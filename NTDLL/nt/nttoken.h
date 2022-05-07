#ifndef NTTOKEN_H
#define NTTOKEN_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtCreateToken creates a token object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateToken(
	OUT PHANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN TOKEN_TYPE Type,
	IN PLUID AuthenticationId,
	IN PLARGE_INTEGER ExpirationTime,
	IN PTOKEN_USER User,
	IN PTOKEN_GROUPS Groups,
	IN PTOKEN_PRIVILEGES Privileges,
	IN PTOKEN_OWNER Owner,
	IN PTOKEN_PRIMARY_GROUP PrimaryGroup,
	IN PTOKEN_DEFAULT_DACL DefaultDacl,
	IN PTOKEN_SOURCE Source
	);

// ZwCreateToken creates a token object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateToken(
	OUT PHANDLE TokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN TOKEN_TYPE Type,
	IN PLUID AuthenticationId,
	IN PLARGE_INTEGER ExpirationTime,
	IN PTOKEN_USER User,
	IN PTOKEN_GROUPS Groups,
	IN PTOKEN_PRIVILEGES Privileges,
	IN PTOKEN_OWNER Owner,
	IN PTOKEN_PRIMARY_GROUP PrimaryGroup,
	IN PTOKEN_DEFAULT_DACL DefaultDacl,
	IN PTOKEN_SOURCE Source
	);

// NtOpenProcessToken opens the token of a process.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenProcessToken(
	IN HANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	OUT PHANDLE TokenHandle
	);

// ZwOpenProcessToken opens the token of a process.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenProcessToken(
	IN HANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	OUT PHANDLE TokenHandle
	);

#if _WIN32_WINNT >= 0x0501

// NtOpenProcessTokenEx opens the token of a process (included in Windows XP and later).
NTSYSAPI
NTSTATUS
NTAPI
NtOpenProcessTokenEx(
	IN HANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN ULONG HandleAttributes,
	OUT PHANDLE TokenHandle
	);

// ZwOpenProcessTokenEx opens the token of a process (included in Windows XP and later).
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenProcessTokenEx(
	IN HANDLE ProcessHandle,
	IN ACCESS_MASK DesiredAccess,
	IN ULONG HandleAttributes,
	OUT PHANDLE TokenHandle
	);

#endif

// NtOpenThreadToken opens the token of a thread.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenThreadToken(
	IN HANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN BOOLEAN OpenAsSelf,
	OUT PHANDLE TokenHandle
	);

// ZwOpenThreadToken opens the token of a thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenThreadToken(
	IN HANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN BOOLEAN OpenAsSelf,
	OUT PHANDLE TokenHandle
	);

#if _WIN32_WINNT >= 0x0501

// NtOpenThreadTokenEx opens the token of a thread (included in Windows XP and later).
NTSYSAPI
NTSTATUS
NTAPI
NtOpenThreadTokenEx(
	IN HANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN BOOLEAN OpenAsSelf,
	IN ULONG HandleAttributes,
	OUT PHANDLE TokenHandle
	);

// ZwOpenThreadTokenEx opens the token of a thread (included in Windows XP and later).
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenThreadTokenEx(
	IN HANDLE ThreadHandle,
	IN ACCESS_MASK DesiredAccess,
	IN BOOLEAN OpenAsSelf,
	IN ULONG HandleAttributes,
	OUT PHANDLE TokenHandle
	);

#endif

// NtDuplicateToken makes a duplicate copy of a token.
NTSYSAPI
NTSTATUS
NTAPI
NtDuplicateToken(
	IN HANDLE ExistingTokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN BOOLEAN EffectiveOnly,
	IN TOKEN_TYPE TokenType,
	OUT PHANDLE NewTokenHandle
	);

// ZwDuplicateToken makes a duplicate copy of a token.
NTSYSAPI
NTSTATUS
NTAPI
ZwDuplicateToken(
	IN HANDLE ExistingTokenHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN BOOLEAN EffectiveOnly,
	IN TOKEN_TYPE TokenType,
	OUT PHANDLE NewTokenHandle
	);

#if _WIN32_WINNT >= 0x0500

// XxFilterToken is only implemented in Windows 2000 or later

// NtFilterToken creates a child of an existing token and applies restrictions to the child token.
NTSYSAPI
NTSTATUS
NTAPI
NtFilterToken(
	IN HANDLE ExistingTokenHandle,
	IN ULONG Flags,
	IN PTOKEN_GROUPS SidsToDisable,
	IN PTOKEN_PRIVILEGES PrivilegesToDelete,
	IN PTOKEN_GROUPS SidsToRestricted,
	OUT PHANDLE NewTokenHandle
	);

// ZwFilterToken creates a child of an existing token and applies restrictions to the child token.
NTSYSAPI
NTSTATUS
NTAPI
ZwFilterToken(
	IN HANDLE ExistingTokenHandle,
	IN ULONG Flags,
	IN PTOKEN_GROUPS SidsToDisable,
	IN PTOKEN_PRIVILEGES PrivilegesToDelete,
	IN PTOKEN_GROUPS SidsToRestricted,
	OUT PHANDLE NewTokenHandle
	);

#endif

// NtAdjustPrivilegesToken adjusts the attributes of the privileges in a token.
NTSYSAPI
NTSTATUS
NTAPI
NtAdjustPrivilegesToken(
	IN HANDLE TokenHandle,
	IN BOOLEAN DisableAllPrivileges,
	IN PTOKEN_PRIVILEGES NewState,
	IN ULONG BufferLength,
	OUT PTOKEN_PRIVILEGES PreviousState OPTIONAL,
	OUT PULONG ReturnLength OPTIONAL
	);

// ZwAdjustPrivilegesToken adjusts the attributes of the privileges in a token.
NTSYSAPI
NTSTATUS
NTAPI
ZwAdjustPrivilegesToken(
	IN HANDLE TokenHandle,
	IN BOOLEAN DisableAllPrivileges,
	IN PTOKEN_PRIVILEGES NewState,
	IN ULONG BufferLength,
	OUT PTOKEN_PRIVILEGES PreviousState OPTIONAL,
	OUT PULONG ReturnLength OPTIONAL
	);

// NtAdjustGroupsToken adjusts the attributes of the groups in a token.
NTSYSAPI
NTSTATUS
NTAPI
NtAdjustGroupsToken(
	IN HANDLE TokenHandle,
	IN BOOLEAN ResetToDefault,
	IN PTOKEN_GROUPS NewState,
	IN ULONG BufferLength,
	OUT PTOKEN_GROUPS PreviousState OPTIONAL,
	OUT PULONG ReturnLength
	);

// ZwAdjustGroupsToken adjusts the attributes of the groups in a token.
NTSYSAPI
NTSTATUS
NTAPI
ZwAdjustGroupsToken(
	IN HANDLE TokenHandle,
	IN BOOLEAN ResetToDefault,
	IN PTOKEN_GROUPS NewState,
	IN ULONG BufferLength,
	OUT PTOKEN_GROUPS PreviousState OPTIONAL,
	OUT PULONG ReturnLength
	);

// NtQueryInformationToken retrieves information about a token object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryInformationToken(
	IN HANDLE TokenHandle,
	IN TOKEN_INFORMATION_CLASS TokenInformationClass,
	OUT PVOID TokenInformation,
	IN ULONG TokenInformationLength,
	OUT PULONG ReturnLength
	);

// ZwQueryInformationToken retrieves information about a token object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryInformationToken(
	IN HANDLE TokenHandle,
	IN TOKEN_INFORMATION_CLASS TokenInformationClass,
	OUT PVOID TokenInformation,
	IN ULONG TokenInformationLength,
	OUT PULONG ReturnLength
	);

// NtSetInformationToken sets information affecting a token object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationToken(
	IN HANDLE TokenHandle,
	IN TOKEN_INFORMATION_CLASS TokenInformationClass,
	IN PVOID TokenInformation,
	IN ULONG TokenInformationLength
	);

// ZwSetInformationToken sets information affecting a token object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationToken(
	IN HANDLE TokenHandle,
	IN TOKEN_INFORMATION_CLASS TokenInformationClass,
	IN PVOID TokenInformation,
	IN ULONG TokenInformationLength
	);

#if _WIN32_WINNT >= 0x0501

// NtCompareTokens determines if two tokens refer to the same principal.
NTSYSAPI
NTSTATUS
NTAPI
NtCompareTokens(
	IN HANDLE FirstTokenHandle,		// FirstTokenHandle must grant TOKEN_QUERY access
	IN HANDLE SecondTokenHandle,	// SecondTokenHandle must grant TOKEN_QUERY access
	OUT PBOOLEAN IdenticalTokens
	);

// ZwCompareTokens determines if two tokens refer to the same principal.
NTSYSAPI
NTSTATUS
NTAPI
ZwCompareTokens(
	IN HANDLE FirstTokenHandle,		// FirstTokenHandle must grant TOKEN_QUERY access
	IN HANDLE SecondTokenHandle,	// SecondTokenHandle must grant TOKEN_QUERY access
	OUT PBOOLEAN IdenticalTokens
	);

#endif

_NTNATIVE_END_NT

#endif
