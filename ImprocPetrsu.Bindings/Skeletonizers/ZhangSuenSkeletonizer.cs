using System;
using ImprocPetrsuWrapper.Bindings;

namespace ImprocPetrsuWrapper.Skeletonizers
{
    public class ZhangSuenSkeletonizer : IImageProcessingAction
    {
        public byte[] Process(byte[] imageBytes, Action<int, int> reportProgress)
        {
            return ImprocPetrsu.ZhangSuenSkeletonize(imageBytes, reportProgress);
        }
    }
}