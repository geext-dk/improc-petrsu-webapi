using System;
using System.Runtime.InteropServices;

namespace ImprocPetrsuWrapper.Bindings
{
    internal static class Bindings
    {
        [DllImport("improc_petrsu")]
        public static extern Buffer improc_petrsu_threshold_binary_image_convert(IntPtr bytes, UIntPtr len, byte threshold);

        [DllImport("improc_petrsu")]
        public static extern Buffer improc_petrsu_rosenfeld_skeletonization(IntPtr bytes, UIntPtr len, int adjacency_mode);

        [DllImport("improc_petrsu")]
        public static extern Buffer improc_petrsu_eberly_skeletonization(IntPtr bytes, UIntPtr len);

        [DllImport("improc_petrsu")]
        public static extern Buffer improc_petrsu_zhang_suen_skeletonization(IntPtr bytes, UIntPtr len);

        public struct Buffer : IDisposable
        {
            public IntPtr bytes { get; set; }
            public UIntPtr len { get; set; }

            public byte[] ToArray()
            {
                var size = (int)len;
                var byteArray = new byte[size];
                Marshal.Copy(bytes, byteArray, 0, size);

                return byteArray;
            }

            public void Dispose()
            {
                Bindings.improc_petrsu_free(this);
            }
        }

        [DllImport("improc_petrsu")]
        private static extern void improc_petrsu_free(Buffer buffer);
    }
}