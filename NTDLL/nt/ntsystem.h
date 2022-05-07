#ifndef NTSYSTEM_H
#define NTSYSTEM_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtQuerySystemInformation queries information about the system.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySystemInformation(
	IN SYSTEM_INFORMATION_CLASS SystemInformationClass,
	IN OUT PVOID SystemInformation,
	IN ULONG SystemInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQuerySystemInformation queries information about the system.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySystemInformation(
	IN SYSTEM_INFORMATION_CLASS SystemInformationClass,
	IN OUT PVOID SystemInformation,
	IN ULONG SystemInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtSetSystemInformation sets information that affects the operation of the system.
NTSYSAPI
NTSTATUS
NTAPI
NtSetSystemInformation(
	IN SYSTEM_INFORMATION_CLASS SystemInformationClass,
	IN OUT PVOID SystemInformation,
	IN ULONG SystemInformationLength
	);

// ZwSetSystemInformation sets information that affects the operation of the system.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetSystemInformation(
	IN SYSTEM_INFORMATION_CLASS SystemInformationClass,
	IN OUT PVOID SystemInformation,
	IN ULONG SystemInformationLength
	);

// NtQuerySystemEnvironmentValue queries the value of a system environment variable
// stored in the non-volatile (CMOS) memory of the system.
NTSYSAPI
NTSTATUS
NTAPI
NtQuerySystemEnvironmentValue(
	IN PUNICODE_STRING Name,
	OUT PVOID Value,
	IN ULONG ValueLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQuerySystemEnvironmentValue queries the value of a system environment variable
// stored in the non-volatile (CMOS) memory of the system.
NTSYSAPI
NTSTATUS
NTAPI
ZwQuerySystemEnvironmentValue(
	IN PUNICODE_STRING Name,
	OUT PVOID Value,
	IN ULONG ValueLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtSetSystemEnvironmentValue sets the value of a system environment variable stored in
// the non-volatile (CMOS) memory of the system.
NTSYSAPI
NTSTATUS
NTAPI
NtSetSystemEnvironmentValue(
	IN PUNICODE_STRING Name,
	IN PUNICODE_STRING Value
	);

// ZwSetSystemEnvironmentValue sets the value of a system environment variable stored in
// the non-volatile (CMOS) memory of the system.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetSystemEnvironmentValue(
	IN PUNICODE_STRING Name,
	IN PUNICODE_STRING Value
	);

// NtShutdownSystem shuts down the system.
NTSYSAPI
NTSTATUS
NTAPI
NtShutdownSystem(
	IN SHUTDOWN_ACTION Action
	);

// ZwShutdownSystem shuts down the system.
NTSYSAPI
NTSTATUS
NTAPI
ZwShutdownSystem(
	IN SHUTDOWN_ACTION Action
	);

// NtSystemDebugControl performs a subset of the operations available to a kernel mode
// debugger.
NTSYSAPI
NTSTATUS
NTAPI
NtSystemDebugControl(
	IN DEBUG_CONTROL_CODE ControlCode,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwSystemDebugControl performs a subset of the operations available to a kernel mode
// debugger.
NTSYSAPI
NTSTATUS
NTAPI
ZwSystemDebugControl(
	IN DEBUG_CONTROL_CODE ControlCode,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

_NTNATIVE_END_NT

#endif
