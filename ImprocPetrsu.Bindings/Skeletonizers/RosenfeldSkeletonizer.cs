using System;
using ImprocPetrsuWrapper.Bindings;

namespace ImprocPetrsuWrapper.Skeletonizers
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
            return ImprocPetrsu.RosenfeldSkeletonize(image, _mode, reportProgress);
        }
    }
}