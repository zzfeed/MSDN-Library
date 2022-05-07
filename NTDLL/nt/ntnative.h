#ifndef NTNATIVE_H
#define NTNATIVE_H

#pragma once

#ifdef NTLITE_H

#error NtLite and NtNative headers are mutually exclusive.  Pick exactly one.

#endif

//
// General NtNative preprocessor controls:
//
// _NTNATIVE_IN_NAMESPACE
//
// (C++ only) Place all NTNATIVE definitions in namespace NT.
// Otherwise, they are placed in the global namespace.
// This is primarily used for programs that are structured to use older versions of NTNATIVE
// that required the use of a seperate namespace.
//
// _NTNATIVE_NO_NTSTATUS
//
// Do not include Ntstatus.h.
//
// _NTTYPES_NO_WINNT
//
// Do not duplicate any of the definitions provided by Winnt.h.  Automatically defined if Winnt.h is included
// before NtNative.h
//
// _NTTYPES_NO_NTDEF
//
// Do not duplicate any of the definitions provided by Ntdef.h.  Automatically defined if Ntdef.h is included
// before NtNative.h
//
// _NTNATIVE_NO_NTDLL
//
// Do not include ntdll.lib in the library search list.
//
// _NTNATIVE_LSA_API
//
// Include LSA API definitions (may conflict with Win32 headers).
//
// _NTNATIVE_NO_DBGKD
//
// Do not include DbgKd definitions (typically required when building a WinDbg extesion).
//
// _NTNATIVE_USE_DR_BITFIELDS
//
// Include bitfield definitions (DEBUG_STATUS, DEBUG_CONTROL) for x86 debug registers.
//
// Other controls are described below for including or excluding helper functions defined by various headers.
//

#ifdef _NTNATIVE_NO_WINNT
#define _NTTYPES_NO_WINNT
#endif

#ifdef _NTNATIVE_NO_NTDEF
#define _NTTYPES_NO_NTDEF
#endif

#if defined(__IDA__) && !defined(_NTTYPES_NO_WINNT)
#define _NTTYPES_NO_WINNT
#endif


#if !defined(_X86_) && !defined(_MIPS_) && !defined(_ALPHA_) && !defined(_PPC_) && !defined(_IA64_) && !defined(_AMD64_)
#define _X86_
#endif

#if defined(__cplusplus) && defined(_NTNATIVE_IN_NAMESPACE)
#define _NTNATIVE_BEGIN_NT namespace NT {
#define _NTNATIVE_END_NT  };
#define _NTNATIVE_USING_NT(exp) using NT::exp
#define _NTNATIVE_SELECT_NT(exp) NT::exp
#else
#define _NTNATIVE_BEGIN_NT
#define _NTNATIVE_END_NT
#define _NTNATIVE_USING_NT(exp)
#define _NTNATIVE_SELECT_NT(exp) exp
#endif

#define _NTNATIVE_INLINE __inline
#define _NTNATIVE_NAKED __declspec(naked)
#define _NTNATIVE_NORETURN __declspec(noreturn)

#if _MSC_VER >= 1300
#define _NTNATIVE_FORCEINLINE __inline
#else
#define _NTNATIVE_FORCEINLINE __inline
#endif

#ifndef _WIN32_WINNT
#define _WIN32_WINNT 0x0500
#pragma message("NtNative.h warning: _WIN32_WINNT undefined; assuming Windows 2000.")
#elif _WIN32_WINNT < 0x0400
#pragma message("NtNative.h warning: Compatibility with Windows NT 3.51 is not tested; unexpected failures may occur.")
#endif



#ifndef _NTNATIVE_NO_NTSTATUS

#ifndef WIN32_NO_STATUS
#define WIN32_NO_STATUS
#endif

#undef WIN32_NO_STATUS

#include <ntstatus.h>

#endif

//
// Windows NT/Windows 2000/XP/2003 kernel mode and user mode native API declarations.
// Headers written by Skywing and Yoni.  NtTm routines courtesey of Alex Ionescu.
//
// All declarations are placed in namespace NT; however, this namespace may be selected
// into the global namespace even when the Win32 API is in scope.
//
// _WIN32_WINNT should be defined to reflect the Windows NT version your application is
// being compiled for.  Windows NT 4.0 through Windows Server 2003 are theoretically
// supported, but only Windows 2000 and Windows Server 2003 support have seen real testing
// and verification.
//
// The following optional preprocessor definitions can be used to compile in a variety of
// helper functions used to perform subsystem-specific tasks:
//
// NTNATIVE_CSRSS_FUNCTIONS: Includes various commonly-used CSRSS/CSR support routines.
// NTNATIVE_VDM_FUNCTIONS: Includes routines universal to almost any NT VDM implementation.
// NTNATIVE_DBG_FUNCTIONS: Includes various helper routines, e.g. safe DbgPrompt wrapper.
//

#ifdef __cplusplus
extern "C" {
#endif

#include <pshpack4.h>

#include <nt\nttypes.h>
#include <nt\ntobject.h>
#include <nt\ntport.h>
#include <nt\ntrtl.h>
#include <nt\ntdbg.h>
#include <nt\ntprocess.h>
#include <nt\ntcsr.h>
#include <nt\ntjob.h>
#include <nt\nttoken.h>
#include <nt\ntsynchronization.h>
#include <nt\ntmemory.h>
#include <nt\ntsection.h>
#include <nt\ntthread.h>
#include <nt\nttime.h>
#include <nt\ntprofile.h>
#include <nt\ntfile.h>
#include <nt\ntregistry.h>
#include <nt\ntsecurity.h>
#include <nt\ntpower.h>
#include <nt\ntmisc.h>
#include <nt\ntsystem.h>
#include <nt\ntldr.h>
#include <nt\ntkernel.h>
#include <nt\ntefi.h>
#include <nt\ntvdm.h>
#include <nt\nttm.h>
#include <nt\ntstartup.h>
#include <nt\ntdbgkd.h>

#include <poppack.h>

#ifdef __cplusplus
}
#endif

#ifndef _NTNATIVE_NO_NTSTATUS

#ifndef WIN32_NO_STATUS
#define WIN32_NO_STATUS
#endif

_NTNATIVE_USING_NT(NTSTATUS);

#endif


#ifdef _NTNATIVE_NO_NTDLL

#ifndef NTDLL_LEAN_AND_MEAN
#define NTDLL_LEAN_AND_MEAN /* Obsolete name for compatibility with old applications */
#endif

#endif


#ifndef NTDLL_LEAN_AND_MEAN
#pragma comment(lib, "ntdll.lib")
#endif

#endif

