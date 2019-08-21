using ImprocPetrsuWrapper.Bindings;

namespace ImprocPetrsuWrapper.Skeletonizers
{
    public class ZhangSuenSkeletonizer : IImageProcessingAction
    {
        public byte[] Process(byte[] imageBytes)
        {
            return ImprocPetrsu.ZhangSuenSkeletonize(imageBytes);
        }
    }
}