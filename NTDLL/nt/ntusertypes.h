#ifdef _MSC_VER
#pragma once
#endif

#ifndef NTUSERTYPES_H
#define NTUSERTYPES_H

//
// WinDef
//

#ifndef _NTWIN32_NO_WINDEF

typedef HANDLE HWND;
typedef HANDLE HDWP;
typedef HANDLE HACCEL;
typedef HANDLE HDESK;
typedef HANDLE HWINSTA;
typedef HANDLE HMENU;
typedef HANDLE HSTR;
typedef HANDLE HTASK;
typedef HANDLE HKL;
typedef HANDLE HMONITOR;
typedef HANDLE HWINEVENTHOOK;
typedef HANDLE HUMPD;
typedef HANDLE HCURSOR;

typedef ULONG COLORREF;

#ifndef NEAR
#define NEAR
#endif

#ifndef FAR
#define FAR
#endif

typedef ULONG BOOL;
typedef UINT_PTR WPARAM;
typedef LONG_PTR LPARAM;



typedef struct tagRECT {
	LONG left;
	LONG top;
	LONG right;
	LONG bottom;
} RECT, * PRECT, * LPRECT;

typedef struct _RECTL {
	LONG left;
	LONG top;
	LONG right;
	LONG bottom;
} RECTL, * PRECTL, * LPRECTL;

typedef struct tagPOINT {
	LONG x;
	LONG y;
} POINT, * PPOINT, * LPPOINT;

typedef struct _POINTL {
	LONG x;
	LONG y;
} POINTL, * PPOINTL, * LPPOINTL;

typedef struct tagSIZE {
	LONG cx;
	LONG cy;
} SIZE, * PSIZE, * LPSIZE;

typedef struct tagSIZEL {
	LONG cx;
	LONG cy;
} SIZEL, * PSIZEL, * LPSIZEL;

typedef LONG_PTR LRESULT;




typedef HANDLE HDC;
typedef HANDLE HGDIOBJ;
typedef HANDLE HBRUSH;
typedef HANDLE HBITMAP;
typedef HANDLE HPEN;
typedef HANDLE HRGN;
typedef HANDLE HCOLORSPACE;
typedef HANDLE HGLRC;
typedef HANDLE HENHMETAFILE;
typedef HANDLE HFONT;
typedef HANDLE HICON;
typedef HANDLE HMETAFILE;
typedef HANDLE HPALETTE;

#ifndef _PALETTEENTRY_DEFINED
#define _PALETTEENTRY_DEFINED

typedef struct tagPALETTEENTRY {
	BYTE peRed;
	BYTE peGreen;
	BYTE peBlue;
	BYTE peFlags;
} PALETTEENTRY, * PPALETTEENTRY, * LPPALETTEENTRY;

#endif

#ifndef _LOGPALETTE_DEFINED
#define _LOGPALETTE_DEFINED

typedef struct tagLOGPALETTE {
	WORD palVersion;
	WORD palNumEntries;
	PALETTEENTRY palPalEntry[1];
} LOGPALETTE, * PLOGPALETTE, * LPLOGPALETTE;

#endif



#endif

//
// WinUser
//

#ifndef _NTWIN32_NO_WINUSER

typedef struct tagMSG {
	HWND hwnd;
	UINT message;
	WPARAM wParam;
	LPARAM lParam;
	DWORD time;
	POINT pt;
#ifdef _MAC
	DWORD lPrivate;
#endif
} MSG, * PMSG, NEAR * NPMSG, FAR * LPMSG;

#define POINTSTOPOINT(pt, pts)					\
{ (pt).x = (LONG)(SHORT)LOWORD(*(LONG*)&pts);	\
	(pt).y = (LONG)(SHORT)HIWORD(*(LONG*)&pts);	}

#define POINTTOPOINTS(pt)		(MAKELONG((short)((pt).x), (short)((pt).y)))
#define MAKEWPARAM(l, h)		((WPARAM)(DWORD)MAKELONG(l, h))
#define MAKELPARAM(l, h)		((LPARAM)(DWORD)MAKELONG(l, h))
#define MAKELRESULT(l, h)		((LRESULT)(DWORD)MAKELONG(l, h))

typedef struct tagPAINTSTRUCT {
	HDC hdc;
	BOOL fErase;
	RECT rcPaint;
	BOOL fRestore;
	BOOL fIncUpdate;
	BYTE rgbReserved[32];
} PAINTSTRUCT, * PPAINTSTRUCT, * NPPAINTSTRUCT, * LPPAINTSTRUCT;

typedef struct _PROPSET {
	HANDLE hData;
	ATOM atom;
} PROPSET, *PPROPSET;

#define MONITORINFOF_PRIMARY		0x00000001

#define FVIRTKEY  TRUE          /* Assumed to be == TRUE */
#define FNOINVERT 0x02
#define FSHIFT    0x04
#define FCONTROL  0x08
#define FALT      0x10

typedef struct tagACCEL {
#ifndef _MAC
	BYTE fVirt;
	WORD key;
	WORD cmd;
#else
	WORD fVirt;
	WORD key;
	DWORD cmd;
#endif
} ACCEL, *LPACCEL;

#endif

typedef ACCEL * PACCEL;

//
// NtUser
//

typedef struct _NAMELIST {
	ULONG Size;
	ULONG NumberOfNames;
	WCHAR Names[ANYSIZE_ARRAY];
} NAMELIST, *PNAMELIST;

#if _WIN32_WINNT == 0x0502

typedef enum _NTUSERCALL {
	NtUserCallCreateMenu,
	NtUserCallCreatePopupMenu,
	NtUserCallDisableProcessWindowsGhosting,
	NtUserCallClearWakeMask,
	NtUserCallAllowForegroundActivation,
	NtUserCallDestroyCaret,
	NtUserCallGetDeviceChangeInfo,
	NtUserCallGetIMEStatus,
	NtUserCallGetInputDesktop,
	NtUserCallGetMessagePos,
	NtUserCallGetRemoteProcessId,
	NtUserCallHideCursorNoCapture,
	NtUserCallLoadCursorsAndIcons,
	NtUserCallReleaseCapture,
	NtUserCallResetDblClk,
	NtUserCallZapActiveAndFocus,
	NtUserCallRemoteConsoleShadowStop,
	NtUserCallDisconnect,
	NtUserCallRemoteLogoff,
	NtUserCallRemoteNtSecurity,
	NtUserCallRemoteShadowSetup,
	NtUserCallRemoteShadowStop,
	NtUserCallRemotePassthruEnable,
	NtUserCallRemotePassthruDisable,
	NtUserCallRemoteConnectState,
	NtUserCallUpdatePerUserImmEnabling,
	NtUserCallUserPowerCalloutWorker,
	NtUserCallDoInitMessagePumpHook,
	NtUserCallDoUninitMessagePumpHook,
	NtUserCallLoadUserApiHook,
	NtUserCallBeginDeferWindowPos,
	NtUserCallWindowFromDC,
	NtUserCallAllowSetForegroundWindow,
	NtUserCallCreateEmptyCursorObject,
	NtUserCallCreateSystemThreads,
	NtUserCallCsDdeUninitialize,
	NtUserCallDirectedYield,
	NtUserCallEnumClipboardFormats,
	NtUserCallGetCursorPos,
	NtUserCallGetInputEvent,
	NtUserCallGetKeyboardLayout,
	NtUserCallGetKeyboardType,
	NtUserCallGetProcessDefaultLayout,
	NtUserCallGetQueueStatus,
	NtUserCallGetWinStationInfo
} NTUSERCALL, * PNTUSERCALL;

#elif _WIN32_WINNT == 0x0501

typedef enum _NTUSERCALL {
} NTUSERCALL, * PNTUSERCALL;

#elif _WIN32_WINNT == 0x0500

typedef enum _NTUSERCALL {
} NTUSERCALL, * PNTUSERCALL;

#elif _WIN32_WINNT == 0x0400

typedef enum _NTUSERCALL {
} NTUSERCALL, * PNTUSERCALL;

#else

#error No NtUserCall for this platform.

#endif

typedef enum _CONSOLECONTROL {
	ConsoleDesktopConsoleThread,		// 0x00
	ConsoleClassAtom,					// 0x01
	ConsolePermanentFont,				// 0x02
	ConsoleSetVDMCursorBounds,			// 0x03
	ConsoleNotifyConsoleApplication,	// 0x04
	ConsolePublicPalette,				// 0x05
	ConsoleWindowStationProcess,		// 0x06
	ConsoleRegisterConsoleIME,			// 0x07
	ConsoleFullscreenSwitch,			// 0x08
	ConsoleSetCaretInfo,				// 0x09
	MaxConsoleControl
} CONSOLECONTROL, * PCCONSOLECONTROL;

typedef struct _CONSOLEDESKTOPCONSOLETHREAD { // Class 0
	HDESK hdesk;
	DWORD dwThreadId;
} CONSOLEDESKTOPCONSOLETHREAD, *PCONSOLEDESKTOPCONSOLETHREAD;

// typedef ATOM _CONSOLECLASSATOM; // Class 2
// typedef RECT _CONSOLESETVDMCURSORBOUNDS; // Class 3
typedef struct _CONSOLE_PROCESS_INFO CONSOLENOTIFYCONSOLEAPPLICATION; // Class 4
// typedef HPALETTE CONSOLEPUBLICPALETTE; // Class 5

typedef struct _CONSOLEWINDOWSTATIONPROCESS { // Class 6
	DWORD dwProcessId;
	HWINSTA hwinsta;
} CONSOLEWINDOWSTATIONPROCESS, *PCONSOLEWINDOWSTATIONPROCESS;

typedef struct _CONSOLE_REGISTER_CONSOLEIME CONSOLE_REGISTER_CONSOLEIME; // Class 7

typedef struct _CONSOLE_FULLSCREEN_SWITCH { // Class 8
	BOOL bFullscreenSwitch;
	HWND hwnd;
} CONSOLE_FULLSCREEN_SWITCH, * PCONSOLE_FULLSCREEN_SWITCH;

typedef struct _CONSOLE_CARET_INFO CONSOLE_CARET_INFO; // Class 9



typedef enum _FULLSCREENCONTROL {
	FullscreenControlEnable,				// 0x00
	FullscreenControlDisable,				// 0x01
	FullscreenControlSetCursorPosition,		// 0x02
	FullscreenControlSetCursorAttributes,	// 0x03
	FullscreenControlRegisterVdm,			// 0x04
	FullscreenControlSetPalette,			// 0x05
	FullscreenControlSetColors,				// 0x06
	FullscreenControlLoadFont,				// 0x07
	FullscreenControlRestoreHardwareState,	// 0x08
	FullscreenControlSaveHardwareState,		// 0x09
	FullscreenControlCopyFrameBuffer,		// 0x0a
	FullscreenControlReadFromFrameBuffer,	// 0x0b
	FullscreenControlWriteToFrameBuffer,	// 0x0c
	FullscreenControlReverseMousePointer,	// 0x0d
	FullscreenControlSetMode				// 0x0e
} FULLSCREENCONTROL;


#endif
