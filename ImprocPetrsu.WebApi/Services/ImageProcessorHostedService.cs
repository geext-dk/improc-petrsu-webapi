using System;
using System.Threading;
using System.Threading.Tasks;
using Geext.AsyncArtifactCreator;
using ImprocPetrsu.Bindings;
using Microsoft.Extensions.Hosting;

namespace ImprocPetrsu.WebApi.Services
{
    public class ImageProcessorHostedService
        : AsyncArtifactCreator<ImageProcessorHostedService.ImageToProcess,
                ImageProcessorHostedService.FinalImage,
                Guid>,
        IHostedService
    {
        protected override Task<FinalImage> ProduceArtifact(ImageToProcess request,
            CancellationToken cancellationToken = default)
        {
            var newBytes = request.Action.Process(request.Bytes, (current, max) =>
            {
                ReportProgress(request.Id, (double) current / max);
            });

            return Task.FromResult(new FinalImage(request.Id, newBytes));
        }

        protected override Guid GetIdentity(ImageToProcess request)
        {
            return request.Id;
        }

        protected override Guid GetIdentity(FinalImage artifact)
        {
            return artifact.Id;
        }

        public class ImageToProcess
        {
            public ImageToProcess(byte[] bytes, IImageProcessingAction action)
            {
                Id = Guid.NewGuid();
                Bytes = bytes;
                Action = action;
            }

            public byte[] Bytes { get; }
            public Guid Id { get; }
            public IImageProcessingAction Action { get; }
        }

        public class FinalImage
        {
            public FinalImage(Guid id, byte[] bytes)
            {
                Id = id;
                Bytes = bytes;
            }

            public Guid Id { get; }
            public byte[] Bytes { get; }
            public string ContentType => "image/png";
        }
    }
}