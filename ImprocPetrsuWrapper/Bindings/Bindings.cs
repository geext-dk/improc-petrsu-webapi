using System;
using System.Runtime.InteropServices;

namespace ImprocPetrsuWrapper.Bindings
{
    internal static class Bindings
    {
        [DllImport("improc_petrsu", CallingConvention = CallingConvention.Cdecl)]
        public static extern Buffer improc_petrsu_threshold_binary_image_converter_process(IntPtr bytes, UIntPtr len,
            byte threshold, IntPtr incrementProgress);

        [DllImport("improc_petrsu", CallingConvention = CallingConvention.Cdecl)]
        public static extern Buffer improc_petrsu_rosenfeld_skeletonizer_process(IntPtr bytes, UIntPtr len,
            int adjacency_mode, IntPtr incrementProgress);

        [DllImport("improc_petrsu", CallingConvention = CallingConvention.Cdecl)]
        public static extern Buffer improc_petrsu_eberly_skeletonizer_process(IntPtr bytes, UIntPtr len,
            IntPtr reportProgress);

        [DllImport("improc_petrsu", CallingConvention = CallingConvention.Cdecl)]
        public static extern Buffer improc_petrsu_zhang_suen_skeletonizer_process(IntPtr bytes, UIntPtr len,
            IntPtr incrementProgress);

        [DllImport("improc_petrsu", CallingConvention = CallingConvention.Cdecl)]
        private static extern void improc_petrsu_free(Buffer buffer);

        public struct Buffer : IDisposable
        {
            public IntPtr bytes { get; set; }
            public UIntPtr len { get; set; }

            public byte[] ToArray()
            {
                var size = (int) len;
                var byteArray = new byte[size];
                Marshal.Copy(bytes, byteArray, 0, size);

                return byteArray;
            }

            public void Dispose()
            {
                improc_petrsu_free(this);
            }
        }
    }
}