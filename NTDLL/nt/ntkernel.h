#ifndef NTKERNEL_H
#define NTKERNEL_H

#pragma once

_NTNATIVE_BEGIN_NT

// KiUserApcDispatcher dispatches APCs for the current thread.
NTSYSAPI
VOID
NTAPI
KiUserApcDispatcher(
	IN PVOID Unused1,
	IN PVOID Unused2,
	IN PVOID Unused3,
	IN PCONTEXT Context,
	IN PVOID ContextBody
	);

// KiUserExceptionDispatcher dispatches a user-mode exception.
NTSYSAPI
VOID
NTAPI
KiUserExceptionDispatcher(
	EXCEPTION_RECORD ExceptionRecord,
	PCONTEXT Context
	);

// KiDispatchException dispatches an exception.
NTSYSAPI
VOID
NTAPI
KiDispatchException(
	PEXCEPTION_RECORD Er,
	ULONG Reserved,
	PKTRAP_FRAME Tf,
	MODE PreviousMode,
	BOOLEAN SearchFrames
	);

//
// The following are kernel mode routines.
//
#ifdef NT_KERNEL_MODE
// ObCreateObject creates a new object.
NTKERNELAPI
NTSTATUS
NTAPI
ObCreateObject(
	IN KPROCESSOR_MODE ObjectAttributesAccessMode OPTIONAL,
	IN POBJECT_TYPE ObjectType,
	IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
	IN KPROCESSOR_MODE AccessMode,
	IN PVOID Reserved,
	IN ULONG ObjectSizeToAllocate,
	IN ULONG PagedPoolCharge OPTIONAL,
	IN ULONG NonPagedPoolCharge OPTIONAL,
	OUT PVOID *Object
	);

// ObInsertObject creates a handle to an existing object.
NTKERNELAPI
NTSTATUS
NTAPI
ObInsertObject(
	IN PVOID Object,
	IN PACCESS_STATE PassedAccessState OPTIONAL,
	IN ACCESS_MASK DesiredAccess,
	IN ULONG AdditionalReferences,
	OUT PVOID *ReferencedObject OPTIONAL,
	OUT PHANDLE Handle
	);

// ObGetObjectPointerCount retrieves the number of pointers to an existing object.
NTKERNELAPI
ULONG
NTAPI
ObGetObjectPointerCount(
	IN PVOID Object
	);

// ObMakeTemporaryObject sets the temporary attribute in an existing object.
NTKERNELAPI
VOID
NTAPI
ObMakeTemporaryObject(
	IN PVOID Object
	);

// ObQueryNameString retrieves name information for an object.
NTKERNELAPI
VOID
NTAPI
ObQueryNameString(
	IN PVOID Object,
	OUT POBJECT_NAME_INFORMATION ObjectInformation,
	IN ULONG InformationLength,
	OUT PULONG ReturnLength
	);

//
// Kernel LPC routines
//

extern POBJECT_TYPE* LpcPortObjectType;

// LpcRequestPort sends a port message with no restrictions on type.
NTKERNELAPI
NTSTATUS
NTAPI
LpcRequestPort(
	IN PVOID Port,
	IN PPORT_MESSAGE RequestMessage
	);

// LpcRequestWaitReplyPort sends and receives port messages.
NTKERNELAPI
NTSTATUS
NTAPI
LpcRequestWaitReplyPort(
	IN PVOID Port,
	IN PPORT_MESSAGE RequestMessage,
	OUT PPORT_MESSAGE ReplyMessage
	);



#endif

_NTNATIVE_END_NT

#endif
