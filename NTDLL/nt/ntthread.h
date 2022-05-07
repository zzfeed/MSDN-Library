#ifndef NTTHREAD_H
#define NTTHREAD_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtCreateThread creates a thread in a process.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateThread(
	OUT PHANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN HANDLE ProcessHandle,
	OUT PCLIENT_ID ClientId,
	IN PCONTEXT ThreadContext,
	IN PUSER_STACK UserStack,
	IN BOOLEAN CreateSuspended
	);

// ZwCreateThread creates a thread in a process.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateThread(
	OUT PHANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN HANDLE ProcessHandle,
	OUT PCLIENT_ID ClientId,
	IN PCONTEXT ThreadContext,
	IN PUSER_STACK UserStack,
	IN BOOLEAN CreateSuspended
	);

// NtOpenThread opens a thread object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenThread(
	OUT PHANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PCLIENT_ID ClientId
	);

// ZwOpenThread opens a thread object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenThread(
	OUT PHANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PCLIENT_ID ClientId
	);

//
// Thread termination routines
//
// There are special considerations for NtTerminateThread and
// ZwTerminateThread.
//
// - If the thread handle is NULL, then the current thread is considered
//   to be the thread to terminate.  However, the thread is not terminated
//   if it is the last thread remaining in the process.  If this is the case,
//   then the function returns STATUS_CANT_TERMINATE_SELF.
//
// Otherwise, normal thread termination behavior is observed.
//

// NtTerminateThread terminates a thread.
NTSYSAPI
NTSTATUS
NTAPI
NtTerminateThread(
	IN HANDLE ThreadHandle OPTIONAL,
	IN NTSTATUS ExitStatus
	);

// ZwTerminateThread terminates a thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwTerminateThread(
	IN HANDLE ThreadHandle OPTIONAL,
	IN NTSTATUS ExitStatus
	);

// NtQueryInformationThread retrieves information about a thread object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationThread(
	IN HANDLE ThreadHandle,
	IN THREADINFOCLASS ThreadInformationClass,
	OUT PVOID ThreadInformation,
	IN ULONG ThreadInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryInformationThread retrieves information about a thread object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationThread(
	IN HANDLE ThreadHandle,
	IN THREADINFOCLASS ThreadInformationClass,
	OUT PVOID ThreadInformation,
	IN ULONG ThreadInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtSetInformationThread sets information affecting a thread object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationThread(
	IN HANDLE ThreadHandle,
	IN THREADINFOCLASS ThreadInformationClass,
	IN PVOID ThreadInformation,
	IN ULONG ThreadInformationLength
	);

// ZwSetInformationThread sets information affecting a thread object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationThread(
	IN HANDLE ThreadHandle,
	IN THREADINFOCLASS ThreadInformationClass,
	IN PVOID ThreadInformation,
	IN ULONG ThreadInformationLength
	);

// NtSuspendThread suspends the execution of a thread.
NTSYSAPI
NTSTATUS
NTAPI
NtSuspendThread(
	IN HANDLE ThreadHandle,
	OUT PULONG PreviousSuspendCount OPTIONAL
	);

// ZwSuspendThread suspends the execution of a thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwSuspendThread(
	IN HANDLE ThreadHandle,
	OUT PULONG PreviousSuspendCount OPTIONAL
	);

// NtResumeThread decrements the suspend count of a thread and resumes the execution
// of the thread if the suspend count reaches zero.
NTSYSAPI
NTSTATUS
NTAPI
NtResumeThread(
	IN HANDLE ThreadHandle,
	OUT PULONG PreviousSuspendCount OPTIONAL
	);

// ZwResumeThread decrements the suspend count of a thread and resumes the execution
// of the thread if the suspend count reaches zero.
NTSYSAPI
NTSTATUS
NTAPI
ZwResumeThread(
	IN HANDLE ThreadHandle,
	OUT PULONG PreviousSuspendCount OPTIONAL
	);

// NtGetContextThread retrieves the execution context of a thread.
NTSYSAPI
NTSTATUS
NTAPI
NtGetContextThread(
	IN HANDLE ThreadHandle,
	OUT PCONTEXT Context
	);

// ZwGetContextThread retrieves the execution context of a thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwGetContextThread(
	IN HANDLE ThreadHandle,
	OUT PCONTEXT Context
	);

// NtSetContextThread sets the execution context of a thread.
NTSYSAPI
NTSTATUS
NTAPI
NtSetContextThread(
	IN HANDLE ThreadHandle,
	IN PCONTEXT Context
	);

// ZwSetContextThread sets the execution context of a thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetContextThread(
	IN HANDLE ThreadHandle,
	IN PCONTEXT Context
	);

// NtQueueApcThread queues a user APC request to the APC queue of a thread.
NTSYSAPI
NTSTATUS
NTAPI
NtQueueApcThread(
	IN HANDLE ThreadHandle,
	IN PKNORMAL_ROUTINE ApcRoutine,
	IN PVOID ApcContext OPTIONAL,
	IN PVOID Argument1 OPTIONAL,
	IN PVOID Argument2 OPTIONAL
	);

// ZwQueueApcThread queues a user APC request to the APC queue of a thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueueApcThread(
	IN HANDLE ThreadHandle,
	IN PKNORMAL_ROUTINE ApcRoutine,
	IN PVOID ApcContext OPTIONAL,
	IN PVOID Argument1 OPTIONAL,
	IN PVOID Argument2 OPTIONAL
	);

// NtTestAlert tests whether a thread has been alerted.
NTSYSAPI
NTSTATUS
NTAPI
NtTestAlert(
	VOID
	);

// ZwTestAlert tests whether a thread has been alerted.
NTSYSAPI
NTSTATUS
NTAPI
ZwTestAlert(
	VOID
	);

// NtAlertThread wakes a thread from an alertable wait.
NTSYSAPI
NTSTATUS
NTAPI
NtAlertThread(
	IN HANDLE ThreadHandle
	);

// ZwAlertThread wakes a thread from an alertable wait.
NTSYSAPI
NTSTATUS
NTAPI
ZwAlertThread(
	IN HANDLE ThreadHandle
	);

// NtAlertResumeThread wakes a thread from a possibly suspended alertable wait.
NTSYSAPI
NTSTATUS
NTAPI
NtAlertResumeThread(
	IN HANDLE ThreadHandle,
	OUT PULONG PreviousSuspendCount OPTIONAL
	);

// ZwAlertResumeThread wakes a thread from a possibly suspended alertable wait.
NTSYSAPI
NTSTATUS
NTAPI
ZwAlertResumeThread(
	IN HANDLE ThreadHandle,
	OUT PULONG PreviousSuspendCount OPTIONAL
	);

// NtRegisterThreadTerminatePort registers an LPC port that should be sent a message
// when the thread terminates.
NTSYSAPI
NTSTATUS
NTAPI
NtRegisterThreadTerminatePort(
	IN HANDLE PortHandle
	);

// ZwRegisterThreadTerminatePort registers an LPC port that should be sent a message
// when the thread terminates.
NTSYSAPI
NTSTATUS
NTAPI
ZwRegisterThreadTerminatePort(
	IN HANDLE PortHandle
	);

// NtImpersonateThread enables one thread to impersonate the security context of
// another.
NTSYSAPI
NTSTATUS
NTAPI
NtImpersonateThread(
	IN HANDLE ThreadHandle,
	IN HANDLE TargetThreadHandle,
	IN PSECURITY_QUALITY_OF_SERVICE SecurityQos
	);

// ZwImpersonateThread enables one thread to impersonate the security context of
// another.
NTSYSAPI
NTSTATUS
NTAPI
ZwImpersonateThread(
	IN HANDLE ThreadHandle,
	IN HANDLE TargetThreadHandle,
	IN PSECURITY_QUALITY_OF_SERVICE SecurityQos
	);

// The XxImpersonateAnonymousToken routines are only implemented on Windows 2000 (or later).

// NtImpersonateAnonymousToken sets the impersonation token of a thread to the
// anonymous token (a token with no privileges and “Everyone” as the sole group
// membership).
NTSYSAPI
NTSTATUS
NTAPI
NtImpersonateAnonymousToken(
	IN HANDLE ThreadHandle
	);

// ZwImpersonateAnonymousToken sets the impersonation token of a thread to the
// anonymous token (a token with no privileges and “Everyone” as the sole group
// membership).
NTSYSAPI
NTSTATUS
NTAPI
ZwImpersonateAnonymousToken(
	IN HANDLE ThreadHandle
	);

#ifndef NtCurrentThread
// NtCurrentThread returns a pseudohandle to the current thread.
_NTNATIVE_INLINE
HANDLE
NtCurrentThread(
	VOID
	)
{
	return (HANDLE) -2;
}
#endif

#ifndef ZwCurrentThread
// ZwCurrentThread returns a pseudohandle to the current thread.
_NTNATIVE_INLINE
HANDLE
ZwCurrentThread(
	VOID
	)
{
	return (HANDLE) -2;
}
#endif

#ifndef __IDA__

#ifdef _M__X86_

// NtSwitchToSpareStack switches to the thread's spare user stack space (32 bytes).
__declspec(naked)
_NTNATIVE_INLINE
VOID
NtSwitchToSpareStack(
	VOID
	)
{
	__asm
	{
		mov		eax, dword ptr [esp]
		mov		esp, dword ptr fs:[0x000000AC]
		jmp		eax
	}
}

// NtFreeStackAndTerminateThread uses the thread's spare user stack space to free the
// thread's stack and exit the thread.  The function WILL terminate the process if the
// thread is the last remaining thread in the process.  This function does not return
// to it's caller.  All caller registers are destroyed.  If an error occurs during the
// first portion of the code, an exception will be raised.
__declspec(naked)
__declspec(noreturn)
_NTNATIVE_INLINE
VOID
__stdcall
NtFreeStackAndTerminateThread(
	IN NTSTATUS TerminationCode
	)
{
	__asm
	{
		sub		esp, 0x1C						; sizeof(MEMORY_BASIC_INFORMATION)
		mov		ebx, dword ptr [esp+0x1C+0x04]	; Save the termination code in a nonvolatile register
		xor		edx, edx						; Zero
		mov		edi, dword ptr fs:[0x00000008]	; Stack limit pointer in TEB

		lea		ecx, dword ptr [esp]			; Pointer to MEMORY_BASIC_INFORMATION, for VM query

		push	edx								; ReturnLength pointer, unnecessary (NULL)
		push	0x1C							; sizeof(MEMORY_BASIC_INFORMATION)
		push	ecx								; Return buffer, MEMORY_BASIC_INFORMATION pointer
		push	edx								; MemoryBasicInformation (0)
		push	edi								; Stack limit pointer in TEB
		push	0xFFFFFFFF						; NtCurrentProcess
		call	dword ptr [NtQueryVirtualMemory]; Locate the allocation base for the thread's stack

		xor		edx, edx						; Zero

		cmp		eax, edx						; NT_SUCCESS()
		jge		SuccessfulQuery

		push	eax
		call		dword ptr [RtlRaiseStatus]		; Bail out if we can't determine the stack size...

SuccessfulQuery:								; Cache what we need from the old stack in registers
		mov		ecx, dword ptr [esp+0x04]		; MemoryBasicInformation.AllocationBase

		mov		eax, dword ptr fs:[0x00000018]	; Linear address of TEB
		lea		esp, dword ptr [eax+0x000000A8]	; Switch to the reserve stack space.  From this
												; point on, we have only 32 bytes to work with.  Note
												; that the stack base is at +0xAC, but we make room
												; for a local variable, Free size.
		and		dword ptr [esp], edx			; Free size (must be 0 for MEM_RELEASE)
		lea		esi, dword ptr [esp]			; Pointer to free size

		push	0x00008000						; MEM_RELEASE
		push	esi								; Pointer to free size
		push	ecx								; Start of stack allocation region
		push	0xFFFFFFFF						; NtCurrentProcess
		call	dword ptr [NtFreeVirtualMemory]	; Release the thread's allocated stack

		push	ebx								; Termination code
		push	0								; Supplying NULL for a thread handle will cause
												; NtTerminateThread to terminate the current thread
												; only if it is not the last thread in the process.
		call	dword ptr [NtTerminateThread]	; Attempt to end the current thread...

		push	ebx								; Termination code.  If we're at this point, then the
												; thread is the last in the process, so we terminate
												; the process instead.
		push	0xFFFFFFFF						; NtCurrentProcess
		call	dword ptr [NtTerminateProcess]	; No return from here!
	}

	UNREFERENCED_PARAMETER(TerminationCode);
}

#endif

#endif

_NTNATIVE_END_NT

#endif
