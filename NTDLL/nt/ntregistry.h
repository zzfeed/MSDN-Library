#ifndef NTREGISTRY_H
#define NTREGISTRY_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtCreateKey creates or opens a registry key object.
NTSYSAPI
NTSTATUS
NTAPI
NtCreateKey(
	OUT PHANDLE KeyHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG TitleIndex,
	IN PUNICODE_STRING Class OPTIONAL,
	IN ULONG CreateOptions,
	OUT PULONG Disposition OPTIONAL
	);

// ZwCreateKey creates or opens a registry key object.
NTSYSAPI
NTSTATUS
NTAPI
ZwCreateKey(
	OUT PHANDLE KeyHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes,
	IN ULONG TitleIndex,
	IN PUNICODE_STRING Class OPTIONAL,
	IN ULONG CreateOptions,
	OUT PULONG Disposition OPTIONAL
	);

// NtOpenKey opens a registry key object.
NTSYSAPI
NTSTATUS
NTAPI
NtOpenKey(
	OUT PHANDLE KeyHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);


// ZwOpenKey opens a registry key object.
NTSYSAPI
NTSTATUS
NTAPI
ZwOpenKey(
	OUT PHANDLE KeyHandle,
	IN ACCESS_MASK DesiredAccess,
	IN POBJECT_ATTRIBUTES ObjectAttributes
	);

// NtDeleteKey deletes a key in the registry.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteKey(
	IN HANDLE KeyHandle		// KeyHandle must grant DELETE access.
	);

// ZwDeleteKey deletes a key in the registry.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteKey(
	IN HANDLE KeyHandle		// KeyHandle must grant DELETE access.
	);

// NtFlushKey flushes changes to a key to disk.
NTSYSAPI
NTSTATUS
NTAPI
NtFlushKey(
	IN HANDLE KeyHandle		// KeyHandle need not grant any specific access rights.
	);

// ZwFlushKey flushes changes to a key to disk.
NTSYSAPI
NTSTATUS
NTAPI
ZwFlushKey(
	IN HANDLE KeyHandle		// KeyHandle need not grant any specific access rights.
	);

// NtSaveKey saves a copy of a key and its subkeys in a file.  SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtSaveKey(
	IN HANDLE KeyHandle,	// KeyHandle need not grant any specific access rights.
	IN HANDLE FileHandle	// FileHandle must grant FILE_GENERIC_WRITE access.
	);

// ZwSaveKey saves a copy of a key and its subkeys in a file.  SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwSaveKey(
	IN HANDLE KeyHandle,	// KeyHandle need not grant any specific access rights.
	IN HANDLE FileHandle	// FileHandle must grant FILE_GENERIC_WRITE access.
	);

// NtSaveMergedKeys merges two keys and their subkeys and saves the result in a file.  SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtSaveMergedKeys(
	IN HANDLE KeyHandle1,	// KeyHandle1 need not grant any specific access rights. (High)
	IN HANDLE KeyHandle2,	// KeyHandle2 need not grant any specific access rights. (Low)
	IN HANDLE FileHandle	// FileHandle must grant FILE_GENERIC_WRITE access.
	);

// ZwSaveMergedKeys merges two keys and their subkeys and saves the result in a file.  SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwSaveMergedKeys(
	IN HANDLE KeyHandle1,	// KeyHandle1 need not grant any specific access rights. (High)
	IN HANDLE KeyHandle2,	// KeyHandle2 need not grant any specific access rights. (Low)
	IN HANDLE FileHandle	// FileHandle must grant FILE_GENERIC_WRITE access.
	);

// NtRestoreKey restores a key saved in a file to the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtRestoreKey(
	IN HANDLE KeyHandle,	// KeyHandle need not grant any specific access rights.
	IN HANDLE FileHandle,	// FileHandle must grant FILE_GENERIC_READ access.
	IN ULONG Flags			// REG_WHOLE_HIVE_VOLATILE, REG_REFRESH_HIVE, REG_FORCE_RESTORE
	);

// ZwRestoreKey restores a key saved in a file to the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwRestoreKey(
	IN HANDLE KeyHandle,	// KeyHandle need not grant any specific access rights.
	IN HANDLE FileHandle,	// FileHandle must grant FILE_GENERIC_READ access.
	IN ULONG Flags			// REG_WHOLE_HIVE_VOLATILE, REG_REFRESH_HIVE, REG_FORCE_RESTORE
	);


// NtLoadKey mounts a key hive in the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtLoadKey(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN POBJECT_ATTRIBUTES FileObjectAttributes
	);

// ZwLoadKey mounts a key hive in the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwLoadKey(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN POBJECT_ATTRIBUTES FileObjectAttributes
	);

// NtLoadKey2 mounts a key hive in the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtLoadKey2(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN POBJECT_ATTRIBUTES FileObjectAttributes,
	IN ULONG Flags									// REG_NO_LAZY_FLUSH
	);

// ZwLoadKey2 mounts a key hive in the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwLoadKey2(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN POBJECT_ATTRIBUTES FileObjectAttributes,
	IN ULONG Flags									// REG_NO_LAZY_FLUSH
	);

// NtUnloadKey dismounts a key hive in the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtUnloadKey(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes
	);

// ZwUnloadKey dismounts a key hive in the registry.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnloadKey(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes
	);

#if _WIN32_WINNT >= 0x0500

// NtQueryOpenSubKeys reports on the number of open keys in a hive.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryOpenSubKeys(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,		// KeyObjectAttributes must refer to a hive root.
	OUT PULONG NumberOfKeys
	);

// ZwQueryOpenSubKeys reports on the number of open keys in a hive.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryOpenSubKeys(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,		// KeyObjectAttributes must refer to a hive root.
	OUT PULONG NumberOfKeys
	);

#endif

// NtReplaceKey replaces a mounted key hive with another.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtReplaceKey(
	IN POBJECT_ATTRIBUTES NewFileObjectAttributes,
	IN HANDLE KeyHandle,							// KeyHandle need not grant any specific access rights.
	IN POBJECT_ATTRIBUTES OldFileObjectAttributes
	);

// ZwReplaceKey replaces a mounted key hive with another.  SeRestorePrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwReplaceKey(
	IN POBJECT_ATTRIBUTES NewFileObjectAttributes,
	IN HANDLE KeyHandle,							// KeyHandle need not grant any specific access rights.
	IN POBJECT_ATTRIBUTES OldFileObjectAttributes
	);

// NtSetInformationKey sets information affecting a key object.
NTSYSAPI
NTSTATUS
NTAPI
NtSetInformationKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_SET_VALUE access.
	IN KEY_SET_INFORMATION_CLASS KeyInformationClass,
	IN PVOID KeyInformation,
	IN ULONG KeyInformationLength
	);

// ZwSetInformationKey sets information affecting a key object.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetInformationKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_SET_VALUE access.
	IN KEY_SET_INFORMATION_CLASS KeyInformationClass,
	IN PVOID KeyInformation,
	IN ULONG KeyInformationLength
	);

// NtQueryKey retrieves information about a key object.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_QUERY_VALUE access, except for KeyNameInformation, where no specific access rights are required.
	IN KEY_INFORMATION_CLASS KeyInformationClass,
	OUT PVOID KeyInformation,
	IN ULONG KeyInformationLength,
	OUT PULONG ResultLength
	);

// ZwQueryKey retrieves information about a key object.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_QUERY_VALUE access, except for KeyNameInformation, where no specific access rights are required.
	IN KEY_INFORMATION_CLASS KeyInformationClass,
	OUT PVOID KeyInformation,
	IN ULONG KeyInformationLength,
	OUT PULONG ResultLength
	);

// NtEnumerateKey enumerates the subkeys of a key object.
NTSYSAPI
NTSTATUS
NTAPI
NtEnumerateKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_ENUMERATE_SUB_KEYS access.
	IN ULONG Index,
	IN KEY_INFORMATION_CLASS KeyInformationClass,
	OUT PVOID KeyInformation,
	IN ULONG KeyInformationLength,
	OUT PULONG ResultLength
	);

// ZwEnumerateKey enumerates the subkeys of a key object.
NTSYSAPI
NTSTATUS
NTAPI
ZwEnumerateKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_ENUMERATE_SUB_KEYS access.
	IN ULONG Index,
	IN KEY_INFORMATION_CLASS KeyInformationClass,
	OUT PVOID KeyInformation,
	IN ULONG KeyInformationLength,
	OUT PULONG ResultLength
	);

// NtNotifyChangeKey monitors a key for changes.
NTSYSAPI
NTSTATUS
NTAPI
NtNotifyChangeKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_NOTIFY access.
	IN HANDLE EventHandle OPTIONAL,						// EventHandle must grant EVENT_MODIFY_STATE access.
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG NotifyFilter,
	IN BOOLEAN WatchSubtree,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN Asynchronous
	);

// ZwNotifyChangeKey monitors a key for changes.
NTSYSAPI
NTSTATUS
NTAPI
ZwNotifyChangeKey(
	IN HANDLE KeyHandle,								// KeyHandle must grant KEY_NOTIFY access.
	IN HANDLE EventHandle OPTIONAL,						// EventHandle must grant EVENT_MODIFY_STATE access.
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG NotifyFilter,
	IN BOOLEAN WatchSubtree,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN Asynchronous
	);

// NtNotifyChangeMultipleKeys monitors one or two keys for changes.
NTSYSAPI
NTSTATUS
NTAPI
NtNotifyChangeMultipleKeys (
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_NOTIFY access.
	IN ULONG Flags,
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN HANDLE EventHandle OPTIONAL,					// EventHandle must grant EVENT_MODIFY_STATE access.
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG NotifyFilter,
	IN BOOLEAN WatchSubtree,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN Asynchronous
	);

// ZwNotifyChangeMultipleKeys monitors one or two keys for changes.
NTSYSAPI
NTSTATUS
NTAPI
ZwNotifyChangeMultipleKeys (
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_NOTIFY access.
	IN ULONG Flags,
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN HANDLE EventHandle OPTIONAL,					// EventHandle must grant EVENT_MODIFY_STATE access.
	IN PIO_APC_ROUTINE ApcRoutine OPTIONAL,
	IN PVOID ApcContext OPTIONAL,
	OUT PIO_STATUS_BLOCK IoStatusBlock,
	IN ULONG NotifyFilter,
	IN BOOLEAN WatchSubtree,
	IN PVOID Buffer,
	IN ULONG BufferLength,
	IN BOOLEAN Asynchronous
	);

// NtDeleteValueKey deletes a value from a key.
NTSYSAPI
NTSTATUS
NTAPI
NtDeleteValueKey(
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_SET_VALUE access.
	IN PUNICODE_STRING ValueName
	);

// ZwDeleteValueKey deletes a value from a key.
NTSYSAPI
NTSTATUS
NTAPI
ZwDeleteValueKey(
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_SET_VALUE access.
	IN PUNICODE_STRING ValueName
	);

// NtSetValueKey updates or adds a value to a key.
NTSYSAPI
NTSTATUS
NTAPI
NtSetValueKey(
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_SET_VALUE access.
	IN PUNICODE_STRING ValueName,
	IN ULONG TitleIndex,
	IN ULONG Type,
	IN PVOID Data,
	IN ULONG DataSize
	);

// ZwSetValueKey updates or adds a value to a key.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetValueKey(
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_SET_VALUE access.
	IN PUNICODE_STRING ValueName,
	IN ULONG TitleIndex,
	IN ULONG Type,
	IN PVOID Data,
	IN ULONG DataSize
	);

// NtQueryValueKey retrieves information about a key value.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryValueKey(
	IN HANDLE KeyHandle,										// KeyHandle must grant KEY_QUERY_VALUE access.
	IN PUNICODE_STRING ValueName,
	IN KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
	OUT PVOID KeyValueInformation,
	IN ULONG KeyValueInformationLength,
	OUT PULONG ResultLength
	);

// ZwQueryValueKey retrieves information about a key value.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryValueKey(
	IN HANDLE KeyHandle,										// KeyHandle must grant KEY_QUERY_VALUE access.
	IN PUNICODE_STRING ValueName,
	IN KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
	OUT PVOID KeyValueInformation,
	IN ULONG KeyValueInformationLength,
	OUT PULONG ResultLength
	);

// NtEnumerateValueKey enumerates the values of a key.
NTSYSAPI
NTSTATUS
NTAPI
NtEnumerateValueKey(
	IN HANDLE KeyHandle,										// KeyHandle must grant KEY_QUERY_VALUE access.
	IN ULONG Index,
	IN KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
	OUT PVOID KeyValueInformation,
	IN ULONG KeyValueInformationLength,
	OUT PULONG ResultLength
	);

// ZwEnumerateValueKey enumerates the values of a key.
NTSYSAPI
NTSTATUS
NTAPI
ZwEnumerateValueKey(
	IN HANDLE KeyHandle,										// KeyHandle must grant KEY_QUERY_VALUE access.
	IN ULONG Index,
	IN KEY_VALUE_INFORMATION_CLASS KeyValueInformationClass,
	OUT PVOID KeyValueInformation,
	IN ULONG KeyValueInformationLength,
	OUT PULONG ResultLength
	);

// NtQueryMultipleValueKey retrieves information about multiple key values.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryMultipleValueKey(
	IN HANDLE KeyHandle,				// KeyHandle must grant KEY_QUERY_VALUE access.
	IN OUT PKEY_VALUE_ENTRY ValueList,
	IN ULONG NumberOfValues,
	OUT PVOID Buffer,
	IN OUT PULONG Length,
	OUT PULONG ReturnLength
	);

// ZwQueryMultipleValueKey retrieves information about multiple key values.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryMultipleValueKey(
	IN HANDLE KeyHandle,				// KeyHandle must grant KEY_QUERY_VALUE access.
	IN OUT PKEY_VALUE_ENTRY ValueList,
	IN ULONG NumberOfValues,
	OUT PVOID Buffer,
	IN OUT PULONG Length,
	OUT PULONG ReturnLength
	);

// NtInitializeRegistry initializes the registry.  This system service can only be called once per system boot.
NTSYSAPI
NTSTATUS
NTAPI
NtInitializeRegistry(
	IN BOOLEAN Setup
	);

// ZwInitializeRegistry initializes the registry.  This system service can only be called once per system boot.
NTSYSAPI
NTSTATUS
NTAPI
ZwInitializeRegistry(
	IN BOOLEAN Setup
	);

#if _WIN32_WINNT >= 0x0501

// NtCompactKeys attempts to optimize registry space usage for a given subkey path. SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtCompactKeys(
	IN ULONG Length,		// Length must be < 0x3FFFFFFF.  Size of kernel buffer to allocate for compacting.
	IN HANDLE Keys[1]		// Key must grant KEY_WRITE access.
	);

// ZwCompactKeys attempts to optimize registry space usage for a given subkey path. SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwCompactKeys(
	IN ULONG Length,		// Length must be < 0x3FFFFFFF.  Size of kernel buffer to allocate for compacting.
	IN HANDLE Keys[1]		// Key must grant KEY_WRITE access.
	);

// NtCompressKey attempts to compress the data backing a registry key.  SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtCompressKey(
	IN HANDLE Key			// Key must grant KEY_WRITE access.
	);

// ZwCompressKey attempts to compress the data backing a registry key.  SeBackupPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwCompressKey(
	IN HANDLE Key			// Key must grant KEY_WRITE access.
	);

// NtLoadKeyEx mounts a key hive in the registry.  SeRestorePrivilege is required. NtLoadKey and NtLoadKey2 provide a subset
// of the functionality available through NtLoadKeyEx.  If present, Key must be a handle to a volatile hive (that is, a hive
// loaded by one of the NtLoadKey family of functions).  The newly loaded hive's trust class is inherited from the supplied hive.
NTSYSAPI
NTSTATUS
NTAPI
NtLoadKeyEx(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN POBJECT_ATTRIBUTES FileObjectAttributes,
	IN ULONG Flags,
	IN HANDLE Key OPTIONAL						// Key handle need not grant any specific access right.
	);

// ZwLoadKeyEx mounts a key hive in the registry.  SeRestorePrivilege is required. ZwLoadKey and ZwLoadKey2 provide a subset
// of the functionality available through ZwLoadKeyEx.  If present, Key must be a handle to a volatile hive (that is, a hive
// loaded by one of the ZwLoadKey family of functions).  The newly loaded hive's trust class is inherited from the supplied hive.
NTSYSAPI
NTSTATUS
NTAPI
ZwLoadKeyEx(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN POBJECT_ATTRIBUTES FileObjectAttributes,
	IN ULONG Flags,
	IN HANDLE Key OPTIONAL						// Key handle need not grant any specific access rights.
	);

// NtUnloadKeyEx dismounts a key hive in the registry.  The optional event handle is set when the unload operation completes.
// SeRestorePrivilege is required.  NtUnloadKeyEx will asynchronously unload the hive when the last reference to it is closed.
NTSYSAPI
NTSTATUS
NTAPI
NtUnloadKeyEx(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN HANDLE EventHandle OPTIONAL					// Event handle must grant EVENT_MODIFY_STATE access.
	);

// ZwUnloadKeyEx dismounts a key hive in the registry.  The optional event handle is set when the unload operation completes.
// SeRestorePrivilege is required.  ZwUnloadKeyEx will asynchronously unload the hive when the last reference to it is closed.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnloadKeyEx(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN HANDLE EventHandle OPTIONAL					// Event handle must grant EVENT_MODIFY_STATE access.
	);

// NtUnloadKey2 dismounts a key hive in the registry.  SeRestorePrivilege is required.  NtUnloadKey provides a subset of
// the functionality available throrugh NtUnloadKey2.  NtUnloadKey2 can be used to unload a hive even if references to it remain.
NTSYSAPI
NTSTATUS
NTAPI
NtUnloadKey2(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN BOOLEAN ForceUnload							// Should the hive be dismounted even if there are outstanding references?
	);

// ZwUnloadKey2 dismounts a key hive in the registry.  SeRestorePrivilege is required.  ZwUnloadKey provides a subset of
// the functionality available throrugh ZwUnloadKey2.  ZwUnloadKey2 can be used to unload a hive even if references to it remain.
NTSYSAPI
NTSTATUS
NTAPI
ZwUnloadKey2(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,
	IN BOOLEAN ForceUnload							// Should the hive be dismounted even if there are outstanding references?
	);

// NtLockRegistryKey locks a view of the registry into physical memory.  In Windows XP and later, portions
// of the registry can be paged out.  SeLockMemoryPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
NtLockRegistryKey(
	IN HANDLE Key									// Key handle must grant KEY_WRITE access.
	);

// ZwLockRegistryKey locks a view of the registry into physical memory.  In Windows XP and later, portions
// of the registry can be paged out.  SeLockMemoryPrivilege is required.
NTSYSAPI
NTSTATUS
NTAPI
ZwLockRegistryKey(
	IN HANDLE Key									// Key handle must grant KEY_WRITE access.
	);

// NtQueryOpenSubKeysEx reports on the names and owner processes of open keys in a hive.  SeRestorePrivilege is required.
// KeyObjectAttributes must not refer to a hive root; however, it can refer to \Registry.
NTSYSAPI
NTSTATUS
NTAPI
NtQueryOpenSubKeysEx(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,		// Key referred to by KeyObjectAttributes must be accessible for KEY_READ.
	IN ULONG SubKeyInformationLength,				// Must be >= 4
	OUT POPEN_SUB_KEY_INFORMATION SubkeyInformation,
	OUT PULONG ReturnLength
	);

// ZwQueryOpenSubKeysEx reports on the names and owner processes of open keys in a hive.  SeRestorePrivilege is required.
// KeyObjectAttributes must not refer to a hive root; however, it can refer to \Registry.
NTSYSAPI
NTSTATUS
NTAPI
ZwQueryOpenSubKeysEx(
	IN POBJECT_ATTRIBUTES KeyObjectAttributes,		// Key referred to by KeyObjectAttributes must be accessible for KEY_READ.
	IN ULONG SubKeyInformationLength,				// Must be >= 4
	OUT POPEN_SUB_KEY_INFORMATION SubkeyInformation,
	OUT PULONG ReturnLength
	);

// NtSaveKeyEx saves a copy of a key and its subkeys in a file, using the selected hive file format.
NTSYSAPI
NTSTATUS
NTAPI
NtSaveKeyEx(
	IN HANDLE KeyHandle,
	IN HANDLE FileHandle,
	IN ULONG Flags									// REG_STANDARD_FORMAT, etc..
	);

// ZwSaveKeyEx saves a copy of a key and its subkeys in a file, using the selected hive file format.
NTSYSAPI
NTSTATUS
NTAPI
ZwSaveKeyEx(
	IN HANDLE KeyHandle,
	IN HANDLE FileHandle,
	IN ULONG Flags									// REG_STANDARD_FORMAT, etc..
	);

// NtRenameKey renames a registry key.
NTSYSAPI
NTSTATUS
NTAPI
NtRenameKey(
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_WRITE access.
	IN PUNICODE_STRING ReplacementName
	);

// ZwRenameKey renames a registry key.
NTSYSAPI
NTSTATUS
NTAPI
ZwRenameKey(
	IN HANDLE KeyHandle,							// KeyHandle must grant KEY_WRITE access.
	IN PUNICODE_STRING ReplacementName
	);


#endif

_NTNATIVE_END_NT

#endif
