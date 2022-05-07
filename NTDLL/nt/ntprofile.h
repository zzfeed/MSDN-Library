#ifndef NTPROFILE_H
#define NTPROFILE_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtCreateProfile creates a profile object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateProfile(
	OUT PHANDLE ProfileHandle,
	IN HANDLE ProcessHandle,
	IN PVOID Base,
	IN ULONG Size,
	IN ULONG BucketShift,
	IN PULONG Buffer,
	IN ULONG BufferLength,
	IN KPROFILE_SOURCE Source,
	IN ULONG_PTR ProcessorMask
	);

// ZwCreateProfile creates a profile object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateProfile(
	OUT PHANDLE ProfileHandle,
	IN HANDLE ProcessHandle,
	IN PVOID Base,
	IN ULONG Size,
	IN ULONG BucketShift,
	IN PULONG Buffer,
	IN ULONG BufferLength,
	IN KPROFILE_SOURCE Source,
	IN ULONG_PTR ProcessorMask
	);

// NtSetIntervalProfile sets the interval between profiling samples for the specified
// profiling source.
NTSYSAPI
NTSTATUS
NTAPI
NtSetIntervalProfile(
	IN ULONG Interval,
	IN KPROFILE_SOURCE Source
	);

// ZwSetIntervalProfile sets the interval between profiling samples for the specified
// profiling source.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetIntervalProfile(
	IN ULONG Interval,
	IN KPROFILE_SOURCE Source
	);

// NtQueryIntervalProfile retrieves the interval between profiling samples for the
// specified profiling source.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryIntervalProfile(
	IN KPROFILE_SOURCE Source,
	OUT PULONG Interval
	);

// ZwQueryIntervalProfile retrieves the interval between profiling samples for the
// specified profiling source.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryIntervalProfile(
	IN KPROFILE_SOURCE Source,
	OUT PULONG Interval
	);

// NtStartProfile starts the collection of profiling data.
NTSYSAPI
NTSTATUS
NTAPI
NtStartProfile(
	IN HANDLE ProfileHandle
	);

// ZwStartProfile starts the collection of profiling data.
NTSYSAPI
NTSTATUS
NTAPI
ZwStartProfile(
	IN HANDLE ProfileHandle
	);

// NtStopProfile stops the collection of profiling data.
NTSYSAPI
NTSTATUS
NTAPI
NtStopProfile(
	IN HANDLE ProfileHandle
	);

// ZwStopProfile stops the collection of profiling data.
NTSYSAPI
NTSTATUS
NTAPI
ZwStopProfile(
	IN HANDLE ProfileHandle
	);

_NTNATIVE_END_NT

#endif
