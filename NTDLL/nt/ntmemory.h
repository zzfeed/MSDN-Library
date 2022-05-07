#ifndef NTMEMORY_H
#define NTMEMORY_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtAllocateVirtualMemory allocates virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
NtAllocateVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN ULONG ZeroBits,
	IN OUT PULONG AllocationSize,
	IN ULONG AllocationType,
	IN ULONG Protect
	);

// ZwAllocateVirtualMemory allocates virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
ZwAllocateVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN ULONG ZeroBits,
	IN OUT PULONG AllocationSize,
	IN ULONG AllocationType,
	IN ULONG Protect
	);

// NtAllocateVirtualMemory allocates virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
NtAllocateVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN ULONG ZeroBits,
	IN OUT PULONG AllocationSize,
	IN ULONG AllocationType,
	IN ULONG Protect
	);

// ZwAllocateVirtualMemory allocates virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
ZwAllocateVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN ULONG ZeroBits,
	IN OUT PULONG AllocationSize,
	IN ULONG AllocationType,
	IN ULONG Protect
	);

// NtFreeVirtualMemory frees virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
NtFreeVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG FreeSize,
	IN ULONG FreeType
	);

// ZwFreeVirtualMemory frees virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
ZwFreeVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG FreeSize,
	IN ULONG FreeType
	);

// NtQueryVirtualMemory retrieves information about virtual memory in the user mode
// address range.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryVirtualMemory(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	IN MEMORY_INFORMATION_CLASS MemoryInformationClass,
	OUT PVOID MemoryInformation,
	IN ULONG MemoryInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryVirtualMemory retrieves information about virtual memory in the user mode
// address range.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryVirtualMemory(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	IN MEMORY_INFORMATION_CLASS MemoryInformationClass,
	OUT PVOID MemoryInformation,
	IN ULONG MemoryInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtLockVirtualMemory locks virtual memory in the user mode address range, ensuring
// that subsequent accesses to the locked region of virtual memory will not incur page
// faults.
NTSYSAPI
NTSTATUS
NTAPI
NtLockVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG LockSize,
	IN ULONG LockType
	);

// ZwLockVirtualMemory locks virtual memory in the user mode address range, ensuring
// that subsequent accesses to the locked region of virtual memory will not incur page
// faults.
NTSYSAPI
NTSTATUS
NTAPI
ZwLockVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG LockSize,
	IN ULONG LockType
	);

// NtUnlockVirtualMemory unlocks virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
NtUnlockVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG LockSize,
	IN ULONG LockType
	);

// ZwUnlockVirtualMemory unlocks virtual memory in the user mode address range.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnlockVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG LockSize,
	IN ULONG LockType
	);

// NtReadVirtualMemory reads virtual memory in the user mode address range of
// another process.
NTSYSAPI
NTSTATUS
NTAPI
NtReadVirtualMemory(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwReadVirtualMemory reads virtual memory in the user mode address range of
// another process.
NTSYSAPI
NTSTATUS
NTAPI
ZwReadVirtualMemory(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtWriteVirtualMemory writes virtual memory in the user mode address range of
// another process.
NTSYSAPI
NTSTATUS
NTAPI
NtWriteVirtualMemory(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwWriteVirtualMemory writes virtual memory in the user mode address range of
// another process.
NTSYSAPI
NTSTATUS
NTAPI
ZwWriteVirtualMemory(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtProtectVirtualMemory changes the protection on virtual memory in the user mode
// address range.
NTSYSAPI
NTSTATUS
NTAPI
NtProtectVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG ProtectSize,
	IN ULONG NewProtect,
	OUT PULONG OldProtect
	);

// ZwProtectVirtualMemory changes the protection on virtual memory in the user mode
// address range.
NTSYSAPI
NTSTATUS
NTAPI
ZwProtectVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG ProtectSize,
	IN ULONG NewProtect,
	OUT PULONG OldProtect
	);

// NtFlushVirtualMemory flushes virtual memory in the user mode address range that is
// mapped to a file.
NTSYSAPI
NTSTATUS
NTAPI
NtFlushVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG FlushSize,
	OUT PIO_STATUS_BLOCK IoStatusBlock
	);

// ZwFlushVirtualMemory flushes virtual memory in the user mode address range that is
// mapped to a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwFlushVirtualMemory(
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN OUT PULONG FlushSize,
	OUT PIO_STATUS_BLOCK IoStatusBlock
	);

// Physical pages routines are only implemented in Windows 2000 (or later);

// NtAllocateUserPhysicalPages allocates pages of physical memory.
NTSYSAPI
NTSTATUS
NTAPI
NtAllocateUserPhysicalPages(
	IN HANDLE ProcessHandle,
	IN PULONG NumberOfPages,
	OUT PULONG PageFrameNumbers
	);

// ZwAllocateUserPhysicalPages allocates pages of physical memory.
NTSYSAPI
NTSTATUS
NTAPI
ZwAllocateUserPhysicalPages(
	IN HANDLE ProcessHandle,
	IN PULONG NumberOfPages,
	OUT PULONG PageFrameNumbers
	);

// NtFreeUserPhysicalPages frees pages of physical memory.
NTSYSAPI
NTSTATUS
NTAPI
NtFreeUserPhysicalPages(
	IN HANDLE ProcessHandle,
	IN OUT PULONG NumberOfPages,
	IN PULONG PageFrameNumbers
	);

// ZwFreeUserPhysicalPages frees pages of physical memory.
NTSYSAPI
NTSTATUS
NTAPI
ZwFreeUserPhysicalPages(
	IN HANDLE ProcessHandle,
	IN OUT PULONG NumberOfPages,
	IN PULONG PageFrameNumbers
	);

// NtMapUserPhysicalPages maps pages of physical memory into a physical memory
// view.
NTSYSAPI
NTSTATUS
NTAPI
NtMapUserPhysicalPages(
	IN PVOID BaseAddress,
	IN PULONG NumberOfPages,
	IN PULONG PageFrameNumbers
	);

// ZwMapUserPhysicalPages maps pages of physical memory into a physical memory
// view.
NTSYSAPI
NTSTATUS
NTAPI
ZwMapUserPhysicalPages(
	IN PVOID BaseAddress,
	IN PULONG NumberOfPages,
	IN PULONG PageFrameNumbers
	);

// NtMapUserPhysicalPagesScatter maps pages of physical memory into a physical memory
// view.
NTSYSAPI
NTSTATUS
NTAPI
NtMapUserPhysicalPagesScatter(
	IN PVOID *BaseAddresses,
	IN PULONG NumberOfPages,
	IN PULONG PageFrameNumbers
	);

// ZwMapUserPhysicalPagesScatter maps pages of physical memory into a physical memory
// view.
NTSYSAPI
NTSTATUS
NTAPI
ZwMapUserPhysicalPagesScatter(
	IN PVOID *BaseAddresses,
	IN PULONG NumberOfPages,
	IN PULONG PageFrameNumbers
	);

// NtGetWriteWatch retrieves the addresses of pages that have been written to in a region
// of virtual memory.
NTSYSAPI
NTSTATUS
NTAPI
NtGetWriteWatch(
	IN HANDLE ProcessHandle,
	IN ULONG Flags,
	IN PVOID BaseAddress,
	IN ULONG RegionSize,
	OUT PULONG Buffer,
	IN OUT PULONG BufferEntries,
	OUT PULONG Granularity
	);

// ZwGetWriteWatch retrieves the addresses of pages that have been written to in a region
// of virtual memory.
NTSYSAPI
NTSTATUS
NTAPI
ZwGetWriteWatch(
	IN HANDLE ProcessHandle,
	IN ULONG Flags,
	IN PVOID BaseAddress,
	IN ULONG RegionSize,
	OUT PULONG Buffer,
	IN OUT PULONG BufferEntries,
	OUT PULONG Granularity
	);

// NtResetWriteWatch resets the virtual memory write watch information for a region of
// virtual memory.
NTSYSAPI
NTSTATUS
NTAPI
NtResetWriteWatch(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	IN ULONG RegionSize
	);

// ZwResetWriteWatch resets the virtual memory write watch information for a region of
// virtual memory.
NTSYSAPI
NTSTATUS
NTAPI
ZwResetWriteWatch(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress,
	IN ULONG RegionSize
	);

_NTNATIVE_END_NT

#endif
