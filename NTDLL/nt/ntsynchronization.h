#ifndef NTSYNCHRONIZATION_H
#define NTSYNCHRONIZATION_H

#pragma once

#include <nt\nttypes.h>

_NTNATIVE_BEGIN_NT

// NtWaitForSingleObject waits for an object to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitForSingleObject(
	IN HANDLE Handle,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwWaitForSingleObject waits for an object to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitForSingleObject(
	IN HANDLE Handle,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// NtSignalAndWaitForSingleObject signals one object and waits for another to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtSignalAndWaitForSingleObject(
	IN HANDLE HandleToSignal,
	IN HANDLE HandleToWait,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwSignalAndWaitForSingleObject signals one object and waits for another to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwSignalAndWaitForSingleObject(
	IN HANDLE HandleToSignal,
	IN HANDLE HandleToWait,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// NtWaitForMultipleObjects waits for one or more objects to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitForMultipleObjects(
	IN ULONG HandleCount,
	IN PHANDLE Handles,
	IN WAIT_TYPE WaitType,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwWaitForMultipleObjects waits for one or more objects to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitForMultipleObjects(
	IN ULONG HandleCount,
	IN PHANDLE Handles,
	IN WAIT_TYPE WaitType,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

#if _WIN32_WINNT >= 0x0502

//
// These routines were added in Windows Server 2003 Service Pack 1.
// They are identical to NtWaitForMultipleObjects/ZwWaitForMultipleObjects
// on x86 systems, except that NtWaitForMultipleObjects32 does not perform
// proper parameter validation on the WaitType parameter, allowing user mode
// programs to potentially put a threads kernel wait state into an inconsistent
// state.
//

// NtWaitForMultipleObjects32 waits for one or more objects to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitForMultipleObjects32(
	IN ULONG HandleCount,
	IN PHANDLE Handles,
	IN WAIT_TYPE WaitType,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwWaitForMultipleObjects32 waits for one or more objects to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitForMultipleObjects32(
	IN ULONG HandleCount,
	IN PHANDLE Handles,
	IN WAIT_TYPE WaitType,
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

#endif

// NtCreateTimer creates or opens a timer object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateTimer(
	OUT PHANDLE TimerHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN TIMER_TYPE TimerType
	);

// ZwCreateTimer creates or opens a timer object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateTimer(
	OUT PHANDLE TimerHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN TIMER_TYPE TimerType
	);

// NtOpenTimer opens a timer object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenTimer(
	OUT PHANDLE TimerHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenTimer opens a timer object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenTimer(
	OUT PHANDLE TimerHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtCancelTimer deactivates a timer.
NTSYSAPI
NTSTATUS
NTAPI
NtCancelTimer(
	IN HANDLE TimerHandle,
	OUT PBOOLEAN PreviousState OPTIONAL
	);

// ZwCancelTimer deactivates a timer.
NTSYSAPI
NTSTATUS
NTAPI
ZwCancelTimer(
	IN HANDLE TimerHandle,
	OUT PBOOLEAN PreviousState OPTIONAL
	);

// NtSetTimer sets properties of and activates a timer.
NTSYSAPI
NTSTATUS
NTAPI
NtSetTimer(
	IN HANDLE TimerHandle,
	IN PLARGE_INTEGER DueTime,
	IN PTIMER_APC_ROUTINE TimerApcRoutine OPTIONAL,
	IN PVOID TimerContext,
	IN BOOLEAN Resume,
	IN LONG Period,
	OUT PBOOLEAN PreviousState OPTIONAL
	);

// ZwSetTimer sets properties of and activates a timer.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetTimer(
	IN HANDLE TimerHandle,
	IN PLARGE_INTEGER DueTime,
	IN PTIMER_APC_ROUTINE TimerApcRoutine OPTIONAL,
	IN PVOID TimerContext,
	IN BOOLEAN Resume,
	IN LONG Period,
	OUT PBOOLEAN PreviousState OPTIONAL
	);

// NtQueryTimer retrieves information about a timer object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryTimer(
	IN HANDLE TimerHandle,
	IN TIMER_INFORMATION_CLASS TimerInformationClass,
	OUT PVOID TimerInformation,
	IN ULONG TimerInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwQueryTimer retrieves information about a timer object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryTimer(
	IN HANDLE TimerHandle,
	IN TIMER_INFORMATION_CLASS TimerInformationClass,
	OUT PVOID TimerInformation,
	IN ULONG TimerInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// NtCreateEvent creates or opens an event object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateEvent(
	OUT PHANDLE EventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN EVENT_TYPE EventType,
	IN BOOLEAN InitialState
	);

// ZwCreateEvent creates or opens an event object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateEvent(
	OUT PHANDLE EventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN EVENT_TYPE EventType,
	IN BOOLEAN InitialState
	);

// NtOpenEvent opens an event object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenEvent(
	OUT PHANDLE EventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenEvent opens an event object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenEvent(
	OUT PHANDLE EventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtSetEvent sets an event object to the signaled state.
NTSYSAPI
NTSTATUS
NTAPI
NtSetEvent(
	IN HANDLE EventHandle,
	OUT PULONG PreviousState OPTIONAL
	);

// ZwSetEvent sets an event object to the signaled state.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetEvent(
	IN HANDLE EventHandle,
	OUT PULONG PreviousState OPTIONAL
	);

// NtPulseEvent sets an event object to the signaled state releasing all or one waiting
// thread (depending upon the event type) and then resets the event to the unsignaled
// state.
NTSYSAPI
NTSTATUS
NTAPI
NtPulseEvent(
	IN HANDLE EventHandle,
	OUT PULONG PreviousState OPTIONAL
	);

// ZwPulseEvent sets an event object to the signaled state releasing all or one waiting
// thread (depending upon the event type) and then resets the event to the unsignaled
// state.
NTSYSAPI
NTSTATUS
NTAPI
ZwPulseEvent(
	IN HANDLE EventHandle,
	OUT PULONG PreviousState OPTIONAL
	);

// NtResetEvent resets an event object to the unsignaled state.
NTSYSAPI
NTSTATUS
NTAPI
NtResetEvent(
	IN HANDLE EventHandle,
	OUT PULONG PreviousState OPTIONAL
	);

// ZwResetEvent resets an event object to the unsignaled state.
NTSYSAPI
NTSTATUS
NTAPI
ZwResetEvent(
	IN HANDLE EventHandle,
	OUT PULONG PreviousState OPTIONAL
	);

// NtClearEvent resets an event object to the unsignaled state.
NTSYSAPI
NTSTATUS
NTAPI
NtClearEvent(
	IN HANDLE EventHandle
	);

// ZwClearEvent resets an event object to the unsignaled state.
NTSYSAPI
NTSTATUS
NTAPI
ZwClearEvent(
	IN HANDLE EventHandle
	);

// NtQueryEvent retrieves information about an event object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryEvent(
	IN HANDLE EventHandle,
	IN EVENT_INFORMATION_CLASS EventInformationClass,
	OUT PVOID EventInformation,
	IN ULONG EventInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwQueryEvent retrieves information about an event object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryEvent(
	IN HANDLE EventHandle,
	IN EVENT_INFORMATION_CLASS EventInformationClass,
	OUT PVOID EventInformation,
	IN ULONG EventInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// NtCreateSemaphore creates or opens a semaphore object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateSemaphore(
	OUT PHANDLE SemaphoreHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN LONG InitialCount,
	IN LONG MaximumCount
	);

// ZwCreateSemaphore creates or opens a semaphore object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateSemaphore(
	OUT PHANDLE SemaphoreHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN LONG InitialCount,
	IN LONG MaximumCount
	);


// NtOpenSemaphore opens a semaphore object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenSemaphore(
	OUT PHANDLE SemaphoreHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenSemaphore opens a semaphore object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenSemaphore(
	OUT PHANDLE SemaphoreHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtReleaseSemaphore increases the count of a semaphore by a given amount.
NTSYSAPI
NTSTATUS
NTAPI
NtReleaseSemaphore(
	IN HANDLE SemaphoreHandle,
	IN LONG ReleaseCount,
	OUT PLONG PreviousCount OPTIONAL
	);

// ZwReleaseSemaphore increases the count of a semaphore by a given amount.
NTSYSAPI
NTSTATUS
NTAPI
ZwReleaseSemaphore(
	IN HANDLE SemaphoreHandle,
	IN LONG ReleaseCount,
	OUT PLONG PreviousCount OPTIONAL
	);

// NtQuerySemaphore retrieves information about a semaphore object.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySemaphore(
	IN HANDLE SemaphoreHandle,
	IN SEMAPHORE_INFORMATION_CLASS SemaphoreInformationClass,
	OUT PVOID SemaphoreInformation,
	IN ULONG SemaphoreInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwQuerySemaphore retrieves information about a semaphore object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySemaphore(
	IN HANDLE SemaphoreHandle,
	IN SEMAPHORE_INFORMATION_CLASS SemaphoreInformationClass,
	OUT PVOID SemaphoreInformation,
	IN ULONG SemaphoreInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// NtCreateMutant creates or opens a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateMutant(
	OUT PHANDLE MutantHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN BOOLEAN InitialOwner
	);

// ZwCreateMutant creates or opens a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateMutant(
	OUT PHANDLE MutantHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN BOOLEAN InitialOwner
	);

// NtOpenMutant opens a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenMutant(
	OUT PHANDLE MutantHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenMutant opens a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenMutant(
	OUT PHANDLE MutantHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtReleaseMutant releases ownership of a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
NtReleaseMutant(
	IN HANDLE MutantHandle,
	OUT PULONG PreviousState
	);

// ZwReleaseMutant releases ownership of a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
ZwReleaseMutant(
	IN HANDLE MutantHandle,
	OUT PULONG PreviousState
	);

// NtQueryMutant retrieves information about a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryMutant(
	IN HANDLE MutantHandle,
	IN MUTANT_INFORMATION_CLASS MutantInformationClass,
	OUT PVOID MutantInformation,
	IN ULONG MutantInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwQueryMutant retrieves information about a mutant object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryMutant(
	IN HANDLE MutantHandle,
	IN MUTANT_INFORMATION_CLASS MutantInformationClass,
	OUT PVOID MutantInformation,
	IN ULONG MutantInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// NtCreateIoCompletion creates or opens an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateIoCompletion(
	OUT PHANDLE IoCompletionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG NumberOfConcurrentThreads
	);

// ZwCreateIoCompletion creates or opens an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateIoCompletion(
	OUT PHANDLE IoCompletionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG NumberOfConcurrentThreads
	);

// NtOpenIoCompletion opens an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenIoCompletion(
	OUT PHANDLE IoCompletionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenIoCompletion opens an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenIoCompletion(
	OUT PHANDLE IoCompletionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtSetIoCompletion queues an I/O completion message to an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetIoCompletion(
	IN HANDLE IoCompletionHandle,
	IN ULONG_PTR CompletionKey,
	IN ULONG_PTR CompletionValue,
	IN NTSTATUS Status,
	IN ULONG Information
	);

// ZwSetIoCompletion queues an I/O completion message to an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetIoCompletion(
	IN HANDLE IoCompletionHandle,
	IN ULONG_PTR CompletionKey,
	IN ULONG_PTR CompletionValue,
	IN NTSTATUS Status,
	IN ULONG Information
	);

// NtRemoveIoCompletion dequeues an I/O completion message from an I/O completion
// object.
NTSYSAPI
NTSTATUS
NTAPI
NtRemoveIoCompletion(
	IN HANDLE IoCompletionHandle,
	OUT PULONG_PTR CompletionKey,
	OUT PULONG_PTR CompletionValue,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwRemoveIoCompletion dequeues an I/O completion message from an I/O completion
// object.
NTSYSAPI
NTSTATUS
NTAPI
ZwRemoveIoCompletion(
	IN HANDLE IoCompletionHandle,
	OUT PULONG_PTR CompletionKey,
	OUT PULONG_PTR CompletionValue,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// NtQueryIoCompletion retrieves information about an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryIoCompletion(
	IN HANDLE IoCompletionHandle,
	IN IO_COMPLETION_INFORMATION_CLASS IoCompletionInformationClass,
	OUT PVOID IoCompletionInformation,
	IN ULONG IoCompletionInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwQueryIoCompletion retrieves information about an I/O completion object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryIoCompletion(
	IN HANDLE IoCompletionHandle,
	IN IO_COMPLETION_INFORMATION_CLASS IoCompletionInformationClass,
	OUT PVOID IoCompletionInformation,
	IN ULONG IoCompletionInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// NtCreateEventPair creates or opens an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateEventPair(
	OUT PHANDLE EventPairHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwCreateEventPair creates or opens an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateEventPair(
	OUT PHANDLE EventPairHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtOpenEventPair opens an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenEventPair(
	OUT PHANDLE EventPairHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenEventPair opens an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenEventPair(
	OUT PHANDLE EventPairHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtWaitLowEventPair waits for the low event of an event pair to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitLowEventPair(
	IN HANDLE EventPairHandle
	);

// ZwWaitLowEventPair waits for the low event of an event pair to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitLowEventPair(
	IN HANDLE EventPairHandle
	);

// NtWaitHighEventPair waits for the high event of an event pair to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitHighEventPair(
	IN HANDLE EventPairHandle
	);

// ZwWaitHighEventPair waits for the high event of an event pair to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitHighEventPair(
	IN HANDLE EventPairHandle
	);

// NtSetLowWaitHighEventPair signals the low event of an event pair and waits for the
// high event to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtSetLowWaitHighEventPair(
	IN HANDLE EventPairHandle
	);

// ZwSetLowWaitHighEventPair signals the low event of an event pair and waits for the
// high event to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetLowWaitHighEventPair(
	IN HANDLE EventPairHandle
	);

// NtSetHighWaitLowEventPair signals the high event of an event pair and waits for the
// low event to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtSetHighWaitLowEventPair(
	IN HANDLE EventPairHandle
	);

// ZwSetHighWaitLowEventPair signals the high event of an event pair and waits for the
// low event to become signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetHighWaitLowEventPair(
	IN HANDLE EventPairHandle
	);

// NtSetLowEventPair signals the low event of an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetLowEventPair(
	IN HANDLE EventPairHandle
	);

// ZwSetLowEventPair signals the low event of an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetLowEventPair(
	IN HANDLE EventPairHandle
	);

// NtSetHighEventPair signals the high event of an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetHighEventPair(
	IN HANDLE EventPairHandle
	);

// ZwSetHighEventPair signals the high event of an event pair object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetHighEventPair(
	IN HANDLE EventPairHandle
	);

#if _WIN32_WINNT >= 0x501

// NtSetEventBoostPriority sets an event and resets the quantum of the first waiter thread on it.
// This routine can only be used on SynchronizationEvents, not NotificationEvents.  On Workstation
// systems, the priority of the first waiter thread is also boosted by the standard event boost.
NTSYSAPI
NTSTATUS
NTAPI
NtSetEventBoostPriority(
	IN HANDLE EventHandle							// EventHandle must grant EVENT_MODIFY_STATE access.
	);

// ZwSetEventBoostPriority sets an event and resets the quantum of the first waiter thread on it.
// This routine can only be used on SynchronizationEvents, not NotificationEvents.  On Workstation
// systems, the priority of the first waiter thread is also boosted by the standard event boost.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetEventBoostPriority(
	IN HANDLE EventHandle							// EventHandle must grant EVENT_MODIFY_STATE access.
	);

// NtCreateKeyedEvent creates a keyed event.  The reserved parameter must be set
// to zero.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateKeyedEvent(
	OUT PHANDLE KeyedEventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG Reserved							// Must be zero
	);

// ZwCreateKeyedEvent creates a keyed event.  The reserved parameter must be set
// to zero.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateKeyedEvent(
	OUT PHANDLE KeyedEventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG Reserved							// Must be zero
	);

// NtOpenKeyedEvent opens a handle to an existing keyed event.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenKeyedEvent(
	OUT PHANDLE KeyedEventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenKeyedEvent opens a handle to an existing keyed event.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenKeyedEvent(
	OUT PHANDLE KeyedEventHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtWaitForKeyedEvent waits for a keyed event to become signaled.  A keyed event object is considered
// signaled for purposes of NtWaitForKeyedEvent when NtReleaseKeyedEvent for the given key is called.
// The initial state of a keyed event for a given key is signaled.
NTSYSAPI
NTSTATUS
NTAPI
NtWaitForKeyedEvent(
	IN HANDLE KeyedEventHandle,
	IN PVOID Key,														// Bit 0 must not be set.  Waits for key to be released.
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwWaitForKeyedEvent waits for a keyed event to become signaled.  A keyed event object is considered
// signaled for purposes of ZwWaitForKeyedEvent when ZwReleaseKeyedEvent for the given key is called.
// The initial state of a keyed event for a given key is signaled.
NTSYSAPI
NTSTATUS
NTAPI
ZwWaitForKeyedEvent(
	IN HANDLE KeyedEventHandle,
	IN PVOID Key,														// Bit 0 must not be set.  Waits for key to be released.
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// NtReleaseKeyedEvent releases a keyed event.  Threads with the given key are released from their keyed event waits.
NTSYSAPI
NTSTATUS
NTAPI
NtReleaseKeyedEvent(
	IN HANDLE KeyedEventHandle,
	IN PVOID Key,														// Bit 0 must not be set.  Wakes threads waiting on key.
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

// ZwReleaseKeyedEvent releases a keyed event.
NTSYSAPI
NTSTATUS
NTAPI
ZwReleaseKeyedEvent(
	IN HANDLE KeyedEventHandle,
	IN PVOID Key,														// Bit 0 must not be set.  Wakes threads waiting on key.
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Timeout OPTIONAL
	);

#endif

_NTNATIVE_END_NT

#endif
