using System;
using System.Runtime.InteropServices;

namespace ImprocPetrsuWrapper.Bindings
{
    internal static class ImprocPetrsu
    {
        public static byte[] ConvertToBinary(byte[] imageBytes, byte threshold)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr)imageBytes.Length;

            byte[] retImageBytes;
            using (var retImageBuf = Bindings.improc_petrsu_threshold_binary_image_convert(bytesPtr, lenUsize, threshold))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }

        public static byte[] RosenfeldSkeletonize(byte[] imageBytes, AdjacencyMode mode)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr)imageBytes.Length;

            byte[] retImageBytes;
            using (var retImageBuf = Bindings.improc_petrsu_rosenfeld_skeletonization(bytesPtr, lenUsize, (byte)mode))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }

        public static byte[] EberlySkeletonize(byte[] imageBytes)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr)imageBytes.Length;

            byte[] retImageBytes;
            using (var retImageBuf = Bindings.improc_petrsu_eberly_skeletonization(bytesPtr, lenUsize))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }

        public static byte[] ZhangSuenSkeletonize(byte[] imageBytes)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr)imageBytes.Length;

            byte[] retImageBytes;
            using (var retImageBuf = Bindings.improc_petrsu_zhang_suen_skeletonization(bytesPtr, lenUsize))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }
    }
}
