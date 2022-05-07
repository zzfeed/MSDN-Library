
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

namespace MSDN.Enum
{
    public enum FILE_INFORMATION_CLASS : uint
    {
        FileDirectoryInformation = 1,
        FileFullDirectoryInformation,
        FileBothDirectoryInformation,
        FileBasicInformation,
        FileStandardInformation,
        FileInternalInformation,
        FileEaInformation,
        FileAccessInformation,
        FileNameInformation,
        FileRenameInformation,
        FileLinkInformation,
        FileNamesInformation,
        FileDispositionInformation,
        FilePositionInformation,
        FileFullEaInformation,
        FileModeInformation,
        FileAlignmentInformation,
        FileAllInformation,
        FileAllocationInformation,
        FileEndOfFileInformation,
        FileAlternateNameInformation,
        FileStreamInformation,
        FilePipeInformation,
        FilePipeLocalInformation,
        FilePipeRemoteInformation,
        FileMailslotQueryInformation,
        FileMailslotSetInformation,
        FileCompressionInformation,
        FileObjectIdInformation,
        FileCompletionInformation,
        FileMoveClusterInformation,
        FileQuotaInformation,
        FileReparsePointInformation,
        FileNetworkOpenInformation,
        FileAttributeTagInformation,
        FileTrackingInformation,
        FileIdBothDirectoryInformation,
        FileIdFullDirectoryInformation,
        FileValidDataLengthInformation,
        FileShortNameInformation,
        FileIoCompletionNotificationInformation,
        FileIoStatusBlockRangeInformation,
        FileIoPriorityHintInformation,
        FileSfioReserveInformation,
        FileSfioVolumeInformation,
        FileHardLinkInformation,
        FileProcessIdsUsingFileInformation,
        FileNormalizedNameInformation,
        FileNetworkPhysicalNameInformation,
        FileIdGlobalTxDirectoryInformation,
        FileIsRemoteDeviceInformation,
        FileAttributeCacheInformation,
        FileNumaNodeInformation,
        FileStandardLinkInformation,
        FileRemoteProtocolInformation,
        FileMaximumInformation 
    }
    public enum System_Information_Class : uint
    {
        SystemBasicInformation,
        SystemProcessorInformation,
        SystemPerformanceInformation,
        SystemTimeOfDayInformation,
        SystemPathInformation,
        SystemProcessInformation,
        SystemCallCounts,
        SystemConfigurationInformation,
        SystemProcessorTimes,
        SystemGlobalFlag,
        SystemNotImplemented2,
        SystemModuleInformation,
        SystemLockInformation,
        SystemNotImplemented3,
        SystemNotImplemented4,
        SystemNotImplemented5,
        SystemHandleInformation,
        SystemObjectInformation,
        SystemPagefileInformation,
        SystemInstructionEmulationCounts,
        SystemInvalidInfoClass1,
        SystemCacheInformation,
        SystemPoolTagInformation,
        SystemProcessorStatistics,
        SystemDpcInformation,
        SystemNotImplemented6,
        SystemLoadImage,
        SystemUnloadImage,
        SystemTimeAdjustment,
        SystemNotImplemented7,
        SystemNotImplemented8,
        SystemNotImplemented9,
        SystemCrashDumpInformation,
        SystemExceptionInformation,
        SystemCrashDumpStateInformation,
        SystemKernelDebuggerInformation,
        SystemContextSwitchInformation,
        SystemRegistryQuotaInformation,
        SystemLoadAndCallImage,
        SystemPrioritySeparation,
        SystemNotImplemented10,
        SystemNotImplemented11,
        SystemInvalidInfoClass2,
        SystemInvalidInfoClass3,
        SystemTimeZoneInformation,
        SystemLookasideInformation,
        SystemSetTimeSlipEvent,
        SystemCreateSession,
        SystemDeleteSession,
        SystemInvalidInfoClass4,
        SystemRangeStartInformation,
        SystemVerifierInformation,
        SystemAddVerifier,
        SystemSessionProcessesInformation,

        // http://forums.mydigitallife.info/archive/index.php/t-32135.html
        SystemDriveVolume = 98
    }
    public enum process_information_class : uint
    {
        ProcessBasicInformation,
        ProcessQuotaLimits,
        ProcessIoCounters,
        ProcessVmCounters,
        ProcessTimes,
        ProcessBasePriority,
        ProcessRaisePriority,
        ProcessDebugPort,
        ProcessExceptionPort,
        ProcessAccessToken,
        ProcessLdtInformation,
        ProcessLdtSize,
        ProcessDefaultHardErrorMode,
        ProcessIoPortHandlers,
        ProcessPooledUsageAndLimits,
        ProcessWorkingSetWatch,
        ProcessUserModeIOPL,
        ProcessEnableAlignmentFaultFixup,
        ProcessPriorityClass,
        ProcessWx86Information,
        ProcessHandleCount,
        ProcessAffinityMask,
        ProcessPriorityBoost,
        ProcessDeviceMap,
        ProcessSessionInformation,
        ProcessForegroundInformation,
        ProcessWow64Information,
        ProcessImageFileName,
        ProcessLUIDDeviceMapsEnabled,
        ProcessBreakOnTermination,
        ProcessDebugObjectHandle,
        ProcessDebugFlags,
        ProcessHandleTracing,
        ProcessIoPriority,
        ProcessExecuteFlags,
        ProcessTlsInformation,
        ProcessCookie,
        ProcessImageInformation,
        ProcessCycleTime,
        ProcessPagePriority,
        ProcessInstrumentationCallback,
        ProcessThreadStackAllocation,
        ProcessWorkingSetWatchEx,
        ProcessImageFileNameWin32,
        ProcessImageFileMapping,
        ProcessAffinityUpdateMode,
        ProcessMemoryAllocationMode,
        ProcessGroupInformation,
        ProcessTokenVirtualizationEnabled,
        ProcessConsoleHostProcess,
        ProcessWindowInformation,
        ProcessHandleInformation,
        ProcessMitigationPolicy,
        ProcessDynamicFunctionTableInformation,
        ProcessHandleCheckingMode,
        ProcessKeepAliveCount,
        ProcessRevokeFileHandles,
        MaxProcessInfoClass
    }
    public enum THREAD_INFORMATION_CLASS : uint
    {
        ThreadBasicInformation,
        ThreadTimes,
        ThreadPriority,
        ThreadBasePriority,
        ThreadAffinityMask,
        ThreadImpersonationToken,
        ThreadDescriptorTableEntry,
        ThreadEnableAlignmentFaultFixup,
        ThreadEventPair,
        ThreadQuerySetWin32StartAddress,
        ThreadZeroTlsCell,
        ThreadPerformanceCount,
        ThreadAmILastThread,
        ThreadIdealProcessor,
        ThreadPriorityBoost,
        ThreadSetTlsArrayAddress,
        ThreadIsIoPending,
        ThreadHideFromDebugger
    }
    public enum TOKEN_INFORMATION_CLASS : uint
    {
        None = 0,

        // The buffer receives a TOKEN_USER structure that contains the user account of the token.
        TokenUser,

        // The buffer receives a TOKEN_GROUPS structure that contains the group accounts associated with the token.
        TokenGroups,

        // The buffer receives a TOKEN_PRIVILEGES structure that contains the privileges of the token.
        TokenPrivileges,

        // The buffer receives a TOKEN_OWNER structure that contains the default owner security identifier (SID) for newly created objects.
        TokenOwner,

        // The buffer receives a TOKEN_PRIMARY_GROUP structure that contains the default primary group SID for newly created objects.
        TokenPrimaryGroup,

        // The buffer receives a TOKEN_DEFAULT_DACL structure that contains the default DACL for newly created objects.
        TokenDefaultDacl,

        // The buffer receives a TOKEN_SOURCE structure that contains the source of the token. TOKEN_QUERY_SOURCE access is needed to retrieve this information.
        TokenSource,

        // The buffer receives a TOKEN_TYPE value that indicates whether the token is a primary or impersonation token.
        TokenType,

        // The buffer receives a SECURITY_IMPERSONATION_LEVEL value that indicates the impersonation level of the token. If the access token is not an impersonation token, the function fails.
        TokenImpersonationLevel,

        // The buffer receives a TOKEN_STATISTICS structure that contains various token statistics.
        TokenStatistics,

        // The buffer receives a TOKEN_GROUPS structure that contains the list of restricting SIDs in a restricted token.
        TokenRestrictedSids,

        // The buffer receives a DWORD value that indicates the Terminal Services session identifier that is associated with the token.
        TokenSessionId,

        // The buffer receives a TOKEN_GROUPS_AND_PRIVILEGES structure that contains the user SID, the group accounts, the restricted SIDs, and the authentication ID associated with the token.
        TokenGroupsAndPrivileges,

        // Reserved
        TokenSessionReference,

        // The buffer receives a DWORD value that is nonzero if the token includes the SANDBOX_INERT flag.
        TokenSandBoxInert,

        // Reserved
        TokenAuditPolicy,

        // The buffer receives a TOKEN_ORIGIN value.
        TokenOrigin,

        // The buffer receives a TOKEN_ELEVATION_TYPE value that specifies the elevation level of the token.
        TokenElevationType,

        // The buffer receives a TOKEN_LINKED_TOKEN structure that contains a handle to another token that is linked to this token.
        TokenLinkedToken,

        // The buffer receives a TOKEN_ELEVATION structure that specifies whether the token is elevated.
        TokenElevation,

        // The buffer receives a DWORD value that is nonzero if the token has ever been filtered.
        TokenHasRestrictions,

        // The buffer receives a TOKEN_ACCESS_INFORMATION structure that specifies security information contained in the token.
        TokenAccessInformation,

        // The buffer receives a DWORD value that is nonzero if virtualization is allowed for the token.
        TokenVirtualizationAllowed,

        // The buffer receives a DWORD value that is nonzero if virtualization is enabled for the token
        TokenVirtualizationEnabled,

        // The buffer receives a TOKEN_MANDATORY_LABEL structure that specifies the token's integrity level.
        TokenIntegrityLevel,

        // The buffer receives a DWORD value that is nonzero if the token has the UIAccess flag set.
        TokenUIAccess,

        // The buffer receives a TOKEN_MANDATORY_POLICY structure that specifies the token's mandatory integrity policy.
        TokenMandatoryPolicy,

        // The buffer receives a TOKEN_GROUPS structure that specifies the token's logon SID.
        TokenLogonSid,

        // The buffer receives a DWORD value that is nonzero if the token is an app container token. 
        TokenIsAppContainer,

        // The buffer receives a TOKEN_GROUPS structure that contains the capabilities associated with the token.
        TokenCapabilities,

        // The buffer receives a TOKEN_APPCONTAINER_INFORMATION structure that contains the AppContainerSid associated with the token.
        TokenAppContainerSid,

        // The buffer receives a DWORD value that includes the app container number for the token.
        TokenAppContainerNumber,

        // The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the user claims associated with the token.
        TokenUserClaimAttributes,

        // The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the device claims associated with the 
        TokenDeviceClaimAttributes,

        // reserved
        TokenRestrictedUserClaimAttributes,

        // reserved
        TokenRestrictedDeviceClaimAttributes,

        // The buffer receives a TOKEN_GROUPS structure that contains the device groups that are associated with the token.
        TokenDeviceGroups,

        // The buffer receives a TOKEN_GROUPS structure that contains the restricted device groups that are associated with the token.
        TokenRestrictedDeviceGroups,

        // reserved
        TokenSecurityAttributes,

        // reserved 
        TokenIsRestricted,

        // The buffer receives The maximum value for this enumeration.
        MaxTokenInfoClass
    }
    public enum OBJECT_INFORMATION_CLASS : uint
    {
        // ObjectBasicInformation Structare
        ObjectBasicInformation,
        // Unicode_String Structare
        ObjectNameInformation,
        // ObjectTypeInformation Structare
        ObjectTypeInformation,
        // ???
        ObjectAllInformation,
        // ???
        ObjectDataInformation
    }


    [Flags]
    public enum ConnectionStates
    {
        Modem = 0x1,
        LAN = 0x2,
        Proxy = 0x4,
        RasInstalled = 0x10,
        Offline = 0x20,
        Configured = 0x40,
    }

    public enum KWAIT_REASON
    {
        Executive = 0,
        FreePage = 1,
        PageIn = 2,
        PoolAllocation = 3,
        DelayExecution = 4,
        Suspended = 5,
        UserRequest = 6,
        WrExecutive = 7,
        WrFreePage = 8,
        WrPageIn = 9,
        WrPoolAllocation = 10,
        WrDelayExecution = 11,
        WrSuspended = 12,
        WrUserRequest = 13,
        WrEventPair = 14,
        WrQueue = 15,
        WrLpcReceive = 16,
        WrLpcReply = 17,
        WrVirtualMemory = 18,
        WrPageOut = 19,
        WrRendezvous = 20,
        Spare2 = 21,
        Spare3 = 22,
        Spare4 = 23,
        Spare5 = 24,
        WrCalloutStack = 25,
        WrKernel = 26,
        WrResource = 27,
        WrPushLock = 28,
        WrMutex = 29,
        WrQuantumEnd = 30,
        WrDispatchInt = 31,
        WrPreempted = 32,
        WrYieldExecution = 33,
        WrFastMutex = 34,
        WrGuardedMutex = 35,
        WrRundown = 36,
        MaximumWaitReason = 37
    }

    public enum THREAD_STATE
    {
        StateInitialized,
        StateReady,
        StateRunning,
        StateStandby,
        StateTerminated,
        StateWait,
        StateTransition,
        StateUnknown  
    }

    public enum TCP_TABLE_CLASS
    {
        BASIC_LISTENER,
        BASIC_CONNECTIONS,
        BASIC_ALL,
        OWNER_PID_LISTENER,
        OWNER_PID_CONNECTIONS,
        OWNER_PID_ALL,
        OWNER_MODULE_LISTENER,
        OWNER_MODULE_CONNECTIONS,
        OWNER_MODULE_ALL
    }

    public enum UDP_TABLE_CLASS
    {
        UDP_TABLE_BASIC,
        UDP_TABLE_OWNER_PID,
        UDP_TABLE_OWNER_MODULE 
    }

    public enum FILE_ACTION
    {
        ADDED = 0x00000001,
        REMOVED = 0x00000002,
        MODIFIED = 0x00000003,
        RENAMED_OLD_NAME = 0x00000004,
        RENAMED_NEW_NAME = 0x00000005
    }

    public enum MIB_TCP_STATE
    {
        CLOSED = 1,
        LISTEN = 2,
        SYN_SENT = 3,
        RCVD = 4,
        ESTAB = 5,
        FIN_WAIT1 = 6,
        FIN_WAIT2 = 7,
        CLOSE_WAIT = 8,
        CLOSING = 9,
        LAST_ACK = 10,
        TIME_WAIT = 11,
        DELETE_TCB = 12
    }

    [Flags]
    public enum ThumbButtonMask
    {
        Bitmap = 0x1,
        Icon = 0x2,
        Tooltip = 0x4,
        THB_FLAGS = 0x8
    }

    public enum TaskbarProgressBarStatus
    {
        NoProgress = 0,
        Indeterminate = 0x1,
        Normal = 0x2,
        Error = 0x4,
        Paused = 0x8
    }

    public enum TCP_CONNECTION_OFFLOAD_STATE
    {
        InHost = 0,
        Offloading = 1,
        Offloaded = 2,
        Uploading = 3,
        Max = 4 
    }

    [Flags]
    public enum ACE_OBJECT_FLAGS
    {
        Null = 0x0,
        ACE_OBJECT_TYPE_PRESENT = 0x1,
        ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2
    }

    public enum SetTabPropertiesOption
    {
        None = 0x0,
        UseAppThumbnailAlways = 0x1,
        UseAppThumbnailWhenActive = 0x2,
        UseAppPeekAlways = 0x4,
        UseAppPeekWhenActive = 0x8
    }

    [Flags]
    public enum ThumbButtonOptions
    {
        Enabled = 0x00000000,
        Disabled = 0x00000001,
        DismissOnClick = 0x00000002,
        NoBackground = 0x00000004,
        Hidden = 0x00000008,
        NonInteractive = 0x00000010
    }
    public enum ACCESS_MODE
    {
        NOT_USED_ACCESS = 0,
        GRANT_ACCESS,
        SET_ACCESS,
        DENY_ACCESS,
        REVOKE_ACCESS,
        SET_AUDIT_SUCCESS,
        SET_AUDIT_FAILURE
    }

    public enum MULTIPLE_TRUSTEE_OPERATION
    {
        NO_MULTIPLE_TRUSTEE,
        TRUSTEE_IS_IMPERSONATE
    }

    public enum TRUSTEE_FORM
    {
        TRUSTEE_IS_SID,
        TRUSTEE_IS_NAME,
        TRUSTEE_BAD_FORM,
        TRUSTEE_IS_OBJECTS_AND_SID,
        TRUSTEE_IS_OBJECTS_AND_NAME
    }

    public enum TRUSTEE_TYPE
    {
        TRUSTEE_IS_UNKNOWN,
        TRUSTEE_IS_USER,
        TRUSTEE_IS_GROUP,
        TRUSTEE_IS_DOMAIN,
        TRUSTEE_IS_ALIAS,
        TRUSTEE_IS_WELL_KNOWN_GROUP,
        TRUSTEE_IS_DELETED,
        TRUSTEE_IS_INVALID,
        TRUSTEE_IS_COMPUTER
    }

    [Flags]
    public enum ExecutionState : uint
    {
        AwaymodeRequired = 0x00000040,
        Continuous = 0x80000000,
        DisplayRequired = 0x00000002,
        SystemRequired = 0x00000001
    }

    /// <summary>
    /// This enumeration lists all kinds of accessible objects that can
    /// be directly assigned to a window.
    /// </summary>
    public enum AccessibleObjectID : uint
    {
        /// <summary>
        /// The window itself.
        /// </summary>
        WINDOW = 0x00000000,

        /// <summary>
        /// The system menu.
        /// </summary>
        SYSMENU = 0xFFFFFFFF,

        /// <summary>
        /// The title bar.
        /// </summary>
        TITLEBAR = 0xFFFFFFFE,

        /// <summary>
        /// The menu.
        /// </summary>
        MENU = 0xFFFFFFFD,

        /// <summary>
        /// The client area.
        /// </summary>
        CLIENT = 0xFFFFFFFC,

        /// <summary>
        /// The vertical scroll bar.
        /// </summary>
        VSCROLL = 0xFFFFFFFB,

        /// <summary>
        /// The horizontal scroll bar.
        /// </summary>
        HSCROLL = 0xFFFFFFFA,

        /// <summary>
        /// The size grip (part in the lower right corner that
        /// makes resizing the window easier).
        /// </summary>
        SIZEGRIP = 0xFFFFFFF9,

        /// <summary>
        /// The caret (text cursor).
        /// </summary>
        CARET = 0xFFFFFFF8,

        /// <summary>
        /// The mouse cursor. There is only one mouse
        /// cursor and it is not assigned to any window.
        /// </summary>
        CURSOR = 0xFFFFFFF7,

        /// <summary>
        /// An alert window.
        /// </summary>
        ALERT = 0xFFFFFFF6,

        /// <summary>
        /// A sound this window is playing.
        /// </summary>
        SOUND = 0xFFFFFFF5
    }
    public enum WLAN_INTERFACE_STATE
    {
        wlan_interface_state_not_ready = 0,
        wlan_interface_state_connected = 1,
        wlan_interface_state_ad_hoc_network_formed = 2,
        wlan_interface_state_disconnecting = 3,
        wlan_interface_state_disconnected = 4,
        wlan_interface_state_associating = 5,
        wlan_interface_state_discovering = 6,
        wlan_interface_state_authenticating = 7 
    }
    [Flags]
    public enum QueryTypes : short
    {
        Zero = 0x0000,

        //  RFC 1034/1035
        A = 0x0001,    //  1
        Ns = 0x0002,    //  2
        Md = 0x0003,    //  3
        Mf = 0x0004,    //  4
        Cname = 0x0005,     //  5
        Soa = 0x0006,     //  6
        Mb = 0x0007,     //  7
        Mg = 0x0008,     //  8
        Mr = 0x0009,    //  9
        Null = 0x000a,     //  10
        Wks = 0x000b,     //  11
        Ptr = 0x000c,     //  12
        Hinfo = 0x000d,    //  13
        Minfo = 0x000e,    //  14
        Mx = 0x000f,    //  15
        Text = 0x0010,    //  16

        //  RFC 1183
        Rp = 0x0011,    //  17
        Afsdb = 0x0012,   //  18
        X25 = 0x0013,    //  19
        Isdn = 0x0014,    //  20
        Rt = 0x0015,    //  21

        //  RFC 1348
        Nsap = 0x0016,      //  22
        Nsapptr = 0x0017,     //  23

        //  RFC 2065    (DNS security)
        Sig = 0x0018,     //  24
        Key = 0x0019,     //  25

        //  RFC 1664    (X.400 mail)
        Px = 0x001a,     //  26

        //  RFC 1712    (Geographic position)
        Gpos = 0x001b,     //  27

        //  RFC 1886    (IPv6 Address)
        Aaaa = 0x001c,     //  28

        //  RFC 1876    (Geographic location)
        Loc = 0x001d,     //  29

        //  RFC 2065    (Secure negative response)
        Nxt = 0x001e,     //  30

        //  Patton      (Endpoint Identifier)
        Eid = 0x001f,     //  31

        //  Patton      (Nimrod Locator)
        Nimloc = 0x0020,   //  32

        //  RFC 2052    (Service location)
        Srv = 0x0021,    //  33

        //  ATM Standard something-or-another (ATM Address)
        Atma = 0x0022,     //  34

        //  RFC 2168    (Naming Authority Pointer)
        Naptr = 0x0023,    //  35

        //  RFC 2230    (Key Exchanger)
        Kx = 0x0024,     //  36

        //  RFC 2538    (CERT)
        Cert = 0x0025,    //  37

        //  A6 Draft    (A6)
        A6 = 0x0026,    //  38

        //  DNAME Draft (DNAME)
        Dname = 0x0027,     //  39

        //  Eastlake    (Kitchen Sink)
        Sink = 0x0028,  //  40

        //  RFC 2671    (EDNS OPT)
        Opt = 0x0029,     //  41

        //  RFC 4034    (DNSSEC DS)
        Ds = 0x002b,    //  43

        //  RFC 4034    (DNSSEC RRSIG)
        Rrsig = 0x002e,     //  46

        //  RFC 4034    (DNSSEC NSEC)
        Nsec = 0x002f,   //  47

        //  RFC 4034    (DNSSEC DNSKEY)
        Dnskey = 0x0030,     //  48

        //  RFC 4701    (DHCID)
        Dhcid = 0x0031,   //  49

        //
        //  IANA Reserved
        //

        Uinfo = 0x0064,     //  100
        Uid = 0x0065,     //  101
        Gid = 0x0066,    //  102
        Unspec = 0x0067,    //  103

        //
        //  Query only types (1035, 1995)
        //      - Crawford      (ADDRS)
        //      - TKEY draft    (TKEY)
        //      - TSIG draft    (TSIG)
        //      - RFC 1995      (IXFR)
        //      - RFC 1035      (AXFR up)
        //

        Addrs = 0x00f8,      //  248
        Tkey = 0x00f9,     //  249
        Tsig = 0x00fa,   //  250
        Ixfr = 0x00fb,     //  251
        Axfr = 0x00fc,     //  252
        Mailb = 0x00fd,     //  253
        Maila = 0x00fe,     //  254
        All = 0x00ff,     //  255
        Any = 0x00ff      //  255
    }

    [Flags]
    public enum QueryOptions : uint
    {
        AcceptTruncatedResponse = 1,
        BypassCache = 8,
        DontResetTtlValues = 0x100000,
        NoHostsFile = 0x40,
        NoLocalName = 0x20,
        NoNetbt = 0x80,
        NoRecursion = 4,
        NoWireQuery = 0x10,
        Reserved = unchecked((uint)-16777216),
        ReturnMessage = 0x200,
        Standard = 0,
        TreatAsFqdn = 0x1000,
        UseTcpOnly = 2,
        WireOnly = 0x100
    }
    [Flags]
    public enum QueryOptions64 : ulong
    {
        AcceptTruncatedResponse = 1,
        BypassCache = 8,
        DontResetTtlValues = 0x100000,
        NoHostsFile = 0x40,
        NoLocalName = 0x20,
        NoNetbt = 0x80,
        NoRecursion = 4,
        NoWireQuery = 0x10,
        Reserved = unchecked((uint)-16777216),
        ReturnMessage = 0x200,
        Standard = 0,
        TreatAsFqdn = 0x1000,
        UseTcpOnly = 2,
        WireOnly = 0x100
    }
    public enum HookType
    {
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14
    }
    [Flags]
    public enum ARCONTENT : uint
    {
        Autoruninf = 0x00000002,
        Audiocd = 0x00000004,
        Dvdmovie = 0x00000008,
        Blankcd = 0x00000010,
        Blankdvd = 0x00000020,
        Unknowncontent = 0x00000040,
        Autoplaypix = 0x00000080,
        Autoplaymusic = 0x00000100,
        Autoplayvideo = 0x00000200,
        Vcd = 0x00000400,
        Svcd = 0x00000800,
        Dvdaudio = 0x00001000,
        Blankbd = 0x00002000,
        Bluray = 0x00004000,
        None = 0x00000000,
        Mask = 0x00007FFE,
        PhaseUnknown = 0x00000000,
        PhasePresniff = 0x10000000,
        PhaseSniffing = 0x20000000,
        PhaseFinal = 0x40000000,
        PhaseMask = 0x70000000
    }
    [Flags]
    public enum SHGFI : uint
    {
        /// <summary>get icon</summary>
        Icon = 0x000000100,
        /// <summary>get display name</summary>
        DisplayName = 0x000000200,
        /// <summary>get type name</summary>
        TypeName = 0x000000400,
        /// <summary>get attributes</summary>
        Attributes = 0x000000800,
        /// <summary>get icon location</summary>
        IconLocatin = 0x000001000,
        /// <summary>return exe type</summary>
        ExeType = 0x000002000,
        /// <summary>get system icon index</summary>
        SysIconIndex = 0x000004000,
        /// <summary>put a link overlay on icon</summary>
        LinkOverlay = 0x000008000,
        /// <summary>show icon in selected state</summary>
        Selected = 0x000010000,
        /// <summary>get only specified attributes</summary>
        Attr_Specified = 0x000020000,
        /// <summary>get large icon</summary>
        LargeIcon = 0x000000000,
        /// <summary>get small icon</summary>
        SmallIcon = 0x000000001,
        /// <summary>get open icon</summary>
        OpenIcon = 0x000000002,
        /// <summary>get shell size icon</summary>
        ShellIconize = 0x000000004,
        /// <summary>pszPath is a pidl</summary>
        PIDL = 0x000000008,
        /// <summary>use passed dwFileAttribute</summary>
        UseFileAttributes = 0x000000010,
        /// <summary>apply the appropriate overlays</summary>
        AddOverlays = 0x000000020,
        /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
        OverlayIndex = 0x000000040,
        /// <summary>receive All option available</summary>
        All = Icon | DisplayName | TypeName |
            Attributes | IconLocatin | ExeType
    }

    [Flags]
    public enum WELL_KNOWN_SID_TYPE
    {
        WinNullSid = 0,
        WinWorldSid = 1,
        WinLocalSid = 2,
        WinCreatorOwnerSid = 3,
        WinCreatorGroupSid = 4,
        WinCreatorOwnerServerSid = 5,
        WinCreatorGroupServerSid = 6,
        WinNtAuthoritySid = 7,
        WinDialupSid = 8,
        WinNetworkSid = 9,
        WinBatchSid = 10,
        WinInteractiveSid = 11,
        WinServiceSid = 12,
        WinAnonymousSid = 13,
        WinProxySid = 14,
        WinEnterpriseControllersSid = 15,
        WinSelfSid = 16,
        WinAuthenticatedUserSid = 17,
        WinRestrictedCodeSid = 18,
        WinTerminalServerSid = 19,
        WinRemoteLogonIdSid = 20,
        WinLogonIdsSid = 21,
        WinLocalSystemSid = 22,
        WinLocalServiceSid = 23,
        WinNetworkServiceSid = 24,
        WinBuiltinDomainSid = 25,
        WinBuiltinAdministratorsSid = 26,
        WinBuiltinUsersSid = 27,
        WinBuiltinGuestsSid = 28,
        WinBuiltinPowerUsersSid = 29,
        WinBuiltinAccountOperatorsSid = 30,
        WinBuiltinSystemOperatorsSid = 31,
        WinBuiltinPrintOperatorsSid = 32,
        WinBuiltinBackupOperatorsSid = 33,
        WinBuiltinReplicatorSid = 34,
        WinBuiltinPreWindows2000CompatibleAccessSid = 35,
        WinBuiltinRemoteDesktopUsersSid = 36,
        WinBuiltinNetworkConfigurationOperatorsSid = 37,
        WinAccountAdministratorSid = 38,
        WinAccountGuestSid = 39,
        WinAccountKrbtgtSid = 40,
        WinAccountDomainAdminsSid = 41,
        WinAccountDomainUsersSid = 42,
        WinAccountDomainGuestsSid = 43,
        WinAccountComputersSid = 44,
        WinAccountControllersSid = 45,
        WinAccountCertAdminsSid = 46,
        WinAccountSchemaAdminsSid = 47,
        WinAccountEnterpriseAdminsSid = 48,
        WinAccountPolicyAdminsSid = 49,
        WinAccountRasAndIasServersSid = 50,
        WinNTLMAuthenticationSid = 51,
        WinDigestAuthenticationSid = 52,
        WinSChannelAuthenticationSid = 53,
        WinThisOrganizationSid = 54,
        WinOtherOrganizationSid = 55,
        WinBuiltinIncomingForestTrustBuildersSid = 56,
        WinBuiltinPerfMonitoringUsersSid = 57,
        WinBuiltinPerfLoggingUsersSid = 58,
        WinBuiltinAuthorizationAccessSid = 59,
        WinBuiltinTerminalServerLicenseServersSid = 60,
        WinBuiltinDCOMUsersSid = 61,
        WinBuiltinIUsersSid = 62,
        WinIUserSid = 63,
        WinBuiltinCryptoOperatorsSid = 64,
        WinUntrustedLabelSid = 65,
        WinLowLabelSid = 66,
        WinMediumLabelSid = 67,
        WinHighLabelSid = 68,
        WinSystemLabelSid = 69,
        WinWriteRestrictedCodeSid = 70,
        WinCreatorOwnerRightsSid = 71,
        WinCacheablePrincipalsGroupSid = 72,
        WinNonCacheablePrincipalsGroupSid = 73,
        WinEnterpriseReadonlyControllersSid = 74,
        WinAccountReadonlyControllersSid = 75,
        WinBuiltinEventLogReadersGroup = 76,
        WinNewEnterpriseReadonlyControllersSid = 77,
        WinBuiltinCertSvcDComAccessGroup = 78,
        WinMediumPlusLabelSid = 79,
        WinLocalLogonSid = 80,
        WinConsoleLogonSid = 81,
        WinThisOrganizationCertificateSid = 82,
        WinApplicationPackageAuthoritySid = 83,
        WinBuiltinAnyPackageSid = 84,
        WinCapabilityInternetClientSid = 85,
        WinCapabilityInternetClientServerSid = 86,
        WinCapabilityPrivateNetworkClientServerSid = 87,
        WinCapabilityPicturesLibrarySid = 88,
        WinCapabilityVideosLibrarySid = 89,
        WinCapabilityMusicLibrarySid = 90,
        WinCapabilityDocumentsLibrarySid = 91,
        WinCapabilitySharedUserCertificatesSid = 92,
        WinCapabilityDefaultWindowsCredentialsSid = 93,
        WinCapabilityRemovableStorageSid = 94
    }

    public enum SID_NAME_USE : uint
    {
        SidTypeUser = 1,
        SidTypeGroup,
        SidTypeDomain,
        SidTypeAlias,
        SidTypeWellKnownGroup,
        SidTypeDeletedAccount,
        SidTypeInvalid,
        SidTypeUnknown,
        SidTypeComputer,
        SidTypeLabel
    }

    [Flags]
    public enum SidUsage
    {
        SidTypeUser = 1,
        SidTypeGroup,
        SidTypeDomain,
        SidTypeAlias,
        SidTypeWellKnownGroup,
        SidTypeDeletedAccount,
        SidTypeInvalid
    }
    public enum CbtHookAction : int
    {
        HCBT_MOVESIZE = 0,
        HCBT_MINMAX = 1,
        HCBT_QS = 2,
        HCBT_CREATEWND = 3,
        HCBT_DESTROYWND = 4,
        HCBT_ACTIVATE = 5,
        HCBT_CLICKSKIPPED = 6,
        HCBT_KEYSKIPPED = 7,
        HCBT_SYSCOMMAND = 8,
        HCBT_SETFOCUS = 9
    }

    public enum COMPUTER_NAME_FORMAT
    {
        ComputerNameNetBIOS,
        ComputerNameDnsHostname,
        ComputerNameDnsDomain,
        ComputerNameDnsFullyQualified,
        ComputerNamePhysicalNetBIOS,
        ComputerNamePhysicalDnsHostname,
        ComputerNamePhysicalDnsDomain,
        ComputerNamePhysicalDnsFullyQualified,
        ComputerNameMax
    }

    [Flags]
    public enum MIB
    {
        OTHER = 1,
        ETHERNET = 6,
        ISO88025_TOKENRING = 9,
        PPP = 23,
        LOOPBACK = 24,
        SLIP = 28,
        IEEE80211 = 71
    }
    public enum MIB_IPROUTE_TYPE
    {
        OTHER = 1,
        INVALID = 2,
        DIRECT = 3,
        INDIRECT = 4,
    }
    [Flags]
    public enum MIB_IPADDR : ushort
    {
        PRIMARY = 0x0001,
        DYNAMIC = 0x0004,
        DISCONNECTED = 0x0008,
        DELETED = 0x0040,
        TRANSIENT = 0x0080
    }
    [Flags]
    public enum NlPrefixOrigin
    {
        //
        // These values are from iptypes.h.
        // They need to fit in a 4 bit field.
        //
        IpPrefixOriginOther = 0,
        IpPrefixOriginManual,
        IpPrefixOriginWellKnown,
        IpPrefixOriginDhcp,
        IpPrefixOriginRouterAdvertisement,
        IpPrefixOriginUnchanged = 1 << 4
    }
    [Flags]
    public enum AdaptersFlags : uint
    {
        SKIP_UNICAST = 0x0001,
        SKIP_ANYCAST = 0x0002,
        SKIP_MULTICAST = 0x0004,
        SKIP_DNS_SERVER = 0x0008,
        INCLUDE_PREFIX = 0x0010,
        SKIP_FRIENDLY_NAME = 0x0020,

        // Vista and later
        INCLUDE_WINS_INFO = 0x0040,
        INCLUDE_GATEWAYS = 0x0080,
        INCLUDE_ALL_INTERFACES = 0x0100,
        INCLUDE_ALL_COMPARTMENTS = 0x0200,
        INCLUDE_TUNNEL_BINDINGORDER = 0x0400
    }
    [Flags]
    public enum IF_OPER_STATUS
    {
        IfOperStatusUp = 1,
        IfOperStatusDown = 2,
        IfOperStatusTesting = 3,
        IfOperStatusUnknown = 4,
        IfOperStatusDormant = 5,
        IfOperStatusNotPresent = 6,
        IfOperStatusLowerLayerDown = 7
    }
    [Flags]
    public enum NET_IF_CONNECTION_TYPE
    {
        NET_IF_CONNECTION_DEDICATED = 1,
        NET_IF_CONNECTION_PASSIVE = 2,
        NET_IF_CONNECTION_DEMAND = 3,
        NET_IF_CONNECTION_MAXIMUM = 4
    }
    [Flags]
    public enum TUNNEL_TYPE
    {
        TUNNEL_TYPE_NONE = 0,
        TUNNEL_TYPE_OTHER = 1,
        TUNNEL_TYPE_DIRECT = 2,
        TUNNEL_TYPE_6TO4 = 11,
        TUNNEL_TYPE_ISATAP = 13,
        TUNNEL_TYPE_TEREDO = 14,
        TUNNEL_TYPE_IPHTTPS = 15
    }
    public enum NL_DAD_STATE
    {
        //
        // TODO: Remove the Nlds* definitions.
        //
        NldsInvalid,
        NldsTentative,
        NldsDuplicate,
        NldsDeprecated,
        NldsPreferred,

        //
        // These values are from in iptypes.h.
        //
        IpDadStateInvalid = 0,
        IpDadStateTentative,
        IpDadStateDuplicate,
        IpDadStateDeprecated,
        IpDadStatePreferred,
    }
    [Flags]
    public enum NL_SUFFIX_ORIGIN
    {
        //
        // TODO: Remove the Nlso* definitions.
        //
        NlsoOther = 0,
        NlsoManual,
        NlsoWellKnown,
        NlsoDhcp,
        NlsoLinkLayerAddress,
        NlsoRandom,

        //
        // These values are from in iptypes.h.
        // They need to fit in a 4 bit field.
        //
        IpSuffixOriginOther = 0,
        IpSuffixOriginManual,
        IpSuffixOriginWellKnown,
        IpSuffixOriginDhcp,
        IpSuffixOriginLinkLayerAddress,
        IpSuffixOriginRandom,
        IpSuffixOriginUnchanged = 1 << 4
    }
    [Flags]
    public enum IF_TYPE
    {
        IF_TYPE_OTHER = 1,   // None of the below
        IF_TYPE_REGULAR_1822 = 2,
        IF_TYPE_HDH_1822 = 3,
        IF_TYPE_DDN_X25 = 4,
        IF_TYPE_RFC877_X25 = 5,
        IF_TYPE_ETHERNET_CSMACD = 6,
        IF_TYPE_IS088023_CSMACD = 7,
        IF_TYPE_ISO88024_TOKENBUS = 8,
        IF_TYPE_ISO88025_TOKENRING = 9,
        IF_TYPE_ISO88026_MAN = 10,
        IF_TYPE_STARLAN = 11,
        IF_TYPE_PROTEON_10MBIT = 12,
        IF_TYPE_PROTEON_80MBIT = 13,
        IF_TYPE_HYPERCHANNEL = 14,
        IF_TYPE_FDDI = 15,
        IF_TYPE_LAP_B = 16,
        IF_TYPE_SDLC = 17,
        IF_TYPE_DS1 = 18,  // DS1-MIB
        IF_TYPE_E1 = 19,  // Obsolete; see DS1-MIB
        IF_TYPE_BASIC_ISDN = 20,
        IF_TYPE_PRIMARY_ISDN = 21,
        IF_TYPE_PROP_POINT2POINT_SERIAL = 22,  // proprietary serial
        IF_TYPE_PPP = 23,
        IF_TYPE_SOFTWARE_LOOPBACK = 24,
        IF_TYPE_EON = 25,  // CLNP over IP
        IF_TYPE_ETHERNET_3MBIT = 26,
        IF_TYPE_NSIP = 27,  // XNS over IP
        IF_TYPE_SLIP = 28,  // Generic Slip
        IF_TYPE_ULTRA = 29,  // ULTRA Technologies
        IF_TYPE_DS3 = 30,  // DS3-MIB
        IF_TYPE_SIP = 31,  // SMDS, coffee
        IF_TYPE_FRAMERELAY = 32,  // DTE only
        IF_TYPE_RS232 = 33,
        IF_TYPE_PARA = 34,  // Parallel port
        IF_TYPE_ARCNET = 35,
        IF_TYPE_ARCNET_PLUS = 36,
        IF_TYPE_ATM = 37,  // ATM cells
        IF_TYPE_MIO_X25 = 38,
        IF_TYPE_SONET = 39,  // SONET or SDH
        IF_TYPE_X25_PLE = 40,
        IF_TYPE_ISO88022_LLC = 41,
        IF_TYPE_LOCALTALK = 42,
        IF_TYPE_SMDS_DXI = 43,
        IF_TYPE_FRAMERELAY_SERVICE = 44,  // FRNETSERV-MIB
        IF_TYPE_V35 = 45,
        IF_TYPE_HSSI = 46,
        IF_TYPE_HIPPI = 47,
        IF_TYPE_MODEM = 48,  // Generic Modem
        IF_TYPE_AAL5 = 49,  // AAL5 over ATM
        IF_TYPE_SONET_PATH = 50,
        IF_TYPE_SONET_VT = 51,
        IF_TYPE_SMDS_ICIP = 52,  // SMDS InterCarrier Interface
        IF_TYPE_PROP_VIRTUAL = 53,  // Proprietary virtual/internal
        IF_TYPE_PROP_MULTIPLEXOR = 54,  // Proprietary multiplexing
        IF_TYPE_IEEE80212 = 55,  // 100BaseVG
        IF_TYPE_FIBRECHANNEL = 56,
        IF_TYPE_HIPPIINTERFACE = 57,
        IF_TYPE_FRAMERELAY_INTERCONNECT = 58,  // Obsolete, use 32 or 44
        IF_TYPE_AFLANE_8023 = 59,  // ATM Emulated LAN for 802.3
        IF_TYPE_AFLANE_8025 = 60,  // ATM Emulated LAN for 802.5
        IF_TYPE_CCTEMUL = 61,  // ATM Emulated circuit
        IF_TYPE_FASTETHER = 62,  // Fast Ethernet (100BaseT)
        IF_TYPE_ISDN = 63,  // ISDN and X.25
        IF_TYPE_V11 = 64,  // CCITT V.11/X.21
        IF_TYPE_V36 = 65,  // CCITT V.36
        IF_TYPE_G703_64K = 66,  // CCITT G703 at 64Kbps
        IF_TYPE_G703_2MB = 67,  // Obsolete; see DS1-MIB
        IF_TYPE_QLLC = 68,  // SNA QLLC
        IF_TYPE_FASTETHER_FX = 69,  // Fast Ethernet (100BaseFX)
        IF_TYPE_CHANNEL = 70,
        IF_TYPE_IEEE80211 = 71,  // Radio spread spectrum
        IF_TYPE_IBM370PARCHAN = 72,  // IBM System 360/370 OEMI Channel
        IF_TYPE_ESCON = 73,  // IBM Enterprise Systems Connection
        IF_TYPE_DLSW = 74,  // Data Link Switching
        IF_TYPE_ISDN_S = 75,  // ISDN S/T interface
        IF_TYPE_ISDN_U = 76,  // ISDN U interface
        IF_TYPE_LAP_D = 77,  // Link Access Protocol D
        IF_TYPE_IPSWITCH = 78,  // IP Switching Objects
        IF_TYPE_RSRB = 79,  // Remote Source Route Bridging
        IF_TYPE_ATM_LOGICAL = 80,  // ATM Logical Port
        IF_TYPE_DS0 = 81,  // Digital Signal Level 0
        IF_TYPE_DS0_BUNDLE = 82,  // Group of ds0s on the same ds1
        IF_TYPE_BSC = 83,  // Bisynchronous Protocol
        IF_TYPE_ASYNC = 84,  // Asynchronous Protocol
        IF_TYPE_CNR = 85,  // Combat Net Radio
        IF_TYPE_ISO88025R_DTR = 86,  // ISO 802.5r DTR
        IF_TYPE_EPLRS = 87,  // Ext Pos Loc Report Sys
        IF_TYPE_ARAP = 88,  // Appletalk Remote Access Protocol
        IF_TYPE_PROP_CNLS = 89,  // Proprietary Connectionless Proto
        IF_TYPE_HOSTPAD = 90,  // CCITT-ITU X.29 PAD Protocol
        IF_TYPE_TERMPAD = 91,  // CCITT-ITU X.3 PAD Facility
        IF_TYPE_FRAMERELAY_MPI = 92,  // Multiproto Interconnect over FR
        IF_TYPE_X213 = 93,  // CCITT-ITU X213
        IF_TYPE_ADSL = 94,  // Asymmetric Digital Subscrbr Loop
        IF_TYPE_RADSL = 95,  // Rate-Adapt Digital Subscrbr Loop
        IF_TYPE_SDSL = 96,  // Symmetric Digital Subscriber Loop
        IF_TYPE_VDSL = 97,  // Very H-Speed Digital Subscrb Loop
        IF_TYPE_ISO88025_CRFPRINT = 98,  // ISO 802.5 CRFP
        IF_TYPE_MYRINET = 99,  // Myricom Myrinet
        IF_TYPE_VOICE_EM = 100,  // Voice recEive and transMit
        IF_TYPE_VOICE_FXO = 101,  // Voice Foreign Exchange Office
        IF_TYPE_VOICE_FXS = 102,  // Voice Foreign Exchange Station
        IF_TYPE_VOICE_ENCAP = 103,  // Voice encapsulation
        IF_TYPE_VOICE_OVERIP = 104,  // Voice over IP encapsulation
        IF_TYPE_ATM_DXI = 105,  // ATM DXI
        IF_TYPE_ATM_FUNI = 106,  // ATM FUNI
        IF_TYPE_ATM_IMA = 107,  // ATM IMA
        IF_TYPE_PPPMULTILINKBUNDLE = 108,  // PPP Multilink Bundle
        IF_TYPE_IPOVER_CDLC = 109,  // IBM ipOverCdlc
        IF_TYPE_IPOVER_CLAW = 110,  // IBM Common Link Access to Workstn
        IF_TYPE_STACKTOSTACK = 111,  // IBM stackToStack
        IF_TYPE_VIRTUALIPADDRESS = 112,  // IBM VIPA
        IF_TYPE_MPC = 113,  // IBM multi-proto channel support
        IF_TYPE_IPOVER_ATM = 114,  // IBM ipOverAtm
        IF_TYPE_ISO88025_FIBER = 115,  // ISO 802.5j Fiber Token Ring
        IF_TYPE_TDLC = 116,  // IBM twinaxial data link control
        IF_TYPE_GIGABITETHERNET = 117,
        IF_TYPE_HDLC = 118,
        IF_TYPE_LAP_F = 119,
        IF_TYPE_V37 = 120,
        IF_TYPE_X25_MLP = 121,  // Multi-Link Protocol
        IF_TYPE_X25_HUNTGROUP = 122,  // X.25 Hunt Group
        IF_TYPE_TRANSPHDLC = 123,
        IF_TYPE_INTERLEAVE = 124,  // Interleave channel
        IF_TYPE_FAST = 125,  // Fast channel
        IF_TYPE_IP = 126,  // IP (for APPN HPR in IP networks)
        IF_TYPE_DOCSCABLE_MACLAYER = 127,  // CATV Mac Layer
        IF_TYPE_DOCSCABLE_DOWNSTREAM = 128,  // CATV Downstream interface
        IF_TYPE_DOCSCABLE_UPSTREAM = 129,  // CATV Upstream interface
        IF_TYPE_A12MPPSWITCH = 130,  // Avalon Parallel Processor
        IF_TYPE_TUNNEL = 131,  // Encapsulation interface
        IF_TYPE_COFFEE = 132,  // Coffee pot
        IF_TYPE_CES = 133,  // Circuit Emulation Service
        IF_TYPE_ATM_SUBINTERFACE = 134,  // ATM Sub Interface
        IF_TYPE_L2_VLAN = 135,  // Layer 2 Virtual LAN using 802.1Q
        IF_TYPE_L3_IPVLAN = 136,  // Layer 3 Virtual LAN using IP
        IF_TYPE_L3_IPXVLAN = 137,  // Layer 3 Virtual LAN using IPX
        IF_TYPE_DIGITALPOWERLINE = 138,  // IP over Power Lines
        IF_TYPE_MEDIAMAILOVERIP = 139,  // Multimedia Mail over IP
        IF_TYPE_DTM = 140,  // Dynamic syncronous Transfer Mode
        IF_TYPE_DCN = 141,  // Data Communications Network
        IF_TYPE_IPFORWARD = 142,  // IP Forwarding Interface
        IF_TYPE_MSDSL = 143,  // Multi-rate Symmetric DSL
        IF_TYPE_IEEE1394 = 144,  // IEEE1394 High Perf Serial Bus
        IF_TYPE_RECEIVE_ONLY = 145 // TV adapter type
    }
    [Flags]
    public enum NL_ROUTER_DISCOVERY_BEHAVIOR
    {
        RouterDiscoveryDisabled = 0,
        RouterDiscoveryEnabled,
        RouterDiscoveryDhcp,
        RouterDiscoveryUnchanged = -1
    }
    [Flags]
    public enum NL_LINK_LOCAL_ADDRESS_BEHAVIOR
    {
        LinkLocalAlwaysOff = 0,     // Never use link locals.
        LinkLocalDelayed,           // Use link locals only if no other addresses. 
        // (default for IPv4).
        // Legacy mapping: IPAutoconfigurationEnabled.
        LinkLocalAlwaysOn,          // Always use link locals (default for IPv6). 
        LinkLocalUnchanged = -1
    }

    [Flags]
    public enum FontPitchAndFamily : byte
    {
        DEFAULT_PITCH = 0,
        FIXED_PITCH = 1,
        VARIABLE_PITCH = 2,
        FF_DONTCARE = (0 << 4),
        FF_ROMAN = (1 << 4),
        FF_SWISS = (2 << 4),
        FF_MODERN = (3 << 4),
        FF_SCRIPT = (4 << 4),
        FF_DECORATIVE = (5 << 4),
    }

    [Flags]
    public enum ConsoleDesiredAccess : uint
    {
        GENERIC_READ = 0x80000000,
        GENERIC_WRITE = 0x40000000
    }
    [Flags]
    public enum ConsoleFileShare : uint
    {
        FILE_SHARE_READ = 0x00000001,
        FILE_SHARE_WRITE = 0x00000002
    }
    [Flags]
    public enum ConsoleSelectionFlags
    {
        CONSOLE_MOUSE_DOWN = 0x0008,
        CONSOLE_MOUSE_SELECTION = 0x0004,
        CONSOLE_NO_SELECTION = 0x0000,
        CONSOLE_SELECTION_IN_PROGRESS = 0x0001,
        CONSOLE_SELECTION_NOT_EMPTY = 0x0002
    }
    public enum Attribute : short
    {
        FOREGROUND_BLUE = 0x01,
        FOREGROUND_GREEN = 0x02,
        FOREGROUND_RED = 0x04,
        FOREGROUND_INTENSIFY = 0x08,
        BACKGROUND_BLUE = 0x10,
        BACKGROUND_GREEN = 0x20,
        BACKGROUND_INTENSIFY = 0x80,

        COMMON_LVB_LEADING_BYTE = 0x0100, // Leading Byte of DBCS
        COMMON_LVB_TRAILING_BYTE = 0x0200,// Trailing Byte of DBCS
        COMMON_LVB_GRID_HORIZONTAL = 0x0400,// DBCS: Grid attribute: top horizontal.
        COMMON_LVB_GRID_LVERTICAL = 0x0800,// DBCS: Grid attribute: left vertical.
        COMMON_LVB_GRID_RVERTICAL = 0x1000, // DBCS: Grid attribute: right vertical.
        COMMON_LVB_REVERSE_VIDEO = 0x4000, // DBCS: Reverse fore/back ground attribute.
        COMMON_LVB_UNDERSCORE = unchecked((short)0x8000),// DBCS: Underscore.
        COMMON_LVB_SBCSDBCS = 0x0300,// SBCS or DBCS flag.

        Black = 0,
        Blue = FOREGROUND_BLUE,
        Green = FOREGROUND_GREEN,
        SkyBlue = FOREGROUND_BLUE + FOREGROUND_GREEN,
        Red = FOREGROUND_RED,
        Purple = FOREGROUND_BLUE + FOREGROUND_RED,
        Brown = FOREGROUND_GREEN + FOREGROUND_RED,
        White = FOREGROUND_BLUE + FOREGROUND_GREEN +
        FOREGROUND_RED,
        Gray = FOREGROUND_INTENSIFY,
        BlueForte = FOREGROUND_BLUE + FOREGROUND_INTENSIFY,
        GreenForte = FOREGROUND_GREEN + FOREGROUND_INTENSIFY,
        SkyBlueForte = FOREGROUND_BLUE + FOREGROUND_GREEN +
        FOREGROUND_INTENSIFY,
        RedForte = FOREGROUND_RED + FOREGROUND_INTENSIFY,
        PurpleForte = FOREGROUND_BLUE + FOREGROUND_RED +
            FOREGROUND_INTENSIFY,
        Yellow = FOREGROUND_GREEN + FOREGROUND_RED +
            FOREGROUND_INTENSIFY,
        WhiteForte = FOREGROUND_BLUE + FOREGROUND_GREEN +
            FOREGROUND_RED + FOREGROUND_INTENSIFY
    }
    public enum StdHandle : uint
    {
        STD_INPUT_HANDLE = 0xfffffff6,
        STD_OUTPUT_HANDLE = 0xfffffff5,
        STD_ERROR_HANDLE = 0xfffffff4
    }
    public enum ConsoleMode : uint
    {
        CONSOLE_FULLSCREEN_MODE = 1,
        CONSOLE_WINDOWED_MODE = 2
    }

    public enum eventType : short
    {
        FOCUS_EVENT = 0x0010,
        KEY_EVENT = 0x0001,
        MENU_EVENT = 0x0008,
        MOUSE_EVENT = 0x0002,
        WINDOW_BUFFER_SIZE_EVENT = 0x0004
    }
    [Flags]
    public enum ControlKeyState : uint
    {
        RIGHT_ALT_PRESSED     = 0x0001,     // the right alt key is pressed.
        LEFT_ALT_PRESSED      = 0x0002,     // the left alt key is pressed.
        RIGHT_CTRL_PRESSED    = 0x0004,     // the right ctrl key is pressed.
        LEFT_CTRL_PRESSED     = 0x0008,     // the left ctrl key is pressed.
        SHIFT_PRESSED         = 0x0010,     // the shift key is pressed.
        NUMLOCK_ON            = 0x0020,     // the numlock light is on.
        SCROLLLOCK_ON         = 0x0040,     // the scrolllock light is on.
        CAPSLOCK_ON           = 0x0080,     // the capslock light is on.
        ENHANCED_KEY          = 0x0100,     // the key is enhanced.
        NLS_DBCSCHAR          = 0x00010000, // DBCS for JPN: SBCS/DBCS mode.
        NLS_ALPHANUMERIC      = 0x00000000, // DBCS for JPN: Alphanumeric mode.
        NLS_KATAKANA          = 0x00020000, // DBCS for JPN: Katakana mode.
        NLS_HIRAGANA          = 0x00040000, // DBCS for JPN: Hiragana mode.
        NLS_ROMAN             = 0x00400000, // DBCS for JPN: Roman/Noroman mode.
        NLS_IME_CONVERSION    = 0x00800000, // DBCS for JPN: IME conversion.
        NLS_IME_DISABLE       = 0x20000000  // DBCS for JPN: IME enable/disable.
    }

    [Flags]
    public enum ButtonState : uint
    {
        FROM_LEFT_1ST_BUTTON_PRESSED = 0x1,
        FROM_LEFT_2ND_BUTTON_PRESSED = 0x4,
        FROM_LEFT_3RD_BUTTON_PRESSED = 0x8,
        FROM_LEFT_4TH_BUTTON_PRESSED = 0x10,
        RIGHTMOST_BUTTON_PRESSED = 0x2
    }
    [Flags]
    public enum EventFlags
    {
        DOUBLE_CLICK = 0x0002,
        MOUSE_HWHEELED = 0x0008,
        MOUSE_MOVED = 0x0001,
        MOUSE_WHEELED = 0x0004
    }
    [Flags]
    public enum ConsoleModes
    {
        ENABLE_ECHO_INPUT = 0x0004,
        ENABLE_EXTENDED_FLAGS = 0x0080,
        ENABLE_INSERT_MODE = 0x0020,
        ENABLE_LINE_INPUT = 0x0002,
        ENABLE_MOUSE_INPUT = 0x0010,
        ENABLE_PROCESSED_INPUT = 0x0001,
        ENABLE_QUICK_EDIT_MODE = 0x0040,
        ENABLE_WINDOW_INPUT = 0x0008
    }
    public enum CtrlType : uint
    {
        CTRL_C_EVENT = 0,
        CTRL_BREAK_EVENT = 1,
        CTRL_CLOSE_EVENT = 2,
        CTRL_LOGOFF_EVENT = 5,
        CTRL_SHUTDOWN_EVENT = 6
    }

    [Flags]
    public enum AnimateWindowFlags : uint
    {
        AW_HOR_POSITIVE = 0x00000001,
        AW_HOR_NEGATIVE = 0x00000002,
        AW_VER_POSITIVE = 0x00000004,
        AW_VER_NEGATIVE = 0x00000008,
        AW_CENTER = 0x00000010,
        AW_HIDE = 0x00010000,
        AW_ACTIVATE = 0x00020000,
        AW_SLIDE = 0x00040000,
        AW_BLEND = 0x00080000
    }

    public enum MachineType : ushort
    {
        Native = 0,
        I386 = 0x014c,
        Itanium = 0x0200,
        x64 = 0x8664
    }
    public enum MagicType : ushort
    {
        IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b,
        IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b
    }
    public enum SubSystemType : ushort
    {
        IMAGE_SUBSYSTEM_UNKNOWN = 0,
        IMAGE_SUBSYSTEM_NATIVE = 1,
        IMAGE_SUBSYSTEM_WINDOWS_GUI = 2,
        IMAGE_SUBSYSTEM_WINDOWS_CUI = 3,
        IMAGE_SUBSYSTEM_POSIX_CUI = 7,
        IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9,
        IMAGE_SUBSYSTEM_EFI_APPLICATION = 10,
        IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11,
        IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12,
        IMAGE_SUBSYSTEM_EFI_ROM = 13,
        IMAGE_SUBSYSTEM_XBOX = 14

    }
    public enum DllCharacteristicsType : ushort
    {
        RES_0 = 0x0001,
        RES_1 = 0x0002,
        RES_2 = 0x0004,
        RES_3 = 0x0008,
        IMAGE_DLL_CHARACTERISTICS_DYNAMIC_BASE = 0x0040,
        IMAGE_DLL_CHARACTERISTICS_FORCE_INTEGRITY = 0x0080,
        IMAGE_DLL_CHARACTERISTICS_NX_COMPAT = 0x0100,
        IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,
        IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,
        IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,
        RES_4 = 0x1000,
        IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,
        IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000
    }
    [Flags]
    public enum DataSectionFlags : uint
    {
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TypeReg = 0x00000000,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TypeDsect = 0x00000001,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TypeNoLoad = 0x00000002,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TypeGroup = 0x00000004,
        /// <summary>
        /// The section should not be padded to the next boundary. This flag is obsolete and is replaced by IMAGE_SCN_ALIGN_1BYTES. This is valid only for object files.
        /// </summary>
        TypeNoPadded = 0x00000008,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TypeCopy = 0x00000010,
        /// <summary>
        /// The section contains executable code.
        /// </summary>
        ContentCode = 0x00000020,
        /// <summary>
        /// The section contains initialized data.
        /// </summary>
        ContentInitializedData = 0x00000040,
        /// <summary>
        /// The section contains uninitialized data.
        /// </summary>
        ContentUninitializedData = 0x00000080,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        LinkOther = 0x00000100,
        /// <summary>
        /// The section contains comments or other information. The .drectve section has this type. This is valid for object files only.
        /// </summary>
        LinkInfo = 0x00000200,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        TypeOver = 0x00000400,
        /// <summary>
        /// The section will not become part of the image. This is valid only for object files.
        /// </summary>
        LinkRemove = 0x00000800,
        /// <summary>
        /// The section contains COMDAT data. For more information, see section 5.5.6, COMDAT Sections (Object Only). This is valid only for object files.
        /// </summary>
        LinkComDat = 0x00001000,
        /// <summary>
        /// Reset speculative exceptions handling bits in the TLB entries for this section.
        /// </summary>
        NoDeferSpecExceptions = 0x00004000,
        /// <summary>
        /// The section contains data referenced through the global pointer (GP).
        /// </summary>
        RelativeGP = 0x00008000,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        MemPurgeable = 0x00020000,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        Memory16Bit = 0x00020000,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        MemoryLocked = 0x00040000,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        MemoryPreload = 0x00080000,
        /// <summary>
        /// Align data on a 1-byte boundary. Valid only for object files.
        /// </summary>
        Align1Bytes = 0x00100000,
        /// <summary>
        /// Align data on a 2-byte boundary. Valid only for object files.
        /// </summary>
        Align2Bytes = 0x00200000,
        /// <summary>
        /// Align data on a 4-byte boundary. Valid only for object files.
        /// </summary>
        Align4Bytes = 0x00300000,
        /// <summary>
        /// Align data on an 8-byte boundary. Valid only for object files.
        /// </summary>
        Align8Bytes = 0x00400000,
        /// <summary>
        /// Align data on a 16-byte boundary. Valid only for object files.
        /// </summary>
        Align16Bytes = 0x00500000,
        /// <summary>
        /// Align data on a 32-byte boundary. Valid only for object files.
        /// </summary>
        Align32Bytes = 0x00600000,
        /// <summary>
        /// Align data on a 64-byte boundary. Valid only for object files.
        /// </summary>
        Align64Bytes = 0x00700000,
        /// <summary>
        /// Align data on a 128-byte boundary. Valid only for object files.
        /// </summary>
        Align128Bytes = 0x00800000,
        /// <summary>
        /// Align data on a 256-byte boundary. Valid only for object files.
        /// </summary>
        Align256Bytes = 0x00900000,
        /// <summary>
        /// Align data on a 512-byte boundary. Valid only for object files.
        /// </summary>
        Align512Bytes = 0x00A00000,
        /// <summary>
        /// Align data on a 1024-byte boundary. Valid only for object files.
        /// </summary>
        Align1024Bytes = 0x00B00000,
        /// <summary>
        /// Align data on a 2048-byte boundary. Valid only for object files.
        /// </summary>
        Align2048Bytes = 0x00C00000,
        /// <summary>
        /// Align data on a 4096-byte boundary. Valid only for object files.
        /// </summary>
        Align4096Bytes = 0x00D00000,
        /// <summary>
        /// Align data on an 8192-byte boundary. Valid only for object files.
        /// </summary>
        Align8192Bytes = 0x00E00000,
        /// <summary>
        /// The section contains extended relocations.
        /// </summary>
        LinkExtendedRelocationOverflow = 0x01000000,
        /// <summary>
        /// The section can be discarded as needed.
        /// </summary>
        MemoryDiscardable = 0x02000000,
        /// <summary>
        /// The section cannot be cached.
        /// </summary>
        MemoryNotCached = 0x04000000,
        /// <summary>
        /// The section is not pageable.
        /// </summary>
        MemoryNotPaged = 0x08000000,
        /// <summary>
        /// The section can be shared in memory.
        /// </summary>
        MemoryShared = 0x10000000,
        /// <summary>
        /// The section can be executed as code.
        /// </summary>
        MemoryExecute = 0x20000000,
        /// <summary>
        /// The section can be read.
        /// </summary>
        MemoryRead = 0x40000000,
        /// <summary>
        /// The section can be written to.
        /// </summary>
        MemoryWrite = 0x80000000
    }

    public enum ShutDownMode
    {
        Both,
        Send,
        Receive
    }

    public enum MsgFlags : int
    {
        /// <summary>
        /// Processes Out Of Band (OOB) data.
        /// </summary>
        MSG_OOB = 0x1,

        /// <summary>
        /// Peeks at the incoming data. The data is copied into the buffer,
        /// but is not removed from the input queue.
        /// </summary>
        MSG_PEEK = 0x2,

        /// <summary>
        /// send without using routing tables
        /// </summary>
        MSG_DONTROUTE = 0x4,

        /// <summary>
        /// The receive request will complete only when one of the following events occurs:
        /// </summary>
        MSG_WAITALL = 0x8,

        /// <summary>
        /// partial send or recv for message xport
        /// </summary>
        MSG_PARTIAL = 0x8000,

        /// <summary>
        /// ???? ... ???
        /// </summary>
        MSG_DONTWAIT = 0x1000000
    }
    public enum AI : int
    {
        AI_NOTHING = 0x00000000,
        AI_PASSIVE = 0x00000001,  // Socket address will be used in bind() call
        AI_CANONNAME = 0x00000002, // Return canonical name in first ai_canonname
        AI_NUMERICHOST = 0x00000004,  // Nodename must be a numeric address string
        AI_NUMERICSERV = 0x00000008, // Servicename must be a numeric port number

        AI_ALL = 0x00000100,  // Query both IP6 and IP4 with AI_V4MAPPED
        AI_ADDRCONFIG = 0x00000400,  // Resolution only if global address configured
        AI_V4MAPPED = 0x00000800,  // On v6 failure, query v4 and convert to V4MAPPED format

        AI_NON_AUTHORITATIVE = 0x00004000,  // LUP_NON_AUTHORITATIVE
        AI_SECURE = 0x00008000,  // LUP_SECURE
        AI_RETURN_PREFERRED_NAMES = 0x00010000,  // LUP_RETURN_PREFERRED_NAMES

        AI_FQDN = 0x00020000,  // Return the FQDN in ai_canonname
        AI_FILESERVER = 0x00040000  // Resolving fileserver name resolution 
    }
    public enum NI : int
    {
        NI_DGRAM = 0x0001,
        NI_NAMEREQD = 0x0002,
        NI_NOFQDN = 0x0004,
        NI_NUMERICHOST = 0x0008,
        NI_NUMERICSCOPE = 0x0010,
        NI_NUMERICSERV = 0x0020
    }
    public enum SocketType : short
    {
        /// <summary>
        /// stream socket 
        /// </summary>
        STREAM = 1,

        /// <summary>
        /// datagram socket 
        /// </summary>
        DGRAM = 2,

        /// <summary>
        /// raw-protocol interface 
        /// </summary>
        RAW = 3,

        /// <summary>
        /// reliably-delivered message 
        /// </summary>
        RDM = 4,

        /// <summary>
        /// sequenced packet stream 
        /// </summary>
        SEQPACKET = 5
    }
    public enum SocketProtocol : short
    {
        //dummy for IP  
        IP = 0,
        //control message protocol  
        ICMP = 1,
        //internet group management protocol  
        IGMP = 2,
        //gateway^2 (deprecated)  
        GGP = 3,
        //tcp  
        TCP = 6,
        //pup  
        PUP = 12,
        //user datagram protocol  
        UDP = 17,
        //xns idp  
        IDP = 22,
        //IPv6  
        IPV6 = 41,
        //UNOFFICIAL net disk proto  
        ND = 77,

        ICLFXBM = 78,
        //raw IP packet  
        RAW = 255,


        BTHPROTO_RFCOMM = 0x0003,
        BTHPROTO_L2CAP = 0x0100,

        SOL_RFCOMM = BTHPROTO_RFCOMM,
        SOL_L2CAP = BTHPROTO_L2CAP,
        SOL_SDP = 0x0101,

        MAX = 256
    }
    public enum AddressFamilies : short
    {
        /// <summary>
        /// Unspecified [value = 0].
        /// </summary>
        UNSPEC = 0,
        /// <summary>
        /// Local to host (pipes, portals) [value = 1].
        /// </summary>
        UNIX = 1,
        /// <summary>
        /// Internetwork: UDP, TCP, etc [value = 2].
        /// </summary>
        INET = 2,
        /// <summary>
        /// Arpanet imp addresses [value = 3].
        /// </summary>
        IMPLINK = 3,
        /// <summary>
        /// Pup protocols: e.g. BSP [value = 4].
        /// </summary>
        PUP = 4,
        /// <summary>
        /// Mit CHAOS protocols [value = 5].
        /// </summary>
        CHAOS = 5,
        /// <summary>
        /// XEROX NS protocols [value = 6].
        /// </summary>
        NS = 6,
        /// <summary>
        /// IPX protocols: IPX, SPX, etc [value = 6].
        /// </summary>
        IPX = 6,
        /// <summary>
        /// ISO protocols [value = 7].
        /// </summary>
        ISO = 7,
        /// <summary>
        /// OSI is ISO [value = 7].
        /// </summary>
        OSI = 7,
        /// <summary>
        /// european computer manufacturers [value = 8].
        /// </summary>
        ECMA = 8,
        /// <summary>
        /// datakit protocols [value = 9].
        /// </summary>
        DATAKIT = 9,
        /// <summary>
        /// CCITT protocols, X.25 etc [value = 10].
        /// </summary>
        CCITT = 10,
        /// <summary>
        /// IBM SNA [value = 11].
        /// </summary>
        SNA = 11,
        /// <summary>
        /// DECnet [value = 12].
        /// </summary>
        DECnet = 12,
        /// <summary>
        /// Direct data link interface [value = 13].
        /// </summary>
        DLI = 13,
        /// <summary>
        /// LAT [value = 14].
        /// </summary>
        LAT = 14,
        /// <summary>
        /// NSC Hyperchannel [value = 15].
        /// </summary>
        HYLINK = 15,
        /// <summary>
        /// AppleTalk [value = 16].
        /// </summary>
        APPLETALK = 16,
        /// <summary>
        /// NetBios-style addresses [value = 17].
        /// </summary>
        NETBIOS = 17,
        /// <summary>
        /// VoiceView [value = 18].
        /// </summary>
        VOICEVIEW = 18,
        /// <summary>
        /// Protocols from Firefox [value = 19].
        /// </summary>
        FIREFOX = 19,
        /// <summary>
        /// Somebody is using this! [value = 20].
        /// </summary>
        UNKNOWN1 = 20,
        /// <summary>
        /// Banyan [value = 21].
        /// </summary>
        BAN = 21,
        /// <summary>
        /// Native ATM Services [value = 22].
        /// </summary>
        ATM = 22,
        /// <summary>
        /// Internetwork Version 6 [value = 23].
        /// </summary>
        INET6 = 23,
        /// <summary>
        /// Microsoft Wolfpack [value = 24].
        /// </summary>
        CLUSTER = 24,
        /// <summary>
        /// IEEE 1284.4 WG AF [value = 25].
        /// </summary>
        IEEE = 25,
        /// <summary>
        /// IrDA [value = 26].
        /// </summary>
        IRDA = 26,
        /// <summary>
        /// Network Designers OSI &amp; gateway enabled protocols [value = 28].
        /// </summary>
        NETDES = 28,
        /// <summary>
        /// [value = 29].
        /// </summary>
        TCNPROCESS = 29,
        /// <summary>
        /// [value = 30].
        /// </summary>
        TCNMESSAGE = 30,
        /// <summary>
        /// [value = 31].
        /// </summary>
        ICLFXBM = 31,
        /// <summary>
        /// Bluetooth
        /// </summary>
        BTH  = 32
    }
    public enum AddressFamilyInt : uint
    {
        /// <summary>
        /// Unspecified [value = 0].
        /// </summary>
        UNSPEC = 0,
        /// <summary>
        /// Local to host (pipes, portals) [value = 1].
        /// </summary>
        UNIX = 1,
        /// <summary>
        /// Internetwork: UDP, TCP, etc [value = 2].
        /// </summary>
        INET = 2,
        /// <summary>
        /// Arpanet imp addresses [value = 3].
        /// </summary>
        IMPLINK = 3,
        /// <summary>
        /// Pup protocols: e.g. BSP [value = 4].
        /// </summary>
        PUP = 4,
        /// <summary>
        /// Mit CHAOS protocols [value = 5].
        /// </summary>
        CHAOS = 5,
        /// <summary>
        /// XEROX NS protocols [value = 6].
        /// </summary>
        NS = 6,
        /// <summary>
        /// IPX protocols: IPX, SPX, etc [value = 6].
        /// </summary>
        IPX = 6,
        /// <summary>
        /// ISO protocols [value = 7].
        /// </summary>
        ISO = 7,
        /// <summary>
        /// OSI is ISO [value = 7].
        /// </summary>
        OSI = 7,
        /// <summary>
        /// european computer manufacturers [value = 8].
        /// </summary>
        ECMA = 8,
        /// <summary>
        /// datakit protocols [value = 9].
        /// </summary>
        DATAKIT = 9,
        /// <summary>
        /// CCITT protocols, X.25 etc [value = 10].
        /// </summary>
        CCITT = 10,
        /// <summary>
        /// IBM SNA [value = 11].
        /// </summary>
        SNA = 11,
        /// <summary>
        /// DECnet [value = 12].
        /// </summary>
        DECnet = 12,
        /// <summary>
        /// Direct data link interface [value = 13].
        /// </summary>
        DLI = 13,
        /// <summary>
        /// LAT [value = 14].
        /// </summary>
        LAT = 14,
        /// <summary>
        /// NSC Hyperchannel [value = 15].
        /// </summary>
        HYLINK = 15,
        /// <summary>
        /// AppleTalk [value = 16].
        /// </summary>
        APPLETALK = 16,
        /// <summary>
        /// NetBios-style addresses [value = 17].
        /// </summary>
        NETBIOS = 17,
        /// <summary>
        /// VoiceView [value = 18].
        /// </summary>
        VOICEVIEW = 18,
        /// <summary>
        /// Protocols from Firefox [value = 19].
        /// </summary>
        FIREFOX = 19,
        /// <summary>
        /// Somebody is using this! [value = 20].
        /// </summary>
        UNKNOWN1 = 20,
        /// <summary>
        /// Banyan [value = 21].
        /// </summary>
        BAN = 21,
        /// <summary>
        /// Native ATM Services [value = 22].
        /// </summary>
        ATM = 22,
        /// <summary>
        /// Internetwork Version 6 [value = 23].
        /// </summary>
        INET6 = 23,
        /// <summary>
        /// Microsoft Wolfpack [value = 24].
        /// </summary>
        CLUSTER = 24,
        /// <summary>
        /// IEEE 1284.4 WG AF [value = 25].
        /// </summary>
        IEEE = 25,
        /// <summary>
        /// IrDA [value = 26].
        /// </summary>
        IRDA = 26,
        /// <summary>
        /// Network Designers OSI &amp; gateway enabled protocols [value = 28].
        /// </summary>
        NETDES = 28,
        /// <summary>
        /// [value = 29].
        /// </summary>
        TCNPROCESS = 29,
        /// <summary>
        /// [value = 30].
        /// </summary>
        TCNMESSAGE = 30,
        /// <summary>
        /// [value = 31].
        /// </summary>
        ICLFXBM = 31,
        /// <summary>
        /// Bluetooth
        /// </summary>
        BTH = 32
    }
    public enum SocketTypeInt
    {
        /// <summary>
        /// stream socket 
        /// </summary>
        STREAM = 1,

        /// <summary>
        /// datagram socket 
        /// </summary>
        DGRAM = 2,

        /// <summary>
        /// raw-protocol interface 
        /// </summary>
        RAW = 3,

        /// <summary>
        /// reliably-delivered message 
        /// </summary>
        RDM = 4,

        /// <summary>
        /// sequenced packet stream 
        /// </summary>
        SEQPACKET = 5
    }
    public enum SocketProtocolInt
    {
        //dummy for IP  
        IP = 0,
        //control message protocol  
        ICMP = 1,
        //internet group management protocol  
        IGMP = 2,
        //gateway^2 (deprecated)  
        GGP = 3,
        //tcp  
        TCP = 6,
        //pup  
        PUP = 12,
        //user datagram protocol  
        UDP = 17,
        //xns idp  
        IDP = 22,
        //IPv6  
        IPV6 = 41,
        //UNOFFICIAL net disk proto  
        ND = 77,

        ICLFXBM = 78,
        //raw IP packet  
        RAW = 255,


        BTHPROTO_RFCOMM = 0x0003,
        BTHPROTO_L2CAP = 0x0100,

        SOL_RFCOMM = BTHPROTO_RFCOMM,
        SOL_L2CAP = BTHPROTO_L2CAP,
        SOL_SDP = 0x0101,
        MAX = 256
    }

    public enum OptionFlagsPerSocket : short
    {
        // turn on debugging info recording  
        SO_DEBUG = 0x0001,
        // socket has had listen()  
        SO_ACCEPTCONN = 0x0002,
        // allow local address reuse  
        SO_REUSEADDR = 0x0004,
        // keep connections alive  
        SO_KEEPALIVE = 0x0008,
        // just use interface addresses  
        SO_DONTROUTE = 0x0010,
        // permit sending of broadcast msgs  
        SO_BROADCAST = 0x0020,
        // bypass hardware when possible  
        SO_USELOOPBACK = 0x0040,
        // linger on close if data present  
        SO_LINGER = 0x0080,
        // leave received OOB data in line  
        SO_OOBINLINE = 0x0100,
        SO_DONTLINGER = (int)(~SO_LINGER),
        // disallow local address reuse 
        SO_EXCLUSIVEADDRUSE = ((int)(~SO_REUSEADDR)),

        ///*
        // * Additional options.
        // */
        // send buffer size  
        SO_SNDBUF = 0x1001,
        // receive buffer size  
        SO_RCVBUF = 0x1002,
        // send low-water mark  
        SO_SNDLOWAT = 0x1003,
        // receive low-water mark  
        SO_RCVLOWAT = 0x1004,
        // send timeout  
        SO_SNDTIMEO = 0x1005,
        // receive timeout  
        SO_RCVTIMEO = 0x1006,
        // get error status and clear  
        SO_ERROR = 0x1007,
        // get socket type  
        SO_TYPE = 0x1008,

        ///*
        // * WinSock 2 extension -- new options
        // */
        // ID of a socket group  
        SO_GROUP_ID = 0x2001,
        // the relative priority within a group 
        SO_GROUP_PRIORITY = 0x2002,
        // maximum message size  
        SO_MAX_MSG_SIZE = 0x2003,
        // WSAPROTOCOL_INFOA structure  
        SO_PROTOCOL_INFOA = 0x2004,
        // WSAPROTOCOL_INFOW structure  
        SO_PROTOCOL_INFOW = 0x2005,
        // configuration info for service provider  
        PVD_CONFIG = 0x3001,
        // enable true conditional accept: connection is not ack-ed to the other side until conditional function returns CF_ACCEPT  
        SO_CONDITIONAL_ACCEPT = 0x3002
    }
    public enum ShutDownFlags : int
    {
        SD_RECEIVE = 0,
        SD_SEND = 1,
        SD_BOTH = 2
    }
    /// <summary>
    /// Socket Options and IOCTLs
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms740526(v=vs.85).aspx
    /// </summary>
    public enum SocketOptionName
    {
        /// <summary>
        /// BOOL
        /// </summary>
        AcceptConnection = 2,

        AddMembership = 12,

        AddSourceMembership = 15,

        BlockSource = 0x11,
        /// <summary>
        /// BOOL
        /// </summary>
        Broadcast = 0x20,

        BsdUrgent = 2,

        ChecksumCoverage = 20,
        /// <summary>
        /// BOOL
        /// </summary>
        Debug = 1,

        DontFragment = 14,
        /// <summary>
        /// BOOL
        /// </summary>
        DontLinger = -129,
        /// <summary>
        /// BOOL
        /// </summary>
        DontRoute = 0x10,

        DropMembership = 13,

        DropSourceMembership = 0x10,
        /// <summary>
        /// int 
        /// </summary>
        Error = 0x1007,

        ExclusiveAddressUse = -5,

        Expedited = 2,

        HeaderIncluded = 2,

        HopLimit = 0x15,

        IPOptions = 1,

        IPProtectionLevel = 0x17,

        IpTimeToLive = 4,

        IPv6Only = 0x1b,
        /// <summary>
        /// BOOL
        /// </summary>
        KeepAlive = 8,
        /// <summary>
        /// IntPtr
        /// </summary>
        Linger = 0x80,

        MaxConnections = 0x7fffffff,

        MulticastInterface = 9,

        MulticastLoopback = 11,

        MulticastTimeToLive = 10,

        NoChecksum = 1,
        /// <summary>
        /// BOOL
        /// </summary>
        NoDelay = 1,

        OutOfBandInline = 0x100,

        PacketInformation = 0x13,
        /// <summary>
        /// int
        /// </summary>
        ReceiveBuffer = 0x1002,

        ReceiveLowWater = 0x1004,

        ReceiveTimeout = 0x1006,
        /// <summary>
        /// BOOL
        /// </summary>
        ReuseAddress = 4,

        SendBuffer = 0x1001,

        SendLowWater = 0x1003,

        SendTimeout = 0x1005,
        /// <summary>
        /// int
        /// </summary>
        Type = 0x1008,

        TypeOfService = 3,

        UnblockSource = 0x12,

        UpdateAcceptContext = 0x700b,

        UpdateConnectContext = 0x7010,

        UseLoopback = 0x40
    }
    public enum SocketOptionLevel
    {
        IP = 0,
        IPv6 = 0x29,
        Socket = 0xffff,
        Tcp = 6,
        Udp = 0x11
    }
    public enum Command : int
    {
        /// <summary>
        /// Use to determine the amount of data pending in the network's input buffer that can be read from socket s. 
        /// </summary>
        FIONREAD = 1074030207,

        /// <summary>
        /// The *argp parameter is a pointer to an unsigned long value. 
        /// Set *argp to a nonzero value if the nonblocking mode should be enabled, 
        /// or zero if the nonblocking mode should be disabled.
        /// </summary>
        Fionbio = -2147195266,

        Fioasync = 2147195267,
        Siocshiwat = 2147192064,
        Siocghiwat = 1074033409,
        Siocslowat = 2147192062,
        Siocglowat = 1074033411,

        /// <summary>
        /// Use to determine if all out of band (OOB) data has been read. 
        /// </summary>
        Siocatmark = 1074033415
    }
    public enum ControlCode : int
    {
        SIO_ASSOCIATE_HANDLE = -2013265919,
        SIO_ENABLE_CIRCULAR_QUEUEING = 671088642,
        SIO_FIND_ROUTE = 1207959555,
        SIO_FLUSH = 671088644,
        SIO_GET_BROADCAST_ADDRESS = 1207959557,
        SIO_GET_EXTENSION_FUNCTION_POINTER = -939524090,
        SIO_GET_QOS = -939524089,
        SIO_GET_GROUP_QOS = -939524088,
        SIO_MULTIPOINT_LOOPBACK = -2013265911,
        SIO_MULTICAST_SCOPE = -2013265910,
        SIO_SET_QOS = -2013265909,
        SIO_SET_GROUP_QOS = -2013265908,
        SIO_TRANSLATE_HANDLE = -939524083,
        SIO_ROUTING_INTERFACE_QUERY = -939524076,
        SIO_ROUTING_INTERFACE_CHANGE = -2013265899,
        SIO_ADDRESS_LIST_QUERY = 1207959574,
        SIO_ADDRESS_LIST_CHANGE = 671088663,
        SIO_QUERY_TARGET_PNP_HANDLE = 1207959576,

        /* [OUT] INTERFACE_INFO */
        SIO_GET_INTERFACE_LIST = 1074033791,

        SIO_GET_INTERFACE_LIST_EX = 1074033790,
        SIO_SET_MULTICAST_FILTER = -2147191683,
        SIO_GET_MULTICAST_FILTER = -2147191684,
        SIOCSIPMSFILTER = -2147191683,
        SIOCGIPMSFILTER = -2147191684,

        SIO_RCVALL = -1744830463,
        SIO_RCVALL_MCAST = -1744830462,
        SIO_RCVALL_IGMPMCAST = -1744830461,

        /* [IN] tcp_keepalive*/
        SIO_KEEPALIVE_VALS = -1744830460,

        SIO_ABSORB_RTRALERT = -1744830459,
        SIO_UCAST_IF = -1744830458,
        SIO_LIMIT_BROADCASTS = -1744830457,
        SIO_INDEX_BIND = -1744830456,
        SIO_INDEX_MCASTIF = -1744830455,
        SIO_INDEX_ADD_MCAST = -1744830454,
        SIO_INDEX_DEL_MCAST = -1744830453,
        SIO_UDP_CONNRESET = -1744830452,
        SIO_RCVALL_MCAST_IF = -1744830451,
        SIO_RCVALL_IF = -1744830450,

        /* [OUT] Int32*/
        FIONREAD = 1074030207,

        /* [IN] Int32*/
        FIONBIO = -2147195266,

        FIOASYNC = 2147195267,
        SIOCSHIWAT = 2147192064,
        SIOCGHIWAT = 1074033409,
        SIOCSLOWAT = 2147192062,
        SIOCGLOWAT = 1074033411,
        SIOCATMARK = 1074033415
    }
    [Flags]
    public enum AsyncEventBits
    {
        FdAccept = 8,
        FdAddressListChange = 0x200,
        FdAllEvents = 0x3ff,
        FdClose = 0x20,
        FdConnect = 0x10,
        FdGroupQos = 0x80,
        FdNone = 0,
        FdOob = 4,
        FdQos = 0x40,
        FdRead = 1,
        FdRoutingInterfaceChange = 0x100,
        FdWrite = 2
    }

    [Flags]
    public enum ShutdownFlags : uint
    {
        SHUTDOWN_FORCE_OTHERS = 0x00000001,
        SHUTDOWN_FORCE_SELF = 0x00000002,
        SHUTDOWN_GRACE_OVERRIDE = 0x00000020,
        SHUTDOWN_HYBRID = 0x00000200,
        SHUTDOWN_INSTALL_UPDATES = 0x00000040,
        SHUTDOWN_NOREBOOT = 0x00000010,
        SHUTDOWN_POWEROFF = 0x00000008,
        SHUTDOWN_RESTART = 0x00000004,
        SHUTDOWN_RESTARTAPPS = 0x00000080
    }
    [Flags]
    public enum ShutdownReason : uint
    {
        // Microsoft major reasons.
        SHTDN_REASON_MAJOR_OTHER = 0x00000000,
        SHTDN_REASON_MAJOR_NONE = 0x00000000,
        SHTDN_REASON_MAJOR_HARDWARE = 0x00010000,
        SHTDN_REASON_MAJOR_OPERATINGSYSTEM = 0x00020000,
        SHTDN_REASON_MAJOR_SOFTWARE = 0x00030000,
        SHTDN_REASON_MAJOR_APPLICATION = 0x00040000,
        SHTDN_REASON_MAJOR_SYSTEM = 0x00050000,
        SHTDN_REASON_MAJOR_POWER = 0x00060000,
        SHTDN_REASON_MAJOR_LEGACY_API = 0x00070000,

        // Microsoft minor reasons.
        SHTDN_REASON_MINOR_OTHER = 0x00000000,
        SHTDN_REASON_MINOR_NONE = 0x000000ff,
        SHTDN_REASON_MINOR_MAINTENANCE = 0x00000001,
        SHTDN_REASON_MINOR_INSTALLATION = 0x00000002,
        SHTDN_REASON_MINOR_UPGRADE = 0x00000003,
        SHTDN_REASON_MINOR_RECONFIG = 0x00000004,
        SHTDN_REASON_MINOR_HUNG = 0x00000005,
        SHTDN_REASON_MINOR_UNSTABLE = 0x00000006,
        SHTDN_REASON_MINOR_DISK = 0x00000007,
        SHTDN_REASON_MINOR_PROCESSOR = 0x00000008,
        SHTDN_REASON_MINOR_NETWORKCARD = 0x00000000,
        SHTDN_REASON_MINOR_POWER_SUPPLY = 0x0000000a,
        SHTDN_REASON_MINOR_CORDUNPLUGGED = 0x0000000b,
        SHTDN_REASON_MINOR_ENVIRONMENT = 0x0000000c,
        SHTDN_REASON_MINOR_HARDWARE_DRIVER = 0x0000000d,
        SHTDN_REASON_MINOR_OTHERDRIVER = 0x0000000e,
        SHTDN_REASON_MINOR_BLUESCREEN = 0x0000000F,
        SHTDN_REASON_MINOR_SERVICEPACK = 0x00000010,
        SHTDN_REASON_MINOR_HOTFIX = 0x00000011,
        SHTDN_REASON_MINOR_SECURITYFIX = 0x00000012,
        SHTDN_REASON_MINOR_SECURITY = 0x00000013,
        SHTDN_REASON_MINOR_NETWORK_CONNECTIVITY = 0x00000014,
        SHTDN_REASON_MINOR_WMI = 0x00000015,
        SHTDN_REASON_MINOR_SERVICEPACK_UNINSTALL = 0x00000016,
        SHTDN_REASON_MINOR_HOTFIX_UNINSTALL = 0x00000017,
        SHTDN_REASON_MINOR_SECURITYFIX_UNINSTALL = 0x00000018,
        SHTDN_REASON_MINOR_MMC = 0x00000019,
        SHTDN_REASON_MINOR_TERMSRV = 0x00000020,

        // Flags that end up in the event log code.
        SHTDN_REASON_FLAG_USER_DEFINED = 0x40000000,
        SHTDN_REASON_FLAG_PLANNED = 0x80000000,
        SHTDN_REASON_UNKNOWN = SHTDN_REASON_MINOR_NONE,
        SHTDN_REASON_LEGACY_API = (SHTDN_REASON_MAJOR_LEGACY_API | SHTDN_REASON_FLAG_PLANNED),

        // This mask cuts out UI flags.
        SHTDN_REASON_VALID_BIT_MASK = 0xc0ffffff
    }

    [Flags]
    public enum EWX : uint
    {
        EWX_HYBRID_SHUTDOWN = 0x00400000,
        EWX_LOGOFF = 0,
        EWX_POWEROFF = 0x00000008,
        EWX_REBOOT = 0x00000002,
        EWX_RESTARTAPPS = 0x00000040,
        EWX_SHUTDOWN = 0x00000001,
        EWX_FORCE = 0x00000004,
        EWX_FORCEIFHUNG = 0x00000010,
    }
    public enum ClipboardFormat : uint
    {
        /*
         * Predefined Clipboard Formats
         */
        CF_TEXT = 1,
        CF_BITMAP = 2,
        CF_METAFILEPICT = 3,
        CF_SYLK = 4,
        CF_DIF = 5,
        CF_TIFF = 6,
        CF_OEMTEXT = 7,
        CF_DIB = 8,
        CF_PALETTE = 9,
        CF_PENDATA = 10,
        CF_RIFF = 11,
        CF_WAVE = 12,
        CF_UNICODETEXT = 13,
        CF_ENHMETAFILE = 14,
        CF_HDROP = 15,
        CF_LOCALE = 16,
        CF_DIBV5 = 17,
        CF_MAX = 18,

        CF_OWNERDISPLAY = 0x0080,
        CF_DSPTEXT = 0x0081,
        CF_DSPBITMAP = 0x0082,
        CF_DSPMETAFILEPICT = 0x0083,
        CF_DSPENHMETAFILE = 0x008E,

        /*
         * "Private" formats don't get GlobalFree()'d
         */
        CF_PRIVATEFIRST = 0x0200,
        CF_PRIVATELAST = 0x02FF,

        /*
         * "GDIOBJ" formats do get DeleteObject()'d
         */
        CF_GDIOBJFIRST = 0x0300,
        CF_GDIOBJLAST = 0x03FF
    }
    public enum Win32ResourceType : uint
    {
        RT_CURSOR = 0x1,
        RT_FONT = 0x8,
        RT_BITMAP = 0x2,
        RT_ICON = 0x3,
        RT_MENU = 0x4,
        RT_DIALOG = 0x5,
        RT_STRING = 0x6,
        RT_FONTDIR = 0x7,
        RT_ACCELERATOR = 0x9,
        RT_RCDATA = 0xa,
        RT_MESSAGETABLE = 0xb,
        RT_GROUP_CURSOR = 0xc,
        RT_GROUP_ICON = 0xe,
        RT_VERSION = 0x10,
        RT_DLGINCLUDE = 0x11,
        RT_PLUGPLAY = 0x13,
        RT_VXD = 0x14,
        RT_ANICURSOR = 0x15,
        RT_ANIICON = 0x16,
        RT_HTML = 0x17,
        RT_MANIFEST = 0x18
    }

    public enum RESOURCE_ENUM : uint
    {
        RESOURCE_ENUM_MUI = 0x0002,
        RESOURCE_ENUM_LN = 0x0001,
        RESOURCE_ENUM_MUI_SYSTEM = 0x0004,
        RESOURCE_ENUM_VALIDATE = 0x0008
    }

    public enum ImageType : uint
    {
        IMAGE_BITMAP = 0,
        IMAGE_CURSOR = 2,
        IMAGE_ICON = 1
    }

    [Flags]
    public enum ImageFlagsExtended : uint
    {
        LR_CREATEDIBSECTION = 0x00002000,
        LR_DEFAULTCOLOR = 0x00000000,
        LR_DEFAULTSIZE = 0x00000040,
        LR_LOADFROMFILE = 0x00000010,
        LR_LOADMAP3DCOLORS = 0x00001000,
        LR_LOADTRANSPARENT = 0x00000020,
        LR_MONOCHROME = 0x00000001,
        LR_SHARED = 0x00008000,
        LR_VGACOLOR = 0x00000080
    }

    [Flags]
    public enum ImageFlags : uint
    {
        // Deletes the original image after creating the copy.
        LR_COPYDELETEORG = 0x00000008,

        // Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image.
        LR_COPYFROMRESOURCE = 0x00004000,

        // Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth
        LR_COPYRETURNORG = 0x00000004,

        // this is set and a new bitmap is created, the bitmap is created as a DIB section.
        LR_CREATEDIBSECTION = 0x00002000,

        // Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set to zero.
        LR_DEFAULTSIZE = 0x00000040,

        // Creates a new monochrome image
        LR_MONOCHROME = 0x00000001
    }

    [Flags]
    public enum FileFlags : uint
    {
        VS_FF_DEBUG = 1,
        VS_FF_INFOINFERRED = 16,
        VS_FF_PATCHED = 4,
        VS_FF_PRERELEASE = 2,
        VS_FF_PRIVATEBUILD = 8,
        VS_FF_SPECIALBUILD = 32,
    }

    [Flags]
    public enum FileOS : uint
    {
        VOS_UNKNOWN = 0,
        VOS_DOS = 0x10000,
        VOS_OS216 = 0x20000,
        VOS_OS232 = 0x30000,
        VOS_NT = 0x40000,
        VOS__BASE = 0,
        VOS__WINDOWS16 = 1,
        VOS__PM16 = 2,
        VOS__PM32 = 3,
        VOS__WINDOWS32 = 4,
        VOS_DOS_WINDOWS16 = 0x10001,
        VOS_DOS_WINDOWS32 = 0x10004,
        VOS_OS216_PM16 = 0x20002,
        VOS_OS232_PM32 = 0x30003,
        VOS_NT_WINDOWS32 = 0x40004
    }

    [Flags]
    public enum FileType : uint
    {
        VFT_APP = 1,
        VFT_DLL = 2,
        VFT_DRV = 3,
        VFT_FONT = 4,
        VFT_STATIC_LIB = 7,
        VFT_UNKNOWN = 0,
        VFT_VXD = 5
    }

    [Flags]
    public enum FileSubtype : uint
    {
        VFT2_UNKNOWN = 0,
        VFT2_DRV_PRINTER = 1,
        VFT2_DRV_KEYBOARD = 2,
        VFT2_DRV_LANGUAGE = 3,
        VFT2_DRV_DISPLAY = 4,
        VFT2_DRV_MOUSE = 5,
        VFT2_DRV_NETWORK = 6,
        VFT2_DRV_SYSTEM = 7,
        VFT2_DRV_INSTALLABLE = 8,
        VFT2_DRV_SOUND = 9,
        VFT2_DRV_COMM = 10,
        VFT2_DRV_INPUTMETHOD = 11,
        VFT2_DRV_VERSIONED_PRINTER = 12,
        VFT2_FONT_RASTER = 1,
        VFT2_FONT_VECTOR = 2,
        VFT2_FONT_TRUETYPE = 3
    }

    public enum LIST_MODULES : uint
    {
        LIST_MODULES_32BIT = 0x01,
        LIST_MODULES_64BIT = 0x02,
        LIST_MODULES_ALL = 0x03,
        LIST_MODULES_DEFAULT = 0x0
    }

    [Flags]
    public enum MenuOption : uint
    {
        MF_BYCOMMAND = 0x00000000,
        MF_ENABLED = 0x00000000,
        MF_GRAYED = 0x00000001,
        MF_DISABLED = 0x00000002,
        MF_BYPOSITION = 0x00000400
    }

    public enum AdditionalFlags
    {
        FIND_FIRST_EX_CASE_SENSITIVE = 1,
        FIND_FIRST_EX_LARGE_FETCH = 2
    }
    public enum EMoveMethod : uint
    {
        Begin = 0,
        Current = 1,
        End = 2
    }
    public enum FINDEX_INFO_LEVELS
    {
        FindExInfoStandard,
        FindExInfoBasic,
        FindExInfoMaxInfoLevel
    }
    public enum FINDEX_SEARCH_OPS
    {
        FindExSearchNameMatch,
        FindExSearchLimitToDirectories,
        FindExSearchLimitToDevices
    }

    public enum GET_FILEEX_INFO_LEVELS
    {
        GetFileExInfoStandard,
        GetFileExMaxInfoLevel
    }
    public enum LockFlags : uint
    {
        LOCKFILE_FAIL_IMMEDIATELY = 0x00000001,
        LOCKFILE_EXCLUSIVE_LOCK = 0x00000002
    }
    [Flags]
    public enum FileMapProtection : uint
    {
        PageReadonly = 0x02,
        PageReadWrite = 0x04,
        PageWriteCopy = 0x08,
        PageExecuteRead = 0x20,
        PageExecuteReadWrite = 0x40,
        SectionCommit = 0x8000000,
        SectionImage = 0x1000000,
        SectionNoCache = 0x10000000,
        SectionReserve = 0x4000000,
    }
    [Flags]
    public enum FileMapAccess : uint
    {
        FileMapCopy = 0x0001,
        FileMapWrite = 0x0002,
        FileMapRead = 0x0004,
        FileMapAllAccess = 0x001f,
        fileMapExecute = 0x0020,
    }

    public enum AllocationProtectEnum : uint
    {
        PAGE_EXECUTE = 0x00000010,
        PAGE_EXECUTE_READ = 0x00000020,
        PAGE_EXECUTE_READWRITE = 0x00000040,
        PAGE_EXECUTE_WRITECOPY = 0x00000080,
        PAGE_NOACCESS = 0x00000001,
        PAGE_READONLY = 0x00000002,
        PAGE_READWRITE = 0x00000004,
        PAGE_WRITECOPY = 0x00000008,
        PAGE_GUARD = 0x00000100,
        PAGE_NOCACHE = 0x00000200,
        PAGE_WRITECOMBINE = 0x00000400
    }

    public enum StateEnum : uint
    {
        MEM_COMMIT = 0x1000,
        MEM_FREE = 0x10000,
        MEM_RESERVE = 0x2000
    }

    public enum TypeEnum : uint
    {
        MEM_IMAGE = 0x1000000,
        MEM_MAPPED = 0x40000,
        MEM_PRIVATE = 0x20000
    }

    [Flags]
    public enum CONTEXT_FLAGS : uint
    {
        CONTEXT_i386 = 0x10000,
        CONTEXT_i486 = 0x10000,   //  same as i386
        CONTEXT_CONTROL = CONTEXT_i386 | 0x01, // SS:SP, CS:IP, FLAGS, BP
        CONTEXT_INTEGER = CONTEXT_i386 | 0x02, // AX, BX, CX, DX, SI, DI
        CONTEXT_SEGMENTS = CONTEXT_i386 | 0x04, // DS, ES, FS, GS
        CONTEXT_FLOATING_POINT = CONTEXT_i386 | 0x08, // 387 state
        CONTEXT_DEBUG_REGISTERS = CONTEXT_i386 | 0x10, // DB 0-3,6,7
        CONTEXT_EXTENDED_REGISTERS = CONTEXT_i386 | 0x20, // cpu specific extensions
        CONTEXT_FULL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS,
        CONTEXT_ALL = CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT
            | CONTEXT_DEBUG_REGISTERS | CONTEXT_EXTENDED_REGISTERS,
        CONTEXT_XSTATE = CONTEXT_i386 | (uint)0x00000040L
    }

    [Flags]
    public enum WOW64_CONTEXT_FLAGS : uint
    {
        WOW64_CONTEXT_i386 = 0x10000,
        WOW64_CONTEXT_i486 = 0x10000,   //  same as i386
        WOW64_CONTEXT_CONTROL = WOW64_CONTEXT_i386 | 0x01, // SS:SP, CS:IP, FLAGS, BP
        WOW64_CONTEXT_INTEGER = WOW64_CONTEXT_i386 | 0x02, // AX, BX, CX, DX, SI, DI
        WOW64_CONTEXT_SEGMENTS = WOW64_CONTEXT_i386 | 0x04, // DS, ES, FS, GS
        WOW64_CONTEXT_FLOATING_POINT = WOW64_CONTEXT_i386 | 0x08, // 387 state
        WOW64_CONTEXT_DEBUG_REGISTERS = WOW64_CONTEXT_i386 | 0x10, // DB 0-3,6,7
        WOW64_CONTEXT_EXTENDED_REGISTERS = WOW64_CONTEXT_i386 | 0x20, // cpu specific extensions
        WOW64_CONTEXT_FULL = WOW64_CONTEXT_CONTROL | WOW64_CONTEXT_INTEGER | WOW64_CONTEXT_SEGMENTS,
        WOW64_CONTEXT_ALL = WOW64_CONTEXT_CONTROL | WOW64_CONTEXT_INTEGER | WOW64_CONTEXT_SEGMENTS
            | WOW64_CONTEXT_FLOATING_POINT | WOW64_CONTEXT_DEBUG_REGISTERS | WOW64_CONTEXT_EXTENDED_REGISTERS,
        WOW64_CONTEXT_XSTATE = WOW64_CONTEXT_i386 | (uint)0x00000040L
    }

    /// <summary>
    /// look at GetSystemMetrics function parameters
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724385(v=vs.85).aspx
    /// </summary>
    public enum SystemMetric : uint
    {
        SM_CXSCREEN = 0,
        SM_CYSCREEN = 1,
        SM_CXVSCROLL = 2,
        SM_CYHSCROLL = 3,
        SM_CYCAPTION = 4,
        SM_CXBORDER = 5,
        SM_CYBORDER = 6,
        SM_CXDLGFRAME = 7,
        SM_CYDLGFRAME = 8,
        SM_CYVTHUMB = 9,
        SM_CXHTHUMB = 10,
        SM_CXICON = 11,
        SM_CYICON = 12,
        SM_CXCURSOR = 13,
        SM_CYCURSOR = 14,
        SM_CYMENU = 15,
        SM_CXFULLSCREEN = 16,
        SM_CYFULLSCREEN = 17,
        SM_CYKANJIWINDOW = 18,
        SM_MOUSEPRESENT = 19,
        SM_CYVSCROLL = 20,
        SM_CXHSCROLL = 21,
        SM_DEBUG = 22,
        SM_SWAPBUTTON = 23,
        SM_RESERVED1 = 24,
        SM_RESERVED2 = 25,
        SM_RESERVED3 = 26,
        SM_RESERVED4 = 27,
        SM_CXMIN = 28,
        SM_CYMIN = 29,
        SM_CXSIZE = 30,
        SM_CYSIZE = 31,
        SM_CXFRAME = 32,
        SM_CYFRAME = 33,
        SM_CXMINTRACK = 34,
        SM_CYMINTRACK = 35,
        SM_CXDOUBLECLK = 36,
        SM_CYDOUBLECLK = 37,
        SM_CXICONSPACING = 38,
        SM_CYICONSPACING = 39,
        SM_MENUDROPALIGNMENT = 40,
        SM_PENWINDOWS = 41,
        SM_DBCSENABLED = 42,
        SM_CMOUSEBUTTONS = 43,
        SM_CXFIXEDFRAME = SM_CXDLGFRAME, /* ;win40 name change */
        SM_CYFIXEDFRAME = SM_CYDLGFRAME, /* ;win40 name change */
        SM_CXSIZEFRAME = SM_CXFRAME, /* ;win40 name change */
        SM_CYSIZEFRAME = SM_CYFRAME,  /* ;win40 name change */
        SM_SECURE = 44,
        SM_CXEDGE = 45,
        SM_CYEDGE = 46,
        SM_CXMINSPACING = 47,
        SM_CYMINSPACING = 48,
        SM_CXSMICON = 49,
        SM_CYSMICON = 50,
        SM_CYSMCAPTION = 51,
        SM_CXSMSIZE = 52,
        SM_CYSMSIZE = 53,
        SM_CXMENUSIZE = 54,
        SM_CYMENUSIZE = 55,
        SM_ARRANGE = 56,
        SM_CXMINIMIZED = 57,
        SM_CYMINIMIZED = 58,
        SM_CXMAXTRACK = 59,
        SM_CYMAXTRACK = 60,
        SM_CXMAXIMIZED = 61,
        SM_CYMAXIMIZED = 62,
        SM_NETWORK = 63,
        SM_CLEANBOOT = 67,
        SM_CXDRAG = 68,
        SM_CYDRAG = 69,
        SM_SHOWSOUNDS = 70,
        SM_CXMENUCHECK = 71,  /* Use instead of GetMenuCheckMarkDimensions()! */
        SM_CYMENUCHECK = 72,
        SM_SLOWMACHINE = 73,
        SM_MIDEASTENABLED = 74,
        SM_MOUSEWHEELPRESENT = 75,
        SM_XVIRTUALSCREEN = 76,
        SM_YVIRTUALSCREEN = 77,
        SM_CXVIRTUALSCREEN = 78,
        SM_CYVIRTUALSCREEN = 79,
        SM_CMONITORS = 80,
        SM_SAMEDISPLAYFORMAT = 81,
        SM_IMMENABLED = 82,
        SM_CXFOCUSBORDER = 83,
        SM_CYFOCUSBORDER = 84,
        SM_TABLETPC = 86,
        SM_MEDIACENTER = 87,
        SM_STARTER = 88,
        SM_SERVERR2 = 89,
        SM_MOUSEHORIZONTALWHEELPRESENT = 91,
        SM_CXPADDEDBORDER = 92,
        SM_DIGITIZER = 94,
        SM_MAXIMUMTOUCHES = 95,

        //#if (WINVER < 0x0500) && (!defined(_WIN32_WINNT) || (_WIN32_WINNT < 0x0400))
        //SM_CMETRICS             76
        //#elif WINVER == 0x500
        //SM_CMETRICS             83
        //#elif WINVER == 0x501
        //SM_CMETRICS             91
        //#elif WINVER == 0x600
        //SM_CMETRICS             93
        //#else
        //SM_CMETRICS             97
        //#endif

        SM_REMOTESESSION = 0x1000,
        SM_SHUTTINGDOWN = 0x2000,
        SM_REMOTECONTROL = 0x2001,
        SM_CARETBLINKINGENABLED = 0x2002
    }

    /// <summary>
    /// look at SystemParametersInfo function parameters
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724947(v=vs.85).aspx
    /// </summary>
    public enum ParameterAction : uint
    {
        SPI_GETBEEP = 0x0001,
        SPI_SETBEEP = 0x0002,
        SPI_GETMOUSE = 0x0003,
        SPI_SETMOUSE = 0x0004,
        SPI_GETBORDER = 0x0005,
        SPI_SETBORDER = 0x0006,
        SPI_GETKEYBOARDSPEED = 0x000A,
        SPI_SETKEYBOARDSPEED = 0x000B,
        SPI_LANGDRIVER = 0x000C,
        SPI_ICONHORIZONTALSPACING = 0x000D,
        SPI_GETSCREENSAVETIMEOUT = 0x000E,
        SPI_SETSCREENSAVETIMEOUT = 0x000F,
        SPI_GETSCREENSAVEACTIVE = 0x0010,
        SPI_SETSCREENSAVEACTIVE = 0x0011,
        SPI_GETGRIDGRANULARITY = 0x0012,
        SPI_SETGRIDGRANULARITY = 0x0013,
        SPI_SETDESKWALLPAPER = 0x0014,
        SPI_SETDESKPATTERN = 0x0015,
        SPI_GETKEYBOARDDELAY = 0x0016,
        SPI_SETKEYBOARDDELAY = 0x0017,
        SPI_ICONVERTICALSPACING = 0x0018,
        SPI_GETICONTITLEWRAP = 0x0019,
        SPI_SETICONTITLEWRAP = 0x001A,
        SPI_GETMENUDROPALIGNMENT = 0x001B,
        SPI_SETMENUDROPALIGNMENT = 0x001C,
        SPI_SETDOUBLECLKWIDTH = 0x001D,
        SPI_SETDOUBLECLKHEIGHT = 0x001E,
        SPI_GETICONTITLELOGFONT = 0x001F,
        SPI_SETDOUBLECLICKTIME = 0x0020,
        SPI_SETMOUSEBUTTONSWAP = 0x0021,
        SPI_SETICONTITLELOGFONT = 0x0022,
        SPI_GETFASTTASKSWITCH = 0x0023,
        SPI_SETFASTTASKSWITCH = 0x0024,

        SPI_SETDRAGFULLWINDOWS = 0x0025,
        SPI_GETDRAGFULLWINDOWS = 0x0026,
        SPI_GETNONCLIENTMETRICS = 0x0029,
        SPI_SETNONCLIENTMETRICS = 0x002A,
        SPI_GETMINIMIZEDMETRICS = 0x002B,
        SPI_SETMINIMIZEDMETRICS = 0x002C,
        SPI_GETICONMETRICS = 0x002D,
        SPI_SETICONMETRICS = 0x002E,
        SPI_SETWORKAREA = 0x002F,
        SPI_GETWORKAREA = 0x0030,
        SPI_SETPENWINDOWS = 0x0031,

        SPI_GETHIGHCONTRAST = 0x0042,
        SPI_SETHIGHCONTRAST = 0x0043,
        SPI_GETKEYBOARDPREF = 0x0044,
        SPI_SETKEYBOARDPREF = 0x0045,
        SPI_GETSCREENREADER = 0x0046,
        SPI_SETSCREENREADER = 0x0047,
        SPI_GETANIMATION = 0x0048,
        SPI_SETANIMATION = 0x0049,
        SPI_GETFONTSMOOTHING = 0x004A,
        SPI_SETFONTSMOOTHING = 0x004B,
        SPI_SETDRAGWIDTH = 0x004C,
        SPI_SETDRAGHEIGHT = 0x004D,
        SPI_SETHANDHELD = 0x004E,
        SPI_GETLOWPOWERTIMEOUT = 0x004F,
        SPI_GETPOWEROFFTIMEOUT = 0x0050,
        SPI_SETLOWPOWERTIMEOUT = 0x0051,
        SPI_SETPOWEROFFTIMEOUT = 0x0052,
        SPI_GETLOWPOWERACTIVE = 0x0053,
        SPI_GETPOWEROFFACTIVE = 0x0054,
        SPI_SETLOWPOWERACTIVE = 0x0055,
        SPI_SETPOWEROFFACTIVE = 0x0056,
        SPI_SETCURSORS = 0x0057,
        SPI_SETICONS = 0x0058,
        SPI_GETDEFAULTINPUTLANG = 0x0059,
        SPI_SETDEFAULTINPUTLANG = 0x005A,
        SPI_SETLANGTOGGLE = 0x005B,
        SPI_GETWINDOWSEXTENSION = 0x005C,
        SPI_SETMOUSETRAILS = 0x005D,
        SPI_GETMOUSETRAILS = 0x005E,
        SPI_SETSCREENSAVERRUNNING = 0x0061,
        SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,

        SPI_GETFILTERKEYS = 0x0032,
        SPI_SETFILTERKEYS = 0x0033,
        SPI_GETTOGGLEKEYS = 0x0034,
        SPI_SETTOGGLEKEYS = 0x0035,
        SPI_GETMOUSEKEYS = 0x0036,
        SPI_SETMOUSEKEYS = 0x0037,
        SPI_GETSHOWSOUNDS = 0x0038,
        SPI_SETSHOWSOUNDS = 0x0039,
        SPI_GETSTICKYKEYS = 0x003A,
        SPI_SETSTICKYKEYS = 0x003B,
        SPI_GETACCESSTIMEOUT = 0x003C,
        SPI_SETACCESSTIMEOUT = 0x003D,

        SPI_GETSERIALKEYS = 0x003E,
        SPI_SETSERIALKEYS = 0x003F,

        SPI_GETSOUNDSENTRY = 0x0040,
        SPI_SETSOUNDSENTRY = 0x0041,

        SPI_GETSNAPTODEFBUTTON = 0x005F,
        SPI_SETSNAPTODEFBUTTON = 0x0060,
        SPI_GETMOUSEHOVERWIDTH = 0x0062,
        SPI_SETMOUSEHOVERWIDTH = 0x0063,
        SPI_GETMOUSEHOVERHEIGHT = 0x0064,
        SPI_SETMOUSEHOVERHEIGHT = 0x0065,
        SPI_GETMOUSEHOVERTIME = 0x0066,
        SPI_SETMOUSEHOVERTIME = 0x0067,
        SPI_GETWHEELSCROLLLINES = 0x0068,
        SPI_SETWHEELSCROLLLINES = 0x0069,
        SPI_GETMENUSHOWDELAY = 0x006A,
        SPI_SETMENUSHOWDELAY = 0x006B,

        SPI_GETWHEELSCROLLCHARS = 0x006C,
        SPI_SETWHEELSCROLLCHARS = 0x006D,

        SPI_GETSHOWIMEUI = 0x006E,
        SPI_SETSHOWIMEUI = 0x006F,

        SPI_GETMOUSESPEED = 0x0070,
        SPI_SETMOUSESPEED = 0x0071,
        SPI_GETSCREENSAVERRUNNING = 0x0072,
        SPI_GETDESKWALLPAPER = 0x0073,

        SPI_GETAUDIODESCRIPTION = 0x0074,
        SPI_SETAUDIODESCRIPTION = 0x0075,

        SPI_GETSCREENSAVESECURE = 0x0076,
        SPI_SETSCREENSAVESECURE = 0x0077,

        SPI_GETHUNGAPPTIMEOUT = 0x0078,
        SPI_SETHUNGAPPTIMEOUT = 0x0079,
        SPI_GETWAITTOKILLTIMEOUT = 0x007A,
        SPI_SETWAITTOKILLTIMEOUT = 0x007B,
        SPI_GETWAITTOKILLSERVICETIMEOUT = 0x007C,
        SPI_SETWAITTOKILLSERVICETIMEOUT = 0x007D,
        SPI_GETMOUSEDOCKTHRESHOLD = 0x007E,
        SPI_SETMOUSEDOCKTHRESHOLD = 0x007F,
        SPI_GETPENDOCKTHRESHOLD = 0x0080,
        SPI_SETPENDOCKTHRESHOLD = 0x0081,
        SPI_GETWINARRANGING = 0x0082,
        SPI_SETWINARRANGING = 0x0083,
        SPI_GETMOUSEDRAGOUTTHRESHOLD = 0x0084,
        SPI_SETMOUSEDRAGOUTTHRESHOLD = 0x0085,
        SPI_GETPENDRAGOUTTHRESHOLD = 0x0086,
        SPI_SETPENDRAGOUTTHRESHOLD = 0x0087,
        SPI_GETMOUSESIDEMOVETHRESHOLD = 0x0088,
        SPI_SETMOUSESIDEMOVETHRESHOLD = 0x0089,
        SPI_GETPENSIDEMOVETHRESHOLD = 0x008A,
        SPI_SETPENSIDEMOVETHRESHOLD = 0x008B,
        SPI_GETDRAGFROMMAXIMIZE = 0x008C,
        SPI_SETDRAGFROMMAXIMIZE = 0x008D,
        SPI_GETSNAPSIZING = 0x008E,
        SPI_SETSNAPSIZING = 0x008F,
        SPI_GETDOCKMOVING = 0x0090,
        SPI_SETDOCKMOVING = 0x0091,

        SPI_GETACTIVEWINDOWTRACKING = 0x1000,
        SPI_SETACTIVEWINDOWTRACKING = 0x1001,
        SPI_GETMENUANIMATION = 0x1002,
        SPI_SETMENUANIMATION = 0x1003,
        SPI_GETCOMBOBOXANIMATION = 0x1004,
        SPI_SETCOMBOBOXANIMATION = 0x1005,
        SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,
        SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,
        SPI_GETGRADIENTCAPTIONS = 0x1008,
        SPI_SETGRADIENTCAPTIONS = 0x1009,
        SPI_GETKEYBOARDCUES = 0x100A,
        SPI_SETKEYBOARDCUES = 0x100B,
        SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,
        SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,
        SPI_GETACTIVEWNDTRKZORDER = 0x100C,
        SPI_SETACTIVEWNDTRKZORDER = 0x100D,
        SPI_GETHOTTRACKING = 0x100E,
        SPI_SETHOTTRACKING = 0x100F,
        SPI_GETMENUFADE = 0x1012,
        SPI_SETMENUFADE = 0x1013,
        SPI_GETSELECTIONFADE = 0x1014,
        SPI_SETSELECTIONFADE = 0x1015,
        SPI_GETTOOLTIPANIMATION = 0x1016,
        SPI_SETTOOLTIPANIMATION = 0x1017,
        SPI_GETTOOLTIPFADE = 0x1018,
        SPI_SETTOOLTIPFADE = 0x1019,
        SPI_GETCURSORSHADOW = 0x101A,
        SPI_SETCURSORSHADOW = 0x101B,

        SPI_GETMOUSESONAR = 0x101C,
        SPI_SETMOUSESONAR = 0x101D,
        SPI_GETMOUSECLICKLOCK = 0x101E,
        SPI_SETMOUSECLICKLOCK = 0x101F,
        SPI_GETMOUSEVANISH = 0x1020,
        SPI_SETMOUSEVANISH = 0x1021,
        SPI_GETFLATMENU = 0x1022,
        SPI_SETFLATMENU = 0x1023,
        SPI_GETDROPSHADOW = 0x1024,
        SPI_SETDROPSHADOW = 0x1025,
        SPI_GETBLOCKSENDINPUTRESETS = 0x1026,
        SPI_SETBLOCKSENDINPUTRESETS = 0x1027,

        SPI_GETUIEFFECTS = 0x103E,
        SPI_SETUIEFFECTS = 0x103F,

        SPI_GETDISABLEOVERLAPPEDCONTENT = 0x1040,
        SPI_SETDISABLEOVERLAPPEDCONTENT = 0x1041,
        SPI_GETCLIENTAREAANIMATION = 0x1042,
        SPI_SETCLIENTAREAANIMATION = 0x1043,
        SPI_GETCLEARTYPE = 0x1048,
        SPI_SETCLEARTYPE = 0x1049,
        SPI_GETSPEECHRECOGNITION = 0x104A,
        SPI_SETSPEECHRECOGNITION = 0x104B,

        SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,
        SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,
        SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,
        SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,
        SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,
        SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,
        SPI_GETCARETWIDTH = 0x2006,
        SPI_SETCARETWIDTH = 0x2007,

        SPI_GETMOUSECLICKLOCKTIME = 0x2008,
        SPI_SETMOUSECLICKLOCKTIME = 0x2009,
        SPI_GETFONTSMOOTHINGTYPE = 0x200A,
        SPI_SETFONTSMOOTHINGTYPE = 0x200B,

        /* constants for SPI_GETFONTSMOOTHINGTYPE and SPI_SETFONTSMOOTHINGTYPE: */
        FE_FONTSMOOTHINGSTANDARD = 0x0001,
        FE_FONTSMOOTHINGCLEARTYPE = 0x0002,

        SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,
        SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

        SPI_GETFOCUSBORDERWIDTH = 0x200E,
        SPI_SETFOCUSBORDERWIDTH = 0x200F,
        SPI_GETFOCUSBORDERHEIGHT = 0x2010,
        SPI_SETFOCUSBORDERHEIGHT = 0x2011,

        SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,
        SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,

        /* constants for SPI_GETFONTSMOOTHINGORIENTATION and SPI_SETFONTSMOOTHINGORIENTATION: */
        FE_FONTSMOOTHINGORIENTATIONBGR = 0x0000,
        FE_FONTSMOOTHINGORIENTATIONRGB = 0x0001,

        SPI_GETMINIMUMHITRADIUS = 0x2014,
        SPI_SETMINIMUMHITRADIUS = 0x2015,
        SPI_GETMESSAGEDURATION = 0x2016,
        SPI_SETMESSAGEDURATION = 0x2017,
    }

    [Flags]
    public enum CopyFileFlags : uint
    {
        /// <summary>
        /// An attempt to copy an encrypted file will succeed even if the destination copy cannot be encrypted.
        /// </summary>
        COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,

        /// <summary>
        /// If the source file is a symbolic link,
        /// the destination file is also a symbolic link pointing to the same file that the source symbolic link is pointing to.
        /// </summary>
        COPY_FILE_COPY_SYMLINK = 0x00000800, //NT 6.0+

        /// <summary>
        /// The copy operation fails immediately if the target file already exists.
        /// </summary>
        COPY_FILE_FAIL_IF_EXISTS = 0x00000001,

        /// <summary>
        /// The copy operation is performed using unbuffered I/O,
        /// bypassing system I/O cache resources. Recommended for very large file transfers.
        /// </summary>
        COPY_FILE_NO_BUFFERING = 0x00001000,

        /// <summary>
        /// The file is copied and the original file is opened for write access.
        /// </summary>
        COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,

        /// <summary>
        /// Progress of the copy is tracked in the target file in case the copy fails.
        /// The failed copy can be restarted at a later time by specifying the same values for
        /// lpExistingFileName and lpNewFileName as those used in the call that failed.
        /// </summary>
        COPY_FILE_RESTARTABLE = 0x00000002,
    }
    public enum CopyProgressResult : uint
    {
        PROGRESS_CONTINUE = 0,
        PROGRESS_CANCEL = 1,
        PROGRESS_STOP = 2,
        PROGRESS_QUIET = 3
    }

    public enum MIB_NOTIFICATION_TYPE
    {
        MibParameterNotification = 0,
        MibAddInstance = 1,
        MibDeleteInstance = 2,
        MibInitialNotification = 3
    }

    public enum CopyProgressCallbackReason : uint
    {
        CALLBACK_CHUNK_FINISHED = 0x00000000,
        CALLBACK_STREAM_SWITCH = 0x00000001
    }
    [Flags]
    public enum MoveFileFlags
    {
        /// <summary>
        /// If the file is to be moved to a different volume,
        /// the function simulates the move by using the CopyFile and DeleteFile functions.
        /// This value cannot be used with MOVEFILE_DELAY_UNTIL_REBOO
        /// </summary>
        MOVEFILE_COPY_ALLOWED = 0x2,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        MOVEFILE_CREATE_HARDLINK = 0x10,

        /// <summary>
        /// The system does not move the file until the operating system is restarted.
        /// The system moves the file immediately after AUTOCHK is executed,
        /// but before creating any paging files. 
        /// </summary>
        MOVEFILE_DELAY_UNTIL_REBOOT = 0x4,

        /// <summary>
        /// The function fails if the source file is a link source,
        /// but the file cannot be tracked after the move.
        /// </summary>
        MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x20,

        /// <summary>
        /// If a file named lpNewFileName exists,
        /// the function replaces its contents with the contents of the lpExistingFileName file,
        /// provided that security requirements regarding access control lists (ACLs) are met.
        /// </summary>
        MOVEFILE_REPLACE_EXISTING = 0x1,

        /// <summary>
        /// The function does not return until the file is actually moved on the disk.
        /// </summary>
        MOVEFILE_WRITE_THROUGH = 0x8,
    }
    public enum Operation : uint
    {
        /// <summary>
        /// Decommits the specified region of committed pages.
        /// After the operation, the pages are in the reserved state. 
        /// </summary>
        MEM_DECOMMIT = 0x4000,

        /// <summary>
        /// Releases the specified region of pages.
        /// After this operation, the pages are in the free state. 
        /// </summary>
        MEM_RELEASE = 0x8000
    }
    [Flags]
    public enum HeapFlags
    {
        HEAP_CREATE_ENABLE_EXECUTE = 0x00040000,
        HEAP_GENERATE_EXCEPTIONS = 0x00000004,
        HEAP_NO_SERIALIZE = 0x00000001,
        HEAP_REALLOC_IN_PLACE_ONLY = 0x00000010,
        HEAP_ZERO_MEMORY = 0x00000008
    }
    [Flags]
    public enum LocalMemoryFlags : uint
    {
        // Allocates fixed memory. The return value is a pointer to the memory object.
        Fixed = 0x0000,

        // Allocates movable memory.
        // Memory blocks are never moved in physical memory, 
        // but they can be moved within the default heap. 
        Moveable = 0x0002,

        // Initializes memory contents to zero.
        Zeroinit = 0x0040,

        // Combines MOVEABLE and ZEROINIT.
        Lhnd = (Moveable | Zeroinit),

        // Combines FIXED and ZEROINIT.
        Lptr = (Fixed | Zeroinit),

        // Same as MOVEABLE.
        Nonzerolhnd = (Moveable),

        // Same as FIXED.
        Nonzerolptr = (Fixed),

        // Allows modification of the attributes of the memory object. 
        Modify = 0x0080,

        VALID_FLAGS = 0x0F72,
        INVALID_HANDLE = 0x8000
    }
    [Flags]
    public enum GlobalMemoryFlags : uint
    {
        // Allocates fixed memory.
        // The return value is a pointer
        Fixed = 0x0000,

        // Allocates movable memory.
        // Memory blocks are never moved in physical memory,
        // but they can be moved within the default heap. 
        Moveable = 0x0002,

        // Initializes memory contents to zero.
        Zeroinit = 0x0040,

        // Combines _FIXED and _ZEROINIT.
        Gptr = (Fixed | Zeroinit),

        // Combines _MOVEABLE and _ZEROINIT.
        Ghnd = (Moveable | Zeroinit),

        // Allows modification of the attributes of the memory object. 
        Modify = 0x80,

        ValidFlags = 0x7f72,
        InvalidHandle = 0x8000
    }
    [Flags]
    public enum AllocationType : uint
    {
        Commit = 0x1000,
        Reserve = 0x2000,
        Decommit = 0x4000,
        Release = 0x8000,
        Reset = 0x80000,
        Physical = 0x400000,
        TopDown = 0x100000,
        WriteWatch = 0x200000,
        LargePages = 0x20000000
    }
    [Flags]
    public enum MemoryProtection : uint
    {
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        NoAccess = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        GuardModifierflag = 0x100,
        NoCacheModifierflag = 0x200,
        WriteCombineModifierflag = 0x400
    }

    /// <summary>
    /// For use with ChildWindowFromPointEx 
    /// </summary>
    [Flags]
    public enum WindowFromPointFlags : uint
    {
        /// <summary>
        /// Does not skip any child windows
        /// </summary>
        CWP_ALL = 0x0000,
        /// <summary>
        /// Skips invisible child windows
        /// </summary>
        CWP_SKIPINVISIBLE = 0x0001,
        /// <summary>
        /// Skips disabled child windows
        /// </summary>
        CWP_SKIPDISABLED = 0x0002,
        /// <summary>
        /// Skips transparent child windows
        /// </summary>
        CWP_SKIPTRANSPARENT = 0x0004
    }

    [Flags]
    public enum GET_MODULE_HANDLE_EX_FLAG
    {
        /// <summary>
        /// The lpModuleName parameter is an address in the module
        /// </summary>
        FROM_ADDRESS = 0x00000004,

        /// <summary>
        /// The module stays loaded until the process is terminated, no matter how many times FreeLibrary is called. 
        /// </summary>
        PIN = 0x00000001,

        /// <summary>
        /// The reference count for the module is not incremented.
        /// This option is equivalent to the behavior of GetModuleHandle.
        /// </summary>
        UNCHANGED_REFCOUNT = 0x00000002
    }

    [Flags]
    public enum LoadLibraryFlags : uint
    {
        DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
        LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
        LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
        LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
        LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
        LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,
        LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,
        LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,
        LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,
        LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,
        LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
    }

    [Flags]
    public enum DUPLICATE : uint
    {
        DUPLICATE_NULL = 0x00000000,
        DUPLICATE_CLOSE_SOURCE = 0x00000001,
        DUPLICATE_SAME_ACCESS = 0x00000002
    }

    [Flags]
    public enum LogonFlags : uint
    {
        LOGON_WITH_PROFILE = 0x00000001,
        LOGON_NETCREDENTIALS_ONLY = 0x00000002
    }
    [Flags]
    public enum SECURITY_IMPERSONATION_LEVEL : uint
    {
        /// <summary>
        /// The server process cannot obtain identification information about the client, 
        /// and it cannot impersonate the client. It is defined with no value given, and thus, 
        /// by ANSI C rules, defaults to a value of zero. 
        /// </summary>
        SecurityAnonymous = 0,

        /// <summary>
        /// The server process can obtain information about the client, such as security identifiers and privileges, 
        /// but it cannot impersonate the client. This is useful for servers that export their own objects, 
        /// for example, database products that export tables and views. 
        /// Using the retrieved client-security information, the server can make access-validation decisions without 
        /// being able to use other services that are using the client's security context. 
        /// </summary>
        SecurityIdentification = 1,

        /// <summary>
        /// The server process can impersonate the client's security context on its local system. 
        /// The server cannot impersonate the client on remote systems. 
        /// </summary>
        SecurityImpersonation = 2,

        /// <summary>
        /// The server process can impersonate the client's security context on remote systems. 
        /// NOTE: Windows NT:  This impersonation level is not supported.
        /// </summary>
        SecurityDelegation = 3,
    }
    [Flags]
    public enum RestrictedTokenFlags : uint
    {
        DISABLE_MAX_PRIVILEGE = 0x1,
        SANDBOX_INERT = 0x2,
        LUA_TOKEN = 0x4,
        WRITE_RESTRICTED = 0x8
    }
    [Flags]
    public enum TokenAccess : uint
    {
        /// <summary>
        /// Required to change the default owner, primary group, or DACL of an access token.
        /// </summary>
        ADJUST_DEFAULT = 0x0080,

        /// <summary>
        /// Required to adjust the attributes of the groups in an access token.
        /// </summary>
        ADJUST_GROUPS = 0x0040,

        /// <summary>
        /// Required to enable or disable the privileges in an access token.
        /// </summary>
        ADJUST_PRIVILEGES = 0x0020,

        /// <summary>
        /// Required to adjust the session ID of an access token. The SE_TCB_NAME privilege is required.
        /// </summary>
        ADJUST_SESSIONID = 0x0100,

        /// <summary>
        /// Required to attach a primary token to a process.
        /// The SE_ASSIGNPRIMARYNAME privilege is also required to accomplish this task.
        /// </summary>
        ASSIGN_PRIMARY = 0x0001,

        /// <summary>
        /// Required to duplicate an access token.
        /// </summary>
        DUPLICATE = 0x0002,

        /// <summary>
        /// Combines STANDARD_RIGHTS_EXECUTE and IMPERSONATE.
        /// </summary>
        EXECUTE = 0x00020000,

        /// <summary>
        /// Required to attach an impersonation access token to a process.
        /// </summary>
        IMPERSONATE = 0x0004,

        /// <summary>
        /// Required to query an access token.
        /// </summary>
        QUERY = 0x0008,

        /// <summary>
        /// Required to query the source of an access token.
        /// </summary>
        QUERY_SOURCE = 0x0010,

        /// <summary>
        /// Combines STANDARD_RIGHTS_READ and QUERY.
        /// </summary>
        READ = 0x00020000 | QUERY,

        /// <summary>
        /// Combines STANDARD_RIGHTS_WRITE, ADJUST_PRIVILEGES, ADJUST_GROUPS, and ADJUST_DEFAULT.
        /// </summary>
        WRITE = 0x00020000 | ADJUST_PRIVILEGES | ADJUST_GROUPS | ADJUST_DEFAULT,

        /// <summary>
        /// Combines all possible access rights for a token.
        /// </summary>
        ALL_ACCESS = ADJUST_DEFAULT | ADJUST_GROUPS | ADJUST_PRIVILEGES | ADJUST_SESSIONID | ASSIGN_PRIMARY |
            DUPLICATE | EXECUTE | IMPERSONATE | QUERY | QUERY_SOURCE | READ | WRITE,

        MAXIMUM_ALLOWED = 0x2000000
    }
    [Flags]
    public enum TOKEN_TYPE : uint
    {
        TokenPrimary = 1,
        TokenImpersonation = 2
    }
    [Flags]
    public enum TOKEN_ELEVATION_TYPE : uint
    {
        TokenElevationTypeDefault = 1,
        TokenElevationTypeFull,
        TokenElevationTypeLimited
    }
    
    public enum LogonType : uint
    {
        /// <summary>
        /// This logon type is intended for users who will be interactively using the computer, such as a user being logged on  
        /// by a terminal server, remote shell, or similar process.
        /// This logon type has the additional expense of caching logon information for disconnected operations; 
        /// therefore, it is inappropriate for some client/server applications,
        /// such as a mail server.
        /// </summary>
        INTERACTIVE = 2,

        /// <summary>
        /// This logon type is intended for high performance servers to authenticate plaintext passwords.

        /// The LogonUser function does not cache credentials for this logon type.
        /// </summary>
        NETWORK = 3,

        /// <summary>
        /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without 
        /// their direct intervention. This type is also for higher performance servers that process many plaintext
        /// authentication attempts at a time, such as mail or Web servers. 
        /// The LogonUser function does not cache credentials for this logon type.
        /// </summary>
        BATCH = 4,

        /// <summary>
        /// Indicates a service-type logon. The account provided must have the service privilege enabled. 
        /// </summary>
        SERVICE = 5,

        /// <summary>
        /// This logon type is for GINA DLLs that log on users who will be interactively using the computer. 
        /// This logon type can generate a unique audit record that shows when the workstation was unlocked. 
        /// </summary>
        UNLOCK = 7,

        /// <summary>
        /// This logon type preserves the name and password in the authentication package, which allows the server to make 
        /// connections to other network servers while impersonating the client. A server can accept plaintext credentials 
        /// from a client, call LogonUser, verify that the user can access the system across the network, and still 
        /// communicate with other servers.
        /// NOTE: Windows NT:  This value is not supported. 
        /// </summary>
        NETWORK_CLEARTEXT = 8,

        /// <summary>
        /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
        /// The new logon session has the same local identifier but uses different credentials for other network connections. 
        /// NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
        /// NOTE: Windows NT:  This value is not supported. 
        /// </summary>
        NEW_CREDENTIALS = 9,
    }
    public enum LogonProvider : uint
    {
        /// <summary>
        /// Use the standard logon provider for the system. 
        /// The default security provider is negotiate, unless you pass NULL for the domain name and the user name 
        /// is not in UPN format. In this case, the default provider is NTLM. 
        /// NOTE: Windows 2000/NT:   The default security provider is NTLM.
        /// </summary>
        DEFAULT = 0,

        WINNT35,
        WINNT40,
        WINNT50
    }

    [Flags]
    public enum CreationFlags : uint
    {
        CREATE_NEW_PROCESS = 0x00000000,
        DEBUG_PROCESS = 0x00000001,
        DEBUG_ONLY_THIS_PROCESS = 0x00000002,
        CREATE_SUSPENDED = 0x00000004,
        DETACHED_PROCESS = 0x00000008,
        CREATE_NEW_CONSOLE = 0x00000010,
        NORMAL_PRIORITY_CLASS = 0x00000020,
        IDLE_PRIORITY_CLASS = 0x00000040,
        HIGH_PRIORITY_CLASS = 0x00000080,
        REALTIME_PRIORITY_CLASS = 0x00000100,
        CREATE_NEW_PROCESS_GROUP = 0x00000200,
        CREATE_UNICODE_ENVIRONMENT = 0x00000400,
        CREATE_SEPARATE_WOW_VDM = 0x00000800,
        CREATE_SHARED_WOW_VDM = 0x00001000,
        CREATE_FORCEDOS = 0x00002000,
        BELOW_NORMAL_PRIORITY_CLASS = 0x00004000,
        ABOVE_NORMAL_PRIORITY_CLASS = 0x00008000,
        INHERIT_PARENT_AFFINITY = 0x00010000,
        INHERIT_CALLER_PRIORITY = 0x00020000,
        CREATE_PROTECTED_PROCESS = 0x00040000,
        EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
        PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000,
        PROCESS_MODE_BACKGROUND_END = 0x00200000,
        CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
        CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
        CREATE_DEFAULT_ERROR_MODE = 0x04000000,
        CREATE_NO_WINDOW = 0x08000000,
        PROFILE_USER = 0x10000000,
        PROFILE_KERNEL = 0x20000000,
        PROFILE_SERVER = 0x40000000,
        CREATE_IGNORE_SYSTEM_DEFAULT = 0x80000000,
    }

    [Flags]
    public enum ThreadAccess : uint
    {
        TERMINATE = (0x0001),
        SUSPEND_RESUME = (0x0002),
        GET_CONTEXT = (0x0008),
        SET_CONTEXT = (0x0010),
        SET_INFORMATION = (0x0020),
        QUERY_INFORMATION = (0x0040),
        SET_THREAD_TOKEN = (0x0080),
        IMPERSONATE = (0x0100),
        DIRECT_IMPERSONATION = (0x0200)
    }

    public enum CreateThreadFlags : uint
    {
        Default = 0,
        CREATE_SUSPENDED = 0x00000004,
        STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000
    }

    public enum SnapshotFlags : uint
    {
        HeapList = 0x00000001,
        Process = 0x00000002,
        Thread = 0x00000004,
        Module = 0x00000008,
        Module32 = 0x00000010,
        Inherit = 0x80000000,
        All = 0x0000001F
    }

    public enum PROCESS_MITIGATION_POLICY
    {
        ProcessDEPPolicy = 0,
        ProcessASLRPolicy = 1,
        ProcessReserved1MitigationPolicy = 2,
        ProcessStrictHandleCheckPolicy = 3,
        ProcessSystemCallDisablePolicy = 4,
        MaxProcessMitigationPolicy = 5 
    }

    public enum WaitForSingleObjectFlags : uint
    {
        Infinite = 0xFFFFFFFF,
        Abandoned = 0x00000080,
        Object = 0x00000000,
        Timeout = 0x00000102
    }

    [Flags]
    public enum ProcessAccessFlags : uint
    {
        All = 0x001F0FFF,
        Terminate = 0x00000001,
        CreateThread = 0x00000002,
        VMOperation = 0x00000008,
        VMRead = 0x00000010,
        VMWrite = 0x00000020,
        DupHandle = 0x00000040,
        SetInformation = 0x00000200,
        QueryInformation = 0x00000400,
        Synchronize = 0x00100000,
        MaximumAllowed = 0x2000000
    }

    [Flags]
    public enum MouseEventDataXButtons : uint
    {
        Nothing = 0x00000000,
        XBUTTON1 = 0x00000001,
        XBUTTON2 = 0x00000002
    }
    [Flags]
    public enum MOUSEEVENTF : uint
    {
        ABSOLUTE = 0x8000,
        HWHEEL = 0x01000,
        MOVE = 0x0001,
        MOVE_NOCOALESCE = 0x2000,
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010,
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        VIRTUALDESK = 0x4000,
        WHEEL = 0x0800,
        XDOWN = 0x0080,
        XUP = 0x0100
    }

    public enum KEYEVENTF : uint
    {
        KEYDOWN = 0x0000,
        EXTENDEDKEY = 0x0001,
        KEYUP = 0x0002,
        SCANCODE = 0x0008,
        UNICODE = 0x0004
    }
    [Flags]
    public enum MouseEventFlags : uint
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010,
        WHEEL = 0x00000800,
        XDOWN = 0x00000080,
        XUP = 0x00000100
    }
    [Flags]
    public enum KeyEventFlags : uint
    {
        KeyPress = 1 | 0,
        KeyRelease = 1 | 2
    }

    [Flags]
    public enum LLKHF_Flags
    {
        LLKHF_EXTENDED = 0x01,
        LLKHF_INJECTED = 0x10,
        LLKHF_ALTDOWN = 0x20,
        LLKHF_UP = 0x80,
    }

    [Flags]
    public enum Modifiers
    {
        MOD_ALT = 0x0001,
        MOD_CONTROL = 0x0002,
        MOD_NOREPEAT = 0x4000,
        MOD_SHIFT = 0x0004,
        MOD_WIN = 0x0008
    }

    public enum VirtualKey : uint
    {
        ///<summary>
        ///Left mouse button
        ///</summary>
        LBUTTON = 0x01,
        ///<summary>
        ///Right mouse button
        ///</summary>
        RBUTTON = 0x02,
        ///<summary>
        ///Control-break processing
        ///</summary>
        CANCEL = 0x03,
        ///<summary>
        ///Middle mouse button (three-button mouse)
        ///</summary>
        MBUTTON = 0x04,
        ///<summary>
        ///Windows 2000/XP: X1 mouse button
        ///</summary>
        XBUTTON1 = 0x05,
        ///<summary>
        ///Windows 2000/XP: X2 mouse button
        ///</summary>
        XBUTTON2 = 0x06,
        ///<summary>
        ///BACKSPACE key
        ///</summary>
        BACK = 0x08,
        ///<summary>
        ///TAB key
        ///</summary>
        TAB = 0x09,
        ///<summary>
        ///CLEAR key
        ///</summary>
        CLEAR = 0x0C,
        ///<summary>
        ///ENTER key
        ///</summary>
        RETURN = 0x0D,
        ///<summary>
        ///SHIFT key
        ///</summary>
        SHIFT = 0x10,
        ///<summary>
        ///CTRL key
        ///</summary>
        CONTROL = 0x11,
        ///<summary>
        ///ALT key
        ///</summary>
        MENU = 0x12,
        ///<summary>
        ///PAUSE key
        ///</summary>
        PAUSE = 0x13,
        ///<summary>
        ///CAPS LOCK key
        ///</summary>
        CAPITAL = 0x14,
        ///<summary>
        ///Input Method Editor (IME) Kana mode
        ///</summary>
        KANA = 0x15,
        ///<summary>
        ///IME Hangul mode
        ///</summary>
        HANGUL = 0x15,
        ///<summary>
        ///IME Junja mode
        ///</summary>
        JUNJA = 0x17,
        ///<summary>
        ///IME final mode
        ///</summary>
        FINAL = 0x18,
        ///<summary>
        ///IME Hanja mode
        ///</summary>
        HANJA = 0x19,
        ///<summary>
        ///IME Kanji mode
        ///</summary>
        KANJI = 0x19,
        ///<summary>
        ///ESC key
        ///</summary>
        ESCAPE = 0x1B,
        ///<summary>
        ///IME convert
        ///</summary>
        CONVERT = 0x1C,
        ///<summary>
        ///IME nonconvert
        ///</summary>
        NONCONVERT = 0x1D,
        ///<summary>
        ///IME accept
        ///</summary>
        ACCEPT = 0x1E,
        ///<summary>
        ///IME mode change request
        ///</summary>
        MODECHANGE = 0x1F,
        ///<summary>
        ///SPACEBAR
        ///</summary>
        SPACE = 0x20,
        ///<summary>
        ///PAGE UP key
        ///</summary>
        PRIOR = 0x21,
        ///<summary>
        ///PAGE DOWN key
        ///</summary>
        NEXT = 0x22,
        ///<summary>
        ///END key
        ///</summary>
        END = 0x23,
        ///<summary>
        ///HOME key
        ///</summary>
        HOME = 0x24,
        ///<summary>
        ///LEFT ARROW key
        ///</summary>
        LEFT = 0x25,
        ///<summary>
        ///UP ARROW key
        ///</summary>
        UP = 0x26,
        ///<summary>
        ///RIGHT ARROW key
        ///</summary>
        RIGHT = 0x27,
        ///<summary>
        ///DOWN ARROW key
        ///</summary>
        DOWN = 0x28,
        ///<summary>
        ///SELECT key
        ///</summary>
        SELECT = 0x29,
        ///<summary>
        ///PRINT key
        ///</summary>
        PRINT = 0x2A,
        ///<summary>
        ///EXECUTE key
        ///</summary>
        EXECUTE = 0x2B,
        ///<summary>
        ///PRINT SCREEN key
        ///</summary>
        SNAPSHOT = 0x2C,
        ///<summary>
        ///INS key
        ///</summary>
        INSERT = 0x2D,
        ///<summary>
        ///DEL key
        ///</summary>
        DELETE = 0x2E,
        ///<summary>
        ///HELP key
        ///</summary>
        HELP = 0x2F,
        ///<summary>
        ///0 key
        ///</summary>
        KEY_0 = 0x30,
        ///<summary>
        ///1 key
        ///</summary>
        KEY_1 = 0x31,
        ///<summary>
        ///2 key
        ///</summary>
        KEY_2 = 0x32,
        ///<summary>
        ///3 key
        ///</summary>
        KEY_3 = 0x33,
        ///<summary>
        ///4 key
        ///</summary>
        KEY_4 = 0x34,
        ///<summary>
        ///5 key
        ///</summary>
        KEY_5 = 0x35,
        ///<summary>
        ///6 key
        ///</summary>
        KEY_6 = 0x36,
        ///<summary>
        ///7 key
        ///</summary>
        KEY_7 = 0x37,
        ///<summary>
        ///8 key
        ///</summary>
        KEY_8 = 0x38,
        ///<summary>
        ///9 key
        ///</summary>
        KEY_9 = 0x39,
        ///<summary>
        ///A key
        ///</summary>
        KEY_A = 0x41,
        ///<summary>
        ///B key
        ///</summary>
        KEY_B = 0x42,
        ///<summary>
        ///C key
        ///</summary>
        KEY_C = 0x43,
        ///<summary>
        ///D key
        ///</summary>
        KEY_D = 0x44,
        ///<summary>
        ///E key
        ///</summary>
        KEY_E = 0x45,
        ///<summary>
        ///F key
        ///</summary>
        KEY_F = 0x46,
        ///<summary>
        ///G key
        ///</summary>
        KEY_G = 0x47,
        ///<summary>
        ///H key
        ///</summary>
        KEY_H = 0x48,
        ///<summary>
        ///I key
        ///</summary>
        KEY_I = 0x49,
        ///<summary>
        ///J key
        ///</summary>
        KEY_J = 0x4A,
        ///<summary>
        ///K key
        ///</summary>
        KEY_K = 0x4B,
        ///<summary>
        ///L key
        ///</summary>
        KEY_L = 0x4C,
        ///<summary>
        ///M key
        ///</summary>
        KEY_M = 0x4D,
        ///<summary>
        ///N key
        ///</summary>
        KEY_N = 0x4E,
        ///<summary>
        ///O key
        ///</summary>
        KEY_O = 0x4F,
        ///<summary>
        ///P key
        ///</summary>
        KEY_P = 0x50,
        ///<summary>
        ///Q key
        ///</summary>
        KEY_Q = 0x51,
        ///<summary>
        ///R key
        ///</summary>
        KEY_R = 0x52,
        ///<summary>
        ///S key
        ///</summary>
        KEY_S = 0x53,
        ///<summary>
        ///T key
        ///</summary>
        KEY_T = 0x54,
        ///<summary>
        ///U key
        ///</summary>
        KEY_U = 0x55,
        ///<summary>
        ///V key
        ///</summary>
        KEY_V = 0x56,
        ///<summary>
        ///W key
        ///</summary>
        KEY_W = 0x57,
        ///<summary>
        ///X key
        ///</summary>
        KEY_X = 0x58,
        ///<summary>
        ///Y key
        ///</summary>
        KEY_Y = 0x59,
        ///<summary>
        ///Z key
        ///</summary>
        KEY_Z = 0x5A,
        ///<summary>
        ///Left Windows key (Microsoft Natural keyboard) 
        ///</summary>
        LWIN = 0x5B,
        ///<summary>
        ///Right Windows key (Natural keyboard)
        ///</summary>
        RWIN = 0x5C,
        ///<summary>
        ///Applications key (Natural keyboard)
        ///</summary>
        APPS = 0x5D,
        ///<summary>
        ///Computer Sleep key
        ///</summary>
        SLEEP = 0x5F,
        ///<summary>
        ///Numeric keypad 0 key
        ///</summary>
        NUMPAD0 = 0x60,
        ///<summary>
        ///Numeric keypad 1 key
        ///</summary>
        NUMPAD1 = 0x61,
        ///<summary>
        ///Numeric keypad 2 key
        ///</summary>
        NUMPAD2 = 0x62,
        ///<summary>
        ///Numeric keypad 3 key
        ///</summary>
        NUMPAD3 = 0x63,
        ///<summary>
        ///Numeric keypad 4 key
        ///</summary>
        NUMPAD4 = 0x64,
        ///<summary>
        ///Numeric keypad 5 key
        ///</summary>
        NUMPAD5 = 0x65,
        ///<summary>
        ///Numeric keypad 6 key
        ///</summary>
        NUMPAD6 = 0x66,
        ///<summary>
        ///Numeric keypad 7 key
        ///</summary>
        NUMPAD7 = 0x67,
        ///<summary>
        ///Numeric keypad 8 key
        ///</summary>
        NUMPAD8 = 0x68,
        ///<summary>
        ///Numeric keypad 9 key
        ///</summary>
        NUMPAD9 = 0x69,
        ///<summary>
        ///Multiply key
        ///</summary>
        MULTIPLY = 0x6A,
        ///<summary>
        ///Add key
        ///</summary>
        ADD = 0x6B,
        ///<summary>
        ///Separator key
        ///</summary>
        SEPARATOR = 0x6C,
        ///<summary>
        ///Subtract key
        ///</summary>
        SUBTRACT = 0x6D,
        ///<summary>
        ///Decimal key
        ///</summary>
        DECIMAL = 0x6E,
        ///<summary>
        ///Divide key
        ///</summary>
        DIVIDE = 0x6F,
        ///<summary>
        ///F1 key
        ///</summary>
        F1 = 0x70,
        ///<summary>
        ///F2 key
        ///</summary>
        F2 = 0x71,
        ///<summary>
        ///F3 key
        ///</summary>
        F3 = 0x72,
        ///<summary>
        ///F4 key
        ///</summary>
        F4 = 0x73,
        ///<summary>
        ///F5 key
        ///</summary>
        F5 = 0x74,
        ///<summary>
        ///F6 key
        ///</summary>
        F6 = 0x75,
        ///<summary>
        ///F7 key
        ///</summary>
        F7 = 0x76,
        ///<summary>
        ///F8 key
        ///</summary>
        F8 = 0x77,
        ///<summary>
        ///F9 key
        ///</summary>
        F9 = 0x78,
        ///<summary>
        ///F10 key
        ///</summary>
        F10 = 0x79,
        ///<summary>
        ///F11 key
        ///</summary>
        F11 = 0x7A,
        ///<summary>
        ///F12 key
        ///</summary>
        F12 = 0x7B,
        ///<summary>
        ///F13 key
        ///</summary>
        F13 = 0x7C,
        ///<summary>
        ///F14 key
        ///</summary>
        F14 = 0x7D,
        ///<summary>
        ///F15 key
        ///</summary>
        F15 = 0x7E,
        ///<summary>
        ///F16 key
        ///</summary>
        F16 = 0x7F,
        ///<summary>
        ///F17 key  
        ///</summary>
        F17 = 0x80,
        ///<summary>
        ///F18 key  
        ///</summary>
        F18 = 0x81,
        ///<summary>
        ///F19 key  
        ///</summary>
        F19 = 0x82,
        ///<summary>
        ///F20 key  
        ///</summary>
        F20 = 0x83,
        ///<summary>
        ///F21 key  
        ///</summary>
        F21 = 0x84,
        ///<summary>
        ///F22 key, (PPC only) Key used to lock device.
        ///</summary>
        F22 = 0x85,
        ///<summary>
        ///F23 key  
        ///</summary>
        F23 = 0x86,
        ///<summary>
        ///F24 key  
        ///</summary>
        F24 = 0x87,
        ///<summary>
        ///NUM LOCK key
        ///</summary>
        NUMLOCK = 0x90,
        ///<summary>
        ///SCROLL LOCK key
        ///</summary>
        SCROLL = 0x91,
        ///<summary>
        ///Left SHIFT key
        ///</summary>
        LSHIFT = 0xA0,
        ///<summary>
        ///Right SHIFT key
        ///</summary>
        RSHIFT = 0xA1,
        ///<summary>
        ///Left CONTROL key
        ///</summary>
        LCONTROL = 0xA2,
        ///<summary>
        ///Right CONTROL key
        ///</summary>
        RCONTROL = 0xA3,
        ///<summary>
        ///Left MENU key
        ///</summary>
        LMENU = 0xA4,
        ///<summary>
        ///Right MENU key
        ///</summary>
        RMENU = 0xA5,
        ///<summary>
        ///Windows 2000/XP: Browser Back key
        ///</summary>
        BROWSER_BACK = 0xA6,
        ///<summary>
        ///Windows 2000/XP: Browser Forward key
        ///</summary>
        BROWSER_FORWARD = 0xA7,
        ///<summary>
        ///Windows 2000/XP: Browser Refresh key
        ///</summary>
        BROWSER_REFRESH = 0xA8,
        ///<summary>
        ///Windows 2000/XP: Browser Stop key
        ///</summary>
        BROWSER_STOP = 0xA9,
        ///<summary>
        ///Windows 2000/XP: Browser Search key 
        ///</summary>
        BROWSER_SEARCH = 0xAA,
        ///<summary>
        ///Windows 2000/XP: Browser Favorites key
        ///</summary>
        BROWSER_FAVORITES = 0xAB,
        ///<summary>
        ///Windows 2000/XP: Browser Start and Home key
        ///</summary>
        BROWSER_HOME = 0xAC,
        ///<summary>
        ///Windows 2000/XP: Volume Mute key
        ///</summary>
        VOLUME_MUTE = 0xAD,
        ///<summary>
        ///Windows 2000/XP: Volume Down key
        ///</summary>
        VOLUME_DOWN = 0xAE,
        ///<summary>
        ///Windows 2000/XP: Volume Up key
        ///</summary>
        VOLUME_UP = 0xAF,
        ///<summary>
        ///Windows 2000/XP: Next Track key
        ///</summary>
        MEDIA_NEXT_TRACK = 0xB0,
        ///<summary>
        ///Windows 2000/XP: Previous Track key
        ///</summary>
        MEDIA_PREV_TRACK = 0xB1,
        ///<summary>
        ///Windows 2000/XP: Stop Media key
        ///</summary>
        MEDIA_STOP = 0xB2,
        ///<summary>
        ///Windows 2000/XP: Play/Pause Media key
        ///</summary>
        MEDIA_PLAY_PAUSE = 0xB3,
        ///<summary>
        ///Windows 2000/XP: Start Mail key
        ///</summary>
        LAUNCH_MAIL = 0xB4,
        ///<summary>
        ///Windows 2000/XP: Select Media key
        ///</summary>
        LAUNCH_MEDIA_SELECT = 0xB5,
        ///<summary>
        ///Windows 2000/XP: Start Application 1 key
        ///</summary>
        LAUNCH_APP1 = 0xB6,
        ///<summary>
        ///Windows 2000/XP: Start Application 2 key
        ///</summary>
        LAUNCH_APP2 = 0xB7,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_1 = 0xBA,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '+' key
        ///</summary>
        OEM_PLUS = 0xBB,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the ',' key
        ///</summary>
        OEM_COMMA = 0xBC,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '-' key
        ///</summary>
        OEM_MINUS = 0xBD,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '.' key
        ///</summary>
        OEM_PERIOD = 0xBE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_2 = 0xBF,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_3 = 0xC0,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_4 = 0xDB,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_5 = 0xDC,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_6 = 0xDD,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_7 = 0xDE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_8 = 0xDF,
        ///<summary>
        ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///</summary>
        OEM_102 = 0xE2,
        ///<summary>
        ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        ///</summary>
        PROCESSKEY = 0xE5,
        ///<summary>
        ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
        ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///</summary>
        PACKET = 0xE7,
        ///<summary>
        ///Attn key
        ///</summary>
        ATTN = 0xF6,
        ///<summary>
        ///CrSel key
        ///</summary>
        CRSEL = 0xF7,
        ///<summary>
        ///ExSel key
        ///</summary>
        EXSEL = 0xF8,
        ///<summary>
        ///Erase EOF key
        ///</summary>
        EREOF = 0xF9,
        ///<summary>
        ///Play key
        ///</summary>
        PLAY = 0xFA,
        ///<summary>
        ///Zoom key
        ///</summary>
        ZOOM = 0xFB,
        ///<summary>
        ///Reserved 
        ///</summary>
        NONAME = 0xFC,
        ///<summary>
        ///PA1 key
        ///</summary>
        PA1 = 0xFD,
        ///<summary>
        ///Clear key
        ///</summary>
        OEM_CLEAR = 0xFE
    }
    public enum ScanCode : uint
    {
        LBUTTON = 0,
        RBUTTON = 0,
        CANCEL = 70,
        MBUTTON = 0,
        XBUTTON1 = 0,
        XBUTTON2 = 0,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        PAUSE = 0,
        CAPITAL = 58,
        KANA = 0,
        HANGUL = 0,
        JUNJA = 0,
        FINAL = 0,
        HANJA = 0,
        KANJI = 0,
        ESCAPE = 1,
        CONVERT = 0,
        NONCONVERT = 0,
        ACCEPT = 0,
        MODECHANGE = 0,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 75,
        UP = 72,
        RIGHT = 77,
        DOWN = 80,
        SELECT = 0,
        PRINT = 0,
        EXECUTE = 0,
        SNAPSHOT = 84,
        INSERT = 82,
        DELETE = 83,
        HELP = 99,
        KEY_0 = 11,
        KEY_1 = 2,
        KEY_2 = 3,
        KEY_3 = 4,
        KEY_4 = 5,
        KEY_5 = 6,
        KEY_6 = 7,
        KEY_7 = 8,
        KEY_8 = 9,
        KEY_9 = 10,
        KEY_A = 30,
        KEY_B = 48,
        KEY_C = 46,
        KEY_D = 32,
        KEY_E = 18,
        KEY_F = 33,
        KEY_G = 34,
        KEY_H = 35,
        KEY_I = 23,
        KEY_J = 36,
        KEY_K = 37,
        KEY_L = 38,
        KEY_M = 50,
        KEY_N = 49,
        KEY_O = 24,
        KEY_P = 25,
        KEY_Q = 16,
        KEY_R = 19,
        KEY_S = 31,
        KEY_T = 20,
        KEY_U = 22,
        KEY_V = 47,
        KEY_W = 17,
        KEY_X = 45,
        KEY_Y = 21,
        KEY_Z = 44,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SEPARATOR = 0,
        SUBTRACT = 74,
        DECIMAL = 83,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        F16 = 103,
        F17 = 104,
        F18 = 105,
        F19 = 106,
        F20 = 107,
        F21 = 108,
        F22 = 109,
        F23 = 110,
        F24 = 118,
        NUMLOCK = 69,
        SCROLL = 70,
        LSHIFT = 42,
        RSHIFT = 54,
        LCONTROL = 29,
        RCONTROL = 29,
        LMENU = 56,
        RMENU = 56,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 39,
        OEM_PLUS = 13,
        OEM_COMMA = 51,
        OEM_MINUS = 12,
        OEM_PERIOD = 52,
        OEM_2 = 53,
        OEM_3 = 41,
        OEM_4 = 26,
        OEM_5 = 43,
        OEM_6 = 27,
        OEM_7 = 40,
        OEM_8 = 0,
        OEM_102 = 86,
        PROCESSKEY = 0,
        PACKET = 0,
        ATTN = 0,
        CRSEL = 0,
        EXSEL = 0,
        EREOF = 93,
        PLAY = 0,
        ZOOM = 98,
        NONAME = 0,
        PA1 = 0,
        OEM_CLEAR = 0,
    }

    public enum VirtualKeyShort : short
    {
        ///<summary>
        ///Left mouse button
        ///</summary>
        LBUTTON = 0x01,
        ///<summary>
        ///Right mouse button
        ///</summary>
        RBUTTON = 0x02,
        ///<summary>
        ///Control-break processing
        ///</summary>
        CANCEL = 0x03,
        ///<summary>
        ///Middle mouse button (three-button mouse)
        ///</summary>
        MBUTTON = 0x04,
        ///<summary>
        ///Windows 2000/XP: X1 mouse button
        ///</summary>
        XBUTTON1 = 0x05,
        ///<summary>
        ///Windows 2000/XP: X2 mouse button
        ///</summary>
        XBUTTON2 = 0x06,
        ///<summary>
        ///BACKSPACE key
        ///</summary>
        BACK = 0x08,
        ///<summary>
        ///TAB key
        ///</summary>
        TAB = 0x09,
        ///<summary>
        ///CLEAR key
        ///</summary>
        CLEAR = 0x0C,
        ///<summary>
        ///ENTER key
        ///</summary>
        RETURN = 0x0D,
        ///<summary>
        ///SHIFT key
        ///</summary>
        SHIFT = 0x10,
        ///<summary>
        ///CTRL key
        ///</summary>
        CONTROL = 0x11,
        ///<summary>
        ///ALT key
        ///</summary>
        MENU = 0x12,
        ///<summary>
        ///PAUSE key
        ///</summary>
        PAUSE = 0x13,
        ///<summary>
        ///CAPS LOCK key
        ///</summary>
        CAPITAL = 0x14,
        ///<summary>
        ///Input Method Editor (IME) Kana mode
        ///</summary>
        KANA = 0x15,
        ///<summary>
        ///IME Hangul mode
        ///</summary>
        HANGUL = 0x15,
        ///<summary>
        ///IME Junja mode
        ///</summary>
        JUNJA = 0x17,
        ///<summary>
        ///IME final mode
        ///</summary>
        FINAL = 0x18,
        ///<summary>
        ///IME Hanja mode
        ///</summary>
        HANJA = 0x19,
        ///<summary>
        ///IME Kanji mode
        ///</summary>
        KANJI = 0x19,
        ///<summary>
        ///ESC key
        ///</summary>
        ESCAPE = 0x1B,
        ///<summary>
        ///IME convert
        ///</summary>
        CONVERT = 0x1C,
        ///<summary>
        ///IME nonconvert
        ///</summary>
        NONCONVERT = 0x1D,
        ///<summary>
        ///IME accept
        ///</summary>
        ACCEPT = 0x1E,
        ///<summary>
        ///IME mode change request
        ///</summary>
        MODECHANGE = 0x1F,
        ///<summary>
        ///SPACEBAR
        ///</summary>
        SPACE = 0x20,
        ///<summary>
        ///PAGE UP key
        ///</summary>
        PRIOR = 0x21,
        ///<summary>
        ///PAGE DOWN key
        ///</summary>
        NEXT = 0x22,
        ///<summary>
        ///END key
        ///</summary>
        END = 0x23,
        ///<summary>
        ///HOME key
        ///</summary>
        HOME = 0x24,
        ///<summary>
        ///LEFT ARROW key
        ///</summary>
        LEFT = 0x25,
        ///<summary>
        ///UP ARROW key
        ///</summary>
        UP = 0x26,
        ///<summary>
        ///RIGHT ARROW key
        ///</summary>
        RIGHT = 0x27,
        ///<summary>
        ///DOWN ARROW key
        ///</summary>
        DOWN = 0x28,
        ///<summary>
        ///SELECT key
        ///</summary>
        SELECT = 0x29,
        ///<summary>
        ///PRINT key
        ///</summary>
        PRINT = 0x2A,
        ///<summary>
        ///EXECUTE key
        ///</summary>
        EXECUTE = 0x2B,
        ///<summary>
        ///PRINT SCREEN key
        ///</summary>
        SNAPSHOT = 0x2C,
        ///<summary>
        ///INS key
        ///</summary>
        INSERT = 0x2D,
        ///<summary>
        ///DEL key
        ///</summary>
        DELETE = 0x2E,
        ///<summary>
        ///HELP key
        ///</summary>
        HELP = 0x2F,
        ///<summary>
        ///0 key
        ///</summary>
        KEY_0 = 0x30,
        ///<summary>
        ///1 key
        ///</summary>
        KEY_1 = 0x31,
        ///<summary>
        ///2 key
        ///</summary>
        KEY_2 = 0x32,
        ///<summary>
        ///3 key
        ///</summary>
        KEY_3 = 0x33,
        ///<summary>
        ///4 key
        ///</summary>
        KEY_4 = 0x34,
        ///<summary>
        ///5 key
        ///</summary>
        KEY_5 = 0x35,
        ///<summary>
        ///6 key
        ///</summary>
        KEY_6 = 0x36,
        ///<summary>
        ///7 key
        ///</summary>
        KEY_7 = 0x37,
        ///<summary>
        ///8 key
        ///</summary>
        KEY_8 = 0x38,
        ///<summary>
        ///9 key
        ///</summary>
        KEY_9 = 0x39,
        ///<summary>
        ///A key
        ///</summary>
        KEY_A = 0x41,
        ///<summary>
        ///B key
        ///</summary>
        KEY_B = 0x42,
        ///<summary>
        ///C key
        ///</summary>
        KEY_C = 0x43,
        ///<summary>
        ///D key
        ///</summary>
        KEY_D = 0x44,
        ///<summary>
        ///E key
        ///</summary>
        KEY_E = 0x45,
        ///<summary>
        ///F key
        ///</summary>
        KEY_F = 0x46,
        ///<summary>
        ///G key
        ///</summary>
        KEY_G = 0x47,
        ///<summary>
        ///H key
        ///</summary>
        KEY_H = 0x48,
        ///<summary>
        ///I key
        ///</summary>
        KEY_I = 0x49,
        ///<summary>
        ///J key
        ///</summary>
        KEY_J = 0x4A,
        ///<summary>
        ///K key
        ///</summary>
        KEY_K = 0x4B,
        ///<summary>
        ///L key
        ///</summary>
        KEY_L = 0x4C,
        ///<summary>
        ///M key
        ///</summary>
        KEY_M = 0x4D,
        ///<summary>
        ///N key
        ///</summary>
        KEY_N = 0x4E,
        ///<summary>
        ///O key
        ///</summary>
        KEY_O = 0x4F,
        ///<summary>
        ///P key
        ///</summary>
        KEY_P = 0x50,
        ///<summary>
        ///Q key
        ///</summary>
        KEY_Q = 0x51,
        ///<summary>
        ///R key
        ///</summary>
        KEY_R = 0x52,
        ///<summary>
        ///S key
        ///</summary>
        KEY_S = 0x53,
        ///<summary>
        ///T key
        ///</summary>
        KEY_T = 0x54,
        ///<summary>
        ///U key
        ///</summary>
        KEY_U = 0x55,
        ///<summary>
        ///V key
        ///</summary>
        KEY_V = 0x56,
        ///<summary>
        ///W key
        ///</summary>
        KEY_W = 0x57,
        ///<summary>
        ///X key
        ///</summary>
        KEY_X = 0x58,
        ///<summary>
        ///Y key
        ///</summary>
        KEY_Y = 0x59,
        ///<summary>
        ///Z key
        ///</summary>
        KEY_Z = 0x5A,
        ///<summary>
        ///Left Windows key (Microsoft Natural keyboard) 
        ///</summary>
        LWIN = 0x5B,
        ///<summary>
        ///Right Windows key (Natural keyboard)
        ///</summary>
        RWIN = 0x5C,
        ///<summary>
        ///Applications key (Natural keyboard)
        ///</summary>
        APPS = 0x5D,
        ///<summary>
        ///Computer Sleep key
        ///</summary>
        SLEEP = 0x5F,
        ///<summary>
        ///Numeric keypad 0 key
        ///</summary>
        NUMPAD0 = 0x60,
        ///<summary>
        ///Numeric keypad 1 key
        ///</summary>
        NUMPAD1 = 0x61,
        ///<summary>
        ///Numeric keypad 2 key
        ///</summary>
        NUMPAD2 = 0x62,
        ///<summary>
        ///Numeric keypad 3 key
        ///</summary>
        NUMPAD3 = 0x63,
        ///<summary>
        ///Numeric keypad 4 key
        ///</summary>
        NUMPAD4 = 0x64,
        ///<summary>
        ///Numeric keypad 5 key
        ///</summary>
        NUMPAD5 = 0x65,
        ///<summary>
        ///Numeric keypad 6 key
        ///</summary>
        NUMPAD6 = 0x66,
        ///<summary>
        ///Numeric keypad 7 key
        ///</summary>
        NUMPAD7 = 0x67,
        ///<summary>
        ///Numeric keypad 8 key
        ///</summary>
        NUMPAD8 = 0x68,
        ///<summary>
        ///Numeric keypad 9 key
        ///</summary>
        NUMPAD9 = 0x69,
        ///<summary>
        ///Multiply key
        ///</summary>
        MULTIPLY = 0x6A,
        ///<summary>
        ///Add key
        ///</summary>
        ADD = 0x6B,
        ///<summary>
        ///Separator key
        ///</summary>
        SEPARATOR = 0x6C,
        ///<summary>
        ///Subtract key
        ///</summary>
        SUBTRACT = 0x6D,
        ///<summary>
        ///Decimal key
        ///</summary>
        DECIMAL = 0x6E,
        ///<summary>
        ///Divide key
        ///</summary>
        DIVIDE = 0x6F,
        ///<summary>
        ///F1 key
        ///</summary>
        F1 = 0x70,
        ///<summary>
        ///F2 key
        ///</summary>
        F2 = 0x71,
        ///<summary>
        ///F3 key
        ///</summary>
        F3 = 0x72,
        ///<summary>
        ///F4 key
        ///</summary>
        F4 = 0x73,
        ///<summary>
        ///F5 key
        ///</summary>
        F5 = 0x74,
        ///<summary>
        ///F6 key
        ///</summary>
        F6 = 0x75,
        ///<summary>
        ///F7 key
        ///</summary>
        F7 = 0x76,
        ///<summary>
        ///F8 key
        ///</summary>
        F8 = 0x77,
        ///<summary>
        ///F9 key
        ///</summary>
        F9 = 0x78,
        ///<summary>
        ///F10 key
        ///</summary>
        F10 = 0x79,
        ///<summary>
        ///F11 key
        ///</summary>
        F11 = 0x7A,
        ///<summary>
        ///F12 key
        ///</summary>
        F12 = 0x7B,
        ///<summary>
        ///F13 key
        ///</summary>
        F13 = 0x7C,
        ///<summary>
        ///F14 key
        ///</summary>
        F14 = 0x7D,
        ///<summary>
        ///F15 key
        ///</summary>
        F15 = 0x7E,
        ///<summary>
        ///F16 key
        ///</summary>
        F16 = 0x7F,
        ///<summary>
        ///F17 key  
        ///</summary>
        F17 = 0x80,
        ///<summary>
        ///F18 key  
        ///</summary>
        F18 = 0x81,
        ///<summary>
        ///F19 key  
        ///</summary>
        F19 = 0x82,
        ///<summary>
        ///F20 key  
        ///</summary>
        F20 = 0x83,
        ///<summary>
        ///F21 key  
        ///</summary>
        F21 = 0x84,
        ///<summary>
        ///F22 key, (PPC only) Key used to lock device.
        ///</summary>
        F22 = 0x85,
        ///<summary>
        ///F23 key  
        ///</summary>
        F23 = 0x86,
        ///<summary>
        ///F24 key  
        ///</summary>
        F24 = 0x87,
        ///<summary>
        ///NUM LOCK key
        ///</summary>
        NUMLOCK = 0x90,
        ///<summary>
        ///SCROLL LOCK key
        ///</summary>
        SCROLL = 0x91,
        ///<summary>
        ///Left SHIFT key
        ///</summary>
        LSHIFT = 0xA0,
        ///<summary>
        ///Right SHIFT key
        ///</summary>
        RSHIFT = 0xA1,
        ///<summary>
        ///Left CONTROL key
        ///</summary>
        LCONTROL = 0xA2,
        ///<summary>
        ///Right CONTROL key
        ///</summary>
        RCONTROL = 0xA3,
        ///<summary>
        ///Left MENU key
        ///</summary>
        LMENU = 0xA4,
        ///<summary>
        ///Right MENU key
        ///</summary>
        RMENU = 0xA5,
        ///<summary>
        ///Windows 2000/XP: Browser Back key
        ///</summary>
        BROWSER_BACK = 0xA6,
        ///<summary>
        ///Windows 2000/XP: Browser Forward key
        ///</summary>
        BROWSER_FORWARD = 0xA7,
        ///<summary>
        ///Windows 2000/XP: Browser Refresh key
        ///</summary>
        BROWSER_REFRESH = 0xA8,
        ///<summary>
        ///Windows 2000/XP: Browser Stop key
        ///</summary>
        BROWSER_STOP = 0xA9,
        ///<summary>
        ///Windows 2000/XP: Browser Search key 
        ///</summary>
        BROWSER_SEARCH = 0xAA,
        ///<summary>
        ///Windows 2000/XP: Browser Favorites key
        ///</summary>
        BROWSER_FAVORITES = 0xAB,
        ///<summary>
        ///Windows 2000/XP: Browser Start and Home key
        ///</summary>
        BROWSER_HOME = 0xAC,
        ///<summary>
        ///Windows 2000/XP: Volume Mute key
        ///</summary>
        VOLUME_MUTE = 0xAD,
        ///<summary>
        ///Windows 2000/XP: Volume Down key
        ///</summary>
        VOLUME_DOWN = 0xAE,
        ///<summary>
        ///Windows 2000/XP: Volume Up key
        ///</summary>
        VOLUME_UP = 0xAF,
        ///<summary>
        ///Windows 2000/XP: Next Track key
        ///</summary>
        MEDIA_NEXT_TRACK = 0xB0,
        ///<summary>
        ///Windows 2000/XP: Previous Track key
        ///</summary>
        MEDIA_PREV_TRACK = 0xB1,
        ///<summary>
        ///Windows 2000/XP: Stop Media key
        ///</summary>
        MEDIA_STOP = 0xB2,
        ///<summary>
        ///Windows 2000/XP: Play/Pause Media key
        ///</summary>
        MEDIA_PLAY_PAUSE = 0xB3,
        ///<summary>
        ///Windows 2000/XP: Start Mail key
        ///</summary>
        LAUNCH_MAIL = 0xB4,
        ///<summary>
        ///Windows 2000/XP: Select Media key
        ///</summary>
        LAUNCH_MEDIA_SELECT = 0xB5,
        ///<summary>
        ///Windows 2000/XP: Start Application 1 key
        ///</summary>
        LAUNCH_APP1 = 0xB6,
        ///<summary>
        ///Windows 2000/XP: Start Application 2 key
        ///</summary>
        LAUNCH_APP2 = 0xB7,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_1 = 0xBA,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '+' key
        ///</summary>
        OEM_PLUS = 0xBB,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the ',' key
        ///</summary>
        OEM_COMMA = 0xBC,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '-' key
        ///</summary>
        OEM_MINUS = 0xBD,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '.' key
        ///</summary>
        OEM_PERIOD = 0xBE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_2 = 0xBF,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_3 = 0xC0,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_4 = 0xDB,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_5 = 0xDC,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_6 = 0xDD,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_7 = 0xDE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_8 = 0xDF,
        ///<summary>
        ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///</summary>
        OEM_102 = 0xE2,
        ///<summary>
        ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        ///</summary>
        PROCESSKEY = 0xE5,
        ///<summary>
        ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
        ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///</summary>
        PACKET = 0xE7,
        ///<summary>
        ///Attn key
        ///</summary>
        ATTN = 0xF6,
        ///<summary>
        ///CrSel key
        ///</summary>
        CRSEL = 0xF7,
        ///<summary>
        ///ExSel key
        ///</summary>
        EXSEL = 0xF8,
        ///<summary>
        ///Erase EOF key
        ///</summary>
        EREOF = 0xF9,
        ///<summary>
        ///Play key
        ///</summary>
        PLAY = 0xFA,
        ///<summary>
        ///Zoom key
        ///</summary>
        ZOOM = 0xFB,
        ///<summary>
        ///Reserved 
        ///</summary>
        NONAME = 0xFC,
        ///<summary>
        ///PA1 key
        ///</summary>
        PA1 = 0xFD,
        ///<summary>
        ///Clear key
        ///</summary>
        OEM_CLEAR = 0xFE
    }
    public enum ScanCodeShort : short
    {
        LBUTTON = 0,
        RBUTTON = 0,
        CANCEL = 70,
        MBUTTON = 0,
        XBUTTON1 = 0,
        XBUTTON2 = 0,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        PAUSE = 0,
        CAPITAL = 58,
        KANA = 0,
        HANGUL = 0,
        JUNJA = 0,
        FINAL = 0,
        HANJA = 0,
        KANJI = 0,
        ESCAPE = 1,
        CONVERT = 0,
        NONCONVERT = 0,
        ACCEPT = 0,
        MODECHANGE = 0,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 75,
        UP = 72,
        RIGHT = 77,
        DOWN = 80,
        SELECT = 0,
        PRINT = 0,
        EXECUTE = 0,
        SNAPSHOT = 84,
        INSERT = 82,
        DELETE = 83,
        HELP = 99,
        KEY_0 = 11,
        KEY_1 = 2,
        KEY_2 = 3,
        KEY_3 = 4,
        KEY_4 = 5,
        KEY_5 = 6,
        KEY_6 = 7,
        KEY_7 = 8,
        KEY_8 = 9,
        KEY_9 = 10,
        KEY_A = 30,
        KEY_B = 48,
        KEY_C = 46,
        KEY_D = 32,
        KEY_E = 18,
        KEY_F = 33,
        KEY_G = 34,
        KEY_H = 35,
        KEY_I = 23,
        KEY_J = 36,
        KEY_K = 37,
        KEY_L = 38,
        KEY_M = 50,
        KEY_N = 49,
        KEY_O = 24,
        KEY_P = 25,
        KEY_Q = 16,
        KEY_R = 19,
        KEY_S = 31,
        KEY_T = 20,
        KEY_U = 22,
        KEY_V = 47,
        KEY_W = 17,
        KEY_X = 45,
        KEY_Y = 21,
        KEY_Z = 44,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SEPARATOR = 0,
        SUBTRACT = 74,
        DECIMAL = 83,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        F16 = 103,
        F17 = 104,
        F18 = 105,
        F19 = 106,
        F20 = 107,
        F21 = 108,
        F22 = 109,
        F23 = 110,
        F24 = 118,
        NUMLOCK = 69,
        SCROLL = 70,
        LSHIFT = 42,
        RSHIFT = 54,
        LCONTROL = 29,
        RCONTROL = 29,
        LMENU = 56,
        RMENU = 56,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 39,
        OEM_PLUS = 13,
        OEM_COMMA = 51,
        OEM_MINUS = 12,
        OEM_PERIOD = 52,
        OEM_2 = 53,
        OEM_3 = 41,
        OEM_4 = 26,
        OEM_5 = 43,
        OEM_6 = 27,
        OEM_7 = 40,
        OEM_8 = 0,
        OEM_102 = 86,
        PROCESSKEY = 0,
        PACKET = 0,
        ATTN = 0,
        CRSEL = 0,
        EXSEL = 0,
        EREOF = 93,
        PLAY = 0,
        ZOOM = 98,
        NONAME = 0,
        PA1 = 0,
        OEM_CLEAR = 0,
    }

    public enum VirtualKeyByte : byte
    {
        ///<summary>
        ///Left mouse button
        ///</summary>
        LBUTTON = 0x01,
        ///<summary>
        ///Right mouse button
        ///</summary>
        RBUTTON = 0x02,
        ///<summary>
        ///Control-break processing
        ///</summary>
        CANCEL = 0x03,
        ///<summary>
        ///Middle mouse button (three-button mouse)
        ///</summary>
        MBUTTON = 0x04,
        ///<summary>
        ///Windows 2000/XP: X1 mouse button
        ///</summary>
        XBUTTON1 = 0x05,
        ///<summary>
        ///Windows 2000/XP: X2 mouse button
        ///</summary>
        XBUTTON2 = 0x06,
        ///<summary>
        ///BACKSPACE key
        ///</summary>
        BACK = 0x08,
        ///<summary>
        ///TAB key
        ///</summary>
        TAB = 0x09,
        ///<summary>
        ///CLEAR key
        ///</summary>
        CLEAR = 0x0C,
        ///<summary>
        ///ENTER key
        ///</summary>
        RETURN = 0x0D,
        ///<summary>
        ///SHIFT key
        ///</summary>
        SHIFT = 0x10,
        ///<summary>
        ///CTRL key
        ///</summary>
        CONTROL = 0x11,
        ///<summary>
        ///ALT key
        ///</summary>
        MENU = 0x12,
        ///<summary>
        ///PAUSE key
        ///</summary>
        PAUSE = 0x13,
        ///<summary>
        ///CAPS LOCK key
        ///</summary>
        CAPITAL = 0x14,
        ///<summary>
        ///Input Method Editor (IME) Kana mode
        ///</summary>
        KANA = 0x15,
        ///<summary>
        ///IME Hangul mode
        ///</summary>
        HANGUL = 0x15,
        ///<summary>
        ///IME Junja mode
        ///</summary>
        JUNJA = 0x17,
        ///<summary>
        ///IME final mode
        ///</summary>
        FINAL = 0x18,
        ///<summary>
        ///IME Hanja mode
        ///</summary>
        HANJA = 0x19,
        ///<summary>
        ///IME Kanji mode
        ///</summary>
        KANJI = 0x19,
        ///<summary>
        ///ESC key
        ///</summary>
        ESCAPE = 0x1B,
        ///<summary>
        ///IME convert
        ///</summary>
        CONVERT = 0x1C,
        ///<summary>
        ///IME nonconvert
        ///</summary>
        NONCONVERT = 0x1D,
        ///<summary>
        ///IME accept
        ///</summary>
        ACCEPT = 0x1E,
        ///<summary>
        ///IME mode change request
        ///</summary>
        MODECHANGE = 0x1F,
        ///<summary>
        ///SPACEBAR
        ///</summary>
        SPACE = 0x20,
        ///<summary>
        ///PAGE UP key
        ///</summary>
        PRIOR = 0x21,
        ///<summary>
        ///PAGE DOWN key
        ///</summary>
        NEXT = 0x22,
        ///<summary>
        ///END key
        ///</summary>
        END = 0x23,
        ///<summary>
        ///HOME key
        ///</summary>
        HOME = 0x24,
        ///<summary>
        ///LEFT ARROW key
        ///</summary>
        LEFT = 0x25,
        ///<summary>
        ///UP ARROW key
        ///</summary>
        UP = 0x26,
        ///<summary>
        ///RIGHT ARROW key
        ///</summary>
        RIGHT = 0x27,
        ///<summary>
        ///DOWN ARROW key
        ///</summary>
        DOWN = 0x28,
        ///<summary>
        ///SELECT key
        ///</summary>
        SELECT = 0x29,
        ///<summary>
        ///PRINT key
        ///</summary>
        PRINT = 0x2A,
        ///<summary>
        ///EXECUTE key
        ///</summary>
        EXECUTE = 0x2B,
        ///<summary>
        ///PRINT SCREEN key
        ///</summary>
        SNAPSHOT = 0x2C,
        ///<summary>
        ///INS key
        ///</summary>
        INSERT = 0x2D,
        ///<summary>
        ///DEL key
        ///</summary>
        DELETE = 0x2E,
        ///<summary>
        ///HELP key
        ///</summary>
        HELP = 0x2F,
        ///<summary>
        ///0 key
        ///</summary>
        KEY_0 = 0x30,
        ///<summary>
        ///1 key
        ///</summary>
        KEY_1 = 0x31,
        ///<summary>
        ///2 key
        ///</summary>
        KEY_2 = 0x32,
        ///<summary>
        ///3 key
        ///</summary>
        KEY_3 = 0x33,
        ///<summary>
        ///4 key
        ///</summary>
        KEY_4 = 0x34,
        ///<summary>
        ///5 key
        ///</summary>
        KEY_5 = 0x35,
        ///<summary>
        ///6 key
        ///</summary>
        KEY_6 = 0x36,
        ///<summary>
        ///7 key
        ///</summary>
        KEY_7 = 0x37,
        ///<summary>
        ///8 key
        ///</summary>
        KEY_8 = 0x38,
        ///<summary>
        ///9 key
        ///</summary>
        KEY_9 = 0x39,
        ///<summary>
        ///A key
        ///</summary>
        KEY_A = 0x41,
        ///<summary>
        ///B key
        ///</summary>
        KEY_B = 0x42,
        ///<summary>
        ///C key
        ///</summary>
        KEY_C = 0x43,
        ///<summary>
        ///D key
        ///</summary>
        KEY_D = 0x44,
        ///<summary>
        ///E key
        ///</summary>
        KEY_E = 0x45,
        ///<summary>
        ///F key
        ///</summary>
        KEY_F = 0x46,
        ///<summary>
        ///G key
        ///</summary>
        KEY_G = 0x47,
        ///<summary>
        ///H key
        ///</summary>
        KEY_H = 0x48,
        ///<summary>
        ///I key
        ///</summary>
        KEY_I = 0x49,
        ///<summary>
        ///J key
        ///</summary>
        KEY_J = 0x4A,
        ///<summary>
        ///K key
        ///</summary>
        KEY_K = 0x4B,
        ///<summary>
        ///L key
        ///</summary>
        KEY_L = 0x4C,
        ///<summary>
        ///M key
        ///</summary>
        KEY_M = 0x4D,
        ///<summary>
        ///N key
        ///</summary>
        KEY_N = 0x4E,
        ///<summary>
        ///O key
        ///</summary>
        KEY_O = 0x4F,
        ///<summary>
        ///P key
        ///</summary>
        KEY_P = 0x50,
        ///<summary>
        ///Q key
        ///</summary>
        KEY_Q = 0x51,
        ///<summary>
        ///R key
        ///</summary>
        KEY_R = 0x52,
        ///<summary>
        ///S key
        ///</summary>
        KEY_S = 0x53,
        ///<summary>
        ///T key
        ///</summary>
        KEY_T = 0x54,
        ///<summary>
        ///U key
        ///</summary>
        KEY_U = 0x55,
        ///<summary>
        ///V key
        ///</summary>
        KEY_V = 0x56,
        ///<summary>
        ///W key
        ///</summary>
        KEY_W = 0x57,
        ///<summary>
        ///X key
        ///</summary>
        KEY_X = 0x58,
        ///<summary>
        ///Y key
        ///</summary>
        KEY_Y = 0x59,
        ///<summary>
        ///Z key
        ///</summary>
        KEY_Z = 0x5A,
        ///<summary>
        ///Left Windows key (Microsoft Natural keyboard) 
        ///</summary>
        LWIN = 0x5B,
        ///<summary>
        ///Right Windows key (Natural keyboard)
        ///</summary>
        RWIN = 0x5C,
        ///<summary>
        ///Applications key (Natural keyboard)
        ///</summary>
        APPS = 0x5D,
        ///<summary>
        ///Computer Sleep key
        ///</summary>
        SLEEP = 0x5F,
        ///<summary>
        ///Numeric keypad 0 key
        ///</summary>
        NUMPAD0 = 0x60,
        ///<summary>
        ///Numeric keypad 1 key
        ///</summary>
        NUMPAD1 = 0x61,
        ///<summary>
        ///Numeric keypad 2 key
        ///</summary>
        NUMPAD2 = 0x62,
        ///<summary>
        ///Numeric keypad 3 key
        ///</summary>
        NUMPAD3 = 0x63,
        ///<summary>
        ///Numeric keypad 4 key
        ///</summary>
        NUMPAD4 = 0x64,
        ///<summary>
        ///Numeric keypad 5 key
        ///</summary>
        NUMPAD5 = 0x65,
        ///<summary>
        ///Numeric keypad 6 key
        ///</summary>
        NUMPAD6 = 0x66,
        ///<summary>
        ///Numeric keypad 7 key
        ///</summary>
        NUMPAD7 = 0x67,
        ///<summary>
        ///Numeric keypad 8 key
        ///</summary>
        NUMPAD8 = 0x68,
        ///<summary>
        ///Numeric keypad 9 key
        ///</summary>
        NUMPAD9 = 0x69,
        ///<summary>
        ///Multiply key
        ///</summary>
        MULTIPLY = 0x6A,
        ///<summary>
        ///Add key
        ///</summary>
        ADD = 0x6B,
        ///<summary>
        ///Separator key
        ///</summary>
        SEPARATOR = 0x6C,
        ///<summary>
        ///Subtract key
        ///</summary>
        SUBTRACT = 0x6D,
        ///<summary>
        ///Decimal key
        ///</summary>
        DECIMAL = 0x6E,
        ///<summary>
        ///Divide key
        ///</summary>
        DIVIDE = 0x6F,
        ///<summary>
        ///F1 key
        ///</summary>
        F1 = 0x70,
        ///<summary>
        ///F2 key
        ///</summary>
        F2 = 0x71,
        ///<summary>
        ///F3 key
        ///</summary>
        F3 = 0x72,
        ///<summary>
        ///F4 key
        ///</summary>
        F4 = 0x73,
        ///<summary>
        ///F5 key
        ///</summary>
        F5 = 0x74,
        ///<summary>
        ///F6 key
        ///</summary>
        F6 = 0x75,
        ///<summary>
        ///F7 key
        ///</summary>
        F7 = 0x76,
        ///<summary>
        ///F8 key
        ///</summary>
        F8 = 0x77,
        ///<summary>
        ///F9 key
        ///</summary>
        F9 = 0x78,
        ///<summary>
        ///F10 key
        ///</summary>
        F10 = 0x79,
        ///<summary>
        ///F11 key
        ///</summary>
        F11 = 0x7A,
        ///<summary>
        ///F12 key
        ///</summary>
        F12 = 0x7B,
        ///<summary>
        ///F13 key
        ///</summary>
        F13 = 0x7C,
        ///<summary>
        ///F14 key
        ///</summary>
        F14 = 0x7D,
        ///<summary>
        ///F15 key
        ///</summary>
        F15 = 0x7E,
        ///<summary>
        ///F16 key
        ///</summary>
        F16 = 0x7F,
        ///<summary>
        ///F17 key  
        ///</summary>
        F17 = 0x80,
        ///<summary>
        ///F18 key  
        ///</summary>
        F18 = 0x81,
        ///<summary>
        ///F19 key  
        ///</summary>
        F19 = 0x82,
        ///<summary>
        ///F20 key  
        ///</summary>
        F20 = 0x83,
        ///<summary>
        ///F21 key  
        ///</summary>
        F21 = 0x84,
        ///<summary>
        ///F22 key, (PPC only) Key used to lock device.
        ///</summary>
        F22 = 0x85,
        ///<summary>
        ///F23 key  
        ///</summary>
        F23 = 0x86,
        ///<summary>
        ///F24 key  
        ///</summary>
        F24 = 0x87,
        ///<summary>
        ///NUM LOCK key
        ///</summary>
        NUMLOCK = 0x90,
        ///<summary>
        ///SCROLL LOCK key
        ///</summary>
        SCROLL = 0x91,
        ///<summary>
        ///Left SHIFT key
        ///</summary>
        LSHIFT = 0xA0,
        ///<summary>
        ///Right SHIFT key
        ///</summary>
        RSHIFT = 0xA1,
        ///<summary>
        ///Left CONTROL key
        ///</summary>
        LCONTROL = 0xA2,
        ///<summary>
        ///Right CONTROL key
        ///</summary>
        RCONTROL = 0xA3,
        ///<summary>
        ///Left MENU key
        ///</summary>
        LMENU = 0xA4,
        ///<summary>
        ///Right MENU key
        ///</summary>
        RMENU = 0xA5,
        ///<summary>
        ///Windows 2000/XP: Browser Back key
        ///</summary>
        BROWSER_BACK = 0xA6,
        ///<summary>
        ///Windows 2000/XP: Browser Forward key
        ///</summary>
        BROWSER_FORWARD = 0xA7,
        ///<summary>
        ///Windows 2000/XP: Browser Refresh key
        ///</summary>
        BROWSER_REFRESH = 0xA8,
        ///<summary>
        ///Windows 2000/XP: Browser Stop key
        ///</summary>
        BROWSER_STOP = 0xA9,
        ///<summary>
        ///Windows 2000/XP: Browser Search key 
        ///</summary>
        BROWSER_SEARCH = 0xAA,
        ///<summary>
        ///Windows 2000/XP: Browser Favorites key
        ///</summary>
        BROWSER_FAVORITES = 0xAB,
        ///<summary>
        ///Windows 2000/XP: Browser Start and Home key
        ///</summary>
        BROWSER_HOME = 0xAC,
        ///<summary>
        ///Windows 2000/XP: Volume Mute key
        ///</summary>
        VOLUME_MUTE = 0xAD,
        ///<summary>
        ///Windows 2000/XP: Volume Down key
        ///</summary>
        VOLUME_DOWN = 0xAE,
        ///<summary>
        ///Windows 2000/XP: Volume Up key
        ///</summary>
        VOLUME_UP = 0xAF,
        ///<summary>
        ///Windows 2000/XP: Next Track key
        ///</summary>
        MEDIA_NEXT_TRACK = 0xB0,
        ///<summary>
        ///Windows 2000/XP: Previous Track key
        ///</summary>
        MEDIA_PREV_TRACK = 0xB1,
        ///<summary>
        ///Windows 2000/XP: Stop Media key
        ///</summary>
        MEDIA_STOP = 0xB2,
        ///<summary>
        ///Windows 2000/XP: Play/Pause Media key
        ///</summary>
        MEDIA_PLAY_PAUSE = 0xB3,
        ///<summary>
        ///Windows 2000/XP: Start Mail key
        ///</summary>
        LAUNCH_MAIL = 0xB4,
        ///<summary>
        ///Windows 2000/XP: Select Media key
        ///</summary>
        LAUNCH_MEDIA_SELECT = 0xB5,
        ///<summary>
        ///Windows 2000/XP: Start Application 1 key
        ///</summary>
        LAUNCH_APP1 = 0xB6,
        ///<summary>
        ///Windows 2000/XP: Start Application 2 key
        ///</summary>
        LAUNCH_APP2 = 0xB7,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_1 = 0xBA,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '+' key
        ///</summary>
        OEM_PLUS = 0xBB,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the ',' key
        ///</summary>
        OEM_COMMA = 0xBC,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '-' key
        ///</summary>
        OEM_MINUS = 0xBD,
        ///<summary>
        ///Windows 2000/XP: For any country/region, the '.' key
        ///</summary>
        OEM_PERIOD = 0xBE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_2 = 0xBF,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_3 = 0xC0,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_4 = 0xDB,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_5 = 0xDC,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_6 = 0xDD,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard. 
        ///</summary>
        OEM_7 = 0xDE,
        ///<summary>
        ///Used for miscellaneous characters; it can vary by keyboard.
        ///</summary>
        OEM_8 = 0xDF,
        ///<summary>
        ///Windows 2000/XP: Either the angle bracket key or the backslash key on the RT 102-key keyboard
        ///</summary>
        OEM_102 = 0xE2,
        ///<summary>
        ///Windows 95/98/Me, Windows NT 4.0, Windows 2000/XP: IME PROCESS key
        ///</summary>
        PROCESSKEY = 0xE5,
        ///<summary>
        ///Windows 2000/XP: Used to pass Unicode characters as if they were keystrokes.
        ///The VK_PACKET key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods. For more information,
        ///see Remark in KEYBDINPUT, SendInput, WM_KEYDOWN, and WM_KEYUP
        ///</summary>
        PACKET = 0xE7,
        ///<summary>
        ///Attn key
        ///</summary>
        ATTN = 0xF6,
        ///<summary>
        ///CrSel key
        ///</summary>
        CRSEL = 0xF7,
        ///<summary>
        ///ExSel key
        ///</summary>
        EXSEL = 0xF8,
        ///<summary>
        ///Erase EOF key
        ///</summary>
        EREOF = 0xF9,
        ///<summary>
        ///Play key
        ///</summary>
        PLAY = 0xFA,
        ///<summary>
        ///Zoom key
        ///</summary>
        ZOOM = 0xFB,
        ///<summary>
        ///Reserved 
        ///</summary>
        NONAME = 0xFC,
        ///<summary>
        ///PA1 key
        ///</summary>
        PA1 = 0xFD,
        ///<summary>
        ///Clear key
        ///</summary>
        OEM_CLEAR = 0xFE
    }
    public enum ScanCodeByte : byte
    {
        LBUTTON = 0,
        RBUTTON = 0,
        CANCEL = 70,
        MBUTTON = 0,
        XBUTTON1 = 0,
        XBUTTON2 = 0,
        BACK = 14,
        TAB = 15,
        CLEAR = 76,
        RETURN = 28,
        SHIFT = 42,
        CONTROL = 29,
        MENU = 56,
        PAUSE = 0,
        CAPITAL = 58,
        KANA = 0,
        HANGUL = 0,
        JUNJA = 0,
        FINAL = 0,
        HANJA = 0,
        KANJI = 0,
        ESCAPE = 1,
        CONVERT = 0,
        NONCONVERT = 0,
        ACCEPT = 0,
        MODECHANGE = 0,
        SPACE = 57,
        PRIOR = 73,
        NEXT = 81,
        END = 79,
        HOME = 71,
        LEFT = 75,
        UP = 72,
        RIGHT = 77,
        DOWN = 80,
        SELECT = 0,
        PRINT = 0,
        EXECUTE = 0,
        SNAPSHOT = 84,
        INSERT = 82,
        DELETE = 83,
        HELP = 99,
        KEY_0 = 11,
        KEY_1 = 2,
        KEY_2 = 3,
        KEY_3 = 4,
        KEY_4 = 5,
        KEY_5 = 6,
        KEY_6 = 7,
        KEY_7 = 8,
        KEY_8 = 9,
        KEY_9 = 10,
        KEY_A = 30,
        KEY_B = 48,
        KEY_C = 46,
        KEY_D = 32,
        KEY_E = 18,
        KEY_F = 33,
        KEY_G = 34,
        KEY_H = 35,
        KEY_I = 23,
        KEY_J = 36,
        KEY_K = 37,
        KEY_L = 38,
        KEY_M = 50,
        KEY_N = 49,
        KEY_O = 24,
        KEY_P = 25,
        KEY_Q = 16,
        KEY_R = 19,
        KEY_S = 31,
        KEY_T = 20,
        KEY_U = 22,
        KEY_V = 47,
        KEY_W = 17,
        KEY_X = 45,
        KEY_Y = 21,
        KEY_Z = 44,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 82,
        NUMPAD1 = 79,
        NUMPAD2 = 80,
        NUMPAD3 = 81,
        NUMPAD4 = 75,
        NUMPAD5 = 76,
        NUMPAD6 = 77,
        NUMPAD7 = 71,
        NUMPAD8 = 72,
        NUMPAD9 = 73,
        MULTIPLY = 55,
        ADD = 78,
        SEPARATOR = 0,
        SUBTRACT = 74,
        DECIMAL = 83,
        DIVIDE = 53,
        F1 = 59,
        F2 = 60,
        F3 = 61,
        F4 = 62,
        F5 = 63,
        F6 = 64,
        F7 = 65,
        F8 = 66,
        F9 = 67,
        F10 = 68,
        F11 = 87,
        F12 = 88,
        F13 = 100,
        F14 = 101,
        F15 = 102,
        F16 = 103,
        F17 = 104,
        F18 = 105,
        F19 = 106,
        F20 = 107,
        F21 = 108,
        F22 = 109,
        F23 = 110,
        F24 = 118,
        NUMLOCK = 69,
        SCROLL = 70,
        LSHIFT = 42,
        RSHIFT = 54,
        LCONTROL = 29,
        RCONTROL = 29,
        LMENU = 56,
        RMENU = 56,
        BROWSER_BACK = 106,
        BROWSER_FORWARD = 105,
        BROWSER_REFRESH = 103,
        BROWSER_STOP = 104,
        BROWSER_SEARCH = 101,
        BROWSER_FAVORITES = 102,
        BROWSER_HOME = 50,
        VOLUME_MUTE = 32,
        VOLUME_DOWN = 46,
        VOLUME_UP = 48,
        MEDIA_NEXT_TRACK = 25,
        MEDIA_PREV_TRACK = 16,
        MEDIA_STOP = 36,
        MEDIA_PLAY_PAUSE = 34,
        LAUNCH_MAIL = 108,
        LAUNCH_MEDIA_SELECT = 109,
        LAUNCH_APP1 = 107,
        LAUNCH_APP2 = 33,
        OEM_1 = 39,
        OEM_PLUS = 13,
        OEM_COMMA = 51,
        OEM_MINUS = 12,
        OEM_PERIOD = 52,
        OEM_2 = 53,
        OEM_3 = 41,
        OEM_4 = 26,
        OEM_5 = 43,
        OEM_6 = 27,
        OEM_7 = 40,
        OEM_8 = 0,
        OEM_102 = 86,
        PROCESSKEY = 0,
        PACKET = 0,
        ATTN = 0,
        CRSEL = 0,
        EXSEL = 0,
        EREOF = 93,
        PLAY = 0,
        ZOOM = 98,
        NONAME = 0,
        PA1 = 0,
        OEM_CLEAR = 0,
    }

    public enum MapVirtualKeyMapTypes : uint
    {
        /// <summary>
        /// uCode is a virtual-key code and is translated into a scan code.
        /// If it is a virtual-key code that does not distinguish between left- and
        /// right-hand keys, the left-hand scan code is returned.
        /// If there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VK_TO_VSC = 0x00,

        /// <summary>
        /// uCode is a scan code and is translated into a virtual-key code that
        /// does not distinguish between left- and right-hand keys.
        /// If there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VSC_TO_VK = 0x01,

        /// <summary>
        /// uCode is a virtual-key code and is translated into an unshifted
        /// character value in the low-order word of the return value.
        /// Dead keys (diacritics) are indicated by setting the top bit of the return value. 
        /// If there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VK_TO_CHAR = 0x02,

        /// <summary>
        /// Windows NT/2000/XP: uCode is a scan code and is translated into a
        /// virtual-key code that distinguishes between left- and right-hand keys.
        /// If there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VSC_TO_VK_EX = 0x03,

        /// <summary>
        /// Vista and later, and only by MapVirtualKeyEx
        /// he uCode parameter is a virtual-key code and is translated into a scan code.
        /// If there is no translation, the function returns 0.
        /// </summary>
        MAPVK_VK_TO_VSC_EX = 0x04
    }

    public enum NL_ROUTE_ORIGIN
    {
        NlroManual,
        NlroWellKnown,
        NlroDHCP,
        NlroRouterAdvertisement,
        Nlro6to4,
    }

    public enum NL_ROUTE_PROTOCOL
    {
        RouteProtocolOther = 1,
        RouteProtocolLocal = 2,
        RouteProtocolNetMgmt = 3,
        RouteProtocolIcmp = 4,
        RouteProtocolEgp = 5,
        RouteProtocolGgp = 6,
        RouteProtocolHello = 7,
        RouteProtocolRip = 8,
        RouteProtocolIsIs = 9,
        RouteProtocolEsIs = 10,
        RouteProtocolCisco = 11,
        RouteProtocolBbn = 12,
        RouteProtocolOspf = 13,
        RouteProtocolBgp = 14,
    }

    public enum GetWindow_Cmd : uint
    {
        /// <summary>
        /// The retrieved handle identifies the window of the same type that is highest in the Z order.
        /// </summary>
        GW_HWNDFIRST = 0,

        /// <summary>
        /// The retrieved handle identifies the window of the same type that is lowest in the Z order.
        /// </summary>
        GW_HWNDLAST = 1,

        /// <summary>
        /// The retrieved handle identifies the window below the specified window in the Z order.
        /// </summary>
        GW_HWNDNEXT = 2,

        /// <summary>
        /// The retrieved handle identifies the window above the specified window in the Z order.
        /// </summary>
        GW_HWNDPREV = 3,

        /// <summary>
        /// The retrieved handle identifies the specified window's owner window
        /// </summary>
        GW_OWNER = 4,

        /// <summary>
        /// The retrieved handle identifies the child window at the top of the Z orde
        /// </summary>
        GW_CHILD = 5,

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms632599(v=vs.85).aspx#owned_windows
        /// The retrieved handle identifies the enabled popup window owned by the specified window
        /// </summary>
        GW_ENABLEDPOPUP = 6
    }

    public enum WindowMessege : uint
    {
        /// <summary>
        /// The WM_NULL message performs no operation. An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
        /// </summary>
        NULL = 0x0000,
        /// <summary>
        /// The WM_CREATE message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// </summary>
        CREATE = 0x0001,
        /// <summary>
        /// The WM_DESTROY message is sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen. 
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the processing of the message, it can be assumed that all child windows still exist.
        /// /// </summary>
        DESTROY = 0x0002,
        /// <summary>
        /// The WM_MOVE message is sent after a window has been moved. 
        /// </summary>
        MOVE = 0x0003,
        /// <summary>
        /// The WM_SIZE message is sent to a window after its size has changed.
        /// </summary>
        SIZE = 0x0005,
        /// <summary>
        /// The WM_ACTIVATE message is sent to both the window being activated and the window being deactivated. If the windows use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window being deactivated, then to the window procedure of the top-level window being activated. If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately. 
        /// </summary>
        ACTIVATE = 0x0006,
        /// <summary>
        /// The WM_SETFOCUS message is sent to a window after it has gained the keyboard focus. 
        /// </summary>
        SETFOCUS = 0x0007,
        /// <summary>
        /// The WM_KILLFOCUS message is sent to a window immediately before it loses the keyboard focus. 
        /// </summary>
        KILLFOCUS = 0x0008,
        /// <summary>
        /// The WM_ENABLE message is sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed. 
        /// </summary>
        ENABLE = 0x000A,
        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn. 
        /// </summary>
        SETREDRAW = 0x000B,
        /// <summary>
        /// An application sends a WM_SETTEXT message to set the text of a window. 
        /// </summary>
        SETTEXT = 0x000C,
        /// <summary>
        /// An application sends a WM_GETTEXT message to copy the text that corresponds to a window into a buffer provided by the caller. 
        /// </summary>
        GETTEXT = 0x000D,
        /// <summary>
        /// An application sends a WM_GETTEXTLENGTH message to determine the length, in characters, of the text associated with a window. 
        /// </summary>
        GETTEXTLENGTH = 0x000E,
        /// <summary>
        /// The WM_PAINT message is sent when the system or another application makes a request to paint a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_PAINT message by using the GetMessage or PeekMessage function. 
        /// </summary>
        PAINT = 0x000F,
        /// <summary>
        /// The WM_CLOSE message is sent as a signal that a window or an application should terminate.
        /// </summary>
        CLOSE = 0x0010,
        /// <summary>
        /// The WM_QUERYENDSESSION message is sent when the user chooses to end the session
        /// or when an application calls one of the system shutdown functions.
        /// If any application returns zero, the session is not ended.
        /// The system stops sending WM_QUERYENDSESSION messages as soon as one application returns zero.
        /// After processing this message, 
        /// the system sends the WM_ENDSESSION message with the wParam parameter set to
        /// the results of the WM_QUERYENDSESSION message.
        /// </summary>
        QUERYENDSESSION = 0x0011,
        /// <summary>
        /// The WM_QUERYOPEN message is sent to an icon when the user requests that the window be restored to its previous size and position.
        /// </summary>
        QUERYOPEN = 0x0013,
        /// <summary>
        /// The WM_ENDSESSION message is sent to an application after the system processes the results of the WM_QUERYENDSESSION message. The WM_ENDSESSION message informs the application whether the session is ending.
        /// </summary>
        ENDSESSION = 0x0016,
        /// <summary>
        /// The WM_QUIT message indicates a request to terminate an application and is generated when the application calls the PostQuitMessage function. It causes the GetMessage function to return zero.
        /// </summary>
        QUIT = 0x0012,
        /// <summary>
        /// The WM_ERASEBKGND message is sent when the window background must be erased (for example, when a window is resized). The message is sent to prepare an invalidated portion of a window for painting. 
        /// </summary>
        ERASEBKGND = 0x0014,
        /// <summary>
        /// This message is sent to all top-level windows when a change is made to a system color setting. 
        /// </summary>
        SYSCOLORCHANGE = 0x0015,
        /// <summary>
        /// The WM_SHOWWINDOW message is sent to a window when the window is about to be hidden or shown.
        /// </summary>
        SHOWWINDOW = 0x0018,
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        WININICHANGE = 0x001A,
        /// <summary>
        /// An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
        /// Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
        /// </summary>
        SETTINGCHANGE = WININICHANGE,
        /// <summary>
        /// The WM_DEVMODECHANGE message is sent to all top-level windows whenever the user changes device-mode settings. 
        /// </summary>
        DEVMODECHANGE = 0x001B,
        /// <summary>
        /// The WM_ACTIVATEAPP message is sent when a window belonging to a different application than the active window is about to be activated. The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
        /// </summary>
        ACTIVATEAPP = 0x001C,
        /// <summary>
        /// An application sends the WM_FONTCHANGE message to all top-level windows in the system after changing the pool of font resources. 
        /// </summary>
        FONTCHANGE = 0x001D,
        /// <summary>
        /// A message that is sent whenever there is a change in the system time.
        /// </summary>
        TIMECHANGE = 0x001E,
        /// <summary>
        /// The WM_CANCELMODE message is sent to cancel certain modes, such as mouse capture. For example, the system sends this message to the active window when a dialog box or message box is displayed. Certain functions also send this message explicitly to the specified window regardless of whether it is the active window. For example, the EnableWindow function sends this message when disabling the specified window.
        /// </summary>
        CANCELMODE = 0x001F,
        /// <summary>
        /// The WM_SETCURSOR message is sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured. 
        /// </summary>
        SETCURSOR = 0x0020,
        /// <summary>
        /// The WM_MOUSEACTIVATE message is sent when the cursor is in an inactive window and the user presses a mouse button. The parent window receives this message only if the child window passes it to the DefWindowProc function.
        /// </summary>
        MOUSEACTIVATE = 0x0021,
        /// <summary>
        /// The WM_CHILDACTIVATE message is sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
        /// </summary>
        CHILDACTIVATE = 0x0022,
        /// <summary>
        /// The WM_QUEUESYNC message is sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the WH_JOURNALPLAYBACK Hook procedure. 
        /// </summary>
        QUEUESYNC = 0x0023,
        /// <summary>
        /// The WM_GETMINMAXINFO message is sent to a window when the size or position of the window is about to change. An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size. 
        /// </summary>
        GETMINMAXINFO = 0x0024,
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_PAINTICON message is sent to a minimized window when the icon is to be painted. This message is not sent by newer versions of Microsoft Windows, except in unusual circumstances explained in the Remarks.
        /// </summary>
        PAINTICON = 0x0026,
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_ICONERASEBKGND message is sent to a minimized window when the background of the icon must be filled before painting the icon. A window receives this message only if a class icon is defined for the window; otherwise, WM_ERASEBKGND is sent. This message is not sent by newer versions of Windows.
        /// </summary>
        ICONERASEBKGND = 0x0027,
        /// <summary>
        /// The WM_NEXTDLGCTL message is sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box. 
        /// </summary>
        NEXTDLGCTL = 0x0028,
        /// <summary>
        /// The WM_SPOOLERSTATUS message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue. 
        /// </summary>
        SPOOLERSTATUS = 0x002A,
        /// <summary>
        /// The WM_DRAWITEM message is sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box, list box, or menu has changed.
        /// </summary>
        DRAWITEM = 0x002B,
        /// <summary>
        /// The WM_MEASUREITEM message is sent to the owner window of a combo box, list box, list view control, or menu item when the control or menu is created.
        /// </summary>
        MEASUREITEM = 0x002C,
        /// <summary>
        /// Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT message. The system sends a WM_DELETEITEM message for each deleted item. The system sends the WM_DELETEITEM message for any deleted list box or combo box item with nonzero item data.
        /// </summary>
        DELETEITEM = 0x002D,
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_KEYDOWN message. 
        /// </summary>
        VKEYTOITEM = 0x002E,
        /// <summary>
        /// Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_CHAR message. 
        /// </summary>
        CHARTOITEM = 0x002F,
        /// <summary>
        /// An application sends a WM_SETFONT message to specify the font that a control is to use when drawing text. 
        /// </summary>
        SETFONT = 0x0030,
        /// <summary>
        /// An application sends a WM_GETFONT message to a control to retrieve the font with which the control is currently drawing its text. 
        /// </summary>
        GETFONT = 0x0031,
        /// <summary>
        /// An application sends a WM_SETHOTKEY message to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window. 
        /// </summary>
        SETHOTKEY = 0x0032,
        /// <summary>
        /// An application sends a WM_GETHOTKEY message to determine the hot key associated with a window. 
        /// </summary>
        GETHOTKEY = 0x0033,
        /// <summary>
        /// The WM_QUERYDRAGICON message is sent to a minimized (iconic) window. The window is about to be dragged by the user but does not have an icon defined for its class. An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
        /// </summary>
        QUERYDRAGICON = 0x0037,
        /// <summary>
        /// The system sends the WM_COMPAREITEM message to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box. Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box created with the CBS_SORT or LBS_SORT style. 
        /// </summary>
        COMPAREITEM = 0x0039,
        /// <summary>
        /// Active Accessibility sends the WM_GETOBJECT message to obtain information about an accessible object contained in a server application. 
        /// Applications never send this message directly. It is sent only by Active Accessibility in response to calls to AccessibleObjectFromPoint, AccessibleObjectFromEvent, or AccessibleObjectFromWindow. However, server applications handle this message. 
        /// </summary>
        GETOBJECT = 0x003D,
        /// <summary>
        /// The WM_COMPACTING message is sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is being spent compacting memory. This indicates that system memory is low.
        /// </summary>
        COMPACTING = 0x0041,
        /// <summary>
        /// WM_COMMNOTIFY is Obsolete for Win32-Based Applications
        /// </summary>
        [Obsolete]
        COMMNOTIFY = 0x0044,
        /// <summary>
        /// The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WINDOWPOSCHANGING = 0x0046,
        /// <summary>
        /// The WM_WINDOWPOSCHANGED message is sent to a window whose size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WINDOWPOSCHANGED = 0x0047,
        /// <summary>
        /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
        /// Use: POWERBROADCAST
        /// </summary>
        [Obsolete]
        POWER = 0x0048,
        /// <summary>
        /// An application sends the WM_COPYDATA message to pass data to another application. 
        /// </summary>
        COPYDATA = 0x004A,
        /// <summary>
        /// The WM_CANCELJOURNAL message is posted to an application when a user cancels the application's journaling activities. The message is posted with a NULL window handle. 
        /// </summary>
        CANCELJOURNAL = 0x004B,
        /// <summary>
        /// Sent by a common control to its parent window when an event has occurred or the control requires some information. 
        /// </summary>
        NOTIFY = 0x004E,
        /// <summary>
        /// The WM_INPUTLANGCHANGEREQUEST message is posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar. An application can accept the change by passing the message to the DefWindowProc function or reject the change (and prevent it from taking place) by returning immediately. 
        /// </summary>
        INPUTLANGCHANGEREQUEST = 0x0050,
        /// <summary>
        /// The WM_INPUTLANGCHANGE message is sent to the topmost affected window after an application's input language has been changed. You should make any application-specific settings and pass the message to the DefWindowProc function, which passes the message to all first-level child windows. These child windows can pass the message to DefWindowProc to have it pass the message to their child windows, and so on. 
        /// </summary>
        INPUTLANGCHANGE = 0x0051,
        /// <summary>
        /// Sent to an application that has initiated a training card with Microsoft Windows Help. The message informs the application when the user clicks an authorable button. An application initiates a training card by specifying the HELP_TCARD command in a call to the WinHelp function.
        /// </summary>
        TCARD = 0x0052,
        /// <summary>
        /// Indicates that the user pressed the F1 key. If a menu is active when F1 is pressed, WM_HELP is sent to the window associated with the menu; otherwise, WM_HELP is sent to the window that has the keyboard focus. If no window has the keyboard focus, WM_HELP is sent to the currently active window. 
        /// </summary>
        HELP = 0x0053,
        /// <summary>
        /// The WM_USERCHANGED message is sent to all windows after the user has logged on or off. When the user logs on or off, the system updates the user-specific settings. The system sends this message immediately after updating the settings.
        /// </summary>
        USERCHANGED = 0x0054,
        /// <summary>
        /// Determines if a window accepts ANSI or Unicode structures in the WM_NOTIFY notification message. WM_NOTIFYFORMAT messages are sent from a common control to its parent window and from the parent window to the common control.
        /// </summary>
        NOTIFYFORMAT = 0x0055,
        /// <summary>
        /// The WM_CONTEXTMENU message notifies a window that the user clicked the right mouse button (right-clicked) in the window.
        /// </summary>
        CONTEXTMENU = 0x007B,
        /// <summary>
        /// The WM_STYLECHANGING message is sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
        /// </summary>
        STYLECHANGING = 0x007C,
        /// <summary>
        /// The WM_STYLECHANGED message is sent to a window after the SetWindowLong function has changed one or more of the window's styles
        /// </summary>
        STYLECHANGED = 0x007D,
        /// <summary>
        /// The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
        /// </summary>
        DISPLAYCHANGE = 0x007E,
        /// <summary>
        /// The WM_GETICON message is sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption. 
        /// </summary>
        GETICON = 0x007F,
        /// <summary>
        /// An application sends the WM_SETICON message to associate a new large or small icon with a window. The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption. 
        /// </summary>
        SETICON = 0x0080,
        /// <summary>
        /// The WM_NCCREATE message is sent prior to the WM_CREATE message when a window is first created.
        /// </summary>
        NCCREATE = 0x0081,
        /// <summary>
        /// The WM_NCDESTROY message informs a window that its nonclient area is being destroyed. The DestroyWindow function sends the WM_NCDESTROY message to the window following the WM_DESTROY message. WM_DESTROY is used to free the allocated memory object associated with the window. 
        /// The WM_NCDESTROY message is sent after the child windows have been destroyed. In contrast, WM_DESTROY is sent before the child windows are destroyed.
        /// </summary>
        NCDESTROY = 0x0082,
        /// <summary>
        /// The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated. By processing this message, an application can control the content of the window's client area when the size or position of the window changes.
        /// </summary>
        NCCALCSIZE = 0x0083,
        /// <summary>
        /// The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released. If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
        /// </summary>
        NCHITTEST = 0x0084,
        /// <summary>
        /// The WM_NCPAINT message is sent to a window when its frame must be painted. 
        /// </summary>
        NCPAINT = 0x0085,
        /// <summary>
        /// The WM_NCACTIVATE message is sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
        /// </summary>
        NCACTIVATE = 0x0086,
        /// <summary>
        /// The WM_GETDLGCODE message is sent to the window procedure associated with a control. By default, the system handles all keyboard input to the control; the system interprets certain types of keyboard input as dialog box navigation keys. To override this default behavior, the control can respond to the WM_GETDLGCODE message to indicate the types of input it wants to process itself.
        /// </summary>
        GETDLGCODE = 0x0087,
        /// <summary>
        /// The WM_SYNCPAINT message is used to synchronize painting while avoiding linking independent GUI threads.
        /// </summary>
        SYNCPAINT = 0x0088,
        /// <summary>
        /// The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMOUSEMOVE = 0x00A0,
        /// <summary>
        /// The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONDOWN = 0x00A1,
        /// <summary>
        /// The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONUP = 0xa2,
        /// <summary>
        /// The WM_NCLBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCLBUTTONDBLCLK = 0x00A3,
        /// <summary>
        /// The WM_NCRBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCRBUTTONDOWN = 0x00A4,
        /// <summary>
        /// The WM_NCRBUTTONUP message is posted when the user releases the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCRBUTTONUP = 0x00A5,
        /// <summary>
        /// The WM_NCRBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCRBUTTONDBLCLK = 0x00A6,
        /// <summary>
        /// The WM_NCMBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMBUTTONDOWN = 0x00A7,
        /// <summary>
        /// The WM_NCMBUTTONUP message is posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMBUTTONUP = 0x00A8,
        /// <summary>
        /// The WM_NCMBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCMBUTTONDBLCLK = 0x00A9,
        /// <summary>
        /// The WM_NCXBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCXBUTTONDOWN = 0x00AB,
        /// <summary>
        /// The WM_NCXBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCXBUTTONUP = 0x00AC,
        /// <summary>
        /// The WM_NCXBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
        /// </summary>
        NCXBUTTONDBLCLK = 0x00AD,
        /// <summary>
        /// The WM_INPUT_DEVICE_CHANGE message is sent to the window that registered to receive raw input. A window receives this message through its WindowProc function.
        /// </summary>
        INPUT_DEVICE_CHANGE = 0x00FE,
        /// <summary>
        /// The WM_INPUT message is sent to the window that is getting raw input. 
        /// </summary>
        INPUT = 0x00FF,
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        KEYFIRST = 0x0100,
        /// <summary>
        /// The WM_KEYDOWN message is posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed. 
        /// </summary>
        KEYDOWN = 0x0100,
        /// <summary>
        /// The WM_KEYUP message is posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus. 
        /// </summary>
        KEYUP = 0x0101,
        /// <summary>
        /// The WM_CHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_CHAR message contains the character code of the key that was pressed. 
        /// </summary>
        CHAR = 0x0102,
        /// <summary>
        /// The WM_DEADCHAR message is posted to the window with the keyboard focus when a WM_KEYUP message is translated by the TranslateMessage function. WM_DEADCHAR specifies a character code generated by a dead key. A dead key is a key that generates a character, such as the umlaut (double-dot), that is combined with another character to form a composite character. For example, the umlaut-O character (Ö) is generated by typing the dead key for the umlaut character, and then typing the O key. 
        /// </summary>
        DEADCHAR = 0x0103,
        /// <summary>
        /// The WM_SYSKEYDOWN message is posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
        /// </summary>
        SYSKEYDOWN = 0x0104,
        /// <summary>
        /// The WM_SYSKEYUP message is posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
        /// </summary>
        SYSKEYUP = 0x0105,
        /// <summary>
        /// The WM_SYSCHAR message is posted to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. It specifies the character code of a system character key — that is, a character key that is pressed while the ALT key is down. 
        /// </summary>
        SYSCHAR = 0x0106,
        /// <summary>
        /// The WM_SYSDEADCHAR message is sent to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. WM_SYSDEADCHAR specifies the character code of a system dead key — that is, a dead key that is pressed while holding down the ALT key. 
        /// </summary>
        SYSDEADCHAR = 0x0107,
        /// <summary>
        /// The WM_UNICHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_UNICHAR message contains the character code of the key that was pressed. 
        /// The WM_UNICHAR message is equivalent to WM_CHAR, but it uses Unicode Transformation Format (UTF)-32, whereas WM_CHAR uses UTF-16. It is designed to send or post Unicode characters to ANSI windows and it can can handle Unicode Supplementary Plane characters.
        /// </summary>
        UNICHAR = 0x0109,
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        KEYLAST = 0x0109,
        /// <summary>
        /// Sent immediately before the IME generates the composition string as a result of a keystroke. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_STARTCOMPOSITION = 0x010D,
        /// <summary>
        /// Sent to an application when the IME ends composition. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_ENDCOMPOSITION = 0x010E,
        /// <summary>
        /// Sent to an application when the IME changes composition status as a result of a keystroke. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_COMPOSITION = 0x010F,
        IME_KEYLAST = 0x010F,
        /// <summary>
        /// The WM_INITDIALOG message is sent to the dialog box procedure immediately before a dialog box is displayed. Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box. 
        /// </summary>
        INITDIALOG = 0x0110,
        /// <summary>
        /// The WM_COMMAND message is sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when an accelerator keystroke is translated. 
        /// </summary>
        COMMAND = 0x0111,
        /// <summary>
        /// A window receives this message when the user chooses a command from the Window menu, clicks the maximize button, minimize button, restore button, close button, or moves the form. You can stop the form from moving by filtering this out.
        /// </summary>
        SYSCOMMAND = 0x0112,
        /// <summary>
        /// The WM_TIMER message is posted to the installing thread's message queue when a timer expires. The message is posted by the GetMessage or PeekMessage function. 
        /// </summary>
        TIMER = 0x0113,
        /// <summary>
        /// The WM_HSCROLL message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar. This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control. 
        /// </summary>
        HSCROLL = 0x0114,
        /// <summary>
        /// The WM_VSCROLL message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar. This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control. 
        /// </summary>
        VSCROLL = 0x0115,
        /// <summary>
        /// The WM_INITMENU message is sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key. This allows the application to modify the menu before it is displayed. 
        /// </summary>
        INITMENU = 0x0116,
        /// <summary>
        /// The WM_INITMENUPOPUP message is sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu. 
        /// </summary>
        INITMENUPOPUP = 0x0117,
        /// <summary>
        /// The WM_MENUSELECT message is sent to a menu's owner window when the user selects a menu item. 
        /// </summary>
        MENUSELECT = 0x011F,
        /// <summary>
        /// The WM_MENUCHAR message is sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key. This message is sent to the window that owns the menu. 
        /// </summary>
        MENUCHAR = 0x0120,
        /// <summary>
        /// The WM_ENTERIDLE message is sent to the owner window of a modal dialog box or menu that is entering an idle state. A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages. 
        /// </summary>
        ENTERIDLE = 0x0121,
        /// <summary>
        /// The WM_MENURBUTTONUP message is sent when the user releases the right mouse button while the cursor is on a menu item. 
        /// </summary>
        MENURBUTTONUP = 0x0122,
        /// <summary>
        /// The WM_MENUDRAG message is sent to the owner of a drag-and-drop menu when the user drags a menu item. 
        /// </summary>
        MENUDRAG = 0x0123,
        /// <summary>
        /// The WM_MENUGETOBJECT message is sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item. 
        /// </summary>
        MENUGETOBJECT = 0x0124,
        /// <summary>
        /// The WM_UNINITMENUPOPUP message is sent when a drop-down menu or submenu has been destroyed. 
        /// </summary>
        UNINITMENUPOPUP = 0x0125,
        /// <summary>
        /// The WM_MENUCOMMAND message is sent when the user makes a selection from a menu. 
        /// </summary>
        MENUCOMMAND = 0x0126,
        /// <summary>
        /// An application sends the WM_CHANGEUISTATE message to indicate that the user interface (UI) state should be changed.
        /// </summary>
        CHANGEUISTATE = 0x0127,
        /// <summary>
        /// An application sends the WM_UPDATEUISTATE message to change the user interface (UI) state for the specified window and all its child windows.
        /// </summary>
        UPDATEUISTATE = 0x0128,
        /// <summary>
        /// An application sends the WM_QUERYUISTATE message to retrieve the user interface (UI) state for a window.
        /// </summary>
        QUERYUISTATE = 0x0129,
        /// <summary>
        /// The WM_CTLCOLORMSGBOX message is sent to the owner window of a message box before Windows draws the message box. By responding to this message, the owner window can set the text and background colors of the message box by using the given display device context handle. 
        /// </summary>
        CTLCOLORMSGBOX = 0x0132,
        /// <summary>
        /// An edit control that is not read-only or disabled sends the WM_CTLCOLOREDIT message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the edit control. 
        /// </summary>
        CTLCOLOREDIT = 0x0133,
        /// <summary>
        /// Sent to the parent window of a list box before the system draws the list box. By responding to this message, the parent window can set the text and background colors of the list box by using the specified display device context handle. 
        /// </summary>
        CTLCOLORLISTBOX = 0x0134,
        /// <summary>
        /// The WM_CTLCOLORBTN message is sent to the parent window of a button before drawing the button. The parent window can change the button's text and background colors. However, only owner-drawn buttons respond to the parent window processing this message. 
        /// </summary>
        CTLCOLORBTN = 0x0135,
        /// <summary>
        /// The WM_CTLCOLORDLG message is sent to a dialog box before the system draws the dialog box. By responding to this message, the dialog box can set its text and background colors using the specified display device context handle. 
        /// </summary>
        CTLCOLORDLG = 0x0136,
        /// <summary>
        /// The WM_CTLCOLORSCROLLBAR message is sent to the parent window of a scroll bar control when the control is about to be drawn. By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control. 
        /// </summary>
        CTLCOLORSCROLLBAR = 0x0137,
        /// <summary>
        /// A static control, or an edit control that is read-only or disabled, sends the WM_CTLCOLORSTATIC message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the static control. 
        /// </summary>
        CTLCOLORSTATIC = 0x0138,
        /// <summary>
        /// Use WM_MOUSEFIRST to specify the first mouse message. Use the PeekMessage() Function.
        /// </summary>
        MOUSEFIRST = 0x0200,
        /// <summary>
        /// The WM_MOUSEMOVE message is posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MOUSEMOVE = 0x0200,
        /// <summary>
        /// The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONDOWN = 0x0201,
        /// <summary>
        /// The WM_LBUTTONUP message is posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONUP = 0x0202,
        /// <summary>
        /// The WM_LBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        LBUTTONDBLCLK = 0x0203,
        /// <summary>
        /// The WM_RBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        RBUTTONDOWN = 0x0204,
        /// <summary>
        /// The WM_RBUTTONUP message is posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        RBUTTONUP = 0x0205,
        /// <summary>
        /// The WM_RBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        RBUTTONDBLCLK = 0x0206,
        /// <summary>
        /// The WM_MBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MBUTTONDOWN = 0x0207,
        /// <summary>
        /// The WM_MBUTTONUP message is posted when the user releases the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MBUTTONUP = 0x0208,
        /// <summary>
        /// The WM_MBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        MBUTTONDBLCLK = 0x0209,
        /// <summary>
        /// The WM_MOUSEWHEEL message is sent to the focus window when the mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no public forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        MOUSEWHEEL = 0x020A,
        /// <summary>
        /// The WM_XBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse. 
        /// </summary>
        XBUTTONDOWN = 0x020B,
        /// <summary>
        /// The WM_XBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        XBUTTONUP = 0x020C,
        /// <summary>
        /// The WM_XBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        XBUTTONDBLCLK = 0x020D,
        /// <summary>
        /// The WM_MOUSEHWHEEL message is sent to the focus window when the mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no public forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        MOUSEHWHEEL = 0x020E,
        /// <summary>
        /// Use WM_MOUSELAST to specify the last mouse message. Used with PeekMessage() Function.
        /// </summary>
        MOUSELAST = 0x020E,
        /// <summary>
        /// The WM_PARENTNOTIFY message is sent to the parent of a child window when the child window is created or destroyed, or when the user clicks a mouse button while the cursor is over the child window. When the child window is being created, the system sends WM_PARENTNOTIFY just before the CreateWindow or CreateWindowEx function that creates the window returns. When the child window is being destroyed, the system sends the message before any processing to destroy the window takes place.
        /// </summary>
        PARENTNOTIFY = 0x0210,
        /// <summary>
        /// The WM_ENTERMENULOOP message informs an application's main window procedure that a menu modal loop has been entered. 
        /// </summary>
        ENTERMENULOOP = 0x0211,
        /// <summary>
        /// The WM_EXITMENULOOP message informs an application's main window procedure that a menu modal loop has been exited. 
        /// </summary>
        EXITMENULOOP = 0x0212,
        /// <summary>
        /// The WM_NEXTMENU message is sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu. 
        /// </summary>
        NEXTMENU = 0x0213,
        /// <summary>
        /// The WM_SIZING message is sent to a window that the user is resizing. By processing this message, an application can monitor the size and position of the drag rectangle and, if needed, change its size or position. 
        /// </summary>
        SIZING = 0x0214,
        /// <summary>
        /// The WM_CAPTURECHANGED message is sent to the window that is losing the mouse capture.
        /// </summary>
        CAPTURECHANGED = 0x0215,
        /// <summary>
        /// The WM_MOVING message is sent to a window that the user is moving. By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
        /// </summary>
        MOVING = 0x0216,
        /// <summary>
        /// Notifies applications that a power-management event has occurred.
        /// </summary>
        POWERBROADCAST = 0x0218,
        /// <summary>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        DEVICECHANGE = 0x0219,
        /// <summary>
        /// An application sends the WM_MDICREATE message to a multiple-document interface (MDI) client window to create an MDI child window. 
        /// </summary>
        MDICREATE = 0x0220,
        /// <summary>
        /// An application sends the WM_MDIDESTROY message to a multiple-document interface (MDI) client window to close an MDI child window. 
        /// </summary>
        MDIDESTROY = 0x0221,
        /// <summary>
        /// An application sends the WM_MDIACTIVATE message to a multiple-document interface (MDI) client window to instruct the client window to activate a different MDI child window. 
        /// </summary>
        MDIACTIVATE = 0x0222,
        /// <summary>
        /// An application sends the WM_MDIRESTORE message to a multiple-document interface (MDI) client window to restore an MDI child window from maximized or minimized size. 
        /// </summary>
        MDIRESTORE = 0x0223,
        /// <summary>
        /// An application sends the WM_MDINEXT message to a multiple-document interface (MDI) client window to activate the next or previous child window. 
        /// </summary>
        MDINEXT = 0x0224,
        /// <summary>
        /// An application sends the WM_MDIMAXIMIZE message to a multiple-document interface (MDI) client window to maximize an MDI child window. The system resizes the child window to make its client area fill the client window. The system places the child window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in the leftmost position. The system also appends the title bar text of the child window to that of the frame window. 
        /// </summary>
        MDIMAXIMIZE = 0x0225,
        /// <summary>
        /// An application sends the WM_MDITILE message to a multiple-document interface (MDI) client window to arrange all of its MDI child windows in a tile format. 
        /// </summary>
        MDITILE = 0x0226,
        /// <summary>
        /// An application sends the WM_MDICASCADE message to a multiple-document interface (MDI) client window to arrange all its child windows in a cascade format. 
        /// </summary>
        MDICASCADE = 0x0227,
        /// <summary>
        /// An application sends the WM_MDIICONARRANGE message to a multiple-document interface (MDI) client window to arrange all minimized MDI child windows. It does not affect child windows that are not minimized. 
        /// </summary>
        MDIICONARRANGE = 0x0228,
        /// <summary>
        /// An application sends the WM_MDIGETACTIVE message to a multiple-document interface (MDI) client window to retrieve the handle to the active MDI child window. 
        /// </summary>
        MDIGETACTIVE = 0x0229,
        /// <summary>
        /// An application sends the WM_MDISETMENU message to a multiple-document interface (MDI) client window to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both. 
        /// </summary>
        MDISETMENU = 0x0230,
        /// <summary>
        /// The WM_ENTERSIZEMOVE message is sent one time to a window after it enters the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns. 
        /// The system sends the WM_ENTERSIZEMOVE message regardless of whether the dragging of full windows is enabled.
        /// </summary>
        ENTERSIZEMOVE = 0x0231,
        /// <summary>
        /// The WM_EXITSIZEMOVE message is sent one time to a window, after it has exited the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns. 
        /// </summary>
        EXITSIZEMOVE = 0x0232,
        /// <summary>
        /// Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
        /// </summary>
        DROPFILES = 0x0233,
        /// <summary>
        /// An application sends the WM_MDIREFRESHMENU message to a multiple-document interface (MDI) client window to refresh the window menu of the MDI frame window. 
        /// </summary>
        MDIREFRESHMENU = 0x0234,
        /// <summary>
        /// Sent to an application when a window is activated. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_SETCONTEXT = 0x0281,
        /// <summary>
        /// Sent to an application to notify it of changes to the IME window. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_NOTIFY = 0x0282,
        /// <summary>
        /// Sent by an application to direct the IME window to carry out the requested command. The application uses this message to control the IME window that it has created. To send this message, the application calls the SendMessage function with the following parameters.
        /// </summary>
        IME_CONTROL = 0x0283,
        /// <summary>
        /// Sent to an application when the IME window finds no space to extend the area for the composition window. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_COMPOSITIONFULL = 0x0284,
        /// <summary>
        /// Sent to an application when the operating system is about to change the current IME. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_SELECT = 0x0285,
        /// <summary>
        /// Sent to an application when the IME gets a character of the conversion result. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_CHAR = 0x0286,
        /// <summary>
        /// Sent to an application to provide commands and request information. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_REQUEST = 0x0288,
        /// <summary>
        /// Sent to an application by the IME to notify the application of a key press and to keep message order. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_KEYDOWN = 0x0290,
        /// <summary>
        /// Sent to an application by the IME to notify the application of a key release and to keep message order. A window receives this message through its WindowProc function. 
        /// </summary>
        IME_KEYUP = 0x0291,
        /// <summary>
        /// The WM_MOUSEHOVER message is posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        MOUSEHOVER = 0x02A1,
        /// <summary>
        /// The WM_MOUSELEAVE message is posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        MOUSELEAVE = 0x02A3,
        /// <summary>
        /// The WM_NCMOUSEHOVER message is posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        NCMOUSEHOVER = 0x02A0,
        /// <summary>
        /// The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        NCMOUSELEAVE = 0x02A2,
        /// <summary>
        /// The WM_WTSSESSION_CHANGE message notifies applications of changes in session state.
        /// </summary>
        WTSSESSION_CHANGE = 0x02B1,
        TABLET_FIRST = 0x02c0,
        TABLET_LAST = 0x02df,
        /// <summary>
        /// An application sends a WM_CUT message to an edit control or combo box to delete (cut) the current selection, if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format. 
        /// </summary>
        CUT = 0x0300,
        /// <summary>
        /// An application sends the WM_COPY message to an edit control or combo box to copy the current selection to the clipboard in CF_TEXT format. 
        /// </summary>
        COPY = 0x0301,
        /// <summary>
        /// An application sends a WM_PASTE message to an edit control or combo box to copy the current content of the clipboard to the edit control at the current caret position. Data is inserted only if the clipboard contains data in CF_TEXT format. 
        /// </summary>
        PASTE = 0x0302,
        /// <summary>
        /// An application sends a WM_CLEAR message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control. 
        /// </summary>
        CLEAR = 0x0303,
        /// <summary>
        /// An application sends a WM_UNDO message to an edit control to undo the last operation. When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
        /// </summary>
        UNDO = 0x0304,
        /// <summary>
        /// The WM_RENDERFORMAT message is sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function. 
        /// </summary>
        RENDERFORMAT = 0x0305,
        /// <summary>
        /// The WM_RENDERALLFORMATS message is sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats. For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function. 
        /// </summary>
        RENDERALLFORMATS = 0x0306,
        /// <summary>
        /// The WM_DESTROYCLIPBOARD message is sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard. 
        /// </summary>
        DESTROYCLIPBOARD = 0x0307,
        /// <summary>
        /// The WM_DRAWCLIPBOARD message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer window to display the new content of the clipboard. 
        /// </summary>
        DRAWCLIPBOARD = 0x0308,
        /// <summary>
        /// The WM_PAINTCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area needs repainting. 
        /// </summary>
        PAINTCLIPBOARD = 0x0309,
        /// <summary>
        /// The WM_VSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and update the scroll bar values. 
        /// </summary>
        VSCROLLCLIPBOARD = 0x030A,
        /// <summary>
        /// The WM_SIZECLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area has changed size. 
        /// </summary>
        SIZECLIPBOARD = 0x030B,
        /// <summary>
        /// The WM_ASKCBFORMATNAME message is sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDISPLAY clipboard format.
        /// </summary>
        ASKCBFORMATNAME = 0x030C,
        /// <summary>
        /// The WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain. 
        /// </summary>
        CHANGECBCHAIN = 0x030D,
        /// <summary>
        /// The WM_HSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll the clipboard image and update the scroll bar values. 
        /// </summary>
        HSCROLLCLIPBOARD = 0x030E,
        /// <summary>
        /// This message informs a window that it is about to receive the keyboard focus, giving the window the opportunity to realize its logical palette when it receives the focus.
        /// </summary>
        QUERYNEWPALETTE = 0x030F,
        /// <summary>
        /// The WM_PALETTEISCHANGING message informs applications that an application is going to realize its logical palette. 
        /// </summary>
        PALETTEISCHANGING = 0x0310,
        /// <summary>
        /// This message is sent by the OS to all top-level and overlapped windows after the window with the keyboard focus realizes its logical palette. 
        /// This message enables windows that do not have the keyboard focus to realize their logical palettes and update their client areas.
        /// </summary>
        PALETTECHANGED = 0x0311,
        /// <summary>
        /// The WM_HOTKEY message is posted when the user presses a hot key registered by the RegisterHotKey function. The message is placed at the top of the message queue associated with the thread that registered the hot key. 
        /// </summary>
        HOTKEY = 0x0312,
        /// <summary>
        /// The WM_PRINT message is sent to a window to request that it draw itself in the specified device context, most commonly in a printer device context.
        /// </summary>
        PRINT = 0x0317,
        /// <summary>
        /// The WM_PRINTCLIENT message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
        /// </summary>
        PRINTCLIENT = 0x0318,
        /// <summary>
        /// The WM_APPCOMMAND message notifies a window that the user generated an application command event, for example, by clicking an application command button using the mouse or typing an application command key on the keyboard.
        /// </summary>
        APPCOMMAND = 0x0319,
        /// <summary>
        /// The WM_THEMECHANGED message is broadcast to every window following a theme change event. Examples of theme change events are the activation of a theme, the deactivation of a theme, or a transition from one theme to another.
        /// </summary>
        THEMECHANGED = 0x031A,
        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        CLIPBOARDUPDATE = 0x031D,
        /// <summary>
        /// The system will send a window the WM_DWMCOMPOSITIONCHANGED message to indicate that the availability of desktop composition has changed.
        /// </summary>
        DWMCOMPOSITIONCHANGED = 0x031E,
        /// <summary>
        /// WM_DWMNCRENDERINGCHANGED is called when the non-client area rendering status of a window has changed. Only windows that have set the flag DWM_BLURBEHIND.fTransitionOnMaximized to true will get this message. 
        /// </summary>
        DWMNCRENDERINGCHANGED = 0x031F,
        /// <summary>
        /// Sent to all top-level windows when the colorization color has changed. 
        /// </summary>
        DWMCOLORIZATIONCOLORCHANGED = 0x0320,
        /// <summary>
        /// WM_DWMWINDOWMAXIMIZEDCHANGE will let you know when a DWM composed window is maximized. You also have to register for this message as well. You'd have other windowd go opaque when this message is sent.
        /// </summary>
        DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
        /// <summary>
        /// Sent to request extended title bar information. A window receives this message through its WindowProc function.
        /// </summary>
        GETTITLEBARINFOEX = 0x033F,
        HANDHELDFIRST = 0x0358,
        HANDHELDLAST = 0x035F,
        AFXFIRST = 0x0360,
        AFXLAST = 0x037F,
        PENWINFIRST = 0x0380,
        PENWINLAST = 0x038F,
        /// <summary>
        /// The WM_APP constant is used by applications to help define private messages, usually of the form WM_APP+X, where X is an integer value. 
        /// </summary>
        APP = 0x8000,
        /// <summary>
        /// The WM_USER constant is used by applications to help define private messages for use by private window classes, usually of the form WM_USER+X, where X is an integer value. 
        /// </summary>
        USER = 0x0400,

        /// <summary>
        /// An application sends the WM_CPL_LAUNCH message to Windows Control Panel to request that a Control Panel application be started. 
        /// </summary>
        CPL_LAUNCH = USER + 0x1000,
        /// <summary>
        /// The WM_CPL_LAUNCHED message is sent when a Control Panel application, started by the WM_CPL_LAUNCH message, has closed. The WM_CPL_LAUNCHED message is sent to the window identified by the wParam parameter of the WM_CPL_LAUNCH message that started the application. 
        /// </summary>
        CPL_LAUNCHED = USER + 0x1001,
        /// <summary>
        /// WM_SYSTIMER is a well-known yet still undocumented message. Windows uses WM_SYSTIMER for public actions like scrolling.
        /// </summary>
        SYSTIMER = 0x118
    }
    public enum SysCommands : uint
    {
        SC_SIZE = 0xF000,
        SC_MOVE = 0xF010,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_NEXTWINDOW = 0xF040,
        SC_PREVWINDOW = 0xF050,
        SC_CLOSE = 0xF060,
        SC_VSCROLL = 0xF070,
        SC_HSCROLL = 0xF080,
        SC_MOUSEMENU = 0xF090,
        SC_KEYMENU = 0xF100,
        SC_ARRANGE = 0xF110,
        SC_RESTORE = 0xF120,
        SC_TASKLIST = 0xF130,
        SC_SCREENSAVE = 0xF140,
        SC_HOTKEY = 0xF150,
        //#if(WINVER >= 0x0400) //Win95
        SC_DEFAULT = 0xF160,
        SC_MONITORPOWER = 0xF170,
        SC_CONTEXTHELP = 0xF180,
        SC_SEPARATOR = 0xF00F,
        //#endif /* WINVER >= 0x0400 */

        //#if(WINVER >= 0x0600) //Vista
        SCF_ISSECURE = 0x00000001,
        //#endif /* WINVER >= 0x0600 */

        /*
          * Obsolete names
          */
        SC_ICON = SC_MINIMIZE,
        SC_ZOOM = SC_MAXIMIZE
    }

    [Flags]
    public enum SetWindowPosuFlags : uint
    {
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOREDRAW = 0x0008,
        SWP_NOACTIVATE = 0x0010,
        SWP_DRAWFRAME = 0x0020,
        SWP_FRAMECHANGED = 0x0020,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOREPOSITION = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_DEFERERASE = 0x2000,
        SWP_ASYNCWINDOWPOS = 0x4000,
    }
    public enum SetWindowPosInsertAfter
    {
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2,
        HWND_TOP = 0,
        HWND_BOTTOM = 1
    }

    [Flags]
    public enum WindowStyle : uint
    {
        OVERLAPPED = 0,
        POPUP = 0x80000000,
        CHILD = 0x40000000,
        MINIMIZE = 0x20000000,
        VISIBLE = 0x10000000,
        DISABLED = 0x8000000,
        CLIPSIBLINGS = 0x4000000,
        CLIPCHILDREN = 0x2000000,
        MAXIMIZE = 0x1000000,
        CAPTION = 0xC00000,      // BORDER or DLGFRAME  
        BORDER = 0x800000,
        DLGFRAME = 0x400000,
        VSCROLL = 0x200000,
        HSCROLL = 0x100000,
        SYSMENU = 0x80000,
        THICKFRAME = 0x40000,
        GROUP = 0x20000,
        TABSTOP = 0x10000,
        MINIMIZEBOX = 0x20000,
        MAXIMIZEBOX = 0x10000,
        TILED = OVERLAPPED,
        ICONIC = MINIMIZE,
        SIZEBOX = THICKFRAME,

        EX_DLGMODALFRAME = 0x0001,
        EX_NOPARENTNOTIFY = 0x0004,
        EX_TOPMOST = 0x0008,
        EX_ACCEPTFILES = 0x0010,
        EX_TRANSPARENT = 0x0020,
        EX_MDICHILD = 0x0040,
        EX_TOOLWINDOW = 0x0080,
        EX_WINDOWEDGE = 0x0100,
        EX_CLIENTEDGE = 0x0200,
        EX_CONTEXTHELP = 0x0400,
        EX_RIGHT = 0x1000,
        EX_LEFT = 0x0000,
        EX_RTLREADING = 0x2000,
        EX_LTRREADING = 0x0000,
        EX_LEFTSCROLLBAR = 0x4000,
        EX_RIGHTSCROLLBAR = 0x0000,
        EX_CONTROLPARENT = 0x10000,
        EX_STATICEDGE = 0x20000,
        EX_APPWINDOW = 0x40000,
        EX_OVERLAPPEDWINDOW = (EX_WINDOWEDGE | EX_CLIENTEDGE),
        EX_PALETTEWINDOW = (EX_WINDOWEDGE | EX_TOOLWINDOW | EX_TOPMOST),
        EX_LAYERED = SYSMENU,
        EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
        EX_LAYOUTRTL = 0x00400000, // Right to left mirroring
        EX_COMPOSITED = 0x02000000,
        EX_NOACTIVATE = 0x08000000,
    }
    public enum WindowStyleFlags
    {
        GWL_EXSTYLE = (-20),
        GWL_HINSTANCE = (-6),
        GWL_HWNDPARENT = (-8),
        GWL_ID = (-12),
        GWL_STYLE = (-16),
        GWL_USERDATA = (-21),
        GWL_WNDPROC = (-4),
    }

    public enum ShowWindowCommand : uint
    {
        /// <summary>Hides the window and activates another window.</summary>
        /// <remarks>See SW_HIDE</remarks>
        Hide = 0,

        /// <summary>Activates and displays a window. If the window is minimized 
        /// or maximized, the system restores it to its original size and 
        /// position. An application should specify this flag when displaying 
        /// the window for the first time.</summary>
        /// <remarks>See SW_SHOWNORMAL</remarks>
        ShowNormal = 1,

        /// <summary>Activates the window and displays it as a minimized window.</summary>
        /// <remarks>See SW_SHOWMINIMIZED</remarks>
        ShowMinimized = 2,

        /// <summary>Activates the window and displays it as a maximized window.</summary>
        /// <remarks>See SW_SHOWMAXIMIZED</remarks>
        ShowMaximized = 3,

        /// <summary>Maximizes the specified window.</summary>
        /// <remarks>See SW_MAXIMIZE</remarks>
        Maximize = 3,

        /// <summary>Displays a window in its most recent size and position. 
        /// This value is similar to "ShowNormal", except the window is not 
        /// actived.</summary>
        /// <remarks>See SW_SHOWNOACTIVATE</remarks>
        ShowNormalNoActivate = 4,

        /// <summary>Activates the window and displays it in its current size 
        /// and position.</summary>
        /// <remarks>See SW_SHOW</remarks>
        Show = 5,

        /// <summary>Minimizes the specified window and activates the next 
        /// top-level window in the Z order.</summary>
        /// <remarks>See SW_MINIMIZE</remarks>
        Minimize = 6,

        /// <summary>Displays the window as a minimized window. This value is 
        /// similar to "ShowMinimized", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
        ShowMinNoActivate = 7,

        /// <summary>Displays the window in its current size and position. This 
        /// value is similar to "Show", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWNA</remarks>
        ShowNoActivate = 8,

        /// <summary>Activates and displays the window. If the window is 
        /// minimized or maximized, the system restores it to its original size 
        /// and position. An application should specify this flag when restoring 
        /// a minimized window.</summary>
        /// <remarks>See SW_RESTORE</remarks>
        Restore = 9,

        /// <summary>Sets the show state based on the SW_ value specified in the 
        /// STARTUPINFO structure passed to the CreateProcess function by the 
        /// program that started the application.</summary>
        /// <remarks>See SW_SHOWDEFAULT</remarks>
        ShowDefault = 10,

        /// <summary>Windows 2000/XP: Minimizes a window, even if the thread 
        /// that owns the window is hung. This flag should only be used when 
        /// minimizing windows from a different thread.</summary>
        /// <remarks>See SW_FORCEMINIMIZE</remarks>
        ForceMinimized = 11
    }

    public enum ShowWindowCommandShort : short
    {
        /// <summary>Hides the window and activates another window.</summary>
        /// <remarks>See SW_HIDE</remarks>
        Hide = 0,

        /// <summary>Activates and displays a window. If the window is minimized 
        /// or maximized, the system restores it to its original size and 
        /// position. An application should specify this flag when displaying 
        /// the window for the first time.</summary>
        /// <remarks>See SW_SHOWNORMAL</remarks>
        ShowNormal = 1,

        /// <summary>Activates the window and displays it as a minimized window.</summary>
        /// <remarks>See SW_SHOWMINIMIZED</remarks>
        ShowMinimized = 2,

        /// <summary>Activates the window and displays it as a maximized window.</summary>
        /// <remarks>See SW_SHOWMAXIMIZED</remarks>
        ShowMaximized = 3,

        /// <summary>Maximizes the specified window.</summary>
        /// <remarks>See SW_MAXIMIZE</remarks>
        Maximize = 3,

        /// <summary>Displays a window in its most recent size and position. 
        /// This value is similar to "ShowNormal", except the window is not 
        /// actived.</summary>
        /// <remarks>See SW_SHOWNOACTIVATE</remarks>
        ShowNormalNoActivate = 4,

        /// <summary>Activates the window and displays it in its current size 
        /// and position.</summary>
        /// <remarks>See SW_SHOW</remarks>
        Show = 5,

        /// <summary>Minimizes the specified window and activates the next 
        /// top-level window in the Z order.</summary>
        /// <remarks>See SW_MINIMIZE</remarks>
        Minimize = 6,

        /// <summary>Displays the window as a minimized window. This value is 
        /// similar to "ShowMinimized", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWMINNOACTIVE</remarks>
        ShowMinNoActivate = 7,

        /// <summary>Displays the window in its current size and position. This 
        /// value is similar to "Show", except the window is not activated.</summary>
        /// <remarks>See SW_SHOWNA</remarks>
        ShowNoActivate = 8,

        /// <summary>Activates and displays the window. If the window is 
        /// minimized or maximized, the system restores it to its original size 
        /// and position. An application should specify this flag when restoring 
        /// a minimized window.</summary>
        /// <remarks>See SW_RESTORE</remarks>
        Restore = 9,

        /// <summary>Sets the show state based on the SW_ value specified in the 
        /// STARTUPINFO structure passed to the CreateProcess function by the 
        /// program that started the application.</summary>
        /// <remarks>See SW_SHOWDEFAULT</remarks>
        ShowDefault = 10,

        /// <summary>Windows 2000/XP: Minimizes a window, even if the thread 
        /// that owns the window is hung. This flag should only be used when 
        /// minimizing windows from a different thread.</summary>
        /// <remarks>See SW_FORCEMINIMIZE</remarks>
        ForceMinimized = 11
    }

    public enum FlashWindowFlags : uint
    {
        /// <summary>
        /// Stop flashing. The system restores the window to its original state.
        /// </summary>
        FLASHW_STOP = 0,

        /// <summary>
        /// Flash the window caption.
        /// </summary>
        FLASHW_CAPTION = 1,

        /// <summary>
        /// Flash the taskbar button.
        /// </summary>
        FLASHW_TRAY = 2,

        /// <summary>
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        /// </summary>
        FLASHW_ALL = 3,

        /// <summary>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </summary>
        FLASHW_TIMER = 4,

        /// <summary>
        /// Flash continuously until the window comes to the foreground.
        /// </summary>
        FLASHW_TIMERNOFG = 12
    }

    [Flags]
    public enum RedrawWindowFlags : int
    {
        Invalidate = 0x0001,
        InternalPaint = 0x0002,
        Erase = 0x0004,
        Validate = 0x0008,
        NoInternalPaint = 0x0010,
        NoErase = 0x0020,
        NoChildren = 0x0040,
        AllChildren = 0x0080,
        UpdateNow = 0x0100,
        EraseNow = 0x0200,
        Frame = 0x0400,
        NoFrame = 0x0800
    }

    [Flags]
    public enum PrivilegeState
    {
        /// <summary>Privilege is disabled.</summary>
        Disabled = 0,

        /// <summary>Privilege is enabled by default.</summary>
        EnabledByDefault = 1,

        /// <summary>Privilege is enabled.</summary>
        Enabled = 2,

        /// <summary>Privilege is removed.</summary>
        Removed = 4,

        /// <summary>Privilege used to gain access to an object or service.</summary>
        UsedForAccess = -2147483648
    }

    [Flags]
    public enum STARTUPINFO_FLAGS
    {
        FORCE_ON_FEEDBACK = 0x00000040,
        FORCE_OFF_FEEDBACK = 0x00000080,
        PREVENT_PINNING = 0x00002000,
        RUN_FULL_SCREEN = 0x00000020,
        TITLE_IS_APP_ID = 0x00001000,
        TITLE_IS_LINK_NAME = 0x00000800,
        USE_COUNT_CHARS = 0x00000008,
        USE_FILL_ATTRIBUTE = 0x00000010,
        USE_HOTKEY = 0x00000200,
        USE_POSITION = 0x00000004,
        USE_SHOW_WINDOW = 0x00000001,
        USE_SIZE = 0x00000002,
        USE_STD_HANDLES = 0x00000100

    }

    public enum TileWindowsFlags : uint
    {
        MDITILE_VERTICAL = 0x0000,
        MDITILE_HORIZONTAL = 0x0001
    }

    public enum EXTENDED_NAME_FORMAT
    {
        NameUnknown = 0,
        NameFullyQualifiedDN = 1,
        NameSamCompatible = 2,
        NameDisplay = 3,
        NameUniqueId = 6,
        NameCanonical = 7,
        NameUserPrincipal = 8,
        NameCanonicalEx = 9,
        NameServicePrincipal = 10,
    }

    [Flags]
    public enum SCM_ACCESS : uint
    {
        STANDARD_RIGHTS_REQUIRED = 0xF0000,
        CONNECT = 0x00001,
        CREATE_SERVICE = 0x00002,
        ENUMERATE_SERVICE = 0x00004,
        LOCK = 0x00008,
        QUERY_LOCK_STATUS = 0x00010,
        MODIFY_BOOT_CONFIG = 0x00020,
        ALL_ACCESS =
            STANDARD_RIGHTS_REQUIRED |
            CONNECT | CREATE_SERVICE |
            ENUMERATE_SERVICE |
            LOCK | QUERY_LOCK_STATUS |
            MODIFY_BOOT_CONFIG,
        GENERIC_READ =
            ACCESS_MASK.StandardRightsRead |
            ENUMERATE_SERVICE |
            QUERY_LOCK_STATUS,
        GENERIC_WRITE =
            ACCESS_MASK.StandardRightsWrite |
            CREATE_SERVICE |
            MODIFY_BOOT_CONFIG,
        GENERIC_EXECUTE =
            ACCESS_MASK.StandardRightsExecute |
            CONNECT | LOCK,
        GENERIC_ALL = ALL_ACCESS
    }

    [Flags]
    public enum ACCESS_MASK : uint
    {
        Delete = 0x10000,
        ReadControl = 0x20000,
        WriteDac = 0x40000,
        WriteOwner = 0x80000,
        Synchronize = 0x100000,

        MaximumAllowed = 0x02000000,
        SpecificRightsAll = 0x0000ffff,
        AccessSystemSecurity = 0x01000000,

        StandardRightsRequired = 0xf0000,
        StandardRightsRead = 0x20000,
        StandardRightsWrite = 0x00020000,
        StandardRightsExecute = 0x00020000,
        StandardRightsAll = 0x001f0000,

        GenericRead = 0x80000000,
        GenericWrite = 0x40000000,
        GenericExecute = 0x20000000,
        GenericAll = 0x10000000,

        DesktopReadobjects = 0x00000001,
        DesktopCreatewindow = 0x00000002,
        DesktopCreatemenu = 0x00000004,
        DesktopHookcontrol = 0x00000008,
        DesktopJournalrecord = 0x00000010,
        DesktopJournalplayback = 0x00000020,
        DesktopEnumerate = 0x00000040,
        DesktopWriteobjects = 0x00000080,
        DesktopSwitchdesktop = 0x00000100,
        DesktopAll =
            0x00000001 | 0x00000002 | 0x00000004 |
            0x00000008 | 0x00000010 | 0x00000020 |
            0x00000040 | 0x00000080 | 0x00000100,

        WinstaEnumdesktops = 0x00000001,
        WinstaReadattributes = 0x00000002,
        WinstaAccessclipboard = 0x00000004,
        WinstaCreatedesktop = 0x00000008,
        WinstaWriteattributes = 0x00000010,
        WinstaAccessglobalatoms = 0x00000020,
        WinstaExitwindows = 0x00000040,
        WinstaEnumerate = 0x00000100,
        WinstaReadscreen = 0x00000200,

        WinstaAllAccess = 0x0000037f,

        EventAllAccess = 0x1F0003,
        EventModifyState = 0x0002,

        MutexAllAccess = 0x1F0001,
        MutexModifyState = 0x0001,

        SemaphoreAllAccess = 0x1F0003,
        SemaphoreModifyState = 0x0002,

        TimerAllAccess = 0x1F0003,
        TimerModifyState = 0x0002,
        TimerQueryState = 0x0001,

        AdsRightDelete                   = 0x10000,
        AdsRightReadControl             = 0x20000,
        AdsRightWriteDac                = 0x40000,
        AdsRightWriteOwner              = 0x80000,
        AdsRightSynchronize              = 0x100000,
        AdsRightAccessSystemSecurity   = 0x1000000,
        AdsRightGenericRead             = 0x80000000,
        AdsRightGenericWrite            = 0x40000000,
        AdsRightGenericExecute          = 0x20000000,
        AdsRightGenericAll              = 0x10000000,
        AdsRightDsCreateChild          = 0x1,
        AdsRightDsDeleteChild          = 0x2,
        AdsRightActrlDsList            = 0x4,
        AdsRightDsSelf                  = 0x8,
        AdsRightDsReadProp             = 0x10,
        AdsRightDsWriteProp            = 0x20,
        AdsRightDsDeleteTree           = 0x40,
        AdsRightDsListObject           = 0x80,
        AdsRightDsControlAccess        = 0x100,

        KeyQueryValue = (0x0001),
        KeySetValue = (0x0002),
        KeyCreateSubKey = (0x0004),
        KeyEnumerateSubKeys = (0x0008),
        KeyNotify = (0x0010),
        KeyCreateLink = (0x0020),
        KeyWow6432Key = (0x0200),
        KeyWow6464Key = (0x0100),
        KeyWow64Res = (0x0300),
        
        KeyRead =
            (StandardRightsRead |
            KeyQueryValue|
            KeyEnumerateSubKeys|
            KeyNotify) & 
            (~Synchronize),

        KeyWrite = 
            (StandardRightsWrite |
            KeySetValue |
            KeyCreateSubKey) & 
            (~Synchronize),

        KeyExecute =
            (KeyRead ) &
            (~Synchronize),

        KeyAllAccess =
            (StandardRightsAll |
            KeyQueryValue |
            KeySetValue |
            KeyCreateSubKey |
            KeyEnumerateSubKeys|
            KeyNotify|
            KeyCreateLink) &
            (~Synchronize),

    }
    [Flags]
    public enum ServiceType
    {
        KERNEL_DRIVER = 0x00000001,
        FILE_SYSTEM_DRIVER = 0x00000002,
        ADAPTER = 0x00000004,
        RECOGNIZER_DRIVER = 0x00000008,
        WIN32_OWN_PROCESS = 0x00000010,
        WIN32_SHARE_PROCESS = 0x00000020,
        INTERACTIVE_PROCESS = 0x00000100,
        All = ADAPTER | FILE_SYSTEM_DRIVER | KERNEL_DRIVER | RECOGNIZER_DRIVER | WIN32_OWN_PROCESS | WIN32_SHARE_PROCESS | INTERACTIVE_PROCESS
    }
    [Flags]
    public enum StartType
    {
        AUTO_START = 0x00000002,
        BOOT_START = 0x00000000,
        DEMAND_START = 0x00000003,
        DISABLED = 0x00000004,
        SYSTEM_START = 0x00000001
    }
    [Flags]
    public enum ErrorControl
    {
        ERROR_CRITICAL = 0x00000003,
        ERROR_IGNORE = 0x00000000,
        ERROR_NORMAL = 0x00000001,
        ERROR_SEVERE = 0x00000002
    }
    [Flags]
    public enum ServiceState
    {
        ACTIVE = 0x00000001,
        INACTIVE = 0x00000002,
        ALL = 0x00000003
    }
    [Flags]
    public enum ServiceStateEx
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    public enum IP_STATUS : uint
    {
        IP_STATUS_BASE = 11000,

        IP_SUCCESS = 0,
        IP_BUF_TOO_SMALL = (IP_STATUS_BASE + 1),
        IP_DEST_NET_UNREACHABLE = (IP_STATUS_BASE + 2),
        IP_DEST_HOST_UNREACHABLE = (IP_STATUS_BASE + 3),
        IP_DEST_PROT_UNREACHABLE_1 = (IP_STATUS_BASE + 4),
        IP_DEST_PORT_UNREACHABLE_2 = (IP_STATUS_BASE + 5),
        IP_NO_RESOURCES = (IP_STATUS_BASE + 6),
        IP_BAD_OPTION = (IP_STATUS_BASE + 7),
        IP_HW_ERROR = (IP_STATUS_BASE + 8),
        IP_PACKET_TOO_BIG = (IP_STATUS_BASE + 9),
        IP_REQ_TIMED_OUT = (IP_STATUS_BASE + 10),
        IP_BAD_REQ = (IP_STATUS_BASE + 11),
        IP_BAD_ROUTE = (IP_STATUS_BASE + 12),
        IP_TTL_EXPIRED_TRANSIT = (IP_STATUS_BASE + 13),
        IP_TTL_EXPIRED_REASSEM = (IP_STATUS_BASE + 14),
        IP_PARAM_PROBLEM = (IP_STATUS_BASE + 15),
        IP_SOURCE_QUENCH = (IP_STATUS_BASE + 16),
        IP_OPTION_TOO_BIG = (IP_STATUS_BASE + 17),
        IP_BAD_DESTINATION = (IP_STATUS_BASE + 18),

        //
        // Variants of the above using IPv6 terminology, where different
        //

        IP_DEST_NO_ROUTE = (IP_STATUS_BASE + 2),
        IP_DEST_ADDR_UNREACHABLE = (IP_STATUS_BASE + 3),
        IP_DEST_PROHIBITED = (IP_STATUS_BASE + 4),
        IP_DEST_PORT_UNREACHABLE = (IP_STATUS_BASE + 5),
        IP_HOP_LIMIT_EXCEEDED = (IP_STATUS_BASE + 13),
        IP_REASSEMBLY_TIME_EXCEEDED = (IP_STATUS_BASE + 14),
        IP_PARAMETER_PROBLEM = (IP_STATUS_BASE + 15),

        //
        // IPv6-only status codes
        //

        IP_DEST_UNREACHABLE = (IP_STATUS_BASE + 40),
        IP_TIME_EXCEEDED = (IP_STATUS_BASE + 41),
        IP_BAD_HEADER = (IP_STATUS_BASE + 42),
        IP_UNRECOGNIZED_NEXT_HEADER = (IP_STATUS_BASE + 43),
        IP_ICMP_ERROR = (IP_STATUS_BASE + 44),
        IP_DEST_SCOPE_MISMATCH = (IP_STATUS_BASE + 45),

        //
        // The next group are status codes passed up on status indications to
        // transport layer protocols.
        //
        IP_ADDR_DELETED = (IP_STATUS_BASE + 19),
        IP_SPEC_MTU_CHANGE = (IP_STATUS_BASE + 20),
        IP_MTU_CHANGE = (IP_STATUS_BASE + 21),
        IP_UNLOAD = (IP_STATUS_BASE + 22),
        IP_ADDR_ADDED = (IP_STATUS_BASE + 23),
        IP_MEDIA_CONNECT = (IP_STATUS_BASE + 24),
        IP_MEDIA_DISCONNECT = (IP_STATUS_BASE + 25),
        IP_BIND_ADAPTER = (IP_STATUS_BASE + 26),
        IP_UNBIND_ADAPTER = (IP_STATUS_BASE + 27),
        IP_DEVICE_DOES_NOT_EXIST = (IP_STATUS_BASE + 28),
        IP_DUPLICATE_ADDRESS = (IP_STATUS_BASE + 29),
        IP_INTERFACE_METRIC_CHANGE = (IP_STATUS_BASE + 30),
        IP_RECONFIG_SECFLTR = (IP_STATUS_BASE + 31),
        IP_NEGOTIATING_IPSEC = (IP_STATUS_BASE + 32),
        IP_INTERFACE_WOL_CAPABILITY_CHANGE = (IP_STATUS_BASE + 33),
        IP_DUPLICATE_IPADD = (IP_STATUS_BASE + 34),

        IP_GENERAL_FAILURE = (IP_STATUS_BASE + 50),
        MAX_IP_STATUS = IP_GENERAL_FAILURE,
        IP_PENDING = (IP_STATUS_BASE + 255),
    }

    [Flags]
    public enum InfoLevel
    {
        /// <summary>
        /// BOOL fDelayedAutostart
        /// </summary>
        DELAYED_AUTO_START_INFO = 3,

        /// <summary>
        /// IntPtr lpDescription; /* String */
        /// </summary>
        DESCRIPTION = 1,

        /// <summary>
        /// DWORD     dwResetPeriod;
        /// IntPtr    lpRebootMsg;      /* String */
        /// IntPtr    lpCommand;        /* String */
        /// DWORD     cActions;
        /// SC_ACTION *lpsaActions;     /* Array */
        /// </summary>
        FAILURE_ACTIONS = 2,

        /// <summary>
        /// BOOL fFailureActionsOnNonCrashFailures;
        /// </summary>
        FAILURE_ACTIONS_FLAG = 4,

        /// <summary>
        /// USHORT  usPreferredNode;
        /// BOOLEAN fDelete;
        /// </summary>
        PREFERRED_NODE = 9,

        /// <summary>
        /// DWORD dwPreshutdownTimeout;
        /// </summary>
        PRESHUTDOWN_INFO = 7,

        /// <summary>
        /// IntPtr pmszRequiredPrivileges; /* String */
        /// </summary>
        REQUIRED_PRIVILEGES_INFO = 6,

        /// <summary>
        /// DWORD dwServiceSidType;
        /// SERVICE_SID_TYPE_NONE = 0x00000000
        /// SERVICE_SID_TYPE_RESTRICTED = 0x00000003
        /// SERVICE_SID_TYPE_UNRESTRICTED = 0x00000001
        /// </summary>
        SERVICE_SID_INFO = 5,

        /// <summary>
        /// DWORD            cTriggers;
        /// SERVICE_TRIGGER* pTriggers; /* Array */
        /// PBYTE            pReserved;
        /// </summary>
        TRIGGER_INFO = 8
    }
    [Flags]
    public enum ServiceControl
    {
        CONTINUE = 0x00000003,
        INTERROGATE = 0x00000004,
        NETBINDADD = 0x00000007,
        NETBINDDISABLE = 0x0000000A,
        NETBINDENABLE = 0x00000009,
        NETBINDREMOVE = 0x00000008,
        PARAMCHANGE = 0x00000006,
        PAUSE = 0x00000002,
        STOP = 0x00000001
    }
    [Flags]
    public enum ServiceControlEx
    {
        NETBINDCHANGE = 0x00000010,
        PARAMCHANGE = 0x00000008,
        PAUSE_CONTINUE = 0x00000002,
        PRESHUTDOWN = 0x00000100,
        SHUTDOWN = 0x00000004,
        STOP = 0x00000001,
        HARDWAREPROFILECHANGE = 0x00000020,
        POWEREVENT = 0x00000040,
        SESSIONCHANGE = 0x00000080
    }
    [Flags]
    public enum ServiceFlags
    {
        Default = 0x00000000,
        SERVICE_RUNS_IN_SYSTEM_PROCESS = 0x00000001
    }
    [Flags]
    public enum ServiceAccept
    {
        NETBINDCHANGE = 0x00000010,
        PARAMCHANGE = 0x00000008,
        PAUSE_CONTINUE = 0x00000002,
        PRESHUTDOWN = 0x00000100,
        SHUTDOWN = 0x00000004,
        STOP = 0x00000001,
        HARDWAREPROFILECHANGE = 0x00000020,
        POWEREVENT = 0x00000040,
        SESSIONCHANGE = 0x00000080,
        TIMECHANGE = 0x00000200,
        TRIGGEREVENT = 0x00000400
    }
    [Flags]
    public enum State
    {
        CONTINUE_PENDING = 0x00000005,
        PAUSE_PENDING = 0x00000006,
        PAUSED = 0x00000007,
        RUNNING = 0x00000004,
        START_PENDING = 0x00000002,
        STOP_PENDING = 0x00000003,
        STOPPED = 0x00000001
    }
    [Flags]
    public enum RegAccess
    {
        QueryValue = 0x0001,
        SetValue = 0x0002,
        CreateSubKey = 0x0004,
        EnumerateSubKeys = 0x0008,
        Notify = 0x0010,
        CreateLink = 0x0020,
        Wow6432Key = 0x0200,
        Wow6464Key = 0x0100,
        Wow64Res = 0x0300,
        Read = 0x00020019,
        Write = 0x00020006,
        Execute = 0x00020019,
        AllAccess = 0x000f003f
    }
    [Flags]
    public enum RegOptions
    {
        NonVolatile = 0x0,
        Volatile = 0x1,
        CreateLink = 0x2,
        BackupRestore = 0x4,
        OpenLink = 0x8
    }

    public enum RegDisposition
    {
        CREATED_NEW_KEY = 0x00000001,
        OPENED_EXISTING_KEY = 0x00000002
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724884(v=vs.85).aspx
    /// </summary>
    public enum RegFlags
    {
        /// <summary>
        /// Any
        /// </summary>
        Any = 65535,

        /// <summary>
        /// No defined value type.
        /// </summary>
        RegNone = 1,

        /// <summary>
        /// ???
        /// </summary>
        Noexpand = 268435456,

        /// <summary>
        /// Bytes
        /// </summary>
        RegBinary = 8,

        /// <summary>
        /// Int32
        /// </summary>
        Dword = 24,

        /// <summary>
        /// Int32
        /// </summary>
        RegDword = 16,

        /// <summary>
        /// Int64
        /// </summary>
        Qword = 72,

        /// <summary>
        /// Int64
        /// </summary>
        RegQword = 64,

        /// <summary>
        /// A null-terminated string.
        /// This will be either a Unicode or an ANSI string,
        /// depending on whether you use the Unicode or ANSI functions.
        /// </summary>
        RegSz = 2,

        /// <summary>
        /// A sequence of null-terminated strings, terminated by an empty string (\0).
        /// The following is an example:
        /// String1\0String2\0String3\0LastString\0\0
        /// The first \0 terminates the first string, the second to the last \0 terminates the last string, 
        /// and the final \0 terminates the sequence. Note that the final terminator must be factored into the length of the string.
        /// </summary>
        RegMultiSz = 32,

        /// <summary>
        /// A null-terminated string that contains unexpanded references to environment variables (for example, "%PATH%").
        /// It will be a Unicode or ANSI string depending on whether you use the Unicode or ANSI functions. 
        /// To expand the environment variable references, use the ExpandEnvironmentStrings function.
        /// </summary>
        RegExpandSz = 4,

        RrfZeroonfailure = 536870912
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724884(v=vs.85).aspx
    /// </summary>
    public enum RegType
    {
        RegNone = 0,

        // String
        RegSz = 1,
        RegExpandSz = 2,
        RegMultiSz = 7,

        // Byte's
        RegBinary = 3,
        // Int32
        RegDword = 4,
        // Int64
        RegQword = 11,

        RegQwordLittleEndian = 11,
        RegDwordLittleEndian = 4,
        RegDwordBigEndian = 5,

        RegLink = 6,
        RegResourceList = 8,
        RegFullResourceDescriptor = 9,
        RegResourceRequirementsList = 10,
    }
    public enum RegFormat
    {
        REG_STANDARD_FORMAT = 1,
        REG_LATEST_FORMAT = 2,
        REG_NO_COMPRESSION = 4
    }
    public enum RegRestore
    {
        REG_FORCE_RESTORE = 0x00000008,
        REG_WHOLE_HIVE_VOLATILE = 0x00000001
    }
    [Flags]
    public enum RegNotifyFilter
    {
        ChangeName = 0x00000001,
        ChangeAttributes = 0x00000002,
        ChangeLastSet = 0x00000004,
        ChangeSecurity = 0x00000008,
        All = 0x00000001 | 0x00000002 | 0x00000004 | 0x00000008
    }

    public enum CreateEventFlags
    {
        ManualReset = 0x00000001,
        InitialSet = 0x00000002
    }

    [Flags]
    public enum SECURITY_INFORMATION : uint
    {
        OwnerSecurityInformation = 0x01,
        GroupSecurityInformation = 0x02,
        DaclSecurityInformation = 0x04,
        SaclSecurityInformation = 0x08,
        LabelSecurityInformation = 0x10,
        ProtectedDaclSecurityInformation = 0x80000000,
        ProtectedSaclSecurityInformation = 0x40000000,
        UnprotectedDaclSecurityInformation = 0x20000000,
        UnprotectedSaclSecurityInformation = 0x10000000,

        All =
            OwnerSecurityInformation |
            GroupSecurityInformation |
            DaclSecurityInformation |
            SaclSecurityInformation |
            LabelSecurityInformation |
            ProtectedDaclSecurityInformation |
            ProtectedSaclSecurityInformation |
            UnprotectedDaclSecurityInformation |
            UnprotectedSaclSecurityInformation,

        AllLite =
            0x01 |
            0x02 |
            0x04,

        AllNamed =
            0x00000001 |
            0x00000002 |
            0x00000004 |
            0x00000008 |
            0x00000010 |
            0x00000020 |
            0x00000040
    }

    [Flags]
    public enum SECURITY_DESCRIPTOR_CONTROL : short
    {
        SeOwnerDefaulted = 0x1,
        SeGroupDefaulted = 0x2,
        SeDaclPresent = 0x4,
        SeDaclDefaulted = 0x8,
        SeSaclPresent = 0x10,
        SeSaclDefaulted = 0x20,
        SeDaclAutoInheritReq = 0x100,
        SeSaclAutoInheritReq = 0x200,
        SeDaclAutoInherited = 0x400,
        SeSaclAutoInherited = 0x800,
        SeDaclProtected = 0x1000,
        SeSaclProtected = 0x2000,
        //SeSelfRelative = 0x8000

    }
    [Flags]
    public enum WT_CREATE : uint
    {
        ExecuteDefault = 0x00000000,
        ExecuteInTimerthread = 0x00000020,
        ExecuteInIoThread = 0x00000001,
        ExecuteInPersistentthread = 0x00000080,
        ExecuteLongFunction = 0x00000010,
        ExecuteOnlyOnce = 0x00000008,
        TransferImpersonation = 0x00000100
    }
    public enum CREATE_WAITABLE_TIMER
    {
        Default = 0,
        ManualReset = 0x00000001
    }
    [Flags]
    public enum NotifyFilter
    {
        ChangeFileName = 0x00000001,
        ChangeDirName = 0x00000002,
        ChangeAttributes = 0x00000004,
        ChangeSize = 0x00000008,
        ChangeLastWrite = 0x00000010,
        ChangeSecurity = 0x00000100
    }

    [Flags]
    public enum DriveType
    {
        Unknown = 0,
        NoRootDir = 1,
        Removable = 2,
        Fixed = 3,
        Remote = 4,
        Cdrom = 5,
        Ramdisk = 6
    }

    [Flags]
    public enum FileSystemFlags : uint
    {
        /// <summary>
        /// The file system supports case-sensitive file names. 
        /// </summary>
        FILE_CASE_SENSITIVE_SEARCH = 0x00000001,
        /// <summary>
        /// The file system preserves the case of file names when it places a name on disk. 
        /// </summary>
        FILE_CASE_PRESERVED_NAMES = 0x00000002,
        /// <summary>
        /// The file system supports Unicode in file names.  
        /// </summary>
        FILE_UNICODE_ON_DISK = 0x00000004,
        /// <summary>
        /// The file system preserves and enforces access control lists (ACL).  
        /// </summary>
        FILE_PERSISTENT_ACLS = 0x00000008,
        /// <summary>
        /// The file system supports file-based compression. This flag is incompatible with the FILE_VOLUME_IS_COMPRESSED flag.  
        /// </summary>
        FILE_FILE_COMPRESSION = 0x00000010,
        /// <summary>
        /// The file system supports per-user quotas.  
        /// </summary>
        FILE_VOLUME_QUOTAS = 0x00000020,
        /// <summary>
        /// The file system supports sparse files.  
        /// </summary>
        FILE_SUPPORTS_SPARSE_FILES = 0x00000040,
        /// <summary>
        /// The file system supports reparse points.  
        /// </summary>
        FILE_SUPPORTS_REPARSE_POINTS = 0x00000080,
        /// <summary>
        /// The file system supports remote storage.  
        /// </summary>
        FILE_SUPPORTS_REMOTE_STORAGE = 0x00000100,
        FS_LFN_APIS = 0x00004000,
        /// <summary>
        /// The specified volume is a compressed volume. This flag is incompatible with the FILE_FILE_COMPRESSION flag.  
        /// </summary>
        FILE_VOLUME_IS_COMPRESSED = 0x00008000,
        /// <summary>
        /// The file system supports object identifiers.  
        /// </summary>
        FILE_SUPPORTS_OBJECT_IDS = 0x00010000,
        /// <summary>
        /// The file system supports the Encrypted File System (EFS).  
        /// </summary>
        FILE_SUPPORTS_ENCRYPTION = 0x00020000,
        /// <summary>
        /// The file system supports named streams.  
        /// </summary>
        FILE_NAMED_STREAMS = 0x00040000,
        /// <summary>
        /// Microsoft Windows XP and later: The specified volume is read-only.  
        /// </summary>
        FILE_READ_ONLY_VOLUME = 0x00080000

    }

    [Flags]
    public enum DDD_FLAGS
    {
        RAW_TARGET_PATH = 0x00000001,
        REMOVE_DEFINITION = 0x00000002,
        EXACT_MATCH_ON_REMOVE = 0x00000004,
        NO_BROADCAST_SYSTEM = 0x00000008,
        Removesymboliclink =
            RAW_TARGET_PATH |
            REMOVE_DEFINITION |
            EXACT_MATCH_ON_REMOVE
    }

    public enum InputType
    {
        InputMouse = 0,
        InputKeyboard = 1,
        InputHardware = 2
    }
    [Flags]
    public enum UserPriv
    {
        Guest = 0,
        User = 1,
        Admin = 2
    }
    [Flags]
    public enum UserGroupAttributes : uint
    {
        MANDATORY = 0x00000001,
        ENABLED_BY_DEFAULT = 0x00000002,
        ENABLED = 0x00000004,
        OWNER = 0x00000008,
        USE_FOR_DENY_ONLY = 0x00000010,
        INTEGRITY = 0x00000020,
        INTEGRITY_ENABLED = 0x00000040,
        RESOURCE = 0x20000000,
        LOGON_ID = 0xC0000000,

        VALID_ATTRIBUTES =
            (MANDATORY |
             ENABLED_BY_DEFAULT |
             ENABLED |
             OWNER |
             USE_FOR_DENY_ONLY |
             LOGON_ID |
             RESOURCE |
             INTEGRITY |
             INTEGRITY_ENABLED)
    }
    [Flags]
    public enum UserFlags
    {
        SCRIPT = 0x00000001,
        ACCOUNTDISABLE = 0x00000002,
        HOMEDIR_REQUIRED = 0x00000008,
        PASSWD_NOTREQD = 0x00000020,
        PASSWD_CANT_CHANGE = 0x00000040,
        LOCKOUT = 0x00000010,
        DONT_EXPIRE_PASSWD = 0x00010000,
        ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x00000080,
        NOT_DELEGATED = 0x00100000,
        SMARTCARD_REQUIRED = 0x00040000,
        USE_DES_KEY_ONLY = 0x00200000,
        DONT_REQUIRE_PREAUTH = 0x00400000,
        TRUSTED_FOR_DELEGATION = 0x00080000,
        PASSWORD_EXPIRED = 0x00800000,
        TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x01000000,

        // The following values describe the account type. Only one value can be set.
        // You cannot change the account type using the NetUserSetInfo function.

        NORMAL_ACCOUNT = 0x00000200,
        TEMP_DUPLICATE_ACCOUNT = 0x00000100,
        WORKSTATION_TRUST_ACCOUNT = 0x00001000,
        SERVER_TRUST_ACCOUNT = 0x00002000,
        INTERDOMAIN_TRUST_ACCOUNT = 0x00000800
    }
    [Flags]
    public enum UserAuth
    {
        AfOpPrint = 1,
        AfOpComm = 2,
        AfOpServer = 4,
        AfOpAccounts = 8
    }

    public enum UserGlobalGroup
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1
    }
    public enum NetLocalGroupEnum
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1
    }

    public enum NetGroupUsers
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1
    }
    public enum NetGroup
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1,
        GroupInfo2 = 2,
        GroupInfo3 = 3
    }
    public enum NetGroupEx
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1,
        GroupInfo2 = 2,
        GroupInfo3 = 3,

        GroupInfo1002 = 1002,
        GroupInfo1005 = 1005
    }

    public enum NetShareAdd
    {
        ShareInfo2 = 2,

        ShareInfo502 = 502,
        ShareInfo503 = 503
    }
    public enum NetShareDel
    {
        ShareInfo0 = 0,
        ShareInfo1 = 1,
        ShareInfo2 = 2,

        ShareInfo502 = 502,
        ShareInfo503 = 503
    }
    public enum NetShareGet
    {
        ShareInfo0 = 0,
        ShareInfo1 = 1,
        ShareInfo2 = 2,

        ShareInfo501 = 501,
        ShareInfo502 = 502,
        ShareInfo503 = 503,

        ShareInfo1005 = 1005
    }
    public enum NetShareSet
    {
        ShareInfo1 = 1,
        ShareInfo2 = 2,

        ShareInfo502 = 502,
        ShareInfo503 = 503,

        ShareInfo1004 = 1004,
        ShareInfo1005 = 1005,
        ShareInfo1006 = 1006,

        ShareInfo1501 = 1501
    }
    public enum NetShareEnum
    {
        ShareInfo0 = 0,
        ShareInfo1 = 1,
        ShareInfo2 = 2,

        ShareInfo502 = 502,
        ShareInfo503 = 503
    }
    public enum NetShareEnumEx
    {
        ConnectionInfo0 = 0,
        ConnectionInfo1 = 1
    }

    public enum NetLocalGroupAdd
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1
    }
    public enum NetLocalGroupGet
    {
        GroupInfo1 = 1
    }
    public enum NetLocalGroupGetEx
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1,
        GroupInfo2 = 2,
        GroupInfo3 = 3,
    }
    public enum NetLocalGroupSet
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1,
        GroupInfo1002 = 1002
    }
    public enum NetLocalGroupSetEx
    {
        GroupInfo0 = 0,
        GroupInfo3 = 3
    }
    public enum UserLocalGroupGet
    {
        GroupInfo0 = 0
    }
    public enum UserLocalGroupMember
    {
        GroupInfo0 = 0,
        GroupInfo3 = 3
    }

    public enum NetUseAdd
    {
        GroupInfo1 = 1,
        GroupInfo2 = 2
    }
    public enum NetUseGet
    {
        GroupInfo0 = 0,
        GroupInfo1 = 1,
        GroupInfo2 = 2
    }

    public enum ForceCondition
    {
        Noforce = 0,
        Force,
        LotsOfForce
    }
    public enum UserLocalGroupFlags
    {
        LG_INCLUDE_INDIRECT = 1
    }
    public enum UserLevelAdd : uint
    {
        Info1 = 1,
        Info2 = 2,
        Info3 = 3,
        Info4 = 4
    }
    public enum UserLevelGet : uint
    {
        Info0 = 0,
        Info1 = 1,
        Info2 = 2,
        Info3 = 3,
        Info4 = 4,
        Info10 = 10,
        Info11 = 11,
        Info20 = 20,
        Info23 = 23
    }
    public enum UserLevelSet : uint
    {
        Info0 = 0,
        Info1 = 1,
        Info2 = 2,
        Info3 = 3,
        Info4 = 4,
        Info21 = 21,
        Info22 = 22,

        Info1003 = 1003,
        Info1005 = 1005,
        Info1006 = 1006,
        Info1007 = 1007,
        Info1008 = 1008,
        Info1009 = 1009,
        Info1010 = 1010,
        Info1011 = 1011,
        Info1012 = 1012,
        Info1014 = 1014,
        Info1017 = 1017,
        Info1020 = 1020,
        Info1024 = 1024,
        Info1051 = 1051,
        Info1052 = 1052,
        Info1053 = 1053
    }
    public enum UserLevelEnum : uint
    {
        Info0 = 0,
        Info1 = 1,
        Info2 = 2,
        Info3 = 3,
        Info10 = 10,
        Info11 = 11,
        Info20 = 20,
        Info23 = 23
    }
    [Flags]
    public enum UserFilter : uint
    {
        TempDuplicateAccount = 1,
        NormalAccount = 2,
        InterdomainTrustAccount = 8,
        WorkstationTrustAccount = 16,
        ServerTrustAccount = 32
    }
    [Flags]
    public enum SE_GROUP : uint
    {
        MANDATORY = 0x00000001,
        ENABLED_BY_DEFAULT = 0x00000002,
        ENABLED = 0x00000004,
        OWNER = 0x00000008,
        USE_FOR_DENY_ONLY = 0x00000010,
        INTEGRITY = 0x00000020,
        INTEGRITY_ENABLED = 0x00000040,
        LOGON_ID = 0xC0000000,
        RESOURCE = 0x20000000
    }
    [Flags]
    public enum ConnectionStatus : uint
    {
        USE_OK = 0,
        USE_PAUSED,
        USE_SESSLOST,
        USE_DISCONN,
        USE_NETERR,
        USE_CONN,
        USE_RECONN
    }
    [Flags]
    public enum ResourceType : uint
    {
        USE_WILDCARD = unchecked((uint)-1),
        USE_DISKDEV = 0,
        USE_SPOOLDEV = 1,
        USE_CHARDEV = 2,
        USE_IPC = 3
    }
    [Flags]
    public enum ConnectionCreate
    {
        NO_CONNECT = 0x1,
        BYPASS_CSC = 0x2,
        CRED_RESET = 0x4
    }
    [Flags]
    public enum DeviceType : uint
    {
        STYPE_DISKTREE = 0,
        PRINTQ = 1,
        STYPE_DEVICE = 2,
        STYPE_IPC = 3,
        STYPE_TEMPORARY = 0x40000000,
        STYPE_SPECIAL = 0x80000000
    }

    [Flags]
    public enum Permissions : uint
    {
        READ = 0x01,
        WRITE = 0x02,
        CREATE = 0x04,
        EXEC = 0x08,
        DELETE = 0x10,
        ATRIB = 0x20,
        PERM = 0x40,
        GROUP = 0x8000,

        NONE = 0,
        ALL = READ | WRITE | CREATE | EXEC | DELETE | ATRIB | PERM
    }
    [Flags]
    public enum SHI1005 : uint
    {
        FLAGS_DFS = 0x0001,
        FLAGS_DFS_ROOT = 0x0002,
        RESTRICT_EXCLUSIVE_OPENS = 0x0100,
        FORCE_SHARED_DELETE = 0x0200,
        ALLOW_NAMESPACE_CACHING = 0x0400,
        ACCESS_BASED_DIRECTORY_ENUM = 0x0800,
        FORCE_LEVELII_OPLOCK = 0x1000,
        ENABLE_HASH = 0x2000,
        ENABLE_CA = 0X4000,

        CSC_MASK = 0x0030,
        CSC_MASK_EXT = 0x2030
    }
    [Flags]
    public enum Permissions2 : uint
    {
        FILE_READ = 0x1,
        FILE_WRITE = 0x2,
        FILE_CREATE = 0x4
    }

    public enum SESS : uint
    {
        // session is logged on as a guest
        SESS_GUEST = 0x00000001,
        // session is not using encryption
        SESS_NOENCRYPTION = 0x00000002
    }

    public enum NetFile : uint
    {
        Info2 = 2,
        Info3 = 3
    }
    public enum NetSessionAdd
    {
        Info0 = 0,
        Info1 = 1,
        Info2 = 2,
        Info10 = 10
    }
    public enum NetSessionEnum
    {
        Info0 = 0,
        Info1 = 1,
        Info2 = 2,
        Info10 = 10,
        Info502 = 502
    }

    [Flags]
    public enum IeSettingOptions : uint
    {
        InternetPerConnFlags = 1,
        InternetPerConnProxyServer = 2,
        InternetPerConnProxyBypass = 3,
        InternetPerConnAutoconfigUrl = 4,
        InternetPerConnAutodiscoveryFlags = 5,
        InternetPerConnAutoconfigSecondaryUrl = 6,
        InternetPerConnAutoconfigReloadDelayMins = 7,
        InternetPerConnAutoconfigLastDetectTime = 8,
        InternetPerConnAutoconfigLastDetectUrl = 9

    };
    public enum InternetOption : uint
    {
        Callback = 1,
        ConnectTimeout = 2,
        ConnectRetries = 3,
        ConnectBackoff = 4,
        SendTimeout = 5,
        ControlSendTimeout = SendTimeout,
        ReceiveTimeout = 6,
        ControlReceiveTimeout = ReceiveTimeout,
        DataSendTimeout = 7,
        DataReceiveTimeout = 8,
        HandleType = 9,
        ListenTimeout = 11,
        ReadBufferSize = 12,
        WriteBufferSize = 13,

        AsyncID = 15,
        AsyncPriority = 16,

        ParentHandle = 21,
        KeepConnection = 22,
        RequestFlags = 23,
        ExtendedError = 24,

        OfflineMode = 26,
        CacheStreamHandle = 27,
        UserName = 28,
        Password = 29,
        Async = 30,
        SecurityFlags = 31,
        SecurityCertificateStruct = 32,
        DatafileName = 33,
        Url = 34,
        SecurityCertificate = 35,
        SecurityKeyBitness = 36,

        /// <summary>
        /// manually refresh settings after 'PerConnectionOption' Flag
        /// </summary>
        Refresh = 37,

        Proxy = 38,
        SettingsChanged = 39,
        Version = 40,
        UserAgent = 41,
        EndBrowserSession = 42,
        ProxyUSERNAME = 43,
        ProxyPassword = 44,
        ContextValue = 45,
        ConnectLimit = 46,
        SecuritySelectClientCert = 47,
        Policy = 48,
        DisconnectedTimeout = 49,
        ConnectedState = 50,
        IdleState = 51,
        OfflineSemantics = 52,
        SecondaryCacheKey = 53,
        CallbackFilter = 54,
        ConnectTime = 55,
        SendThroughput = 56,
        ReceiveThroughput = 57,
        RequestPriority = 58,
        HttpVersion = 59,
        ResetUrlcacheSession = 60,
        ErrorMask = 62,
        FromCacheTimeout = 63,
        BypassEditedEntry = 64,
        DiagnosticSocketInfo = 67,
        CodePage = 68,
        CacheTimestamps = 69,
        DisableAutodial = 70,
        MaxConnsPerServer = 73,
        MaxConnsPer10Server = 74,

        /// <summary>
        /// INTERNET_PER_CONNECTION_OPTION_LIST structure
        /// </summary>
        PerConnectionOption = 75,

        DigestAuthUnload = 76,
        IgnoreOffline = 77,
        Identify = 78,
        RemoveIdentity = 79,
        AlterIdentity = 80,
        SuppressBehavior = 81,
        AutodialMode = 82,
        AutodialConnection = 83,
        ClientCertContext = 84,
        AuthFlags = 85,
        Cookies3RdParty = 86,
        DisablePassportAuth = 87,
        SendUtf8ServernameToProxy = 88,
        ExemptConnectionLimit = 89,
        EnablePassportAuth = 90,

        HibernateInactiveWorkerThreads = 91,
        ActivateWorkerThreads = 92,
        RestoreWorkerThreadDefaults = 93,
        SocketSendBufferLength = 94,
        ProxySettingsChanged = 95,

        DatafileExt = 96,

        InternetFirstOption = Callback,
        InternetLastOption = DatafileExt
    }

    [Flags]
    public enum ProfileType : uint
    {
        Temporary = 0x00000001, // A profile has been allocated that will be deleted at logoff.
        Roaming = 0x00000002,   // The loaded profile is a roaming profile.
        Mandatory = 0x00000004  // The loaded profile is mandatory.
    }

    [Flags]
    public enum DnsFreeType
    {
        Flat = 0,
        RecordList = 1,
        ParsedMessageFields = 2
    }

    [Flags]
    public enum DnsConfigType
    {
        DomainNameW,
        DomainNameA,
        DomainNameUtf8,
        DnsConfigAdapterDomainNameW,
        DnsConfigAdapterDomainNameA,
        DnsConfigAdapterDomainNameUtf8,
        DnsConfigDnsServerList,
        DnsConfigSearchList,
        DnsConfigAdapterInfo,
        HostNameRegistrationEnabled,
        DnsConfigAdapterHostNameRegistrationEnabled,
        DnsConfigAddressRegistrationMaxCount,
        DnsConfigHostNameW,
        DnsConfigHostNameA,
        DnsConfigHostNameUtf8,
        DnsConfigFullHostNameW,
        DnsConfigFullHostNameA,
        DnsConfigFullHostNameUtf
    }

    [Flags]
    public enum DnsCharset
    {
        DnsCharSetUnknown,
        DnsCharSetUnicode,
        DnsCharSetUtf8,
        DnsCharSetAnsi
    }

    [Flags]
    public enum QueryUpdate : uint
    {
        DnsUpdateSecurityUseDefault = 0x00000000,
        DnsUpdateSecurityOff = 0x00000010,
        DnsUpdateSecurityOn = 0x00000020,
        DnsUpdateSecurityOnly = 0x00000100,
        DnsUpdateCacheSecurityContext = 0x00000200,
        DnsUpdateTestUseLocalSysAcct = 0x00000400,
        DnsUpdateForceSecurityNego = 0x00000800,
        DnsUpdateTryAllMasterServers = 0x00001000,
        DnsUpdateSkipNoUpdateAdapters = 0x00002000,
        DnsUpdateRemoteServer = 0x00004000,
        DnsUpdateReserved = 0xffff0000
    }

    [Flags]
    public enum DnsNameFormat
    {
        DnsNameDomain,
        DnsNameDomainLabel,
        DnsNameHostnameFull,
        DnsNameHostnameLabel,
        DnsNameWildcard,
        DnsNameSrvRecord,
        DnsNameValidateTld
    }

    [Flags]
    public enum DnsProxyInformationType
    {
        Direct,
        DefaultSettings,
        ProxyName,
        DoesNotExist
    }

    [Flags]
    public enum NetConnected : uint
    {
        Null = 0x00000000,
        UpdateProfile = 0x00000001,
        UpdateRecent = 0x00000002,
        Temporary = 0x00000004,
        Interactive = 0x00000008,
        Prompt = 0x00000010,
        NeedDrive = 0x00000020,
        Refcount = 0x00000040,
        Redirect = 0x00000080,
        Localdrive = 0x00000100,
        CurrentMedia = 0x00000200,
        Deferred = 0x00000400,
        Reserved = 0xFF000000,
        Commandline = 0x00000800,
        CmdSavecred = 0x00001000,
        CredReset = 0x00002000
    }

    [Flags]
    public enum NetResourceScope : uint
    {
        Connected = 0x00000001,
        Globalnet = 0x00000002,
        Remembered = 0x00000003,
        Recent = 0x00000004,
        Context = 0x00000005
    }

    [Flags]
    public enum NetResourceType : uint
    {
        Any = 0,
        Disk = 1,
        Print = 2
    }

    [Flags]
    public enum NetResourceDisplayType : uint
    {
        Generic = 0x00000000,
        Domain = 0x00000001,
        Server = 0x00000002,
        Share = 0x00000003,
        File = 0x00000004,
        Group = 0x00000005,
        Network = 0x00000006,
        Root = 0x00000007,
        Shareadmin = 0x00000008,
        Directory = 0x00000009,
        Tree = 0x0000000A,
        Ndscontainer = 0x0000000B
    }

    [Flags]
    public enum NetResourceUsage : uint
    {
        Connectable = 0x00000001,
        Container = 0x00000002,
        Nolocaldevice = 0x00000004,
        Sibling = 0x00000008,
        Attached = 0x00000010,
        All = Connectable | Container | Attached,
        Reserved = 0x80000000
    }

    [Flags]
    public enum SocketSecurityProtocol
    {
        Default,
        Ipsec,
        Invalid
    }

    [Flags]
    public enum SecurityFlags
    {
        GuaranteeEncryption = 0x00000001,
        AllowInsecure = 0x00000002
    }

    [Flags]
    public enum WinEeventFlags : uint
    {
        /// <summary>
        /// Events are ASYNC
        /// </summary>
        OutOfContext = 0x0000,

        /// <summary>
        /// Don't call back for events on installer's thread
        /// </summary>
        SkipOwnThread = 0x0001,

        /// <summary>
        /// Don't call back for events on installer's process
        /// </summary>
        SkipOwnProcess = 0x0002,

        /// <summary>
        /// Events are SYNC, this causes your dll to be injected into every process
        /// </summary>
        InContext = 0x0004
    }

    public enum AccessibleEventType : uint
    {
        /// <summary>
        /// The lowest possible event value
        /// </summary>
        EventMin = 0x00000001,

        /// <summary>
        /// The highest possible event value
        /// </summary>
        EventMax = 0x7FFFFFFF,

        /// <summary>
        ///  Sent when a sound is played.  Currently nothing is generating this, we
        ///  are going to be cleaning up the SOUNDSENTRY feature in the control panel
        ///  and will use this at that time.  Applications implementing WinEvents
        ///  are perfectly welcome to use it.  Clients of IAccessible* will simply
        ///  turn around and get back a non-visual object that describes the sound.
        /// </summary>
        EventSystemSound = 0x0001,

        /// <summary>
        /// Sent when an alert needs to be given to the user.  MessageBoxes generate
        /// alerts for example.
        /// </summary>
        EventSystemAlert = 0x0002,

        /// <summary>
        /// Sent when the foreground (active) window changes, even if it is changing
        /// to another window in the same thread as the previous one.
        /// </summary>
        EventSystemForeground = 0x0003,

        /// <summary>
        /// Sent when entering into and leaving from menu mode (system, app bar, and
        /// track popups).
        /// </summary>
        EventSystemMenustart = 0x0004,

        /// <summary>
        /// Sent when entering into and leaving from menu mode (system, app bar, and
        /// track popups).
        /// </summary>
        EventSystemMenuend = 0x0005,

        /// <summary>
        /// Sent when a menu popup comes up and just before it is taken down.  Note
        /// that for a call to TrackPopupMenu(), a client will see EVENT_SYSTEM_MENUSTART
        /// followed almost immediately by EVENT_SYSTEM_MENUPOPUPSTART for the popup
        /// being shown.
        /// </summary>
        EventSystemMenupopupstart = 0x0006,

        /// <summary>
        /// Sent when a menu popup comes up and just before it is taken down.  Note
        /// that for a call to TrackPopupMenu(), a client will see EVENT_SYSTEM_MENUSTART
        /// followed almost immediately by EVENT_SYSTEM_MENUPOPUPSTART for the popup
        /// being shown.
        /// </summary>
        EventSystemMenupopupend = 0x0007,


        /// <summary>
        /// Sent when a window takes the capture and releases the capture.
        /// </summary>
        EventSystemCapturestart = 0x0008,

        /// <summary>
        /// Sent when a window takes the capture and releases the capture.
        /// </summary>
        EventSystemCaptureend = 0x0009,

        /// <summary>
        /// Sent when a window enters and leaves move-size dragging mode.
        /// </summary>
        EventSystemMovesizestart = 0x000A,

        /// <summary>
        /// Sent when a window enters and leaves move-size dragging mode.
        /// </summary>
        EventSystemMovesizeend = 0x000B,

        /// <summary>
        /// Sent when a window enters and leaves context sensitive help mode.
        /// </summary>
        EventSystemContexthelpstart = 0x000C,

        /// <summary>
        /// Sent when a window enters and leaves context sensitive help mode.
        /// </summary>
        EventSystemContexthelpend = 0x000D,

        /// <summary>
        /// Sent when a window enters and leaves drag drop mode.  Note that it is up
        /// to apps and OLE to generate this, since the system doesn't know.  Like
        /// EVENT_SYSTEM_SOUND, it will be a while before this is prevalent.
        /// </summary>
        EventSystemDragdropstart = 0x000E,

        /// <summary>
        /// Sent when a window enters and leaves drag drop mode.  Note that it is up
        /// to apps and OLE to generate this, since the system doesn't know.  Like
        /// EVENT_SYSTEM_SOUND, it will be a while before this is prevalent.
        /// </summary>
        EventSystemDragdropend = 0x000F,

        /// <summary>
        /// Sent when a dialog comes up and just before it goes away.
        /// </summary>
        EventSystemDialogstart = 0x0010,

        /// <summary>
        /// Sent when a dialog comes up and just before it goes away.
        /// </summary>
        EventSystemDialogend = 0x0011,

        /// <summary>
        /// Sent when beginning and ending the tracking of a scrollbar in a window,
        /// and also for scrollbar controls.
        /// </summary>
        EventSystemScrollingstart = 0x0012,

        /// <summary>
        /// Sent when beginning and ending the tracking of a scrollbar in a window,
        /// and also for scrollbar controls.
        /// </summary>
        EventSystemScrollingend = 0x0013,

        /// <summary>
        /// Sent when beginning and ending alt-tab mode with the switch window.
        /// </summary>
        EventSystemSwitchstart = 0x0014,

        /// <summary>
        /// Sent when beginning and ending alt-tab mode with the switch window.
        /// </summary>
        EventSystemSwitchend = 0x0015,

        /// <summary>
        /// Sent when a window minimizes.
        /// </summary>
        EventSystemMinimizestart = 0x0016,

        /// <summary>
        /// Sent just before a window restores.
        /// </summary>
        EventSystemMinimizeend = 0x0017,

        /// <summary>
        /// hwnd + ID + idChild is created item
        /// </summary>
        EventObjectCreate = 0x8000,

        /// <summary>
        /// hwnd + ID + idChild is destroyed item
        /// </summary>
        EventObjectDestroy = 0x8001,

        /// <summary>
        /// hwnd + ID + idChild is shown item
        /// </summary>
        EventObjectShow = 0x8002,

        /// <summary>
        /// hwnd + ID + idChild is hidden item
        /// </summary>
        EventObjectHide = 0x8003,

        /// <summary>
        /// hwnd + ID + idChild is parent of zordering children
        /// </summary>
        EventObjectReorder = 0x8004,

        /// <summary>
        /// hwnd + ID + idChild is focused item
        /// </summary>
        EventObjectFocus = 0x8005,

        /// <summary>
        /// hwnd + ID + idChild is selected item (if only one), or idChild is OBJID_WINDOW if complex
        /// </summary>
        EventObjectSelection = 0x8006,

        /// <summary>
        /// hwnd + ID + idChild is item added
        /// </summary>
        EventObjectSelectionadd = 0x8007,

        /// <summary>
        /// hwnd + ID + idChild is item removed
        /// </summary>
        EventObjectSelectionremove = 0x8008,

        /// <summary>
        /// hwnd + ID + idChild is parent of changed selected items
        /// </summary>
        EventObjectSelectionwithin = 0x8009,

        /// <summary>
        /// hwnd + ID + idChild is item w/ state change
        /// </summary>
        EventObjectStatechange = 0x800A,

        /// <summary>
        /// hwnd + ID + idChild is moved/sized item
        /// </summary>
        EventObjectLocationchange = 0x800B,

        /// <summary>
        /// hwnd + ID + idChild is item w/ name change
        /// </summary>
        EventObjectNamechange = 0x800C,

        /// <summary>
        /// hwnd + ID + idChild is item w/ desc change
        /// </summary>
        EventObjectDescriptionchange = 0x800D,

        /// <summary>
        /// hwnd + ID + idChild is item w/ value change
        /// </summary>
        EventObjectValuechange = 0x800E,

        /// <summary>
        /// hwnd + ID + idChild is item w/ new parent
        /// </summary>
        EventObjectParentchange = 0x800F,

        /// <summary>
        /// hwnd + ID + idChild is item w/ help change
        /// </summary>
        EventObjectHelpchange = 0x8010,

        /// <summary>
        /// hwnd + ID + idChild is item w/ def action change
        /// </summary>
        EventObjectDefactionchange = 0x8011,

        /// <summary>
        /// hwnd + ID + idChild is item w/ keybd accel change
        /// </summary>
        EventObjectAcceleratorchange = 0x8012
    }

    public enum CopyPixelOperation
    {
        // Summary:
        //     The bitmap is not mirrored.
        NoMirrorBitmap = -2147483648,
        //
        // Summary:
        //     The destination area is filled by using the color associated with index 0
        //     in the physical palette. (This color is black for the default physical palette.)
        Blackness = 66,
        //
        // Summary:
        //     The source and destination colors are combined using the Boolean OR operator,
        //     and then resultant color is then inverted.
        NotSourceErase = 1114278,
        //
        // Summary:
        //     The inverted source area is copied to the destination.
        NotSourceCopy = 3342344,
        //
        // Summary:
        //     The inverted colors of the destination area are combined with the colors
        //     of the source area using the Boolean AND operator.
        SourceErase = 4457256,
        //
        // Summary:
        //     The destination area is inverted.
        DestinationInvert = 5570569,
        //
        // Summary:
        //     The colors of the brush currently selected in the destination device context
        //     are combined with the colors of the destination are using the Boolean XOR
        //     operator.
        PatInvert = 5898313,
        //
        // Summary:
        //     The colors of the source and destination areas are combined using the Boolean
        //     XOR operator.
        SourceInvert = 6684742,
        //
        // Summary:
        //     The colors of the source and destination areas are combined using the Boolean
        //     AND operator.
        SourceAnd = 8913094,
        //
        // Summary:
        //     The colors of the inverted source area are merged with the colors of the
        //     destination area by using the Boolean OR operator.
        MergePaint = 12255782,
        //
        // Summary:
        //     The colors of the source area are merged with the colors of the selected
        //     brush of the destination device context using the Boolean AND operator.
        MergeCopy = 12583114,
        //
        // Summary:
        //     The source area is copied directly to the destination area.
        SourceCopy = 13369376,
        //
        // Summary:
        //     The colors of the source and destination areas are combined using the Boolean
        //     OR operator.
        SourcePaint = 15597702,
        //
        // Summary:
        //     The brush currently selected in the destination device context is copied
        //     to the destination bitmap.
        PatCopy = 15728673,
        //
        // Summary:
        //     The colors of the brush currently selected in the destination device context
        //     are combined with the colors of the inverted source area using the Boolean
        //     OR operator. The result of this operation is combined with the colors of
        //     the destination area using the Boolean OR operator.
        PatPaint = 16452105,
        //
        // Summary:
        //     The destination area is filled by using the color associated with index 1
        //     in the physical palette. (This color is white for the default physical palette.)
        Whiteness = 16711778,
        //
        // Summary:
        //     Windows that are layered on top of your window are included in the resulting
        //     image. By default, the image contains only your window. Note that this generally
        //     cannot be used for printing device contexts.
        CaptureBlt = 1073741824,
    }

    public enum ObjectType
    {
        /* Object Definitions for EnumObjects() */
        Pen = 1,
        Brush = 2,
        DC = 3,
        MetaDC = 4,
        Pal = 5,
        Font = 6,
        Bitmap = 7,
        Region = 8,
        Metafile = 9,
        Memdc = 10,
        Extpen = 11,
        Enhmetadc = 12,
        Enhmetafile = 13
    }

    public enum DCType
    {
        DRIVERVERSION = 0,
        TECHNOLOGY = 2,
        HORZSIZE = 4,
        VERTSIZE = 6,
        HORZRES = 8,
        VERTRES = 10,
        LOGPIXELSX = 88,
        LOGPIXELSY = 90,
        BITSPIXEL = 12,
        PLANES = 14,
        NUMBRUSHES = 16,
        NUMPENS = 18,
        NUMFONTS = 22,
        NUMCOLORS = 24,
        ASPECTX = 40,
        ASPECTY = 42,
        ASPECTXY = 44,
        CLIPCAPS = 36,
        SIZEPALETTE = 104,
        NUMRESERVED = 106,
        COLORRES = 108,
        PHYSICALWIDTH = 110,
        PHYSICALHEIGHT = 111,
        PHYSICALOFFSETX = 112,
        PHYSICALOFFSETY = 113,
        SCALINGFACTORX = 114,
        SCALINGFACTORY = 115,
        RASTERCAPS = 38,
        CURVECAPS = 28,
        LINECAPS = 30,
        POLYGONALCAPS = 32,
        TEXTCAPS = 34
    }

    public enum PrintFlags
    {
        Default = 0,
        ClientOnly = 1
    }

    public enum AncestorFlags : uint
    {
        Parent = 1,
        Root = 2,
        RootOwner = 3
    }

    [Flags]
    public enum ExecuteFlags : uint
    {
        ExecuteDefault = 0x00000000,
        ExecuteInTimerThread = 0x00000020,
        ExecuteinioThread = 0x00000001,
        ExecuteInpersistentThread = 0x00000080,
        ExecuteLongFunction = 0x00000010,
        ExecuteOnlyOnce = 0x00000008,
        TransferImpersonation = 0x00000100
    }

    [Flags]
    public enum FileAccess : uint
    {
        //
        // Standart Section
        //

        AccessSystemSecurity = 0x1000000,   // AccessSystemAcl access type
        MaximumAllowed = 0x2000000,     // MaximumAllowed access type

        Delete = 0x10000,
        ReadControl = 0x20000,
        WriteDac = 0x40000,
        WriteOwner = 0x80000,
        Synchronize = 0x100000,

        StandardRightsRequired = 0xF0000,
        StandardRightsRead = ReadControl,
        StandardRightsWrite = ReadControl,
        StandardRightsExecute = ReadControl,
        StandardRightsAll = 0x1F0000,

        FileReadData = 0x0001,        // file & pipe
        FileListDirectory = 0x0001,       // directory
        FileWriteData = 0x0002,       // file & pipe
        FileAddFile = 0x0002,         // directory
        FileAppendData = 0x0004,      // file
        FileAddSubdirectory = 0x0004,     // directory
        FileCreatePipeInstance = 0x0004, // named pipe
        FileReadEa = 0x0008,          // file & directory
        FileWriteEa = 0x0010,         // file & directory
        FileExecute = 0x0020,          // file
        FileTraverse = 0x0020,         // directory
        FileDeleteChild = 0x0040,     // directory
        FileReadAttributes = 0x0080,      // all
        FileWriteAttributes = 0x0100,     // all

        //
        // Generic Section
        //

        GenericRead = 0x80000000,
        GenericWrite = 0x40000000,
        GenericExecute = 0x20000000,
        GenericAll = 0x10000000,
        SpecificRightsAll = 0xffff,

        FileAllAccess =
            StandardRightsRequired |
            Synchronize |
            0x1FF,

        FileGenericRead =
            StandardRightsRead |
            FileReadData |
            FileReadAttributes |
            FileReadEa |
            Synchronize,

        FileGenericWrite =
            StandardRightsWrite |
            FileWriteData |
            FileWriteAttributes |
            FileWriteEa |
            FileAppendData |
            Synchronize,

        FileGenericExecute =
            StandardRightsExecute |
              FileReadAttributes |
              FileExecute |
              Synchronize
    }

    [Flags]
    public enum FileAttributes : uint
    {
        ReadOnly = 1,
        Hidden = 2,
        System = 4,
        Directory = 16,
        Archive = 32,
        Device = 64,
        Normal = 128,
        Temporary = 256,
        SparseFile = 512,
        ReparsePoint = 1024,
        Compressed = 2048,
        Offline = 4096,
        NotContentIndexed = 8192,
        Encrypted = 16384,
    }

    [Flags]
    public enum FileShare : uint
    {
        Read = 0x00000001,
        Write = 0x00000002,
        Delete = 0x00000004,
        All = Read | Write | Delete
    }

    [Flags]
    public enum FileMode : uint
    {
        // Summary:
        //     Specifies that the operating system should create a new file. This requires
        //     System.Security.Permissions.FileIOPermissionAccess.Write. If the file already
        //     exists, an System.IO.IOException is thrown.
        CreateNew = 1,
        //
        // Summary:
        //     Specifies that the operating system should create a new file. If the file
        //     already exists, it will be overwritten. This requires System.Security.Permissions.FileIOPermissionAccess.Write.
        //     System.IO.FileMode.Create is equivalent to requesting that if the file does
        //     not exist, use System.IO.FileMode.CreateNew; otherwise, use System.IO.FileMode.Truncate.
        //     If the file already exists but is a hidden file, an System.UnauthorizedAccessException
        //     is thrown.
        Create = 2,
        //
        // Summary:
        //     Specifies that the operating system should open an existing file. The ability
        //     to open the file is dependent on the value specified by System.IO.FileAccess.
        //     A System.IO.FileNotFoundException is thrown if the file does not exist.
        Open = 3,
        //
        // Summary:
        //     Specifies that the operating system should open a file if it exists; otherwise,
        //     a new file should be created. If the file is opened with FileAccess.Read,
        //     System.Security.Permissions.FileIOPermissionAccess.Read is required. If the
        //     file access is FileAccess.Write then System.Security.Permissions.FileIOPermissionAccess.Write
        //     is required. If the file is opened with FileAccess.ReadWrite, both System.Security.Permissions.FileIOPermissionAccess.Read
        //     and System.Security.Permissions.FileIOPermissionAccess.Write are required.
        //     If the file access is FileAccess.Append, then System.Security.Permissions.FileIOPermissionAccess.Append
        //     is required.
        OpenOrCreate = 4,
        //
        // Summary:
        //     Specifies that the operating system should open an existing file. Once opened,
        //     the file should be truncated so that its size is zero bytes. This requires
        //     System.Security.Permissions.FileIOPermissionAccess.Write. Attempts to read
        //     from a file opened with Truncate cause an exception.
        Truncate = 5,
        //
        // Summary:
        //     Opens the file if it exists and seeks to the end of the file, or creates
        //     a new file. FileMode.Append can only be used in conjunction with FileAccess.Write.
        //     Attempting to seek to a position before the end of the file will throw an
        //     System.IO.IOException and any attempt to read fails and throws an System.NotSupportedException.
        Append = 6,
    }

    [Flags]
    public enum FileFlag : uint
    {
        BackupSemantics = 0x02000000,
        DeleteOnClose = 0x04000000,
        NoBuffering = 0x20000000,
        OpenNoRecall = 0x00100000,
        OpenReparsePoint = 0x00200000,
        Overlapped = 0x40000000,
        PosixSemantics = 0x0100000,
        RandomAccess = 0x10000000,
        SequentialScan = 0x08000000,
        WriteThrough = 0x80000000
    }

    public enum FILE_INFO_BY_HANDLE_CLASS
    {
        /// <summary>
        /// Get / Set
        /// </summary>
        FileBasicInfo = 0,

        /// <summary>
        /// Get
        /// </summary>
        FileStandardInfo = 1,

        /// <summary>
        /// Get
        /// </summary>
        FileNameInfo = 2,

        /// <summary>
        /// Set
        /// </summary>
        FileRenameInfo = 3,

        /// <summary>
        /// Set
        /// </summary>
        FileDispositionInfo = 4,

        /// <summary>
        /// Set
        /// </summary>
        FileAllocationInfo = 5,

        /// <summary>
        /// Set
        /// </summary>
        FileEndOfFileInfo = 6,

        /// <summary>
        /// Get
        /// </summary>
        FileStreamInfo = 7,

        /// <summary>
        /// Get
        /// </summary>
        FileCompressionInfo = 8,

        /// <summary>
        /// Get
        /// </summary>
        FileAttributeTagInfo = 9,

        /// <summary>
        /// Get
        /// </summary>
        FileIdBothDirectoryInfo = 10,  // 0xA

        /// <summary>
        /// Get
        /// </summary>
        FileIdBothDirectoryRestartInfo = 11,  // 0xB

        /// <summary>
        /// Set
        /// </summary>
        FileIoPriorityHintInfo = 12,  // 0xC

        /// <summary>
        /// Get
        /// </summary>
        FileRemoteProtocolInfo = 13,  // 0xD

        /// <summary>
        /// Get
        /// </summary>
        FileFullDirectoryInfo = 14,  // 0xE

        /// <summary>
        /// Get
        /// </summary>
        FileFullDirectoryRestartInfo = 15,  // 0xF

        /// <summary>
        /// Get
        /// </summary>
        FileStorageInfo = 16,  // 0x10

        /// <summary>
        /// Get
        /// </summary>
        FileAlignmentInfo = 17,  // 0x11

        /// <summary>
        /// Get
        /// </summary>
        FileIdInfo = 18,  // 0x12
    }

    public enum PRIORITY_HINT
    {
        IoPriorityHintVeryLow = 0,
        IoPriorityHintLow,
        IoPriorityHintNormal,
        MaximumIoPriorityHintType
    }

    [Flags]
    public enum TpCallbackPriority
    {
        High,
        Normal,
        Low,
        Invalid
    }

    [Flags]
    public enum HandleFlag : uint
    {
        Null = 0,
        Inherit = 0x00000001,
        HandleFlagProtectFromClose = 0x00000002
    }

    [Flags]
    public enum WorkingSizeFlags
    {
        MIN_ENABLE = 0x00000001,
        MIN_DISABLE = 0x00000002,
        MAX_ENABLE = 0x00000004,
        MAX_DISABLE = 0x00000008
    }

    public enum CoInit
    {
        /// <summary>
        /// Initializes the thread for apartment-threaded object concurrency.
        /// </summary>
        MultiThreaded = 0x0,

        /// <summary>
        /// Initializes the thread for multi-threaded object concurrency.
        /// </summary>
        ApartmentThreaded = 0x2,

        /// <summary>
        /// Disables DDE for OLE1 support.
        /// </summary>
        DisableOle1Dde = 0x4,

        /// <summary>
        /// Trade memory for speed.
        /// </summary>
        SpeedOverMemory = 0x8
    }

    [Flags]
    public enum NamePipeMode : uint
    {
        PIPE_TYPE_BYTE = 0x00000000,
        PIPE_TYPE_MESSAGE = 0x00000004,

        PIPE_READMODE_BYTE = 0x00000000,
        PIPE_READMODE_MESSAGE = 0x00000002,

        PIPE_WAIT = 0x00000000,
        PIPE_NOWAIT = 0x00000001,

        PIPE_ACCEPT_REMOTE_CLIENTS = 0x00000000,
        PIPE_REJECT_REMOTE_CLIENTS = 0x00000008
    }

    [Flags]
    public enum NamePipeOpenMode : uint
    {
        PIPE_ACCESS_INBOUND = 0x00000001,
        PIPE_ACCESS_OUTBOUND = 0x00000002,
        PIPE_ACCESS_DUPLEX = 0x00000003,

        FILE_FLAG_FIRST_PIPE_INSTANCE = 0x00080000,
        FILE_FLAG_WRITE_THROUGH = 0x80000000,
        FILE_FLAG_OVERLAPPED = 0x40000000,

        WRITE_DAC = 0x00040000,
        WRITE_OWNER = 0x00080000,
        ACCESS_SYSTEM_SECURITY = 0x01000000
    }

    [Flags]
    public enum PipeInfoFlags : uint
    {
        PIPE_CLIENT_END = 0x00000000,
        PIPE_SERVER_END = 0x00000001,

        WAIT = 0x00000000,
        NOWAIT = 0x00000001
    }

    [Flags]
    public enum HandleStateFlags : uint
    {
        BYTE = 0x00000000,
        MESSAGE = 0x00000002
    }

    [Flags]
    public enum CONNDLG_FLAGS : uint
    {
        SidTypeUser = 0x00000001,
        CONNDLG_RO_PATH = 0x00000001,/* Resource path should be read-only    */
        CONNDLG_CONN_POINT = 0x00000002, /* Netware -style movable connection point enabled */
        CONNDLG_USE_MRU = 0x00000004, /* Use MRU combobox  */
        CONNDLG_HIDE_BOX = 0x00000008, /* Hide persistent connect checkbox  */

        /*
         * NOTE:  Set at most ONE of the below flags.  If neither flag is set,
         *        then the persistence is set to whatever the user chose during
         *        a previous connection
         */
        CONNDLG_PERSIST = 0x00000010,/* Force persistent connection */
        CONNDLG_NOT_PERSIST = 0x00000020,/* Force connection NOT persistent */
    }

    [Flags]
    public enum DISC : uint
    {
        DISC_UPDATE_PROFILE = 0x00000001,
        DISC_NO_FORCE = 0x00000040
    }

    [Flags]
    public enum DuplicationOptions : uint
    {
        CLOSE_SOURCE = 0x00000001,
        SAME_ACCESS = 0x00000002,
        SAME_ATTRIBUTES = 0x00000004
    }

    public enum ThreadState
    {
        StateInitialized,
        StateReady,
        StateRunning,
        StateStandby,
        StateTerminated,
        StateWait,
        StateTransition,
        StateUnknown
    }

    public enum POOL_TYPE
    {
        NonPagedPool,
        PagedPool,
        NonPagedPoolMustSucceed,
        DontUseThisType,
        NonPagedPoolCacheAligned,
        PagedPoolCacheAligned,
        NonPagedPoolCacheAlignedMustS,
        MaxPoolType
    }

    public enum KWaitReason
    {
        Executive,
        FreePage,
        PageIn,
        PoolAllocation,
        DelayExecution,
        Suspended,
        UserRequest,
        WrExecutive,
        WrFreePage,
        WrPageIn,
        WrPoolAllocation,
        WrDelayExecution,
        WrSuspended,
        WrUserRequest,
        WrEventPair,
        WrQueue,
        WrLpcReceive,
        WrLpcReply,
        WrVirtualMemory,
        WrPageOut,
        WrRendezvous,
        Spare2,
        Spare3,
        Spare4,
        Spare5,
        Spare6,
        WrKernel,
        MaximumWaitReason
    }

    [Flags]
    public enum FinalPathFlags : uint
    {
        FILE_NAME_NORMALIZED = 0x0,
        FILE_NAME_OPENED = 0x8,

        VOLUME_NAME_DOS = 0x0,
        VOLUME_NAME_GUID = 0x1,
        VOLUME_NAME_NONE = 0x4,
        VOLUME_NAME_NT = 0x2
    }

    public enum ParameterFlags : uint
    {
        /* Get */
        SPIF_DEFAULT = 0x0000,

        /* Set */
        SPIF_UPDATEINIFILE = 0x0001,
        SPIF_SENDCHANGE = SPIF_UPDATEINIFILE,
        SPIF_SENDWININICHANGE = 0x0002,
    }

    public enum UserObjectInformation
    {
        /// <summary>
        /// [Support Set]
        /// USEROBJECTFLAGS structure
        /// </summary>
        UOI_FLAGS = 1,

        /// <summary>
        /// The name of the object, as a string.
        /// </summary>
        UOI_NAME = 2,

        /// <summary>
        /// The type name of the object, as a string.
        /// </summary>
        UOI_TYPE = 3,

        /// <summary>
        /// The SID structure that identifies the user that is currently associated with the specified object.
        /// If no user is associated with the object,
        ///  the value returned in the buffer pointed to by lpnLengthNeeded is zero
        /// </summary>
        UOI_USER_SID = 4,

        /// <summary>
        /// The size of the desktop heap, in KB, as a ULONG value.
        /// The hObj parameter must be a handle to a desktop object,
        /// otherwise, the function fails.
        /// </summary>
        UOI_HEAPSIZE = 5,

        /// <summary>
        /// TRUE if the hObj parameter is a handle to the desktop object that is receiving input from the user. 
        /// FALSE otherwise.
        /// </summary>
        UOI_IO = 6
    }

    public enum SE_OBJECT_TYPE
    {
        SE_UNKNOWN_OBJECT_TYPE = 0,
        SE_FILE_OBJECT,
        SE_SERVICE,
        SE_PRINTER,
        SE_REGISTRY_KEY,
        SE_LMSHARE,
        SE_KERNEL_OBJECT,
        SE_WINDOW_OBJECT,
        SE_DS_OBJECT,
        SE_DS_OBJECT_ALL,
        SE_PROVIDER_DEFINED_OBJECT,
        SE_WMIGUID_OBJECT,
        SE_REGISTRY_WOW64_32KEY
    }

    [Flags]
    public enum AceType : byte
    {
        // ACE
        ACCESS_ALLOWED = (0x0),
        ACCESS_DENIED = (0x1),
        SYSTEM_AUDIT = (0x2),

        // ACE_OBJECT
        ACCESS_ALLOWED_OBJECT = (0x5),
        ACCESS_DENIED_OBJECT = (0x6),
        SYSTEM_AUDIT_OBJECT = (0x7),

        // ACE_CALLBACK
        ACCESS_ALLOWED_CALLBACK = (0x9),
        ACCESS_DENIED_CALLBACK = (0xA),
        SYSTEM_AUDIT_CALLBACK = (0xD),

        // ACE_CALLBACK_OBJECT
        ACCESS_ALLOWED_CALLBACK_OBJECT = (0xB),
        ACCESS_DENIED_CALLBACK_OBJECT = (0xC),
        SYSTEM_AUDIT_CALLBACK_OBJECT = (0xF),

        //ACE_MANDATORY_LABEL
        SYSTEM_MANDATORY_LABEL = (0x11),
    }

    [Flags]
    public enum AceFlags : byte
    {
        //
        //  The following are the inherit flags that go into the AceFlags field
        //  of an Ace header.
        //

        OBJECT_INHERIT_ACE = (0x1),
        CONTAINER_INHERIT_ACE = (0x2),
        NO_PROPAGATE_INHERIT_ACE = (0x4),
        INHERIT_ONLY_ACE = (0x8),
        INHERITED_ACE = (0x10),
        VALID_INHERIT_FLAGS = (0x1F),
        All = 0x1 | 0x2 | 0x4 | 0x8 | 0x10 | 0x1F,


        //  The following are the currently defined ACE flags that go into the
        //  AceFlags field of an ACE header.  Each ACE type has its own set of
        //  AceFlags.
        //
        //  SUCCESSFUL_ACCESS_ACE_FLAG - used only with system audit and alarm ACE
        //  types to indicate that a message is generated for successful accesses.
        //
        //  FAILED_ACCESS_ACE_FLAG - used only with system audit and alarm ACE types
        //  to indicate that a message is generated for failed accesses.
        //

        //
        //  SYSTEM_AUDIT and SYSTEM_ALARM AceFlags
        //
        //  These control the signaling of audit and alarms for success or failure.
        //

        SUCCESSFUL_ACCESS_ACE_FLAG = (0x40),
        FAILED_ACCESS_ACE_FLAG = (0x80)
    }

    [Flags]
    public enum IPAdapterFlags : uint
    {
        IP_ADAPTER_DDNS_ENABLED = 0x0001,
        IP_ADAPTER_REGISTER_ADAPTER_SUFFIX = 0x0002,
        IP_ADAPTER_DHCP_ENABLED = 0x0004,
        IP_ADAPTER_RECEIVE_ONLY = 0x0008,
        IP_ADAPTER_NO_MULTICAST = 0x0010,
        IP_ADAPTER_IPV6_OTHER_STATEFUL_CONFIG = 0x0020,
        IP_ADAPTER_NETBIOS_OVER_TCPIP_ENABLED = 0x0040,
        IP_ADAPTER_IPV4_ENABLED = 0x0080,
        IP_ADAPTER_IPV6_ENABLED = 0x0100,
        IP_ADAPTER_IPV6_MANAGE_ADDRESS_CONFIG = 0x0200
    }

    public enum ACL_INFORMATION_CLASS
    {
        /// <summary>
        /// DWORD AclRevision
        /// </summary>
        AclRevisionInformation = 1,

        /// <summary>
        /// DWORD AceCount;
        /// DWORD AclBytesInUse;
        /// DWORD AclBytesFree;
        /// </summary>
        AclSizeInformation
    }

    [Flags]
    public enum ObjectPresent : uint
    {
        ACE_OBJECT_TYPE_PRESENT = 0x1,
        ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2
    }

    [Flags]
    public enum Action
    {
        TREE_SEC_INFO_SET = 0x00000001,
        TREE_SEC_INFO_RESET = 0x00000002,
        TREE_SEC_INFO_RESET_KEEP_EXPLICIT = 0x00000003
    }

    [Flags]
    public enum PROG_INVOKE_SETTING
    {
        InvokeNever = 1,
        InvokeEveryObject,
        InvokeOnError,
        CancelOperation,
        RetryOperation,
        InvokePrePostError
    }

    [Flags]
    public enum POLICY_AUDIT_EVENT_TYPE
    {
        System,
        Logon,
        ObjectAccess,
        PrivilegeUse,
        DetailedTracking,
        PolicyChange,
        AccountManagement,
        DirectoryServiceAccess,
        AccountLogon
    }

    public enum MIB_IPNET : uint
    {
        OTHER = 1,
        INVALID = 2,
        DYNAMIC = 3,
        STATIC = 4
    }

    [Flags]
    public enum CS : uint
    {
        BYTEALIGNCLIENT = 0x1000,
        BYTEALIGNWINDOW = 0x2000,
        CLASSDC = 0x0040,
        DBLCLKS = 0x0008,
        DROPSHADOW = 0x00020000,
        GLOBALCLASS = 0x4000,
        HREDRAW = 0x0002,
        NOCLOSE = 0x0200,
        OWNDC = 0x0020,
        PARENTDC = 0x0080,
        SAVEBITS = 0x0800,
        VREDRAW = 0x0001,
    }

    public enum SAFER_SCOPEID
    {
        SAFER_SCOPEID_MACHINE = 1,
        SAFER_SCOPEID_USER = 2
    }

    public enum SAFER_LEVELID
    {
        CONSTRAINED = 0x10000,
        DISALLOWED = 0x00000,
        FULLYTRUSTED = 0x40000,
        NORMALUSER = 0x20000,
        UNTRUSTED = 0x01000
    }

    public enum SAFER_LEVEL
    {
        SAFER_LEVEL_OPEN = 1
    }

    public enum SAFER_TOKEN
    {
        NULL = 0,
        NULL_IF_EQUAL = (0x1),
        COMPARE_ONLY = (0x2),
        MAKE_INERT = (0x4),
        WANT_FLAGS = (0x8),
    }

    [Flags]
    public enum SERVICE_NOTIFY
    {
        CREATED = 0x00000080,
        CONTINUE_PENDING = 0x00000010,
        DELETE_PENDING = 0x00000200,
        DELETED = 0x00000100,
        PAUSE_PENDING = 0x00000020,
        PAUSED = 0x00000040,
        RUNNING = 0x00000008,
        START_PENDING = 0x00000002,
        STOP_PENDING = 0x00000004,
        STOPPED = 0x00000001
    }

    [Flags]
    public enum DWM_BB
    {
        fEnable = 0x00000001,
        hRgnBlur = 0x00000002,
        fTransitionOnMaximized = 0x00000004,
    }

    [Flags]
    public enum DWM_TNP
    {
        rcDestination = 0x00000001,
        rcSource = 0x00000002,
        opacity = 0x00000004,
        fVisible = 0x00000008,
        fSourceClientAreaOnly = 0x00000010
    }

    [Flags]
    public enum ULW
    {
        Colour = 0x00000001,
        Opicity = 0x00000002,
        Draw = 0x00000004
    }

    public enum DWMWINDOWATTRIBUTE
    {
        NCRENDERING_ENABLED = 1,
        NCRENDERING_POLICY,
        TRANSITIONS_FORCEDISABLED,
        ALLOW_NCPAINT,
        CAPTION_BUTTON_BOUNDS,
        NONCLIENT_RTL_LAYOUT,
        FORCE_ICONIC_REPRESENTATION,
        FLIP3D_POLICY,
        EXTENDED_FRAME_BOUNDS,
        HAS_ICONIC_BITMAP,
        DISALLOW_PEEK,
        EXCLUDED_FROM_PEEK,
        CLOAK,
        CLOAKED,
        FREEZE_REPRESENTATION,
        LAST
    }

    [Flags]
    public enum FILE_NOTIFY_CHANGE
    {
        FILE_NAME = 0x00000001,
        DIR_NAME = 0x00000002,
        ATTRIBUTES = 0x00000004,
        CHANGE_SIZE = 0x00000008,
        CHANGE_LAST_WRITE = 0x00000010,
        CHANGE_LAST_ACCESS = 0x00000020,
        CHANGE_CREATION = 0x00000040,
        CHANGE_SECURITY = 0x00000100,
        All = 0x00000001 | 0x00000002 | 0x00000004 | 0x00000008 | 0x00000010 | 0x00000020 | 0x00000040 | 0x00000100
    }

    public enum DOT11_BSS_TYPE
    {
        infrastructure = 1,
        independent = 2,
        any = 3 
    }

    public enum DOT11_PHY_TYPE : uint
    {
        unknown = 0,
        any = 0,
        fhss = 1,
        dsss = 2,
        irbaseband = 3,
        ofdm = 4,
        hrdsss = 5,
        erp = 6,
        ht = 7,
        IHV_start = 0x80000000,
        IHV_end = 0xffffffff 
    }

    public enum WLAN_INTERFACE_TYPE
    {
        emulated_802_11 = 0,
        native_802_11,
        invalid 
    }

    public enum DOT11_CIPHER_ALGORITHM : uint
    {
        NONE = 0x00,
        WEP40 = 0x01,
        TKIP = 0x02,
        CCMP = 0x04,
        WEP104 = 0x05,
        WPA_USE_GROUP = 0x100,
        RSN_USE_GROUP = 0x100,
        WEP = 0x101,
        IHV_START = 0x80000000,
        IHV_END = 0xffffffff
    }

    public enum DOT11_AUTH_ALGORITHM : uint
    {
        DAA_80211_OPEN = 1,
        DAA_80211_SHARED_KEY = 2,
        DAA_WPA = 3,
        DAA_WPA_PSK = 4,
        DAA_WPA_NONE = 5,
        DAA_RSNA = 6,
        DAA_RSNA_PSK = 7,
        DAA_IHV_START = 0x80000000,
        DAA_IHV_END = 0xffffffff
    }

    public enum WLAN_CONNECTION_MODE : uint
    {
        profile,
        temporary_profile,
        discovery_secure,
        discovery_unsecure,
        auto,
        invalid 
    }

    public enum WLAN_CONNECTION
    {
        // XP mode
        IDK = 0x00000000,

        // Vista Mode
        HIDDEN_NETWORK = 0x00000001,
        ADHOC_JOIN_ONLY = 0x00000002,
        IGNORE_PRIVACY_BIT = 0x00000004,
        EAPOL_PASSTHROUGH = 0x00000008,
    }

    public enum IO_PRIORITY_HINT
    {
        IoPriorityVeryLow = 0,
        IoPriorityLow = 1,
        IoPriorityNormal = 2,
        IoPriorityHigh = 3,
        IoPriorityCritical = 4,
        MaxIoPriorityTypes = 5 
    }

    public enum WLAN_INTF_OPCODE
    {
        wlan_intf_opcode_autoconf_start = 0x000000000,
        wlan_intf_opcode_autoconf_enabled,
        wlan_intf_opcode_background_scan_enabled,
        wlan_intf_opcode_media_streaming_mode,
        wlan_intf_opcode_radio_state,
        wlan_intf_opcode_bss_type,
        wlan_intf_opcode_interface_state,
        wlan_intf_opcode_current_connection,
        wlan_intf_opcode_channel_number,
        wlan_intf_opcode_supported_infrastructure_auth_cipher_pairs,
        wlan_intf_opcode_supported_adhoc_auth_cipher_pairs,
        wlan_intf_opcode_supported_country_or_region_string_list,
        wlan_intf_opcode_current_operation_mode,
        wlan_intf_opcode_supported_safe_mode,
        wlan_intf_opcode_certified_safe_mode,
        wlan_intf_opcode_hosted_network_capable,
        wlan_intf_opcode_management_frame_protection_capable,
        wlan_intf_opcode_autoconf_end = 0x0fffffff,
        wlan_intf_opcode_msm_start = 0x10000100,
        wlan_intf_opcode_statistics,
        wlan_intf_opcode_rssi,
        wlan_intf_opcode_msm_end = 0x1fffffff,
        wlan_intf_opcode_security_start = 0x20010000,
        wlan_intf_opcode_security_end = 0x2fffffff,
        wlan_intf_opcode_ihv_start = 0x30000000,
        wlan_intf_opcode_ihv_end = 0x3fffffff 
    }

    public enum WLAN_OPCODE_VALUE_TYPE
    {
        wlan_opcode_value_type_query_only = 0,
        wlan_opcode_value_type_set_by_group_policy = 1,
        wlan_opcode_value_type_set_by_user = 2,
        wlan_opcode_value_type_invalid = 3 
    }

    [Flags]
    public enum WLAN_NOTIFICATION_SOURCE : uint
    {
        None = 0,
        /// <summary>
        /// All notifications, including those generated by the 802.1X module.
        /// </summary>
        All = 0X0000FFFF,
        /// <summary>
        /// Notifications generated by the auto configuration module.
        /// </summary>
        ACM = 0X00000008,
        /// <summary>
        /// Notifications generated by MSM.
        /// </summary>
        MSM = 0X00000010,
        /// <summary>
        /// Notifications generated by the security module.
        /// </summary>
        Security = 0X00000020,
        /// <summary>
        /// Notifications generated by independent hardware vendors (IHV).
        /// </summary>
        IHV = 0X00000040,
        /// <summary>
        /// Registers for notifications generated by 802.1X.
        /// </summary>
        ONEX = 0X00000004,
        /// <summary>
        /// notifications generated by the wireless Hosted Network
        /// </summary>
        HNWK = 0X00000080
    }

    public enum CRYPT_STRING : uint
    {
        BASE64HEADER = 0,
        BASE64 = 1,
        BINARY = 2,
        BASE64REQUESTHEADER = 3,
        HEX = 4,
        HEXASCII = 5,
        BASE64_ANY = 6,
        ANY = 7,
        HEX_ANY = 8,
        BASE64X509CRLHEADER = 9,
        HEXADDR = 10,
        HEXASCIIADDR = 11,
        HEXRAW = 12,
        NOCRLF = 0x40000000,
        NOCR = 0x80000000
    }

    public enum DEVICE_NOTIFY
    {
        WINDOW_HANDLE = 0x00000000,
        SERVICE_HANDLE = 0x00000001,
        ALL_INTERFACE_CLASSES = 0x00000004
    }

    public enum DBT_DEVTYP
    {
        OEM = 0x00000000,
        PORT = 0x00000003,
        VOLUME = 0x00000002,
        DEVICEINTERFACE = 0x00000005,
        HANDLE = 0x00000006
    }

    public enum WLAN_NOTIFICATION_ACM
    {
        start = 0,
        autoconf_enabled,
        autoconf_disabled,
        background_scan_enabled,
        background_scan_disabled,

        /// <summary>
        /// DOT11_BSS_TYPE
        /// </summary>
        bss_type_change,

        /// <summary>
        /// WLAN_POWER_SETTING
        /// </summary>
        power_setting_change,

        scan_complete,

        /// <summary>
        /// WLAN_REASON_CODE 
        /// </summary>
        scan_fail,

        /// <summary>
        /// WLAN_CONNECTION_NOTIFICATION_DATA 
        /// </summary>
        connection_start,

        /// <summary>
        /// WLAN_CONNECTION_NOTIFICATION_DATA
        /// </summary>
        connection_complete,

        /// <summary>
        /// WLAN_CONNECTION_NOTIFICATION_DATA
        /// </summary>
        connection_attempt_fail,

        filter_list_change,
        interface_arrival,
        interface_removal,
        profile_change,

        /// <summary>
        /// Two WCHAR strings, 
        /// the old profile name followed by the new profile name.
        /// </summary>
        profile_name_change,

        profiles_exhausted,
        network_not_available,
        network_available,

        /// <summary>
        /// WLAN_CONNECTION_NOTIFICATION_DATA
        /// </summary>
        disconnecting,

        /// <summary>
        /// WLAN_CONNECTION_NOTIFICATION_DATA
        /// </summary>
        disconnected,

        /// <summary>
        /// WLAN_ADHOC_NETWORK_STATE
        /// </summary>
        adhoc_network_state_change,

        profile_unblocked,
        screen_power_change,
        end 
    }

    public enum WLAN_NOTIFICATION_MSM
    {
        start = 0,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        associating,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        associated,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        authenticating,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        connected,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA
        /// </summary>
        roaming_start,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA
        /// </summary>
        roaming_end,

        /// <summary>
        /// WLAN_PHY_RADIO_STATE
        /// </summary>
        radio_state_change,

        /// <summary>
        /// WLAN_SIGNAL_QUALITY (ULONG)
        /// </summary>
        signal_quality_change,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        disassociating,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        disconnected,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        peer_join,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA 
        /// </summary>
        peer_leave,

        /// <summary>
        /// WLAN_MSM_NOTIFICATION_DATA
        /// </summary>
        adapter_removal,

        /// <summary>
        /// ULONG
        /// </summary>
        adapter_operation_mode_change,
        end 
    }

    public enum WLAN_HOSTED_NETWORK_NOTIFICATION
    {
        /// <summary>
        /// WLAN_HOSTED_NETWORK_STATE_CHANGE
        /// </summary>
        state_change = 0x00001000,

        /// <summary>
        /// WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE 
        /// </summary>
        peer_state_change,

        /// <summary>
        /// WLAN_HOSTED_NETWORK_RADIO_STATE
        /// </summary>
        radio_state_change
    }

    public enum ONEX_NOTIFICATION_TYPE
    {
        OneXPublicNotificationBase = 0,
        
        /// <summary>
        /// ONEX_RESULT_UPDATE_DATA
        /// </summary>
        ResultUpdate,

        /// <summary>
        /// ONEX_AUTH_RESTART_REASON
        /// </summary>
        AuthRestarted,

        EventInvalid,
        OneXNumNotifications = EventInvalid 
    }

    public enum ONEX_AUTH_RESTART_REASON
    {
        OneXRestartReasonPeerInitiated,
        OneXRestartReasonMsmInitiated,
        OneXRestartReasonOneXHeldStateTimeout,
        OneXRestartReasonOneXAuthTimeout,
        OneXRestartReasonOneXConfigurationChanged,
        OneXRestartReasonOneXUserChanged,
        OneXRestartReasonQuarantineStateChanged,
        OneXRestartReasonAltCredsTrial,
        OneXRestartReasonInvalid
    }

    public enum WLAN_POWER_SETTING
    {
        no_saving,
        low_saving,
        medium_saving,
        maximum_saving,
        invalid 
    }

    public enum DOT11_RADIO_STATE
    {
        unknown,
        on,
        off 
    }

    public enum WLAN_ADHOC_NETWORK_STATE
    {
        formed = 0,
        connected = 1 
    }

    public enum WL_DISPLAY_PAGES
    {
        WLConnectionPage,
        WLSecurityPage
    }

    [Flags]
    public enum DiGetClassFlags : uint
    {
        DEFAULT = 0x00000001,  // only valid with DEVICEINTERFACE
        PRESENT = 0x00000002,
        ALLCLASSES = 0x00000004,
        PROFILE = 0x00000008,
        DEVICEINTERFACE = 0x00000010,
    }

    public enum SPDRP : uint
    {
        DEVICEDESC = 0x00000000, // DeviceDesc (R/W)
        HARDWAREID = 0x00000001, // HardwareID (R/W)
        COMPATIBLEIDS = 0x00000002, // CompatibleIDs (R/W)
        UNUSED0 = 0x00000003, // unused
        SERVICE = 0x00000004, // Service (R/W)
        UNUSED1 = 0x00000005, // unused
        UNUSED2 = 0x00000006, // unused
        CLASS = 0x00000007, // Class (R--tied to ClassGUID)
        CLASSGUID = 0x00000008, // ClassGUID (R/W)
        DRIVER = 0x00000009, // Driver (R/W)
        CONFIGFLAGS = 0x0000000A, // ConfigFlags (R/W)
        MFG = 0x0000000B, // Mfg (R/W)
        FRIENDLYNAME = 0x0000000C, // FriendlyName (R/W)
        LOCATION_INFORMATION = 0x0000000D, // LocationInformation (R/W)
        PHYSICAL_DEVICE_OBJECT_NAME = 0x0000000E, // PhysicalDeviceObjectName (R)
        CAPABILITIES = 0x0000000F, // Capabilities (R)
        UI_NUMBER = 0x00000010, // UiNumber (R)
        UPPERFILTERS = 0x00000011, // UpperFilters (R/W)
        LOWERFILTERS = 0x00000012, // LowerFilters (R/W)
        BUSTYPEGUID = 0x00000013, // BusTypeGUID (R)
        LEGACYBUSTYPE = 0x00000014, // LegacyBusType (R)
        BUSNUMBER = 0x00000015, // BusNumber (R)
        ENUMERATOR_NAME = 0x00000016, // Enumerator Name (R)
        SECURITY = 0x00000017, // Security (R/W, binary form)
        SECURITY_SDS = 0x00000018, // Security (W, SDS form)
        DEVTYPE = 0x00000019, // Device Type (R/W)
        EXCLUSIVE = 0x0000001A, // Device is exclusive-access (R/W)
        CHARACTERISTICS = 0x0000001B, // Device Characteristics (R/W)
        ADDRESS = 0x0000001C, // Device Address (R)
        UI_NUMBER_DESC_FORMAT = 0X0000001D, // UiNumberDescFormat (R/W)
        DEVICE_POWER_DATA = 0x0000001E, // Device Power Data (R)
        REMOVAL_POLICY = 0x0000001F, // Removal Policy (R)
        REMOVAL_POLICY_HW_DEFAULT = 0x00000020, // Hardware Removal Policy (R)
        REMOVAL_POLICY_OVERRIDE = 0x00000021, // Removal Policy Override (RW)
        INSTALL_STATE = 0x00000022, // Device Install State (R)
        LOCATION_PATHS = 0x00000023, // Device Location Paths (R)
        BASE_CONTAINERID = 0x00000024  // Base ContainerID (R)
    }

    public enum DIF : uint
    {
        SELECTDEVICE = 0x00000001,
        INSTALLDEVICE = 0x00000002,
        ASSIGNRESOURCES = 0x00000003,
        PROPERTIES = 0x00000004,
        REMOVE = 0x00000005,
        FIRSTTIMESETUP = 0x00000006,
        FOUNDDEVICE = 0x00000007,
        SELECTCLASSDRIVERS = 0x00000008,
        VALIDATECLASSDRIVERS = 0x00000009,
        INSTALLCLASSDRIVERS = 0x0000000A,
        CALCDISKSPACE = 0x0000000B,
        DESTROYPRIVATEDATA = 0x0000000C,
        VALIDATEDRIVER = 0x0000000D,
        DETECT = 0x0000000F,
        INSTALLWIZARD = 0x00000010,
        DESTROYWIZARDDATA = 0x00000011,
        PROPERTYCHANGE = 0x00000012,
        ENABLECLASS = 0x00000013,
        DETECTVERIFY = 0x00000014,
        INSTALLDEVICEFILES = 0x00000015,
        UNREMOVE = 0x00000016,
        SELECTBESTCOMPATDRV = 0x00000017,
        ALLOW_INSTALL = 0x00000018,
        REGISTERDEVICE = 0x00000019,
        NEWDEVICEWIZARD_PRESELECT = 0x0000001A,
        NEWDEVICEWIZARD_SELECT = 0x0000001B,
        NEWDEVICEWIZARD_PREANALYZE = 0x0000001C,
        NEWDEVICEWIZARD_POSTANALYZE = 0x0000001D,
        NEWDEVICEWIZARD_FINISHINSTALL = 0x0000001E,
        UNUSED1 = 0x0000001F,
        INSTALLINTERFACES = 0x00000020,
        DETECTCANCEL = 0x00000021,
        REGISTER_COINSTALLERS = 0x00000022,
        ADDPROPERTYPAGE_ADVANCED = 0x00000023,
        ADDPROPERTYPAGE_BASIC = 0x00000024,
        RESERVED1 = 0x00000025,
        TROUBLESHOOTER = 0x00000026,
        POWERMESSAGEWAKE = 0x00000027,
        ADDREMOTEPROPERTYPAGE_ADVANCED = 0x00000028,
        UPDATEDRIVER_UI = 0x00000029,
        FINISHINSTALL_ACTION = 0x0000002A,
        RESERVED2 = 0x00000030,
    }

    public enum DICS : uint
    {
        ENABLE = 0x00000001,
        DISABLE = 0x00000002,
        PROPCHANGE = 0x00000003,
        START = 0x00000004,
        STOP = 0x00000005
    }

    public enum DICS_FLAG : uint
    {
        /// <summary>
        /// make change in all hardware profiles
        /// </summary>
        GLOBAL = 0x00000001,

        /// <summary>
        /// make change in specified profile only
        /// </summary>
        CONFIGSPECIFIC = 0x00000002,

        /// <summary>
        /// 1 or more hardware profile-specific
        /// changes to follow.
        /// </summary>
        CONFIGGENERAL = 0x00000004
    }

    [Flags]
    public enum DI : uint
    {
        //
        // SP_DEVINSTALL_PARAMS.Flags values
        //
        // Flags for choosing a device
        //
        SHOWOEM = 0x00000001,     // support Other... button
        SHOWCOMPAT = 0x00000002,     // show compatibility list
        SHOWCLASS = 0x00000004,     // show class list
        SHOWALL = 0x00000007,     // both class & compat list shown
        NOVCP = 0x00000008,     // don't create a new copy queue--use
        // caller-supplied FileQueue
        DIDCOMPAT = 0x00000010,     // Searched for compatible devices
        DIDCLASS = 0x00000020,     // Searched for class devices
        AUTOASSIGNRES = 0x00000040,     // No UI for resources if possible

        // flags returned by DiInstallDevice to indicate need to reboot/restart
        NEEDRESTART = 0x00000080,     // Reboot required to take effect
        NEEDREBOOT = 0x00000100,     // ""

        // flags for device installation
        NOBROWSE = 0x00000200,     // no Browse... in InsertDisk

        // Flags set by DiBuildDriverInfoList
        MULTMFGS = 0x00000400,    // Set if multiple manufacturers in
        // class driver list

        // Flag indicates that device is disabled
        DISABLED = 0x00000800,    // Set if device disabled

        // Flags for Device/Class Properties
        GENERALPAGE_ADDED = 0x00001000,
        RESOURCEPAGE_ADDED = 0x00002000,

        // Flag to indicate the setting properties for this Device (or class) caused a change
        // so the Dev Mgr UI probably needs to be updatd.
        PROPERTIES_CHANGE = 0x00004000,

        // Flag to indicate that the sorting from the INF file should be used.
        INF_IS_SORTED = 0x00008000,

        // Flag to indicate that only the the INF specified by SP_DEVINSTALL_PARAMS.DriverPath
        // should be searched.
        ENUMSINGLEINF = 0x00010000,

        // Flag that prevents ConfigMgr from removing/re-enumerating devices during device
        // registration, installation, and deletion.
        DONOTCALLCONFIGMG = 0x00020000,

        // The following flag can be used to install a device disabled
        INSTALLDISABLED = 0x00040000,

        // Flag that causes SetupDiBuildDriverInfoList to build a device's compatible driver
        // list from its existing class driver list, instead of the normal INF search.
        COMPAT_FROM_CLASS = 0x00080000,

        // This flag is set if the Class Install params should be used.
        CLASSINSTALLPARAMS = 0x00100000,

        // This flag is set if the caller of DiCallClassInstaller does NOT
        // want the internal default action performed if the Class installer
        // returns ERROR_DI_DO_DEFAULT.
        NODI_DEFAULTACTION = 0x00200000,

        // The setupx flag, DI_NOSYNCPROCESSING (0x00400000L) is not support in the Setup APIs.

        // flags for device installation
        QUIETINSTALL = 0x00800000,    // don't confuse the user with
        // questions or excess info
        NOFILECOPY = 0x01000000,    // No file Copy necessary
        FORCECOPY = 0x02000000,    // Force files to be copied from install path
        DRIVERPAGE_ADDED = 0x04000000,    // Prop provider added Driver page.
        USECI_SELECTSTRINGS = 0x08000000,    // Use Class Installer Provided strings in the Select Device Dlg
        OVERRIDE_INFFLAGS = 0x10000000,    // Override INF flags
        PROPS_NOCHANGEUSAGE = 0x20000000,   // No Enable/Disable in General Props

        NOSELECTICONS = 0x40000000,    // No small icons in select device dialogs

        NOWRITE_IDS = 0x80000000    // Don't write HW & Compat IDs on install
    }

    [Flags]
    public enum DI_FLAGSEX : uint
    {
        CI_FAILED = 0x00000004,  // Failed to Load/Call class installer
        FINISHINSTALL_ACTION = 0x00000008,  // Class/co-installer wants to get a DIF_FINISH_INSTALL action in client context.

        DIDINFOLIST = 0x00000010,  // Did the Class Info List
        DIDCOMPATINFO = 0x00000020,  // Did the Compat Info List

        FILTERCLASSES = 0x00000040,
        SETFAILEDINSTALL = 0x00000080,
        DEVICECHANGE = 0x00000100,
        ALWAYSWRITEIDS = 0x00000200,
        PROPCHANGE_PENDING = 0x00000400,  // One or more device property sheets have had changes made
        // to them, and need to have a DIF_PROPERTYCHANGE occur.
        ALLOWEXCLUDEDDRVS = 0x00000800,
        NOUIONQUERYREMOVE = 0x00001000,
        USECLASSFORCOMPAT = 0x00002000,  // Use the device's class when building compat drv list.
        // (Ignored if DI_COMPAT_FROM_CLASS flag is specified.)

        NO_DRVREG_MODIFY = 0x00008000,  // Don't run AddReg and DelReg for device's software (driver) key.
        IN_SYSTEM_SETUP = 0x00010000,  // Installation is occurring during initial system setup.
        INET_DRIVER = 0x00020000,  // Driver came from Windows Update
        APPENDDRIVERLIST = 0x00040000,  // Cause SetupDiBuildDriverInfoList to append
        // a new driver list to an existing list.
        PREINSTALLBACKUP = 0x00080000,  // not used
        BACKUPONREPLACE = 0x00100000,  // not used
        DRIVERLIST_FROM_URL = 0x00200000,  // build driver list from INF(s) retrieved from URL specified
        // in SP_DEVINSTALL_PARAMS.DriverPath (empty string means
        // Windows Update website)
        RESERVED1 = 0x00400000,
        EXCLUDE_OLD_INET_DRIVERS = 0x00800000,  // Don't include old Internet drivers when building
        // a driver list.
        // Ignored on Windows Vista and later.
        POWERPAGE_ADDED = 0x01000000,  // class installer added their own power page

        FILTERSIMILARDRIVERS = 0x02000000,  // only include similar drivers in class list
        INSTALLEDDRIVER = 0x04000000,  // only add the installed driver to the class or compat
        // driver list.  Used in calls to SetupDiBuildDriverInfoList
        NO_CLASSLIST_NODE_MERGE = 0x08000000,  // Don't remove identical driver nodes from the class list
        ALTPLATFORM_DRVSEARCH = 0x10000000,  // Build driver list based on alternate platform information
        // specified in associated file queue
        RESTART_DEVICE_ONLY = 0x20000000,  // only restart the device drivers are being installed on as
        // opposed to restarting all devices using those drivers.

        RECURSIVESEARCH = 0x40000000,  // Tell SetupDiBuildDriverInfoList to do a recursive search
        SEARCH_PUBLISHED_INFS = 0x80000000  // Tell SetupDiBuildDriverInfoList to do a "published INF" search
    }

    public enum ResType
    {
        All = (0x00000000),   // Return all resource types
        None = (0x00000000),  // Arbitration always succeeded
        Mem = (0x00000001), // Physical address resource
        IO = (0x00000002),   // Physical I/O address resource
        DMA = (0x00000003),  // DMA channels resource
        IRQ = (0x00000004),   // IRQ resource
        DoNotUse = (0x00000005),   // Used as spacer to sync subsequent ResTypes w/NT
        BusNumber = (0x00000006),   // bus number resource
        MemLarge = (0x00000007),   // Memory resources >= 4GB
        MAX = (0x00000007),   // Maximum known (arbitrated) ResType

        Ignored_Bit = (0x00008000),   // Ignore this resource
        ClassSpecific = (0x0000FFFF),   // class-specific resource
        Reserved = (0x00008000),   // reserved for internal use
        DevicePrivate = (0x00008001),   // device private data
        PcCardConfig = (0x00008002),   // PC Card configuration data
        MfCardConfig = (0x00008003)   // MF Card configuration data
    }
}