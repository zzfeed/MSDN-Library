#ifndef NTPROCESS_H
#define NTPROCESS_H

#pragma once

#include <nt\nttypes.h>

_NTNATIVE_BEGIN_NT

// New (compared to OpenProcess) XxCreateProcess flags:
// PROCESS_CREATE_PROCESS Bequeath address space and handles to new process

// NtCreateProcess creates a process object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateProcess(
	OUT PHANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN HANDLE InheritFromProcessHandle,
	IN BOOLEAN InheritHandles,
	IN HANDLE SectionHandle OPTIONAL,
	IN HANDLE DebugPort OPTIONAL,
	IN HANDLE ExceptionPort OPTIONAL
	);

// ZwCreateProcess creates a process object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateProcess(
	OUT PHANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN HANDLE InheritFromProcessHandle,
	IN BOOLEAN InheritHandles,
	IN HANDLE SectionHandle OPTIONAL,
	IN HANDLE DebugPort OPTIONAL,
	IN HANDLE ExceptionPort OPTIONAL
	);

#if _WIN32_WINNT >= 0x501

#define PROCESS_BREAKAWAY_FROM_JOB			0x00000001	/* Process does not inherit the inherit from process's job */
#define PROCESS_DEBUG_ONLY_THIS_PROCESS		0x00000002	/* Processes inheriting from the new process are not debugged */
#define PROCESS_INHERIT_HANDLES				0x00000004	/* Inheritable object handles are propagated to the new process */
#define PROCESS_UNUSED_1					0x00000008	/* Valid but ignored */

//
// The JobMemberLevel in particular deserves some extra explanation.
// It is used to select which JobObject in the inherit process's JobSet a new process should be associated with.
//
// If JobMemberLevel is zero, the new process directly inherits the inherit process's JobObject.
// If JobMemberLevel is nonzero, and the inherit process is not associated with a job, the create process operation fails.
// If JobMemberLevel is less than or equal to the inherit process JobObject's MemberLevel, the create process operation fails.
// Otherwise, the inherit process's JobSet is searched for a JobObject with MemberLevel equal to the supplied JobMemberLevel.
// The first JobObject with a matching MemberLevel is used as the new process's associated JobObject.  If no JobObject with
// the given MemberLevel is found, the create process operation fails.
//

// NtCreateProcessEx creates a process object.	
NTSYSAPI
NTSTATUS
NTAPI
NtCreateProcessEx(
	OUT PHANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN HANDLE InheritFromProcessHandle,
	IN ULONG CreateFlags,					// PROCESS_* flags; see above
	IN HANDLE SectionHandle OPTIONAL,
	IN HANDLE DebugObject OPTIONAL,
	IN HANDLE ExceptionPort OPTIONAL,
	IN ULONG JobMemberLevel					// Nonzero requires the parent to be in a job, select which job in JobSet
	);

// ZwCreateProcessEx creates a process object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateProcessEx(
	OUT PHANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN HANDLE InheritFromProcessHandle,
	IN ULONG CreateFlags,					// PROCESS_* flags; see above
	IN HANDLE SectionHandle OPTIONAL,
	IN HANDLE DebugObject OPTIONAL,
	IN HANDLE ExceptionPort OPTIONAL,
	IN ULONG JobMemberLevel					// Nonzero requires the parent to be in a job, select which job in JobSet
	);

#endif

#if _WIN32_WINNT >= 0x0600

/*
NTSYSAPI
NTSTATUS
NTAPI
NtCreateUserProcess(
	OUT PHANDLE ProcessHandle,
	OUT PHANDLE ThreaadHandle,
	IN ULONG DesiredProcessRigghts,
	IN ULONG DesiredThreadRights,
	IN ULONG Unk,
	IN ULONG Unk,
	IN ULONG Unk,
	IN ULONG Unk_1
	IN PRTL_USER_PROCESS_PARAMETERS ProcessParameters,
	IN PCREATE_PROCESS_PARAMETERS CreateProcessParameters,
	IN PPROC_THREAD_ATTRIBUTE_LIST ProcThreadAttributeList
	);
*/

#endif

// New (compared to OpenProcess) XxCreateProcss flags:
// PROCESS_SET_SESSIONID Set process session id
// PROCESS_CREATE_PROCESS Bequeath address space and handles to new process
// PROCESS_SET_PORT Set process exception or debug port

// NtOpenProcess opens a process object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenProcess(
	OUT PHANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PCLIENT_ID ClientId OPTIONAL
	);

// ZwOpenProcess opens a process object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenProcess(
	OUT PHANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PCLIENT_ID ClientId OPTIONAL
	);

//
// Process termination routines
//
// There are special considerations for NtTerminateProcess and 
// ZwTerminateProcess.
//
// - If the process handle is NULL, then the current process is considered
//   to be the process to terminate.  All threads except the current thread
//   are terminated.  However, the current process and thread are not
//   terminated (instead, the function returns with STATUS_SUCCESS).
//
// - If the exit status is DBG_TERMINATE_PROCESS, then STATUS_ACCESS_DENIED
//   is returned (and the process is not terminated) if the process has a
//   DebugPort assigned and the process handle provided does not refer to
//   the current process.
//
// Otherwise, normal process termination behavior is observed.
//

// NtTerminateProcess terminates a process and the threads that it contains.
NTSYSAPI
NTSTATUS
NTAPI
NtTerminateProcess(
	IN HANDLE ProcessHandle OPTIONAL,
	IN NTSTATUS ExitStatus
	);

// NtTerminateProcess terminates a process and the threads that it contains.
NTSYSAPI
NTSTATUS
NTAPI
NtTerminateProcess(
	IN HANDLE ProcessHandle OPTIONAL,
	IN NTSTATUS ExitStatus
	);

// NtQueryInformationProcess retrieves information about a process object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationProcess(
	IN HANDLE ProcessHandle,
	IN PROCESSINFOCLASS ProcessInformationClass,
	OUT PVOID ProcessInformation,
	IN ULONG ProcessInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryInformationProcess retrieves information about a process object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationProcess(
	IN HANDLE ProcessHandle,
	IN PROCESSINFOCLASS ProcessInformationClass,
	OUT PVOID ProcessInformation,
	IN ULONG ProcessInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtSetInformationProcess sets information affecting a process object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationProcess(
	IN HANDLE ProcessHandle,
	IN PROCESSINFOCLASS ProcessInformationClass,
	IN PVOID ProcessInformation,
	IN ULONG ProcessInformationLength
	);

// ZwSetInformationProcess sets information affecting a process object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationProcess(
	IN HANDLE ProcessHandle,
	IN PROCESSINFOCLASS ProcessInformationClass,
	IN PVOID ProcessInformation,
	IN ULONG ProcessInformationLength
	);

#if _WIN32_WINNT >= 0x0501

// NtSuspendProcess suspends all threads in a process.
NTSYSAPI
NTSTATUS
NTAPI
NtSuspendProcess(
	IN HANDLE Process								// Process handle must grant PROCESS_SUSPEND_RESUME access.
	);

// ZwSuspendProcess suspends all threads in a process.
NTSYSAPI
NTSTATUS
NTAPI
ZwSuspendProcess(
	IN HANDLE Process								// Process handle must grant PROCESS_SUSPEND_RESUME access.
	);

// NtResumeProcess resumes all threads in a process.
NTSYSAPI
NTSTATUS
NTAPI
NtResumeProcess(
	IN HANDLE Process								// Process handle must grant PROCESS_SUSPEND_RESUME access.
	);

// ZwResumeProcess resumes all threads in a process.
NTSYSAPI
NTSTATUS
NTAPI
ZwResumeProcess(
	IN HANDLE Process								// Process handle must grant PROCESS_SUSPEND_RESUME access.
	);

#endif

#ifndef NtCurrentProcess
// NtCurrentProcess returns a pseudohandle to the current process.
_NTNATIVE_INLINE
HANDLE
NtCurrentProcess(
	VOID
	)
{
	return (HANDLE) -1;
}
#endif

#ifndef ZwCurrentProcess
// ZwCurrentProcess returns a pseudohandle to the current process.
_NTNATIVE_INLINE
HANDLE
ZwCurrentProcess(
	VOID
	)
{
	return (HANDLE) -1;
}
#endif

_NTNATIVE_END_NT

#endif
