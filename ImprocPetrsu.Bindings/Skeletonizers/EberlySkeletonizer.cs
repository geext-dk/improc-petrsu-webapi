using System;
using ImprocPetrsu.Bindings.NativeWrappers;

namespace ImprocPetrsu.Bindings.Skeletonizers
{
    public class EberlySkeletonizer : IImageProcessingAction
    {
        public byte[] Process(byte[] imageBytes, Action<int, int> reportProgress)
        {
            return ImprocPetrsuWrapper.EberlySkeletonize(imageBytes, reportProgress);
        }
    }
}