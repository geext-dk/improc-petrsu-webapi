using System;
using System.Runtime.InteropServices;
using System.Transactions;

namespace ImprocPetrsuWrapper.Bindings
{
    internal static class ImprocPetrsu
    {
        private delegate void ReportProgress(int current, int max);
        public static byte[] ConvertToBinary(byte[] imageBytes, byte threshold, Action<int, int> reportProgress)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr) imageBytes.Length;

            byte[] retImageBytes;
            ReportProgress delegateReportProgress = (current, max) => reportProgress(current, max);
            using (var retImageBuf = Bindings.improc_petrsu_threshold_binary_image_converter_process(bytesPtr, lenUsize,
                threshold, Marshal.GetFunctionPointerForDelegate(delegateReportProgress)))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }

        public static byte[] RosenfeldSkeletonize(byte[] imageBytes, AdjacencyMode mode,
            Action<int, int> reportProgress)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr) imageBytes.Length;

            byte[] retImageBytes;
            ReportProgress delegateReportProgress = (current, max) => reportProgress(current, max);
            using (var retImageBuf = Bindings.improc_petrsu_rosenfeld_skeletonizer_process(bytesPtr, lenUsize,
                (byte) mode,
                Marshal.GetFunctionPointerForDelegate(delegateReportProgress)))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }

        public static byte[] EberlySkeletonize(byte[] imageBytes, Action<int, int> reportProgress)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr) imageBytes.Length;

            byte[] retImageBytes;
            ReportProgress delegateReportProgress = (current, max) => reportProgress(current, max);
            using (var retImageBuf = Bindings.improc_petrsu_eberly_skeletonizer_process(bytesPtr, lenUsize,
                Marshal.GetFunctionPointerForDelegate(delegateReportProgress)))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }

        public static byte[] ZhangSuenSkeletonize(byte[] imageBytes, Action<int, int> reportProgress)
        {
            var bytesPtr = Marshal.AllocHGlobal(imageBytes.Length);
            Marshal.Copy(imageBytes, 0, bytesPtr, imageBytes.Length);
            var lenUsize = (UIntPtr) imageBytes.Length;

            byte[] retImageBytes;
            ReportProgress delegateReportProgress = (current, max) => reportProgress(current, max);
            using (var retImageBuf = Bindings.improc_petrsu_zhang_suen_skeletonizer_process(bytesPtr, lenUsize,
                Marshal.GetFunctionPointerForDelegate(delegateReportProgress)))
            {
                retImageBytes = retImageBuf.ToArray();
            }

            return retImageBytes;
        }
    }
}