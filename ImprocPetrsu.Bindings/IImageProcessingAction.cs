using System;

namespace ImprocPetrsuWrapper
{
    public interface IImageProcessingAction
    {
        byte[] Process(byte[] imageBytes, Action<int, int> reportProgress);
    }
}