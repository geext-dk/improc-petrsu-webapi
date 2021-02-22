using System;
using ImprocPetrsu.Bindings.NativeWrappers;

namespace ImprocPetrsu.Bindings.BinaryImageConverters
{
    public class ThresholdBinaryImageConverter : IImageProcessingAction
    {
        private readonly byte _threshold;
        public ThresholdBinaryImageConverter(byte threshold)
        {
            _threshold = threshold;
        }

        public byte[] Process(byte[] imageBytes, Action<int, int> reportProgress)
        {
            return ImprocPetrsuWrapper.ConvertToBinary(imageBytes, _threshold, reportProgress);
        }
    }
}