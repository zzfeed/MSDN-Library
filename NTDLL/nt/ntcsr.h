#ifndef NTCSR_H
#define NTCSR_H

#pragma once

#ifdef __IDA__

#define _NTNATIVE_BEGIN_NT
#define _NTNATIVE_END_NT
#define NTAPI
#define NTSYSAPI
#define IN
#define OUT
#define OPTIONAL
#define VOID void

#ifndef NTTYPES_H
typedef struct _CLIENT_ID {
	HANDLE UniqueProcess;
	HANDLE UniqueThread;
} CLIENT_ID,*PCLIENT_ID;

typedef struct _PORT_MESSAGE {
	struct {
		union {
			struct {
				CSHORT DataLength;
				CSHORT TotalLength;
			} s1;
			ULONG Length;
		} u1;
		union {
			struct {
				CSHORT Type;
				CSHORT DataInfoOffset;
			} s2;
			ULONG ZeroInit;
		} u2;
		union {
			CLIENT_ID ClientId;
			double DoNotUseThisField;	// Alignment
		};
		ULONG MessageId;
		union {
			ULONG ClientViewSize;	// Only valid on LPC_CONNECTION_REQUEST message
			ULONG CallbackId;		// Only valid on LPC_REQUEST message
		};
		//  UCHAR Data[];
	};
} PORT_MESSAGE,*PPORT_MESSAGE;
#endif

#endif

_NTNATIVE_BEGIN_NT

typedef ULONG (NTAPI * PCSR_CALLBACK_ROUTINE)(IN OUT struct _CSR_API_MSG* ReplyMsg);

typedef struct _CSR_CALLBACK_INFO {
	ULONG ApiNumberBase;
	ULONG MaxApiNumber;
	PCSR_CALLBACK_ROUTINE *CallbackDispatchTable;
} CSR_CALLBACK_INFO, *PCSR_CALLBACK_INFO;

typedef struct _CSR_API_CONNECTINFO {
	IN ULONG ExpectedVersion;
	OUT ULONG CurrentVersion;
	OUT HANDLE ObjectDirectory;
	OUT PVOID SharedSectionBase;
	OUT PVOID SharedStaticServerData;
	OUT PVOID SharedSectionHeap;
	OUT ULONG DebugFlags;
	OUT ULONG SizeOfPebData;
	OUT ULONG SizeOfTebData;
	OUT ULONG NumberOfServerDllNames;
} CSR_API_CONNECTINFO, *PCSR_API_CONNECTINFO;

#define CSR_VERSION 0x10000

typedef struct _CSR_NULLAPICALL_MSG {
	LONG  CountArguments;
	ULONG FastArguments[12];
	PCHAR *Arguments;
} CSR_NULLAPICALL_MSG, *PCSR_NULLAPICALL_MSG;

typedef struct _CSR_CLIENTCONNECT_MSG {
	IN ULONG ServerDllIndex;
	IN OUT PVOID ConnectionInformation;
	IN OUT ULONG ConnectionInformationLength;
} CSR_CLIENTCONNECT_MSG, *PCSR_CLIENTCONNECT_MSG;

typedef struct _CSR_THREADCONNECT_MSG {
	HANDLE SectionHandle;
	HANDLE EventPairHandle;
	OUT PCHAR MessageStack;
	OUT ULONG MessageStackSize;
	OUT ULONG RemoteViewDelta;
} CSR_THREADCONNECT_MSG, *PCSR_THREADCONNECT_MSG;

#define CSR_PROFILE_START	   0x00000001
#define CSR_PROFILE_STOP		0x00000002
#define CSR_PROFILE_DUMP		0x00000003
#define CSR_PROFILE_STOPDUMP	0x00000004

typedef struct _CSR_PROFILE_CONTROL_MSG {
	IN ULONG ProfileControlFlag;
} CSR_PROFILE_CONTROL_MSG, *PCSR_PROFILE_CONTROL_MSG;

typedef struct _CSR_IDENTIFY_ALERTABLE_MSG {
	IN CLIENT_ID ClientId;
} CSR_IDENTIFY_ALERTABLE_MSG, *PCSR_IDENTIFY_ALERTABLE_MSG;

#define CSR_NORMAL_PRIORITY_CLASS   0x00000010
#define CSR_IDLE_PRIORITY_CLASS	 0x00000020
#define CSR_HIGH_PRIORITY_CLASS	 0x00000040
#define CSR_REALTIME_PRIORITY_CLASS 0x00000080

typedef struct _CSR_SETPRIORITY_CLASS_MSG {
	IN HANDLE ProcessHandle;
	IN ULONG PriorityClass;
} CSR_SETPRIORITY_CLASS_MSG, *PCSR_SETPRIORITY_CLASS_MSG;

typedef struct _CSR_CAPTURE_HEADER {
	ULONG Length;
	struct _CSR_CAPTURE_HEADER *RelatedCaptureBuffer;
	ULONG CountMessagePointers;
#if _WIN32_WINNT <= 0x0400
	ULONG CountCapturePointers;
#endif
	PULONG MessagePointerOffsets; // Relative to message
#if _WIN32_WINNT <= 0x0400
	PULONG CapturePointerOffsets; // Relative to capture buffer
	PCHAR FreeSpace;
#endif
} CSR_CAPTURE_HEADER, *PCSR_CAPTURE_HEADER;

typedef ULONG CSR_API_NUMBER;

typedef struct _CSR_API_MSG {
	PORT_MESSAGE h;
	union {
		CSR_API_CONNECTINFO ConnectionRequest;
		struct {
			PCSR_CAPTURE_HEADER CaptureBuffer;
			CSR_API_NUMBER ApiNumber;
			ULONG ReturnValue;
			ULONG Reserved;
			union {
				CSR_NULLAPICALL_MSG NullApiCall;
				CSR_CLIENTCONNECT_MSG ClientConnect;
				CSR_THREADCONNECT_MSG ThreadConnect;
				CSR_PROFILE_CONTROL_MSG ProfileControl;
				CSR_IDENTIFY_ALERTABLE_MSG IdentifyAlertable;
				CSR_SETPRIORITY_CLASS_MSG PriorityClass;
				ULONG ApiMessageData[30];
			} u;
		};
	};
} CSR_API_MSG, *PCSR_API_MSG;

#define CSRSRV_SERVERDLL_INDEX	 0
#define BASESRV_SERVERDLL_INDEX  1
#define CONSRV_SERVERDLL_INDEX	 2
#define USERSRV_SERVERDLL_INDEX  3
#define CSRSRV_FIRST_API_NUMBER	0
#define BASESRV_FIRST_API_NUMBER 0
#define CONSRV_FIRST_API_NUMBER 0x200
#define USERSRV_FIRST_API_NUMBER 0x400

#define CSR_MAKE_API_NUMBER(CsrDllIndex, ApiIndex) (CSR_API_NUMBER)(((CsrDllIndex) << 16) | (ApiIndex))

#define CSR_APINUMBER_TO_SERVERDLLINDEX(ApiNumber) ((ULONG)((ULONG)(ApiNumber) >> 16))

#define CSR_APINUMBER_TO_APITABLEINDEX(ApiNumber) ((ULONG)((USHORT)(ApiNumber)))

typedef enum _CSRP_API_NUMBER {
	CsrpNullApiCall = CSRSRV_FIRST_API_NUMBER,
	CsrpClientConnect,
	CsrpThreadConnect,
	CsrpProfileControl,
	CsrpIdentifyAlertable,
	CsrpSetPriorityClass,
	CsrpMaxApiNumber
} CSRP_API_NUMBER, *PCSRP_API_NUMBER;

typedef enum _BASESRV_API_NUMBER {
	BasepCreateProcess = BASESRV_FIRST_API_NUMBER,
	BasepCreateThread,
	BasepGetTempFile,
	BasepExitProcess,
	BasepDebugProcess,
	BasepCheckVDM,
	BasepUpdateVDMEntry,
	BasepGetNextVDMCommand,
	BasepExitVDM,
	BasepIsFirstVDM,
	BasepGetVDMExitCode,
	BasepSetReenterCount,
	BasepSetProcessShutdownParam,
	BasepGetProcessShutdownParam,
	BasepNlsSetUserInfo,
	BasepNlsSetMultipleUserInfo,
	BasepNlsCreateSortSection,
#if _WIN32_WINNT <= 0x0500
	BasepNlsPreserveSection,
#endif
	BasepSetVDMCurDirs,
	BasepGetVDMCurDirs,
	BasepBatNotification,
	BasepRegisterWowExec,
	BasepSoundSentryNotification,
	BasepRefreshIniFileMapping,
	BasepDefineDosDevice,
#if _WIN32_WINNT >= 0x0500
	BasepSetTermsrvAppInstallMode,
	BasepNlsUpdateCacheCount,
#endif
#if _WIN32_WINNT >= 0x0501
	BasepSetTermsrvClientTimeZone,
	BasepSxsCreateActivationContext,
	BasepDebugProcessStop,
	BasepRegisterThread,
	BasepCheckApplicationCompatibility,
	BasepNlsGetUserInfo,
#endif
	BasepMaxApiNumber
} BASESRV_API_NUMBER, *PBASESRV_API_NUMBER;

typedef enum _USER_API_NUMBER {
	UserpExitWindowsEx = USERSRV_FIRST_API_NUMBER,
	UserpEndTask,
	UserpLogon,
	UserpRegisterServicesProcess,
	UserpActivateDebugger,
	UserpGetThreadConsoleDesktop,
	UserpDeviceEvent,
	UserpRegisterLogonProcess,
	UserpWin32HeapFail,
	UserpWin32HeapStat,
	UserpMaxApiNumber
} USER_API_NUMBER, *PUSER_API_NUMBER;

typedef struct _BASESRV_API_CONNECTINFO {
	IN ULONG ExpectedVersion;
	OUT HANDLE DefaultObjectDirectory;
	OUT ULONG WindowsVersion;
	OUT ULONG CurrentVersion;
	OUT ULONG DebugFlags;
	OUT WCHAR WindowsDirectory[MAX_PATH];
	OUT WCHAR WindowsSystemDirectory[MAX_PATH];
} BASESRV_API_CONNECTINFO, *PBASESRV_API_CONNECTINFO;

typedef struct _BASE_CREATEPROCESS_MSG {
	HANDLE ProcessHandle;
	HANDLE ThreadHandle;
	CLIENT_ID ClientId;
	CLIENT_ID DebuggerClientId;
	ULONG CreationFlags;
	ULONG IsVDM;
	HANDLE hVDM;
} BASE_CREATEPROCESS_MSG, *PBASE_CREATEPROCESS_MSG;

#ifdef _NTTYPES_NO_WINNT

typedef struct _BASE_CREATETHREAD_MSG {
	HANDLE ThreadHandle;
	CLIENT_ID ClientId;
} BASE_CREATETHREAD_MSG, *PBASE_CREATETHREAD_MSG;

typedef struct _BASE_GETTEMPFILE_MSG {
	UINT uUnique;
} BASE_GETTEMPFILE_MSG, *PBASE_GETTEMPFILE_MSG;

typedef struct _BASE_EXITPROCESS_MSG {
	UINT uExitCode;
} BASE_EXITPROCESS_MSG, *PBASE_EXITPROCESS_MSG;

typedef struct _BASE_DEBUGPROCESS_MSG {
	DWORD dwProcessId;
	CLIENT_ID DebuggerClientId;
	PVOID AttachCompleteRoutine;
} BASE_DEBUGPROCESS_MSG, *PBASE_DEBUGPROCESS_MSG;

typedef struct _BASE_CHECKVDM_MSG {
	ULONG iTask;
	HANDLE ConsoleHandle;
	ULONG BinaryType;
	HANDLE WaitObjectForParent;
	HANDLE StdIn;
	HANDLE StdOut;
	HANDLE StdErr;
	ULONG CodePage;
	ULONG dwCreationFlags;
	PCHAR CmdLine;
	PCHAR AppName;
	PCHAR PifFile;
	PCHAR CurDirectory;
	PCHAR Env;
	ULONG EnvLen;
	struct _STARTUPINFOA* StartupInfo;
	PCHAR Desktop;
	ULONG DesktopLen;
	PCHAR Title;
	ULONG TitleLen;
	PCHAR Reserved;
	ULONG ReservedLen;
	USHORT CmdLen;
	USHORT AppLen;
	USHORT PifLen;
	USHORT CurDirectoryLen;
	USHORT CurDrive;
	USHORT VDMState;
} BASE_CHECKVDM_MSG, *PBASE_CHECKVDM_MSG;

typedef struct _BASE_UPDATE_VDM_ENTRY_MSG {
	ULONG iTask;
	ULONG BinaryType;
	HANDLE ConsoleHandle;
	HANDLE VDMProcessHandle;
	HANDLE WaitObjectForParent;
	WORD EntryIndex;
	WORD VDMCreationState;
} BASE_UPDATE_VDM_ENTRY_MSG, *PBASE_UPDATE_VDM_ENTRY_MSG;

typedef struct _BASE_GET_NEXT_VDM_COMMAND_MSG {
	ULONG  iTask;
	HANDLE ConsoleHandle;
	HANDLE WaitObjectForVDM;
	HANDLE StdIn;
	HANDLE StdOut;
	HANDLE StdErr;
	ULONG  CodePage;
	ULONG  dwCreationFlags;
	ULONG  ExitCode;
	PCHAR  CmdLine;
	PCHAR  AppName;
	PCHAR  PifFile;
	PCHAR  CurDirectory;
	PCHAR  Env;
	ULONG  EnvLen;
	struct _STARTUPINFOA* StartupInfo;
	PCHAR  Desktop;
	ULONG  DesktopLen;
	PCHAR  Title;
	ULONG  TitleLen;
	PCHAR  Reserved;
	ULONG  ReservedLen;
	USHORT CurrentDrive;
	USHORT CmdLen;
	USHORT AppLen;
	USHORT PifLen;
	USHORT CurDirectoryLen;
	USHORT VDMState;
	BOOLEAN fComingFromBat;
} BASE_GET_NEXT_VDM_COMMAND_MSG, *PBASE_GET_NEXT_VDM_COMMAND_MSG;

typedef struct _BASE_EXIT_VDM_MSG {
	HANDLE ConsoleHandle;
	ULONG iWowTask;
	HANDLE WaitObjectForVDM;
} BASE_EXIT_VDM_MSG, *PBASE_EXIT_VDM_MSG;

typedef struct _BASE_IS_FIRST_VDM_MSG {
	BOOL    FirstVDM;
} BASE_IS_FIRST_VDM_MSG, *PBASE_IS_FIRST_VDM_MSG;

typedef struct _BASE_GET_VDM_EXIT_CODE_MSG {
	HANDLE ConsoleHandle;
	HANDLE hParent;
	ULONG ExitCode;
} BASE_GET_VDM_EXIT_CODE_MSG, *PBASE_GET_VDM_EXIT_CODE_MSG;

typedef struct _BASE_SET_REENTER_COUNT {
	HANDLE ConsoleHandle;
	ULONG  fIncDec;
} BASE_SET_REENTER_COUNT_MSG, *PBASE_SET_REENTER_COUNT_MSG;

typedef struct _BASE_SHUTDOWNPARAM_MSG {
	ULONG ShutdownLevel;
	ULONG ShutdownFlags;
} BASE_SHUTDOWNPARAM_MSG, *PBASE_SHUTDOWNPARAM_MSG;

typedef struct _BASE_NLS_SET_USER_INFO_MSG {
	PWCHAR pValue;
	PWCHAR pCacheString;
	PWCHAR pData;
	ULONG DataLength;
} BASE_NLS_SET_USER_INFO_MSG, *PBASE_NLS_SET_USER_INFO_MSG;

typedef struct _BASE_NLS_SET_MULTIPLE_USER_INFO_MSG {
	ULONG Flags;
	ULONG DataLength;
	PWCHAR pPicture;
	PWCHAR pSeparator;
	PWCHAR pOrder;
	PWCHAR pTLZero;
	PWCHAR pTimeMarkPosn;
} BASE_NLS_SET_MULTIPLE_USER_INFO_MSG, *PBASE_NLS_SET_MULTIPLE_USER_INFO_MSG;

typedef struct _BASE_NLS_CREATE_SORT_SECTION_MSG {
#if _WIN32_WINNT >= 0x0500
	ULONG Reserved;
	ULONG NlsSection;
	LCID Locale;
#else
	UNICODE_STRING SectionName;
	HANDLE hNewSection;
	LARGE_INTEGER SectionSize;
#endif
} BASE_NLS_CREATE_SORT_SECTION_MSG, *PBASE_NLS_CREATE_SORT_SECTION_MSG;

typedef struct _BASE_NLS_PRESERVE_SECTION_MSG {
	HANDLE hSection;
} BASE_NLS_PRESERVE_SECTION_MSG, *PBASE_NLS_PRESERVE_SECTION_MSG;

typedef struct _BASE_GET_SET_VDM_CUR_DIRS_MSG {
	HANDLE ConsoleHandle;
	PCHAR lpszzCurDirs;
	ULONG cchCurDirs;
} BASE_GET_SET_VDM_CUR_DIRS_MSG, *PBASE_GET_SET_VDM_CUR_DIRS_MSG;

typedef struct _BASE_BAT_NOTIFICATION_MSG {
	HANDLE ConsoleHandle;
	ULONG fBeginEnd;
} BASE_BAT_NOTIFICATION_MSG, *PBASE_BAT_NOTIFICATION_MSG;

typedef struct _BASE_REGISTER_WOWEXEC_MSG {
	HANDLE hwndWowExec;
} BASE_REGISTER_WOWEXEC_MSG, *PBASE_REGISTER_WOWEXEC_MSG;

typedef struct _BASE_SOUNDSENTRY_NOTIFICATION_MSG {
	ULONG VideoMode;
} BASE_SOUNDSENTRY_NOTIFICATION_MSG, *PBASE_SOUNDSENTRY_NOTIFICATION_MSG;

typedef struct _BASE_REFRESHINIFILEMAPPING_MSG {
	UNICODE_STRING IniFileName;
} BASE_REFRESHINIFILEMAPPING_MSG, *PBASE_REFRESHINIFILEMAPPING_MSG;

typedef struct _BASE_DEFINEDOSDEVICE_MSG {
	ULONG Flags;
	UNICODE_STRING DeviceName;
	UNICODE_STRING TargetPath;
} BASE_DEFINEDOSDEVICE_MSG, *PBASE_DEFINEDOSDEVICE_MSG;

typedef struct _BASE_API_MSG {
	PORT_MESSAGE h;
	PCSR_CAPTURE_HEADER CaptureBuffer;
	CSR_API_NUMBER ApiNumber;
	ULONG ReturnValue;
	ULONG Reserved;
	union {
		BASE_NLS_SET_USER_INFO_MSG NlsSetUserInfo;
		BASE_NLS_SET_MULTIPLE_USER_INFO_MSG NlsSetMultipleUserInfo;
		BASE_NLS_CREATE_SORT_SECTION_MSG NlsCreateSortSection;
		BASE_NLS_PRESERVE_SECTION_MSG NlsPreserveSection;
		BASE_SHUTDOWNPARAM_MSG ShutdownParam;
		BASE_CREATEPROCESS_MSG CreateProcess;
		BASE_CREATETHREAD_MSG CreateThread;
		BASE_GETTEMPFILE_MSG GetTempFile;
		BASE_EXITPROCESS_MSG ExitProcess;
		BASE_DEBUGPROCESS_MSG DebugProcess;
		BASE_CHECKVDM_MSG CheckVDM;
		BASE_UPDATE_VDM_ENTRY_MSG UpdateVDMEntry;
		BASE_GET_NEXT_VDM_COMMAND_MSG GetNextVDMCommand;
		BASE_EXIT_VDM_MSG ExitVDM;
		BASE_IS_FIRST_VDM_MSG IsFirstVDM;
		BASE_GET_VDM_EXIT_CODE_MSG GetVDMExitCode;
		BASE_SET_REENTER_COUNT_MSG SetReenterCount;
		BASE_GET_SET_VDM_CUR_DIRS_MSG GetSetVDMCurDirs;
		BASE_BAT_NOTIFICATION_MSG BatNotification;
		BASE_REGISTER_WOWEXEC_MSG RegisterWowExec;
		BASE_SOUNDSENTRY_NOTIFICATION_MSG SoundSentryNotification;
		BASE_REFRESHINIFILEMAPPING_MSG RefreshIniFileMapping;
		BASE_DEFINEDOSDEVICE_MSG DefineDosDeviceApi;
	} u;
} BASE_API_MSG, *PBASE_API_MSG;

typedef struct _EXITWINDOWSEXMSG {
	DWORD dwLastError;
	UINT uFlags;
	DWORD dwReserved;
	BOOL fSuccess;
} EXITWINDOWSEXMSG, *PEXITWINDOWSEXMSG;

typedef struct _ENDTASKMSG {
	DWORD dwLastError;
	HWND hwnd;
	BOOL fShutdown;
	BOOL fForce;
	BOOL fSuccess;
} ENDTASKMSG, *PENDTASKMSG;

typedef struct _LOGONMSG {
	BOOL fLogon;
} LOGONMSG, *PLOGONMSG;

typedef struct _ADDFONTMSG {
	PWCHAR pwchName;
	DWORD dwFlags;
} ADDFONTMSG, *PADDFONTMSG;

typedef struct _REGISTERSERVICESPROCESSMSG {
	DWORD dwLastError;
	DWORD dwProcessId;
	BOOL fSuccess;
} REGISTERSERVICESPROCESSMSG, *PREGISTERSERVICESPROCESSMSG;

typedef struct _ACTIVATEDEBUGGERMSG {
	CLIENT_ID ClientId;
} ACTIVATEDEBUGGERMSG, *PACTIVATEDEBUGGERMSG;

typedef struct _GETTHREADCONSOLEDESKTOPMSG {
	DWORD dwThreadId;
	HDESK hdeskConsole;
} GETTHREADCONSOLEDESKTOPMSG, *PGETTHREADCONSOLEDESKTOPMSG;

typedef struct _WIN32HEAPFAILMSG {
	DWORD dwFlags;
	BOOL bFail;
} WIN32HEAPFAILMSG, *PWIN32HEAPFAILMSG;

typedef struct _WIN32HEAPSTATMSG {
	PVOID phs;
	DWORD dwLen;
	DWORD dwMaxTag;
} WIN32HEAPSTATMSG, *PWIN32HEAPSTATMSG;

typedef struct _DEVICEEVENTMSG {
	HWND hWnd;
	WPARAM wParam;
	LPARAM lParam;
	DWORD  dwFlags;
	ULONG_PTR dwResult;
} DEVICEEVENTMSG, *PDEVICEEVENTMSG;

typedef struct _USER_API_MSG {
	PORT_MESSAGE h;
	PCSR_CAPTURE_HEADER CaptureBuffer;
	CSR_API_NUMBER ApiNumber;
	ULONG ReturnValue;
	ULONG Reserved;
	union {
		EXITWINDOWSEXMSG ExitWindowsEx;
		ENDTASKMSG EndTask;
		LOGONMSG Logon;
		REGISTERSERVICESPROCESSMSG RegisterServicesProcess;
		ACTIVATEDEBUGGERMSG ActivateDebugger;
		GETTHREADCONSOLEDESKTOPMSG GetThreadConsoleDesktop;
		WIN32HEAPFAILMSG Win32HeapFail;
		WIN32HEAPSTATMSG Win32HeapStat;
		DEVICEEVENTMSG DeviceEvent;
		DWORD IdLogon;
	} u;
} USER_API_MSG, *PUSER_API_MSG;

#endif

// CsrClientCallServer initiates an LPC call to the CSR server, and waits for a reply.
NTSYSAPI
NTSTATUS
NTAPI
CsrClientCallServer(
	IN OUT PCSR_API_MSG m,
	IN OUT PCSR_CAPTURE_HEADER CaptureBuffer OPTIONAL,
	IN CSR_API_NUMBER ApiNumber,
	IN ULONG ArgLength // Negative values mean that m->h.u2.s2.DataInfoOffset is valid
	);

// CsrNewThread sets up the thread termination port for a new thread.  It should not be called for the first thread.
NTSYSAPI
NTSTATUS
NTAPI
CsrNewThread(
	VOID
	);

#pragma warning(disable:4200)
typedef struct _CSR_CAPTURE_BUFFER {
	ULONG Length;
	ULONG u2;
	ULONG Value;
	PUCHAR ExtraData;
	ULONG MessageData[];
} CSR_CAPTURE_BUFFER, *PCSR_CAPTURE_BUFFER;
#pragma warning(default:4200)

// CsrAllocateCaptureBuffer allocates a CSR capture buffer from the CSR heap.
NTSYSAPI
PCSR_CAPTURE_HEADER
NTAPI
CsrAllocateCaptureBuffer(
	IN ULONG CountMessagePointers, // *6 bytes, > 0
#if _WIN32_WINNT <= 0x0400
	IN ULONG CountCapturePointers,
#endif
	IN ULONG Size // + extra bytes, >=1+ArraySize*4 && <= (~0x80000013 - Arg2 - Arg1*4)/3
	);

// CsrFreeCaptureBuffer frees a CSR capture buffer allocated with CsrAllocateCaptureBuffer.
NTSYSAPI
NTSTATUS
NTAPI
CsrFreeCaptureBuffer(
	IN PCSR_CAPTURE_HEADER CaptureBuffer
	);

// CsrClientConnectToServer connects to the CSR server.
NTSYSAPI
NTSTATUS
NTAPI
CsrClientConnectToServer(
	IN PWSTR ObjectDirectory,
	IN ULONG ServerDllIndex,
#if _WIN32_WINNT <= 0x0400
	IN PCSR_CALLBACK_INFO CallbackInformation OPTIONAL,
#endif
	IN PVOID ConnectionInformation,
	IN OUT PULONG ConnectionInformationLength OPTIONAL,
	OUT PBOOLEAN CalledFromServer OPTIONAL
	);

// CsrAllocateMessagePointer allocates a pointer within a CSR capture buffer.
NTSYSAPI
ULONG
NTAPI
CsrAllocateMessagePointer(
	IN OUT PCSR_CAPTURE_HEADER CaptureBuffer,
	IN ULONG Length,
	OUT PVOID *Pointer
	);

// CsrCaptureMessageBuffer captures an ANSI string from within a CSR capture buffer.
NTSYSAPI
VOID
NTAPI
CsrCaptureMessageBuffer(
	IN OUT PCSR_CAPTURE_HEADER CaptureBuffer,
	IN PVOID Buffer OPTIONAL,
	IN ULONG Length,
	OUT PVOID *CapturedBuffer
	);

// CsrCaptureMessageString captures a counted ANSI string from within a CSR capture buffer.
NTSYSAPI
VOID
NTAPI
CsrCaptureMessageString(
	IN OUT PCSR_CAPTURE_HEADER CaptureBuffer,
	IN PCSTR String OPTIONAL,
	IN ULONG Length,
	IN ULONG MaximumLength,
	OUT PSTRING CapturedString
	);

// CsrpConnectToServer connects to the CSR server.
typedef NTSTATUS (NTAPI * CsrpConnectToServerProc)(PCWSTR ServerName);

// CsrCaptureTimeout calculates a relative CSR capture timeout value.
NTSYSAPI
ULONG
NTAPI
CsrCaptureTimeout(
	  IN ULONG TimeoutMs,
	  OUT PLARGE_INTEGER TimeoutNs100
	  );

// CsrProbeForWrite tests a memory region for write access.  An exception is raised if it is not accessible or aligned.
NTSYSAPI
VOID
NTAPI
CsrProbeForWrite(
	IN PVOID Address,
	IN ULONG Length,
	IN ULONG Alignment
	);

// CsrProbeForRead tests a memory region for read access.  An exception is raised if it is not accessible or aligned.
NTSYSAPI
VOID
NTAPI
CsrProbeForRead(
	IN PVOID Address,
	IN ULONG Length,
	IN ULONG Alignment
	);

// CsrIdentifyAlertableThread marks the current thread as alertable.
NTSYSAPI
NTSTATUS
NTAPI
CsrIdentifyAlertableThread(
	VOID
	);

// CsrSetPriorityClass requests the CSR server to modify the priority class of a process.
NTSYSAPI
NTSTATUS
NTAPI
CsrSetPriorityClass(
	IN HANDLE ProcessHandle,
	IN OUT PULONG PriorityClass
	);

// CsrGetProcessId returns the unique process identifier of the CSR server process.
NTSYSAPI
HANDLE
NTAPI
CsrGetProcessId(
	VOID
	);

//
// WARNING OBSOLETE STRUCTURE DEFINITIONS !!!
//
// These are taken from the Windows NT/2000 Native API Reference.
// Symbols have proven them to be inaccurate, but they are retained for backwards compatibility.
//
// DO NOT USE THESE STRUCTURES IN NEW PROGRAMS!!!
//

typedef struct _CSRSS_MESSAGE {
	ULONG Unknown1;
	ULONG Opcode;
	ULONG Status;
	ULONG Unknown2;
} CSRSS_MESSAGE, * PCSRSS_MESSAGE;

typedef struct _CSRSS_PROCESS_INFORMATION {
	HANDLE hProcess;
	HANDLE hThread;
	DWORD dwProcessId;
	DWORD dwThreadId;
} CSRSS_PROCESS_INFORMATION, *PCSRSS_PROCESS_INFORMATION, *LPCSRSS_PROCESS_INFORMATION;


typedef struct _CSR_NEW_PROCESS_MESSAGE {
	PORT_MESSAGE PortMessage;
	CSRSS_MESSAGE CsrssMessage;
	CSRSS_PROCESS_INFORMATION ProcessInformation;
	CLIENT_ID Debugger;
	ULONG CreationFlags;
	ULONG VdmInfo[2];
} CSR_NEW_PROCESS_MESSAGE, * PCSR_NEW_PROCESS_MESSAGE;

typedef struct _CSR_NEW_THREAD_MESSAGE {
	PORT_MESSAGE PortMessage;
	CSRSS_MESSAGE CsrssMessage;
	HANDLE Thread;
	CLIENT_ID ClientId;
} CSR_NEW_THREAD_MESSAGE, * PCSR_NEW_THREAD_MESSAGE;

#ifdef NTNATIVE_CSRSS_FUNCTIONS

// Notify CSRSS of a new process.  Not a NT native API in itself, but useful for many things.
inline
VOID
NTAPI
CsrssNewProcessNotification(
	IN HANDLE Process,
	IN HANDLE Thread,
	IN ULONG ProcessId,
	IN ULONG ThreadId
	)
{
	CSR_NEW_PROCESS_MESSAGE CsrMessage = {{0}, {0}, {Process, Thread, ProcessId, ThreadId}, {0}, 0, {0}};
	CsrClientCallServer((PCSR_API_MSG)&CsrMessage, 0, 0x10000, sizeof(CSR_NEW_PROCESS_MESSAGE));
}

// Notify CSRSS of a new thread.
inline
VOID
NTAPI
CsrssNewThreadNotification(
	IN HANDLE Thread,
	IN PCLIENT_ID ClientId
	)
{
	CSR_NEW_THREAD_MESSAGE CsrMessage = {{0}, {0}, Thread, {ClientId->UniqueProcess, ClientId->UniqueThread}};
	CsrClientCallServer((PCSR_API_MSG)&CsrMessage, 0, 0x10001, sizeof(CLIENT_ID)+sizeof(HANDLE)); // Size: Bug?
}

// FindCsrpConnectToServer attempts to locate the address of CsrpConnectToServer, given
// the base address of ntdll.dll.
inline
NTSTATUS
NTAPI
FindCsrpConnectToServer(
	HANDLE Ntdll,
	CsrpConnectToServerProc* CsrpConnectToServer
	)
{
	__try {
		PIMAGE_NT_HEADERS NtHeaders = RtlImageNtHeader((PVOID)Ntdll);
		PBYTE ImageBase = (PBYTE)Ntdll;
		PVOID ApiPort = NULL, ApiPortRef = NULL;
		ULONG_PTR Offset;

		for(Offset = 0; Offset < (ULONG_PTR)NtHeaders->OptionalHeader.SizeOfImage-sizeof(L"ApiPort"); Offset++) {
			if(!memcmp(&ImageBase[Offset], L"ApiPort", sizeof(L"ApiPort"))) {
				ApiPort = &ImageBase[Offset];
				break;
			}
		}

		if(!ApiPort)
			return STATUS_ENTRYPOINT_NOT_FOUND;

		for(Offset = 0; Offset < (ULONG_PTR)NtHeaders->OptionalHeader.SizeOfImage-sizeof(ApiPort); Offset++) {
			if(!memcmp(&ImageBase[Offset], &ApiPort, sizeof(ApiPort))) {
				ApiPortRef = &ImageBase[Offset]; // Referenced only in CsrpConnectToServer
				break;
			}
		}

		if(!ApiPortRef)
			return STATUS_ENTRYPOINT_NOT_FOUND;

		for(Offset; Offset > 5; Offset--) {
			if(!memcmp(&ImageBase[Offset], "\x55\x8b\xec\x83\xec", 5)) { // Function start signature
				*CsrpConnectToServer = (CsrpConnectToServerProc)&ImageBase[Offset];
				return STATUS_SUCCESS;
			}
		}

		return STATUS_ENTRYPOINT_NOT_FOUND;
	}

	__except(GetExceptionCode() != STATUS_GUARD_PAGE_VIOLATION ? EXCEPTION_EXECUTE_HANDLER : EXCEPTION_CONTINUE_SEARCH) {
		return (NTSTATUS)GetExceptionCode();
	}
}

#endif

_NTNATIVE_END_NT

#endif
