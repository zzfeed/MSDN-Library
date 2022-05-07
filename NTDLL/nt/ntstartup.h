#ifndef _MSC_VER
#pragma once
#endif

#ifndef NTSTARTUP_H
#define NTSTARTUP_H

_NTNATIVE_BEGIN_NT

//
// Entry point for an NT application.
// NtProcessStartup must not return.  It must exit the process with NtTerminateProcess(NtCurrentProcess(), ExitStatus);
// The RTL_USER_PROCESS_PARAMETERS field of the PEB must be normalized before it is used.
//

DECLSPEC_NORETURN
VOID
NTAPI
NtProcessStartup(
	IN PPEB Peb
	);

_NTNATIVE_END_NT

#endif
