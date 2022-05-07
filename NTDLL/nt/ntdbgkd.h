#ifndef NTDBGKD_H
#define NTDBGKD_H

#ifdef _MSC_VER
#pragma once
#endif

_NTNATIVE_BEGIN_NT

#ifndef _NTTYPES_NO_DBGKD

#define NTKDAPI

NTKDAPI
VOID
NTAPI
DbgKdSendBreakIn(
	VOID
	);

//NTKDAPI
//PBYTE
//NTAPI
//DbgKdGets(
//	PBYTE Buffer,
//    WORD Length
//	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWaitStateChange(
	OUT PDBGKD_WAIT_STATE_CHANGE StateChange,
	OUT PVOID Buffer,
	IN DWORD BufferLength
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdContinue(
	IN NTSTATUS ContinueStatus
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdContinue2(
	IN NTSTATUS ContinueStatus,
	IN DBGKD_CONTROL_SET ControlSet
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdReadVirtualMemory(
	IN PVOID TargetBaseAddress,
	OUT PVOID UserInterfaceBuffer,
	IN DWORD TransferCount,
	OUT PDWORD ActualBytesRead OPTIONAL
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWriteVirtualMemory(
	IN PVOID TargetBaseAddress,
	IN PVOID UserInterfaceBuffer,
	IN DWORD TransferCount,
	OUT PDWORD ActualBytesWritten OPTIONAL
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdReadPhysicalMemory(
	IN PHYSICAL_ADDRESS TargetBaseAddress,
	OUT PVOID UserInterfaceBuffer,
	IN DWORD TransferCount,
	OUT PDWORD ActualBytesRead OPTIONAL
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWritePhysicalMemory(
	IN PHYSICAL_ADDRESS TargetBaseAddress,
	IN PVOID UserInterfaceBuffer,
	IN DWORD TransferCount,
	OUT PDWORD ActualBytesWritten OPTIONAL
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdReadControlSpace(
	IN WORD Processor,
	IN PVOID TargetBaseAddress,
	OUT PVOID UserInterfaceBuffer,
	IN DWORD TransferCount,
	OUT PDWORD ActualBytesRead OPTIONAL
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWriteControlSpace(
	IN WORD Processor,
	IN PVOID TargetBaseAddress,
	IN PVOID UserInterfaceBuffer,
	IN DWORD TransferCount,
	OUT PDWORD ActualBytesWritten OPTIONAL
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdReadIoSpace(
	IN PVOID IoAddress,
	OUT PVOID ReturnedData,
	IN DWORD DataSize
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWriteIoSpace(
	IN PVOID IoAddress,
	IN DWORD DataValue,
	IN DWORD DataSize
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdReadMsr(
	IN DWORD MsrReg,
	OUT PDWORDLONG MsrValue
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWriteMsr(
	IN DWORD MsrReg,
	IN DWORDLONG MsrValue
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdGetContext(
    IN WORD Processor,
    IN OUT PCONTEXT Context
    );

NTKDAPI
NTSTATUS
NTAPI
DbgKdSetContext(
	IN WORD Processor,
	IN PCONTEXT Context
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdWriteBreakPoint(
	IN PVOID BreakPointAddress,
	OUT PDWORD BreakPointHandle
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdRestoreBreakPoint(
	IN DWORD BreakPointHandle
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdReboot(
	VOID
	);

#ifdef _X86_

NTKDAPI
NTSTATUS
NTAPI
DbgKdLookupSelector(
	IN WORD Processor,
	IN OUT PDESCRIPTOR_TABLE_ENTRY DescriptorTableEntry
	);

#endif

NTKDAPI
NTSTATUS
NTAPI
DbgKdCrash(
	IN DWORD BugCheckCode
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdSwitchActiveProcessor(
	IN WORD Processor
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdSetSpecialCalls(
    IN DWORD NumSpecialCalls,
    IN PDWORD_PTR Calls
    );

NTKDAPI
NTSTATUS
NTAPI
DbgKdSetInternalBreakPoint(
    IN DWORD_PTR BreakpointAddress,
    IN DWORD Flags
    );

NTKDAPI
NTSTATUS
NTAPI
DbgKdGetInternalBreakPoint(
	IN DWORD_PTR BreakpointAddress,
	OUT PDWORD Flags,
	OUT PDWORD Calls,
	OUT PDWORD MaxCallsPerPeriod,
	OUT PDWORD MinInstructions,
	OUT PDWORD MaxInstructions,
	OUT PDWORD TotalInstructions
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdGetVersion(
	OUT PDBGKD_GET_VERSION Version
	);

NTKDAPI
NTSTATUS
NTAPI
DbgKdPageIn(
	IN ULONG_PTR Address
	);

//
// DbgKd Io handler for DbgKd clients.
// Can be called during any DbgKd request from the main thread.
//
// If PromptString is provided, then the string is already initialized
// by the DbgKd API to have zero length and an appropriate buffer and
// maximum length.
//

typedef VOID (NTAPI * PDBGKD_HANDLE_IO_ROUTINE)(IN PSTRING DisplayString,
												 IN OUT PSTRING PromptString OPTIONAL,
												 IN ULONG Processor,
												 IN PVOID HandleIoContext);

//
// Connect to the target.
// If ComPort and/or BaudRate are not specified, the routine attempts
// to gather port & baud information from the environment block of the
// process.  If this is unsuccessful then the function fails.
//
// Multiple connections are not supported.
//

NTKDAPI
NTSTATUS
NTAPI
DbgKdConnectAndInitialize(
	IN CONST WCHAR* TransportName,
	IN CONST WCHAR* PortName OPTIONAL,
	IN ULONG BaudRate OPTIONAL,
	IN PDBGKD_HANDLE_IO_ROUTINE HandleIoRoutine,
	IN PVOID HandleIoContext
	);

//
// Shut down the debugger connection cleanly.  Must not be called while there is a
// pending DbgKd operation.
//

NTKDAPI
NTSTATUS
NTAPI
DbgKdStopDebugging(
	VOID
	);

//
// Perform a hard abort of a pending DbgKd operation.
// The DbgKd routine will return with STATUS_REQUEST_ABORTED.
// After this occurs the session must be closed with DbgKdStopDebugging.
//

NTKDAPI
NTSTATUS
NTAPI
DbgKdAbortRequest(
	VOID
	);

//
// Request a breakin of the target (possibly while a DbgKd call is pending).
//

NTKDAPI
NTSTATUS
NTAPI
DbgKdRequestBreakIn(
	VOID
	);

//
// Request a resync with the target (possibly while a DbgKd call is pending).
//

NTKDAPI
NTSTATUS
NTAPI
DbgKdRequestResync(
	VOID
	);

#endif

_NTNATIVE_END_NT

#endif
