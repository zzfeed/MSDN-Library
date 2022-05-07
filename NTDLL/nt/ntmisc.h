#ifndef NTMISC_H
#define NTMISC_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtRaiseException raises an exception.
NTSYSAPI
NTSTATUS
NTAPI
NtRaiseException(
	IN PEXCEPTION_RECORD ExceptionRecord,
	IN PCONTEXT Context,
	IN BOOLEAN FirstChance
	);

// ZwRaiseException raises an exception.
NTSYSAPI
NTSTATUS
NTAPI
ZwRaiseException(
	IN PEXCEPTION_RECORD ExceptionRecord,
	IN PCONTEXT Context,
	IN BOOLEAN FirstChance
	);

// NtContinue resumes execution of a saved execution context.
NTSYSAPI
NTSTATUS
NTAPI
NtContinue(
	IN PCONTEXT Context,
	IN BOOLEAN TestAlert
	);

// ZwContinue resumes execution of a saved execution context.
NTSYSAPI
NTSTATUS
NTAPI
ZwContinue(
	IN PCONTEXT Context,
	IN BOOLEAN TestAlert
	);

#if _WIN32_WINNT < 0x0500

// NtW32Call calls one of a predefined set of user mode functions.
NTSYSAPI
NTSTATUS
NTAPI
NtW32Call(
	IN ULONG RoutineIndex,
	IN PVOID Argument,
	IN ULONG ArgumentLength,
	OUT PVOID *Result OPTIONAL,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwW32Call calls one of a predefined set of user mode functions.
NTSYSAPI
NTSTATUS
NTAPI
ZwW32Call(
	IN ULONG RoutineIndex,
	IN PVOID Argument,
	IN ULONG ArgumentLength,
	OUT PVOID *Result OPTIONAL,
	OUT PULONG ResultLength OPTIONAL
	);

#endif

// NtCallbackReturn returns from a function called by NtW32Call.
NTSYSAPI
NTSTATUS
NTAPI
NtCallbackReturn(
	IN PVOID Result OPTIONAL,
	IN ULONG ResultLength,
	IN NTSTATUS Status
	);

// ZwCallbackReturn returns from a function called by ZwW32Call.
NTSYSAPI
NTSTATUS
NTAPI
ZwCallbackReturn(
	IN PVOID Result OPTIONAL,
	IN ULONG ResultLength,
	IN NTSTATUS Status
	);

#if _WIN32_WINNT < 0x0500

// NtSetLowWaitHighThread effectively invokes NtSetLowWaitHighEventPair on the
// event pair of the thread.
NTSYSAPI
NTSTATUS
NTAPI
NtSetLowWaitHighThread(
	VOID
	);

// ZwSetLowWaitHighThread effectively invokes ZwSetLowWaitHighEventPair on the
// event pair of the thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetLowWaitHighThread(
	VOID
	);

// NtSetHighWaitLowThread effectively invokes NtSetHighWaitLowEventPair on the
// event pair of the thread.
NTSYSAPI
NTSTATUS
NTAPI
NtSetHighWaitLowThread(
	VOID
	);

// ZwSetHighWaitLowThread effectively invokes ZwSetHighWaitLowEventPair on the
// event pair of the thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetHighWaitLowThread(
	VOID
	);

#endif

// NtLoadDriver loads a device driver.
NTSYSAPI
NTSTATUS
NTAPI
NtLoadDriver(
	IN PUNICODE_STRING DriverServiceName
	);

// ZwLoadDriver loads a device driver.
NTSYSAPI
NTSTATUS
NTAPI
ZwLoadDriver(
	IN PUNICODE_STRING DriverServiceName
	);

// NtUnloadDriver unloads a device driver.
NTSYSAPI
NTSTATUS
NTAPI
NtUnloadDriver(
	IN PUNICODE_STRING DriverServiceName
	);

// ZwUnloadDriver unloads a device driver.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnloadDriver(
	IN PUNICODE_STRING DriverServiceName
	);

// NtFlushInstructionCache flushes the instruction cache of a process.
NTSYSAPI
NTSTATUS
NTAPI
NtFlushInstructionCache(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress OPTIONAL,
	IN ULONG FlushSize
	);

// ZwFlushInstructionCache flushes the instruction cache of a process.
NTSYSAPI
NTSTATUS
NTAPI
ZwFlushInstructionCache(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress OPTIONAL,
	IN ULONG FlushSize
	);

// NtFlushWriteBuffer flushes the write buffer.
NTSYSAPI
NTSTATUS
NTAPI
NtFlushWriteBuffer(
	VOID
	);

// ZwFlushWriteBuffer flushes the write buffer.
NTSYSAPI
NTSTATUS
NTAPI
ZwFlushWriteBuffer(
	VOID
	);

// NtQueryDefaultLocale retrieves the default locale.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDefaultLocale(
	IN BOOLEAN ThreadOrSystem,
	OUT PLCID Locale
	);

// NtQueryDefaultLocale retrieves the default locale.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDefaultLocale(
	IN BOOLEAN ThreadOrSystem,
	OUT PLCID Locale
	);

// ZwQueryDefaultLocale retrieves the default locale.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryDefaultLocale(
	IN BOOLEAN ThreadOrSystem,
	OUT PLCID Locale
	);

// NtSetDefaultLocale sets the default locale.
NTSYSAPI
NTSTATUS
NTAPI
NtSetDefaultLocale(
	IN BOOLEAN ThreadOrSystem,
	IN LCID Locale
	);

// ZwSetDefaultLocale sets the default locale.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetDefaultLocale(
	IN BOOLEAN ThreadOrSystem,
	IN LCID Locale
	);

#if _WIN32_WINNT >= 0x0500

// NtQueryDefaultUILanguage retrieves the default user interface language identifier.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDefaultUILanguage(
	OUT PLANGID LanguageId
	);

// ZwQueryDefaultUILanguage retrieves the default user interface language identifier.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryDefaultUILanguage(
	OUT PLANGID LanguageId
	);

// NtSetDefaultUILanguage sets the default user interface language identifier.
NTSYSAPI
NTSTATUS
NTAPI
NtSetDefaultUILanguage(
	IN LANGID LanguageId
	);

// ZwSetDefaultUILanguage sets the default user interface language identifier.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetDefaultUILanguage(
	IN LANGID LanguageId
	);

// NtQueryInstallUILanguage retrieves the installation user interface language identifier.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInstallUILanguage(
	OUT PLANGID LanguageId
	);

// ZwQueryInstallUILanguage retrieves the installation user interface language identifier.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInstallUILanguage(
	OUT PLANGID LanguageId
	);

#endif

// NtAllocateLocallyUniqueId allocates a locally unique identifier.
NTSYSAPI
NTSTATUS
NTAPI
NtAllocateLocallyUniqueId(
	OUT PLUID Luid
	);


// ZwAllocateLocallyUniqueId allocates a locally unique identifier.
NTSYSAPI
NTSTATUS
NTAPI
ZwAllocateLocallyUniqueId(
	OUT PLUID Luid
	);

#if _WIN32_WINNT >= 0x0500

// NtAllocateUuids allocates some of the components of a universally unique identifier.
NTSYSAPI
NTSTATUS
NTAPI
NtAllocateUuids(
	OUT PLARGE_INTEGER UuidLastTimeAllocated,
	OUT PULONG UuidDeltaTime,
	OUT PULONG UuidSequenceNumber,
	OUT PUCHAR UuidSeed
	);

// ZwAllocateUuids allocates some of the components of a universally unique identifier.
NTSYSAPI
NTSTATUS
NTAPI
ZwAllocateUuids(
	OUT PLARGE_INTEGER UuidLastTimeAllocated,
	OUT PULONG UuidDeltaTime,
	OUT PULONG UuidSequenceNumber,
	OUT PUCHAR UuidSeed
	);

#else

// NtAllocateUuids allocates some of the components of a universally unique identifier.
NTSYSAPI
NTSTATUS
NTAPI
NtAllocateUuids(
	OUT PLARGE_INTEGER UuidLastTimeAllocated,
	OUT PULONG UuidDeltaTime,
	OUT PULONG UuidSequenceNumber
	);

// ZwAllocateUuids allocates some of the components of a universally unique identifier.
NTSYSAPI
NTSTATUS
NTAPI
ZwAllocateUuids(
	OUT PLARGE_INTEGER UuidLastTimeAllocated,
	OUT PULONG UuidDeltaTime,
	OUT PULONG UuidSequenceNumber
	);

#endif

#if _WIN32_WINNT >= 0x0500

// NtSetUuidSeed sets the universally unique identifier seed.
NTSYSAPI
NTSTATUS
NTAPI
NtSetUuidSeed(
	IN PUCHAR UuidSeed
	);


// ZwSetUuidSeed sets the universally unique identifier seed.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetUuidSeed(
	IN PUCHAR UuidSeed
	);

#endif

// NtRaiseHardError displays a message box containing an error message.
NTSYSAPI
NTSTATUS
NTAPI
NtRaiseHardError(
	IN NTSTATUS Status,
	IN ULONG NumberOfArguments,
	IN ULONG StringArgumentsMask,
	IN PULONG_PTR Arguments,
	IN HARDERROR_RESPONSE_OPTION ResponseOption,
	OUT PHARDERROR_RESPONSE Response
	);

// ZwRaiseHardError displays a message box containing an error message.
NTSYSAPI
NTSTATUS
NTAPI
ZwRaiseHardError(
	IN NTSTATUS Status,
	IN ULONG NumberOfArguments,
	IN ULONG StringArgumentsMask,
	IN PULONG_PTR Arguments,
	IN HARDERROR_RESPONSE_OPTION ResponseOption,
	OUT PHARDERROR_RESPONSE Response
	);

// NtSetDefaultHardErrorPort sets the default hard error port.
NTSYSAPI
NTSTATUS
NTAPI
NtSetDefaultHardErrorPort(
	IN HANDLE PortHandle
	);

// ZwSetDefaultHardErrorPort sets the default hard error port.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetDefaultHardErrorPort(
	IN HANDLE PortHandle
	);

// NtDisplayString displays a string.
NTSYSAPI
NTSTATUS
NTAPI
NtDisplayString(
	IN PUNICODE_STRING String
	);

// ZwDisplayString displays a string.
NTSYSAPI
NTSTATUS
NTAPI
ZwDisplayString(
	IN PUNICODE_STRING String
	);

// NtCreatePagingFile creates a paging file.
NTSYSAPI
NTSTATUS
NTAPI
NtCreatePagingFile(
	IN PUNICODE_STRING FileName,
	IN PULARGE_INTEGER InitialSize,
	IN PULARGE_INTEGER MaximumSize,
	IN ULONG Priority OPTIONAL
	);

// ZwCreatePagingFile creates a paging file.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreatePagingFile(
	IN PUNICODE_STRING FileName,
	IN PULARGE_INTEGER InitialSize,
	IN PULARGE_INTEGER MaximumSize,
	IN ULONG Priority OPTIONAL
	);

// NtAddAtom adds an atom to the global atom table.
NTSYSAPI
NTSTATUS
NTAPI
NtAddAtom(
	IN PWSTR String,
#if _WIN32_WINNT >= 0x0500
	IN ULONG StringLength,
#endif
	OUT PUSHORT Atom
	);

// ZwAddAtom adds an atom to the global atom table.
NTSYSAPI
NTSTATUS
NTAPI
ZwAddAtom(
	IN PWSTR String,
#if _WIN32_WINNT >= 0x0500
	IN ULONG StringLength,
#endif
	OUT PUSHORT Atom
	);

// NtFindAtom searches for an atom in the global atom table.
NTSYSAPI
NTSTATUS
NTAPI
NtFindAtom(
	IN PWSTR String,
#if _WIN32_WINNT >= 0x0500
	IN ULONG StringLength,
#endif
	OUT PUSHORT Atom
	);

// ZwFindAtom searches for an atom in the global atom table.
NTSYSAPI
NTSTATUS
NTAPI
ZwFindAtom(
	IN PWSTR String,
#if _WIN32_WINNT >= 0x0500
	IN ULONG StringLength,
#endif
	OUT PUSHORT Atom
	);

// NtDeleteAtom deletes an atom from the global atom table.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteAtom(
	IN USHORT Atom
	);


// ZwDeleteAtom deletes an atom from the global atom table.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteAtom(
	IN USHORT Atom
	);

// NtQueryInformationAtom retrieves information about an atom in the global atom
// table.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationAtom(
	IN USHORT Atom,
	IN ATOM_INFORMATION_CLASS AtomInformationClass,
	OUT PVOID AtomInformation,
	IN ULONG AtomInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryInformationAtom retrieves information about an atom in the global atom
// table.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationAtom(
	IN USHORT Atom,
	IN ATOM_INFORMATION_CLASS AtomInformationClass,
	OUT PVOID AtomInformation,
	IN ULONG AtomInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

/*	The following system services all just return STATUS_NOT_IMPLEMENTED:
	ZwCreateChannel
	ZwListenChannel
	ZwOpenChannel
	ZwReplyWaitSendChannel
	ZwSendWaitReplyChannel
	ZwSetContextChannel

	The following system services are only present in Windows 2000 and just return
	STATUS_NOT_IMPLEMENTED on the Intel platform:
	ZwAllocateVirtualMemory64
	ZwFreeVirtualMemory64
	ZwProtectVirtualMemory64
	ZwQueryVirtualMemory64
	ZwReadVirtualMemory64
	ZwWriteVirtualMemory64
	ZwMapViewOfVlmSection
	ZwUnmapViewOfVlmSection
	ZwReadFile64
	ZwWriteFile64
*/

#ifndef __IDA__

#ifdef _M_IX86

#ifndef _NTTYPES_NO_WINNT

_NTNATIVE_NAKED
_NTNATIVE_FORCEINLINE
PTEB
NTAPI
NtCurrentTeb(
	VOID
	)
{
	__asm
	{
		mov		eax, dword ptr fs:[0x18]
		ret
	}
}

#else

_NTNATIVE_NAKED
_NTNATIVE_FORCEINLINE
PTEB
NTAPI
__NtCurrentTeb(
	VOID
	)
{
	__asm
	{
		mov		eax, dword ptr fs:[0x18]
		ret
	}
}

#define NtCurrentTeb() __NtCurrentTeb()

#endif

#endif

#endif

#define NtCurrentPeb() (NtCurrentTeb()->ProcessEnvironmentBlock)

#if _WIN32_WINNT >= 0x0501

// NtGetCurrentProcessorNumber returns the processor on which the
// current thread is executing.
NTSYSAPI
ULONG
NTAPI
NtGetCurrentProcessorNumber(
	VOID
	);

// ZwGetCurrentProcessorNumber returns the processor on which the
// current thread is executing.
NTSYSAPI
ULONG
NTAPI
ZwGetCurrentProcessorNumber(
	VOID
	);

// NtLockProductActivationKeys checks the product build number, determines
// the safe-mode boot state, and locks the product activation registry key in memory.
// On return, ProductBuild will be the current build number if the in build number was
// in range, or zero if it was invalid.  InitSafeBootMode values are drawn from the
// SAFEBOOT_MODE enumeration.
// Subkeys of \Machine\System\WPA\KEY-DP4T2GP93MPBT26V8TBK are locked for Windows Server 2003.
NTSYSAPI
NTSTATUS
NTAPI
NtLockProductActivationKeys(
	IN OUT PULONG ProductBuild OPTIONAL,
	OUT PSAFEBOOT_MODE InitSafeBootMode OPTIONAL
	);

// ZwLockProductActivationKeys checks the product build number, determines
// the safe-mode boot state, and locks the product activation registry key in memory.
// On return, ProductBuild will be the current build number if the in build number was
// in range, or zero if it was invalid.  InitSafeBootMode values are drawn from the
// SAFEBOOT_MODE enumeration.
// Subkeys of \Machine\System\WPA\KEY-DP4T2GP93MPBT26V8TBK are locked for Windows Server 2003.
NTSYSAPI
NTSTATUS
NTAPI
ZwLockProductActivationKeys(
	IN OUT PULONG ProductBuild OPTIONAL,
	OUT PSAFEBOOT_MODE InitSafeBootMode OPTIONAL
	);

// NtApphelpCacheControl performs a variety of operations on the application compatibility database.
NTSYSAPI
NTSTATUS
NTAPI
NtApphelpCacheControl(
	IN APPHELPCACHECONTROL ApphelpCacheControl,
	IN PUNICODE_STRING ApphelpCacheObject
	);

// ZwApphelpCacheControl performs a variety of operations on the application compatibility database.
NTSYSAPI
NTSTATUS
NTAPI
ZwApphelpCacheControl(
	IN APPHELPCACHECONTROL ApphelpCacheControl,
	IN PUNICODE_STRING ApphelpCacheObject
	);

// NtQueryPortInformationProcess determines if the current thread will generate debug or exception events.
// If the current process has a debug port and the current thread has the ThreadHideFromDebugger flag set, then the function
// returns TRUE.  Otherwise, it returns TRUE only if the current process is not associated with either a debug or exception port.
NTSYSAPI
BOOLEAN
NTAPI
NtQueryPortInformationProcess(
	VOID
	);

// NtQueryPortInformationProcess determines if the current thread will generate debug or exception events.
// If the current process has a debug port and the current thread has the ThreadHideFromDebugger flag set, then the function
// returns TRUE.  Otherwise, it returns TRUE only if the current process is not associated with either a debug or exception port.
NTSYSAPI
BOOLEAN
NTAPI
ZwQueryPortInformationProcess(
	VOID
	);

// NtTraceEvent logs a WMI event.
NTSYSAPI
NTSTATUS
NTAPI
ZwTraceEvent(
	IN ULONG TraceHandle,
	IN ULONG Flags,								// 0x01 - Use WmiTraceMessage instead of WmiTrace, 0x02 - invalid with 0x01
	IN ULONG TraceHeaderLength,					// Max 0x30
	IN struct _EVENT_TRACE_HEADER* TraceHeader
	);

// ZwTraceEvent logs a WMI event.
NTSYSAPI
NTSTATUS
NTAPI
ZwTraceEvent(
	IN ULONG TraceHandle,
	IN ULONG Flags,								// 0x01 - Use WmiTraceMessage instead of WmiTrace, 0x02 - invalid with 0x01
	IN ULONG TraceHeaderLength,					// Max 0x30
	IN struct _EVENT_TRACE_HEADER* TraceHeader
	);

#endif

_NTNATIVE_END_NT

#endif
