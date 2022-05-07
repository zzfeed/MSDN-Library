
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
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

namespace MSDN.Struct
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct system_Information
    {
        public static void FreeHandle(system_Information* cHandle)
        {
            msvcrt.free((IntPtr)cHandle);
        }
        public static system_Information* CreateHandle(uint cSize)
        {
            return (system_Information*)msvcrt.malloc(cSize);
        }
        public static system_Information* CreateHandle(System_Information_Class cClass, out uint cSize)
        {
            cSize = 0;
            switch (cClass)
            {
                case System_Information_Class.SystemBasicInformation:
                    cSize = (uint)sizeof(SYSTEM_BASIC_INFORMATION);
                    break;
                case System_Information_Class.SystemProcessorInformation:
                    cSize = (uint)sizeof(SYSTEM_PROCESSOR_INFORMATION);
                    break;
                case System_Information_Class.SystemPerformanceInformation:
                    cSize = (uint)sizeof(SYSTEM_PERFORMANCE_INFORMATION);
                    break;
                case System_Information_Class.SystemTimeOfDayInformation:
                    cSize = (uint)sizeof(SYSTEM_TIME_OF_DAY_INFORMATION);
                    break;
                case System_Information_Class.SystemPathInformation:
                    //throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemProcessInformation:
                    cSize = (uint)sizeof(SYSTEM_PROCESS_INFORMATION);
                    break;
                case System_Information_Class.SystemCallCounts:
                    cSize = (uint)sizeof(SYSTEM_CALL_COUNT_INFORMATION);
                    break;
                case System_Information_Class.SystemConfigurationInformation:
                    cSize = (uint)sizeof(SYSTEM_CONFIGURATION_INFORMATION);
                    break;
                case System_Information_Class.SystemProcessorTimes:
                    cSize = (uint)sizeof(SYSTEM_CONFIGURATION_INFORMATION);
                    break;
                case System_Information_Class.SystemGlobalFlag:
                    cSize = (uint)sizeof(SYSTEM_CONFIGURATION_INFORMATION);
                    break;
                case System_Information_Class.SystemNotImplemented2:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemModuleInformation:
                    cSize = (uint)sizeof(SYSTEM_MODULE_INFORMATION);
                    break;
                case System_Information_Class.SystemLockInformation:
                    cSize = (uint)sizeof(SYSTEM_LOCK_INFORMATION);
                    break;
                case System_Information_Class.SystemNotImplemented3:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemNotImplemented4:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemNotImplemented5:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemHandleInformation:
                    cSize = (uint)sizeof(SYSTEM_HANDLE_INFORMATION);
                    break;
                case System_Information_Class.SystemObjectInformation:
                    cSize = (uint)sizeof(SYSTEM_OBJECT_INFORMATION);
                    break;
                case System_Information_Class.SystemPagefileInformation:
                    cSize = (uint)sizeof(SYSTEM_PAGEFILE_INFORMATION);
                    break;
                case System_Information_Class.SystemInstructionEmulationCounts:
                    cSize = (uint)sizeof(SYSTEM_INSTRUCTION_EMULATION_INFORMATION);
                    break;
                case System_Information_Class.SystemInvalidInfoClass1:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemCacheInformation:
                    cSize = (uint)sizeof(SYSTEM_CACHE_INFORMATION);
                    break;
                case System_Information_Class.SystemPoolTagInformation:
                    cSize = (uint)sizeof(SYSTEM_POOL_TAG_INFORMATION);
                    break;
                case System_Information_Class.SystemProcessorStatistics:
                    cSize = (uint)sizeof(SYSTEM_PROCESSOR_STATISTICS);
                    break;
                case System_Information_Class.SystemDpcInformation:
                    cSize = (uint)sizeof(SYSTEM_DPC_INFORMATION);
                    break;
                case System_Information_Class.SystemNotImplemented6:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemLoadImage:
                    cSize = (uint)sizeof(SYSTEM_LOAD_IMAGE);
                    break;
                case System_Information_Class.SystemUnloadImage:
                    cSize = (uint)sizeof(SYSTEM_UNLOAD_IMAGE);
                    break;
                case System_Information_Class.SystemTimeAdjustment:
                    cSize = (uint)sizeof(SYSTEM_TIME_ADJUSTMENT);
                    break;
                case System_Information_Class.SystemNotImplemented7:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemNotImplemented8:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemNotImplemented9:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemCrashDumpInformation:
                    cSize = (uint)sizeof(SYSTEM_CRASH_DUMP_INFORMATION);
                    break;
                case System_Information_Class.SystemExceptionInformation:
                    cSize = (uint)sizeof(SYSTEM_EXCEPTION_INFORMATION);
                    break;
                case System_Information_Class.SystemCrashDumpStateInformation:
                    cSize = (uint)sizeof(SYSTEM_CRASH_DUMP_STATE_INFORMATION);
                    break;
                case System_Information_Class.SystemKernelDebuggerInformation:
                    cSize = (uint)sizeof(SYSTEM_KERNEL_DEBUGGER_INFORMATION);
                    break;
                case System_Information_Class.SystemContextSwitchInformation:
                    cSize = (uint)sizeof(SYSTEM_CONTEXT_SWITCH_INFORMATION);
                    break;
                case System_Information_Class.SystemRegistryQuotaInformation:
                    cSize = (uint)sizeof(SYSTEM_REGISTRY_QUOTA_INFORMATION);
                    break;
                case System_Information_Class.SystemLoadAndCallImage:
                    cSize = (uint)sizeof(SYSTEM_LOAD_AND_CALL_IMAGE);
                    break;
                case System_Information_Class.SystemPrioritySeparation:
                    cSize = (uint)sizeof(SYSTEM_PRIORITY_SEPARATION);
                    break;
                case System_Information_Class.SystemNotImplemented10:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemNotImplemented11:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemInvalidInfoClass2:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemInvalidInfoClass3:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemTimeZoneInformation:
                    cSize = (uint)sizeof(TIME_ZONE_INFORMATION);
                    break;
                case System_Information_Class.SystemLookasideInformation:
                    cSize = (uint)sizeof(SYSTEM_LOOKASIDE_INFORMATION);
                    break;
                case System_Information_Class.SystemSetTimeSlipEvent:
                    cSize = (uint)sizeof(SYSTEM_SET_TIME_SLIP_EVENT);
                    break;
                case System_Information_Class.SystemCreateSession:
                    cSize = (uint)sizeof(SYSTEM_CREATE_SESSION);
                    break;
                case System_Information_Class.SystemDeleteSession:
                    cSize = (uint)sizeof(SYSTEM_DELETE_SESSION);
                    break;
                case System_Information_Class.SystemInvalidInfoClass4:
                    throw new Exception("not supported.");
                    break;
                case System_Information_Class.SystemRangeStartInformation:
                    cSize = (uint)sizeof(SYSTEM_RANGE_START_INFORMATION);
                    break;
                case System_Information_Class.SystemVerifierInformation:
                    throw new Exception("Format unknown.");
                    break;
                case System_Information_Class.SystemAddVerifier:
                    throw new Exception("Format unknown.");
                    break;
                case System_Information_Class.SystemSessionProcessesInformation:
                    cSize = (uint)sizeof(SYSTEM_SESSION_PROCESSES_INFORMATION);
                    break;
                case System_Information_Class.SystemDriveVolume:
                    cSize = (uint)sizeof(UNICODE_STRING);
                    break;
            }

            return (system_Information*)msvcrt.malloc(cSize);
        }

        // Query
        [FieldOffset(0)]
        public SYSTEM_BASIC_INFORMATION SystemBasicInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_PROCESSOR_INFORMATION SystemProcessorInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_PERFORMANCE_INFORMATION SystemPerformanceInformation;

        [FieldOffset(0)]
        public SYSTEM_TIME_OF_DAY_INFORMATION SystemTimeOfDayInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_PROCESS_INFORMATION SystemProcessInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_CALL_COUNT_INFORMATION SystemCallCounts;

        [FieldOffset(0)]
        public SYSTEM_CONFIGURATION_INFORMATION SystemConfigurationInformation;

        [FieldOffset(0)]
        public SYSTEM_PROCESSOR_TIMES SystemProcessorTimes;

        [FieldOffset(0)]
        public SYSTEM_GLOBAL_FLAG SystemGlobalFlag;

        // Query
        [FieldOffset(0)]
        public SYSTEM_MODULE_INFORMATION SystemModuleInformation;

        [FieldOffset(0)]
        public SYSTEM_LOCK_INFORMATION SystemLockInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_HANDLE_INFORMATION SystemHandleInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_OBJECT_INFORMATION SystemObjectInformation;

        // Query
        [FieldOffset(0)]
        public SYSTEM_PAGEFILE_INFORMATION SystemPagefileInformation;

        [FieldOffset(0)]
        public SYSTEM_INSTRUCTION_EMULATION_INFORMATION SystemInstructionEmulationCounts;

        [FieldOffset(0)]
        public SYSTEM_CACHE_INFORMATION SystemCacheInformation;

        [FieldOffset(0)]
        public SYSTEM_POOL_TAG_INFORMATION SystemPoolTagInformation;

        [FieldOffset(0)]
        public SYSTEM_PROCESSOR_STATISTICS SystemProcessorStatistics;

        [FieldOffset(0)]
        public SYSTEM_DPC_INFORMATION SystemDpcInformation;

        [FieldOffset(0)]
        public SYSTEM_LOAD_IMAGE SystemLoadImage;

        [FieldOffset(0)]
        public SYSTEM_UNLOAD_IMAGE SystemUnloadImage;

        // Query, Set
        [FieldOffset(0)]
        public SYSTEM_TIME_ADJUSTMENT SystemTimeAdjustment;

        [FieldOffset(0)]
        public SYSTEM_CRASH_DUMP_INFORMATION SystemCrashDumpInformation;

        [FieldOffset(0)]
        public SYSTEM_EXCEPTION_INFORMATION SystemExceptionInformation;

        [FieldOffset(0)]
        public SYSTEM_CRASH_DUMP_STATE_INFORMATION SystemCrashDumpStateInformation;

        [FieldOffset(0)]
        public SYSTEM_KERNEL_DEBUGGER_INFORMATION SystemKernelDebuggerInformation;

        [FieldOffset(0)]
        public SYSTEM_CONTEXT_SWITCH_INFORMATION SystemContextSwitchInformation;

        // Query, Set
        [FieldOffset(0)]
        public SYSTEM_REGISTRY_QUOTA_INFORMATION SystemRegistryQuotaInformation;

        [FieldOffset(0)]
        public SYSTEM_LOAD_AND_CALL_IMAGE SystemLoadAndCallImage;

        [FieldOffset(0)]
        public SYSTEM_PRIORITY_SEPARATION SystemPrioritySeparation;

        [FieldOffset(0)]
        public TIME_ZONE_INFORMATION SystemTimeZoneInformation;

        [FieldOffset(0)]
        public SYSTEM_LOOKASIDE_INFORMATION SystemLookasideInformation;

        [FieldOffset(0)]
        public SYSTEM_SET_TIME_SLIP_EVENT SystemSetTimeSlipEvent;

        [FieldOffset(0)]
        public SYSTEM_CREATE_SESSION SystemCreateSession;

        [FieldOffset(0)]
        public SYSTEM_DELETE_SESSION SystemDeleteSession;

        [FieldOffset(0)]
        public SYSTEM_RANGE_START_INFORMATION SystemRangeStartInformation;

        //[FieldOffset(0)]
        //public ??? SystemVerifierInformation;

        //[FieldOffset(0)]
        //public ??? SystemAddVerifier;

        [FieldOffset(0)]
        public SYSTEM_SESSION_PROCESSES_INFORMATION SystemSessionProcessesInformation;

        [FieldOffset(0)]
        public UNICODE_STRING SystemDriveVolume;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct process_information
    {
        public static void FreeHandle(process_information* cHandle)
        {
            msvcrt.free((IntPtr)cHandle); ;
        }
        public static process_information* CreateHandle(uint cSize)
        {
            return (process_information*)msvcrt.malloc(cSize);
        }
        public static process_information* CreateHandle(process_information_class cClass, out uint cSize)
        {
            cSize = 0;
            switch (cClass)
            {
                case process_information_class.ProcessBasicInformation:
                    cSize = (uint)sizeof(PROCESS_BASIC_INFORMATION);
                    break;
                case process_information_class.ProcessQuotaLimits:
                    cSize = (uint)sizeof(QUOTA_LIMITS);
                    break;
                case process_information_class.ProcessIoCounters:
                    cSize = (uint)sizeof(IO_COUNTERS);
                    break;
                case process_information_class.ProcessVmCounters:
                    cSize = (uint)sizeof(VM_COUNTERS);
                    break;
                case process_information_class.ProcessTimes:
                    cSize = (uint)sizeof(KERNEL_USER_TIMES);
                    break;
                case process_information_class.ProcessBasePriority:
                    cSize = (uint)sizeof(int);
                    break;
                case process_information_class.ProcessRaisePriority:
                    cSize = (uint)sizeof(long);
                    break;
                case process_information_class.ProcessDebugPort:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessExceptionPort:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case process_information_class.ProcessAccessToken:
                    cSize = (uint)sizeof(PROCESS_ACCESS_TOKEN);
                    break;
                case process_information_class.ProcessLdtInformation:
                    cSize = (uint)sizeof(LDT_ENTRY);
                    break;
                case process_information_class.ProcessLdtSize:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessDefaultHardErrorMode:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessIoPortHandlers:
                    throw new Exception("not supported.");
                    break;
                case process_information_class.ProcessPooledUsageAndLimits:
                    cSize = (uint)sizeof(POOLED_USAGE_AND_LIMITS);
                    break;
                case process_information_class.ProcessWorkingSetWatch:
                    cSize = (uint)sizeof(PROCESS_WS_WATCH_INFORMATION);
                    break;
                case process_information_class.ProcessUserModeIOPL:
                    throw new Exception("not supported.");
                    break;
                case process_information_class.ProcessEnableAlignmentFaultFixup:
                    cSize = (uint)sizeof(byte);
                    break;
                case process_information_class.ProcessPriorityClass:
                    cSize = (uint)sizeof(ushort);
                    break;
                case process_information_class.ProcessWx86Information:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessHandleCount:
                    cSize = (uint)sizeof(PROCESS_HANDLE_INFORMATION);
                    break;
                case process_information_class.ProcessAffinityMask:
                    cSize = (uint)sizeof(long);
                    break;
                case process_information_class.ProcessPriorityBoost:
                    cSize = (uint)sizeof(long);
                    break;
                case process_information_class.ProcessDeviceMap:
                    cSize = (uint)sizeof(PROCESS_DEVICE_MAP_INFORMATION);
                    break;
                case process_information_class.ProcessSessionInformation:
                    cSize = (uint)sizeof(PROCESS_SESSION_INFORMATION);
                    break;
                case process_information_class.ProcessForegroundInformation:
                    cSize = (uint)sizeof(PROCESS_FOREGROUND_BACKGROUND);
                    break;
                case process_information_class.ProcessWow64Information:
                    cSize = (uint)sizeof(UIntPtr);
                    break;
                case process_information_class.ProcessImageFileName:
                    cSize = (uint)sizeof(UNICODE_STRING);
                    break;
                case process_information_class.ProcessLUIDDeviceMapsEnabled:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessBreakOnTermination:
                    cSize = (uint)sizeof(bool);
                    break;
                case process_information_class.ProcessDebugObjectHandle:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case process_information_class.ProcessDebugFlags:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessHandleTracing:
                    cSize = (uint)sizeof(PROCESS_HANDLE_TRACING_QUERY);
                    break;
                case process_information_class.ProcessIoPriority:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessExecuteFlags:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessTlsInformation:
                    throw new Exception("not supported.");
                    break;
                case process_information_class.ProcessCookie:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessImageInformation:
                    cSize = (uint)sizeof(SECTION_IMAGE_INFORMATION);
                    break;
                case process_information_class.ProcessCycleTime:
                    cSize = (uint)sizeof(PROCESS_CYCLE_TIME_INFORMATION);
                    break;
                case process_information_class.ProcessPagePriority:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessInstrumentationCallback:
                    throw new Exception("not supported.");
                    break;
                case process_information_class.ProcessThreadStackAllocation:
                    cSize = (uint)sizeof(PROCESS_STACK_ALLOCATION_INFORMATION);
                    break;
                case process_information_class.ProcessWorkingSetWatchEx:
                    cSize = (uint)sizeof(PROCESS_WS_WATCH_INFORMATION_EX);
                    break;
                case process_information_class.ProcessImageFileNameWin32:
                    cSize = (uint)sizeof(UNICODE_STRING);
                    break;
                case process_information_class.ProcessImageFileMapping:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case process_information_class.ProcessAffinityUpdateMode:
                    cSize = (uint)sizeof(PROCESS_AFFINITY_UPDATE_MODE);
                    break;
                case process_information_class.ProcessMemoryAllocationMode:
                    cSize = (uint)sizeof(PROCESS_MEMORY_ALLOCATION_MODE);
                    break;
                case process_information_class.ProcessGroupInformation:
                    cSize = (uint)sizeof(ushort);
                    break;
                case process_information_class.ProcessTokenVirtualizationEnabled:
                    cSize = (uint)sizeof(uint);
                    break;
                case process_information_class.ProcessConsoleHostProcess:
                    cSize = (uint)sizeof(UIntPtr);
                    break;
                case process_information_class.ProcessWindowInformation:
                    cSize = (uint)sizeof(PROCESS_WINDOW_INFORMATION);
                    break;
                case process_information_class.ProcessHandleInformation:
                    cSize = (uint)sizeof(PROCESS_HANDLE_SNAPSHOT_INFORMATION);
                    break;
                case process_information_class.ProcessMitigationPolicy:
                    cSize = (uint)sizeof(PROCESS_MITIGATION_POLICY_INFORMATION);
                    break;
                case process_information_class.ProcessDynamicFunctionTableInformation:
                    throw new Exception("not supported.");
                    break;
                case process_information_class.ProcessHandleCheckingMode:
                    throw new Exception("not supported.");
                    break;
                case process_information_class.ProcessKeepAliveCount:
                    cSize = (uint)sizeof(PROCESS_KEEPALIVE_COUNT_INFORMATION);
                    break;
                case process_information_class.ProcessRevokeFileHandles:
                    cSize = (uint)sizeof(PROCESS_REVOKE_FILE_HANDLES_INFORMATION);
                    break;
                case process_information_class.MaxProcessInfoClass:
                    throw new Exception("not supported.");
                    break;
            }

            return (process_information*)msvcrt.malloc(cSize);
        }

        // Query
        [FieldOffset(0)]
        public PROCESS_BASIC_INFORMATION ProcessBasicInformation;

        // Query, Set
        [FieldOffset(0)]
        public QUOTA_LIMITS ProcessQuotaLimits;

        // Query
        [FieldOffset(0)]
        public IO_COUNTERS ProcessIoCounters;

        // Query
        [FieldOffset(0)]
        public VM_COUNTERS ProcessVmCounters;

        // Query
        [FieldOffset(0)]
        public KERNEL_USER_TIMES ProcessTimes;

        // Set
        [FieldOffset(0)]
        public int ProcessBasePriority;

        // Set
        [FieldOffset(0)]
        public long ProcessRaisePriority;

        // Query, Set
        [FieldOffset(0)]
        public uint ProcessDebugPort;

        // Set
        [FieldOffset(0)]
        public IntPtr ProcessExceptionPort;

        // Set
        [FieldOffset(0)]
        public PROCESS_ACCESS_TOKEN ProcessAccessToken;

        // Query
        [FieldOffset(0)]
        public LDT_ENTRY ProcessLdtInformation;

        // Set
        [FieldOffset(0)]
        public uint ProcessLdtSize;

        // Query, Set
        [FieldOffset(0)]
        public uint ProcessDefaultHardErrorMode;

        // Set
        // (kernel-mode only)
        //[FieldOffset(0)]
        //public ??? ProcessIoPortHandlers;

        // Query
        [FieldOffset(0)]
        public POOLED_USAGE_AND_LIMITS ProcessPooledUsageAndLimits;

        // Query, (Set ??)
        [FieldOffset(0)]
        public PROCESS_WS_WATCH_INFORMATION ProcessWorkingSetWatch;

        // Set
        //[FieldOffset(0)]
        //public ??? ProcessUserModeIOPL;

        // Set
        // false [0] Or true [1]
        [FieldOffset(0)]
        public byte ProcessEnableAlignmentFaultFixup;

        // Set
        [FieldOffset(0)]
        public ushort ProcessPriorityClass;

        // Query
        [FieldOffset(0)]
        public uint ProcessWx86Information;

        // Query
        [FieldOffset(0)]
        public PROCESS_HANDLE_INFORMATION ProcessHandleCount;

        // Set
        [FieldOffset(0)]
        public uint ProcessAffinityMask;

        // Query, Set
        [FieldOffset(0)]
        public uint ProcessPriorityBoost;

        // New ,,,,,,,,,, even not showed in
        // http://undocumented.ntinternals.net

        [FieldOffset(0)]
        public PROCESS_DEVICE_MAP_INFORMATION ProcessDeviceMap;

        [FieldOffset(0)]
        public PROCESS_SESSION_INFORMATION ProcessSessionInformation;

        [FieldOffset(0)]
        public PROCESS_FOREGROUND_BACKGROUND ProcessForegroundInformation;

        [FieldOffset(0)]
        public UIntPtr ProcessWow64Information;

        [FieldOffset(0)]
        public UNICODE_STRING ProcessImageFileName;

        [FieldOffset(0)]
        public uint ProcessLUIDDeviceMapsEnabled;

        // false [0] Or true [1]
        // look at RtlSetProcessIsCritical
        // http://www.geoffchappell.com/viewer.htm?doc=studies/windows/win32/ntdll/api/rtl/peb/setprocessiscritical.htm
        [FieldOffset(0)]
        public uint ProcessBreakOnTermination;

        [FieldOffset(0)]
        public IntPtr ProcessDebugObjectHandle;

        [FieldOffset(0)]
        public uint ProcessDebugFlags;

        // size 0 disables, otherwise enables
        [FieldOffset(0)]
        public PROCESS_HANDLE_TRACING_QUERY ProcessHandleTracing;

        [FieldOffset(0)]
        public uint ProcessIoPriority;

        [FieldOffset(0)]
        public uint ProcessExecuteFlags;

        //[FieldOffset(0)]
        // public ??? ProcessResourceManagement
        // public ??? ProcessTlsInformation;

        [FieldOffset(0)]
        public uint ProcessCookie;

        [FieldOffset(0)]
        public SECTION_IMAGE_INFORMATION ProcessImageInformation;

        [FieldOffset(0)]
        public PROCESS_CYCLE_TIME_INFORMATION ProcessCycleTime;

        [FieldOffset(0)]
        public uint ProcessPagePriority;

        //[FieldOffset(0)]
        //public ??? ProcessInstrumentationCallback;

        [FieldOffset(0)]
        public PROCESS_STACK_ALLOCATION_INFORMATION ProcessThreadStackAllocation;

        [FieldOffset(0)]
        public PROCESS_WS_WATCH_INFORMATION_EX ProcessWorkingSetWatchEx;

        [FieldOffset(0)]
        public UNICODE_STRING ProcessImageFileNameWin32;

        [FieldOffset(0)]
        public IntPtr ProcessImageFileMapping;

        [FieldOffset(0)]
        public PROCESS_AFFINITY_UPDATE_MODE ProcessAffinityUpdateMode;

        [FieldOffset(0)]
        public PROCESS_MEMORY_ALLOCATION_MODE ProcessMemoryAllocationMode;

        [FieldOffset(0)]
        public fixed ushort ProcessGroupInformation[1];

        [FieldOffset(0)]
        public uint ProcessTokenVirtualizationEnabled;

        [FieldOffset(0)]
        public UIntPtr ProcessConsoleHostProcess;

        [FieldOffset(0)]
        public PROCESS_WINDOW_INFORMATION ProcessWindowInformation;

        [FieldOffset(0)]
        public PROCESS_HANDLE_SNAPSHOT_INFORMATION ProcessHandleInformation;

        [FieldOffset(0)]
        public PROCESS_MITIGATION_POLICY_INFORMATION ProcessMitigationPolicy;

        //[FieldOffset(0)]
        //public ??? ProcessDynamicFunctionTableInformation

        //[FieldOffset(0)]
        //public ??? ProcessHandleCheckingMode

        [FieldOffset(0)]
        public PROCESS_KEEPALIVE_COUNT_INFORMATION ProcessKeepAliveCount;

        [FieldOffset(0)]
        public PROCESS_REVOKE_FILE_HANDLES_INFORMATION ProcessRevokeFileHandles;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct THREAD_INFORMATION
    {
        public static void FreeHandle(THREAD_INFORMATION* cHandle)
        {
            msvcrt.free((IntPtr)cHandle); ;
        }
        public static THREAD_INFORMATION* CreateHandle(uint cSize)
        {
            return (THREAD_INFORMATION*)msvcrt.malloc(cSize);
        }
        public static THREAD_INFORMATION* CreateHandle(THREAD_INFORMATION_CLASS cClass, out uint cSize)
        {
            cSize = 0;
            switch (cClass)
            {
                case THREAD_INFORMATION_CLASS.ThreadBasicInformation:
                    cSize = (uint)sizeof(THREAD_BASIC_INFORMATION);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadTimes:
                    cSize = (uint)sizeof(THREAD_TIMES_INFORMATION);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadPriority:
                    cSize = (uint)sizeof(ULONG);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadBasePriority:
                    cSize = (uint)sizeof(ULONG);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadAffinityMask:
                    cSize = (uint)sizeof(ULONG);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadImpersonationToken:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadDescriptorTableEntry:
                    cSize = (uint)sizeof(DESCRIPTOR_TABLE_ENTRY);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadEnableAlignmentFaultFixup:
                    cSize = (uint)sizeof(BOOLEAN);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadEventPair:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadQuerySetWin32StartAddress:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadZeroTlsCell:
                    cSize = (uint)sizeof(ULONG);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadPerformanceCount:
                    cSize = (uint)sizeof(LARGE_INTEGER);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadAmILastThread:
                    cSize = (uint)sizeof(BOOL);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadIdealProcessor:
                    cSize = (uint)sizeof(ULONG);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadPriorityBoost:
                    cSize = (uint)sizeof(BOOLEAN);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadSetTlsArrayAddress:
                    cSize = (uint)sizeof(IntPtr);
                    break;
                case THREAD_INFORMATION_CLASS.ThreadIsIoPending:
                    throw new Exception("not supported.");
                    break;
                case THREAD_INFORMATION_CLASS.ThreadHideFromDebugger:
                    throw new Exception("not supported.");
                    break;
            }

            return (THREAD_INFORMATION*)msvcrt.malloc(cSize);
        }

        // QUERY 
        [FieldOffset(0)]
        public THREAD_BASIC_INFORMATION ThreadBasicInformation;

        // QUERY 
        [FieldOffset(0)]
        public THREAD_TIMES_INFORMATION ThreadTimes;

        // SET 
        [FieldOffset(0)]
        public ULONG ThreadPriority;

        // SET 
        [FieldOffset(0)]
        public ULONG ThreadBasePriority;

        // SET 
        [FieldOffset(0)]
        public ULONG ThreadAffinityMask;

        // SET 
        [FieldOffset(0)]
        public IntPtr ThreadImpersonationToken;

        // QUERY  
        [FieldOffset(0)]
        public DESCRIPTOR_TABLE_ENTRY ThreadDescriptorTableEntry;

        // SET 
        [FieldOffset(0)]
        public BOOLEAN ThreadEnableAlignmentFaultFixup;

        // SET 
        [FieldOffset(0)]
        public IntPtr ThreadEventPair;

        // QUERY / SET
        [FieldOffset(0)]
        public IntPtr ThreadQuerySetWin32StartAddress;

        // SET
        [FieldOffset(0)]
        public ULONG ThreadZeroTlsCell;

        // QUERY
        [FieldOffset(0)]
        public LARGE_INTEGER ThreadPerformanceCount;

        // QUERY
        [FieldOffset(0)]
        public BOOL ThreadAmILastThread;

        // SET
        [FieldOffset(0)]
        public ULONG ThreadIdealProcessor;

        // QUERY / SET
        [FieldOffset(0)]
        public BOOLEAN ThreadPriorityBoost;

        // SET
        [FieldOffset(0)]
        public IntPtr ThreadSetTlsArrayAddress;

        // ???
        //[FieldOffset(0)]
        //public ??? ThreadIsIoPending;

        // ???
        //[FieldOffset(0)]
        //public ??? ThreadHideFromDebugger;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct FILE_INFORMATION
    {
        public static void FreeHandle(FILE_INFORMATION* cHandle)
        {
            msvcrt.free((IntPtr)cHandle); ;
        }
        public static FILE_INFORMATION* CreateHandle(uint cSize)
        {
            return (FILE_INFORMATION*)msvcrt.malloc(cSize);
        }
        public static FILE_INFORMATION* CreateHandle(FILE_INFORMATION_CLASS cClass, out uint cSize)
        {
            cSize = 0;
            switch (cClass)
            {
                case FILE_INFORMATION_CLASS.FileDirectoryInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileFullDirectoryInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileBothDirectoryInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileBasicInformation:
                    cSize = (uint)sizeof(FILE_BASIC_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileStandardInformation:
                    cSize = (uint)sizeof(FILE_STANDARD_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileInternalInformation:
                    cSize = (uint)sizeof(FILE_INTERNAL_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileEaInformation:
                    cSize = (uint)sizeof(FILE_EA_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileAccessInformation:
                    cSize = (uint)sizeof(FILE_ACCESS_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileNameInformation:
                    cSize = (uint)sizeof(FILE_NAME_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileRenameInformation:
                    cSize = (uint)sizeof(FILE_RENAME_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileLinkInformation:
                    cSize = (uint)sizeof(FILE_LINK_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileNamesInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileDispositionInformation:
                    cSize = (uint)sizeof(FILE_DISPOSITION_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FilePositionInformation:
                    cSize = (uint)sizeof(FILE_POSITION_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileFullEaInformation:
                    cSize = (uint)sizeof(FILE_FULL_EA_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileModeInformation:
                    cSize = (uint)sizeof(FILE_MODE_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileAlignmentInformation:
                    cSize = (uint)sizeof(FILE_ALIGNMENT_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileAllInformation:
                    cSize = (uint)sizeof(FILE_ALL_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileAllocationInformation:
                    cSize = (uint)sizeof(FILE_ALLOCATION_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileEndOfFileInformation:
                    //cSize = (uint)sizeof(FILE_END_OF_FILE_INFORMATION);
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileAlternateNameInformation:
                    cSize = (uint)sizeof(FILE_NAME_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileStreamInformation:
                    cSize = (uint)sizeof(FILE_STREAM_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FilePipeInformation:
                    cSize = (uint)sizeof(FILE_PIPE_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FilePipeLocalInformation:
                    cSize = (uint)sizeof(FILE_PIPE_LOCAL_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FilePipeRemoteInformation:
                    cSize = (uint)sizeof(FILE_PIPE_REMOTE_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileMailslotQueryInformation:
                    cSize = (uint)sizeof(FILE_MAILSLOT_QUERY_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileMailslotSetInformation:
                    cSize = (uint)sizeof(FILE_MAILSLOT_SET_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileCompressionInformation:
                    cSize = (uint)sizeof(FILE_COMPRESSION_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileObjectIdInformation:
                    cSize = (uint)sizeof(FILE_ATTRIBUTE_TAG_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileCompletionInformation:
                    cSize = (uint)sizeof(FILE_COMPLETION_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileMoveClusterInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileQuotaInformation:
                    cSize = (uint)sizeof(FILE_QUOTA_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileReparsePointInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileNetworkOpenInformation:
                    cSize = (uint)sizeof(FILE_NETWORK_OPEN_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileAttributeTagInformation:
                    cSize = (uint)sizeof(FILE_ATTRIBUTE_TAG_INFORMATION);
                    break;
                case FILE_INFORMATION_CLASS.FileTrackingInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIdBothDirectoryInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIdFullDirectoryInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileValidDataLengthInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileShortNameInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIoCompletionNotificationInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIoStatusBlockRangeInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIoPriorityHintInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileSfioReserveInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileSfioVolumeInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileHardLinkInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileProcessIdsUsingFileInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileNormalizedNameInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileNetworkPhysicalNameInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIdGlobalTxDirectoryInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileIsRemoteDeviceInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileAttributeCacheInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileNumaNodeInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileStandardLinkInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileRemoteProtocolInformation:
                    throw new Exception("not supported.");
                    break;
                case FILE_INFORMATION_CLASS.FileMaximumInformation:
                    throw new Exception("not supported.");
                    break;
            }

            return (FILE_INFORMATION*)msvcrt.malloc(cSize);
        }

        // Query [NtQueryDirectoryFile]
        //[FieldOffset(0)]
        //public FILE_DIRECTORY_INFORMATION FileDirectoryInformation;

        // Query [NtQueryDirectoryFile]
        //[FieldOffset(0)]
        //public  FILE_FULL_DIR_INFORMATION FileIdFullDirectoryInformation;

        // Query [NtQueryDirectoryFile]
        //[FieldOffset(0)]
        //public  FILE_BOTH_DIR_INFORMATION FileBothDirectoryInformation;

        // Query, Set
        [FieldOffset(0)]
        public FILE_BASIC_INFORMATION FileBasicInformation;

        // Query
        [FieldOffset(0)]
        public FILE_STANDARD_INFORMATION FileStandardInformation;

        // Query
        [FieldOffset(0)]
        public FILE_INTERNAL_INFORMATION FileInternalInformation;

        [FieldOffset(0)]
        public FILE_IO_PRIORITY_HINT_INFORMATION FileIoPriorityHintInformation;

        // Query
        [FieldOffset(0)]
        public FILE_EA_INFORMATION FileEaInformation;

        // Query
        [FieldOffset(0)]
        public FILE_ACCESS_INFORMATION FileAccessInformation;

        // Query
        [FieldOffset(0)]
        public FILE_NAME_INFORMATION FileNameInformation;

        // Set
        [FieldOffset(0)]
        public FILE_RENAME_INFORMATION FileRenameInformation;

        // Set
        [FieldOffset(0)]
        public FILE_LINK_INFORMATION FileLinkInformation;

        // Get [NtQueryDirectoryFile]
        //[FieldOffset(0)]
        //public FILE_NAMES_INFORMATION FileNamesInformation;

        // Set
        [FieldOffset(0)]
        public FILE_DISPOSITION_INFORMATION FileDispositionInformation;

        // Query, Set
        [FieldOffset(0)]
        public FILE_POSITION_INFORMATION FilePositionInformation;

        [FieldOffset(0)]
        public FILE_FULL_EA_INFORMATION FileFullEaInformation;

        [FieldOffset(0)]
        public FILE_MODE_INFORMATION FileModeInformation;

        [FieldOffset(0)]
        public FILE_ALIGNMENT_INFORMATION FileAlignmentInformation;

        // Query
        [FieldOffset(0)]
        public FILE_ALL_INFORMATION FileAllInformation;

        [FieldOffset(0)]
        public FILE_ALLOCATION_INFORMATION FileAllocationInformation;

        // Set
        //[FieldOffset(0)]
        //public FILE_END_OF_FILE_INFORMATION FileEndOfFileInformation;

        // Query
        [FieldOffset(0)]
        public FILE_NAME_INFORMATION FileAlternateNameInformation;

        [FieldOffset(0)]
        public FILE_STREAM_INFORMATION FileStreamInformation;

        [FieldOffset(0)]
        public FILE_PIPE_INFORMATION FilePipeInformation;

        [FieldOffset(0)]
        public FILE_PIPE_LOCAL_INFORMATION FilePipeLocalInformation;

        [FieldOffset(0)]
        public FILE_PIPE_REMOTE_INFORMATION FilePipeRemoteInformation;

        [FieldOffset(0)]
        public FILE_MAILSLOT_QUERY_INFORMATION FileMailslotQueryInformation;

        [FieldOffset(0)]
        public FILE_MAILSLOT_SET_INFORMATION FileMailslotSetInformation;

        [FieldOffset(0)]
        public FILE_COMPRESSION_INFORMATION FileCompressionInformation;

        [FieldOffset(0)]
        public FILE_COPY_ON_WRITE_INFORMATION FileCopyOnWriteInformation;

        // Set
        [FieldOffset(0)]
        public FILE_COMPLETION_INFORMATION FileCompletionInformation;

        //[FieldOffset(0)]
        //public ??? FileMoveClusterInformation;

        [FieldOffset(0)]
        public FILE_QUOTA_INFORMATION FileQuotaInformation;

        //[FieldOffset(0)]
        //public ??? FileReparsePointInformation;

        // Query
        [FieldOffset(0)]
        public FILE_NETWORK_OPEN_INFORMATION FileNetworkOpenInformation;

        [FieldOffset(0)]
        public FILE_ATTRIBUTE_TAG_INFORMATION FileAttributeTagInformation;

        //[FieldOffset(0)]
        //public ??? FileTrackingInformation;

        //[FieldOffset(0)]
        //public ??? FileOleDirectoryInformation;

        //[FieldOffset(0)]
        //public ??? FileContentIndexInformation;

        //[FieldOffset(0)]
        //public ??? FileInheritContentIndexInformation;

        //[FieldOffset(0)]
        //public ??? FileOleInformation;
    }

    #region NTDLL

    [StructLayout(LayoutKind.Explicit)]
    public struct OBJECT_INFORMATION
    {

        [FieldOffset(0)]
        public OBJECT_BASIC_INFORMATION ObjectBasicInformation;

        [FieldOffset(0)]
        public OBJECT_TYPE_INFORMATION ObjectTypeInformation;

        [FieldOffset(0)]
        public OBJECT_NAME_INFORMATION ObjectNameInformation;

        [FieldOffset(0)]
        public OBJECT_ALL_TYPES_INFORMATION ObjectAllTypesInformation;

        [FieldOffset(0)]
        public OBJECT_DATA_INFORMATION ObjectDataInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct OBJECT_BASIC_INFORMATION
    {
        public ULONG Attributes;
        public ACCESS_MASK GrantedAccess;
        public ULONG HandleCount;
        public ULONG PointerCount;
        public ULONG PagedPoolUsage;
        public ULONG NonPagedPoolUsage;
        public fixed ULONG Reserved[3];
        public ULONG NameInformationLength;
        public ULONG TypeInformationLength;
        public ULONG SecurityDescriptorLength;
        public LARGE_INTEGER CreateTime;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct OBJECT_TYPE_INFORMATION
    {
        public UNICODE_STRING Name;
        public ULONG ObjectCount;
        public ULONG HandleCount;
        public fixed ULONG Reserved1[4];
        public ULONG PeakObjectCount;
        public ULONG PeakHandleCount;
        public fixed ULONG Reserved2[4];
        public ULONG InvalidAttributes;
        public GENERIC_MAPPING GenericMapping;
        public ULONG ValidAccess;
        public UCHAR Unknown;
        public BOOLEAN MaintainHandleDatabase;
        public POOL_TYPE PoolType;
        public ULONG PagedPoolUsage;
        public ULONG NonPagedPoolUsage;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OBJECT_NAME_INFORMATION
    {
        public UNICODE_STRING Name;
        //public fixed WCHAR NameBuffer[0];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OBJECT_ALL_TYPES_INFORMATION
    {
        public ULONG NumberOfTypes;
        public OBJECT_TYPE_INFORMATION TypeInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OBJECT_DATA_INFORMATION
    {
        public BOOLEAN InheritHandle;
        public BOOLEAN ProtectFromClose;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SYSTEM_TIME_ADJUSTMENT
    {
        public struct SYSTEM_SET_TIME_ADJUSTMENT
        {
            public ULONG TimeAdjustment;
            public BOOLEAN Enable;
        }
        public struct SYSTEM_QUERY_TIME_ADJUSTMENT
        {
            public ULONG TimeAdjustment;
            public ULONG MaximumIncrement;
            public BOOLEAN TimeSynchronization;
        }

        [FieldOffset(0)]
        public SYSTEM_QUERY_TIME_ADJUSTMENT SystemQueryTimeAdjustment;

        [FieldOffset(0)]
        public SYSTEM_SET_TIME_ADJUSTMENT SystemSetTimeAdjustment;
    }

    public struct SYSTEM_SET_TIME_ADJUSTMENT
    {
        public ULONG TimeAdjustment;
        public BOOLEAN TimeSynchronization;
    }

    public struct SYSTEM_CRASH_DUMP_INFORMATION
    {
        public IntPtr CrashDumpSectionHandle;
        public IntPtr Unknown;
    }

    public struct SYSTEM_EXCEPTION_INFORMATION
    {
        public uint AlignmentFixupCount;
        public uint ExceptionDispatchCount;
        public uint FloatingEmulationCount;
        public uint Reserved;
    }

    public struct SYSTEM_CRASH_DUMP_STATE_INFORMATION
    {
        public uint ValidCrashDump;
        public uint Unknown;
    }

    public struct SYSTEM_KERNEL_DEBUGGER_INFORMATION
    {
        public BOOLEAN DebuggerEnabled;
        public BOOLEAN DebuggerNotPresent;
    }

    public unsafe struct SYSTEM_CONTEXT_SWITCH_INFORMATION
    {
        public uint ContextSwitches;
        public fixed uint ContextSwitchCounters[11];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IMAGE_DOS_HEADER
    {
        public fixed byte e_magic[2]; // Magic number
        public UInt16 e_cblp; // Bytes on last page of file
        public UInt16 e_cp; // Pages in file
        public UInt16 e_crlc; // Relocations
        public UInt16 e_cparhdr; // Size of header in paragraphs
        public UInt16 e_minalloc; // Minimum extra paragraphs needed
        public UInt16 e_maxalloc; // Maximum extra paragraphs needed
        public UInt16 e_ss; // Initial (relative) SS value
        public UInt16 e_sp; // Initial SP value
        public UInt16 e_csum; // Checksum
        public UInt16 e_ip; // Initial IP value
        public UInt16 e_cs; // Initial (relative) CS value
        public UInt16 e_lfarlc; // File address of relocation table
        public UInt16 e_ovno; // Overlay number
        public fixed UInt16 e_res1[4]; // Reserved words
        public UInt16 e_oemid; // OEM identifier (for e_oeminfo)
        public UInt16 e_oeminfo; // OEM information; e_oemid specific
        public fixed UInt16 e_res2[10]; // Reserved words
        public Int32 e_lfanew; // File address of new exe header

        private string _e_magic
        {
            get
            {
                fixed (byte* ptr = e_magic)
                {
                    var arr = new byte[2];
                    for (var i = 0; i < 2; i++) { arr[i] = ptr[i]; }
                    return Encoding.ASCII.GetString(arr);
                }
            }
        }

        public bool isValid
        {
            get { return _e_magic == "MZ"; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IMAGE_NT_HEADERS_86
    {
        public fixed byte Signature[4];
        public IMAGE_FILE_HEADER FileHeader;
        public IMAGE_OPTIONAL_HEADER_86 OptionalHeader;

        private string _Signature
        {
            get
            {
                fixed (byte* ptr = Signature)
                {
                    var arr = new byte[4];
                    for (var i = 0; i < 4; i++) { arr[i] = ptr[i]; }
                    return Encoding.ASCII.GetString(arr);
                }
            }
        }

        public bool isValid
        {
            get { return _Signature == "PE\0\0" && (isX32 | isX64); }
        }

        public bool isX32
        {
            get { return OptionalHeader.Magic == MagicType.IMAGE_NT_OPTIONAL_HDR32_MAGIC; }
        }

        public bool isX64
        {
            get { return OptionalHeader.Magic == MagicType.IMAGE_NT_OPTIONAL_HDR64_MAGIC; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IMAGE_NT_HEADERS_64
    {
        public fixed byte Signature[4];
        public IMAGE_FILE_HEADER FileHeader;
        public IMAGE_OPTIONAL_HEADER_64 OptionalHeader;

        private string _Signature
        {
            get
            {
                fixed (byte* ptr = Signature)
                {
                    var arr = new byte[4];
                    for (var i = 0; i < 4; i++) { arr[i] = ptr[i]; }
                    return Encoding.ASCII.GetString(arr);
                }
            }
        }

        public bool isValid
        {
            get { return _Signature == "PE\0\0" && (isX32 | isX64); }
        }

        public bool isX32
        {
            get { return OptionalHeader.Magic == MagicType.IMAGE_NT_OPTIONAL_HDR32_MAGIC; }
        }

        public bool isX64
        {
            get { return OptionalHeader.Magic == MagicType.IMAGE_NT_OPTIONAL_HDR64_MAGIC; }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 240)]
    public struct IMAGE_OPTIONAL_HEADER_64
    {
        [FieldOffset(0)]
        public MagicType Magic;

        [FieldOffset(2)]
        public byte MajorLinkerVersion;

        [FieldOffset(3)]
        public byte MinorLinkerVersion;

        [FieldOffset(4)]
        public uint SizeOfCode;

        [FieldOffset(8)]
        public uint SizeOfInitializedData;

        [FieldOffset(12)]
        public uint SizeOfUninitializedData;

        [FieldOffset(16)]
        public uint AddressOfEntryPoint;

        [FieldOffset(20)]
        public uint BaseOfCode;

        [FieldOffset(24)]
        public ulong ImageBase;

        [FieldOffset(32)]
        public uint SectionAlignment;

        [FieldOffset(36)]
        public uint FileAlignment;

        [FieldOffset(40)]
        public ushort MajorOperatingSystemVersion;

        [FieldOffset(42)]
        public ushort MinorOperatingSystemVersion;

        [FieldOffset(44)]
        public ushort MajorImageVersion;

        [FieldOffset(46)]
        public ushort MinorImageVersion;

        [FieldOffset(48)]
        public ushort MajorSubsystemVersion;

        [FieldOffset(50)]
        public ushort MinorSubsystemVersion;

        [FieldOffset(52)]
        public uint Win32VersionValue;

        [FieldOffset(56)]
        public uint SizeOfImage;

        [FieldOffset(60)]
        public uint SizeOfHeaders;

        [FieldOffset(64)]
        public uint CheckSum;

        [FieldOffset(68)]
        public SubSystemType Subsystem;

        [FieldOffset(70)]
        public DllCharacteristicsType DllCharacteristics;

        [FieldOffset(72)]
        public ulong SizeOfStackReserve;

        [FieldOffset(80)]
        public ulong SizeOfStackCommit;

        [FieldOffset(88)]
        public ulong SizeOfHeapReserve;

        [FieldOffset(96)]
        public ulong SizeOfHeapCommit;

        [FieldOffset(104)]
        public uint LoaderFlags;

        [FieldOffset(108)]
        public uint NumberOfRvaAndSizes;

        [FieldOffset(112)]
        public IMAGE_DATA_DIRECTORY ExportTable;

        [FieldOffset(120)]
        public IMAGE_DATA_DIRECTORY ImportTable;

        [FieldOffset(128)]
        public IMAGE_DATA_DIRECTORY ResourceTable;

        [FieldOffset(136)]
        public IMAGE_DATA_DIRECTORY ExceptionTable;

        [FieldOffset(144)]
        public IMAGE_DATA_DIRECTORY CertificateTable;

        [FieldOffset(152)]
        public IMAGE_DATA_DIRECTORY BaseRelocationTable;

        [FieldOffset(160)]
        public IMAGE_DATA_DIRECTORY Debug;

        [FieldOffset(168)]
        public IMAGE_DATA_DIRECTORY Architecture;

        [FieldOffset(176)]
        public IMAGE_DATA_DIRECTORY GlobalPtr;

        [FieldOffset(184)]
        public IMAGE_DATA_DIRECTORY TLSTable;

        [FieldOffset(192)]
        public IMAGE_DATA_DIRECTORY LoadConfigTable;

        [FieldOffset(200)]
        public IMAGE_DATA_DIRECTORY BoundImport;

        [FieldOffset(208)]
        public IMAGE_DATA_DIRECTORY IAT;

        [FieldOffset(216)]
        public IMAGE_DATA_DIRECTORY DelayImportDescriptor;

        [FieldOffset(224)]
        public IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

        [FieldOffset(232)]
        public IMAGE_DATA_DIRECTORY Reserved;
    }

    [StructLayout(LayoutKind.Explicit, Size = 224)]
    public struct IMAGE_OPTIONAL_HEADER_86
    {
        [FieldOffset(0)]
        public MagicType Magic;

        [FieldOffset(2)]
        public byte MajorLinkerVersion;

        [FieldOffset(3)]
        public byte MinorLinkerVersion;

        [FieldOffset(4)]
        public uint SizeOfCode;

        [FieldOffset(8)]
        public uint SizeOfInitializedData;

        [FieldOffset(12)]
        public uint SizeOfUninitializedData;

        [FieldOffset(16)]
        public uint AddressOfEntryPoint;

        [FieldOffset(20)]
        public uint BaseOfCode;

        // PE32 contains this additional field
        [FieldOffset(24)]
        public uint BaseOfData;

        [FieldOffset(28)]
        public uint ImageBase;

        [FieldOffset(32)]
        public uint SectionAlignment;

        [FieldOffset(36)]
        public uint FileAlignment;

        [FieldOffset(40)]
        public ushort MajorOperatingSystemVersion;

        [FieldOffset(42)]
        public ushort MinorOperatingSystemVersion;

        [FieldOffset(44)]
        public ushort MajorImageVersion;

        [FieldOffset(46)]
        public ushort MinorImageVersion;

        [FieldOffset(48)]
        public ushort MajorSubsystemVersion;

        [FieldOffset(50)]
        public ushort MinorSubsystemVersion;

        [FieldOffset(52)]
        public uint Win32VersionValue;

        [FieldOffset(56)]
        public uint SizeOfImage;

        [FieldOffset(60)]
        public uint SizeOfHeaders;

        [FieldOffset(64)]
        public uint CheckSum;

        [FieldOffset(68)]
        public SubSystemType Subsystem;

        [FieldOffset(70)]
        public DllCharacteristicsType DllCharacteristics;

        [FieldOffset(72)]
        public uint SizeOfStackReserve;

        [FieldOffset(76)]
        public uint SizeOfStackCommit;

        [FieldOffset(80)]
        public uint SizeOfHeapReserve;

        [FieldOffset(84)]
        public uint SizeOfHeapCommit;

        [FieldOffset(88)]
        public uint LoaderFlags;

        [FieldOffset(92)]
        public uint NumberOfRvaAndSizes;

        [FieldOffset(96)]
        public IMAGE_DATA_DIRECTORY ExportTable;

        [FieldOffset(104)]
        public IMAGE_DATA_DIRECTORY ImportTable;

        [FieldOffset(112)]
        public IMAGE_DATA_DIRECTORY ResourceTable;

        [FieldOffset(120)]
        public IMAGE_DATA_DIRECTORY ExceptionTable;

        [FieldOffset(128)]
        public IMAGE_DATA_DIRECTORY CertificateTable;

        [FieldOffset(136)]
        public IMAGE_DATA_DIRECTORY BaseRelocationTable;

        [FieldOffset(144)]
        public IMAGE_DATA_DIRECTORY Debug;

        [FieldOffset(152)]
        public IMAGE_DATA_DIRECTORY Architecture;

        [FieldOffset(160)]
        public IMAGE_DATA_DIRECTORY GlobalPtr;

        [FieldOffset(168)]
        public IMAGE_DATA_DIRECTORY TLSTable;

        [FieldOffset(176)]
        public IMAGE_DATA_DIRECTORY LoadConfigTable;

        [FieldOffset(184)]
        public IMAGE_DATA_DIRECTORY BoundImport;

        [FieldOffset(192)]
        public IMAGE_DATA_DIRECTORY IAT;

        [FieldOffset(200)]
        public IMAGE_DATA_DIRECTORY DelayImportDescriptor;

        [FieldOffset(208)]
        public IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

        [FieldOffset(216)]
        public IMAGE_DATA_DIRECTORY Reserved;
    }

    public struct IMAGE_FILE_HEADER
    {
        public MachineType Machine;
        public ushort NumberOfSections;
        public uint TimeDateStamp;
        public uint PointerToSymbolTable;
        public uint NumberOfSymbols;
        public ushort SizeOfOptionalHeader;
        public ushort Characteristics;
    }

    public struct IMAGE_DATA_DIRECTORY
    {
        public int VirtualAddress;
        public int Size;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IMAGE_SECTION_HEADER
    {
        [FieldOffset(0)]
        public fixed byte name[8];

        [FieldOffset(8)]
        public UInt32 VirtualSize;

        [FieldOffset(12)]
        public UInt32 VirtualAddress;

        [FieldOffset(16)]
        public UInt32 SizeOfRawData;

        [FieldOffset(20)]
        public UInt32 PointerToRawData;

        [FieldOffset(24)]
        public UInt32 PointerToRelocations;

        [FieldOffset(28)]
        public UInt32 PointerToLinenumbers;

        [FieldOffset(32)]
        public UInt16 NumberOfRelocations;

        [FieldOffset(34)]
        public UInt16 NumberOfLinenumbers;

        [FieldOffset(36)]
        public DataSectionFlags Characteristics;

        public string Name
        {
            get
            {
                fixed (byte* ptr = name)
                {
                    var arr = new byte[8];
                    for (var i = 0; i < 8; i++) { arr[i] = ptr[i]; }
                    return Encoding.ASCII.GetString(arr);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_EXPORT_DIRECTORY
    {
        public UInt32 Characteristics;
        public UInt32 TimeDateStamp;
        public UInt16 MajorVersion;
        public UInt16 MinorVersion;
        public UInt32 Name;
        public UInt32 Base;
        public UInt32 NumberOfFunctions;
        public UInt32 NumberOfNames;
        public IntPtr AddressOfFunctions; // RVA from base of image
        public IntPtr AddressOfNames; // RVA from base of image
        public IntPtr AddressOfNameOrdinals; // RVA from base of image
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_IMPORT_DESCRIPTOR
    {
        [FieldOffset(0)]
        public uint OriginalFirstThunk;

        [FieldOffset(4)]
        public uint dwUseless1;

        [FieldOffset(8)]
        public uint dwUseless2;

        [FieldOffset(12)]
        public uint Name;

        [FieldOffset(16)]
        public uint FirstThunk;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_THUNK_DATA
    {
        [FieldOffset(0)]
        public int ForwarderString; // PBYTE 
        [FieldOffset(0)]
        public int Function; // PDWORD
        [FieldOffset(0)]
        public int Ordinal;
        [FieldOffset(0)]
        public int AddressOfData; // IMAGE_IMPORT_BY_NAME
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_IMPORT_BY_NAME
    {
        [FieldOffset(0)]
        public ushort Hint;
        [FieldOffset(2)]
        public byte Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_COR20_HEADER
    {
        // Header versioning
        public uint cb;
        public ushort MajorRuntimeVersion;
        public ushort MinorRuntimeVersion;

        // Symbol table and startup information
        public IMAGE_DATA_DIRECTORY MetaData;
        public uint Flags;
        public uint EntryPointToken;

        // Binding information
        public IMAGE_DATA_DIRECTORY Resources;
        public IMAGE_DATA_DIRECTORY StrongNameSignature;

        // Regular fixup and binding information
        public IMAGE_DATA_DIRECTORY CodeManagerTable;
        public IMAGE_DATA_DIRECTORY VTableFixups;
        public IMAGE_DATA_DIRECTORY ExportAddressTableJumps;

        // Precompiled image info (public use only - set to zero)
        public IMAGE_DATA_DIRECTORY ManagedNativeHeader;
    }

    public struct SYSTEM_REGISTRY_QUOTA_INFORMATION
    {
        public uint RegistryQuota;
        public uint RegistryQuotaInUse;
        public uint PagedPoolSize;
    }

    public struct SYSTEM_LOAD_AND_CALL_IMAGE
    {
        public UNICODE_STRING ModuleName;
    }

    public struct SYSTEM_PRIORITY_SEPARATION
    {
        public uint PrioritySeparation;
    }
    public struct SYSTEM_SESSION_PROCESSES_INFORMATION
    {
        public ULONG SessionId;
        public ULONG BufferSize;
        public PVOID Buffer;
    }
    public struct SYSTEM_CREATE_SESSION
    {
        public ULONG SessionId;
    }
    public struct SYSTEM_RANGE_START_INFORMATION
    {
        public PVOID SystemRangeStart;
    }
    public struct SYSTEM_DELETE_SESSION
    {
        public ULONG SessionId;
    }

    public struct SYSTEM_SET_TIME_SLIP_EVENT
    {
        public HANDLE TimeSlipEvent;
    }

    public struct SYSTEM_LOOKASIDE_INFORMATION
    {
        public ushort Depth;
        public ushort MaximumDepth;
        public uint TotalAllocates;
        public uint AllocateMisses;
        public uint TotalFrees;
        public uint FreeMisses;
        public POOL_TYPE Type;
        public uint Tag;
        public uint Size;
    }

    public struct PROCESS_MODULE_INFO
    {
        public ULONG Size; // 0x24
        public MODULE_HEADER ModuleHeader;
    }

    public struct MODULE_HEADER
    {
        public ULONG Initialized;
        public HANDLE SsHandle;
        public LIST_ENTRY InLoadOrderModuleList;
        public LIST_ENTRY InMemoryOrderModuleList;
        public LIST_ENTRY InInitializationOrderModuleList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PROCESS_BASIC_INFORMATION
    {
        public IntPtr ExitStatus;

        /// <summary>
        /// PEB structure
        /// </summary>
        public PEB* PebBaseAddress;

        public IntPtr AffinityMask;
        public IntPtr BasePriority;

        public IntPtr UniqueProcessId;
        public IntPtr InheritedFromUniqueProcessId;

        public PEB_86* PEB_86
        {
            get { return (PEB_86*)PebBaseAddress; }
        }

        public PEB_64* PEB_64
        {
            get { return (PEB_64*)PebBaseAddress; }
        }

        public int Size
        {
            get { return (6 * IntPtr.Size); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PEB
    {
        public short ignoreMe;

        public byte BeingDebugged;

        public byte ignoreMe_;
        public IntPtr ignoreMe__;
        public IntPtr ignoreMe___;
        public IntPtr ignoreMe____;

        public RTL_USER_PROCESS_PARAMETERS* ProcessParameters;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PEB_86
    {
        public byte InheritedAddressSpace;
        public byte ReadImageFileExecOptions;
        public byte BeingDebugged;
        public byte SpareBool;
        public HANDLE Mutant;

        // OR
        // public IntPtr SectionBaseAddress
        // public IntPtr ImageBaseAddress
        
        // OR
        public PROCESS_MODULE_INFO* ProcessModuleInfo;
        public PEB_LDR_DATA* Ldr;

        public RTL_USER_PROCESS_PARAMETERS* ProcessParameters;
        
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PEB_64
    {
        public byte InheritedAddressSpace;
        public byte ReadImageFileExecOptions;
        public byte BeingDebugged;

        public fixed byte Reserved2[21];

        /// <summary> 
        /// PEB_LDR_DATA structure
        /// </summary>
        public PEB_LDR_DATA* LoaderData;

        /// <summary>
        /// RTL_USER_PROCESS_PARAMETERS structure
        /// </summary>
        public RTL_USER_PROCESS_PARAMETERS* ProcessParameters;

        //public fixed byte Reserved3[520];
        //public IntPtr PostProcessInitRoutine;
        //public fixed byte Reserved4[136];
        //public uint SessionId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RTL_USER_PROCESS_PARAMETERS
    {
        public uint MaximumLength;
        public uint Length;
        public uint Flags;
        public uint DebugFlags;
        public SafeWindowHandle ConsoleHandle;
        public uint ConsoleFlags;

        // we can cast it as SafeFileHandle too.
        // also, we can change it using CreateFile ot new Console Handle. 
        public SafeConsoleHandle StdInputHandle;
        public SafeConsoleHandle StdOutputHandle;
        public SafeConsoleHandle StdErrorHandle;

        public UNICODE_STRING CurrentDirectoryPath;
        public IntPtr CurrentDirectoryHandle;
        public UNICODE_STRING DllPath;
        public UNICODE_STRING ImagePathName;
        public UNICODE_STRING CommandLine;
        public Environment Environment;

        public uint StartingPositionLeft;
        public uint StartingPositionTop;
        public uint Width;
        public uint Height;
        public uint CharWidth;
        public uint CharHeight;
        public uint ConsoleTextAttributes;
        public WindowStyleFlags WindowFlags;
        public ShowWindowCommand ShowWindowFlags;
        public UNICODE_STRING WindowTitle;
        public UNICODE_STRING DesktopName;
        public UNICODE_STRING ShellInfo;
        public UNICODE_STRING RuntimeData;
        public fixed byte DLCurrentDirectory[0x20 * 0xc];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Environment
    {
        public Environment(int ptr)
        {
            Handle = (char*)ptr;
        }
        public Environment(IntPtr ptr)
        {
            Handle = (char*)ptr;
        }
        public char* Handle;

        public string[] Strings
        {
            get
            {
                var eCount = 0;
                var eContinue = true;
                var eString = string.Empty;
                var eVar = this.Handle;
                var eList = new List<string>();

                do
                {
                    switch (eVar[0])
                    {
                        /* End */
                        case '\0':
                            //Console.Write(eVar[0]);
                            //Console.WriteLine();

                            eString = Marshal.PtrToStringUni(
                                (IntPtr)eVar - (eCount * 2 - 2), eCount - 1);
                            eList.Add(eString);
                            eCount = 0;

                            //Console.WriteLine(eString);
                            //Console.WriteLine();

                            if (eVar[1] == '\0')
                                eContinue = false;
                            break;

                        /* Start */
                        default:
                            //Console.Write(eVar[0]);
                            break;
                    }

                    // next .!.
                    eVar += 1;
                    eCount += 1;

                } while (eContinue);

                return eList.ToArray();
            }
        }
        public string[] StringsFromProcess(SafeProcessHandle hProcess)
        {
            uint lpNumberOfBytesRead;
            var lpBuffer = (char*)kernel32.LocalAlloc(LocalMemoryFlags.Fixed, 0x2710);
            kernel32.ReadProcessMemory(hProcess, (IntPtr)Handle, (IntPtr)lpBuffer, 0x2710, out lpNumberOfBytesRead);

            var eCount = 0;
            var eContinue = true;
            var eString = string.Empty;
            var eList = new List<string>();

            do
            {
                switch (lpBuffer[0])
                {
                    /* End */
                    case '\0':
                        //Console.Write(eVar[0]);
                        //Console.WriteLine();

                        eString = Marshal.PtrToStringUni(
                            (IntPtr)lpBuffer - (eCount * 2 - 2), eCount - 1);
                        eList.Add(eString);
                        eCount = 0;

                        //Console.WriteLine(eString);
                        //Console.WriteLine();

                        if (lpBuffer[1] == '\0')
                            eContinue = false;
                        break;

                    /* Start */
                    default:
                        //Console.Write(eVar[0]);
                        break;
                }

                // next .!.
                lpBuffer += 1;
                eCount += 1;

            } while (eContinue);

            kernel32.LocalFree((IntPtr) lpBuffer);
            return eList.ToArray();
        }

        public static Environment FromPtr(IntPtr handle)
        {
            return new Environment() { Handle = (char*)handle };
        }
        public static Environment Instance()
        {
            return new Environment() { Handle = (char*)0 };
        }
        public void Destroy()
        {
            userenv.DestroyEnvironmentBlock(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PEB_LDR_DATA
    {
        public int Length;
        public bool Initialized;
        public IntPtr SsHandle;

        /// <summary>
        /// LDR_DATA_TABLE_ENTRY structure
        /// </summary>
        public LIST_ENTRY InLoadOrderModuleList;

        /// <summary>
        /// LDR_DATA_TABLE_ENTRY structure
        /// </summary>
        public LIST_ENTRY InMemoryOrderModuleList;

        /// <summary>
        /// LDR_DATA_TABLE_ENTRY structure
        /// </summary>
        public LIST_ENTRY InInitializationOrderModuleList;

        public PVOID EntryInProgress;
        //public BOOLEAN ShutdownInProgress;
        //public HANDLE ShutdownThreadId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LDR_DATA_TABLE_ENTRY
    {
        public LIST_ENTRY InLoadOrderModuleList;
        public LIST_ENTRY InMemoryOrderModuleList;
        public LIST_ENTRY InInitializationOrderModuleList;
        public IntPtr BaseAddress;
        public IntPtr EntryPoint;
        public UInt32 SizeOfImage;
        public UNICODE_STRING FullDllName;
        public UNICODE_STRING BaseDllName;
        public UInt32 Flags;
        public short LoadCount;
        public short TlsIndex;
        public LIST_ENTRY HashTableEntry;
        public UInt32 TimeDateStamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct THREAD_BASIC_INFORMATION
    {
        public NtStatus ExitStatus;
        public PVOID TebBaseAddress;
        public CLIENT_ID ClientId;
        public uint AffinityMask;
        public uint Priority;
        public uint BasePriority;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct THREAD_TIMES_INFORMATION
    {
        public LARGE_INTEGER CreationTime;
        public LARGE_INTEGER ExitTime;
        public LARGE_INTEGER KernelTime;
        public LARGE_INTEGER UserTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DESCRIPTOR_TABLE_ENTRY
    {
        public ULONG Selector;
        public LDT_ENTRY Descriptor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_ALL_INFORMATION
    {
        public FILE_BASIC_INFORMATION BasicInformation;
        public FILE_STANDARD_INFORMATION StandardInformation;
        public FILE_INTERNAL_INFORMATION InternalInformation;
        public FILE_EA_INFORMATION EaInformation;
        public FILE_ACCESS_INFORMATION AccessInformation;
        public FILE_POSITION_INFORMATION PositionInformation;
        public FILE_MODE_INFORMATION ModeInformation;
        public FILE_ALIGNMENT_INFORMATION AlignmentInformation;
        public FILE_NAME_INFORMATION NameInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_ACCESS_INFORMATION
    {
        public ACCESS_MASK AccessFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_ALIGNMENT_INFORMATION
    {
        public ULONG AlignmentRequirement;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_ALLOCATION_INFORMATION
    {
        public LARGE_INTEGER AllocationSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_END_OF_FILE_INFORMATION
    {
        public LARGE_INTEGER EndOfFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_PIPE_INFORMATION
    {
        public ULONG ReadMode;
        public ULONG CompletionMode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_PIPE_LOCAL_INFORMATION
    {
        public ULONG NamedPipeType;
        public ULONG NamedPipeConfiguration;
        public ULONG MaximumInstances;
        public ULONG CurrentInstances;
        public ULONG InboundQuota;
        public ULONG ReadDataAvailable;
        public ULONG OutboundQuota;
        public ULONG WriteQuotaAvailable;
        public ULONG NamedPipeState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_PIPE_REMOTE_INFORMATION
    {
        public LARGE_INTEGER CollectDataTime;
        public ULONG MaximumCollectionCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_COMPRESSION_INFORMATION
    {
        public LARGE_INTEGER CompressedFileSize;
        public USHORT CompressionFormat;
        public UCHAR CompressionUnitShift;
        public UCHAR ChunkShift;
        public UCHAR ClusterShift;
        public fixed UCHAR Reserved[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_MAILSLOT_QUERY_INFORMATION
    {
        public ULONG MaximumMessageSize;
        public ULONG MailslotQuota;
        public ULONG NextMessageSize;
        public ULONG MessagesAvailable;
        public LARGE_INTEGER ReadTimeout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_MAILSLOT_SET_INFORMATION
    {
        public LARGE_INTEGER* ReadTimeout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_ATTRIBUTE_TAG_INFORMATION
    {
        public Enum.FileAttributes FileAttributes;
        public ULONG ReparseTag;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_BASIC_INFORMATION
    {
        public LARGE_INTEGER CreationTime;
        public LARGE_INTEGER LastAccessTime;
        public LARGE_INTEGER LastWriteTime;
        public LARGE_INTEGER ChangeTime;
        public Enum.FileAttributes FileAttributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_EA_INFORMATION
    {
        public ULONG EaSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_INTERNAL_INFORMATION
    {
        public LARGE_INTEGER IndexNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_IO_PRIORITY_HINT_INFORMATION
    {
        public IO_PRIORITY_HINT PriorityHint;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_MODE_INFORMATION
    {
        public ULONG Mode;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_RENAME_INFORMATION
    {
        public BOOLEAN ReplaceIfExists;
        public HANDLE RootDirectory;
        public ULONG FileNameLength;
        public fixed WCHAR FileName[256];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_LINK_INFORMATION
    {
        public BOOLEAN ReplaceIfExists;
        public HANDLE RootDirectory;
        public ULONG FileNameLength;
        public fixed WCHAR FileName[256];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_DISPOSITION_INFORMATION
    {
        public BOOLEAN DeleteFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_COMPLETION_INFORMATION
    {
        public HANDLE Port;
        public PVOID Key;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SID
    {
        public byte Revision;
        public byte SubAuthorityCount;
        public SID_IDENTIFIER_AUTHORITY IdentifierAuthority;
        public fixed uint SubAuthority[1];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_QUOTA_INFORMATION
    {
        public ULONG NextEntryOffset;
        public ULONG SidLength;
        public LARGE_INTEGER ChangeTime;
        public LARGE_INTEGER QuotaUsed;
        public LARGE_INTEGER QuotaThreshold;
        public LARGE_INTEGER QuotaLimit;
        public SID Sid;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_COPY_ON_WRITE_INFORMATION
    {
        public BOOLEAN ReplaceIfExists;
        public HANDLE RootDirectory;
        public ULONG FileNameLength;
        public fixed WCHAR FileName[1];

        public string Name
        {
            get
            {
                fixed (char* FileNamePtr = FileName)
                    return new string(FileNamePtr);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_NAME_INFORMATION
    {
        public ULONG FileNameLength;
        public fixed WCHAR FileName[1];

        public string Name
        {
            get
            {
                fixed (char* FileNamePtr = FileName)
                {
                    var idx = 0;
                    do
                    {
                        idx++;
                    } while ((FileNamePtr[idx] < 127 && FileNamePtr[idx] != '\0') &&
                        idx < FileNameLength);
                    return new string(FileNamePtr, 0, idx);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_STREAM_INFORMATION
    {
        public ULONG NextEntryOffset;
        public ULONG StreamNameLength;
        public LARGE_INTEGER StreamSize;
        public LARGE_INTEGER StreamAllocationSize;
        public fixed WCHAR StreamName[1];

        public string Name
        {
            get
            {
                fixed (char* FileNamePtr = StreamName)
                    return new string(FileNamePtr);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_NETWORK_OPEN_INFORMATION
    {
        public LARGE_INTEGER CreationTime;
        public LARGE_INTEGER LastAccessTime;
        public LARGE_INTEGER LastWriteTime;
        public LARGE_INTEGER ChangeTime;
        public LARGE_INTEGER AllocationSize;
        public LARGE_INTEGER EndOfFile;
        public FileAttributes FileAttributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_POSITION_INFORMATION
    {
        public LARGE_INTEGER CurrentByteOffset;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FILE_FULL_EA_INFORMATION
    {
        public ULONG NextEntryOffset;
        public UCHAR Flags;
        public UCHAR EaNameLength;
        public USHORT EaValueLength;
        public fixed CHAR EaName[1];

        public string Name
        {
            get
            {
                fixed (byte* namePtr = EaName)
                    return new string((char*)namePtr);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILE_STANDARD_INFORMATION
    {
        public LARGE_INTEGER AllocationSize;
        public LARGE_INTEGER EndOfFile;
        public ULONG NumberOfLinks;
        public BOOLEAN DeletePending;
        public BOOLEAN Directory;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TOKEN_INFORMATION
    {
        [FieldOffset(0)]
        public TOKEN_USER TokenUser;

        [FieldOffset(0)]
        public TOKEN_GROUPS TokenGroups;

        [FieldOffset(0)]
        public TOKEN_PRIVILEGES TokenPrivileges;

        [FieldOffset(0)]
        public TOKEN_OWNER TokenOwner;

        [FieldOffset(0)]
        public TOKEN_PRIMARY_GROUP TokenPrimaryGroup;

        [FieldOffset(0)]
        public TOKEN_DEFAULT_DACL TokenDefaultDacl;

        [FieldOffset(0)]
        public TOKEN_SOURCE TokenSource;

        [FieldOffset(0)]
        public TOKEN_TYPE TokenType;

        [FieldOffset(0)]
        public SECURITY_IMPERSONATION_LEVEL TokenImpersonationLevel;

        [FieldOffset(0)]
        public TOKEN_STATISTICS TokenStatistics;

        [FieldOffset(0)]
        public TOKEN_GROUPS TokenRestrictedSids;

        [FieldOffset(0)]
        public uint TokenSessionId;

        [FieldOffset(0)]
        public TOKEN_GROUPS_AND_PRIVILEGES TokenGroupsAndPrivileges;

        [FieldOffset(0)]
        public uint TokenSandBoxInert;

        [FieldOffset(0)]
        public TOKEN_ORIGIN TokenOrigin;

        [FieldOffset(0)]
        public TOKEN_ELEVATION_TYPE TokenElevationType;

        [FieldOffset(0)]
        public TOKEN_LINKED_TOKEN TokenLinkedToken;

        [FieldOffset(0)]
        public TOKEN_ELEVATION TokenElevation;

        [FieldOffset(0)]
        public uint TokenHasRestrictions;

        [FieldOffset(0)]
        public TOKEN_ACCESS_INFORMATION TokenAccessInformation;

        [FieldOffset(0)]
        public uint TokenVirtualizationAllowed;

        [FieldOffset(0)]
        public uint TokenVirtualizationEnabled;

        [FieldOffset(0)]
        public TOKEN_MANDATORY_LABEL TokenIntegrityLevel;

        [FieldOffset(0)]
        public uint TokenUIAccess;

        [FieldOffset(0)]
        public TOKEN_MANDATORY_POLICY TokenMandatoryPolicy;

        [FieldOffset(0)]
        public TOKEN_GROUPS TokenLogonSid;

        [FieldOffset(0)]
        public uint TokenIsAppContainer;

        [FieldOffset(0)]
        public TOKEN_GROUPS TokenCapabilities;

        [FieldOffset(0)]
        public TOKEN_APPCONTAINER_INFORMATION TokenAppContainerSid;

        [FieldOffset(0)]
        public uint TokenAppContainerNumber;

        [FieldOffset(0)]
        public CLAIM_SECURITY_ATTRIBUTES_INFORMATION TokenUserClaimAttributes;

        [FieldOffset(0)]
        public CLAIM_SECURITY_ATTRIBUTES_INFORMATION TokenDeviceClaimAttributes;

        [FieldOffset(0)]
        public TOKEN_GROUPS TokenDeviceGroups;

        [FieldOffset(0)]
        public TOKEN_GROUPS TokenRestrictedDeviceGroups;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Process_Device_Map_Information
    {
        [FieldOffset(0)]
        public System.IntPtr DirectoryHandleSet;

        public struct AnonymousStruct
        {
            public uint DriveMap;
            public unsafe fixed byte DriveType[32];
        }

        [FieldOffset(0)]
        public AnonymousStruct Query;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_MEMORY_ALLOCATION_MODE
    {
        public ULONG Flags;
        public ULONG Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_AFFINITY_UPDATE_MODE
    {
        public ULONG Flags;
        public ULONG Reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct PROCESS_WINDOW_INFORMATION
    {
        public ULONG WindowFlags;
        public USHORT WindowTitleLength;
        public WCHAR WindowTitle;

        public string Title
        {
            get
            {
                fixed (char* titlePtr = &WindowTitle)
                    return new string(titlePtr);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_HANDLE_SNAPSHOT_INFORMATION
    {
        public ULONG_PTR NumberOfHandles;
        public ULONG_PTR Reserved;
        public PROCESS_HANDLE_TABLE_ENTRY_INFO First;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_HANDLE_TRACING_QUERY
    {
        public HANDLE Handle;
        public ULONG TotalTraces;
        public PROCESS_HANDLE_TRACING_ENTRY First;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PROCESS_HANDLE_TRACING_ENTRY
    {
        public HANDLE Handle;
        public CLIENT_ID ClientId;
        public ULONG Type;
        public fixed int Stacks[16]; // IntPtr array
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLIENT_ID
    {
        public uint UniqueProcess;
        public uint UniqueThread;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_HANDLE_TABLE_ENTRY_INFO
    {
        private IntPtr HandleValue;
        private uint HandleCount;
        private uint PointerCount;
        private uint GrantedAccess;
        private uint ObjectTypeIndex;
        private uint HandleAttributes;
        private uint Reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_HANDLE_INFORMATION
    {
        public UInt32 HandleCount;
        //public fixed int Reserved3[1];
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct PROCESS_DEVICE_MAP_INFORMATION
    {
        [FieldOffset(0)]
        public PROCESS_DEVICE_MAP_INFORMATION_SET Set;

        [FieldOffset(0)]
        public PROCESS_DEVICE_MAP_INFORMATION_Query Query;

        public struct PROCESS_DEVICE_MAP_INFORMATION_SET
        {
            public HANDLE directoryHandle;
        }
        public struct PROCESS_DEVICE_MAP_INFORMATION_Query
        {
            public ulong DriveMap;
            public fixed byte DriveType[32];
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SECTION_IMAGE_INFORMATION
    {
        public PVOID EntryPoint;
        public ULONG StackZeroBits;
        public ULONG StackReserved;
        public ULONG StackCommit;
        public ULONG ImageSubsystem;
        public WORD SubsystemVersionLow;
        public WORD SubsystemVersionHigh;
        public ULONG Unknown1;
        public ULONG ImageCharacteristics;
        public ULONG ImageMachineType;
        public fixed ULONG Unknown2[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_FOREGROUND_BACKGROUND
    {
        // bool ....
        public byte Foreground;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_KEEPALIVE_COUNT_INFORMATION
    {
        public ULONG Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_REVOKE_FILE_HANDLES_INFORMATION
    {
        public UNICODE_STRING TargetDevicePath;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct PROCESS_MITIGATION_POLICY_INFORMATION
    {
        [FieldOffset(0)]
        public PROCESS_MITIGATION_POLICY Policy;

        // Any Policy Type
        [FieldOffset(4)]
        public DWORD Flags;

        // PROCESS_MITIGATION_DEP_POLICY Policy Type Only
        [FieldOffset(8)]
        public BOOLEAN Permanent;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_SESSION_INFORMATION
    {
        public ULONG SessionId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_CYCLE_TIME_INFORMATION
    {
        public long AccumulatedCycles;
        public long CurrentCycleCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_STACK_ALLOCATION_INFORMATION
    {
        public SIZE_T ReserveSize;
        public SIZE_T ZeroBits;
        public PVOID StackBase;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_WS_WATCH_INFORMATION_EX
    {
        public PROCESS_WS_WATCH_INFORMATION BasicInfo;
        public ULONG_PTR FaultingThreadId;
        public ULONG_PTR Flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_WS_WATCH_INFORMATION
    {
        public IntPtr FaultingPc;
        public IntPtr FaultingVa;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_HANDLE_INFORMATION
    {
        public ULONG HandleCount;
        public SYSTEM_HANDLE_TABLE_ENTRY_INFO first;
    }

    public struct IO_STATUS_BLOCK
    {
        public PVOID Pointer;
        public ULONG_PTR Information;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_HANDLE_TABLE_ENTRY_INFO
    {
        public ULONG pId;
        public BYTE ObjectTypeNumber;
        public BYTE Flags; // 0x01 = PROTECT_FROM_CLOSE, 0x02 = INHERIT
        public USHORT handle;
        public PVOID Object;
        public ACCESS_MASK GrantedAccess;

        public uint ProcessId
        {
            get { return pId; }
        }
        public IntPtr Handle
        {
            get
            {
                IntPtr newHandle;
                var src = (IntPtr)handle;
                ObjectHelper.Duplicate(pId, src, out newHandle);
                return newHandle;
            }
        }
        public unsafe OBJECT_NAME_INFORMATION Name
        {
            get
            {
                OBJECT_INFORMATION* newhandle;
                ObjectHelper.Query(OBJECT_INFORMATION_CLASS.ObjectNameInformation, Handle, out newhandle);
                return (int)newhandle == 0 ? default(OBJECT_NAME_INFORMATION) : newhandle->ObjectNameInformation;
            }
        }
        public unsafe OBJECT_TYPE_INFORMATION Type
        {
            get
            {
                OBJECT_INFORMATION* newhandle;
                ObjectHelper.Query(OBJECT_INFORMATION_CLASS.ObjectTypeInformation, Handle, out newhandle);
                return (int)newhandle == 0 ? default(OBJECT_TYPE_INFORMATION) : newhandle->ObjectTypeInformation;
            }
        }
        public unsafe OBJECT_BASIC_INFORMATION Basic
        {
            get
            {
                OBJECT_INFORMATION* newhandle;
                ObjectHelper.Query(OBJECT_INFORMATION_CLASS.ObjectBasicInformation, Handle, out newhandle);
                return (int)newhandle == 0 ? default(OBJECT_BASIC_INFORMATION) : newhandle->ObjectBasicInformation;
            }
        }
        public unsafe OBJECT_DATA_INFORMATION Data
        {
            get
            {
                OBJECT_INFORMATION* newhandle;
                ObjectHelper.Query(OBJECT_INFORMATION_CLASS.ObjectDataInformation, Handle, out newhandle);
                return (int)newhandle == 0 ? default(OBJECT_DATA_INFORMATION) : newhandle->ObjectDataInformation;
            }
        }
        public void Close()
        {
            var tProc = kernel32.GetCurrentProcess();
            var sProc = kernel32.OpenProcess(
                ProcessAccessFlags.DupHandle,
                false, ProcessId);

            IntPtr newHandle;
            kernel32.DuplicateHandle(
                sProc, (IntPtr)handle,
                tProc, out newHandle,
                ProcessAccessFlags.All, false,
                //DUPLICATE.DUPLICATE_SAME_ACCESS|
                DUPLICATE.DUPLICATE_CLOSE_SOURCE);

            if (newHandle != IntPtr.Zero)
                newHandle.Close();
            sProc.Release();
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_HANDLE_INFORMATION_EX
    {
        public ULONG_PTR NumberOfHandles;
        public ULONG_PTR Reserved;
        public SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX first;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX
    {
        public PVOID Object;
        public HANDLE UniqueProcessId;
        public HANDLE HandleValue;
        public ULONG GrantedAccess;
        public USHORT CreatorBackTraceIndex;
        public USHORT ObjectTypeIndex;
        public ULONG HandleAttributes;
        public ULONG Reserved;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct POOLED_USAGE_AND_LIMITS
    {
        public Int32 PeakPagedPoolUsage;
        public Int32 PagedPoolUsage;
        public Int32 PagedPoolLimit;
        public Int32 PeakNonPagedPoolUsage;
        public Int32 NonPagedPoolUsage;
        public Int32 NonPagedPoolLimit;
        public Int32 PeakPagefileUsage;
        public Int32 PagefileUsage;
        public Int32 PagefileLimit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LDT_ENTRY
    {
        public ushort LimitLow;
        public ushort BaseLow;
        public HIGHWORD HighWord;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_ACCESS_TOKEN
    {
        public SafeTokenHandle Token;
        public SafeThreadHandle Thread;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KERNEL_USER_TIMES
    {
        public LARGE_INTEGER CreateTime;
        public LARGE_INTEGER ExitTime;
        public LARGE_INTEGER KernelTime;
        public LARGE_INTEGER UserTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VM_COUNTERS
    {
        public ULONG PeakVirtualSize;
        public ULONG VirtualSize;
        public ULONG PageFaultCount;
        public ULONG PeakWorkingSetSize;
        public ULONG WorkingSetSize;
        public ULONG QuotaPeakPagedPoolUsage;
        public ULONG QuotaPagedPoolUsage;
        public ULONG QuotaPeakNonPagedPoolUsage;
        public ULONG QuotaNonPagedPoolUsage;
        public ULONG PagefileUsage;
        public ULONG PeakPagefileUsage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_COUNTERS
    {
        public ULONGLONG ReadOperationCount;
        public ULONGLONG WriteOperationCount;
        public ULONGLONG OtherOperationCount;
        public ULONGLONG ReadTransferCount;
        public ULONGLONG WriteTransferCount;
        public ULONGLONG OtherTransferCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct QUOTA_LIMITS
    {
        public SIZE_T PagedPoolLimit;
        public SIZE_T NonPagedPoolLimit;
        public SIZE_T MinimumWorkingSetSize;
        public SIZE_T MaximumWorkingSetSize;
        public SIZE_T PagefileLimit;
        public LARGE_INTEGER TimeLimit;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSOR_NUMBER
    {
        public WORD Group;
        public BYTE Number;
        public BYTE Reserved;
    }

    public struct SYSTEM_BASIC_INFORMATION
    {
        public ULONG Reserved;
        public ULONG TimerResolution;
        public ULONG PageSize;
        public ULONG NumberOfPhysicalPages;
        public ULONG LowestPhysicalPageNumber;
        public ULONG HighestPhysicalPageNumber;
        public ULONG AllocationGranularity;
        public ULONG_PTR MinimumUserModeAddress;
        public ULONG_PTR MaximumUserModeAddress;
        public ULONG_PTR ActiveProcessorsAffinityMask;
        public byte NumberOfProcessors;
    }

    public struct SYSTEM_PROCESSOR_INFORMATION
    {
        public ushort ProcessorArchitecture;
        public ushort ProcessorLevel;
        public ushort ProcessorRevision;
        public ushort Unknown;
        public uint FeatureBits;
    }

    public unsafe struct SYSTEM_PERFORMANCE_INFORMATION
    {
        public long IdleTime;
        public long ReadTransferCount;
        public long WriteTransferCount;
        public long OtherTransferCount;
        public uint ReadOperationCount;
        public uint WriteOperationCount;
        public uint OtherOperationCount;
        public uint AvailablePages;
        public uint TotalCommittedPages;
        public uint TotalCommitLimit;
        public uint PeakCommitment;
        public uint PageFaults;
        public uint WriteCopyFaults;
        public uint TransistionFaults;
        public uint Reserved1;
        public uint DemandZeroFaults;
        public uint PagesRead;
        public uint PageReadIos;
        public fixed uint Reserved2[2];
        public uint PagefilePagesWritten;
        public uint PagefilePageWriteIos;
        public uint MappedFilePagesWritten;
        public uint MappedFilePageWriteIos;
        public uint PagedPoolUsage;
        public uint NonPagedPoolUsage;
        public uint PagedPoolAllocs;
        public uint PagedPoolFrees;
        public uint NonPagedPoolAllocs;
        public uint NonPagedPoolFrees;
        public uint TotalFreeSystemPtes;
        public uint SystemCodePage;
        public uint TotalSystemDriverPages;
        public uint TotalSystemCodePages;
        public uint SmallNonPagedLookasideListAllocateHits;
        public uint SmallPagedLookasideListAllocateHits;
        public uint Reserved3;
        public uint MmSystemCachePage;
        public uint PagedPoolPage;
        public uint SystemDriverPage;
        public uint FastReadNoWait;
        public uint FastReadWait;
        public uint FastReadResourceMiss;
        public uint FastReadNotPossible;
        public uint FastMdlReadNoWait;
        public uint FastMdlReadWait;
        public uint FastMdlReadResourceMiss;
        public uint FastMdlReadNotPossible;
        public uint MapDataNoWait;
        public uint MapDataWait;
        public uint MapDataNoWaitMiss;
        public uint MapDataWaitMiss;
        public uint PinMappedDataCount;
        public uint PinReadNoWait;
        public uint PinReadWait;
        public uint PinReadNoWaitMiss;
        public uint PinReadWaitMiss;
        public uint CopyReadNoWait;
        public uint CopyReadWait;
        public uint CopyReadNoWaitMiss;
        public uint CopyReadWaitMiss;
        public uint MdlReadNoWait;
        public uint MdlReadWait;
        public uint MdlReadNoWaitMiss;
        public uint MdlReadWaitMiss;
        public uint ReadAheadIos;
        public uint LazyWriteIos;
        public uint LazyWritePages;
        public uint DataFlushes;
        public uint DataPages;
        public uint ContextSwitches;
        public uint FirstLevelTbFills;
        public uint SecondLevelTbFills;
        public uint SystemCalls;
    }

    public struct SYSTEM_TIME_OF_DAY_INFORMATION
    {
        public long BootTime;
        public long CurrentTime;
        public long TimeZoneBias;
        public uint CurrentTimeZoneId;
    }

    public struct SYSTEM_THREAD
    {
        public long KernelTime;
        public long UserTime;
        public long CreateTime;
        public ULONG WaitTime;
        public PVOID StartAddress;
        public CLIENT_ID ClientId;
        public uint Priority;
        public uint BasePriority;
        public ULONG ContextSwitchCount;
        public THREAD_STATE State;
        public KWAIT_REASON WaitReason;
    }

    public struct SYSTEM_THREAD_INFORMATION
    {
        public long KernelTime;
        public long UserTime;
        public long CreateTime;
        public uint WaitTime;
        public IntPtr StartAddress;
        public CLIENT_ID ClientId;
        public int Priority;
        public int BasePriority;
        public uint ContextSwitchCount;
        public ThreadState State;
        public KWaitReason WaitReason;
    }

    public unsafe struct SYSTEM_PROCESS_INFORMATION
    {
        /// <summary>
        /// if value > 0, there is next entry
        /// to get it use this sample 
        /// var info = (SYSTEM_PROCESS_INFORMATION*)((uint)current + NextEntryOffset)
        /// </summary>
        public ULONG NextEntryOffset;

        /// <summary>
        /// Number Of Threads
        /// to get the Info
        /// use (&Threads)[idx]
        /// </summary>
        public ULONG NumberOfThreads;

        public fixed ULONG Reserved1[6];
        public long CreateTime;
        public long UserTime;
        public long KernelTime;
        public UNICODE_STRING ProcessName;
        public LONG BasePriority;

        public ULONG ProcessId;
        public HANDLE UniqueProcessId;

        public ULONG HandleCount;
        public fixed ULONG Reserved2[2];
        public ULONG PeakVirtualSize;
        public ULONG VirtualSize;
        public ULONG PageFaultCount;
        public ULONG PeakWorkingSetSize;
        public ULONG WorkingSetSize;
        public ULONG QuotaPeakPagedPoolUsage;
        public ULONG QuotaPagedPoolUsage;
        public ULONG QuotaPeakNonPagedPoolUsage;
        public ULONG QuotaNonPagedPoolUsage;
        public ULONG PagefileUsage;
        public ULONG PeakPagefileUsage;
        public ULONG PrivatePageCount;
        public IO_COUNTERS IoCounters;

        public SYSTEM_THREAD_INFORMATION Threads;
    }

    public unsafe struct SYSTEM_CALL_COUNT_INFORMATION
    {
        public uint Size;
        public uint NumberOfDescriptorTables;
        public fixed uint NumberOfRoutinesInTable[1];
    }

    public struct SYSTEM_CONFIGURATION_INFORMATION
    {
        public uint DiskCount;
        public uint FloppyCount;
        public uint CdRomCount;
        public uint TapeCount;
        public uint SerialCount;
        public uint ParallelCount;
    }

    public struct SYSTEM_PROCESSOR_TIMES
    {
        public LARGE_INTEGER IdleTime;
        public LARGE_INTEGER KernelTime;
        public LARGE_INTEGER UserTime;
        public LARGE_INTEGER DpcTime;
        public LARGE_INTEGER InterruptTime;
        public ULONG InterruptCount;
    }

    public struct SYSTEM_GLOBAL_FLAG
    {
        public ULONG GlobalFlag;
    }

    public unsafe struct SYSTEM_MODULE_INFORMATION
    {
        public PVOID Ptr1, Ptr2;
        public PVOID Base;
        public uint Size;
        public uint Flags;
        public ushort Index;
        public ushort Unknown;
        public ushort LoadCount;
        public ushort ModuleNameOffset;
        public fixed byte imageName[256];

        public string ImageName
        {
            get
            {
                var arr = new byte[256 - 4];
                fixed (byte* ptr = imageName)
                fixed (byte* newPtr = &arr[0])
                {
                    msvcrt.memcpy((IntPtr)newPtr, (IntPtr)ptr + 4, 256);
                    var dwRes = Encoding.ASCII.GetString(arr);
                    return dwRes.Substring(0, dwRes.IndexOf("\0") + 1);
                }
            }
        }
    }

    public unsafe struct SYSTEM_LOCK_INFORMATION
    {
        public IntPtr Address;
        public ushort Type;
        public ushort Reserved1;
        public uint ExclusiveOwnerThreadId;
        public uint ActiveCount;
        public uint ContentionCount;
        public fixed uint Reserved2[2];
        public uint NumberOfSharedWaiters;
        public uint NumberOfExclusiveWaiters;
    }

    public struct SYSTEM_OBJECT_TYPE_INFORMATION
    {
        public uint NextEntryOffset;
        public uint ObjectCount;
        public uint HandleCount;
        public uint TypeNumber;
        public uint InvalidAttributes;
        public GENERIC_MAPPING GenericMapping;
        public ACCESS_MASK ValidAccessMask;
        public POOL_TYPE PoolType;
        public byte Unknown;
        public UNICODE_STRING Name;
    }

    public unsafe struct SYSTEM_OBJECT_INFORMATION
    {
        public ULONG NextEntryOffset;
        public PVOID Object;
        public ULONG CreatorProcessId;
        public USHORT Unknown;
        public USHORT Flags;
        public ULONG PointerCount;
        public ULONG HandleCount;
        public ULONG PagedPoolUsage;
        public ULONG NonPagedPoolUsage;
        public ULONG ExclusiveProcessId;
        public SECURITY_DESCRIPTOR* SecurityDescriptor;
        public UNICODE_STRING Name;
    }

    public struct SYSTEM_PAGEFILE_INFORMATION
    {
        public uint NextEntryOffset;
        public uint CurrentSize;
        public uint TotalUsed;
        public uint PeakUsed;
        public UNICODE_STRING FileName;
    }

    public struct SYSTEM_INSTRUCTION_EMULATION_INFORMATION
    {
        public ULONG SegmentNotPresent;
        public ULONG TwoByteOpcode;
        public ULONG ESprefix;
        public ULONG CSprefix;
        public ULONG SSprefix;
        public ULONG DSprefix;
        public ULONG FSPrefix;
        public ULONG GSprefix;
        public ULONG OPER32prefix;
        public ULONG ADDR32prefix;
        public ULONG INSB;
        public ULONG INSW;
        public ULONG OUTSB;
        public ULONG OUTSW;
        public ULONG PUSHFD;
        public ULONG POPFD;
        public ULONG INTnn;
        public ULONG INTO;
        public ULONG IRETD;
        public ULONG INBimm;
        public ULONG INWimm;
        public ULONG OUTBimm;
        public ULONG OUTWimm;
        public ULONG INB;
        public ULONG INW;
        public ULONG OUTB;
        public ULONG OUTW;
        public ULONG LOCKprefix;
        public ULONG REPNEprefix;
        public ULONG REPprefix;
        public ULONG HLT;
        public ULONG CLI;
        public ULONG STI;
        public ULONG GenericInvalidOpcode;
    }

    public unsafe struct SYSTEM_CACHE_INFORMATION
    {
        public uint SystemCacheWsSize;
        public uint SystemCacheWsPeakSize;
        public uint SystemCacheWsFaults;
        public uint SystemCacheWsMinimum;
        public uint SystemCacheWsMaximum;
        public uint TransitionSharedPages;
        public uint TransitionSharedPagesPeak;
        public fixed uint Reserved[2];
    }

    public unsafe struct SYSTEM_POOL_TAG_INFORMATION
    {
        public fixed byte Tag[4];
        public uint PagedPoolAllocs;
        public uint PagedPoolFrees;
        public uint PagedPoolUsage;
        public uint NonPagedPoolAllocs;
        public uint NonPagedPoolFrees;
        public uint NonPagedPoolUsage;
    }

    public struct SYSTEM_PROCESSOR_STATISTICS
    {
        public uint ContextSwitches;
        public uint DpcCount;
        public uint DpcRequestRate;
        public uint TimeIncrement;
        public uint DpcBypassCount;
        public uint ApcBypassCount;
    }

    public struct SYSTEM_DPC_INFORMATION
    {
        public uint Reserved;
        public uint MaximumDpcQueueDepth;
        public uint MinimumDpcRate;
        public uint AdjustDpcThreshold;
        public uint IdealDpcRate;
    }

    public struct SYSTEM_LOAD_IMAGE
    {
        public UNICODE_STRING ModuleName;
        public PVOID ModuleBase;
        public PVOID Unknown;
        public PVOID EntryPoint;
        public PVOID ExportDirectory;
    }

    public struct SYSTEM_UNLOAD_IMAGE
    {
        public IntPtr ModuleBase;
    } 
    #endregion

    #region TOKEN
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_APPCONTAINER_INFORMATION
    {
        public SafeSidHandle TokenAppContainer;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(TOKEN_APPCONTAINER_INFORMATION)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_MANDATORY_POLICY
    {
        public DWORD Policy;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(TOKEN_MANDATORY_POLICY)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_MANDATORY_LABEL
    {
        public SID_AND_ATTRIBUTES Label;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(TOKEN_MANDATORY_LABEL)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SID_AND_ATTRIBUTES_HASH
    {
        private const int SID_HASH_SIZE = 32;
        public DWORD SidCount;
        public SID_AND_ATTRIBUTES* SidAttr;
        public IntPtr Hash;
        //public SID_HASH_ENTRY Hash[SID_HASH_SIZE];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_ELEVATION
    {
        public DWORD TokenIsElevated;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_ORIGIN
    {
        public LUID OriginatingLogonSession;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_OWNER
    {
        public SafeSidHandle Owner;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_LINKED_TOKEN
    {
        public HANDLE LinkedToken;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_PRIMARY_GROUP
    {
        public SafeSidHandle PrimaryGroup;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TOKEN_SOURCE
    {
        private const int TOKEN_SOURCE_LENGTH = 8;
        public fixed CHAR SourceName[TOKEN_SOURCE_LENGTH];
        public LUID SourceIdentifier;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TOKEN_DEFAULT_DACL
    {
        public ACL* DefaultDacl;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_USER
    {
        public SID_AND_ATTRIBUTES User;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_STATISTICS
    {
        public LUID TokenId;
        public LUID AuthenticationId;
        public LARGE_INTEGER ExpirationTime;
        public TOKEN_TYPE TokenType;
        public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
        public DWORD DynamicCharged;
        public DWORD DynamicAvailable;
        public DWORD GroupCount;
        public DWORD PrivilegeCount;
        public LUID ModifiedId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SID_AND_ATTRIBUTES
    {
        public SafeSidHandle Sid;
        public DWORD Attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LUID
    {
        public uint LowPart;
        public int HighPart;

        public static bool fromString(string prev, ref LUID_AND_ATTRIBUTES attribute)
        {
            return advapi32.LookupPrivilegeValue(
                null, prev, out attribute.Luid);
        }

        public static bool fromString(string prev, ref LUID luid)
        {
            return advapi32.LookupPrivilegeValue(
                null, prev, out luid);
        }

        public override string ToString()
        {
            uint toRead = 0;
            var luid = this;
            var builder = new StringBuilder((int)toRead);
            advapi32.LookupPrivilegeName(String.Empty, ref luid, builder, out toRead);

            if (toRead > 0)
            {
                builder.EnsureCapacity((int)toRead);
                advapi32.LookupPrivilegeName(String.Empty, ref luid, builder, out toRead);
                return builder.ToString();
            }
            return null;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LUID_AND_ATTRIBUTES
    {
        public LUID Luid;
        public PrivilegeState Attributes;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(LUID_AND_ATTRIBUTES)); }
        }
    }
    #endregion

    #region SESSION_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct SESSION_INFO
    {
        [FieldOffset(0)]
        public SESSION_INFO_0 Info0;

        [FieldOffset(0)]
        public SESSION_INFO_1 Info1;

        [FieldOffset(0)]
        public SESSION_INFO_2 Info2;

        [FieldOffset(0)]
        public SESSION_INFO_10 Info10;

        [FieldOffset(0)]
        public SESSION_INFO_502 Info502;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(SESSION_INFO)); }
        }

        public static SESSION_INFO* Instance()
        {
            return (SESSION_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SESSION_INFO_0
    {
        public IntPtr cname;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SESSION_INFO_1
    {
        public IntPtr cname;

        public IntPtr username;
        public DWORD num_opens;
        public DWORD time;
        public DWORD idle_time;
        public SESS user_flags;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SESSION_INFO_2
    {
        public IntPtr cname;

        public IntPtr username;
        public DWORD num_opens;
        public DWORD time;
        public DWORD idle_time;
        public SESS user_flags;

        public IntPtr cltype_name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SESSION_INFO_10
    {
        public IntPtr cname;
        public IntPtr username;
        public DWORD time;
        public DWORD idle_time;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SESSION_INFO_502
    {
        public IntPtr cname;
        public IntPtr username;
        public DWORD num_opens;
        public DWORD time;
        public DWORD idle_time;
        public SESS user_flags;
        public IntPtr cltype_name;
        public IntPtr transport;
    } 
    #endregion

    #region FILE_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct FILE_INFO
    {
        [FieldOffset(0)]
        public FILE_INFO_2 Info2;

        [FieldOffset(0)]
        public FILE_INFO_3 Info3;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(FILE_INFO)); }
        }

        public static FILE_INFO* Instance()
        {
            return (FILE_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_INFO_2
    {
        public DWORD id;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_INFO_3
    {
        public DWORD id;

        public Permissions2 permissions;
        public DWORD num_locks;
        public IntPtr pathname;
        public IntPtr username;
    } 
    #endregion

    #region SHARE_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct SHARE_INFO
    {
        [FieldOffset(0)]
        public SHARE_INFO_0 Info0;

        [FieldOffset(0)]
        public SHARE_INFO_1 Info1;

        [FieldOffset(0)]
        public SHARE_INFO_2 Info2;

        [FieldOffset(0)]
        public SHARE_INFO_501 Info501;

        [FieldOffset(0)]
        public SHARE_INFO_502 Info502;

        [FieldOffset(0)]
        public SHARE_INFO_503 Info503;

        [FieldOffset(0)]
        public SHARE_INFO_1004 Info1004;

        [FieldOffset(0)]
        public SHARE_INFO_1005 Info1005;

        [FieldOffset(0)]
        public SHARE_INFO_1006 Info1006;

        [FieldOffset(0)]
        public SHARE_INFO_1501 Info1501;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(SHARE_INFO)); }
        }

        public static SHARE_INFO* Instance()
        {
            return (SHARE_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_0
    {
        public IntPtr netname;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_1
    {
        public IntPtr netname;

        public DeviceType type;
        public IntPtr remark;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_2
    {
        public IntPtr netname;

        public DeviceType type;
        public IntPtr remark;

        public Permissions permissions;
        public DWORD max_uses;
        public DWORD current_uses;
        public IntPtr path;
        public IntPtr passwd;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_501
    {
        public IntPtr netname;
        public DeviceType type;
        public IntPtr remark;

        public DWORD flags;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct SHARE_INFO_502
    {
        public IntPtr netname;
        public DeviceType type;
        public IntPtr remark;

        public Permissions permissions;
        public DWORD max_uses;
        public DWORD current_uses;
        public IntPtr path;
        public IntPtr passwd;
        public DWORD reserved;
        public SafeSecurityDescriptorHandle security_descriptor;

    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_503
    {
        public IntPtr netname;
        public DeviceType type;
        public IntPtr remark;

        public Permissions permissions;
        public DWORD max_uses;
        public DWORD current_uses;
        public IntPtr path;
        public IntPtr passwd;
        public IntPtr servername;
        public DWORD reserved;
        public SafeSecurityDescriptorHandle security_descriptor;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_1004
    {
        public IntPtr remark;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_1005
    {
        public SHI1005 flags;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_1006
    {
        public DWORD max_uses;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARE_INFO_1501
    {
        public DWORD reserved;
        public SafeSecurityDescriptorHandle security_descriptor;
    } 
    #endregion

    #region CONNECTION_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct CONNECTION_INFO
    {
        [FieldOffset(0)]
        public CONNECTION_INFO_0 Info0;

        [FieldOffset(0)]
        public CONNECTION_INFO_1 Info1;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(CONNECTION_INFO)); }
        }

        public static CONNECTION_INFO* Instance()
        {
            return (CONNECTION_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONNECTION_INFO_0
    {
        public DWORD id;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CONNECTION_INFO_1
    {
        public DWORD id;

        public DeviceType type;
        public DWORD num_opens;
        public DWORD num_users;
        public DWORD time;
        public IntPtr username;
        public IntPtr netname;
    } 
    #endregion

    #region USE_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct USE_INFO
    {
        [FieldOffset(0)]
        public USE_INFO_0 Info0;

        [FieldOffset(0)]
        public USE_INFO_1 Info1;

        [FieldOffset(0)]
        public USE_INFO_2 Info2;

        [FieldOffset(0)]
        public USE_INFO_3 Info3;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(USE_INFO)); }
        }

        public static USE_INFO* Instance()
        {
            return (USE_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USE_INFO_0
    {
        public IntPtr local;
        public IntPtr remote;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USE_INFO_1
    {
        public IntPtr local;
        public IntPtr remote;

        public IntPtr password;
        public ConnectionStatus status;
        public ResourceType asg_type;
        public DWORD refcount;
        public DWORD usecount;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USE_INFO_2
    {
        public IntPtr local;
        public IntPtr remote;

        public IntPtr password;
        public ConnectionStatus status;
        public ResourceType asg_type;
        public DWORD refcount;
        public DWORD usecount;

        public IntPtr username;
        public IntPtr domainname;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USE_INFO_3
    {
        public IntPtr local;
        public IntPtr remote;

        public IntPtr password;
        public ConnectionStatus status;
        public ResourceType asg_type;
        public DWORD refcount;
        public DWORD usecount;

        public IntPtr username;
        public IntPtr domainname;

        public ConnectionCreate flags;
    } 
    #endregion

    #region USER_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct USER_INFO
    {
        [FieldOffset(0)]
        public USER_INFO_0 Info0;

        [FieldOffset(0)]
        public USER_INFO_1 Info1;

        [FieldOffset(0)]
        public USER_INFO_2 Info2;

        [FieldOffset(0)]
        public USER_INFO_3 Info3;

        [FieldOffset(0)]
        public USER_INFO_4 Info4;

        [FieldOffset(0)]
        public USER_INFO_10 Info10;

        [FieldOffset(0)]
        public USER_INFO_11 Info11;

        [FieldOffset(0)]
        public USER_INFO_20 Info20;

        [FieldOffset(0)]
        public USER_INFO_21 Info21;

        [FieldOffset(0)]
        public USER_INFO_22 Info22;

        [FieldOffset(0)]
        public USER_INFO_23 Info23;

        [FieldOffset(0)]
        public USER_INFO_1003 Info1003;

        [FieldOffset(0)]
        public USER_INFO_1005 Info1005;

        [FieldOffset(0)]
        public USER_INFO_1006 Info1006;

        [FieldOffset(0)]
        public USER_INFO_1007 Info1007;

        [FieldOffset(0)]
        public USER_INFO_1008 Info1008;

        [FieldOffset(0)]
        public USER_INFO_1009 Info1009;

        [FieldOffset(0)]
        public USER_INFO_1010 Info1010;

        [FieldOffset(0)]
        public USER_INFO_1011 Info1011;

        [FieldOffset(0)]
        public USER_INFO_1012 Info1012;

        [FieldOffset(0)]
        public USER_INFO_1014 Info1014;

        [FieldOffset(0)]
        public USER_INFO_1017 Info1017;

        [FieldOffset(0)]
        public USER_INFO_1020 Info1020;

        [FieldOffset(0)]
        public USER_INFO_1024 Info1024;

        [FieldOffset(0)]
        public USER_INFO_1051 Info1051;

        [FieldOffset(0)]
        public USER_INFO_1052 Info1052;

        [FieldOffset(0)]
        public USER_INFO_1053 Info1053;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(USER_INFO)); }
        }

        public static USER_INFO* Instance()
        {
            return (USER_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_0
    {
        public IntPtr name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1
    {
        public IntPtr name;

        public IntPtr password;
        public DWORD password_age;
        public UserPriv priv;
        public IntPtr home_dir;
        public IntPtr comment;
        public UserFlags flags;
        public IntPtr script_path;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_2
    {
        public IntPtr name;

        public IntPtr password;
        public DWORD password_age;
        public UserPriv priv;
        public IntPtr home_dir;
        public IntPtr comment;
        public UserFlags flags;
        public IntPtr script_path;

        public UserAuth auth_flags;
        public IntPtr full_name;
        public IntPtr usr_comment;
        public IntPtr parms;
        public IntPtr workstations;
        public DWORD last_logon;
        public DWORD last_logoff;
        public DWORD acct_expires;
        public DWORD max_storage;
        public DWORD units_per_week;
        public IntPtr logon_hours;
        public DWORD bad_pw_count;
        public DWORD num_logons;
        public IntPtr logon_server;
        public DWORD country_code;
        public DWORD code_page;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_3
    {
        public IntPtr name;

        public IntPtr password;
        public DWORD password_age;
        public UserPriv priv;
        public IntPtr home_dir;
        public IntPtr comment;
        public UserFlags flags;
        public IntPtr script_path;

        public UserAuth auth_flags;
        public IntPtr full_name;
        public IntPtr usr_comment;
        public IntPtr parms;
        public IntPtr workstations;
        public DWORD last_logon;
        public DWORD last_logoff;
        public DWORD acct_expires;
        public DWORD max_storage;
        public DWORD units_per_week;
        public IntPtr logon_hours;
        public DWORD bad_pw_count;
        public DWORD num_logons;
        public IntPtr logon_server;
        public DWORD country_code;
        public DWORD code_page;

        public DWORD user_id;
        public DWORD primary_group_id;
        public IntPtr profile;
        public IntPtr home_dir_drive;
        public DWORD password_expired;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_4
    {
        public IntPtr name;

        public IntPtr password;
        public DWORD password_age;
        public UserPriv priv;
        public IntPtr home_dir;
        public IntPtr comment;
        public UserFlags flags;
        public IntPtr script_path;

        public UserAuth auth_flags;
        public IntPtr full_name;
        public IntPtr usr_comment;
        public IntPtr parms;
        public IntPtr workstations;
        public DWORD last_logon;
        public DWORD last_logoff;
        public DWORD acct_expires;
        public DWORD max_storage;
        public DWORD units_per_week;
        public IntPtr logon_hours;
        public DWORD bad_pw_count;
        public DWORD num_logons;
        public IntPtr logon_server;
        public DWORD country_code;
        public DWORD code_page;

        public SafeSidHandle user_sid;
        public DWORD primary_group_id;
        public IntPtr profile;
        public IntPtr home_dir_drive;
        public DWORD password_expired;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_10
    {
        public IntPtr name;
        public IntPtr comment;
        public IntPtr usr_comment;
        public IntPtr full_name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_11
    {
        public IntPtr name;
        public IntPtr comment;
        public IntPtr usr_comment;
        public IntPtr full_name;

        public UserPriv priv;
        public UserAuth auth_flags;
        public DWORD password_age;
        public IntPtr home_dir;
        public IntPtr parms;
        public DWORD last_logon;
        public DWORD last_logoff;
        public DWORD bad_pw_count;
        public DWORD num_logons;
        public IntPtr logon_server;
        public DWORD country_code;
        public IntPtr workstations;
        public DWORD max_storage;
        public DWORD units_per_week;
        public IntPtr logon_hours;
        public DWORD code_page;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_20
    {
        public IntPtr name;
        public IntPtr full_name;
        public IntPtr comment;
        public UserFlags flags;
        public DWORD user_id;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct USER_INFO_21
    {
        public fixed BYTE usri21_password[16];
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct USER_INFO_22
    {
        public IntPtr name;
        public fixed BYTE password[16];
        public DWORD password_age;
        public UserPriv priv;
        public IntPtr home_dir;
        public IntPtr comment;
        public UserFlags flags;
        public IntPtr script_path;
        public DWORD auth_flags;
        public IntPtr full_name;
        public IntPtr usr_comment;
        public IntPtr parms;
        public IntPtr workstations;
        public DWORD last_logon;
        public DWORD last_logoff;
        public DWORD acct_expires;
        public DWORD max_storage;
        public DWORD units_per_week;
        public IntPtr logon_hours;
        public DWORD bad_pw_count;
        public DWORD num_logons;
        public IntPtr logon_server;
        public DWORD country_code;
        public DWORD code_page;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct USER_INFO_23
    {
        public IntPtr name;
        public IntPtr full_name;
        public IntPtr comment;
        public UserFlags flags;
        public SafeSidHandle user_sid;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1003
    {
        public IntPtr password;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1005
    {
        public UserPriv priv;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1006
    {
        public IntPtr home_dir;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1007
    {
        public IntPtr comment;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1008
    {
        public UserFlags flag;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1009
    {
        public IntPtr script_path;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1010
    {
        public UserAuth auth_flags;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1011
    {
        public IntPtr full_name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1012
    {
        public IntPtr usr_comment;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1014
    {
        public IntPtr workstations;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1017
    {
        public DWORD acct_expires;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1020
    {
        public DWORD units_per_week;
        public IntPtr logon_hours;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1024
    {
        public DWORD country_code;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1051
    {
        public DWORD primary_group_id;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1052
    {
        public IntPtr profile;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct USER_INFO_1053
    {
        public IntPtr home_dir_drive;
    } 
    #endregion

    #region LOCALGROUP_USERS_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct LOCALGROUP_USERS_INFO
    {
        [FieldOffset(0)]
        public LOCALGROUP_USERS_INFO_0 Info0;

        [FieldOffset(0)]
        public LOCALGROUP_USERS_INFO_1 Info1;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(LOCALGROUP_USERS_INFO)); }
        }

        public static LOCALGROUP_USERS_INFO* Instance()
        {
            return (LOCALGROUP_USERS_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_USERS_INFO_0
    {
        public IntPtr name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_USERS_INFO_1
    {
        public IntPtr name;
        public IntPtr comment;
    } 
    #endregion

    #region GLOBAL_GROUP_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct GLOBAL_GROUP_INFO
    {
        [FieldOffset(0)]
        public GLOBALGROUP_USERS_INFO_0 Info0;

        [FieldOffset(0)]
        public GLOBALGROUP_USERS_INFO_1 Info1;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(GLOBAL_GROUP_INFO)); }
        }

        public static GLOBAL_GROUP_INFO* Instance()
        {
            return (GLOBAL_GROUP_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GLOBALGROUP_USERS_INFO_0
    {
        public IntPtr name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GLOBALGROUP_USERS_INFO_1
    {
        public IntPtr name;
        public UserGroupAttributes attributes;
    } 
    #endregion

    #region LOCALGROUP_MEMBERS_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct LOCALGROUP_MEMBERS_INFO
    {
        [FieldOffset(0)]
        public LOCALGROUP_MEMBERS_INFO_0 Member0;

        [FieldOffset(0)]
        public LOCALGROUP_MEMBERS_INFO_1 Member1;

        [FieldOffset(0)]
        public LOCALGROUP_MEMBERS_INFO_2 Member2;

        [FieldOffset(0)]
        public LOCALGROUP_MEMBERS_INFO_3 Member3;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(LOCALGROUP_MEMBERS_INFO)); }
        }

        public static LOCALGROUP_MEMBERS_INFO* Instance()
        {
            return (LOCALGROUP_MEMBERS_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_MEMBERS_INFO_0
    {
        public SafeSidHandle sid;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_MEMBERS_INFO_1
    {
        public SafeSidHandle sid;
        public SidUsage sidusage;
        public IntPtr name;

        public string Name
        {
            get { return name.ToUnicodeStr(); }
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_MEMBERS_INFO_2
    {
        public SafeSidHandle sid;
        public SidUsage sidusage;
        public IntPtr domainandname;

        public string Domain
        {
            get { return domainandname.ToUnicodeStr(); }
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_MEMBERS_INFO_3
    {
        public IntPtr domainandname;

        public string Domain
        {
            get { return domainandname.ToUnicodeStr(); }
        }
    } 
    #endregion

    #region LOCALGROUP_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct LOCALGROUP_INFO
    {
        [FieldOffset(0)]
        public LOCALGROUP_INFO_0 Info0;

        [FieldOffset(0)]
        public LOCALGROUP_INFO_1 Info1;

        [FieldOffset(0)]
        public LOCALGROUP_INFO_1002 Info2;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(LOCALGROUP_INFO)); }
        }

        public static LOCALGROUP_INFO* Instance()
        {
            return (LOCALGROUP_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_INFO_0
    {
        public IntPtr name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_INFO_1
    {
        public IntPtr name;
        public IntPtr comment;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALGROUP_INFO_1002
    {
        public IntPtr comment;
    } 
    #endregion

    #region GROUP_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct GROUP_INFO
    {
        [FieldOffset(0)]
        public GROUP_INFO_0 Info0;

        [FieldOffset(0)]
        public GROUP_INFO_1 Info1;

        [FieldOffset(0)]
        public GROUP_INFO_2 Info2;

        [FieldOffset(0)]
        public GROUP_INFO_3 Info3;

        [FieldOffset(0)]
        public GROUP_INFO_1002 Info1002;

        [FieldOffset(0)]
        public GROUP_INFO_1005 Info1005;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(GROUP_INFO)); }
        }

        public static GROUP_INFO* Instance()
        {
            return (GROUP_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_INFO_0
    {
        public IntPtr name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_INFO_1
    {
        public IntPtr name;
        public IntPtr comment;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_INFO_2
    {
        public IntPtr name;
        public IntPtr comment;
        public DWORD group_id;
        public SE_GROUP attributes;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_INFO_3
    {
        public IntPtr name;
        public IntPtr comment;
        public SafeSidHandle group_sid;
        public SE_GROUP attributes;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_INFO_1002
    {
        public IntPtr comment;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_INFO_1005
    {
        public SE_GROUP attributes;
    } 
    #endregion

    #region GROUP_USERS_INFO
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct GROUP_USERS_INFO
    {
        [FieldOffset(0)]
        public GROUP_USERS_INFO_0 Info0;

        [FieldOffset(0)]
        public GROUP_USERS_INFO_1 Info1;


        public static int Size
        {
            get { return Marshal.SizeOf(typeof(GROUP_USERS_INFO)); }
        }

        public static GROUP_USERS_INFO* Instance()
        {
            return (GROUP_USERS_INFO*)Marshal.AllocHGlobal(Size);
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_USERS_INFO_0
    {
        public IntPtr name;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_USERS_INFO_1
    {
        public IntPtr name;
        public SE_GROUP attributes;
    } 
    #endregion

    #region ICON
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct GRPICONDIRENTRY
    {
        public byte bWidth;
        public byte bHeight;
        public byte bColorCount;
        public byte bReserved;
        public ushort wPlanes;
        public ushort wBitCount;
        public uint dwBytesInRes;
        public ushort nID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICONINFO
    {
        public BOOL fIcon;
        public DWORD xHotspot;
        public DWORD yHotspot;
        public SafeBitmapHandle hbmMask;
        public SafeBitmapHandle hbmColor;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICONINFOEX
    {
        public DWORD cbSize;
        public BOOL fIcon;
        public DWORD xHotspot;
        public DWORD yHotspot;
        public SafeBitmapHandle hbmMask;
        public SafeBitmapHandle hbmColor;
        public WORD wResID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public TCHAR[] szModName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public TCHAR[] szResName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICONDIR
    {
        public ushort idReserved;
        public ushort idType;
        public ushort idCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICONDIRENTRY
    {
        public byte bWidth;
        public byte bHeight;
        public byte bColorCount;
        public byte bReserved;
        public ushort wPlanes;
        public ushort wBitCount;
        public uint dwBytesInRes;
        public uint dwImageOffset;
    }
    #endregion

    #region BITMAP
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
    }
    #endregion

    #region SOCKET
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WSAData
    {
        public Int16 version;
        public Int16 highVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
        public String description;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public String systemStatus;

        public Int16 maxSockets;
        public Int16 maxUdpDg;
        public IntPtr vendorInfo;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct sockaddr
    {
        public AddressFamilies sa_family;
        public fixed char sa_data[14];

        public string Name
        {
            get
            {
                string result;
                fixed (char* str = sa_data)
                {
                    result = new string(str);
                }
                return result;
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct sockaddr_gen
    {
        //[FieldOffset(0)]
        //public sockaddr Address;

        //[FieldOffset(0)]
        //public sockaddr_in AddressIn;

        [FieldOffset(0)]
        public sockaddr_in6_old AddressIn6;
    }

    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct in_addr
    {
        [FieldOffset(0)]
        public byte s_b1;
        [FieldOffset(1)]
        public byte s_b2;
        [FieldOffset(2)]
        public byte s_b3;
        [FieldOffset(3)]
        public byte s_b4;

        [FieldOffset(0)]
        public ushort s_w1;
        [FieldOffset(2)]
        public ushort s_w2;

        [FieldOffset(0)]
        public uint s_addrres;

        public in_addr(byte b1, byte b2, byte b3, byte b4)
        {
            s_addrres = 0;
            s_w1 = s_w2 = 0;
            s_b1 = s_b2 = s_b3 = s_b4 = 0;

            s_b1 = b1;
            s_b2 = b2;
            s_b3 = b3;
            s_b4 = b4;
        }

        /// <summary>
        /// can be used for most tcp & ip code
        /// </summary>
        public uint s_addr
        {
            get { return s_addrres; }
        }

        /// <summary>
        /// host on imp
        /// </summary>
        public byte s_host
        {
            get { return s_b2; }
        }

        /// <summary>
        /// network
        /// </summary>
        public byte s_net
        {
            get { return s_b1; }
        }

        /// <summary>
        /// imp
        /// </summary>
        public ushort s_imp
        {
            get { return s_w2; }
        }

        /// <summary>
        /// imp #
        /// </summary>
        public byte s_impno
        {
            get { return s_b4; }
        }

        /// <summary>
        /// logical host
        /// </summary>
        public byte s_lh
        {
            get { return s_b3; }
        }

        public string Host
        {
            get
            {
                var reversedHost = new StringBuilder(256);
                var reversedPort = new StringBuilder(256);
                var sock = sockaddr_in.FromString(ToString());

                var data = new WSAData();
                ws2_32.WSAStartup(2, ref data);

                ws2_32.GetNameInfo(
                    ref sock, Marshal.SizeOf(sock),
                    reversedHost, (uint)reversedHost.Capacity,
                    reversedPort, (uint)reversedPort.Capacity,
                    NI.NI_NUMERICSCOPE);

                ws2_32.WSACleanup();
                return reversedHost.ToString();
            }
        }

        public static in_addr Instance
        {
            get { return new in_addr(); }
        }

        public static in_addr FromAddress(string cp)
        {
            return ws2_32.inet_addr(cp);
        }

        public override string ToString()
        {
            return ws2_32.inet_ntoa(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct sockaddr_in
    {
        public AddressFamilies sin_family;
        public ushort sin_port;
        public in_addr sin_addr;
        public fixed byte sin_zero[8];

        public string Host
        {
            get
            {
                var local = this;
                var length = (uint)256;
                var builder = new StringBuilder((int)length);

                var data = new WSAData();
                ws2_32.WSAStartup(2, ref data);
                ws2_32.WSAAddressToString(ref local, (uint)Marshal.SizeOf(local), IntPtr.Zero, builder,
                                                ref length);
                ws2_32.WSACleanup();

                return builder.ToString().Split(':')[0];
            }

        }

        public string Port
        {
            get
            {
                var local = this;
                var length = (uint)256;
                var builder = new StringBuilder((int)length);

                var data = new WSAData();
                ws2_32.WSAStartup(2, ref data);
                ws2_32.WSAAddressToString(ref local, (uint)Marshal.SizeOf(local), IntPtr.Zero, builder,
                                                ref length);
                ws2_32.WSACleanup();

                return builder.ToString().Split(':')[1];
            }

        }

        public static sockaddr_in FromString(string host, ushort port)
        {
            return FromString(host + ":" + port);
        }
        public static sockaddr_in FromString(string host)
        {
            var data = new WSAData();
            ws2_32.WSAStartup(2, ref data);
            var sockaddr = new sockaddr_in();
            var lpAddressLength = Marshal.SizeOf(sockaddr);
            var dwerr = ws2_32.WSAStringToAddress(
                host,
                AddressFamilies.INET,
                IntPtr.Zero,
                ref sockaddr,
                ref lpAddressLength);

            if (dwerr != 0)
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            ws2_32.WSACleanup();
            return sockaddr;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct in6_addr
    {
        [FieldOffset(0)]
        public byte Byte_0;
        [FieldOffset(1)]
        public byte Byte_1;
        [FieldOffset(2)]
        public byte Byte_2;
        [FieldOffset(3)]
        public byte Byte_3;

        [FieldOffset(4)]
        public byte Byte_4;
        [FieldOffset(5)]
        public byte Byte_5;
        [FieldOffset(6)]
        public byte Byte_6;
        [FieldOffset(7)]
        public byte Byte_7;

        [FieldOffset(8)]
        public byte Byte_8;
        [FieldOffset(9)]
        public byte Byte_9;
        [FieldOffset(10)]
        public byte Byte_10;
        [FieldOffset(11)]
        public byte Byte_11;

        [FieldOffset(12)]
        public byte Byte_12;
        [FieldOffset(13)]
        public byte Byte_13;
        [FieldOffset(14)]
        public byte Byte_14;
        [FieldOffset(15)]
        public byte Byte_16;

        [FieldOffset(0)]
        public short Word_0;
        [FieldOffset(2)]
        public short Word_1;
        [FieldOffset(4)]
        public short Word_2;
        [FieldOffset(6)]
        public short Word_3;

        [FieldOffset(8)]
        public short Word_4;
        [FieldOffset(10)]
        public short Word_5;
        [FieldOffset(12)]
        public short Word_6;
        [FieldOffset(14)]
        public short Word_7;

        public string Host
        {
            get
            {
                var reversedHost = new StringBuilder(256);
                var reversedPort = new StringBuilder(256);
                var sock = sockaddr_in6.FromString(ToString());

                var data = new WSAData();
                ws2_32.WSAStartup(2, ref data);

                ws2_32.GetNameInfo(
                    ref sock, Marshal.SizeOf(sock),
                    reversedHost, (uint)reversedHost.Capacity,
                    reversedPort, (uint)reversedPort.Capacity,
                    NI.NI_NUMERICSCOPE);

                ws2_32.WSACleanup();
                return reversedHost.ToString();
            }
        }

        public static in6_addr Instance
        {
            get { return new in6_addr(); }
        }

        public static in6_addr FromAddress(string cp)
        {
            var instance = Instance;
            ws2_32.inet_pton(AddressFamilies.INET6, cp, ref instance);
            return instance;
        }

        public override string ToString()
        {
            var pStringBuf = new StringBuilder(256);
            ws2_32.InetNtop(
                AddressFamilies.INET6, ref this, pStringBuf, 256);
            return pStringBuf.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IPV6_ADDRESS_EX
    {
        public ushort sin6_port;
        public uint sin6_flowinfo;
        public in6_addr sin6_addr;
        public uint sin6_scope_id;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct sockaddr_in6
    {
        [FieldOffset(0)]
        public AddressFamilies sin6_family;
        [FieldOffset(2)]
        public ushort sin6_port;
        [FieldOffset(4)]
        public uint sin6_flowinfo;
        [FieldOffset(8)]
        public in6_addr sin6_addr;
        [FieldOffset(24)]
        public uint sin6_scope_id;

        public string Host
        {
            get
            {
                var local = this;
                var length = (uint)256;
                var builder = new StringBuilder((int)length);

                var data = new WSAData();
                ws2_32.WSAStartup(2, ref data);
                ws2_32.WSAAddressToString(
                    ref local, (uint)Marshal.SizeOf(local), IntPtr.Zero, builder, ref length);
                ws2_32.WSACleanup();

                if (sin6_port <= 0)
                    return builder.ToString();

                var ipv6Address = builder.ToString();
                var idx = ipv6Address.LastIndexOf(':');
                return ipv6Address.Substring(1, idx - 2);
            }

        }

        public string Port
        {
            get
            {
                var local = this;
                var length = (uint)256;
                var builder = new StringBuilder((int)length);

                var data = new WSAData();
                ws2_32.WSAStartup(2, ref data);
                ws2_32.WSAAddressToString(ref local, (uint)Marshal.SizeOf(local), IntPtr.Zero, builder,
                                                ref length);
                ws2_32.WSACleanup();

                if (sin6_port <= 0)
                    return null;

                var ipv6Address = builder.ToString();
                var idx = ipv6Address.LastIndexOf(':');
                return ipv6Address.Substring(idx + 1);
            }

        }

        public static sockaddr_in6 FromString(string host, ushort port)
        {
            return FromString("[" + host + "]" + ":" + port);
        }
        public static sockaddr_in6 FromString(string host)
        {
            var data = new WSAData();
            ws2_32.WSAStartup(2, ref data);
            var sockaddr = new sockaddr_in6();
            var lpAddressLength = Marshal.SizeOf(sockaddr);
            var dwerr = ws2_32.WSAStringToAddress(
                host,
                AddressFamilies.INET6,
                IntPtr.Zero,
                ref sockaddr,
                ref lpAddressLength);

            if (dwerr != 0)
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
            ws2_32.WSACleanup();
            return sockaddr;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct sockaddr_in6_old
    {
        [FieldOffset(0)]
        public AddressFamilies sin6_family;

        [FieldOffset(2)]
        public ushort sin6_port;

        [FieldOffset(4)]
        public uint sin6_flowinfo;

        [FieldOffset(8)]
        public in6_addr sin6_addr;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SOCKADDR_IRDA
    {
        public ushort irdaAddressFamily;
        public fixed UCHAR irdaDeviceID[4];
        public fixed char irdaServiceName[25];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SOCKADDR_BTH
    {
        public ushort addressFamily;
        public ULONGLONG btAddr; 
        public GUID serviceClassId;
        public ULONG port;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SOCKADDR_INET
    {
        public sockaddr_in Ipv4;
        public sockaddr_in6 Ipv6;
        public AddressFamilies si_family;
    }
    #endregion

    #region CONSOLE
    [StructLayout(LayoutKind.Sequential)]
    public struct SMALL_RECT
    {
        public SHORT Left;
        public SHORT Top;
        public SHORT Right;
        public SHORT Bottom;

        public SMALL_RECT(short xI, short yI, short wI, short hI)
        {
            Left = xI;
            Top = yI;
            Right = (short)(Left + wI);
            Bottom = (short)(Top + hI);
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct CHAR_INFO
    {
        [FieldOffset(0)]
        public WCHAR UnicodeChar;
        [FieldOffset(0)]
        public CHAR AsciiChar;

        [FieldOffset(2)]
        public Enum.Attribute Attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONSOLE_CURSOR_INFO
    {
        public DWORD dwSize;
        public BOOL bVisible;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONSOLE_SCREEN_BUFFER_INFO
    {
        /// <summary>
        /// A COORD structure that contains the size of the console screen buffer, 
        /// in character columns and rows.
        /// </summary>
        public COORD dwSize;

        /// <summary>
        /// A COORD structure that contains the column and row coordinates 
        /// of the cursor in the console screen buffer.
        /// </summary>
        public COORD dwCursorPosition;

        /// <summary>
        /// The attributes of the characters written to a screen buffer by the WriteFile and WriteConsole functions, 
        /// or echoed to a screen buffer by the ReadFile and ReadConsole functions. 
        /// For more information, see Character Attributes.
        /// </summary>
        public Enum.Attribute wAttributes;

        /// <summary>
        /// A SMALL_RECT structure that contains the console screen buffer coordinates of the
        ///  upper-left and lower-right corners of the display window.
        /// </summary>
        public SMALL_RECT srWindow;

        /// <summary>
        /// A COORD structure that contains the maximum size of the console window, in character columns and rows,
        ///  given the current screen buffer size and font and the screen size.
        /// </summary>
        public COORD dwMaximumWindowSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CONSOLE_SCREEN_BUFFER_INFOEX
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public ULONG cbSize;

        /// <summary>
        /// A COORD structure that contains the size of the console screen buffer, 
        /// in character columns and rows.
        /// </summary>
        public COORD dwSize;

        /// <summary>
        /// A COORD structure that contains the column and row coordinates 
        /// of the cursor in the console screen buffer.
        /// </summary>
        public COORD dwCursorPosition;

        /// <summary>
        /// The attributes of the characters written to a screen buffer by the WriteFile and WriteConsole functions, 
        /// or echoed to a screen buffer by the ReadFile and ReadConsole functions. 
        /// For more information, see Character Attributes.
        /// </summary>
        public Enum.Attribute wAttributes;

        /// <summary>
        /// A SMALL_RECT structure that contains the console screen buffer coordinates of the
        ///  upper-left and lower-right corners of the display window.
        /// </summary>
        public SMALL_RECT srWindow;

        /// <summary>
        /// A COORD structure that contains the maximum size of the console window, in character columns and rows,
        ///  given the current screen buffer size and font and the screen size.
        /// </summary>
        public COORD dwMaximumWindowSize;

        /// <summary>
        /// The fill attribute for console pop-ups.
        /// </summary>
        public WORD wPopupAttributes;

        /// <summary>
        /// If this member is TRUE, full-screen mode is supported; otherwise, it is not.
        /// </summary>
        public BOOL bFullscreenSupported;

        /// <summary>
        /// An array of COLORREF values that describe the console's color settings.
        /// </summary>
        public fixed COLORREF ColorTable[16];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONSOLE_FONT_INFO
    {
        public DWORD nFont;
        public COORD dwFontSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CONSOLE_FONT_INFOEX
    {
        public ULONG cbSize;
        public DWORD nFont;
        public COORD dwFontSize;
        public FontPitchAndFamily FontFamily;
        public UINT FontWeight;
        public fixed WCHAR FaceName[32];
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CONSOLE_FONT
    {
        public DWORD index;
        public COORD dim;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONSOLE_HISTORY_INFO
    {
        public UINT cbSize;
        public UINT HistoryBufferSize;
        public UINT NumberOfHistoryBuffers;
        public DWORD dwFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONSOLE_SELECTION_INFO
    {
        public uint Flags;
        public COORD SelectionAnchor;
        public SMALL_RECT Selection;
    }
    #endregion

    #region Device
    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_HDR
    {
        public DWORD size;
        public DBT_DEVTYP devicetype;
        public DWORD reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_VOLUME
    {
        public DWORD size;
        public DBT_DEVTYP devicetype;
        public DWORD reserved;
        public DWORD unitmask;
        public WORD flags;

        /// <summary>
        /// Detecting USB Drive Removal in a C# Program
        /// http://www.codeproject.com/Articles/18062/Detecting-USB-Drive-Removal-in-a-C-Program
        /// 
        /// Gets drive letter from a bit mask where bit 0 = A, bit 1 = B etc.
        /// There can actually be more than one drive in the mask but we 
        /// just use the last one in this case.
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public char Letter
        {
            get
            {
                char letter;
                string drives = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                // 1 = A
                // 2 = B
                // 4 = C...
                int cnt = 0;
                uint pom = unitmask / 2;
                while (pom != 0)
                {
                    // while there is any bit set in the mask
                    // shift it to the righ...                
                    pom = pom / 2;
                    cnt++;
                }

                return cnt < drives.Length ? drives[cnt] : '?'; ;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct DEV_BROADCAST_PORT
    {
        public DWORD size;
        public DBT_DEVTYP devicetype;
        public DWORD reserved;
        public fixed char name[256];

        public string Name
        {
            get
            {
                fixed (char* wcahrPtr = name)
                    return new string(wcahrPtr);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DEV_BROADCAST_OEM
    {
        public DWORD size;
        public DBT_DEVTYP devicetype;
        public DWORD reserved;
        public DWORD identifier;
        public DWORD suppfunc;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct DEV_BROADCAST_DEVICEINTERFACE
    {
        public DWORD size;
        public DBT_DEVTYP devicetype;
        public DWORD reserved;
        public GUID classguid;
        public fixed char name[256];

        public string Name
        {
            get
            {
                fixed (char* wcahrPtr =  name)
                    return new string(wcahrPtr);
            }
        }

        /// <summary>
        /// nice wrapper found on ..........
        /// http://stackoverflow.com/questions/2208722/how-to-get-friendly-device-name-from-dev-broadcast-deviceinterface-and-device-in
        /// </summary>
        public string RegistryKey
        {
            get
            {
                var Parts = Name.Split('#');
                if (Parts.Length >= 3)
                {
                    var DevType = Parts[0].Substring(Parts[0].IndexOf(@"?\") + 2);
                    var DeviceInstanceId = Parts[1];
                    var DeviceUniqueID = Parts[2];
                    var RegPath = @"SYSTEM\CurrentControlSet\Enum\" + DevType + "\\" + DeviceInstanceId + "\\" + DeviceUniqueID;
                    return RegPath;
                }
                return String.Empty;
            }
        } 
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEV_BROADCAST_HANDLE
    {
        public DWORD size;
        public DBT_DEVTYP devicetype;
        public DWORD reserved;
        public HANDLE handle;
        // handle from RegisterDeviceNotification
        public IntPtr hdevnotify;
        public GUID eventguid;
        public LONG nameoffset;
        public fixed BYTE data[1024];
    }
    #endregion

    #region WLAN
    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_BSS_LIST
    {
        public DWORD dwTotalSize;
        public DWORD dwNumberOfItems;
        public WLAN_BSS_ENTRY First;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_RATE_SET
    {
        public ULONG uRateSetLength;
        public fixed USHORT usRateSet[126];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_BSS_ENTRY
    {
        public DOT11_SSID dot11Ssid;
        public ULONG uPhyId;
        public fixed byte dot11Bssid[6];
        public DOT11_BSS_TYPE dot11BssType;
        public DOT11_PHY_TYPE dot11BssPhyType;
        public LONG lRssi;
        public ULONG uLinkQuality;
        public BOOLEAN bInRegDomain;
        public USHORT usBeaconPeriod;
        public ULONGLONG ullTimestamp;
        public ULONGLONG ullHostTimestamp;
        public USHORT usCapabilityInformation;
        public ULONG ulChCenterFrequency;
        public WLAN_RATE_SET wlanRateSet;
        public ULONG ulIeOffset;
        public ULONG ulIeSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DOT11_BSSID_LIST
    {
        public NDIS_OBJECT_HEADER Header;
        public ULONG uNumOfEntries;
        public ULONG uTotalNumOfEntries;
        public fixed byte BSSIDs[6];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NDIS_OBJECT_HEADER
    {
        public UCHAR Type;
        public UCHAR Revision;
        public USHORT Size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DOT11_SSID
    {
        public ULONG uSSIDLength;
        public fixed UCHAR ucSSID[32];

        public string Hex
        {
            get
            {
                var ret = ToString();
                var builder = new StringBuilder();
                foreach (var code in ToString())
                    builder.Append(((byte)code).ToString("X2"));
                return builder.ToString();
            }
        }

        public override string ToString()
        {
            fixed (byte* charPtr = ucSSID)
            {
                var charPtrNew = new byte[uSSIDLength];
                for (var i = 0; i < uSSIDLength; i++)
                    charPtrNew[i] = charPtr[i];
                return Encoding.ASCII.GetString(charPtrNew);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_RAW_DATA
    {
        public uint dwDataSize;
        public fixed BYTE DataBlob[1];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_INTERFACE_CAPABILITY
    {
        public WLAN_INTERFACE_TYPE interfaceType;
        public BOOL bDot11DSupported;
        public DWORD dwMaxDesiredSsidListSize;
        public DWORD dwMaxDesiredBssidListSize;
        public DWORD dwNumberOfSupportedPhys;
        public fixed uint dot11PhyTypes[64]; // DOT11_PHY_TYPE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_INTERFACE_INFO_LIST
    {
        public DWORD dwNumberOfItems;
        public DWORD dwIndex;
        public WLAN_INTERFACE_INFO First;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_AVAILABLE_NETWORK_LIST
    {
        public DWORD dwNumberOfItems;
        public DWORD dwIndex;
        public WLAN_AVAILABLE_NETWORK First;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_INTERFACE_INFO
    {
        public GUID InterfaceGuid;
        public fixed WCHAR strInterfaceDescription[256];
        public WLAN_INTERFACE_STATE isState;

        public string InterfaceDescription
        {
            get
            {
                fixed (WCHAR* wcahrPtr = strInterfaceDescription)
                    return new string(wcahrPtr);
            }
        }

        public byte[] PhysicalAddress
        {
            get
            {
                uint sizePointer = 0;
                var adapterAddresses = (IP_ADAPTER_ADDRESSES*)0;
                Iphlpapi.GetAdaptersAddresses(
                    AddressFamilyInt.INET,
                    AdaptersFlags.SKIP_DNS_SERVER,
                    IntPtr.Zero,
                    adapterAddresses,
                    ref sizePointer);

                adapterAddresses = (IP_ADAPTER_ADDRESSES*)msvcrt.malloc(sizePointer);
                Iphlpapi.GetAdaptersAddresses(
                    AddressFamilyInt.INET,
                    AdaptersFlags.SKIP_DNS_SERVER,
                    IntPtr.Zero,
                    adapterAddresses,
                    ref sizePointer);

                var physicalAddress = new byte[6];
                do
                {
                    if (adapterAddresses->Description != InterfaceDescription)
                    {
                        adapterAddresses = adapterAddresses->next;
                        continue;
                    }

                    for (var i = 0; i < 6; i++)
                    {
                        physicalAddress[i] =
                            adapterAddresses->PhysicalAddress[i];
                    }

                    break;
                } while ((int)adapterAddresses != 0);

                msvcrt.free((IntPtr)adapterAddresses);
                return physicalAddress;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_AVAILABLE_NETWORK
    {
        public fixed WCHAR strProfileName[256];
        public DOT11_SSID dot11Ssid;
        public DOT11_BSS_TYPE dot11BssType;
        public ULONG uNumberOfBssids;
        public BOOL bNetworkConnectable;
        // WLAN_REASON_CODE
        public uint wlanNotConnectableReason;
        public ULONG uNumberOfPhyTypes;
        // DOT11_PHY_TYPE Array
        public fixed int dot11PhyTypes[8];
        public BOOL bMorePhyTypes;
        // WLAN_SIGNAL_QUALITY 
        public ULONG wlanSignalQuality;
        public BOOL bSecurityEnabled;
        public DOT11_AUTH_ALGORITHM dot11DefaultAuthAlgorithm;
        public DOT11_CIPHER_ALGORITHM dot11DefaultCipherAlgorithm;
        public DWORD dwFlags;
        public DWORD dwReserved;

        public ULONG SignalQuality
        {
            get { return wlanSignalQuality; }
        }

        public DOT11_AUTH_ALGORITHM AuthAlgorithm
        {
            get { return dot11DefaultAuthAlgorithm; }
        }

        public DOT11_CIPHER_ALGORITHM CipherAlgorithm
        {
            get { return dot11DefaultCipherAlgorithm; }
        }

        public string ProfileName
        {
            get
            {
                fixed (WCHAR* wcahrPtr = strProfileName)
                    return new string(wcahrPtr);
            }
        }

        public override string ToString()
        {
            return dot11Ssid.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_CONNECTION_PARAMETERS
    {
        public WLAN_CONNECTION_MODE wlanConnectionMode;
        [MarshalAs(UnmanagedType.LPWStr)]
        public String strProfile;
        public DOT11_SSID* pDot11Ssid;
        public DOT11_BSSID_LIST* pDesiredBssidList;
        public DOT11_BSS_TYPE dot11BssType;
        public WLAN_CONNECTION dwFlags;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct WLAN_NOTIFICATION_DATA
    {
        [FieldOffset(0)]
        public WLAN_NOTIFICATION_SOURCE NotificationSource;

        [FieldOffset(4)]
        public DWORD NotificationCode;

        [FieldOffset(4)]
        public WLAN_NOTIFICATION_ACM NotificationAcmCode;

        [FieldOffset(4)]
        public WLAN_NOTIFICATION_MSM NotificationMsmCode;

        [FieldOffset(4)]
        public WLAN_HOSTED_NETWORK_NOTIFICATION HostedNetworkNotificationCode;

        [FieldOffset(4)]
        public ONEX_NOTIFICATION_TYPE OnexNotificationTypeCode;

        [FieldOffset(8)]
        public GUID InterfaceGuid;

        [FieldOffset(24)]
        public DWORD dwDataSize;

        [FieldOffset(28)]
        public PVOID pData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WLAN_PROFILE_INFO_LIST
    {
        public DWORD dwNumberOfItems;
        public DWORD dwIndex;
        public WLAN_PROFILE_INFO First;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WLAN_PROFILE_INFO
    {
        public fixed WCHAR strProfileName[256];
        public DWORD dwFlags;

        public string ProfileName
        {
            get
            {
                fixed (char* profile = strProfileName)
                    return new string(profile);
            }
        }
    }

    public struct WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE
    {
        public uint OldState;
        public uint NewState;
        public uint Reason;
    }

    public struct WLAN_HOSTED_NETWORK_RADIO_STATE
    {
        public DOT11_RADIO_STATE dot11SoftwareRadioState;
        public DOT11_RADIO_STATE dot11HardwareRadioState;
    }

    public struct WLAN_HOSTED_NETWORK_STATE_CHANGE
    {
        public uint OldState;
        public uint NewState;
        public uint Reason;
    }

    public struct WLAN_PHY_RADIO_STATE
    {
        public DWORD dwPhyIndex;
        public DOT11_RADIO_STATE dot11SoftwareRadioState;
        public DOT11_RADIO_STATE dot11HardwareRadioState;
    }

    public unsafe struct WLAN_CONNECTION_NOTIFICATION_DATA
    {
        public WLAN_CONNECTION_MODE wlanConnectionMode;
        public fixed WCHAR strProfileName[256];
        public DOT11_SSID dot11Ssid;
        public DOT11_BSS_TYPE dot11BssType;
        public BOOL bSecurityEnabled;
        public uint wlanReasonCode;
        public DWORD dwFlags;
        public fixed WCHAR strProfileXml[1];

        public string ProfileName
        {
            get
            {
                fixed (char* profile = strProfileName)
                    return new string(profile);
            }
        }

        public string ProfileXml
        {
            get
            {
                fixed (char* profile = strProfileXml)
                    return new string(profile);
            }
        }
    }

    public unsafe struct WLAN_MSM_NOTIFICATION_DATA
    {
        public WLAN_CONNECTION_MODE wlanConnectionMode;
        public fixed WCHAR strProfileName[256];
        public DOT11_SSID dot11Ssid;
        public DOT11_BSS_TYPE dot11BssType;
        public fixed byte dot11MacAddr[6];
        public BOOL bSecurityEnabled;
        public BOOL bFirstPeer;
        public BOOL bLastPeer;
        public DWORD wlanReasonCode;

        public string ProfileName
        {
            get
            {
                fixed (char* profile = strProfileName)
                    return new string(profile);
            }
        }
    }
    #endregion

    #region IP
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_DNS_SUFFIX
    {
        public IP_ADAPTER_DNS_SUFFIX* Next;
        public fixed WCHAR WCHAR[256];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_PREFIX
    {
        public ULONG Length;
        public DWORD Flags;

        public IP_ADAPTER_PREFIX* Next;
        public SOCKET_ADDRESS Address;
        public ULONG PrefixLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IP_INTERFACE_INFO
    {
        public LONG NumAdapters;
        public IP_ADAPTER_INDEX_MAP First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(IP_INTERFACE_INFO)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_PER_ADAPTER_INFO
    {
        public UINT AutoconfigEnabled;
        public UINT AutoconfigActive;
        public IP_ADDR_STRING* CurrentDnsServer;
        public IP_ADDR_STRING DnsServerList;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_INFO
    {
        public IP_ADAPTER_INFO* next;
        public DWORD ComboIndex;
        public fixed byte adapterName[260];
        public fixed byte description[132];
        public UINT AddressLength;
        public fixed BYTE Address[8];
        public DWORD Index;
        public MIB Type;
        public UINT DhcpEnabled;
        public IP_ADDR_STRING* CurrentIpAddress;
        public IP_ADDR_STRING IpAddressList;
        public IP_ADDR_STRING GatewayList;
        public IP_ADDR_STRING DhcpServer;
        public uint HaveWins; // BOOL
        public IP_ADDR_STRING PrimaryWinsServer;
        public IP_ADDR_STRING SecondaryWinsServer;
        public time_t LeaseObtained;
        public time_t LeaseExpires;

        public string AdapterName
        {
            get
            {
                fixed (byte* someData = adapterName)
                {
                    return ((IntPtr)someData).ToAnsiStr();
                }
            }
        }

        public string Description
        {
            get
            {
                fixed (byte* someData = description)
                {
                    return ((IntPtr)someData).ToAnsiStr();
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct SOCKET_ADDRESS
    {
        [FieldOffset(0)]
        public sockaddr_in* lpSockaddrIn;

        [FieldOffset(0)]
        public sockaddr_in6* lpSockaddrIn6;

        [FieldOffset(4)]
        public INT iSockaddrLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_UNICAST_ADDRESS
    {
        public ULONG Length;
        public DWORD Flags;

        public IP_ADAPTER_UNICAST_ADDRESS* Next;
        public SOCKET_ADDRESS Address;
        public NlPrefixOrigin PrefixOrigin;
        public NL_SUFFIX_ORIGIN SuffixOrigin;
        public NL_DAD_STATE DadState;
        public ULONG ValidLifetime;
        public ULONG PreferredLifetime;
        public ULONG LeaseLifetime;
        public UINT8 OnLinkPrefixLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_ANYCAST_ADDRESS
    {
        public ULONG Length;
        public DWORD Flags;

        public IP_ADAPTER_ANYCAST_ADDRESS* Next;
        public SOCKET_ADDRESS Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_ADDRESSES
    {
        public ULONG Length, IfIndex;
        public IP_ADAPTER_ADDRESSES* next;
        public char* adapterName;
        public IP_ADAPTER_UNICAST_ADDRESS* FirstUnicastAddress;
        public IP_ADAPTER_ANYCAST_ADDRESS* FirstAnycastAddress;
        public IP_ADAPTER_MULTICAST_ADDRESS* FirstMulticastAddress;
        public IP_ADAPTER_DNS_SERVER_ADDRESS* FirstDnsServerAddress;
        public char* dnsSuffix;
        public char* description;
        public char* friendlyName;

        public fixed BYTE PhysicalAddress[8];
        public DWORD PhysicalAddressLength;
        public IPAdapterFlags Flags;
        public DWORD Mtu;
        public IF_TYPE IfType;
        public IF_OPER_STATUS OperStatus;
        public DWORD Ipv6IfIndex;
        public fixed DWORD ZoneIndices[16];
        public IP_ADAPTER_PREFIX* FirstPrefix;
        public ULONG64 TransmitLinkSpeed;
        public ULONG64 ReceiveLinkSpeed;
        public IP_ADAPTER_WINS_SERVER_ADDRESS* FirstWinsServerAddress;
        public IP_ADAPTER_GATEWAY_ADDRESS* FirstGatewayAddress;
        public ULONG Ipv4Metric;
        public ULONG Ipv6Metric;
        public IF_LUID Luid;
        public SOCKET_ADDRESS Dhcpv4Server;
        public UInt32 CompartmentId;
        public GUID NetworkGuid;
        public NET_IF_CONNECTION_TYPE ConnectionType;
        public TUNNEL_TYPE TunnelType;
        public SOCKET_ADDRESS Dhcpv6Server;
        public fixed BYTE Dhcpv6ClientDuid[130];
        public ULONG Dhcpv6ClientDuidLength;
        public ULONG Dhcpv6Iaid;
        public IP_ADAPTER_DNS_SUFFIX* FirstDnsSuffix;

        public string AdapterName
        {
            get { return ((IntPtr)adapterName).ToAnsiStr(); }
        }

        public string DnsSuffix
        {
            get { return ((IntPtr)dnsSuffix).ToUnicodeStr(); }
        }

        public string Description
        {
            get { return ((IntPtr)description).ToUnicodeStr(); }
        }

        public string FriendlyName
        {
            get { return ((IntPtr)friendlyName).ToUnicodeStr(); }
        }

        public Dictionary<object, string> Addresses
        {
            get
            {
                var dic = new Dictionary<object, string>();
                if ((int)FirstAnycastAddress != 0)
                    dic.Add("Anycast", FirstAnycastAddress->Address.lpSockaddrIn->Host);
                if ((int)FirstDnsServerAddress != 0)
                    dic.Add("DnsServer", FirstDnsServerAddress->Address.lpSockaddrIn->Host);
                if ((int)FirstMulticastAddress != 0)
                    dic.Add("Multicast", FirstMulticastAddress->Address.lpSockaddrIn->Host);
                if ((int)FirstUnicastAddress != 0)
                    dic.Add("Unicast", FirstMulticastAddress->Address.lpSockaddrIn->Host);
                if ((int)FirstPrefix != 0)
                    dic.Add("FirstPrefix", FirstPrefix->Address.lpSockaddrIn->Host);
                if ((int)Dhcpv4Server.lpSockaddrIn != 0)
                    dic.Add("Dhcpv4Server", Dhcpv4Server.lpSockaddrIn->Host);
                if ((int)Dhcpv6Server.lpSockaddrIn != 0)
                    dic.Add("Dhcpv6Server", Dhcpv6Server.lpSockaddrIn->Host);
                return dic;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_UNIDIRECTIONAL_ADAPTER_ADDRESS
    {
        public ULONG NumAdapters;
        public ULONG First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(IP_UNIDIRECTIONAL_ADAPTER_ADDRESS)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_GATEWAY_ADDRESS
    {
        public ULONG Length;
        public DWORD Reserved;
        public IP_ADAPTER_GATEWAY_ADDRESS* Next;
        public SOCKET_ADDRESS Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_MULTICAST_ADDRESS
    {
        public ULONG Length;
        public DWORD Flags;

        public IP_ADAPTER_MULTICAST_ADDRESS* Next;
        public SOCKET_ADDRESS Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_DNS_SERVER_ADDRESS
    {
        public ULONG Length;
        public DWORD Flags;

        public IP_ADAPTER_DNS_SERVER_ADDRESS* Next;
        public SOCKET_ADDRESS Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADAPTER_WINS_SERVER_ADDRESS
    {
        public ULONG Length;
        public DWORD Flags;

        public IP_ADAPTER_WINS_SERVER_ADDRESS* Next;
        public SOCKET_ADDRESS Address;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UNICASTIPADDRESS_TABLE
    {
        public ULONG NumEntries;
        public MIB_UNICASTIPADDRESS_ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UNICASTIPADDRESS_TABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPFORWARDTABLE
    {
        public DWORD dwNumEntries;
        public MIB_IPFORWARDROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_IPFORWARDTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPTABLE
    {
        public DWORD dwNumEntries;
        public MIB_TCPROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCPTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPTABLE
    {
        public DWORD dwNumEntries;
        public MIB_UDPROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UDPTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPTABLE_OWNER_PID
    {
        public DWORD dwNumEntries;
        public MIB_UDPROW_OWNER_PID First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UDPTABLE_OWNER_PID)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6TABLE_OWNER_PID
    {
        public DWORD dwNumEntries;
        public MIB_UDP6ROW_OWNER_PID First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UDP6TABLE_OWNER_PID)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPTABLE_OWNER_MODULE
    {
        public DWORD dwNumEntries;
        public MIB_UDPROW_OWNER_MODULE First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UDPTABLE_OWNER_MODULE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6TABLE_OWNER_MODULE
    {
        public DWORD dwNumEntries;
        public MIB_UDP6ROW_OWNER_MODULE First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UDP6TABLE_OWNER_MODULE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6TABLE
    {
        public DWORD dwNumEntries;
        public MIB_UDP6ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_UDPTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPTABLE2
    {
        public DWORD dwNumEntries;
        public MIB_TCPROW2 First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCPTABLE2)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPTABLE_OWNER_PID
    {
        public DWORD dwNumEntries;
        public MIB_TCPROW_OWNER_PID First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCPTABLE_OWNER_PID)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6TABLE
    {
        public DWORD dwNumEntries;
        public MIB_TCP6ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCP6TABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6TABLE2
    {
        public DWORD dwNumEntries;
        public MIB_TCP6ROW2 First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCP6TABLE2)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6TABLE_OWNER_PID
    {
        public DWORD dwNumEntries;
        public MIB_TCP6ROW_OWNER_PID First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCP6TABLE_OWNER_PID)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPTABLE_OWNER_MODULE
    {
        public DWORD dwNumEntries;
        public MIB_TCPROW_OWNER_MODULE First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCPTABLE_OWNER_MODULE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6TABLE_OWNER_MODULE
    {
        public DWORD dwNumEntries;
        public MIB_TCP6ROW_OWNER_MODULE First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_TCP6TABLE_OWNER_MODULE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_ANYCASTIPADDRESS_TABLE
    {
        public ULONG NumEntries;
        public MIB_ANYCASTIPADDRESS_ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_ANYCASTIPADDRESS_TABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_MULTICASTIPADDRESS_TABLE
    {
        public ULONG NumEntries;
        public MIB_MULTICASTIPADDRESS_ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_MULTICASTIPADDRESS_TABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPNETTABLE
    {
        public DWORD dwNumEntries;
        public MIB_IPNETROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_IPNETTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPPATH_TABLE
    {
        public ULONG NumEntries;
        public MIB_IPPATH_ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_IPPATH_TABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPADDRTABLE
    {
        public DWORD dwNumEntries;
        public MIB_IPADDRROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_IPADDRTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPINTERFACE_TABLE
    {
        public ULONG NumEntries;
        public MIB_IPINTERFACE_ROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_IPINTERFACE_TABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IFTABLE
    {
        public DWORD dwNumEntries;
        public MIB_IFROW First;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(MIB_IFTABLE)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPFORWARD_ROW2
    {
        public NET_LUID InterfaceLuid;
        public NET_IFINDEX InterfaceIndex;
        public IP_ADDRESS_PREFIX DestinationPrefix;
        public SOCKADDR_INET NextHop;
        public UCHAR SitePrefixLength;
        public ULONG ValidLifetime;
        public ULONG PreferredLifetime;
        public ULONG Metric;
        public NL_ROUTE_PROTOCOL Protocol;
        public BOOLEAN Loopback;
        public BOOLEAN AutoconfigureAddress;
        public BOOLEAN Publish;
        public BOOLEAN Immortal;
        public ULONG Age;
        public NL_ROUTE_ORIGIN Origin;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IP_ADDRESS_PREFIX
    {
        public SOCKADDR_INET Prefix;
        public UINT8 PrefixLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UNICASTIPADDRESS_ROW
    {
        public SOCKADDR_INET Address;
        public NET_LUID InterfaceLuid;
        public NET_IFINDEX InterfaceIndex;
        public NlPrefixOrigin PrefixOrigin;
        public NL_SUFFIX_ORIGIN SuffixOrigin;
        public ULONG ValidLifetime;
        public ULONG PreferredLifetime;
        public UINT8 OnLinkPrefixLength;
        public byte SkipAsSource;
        public NL_DAD_STATE DadState;
        public SCOPE_ID ScopeId;
        public LARGE_INTEGER CreationTimeStamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPFORWARDROW
    {
        public in_addr dwForwardDest;
        public DWORD dwForwardMask;
        public DWORD dwForwardPolicy;
        public DWORD dwForwardNextHop;
        public DWORD dwForwardIfIndex;
        public DWORD dwForwardType;
        public DWORD dwForwardProto;
        public DWORD dwForwardAge;
        public DWORD dwForwardNextHopAS;
        public DWORD dwForwardMetric1;
        public DWORD dwForwardMetric2;
        public DWORD dwForwardMetric3;
        public DWORD dwForwardMetric4;
        public DWORD dwForwardMetric5;

        public string Destination
        {
            get { return ws2_32.inet_ntoa(dwForwardDest); }
        }

        public static MIB_IPFORWARDROW FromIp(string ip)
        {
            return new MIB_IPFORWARDROW()
            {
                dwForwardDest = ws2_32.inet_addr(ip)
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPROW
    {
        public MIB_TCP_STATE dwState;

        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;

        public in_addr dwRemoteAddr;
        public DWORD dwRemotePort;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPROW
    {
        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPROW_OWNER_PID
    {
        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;
        public DWORD dwOwningPid;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MIB_UDPROW_OWNER_MODULE
    {
        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;
        public DWORD dwOwningPid;
        public LARGE_INTEGER liCreateTimestamp;
        public int dwFlags; // Or SpecificPortBind
        public fixed ULONGLONG OwningModuleInfo[16];

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MIB_UDP6ROW_OWNER_MODULE
    {
        public in6_addr ucLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;

        public DWORD dwOwningPid;
        public LARGE_INTEGER liCreateTimestamp;
        public int dwFlags; // Or SpecificPortBind
        public fixed ULONGLONG OwningModuleInfo[16];

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6ROW_OWNER_PID
    {
        public in6_addr ucLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;
        public DWORD dwOwningPid;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDP6ROW
    {
        public in6_addr dwLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPROW2
    {
        public MIB_TCP_STATE dwState;

        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;

        public in_addr dwRemoteAddr;
        public DWORD dwRemotePort;

        public DWORD dwOwningPid;
        public TCP_CONNECTION_OFFLOAD_STATE dwOffloadState;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPROW_OWNER_PID
    {
        public MIB_TCP_STATE dwState;

        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;

        public in_addr dwRemoteAddr;
        public DWORD dwRemotePort;

        public DWORD dwOwningPid;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6ROW
    {
        public MIB_TCP_STATE dwState;

        public in6_addr dwLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;

        public in6_addr dwRemoteAddr;
        public DWORD dwRemoteScopeId;
        public DWORD dwRemotePort;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6ROW2
    {
        public in6_addr dwLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;

        public in6_addr dwRemoteAddr;
        public DWORD dwRemoteScopeId;
        public DWORD dwRemotePort;

        public MIB_TCP_STATE dwState;
        public DWORD dwOwningPid;
        public TCP_CONNECTION_OFFLOAD_STATE dwOffloadState;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCP6ROW_OWNER_PID
    {
        public in6_addr dwLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;

        public in6_addr dwRemoteAddr;
        public DWORD dwRemoteScopeId;
        public DWORD dwRemotePort;

        public MIB_TCP_STATE dwState;
        public DWORD dwOwningPid;

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MIB_TCPROW_OWNER_MODULE
    {
        public MIB_TCP_STATE dwState;

        public in_addr dwLocalAddr;
        public DWORD dwLocalPort;

        public in_addr dwRemoteAddr;
        public DWORD dwRemotePort;

        public DWORD dwOwningPid;
        public SYSTEMTIME liCreateTimestamp;
        public fixed ULONGLONG OwningModuleInfo[16];

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MIB_TCP6ROW_OWNER_MODULE
    {
        public in6_addr dwLocalAddr;
        public DWORD dwLocalScopeId;
        public DWORD dwLocalPort;

        public in6_addr dwRemoteAddr;
        public DWORD dwRemoteScopeId;
        public DWORD dwRemotePort;

        public MIB_TCP_STATE dwState;
        public DWORD dwOwningPid;
        public SYSTEMTIME liCreateTimestamp;
        public fixed ULONGLONG OwningModuleInfo[16];

        public ushort LocalPort
        {
            get { return ws2_32.ntohs((ushort)dwLocalPort); }
        }
        public ushort RemotePort
        {
            get { return ws2_32.ntohs((ushort)dwRemotePort); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_ANYCASTIPADDRESS_ROW
    {
        public SOCKADDR_INET Address;
        public ULONG64 InterfaceLuid;
        public LONG InterfaceIndex;
        public ULONG ScopeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_MULTICASTIPADDRESS_ROW
    {
        public SOCKADDR_INET Address;
        public LONG InterfaceIndex;
        public ULONG64 InterfaceLuid;
        public ULONG ScopeId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPPATH_ROW
    {
        public SOCKADDR_INET Source;
        public SOCKADDR_INET Destination;
        public ULONG64 InterfaceLuid;
        public ULONG InterfaceIndex;
        public SOCKADDR_INET CurrentNextHop;
        public ULONG PathMtu;
        public ULONG RttMean;
        public ULONG RttDeviation;
        public ULONG LastReachable;
        public BYTE IsReachable;
        public ULONG64 LinkTransmitSpeed;
        public ULONG64 LinkReceiveSpeed;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MIB_IPNETROW
    {
        public DWORD dwIndex;
        public DWORD dwPhysAddrLen;
        public fixed BYTE bPhysAddr[8];
        public in_addr dwAddr;
        public MIB_IPNET dwType;

        public string Ipv4Address
        {
            get { return dwAddr.ToString(); }
        }

        public string PhysicalAddress
        {
            get
            {
                fixed (byte* macAddress = bPhysAddr)
                {
                    var builder = new StringBuilder((int)dwPhysAddrLen);
                    for (uint i = 0; i < dwPhysAddrLen; i++)
                    {
                        builder.Append((dwPhysAddrLen - 1) != i ?
                            macAddress[i].ToString("X2-") : macAddress[i].ToString("X2"));
                    }
                    return builder.ToString();
                }
            }
        }

        public uint Create()
        {
            return Iphlpapi.CreateIpNetEntry(ref this);
        }

        public uint Delete()
        {
            return Iphlpapi.DeleteIpNetEntry(ref this);
        }

        public uint Modify()
        {
            return Iphlpapi.SetIpNetEntry(ref this);
        }

        public static MIB_IPNETROW[] Enum
        {
            get
            {
                uint pdwSize = 0;
                var pIpNetTable = (MIB_IPNETTABLE*)0;
                Iphlpapi.GetIpNetTable(
                    pIpNetTable, ref pdwSize, false);

                pIpNetTable = (MIB_IPNETTABLE*)msvcrt.malloc(pdwSize);
                Iphlpapi.GetIpNetTable(
                    pIpNetTable, ref pdwSize, false);

                var arr = new MIB_IPNETROW[pIpNetTable->dwNumEntries];
                for (var i = 0; i < pIpNetTable->dwNumEntries; i++)
                    arr[i] = (&pIpNetTable->First)[i];

                return arr;
            }
        }

        public override string ToString()
        {
            return PhysicalAddress;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPADDRROW
    {
        public in_addr dwAddr;
        public DWORD dwIndex;
        public in_addr dwMask;
        public in_addr dwBCastAddr;
        public DWORD dwReasmSize;
        public ushort unused1;
        public MIB_IPADDR wType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct MIB_IPINTERFACE_ROW
    {
        //
        // Key Structure;
        //
        public AddressFamilies Family;
        public ULONG64 InterfaceLuid;
        public ULONG InterfaceIndex;

        //
        // Read-Write fields.
        //

        //
        // Fields currently not exposed.
        //
        public ULONG MaxReassemblySize;
        public ULONG64 InterfaceIdentifier;
        public ULONG MinRouterAdvertisementInterval;
        public ULONG MaxRouterAdvertisementInterval;

        //
        // Fileds currently exposed.
        //       
        public byte AdvertisingEnabled;
        public byte ForwardingEnabled;
        public byte WeakHostSend;
        public byte WeakHostReceive;
        public byte UseAutomaticMetric;
        public byte UseNeighborUnreachabilityDetection;
        public byte ManagedAddressConfigurationSupported;
        public byte OtherStatefulConfigurationSupported;
        public byte AdvertiseDefaultRoute;

        public NL_ROUTER_DISCOVERY_BEHAVIOR RouterDiscoveryBehavior;
        public ULONG DadTransmits; // DupAddrDetectTransmits in RFC 2462.    
        public ULONG BaseReachableTime;
        public ULONG RetransmitTime;
        public ULONG PathMtuDiscoveryTimeout; // Path MTU discovery timeout (in ms).

        public NL_LINK_LOCAL_ADDRESS_BEHAVIOR LinkLocalAddressBehavior;
        public ULONG LinkLocalAddressTimeout; // In ms.
        public fixed ULONG ZoneIndices[16]; // Zone part of a SCOPE_ID.
        public ULONG SitePrefixLength;
        public ULONG Metric;
        public ULONG NlMtu;

        //
        // Read Only fields.
        //
        public byte Connected;
        public byte SupportsWakeUpPatterns;
        public byte SupportsNeighborDiscovery;
        public byte SupportsRouterDiscovery;

        public ULONG ReachableTime;

        public byte TransmitOffload;
        public byte ReceiveOffload;

        //
        // Disables using default route on the interface. This flag
        // can be used by VPN clients to restrict Split tunnelling.
        //
        public byte DisableDefaultRoutes;

        public static MIB_IPINTERFACE_ROW GetInterface(uint index, AddressFamilies family)
        {
            return new MIB_IPINTERFACE_ROW()
            {
                InterfaceIndex = index,
                Family = family
            };
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct MIB_IFROW
    {
        public fixed WCHAR wszName[256];
        public DWORD dwIndex;
        public DWORD dwType;
        public DWORD dwMtu;
        public DWORD dwSpeed;
        public DWORD dwPhysAddrLen;
        public fixed BYTE bPhysAddr[8];
        public DWORD dwAdminStatus;
        public DWORD dwOperStatus;
        public DWORD dwLastChange;
        public DWORD dwInOctets;
        public DWORD dwInUcastPkts;
        public DWORD dwInNUcastPkts;
        public DWORD dwInDiscards;
        public DWORD dwInErrors;
        public DWORD dwInUnknownProtos;
        public DWORD dwOutOctets;
        public DWORD dwOutUcastPkts;
        public DWORD dwOutNUcastPkts;
        public DWORD dwOutDiscards;
        public DWORD dwOutErrors;
        public DWORD dwOutQLen;
        public DWORD dwDescrLen;
        public fixed BYTE bDescr[256];

        public string Name
        {
            get
            {
                fixed (char* someData = wszName)
                {
                    return Marshal.PtrToStringUni((IntPtr)someData);
                }
            }
        }

        public static MIB_IFROW GetInterface(uint index)
        {
            return new MIB_IFROW()
            {
                dwIndex = index
            };
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_UDPSTATS
    {
        public DWORD dwInDatagrams;
        public DWORD dwNoPorts;
        public DWORD dwInErrors;
        public DWORD dwOutDatagrams;
        public DWORD dwNumAddrs;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPSTATS
    {
        public DWORD dwRtoAlgorithm;
        public DWORD dwRtoMin;
        public DWORD dwRtoMax;
        public DWORD dwMaxConn;
        public DWORD dwActiveOpens;
        public DWORD dwPassiveOpens;
        public DWORD dwAttemptFails;
        public DWORD dwEstabResets;
        public DWORD dwCurrEstab;
        public DWORD dwInSegs;
        public DWORD dwOutSegs;
        public DWORD dwRetransSegs;
        public DWORD dwInErrs;
        public DWORD dwOutRsts;
        public DWORD dwNumConns;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IF_LUID
    {
        public ULONG64 Value;

        /*
            typedef union _NET_LUID_LH
        {
            ULONG64     Value;
            struct
            {
                ULONG64     Reserved:24;
                ULONG64     NetLuidIndex:24;
                ULONG64     IfType:16;                  // equal to IANA IF type
            }Info;
        } NET_LUID_LH, *PNET_LUID_LH;
            */
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IP_ADDR_STRING
    {
        public IP_ADDR_STRING* Next;
        public fixed byte IpAddress[16];
        public fixed byte IpMask[16];
        public DWORD Context;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct IP_ADAPTER_INDEX_MAP
    {
        public ULONG index;
        public fixed WCHAR name[128];

        public string Name
        {
            get
            {
                fixed (char* someData = name)
                {
                    return Marshal.PtrToStringUni((IntPtr)someData);
                    ;
                }
            }
        }
    } 
    #endregion

    #region Windows
    public struct GuiThreadInfo
    {
        public DWORD cbSize;
        public DWORD flags;
        public SafeWindowHandle hwndActive;
        public SafeWindowHandle hwndFocus;
        public SafeWindowHandle hwndCapture;
        public SafeWindowHandle hwndMenuOwner;
        public SafeWindowHandle hwndMoveSize;
        public SafeWindowHandle hwndCaret;
        public SafeWindowHandle rcCaret;
    }
    #endregion

    #region ???

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct INTERNET_PER_CONN_OPTION_LIST
    {
        public int size;
        public IntPtr connection;
        public int optionCount;
        public int optionError;
        public INTERNET_PER_CONN_OPTION* options;

        public static uint Size
        {
            get
            {
                return (uint)Marshal.SizeOf(
                    typeof(INTERNET_PER_CONN_OPTION_LIST));
            }
        }
        public INTERNET_PER_CONN_OPTION this[int idx]
        {
            get { return options[idx]; }
            set { options[idx] = value; }
        }

        public INTERNET_PER_CONN_OPTION_LIST(int optionCount)
        {
            this.size = Marshal.SizeOf(typeof(INTERNET_PER_CONN_OPTION_LIST));
            this.connection = IntPtr.Zero;
            this.optionCount = optionCount;
            this.optionError = 0;
            this.options = (INTERNET_PER_CONN_OPTION*)Marshal.AllocHGlobal(
                Marshal.SizeOf(typeof(INTERNET_PER_CONN_OPTION)) * optionCount);
        }
        public INTERNET_PER_CONN_OPTION_LIST(INTERNET_PER_CONN_OPTION[] arr)
            : this(arr.Length)
        {
            for (var i = 0; i < optionCount; i++)
            {
                this.options[i].dwOption = arr[i].dwOption;
                this.options[i].dwValue = arr[i].dwValue;
                this.options[i].ftValue = arr[i].ftValue;
                this.options[i].pszValue = arr[i].pszValue;
            }
        }
    }
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct INTERNET_PER_CONN_OPTION
    {
        [FieldOffset(0)]
        public IeSettingOptions dwOption;

        [FieldOffset(4)]
        public uint dwValue;
        [FieldOffset(4)]
        public IntPtr pszValue;
        [FieldOffset(4)]
        public Filetime ftValue;

        public static INTERNET_PER_CONN_OPTION Instance(IeSettingOptions dwOption, uint dwValue)
        {
            var instance = new INTERNET_PER_CONN_OPTION
            {
                dwOption = dwOption,
                dwValue = dwValue
            };
            return instance;
        }
        public static INTERNET_PER_CONN_OPTION Instance(IeSettingOptions dwOption, IntPtr pszValue)
        {
            var instance = new INTERNET_PER_CONN_OPTION
            {
                dwOption = dwOption,
                pszValue = pszValue
            };
            return instance;
        }
        public static INTERNET_PER_CONN_OPTION Instance(IeSettingOptions dwOption, Filetime ftValue)
        {
            var instance = new INTERNET_PER_CONN_OPTION
            {
                dwOption = dwOption,
                ftValue = ftValue
            };
            return instance;
        }

        //
        // InternetPerConnFlags
        //

        public const uint ProxyTypeDirect = 0x1;         // direct to net
        public const uint ProxyTypeProxy = 0x2;           // via named proxy
        public const uint ProxyTypeAutoProxyUrl = 0x4;    // autoproxy URL
        public const uint ProxyTypeAutoDetect = 0x8;      // use autoproxy detection

        //
        // InternetPerConnAutodiscoveryFlags
        //

        public const uint AutoProxyFlagUserSet = 0x1;                 // user changed this setting
        public const uint AutoProxyFlagAlwaysDetect = 0x2;            // force detection even when its not needed
        public const uint AutoProxyFlagDetectionRun = 0x4;            // detection has been run
        public const uint AutoProxyFlagMigrated = 0x8;                // migration has just been done 
        public const uint AutoProxyFlagDontCacheProxyResult = 0x10;   // don't cache result of host=proxy name
        public const uint AutoProxyFlagCacheInitRun = 0x20;           // don't initalize and run unless URL expired
        public const uint AutoProxyFlagDetectionSuspect = 0x40;       // if we're on a LAN & Modem, with only one IP, bad?!?
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROFILEINFO
    {
        public DWORD dwSize;
        public DWORD dwFlags;
        public string lpUserName;
        public string lpProfilePath;
        public string lpDefaultPath;
        public string lpServerName;
        public string lpPolicyPath;
        public SafeRegistryHandle hProfile;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct VALENT
    {
        public IntPtr ve_valuename;
        public DWORD ve_valuelen;
        public DWORD_PTR ve_valueptr;
        public RegType ve_type;

        public string Name
        {
            get { return new string((char*)ve_valuename); }
        }

        public string Value
        {
            get { return new string((char*)ve_valueptr); }
        }

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(VALENT)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DYNAMIC_TIME_ZONE_INFORMATION
    {
        public LONG Bias;
        public fixed WCHAR StandardName[32];
        public SYSTEMTIME StandardDate;
        public LONG StandardBias;
        public fixed WCHAR DaylightName[32];
        public SYSTEMTIME DaylightDate;
        public LONG DaylightBias;
        public fixed WCHAR TimeZoneKeyName[128];
        public BOOLEAN DynamicDaylightTimeDisabled;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public WORD wYear;
        public WORD wMonth;
        public WORD wDayOfWeek;
        public WORD wDay;
        public WORD wHour;
        public WORD wMinute;
        public WORD wSecond;
        public WORD wMilliseconds;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TIME_ZONE_INFORMATION
    {
        public LONG Bias;
        public fixed WCHAR StandardName[32];
        public SYSTEMTIME StandardDate;
        public LONG StandardBias;
        public fixed WCHAR DaylightName[32];
        public SYSTEMTIME DaylightDate;
        public LONG DaylightBias;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WIN32_FIND_DATA
    {
        public FileAttributes dwFileAttributes;
        public Filetime ftCreationTime;
        public Filetime ftLastAccessTime;
        public Filetime ftLastWriteTime;
        public DWORD nFileSizeHigh;
        public DWORD nFileSizeLow;
        public DWORD dwReserved0;
        public DWORD dwReserved1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;

        //public fixed TCHAR cFileName[260];
        //public fixed TCHAR cAlternateFileName[14];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WIN32_FILE_ATTRIBUTE_DATA
    {
        public FileAttributes dwFileAttributes;
        public Filetime ftCreationTime;
        public Filetime ftLastAccessTime;
        public Filetime ftLastWriteTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_RECORD
    {
        [FieldOffset(0)]
        public eventType EventType;
        [FieldOffset(2)]
        public KEY_EVENT_RECORD KeyEvent;
        [FieldOffset(2)]
        public MOUSE_EVENT_RECORD MouseEvent;
        [FieldOffset(2)]
        public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
        [FieldOffset(2)]
        public MENU_EVENT_RECORD MenuEvent;
        [FieldOffset(2)]
        public FOCUS_EVENT_RECORD FocusEvent;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct KEY_EVENT_RECORD
    {
        public BOOL bKeyDown;
        public WORD wRepeatCount;
        public VirtualKeyShort wVirtualKeyCode;
        public short wVirtualScanCode;
        public WCHAR UnicodeChar;
        public ControlKeyState dwControlKeyState;

        public override string ToString()
        {
            return string.Format(
                "KeyDown :: {0}\n" + "RepeatCount :: {1}\n" + "VirtualKeyCode :: {2}\n" + "VirtualScanCode :: {3}\n" + "UnicodeChar :: {4}\n" + "ControlKeyState :: {5}\n",
                bKeyDown, wRepeatCount, wVirtualKeyCode, wVirtualScanCode, UnicodeChar, dwControlKeyState);
        }
    }

    public struct MOUSE_EVENT_RECORD
    {
        public COORD dwMousePosition;
        public Enum.ButtonState dwButtonState;
        public ControlKeyState dwControlKeyState;
        public EventFlags dwEventFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOW_BUFFER_SIZE_RECORD
    {
        public COORD dwSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MENU_EVENT_RECORD
    {
        public uint dwCommandId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FOCUS_EVENT_RECORD
    {
        public BOOL bSetFocus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COORD
    {
        public SHORT X;
        public SHORT Y;

        public COORD(SHORT xI, SHORT yI)
        {
            X = xI;
            Y = yI;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TITLEBARINFO
    {
        public const int CCHILDREN_TITLEBAR = 5;
        public uint cbSize;
        public RECT rcTitleBar;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_TITLEBAR + 1)]
        public uint[] rgstate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWINFO
    {
        public uint cbSize;
        public RECT rcWindow;
        public RECT rcClient;
        public uint dwStyle;
        public uint dwExStyle;
        public uint dwWindowStatus;
        public uint cxWindowBorders;
        public uint cyWindowBorders;
        public ushort atomWindowType;
        public ushort wCreatorVersion;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT pt;
        public uint mouseData;
        public uint flags;
        public uint time;
        public IntPtr dwExtraInfo;

        public override string ToString()
        {
            return string.Format(
                "X:{0}, Y:{1}, Data:{2}, Flags:{3}, Time:{4}, ExtraInfo:{5},",
                pt.X, pt.Y, mouseData, flags, time, dwExtraInfo);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KBDLLHOOKSTRUCT
    {
        public VirtualKey vkCode;
        public ScanCode scanCode;
        public LLKHF_Flags flags;
        public uint time;
        public UIntPtr dwExtraInfo;

        public override string ToString()
        {
            return string.Format(
                "VirtualKey:{0}, ScanCode:{1}, Flags:{2}, Time:{3}, ExtraInfo:{4},",
                vkCode, scanCode, flags, time, dwExtraInfo);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CBTACTIVATESTRUCT
    {
        public BOOL fMouse;
        public SafeWindowHandle hWndActive;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CBT_CREATEWND
    {
        public CREATESTRUCT* lpcs;
        public SafeWindowHandle hwndInsertAfter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEHOOKSTRUCT
    {
        public POINT pt;
        public SafeWindowHandle hwnd;
        public UINT wHitTestCode;
        public ULONG_PTR dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CREATESTRUCT
    {
        public SafeWindowHandle lpCreateParams;
        public HINSTANCE hInstance;
        public HMENU hMenu;
        public SafeWindowHandle hwndParent;
        public int cy;
        public int cx;
        public int y;
        public int x;
        public WindowStyle style;
        public IntPtr lpszName;
        public IntPtr lpszClass;
        public WindowStyle dwExStyle;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct timeval
    {
        /// <summary>
        /// Time interval, in seconds.
        /// </summary>
        public int tv_sec;

        /// <summary>
        /// Time interval, in microseconds.
        /// </summary>
        public int tv_usec;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct fd_set
    {
        public uint fd_count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Size)]
        public IntPtr[] fd_array;

        private const int Size = 1;

        public static fd_set Null
        {
            get
            {
                return new fd_set()
                            {
                                fd_array = null,
                                fd_count = 0
                            };
            }
        }

        public static fd_set Create(SafeSocketHandle socket)
        {
            var handle = new fd_set()
            {
                fd_count = Size,
                fd_array = new IntPtr[Size] { socket.stdHandle }
            };
            return handle;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INTERFACE_INFO
    {
        public uint iiFlags;
        public sockaddr_gen iiAddress;
        public sockaddr_gen iiBroadcastAddress;
        public sockaddr_gen iiNetmask;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct tcp_keepalive
    {
        public uint onoff;
        public uint keepalivetime;
        public uint keepaliveinterval;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct addrinfo
    {
        public AI ai_flags;
        public AddressFamilyInt ai_family;
        public SocketTypeInt ai_socktype;
        public SocketProtocolInt ai_protocol;
        public uint ai_addrlen;

        //public IntPtr ai_canonname;
        public char* ai_canonname;

        //public IntPtr ai_addr;
        public sockaddr* ai_addr;

        //public IntPtr ai_next;
        public addrinfo* ai_next;

        public string[] Hosts
        {
            get
            {
                var hostList = new List<string>();
                var addressList = new List<addrinfo> { this };
                addressList.AddRange(Children);

                foreach (var info in addressList)
                {
                    try
                    {
                        hostList.Add(info.SockaddrIn6.Host);
                    }
                    catch
                    {
                    }
                }

                return hostList.ToArray();
            }
        }

        public addrinfo[] Children
        {
            get
            {
                if ((IntPtr)ai_next == IntPtr.Zero)
                    return new addrinfo[0];

                var info = ai_next;
                var childList = new List<addrinfo>();

                while (true)
                {
                    childList.Add(*info);

                    if ((IntPtr)(info->ai_next) == IntPtr.Zero)
                        break;
                    info = info->ai_next;
                }
                return childList.ToArray();
            }
        }

        public string Name
        {
            get { return new string(ai_canonname); }
        }

        public sockaddr_in SockaddrIn
        {
            get
            {
                return (sockaddr_in)Marshal.PtrToStructure(
                    (IntPtr)ai_addr,
                    typeof(sockaddr_in));
            }
        }

        public sockaddr_in6 SockaddrIn6
        {
            get
            {
                return (sockaddr_in6)Marshal.PtrToStructure(
                    (IntPtr)ai_addr,
                    typeof(sockaddr_in6));
            }
        }

        public static addrinfo CreateHints()
        {
            return new addrinfo()
            {
                ai_flags = AI.AI_NOTHING,
                ai_family = AddressFamilyInt.UNSPEC,
                ai_socktype = SocketTypeInt.STREAM,
                ai_protocol = SocketProtocolInt.IP
            };
        }

        public static addrinfo FromPtr(IntPtr handle)
        {
            return *(addrinfo*)handle;
        }
    }

    // Resource File Formats
    // http://msdn.microsoft.com/en-us/library/windows/desktop/ms648007(v=vs.85).aspx
    // Version Resources
    // The main structure in a version resource is the VS_FIXEDFILEINFO structure.
    // Additional structures include the VarFileInfo structure to store language information data,
    // and StringFileInfo for user-defined string information.
    // All strings in a version resource are in Unicode format.
    // Each block of information is [aligned on a DWORD boundary].

    // DWORD-aligned 
    // http://msdn.microsoft.com/en-us/library/windows/desktop/aa369366(v=vs.85).aspx
    // Each data structure in a value list must begin on a DWORD boundary.
    // This means that the distance (in bytes) between the start of the value list buffer
    // and the start of any data structure is always an even >> multiple of sizeof(DWORD). <<
    // If a data structure contains variable length data, you might have to advance a few extra bytes,
    // before adding the next data structure in order to ensure DWORD-alignment (see the diagram in Value Lists).
    // Use the ALIGN_CLUSPROP macro to calculate the correct alignment size.

    // ALIGN_CLUSPROP macro
    // http://msdn.microsoft.com/en-us/library/windows/desktop/aa367179(v=vs.85).aspx
    // #define ALIGN_CLUSPROP( num ) ((num + 3) & ~3)

    // Struct Info
    // Begin
    // Header -> ALIGN_CLUSPROP -> VS_FIXEDFILEINFO -> ALIGN_CLUSPROP
    // Header -> ALIGN_CLUSPROP -> {-SubHeader, string, ALIGN_CLUSPROP- Until Header.Length} -> ALIGN_CLUSPROP
    // Header -> ALIGN_CLUSPROP -> {-LANGANDCODEPAGE- Until Header.Length} -> ALIGN_CLUSPROP
    // End

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public unsafe struct RESOURCEHEADER
    {
        /// <summary>
        /// The length, in bytes, of the VS_VERSIONINFO structure
        /// </summary>
        [FieldOffset(0)]
        public WORD wLength;

        /// <summary>
        /// The length, in bytes, of the Value member. 
        /// </summary>
        [FieldOffset(2)]
        public WORD wValueLength;

        /// <summary>
        /// The type of data in the version resource. 
        /// This member is 1 if the version resource contains text data and 0 if the version resource contains binary data.
        /// </summary>
        [FieldOffset(4)]
        public WORD wType;

        /// <summary>
        /// The Unicode string L"VarFileInfo".
        /// </summary>
        [FieldOffset(6)]
        public fixed WCHAR szKeyVar[12];

        /// <summary>
        /// The Unicode string L"StringFileInfo".
        /// </summary>
        [FieldOffset(6)]
        public fixed WCHAR szKeyString[15];

        /// <summary>
        /// The Unicode string L"VS_VERSION_INFO".
        /// </summary>
        [FieldOffset(6)]
        public fixed WCHAR szKeyVerInfo[16];

        public int IsVarFileInfo
        {
            get
            {
                fixed (char* charPtr = szKeyString)
                {
                    var charData = new string(charPtr);
                    if (charData == "VarFileInfo")
                        return 6 + ("VarFileInfo".Length + 1) * 2;
                }
                return 0;
            }
        }

        public int IsStringFileInfo
        {
            get
            {
                fixed (char* charPtr = szKeyString)
                {
                    var charData = new string(charPtr);
                    if (charData == "StringFileInfo")
                        return 6 + ("StringFileInfo".Length + 1) * 2;
                }
                return 0;
            }
        }

        public int IsVersionInfo
        {
            get
            {
                fixed (char* charPtr = szKeyString)
                {
                    var charData = new string(charPtr);
                    if (charData == "VS_VERSION_INFO")
                        return 6 + ("VS_VERSION_INFO".Length + 1) * 2;
                }
                return 0;
            }
        }

        public static int Size
        {
            get { return 6; }
        }
    };

    /// <summary>
    /// http://vmd.myxomop.com/apires/ref/v/vs_fixedfileinfo.html
    /// http://www.pinvoke.net/default.aspx/Structures/VS_FIXEDFILEINFO.html
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms646997(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VS_FIXEDFILEINFO
    {
        /// <summary>
        /// Contains the value 0xFEEF04BD.
        /// </summary>
        public DWORD dwSignature;

        /// <summary>
        /// The binary version number of this structure.
        /// </summary>
        public DWORD dwStrucVersion;

        /// <summary>
        /// The most significant 32 bits of the file's binary version number. 
        /// </summary>
        public DWORD dwFileVersionMS;

        /// <summary>
        /// The least significant 32 bits of the file's binary version number.
        /// </summary>
        public DWORD dwFileVersionLS;

        /// <summary>
        /// The most significant 32 bits of the binary version number of the product with which this file was distributed. 
        /// </summary>
        public DWORD dwProductVersionMS;

        /// <summary>
        /// The least significant 32 bits of the binary version number of the product with which this file was distributed. 
        /// </summary>
        public DWORD dwProductVersionLS;

        /// <summary>
        /// Contains a bitmask that specifies the valid bits in dwFileFlags.
        /// </summary>
        public DWORD dwFileFlagsMask;

        /// <summary>
        /// dwFileFlags
        /// </summary>
        public FileFlags dwFileFlags;

        /// <summary>
        /// dwFileOS
        /// </summary>
        public FileOS dwFileOS;

        /// <summary>
        /// The general type of file.
        /// </summary>
        public FileType dwFileType;

        /// <summary>
        /// The function of the file. 
        /// </summary>
        public FileSubtype dwFileSubtype;

        /// <summary>
        /// The most significant 32 bits of the file's 64-bit binary creation date and time stamp. 
        /// </summary>
        public DWORD dwFileDateMS;

        /// <summary>
        /// The least significant 32 bits of the file's 64-bit binary creation date and time stamp. 
        /// </summary>
        public DWORD dwFileDateLS;

        public static int Size
        {
            get { return 52; }
        }
    };

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms647464(v=vs.85).aspx
    /// </summary>
    public struct LANGANDCODEPAGE
    {
        public WORD wLanguage;
        public WORD wCodePage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LPMODULEINFO
    {
        public LPVOID lpBaseOfDll;
        public DWORD SizeOfImage;
        public LPVOID EntryPoint;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(LPMODULEINFO)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONTEXT
    {
        //set this to an appropriate value 
        public CONTEXT_FLAGS ContextFlags;
        // Retrieved by CONTEXT_DEBUG_REGISTERS 
        public uint Dr0;
        public uint Dr1;
        public uint Dr2;
        public uint Dr3;
        public uint Dr6;
        public uint Dr7;
        // Retrieved by CONTEXT_FLOATING_POINT 
        public FLOATING_SAVE_AREA FloatSave;
        // Retrieved by CONTEXT_SEGMENTS 
        public uint SegGs;
        public uint SegFs;
        public uint SegEs;
        public uint SegDs;
        // Retrieved by CONTEXT_INTEGER 
        public uint Edi;
        public uint Esi;
        public uint Ebx;
        public uint Edx;
        public uint Ecx;
        public uint Eax;
        // Retrieved by CONTEXT_CONTROL 
        public uint Ebp;
        public uint Eip;
        public uint SegCs;
        public uint EFlags;
        public uint Esp;
        public uint SegSs;
        // Retrieved by CONTEXT_EXTENDED_REGISTERS 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] ExtendedRegisters;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CONTEXT_UNSAFE
    {
        //set this to an appropriate value 
        public CONTEXT_FLAGS ContextFlags;
        // Retrieved by CONTEXT_DEBUG_REGISTERS 
        public uint Dr0;
        public uint Dr1;
        public uint Dr2;
        public uint Dr3;
        public uint Dr6;
        public uint Dr7;
        // Retrieved by CONTEXT_FLOATING_POINT 
        public FLOATING_SAVE_AREA FloatSave;
        // Retrieved by CONTEXT_SEGMENTS 
        public uint SegGs;
        public uint SegFs;
        public uint SegEs;
        public uint SegDs;
        // Retrieved by CONTEXT_INTEGER 
        public uint Edi;
        public uint Esi;
        public uint Ebx;
        public uint Edx;
        public uint Ecx;
        public uint Eax;
        // Retrieved by CONTEXT_CONTROL 
        public uint Ebp;
        public uint Eip;
        public uint SegCs;
        public uint EFlags;
        public uint Esp;
        public uint SegSs;
        // Retrieved by CONTEXT_EXTENDED_REGISTERS 
        public fixed byte ExtendedRegisters[512];
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WOW64_CONTEXT
    {
        //set this to an appropriate value 
        public WOW64_CONTEXT_FLAGS ContextFlags;
        // Retrieved by CONTEXT_DEBUG_REGISTERS 
        public uint Dr0;
        public uint Dr1;
        public uint Dr2;
        public uint Dr3;
        public uint Dr6;
        public uint Dr7;
        // Retrieved by CONTEXT_FLOATING_POINT 
        public WOW64_FLOATING_SAVE_AREA FloatSave;
        // Retrieved by CONTEXT_SEGMENTS 
        public uint SegGs;
        public uint SegFs;
        public uint SegEs;
        public uint SegDs;
        // Retrieved by CONTEXT_INTEGER 
        public uint Edi;
        public uint Esi;
        public uint Ebx;
        public uint Edx;
        public uint Ecx;
        public uint Eax;
        // Retrieved by CONTEXT_CONTROL 
        public uint Ebp;
        public uint Eip;
        public uint SegCs;
        public uint EFlags;
        public uint Esp;
        public uint SegSs;
        // Retrieved by CONTEXT_EXTENDED_REGISTERS 
        public fixed byte ExtendedRegisters[512];
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct ProcessForegroundBackground
    {
        public byte Foreground;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FLOATING_SAVE_AREA
    {
        public uint ControlWord;
        public uint StatusWord;
        public uint TagWord;
        public uint ErrorOffset;
        public uint ErrorSelector;
        public uint DataOffset;
        public uint DataSelector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public byte[] RegisterArea;
        public uint Cr0NpxState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WOW64_FLOATING_SAVE_AREA
    {
        public uint ControlWord;
        public uint StatusWord;
        public uint TagWord;
        public uint ErrorOffset;
        public uint ErrorSelector;
        public uint DataOffset;
        public uint DataSelector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public byte[] RegisterArea;
        public uint Cr0NpxState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct WOW64_FLOATING_SAVE_AREA_UNSAFE
    {
        public uint ControlWord;
        public uint StatusWord;
        public uint TagWord;
        public uint ErrorOffset;
        public uint ErrorSelector;
        public uint DataOffset;
        public uint DataSelector;
        public fixed byte RegisterArea[80];
        public uint Cr0NpxState;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOADED_IMAGE
    {
        public IntPtr moduleName;
        public SafeFileHandle hFile;
        public IntPtr MappedAddress;
        public IntPtr FileHeader;
        public IntPtr lastRvaSection;
        public UInt32 numbOfSections;
        public IntPtr firstRvaSection;
        public UInt32 charachteristics;
        public ushort systemImage;
        public ushort dosImage;
        public ushort readOnly;
        public ushort version;

        // these two comprise the LIST_ENTRY
        public IntPtr links_1;
        public IntPtr links_2;
        public UInt32 sizeOfImage;
    }



    public struct Time_Fields
    {
        public short Year;        // range [1601...]
        public short Month;       // range [1..12]
        public short Day;         // range [1..31]
        public short Hour;        // range [0..23]
        public short Minute;      // range [0..59]
        public short Second;      // range [0..59]
        public short Milliseconds;// range [0..999]
        public short Weekday;     // range [0..6] == [Sunday..Saturday]
    }

    public struct GENERIC_MAPPING
    {
        public ACCESS_MASK GenericRead;
        public ACCESS_MASK GenericWrite;
        public ACCESS_MASK GenericExecute;
        public ACCESS_MASK GenericAll;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UNICODE_STRING : IDisposable
    {
        public ushort Length;
        public ushort MaximumLength;
        public IntPtr Buffer;

        public void Set(string value)
        {
            Length = (ushort)(value.Length * 2);
            MaximumLength = (ushort)(Length + 2);
            Buffer = Marshal.StringToHGlobalUni(value);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Buffer);

            Length = 0;
            MaximumLength = 0;
            Buffer = IntPtr.Zero;
        }

        public unsafe string FromProcess(SafeProcessHandle hProcess)
        {
            uint lpNumberOfBytesRead;
            var lpBuffer = (char*)kernel32.LocalAlloc(LocalMemoryFlags.Fixed, Length);
            kernel32.ReadProcessMemory(hProcess, Buffer, (IntPtr)lpBuffer, Length, out lpNumberOfBytesRead);

            var idx = 0;
            var buffPtr = lpBuffer;
            for (var i = 0; i < Length; i++)
            {
                var selectedChar = buffPtr[i];
                if (selectedChar != '\0' &&
                    selectedChar <= 127)
                    continue;

                idx = i;
                break;
            }

            var result = new string(lpBuffer, 0, idx);
            kernel32.LocalFree((IntPtr)lpBuffer);
            return result;
        }

        public unsafe override string ToString()
        {
            var idx = 0;
            var buffPtr = (char*)Buffer;
            for (var i = 0; i < Length; i++)
            {
                var selectedChar = buffPtr[i];
                if (selectedChar != '\0' &&
                    selectedChar <= 127)
                    continue;

                idx = i;
                break;
            }

            return Buffer.ToUnicodeStr(idx);
        }
    }

    public struct BYTES
    {
        public byte BaseMid;
        public byte Flags1;
        public byte Flags2;
        public byte BaseHi;
    }

    public struct BITS
    {
        private int Value;

        /// <summary>
        /// Max set value is 255 (11111111b)
        /// </summary>
        public int BaseMid
        {
            get { return (Value & 0xFF); }
            set { Value = (Value & unchecked((int)0xFFFFFF00)) | (value & 0xFF); }
        }

        /// <summary>
        /// Max set value is 31 (11111b)
        /// </summary>
        public int Type
        {
            get { return (Value & 0x1F00) >> 8; }
            set { Value = (Value & unchecked((int)0xFFFFE0FF)) | ((value & 0x1F) << 8); }
        }

        /// <summary>
        /// Max set value is 3 (11b)
        /// </summary>
        public int Dpl
        {
            get { return (Value & 0x6000) >> 13; }
            set { Value = (Value & unchecked((int)0xFFFF9FFF)) | ((value & 0x3) << 13); }
        }

        /// <summary>
        /// Max set value is 1 (1b)
        /// </summary>
        public int Pres
        {
            get { return (Value & 0x4000) >> 15; }
            set { Value = (Value & unchecked((int)0xFFFFBFFF)) | ((value & 0x1) << 15); }
        }

        /// <summary>
        /// Max set value is 15 (1111b)
        /// </summary>
        public int LimitHi
        {
            get { return (Value & 0xF0000) >> 16; }
            set { Value = (Value & unchecked((int)0xFFF0FFFF)) | ((value & 0xF) << 16); }
        }

        /// <summary>
        /// Max set value is 1 (1b)
        /// </summary>
        public int Sys
        {
            get { return (Value & 0x100000) >> 20; }
            set { Value = (Value & unchecked((int)0xFFEFFFFF)) | ((value & 0x1) << 20); }
        }

        /// <summary>
        /// Max set value is 1 (1b)
        /// </summary>
        public int Reserved_0
        {
            get { return (Value & 0x200000) >> 21; }
            set { Value = (Value & unchecked((int)0xFFDFFFFF)) | ((value & 0x1) << 21); }
        }

        /// <summary>
        /// Max set value is 1 (1b)
        /// </summary>
        public int Default_Big
        {
            get { return (Value & 0x400000) >> 22; }
            set { Value = (Value & unchecked((int)0xFFBFFFFF)) | ((value & 0x1) << 22); }
        }

        /// <summary>
        /// Max set value is 1 (1b)
        /// </summary>
        public int Granularity
        {
            get { return (Value & 0x800000) >> 23; }
            set { Value = (Value & unchecked((int)0xFF7FFFFF)) | ((value & 0x1) << 23); }
        }

        /// <summary>
        /// Max set value is 255 (11111111b)
        /// </summary>
        public int BaseHi
        {
            get { return (Value & unchecked((int)0xFF000000)) >> 24; }
            set { Value = (Value & unchecked((int)0xFFFFFF)) | ((value & 0xFF) << 24); }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct HIGHWORD
    {
        [FieldOffset(0)]
        public BYTES Bytes;
        [FieldOffset(0)]
        public BITS Bits;
    }

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct LARGE_INTEGER
    {
        [FieldOffset(0)]
        public Int64 QuadPart;
        [FieldOffset(0)]
        public DWORD LowPart;
        [FieldOffset(4)]
        public LONG HighPart;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LIST_ENTRY
    {
        public IntPtr Flink;
        public IntPtr Blink;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        /// <summary>
        /// The length of the structure, in bytes. Before calling the GetWindowPlacement or SetWindowPlacement functions, set this member to sizeof(WINDOWPLACEMENT).
        /// <para>
        /// GetWindowPlacement and SetWindowPlacement fail if this member is not set correctly.
        /// </para>
        /// </summary>
        public int Length;

        /// <summary>
        /// Specifies flags that control the position of the minimized window and the method by which the window is restored.
        /// </summary>
        public int Flags;

        /// <summary>
        /// The current show state of the window.
        /// </summary>
        public ShowWindowCommand ShowCmd;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is minimized.
        /// </summary>
        public POINT MinPosition;

        /// <summary>
        /// The coordinates of the window's upper-left corner when the window is maximized.
        /// </summary>
        public POINT MaxPosition;

        /// <summary>
        /// The window's coordinates when the window is in the restored position.
        /// </summary>
        public RECT NormalPosition;

        /// <summary>
        /// Gets the default (empty) value.
        /// </summary>
        public unsafe static WINDOWPLACEMENT Default
        {
            get
            {
                return new WINDOWPLACEMENT { Length = sizeof(WINDOWPLACEMENT) }; ;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FLASHWINFO
    {
        /// <summary>
        /// (uint)Marshal.SizeOf(typeof(FLASHWINFO))
        /// </summary>
        public UInt32 cbSize;

        /// <summary>
        /// handle
        /// </summary>
        public SafeWindowHandle hwnd;

        /// <summary>
        /// flags
        /// </summary>
        public FlashWindowFlags dwFlags;

        /// <summary>
        /// count
        /// </summary>
        public UInt32 uCount;

        /// <summary>
        /// timeout
        /// </summary>
        public UInt32 dwTimeout;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT : IEquatable<RECT>
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public RECT(int xI, int yI, int wI, int hI)
        {
            Left = xI;
            Top = yI;
            Right = Left + wI;
            Bottom = Top + hI;
        }

        public int X
        {
            get { return this.Left; }
        }

        public int Y
        {
            get { return this.Top; }
        }

        public int Width
        {
            get { return (this.Right - this.Left); }
        }

        public int Height
        {
            get { return (this.Bottom - this.Top); }
        }

        public BOOL Equals(RECT other)
        {
            return
                other.X == X &&
                other.Y == Y &&
                other.Left == Left &&
                other.Right == Right;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        public BYTE BlendOp;
        public BYTE BlendFlags;
        public BYTE SourceConstantAlpha;
        public BYTE AlphaFormat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public LONG cW;
        public LONG cH;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override LPCTSTR ToString()
        {
            return string.Format("X:{0}, Y:{1}", X, Y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_GROUPS
    {
        public DWORD GroupCount;

        /// <summary>
        /// to Enum use (&Output->First)[i];
        /// </summary>
        public SID_AND_ATTRIBUTES First;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        //public SID_AND_ATTRIBUTES[] Groups;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(TOKEN_GROUPS)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_PRIVILEGES
    {
        public DWORD PrivilegeCount;

        /// <summary>
        /// to Enum use (&Output->First)[i];
        /// </summary>
        public LUID_AND_ATTRIBUTES First;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        //public LUID_AND_ATTRIBUTES[] Privileges;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(TOKEN_PRIVILEGES)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PPRIVILEGE_SET
    {
        public DWORD PrivilegeCount;
        public DWORD Control;

        /// <summary>
        /// to Enum use (&Output->First)[i];
        /// </summary>
        public LUID_AND_ATTRIBUTES First;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        //public LUID_AND_ATTRIBUTES[] Privileges;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(PPRIVILEGE_SET)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TOKEN_GROUPS_AND_PRIVILEGES
    {
        public DWORD SidCount;
        public DWORD SidLength;
        public SID_AND_ATTRIBUTES* Sids;
        public DWORD RestrictedSidCount;
        public DWORD RestrictedSidLength;
        public SID_AND_ATTRIBUTES* RestrictedSids;
        public DWORD PrivilegeCount;
        public DWORD PrivilegeLength;
        public LUID_AND_ATTRIBUTES* Privileges;
        public LUID AuthenticationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TOKEN_ACCESS_INFORMATION
    {
        public SID_AND_ATTRIBUTES_HASH* SidHash;
        public SID_AND_ATTRIBUTES_HASH* RestrictedSidHash;

        /// <summary>
        /// TOKEN_PRIVILEGES
        /// </summary>
        public IntPtr Privileges;

        public LUID AuthenticationId;
        public TOKEN_TYPE TokenType;
        public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
        public TOKEN_MANDATORY_POLICY MandatoryPolicy;
        public DWORD Flags;
        public DWORD AppContainerNumber;
        public SafeSidHandle PackageSid;
        public SID_AND_ATTRIBUTES_HASH* CapabilitiesHash;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLAIM_SECURITY_ATTRIBUTES_INFORMATION
    {
        public WORD Version;
        public WORD Reserved;
        public DWORD AttributeCount;

        /// <summary>
        /// CLAIM_SECURITY_ATTRIBUTE_V1 structure
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/hh448489(v=vs.85).aspx
        /// </summary>
        public IntPtr pAttributeV1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct STARTUPINFO
    {
        /// <summary>
        /// must be set to
        /// Marshal.SizeOf(typeof(STARTUPINFO))
        /// </summary>
        public Int32 cb;

        /// <summary>
        /// Reserved; must be NULL.
        /// </summary>
        public IntPtr lpReserved;

        /// <summary>
        /// The name of the desktop, or the name of both the desktop and window station for this process.
        /// </summary>
        public IntPtr lpDesktop;

        /// <summary>
        /// For console processes, this is the title displayed in the title bar if a new console window is created.
        /// If NULL, the name of the executable file is used as the window title instead. 
        /// </summary>
        public IntPtr lpTitle;

        /// <summary>
        /// location X
        /// </summary>
        public DWORD dwX;

        /// <summary>
        /// /// location Y
        /// </summary>
        public DWORD dwY;

        /// <summary>
        /// Size of X
        /// </summary>
        public DWORD dwXSize;

        /// <summary>
        /// Size of Y
        /// </summary>
        public DWORD dwYSize;

        public Int32 dwXCountChars;
        public Int32 dwYCountChars;
        public Int32 dwFillAttribute;
        public STARTUPINFO_FLAGS dwFlags;
        public ShowWindowCommandShort wShowWindow;
        public Int16 cbReserved2;
        public IntPtr lpReserved2;
        public SafeConsoleHandle hStdInput;
        public SafeConsoleHandle hStdOutput;
        public SafeConsoleHandle hStdError;

        public string Title
        {
            get { return lpTitle.ToUnicodeStr(); }
        }

        public string Desktop
        {
            get { return lpDesktop.ToUnicodeStr(); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_INFORMATION
    {
        public SafeProcessHandle hProcess;
        public SafeThreadHandle hThread;
        public int dwProcessId;
        public int dwThreadId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        /// <summary>
        /// The size, in bytes, of this structure. Set this value to the size of the SECURITY_ATTRIBUTES structure.
        /// </summary>
        public uint nLength;

        /// <summary>
        /// A pointer to a SECURITY_DESCRIPTOR structure that controls access to the object.
        /// user [IntPtr.Zero] to assigned the default security descriptor associated with the access token of the calling process. 
        /// </summary>
        public SafeSecurityDescriptorHandle lpSecurityDescriptor;

        /// <summary>
        /// A Boolean value that specifies whether the returned handle is inherited when a new process is created.
        /// </summary>
        public bool bInheritHandle;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct THREADENTRY32
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Before calling the Thread32First function,
        /// set this member to :: Marshal.SizeOf(typeof(THREADENTRY32))
        /// If you do not initialize dwSize,
        /// Thread32First fails.
        /// </summary>
        public UInt32 dwSize;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public UInt32 cntUsage;

        /// <summary>
        /// The thread identifier, compatible with the thread identifier returned by the CreateProcess function.
        /// </summary>
        public UInt32 th32ThreadID;

        /// <summary>
        /// The identifier of the process that created the thread.
        /// </summary>
        public UInt32 th32OwnerProcessID;

        /// <summary>
        /// The kernel base priority level assigned to the thread.
        /// </summary>
        public UInt32 tpBasePri;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public UInt32 tpDeltaPri;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public UInt32 dwFlags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct PROCESSENTRY32
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Before calling the Process32First function,
        /// set this member to :: Marshal.SizeOf(typeof(PROCESSENTRY32))
        /// If you do not initialize dwSize,
        /// Process32First fails.
        /// </summary>
        public UInt32 dwSize;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public UInt32 cntUsage;

        /// <summary>
        /// The process identifier.
        /// </summary>
        public UInt32 th32ProcessID;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public IntPtr th32DefaultHeapID;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public UInt32 th32ModuleID;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public UInt32 cntThreads;

        /// <summary>
        /// The number of execution threads started by the process.
        /// </summary>
        public UInt32 th32ParentProcessID;

        /// <summary>
        /// he identifier of the process that created this process (its parent process).
        /// </summary>
        public Int32 pcPriClassBase;

        /// <summary>
        /// The base priority of any threads created by this process.
        /// </summary>
        public UInt32 dwFlags;

        /// <summary>
        /// The name of the executable file for the process.
        /// To retrieve the full path to the executable file,
        /// call the Module32First function and check the szExePath member of the MODULEENTRY32 structure that is returned.
        /// However, if the calling process is a 32-bit process,
        /// you must call the QueryFullProcessImageName function to retrieve the full path of the executable file for a 64-bit process.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szExeFile;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct HEAPLIST32
    {
        public SIZE_T dwSize;
        public DWORD th32ProcessID;
        public ULONG_PTR th32HeapID;
        public DWORD dwFlags;
    };

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct MODULEENTRY32
    {
        public uint dwSize;
        public uint th32ModuleID;
        public uint th32ProcessID;
        public uint GlblcntUsage;
        public uint ProccntUsage;
        public IntPtr modBaseAddr;
        public uint modBaseSize;
        public IntPtr hModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szModule;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szExePath;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public PVOID BaseAddress;
        public PVOID AllocationBase;
        public AllocationProtectEnum AllocationProtect;
        public SIZE_T RegionSize;
        public StateEnum State;
        public AllocationProtectEnum Protect;
        public TypeEnum Type;

        public bool Valid
        {
            get
            {
                return
                    AllocationProtect == AllocationProtectEnum.PAGE_READWRITE &&
                    State == StateEnum.MEM_COMMIT &&
                    RegionSize > 0;
            }
        }

        public IntPtr Next
        {
            get { return IntPtr.Add(BaseAddress, (int)RegionSize); }
        }

        public byte[] Read(SafeProcessHandle proc)
        {
            uint read;
            byte[] data;
            var handle = Marshal.AllocHGlobal((int)RegionSize);
            kernel32.ReadProcessMemory(proc, BaseAddress, handle, RegionSize, out read);
            data = new byte[read];
            Marshal.Copy(handle, data, 0, (int)read);
            Marshal.FreeHGlobal(handle);
            return data;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public WORD wProcessorArchitecture;
        public WORD wReserved;
        public DWORD dwPageSize;
        public LPVOID lpMinimumApplicationAddress;
        public LPVOID lpMaximumApplicationAddress;
        public DWORD_PTR dwActiveProcessorMask;
        public DWORD dwNumberOfProcessors;
        public DWORD dwProcessorType;
        public DWORD dwAllocationGranularity;
        public WORD wProcessorLevel;
        public WORD wProcessorRevision;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OSVERSIONINFOEX
    {
        public uint dwOSVersionInfoSize;
        public uint dwMajorVersion;
        public uint dwMinorVersion;
        public uint dwBuildNumber;
        public uint dwPlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szCSDVersion;

        public Int16 wServicePackMajor;
        public Int16 wServicePackMinor;
        public Int16 wSuiteMask;
        public Byte wProductType;
        public Byte wReserved;

        private const uint VER_SERVER_NT = 0x80000000;
        private const uint VER_WORKSTATION_NT = 0x40000000;

        private const uint VER_NT_WORKSTATION = 0x00000001;
        private const uint VER_NT_DOMAIN_CONTROLLER = 0x00000002;
        private const uint VER_NT_SERVER = 0x00000003;

        private const uint VER_SUITE_SMALLBUSINESS = 0x00000001;
        private const uint VER_SUITE_ENTERPRISE = 0x00000002;
        private const uint VER_SUITE_BACKOFFICE = 0x00000004;
        private const uint VER_SUITE_COMMUNICATIONS = 0x00000008;
        private const uint VER_SUITE_TERMINAL = 0x00000010;
        private const uint VER_SUITE_SMALLBUSINESS_RESTRICTED = 0x00000020;
        private const uint VER_SUITE_EMBEDDEDNT = 0x00000040;
        private const uint VER_SUITE_DATACENTER = 0x00000080;
        private const uint VER_SUITE_SINGLEUSERTS = 0x00000100;
        private const uint VER_SUITE_PERSONAL = 0x00000200;
        private const uint VER_SUITE_BLADE = 0x00000400;

        public bool Is7
        {
            get
            {
                return dwMajorVersion == 6 &&
                        dwMinorVersion == 1 &&
                        wProductType == VER_NT_WORKSTATION;

            }
        }

        public bool IsServer2008R2
        {
            get
            {
                return dwMajorVersion == 6 &&
                        dwMinorVersion == 1 &&
                        wProductType != VER_NT_WORKSTATION;
            }
        }

        public bool IsServer2008
        {
            get
            {
                return dwMajorVersion == 6 &&
                        dwMinorVersion == 0 &&
                        wProductType != VER_NT_WORKSTATION;

            }
        }

        public bool IsVista
        {
            get
            {
                return dwMajorVersion == 6 &&
                        dwMinorVersion == 0 &&
                        wProductType == VER_NT_WORKSTATION;

            }
        }

        public bool IsServer2003R2
        {
            get
            {
                return dwMajorVersion == 5 &&
                        dwMinorVersion == 2 &&
                        user32.GetSystemMetrics(SystemMetric.SM_SERVERR2) != 0;

            }
        }

        public bool IsServer2003
        {
            get
            {
                return dwMajorVersion == 5 &&
                        dwMinorVersion == 2 &&
                        user32.GetSystemMetrics(SystemMetric.SM_SERVERR2) == 0;

            }
        }

        public bool IsXP
        {
            get
            {
                return dwMajorVersion == 5 &&
                        dwMinorVersion == 1;

            }
        }

        public bool Is2000
        {
            get
            {
                return dwMajorVersion == 5 &&
                        dwMinorVersion == 0;

            }
        }

        public static OSVERSIONINFOEX Instance
        {
            get
            {
                var instance = new OSVERSIONINFOEX();
                instance.dwOSVersionInfoSize = (uint)Marshal.SizeOf(instance);
                return instance;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ENUM_SERVICE_STATUS
    {
        public IntPtr lpServiceName;
        public IntPtr lpDisplayName;
        public SERVICE_STATUS ServiceStatus;

        public string ServiceName
        {
            get { return lpServiceName.ToUnicodeStr(); }
        }

        public string DisplayName
        {
            get { return lpDisplayName.ToUnicodeStr(); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_STATUS
    {
        public ServiceType dwServiceType;
        public State dwCurrentState;
        public ServiceAccept dwControlsAccepted;
        public DWORD dwWin32ExitCode;
        public DWORD dwServiceSpecificExitCode;
        public DWORD dwCheckPoint;
        public DWORD dwWaitHint;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct QUERY_SERVICE_CONFIG
    {
        public ServiceType dwServiceType;
        public StartType dwStartType;
        public ErrorControl dwErrorControl;
        public IntPtr lpBinaryPathName;
        public IntPtr lpLoadOrderGroup;
        public DWORD dwTagId;
        public IntPtr lpDependencies;
        public IntPtr lpServiceStartName;
        public IntPtr lpDisplayName;

        public string BinaryPathName
        {
            get { return lpBinaryPathName.ToUnicodeStr(); }
        }

        public string ServiceStartName
        {
            get { return lpServiceStartName.ToUnicodeStr(); }
        }

        public string DisplayName
        {
            get { return lpDisplayName.ToUnicodeStr(); }
        }

        public static uint Size
        {
            get { return 500; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_CONTROL_STATUS_REASON_PARAMS
    {
        public DWORD dwReason;
        public IntPtr pszComment;
        public SERVICE_STATUS_PROCESS ServiceStatus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_STATUS_PROCESS
    {
        public ServiceType dwServiceType;
        public ServiceStateEx dwCurrentState;
        public ServiceControlEx dwControlsAccepted;
        public DWORD dwWin32ExitCode;
        public DWORD dwServiceSpecificExitCode;
        public DWORD dwCheckPoint;
        public DWORD dwWaitHint;
        public DWORD dwProcessId;
        public ServiceFlags dwServiceFlags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENUM_SERVICE_STATUS_PROCESS
    {
        public IntPtr lpServiceName;
        public IntPtr lpDisplayName;
        public SERVICE_STATUS_PROCESS ServiceStatusProcess;

        public string ServiceName
        {
            get { return lpServiceName.ToUnicodeStr(); }
        }

        public string DisplayName
        {
            get { return lpDisplayName.ToUnicodeStr(); }
        }

        public static uint Size
        {
            get
            {
                return (uint)Marshal.SizeOf(
                    typeof(ENUM_SERVICE_STATUS_PROCESS));
            }
        }
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/dd405512(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SERVICE_TRIGGER
    {
        public DWORD dwTriggerType;
        public DWORD dwAction;
        public GUID* pTriggerSubtype;
        public DWORD cDataItems;
        public SERVICE_TRIGGER_SPECIFIC_DATA_ITEM* pDataItems;
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/dd405515(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_TRIGGER_SPECIFIC_DATA_ITEM
    {
        public DWORD dwDataType;
        public DWORD cbData;
        public IntPtr pData;
    }

    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms685126(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SC_ACTION
    {
        public DWORD Type;
        public DWORD Delay;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeOverlapped
    {
        public IntPtr InternalLow;
        public IntPtr InternalHigh;
        public int OffsetLow;
        public int OffsetHigh;
        public SafeEventHandle EventHandle;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ACL
    {
        public UCHAR AclRevision;
        public UCHAR Sbz1;
        public USHORT AclSize;
        public USHORT AceCount;
        public USHORT Sbz2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SID_IDENTIFIER_AUTHORITY
    {
        public fixed byte Value[6];
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct PREASON_CONTEXT
    {
        [FieldOffset(0)]
        public ULONG Version;

        [FieldOffset(4)]
        public DWORD Flags;

        [FieldOffset(8)]
        public string SimpleReasonString;

        [FieldOffset(8)]
        public HMODULE LocalizedReasonModule;

        [FieldOffset(12)]
        public ULONG LocalizedReasonId;

        [FieldOffset(16)]
        public ULONG ReasonStringCount;

        [FieldOffset(20)]
        public IntPtr ReasonStrings;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT
    {
        [FieldOffset(0)]
        public InputType type;
        [FieldOffset(4)]
        public MOUSEINPUT mi;
        [FieldOffset(4)]
        public KEYBDINPUT ki;
        [FieldOffset(4)]
        public HARDWAREINPUT hi;

        public static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public LONG dx;
        public LONG dy;
        public MouseEventDataXButtons mouseData;
        public MOUSEEVENTF dwFlags;
        public DWORD time;
        public ULONG_PTR dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public VirtualKeyShort wVk;
        public ScanCodeShort wScan;
        public KEYEVENTF dwFlags;
        public DWORD time;
        public ULONG_PTR dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public DWORD uMsg;
        public WORD wParamL;
        public WORD wParamH;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEINFO
    {
        public SafeIconHandle hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(SHFILEINFO)); }
        }
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct DNS_RECORD
    {
        public DNS_RECORD* pNext;
        public IntPtr pName;
        public QueryTypes wType;
        public WORD wDataLength;
        public DWORD DW;
        public DWORD dwTtl;
        public DWORD dwReserved;

        //public IntPtr pNameExchange;
        //public short wPreference;
        //public short Pad;

        public static DNS_RECORD* Instance
        {
            get { return (DNS_RECORD*)0; }
        }

        public string Name
        {
            get { return pName.ToUnicodeStr(); }
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct IP4_ARRAY
    {
        public DWORD AddrCount;
        public DWORD address;

        public static IP4_ARRAY fromAddress(string address)
        {
            var arr = new IP4_ARRAY
            {
                AddrCount = 1,
                address = ws2_32.inet_addr(address).s_addrres
            };
            return arr;
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct DNS_QUERY_REQUEST
    {
        public ULONG Version;
        public string QueryName;
        public QueryTypes QueryType;
        public QueryOptions64 QueryOptions;
        public DNS_ADDR_ARRAY* pDnsServerList;
        public ULONG InterfaceIndex;
        public IntPtr pQueryCompletionCallback;
        public PVOID pQueryContext;

    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DNS_ADDR_ARRAY
    {
        public DWORD MaxCount;
        public DWORD AddrCount;
        public DWORD Tag;
        public AddressFamilies Family;
        public WORD WordReserved;
        public DWORD Flags;
        public DWORD MatchFlag;
        public DWORD Reserved1;
        public DWORD Reserved2;
        public DNS_ADDR First;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_ADDR
    {
        /// <summary>
        /// i d k what the real size for this ?//?
        /// </summary>
        private const int DNS_ADDR_MAX_SOCKADDR_LENGTH = 256;
        public fixed CHAR MaxSa[DNS_ADDR_MAX_SOCKADDR_LENGTH];
        public fixed DWORD DnsAddrUserDword[8];
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_QUERY_RESULT
    {
        public ULONG Version;
        public string QueryName;
        public WORD QueryType;
        public ULONG64 QueryOptions;
        public DNS_ADDR_ARRAY* pDnsServerList;
        public ULONG InterfaceIndex;
        public IntPtr pQueryCompletionCallback;
        public PVOID pQueryContext;

    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DNS_QUERY_CANCEL
    {
        public ULONG Version;
        public Win32Error QueryStatus;
        public ULONG64 QueryOptions;
        public DNS_RECORD* pQueryRecords;
        public PVOID reserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_MESSAGE_BUFFER
    {
        public DNS_HEADER MessageHead;
        public CHAR First;
    }

    /// <summary>
    /// i dont like this struct ...
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms682059(v=vs.85).aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_HEADER
    {
        public WORD Xid;
        public BYTE Reserver;
        public WORD QuestionCount;
        public WORD AnswerCount;
        public WORD NameServerCount;
        public WORD AdditionalCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DNS_PROXY_INFORMATION
    {
        public ULONG version;
        public DnsProxyInformationType proxyInformationType;
        public IntPtr proxyName;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NETINFOSTRUCT
    {
        public DWORD cbStructure;
        public DWORD dwProviderVersion;
        public DWORD dwStatus;
        public DWORD dwCharacteristics;
        public ULONG_PTR dwHandle;
        public WORD wNetType;
        public DWORD dwPrinters;
        public DWORD dwDrives;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NETRESOURCE
    {
        public NetResourceScope dwScope;
        public NetResourceType dwType;
        public NetResourceDisplayType dwDisplayType;
        public NetResourceUsage dwUsage;
        public IntPtr lpLocalName;
        public IntPtr lpRemoteName;
        public IntPtr lpComment;
        public IntPtr lpProvider;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NETCONNECTINFOSTRUCT
    {
        public DWORD cbStructure;
        public DWORD dwFlags;
        public DWORD dwSpeed;
        public DWORD dwDelay;
        public DWORD dwOptDataSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CONNECTDLGSTRUCT
    {
        public DWORD cbStructure;
        public SafeWindowHandle hwndOwner;
        public NETRESOURCE* lpConnRes;
        public CONNDLG_FLAGS dwFlags;
        public DWORD dwDevNum;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISCDLGSTRUCT
    {
        public DWORD cbStructure;
        public SafeWindowHandle hwndOwner;
        public IntPtr lpLocalName;
        public IntPtr lpRemoteName;
        public DISC dwFlags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct FIXED_INFO
    {
        private const int MAX_HOSTNAME_LEN = 256;
        private const int MAX_DOMAIN_NAME_LEN = 128;
        private const int MAX_SCOPE_ID_LEN = 256;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HOSTNAME_LEN + 4)]
        public string HostName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DOMAIN_NAME_LEN + 4)]
        public string DomainName;

        public IP_ADDR_STRING* CurrentDnsServer;
        public IP_ADDR_STRING DnsServerList;
        public UINT NodeType;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SCOPE_ID_LEN + 4)]
        public string ScopeId;

        public BOOL EnableRouting;
        public BOOL EnableProxy;
        public BOOL EnableDns;

        public static uint Size
        {
            get { return (uint)Marshal.SizeOf(typeof(FIXED_INFO)); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SOCKET_SECURITY_SETTINGS
    {
        public SocketSecurityProtocol SecurityProtocol;
        public SecurityFlags SecurityFlags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SOCKET_PEER_TARGET_NAME
    {
        public SocketSecurityProtocol SecurityProtocol;
        public SOCKADDR_STORAGE PeerAddress;
        public ULONG PeerTargetNameStringLen;
        [MarshalAs(UnmanagedType.LPTStr, SizeConst = 250)]
        public string AllStrings;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SOCKADDR_STORAGE
    {
        private const int _SS_PAD1SIZE = 6;
        private const int _SS_PAD2SIZE = 112;

        public AddressFamilies ss_family;
        public fixed char __ss_pad1[_SS_PAD1SIZE];
        public Int64 __ss_align;
        public fixed char __ss_pad2[_SS_PAD2SIZE];
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DEVMODE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        public WORD dmSpecVersion;
        public WORD dmDriverVersion;
        public WORD dmSize;
        public WORD dmDriverExtra;
        public Union0 union0;
        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        public WORD dmLogPixels;
        public DWORD dmBitsPerPel;
        public DWORD dmPelsWidth;
        public DWORD dmPelsHeight;
        public DWORD dmNupOrDisplayFlags;
        public DWORD dmDisplayFrequency;
        public DWORD dmICMMethod;
        public DWORD dmICMIntent;
        public DWORD dmMediaType;
        public DWORD dmDitherType;
        public DWORD dmReserved1;
        public DWORD dmReserved2;
        public DWORD dmPanningWidth;
        public DWORD dmPanningHeight;

        [StructLayout(LayoutKind.Explicit)]
        public struct Union0
        {
            [FieldOffset(0)]
            public Sub1 sub1;
            [FieldOffset(0)]
            public Sub2 sub2;

            [StructLayout(LayoutKind.Sequential)]
            public struct Sub1
            {
                public short dmOrientation;
                public short dmPaperSize;
                public short dmPaperLength;
                public short dmPaperWidth;
                public short dmScale;
                public short dmCopies;
                public short dmDefaultSource;
                public short dmPrintQuality;

            }
            [StructLayout(LayoutKind.Sequential)]
            public struct Sub2
            {
                public LONG x;
                public LONG y;
                public DWORD dmDisplayOrientation;
                public DWORD dmDisplayFixedOutput;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TimeOut
    {
        public uint Milliseconds;

        public static TimeOut Ignore
        {
            get { return new TimeOut() { Milliseconds = 0 }; }
        }
        public static TimeOut Infinite
        {
            get { return new TimeOut() { Milliseconds = 0xFFFFFFFF }; }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Filetime
    {
        public DWORD dwLowDateTime;
        public DWORD dwHighDateTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BY_HANDLE_FILE_INFORMATION
    {
        public FileAttributes dwFileAttributes;
        public Filetime ftCreationTime;
        public Filetime ftLastAccessTime;
        public Filetime ftLastWriteTime;
        public DWORD dwVolumeSerialNumber;
        public DWORD nFileSizeHigh;
        public DWORD nFileSizeLow;
        public DWORD nNumberOfLinks;
        public DWORD nFileIndexHigh;
        public DWORD nFileIndexLow;
    }

    /// <summary>
    /// used with 
    /// GetFileInformationByHandleEx
    /// SetFileInformationByHandle
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct FileInfo
    {
        [FieldOffset(0)]
        public FILE_BASIC_INFO FileBasicInfo;
        [FieldOffset(0)]
        public FILE_ALLOCATION_INFO FileAllocationInfo;
        [FieldOffset(0)]
        public FILE_RENAME_INFO FileRenameInfo;
        [FieldOffset(0)]
        public FILE_END_OF_FILE_INFO FileEndOfFileInfo;
        [FieldOffset(0)]
        public FILE_IO_PRIORITY_HINT_INFO FileIoPriorityHintInfo;
        [FieldOffset(0)]
        public FILE_DISPOSITION_INFO FileDispositionInfo;
        [FieldOffset(0)]
        public FILE_STANDARD_INFO FileStandardInfo;
        [FieldOffset(0)]
        public FILE_NAME_INFO FileNameInfo;
        [FieldOffset(0)]
        public FILE_STREAM_INFO FileStreamInfo;
        [FieldOffset(0)]
        public FILE_COMPRESSION_INFO FileCompressionInfo;
        [FieldOffset(0)]
        public FILE_ATTRIBUTE_TAG_INFORMATION FileAttributeTagInfo;
        [FieldOffset(0)]
        public FILE_ID_BOTH_DIR_INFO FileIdBothDirectoryInfo;
        [FieldOffset(0)]
        public FILE_ID_BOTH_DIR_INFO FileIdBothDirectoryRestartInfo;
        [FieldOffset(0)]
        public FILE_REMOTE_PROTOCOL_INFO FileRemoteProtocolInfo;
        [FieldOffset(0)]
        public FILE_FULL_DIR_INFO FileFullDirectoryInfo;
        [FieldOffset(0)]
        public FILE_FULL_DIR_INFO FileFullDirectoryRestartInfo;
        [FieldOffset(0)]
        public FILE_STORAGE_INFO FileStorageInfo;
        [FieldOffset(0)]
        public FILE_ALIGNMENT_INFO FileAlignmentInfo;
        [FieldOffset(0)]
        public FILE_ID_INFO FileIdInfo;

        public static uint Size
        {
            get { return 1024; }
        }
    }

    public struct FILE_BASIC_INFO
    {
        public LARGE_INTEGER CreationTime;
        public LARGE_INTEGER LastAccessTime;
        public LARGE_INTEGER LastWriteTime;
        public LARGE_INTEGER ChangeTime;
        public FileAttributes FileAttributes;
    }
    public struct FILE_STANDARD_INFO
    {
        public LARGE_INTEGER AllocationSize;
        public LARGE_INTEGER EndOfFile;
        public DWORD NumberOfLinks;
        public BOOLEAN DeletePending;
        public BOOLEAN Directory;
    }
    public unsafe struct FILE_NAME_INFO
    {
        public DWORD FileNameLength;
        public fixed WCHAR fileName[1];

        public string FileName
        {
            get
            {
                fixed (char* ch = fileName)
                {
                    return new string(ch, 0, (int)FileNameLength / 2);
                }
            }
        }
    }
    public unsafe struct FILE_STREAM_INFO
    {
        public DWORD NextEntryOffset;
        public DWORD StreamNameLength;
        public LARGE_INTEGER StreamSize;
        public LARGE_INTEGER StreamAllocationSize;
        public fixed WCHAR streamName[1];

        public string FileName
        {
            get
            {
                fixed (char* ch = streamName)
                {
                    return new string(ch, 0, (int)StreamNameLength / 2);
                }
            }
        }
    }
    public struct FILE_IO_PRIORITY_HINT_INFO
    {
        public PRIORITY_HINT PriorityHint;
    }
    public struct FILE_END_OF_FILE_INFO
    {
        public LARGE_INTEGER EndOfFile;
    }
    public struct FILE_ALLOCATION_INFO
    {
        public LARGE_INTEGER AllocationSize;
    }
    public struct FILE_DISPOSITION_INFO
    {
        public BOOL DeleteFile;
    }
    public unsafe struct FILE_RENAME_INFO
    {
        public BOOL ReplaceIfExists;
        public HANDLE RootDirectory;
        public DWORD FileNameLength;
        public fixed WCHAR fileName[1];

        public string FileName
        {
            get
            {
                fixed (char* ch = fileName)
                {
                    return new string(ch, 0, (int)FileNameLength / 2);
                }
            }
        }
    }
    public unsafe struct FILE_ID_INFO
    {
        public ULONGLONG VolumeSerialNumber;
        public fixed UCHAR FileId[16];
    }
    public struct FILE_ALIGNMENT_INFO
    {
        public ULONG AlignmentRequirement;
    }
    public struct FILE_STORAGE_INFO
    {
        public ULONG LogicalBytesPerSector;
        public ULONG PhysicalBytesPerSectorForAtomicity;
        public ULONG PhysicalBytesPerSectorForPerformance;
        public ULONG FileSystemEffectivePhysicalBytesPerSectorForAtomicity;
        public ULONG Flags;
        public ULONG ByteOffsetForSectorAlignment;
        public ULONG ByteOffsetForPartitionAlignment;
    }
    public unsafe struct FILE_FULL_DIR_INFO
    {
        public ULONG NextEntryOffset;
        public ULONG FileIndex;
        public LARGE_INTEGER CreationTime;
        public LARGE_INTEGER LastAccessTime;
        public LARGE_INTEGER LastWriteTime;
        public LARGE_INTEGER ChangeTime;
        public LARGE_INTEGER EndOfFile;
        public LARGE_INTEGER AllocationSize;
        public ULONG FileAttributes;
        public ULONG FileNameLength;
        public ULONG EaSize;
        public fixed WCHAR fileName[1];

        public string FileName
        {
            get
            {
                fixed (char* ch = fileName)
                {
                    return new string(ch, 0, (int)FileNameLength / 2);
                }
            }
        }
    }
    public unsafe struct FILE_REMOTE_PROTOCOL_INFO
    {
        public USHORT StructureVersion;
        public USHORT StructureSize;
        public ULONG Protocol;
        public USHORT ProtocolMajorVersion;
        public USHORT ProtocolMinorVersion;
        public USHORT ProtocolRevision;
        public fixed USHORT Reserved[8];
        public DWORD Flags;
    }
    public unsafe struct FILE_ID_BOTH_DIR_INFO
    {
        public DWORD NextEntryOffset;
        public DWORD FileIndex;
        public LARGE_INTEGER CreationTime;
        public LARGE_INTEGER LastAccessTime;
        public LARGE_INTEGER LastWriteTime;
        public LARGE_INTEGER ChangeTime;
        public LARGE_INTEGER EndOfFile;
        public LARGE_INTEGER AllocationSize;
        public FileAttributes FileAttributes;
        public DWORD FileNameLength;
        public DWORD EaSize;
        public byte ShortNameLength;
        public fixed WCHAR ShortName[12];
        public LARGE_INTEGER FileId;
        public fixed WCHAR fileName[1];

        public string FileName
        {
            get
            {
                fixed (char* ch = fileName)
                {
                    return new string(ch, 0, (int)FileNameLength / 2);
                }
            }
        }
    }
    public unsafe struct FILE_COMPRESSION_INFO
    {
        public LARGE_INTEGER CompressedFileSize;
        public WORD CompressionFormat;
        public UCHAR CompressionUnitShift;
        public UCHAR ChunkShift;
        public UCHAR ClusterShift;
        public fixed UCHAR Reserved[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OVERLAPPED
    {
        public IntPtr InternalLow;
        public IntPtr InternalHigh;
        public int OffsetLow;
        public int OffsetHigh;
        public SafeEventHandle EventHandle;

        public static OVERLAPPED Initialize()
        {
            return new OVERLAPPED
            {
                Event = kernel32.CreateEvent(IntPtr.Zero, false, false, null)
            };
        }

        public SafeEventHandle Event
        {
            get { return EventHandle; }
            set { EventHandle = value; }
        }
    }

    public struct CallbackEnvirment
    {
        public uint Version;
        public SafeThreadpool Pool;
        public SafeThreadpoolCleanUpGroup CleanupGroup;

        public IntPtr CleanupGroupCancelCallback;
        //public CleanupGroupCancelCallback CleanupGroupCancelCallback;

        public IntPtr RaceDll;

        public IntPtr ActivationContext;
        //struct _ACTIVATION_CONTEXT *ActivationContext;

        public IntPtr FinalizationCallback;
        //public SimpleCallback FinalizationCallback;

        public uint Flags;
        //union {
        //    DWORD                          Flags;
        //    struct {
        //        DWORD                      LongFunction :  1;
        //        DWORD                      Persistent   :  1;
        //        DWORD                      Private      : 30;
        //    } s;
        //} u; 

        public TpCallbackPriority CallbackPriority;
        public uint Size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct USEROBJECTFLAGS
    {
        public BOOL fInherit;
        public BOOL fReserved;
        public DWORD dwFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ShellExecuteInfo
    {
        public int cbSize;
        public int fMask;
        public SafeWindowHandle hwnd;
        public IntPtr lpVerb;
        public IntPtr lpFile;
        public IntPtr lpParameters;
        public IntPtr lpDirectory;
        public ShowWindowCommand nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        public IntPtr lpClass;
        public IntPtr hkeyClass;
        public int dwHotKey;
        public IntPtr hIcon;
        public IntPtr hProcess;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct EXPLICIT_ACCESS
    {
        public ACCESS_MASK grfAccessPermissions;
        public ACCESS_MODE grfAccessMode;
        public AceFlags grfInheritance;
        public TRUSTEE Trustee;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HEADER
    {
        public AceType AceType;
        public AceFlags AceFlags;
        public WORD AceSize;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACE
    {
        public HEADER Header;
        public ACCESS_MASK Mask;
        public uint SidStart;

        public bool IsValidType
        {
            get
            {
                if (Header.AceType == AceType.ACCESS_ALLOWED)
                    return true;
                if (Header.AceType == AceType.ACCESS_DENIED)
                    return true;
                if (Header.AceType == AceType.SYSTEM_AUDIT)
                    return true;

                return false;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACE_OBJECT
    {
        public HEADER Header;
        public ACCESS_MASK Mask;
        public ACE_OBJECT_FLAGS Flags;
        public GUID ObjectType;
        public GUID InheritedObjectType;
        public DWORD SidStart;

        public bool IsValidType
        {
            get
            {
                if (Header.AceType == (AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_OBJECT))
                    return true;
                if (Header.AceType == (AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_OBJECT))
                    return true;
                if (Header.AceType == (AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_OBJECT))
                    return true;

                return false;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACE_CALLBACK
    {
        public HEADER Header;
        public ACCESS_MASK Mask;
        public DWORD SidStart;

        public bool IsValidType
        {
            get
            {
                if (Header.AceType == (AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK))
                    return true;
                if (Header.AceType == (AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK))
                    return true;
                if (Header.AceType == (AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK))
                    return true;

                return false;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACE_CALLBACK_OBJECT
    {
        public HEADER Header;
        public ACCESS_MASK Mask;
        public DWORD Flags;
        public GUID ObjectType;
        public GUID InheritedObjectType;
        public DWORD SidStart;

        public bool IsValidType
        {
            get
            {
                if (Header.AceType == (AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK | AceType.ACCESS_ALLOWED_OBJECT))
                    return true;
                if (Header.AceType == (AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK | AceType.ACCESS_DENIED_OBJECT))
                    return true;
                if (Header.AceType == (AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK | AceType.SYSTEM_AUDIT_OBJECT))
                    return true;

                return false;
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACE_MANDATORY_LABEL
    {
        public HEADER Header;
        public ACCESS_MASK Mask;
        public DWORD SidStart;

        public bool IsValidType
        {
            get { return Header.AceType == AceType.SYSTEM_MANDATORY_LABEL; }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ACE_HEADER_BASE
    {
        [FieldOffset(0)]
        public ACE Ace;
        [FieldOffset(0)]
        public ACE_OBJECT AceObject;
        [FieldOffset(0)]
        public ACE_CALLBACK AceCallback;
        [FieldOffset(0)]
        public ACE_CALLBACK_OBJECT AceCallbackObject;
        [FieldOffset(0)]
        public ACE_MANDATORY_LABEL AceMandatoryLabel;

        public uint Size
        {
            get
            {
                if (Ace.IsValidType) return (uint)Ace.Header.AceSize;
                if (AceObject.IsValidType) return (uint)AceObject.Header.AceSize;
                if (AceCallback.IsValidType) return (uint)AceCallback.Header.AceSize;
                if (AceCallbackObject.IsValidType) return (uint)AceCallbackObject.Header.AceSize;
                if (AceMandatoryLabel.IsValidType) return (uint)AceMandatoryLabel.Header.AceSize;
                return 0;
            }
        }

        public unsafe SafeSidHandle Sid
        {
            get
            {
                if (Ace.IsValidType)
                {
                    fixed (uint* sid = &Ace.SidStart)
                    {
                        return new SafeSidHandle((IntPtr)sid);
                    }
                }
                if (AceObject.IsValidType)
                {
                    fixed (uint* sid = &AceObject.SidStart)
                    {
                        return new SafeSidHandle((IntPtr)sid);
                    }
                }
                if (AceCallback.IsValidType)
                {
                    fixed (uint* sid = &AceCallback.SidStart)
                    {
                        return new SafeSidHandle((IntPtr)sid);
                    }
                }
                if (AceCallbackObject.IsValidType)
                {
                    fixed (uint* sid = &AceCallbackObject.SidStart)
                    {
                        return new SafeSidHandle((IntPtr)sid);
                    }
                }
                return new SafeSidHandle(0);
            }
            set
            {
                if (Ace.IsValidType)
                {
                    fixed (uint* sid = &Ace.SidStart)
                    {
                        advapi32.CopySid(
                            value.Length,
                            new SafeSidHandle((IntPtr)sid),
                            value);
                    }
                }
                if (AceObject.IsValidType)
                {
                    fixed (uint* sid = &AceObject.SidStart)
                    {
                        advapi32.CopySid(
                            value.Length,
                            new SafeSidHandle((IntPtr)sid),
                            value);
                    }
                }
                if (AceCallback.IsValidType)
                {
                    fixed (uint* sid = &AceCallback.SidStart)
                    {
                        advapi32.CopySid(
                            value.Length,
                            new SafeSidHandle((IntPtr)sid),
                            value);
                    }
                }
                if (AceCallbackObject.IsValidType)
                {
                    fixed (uint* sid = &AceCallbackObject.SidStart)
                    {
                        advapi32.CopySid(
                            value.Length,
                            new SafeSidHandle((IntPtr)sid),
                            value);
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct TRUSTEE
    {
        public TRUSTEE* pMultipleTrustee;
        public MULTIPLE_TRUSTEE_OPERATION MultipleTrusteeOperation;
        public TRUSTEE_FORM TrusteeForm;
        public TRUSTEE_TYPE TrusteeType;
        public IntPtr ptstrName;

        public string Name
        {
            get { return ptstrName.ToUnicodeStr(); }
        }

        public OBJECTS_AND_SID ObjectsAndSid
        {
            get { return *(OBJECTS_AND_SID*)ptstrName; }
        }

        public OBJECTS_AND_NAME ObjectsAndName
        {
            get { return *(OBJECTS_AND_NAME*)ptstrName; }
        }

        public SafeSidHandle Sid
        {
            get { return new SafeSidHandle(ptstrName); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OBJECTS_AND_NAME
    {
        public ObjectPresent ObjectsPresent;
        public SE_OBJECT_TYPE ObjectType;
        public IntPtr objectTypeName;
        public IntPtr inheritedObjectTypeName;
        public IntPtr ptstrName;

        public string ObjectTypeName
        {
            get { return objectTypeName.ToUnicodeStr(); }
        }

        public string InheritedObjectTypeName
        {
            get { return inheritedObjectTypeName.ToUnicodeStr(); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OBJECTS_AND_SID
    {
        public ObjectPresent ObjectsPresent;
        public GUID ObjectTypeGuid;
        public GUID InheritedObjectTypeGuid;
        public SafeSidHandle pSid;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_DESCRIPTOR
    {
        public BYTE Revision;
        public BYTE Sbz1;
        public SECURITY_DESCRIPTOR_CONTROL Control;
        public SafeSidHandle Owner;
        public SafeSidHandle Group;
        public SafeAclHandle Sacl;
        public SafeAclHandle Dacl;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACL_SIZE_INFORMATION
    {
        public DWORD AceCount;
        public DWORD AclBytesInUse;
        public DWORD AclBytesFree;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ACL_REVISION_INFORMATION
    {
        public DWORD AclRevision;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AUDIT_POLICY_INFORMATION
    {
        public GUID AuditSubCategoryGuid;
        public ULONG AuditingInformation;
        public GUID AuditCategoryGuid;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct POLICY_AUDIT_SID_ARRAY
    {
        public ULONG UsersCount;
        public SafeSidHandle* UserSidArray;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public SafeWindowHandle hwnd;
        public UINT message;
        public IntPtr wParam;
        public IntPtr lParam;
        public DWORD time;
        public POINT pt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASS
    {
        public CS style;
        public WindowProc lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public HINSTANCE hInstance;
        public IntPtr hIcon; // HICON
        public IntPtr hCursor; // HCURSOR
        public IntPtr hbrBackground; // HBRUSH
        public string lpszMenuName; // String
        public string lpszClassName; // String
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASSEX
    {
        public uint cbSize;
        public CS style;
        public WindowProc lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public HINSTANCE hInstance;
        public IntPtr hIcon; // HICON
        public IntPtr hCursor; // HCURSOR
        public IntPtr hbrBackground; // HBRUSH
        public string lpszMenuName; // String
        public string lpszClassName; // String
        public IntPtr hIconSm; // HICON
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThumbButton
    {
        /// <summary>
        /// WPARAM value for a THUMBBUTTON being clicked.
        /// </summary>
        public const int Clicked = 0x1800;

        public ThumbButtonMask Mask;
        public uint Id;
        public uint Bitmap;
        public IntPtr Icon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string Tip;
        public ThumbButtonOptions Flags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SERVICE_NOTIFY
    {
        public DWORD dwVersion; // 0x2
        public ScNotifyCallback pfnNotifyCallback;
        public PVOID pContext;
        public DWORD dwNotificationStatus;
        public SERVICE_STATUS_PROCESS ServiceStatus;
        public DWORD dwNotificationTriggered;
        public IntPtr pszServiceNames;

        public string ServiceNames
        {
            get { return pszServiceNames == IntPtr.Zero ? null : pszServiceNames.ToUnicodeStr(); }
            set { pszServiceNames = Marshal.StringToHGlobalUni(value); }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_BLURBEHIND
    {
        public DWM_BB dwFlags;
        public BOOL fEnable;
        public SafeRegionHandle hRgnBlur;
        public BOOL fTransitionOnMaximized;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_THUMBNAIL_PROPERTIES
    {
        public DWM_TNP dwFlags;
        public RECT rcDestination;
        public RECT rcSource;
        public BYTE opacity;
        public BOOL fVisible;
        public BOOL fSourceClientAreaOnly;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IP_OPTION_INFORMATION
    {
        public byte Ttl;
        public byte Tos;
        public byte Flags;
        public byte OptionsSize;
        public IntPtr OptionsData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICMP_ECHO_REPLY
    {
        public in_addr Address;
        public IP_STATUS Status;
        public ULONG RoundTripTime;
        public USHORT DataSize;
        public USHORT Reserved;
        public PVOID Data;
        public IP_OPTION_INFORMATION Options;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ICMPV6_ECHO_REPLY
    {
        public IPV6_ADDRESS_EX Address;
        public IP_STATUS Status;
        public int RoundTripTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_IPSTATS
    {
        public DWORD dwForwarding;
        public DWORD dwDefaultTTL;
        public DWORD dwInReceives;
        public DWORD dwInHdrErrors;
        public DWORD dwInAddrErrors;
        public DWORD dwForwDatagrams;
        public DWORD dwInUnknownProtos;
        public DWORD dwInDiscards;
        public DWORD dwInDelivers;
        public DWORD dwOutRequests;
        public DWORD dwRoutingDiscards;
        public DWORD dwOutDiscards;
        public DWORD dwOutNoRoutes;
        public DWORD dwReasmTimeout;
        public DWORD dwReasmReqds;
        public DWORD dwReasmOks;
        public DWORD dwReasmFails;
        public DWORD dwFragOks;
        public DWORD dwFragFails;
        public DWORD dwFragCreates;
        public DWORD dwNumIf;
        public DWORD dwNumAddr;
        public DWORD dwNumRoutes;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct FILE_NOTIFY_INFORMATION
    {
        public DWORD NextEntryOffset;
        public FILE_ACTION Action;
        public DWORD FileNameLength;
        public fixed WCHAR fileName[1024];

        public string FileName
        {
            get
            {
                fixed (char* fileNamePtr = fileName)
                    return new string(fileNamePtr);
            }
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct UDP_TABLE_INFO
    {
        [FieldOffset(0)]
        public MIB_UDPTABLE BASIC;

        [FieldOffset(0)]
        public MIB_UDPTABLE_OWNER_PID OWNER_PID;

        [FieldOffset(0)]
        public MIB_UDPTABLE_OWNER_MODULE OWNER_MODULE;

        [FieldOffset(0)]
        public MIB_UDP6TABLE_OWNER_PID OWNER_PID_IPV6;

        [FieldOffset(0)]
        public MIB_UDP6TABLE_OWNER_MODULE OWNER_MODULE_IPV6;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct TCP_TABLE_INFO
    {
        [FieldOffset(0)]
        public MIB_TCPTABLE BASIC_LISTENER;

        [FieldOffset(0)]
        public MIB_TCPTABLE BASIC_CONNECTIONS;

        [FieldOffset(0)]
        public MIB_TCPTABLE BASIC_ALL;

        [FieldOffset(0)]
        public MIB_TCPTABLE_OWNER_PID PID_LISTENER;

        [FieldOffset(0)]
        public MIB_TCPTABLE_OWNER_PID PID_CONNECTIONS;

        [FieldOffset(0)]
        public MIB_TCPTABLE_OWNER_PID PID_ALL;

        [FieldOffset(0)]
        public MIB_TCP6TABLE_OWNER_PID PID_LISTENER_IPV6;

        [FieldOffset(0)]
        public MIB_TCP6TABLE_OWNER_PID PID_CONNECTIONS_IPV6;

        [FieldOffset(0)]
        public MIB_TCP6TABLE_OWNER_PID PID_ALL_IPV6;

        [FieldOffset(0)]
        public MIB_TCPTABLE_OWNER_MODULE MODULE_LISTENER;

        [FieldOffset(0)]
        public MIB_TCPTABLE_OWNER_MODULE MODULE_CONNECTIONS;

        [FieldOffset(0)]
        public MIB_TCPTABLE_OWNER_MODULE MODULE_ALL;

        [FieldOffset(0)]
        public MIB_TCP6TABLE_OWNER_MODULE MODULE_CONNECTIONS_IPV6;

        [FieldOffset(0)]
        public MIB_TCP6TABLE_OWNER_MODULE MODULE_LISTENER_IPV6;

        [FieldOffset(0)]
        public MIB_TCP6TABLE_OWNER_MODULE MODULE_ALL_IPV6;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DATA_BLOB
    {
        public DWORD cbData;
        public IntPtr pbData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVINFO_DATA
    {
        public DWORD cbSize;
        public GUID ClassGuid;
        public DWORD DevInst;
        public ULONG_PTR Reserved;
    }

    [StructLayout(LayoutKind.Sequential,
        Pack = 1 /*8 in X64*/)]
    public struct SP_DRVINFO_DETAIL_DATA
    {
        public int cbSize;
        public FILETIME InfDate;
        public DWORD CompatIDsOffset;
        public DWORD CompatIDsLength;
        public ULONG_PTR Reserved;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string SectionName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string InfFileName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string DrvDescription;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string HardwareID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVICE_INTERFACE_DATA
    {
        public DWORD cbSize;
        public GUID InterfaceClassGuid;
        public DWORD Flags;
        public ULONG_PTR Reserved;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        public DWORD cbSize;
        public fixed byte devicePath[256];

        public string DevicePath
        {
            get
            {
                string devPath = null;
                fixed (byte* charPtr = devicePath)
                {
                    var countTo = 0;
                    for (var i = 0; i < 256; i++)
                    {
                        try
                        {
                            if (charPtr[i] == '}')
                                countTo = i;
                        }
                        catch (AccessViolationException)
                        {
                            return null;
                        }
                    }

                    if (countTo > 0)
                    {
                        var arr = new byte[countTo + 1];
                        for (var i = 0; i < arr.Length; i++)
                            arr[i] = charPtr[i];
                        devPath = Encoding.ASCII.GetString(arr);
                    }
                }
                return devPath;
            }
        }

        public SafeFileHandle FileHandle
        {
            get
            {
                return kernel32.CreateFile(
                    DevicePath,
                    0x0, 0x0, IntPtr.Zero,
                    FileMode.Open,
                    (FileAttributes)0x0, IntPtr.Zero);
            }
        }

        public override LPCTSTR ToString()
        {
            return DevicePath;
        }
    }

    [StructLayout(LayoutKind.Sequential,
        CharSet = CharSet.Ansi,
        Pack = 4)]
    public struct SP_DRVINFO_DATA
    {
        public int cbSize;
        public int DriverType;
        public IntPtr Reserved;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Description;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string MfgName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string ProviderName;

        public Filetime DriverDate;
        public ulong DriverVersion;
    }

    public struct SP_DRVINFO_EX
    {
        public bool IsValid;
        public SP_DRVINFO_DATA InfoData;
        public SP_DRVINFO_DETAIL_DATA DetailData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVINSTALL_PARAMS
    {
        public Int32 cbSize;
        public Int32 Flags;
        public Int32 FlagsEx;
        public SafeWindowHandle hwndParent;
        public IntPtr InstallMsgHandler;
        public IntPtr InstallMsgHandlerContext;
        public IntPtr FileQueue;
        public IntPtr ClassInstallReserved;
        public int Reserved;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string DriverPath;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DRVINSTALL_PARAMS
    {
        public DWORD cbSize;
        public DWORD Rank;
        public DWORD Flags;
        public DWORD_PTR PrivateData;
        public DWORD Reserved;
    }

    //
    // Class installation parameters header.  This must be the first field of any
    // class install parameter structure.  The InstallFunction field must be set to
    // the function code corresponding to the structure, and the cbSize field must
    // be set to the size of the header structure.  E.g.,
    //
    // SP_ENABLECLASS_PARAMS EnableClassParams;
    //
    // EnableClassParams.ClassInstallHeader.cbSize = sizeof(SP_CLASSINSTALL_HEADER);
    // EnableClassParams.ClassInstallHeader.InstallFunction = DIF_ENABLECLASS;
    //

    public struct SP_CLASSINSTALL_HEADER
    {
        public DWORD cbSize;
        public DIF InstallFunction;
    }

    //
    // Structure corresponding to a DIF_PROPERTYCHANGE install function.
    //

    public struct SP_PROPCHANGE_PARAMS
    {
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;
        public DICS StateChange;
        public DICS_FLAG Scope;
        public DWORD HwProfile;
    }

    //
    // Structure corresponding to the DIF_POWERMESSAGEWAKE install function
    //

    public struct SP_POWERMESSAGEWAKE_PARAMS
    {
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256 * 2)]
        public string PowerMessageWake;
    }

    //
    // Structure corresponding to a DIF_REMOVE install function.
    //

    public struct SP_REMOVEDEVICE_PARAMS
    {
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;
        public DICS_FLAG Scope;
        public DWORD HwProfile;
    }

    //
    // Structure corresponding to a DIF_SELECTDEVICE install function.
    //

    public struct SP_SELECTDEVICE_PARAMS
    {
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
        public string Title;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Instructions;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string ListLabel;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string SubTitle;

        public short Reserved;
    }

    //
    // Structure corresponding to the DIF_TROUBLESHOOTER install function
    //

    public struct SP_TROUBLESHOOTER_PARAMS
    {
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string ChmFile;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string HtmlTroubleShooter;
    }

    //
    // Structure corresponding to a DIF_UNREMOVE install function.
    //

    public struct SP_UNREMOVEDEVICE_PARAMS
    {
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;

        // 0x00000002
        public DWORD Scope;

        public DWORD HwProfile;
    }

    public struct DEVPROPKEY
    {
        public GUID fmtid;
        public ULONG pid;
    };

    public struct SP_DEVINFO_LIST_DETAIL_DATA
    {
        public DWORD cbSize;
        public GUID ClassGuid;
        public HANDLE RemoteMachineHandle;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260 + 3)]
        public string RemoteMachineName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CONFLICT_DETAILS
    {
        public ULONG ulSize;
        public ULONG ulMask;
        public DEVINST dnDevInst;
        public uint rdResDes;
        public ULONG ulFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDescription;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INSTALLERINFO
    {
        public IntPtr ApplicationId;
        public IntPtr DisplayName;
        public IntPtr ProductName;
        public IntPtr MfgName;
    }
    #endregion
}