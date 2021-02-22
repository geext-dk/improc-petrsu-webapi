using System;

namespace ImprocPetrsu.Bindings
{
    public interface IImageProcessingAction
    {
        byte[] Process(byte[] imageBytes, Action<int, int> reportProgress);
    }
}