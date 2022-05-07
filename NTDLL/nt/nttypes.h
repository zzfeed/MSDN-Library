#ifndef NTTYPES_H
#define NTTYPES_H

#pragma once
#pragma warning(push)
#pragma warning(disable:4201)

#if !defined(_NTDEF_)
#define _NTDEF_
#else
#define _NTTYPES_NO_NTDEF
#endif

#if !defined(_WINNT_)
#define _WINNT_
#else
#define _NTTYPES_NO_WINNT
#endif

#if !defined(BASETYPES)
#define BASETYPES
#else
#define _NTTYPES_NO_BASETYPES
#endif

#if !defined(_WINUSER_)
#define _WINUSER_
#else
#define _NTTYPES_NO_WINUSER
#endif

#if !defined(_NTNATIVE_NO_DBGKD)
#if !defined(_WDBGEXTS_)
#define _WDBGEXTS_
#else
#define _NTTYPES_NO_DBGKD
#endif
#else
#define _NTTYPES_NO_DBGKD
#endif

/*
#if !defined(_WINDEF_)
#define _WINDEF_
#else
#define _NTTYPES_NO_WINDEF
#endif
*/


_NTNATIVE_BEGIN_NT


#if defined(_WIN64)
#include <pshpack8.h>
#else
#include <pshpack4.h>
#endif



//
// TYPE_ALIGNMENT will return the alignment requirements of a given type for
// the current platform.
//

#ifndef __cplusplus
#ifndef TYPE_ALIGNMENT
#define TYPE_ALIGNMENT( t ) \
	FIELD_OFFSET( struct { char x; t test; }, test )
#endif
#endif

#ifndef PROBE_ALIGNMENT
#if defined(_WIN64)

#define PROBE_ALIGNMENT( _s ) (TYPE_ALIGNMENT( _s ) > TYPE_ALIGNMENT( ULONG ) ? \
	TYPE_ALIGNMENT( _s ) : TYPE_ALIGNMENT( ULONG ))

#else

#define PROBE_ALIGNMENT( _s ) TYPE_ALIGNMENT( ULONG )

#endif
#endif

//
// C_ASSERT() can be used to perform many compile-time assertions:
//            type sizes, field offsets, etc.
//
// An assertion failure results in error C2118: negative subscript.
//

#ifndef C_ASSERT
#define C_ASSERT(e) typedef char __C_ASSERT__[(e)?1:-1]
#endif

#if (defined(_M_IX86) || defined(_M_IA64) || defined(_M_AMD64)) && !defined(MIDL_PASS)
#define DECLSPEC_IMPORT __declspec(dllimport)
#else
#define DECLSPEC_IMPORT
#endif

#ifndef DECLSPEC_NORETURN
#if (_MSC_VER >= 1200) && !defined(MIDL_PASS)
#define DECLSPEC_NORETURN   __declspec(noreturn)
#else
#define DECLSPEC_NORETURN
#endif
#endif

#ifndef DECLSPEC_ALIGN
#if (_MSC_VER >= 1300) && !defined(MIDL_PASS)
#define DECLSPEC_ALIGN(x)   __declspec(align(x))
#else
#define DECLSPEC_ALIGN(x)
#endif
#endif

#ifndef DECLSPEC_CACHEALIGN
#define DECLSPEC_CACHEALIGN DECLSPEC_ALIGN(128)
#endif

#ifndef DECLSPEC_UUID
#if (_MSC_VER >= 1100) && defined (__cplusplus)
#define DECLSPEC_UUID(x)    __declspec(uuid(x))
#else
#define DECLSPEC_UUID(x)
#endif
#endif

#ifndef DECLSPEC_NOVTABLE
#if (_MSC_VER >= 1100) && defined(__cplusplus)
#define DECLSPEC_NOVTABLE   __declspec(novtable)
#else
#define DECLSPEC_NOVTABLE
#endif
#endif

#ifndef DECLSPEC_SELECTANY
#if (_MSC_VER >= 1100)
#define DECLSPEC_SELECTANY  __declspec(selectany)
#else
#define DECLSPEC_SELECTANY
#endif
#endif

#ifndef NOP_FUNCTION
#if (_MSC_VER >= 1210)
#define NOP_FUNCTION __noop
#else
#define NOP_FUNCTION (void)0
#endif
#endif

#ifndef DECLSPEC_ADDRSAFE
#if (_MSC_VER >= 1200) && (defined(_M_ALPHA) || defined(_M_AXP64))
#define DECLSPEC_ADDRSAFE  __declspec(address_safe)
#else
#define DECLSPEC_ADDRSAFE
#endif
#endif

#ifndef FORCEINLINE
#if (_MSC_VER >= 1200)
#define FORCEINLINE __forceinline
#else
#define FORCEINLINE __inline
#endif
#endif

#ifndef DECLSPEC_DEPRECATED
#if (_MSC_VER >= 1300) && !defined(MIDL_PASS)
#define DECLSPEC_DEPRECATED   __declspec(deprecated)
#define DEPRECATE_SUPPORTED
#else
#define DECLSPEC_DEPRECATED
#undef  DEPRECATE_SUPPORTED
#endif
#endif

#if !defined(_MAC) && (defined(_M_MRX000) || defined(_M_ALPHA) || defined(_M_IA64)) && (_MSC_VER >= 1100) && !(defined(MIDL_PASS) || defined(RC_INVOKED))
#ifndef POINTER_64
#define POINTER_64 __ptr64
#endif
typedef unsigned __int64 POINTER_64_INT;
#if defined(_WIN64)
#ifndef POINTER_32
#define POINTER_32 __ptr32
#endif
#else
#ifndef POINTER_32
#define POINTER_32 __ptr32
#endif
#endif
#else
#if defined(_MAC) && defined(_MAC_INT_64)
#ifndef POINTER_64
#define POINTER_64 __ptr64
#endif
typedef unsigned __int64 POINTER_64_INT;
#else
#ifndef POINTER_64
#define POINTER_64 __ptr64
#endif
//typedef unsigned long POINTER_64_INT;
#ifdef _WIN64
typedef unsigned __int64 POINTER_64_INT;
#else
typedef unsigned long POINTER_64_INT;
#endif
#endif
#ifndef POINTER_32
#define POINTER_32 __ptr32
#endif
#endif

#ifndef FIRMWARE_PTR
#if defined(_IA64_)
#define FIRMWARE_PTR
#else
#define FIRMWARE_PTR POINTER_32
#endif
#endif

#ifndef CONST
#define CONST const
#endif

#ifndef DECLSPEC_IMPORT
#if (defined(_M_MRX000) || defined(_M_IX86) || defined(_M_ALPHA) || defined(_M_PPC)) && !defined(MIDL_PASS)
#define DECLSPEC_IMPORT __declspec(dllimport)
#else
#define DECLSPEC_IMPORT
#endif
#endif

#ifndef DECLSPEX_EXPORT
#if (defined(_M_MRX000) || defined(_M_IX86) || defined(_M_ALPHA) || defined(_M_PPC)) && !defined(MIDL_PASS)
#define DECLSPEC_EXPORT __declspec(dllexport)
#else
#define DECLSPEC_EXPORT
#endif
#endif

#if (_MSC_VER >= 800) || defined(_STDCALL_SUPPORTED)
#define NTAPI __stdcall
#else
#define _cdecl
#define NTAPI
#endif

#ifndef NTFASTAPI
#define NTFASTAPI __fastcall
#endif

#if !defined(_NTSYSTEM_)
#define NTSYSAPI DECLSPEC_IMPORT
#else
#define NTSYSAPI DECLSPEC_EXPORT
#endif

#ifndef CONST
#define CONST               const
#endif

/*
#ifndef PVOID
typedef void *PVOID;    
#endif
*/

/*
#ifndef PSID
typedef PVOID PSID;
#endif
*/

#ifndef FALSE
#define FALSE   0
#endif
#ifndef TRUE
#define TRUE    1
#endif

#ifndef NULL
#ifdef __cplusplus
#define NULL    0
#else
#define NULL    ((void *)0)
#endif
#endif // NULL

#ifndef IN
#define IN
#endif

#ifndef OUT
#define OUT
#endif

#ifndef OPTIONAL
#define OPTIONAL
#endif

#ifndef ANYSIZE_ARRAY
#define ANYSIZE_ARRAY 1       
#endif

#if defined(_M_MRX000) && !(defined(MIDL_PASS) || defined(RC_INVOKED)) && defined(ENABLE_RESTRICTED)
#define RESTRICTED_POINTER __restrict
#else
#define RESTRICTED_POINTER
#endif

#if defined(_M_MRX000) || defined(_M_ALPHA) || defined(_M_PPC) || defined(_M_IA64) || defined(_M_AMD64)
#define UNALIGNED __unaligned
#if defined(_WIN64)
#define UNALIGNED64 __unaligned
#else
#define UNALIGNED64
#endif
#else
#define UNALIGNED
#define UNALIGNED64
#endif


#ifndef MAX_NATURAL_ALIGNMENT
#if defined(_WIN64) || defined(_M_ALPHA)
#define MAX_NATURAL_ALIGNMENT sizeof(ULONGLONG)
#else
#define MAX_NATURAL_ALIGNMENT sizeof(ULONG)
#endif
#endif

#ifndef FASTCALL
#if defined(_M_IX86)
#define FASTCALL _fastcall
#else
#define FASTCALL
#endif
#endif

//
// Useful Helper Macros
//

//
// Determine if an argument is present by testing the value of the pointer
// to the argument value.
//

#ifndef ARGUMENT_PRESENT
#define ARGUMENT_PRESENT(ArgumentPointer)    (\
    (CHAR *)(ArgumentPointer) != (CHAR *)(NULL) )
#endif

//
// Calculate the byte offset of a field in a structure of type type.
//

#ifndef FIELD_OFFSET
#define FIELD_OFFSET(type, field)    ((LONG)(LONG_PTR)&(((type *)0)->field))
#endif

//
// Calculate the address of the base of the structure given its type, and an
// address of a field within the structure.
//

#ifndef CONTAINING_RECORD
#define CONTAINING_RECORD(address, type, field) ((type *)( \
                                                  (PCHAR)(address) - \
                                                  (ULONG_PTR)(&((type *)0)->field)))
#endif





#ifndef _NTTYPES_NO_BASETYPES

typedef unsigned int UINT;
typedef unsigned long ULONG;
typedef ULONG *PULONG;
typedef ULONG DWORD;
typedef ULONG* PDWORD;
typedef unsigned short USHORT;
typedef USHORT *PUSHORT;
typedef unsigned char UCHAR;
typedef UCHAR *PUCHAR;
typedef char *PSZ;
typedef long LONG;
typedef short SHORT;

typedef SHORT *PSHORT;  
typedef LONG *PLONG;    

typedef unsigned char UCHAR;
typedef unsigned short USHORT;
typedef unsigned long ULONG;

#ifndef __IDA__

typedef struct _QUAD {              // QUAD is for those times we want
    double  DoNotUseThisField;      // an 8 byte aligned 8 byte long structure
} QUAD;                             // which is NOT really a floating point
                                    // number.  Use DOUBLE if you want an FP
                                    // number.

typedef QUAD UQUAD;

#endif

typedef signed char SCHAR;
typedef SCHAR *PSCHAR;

#ifndef NO_STRICT
#ifndef STRICT
#define STRICT 1
#endif
#endif

typedef UCHAR  FCHAR;
typedef USHORT FSHORT;
typedef ULONG  FLONG;

typedef float FLOAT;

#ifndef VOID
#define VOID void
typedef char CHAR;
typedef short SHORT;
typedef long LONG;
#endif

#ifndef _WCHAR_T_DEFINED
typedef unsigned short wchar_t;
#define _WCHAR_T_DEFINED
#endif

#ifndef _MAC
typedef wchar_t WCHAR;
#else

typedef unsigned short WCHAR;
#endif

typedef WCHAR *PWCHAR;
typedef WCHAR *LPWCH, *PWCH;
typedef CONST WCHAR *LPCWCH, *PCWCH;
typedef WCHAR *NWPSTR;
typedef WCHAR *LPWSTR, *PWSTR;
typedef WCHAR UNALIGNED *LPUWSTR, *PUWSTR;

typedef CONST WCHAR *LPCWSTR, *PCWSTR;
typedef CONST WCHAR UNALIGNED *LPCUWSTR, *PCUWSTR;


typedef CHAR *PCHAR;
typedef CHAR *LPCH, *PCH;

typedef CONST CHAR *LPCCH, *PCCH;
typedef CHAR *NPSTR;
typedef CHAR *LPSTR, *PSTR;
typedef CONST CHAR *LPCSTR, *PCSTR;

#endif


typedef void* PVOID;
typedef void* LPVOID;


#ifdef STRICT
typedef void *HANDLE;
#define DECLARE_HANDLE(name) struct name##__ { int unused; }; typedef struct name##__ *name
#else
typedef PVOID HANDLE;
#define DECLARE_HANDLE(name) typedef HANDLE name
#endif
typedef HANDLE *PHANDLE;

#if !defined(_W64)
#if !defined(__midl) && (defined(_X86_) || defined(_M_IX86)) && _MSC_VER >= 1300
#define _W64 __w64
#else
#define _W64
#endif
#endif

#if !defined(__IDA__)


//
// The INT_PTR is guaranteed to be the same size as a pointer.  Its
// size with change with pointer size (32/64).  It should be used
// anywhere that a pointer is cast to an integer type. UINT_PTR is
// the unsigned variation.
//
// __int3264 is intrinsic to 64b MIDL but not to old MIDL or to C compiler.
//
#if ( 501 < __midl )

    typedef [public] __int3264 INT_PTR, *PINT_PTR;
    typedef [public] unsigned __int3264 UINT_PTR, *PUINT_PTR;

    typedef [public] __int3264 LONG_PTR, *PLONG_PTR;
    typedef [public] unsigned __int3264 ULONG_PTR, *PULONG_PTR;

#else  // midl64
// old midl and C++ compiler

#if defined(_WIN64)
    typedef __int64 INT_PTR, *PINT_PTR;
    typedef unsigned __int64 UINT_PTR, *PUINT_PTR;

    typedef __int64 LONG_PTR, *PLONG_PTR;
    typedef unsigned __int64 ULONG_PTR, *PULONG_PTR;

    #define __int3264   __int64

#else
    typedef _W64 int INT_PTR, *PINT_PTR;
    typedef _W64 unsigned int UINT_PTR, *PUINT_PTR;

    typedef _W64 long LONG_PTR, *PLONG_PTR;
    typedef _W64 unsigned long ULONG_PTR, *PULONG_PTR;

    #define __int3264   __int32

#endif
#endif // midl64

#else

#if defined(_WIN64)

typedef __int64 INT_PTR, * PINT_PTR;
typedef unsigned __int64 UINT_PTR, * PUINT_PTR;
typedef __int64 LONG_PTR, * PLONG_PTR;
typedef unsigned __int64 ULONG_PTR, * PULONG_PTR;

#else

typedef int INT_PTR, * PINT_PTR;
typedef unsigned int UINT_PTR, * PUINT_PTR;
typedef long LONG_PTR, * PLONG_PTR;
typedef unsigned long ULONG_PTR, * PULONG_PTR;

#endif

#endif


typedef ULONG_PTR SIZE_T, *PSIZE_T;
typedef LONG_PTR SSIZE_T, *PSSIZE_T;
typedef ULONG_PTR DWORD_PTR;
typedef ULONG_PTR* PDWORD_PTR;


//
// Low order two bits of a handle are ignored by the system and available
// for use by application code as tag bits.  The remaining bits are opaque
// and used to store a serial number and table index.
//

#ifndef OBJ_HANDLE_TAGBITS
enum {
	OBJ_HANDLE_TAGBITS	=	0x00000003L
};
//#define OBJ_HANDLE_TAGBITS  0x00000003L
#endif

#ifndef _DWORD_DEFINED
#define _DWORD_DEFINED
typedef unsigned long DWORD;
#endif

typedef unsigned __int64 ULONG64, *PULONG64;
typedef unsigned __int64 DWORD64, *PDWORD64;

#ifndef _WORD_DEFINED
#define _WORD_DEFINED
typedef unsigned short WORD;
#endif

typedef WORD* PWORD;

#ifndef _BYTE_DEFINED
typedef unsigned char BYTE;
#define _BYTE_DEFINED
#endif

typedef struct _NTSYSTEMTIME
{
	WORD wYear;
	WORD wMonth;
	WORD wDayOfWeek;
	WORD wDay;
	WORD wHour;
	WORD wMinute;
	WORD wSecond;
	WORD wMilliseconds;
} 	NTSYSTEMTIME;

typedef struct _NTSYSTEMTIME *PNTSYSTEMTIME;

typedef struct _NTSYSTEMTIME *LPNTSYSTEMTIME;

typedef BYTE  BOOLEAN;           
typedef BOOLEAN *PBOOLEAN; 

#if !defined(_NTTYPES_NO_WINNT)

//
// Cardinal Data Types [0 - 2**N-2)
//

typedef char CCHAR;          // winnt

#endif
typedef short CSHORT;
typedef ULONG CLONG;

typedef CCHAR *PCCHAR;
typedef CSHORT *PCSHORT;
typedef CLONG *PCLONG;

// end_ntminiport end_ntndis end_ntminitape

#ifndef __IDA__
#ifndef GUID_DEFINED
#define GUID_DEFINED

typedef struct _GUID {          // size is 16
	ULONG Data1;
	USHORT Data2;
	USHORT Data3;
	UCHAR Data4[8];
} GUID;

#endif
#endif

typedef GUID CLSID;
typedef CLSID *LPCLSID;

//
// UUID Generation
//

typedef GUID UUID;







//////////////////////////////////////////////////////
// BEGIN SECURITY TYPES AND CONSTANTS FROM WINNT.H
// BEGIN_WINNT_SECURITY
//


#if !defined(__IDA__)
#ifndef SID_IDENTIFIER_AUTHORITY_DEFINED
#define SID_IDENTIFIER_AUTHORITY_DEFINED
typedef struct _SID_IDENTIFIER_AUTHORITY {
	BYTE  Value[6];
} SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;
#endif

#ifndef SID_DEFINED
#define SID_DEFINED
typedef struct _SID
{
	BYTE Revision;
	BYTE SubAuthorityCount;
	SID_IDENTIFIER_AUTHORITY IdentifierAuthority;
	/* [size_is] */ ULONG SubAuthority[ 1 ];
} 	SID;

typedef struct _SID *PISID;

typedef struct _SID_AND_ATTRIBUTES
{
	SID *Sid;
	DWORD Attributes;
} 	SID_AND_ATTRIBUTES;

typedef struct _SID_AND_ATTRIBUTES *PSID_AND_ATTRIBUTES;

#endif
#endif

typedef PVOID PSID;
typedef PVOID PACCESS_TOKEN;
typedef PVOID PSECURITY_DESCRIPTOR;

#ifndef _NTTYPES_NO_WINNT

typedef DWORD ACCESS_MASK;
typedef ACCESS_MASK *PACCESS_MASK;

//
// Locally Unique Identifier
//

#ifndef __IDA__

typedef struct _LUID {
	ULONG LowPart;
	LONG HighPart;
} LUID, *PLUID;

typedef struct _LUID_AND_ATTRIBUTES {
	LUID Luid;
	DWORD Attributes;
} LUID_AND_ATTRIBUTES, * PLUID_AND_ATTRIBUTES;
typedef LUID_AND_ATTRIBUTES LUID_AND_ATTRIBUTES_ARRAY[ANYSIZE_ARRAY];
typedef LUID_AND_ATTRIBUTES_ARRAY *PLUID_AND_ATTRIBUTES_ARRAY;

#endif

#define ACL_REVISION     (2)
#define ACL_REVISION_DS  (4)

// This is the history of ACL revisions.  Add a new one whenever
// ACL_REVISION is updated

#define ACL_REVISION1   (1)
#define MIN_ACL_REVISION ACL_REVISION2
#define ACL_REVISION2   (2)
#define ACL_REVISION3   (3)
#define ACL_REVISION4   (4)
#define MAX_ACL_REVISION ACL_REVISION4

typedef struct _ACL {
	BYTE  AclRevision;
	BYTE  Sbz1;
	WORD   AclSize;
	WORD   AceCount;
	WORD   Sbz2;
} ACL;
typedef ACL *PACL;

typedef struct _ACE_HEADER {
	BYTE  AceType;
	BYTE  AceFlags;
	WORD   AceSize;
} ACE_HEADER;
typedef ACE_HEADER *PACE_HEADER;

#define ACCESS_MIN_MS_ACE_TYPE                  (0x0)
#define ACCESS_ALLOWED_ACE_TYPE                 (0x0)
#define ACCESS_DENIED_ACE_TYPE                  (0x1)
#define SYSTEM_AUDIT_ACE_TYPE                   (0x2)
#define SYSTEM_ALARM_ACE_TYPE                   (0x3)
#define ACCESS_MAX_MS_V2_ACE_TYPE               (0x3)

#define ACCESS_ALLOWED_COMPOUND_ACE_TYPE        (0x4)
#define ACCESS_MAX_MS_V3_ACE_TYPE               (0x4)

#define ACCESS_MIN_MS_OBJECT_ACE_TYPE           (0x5)
#define ACCESS_ALLOWED_OBJECT_ACE_TYPE          (0x5)
#define ACCESS_DENIED_OBJECT_ACE_TYPE           (0x6)
#define SYSTEM_AUDIT_OBJECT_ACE_TYPE            (0x7)
#define SYSTEM_ALARM_OBJECT_ACE_TYPE            (0x8)
#define ACCESS_MAX_MS_OBJECT_ACE_TYPE           (0x8)

#define ACCESS_MAX_MS_V4_ACE_TYPE               (0x8)
#define ACCESS_MAX_MS_ACE_TYPE                  (0x8)

#define ACCESS_ALLOWED_CALLBACK_ACE_TYPE        (0x9)
#define ACCESS_DENIED_CALLBACK_ACE_TYPE         (0xA)
#define ACCESS_ALLOWED_CALLBACK_OBJECT_ACE_TYPE (0xB)
#define ACCESS_DENIED_CALLBACK_OBJECT_ACE_TYPE  (0xC)
#define SYSTEM_AUDIT_CALLBACK_ACE_TYPE          (0xD)
#define SYSTEM_ALARM_CALLBACK_ACE_TYPE          (0xE)
#define SYSTEM_AUDIT_CALLBACK_OBJECT_ACE_TYPE   (0xF)
#define SYSTEM_ALARM_CALLBACK_OBJECT_ACE_TYPE   (0x10)

#define ACCESS_MAX_MS_V5_ACE_TYPE               (0x10)

//
//  The following are the inherit flags that go into the AceFlags field
//  of an Ace header.
//

#define OBJECT_INHERIT_ACE                (0x1)
#define CONTAINER_INHERIT_ACE             (0x2)
#define NO_PROPAGATE_INHERIT_ACE          (0x4)
#define INHERIT_ONLY_ACE                  (0x8)
#define INHERITED_ACE                     (0x10)
#define VALID_INHERIT_FLAGS               (0x1F)

//  The following are the currently defined ACE flags that go into the
//  AceFlags field of an ACE header.  Each ACE type has its own set of
//  AceFlags.
//
//  SUCCESSFUL_ACCESS_ACE_FLAG - used only with system audit and alarm ACE
//  types to indicate that a message is generated for successful accesses.
//
//  FAILED_ACCESS_ACE_FLAG - used only with system audit and alarm ACE types
//  to indicate that a message is generated for failed accesses.
//

//
//  SYSTEM_AUDIT and SYSTEM_ALARM AceFlags
//
//  These control the signaling of audit and alarms for success or failure.
//

#define SUCCESSFUL_ACCESS_ACE_FLAG       (0x40)
#define FAILED_ACCESS_ACE_FLAG           (0x80)

//  The following are the four predefined ACE types.

//  Examine the AceType field in the Header to determine
//  which structure is appropriate to use for casting.


typedef struct _ACCESS_ALLOWED_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
} ACCESS_ALLOWED_ACE;

typedef ACCESS_ALLOWED_ACE *PACCESS_ALLOWED_ACE;

typedef struct _ACCESS_DENIED_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
} ACCESS_DENIED_ACE;
typedef ACCESS_DENIED_ACE *PACCESS_DENIED_ACE;

typedef struct _SYSTEM_AUDIT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
} SYSTEM_AUDIT_ACE;
typedef SYSTEM_AUDIT_ACE *PSYSTEM_AUDIT_ACE;

typedef struct _SYSTEM_ALARM_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
} SYSTEM_ALARM_ACE;
typedef SYSTEM_ALARM_ACE *PSYSTEM_ALARM_ACE;

// end_ntifs


typedef struct _ACCESS_ALLOWED_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
} ACCESS_ALLOWED_OBJECT_ACE, *PACCESS_ALLOWED_OBJECT_ACE;

typedef struct _ACCESS_DENIED_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
} ACCESS_DENIED_OBJECT_ACE, *PACCESS_DENIED_OBJECT_ACE;

typedef struct _SYSTEM_AUDIT_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
} SYSTEM_AUDIT_OBJECT_ACE, *PSYSTEM_AUDIT_OBJECT_ACE;

typedef struct _SYSTEM_ALARM_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
} SYSTEM_ALARM_OBJECT_ACE, *PSYSTEM_ALARM_OBJECT_ACE;

//
// Callback ace support in post Win2000.
// Resource managers can put their own data after Sidstart + Length of the sid
//

typedef struct _ACCESS_ALLOWED_CALLBACK_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
	// Opaque resouce manager specific data
} ACCESS_ALLOWED_CALLBACK_ACE, *PACCESS_ALLOWED_CALLBACK_ACE;

typedef struct _ACCESS_DENIED_CALLBACK_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
	// Opaque resouce manager specific data
} ACCESS_DENIED_CALLBACK_ACE, *PACCESS_DENIED_CALLBACK_ACE;

typedef struct _SYSTEM_AUDIT_CALLBACK_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
	// Opaque resouce manager specific data
} SYSTEM_AUDIT_CALLBACK_ACE, *PSYSTEM_AUDIT_CALLBACK_ACE;

typedef struct _SYSTEM_ALARM_CALLBACK_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD SidStart;
	// Opaque resouce manager specific data
} SYSTEM_ALARM_CALLBACK_ACE, *PSYSTEM_ALARM_CALLBACK_ACE;

typedef struct _ACCESS_ALLOWED_CALLBACK_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
	// Opaque resouce manager specific data
} ACCESS_ALLOWED_CALLBACK_OBJECT_ACE, *PACCESS_ALLOWED_CALLBACK_OBJECT_ACE;

typedef struct _ACCESS_DENIED_CALLBACK_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
	// Opaque resouce manager specific data
} ACCESS_DENIED_CALLBACK_OBJECT_ACE, *PACCESS_DENIED_CALLBACK_OBJECT_ACE;

typedef struct _SYSTEM_AUDIT_CALLBACK_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
	// Opaque resouce manager specific data
} SYSTEM_AUDIT_CALLBACK_OBJECT_ACE, *PSYSTEM_AUDIT_CALLBACK_OBJECT_ACE;

typedef struct _SYSTEM_ALARM_CALLBACK_OBJECT_ACE {
	ACE_HEADER Header;
	ACCESS_MASK Mask;
	DWORD Flags;
	GUID ObjectType;
	GUID InheritedObjectType;
	DWORD SidStart;
	// Opaque resouce manager specific data
} SYSTEM_ALARM_CALLBACK_OBJECT_ACE, *PSYSTEM_ALARM_CALLBACK_OBJECT_ACE;

//
// Currently define Flags for "OBJECT" ACE types.
//

#define ACE_OBJECT_TYPE_PRESENT           0x1
#define ACE_INHERITED_OBJECT_TYPE_PRESENT 0x2


//
//  The following declarations are used for setting and querying information
//  about and ACL.  First are the various information classes available to
//  the user.
//

typedef enum _ACL_INFORMATION_CLASS {
	AclRevisionInformation = 1,
	AclSizeInformation
} ACL_INFORMATION_CLASS;

//
//  This record is returned/sent if the user is requesting/setting the
//  AclRevisionInformation
//

typedef struct _ACL_REVISION_INFORMATION {
	DWORD AclRevision;
} ACL_REVISION_INFORMATION;
typedef ACL_REVISION_INFORMATION *PACL_REVISION_INFORMATION;

//
//  This record is returned if the user is requesting AclSizeInformation
//

typedef struct _ACL_SIZE_INFORMATION {
	DWORD AceCount;
	DWORD AclBytesInUse;
	DWORD AclBytesFree;
} ACL_SIZE_INFORMATION;
typedef ACL_SIZE_INFORMATION *PACL_SIZE_INFORMATION;




#define SECURITY_DESCRIPTOR_REVISION     (1)
#define SECURITY_DESCRIPTOR_REVISION1    (1)

// end_wdm end_ntddk


#define SECURITY_DESCRIPTOR_MIN_LENGTH   (sizeof(SECURITY_DESCRIPTOR))


typedef USHORT   SECURITY_DESCRIPTOR_CONTROL, *PSECURITY_DESCRIPTOR_CONTROL;

#define SE_OWNER_DEFAULTED               (0x0001)
#define SE_GROUP_DEFAULTED               (0x0002)
#define SE_DACL_PRESENT                  (0x0004)
#define SE_DACL_DEFAULTED                (0x0008)
#define SE_SACL_PRESENT                  (0x0010)
#define SE_SACL_DEFAULTED                (0x0020)
#define SE_DACL_AUTO_INHERIT_REQ         (0x0100)
#define SE_SACL_AUTO_INHERIT_REQ         (0x0200)
#define SE_DACL_AUTO_INHERITED           (0x0400)
#define SE_SACL_AUTO_INHERITED           (0x0800)
#define SE_DACL_PROTECTED                (0x1000)
#define SE_SACL_PROTECTED                (0x2000)
#define SE_RM_CONTROL_VALID              (0x4000)
#define SE_SELF_RELATIVE                 (0x8000)

typedef struct _SECURITY_DESCRIPTOR_RELATIVE {
	BYTE  Revision;
	BYTE  Sbz1;
	SECURITY_DESCRIPTOR_CONTROL Control;
	DWORD Owner;
	DWORD Group;
	DWORD Sacl;
	DWORD Dacl;
} SECURITY_DESCRIPTOR_RELATIVE, *PISECURITY_DESCRIPTOR_RELATIVE;

typedef struct _SECURITY_DESCRIPTOR {
	BYTE  Revision;
	BYTE  Sbz1;
	SECURITY_DESCRIPTOR_CONTROL Control;
	PSID Owner;
	PSID Group;
	PACL Sacl;
	PACL Dacl;

} SECURITY_DESCRIPTOR, *PISECURITY_DESCRIPTOR;


typedef struct _OBJECT_TYPE_LIST {
	WORD   Level;
	WORD   Sbz;
	GUID *ObjectType;
} OBJECT_TYPE_LIST, *POBJECT_TYPE_LIST;

//
// DS values for Level
//

#define ACCESS_OBJECT_GUID       0
#define ACCESS_PROPERTY_SET_GUID 1
#define ACCESS_PROPERTY_GUID     2

#define ACCESS_MAX_LEVEL         4

//
// Parameters to NtAccessCheckByTypeAndAditAlarm
//

typedef enum _AUDIT_EVENT_TYPE {
	AuditEventObjectAccess,
	AuditEventDirectoryServiceAccess
} AUDIT_EVENT_TYPE, *PAUDIT_EVENT_TYPE;

#define AUDIT_ALLOW_NO_PRIVILEGE 0x1

//
// DS values for Source and ObjectTypeName
//

#define ACCESS_DS_SOURCE_A "DS"
#define ACCESS_DS_SOURCE_W L"DS"
#define ACCESS_DS_OBJECT_TYPE_NAME_A "Directory Service Object"
#define ACCESS_DS_OBJECT_TYPE_NAME_W L"Directory Service Object"

//
// Privilege attributes
//

#define SE_PRIVILEGE_ENABLED_BY_DEFAULT (0x00000001L)
#define SE_PRIVILEGE_ENABLED            (0x00000002L)
#define SE_PRIVILEGE_REMOVED            (0X00000004L)
#define SE_PRIVILEGE_USED_FOR_ACCESS    (0x80000000L)

//
// Privilege Set Control flags
//

#define PRIVILEGE_SET_ALL_NECESSARY    (1)

//
//  Privilege Set - This is defined for a privilege set of one.
//                  If more than one privilege is needed, then this structure
//                  will need to be allocated with more space.
//
//  Note: don't change this structure without fixing the INITIAL_PRIVILEGE_SET
//  structure (defined in se.h)
//

typedef struct _PRIVILEGE_SET {
	DWORD PrivilegeCount;
	DWORD Control;
#ifdef __IDA__
	struct _LUID_AND_ATTRIBUTES Privilege[ANYSIZE_ARRAY];
#else
	struct _LUID_AND_ATTRIBUTES Privilege[ANYSIZE_ARRAY];
#endif
} PRIVILEGE_SET, * PPRIVILEGE_SET;

#endif


//
// NLS basics (Locale and Language Ids)
//

#if !defined(_NTTYPES_NO_WINNT)

typedef ULONG LCID;         // winnt
typedef PULONG PLCID;       // winnt
typedef USHORT LANGID;      // winnt

#endif

#if !defined(_NTTYPES_NO_NTDEF)

//
// Logical Data Type - These are 32-bit logical values.
//

typedef ULONG LOGICAL;
typedef ULONG *PLOGICAL;

// begin_ntndis begin_windbgkd
//
// NTSTATUS
//

#endif

#ifndef _NTSTATUS_DEFINED_

typedef LONG NTSTATUS;
/*lint -save -e624 */  // Don't complain about different typedefs.
typedef NTSTATUS *PNTSTATUS;
/*lint -restore */  // Resume checking for different typedefs.

#endif

//
//  Status values are 32 bit values layed out as follows:
//
//   3 3 2 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1
//   1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
//  +---+-+-------------------------+-------------------------------+
//  |Sev|C|       Facility          |               Code            |
//  +---+-+-------------------------+-------------------------------+
//
//  where
//
//      Sev - is the severity code
//
//          00 - Success
//          01 - Informational
//          10 - Warning
//          11 - Error
//
//      C - is the Customer code flag
//
//      Facility - is the facility code
//
//      Code - is the facility's status code
//

//
// Generic test for success on any status value (non-negative numbers
// indicate success).
//

#define NT_SUCCESS(Status) ((_NTNATIVE_SELECT_NT(NTSTATUS))(Status) >= 0)

//
// Generic test for information on any status value.
//

#define NT_INFORMATION(Status) ((ULONG)(Status) >> 30 == 1)

//
// Generic test for warning on any status value.
//

#define NT_WARNING(Status) ((ULONG)(Status) >> 30 == 2)

//
// Generic test for error on any status value.
//

#define NT_ERROR(Status) ((ULONG)(Status) >> 30 == 3)

// end_windbgkd
// begin_winnt
#define APPLICATION_ERROR_MASK       0x20000000
#define ERROR_SEVERITY_SUCCESS       0x00000000
#define ERROR_SEVERITY_INFORMATIONAL 0x40000000
#define ERROR_SEVERITY_WARNING       0x80000000
#define ERROR_SEVERITY_ERROR         0xC0000000
// end_winnt

// end_ntndis
//
// Large (64-bit) integer types and operations
//

#define TIME LARGE_INTEGER
#define _TIME _LARGE_INTEGER
#define PTIME PLARGE_INTEGER
#define LowTime LowPart
#define HighTime HighPart

// begin_winnt

//
// _M_IX86 included so that EM CONTEXT structure compiles with
// x86 programs. *** TBD should this be for all architectures?
//

//
// 16 byte aligned type for 128 bit floats
//

//
// For we define a 128 bit structure and use __declspec(align(16)) pragma to
// align to 128 bits.
//

#ifndef _NTTYPES_NO_WINNT

#if defined(_M_IA64) && !defined(MIDL_PASS)
__declspec(align(16))
#endif
typedef struct _FLOAT128 {
    __int64 LowPart;
    __int64 HighPart;
} FLOAT128;

typedef FLOAT128 *PFLOAT128;

// end_winnt

#endif

#ifndef _NTTYPES_NO_WINNT


// begin_winnt begin_ntminiport begin_ntndis begin_ntminitape

//
// __int64 is only supported by 2.0 and later midl.
// __midl is set by the 2.0 midl and not by 1.0 midl.
//

#define _ULONGLONG_
#if (!defined (_MAC) && (!defined(MIDL_PASS) || defined(__midl)) && (!defined(_M_IX86) || (defined(_INTEGRAL_MAX_BITS) && _INTEGRAL_MAX_BITS >= 64)))
typedef __int64 LONGLONG;
typedef unsigned __int64 ULONGLONG;

#define MAXLONGLONG                      (0x7fffffffffffffff)
#else

#if defined(_MAC) && defined(_MAC_INT_64)
typedef __int64 LONGLONG;
typedef unsigned __int64 ULONGLONG;

#define MAXLONGLONG                      (0x7fffffffffffffff)
#else
typedef double LONGLONG;
typedef double ULONGLONG;
#endif //_MAC and int64

#endif

typedef LONGLONG *PLONGLONG;
typedef ULONGLONG *PULONGLONG;

// Update Sequence Number

typedef LONGLONG USN;

#if !defined(_NTTYPES_NO_NTDEF) && !defined(_NTTYPES_NO_WINNT) && !defined(__IDA__)

#if defined(MIDL_PASS)
typedef struct _LARGE_INTEGER {
#else // MIDL_PASS
typedef union _LARGE_INTEGER {
    struct {
        ULONG LowPart;
        LONG HighPart;
    };
    struct {
        ULONG LowPart;
        LONG HighPart;
    } u;
#endif //MIDL_PASS
    LONGLONG QuadPart;
} LARGE_INTEGER;

typedef LARGE_INTEGER *PLARGE_INTEGER;

#if defined(MIDL_PASS)
typedef struct _ULARGE_INTEGER {
#else // MIDL_PASS
typedef union _ULARGE_INTEGER {
    struct {
        ULONG LowPart;
        ULONG HighPart;
    };
    struct {
        ULONG LowPart;
        ULONG HighPart;
    } u;
#endif //MIDL_PASS
    ULONGLONG QuadPart;
} ULARGE_INTEGER;

typedef ULARGE_INTEGER *PULARGE_INTEGER;

#endif

// end_ntminiport end_ntndis end_ntminitape

#endif





#ifdef __IDA__

typedef struct _IO_COUNTERS { // Information Class 2
	LARGE_INTEGER ReadOperationCount;
	LARGE_INTEGER WriteOperationCount;
	LARGE_INTEGER OtherOperationCount;
	LARGE_INTEGER ReadTransferCount;
	LARGE_INTEGER WriteTransferCount;
	LARGE_INTEGER OtherTransferCount;
} IO_COUNTERS, *PIO_COUNTERS;

typedef struct _EXCEPTION_RECORD64 {
	DWORD    ExceptionCode;
	DWORD ExceptionFlags;
	DWORD64 ExceptionRecord;
	DWORD64 ExceptionAddress;
	DWORD NumberParameters;
	DWORD __unusedAlignment;
	DWORD64 ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS];
} EXCEPTION_RECORD64, *PEXCEPTION_RECORD64;

#endif






///////////////
// NTIMAGE.H //
///////////////

#ifndef _NTTYPES_NO_WINNT

//
// Image Format
//


#ifndef _MAC

#include "pshpack4.h"                   // 4 byte packing is the default

#define IMAGE_DOS_SIGNATURE                 0x5A4D      // MZ
#define IMAGE_OS2_SIGNATURE                 0x454E      // NE
#define IMAGE_OS2_SIGNATURE_LE              0x454C      // LE
#define IMAGE_VXD_SIGNATURE                 0x454C      // LE
#define IMAGE_NT_SIGNATURE                  0x00004550  // PE00

#include "pshpack2.h"                   // 16 bit headers are 2 byte packed

#else

#include "pshpack1.h"

#define IMAGE_DOS_SIGNATURE                 0x4D5A      // MZ
#define IMAGE_OS2_SIGNATURE                 0x4E45      // NE
#define IMAGE_OS2_SIGNATURE_LE              0x4C45      // LE
#define IMAGE_NT_SIGNATURE                  0x50450000  // PE00
#endif

typedef struct _IMAGE_DOS_HEADER {      // DOS .EXE header
	WORD   e_magic;                     // Magic number
	WORD   e_cblp;                      // Bytes on last page of file
	WORD   e_cp;                        // Pages in file
	WORD   e_crlc;                      // Relocations
	WORD   e_cparhdr;                   // Size of header in paragraphs
	WORD   e_minalloc;                  // Minimum extra paragraphs needed
	WORD   e_maxalloc;                  // Maximum extra paragraphs needed
	WORD   e_ss;                        // Initial (relative) SS value
	WORD   e_sp;                        // Initial SP value
	WORD   e_csum;                      // Checksum
	WORD   e_ip;                        // Initial IP value
	WORD   e_cs;                        // Initial (relative) CS value
	WORD   e_lfarlc;                    // File address of relocation table
	WORD   e_ovno;                      // Overlay number
	WORD   e_res[4];                    // Reserved words
	WORD   e_oemid;                     // OEM identifier (for e_oeminfo)
	WORD   e_oeminfo;                   // OEM information; e_oemid specific
	WORD   e_res2[10];                  // Reserved words
	LONG   e_lfanew;                    // File address of new exe header
} IMAGE_DOS_HEADER, *PIMAGE_DOS_HEADER;

typedef struct _IMAGE_OS2_HEADER {      // OS/2 .EXE header
	WORD   ne_magic;                    // Magic number
	CHAR   ne_ver;                      // Version number
	CHAR   ne_rev;                      // Revision number
	WORD   ne_enttab;                   // Offset of Entry Table
	WORD   ne_cbenttab;                 // Number of bytes in Entry Table
	LONG   ne_crc;                      // Checksum of whole file
	WORD   ne_flags;                    // Flag word
	WORD   ne_autodata;                 // Automatic data segment number
	WORD   ne_heap;                     // Initial heap allocation
	WORD   ne_stack;                    // Initial stack allocation
	LONG   ne_csip;                     // Initial CS:IP setting
	LONG   ne_sssp;                     // Initial SS:SP setting
	WORD   ne_cseg;                     // Count of file segments
	WORD   ne_cmod;                     // Entries in Module Reference Table
	WORD   ne_cbnrestab;                // Size of non-resident name table
	WORD   ne_segtab;                   // Offset of Segment Table
	WORD   ne_rsrctab;                  // Offset of Resource Table
	WORD   ne_restab;                   // Offset of resident name table
	WORD   ne_modtab;                   // Offset of Module Reference Table
	WORD   ne_imptab;                   // Offset of Imported Names Table
	LONG   ne_nrestab;                  // Offset of Non-resident Names Table
	WORD   ne_cmovent;                  // Count of movable entries
	WORD   ne_align;                    // Segment alignment shift count
	WORD   ne_cres;                     // Count of resource segments
	BYTE   ne_exetyp;                   // Target Operating system
	BYTE   ne_flagsothers;              // Other .EXE flags
	WORD   ne_pretthunks;               // offset to return thunks
	WORD   ne_psegrefbytes;             // offset to segment ref. bytes
	WORD   ne_swaparea;                 // Minimum code swap area size
	WORD   ne_expver;                   // Expected Windows version number
} IMAGE_OS2_HEADER, *PIMAGE_OS2_HEADER;

typedef struct _IMAGE_VXD_HEADER {      // Windows VXD header
	WORD   e32_magic;                   // Magic number
	BYTE   e32_border;                  // The byte ordering for the VXD
	BYTE   e32_worder;                  // The word ordering for the VXD
	DWORD  e32_level;                   // The EXE format level for now = 0
	WORD   e32_cpu;                     // The CPU type
	WORD   e32_os;                      // The OS type
	DWORD  e32_ver;                     // Module version
	DWORD  e32_mflags;                  // Module flags
	DWORD  e32_mpages;                  // Module # pages
	DWORD  e32_startobj;                // Object # for instruction pointer
	DWORD  e32_eip;                     // Extended instruction pointer
	DWORD  e32_stackobj;                // Object # for stack pointer
	DWORD  e32_esp;                     // Extended stack pointer
	DWORD  e32_pagesize;                // VXD page size
	DWORD  e32_lastpagesize;            // Last page size in VXD
	DWORD  e32_fixupsize;               // Fixup section size
	DWORD  e32_fixupsum;                // Fixup section checksum
	DWORD  e32_ldrsize;                 // Loader section size
	DWORD  e32_ldrsum;                  // Loader section checksum
	DWORD  e32_objtab;                  // Object table offset
	DWORD  e32_objcnt;                  // Number of objects in module
	DWORD  e32_objmap;                  // Object page map offset
	DWORD  e32_itermap;                 // Object iterated data map offset
	DWORD  e32_rsrctab;                 // Offset of Resource Table
	DWORD  e32_rsrccnt;                 // Number of resource entries
	DWORD  e32_restab;                  // Offset of resident name table
	DWORD  e32_enttab;                  // Offset of Entry Table
	DWORD  e32_dirtab;                  // Offset of Module Directive Table
	DWORD  e32_dircnt;                  // Number of module directives
	DWORD  e32_fpagetab;                // Offset of Fixup Page Table
	DWORD  e32_frectab;                 // Offset of Fixup Record Table
	DWORD  e32_impmod;                  // Offset of Import Module Name Table
	DWORD  e32_impmodcnt;               // Number of entries in Import Module Name Table
	DWORD  e32_impproc;                 // Offset of Import Procedure Name Table
	DWORD  e32_pagesum;                 // Offset of Per-Page Checksum Table
	DWORD  e32_datapage;                // Offset of Enumerated Data Pages
	DWORD  e32_preload;                 // Number of preload pages
	DWORD  e32_nrestab;                 // Offset of Non-resident Names Table
	DWORD  e32_cbnrestab;               // Size of Non-resident Name Table
	DWORD  e32_nressum;                 // Non-resident Name Table Checksum
	DWORD  e32_autodata;                // Object # for automatic data object
	DWORD  e32_debuginfo;               // Offset of the debugging information
	DWORD  e32_debuglen;                // The length of the debugging info. in bytes
	DWORD  e32_instpreload;             // Number of instance pages in preload section of VXD file
	DWORD  e32_instdemand;              // Number of instance pages in demand load section of VXD file
	DWORD  e32_heapsize;                // Size of heap - for 16-bit apps
	BYTE   e32_res3[12];                // Reserved words
	DWORD  e32_winresoff;
	DWORD  e32_winreslen;
	WORD   e32_devid;                   // Device ID for VxD
	WORD   e32_ddkver;                  // DDK version for VxD
} IMAGE_VXD_HEADER, *PIMAGE_VXD_HEADER;

#ifndef _MAC
#include "poppack.h"                    // Back to 4 byte packing
#endif

//
// File header format.
//

typedef struct _IMAGE_FILE_HEADER {
	WORD    Machine;
	WORD    NumberOfSections;
	DWORD   TimeDateStamp;
	DWORD   PointerToSymbolTable;
	DWORD   NumberOfSymbols;
	WORD    SizeOfOptionalHeader;
	WORD    Characteristics;
} IMAGE_FILE_HEADER, *PIMAGE_FILE_HEADER;

#define IMAGE_SIZEOF_FILE_HEADER             20


#define IMAGE_FILE_RELOCS_STRIPPED           0x0001  // Relocation info stripped from file.
#define IMAGE_FILE_EXECUTABLE_IMAGE          0x0002  // File is executable  (i.e. no unresolved externel references).
#define IMAGE_FILE_LINE_NUMS_STRIPPED        0x0004  // Line nunbers stripped from file.
#define IMAGE_FILE_LOCAL_SYMS_STRIPPED       0x0008  // Local symbols stripped from file.
#define IMAGE_FILE_AGGRESIVE_WS_TRIM         0x0010  // Agressively trim working set
#define IMAGE_FILE_LARGE_ADDRESS_AWARE       0x0020  // App can handle >2gb addresses
#define IMAGE_FILE_BYTES_REVERSED_LO         0x0080  // Bytes of machine word are reversed.
#define IMAGE_FILE_32BIT_MACHINE             0x0100  // 32 bit word machine.
#define IMAGE_FILE_DEBUG_STRIPPED            0x0200  // Debugging info stripped from file in .DBG file
#define IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP   0x0400  // If Image is on removable media, copy and run from the swap file.
#define IMAGE_FILE_NET_RUN_FROM_SWAP         0x0800  // If Image is on Net, copy and run from the swap file.
#define IMAGE_FILE_SYSTEM                    0x1000  // System File.
#define IMAGE_FILE_DLL                       0x2000  // File is a DLL.
#define IMAGE_FILE_UP_SYSTEM_ONLY            0x4000  // File should only be run on a UP machine
#define IMAGE_FILE_BYTES_REVERSED_HI         0x8000  // Bytes of machine word are reversed.

#define IMAGE_FILE_MACHINE_UNKNOWN           0
#define IMAGE_FILE_MACHINE_I386              0x014c  // Intel 386.
#define IMAGE_FILE_MACHINE_R3000             0x0162  // MIPS little-endian, 0x160 big-endian
#define IMAGE_FILE_MACHINE_R4000             0x0166  // MIPS little-endian
#define IMAGE_FILE_MACHINE_R10000            0x0168  // MIPS little-endian
#define IMAGE_FILE_MACHINE_WCEMIPSV2         0x0169  // MIPS little-endian WCE v2
#define IMAGE_FILE_MACHINE_ALPHA             0x0184  // Alpha_AXP
#define IMAGE_FILE_MACHINE_SH3               0x01a2  // SH3 little-endian
#define IMAGE_FILE_MACHINE_SH3DSP            0x01a3
#define IMAGE_FILE_MACHINE_SH3E              0x01a4  // SH3E little-endian
#define IMAGE_FILE_MACHINE_SH4               0x01a6  // SH4 little-endian
#define IMAGE_FILE_MACHINE_SH5               0x01a8  // SH5
#define IMAGE_FILE_MACHINE_ARM               0x01c0  // ARM Little-Endian
#define IMAGE_FILE_MACHINE_THUMB             0x01c2
#define IMAGE_FILE_MACHINE_AM33              0x01d3
#define IMAGE_FILE_MACHINE_POWERPC           0x01F0  // IBM PowerPC Little-Endian
#define IMAGE_FILE_MACHINE_POWERPCFP         0x01f1
#define IMAGE_FILE_MACHINE_IA64              0x0200  // Intel 64
#define IMAGE_FILE_MACHINE_MIPS16            0x0266  // MIPS
#define IMAGE_FILE_MACHINE_ALPHA64           0x0284  // ALPHA64
#define IMAGE_FILE_MACHINE_MIPSFPU           0x0366  // MIPS
#define IMAGE_FILE_MACHINE_MIPSFPU16         0x0466  // MIPS
#define IMAGE_FILE_MACHINE_AXP64             IMAGE_FILE_MACHINE_ALPHA64
#define IMAGE_FILE_MACHINE_TRICORE           0x0520  // Infineon
#define IMAGE_FILE_MACHINE_CEF               0x0CEF
#define IMAGE_FILE_MACHINE_EBC               0x0EBC  // EFI Byte Code
#define IMAGE_FILE_MACHINE_AMD64             0x8664  // AMD64 (K8)
#define IMAGE_FILE_MACHINE_M32R              0x9041  // M32R little-endian
#define IMAGE_FILE_MACHINE_CEE               0xC0EE

//
// Directory format.
//

typedef struct _IMAGE_DATA_DIRECTORY {
	DWORD   VirtualAddress;
	DWORD   Size;
} IMAGE_DATA_DIRECTORY, *PIMAGE_DATA_DIRECTORY;

#define IMAGE_NUMBEROF_DIRECTORY_ENTRIES    16

//
// Optional header format.
//

typedef struct _IMAGE_OPTIONAL_HEADER {
	//
	// Standard fields.
	//

	WORD    Magic;
	BYTE    MajorLinkerVersion;
	BYTE    MinorLinkerVersion;
	DWORD   SizeOfCode;
	DWORD   SizeOfInitializedData;
	DWORD   SizeOfUninitializedData;
	DWORD   AddressOfEntryPoint;
	DWORD   BaseOfCode;
	DWORD   BaseOfData;

	//
	// NT additional fields.
	//

	DWORD   ImageBase;
	DWORD   SectionAlignment;
	DWORD   FileAlignment;
	WORD    MajorOperatingSystemVersion;
	WORD    MinorOperatingSystemVersion;
	WORD    MajorImageVersion;
	WORD    MinorImageVersion;
	WORD    MajorSubsystemVersion;
	WORD    MinorSubsystemVersion;
	DWORD   Win32VersionValue;
	DWORD   SizeOfImage;
	DWORD   SizeOfHeaders;
	DWORD   CheckSum;
	WORD    Subsystem;
	WORD    DllCharacteristics;
	DWORD   SizeOfStackReserve;
	DWORD   SizeOfStackCommit;
	DWORD   SizeOfHeapReserve;
	DWORD   SizeOfHeapCommit;
	DWORD   LoaderFlags;
	DWORD   NumberOfRvaAndSizes;
	IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES];
} IMAGE_OPTIONAL_HEADER32, *PIMAGE_OPTIONAL_HEADER32;

typedef struct _IMAGE_ROM_OPTIONAL_HEADER {
	WORD   Magic;
	BYTE   MajorLinkerVersion;
	BYTE   MinorLinkerVersion;
	DWORD  SizeOfCode;
	DWORD  SizeOfInitializedData;
	DWORD  SizeOfUninitializedData;
	DWORD  AddressOfEntryPoint;
	DWORD  BaseOfCode;
	DWORD  BaseOfData;
	DWORD  BaseOfBss;
	DWORD  GprMask;
	DWORD  CprMask[4];
	DWORD  GpValue;
} IMAGE_ROM_OPTIONAL_HEADER, *PIMAGE_ROM_OPTIONAL_HEADER;

typedef struct _IMAGE_OPTIONAL_HEADER64 {
	WORD        Magic;
	BYTE        MajorLinkerVersion;
	BYTE        MinorLinkerVersion;
	DWORD       SizeOfCode;
	DWORD       SizeOfInitializedData;
	DWORD       SizeOfUninitializedData;
	DWORD       AddressOfEntryPoint;
	DWORD       BaseOfCode;
	ULONGLONG   ImageBase;
	DWORD       SectionAlignment;
	DWORD       FileAlignment;
	WORD        MajorOperatingSystemVersion;
	WORD        MinorOperatingSystemVersion;
	WORD        MajorImageVersion;
	WORD        MinorImageVersion;
	WORD        MajorSubsystemVersion;
	WORD        MinorSubsystemVersion;
	DWORD       Win32VersionValue;
	DWORD       SizeOfImage;
	DWORD       SizeOfHeaders;
	DWORD       CheckSum;
	WORD        Subsystem;
	WORD        DllCharacteristics;
	ULONGLONG   SizeOfStackReserve;
	ULONGLONG   SizeOfStackCommit;
	ULONGLONG   SizeOfHeapReserve;
	ULONGLONG   SizeOfHeapCommit;
	DWORD       LoaderFlags;
	DWORD       NumberOfRvaAndSizes;
	IMAGE_DATA_DIRECTORY DataDirectory[IMAGE_NUMBEROF_DIRECTORY_ENTRIES];
} IMAGE_OPTIONAL_HEADER64, *PIMAGE_OPTIONAL_HEADER64;

#define IMAGE_SIZEOF_ROM_OPTIONAL_HEADER      56
#define IMAGE_SIZEOF_STD_OPTIONAL_HEADER      28
#define IMAGE_SIZEOF_NT_OPTIONAL32_HEADER    224
#define IMAGE_SIZEOF_NT_OPTIONAL64_HEADER    240

#define IMAGE_NT_OPTIONAL_HDR32_MAGIC      0x10b
#define IMAGE_NT_OPTIONAL_HDR64_MAGIC      0x20b
#define IMAGE_ROM_OPTIONAL_HDR_MAGIC       0x107

#ifdef _WIN64
typedef IMAGE_OPTIONAL_HEADER64             IMAGE_OPTIONAL_HEADER;
typedef PIMAGE_OPTIONAL_HEADER64            PIMAGE_OPTIONAL_HEADER;
#define IMAGE_SIZEOF_NT_OPTIONAL_HEADER     IMAGE_SIZEOF_NT_OPTIONAL64_HEADER
#define IMAGE_NT_OPTIONAL_HDR_MAGIC         IMAGE_NT_OPTIONAL_HDR64_MAGIC
#else
typedef IMAGE_OPTIONAL_HEADER32             IMAGE_OPTIONAL_HEADER;
typedef PIMAGE_OPTIONAL_HEADER32            PIMAGE_OPTIONAL_HEADER;
#define IMAGE_SIZEOF_NT_OPTIONAL_HEADER     IMAGE_SIZEOF_NT_OPTIONAL32_HEADER
#define IMAGE_NT_OPTIONAL_HDR_MAGIC         IMAGE_NT_OPTIONAL_HDR32_MAGIC
#endif

typedef struct _IMAGE_NT_HEADERS64 {
	DWORD Signature;
	IMAGE_FILE_HEADER FileHeader;
	IMAGE_OPTIONAL_HEADER64 OptionalHeader;
} IMAGE_NT_HEADERS64, *PIMAGE_NT_HEADERS64;

typedef struct _IMAGE_NT_HEADERS {
	DWORD Signature;
	IMAGE_FILE_HEADER FileHeader;
	IMAGE_OPTIONAL_HEADER32 OptionalHeader;
} IMAGE_NT_HEADERS32, *PIMAGE_NT_HEADERS32;

typedef struct _IMAGE_ROM_HEADERS {
	IMAGE_FILE_HEADER FileHeader;
	IMAGE_ROM_OPTIONAL_HEADER OptionalHeader;
} IMAGE_ROM_HEADERS, *PIMAGE_ROM_HEADERS;

#ifdef _WIN64
typedef IMAGE_NT_HEADERS64                  IMAGE_NT_HEADERS;
typedef PIMAGE_NT_HEADERS64                 PIMAGE_NT_HEADERS;
#else
typedef IMAGE_NT_HEADERS32                  IMAGE_NT_HEADERS;
typedef PIMAGE_NT_HEADERS32                 PIMAGE_NT_HEADERS;
#endif

// IMAGE_FIRST_SECTION doesn't need 32/64 versions since the file header is the same either way.

#define IMAGE_FIRST_SECTION( ntheader ) ((PIMAGE_SECTION_HEADER)        \
	((ULONG_PTR)ntheader +                                              \
	FIELD_OFFSET( IMAGE_NT_HEADERS, OptionalHeader ) +                 \
	((PIMAGE_NT_HEADERS)(ntheader))->FileHeader.SizeOfOptionalHeader   \
	))

// Subsystem Values

#define IMAGE_SUBSYSTEM_UNKNOWN              0   // Unknown subsystem.
#define IMAGE_SUBSYSTEM_NATIVE               1   // Image doesn't require a subsystem.
#define IMAGE_SUBSYSTEM_WINDOWS_GUI          2   // Image runs in the Windows GUI subsystem.
#define IMAGE_SUBSYSTEM_WINDOWS_CUI          3   // Image runs in the Windows character subsystem.
#define IMAGE_SUBSYSTEM_OS2_CUI              5   // image runs in the OS/2 character subsystem.
#define IMAGE_SUBSYSTEM_POSIX_CUI            7   // image runs in the Posix character subsystem.
#define IMAGE_SUBSYSTEM_NATIVE_WINDOWS       8   // image is a native Win9x driver.
#define IMAGE_SUBSYSTEM_WINDOWS_CE_GUI       9   // Image runs in the Windows CE subsystem.
#define IMAGE_SUBSYSTEM_EFI_APPLICATION      10  //
#define IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER  11   //
#define IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER   12  //
#define IMAGE_SUBSYSTEM_EFI_ROM              13
#define IMAGE_SUBSYSTEM_XBOX                 14

// DllCharacteristics Entries

//      IMAGE_LIBRARY_PROCESS_INIT           0x0001     // Reserved.
//      IMAGE_LIBRARY_PROCESS_TERM           0x0002     // Reserved.
//      IMAGE_LIBRARY_THREAD_INIT            0x0004     // Reserved.
//      IMAGE_LIBRARY_THREAD_TERM            0x0008     // Reserved.
#define IMAGE_DLLCHARACTERISTICS_NO_ISOLATION 0x0200    // Image understands isolation and doesn't want it
#define IMAGE_DLLCHARACTERISTICS_NO_SEH      0x0400     // Image does not use SEH.  No SE handler may reside in this image
#define IMAGE_DLLCHARACTERISTICS_NO_BIND     0x0800     // Do not bind this image.
//                                           0x1000     // Reserved.
#define IMAGE_DLLCHARACTERISTICS_X86_THUNK   0x0001 // Image is a Wx86 Thunk DLL
#define IMAGE_DLLCHARACTERISTICS_WDM_DRIVER  0x2000     // Driver uses WDM model
//                                           0x4000     // Reserved.
#define IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE     0x8000

// LoaderFlags Values

#define IMAGE_LOADER_FLAGS_COMPLUS             0x00000001   // COM+ image
#define IMAGE_LOADER_FLAGS_SYSTEM_GLOBAL       0x01000000   // Global subsections apply across TS sessions.

// Directory Entries

#define IMAGE_DIRECTORY_ENTRY_EXPORT          0   // Export Directory
#define IMAGE_DIRECTORY_ENTRY_IMPORT          1   // Import Directory
#define IMAGE_DIRECTORY_ENTRY_RESOURCE        2   // Resource Directory
#define IMAGE_DIRECTORY_ENTRY_EXCEPTION       3   // Exception Directory
#define IMAGE_DIRECTORY_ENTRY_SECURITY        4   // Security Directory
#define IMAGE_DIRECTORY_ENTRY_BASERELOC       5   // Base Relocation Table
#define IMAGE_DIRECTORY_ENTRY_DEBUG           6   // Debug Directory
//      IMAGE_DIRECTORY_ENTRY_COPYRIGHT       7   // (X86 usage)
#define IMAGE_DIRECTORY_ENTRY_ARCHITECTURE    7   // Architecture Specific Data
#define IMAGE_DIRECTORY_ENTRY_GLOBALPTR       8   // RVA of GP
#define IMAGE_DIRECTORY_ENTRY_TLS             9   // TLS Directory
#define IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG    10   // Load Configuration Directory
#define IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT   11   // Bound Import Directory in headers
#define IMAGE_DIRECTORY_ENTRY_IAT            12   // Import Address Table
#define IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT   13   // Delay Load Import Descriptors
#define IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR 14   // COM Runtime descriptor

//
// Non-COFF Object file header
//

typedef struct ANON_OBJECT_HEADER {
	WORD    Sig1;            // Must be IMAGE_FILE_MACHINE_UNKNOWN
	WORD    Sig2;            // Must be 0xffff
	WORD    Version;         // >= 1 (implies the CLSID field is present)
	WORD    Machine;
	DWORD   TimeDateStamp;
	CLSID   ClassID;         // Used to invoke CoCreateInstance
	DWORD   SizeOfData;      // Size of data that follows the header
} ANON_OBJECT_HEADER;

//
// Section header format.
//

#define IMAGE_SIZEOF_SHORT_NAME              8

typedef struct _IMAGE_SECTION_HEADER {
	BYTE    Name[IMAGE_SIZEOF_SHORT_NAME];
	union {
		DWORD   PhysicalAddress;
		DWORD   VirtualSize;
	} Misc;
	DWORD   VirtualAddress;
	DWORD   SizeOfRawData;
	DWORD   PointerToRawData;
	DWORD   PointerToRelocations;
	DWORD   PointerToLinenumbers;
	WORD    NumberOfRelocations;
	WORD    NumberOfLinenumbers;
	DWORD   Characteristics;
} IMAGE_SECTION_HEADER, *PIMAGE_SECTION_HEADER;

#define IMAGE_SIZEOF_SECTION_HEADER          40

//
// Section characteristics.
//
//      IMAGE_SCN_TYPE_REG                   0x00000000  // Reserved.
//      IMAGE_SCN_TYPE_DSECT                 0x00000001  // Reserved.
//      IMAGE_SCN_TYPE_NOLOAD                0x00000002  // Reserved.
//      IMAGE_SCN_TYPE_GROUP                 0x00000004  // Reserved.
#define IMAGE_SCN_TYPE_NO_PAD                0x00000008  // Reserved.
//      IMAGE_SCN_TYPE_COPY                  0x00000010  // Reserved.

#define IMAGE_SCN_CNT_CODE                   0x00000020  // Section contains code.
#define IMAGE_SCN_CNT_INITIALIZED_DATA       0x00000040  // Section contains initialized data.
#define IMAGE_SCN_CNT_UNINITIALIZED_DATA     0x00000080  // Section contains uninitialized data.

#define IMAGE_SCN_LNK_OTHER                  0x00000100  // Reserved.
#define IMAGE_SCN_LNK_INFO                   0x00000200  // Section contains comments or some other type of information.
//      IMAGE_SCN_TYPE_OVER                  0x00000400  // Reserved.
#define IMAGE_SCN_LNK_REMOVE                 0x00000800  // Section contents will not become part of image.
#define IMAGE_SCN_LNK_COMDAT                 0x00001000  // Section contents comdat.
//                                           0x00002000  // Reserved.
//      IMAGE_SCN_MEM_PROTECTED - Obsolete   0x00004000
#define IMAGE_SCN_NO_DEFER_SPEC_EXC          0x00004000  // Reset speculative exceptions handling bits in the TLB entries for this section.
#define IMAGE_SCN_GPREL                      0x00008000  // Section content can be accessed relative to GP
#define IMAGE_SCN_MEM_FARDATA                0x00008000
//      IMAGE_SCN_MEM_SYSHEAP  - Obsolete    0x00010000
#define IMAGE_SCN_MEM_PURGEABLE              0x00020000
#define IMAGE_SCN_MEM_16BIT                  0x00020000
#define IMAGE_SCN_MEM_LOCKED                 0x00040000
#define IMAGE_SCN_MEM_PRELOAD                0x00080000

#define IMAGE_SCN_ALIGN_1BYTES               0x00100000  //
#define IMAGE_SCN_ALIGN_2BYTES               0x00200000  //
#define IMAGE_SCN_ALIGN_4BYTES               0x00300000  //
#define IMAGE_SCN_ALIGN_8BYTES               0x00400000  //
#define IMAGE_SCN_ALIGN_16BYTES              0x00500000  // Default alignment if no others are specified.
#define IMAGE_SCN_ALIGN_32BYTES              0x00600000  //
#define IMAGE_SCN_ALIGN_64BYTES              0x00700000  //
#define IMAGE_SCN_ALIGN_128BYTES             0x00800000  //
#define IMAGE_SCN_ALIGN_256BYTES             0x00900000  //
#define IMAGE_SCN_ALIGN_512BYTES             0x00A00000  //
#define IMAGE_SCN_ALIGN_1024BYTES            0x00B00000  //
#define IMAGE_SCN_ALIGN_2048BYTES            0x00C00000  //
#define IMAGE_SCN_ALIGN_4096BYTES            0x00D00000  //
#define IMAGE_SCN_ALIGN_8192BYTES            0x00E00000  //
// Unused                                    0x00F00000
#define IMAGE_SCN_ALIGN_MASK                 0x00F00000

#define IMAGE_SCN_LNK_NRELOC_OVFL            0x01000000  // Section contains extended relocations.
#define IMAGE_SCN_MEM_DISCARDABLE            0x02000000  // Section can be discarded.
#define IMAGE_SCN_MEM_NOT_CACHED             0x04000000  // Section is not cachable.
#define IMAGE_SCN_MEM_NOT_PAGED              0x08000000  // Section is not pageable.
#define IMAGE_SCN_MEM_SHARED                 0x10000000  // Section is shareable.
#define IMAGE_SCN_MEM_EXECUTE                0x20000000  // Section is executable.
#define IMAGE_SCN_MEM_READ                   0x40000000  // Section is readable.
#define IMAGE_SCN_MEM_WRITE                  0x80000000  // Section is writeable.

//
// TLS Chaacteristic Flags
//
#define IMAGE_SCN_SCALE_INDEX                0x00000001  // Tls index is scaled

#ifndef _MAC
#include "pshpack2.h"                       // Symbols, relocs, and linenumbers are 2 byte packed
#endif

//
// Symbol format.
//

typedef struct _IMAGE_SYMBOL {
	union {
		BYTE    ShortName[8];
		struct {
			DWORD   Short;     // if 0, use LongName
			DWORD   Long;      // offset into string table
		} Name;
		DWORD   LongName[2];    // PBYTE [2]
	} N;
	DWORD   Value;
	SHORT   SectionNumber;
	WORD    Type;
	BYTE    StorageClass;
	BYTE    NumberOfAuxSymbols;
} IMAGE_SYMBOL;
typedef IMAGE_SYMBOL UNALIGNED *PIMAGE_SYMBOL;


#define IMAGE_SIZEOF_SYMBOL                  18

//
// Section values.
//
// Symbols have a section number of the section in which they are
// defined. Otherwise, section numbers have the following meanings:
//

#define IMAGE_SYM_UNDEFINED           (SHORT)0          // Symbol is undefined or is common.
#define IMAGE_SYM_ABSOLUTE            (SHORT)-1         // Symbol is an absolute value.
#define IMAGE_SYM_DEBUG               (SHORT)-2         // Symbol is a special debug item.
#define IMAGE_SYM_SECTION_MAX         0xFEFF            // Values 0xFF00-0xFFFF are special

//
// Type (fundamental) values.
//

#define IMAGE_SYM_TYPE_NULL                 0x0000  // no type.
#define IMAGE_SYM_TYPE_VOID                 0x0001  //
#define IMAGE_SYM_TYPE_CHAR                 0x0002  // type character.
#define IMAGE_SYM_TYPE_SHORT                0x0003  // type short integer.
#define IMAGE_SYM_TYPE_INT                  0x0004  //
#define IMAGE_SYM_TYPE_LONG                 0x0005  //
#define IMAGE_SYM_TYPE_FLOAT                0x0006  //
#define IMAGE_SYM_TYPE_DOUBLE               0x0007  //
#define IMAGE_SYM_TYPE_STRUCT               0x0008  //
#define IMAGE_SYM_TYPE_UNION                0x0009  //
#define IMAGE_SYM_TYPE_ENUM                 0x000A  // enumeration.
#define IMAGE_SYM_TYPE_MOE                  0x000B  // member of enumeration.
#define IMAGE_SYM_TYPE_BYTE                 0x000C  //
#define IMAGE_SYM_TYPE_WORD                 0x000D  //
#define IMAGE_SYM_TYPE_UINT                 0x000E  //
#define IMAGE_SYM_TYPE_DWORD                0x000F  //
#define IMAGE_SYM_TYPE_PCODE                0x8000  //
//
// Type (derived) values.
//

#define IMAGE_SYM_DTYPE_NULL                0       // no derived type.
#define IMAGE_SYM_DTYPE_POINTER             1       // pointer.
#define IMAGE_SYM_DTYPE_FUNCTION            2       // function.
#define IMAGE_SYM_DTYPE_ARRAY               3       // array.

//
// Storage classes.
//
#define IMAGE_SYM_CLASS_END_OF_FUNCTION     (BYTE )-1
#define IMAGE_SYM_CLASS_NULL                0x0000
#define IMAGE_SYM_CLASS_AUTOMATIC           0x0001
#define IMAGE_SYM_CLASS_EXTERNAL            0x0002
#define IMAGE_SYM_CLASS_STATIC              0x0003
#define IMAGE_SYM_CLASS_REGISTER            0x0004
#define IMAGE_SYM_CLASS_EXTERNAL_DEF        0x0005
#define IMAGE_SYM_CLASS_LABEL               0x0006
#define IMAGE_SYM_CLASS_UNDEFINED_LABEL     0x0007
#define IMAGE_SYM_CLASS_MEMBER_OF_STRUCT    0x0008
#define IMAGE_SYM_CLASS_ARGUMENT            0x0009
#define IMAGE_SYM_CLASS_STRUCT_TAG          0x000A
#define IMAGE_SYM_CLASS_MEMBER_OF_UNION     0x000B
#define IMAGE_SYM_CLASS_UNION_TAG           0x000C
#define IMAGE_SYM_CLASS_TYPE_DEFINITION     0x000D
#define IMAGE_SYM_CLASS_UNDEFINED_STATIC    0x000E
#define IMAGE_SYM_CLASS_ENUM_TAG            0x000F
#define IMAGE_SYM_CLASS_MEMBER_OF_ENUM      0x0010
#define IMAGE_SYM_CLASS_REGISTER_PARAM      0x0011
#define IMAGE_SYM_CLASS_BIT_FIELD           0x0012

#define IMAGE_SYM_CLASS_FAR_EXTERNAL        0x0044  //

#define IMAGE_SYM_CLASS_BLOCK               0x0064
#define IMAGE_SYM_CLASS_FUNCTION            0x0065
#define IMAGE_SYM_CLASS_END_OF_STRUCT       0x0066
#define IMAGE_SYM_CLASS_FILE                0x0067
// new
#define IMAGE_SYM_CLASS_SECTION             0x0068
#define IMAGE_SYM_CLASS_WEAK_EXTERNAL       0x0069

#define IMAGE_SYM_CLASS_CLR_TOKEN           0x006B

// type packing constants

#define N_BTMASK                            0x000F
#define N_TMASK                             0x0030
#define N_TMASK1                            0x00C0
#define N_TMASK2                            0x00F0
#define N_BTSHFT                            4
#define N_TSHIFT                            2
// MACROS

// Basic Type of  x
#define BTYPE(x) ((x) & N_BTMASK)

// Is x a pointer?
#ifndef ISPTR
#define ISPTR(x) (((x) & N_TMASK) == (IMAGE_SYM_DTYPE_POINTER << N_BTSHFT))
#endif

// Is x a function?
#ifndef ISFCN
#define ISFCN(x) (((x) & N_TMASK) == (IMAGE_SYM_DTYPE_FUNCTION << N_BTSHFT))
#endif

// Is x an array?

#ifndef ISARY
#define ISARY(x) (((x) & N_TMASK) == (IMAGE_SYM_DTYPE_ARRAY << N_BTSHFT))
#endif

// Is x a structure, union, or enumeration TAG?
#ifndef ISTAG
#define ISTAG(x) ((x)==IMAGE_SYM_CLASS_STRUCT_TAG || (x)==IMAGE_SYM_CLASS_UNION_TAG || (x)==IMAGE_SYM_CLASS_ENUM_TAG)
#endif

#ifndef INCREF
#define INCREF(x) ((((x)&~N_BTMASK)<<N_TSHIFT)|(IMAGE_SYM_DTYPE_POINTER<<N_BTSHFT)|((x)&N_BTMASK))
#endif
#ifndef DECREF
#define DECREF(x) ((((x)>>N_TSHIFT)&~N_BTMASK)|((x)&N_BTMASK))
#endif

//
// Auxiliary entry format.
//

typedef union _IMAGE_AUX_SYMBOL {
	struct {
		DWORD    TagIndex;                      // struct, union, or enum tag index
		union {
			struct {
				WORD    Linenumber;             // declaration line number
				WORD    Size;                   // size of struct, union, or enum
			} LnSz;
			DWORD    TotalSize;
		} Misc;
		union {
			struct {                            // if ISFCN, tag, or .bb
				DWORD    PointerToLinenumber;
				DWORD    PointerToNextFunction;
			} Function;
			struct {                            // if ISARY, up to 4 dimen.
				WORD     Dimension[4];
			} Array;
		} FcnAry;
		WORD    TvIndex;                        // tv index
	} Sym;
	struct {
		BYTE    Name[IMAGE_SIZEOF_SYMBOL];
	} File;
	struct {
		DWORD   Length;                         // section length
		WORD    NumberOfRelocations;            // number of relocation entries
		WORD    NumberOfLinenumbers;            // number of line numbers
		DWORD   CheckSum;                       // checksum for communal
		SHORT   Number;                         // section number to associate with
		BYTE    Selection;                      // communal selection type
	} Section;
} IMAGE_AUX_SYMBOL;
typedef IMAGE_AUX_SYMBOL UNALIGNED *PIMAGE_AUX_SYMBOL;

#define IMAGE_SIZEOF_AUX_SYMBOL             18

typedef enum IMAGE_AUX_SYMBOL_TYPE {
	IMAGE_AUX_SYMBOL_TYPE_TOKEN_DEF = 1,
} IMAGE_AUX_SYMBOL_TYPE;

#include <pshpack2.h>

typedef struct _IMAGE_AUX_SYMBOL_TOKEN_DEF {
	BYTE  bAuxType;                  // IMAGE_AUX_SYMBOL_TYPE
	BYTE  bReserved;                 // Must be 0
	DWORD SymbolTableIndex;
	BYTE  rgbReserved[12];           // Must be 0
} IMAGE_AUX_SYMBOL_TOKEN_DEF;

typedef IMAGE_AUX_SYMBOL_TOKEN_DEF UNALIGNED *PIMAGE_AUX_SYMBOL_TOKEN_DEF;

#include <poppack.h>

//
// Communal selection types.
//

#define IMAGE_COMDAT_SELECT_NODUPLICATES    1
#define IMAGE_COMDAT_SELECT_ANY             2
#define IMAGE_COMDAT_SELECT_SAME_SIZE       3
#define IMAGE_COMDAT_SELECT_EXACT_MATCH     4
#define IMAGE_COMDAT_SELECT_ASSOCIATIVE     5
#define IMAGE_COMDAT_SELECT_LARGEST         6
#define IMAGE_COMDAT_SELECT_NEWEST          7

#define IMAGE_WEAK_EXTERN_SEARCH_NOLIBRARY  1
#define IMAGE_WEAK_EXTERN_SEARCH_LIBRARY    2
#define IMAGE_WEAK_EXTERN_SEARCH_ALIAS      3

//
// Relocation format.
//

typedef struct _IMAGE_RELOCATION {
	union {
		DWORD   VirtualAddress;
		DWORD   RelocCount;             // Set to the real count when IMAGE_SCN_LNK_NRELOC_OVFL is set
	};
	DWORD   SymbolTableIndex;
	WORD    Type;
} IMAGE_RELOCATION;
typedef IMAGE_RELOCATION UNALIGNED *PIMAGE_RELOCATION;

#define IMAGE_SIZEOF_RELOCATION         10

//
// I386 relocation types.
//
#define IMAGE_REL_I386_ABSOLUTE         0x0000  // Reference is absolute, no relocation is necessary
#define IMAGE_REL_I386_DIR16            0x0001  // Direct 16-bit reference to the symbols virtual address
#define IMAGE_REL_I386_REL16            0x0002  // PC-relative 16-bit reference to the symbols virtual address
#define IMAGE_REL_I386_DIR32            0x0006  // Direct 32-bit reference to the symbols virtual address
#define IMAGE_REL_I386_DIR32NB          0x0007  // Direct 32-bit reference to the symbols virtual address, base not included
#define IMAGE_REL_I386_SEG12            0x0009  // Direct 16-bit reference to the segment-selector bits of a 32-bit virtual address
#define IMAGE_REL_I386_SECTION          0x000A
#define IMAGE_REL_I386_SECREL           0x000B
#define IMAGE_REL_I386_TOKEN            0x000C  // clr token
#define IMAGE_REL_I386_SECREL7          0x000D  // 7 bit offset from base of section containing target
#define IMAGE_REL_I386_REL32            0x0014  // PC-relative 32-bit reference to the symbols virtual address

//
// MIPS relocation types.
//
#define IMAGE_REL_MIPS_ABSOLUTE         0x0000  // Reference is absolute, no relocation is necessary
#define IMAGE_REL_MIPS_REFHALF          0x0001
#define IMAGE_REL_MIPS_REFWORD          0x0002
#define IMAGE_REL_MIPS_JMPADDR          0x0003
#define IMAGE_REL_MIPS_REFHI            0x0004
#define IMAGE_REL_MIPS_REFLO            0x0005
#define IMAGE_REL_MIPS_GPREL            0x0006
#define IMAGE_REL_MIPS_LITERAL          0x0007
#define IMAGE_REL_MIPS_SECTION          0x000A
#define IMAGE_REL_MIPS_SECREL           0x000B
#define IMAGE_REL_MIPS_SECRELLO         0x000C  // Low 16-bit section relative referemce (used for >32k TLS)
#define IMAGE_REL_MIPS_SECRELHI         0x000D  // High 16-bit section relative reference (used for >32k TLS)
#define IMAGE_REL_MIPS_TOKEN            0x000E  // clr token
#define IMAGE_REL_MIPS_JMPADDR16        0x0010
#define IMAGE_REL_MIPS_REFWORDNB        0x0022
#define IMAGE_REL_MIPS_PAIR             0x0025

//
// Alpha Relocation types.
//
#define IMAGE_REL_ALPHA_ABSOLUTE        0x0000
#define IMAGE_REL_ALPHA_REFLONG         0x0001
#define IMAGE_REL_ALPHA_REFQUAD         0x0002
#define IMAGE_REL_ALPHA_GPREL32         0x0003
#define IMAGE_REL_ALPHA_LITERAL         0x0004
#define IMAGE_REL_ALPHA_LITUSE          0x0005
#define IMAGE_REL_ALPHA_GPDISP          0x0006
#define IMAGE_REL_ALPHA_BRADDR          0x0007
#define IMAGE_REL_ALPHA_HINT            0x0008
#define IMAGE_REL_ALPHA_INLINE_REFLONG  0x0009
#define IMAGE_REL_ALPHA_REFHI           0x000A
#define IMAGE_REL_ALPHA_REFLO           0x000B
#define IMAGE_REL_ALPHA_PAIR            0x000C
#define IMAGE_REL_ALPHA_MATCH           0x000D
#define IMAGE_REL_ALPHA_SECTION         0x000E
#define IMAGE_REL_ALPHA_SECREL          0x000F
#define IMAGE_REL_ALPHA_REFLONGNB       0x0010
#define IMAGE_REL_ALPHA_SECRELLO        0x0011  // Low 16-bit section relative reference
#define IMAGE_REL_ALPHA_SECRELHI        0x0012  // High 16-bit section relative reference
#define IMAGE_REL_ALPHA_REFQ3           0x0013  // High 16 bits of 48 bit reference
#define IMAGE_REL_ALPHA_REFQ2           0x0014  // Middle 16 bits of 48 bit reference
#define IMAGE_REL_ALPHA_REFQ1           0x0015  // Low 16 bits of 48 bit reference
#define IMAGE_REL_ALPHA_GPRELLO         0x0016  // Low 16-bit GP relative reference
#define IMAGE_REL_ALPHA_GPRELHI         0x0017  // High 16-bit GP relative reference

//
// IBM PowerPC relocation types.
//
#define IMAGE_REL_PPC_ABSOLUTE          0x0000  // NOP
#define IMAGE_REL_PPC_ADDR64            0x0001  // 64-bit address
#define IMAGE_REL_PPC_ADDR32            0x0002  // 32-bit address
#define IMAGE_REL_PPC_ADDR24            0x0003  // 26-bit address, shifted left 2 (branch absolute)
#define IMAGE_REL_PPC_ADDR16            0x0004  // 16-bit address
#define IMAGE_REL_PPC_ADDR14            0x0005  // 16-bit address, shifted left 2 (load doubleword)
#define IMAGE_REL_PPC_REL24             0x0006  // 26-bit PC-relative offset, shifted left 2 (branch relative)
#define IMAGE_REL_PPC_REL14             0x0007  // 16-bit PC-relative offset, shifted left 2 (br cond relative)
#define IMAGE_REL_PPC_TOCREL16          0x0008  // 16-bit offset from TOC base
#define IMAGE_REL_PPC_TOCREL14          0x0009  // 16-bit offset from TOC base, shifted left 2 (load doubleword)

#define IMAGE_REL_PPC_ADDR32NB          0x000A  // 32-bit addr w/o image base
#define IMAGE_REL_PPC_SECREL            0x000B  // va of containing section (as in an image sectionhdr)
#define IMAGE_REL_PPC_SECTION           0x000C  // sectionheader number
#define IMAGE_REL_PPC_IFGLUE            0x000D  // substitute TOC restore instruction iff symbol is glue code
#define IMAGE_REL_PPC_IMGLUE            0x000E  // symbol is glue code; virtual address is TOC restore instruction
#define IMAGE_REL_PPC_SECREL16          0x000F  // va of containing section (limited to 16 bits)
#define IMAGE_REL_PPC_REFHI             0x0010
#define IMAGE_REL_PPC_REFLO             0x0011
#define IMAGE_REL_PPC_PAIR              0x0012
#define IMAGE_REL_PPC_SECRELLO          0x0013  // Low 16-bit section relative reference (used for >32k TLS)
#define IMAGE_REL_PPC_SECRELHI          0x0014  // High 16-bit section relative reference (used for >32k TLS)
#define IMAGE_REL_PPC_GPREL             0x0015
#define IMAGE_REL_PPC_TOKEN             0x0016  // clr token

#define IMAGE_REL_PPC_TYPEMASK          0x00FF  // mask to isolate above values in IMAGE_RELOCATION.Type

// Flag bits in IMAGE_RELOCATION.TYPE

#define IMAGE_REL_PPC_NEG               0x0100  // subtract reloc value rather than adding it
#define IMAGE_REL_PPC_BRTAKEN           0x0200  // fix branch prediction bit to predict branch taken
#define IMAGE_REL_PPC_BRNTAKEN          0x0400  // fix branch prediction bit to predict branch not taken
#define IMAGE_REL_PPC_TOCDEFN           0x0800  // toc slot defined in file (or, data in toc)

//
// Hitachi SH3 relocation types.
//
#define IMAGE_REL_SH3_ABSOLUTE          0x0000  // No relocation
#define IMAGE_REL_SH3_DIRECT16          0x0001  // 16 bit direct
#define IMAGE_REL_SH3_DIRECT32          0x0002  // 32 bit direct
#define IMAGE_REL_SH3_DIRECT8           0x0003  // 8 bit direct, -128..255
#define IMAGE_REL_SH3_DIRECT8_WORD      0x0004  // 8 bit direct .W (0 ext.)
#define IMAGE_REL_SH3_DIRECT8_LONG      0x0005  // 8 bit direct .L (0 ext.)
#define IMAGE_REL_SH3_DIRECT4           0x0006  // 4 bit direct (0 ext.)
#define IMAGE_REL_SH3_DIRECT4_WORD      0x0007  // 4 bit direct .W (0 ext.)
#define IMAGE_REL_SH3_DIRECT4_LONG      0x0008  // 4 bit direct .L (0 ext.)
#define IMAGE_REL_SH3_PCREL8_WORD       0x0009  // 8 bit PC relative .W
#define IMAGE_REL_SH3_PCREL8_LONG       0x000A  // 8 bit PC relative .L
#define IMAGE_REL_SH3_PCREL12_WORD      0x000B  // 12 LSB PC relative .W
#define IMAGE_REL_SH3_STARTOF_SECTION   0x000C  // Start of EXE section
#define IMAGE_REL_SH3_SIZEOF_SECTION    0x000D  // Size of EXE section
#define IMAGE_REL_SH3_SECTION           0x000E  // Section table index
#define IMAGE_REL_SH3_SECREL            0x000F  // Offset within section
#define IMAGE_REL_SH3_DIRECT32_NB       0x0010  // 32 bit direct not based
#define IMAGE_REL_SH3_GPREL4_LONG       0x0011  // GP-relative addressing
#define IMAGE_REL_SH3_TOKEN             0x0012  // clr token

#define IMAGE_REL_ARM_ABSOLUTE          0x0000  // No relocation required
#define IMAGE_REL_ARM_ADDR32            0x0001  // 32 bit address
#define IMAGE_REL_ARM_ADDR32NB          0x0002  // 32 bit address w/o image base
#define IMAGE_REL_ARM_BRANCH24          0x0003  // 24 bit offset << 2 & sign ext.
#define IMAGE_REL_ARM_BRANCH11          0x0004  // Thumb: 2 11 bit offsets
#define IMAGE_REL_ARM_TOKEN             0x0005  // clr token
#define IMAGE_REL_ARM_GPREL12           0x0006  // GP-relative addressing (ARM)
#define IMAGE_REL_ARM_GPREL7            0x0007  // GP-relative addressing (Thumb)
#define IMAGE_REL_ARM_BLX24             0x0008
#define IMAGE_REL_ARM_BLX11             0x0009
#define IMAGE_REL_ARM_SECTION           0x000E  // Section table index
#define IMAGE_REL_ARM_SECREL            0x000F  // Offset within section

#define IMAGE_REL_AM_ABSOLUTE           0x0000
#define IMAGE_REL_AM_ADDR32             0x0001
#define IMAGE_REL_AM_ADDR32NB           0x0002
#define IMAGE_REL_AM_CALL32             0x0003
#define IMAGE_REL_AM_FUNCINFO           0x0004
#define IMAGE_REL_AM_REL32_1            0x0005
#define IMAGE_REL_AM_REL32_2            0x0006
#define IMAGE_REL_AM_SECREL             0x0007
#define IMAGE_REL_AM_SECTION            0x0008
#define IMAGE_REL_AM_TOKEN              0x0009

//
// X86-64 relocations
//
#define IMAGE_REL_AMD64_ABSOLUTE        0x0000  // Reference is absolute, no relocation is necessary
#define IMAGE_REL_AMD64_ADDR64          0x0001  // 64-bit address (VA).
#define IMAGE_REL_AMD64_ADDR32          0x0002  // 32-bit address (VA).
#define IMAGE_REL_AMD64_ADDR32NB        0x0003  // 32-bit address w/o image base (RVA).
#define IMAGE_REL_AMD64_REL32           0x0004  // 32-bit relative address from byte following reloc
#define IMAGE_REL_AMD64_REL32_1         0x0005  // 32-bit relative address from byte distance 1 from reloc
#define IMAGE_REL_AMD64_REL32_2         0x0006  // 32-bit relative address from byte distance 2 from reloc
#define IMAGE_REL_AMD64_REL32_3         0x0007  // 32-bit relative address from byte distance 3 from reloc
#define IMAGE_REL_AMD64_REL32_4         0x0008  // 32-bit relative address from byte distance 4 from reloc
#define IMAGE_REL_AMD64_REL32_5         0x0009  // 32-bit relative address from byte distance 5 from reloc
#define IMAGE_REL_AMD64_SECTION         0x000A  // Section index
#define IMAGE_REL_AMD64_SECREL          0x000B  // 32 bit offset from base of section containing target
#define IMAGE_REL_AMD64_SECREL7         0x000C  // 7 bit unsigned offset from base of section containing target
#define IMAGE_REL_AMD64_TOKEN           0x000D  // 32 bit metadata token

//
// IA64 relocation types.
//
#define IMAGE_REL_IA64_ABSOLUTE         0x0000
#define IMAGE_REL_IA64_IMM14            0x0001
#define IMAGE_REL_IA64_IMM22            0x0002
#define IMAGE_REL_IA64_IMM64            0x0003
#define IMAGE_REL_IA64_DIR32            0x0004
#define IMAGE_REL_IA64_DIR64            0x0005
#define IMAGE_REL_IA64_PCREL21B         0x0006
#define IMAGE_REL_IA64_PCREL21M         0x0007
#define IMAGE_REL_IA64_PCREL21F         0x0008
#define IMAGE_REL_IA64_GPREL22          0x0009
#define IMAGE_REL_IA64_LTOFF22          0x000A
#define IMAGE_REL_IA64_SECTION          0x000B
#define IMAGE_REL_IA64_SECREL22         0x000C
#define IMAGE_REL_IA64_SECREL64I        0x000D
#define IMAGE_REL_IA64_SECREL32         0x000E
// 
#define IMAGE_REL_IA64_DIR32NB          0x0010
#define IMAGE_REL_IA64_SREL14           0x0011
#define IMAGE_REL_IA64_SREL22           0x0012
#define IMAGE_REL_IA64_SREL32           0x0013
#define IMAGE_REL_IA64_UREL32           0x0014
#define IMAGE_REL_IA64_PCREL60X         0x0015  // This is always a BRL and never converted
#define IMAGE_REL_IA64_PCREL60B         0x0016  // If possible, convert to MBB bundle with NOP.B in slot 1
#define IMAGE_REL_IA64_PCREL60F         0x0017  // If possible, convert to MFB bundle with NOP.F in slot 1
#define IMAGE_REL_IA64_PCREL60I         0x0018  // If possible, convert to MIB bundle with NOP.I in slot 1
#define IMAGE_REL_IA64_PCREL60M         0x0019  // If possible, convert to MMB bundle with NOP.M in slot 1
#define IMAGE_REL_IA64_IMMGPREL64       0x001A
#define IMAGE_REL_IA64_TOKEN            0x001B  // clr token
#define IMAGE_REL_IA64_GPREL32          0x001C
#define IMAGE_REL_IA64_ADDEND           0x001F

//
// CEF relocation types.
//
#define IMAGE_REL_CEF_ABSOLUTE          0x0000  // Reference is absolute, no relocation is necessary
#define IMAGE_REL_CEF_ADDR32            0x0001  // 32-bit address (VA).
#define IMAGE_REL_CEF_ADDR64            0x0002  // 64-bit address (VA).
#define IMAGE_REL_CEF_ADDR32NB          0x0003  // 32-bit address w/o image base (RVA).
#define IMAGE_REL_CEF_SECTION           0x0004  // Section index
#define IMAGE_REL_CEF_SECREL            0x0005  // 32 bit offset from base of section containing target
#define IMAGE_REL_CEF_TOKEN             0x0006  // 32 bit metadata token

//
// clr relocation types.
//
#define IMAGE_REL_CEE_ABSOLUTE          0x0000  // Reference is absolute, no relocation is necessary
#define IMAGE_REL_CEE_ADDR32            0x0001  // 32-bit address (VA).
#define IMAGE_REL_CEE_ADDR64            0x0002  // 64-bit address (VA).
#define IMAGE_REL_CEE_ADDR32NB          0x0003  // 32-bit address w/o image base (RVA).
#define IMAGE_REL_CEE_SECTION           0x0004  // Section index
#define IMAGE_REL_CEE_SECREL            0x0005  // 32 bit offset from base of section containing target
#define IMAGE_REL_CEE_TOKEN             0x0006  // 32 bit metadata token


#define IMAGE_REL_M32R_ABSOLUTE       0x0000   // No relocation required
#define IMAGE_REL_M32R_ADDR32         0x0001   // 32 bit address
#define IMAGE_REL_M32R_ADDR32NB       0x0002   // 32 bit address w/o image base
#define IMAGE_REL_M32R_ADDR24         0x0003   // 24 bit address
#define IMAGE_REL_M32R_GPREL16        0x0004   // GP relative addressing
#define IMAGE_REL_M32R_PCREL24        0x0005   // 24 bit offset << 2 & sign ext.
#define IMAGE_REL_M32R_PCREL16        0x0006   // 16 bit offset << 2 & sign ext.
#define IMAGE_REL_M32R_PCREL8         0x0007   // 8 bit offset << 2 & sign ext.
#define IMAGE_REL_M32R_REFHALF        0x0008   // 16 MSBs
#define IMAGE_REL_M32R_REFHI          0x0009   // 16 MSBs; adj for LSB sign ext.
#define IMAGE_REL_M32R_REFLO          0x000A   // 16 LSBs
#define IMAGE_REL_M32R_PAIR           0x000B   // Link HI and LO
#define IMAGE_REL_M32R_SECTION        0x000C   // Section table index
#define IMAGE_REL_M32R_SECREL32       0x000D   // 32 bit section relative reference
#define IMAGE_REL_M32R_TOKEN          0x000E   // clr token


#define EXT_IMM64(Value, Address, Size, InstPos, ValPos)  /* Intel-IA64-Filler */           \
	Value |= (((ULONGLONG)((*(Address) >> InstPos) & (((ULONGLONG)1 << Size) - 1))) << ValPos)  // Intel-IA64-Filler

#define INS_IMM64(Value, Address, Size, InstPos, ValPos)  /* Intel-IA64-Filler */\
	*(PDWORD)Address = (*(PDWORD)Address & ~(((1 << Size) - 1) << InstPos)) | /* Intel-IA64-Filler */\
	((DWORD)((((ULONGLONG)Value >> ValPos) & (((ULONGLONG)1 << Size) - 1))) << InstPos)  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IMM7B_INST_WORD_X         3  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM7B_SIZE_X              7  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM7B_INST_WORD_POS_X     4  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM7B_VAL_POS_X           0  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IMM9D_INST_WORD_X         3  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM9D_SIZE_X              9  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM9D_INST_WORD_POS_X     18  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM9D_VAL_POS_X           7  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IMM5C_INST_WORD_X         3  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM5C_SIZE_X              5  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM5C_INST_WORD_POS_X     13  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM5C_VAL_POS_X           16  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IC_INST_WORD_X            3  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IC_SIZE_X                 1  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IC_INST_WORD_POS_X        12  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IC_VAL_POS_X              21  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IMM41a_INST_WORD_X        1  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41a_SIZE_X             10  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41a_INST_WORD_POS_X    14  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41a_VAL_POS_X          22  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IMM41b_INST_WORD_X        1  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41b_SIZE_X             8  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41b_INST_WORD_POS_X    24  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41b_VAL_POS_X          32  // Intel-IA64-Filler

#define EMARCH_ENC_I17_IMM41c_INST_WORD_X        2  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41c_SIZE_X             23  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41c_INST_WORD_POS_X    0  // Intel-IA64-Filler
#define EMARCH_ENC_I17_IMM41c_VAL_POS_X          40  // Intel-IA64-Filler

#define EMARCH_ENC_I17_SIGN_INST_WORD_X          3  // Intel-IA64-Filler
#define EMARCH_ENC_I17_SIGN_SIZE_X               1  // Intel-IA64-Filler
#define EMARCH_ENC_I17_SIGN_INST_WORD_POS_X      27  // Intel-IA64-Filler
#define EMARCH_ENC_I17_SIGN_VAL_POS_X            63  // Intel-IA64-Filler


//
// Line number format.
//

typedef struct _IMAGE_LINENUMBER {
	union {
		DWORD   SymbolTableIndex;               // Symbol table index of function name if Linenumber is 0.
		DWORD   VirtualAddress;                 // Virtual address of line number.
	} Type;
	WORD    Linenumber;                         // Line number.
} IMAGE_LINENUMBER;
typedef IMAGE_LINENUMBER UNALIGNED *PIMAGE_LINENUMBER;

#define IMAGE_SIZEOF_LINENUMBER              6

#ifndef _MAC
#include "poppack.h"                        // Back to 4 byte packing
#endif

//
// Based relocation format.
//

typedef struct _IMAGE_BASE_RELOCATION {
	DWORD   VirtualAddress;
	DWORD   SizeOfBlock;
	//  WORD    TypeOffset[1];
} IMAGE_BASE_RELOCATION;
typedef IMAGE_BASE_RELOCATION UNALIGNED * PIMAGE_BASE_RELOCATION;

#define IMAGE_SIZEOF_BASE_RELOCATION         8

//
// Based relocation types.
//

#define IMAGE_REL_BASED_ABSOLUTE              0
#define IMAGE_REL_BASED_HIGH                  1
#define IMAGE_REL_BASED_LOW                   2
#define IMAGE_REL_BASED_HIGHLOW               3
#define IMAGE_REL_BASED_HIGHADJ               4
#define IMAGE_REL_BASED_MIPS_JMPADDR          5
#define IMAGE_REL_BASED_SECTION               6
#define IMAGE_REL_BASED_REL32                 7
#define IMAGE_REL_BASED_MIPS_JMPADDR16        9
#define IMAGE_REL_BASED_IA64_IMM64            9
#define IMAGE_REL_BASED_DIR64                 10
#define IMAGE_REL_BASED_HIGH3ADJ              11


//
// Archive format.
//

#define IMAGE_ARCHIVE_START_SIZE             8
#define IMAGE_ARCHIVE_START                  "!<arch>\n"
#define IMAGE_ARCHIVE_END                    "`\n"
#define IMAGE_ARCHIVE_PAD                    "\n"
#define IMAGE_ARCHIVE_LINKER_MEMBER          "/               "
#define IMAGE_ARCHIVE_LONGNAMES_MEMBER       "//              "

typedef struct _IMAGE_ARCHIVE_MEMBER_HEADER {
	BYTE     Name[16];                          // File member name - `/' terminated.
	BYTE     Date[12];                          // File member date - decimal.
	BYTE     UserID[6];                         // File member user id - decimal.
	BYTE     GroupID[6];                        // File member group id - decimal.
	BYTE     Mode[8];                           // File member mode - octal.
	BYTE     Size[10];                          // File member size - decimal.
	BYTE     EndHeader[2];                      // String to end header.
} IMAGE_ARCHIVE_MEMBER_HEADER, *PIMAGE_ARCHIVE_MEMBER_HEADER;

#define IMAGE_SIZEOF_ARCHIVE_MEMBER_HDR      60

//
// DLL support.
//

//
// Export Format
//

typedef struct _IMAGE_EXPORT_DIRECTORY {
	DWORD   Characteristics;
	DWORD   TimeDateStamp;
	WORD    MajorVersion;
	WORD    MinorVersion;
	DWORD   Name;
	DWORD   Base;
	DWORD   NumberOfFunctions;
	DWORD   NumberOfNames;
	DWORD   AddressOfFunctions;     // RVA from base of image
	DWORD   AddressOfNames;         // RVA from base of image
	DWORD   AddressOfNameOrdinals;  // RVA from base of image
} IMAGE_EXPORT_DIRECTORY, *PIMAGE_EXPORT_DIRECTORY;

//
// Import Format
//

typedef struct _IMAGE_IMPORT_BY_NAME {
	WORD    Hint;
	BYTE    Name[1];
} IMAGE_IMPORT_BY_NAME, *PIMAGE_IMPORT_BY_NAME;

#include "pshpack8.h"                       // Use align 8 for the 64-bit IAT.

typedef struct _IMAGE_THUNK_DATA64 {
	union {
		ULONGLONG ForwarderString;  // PBYTE 
		ULONGLONG Function;         // PDWORD
		ULONGLONG Ordinal;
		ULONGLONG AddressOfData;    // PIMAGE_IMPORT_BY_NAME
	} u1;
} IMAGE_THUNK_DATA64;
typedef IMAGE_THUNK_DATA64 * PIMAGE_THUNK_DATA64;

#include "poppack.h"                        // Back to 4 byte packing

typedef struct _IMAGE_THUNK_DATA32 {
	union {
		DWORD ForwarderString;      // PBYTE 
		DWORD Function;             // PDWORD
		DWORD Ordinal;
		DWORD AddressOfData;        // PIMAGE_IMPORT_BY_NAME
	} u1;
} IMAGE_THUNK_DATA32;
typedef IMAGE_THUNK_DATA32 * PIMAGE_THUNK_DATA32;

#define IMAGE_ORDINAL_FLAG64 0x8000000000000000
#define IMAGE_ORDINAL_FLAG32 0x80000000
#define IMAGE_ORDINAL64(Ordinal) (Ordinal & 0xffff)
#define IMAGE_ORDINAL32(Ordinal) (Ordinal & 0xffff)
#define IMAGE_SNAP_BY_ORDINAL64(Ordinal) ((Ordinal & IMAGE_ORDINAL_FLAG64) != 0)
#define IMAGE_SNAP_BY_ORDINAL32(Ordinal) ((Ordinal & IMAGE_ORDINAL_FLAG32) != 0)

//
// Thread Local Storage
//

typedef VOID
(NTAPI *PIMAGE_TLS_CALLBACK) (
							  PVOID DllHandle,
							  DWORD Reason,
							  PVOID Reserved
							  );

typedef struct _IMAGE_TLS_DIRECTORY64 {
	ULONGLONG   StartAddressOfRawData;
	ULONGLONG   EndAddressOfRawData;
	ULONGLONG   AddressOfIndex;         // PDWORD
	ULONGLONG   AddressOfCallBacks;     // PIMAGE_TLS_CALLBACK *;
	DWORD   SizeOfZeroFill;
	DWORD   Characteristics;
} IMAGE_TLS_DIRECTORY64;
typedef IMAGE_TLS_DIRECTORY64 * PIMAGE_TLS_DIRECTORY64;

typedef struct _IMAGE_TLS_DIRECTORY32 {
	DWORD   StartAddressOfRawData;
	DWORD   EndAddressOfRawData;
	DWORD   AddressOfIndex;             // PDWORD
	DWORD   AddressOfCallBacks;         // PIMAGE_TLS_CALLBACK *
	DWORD   SizeOfZeroFill;
	DWORD   Characteristics;
} IMAGE_TLS_DIRECTORY32;
typedef IMAGE_TLS_DIRECTORY32 * PIMAGE_TLS_DIRECTORY32;

#ifdef _WIN64
#define IMAGE_ORDINAL_FLAG              IMAGE_ORDINAL_FLAG64
#define IMAGE_ORDINAL(Ordinal)          IMAGE_ORDINAL64(Ordinal)
typedef IMAGE_THUNK_DATA64              IMAGE_THUNK_DATA;
typedef PIMAGE_THUNK_DATA64             PIMAGE_THUNK_DATA;
#define IMAGE_SNAP_BY_ORDINAL(Ordinal)  IMAGE_SNAP_BY_ORDINAL64(Ordinal)
typedef IMAGE_TLS_DIRECTORY64           IMAGE_TLS_DIRECTORY;
typedef PIMAGE_TLS_DIRECTORY64          PIMAGE_TLS_DIRECTORY;
#else
#define IMAGE_ORDINAL_FLAG              IMAGE_ORDINAL_FLAG32
#define IMAGE_ORDINAL(Ordinal)          IMAGE_ORDINAL32(Ordinal)
typedef IMAGE_THUNK_DATA32              IMAGE_THUNK_DATA;
typedef PIMAGE_THUNK_DATA32             PIMAGE_THUNK_DATA;
#define IMAGE_SNAP_BY_ORDINAL(Ordinal)  IMAGE_SNAP_BY_ORDINAL32(Ordinal)
typedef IMAGE_TLS_DIRECTORY32           IMAGE_TLS_DIRECTORY;
typedef PIMAGE_TLS_DIRECTORY32          PIMAGE_TLS_DIRECTORY;
#endif

typedef struct _IMAGE_IMPORT_DESCRIPTOR {
	union {
		DWORD   Characteristics;            // 0 for terminating null import descriptor
		DWORD   OriginalFirstThunk;         // RVA to original unbound IAT (PIMAGE_THUNK_DATA)
	};
	DWORD   TimeDateStamp;                  // 0 if not bound,
	// -1 if bound, and real date\time stamp
	//     in IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT (new BIND)
	// O.W. date/time stamp of DLL bound to (Old BIND)

	DWORD   ForwarderChain;                 // -1 if no forwarders
	DWORD   Name;
	DWORD   FirstThunk;                     // RVA to IAT (if bound this IAT has actual addresses)
} IMAGE_IMPORT_DESCRIPTOR;
typedef IMAGE_IMPORT_DESCRIPTOR UNALIGNED *PIMAGE_IMPORT_DESCRIPTOR;

//
// New format import descriptors pointed to by DataDirectory[ IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT ]
//

typedef struct _IMAGE_BOUND_IMPORT_DESCRIPTOR {
	DWORD   TimeDateStamp;
	WORD    OffsetModuleName;
	WORD    NumberOfModuleForwarderRefs;
	// Array of zero or more IMAGE_BOUND_FORWARDER_REF follows
} IMAGE_BOUND_IMPORT_DESCRIPTOR,  *PIMAGE_BOUND_IMPORT_DESCRIPTOR;

typedef struct _IMAGE_BOUND_FORWARDER_REF {
	DWORD   TimeDateStamp;
	WORD    OffsetModuleName;
	WORD    Reserved;
} IMAGE_BOUND_FORWARDER_REF, *PIMAGE_BOUND_FORWARDER_REF;

//
// Resource Format.
//

//
// Resource directory consists of two counts, following by a variable length
// array of directory entries.  The first count is the number of entries at
// beginning of the array that have actual names associated with each entry.
// The entries are in ascending order, case insensitive strings.  The second
// count is the number of entries that immediately follow the named entries.
// This second count identifies the number of entries that have 16-bit integer
// Ids as their name.  These entries are also sorted in ascending order.
//
// This structure allows fast lookup by either name or number, but for any
// given resource entry only one form of lookup is supported, not both.
// This is consistant with the syntax of the .RC file and the .RES file.
//

typedef struct _IMAGE_RESOURCE_DIRECTORY {
	DWORD   Characteristics;
	DWORD   TimeDateStamp;
	WORD    MajorVersion;
	WORD    MinorVersion;
	WORD    NumberOfNamedEntries;
	WORD    NumberOfIdEntries;
	//  IMAGE_RESOURCE_DIRECTORY_ENTRY DirectoryEntries[];
} IMAGE_RESOURCE_DIRECTORY, *PIMAGE_RESOURCE_DIRECTORY;

#define IMAGE_RESOURCE_NAME_IS_STRING        0x80000000
#define IMAGE_RESOURCE_DATA_IS_DIRECTORY     0x80000000
//
// Each directory contains the 32-bit Name of the entry and an offset,
// relative to the beginning of the resource directory of the data associated
// with this directory entry.  If the name of the entry is an actual text
// string instead of an integer Id, then the high order bit of the name field
// is set to one and the low order 31-bits are an offset, relative to the
// beginning of the resource directory of the string, which is of type
// IMAGE_RESOURCE_DIRECTORY_STRING.  Otherwise the high bit is clear and the
// low-order 16-bits are the integer Id that identify this resource directory
// entry. If the directory entry is yet another resource directory (i.e. a
// subdirectory), then the high order bit of the offset field will be
// set to indicate this.  Otherwise the high bit is clear and the offset
// field points to a resource data entry.
//

typedef struct _IMAGE_RESOURCE_DIRECTORY_ENTRY {
	union {
		struct {
			DWORD NameOffset:31;
			DWORD NameIsString:1;
		};
		DWORD   Name;
		WORD    Id;
	};
	union {
		DWORD   OffsetToData;
		struct {
			DWORD   OffsetToDirectory:31;
			DWORD   DataIsDirectory:1;
		};
	};
} IMAGE_RESOURCE_DIRECTORY_ENTRY, *PIMAGE_RESOURCE_DIRECTORY_ENTRY;

//
// For resource directory entries that have actual string names, the Name
// field of the directory entry points to an object of the following type.
// All of these string objects are stored together after the last resource
// directory entry and before the first resource data object.  This minimizes
// the impact of these variable length objects on the alignment of the fixed
// size directory entry objects.
//

typedef struct _IMAGE_RESOURCE_DIRECTORY_STRING {
	WORD    Length;
	CHAR    NameString[ 1 ];
} IMAGE_RESOURCE_DIRECTORY_STRING, *PIMAGE_RESOURCE_DIRECTORY_STRING;


typedef struct _IMAGE_RESOURCE_DIR_STRING_U {
	WORD    Length;
	WCHAR   NameString[ 1 ];
} IMAGE_RESOURCE_DIR_STRING_U, *PIMAGE_RESOURCE_DIR_STRING_U;


//
// Each resource data entry describes a leaf node in the resource directory
// tree.  It contains an offset, relative to the beginning of the resource
// directory of the data for the resource, a size field that gives the number
// of bytes of data at that offset, a CodePage that should be used when
// decoding code point values within the resource data.  Typically for new
// applications the code page would be the unicode code page.
//

typedef struct _IMAGE_RESOURCE_DATA_ENTRY {
	DWORD   OffsetToData;
	DWORD   Size;
	DWORD   CodePage;
	DWORD   Reserved;
} IMAGE_RESOURCE_DATA_ENTRY, *PIMAGE_RESOURCE_DATA_ENTRY;

//
// Load Configuration Directory Entry
//

typedef struct {
	DWORD   Characteristics;
	DWORD   TimeDateStamp;
	WORD    MajorVersion;
	WORD    MinorVersion;
	DWORD   GlobalFlagsClear;
	DWORD   GlobalFlagsSet;
	DWORD   CriticalSectionDefaultTimeout;
	DWORD   DeCommitFreeBlockThreshold;
	DWORD   DeCommitTotalFreeThreshold;
	DWORD   LockPrefixTable;            // VA
	DWORD   MaximumAllocationSize;
	DWORD   VirtualMemoryThreshold;
	DWORD   ProcessHeapFlags;
	DWORD   ProcessAffinityMask;
	WORD    CSDVersion;
	WORD    Reserved1;
	DWORD   EditList;                   // VA
	DWORD   Reserved[ 1 ];
} IMAGE_LOAD_CONFIG_DIRECTORY32, *PIMAGE_LOAD_CONFIG_DIRECTORY32;

typedef struct {
	DWORD   Characteristics;
	DWORD   TimeDateStamp;
	WORD    MajorVersion;
	WORD    MinorVersion;
	DWORD   GlobalFlagsClear;
	DWORD   GlobalFlagsSet;
	DWORD   CriticalSectionDefaultTimeout;
	ULONGLONG  DeCommitFreeBlockThreshold;
	ULONGLONG  DeCommitTotalFreeThreshold;
	ULONGLONG  LockPrefixTable;         // VA
	ULONGLONG  MaximumAllocationSize;
	ULONGLONG  VirtualMemoryThreshold;
	ULONGLONG  ProcessAffinityMask;
	DWORD   ProcessHeapFlags;
	WORD    CSDVersion;
	WORD    Reserved1;
	ULONGLONG  EditList;                // VA
	DWORD   Reserved[ 2 ];
} IMAGE_LOAD_CONFIG_DIRECTORY64, *PIMAGE_LOAD_CONFIG_DIRECTORY64;

#ifdef _WIN64
typedef IMAGE_LOAD_CONFIG_DIRECTORY64   IMAGE_LOAD_CONFIG_DIRECTORY;
typedef PIMAGE_LOAD_CONFIG_DIRECTORY64  PIMAGE_LOAD_CONFIG_DIRECTORY;
#else
typedef IMAGE_LOAD_CONFIG_DIRECTORY32   IMAGE_LOAD_CONFIG_DIRECTORY;
typedef PIMAGE_LOAD_CONFIG_DIRECTORY32  PIMAGE_LOAD_CONFIG_DIRECTORY;
#endif

//
// WIN CE Exception table format
//

//
// Function table entry format.  Function table is pointed to by the
// IMAGE_DIRECTORY_ENTRY_EXCEPTION directory entry.
//

typedef struct _IMAGE_CE_RUNTIME_FUNCTION_ENTRY {
	DWORD FuncStart;
	DWORD PrologLen : 8;
	DWORD FuncLen : 22;
	DWORD ThirtyTwoBit : 1;
	DWORD ExceptionFlag : 1;
} IMAGE_CE_RUNTIME_FUNCTION_ENTRY, * PIMAGE_CE_RUNTIME_FUNCTION_ENTRY;

typedef struct _IMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY {
	ULONGLONG BeginAddress;
	ULONGLONG EndAddress;
	ULONGLONG ExceptionHandler;
	ULONGLONG HandlerData;
	ULONGLONG PrologEndAddress;
} IMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY, *PIMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY;

typedef struct _IMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY {
	DWORD BeginAddress;
	DWORD EndAddress;
	DWORD ExceptionHandler;
	DWORD HandlerData;
	DWORD PrologEndAddress;
} IMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY, *PIMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY;

typedef struct _IMAGE_RUNTIME_FUNCTION_ENTRY {
	DWORD BeginAddress;
	DWORD EndAddress;
	DWORD UnwindInfoAddress;
} _IMAGE_RUNTIME_FUNCTION_ENTRY, *_PIMAGE_RUNTIME_FUNCTION_ENTRY;

typedef  _IMAGE_RUNTIME_FUNCTION_ENTRY  IMAGE_IA64_RUNTIME_FUNCTION_ENTRY;
typedef _PIMAGE_RUNTIME_FUNCTION_ENTRY PIMAGE_IA64_RUNTIME_FUNCTION_ENTRY;

#if defined(_AXP64_)

typedef  IMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY  IMAGE_AXP64_RUNTIME_FUNCTION_ENTRY;
typedef PIMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY PIMAGE_AXP64_RUNTIME_FUNCTION_ENTRY;
typedef  IMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY  IMAGE_RUNTIME_FUNCTION_ENTRY;
typedef PIMAGE_ALPHA64_RUNTIME_FUNCTION_ENTRY PIMAGE_RUNTIME_FUNCTION_ENTRY;

#elif defined(_ALPHA_)

typedef  IMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY  IMAGE_RUNTIME_FUNCTION_ENTRY;
typedef PIMAGE_ALPHA_RUNTIME_FUNCTION_ENTRY PIMAGE_RUNTIME_FUNCTION_ENTRY;

#else

typedef  _IMAGE_RUNTIME_FUNCTION_ENTRY  IMAGE_RUNTIME_FUNCTION_ENTRY;
typedef _PIMAGE_RUNTIME_FUNCTION_ENTRY PIMAGE_RUNTIME_FUNCTION_ENTRY;

#endif

//
// Debug Format
//

typedef struct _IMAGE_DEBUG_DIRECTORY {
	DWORD   Characteristics;
	DWORD   TimeDateStamp;
	WORD    MajorVersion;
	WORD    MinorVersion;
	DWORD   Type;
	DWORD   SizeOfData;
	DWORD   AddressOfRawData;
	DWORD   PointerToRawData;
} IMAGE_DEBUG_DIRECTORY, *PIMAGE_DEBUG_DIRECTORY;

#define IMAGE_DEBUG_TYPE_UNKNOWN          0
#define IMAGE_DEBUG_TYPE_COFF             1
#define IMAGE_DEBUG_TYPE_CODEVIEW         2
#define IMAGE_DEBUG_TYPE_FPO              3
#define IMAGE_DEBUG_TYPE_MISC             4
#define IMAGE_DEBUG_TYPE_EXCEPTION        5
#define IMAGE_DEBUG_TYPE_FIXUP            6
#define IMAGE_DEBUG_TYPE_OMAP_TO_SRC      7
#define IMAGE_DEBUG_TYPE_OMAP_FROM_SRC    8
#define IMAGE_DEBUG_TYPE_BORLAND          9
#define IMAGE_DEBUG_TYPE_RESERVED10       10
#define IMAGE_DEBUG_TYPE_CLSID            11


typedef struct _IMAGE_COFF_SYMBOLS_HEADER {
	DWORD   NumberOfSymbols;
	DWORD   LvaToFirstSymbol;
	DWORD   NumberOfLinenumbers;
	DWORD   LvaToFirstLinenumber;
	DWORD   RvaToFirstByteOfCode;
	DWORD   RvaToLastByteOfCode;
	DWORD   RvaToFirstByteOfData;
	DWORD   RvaToLastByteOfData;
} IMAGE_COFF_SYMBOLS_HEADER, *PIMAGE_COFF_SYMBOLS_HEADER;

#define FRAME_FPO       0
#define FRAME_TRAP      1
#define FRAME_TSS       2
#define FRAME_NONFPO    3

typedef struct _FPO_DATA {
	DWORD       ulOffStart;             // offset 1st byte of function code
	DWORD       cbProcSize;             // # bytes in function
	DWORD       cdwLocals;              // # bytes in locals/4
	WORD        cdwParams;              // # bytes in params/4
	WORD        cbProlog : 8;           // # bytes in prolog
	WORD        cbRegs   : 3;           // # regs saved
	WORD        fHasSEH  : 1;           // TRUE if SEH in func
	WORD        fUseBP   : 1;           // TRUE if EBP has been allocated
	WORD        reserved : 1;           // reserved for future use
	WORD        cbFrame  : 2;           // frame type
} FPO_DATA, *PFPO_DATA;
#define SIZEOF_RFPO_DATA 16


#define IMAGE_DEBUG_MISC_EXENAME    1

typedef struct _IMAGE_DEBUG_MISC {
	DWORD       DataType;               // type of misc data, see defines
	DWORD       Length;                 // total length of record, rounded to four
	// byte multiple.
	BOOLEAN     Unicode;                // TRUE if data is unicode string
	BYTE        Reserved[ 3 ];
	BYTE        Data[ 1 ];              // Actual data
} IMAGE_DEBUG_MISC, *PIMAGE_DEBUG_MISC;


//
// Function table extracted from MIPS/ALPHA/IA64 images.  Does not contain
// information needed only for runtime support.  Just those fields for
// each entry needed by a debugger.
//

typedef struct _IMAGE_FUNCTION_ENTRY {
	DWORD   StartingAddress;
	DWORD   EndingAddress;
	DWORD   EndOfPrologue;
} IMAGE_FUNCTION_ENTRY, *PIMAGE_FUNCTION_ENTRY;

typedef struct _IMAGE_FUNCTION_ENTRY64 {
	ULONGLONG   StartingAddress;
	ULONGLONG   EndingAddress;
	union {
		ULONGLONG   EndOfPrologue;
		ULONGLONG   UnwindInfoAddress;
	};
} IMAGE_FUNCTION_ENTRY64, *PIMAGE_FUNCTION_ENTRY64;

//
// Debugging information can be stripped from an image file and placed
// in a separate .DBG file, whose file name part is the same as the
// image file name part (e.g. symbols for CMD.EXE could be stripped
// and placed in CMD.DBG).  This is indicated by the IMAGE_FILE_DEBUG_STRIPPED
// flag in the Characteristics field of the file header.  The beginning of
// the .DBG file contains the following structure which captures certain
// information from the image file.  This allows a debug to proceed even if
// the original image file is not accessable.  This header is followed by
// zero of more IMAGE_SECTION_HEADER structures, followed by zero or more
// IMAGE_DEBUG_DIRECTORY structures.  The latter structures and those in
// the image file contain file offsets relative to the beginning of the
// .DBG file.
//
// If symbols have been stripped from an image, the IMAGE_DEBUG_MISC structure
// is left in the image file, but not mapped.  This allows a debugger to
// compute the name of the .DBG file, from the name of the image in the
// IMAGE_DEBUG_MISC structure.
//

typedef struct _IMAGE_SEPARATE_DEBUG_HEADER {
	WORD        Signature;
	WORD        Flags;
	WORD        Machine;
	WORD        Characteristics;
	DWORD       TimeDateStamp;
	DWORD       CheckSum;
	DWORD       ImageBase;
	DWORD       SizeOfImage;
	DWORD       NumberOfSections;
	DWORD       ExportedNamesSize;
	DWORD       DebugDirectorySize;
	DWORD       SectionAlignment;
	DWORD       Reserved[2];
} IMAGE_SEPARATE_DEBUG_HEADER, *PIMAGE_SEPARATE_DEBUG_HEADER;

typedef struct _NON_PAGED_DEBUG_INFO {
	WORD        Signature;
	WORD        Flags;
	DWORD       Size;
	WORD        Machine;
	WORD        Characteristics;
	DWORD       TimeDateStamp;
	DWORD       CheckSum;
	DWORD       SizeOfImage;
	ULONGLONG   ImageBase;
	//DebugDirectorySize
	//IMAGE_DEBUG_DIRECTORY
} NON_PAGED_DEBUG_INFO, *PNON_PAGED_DEBUG_INFO;

#ifndef _MAC
#define IMAGE_SEPARATE_DEBUG_SIGNATURE 0x4944
#define NON_PAGED_DEBUG_SIGNATURE      0x494E
#else
#define IMAGE_SEPARATE_DEBUG_SIGNATURE 0x4449  // DI
#define NON_PAGED_DEBUG_SIGNATURE      0x4E49  // NI
#endif

#define IMAGE_SEPARATE_DEBUG_FLAGS_MASK 0x8000
#define IMAGE_SEPARATE_DEBUG_MISMATCH   0x8000  // when DBG was updated, the
// old checksum didn't match.

//
//  The .arch section is made up of headers, each describing an amask position/value
//  pointing to an array of IMAGE_ARCHITECTURE_ENTRY's.  Each "array" (both the header
//  and entry arrays) are terminiated by a quadword of 0xffffffffL.
//
//  NOTE: There may be quadwords of 0 sprinkled around and must be skipped.
//

typedef struct _ImageArchitectureHeader {
	unsigned int AmaskValue: 1;                 // 1 -> code section depends on mask bit
	// 0 -> new instruction depends on mask bit
	int :7;                                     // MBZ
	unsigned int AmaskShift: 8;                 // Amask bit in question for this fixup
	int :16;                                    // MBZ
	DWORD FirstEntryRVA;                        // RVA into .arch section to array of ARCHITECTURE_ENTRY's
} IMAGE_ARCHITECTURE_HEADER, *PIMAGE_ARCHITECTURE_HEADER;

typedef struct _ImageArchitectureEntry {
	DWORD FixupInstRVA;                         // RVA of instruction to fixup
	DWORD NewInst;                              // fixup instruction (see alphaops.h)
} IMAGE_ARCHITECTURE_ENTRY, *PIMAGE_ARCHITECTURE_ENTRY;

#include "poppack.h"                // Back to the initial value

// The following structure defines the new import object.  Note the values of the first two fields,
// which must be set as stated in order to differentiate old and new import members.
// Following this structure, the linker emits two null-terminated strings used to recreate the
// import at the time of use.  The first string is the import's name, the second is the dll's name.

#define IMPORT_OBJECT_HDR_SIG2  0xffff

typedef struct IMPORT_OBJECT_HEADER {
	WORD    Sig1;                       // Must be IMAGE_FILE_MACHINE_UNKNOWN
	WORD    Sig2;                       // Must be IMPORT_OBJECT_HDR_SIG2.
	WORD    Version;
	WORD    Machine;
	DWORD   TimeDateStamp;              // Time/date stamp
	DWORD   SizeOfData;                 // particularly useful for incremental links

	union {
		WORD    Ordinal;                // if grf & IMPORT_OBJECT_ORDINAL
		WORD    Hint;
	};

	WORD    Type : 2;                   // IMPORT_TYPE
	WORD    NameType : 3;               // IMPORT_NAME_TYPE
	WORD    Reserved : 11;              // Reserved. Must be zero.
} IMPORT_OBJECT_HEADER;

typedef enum IMPORT_OBJECT_TYPE
{
	IMPORT_OBJECT_CODE = 0,
	IMPORT_OBJECT_DATA = 1,
	IMPORT_OBJECT_CONST = 2,
} IMPORT_OBJECT_TYPE;

typedef enum IMPORT_OBJECT_NAME_TYPE
{
	IMPORT_OBJECT_ORDINAL = 0,          // Import by ordinal
	IMPORT_OBJECT_NAME = 1,             // Import name == public symbol name.
	IMPORT_OBJECT_NAME_NO_PREFIX = 2,   // Import name == public symbol name skipping leading ?, @, or optionally _.
	IMPORT_OBJECT_NAME_UNDECORATE = 3,  // Import name == public symbol name skipping leading ?, @, or optionally _
	// and truncating at first @
} IMPORT_OBJECT_NAME_TYPE;


#ifndef __IMAGE_COR20_HEADER_DEFINED__
#define __IMAGE_COR20_HEADER_DEFINED__

typedef enum ReplacesCorHdrNumericDefines
{
	// COM+ Header entry point flags.
	COMIMAGE_FLAGS_ILONLY               =0x00000001,
	COMIMAGE_FLAGS_32BITREQUIRED        =0x00000002,
	COMIMAGE_FLAGS_IL_LIBRARY           =0x00000004,
	COMIMAGE_FLAGS_TRACKDEBUGDATA       =0x00010000,

	// Version flags for image.
	COR_VERSION_MAJOR_V2                =2,
	COR_VERSION_MAJOR                   =COR_VERSION_MAJOR_V2,
	COR_VERSION_MINOR                   =0,
	COR_DELETED_NAME_LENGTH             =8,
	COR_VTABLEGAP_NAME_LENGTH           =8,

	// Maximum size of a NativeType descriptor.
	NATIVE_TYPE_MAX_CB                  =1,   
	COR_ILMETHOD_SECT_SMALL_MAX_DATASIZE=0xFF,

	// #defines for the MIH FLAGS
	IMAGE_COR_MIH_METHODRVA             =0x01,
	IMAGE_COR_MIH_EHRVA                 =0x02,    
	IMAGE_COR_MIH_BASICBLOCK            =0x08,

	// V-table constants
	COR_VTABLE_32BIT                    =0x01,          // V-table slots are 32-bits in size.   
	COR_VTABLE_64BIT                    =0x02,          // V-table slots are 64-bits in size.   
	COR_VTABLE_FROM_UNMANAGED           =0x04,          // If set, transition from unmanaged.
	COR_VTABLE_CALL_MOST_DERIVED        =0x10,          // Call most derived method described by

	// EATJ constants
	IMAGE_COR_EATJ_THUNK_SIZE           =32,            // Size of a jump thunk reserved range.

	// Max name lengths    
	//@todo: Change to unlimited name lengths.
	MAX_CLASS_NAME                      =1024,
	MAX_PACKAGE_NAME                    =1024,
} ReplacesCorHdrNumericDefines;

// COM+ 2.0 header structure.
typedef struct IMAGE_COR20_HEADER
{
	// Header versioning
	DWORD                   cb;              
	WORD                    MajorRuntimeVersion;
	WORD                    MinorRuntimeVersion;

	// Symbol table and startup information
	IMAGE_DATA_DIRECTORY    MetaData;        
	DWORD                   Flags;           
	DWORD                   EntryPointToken;

	// Binding information
	IMAGE_DATA_DIRECTORY    Resources;
	IMAGE_DATA_DIRECTORY    StrongNameSignature;

	// Regular fixup and binding information
	IMAGE_DATA_DIRECTORY    CodeManagerTable;
	IMAGE_DATA_DIRECTORY    VTableFixups;
	IMAGE_DATA_DIRECTORY    ExportAddressTableJumps;

	// Precompiled image info (internal use only - set to zero)
	IMAGE_DATA_DIRECTORY    ManagedNativeHeader;

} IMAGE_COR20_HEADER, *PIMAGE_COR20_HEADER;

#endif // __IMAGE_COR20_HEADER_DEFINED__

//
// End Image Format
//

#endif










//
// Define the base asynchronous I/O argument types
//

typedef struct _IO_STATUS_BLOCK {
    union {
        NTSTATUS Status;
        PVOID Pointer;
    };

    ULONG_PTR Information;
} IO_STATUS_BLOCK, *PIO_STATUS_BLOCK;

#if defined(_WIN64)
typedef struct _IO_STATUS_BLOCK32 {
    NTSTATUS Status;
    ULONG Information;
} IO_STATUS_BLOCK32, *PIO_STATUS_BLOCK32;
#endif

//
// Pool Allocation routines (in pool.c)
//

typedef enum _POOL_TYPE {
    NonPagedPool,
    PagedPool,
    NonPagedPoolMustSucceed,
    DontUseThisType,
    NonPagedPoolCacheAligned,
    PagedPoolCacheAligned,
    NonPagedPoolCacheAlignedMustS,
    MaxPoolType

    // end_wdm
    ,
    //
    // Note these per session types are carefully chosen so that the appropriate
    // masking still applies as well as MaxPoolType above.
    //

    NonPagedPoolSession = 32,
    PagedPoolSession = NonPagedPoolSession + 1,
    NonPagedPoolMustSucceedSession = PagedPoolSession + 1,
    DontUseThisTypeSession = NonPagedPoolMustSucceedSession + 1,
    NonPagedPoolCacheAlignedSession = DontUseThisTypeSession + 1,
    PagedPoolCacheAlignedSession = NonPagedPoolCacheAlignedSession + 1,
    NonPagedPoolCacheAlignedMustSSession = PagedPoolCacheAlignedSession + 1,

    // begin_wdm

    } POOL_TYPE;


#define POOL_COLD_ALLOCATION 256     // Note this cannot encode into the header.


#define POOL_QUOTA_FAIL_INSTEAD_OF_RAISE 8
#define POOL_RAISE_IF_ALLOCATION_FAILURE 16


typedef enum _TIMER_TYPE {
    NotificationTimer,
    SynchronizationTimer
    } TIMER_TYPE;


#ifndef _NTTYPES_NO_WINNT


#ifndef _DWORDLONG_
#define _DWORDLONG_
typedef ULONGLONG  DWORDLONG;
typedef DWORDLONG *PDWORDLONG;
#endif

// end_winnt

#endif

#ifndef MODE
typedef enum _MODE {
    KernelMode,
    UserMode,
    MaximumMode
} MODE;
#endif

typedef CCHAR KPROCESSOR_MODE;

// begin_ntminiport begin_ntndis

//
// Physical address.
//

typedef LARGE_INTEGER PHYSICAL_ADDRESS, *PPHYSICAL_ADDRESS;

// end_ntminiport end_ntndis

#ifndef _NTTYPES_NO_WINNT

// begin_winnt

//
// Define operations to logically shift an int64 by 0..31 bits and to multiply
// 32-bits by 32-bits to form a 64-bit product.
//

#if defined(MIDL_PASS) || defined(RC_INVOKED)

//
// Midl does not understand inline assembler. Therefore, the Rtl functions
// are used for shifts by 0.31 and multiplies of 32-bits times 32-bits to
// form a 64-bit product.
//

#define Int32x32To64(a, b) ((LONGLONG)((LONG)(a)) * (LONGLONG)((LONG)(b)))
#define UInt32x32To64(a, b) ((ULONGLONG)((ULONG)(a)) * (ULONGLONG)((ULONG)(b)))

#define Int64ShllMod32(a, b) ((ULONGLONG)(a) << (b))
#define Int64ShraMod32(a, b) ((LONGLONG)(a) >> (b))
#define Int64ShrlMod32(a, b) ((ULONGLONG)(a) >> (b))

#elif defined(_M_MRX000)

//
// MIPS uses intrinsic functions to perform shifts by 0..31 and multiplies of
// 32-bits times 32-bits to 64-bits.
//

#define Int32x32To64 __emul
#define UInt32x32To64 __emulu

#define Int64ShllMod32 __ll_lshift
#define Int64ShraMod32 __ll_rshift
#define Int64ShrlMod32 __ull_rshift

#if defined (__cplusplus)
extern "C" {
#endif

LONGLONG
NTAPI
Int32x32To64 (
    LONG Multiplier,
    LONG Multiplicand
    );

ULONGLONG
NTAPI
UInt32x32To64 (
    ULONG Multiplier,
    ULONG Multiplicand
    );

ULONGLONG
NTAPI
Int64ShllMod32 (
    ULONGLONG Value,
    ULONG ShiftCount
    );

LONGLONG
NTAPI
Int64ShraMod32 (
    LONGLONG Value,
    ULONG ShiftCount
    );

ULONGLONG
NTAPI
Int64ShrlMod32 (
    ULONGLONG Value,
    ULONG ShiftCount
    );

#if defined (__cplusplus)
};
#endif

#pragma intrinsic(__emul)
#pragma intrinsic(__emulu)

#pragma intrinsic(__ll_lshift)
#pragma intrinsic(__ll_rshift)
#pragma intrinsic(__ull_rshift)

#elif defined(_M_IX86)

//
// The x86 C compiler understands inline assembler. Therefore, inline functions
// that employ inline assembler are used for shifts of 0..31.  The multiplies
// rely on the compiler recognizing the cast of the multiplicand to int64 to
// generate the optimal code inline.
//

#ifndef Int32x32To64
#define Int32x32To64( a, b ) (LONGLONG)((LONGLONG)(LONG)(a) * (LONG)(b))
#endif

#ifndef UInt32x32To64
#define UInt32x32To64( a, b ) (ULONGLONG)((ULONGLONG)(ULONG)(a) * (ULONG)(b))
#endif

ULONGLONG
NTAPI
Int64ShllMod32 (
    ULONGLONG Value,
    ULONG ShiftCount
    );

LONGLONG
NTAPI
Int64ShraMod32 (
    LONGLONG Value,
    ULONG ShiftCount
    );

ULONGLONG
NTAPI
Int64ShrlMod32 (
    ULONGLONG Value,
    ULONG ShiftCount
    );

#if _MSC_VER >= 1200
#pragma warning(push)
#endif
#pragma warning(disable:4035)               // re-enable below

#if 0
__inline ULONGLONG
NTAPI
Int64ShllMod32 (
    ULONGLONG Value,
    ULONG ShiftCount
    )
{
    __asm    {
        mov     ecx, ShiftCount
        mov     eax, dword ptr [Value]
        mov     edx, dword ptr [Value+4]
        shld    edx, eax, cl
        shl     eax, cl
    }
}

__inline LONGLONG
NTAPI
Int64ShraMod32 (
    LONGLONG Value,
    ULONG ShiftCount
    )
{
    __asm {
        mov     ecx, ShiftCount
        mov     eax, dword ptr [Value]
        mov     edx, dword ptr [Value+4]
        shrd    eax, edx, cl
        sar     edx, cl
    }
}

__inline ULONGLONG
NTAPI
Int64ShrlMod32 (
    ULONGLONG Value,
    ULONG ShiftCount
    )
{
    __asm    {
        mov     ecx, ShiftCount
        mov     eax, dword ptr [Value]
        mov     edx, dword ptr [Value+4]
        shrd    eax, edx, cl
        shr     edx, cl
    }
}

#endif
#if _MSC_VER >= 1200
#pragma warning(pop)
#else
#pragma warning(default:4035)
#endif

#elif defined(_M_ALPHA)

//
// Alpha has native 64-bit operations that are just as fast as their 32-bit
// counter parts. Therefore, the int64 data type is used directly to form
// shifts of 0..31 and multiplies of 32-bits times 32-bits to form a 64-bit
// product.
//

#define Int32x32To64(a, b) ((LONGLONG)((LONG)(a)) * (LONGLONG)((LONG)(b)))
#define UInt32x32To64(a, b) ((ULONGLONG)((ULONG)(a)) * (ULONGLONG)((ULONG)(b)))

#define Int64ShllMod32(a, b) ((ULONGLONG)(a) << (b))
#define Int64ShraMod32(a, b) ((LONGLONG)(a) >> (b))
#define Int64ShrlMod32(a, b) ((ULONGLONG)(a) >> (b))
#error shouldn't happen

#elif defined(_M_PPC)

#define Int32x32To64(a, b) ((LONGLONG)((LONG)(a)) * (LONGLONG)((LONG)(b)))
#define UInt32x32To64(a, b) ((ULONGLONG)((ULONG)(a)) * (ULONGLONG)((ULONG)(b)))

#define Int64ShllMod32(a, b) ((ULONGLONG)(a) << (b))
#define Int64ShraMod32(a, b) ((LONGLONG)(a) >> (b))
#define Int64ShrlMod32(a, b) ((ULONGLONG)(a) >> (b))

#elif defined(_68K_) || defined(_MPPC_)

//
// The Macintosh 68K and PowerPC compilers do not currently support int64.
//

#define Int32x32To64(a, b) ((LONGLONG)((LONG)(a)) * (LONGLONG)((LONG)(b)))
#define UInt32x32To64(a, b) ((DWORDLONG)((DWORD)(a)) * (DWORDLONG)((DWORD)(b)))

#define Int64ShllMod32(a, b) ((DWORDLONG)(a) << (b))
#define Int64ShraMod32(a, b) ((LONGLONG)(a) >> (b))
#define Int64ShrlMod32(a, b) ((DWORDLONG)(a) >> (b))

#elif defined(_M_IA64)

//
// IA64 has native 64-bit operations that are just as fast as their 32-bit
// counter parts. Therefore, the int64 data type is used directly to form
// shifts of 0..31 and multiplies of 32-bits times 32-bits to form a 64-bit
// product.
//

#define Int32x32To64(a, b) ((LONGLONG)((LONG)(a)) * (LONGLONG)((LONG)(b)))
#define UInt32x32To64(a, b) ((ULONGLONG)((ULONG)(a)) * (ULONGLONG)((ULONG)(b)))

#define Int64ShllMod32(a, b) ((ULONGLONG)(a) << (b))
#define Int64ShraMod32(a, b) ((LONGLONG)(a) >> (b))
#define Int64ShrlMod32(a, b) ((ULONGLONG)(a) >> (b))

#else

#error Must define a target architecture.

#endif

#endif
//
// Pointer to an Asciiz string
//

//#ifndef _NTTYPES_NO_BASETYPES

#ifndef PSZ
typedef CHAR *PSZ;
#endif
#ifndef PCSZ
typedef CONST char *PCSZ;
#endif

//#endif

// begin_ntndis
//
// Counted String
//

typedef struct _STRING {
    USHORT Length;
    USHORT MaximumLength;
#ifdef MIDL_PASS
    [size_is(MaximumLength), length_is(Length) ]
#endif // MIDL_PASS
    PCHAR Buffer;
} STRING;

typedef STRING *PSTRING;

typedef STRING ANSI_STRING;
typedef PSTRING PANSI_STRING;

typedef STRING OEM_STRING;
typedef PSTRING POEM_STRING;

//
// CONSTCounted String
//

typedef struct _CSTRING {
    USHORT Length;
    USHORT MaximumLength;
    CONST char *Buffer;
} CSTRING;
typedef CSTRING *PCSTRING;

#ifndef ANSI_NULL
#define ANSI_NULL ((CHAR)0)     // winnt
#define UNICODE_NULL ((WCHAR)0) 
#define UNICODE_STRING_MAX_BYTES ((WORD  ) 65534) 
#define UNICODE_STRING_MAX_CHARS (32767) 
#endif     

typedef STRING CANSI_STRING;
typedef PSTRING PCANSI_STRING;

//
// Unicode strings are counted 16-bit character strings. If they are
// NULL terminated, Length does not include trailing NULL.
//

typedef struct _UNICODE_STRING {
    USHORT Length;
    USHORT MaximumLength;
#ifdef MIDL_PASS
    [size_is(MaximumLength / 2), length_is((Length) / 2) ] USHORT * Buffer;
#else // MIDL_PASS
    PWSTR  Buffer;
#endif // MIDL_PASS
} UNICODE_STRING;
typedef UNICODE_STRING *PUNICODE_STRING;
typedef const UNICODE_STRING *PCUNICODE_STRING;

#ifndef UNICODE_NULL
#define UNICODE_NULL ((WCHAR)0) // winnt
#endif

typedef struct _KTHREAD *PKTHREAD;
typedef struct _ETHREAD *PETHREAD;
typedef struct _EPROCESS *PEPROCESS;
typedef struct _PEB *PPEB;
typedef struct _KINTERRUPT *PKINTERRUPT;
typedef struct _IO_TIMER *PIO_TIMER;
typedef struct _OBJECT_TYPE *POBJECT_TYPE;
typedef struct _CALLBACK_OBJECT *PCALLBACK_OBJECT;
typedef struct _DEVICE_HANDLER_OBJECT *PDEVICE_HANDLER_OBJECT;
typedef struct _BUS_HANDLER *PBUS_HANDLER;
//typedef struct _KTRAP_FRAME *PKTRAP_FRAME;

typedef struct _EXCEPTION_REGISTRATION_RECORD * PEXCEPTION_REGISTRATION_RECORD; // Standard exception registration, not defined here

typedef struct _KTRAP_FRAME {
	ULONG							DbgEbp;
	ULONG							DbgEip;
	ULONG							DbgArgMark;
	ULONG							DbgArgPointer;
	ULONG							TempSegCs;
	ULONG							TempEsp;
	ULONG							Dr0;
	ULONG							Dr1;
	ULONG							Dr2;
	ULONG							Dr3;
	ULONG							Dr6;
	ULONG							Dr7;
	ULONG							SegGs;
	ULONG							SegEs;
	ULONG							SegDs;
	ULONG							Edx;
	ULONG							Ecx;
	ULONG							Eax;
	ULONG							PreviousPreviousMode; // MODE, but as a ULONG to ensure we have proper alignment (32-bit)
	PEXCEPTION_REGISTRATION_RECORD	ExceptionList;
	ULONG							SegFs;
	ULONG							Edi;
	ULONG							Esi;
	ULONG							Ebx;
	ULONG							Ebp;
	ULONG							ErrCode;
	ULONG							Eip;
	ULONG							SegCs;
	ULONG							EFlags;
	ULONG							HardwareEsp;
	ULONG							HardwareSegSs;
	ULONG							V86Es;
	ULONG							V86Ds;
	ULONG							V86Fs;
	ULONG							V86Gs;
} KTRAP_FRAME, * PKTRAP_FRAME;

#ifndef _NTTYPES_NO_WINNT

typedef struct _NT_TIB {
    struct _EXCEPTION_REGISTRATION_RECORD *ExceptionList;
    PVOID StackBase;
    PVOID StackLimit;
    PVOID SubSystemTib;
    union {
        PVOID FiberData;
        ULONG Version;
    };
    PVOID ArbitraryUserPointer;
    struct _NT_TIB *Self;
} NT_TIB;
typedef NT_TIB *PNT_TIB;

#endif

#ifndef OBJ_INHERIT
enum {
	OBJ_INHERIT				=	0x00000002L,
	OBJ_PERMANENT			=	0x00000010L,
	OBJ_EXCLUSIVE			=	0x00000020L,
	OBJ_CASE_INSENSITIVE	=	0x00000040L,
	OBJ_OPENIF				=	0x00000080L,
	OBJ_OPENLINK			=	0x00000100L,
#if _WIN32_WINNT >= 0x0500
	OBJ_KERNEL_HANDLE		=	0x00000200L,
#endif
#if _WIN32_WINNT <= 0x0400
	OBJ_VALID_ATTRIBUTES	=	0x000002F2L
#elif _WIN32_WINNT <= 0x0500
	OBJ_VALID_ATTRIBUTES	=	0x000004F2L
#else
	OBJ_FORCE_ACCESS_CHECK	=	0x00000400L,
	OBJ_VALID_ATTRIBUTES	=	0x000007F2L
#endif
};
#endif

//
// Thread affinity
//

typedef ULONG_PTR KAFFINITY;
typedef KAFFINITY *PKAFFINITY;

//
// Thread priority
//

typedef LONG KPRIORITY;

//
// Spin Lock
//

typedef ULONG_PTR KSPIN_LOCK;
typedef KSPIN_LOCK *PKSPIN_LOCK;

#ifndef _NTTYPES_NO_WINNT

#if defined(_M_IA64)

typedef struct _FRAME_POINTERS {
    ULONGLONG MemoryStackFp;
    ULONGLONG BackingStoreFp;
} FRAME_POINTERS, *PFRAME_POINTERS;

#define UNWIND_HISTORY_TABLE_SIZE 12

typedef struct _RUNTIME_FUNCTION {
    ULONG BeginAddress;
    ULONG EndAddress;
    ULONG UnwindInfoAddress;
} RUNTIME_FUNCTION, *PRUNTIME_FUNCTION;

typedef struct _UNWIND_HISTORY_TABLE_ENTRY {
    ULONG64 ImageBase;
    ULONG64 Gp;
    PRUNTIME_FUNCTION FunctionEntry;
} UNWIND_HISTORY_TABLE_ENTRY, *PUNWIND_HISTORY_TABLE_ENTRY;

typedef struct _UNWIND_HISTORY_TABLE {
    ULONG Count;
    UCHAR Search;
    ULONG64 LowAddress;
    ULONG64 HighAddress;
    UNWIND_HISTORY_TABLE_ENTRY Entry[UNWIND_HISTORY_TABLE_SIZE];
} UNWIND_HISTORY_TABLE, *PUNWIND_HISTORY_TABLE;

#endif // _M_IA64

#endif

//
// Interrupt routine (first level dispatch)
//

typedef
VOID
(*PKINTERRUPT_ROUTINE) (
    VOID
    );













#ifndef _NTTYPES_NO_WINNT


////////////////////////////////////////////////////////////////////////
//                                                                    //
//                             ACCESS TYPES                           //
//                                                                    //
////////////////////////////////////////////////////////////////////////


// begin_ntddk begin_wdm begin_nthal begin_ntifs
//
//  The following are masks for the predefined standard access types
//

#define DELETE                           (0x00010000L)
#define READ_CONTROL                     (0x00020000L)
#define WRITE_DAC                        (0x00040000L)
#define WRITE_OWNER                      (0x00080000L)
#define SYNCHRONIZE                      (0x00100000L)

#define STANDARD_RIGHTS_REQUIRED         (0x000F0000L)

#define STANDARD_RIGHTS_READ             (READ_CONTROL)
#define STANDARD_RIGHTS_WRITE            (READ_CONTROL)
#define STANDARD_RIGHTS_EXECUTE          (READ_CONTROL)

#define STANDARD_RIGHTS_ALL              (0x001F0000L)

#define SPECIFIC_RIGHTS_ALL              (0x0000FFFFL)

//
// AccessSystemAcl access type
//

#define ACCESS_SYSTEM_SECURITY           (0x01000000L)

//
// MaximumAllowed access type
//

#define MAXIMUM_ALLOWED                  (0x02000000L)

//
//  These are the generic rights.
//

#define GENERIC_READ                     (0x80000000L)
#define GENERIC_WRITE                    (0x40000000L)
#define GENERIC_EXECUTE                  (0x20000000L)
#define GENERIC_ALL                      (0x10000000L)

//
//  Define the generic mapping array.  This is used to denote the
//  mapping of each generic access right to a specific access mask.
//

typedef struct _GENERIC_MAPPING {
	ACCESS_MASK GenericRead;
	ACCESS_MASK GenericWrite;
	ACCESS_MASK GenericExecute;
	ACCESS_MASK GenericAll;
} GENERIC_MAPPING;
typedef GENERIC_MAPPING *PGENERIC_MAPPING;


//
// Security Tracking Mode
//

#define SECURITY_DYNAMIC_TRACKING      (TRUE)
#define SECURITY_STATIC_TRACKING       (FALSE)

typedef BOOLEAN SECURITY_CONTEXT_TRACKING_MODE,
* PSECURITY_CONTEXT_TRACKING_MODE;



//
// Quality Of Service
//

typedef enum _SECURITY_IMPERSONATION_LEVEL { // Information Class 9
	SecurityAnonymous,
	SecurityIdentification,
	SecurityImpersonation,
	SecurityDelegation
} SECURITY_IMPERSONATION_LEVEL, * PSECURITY_IMPERSONATION_LEVEL;


#define SECURITY_MAX_IMPERSONATION_LEVEL SecurityDelegation
#define SECURITY_MIN_IMPERSONATION_LEVEL SecurityAnonymous
#define DEFAULT_IMPERSONATION_LEVEL SecurityImpersonation
#define VALID_IMPERSONATION_LEVEL(L) (((L) >= SECURITY_MIN_IMPERSONATION_LEVEL) && ((L) <= SECURITY_MAX_IMPERSONATION_LEVEL))

typedef struct _SECURITY_QUALITY_OF_SERVICE {
	DWORD Length;
	SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
	SECURITY_CONTEXT_TRACKING_MODE ContextTrackingMode;
	BOOLEAN EffectiveOnly;
} SECURITY_QUALITY_OF_SERVICE, * PSECURITY_QUALITY_OF_SERVICE;

typedef enum _PROXY_CLASS {
	ProxyFull,
	ProxyService,
	ProxyTree,
	ProxyDirectory
} PROXY_CLASS, * PPROXY_CLASS;

typedef struct _SECURITY_TOKEN_PROXY_DATA {
	ULONG Length;
	PROXY_CLASS ProxyClass;
	UNICODE_STRING PathInfo;
	ACCESS_MASK ContainerMask;
	ACCESS_MASK ObjectMask;
} SECURITY_TOKEN_PROXY_DATA, *PSECURITY_TOKEN_PROXY_DATA;

typedef struct _SECURITY_TOKEN_AUDIT_DATA {
	ULONG Length;
	ACCESS_MASK GrantMask;
	ACCESS_MASK DenyMask;
} SECURITY_TOKEN_AUDIT_DATA, *PSECURITY_TOKEN_AUDIT_DATA;

typedef struct _SECURITY_ADVANCED_QUALITY_OF_SERVICE {
	ULONG Length;
	SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
	SECURITY_CONTEXT_TRACKING_MODE ContextTrackingMode;
	BOOLEAN EffectiveOnly;
	PSECURITY_TOKEN_PROXY_DATA ProxyData;
	PSECURITY_TOKEN_AUDIT_DATA AuditData;
} SECURITY_ADVANCED_QUALITY_OF_SERVICE, *PSECURITY_ADVANCED_QUALITY_OF_SERVICE;


//
// Used to represent information related to a thread impersonation
//

typedef struct _SE_IMPERSONATION_STATE {
	PACCESS_TOKEN Token;
	BOOLEAN CopyOnOpen;
	BOOLEAN EffectiveOnly;
	SECURITY_IMPERSONATION_LEVEL Level;
} SE_IMPERSONATION_STATE, *PSE_IMPERSONATION_STATE;

#define DISABLE_MAX_PRIVILEGE   0x1 
#define SANDBOX_INERT           0x2 

typedef DWORD SECURITY_INFORMATION, *PSECURITY_INFORMATION;

#define OWNER_SECURITY_INFORMATION       (0x00000001L)
#define GROUP_SECURITY_INFORMATION       (0x00000002L)
#define DACL_SECURITY_INFORMATION        (0x00000004L)
#define SACL_SECURITY_INFORMATION        (0x00000008L)

#define PROTECTED_DACL_SECURITY_INFORMATION     (0x80000000L)
#define PROTECTED_SACL_SECURITY_INFORMATION     (0x40000000L)
#define UNPROTECTED_DACL_SECURITY_INFORMATION   (0x20000000L)
#define UNPROTECTED_SACL_SECURITY_INFORMATION   (0x10000000L)

#ifndef _NTTYPES_NO_WINNT

//
//  Doubly linked list structure.  Can be used as either a list head, or
//  as link words.
//

typedef struct _LIST_ENTRY {
	struct _LIST_ENTRY *Flink;
	struct _LIST_ENTRY *Blink;
} LIST_ENTRY, *PLIST_ENTRY, *RESTRICTED_POINTER PRLIST_ENTRY;

#endif


typedef struct _RTL_CRITICAL_SECTION_DEBUG {
	WORD   Type;
	WORD   CreatorBackTraceIndex;
	struct _RTL_CRITICAL_SECTION *CriticalSection;
	LIST_ENTRY ProcessLocksList;
	DWORD EntryCount;
	DWORD ContentionCount;
	DWORD Spare[ 2 ];
} RTL_CRITICAL_SECTION_DEBUG, *PRTL_CRITICAL_SECTION_DEBUG, RTL_RESOURCE_DEBUG, *PRTL_RESOURCE_DEBUG;

#define RTL_CRITSECT_TYPE 0
#define RTL_RESOURCE_TYPE 1

typedef struct _RTL_CRITICAL_SECTION {
	PRTL_CRITICAL_SECTION_DEBUG DebugInfo;

	//
	//  The following three fields control entering and exiting the critical
	//  section for the resource
	//

	LONG LockCount;
	LONG RecursionCount;
	HANDLE OwningThread;        // from the thread's ClientId->UniqueThread
	HANDLE LockSemaphore;
	ULONG_PTR SpinCount;        // force size on 64-bit systems when packed
} RTL_CRITICAL_SECTION, *PRTL_CRITICAL_SECTION;

#endif


//
// Rtl Resources - ERESOURCE-like shared/exclusive locks for user mode.
//

typedef struct _RTL_RESOURCE {
    RTL_CRITICAL_SECTION CriticalSection;

    HANDLE SharedSemaphore;
    ULONG NumberOfWaitingShared;
    HANDLE ExclusiveSemaphore;
    ULONG NumberOfWaitingExclusive;

	//
	// The current state of the resource can be interpreted by examining NumberOfActive:
	// NumberOfActive  < 0: abs(NumberOfActive) is the number of exclusive acquisitions.
	// NumberOfActive == 0: The resource is not acquired.
	// NumberOfActive  > 0: NumberOfActive is the number of shared acquisitions.
	//

    LONG NumberOfActive;
    HANDLE ExclusiveOwnerThread;

    ULONG Flags;        // See below

    PRTL_RESOURCE_DEBUG DebugInfo;
} RTL_RESOURCE, *PRTL_RESOURCE;

#define RTL_RESOURCE_FLAG_DISABLE_TIMEOUT     ((ULONG) 0x00000001)		/* Disable wait timeout deadlock detection */

//
// Define the I/O bus interface types.
//

typedef enum _INTERFACE_TYPE {
	InterfaceTypeUndefined = -1,
	Internal,
	Isa,
	Eisa,
	MicroChannel,
	TurboChannel,
	PCIBus,
	VMEBus,
	NuBus,
	PCMCIABus,
	CBus,
	MPIBus,
	MPSABus,
	ProcessorInternal,
	InternalPowerBus,
	PNPISABus,
	PNPBus,
	MaximumInterfaceType
}INTERFACE_TYPE, *PINTERFACE_TYPE;

//
// Define the DMA transfer widths.
//

typedef enum _DMA_WIDTH {
	Width8Bits,
	Width16Bits,
	Width32Bits,
	MaximumDmaWidth
}DMA_WIDTH, *PDMA_WIDTH;

//
// Define DMA transfer speeds.
//

typedef enum _DMA_SPEED {
	Compatible,
	TypeA,
	TypeB,
	TypeC,
	TypeF,
	MaximumDmaSpeed
}DMA_SPEED, *PDMA_SPEED;





//
// Done defining the basic types.
// Now, compound types.
//

//
// PNP / VDM TYPE DEFINITIONS
//

#include <nt\nttypespnpvdm.h>

//
// END PNP / VDM TYPE DEFINITIONS
//






//
// Profile source types
//
typedef enum _KPROFILE_SOURCE {
    ProfileTime,
    ProfileAlignmentFixup,
    ProfileTotalIssues,
    ProfilePipelineDry,
    ProfileLoadInstructions,
    ProfilePipelineFrozen,
    ProfileBranchInstructions,
    ProfileTotalNonissues,
    ProfileDcacheMisses,
    ProfileIcacheMisses,
    ProfileCacheMisses,
    ProfileBranchMispredictions,
    ProfileStoreInstructions,
    ProfileFpInstructions,
    ProfileIntegerInstructions,
    Profile2Issue,
    Profile3Issue,
    Profile4Issue,
    ProfileSpecialInstructions,
    ProfileTotalCycles,
    ProfileIcacheIssues,
    ProfileDcacheAccesses,
    ProfileMemoryBarrierCycles,
    ProfileLoadLinkedIssues,
    ProfileMaximum
} KPROFILE_SOURCE;

//#ifndef _NTTYPES_NO_WINNT

typedef struct _OBJECT_ATTRIBUTES {
	ULONG Length;
	HANDLE RootDirectory;
	PUNICODE_STRING ObjectName;
	ULONG Attributes;
	PVOID SecurityDescriptor;
	PVOID SecurityQualityOfService;
} OBJECT_ATTRIBUTES, *POBJECT_ATTRIBUTES;

typedef struct _CLIENT_ID {
	HANDLE UniqueProcess;
	HANDLE UniqueThread;
} CLIENT_ID,*PCLIENT_ID;

typedef enum _PROCESSINFOCLASS {      //Query Set	Notes (paraphrased from Windows NT/2000 Native API Reference + additions for Windows XP/Windows Server 2003)
	ProcessBasicInformation,          // 0  Y N
	ProcessQuotaLimits,               // 1  Y Y	SeIncreaseQuotaPrivilege (to set quota)
	ProcessIoCounters,                // 2  Y N	Windows 2000 or later
	ProcessVmCounters,                // 3  Y N
	ProcessTimes,                     // 4  Y N
	ProcessBasePriority,              // 5  N Y	KPRIORITY, SeIncreaseBasePriorityPrivilege
	ProcessRaisePriority,             // 6  N Y	ULONG, sets all thread priorities, up to highest nonreal-time
	ProcessDebugPort,                 // 7  Y Y	HANDLE, can only be set if zero (can be reset to 0 in NT4), -1 when using DebugObjects on Windows XP or later [in this case, read-only]
	ProcessExceptionPort,             // 8  N Y	HANDLE, can only be set if zero
	ProcessAccessToken,               // 9  N Y	Token must have TOKEN_ASSIGN_PRIMARY, SeAssignPrimaryTokenPrivilege unless under Windows 2000 and reducing privileges
	ProcessLdtInformation,            // 10 Y Y	LDTINFORMATION
	ProcessLdtSize,                   // 11 N Y
	ProcessDefaultHardErrorMode,      // 12 Y Y	ULONG, see SetErrorMode in PSDK
	ProcessIoPortHandlers,            // 13 N Y	ULONG, 1 to enable VDM flag in _EPROCESS, requires SeTcbPrivilege - Win2003+, otherwise IoPortHandlers struct
	ProcessPooledUsageAndLimits,      // 14 Y N
	ProcessWorkingSetWatch,           // 15 Y Y	May set ProcessInformation to NULL and ProcessInformationLength to 0
	ProcessUserModeIOPL,              // 16 N Y	SeTcbPrivilege, Intel-specific, set IOPL in EFLAGS for all threads
	ProcessEnableAlignmentFaultFixup, // 17 N Y	BOOLEAN
	ProcessPriorityClass,             // 18 Y Y	SeIncreaseBasePriorityPrivilege, PC_xxxxx, 4 for NT4, 6 for Windows 2000 or later, set to all threads, USHORT
	ProcessWx86Information,           // 19 Y N	ULONG, always 0 on x86 Windows Server 2003, else a BOOLEAN (as ULONG) and requires SeTcbPrivilege to set, 0 --> Process.VmTopDown, 1 --> !Process.VmTopDown
	ProcessHandleCount,               // 20 Y N	ULONG
	ProcessAffinityMask,              // 21 N Y	KAFFINITY, set to all threads
	ProcessPriorityBoost,             // 22 Y Y	ULONG, interpreted as boolean, set to all threads
	ProcessDeviceMap,                 // 23 Y Y	Different for get/set, see GetDriveType, by is the drive map associated with the object directory named "\\??\\"
	ProcessSessionInformation,        // 24 Y Y	Terminal services session, SeTcbPrivilege, stored in KPROCESS, process token, PEB, SeTcbPrivilege required
	ProcessForegroundInformation,     // 25 N Y	BOOLEAN (sizeof == 1), may also be set with ProcessPriorityClass
	ProcessWow64Information,          // 26 Y N	0 on x86, ULONG
	ProcessImageFileName,  	          // 27 Y N UNICODE_STRING
	ProcessLUIDDeviceMapsEnabled,	  // 28 Y N ULONG
	ProcessBreakOnTermination,		  // 29 Y Y	RtlSetProcessIsCritical, sizeof == 4, Windows XP/Server 2003 or later, SeDebugPrivilege
	ProcessDebugObjectHandle,		  // 30 Y N Opens a HANDLE to a DebugObject into the caller process with MAXIMUM_ALLOWED rights
	ProcessDebugFlags,				  // 31 Y Y ULONG, see PROCESS_DEBUG_FLAG_* below
	ProcessHandleTracing,			  // 32 Y Y	sizeof == 0/4/8, handle checking, size==0 disables, otherwise PROCESS_HANDLE_TRACING_ENABLE or PROCESS_HANDLE_TRACING_ENABLE_EX, on query size must be >= 8 (PROCESS_HANDLE_TRACING_QUERY with zero handles)
	ProcessIoPriority,                // 33 N N Reserved
	ProcessExecuteFlags,              // 34 Y Y ULONG, see MEM_EXECUTE_* below
	ProcessTlsInformation,            // 35 N Y PROCESS_TLS_INFORMATION
	//ProcessResourceManagement,        // 35 N N Reserved
	ProcessCookie,                    // 36 Y N ULONG, unique random value for this process
	ProcessImageInformation,          // 37 Y N SECTION_IMAGE_INFORMATION for main process image
	MaxProcessInfoClass
} PROCESSINFOCLASS;

typedef struct _PROCESS_BASIC_INFORMATION { // Information Class 0
	NTSTATUS ExitStatus;
	PPEB PebBaseAddress;
	KAFFINITY AffinityMask;
	KPRIORITY BasePriority;
	HANDLE UniqueProcessId;
	HANDLE InheritedFromUniqueProcessId;
} PROCESS_BASIC_INFORMATION, *PPROCESS_BASIC_INFORMATION;

#ifndef _NTTYPES_NO_WINNT

typedef struct _QUOTA_LIMITS { // Information Class 1
	ULONG PagedPoolLimit;
	ULONG NonPagedPoolLimit;
	ULONG MinimumWorkingSetSize;
	ULONG MaximumWorkingSetSize;
	ULONG PagefileLimit;
	LARGE_INTEGER TimeLimit;
} QUOTA_LIMITS, *PQUOTA_LIMITS;

#define QUOTA_LIMITS_HARDWS_MIN_ENABLE  0x00000001
#define QUOTA_LIMITS_HARDWS_MIN_DISABLE 0x00000002
#define QUOTA_LIMITS_HARDWS_MAX_ENABLE  0x00000004
#define QUOTA_LIMITS_HARDWS_MAX_DISABLE 0x00000008

typedef struct _QUOTA_LIMITS_EX {
    SIZE_T PagedPoolLimit;
    SIZE_T NonPagedPoolLimit;
    SIZE_T MinimumWorkingSetSize;
    SIZE_T MaximumWorkingSetSize;
    SIZE_T PagefileLimit;
    LARGE_INTEGER TimeLimit;
    SIZE_T Reserved1;
    SIZE_T Reserved2;
    SIZE_T Reserved3;
    SIZE_T Reserved4;
    ULONG  Flags;
    ULONG  Reserved5;
} QUOTA_LIMITS_EX, *PQUOTA_LIMITS_EX;


typedef struct _IO_COUNTERS { // Information Class 2
	LARGE_INTEGER ReadOperationCount;
	LARGE_INTEGER WriteOperationCount;
	LARGE_INTEGER OtherOperationCount;
	LARGE_INTEGER ReadTransferCount;
	LARGE_INTEGER WriteTransferCount;
	LARGE_INTEGER OtherTransferCount;
} IO_COUNTERS, *PIO_COUNTERS;

#endif

typedef struct _VM_COUNTERS { // Information Class 3
	ULONG PeakVirtualSize;
	ULONG VirtualSize;
	ULONG PageFaultCount;
	ULONG PeakWorkingSetSize;
	ULONG WorkingSetSize;
	ULONG QuotaPeakPagedPoolUsage;
	ULONG QuotaPagedPoolUsage;
	ULONG QuotaPeakNonPagedPoolUsage;
	ULONG QuotaNonPagedPoolUsage;
	ULONG PagefileUsage;
	ULONG PeakPagefileUsage;
} VM_COUNTERS, *PVM_COUNTERS;

typedef struct _VM_COUNTERS_EX {
	SIZE_T PeakVirtualSize;
	SIZE_T VirtualSize;
	ULONG PageFaultCount;
	SIZE_T PeakWorkingSetSize;
	SIZE_T WorkingSetSize;
	SIZE_T QuotaPeakPagedPoolUsage;
	SIZE_T QuotaPagedPoolUsage;
	SIZE_T QuotaPeakNonPagedPoolUsage;
	SIZE_T QuotaNonPagedPoolUsage;
	SIZE_T PagefileUsage;
	SIZE_T PeakPagefileUsage;
	SIZE_T PrivateUsage;
} VM_COUNTERS_EX, * PVM_COUNTERS_EX;

typedef struct _KERNEL_USER_TIMES { // Information Class 4
	LARGE_INTEGER CreateTime; // Since January 1 1601
	LARGE_INTEGER ExitTime;  // Since January 1 1601 if exited, else 0
	LARGE_INTEGER KernelTime;  // 100 nanosecond intervals
	LARGE_INTEGER UserTime; // 100 nanosecond intervals
} KERNEL_USER_TIMES, *PKERNEL_USER_TIMES;

typedef struct _PROCESS_ACCESS_TOKEN { // Information Class 9
	HANDLE Token;
	HANDLE Thread; // Reserved, set to NULL
} PROCESS_ACCESS_TOKEN, *PPROCESS_ACCESS_TOKEN;

typedef struct _PROCESS_LDT_INFORMATION { // Information Class 10
	ULONG Size;
	ULONG AllocatedSize;
	struct _LDT_ENTRY *Ldt;
} PROCESS_LDT_INFORMATION, *PPROCESS_LDT_INFORMATION;

typedef enum _EMULATOR_PORT_ACCESS_TYPE {
	Uchar,
	Ushort,
	Ulong
} EMULATOR_PORT_ACCESS_TYPE, *PEMULATOR_PORT_ACCESS_TYPE;

#define EMULATOR_READ_ACCESS    0x01
#define EMULATOR_WRITE_ACCESS   0x02

typedef struct _EMULATOR_ACCESS_ENTRY {
	ULONG BasePort;
	ULONG NumConsecutivePorts;
	EMULATOR_PORT_ACCESS_TYPE AccessType;
	UCHAR AccessMode;
	UCHAR StringSupport;
	PVOID Routine;
} EMULATOR_ACCESS_ENTRY, *PEMULATOR_ACCESS_ENTRY;

typedef struct _PROCESS_IO_PORT_HANDLER_INFORMATION { // Information Class 13
	BOOLEAN Install;
	ULONG NumEntries;
	ULONG Context;
	PEMULATOR_ACCESS_ENTRY EmulatorAccessEntries;
} PROCESS_IO_PORT_HANDLER_INFORMATION, *PPROCESS_IO_PORT_HANDLER_INFORMATION;

typedef struct _POOLED_USAGE_AND_LIMITS { // Information Class 14
	ULONG PeakPagedPoolUsage;
	ULONG PagedPoolUsage;
	ULONG PagedPoolLimit;
	ULONG PeakNonPagedPoolUsage;
	ULONG NonPagedPoolUsage;
	ULONG NonPagedPoolLimit;
	ULONG PeakPagefileUsage;
	ULONG PagefileUsage;
	ULONG PagefileLimit;
} POOLED_USAGE_AND_LIMITS, *PPOOLED_USAGE_AND_LIMITS;

typedef struct _PROCESS_WS_WATCH_INFORMATION { // Information Class 15
	PVOID FaultingPc;
	PVOID FaultingVa;
} PROCESS_WS_WATCH_INFORMATION, *PPROCESS_WS_WATCH_INFORMATION;

typedef struct _PROCESS_PRIORITY_CLASS { // Information Class 18
	BOOLEAN Foreground;
	UCHAR PriorityClass; // See below
} PROCESS_PRIORITY_CLASS, *PPROCESS_PRIORITY_CLASS;

enum {
	PC_IDLE		=	1,
	PC_NORMAL	=	2,
	PC_HIGH		=	3,
	PC_REALTIME	=	4,
	PC_BELOW_NORMAL	=	5,	// Windows 2000 or later
	PC_ABOVE_NORMAL	=	6	// Windows 2000 or later
};

typedef struct _PROCESS_DEVICEMAP_INFORMATION { // Information Class 23
	union {
		struct {
			HANDLE DirectoryHandle;
		} Set;
		struct {
			ULONG DriveMap;
			UCHAR DriveType[32];
		} Query;
	};
} PROCESS_DEVICEMAP_INFORMATION, *PPROCESS_DEVICEMAP_INFORMATION;

typedef struct _PROCESS_DEVICEMAP_INFORMATION_EX { // Information Class 23
    union {
        struct {
            HANDLE DirectoryHandle;
        } Set;
        struct {
            ULONG DriveMap;
            UCHAR DriveType[ 32 ];
        } Query;
    };
    ULONG Flags;    // specifies that the query type
} PROCESS_DEVICEMAP_INFORMATION_EX, *PPROCESS_DEVICEMAP_INFORMATION_EX;

//
// PROCESS_DEVICEMAP_INFORMATION_EX flags
//

#define PROCESS_LUID_DOSDEVICES_ONLY 0x00000001

typedef struct _PROCESS_SESSION_INFORMATION { // Information Class 24
	ULONG SessionId;
} PROCESS_SESSION_INFORMATION, *PPROCESS_SESSION_INFORMATION;

typedef struct _PROCESS_HANDLE_TRACING_ENABLE {
    ULONG Flags;
} PROCESS_HANDLE_TRACING_ENABLE, *PPROCESS_HANDLE_TRACING_ENABLE;

typedef struct _PROCESS_HANDLE_TRACING_ENABLE_EX {
    ULONG Flags;
    ULONG TotalSlots;
} PROCESS_HANDLE_TRACING_ENABLE_EX, *PPROCESS_HANDLE_TRACING_ENABLE_EX;


#define PROCESS_HANDLE_TRACING_MAX_STACKS 16

typedef struct _PROCESS_HANDLE_TRACING_ENTRY {
    HANDLE Handle;
    CLIENT_ID ClientId;
    ULONG Type;
    PVOID Stacks[PROCESS_HANDLE_TRACING_MAX_STACKS];
} PROCESS_HANDLE_TRACING_ENTRY, *PPROCESS_HANDLE_TRACING_ENTRY;

typedef struct _PROCESS_HANDLE_TRACING_QUERY {
    HANDLE Handle;
    ULONG  TotalTraces;
    PROCESS_HANDLE_TRACING_ENTRY HandleTrace[1];
} PROCESS_HANDLE_TRACING_QUERY, *PPROCESS_HANDLE_TRACING_QUERY;

//
// Process debug flags - Info Class 31
//

#define PROCESS_DEBUG_FLAG_NO_DEBUG_INHERIT		0x00000001 /* Typically set after debugged once, EPROCESS.NoDebugInherit (Flags) */


//
// Mm Process Execution Flags - Info Class 34
//

#define MEM_EXECUTE_OPTION_DISABLE                 0x00000001 // disable execution of code
#define MEM_EXECUTE_OPTION_ENABLE                  0x00000002 // enable execution of code
#define MEM_EXECUTE_OPTION_DISABLE_THUNK_EMULATION 0x00000004
#define MEM_EXECUTE_OPTION_PERMANENT               0x00000008 // don't allow changes to NX after this call
#define MEM_EXECUTE_OPTION_EXECUTE_DISPATCH_ENABLE 0x00000010
#define MEM_EXECUTE_OPTION_IMAGE_DISPATCH_ENABLE   0x00000020
#define MEM_EXECUTE_OPTION_VALID_FLAGS             0x0000003F


typedef struct _CURDIR {
	UNICODE_STRING DosPath;
	HANDLE Handle;
} CURDIR, *PCURDIR;

#define RTL_USER_PROC_CURDIR_CLOSE      0x00000002
#define RTL_USER_PROC_CURDIR_INHERIT    0x00000003

typedef struct _RTL_DRIVE_LETTER_CURDIR {
	USHORT Flags;
	USHORT Length;
	ULONG TimeStamp;
	STRING DosPath;
} RTL_DRIVE_LETTER_CURDIR, *PRTL_DRIVE_LETTER_CURDIR;

#define RTL_MAX_DRIVE_LETTERS 32
#define RTL_DRIVE_LETTER_VALID (USHORT)0x0001

typedef struct _RTL_USER_PROCESS_PARAMETERS {
	union {
		//
		// Compatibility hack for applications using the older Windows NT/2000 Native API Reference definition.
		//

		//
		// This is the Nt definition, as reported by symbols...
		//

		struct {
			ULONG MaximumLength;
			ULONG Length;

			ULONG Flags;
			ULONG DebugFlags;

			HANDLE ConsoleHandle;
			ULONG  ConsoleFlags;
			HANDLE StandardInput;
			HANDLE StandardOutput;
			HANDLE StandardError;

			CURDIR CurrentDirectory;
			UNICODE_STRING DllPath;
			UNICODE_STRING ImagePathName;
			UNICODE_STRING CommandLine;
			PWSTR Environment;      // NOTE this is allocated with NtAllocateVirtualMemory; it is NOT with ProcessParameters

			ULONG StartingX;
			ULONG StartingY;
			ULONG CountX;
			ULONG CountY;
			ULONG CountCharsX;
			ULONG CountCharsY;
			ULONG FillAttribute;

			ULONG WindowFlags;
			ULONG ShowWindowFlags;
			UNICODE_STRING WindowTitle;     // ProcessParameters
			UNICODE_STRING DesktopInfo;     // ProcessParameters
			UNICODE_STRING ShellInfo;       // ProcessParameters
			UNICODE_STRING RuntimeData;     // ProcessParameters
			RTL_DRIVE_LETTER_CURDIR CurrentDirectores[ RTL_MAX_DRIVE_LETTERS ];
		};

		//
		// This is the incorrect, legacy definition.
		//

		struct {
			ULONG AllocationSize;
			ULONG Size;
			ULONG Flags_LEGACY;
			ULONG Reserved;
			LONG Console; // Console id, or one of the following: -1 = no console, -2 = allocate console
			ULONG ProcessGroup;
			HANDLE hStdInput; // STARTF_USESTDHANDLES
			HANDLE hStdOutput; // STARF_USESTDHANDLES
			HANDLE hStdError; // STARF_USESTDHANDLES
			UNICODE_STRING CurrentDirectoryName;
			HANDLE CurrentDirectoryHandle;
			UNICODE_STRING DllPath_LEGACY; // Search path
			UNICODE_STRING ImageFile;
			UNICODE_STRING CommandLine_LEGACY;
			PWSTR Environment_LEGACY;
			ULONG dwX; // STARTF_USEPOSITION
			ULONG dwY; // STARTF_USEPOSITION
			ULONG dwXSize; // STARTF_USESIZE
			ULONG dwYSize; // STARTF_USESIZE
			ULONG dwXCountChars; // New console screen buffer size, STARTF_USECOUNTCHARS
			ULONG dwYCountChars; // New console screen buffer size, STARTF_USECOUNTCHARS
			ULONG dwFillAttribute; // New console initial text and background colors, STARTF_USEFILLATTRIBUTE
			ULONG dwFlags; // Mask of used parameters
			ULONG wShowWindow; // STARTF_USESHOWWINDOW
			UNICODE_STRING WindowTitle_LEGACY;
			UNICODE_STRING Desktop;
			UNICODE_STRING Reserved2;
			UNICODE_STRING Reserved3;
		};
	};
} RTL_USER_PROCESS_PARAMETERS, *PRTL_USER_PROCESS_PARAMETERS;

#define _PROCESS_PARAMETERS _RTL_USER_PROCESS_PARAMETERS
#define PROCESS_PARAMETERS RTL_USER_PROCESS_PARAMETERS
#define PPROCESS_PARAMETERS PRTL_USER_PROCESS_PARAMETERS

//
// Flags for RTL_USER_PROCESS_PARAMETERS
//

#define RTL_USER_PROC_PARAMS_NORMALIZED		0x00000001
#define RTL_USER_PROC_PROFILE_USER			0x00000002
#define RTL_USER_PROC_PROFILE_KERNEL		0x00000004
#define RTL_USER_PROC_PROFILE_SERVER		0x00000008
#define RTL_USER_PROC_RESERVE_1MB			0x00000020
#define RTL_USER_PROC_RESERVE_16MB			0x00000040
#define RTL_USER_PROC_CASE_SENSITIVE		0x00000080
#define RTL_USER_PROC_DISABLE_HEAP_DECOMMIT	0x00000100

// Used with RtlQueryProcessDebugInformation
enum {
	PDI_MODULES	=	0x01,	// The loaded modules of the process
	PDI_BACKTRACE	=	0x02,	// The heap stack back traces
	PDI_HEAPS	=	0x04,	// The heaps of the process
	PDI_HEAP_TAGS	=	0x08,	// The heap tags
	PDI_HEAP_BLOCKS	=	0x10,	// The heap blocks
	PDI_LOCKS	=	0x20	// The locks created by the process
};

typedef struct _DEBUG_BUFFER {
	HANDLE SectionHandle;
	PVOID SectionBase;
	PVOID RemoteSectionBase;
	ULONG SectionBaseDelta;
	HANDLE EventPairHandle;
	ULONG Unknown[2];
	HANDLE RemoteThreadHandle;
	ULONG InfoClassMask;
	ULONG SizeOfInfo;
	ULONG AllocatedSize;
	ULONG SectionSize;
	PVOID ModuleInformation;
	PVOID BackTraceInformation;
	PVOID HeapInformation;
	PVOID LockInformation;
	PVOID Reserved[8];
} DEBUG_BUFFER, *PDEBUG_BUFFER;

typedef struct _DEBUG_MODULE_INFORMATION { // c.f. SYSTEM_MODULE_INFORMATION
	ULONG Reserved[2];
	ULONG Base;
	ULONG Size;
	ULONG Flags; // See below
	USHORT Index;
	USHORT Unknown;
	USHORT LoadCount;
	USHORT ModuleNameOffset;
	CHAR ImageName[256];
} DEBUG_MODULE_INFORMATION, *PDEBUG_MODULE_INFORMATION;

// Loader flags for DEBUG_MODULE_INFORMATION
enum {
	LDRP_STATIC_LINK		=	0x00000002,
	LDRP_IMAGE_DLL			=	0x00000004,
	LDRP_LOAD_IN_PROGRESS		=	0x00001000,
	LDRP_UNLOAD_IN_PROGRESS		=	0x00002000,
	LDRP_ENTRY_PROCESSED		=	0x00004000,
	LDRP_ENTRY_INSERTED		=	0x00008000,
	LDRP_CURRENT_LOAD		=	0x00010000,
	LDRP_FAILED_BUILTIN_LOAD	=	0x00020000,
	LDRP_DONT_CALL_FOR_THREADS	=	0x00040000,
	LDRP_PROCESS_ATTACH_CALLED	=	0x00080000,
	LDRP_DEBUG_SYMBOLS_LOADED	=	0x00100000,
	LDRP_IMAGE_NOT_AT_BASE		=	0x00200000,
	LDRP_WX86_IGNORE_MACHINETYPE	=	0x00400000
};

// The flags PDI_HEAP_TAGS and PDI_HEAP_BLOCKS must be specified in addition
// to PDI_HEAPS if information on heap tags or blocks is required.
typedef struct _DEBUG_HEAP_INFORMATION {
	ULONG Base;
	ULONG Flags;
	USHORT Granularity;
	USHORT Unknown;
	ULONG Allocated;
	ULONG Committed;
	ULONG TagCount;
	ULONG BlockCount;
	ULONG Reserved[7];
	PVOID Tags;
	PVOID Blocks;
} DEBUG_HEAP_INFORMATION, *PDEBUG_HEAP_INFORMATION;

typedef struct _DEBUG_LOCK_INFORMATION { // c.f. SYSTEM_LOCK_INFORMATION
	PVOID Address;
	USHORT Type;
	USHORT CreatorBackTraceIndex;
	ULONG OwnerThreadId;
	ULONG ActiveCount; // Critical sections start at -1, resources at 0
	ULONG ContentionCount;
	ULONG EntryCount; // Entries which required a wait
	ULONG RecursionCount;
	ULONG NumberOfSharedWaiters;
	ULONG NumberOfExclusiveWaiters;
} DEBUG_LOCK_INFORMATION, *PDEBUG_LOCK_INFORMATION;

enum {
	NtPortMaxDataSize		=	0x104,
	NtPortMaxMessageSize	=	0x148
};

enum {
	NtPortValidAttributes	=	OBJ_CASE_INSENSITIVE
};

#pragma warning(disable:4200)
typedef struct _PORT_MESSAGE {
	union {
		//
		// Correct definition
		//

		struct {
			union {
				struct {
					CSHORT DataLength;
					CSHORT TotalLength;
				} s1;
				ULONG Length;
			} u1;
			union {
				struct {
					CSHORT Type;
					CSHORT DataInfoOffset;
				} s2;
				ULONG ZeroInit;
			} u2;
			union {
				CLIENT_ID ClientId;
				double DoNotUseThisField;	// Alignment
			};
			ULONG MessageId;
			union {
				ULONG ClientViewSize;	// Only valid on LPC_CONNECTION_REQUEST message
				ULONG CallbackId;		// Only valid on LPC_REQUEST message
			};
		//  UCHAR Data[];
		};

		//
		// Old definition
		//
		struct {
			USHORT DataSize;
			USHORT MessageSize;
			USHORT MessageType;
			USHORT VirtualRangesOffset;
			CLIENT_ID ClientId_LEGACY;
			ULONG MessageId_LEGACY;
			ULONG SectionSize;
			//	UCHAR Data [];
		};
	};
} PORT_MESSAGE,*PPORT_MESSAGE;

//
// OBSOLETE
//

typedef struct _PORT_MESSAGE_DATA {
	USHORT DataSize;
	USHORT MessageSize;
	USHORT MessageType;
	USHORT VirtualRangesOffset;
	CLIENT_ID ClientId;
	ULONG MessageId;
	ULONG SectionSize;
	UCHAR Data [];
} PORT_MESSAGE_DATA, *PPORT_MESSAGE_DATA;
#pragma warning(default:4200)

typedef enum _LPC_TYPE {
	LPC_NEW_MESSAGE,//A new message
	LPC_REQUEST,//A request message
	LPC_REPLY,//A reply to a request message
	LPC_DATAGRAM,//
	LPC_LOST_REPLY,//
	LPC_PORT_CLOSED,//Sent when port is deleted
	LPC_CLIENT_DIED,//Messages to thread termination ports
	LPC_EXCEPTION,//Messages to thread exception port
	LPC_DEBUG_EVENT,//Messages to thread debug port
	LPC_ERROR_EVENT,//Used by ZwRaiseHardError
	LPC_CONNECTION_REQUEST //Used by ZwConnectPort
} LPC_TYPE;

typedef struct _PORT_DATA_ENTRY {
	PVOID Base;
	ULONG Size;
} PORT_DATA_ENTRY, *PPORT_DATA_ENTRY;

typedef struct _PORT_DATA_INFORMATION {
	ULONG CountDataEntries;
	PORT_DATA_ENTRY DataEntries[1];
} PORT_DATA_INFORMATION, *PPORT_DATA_INFORMATION;

#define PORT_MAXIMUM_MESSAGE_LENGTH 256

typedef struct _LPC_CLIENT_DIED_MSG {
	PORT_MESSAGE PortMsg;
	LARGE_INTEGER CreateTime;
} LPC_CLIENT_DIED_MSG, *PLPC_CLIENT_DIED_MSG;

#if _WIN32_WINNT <= 0x0400
#define MAXIMUM_HARDERROR_PARAMETERS 4
#else
#define MAXIMUM_HARDERROR_PARAMETERS 5
#endif

#define HARDERROR_OVERRIDE_ERRORMODE   0x10000000
#define HARDERROR_FLAGS_DEFDESKTOPONLY 0x00020000
#define HARDERROR_PARAMETERS_FLAGSPOS 4

typedef struct _HARDERROR_MSG {
	PORT_MESSAGE h;
	NTSTATUS Status;
	LARGE_INTEGER ErrorTime;
	ULONG ValidResponseOptions;
	ULONG Response;
	ULONG NumberOfParameters;
	ULONG UnicodeStringParameterMask;
	ULONG Parameters[MAXIMUM_HARDERROR_PARAMETERS];
} HARDERROR_MSG, *PHARDERROR_MSG;

typedef struct _PORT_VIEW {
	union {
		struct {
			ULONG Length;
			HANDLE SectionHandle;
			ULONG SectionOffset;
			ULONG ViewSize;
			PVOID ViewBase;
			PVOID ViewRemoteBase;
		};

		//
		// OBSOLETE
		//

		struct {
			ULONG Length_LEGACY;
			HANDLE SectionHandle_LEGACY;
			ULONG SectionOffset_LEGACY;
			ULONG ViewSize_LEGACY;
			PVOID ViewBase_LEGACY;
			PVOID TargetViewBase;
		};
	};
} PORT_VIEW, *PPORT_VIEW;

typedef struct _REMOTE_PORT_VIEW {
	ULONG Length;
	ULONG ViewSize;
	PVOID ViewBase;
} REMOTE_PORT_VIEW, *PREMOTE_PORT_VIEW;

#define _PORT_SECTION_READ _PORT_VIEW
#define PORT_SECTION_READ PORT_VIEW
#define PPORT_SECTION_READ PPORT_VIEW

#define _PORT_SECTION_WRITE _REMOTE_PORT_VIEW
#define PORT_SECTION_WRITE REMOTE_PORT_VIEW
#define PPORT_SECTION_WRITE PREMOTE_PORT_VIEW

typedef enum _PORT_INFORMATION_CLASS {
	PortBasicInformation
} PORT_INFORMATION_CLASS;

typedef struct _PORT_BASIC_INFORMATION {
#ifndef __cplusplus
	CHAR Unused[0]; /* MS C Compiler requires this for some reason... */
#endif
} PORT_BASIC_INFORMATION,*PPORT_BASIC_INFORMATION;

#ifndef _NTTYPES_NO_WINNT

typedef enum _TOKEN_INFORMATION_CLASS { //		Query	Set		Notes
	TokenUser = 1,						// 1	Y		N
	TokenGroups,						// 2	Y		N
	TokenPrivileges,					// 3	Y		N
	TokenOwner,							// 4	Y		Y
	TokenPrimaryGroup,					// 5	Y		Y
	TokenDefaultDacl,					// 6	Y		Y
	TokenSource,						// 7	Y		N
	TokenType,							// 8	Y		N
	TokenImpersonationLevel,			// 9	Y		N
	TokenStatistics,					// 10	Y		N
	TokenRestrictedSids,				// 11	Y		N
	TokenSessionId,						// 12	Y		Y		ULONG
	TokenGroupsAndPrivileges,
	TokenSessionReference,
	TokenSandBoxInert,
	TokenAuditPolicy,
	TokenOrigin,
	MaxTokenInfoClass
} TOKEN_INFORMATION_CLASS;

typedef struct _TOKEN_USER { // Information Class 1
	SID_AND_ATTRIBUTES User;
} TOKEN_USER, *PTOKEN_USER;

typedef struct _TOKEN_GROUPS { // Information Classes 2 and 11
	ULONG GroupCount;
	SID_AND_ATTRIBUTES Groups[ANYSIZE_ARRAY];
} TOKEN_GROUPS, *PTOKEN_GROUPS;

typedef struct _TOKEN_PRIVILEGES { // Information Class 3
	ULONG PrivilegeCount;
	LUID_AND_ATTRIBUTES Privileges[ANYSIZE_ARRAY];
} TOKEN_PRIVILEGES, *PTOKEN_PRIVILEGES;

typedef struct _TOKEN_OWNER { // Information Class 4
	PSID Owner;
} TOKEN_OWNER, *PTOKEN_OWNER;

typedef struct _TOKEN_PRIMARY_GROUP { // Information Class 5
	PSID PrimaryGroup;
} TOKEN_PRIMARY_GROUP, *PTOKEN_PRIMARY_GROUP;

typedef struct _TOKEN_DEFAULT_DACL { // Information Class 6
	PACL DefaultDacl;
} TOKEN_DEFAULT_DACL, *PTOKEN_DEFAULT_DACL;

typedef struct _TOKEN_SOURCE { // Information Class 7
	CHAR SourceName[8];
	LUID SourceIdentifier;
} TOKEN_SOURCE, *PTOKEN_SOURCE;

typedef struct _TOKEN_GROUPS_AND_PRIVILEGES { // Information Class 13
    ULONG SidCount;
    ULONG SidLength;
    PSID_AND_ATTRIBUTES Sids;
    ULONG RestrictedSidCount;
    ULONG RestrictedSidLength;
    PSID_AND_ATTRIBUTES RestrictedSids;
    ULONG PrivilegeCount;
    ULONG PrivilegeLength;
    PLUID_AND_ATTRIBUTES Privileges;
    LUID AuthenticationId;
} TOKEN_GROUPS_AND_PRIVILEGES, *PTOKEN_GROUPS_AND_PRIVILEGES;

//
// Valid bits for each TOKEN_AUDIT_POLICY policy mask field.
//

#define TOKEN_AUDIT_SUCCESS_INCLUDE 0x1
#define TOKEN_AUDIT_SUCCESS_EXCLUDE 0x2
#define TOKEN_AUDIT_FAILURE_INCLUDE 0x4
#define TOKEN_AUDIT_FAILURE_EXCLUDE 0x8

#define VALID_AUDIT_POLICY_BITS (TOKEN_AUDIT_SUCCESS_INCLUDE | \
                                 TOKEN_AUDIT_SUCCESS_EXCLUDE | \
                                 TOKEN_AUDIT_FAILURE_INCLUDE | \
                                 TOKEN_AUDIT_FAILURE_EXCLUDE)

#define VALID_TOKEN_AUDIT_POLICY_ELEMENT(P) ((((P).PolicyMask & ~VALID_AUDIT_POLICY_BITS) == 0) && \
                                             ((P).Category <= AuditEventMaxType))

typedef struct _TOKEN_AUDIT_POLICY_ELEMENT {
    ULONG Category;
    ULONG PolicyMask;
} TOKEN_AUDIT_POLICY_ELEMENT, *PTOKEN_AUDIT_POLICY_ELEMENT;

typedef struct _TOKEN_AUDIT_POLICY { // Information Class 16
    ULONG PolicyCount;
    TOKEN_AUDIT_POLICY_ELEMENT Policy[ANYSIZE_ARRAY];
} TOKEN_AUDIT_POLICY, *PTOKEN_AUDIT_POLICY;

#define PER_USER_AUDITING_POLICY_SIZE(p) \
    ( sizeof(TOKEN_AUDIT_POLICY) + (((p)->PolicyCount > ANYSIZE_ARRAY) ? (sizeof(TOKEN_AUDIT_POLICY_ELEMENT) * ((p)->PolicyCount - ANYSIZE_ARRAY)) : 0) )
#define PER_USER_AUDITING_POLICY_SIZE_BY_COUNT(C) \
    ( sizeof(TOKEN_AUDIT_POLICY) + (((C) > ANYSIZE_ARRAY) ? (sizeof(TOKEN_AUDIT_POLICY_ELEMENT) * ((C) - ANYSIZE_ARRAY)) : 0) )


typedef struct _TOKEN_ORIGIN { // Information Class 17
    LUID OriginatingLogonSession ;
} TOKEN_ORIGIN, * PTOKEN_ORIGIN ;



typedef enum _TOKEN_TYPE { // Information Class 8
	TokenPrimary = 1,
	TokenImpersonation
} TOKEN_TYPE, *PTOKEN_TYPE;

// _SECURITY_IMPERSONATION_LEVEL // Information Class 9
typedef struct _TOKEN_STATISTICS { // Information Class 10
	LUID TokenId;
	LUID AuthenticationId;
	LARGE_INTEGER ExpirationTime;
	TOKEN_TYPE TokenType;
	SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
	ULONG DynamicCharged;
	ULONG DynamicAvailable;
	ULONG GroupCount;
	ULONG PrivilegeCount;
	LUID ModifiedId;
} TOKEN_STATISTICS, *PTOKEN_STATISTICS;

typedef enum _JOBOBJECTINFOCLASS {				// Query Set
	JobObjectBasicAccountingInformation	=1,		// Y	 N
	JobObjectBasicLimitInformation,				// Y	 Y
	JobObjectBasicProcessIdList,				// Y	 N
	JobObjectBasicUIRestrictions,				// Y	 Y
	JobObjectSecurityLimitInformation,			// Y	 Y
	JobObjectEndOfJobTimeInformation,			// N	 Y
	JobObjectAssociateCompletionPortInformation,// N	 Y
	JobObjectBasicAndIoAccountingInformation,	// Y	 N
	JobObjectExtendedLimitInformation,			// Y	 Y
	JobObjectJobSetInformation					// Y	 Y
} JOBOBJECTINFOCLASS;

typedef struct _JOBOBJECT_BASIC_ACCOUNTING_INFORMATION {
	LARGE_INTEGER TotalUserTime;
	LARGE_INTEGER TotalKernelTime;
	LARGE_INTEGER ThisPeriodTotalUserTime;
	LARGE_INTEGER ThisPeriodTotalKernelTime;
	ULONG TotalPageFaultCount;
	ULONG TotalProcesses;
	ULONG ActiveProcesses;
	ULONG TotalTerminatedProcesses;
} JOBOBJECT_BASIC_ACCOUNTING_INFORMATION,
*PJOBOBJECT_BASIC_ACCOUNTING_INFORMATION;

typedef struct _JOBOBJECT_BASIC_LIMIT_INFORMATION {
	LARGE_INTEGER PerProcessUserTimeLimit;
	LARGE_INTEGER PerJobUserTimeLimit;
	ULONG LimitFlags;
	ULONG MinimumWorkingSetSize;
	ULONG MaximumWorkingSetSize;
	ULONG ActiveProcessLimit;
	ULONG Affinity;
	ULONG PriorityClass; // PC_xxxxx
	ULONG SchedulingClass;
}JOBOBJECT_BASIC_LIMIT_INFORMATION,*PJOBOBJECT_BASIC_LIMIT_INFORMATION;

typedef struct _JOBOBJECT_BASIC_PROCESS_ID_LIST {
	ULONG NumberOfAssignedProcesses;
	ULONG NumberOfProcessIdsInList;
	ULONG_PTR ProcessIdList [1 ];
}JOBOBJECT_BASIC_PROCESS_ID_LIST,*PJOBOBJECT_BASIC_PROCESS_ID_LIST;

typedef struct _JOBOBJECT_BASIC_UI_RESTRICTIONS {
	ULONG UIRestrictionsClass;
}JOBOBJECT_BASIC_UI_RESTRICTIONS,*PJOBOBJECT_BASIC_UI_RESTRICTIONS;

typedef struct _JOBOBJECT_SECURITY_LIMIT_INFORMATION {
	ULONG SecurityLimitFlags;
	HANDLE JobToken;
	PTOKEN_GROUPS SidsToDisable;
	PTOKEN_PRIVILEGES PrivilegesToDelete;
	PTOKEN_GROUPS RestrictedSids;
}JOBOBJECT_SECURITY_LIMIT_INFORMATION,
*PJOBOBJECT_SECURITY_LIMIT_INFORMATION;

typedef struct _JOBOBJECT_END_OF_JOB_TIME_INFORMATION {
	ULONG EndOfJobTimeAction;
}JOBOBJECT_END_OF_JOB_TIME_INFORMATION,
*PJOBOBJECT_END_OF_JOB_TIME_INFORMATION;

typedef struct _JOBOBJECT_ASSOCIATE_COMPLETION_PORT {
	PVOID CompletionKey;
	HANDLE CompletionPort;
}JOBOBJECT_ASSOCIATE_COMPLETION_PORT,*PJOBOBJECT_ASSOCIATE_COMPLETION_PORT;

typedef struct JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION {
	JOBOBJECT_BASIC_ACCOUNTING_INFORMATION BasicInfo;
	IO_COUNTERS IoInfo;
}JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION,
*PJOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION;

typedef struct _JOBOBJECT_EXTENDED_LIMIT_INFORMATION {
	JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
	IO_COUNTERS IoInfo;
	ULONG ProcessMemoryLimit;
	ULONG JobMemoryLimit;
	ULONG PeakProcessMemoryUsed;
	ULONG PeakJobMemoryUsed;
}JOBOBJECT_EXTENDED_LIMIT_INFORMATION,
*PJOBOBJECT_EXTENDED_LIMIT_INFORMATION;

#if _WIN32_WINNT >= 0x0501

typedef struct _JOBOBJECT_JOBSET_INFORMATION {
	DWORD MemberLevel;
} JOBOBJECT_JOBSET_INFORMATION, *PJOBOBJECT_JOBSET_INFORMATION;

#endif



#endif

typedef enum _WAIT_TYPE {
	WaitAll, // Wait for any handle to be signaled
	WaitAny // Wait for all handles to be signaled
} WAIT_TYPE, *PWAIT_TYPE;

typedef VOID (NTAPI *PTIMER_APC_ROUTINE)(PVOID TimerContext,
										 ULONG TimerLowValue,
						 				 ULONG TimerHighValue);

typedef enum _TIMER_INFORMATION_CLASS {
	TimerBasicInformation
} TIMER_INFORMATION_CLASS;

typedef struct _TIMER_BASIC_INFORMATION {
	LARGE_INTEGER TimeRemaining;
	BOOLEAN SignalState;
} TIMER_BASIC_INFORMATION, *PTIMER_BASIC_INFORMATION;

typedef enum _EVENT_TYPE {
	NotificationEvent, // A manual-reset event
	SynchronizationEvent // An auto-reset event
} EVENT_TYPE;

typedef enum _EVENT_INFORMATION_CLASS {
	EventBasicInformation
} EVENT_INFORMATION_CLASS;

typedef struct _EVENT_BASIC_INFORMATION {
	EVENT_TYPE EventType;
	LONG SignalState;
} EVENT_BASIC_INFORMATION, *PEVENT_BASIC_INFORMATION;

typedef enum _SEMAPHORE_INFORMATION_CLASS {
	SemaphoreBasicInformation
} SEMAPHORE_INFORMATION_CLASS;

typedef struct _SEMAPHORE_BASIC_INFORMATION {
	LONG CurrentCount;
	LONG MaximumCount;
} SEMAPHORE_BASIC_INFORMATION, *PSEMAPHORE_BASIC_INFORMATION;

typedef enum _MUTANT_INFORMATION_CLASS {
	MutantBasicInformation
} MUTANT_INFORMATION_CLASS;

typedef struct _MUTANT_BASIC_INFORMATION {
	LONG SignalState;
	BOOLEAN Owned;
	BOOLEAN Abandoned;
} MUTANT_BASIC_INFORMATION, *PMUTANT_BASIC_INFORMATION;

typedef enum _IO_COMPLETION_INFORMATION_CLASS {
	IoCompletionBasicInformation
} IO_COMPLETION_INFORMATION_CLASS;

typedef struct _IO_COMPLETION_BASIC_INFORMATION {
	LONG SignalState; // Positive indicates signaled
} IO_COMPLETION_BASIC_INFORMATION, *PIO_COMPLETION_BASIC_INFORMATION;

typedef enum _OBJECT_INFORMATION_CLASS {	//		Query	Set	Notes
	ObjectBasicInformation,					// 0	Y		N
	ObjectNameInformation,					// 1	Y		N
	ObjectTypeInformation,					// 2	Y		N
	ObjectAllTypesInformation,				// 3	Y		N	Handle ignored, array of DWORD-aligned OBJECT_TYPE_INFORMATION structures
	ObjectHandleInformation,				// 4	Y		Y
	ObjectSessionInformation,               // 5    N       Y   Data ignored, handle must be a directory object (any access), requires SE_TCB_PRIVILEGE, sets directory sessionid to current sessionid
	MaxObjectInfoClass
} OBJECT_INFORMATION_CLASS;

typedef struct _OBJECT_BASIC_INFORMATION {//Information Class 0
	ULONG Attributes;
	ACCESS_MASK GrantedAccess;
	ULONG HandleCount;
	ULONG PointerCount;
	ULONG PagedPoolUsage;
	ULONG NonPagedPoolUsage;
	ULONG Reserved [3 ];
	ULONG NameInformationLength;
	ULONG TypeInformationLength;
	ULONG SecurityDescriptorLength;
	LARGE_INTEGER CreateTime;
} OBJECT_BASIC_INFORMATION,*POBJECT_BASIC_INFORMATION;

#ifndef HANDLE_FLAG_INHERIT
#define HANDLE_FLAG_INHERIT 0x01
#endif
#ifndef HANDLE_FLAG_PROTECT_FROM_CLOSE
#define HANDLE_FLAG_PROTECT_FROM_CLOSE 0x02
#endif

#ifndef __IDA__
enum { // Other handle flags
	PERMANENT		=	0x10,
	EXCLUSIVE		=	0x20 // (different encoding than in SYSTEM_OBJECT_INFORMATION)
};
#endif

typedef struct _OBJECT_NAME_INFORMATION {//Information Class 1
	UNICODE_STRING Name;
} OBJECT_NAME_INFORMATION,*POBJECT_NAME_INFORMATION;

typedef struct _OBJECT_TYPE_INFORMATION {//Information Class 2
	UNICODE_STRING Name;
	ULONG ObjectCount;
	ULONG HandleCount;
	ULONG Reserved1 [4 ];
	ULONG PeakObjectCount;
	ULONG PeakHandleCount;
	ULONG Reserved2 [4 ];
	ULONG InvalidAttributes;
	GENERIC_MAPPING GenericMapping;
	ULONG ValidAccess;
	UCHAR Unknown;
	BOOLEAN MaintainHandleDatabase;
	POOL_TYPE PoolType;
	ULONG PagedPoolUsage;
	ULONG NonPagedPoolUsage;
} OBJECT_TYPE_INFORMATION,*POBJECT_TYPE_INFORMATION;

typedef struct _OBJECT_ALL_TYPES_INFORMATION {//Information Class 3
	ULONG NumberOfTypes;
	OBJECT_TYPE_INFORMATION TypeInformation;
} OBJECT_ALL_TYPES_INFORMATION,*POBJECT_ALL_TYPES_INFORMATION;

typedef struct _OBJECT_HANDLE_ATTRIBUTE_INFORMATION {//Information Class 4
	BOOLEAN Inherit;
	BOOLEAN ProtectFromClose;
} OBJECT_HANDLE_ATTRIBUTE_INFORMATION,*POBJECT_HANDLE_ATTRIBUTE_INFORMATION;

typedef struct _DIRECTORY_BASIC_INFORMATION {
	UNICODE_STRING ObjectName;
	UNICODE_STRING ObjectTypeName;
} DIRECTORY_BASIC_INFORMATION,*PDIRECTORY_BASIC_INFORMATION;

typedef enum _MEMORY_INFORMATION_CLASS {
	MemoryBasicInformation,
	MemoryWorkingSetList,
	MemorySectionName,
	MemoryBasicVlmInformation
} MEMORY_INFORMATION_CLASS;

#ifndef _NTTYPES_NO_WINNT

typedef struct _MEMORY_BASIC_INFORMATION {//Information Class 0
	PVOID BaseAddress;
	PVOID AllocationBase;
	ULONG AllocationProtect;
	ULONG RegionSize;
	ULONG State;
	ULONG Protect;
	ULONG Type;
} MEMORY_BASIC_INFORMATION,*PMEMORY_BASIC_INFORMATION;

#endif

typedef struct _MEMORY_WORKING_SET_LIST {//Information Class 1
	ULONG NumberOfPages;
	ULONG WorkingSetList [1 ];
} MEMORY_WORKING_SET_LIST,*PMEMORY_WORKING_SET_LIST;

enum {
	WSLE_PAGE_READONLY			=	0x001,	// Page is read only
	WSLE_PAGE_EXECUTE			=	0x002,	// Page is executable
	WSLE_PAGE_READWRITE			=	0x004,	// Page is writeable
	WSLE_PAGE_EXECUTE_READ		=	0x003,
	WSLE_PAGE_WRITECOPY			=	0x005,	// Page should be copied on write
	WSLE_PAGE_EXECUTE_READWRITE	=	0x006,
	WSLE_PAGE_EXECUTE_WRITECOPY	=	0x007,	// Page should be copied on write
	WSLE_PAGE_SHARE_COUNT_MASK	=	0x0E0,
	WSLE_PAGE_SHAREABLE			=	0x100	//Page is shareable
};

typedef struct _MEMORY_SECTION_NAME {//Information Class 2
	UNICODE_STRING SectionFileName;
} MEMORY_SECTION_NAME,*PMEMORY_SECTION_NAME;

enum {
	LOCK_VM_IN_WSL	=	0x01,	 // Lock page in working set list
	LOCK_VM_IN_RAM	=	0x02	 // Lock page in physical memory
};

enum {
	SEC_BASED		=	0x00200000,	// Section should be mapped at same address in each process
	SEC_NO_CHANGE	=	0x00400000, // Changes to protection of section pages are disabled
#if !defined(SEC_VLM) && !defined(__IDA__)
	SEC_VLM			=	0x02000000	// Map section in VLM region
#endif
};

typedef enum _SECTION_INFORMATION_CLASS {
	SectionBasicInformation,
	SectionImageInformation
} SECTION_INFORMATION_CLASS;

typedef struct _SECTION_BASIC_INFORMATION {//Information Class 0
	union {
		// Correct
		struct {
			PVOID BaseAddress;
			ULONG AllocationAttributes;
			LARGE_INTEGER MaximumSize;
		};
		// Old
		struct {
			PVOID BaseAddress_LEGACY;
			ULONG Attributes;
			LARGE_INTEGER Size;
		};
	};
} SECTION_BASIC_INFORMATION,*PSECTION_BASIC_INFORMATION;

typedef struct _SECTION_IMAGE_INFORMATION {//Information Class 1
	union {
		// Correct as of Windows Server 2003 ntoskrnl symbols
		struct {
			PVOID TransferAddress;
			ULONG ZeroBits;
			ULONG MaximumStackSize;
			ULONG CommittedStackSize;
			ULONG SubSystemType;

			union {
				struct {
					USHORT SubSystemMinorVersion;
					USHORT SubSystemMajorVersion;
				};

				ULONG SubSystemVersion;
			};

			ULONG_PTR GpValue;
			USHORT ImageCharacteristics;
			USHORT DllCharacteristics;
			USHORT Machine;
			BOOLEAN ImageContainsCode;
			BOOLEAN Spare1;
			ULONG LoaderFlags;
			ULONG Reserved[2];
		};
		// Incorrect, old
		struct {
			PVOID EntryPoint;
			ULONG Unknown1;
			ULONG StackReserve;
			ULONG StackCommit;
			ULONG Subsystem;
			USHORT MinorSubsystemVersion;
			USHORT MajorSubsystemVersion;
			ULONG Unknown2;
			ULONG Characteristics;
			USHORT ImageNumber;
			BOOLEAN Executable;
			UCHAR Unknown3;
			ULONG Unknown4 [3 ];
		};
	};
} SECTION_IMAGE_INFORMATION,*PSECTION_IMAGE_INFORMATION;

typedef enum _SECTION_INHERIT {
	ViewShare =	1,
	ViewUnmap =	2
} SECTION_INHERIT;

enum {
	AT_EXTENDABLE_FILE		=	0x00002000,	// Allows view to exceed section size
	AT_RESERVED				=	0x20000000, // Valid but ignored
	AT_ROUND_TO_PAGE		=	0x40000000	// Adjust address and size if necessary
};

#define MEM_DOS_LIM      0x40000000

enum {
	THREAD_ALERT			=	0x00000004	// Alert thread
};

typedef struct _USER_STACK {
	PVOID FixedStackBase;
	PVOID FixedStackLimit;
	PVOID ExpandableStackBase;
	PVOID ExpandableStackLimit;
	PVOID ExpandableStackBottom;
} USER_STACK, *PUSER_STACK;

typedef enum _THREADINFOCLASS {		//		Query	Set		Notes
	ThreadBasicInformation,			// 0	Y		N
	ThreadTimes,					// 1	Y		N
	ThreadPriority,					// 2	N		Y		KAFFINITY
	ThreadBasePriority,				// 3	N		Y		LONG
	ThreadAffinityMask,				// 4	N		Y		KAFFINITY
	ThreadImpersonationToken,		// 5	N		Y		HANDLE
	ThreadDescriptorTableEntry,		// 6	Y		N
	ThreadEnableAlignmentFaultFixup,// 7	N		Y		BOOLEAN
	ThreadEventPair,				// 8	N		Y		HANDLE, removed in Windows 2000 and later (invalid infoclass)
	ThreadQuerySetWin32StartAddress,// 9	Y		Y		PVOID, x86: Initially eax, also LpcReceivedMessageId
	ThreadZeroTlsCell,				// 10	N		Y		ULONG, Zeroes TLS cell at specified index
	ThreadPerformanceCount,			// 11	Y		N		LARGE_INTEGER, Always 0
	ThreadAmILastThread,			// 12	Y		N		ULONG
	ThreadIdealProcessor,			// 13	N		Y		ULONG, MAXIMUM_PROCESSORS sets none
	ThreadPriorityBoost,			// 14	Y		Y		ULONG, boolean: enabled
	ThreadSetTlsArrayAddress,		// 15	N		Y		PVOID, address of TLS array
	ThreadIsIoPending,				// 16	Y		N		ULONG, boolean: outstanding IRPs
	ThreadHideFromDebugger,			// 17	N		Y		Use NULL pointer and zero disables debug events
	ThreadBreakOnTermination,		// 18	Y		Y		Terminate system on exit, ULONG/BOOLEAN interpretation, SeTcbPrivilege,
	ThreadSwitchLegacyState,        // 19   N       ?       x64 only, Thread->Tcb.NpxState set to LEGACY_STATE_SWITCH, no data supplied
	ThreadIsTerminated,             // 20   Y       N       ULONG, Terminated ? TRUE : FALSE
	MaxThreadInfoClass
} THREADINFOCLASS;

typedef struct _THREAD_BASIC_INFORMATION { // Information Class 0
	NTSTATUS ExitStatus;
	PNT_TIB TebBaseAddress;
	CLIENT_ID ClientId;
	KAFFINITY AffinityMask;
	KPRIORITY Priority;
	KPRIORITY BasePriority;
} THREAD_BASIC_INFORMATION, *PTHREAD_BASIC_INFORMATION;

/*
typedef struct _KERNEL_USER_TIMES { // Information Class 1
	LARGE_INTEGER CreateTime;
	LARGE_INTEGER ExitTime;
	LARGE_INTEGER KernelTime;
	LARGE_INTEGER UserTime;
} KERNEL_USER_TIMES, *PKERNEL_USER_TIMES;
*/

typedef VOID (NTAPI *PKNORMAL_ROUTINE)(PVOID ApcContext,
									   PVOID Argument1,
									   PVOID Argument2);

/*
typedef enum _KPROFILE_SOURCE {
	ProfileTime
} KPROFILE_SOURCE;
*/

// For ntddk.h compatibility
#ifndef FILE_SUPERSEDED
enum {
	FILE_SUPERSEDED		=	0x00000000,
	FILE_OPENED			=	0x00000001,
	FILE_CREATED		=	0x00000002,
	FILE_OVERWRITTEN	=	0x00000003,
	FILE_EXISTS			=	0x00000004,
	FILE_DOES_NOT_EXIST	=	0x00000005
};
#endif

// For ntddk.h compatibility
#ifndef FILE_SUPERSEDE
enum {
	FILE_SUPERSEDE				=	0x00000000,
	FILE_OPEN					=	0x00000001,
	FILE_CREATE					=	0x00000002,
	FILE_OPEN_IF				=	0x00000003,
	FILE_OVERWRITE				=	0x00000004,
	FILE_OVERWRITE_IF			=	0x00000005
};

enum {
	FILE_MAXIMUM_DISPOSITION	=	0x00000005
};
#endif

#ifndef _NTTYPES_NO_WINNT

typedef union _FILE_SEGMENT_ELEMENT {
	PVOID Buffer;
	ULONGLONG Alignment;
} FILE_SEGMENT_ELEMENT, *PFILE_SEGMENT_ELEMENT;


#endif

//
// Define the create/open option flags
//

// For ntddk.h compatibility
#ifndef FILE_DIRECTORY_FILE
enum {
	FILE_DIRECTORY_FILE					=	0x00000001,
	FILE_WRITE_THROUGH					=	0x00000002,
	FILE_SEQUENTIAL_ONLY				=	0x00000004,
	FILE_NO_INTERMEDIATE_BUFFERING		=	0x00000008,
	FILE_SYNCHRONOUS_IO_ALERT			=	0x00000010,
	FILE_SYNCHRONOUS_IO_NONALERT		=	0x00000020,
	FILE_NON_DIRECTORY_FILE				=	0x00000040,
	FILE_CREATE_TREE_CONNECTION			=	0x00000080,
	FILE_COMPLETE_IF_OPLOCKED			=	0x00000100,
	FILE_NO_EA_KNOWLEDGE				=	0x00000200,
	FILE_OPEN_FOR_RECOVERY				=	0x00000400,
	FILE_RANDOM_ACCESS					=	0x00000800,
	FILE_DELETE_ON_CLOSE				=	0x00001000,
	FILE_OPEN_BY_FILE_ID				=	0x00002000,
	FILE_OPEN_FOR_BACKUP_INTENT			=	0x00004000,
	FILE_NO_COMPRESSION					=	0x00008000,
	FILE_RESERVE_OPFILTER				=	0x00010000,
	FILE_OPEN_REPARSE_POINT				=	0x00020000,
	FILE_OPEN_NO_RECALL					=	0x00040000,
	FILE_OPEN_FOR_FREE_SPACE_QUERY		=	0x00080000,
	FILE_COPY_STRUCTURED_STORAGE		=	0x00000041,
	FILE_STRUCTURED_STORAGE				=	0x00000441,
	FILE_VALID_OPTION_FLAGS				=	0x00ffffff,
	FILE_VALID_PIPE_OPTION_FLAGS		=	0x00000032,
	FILE_VALID_MAILSLOT_OPTION_FLAGS	=	0x00000032,
	FILE_VALID_SET_FLAGS				=	0x00000036
};
#endif

typedef VOID (NTAPI *PIO_APC_ROUTINE)(PVOID ApcContext,
									  PIO_STATUS_BLOCK IoStatusBlock,
									  ULONG Reserved);

enum {
	FILE_NOTIFY_CHANGE_EA					=	0x0000080,
	FILE_NOTIFY_CHANGE_STREAM_NAME			=	0x00000200,
	FILE_NOTIFY_CHANGE_STREAM_SIZE			=	0x00000400,
	FILE_NOTIFY_CHANGE_STREAM_WRITE			=	0x00000800
};

#ifndef _NTTYPES_NO_WINNT

typedef struct _FILE_NOTIFY_INFORMATION {
	ULONG NextEntryOffset;
	ULONG Action;
	ULONG NameLength;
	ULONG Name [1 ];
} FILE_NOTIFY_INFORMATION,*PFILE_NOTIFY_INFORMATION;

#endif

enum {
	FILE_ACTION_ADDED_STREAM		=	0x00000006,
	FILE_ACTION_REMOVED_STREAM		=	0x00000007,
	FILE_ACTION_MODIFIED_STREAM		=	0x00000008
};

typedef struct _FILE_FULL_EA_INFORMATION {
	ULONG NextEntryOffset;
	UCHAR Flags;
	UCHAR EaNameLength;
	USHORT EaValueLength;
	CHAR EaName [1 ];
	//UCHAR EaData [];//Variable length data not declared}
} FILE_FULL_EA_INFORMATION,
*PFILE_FULL_EA_INFORMATION;

typedef struct _FILE_GET_EA_INFORMATION {
	ULONG NextEntryOffset;
	UCHAR EaNameLength;
	CHAR EaName [1 ];
} FILE_GET_EA_INFORMATION,*PFILE_GET_EA_INFORMATION;

#if !defined(FILE_ANY_ACCESS) && !defined(__IDA__)
enum {
	FILE_ANY_ACCESS = 0
};
#endif
#ifndef FILE_SPECIAL_ACCESS
enum {
	FILE_SPECIAL_ACCESS = FILE_ANY_ACCESS
};
#endif
#if !defined(FILE_READ_ACCESS) && !defined(__IDA__)
enum {
	FILE_READ_ACCESS = 0x0001 // file & pipe
};
#endif
#if !defined(FILE_WRITE_ACCESS) && !defined(__IDA__)
enum {
	FILE_WRITE_ACCESS = 0x0002 // file & pipe
};
#endif

// For ntddk.h compatibility
#ifndef DEVICE_TYPE
typedef ULONG DEVICE_TYPE;

#if !defined(__IDA__)
enum {
	FILE_DEVICE_BEEP				=	0x00000001,
	FILE_DEVICE_CD_ROM				=	0x00000002,
	FILE_DEVICE_CD_ROM_FILE_SYSTEM	=	0x00000003,
	FILE_DEVICE_CONTROLLER			=	0x00000004,
	FILE_DEVICE_DATALINK			=	0x00000005,
	FILE_DEVICE_DFS					=	0x00000006,
	FILE_DEVICE_DISK				=	0x00000007,
	FILE_DEVICE_DISK_FILE_SYSTEM	=	0x00000009,
	FILE_DEVICE_FILE_SYSTEM			=	0x00000009,
	FILE_DEVICE_INPORT_PORT			=	0x0000000a,
	FILE_DEVICE_KEYBOARD			=	0x0000000b,
	FILE_DEVICE_MAILSLOT			=	0x0000000c,
	FILE_DEVICE_MIDI_IN				=	0x0000000d,
	FILE_DEVICE_MIDI_OUT			=	0x0000000e,
	FILE_DEVICE_MOUSE				=	0x0000000f,
	FILE_DEVICE_MULTI_UNC_PROVIDER	=	0x00000010,
	FILE_DEVICE_NAMED_PIPE			=	0x00000011,
	FILE_DEVICE_NETWORK				=	0x00000012,
	FILE_DEVICE_NETWORK_BROWSER		=	0x00000013,
	FILE_DEVICE_NETWORK_FILE_SYSTEM	=	0x00000014,
	FILE_DEVICE_NULL				=	0x00000015,
	FILE_DEVICE_PARALLEL_PORT		=	0x00000016,
	FILE_DEVICE_PHYSICAL_NETCARD	=	0x00000017,
	FILE_DEVICE_PRINTER				=	0x00000018,
	FILE_DEVICE_SCANNER				=	0x00000019,
	FILE_DEVICE_SERIAL_MOUSE_PORT	=	0x0000001a,
	FILE_DEVICE_SERIAL_PORT			=	0x0000001b,
	FILE_DEVICE_SCREEN				=	0x0000001c,
	FILE_DEVICE_SOUND				=	0x0000001d,
	FILE_DEVICE_STREAMS				=	0x0000001e,
	FILE_DEVICE_TAPE				=	0x0000001f,
	FILE_DEVICE_TAPE_FILE_SYSTEM	=	0x00000020,
	FILE_DEVICE_TRANSPORT			=	0x00000021,
	FILE_DEVICE_UNKNOWN				=	0x00000022,
	FILE_DEVICE_VIDEO				=	0x00000023,
	FILE_DEVICE_VIRTUAL_DISK		=	0x00000024,
	FILE_DEVICE_WAVE_IN				=	0x00000025,
	FILE_DEVICE_WAVE_OUT			=	0x00000026,
	FILE_DEVICE_8042_PORT			=	0x00000027,
	FILE_DEVICE_NETWORK_REDIRECTOR	=	0x00000028,
	FILE_DEVICE_BATTERY				=	0x00000029,
	FILE_DEVICE_BUS_EXTENDER		=	0x0000002a,
	FILE_DEVICE_MODEM				=	0x0000002b,
	FILE_DEVICE_VDM					=	0x0000002c,
	FILE_DEVICE_MASS_STORAGE		=	0x0000002d,
	FILE_DEVICE_SMB					=	0x0000002e,
	FILE_DEVICE_KS					=	0x0000002f,
	FILE_DEVICE_CHANGER				=	0x00000030,
	FILE_DEVICE_SMARTCARD			=	0x00000031,
	FILE_DEVICE_ACPI				=	0x00000032,
	FILE_DEVICE_DVD					=	0x00000033,
	FILE_DEVICE_FULLSCREEN_VIDEO	=	0x00000034,
	FILE_DEVICE_DFS_FILE_SYSTEM		=	0x00000035,
	FILE_DEVICE_DFS_VOLUME			=	0x00000036,
	FILE_DEVICE_SERENUM				=	0x00000037,
	FILE_DEVICE_TERMSRV				=	0x00000038,
	FILE_DEVICE_KSEC				=	0x00000039
};
#endif
#endif

typedef enum _FSINFOCLASS { //				Query	Set		Notes
	FileFsVolumeInformation		=	1,	// 1	Y		N
	FileFsLabelInformation		=	2,	// 2	N		Y
	FileFsSizeInformation		=	3,	// 3	Y		N
	FileFsDeviceInformation		=	4,	// 4	Y		N
	FileFsAttributeInformation	=	5,	// 5	Y		N
	FileFsControlInformation	=	6,	// 6	Y		Y	Only implemented on Windows 2000 (or later)
	FileFsFullSizeInformation	=	7,	// 7	Y		N	Only implemented on Windows 2000 (or later)
	FileFsObjectIdInformation	=	8,	// 8	Y		Y	Only implemented on Windows 2000 (or later)
	FileFsDriverPathInformation =   9,  // 9    Y       N   Only implemented on Windows XP   (or later)
	FileFsMaximumInformation
} FS_INFORMATION_CLASS,*PFS_INFORMATION_CLASS;

typedef struct _FILE_FS_VOLUME_INFORMATION {
	LARGE_INTEGER VolumeCreationTime;
	ULONG VolumeSerialNumber;
	ULONG VolumeLabelLength;
	UCHAR Unknown;
	WCHAR VolumeLabel [1 ];
} FILE_FS_VOLUME_INFORMATION,*PFILE_FS_VOLUME_INFORMATION;

typedef struct _FILE_FS_LABEL_INFORMATION {
	ULONG VolumeLabelLength;
	WCHAR VolumeLabel;
} FILE_FS_LABEL_INFORMATION,*PFILE_FS_LABEL_INFORMATION;

typedef struct _FILE_FS_DEVICE_INFORMATION {
	DEVICE_TYPE DeviceType;
	ULONG Characteristics;
} FILE_FS_DEVICE_INFORMATION,*PFILE_FS_DEVICE_INFORMATION;

typedef struct _FILE_FS_ATTRIBUTE_INFORMATION {
	ULONG FileSystemFlags;
	ULONG MaximumComponentNameLength;
	ULONG FileSystemNameLength;
	WCHAR FileSystemName [1 ];
} FILE_FS_ATTRIBUTE_INFORMATION,*PFILE_FS_ATTRIBUTE_INFORMATION;

typedef struct _FILE_FS_DRIVER_PATH_INFORMATION {
	BOOLEAN DriverInPath;
	ULONG   DriverNameLength;
	WCHAR   DriverName[ 1 ];
} FILE_FS_DRIVER_PATH_INFORMATION, * PFILE_FS_DRIVER_PATH_INFORMATION;

//
// Define the various device characteristics flags
//

// For ntddk.h compatibility
#ifndef FILE_REMOVABLE_MEDIA
enum {
	FILE_REMOVABLE_MEDIA			=	0x00000001,
	FILE_READ_ONLY_DEVICE			=	0x00000002,
	FILE_FLOPPY_DISKETTE			=	0x00000004,
	FILE_WRITE_ONCE_MEDIA			=	0x00000008,
	FILE_REMOTE_DEVICE				=	0x00000010,
	FILE_DEVICE_IS_MOUNTED			=	0x00000020,
	FILE_VIRTUAL_VOLUME				=	0x00000040,
	FILE_AUTOGENERATED_DEVICE_NAME	=	0x00000080,
	FILE_DEVICE_SECURE_OPEN			=	0x00000100
};
#endif

/*
typedef struct _FILE_FS_ATTRIBUTE_INFORMATION {
	ULONG FileSystemFlags;
	ULONG MaximumComponentNameLength;
	ULONG FileSystemNameLength;
	WCHAR FileSystemName [1 ];
} FILE_FS_ATTRIBUTE_INFORMATION,*PFILE_FS_ATTRIBUTE_INFORMATION;
*/

// For ntddk.h compatibility
#if !defined(FILE_CASE_SENSITIVE_SEARCH) && !defined(__IDA__)
enum {
	FILE_CASE_SENSITIVE_SEARCH		=	0x00000001,
	FILE_CASE_PRESERVED_NAMES		=	0x00000002,
	FILE_UNICODE_ON_DISK			=	0x00000004,
	FILE_PERSISTENT_ACLS			=	0x00000008,
	FILE_FILE_COMPRESSION			=	0x00000010,
	FILE_VOLUME_QUOTAS				=	0x00000020,
	FILE_SUPPORTS_SPARSE_FILES		=	0x00000040,
	FILE_SUPPORTS_REPARSE_POINTS	=	0x00000080,
	FILE_SUPPORTS_REMOTE_STORAGE	=	0x00000100,
	FILE_VOLUME_IS_COMPRESSED		=	0x00008000,
	FILE_SUPPORTS_OBJECT_IDS		=	0x00010000,
	FILE_SUPPORTS_ENCRYPTION		=	0x00020000,
	FILE_NAMED_STREAMS				=	0x00040000,
	FILE_READ_ONLY_VOLUME			=	0x00800000
};
#endif

typedef struct _FILE_FS_CONTROL_INFORMATION {
	LARGE_INTEGER Reserved [3 ];
	LARGE_INTEGER DefaultQuotaThreshold;
	LARGE_INTEGER DefaultQuotaLimit;
	ULONG QuotaFlags;
} FILE_FS_CONTROL_INFORMATION,*PFILE_FS_CONTROL_INFORMATION;

typedef struct _FILE_FS_FULL_SIZE_INFORMATION {
	LARGE_INTEGER TotalQuotaAllocationUnits;
	LARGE_INTEGER AvailableQuotaAllocationUnits;
	LARGE_INTEGER AvailableAllocationUnits;
	ULONG SectorsPerAllocationUnit;
	ULONG BytesPerSector;
} FILE_FS_FULL_SIZE_INFORMATION,*PFILE_FS_FULL_SIZE_INFORMATION;

typedef struct _FILE_FS_OBJECT_ID_INFORMATION {
	UUID VolumeObjectId;
	ULONG VolumeObjectIdExtendedInfo [12 ];
} FILE_FS_OBJECT_ID_INFORMATION,*PFILE_FS_OBJECT_ID_INFORMATION;

typedef struct _FILE_USER_QUOTA_INFORMATION {
	ULONG NextEntryOffset;
	ULONG SidLength;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER QuotaUsed;
	LARGE_INTEGER QuotaThreshold;
	LARGE_INTEGER QuotaLimit;
	SID Sid [1 ];
} FILE_USER_QUOTA_INFORMATION,*PFILE_USER_QUOTA_INFORMATION;

typedef struct _FILE_QUOTA_LIST_INFORMATION {
	ULONG NextEntryOffset;
	ULONG SidLength;
	SID Sid [1 ];
} FILE_QUOTA_LIST_INFORMATION,*PFILE_QUOTA_LIST_INFORMATION;

typedef enum _FILE_INFORMATION_CLASS {    //	Query	Set		File/Directory
	FileDirectoryInformation		= 1,  //	Y		N		D
	FileFullDirectoryInformation	= 2,  //	Y		N		D
	FileBothDirectoryInformation	= 3,  //	Y		N		D
	FileBasicInformation			= 4,  //	Y		Y		F
	FileStandardInformation			= 5,  //	Y		N		F
	FileInternalInformation			= 6,  //	Y		N		F
	FileEaInformation				= 7,  //	Y		N		F
	FileAccessInformation			= 8,  //	Y		N		F
	FileNameInformation				= 9,  //	Y		N		F
	FileRenameInformation			= 10, //	N		Y		F
	FileLinkInformation				= 11, //	N		Y		F
	FileNamesInformation			= 12, //	Y		N		D
	FileDispositionInformation		= 13, //	N		Y		F
	FilePositionInformation			= 14, //	Y		Y		F
	FileModeInformation				= 16, //	Y		Y		F
	FileAlignmentInformation		= 17, //	Y		N		F
	FileAllInformation				= 18, //	Y		N		F
	FileAllocationInformation		= 19, //	N		Y		F
	FileEndOfFileInformation		= 20, //	N		Y		F
	FileAlternateNameInformation	= 21, //	Y		N		F
	FileStreamInformation			= 22, //	Y		N		F
	FilePipeInformation				= 23, //	Y		Y		F
	FilePipeLocalInformation		= 24, //	Y		N		F
	FilePipeRemoteInformation		= 25, //	Y		Y		F
	FileMailslotQueryInformation	= 26, //	Y		N		F
	FileMailslotSetInformation		= 27, //	N		Y		F
	FileCompressionInformation		= 28, //	Y		N		F
	FileObjectIdInformation			= 29, //	Y		Y		F
	FileCompletionInformation		= 30, //	N		Y		F
	FileMoveClusterInformation		= 31, //	N		Y		F
	FileQuotaInformation			= 32, //	Y		Y		F
	FileReparsePointInformation		= 33, //	Y		N		F
	FileNetworkOpenInformation		= 34, //	Y		N		F
	FileAttributeTagInformation		= 35, //	Y		N		F
	FileTrackingInformation			= 36, //	N		Y		F
	FileIdBothDirectoryInformation  = 37, //    Y       N       D
	FileIdFullDirectoryInformation  = 38, //    Y       N       D
	FileValidDataLengthInformation  = 39, //    Y       Y       F
	FileShortNameInformation        = 40, //    Y       Y       F
	FileMaximumInformation
} FILE_INFORMATION_CLASS, *PFILE_INFORMATION_CLASS;

typedef struct _FILE_DIRECTORY_INFORMATION { // Information Class 1
	ULONG NextEntryOffset;
	ULONG Unknown;
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER EndOfFile;
	LARGE_INTEGER AllocationSize;
	ULONG FileAttributes;
	ULONG FileNameLength;
	WCHAR FileName[1];
} FILE_DIRECTORY_INFORMATION, *PFILE_DIRECTORY_INFORMATION;

typedef struct _FILE_FULL_DIRECTORY_INFORMATION { // Information Class 2
	ULONG NextEntryOffset;
	ULONG Unknown;
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER EndOfFile;
	LARGE_INTEGER AllocationSize;
	ULONG FileAttributes;
	ULONG FileNameLength;
	ULONG EaInformationLength;
	WCHAR FileName[1];
} FILE_FULL_DIRECTORY_INFORMATION, *PFILE_FULL_DIRECTORY_INFORMATION;

typedef struct _FILE_BOTH_DIRECTORY_INFORMATION { // Information Class 3
	ULONG NextEntryOffset;
	ULONG Unknown;
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER EndOfFile;
	LARGE_INTEGER AllocationSize;
	ULONG FileAttributes;
	ULONG FileNameLength;
	ULONG EaInformationLength;
	UCHAR AlternateNameLength;
	WCHAR AlternateName[12];
	WCHAR FileName[1];
} FILE_BOTH_DIRECTORY_INFORMATION, *PFILE_BOTH_DIRECTORY_INFORMATION;

typedef struct _FILE_BASIC_INFORMATION { // Information Class 4
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	ULONG FileAttributes;
} FILE_BASIC_INFORMATION, *PFILE_BASIC_INFORMATION;

typedef struct _FILE_STANDARD_INFORMATION { // Information Class 5
	LARGE_INTEGER AllocationSize;
	LARGE_INTEGER EndOfFile;
	ULONG NumberOfLinks;
	BOOLEAN DeletePending;
	BOOLEAN Directory;
} FILE_STANDARD_INFORMATION, *PFILE_STANDARD_INFORMATION;

typedef struct _FILE_INTERNAL_INFORMATION { // Information Class 6
	LARGE_INTEGER FileId;
} FILE_INTERNAL_INFORMATION, *PFILE_INTERNAL_INFORMATION;

typedef struct _FILE_EA_INFORMATION { // Information Class 7
	ULONG EaInformationLength;
} FILE_EA_INFORMATION, *PFILE_EA_INFORMATION;

typedef struct _FILE_ACCESS_INFORMATION { // Information Class 8
	ACCESS_MASK GrantedAccess;
} FILE_ACCESS_INFORMATION, *PFILE_ACCESS_INFORMATION;

typedef struct _FILE_NAME_INFORMATION { // Information Classes 9 and 21
	ULONG FileNameLength;
	WCHAR FileName[1];
} FILE_NAME_INFORMATION, *PFILE_NAME_INFORMATION,
FILE_ALTERNATE_NAME_INFORMATION, *PFILE_ALTERNATE_NAME_INFORMATION;

typedef struct _FILE_LINK_RENAME_INFORMATION { // Info Classes 10 and 11
	BOOLEAN ReplaceIfExists;
	HANDLE RootDirectory;
	ULONG FileNameLength;
	WCHAR FileName[1];
} FILE_LINK_INFORMATION, *PFILE_LINK_INFORMATION,
FILE_RENAME_INFORMATION, *PFILE_RENAME_INFORMATION;

typedef struct _FILE_NAMES_INFORMATION { // Information Class 12
	ULONG NextEntryOffset;
	ULONG Unknown;
	ULONG FileNameLength;
	WCHAR FileName[1];
} FILE_NAMES_INFORMATION, *PFILE_NAMES_INFORMATION;

typedef struct _FILE_DISPOSITION_INFORMATION { // Information Class 13
	BOOLEAN DeleteFile;
} FILE_DISPOSITION_INFORMATION, *PFILE_DISPOSITION_INFORMATION;

typedef struct _FILE_POSITION_INFORMATION { // Information Class 14
	LARGE_INTEGER CurrentByteOffset;
} FILE_POSITION_INFORMATION, *PFILE_POSITION_INFORMATION;

typedef struct _FILE_MODE_INFORMATION { // Information Class 16
	ULONG Mode;
} FILE_MODE_INFORMATION, *PFILE_MODE_INFORMATION;

typedef struct _FILE_ALIGNMENT_INFORMATION { // Information Class 17
	ULONG AlignmentRequirement;
} FILE_ALIGNMENT_INFORMATION, *PFILE_ALIGNMENT_INFORMATION;

typedef struct _FILE_ALL_INFORMATION { // Information Class 18
	FILE_BASIC_INFORMATION BasicInformation;
	FILE_STANDARD_INFORMATION StandardInformation;
	FILE_INTERNAL_INFORMATION InternalInformation;
	FILE_EA_INFORMATION EaInformation;
	FILE_ACCESS_INFORMATION AccessInformation;
	FILE_POSITION_INFORMATION PositionInformation;
	FILE_MODE_INFORMATION ModeInformation;
	FILE_ALIGNMENT_INFORMATION AlignmentInformation;
	FILE_NAME_INFORMATION NameInformation;
} FILE_ALL_INFORMATION, *PFILE_ALL_INFORMATION;

typedef struct _FILE_ALLOCATION_INFORMATION { // Information Class 19
	LARGE_INTEGER AllocationSize;
} FILE_ALLOCATION_INFORMATION, *PFILE_ALLOCATION_INFORMATION;

typedef struct _FILE_END_OF_FILE_INFORMATION { // Information Class 20
	LARGE_INTEGER EndOfFile;
} FILE_END_OF_FILE_INFORMATION, *PFILE_END_OF_FILE_INFORMATION;

typedef struct _FILE_STREAM_INFORMATION { // Information Class 22
	ULONG NextEntryOffset;
	ULONG StreamNameLength;
	LARGE_INTEGER EndOfStream;
	LARGE_INTEGER AllocationSize;
	WCHAR StreamName[1];
} FILE_STREAM_INFORMATION, *PFILE_STREAM_INFORMATION;

typedef struct _FILE_PIPE_INFORMATION { // Information Class 23
	ULONG ReadModeMessage;
	ULONG WaitModeBlocking;
} FILE_PIPE_INFORMATION, *PFILE_PIPE_INFORMATION;

typedef struct _FILE_PIPE_LOCAL_INFORMATION { // Information Class 24
	ULONG MessageType;
	ULONG Unknown1;
	ULONG MaxInstances;
	ULONG CurInstances;
	ULONG InBufferSize;
	ULONG Unknown2;
	ULONG OutBufferSize;
	ULONG Unknown3[2];
	ULONG ServerEnd;
} FILE_PIPE_LOCAL_INFORMATION, *PFILE_PIPE_LOCAL_INFORMATION;

typedef struct _FILE_PIPE_REMOTE_INFORMATION { // Information Class 25
	LARGE_INTEGER CollectDataTimeout;
	ULONG MaxCollectionCount;
} FILE_PIPE_REMOTE_INFORMATION, *PFILE_PIPE_REMOTE_INFORMATION;

typedef struct _FILE_MAILSLOT_QUERY_INFORMATION { // Information Class 26
	ULONG MaxMessageSize;
	ULONG Unknown;
	ULONG NextSize;
	ULONG MessageCount;
	LARGE_INTEGER ReadTimeout;
} FILE_MAILSLOT_QUERY_INFORMATION, *PFILE_MAILSLOT_QUERY_INFORMATION;

typedef struct _FILE_MAILSLOT_SET_INFORMATION { // Information Class 27
	LARGE_INTEGER ReadTimeout;
} FILE_MAILSLOT_SET_INFORMATION, *PFILE_MAILSLOT_SET_INFORMATION;

typedef struct _FILE_COMPRESSION_INFORMATION { // Information Class 28
	LARGE_INTEGER CompressedSize;
	USHORT CompressionFormat;
	UCHAR CompressionUnitShift;
	UCHAR Unknown;
	UCHAR ClusterSizeShift;
} FILE_COMPRESSION_INFORMATION, *PFILE_COMPRESSION_INFORMATION;

typedef struct _FILE_COMPLETION_INFORMATION { // Information Class 30
	HANDLE IoCompletionHandle;
	ULONG CompletionKey;
} FILE_COMPLETION_INFORMATION, *PFILE_COMPLETION_INFORMATION;

typedef struct _FILE_NETWORK_OPEN_INFORMATION { // Information Class 34
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER AllocationSize;
	LARGE_INTEGER EndOfFile;
	ULONG FileAttributes;
} FILE_NETWORK_OPEN_INFORMATION, *PFILE_NETWORK_OPEN_INFORMATION;

typedef struct _FILE_ATTRIBUTE_TAG_INFORMATION {// Information Class 35
	ULONG FileAttributes;
	ULONG ReparseTag;
} FILE_ATTRIBUTE_TAG_INFORMATION, *PFILE_ATTRIBUTE_TAG_INFORMATION;

#pragma warning(push)
#pragma warning(disable:4121)
// '_FILE_ID_BOTH_DIRECTORY_INFORMATION': alignment of a member was sensitive to packing

typedef struct _FILE_ID_BOTH_DIRECTORY_INFORMATION { // Information Class 37
	ULONG NextEntryOffset;
	ULONG FileIndex;
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER EndOfFile;
	LARGE_INTEGER AllocationSize;
	ULONG FileAttributes;
	ULONG FileNameLength;
	ULONG EaInformationLength;
	UCHAR AlternateNameLength;
	WCHAR AlternateName[12];
	LARGE_INTEGER FileId;
	WCHAR FileName[1];
} FILE_ID_BOTH_DIRECTORY_INFORMATION, *PFILE_ID_BOTH_DIRECTORY_INFORMATION;

typedef struct _FILE_ID_FULL_DIRECTORY_INFORMATION { // Information Class 38
	ULONG NextEntryOffset;
	ULONG FileIndex;
	LARGE_INTEGER CreationTime;
	LARGE_INTEGER LastAccessTime;
	LARGE_INTEGER LastWriteTime;
	LARGE_INTEGER ChangeTime;
	LARGE_INTEGER EndOfFile;
	LARGE_INTEGER AllocationSize;
	ULONG FileAttributes;
	ULONG FileNameLength;
	ULONG EaInformationLength;
	LARGE_INTEGER FileId;
	WCHAR FileName[1];
} FILE_ID_FULL_DIRECTORY_INFORMATION, *PFILE_ID_FULL_DIRECTORY_INFORMATION;

#pragma warning(pop)

typedef enum _KEY_SET_INFORMATION_CLASS {
	KeyLastWriteTimeInformation,
	KeyUserFlagsInformation,
	MaxKeySetInfoClass // Always last
} KEY_SET_INFORMATION_CLASS;

typedef struct _KEY_LAST_WRITE_TIME_INFORMATION {
	LARGE_INTEGER LastWriteTime;
} KEY_LAST_WRITE_TIME_INFORMATION, *PKEY_LAST_WRITE_TIME_INFORMATION;

typedef struct _KEY_USER_FLAGS_INFORMATION {
	ULONG UserFlags;
} KEY_USER_FLAGS_INFORMATION, *PKEY_USER_FLAGS_INFORMATION;

typedef enum _KEY_INFORMATION_CLASS {
	KeyBasicInformation,
	KeyNodeInformation,
	KeyFullInformation,
	KeyNameInformation,
	KeyCachedInformation,
	KeyFlagsInformation,
	MaxKeyInfoClass // Always last
} KEY_INFORMATION_CLASS;

typedef struct _KEY_BASIC_INFORMATION {
	LARGE_INTEGER LastWriteTime;
	ULONG TitleIndex;
	ULONG NameLength;
	WCHAR Name[1]; // Variable length string
} KEY_BASIC_INFORMATION, *PKEY_BASIC_INFORMATION;

typedef struct _KEY_NODE_INFORMATION {
	LARGE_INTEGER LastWriteTime;
	ULONG TitleIndex;
	ULONG ClassOffset;
	ULONG ClassLength;
	ULONG NameLength;
	WCHAR Name[1]; // Variable length string
	// Class[1]; // Variable length string not declared
} KEY_NODE_INFORMATION, *PKEY_NODE_INFORMATION;

typedef struct _KEY_FULL_INFORMATION {
	LARGE_INTEGER LastWriteTime;
	ULONG TitleIndex;
	ULONG ClassOffset;
	ULONG ClassLength;
	ULONG SubKeys;
	ULONG MaxNameLen;
	ULONG MaxClassLen;
	ULONG Values;
	ULONG MaxValueNameLen;
	ULONG MaxValueDataLen;
	WCHAR Class[1]; // Variable length string
} KEY_FULL_INFORMATION, *PKEY_FULL_INFORMATION;

typedef struct _KEY_NAME_INFORMATION {
	ULONG NameLength;
	WCHAR Name[1]; // Variable length string
} KEY_NAME_INFORMATION, *PKEY_NAME_INFORMATION;

typedef struct _KEY_CACHED_INFORMATION {
	LARGE_INTEGER LastWriteTime;
	ULONG TitleIndex;
	ULONG SubKeys;
	ULONG MaxNameLen;
	ULONG Values;
	ULONG MaxValueNameLen;
	ULONG MaxValueDataLen;
	ULONG NameLength;
	WCHAR Name[1];            // Variable length string
} KEY_CACHED_INFORMATION, *PKEY_CACHED_INFORMATION;

typedef struct _KEY_FLAGS_INFORMATION {
	ULONG UserFlags;
} KEY_FLAGS_INFORMATION, *PKEY_FLAGS_INFORMATION;

typedef enum _KEY_VALUE_INFORMATION_CLASS {
	KeyValueBasicInformation,
	KeyValueFullInformation,
	KeyValuePartialInformation,
	KeyValueFullInformationAlign64,
	KeyValuePartialInformationAlign64,
	MaxKeyValueInfoClass  // Always last
} KEY_VALUE_INFORMATION_CLASS;

typedef struct _KEY_VALUE_BASIC_INFORMATION {
	ULONG TitleIndex;
	ULONG Type;
	ULONG NameLength;
	WCHAR Name[1]; // Variable length string
} KEY_VALUE_BASIC_INFORMATION, *PKEY_VALUE_BASIC_INFORMATION;

typedef struct _KEY_VALUE_FULL_INFORMATION {
	ULONG TitleIndex;
	ULONG Type;
	ULONG DataOffset;
	ULONG DataLength;
	ULONG NameLength;
	WCHAR Name[1]; // Variable length string
	// Data[1]; // Variable length data not declared
} KEY_VALUE_FULL_INFORMATION, *PKEY_VALUE_FULL_INFORMATION;

typedef struct _KEY_VALUE_PARTIAL_INFORMATION {
	ULONG TitleIndex;
	ULONG Type;
	ULONG DataLength;
	UCHAR Data[1]; // Variable length data
} KEY_VALUE_PARTIAL_INFORMATION, *PKEY_VALUE_PARTIAL_INFORMATION;

typedef struct _KEY_VALUE_ENTRY {
	PUNICODE_STRING ValueName;
	ULONG DataLength;
	ULONG DataOffset;
	ULONG Type;
} KEY_VALUE_ENTRY, *PKEY_VALUE_ENTRY;

#if !defined(_NTTYPES_NO_WINNT) || defined(__IDA__)

#ifndef POWER_INFORMATION_LEVEL
typedef enum {
	SystemPowerPolicyAc,
	SystemPowerPolicyDc,
	VerifySystemPolicyAc,
	VerifySystemPolicyDc,
	SystemPowerCapabilities,
	SystemBatteryState,
	SystemPowerStateHandler,
	ProcessorStateHandler,
	SystemPowerPolicyCurrent,
	AdministratorPowerPolicy,
	SystemReserveHiberFile,
	ProcessorInformation,
	SystemPowerInformation,
	ProcessorStateHandler2,
	LastWakeTime,                                   // Compare with KeQueryInterruptTime()
	LastSleepTime,                                  // Compare with KeQueryInterruptTime()
	SystemExecutionState,
	SystemPowerStateNotifyHandler,
	ProcessorPowerPolicyAc,
	ProcessorPowerPolicyDc,
	VerifyProcessorPowerPolicyAc,
	VerifyProcessorPowerPolicyDc,
	ProcessorPowerPolicyCurrent,
	SystemPowerStateLogging,
	SystemPowerLoggingEntry
} POWER_INFORMATION_LEVEL;
#endif

#ifndef POWER_ACTION
typedef enum {
    PowerActionNone = 0,
    PowerActionReserved,
    PowerActionSleep,
    PowerActionHibernate,
    PowerActionShutdown,
    PowerActionShutdownReset,
    PowerActionShutdownOff,
    PowerActionWarmEject
} POWER_ACTION, *PPOWER_ACTION;
#endif

#ifndef POWER_ACTION_POLICY
typedef struct {
    POWER_ACTION    Action;
    DWORD           Flags;
    DWORD           EventCode;
} POWER_ACTION_POLICY, *PPOWER_ACTION_POLICY;
#endif

#ifndef SYSTEM_POWER_STATE
typedef enum _SYSTEM_POWER_STATE {
    PowerSystemUnspecified = 0,
    PowerSystemWorking,
    PowerSystemSleeping1,
    PowerSystemSleeping2,
    PowerSystemSleeping3,
    PowerSystemHibernate,
    PowerSystemShutdown,
    PowerSystemMaximum
} SYSTEM_POWER_STATE, *PSYSTEM_POWER_STATE;
#endif

#ifndef SYSTEM_POWER_LEVEL
// system battery drain policies
typedef struct {
    BOOLEAN                 Enable;
    BYTE                    Spare[3];
    DWORD                   BatteryLevel;
    POWER_ACTION_POLICY     PowerPolicy;
    SYSTEM_POWER_STATE      MinSystemState;
} SYSTEM_POWER_LEVEL, *PSYSTEM_POWER_LEVEL;
#endif

// Discharge policy constants
#ifndef NUM_DISCHARGE_POLICIES
#define NUM_DISCHARGE_POLICIES      4
#endif
#ifndef DISCHARGE_POLICY_CRITICAL
#define DISCHARGE_POLICY_CRITICAL   0
#endif
#ifndef DISCHARGE_POLICY_LOW
#define DISCHARGE_POLICY_LOW        1
#endif

#ifndef SYSTEM_POWER_POLICY
typedef struct _SYSTEM_POWER_POLICY {
	ULONG Revision;
	POWER_ACTION_POLICY PowerButton;
	POWER_ACTION_POLICY SleepButton;
	POWER_ACTION_POLICY LidClose;
	SYSTEM_POWER_STATE LidOpenWake;
	ULONG Reserved1;
	POWER_ACTION_POLICY Idle;
	ULONG IdleTimeout;
	UCHAR IdleSensitivity;
	UCHAR Reserved2[3];
	SYSTEM_POWER_STATE MinSleep;
	SYSTEM_POWER_STATE MaxSleep;
	SYSTEM_POWER_STATE ReducedLatencySleep;
	ULONG WinLogonFlags;
	ULONG Reserved3;
	ULONG DozeS4Timeout;
	ULONG BroadcastCapacityResolution;
	SYSTEM_POWER_LEVEL DischargePolicy[NUM_DISCHARGE_POLICIES];
	ULONG VideoTimeout;
	ULONG VideoReserved[4];
	ULONG SpindownTimeout;
	BOOLEAN OptimizeForPower;
	UCHAR FanThrottleTolerance;
	UCHAR ForcedThrottle;
	UCHAR MinThrottle;
	POWER_ACTION_POLICY OverThrottled;
} SYSTEM_POWER_POLICY, *PSYSTEM_POWER_POLICY;
#endif

#ifndef BATTERY_REPORTING_SCALE
//
// System power manager capabilities
//

typedef struct {
    DWORD       Granularity;
    DWORD       Capacity;
} BATTERY_REPORTING_SCALE, *PBATTERY_REPORTING_SCALE;
#endif

#ifndef DEVICE_POWER_STATE
typedef enum _DEVICE_POWER_STATE {
    PowerDeviceUnspecified = 0,
    PowerDeviceD0,
    PowerDeviceD1,
    PowerDeviceD2,
    PowerDeviceD3,
    PowerDeviceMaximum
} DEVICE_POWER_STATE, *PDEVICE_POWER_STATE;
#endif

#ifndef SYSTEM_POWER_CAPABILITIES
typedef struct _SYSTEM_POWER_CAPABILITIES {
	BOOLEAN PowerButtonPresent;
	BOOLEAN SleepButtonPresent;
	BOOLEAN LidPresent;
	BOOLEAN SystemS1;
	BOOLEAN SystemS2;
	BOOLEAN SystemS3;
	BOOLEAN SystemS4;
	BOOLEAN SystemS5;
	BOOLEAN HiberFilePresent;
	BOOLEAN FullWake;
	UCHAR Reserved1[3];
	BOOLEAN ThermalControl;
	BOOLEAN ProcessorThrottle;
	UCHAR ProcessorMinThrottle;
	UCHAR ProcessorThrottleScale;
	UCHAR Reserved2[4];
	BOOLEAN DiskSpinDown;
	UCHAR Reserved3[8];
	BOOLEAN SystemBatteriesPresent;
	BOOLEAN BatteriesAreShortTerm;
	BATTERY_REPORTING_SCALE BatteryScale[3];
	SYSTEM_POWER_STATE AcOnLineWake;
	SYSTEM_POWER_STATE SoftLidWake;
	SYSTEM_POWER_STATE RtcWake;
	SYSTEM_POWER_STATE MinDeviceWakeState;
	SYSTEM_POWER_STATE DefaultLowLatencyWake;
} SYSTEM_POWER_CAPABILITIES, *PSYSTEM_POWER_CAPABILITIES;
#endif

#ifndef SYSTEM_BATTERY_STATE
typedef struct _SYSTEM_BATTERY_STATE {
	BOOLEAN AcOnLine;
	BOOLEAN BatteryPresent;
	BOOLEAN Charging;
	BOOLEAN Discharging;
	BOOLEAN Reserved[4];
	ULONG MaxCapacity;
	ULONG RemainingCapacity;
	ULONG Rate;
	ULONG EstimatedTime;
	ULONG DefaultAlert1;
	ULONG DefaultAlert2;
} SYSTEM_BATTERY_STATE, *PSYSTEM_BATTERY_STATE;
#endif

#endif

typedef DWORD POWER_STATE_HANDLER_TYPE; // FIXME: What is this?
typedef PVOID PENTER_STATE_HANDLER; // FIXME: What is this?

#ifndef POWER_STATE_HANDLER
typedef struct _POWER_STATE_HANDLER {
	POWER_STATE_HANDLER_TYPE Type;
	BOOLEAN RtcWake;
	UCHAR Reserved[3];
	PENTER_STATE_HANDLER Handler;
	PVOID Context;
} POWER_STATE_HANDLER, *PPOWER_STATE_HANDLER;
#endif

typedef PVOID PSET_PROCESSOR_THROTTLE; // FIXME: What is this?
typedef DWORD PROCESSOR_IDLE_HANDLER_INFO; // FIXME: What is this?
enum {
	MAX_IDLE_HANDLERS			=	1	// FIXME: What is this?
};

#ifndef PROCESSOR_STATE_HANDLER
typedef struct _PROCESSOR_STATE_HANDLER {
	UCHAR ThrottleScale;
	BOOLEAN ThrottleOnIdle;
	PSET_PROCESSOR_THROTTLE SetThrottle;
	ULONG NumIdleHandlers;
	PROCESSOR_IDLE_HANDLER_INFO IdleHandler[MAX_IDLE_HANDLERS];
} PROCESSOR_STATE_HANDLER, *PPROCESSOR_STATE_HANDLER;
#endif

#ifndef _NTTYPES_NO_WINNT

#ifndef ADMINISTRATOR_POWER_POLICY
typedef struct _ADMINISTRATOR_POWER_POLICY {
	SYSTEM_POWER_STATE MinSleep;
	SYSTEM_POWER_STATE MaxSleep;
	ULONG MinVideoTimeout;
	ULONG MaxVideoTimeout;
	ULONG MinSpindownTimeout;
	ULONG MaxSpindownTimeout;
} ADMINISTRATOR_POWER_POLICY, *PADMINISTRATOR_POWER_POLICY;
#endif

#endif

typedef struct _PROCESSOR_POWER_INFORMATION {
	ULONG Number;
	ULONG MaxMhz;
	ULONG CurrentMhz;
	ULONG MhzLimit;
	ULONG MaxIdleState;
	ULONG CurrentIdleState;
} PROCESSOR_POWER_INFORMATION, *PPROCESSOR_POWER_INFORMATION;

typedef struct _SYSTEM_POWER_INFORMATION {
	ULONG MaxIdlenessAllowed;
	ULONG Idleness;
	ULONG TimeRemaining;
	UCHAR CoolingMode;
} SYSTEM_POWER_INFORMATION, *PSYSTEM_POWER_INFORMATION;

typedef enum _HARDERROR_RESPONSE_OPTION {
	OptionAbortRetryIgnore,
	OptionOk,
	OptionOkCancel,
	OptionRetryCancel,
	OptionYesNo,
	OptionYesNoCancel,
	OptionShutdownSystem,
#if _WIN32_WINNT >= 0x0500
	OptionOkNoWait,
	OptionCancelTryContinue,
#endif
	MaximumHardErrorOptions
} HARDERROR_RESPONSE_OPTION, *PHARDERROR_RESPONSE_OPTION;

typedef enum _HARDERROR_RESPONSE {
	ResponseReturnToCaller,
	ResponseNotHandled,
	ResponseAbort,
	ResponseCancel,
	ResponseIgnore,
	ResponseNo,
	ResponseOk,
	ResponseRetry,
	ResponseYes,
#if _WIN32_WINNT >= 0x0500
	ResponseTryAgain,
	ResponseContinue,
#endif
	MaximumHardErrorResponses
} HARDERROR_RESPONSE, *PHARDERROR_RESPONSE;

typedef WORD                ATOM;

typedef enum _ATOM_INFORMATION_CLASS {
	AtomBasicInformation,
	AtomListInformation
} ATOM_INFORMATION_CLASS;

typedef struct _ATOM_BASIC_INFORMATION {
	USHORT ReferenceCount;
	USHORT Pinned;
	USHORT NameLength;
	WCHAR Name[1];
} ATOM_BASIC_INFORMATION, *PATOM_BASIC_INFORMATION;

typedef struct _ATOM_LIST_INFORMATION {
	ULONG NumberOfAtoms;
	ATOM Atoms[1];
} ATOM_LIST_INFORMATION, *PATOM_LIST_INFORMATION;

typedef enum _SYSTEM_INFORMATION_CLASS {			// Value	Query	Set
	SystemBasicInformation,							// 0		Y		N
	SystemProcessorInformation,						// 1		Y		N
	SystemPerformanceInformation,					// 2		Y		N
	SystemTimeOfDayInformation,						// 3		Y		N
	SystemNotImplemented1,							// 4		Y		N
	SystemProcessesAndThreadsInformation,			// 5		Y		N
	SystemCallCounts,								// 6		Y		N
	SystemConfigurationInformation,					// 7		Y		N
	SystemProcessorTimes,							// 8		Y		N
	SystemGlobalFlag,								// 9		Y		Y
	SystemNotImplemented2,							// 10		Y		N
	SystemModuleInformation,						// 11		Y		N
	SystemLockInformation,							// 12		Y		N
	SystemNotImplemented3,							// 13		Y		N
	SystemNotImplemented4,							// 14		Y		N
	SystemNotImplemented5,							// 15		Y		N
	SystemHandleInformation,						// 16		Y		N
	SystemObjectInformation,						// 17		Y		N
	SystemPagefileInformation,						// 18		Y		N
	SystemInstructionEmulationCounts,				// 19		Y		N
	SystemInvalidInfoClass1,						// 20
	SystemCacheInformation,							// 21		Y		Y
	SystemPoolTagInformation,						// 22		Y		N
	SystemProcessorStatistics,						// 23		Y		N
	SystemDpcInformation,							// 24		Y		Y
	SystemNotImplemented6,							// 25		Y		N
	SystemLoadImage,								// 26		N		Y
	SystemUnloadImage,								// 27		N		Y
	SystemTimeAdjustment,							// 28		Y		Y
	SystemNotImplemented7,							// 29		Y		N
	SystemNotImplemented8,							// 30		Y		N
	SystemNotImplemented9,							// 31		Y		N
	SystemCrashDumpInformation,						// 32		Y		N
	SystemExceptionInformation,						// 33		Y		N
	SystemCrashDumpStateInformation,				// 34		Y		Y/N
	SystemKernelDebuggerInformation,				// 35		Y		N
	SystemContextSwitchInformation,					// 36		Y		N
	SystemRegistryQuotaInformation,					// 37		Y		Y
	SystemLoadAndCallImage,							// 38		N		Y
	SystemPrioritySeparation,						// 39		N		Y
	SystemNotImplemented10,							// 40		Y		N
	SystemNotImplemented11,							// 41		Y		N
	SystemInvalidInfoClass2,						// 42
	SystemInvalidInfoClass3,						// 43
	SystemTimeZoneInformation,						// 44		Y		N
	SystemLookasideInformation,						// 45		Y		N
	SystemSetTimeSlipEvent,							// 46		N		Y
	SystemCreateSession,							// 47		N		Y
	SystemDeleteSession,							// 48		N		Y
	SystemInvalidInfoClass4,						// 49
	SystemRangeStartInformation,					// 50		Y		N
	SystemVerifierInformation,						// 51		Y		Y
	SystemAddVerifier,								// 52		N		Y
	SystemSessionProcessesInformation,				// 53		Y		N
#if _WIN32_WINNT >= 0x0501
	SystemInformation54,                            // 54
	SystemNumaNodeInformation,						// 55		Y		?	GetNumaProcessorNode
	SystemInformation56,							// 56
	SystemUnknownInformation57,						// 57		Y		?
	SystemInformation58,							// 58
	SystemComPlusPackageInstallStatusInformation,	// 59		Y		Y	sizeof = 4, GetComPlusPackageInstallStatus
	SystemNumaMemoryInformation,					// 60		Y		?	sizeof = 0x88, GetNumaAvailableMemoryNode
	SystemInformation61,							// 61
	SystemInformation62,							// 62
	SystemInformation63,							// 63
	SystemExtendedHandleInformation,				// 64		Y       N   SystemExtendedHandleInformation
	SystemInformation65,							// 65
	SystemInformation66,							// 66
	SystemInformation67,							// 67
	SystemInformation68,							// 68
	SystemHotpatchCodeInformation,							// 69		Y		?
	SystemInformation70,							// 70
	SystemInformation71,							// 71
#endif
#if _WIN32_WINNT >= 0x0502
	SystemInformation72,							// 72
	SystemLogicalProcessorInformation,				// 73		Y		N
#endif
	MaxSystemInfoClass
} SYSTEM_INFORMATION_CLASS;

#define SystemProcessInformation SystemProcessesAndThreadsInformation

typedef struct _SYSTEM_BASIC_INFORMATION { // Information Class 0
	ULONG Reserved;
	ULONG TimerResolution;
	ULONG PageSize;
	ULONG NumberOfPhysicalPages;
	ULONG LowestPhysicalPageNumber;
	ULONG HighestPhysicalPageNumber;
	ULONG AllocationGranularity;
	ULONG_PTR MinimumUserModeAddress;
	ULONG_PTR MaximumUserModeAddress;
	KAFFINITY ActiveProcessorsAffinityMask;
	CCHAR NumberOfProcessors;
} SYSTEM_BASIC_INFORMATION, *PSYSTEM_BASIC_INFORMATION;

typedef struct _SYSTEM_PROCESSOR_INFORMATION { // Information Class 1
	USHORT ProcessorArchitecture;
	USHORT ProcessorLevel;
	USHORT ProcessorRevision;
	USHORT Unknown;
	ULONG FeatureBits;
} SYSTEM_PROCESSOR_INFORMATION, *PSYSTEM_PROCESSOR_INFORMATION;

typedef struct _SYSTEM_PERFORMANCE_INFORMATION { // Information Class 2
	LARGE_INTEGER IdleTime;
	LARGE_INTEGER ReadTransferCount;
	LARGE_INTEGER WriteTransferCount;
	LARGE_INTEGER OtherTransferCount;
	ULONG ReadOperationCount;
	ULONG WriteOperationCount;
	ULONG OtherOperationCount;
	ULONG AvailablePages;
	ULONG TotalCommittedPages;
	ULONG TotalCommitLimit;
	ULONG PeakCommitment;
	ULONG PageFaults;
	ULONG WriteCopyFaults;
	ULONG TransitionFaults;
	ULONG Reserved1;
	ULONG DemandZeroFaults;
	ULONG PagesRead;
	ULONG PageReadIos;
	ULONG Reserved2[2];
	ULONG PagefilePagesWritten;
	ULONG PagefilePageWriteIos;
	ULONG MappedFilePagesWritten;
	ULONG MappedFilePageWriteIos;
	ULONG PagedPoolUsage;
	ULONG NonPagedPoolUsage;
	ULONG PagedPoolAllocs;
	ULONG PagedPoolFrees;
	ULONG NonPagedPoolAllocs;
	ULONG NonPagedPoolFrees;
	ULONG TotalFreeSystemPtes;
	ULONG SystemCodePage;
	ULONG TotalSystemDriverPages;
	ULONG TotalSystemCodePages;
	ULONG SmallNonPagedLookasideListAllocateHits;
	ULONG SmallPagedLookasideListAllocateHits;
	ULONG Reserved3;
	ULONG MmSystemCachePage;
	ULONG PagedPoolPage;
	ULONG SystemDriverPage;
	ULONG FastReadNoWait;
	ULONG FastReadWait;
	ULONG FastReadResourceMiss;
	ULONG FastReadNotPossible;
	ULONG FastMdlReadNoWait;
	ULONG FastMdlReadWait;
	ULONG FastMdlReadResourceMiss;
	ULONG FastMdlReadNotPossible;
	ULONG MapDataNoWait;
	ULONG MapDataWait;
	ULONG MapDataNoWaitMiss;
	ULONG MapDataWaitMiss;
	ULONG PinMappedDataCount;
	ULONG PinReadNoWait;
	ULONG PinReadWait;
	ULONG PinReadNoWaitMiss;
	ULONG PinReadWaitMiss;
	ULONG CopyReadNoWait;
	ULONG CopyReadWait;
	ULONG CopyReadNoWaitMiss;
	ULONG CopyReadWaitMiss;
	ULONG MdlReadNoWait;
	ULONG MdlReadWait;
	ULONG MdlReadNoWaitMiss;
	ULONG MdlReadWaitMiss;
	ULONG ReadAheadIos;
	ULONG LazyWriteIos;
	ULONG LazyWritePages;
	ULONG DataFlushes;
	ULONG DataPages;
	ULONG ContextSwitches;
	ULONG FirstLevelTbFills;
	ULONG SecondLevelTbFills;
	ULONG SystemCalls;
} SYSTEM_PERFORMANCE_INFORMATION, *PSYSTEM_PERFORMANCE_INFORMATION;

typedef struct _SYSTEM_TIME_OF_DAY_INFORMATION { // Information Class 3
	LARGE_INTEGER BootTime;
	LARGE_INTEGER CurrentTime;
	LARGE_INTEGER TimeZoneBias;
	ULONG CurrentTimeZoneId;
} SYSTEM_TIME_OF_DAY_INFORMATION, *PSYSTEM_TIME_OF_DAY_INFORMATION;

typedef enum _THREAD_STATE {
	StateInitialized,
	StateReady,
	StateRunning,
	StateStandby,
	StateTerminated,
	StateWait,
	StateTransition,
	StateUnknown
} THREAD_STATE, * PTHREAD_STATE;

#if _WIN32_WINNT <= 0x0500
typedef enum _KWAIT_REASON {
	Executive,
	FreePage,
	PageIn,
	PoolAllocation,
	DelayExecution,
	Suspended,
	UserRequest,
	WrExecutive,
	WrFreePage,
	WrPageIn,
	WrPoolAllocation,
	WrDelayExecution,
	WrSuspended,
	WrUserRequest,
	WrEventPair,
	WrQueue,
	WrLpcReceive,
	WrLpcReply,
	WrVirtualMemory,
	WrPageOut,
	WrRendezvous,
	Spare2,
	Spare3,
	Spare4,
	Spare5,
	Spare6,
	WrKernel
} KWAIT_REASON;
#else
typedef enum _KWAIT_REASON {
	Executive,
	FreePage,
	PageIn,
	PoolAllocation,
	DelayExecution,
	Suspended,
	UserRequest,
	WrExecutive,
	WrFreePage,
	WrPageIn,
	WrPoolAllocation,
	WrDelayExecution,
	WrSuspended,
	WrUserRequest,
	WrEventPair,
	WrQueue,
	WrLpcReceive,
	WrLpcReply,
	WrVirtualMemory,
	WrPageOut,
	WrRendezvous,
	Spare2,
	Spare3,
	Spare4,
	Spare5,
	Spare6,
	WrKernel,
	WrResource,
	WrPushLock,
	WrMutex,
	WrQuantumEnd,
	WrDispatchInt,
	WrPreempted,
	WrYieldExecution,
	MaximumWaitReason
} KWAIT_REASON;
#endif

typedef struct _SYSTEM_THREAD_INFORMATION {
	LARGE_INTEGER KernelTime;
	LARGE_INTEGER UserTime;
	LARGE_INTEGER CreateTime;
	ULONG WaitTime;
	PVOID StartAddress;
	CLIENT_ID ClientId;
	KPRIORITY Priority;
	KPRIORITY BasePriority;
	ULONG ContextSwitchCount;
	THREAD_STATE State;
	KWAIT_REASON WaitReason;
} SYSTEM_THREAD_INFORMATION, * PSYSTEM_THREAD_INFORMATION;

typedef struct _SYSTEM_THREAD_INFORMATION _SYSTEM_THREADS, SYSTEM_THREADS, * PSYSTEM_THREADS;

typedef struct _SYSTEM_PROCESS_INFORMATION { // Information Class 5
	union {
		ULONG NextEntryDelta;
		ULONG NextEntryOffset;
	};
	union {
		ULONG ThreadCount;
		ULONG NumberOfThreads;
	};
	ULONG Reserved1[6];
	LARGE_INTEGER CreateTime;
	LARGE_INTEGER UserTime;
	LARGE_INTEGER KernelTime;
	UNICODE_STRING ProcessName;
	KPRIORITY BasePriority;
	union {
		ULONG ProcessId;
		HANDLE UniqueProcessId;
	};
	union {
		ULONG InheritedFromProcessId;
		HANDLE InheritedFromUniqueProcessId;
	};
	ULONG HandleCount;
	ULONG Reserved2[2];
	ULONG PeakVirtualSize;
	ULONG VirtualSize;
	ULONG PageFaultCount;
	ULONG PeakWorkingSetSize;
	ULONG WorkingSetSize;
	ULONG QuotaPeakPagedPoolUsage;
	ULONG QuotaPagedPoolUsage;
	ULONG QuotaPeakNonPagedPoolUsage;
	ULONG QuotaNonPagedPoolUsage;
	ULONG PagefileUsage;
	ULONG PeakPagefileUsage;
	ULONG PrivatePageCount;
#if _WIN32_WINNT >= 0x0500
	IO_COUNTERS IoCounters; // Windows 2000 only
#endif
	SYSTEM_THREAD_INFORMATION Threads[1];
} SYSTEM_PROCESS_INFORMATION, *PSYSTEM_PROCESS_INFORMATION;

typedef struct _SYSTEM_PROCESS_INFORMATION _SYSTEM_PROCESSES, SYSTEM_PROCESSES, * PSYSTEM_PROCESSES;

//
// Nt4 version
//

typedef struct _SYSTEM_PROCESS_INFORMATION_V4 { // Information Class 5
	union {
		ULONG NextEntryDelta;
		ULONG NextEntryOffset;
	};
	union {
		ULONG ThreadCount;
		ULONG NumberOfThreads;
	};
	ULONG Reserved1[6];
	LARGE_INTEGER CreateTime;
	LARGE_INTEGER UserTime;
	LARGE_INTEGER KernelTime;
	UNICODE_STRING ProcessName;
	KPRIORITY BasePriority;
	union {
		ULONG ProcessId;
		HANDLE UniqueProcessId;
	};
	union {
		ULONG InheritedFromProcessId;
		HANDLE InheritedFromUniqueProcessId;
	};
	ULONG HandleCount;
	ULONG Reserved2[2];
	ULONG PeakVirtualSize;
	ULONG VirtualSize;
	ULONG PageFaultCount;
	ULONG PeakWorkingSetSize;
	ULONG WorkingSetSize;
	ULONG QuotaPeakPagedPoolUsage;
	ULONG QuotaPagedPoolUsage;
	ULONG QuotaPeakNonPagedPoolUsage;
	ULONG QuotaNonPagedPoolUsage;
	ULONG PagefileUsage;
	ULONG PeakPagefileUsage;
	ULONG PrivatePageCount;
	SYSTEM_THREAD_INFORMATION Threads[1];
} SYSTEM_PROCESS_INFORMATION_V4, *PSYSTEM_PROCESS_INFORMATION_V4;

//
// Nt5 version
//

typedef struct _SYSTEM_PROCESS_INFORMATION_V5 { // Information Class 5
	union {
		ULONG NextEntryDelta;
		ULONG NextEntryOffset;
	};
	union {
		ULONG ThreadCount;
		ULONG NumberOfThreads;
	};
	ULONG Reserved1[6];
	LARGE_INTEGER CreateTime;
	LARGE_INTEGER UserTime;
	LARGE_INTEGER KernelTime;
	UNICODE_STRING ProcessName;
	KPRIORITY BasePriority;
	union {
		ULONG ProcessId;
		HANDLE UniqueProcessId;
	};
	union {
		ULONG InheritedFromProcessId;
		HANDLE InheritedFromUniqueProcessId;
	};
	ULONG HandleCount;
	ULONG Reserved2[2];
	ULONG PeakVirtualSize;
	ULONG VirtualSize;
	ULONG PageFaultCount;
	ULONG PeakWorkingSetSize;
	ULONG WorkingSetSize;
	ULONG QuotaPeakPagedPoolUsage;
	ULONG QuotaPagedPoolUsage;
	ULONG QuotaPeakNonPagedPoolUsage;
	ULONG QuotaNonPagedPoolUsage;
	ULONG PagefileUsage;
	ULONG PeakPagefileUsage;
	ULONG PrivatePageCount;
	IO_COUNTERS IoCounters; // Windows 2000 only
	SYSTEM_THREAD_INFORMATION Threads[1];
} SYSTEM_PROCESS_INFORMATION_V5, *PSYSTEM_PROCESS_INFORMATION_V5;

typedef struct _SYSTEM_CALLS_INFORMATION { // Information Class 6
	ULONG Size;
	ULONG NumberOfDescriptorTables;
	ULONG NumberOfRoutinesInTable[1];
	// ULONG CallCounts[];
} SYSTEM_CALLS_INFORMATION, *PSYSTEM_CALLS_INFORMATION;

typedef struct _SYSTEM_CONFIGURATION_INFORMATION { // Information Class 7
	ULONG DiskCount;
	ULONG FloppyCount;
	ULONG CdRomCount;
	ULONG TapeCount;
	ULONG SerialCount;
	ULONG ParallelCount;
} SYSTEM_CONFIGURATION_INFORMATION, *PSYSTEM_CONFIGURATION_INFORMATION;

typedef struct _SYSTEM_PROCESSOR_TIMES { // Information Class 8
	LARGE_INTEGER IdleTime;
	LARGE_INTEGER KernelTime;
	LARGE_INTEGER UserTime;
	LARGE_INTEGER DpcTime;
	LARGE_INTEGER InterruptTime;
	ULONG InterruptCount;
} SYSTEM_PROCESSOR_TIMES, *PSYSTEM_PROCESSOR_TIMES;

typedef struct _SYSTEM_GLOBAL_FLAG { // Information Class 9
	ULONG GlobalFlag;
} SYSTEM_GLOBAL_FLAG, *PSYSTEM_GLOBAL_FLAG;

#include <pshpack4.h>
typedef struct _SYSTEM_MODULE_INFORMATION { // Information Class 11
#ifdef _WIN64
	PVOID Reserved[2];
#else
	ULONG Reserved[2];
#endif
	PVOID Base;
	ULONG Size;
	ULONG Flags;
	USHORT Index;
	USHORT Unknown;
	USHORT LoadCount;
	USHORT ModuleNameOffset;
	CHAR ImageName[256];
} SYSTEM_MODULE_INFORMATION, *PSYSTEM_MODULE_INFORMATION;
#include <poppack.h>

typedef struct _SYSTEM_LOCK_INFORMATION { // Information Class 12
	PVOID Address;
	USHORT Type;
	USHORT Reserved1;
	ULONG ExclusiveOwnerThreadId;
	ULONG ActiveCount;
	ULONG ContentionCount;
	ULONG Reserved2[2];
	ULONG NumberOfSharedWaiters;
	ULONG NumberOfExclusiveWaiters;
} SYSTEM_LOCK_INFORMATION, *PSYSTEM_LOCK_INFORMATION;

typedef struct _SYSTEM_HANDLE_INFORMATION { // Information Class 16
	ULONG ProcessId;
	UCHAR ObjectTypeNumber;
	UCHAR Flags; // 0x01 = PROTECT_FROM_CLOSE, 0x02 = INHERIT
	USHORT Handle;
	PVOID Object;
	ACCESS_MASK GrantedAccess;
} SYSTEM_HANDLE_INFORMATION, *PSYSTEM_HANDLE_INFORMATION;

typedef struct _SYSTEM_OBJECT_TYPE_INFORMATION { // Information Class 17
	ULONG NextEntryOffset;
	ULONG ObjectCount;
	ULONG HandleCount;
	ULONG TypeNumber;
	ULONG InvalidAttributes;
	GENERIC_MAPPING GenericMapping;
	ACCESS_MASK ValidAccessMask;
	POOL_TYPE PoolType;
	UCHAR Unknown;
	UNICODE_STRING Name;
} SYSTEM_OBJECT_TYPE_INFORMATION, *PSYSTEM_OBJECT_TYPE_INFORMATION;

typedef struct _SYSTEM_OBJECT_INFORMATION {
	ULONG NextEntryOffset;
	PVOID Object;
	ULONG CreatorProcessId;
	USHORT Unknown;
	USHORT Flags;
	ULONG PointerCount;
	ULONG HandleCount;
	ULONG PagedPoolUsage;
	ULONG NonPagedPoolUsage;
	ULONG ExclusiveProcessId;
	PSECURITY_DESCRIPTOR SecurityDescriptor;
	UNICODE_STRING Name;
} SYSTEM_OBJECT_INFORMATION, *PSYSTEM_OBJECT_INFORMATION;

typedef struct _SYSTEM_PAGEFILE_INFORMATION { // Information Class 18
	ULONG NextEntryOffset;
	ULONG CurrentSize;
	ULONG TotalUsed;
	ULONG PeakUsed;
	UNICODE_STRING FileName;
} SYSTEM_PAGEFILE_INFORMATION, *PSYSTEM_PAGEFILE_INFORMATION;

typedef struct _SYSTEM_INSTRUCTION_EMULATION_INFORMATION { // Info Class 19
	ULONG SegmentNotPresent;
	ULONG TwoByteOpcode;
	ULONG ESprefix;
	ULONG CSprefix;
	ULONG SSprefix;
	ULONG DSprefix;
	ULONG FSPrefix;
	ULONG GSprefix;
	ULONG OPER32prefix;
	ULONG ADDR32prefix;
	ULONG INSB;
	ULONG INSW;
	ULONG OUTSB;
	ULONG OUTSW;
	ULONG PUSHFD;
	ULONG POPFD;
	ULONG INTnn;
	ULONG INTO;
	ULONG IRETD;
	ULONG INBimm;
	ULONG INWimm;
	ULONG OUTBimm;
	ULONG OUTWimm;
	ULONG INB;
	ULONG INW;
	ULONG OUTB;
	ULONG OUTW;
	ULONG LOCKprefix;
	ULONG REPNEprefix;
	ULONG REPprefix;
	ULONG HLT;
	ULONG CLI;
	ULONG STI;
	ULONG GenericInvalidOpcode;
} SYSTEM_INSTRUCTION_EMULATION_INFORMATION,
*PSYSTEM_INSTRUCTION_EMULATION_INFORMATION;

typedef struct _SYSTEM_CACHE_INFORMATION { // Information Class 21
	ULONG SystemCacheWsSize;
	ULONG SystemCacheWsPeakSize;
	ULONG SystemCacheWsFaults;
	ULONG SystemCacheWsMinimum;
	ULONG SystemCacheWsMaximum;
	ULONG TransitionSharedPages;
	ULONG TransitionSharedPagesPeak;
	ULONG Reserved[2];
} SYSTEM_CACHE_INFORMATION, *PSYSTEM_CACHE_INFORMATION;

typedef struct _SYSTEM_POOL_TAG_INFORMATION { // Information Class 22
	CHAR Tag[4];
	ULONG PagedPoolAllocs;
	ULONG PagedPoolFrees;
	ULONG PagedPoolUsage;
	ULONG NonPagedPoolAllocs;
	ULONG NonPagedPoolFrees;
	ULONG NonPagedPoolUsage;
} SYSTEM_POOL_TAG_INFORMATION, *PSYSTEM_POOL_TAG_INFORMATION;

typedef struct _SYSTEM_PROCESSOR_STATISTICS { // Information Class 23
	ULONG ContextSwitches;
	ULONG DpcCount;
	ULONG DpcRequestRate;
	ULONG TimeIncrement;
	ULONG DpcBypassCount;
	ULONG ApcBypassCount;
} SYSTEM_PROCESSOR_STATISTICS, *PSYSTEM_PROCESSOR_STATISTICS;

typedef struct _SYSTEM_DPC_INFORMATION { // Information Class 24
	ULONG Reserved;
	ULONG MaximumDpcQueueDepth;
	ULONG MinimumDpcRate;
	ULONG AdjustDpcThreshold;
	ULONG IdealDpcRate;
} SYSTEM_DPC_INFORMATION, *PSYSTEM_DPC_INFORMATION;

typedef struct _SYSTEM_LOAD_IMAGE { // Information Class 26
	UNICODE_STRING ModuleName;
	PVOID ModuleBase;
	PVOID Unknown;
	PVOID EntryPoint;
	PVOID ExportDirectory;
} SYSTEM_LOAD_IMAGE, *PSYSTEM_LOAD_IMAGE;

typedef struct _SYSTEM_UNLOAD_IMAGE { // Information Class 27
	PVOID ModuleBase;
} SYSTEM_UNLOAD_IMAGE, *PSYSTEM_UNLOAD_IMAGE;

typedef struct _SYSTEM_QUERY_TIME_ADJUSTMENT { // Information Class 28
	ULONG TimeAdjustment;
	ULONG MaximumIncrement;
	BOOLEAN TimeSynchronization;
} SYSTEM_QUERY_TIME_ADJUSTMENT, *PSYSTEM_QUERY_TIME_ADJUSTMENT;

typedef struct _SYSTEM_SET_TIME_ADJUSTMENT { // Information Class 28
	ULONG TimeAdjustment;
	BOOLEAN TimeSynchronization;
} SYSTEM_SET_TIME_ADJUSTMENT, *PSYSTEM_SET_TIME_ADJUSTMENT;

typedef struct _SYSTEM_CRASH_DUMP_INFORMATION { // Information Class 32
	HANDLE CrashDumpSectionHandle;
#if _WIN32_WINNT >= 0x0500
	HANDLE Unknown; // Windows 2000 only
#endif
} SYSTEM_CRASH_DUMP_INFORMATION, *PSYSTEM_CRASH_DUMP_INFORMATION;

typedef struct _SYSTEM_EXCEPTION_INFORMATION { // Information Class 33
	ULONG AlignmentFixupCount;
	ULONG ExceptionDispatchCount;
	ULONG FloatingEmulationCount;
	ULONG Reserved;
} SYSTEM_EXCEPTION_INFORMATION, *PSYSTEM_EXCEPTION_INFORMATION;

typedef struct _SYSTEM_CRASH_DUMP_STATE_INFORMATION { // Information Class 34
	ULONG CrashDumpSectionExists;
	ULONG Unknown; // Windows 2000 only
} SYSTEM_CRASH_DUMP_STATE_INFORMATION, *PSYSTEM_CRASH_DUMP_STATE_INFORMATION;

typedef struct _SYSTEM_KERNEL_DEBUGGER_INFORMATION { // Information Class 35
	BOOLEAN DebuggerEnabled;
	BOOLEAN DebuggerNotPresent;
} SYSTEM_KERNEL_DEBUGGER_INFORMATION, *PSYSTEM_KERNEL_DEBUGGER_INFORMATION;

typedef struct _SYSTEM_CONTEXT_SWITCH_INFORMATION { // Information Class 36
	ULONG ContextSwitches;
	ULONG ContextSwitchCounters[11];
} SYSTEM_CONTEXT_SWITCH_INFORMATION, *PSYSTEM_CONTEXT_SWITCH_INFORMATION;

typedef struct _SYSTEM_REGISTRY_QUOTA_INFORMATION { // Information Class 37
	ULONG RegistryQuota;
	ULONG RegistryQuotaInUse;
	ULONG PagedPoolSize;
} SYSTEM_REGISTRY_QUOTA_INFORMATION, *PSYSTEM_REGISTRY_QUOTA_INFORMATION;

typedef struct _SYSTEM_LOAD_AND_CALL_IMAGE { // Information Class 38
	UNICODE_STRING ModuleName;
} SYSTEM_LOAD_AND_CALL_IMAGE, *PSYSTEM_LOAD_AND_CALL_IMAGE;

typedef struct _SYSTEM_PRIORITY_SEPARATION { // Information Class 39
	ULONG PrioritySeparation;
} SYSTEM_PRIORITY_SEPARATION, *PSYSTEM_PRIORITY_SEPARATION;

typedef struct _SYSTEM_TIME_ZONE_INFORMATION { // Information Class 44
	LONG Bias;
	WCHAR StandardName[32];
	NTSYSTEMTIME StandardDate;
	LONG StandardBias;
	WCHAR DaylightName[32];
	NTSYSTEMTIME DaylightDate;
	LONG DaylightBias;
} SYSTEM_TIME_ZONE_INFORMATION, *PSYSTEM_TIME_ZONE_INFORMATION;

typedef struct _SYSTEM_LOOKASIDE_INFORMATION { // Information Class 45
	USHORT Depth;
	USHORT MaximumDepth;
	ULONG TotalAllocates;
	ULONG AllocateMisses;
	ULONG TotalFrees;
	ULONG FreeMisses;
	POOL_TYPE Type;
	ULONG Tag;
	ULONG Size;
} SYSTEM_LOOKASIDE_INFORMATION, *PSYSTEM_LOOKASIDE_INFORMATION;

typedef struct _SYSTEM_SET_TIME_SLIP_EVENT { // Information Class 46
	HANDLE TimeSlipEvent;
} SYSTEM_SET_TIME_SLIP_EVENT, *PSYSTEM_SET_TIME_SLIP_EVENT;

typedef struct _SYSTEM_CREATE_SESSION { // Information Class 47
	ULONG SessionId;
} SYSTEM_CREATE_SESSION, *PSYSTEM_CREATE_SESSION;

typedef struct _SYSTEM_DELETE_SESSION { // Information Class 48
	ULONG SessionId;
} SYSTEM_DELETE_SESSION, *PSYSTEM_DELETE_SESSION;

typedef struct _SYSTEM_RANGE_START_INFORMATION { // Information Class 50
	PVOID SystemRangeStart;
} SYSTEM_RANGE_START_INFORMATION, *PSYSTEM_RANGE_START_INFORMATION;

typedef struct _SYSTEM_SESSION_PROCESSES_INFORMATION { // Information Class 53
	ULONG SessionId;
	ULONG BufferSize;
	PVOID Buffer;
} SYSTEM_SESSION_PROCESSES_INFORMATION, *PSYSTEM_SESSION_PROCESSES_INFORMATION;

typedef struct _SYSTEM_EXTENDED_HANDLE_TABLE_ENTRY_INFO {
	PVOID    Object;
	HANDLE   UniqueProcessId;
	HANDLE   HandleValue;
	ULONG    GrantedAccess;
	USHORT   CreatorBackTraceIndex; // Always zero on 64-bit platforms
	USHORT   ObjectTypeIndex;
	ULONG    HandleAttributes;      // Maximum 8 significant bits
	ULONG    Reserved;              // Reserved - uninitialized
} SYSTEM_EXTENDED_HANDLE_TABLE_ENTRY_INFO, *PSYSTEM_EXTENDED_HANDLE_TABLE_ENTRY_INFO;


typedef struct _SYSTEM_EXTENDED_HANDLE_INFORMATION // Information Class 64
{
	SIZE_T                                  NumberOfHandles;
	SIZE_T                                  Reserved;  // Reserved - uinitialized
	//
	SYSTEM_EXTENDED_HANDLE_TABLE_ENTRY_INFO Handles[ 1 ];
} SYSTEM_EXTENDED_HANDLE_INFORMATION, * PSYSTEM_EXTENDED_HANDLE_INFORMATION;


//
// From Alex Ionescu - Hotpatching support
//

//
// Hotpatch flags
//
#define RTL_HOTPATCH_SUPPORTED_FLAG         0x01
#define RTL_HOTPATCH_SWAP_OBJECT_NAMES      0x08 << 24
#define RTL_HOTPATCH_SYNC_RENAME_FILES      0x10 << 24
#define RTL_HOTPATCH_PATCH_USER_MODE        0x20 << 24
#define RTL_HOTPATCH_REMAP_SYSTEM_DLL       0x40 << 24
#define RTL_HOTPATCH_PATCH_KERNEL_MODE      0x80 << 24


typedef struct _ACTIVATION_CONTEXT* PACTIVATION_CONTEXT;

typedef struct _LDR_DATA_TABLE_ENTRY {
	LIST_ENTRY InLoadOrderLinks;
	LIST_ENTRY InMemoryOrderLinks;
	LIST_ENTRY InInitializationOrderLinks;
	PVOID DllBase;
	PVOID EntryPoint;
	ULONG SizeOfImage;
	UNICODE_STRING FullDllName;
	UNICODE_STRING BaseDllName;
	ULONG Flags;
	USHORT LoadCount;
	USHORT TlsIndex;
	LIST_ENTRY HashLinks;
	PVOID SectionPointer;
	ULONG CheckSum;
	ULONG TimeDateStamp;
	PVOID LoadedImports;
	PACTIVATION_CONTEXT EntryPointActivationContext;
	PVOID PatchInformation;
} LDR_DATA_TABLE_ENTRY, * PLDR_DATA_TABLE_ENTRY;
 
//
// Hotpatch Header
//
typedef struct _RTL_PATCH_HEADER
{
    LIST_ENTRY PatchList;
    PVOID PatchImageBase;
    struct _RTL_PATCH_HEADER *NextPath;
    ULONG PatchFlags;
    LONG PatchRefCount;
    struct _HOTPATCH_HEADER *HotpatchHeader;
    UNICODE_STRING TargetDllName;
    PVOID TargetDllBase;
    PLDR_DATA_TABLE_ENTRY TargetLdrDataTableEntry;
    PLDR_DATA_TABLE_ENTRY PatchLdrDataTableEntry;
    struct _SYSTEM_HOTPATCH_CODE_INFORMATION *CodeInfo;
} RTL_PATCH_HEADER, *PRTL_PATCH_HEADER;
 
// Class 69
typedef struct _SYSTEM_HOTPATCH_CODE_INFORMATION
{
    ULONG Flags;
    ULONG InfoSize;
    union
    {
        struct
        {
            ULONG Foo;
        } CodeInfo;
        struct
        {
            USHORT NameOffset;
            USHORT NameLength;
        } KernelInfo;
        struct
        {
            USHORT NameOffset;
            USHORT NameLength;
            USHORT TargetNameOffset;
            USHORT TargetNameLength;
            UCHAR PatchingFinished;
        } UserModeInfo;
        struct
        {
            USHORT NameOffset;
            USHORT NameLength;
            USHORT TargetNameOffset;
            USHORT TargetNameLength;
            UCHAR PatchingFinished;
            NTSTATUS ReturnCode;
            HANDLE TargetProcess;
        } InjectionInfo;
        struct
        {
            HANDLE FileHandle1;
            PIO_STATUS_BLOCK IoStatusBlock1;
            PVOID RenameInformation1;
            PVOID RenameInformationLength1;
            HANDLE FileHandle2;
            PIO_STATUS_BLOCK IoStatusBlock2;
            PVOID RenameInformation2;
            PVOID RenameInformationLength2;
        } RenameInfo;
        struct
        {
            HANDLE ParentDirectory;
            HANDLE ObjectHandle1;
            HANDLE ObjectHandle2;
        } AtomicSwap;
    };
} SYSTEM_HOTPATCH_CODE_INFORMATION, *PSYSTEM_HOTPATCH_CODE_INFORMATION;
 
//
// Hotpatch Header (In the .HOTP1 section)
//
typedef struct _HOTPATCH_HEADER
{
    ULONG Signature;
    ULONG Version;
    ULONG FixupRgnCount;
    ULONG FixupRgnRva;
    ULONG ValidationCount;
    ULONG ValidationArrayRva;
    ULONG HookCount;
    ULONG HookArrayRva;
    ULONGLONG OrigHotpBaseAddress;
    ULONGLONG OrigTargetBaseAddress;
    ULONG TargetNameRva;
    ULONG ModuleIdMethod;
    union
    {
        ULONG Foo;
    } TargetModuleIdvalue;
} HOTPATCH_HEADER, *PHOTPATCH_HEADER;

#ifndef _NTTYPES_NO_WINNT

typedef enum _LOGICAL_PROCESSOR_RELATIONSHIP {
	RelationProcessorCore,
	RelationNumaNode,
	RelationCache
} LOGICAL_PROCESSOR_RELATIONSHIP;

#define LTP_PC_SMT 0x1

typedef enum _PROCESSOR_CACHE_TYPE {
	CacheUnified,
	CacheInstruction,
	CacheData,
	CacheTrace
} PROCESSOR_CACHE_TYPE;

#define CACHE_FULLY_ASSOCIATIVE 0xFF

typedef struct _CACHE_DESCRIPTOR {
	BYTE   Level;
	BYTE   Associativity;
	WORD   LineSize;
	DWORD  Size;
	PROCESSOR_CACHE_TYPE Type;
} CACHE_DESCRIPTOR, *PCACHE_DESCRIPTOR;

typedef struct _SYSTEM_LOGICAL_PROCESSOR_INFORMATION { // Information Class 73
	ULONG_PTR   ProcessorMask;
	LOGICAL_PROCESSOR_RELATIONSHIP Relationship;
	union {
		struct {
			BYTE  Flags;
		} ProcessorCore;
		struct {
			DWORD NodeNumber;
		} NumaNode;
		CACHE_DESCRIPTOR Cache;
		ULONGLONG  Reserved[2];
	};
} SYSTEM_LOGICAL_PROCESSOR_INFORMATION, *PSYSTEM_LOGICAL_PROCESSOR_INFORMATION;

#endif

typedef struct _SYSTEM_POOL_BLOCK {
	BOOLEAN Allocated;
	USHORT Unknown;
	ULONG Size;
	CHAR Tag[4];
} SYSTEM_POOL_BLOCK, *PSYSTEM_POOL_BLOCK;

typedef struct _SYSTEM_POOL_BLOCKS_INFORMATION { // Info Classes 14 and 15
	ULONG PoolSize;
	PVOID PoolBase;
	USHORT Unknown;
	ULONG NumberOfBlocks;
	SYSTEM_POOL_BLOCK PoolBlocks[1];
} SYSTEM_POOL_BLOCKS_INFORMATION, *PSYSTEM_POOL_BLOCKS_INFORMATION;

typedef struct _SYSTEM_MEMORY_USAGE {
	PVOID Name;
	USHORT Valid;
	USHORT Standby;
	USHORT Modified;
	USHORT PageTables;
} SYSTEM_MEMORY_USAGE, *PSYSTEM_MEMORY_USAGE;

typedef struct _SYSTEM_MEMORY_USAGE_INFORMATION { // Info Classes 25 and 29
	ULONG Reserved;
	PVOID EndOfData;
	SYSTEM_MEMORY_USAGE MemoryUsage[1];
} SYSTEM_MEMORY_USAGE_INFORMATION, *PSYSTEM_MEMORY_USAGE_INFORMATION;

#ifndef _NTTYPES_NO_WINNT

#define MAXIMUM_NUMA_NODES 16

typedef struct _SYSTEM_NUMA_INFORMATION {
    DWORD       HighestNodeNumber;
    DWORD       Reserved;
    union {
        ULONGLONG   ActiveProcessorsAffinityMask[MAXIMUM_NUMA_NODES];
        ULONGLONG   AvailableMemory[MAXIMUM_NUMA_NODES];
    };
} SYSTEM_NUMA_INFORMATION, *PSYSTEM_NUMA_INFORMATION;

#endif


typedef enum _SHUTDOWN_ACTION {
	ShutdownNoReboot,
	ShutdownReboot,
	ShutdownPowerOff
} SHUTDOWN_ACTION;

//
// For compatiblity - do not use!
// Instead use the SYSDBG_COMMAND enumeration.
//

typedef enum _DEBUG_CONTROL_CODE {
	DebugGetTraceInformation = 1,
	DebugSetInternalBreakpoint,
	DebugSetSpecialCall,
	DebugClearSpecialCalls,
	DebugQuerySpecialCalls,
	DebugDbgBreakPoint
} DEBUG_CONTROL_CODE, * PDEBUG_CONTROL_CODE;

typedef enum _SYSDBG_COMMAND {					// Idx		Input					Output				Notes
#if _WIN32_WINNT >= 0x0502
	SysDbgQueryModuleInformation,				// 0
#endif
	SysDbgQueryTraceInformation = 1,			// 1
	SysDbgSetTracepoint,						// 2
	SysDbgSetSpecialCall,						// 3
	SysDbgClearSpecialCalls,					// 4
	SysDbgQuerySpecialCalls,					// 5
	SysDbgBreakPoint,							// 6
#if _WIN32_WINNT  >= 0x0501
	SysDbgQueryVersion,							// 7
	SysDbgReadVirtual,							// 8		SYSDBG_VIRTUAL			Unused				Output buffer specified by SYSDBG_VIRTUAL structure.
	SysDbgWriteVirutal,							// 9		SYSDBG_VIRTUAL			Unused				Output buffer specified by SYSDBG_VIRTUAL structure.
	SysDbgReadPhysical,							// 10
	SysDbgWritePhysical,						// 11
	SysDbgReadControlSpace,
	SysDbgWriteControlSpace,
	SysDbgReadIoSpace,
	SysDbgWriteIoSpace,
	SysDbgReadMsr,
	SysDbgWriteMsr,
	SysDbgReadBusData,
	SysDbgWriteBusData,
	SysDbgCheckLowMemory,
#if _WIN32_WINNT >= 0x0502
	SysDbgEnableKernelDebugger,
	SysDbgDisableKernelDebugger,
	SysDbgGetAutoKdEnable,
	SysDbgSetAutoKdEnable,
	SysDbgGetPrintBufferSize,
	SysDbgSetPrintBufferSize,
	SysDbgGetKdUmExceptionEnable,
	SysDbgSetKdUmExceptionEnable,
	SysDbgGetTriageDump,
	SysDbgGetKdBlockEnable,
	SysDbgSetKdBlockEnable
#endif
#endif
} SYSDBG_COMMAND, * PSYSDBG_COMMAND;

typedef enum _BUS_DATA_TYPE {
	ConfigurationSpaceUndefined = -1,
	Cmos,
	EisaConfiguration,
	Pos,
	CbusConfiguration,
	PCIConfiguration,
	VMEConfiguration,
	NuBusConfiguration,
	PCMCIAConfiguration,
	MPIConfiguration,
	MPSAConfiguration,
	PNPISAConfiguration,
	SgiInternalConfiguration,
	MaximumBusDataType
} BUS_DATA_TYPE, *PBUS_DATA_TYPE;

typedef struct _SYSDBG_VIRTUAL {
	PVOID Address;
	PVOID Buffer;
	ULONG Request; // Length
} SYSDBG_VIRTUAL, * PSYSDBG_VIRTUAL;

typedef struct _SYSDBG_PHYSICAL {
	PHYSICAL_ADDRESS Address;
	PVOID Buffer;
	ULONG Request; // Length
} SYSDBG_PHYSICAL, * PSYSDBG_PHYSICAL;

typedef struct _SYSDBG_CONTROL_SPACE {
	ULONG64 Address;
	PVOID Buffer;
	ULONG Request; // Length
	ULONG Processor;
} SYSDBG_CONTROL_SPACE, * PSYSDBG_CONTROL_SPACE;

typedef struct _SYSDBG_IO_SPACE {
	ULONG64 Address;
	PVOID Buffer;
	ULONG Request; // Length
	INTERFACE_TYPE InterfaceType;
	ULONG BusNumber;
	ULONG AddressSpace;
} SYSDBG_IO_SPACE, * PSYSDBG_IO_SPACE;

typedef struct _SYSDBG_MSR {
	ULONG Msr;
	ULONG64 Data;
} SYSDBG_MSR, * PSYSDBG_MSR;

typedef struct _SYSDBG_BUS_DATA {
	ULONG Address;
	PVOID Buffer;
	ULONG Request; // Length
	BUS_DATA_TYPE BusDataType;
	ULONG BusNumber;
	ULONG SlotNumber;
} SYSDBG_BUS_DATA, * PSYSDBG_BUS_DATA;


#ifndef _NTTYPES_NO_WINNT

#ifdef _X86_

//
// The following values specify the type of failing access when the status is 
// STATUS_ACCESS_VIOLATION and the first parameter in the exception record.
//

#define EXCEPTION_READ_FAULT          0 // Access violation was caused by a read
#define EXCEPTION_WRITE_FAULT         1 // Access violation was caused by a write
#define EXCEPTION_EXECUTE_FAULT       8 // Access violation was caused by an instruction fetch

// begin_wx86

//
//  Define the size of the 80387 save area, which is in the context frame.
//

#define SIZE_OF_80387_REGISTERS      80

//
// The following flags control the contents of the CONTEXT structure.
//

#if !defined(RC_INVOKED)

#define CONTEXT_i386    0x00010000    // this assumes that i386 and
#define CONTEXT_i486    0x00010000    // i486 have identical context records

// end_wx86

#define CONTEXT_CONTROL         (CONTEXT_i386 | 0x00000001L) // SS:SP, CS:IP, FLAGS, BP
#define CONTEXT_INTEGER         (CONTEXT_i386 | 0x00000002L) // AX, BX, CX, DX, SI, DI
#define CONTEXT_SEGMENTS        (CONTEXT_i386 | 0x00000004L) // DS, ES, FS, GS
#define CONTEXT_FLOATING_POINT  (CONTEXT_i386 | 0x00000008L) // 387 state
#define CONTEXT_DEBUG_REGISTERS (CONTEXT_i386 | 0x00000010L) // DB 0-3,6,7
#define CONTEXT_EXTENDED_REGISTERS  (CONTEXT_i386 | 0x00000020L) // cpu specific extensions

#define CONTEXT_FULL (CONTEXT_CONTROL | CONTEXT_INTEGER |\
	CONTEXT_SEGMENTS)

#define CONTEXT_ALL (CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS | CONTEXT_EXTENDED_REGISTERS)

// begin_wx86

#endif

#define MAXIMUM_SUPPORTED_EXTENSION     512

typedef struct _FLOATING_SAVE_AREA {
	DWORD   ControlWord;
	DWORD   StatusWord;
	DWORD   TagWord;
	DWORD   ErrorOffset;
	DWORD   ErrorSelector;
	DWORD   DataOffset;
	DWORD   DataSelector;
	BYTE    RegisterArea[SIZE_OF_80387_REGISTERS];
	DWORD   Cr0NpxState;
} FLOATING_SAVE_AREA;

typedef FLOATING_SAVE_AREA *PFLOATING_SAVE_AREA;

//
// Context Frame
//
//  This frame has a several purposes: 1) it is used as an argument to
//  NtContinue, 2) is is used to constuct a call frame for APC delivery,
//  and 3) it is used in the user level thread creation routines.
//
//  The layout of the record conforms to a standard call frame.
//

typedef struct _CONTEXT {

	//
	// The flags values within this flag control the contents of
	// a CONTEXT record.
	//
	// If the context record is used as an input parameter, then
	// for each portion of the context record controlled by a flag
	// whose value is set, it is assumed that that portion of the
	// context record contains valid context. If the context record
	// is being used to modify a threads context, then only that
	// portion of the threads context will be modified.
	//
	// If the context record is used as an IN OUT parameter to capture
	// the context of a thread, then only those portions of the thread's
	// context corresponding to set flags will be returned.
	//
	// The context record is never used as an OUT only parameter.
	//

	DWORD ContextFlags;

	//
	// This section is specified/returned if CONTEXT_DEBUG_REGISTERS is
	// set in ContextFlags.  Note that CONTEXT_DEBUG_REGISTERS is NOT
	// included in CONTEXT_FULL.
	//

	DWORD   Dr0;
	DWORD   Dr1;
	DWORD   Dr2;
	DWORD   Dr3;
	DWORD   Dr6;
	DWORD   Dr7;

	//
	// This section is specified/returned if the
	// ContextFlags word contians the flag CONTEXT_FLOATING_POINT.
	//

	FLOATING_SAVE_AREA FloatSave;

	//
	// This section is specified/returned if the
	// ContextFlags word contians the flag CONTEXT_SEGMENTS.
	//

	DWORD   SegGs;
	DWORD   SegFs;
	DWORD   SegEs;
	DWORD   SegDs;

	//
	// This section is specified/returned if the
	// ContextFlags word contians the flag CONTEXT_INTEGER.
	//

	DWORD   Edi;
	DWORD   Esi;
	DWORD   Ebx;
	DWORD   Edx;
	DWORD   Ecx;
	DWORD   Eax;

	//
	// This section is specified/returned if the
	// ContextFlags word contians the flag CONTEXT_CONTROL.
	//

	DWORD   Ebp;
	DWORD   Eip;
	DWORD   SegCs;              // MUST BE SANITIZED
	DWORD   EFlags;             // MUST BE SANITIZED
	DWORD   Esp;
	DWORD   SegSs;

	//
	// This section is specified/returned if the ContextFlags word
	// contains the flag CONTEXT_EXTENDED_REGISTERS.
	// The format and contexts are processor specific
	//

	BYTE    ExtendedRegisters[MAXIMUM_SUPPORTED_EXTENSION];

} CONTEXT;



typedef CONTEXT *PCONTEXT;

// begin_ntminiport

#endif //_M_IX86

#endif


#ifndef _LDT_ENTRY_DEFINED
#define _LDT_ENTRY_DEFINED

typedef struct _LDT_ENTRY {
	WORD    LimitLow;
	WORD    BaseLow;
	union {
		struct {
			BYTE    BaseMid;
			BYTE    Flags1;     // Declare as bytes to avoid alignment
			BYTE    Flags2;     // Problems.
			BYTE    BaseHi;
		} Bytes;
		struct {
			DWORD   BaseMid : 8;
			DWORD   Type : 5;
			DWORD   Dpl : 2;
			DWORD   Pres : 1;
			DWORD   LimitHi : 4;
			DWORD   Sys : 1;
			DWORD   Reserved_0 : 1;
			DWORD   Default_Big : 1;
			DWORD   Granularity : 1;
			DWORD   BaseHi : 8;
		} Bits;
	} HighWord;
} LDT_ENTRY, *PLDT_ENTRY;

#endif


#ifndef _NTTYPES_NO_WINNT
#define EXCEPTION_NONCONTINUABLE 0x1    // Noncontinuable exception
#define EXCEPTION_MAXIMUM_PARAMETERS 15 // maximum number of exception parameters

//
// Exception record definition.
//

typedef struct _EXCEPTION_RECORD {
	DWORD ExceptionCode;
	DWORD ExceptionFlags;
	struct _EXCEPTION_RECORD *ExceptionRecord;
	PVOID ExceptionAddress;
	DWORD NumberParameters;
	ULONG_PTR ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS];
} EXCEPTION_RECORD;

typedef EXCEPTION_RECORD *PEXCEPTION_RECORD;

typedef struct _EXCEPTION_RECORD32 {
	DWORD ExceptionCode;
	DWORD ExceptionFlags;
	DWORD ExceptionRecord;
	DWORD ExceptionAddress;
	DWORD NumberParameters;
	DWORD ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS];
} EXCEPTION_RECORD32, *PEXCEPTION_RECORD32;

typedef struct _EXCEPTION_RECORD64 {
	DWORD ExceptionCode;
	DWORD ExceptionFlags;
	DWORD64 ExceptionRecord;
	DWORD64 ExceptionAddress;
	DWORD NumberParameters;
	DWORD __unusedAlignment;
	DWORD64 ExceptionInformation[EXCEPTION_MAXIMUM_PARAMETERS];
} EXCEPTION_RECORD64, *PEXCEPTION_RECORD64;

#endif







#ifndef _NTTYPES_NO_DBGKD

//
// BEGIN KERNEL DEBUGGER INTERFACE
//

//
// CONSTANTS
//

#ifdef _X86_

#define DBGKD_MAXSTREAM						16
#define REPORT_INCLUDES_SEGS				0x0001

#endif

#ifdef _MIPS_

#define DBGKD_MAXSTREAM						16

#endif

#ifdef _ALPHA_

#define DBGKD_MAXSTREAM						16

#endif

#ifdef _PPC_

#define DBGKD_MAXSTREAM						16

#endif


#define BREAKPOINT_TABLE_SIZE				32

#define DBGKD_INTERNAL_BP_FLAG_COUNTONLY	0x00000001	// instructions aren't counted
#define DBGKD_INTERNAL_BP_FLAG_INVALID		0x00000002	// breakpoint is disabled
#define DBGKD_INTERNAL_BP_FLAG_SUSPENDED	0x00000004	// breakpoint is suspended (temporarily)
#define DBGKD_INTERNAL_BP_FLAG_DYING		0x00000008	// breakpoint killed on exit

#define DBGKD_VERS_FLAG_MP					0x0001		// multiprocessor kernel
#define DBGKD_VERS_FLAG_DATA				0x0002		// DebuggerDataList is initialized
#define DBGKD_VERS_FLAG_PTR64				0x0004      // 64-bit pointers
#define DBGKD_VERS_FLAG_NOMM				0x0008      // no PTEs
#define DBGKD_VERS_FLAG_HSS					0x0010      // hardware stepping support

#define DBGKD_SIMULATION_NONE				0x00000000
#define DBGKD_SIMULATION_EXDI				0x00000001

//
// KD API NUMBERS
//

//
// PACKET_TYPE_KD_STATE_CHANGE
//

#define DbgKdExceptionStateChange			0x00003030L
#define DbgKdLoadSymbolsStateChange			0x00003031L

//
// PACKET_TYPE_KD_STATE_MANIPULATE
//

#define DbgKdReadVirtualMemoryApi			0x00003130L
#define DbgKdWriteVirtualMemoryApi			0x00003131L
#define DbgKdGetContextApi					0x00003132L
#define DbgKdSetContextApi					0x00003133L
#define DbgKdWriteBreakPointApi				0x00003134L
#define DbgKdRestoreBreakPointApi			0x00003135L
#define DbgKdContinueApi					0x00003136L
#define DbgKdReadControlSpaceApi			0x00003137L
#define DbgKdWriteControlSpaceApi			0x00003138L
#define DbgKdReadIoSpaceApi					0x00003139L
#define DbgKdWriteIoSpaceApi				0x0000313AL
#define DbgKdRebootApi						0x0000313BL
#define DbgKdContinueApi2					0x0000313CL
#define DbgKdReadPhysicalMemoryApi			0x0000313DL
#define DbgKdWritePhysicalMemoryApi			0x0000313EL
#define DbgKdQuerySpecialCallsApi			0x0000313FL
#define DbgKdSetSpecialCallApi				0x00003140L
#define DbgKdClearSpecialCallsApi			0x00003141L
#define DbgKdSetInternalBreakPointApi		0x00003142L
#define DbgKdGetInternalBreakPointApi		0x00003143L
#define DbgKdReadIoSpaceExtendedApi			0x00003144L
#define DbgKdWriteIoSpaceExtendedApi		0x00003145L
#define DbgKdGetVersionApi					0x00003146L
#define DbgKdWriteBreakPointExApi			0x00003147L
#define DbgKdRestoreBreakPointExApi			0x00003148L
#define DbgKdCauseBugCheckApi				0x00003149L
#define DbgKdSwitchProcessor				0x00003150L
#define DbgKdPageInApi						0x00003151L
#define DbgKdReadMachineSpecificRegister	0x00003152L
#define DbgKdWriteMachineSpecificRegister	0x00003153L
#define DbgKdReadVirtualMemory64Api			0x00003154L
#define DbgKdWriteVirtualMemory64Api		0x00003155L

//
// PACKET_TYPE_KD_DEBUG_IO
//

#define DbgKdPrintStringApi					0x00003230L
#define DbgKdGetStringApi					0x00003231L




//
// KD PROTOCOL CONSTANTS
//

#define PACKET_MAX_SIZE						4000
#define INITIAL_PACKET_ID					0x80800000
#define SYNC_PACKET_ID						0x00000800 // or INITIAL_PACKET_ID

//
// BREAKIN
//

#define BREAKIN_PACKET						0x62626262
#define BREAKIN_PACKET_BYTE					0x62

//
// LEADER
//

#define PACKET_LEADER						0x30303030
#define PACKET_LEADER_BYTE					0x30

#define CONTROL_PACKET_LEADER				0x69696969
#define CONTROL_PACKET_LEADER_BYTE			0x69

//
// TRAILING BYTE
//

#define PACKET_TRAILING_BYTE				0xAA

//
// PACKET TYPES
//

#define PACKET_TYPE_UNUSED					0
#define PACKET_TYPE_KD_STATE_CHANGE			1
#define PACKET_TYPE_KD_STATE_MANIPULATE		2
#define PACKET_TYPE_KD_DEBUG_IO				3
#define PACKET_TYPE_KD_ACKNOWLEDGE			4	// Control packet
#define PACKET_TYPE_KD_RESEND				5	// Control packet
#define PACKET_TYPE_KD_RESET				6	// Control packet
#define PACKET_TYPE_KD_STATE_CHANGE64		7
#define PACKET_TYPE_MAX						8

//
// KERNEL DEBUGGER SUPPORT POOL TAG
//

#define KDBG_TAG							'GBDK'

//
// TRACE DATA
//

#define TRACE_DATA_INSTRUCTIONS_BIG			0xffff

#define TRACE_DATA_BUFFER_MAX_SIZE			40


//
// SPECIAL CALLS
//

#define DBGKD_MAX_SPECIAL_CALLS				10

//
// INTERNAL BREAKPOINTS
//

#define DBGKD_MAX_INTERNAL_BREAKPOINTS		20


//
// TYPES
//

#ifdef _X86_

typedef struct _DBGKD_CONTROL_REPORT {
	DWORD Dr6;
	DWORD Dr7;
	WORD InstructionCount;
	WORD ReportFlags;
	BYTE InstructionStream[DBGKD_MAXSTREAM];
	WORD SegCs;
	WORD SegDs;
	WORD SegEs;
	WORD SegFs;
	DWORD EFlags;
} DBGKD_CONTROL_REPORT, *PDBGKD_CONTROL_REPORT;

typedef struct _DBGKD_CONTROL_SET {
	DWORD TraceFlag;
	DWORD Dr7;
	DWORD CurrentSymbolStart;
	DWORD CurrentSymbolEnd;
} DBGKD_CONTROL_SET, *PDBGKD_CONTROL_SET;

typedef struct _DESCRIPTOR {
	WORD Pad;
	WORD Limit;
	DWORD Base;
} KDESCRIPTOR, *PKDESCRIPTOR;

typedef struct _KSPECIAL_REGISTERS {
	DWORD Cr0;
	DWORD Cr2;
	DWORD Cr3;
	DWORD Cr4;
	DWORD KernelDr0;
	DWORD KernelDr1;
	DWORD KernelDr2;
	DWORD KernelDr3;
	DWORD KernelDr6;
	DWORD KernelDr7;
	KDESCRIPTOR Gdtr;
	KDESCRIPTOR Idtr;
	WORD Tr;
	WORD Ldtr;
	DWORD Reserved[6];
} KSPECIAL_REGISTERS, *PKSPECIAL_REGISTERS;

typedef struct _KPROCESSOR_STATE {
	struct _CONTEXT ContextFrame;
	struct _KSPECIAL_REGISTERS SpecialRegisters;
} KPROCESSOR_STATE, *PKPROCESSOR_STATE;

typedef struct _DESCRIPTOR_TABLE_ENTRY {
	DWORD Selector;
	LDT_ENTRY Descriptor;
} DESCRIPTOR_TABLE_ENTRY, *PDESCRIPTOR_TABLE_ENTRY;

#endif

#ifdef _MIPS_

typedef struct _DBGKD_CONTROL_REPORT {
	DWORD InstructionCount;
	BYTE InstructionStream[DBGKD_MAXSTREAM];
} DBGKD_CONTROL_REPORT, *PDBGKD_CONTROL_REPORT;

typedef DWORD DBGKD_CONTROL_SET, *PDBGKD_CONTROL_SET;

#endif

#ifdef _ALPHA_

typedef struct _DBGKD_CONTROL_REPORT {
	DWORD InstructionCount;
	BYTE InstructionStream[DBGKD_MAXSTREAM];
} DBGKD_CONTROL_REPORT, *PDBGKD_CONTROL_REPORT;

typedef DWORD DBGKD_CONTROL_SET, *PDBGKD_CONTROL_SET;

#endif


#ifdef _PPC_

typedef struct _DBGKD_CONTROL_REPORT {
	DWORD InstructionCount;
	BYTE InstructionStream[DBGKD_MAXSTREAM];
} DBGKD_CONTROL_REPORT, *PDBGKD_CONTROL_REPORT;

typedef DWORD DBGKD_CONTROL_SET, *PDBGKD_CONTROL_SET;

typedef struct _KSPECIAL_REGISTERS {
	DWORD KernelDr0;
	DWORD KernelDr1;
	DWORD KernelDr2;
	DWORD KernelDr3;
	DWORD KernelDr4;
	DWORD KernelDr5;
	DWORD KernelDr6;
	DWORD KernelDr7;
	DWORD Sprg0;
	DWORD Sprg1;
	DWORD Sr0;
	DWORD Sr1;
	DWORD Sr2;
	DWORD Sr3;
	DWORD Sr4;
	DWORD Sr5;
	DWORD Sr6;
	DWORD Sr7;
	DWORD Sr8;
	DWORD Sr9;
	DWORD Sr10;
	DWORD Sr11;
	DWORD Sr12;
	DWORD Sr13;
	DWORD Sr14;
	DWORD Sr15;
	DWORD DBAT0L;
	DWORD DBAT0U;
	DWORD DBAT1L;
	DWORD DBAT1U;
	DWORD DBAT2L;
	DWORD DBAT2U;
	DWORD DBAT3L;
	DWORD DBAT3U;
	DWORD IBAT0L;
	DWORD IBAT0U;
	DWORD IBAT1L;
	DWORD IBAT1U;
	DWORD IBAT2L;
	DWORD IBAT2U;
	DWORD IBAT3L;
	DWORD IBAT3U;
	DWORD Sdr1;
	DWORD Reserved[9];
} KSPECIAL_REGISTERS, *PKSPECIAL_REGISTERS;

typedef struct _KPROCESSOR_STATE {
	struct _CONTEXT ContextFrame;
	struct _KSPECIAL_REGISTERS SpecialRegisters;
} KPROCESSOR_STATE, *PKPROCESSOR_STATE;

#endif


#if defined _M_AMD64

//
// Note - these are dummy structures!
//

#define _MAKE_DUMMY_STRUCT(s) \
	typedef struct _##s { \
	} s, * P##s;

_MAKE_DUMMY_STRUCT(DBGKD_CONTROL_SET);
_MAKE_DUMMY_STRUCT(DBGKD_CONTROL_REPORT);

#undef _MAKE_DUMMY_STRUCT

#endif

typedef struct _DBGKD_READ_MEMORY {
	PVOID TargetBaseAddress;
	DWORD TransferCount;
	DWORD ActualBytesRead;
} DBGKD_READ_MEMORY, *PDBGKD_READ_MEMORY;

#include "pshpack4.h"
typedef struct _DBGKD_READ_MEMORY64 {
	DWORDLONG TargetBaseAddress;
	DWORD TransferCount;
	DWORD ActualBytesRead;
} DBGKD_READ_MEMORY64, *PDBGKD_READ_MEMORY64;
#include "poppack.h"

typedef struct _DBGKD_WRITE_MEMORY {
	PVOID TargetBaseAddress;
	DWORD TransferCount;
	DWORD ActualBytesWritten;
	// UCHAR Data[];
} DBGKD_WRITE_MEMORY, *PDBGKD_WRITE_MEMORY;

#include "pshpack4.h"
typedef struct _DBGKD_WRITE_MEMORY64 {
	DWORDLONG TargetBaseAddress;
	DWORD TransferCount;
	DWORD ActualBytesWritten;
	// UCHAR Data[];
} DBGKD_WRITE_MEMORY64, *PDBGKD_WRITE_MEMORY64;
#include "poppack.h"

typedef struct _DBGKD_GET_CONTEXT {
	DWORD ContextFlags;
} DBGKD_GET_CONTEXT, *PDBGKD_GET_CONTEXT;

typedef struct _DBGKD_SET_CONTEXT {
	DWORD ContextFlags;
	// CONTEXT Context;
} DBGKD_SET_CONTEXT, *PDBGKD_SET_CONTEXT;

typedef struct _DBGKD_WRITE_BREAKPOINT {
	PVOID BreakPointAddress;
	DWORD BreakPointHandle;
} DBGKD_WRITE_BREAKPOINT, *PDBGKD_WRITE_BREAKPOINT;

typedef struct _DBGKD_RESTORE_BREAKPOINT {
	DWORD BreakPointHandle;
} DBGKD_RESTORE_BREAKPOINT, *PDBGKD_RESTORE_BREAKPOINT;

typedef struct _DBGKD_BREAKPOINTEX {
	DWORD BreakPointCount;
	DWORD ContinueStatus;
} DBGKD_BREAKPOINTEX, *PDBGKD_BREAKPOINTEX;

typedef struct _DBGKD_CONTINUE {
	DWORD ContinueStatus;
} DBGKD_CONTINUE, *PDBGKD_CONTINUE;

typedef struct _DBGKD_CONTINUE2 {
	DWORD ContinueStatus;
	DBGKD_CONTROL_SET ControlSet;
} DBGKD_CONTINUE2, *PDBGKD_CONTINUE2;

typedef struct _DBGKD_READ_WRITE_IO {
	DWORD DataSize;
	PVOID IoAddress;
	DWORD DataValue;
} DBGKD_READ_WRITE_IO, *PDBGKD_READ_WRITE_IO;

typedef struct _DBGKD_READ_WRITE_IO_EXTENDED {
	DWORD DataSize;
	DWORD InterfaceType;
	DWORD BusNumber;
	DWORD AddressSpace;
	PVOID IoAddress;
	DWORD DataValue;
} DBGKD_READ_WRITE_IO_EXTENDED, *PDBGKD_READ_WRITE_IO_EXTENDED;

typedef struct _DBGKD_READ_WRITE_MSR {
	DWORD Msr;
	DWORD DataValueLow;
	DWORD DataValueHigh;
} DBGKD_READ_WRITE_MSR, *PDBGKD_READ_WRITE_MSR;

typedef struct _DBGKD_QUERY_SPECIAL_CALLS {
	DWORD NumberOfSpecialCalls;
	// DWORD_PTR SpecialCalls[];
} DBGKD_QUERY_SPECIAL_CALLS, *PDBGKD_QUERY_SPECIAL_CALLS;

typedef struct _DBGKD_SET_SPECIAL_CALL {
	DWORD_PTR SpecialCall;
} DBGKD_SET_SPECIAL_CALL, *PDBGKD_SET_SPECIAL_CALL;

typedef struct _DBGKD_SET_INTERNAL_BREAKPOINT {
	DWORD_PTR BreakpointAddress;
	DWORD Flags;
} DBGKD_SET_INTERNAL_BREAKPOINT, *PDBGKD_SET_INTERNAL_BREAKPOINT;

typedef struct _DBGKD_GET_INTERNAL_BREAKPOINT {
	DWORD_PTR BreakpointAddress;
	DWORD Flags;
	DWORD Calls;
	DWORD MaxCallsPerPeriod;
	DWORD MinInstructions;
	DWORD MaxInstructions;
	DWORD TotalInstructions;
} DBGKD_GET_INTERNAL_BREAKPOINT, *PDBGKD_GET_INTERNAL_BREAKPOINT;

typedef struct _DBGKD_GET_VERSION {
	WORD MajorVersion;
	WORD MinorVersion;
	WORD ProtocolVersion;
	WORD Flags;
	DWORD_PTR KernBase;
	DWORD_PTR PsLoadedModuleList;
	WORD MachineType;
	WORD ThCallbackStack; // offset from kernel stack
	WORD NextCallback; //
	WORD FramePointer; //
	DWORD_PTR KiCallUserMode; // ntoskrnl
	DWORD_PTR KeUserCallbackDispatcher; // ntdll
	DWORD_PTR BreakpointWithStatus; // address of breakpoint in DbgBreakPointWithStatus, look in eax/first arg register for status
	union {
		DWORD_PTR Reserved4;
		DWORD_PTR DebuggerDataList;
	};
} DBGKD_GET_VERSION, *PDBGKD_GET_VERSION;

typedef struct _DBGKD_PAGEIN {
	DWORD_PTR Address;
	DWORD ContinueStatus;
} DBGKD_PAGEIN, *PDBGKD_PAGEIN;

typedef struct _DBGKD_MANIPULATE_STATE {
	ULONG ApiNumber;
	USHORT ProcessorLevel;
	USHORT Processor;
	ULONG ReturnStatus;
	union {
		DBGKD_READ_MEMORY ReadMemory;
		DBGKD_WRITE_MEMORY WriteMemory;
		DBGKD_READ_MEMORY64 ReadMemory64;
		DBGKD_WRITE_MEMORY64 WriteMemory64;
		DBGKD_GET_CONTEXT GetContext;
		DBGKD_SET_CONTEXT SetContext;
		DBGKD_WRITE_BREAKPOINT WriteBreakPoint;
		DBGKD_RESTORE_BREAKPOINT RestoreBreakPoint;
		DBGKD_CONTINUE Continue;
		DBGKD_CONTINUE2 Continue2;
		DBGKD_READ_WRITE_IO ReadWriteIo;
		DBGKD_READ_WRITE_IO_EXTENDED ReadWriteIoExtended;
		DBGKD_QUERY_SPECIAL_CALLS QuerySpecialCalls;
		DBGKD_SET_SPECIAL_CALL SetSpecialCall;
		DBGKD_SET_INTERNAL_BREAKPOINT SetInternalBreakpoint;
		DBGKD_GET_INTERNAL_BREAKPOINT GetInternalBreakpoint;
		DBGKD_GET_VERSION GetVersion;
		DBGKD_BREAKPOINTEX BreakPointEx;
		DBGKD_PAGEIN PageIn;
		DBGKD_READ_WRITE_MSR ReadWriteMsr;
	} u;
} DBGKD_MANIPULATE_STATE, *PDBGKD_MANIPULATE_STATE;

#ifndef DBGKM_EXCEPTION_DEFINED

#define DBGKM_EXCEPTION_DEFINED

typedef struct _DBGKM_EXCEPTION {
	EXCEPTION_RECORD ExceptionRecord;
	ULONG FirstChance;
} DBGKM_EXCEPTION, *PDBGKM_EXCEPTION;

#endif

typedef struct _KD_PACKET {
	DWORD PacketLeader;
	WORD PacketType;
	WORD ByteCount;
	DWORD PacketId;
	DWORD Checksum;
} KD_PACKET, *PKD_PACKET;

typedef struct _DBGKD_LOAD_SYMBOLS {
	DWORD PathNameLength;
	PVOID BaseOfDll;
	DWORD ProcessId;
	DWORD CheckSum;
	DWORD SizeOfImage;
	BOOLEAN UnloadSymbols;
} DBGKD_LOAD_SYMBOLS, *PDBGKD_LOAD_SYMBOLS;

#ifdef _IA64_
#include <pshpck16.h>
#endif

typedef struct _DBGKD_WAIT_STATE_CHANGE {
	DWORD NewState;
	WORD ProcessorLevel;
	WORD Processor;
	DWORD NumberProcessors;
	PVOID Thread;
	PVOID ProgramCounter;
	union {
		DBGKM_EXCEPTION Exception;
		DBGKD_LOAD_SYMBOLS LoadSymbols;
	} u;
	DBGKD_CONTROL_REPORT ControlReport;
	CONTEXT Context;
} DBGKD_WAIT_STATE_CHANGE, *PDBGKD_WAIT_STATE_CHANGE;

typedef struct _DBGKM_EXCEPTION64 {
	EXCEPTION_RECORD64 ExceptionRecord;
	ULONG FirstChance;
} DBGKM_EXCEPTION64, *PDBGKM_EXCEPTION64;

typedef struct _DBGKD_LOAD_SYMBOLS64 {
	ULONG PathNameLength;
	ULONG64 BaseOfDll;
	ULONG64 ProcessId;
	ULONG CheckSum;
	ULONG SizeOfImage;
	BOOLEAN UnloadSymbols;
} DBGKD_LOAD_SYMBOLS64, *PDBGKD_LOAD_SYMBOLS64;

typedef struct _DBGKD_WAIT_STATE_CHANGE64 {
	ULONG NewState;
	USHORT ProcessorLevel;
	USHORT Processor;
	ULONG NumberProcessors;
	ULONG64 Thread;
	ULONG64 ProgramCounter;
	union {
		DBGKM_EXCEPTION64 Exception;
		DBGKD_LOAD_SYMBOLS64 LoadSymbols;
	} u;
	DBGKD_CONTROL_REPORT ControlReport;
	CONTEXT Context;
} DBGKD_WAIT_STATE_CHANGE64, *PDBGKD_WAIT_STATE_CHANGE64;

#ifdef _IA64_
#include <poppack.h>
#endif

typedef struct _DBGKD_DEBUG_DATA_HEADER {
	LIST_ENTRY List;
	DWORD OwnerTag; // Pool Tag
	DWORD Size;
} DBGKD_DEBUG_DATA_HEADER, *PDBGKD_DEBUG_DATA_HEADER;

typedef struct _KDDEBUGGER_DATA {
	DBGKD_DEBUG_DATA_HEADER Header;

	DWORD_PTR KernBase;

	DWORD_PTR BreakpointWithStatus; // Breakpoint instruction in DbgBreakPointWithStatus, EAX/Param Reg 1 is status

	DWORD_PTR SavedContext; // Only valid after KeBugCheckEx

	WORD ThCallbackStack; // displacement from kernel stack
	WORD NextCallback; //
	WORD FramePointer; //
	WORD Unused1;
	DWORD_PTR KiCallUserMode; // ntoskrnl
	DWORD_PTR KeUserCallbackDispatcher; // ntdll

	//
	// The following are ntoskrnl global data structure addresses.
	//

	DWORD_PTR PsLoadedModuleList;
	DWORD_PTR PsActiveProcessHead;
	DWORD_PTR PspCidTable;

	DWORD_PTR ExpSystemResourcesList;
	DWORD_PTR ExpPagedPoolDescriptor;
	DWORD_PTR ExpNumberOfPagedPools;

	DWORD_PTR KeTimeIncrement;
	DWORD_PTR KeBugCheckCallbackListHead;
	DWORD_PTR KiBugcheckData;

	DWORD_PTR IopErrorLogListHead;

	DWORD_PTR ObpRootDirectoryObject;
	DWORD_PTR ObpTypeObjectType;

	DWORD_PTR MmSystemCacheStart;
	DWORD_PTR MmSystemCacheEnd;
	DWORD_PTR MmSystemCacheWs;

	DWORD_PTR MmPfnDatabase;
	DWORD_PTR MmSystemPtesStart;
	DWORD_PTR MmSystemPtesEnd;
	DWORD_PTR MmSubsectionBase;
	DWORD_PTR MmNumberOfPagingFiles;

	DWORD_PTR MmLowestPhysicalPage;
	DWORD_PTR MmHighestPhysicalPage;
	DWORD_PTR MmNumberOfPhysicalPages;

	DWORD_PTR MmMaximumNonPagedPoolInBytes;
	DWORD_PTR MmNonPagedSystemStart;
	DWORD_PTR MmNonPagedPoolStart;
	DWORD_PTR MmNonPagedPoolEnd;

	DWORD_PTR MmPagedPoolStart;
	DWORD_PTR MmPagedPoolEnd;
	DWORD_PTR MmPagedPoolInformation;
	DWORD_PTR MmPageSize;

	DWORD_PTR MmSizeOfPagedPoolInBytes;

	DWORD_PTR MmTotalCommitLimit;
	DWORD_PTR MmTotalCommittedPages;
	DWORD_PTR MmSharedCommit;
	DWORD_PTR MmDriverCommit;
	DWORD_PTR MmProcessCommit;
	DWORD_PTR MmPagedPoolCommit;
	DWORD_PTR MmExtendedCommit;

	DWORD_PTR MmZeroedPageListHead;
	DWORD_PTR MmFreePageListHead;
	DWORD_PTR MmStandbyPageListHead;
	DWORD_PTR MmModifiedPageListHead;
	DWORD_PTR MmModifiedNoWritePageListHead;
	DWORD_PTR MmAvailablePages;
	DWORD_PTR MmResidentAvailablePages;

	DWORD_PTR PoolTrackTable;
	DWORD_PTR NonPagedPoolDescriptor;

	DWORD_PTR MmHighestUserAddress;
	DWORD_PTR MmSystemRangeStart;
	DWORD_PTR MmUserProbeAddress;

	DWORD_PTR KdPrintCircularBuffer;
	DWORD_PTR KdPrintCircularBufferEnd;
	DWORD_PTR KdPrintWritePointer;
	DWORD_PTR KdPrintRolloverCount;

	DWORD_PTR MmLoadedUserImageList;

	DWORD_PTR NtBuildLab;
	DWORD_PTR KiNormalSystemCall;

	DWORD_PTR KiProcessorBlock;
	DWORD_PTR MmUnloadedDrivers;
	DWORD_PTR MmLastUnloadedDriver;
	DWORD_PTR MmTriageActionTaken;
	DWORD_PTR MmSpecialPoolTag;
	DWORD_PTR KernelVerifier;
	DWORD_PTR MmVerifierData;
	DWORD_PTR MmAllocatedNonPagedPool;
	DWORD_PTR MmPeakCommitment;
	DWORD_PTR MmTotalCommitLimitMaximum;
	DWORD_PTR CmNtCSDVersion;

	DWORD_PTR MmPhysicalMemoryBlock;
	DWORD_PTR MmSessionBase;
	DWORD_PTR MmSessionSize;
	DWORD_PTR MmSystemParentTablePage;
} KDDEBUGGER_DATA, *PKDDEBUGGER_DATA;

typedef union _DBGKD_TRACE_DATA {
	struct {
		BYTE SymbolNumber;
		CHAR LevelChange;
		WORD Instructions;
	} s;
	DWORD LongNumber;
} DBGKD_TRACE_DATA, *PDBGKD_TRACE_DATA;

typedef struct _DBGKD_PRINT_STRING {
	DWORD LengthOfString;
	// CHAR String[]; // Also null terminated
} DBGKD_PRINT_STRING, *PDBGKD_PRINT_STRING;

typedef struct _DBGKD_GET_STRING {
	DWORD LengthOfPromptString;
	DWORD LengthOfStringRead;
	// CHAR PromptString[]; // Also null terminated
} DBGKD_GET_STRING, *PDBGKD_GET_STRING;

typedef struct _DBGKD_DEBUG_IO {
	DWORD ApiNumber;
	WORD ProcessorLevel;
	WORD Processor;
	union {
		DBGKD_PRINT_STRING PrintString;
		DBGKD_GET_STRING GetString;
	} u;
} DBGKD_DEBUG_IO, *PDBGKD_DEBUG_IO;

//
// END KERNEL DEBUGGER INTERFACE
//

#endif

//
// Obsolete definition.  Use DBGUI_WAIT_STATE_CHANGE instead for new applications.
//

typedef struct _DEBUG_MESSAGE {
	PORT_MESSAGE PortMessage;
	ULONG EventCode;
	ULONG Status;
	union {
		struct {
			EXCEPTION_RECORD ExceptionRecord;
			ULONG FirstChance;
		} Exception;
		struct {
			ULONG Reserved;
			PVOID StartAddress;
		} CreateThread;
		struct {
			ULONG Reserved;
			HANDLE FileHandle;
			PVOID Base;
			ULONG PointerToSymbolTable;
			ULONG NumberOfSymbols;
			ULONG Reserved2;
			PVOID EntryPoint;
		} CreateProcess;
		struct {
			ULONG ExitCode;
		} ExitThread;
		struct {
			ULONG ExitCode;
		} ExitProcess;
		struct {
			HANDLE FileHandle;
			PVOID Base;
			ULONG PointerToSymbolTable;
			ULONG NumberOfSymbols;
		} LoadDll;
		struct {
			PVOID Base;
		} UnloadDll;
	} u;
} DEBUG_MESSAGE,*PDEBUG_MESSAGE;

#ifdef _NTNATIVE_USE_DR_BITFIELDS

typedef struct _DEBUG_STATUS {
	ULONG B0 :1;
	ULONG B1 :1;
	ULONG B2 :1;
	ULONG B3 :1;
	ULONG :9;
	ULONG BD :1;
	ULONG BS :1;
	ULONG BT :1;
	ULONG :16;
} DEBUG_STATUS,*PDEBUG_STATUS;

typedef struct _DEBUG_CONTROL {
	ULONG L0 :1;
	ULONG G0 :1;
	ULONG L1 :1;
	ULONG G1 :1;
	ULONG L2 :1;
	ULONG G2 :1;
	ULONG L3 :1;
	ULONG G3 :1;
	ULONG LE :1;
	ULONG GE :1;
	ULONG :3;
	ULONG GD :1;
	ULONG :2;
	ULONG RWE0 :2;
	ULONG LEN0 :2;
	ULONG RWE1 :2;
	ULONG LEN1 :2;
	ULONG RWE2 :2;
	ULONG LEN2 :2;
	ULONG RWE3 :2;
	ULONG LEN3 :2;
} DEBUG_CONTROL,*PDEBUG_CONTROL;

#endif

typedef DWORD EXECUTION_STATE;
typedef EXECUTION_STATE *PEXECUTION_STATE;

#ifndef _NTTYPES_NO_WINNT

typedef enum {
	LT_DONT_CARE,
	LT_LOWEST_LATENCY
} LATENCY_TIME;

#endif

typedef LANGID *PLANGID;

typedef struct _RTL_BITMAP {
    ULONG SizeOfBitMap;                     // Number of bits in bit map
    PULONG Buffer;                          // Pointer to the bit map itself
} RTL_BITMAP;
typedef RTL_BITMAP *PRTL_BITMAP;

typedef struct _PEB_LDR_DATA {
	ULONG Length;
	BOOLEAN Initialized;
	PVOID SsHandle;
	LIST_ENTRY InLoadOrderModuleList;
	LIST_ENTRY InMemoryOrderModuleList;
	LIST_ENTRY InInitializationOrderModuleList;
	PVOID EntryInProgress;
} PEB_LDR_DATA, *PPEB_LDR_DATA;

typedef struct {			// +0x44
	UCHAR Info[0x48];		// [0x44, 0x8C)
	UCHAR SpareStack[0x20];	// [0x8C, 0xAC)
	UCHAR Info2[0x14];		// [0xAC, 0xC0)
	//UCHAR Info[0x7C];
} TEB_WIN32_CLIENT_INFO;

typedef struct _GDI_TEB_BATCH
{
	ULONG     Offset;
	ULONG_PTR DC;
	ULONG     Buffer[0x136];
} GDI_TEB_BATCH, *PGDI_TEB_BATCH;

typedef struct _Wx86ThreadState {
	PVOID CallBx86Eip;
	PVOID DeallocationCpu;
	BOOLEAN UseKnownWx86Dll;
	CCHAR OleStubInvoked;

	UCHAR _Pad[2];
} Wx86ThreadState;

#if 0
typedef struct _TEB
{
/*000*/	NT_TIB		NtTib;
/*01C*/	PVOID		EnvironmentPointer;
/*020*/	CLIENT_ID	ClientId;
/*028*/	HANDLE		ActiveRpcHandle;
/*02C*/	PVOID*		ThreadLocalStoragePointer;
/*030*/	PPEB		ProcessEnvironmentBlock;
/*034*/	ULONG		LastErrorValue;
/*038*/	ULONG		CountOfOwnedCriticalSections;
/*03C*/	ULONG		CsrClientThread;
/*040*/	PVOID		Win32ThreadInfo;
/*044*/	TEB_WIN32_CLIENT_INFO ClientInfo;
/*0C0*/	ULONG		WOW32Reserved;
/*0C4*/	ULONG		CurrentLocale;
/*0C8*/	ULONG		FpSoftwareStatusRegister;
/*0CC*/	UCHAR		SystemReserved1[0xD8];
/*1A4*/	ULONG		Spare1;
/*1A8*/	ULONG		ExceptionCode;
/*1AC*/	UCHAR		SpareBytes1[0x28];
/*1D4*/	ULONG		TermServiceSession;
/*1D8*/	UCHAR		SystemReserved2[0x24];
/*1FC*/	GDI_TEB_BATCH	GdiTebBatch;
/*6DC*/	ULONG		gdiRgn;
/*6E0*/	ULONG		gdiPen;
/*6E4*/	ULONG		gdiBrush;
/*6E8*/	CLIENT_ID	RealClientId;
/*6F0*/	ULONG		GdiCachedProcessHandle;
/*6F4*/	ULONG		GdiClientPID;
/*6F8*/	ULONG		GdiClientTID;
/*6FC*/	ULONG		GdiThreadLocalInfo;
/*700*/	UCHAR		UserReserved[0x14];
/*714*/	UCHAR		glDispatchTable[0x460];
/*B74*/	UCHAR		glReserved1[0x68];
/*BDC*/	ULONG		glReserved2;
/*BE0*/	ULONG		glSectionInfo;
/*BE4*/	ULONG		glSection;
/*BE8*/	ULONG		glTable;
/*BEC*/	ULONG		glCurrentRC;
/*BF0*/	ULONG		glContext;
/*BF4*/	ULONG		LastStatusValue;
/*BF8*/	UNICODE_STRING	StaticUnicodeString;
/*C00*/	WCHAR		StaticUnicodeBuffer[0x105];
/*E0C*/	PVOID		DeallocationStack;
/*E10*/	PVOID		TlsSlots[0x40];
/*F10*/	LIST_ENTRY	TlsLinks;
/*F18*/	PVOID		Vdm;
/*F1C*/	ULONG		ReservedForNtRpc;
/*F20*/	ULONG		DbgSsValue;
/*F24*/	HANDLE		DbgSsHandle;
/*F28*/	ULONG		HardErrorsAreDisabled;
/*F2C*/	PVOID		Instrumentation[0x10];
/*F6C*/	PVOID		WinSockData;
/*F70*/	ULONG		GdiBatchCount;
/*F74*/	UCHAR		InDbgPrint;
/*F75*/ UCHAR		FreeStackOnTermination;
/*F76*/ UCHAR		HasFiberData;
/*F77*/ UCHAR		IdealProcessor;
/*F78*/	ULONG		Spare3;
/*F7C*/	ULONG		ReservedForPerf;
/*F80*/	ULONG		ReservedForOle;
/*F84*/	ULONG		WaitingOnLoaderLock;
/*F88*/ Wx86ThreadState Wx86Thread;
/*F94*/ PVOID		TlsExpansionSlots;
/*F98*/ LCID		ImpersonationLocale;
/*F9C*/ ULONG		IsImpersonating;
/*FA0*/ PVOID		NlsCache;
/*FA4*/ PVOID		pShimData;
/*FA8*/ ULONG		HeapVirtualAffinity;
/*FAC*/ HANDLE		CurrentTransactionHandle;
/*FB0*/ PVOID		ActiveFrame;
/*FB4*/	BOOLEAN		SafeThunkCall;
/*FB5*/ BOOLEAN		BooleanSpare;
#if 0
/*F88*/	PVOID		StackCommit;
/*F8C*/	PVOID		StackCommitMax;
/*F90*/	PVOID		StackReserve;
/*F94*/	PVOID		MessageQueue;
#endif
/*F98*/	} TEB, *PTEB;
#else

typedef struct _TEB_ACTIVE_FRAME_CONTEXT
{
	ULONG                        Flags;
	PCHAR                        FrameName;
} TEB_ACTIVE_FRAME_CONTEXT, * PTEB_ACTIVE_FRAME_CONTEXT;

typedef struct _TEB_ACTIVE_FRAME
{
	ULONG                        Flags;
	struct _TEB_ACTIVE_FRAME    *Previous;
	PTEB_ACTIVE_FRAME_CONTEXT    Context;
} TEB_ACTIVE_FRAME, * PTEB_ACTIVE_FRAME;
typedef struct _TEB
{
	NT_TIB                       NtTib;
	PVOID                        EnvironmentPointer;
	CLIENT_ID                    ClientId;
	PVOID                        ActiveRpcHandle;
	PVOID                        ThreadLocalStoragePointer;
	PPEB                         ProcessEnvironmentBlock;
	ULONG                        LastErrorValue;
	ULONG                        CountOfOwnedCriticalSections;
	PVOID                        CsrClientInfo;
	PVOID                        Win32ThreadInfo;
	ULONG                        User32Reserved[ 26 ];
	ULONG                        UserReserved[ 5 ];
	PVOID                        WOW32Reserved;
	ULONG                        CurrentLocale;
	ULONG                        FpSoftwareStatusRegister;
	PVOID                        SystemReserved1[ 54 ];
	LONG                         ExceptionCode;
	PVOID                        ActivationContextStack;
#ifdef _WIN64
	UCHAR                        SpareBytes1[ 24 ];
#else
	UCHAR                        SpareBytes1[ 36 ];
#endif
	ULONG                        TxFsContext;
	GDI_TEB_BATCH                GdiTebBatch;
	CLIENT_ID                    RealClientId;
	PVOID                        GdiCachedProcessHandle;
	ULONG                        GdiClientPID;
	ULONG                        GdiClientTID;
	PVOID                        GdiThreadLocalInfo;
	ULONG_PTR                    Win32ClientInfo[ 62 ];
	PVOID                        glDispatchTable[ 233 ];
	ULONG_PTR                    glReserved1[ 29 ];
	PVOID                        glReserved2;
	PVOID                        glSectionInfo;
	PVOID                        glSection;
	PVOID                        glTable;
	PVOID                        glCurrentRC;
	PVOID                        glContext;
	ULONG                        LastStatusValue;
	UNICODE_STRING               StaticUnicodeString;
	WCHAR                        StaticUnicodeBuffer[ 261 ];
	PVOID                        DeallocationStack;
	PVOID                        TlsSlots[ 64 ];
	LIST_ENTRY                   TlsLinks;
	PVOID                        Vdm;
	PVOID                        ReservedForNtRpc;
	PVOID                        DbgSsReserved[ 2 ];
	ULONG                        HardErrorMode;
#ifdef _WIN64
	PVOID                        Instrumentation[ 11 ];
#else
	PVOID                        Instrumentation[ 9 ];
#endif
	GUID                         ActivityId;
	PVOID                        SubProcessTag;
	PVOID                        EtwLocalData;
	PVOID                        EtwTraceData;
	PVOID                        WinSockData;
	ULONG                        GdiBatchCount;
	BOOLEAN                      SpareBool0;
	BOOLEAN                      SpareBool1;
	BOOLEAN                      SpareBool2;
	UCHAR                        IdealProcessor;
	ULONG                        GuaranteedStackBytes;
	PVOID                        ReservedForPerf;
	PVOID                        ReservedForOle;
	ULONG                        WaitingOnLoaderLock;
	PVOID                        SavedPriorityState;
	ULONG_PTR                    SoftPatchPtr1;
	PVOID                        ThreadPoolData;
	PVOID*                       TlsExpansionSlots;
#ifdef _WIN64
	PVOID                        DeallocationBStore;
	PVOID                        BStoreLimit;
#endif
	ULONG                        ImpersonationLocale;
	ULONG                        IsImpersonating;
	PVOID                        NlsCache;
	PVOID                        pShimData;
	ULONG                        HeapVirtualAffinity;
	PVOID                        CurrentTransactionHandle;
	PTEB_ACTIVE_FRAME            ActiveFrame;
	PVOID                        FlsData;
	PVOID                        PreferredLanguages;
	PVOID                        UserPrefLanguages;
	PVOID                        MergedPrefLanguages;
	ULONG                        MuiImpersonation;
#if 0
#include <pshpack1.h>
	struct {
	union
	{
	    USHORT                   CrossTebFlags;
	    struct
	    {
	        ULONG                SpareCrossTebBits : 16;
	    };
	};
	// this *refuses* to be 2-byte aligned - argh!
	// must fix me !!!
	union
	{
	    USHORT                   SameTebFlags;
	    struct
	    {
	        ULONG                DbgSafeThunkCall       : 1;
	        ULONG                DbgInDebugPrint        : 1;
	        ULONG                DbgHasFiberData        : 1;
	        ULONG                DbgSkipThreadAttach    : 1;
	        ULONG                DbgWerInShipAssertCode : 1;
	        ULONG                DbgRanProcessInit      : 1;
	        ULONG                DbgClonedThread        : 1;
	        ULONG                DbgSuppressDebugMsg    : 1;
	        ULONG                SpareSameTebBits       : 8;
	    };
	}; };
#include <poppack.h>
#else
	//
	// Gah.  Not getting the alignment fixed so doing this for now as we don't
	// need the above members to be addressible directly.  What an awful hack.
	//
	ULONG                        __TebFlagsFixBrokenAlignment;
#endif
	PVOID                        TxnScopeEnterCallback;
	PVOID                        TxnScopeExitCallback;
	PVOID                        TxnScopeContext;
	ULONG                        LockCount;
	ULONG                        ProcessRundown;
	ULONG64                      LastSwitchTime;
	ULONG64                      TotalSwitchOutTime;
	LARGE_INTEGER                WaitReasonBitMap;
} TEB, * PTEB;
#endif

typedef struct {
	PVOID	KernelData;
	USHORT	ProcessId;
	USHORT	Count;
	USHORT	Check;
	USHORT	SubType;
	PVOID	UserData;
} GDI_HANDLE_TABLE_ITEM, *PGDI_HANDLE_TABLE_ITEM;

#ifndef GDI_HANDLE_TABLE_LENGTH
enum {
	GDI_HANDLE_TABLE_LENGTH		=	16384
};
#endif

typedef enum _DOS_PATHNAME_TYPE {
	Path_UNCFullName=1,	// "\\x" or "\\.x"
	Path_DeviceRootDir,	// "x:\"
	Path_StreamName,	// "x:x"
	Path_RelativeDir,	// "\x"
	Path_RelativeName,	// "xx"
	Path_UNCLocalName,	// "\\.\"
	Path_UNCLocalRoot	// "\\.0"
} DOS_PATHNAME_TYPE, *PDOS_PATHNAME_TYPE;

typedef enum _ADJUST_PRIVILEGE_TYPE {
	AdjustCurrentProcess,
	AdjustCurrentThread
} ADJUST_PRIVILEGE_TYPE;

typedef struct _RELATIVE_NAME {
	UNICODE_STRING Name;
	HANDLE CurrentDir;
} RELATIVE_NAME, *PRELATIVE_NAME;

#ifndef _NTTYPES_NO_WINNT

typedef struct _MESSAGE_RESOURCE_ENTRY {
	WORD   Length;
	WORD   Flags;
	BYTE  Text[ 1 ];
} MESSAGE_RESOURCE_ENTRY, *PMESSAGE_RESOURCE_ENTRY;

#define MESSAGE_RESOURCE_UNICODE 0x0001

typedef struct _MESSAGE_RESOURCE_BLOCK {
	DWORD LowId;
	DWORD HighId;
	DWORD OffsetToEntries;
} MESSAGE_RESOURCE_BLOCK, *PMESSAGE_RESOURCE_BLOCK;

typedef struct _MESSAGE_RESOURCE_DATA {
	DWORD NumberOfBlocks;
	MESSAGE_RESOURCE_BLOCK Blocks[ 1 ];
} MESSAGE_RESOURCE_DATA, *PMESSAGE_RESOURCE_DATA;

#endif

typedef MESSAGE_RESOURCE_ENTRY RTL_MESSAGE_RESOURCE_ENTRY;
typedef RTL_MESSAGE_RESOURCE_ENTRY *PRTL_MESSAGE_RESOURCE_ENTRY;

typedef struct _RTL_USER_PROCESS_INFORMATION {
	union {

		//
		// CORRECT definition
		//

		struct {
			ULONG Length;
			HANDLE Process;
			HANDLE Thread;
			CLIENT_ID ClientId;
			SECTION_IMAGE_INFORMATION ImageInformation;
		};

		//
		// OLD definition
		//


		struct {
			ULONG Size;
			HANDLE hProcess;
			HANDLE hThread;
			CLIENT_ID ClientId_LEGACY;
			SECTION_IMAGE_INFORMATION SectionImageInfo;
		};
	};
} RTL_USER_PROCESS_INFORMATION, *PRTL_USER_PROCESS_INFORMATION;

#define _RTL_PROCESS_INFORMATION _RTL_USER_PROCESS_INFORMATION
#define RTL_PROCESS_INFORMATION RTL_USER_PROCESS_INFORMATION
#define PRTL_PROCESS_INFORMATION PRTL_USER_PROCESS_INFORMATION

typedef struct {
	GDI_HANDLE_TABLE_ITEM	Handles[GDI_HANDLE_TABLE_LENGTH];
} GDI_HANDLE_TABLE, *PGDI_HANDLE_TABLE;

typedef struct _MODULE_HEADER
{
	ULONG	Initialized;
	HANDLE	SsHandle;
	LIST_ENTRY InLoadOrderModuleList;
	LIST_ENTRY InMemoryOrderModuleList;
	LIST_ENTRY InInitializationOrderModuleList;
} MODULE_HEADER, *PMODULE_HEADER;

typedef struct _PROCESS_MODULE_INFO
{
	ULONG         Size; // 0x24
	MODULE_HEADER ModuleHeader;
} PROCESS_MODULE_INFO,  * PPROCESS_MODULE_INFO;

typedef PVOID PPEBLOCKROUTINE;
typedef struct _PEB_FREE_BLOCK *PPEB_FREE_BLOCK;
typedef struct _TEXT_INFO *PTEXT_INFO;

typedef struct _PEB
{
/*000*/ BOOLEAN                       InheritedAddressSpace;
/*001*/ BOOLEAN                       ReadImageFileExecOptions;
/*002*/ BOOLEAN                       BeingDebugged;
/*003*/ BOOLEAN                       SpareBool;  // Allocation size
/*004*/ HANDLE                        Mutant;
		union {
/*008*/ PVOID                         SectionBaseAddress;
/*008*/ PVOID                         ImageBaseAddress;
		};
		union {
/*00C*/ PPROCESS_MODULE_INFO	      ProcessModuleInfo; //Ldr
/*00C*/	PPEB_LDR_DATA				  Ldr;
		};
/*010*/ PRTL_USER_PROCESS_PARAMETERS  ProcessParameters;
/*014*/ ULONG                         SubSystemData;
/*018*/ HANDLE                        ProcessHeap;
/*01C*/ PRTL_CRITICAL_SECTION         FastPebLock;
/*020*/ PPEBLOCKROUTINE               AcquireFastPebLock; // function
/*024*/ PPEBLOCKROUTINE               ReleaseFastPebLock; // function
/*028*/ ULONG                         EnvironmentUpdateCount;
/*02C*/ PVOID*                        KernelCallbackTable;// functions
/*030*/ PVOID                         EventLogSection;
/*034*/ PVOID                         EventLog;
/*038*/ PPEB_FREE_BLOCK               FreeList;
/*03C*/ ULONG                         TlsExpansionCounter;      // number of bits
/*040*/ PRTL_BITMAP                   TlsBitmap;          // ntdll!TlsBitMap
/*044*/ ULONG                         TlsBitmapBits[2];  // 64 bits
/*04C*/ PVOID                         ReadOnlySharedMemoryBase;
/*050*/ HANDLE                        ReadOnlySharedMemoryHeap;
/*054*/ PTEXT_INFO                    TextInfo;
/*058*/ PVOID                         InitAnsiCodePageData;
/*05C*/ PVOID                         InitOemCodePageData;
/*060*/ PVOID                         InitUnicodeCaseTableData;
/*064*/ ULONG                         KeNumberProcessors;
/*068*/ ULONG                         NtGlobalFlag;
/*06C*/ UCHAR                         Spare2[0x4];
/*070*/ LARGE_INTEGER                 MmCriticalSectionTimeout;
/*078*/ ULONG                         MmHeapSegmentReserve;
/*07C*/ ULONG                         MmHeapSegmentCommit;
/*080*/ ULONG                         MmHeapDeCommitTotalFreeThreshold;
/*084*/ ULONG                         MmHeapDeCommitFreeBlockThreshold;
/*088*/ ULONG                         NumberOfHeaps;
/*08C*/ ULONG                         MaximumNumberOfHeaps; // 16 by default, *2 if exhausted
/*090*/ PHANDLE                       ProcessHeapsListBuffer;
/*094*/ PGDI_HANDLE_TABLE             GdiSharedHandleTable;
/*098*/ PVOID                         ProcessStarterHelper;
/*09C*/ ULONG                         GdiDCAttributeList;
/*0A0*/ PRTL_CRITICAL_SECTION         LoaderLock;
/*0A4*/ ULONG                         NtMajorVersion;
/*0A8*/ ULONG                         NtMinorVersion;
/*0AC*/ WORD                          NtBuildNumber;
/*0AE*/ WORD                          CmNtCSDVersion;
/*0B0*/ ULONG                         PlatformId;
/*0B4*/ ULONG                         Subsystem;
/*0B8*/ ULONG                         MajorSubsystemVersion;
/*0BC*/ ULONG                         MinorSubsystemVersion;
/*0C0*/ KAFFINITY                     AffinityMask;
/*0C4*/ HANDLE                        GdiHandleBuffer[0x22];
/*14C*/ PVOID                         PostProcessInitRoutine;
/*150*/ PVOID                         TlsExpansionBitmap;
/*154*/ UCHAR                         TlsExpansionBitmapBits[0x80];
/*1D4*/ ULONG                         SessionId;
/*1D8*/ ULARGE_INTEGER                AppCompatFlags;
/*1E0*/ ULARGE_INTEGER                AppCompatFlagsUser;
/*1E8*/ PVOID                         pShimData;
/*1EC*/ PVOID                         AppCompatInfo;
/*1F0*/ PUNICODE_STRING               CSDVersion;
/*1F8*/ PVOID                         ActivationContextData;
/*1FC*/ PVOID                         ProcessAssemblyStorageMap;
/*200*/ PVOID                         SystemDefaultActivationContextData;
/*204*/ PVOID                         SystemAssemblyStorageMap;
/*208*/ ULONG                         MinimumStackCommit;
/*20C*/ }  PEB, * PPEB;

/*
typedef struct _RTL_HEAP_DEFINITION {
	ULONG                   Length;
	ULONG                   Unknown1;
	ULONG                   Unknown2;
	ULONG                   Unknown3;
	ULONG                   Unknown4;
	ULONG                   Unknown5;
	ULONG                   Unknown6;
	ULONG                   Unknown7;
	ULONG                   Unknown8;
	ULONG                   Unknown9;
	ULONG                   Unknown10;
	ULONG                   Unknown11;
	ULONG                   Unknown12;
} RTL_HEAP_DEFINITION, *PRTL_HEAP_DEFINITION;*/

	
typedef NTSTATUS
(NTAPI * PRTL_HEAP_COMMIT_ROUTINE)(
    IN PVOID Base,
    IN OUT PVOID *CommitAddress,
    IN OUT PSIZE_T CommitSize
    );

// Real name for RTL_HEAP_DEFINITION
typedef struct _RTL_HEAP_PARAMETERS {
    ULONG Length;
    SIZE_T SegmentReserve;
    SIZE_T SegmentCommit;
    SIZE_T DeCommitFreeBlockThreshold;
    SIZE_T DeCommitTotalFreeThreshold;
    SIZE_T MaximumAllocationSize;
    SIZE_T VirtualMemoryThreshold;
    SIZE_T InitialCommit;
    SIZE_T InitialReserve;
    PRTL_HEAP_COMMIT_ROUTINE CommitRoutine;
    SIZE_T Reserved[ 2 ];
} RTL_HEAP_PARAMETERS, *PRTL_HEAP_PARAMETERS;

#define _RTL_HEAP_DEFINITION _RTL_HEAP_PARAMETERS
#define RTL_HEAP_DEFINITION RTL_HEAP_PARAMETERS
#define PRTL_HEAP_DEFINITION PRTL_HEAP_PARAMETERS

typedef NTSTATUS 
(NTAPI *PHEAP_ENUMERATION_ROUTINE)(
	IN HANDLE Heap,
	IN PVOID Context
	);

#ifndef _NTTYPES_NO_WINNT

typedef struct _PROCESS_HEAP_ENTRY {
    PVOID lpData;
    DWORD cbData;
    BYTE cbOverhead;
    BYTE iRegionIndex;
    WORD wFlags;
    union {
        struct {
            HANDLE hMem;
            DWORD dwReserved[ 3 ];
        } Block;
        struct {
            DWORD dwCommittedSize;
            DWORD dwUnCommittedSize;
            PVOID lpFirstBlock;
            PVOID lpLastBlock;
        } Region;
    };
} PROCESS_HEAP_ENTRY, *LPPROCESS_HEAP_ENTRY, *PPROCESS_HEAP_ENTRY;

#endif

enum {
	RTL_PROCESS_HEAP_ENTRY_BUSY				=	0x00000001,
	RTL_PROCESS_HEAP_REGION					=	0x00000002,
	RTL_PROCESS_HEAP_UNCOMMITED_RANGE		=	0x00000100,
	RTL_PROCESS_HEAP_ENTRY_MOVEABLE			=	0x00000200,
	RTL_PROCESS_HEAP_ENTRY_DDESHARE_BUSY	=	0x00000400
};

#include <pshpack4.h>
typedef struct _RTL_HEAP_TAG_INFO {
	ULONG AllocCount;
	ULONG FreeCount;
	ULONG MemoryUsed;
} RTL_HEAP_TAG_INFO, *LPRTL_HEAP_TAG_INFO, *PRTL_HEAP_TAG_INFO;
#include <poppack.h>

enum {
	NtDefaultStackReserve		=	100000,
	NtDefaultStackCommit		=	1000,
	NtDefaultHeapReserve		=	100000,
	NtDefaultHeapCommit			=	1000
};

//
//  Define the splay links and the associated manipuliation macros and
//  routines.  Note that the splay_links should be an opaque type.
//  Routine are provided to traverse and manipulate the structure.
//

typedef struct _RTL_SPLAY_LINKS {
    struct _RTL_SPLAY_LINKS *Parent;
    struct _RTL_SPLAY_LINKS *LeftChild;
    struct _RTL_SPLAY_LINKS *RightChild;
} RTL_SPLAY_LINKS;
typedef RTL_SPLAY_LINKS *PRTL_SPLAY_LINKS;


//
//  The following definitions are for the unicode version of the prefix
//  package.
//

typedef struct _UNICODE_PREFIX_TABLE_ENTRY {
    CSHORT NodeTypeCode;
    CSHORT NameLength;
    struct _UNICODE_PREFIX_TABLE_ENTRY *NextPrefixTree;
    struct _UNICODE_PREFIX_TABLE_ENTRY *CaseMatch;
    RTL_SPLAY_LINKS Links;
    PUNICODE_STRING Prefix;
} UNICODE_PREFIX_TABLE_ENTRY;
typedef UNICODE_PREFIX_TABLE_ENTRY *PUNICODE_PREFIX_TABLE_ENTRY;

typedef struct _UNICODE_PREFIX_TABLE {
    CSHORT NodeTypeCode;
    CSHORT NameLength;
    PUNICODE_PREFIX_TABLE_ENTRY NextPrefixTree;
    PUNICODE_PREFIX_TABLE_ENTRY LastNextEntry;
} UNICODE_PREFIX_TABLE;
typedef UNICODE_PREFIX_TABLE *PUNICODE_PREFIX_TABLE;

//
//  Compressed Data Information structure.  This structure is
//  used to describe the state of a compressed data buffer,
//  whose uncompressed size is known.  All compressed chunks
//  described by this structure must be compressed with the
//  same format.  On compressed reads, this entire structure
//  is an output, and on compressed writes the entire structure
//  is an input.
//

typedef struct _COMPRESSED_DATA_INFO {

    //
    //  Code for the compression format (and engine) as
    //  defined in ntrtl.h.  Note that COMPRESSION_FORMAT_NONE
    //  and COMPRESSION_FORMAT_DEFAULT are invalid if
    //  any of the described chunks are compressed.
    //

    USHORT CompressionFormatAndEngine;

    //
    //  Since chunks and compression units are expected to be
    //  powers of 2 in size, we express then log2.  So, for
    //  example (1 << ChunkShift) == ChunkSizeInBytes.  The
    //  ClusterShift indicates how much space must be saved
    //  to successfully compress a compression unit - each
    //  successfully compressed compression unit must occupy
    //  at least one cluster less in bytes than an uncompressed
    //  compression unit.
    //

    UCHAR CompressionUnitShift;
    UCHAR ChunkShift;
    UCHAR ClusterShift;
    UCHAR Reserved;

    //
    //  This is the number of entries in the CompressedChunkSizes
    //  array.
    //

    USHORT NumberOfChunks;

    //
    //  This is an array of the sizes of all chunks resident
    //  in the compressed data buffer.  There must be one entry
    //  in this array for each chunk possible in the uncompressed
    //  buffer size.  A size of FSRTL_CHUNK_SIZE indicates the
    //  corresponding chunk is uncompressed and occupies exactly
    //  that size.  A size of 0 indicates that the corresponding
    //  chunk contains nothing but binary 0's, and occupies no
    //  space in the compressed data.  All other sizes must be
    //  less than FSRTL_CHUNK_SIZE, and indicate the exact size
    //  of the compressed data in bytes.
    //

    ULONG CompressedChunkSizes[ANYSIZE_ARRAY];

} COMPRESSED_DATA_INFO;
typedef COMPRESSED_DATA_INFO *PCOMPRESSED_DATA_INFO;

//
//  The results of a compare can be less than, equal, or greater than.
//

typedef enum _RTL_GENERIC_COMPARE_RESULTS {
    GenericLessThan,
    GenericGreaterThan,
    GenericEqual
} RTL_GENERIC_COMPARE_RESULTS;

//
//  Define the generic table package.  Note a generic table should really
//  be an opaque type.  We provide routines to manipulate the structure.
//
//  A generic table is package for inserting, deleting, and looking up elements
//  in a table (e.g., in a symbol table).  To use this package the user
//  defines the structure of the elements stored in the table, provides a
//  comparison function, a memory allocation function, and a memory
//  deallocation function.
//
//  Note: the user compare function must impose a complete ordering among
//  all of the elements, and the table does not allow for duplicate entries.
//

//
//  Do not do the following defines if using Avl
//

#ifndef RTL_USE_AVL_TABLES

//
// Add an empty typedef so that functions can reference the
// a pointer to the generic table struct before it is declared.
//

struct _RTL_GENERIC_TABLE;

//
//  The comparison function takes as input pointers to elements containing
//  user defined structures and returns the results of comparing the two
//  elements.
//

typedef
RTL_GENERIC_COMPARE_RESULTS
(NTAPI *PRTL_GENERIC_COMPARE_ROUTINE) (
    struct _RTL_GENERIC_TABLE *Table,
    PVOID FirstStruct,
    PVOID SecondStruct
    );

//
//  The allocation function is called by the generic table package whenever
//  it needs to allocate memory for the table.
//

typedef
PVOID
(NTAPI *PRTL_GENERIC_ALLOCATE_ROUTINE) (
    struct _RTL_GENERIC_TABLE *Table,
    CLONG ByteSize
    );

//
//  The deallocation function is called by the generic table package whenever
//  it needs to deallocate memory from the table that was allocated by calling
//  the user supplied allocation function.
//

typedef
VOID
(NTAPI *PRTL_GENERIC_FREE_ROUTINE) (
    struct _RTL_GENERIC_TABLE *Table,
    PVOID Buffer
    );

//
//  To use the generic table package the user declares a variable of type
//  GENERIC_TABLE and then uses the routines described below to initialize
//  the table and to manipulate the table.  Note that the generic table
//  should really be an opaque type.
//

typedef struct _RTL_GENERIC_TABLE {
    PRTL_SPLAY_LINKS TableRoot;
    LIST_ENTRY InsertOrderList;
    PLIST_ENTRY OrderedPointer;
    ULONG WhichOrderedElement;
    ULONG NumberGenericTableElements;
    PRTL_GENERIC_COMPARE_ROUTINE CompareRoutine;
    PRTL_GENERIC_ALLOCATE_ROUTINE AllocateRoutine;
    PRTL_GENERIC_FREE_ROUTINE FreeRoutine;
    PVOID TableContext;
} RTL_GENERIC_TABLE;
typedef RTL_GENERIC_TABLE *PRTL_GENERIC_TABLE;

#endif

#ifndef _NTTYPES_NO_WINNT

#ifndef OVERLAPPED

//
//  File structures
//

typedef struct _OVERLAPPED {
    ULONG_PTR Internal;
    ULONG_PTR InternalHigh;
    union {
        struct {
            DWORD Offset;
            DWORD OffsetHigh;
        };

        PVOID Pointer;
    };

    HANDLE  hEvent;
} OVERLAPPED, *LPOVERLAPPED;

#endif

#endif

#ifndef LPOVERLAPPED_COMPLETION_ROUTINE

typedef
VOID
(NTAPI *LPOVERLAPPED_COMPLETION_ROUTINE)(
    DWORD dwErrorCode,
    DWORD dwNumberOfBytesTransfered,
    LPOVERLAPPED lpOverlapped
    );

#endif

#ifndef POVERLAPPED_COMPLETION_ROUTINE

typedef
VOID
(NTAPI *POVERLAPPED_COMPLETION_ROUTINE)(
    DWORD dwErrorCode,
    DWORD dwNumberOfBytesTransfered,
    LPOVERLAPPED lpOverlapped
    );

#endif





#ifndef __IDA__
#ifndef SID_REVISION
enum {
	SID_REVISION					=	1
};
#endif

#ifndef SID_MAX_SUB_AUTHORITIES
enum {
	SID_MAX_SUB_AUTHORITIES			=	15
};
#endif

#ifndef SID_RECOMMENDED_SUB_AUTHORITIES
enum {
	SID_RECOMMENDED_SUB_AUTHORITIES	=	1
};
#endif
#endif

#ifndef ANYSIZE_ARRAY
#define ANYSIZE_ARRAY 1
#endif

/*
typedef struct _COMPRESSED_DATA_INFO {
	USHORT  CompressionFormatAndEngine;
	UCHAR   CompressionUnitShift;
	UCHAR   ChunkShift;
	UCHAR   ClusterShift;
	UCHAR   Reserved;
	USHORT  NumberOfChunks;
	ULONG   CompressedChunkSizes[ANYSIZE_ARRAY];
} COMPRESSED_DATA_INFO, *PCOMPRESSED_DATA_INFO;
*/

typedef struct _GENERATE_NAME_CONTEXT {
	USHORT  Checksum;
	BOOLEAN CheckSumInserted;
	UCHAR   NameLength;
	WCHAR   NameBuffer[8];
	ULONG   ExtensionLength;
	WCHAR   ExtensionBuffer[4];
	ULONG   LastIndexValue;
} GENERATE_NAME_CONTEXT, *PGENERATE_NAME_CONTEXT;

enum {
	DELETE_MAX_PRIVILEGES		=	0x00000001
};

// NtLockProductActivationKeys parameter
typedef enum _SAFEBOOT_MODE {
	SAFEBOOT_NORMAL			=	0,
	SAFEBOOT_MINIMAL		=	1,
	SAFEBOOT_NETWORK		=	2,
	SAFEBOOT_DSREPAIR		=	3	// Domain controllers only
} SAFEBOOT_MODE, *PSAFEBOOT_MODE;

enum {
	NtKeyedEventValidAttributes	=	OBJ_CASE_INSENSITIVE
};

// System Environment Values (firmware settings)

#define SV_AUTOLOAD_NAME			L"AUTOLOAD"
#define SV_COUNTDOWN_NAME			L"COUNTDOWN"
#define SV_OSLOADER_NAME			L"OSLOADER"
#define SV_SYSTEMPARTITION_NAME		L"SYSTEMPARTITION"
#define SV_LASTKNOWNBOOT_NAME		L"LastKnownBoot"
#define SV_OSLOADPARTITION_NAME		L"OSLOADPARTITION"
#define SV_OSLOADFILENAME_NAME		L"OSLOADFILENAME"
#define SV_OSLOADOPTIONS_NAME		L"OSLOADOPTIONS"
#define SV_LOADIDENTIFIER_NAME		L"LOADIDENTIFIER"

typedef LONG (NTAPI* PRTL_VECTORED_EXCEPTION_HANDLER)(struct _EXCEPTION_POINTERS *ExceptionInfo);

// NTFS on-disk structures

#ifndef NTNATIVE_NO_NTFS

typedef struct {
    ULONG Type;
    USHORT UsaOffset;
    USHORT UsaCount;
    USN Usn;
} NTFS_RECORD_HEADER, *PNTFS_RECORD_HEADER;

typedef struct {
    NTFS_RECORD_HEADER Ntfs;
    USHORT SequenceNumber;
    USHORT LinkCount;
    USHORT AttributesOffset;
    USHORT Flags;               // 0x0001 = InUse, 0x0002 = Directory
    ULONG BytesInUse;
    ULONG BytesAllocated;
    ULONGLONG BaseFileRecord;
    USHORT NextAttributeNumber;
} FILE_RECORD_HEADER, *PFILE_RECORD_HEADER;

typedef enum {
    AttributeStandardInformation = 0x10,
    AttributeAttributeList = 0x20,
    AttributeFileName = 0x30,
    AttributeObjectId = 0x40,
    AttributeSecurityDescriptor = 0x50,
    AttributeVolumeName = 0x60,
    AttributeVolumeInformation = 0x70,
    AttributeData = 0x80,
    AttributeIndexRoot = 0x90,
    AttributeIndexAllocation = 0xA0,
    AttributeBitmap = 0xB0,
    AttributeReparsePoint = 0xC0,
    AttributeEAInformation = 0xD0,
    AttributeEA = 0xE0,
    AttributePropertySet = 0xF0,
    AttributeLoggedUtilityStream = 0x100
} ATTRIBUTE_TYPE, *PATTRIBUTE_TYPE;

typedef struct {
    ATTRIBUTE_TYPE AttributeType;
    ULONG Length;
    BOOLEAN Nonresident;
    UCHAR NameLength;
    USHORT NameOffset;
    USHORT Flags;               // 0x0001 = Compressed
    USHORT AttributeNumber;
} ATTRIBUTE, *PATTRIBUTE;

typedef struct {
    ATTRIBUTE Attribute;
    ULONG ValueLength;
    USHORT ValueOffset;
    USHORT Flags;               // 0x0001 = Indexed
} RESIDENT_ATTRIBUTE, *PRESIDENT_ATTRIBUTE;

typedef struct {
    ATTRIBUTE Attribute;
    ULONGLONG LowVcn;
    ULONGLONG HighVcn;
    USHORT RunArrayOffset;
    UCHAR CompressionUnit;
    UCHAR AlignmentOrReserved[5];
    ULONGLONG AllocatedSize;
    ULONGLONG DataSize;
    ULONGLONG InitializedSize;
    ULONGLONG CompressedSize;    // Only when compressed
} NONRESIDENT_ATTRIBUTE, *PNONRESIDENT_ATTRIBUTE;

typedef struct {
    ULONGLONG CreationTime; 
    ULONGLONG ChangeTime;
    ULONGLONG LastWriteTime; 
    ULONGLONG LastAccessTime; 
    ULONG FileAttributes; 
    ULONG AlignmentOrReservedOrUnknown[3];
#if _WIN32_WINNT >= 0x0500
    ULONG QuotaId;                        // NTFS 3.0 only
    ULONG SecurityId;                     // NTFS 3.0 only
    ULONGLONG QuotaCharge;                // NTFS 3.0 only
    USN Usn;                              // NTFS 3.0 only
#endif
} STANDARD_INFORMATION, *PSTANDARD_INFORMATION;

typedef struct {
    ATTRIBUTE_TYPE AttributeType;
    USHORT Length;
    UCHAR NameLength;
    UCHAR NameOffset;
    ULONGLONG LowVcn;
    ULONGLONG FileReferenceNumber;
    USHORT AttributeNumber;
    USHORT AlignmentOrReserved[3];
} ATTRIBUTE_LIST, *PATTRIBUTE_LIST;

typedef struct {
    ULONGLONG DirectoryFileReferenceNumber;
    ULONGLONG CreationTime;   // Saved when filename last changed
    ULONGLONG ChangeTime;     // ditto
    ULONGLONG LastWriteTime;  // ditto
    ULONGLONG LastAccessTime; // ditto
    ULONGLONG AllocatedSize;  // ditto
    ULONGLONG DataSize;       // ditto
    ULONG FileAttributes;     // ditto
    ULONG AlignmentOrReserved;
    UCHAR NameLength;
    UCHAR NameType;           // 0x01 = Long, 0x02 = Short
    WCHAR Name[1];
} FILENAME_ATTRIBUTE, *PFILENAME_ATTRIBUTE;

typedef struct {
    GUID ObjectId;
    union {
        struct {
            GUID BirthVolumeId;
            GUID BirthObjectId;
            GUID DomainId;
        } ;
        UCHAR ExtendedInfo[48];
    };
} OBJECTID_ATTRIBUTE, *POBJECTID_ATTRIBUTE;

typedef struct {
    ULONG Unknown[2];
    UCHAR MajorVersion;
    UCHAR MinorVersion;
    USHORT Flags;
} VOLUME_INFORMATION, *PVOLUME_INFORMATION;

typedef struct {
    ULONG EntriesOffset;
    ULONG IndexBlockLength;
    ULONG AllocatedSize;
    ULONG Flags;         // 0x00 = Small directory, 0x01 = Large directory
} DIRECTORY_INDEX, *PDIRECTORY_INDEX;

typedef struct {
    ULONGLONG FileReferenceNumber;
    USHORT Length;
    USHORT AttributeLength;
    ULONG Flags;           // 0x01 = Has trailing VCN, 0x02 = Last entry
    // FILENAME_ATTRIBUTE Name;
    // ULONGLONG Vcn;      // VCN in IndexAllocation of earlier entries
} DIRECTORY_ENTRY, *PDIRECTORY_ENTRY;

typedef struct {
    ATTRIBUTE_TYPE Type;
    ULONG CollationRule;
    ULONG BytesPerIndexBlock;
    ULONG ClustersPerIndexBlock;
    DIRECTORY_INDEX DirectoryIndex;
} INDEX_ROOT, *PINDEX_ROOT;

typedef struct {
    NTFS_RECORD_HEADER Ntfs;
    ULONGLONG IndexBlockVcn;
    DIRECTORY_INDEX DirectoryIndex;
} INDEX_BLOCK_HEADER, *PINDEX_BLOCK_HEADER;

typedef struct {
    ULONG ReparseTag;
    USHORT ReparseDataLength;
    USHORT Reserved;
    UCHAR ReparseData[1];
} REPARSE_POINT, *PREPARSE_POINT;

typedef struct {
    ULONG EaLength;
    ULONG EaQueryLength;
} EA_INFORMATION, *PEA_INFORMATION;

typedef struct {
    ULONG NextEntryOffset;
    UCHAR Flags;
    UCHAR EaNameLength;
    USHORT EaValueLength;
    CHAR EaName[1];
    // UCHAR EaData[];
} EA_ATTRIBUTE, *PEA_ATTRIBUTE;

typedef struct {
    WCHAR AttributeName[64];
    ULONG AttributeNumber;
    ULONG Unknown[2];
    ULONG Flags;
    ULONGLONG MinimumSize;
    ULONGLONG MaximumSize;
} ATTRIBUTE_DEFINITION, *PATTRIBUTE_DEFINITION;

#include <pshpack1.h>

typedef struct {
    UCHAR Jump[3];
    UCHAR Format[8];
    USHORT BytesPerSector;
    UCHAR SectorsPerCluster;
    USHORT BootSectors;
    UCHAR Mbz1;
    USHORT Mbz2;
    USHORT Reserved1;
    UCHAR MediaType;
    USHORT Mbz3;
    USHORT SectorsPerTrack;
    USHORT NumberOfHeads;
    ULONG PartitionOffset;
    ULONG Reserved2[2];
    ULONGLONG TotalSectors;
    ULONGLONG MftStartLcn;
    ULONGLONG Mft2StartLcn;
    ULONG ClustersPerFileRecord;
    ULONG ClustersPerIndexBlock;
    ULONGLONG VolumeSerialNumber;
    UCHAR Code[0x1AE];
    USHORT BootSignature;
} BOOT_BLOCK, *PBOOT_BLOCK;

#include <poppack.h>

#endif // NTNATIVE_NO_NTFS




//
// Security rights for kernel objects
//



#ifndef _NTTYPES_NO_WINNT

//
// Process
//

#define PROCESS_TERMINATE         (0x0001)  
#define PROCESS_CREATE_THREAD     (0x0002)  
#define PROCESS_SET_SESSIONID     (0x0004)  
#define PROCESS_VM_OPERATION      (0x0008)  
#define PROCESS_VM_READ           (0x0010)  
#define PROCESS_VM_WRITE          (0x0020)  
#define PROCESS_DUP_HANDLE        (0x0040)  
#define PROCESS_CREATE_PROCESS    (0x0080)  
#define PROCESS_SET_QUOTA         (0x0100)  
#define PROCESS_SET_INFORMATION   (0x0200)  
#define PROCESS_QUERY_INFORMATION (0x0400)  
#define PROCESS_SUSPEND_RESUME    (0x0800)  
#define PROCESS_ALL_ACCESS        (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | \
                                   0xFFF)

//
// Thread
//

#define THREAD_TERMINATE               (0x0001)  
#define THREAD_SUSPEND_RESUME          (0x0002)  
#define THREAD_GET_CONTEXT             (0x0008)  
#define THREAD_SET_CONTEXT             (0x0010)  
#define THREAD_SET_INFORMATION         (0x0020)  
#define THREAD_QUERY_INFORMATION       (0x0040)  
#define THREAD_SET_THREAD_TOKEN        (0x0080)
#define THREAD_IMPERSONATE             (0x0100)
#define THREAD_DIRECT_IMPERSONATION    (0x0200)

#define THREAD_ALL_ACCESS         (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | \
	0x3FF)

//
// Process
//

#if ((defined(_WIN32_WINNT) && (_WIN32_WINNT > 0x0400)) || (!defined(_WIN32_WINNT)))
#define TOKEN_ALL_ACCESS  (TOKEN_ALL_ACCESS_P |\
                          TOKEN_ADJUST_SESSIONID )
#else
#define TOKEN_ALL_ACCESS  (TOKEN_ALL_ACCESS_P)
#endif

#define TOKEN_READ       (STANDARD_RIGHTS_READ      |\
                          TOKEN_QUERY)


#define TOKEN_WRITE      (STANDARD_RIGHTS_WRITE     |\
                          TOKEN_ADJUST_PRIVILEGES   |\
                          TOKEN_ADJUST_GROUPS       |\
                          TOKEN_ADJUST_DEFAULT)

#define TOKEN_EXECUTE    (STANDARD_RIGHTS_EXECUTE)

//
// Token
//

#define TOKEN_ASSIGN_PRIMARY    (0x0001)
#define TOKEN_DUPLICATE         (0x0002)
#define TOKEN_IMPERSONATE       (0x0004)
#define TOKEN_QUERY             (0x0008)
#define TOKEN_QUERY_SOURCE      (0x0010)
#define TOKEN_ADJUST_PRIVILEGES (0x0020)
#define TOKEN_ADJUST_GROUPS     (0x0040)
#define TOKEN_ADJUST_DEFAULT    (0x0080)
#define TOKEN_ADJUST_SESSIONID  (0x0100)

#define TOKEN_ALL_ACCESS_P (STANDARD_RIGHTS_REQUIRED  |\
	TOKEN_ASSIGN_PRIMARY      |\
	TOKEN_DUPLICATE           |\
	TOKEN_IMPERSONATE         |\
	TOKEN_QUERY               |\
	TOKEN_QUERY_SOURCE        |\
	TOKEN_ADJUST_PRIVILEGES   |\
	TOKEN_ADJUST_GROUPS       |\
	TOKEN_ADJUST_DEFAULT )

//
// Job
//

#define JOB_OBJECT_ASSIGN_PROCESS           (0x0001)
#define JOB_OBJECT_SET_ATTRIBUTES           (0x0002)
#define JOB_OBJECT_QUERY                    (0x0004)
#define JOB_OBJECT_TERMINATE                (0x0008)
#define JOB_OBJECT_SET_SECURITY_ATTRIBUTES  (0x0010)
#define JOB_OBJECT_ALL_ACCESS       (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | \
                                        0x1F )

//
// Token
//

#if ((defined(_WIN32_WINNT) && (_WIN32_WINNT > 0x0400)) || (!defined(_WIN32_WINNT)))
#define TOKEN_ALL_ACCESS  (TOKEN_ALL_ACCESS_P |\
							TOKEN_ADJUST_SESSIONID )
#else
#define TOKEN_ALL_ACCESS  (TOKEN_ALL_ACCESS_P)
#endif

#define TOKEN_READ       (STANDARD_RIGHTS_READ      |\
							TOKEN_QUERY)


#define TOKEN_WRITE      (STANDARD_RIGHTS_WRITE     |\
							TOKEN_ADJUST_PRIVILEGES   |\
							TOKEN_ADJUST_GROUPS       |\
							TOKEN_ADJUST_DEFAULT)

#define TOKEN_EXECUTE    (STANDARD_RIGHTS_EXECUTE)

//
// Event
//

#define EVENT_MODIFY_STATE      0x0002  
#define EVENT_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|0x3) 

//
// Mutant
//

#define MUTANT_QUERY_STATE      0x0001

#define MUTANT_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|\
							MUTANT_QUERY_STATE)


//
// Semaphore
//

#define SEMAPHORE_MODIFY_STATE      0x0002  
#define SEMAPHORE_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|0x3) 

//
// Timer
//

#define TIMER_QUERY_STATE       0x0001
#define TIMER_MODIFY_STATE      0x0002

#define TIMER_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|\
	TIMER_QUERY_STATE|TIMER_MODIFY_STATE)

//
// Section
//

#define SECTION_QUERY                0x0001
#define SECTION_MAP_WRITE            0x0002
#define SECTION_MAP_READ             0x0004
#define SECTION_MAP_EXECUTE          0x0008
#define SECTION_EXTEND_SIZE          0x0010
#define SECTION_MAP_EXECUTE_EXPLICIT 0x0020 // not included in SECTION_ALL_ACCESS

#define SECTION_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SECTION_QUERY|\
                            SECTION_MAP_WRITE |      \
                            SECTION_MAP_READ |       \
                            SECTION_MAP_EXECUTE |    \
                            SECTION_EXTEND_SIZE)

//
// File
//

#define FILE_READ_DATA            ( 0x0001 )    // file & pipe
#define FILE_LIST_DIRECTORY       ( 0x0001 )    // directory

#define FILE_WRITE_DATA           ( 0x0002 )    // file & pipe
#define FILE_ADD_FILE             ( 0x0002 )    // directory

#define FILE_APPEND_DATA          ( 0x0004 )    // file
#define FILE_ADD_SUBDIRECTORY     ( 0x0004 )    // directory
#define FILE_CREATE_PIPE_INSTANCE ( 0x0004 )    // named pipe


#define FILE_READ_EA              ( 0x0008 )    // file & directory

#define FILE_WRITE_EA             ( 0x0010 )    // file & directory

#define FILE_EXECUTE              ( 0x0020 )    // file
#define FILE_TRAVERSE             ( 0x0020 )    // directory

#define FILE_DELETE_CHILD         ( 0x0040 )    // directory

#define FILE_READ_ATTRIBUTES      ( 0x0080 )    // all

#define FILE_WRITE_ATTRIBUTES     ( 0x0100 )    // all

#define FILE_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x1FF)

#define FILE_GENERIC_READ         (STANDARD_RIGHTS_READ     |\
                                   FILE_READ_DATA           |\
                                   FILE_READ_ATTRIBUTES     |\
                                   FILE_READ_EA             |\
                                   SYNCHRONIZE)


#define FILE_GENERIC_WRITE        (STANDARD_RIGHTS_WRITE    |\
                                   FILE_WRITE_DATA          |\
                                   FILE_WRITE_ATTRIBUTES    |\
                                   FILE_WRITE_EA            |\
                                   FILE_APPEND_DATA         |\
                                   SYNCHRONIZE)


#define FILE_GENERIC_EXECUTE      (STANDARD_RIGHTS_EXECUTE  |\
                                   FILE_READ_ATTRIBUTES     |\
                                   FILE_EXECUTE             |\
                                   SYNCHRONIZE)

//
// IoCompletion
//

#define IO_COMPLETION_MODIFY_STATE  0x0002  
#define IO_COMPLETION_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|0x3) 

//
// Key
//

#define KEY_QUERY_VALUE         (0x0001)
#define KEY_SET_VALUE           (0x0002)
#define KEY_CREATE_SUB_KEY      (0x0004)
#define KEY_ENUMERATE_SUB_KEYS  (0x0008)
#define KEY_NOTIFY              (0x0010)
#define KEY_CREATE_LINK         (0x0020)
#define KEY_WOW64_32KEY         (0x0200)
#define KEY_WOW64_64KEY         (0x0100)
#define KEY_WOW64_RES           (0x0300)

#define KEY_READ                ((STANDARD_RIGHTS_READ       |\
                                  KEY_QUERY_VALUE            |\
                                  KEY_ENUMERATE_SUB_KEYS     |\
                                  KEY_NOTIFY)                 \
                                  &                           \
                                 (~SYNCHRONIZE))


#define KEY_WRITE               ((STANDARD_RIGHTS_WRITE      |\
                                  KEY_SET_VALUE              |\
                                  KEY_CREATE_SUB_KEY)         \
                                  &                           \
                                 (~SYNCHRONIZE))

#define KEY_EXECUTE             ((KEY_READ)                   \
                                  &                           \
                                 (~SYNCHRONIZE))

#define KEY_ALL_ACCESS          ((STANDARD_RIGHTS_ALL        |\
                                  KEY_QUERY_VALUE            |\
                                  KEY_SET_VALUE              |\
                                  KEY_CREATE_SUB_KEY         |\
                                  KEY_ENUMERATE_SUB_KEYS     |\
                                  KEY_NOTIFY                 |\
                                  KEY_CREATE_LINK)            \
                                  &                           \
                                 (~SYNCHRONIZE))


#endif

//
// IoCompletion, other objects (not in Winnt.h)
//

//#ifndef _NTTYPES_NO_WINNT

#define EVENT_QUERY_STATE		0x0001
#define SEMAPHORE_QUERY_STATE       0x0001
#define IO_COMPLETION_QUERY_STATE  0x0001  
#define PROCESS_SET_PORT          (0x0800)	/* Obsolete; use PROCESS_SUSPEND_RESUME instead */

#define EVENT_PAIR_ALL_ACCESS		STANDARD_RIGHTS_ALL


//
// Object Manager Object Type Specific Access Rights.
//

#define OBJECT_TYPE_CREATE (0x0001)

#define OBJECT_TYPE_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED | 0x1)

//
// Object Manager Directory Specific Access Rights.
//

#define DIRECTORY_QUERY                 (0x0001)
#define DIRECTORY_TRAVERSE              (0x0002)
#define DIRECTORY_CREATE_OBJECT         (0x0004)
#define DIRECTORY_CREATE_SUBDIRECTORY   (0x0008)

#define DIRECTORY_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED | 0xF)

//
// Object Manager Symbolic Link Specific Access Rights.
//

#define SYMBOLIC_LINK_QUERY (0x0001)

#define SYMBOLIC_LINK_ALL_ACCESS (STANDARD_RIGHTS_REQUIRED | 0x1)


//#endif


// Port access masks
enum {
	PORT_CONNECT			=	0x00000001,
	PORT_ALL_ACCESS			=	PORT_CONNECT | STANDARD_RIGHTS_ALL
};

#if _WIN32_WINNT >= 0x0501

// Keyed event access masks
enum {
	KEYED_EVENT_WAIT			=	0x00000001,	// Needed to call NtWaitForKeyedEvent
	KEYED_EVENT_RELEASE				=	0x00000002,	// Needed to call NtReleaseKeyedEvent
	KEYED_EVENT_ALL_ACCESS	=	KEYED_EVENT_WAIT | KEYED_EVENT_RELEASE	// All permissible access attributes
};

//
// DebugObject access rights.
// Note that DEBUG_OBJECT_ALL_ACCESS includes the specific rights 0x0F, but there are only two
// debug object specific access rights that are ever checked by the kernel.  This appears to be a bug.
//

#define DEBUG_OBJECT_ALL_ACCESS							(STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x0F)
#define DEBUG_OBJECT_WAIT_STATE_CHANGE					0x0001	/* Required to call NtWaitForDebugEvent & NtContinueDebugEvent */
#define DEBUG_OBJECT_ADD_REMOVE_PROCESS					0x0002	/* Required to call NtDebugActiveProcess & NtRemoveProcessDebug */

#endif


//
// End of kernel object security
//


//
// Open flags / attributes / flags / options / etc
//

#ifndef _NTTYPES_NO_WINNT

//
// File
//

#define FILE_SHARE_READ                 0x00000001  
#define FILE_SHARE_WRITE                0x00000002  
#define FILE_SHARE_DELETE               0x00000004  
#define FILE_ATTRIBUTE_READONLY             0x00000001  
#define FILE_ATTRIBUTE_HIDDEN               0x00000002  
#define FILE_ATTRIBUTE_SYSTEM               0x00000004  
#define FILE_ATTRIBUTE_DIRECTORY            0x00000010  
#define FILE_ATTRIBUTE_ARCHIVE              0x00000020  
#define FILE_ATTRIBUTE_DEVICE               0x00000040  
#define FILE_ATTRIBUTE_NORMAL               0x00000080  
#define FILE_ATTRIBUTE_TEMPORARY            0x00000100  
#define FILE_ATTRIBUTE_SPARSE_FILE          0x00000200  
#define FILE_ATTRIBUTE_REPARSE_POINT        0x00000400  
#define FILE_ATTRIBUTE_COMPRESSED           0x00000800  
#define FILE_ATTRIBUTE_OFFLINE              0x00001000  
#define FILE_ATTRIBUTE_NOT_CONTENT_INDEXED  0x00002000  
#define FILE_ATTRIBUTE_ENCRYPTED            0x00004000  
#define FILE_NOTIFY_CHANGE_FILE_NAME    0x00000001   
#define FILE_NOTIFY_CHANGE_DIR_NAME     0x00000002   
#define FILE_NOTIFY_CHANGE_ATTRIBUTES   0x00000004   
#define FILE_NOTIFY_CHANGE_SIZE         0x00000008   
#define FILE_NOTIFY_CHANGE_LAST_WRITE   0x00000010   
#define FILE_NOTIFY_CHANGE_LAST_ACCESS  0x00000020   
#define FILE_NOTIFY_CHANGE_CREATION     0x00000040   
#define FILE_NOTIFY_CHANGE_SECURITY     0x00000100   
#define FILE_ACTION_ADDED                   0x00000001   
#define FILE_ACTION_REMOVED                 0x00000002   
#define FILE_ACTION_MODIFIED                0x00000003   
#define FILE_ACTION_RENAMED_OLD_NAME        0x00000004   
#define FILE_ACTION_RENAMED_NEW_NAME        0x00000005   
#define MAILSLOT_NO_MESSAGE             ((DWORD)-1) 
#define MAILSLOT_WAIT_FOREVER           ((DWORD)-1) 
#define FILE_CASE_SENSITIVE_SEARCH      0x00000001  
#define FILE_CASE_PRESERVED_NAMES       0x00000002  
#define FILE_UNICODE_ON_DISK            0x00000004  
#define FILE_PERSISTENT_ACLS            0x00000008  
#define FILE_FILE_COMPRESSION           0x00000010  
#define FILE_VOLUME_QUOTAS              0x00000020  
#define FILE_SUPPORTS_SPARSE_FILES      0x00000040  
#define FILE_SUPPORTS_REPARSE_POINTS    0x00000080  
#define FILE_SUPPORTS_REMOTE_STORAGE    0x00000100  
#define FILE_VOLUME_IS_COMPRESSED       0x00008000  
#define FILE_SUPPORTS_OBJECT_IDS        0x00010000  
#define FILE_SUPPORTS_ENCRYPTION        0x00020000  
#define FILE_NAMED_STREAMS              0x00040000  
#define FILE_READ_ONLY_VOLUME           0x00080000  

//
// Key
//

//
// Open/Create Options
//

#define REG_OPTION_RESERVED         (0x00000000L)   // Parameter is reserved

#define REG_OPTION_NON_VOLATILE     (0x00000000L)   // Key is preserved
                                                    // when system is rebooted

#define REG_OPTION_VOLATILE         (0x00000001L)   // Key is not preserved
                                                    // when system is rebooted

#define REG_OPTION_CREATE_LINK      (0x00000002L)   // Created key is a
                                                    // symbolic link

#define REG_OPTION_BACKUP_RESTORE   (0x00000004L)   // open for backup or restore
                                                    // special access rules
                                                    // privilege required

#define REG_OPTION_OPEN_LINK        (0x00000008L)   // Open symbolic link

#define REG_LEGAL_OPTION            \
                (REG_OPTION_RESERVED            |\
                 REG_OPTION_NON_VOLATILE        |\
                 REG_OPTION_VOLATILE            |\
                 REG_OPTION_CREATE_LINK         |\
                 REG_OPTION_BACKUP_RESTORE      |\
                 REG_OPTION_OPEN_LINK)

//
// Key creation/open disposition
//

#define REG_CREATED_NEW_KEY         (0x00000001L)   // New Registry Key created
#define REG_OPENED_EXISTING_KEY     (0x00000002L)   // Existing Key opened

//
// hive format to be used by Reg(Nt)SaveKeyEx
//
#define REG_STANDARD_FORMAT     1
#define REG_LATEST_FORMAT       2
#define REG_NO_COMPRESSION      4

//
// Key restore flags
//

#define REG_WHOLE_HIVE_VOLATILE     (0x00000001L)   // Restore whole hive volatile
#define REG_REFRESH_HIVE            (0x00000002L)   // Unwind changes to last flush
#define REG_NO_LAZY_FLUSH           (0x00000004L)   // Never lazy flush this hive
#define REG_FORCE_RESTORE           (0x00000008L)   // Force the restore process even when we have open handles on subkeys

// end_ntddk end_wdm end_nthal

//
// Notify filter values
//
#define REG_NOTIFY_CHANGE_NAME          (0x00000001L) // Create or delete (child)
#define REG_NOTIFY_CHANGE_ATTRIBUTES    (0x00000002L)
#define REG_NOTIFY_CHANGE_LAST_SET      (0x00000004L) // time stamp
#define REG_NOTIFY_CHANGE_SECURITY      (0x00000008L)

#define REG_LEGAL_CHANGE_FILTER                 \
                (REG_NOTIFY_CHANGE_NAME          |\
                 REG_NOTIFY_CHANGE_ATTRIBUTES    |\
                 REG_NOTIFY_CHANGE_LAST_SET      |\
                 REG_NOTIFY_CHANGE_SECURITY)

//
//
// Predefined Value Types.
//

#define REG_NONE                    ( 0 )   // No value type
#define REG_SZ                      ( 1 )   // Unicode nul terminated string
#define REG_EXPAND_SZ               ( 2 )   // Unicode nul terminated string
                                            // (with environment variable references)
#define REG_BINARY                  ( 3 )   // Free form binary
#define REG_DWORD                   ( 4 )   // 32-bit number
#define REG_DWORD_LITTLE_ENDIAN     ( 4 )   // 32-bit number (same as REG_DWORD)
#define REG_DWORD_BIG_ENDIAN        ( 5 )   // 32-bit number
#define REG_LINK                    ( 6 )   // Symbolic Link (unicode)
#define REG_MULTI_SZ                ( 7 )   // Multiple Unicode strings
#define REG_RESOURCE_LIST           ( 8 )   // Resource list in the resource map
#define REG_FULL_RESOURCE_DESCRIPTOR ( 9 )  // Resource list in the hardware description
#define REG_RESOURCE_REQUIREMENTS_LIST ( 10 )
#define REG_QWORD                   ( 11 )  // 64-bit number
#define REG_QWORD_LITTLE_ENDIAN     ( 11 )  // 64-bit number (same as REG_QWORD)

//
// Job Object
//

#define JOB_OBJECT_TERMINATE_AT_END_OF_JOB  0
#define JOB_OBJECT_POST_AT_END_OF_JOB       1

//
// Completion Port Messages for job objects
//
// These values are returned via the IoStatusBlock->Information parameter
//

#define JOB_OBJECT_MSG_END_OF_JOB_TIME          1
#define JOB_OBJECT_MSG_END_OF_PROCESS_TIME      2
#define JOB_OBJECT_MSG_ACTIVE_PROCESS_LIMIT     3
#define JOB_OBJECT_MSG_ACTIVE_PROCESS_ZERO      4
#define JOB_OBJECT_MSG_NEW_PROCESS              6
#define JOB_OBJECT_MSG_EXIT_PROCESS             7
#define JOB_OBJECT_MSG_ABNORMAL_EXIT_PROCESS    8
#define JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT     9
#define JOB_OBJECT_MSG_JOB_MEMORY_LIMIT         10


//
// Basic Limits
//
#define JOB_OBJECT_LIMIT_WORKINGSET                 0x00000001
#define JOB_OBJECT_LIMIT_PROCESS_TIME               0x00000002
#define JOB_OBJECT_LIMIT_JOB_TIME                   0x00000004
#define JOB_OBJECT_LIMIT_ACTIVE_PROCESS             0x00000008
#define JOB_OBJECT_LIMIT_AFFINITY                   0x00000010
#define JOB_OBJECT_LIMIT_PRIORITY_CLASS             0x00000020
#define JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME          0x00000040
#define JOB_OBJECT_LIMIT_SCHEDULING_CLASS           0x00000080

//
// Extended Limits
//
#define JOB_OBJECT_LIMIT_PROCESS_MEMORY             0x00000100
#define JOB_OBJECT_LIMIT_JOB_MEMORY                 0x00000200
#define JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION 0x00000400
#define JOB_OBJECT_LIMIT_BREAKAWAY_OK               0x00000800
#define JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK        0x00001000
#define JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE          0x00002000

#define JOB_OBJECT_LIMIT_RESERVED2                  0x00004000
#define JOB_OBJECT_LIMIT_RESERVED3                  0x00008000
#define JOB_OBJECT_LIMIT_RESERVED4                  0x00010000
#define JOB_OBJECT_LIMIT_RESERVED5                  0x00020000
#define JOB_OBJECT_LIMIT_RESERVED6                  0x00040000


#define JOB_OBJECT_LIMIT_VALID_FLAGS            0x0007ffff

#define JOB_OBJECT_BASIC_LIMIT_VALID_FLAGS      0x000000ff
#define JOB_OBJECT_EXTENDED_LIMIT_VALID_FLAGS   0x00003fff
#define JOB_OBJECT_RESERVED_LIMIT_VALID_FLAGS   0x0007ffff

//
// UI restrictions for jobs
//

#define JOB_OBJECT_UILIMIT_NONE             0x00000000

#define JOB_OBJECT_UILIMIT_HANDLES          0x00000001
#define JOB_OBJECT_UILIMIT_READCLIPBOARD    0x00000002
#define JOB_OBJECT_UILIMIT_WRITECLIPBOARD   0x00000004
#define JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS 0x00000008
#define JOB_OBJECT_UILIMIT_DISPLAYSETTINGS  0x00000010
#define JOB_OBJECT_UILIMIT_GLOBALATOMS      0x00000020
#define JOB_OBJECT_UILIMIT_DESKTOP          0x00000040
#define JOB_OBJECT_UILIMIT_EXITWINDOWS      0x00000080

#define JOB_OBJECT_UILIMIT_ALL              0x000000FF

#define JOB_OBJECT_UI_VALID_FLAGS           0x000000FF

#define JOB_OBJECT_SECURITY_NO_ADMIN            0x00000001
#define JOB_OBJECT_SECURITY_RESTRICTED_TOKEN    0x00000002
#define JOB_OBJECT_SECURITY_ONLY_TOKEN          0x00000004
#define JOB_OBJECT_SECURITY_FILTER_TOKENS       0x00000008

#define JOB_OBJECT_SECURITY_VALID_FLAGS         0x0000000f

//
// Memory Protection / Section Flags
// 

#define PAGE_NOACCESS          0x01     
#define PAGE_READONLY          0x02     
#define PAGE_READWRITE         0x04     
#define PAGE_WRITECOPY         0x08     
#define PAGE_EXECUTE           0x10     
#define PAGE_EXECUTE_READ      0x20     
#define PAGE_EXECUTE_READWRITE 0x40     
#define PAGE_EXECUTE_WRITECOPY 0x80     
#define PAGE_GUARD            0x100     
#define PAGE_NOCACHE          0x200     
#define PAGE_WRITECOMBINE     0x400     
#define MEM_COMMIT           0x1000     
#define MEM_RESERVE          0x2000     
#define MEM_DECOMMIT         0x4000     
#define MEM_RELEASE          0x8000     
#define MEM_FREE            0x10000     
#define MEM_PRIVATE         0x20000     
#define MEM_MAPPED          0x40000     
#define MEM_RESET           0x80000     
#define MEM_TOP_DOWN       0x100000     
#define MEM_WRITE_WATCH    0x200000     
#define MEM_PHYSICAL       0x400000     
#define MEM_4MB_PAGES    0x80000000     
#define SEC_FILE           0x800000     
#define SEC_IMAGE         0x1000000     
#define SEC_RESERVE       0x4000000     
#define SEC_COMMIT        0x8000000     
#define SEC_NOCACHE      0x10000000     
#define MEM_IMAGE         SEC_IMAGE     
#define WRITE_WATCH_FLAG_RESET 0x01   

#endif



#if _WIN32_WINNT >= 0x0501

// NtApphelpCacheControl control classes

typedef enum _APPHELPCACHECONTROL {
	ApphelpCheckCached,	// PUNICODE_STRING
	ApphelpAddToCache,	// PUNICODE_STRING
	ApphelpFlushCache,	// 0
	ApphelpDumpCache	// 0
} APPHELPCACHECONTROL, * PAPPHELPCACHECONTROL;

#if !defined(_NTTYPES_NO_WINNT) || defined(__IDA__)

typedef struct _JOB_SET_ARRAY {
	HANDLE JobHandle;   // Handle to job object to insert.  JOB_OBJECT_QUERY is required.
	DWORD MemberLevel;  // Level of this job in the set. Must be > 0. Can be sparse.
	DWORD Flags;        // Unused. Must be zero
} JOB_SET_ARRAY, *PJOB_SET_ARRAY;

#endif

#endif


//
// Debug object flags
//

#if _WIN32_WINNT >= 0x0501

typedef enum _DEBUGOBJECTINFOCLASS {
	DebugObjectUnusedInformation,
	DebugObjectKillProcessOnExitInformation
} DEBUGOBJECTINFOCLASS, * PDEBUGOBJECTINFOCLASS;

typedef struct _DEBUG_OBJECT_KILL_PROCESS_ON_EXIT_INFORMATION {
	ULONG KillProcessOnExit;		// Interpreted as a BOOLEAN, TRUE -> process is terminated on NtRemoveProcessDebug.
} DEBUG_OBJECT_KILL_PROCESS_ON_EXIT_INFORMATION, * PDEBUG_OBJECT_KILL_PROCESS_ON_EXIT_INFORMATION;

#endif


//
// Nt Product Type
//

#ifndef _NTTYPES_NO_NTDEF

typedef enum _NT_PRODUCT_TYPE {
	NtProductWinNt = 1,
	NtProductLanManNt,
	NtProductServer
} NT_PRODUCT_TYPE, *PNT_PRODUCT_TYPE;


typedef enum _SUITE_TYPE {
	SmallBusiness,
	Enterprise,
	BackOffice,
	CommunicationServer,
	TerminalServer,
	SmallBusinessRestricted,
	EmbeddedNT,
	DataCenter,
	SingleUserTS,
	Personal,
	Blade,
	EmbeddedRestricted,
	SecurityAppliance,
	MaxSuiteType
} SUITE_TYPE;

#endif

#if !defined(_NTTYPES_NO_NTDEF) && !defined(_NTTYPES_NO_WINNT)

#define VER_SERVER_NT                       0x80000000
#define VER_WORKSTATION_NT                  0x40000000
#define VER_SUITE_SMALLBUSINESS             0x00000001
#define VER_SUITE_ENTERPRISE                0x00000002
#define VER_SUITE_BACKOFFICE                0x00000004
#define VER_SUITE_COMMUNICATIONS            0x00000008
#define VER_SUITE_TERMINAL                  0x00000010
#define VER_SUITE_SMALLBUSINESS_RESTRICTED  0x00000020
#define VER_SUITE_EMBEDDEDNT                0x00000040
#define VER_SUITE_DATACENTER                0x00000080
#define VER_SUITE_SINGLEUSERTS              0x00000100
#define VER_SUITE_PERSONAL                  0x00000200
#define VER_SUITE_BLADE                     0x00000400
#define VER_SUITE_EMBEDDED_RESTRICTED       0x00000800
#define VER_SUITE_SECURITY_APPLIANCE        0x00001000



#define LANG_NEUTRAL                     0x00
#define LANG_INVARIANT                   0x7f

#define LANG_AFRIKAANS                   0x36
#define LANG_ALBANIAN                    0x1c
#define LANG_ARABIC                      0x01
#define LANG_ARMENIAN                    0x2b
#define LANG_ASSAMESE                    0x4d
#define LANG_AZERI                       0x2c
#define LANG_BASQUE                      0x2d
#define LANG_BELARUSIAN                  0x23
#define LANG_BENGALI                     0x45
#define LANG_BULGARIAN                   0x02
#define LANG_CATALAN                     0x03
#define LANG_CHINESE                     0x04
#define LANG_CROATIAN                    0x1a
#define LANG_CZECH                       0x05
#define LANG_DANISH                      0x06
#define LANG_DIVEHI                      0x65
#define LANG_DUTCH                       0x13
#define LANG_ENGLISH                     0x09
#define LANG_ESTONIAN                    0x25
#define LANG_FAEROESE                    0x38
#define LANG_FARSI                       0x29
#define LANG_FINNISH                     0x0b
#define LANG_FRENCH                      0x0c
#define LANG_GALICIAN                    0x56
#define LANG_GEORGIAN                    0x37
#define LANG_GERMAN                      0x07
#define LANG_GREEK                       0x08
#define LANG_GUJARATI                    0x47
#define LANG_HEBREW                      0x0d
#define LANG_HINDI                       0x39
#define LANG_HUNGARIAN                   0x0e
#define LANG_ICELANDIC                   0x0f
#define LANG_INDONESIAN                  0x21
#define LANG_ITALIAN                     0x10
#define LANG_JAPANESE                    0x11
#define LANG_KANNADA                     0x4b
#define LANG_KASHMIRI                    0x60
#define LANG_KAZAK                       0x3f
#define LANG_KONKANI                     0x57
#define LANG_KOREAN                      0x12
#define LANG_KYRGYZ                      0x40
#define LANG_LATVIAN                     0x26
#define LANG_LITHUANIAN                  0x27
#define LANG_MACEDONIAN                  0x2f   // the Former Yugoslav Republic of Macedonia
#define LANG_MALAY                       0x3e
#define LANG_MALAYALAM                   0x4c
#define LANG_MANIPURI                    0x58
#define LANG_MARATHI                     0x4e
#define LANG_MONGOLIAN                   0x50
#define LANG_NEPALI                      0x61
#define LANG_NORWEGIAN                   0x14
#define LANG_ORIYA                       0x48
#define LANG_POLISH                      0x15
#define LANG_PORTUGUESE                  0x16
#define LANG_PUNJABI                     0x46
#define LANG_ROMANIAN                    0x18
#define LANG_RUSSIAN                     0x19
#define LANG_SANSKRIT                    0x4f
#define LANG_SERBIAN                     0x1a
#define LANG_SINDHI                      0x59
#define LANG_SLOVAK                      0x1b
#define LANG_SLOVENIAN                   0x24
#define LANG_SPANISH                     0x0a
#define LANG_SWAHILI                     0x41
#define LANG_SWEDISH                     0x1d
#define LANG_SYRIAC                      0x5a
#define LANG_TAMIL                       0x49
#define LANG_TATAR                       0x44
#define LANG_TELUGU                      0x4a
#define LANG_THAI                        0x1e
#define LANG_TURKISH                     0x1f
#define LANG_UKRAINIAN                   0x22
#define LANG_URDU                        0x20
#define LANG_UZBEK                       0x43
#define LANG_VIETNAMESE                  0x2a

#define SUBLANG_NEUTRAL                  0x00    // language neutral
#define SUBLANG_DEFAULT                  0x01    // user default
#define SUBLANG_SYS_DEFAULT              0x02    // system default

#define SUBLANG_ARABIC_SAUDI_ARABIA      0x01    // Arabic (Saudi Arabia)
#define SUBLANG_ARABIC_IRAQ              0x02    // Arabic (Iraq)
#define SUBLANG_ARABIC_EGYPT             0x03    // Arabic (Egypt)
#define SUBLANG_ARABIC_LIBYA             0x04    // Arabic (Libya)
#define SUBLANG_ARABIC_ALGERIA           0x05    // Arabic (Algeria)
#define SUBLANG_ARABIC_MOROCCO           0x06    // Arabic (Morocco)
#define SUBLANG_ARABIC_TUNISIA           0x07    // Arabic (Tunisia)
#define SUBLANG_ARABIC_OMAN              0x08    // Arabic (Oman)
#define SUBLANG_ARABIC_YEMEN             0x09    // Arabic (Yemen)
#define SUBLANG_ARABIC_SYRIA             0x0a    // Arabic (Syria)
#define SUBLANG_ARABIC_JORDAN            0x0b    // Arabic (Jordan)
#define SUBLANG_ARABIC_LEBANON           0x0c    // Arabic (Lebanon)
#define SUBLANG_ARABIC_KUWAIT            0x0d    // Arabic (Kuwait)
#define SUBLANG_ARABIC_UAE               0x0e    // Arabic (U.A.E)
#define SUBLANG_ARABIC_BAHRAIN           0x0f    // Arabic (Bahrain)
#define SUBLANG_ARABIC_QATAR             0x10    // Arabic (Qatar)
#define SUBLANG_AZERI_LATIN              0x01    // Azeri (Latin)
#define SUBLANG_AZERI_CYRILLIC           0x02    // Azeri (Cyrillic)
#define SUBLANG_CHINESE_TRADITIONAL      0x01    // Chinese (Taiwan)
#define SUBLANG_CHINESE_SIMPLIFIED       0x02    // Chinese (PR China)
#define SUBLANG_CHINESE_HONGKONG         0x03    // Chinese (Hong Kong S.A.R., P.R.C.)
#define SUBLANG_CHINESE_SINGAPORE        0x04    // Chinese (Singapore)
#define SUBLANG_CHINESE_MACAU            0x05    // Chinese (Macau S.A.R.)
#define SUBLANG_DUTCH                    0x01    // Dutch
#define SUBLANG_DUTCH_BELGIAN            0x02    // Dutch (Belgian)
#define SUBLANG_ENGLISH_US               0x01    // English (USA)
#define SUBLANG_ENGLISH_UK               0x02    // English (UK)
#define SUBLANG_ENGLISH_AUS              0x03    // English (Australian)
#define SUBLANG_ENGLISH_CAN              0x04    // English (Canadian)
#define SUBLANG_ENGLISH_NZ               0x05    // English (New Zealand)
#define SUBLANG_ENGLISH_EIRE             0x06    // English (Irish)
#define SUBLANG_ENGLISH_SOUTH_AFRICA     0x07    // English (South Africa)
#define SUBLANG_ENGLISH_JAMAICA          0x08    // English (Jamaica)
#define SUBLANG_ENGLISH_CARIBBEAN        0x09    // English (Caribbean)
#define SUBLANG_ENGLISH_BELIZE           0x0a    // English (Belize)
#define SUBLANG_ENGLISH_TRINIDAD         0x0b    // English (Trinidad)
#define SUBLANG_ENGLISH_ZIMBABWE         0x0c    // English (Zimbabwe)
#define SUBLANG_ENGLISH_PHILIPPINES      0x0d    // English (Philippines)
#define SUBLANG_FRENCH                   0x01    // French
#define SUBLANG_FRENCH_BELGIAN           0x02    // French (Belgian)
#define SUBLANG_FRENCH_CANADIAN          0x03    // French (Canadian)
#define SUBLANG_FRENCH_SWISS             0x04    // French (Swiss)
#define SUBLANG_FRENCH_LUXEMBOURG        0x05    // French (Luxembourg)
#define SUBLANG_FRENCH_MONACO            0x06    // French (Monaco)
#define SUBLANG_GERMAN                   0x01    // German
#define SUBLANG_GERMAN_SWISS             0x02    // German (Swiss)
#define SUBLANG_GERMAN_AUSTRIAN          0x03    // German (Austrian)
#define SUBLANG_GERMAN_LUXEMBOURG        0x04    // German (Luxembourg)
#define SUBLANG_GERMAN_LIECHTENSTEIN     0x05    // German (Liechtenstein)
#define SUBLANG_ITALIAN                  0x01    // Italian
#define SUBLANG_ITALIAN_SWISS            0x02    // Italian (Swiss)
#if _WIN32_WINNT >= 0x0501
#define SUBLANG_KASHMIRI_SASIA           0x02    // Kashmiri (South Asia)
#endif
#define SUBLANG_KASHMIRI_INDIA           0x02    // For app compatibility only
#define SUBLANG_KOREAN                   0x01    // Korean (Extended Wansung)
#define SUBLANG_LITHUANIAN               0x01    // Lithuanian
#define SUBLANG_MALAY_MALAYSIA           0x01    // Malay (Malaysia)
#define SUBLANG_MALAY_BRUNEI_DARUSSALAM  0x02    // Malay (Brunei Darussalam)
#define SUBLANG_NEPALI_INDIA             0x02    // Nepali (India)
#define SUBLANG_NORWEGIAN_BOKMAL         0x01    // Norwegian (Bokmal)
#define SUBLANG_NORWEGIAN_NYNORSK        0x02    // Norwegian (Nynorsk)
#define SUBLANG_PORTUGUESE               0x02    // Portuguese
#define SUBLANG_PORTUGUESE_BRAZILIAN     0x01    // Portuguese (Brazilian)
#define SUBLANG_SERBIAN_LATIN            0x02    // Serbian (Latin)
#define SUBLANG_SERBIAN_CYRILLIC         0x03    // Serbian (Cyrillic)
#define SUBLANG_SPANISH                  0x01    // Spanish (Castilian)
#define SUBLANG_SPANISH_MEXICAN          0x02    // Spanish (Mexican)
#define SUBLANG_SPANISH_MODERN           0x03    // Spanish (Spain)
#define SUBLANG_SPANISH_GUATEMALA        0x04    // Spanish (Guatemala)
#define SUBLANG_SPANISH_COSTA_RICA       0x05    // Spanish (Costa Rica)
#define SUBLANG_SPANISH_PANAMA           0x06    // Spanish (Panama)
#define SUBLANG_SPANISH_DOMINICAN_REPUBLIC 0x07  // Spanish (Dominican Republic)
#define SUBLANG_SPANISH_VENEZUELA        0x08    // Spanish (Venezuela)
#define SUBLANG_SPANISH_COLOMBIA         0x09    // Spanish (Colombia)
#define SUBLANG_SPANISH_PERU             0x0a    // Spanish (Peru)
#define SUBLANG_SPANISH_ARGENTINA        0x0b    // Spanish (Argentina)
#define SUBLANG_SPANISH_ECUADOR          0x0c    // Spanish (Ecuador)
#define SUBLANG_SPANISH_CHILE            0x0d    // Spanish (Chile)
#define SUBLANG_SPANISH_URUGUAY          0x0e    // Spanish (Uruguay)
#define SUBLANG_SPANISH_PARAGUAY         0x0f    // Spanish (Paraguay)
#define SUBLANG_SPANISH_BOLIVIA          0x10    // Spanish (Bolivia)
#define SUBLANG_SPANISH_EL_SALVADOR      0x11    // Spanish (El Salvador)
#define SUBLANG_SPANISH_HONDURAS         0x12    // Spanish (Honduras)
#define SUBLANG_SPANISH_NICARAGUA        0x13    // Spanish (Nicaragua)
#define SUBLANG_SPANISH_PUERTO_RICO      0x14    // Spanish (Puerto Rico)
#define SUBLANG_SWEDISH                  0x01    // Swedish
#define SUBLANG_SWEDISH_FINLAND          0x02    // Swedish (Finland)
#define SUBLANG_URDU_PAKISTAN            0x01    // Urdu (Pakistan)
#define SUBLANG_URDU_INDIA               0x02    // Urdu (India)
#define SUBLANG_UZBEK_LATIN              0x01    // Uzbek (Latin)
#define SUBLANG_UZBEK_CYRILLIC           0x02    // Uzbek (Cyrillic)

#define SORT_DEFAULT                     0x0     // sorting default

#define SORT_JAPANESE_XJIS               0x0     // Japanese XJIS order
#define SORT_JAPANESE_UNICODE            0x1     // Japanese Unicode order

#define SORT_CHINESE_BIG5                0x0     // Chinese BIG5 order
#define SORT_CHINESE_PRCP                0x0     // PRC Chinese Phonetic order
#define SORT_CHINESE_UNICODE             0x1     // Chinese Unicode order
#define SORT_CHINESE_PRC                 0x2     // PRC Chinese Stroke Count order
#define SORT_CHINESE_BOPOMOFO            0x3     // Traditional Chinese Bopomofo order

#define SORT_KOREAN_KSC                  0x0     // Korean KSC order
#define SORT_KOREAN_UNICODE              0x1     // Korean Unicode order

#define SORT_GERMAN_PHONE_BOOK           0x1     // German Phone Book order

#define SORT_HUNGARIAN_DEFAULT           0x0     // Hungarian Default order
#define SORT_HUNGARIAN_TECHNICAL         0x1     // Hungarian Technical order

#define SORT_GEORGIAN_TRADITIONAL        0x0     // Georgian Traditional order
#define SORT_GEORGIAN_MODERN             0x1     // Georgian Modern order


#define MAKELANGID(p, s)       ((((USHORT)(s)) << 10) | (USHORT)(p))
#define PRIMARYLANGID(lgid)    ((USHORT)(lgid) & 0x3ff)
#define SUBLANGID(lgid)        ((USHORT)(lgid) >> 10)


#define NLS_VALID_LOCALE_MASK  0x000fffff

#define MAKELCID(lgid, srtid)  ((ULONG)((((ULONG)((USHORT)(srtid))) << 16) |  \
	((ULONG)((USHORT)(lgid)))))
#define MAKESORTLCID(lgid, srtid, ver)                                            \
	((ULONG)((MAKELCID(lgid, srtid)) |             \
	(((ULONG)((USHORT)(ver))) << 20)))
#define LANGIDFROMLCID(lcid)   ((USHORT)(lcid))
#define SORTIDFROMLCID(lcid)   ((USHORT)((((ULONG)(lcid)) >> 16) & 0xf))
#define SORTVERSIONFROMLCID(lcid)  ((USHORT)((((ULONG)(lcid)) >> 20) & 0xf))

#define LANG_SYSTEM_DEFAULT    (MAKELANGID(LANG_NEUTRAL, SUBLANG_SYS_DEFAULT))
#define LANG_USER_DEFAULT      (MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT))

#define LOCALE_SYSTEM_DEFAULT  (MAKELCID(LANG_SYSTEM_DEFAULT, SORT_DEFAULT))
#define LOCALE_USER_DEFAULT    (MAKELCID(LANG_USER_DEFAULT, SORT_DEFAULT))

#define LOCALE_NEUTRAL                                                        \
	(MAKELCID(MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), SORT_DEFAULT))

#define LOCALE_INVARIANT                                                      \
	(MAKELCID(MAKELANGID(LANG_INVARIANT, SUBLANG_NEUTRAL), SORT_DEFAULT))

#endif

//
// DbgUi types for LPC debug port messages (KM -> UM).
//
// These also apply to Nt*Debug APIs with NT 5.01, 5.02, and later.
//

typedef enum _DBG_STATE {
	DbgIdle,
	DbgReplyPending,
	DbgCreateThreadStateChange,
	DbgCreateProcessStateChange,
	DbgExitThreadStateChange,
	DbgExitProcessStateChange,
	DbgExceptionStateChange,
	DbgBreakpointStateChange,
	DbgSingleStepStateChange,
	DbgLoadDllStateChange,
	DbgUnloadDllStateChange
} DBG_STATE, *PDBG_STATE;

#ifndef DBGKM_EXCEPTION_DEFINED

#define DBGKM_EXCEPTION_DEFINED

typedef struct _DBGKM_EXCEPTION {
	EXCEPTION_RECORD ExceptionRecord;
	ULONG FirstChance;
} DBGKM_EXCEPTION, *PDBGKM_EXCEPTION;

#endif

typedef struct _DBGKM_CREATE_THREAD {
	ULONG SubSystemKey;
	PVOID StartAddress;
} DBGKM_CREATE_THREAD, *PDBGKM_CREATE_THREAD;

typedef struct _DBGKM_CREATE_PROCESS {
	ULONG SubSystemKey;
	HANDLE FileHandle;
	PVOID BaseOfImage;
	ULONG DebugInfoFileOffset;
	ULONG DebugInfoSize;
	DBGKM_CREATE_THREAD InitialThread;
} DBGKM_CREATE_PROCESS, *PDBGKM_CREATE_PROCESS;

typedef struct _DBGKM_EXIT_THREAD {
	NTSTATUS ExitStatus;
} DBGKM_EXIT_THREAD, *PDBGKM_EXIT_THREAD;

typedef struct _DBGKM_EXIT_PROCESS {
	NTSTATUS ExitStatus;
} DBGKM_EXIT_PROCESS, *PDBGKM_EXIT_PROCESS;

typedef struct _DBGKM_LOAD_DLL {
	HANDLE FileHandle;
	PVOID BaseOfDll;
	ULONG DebugInfoFileOffset;
	ULONG DebugInfoSize;
} DBGKM_LOAD_DLL, *PDBGKM_LOAD_DLL;

typedef struct _DBGKM_UNLOAD_DLL {
	PVOID BaseAddress;
} DBGKM_UNLOAD_DLL, *PDBGKM_UNLOAD_DLL;

typedef struct _DBGUI_WAIT_STATE_CHANGE {
	DBG_STATE NewState;
	CLIENT_ID AppClientId;
	union {
		struct {
			HANDLE HandleToThread;
			DBGKM_CREATE_THREAD NewThread;
		} CreateThread;
		struct {
			HANDLE HandleToProcess;
			HANDLE HandleToThread;
			DBGKM_CREATE_PROCESS NewProcess;
		} CreateProcessInfo;
		DBGKM_EXIT_THREAD ExitThread;
		DBGKM_EXIT_PROCESS ExitProcess;
		DBGKM_EXCEPTION Exception;
		DBGKM_LOAD_DLL LoadDll;
		DBGKM_UNLOAD_DLL UnloadDll;
	} StateInfo;
} DBGUI_WAIT_STATE_CHANGE, * PDBGUI_WAIT_STATE_CHANGE;


#if _WIN32_WINNT >= 0x0501 && !defined(_NTTYPES_NO_WINNT)

typedef VOID (* RTL_VERIFIER_DLL_LOAD_CALLBACK) (
    PWSTR DllName,
    PVOID DllBase,
    SIZE_T DllSize,
    PVOID Reserved
    );

typedef VOID (* RTL_VERIFIER_DLL_UNLOAD_CALLBACK) (
    PWSTR DllName,
    PVOID DllBase,
    SIZE_T DllSize,
    PVOID Reserved
    );

typedef struct _RTL_VERIFIER_THUNK_DESCRIPTOR {

    PCHAR ThunkName;
    PVOID ThunkOldAddress;
    PVOID ThunkNewAddress;

} RTL_VERIFIER_THUNK_DESCRIPTOR, *PRTL_VERIFIER_THUNK_DESCRIPTOR;

typedef struct _RTL_VERIFIER_DLL_DESCRIPTOR {

    PWCHAR DllName;
    DWORD DllFlags;
    PVOID DllAddress;
    PRTL_VERIFIER_THUNK_DESCRIPTOR DllThunks;

} RTL_VERIFIER_DLL_DESCRIPTOR, *PRTL_VERIFIER_DLL_DESCRIPTOR;

typedef struct _RTL_VERIFIER_PROVIDER_DESCRIPTOR {

    //
    // Filled by verifier provider DLL
    // 

    DWORD Length;        
    PRTL_VERIFIER_DLL_DESCRIPTOR ProviderDlls;
    RTL_VERIFIER_DLL_LOAD_CALLBACK ProviderDllLoadCallback;
    RTL_VERIFIER_DLL_UNLOAD_CALLBACK ProviderDllUnloadCallback;
    
    //
    // Filled by verifier engine
    //
        
    PWSTR VerifierImage;
    DWORD VerifierFlags;
    DWORD VerifierDebug;

} RTL_VERIFIER_PROVIDER_DESCRIPTOR, *PRTL_VERIFIER_PROVIDER_DESCRIPTOR;

//
// Application verifier standard flags
//

#define RTL_VRF_FLG_FULL_PAGE_HEAP     0x0001
#define RTL_VRF_FLG_LOCK_CHECKS        0x0002
#define RTL_VRF_FLG_HANDLE_CHECKS      0x0004
#define RTL_VRF_FLG_STACK_CHECKS       0x0008
#define RTL_VRF_FLG_APPCOMPAT_CHECKS   0x0010

//
// Application verifier standard stop codes
//

#define APPLICATION_VERIFIER_INTERNAL_ERROR               0x80000000
#define APPLICATION_VERIFIER_INTERNAL_WARNING             0x40000000
#define APPLICATION_VERIFIER_NO_BREAK                     0x20000000
#define APPLICATION_VERIFIER_RESERVED_BIT_28              0x10000000

#define APPLICATION_VERIFIER_UNKNOWN_ERROR                0x0001
#define APPLICATION_VERIFIER_ACCESS_VIOLATION             0x0002
#define APPLICATION_VERIFIER_UNSYNCHRONIZED_ACCESS        0x0003
#define APPLICATION_VERIFIER_EXTREME_SIZE_REQUEST         0x0004
#define APPLICATION_VERIFIER_BAD_HEAP_HANDLE              0x0005
#define APPLICATION_VERIFIER_SWITCHED_HEAP_HANDLE         0x0006
#define APPLICATION_VERIFIER_DOUBLE_FREE                  0x0007
#define APPLICATION_VERIFIER_CORRUPTED_HEAP_BLOCK         0x0008
#define APPLICATION_VERIFIER_DESTROY_PROCESS_HEAP         0x0009
#define APPLICATION_VERIFIER_UNEXPECTED_EXCEPTION         0x000A
#define APPLICATION_VERIFIER_STACK_OVERFLOW               0x000B

#define APPLICATION_VERIFIER_TERMINATE_THREAD_CALL        0x0100

#define APPLICATION_VERIFIER_EXIT_THREAD_OWNS_LOCK        0x0200
#define APPLICATION_VERIFIER_LOCK_IN_UNLOADED_DLL         0x0201
#define APPLICATION_VERIFIER_LOCK_IN_FREED_HEAP           0x0202
#define APPLICATION_VERIFIER_LOCK_DOUBLE_INITIALIZE       0x0203
#define APPLICATION_VERIFIER_LOCK_IN_FREED_MEMORY         0x0204
#define APPLICATION_VERIFIER_LOCK_CORRUPTED               0x0205
#define APPLICATION_VERIFIER_LOCK_INVALID_OWNER           0x0206
#define APPLICATION_VERIFIER_LOCK_INVALID_RECURSION_COUNT 0x0207
#define APPLICATION_VERIFIER_LOCK_INVALID_LOCK_COUNT      0x0208
#define APPLICATION_VERIFIER_LOCK_OVER_RELEASED           0x0209
#define APPLICATION_VERIFIER_LOCK_NOT_INITIALIZED         0x0210

#define APPLICATION_VERIFIER_INVALID_HANDLE               0x0300

#define VERIFIER_STOP(Code, Msg, P1, S1, P2, S2, P3, S3, P4, S4) {  \
        RtlApplicationVerifierStop ((Code),                         \
                                    (Msg),                          \
                                    (ULONG_PTR)(P1),(S1),           \
                                    (ULONG_PTR)(P2),(S2),           \
                                    (ULONG_PTR)(P3),(S3),           \
                                    (ULONG_PTR)(P4),(S4));          \
  }

#endif

//
// Privileges
//

#define SE_MIN_WELL_KNOWN_PRIVILEGE       (2L)
#define SE_CREATE_TOKEN_PRIVILEGE         (2L)
#define SE_ASSIGNPRIMARYTOKEN_PRIVILEGE   (3L)
#define SE_LOCK_MEMORY_PRIVILEGE          (4L)
#define SE_INCREASE_QUOTA_PRIVILEGE       (5L)

// Obsolete

//#define SE_UNSOLICITED_INPUT_PRIVILEGE    (6L)

#define SE_MACHINE_ACCOUNT_PRIVILEGE      (6L)
#define SE_TCB_PRIVILEGE                  (7L)
#define SE_SECURITY_PRIVILEGE             (8L)
#define SE_TAKE_OWNERSHIP_PRIVILEGE       (9L)
#define SE_LOAD_DRIVER_PRIVILEGE          (10L)
#define SE_SYSTEM_PROFILE_PRIVILEGE       (11L)
#define SE_SYSTEMTIME_PRIVILEGE           (12L)
#define SE_PROF_SINGLE_PROCESS_PRIVILEGE  (13L)
#define SE_INC_BASE_PRIORITY_PRIVILEGE    (14L)
#define SE_CREATE_PAGEFILE_PRIVILEGE      (15L)
#define SE_CREATE_PERMANENT_PRIVILEGE     (16L)
#define SE_BACKUP_PRIVILEGE               (17L)
#define SE_RESTORE_PRIVILEGE              (18L)
#define SE_SHUTDOWN_PRIVILEGE             (19L)
#define SE_DEBUG_PRIVILEGE                (20L)
#define SE_AUDIT_PRIVILEGE                (21L)
#define SE_SYSTEM_ENVIRONMENT_PRIVILEGE   (22L)
#define SE_CHANGE_NOTIFY_PRIVILEGE        (23L)
#define SE_REMOTE_SHUTDOWN_PRIVILEGE      (24L)
#define SE_UNDOCK_PRIVILEGE               (25L)
#define SE_SYNC_AGENT_PRIVILEGE           (26L)
#define SE_ENABLE_DELEGATION_PRIVILEGE    (27L)
#define SE_MANAGE_VOLUME_PRIVILEGE        (28L)
#define SE_IMPERSONATE_PRIVILEGE          (29L)
#define SE_CREATE_GLOBAL_PRIVILEGE        (30L)
#define SE_MAX_WELL_KNOWN_PRIVILEGE       (SE_CREATE_GLOBAL_PRIVILEGE)

//
// Kernel User Shared Data
//

#ifdef _M_IX86
#define KIP0PCRADDRESS              0xffdff000  
#define KI_USER_SHARED_DATA         0xffdf0000	/* Write access */
#define MM_SHARED_USER_DATA_VA      0x7FFE0000	/* Read only */
#elif defined(_AMD64_)
#define KI_USER_SHARED_DATA         0xfffff78000000000  /* Write access */
#define MM_SHARED_USER_DATA_VA      0x7FFE0000	        /* Read only */
#endif

#define SharedUserData  ((KUSER_SHARED_DATA * const) KI_USER_SHARED_DATA)		/* Kernel mode */
#define USER_SHARED_DATA ((KUSER_SHARED_DATA * const)MM_SHARED_USER_DATA_VA)	/* User mode */

typedef struct _KSYSTEM_TIME {
	ULONG LowPart;
	LONG High1Time;
	LONG High2Time;
} KSYSTEM_TIME, *PKSYSTEM_TIME;

typedef enum _ALTERNATIVE_ARCHITECTURE_TYPE {
	StandardDesign,                 // None == 0 == standard design
	NEC98x86,                       // NEC PC98xx series on X86
	EndAlternatives                 // past end of known alternatives
} ALTERNATIVE_ARCHITECTURE_TYPE;

#define PROCESSOR_FEATURE_MAX 64
#define MAX_WOW64_SHARED_ENTRIES 16

#define NX_SUPPORT_POLICY_ALWAYSOFF   0
#define NX_SUPPORT_POLICY_ALWAYSON    1
#define NX_SUPPORT_POLICY_OPTIN       2
#define NX_SUPPORT_POLICY_OPTOUT      3

typedef struct _KUSER_SHARED_DATA {

    //
    // Current low 32-bit of tick count and tick count multiplier.
    //
    // N.B. The tick count is updated each time the clock ticks.
    //

    ULONG TickCountLowDeprecated;
    ULONG TickCountMultiplier;

    //
    // Current 64-bit interrupt time in 100ns units.
    //

    volatile KSYSTEM_TIME InterruptTime;

    //
    // Current 64-bit system time in 100ns units.
    //

    volatile KSYSTEM_TIME SystemTime;

    //
    // Current 64-bit time zone bias.
    //

    volatile KSYSTEM_TIME TimeZoneBias;

    //
    // Support image magic number range for the host system.
    //
    // N.B. This is an inclusive range.
    //

    USHORT ImageNumberLow;
    USHORT ImageNumberHigh;

    //
    // Copy of system root in Unicode
    //

    WCHAR NtSystemRoot[ 260 ];

    //
    // Maximum stack trace depth if tracing enabled.
    //

    ULONG MaxStackTraceDepth;

    //
    // Crypto Exponent
    //

    ULONG CryptoExponent;

    //
    // TimeZoneId
    //

    ULONG TimeZoneId;

    ULONG LargePageMinimum;
    ULONG Reserved2[ 7 ];

    //
    // product type
    //

    NT_PRODUCT_TYPE NtProductType;
    BOOLEAN ProductTypeIsValid;

    //
    // NT Version. Note that each process sees a version from its PEB, but
    // if the process is running with an altered view of the system version,
    // the following two fields are used to correctly identify the version
    //

    ULONG NtMajorVersion;
    ULONG NtMinorVersion;

    //
    // Processor Feature Bits
    //

    BOOLEAN ProcessorFeatures[PROCESSOR_FEATURE_MAX];

    //
    // Reserved fields - do not use
    //
    ULONG Reserved1;
    ULONG Reserved3;

    //
    // Time slippage while in debugger
    //

    volatile ULONG TimeSlip;

    //
    // Alternative system architecture.  Example: NEC PC98xx on x86
    //

    ALTERNATIVE_ARCHITECTURE_TYPE AlternativeArchitecture;

    //
    // If the system is an evaluation unit, the following field contains the
    // date and time that the evaluation unit expires. A value of 0 indicates
    // that there is no expiration. A non-zero value is the UTC absolute time
    // that the system expires.
    //

    LARGE_INTEGER SystemExpirationDate;

    //
    // Suite Support
    //

    ULONG SuiteMask;

    //
    // TRUE if a kernel debugger is connected/enabled
    //

    BOOLEAN KdDebuggerEnabled;


    //
    // Current console session Id. Always zero on non-TS systems
    //
    volatile ULONG ActiveConsoleId;

    //
    // Force-dismounts cause handles to become invalid. Rather than
    // always probe handles, we maintain a serial number of
    // dismounts that clients can use to see if they need to probe
    // handles.
    //

    volatile ULONG DismountCount;

    //
    // This field indicates the status of the 64-bit COM+ package on the system.
    // It indicates whether the Intermediate Language (IL) COM+ images need to
    // use the 64-bit COM+ runtime or the 32-bit COM+ runtime.
    //

    ULONG ComPlusPackage;

    //
    // Time in tick count for system-wide last user input across all
    // terminal sessions. For MP performance, it is not updated all
    // the time (e.g. once a minute per session). It is used for idle
    // detection.
    //

    ULONG LastSystemRITEventTickCount;

    //
    // Number of physical pages in the system.  This can dynamically
    // change as physical memory can be added or removed from a running
    // system.
    //

    ULONG NumberOfPhysicalPages;

    //
    // True if the system was booted in safe boot mode.
    //

    BOOLEAN SafeBootMode;

    //
    // The following field is used for Heap  and  CritSec Tracing
    // The last bit is set for Critical Sec Collision tracing and
    // second Last bit is for Heap Tracing
    // Also the first 16 bits are used as counter.
    //

    ULONG TraceLogging;

    //
    // Depending on the processor, the code for fast system call
    // will differ, the following buffer is filled with the appropriate
    // code sequence and user mode code will branch through it.
    //
    // (32 bytes, using ULONGLONG for alignment).
    //
    // N.B. The following two fields are only used on 32-bit systems.
    //

    ULONGLONG   Fill0;          // alignment
    ULONGLONG   SystemCall[4];

    //
    // The 64-bit tick count.
    //

    union {
        volatile KSYSTEM_TIME TickCount;
        volatile ULONG64 TickCountQuad;
    };

	//
	// Cookie for encoding pointers system wide.
	//

	ULONG Cookie;

	//
	// Shared information for Wow64 processes.
	//

	ULONG Wow64SharedInformation[MAX_WOW64_SHARED_ENTRIES];

} KUSER_SHARED_DATA, *PKUSER_SHARED_DATA;


//
// Time
//

typedef struct _TIME_FIELDS {
	CSHORT Year;        // range [1601...]
	CSHORT Month;       // range [1..12]
	CSHORT Day;         // range [1..31]
	CSHORT Hour;        // range [0..23]
	CSHORT Minute;      // range [0..59]
	CSHORT Second;      // range [0..59]
	CSHORT Milliseconds;// range [0..999]
	CSHORT Weekday;     // range [0..6] == [Sunday..Saturday]
} TIME_FIELDS;
typedef TIME_FIELDS *PTIME_FIELDS;

typedef struct _RTL_TIME_ZONE_INFORMATION {
	LONG Bias;
	WCHAR StandardName[ 32 ];
	TIME_FIELDS StandardStart;
	LONG StandardBias;
	WCHAR DaylightName[ 32 ];
	TIME_FIELDS DaylightStart;
	LONG DaylightBias;
} RTL_TIME_ZONE_INFORMATION, *PRTL_TIME_ZONE_INFORMATION;


#if _WIN32_WINNT >= 0x0501

//
// Open key information for NtQueryOpenSubKeysEx
//

typedef struct _OPEN_SUB_KEY {
	HANDLE UniqueProcess;
	UNICODE_STRING KeyName;
} OPEN_SUB_KEY, * POPEN_SUB_KEY;

typedef struct _OPEN_SUB_KEY_INFORMATION {
	ULONG OpenSubKeys;
	OPEN_SUB_KEY Keys[ANYSIZE_ARRAY];
} OPEN_SUB_KEY_INFORMATION, * POPEN_SUB_KEY_INFORMATION;

#endif



#if _WIN32_WINNT >= 0x0501

//
// Wmi Trace API definitions
//

//
// predefined generic event types (0x00 to 0x09 reserved).
//

#define EVENT_TRACE_TYPE_INFO               0x00  // Info or point event
#define EVENT_TRACE_TYPE_START              0x01  // Start event
#define EVENT_TRACE_TYPE_END                0x02  // End event
#define EVENT_TRACE_TYPE_DC_START           0x03  // Collection start marker
#define EVENT_TRACE_TYPE_DC_END             0x04  // Collection end marker
#define EVENT_TRACE_TYPE_EXTENSION          0x05  // Extension/continuation
#define EVENT_TRACE_TYPE_REPLY              0x06  // Reply event
#define EVENT_TRACE_TYPE_DEQUEUE            0x07  // De-queue event
#define EVENT_TRACE_TYPE_CHECKPOINT         0x08  // Generic checkpoint event
#define EVENT_TRACE_TYPE_RESERVED9          0x09

//
// Event types for Process & Threads
//

#define EVENT_TRACE_TYPE_LOAD                  0x0A      // Load image

//
// Event types for IO subsystem
//

#define EVENT_TRACE_TYPE_IO_READ               0x0A
#define EVENT_TRACE_TYPE_IO_WRITE              0x0B

//
// Event types for Memory subsystem
//

#define EVENT_TRACE_TYPE_MM_TF                 0x0A      // Transition fault
#define EVENT_TRACE_TYPE_MM_DZF                0x0B      // Demand Zero fault
#define EVENT_TRACE_TYPE_MM_COW                0x0C      // Copy on Write
#define EVENT_TRACE_TYPE_MM_GPF                0x0D      // Guard Page fault
#define EVENT_TRACE_TYPE_MM_HPF                0x0E      // Hard page fault

//
// Event types for Network subsystem, all protocols
//

#define EVENT_TRACE_TYPE_SEND                  0x0A     // Send
#define EVENT_TRACE_TYPE_RECEIVE               0x0B     // Receive
#define EVENT_TRACE_TYPE_CONNECT               0x0C     // Connect
#define EVENT_TRACE_TYPE_DISCONNECT            0x0D     // Disconnect
#define EVENT_TRACE_TYPE_RETRANSMIT            0x0E     // ReTransmit
#define EVENT_TRACE_TYPE_ACCEPT                0x0F     // Accept
#define EVENT_TRACE_TYPE_RECONNECT             0x10     // ReConnect

//
// Event Types for the Header (to handle internal event headers)
//

#define EVENT_TRACE_TYPE_GUIDMAP                0x0A
#define EVENT_TRACE_TYPE_CONFIG                 0x0B
#define EVENT_TRACE_TYPE_SIDINFO                0x0C
#define EVENT_TRACE_TYPE_SECURITY               0x0D

//
// Event types for Registry subsystem
//

#define EVENT_TRACE_TYPE_REGCREATE              0x0A     // NtCreateKey
#define EVENT_TRACE_TYPE_REGOPEN                0x0B     // NtOpenKey
#define EVENT_TRACE_TYPE_REGDELETE              0x0C     // NtDeleteKey
#define EVENT_TRACE_TYPE_REGQUERY               0x0D     // NtQueryKey
#define EVENT_TRACE_TYPE_REGSETVALUE            0x0E     // NtSetValueKey
#define EVENT_TRACE_TYPE_REGDELETEVALUE         0x0F     // NtDeleteValueKey
#define EVENT_TRACE_TYPE_REGQUERYVALUE          0x10     // NtQueryValueKey
#define EVENT_TRACE_TYPE_REGENUMERATEKEY        0x11     // NtEnumerateKey
#define EVENT_TRACE_TYPE_REGENUMERATEVALUEKEY   0x12     // NtEnumerateValueKey
#define EVENT_TRACE_TYPE_REGQUERYMULTIPLEVALUE  0x13     // NtQueryMultipleValueKey
#define EVENT_TRACE_TYPE_REGSETINFORMATION      0x14     // NtSetInformationKey
#define EVENT_TRACE_TYPE_REGFLUSH               0x15     // NtFlushKey
#define EVENT_TRACE_TYPE_REGKCBDMP              0x16     // KcbDump/create

//
// Enable flags for SystemControlGuid only
//
#define EVENT_TRACE_FLAG_PROCESS            0x00000001  // process start & end
#define EVENT_TRACE_FLAG_THREAD             0x00000002  // thread start & end
#define EVENT_TRACE_FLAG_IMAGE_LOAD         0x00000004  // image load

#define EVENT_TRACE_FLAG_DISK_IO            0x00000100  // physical disk IO
#define EVENT_TRACE_FLAG_DISK_FILE_IO       0x00000200  // requires disk IO

#define EVENT_TRACE_FLAG_MEMORY_PAGE_FAULTS 0x00001000  // all page faults
#define EVENT_TRACE_FLAG_MEMORY_HARD_FAULTS 0x00002000  // hard faults only

#define EVENT_TRACE_FLAG_NETWORK_TCPIP      0x00010000  // tcpip send & receive

#define EVENT_TRACE_FLAG_REGISTRY           0x00020000  // registry calls
#define EVENT_TRACE_FLAG_DBGPRINT           0x00040000  // DbgPrint(ex) Calls


//
// Pre-defined Enable flags for everybody else
//

#define EVENT_TRACE_FLAG_EXTENSION          0x80000000  // indicates more flags
#define EVENT_TRACE_FLAG_FORWARD_WMI        0x40000000  // Can forward to WMI
#define EVENT_TRACE_FLAG_ENABLE_RESERVE     0x20000000  // Reserved

//
// Logger Mode flags
//

#define EVENT_TRACE_FILE_MODE_NONE          0x00000000  // logfile is off
#define EVENT_TRACE_FILE_MODE_SEQUENTIAL    0x00000001  // log sequentially
#define EVENT_TRACE_FILE_MODE_CIRCULAR      0x00000002  // log in circular manner
#define EVENT_TRACE_FILE_MODE_APPEND        0x00000004  // append sequential log
#define EVENT_TRACE_FILE_MODE_NEWFILE       0x00000008  // auto-switch log file

#define EVENT_TRACE_FILE_MODE_PREALLOCATE   0x00000020  // pre-allocate mode

#define EVENT_TRACE_REAL_TIME_MODE          0x00000100  // real time mode on
#define EVENT_TRACE_DELAY_OPEN_FILE_MODE    0x00000200  // delay opening file
#define EVENT_TRACE_BUFFERING_MODE          0x00000400  // buffering mode only
#define EVENT_TRACE_PRIVATE_LOGGER_MODE     0x00000800  // Process Private Logger
#define EVENT_TRACE_ADD_HEADER_MODE         0x00001000  // Add a logfile header
#define EVENT_TRACE_USE_GLOBAL_SEQUENCE     0x00004000  // Use global sequence no.
#define EVENT_TRACE_USE_LOCAL_SEQUENCE      0x00008000  // Use local sequence no.

#define EVENT_TRACE_RELOG_MODE              0x00010000  // Relogger

#define EVENT_TRACE_USE_PAGED_MEMORY        0x01000000  // Use pageable buffers   

//
// internal control codes used.
//
#define EVENT_TRACE_CONTROL_QUERY           0
#define EVENT_TRACE_CONTROL_STOP            1
#define EVENT_TRACE_CONTROL_UPDATE          2
#define EVENT_TRACE_CONTROL_FLUSH           3       // Flushes all the buffers

//
// Flags used by WMI Trace Message
// Note that the order or value of these flags should NOT be changed as they are processed
// in this order.
//
#define TRACE_MESSAGE_SEQUENCE		1           // Message should include a sequence number
#define TRACE_MESSAGE_GUID			2           // Message includes a GUID
#define TRACE_MESSAGE_COMPONENTID   4           // Message has no GUID, Component ID instead
#define	TRACE_MESSAGE_TIMESTAMP		8           // Message includes a timestamp
#define TRACE_MESSAGE_PERFORMANCE_TIMESTAMP 16  // Timestamp is the Performance Counter not the system clock
#define	TRACE_MESSAGE_SYSTEMINFO	32          // Message includes system information TID,PID
#define TRACE_MESSAGE_FLAG_MASK     0xFFFF      // Only the lower 16 bits of flags are placed in the message
                                                // those above 16 bits are reserved for local processing
#define TRACE_MESSAGE_MAXIMUM_SIZE  8*1024      // the maximum size allowed for a single trace message
                                                // longer messages will return ERROR_BUFFER_OVERFLOW

// Flags to indicate to consumer which fields
// in the EVENT_TRACE_HEADER are valid
//

#define EVENT_TRACE_USE_PROCTIME   0x0001    // ProcessorTime field is valid
#define EVENT_TRACE_USE_NOCPUTIME  0x0002    // No Kernel/User/Processor Times

#if _MSC_VER >= 1200
#pragma warning(push)
#endif
#pragma warning (disable:4201)
//
// Trace header for all (except kernel) events. This is used to overlay
// to bottom part of WNODE_HEADER to conserve space.
//

typedef struct _EVENT_TRACE_HEADER {        // overlays WNODE_HEADER
    USHORT          Size;                   // Size of entire record
    union {
        USHORT      FieldTypeFlags;         // Indicates valid fields
        struct {
            UCHAR   HeaderType;             // Header type - internal use only
            UCHAR   MarkerFlags;            // Marker - internal use only
        };
    };
    union {
        ULONG       Version;
        struct {
            UCHAR   Type;                   // event type
            UCHAR   Level;                  // trace instrumentation level
            USHORT  Version;                // version of trace record
        } Class;
    };
    ULONG           ThreadId;               // Thread Id
    ULONG           ProcessId;              // Process Id
    LARGE_INTEGER   TimeStamp;              // time when event happens
    union {
        GUID        Guid;                   // Guid that identifies event
        ULONGLONG   GuidPtr;                // use with WNODE_FLAG_USE_GUID_PTR
    };
    union {
        struct {
            ULONG   ClientContext;          // Reserved
            ULONG   Flags;                  // Flags for header
        };
        struct {
            ULONG   KernelTime;             // Kernel Mode CPU ticks
            ULONG   UserTime;               // User mode CPU ticks
        };
        ULONG64     ProcessorTime;          // Processor Clock
    };
} EVENT_TRACE_HEADER, *PEVENT_TRACE_HEADER;

//
// This header is used to trace and track transaction co-relations
//
typedef struct _EVENT_INSTANCE_HEADER {
    USHORT          Size;
    union {
        USHORT      FieldTypeFlags;     // Indicates valid fields
        struct {
            UCHAR   HeaderType;         // Header type - internal use only
            UCHAR   MarkerFlags;        // Marker - internal use only
        };
    };
    union {
        ULONG       Version;
        struct {
            UCHAR   Type;
            UCHAR   Level;
            USHORT  Version;
        } Class;
    };
    ULONG           ThreadId;
    ULONG           ProcessId;
    LARGE_INTEGER   TimeStamp;
    ULONGLONG       RegHandle;
    ULONG           InstanceId;
    ULONG           ParentInstanceId;
    union {
        struct {
            ULONG   ClientContext;          // Reserved
            ULONG   Flags;                  // Flags for header
        };
        struct {
            ULONG   KernelTime;             // Kernel Mode CPU ticks
            ULONG   UserTime;               // User mode CPU ticks
        };
        ULONG64     ProcessorTime;          // Processor Clock
    };
    ULONGLONG       ParentRegHandle;
} EVENT_INSTANCE_HEADER, *PEVENT_INSTANCE_HEADER;

//
// Following are structures and macros for use with USE_MOF_PTR
//

#define DEFINE_TRACE_MOF_FIELD(MOF, ptr, length, type) \
    (MOF)->DataPtr  = (ULONG64) ptr; \
    (MOF)->Length   = (ULONG) length; \
    (MOF)->DataType = (ULONG) type;

typedef struct _MOF_FIELD {
    ULONG64     DataPtr;    // Pointer to the field. Up to 64-bits only
    ULONG       Length;     // Length of the MOF field
    ULONG       DataType;   // Type of data
} MOF_FIELD, *PMOF_FIELD;

//
// This is the header for every logfile. The memory for LoggerName
// and LogFileName must be contiguous adjacent to this structure
// Allows both user-mode and kernel-mode to understand the header
//
typedef struct _TRACE_LOGFILE_HEADER {
    ULONG           BufferSize;         // Logger buffer size in Kbytes
    union {
        ULONG       Version;            // Logger version
        struct {
            UCHAR   MajorVersion;
            UCHAR   MinorVersion;
            UCHAR   SubVersion;
            UCHAR   SubMinorVersion;
        } VersionDetail;
    };
    ULONG           ProviderVersion;    // defaults to NT version
    ULONG           NumberOfProcessors; // Number of Processors
    LARGE_INTEGER   EndTime;            // Time when logger stops
    ULONG           TimerResolution;    // assumes timer is constant!!!
    ULONG           MaximumFileSize;    // Maximum in Mbytes
    ULONG           LogFileMode;        // specify logfile mode
    ULONG           BuffersWritten;     // used to file start of Circular File
    union {
        GUID LogInstanceGuid;           // For RealTime Buffer Delivery
        struct {
            ULONG   StartBuffers;       // Count of buffers written at start.
            ULONG   PointerSize;        // Size of pointer type in bits
            ULONG   EventsLost;         // Events losts during log session
            ULONG   CpuSpeedInMHz;      // Cpu Speed in MHz
        };
    };
    PWCHAR          LoggerName;
    PWCHAR          LogFileName;
    RTL_TIME_ZONE_INFORMATION TimeZone;
    LARGE_INTEGER   BootTime;
    LARGE_INTEGER   PerfFreq;           // Reserved
    LARGE_INTEGER   StartTime;          // Reserved
    ULONG           ReservedFlags;      // Reserved
    ULONG           BuffersLost;
} TRACE_LOGFILE_HEADER, *PTRACE_LOGFILE_HEADER;


//
// Instance Information to track parent child relationship of Instances.
//
typedef struct EVENT_INSTANCE_INFO {
    HANDLE      RegHandle;
    ULONG       InstanceId;
} EVENT_INSTANCE_INFO, *PEVENT_INSTANCE_INFO;

typedef struct _WNODE_HEADER
{
	ULONG BufferSize;        // Size of entire buffer inclusive of this ULONG
	ULONG ProviderId;    // Provider Id of driver returning this buffer
	union
	{
		ULONG64 HistoricalContext;  // Logger use
		struct
		{
			ULONG Version;           // Reserved
			ULONG Linkage;           // Linkage field reserved for WMI
		};
	};

	union
	{
		ULONG CountLost;         // Reserved
		HANDLE KernelHandle;     // Kernel handle for data block
		LARGE_INTEGER TimeStamp; // Timestamp as returned in units of 100ns
		// since 1/1/1601
	};
	GUID Guid;                  // Guid for data block returned with results
	ULONG ClientContext;
	ULONG Flags;             // Flags, see below
} WNODE_HEADER, *PWNODE_HEADER;

#define WNODE_FLAG_ALL_DATA        0x00000001 // set for WNODE_ALL_DATA
#define WNODE_FLAG_SINGLE_INSTANCE 0x00000002 // set for WNODE_SINGLE_INSTANCE
#define WNODE_FLAG_SINGLE_ITEM     0x00000004 // set for WNODE_SINGLE_ITEM
#define WNODE_FLAG_EVENT_ITEM      0x00000008 // set for WNODE_EVENT_ITEM

// Set if data block size is
// identical for all instances
// (used with  WNODE_ALL_DATA
// only)
#define WNODE_FLAG_FIXED_INSTANCE_SIZE 0x00000010

#define WNODE_FLAG_TOO_SMALL           0x00000020 // set for WNODE_TOO_SMALL

// Set when a data provider returns a
// WNODE_ALL_DATA in which the number of
// instances and their names returned
// are identical to those returned from the
// previous WNODE_ALL_DATA query. Only data
// blocks registered with dynamic instance
// names should use this flag.
#define WNODE_FLAG_INSTANCES_SAME  0x00000040

// Instance names are not specified in
// WNODE_ALL_DATA; values specified at
// registration are used instead. Always
// set for guids registered with static
// instance names
#define WNODE_FLAG_STATIC_INSTANCE_NAMES 0x00000080

#define WNODE_FLAG_INTERNAL      0x00000100  // Used internally by WMI

// timestamp should not be modified by
// a historical logger
#define WNODE_FLAG_USE_TIMESTAMP 0x00000200
#define WNODE_FLAG_PERSIST_EVENT 0x00000400

#define WNODE_FLAG_EVENT_REFERENCE 0x00002000

// Set if Instance names are ansi. Only set when returning from
// WMIQuerySingleInstanceA and WMIQueryAllDataA
#define WNODE_FLAG_ANSI_INSTANCENAMES 0x00004000

// Set if WNODE is a method call
#define WNODE_FLAG_METHOD_ITEM     0x00008000

// Set if instance names originated from a PDO
#define WNODE_FLAG_PDO_INSTANCE_NAMES  0x00010000

// The second byte, except the first bit is used exclusively for tracing
#define WNODE_FLAG_TRACED_GUID   0x00020000 // denotes a trace

#define WNODE_FLAG_LOG_WNODE     0x00040000 // request to log Wnode

#define WNODE_FLAG_USE_GUID_PTR  0x00080000 // Guid is actually a pointer

#define WNODE_FLAG_USE_MOF_PTR   0x00100000 // MOF data are dereferenced

#define WNODE_FLAG_NO_HEADER     0x00200000 // Trace without header

// Set for events that are WNODE_EVENT_REFERENCE
// Mask for event severity level. Level 0xff is the most severe type of event
#define WNODE_FLAG_SEVERITY_MASK 0xff000000

//
// Logger configuration and running statistics. This structure is used
// by user-mode callers, such as PDH library
//

typedef struct _EVENT_TRACE_PROPERTIES {
    WNODE_HEADER Wnode;
//
// data provided by caller
    ULONG BufferSize;                   // buffer size for logging (kbytes)
    ULONG MinimumBuffers;               // minimum to preallocate
    ULONG MaximumBuffers;               // maximum buffers allowed
    ULONG MaximumFileSize;              // maximum logfile size (in MBytes)
    ULONG LogFileMode;                  // sequential, circular
    ULONG FlushTimer;                   // buffer flush timer, in seconds
    ULONG EnableFlags;                  // trace enable flags
    LONG  AgeLimit;                     // age decay time, in minutes

// data returned to caller
    ULONG NumberOfBuffers;              // no of buffers in use
    ULONG FreeBuffers;                  // no of buffers free
    ULONG EventsLost;                   // event records lost
    ULONG BuffersWritten;               // no of buffers written to file
    ULONG LogBuffersLost;               // no of logfile write failures
    ULONG RealTimeBuffersLost;          // no of rt delivery failures
    HANDLE LoggerThreadId;              // thread id of Logger
    ULONG LogFileNameOffset;            // Offset to LogFileName
    ULONG LoggerNameOffset;             // Offset to LoggerName
} EVENT_TRACE_PROPERTIES, *PEVENT_TRACE_PROPERTIES;

// NOTE:
// If AgeLimit is 0, default is used
// If AgeLimit is < 0, buffer aging is turned off

typedef struct _TRACE_GUID_PROPERTIES {
    GUID    Guid;
    ULONG   GuidType;
    ULONG   LoggerId;
    ULONG   EnableLevel;
    ULONG   EnableFlags;
    BOOLEAN     IsEnable;
} TRACE_GUID_PROPERTIES, *PTRACE_GUID_PROPERTIES;


//
// Data Provider structures
//
// Used by RegisterTraceGuids()

typedef struct  _TRACE_GUID_REGISTRATION {
    CONST GUID *Guid;           // Guid of data block being registered or updated.
    HANDLE RegHandle;      // Guid Registration Handle is returned.
} TRACE_GUID_REGISTRATION, *PTRACE_GUID_REGISTRATION;

//
// Data consumer structures
//

// An EVENT_TRACE consists of a fixed header (EVENT_TRACE_HEADER) and
// optionally a variable portion pointed to by MofData. The datablock
// layout of the variable portion is unknown to the Logger and must
// be obtained from WBEM CIMOM database.
//
typedef struct _EVENT_TRACE {
    EVENT_TRACE_HEADER      Header;             // Event trace header
    ULONG                   InstanceId;         // Instance Id of this event
    ULONG                   ParentInstanceId;   // Parent Instance Id.
    GUID                    ParentGuid;         // Parent Guid;
    PVOID                   MofData;            // Pointer to Variable Data
    ULONG                   MofLength;          // Variable Datablock Length
    ULONG                   ClientContext;      // Reserved
} EVENT_TRACE, *PEVENT_TRACE;


#endif


#if !defined(_NTTYPES_NO_WINNT) && !defined(_NTTYPES_NO_NTDEF)

#endif


//
// Keyboard Layout
//

typedef struct {
	BYTE Vk;
	BYTE ModBits;
} VK_TO_BIT, * PVK_TO_BIT;

typedef struct {
	PVK_TO_BIT pVkToBit;     // Virtual Keys -> Mod bits
	WORD       wMaxModBits;  // max Modification bit combination value
	BYTE       ModNumber[ANYSIZE_ARRAY];  // Mod bits -> Modification Number
} MODIFIERS, * PMODIFIERS;

typedef struct _VSC_VK {
	BYTE Vsc;
	USHORT Vk;
} VSC_VK, * PVSC_VK;

typedef struct _VK_VSC {
	BYTE Vk;
	BYTE Vsc;
} VK_VSC, * PVK_VSC;

#define TYPEDEF_VK_TO_WCHARS(n) typedef struct _VK_TO_WCHARS##n {  \
	BYTE  VirtualKey;      \
	BYTE  Attributes;      \
	WCHAR wch[n];          \
} VK_TO_WCHARS##n, * PVK_TO_WCHARS##n;

TYPEDEF_VK_TO_WCHARS(1) // VK_TO_WCHARS1, *PVK_TO_WCHARS1;
TYPEDEF_VK_TO_WCHARS(2) // VK_TO_WCHARS2, *PVK_TO_WCHARS2;
TYPEDEF_VK_TO_WCHARS(3) // VK_TO_WCHARS3, *PVK_TO_WCHARS3;
TYPEDEF_VK_TO_WCHARS(4) // VK_TO_WCHARS4, *PVK_TO_WCHARS4;
TYPEDEF_VK_TO_WCHARS(5) // VK_TO_WCHARS5, *PVK_TO_WCHARS5;
TYPEDEF_VK_TO_WCHARS(6) // VK_TO_WCHARS6, *PVK_TO_WCHARS5;
TYPEDEF_VK_TO_WCHARS(7) // VK_TO_WCHARS7, *PVK_TO_WCHARS7;

TYPEDEF_VK_TO_WCHARS(8) // VK_TO_WCHARS8, *PVK_TO_WCHARS8;
TYPEDEF_VK_TO_WCHARS(9) // VK_TO_WCHARS9, *PVK_TO_WCHARS9;
TYPEDEF_VK_TO_WCHARS(10) // VK_TO_WCHARS10, *PVK_TO_WCHARS10;

typedef struct _VK_TO_WCHAR_TABLE {
	PVK_TO_WCHARS1 pVkToWchars;
	BYTE           nModifications;
	BYTE           cbSize;
} VK_TO_WCHAR_TABLE, * PVK_TO_WCHAR_TABLE;

typedef struct {
	DWORD  dwBoth;  // diacritic & char
	WCHAR  wchComposed;
	USHORT uFlags;
} DEADKEY, * PDEADKEY;

#define TYPEDEF_LIGATURE(n) typedef struct _LIGATURE##n {     \
	BYTE  VirtualKey;         \
	WORD  ModificationNumber; \
	WCHAR wch[n];             \
} LIGATURE##n, * PLIGATURE##n;

TYPEDEF_LIGATURE(1) // LIGATURE1, *PLIGATURE1;
TYPEDEF_LIGATURE(2) // LIGATURE2, *PLIGATURE2;
TYPEDEF_LIGATURE(3) // LIGATURE3, *PLIGATURE3;
TYPEDEF_LIGATURE(4) // LIGATURE4, *PLIGATURE4;
TYPEDEF_LIGATURE(5) // LIGATURE5, *PLIGATURE5;

typedef struct {
	BYTE   vsc;
	WCHAR * pwsz;
} VSC_LPWSTR, * PVSC_LPWSTR;

typedef WCHAR * DEADKEY_LPWSTR;

typedef struct tagKbdLayer {
	/*
	* Modifier keys
	*/
	PMODIFIERS pCharModifiers;

	/*
	* Characters
	*/
	PVK_TO_WCHAR_TABLE pVkToWcharTable;  // ptr to tbl of ptrs to tbl

	/*
	* Diacritics
	*/
	PDEADKEY pDeadKey;

	/*
	* Names of Keys
	*/
	PVSC_LPWSTR pKeyNames;
	PVSC_LPWSTR pKeyNamesExt;
	WCHAR * * pKeyNamesDead;

	/*
	* Scan codes to Virtual Keys
	*/
	USHORT  * pusVSCtoVK;
	BYTE    bMaxVSCtoVK;
	PVSC_VK pVSCtoVK_E0;  // Scancode has E0 prefix
	PVSC_VK pVSCtoVK_E1;  // Scancode has E1 prefix

	/*
	* Locale-specific special processing
	*/
	DWORD fLocaleFlags;

	/*
	* Ligatures
	*/
	BYTE       nLgMax;
	BYTE       cbLgEntry;
	PLIGATURE1 pLigature;

	/*
	* Type and subtype. These are optional.
	*/
	DWORD      dwType;     // Keyboard Type
	DWORD      dwSubType;  // Keyboard SubType: may contain OemId
} KBDTABLES, * PKBDTABLES;

typedef struct _VK_FUNCTION_PARAM {
	BYTE  NLSFEProcIndex;
	ULONG NLSFEProcParam;
} VK_FPARAM, * PVK_FPARAM;

typedef struct _VK_TO_FUNCTION_TABLE {
	BYTE Vk;
	BYTE NLSFEProcType;
	BYTE NLSFEProcCurrent;
	// Index[0] : Base
	// Index[1] : Shift
	// Index[2] : Control
	// Index[3] : Shift+Control
	// Index[4] : Alt
	// Index[5] : Shift+Alt
	// Index[6] : Control+Alt
	// Index[7] : Shift+Control+Alt
	BYTE NLSFEProcSwitch;   // 8 bits
	VK_FPARAM NLSFEProc[8];
	VK_FPARAM NLSFEProcAlt[8];
} VK_F, * PVK_F;


typedef struct tagKbdNlsLayer {
	USHORT OEMIdentifier;
	USHORT LayoutInformation;
	ULONG  NumOfVkToF;
	PVK_F pVkToF;
	LONG     NumOfMouseVKey;
	USHORT * pusMouseVKey;
} KBDNLSTABLES, * PKBDNLSTABLES;

typedef struct tagKBDTABLE_DESC {
	WCHAR wszDllName[32];
	DWORD dwType;     // Keyboard type ID
	DWORD dwSubType;  // Combined SubType ID (OEMID : SubType)
} KBDTABLE_DESC, * PKBDTABLE_DESC;

#define KBDTABLE_MULTI_MAX  (8)

typedef struct tagKBDTABLE_MULTI {
	ULONG nTables;
	KBDTABLE_DESC aKbdTables[KBDTABLE_MULTI_MAX];
} KBDTABLE_MULTI, * PKBDTABLE_MULTI;

typedef struct tagKBD_TYPE_INFO {
	DWORD dwVersion;
	DWORD dwType;
	DWORD dwSubType;
} KBD_TYPE_INFO, *PKBD_TYPE_INFO;

#define IDS_FROM_SCANCODE(prefix, base) \
	(0xc000 + ((0x ## prefix) >= 0xE0 ? 0x100 : 0) + (0x ## base))

#define KBDEXT        (USHORT)0x0100
#define KBDMULTIVK    (USHORT)0x0200
#define KBDSPECIAL    (USHORT)0x0400
#define KBDNUMPAD     (USHORT)0x0800
#define KBDUNICODE    (USHORT)0x1000
#define KBDINJECTEDVK (USHORT)0x2000
#define KBDMAPPEDVK   (USHORT)0x4000
#define KBDBREAK      (USHORT)0x8000

#define EXTENDED_BIT   0x01000000
#define DONTCARE_BIT   0x02000000
#define FAKE_KEYSTROKE 0x02000000
#define ALTNUMPAD_BIT  0x04000000

#define KBDBASE        0
#define KBDSHIFT       1
#define KBDCTRL        2
#define KBDALT         4

#define KBDKANA        8
#define KBDROYA        0x10
#define KBDLOYA        0x20
#define KBDGRPSELTAP   0x80

#define SHFT_INVALID 0x0F

#define WCH_NONE 0xF000
#define WCH_DEAD 0xF001
#define WCH_LGTR 0xF002

#define CAPLOK      0x01
#define SGCAPS      0x02
#define CAPLOKALTGR 0x04

#define KANALOK     0x08
#define GRPSELTAP   0x80


#define KBD_VERSION         1
#define GET_KBD_VERSION(p)  (HIWORD((p)->fLocaleFlags))

#define KLLF_ALTGR       0x0001
#define KLLF_SHIFTLOCK   0x0002
#define KLLF_LRM_RLM     0x0004

#define KLLF_LAYOUT_ATTRS (KLLF_SHIFTLOCK | KLLF_ALTGR | KLLF_LRM_RLM)
#define KLLF_GLOBAL_ATTRS (KLLF_SHIFTLOCK)

#define KLL_ATTR_FROM_KLF(x)         ((x) >> 15)
#define KLL_LAYOUT_ATTR_FROM_KLF(x)  (KLL_ATTR_FROM_KLF(x) & KLLF_LAYOUT_ATTRS)
#define KLL_GLOBAL_ATTR_FROM_KLF(x)  (KLL_ATTR_FROM_KLF(x) & KLLF_GLOBAL_ATTRS)


#if !defined(_NTTYPES_NO_WINNT) && !defined(_NTTYPES_NO_NTDEF)

//
// Dll Init Routine parameters
//

#define DLL_PROCESS_ATTACH   1    
#define DLL_THREAD_ATTACH    2    
#define DLL_THREAD_DETACH    3    
#define DLL_PROCESS_DETACH   0    
#define DLL_PROCESS_VERIFIER 4    

#endif

//
// Dll Init Routine types
//

typedef
BOOLEAN
(NTAPI * PDLL_INIT_ROUTINE) (
    IN PVOID DllHandle,
    IN ULONG Reason,
    IN PCONTEXT Context OPTIONAL
    );

//
// Variable argument list support (used by Dbg)
//

#ifndef _VA_LIST_DEFINED
#ifdef  _M_ALPHA
typedef struct {
	char *a0;       /* pointer to first homed integer argument */
	int offset;     /* byte offset of next parameter */
} va_list;
#else
typedef char *  va_list;
#endif
#define _VA_LIST_DEFINED
#endif

#ifdef _NTTYPES_NO_WINNT

//
// NtDuplicateObject flags.
//

#define DUPLICATE_CLOSE_SOURCE      0x00000001  // winnt
#define DUPLICATE_SAME_ACCESS       0x00000002  // winnt

#endif

#define DUPLICATE_SAME_ATTRIBUTES   0x00000004  // ntddk

//
// Priority
//

#define LOW_PRIORITY 0              // Lowest thread priority level
#define LOW_REALTIME_PRIORITY 16    // Lowest realtime priority level
#define HIGH_PRIORITY 31            // Highest thread priority level
#define MAXIMUM_PRIORITY 32         // Number of thread priority levels

//
// RtlCreateAndSetSD parameter type
//

typedef struct _RTL_ACE_DATA {
	UCHAR AceType;
	UCHAR InheritFlags;
	UCHAR AceFlags;
	ACCESS_MASK Mask;
	PSID *Sid;
} RTL_ACE_DATA, *PRTL_ACE_DATA;

#ifndef _NTTYPES_NO_WINNT

#define HEAP_NO_SERIALIZE               0x00000001      // winnt
#define HEAP_GROWABLE                   0x00000002      // winnt
#define HEAP_GENERATE_EXCEPTIONS        0x00000004      // winnt
#define HEAP_ZERO_MEMORY                0x00000008      // winnt
#define HEAP_REALLOC_IN_PLACE_ONLY      0x00000010      // winnt
#define HEAP_TAIL_CHECKING_ENABLED      0x00000020      // winnt
#define HEAP_FREE_CHECKING_ENABLED      0x00000040      // winnt
#define HEAP_DISABLE_COALESCE_ON_FREE   0x00000080      // winnt

#endif

#define HEAP_CREATE_ALIGN_16            0x00010000      // winnt Create heap with 16 byte alignment (obsolete)
#define HEAP_CREATE_ENABLE_TRACING      0x00020000      // winnt Create heap call tracing enabled (obsolete)

#define HEAP_SETTABLE_USER_VALUE        0x00000100
#define HEAP_SETTABLE_USER_FLAG1        0x00000200
#define HEAP_SETTABLE_USER_FLAG2        0x00000400
#define HEAP_SETTABLE_USER_FLAG3        0x00000800
#define HEAP_SETTABLE_USER_FLAGS        0x00000E00

#define HEAP_CLASS_0                    0x00000000      // process heap
#define HEAP_CLASS_1                    0x00001000      // private heap
#define HEAP_CLASS_2                    0x00002000      // Kernel Heap
#define HEAP_CLASS_3                    0x00003000      // GDI heap
#define HEAP_CLASS_4                    0x00004000      // User heap
#define HEAP_CLASS_5                    0x00005000      // Console heap
#define HEAP_CLASS_6                    0x00006000      // User Desktop heap
#define HEAP_CLASS_7                    0x00007000      // Csrss Shared heap
#define HEAP_CLASS_8                    0x00008000      // Csr Port heap
#define HEAP_CLASS_MASK                 0x0000F000

#ifndef _NTTYPES_NO_WINNT

#define HEAP_MAXIMUM_TAG                0x0FFF              // winnt

#endif

#define HEAP_GLOBAL_TAG                 0x0800

#ifndef _NTTYPES_NO_WINNT

#define HEAP_PSEUDO_TAG_FLAG            0x8000              // winnt
#define HEAP_TAG_SHIFT                  18                  // winnt
#define HEAP_MAKE_TAG_FLAGS( b, o ) ((ULONG)((b) + ((o) << 18)))  // winnt

#endif

#define HEAP_TAG_MASK                  (HEAP_MAXIMUM_TAG << HEAP_TAG_SHIFT)

#define HEAP_CREATE_VALID_MASK         (HEAP_NO_SERIALIZE |             \
                                        HEAP_GROWABLE |                 \
                                        HEAP_GENERATE_EXCEPTIONS |      \
                                        HEAP_ZERO_MEMORY |              \
                                        HEAP_REALLOC_IN_PLACE_ONLY |    \
                                        HEAP_TAIL_CHECKING_ENABLED |    \
                                        HEAP_FREE_CHECKING_ENABLED |    \
                                        HEAP_DISABLE_COALESCE_ON_FREE | \
                                        HEAP_CLASS_MASK |               \
                                        HEAP_CREATE_ALIGN_16 |          \
                                        HEAP_CREATE_ENABLE_TRACING)
//};

#ifndef MAX_PATH
#define MAX_PATH 260
#endif

#ifndef _NTTYPES_NO_NTDEF

#define RTL_CONSTANT_OBJECT_ATTRIBUTES(n, a) \
	{ sizeof(OBJECT_ATTRIBUTES), NULL, RTL_CONST_CAST(PUNICODE_STRING)(n), a, NULL, NULL }
#define RTL_INIT_OBJECT_ATTRIBUTES(n, a) RTL_CONSTANT_OBJECT_ATTRIBUTES(n, a)
#define RTL_FIELD_SIZE(type, field) (sizeof(((type *)0)->field))
#define RTL_SIZEOF_THROUGH_FIELD(type, field) \
	(FIELD_OFFSET(type, field) + RTL_FIELD_SIZE(type, field))
#define RTL_CONTAINS_FIELD(Struct, Size, Field) \
	( (((PCHAR)(&(Struct)->Field)) + sizeof((Struct)->Field)) <= (((PCHAR)(Struct))+(Size)) )
#ifndef RTL_NUMBER_OF
#define RTL_NUMBER_OF(A) (sizeof(A)/sizeof((A)[0]))
#endif
#define RTL_CONSTANT_STRING(s) { sizeof( s ) - sizeof( (s)[0] ), sizeof( s ), s }
#define RTL_BITS_OF(sizeOfArg) (sizeof(sizeOfArg) * 8)
#define RTL_BITS_OF_FIELD(type, field) (RTL_BITS_OF(RTL_FIELD_TYPE(type, field)))

#endif

#ifdef _NTNATIVE_LSA_API
#ifndef _NTSECAPI_
#ifndef _NTLSA_IFS_
// begin_ntifs
//
// Used by a logon process to indicate what type of logon is being
// requested.
//

typedef enum _SECURITY_LOGON_TYPE {
	Interactive = 2,    // Interactively logged on (locally or remotely)
	Network,            // Accessing system via network
	Batch,              // Started via a batch queue
	Service,            // Service started by service controller
	Proxy,              // Proxy logon
	Unlock,             // Unlock workstation
	NetworkCleartext,   // Network logon with cleartext credentials
	NewCredentials,     // Clone caller, new default credentials
	RemoteInteractive,  // Remote, yet interactive. Terminal server
	CachedInteractive,  // Try cached credentials without hitting the net.
	CachedRemoteInteractive, // Same as RemoteInteractive, this is used internally for auditing purpose
	CachedUnlock        // Cached Unlock workstation
} SECURITY_LOGON_TYPE, *PSECURITY_LOGON_TYPE;

// end_ntifs
#endif // _NTLSA_IFS_
#endif
#endif

#ifndef _NTTYPES_NO_WINNT

typedef enum _SID_NAME_USE {
	SidTypeUser = 1,
	SidTypeGroup,
	SidTypeDomain,
	SidTypeAlias,
	SidTypeWellKnownGroup,
	SidTypeDeletedAccount,
	SidTypeInvalid,
	SidTypeUnknown,
	SidTypeComputer
} SID_NAME_USE, *PSID_NAME_USE;

typedef SID_AND_ATTRIBUTES SID_AND_ATTRIBUTES_ARRAY[ANYSIZE_ARRAY];
typedef SID_AND_ATTRIBUTES_ARRAY *PSID_AND_ATTRIBUTES_ARRAY;

#define SECURITY_NULL_SID_AUTHORITY         {0,0,0,0,0,0}
#define SECURITY_WORLD_SID_AUTHORITY        {0,0,0,0,0,1}
#define SECURITY_LOCAL_SID_AUTHORITY        {0,0,0,0,0,2}
#define SECURITY_CREATOR_SID_AUTHORITY      {0,0,0,0,0,3}
#define SECURITY_NON_UNIQUE_AUTHORITY       {0,0,0,0,0,4}
#define SECURITY_RESOURCE_MANAGER_AUTHORITY {0,0,0,0,0,9}

#define SECURITY_NULL_RID                 (0x00000000L)
#define SECURITY_WORLD_RID                (0x00000000L)
#define SECURITY_LOCAL_RID                (0x00000000L)

#define SECURITY_CREATOR_OWNER_RID        (0x00000000L)
#define SECURITY_CREATOR_GROUP_RID        (0x00000001L)

#define SECURITY_CREATOR_OWNER_SERVER_RID (0x00000002L)
#define SECURITY_CREATOR_GROUP_SERVER_RID (0x00000003L)

#define SECURITY_NT_AUTHORITY           {0,0,0,0,0,5}   // ntifs

#define SECURITY_DIALUP_RID             (0x00000001L)
#define SECURITY_NETWORK_RID            (0x00000002L)
#define SECURITY_BATCH_RID              (0x00000003L)
#define SECURITY_INTERACTIVE_RID        (0x00000004L)
#define SECURITY_LOGON_IDS_RID          (0x00000005L)
#define SECURITY_LOGON_IDS_RID_COUNT    (3L)
#define SECURITY_SERVICE_RID            (0x00000006L)
#define SECURITY_ANONYMOUS_LOGON_RID    (0x00000007L)
#define SECURITY_PROXY_RID              (0x00000008L)
#define SECURITY_ENTERPRISE_CONTROLLERS_RID (0x00000009L)
#define SECURITY_SERVER_LOGON_RID       SECURITY_ENTERPRISE_CONTROLLERS_RID
#define SECURITY_PRINCIPAL_SELF_RID     (0x0000000AL)
#define SECURITY_AUTHENTICATED_USER_RID (0x0000000BL)
#define SECURITY_RESTRICTED_CODE_RID    (0x0000000CL)
#define SECURITY_TERMINAL_SERVER_RID    (0x0000000DL)
#define SECURITY_REMOTE_LOGON_RID       (0x0000000EL)
#define SECURITY_THIS_ORGANIZATION_RID  (0x0000000FL)

#define SECURITY_LOCAL_SYSTEM_RID       (0x00000012L)
#define SECURITY_LOCAL_SERVICE_RID      (0x00000013L)
#define SECURITY_NETWORK_SERVICE_RID    (0x00000014L)

#define SECURITY_NT_NON_UNIQUE          (0x00000015L)
#define SECURITY_NT_NON_UNIQUE_SUB_AUTH_COUNT  (3L)

#define SECURITY_BUILTIN_DOMAIN_RID     (0x00000020L)

#define SECURITY_PACKAGE_BASE_RID       (0x00000040L)
#define SECURITY_PACKAGE_RID_COUNT      (2L)
#define SECURITY_PACKAGE_NTLM_RID       (0x0000000AL)
#define SECURITY_PACKAGE_SCHANNEL_RID   (0x0000000EL)
#define SECURITY_PACKAGE_DIGEST_RID     (0x00000015L)

#define SECURITY_MAX_ALWAYS_FILTERED    (0x000003E7L)
#define SECURITY_MIN_NEVER_FILTERED     (0x000003E8L)

#define SECURITY_OTHER_ORGANIZATION_RID (0x000003E8L)

#define FOREST_USER_RID_MAX            (0x000001F3L)

#define DOMAIN_USER_RID_ADMIN          (0x000001F4L)
#define DOMAIN_USER_RID_GUEST          (0x000001F5L)
#define DOMAIN_USER_RID_KRBTGT         (0x000001F6L)

#define DOMAIN_USER_RID_MAX            (0x000003E7L)


// well-known groups ...

#define DOMAIN_GROUP_RID_ADMINS        (0x00000200L)
#define DOMAIN_GROUP_RID_USERS         (0x00000201L)
#define DOMAIN_GROUP_RID_GUESTS        (0x00000202L)
#define DOMAIN_GROUP_RID_COMPUTERS     (0x00000203L)
#define DOMAIN_GROUP_RID_CONTROLLERS   (0x00000204L)
#define DOMAIN_GROUP_RID_CERT_ADMINS   (0x00000205L)
#define DOMAIN_GROUP_RID_SCHEMA_ADMINS (0x00000206L)
#define DOMAIN_GROUP_RID_ENTERPRISE_ADMINS (0x00000207L)
#define DOMAIN_GROUP_RID_POLICY_ADMINS (0x00000208L)




// well-known aliases ...

#define DOMAIN_ALIAS_RID_ADMINS        (0x00000220L)
#define DOMAIN_ALIAS_RID_USERS         (0x00000221L)
#define DOMAIN_ALIAS_RID_GUESTS        (0x00000222L)
#define DOMAIN_ALIAS_RID_POWER_USERS   (0x00000223L)

#define DOMAIN_ALIAS_RID_ACCOUNT_OPS   (0x00000224L)
#define DOMAIN_ALIAS_RID_SYSTEM_OPS    (0x00000225L)
#define DOMAIN_ALIAS_RID_PRINT_OPS     (0x00000226L)
#define DOMAIN_ALIAS_RID_BACKUP_OPS    (0x00000227L)

#define DOMAIN_ALIAS_RID_REPLICATOR    (0x00000228L)
#define DOMAIN_ALIAS_RID_RAS_SERVERS   (0x00000229L)
#define DOMAIN_ALIAS_RID_PREW2KCOMPACCESS (0x0000022AL)
#define DOMAIN_ALIAS_RID_REMOTE_DESKTOP_USERS (0x0000022BL)
#define DOMAIN_ALIAS_RID_NETWORK_CONFIGURATION_OPS (0x0000022CL)
#define DOMAIN_ALIAS_RID_INCOMING_FOREST_TRUST_BUILDERS (0x0000022DL)

#define DOMAIN_ALIAS_RID_MONITORING_USERS       (0x0000022EL)
#define DOMAIN_ALIAS_RID_LOGGING_USERS          (0x0000022FL)
#define DOMAIN_ALIAS_RID_AUTHORIZATIONACCESS    (0x00000230L)
#define DOMAIN_ALIAS_RID_TS_LICENSE_SERVERS     (0x00000231L)



typedef enum {

	WinNullSid                                  = 0,
	WinWorldSid                                 = 1,
	WinLocalSid                                 = 2,
	WinCreatorOwnerSid                          = 3,
	WinCreatorGroupSid                          = 4,
	WinCreatorOwnerServerSid                    = 5,
	WinCreatorGroupServerSid                    = 6,
	WinNtAuthoritySid                           = 7,
	WinDialupSid                                = 8,
	WinNetworkSid                               = 9,
	WinBatchSid                                 = 10,
	WinInteractiveSid                           = 11,
	WinServiceSid                               = 12,
	WinAnonymousSid                             = 13,
	WinProxySid                                 = 14,
	WinEnterpriseControllersSid                 = 15,
	WinSelfSid                                  = 16,
	WinAuthenticatedUserSid                     = 17,
	WinRestrictedCodeSid                        = 18,
	WinTerminalServerSid                        = 19,
	WinRemoteLogonIdSid                         = 20,
	WinLogonIdsSid                              = 21,
	WinLocalSystemSid                           = 22,
	WinLocalServiceSid                          = 23,
	WinNetworkServiceSid                        = 24,
	WinBuiltinDomainSid                         = 25,
	WinBuiltinAdministratorsSid                 = 26,
	WinBuiltinUsersSid                          = 27,
	WinBuiltinGuestsSid                         = 28,
	WinBuiltinPowerUsersSid                     = 29,
	WinBuiltinAccountOperatorsSid               = 30,
	WinBuiltinSystemOperatorsSid                = 31,
	WinBuiltinPrintOperatorsSid                 = 32,
	WinBuiltinBackupOperatorsSid                = 33,
	WinBuiltinReplicatorSid                     = 34,
	WinBuiltinPreWindows2000CompatibleAccessSid = 35,
	WinBuiltinRemoteDesktopUsersSid             = 36,
	WinBuiltinNetworkConfigurationOperatorsSid  = 37,
	WinAccountAdministratorSid                  = 38,
	WinAccountGuestSid                          = 39,
	WinAccountKrbtgtSid                         = 40,
	WinAccountDomainAdminsSid                   = 41,
	WinAccountDomainUsersSid                    = 42,
	WinAccountDomainGuestsSid                   = 43,
	WinAccountComputersSid                      = 44,
	WinAccountControllersSid                    = 45,
	WinAccountCertAdminsSid                     = 46,
	WinAccountSchemaAdminsSid                   = 47,
	WinAccountEnterpriseAdminsSid               = 48,
	WinAccountPolicyAdminsSid                   = 49,
	WinAccountRasAndIasServersSid               = 50,
	WinNTLMAuthenticationSid                    = 51,
	WinDigestAuthenticationSid                  = 52,
	WinSChannelAuthenticationSid                = 53,
	WinThisOrganizationSid                      = 54,
	WinOtherOrganizationSid                     = 55,
	WinBuiltinIncomingForestTrustBuildersSid    = 56,
	WinBuiltinPerfMonitoringUsersSid            = 57,
	WinBuiltinPerfLoggingUsersSid               = 58,
	WinBuiltinAuthorizationAccessSid            = 59,
	WinBuiltinTerminalServerLicenseServersSid   = 60,

} WELL_KNOWN_SID_TYPE;

//
// Allocate the System Luid.  The first 1000 LUIDs are reserved.
// Use #999 here (0x3E7 = 999)
//

#define SYSTEM_LUID                     { 0x3E7, 0x0 }
#define ANONYMOUS_LOGON_LUID            { 0x3e6, 0x0 }
#define LOCALSERVICE_LUID               { 0x3e5, 0x0 }
#define NETWORKSERVICE_LUID             { 0x3e4, 0x0 }

#define SE_GROUP_MANDATORY              (0x00000001L)
#define SE_GROUP_ENABLED_BY_DEFAULT     (0x00000002L)
#define SE_GROUP_ENABLED                (0x00000004L)
#define SE_GROUP_OWNER                  (0x00000008L)
#define SE_GROUP_USE_FOR_DENY_ONLY      (0x00000010L)
#define SE_GROUP_LOGON_ID               (0xC0000000L)
#define SE_GROUP_RESOURCE               (0x20000000L)


#endif

#ifndef _NTTYPES_NO_WINUSER

#define MB_OK                       0x00000000L
#define MB_OKCANCEL                 0x00000001L
#define MB_ABORTRETRYIGNORE         0x00000002L
#define MB_YESNOCANCEL              0x00000003L
#define MB_YESNO                    0x00000004L
#define MB_RETRYCANCEL              0x00000005L
#if _WIN32_WINNT >= 0x0500
#define MB_CANCELTRYCONTINUE        0x00000006L
#endif /* _WIN32_WINNT >= 0x0500 */


#define MB_ICONHAND                 0x00000010L
#define MB_ICONQUESTION             0x00000020L
#define MB_ICONEXCLAMATION          0x00000030L
#define MB_ICONASTERISK             0x00000040L

#if _WIN32_WINNT >= 0x0400
#define MB_USERICON                 0x00000080L
#define MB_ICONWARNING              MB_ICONEXCLAMATION
#define MB_ICONERROR                MB_ICONHAND
#endif /* _WIN32_WINNT >= 0x0400 */

#define MB_ICONINFORMATION          MB_ICONASTERISK
#define MB_ICONSTOP                 MB_ICONHAND

#define MB_DEFBUTTON1               0x00000000L
#define MB_DEFBUTTON2               0x00000100L
#define MB_DEFBUTTON3               0x00000200L
#if _WIN32_WINNT >= 0x0400
#define MB_DEFBUTTON4               0x00000300L
#endif /* _WIN32_WINNT >= 0x0400 */

#define MB_APPLMODAL                0x00000000L
#define MB_SYSTEMMODAL              0x00001000L
#define MB_TASKMODAL                0x00002000L
#if _WIN32_WINNT >= 0x0400
#define MB_HELP                     0x00004000L // Help Button
#endif /* _WIN32_WINNT >= 0x0400 */

#define MB_NOFOCUS                  0x00008000L
#define MB_SETFOREGROUND            0x00010000L
#define MB_DEFAULT_DESKTOP_ONLY     0x00020000L

#if _WIN32_WINNT >= 0x0400
#define MB_TOPMOST                  0x00040000L
#define MB_RIGHT                    0x00080000L
#define MB_RTLREADING               0x00100000L


#endif /* _WIN32_WINNT >= 0x0400 */

#ifdef _WIN32_WINNT
#if (_WIN32_WINNT >= 0x0400)
#define MB_SERVICE_NOTIFICATION          0x00200000L
#else
#define MB_SERVICE_NOTIFICATION          0x00040000L
#endif
#define MB_SERVICE_NOTIFICATION_NT3X     0x00040000L
#endif

#define MB_TYPEMASK                 0x0000000FL
#define MB_ICONMASK                 0x000000F0L
#define MB_DEFMASK                  0x00000F00L
#define MB_MODEMASK                 0x00003000L
#define MB_MISCMASK                 0x0000C000L

#endif

typedef struct _LDRP_TLS_ENTRY {
	LIST_ENTRY Links;
	IMAGE_TLS_DIRECTORY Tls;
} LDRP_TLS_ENTRY, *PLDRP_TLS_ENTRY;

#ifndef _NTEXAPI_						/* NTEXAPI.H included with ancient DDK versions, be compatible here in case someone is still using it */

//
// NtGlobalFlag
//

#define FLG_STOP_ON_EXCEPTION			0x00000001      // user and kernel mode
#define FLG_SHOW_LDR_SNAPS				0x00000002      // user and kernel mode
#define FLG_DEBUG_INITIAL_COMMAND		0x00000004      // kernel mode only up until WINLOGON started
#define FLG_STOP_ON_HUNG_GUI			0x00000008      // kernel mode only while running

#define FLG_HEAP_ENABLE_TAIL_CHECK		0x00000010      // user mode only
#define FLG_HEAP_ENABLE_FREE_CHECK		0x00000020      // user mode only
#define FLG_HEAP_VALIDATE_PARAMETERS	0x00000040      // user mode only
#define FLG_HEAP_VALIDATE_ALL			0x00000080      // user mode only

#define FLG_POOL_ENABLE_TAIL_CHECK		0x00000100      // kernel mode only
#define FLG_POOL_ENABLE_FREE_CHECK		0x00000200      // kernel mode only
#define FLG_POOL_ENABLE_TAGGING			0x00000400      // kernel mode only
#define FLG_HEAP_ENABLE_TAGGING			0x00000800      // user mode only

#define FLG_USER_STACK_TRACE_DB			0x00001000      // x86 user mode only
#define FLG_KERNEL_STACK_TRACE_DB		0x00002000      // x86 kernel mode only at boot time
#define FLG_MAINTAIN_OBJECT_TYPELIST	0x00004000      // kernel mode only at boot time
#define FLG_HEAP_ENABLE_TAG_BY_DLL		0x00008000      // user mode only

#define FLG_IGNORE_DEBUG_PRIV			0x00010000      // kernel mode only
#define FLG_ENABLE_CSRDEBUG				0x00020000      // kernel mode only at boot time
#define FLG_ENABLE_KDEBUG_SYMBOL_LOAD	0x00040000      // kernel mode only
#define FLG_DISABLE_PAGE_KERNEL_STACKS	0x00080000      // kernel mode only at boot time

#define FLG_HEAP_ENABLE_CALL_TRACING	0x00100000      // user mode only
#define FLG_HEAP_DISABLE_COALESCING		0x00200000      // user mode only

#define FLG_ENABLE_CLOSE_EXCEPTIONS		0x00400000      // kernel mode only
#define FLG_ENABLE_EXCEPTION_LOGGING	0x00800000      // kernel mode only

#define FLG_ENABLE_HANDLE_TYPE_TAGGING	0x01000000      // kernel mode only

#define FLG_HEAP_PAGE_ALLOCS			0x02000000      // user mode only
#define FLG_DEBUG_INITIAL_COMMAND_EX	0x04000000      // kernel mode only up until WINLOGON started

#define FLG_VALID_BITS					0x07FFFFFF

#define FLG_USERMODE_VALID_BITS			(FLG_STOP_ON_EXCEPTION           | \
										FLG_SHOW_LDR_SNAPS              | \
										FLG_HEAP_ENABLE_TAIL_CHECK      | \
										FLG_HEAP_ENABLE_FREE_CHECK      | \
										FLG_HEAP_VALIDATE_PARAMETERS    | \
										FLG_HEAP_VALIDATE_ALL           | \
										FLG_HEAP_ENABLE_TAGGING         | \
										FLG_USER_STACK_TRACE_DB         | \
										FLG_HEAP_ENABLE_TAG_BY_DLL      | \
										FLG_HEAP_ENABLE_CALL_TRACING    | \
										FLG_HEAP_DISABLE_COALESCING     | \
										FLG_HEAP_PAGE_ALLOCS)

#define FLG_BOOTONLY_VALID_BITS			(FLG_KERNEL_STACK_TRACE_DB       | \
										FLG_MAINTAIN_OBJECT_TYPELIST    | \
										FLG_ENABLE_CSRDEBUG             | \
										FLG_DISABLE_PAGE_KERNEL_STACKS)

#define FLG_KERNELMODE_VALID_BITS		(FLG_STOP_ON_EXCEPTION           | \
										FLG_SHOW_LDR_SNAPS              | \
										FLG_DEBUG_INITIAL_COMMAND       | \
										FLG_DEBUG_INITIAL_COMMAND_EX    | \
										FLG_STOP_ON_HUNG_GUI            | \
										FLG_POOL_ENABLE_TAIL_CHECK      | \
										FLG_POOL_ENABLE_FREE_CHECK      | \
										FLG_POOL_ENABLE_TAGGING         | \
										FLG_IGNORE_DEBUG_PRIV           | \
										FLG_ENABLE_KDEBUG_SYMBOL_LOAD   | \
										FLG_ENABLE_CLOSE_EXCEPTIONS     | \
										FLG_ENABLE_EXCEPTION_LOGGING    | \
										FLG_ENABLE_HANDLE_TYPE_TAGGING)

#endif

#ifndef NT_NO_GDIOBJ

#define GDIOBJ_FREE		0x00
#define GDIOBJ_DC		0x01
#define GDIOBJ_REGION	0x04
#define GDIOBJ_BITMAP	0x05
#define GDIOBJ_PALETTE	0x08
#define GDIOBJ_FONT		0x0A
#define GDIOBJ_BRUSH	0x10

#define GDIOBJ_TYPEMASK 0x1F

#define MAX_GDI_OBJECTS 16384

typedef struct _GDI_HANDLE_ENTRY {
	HANDLE Handle; // The real object handle
	HANDLE CreatorProcessId; // Creator's process id
	USHORT Unique; // Unique value for this handle.  If it doesn't match the top 16 bits in the GDI handle passed
	// in then the requestor is reusing a stale handle.
	UCHAR Type;
	UCHAR Unknown0;
	ULONG Unknown1;
} GDI_HANDLE_ENTRY, * PGDI_HANDLE_ENTRY;

#ifdef _M_IX86
C_ASSERT(sizeof(GDI_HANDLE_ENTRY) == 0x10);
#endif

#endif


#if _WIN32_WINNT >= 0x0600 && !defined(_WINNT_)

//
// Transaction Manager (Windows Vista)
//

//
// Types for Nt level TM calls
//
 
// begin_ntktm begin_winnt
 
//
// KTM Tm object rights
//
#define TRANSACTIONMANAGER_QUERY_INFORMATION     ( 0x0001 )
#define TRANSACTIONMANAGER_SET_INFORMATION       ( 0x0002 )
#define TRANSACTIONMANAGER_RECOVER               ( 0x0004 )
#define TRANSACTIONMANAGER_RENAME                ( 0x0008 )
#define TRANSACTIONMANAGER_CREATE_RM             ( 0x0010 )
 
//
// Generic mappings for transaction manager rights.
//
 
#define TRANSACTIONMANAGER_GENERIC_READ            (STANDARD_RIGHTS_READ            |\
                                                    TRANSACTIONMANAGER_QUERY_INFORMATION   |\
                                                    SYNCHRONIZE)
 
#define TRANSACTIONMANAGER_GENERIC_WRITE           (STANDARD_RIGHTS_WRITE           |\
                                                    TRANSACTIONMANAGER_SET_INFORMATION     |\
                                                    TRANSACTIONMANAGER_RECOVER             |\
                                                    TRANSACTIONMANAGER_RENAME              |\
                                                    TRANSACTIONMANAGER_CREATE_RM           |\
                                                    SYNCHRONIZE)
 
#define TRANSACTIONMANAGER_GENERIC_EXECUTE         (STANDARD_RIGHTS_EXECUTE         |\
                                                    SYNCHRONIZE)
 
#define TRANSACTIONMANAGER_ALL_ACCESS              (STANDARD_RIGHTS_REQUIRED        |\
                                                    TRANSACTIONMANAGER_GENERIC_READ        |\
                                                    TRANSACTIONMANAGER_GENERIC_WRITE       |\
                                                    TRANSACTIONMANAGER_GENERIC_EXECUTE)
 
 
//
// KTM transaction object rights.
//
#define TRANSACTION_QUERY_INFORMATION     ( 0x0001 )
#define TRANSACTION_SET_INFORMATION       ( 0x0002 )
#define TRANSACTION_ENLIST                ( 0x0004 )
#define TRANSACTION_COMMIT                ( 0x0008 )
#define TRANSACTION_ROLLBACK              ( 0x0010 )
#define TRANSACTION_PROPAGATE             ( 0x0020 )
#define TRANSACTION_SAVEPOINT             ( 0x0040 )
#define TRANSACTION_MARSHALL              ( TRANSACTION_QUERY_INFORMATION )
 
//
// Generic mappings for transaction rights.
// Resource managers, when enlisting, should generally use the macro
// TRANSACTION_RESOURCE_MANAGER_RIGHTS when opening a transaction.
// It's the same as generic read and write except that it does not allow
// a commit decision to be made.
//
 
#define TRANSACTION_GENERIC_READ            (STANDARD_RIGHTS_READ            |\
                                             TRANSACTION_QUERY_INFORMATION   |\
                                             SYNCHRONIZE)
 
#define TRANSACTION_GENERIC_WRITE           (STANDARD_RIGHTS_WRITE           |\
                                             TRANSACTION_SET_INFORMATION     |\
                                             TRANSACTION_COMMIT              |\
                                             TRANSACTION_ENLIST              |\
                                             TRANSACTION_ROLLBACK            |\
                                             TRANSACTION_PROPAGATE           |\
                                             TRANSACTION_SAVEPOINT           |\
                                             SYNCHRONIZE)
 
#define TRANSACTION_GENERIC_EXECUTE         (STANDARD_RIGHTS_EXECUTE         |\
                                             TRANSACTION_COMMIT              |\
                                             TRANSACTION_ROLLBACK            |\
                                             SYNCHRONIZE)
 
#define TRANSACTION_ALL_ACCESS              (STANDARD_RIGHTS_REQUIRED        |\
                                             TRANSACTION_GENERIC_READ        |\
                                             TRANSACTION_GENERIC_WRITE       |\
                                             TRANSACTION_GENERIC_EXECUTE)
 
#define TRANSACTION_RESOURCE_MANAGER_RIGHTS (TRANSACTION_GENERIC_READ        |\
                                             STANDARD_RIGHTS_WRITE           |\
                                             TRANSACTION_SET_INFORMATION     |\
                                             TRANSACTION_ENLIST              |\
                                             TRANSACTION_ROLLBACK            |\
                                             TRANSACTION_PROPAGATE           |\
                                             SYNCHRONIZE)
 
//
// KTM resource manager object rights.
//
#define RESOURCEMANAGER_QUERY_INFORMATION     ( 0x0001 )
#define RESOURCEMANAGER_SET_INFORMATION       ( 0x0002 )
#define RESOURCEMANAGER_RECOVER               ( 0x0004 )
#define RESOURCEMANAGER_ENLIST                ( 0x0008 )
#define RESOURCEMANAGER_GET_NOTIFICATION      ( 0x0010 )
#define RESOURCEMANAGER_REGISTER_PROTOCOL     ( 0x0020 )
#define RESOURCEMANAGER_COMPLETE_PROPAGATION  ( 0x0040 )
 
//
// Generic mappings for resource manager rights.
//
#define RESOURCEMANAGER_GENERIC_READ        (STANDARD_RIGHTS_READ                 |\
                                             RESOURCEMANAGER_QUERY_INFORMATION    |\
                                             RESOURCEMANAGER_RECOVER              |\
                                             SYNCHRONIZE)
 
#define RESOURCEMANAGER_GENERIC_WRITE       (STANDARD_RIGHTS_WRITE                |\
                                             RESOURCEMANAGER_SET_INFORMATION      |\
                                             RESOURCEMANAGER_ENLIST               |\
                                             RESOURCEMANAGER_GET_NOTIFICATION     |\
                                             RESOURCEMANAGER_REGISTER_PROTOCOL    |\
                                             RESOURCEMANAGER_COMPLETE_PROPAGATION |\
                                             SYNCHRONIZE)
 
#define RESOURCEMANAGER_GENERIC_EXECUTE     (STANDARD_RIGHTS_EXECUTE              |\
                                             RESOURCEMANAGER_ENLIST               |\
                                             RESOURCEMANAGER_GET_NOTIFICATION     |\
                                             RESOURCEMANAGER_COMPLETE_PROPAGATION |\
                                             SYNCHRONIZE)
 
#define RESOURCEMANAGER_ALL_ACCESS          (STANDARD_RIGHTS_REQUIRED             |\
                                             RESOURCEMANAGER_GENERIC_READ         |\
                                             RESOURCEMANAGER_GENERIC_WRITE        |\
                                             RESOURCEMANAGER_GENERIC_EXECUTE)
 
 
//
// KTM enlistment object rights.
//
#define ENLISTMENT_QUERY_INFORMATION     ( 0x0001 )
#define ENLISTMENT_SET_INFORMATION       ( 0x0002 )
#define ENLISTMENT_RECOVER               ( 0x0004 )
#define ENLISTMENT_REFERENCE             ( 0x0008 )
#define ENLISTMENT_SUBORDINATE_RIGHTS    ( 0x0010 )
#define ENLISTMENT_SUPERIOR_RIGHTS       ( 0x0020 )
 
//
// Generic mappings for enlistment rights.
//
#define ENLISTMENT_GENERIC_READ        (STANDARD_RIGHTS_READ           |\
                                        ENLISTMENT_QUERY_INFORMATION   |\
                                        SYNCHRONIZE)
 
#define ENLISTMENT_GENERIC_WRITE       (STANDARD_RIGHTS_WRITE          |\
                                        ENLISTMENT_SET_INFORMATION     |\
                                        ENLISTMENT_RECOVER             |\
                                        ENLISTMENT_REFERENCE           |\
                                        ENLISTMENT_SUBORDINATE_RIGHTS  |\
                                        ENLISTMENT_SUPERIOR_RIGHTS     |\
                                        SYNCHRONIZE)
 
#define ENLISTMENT_GENERIC_EXECUTE     (STANDARD_RIGHTS_EXECUTE        |\
                                        ENLISTMENT_RECOVER             |\
                                        ENLISTMENT_SUBORDINATE_RIGHTS  |\
                                        ENLISTMENT_SUPERIOR_RIGHTS     |\
                                        SYNCHRONIZE)
 
#define ENLISTMENT_ALL_ACCESS          (STANDARD_RIGHTS_REQUIRED       |\
                                        ENLISTMENT_GENERIC_READ        |\
                                        ENLISTMENT_GENERIC_WRITE       |\
                                        ENLISTMENT_GENERIC_EXECUTE)
 
 
// end_ntktm end_winnt
 
 
 
//
// Transaction outcomes.
//
// TODO: warning, must match values in KTRANSACTION_OUTCOME duplicated def 
// in tm.h.
//
 
typedef enum _TRANSACTION_OUTCOME {
    TransactionOutcomeUndetermined = 1,
    TransactionOutcomeCommitted,
    TransactionOutcomeAborted,
} TRANSACTION_OUTCOME;
 
 
typedef struct _TRANSACTION_BASIC_INFORMATION {
    GUID    UnitOfWork;
    ULONG   State;
    ULONG   Outcome;
} TRANSACTION_BASIC_INFORMATION, *PTRANSACTION_BASIC_INFORMATION;
 
typedef struct _TRANSACTIONMANAGER_BASIC_INFORMATION {
    GUID    TmIdentity;
    LARGE_INTEGER VirtualClock;
} TRANSACTIONMANAGER_BASIC_INFORMATION, *PTRANSACTIONMANAGER_BASIC_INFORMATION;
 
typedef struct _TRANSACTIONMANAGER_LOG_INFORMATION {
    GUID LogIdentity;
} TRANSACTIONMANAGER_LOG_INFORMATION, *PTRANSACTIONMANAGER_LOG_INFORMATION;
 
typedef struct _TRANSACTION_PROPERTIES_INFORMATION {
    ULONG              IsolationLevel;
    ULONG              IsolationFlags;
    LARGE_INTEGER      Timeout;
    ULONG              Outcome;
    ULONG              DescriptionLength;
    WCHAR              Description[1];            // Variable size
//          Data[1];            // Variable size data not declared
} TRANSACTION_PROPERTIES_INFORMATION, *PTRANSACTION_PROPERTIES_INFORMATION;
 
typedef struct _TRANSACTION_FULL_INFORMATION {
// Not currently defined
    ULONG   NameLength;
} TRANSACTION_FULL_INFORMATION, *PTRANSACTION_FULL_INFORMATION;
 
 
typedef struct _RESOURCEMANAGER_BASIC_INFORMATION {
    GUID    RmId;
} RESOURCEMANAGER_BASIC_INFORMATION, *PRESOURCEMANAGER_BASIC_INFORMATION;
 
typedef struct _RESOURCEMANAGER_COMPLETION_INFORMATION {
    HANDLE    IoCompletionPortHandle;
    ULONG_PTR CompletionKey;
} RESOURCEMANAGER_COMPLETION_INFORMATION, *PRESOURCEMANAGER_COMPLETION_INFORMATION;
 
// end_wdm
typedef struct _TRANSACTION_NAME_INFORMATION {
    ULONG   NameLength;
    WCHAR   Name[1];            // Variable length string
} TRANSACTION_NAME_INFORMATION, *PTRANSACTION_NAME_INFORMATION;
 
 
// begin_wdm
typedef enum _TRANSACTION_INFORMATION_CLASS {
    TransactionBasicInformation,
    TransactionPropertiesInformation,
    TransactionDescriptionInformation,
    TransactionFullInformation
// end_wdm
    ,
//    TransactionNameInformation
// begin_wdm
} TRANSACTION_INFORMATION_CLASS;
 
// begin_wdm
typedef enum _TRANSACTIONMANAGER_INFORMATION_CLASS {
    TransactionManagerBasicInformation,
    TransactionManagerLogInformation
// end_wdm
 
// begin_wdm
} TRANSACTIONMANAGER_INFORMATION_CLASS;
 
 
// begin_wdm
typedef enum _RESOURCEMANAGER_INFORMATION_CLASS {
    ResourceManagerBasicInformation,
    ResourceManagerCompletionInformation,
    ResourceManagerFullInformation
// end_wdm
    ,
    ResourceManagerNameInformation
// begin_wdm
} RESOURCEMANAGER_INFORMATION_CLASS;
 
 
typedef struct _ENLISTMENT__BASIC_INFORMATION {
    GUID    EnlistmentId;
    GUID    TransactionId;
    GUID    RmId;
} ENLISTMENT_BASIC_INFORMATION, *PENLISTMENT_BASIC_INFORMATION;
 
// begin_wdm
typedef enum _ENLISTMENT_INFORMATION_CLASS {
    EnlistmentBasicInformation,
    EnlistmentRecoveryInformation,
    EnlistmentDynamicNameInformation,
    EnlistmentFullInformation
// end_wdm
    ,
    EnlistmentNameInformation
// begin_wdm
} ENLISTMENT_INFORMATION_CLASS;


#endif

#include <poppack.h>

_NTNATIVE_END_NT

#pragma warning(pop)

#endif
