#ifndef NTSECTION_H
#define NTSECTION_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtCreateSection creates a section object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateSection(
	OUT PHANDLE SectionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PLARGE_INTEGER SectionSize OPTIONAL,
	IN ULONG Protect,
	IN ULONG Attributes,
	IN HANDLE FileHandle
	);

// ZwCreateSection creates a section object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateSection(
	OUT PHANDLE SectionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN PLARGE_INTEGER SectionSize OPTIONAL,
	IN ULONG Protect,
	IN ULONG Attributes,
	IN HANDLE FileHandle
	);

// NtOpenSection opens a section object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenSection(
	OUT PHANDLE SectionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// ZwOpenSection opens a section object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenSection(
	OUT PHANDLE SectionHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtQuerySection retrieves information about a section object.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySection(
	IN HANDLE SectionHandle,
	IN SECTION_INFORMATION_CLASS SectionInformationClass,
	OUT PVOID SectionInformation,
	IN ULONG SectionInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// ZwQuerySection retrieves information about a section object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySection(
	IN HANDLE SectionHandle,
	IN SECTION_INFORMATION_CLASS SectionInformationClass,
	OUT PVOID SectionInformation,
	IN ULONG SectionInformationLength,
	OUT PULONG ResultLength OPTIONAL
	);

// NtExtendSection extends a file backed data section.
NTSYSAPI
NTSTATUS
NTAPI
NtExtendSection(
	IN HANDLE SectionHandle,
	IN PLARGE_INTEGER SectionSize
	);

// ZwExtendSection extends a file backed data section.
NTSYSAPI
NTSTATUS
NTAPI
ZwExtendSection(
	IN HANDLE SectionHandle,
	IN PLARGE_INTEGER SectionSize
	);

// NtMapViewOfSection maps a view of a section to a range of virtual addresses.
NTSYSAPI
NTSTATUS
NTAPI
NtMapViewOfSection(
	IN HANDLE SectionHandle,
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN ULONG ZeroBits,
	IN ULONG CommitSize,
	IN OUT PLARGE_INTEGER SectionOffset OPTIONAL,
	IN OUT PULONG ViewSize,
	IN SECTION_INHERIT InheritDisposition,
	IN ULONG AllocationType,
	IN ULONG Protect
	);

// ZwMapViewOfSection maps a view of a section to a range of virtual addresses.
NTSYSAPI
NTSTATUS
NTAPI
ZwMapViewOfSection(
	IN HANDLE SectionHandle,
	IN HANDLE ProcessHandle,
	IN OUT PVOID *BaseAddress,
	IN ULONG ZeroBits,
	IN ULONG CommitSize,
	IN OUT PLARGE_INTEGER SectionOffset OPTIONAL,
	IN OUT PULONG ViewSize,
	IN SECTION_INHERIT InheritDisposition,
	IN ULONG AllocationType,
	IN ULONG Protect
	);

// NtUnmapViewOfSection unmaps a view of a section.
NTSYSAPI
NTSTATUS
NTAPI
NtUnmapViewOfSection(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress
	);

// ZwUnmapViewOfSection unmaps a view of a section.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnmapViewOfSection(
	IN HANDLE ProcessHandle,
	IN PVOID BaseAddress
	);

// XxAreMappedFilesTheSame is only implemented in Windows 2000 (or later).

// NtAreMappedFilesTheSame tests whether two pointers refer to image sections backed
// by the same file.
NTSYSAPI
NTSTATUS
NTAPI
NtAreMappedFilesTheSame(
	IN PVOID Address1,
	IN PVOID Address2
	);

// ZwAreMappedFilesTheSame tests whether two pointers refer to image sections backed
// by the same file.
NTSYSAPI
NTSTATUS
NTAPI
ZwAreMappedFilesTheSame(
	IN PVOID Address1,
	IN PVOID Address2
	);

_NTNATIVE_END_NT

#endif
