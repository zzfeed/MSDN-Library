#ifndef NTLDR_H
#define NTLDR_H

#pragma once

_NTNATIVE_BEGIN_NT

// LdrGetDllHandle retrieves the handle (base address) of a loaded executable image.
NTSYSAPI
NTSTATUS
NTAPI
LdrGetDllHandle(
	IN PCWSTR SearchPaths OPTIONAL,
	IN PVOID Reserved,
	IN PUNICODE_STRING ModuleName,
	OUT PHANDLE DllHandle
	);

// LdrGetDllHandle retrieves the address of a symbol exported by a loaded executable image.
NTSYSAPI
NTSTATUS
NTAPI
LdrGetProcedureAddress(
	IN HANDLE ModuleHandle,
	IN PSTRING ProcedureName OPTIONAL,
	IN ULONG ProcedureOrdinalValue OPTIONAL,
	OUT PVOID *ProcedureAddress
	);

// LdrLoadDll maps an executable image into the virtual address space of the process.
NTSYSAPI
NTSTATUS
NTAPI
LdrLoadDll(
	IN PCWSTR SearchPaths OPTIONAL,
	IN PULONG ActionWhenLoading OPTIONAL,
	IN PUNICODE_STRING ModuleName,
	OUT PHANDLE Module
	);

// LdrShutdownProcess frees loader data associated with the process.
NTSYSAPI
NTSTATUS
NTAPI
LdrShutdownProcess(
	VOID
	);

// LdrShutdownThread frees loader data associated with the thread.
NTSYSAPI
NTSTATUS
NTAPI
LdrShutdownThread(
	VOID
	);

// LdrUnloadDll unmaps a loaded executable image from the virtual address space of the process.
NTSYSAPI
NTSTATUS
NTAPI
LdrUnloadDll(
	IN HANDLE Module
	);

// LdrQueryProcessModuleInformation retrieves information about loaded modules in the process.
NTSYSAPI
NTSTATUS
NTAPI
LdrQueryProcessModuleInformation(
	OUT PVOID SystemModuleInformation, // ULONG Count, SYSTEM_MODULE_INFORMATION[]
	IN ULONG InformationSize,
	OUT PULONG ReturnSize OPTIONAL
	);

// LdrDisableThreadCalloutsForDll disables DLL_THREAD_ATTACH/DLL_THREAD_DETACH calls to the
// specified DLL's DllMain entrypoint function.
NTSYSAPI
NTSTATUS
NTAPI
LdrDisableThreadCalloutsForDll(
	IN HANDLE Module
	);

// LdrInitializeThunk allocates TLS data and calls DLL entrypoints for a new thread creation.
// It follows the KNORMAL_ROUTINE prototype, HOWEVER versions of it have been known to ruin
// the caller's context!
NTSYSAPI
VOID
NTAPI
LdrInitializeThunk(
	PVOID Context1,
	PVOID Context2,
	PVOID Context3
	);

// LdrQueryImageFileExecutionOptions retrieves ImageFileExecutionOptions values from the registry.
NTSYSAPI
NTSTATUS
NTAPI
LdrQueryImageFileExecutionOptions(
	IN PUNICODE_STRING ImagePath,
	IN PUSHORT OptionName,
	IN ULONG RequestedType, // Registry value type
	OUT PVOID Option,
	IN ULONG OptionSize,
	OUT PULONG ReturnLength OPTIONAL
	);

#if _WIN32_WINNT >= 0x0502

// LdrQueryImageFileExecutionOptionsEx retrieves ImageFileExecutionOptions values from the registry.
NTSYSAPI
NTSTATUS
NTAPI
LdrQueryImageFileExecutionOptionsEx(
	IN PUNICODE_STRING ImagePath,
	IN PUSHORT OptionName,
	IN ULONG RequestedType, // Registry value type
	OUT PVOID Option,
	IN ULONG OptionSize,
	OUT PULONG ReturnLength OPTIONAL,
	IN BOOLEAN Wow64Query
	);

#endif

_NTNATIVE_END_NT

#endif
