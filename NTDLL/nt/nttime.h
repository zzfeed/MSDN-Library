#ifndef NTTIME_H
#define NTTIME_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtQuerySystemTime retrieves the system time.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySystemTime(
	OUT PLARGE_INTEGER CurrentTime
	);

// ZwQuerySystemTime retrieves the system time.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySystemTime(
	OUT PLARGE_INTEGER CurrentTime
	);

// NtSetSystemTime sets the system time.
NTSYSAPI
NTSTATUS
NTAPI
NtSetSystemTime(
	IN PLARGE_INTEGER NewTime,
	OUT PLARGE_INTEGER OldTime OPTIONAL
	);


// ZwSetSystemTime sets the system time.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetSystemTime(
	IN PLARGE_INTEGER NewTime,
	OUT PLARGE_INTEGER OldTime OPTIONAL
	);

// NtQueryPerformanceCounter retrieves information from the high-resolution
// performance counter.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryPerformanceCounter(
	OUT PLARGE_INTEGER PerformanceCount,
	OUT PLARGE_INTEGER PerformanceFrequency OPTIONAL
	);

// ZwQueryPerformanceCounter retrieves information from the high-resolution
// performance counter.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryPerformanceCounter(
	OUT PLARGE_INTEGER PerformanceCount,
	OUT PLARGE_INTEGER PerformanceFrequency OPTIONAL
	);

// NtSetTimerResolution sets the resolution of the system timer.
NTSYSAPI
NTSTATUS
NTAPI
NtSetTimerResolution(
	IN ULONG RequestedResolution,
	IN BOOLEAN Set,
	OUT PULONG ActualResolution
	);


// ZwSetTimerResolution sets the resolution of the system timer.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetTimerResolution(
	IN ULONG RequestedResolution,
	IN BOOLEAN Set,
	OUT PULONG ActualResolution
	);

// NtQueryTimerResolution retrieves information about the resolution of the system
// timer.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryTimerResolution(
	OUT PULONG CoarsestResolution,
	OUT PULONG FinestResolution,
	OUT PULONG ActualResolution
	);

// ZwQueryTimerResolution retrieves information about the resolution of the system
// timer.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryTimerResolution(
	OUT PULONG CoarsestResolution,
	OUT PULONG FinestResolution,
	OUT PULONG ActualResolution
	);

// NtDelayExecution suspends the execution of the current thread for a specified interval.
NTSYSAPI
NTSTATUS
NTAPI
NtDelayExecution(
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Interval // Negative is relative, positive is absolute
	);

// ZwDelayExecution suspends the execution of the current thread for a specified interval.
NTSYSAPI
NTSTATUS
NTAPI
ZwDelayExecution(
	IN BOOLEAN Alertable,
	IN PLARGE_INTEGER Interval // Negative is relative, positive is absolute
	);

// NtYieldExecution yields the use of the processor by the current thread to any other
// thread that is ready to use it.
NTSYSAPI
NTSTATUS
NTAPI
NtYieldExecution(
	VOID
	);

// ZwYieldExecution yields the use of the processor by the current thread to any other
// thread that is ready to use it.
NTSYSAPI
NTSTATUS
NTAPI
ZwYieldExecution(
	VOID
	);

// NtGetTickCount retrieves the number of milliseconds that have elapsed since the system
// booted.
NTSYSAPI
ULONG
NTAPI
NtGetTickCount(
	VOID
	);

#if _WIN32_WINNT < 0x0501

// ZwGetTickCount retrieves the number of milliseconds that have elapsed since the system
// booted.
NTSYSAPI
ULONG
NTAPI
ZwGetTickCount(
	VOID
	);

#endif

_NTNATIVE_END_NT

#endif
