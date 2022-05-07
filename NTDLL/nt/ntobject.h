#ifndef NTOBJECT_H
#define NTOBJECT_H

#pragma once

_NTNATIVE_BEGIN_NT

//
// General functions
//

_NTNATIVE_INLINE VOID 
  InitializeObjectAttributes(
  OUT POBJECT_ATTRIBUTES  InitializedAttributes,
  IN PUNICODE_STRING  ObjectName,
  IN ULONG  Attributes,
  IN HANDLE  RootDirectory,
  IN PSECURITY_DESCRIPTOR  SecurityDescriptor
  )
{
	InitializedAttributes->Length = sizeof( OBJECT_ATTRIBUTES );
	InitializedAttributes->RootDirectory = RootDirectory;
	InitializedAttributes->Attributes = Attributes;
	InitializedAttributes->ObjectName = ObjectName;
	InitializedAttributes->SecurityDescriptor = SecurityDescriptor;
	InitializedAttributes->SecurityQualityOfService = NULL;
}

// NtQueryObject queries generic information about any object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryObject(
	IN HANDLE ObjectHandle,
	IN OBJECT_INFORMATION_CLASS ObjectInformationClass,
	OUT PVOID ObjectInformation,
	IN ULONG ObjectInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryObject queries generic information about any object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryObject(
	IN HANDLE ObjectHandle,
	IN OBJECT_INFORMATION_CLASS ObjectInformationClass,
	OUT PVOID ObjectInformation,
	IN ULONG ObjectInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtSetInformationObject sets attributes on a handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationObject(
	IN HANDLE ObjectHandle,
	IN OBJECT_INFORMATION_CLASS ObjectInformationClass,
	IN PVOID ObjectInformation,
	IN ULONG ObjectInformationLength
	);

// ZwSetInformationObject sets attributes on a handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationObject(
	IN HANDLE ObjectHandle,
	IN OBJECT_INFORMATION_CLASS ObjectInformationClass,
	IN PVOID ObjectInformation,
	IN ULONG ObjectInformationLength
	);

// NtDuplicateObject duplicates the handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
NtDuplicateObject(
	IN HANDLE SourceProcessHandle,
	IN HANDLE SourceHandle,
	IN HANDLE TargetProcessHandle OPTIONAL,
	OUT PHANDLE TargetHandle OPTIONAL,
	IN ACCESS_MASK DesiredAccess,
	IN ULONG Attributes,
	IN ULONG Options
	);

// ZwDuplicateObject duplicates the handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwDuplicateObject(
	IN HANDLE SourceProcessHandle,
	IN HANDLE SourceHandle,
	IN HANDLE TargetProcessHandle OPTIONAL,
	OUT PHANDLE TargetHandle OPTIONAL,
	IN ACCESS_MASK DesiredAccess,
	IN ULONG Attributes,
	IN ULONG Options
	);

// NtMakeTemporaryObject removes the permanent attribute of an object if it was
// present.
NTSYSAPI
NTSTATUS
NTAPI
NtMakeTemporaryObject(
	IN HANDLE Handle
	);

// ZwMakeTemporaryObject removes the permanent attribute of an object if it was
// present.
NTSYSAPI
NTSTATUS
NTAPI
ZwMakeTemporaryObject(
	IN HANDLE Handle
	);

// NtClose closes a handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
NtClose(
	IN HANDLE Handle
	);

// ZwClose closes a handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwClose(
	IN HANDLE Handle
	);

// NtQuerySecurityObject retrieves a copy of the security descriptor protecting an
// object.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySecurityObject(
	IN HANDLE Handle,
	IN SECURITY_INFORMATION SecurityInformation,
	OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN ULONG SecurityDescriptorLength,
	OUT PULONG ReturnLength
	);

// ZwQuerySecurityObject retrieves a copy of the security descriptor protecting an
// object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySecurityObject(
	IN HANDLE Handle,
	IN SECURITY_INFORMATION SecurityInformation,
	OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN ULONG SecurityDescriptorLength,
	OUT PULONG ReturnLength
	);

// NtSetSecurityObject sets the security descriptor protecting an object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetSecurityObject(
	IN HANDLE Handle,
	IN SECURITY_INFORMATION SecurityInformation,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor
	);

// ZwSetSecurityObject sets the security descriptor protecting an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetSecurityObject(
	IN HANDLE Handle,
	IN SECURITY_INFORMATION SecurityInformation,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor
	);

// NtCreateDirectoryObject creates or opens an object directory.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateDirectoryObject(
	OUT PHANDLE DirectoryHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwCreateDirectoryObject creates or opens an object directory.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateDirectoryObject(
	OUT PHANDLE DirectoryHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtOpenDirectoryObject opens an object directory.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenDirectoryObject(
	OUT PHANDLE DirectoryHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenDirectoryObject opens an object directory.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenDirectoryObject(
	OUT PHANDLE DirectoryHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtQueryDirectoryObject retrieves information about the contents of an object
// directory.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDirectoryObject(
	IN HANDLE DirectoryHandle,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN ReturnSingleEntry,
	IN BOOLEAN RestartScan,
	IN OUT PULONG Context,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryDirectoryObject retrieves information about the contents of an object
// directory.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryDirectoryObject(
	IN HANDLE DirectoryHandle,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN ReturnSingleEntry,
	IN BOOLEAN RestartScan,
	IN OUT PULONG Context,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtCreateSymbolicLinkObject creates or opens a symbolic link object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateSymbolicLinkObject(
	OUT PHANDLE SymbolicLinkHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PUNICODE_STRING TargetName
	);

// ZwCreateSymbolicLinkObject creates or opens a symbolic link object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateSymbolicLinkObject(
	OUT PHANDLE SymbolicLinkHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PUNICODE_STRING TargetName
	);

// NtOpenSymbolicLinkObject opens a symbolic link object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenSymbolicLinkObject(
	OUT PHANDLE SymbolicLinkHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenSymbolicLinkObject opens a symbolic link object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenSymbolicLinkObject(
	OUT PHANDLE SymbolicLinkHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtQuerySymbolicLinkObject retrieves the name of the target of a symbolic link.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySymbolicLinkObject(
	IN HANDLE SymbolicLinkHandle,
	IN OUT PUNICODE_STRING TargetName,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQuerySymbolicLinkObject retrieves the name of the target of a symbolic link.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySymbolicLinkObject(
	IN HANDLE SymbolicLinkHandle,
	IN OUT PUNICODE_STRING TargetName,
	OUT PULONG ReturnLength OPTIONAL
	);

#if _WIN32_WINNT >= 0x0501

// NtMakePermanentObject sets the permanent attribute of an object if it was not
// present.  SeCreatePermanentPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtMakePermanentObject(
	IN HANDLE Object				// Object handle need not grant any specific access rights.
	);

// ZwMakePermanentObject sets the permanent attribute of an object if it was not
// present.  SeCreatePermanentPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwMakePermanentObject(
	IN HANDLE Object				// Object handle need not grant any specific access rights.
	);

#endif

_NTNATIVE_END_NT

#endif
