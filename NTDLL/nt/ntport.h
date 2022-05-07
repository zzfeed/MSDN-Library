#ifndef NTPORT_H
#define NTPORT_H

#pragma once

#include <nt\nttypes.h>

_NTNATIVE_BEGIN_NT

// NtCreatePort creates a port object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreatePort(
	OUT PHANDLE PortHandle,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG MaxConnectionInfoLength, // Max 0x104
	IN ULONG MaxMessageLength, // Max 0x148
	IN ULONG MaxPoolUsage	// 0
	);

// ZwCreatePort creates a port object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreatePort(
	OUT PHANDLE PortHandle,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG MaxConnectionInfoLength, // Max 0x104
	IN ULONG MaxMessageLength, // Max 0x148
	IN ULONG MaxPoolUsage	// 0
	);

// NtCreateWaitablePort creates a waitable port object (Windows 2000 or later).
NTSYSAPI
NTSTATUS
NTAPI
NtCreateWaitablePort(
	OUT PHANDLE PortHandle,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG MaxConnectionInfoLength, // Max 0x104
	IN ULONG MaxMessageLength, // Max 0x148
	IN ULONG MaxPoolUsage	// 0
	);

// ZwCreateWaitablePort creates a waitable port object (Windows 2000 or later).
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateWaitablePort(
	OUT PHANDLE PortHandle,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG MaxConnectionInfoLength, // Max 0x104
	IN ULONG MaxMessageLength, // Max 0x148
	IN ULONG MaxPoolUsage	// 0
	);

// NtConnectPort creates a port connected to a named port.
NTSYSAPI
NTSTATUS
NTAPI
NtConnectPort(
	OUT PHANDLE PortHandle,
	IN PUNICODE_STRING PortName,
	IN PSECURITY_QUALITY_OF_SERVICE SecurityQos,
	IN OUT PPORT_VIEW ClientView OPTIONAL,
	OUT PREMOTE_PORT_VIEW ServerView OPTIONAL,
	OUT PULONG MaxMessageLength OPTIONAL,
	IN OUT PVOID ConnectInformation OPTIONAL,
	IN OUT PULONG ConnectInformationLength OPTIONAL
	);

// ZwConnectPort creates a port connected to a named port.
NTSYSAPI
NTSTATUS
NTAPI
ZwConnectPort(
	OUT PHANDLE PortHandle,
	IN PUNICODE_STRING PortName,
	IN PSECURITY_QUALITY_OF_SERVICE SecurityQos,
	IN OUT PPORT_VIEW ClientView OPTIONAL,
	OUT PREMOTE_PORT_VIEW ServerView OPTIONAL,
	OUT PULONG MaxMessageLength OPTIONAL,
	IN OUT PVOID ConnectInformation OPTIONAL,
	IN OUT PULONG ConnectInformationLength OPTIONAL
	);

// NtSecureConnectPort creates a port connected to a named port (Windows 2000 or later).
NTSYSAPI
NTSTATUS
NTAPI
NtSecureConnectPort(
	OUT PHANDLE PortHandle,
	IN PUNICODE_STRING PortName,
	IN PSECURITY_QUALITY_OF_SERVICE SecurityQos,
	IN OUT PPORT_VIEW ClientView OPTIONAL,
	IN PSID ServerSid OPTIONAL,
	OUT PREMOTE_PORT_VIEW ServerView OPTIONAL,
	OUT PULONG MaxMessageLength OPTIONAL,
	IN OUT PVOID ConnectInformation OPTIONAL,
	IN OUT PULONG ConnectInformationLength OPTIONAL
	);

// NtSecureConnectPort creates a port connected to a named port (Windows 2000 or later).
NTSYSAPI
NTSTATUS
NTAPI
ZwSecureConnectPort(
	OUT PHANDLE PortHandle,
	IN PUNICODE_STRING PortName,
	IN PSECURITY_QUALITY_OF_SERVICE SecurityQos,
	IN OUT PPORT_VIEW ClientView OPTIONAL,
	IN PSID ServerSid OPTIONAL,
	OUT PREMOTE_PORT_VIEW ServerView OPTIONAL,
	OUT PULONG MaxMessageLength OPTIONAL,
	IN OUT PVOID ConnectInformation OPTIONAL,
	IN OUT PULONG ConnectInformationLength OPTIONAL
	);

// NtListenPort listens on a port for a connection request message.
NTSYSAPI
NTSTATUS
NTAPI
NtListenPort(
	IN HANDLE PortHandle,
	OUT PPORT_MESSAGE Message
	);

// ZwListenPort listens on a port for a connection request message.
NTSYSAPI
NTSTATUS
NTAPI
ZwListenPort(
	IN HANDLE PortHandle,
	OUT PPORT_MESSAGE Message
	);

// NtAcceptConnectPort accepts or rejects a connection request.
NTSYSAPI
NTSTATUS
NTAPI
NtAcceptConnectPort(
	OUT PHANDLE PortHandle,
	IN PVOID PortIdentifier,
	IN PPORT_MESSAGE Message,
	IN BOOLEAN Accept,
	IN OUT PPORT_VIEW ServerView OPTIONAL,
	OUT PREMOTE_PORT_VIEW ClientView OPTIONAL
	);

// ZwAcceptConnectPort accepts or rejects a connection request.
NTSYSAPI
NTSTATUS
NTAPI
ZwAcceptConnectPort(
	OUT PHANDLE PortHandle,
	IN PVOID PortIdentifier,
	IN PPORT_MESSAGE Message,
	IN BOOLEAN Accept,
	IN OUT PPORT_VIEW ServerView OPTIONAL,
	OUT PREMOTE_PORT_VIEW ClientView OPTIONAL
	);

// NtCompleteConnectPort completes the port connection process.
NTSYSAPI
NTSTATUS
NTAPI
NtCompleteConnectPort(
	IN HANDLE PortHandle
	);

// ZwCompleteConnectPort completes the port connection process.
NTSYSAPI
NTSTATUS
NTAPI
ZwCompleteConnectPort(
	IN HANDLE PortHandle
	);

// NtRequestPort sends a request message to a port.
NTSYSAPI
NTSTATUS
NTAPI
NtRequestPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE RequestMessage
	);

// ZwRequestPort sends a request message to a port.
NTSYSAPI
NTSTATUS
NTAPI
ZwRequestPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE RequestMessage
	);

// NtRequestWaitReplyPort sends a request message to a port and waits for a reply message.
NTSYSAPI
NTSTATUS
NTAPI
NtRequestWaitReplyPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE RequestMessage,
	OUT PPORT_MESSAGE ReplyMessage
	);

// ZwRequestWaitReplyPort sends a request message to a port and waits for a reply message.
NTSYSAPI
NTSTATUS
NTAPI
ZwRequestWaitReplyPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE RequestMessage,
	OUT PPORT_MESSAGE ReplyMessage
	);

// NtReplyPort sends a reply message to a port.
NTSYSAPI
NTSTATUS
NTAPI
NtReplyPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE ReplyMessage
	);

// ZwReplyPort sends a reply message to a port.
NTSYSAPI
NTSTATUS
NTAPI
ZwReplyPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE ReplyMessage
	);

// NtReplyWaitReplyPort sends a reply message to a port and waits for a reply message.
NTSYSAPI
NTSTATUS
NTAPI
NtReplyWaitReplyPort(
	IN HANDLE PortHandle,
	IN OUT PPORT_MESSAGE ReplyMessage
	);

// ZwReplyWaitReplyPort sends a reply message to a port and waits for a reply message.
NTSYSAPI
NTSTATUS
NTAPI
ZwReplyWaitReplyPort(
	IN HANDLE PortHandle,
	IN OUT PPORT_MESSAGE ReplyMessage
	);

// NtReplyWaitReceivePort optionally sends a reply message to a port and waits for a message.
NTSYSAPI
NTSTATUS
NTAPI
NtReplyWaitReceivePort(
	IN HANDLE PortHandle,
	OUT PULONG PortIdentifier OPTIONAL,
	IN PPORT_MESSAGE ReplyMessage OPTIONAL,
	OUT PPORT_MESSAGE Message
	);

// ZwReplyWaitReceivePort optionally sends a reply message to a port and waits for a message.
NTSYSAPI
NTSTATUS
NTAPI
ZwReplyWaitReceivePort(
	IN HANDLE PortHandle,
	OUT PVOID* PortIdentifier OPTIONAL,
	IN PPORT_MESSAGE ReplyMessage OPTIONAL,
	OUT PPORT_MESSAGE Message
	);

// NtReplyWaitReceivePortEx optionally sends a reply message to a port and waits for a message.
NTSYSAPI
NTSTATUS
NTAPI
NtReplyWaitReceivePortEx(
	IN HANDLE PortHandle,
	OUT PVOID* PortIdentifier OPTIONAL,
	IN PPORT_MESSAGE ReplyMessage OPTIONAL,
	OUT PPORT_MESSAGE Message,
	IN PLARGE_INTEGER Timeout
	);

// ZwReplyWaitReceivePortEx optionally sends a reply message to a port and waits for a message.
NTSYSAPI
NTSTATUS
NTAPI
ZwReplyWaitReceivePortEx(
	IN HANDLE PortHandle,
	OUT PVOID* PortIdentifier OPTIONAL,
	IN PPORT_MESSAGE ReplyMessage OPTIONAL,
	OUT PPORT_MESSAGE Message,
	IN PLARGE_INTEGER Timeout
	);

// NtReadRequestData reads the data from the process virtual address space referenced by a message.
NTSYSAPI
NTSTATUS
NTAPI
NtReadRequestData(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE Message,
	IN ULONG Index,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwReadRequestData reads the data from the process virtual address space referenced by a message.
NTSYSAPI
NTSTATUS
NTAPI
ZwReadRequestData(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE Message,
	IN ULONG Index,
	OUT PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtWriteRequestData writes data to the process virtual address space referenced by a message.
NTSYSAPI
NTSTATUS
NTAPI
NtWriteRequestData(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE Message,
	IN ULONG Index,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwWriteRequestData writes data to the process virtual address space referenced by a message.
NTSYSAPI
NTSTATUS
NTAPI
ZwWriteRequestData(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE Message,
	IN ULONG Index,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtQueryInformationPort retrieves information about a port object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationPort(
	IN HANDLE PortHandle,
	IN PORT_INFORMATION_CLASS PortInformationClass,
	OUT PVOID PortInformation,
	IN ULONG PortInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtQueryInformationPort retrieves information about a port object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationPort(
	IN HANDLE PortHandle,
	IN PORT_INFORMATION_CLASS PortInformationClass,
	OUT PVOID PortInformation,
	IN ULONG PortInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwQueryInformationPort retrieves information about a port object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationPort(
	IN HANDLE PortHandle,
	IN PORT_INFORMATION_CLASS PortInformationClass,
	OUT PVOID PortInformation,
	IN ULONG PortInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtImpersonateClientOfPort impersonates the security context of the client of a port.
NTSYSAPI
NTSTATUS
NTAPI
NtImpersonateClientOfPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE Message
	);

// ZwImpersonateClientOfPort impersonates the security context of the client of a port.
NTSYSAPI
NTSTATUS
NTAPI
ZwImpersonateClientOfPort(
	IN HANDLE PortHandle,
	IN PPORT_MESSAGE Message
	);

// InitializePortMessage initializes a new port message.
_NTNATIVE_INLINE
VOID
InitializePortMessage(
	OUT PPORT_MESSAGE Message,
	IN USHORT DataSize OPTIONAL,
	IN USHORT MessageSize,
	IN USHORT VirtualRangesOffset OPTIONAL
	)
{
	Message->DataSize = DataSize;
	Message->MessageSize = MessageSize;
	Message->MessageType = LPC_NEW_MESSAGE;
	Message->VirtualRangesOffset = VirtualRangesOffset;
}

// InitializeReplyPortMessage initializes a reply port message.
_NTNATIVE_INLINE
VOID
InitializeReplyPortMessage(
	OUT PPORT_MESSAGE Message,
	IN USHORT DataSize OPTIONAL,
	IN USHORT MessageSize,
	IN USHORT VirtualRangesOffset OPTIONAL,
	IN CONST PPORT_MESSAGE OriginalMessage
	)
{
	Message->DataSize = DataSize;
	Message->MessageSize = MessageSize;
	Message->MessageType = OriginalMessage->MessageType;
	Message->VirtualRangesOffset = VirtualRangesOffset;
	Message->MessageId = OriginalMessage->MessageId;
}

_NTNATIVE_END_NT

#endif
