using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ImprocPetrsu.Web.Dto;
using ImprocPetrsu.Web.Enums;
using ImprocPetrsu.Web.Services;
using ImprocPetrsuWrapper;
using ImprocPetrsuWrapper.BinaryImageConverters;
using ImprocPetrsuWrapper.Bindings;
using ImprocPetrsuWrapper.Skeletonizers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImprocPetrsu.Web.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly ImageProcessorHostedService _imageProcessorHostedService;

        public ImageController(ImageProcessorHostedService imageProcessorHostedService)
        {
            _imageProcessorHostedService = imageProcessorHostedService;
        }

        [HttpPost("convertToBinary")]
        public async Task<IActionResult> ConvertToBinary(IFormFile file, [FromQuery] byte threshold,
            CancellationToken cancellationToken)
        {
            return await CreateImageRequest(file, bytes =>
            {
                if (threshold == default)
                    threshold = 125;

                var converter = new ThresholdBinaryImageConverter(threshold);
                return new ImageProcessorHostedService.ImageToProcess(bytes, converter);
            }, cancellationToken);
        }

        /// <summary>
        /// Skeletonize the image with the given algorithm
        /// </summary>
        /// <param name="file">A file to skeletonize</param>
        /// <param name="algorithm">An algorithm to use</param>
        /// <param name="adjacencyMode">
        /// An optional adjacency mode to use. Takes effect only with Rosenfeld algorithm
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("skeletonize")]
        public async Task<IActionResult> SkeletonizeImage(IFormFile file,
            [FromQuery] SkeletonizeAlgorithm algorithm = SkeletonizeAlgorithm.ZhangSuen,
            [FromQuery] AdjacencyMode adjacencyMode = AdjacencyMode.Eight,
            CancellationToken cancellationToken = default)
        {
            return await CreateImageRequest(file, bytes =>
            {
                IImageProcessingAction skeletonizer = algorithm switch
                {
                    SkeletonizeAlgorithm.Eberly => new EberlySkeletonizer(),
                    SkeletonizeAlgorithm.Rosenfeld => new RosenfeldSkeletonizer(adjacencyMode),
                    SkeletonizeAlgorithm.ZhangSuen => new ZhangSuenSkeletonizer(),
                    _ => throw new ArgumentException("Unexpected algorithm name: ", nameof(algorithm))
                };
                
                return new ImageProcessorHostedService.ImageToProcess(bytes, skeletonizer);
            }, cancellationToken);
        }

        [HttpGet("getProgress/{imageId:guid}")]
        public IActionResult GetProgress(Guid imageId)
        {
            var progress = _imageProcessorHostedService.GetProgress(imageId);

            return Ok(new ProgressDto {Progress = progress.Progress, IsReady = progress.IsReady});
        }

        [HttpGet("take/{imageId:guid}")]
        public IActionResult TakeImage(Guid imageId)
        {
            var finalImage = _imageProcessorHostedService.TakeCreatedArtifact(imageId);

            return File(finalImage.Bytes, finalImage.ContentType);
        }

        private async Task<IActionResult> CreateImageRequest(IFormFile file,
            Func<byte[], ImageProcessorHostedService.ImageToProcess> func,
            CancellationToken cancellationToken = default)
        {
            await using var fileStream = file.OpenReadStream();
            await using var ms = new MemoryStream();

            await fileStream.CopyToAsync(ms, cancellationToken);

            var imageBytes = ms.ToArray();

            var request = func(imageBytes);

            _imageProcessorHostedService.AddRequestToQueue(request);

            return Accepted(new RequestCreatedDto {ImageId = request.Id});
        }
    }
}