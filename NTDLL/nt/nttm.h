#ifndef NTTM_H
#define NTTM_H

#pragma once

_NTNATIVE_BEGIN_NT

#if _WIN32_WINNT >= 0x0600

//
// Nt level transaction manager API calls
//
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtCreateTransactionManager (
    OUT PHANDLE TmHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN PUNICODE_STRING LogFileName,
    IN ULONG CreateOptions OPTIONAL,
    IN ULONG CommitStrength OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwCreateTransactionManager (
    OUT PHANDLE TmHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN PUNICODE_STRING LogFileName,
    IN ULONG CreateOptions OPTIONAL,
    IN ULONG CommitStrength OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtOpenTransactionManager (
    OUT PHANDLE TmHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN PUNICODE_STRING LogFileName,
    IN ULONG OpenOptions OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwOpenTransactionManager (
    OUT PHANDLE TmHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN PUNICODE_STRING LogFileName,
    IN ULONG OpenOptions OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRenameTransactionManager (
    IN HANDLE TmHandle,
    IN LPGUID ExistingTransactionManagerGuid,
    IN LPGUID NewTransactionManagerGuid
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRenameTransactionManager (
    IN HANDLE TmHandle,
    IN LPGUID ExistingTransactionManagerGuid,
    IN LPGUID NewTransactionManagerGuid
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRollforwardTransactionManager (
    IN HANDLE TransactionManagerHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRollforwardTransactionManager (
    IN HANDLE TransactionManagerHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRecoverTransactionManager (
    IN HANDLE TransactionManagerHandle
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRecoverTransactionManager (
    IN HANDLE TransactionManagerHandle
    );
 
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtQueryInformationTransactionManager (
    IN HANDLE TransactionManagerHandle,
    IN TRANSACTION_INFORMATION_CLASS TransactionManagerInformationClass,
    OUT PVOID TransactionManagerInformation,
    IN ULONG TransactionManagerInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwQueryInformationTransactionManager (
    IN HANDLE TransactionManagerHandle,
    IN TRANSACTION_INFORMATION_CLASS TransactionManagerInformationClass,
    OUT PVOID TransactionManagerInformation,
    IN ULONG TransactionManagerInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtCreateTransaction (
    OUT PHANDLE TransactionHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG CreateOptions OPTIONAL,
    IN ULONG IsolationLevel OPTIONAL,
    IN ULONG IsolationFlags OPTIONAL,
    IN PLARGE_INTEGER Timeout OPTIONAL,
    IN PUNICODE_STRING Description OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwCreateTransaction (
    OUT PHANDLE TransactionHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG CreateOptions OPTIONAL,
    IN ULONG IsolationLevel OPTIONAL,
    IN ULONG IsolationFlags OPTIONAL,
    IN PLARGE_INTEGER Timeout OPTIONAL,
    IN PUNICODE_STRING Description OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtOpenTransaction (
    OUT PHANDLE TransactionHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwOpenTransaction (
    OUT PHANDLE TransactionHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtQueryInformationTransaction (
    IN HANDLE TransactionHandle,
    IN TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
    OUT PVOID TransactionInformation,
    IN ULONG TransactionInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwQueryInformationTransaction (
    IN HANDLE TransactionHandle,
    IN TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
    OUT PVOID TransactionInformation,
    IN ULONG TransactionInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtSetInformationTransaction (
    IN HANDLE TransactionHandle,
    IN TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
    IN PVOID TransactionInformation,
    IN ULONG TransactionInformationLength
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwSetInformationTransaction (
    IN HANDLE TransactionHandle,
    IN TRANSACTION_INFORMATION_CLASS TransactionInformationClass,
    IN PVOID TransactionInformation,
    IN ULONG TransactionInformationLength
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtCommitTransaction (
    IN HANDLE  TransactionHandle,
    IN BOOLEAN Wait
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwCommitTransaction (
    IN HANDLE  TransactionHandle,
    IN BOOLEAN Wait
    );
 
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRollbackTransaction (
    IN HANDLE  TransactionHandle,
    IN BOOLEAN Wait
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRollbackTransaction (
    IN HANDLE  TransactionHandle,
    IN BOOLEAN Wait
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRollbackSavepoint (
    IN HANDLE  TransactionHandle,
    IN SAVEPOINT_ID SavepointId
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRollbackSavepoint (
    IN HANDLE  TransactionHandle,
    IN SAVEPOINT_ID SavepointId
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtSavepointTransaction (
    IN HANDLE TransactionHandle,
    IN BOOLEAN Wait,
    OUT PSAVEPOINT_ID SavepointId
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwSavepointTransaction (
    IN HANDLE TransactionHandle,
    IN BOOLEAN Wait,
    OUT PSAVEPOINT_ID SavepointId
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtClearSavepointTransaction (
    IN HANDLE       TransactionHandle,
    IN SAVEPOINT_ID SavepointId
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwClearSavepointTransaction (
    IN HANDLE       TransactionHandle,
    IN SAVEPOINT_ID SavepointId
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtClearAllSavepointsTransaction (
    IN HANDLE       TransactionHandle
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwClearAllSavepointsTransaction (
    IN HANDLE       TransactionHandle
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtPrePrepareEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwPrePrepareEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtPrepareEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwPrepareEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtCommitEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwCommitEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRollbackEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRollbackEnlistment (
    IN HANDLE EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtPrePrepareComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwPrePrepareComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtPrepareComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwPrepareComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtPrepareCompleteReadOnly (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwPrepareCompleteReadOnly (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtCommitComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwCommitComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtReadOnlyEnlistment (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwReadOnlyEnlistment (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtRollbackComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwRollbackComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtSavepointComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwSavepointComplete (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtReferenceEnlistmentKey (
    IN	HANDLE            EnlistmentHandle,
    OUT PVOID *Key
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwReferenceEnlistmentKey (
    IN	HANDLE            EnlistmentHandle,
    OUT PVOID *Key
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtDereferenceEnlistmentKey (
    IN	HANDLE            EnlistmentHandle,
    OUT BOOLEAN           *LastReference OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwDereferenceEnlistmentKey (
    IN	HANDLE            EnlistmentHandle,
    OUT BOOLEAN           *LastReference OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtSinglePhaseReject (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwSinglePhaseReject (
    IN	HANDLE            EnlistmentHandle,
    __in_opt PLARGE_INTEGER TmVirtualClock
    );
 
 
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtCreateResourceManager (
    OUT PHANDLE ResourceManagerHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG CreateOptions OPTIONAL,
    IN PVOID CallbackRoutine OPTIONAL,
    IN PVOID RMKey OPTIONAL,
    IN HANDLE TmHandle
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwCreateResourceManager (
    OUT PHANDLE ResourceManagerHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG CreateOptions OPTIONAL,
    IN PVOID CallbackRoutine OPTIONAL,
    IN PVOID RMKey OPTIONAL,
    IN HANDLE TmHandle
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtOpenResourceManager (
    OUT PHANDLE ResourceManagerHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG CreateOptions OPTIONAL,
    IN PVOID CallbackRoutine OPTIONAL,
    IN PVOID RMKey OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwOpenResourceManager (
    OUT PHANDLE ResourceManagerHandle,
    IN ACCESS_MASK DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG CreateOptions OPTIONAL,
    IN PVOID CallbackRoutine OPTIONAL,
    IN PVOID RMKey OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRecoverResourceManager (
    IN HANDLE ResourceManagerHandle
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRecoverResourceManager (
    IN HANDLE ResourceManagerHandle
    );
 
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtGetNotificationResourceManager (
    IN	HANDLE				ResourceManagerHandle,
    OUT PTRANSACTION_NOTIFICATION	TransactionNotification,
    IN	ULONG				NotificationLength,
    IN	PLARGE_INTEGER			Timeout OPTIONAL,
    OUT PULONG				ReturnLength OPTIONAL,
    IN  ULONG                           Asynchronous,
    IN  ULONG_PTR                       AsynchronousContext OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwGetNotificationResourceManager (
    IN	HANDLE				ResourceManagerHandle,
    OUT PTRANSACTION_NOTIFICATION	TransactionNotification,
    IN	ULONG				NotificationLength,
    IN	PLARGE_INTEGER			Timeout OPTIONAL,
    OUT PULONG				ReturnLength OPTIONAL,
    IN  ULONG                           Asynchronous,
    IN  ULONG_PTR                       AsynchronousContext OPTIONAL
    );
 
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtQueryInformationResourceManager (
    IN HANDLE ResourceManagerHandle,
    IN RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
    OUT PVOID ResourceManagerInformation,
    IN ULONG ResourceManagerInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwQueryInformationResourceManager (
    IN HANDLE ResourceManagerHandle,
    IN RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
    OUT PVOID ResourceManagerInformation,
    IN ULONG ResourceManagerInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtSetInformationResourceManager (
    IN HANDLE ResourceManagerHandle,
    IN RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
    IN PVOID ResourceManagerInformation,
    IN ULONG ResourceManagerInformationLength
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwSetInformationResourceManager (
    IN HANDLE ResourceManagerHandle,
    IN RESOURCEMANAGER_INFORMATION_CLASS ResourceManagerInformationClass,
    IN PVOID ResourceManagerInformation,
    IN ULONG ResourceManagerInformationLength
    );

 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtCreateEnlistment (
    OUT PHANDLE           EnlistmentHandle,
    IN ACCESS_MASK        DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN HANDLE             ResourceManagerHandle,
    IN HANDLE             TransactionHandle,
    IN ULONG              CreateOptions OPTIONAL,
    IN NOTIFICATION_MASK  NotificationMask,
    IN PVOID              EnlistmentKey OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwCreateEnlistment (
    OUT PHANDLE           EnlistmentHandle,
    IN ACCESS_MASK        DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN HANDLE             ResourceManagerHandle,
    IN HANDLE             TransactionHandle,
    IN ULONG              CreateOptions OPTIONAL,
    IN NOTIFICATION_MASK  NotificationMask,
    IN PVOID              EnlistmentKey OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtOpenEnlistment (
    OUT PHANDLE           EnlistmentHandle,
    IN ACCESS_MASK        DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG              CreateOptions OPTIONAL,
    IN NOTIFICATION_MASK  NotificationMask,
    IN PVOID              EnlistmentKey OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwOpenEnlistment (
    OUT PHANDLE           EnlistmentHandle,
    IN ACCESS_MASK        DesiredAccess,
    IN POBJECT_ATTRIBUTES ObjectAttributes OPTIONAL,
    IN ULONG              CreateOptions OPTIONAL,
    IN NOTIFICATION_MASK  NotificationMask,
    IN PVOID              EnlistmentKey OPTIONAL
    );

 
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtQueryInformationEnlistment (
    IN HANDLE EnlistmentHandle,
    IN ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
    OUT PVOID EnlistmentInformation,
    IN ULONG EnlistmentInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwQueryInformationEnlistment (
    IN HANDLE EnlistmentHandle,
    IN ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
    OUT PVOID EnlistmentInformation,
    IN ULONG EnlistmentInformationLength,
    OUT PULONG ReturnLength OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtSetInformationEnlistment (
    IN HANDLE EnlistmentHandle,
    IN ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
    IN PVOID EnlistmentInformation,
    IN ULONG EnlistmentInformationLength
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwSetInformationEnlistment (
    IN HANDLE EnlistmentHandle,
    IN ENLISTMENT_INFORMATION_CLASS EnlistmentInformationClass,
    IN PVOID EnlistmentInformation,
    IN ULONG EnlistmentInformationLength
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtRegisterProtocolAddressInformation(
    IN HANDLE           ResourceManager,
    IN PCRM_PROTOCOL_ID ProtocolId,
    IN ULONG            ProtocolInformationSize,
    IN PVOID            ProtocolInformation,
    IN ULONG            CreateOptions OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwRegisterProtocolAddressInformation(
    IN HANDLE           ResourceManager,
    IN PCRM_PROTOCOL_ID ProtocolId,
    IN ULONG            ProtocolInformationSize,
    IN PVOID            ProtocolInformation,
    IN ULONG            CreateOptions OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtGetProtocolAddressInformation(
    IN  ULONG   AddressBufferSize,
    OUT PVOID   AddressBuffer,
    OUT PULONG  AddressBufferUsed OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwGetProtocolAddressInformation(
    IN  ULONG   AddressBufferSize,
    OUT PVOID   AddressBuffer,
    OUT PULONG  AddressBufferUsed OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtPullTransaction(
    OUT PHANDLE            TransactionHandle,
    IN  POBJECT_ATTRIBUTES ObjectAttributes,
    IN  ACCESS_MASK        DesiredAccess,
    IN  ULONG              NumberOfProtocols,
    IN  PCRM_PROTOCOL_ID   ProtocolArray,
    IN  ULONG              BufferLength,
    IN  PVOID              Buffer
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwPullTransaction(
    OUT PHANDLE            TransactionHandle,
    IN  POBJECT_ATTRIBUTES ObjectAttributes,
    IN  ACCESS_MASK        DesiredAccess,
    IN  ULONG              NumberOfProtocols,
    IN  PCRM_PROTOCOL_ID   ProtocolArray,
    IN  ULONG              BufferLength,
    IN  PVOID              Buffer
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtPushTransaction(
    IN  HANDLE            TransactionHandle,
    IN  ULONG             NumberOfProtocols,
    IN  PCRM_PROTOCOL_ID  ProtocolArray,
    IN  ULONG             DestinationInfoLength,
    IN  PVOID             DestinationInfo,
    IN  ULONG             ResponseBufferLength,
    OUT PVOID             ResponseBuffer,
    OUT PULONG            ResponseBufferUsed OPTIONAL,
    OUT PULONG            PushCookie OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwPushTransaction(
    IN  HANDLE            TransactionHandle,
    IN  ULONG             NumberOfProtocols,
    IN  PCRM_PROTOCOL_ID  ProtocolArray,
    IN  ULONG             DestinationInfoLength,
    IN  PVOID             DestinationInfo,
    IN  ULONG             ResponseBufferLength,
    OUT PVOID             ResponseBuffer,
    OUT PULONG            ResponseBufferUsed OPTIONAL,
    OUT PULONG            PushCookie OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtGetPushTransactionBuffer(
    IN  HANDLE            TransactionHandle,
    IN  ULONG             PushCookie,
    IN  ULONG             ResponseBufferLength,
    OUT PVOID             ResponseBuffer,
    OUT PULONG            ResponseBufferUsed OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwGetPushTransactionBuffer(
    IN  HANDLE            TransactionHandle,
    IN  ULONG             PushCookie,
    IN  ULONG             ResponseBufferLength,
    OUT PVOID             ResponseBuffer,
    OUT PULONG            ResponseBufferUsed OPTIONAL
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtPropagationComplete(
    IN  HANDLE            EnlistmentHandle,
    IN  ULONG             RequestCookie,
    IN  ULONG             BufferLength,
    IN  PVOID             Buffer
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwPropagationComplete(
    IN  HANDLE            EnlistmentHandle,
    IN  ULONG             RequestCookie,
    IN  ULONG             BufferLength,
    IN  PVOID             Buffer
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtPropagationFailed(
    IN  HANDLE            ResourceManagerHandle,
    IN  ULONG             RequestCookie,
    IN  NTSTATUS          PropStatus
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwPropagationFailed(
    IN  HANDLE            ResourceManagerHandle,
    IN  ULONG             RequestCookie,
    IN  NTSTATUS          PropStatus
    );
 
NTSYSCALLAPI
NTSTATUS
NTAPI
NtMarshallTransaction(
    IN  HANDLE            TransactionHandle,
    IN  ULONG             NumberOfProtocols,
    IN  PCRM_PROTOCOL_ID  ProtocolArray,
    IN  ULONG             BufferLength,
    IN  PVOID             Buffer,
    OUT PULONG            BufferUsed OPTIONAL
    );

NTSYSCALLAPI
NTSTATUS
NTAPI
ZwMarshallTransaction(
    IN  HANDLE            TransactionHandle,
    IN  ULONG             NumberOfProtocols,
    IN  PCRM_PROTOCOL_ID  ProtocolArray,
    IN  ULONG             BufferLength,
    IN  PVOID             Buffer,
    OUT PULONG            BufferUsed OPTIONAL
    );
 
 
 
 
 
//
// TODO:  temporary entry point that must go away before shipping
//
 
NTSYSCALLAPI
NTSTATUS
NTAPI 
NtStartTm(
    void
    );

NTSYSCALLAPI
NTSTATUS
NTAPI 
ZwStartTm(
    void
    );

#endif

_NTNATIVE_END_NT

#endif
