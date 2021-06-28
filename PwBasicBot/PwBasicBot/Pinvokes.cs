using PInvoke;
using System;
using System.Runtime.InteropServices;

namespace PwBasicBot
{
    public static class Pinvokes
    {
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr OpenProcess(
            int dwDesiredAccess,
            IntPtr bInheritHandle,
            IntPtr dwProcessId
            );

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess, 
            IntPtr lpBaseAddress, 
            [Out] byte[] lpBuffer, 
            int dwSize, 
            out IntPtr lpNumberOfBytesRead
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(
             uint processAccess,
             bool bInheritHandle,
             int processId
        );

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern UInt32 NtReadVirtualMemory(int ProcessHandle, int BaseAddress, byte[] Buffer, int NumberOfBytesToRead, ref int NumberOfBytesRead);

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern NTSTATUS NtWriteVirtualMemory(int ProcessHandle, int BaseAddress, byte[] Buffer, int NumberOfBytesToWrite, ref int NumberOfBytesWritten);
    }
}
