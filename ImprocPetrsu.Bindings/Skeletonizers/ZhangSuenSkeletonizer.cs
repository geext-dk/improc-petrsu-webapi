using System;
using ImprocPetrsu.Bindings.NativeWrappers;

namespace ImprocPetrsu.Bindings.Skeletonizers
{
    public class ZhangSuenSkeletonizer : IImageProcessingAction
    {
        public byte[] Process(byte[] imageBytes, Action<int, int> reportProgress)
        {
            return ImprocPetrsuWrapper.ZhangSuenSkeletonize(imageBytes, reportProgress);
        }
    }
}