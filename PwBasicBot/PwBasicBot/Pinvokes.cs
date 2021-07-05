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

        [DllImport("user32.dll")]
#pragma warning disable IDE1006 // Estilos de Nomenclatura
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
#pragma warning restore IDE1006 // Estilos de Nomenclatura

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

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpMousePoint);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
    }
}
