using System.Runtime.InteropServices;
using System.Text;

namespace Lab;

internal static class NativeMethods
{
    [DllImport("user32.dll", EntryPoint = "OpenDesktop", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern IntPtr OpenDesktop(string lpszDesktop, int dwFlags, bool fInherit, Int32 dwDesiredAccess);

    [DllImport("user32.dll", EntryPoint = "CreateDesktopEx", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateDesktopEx(string lpszDesktop,
                                                   IntPtr lpszDevice,
                                                   IntPtr pDevmode,
                                                   Int32 dwFlags,
                                                   Int32 dwDesiredAccess,
                                                   IntPtr lpsa,
                                                   UInt32 ulHeapSize,
                                                   IntPtr pVoid);

    [DllImport("user32.dll", EntryPoint = "CloseDesktop", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CloseDesktop(IntPtr handle);

    [DllImport("user32.dll", EntryPoint = "SwitchDesktop", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SwitchDesktop(IntPtr hDesktop);

    [DllImport("user32.dll", EntryPoint = "EnumDesktops", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool EnumDesktops(IntPtr hWinSta, EnumDesktopProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "GetProcessWindowStation", SetLastError = true)]
    internal static extern IntPtr GetProcessWindowStation();

    [DllImport("kernel32.dll", EntryPoint = "CreateProcess", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            int dwCreationFlags,
            IntPtr lpEnvironment,
            string lpCurrentDirectory,
            ref StartupInfo lpStartupInfo,
            ref ProcessInformation lpProcessInformation
    );

    [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsDelegate enumWindowsCallback, IntPtr lParam);

    [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
    [return: MarshalAs(UnmanagedType.U4)]
    internal static extern int GetWindowThreadProcessId(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] out int processID);

    [DllImport("kernel32.dll", EntryPoint = "GetLastError")]
    internal static extern int GetLastError();

    [DllImport("user32.dll", EntryPoint = "SetThreadDesktop", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool SetThreadDesktop(IntPtr hDesktop);

    [DllImport("user32.dll", EntryPoint = "GetThreadDesktop", SetLastError = true)]
    internal static extern IntPtr GetThreadDesktop(int threadID);

    [DllImport("user32.dll", EntryPoint = "GetUserObjectInformation", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetUserObjectInformation(IntPtr userObject, int index, IntPtr buffer, int bufferSize, IntPtr bufferLengthNeeded);

    [DllImport("kernel32.dll", EntryPoint = "GetCurrentThreadId", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.U4)]
    internal static extern int GetNativeThreadId();

    [DllImport("shell32.dll")]
    [return: MarshalAs(UnmanagedType.U4)]
    internal static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);


    /// <summary />
    [Flags]
    internal enum DesktopAccessMask : uint
    {
        /// <summary />
        DesktopReadObjects = 0x0001,

        /// <summary />
        DesktopCreateWindow = 0x0002,

        /// <summary />
        DesktopCreateMenu = 0x0004,

        /// <summary />
        DesktopHookControl = 0x0008,

        /// <summary />
        DesktopJournalRecord = 0x0010,

        /// <summary />
        DesktopJournalPlayback = 0x0020,

        /// <summary />
        DesktopEnumerate = 0x0040,

        /// <summary />
        DesktopWriteObjects = 0x0080,

        /// <summary />
        DesktopSwitchDesktop = 0x0100,

        /// <summary />
        Delete = 0x00010000,

        /// <summary />
        GenericAll = DesktopReadObjects | DesktopCreateWindow | DesktopCreateMenu |
                     DesktopHookControl | DesktopJournalRecord | DesktopJournalPlayback |
                     DesktopEnumerate | DesktopWriteObjects | DesktopSwitchDesktop
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct ProcessInformation
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct StartupInfo
    {
        public int cb;
        public string lpReserved;
        public string lpDesktop;
        public string lpTitle;
        public int dwX;
        public int dwY;
        public int dwXSize;
        public int dwYSize;
        public int dwXCountChars;
        public int dwYCountChars;
        public int dwFillAttribute;
        public int dwFlags;
        public short wShowWindow;
        public short cbReserved2;
        public IntPtr lpReserved2;
        public IntPtr hStdInput;
        public IntPtr hStdOutput;
        public IntPtr hStdError;
    }

    internal delegate bool EnumDesktopProc(string lpszDesktop, IntPtr lParam);

    /// <summary />
    internal delegate bool EnumWindowsDelegate(IntPtr hWindow, IntPtr lParam);
}

