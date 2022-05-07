
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

namespace MSDN.Delegate
{
    /*
    * IntPtr hwnd,
    * Handle to the window that generates the event, 
    * or NULL if no window is associated with the event.
    */

    public delegate void WinEventProc(
        IntPtr hWinEventHook,
        AccessibleEventType eventType,
        IntPtr hwnd,
        uint idObject,
        uint idChild,
        uint dwEventThread,
        uint dwmsEventTime);

    public delegate uint WindowProc(
        SafeWindowHandle hwnd,
        WindowMessege uMsg,
        IntPtr wParam,
        IntPtr lParam);

    public delegate void TimerApcProc(
        LPVOID lpArgToCompletionRoutine,
        DWORD dwTimerLowValue,
        DWORD dwTimerHighValue);

    public delegate void WaitOrTimerCallback(
        PVOID lpParameter,
        BOOLEAN timerOrWaitFired);

    public delegate BOOL HandlerRoutine(
        CtrlType dwCtrlType);

    public delegate FARPROC LowLevelProc(
            int nCode, IntPtr wParam, IntPtr lParam);

    public delegate CopyProgressResult CopyProgressRoutine(
        long totalFileSize,
        long totalBytesTransferred,
        long streamSize,
        long streamBytesTransferred,
        uint dwStreamNumber,
        CopyProgressCallbackReason dwCallbackReason,
        IntPtr hSourceFile,
        IntPtr hDestinationFile,
        IntPtr lpData);

    public delegate void FileCompletionDelegate(
        UInt32 dwErrorCode,
        UInt32 dwNumberOfBytesTransfered,
        IntPtr lpOverlapped);

    public delegate bool WNDENUMPROC(
        SafeWindowHandle hwnd,
        IntPtr lParam);

    public delegate bool Enumreslangproc(
        HMODULE hModule,
        Win32ResourceType lpszType,
        IntPtr lpszName,
        WORD wIDLanguage,
        LONG_PTR lParam);

    public delegate bool Enumresnameproc(
        HMODULE hModule,
        Win32ResourceType lpszType,
        IntPtr lpszName,
        LONG_PTR lParam);

    public delegate bool Enumrestypeproc(
        HMODULE hModule,
        IntPtr lpszType,
        LONG_PTR lParam);

    public delegate bool PropEnumProc(
        SafeWindowHandle hwnd,
        IntPtr lpszString,
        HANDLE hData);

    public delegate bool PropEnumProcEx(
        SafeWindowHandle hwnd,
        IntPtr lpszString,
        HANDLE hData,
        ULONG_PTR dwData);

    public delegate DWORD ThreadProc(LPVOID lpParameter);
    public delegate DWORD LpthreadStartRoutine(LPVOID lpThreadParameter);

    public delegate void SimpleCallback(
        SafeThreadpoolCallbackInstance instance,
        PVOID context);
    public delegate void TimerCallback(
        SafeThreadpoolCallbackInstance instance,
        PVOID context,
        SafeThreadpoolTimer timer);
    public delegate void WorkCallback(
        SafeThreadpoolCallbackInstance instance, PVOID context,
        SafeThreadpoolWork work);
    public delegate void WaitCallback(
        SafeThreadpoolCallbackInstance instance,
        PVOID context,
        SafeThreadpoolWait wait,
        IntPtr waitResult);
    public delegate void IoCompletionCallback(
        SafeThreadpoolCallbackInstance instance,
        PVOID context,
        IntPtr overlapped,
        ULONG ioResult,
        ULONG_PTR numberOfBytesTransferred,
        SafeThreadpoolIo io);

    public delegate void CleanupGroupCancelCallback(
        PVOID objectContext,
        PVOID cleanupContext);

    public delegate void TimerProc(
        SafeWindowHandle hwnd,
        UINT uMsg,
        UIntPtr idEvent,
        DWORD dwTime);

    public delegate bool EnumDesktopProc(
        IntPtr lpszDesktop,
        IntPtr lParam);

    public delegate bool EnumWindowStationProc(
        IntPtr lpszWindowStation,
        IntPtr lParam);

    public delegate void ScNotifyCallback(
        PVOID pParameter);

    public delegate void FileIOCompletionRoutine(
        DWORD dwErrorCode,
        DWORD dwNumberOfBytesTransfered,
        IntPtr lpOverlapped);

    public unsafe delegate void IpforwardChangeCallback(
        IntPtr callerContext,
        MIB_IPFORWARD_ROW2* row,
        MIB_NOTIFICATION_TYPE notificationType);

    public unsafe delegate void InterfaceChangeCallback(
        IntPtr callerContext,
        MIB_IPINTERFACE_ROW* row,
        MIB_NOTIFICATION_TYPE notificationType);

    public unsafe delegate void UnicastIpaddressChangeCallback(
        IntPtr callerContext,
        MIB_UNICASTIPADDRESS_ROW* row,
        MIB_NOTIFICATION_TYPE notificationType);

    public unsafe delegate void WlanNotificationCallback(
        WLAN_NOTIFICATION_DATA* data,
        PVOID context);
}
