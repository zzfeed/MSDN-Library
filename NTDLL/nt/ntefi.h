#ifndef NTMISC_H
#define NTMISC_H

#pragma once

_NTNATIVE_BEGIN_NT

//
// These routines are only implemented on Extensible Firmware Interface (EFI) systems.
// No information on them is available; information here is purely conjecture based on
// the number of arguments for system services.  These system services return
// STATUS_NOT_IMPLEMENTED on non-EFI systems.
//


// NtAddBootEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtAddBootEntry(
	IN PUNICODE_STRING EntryName,
	IN PUNICODE_STRING EntryValue
	);

// ZwAddBootEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwAddBootEntry(
	IN PUNICODE_STRING EntryName,
	IN PUNICODE_STRING EntryValue
	);

// NtAddDriverEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtAddDriverEntry(
	IN PUNICODE_STRING DriverName,
	IN PUNICODE_STRING DriverPath
	);

// ZwAddDriverEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwAddDriverEntry(
	IN PUNICODE_STRING DriverName,
	IN PUNICODE_STRING DriverPath
	);

// NtDeleteBootEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteBootEntry(
	IN PUNICODE_STRING EntryName,
	IN PUNICODE_STRING EntryValue
	);

// ZwDeleteBootEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteBootEntry(
	IN PUNICODE_STRING EntryName,
	IN PUNICODE_STRING EntryValue
	);

// NtDeleteDriverEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteDriverEntry(
	IN PUNICODE_STRING DriverName,
	IN PUNICODE_STRING DriverPath
	);

// ZwDeleteDriverEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteDriverEntry(
	IN PUNICODE_STRING DriverName,
	IN PUNICODE_STRING DriverPath
	);

// NtEnumerateBootEntries is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtEnumerateBootEntries(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// ZwEnumerateBootEntries is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwEnumerateBootEntries(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// NtEnumerateDriverEntries is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtEnumerateDriverEntries(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// ZwEnumerateDriverEntries is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwEnumerateDriverEntries(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// NtEnumerateSystemEnvironmentValuesEx is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtEnumerateSystemEnvironmentValuesEx(
	IN ULONG Unknown1,
	IN ULONG Unknown2,
	IN ULONG Unknown3
	);

// ZwEnumerateSystemEnvironmentValuesEx is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwEnumerateSystemEnvironmentValuesEx(
	IN ULONG Unknown1,
	IN ULONG Unknown2,
	IN ULONG Unknown3
	);

// NtModifyBootEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtModifyBootEntry(
	IN PUNICODE_STRING EntryName,
	IN PUNICODE_STRING EntryValue
	);

// ZwModifyBootEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwModifyBootEntry(
	IN PUNICODE_STRING EntryName,
	IN PUNICODE_STRING EntryValue
	);

// NtModifyDriverEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtModifyDriverEntry(
	IN PUNICODE_STRING DriverName,
	IN PUNICODE_STRING DriverPath
	);

// ZwModifyDriverEntry is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwModifyDriverEntry(
	IN PUNICODE_STRING DriverName,
	IN PUNICODE_STRING DriverPath
	);

// NtQueryBootEntryOrder is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryBootEntryOrder(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// ZwQueryBootEntryOrder is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryBootEntryOrder(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// NtQueryBootOptions is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryBootOptions(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// ZwQueryBootOptions is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryBootOptions(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// NtQueryDriverEntryOrder is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryDriverEntryOrder(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// ZwQueryDriverEntryOrder is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryDriverEntryOrder(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// NtQuerySystemEnvironmentValueEx is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySystemEnvironmentValueEx(
	IN ULONG Unknown1,
	IN ULONG Unknown2,
	IN ULONG Unknown3,
	IN ULONG Unknown4,
	IN ULONG Unknown5
	);

// ZwQuerySystemEnvironmentValueEx is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySystemEnvironmentValueEx(
	IN ULONG Unknown1,
	IN ULONG Unknown2,
	IN ULONG Unknown3,
	IN ULONG Unknown4,
	IN ULONG Unknown5
	);

// NtTranslatePathName is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtTranslatePathName(
	IN ULONG Unknown1,
	IN ULONG Unknown2,
	IN ULONG Unknown3,
	IN ULONG Unknown4
	);

// ZwTranslatePathName is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwTranslatePathName(
	IN ULONG Unknown1,
	IN ULONG Unknown2,
	IN ULONG Unknown3,
	IN ULONG Unknown4
	);

// NtSetBootEntryOrder is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
NtSetBootEntryOrder(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

// ZwSetBootEntryOrder is not currently implemented on x86.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetBootEntryOrder(
	IN ULONG Unknown1,
	IN ULONG Unknown2
	);

_NTNATIVE_END_NT

#endif
