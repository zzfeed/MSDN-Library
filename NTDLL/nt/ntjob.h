#ifndef NTJOB_H
#define NTJOB_H

#pragma once

#include <nt\nttypes.h>

_NTNATIVE_BEGIN_NT

#if _WIN32_WINNT >= 0x0500

// Job support is only included in Windows 2000 (or later).

// NtCreateJobObject creates or opens a job object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateJobObject(
	OUT PHANDLE JobHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwCreateJobObject creates or opens a job object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateJobObject(
	OUT PHANDLE JobHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtOpenJobObject opens a job object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenJobObject(
	OUT PHANDLE JobHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenJobObject opens a job object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenJobObject(
	OUT PHANDLE JobHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtTerminateJobObject terminates a job and the processes and threads that it contains.
NTSYSAPI
NTSTATUS
NTAPI
NtTerminateJobObject(
	IN HANDLE JobHandle,
	IN NTSTATUS ExitStatus
	);

// ZwTerminateJobObject terminates a job and the processes and threads that it contains.
NTSYSAPI
NTSTATUS
NTAPI
ZwTerminateJobObject(
	IN HANDLE JobHandle,
	IN NTSTATUS ExitStatus
	);

// NtAssignProcessToJobObject associates a process with a job.
NTSYSAPI
NTSTATUS
NTAPI
NtAssignProcessToJobObject(
	IN HANDLE JobHandle,
	IN HANDLE ProcessHandle
	);

// ZwAssignProcessToJobObject associates a process with a job.
NTSYSAPI
NTSTATUS
NTAPI
ZwAssignProcessToJobObject(
	IN HANDLE JobHandle,
	IN HANDLE ProcessHandle
	);

// NtQueryInformationJobObject retrieves information about a job object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationJobObject(
	IN HANDLE JobHandle,
	IN JOBOBJECTINFOCLASS JobInformationClass,
	OUT PVOID JobInformation,
	IN ULONG JobInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryInformationJobObject retrieves information about a job object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationJobObject(
	IN HANDLE JobHandle,
	IN JOBOBJECTINFOCLASS JobInformationClass,
	OUT PVOID JobInformation,
	IN ULONG JobInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtSetInformationJobObject sets information affecting a job object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationJobObject(
	IN HANDLE JobHandle,
	IN JOBOBJECTINFOCLASS JobInformationClass,
	IN PVOID JobInformation,
	IN ULONG JobInformationLength
	);

// ZwSetInformationJobObject sets information affecting a job object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationJobObject(
	IN HANDLE JobHandle,
	IN JOBOBJECTINFOCLASS JobInformationClass,
	IN PVOID JobInformation,
	IN ULONG JobInformationLength
	);

#endif

#if _WIN32_WINNT >= 0x0501

// NtIsProcessInJob determines if a process is associated with a job object.
NTSYSAPI
NTSTATUS
NTAPI
NtIsProcessInJob(
	IN HANDLE ProcessHandle,		// ProcessHandle must grant PROCESS_QUERY_INFORMATION access.
	IN HANDLE JobHandle OPTIONAL	// JobHandle must grant JOB_OBJECT_QUERY access. Defaults to the current process's job object.
	);

// ZwIsProcessInJob determines if a process is associated with a job object.
NTSYSAPI
NTSTATUS
NTAPI
ZwIsProcessInJob(
	IN HANDLE ProcessHandle,		// ProcessHandle must grant PROCESS_QUERY_INFORMATION access.
	IN HANDLE JobHandle OPTIONAL	// JobHandle must grant JOB_OBJECT_QUERY access. Defaults to the current process's job object.
	);

// NtCreateJobSet creates a job set.  Note that a job set is not a kernel object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateJobSet(
	IN ULONG Jobs,				// Jobs must be within the range [1...0x15555555].
	IN PJOB_SET_ARRAY JobSet,	// Job handles must grant JOB_OBJECT_QUERY access.
	IN ULONG Reserved			// Reserved; must be zero.
	);

// ZwCreateJobSet creates a job set.  Note that a job set is not a kernel object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateJobSet(
	IN ULONG Jobs,				// Jobs must be within the range [1...0x15555555].
	IN PJOB_SET_ARRAY JobSet,	// Job handles must grant JOB_OBJECT_QUERY access.
	IN ULONG Reserved			// Reserved; must be zero.
	);

#endif

_NTNATIVE_END_NT

#endif
