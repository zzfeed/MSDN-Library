#ifdef _MSC_VER
#pragma once
#endif

#ifndef NTUSER_H
#define NTUSER_H

// NtUserActivateKeyboardLayout activates a keyboard layout.
W32KAPI
HKL
NTAPI
NtUserActivateKeyboardLayout(
	IN HKL KeyboardLayout,
	IN ULONG Flags
	);

// NtUserAlterWindowStyle modifies a window's style.
W32KAPI
VOID
NTAPI
NtUserAlterWindowStyle(
	IN HWND Window,
	IN ULONG Mask,
	IN ULONG Flags
	);

// NtUserAssociateInputContext

// NtUserAttachThreadInput attaches or detaches the input queues of two threads.
W32KAPI
BOOL
NTAPI
NtUserAttachThreadInput(
	IN ULONG AttachThreadId,
	IN ULONG AttachToThreadId,
	IN BOOL Attach
	);

// NtUserBeginPaint begins a paint operation.
W32KAPI
HDC
NTAPI
NtUserBeginPaint(
	IN HWND Window,
	OUT PPAINTSTRUCT PaintInfo
	);

// NtUserBitBltSysBmp displays a system bitmap.
W32KAPI
BOOL
NTAPI
NtUserBitBltSysBmp(
	IN HDC DC,
	IN LONG XDest,
	IN LONG YDest,
	IN LONG CXDest,
	IN LONG CYDest,
	IN LONG XSrc,
	IN LONG YSrc,
	IN ULONG RasterOperation
	);

// NtUserBlockInput

// NtUserBuildHimcList

// NtUserBuildHwndList builds a list of window handles in the system.
W32KAPI
NTSTATUS
NTAPI
NtUserBuildHwndList(
	IN HDESK Desktop,
	IN HWND NextWindow,
	IN BOOL EnumChildren,
	IN ULONG ThreadId,
	IN LONG MaxWindows,
	OUT HWND *FirstWindow,
	OUT PULONG WindowListEntriesNeeded
	);

// NtUserBuildNameList builds a name list.
W32KAPI
NTSTATUS
NTAPI
NtUserBuildNameList(
	IN HWINSTA WindowStation,
	IN ULONG NameListSize,
	OUT PNAMELIST NameList,
	OUT PULONG NameListSizeNeeded
	);

// NtUserBuildPropList builds a window property list.
W32KAPI
NTSTATUS
NTAPI
NtUserBuildPropList(
	IN HWND Window,
	IN ULONG MaxProps,
	OUT PPROPSET PropSet, 
	OUT PULONG PropSetEntriesNeeded
	);

// NtUserCallHwnd makes a kernel mode support call on a window.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallHwnd(
	IN HWND Window,
	IN NTUSERCALL Function
	);

// NtUserCallHwndLock makes a kernel mode support call on a window, while holding the thread's Win32k lock.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallHwndLock(
	IN HWND Window,
	IN NTUSERCALL Function
	);

// NtUserCallHwndOpt makes a kernel mode support call on a window.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallHwndOpt(
	IN HWND Window,
	IN NTUSERCALL Function
	);

// NtUserCallHwndParam makes a kernel mode support call on a window.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallHwndParam(
	IN HWND Window,
	IN ULONG_PTR Parameter,
	IN NTUSERCALL Function
	);

// NtUserCallHwndParamLock makes a kernel mode support call on a window, while holding the thread's Win32k lock.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallHwndParamLock(
	IN HWND Window,
	IN ULONG_PTR Parameter,
	IN NTUSERCALL Function
	);

// NtUserCallMsgFilter calls a message filter hook.
W32KAPI
BOOL
NTAPI
NtUserCallMsgFilter(
	IN OUT PMSG Msg,
	IN LONG Code
	);

// NtUserCallNextHookEx calls the next hook in the hook chain.
W32KAPI
LRESULT
NTAPI
NtUserCallNextHookEx(
	IN LONG Code,
	IN WPARAM WParam,
	IN LPARAM LParam,
	IN BOOL Ansi
	);

// NtUserCallNoParam makes a kernel mode support call.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallNoParam(
	IN NTUSERCALL Function
	);

// NtUserCallOneParam makes a kernel mode support call.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallOneParam(
	IN ULONG_PTR Parameter,
	IN NTUSERCALL Function
	);

// NtUserCallTwoParam makes a kernel mode support call.
W32KAPI
ULONG_PTR
NTAPI
NtUserCallTwoParam(
	IN ULONG_PTR Parameter1,
	IN ULONG_PTR Parameter2,
	IN NTUSERCALL Function
	);

// NtUserChangeClipboardChain removes a window from the clipboard viewer chain.
W32KAPI
BOOL
NTAPI
NtUserChangeClipboardChain(
	IN HWND WindowToRemove,
	IN HWND WindowToSetAsNext
	);

// NtUserChangeDisplaySettings modifies the system display settings.
W32KAPI
LONG
NTAPI
NtUserChangeDisplaySettings(
	IN PUNICODE_STRING DeviceName,
	IN PDEVMODEW DeviceMode,
	IN HWND Window OPTIONAL,
	IN ULONG Flags,
	IN PVOID VideoParameters OPTIONAL
	);

// NtUserCheckImeHotKey

// NtUserCheckMenuItem sets the checked state of a menuitem.
W32KAPI
ULONG
NTAPI
NtUserCheckMenuItem(
	IN HMENU Menu,
	IN ULONG IDCheckItem,
	IN ULONG CheckFlags
	);

// NtUserChildWindowFromPointEx locates a child window given a client area coordinate.
W32KAPI
HWND
NTAPI
NtUserChildWindowFromPointEx(
	IN HWND ParentWindow,
	IN POINT Point,
	IN ULONG Flags
	);

// NtUserClipCursor clips a cursor to a specific area of the screen.
W32KAPI
BOOL
NTAPI
NtUserClipCursor(
	IN CONST PRECT ClipRect OPTIONAL
	);

// NtUserCloseClipboard closes a reference to the clipboard.
W32KAPI
BOOL
NTAPI
NtUserCloseClipboard(
	VOID
	);

// NtUserCloseDesktop closes a handle to a desktop.
W32KAPI
BOOL
NTAPI
NtUserCloseDesktop(
	IN HDESK DesktopHandle
	);

// NtUserCloseWindowStation closes a handle to a window station.
W32KAPI
BOOL
NTAPI
NtUserCloseWindowStation(
	IN HWINSTA WindowStationHandle
	);

// NtUserConsoleControl performs a control operation on the console.
W32KAPI
NTSTATUS
NTAPI
NtUserConsoleControl(
	IN CONSOLECONTROL ConsoleCommand,
	IN PVOID ConsoleInformation, 
	IN ULONG ConsoleInformationLength
	);

// NtUserConvertMemHandle creates a memory handle for a data block.
W32KAPI
HANDLE
NTAPI
NtUserConvertMemHandle(
	IN PVOID Data,
	IN ULONG DataSize
	);

// NtUserCopyAcceleratorTable copies an accelerator table.
W32KAPI
LONG
NTAPI
NtUserCopyAcceleratorTable(
	IN HACCEL SourceAccelerator,
	IN OUT PACCEL DestAccelerator OPTIONAL,
	IN LONG NumAccelEntries
	);

// NtUserCountClipboardFormats returns the number of active clipboard formats.
W32KAPI
LONG
NTAPI
NtUserCountClipboardFormats(
	VOID
	);

#if _WIN32_WINNT >= 0x0501

// NtUserRealWaitMessageEx waits for a queue state change, without calling usermode for a message pump hook.
W32KAPI
BOOL
NTAPI
NtUserRealWaitMessageEx(
	IN ULONG Flags,
	IN ULONG Timeout
	);

// NtUserRealInternalGetMessage retrieves a message from the current thread's message queue (with an optional wait).
W32KAPI
BOOL
NTAPI
NtUserRealInternalWaitMessage(
	OUT PMSG Msg,
	IN HWND Window,
	IN ULONG MsgFilterMin,
	IN ULONG MsgFilterMaax,
	IN ULONG RemoveMsg,
	IN BOOL Wait
	);

#endif

#endif
