using System;
using ImprocPetrsuWrapper.Bindings;

namespace ImprocPetrsuWrapper.Skeletonizers
{
    public class EberlySkeletonizer : IImageProcessingAction
    {
        public byte[] Process(byte[] imageBytes, Action<int, int> reportProgress)
        {
            return ImprocPetrsu.EberlySkeletonize(imageBytes, reportProgress);
        }
    }
}