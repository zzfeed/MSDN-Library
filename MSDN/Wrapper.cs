
using MSDN.Api;
using MSDN.Enum;
using MSDN.Error;
using MSDN.Struct;
using MSDN.Wrapper;
using MSDN.Delegate;
using MSDN.Extension;
using MSDN.Interface;
using MSDN.SafeHandle;

using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Management;
using System.Diagnostics;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Management.Instrumentation;

using GUID = System.Guid;

using WCHAR = System.Char;
using TCHAR = System.Char;
using LPCTSTR = System.String;

using BOOL = System.Boolean;
using BOOLEAN = System.Byte;

using BYTE = System.Byte;
using CHAR = System.Byte;
using UCHAR = System.Byte;
using UINT8 = System.Byte;

using WORD = System.Int16;
using SHORT = System.Int16;
using USHORT = System.UInt16;

using LANGID = System.UInt32;
using DWORD = System.UInt32;
using UINT = System.UInt32;
using DEVICE_TYPE = System.UInt32;
using SIZE_T = System.UInt32;
using UINT32 = System.UInt32;
using ULONG = System.UInt32;
using LONG = System.Int32;
using COLORREF = System.UInt32;
using INT = System.Int32;
using SCOPE_ID = System.UInt32;
using NET_IFINDEX = System.Int32;

using DWORD64 = System.UInt64;
using DWORDLONG = System.UInt64;
using LARGE_INTEGER = System.Int64;
using ULONG64 = System.UInt64;
using LONGLONG = System.Int64;
using ULONGLONG = System.UInt64;
using USN = System.Int64;
using time_t = System.Int64;
using NET_LUID = System.UInt64;

using HDC = System.IntPtr;
using HDEVINFO = System.IntPtr;
using DEVINST = System.IntPtr;
using HPALETTE = System.IntPtr;
using ULONG_PTR = System.UIntPtr;
using DWORD_PTR = System.UIntPtr;
using FARPROC = System.IntPtr;
using VOID = System.IntPtr;
using PVOID = System.IntPtr;
using LPVOID = System.IntPtr;
using HMODULE = System.IntPtr;
using HANDLE = System.IntPtr;
using HWND = System.IntPtr;
using HGLOBAL = System.IntPtr;
using LONG_PTR = System.IntPtr;
using HLOCAL = System.IntPtr;
using LPCVOID = System.IntPtr;
using HMENU = System.IntPtr;
using HINSTANCE = System.IntPtr;
using CONFLICT_LIST = System.IntPtr;

namespace MSDN.Wrapper
{
    #region Window
    public sealed class NativeHelper : NativeWindow
    {
        public NativeHelper()
        {
            var cp = new CreateParams();
            CreateHandle(cp);
        }

        public Func<Message, bool> MessgeHandler;

        protected override void WndProc(ref Message m)
        {
            if ((MessgeHandler == null) ||
                (MessgeHandler != null && MessgeHandler(m)))
            {
                base.WndProc(ref m);
            }
        }

        public SafeWindowHandle WindowHandle
        {
            get { return new SafeWindowHandle(Handle); }
        }
    }
    [ComImport, Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
    public sealed class TaskbarListManger : ITaskbarList
    {
        // ITaskbarList
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void HrInit();
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void AddTab(SafeWindowHandle hwnd);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void DeleteTab(SafeWindowHandle hwnd);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void ActivateTab(SafeWindowHandle hwnd);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetActiveAlt(SafeWindowHandle hwnd);

        // ITaskbarList2
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void MarkFullscreenWindow(
            SafeWindowHandle hwnd, bool fFullscreen);

        // ITaskbarList3
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetProgressValue(
            SafeWindowHandle hwnd, UInt64 ullCompleted, UInt64 ullTotal);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetProgressState(
            SafeWindowHandle hwnd, TaskbarProgressBarStatus tbpFlags);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void RegisterTab(
            SafeWindowHandle hwndTab, SafeWindowHandle hwndMdi);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void UnregisterTab(
            SafeWindowHandle hwndTab);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetTabOrder(
            SafeWindowHandle hwndTab, SafeWindowHandle hwndInsertBefore);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetTabActive(
            SafeWindowHandle hwndTab, SafeWindowHandle hwndInsertBefore, uint dwReserved);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern ComError ThumbBarAddButtons(
            SafeWindowHandle hwnd, uint cButtons, ThumbButton[] pButtons);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern ComError ThumbBarUpdateButtons(
            SafeWindowHandle hwnd, uint cButtons, ThumbButton[] pButtons);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void ThumbBarSetImageList(SafeWindowHandle hwnd, IntPtr himl);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetOverlayIcon(
          SafeWindowHandle hwnd, IntPtr hIcon, string pszDescription);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetThumbnailTooltip(
            SafeWindowHandle hwnd, string pszTip);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall,
            MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetThumbnailClip(
            SafeWindowHandle hwnd, IntPtr prcClip);

        // ITaskbarList4
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(7)]
        public extern void SetTabProperties(
            SafeWindowHandle hwndTab, SetTabPropertiesOption stpFlags);
    }
    public sealed class DesktopWindowManager
    {
        private SafeWindowHandle hwnd;
        public DesktopWindowManager(
            SafeWindowHandle hwnd)
        {
            this.hwnd = hwnd;
        }

        public ComError Margin(
            int xI, int yI,
            int height, int width)
        {
            var m = new MARGINS()
            {

                cxLeftWidth = xI,
                cxRightWidth = yI,
                cyBottomHeight = xI + height,
                cyTopHeight = yI + width,
            };
            return dwmApi.DwmExtendFrameIntoClientArea(
                hwnd, ref m);
        }

        public ComError Blur(
            bool enable,
            bool transitionOnMaximized,
            SafeRegionHandle region)
        {
            var pBlurBehind = new DWM_BLURBEHIND()
            {
                dwFlags =
                    DWM_BB.fEnable | DWM_BB.hRgnBlur |
                    DWM_BB.fTransitionOnMaximized,
                fEnable = enable,
                fTransitionOnMaximized = transitionOnMaximized,
                hRgnBlur = region
            };

            return dwmApi.DwmEnableBlurBehindWindow(
                hwnd, ref pBlurBehind);
        }

        public bool CompositionMode
        {
            get
            {
                bool pfEnabled;
                return dwmApi.DwmIsCompositionEnabled(out pfEnabled) == 0
                    && pfEnabled;
            }
            set { dwmApi.DwmEnableComposition(value); }
        }
    }
    public sealed class Console : IDisposable
    {
        private SafeConsoleHandle _stdInput;
        private SafeConsoleHandle _stdOutput;
        private SafeConsoleHandle _stdError;

        public Func<Console, INPUT_RECORD, bool> onReceiveHook;
        public Func<Console, CtrlType, bool> onReceiveRoutine;

        private Console() { }
        public static Console Current
        {
            get
            {
                return new Console()
                {
                    _stdInput = kernel32.GetStdHandle(StdHandle.STD_INPUT_HANDLE),
                    _stdOutput = kernel32.GetStdHandle(StdHandle.STD_OUTPUT_HANDLE),
                    _stdError = kernel32.GetStdHandle(StdHandle.STD_ERROR_HANDLE)
                };
            }
        }
        public static SafeWindowHandle Window
        {
            get { return user32.GetConsoleWindow(); }
        }
        public static Console Create()
        {
            kernel32.AllocConsole();
            return Current;
        }
        public static Console Create(
            SafeConsoleHandle stdInput,
            SafeConsoleHandle stdOutput,
            SafeConsoleHandle stdError)
        {
            return new Console()
            {
                _stdInput = stdInput,
                _stdOutput = stdOutput,
                _stdError = stdError
            };
        }
        public void Dispose()
        {
            kernel32.FreeConsole();
        }

        public void Kill()
        {
            kernel32.GenerateConsoleCtrlEvent(
                1 /* CTRL BREAK Key */, 0 /* any process */);
        }
        public void Hook()
        {
            uint lpNumberOfEventsRead;
            var buffer = new INPUT_RECORD[100];
            this.StdInputModes =
                ConsoleModes.ENABLE_WINDOW_INPUT |
                ConsoleModes.ENABLE_MOUSE_INPUT;
            var canContinue = true;
            while (canContinue)
            {
                if (!kernel32.ReadConsoleInput(
                    _stdInput, buffer, (uint)buffer.Length, out lpNumberOfEventsRead))
                    break;

                for (var i = 0; i < lpNumberOfEventsRead; i++)
                {
                    if ((canContinue = onReceiveHook(this, buffer[i])) == false)
                        break;

                }
            }
        }
        public void Route()
        {
            if (!kernel32.SetConsoleCtrlHandler(HandlerRoutine, true))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }
        private bool HandlerRoutine(CtrlType dwCtrlType)
        {
            return kernel32.SetConsoleCtrlHandler(HandlerRoutine, false);
        }

        const string NewLine = "\r\n";
        public void Write(object value)
        {
            if (value == null)
                return;

            DWORD lpNumberOfCharsWritten;
            DWORD nNumberOfCharsToWrite = (DWORD)value.ToString().Length;
            LPVOID lpBuffer = Marshal.StringToHGlobalUni(value.ToString());
            kernel32.WriteConsole(
                _stdOutput, lpBuffer,
                nNumberOfCharsToWrite,
                out lpNumberOfCharsWritten, IntPtr.Zero);
            Marshal.FreeHGlobal(lpBuffer);

            // also we can use this
            // WriteConsoleOutputCharacter
        }
        public void Write(object value, short xI, short yI)
        {
            if (value == null)
                return;

            this.Position = new COORD() { X = xI, Y = yI };
            Write(value);
        }
        public void Write(object value, short xI, short yI, Enum.Attribute colour)
        {
            if (value == null)
                return;

            var col = this.Colour;
            this.Colour = colour;
            this.Position = new COORD() { X = xI, Y = yI };
            Write(value);
            this.Colour = col;
        }
        public void WriteLine()
        {
            DWORD lpNumberOfCharsWritten;
            DWORD nNumberOfCharsToWrite = (DWORD)NewLine.Length;
            LPVOID lpBuffer = Marshal.StringToHGlobalUni(NewLine);
            kernel32.WriteConsole(_stdOutput, lpBuffer, nNumberOfCharsToWrite, out lpNumberOfCharsWritten, IntPtr.Zero);
            Marshal.FreeHGlobal(lpBuffer);

            // also we can use this
            // WriteConsoleOutputCharacter
        }
        public void WriteLine(object value)
        {
            if (value == null)
                return;

            var _value = value + NewLine;
            DWORD lpNumberOfCharsWritten;
            DWORD nNumberOfCharsToWrite = (DWORD)_value.Length;
            LPVOID lpBuffer = Marshal.StringToHGlobalUni(_value);
            kernel32.WriteConsole(_stdOutput, lpBuffer, nNumberOfCharsToWrite, out lpNumberOfCharsWritten, IntPtr.Zero);
            Marshal.FreeHGlobal(lpBuffer);

            // also we can use this
            // WriteConsoleOutputCharacter
        }
        public void WriteLine(object value, short xI, short yI)
        {
            if (value == null)
                return;

            this.Position = new COORD() { X = xI, Y = yI }; ;
            WriteLine(value);
        }
        public void WriteLine(object value, short xI, short yI, Enum.Attribute colour)
        {
            if (value == null)
                return;

            var col = this.Colour;
            this.Colour = colour;
            this.Position = new COORD() { X = xI, Y = yI }; ;
            WriteLine(value);
            this.Colour = col;
        }

        public Char ReadKey()
        {
            DWORD lpNumberOfCharsRead;
            LPCVOID lpBuffer = Marshal.AllocHGlobal(1 * Marshal.SystemDefaultCharSize);
            kernel32.ReadConsole(_stdInput, lpBuffer, 1, out lpNumberOfCharsRead, IntPtr.Zero);

            var result = Marshal.PtrToStringUni(lpBuffer, (int)lpNumberOfCharsRead);
            Marshal.FreeHGlobal(lpBuffer);
            return result[0];

            // also we can use this
            // ReadConsoleOutputCharacter
        }
        public string ReadLine(DWORD nNumberOfCharsToRead = 250)
        {
            DWORD lpNumberOfCharsRead;
            LPCVOID lpBuffer = Marshal.AllocHGlobal((int)nNumberOfCharsToRead * Marshal.SystemDefaultCharSize);
            kernel32.ReadConsole(_stdInput, lpBuffer, nNumberOfCharsToRead, out lpNumberOfCharsRead, IntPtr.Zero);

            var result = Marshal.PtrToStringUni(lpBuffer, (int)lpNumberOfCharsRead);
            Marshal.FreeHGlobal(lpBuffer);
            return result;

            // also we can use this
            // ReadConsoleOutputCharacter
        }
        public void Flush()
        {
            kernel32.FlushConsoleInputBuffer(_stdInput);
        }
        public void Clear()
        {
            CONSOLE_SCREEN_BUFFER_INFO info;
            kernel32.GetConsoleScreenBufferInfo(_stdOutput, out info);

            this.SetChar((char)32, 0, 0, (uint)(info.dwSize.X * info.dwSize.Y));
            this.Position = new COORD() { X = 0, Y = 0 };
        }

        public void GetTable(ref CHAR_INFO[,] table, short xI, short yI)
        {
            COORD
                size = new COORD
                {
                    X = (SHORT)table.GetLength(1),
                    Y = (SHORT)table.GetLength(0)
                },
                location = new COORD()
                {
                    X = xI,
                    Y = yI
                };
            var position = new SMALL_RECT()
            {
                Left = location.X,
                Right = (SHORT)(location.X + size.X - 1),
                Top = location.Y,
                Bottom = (SHORT)(location.Y + size.Y - 1),
            };

            // do the Job.
            if (!kernel32.ReadConsoleOutput(
                _stdOutput, table, size, location, ref position))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }
        public void SetTable(CHAR_INFO[,] table, short xI, short yI)
        {
            COORD
                size = new COORD()
                {
                    X = (SHORT)table.GetLength(1),
                    Y = (SHORT)table.GetLength(0)
                },
                location = new COORD()
                {
                    X = xI,
                    Y = yI
                };
            var position = new SMALL_RECT()
            {
                Left = location.X,
                Right = (SHORT)(location.X + size.X - 1),
                Top = location.Y,
                Bottom = (SHORT)(location.Y + size.Y - 1),
            };

            // do the Job.
            if (!kernel32.WriteConsoleOutput(
                _stdOutput, table, size, location, ref position))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }
        public void SetColour(Enum.Attribute attribute, short xI, short yI, uint length)
        {
            uint result;
            if (!kernel32.FillConsoleOutputAttribute(
                _stdOutput, attribute, length, new COORD(xI, yI), out result))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            // we can also Use 'WriteConsoleOutputAttribute'
            // but we need to make an Array of Attribute
            // and other ugly stuff ...
        }
        public void SetChar(Char character, short xI, short yI, uint length)
        {
            uint result;
            if (!kernel32.FillConsoleOutputCharacter(
                _stdOutput,
                character,
                length,
                new COORD() { X = xI, Y = yI },
                out result))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }
        public void Move(
            SMALL_RECT lpScrollRectangle,
            COORD dwDestinationOrigin,
            CHAR_INFO lpFill)
        {
            if (!kernel32.ScrollConsoleScreenBuffer(
                _stdOutput, ref lpScrollRectangle, IntPtr.Zero, dwDestinationOrigin, ref lpFill))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }

        public string Title
        {
            get
            {
                var builder = new StringBuilder(256);
                if (kernel32.GetConsoleTitle(builder, (uint)builder.Capacity) > 0)
                    return Convert.ToString(builder);

                throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
            set
            {
                if (kernel32.SetConsoleTitle(value) != 0)
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public string OrigionalTitle
        {
            get
            {
                var builder = new StringBuilder(256);
                if (kernel32.GetConsoleOriginalTitle(builder, (uint)builder.Capacity) > 0)
                    return Convert.ToString(builder);

                throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public string Font
        {
            get
            {
                var font = string.Empty;
                var info = new CONSOLE_FONT_INFOEX();
                info.cbSize = (uint)Marshal.SizeOf(info);
                if (!kernel32.GetCurrentConsoleFontEx(_stdOutput, false, ref info))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
                unsafe
                {
                    font = new string(info.FaceName);
                }

                return font;
            }
        }
        public SafeConsoleHandle StdInput
        {
            get { return _stdInput; }
        }
        public SafeConsoleHandle StdOutput
        {
            get { return _stdOutput; }
        }
        public SafeConsoleHandle StdError
        {
            get { return _stdError; }
        }
        public ConsoleModes StdInputModes
        {
            get
            {
                ConsoleModes modes;
                if (kernel32.GetConsoleMode(_stdInput, out modes))
                    return modes;
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleMode(_stdInput, value))
                    throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }
        public ConsoleModes StdOutputModes
        {
            get
            {
                ConsoleModes modes;
                if (kernel32.GetConsoleMode(_stdOutput, out modes))
                    return modes;
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleMode(_stdOutput, value))
                    throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }
        public COORD Position
        {
            get
            {
                CONSOLE_SCREEN_BUFFER_INFO info;
                if (kernel32.GetConsoleScreenBufferInfo(_stdOutput, out info))
                    return info.dwCursorPosition;

                throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleCursorPosition(_stdOutput, value))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public ConsoleMode Mode
        {
            get
            {
                ConsoleMode mode;
                if (kernel32.GetConsoleDisplayMode(out mode))
                    return mode;

                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleDisplayMode(_stdOutput, value, IntPtr.Zero))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public SMALL_RECT Size
        {
            get
            {
                CONSOLE_SCREEN_BUFFER_INFO info;
                if (kernel32.GetConsoleScreenBufferInfo(_stdOutput, out info))
                    return info.srWindow;

                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleWindowInfo(_stdOutput, true, ref value))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public Enum.Attribute Colour
        {
            get
            {
                CONSOLE_SCREEN_BUFFER_INFO info;
                if (kernel32.GetConsoleScreenBufferInfo(_stdOutput, out info))
                    return info.wAttributes;

                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleTextAttribute(_stdOutput, value))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public COORD MaximumSize
        {
            get
            {
                CONSOLE_SCREEN_BUFFER_INFO info;
                if (kernel32.GetConsoleScreenBufferInfo(_stdOutput, out info))
                    return info.dwMaximumWindowSize;

                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }
        public CONSOLE_CURSOR_INFO Cursor
        {
            get
            {
                CONSOLE_CURSOR_INFO cursor;
                if (kernel32.GetConsoleCursorInfo(_stdOutput, out cursor))
                    return cursor;

                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
            set
            {
                if (!kernel32.SetConsoleCursorInfo(_stdOutput, ref value))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }
        public unsafe DWORD[] Process
        {
            get
            {
                DWORD dwProcessCount = 50;

                var lpdwProcessList = (DWORD*)kernel32.GlobalAlloc(
                    GlobalMemoryFlags.Fixed,
                    dwProcessCount * (uint)Marshal.SizeOf(dwProcessCount));

                var ret = kernel32.GetConsoleProcessList(
                    lpdwProcessList,
                    dwProcessCount);

                var processList = new uint[ret];
                if (ret > 0)
                {
                    for (var i = 0; i < ret; i++) { processList[i] = lpdwProcessList[i]; }
                    kernel32.GlobalFree((IntPtr)lpdwProcessList);
                    return processList;
                }

                kernel32.GlobalFree((IntPtr)lpdwProcessList);
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }
    }
    #endregion

    #region Process
    public static class PrivilegesHelper
    {
        /// <summary>
        /// Privilege Types
        /// </summary>
        public static class Types
        {
            public static string SE_ASSIGNPRIMARYTOKEN = "SeAssignPrimaryTokenPrivilege";
            public static string SE_AUDIT = "SeAuditPrivilege";
            public static string SE_BACKUP = "SeBackupPrivilege";
            public static string SE_CHANGE_NOTIFY = "SeChangeNotifyPrivilege";
            public static string SE_CREATE_GLOBAL = "SeCreateGlobalPrivilege";
            public static string SE_CREATE_PAGEFILE = "SeCreatePagefilePrivilege";
            public static string SE_CREATE_PERMANENT = "SeCreatePermanentPrivilege";
            public static string SE_CREATE_SYMBOLIC_LINK = "SeCreateSymbolicLinkPrivilege";
            public static string SE_CREATE_TOKEN = "SeCreateTokenPrivilege";
            public static string SE_DEBUG = "SeDebugPrivilege";
            public static string SE_ENABLE_DELEGATION = "SeEnableDelegationPrivilege";
            public static string SE_IMPERSONATE = "SeImpersonatePrivilege";
            public static string SE_INC_BASE_PRIORITY = "SeIncreaseBasePriorityPrivilege";
            public static string SE_INCREASE_QUOTA = "SeIncreaseQuotaPrivilege";
            public static string SE_INC_WORKING_SET = "SeIncreaseWorkingSetPrivilege";
            public static string SE_LOAD_DRIVER = "SeLoadDriverPrivilege";
            public static string SE_LOCK_MEMORY = "SeLockMemoryPrivilege";
            public static string SE_MACHINE_ACCOUNT = "SeMachineAccountPrivilege";
            public static string SE_MANAGE_VOLUME = "SeManageVolumePrivilege";
            public static string SE_PROF_SINGLE_PROCESS = "SeProfileSingleProcessPrivilege";
            public static string SE_RELABEL = "SeRelabelPrivilege";
            public static string SE_REMOTE_SHUTDOWN = "SeRemoteShutdownPrivilege";
            public static string SE_RESTORE = "SeRestorePrivilege";
            public static string SE_SECURITY = "SeSecurityPrivilege";
            public static string SE_SHUTDOWN = "SeShutdownPrivilege";
            public static string SE_SYNC_AGENT = "SeSyncAgentPrivilege";
            public static string SE_SYSTEM_ENVIRONMENT = "SeSystemEnvironmentPrivilege";
            public static string SE_SYSTEM_PROFILE = "SeSystemProfilePrivilege";
            public static string SE_SYSTEMTIME = "SeSystemtimePrivilege";
            public static string SE_TAKE_OWNERSHIP = "SeTakeOwnershipPrivilege";
            public static string SE_TCB = "SeTcbPrivilege";
            public static string SE_TIME_ZONE = "SeTimeZonePrivilege";
            public static string SE_TRUSTED_CREDMAN_ACCESS = "SeTrustedCredManAccessPrivilege";
            public static string SE_UNDOCK = "SeUndockPrivilege";
            public static string SE_UNSOLICITED_INPUT = "SeUnsolicitedInputPrivilege";

            public static string[] SE_ALL = new[]
                {
                    SE_ASSIGNPRIMARYTOKEN, SE_AUDIT, SE_BACKUP, SE_CHANGE_NOTIFY,
                    SE_CREATE_GLOBAL, SE_CREATE_PAGEFILE, SE_CREATE_PERMANENT, SE_CREATE_SYMBOLIC_LINK,
                    SE_CREATE_TOKEN, SE_DEBUG, SE_ENABLE_DELEGATION, SE_IMPERSONATE, SE_INC_BASE_PRIORITY,
                    SE_INCREASE_QUOTA, SE_INC_WORKING_SET, SE_LOAD_DRIVER, SE_LOCK_MEMORY, SE_MACHINE_ACCOUNT,
                    SE_MANAGE_VOLUME, SE_PROF_SINGLE_PROCESS, SE_RELABEL, SE_REMOTE_SHUTDOWN, SE_RESTORE,
                    SE_SECURITY, SE_SHUTDOWN, SE_SYNC_AGENT, SE_SYSTEM_ENVIRONMENT,
                    SE_SYSTEM_PROFILE, SE_SYSTEMTIME, SE_TAKE_OWNERSHIP, SE_TCB, SE_TIME_ZONE,
                    SE_TRUSTED_CREDMAN_ACCESS, SE_UNDOCK, SE_UNSOLICITED_INPUT
                };
        }

        public static bool Check(SafeProcessHandle pHandle, string prev)
        {
            // define some crap
            SafeTokenHandle tHandle;

            // get Access Token
            if (!advapi32.OpenProcessToken(
                pHandle,
                TokenAccess.ADJUST_PRIVILEGES |
                TokenAccess.QUERY, out tHandle))
                return false;

            // get Result
            var requiredPrivileges = new PPRIVILEGE_SET
            {
                PrivilegeCount = 1,
                //Control = any ? 0 : (uint)1,
                Control = 1,
                First = new LUID_AND_ATTRIBUTES()
            };
            BOOL result;
            return LUID.fromString(prev, ref requiredPrivileges.First) &&
                advapi32.PrivilegeCheck(tHandle, ref requiredPrivileges, out result) &&
                result;
        }
        public unsafe static Dictionary<string, PrivilegeState> Enum(SafeProcessHandle pHandle)
        {
            // define some crap
            SafeTokenHandle tHandle;
            var luidList = new Dictionary<string, PrivilegeState>();

            // get Access Token
            if (!advapi32.OpenProcessToken(
                pHandle,
                TokenAccess.ADJUST_PRIVILEGES | TokenAccess.QUERY,
                out tHandle))
                return null;

            uint tokenInformationLength = 0;
            var tokenInformation = (TOKEN_INFORMATION*)0;

            // get size to Read
            advapi32.GetTokenInformation(
                tHandle,
                TOKEN_INFORMATION_CLASS.TokenPrivileges,
                tokenInformation,
                tokenInformationLength,
                out tokenInformationLength);

            // resize handle
            tokenInformation =
                (TOKEN_INFORMATION*)msvcrt.malloc(tokenInformationLength);
            advapi32.GetTokenInformation(
                tHandle,
                TOKEN_INFORMATION_CLASS.TokenPrivileges,
                tokenInformation, tokenInformationLength,
                out tokenInformationLength);

            // get result
            var tokenPrivileges = &tokenInformation->TokenPrivileges;
            for (var i = 0; i < tokenPrivileges->PrivilegeCount; i++)
            {
                var attrib = (&tokenPrivileges->First)[i];
                luidList.Add(attrib.Luid.ToString(), attrib.Attributes);
            }

            msvcrt.free((IntPtr)tokenInformation);

            // return result
            return luidList;
        }
        public static Dictionary<string, bool> Take(SafeProcessHandle pHandle, bool enable, params string[] tokenPrivilegeTypes)
        {
            // define some crap
            SafeTokenHandle tHandle;
            var luidList = new Dictionary<string, bool>();

            // get Access Token
            if (!advapi32.OpenProcessToken(
                pHandle,
                TokenAccess.ADJUST_PRIVILEGES | TokenAccess.QUERY,
                out tHandle))
                return null;

            {
                var newState = new TOKEN_PRIVILEGES()
                {
                    PrivilegeCount = 1,
                    First = new LUID_AND_ATTRIBUTES()
                    {
                        Luid = new LUID(),
                        Attributes = enable ? PrivilegeState.Enabled : PrivilegeState.Removed
                    }
                };

                foreach (var prev in tokenPrivilegeTypes)
                {
                    uint result = 0;
                    TOKEN_PRIVILEGES previousState;


                    if (
                        // Get Privilege Info
                        LUID.fromString(prev, ref newState.First.Luid) &&
                        // Adjust Token Privilege
                        advapi32.AdjustTokenPrivileges(tHandle, false, ref newState, TOKEN_PRIVILEGES.Size, out previousState, out result) &&
                        // Ensure Adjust Success
                        previousState.PrivilegeCount > 0)
                    {
                        // if a privilege has been modified by this function, the privilege and its *** previous state *** are contained in the TOKEN_PRIVILEGES structure referenced by PreviousState.
                        // If the PrivilegeCount member of TOKEN_PRIVILEGES is zero, then no privileges have been changed by this function.
                        luidList.Add(prev, true);
                    }
                    else
                    {
                        luidList.Add(prev, false);
                    }
                }


            }

            // return result
            tHandle.Release();
            return luidList;
        }
    }
    public static class SecurityDescriptorHelper
    {
        public static void TakeOwnership(
            string location,
            ACCESS_MODE accessMode,
            ACCESS_MASK accessMask)
        {

            #region SID
            var lpDst = new StringBuilder(50);
            kernel32.ExpandEnvironmentStrings("%USERNAME%", lpDst, 50);

            var user = SafeSidHandle.AccountSid(Convert.ToString(lpDst));
            var users = SafeSidHandle.AccountSid("Users");
            var admin = SafeSidHandle.AccountSid("Administrators");
            var system = SafeSidHandle.AccountSid("System");
            #endregion

            #region ACL

            // we generate -new- entiries instead of 
            // modify the current entiries ...
            // [new instance ...]

            /* 
             * using AddAce
             */

            var ppDacl = SafeAclHandle.Default;
            ACE_HEADER_BASE userHeader, usersHeader, adminHeader, systemHeader;

            var flags =
                AceFlags.CONTAINER_INHERIT_ACE |
                AceFlags.OBJECT_INHERIT_ACE;
            var type = (accessMode == ACCESS_MODE.SET_ACCESS ||
                accessMode == ACCESS_MODE.GRANT_ACCESS) ?
                AceType.ACCESS_ALLOWED : AceType.ACCESS_DENIED;

            ppDacl.Generate(
                accessMask, type, flags,
                user, Guid.Empty, Guid.Empty,
                out userHeader);

            ppDacl.Generate(
                accessMask, type, flags,
                users, Guid.Empty, Guid.Empty,
                out usersHeader);

            ppDacl.Generate(
                accessMask, type, flags,
                admin, Guid.Empty, Guid.Empty,
                out adminHeader);

            ppDacl.Generate(
                accessMask, type, flags,
                system, Guid.Empty, Guid.Empty,
                out systemHeader);

            ppDacl.Initialize(
                userHeader.Size +
                usersHeader.Size +
                adminHeader.Size +
                systemHeader.Size);

            ppDacl.Add(
                userHeader,
                usersHeader,
                adminHeader,
                systemHeader);

            unsafe
            {
                // must free the memory ...
                // it was created from handle *(ptr)
                // so free the shit.

                kernel32.LocalFree((IntPtr)(&userHeader));
                kernel32.LocalFree((IntPtr)(&usersHeader));
                kernel32.LocalFree((IntPtr)(&adminHeader));
                kernel32.LocalFree((IntPtr)(&systemHeader));
            }

            /* 
             * using Add[???]Ace
             */

            //var ppAccess =
            //    (accessMode == ACCESS_MODE.SET_ACCESS ||
            //    accessMode == ACCESS_MODE.GRANT_ACCESS) ?
            //    AceType.ACCESS_ALLOWED : AceType.ACCESS_DENIED;
            //var ppDacl = new SafeAclHandle(0);
            //var pSize =
            //    ppDacl.Calculate(user, ppAccess, 1) +
            //    ppDacl.Calculate(users, ppAccess, 1) +
            //    ppDacl.Calculate(system, ppAccess, 1) +
            //    ppDacl.Calculate(admin, ppAccess, 1);

            //ppDacl.Initialize(pSize);
            //ppDacl.Add(ppAccess, 0, ACCESS_MASK.GenericAll, user, Guid.Empty, Guid.Empty);
            //ppDacl.Add(ppAccess, 0, ACCESS_MASK.GenericAll, users, Guid.Empty, Guid.Empty);
            //ppDacl.Add(ppAccess, 0, ACCESS_MASK.GenericAll, system, Guid.Empty, Guid.Empty);
            //ppDacl.Add(ppAccess, 0, ACCESS_MASK.GenericAll, admin, Guid.Empty, Guid.Empty);

            /* 
             * using SetEntriesInAcl
             */

            //var ppDacl = SafeAclHandle.Default;
            //EXPLICIT_ACCESS userAccess, usersAccess, adminAccess, systemAccess;

            //ppDacl.Generate(
            //    accessMask, accessMode, AceFlags.CONTAINER_INHERIT_ACE | AceFlags.OBJECT_INHERIT_ACE,
            //    TRUSTEE_FORM.TRUSTEE_IS_SID, TRUSTEE_TYPE.TRUSTEE_IS_GROUP, user.stdHandle,
            //    out userAccess);

            //ppDacl.Generate(
            //    accessMask, accessMode, AceFlags.CONTAINER_INHERIT_ACE | AceFlags.OBJECT_INHERIT_ACE,
            //    TRUSTEE_FORM.TRUSTEE_IS_SID, TRUSTEE_TYPE.TRUSTEE_IS_WELL_KNOWN_GROUP, users.stdHandle,
            //    out usersAccess);

            //ppDacl.Generate(
            //    accessMask, accessMode, AceFlags.CONTAINER_INHERIT_ACE | AceFlags.OBJECT_INHERIT_ACE,
            //    TRUSTEE_FORM.TRUSTEE_IS_SID, TRUSTEE_TYPE.TRUSTEE_IS_WELL_KNOWN_GROUP, admin.stdHandle,
            //    out adminAccess);

            //ppDacl.Generate(
            //    accessMask, accessMode, AceFlags.CONTAINER_INHERIT_ACE | AceFlags.OBJECT_INHERIT_ACE,
            //    TRUSTEE_FORM.TRUSTEE_IS_SID, TRUSTEE_TYPE.TRUSTEE_IS_WELL_KNOWN_GROUP, system.stdHandle,
            //    out systemAccess);

            // ppDacl.Add(userAccess, usersAccess, adminAccess, systemAccess);

            #endregion

            #region Update

            // take SE_TAKE_OWNERSHIP privilege

            var hProc = SafeProcessHandle.CurrentProcess;
            PrivilegesHelper.Take(hProc, true, PrivilegesHelper.Types.SE_TAKE_OWNERSHIP);

            // v1

            //var pSecurityDescriptor = SafeSecurityDescriptorHandle.Build(user, admin, ppDacl.ExplicitEntries);
            var pSecurityDescriptor = SafeSecurityDescriptorHandle.Default;
            pSecurityDescriptor.Initialize(user, admin, ppDacl);


            advapi32.SetFileSecurity(location, SECURITY_INFORMATION.OwnerSecurityInformation, pSecurityDescriptor);
            advapi32.SetFileSecurity(location, SECURITY_INFORMATION.GroupSecurityInformation, pSecurityDescriptor);
            advapi32.SetFileSecurity(location, SECURITY_INFORMATION.DaclSecurityInformation, pSecurityDescriptor);

            // v2
            //advapi32.SetSecurityInfo(
            //    location,
            //    SE_OBJECT_TYPE.SE_FILE_OBJECT,
            //    SECURITY_INFORMATION.OwnerSecurityInformation,
            //    user,
            //    SafeSidHandle.Default,
            //    SafeAclHandle.Default,
            //    SafeAclHandle.Default);

            //advapi32.SetSecurityInfo(
            //    location,
            //    SE_OBJECT_TYPE.SE_FILE_OBJECT,
            //    SECURITY_INFORMATION.GroupSecurityInformation,
            //    SafeSidHandle.Default,
            //    admin,
            //    SafeAclHandle.Default,
            //    SafeAclHandle.Default);

            //advapi32.SetSecurityInfo(
            //    location,
            //    SE_OBJECT_TYPE.SE_FILE_OBJECT,
            //    SECURITY_INFORMATION.DaclSecurityInformation,
            //    SafeSidHandle.Default,
            //    SafeSidHandle.Default,
            //    ppDacl,
            //    SafeAclHandle.Default);

            // free memory

            ppDacl.Free();
            hProc.Release();

            #endregion
        }
    }
    public static class ProcessHelper
    {
        public unsafe static uint[] EnumId()
        {
            var cCount = 100;
            var cSize = sizeof(uint);

            uint bytesCopied;
            var arraySizeBytes = Convert.ToUInt32(cSize * cCount);
            var pProcessIdsprocessIds = (uint*)msvcrt.malloc(arraySizeBytes);
            psapi.EnumProcesses(
                pProcessIdsprocessIds,
                arraySizeBytes,
                out bytesCopied);

            var processIdsprocessIds = new uint[bytesCopied / cSize];
            for (var i = 0; i < processIdsprocessIds.Length; i++)
                processIdsprocessIds[i] = pProcessIdsprocessIds[i];

            msvcrt.free((IntPtr)pProcessIdsprocessIds);
            return processIdsprocessIds;
        }
        public static PROCESSENTRY32[] EnumProcess()
        {
            var arr = new List<PROCESSENTRY32>();
            var entry = new PROCESSENTRY32() { dwSize = (uint)Marshal.SizeOf(typeof(PROCESSENTRY32)) };
            var hSnapshot = kernel32.CreateToolhelp32Snapshot(SnapshotFlags.Process, 0);
            if (kernel32.Process32First(hSnapshot, ref entry))
            {
                do
                {
                    arr.Add(entry);
                } while (kernel32.Process32Next(hSnapshot, ref entry));
            }
            return arr.ToArray();
        }
        public unsafe static SYSTEM_PROCESS_INFORMATION[] EnumProcessNative()
        {
            NtStatus status;
            uint returnLength;
            var infoClass = System_Information_Class.SystemProcessInformation;
            var processInformation = system_Information.CreateHandle(infoClass, out returnLength);

            status = ntdll.NtQuerySystemInformation(
                infoClass,
                (IntPtr)processInformation,
                returnLength,
                out returnLength);

            if (status == NtStatus.UNSUCCESSFUL ||
                status == NtStatus.NOT_IMPLEMENtED ||
                status == NtStatus.INVALID_INFO_CLASS)
            {
                system_Information.FreeHandle(processInformation);
                throw new System.ComponentModel.Win32Exception(
                    Marshal.GetLastWin32Error());
            }

            if (status == NtStatus.INFO_LENGTH_MISMATCH ||
                status == NtStatus.BUFFER_TOO_SMALL ||
                status == NtStatus.BUFFER_OVERFLOW)
            {
                do
                {
                    system_Information.FreeHandle(processInformation);
                    processInformation = system_Information.CreateHandle(returnLength);
                    status = ntdll.NtQuerySystemInformation(
                        infoClass,
                        (IntPtr)processInformation,
                        returnLength,
                        out returnLength);
                } while (
                    status == NtStatus.INFO_LENGTH_MISMATCH ||
                    status == NtStatus.BUFFER_TOO_SMALL ||
                    status == NtStatus.BUFFER_OVERFLOW);
            }

            if (status == NtStatus.SUCCESS)
            {
                var systemInformationArray = new List<SYSTEM_PROCESS_INFORMATION>();
                var systemInformation = &processInformation->SystemProcessInformation;

                while (true)
                {
                    systemInformationArray.Add(*systemInformation);

                    if ((int)systemInformation->NextEntryOffset > 0)
                    {
                        systemInformation = (SYSTEM_PROCESS_INFORMATION*)
                            ((uint)systemInformation + systemInformation->NextEntryOffset);
                        continue;
                    }

                    // no more data
                    break;
                }

                // return Result
                return systemInformationArray.ToArray();
            }

            // free the garbage
            system_Information.FreeHandle(processInformation);
            return null;
        }
        public unsafe static SYSTEM_HANDLE_TABLE_ENTRY_INFO[] EnumHandles(uint pId = 0)
        {
            // HOWTO Enumerate handles
            // http://forum.sysinternals.com/topic18892.html

            NtStatus status;
            uint returnLength;
            var arr = new List<SYSTEM_HANDLE_TABLE_ENTRY_INFO>();
            var infoClass = System_Information_Class.SystemHandleInformation;
            var processInformation = system_Information.CreateHandle(infoClass, out returnLength);

            status = ntdll.NtQuerySystemInformation(
                infoClass,
                (IntPtr)processInformation,
                returnLength,
                out returnLength);

            if (status == NtStatus.UNSUCCESSFUL)
            {
                system_Information.FreeHandle(processInformation);
                throw new System.ComponentModel.Win32Exception(
                    Marshal.GetLastWin32Error());
            }

            if (status == NtStatus.INFO_LENGTH_MISMATCH)
            {
                do
                {
                    system_Information.FreeHandle(processInformation);
                    processInformation = system_Information.CreateHandle(returnLength);
                    status = ntdll.NtQuerySystemInformation(
                        infoClass,
                        (IntPtr)processInformation,
                        returnLength,
                        out returnLength);
                } while (status == NtStatus.INFO_LENGTH_MISMATCH);
            }

            if (status == NtStatus.SUCCESS)
            {
                var info = &processInformation->SystemHandleInformation;
                var infoPtr = &info->first;

                for (var i = 0; i < info->HandleCount; i++)
                {
                    if (infoPtr[i].GrantedAccess == (ACCESS_MASK)0x0012019f)
                        continue;

                    if (pId == 0 ||
                        infoPtr[i].ProcessId == pId)
                    {
                        arr.Add(infoPtr[i]);
                    }
                }
            }

            // free the garbage
            //system_Information.FreeHandle(processInformation);

            return arr.ToArray();
        }
        public static THREADENTRY32[] EnumThreads(uint pId = 0)
        {
            var arr = new List<THREADENTRY32>();
            var entry = new THREADENTRY32() { dwSize = (uint)Marshal.SizeOf(typeof(THREADENTRY32)) };
            var hSnapshot = kernel32.CreateToolhelp32Snapshot(SnapshotFlags.Thread, pId);
            if (kernel32.Thread32First(hSnapshot, ref entry))
            {
                do
                {
                    arr.Add(entry);
                } while (kernel32.Thread32Next(hSnapshot, ref entry));
            }
            return arr.ToArray();
        }
        public static MODULEENTRY32[] EnumModules(uint pId = 0)
        {
            var arr = new List<MODULEENTRY32>();
            var entry = new MODULEENTRY32() { dwSize = (uint)Marshal.SizeOf(typeof(MODULEENTRY32)) };
            var hSnapshot = kernel32.CreateToolhelp32Snapshot(SnapshotFlags.Module, pId);
            if (kernel32.Module32First(hSnapshot, ref entry))
            {
                do
                {
                    arr.Add(entry);
                } while (kernel32.Module32Next(hSnapshot, ref entry));
            }
            return arr.ToArray();
        }
        public static HEAPLIST32[] EnumHeaps(uint pId = 0)
        {
            var arr = new List<HEAPLIST32>();
            var entry = new HEAPLIST32() { dwSize = (uint)Marshal.SizeOf(typeof(HEAPLIST32)) };
            var hSnapshot = kernel32.CreateToolhelp32Snapshot(SnapshotFlags.HeapList, pId);
            if (kernel32.Heap32ListFirst(hSnapshot, ref entry))
            {
                do
                {
                    arr.Add(entry);
                } while (kernel32.Heap32ListNext(hSnapshot, ref entry));
            }
            return arr.ToArray();
        }
    }
    #endregion

    #region Hotkey
    public sealed class Hotkey : NativeWindow, IDisposable
    {
        public class ModifiersEx
        {
            public Modifiers modifiers;
            public VirtualKey vKey;
        }
        public event Action<ModifiersEx, int> HotKeyPressed;
        private readonly Dictionary<int, ModifiersEx> HotKeyList = new Dictionary<int, ModifiersEx>();

        public Hotkey()
        {
            CreateHandle(
                new CreateParams());
        }
        public void Dispose()
        {
            RemoveHotKeys();
        }

        public void SetHotKey(Modifiers fsModifiers, VirtualKey vlc)
        {
            var sId = 0;
            var sRand = new Random();
            do
            {
                sId = sRand.Next(1000);
            } while (HotKeyList.ContainsKey(sId));

            HotKeyList.Add(sId, new ModifiersEx() { vKey = vlc, modifiers = fsModifiers });
            user32.RegisterHotKey(new SafeWindowHandle(this.Handle), sId, fsModifiers, vlc);
        }
        public void SetHotKey(int id, Modifiers fsModifiers, VirtualKey vlc)
        {
            HotKeyList.Add(id, new ModifiersEx() { vKey = vlc, modifiers = fsModifiers });
            user32.RegisterHotKey(new SafeWindowHandle(this.Handle), id, fsModifiers, vlc);
        }
        public void RemoveHotKeys()
        {
            foreach (var tKey in HotKeyList.Keys)
                user32.UnregisterHotKey(new SafeWindowHandle(this.Handle), tKey);
            HotKeyList.Clear();
        }
        public void RemoveHotKey(int id)
        {
            HotKeyList.Remove(id);
            user32.UnregisterHotKey(new SafeWindowHandle(this.Handle), id);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                /*
                 * wParam 
                 * The identifier of the hot key that generated the message.
                 * If the message was generated by a system-defined hot key,
                 * this parameter will be one of the following values.
                 * IDHOT_SNAPDESKTOP, -2, The "snap desktop" hot key was pressed.
                 * IDHOT_SNAPWINDOW, -1, The "snap window" hot key was pressed
                 * 
                 * lParam 
                 * The low-order word specifies the keys that were to be pressed in combination with the key
                 * specified by the high-order word to generate the WM_HOTKEY message. 
                 * This word can be one or more of the following values.
                 * The high-order word specifies the virtual key code of the hot key.
                 * 
                 */

                // WM_HOTKEY
                case 0x0312:
                    var id = (int)m.WParam;
                    var fsModifiers = HotKeyList[id]; ;

                    if (HotKeyPressed != null)
                        HotKeyPressed(fsModifiers, id);
                    break;
            }
            base.WndProc(ref m);
        }
    } 
    #endregion

    #region Clipboard
    public sealed class Clipboard : IDisposable
    {
        #region Clipboard
        public bool State { get; set; }
        public bool Set()
        {
            Release();
            if (!State)
            {
                State = user32.OpenClipboard(
                    new SafeWindowHandle(0));
            }
            return State;
        }
        public bool Set(SafeWindowHandle hwndNewOwner)
        {
            Release();
            if (!State) { State = user32.OpenClipboard(hwndNewOwner); }
            return State;
        }
        public bool Release()
        {
            if (State) { State = !user32.CloseClipboard(); }
            return State;
        }
        #endregion

        #region Global
        public bool Empty()
        {
            return user32.EmptyClipboard();
        }
        public bool Available(ClipboardFormat uFormat)
        {
            return user32.IsClipboardFormatAvailable(uFormat);
        }
        public IntPtr GetData(ClipboardFormat uFormat)
        {
            return user32.GetClipboardData(uFormat);
        }
        public bool SetData(ClipboardFormat uFormat, IntPtr hMem)
        {
            return user32.SetClipboardData(uFormat, hMem) != IntPtr.Zero;
        }
        #endregion

        #region CF_UNICODETEXT
        public bool ContainText
        {
            get { return Available(ClipboardFormat.CF_UNICODETEXT); }
        }
        public string GetText()
        {
            var stdHandle = GetData(ClipboardFormat.CF_UNICODETEXT);
            return stdHandle.ToUnicodeStr();
        }
        public bool SetText(string text)
        {
            var hMem = Marshal.StringToHGlobalUni(text);
            var dwRes = user32.SetClipboardData(ClipboardFormat.CF_UNICODETEXT, hMem) != IntPtr.Zero;
            hMem.Free();
            return dwRes;
        }
        #endregion

        #region CF_BITMAP
        public bool ContainImage
        {
            get { return Available(ClipboardFormat.CF_BITMAP); }
        }
        public Image GetImage()
        {
            var stdHandle = GetData(ClipboardFormat.CF_BITMAP);
            var hBitmap = new SafeBitmapHandle(stdHandle);
            return hBitmap.Image;
        }
        public bool SetImage(Image img)
        {
            // How do you put a Bitmap on the Clipboard using win32 API from a C# program?
            // http://social.msdn.microsoft.com/Forums/is/winforms/thread/816a35f6-9530-442b-9647-e856602cc0e2

            using (var gh = Graphics.FromImage(img))
            using (var bitmap = new Bitmap(img))
            {
                // SRC
                var hdcSrc = new SafeDCHandle(gh.GetHdc());
                hdcSrc.Select(bitmap.GetHbitmap());

                // TARGET
                var hwnd = new SafeWindowHandle(0).DeviceContext;
                var hdcDest = hwnd.CreateCompatibleDC();
                var hdcBitmap = hwnd.CreateCompatibleBitmap(img.Width, img.Height);
                hdcDest.Select(hdcBitmap.stdHandle);

                // Job
                gdi32.BitBlt(
                    hdcDest, 0, 0, bitmap.Width, bitmap.Height,
                    hdcSrc, 0, 0,
                    Enum.CopyPixelOperation.SourceCopy);
                var dwRes = user32.SetClipboardData(
                    ClipboardFormat.CF_BITMAP,
                    hdcBitmap.stdHandle) != IntPtr.Zero;

                // Clean
                hdcSrc.Release(
                    new SafeWindowHandle(
                        hdcSrc.stdHandle));
                return dwRes;
            }
        }
        #endregion

        #region CF_HDROP
        public bool ContainFileDropList
        {
            get { return Available(ClipboardFormat.CF_HDROP); }
        }
        public unsafe string[] GetFileDropList()
        {
            var stList = new List<string>();
            var builder = new StringBuilder();
            var hdrop = (char*)GetData(ClipboardFormat.CF_HDROP).Increase(18);
            while (true)
            {
                if (*hdrop == '\0')
                {
                    var str = builder.ToString();
                    if (!string.IsNullOrEmpty(str))
                        stList.Add(str);

                    hdrop += 1;
                    builder.Clear();
                }

                if (*hdrop == '\0')
                    break;

                // Grab
                builder.Append(*hdrop);
                hdrop += 1;
            }
            return stList.ToArray();
        }
        #endregion

        void IDisposable.Dispose()
        {
            Release();
        }
    }
    public sealed class ClipboardMonitor : NativeWindow
    {
        private readonly Clipboard cm;
        public event Action<object> OnGrab;

        public bool
            GrabImage,
            GrabText;
        public ClipboardFormat?
            GrabFormat;

        public ClipboardMonitor()
        {
            cm = new Clipboard();
            var cp = new CreateParams();
            CreateHandle(cp);
        }

        private void PrivateJob()
        {
            try
            {
                // check if CM is Set
                // and we have Grab....
                if (!cm.Set(new SafeWindowHandle(Handle)) ||
                    (GrabFormat == null &&
                    !GrabImage &&
                    !GrabText))
                {
                    DoEvents(null);
                }
                else if (GrabImage &&
                    cm.ContainImage)
                {
                    DoEvents(
                        cm.GetImage());
                }
                else if (GrabText &&
                    cm.ContainText)
                {
                    DoEvents(
                        cm.GetText());
                }
                else if (cm.Available(GrabFormat.Value))
                {
                    switch (GrabFormat.Value)
                    {
                        case ClipboardFormat.CF_DSPTEXT:
                        case ClipboardFormat.CF_OEMTEXT:
                        case ClipboardFormat.CF_TEXT:
                            DoEvents(
                                cm.GetData(GrabFormat.Value).ToAnsiStr());
                            break;

                        case ClipboardFormat.CF_UNICODETEXT:
                            DoEvents(
                                cm.GetData(GrabFormat.Value).ToUnicodeStr());
                            break;

                        case ClipboardFormat.CF_BITMAP:
                            DoEvents(
                                cm.GetImage());
                            break;

                        case ClipboardFormat.CF_HDROP:
                            DoEvents(
                                cm.GetFileDropList());
                            break;

                        default:
                            throw new Exception("Error :: format not Support");
                    }
                }
            }
            finally
            {
                cm.Release();
            }
        }
        public void DoEvents(object data)
        {
            if (OnGrab != null)
                OnGrab(data);
        }



        SafeWindowHandle hwndNextWindow;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (0x0001): // WM_CREATE
                    user32.AddClipboardFormatListener(this.Handle);
                    break;

                case (0x0002): // WM_DESTROY
                    user32.RemoveClipboardFormatListener(this.Handle);
                    break;

                case (0x031D): // WM_CLIPBOARDUPDATE
                    PrivateJob();
                    break;

                //case (0x0001): // WM_CREATE
                //    hWndNextWindow = user32.SetClipboardViewer(this.Handle);
                //    break;

                //case (0x0002): // WM_DESTROY
                //    user32.ChangeClipboardChain(this.Handle, hWndNextWindow);
                //    break;

                //case (0x030D): // WM_CHANGECBCHAIN
                //    if (hWndNextWindow == m.WParam)
                //        hWndNextWindow = m.LParam;
                //    else
                //        user32.SendMessage(hWndNextWindow, (WindowMessege)m.Msg, m.WParam, m.LParam);
                //    break;

                //case (0x0308): // WM_DRAWCLIPBOARD
                //    PrivateJob(); ;
                //    user32.SendMessage(hWndNextWindow, (WindowMessege)m.Msg, m.WParam, m.LParam);
                //    break;
            }

            base.WndProc(ref m);
        }
    }
    #endregion

    #region Hook
    // Hook Reference
    // http://blogs.msdn.com/b/toub/archive/2006/05/03/589468.aspx
    // http://blogs.msdn.com/b/toub/archive/2006/05/03/589423.aspx
    // http://msdn.microsoft.com/en-us/library/windows/desktop/ff468841(v=vs.85).aspx

    public abstract class HookBase
    {
        public bool LogToScreen = false;
        public bool ConsoleApplication = false;
        public bool Global = true;
        public Action<object[]> HookCallbackRecive;

        protected IntPtr hookID = IntPtr.Zero;
        protected LowLevelProc proc;

        public abstract void Start();
        protected void Start(HookType idHook)
        {
            if (ConsoleApplication)
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    hookID = SetHook(HookCallback, idHook);
                    if (hookID == IntPtr.Zero)
                        throw new Win32Exception(
                            Marshal.GetLastWin32Error());

                    Application.Run();
                }, null);
            }
            else
            {
                hookID = SetHook(HookCallback, idHook);
                if (hookID == IntPtr.Zero)
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }

        public void Stop()
        {
            user32.UnhookWindowsHookEx(hookID);

            if (ConsoleApplication)
                Application.Exit();
        }
        protected IntPtr SetHook(LowLevelProc lpfn, HookType idHook)
        {
            // GC Fix
            proc = lpfn;
            GC.KeepAlive(this);
            GC.KeepAlive(lpfn);
            GC.KeepAlive(proc);

            if (Global)
            {
                /* Managed Winapi Version -- Global -- [Requied No Debugger] */
                //return user32.SetWindowsHookEx(
                //    idHook,
                //    Marshal.GetFunctionPointerForDelegate(proc),
                //    Marshal.GetHINSTANCE(typeof(Hook).Assembly.GetModules()[0]),
                //    0);

                /* Stephen Toub Version -- Global */
                return user32.SetWindowsHookEx(
                    idHook,
                    Marshal.GetFunctionPointerForDelegate(proc),
                    kernel32.GetModuleHandle(
                        new System.IO.FileInfo(Assembly.GetExecutingAssembly().Location).Name),
                    0);
            }

            /*  Managed Winapi Version -- Private */
            return user32.SetWindowsHookEx(
                idHook,
                Marshal.GetFunctionPointerForDelegate(proc),
                IntPtr.Zero,
                kernel32.GetCurrentThreadId());
        }
        protected virtual IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            return user32.CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }
    public sealed class HookKeys : HookBase
    {
        public override void Start()
        {
            base.Start(HookType.WH_KEYBOARD_LL);
        }
        protected override IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var hookMessege = (WindowMessege)wParam;
                var hookStruct = lParam.ToStructure<KBDLLHOOKSTRUCT>();

                if (LogToScreen &&
                    hookStruct.flags != 0)
                {
                    var lastWindow = user32.GetForegroundWindow();
                    System.Console.WriteLine("Messege :: {0}", hookStruct);
                    System.Console.WriteLine("Window :: {0}", lastWindow.Text);
                }

                if (HookCallbackRecive != null &&
                    hookStruct.flags != 0)
                    HookCallbackRecive(new object[] { hookMessege, hookStruct });
            }

            return base.HookCallback(nCode, wParam, lParam);
        }
    }
    public sealed class HookMouse : HookBase
    {
        public override void Start()
        {
            base.Start(HookType.WH_MOUSE_LL);
        }
        protected override IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var hookMessege = (WindowMessege)wParam;
                var hookStruct = lParam.ToStructure<MSLLHOOKSTRUCT>();

                if (LogToScreen)
                    System.Console.WriteLine(
                        "Messege :: {0}, Position :: {1}",
                        hookMessege, hookStruct.pt);

                if (HookCallbackRecive != null)
                    HookCallbackRecive(new object[] { hookMessege, hookStruct });
            }
            return base.HookCallback(nCode, wParam, lParam);
        }
    }
    public sealed class HookWindow : HookBase
    {
        public HookWindow() { Global = false; }

        public override void Start()
        {
            base.Start(HookType.WH_CBT);
        }
        protected override IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                switch ((CbtHookAction)nCode)
                {
                    case CbtHookAction.HCBT_MOVESIZE:
                        {
                            var handle = new SafeWindowHandle(wParam);
                            var hookStruct = lParam.ToStructure<CBTACTIVATESTRUCT>();

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "{0} hase been Move",
                                    handle.stdHandle);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, handle, hookStruct });
                        }
                        break;

                    case CbtHookAction.HCBT_MINMAX:
                        {
                            var handle = new SafeWindowHandle(wParam);
                            var command = (ShowWindowCommand)(((int)lParam).Low());

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "{0} hase been {2}",
                                    handle.stdHandle,
                                    command);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, handle, command });
                        }
                        break;

                    case CbtHookAction.HCBT_CREATEWND:
                        {
                            var handle = new SafeWindowHandle(wParam);
                            var hookStruct = lParam.ToStructure<CBT_CREATEWND>();

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "{0} hase been Created",
                                    handle.stdHandle);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, handle, hookStruct });
                        }
                        break;

                    case CbtHookAction.HCBT_DESTROYWND:
                        {
                            var handle = new SafeWindowHandle(wParam);

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "{0} hase been Destroyd",
                                    handle.stdHandle);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, handle });
                        }
                        break;

                    case CbtHookAction.HCBT_ACTIVATE:
                        {
                            var handle = new SafeWindowHandle(wParam);
                            var hookStruct = lParam.ToStructure<CBTACTIVATESTRUCT>();

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "{0} hase been Activated",
                                    handle.stdHandle);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, handle, hookStruct });
                        }
                        break;

                    case CbtHookAction.HCBT_CLICKSKIPPED:
                        {
                            var handle = new SafeWindowHandle(wParam);
                            var hookStruct = lParam.ToStructure<MOUSEHOOKSTRUCT>();

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, handle, hookStruct });
                        }
                        break;

                    case CbtHookAction.HCBT_KEYSKIPPED:
                        {
                            var vkey = (VirtualKey)wParam;

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "vkey :: {0}", vkey);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, vkey });
                        }
                        break;

                    case CbtHookAction.HCBT_SYSCOMMAND:
                        {
                            var command = (SysCommands)wParam;

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "System Command :: {0}", command);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, command });
                        }
                        break;

                    case CbtHookAction.HCBT_SETFOCUS:
                        {
                            var wGet = new SafeWindowHandle(wParam);
                            var wLost = new SafeWindowHandle(lParam);

                            if (LogToScreen)
                                System.Console.WriteLine(
                                    "{0} has lost focus to {1}",
                                    wGet.stdHandle,
                                    wLost.stdHandle);

                            if (HookCallbackRecive != null)
                                HookCallbackRecive(new object[] { (CbtHookAction)nCode, wGet, wLost });
                        }
                        break;
                }
            }
            return base.HookCallback(nCode, wParam, lParam);
        }
    } 
    #endregion

    #region Network
    public sealed class Socket : IDisposable
    {
        public static string INADDR_ANY = "0.0.0.0";
        public static string INADDR_LOOPBACK = "127.0.0.1";
        public static string INADDR_BROADCAST = "255.255.255.255";
        public static string INADDR_NONE = "255.255.255.255";

        public static string IN6ADDR_ANY = "0:0:0:0:0:0:0:0";
        public static string IN6ADDR_LOOPBACK = "0:0:0:0:0:0:0:1";
        public static string IN6ADDR_NONE = "0:0:0:0:0:0:0:0";

        public Socket(SafeSocketHandle socket)
        {
            this.socketHandle = socket;
            this.needCleanUp = false;
            this.family = 0;

            // Initialize Socket
            Initialize();
        }
        public Socket(AddressFamilies family, SocketType type, SocketProtocolInt protocol)
        {
            var data = new WSAData() { highVersion = (short)(2) };
            ws2_32.WSAStartup(2, ref data);

            this.socketHandle = ws2_32.socket(family, type, protocol);
            this.needCleanUp = true;
            this.family = family;

            // Initialize Socket
            Initialize();
        }

        private unsafe void Initialize()
        {
            var optval = true;
            ws2_32.setsockopt(socketHandle, SocketOptionLevel.Socket, SocketOptionName.KeepAlive, (IntPtr)(&optval), sizeof(BOOL));

            this.Childeren = new List<Socket>();
            this.ReceiveTimeout = Timeout;
            this.SendTimeout = Timeout;
        }
        public void Dispose()
        {
            Close();
        }

        #region Security
        public SocketError SetSecurity(SocketSecurityProtocol protocol, SecurityFlags flags)
        {
            var securitySettings = new SOCKET_SECURITY_SETTINGS()
            {
                SecurityFlags = flags,
                SecurityProtocol = protocol
            };
            return fwpuclnt.WSASetSocketSecurity(
                this.socketHandle,
                ref securitySettings,
                (uint)Marshal.SizeOf(securitySettings),
                IntPtr.Zero,
                IntPtr.Zero);
        }
        public SocketError PeerTargetName(SocketSecurityProtocol protocol, string address)
        {
            var peerTargetName = new SOCKET_PEER_TARGET_NAME()
            {
                SecurityProtocol = protocol,
                PeerAddress = new SOCKADDR_STORAGE() { ss_family = AddressFamilies.INET },
                AllStrings = address,
                PeerTargetNameStringLen = (uint)address.Length * 2
            };

            return fwpuclnt.WSASetSocketPeerTargetName(
                this.socketHandle,
                ref peerTargetName,
                (uint)Marshal.SizeOf(peerTargetName),
                IntPtr.Zero,
                IntPtr.Zero);
        }

        #endregion

        #region Properties

        public AddressFamilies family { get; private set; }

        private readonly bool needCleanUp;
        private SafeSocketHandle socketHandle;
        private const int Timeout = 5000;


        [Obsolete("select alaways return true")]
        public bool CanReceive
        {
            get
            {
                var nullSocket = fd_set.Null;
                var realSocket = fd_set.Create(this.socketHandle);
                var interval = new timeval() { tv_sec = 3, tv_usec = 500 };
                var result = ws2_32.@select(0, ref realSocket, ref nullSocket, ref nullSocket, ref interval);
                return (result == realSocket.fd_count);
            }
        }
        [Obsolete("select alaways return true")]
        public bool CanSend
        {
            get
            {
                var nullSocket = fd_set.Null;
                var realSocket = fd_set.Create(this.socketHandle);
                var interval = new timeval() { tv_sec = 3, tv_usec = 500 };
                var result = ws2_32.@select(0, ref nullSocket, ref realSocket, ref nullSocket, ref interval);
                return (result == realSocket.fd_count);
            }
        }
        [Obsolete("select alaways return true")]
        public bool IsConnected
        {
            get
            {
                var nullSocket = fd_set.Null;
                var realSocket = fd_set.Create(this.socketHandle);
                var interval = new timeval() { tv_sec = 3, tv_usec = 500 };
                var result = ws2_32.@select(0, ref nullSocket, ref nullSocket, ref realSocket, ref interval);
                return (result == realSocket.fd_count);
            }
        }
        public string Host
        {
            get
            {
                {
                    var address = new sockaddr_in();
                    var size = Marshal.SizeOf(address);
                    var msg = ws2_32.getsockname(this.socketHandle, ref address, ref size);
                    if (msg == SocketError.Success)
                        return address.Host;
                }

                {
                    var address = new sockaddr_in6();
                    var size = Marshal.SizeOf(address);
                    var msg = ws2_32.getsockname(this.socketHandle, ref address, ref size);
                    if (msg == SocketError.Success)
                        return address.Host;
                }

                return null;
            }
        }
        public string Port
        {
            get
            {
                {
                    var address = new sockaddr_in();
                    var size = Marshal.SizeOf(address);
                    var msg = ws2_32.getsockname(this.socketHandle, ref address, ref size);
                    if (msg == SocketError.Success)
                        return address.Port;
                }

                {
                    var address = new sockaddr_in6();
                    var size = Marshal.SizeOf(address);
                    var msg = ws2_32.getsockname(this.socketHandle, ref address, ref size);
                    if (msg == SocketError.Success)
                        return address.Port;
                }

                return null;
            }
        }
        public bool IsValid
        {
            get { return socketHandle.stdHandle != IntPtr.Zero; }
        }
        public unsafe uint Available
        {
            get
            {
                uint BufferRet = 0;

                // v1
                //BufferRet = 0;
                //var BufferPtr = Marshal.AllocHGlobal(Marshal.SizeOf(BufferRet));
                //BufferRet = ws2_32.recv(socketPtr, BufferPtr, Buffer, MsgFlags.MSG_PEEK);
                //Marshal.FreeHGlobal(BufferPtr);

                // v2
                BufferRet = 0;
                ws2_32.ioctlsocket(this.socketHandle, Command.FIONREAD, ref BufferRet);

                // v3
                BufferRet = 0;
                uint nBytesReturned = 0;
                uint handle = 0;
                ws2_32.WSAIoctl(
                    this.socketHandle, ControlCode.FIONREAD,
                    IntPtr.Zero, 0,
                    (IntPtr)(&handle), sizeof(uint),
                    &nBytesReturned,
                    IntPtr.Zero, IntPtr.Zero);
                BufferRet = handle;

                return BufferRet;
            }
        }
        public unsafe int ReceiveTimeout
        {
            get
            {
                int optval, optlen = 4;
                ws2_32.getsockopt(socketHandle, SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (IntPtr)(&optval), &optlen);
                return optval;
            }
            set
            {
                var optval = value;
                ws2_32.setsockopt(socketHandle, SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (IntPtr)(&optval), sizeof(int));
            }
        }
        public unsafe int SendTimeout
        {
            get
            {
                int optval, optlen = 4;
                ws2_32.getsockopt(socketHandle, SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (IntPtr)(&optval), &optlen);
                return optval;
            }
            set
            {
                int optval = value;
                ws2_32.setsockopt(socketHandle, SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (IntPtr)(&optval), sizeof(int));
            }
        }
        public SafeSocketHandle Handle { get { return socketHandle; } }
        public List<Socket> Childeren { get; set; }
        #endregion

        #region Client
        public SocketError Connect(string host, ushort port)
        {
            if (family == 0x0)
                throw new Exception(
                    "this is incoming socket, plz kill yourSelf idiot ...!...");

            switch (family)
            {
                case AddressFamilies.INET:
                    {
                        // option [0]
                        var sockaddr = new sockaddr_in
                        {
                            //sin_family = ADDRESS_FAMILIES.INET,
                            //sin_port = ws2_32.htons(port),
                            //sin_addr = ws2_32.inet_addr(host)
                        };

                        // option [1]
                        //var sinAddr = new ws2_32.in_addr();
                        //ws2_32.inet_pton(ADDRESS_FAMILIES.INET, host, ref sinAddr);
                        //sockaddr.sin_addr = sinAddr;

                        // option [2]
                        var lpAddressLength = Marshal.SizeOf(sockaddr);
                        ws2_32.WSAStringToAddress(host + ":" + port, AddressFamilies.INET, IntPtr.Zero, ref sockaddr, ref lpAddressLength);

                        return ws2_32.connect(socketHandle, ref sockaddr, Marshal.SizeOf(sockaddr));
                    }
                    break;
                case AddressFamilies.INET6:
                    {
                        var sockaddr = new sockaddr_in6();

                        // option [0]
                        //var sin6Addr = new ws2_32.in6_addr();
                        //ws2_32.inet_pton(ADDRESS_FAMILIES.INET6, host, ref sin6Addr);
                        //sockaddr.sin6_addr = sin6Addr;
                        //sockaddr.sin6_port = ws2_32.htons(port);

                        // option [1]
                        var lpAddressLength = Marshal.SizeOf(sockaddr);
                        ws2_32.WSAStringToAddress("[" + host + "]" + ":" + port, AddressFamilies.INET6, IntPtr.Zero, ref sockaddr, ref lpAddressLength);

                        return ws2_32.connect(socketHandle, ref sockaddr, Marshal.SizeOf(sockaddr));
                    }
                    break;
                case AddressFamilies.IRDA:
                    //SOCKADDR_IRDA
                    break;
                case AddressFamilies.BTH:
                    // SOCKADDR_BTH
                    break;
            }

            // ^^
            return SocketError.SocketNotSupported;
        }
        public void ConnectEx(string host, ushort port, Action<object, SocketError> completeDelgate)
        {
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    completeDelgate(this, Connect(host, port));
                }, null);
        }
        #endregion

        #region Server

        // bind to
        // INADDR_???
        // IN6ADDR_???

        public SocketError Bind(string host, ushort port)
        {
            if (family == 0x0)
                throw new Exception(
                    "this is incoming socket, plz kill yourSelf idiot ...!...");

            switch (family)
            {
                case AddressFamilies.INET:
                    {
                        // option [0]
                        var sockaddr = new sockaddr_in
                        {
                            //sin_family = ADDRESS_FAMILIES.INET,
                            //sin_port = ws2_32.htons(port),
                            //sin_addr = ws2_32.inet_addr(host)
                        };

                        // option [1]
                        //var sinAddr = new ws2_32.in_addr();
                        //ws2_32.inet_pton(ADDRESS_FAMILIES.INET, host, ref sinAddr);
                        //sockaddr.sin_addr = sinAddr;

                        // option [2]
                        var lpAddressLength = Marshal.SizeOf(sockaddr);
                        ws2_32.WSAStringToAddress(host + ":" + port, AddressFamilies.INET, IntPtr.Zero, ref sockaddr, ref lpAddressLength);

                        return ws2_32.bind(socketHandle, ref sockaddr, Marshal.SizeOf(sockaddr));
                    }
                    break;
                case AddressFamilies.INET6:
                    {
                        var sockaddr = new sockaddr_in6();

                        // option [0]
                        //var sin6Addr = new ws2_32.in6_addr();
                        //ws2_32.inet_pton(ADDRESS_FAMILIES.INET6, host, ref sin6Addr);
                        //sockaddr.sin6_addr = sin6Addr;
                        //sockaddr.sin6_port = ws2_32.htons(port);

                        // option [1]
                        // option [1]
                        var lpAddressLength = Marshal.SizeOf(sockaddr);
                        ws2_32.WSAStringToAddress("[" + host + "]" + ":" + port, AddressFamilies.INET6, IntPtr.Zero, ref sockaddr, ref lpAddressLength);

                        return ws2_32.bind(socketHandle, ref sockaddr, Marshal.SizeOf(sockaddr));
                    }
                    break;
                case AddressFamilies.IRDA:
                    //SOCKADDR_IRDA
                    break;
                case AddressFamilies.BTH:
                    // SOCKADDR_BTH
                    break;
            }

            // ^^
            return SocketError.SocketNotSupported;
        }
        public void BindEx(Action<object, SocketError> completeDelgate, string host, ushort port)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       completeDelgate(this, Bind(host, port));
                   }, null);
        }

        public SocketError Listen(int backlog)
        {
            if (family == 0x0)
                throw new Exception(
                    "this is incoming socket, plz kill yourSelf idiot ...!...");

            return (SocketError)ws2_32.listen(socketHandle, backlog);
        }
        public void ListenEx(Action<object, SocketError> completeDelgate, int backlog)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       completeDelgate(this, Listen(backlog));
                   }, null);
        }

        public Socket Accept()
        {
            if (family == 0x0)
                throw new Exception(
                    "this is incoming socket, plz kill yourSelf idiot ...!...");

            var sock = new Socket(
                ws2_32.accept(socketHandle, IntPtr.Zero, 0));
            this.Childeren.Add(sock);
            return sock;
        }
        public void AcceptEx(Action<object, Socket> completeDelgate)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       completeDelgate(this, Accept());
                   }, null);
        }
        #endregion

        #region Send / Receive
        public int Send(byte[] someData)
        {
            var handle = GCHandle.Alloc(someData, GCHandleType.Pinned);
            var result = ws2_32.send(socketHandle, handle.AddrOfPinnedObject(), someData.Length + 1, MsgFlags.MSG_OOB);
            handle.Free();
            return result > 0 ? result - 1 : result;
        }
        public int Send(IntPtr someData, int length)
        {
            return ws2_32.send(socketHandle, someData, length, MsgFlags.MSG_OOB);
        }
        public void SendEx(byte[] someData, Action<object, int> completeDelgate)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       completeDelgate(this, Send(someData));
                   }, null);
        }
        public void SendEx(IntPtr someData, int length, Action<object, int> completeDelgate)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       completeDelgate(this, Send(someData, length));
                   }, null);
        }

        public int Receive(ref byte[] someData)
        {
            var handle = GCHandle.Alloc(someData, GCHandleType.Pinned);
            var rec = ws2_32.recv(socketHandle, handle.AddrOfPinnedObject(), someData.Length, MsgFlags.MSG_WAITALL);
            if (rec > 0)
            {
                someData = new byte[rec];
                Marshal.Copy(handle.AddrOfPinnedObject(), someData, 0, rec);
            }
            handle.Free();
            return rec;
        }
        public int Receive(IntPtr someData, int length)
        {
            return ws2_32.recv(socketHandle, someData, length, MsgFlags.MSG_WAITALL);
        }
        public void ReceiveEx(byte[] someData, Action<object, byte[], int> completeDelgate)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       var data = someData;
                       var res = Receive(ref data);
                       completeDelgate(this, data, res);
                   }, null);
        }
        public void ReceiveEx(IntPtr someData, int length, Action<object, IntPtr, int> completeDelgate)
        {
            ThreadPool.QueueUserWorkItem(
                   delegate
                   {
                       var data = someData;
                       var res = Receive(someData, length);
                       completeDelgate(this, data, res);
                   }, null);
        }
        #endregion

        #region Close
        public SocketError Close()
        {
            var err = socketHandle.Release();
            if (needCleanUp)
                ws2_32.WSACleanup();
            return err;
        }
        public SocketError ShutDown(ShutDownMode mode)
        {
            var err = SocketError.Success;
            switch (mode)
            {
                case ShutDownMode.Both:
                    err = (SocketError)ws2_32.shutdown(socketHandle, ShutDownFlags.SD_BOTH);
                    break;

                case ShutDownMode.Send:
                    err = (SocketError)ws2_32.shutdown(socketHandle, ShutDownFlags.SD_SEND);
                    break;

                case ShutDownMode.Receive:
                    err = (SocketError)ws2_32.shutdown(socketHandle, ShutDownFlags.SD_RECEIVE);
                    break;
            }
            return err;
        }
        #endregion
    }
    public unsafe sealed class Wifi : IDisposable
    {

        // Managed Wifi API
        // managedwifi.codeplex.com/

        // WLAN_profile Schema Elements
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms706965(v=vs.85).aspx

        // Wireless Profile Samples
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa369853(v=vs.85).aspx

        public delegate void onChange(ref WLAN_NOTIFICATION_DATA data);
        public event onChange OnChange; 
        IntPtr hClientHandle;

        public Wifi()
        {
            uint pdwNegotiatedVersion;

            wlanapi.WlanOpenHandle(
                0x1, IntPtr.Zero,
                out pdwNegotiatedVersion,
                out hClientHandle);

            uint pdwPrevNotifSource;
            wlanapi.WlanRegisterNotification(
                hClientHandle,
                WLAN_NOTIFICATION_SOURCE.ACM,
                true,
                FuncCallback,
                IntPtr.Zero,
                IntPtr.Zero,
                out pdwPrevNotifSource);
        }
        private void FuncCallback(WLAN_NOTIFICATION_DATA* data, IntPtr context)
        {
            if (OnChange == null)
                return;

            OnChange(ref *data);
        }
        public void Dispose()
        {
            wlanapi.WlanCloseHandle(
                hClientHandle,
                IntPtr.Zero);
        }

        #region Enum
        /// <summary>
        /// Enum Interface
        /// </summary>
        public WLAN_INTERFACE_INFO[] EnumInterfaces()
        {
            WLAN_INTERFACE_INFO_LIST* ppInterfaceList;
            wlanapi.WlanEnumInterfaces(hClientHandle, IntPtr.Zero, &ppInterfaceList);

            var arr = new WLAN_INTERFACE_INFO[ppInterfaceList->dwNumberOfItems];
            for (var i = 0; i < arr.Length; i++)
                arr[i] = (&ppInterfaceList->First)[i];
            return arr;
        }

        /// <summary>
        /// Enum Networks
        /// </summary>
        public WLAN_AVAILABLE_NETWORK[] EnumNetworks(
            WLAN_INTERFACE_INFO info)
        {
            WLAN_AVAILABLE_NETWORK_LIST* ppAvailableNetworkList;
            wlanapi.WlanGetAvailableNetworkList(
                hClientHandle, 
                ref info.InterfaceGuid,
                0x3, 
                IntPtr.Zero,
                &ppAvailableNetworkList);

            var arr = new WLAN_AVAILABLE_NETWORK[ppAvailableNetworkList->dwNumberOfItems];
            for (var i = 0; i < arr.Length; i++)
                arr[i] = (&ppAvailableNetworkList->First)[i];
            return arr;
        }

        /// <summary>
        /// Enum Profiles
        /// </summary>
        public string[] EnumProfiles(
            WLAN_INTERFACE_INFO info)
        {
            WLAN_PROFILE_INFO_LIST* ppProfileList;
            wlanapi.WlanGetProfileList(
                hClientHandle,
                ref info.InterfaceGuid,
                IntPtr.Zero,
                &ppProfileList);

            var arr = new string[ppProfileList->dwNumberOfItems];
            for (var i = 0; i < ppProfileList->dwNumberOfItems; i++)
                arr[i] = ((&ppProfileList->First)[i].ProfileName);
            return arr;
        }

        /// <summary>
        /// Enum BssEntiries
        /// </summary>
        public WLAN_BSS_ENTRY[] EnumBssEntiries(
            WLAN_INTERFACE_INFO info)
        {
            WLAN_BSS_LIST* ppWlanBssList;
            wlanapi.WlanGetNetworkBssList(
                hClientHandle,
                ref info.InterfaceGuid,
                (DOT11_SSID*)0,
                DOT11_BSS_TYPE.any,
                false, // ignored
                IntPtr.Zero,
                &ppWlanBssList);

            var arr = new WLAN_BSS_ENTRY[ppWlanBssList->dwNumberOfItems];
            for (var i = 0; i < ppWlanBssList->dwNumberOfItems; i++)
                arr[i] = ((&ppWlanBssList->First)[i]);
            return arr;
        }
        #endregion

        #region Xml
        /// <summary>
        /// Receive XML from Profile Information
        /// </summary>
        public string ReceiveXml(
            WLAN_INTERFACE_INFO interfaceInfo,
            string profile)
        {
            // Decrypt WEP wlan profile key using CryptUnprotectData
            // http://stackoverflow.com/questions/10765860/decrypt-wep-wlan-profile-key-using-cryptunprotectdata

            // Or use this Flag [better way]
            const uint WLAN_PROFILE_GET_PLAINTEXT_KEY = 0x004;


            uint pdwFlags = WLAN_PROFILE_GET_PLAINTEXT_KEY;
            uint pdwGrantedAccess = 0x0;
            string pstrProfileXml;

            wlanapi.WlanGetProfile(
                hClientHandle,
                ref interfaceInfo.InterfaceGuid,
                profile,
                IntPtr.Zero,
                out pstrProfileXml,
                ref pdwFlags,
                ref pdwGrantedAccess);

            return pstrProfileXml;
        }

        /// <summary>
        /// create XML based on network Information
        /// </summary>
        internal string ReceiveXml(
            WLAN_AVAILABLE_NETWORK network,
            object privateKey = null)
        {
            var key = privateKey;
            var name = network.dot11Ssid;
            var mac = network.dot11Ssid.Hex;

            var keyType = string.Empty;
            var encryption = string.Empty;
            var authentication = string.Empty;

            switch (network.AuthAlgorithm)
            {
                case DOT11_AUTH_ALGORITHM.DAA_80211_OPEN:
                    authentication = "open";
                    break;

                case DOT11_AUTH_ALGORITHM.DAA_80211_SHARED_KEY:
                    authentication = "shared";
                    break;

                case DOT11_AUTH_ALGORITHM.DAA_WPA:
                    authentication = "WPA";
                    break;

                case DOT11_AUTH_ALGORITHM.DAA_WPA_PSK:
                    authentication = "WPAPSK";
                    break;

                case DOT11_AUTH_ALGORITHM.DAA_RSNA:
                    authentication = "WPA2";
                    break;

                case DOT11_AUTH_ALGORITHM.DAA_RSNA_PSK:
                    authentication = "WPA2PSK";
                    break;

                case DOT11_AUTH_ALGORITHM.DAA_WPA_NONE:
                case DOT11_AUTH_ALGORITHM.DAA_IHV_START:
                case DOT11_AUTH_ALGORITHM.DAA_IHV_END:
                    throw new NotSupportedException();
            }

            switch (network.CipherAlgorithm)
            {
                case DOT11_CIPHER_ALGORITHM.NONE:
                    encryption = "none";
                    break;

                case DOT11_CIPHER_ALGORITHM.WEP:
                case DOT11_CIPHER_ALGORITHM.WEP40:
                case DOT11_CIPHER_ALGORITHM.WEP104:
                    encryption = "WEP";
                    keyType = "networkKey";
                    break;

                case DOT11_CIPHER_ALGORITHM.TKIP:
                    encryption = "TKIP";
                    keyType = "passPhrase";
                    break;

                case DOT11_CIPHER_ALGORITHM.CCMP:
                    encryption = "AES";
                    keyType = "passPhrase";
                    break;

                case DOT11_CIPHER_ALGORITHM.WPA_USE_GROUP:
                case DOT11_CIPHER_ALGORITHM.IHV_START:
                case DOT11_CIPHER_ALGORITHM.IHV_END:
                    throw new NotSupportedException();
            }

            string profile = null;

            if (encryption == "none")
            {
                profile = string.Format(
                    "<?xml version=\"1.0\"?>" +
                    "<WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\">" +
                    "<name>{0}</name>" +
                    "<SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig>" +
                    "<connectionType>ESS</connectionType>" +
                    "<MSM><security>" +
                    "<authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption>" +
                    "</security></MSM>" +
                    "</WLANProfile>",

                    name, mac,
                    authentication, encryption);
            }
            else
            {
                profile = string.Format(
                    "<?xml version=\"1.0\"?>" +
                    "<WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\">" +
                    "<name>{0}</name>" +
                    "<SSIDConfig><SSID><hex>{1}</hex><name>{0}</name></SSID></SSIDConfig>" +
                    "<connectionType>ESS</connectionType>" +
                    "<MSM><security>" +
                    "<authEncryption><authentication>{3}</authentication><encryption>{4}</encryption><useOneX>false</useOneX></authEncryption>" +
                    "<sharedKey><keyType>{5}</keyType><protected>false</protected><keyMaterial>{2}</keyMaterial></sharedKey>" +
                    "</security></MSM>" +
                    "</WLANProfile>",

                    name, mac, key,
                    authentication, encryption, keyType);
            }

            return profile;
        }
        #endregion

        #region Profile
        public bool SetProfile(
            WLAN_INTERFACE_INFO info,
            string xmlProfile)
        {
            uint pdwReasonCode;
            return wlanapi.WlanSetProfile(
                hClientHandle, ref info.InterfaceGuid,
                0x00, xmlProfile, null, true, IntPtr.Zero,
                out pdwReasonCode) == 0;
        }

        public bool DeleteProfile(
            WLAN_INTERFACE_INFO info,
            string profile)
        {
            return wlanapi.WlanDeleteProfile(
                hClientHandle,
                ref info.InterfaceGuid,
                profile,
                IntPtr.Zero) == 0;
        }

        public bool RenameProfile(
            WLAN_INTERFACE_INFO info,
            string oldProfileName,
            string newProfileName)
        {
            return wlanapi.WlanRenameProfile(
                hClientHandle, 
                ref info.InterfaceGuid,
                oldProfileName, 
                newProfileName,
                IntPtr.Zero) == 0;
        }

        public bool SetProfilePosition(
            WLAN_INTERFACE_INFO info,
            string profile,
            uint position)
        {
            return wlanapi.WlanSetProfilePosition(
                hClientHandle, 
                ref info.InterfaceGuid,
                profile, 
                position,
                IntPtr.Zero) == 0;
        }
        #endregion

        #region Network
        /// <summary>
        /// ReScan specific Interface networks
        /// </summary>
        public bool Scan(
            WLAN_INTERFACE_INFO interfaceInfo)
        {
            return wlanapi.WlanScan(
                hClientHandle,
                ref interfaceInfo.InterfaceGuid,
                (DOT11_SSID*)0,
                (WLAN_RAW_DATA*)0,
                IntPtr.Zero) == 0;
        } 
        #endregion

        #region Connection
        internal bool Connect(
            WLAN_INTERFACE_INFO info,
            WLAN_AVAILABLE_NETWORK network,

            // needed only to register network
            // in such modes .................
            // network profile not exist
            // registerMode == True
            // << BTW >>
            // if the network have Password
            // you should alaways pass it
            string privateKey = null,

            // usefull in case we want to register
            // network with diffrent key
            bool forceRegister = false)
        {
            // create Parameters Info
            var pConnectionParameters = new WLAN_CONNECTION_PARAMETERS
            {
                strProfile = network.ProfileName,
                dot11BssType = DOT11_BSS_TYPE.any,
                wlanConnectionMode = WLAN_CONNECTION_MODE.profile
            };

            switch (network.dot11DefaultAuthAlgorithm)
            {
                case DOT11_AUTH_ALGORITHM.DAA_WPA_PSK:
                case DOT11_AUTH_ALGORITHM.DAA_RSNA:
                case DOT11_AUTH_ALGORITHM.DAA_RSNA_PSK:
                    pConnectionParameters.dot11BssType = DOT11_BSS_TYPE.infrastructure;
                    break;
            }

            var profileXml = ReceiveXml(info, Convert.ToString(network));
            if (forceRegister || string.IsNullOrEmpty(profileXml))
                SetProfile(info, ReceiveXml(network, privateKey));

            return wlanapi.WlanConnect(hClientHandle, ref info.InterfaceGuid, ref pConnectionParameters, IntPtr.Zero) == 0;
        }

        public bool Connect(
            WLAN_INTERFACE_INFO info,
            string ssid,

            // needed only to register network
            // in such modes .................
            // network profile not exist
            // registerMode == True
            // << BTW >>
            // if the network have Password
            // you should alaways pass it
            string privateKey = null,

            // usefull in case we want to register
            // network with diffrent key
            bool forceRegister = false)
        {
            try
            {
                return Connect  (
                    info,
                    EnumNetworks(info).First(net => (Convert.ToString(net) == ssid)),
                    privateKey, forceRegister);
            }
            catch
            {
                throw new InstanceNotFoundException(
                    "Network not exist .");
            }
        }

        public bool Disconnect(
            WLAN_INTERFACE_INFO interfaceInfo)
        {
            return wlanapi.WlanDisconnect(
                hClientHandle,
                ref interfaceInfo.InterfaceGuid,
                IntPtr.Zero) == 0;
        }
        #endregion
    }
    #endregion

    #region File
    public sealed class Pe : IDisposable
    {
        #region Helpers

        public class FuncPtr
        {
            public string Key;
            public IntPtr Value;
        }

        public enum PeMode
        {
            Mapping,
            LoadLibrary,

            /// <summary>
            /// don't use it
            /// because somtimes we have to use ImageRvaToVa function
            /// and sometimes NOT [memory exception.]
            /// for example try read Exports or Imports from
            /// explorer.exe, ntdll.dll, user32.dll,
            /// and and uncomment 'case PeMode.LoadLibraryAsDataFile:'
            /// from FixOffset function and see diffrent result every time.
            /// </summary>
            LoadLibraryAsDataFile
        }

        IntPtr Alloc(Stream stream, int seek, int size)
        {
            var data = new byte[size];
            stream.Position = seek;
            stream.Read(data, 0, size);
            return GCHandle.Alloc(data, GCHandleType.Pinned).AddrOfPinnedObject();
        }
        IntPtr FixOffset(int address)
        {
            return FixOffset((uint)address);
        }
        unsafe IntPtr FixOffset(uint address)
        {
            var dwPtr = new IntPtr(0);
            switch (mode)
            {
                case PeMode.Mapping:
                    //case PeMode.LoadLibraryAsDataFile:

                    // this case will work 
                    // with LoadLibrary too.

                    if (NT.isX32)
                        dwPtr = dbghelp.ImageRvaToVa(
                            (IMAGE_NT_HEADERS_86*)IntPtr.Add(hView, DOS.e_lfanew),
                            hView, address, null);

                    if (NT.isX64)
                        dwPtr = dbghelp.ImageRvaToVaX64(
                            (IMAGE_NT_HEADERS_64*)IntPtr.Add(hView, DOS.e_lfanew),
                            hView, address, null);
                    break;

                case PeMode.LoadLibrary:
                    //case PeMode.LoadLibraryAsDataFile:

                    // this case will work 
                    // with Mapping too.

                    // but in some exe,dll,other
                    // [like --- winhlp32.exe]
                    // we receive dummy address
                    // [value < short.MaxValue]
                    // in such case we must convert it
                    // to relative virtual address
                    // using ImageRvaToVa.

                    dwPtr = IntPtr.Add(
                        hView, (int)address);

                    break;

                default:
                    throw new NotSupportedException(
                        "Unsupported MODE.");
            }

            return dwPtr;
        }

        #endregion

        #region Properties

        private PeMode mode;
        private IntPtr hHandle;
        private string location;
        private SafeFileHandle hFile;

        public SafeProcessHandle hProc { get; set; }
        public IntPtr hView { get; private set; }

        public IMAGE_DOS_HEADER DOS { get; private set; }
        public IMAGE_NT_HEADERS_86 NT { get; private set; }
        public IMAGE_NT_HEADERS_64 NT_64 { get; private set; }
        public Dictionary<string, IMAGE_SECTION_HEADER> Sections { get; private set; }

        /// <summary>
        /// get File Size
        /// </summary>
        public uint Size
        {
            get
            {
                var section = Sections.Last().Value;
                return section.PointerToRawData + section.SizeOfRawData;
            }
        }

        /// <summary>
        /// get EOF
        /// </summary>
        public byte[] Eof
        {
            get
            {
                var lastSection =
                    Sections.Values.Last();

                hFile.SetFilePointer(
                    EMoveMethod.Begin,
                    (int)(lastSection.PointerToRawData + lastSection.SizeOfRawData));

                byte[] lpBuffer;
                hFile.Read(
                    hFile.Size - (lastSection.PointerToRawData + lastSection.SizeOfRawData),
                    out lpBuffer);

                hFile.SetFilePointer(
                    EMoveMethod.Begin, 0);

                return lpBuffer;
            }
        }

        /// <summary>
        /// validate Image
        /// </summary>
        public bool Validate
        {
            get
            {
                return
                    DOS.isValid && 
                    NT.isValid;
            }
        }

        /// <summary>
        /// 32Bit Check
        /// </summary>
        public bool X32
        {
            get
            {
                return NT.isX32;
            }
        }

        /// <summary>
        /// 32Bit Check
        /// </summary>
        public bool X64
        {
            get
            {
                return NT.isX64;
            }
        }

        /// <summary>
        /// .Net Check
        /// </summary>
        public bool isDotNet
        {
            get
            {
                return CLR != null;
            }
        }

        /// <summary>
        /// get Exports
        /// </summary>
        public unsafe string[] Exports
        {
            get
            {
                var strArr = new List<string>();

                var exportPtr = (IMAGE_EXPORT_DIRECTORY*)FixOffset(
                    NT.isX32 ?
                        NT.OptionalHeader.ExportTable.VirtualAddress :
                        NT_64.OptionalHeader.ExportTable.VirtualAddress);

                if ((uint)exportPtr == 0)
                    return null;

                var names = (int*)FixOffset((int)exportPtr->AddressOfNames);
                var funcs = (int*)FixOffset((int)exportPtr->AddressOfFunctions);

                for (var i = 0; i < exportPtr->NumberOfNames; i++)
                {
                    var eName = FixOffset(names[i]);
                    var eAddress = FixOffset(funcs[i]);

                    // add ....
                    strArr.Add(eName.ToAnsiStr());
                }

                return strArr.ToArray();
            }
        }

        /// <summary>
        /// get Imports
        /// </summary>
        public unsafe Dictionary<string, string[]> Imports
        {
            get
            {
                var dic = new Dictionary<string, string[]>();

                var importPtr = (IMAGE_IMPORT_DESCRIPTOR*)FixOffset(
                    NT.isX32 ?
                        NT.OptionalHeader.ImportTable.VirtualAddress :
                        NT_64.OptionalHeader.ImportTable.VirtualAddress);

                if ((uint)importPtr == 0)
                    return null;

                for (var fdx = 0; fdx >= 0; fdx++)
                {
                    if (importPtr[fdx].dwUseless1 == 0 &&
                        importPtr[fdx].dwUseless2 == 0 &&
                        importPtr[fdx].FirstThunk == 0 &&
                        importPtr[fdx].OriginalFirstThunk == 0)
                        break;

                    // get Import Name
                    hHandle = FixOffset(importPtr[fdx].Name);
                    var name = hHandle.ToAnsiStr();

                    // get import function
                    var strArr = new List<string>();
                    var thunkArr = (IMAGE_THUNK_DATA*)FixOffset(
                        importPtr[fdx].OriginalFirstThunk);

                    if ((int)thunkArr == 0)
                        break;

                    for (var ndx = 0; ndx >= 0; ndx++)
                    {
                        // step 1 :: get IMAGE_THUNK_DATA
                        if (thunkArr[ndx].AddressOfData == 0 ||
                            (thunkArr[ndx].Ordinal & 0x80000000) > 0)
                            break;

                        // step 2 :: get IMAGE_IMPORT_BY_NAME
                        hHandle = FixOffset(thunkArr[ndx].AddressOfData) + 2;

                        // thunkArr[ndx].Function
                        strArr.Add(hHandle.ToAnsiStr());
                    }

                    // update dbs
                    dic.Add(name, strArr.ToArray());
                }

                return dic;
            }
        }

        /// <summary>
        /// get Clr
        /// </summary>
        public unsafe IMAGE_COR20_HEADER? CLR
        {
            get
            {
                if (NT.isX32 &&
                    NT.OptionalHeader.CLRRuntimeHeader.VirtualAddress > 0)
                {
                    hHandle = IntPtr.Add(hView, NT.OptionalHeader.CLRRuntimeHeader.VirtualAddress);
                    var clr = *(IMAGE_COR20_HEADER*)hHandle;
                    return clr;
                }

                if (NT.isX64 &&
                    NT_64.OptionalHeader.CLRRuntimeHeader.VirtualAddress > 0)
                {
                    hHandle = IntPtr.Add(hView, NT.OptionalHeader.CLRRuntimeHeader.VirtualAddress);
                    var clr = *(IMAGE_COR20_HEADER*)hHandle;
                    return clr;
                }
                return null;
            }
        }
        #endregion

        #region Ctor
        public unsafe Pe(
            string fileName,
            PeMode mode = PeMode.LoadLibrary)
        {
            location = fileName;
            hProc = SafeProcessHandle.CurrentProcess;
            hFile = kernel32.CreateFile(
                fileName, Enum.FileAccess.FileGenericRead, Enum.FileShare.Read, IntPtr.Zero,
                Enum.FileMode.Open, (Enum.FileAttributes)0, IntPtr.Zero);
            this.mode = mode;

            switch (mode)
            {
                case PeMode.Mapping:

                    // using File Mapping
                    //

                    uint lpFileSizeHigh;
                    uint lpFileSizeLow = kernel32.GetFileSize(
                        hFile, out lpFileSizeHigh);

                    var hFileMapping = kernel32.CreateFileMapping(
                        hFile, IntPtr.Zero,
                        FileMapProtection.PageReadonly,
                        lpFileSizeHigh, lpFileSizeLow, null);

                    hView = kernel32.MapViewOfFile(hFileMapping, FileMapAccess.FileMapRead, 0, 0, 0);
                    break;

                case PeMode.LoadLibrary:

                    // using LoadLibraryEx
                    //

                    hView = kernel32.LoadLibraryEx(
                        location, IntPtr.Zero,
                        LoadLibraryFlags.DONT_RESOLVE_DLL_REFERENCES |
                        LoadLibraryFlags.LOAD_IGNORE_CODE_AUTHZ_LEVEL);
                    break;

                case PeMode.LoadLibraryAsDataFile:

                    // using LoadLibraryEx ^ LOAD_LIBRARY_AS_DATAFILE
                    //

                    hView = kernel32.LoadLibraryEx(
                        location, IntPtr.Zero,
                        LoadLibraryFlags.DONT_RESOLVE_DLL_REFERENCES |
                        LoadLibraryFlags.LOAD_IGNORE_CODE_AUTHZ_LEVEL |
                        LoadLibraryFlags.LOAD_LIBRARY_AS_DATAFILE);
                    break;
            }

            if (hView == IntPtr.Zero)
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            /* --- IMAGE_DOS_HEADER --- */

            // fix some case in load libary as data file
            // happen in exploer.exe AND other exe files

            if (mode == PeMode.LoadLibraryAsDataFile &&
                !((IMAGE_DOS_HEADER*)(hView))->isValid &&
                ((IMAGE_DOS_HEADER*)(hView - 1))->isValid)
                hView -= 1;

            hHandle = hView;
            DOS = *(IMAGE_DOS_HEADER*)hHandle;
            if (DOS.isValid == false)
                throw new Exception("Bad PE File");

            /* --- IMAGE_NT_HEADERS --- */

            hHandle = IntPtr.Add(hView, DOS.e_lfanew);
            NT = *(IMAGE_NT_HEADERS_86*)hHandle;
            if (NT.isValid == false)
                throw new Exception("Bad PE File");

            if (NT.isX64)
                NT_64 = *(IMAGE_NT_HEADERS_64*)hHandle;

            /* --- IMAGE_SECTION_HEADER --- */

            var count = 0;
            var pHeader = (IMAGE_SECTION_HEADER*)0;
            Sections = new Dictionary<string, IMAGE_SECTION_HEADER>();

            switch (NT.OptionalHeader.Magic)
            {
                case MagicType.IMAGE_NT_OPTIONAL_HDR32_MAGIC:
                    count = NT.FileHeader.NumberOfSections;
                    pHeader = (IMAGE_SECTION_HEADER*)IntPtr.Add(hView, DOS.e_lfanew + sizeof(IMAGE_NT_HEADERS_86));
                    break;

                case MagicType.IMAGE_NT_OPTIONAL_HDR64_MAGIC:
                    count = NT_64.FileHeader.NumberOfSections;
                    pHeader = (IMAGE_SECTION_HEADER*)IntPtr.Add(hView, DOS.e_lfanew + sizeof(IMAGE_NT_HEADERS_64));
                    break;
            }

            for (var i = 0; i < count; i++)
                Sections.Add(pHeader[i].Name, pHeader[i]);
        }
        #endregion

        public void Dispose()
        {
            switch (mode)
            {
                case PeMode.Mapping:
                    //case PeMode.LoadLibraryAsDataFile:
                    kernel32.UnmapViewOfFile(hView);
                    break;

                case PeMode.LoadLibrary:
                    //case PeMode.LoadLibraryAsDataFile:
                    kernel32.FreeLibrary(hView);
                    break;
            }

            hFile.Release();
            hProc.Release();
        }
    }
    public sealed class Resource
    {
        private string pFileName { get; set; }
        private IntPtr hModule { get; set; }

        public Resource(string fileName)
        {
            pFileName = fileName;
            hModule = kernel32.LoadLibraryEx(
                pFileName, IntPtr.Zero,
                LoadLibraryFlags.LOAD_LIBRARY_AS_DATAFILE |
                LoadLibraryFlags.DONT_RESOLVE_DLL_REFERENCES);
        }

        public bool Set(Win32ResourceType type, string name, bool fixName, byte[] data)
        {
            IntPtr hUpdate;
            var pName = fixName ? string.Format("#{0}", name) : name;
            return (hUpdate = kernel32.BeginUpdateResource(pFileName, false)) != IntPtr.Zero &&
                   kernel32.UpdateResource(hUpdate, type, pName, (short)Macro.MAKELANGID(CultureInfo.CurrentCulture), data, (uint)data.Length) &&
                   kernel32.EndUpdateResource(hUpdate, false);
        }
        public bool Set(Win32ResourceType type, string name, bool fixName, IntPtr ptr, uint size)
        {
            IntPtr hUpdate;
            var pName = fixName ? string.Format("#{0}", name) : name;
            return (hUpdate = kernel32.BeginUpdateResource(pFileName, false)) != IntPtr.Zero &&
                   kernel32.UpdateResource(hUpdate, type, pName, (short)Macro.MAKELANGID(CultureInfo.CurrentCulture), ptr, size) &&
                   kernel32.EndUpdateResource(hUpdate, false);
        }

        public uint Load(Win32ResourceType type, string name, bool fixName, out IntPtr ptr)
        {
            var pName = fixName ? string.Format("#{0}", name) : name;
            var hRes = kernel32.FindResource(hModule, pName, type);
            var hGlobal = kernel32.LoadResource(hModule, hRes);
            var lpRes = kernel32.LockResource(hGlobal);
            var hSize = kernel32.SizeofResource(hModule, hRes);

            ptr = hRes;
            return hSize;
        }
        public uint Load<T>(Win32ResourceType type, string name, bool fixName, out T t) where T : struct
        {
            var pName = fixName ? string.Format("#{0}", name) : name;
            var hRes = kernel32.FindResource(hModule, pName, type);
            var hGlobal = kernel32.LoadResource(hModule, hRes);
            var lpRes = kernel32.LockResource(hGlobal);
            var hSize = kernel32.SizeofResource(hModule, hRes);

            t = lpRes.ToStructure<T>();
            return hSize;
        }

        public IEnumerable<Win32ResourceType> EnumTypes()
        {
            var types = new List<Win32ResourceType>();
            kernel32.EnumResourceTypes(
                hModule,
                delegate(IntPtr module, IntPtr type, IntPtr param)
                {
                    if ((int)type > 65535)
                    {
                        // type is pointer to String
                        // type.ToUnicodeStr();
                        return true;
                    }

                    Win32ResourceType result;
                    if (System.Enum.TryParse(Convert.ToString(type), out result)) { types.Add(result); }

                    return true;
                },
                IntPtr.Zero);
            return types;
        }
        public IEnumerable<string> EnumNames(Win32ResourceType type)
        {
            var names = new List<string>();
            kernel32.EnumResourceNames(
                hModule, type,
                delegate(IntPtr module, Win32ResourceType lpszType, IntPtr name, IntPtr param)
                {
                    names.Add((int)name > 65535 ? name.ToUnicodeStr() : Convert.ToString(name));
                    return true;
                },
                IntPtr.Zero);
            return names;
        }
        public IEnumerable<short> EnumLanguages(Win32ResourceType type, string name)
        {
            var languages = new List<short>();
            kernel32.EnumResourceLanguages(
                hModule, type, name,
                delegate(IntPtr module, Win32ResourceType lpszType, IntPtr lpszName, short language, IntPtr param)
                {
                    languages.Add(language);
                    return true;
                },
                IntPtr.Zero);
            return languages;
        }
    }
    #endregion

    #region Device
    public sealed class Volume
    {
        public Volume()
        {
            Rescan();
        }

        public void Rescan()
        {
            volumes = GetVolumeInfo();
        }

        public int Count
        {
            get { return volumes.Length; }
        }

        public VolumeInfo this[int index]
        {
            get { return volumes[index]; }
        }

        private VolumeInfo[] volumes;
        private static VolumeInfo[] GetVolumeInfo()
        {
            var arr = new List<VolumeInfo>();
            var res = new StringBuilder(256);
            var vol = kernel32.FindFirstVolume(res, 256 + 1);

            do
            {
                uint length;
                var letter = new StringBuilder(256);
                kernel32.GetVolumePathNamesForVolumeName(res.ToString(), letter, 256 + 1, out length);
                Debug.WriteLine("Letter :: {0}", letter);

                var type = kernel32.GetDriveType(res.ToString());
                Debug.WriteLine("Type :: {0}", type);

                var guid = res.ToString();
                var idx = guid.IndexOf('{');
                var edx = guid.IndexOf('}');
                var fixedGuid = guid.Substring(idx, edx - idx + 1);
                Debug.WriteLine("volume :: {0}", fixedGuid);

                var physical = Marshal.AllocHGlobal(256);
                var req = kernel32.QueryDosDevice(string.Format("Volume{0}", fixedGuid), physical, 256);
                Debug.WriteLine("Physical :: {0}", physical.ToAnsiStr(req));

                arr.Add(new VolumeInfo()
                {
                    Letter = Convert.ToString(letter),
                    Type = type,
                    Volume = guid,
                    Physical = physical.ToAnsiStr(req)
                });
                res = new StringBuilder(256);
            } while (kernel32.FindNextVolume(vol, res, 256 + 1));

            // return All volume
            return arr.ToArray();
        }    
    }
    public class VolumeInfo
    {
        public string Letter;
        public string Volume;
        public string Physical;
        public Enum.DriveType Type;

        // Editing Drive Letter Assignments
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa364014(v=vs.85).aspx

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RemoveLetter()
        {
            lock (this)
            {
                if (string.IsNullOrEmpty(Letter))
                    return;

                kernel32.DeleteVolumeMountPoint(Letter);

                //var fixedLetter = Letter.Substring(0, 2);
                //kernel32.DefineDosDevice(DDD_FLAGS.Removesymboliclink, fixedLetter, Physical);

                Letter = null;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddLetter(string letter)
        {
            lock (this)
            {
                if (letter.Length != 3 ||
                    !char.IsLetter(letter[0]) ||
                    letter[1] != ':' ||
                    letter[2] != '\\')
                    throw new Exception("Bad format .... !. ");

                kernel32.SetVolumeMountPoint(
                    letter, Volume);

                Letter = letter;
                //var fixedLetter = letter.Substring(0, 2);
                //kernel32.DefineDosDevice(
                //    DDD_FLAGS.RAW_TARGET_PATH,
                //    fixedLetter, Physical);
            }
        }
    }
    #endregion

    #region Monitor
    public sealed class Monitor
    {
        public bool MonitorEnabled;
        public enum MonitorType { File, Registry, Network, Device }
        public event Action<MonitorType, string[]> onReceive;

        /*
         * @"\\.\C:\
         * @"\\.\C:\Windows"
         */

        public void FilterShutDown()
        {
            // SetProcessShutdownParameters
            // too bad that its only work for current process

            throw new NotSupportedException();
        }

        public void FilterDevice()
        {
            kernel32.QueueUserWorkItem(FilterDeviceCallback, IntPtr.Zero, ExecuteFlags.ExecuteDefault);
        }
        public void FilterDevice(Control control)
        {
            kernel32.QueueUserWorkItem(FilterDeviceCallback, control.Handle, ExecuteFlags.ExecuteDefault);
        }
        private unsafe uint FilterDeviceCallback(IntPtr lpThreadParameter)
        {
            var size = (uint)sizeof(DEV_BROADCAST_DEVICEINTERFACE);
            var notificationFilter = (DEV_BROADCAST_DEVICEINTERFACE*)msvcrt.malloc(size);
            kernel32.ZeroMemory((IntPtr)notificationFilter, size);
            notificationFilter->devicetype = DBT_DEVTYP.DEVICEINTERFACE;
            notificationFilter->size = size;

            var hRecipient = new NativeHelper();
            hRecipient.MessgeHandler += MessgeHandler;

            // HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceClasses
            // a5dcbf10-6530-11d2-901f-00c04fb951ed :: USB Raw Device
            // 53f56307-b6bf-11d0-94f2-00a0c91efb8b :: Disk Device
            // ad498944-762f-11d0-8dcb-00c04fc3358c :: Network Card
            // 4d1e55b2-f16f-11cf-88cb-001111000030 :: Human Interface Device (HID)
            // 784126bf-4190-11d4-b5c2-00c04f687a67 :: Palm

            ptrArr = new List<IntPtr>();
            var hKey = RegistryHelper.OpenKey(SafeRegistryHandle.HKEY_LOCAL_MACHINE,
                                              @"SYSTEM\CurrentControlSet\Control\DeviceClasses");

            foreach (var key in RegistryHelper.EnumKeys(hKey))
            {
                notificationFilter->classguid = new Guid(key);
                ptrArr.Add(user32.RegisterDeviceNotification(
                    hRecipient.WindowHandle,
                    (DEV_BROADCAST_HDR*)notificationFilter,
                    DEVICE_NOTIFY.WINDOW_HANDLE));
            }

            hKey.Release();
            msvcrt.free((IntPtr)notificationFilter);

            // this is the only option to let me
            // handle the calls of this shit from diffrent
            // window handle .............................

            MSG lpMsg;
            user32.GetMessage(out lpMsg,
                              lpThreadParameter == IntPtr.Zero
                                  ? user32.GetConsoleWindow()
                                  : new SafeWindowHandle(lpThreadParameter)
                              , 0, 0);

            return 0;
        }

        // FilterDevice Helper function
        private List<IntPtr> ptrArr; 
        private unsafe bool MessgeHandler(Message message)
        {
            // WM_DEVICECHANGE message
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363480(v=vs.85).aspx

            if (!MonitorEnabled)
            {
                if (ptrArr != null)
                {
                    Array.ForEach(
                        ptrArr.ToArray(),
                        ptr => user32.UnregisterDeviceNotification(ptr));
                }

                ptrArr = null;
                return true;
            }

            if (message.Msg == 0x0219 /*DEVICECHANGE*/)
            {

                if (
                    // A device or piece of media has been inserted and is now available.
                    (uint)message.WParam == 0x8000 /*DBT_DEVICEARRIVAL*/ ||

                    // A device or piece of media has been removed.
                    (uint)message.WParam == 0x8004 /*DBT_DEVICEREMOVECOMPLETE*/)
                {
                    var hdr = ((DEV_BROADCAST_HDR*)message.LParam);
                    switch (hdr->devicetype)
                    {
                        case DBT_DEVTYP.OEM:
                            {
                                var deviceOem =
                                    (DEV_BROADCAST_OEM*)hdr;

                                if (onReceive != null)
                                    onReceive(MonitorType.Device,
                                    new[]
                                    {
                                        string.Format("Device was {0}",
                                            (uint)message.WParam == 0x8000
                                                ? "Insert" : "Remove")
                                    });
                            }
                            break;

                        case DBT_DEVTYP.PORT:
                            {
                                var devicePort =
                                    (DEV_BROADCAST_PORT*)hdr;

                                if (onReceive != null)
                                    onReceive(MonitorType.Device,
                                    new[]
                                    {
                                        string.Format("Device was {0}",
                                            (uint)message.WParam == 0x8000
                                            ? "Insert" : "Remove"),
                                        string.Format("Name :: {0}",
                                            devicePort->Name)
                                    });
                            }
                            break;

                        case DBT_DEVTYP.VOLUME:
                            {
                                var deviceVol =
                                    (DEV_BROADCAST_VOLUME*)hdr;

                                if (onReceive != null)
                                    onReceive(MonitorType.Device,
                                    new[]
                                    {
                                        string.Format("Device was {0}",
                                            (uint)message.WParam == 0x8000
                                            ? "Insert" : "Remove"),
                                        string.Format("Letter :: {0}",
                                            deviceVol->Letter)
                                    });
                            }
                            break;

                        case DBT_DEVTYP.DEVICEINTERFACE:
                            {
                                var deviceInterface =
                                    (DEV_BROADCAST_DEVICEINTERFACE*)hdr;

                                if (onReceive != null)
                                    onReceive(MonitorType.Device,
                                    new[]
                                    {
                                        string.Format("Device was {0}",
                                            (uint)message.WParam == 0x8000
                                            ? "Insert" : "Remove"),
                                        string.Format("Name :: {0}", 
                                            deviceInterface->Name),
                                        string.Format("Key :: {0}", 
                                            deviceInterface->RegistryKey)
                                    });
                            }
                            break;

                        case DBT_DEVTYP.HANDLE:
                            {
                                var deviceHandle =
                                    (DEV_BROADCAST_HANDLE*)hdr;

                                if (onReceive != null)
                                    onReceive(MonitorType.Device,
                                    new[]
                                    {
                                        string.Format("Device was {0}",
                                            (uint)message.WParam == 0x8000
                                            ? "Insert" : "Remove")
                                    });
                            }
                            break;
                    }
                }
            }
            return true;
        }

        public void FilterNetwork()
        {
            kernel32.QueueUserWorkItem(FilterNetworkCallback, IntPtr.Zero, ExecuteFlags.ExecuteDefault);
        }
        private uint FilterNetworkCallback(IntPtr lpThreadParameter)
        {
            //while (MonitorEnabled)
            //{
            //    uint dummy = 0;
            //    SocketError socketError;

            //    var hEventObject = kernel32.CreateEvent(
            //        IntPtr.Zero,
            //        false, false,
            //        null);

            //    var socket = new Socket(
            //        AddressFamilies.INET,
            //        SocketType.DGRAM,
            //        SocketProtocolInt.IP);

            //    // Enable non Blocking Mode
            //    uint argp = 1;
            //    ws2_32.WSAIoctl(
            //        socket.Handle, ControlCode.FIONBIO,
            //        (IntPtr)(&argp), sizeof(uint),
            //        IntPtr.Zero, 0,
            //        &dummy,
            //        IntPtr.Zero, IntPtr.Zero);

            //    // Enable notifies when there has been a change to the list of local transport addresses for a socket's address family
            //    ws2_32.WSAIoctl(
            //        socket.Handle, ControlCode.SIO_ADDRESS_LIST_CHANGE,
            //        IntPtr.Zero, 0,
            //        IntPtr.Zero, 0,
            //        &dummy,
            //        IntPtr.Zero, IntPtr.Zero);

            //    ws2_32.WSAEventSelect(
            //        socket.Handle,
            //        hEventObject,
            //        AsyncEventBits.FdAddressListChange);

            //    hEventObject.Wait(WaitForSingleObjectFlags.Infinite);

            //    if (onReceive != null)
            //    {
            //        ConnectionStates lpdwFlags;
            //        var isConnected = wininet.InternetGetConnectedState(out lpdwFlags, 0);
            //        onReceive(MonitorType.Network, isConnected);
            //    }

            //    hEventObject.Release();
            //    socket.Dispose();
            //}

            {
                while (MonitorEnabled)
                {
                    var dwRet = Iphlpapi.NotifyAddrChange(
                        IntPtr.Zero, IntPtr.Zero);
                    if (dwRet != 0)
                        continue;

                    if (onReceive != null)
                        onReceive(MonitorType.Network,
                        new[]
                        {
                            string.Format("Connected ? {0}",
                                wininet.InternetCheckConnection(
                                    "http://www.google.com", 0x1, 0x0))
                        });
                }
            }

            return 0;
        }

        public void FilterFolder(string location)
        {
            var hDirectory = kernel32.CreateFile(
                location,
                Enum.FileAccess.FileListDirectory,
                Enum.FileShare.All,
                IntPtr.Zero,
                Enum.FileMode.Open,
                FileFlag.BackupSemantics,
                IntPtr.Zero);

            kernel32.QueueUserWorkItem(
                FilterFolderCallback, hDirectory.stdHandle,
                ExecuteFlags.ExecuteDefault);
        }
        private uint FilterFolderCallback(IntPtr lpThreadParameter)
        {
            unsafe
            {
                uint lpBytesReturned;
                var hDirectory = new SafeFileHandle(lpThreadParameter);
                var lpFileName = Marshal.PtrToStringUni(lpThreadParameter);
                var lpBuffer = new FILE_NOTIFY_INFORMATION();

                while (MonitorEnabled &&
                    kernel32.ReadDirectoryChanges(
                    hDirectory,
                    ref lpBuffer,
                    (uint)sizeof(FILE_NOTIFY_INFORMATION),
                    true,
                    FILE_NOTIFY_CHANGE.All,
                    out lpBytesReturned, IntPtr.Zero, null))
                {

                    if (onReceive != null)
                        onReceive(MonitorType.File,
                            new []
                            {
                                string.Format("Name   :: {0}", 
                                    hDirectory.Name.EndsWith("\\") ? hDirectory.Name + lpBuffer.FileName : 
                                        hDirectory.Name + '\\' + lpBuffer.FileName),

                                string.Format("Action :: {0}", 
                                    lpBuffer.Action)
                            });
                }

                return 0;
            }
        }

        public void FilterRegistry(SafeRegistryHandle hKey)
        {
            kernel32.QueueUserWorkItem(
                FilterRegistryCallback, (IntPtr)((int)hKey.stdHandle),
                ExecuteFlags.ExecuteDefault);
        }
        public void FilterRegistry(string hive, string key, bool captureTree = false)
        {
            /*
                class RegistryKeyChangeEvent :  RegistryEvent
                {
                  string Hive;
                  string KeyPath;
                  uint8  SECURITY_DESCRIPTOR[];
                  uint64 TIME_CREATED;
                };
             */

            /*
                class RegistryTreeChangeEvent :  RegistryEvent
                {
                  string Hive;
                  string KeyPath;
                  uint8  SECURITY_DESCRIPTOR[];
                  uint64 TIME_CREATED;
                };
             */

            var query = new WqlEventQuery(
                string.Format(
                "SELECT * FROM {0} WHERE Hive = '{1}' AND KeyPath = '{2}'",
                captureTree ? "RegistryTreeChangeEvent" : "RegistryKeyChangeEvent", hive, key));

            var watcher = new ManagementEventWatcher(query);
            if (captureTree) watcher.EventArrived += RegistryTreeChangeEvent;
            else watcher.EventArrived += RegistryKeyChangeEvent;
            watcher.Start();
        }
        public void FilterRegistry(string hive, string key, string value)
        {
            /*
                class RegistryValueChangeEvent :  RegistryEvent
                {
                  string Hive;
                  string KeyPath;
                  uint8  SECURITY_DESCRIPTOR[];
                  uint64 TIME_CREATED;
                  string ValueName;
                };
             */

            var query = new WqlEventQuery(
                  string.Format(
                    "SELECT * FROM RegistryValueChangeEvent WHERE Hive = '{0}' AND KeyPath = '{1}' AND ValueName = '{2}'",
                    hive, key, value));

            var watcher = new ManagementEventWatcher(query);
            watcher.EventArrived += RegistryValueChangeEvent;
            watcher.Start();
        }

        private uint FilterRegistryCallback(IntPtr lpThreadParameter)
        {
            var hKey = new SafeRegistryHandle((uint)lpThreadParameter);
            while (MonitorEnabled &&
                advapi32.RegNotifyChangeKeyValue(hKey, true, RegNotifyFilter.All, new SafeEventHandle(0), false) == 0)
            {
                if (onReceive != null)
                    onReceive(MonitorType.Registry,
                        new[]
                            {
                                string.Format("{0}",
                                    "Registry :: value changed")
                            });
            }

            hKey.Release();
            return 0;
        }
        private void RegistryKeyChangeEvent(object sender, EventArrivedEventArgs eventArrivedEventArgs)
        {
            var watcher = sender as ManagementEventWatcher;
            if (!MonitorEnabled)
            {
                watcher.Stop();
                return;
            }

            if (onReceive != null)
                onReceive(MonitorType.Registry,
                    new[]
                        {
                            "Registry :: Key changed",
                            string.Format("Hive :: {0}", eventArrivedEventArgs.NewEvent["Hive"]),
                            string.Format("RootPath :: {0}", eventArrivedEventArgs.NewEvent["RootPath"])
                        });
        }
        private void RegistryTreeChangeEvent(object sender, EventArrivedEventArgs eventArrivedEventArgs)
        {
            var watcher = sender as ManagementEventWatcher;
            if (!MonitorEnabled)
            {
                watcher.Stop();
                return;
            }

            if (onReceive != null)
                onReceive(MonitorType.Registry,
                    new []
                        {
                            "Registry :: Tree changed",
                            string.Format("Hive :: {0}", eventArrivedEventArgs.NewEvent["Hive"]),
                            string.Format("RootPath :: {0}", eventArrivedEventArgs.NewEvent["RootPath"])
                        });
        }
        private void RegistryValueChangeEvent(object sender, EventArrivedEventArgs eventArrivedEventArgs)
        {
            var watcher = sender as ManagementEventWatcher;
            if (!MonitorEnabled)
            {
                watcher.Stop();
                return;
            }

            if (onReceive != null)
                onReceive(MonitorType.Registry,
                    new string[]
                        {
                            "Registry :: Value changed",
                            string.Format("Hive :: {0}", eventArrivedEventArgs.NewEvent["Hive"]),
                            string.Format("KeyPath :: {0}", eventArrivedEventArgs.NewEvent["KeyPath"]),
                            string.Format("ValueName :: {0}", eventArrivedEventArgs.NewEvent["ValueName"])
                        });
        }
    } 
    #endregion

    #region Hardware
    public class DeviceManager : IDisposable
    {
        #region Base

        public unsafe DeviceManager()
        {
            this.deviceInfoSet = setupapi.SetupDiGetClassDevs((Guid*)0, null, new SafeWindowHandle(0),
                DiGetClassFlags.PRESENT | DiGetClassFlags.PROFILE | DiGetClassFlags.ALLCLASSES);
        }
        public unsafe DeviceManager(Guid guid, bool specific = false)
        {
            if (specific)
            {
                this.deviceInfoSet = setupapi.SetupDiGetClassDevs(
                    &guid, null, new SafeWindowHandle(0),
                    DiGetClassFlags.PRESENT);
                return;
            }

            this.deviceInfoSet = setupapi.SetupDiGetClassDevs(
                &guid, null, new SafeWindowHandle(0),
                DiGetClassFlags.PRESENT | DiGetClassFlags.PROFILE | DiGetClassFlags.DEVICEINTERFACE);

        }

        void IDisposable.Dispose()
        {
            Free(deviceInfoSet);
        }
        public static void Free(IntPtr deviceInfoSet)
        {
            setupapi.SetupDiDestroyDeviceInfoList(deviceInfoSet);
        }

        #endregion

        #region Guid

        public static IEnumerable<Guid> EnumGuid()
        {
            var hKey = RegistryHelper.OpenKey(
                SafeRegistryHandle.HKEY_LOCAL_MACHINE,
                @"SYSTEM\CurrentControlSet\Control\DeviceClasses");

            return RegistryHelper.EnumKeys(hKey)
                .Select(key => new Guid(key));
        }

        #endregion

        #region Driver

        public unsafe SP_DRVINFO_EX GetDriverInfo(
            SP_DEVINFO_DATA deviceInfoData)
        {
            var spDrvinfoDataEx =
                new SP_DRVINFO_EX();

            using (var tmp = new DeviceManager(
                deviceInfoData.ClassGuid,
                true))
            {
                var newDeviceInfoData =
                    tmp.EnumDevices().First();

                if (!setupapi.SetupDiBuildDriverInfoList(
                    tmp.deviceInfoSet,
                    ref newDeviceInfoData,
                    0x2))
                {
                    setupapi.SetupDiDestroyDriverInfoList(
                        tmp.deviceInfoSet,
                        &newDeviceInfoData,
                        0x2);
                }

                spDrvinfoDataEx.InfoData =
                    new SP_DRVINFO_DATA { cbSize = Marshal.SizeOf(typeof(SP_DRVINFO_DATA)) };

                spDrvinfoDataEx.DetailData =
                        new SP_DRVINFO_DETAIL_DATA { cbSize = 797 };

                if (setupapi.SetupDiEnumDriverInfo(
                    tmp.deviceInfoSet,
                    &newDeviceInfoData,
                    0x2, 0x0,
                    ref spDrvinfoDataEx.InfoData))
                {
                    uint requiredSize = 0;
                    spDrvinfoDataEx.IsValid = true;

                    setupapi.SetupDiGetDriverInfoDetail(
                        tmp.deviceInfoSet,
                        &newDeviceInfoData,
                        ref spDrvinfoDataEx.InfoData,
                        ref spDrvinfoDataEx.DetailData,
                        (uint)Marshal.SizeOf(typeof(SP_DRVINFO_DETAIL_DATA)),
                        out requiredSize);
                }

                setupapi.SetupDiDestroyDriverInfoList(
                    tmp.deviceInfoSet,
                    &newDeviceInfoData,
                    0x2);
            }

            // return Result
            return spDrvinfoDataEx;
        }

        public unsafe bool InstallDriver(
            string infName,
            string hwid)
        {
            Guid classGuid;
            uint requiredSize;
            var className = new StringBuilder(256);
            if (!setupapi.SetupDiGetINFClass(
                infName, out classGuid, className, (uint)className.Capacity, out requiredSize))
            {
                return false;
            }

            var deviceInfoSet = setupapi.SetupDiCreateDeviceInfoList(
                &classGuid, new SafeWindowHandle(0));
            if ((int)deviceInfoSet <= 0)
            {
                return false;
            }

            var deviceInfoData =
                new SP_DEVINFO_DATA { cbSize = (uint)sizeof(SP_DEVINFO_DATA) };
            if (!setupapi.SetupDiCreateDeviceInfo(
                deviceInfoSet, Convert.ToString(className), ref classGuid,
                null, new SafeWindowHandle(0),
                0x00000001 /*DICD_GENERATE_ID*/, ref deviceInfoData))
            {
                return false;
            }

            var propertyBuffer =
                Encoding.ASCII.GetBytes(hwid);
            if (!setupapi.SetupDiSetDeviceRegistryProperty(
                deviceInfoSet, ref deviceInfoData, SPDRP.HARDWAREID, propertyBuffer, (uint)propertyBuffer.Length))
            {
                return false;
            }

            if (!setupapi.SetupDiCallClassInstaller(
                DIF.REGISTERDEVICE, deviceInfoSet, ref deviceInfoData))
            {
                return false;
            }

            setupapi.SetupDiDestroyDeviceInfoList(
                deviceInfoSet);


            bool bRebootRequired;
            newdev.UpdateDriverForPlugAndPlayDevices(
                new SafeWindowHandle(0),
                hwid, infName, 0x00000001 /* INSTALLFLAG_FORCE */, out bRebootRequired);

            return true;
        }

        #endregion

        #region Device

        public unsafe IEnumerable<SP_DEVINFO_DATA> EnumDevices()
        {
            uint memberIndex = 0;
            var arr = new List<SP_DEVINFO_DATA>();

            while (true)
            {
                var deviceInfoData = 
                    new SP_DEVINFO_DATA
                    {
                        cbSize = (uint)sizeof(SP_DEVINFO_DATA)
                    };

                if (!setupapi.SetupDiEnumDeviceInfo(
                    deviceInfoSet,
                    memberIndex++,
                    ref deviceInfoData))
                    break;

                arr.Add(deviceInfoData);
            }

            // return Result
            return arr;
        }

        public unsafe IEnumerable<SP_DEVICE_INTERFACE_DATA> EnumDeviceInterface(
            SP_DEVINFO_DATA deviceInfoData)
        {

            var deviceInterfaceData =
                new SP_DEVICE_INTERFACE_DATA
                {
                    cbSize = (uint)sizeof(SP_DEVICE_INTERFACE_DATA)
                };

            setupapi.SetupDiCreateDeviceInterface(
                deviceInfoSet,
                ref deviceInfoData,
                ref deviceInfoData.ClassGuid,
                null, 0x0,
                out deviceInterfaceData);

            // result ........
            return new[] { deviceInterfaceData };
        }

        public unsafe IEnumerable<SP_DEVICE_INTERFACE_DATA> EnumDeviceInterface(
            SP_DEVINFO_DATA deviceInfoData,
            Guid guid)
        {
            uint memberIndex = 0;
            var arr = new List<SP_DEVICE_INTERFACE_DATA>();

            var deviceInterfaceData =
                    new SP_DEVICE_INTERFACE_DATA { cbSize = (uint)sizeof(SP_DEVICE_INTERFACE_DATA) };

            while (true)
            {
                if (!setupapi.SetupDiEnumDeviceInterfaces(
                    deviceInfoSet,
                    &deviceInfoData,
                    ref guid,
                    memberIndex++,
                    ref deviceInterfaceData))
                    break;

                arr.Add(deviceInterfaceData);
            }

            // return Result
            return arr;
        }

        internal unsafe IEnumerable<SP_DEVICE_INTERFACE_DATA> EnumDeviceInterface(
            Guid guid)
        {
            uint memberIndex = 0;
            var arr = new List<SP_DEVICE_INTERFACE_DATA>();

            var deviceInterfaceData =
                    new SP_DEVICE_INTERFACE_DATA { cbSize = (uint)sizeof(SP_DEVICE_INTERFACE_DATA) };

            while (true)
            {
                if (!setupapi.SetupDiEnumDeviceInterfaces(
                    deviceInfoSet,
                    (SP_DEVINFO_DATA*)0,
                    ref guid,
                    memberIndex++,
                    ref deviceInterfaceData))
                    break;

                arr.Add(deviceInterfaceData);
            }

            // return Result
            return arr;
        }

        public unsafe SP_DEVICE_INTERFACE_DETAIL_DATA GetDeviceInterfaceDetails(
            SP_DEVINFO_DATA deviceInfoData,
            SP_DEVICE_INTERFACE_DATA deviceInterfaceData)
        {
            uint requiredSize;

            setupapi.SetupDiGetDeviceInterfaceDetail(
                deviceInfoSet, ref deviceInterfaceData,
                (SP_DEVICE_INTERFACE_DETAIL_DATA*)0, 0x0, out requiredSize,
                ref deviceInfoData);

            var deviceInterfaceDetailData =
                (SP_DEVICE_INTERFACE_DETAIL_DATA*)msvcrt.malloc(256 + sizeof(uint));
            MSDN.Api.kernel32.ZeroMemory((IntPtr)deviceInterfaceDetailData, 256 + sizeof(uint));
            deviceInterfaceDetailData->cbSize = 5;

            if (!setupapi.SetupDiGetDeviceInterfaceDetail(
                deviceInfoSet, ref deviceInterfaceData,
                deviceInterfaceDetailData, requiredSize, out requiredSize,
                ref deviceInfoData))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            // return Result
            return *deviceInterfaceDetailData;
        }

        public StringBuilder GetDeviceInstanceID(
            SP_DEVINFO_DATA deviceInfoData)
        {
            uint requiredSize;
            var deviceInstanceId =
                new StringBuilder(256);

            setupapi.SetupDiGetDeviceInstanceId(
                deviceInfoSet, ref deviceInfoData,
                deviceInstanceId, 256,
                out requiredSize);

            return deviceInstanceId;
        }

        public bool RemoveDevice(
            SP_DEVINFO_DATA deviceInfoData)
        {
            return setupapi.SetupDiRemoveDevice(
                deviceInfoSet,
                ref deviceInfoData);
        }

        public unsafe bool ControlDevice(
            SP_DEVINFO_DATA deviceInfoData,
            DICS dics)
        {
            var classInstallParams =
                new SP_PROPCHANGE_PARAMS
                {
                    ClassInstallHeader =
                        new SP_CLASSINSTALL_HEADER
                        {
                            cbSize = (uint)sizeof(SP_CLASSINSTALL_HEADER),
                            InstallFunction = DIF.PROPERTYCHANGE
                        },
                    HwProfile = 0x0,
                    Scope = DICS_FLAG.GLOBAL,
                    StateChange = dics
                };

            var setResult = setupapi.SetupDiSetClassInstallParams(
                deviceInfoSet,
                ref deviceInfoData,
                ref classInstallParams.ClassInstallHeader,
                (uint)sizeof(SP_PROPCHANGE_PARAMS));

            var installResult = setupapi.SetupDiCallClassInstaller(
                    DIF.PROPERTYCHANGE,
                    deviceInfoSet,
                    ref deviceInfoData);

            //if (!setResult || !installResult)
            //    throw new Win32Exception(
            //        Marshal.GetLastWin32Error());

            return setResult ||
                installResult;
        }

        #endregion

        #region Registry

        public byte[] GetDeviceProperty(
            SP_DEVINFO_DATA deviceInfoData,
            SPDRP property)
        {
            byte[]
                propertyBuffer = null;

            uint
                requiredSize,
                propertyRegDataType;

            setupapi.SetupDiGetDeviceRegistryProperty(
                deviceInfoSet,
                ref deviceInfoData,
                property,
                out propertyRegDataType,
                null, 0x0,
                out requiredSize);

            if (requiredSize == 0)
                return null;

            propertyBuffer = new byte[requiredSize];

            setupapi.SetupDiGetDeviceRegistryProperty(
                deviceInfoSet,
                ref deviceInfoData,
                property,
                out propertyRegDataType,
                propertyBuffer,
                requiredSize,
                out requiredSize);

            return propertyBuffer;
        }

        #endregion

        #region Setup Class

        public StringBuilder GetClassDescription(
            SP_DEVINFO_DATA deviceInfoData)
        {
            uint requiredSize;
            var classDescription =
                new StringBuilder(256);

            setupapi.SetupDiGetClassDescription(
                ref deviceInfoData.ClassGuid,
                classDescription, 256,
                out requiredSize);

            return classDescription;
        }

        #endregion

        #region  Members

        internal HDEVINFO deviceInfoSet;

        #endregion
    } 
    #endregion

    #region Helper
    public static class ImageHelper
    {
        public enum CaptureType
        {
            PrintScreen, 
            Screen,
            Api
        }

        #region Graphics
        // graphics from control
        public static Graphics GraphicsFromControl(Control ctrl)
        {
            return ctrl.CreateGraphics();
            //return GraphicsFromHwnd(
            //    new SafeWindowHandle(ctrl.Handle));
        }

        // graphics from handle
        public static Graphics GraphicsFromHwnd(SafeWindowHandle hWnd)
        {
            return Graphics.FromHwnd(hWnd.stdHandle);
            //return GraphicsFromhDC(hWnd.DeviceContext);
        }

        // graphics from DC
        public static Graphics GraphicsFromhDC(SafeDCHandle hDC)
        {
            return Graphics.FromHdc(hDC.stdHandle);
        }

        // graphics from image
        public static Graphics GraphicsFromImage(Image img)
        {
            return Graphics.FromImage(img);
        }
        #endregion

        #region Image
        // image from link
        public static Image ImageFromLink(string link)
        {
            Image img = null;
            using (var stream = new MemoryStream())
            using (var client = new WebClient())
            {
                try
                {
                    byte[] data = client.DownloadData(link);
                    stream.Write(data, 0, data.Length);
                    stream.Seek(0, System.IO.SeekOrigin.Begin);

                    stream.Flush();
                    img = ImageFromStream(stream);
                }
                catch { }
            }
            return img;
        }

        // image from stream
        public static Image ImageFromStream(Stream stream)
        {
            return Image.FromStream(stream);
        }

        // image from stream
        public static Image ImageFromFile(string location)
        {
            return Image.FromFile(location);
        }

        // new Image
        public static Image CreateImage(int Width, int Height)
        {
            return new Bitmap(Width, Height);
        }
        #endregion

        #region Capture
        // capture from control
        public static Image CaptureControl(Control ctrl)
        {
            return CaptureHandle(
                new SafeWindowHandle(ctrl.Handle));
        }

        // capture from point
        public static Image CaptureControl(int xI, int yI)
        {
            return CaptureHandle(
                user32.WindowFromPhysicalPoint(
                    new POINT() { X = xI, Y = yI }));
        }

        // capture from screen
        public static Image CaptureScreen(CaptureType type)
        {
            switch (type)
            {
                case CaptureType.PrintScreen:
                    unsafe
                    {
                        var pInputs = (INPUT*)msvcrt.malloc((uint)sizeof(INPUT) * 2);
                        pInputs[0] = new INPUT { type = InputType.InputKeyboard, ki = new KEYBDINPUT { wScan = ScanCodeShort.SNAPSHOT, wVk = VirtualKeyShort.SNAPSHOT, dwFlags = KEYEVENTF.KEYDOWN } };
                        pInputs[1] = new INPUT { type = InputType.InputKeyboard, ki = new KEYBDINPUT { wScan = ScanCodeShort.SNAPSHOT, wVk = VirtualKeyShort.SNAPSHOT, dwFlags = KEYEVENTF.KEYUP } };
                        user32.SendInput(2, pInputs, (uint)sizeof(INPUT));
                        msvcrt.free((IntPtr)pInputs);
                        kernel32.Sleep(100);
                    }

                    var cb = new Clipboard();
                    cb.Set();

                    try
                    {
                        return cb.GetImage();
                    }
                    finally
                    {
                        cb.Release();
                    }

                case CaptureType.Screen:
                    return CaptureArea(
                        new RECT(
                            0, 0,
                            user32.GetSystemMetrics(SystemMetric.SM_CXFULLSCREEN),
                            user32.GetSystemMetrics(SystemMetric.SM_CYFULLSCREEN)));

                case CaptureType.Api:
                    return CaptureHandle(user32.GetDesktopWindow(), true);
            }

            return null;
        }

        // capture from lase active window
        public static Image CaptureLastActiveWindow()
        {
            return CaptureHandle(
                user32.GetForegroundWindow());
        }

        // capture process main windows
        public static Image CaptureProcess(Process proc)
        {
            return CaptureHandle(
                new SafeWindowHandle(
                    proc.MainWindowHandle));
        }

        // capture Handle [of ...]
        public static Image CaptureHandle(
            SafeWindowHandle hWnd,
            bool hideBefore = false)
        {
            if (hideBefore)
            {
                user32.ShowWindowAsync(
                    new SafeWindowHandle(
                        Process.GetCurrentProcess().MainWindowHandle),
                    ShowWindowCommand.ForceMinimized);
                Thread.Sleep(250);
            }

            // SOurce
            var hdcSrc = hWnd.DeviceContext;

            // tArget
            var hdcDest = hdcSrc.CreateCompatibleDC();
            var hBitmap = hdcSrc.CreateCompatibleBitmap(hWnd.Rect.Width, hWnd.Rect.Height);
            var hgdiobj = hdcDest.Select(hBitmap.stdHandle);

            // result
            user32.PrintWindow(hWnd, hdcDest, PrintFlags.Default);
            var hRes = hBitmap.Image;

            // Clean all the Shit we make
            hBitmap.Delete();
            //hdcDest.Select(hgdiobj);
            hdcDest.Delete();
            hdcSrc.Release(hWnd);

            // reTurn reSult
            var result = hRes;

            if (hideBefore)
            {
                user32.ShowWindowAsync(
                    new SafeWindowHandle(
                        Process.GetCurrentProcess().MainWindowHandle),
                    ShowWindowCommand.Restore);
            }

            return result;
        }

        // capture Area
        public static Image CaptureArea(RECT rect)
        {
            // SOurce
            var hwnd = user32.GetDesktopWindow();
            //var hwnd = new SafeWindowHandle(0);
            var hdcSrc = hwnd.DeviceContext;

            // tArget
            var hdcDest = hdcSrc.CreateCompatibleDC();
            var hBitmap = hdcSrc.CreateCompatibleBitmap(rect.Width, rect.Height);
            var hgdiobj = hdcDest.Select(hBitmap.stdHandle);

            // result
            gdi32.BitBlt(
                hdcDest, 0, 0, rect.Width, rect.Height,
                hdcSrc, rect.X, rect.Y,
                Enum.CopyPixelOperation.SourceCopy);
            var hRes = hBitmap.Image;

            // Clean all the Shit we make
            hBitmap.Delete();
            //hdcDest.Select(hgdiobj);
            hdcDest.Delete();
            hdcSrc.Release(hwnd);

            // reTurn reSult
            return hRes;
        }
        #endregion

        #region Image <> Byte[]
        // image to byte
        public static byte[] ImageToByteArray(Image image)
        {
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);
            var byteArray = stream.ToArray();
            stream.Close();
            return byteArray;
        }

        // byte to image
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            var stream = new MemoryStream(byteArray);
            var returnImage = Image.FromStream(stream);
            stream.Close();
            return returnImage;
        }
        #endregion

        #region General
        // save to File
        public static void Save(Image img, string location, ImageFormat format)
        {
            // convert to other format	
            img.Save(location, format);
        }

        // save to Stream
        public static void Save(Image img, Stream stream, ImageFormat format)
        {
            // convert to other format	
            img.Save(stream, format);
        }

        // Print
        public static void Print(Image img)
        {
            // properties
            var diag = new PrintDialog();
            var doc = new PrintDocument();

            // print this img
            doc.PrintPage += (Sender, E) => E.Graphics.DrawImage(img, new Point(0, 0));
            diag.Document = doc;
            if (diag.ShowDialog() == DialogResult.OK)
                doc.Print();
        }
        #endregion
    }
    public static class IconHelper
    {
        public static Icon ExtractIcon(string execFileName)
        {
            SafeIconHandle[]
                phiconLarge = new SafeIconHandle[0],
                phiconSmall = new SafeIconHandle[0];
            var dwCount = shell32.ExtractIconEx(
                execFileName, -1, phiconLarge, phiconSmall, 0);

            if (dwCount <= 0)
                return null;

            phiconLarge = new SafeIconHandle[1];
            phiconSmall = new SafeIconHandle[1];

            shell32.ExtractIconEx(
                execFileName, 0, phiconLarge, phiconSmall, 1);

            user32.DestroyIcon(phiconLarge[0]);
            return phiconSmall[0].hIcon;
        }
        public static Icon[] ExtractIcons(string execFileName, bool smallIcon)
        {
            SafeIconHandle[]
                phiconLarge = new SafeIconHandle[0],
                phiconSmall = new SafeIconHandle[0];
            var dwCount = shell32.ExtractIconEx(
                execFileName, -1, phiconLarge, phiconSmall, 0);

            if (dwCount <= 0)
                return new Icon[0];

            var iconList = new Icon[dwCount];
            phiconLarge = new SafeIconHandle[dwCount];
            phiconSmall = new SafeIconHandle[dwCount];

            shell32.ExtractIconEx(
                execFileName, 0, phiconLarge, phiconSmall, dwCount);

            if (smallIcon)
            {
                for (var i = 0; i < dwCount; i++)
                    iconList[i] = phiconSmall[i].hIcon;
                for (var i = 0; i < dwCount; i++)
                    phiconLarge[i].Release();
            }
            else
            {
                for (int i = 0; i < dwCount; i++)
                    phiconSmall[i].Release();
                for (var i = 0; i < dwCount; i++)
                    iconList[i] = phiconLarge[i].hIcon;
            }

            return iconList;
        }
        public static void InjectIcon(string execFileName, string iconFileName)
        {
            InjectIcon(execFileName, iconFileName, 1, 1);
        }
        static void InjectIcon(string execFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
        {
            var iconFile = new IconFile();
            iconFile.Load(iconFileName);

            var hUpdate = kernel32.BeginUpdateResource(execFileName, false);
            Debug.Assert(hUpdate != IntPtr.Zero);

            var data = iconFile.CreateIconGroupData(iconBaseID);
            kernel32.UpdateResource(hUpdate, Win32ResourceType.RT_GROUP_ICON, iconGroupID.ToString(), 0, data, (uint)data.Length);

            for (int i = 0; i < iconFile.GetImageCount(); i++)
            {
                var image = iconFile.GetImageData(i);
                kernel32.UpdateResource(hUpdate, Win32ResourceType.RT_ICON, (iconBaseID + i).ToString(), 0, image, (uint)image.Length);
            }

            kernel32.EndUpdateResource(hUpdate, false);

        }
        class IconFile
        {
            ICONDIR _iconDir = new ICONDIR();
            ArrayList _iconEntry = new ArrayList();
            ArrayList _iconImage = new ArrayList();

            public int GetImageCount()
            {
                return _iconDir.idCount;
            }
            public byte[] GetImageData(int index)
            {
                Debug.Assert(0 <= index && index < GetImageCount());
                return (byte[])_iconImage[index];
            }
            public unsafe void Load(string fileName)
            {
                FileStream fs = null;
                BinaryReader br = null;
                byte[] buffer = null;

                try
                {

                    fs = new FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    br = new BinaryReader(fs);


                    buffer = br.ReadBytes(sizeof(ICONDIR));
                    fixed (ICONDIR* ptr = &_iconDir)
                    {
                        Marshal.Copy(buffer, 0, (IntPtr)ptr, sizeof(ICONDIR));
                    }

                    Debug.Assert(_iconDir.idReserved == 0);
                    Debug.Assert(_iconDir.idType == 1);
                    Debug.Assert(_iconDir.idCount > 0);

                    for (int i = 0; i < _iconDir.idCount; i++)
                    {
                        var entry = new ICONDIRENTRY();
                        buffer = br.ReadBytes(sizeof(ICONDIRENTRY));
                        var ptr = &entry;
                        {
                            Marshal.Copy(buffer, 0, (IntPtr)ptr, sizeof(ICONDIRENTRY));
                        }

                        _iconEntry.Add(entry);
                    }


                    for (int i = 0; i < _iconDir.idCount; i++)
                    {
                        fs.Position = ((ICONDIRENTRY)_iconEntry[i]).dwImageOffset;
                        var img = br.ReadBytes((int)((ICONDIRENTRY)_iconEntry[i]).dwBytesInRes);
                        _iconImage.Add(img);
                    }

                    var b = (byte[])_iconImage[0];

                }
                catch (Exception ex)
                {
                    Debug.Assert(false);
                }
                finally
                {
                    if (br != null)
                    {
                        br.Close();
                    }
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
            public unsafe byte[] CreateIconGroupData(uint nBaseID)
            {

                var data = new byte[SizeOfIconGroupData()];


                fixed (ICONDIR* ptr = &_iconDir)
                {
                    Marshal.Copy((IntPtr)ptr, data, 0, sizeof(ICONDIR));
                }

                int offset = sizeof(ICONDIR);

                for (int i = 0; i < GetImageCount(); i++)
                {
                    var grpEntry = new GRPICONDIRENTRY();
                    var bitmapheader = new BITMAPINFOHEADER();


                    BITMAPINFOHEADER* ptr = &bitmapheader;
                    {
                        Marshal.Copy(GetImageData(i), 0, (IntPtr)ptr, sizeof(BITMAPINFOHEADER));
                    }


                    grpEntry.bWidth = ((ICONDIRENTRY)_iconEntry[i]).bWidth;
                    grpEntry.bHeight = ((ICONDIRENTRY)_iconEntry[i]).bHeight;
                    grpEntry.bColorCount = ((ICONDIRENTRY)_iconEntry[i]).bColorCount;
                    grpEntry.bReserved = ((ICONDIRENTRY)_iconEntry[i]).bReserved;
                    grpEntry.wPlanes = bitmapheader.biPlanes;
                    grpEntry.wBitCount = bitmapheader.biBitCount;
                    grpEntry.dwBytesInRes = ((ICONDIRENTRY)_iconEntry[i]).dwBytesInRes;
                    grpEntry.nID = (ushort)(nBaseID + i);


                    GRPICONDIRENTRY* ptr2 = &grpEntry;
                    {
                        Marshal.Copy((IntPtr)ptr2, data, offset, Marshal.SizeOf(grpEntry));
                    }

                    offset += sizeof(GRPICONDIRENTRY);
                }

                return data;
            }
            unsafe int SizeOfIconGroupData()
            {
                return sizeof(ICONDIR) + sizeof(GRPICONDIRENTRY) * GetImageCount();
            }
        }
    }
    public static class RegistryHelper
    {
        // Struct

        public struct KeyVal
        {
            public string Key;
            public object Value;
        }
        public struct KeyValEx
        {
            public string Name;
            public string Value;
            public RegType Type;
        }

        // Key

        public static SafeRegistryHandle OpenKey(
            SafeRegistryHandle hKey,
            string lpSubKey)
        {
            SafeRegistryHandle phkResult;
            advapi32.RegOpenKeyEx(
                hKey, lpSubKey, 0, RegAccess.AllAccess, out phkResult);
            if (phkResult.stdHandle == UIntPtr.Zero)
            {
                advapi32.RegOpenKeyEx(
                    hKey, lpSubKey, 0,
                    RegAccess.Read | RegAccess.QueryValue | RegAccess.EnumerateSubKeys,
                    out phkResult);
                if (phkResult.stdHandle == UIntPtr.Zero)
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
            return phkResult;
        }

        public static SafeRegistryHandle CreateKey(
            SafeRegistryHandle hKey,
            string lpSubKey)
        {
            SafeRegistryHandle phkResult;
            RegDisposition lpdwDisposition;
            advapi32.RegCreateKeyEx(
                hKey, lpSubKey, 0, null, RegOptions.NonVolatile, RegAccess.AllAccess, IntPtr.Zero, out phkResult, out lpdwDisposition);
            return phkResult;
        }

        public static void DeleteKey(
            SafeRegistryHandle hKey,
            string lpSubKey)
        {
            advapi32.RegDeleteKeyEx(
                hKey, lpSubKey, RegAccess.AllAccess, 0);
        }

        public static void QueryInfoKey(
            SafeRegistryHandle hKey,
            out DWORD lpcSubKeys,
            out DWORD lpcValues)
        {
            uint lpcClass = 0;
            uint lpcMaxSubKeyLen;
            uint lpcMaxClassLen;
            uint lpcMaxValueNameLen;
            uint lpcMaxValueLen;
            uint lpcbSecurityDescriptor;
            Filetime lpftLastWriteTime;

            advapi32.RegQueryInfoKey(
                hKey, null, ref lpcClass, 0,
                out lpcSubKeys,
                out lpcMaxSubKeyLen,
                out lpcMaxClassLen,
                out lpcValues,
                out lpcMaxValueNameLen,
                out lpcMaxValueLen,
                out lpcbSecurityDescriptor,
                out lpftLastWriteTime);
        }

        // Value

        public static object GetValue(
            SafeRegistryHandle hKey,
            string lpValue)
        {
            DWORD pcbData = 0;
            RegType pdwType;
            var pvData = IntPtr.Zero;

            advapi32.RegGetValue(
                hKey, null, lpValue,
                RegFlags.Any,
                out  pdwType,
                pvData,
                ref pcbData);

            pvData = Marshal.AllocHGlobal((int)pcbData);
            var msg = (Win32Error)advapi32.RegGetValue(
                hKey, null, lpValue,
                RegFlags.Any,
                out  pdwType,
                pvData,
                ref pcbData);

            try
            {
                switch (pdwType)
                {
                    case RegType.RegSz:
                    case RegType.RegExpandSz:
                    case RegType.RegMultiSz:
                        if (msg == Win32Error.SUCCESS)
                            return pvData.ToUnicodeStr();
                        break;

                    case RegType.RegDword:
                        if (msg == Win32Error.SUCCESS)
                            return pvData.ReadInt32();
                        break;

                    case RegType.RegQword:
                        if (msg == Win32Error.SUCCESS)
                            return pvData.ReadInt64();
                        break;

                    case RegType.RegBinary:
                        if (msg == Win32Error.SUCCESS)
                        {
                            //unsafe
                            //{
                            //    var byteArr = new byte[lpcbData];
                            //    for (var i = 0; i < byteArr.Length; i++)
                            //        byteArr[i] = ((byte*)lpData)[i];
                            //}

                            var byteArr = new byte[pcbData];
                            Marshal.Copy(pvData, byteArr, 0, byteArr.Length);

                            // Object
                            return byteArr;
                        }
                        break;
                }
                return null;
            }
            finally
            {
                pvData.Free();
            }
        }

        public unsafe static KeyValEx[] QueryMultipleValues(
            SafeRegistryHandle hKey,
            params string[] values)
        {
            if (values.Length == 0)
                return null;

            var ldwTotsize = (uint)(0);
            var lpValueBuf = IntPtr.Zero;
            var valList = (VALENT*)Marshal.AllocHGlobal((int)VALENT.Size * values.Length);
            for (var i = 0; i < values.Length; i++) { valList[i].ve_valuename = Marshal.StringToHGlobalUni(values[i]); }

            // get Size
            advapi32.RegQueryMultipleValues(
                hKey, valList, (uint)values.Length, lpValueBuf, ref ldwTotsize);
            lpValueBuf = lpValueBuf.Reallocate(ldwTotsize);

            // get Data
            advapi32.RegQueryMultipleValues(
                hKey, valList, (uint)values.Length, lpValueBuf, ref ldwTotsize);

            var ValentArr = new KeyValEx[values.Length];
            for (var i = 0; i < ValentArr.Length; i++)
            {
                ValentArr[i].Name = valList[i].Name;
                ValentArr[i].Value = valList[i].Value;
                ValentArr[i].Type = valList[i].ve_type;
            }
            return ValentArr;
        }

        public static void SetValue(
            SafeRegistryHandle hKey,
            string lpValue,
            object lpData)
        {
            if (lpData is string)
                SetValue(hKey, lpValue, lpData, RegType.RegSz);

            if (lpData is Int32)
                SetValue(hKey, lpValue, lpData, RegType.RegDword);

            if (lpData is Int64)
                SetValue(hKey, lpValue, lpData, RegType.RegQword);

            if (lpData is byte[])
                SetValue(hKey, lpValue, lpData, RegType.RegBinary);
        }

        public unsafe static void SetValue(
            SafeRegistryHandle hKey,
            string lpValue,
            object lpData,
            RegType type)
        {
            switch (type)
            {
                case RegType.RegSz:
                case RegType.RegExpandSz:
                case RegType.RegMultiSz:
                    if (lpData is string)
                    {
                        var cbTmp = (string)lpData;
                        var cbData = Convert.ToUInt32(cbTmp.Length * 2);
                        var lpDataPtr = Marshal.StringToHGlobalUni(cbTmp);
                        advapi32.RegSetValueEx(
                            hKey, lpValue, 0, type, lpDataPtr, cbData);
                        lpDataPtr.Free();
                    }
                    break;

                case RegType.RegDword:
                    if (lpData is Int32)
                    {
                        var cbTmp = (Int32)lpData;
                        var cbData = Convert.ToUInt32(
                            Marshal.SizeOf(cbTmp));
                        var lpDataPtr = &cbTmp;
                        advapi32.RegSetValueEx(
                            hKey, lpValue, 0, type, (IntPtr)lpDataPtr, cbData);
                    }
                    break;

                case RegType.RegQword:
                    if (lpData is Int64)
                    {
                        var cbTmp = (Int64)lpData;
                        var cbData = Convert.ToUInt32(
                            Marshal.SizeOf(cbTmp));
                        var lpDataPtr = &cbTmp;
                        advapi32.RegSetValueEx(
                            hKey, lpValue, 0, type, (IntPtr)lpDataPtr, cbData);
                    }
                    break;

                case RegType.RegBinary:
                    if (lpData is byte[])
                    {
                        var cbTmp = (byte[])lpData;
                        var cbData = Convert.ToUInt32(
                            cbTmp.Length);
                        fixed (byte* lpDataPtr = &cbTmp[0])
                        {
                            advapi32.RegSetValueEx(
                                hKey, lpValue, 0, type, (IntPtr)lpDataPtr, cbData);
                        }

                    }
                    break;
            }
        }

        public static void DeleteValue(
            SafeRegistryHandle hKey,
            string lpValueName)
        {
            advapi32.RegDeleteValue(
                hKey, lpValueName);
        }

        // Enum

        public static IEnumerable<string> EnumKeys(
            SafeRegistryHandle hkey)
        {
            uint
                lpcSubKeys,
                lpcValues,
                dwIndex = 0;

            QueryInfoKey(
                hkey,
                out lpcSubKeys,
                out lpcValues);

            do
            {
                if (dwIndex >= lpcSubKeys)
                    break;

                var lpcName = (uint)256;
                var lpName = new StringBuilder(256);

                var lpcClass = (uint)256;
                var lpClass = new StringBuilder(256);

                Filetime lpftLastWriteTime;

                if (advapi32.RegEnumKeyEx(
                    hkey, dwIndex,
                    lpName, ref lpcName,
                    IntPtr.Zero,
                    lpClass, ref lpcClass,
                    out lpftLastWriteTime) != 0)
                    yield break;

                yield return lpName.ToString();

            } while (++dwIndex < int.MaxValue);
        }

        public static IEnumerable<KeyVal> EnumValues(
            SafeRegistryHandle hkey)
        {
            uint
                lpcSubKeys,
                lpcValues,
                dwIndex = 0;

            QueryInfoKey(
                hkey,
                out lpcSubKeys,
                out lpcValues);

            do
            {
                if (dwIndex >= lpcValues)
                    break;

                var lpcchValueName = (uint)256;
                var lpValueName = new StringBuilder(256);

                RegType lpType;
                var lpData = IntPtr.Zero;
                var lpcbData = (uint)0;

                advapi32.RegEnumValue(
                    hkey, dwIndex,
                    lpValueName, ref lpcchValueName,
                    IntPtr.Zero,
                    out lpType,
                    lpData, ref lpcbData);

                lpcchValueName = 256;
                lpValueName.EnsureCapacity(256);
                lpData = lpData.Reallocate(lpcbData);

                var msg = (Win32Error)advapi32.RegEnumValue(
                    hkey, dwIndex,
                    lpValueName, ref lpcchValueName,
                    IntPtr.Zero,
                    out lpType,
                    lpData, ref lpcbData);

                switch (lpType)
                {
                    case RegType.RegSz:
                    case RegType.RegExpandSz:
                    case RegType.RegMultiSz:
                        if (msg == Win32Error.SUCCESS)
                        {
                            yield return new KeyVal()
                            {
                                Key = lpValueName.ToString(),
                                Value = lpData.ToUnicodeStr()
                            };
                        }
                        break;

                    case RegType.RegDword:
                        if (msg == Win32Error.SUCCESS)
                        {
                            yield return new KeyVal()
                            {
                                Key = lpValueName.ToString(),
                                Value = lpData.ReadInt32()
                            };
                        }
                        break;

                    case RegType.RegQword:
                        if (msg == Win32Error.SUCCESS)
                        {
                            yield return new KeyVal()
                            {
                                Key = lpValueName.ToString(),
                                Value = lpData.ReadInt64()
                            };
                        }
                        break;

                    case RegType.RegBinary:
                        if (msg == Win32Error.SUCCESS)
                        {
                            //unsafe
                            //{
                            //    var byteArr = new byte[lpcbData];
                            //    for (var i = 0; i < byteArr.Length; i++)
                            //        byteArr[i] = ((byte*)lpData)[i];
                            //}

                            var byteArr = new byte[lpcbData];
                            Marshal.Copy(lpData, byteArr, 0, byteArr.Length);

                            yield return new KeyVal()
                            {
                                Key = lpValueName.ToString(),
                                Value = byteArr
                            };
                        }
                        break;

                    default:
                        yield return new KeyVal()
                        {
                            Key = lpValueName.ToString(),
                            Value = "Null"
                        };
                        break;
                }

                // free memory 
                lpData.Free();

            } while (++dwIndex < int.MaxValue);
        }
    }
    public static class ProxyHelper
    {
        public unsafe static string Get()
        {
            var lpdwBufferLength = INTERNET_PER_CONN_OPTION_LIST.Size;
            var list = new INTERNET_PER_CONN_OPTION_LIST(1);

            list[0] = INTERNET_PER_CONN_OPTION.Instance(
                IeSettingOptions.InternetPerConnProxyServer,
                IntPtr.Zero);

            if (!wininet.InternetQueryOption(
                IntPtr.Zero,
                InternetOption.PerConnectionOption,
                (IntPtr)(&list),
                &lpdwBufferLength))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            var proxy = list.options[0].pszValue.ToUnicodeStr();
            ((IntPtr)list.options).Free();
            return proxy;
        }
        public unsafe static void Set(string ip, string port)
        {
            var lpdwBufferLength = INTERNET_PER_CONN_OPTION_LIST.Size;
            var list = new INTERNET_PER_CONN_OPTION_LIST(2);

            list[0] = INTERNET_PER_CONN_OPTION.Instance(
                IeSettingOptions.InternetPerConnFlags,
                INTERNET_PER_CONN_OPTION.ProxyTypeProxy);

            list[1] = INTERNET_PER_CONN_OPTION.Instance(
                IeSettingOptions.InternetPerConnProxyServer,
                Marshal.StringToHGlobalUni(
                    string.Format("{0}:{1}", ip, port)));

            if (!wininet.InternetSetOption(
                IntPtr.Zero,
                InternetOption.PerConnectionOption,
                (IntPtr)(&list), lpdwBufferLength))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            ((IntPtr)list.options).Free();
            Refresh();
        }
        public unsafe static void Remove()
        {
            var lpdwBufferLength = INTERNET_PER_CONN_OPTION_LIST.Size;
            var list = new INTERNET_PER_CONN_OPTION_LIST(2);

            list[0] = INTERNET_PER_CONN_OPTION.Instance(
                IeSettingOptions.InternetPerConnFlags,
                INTERNET_PER_CONN_OPTION.ProxyTypeDirect);

            list[1] = INTERNET_PER_CONN_OPTION.Instance(
                IeSettingOptions.InternetPerConnProxyServer,
                IntPtr.Zero);

            if (!wininet.InternetSetOption(
                IntPtr.Zero,
                InternetOption.PerConnectionOption,
                (IntPtr)(&list), lpdwBufferLength))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            ((IntPtr)list.options).Free();
            Refresh();
        }
        public static void Refresh()
        {
            if (!wininet.InternetSetOption(
                IntPtr.Zero,
                InternetOption.Refresh,
                IntPtr.Zero, 0))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }
    }
    public static class MemoryHelper
    {
        public unsafe static void Replace(
            uint pId,
            object source,
            object target)
        {
            MEMORY_BASIC_INFORMATION info;
            var size = (uint)sizeof(MEMORY_BASIC_INFORMATION);

            var lpAddress = IntPtr.Zero;
            var hProcess = kernel32.OpenProcess(
                ProcessAccessFlags.All, false,
                ProcessHelper.EnumProcess().First(proc => proc.th32ProcessID == pId).th32ProcessID);

            #region get Object Bytes
            byte[] lookData = null;
            if (source is string)
            {
                lookData = Encoding.Unicode.GetBytes((string)source);
            }
            else if (source is byte)
            {
                lookData = new byte[1];
                lookData[0] = (byte)source;
            }
            else if (source is short)
            {
                lookData = BitConverter.GetBytes((short)source);
            }
            else if (source is int)
            {
                lookData = BitConverter.GetBytes((int)source);
            }
            else if (source is long)
            {
                lookData = BitConverter.GetBytes((long)source);
            }
            #endregion

            while (kernel32.VirtualQueryEx(hProcess, lpAddress, out info, size) > 0)
            {
                if (info.Valid)
                {
                    var data = info.Read(hProcess);
                    for (var i = 0; i < data.Length; i++)
                    {
                        var index = -1;
                        while (++index < lookData.Length)
                        {
                            try
                            {
                                #region Modify process Memory
                                if (data[i + index] == lookData[index])
                                {
                                    if (index == lookData.Length - 1)
                                    {
                                        uint done;
                                        if (target is string)
                                        {
                                            kernel32.WriteProcessMemory(
                                                hProcess, lpAddress + i,
                                                Marshal.StringToHGlobalUni((string)target),
                                                (uint)((target as string).Length * 2),
                                                out done);
                                            i += (index + (target as string).Length * 2);
                                        }
                                        else
                                        {
                                            byte[] replace = null;

                                            if (target is long)
                                                replace = BitConverter.GetBytes((long)target);
                                            else if (target is int)
                                                replace = BitConverter.GetBytes((int)target);
                                            else if (target is short)
                                                replace = BitConverter.GetBytes((short)target);
                                            else if (target is byte)
                                                replace = new byte[] { (byte)target };

                                            var gc = GCHandle.Alloc(replace, GCHandleType.Pinned);
                                            kernel32.WriteProcessMemory(hProcess, lpAddress + i, gc.AddrOfPinnedObject(), 1, out done);
                                            gc.Free();

                                            if (target is long)
                                                i += (index + 8);
                                            else if (target is int)
                                                i += (index + 4);
                                            else if (target is short)
                                                i += (index + 2);
                                            else if (target is byte)
                                                i += (index + 1);

                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    i += index;
                                    break;
                                }
                                #endregion
                            }
                            catch
                            {
                                i += index;
                                break;
                            }
                        }

                    }
                }

                if ((long)lpAddress > 0x7fffffff ||
                    info.Next == lpAddress)
                    break;
                lpAddress = info.Next;
            }
        }
    }
    public static class ObjectHelper
    {
        public static void Duplicate(
            uint processId,
            IntPtr hSourceHandle,
            out IntPtr lpTargetHandle,
            DUPLICATE duplicateOption = DUPLICATE.DUPLICATE_SAME_ACCESS)
        {
            var hSourceProcessHandle = kernel32.GetCurrentProcess();
            var hTargetProcessHandle = SafeProcessHandle.CurrentProcess;

            if (!kernel32.DuplicateHandle(
                hSourceProcessHandle, hSourceHandle,
                hTargetProcessHandle, out lpTargetHandle,
                ProcessAccessFlags.All, false,
                duplicateOption))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }

        public unsafe static bool Query(
            OBJECT_INFORMATION_CLASS objectInformationClass,
            IntPtr objectHandle,
            out OBJECT_INFORMATION* objectInformation)
        {
            uint resultLength;
            objectInformation = (OBJECT_INFORMATION*)0;
            ntdll.NtQueryObject(objectHandle, objectInformationClass, objectInformation, 0, out resultLength);
            objectInformation = (OBJECT_INFORMATION*)kernel32.LocalAlloc(LocalMemoryFlags.Fixed, resultLength);
            return ntdll.NtQueryObject(objectHandle, objectInformationClass, objectInformation, resultLength, out resultLength) == 0;
        }
    }
    public static class NetworkHelper
    {
        public unsafe static List<IP_STATUS> Ping(sockaddr_in destination)
        {
            // Create Handle [IcmpCreateFile]
            var icmpHandle = Iphlpapi.IcmpCreateFile();

            // Send Echo [IcmpSendEcho]
            var replyBuffer = (ICMP_ECHO_REPLY*)kernel32.LocalAlloc(
                LocalMemoryFlags.Fixed,
                (uint)sizeof(ICMP_ECHO_REPLY) * 5);
            var icmpCount = Iphlpapi.IcmpSendEcho(
                icmpHandle,
                destination.sin_addr,
                Marshal.StringToHGlobalUni("test"), 8,
                (IP_OPTION_INFORMATION*)0,
                replyBuffer, (uint)sizeof(ICMP_ECHO_REPLY) * 5,
                2500);

            // Read Echo
            var statusArr = new List<IP_STATUS>();
            for (var i = 0; i < icmpCount; i++)
            {
                var selected = replyBuffer[i];
                statusArr.Add(selected.Status);
            }

            // Close Handle [IcmpCloseHandle]
            kernel32.LocalFree((IntPtr)replyBuffer);
            Iphlpapi.IcmpCloseHandle(icmpHandle);
            return statusArr;
        }
        public unsafe static List<IP_STATUS> Ping(sockaddr_in6 source, sockaddr_in6 destination)
        {
            // Create Handle [IcmpCreateFile]
            var icmpHandle = Iphlpapi.Icmp6CreateFile();

            // Send Echo [IcmpSendEcho]
            var replyBuffer = (ICMPV6_ECHO_REPLY*)kernel32.LocalAlloc(
                LocalMemoryFlags.Fixed,
                (uint)sizeof(ICMP_ECHO_REPLY) * 5);
            var icmpCount = Iphlpapi.Icmp6SendEcho(
                icmpHandle,
                new SafeEventHandle(0),
                IntPtr.Zero,
                IntPtr.Zero,
                &source, &destination,
                Marshal.StringToHGlobalUni("test"), 8,
                (IP_OPTION_INFORMATION*)0,
                replyBuffer, (uint)sizeof(ICMPV6_ECHO_REPLY) * 5,
                2500);

            // Read Echo
            var statusArr = new List<IP_STATUS>();
            for (var i = 0; i < icmpCount; i++)
            {
                var selected = replyBuffer[i];
                statusArr.Add(selected.Status);
            }

            // Close Handle [IcmpCloseHandle]
            kernel32.LocalFree((IntPtr)replyBuffer);
            Iphlpapi.IcmpCloseHandle(icmpHandle);
            return statusArr;
        }
        public unsafe static List<string> DnsQuery(string uri)
        {
            PVOID pReserved;
            DNS_RECORD* ppQueryResultsSet;

            if (dnsapi.DnsQuery(
                uri,
                QueryTypes.All,
                QueryOptions.Standard,
                IntPtr.Zero,
                out ppQueryResultsSet,
                out pReserved) != Win32Error.SUCCESS)

                // close ...
                return null;

            var arr = new List<string>();
            var queryResultsSet = ppQueryResultsSet;

            do
            {
                arr.Add(ppQueryResultsSet->Name);
                ppQueryResultsSet = ppQueryResultsSet->pNext;
            } while ((int)ppQueryResultsSet != 0);

            dnsapi.DnsRecordListFree(queryResultsSet, DnsFreeType.RecordList);
            return arr;
        }
        public unsafe static sockaddr_in GetIp(string uri)
        {
            var data = new WSAData();
            ws2_32.WSAStartup(2, ref data);

            addrinfo* res;
            var hints = addrinfo.CreateHints();
            var ret = ws2_32.getaddrinfo(uri, null, ref hints, out res);

            ws2_32.WSACleanup();
            return ret == 0 ? res->SockaddrIn : default(sockaddr_in);
        }
        public static string GetHost(sockaddr_in sockaddrIn)
        {
            var data = new WSAData();
            ws2_32.WSAStartup(2, ref data);

            var reversedHost = new StringBuilder(256);
            var reversedPort = new StringBuilder(256);
            var ret = ws2_32.GetNameInfo(
                ref sockaddrIn, Marshal.SizeOf(sockaddrIn),
                reversedHost, (uint)reversedHost.Capacity,
                reversedPort, (uint)reversedPort.Capacity,
                NI.NI_NUMERICSCOPE);

            ws2_32.WSACleanup();
            return ret == 0 ? reversedHost.ToString() : null;
        }
    }
    public static class ConfigurationHelper
    {
        public unsafe static RECT GetWorkingArea()
        {
            var workingArea = new RECT();
            user32.SystemParametersInfo(
                ParameterAction.SPI_GETWORKAREA,
                (uint)sizeof(RECT),
                (IntPtr)(&workingArea), 0);
            return workingArea;
        }
        public static RECT GetClientArea()
        {
            var clientArea = new RECT(
            0, 0,
            user32.GetSystemMetrics(SystemMetric.SM_CXFULLSCREEN),
            user32.GetSystemMetrics(SystemMetric.SM_CYFULLSCREEN));
            return clientArea;
        }
    } 
    #endregion
}
