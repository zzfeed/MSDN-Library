#ifndef NTSECURITY_H
#define NTSECURITY_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtPrivilegeCheck checks whether a set of privileges are enabled in a token.
NTSYSAPI
NTSTATUS
NTAPI
NtPrivilegeCheck(
	IN HANDLE TokenHandle,
	IN PPRIVILEGE_SET RequiredPrivileges,
	OUT PBOOLEAN Result
	);

// ZwPrivilegeCheck checks whether a set of privileges are enabled in a token.
NTSYSAPI
NTSTATUS
NTAPI
ZwPrivilegeCheck(
	IN HANDLE TokenHandle,
	IN PPRIVILEGE_SET RequiredPrivileges,
	OUT PBOOLEAN Result
	);

// NtPrivilegeObjectAuditAlarm generates an audit alarm describing the use of privileges
// in conjunction with a handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
NtPrivilegeObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN PPRIVILEGE_SET Privileges,
	IN BOOLEAN AccessGranted
	);

// ZwPrivilegeObjectAuditAlarm generates an audit alarm describing the use of privileges
// in conjunction with a handle to an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwPrivilegeObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN PPRIVILEGE_SET Privileges,
	IN BOOLEAN AccessGranted
	);

// NtPrivilegedServiceAuditAlarm generates an audit alarm describing the use of
// privileges.
NTSYSAPI
NTSTATUS
NTAPI
NtPrivilegedServiceAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PUNICODE_STRING ServiceName,
	IN HANDLE TokenHandle,
	IN PPRIVILEGE_SET Privileges,
	IN BOOLEAN AccessGranted
	);

// ZwPrivilegedServiceAuditAlarm generates an audit alarm describing the use of
// privileges.
NTSYSAPI
NTSTATUS
NTAPI
ZwPrivilegedServiceAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PUNICODE_STRING ServiceName,
	IN HANDLE TokenHandle,
	IN PPRIVILEGE_SET Privileges,
	IN BOOLEAN AccessGranted
	);

// NtAccessCheck checks whether a security descriptor grants the requested access to an
// agent represented by a token object.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheck(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN PGENERIC_MAPPING GenericMapping,
	OUT PPRIVILEGE_SET PrivilegeSet,
	IN PULONG PrivilegeSetLength,
	OUT PACCESS_MASK GrantedAccess,
	OUT PBOOLEAN AccessStatus
	);

// ZwAccessCheck checks whether a security descriptor grants the requested access to an
// agent represented by a token object.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheck(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN PGENERIC_MAPPING GenericMapping,
	IN PPRIVILEGE_SET PrivilegeSet,
	IN PULONG PrivilegeSetLength,
	OUT PACCESS_MASK GrantedAccess,
	OUT PBOOLEAN AccessStatus
	);

// NtAccessCheckAndAuditAlarm checks whether a security descriptor grants the
// requested access to an agent represented by the impersonation token of the current
// thread. If the security descriptor has a SACL with ACEs that apply to the agent, any
// necessary audit messages are generated.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheckAndAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN ACCESS_MASK DesiredAccess,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccess,
	OUT PBOOLEAN AccessStatus,
	OUT PBOOLEAN GenerateOnClose
	);

// ZwAccessCheckAndAuditAlarm checks whether a security descriptor grants the
// requested access to an agent represented by the impersonation token of the current
// thread. If the security descriptor has a SACL with ACEs that apply to the agent, any
// necessary audit messages are generated.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheckAndAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN ACCESS_MASK DesiredAccess,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccess,
	OUT PBOOLEAN AccessStatus,
	OUT PBOOLEAN GenerateOnClose
	);

// NtAccessCheckByType checks whether a security descriptor grants the requested access
// to an agent represented by a token object.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheckByType(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN HANDLE TokenHandle,
	IN ULONG DesiredAccess,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN PPRIVILEGE_SET PrivilegeSet,
	IN PULONG PrivilegeSetLength,
	OUT PACCESS_MASK GrantedAccess,
	OUT PULONG AccessStatus
	);

// ZwAccessCheckByType checks whether a security descriptor grants the requested access
// to an agent represented by a token object.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheckByType(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN HANDLE TokenHandle,
	IN ULONG DesiredAccess,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN PPRIVILEGE_SET PrivilegeSet,
	IN PULONG PrivilegeSetLength,
	OUT PACCESS_MASK GrantedAccess,
	OUT PULONG AccessStatus
	);

// NtAccessCheckByTypeAndAuditAlarm checks whether a security descriptor grants the
// requested access to an agent represented by the impersonation token of the current
// thread. If the security descriptor has a SACL with ACEs that apply to the agent, any
// necessary audit messages are generated.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheckByTypeAndAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN ACCESS_MASK DesiredAccess,
	IN AUDIT_EVENT_TYPE AuditType,
	IN ULONG Flags,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccess,
	OUT PULONG AccessStatus,
	OUT PBOOLEAN GenerateOnClose
	);

// ZwAccessCheckByTypeAndAuditAlarm checks whether a security descriptor grants the
// requested access to an agent represented by the impersonation token of the current
// thread. If the security descriptor has a SACL with ACEs that apply to the agent, any
// necessary audit messages are generated.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheckByTypeAndAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN ACCESS_MASK DesiredAccess,
	IN AUDIT_EVENT_TYPE AuditType,
	IN ULONG Flags,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccess,
	OUT PULONG AccessStatus,
	OUT PBOOLEAN GenerateOnClose
	);

// NtAccessCheckByTypeResultList checks whether a security descriptor grants the
// requested access to an agent represented by a token object.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheckByTypeResultList(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN PPRIVILEGE_SET PrivilegeSet,
	IN PULONG PrivilegeSetLength,
	OUT PACCESS_MASK GrantedAccessList,
	OUT PULONG AccessStatusList
	);

// ZwAccessCheckByTypeResultList checks whether a security descriptor grants the
// requested access to an agent represented by a token object.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheckByTypeResultList(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN PPRIVILEGE_SET PrivilegeSet,
	IN PULONG PrivilegeSetLength,
	OUT PACCESS_MASK GrantedAccessList,
	OUT PULONG AccessStatusList
	);

// NtAccessCheckByTypeResultListAndAuditAlarm checks whether a security descriptor
// grants the requested access to an agent represented by the impersonation token of the
// current thread. If the security descriptor has a SACL with ACEs that apply to the
// agent, any necessary audit messages are generated.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheckByTypeResultListAndAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN ACCESS_MASK DesiredAccess,
	IN AUDIT_EVENT_TYPE AuditType,
	IN ULONG Flags,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccessList,
	OUT PULONG AccessStatusList,
	OUT PULONG GenerateOnClose
	);

// ZwAccessCheckByTypeResultListAndAuditAlarm checks whether a security descriptor
// grants the requested access to an agent represented by the impersonation token of the
// current thread. If the security descriptor has a SACL with ACEs that apply to the
// agent, any necessary audit messages are generated.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheckByTypeResultListAndAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN ACCESS_MASK DesiredAccess,
	IN AUDIT_EVENT_TYPE AuditType,
	IN ULONG Flags,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccessList,
	OUT PULONG AccessStatusList,
	OUT PULONG GenerateOnClose
	);

// NtAccessCheckByTypeResultListAndAuditAlarmByHandle checks whether a security
// descriptor grants the requested access to an agent represented by a token. If the security
// descriptor has a SACL with ACEs that apply to the agent, any necessary audit messages
// are generated.
NTSYSAPI
NTSTATUS
NTAPI
NtAccessCheckByTypeResultListAndAuditAlarmByHandle(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN HANDLE TokenHandle,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN ACCESS_MASK DesiredAccess,
	IN AUDIT_EVENT_TYPE AuditType,
	IN ULONG Flags,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccessList,
	OUT PULONG AccessStatusList,
	OUT PULONG GenerateOnClose
	);

// ZwAccessCheckByTypeResultListAndAuditAlarmByHandle checks whether a security
// descriptor grants the requested access to an agent represented by a token. If the security
// descriptor has a SACL with ACEs that apply to the agent, any necessary audit messages
// are generated.
NTSYSAPI
NTSTATUS
NTAPI
ZwAccessCheckByTypeResultListAndAuditAlarmByHandle(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN HANDLE TokenHandle,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID PrincipalSelfSid,
	IN ACCESS_MASK DesiredAccess,
	IN AUDIT_EVENT_TYPE AuditType,
	IN ULONG Flags,
	IN POBJECT_TYPE_LIST ObjectTypeList,
	IN ULONG ObjectTypeListLength,
	IN PGENERIC_MAPPING GenericMapping,
	IN BOOLEAN ObjectCreation,
	OUT PACCESS_MASK GrantedAccessList,
	OUT PULONG AccessStatusList,
	OUT PULONG GenerateOnClose
	);

// NtOpenObjectAuditAlarm generates an audit alarm describing the opening of a handle
// to an object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID *HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN ACCESS_MASK GrantedAccess,
	IN PPRIVILEGE_SET Privileges OPTIONAL,
	IN BOOLEAN ObjectCreation,
	IN BOOLEAN AccessGranted,
	OUT PBOOLEAN GenerateOnClose
	);

// ZwOpenObjectAuditAlarm generates an audit alarm describing the opening of a handle
// to an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID *HandleId,
	IN PUNICODE_STRING ObjectTypeName,
	IN PUNICODE_STRING ObjectName,
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN HANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN ACCESS_MASK GrantedAccess,
	IN PPRIVILEGE_SET Privileges OPTIONAL,
	IN BOOLEAN ObjectCreation,
	IN BOOLEAN AccessGranted,
	OUT PBOOLEAN GenerateOnClose
	);

// NtCloseObjectAuditAlarm generates an audit alarm describing the closing of a handle
// to an object.
NTSYSAPI
NTSTATUS
NTAPI
NtCloseObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN BOOLEAN GenerateOnClose
	);

// ZwCloseObjectAuditAlarm generates an audit alarm describing the closing of a handle
// to an object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCloseObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN BOOLEAN GenerateOnClose
	);

// NtDeleteObjectAuditAlarm generates an audit alarm describing the deletion of an
// object.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN BOOLEAN GenerateOnClose
	);

// ZwDeleteObjectAuditAlarm generates an audit alarm describing the deletion of an
// object.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteObjectAuditAlarm(
	IN PUNICODE_STRING SubsystemName,
	IN PVOID HandleId,
	IN BOOLEAN GenerateOnClose
	);

_NTNATIVE_END_NT

#endif
