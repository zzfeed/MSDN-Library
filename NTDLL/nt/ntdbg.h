#ifndef NTDBG_H
#define NTDBG_H

#pragma once

#include <nt\nttypes.h>

_NTNATIVE_BEGIN_NT

NTSYSAPI
VOID
NTAPI
DbgBreakPoint(
    VOID
    );

NTSYSAPI
VOID
NTAPI
DbgBreakPointWithStatus(
    IN ULONG Status
    );

NTSYSAPI
ULONG
NTAPI
DbgPrompt(
    IN PCHAR Prompt,
    OUT PCHAR Response,
    IN ULONG MaximumResponseLength
    );

enum {
	DBG_STATUS_CONTROL_C        =	1,
	DBG_STATUS_SYSRQ            =	2,
	DBG_STATUS_BUGCHECK_FIRST   =	3,
	DBG_STATUS_BUGCHECK_SECOND  =	4,
	DBG_STATUS_FATAL            =	5,
	DBG_STATUS_DEBUG_CONTROL    =	6
};

NTSYSAPI
ULONG
_cdecl
DbgPrint(
    PCH Format,
    ...
    );

NTSYSAPI
ULONG
_cdecl
DbgPrintReturnControlC(
    PCH Format,
    ...
    );

#ifdef NTNATIVE_DBG_FUNCTIONS

__inline ULONG NTAPI DbgPromptSafe(IN PCHAR Prompt, OUT PCHAR Response, IN ULONG MaximumResponseLength)
{
	__try
	{
		return DbgPrompt(Prompt, Response, MaximumResponseLength);
	}
	__except(GetExceptionCode() == EXCEPTION_BREAKPOINT ? EXCEPTION_EXECUTE_HANDLER : EXCEPTION_CONTINUE_SEARCH)
	{
		return 0;
	}
}

//
// Ask the user a yes/no question, appending " [yn] ?\0" to the prompt string.
// Returns DefaultResponse if there is no debugger or if the user gives unrecognized input.
//

__inline BOOLEAN NTAPI DbgQuery(IN PCHAR Prompt, IN BOOLEAN DefaultResponse)
{
	PCHAR _Prompt;
	CHAR Response[2];
	SIZE_T Len;

	Len = strlen(Prompt) + 8; // " [yn] ?\0"
	_Prompt = _alloca(Len);
	RtlCopyMemory(_Prompt, Prompt, Len - 8);
	RtlCopyMemory(_Prompt + Len - 8, " [yn] ?", 8);

	if(DbgPromptSafe(_Prompt, Response, sizeof(Response)))
	{
		switch(tolower(Response[0]))
		{

		case 'y':
			return TRUE;

		case 'n':
			return FALSE;

		default:
			DbgPrint("Invalid response, defaulting to %s...\n", DefaultResponse ? "\"y\"" : "\"n\"");
			return DefaultResponse;

		}
	}

	return DefaultResponse;
}

#endif

#if _WIN32_WINNT >= 0x0501

NTSYSAPI
ULONG
__cdecl
DbgPrintEx(
    IN ULONG ComponentId,
    IN ULONG Level,
    IN PCH Format,
    ...
    );

#ifdef _VA_LIST_DEFINED

NTSYSAPI
ULONG
vDbgPrintEx(
    IN ULONG ComponentId,
    IN ULONG Level,
    IN PCH Format,
    va_list arglist
    );

NTSYSAPI
ULONG
vDbgPrintExWithPrefix(
    IN PCH Prefix,
    IN ULONG ComponentId,
    IN ULONG Level,
    IN PCH Format,
    va_list arglist
    );

#endif

// DbgQueryDebugFilterState retrieves the DbgPrintEx filter state for a component.
NTSYSAPI
BOOLEAN
NTAPI
DbgQueryDebugFilterState(
    IN ULONG ComponentId,
    IN ULONG Level
    );

// DbgSetDebugFilterState sets the DbgPrintEx filter state for a component (SeDebugPrivilege is required).
NTSYSAPI
NTSTATUS
NTAPI
DbgSetDebugFilterState(
    IN ULONG ComponentId,
    IN ULONG Level,
    IN BOOLEAN State
    );

// DbgUiConnectToDbg creates a debug object and associates it with the current thread.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiConnectToDbg(
	VOID
	);

// DbgUiGetThreadDebugObject returns the debug object associated with the current thread.
NTSYSAPI
HANDLE
NTAPI
DbgUiGetThreadDebugObject(
	VOID
	);

// DbgUiSetThreadDebugObject associates a debug object with the current thread.  The existing debug object, if any, is not closed.
NTSYSAPI
VOID
NTAPI
DbgUiSetThreadDebugObject(
	IN HANDLE DebugObject
	);

// DbgUiWaitStateChanges waits for a debug event to occur.  The wait is alertable.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiWaitStateChange(
	OUT PDBGUI_WAIT_STATE_CHANGE StateChange,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// DbgUiConvertStateChangeStructure translates a DBGUI_WAIT_STATE_CHANGE structure into a Win32 DEBUG_EVENT structure.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiConvertStateChangeStructure(
	IN PDBGUI_WAIT_STATE_CHANGE StateChange,
	OUT struct _DEBUG_EVENT* DebugEvent
	);

// DbgUiContinue resumes execution after a debug event. Valid ContinueStatuses included: DBG_EXCEPTION_NOT_HANDLED,
// DBG_EXCEPTION_NOT_HANDLED, DBG_TERMINATE_THREAD, DBG_TERMINATE_PROCESS, and DBG_CONTINUE.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiContinue(
	IN PCLIENT_ID AppClientId,
	IN NTSTATUS ContinueStatus
	);

// DbgUiDebugActiveProcess attaches the current thread's debug object to a process.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiDebugActiveProcess(
	IN PCLIENT_ID AppClientId
	);

// DbgUiIssueRemoteBreakin creates a new thread in the target process.  The new thread executes DbgBreakPoint() and exits.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiIssueRemoteBreakin(
	IN PCLIENT_ID AppClientId
	);

#else

// DbgUiConnectToDbg creates a connection to \DbgUiApiPort, and creates the DbgSs per-thread semaphore.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiConnectToDbg(
	VOID
	);

// DbgUiWaitStateChange waits for a debug LPC port message from the Session Manager.  The wait is alertable.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiWaitStateChange (
    OUT PDBGUI_WAIT_STATE_CHANGE StateChange,
    IN PLARGE_INTEGER Timeout OPTIONAL
    );

// DbgUiContinue resumes execution after a debug event. Valid ContinueStatuses included: DBG_EXCEPTION_NOT_HANDLED,
// DBG_EXCEPTION_NOT_HANDLED, DBG_TERMINATE_THREAD, DBG_TERMINATE_PROCESS, and DBG_CONTINUE.
NTSYSAPI
NTSTATUS
NTAPI
DbgUiContinue (
    IN PCLIENT_ID AppClientId,
    IN NTSTATUS ContinueStatus
    );

#endif

// RtlCreateQueryDebugBuffer creates the data structure required by RtlQueryProcessDebugInformation.
NTSYSAPI
PDEBUG_BUFFER
NTAPI
RtlCreateQueryDebugBuffer(
	IN ULONG Size,
	IN BOOLEAN EventPair // Create one thread for all requests, or create/destroy a thread for each
	);

// RtlQueryProcessDebugInformation queries information about a process that is maintained in user mode.
NTSYSAPI
NTSTATUS
NTAPI
RtlQueryProcessDebugInformation(
	IN ULONG ProcessId,
	IN ULONG DebugInfoClassMask, // PDI_xxxxx
	IN OUT PDEBUG_BUFFER DebugBuffer
	);

// RtlDestroyQueryDebugBuffer deallocates the data structure used by RtlQueryProcessDebugInformation.
NTSYSAPI
NTSTATUS
NTAPI
RtlDestroyQueryDebugBuffer(
	IN PDEBUG_BUFFER DebugBuffer
	);

//
// DebugObject routines for WinXP/Win2003 and later.
//

#if _WIN32_WINNT >= 0x0501

//
// Kernel debug object flags at +0x38 into the DebugObject
//
// #define DEBUG_KERNEL_OBJECT_DEBUGGER_INACTIVE		0x00000001
// #define DEBUG_KERNEL_OBJECT_KILL_PROCESS_ON_EXIT		0x00000002
//

// NtCreateDebugObject creates a debug object for user mode debugging.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateDebugObject(
	OUT PHANDLE DebugObject,
	IN ULONG AccessRequired,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN BOOLEAN KillProcessOnExit
	);

// ZwCreateDebugObject creates a debug object for user mode debugging.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateDebugObject(
	OUT PHANDLE DebugObject,
	IN ULONG AccessRequired,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN BOOLEAN KillProcessOnExit
	);

// NtWaitForDebugEvent waits for a debug event to occur.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitForDebugEvent(
	IN HANDLE DebugObject,						// Debug object handle must grant DEBUG_OBJECT_WAIT_STATE_CHANGE access.
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL,
	OUT PDBGUI_WAIT_STATE_CHANGE StateChange
	);

// ZwWaitForDebugEvent waits for a debug event to occur.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitForDebugEvent(
	IN HANDLE DebugObject,						// Debug object handle must grant DEBUG_OBJECT_WAIT_STATE_CHANGE access.
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL,
	OUT PDBGUI_WAIT_STATE_CHANGE StateChange	
	);

// NtDebugContinue continues the execution of a process after a debug event.
NTSYSAPI
NTSTATUS
NTAPI
NtDebugContinue(
	IN HANDLE DebugObject,						// Debug object handle must grant DEBUG_OBJECT_WAIT_STATE_CHANGE access.
	IN PCLIENT_ID AppClientId,
	IN NTSTATUS ContinueStatus
	);

// ZwDebugContinue continues the execution of a process after a debug event.
NTSYSAPI
NTSTATUS
NTAPI
ZwDebugContinue(
	IN HANDLE DebugObject,
	IN PCLIENT_ID AppClientId,
	IN NTSTATUS ContinueStatus
	);

// NtDebugActiveProcess begins debugging a process that has already been created.
NTSYSAPI
NTSTATUS
NTAPI
NtDebugActiveProcess(
	IN HANDLE Process,							// Process handle must grant PROCESS_SUSPEND_RESUME access.
	IN HANDLE DebugObject						// Debug object handle must grant DEBUG_OBJECT_ADD_REMOVE_PROCESS access.
	);

// NtRemoveProcessDebug removes a process from a debug object, potentially terminating the process.
NTSYSAPI
NTSTATUS
NTAPI
NtRemoveProcessDebug(
	IN HANDLE Process,							// Process handle must grant PROCESS_SUSPEND_RESUME access.
	IN HANDLE DebugObject						// Debug object handle must grant DEBUG_OBJECT_ADD_REMOVE_PROCESS access.
	);

// ZwRemoveProcessDebug removes a process from a debug object, potentially terminating the process.
NTSYSAPI
NTSTATUS
NTAPI
ZwRemoveProcessDebug(
	IN HANDLE Process,							// Process handle must grant PROCESS_SUSPEND_RESUME access.
	IN HANDLE DebugObject						// Debug object handle must grant DEBUG_OBJECT_REMOVE_PROCESS access.
	);

// NtSetInformationDebugObject sets information affecting a debug object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationDebugObject(
	IN HANDLE DebugObject,					// Debug object handle need not grant any particular access right.
	IN DEBUGOBJECTINFOCLASS DebugObjectInformationClass,
	IN PVOID DebugInformation,
	IN ULONG DebugInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwSetInformationDebugObject sets information affecting a debug object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationDebugObject(
	IN HANDLE DebugObject,				// Debug object handle need not grant any particular access right.
	IN DEBUGOBJECTINFOCLASS DebugObjectInformationClass,
	IN PVOID DebugInformation,
	IN ULONG DebugInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtQueryDebugFilterState queries a DbgPrintEx component filter state.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDebugFilterState(
	IN ULONG ComponentId,
	IN ULONG Level
	);

// ZwQueryDebugFilterState queries a DbgPrintEx component filter state.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryDebugFilterState(
	IN ULONG ComponentId,
	IN ULONG Level
	);

// NtSetDebugFilterState sets a DbgPrintEx component filter state.  SeDebugPrivilege is required to perform this operation.
NTSYSAPI
NTSTATUS
NTAPI
NtSetDebugFilterState(
	IN ULONG ComponentId,
	IN ULONG Level,
	IN BOOLEAN Enable
	);

// ZwSetDebugFilterState sets a DbgPrintEx component filter state.  SeDebugPrivilege is required to perform this operation.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetDebugFilterState(
	IN ULONG ComponentId,
	IN ULONG Level,
	IN BOOLEAN Enable
	);

#endif


_NTNATIVE_END_NT

#endif
