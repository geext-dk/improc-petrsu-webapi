using System;
using System.Runtime.InteropServices;
using ImprocPetrsuWrapper.Bindings;

namespace ImprocPetrsuWrapper.BinaryImageConverters
{
    public class ThresholdBinaryImageConverter : IImageProcessingAction
    {
        private byte _threshold;
        public ThresholdBinaryImageConverter(byte threshold)
        {
            _threshold = threshold;
        }

        public byte[] Process(byte[] imageBytes, Action<int, int> reportProgress)
        {
            return ImprocPetrsu.ConvertToBinary(imageBytes, _threshold, reportProgress);
        }
    }
}