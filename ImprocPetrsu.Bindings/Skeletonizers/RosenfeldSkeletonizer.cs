using System;
using ImprocPetrsu.Bindings.NativeWrappers;

namespace ImprocPetrsu.Bindings.Skeletonizers
{
    public class RosenfeldSkeletonizer : IImageProcessingAction
    {
        private readonly AdjacencyMode _mode;
        public RosenfeldSkeletonizer(AdjacencyMode mode)
        {
            _mode = mode;
        }
        
        public byte[] Process(byte[] image, Action<int, int> reportProgress)
        {
            return ImprocPetrsuWrapper.RosenfeldSkeletonize(image, _mode, reportProgress);
        }
    }
}