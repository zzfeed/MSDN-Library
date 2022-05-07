#ifndef NTFILE_H
#define NTFILE_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtCreateFile creates or opens a file.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PLARGE_INTEGER AllocationSize OPTIONAL,
	IN ULONG FileAttributes,
	IN ULONG ShareAccess,
	IN ULONG CreateDisposition,
	IN ULONG CreateOptions,
	IN PVOID EaBuffer OPTIONAL,
	IN ULONG EaLength
	);

// ZwCreateFile creates or opens a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PLARGE_INTEGER AllocationSize OPTIONAL,
	IN ULONG FileAttributes,
	IN ULONG ShareAccess,
	IN ULONG CreateDisposition,
	IN ULONG CreateOptions,
	IN PVOID EaBuffer OPTIONAL,
	IN ULONG EaLength
	);

// NtOpenFile opens a file.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG ShareAccess,
	IN ULONG OpenOptions
	);

// ZwOpenFile opens a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG ShareAccess,
	IN ULONG OpenOptions
	);

// NtDeleteFile deletes a file.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteFile(
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwDeleteFile deletes a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteFile(
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtFlushBuffersFile flushes any cached data to the storage medium or network.
NTSYSAPI
NTSTATUS
NTAPI
NtFlushBuffersFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock
	);

// ZwFlushBuffersFile flushes any cached data to the storage medium or network.
NTSYSAPI
NTSTATUS
NTAPI
ZwFlushBuffersFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock
	);

// NtCancelIoFile cancels all pending I/O operations initiated by the current thread on
// the file object.
NTSYSAPI
NTSTATUS
NTAPI
NtCancelIoFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock
	);

// ZwCancelIoFile cancels all pending I/O operations initiated by the current thread on
// the file object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCancelIoFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock
	);

// NtReadFile reads data from a file.
NTSYSAPI
NTSTATUS
NTAPI
NtReadFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// ZwReadFile reads data from a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwReadFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// NtWriteFile writes data to a file.
NTSYSAPI
NTSTATUS
NTAPI
NtWriteFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PVOID Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// ZwWriteFile writes data to a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwWriteFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PVOID Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// NtReadFileScatter reads data from a file and stores it in a number of discontiguous
// buffers.
NTSYSAPI
NTSTATUS
NTAPI
NtReadFileScatter(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_SEGMENT_ELEMENT Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// ZwReadFileScatter reads data from a file and stores it in a number of discontiguous
// buffers.
NTSYSAPI
NTSTATUS
NTAPI
ZwReadFileScatter(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_SEGMENT_ELEMENT Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// NtWriteFileGather retrieves data from a number of discontiguous buffers and writes it
// to a file.
NTSYSAPI
NTSTATUS
NTAPI
NtWriteFileGather(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_SEGMENT_ELEMENT Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// ZwWriteFileGather retrieves data from a number of discontiguous buffers and writes it
// to a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwWriteFileGather(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_SEGMENT_ELEMENT Buffer,
	IN ULONG Length,
	IN PLARGE_INTEGER ByteOffset OPTIONAL,
	IN PULONG Key OPTIONAL
	);

// NtLockFile locks a region of a file.
NTSYSAPI
NTSTATUS
NTAPI
NtLockFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PULARGE_INTEGER LockOffset,
	IN PULARGE_INTEGER LockLength,
	IN ULONG Key,
	IN BOOLEAN FailImmediately,
	IN BOOLEAN ExclusiveLock
	);

// ZwLockFile locks a region of a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwLockFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PULARGE_INTEGER LockOffset,
	IN PULARGE_INTEGER LockLength,
	IN ULONG Key,
	IN BOOLEAN FailImmediately,
	IN BOOLEAN ExclusiveLock
	);

// NtUnlockFile unlocks a locked region of a file.
NTSYSAPI
NTSTATUS
NTAPI
NtUnlockFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PULARGE_INTEGER LockOffset,
	IN PULARGE_INTEGER LockLength,
	IN ULONG Key
	);

// ZwUnlockFile unlocks a locked region of a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnlockFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PULARGE_INTEGER LockOffset,
	IN PULARGE_INTEGER LockLength,
	IN ULONG Key
	);

// NtDeviceIoControlFile performs an I/O control operation on a file object that represents
// a device.
NTSYSAPI
NTSTATUS
NTAPI
NtDeviceIoControlFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG IoControlCode,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength
	);

// ZwDeviceIoControlFile performs an I/O control operation on a file object that represents
// a device.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeviceIoControlFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG IoControlCode,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength
	);

// NtFsControlFile performs a file system control operation on a file object that represents
// a file-structured device.
NTSYSAPI
NTSTATUS
NTAPI
NtFsControlFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG FsControlCode,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength
	);

// ZwFsControlFile performs a file system control operation on a file object that represents
// a file-structured device.
NTSYSAPI
NTSTATUS
NTAPI
ZwFsControlFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG FsControlCode,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength
	);

// NtNotifyChangeDirectoryFile monitors a directory for changes.
NTSYSAPI
NTSTATUS
NTAPI
NtNotifyChangeDirectoryFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PFILE_NOTIFY_INFORMATION Buffer,
	IN ULONG BufferLength,
	IN ULONG NotifyFilter,
	IN BOOLEAN WatchSubtree
	);

// ZwNotifyChangeDirectoryFile monitors a directory for changes.
NTSYSAPI
NTSTATUS
NTAPI
ZwNotifyChangeDirectoryFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PFILE_NOTIFY_INFORMATION Buffer,
	IN ULONG BufferLength,
	IN ULONG NotifyFilter,
	IN BOOLEAN WatchSubtree
	);

// NtQueryEaFile retrieves information about the extended attributes of a file.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryEaFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PFILE_FULL_EA_INFORMATION Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN ReturnSingleEntry,
	IN PFILE_GET_EA_INFORMATION EaList OPTIONAL,
	IN ULONG EaListLength,
	IN PULONG EaIndex OPTIONAL,
	IN BOOLEAN RestartScan
	);

// ZwQueryEaFile retrieves information about the extended attributes of a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryEaFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PFILE_FULL_EA_INFORMATION Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN ReturnSingleEntry,
	IN PFILE_GET_EA_INFORMATION EaList OPTIONAL,
	IN ULONG EaListLength,
	IN PULONG EaIndex OPTIONAL,
	IN BOOLEAN RestartScan
	);

// NtSetEaFile sets the extended attributes of a file.
NTSYSAPI
NTSTATUS
NTAPI
NtSetEaFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_FULL_EA_INFORMATION Buffer,
	IN ULONG BufferLength
	);

// ZwSetEaFile sets the extended attributes of a file.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetEaFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_FULL_EA_INFORMATION Buffer,
	IN ULONG BufferLength
	);

// NtCreateNamedPipeFile creates a named pipe.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateNamedPipeFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG ShareAccess,
	IN ULONG CreateDisposition,
	IN ULONG CreateOptions,
	IN BOOLEAN TypeMessage,
	IN BOOLEAN ReadmodeMessage,
	IN BOOLEAN Nonblocking,
	IN ULONG MaxInstances,
	IN ULONG InBufferSize,
	IN ULONG OutBufferSize,
	IN PLARGE_INTEGER DefaultTimeout OPTIONAL
	);

// ZwCreateNamedPipeFile creates a named pipe.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateNamedPipeFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG ShareAccess,
	IN ULONG CreateDisposition,
	IN ULONG CreateOptions,
	IN BOOLEAN TypeMessage,
	IN BOOLEAN ReadmodeMessage,
	IN BOOLEAN Nonblocking,
	IN ULONG MaxInstances,
	IN ULONG InBufferSize,
	IN ULONG OutBufferSize,
	IN PLARGE_INTEGER DefaultTimeout OPTIONAL
	);

// NtCreateMailslotFile creates a mailslot.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateMailslotFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG CreateOptions,
	IN ULONG InBufferSize,
	IN ULONG MaxMessageSize,
	IN PLARGE_INTEGER ReadTimeout OPTIONAL
	);

// ZwCreateMailslotFile creates a mailslot.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateMailslotFile(
	OUT PHANDLE FileHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG CreateOptions,
	IN ULONG InBufferSize,
	IN ULONG MaxMessageSize,
	IN PLARGE_INTEGER ReadTimeout OPTIONAL
	);

// NtQueryVolumeInformationFile retrieves information about a file system volume.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryVolumeInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID VolumeInformation,
	IN ULONG VolumeInformationLength,
	IN FS_INFORMATION_CLASS VolumeInformationClass
	);

// ZwQueryVolumeInformationFile retrieves information about a file system volume.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryVolumeInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID VolumeInformation,
	IN ULONG VolumeInformationLength,
	IN FS_INFORMATION_CLASS VolumeInformationClass
	);

// NtSetVolumeInformationFile sets information affecting a file system volume.
NTSYSAPI
NTSTATUS
NTAPI
NtSetVolumeInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	IN FS_INFORMATION_CLASS VolumeInformationClass
	);

// ZwSetVolumeInformationFile sets information affecting a file system volume.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetVolumeInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	IN FS_INFORMATION_CLASS VolumeInformationClass
	);

// The XxQueryQuotaInformationFile routines are only implemented on Windows 2000 (or later).

#if _WIN32_WINNT >= 0x0500

// NtQueryQuotaInformationFile retrieves information about the disk quotas on a
// volume.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryQuotaInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PFILE_USER_QUOTA_INFORMATION Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN ReturnSingleEntry,
	IN PFILE_QUOTA_LIST_INFORMATION QuotaList OPTIONAL,
	IN ULONG QuotaListLength,
	IN PSID ResumeSid OPTIONAL,
	IN BOOLEAN RestartScan
	);

// ZwQueryQuotaInformationFile retrieves information about the disk quotas on a
// volume.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryQuotaInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PFILE_USER_QUOTA_INFORMATION Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN ReturnSingleEntry,
	IN PFILE_QUOTA_LIST_INFORMATION QuotaList OPTIONAL,
	IN ULONG QuotaListLength,
	IN PSID ResumeSid OPTIONAL,
	IN BOOLEAN RestartScan
	);

// NtSetQuotaInformationFile sets disk quota restrictions on a volume.
NTSYSAPI
NTSTATUS
NTAPI
NtSetQuotaInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_USER_QUOTA_INFORMATION Buffer,
	IN ULONG BufferLength
	);

// ZwSetQuotaInformationFile sets disk quota restrictions on a volume.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetQuotaInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PFILE_USER_QUOTA_INFORMATION Buffer,
	IN ULONG BufferLength
	);

#endif

// NtQueryAttributesFile retrieves basic information about a file object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryAttributesFile(
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PFILE_BASIC_INFORMATION FileInformation
	);

// ZwQueryAttributesFile retrieves basic information about a file object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryAttributesFile(
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PFILE_BASIC_INFORMATION FileInformation
	);

// NtQueryFullAttributesFile retrieves extended information about a file object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryFullAttributesFile(
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PFILE_NETWORK_OPEN_INFORMATION FileInformation
	);

// ZwQueryFullAttributesFile retrieves extended information about a file object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryFullAttributesFile(
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	OUT PFILE_NETWORK_OPEN_INFORMATION FileInformation
	);

// NtQueryInformationFile retrieves information about a file object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID FileInformation,
	IN ULONG FileInformationLength,
	IN FILE_INFORMATION_CLASS FileInformationClass
	);

// ZwQueryInformationFile retrieves information about a file object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID FileInformation,
	IN ULONG FileInformationLength,
	IN FILE_INFORMATION_CLASS FileInformationClass
	);

// NtSetInformationFile sets information affecting a file object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PVOID FileInformation,
	IN ULONG FileInformationLength,
	IN FILE_INFORMATION_CLASS FileInformationClass
	);

// ZwSetInformationFile sets information affecting a file object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationFile(
	IN HANDLE FileHandle,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN PVOID FileInformation,
	IN ULONG FileInformationLength,
	IN FILE_INFORMATION_CLASS FileInformationClass
	);

// NtQueryDirectoryFile retrieves information about the contents of a directory.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDirectoryFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID FileInformation,
	IN ULONG FileInformationLength,
	IN FILE_INFORMATION_CLASS FileInformationClass,
	IN BOOLEAN ReturnSingleEntry,
	IN PUNICODE_STRING FileName OPTIONAL,
	IN BOOLEAN RestartScan
	);

// ZwQueryDirectoryFile retrieves information about the contents of a directory.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryDirectoryFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID FileInformation,
	IN ULONG FileInformationLength,
	IN FILE_INFORMATION_CLASS FileInformationClass,
	IN BOOLEAN ReturnSingleEntry,
	IN PUNICODE_STRING FileName OPTIONAL,
	IN BOOLEAN RestartScan
	);

#if _WIN32_WINNT < 0x0500

// The XxQueryOleDirectoryFile routines are only implemented in Windows NT 4.0.

// The operation specified by NtQueryOleDirectoryFile is not implemented by any of the
// supported file systems.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryOleDirectoryFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL ,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	IN FILE_INFORMATION_CLASS FileInformationClass,
	IN BOOLEAN ReturnSingleEntry,
	IN PUNICODE_STRING FileName,
	IN BOOLEAN RestartScan
	);

// The operation specified by ZwQueryOleDirectoryFile is not implemented by any of the
// supported file systems.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryOleDirectoryFile(
	IN HANDLE FileHandle,
	IN HANDLE Event OPTIONAL ,
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	IN FILE_INFORMATION_CLASS FileInformationClass,
	IN BOOLEAN ReturnSingleEntry,
	IN PUNICODE_STRING FileName,
	IN BOOLEAN RestartScan
	);

#endif

_NTNATIVE_END_NT

#endif
