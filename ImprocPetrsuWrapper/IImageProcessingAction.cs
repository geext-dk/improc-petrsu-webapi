namespace ImprocPetrsuWrapper
{
    public interface IImageProcessingAction
    {
        byte[] Process(byte[] imageBytes);
    }
}