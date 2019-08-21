using ImprocPetrsuWrapper.Bindings;

namespace ImprocPetrsuWrapper.Skeletonizers
{
    public class EberlySkeletonizer : IImageProcessingAction
    {
        public byte[] Process(byte[] imageBytes)
        {
            return ImprocPetrsu.EberlySkeletonize(imageBytes);
        }
    }
}