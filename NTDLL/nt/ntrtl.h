#ifndef NTRTL_H
#define NTRTL_H

#pragma once

#include <nt\nttypes.h>

_NTNATIVE_BEGIN_NT

#define RtlProcessHeap() (NtCurrentPeb()->ProcessHeap)

NTSYSAPI
VOID
NTAPI
RtlAssert(
    IN PVOID FailedAssertion,
    IN PVOID FileName,
    IN ULONG LineNumber,
    IN PCHAR Message OPTIONAL
    );

#ifndef _NTRTL_EXCLUDE_ASSERT

//
// From NTDDK.h - 3790.1830
//

//
// If debugging support enabled, define an ASSERT macro that works.  Otherwise
// define the ASSERT macro to expand to an empty expression.
//
// The ASSERT macro has been updated to be an expression instead of a statement.
//

#if DBG

#define ASSERT( exp ) \
    ((!(exp)) ? \
        (RtlAssert( #exp, __FILE__, __LINE__, NULL ),FALSE) : \
        TRUE)

#define ASSERTMSG( msg, exp ) \
    ((!(exp)) ? \
        (RtlAssert( #exp, __FILE__, __LINE__, msg ),FALSE) : \
        TRUE)

#define RTL_SOFT_ASSERT(_exp) \
    ((!(_exp)) ? \
        (DbgPrint("%s(%d): Soft assertion failed\n   Expression: %s\n", __FILE__, __LINE__, #_exp),FALSE) : \
        TRUE)

#define RTL_SOFT_ASSERTMSG(_msg, _exp) \
    ((!(_exp)) ? \
        (DbgPrint("%s(%d): Soft assertion failed\n   Expression: %s\n   Message: %s\n", __FILE__, __LINE__, #_exp, (_msg)),FALSE) : \
        TRUE)

#if _MSC_VER >= 1300

#define NT_ASSERT(_exp) \
    ((!(_exp)) ? \
        (__annotation(L"Debug", L"AssertFail", L#_exp), \
         DbgRaiseAssertionFailure(), FALSE) : \
        TRUE)

#define NT_ASSERTMSG(_msg, _exp) \
    ((!(_exp)) ? \
        (__annotation(L"Debug", L"AssertFail", L##_msg), \
         DbgRaiseAssertionFailure(), FALSE) : \
        TRUE)

#define NT_ASSERTMSGW(_msg, _exp) \
    ((!(_exp)) ? \
        (__annotation(L"Debug", L"AssertFail", _msg), \
         DbgRaiseAssertionFailure(), FALSE) : \
        TRUE)

#define NT_VERIFY     NT_ASSERT
#define NT_VERIFYMSG  NT_ASSERTMSG
#define NT_VERIFYMSGW NT_ASSERTMSGW

#endif // #if _MSC_VER >= 1300

#define RTL_VERIFY         ASSERT
#define RTL_VERIFYMSG      ASSERTMSG

#define RTL_SOFT_VERIFY    RTL_SOFT_ASSERT
#define RTL_SOFT_VERIFYMSG RTL_SOFT_ASSERTMSG

#else
#define ASSERT( exp )         ((void) 0)
#define ASSERTMSG( msg, exp ) ((void) 0)

#if _MSC_VER >= 1300

#define NT_ASSERT(_exp)           ((void) 0)
#define NT_ASSERTMSG(_msg, _exp)  ((void) 0)
#define NT_ASSERTMSGW(_msg, _exp) ((void) 0)

#define NT_VERIFY(_exp)           ((_exp) ? TRUE : FALSE)
#define NT_VERIFYMSG(_msg, _exp ) ((_exp) ? TRUE : FALSE)
#define NT_VERIFYMSGW(_msg, _exp) ((_exp) ? TRUE : FALSE)

#endif // #if _MSC_VER >= 1300

#define RTL_SOFT_ASSERT(_exp)          ((void) 0)
#define RTL_SOFT_ASSERTMSG(_msg, _exp) ((void) 0)

#define RTL_VERIFY( exp )         ((exp) ? TRUE : FALSE)
#define RTL_VERIFYMSG( msg, exp ) ((exp) ? TRUE : FALSE)

#define RTL_SOFT_VERIFY(_exp)         ((_exp) ? TRUE : FALSE)
#define RTL_SOFT_VERIFYMSG(msg, _exp) ((_exp) ? TRUE : FALSE)

#endif // DBG



#endif

#if defined(_M_ALPHA) || defined(_M_AXP64) || defined(_M_IA64)
PVOID
_ReturnAddress (
    VOID
    );

#pragma intrinsic(_ReturnAddress)

#define RtlGetCallersAddress(CallersAddress, CallersCaller) \
    *CallersAddress = (PVOID)_ReturnAddress(); \
    *CallersCaller = NULL;
#else
NTSYSAPI
VOID
NTAPI
RtlGetCallersAddress(
    OUT PVOID *CallersAddress,
    OUT PVOID *CallersCaller
    );
#endif

NTSYSAPI
ULONG
NTAPI
RtlWalkFrameChain (
    OUT PVOID *Callers,
    IN ULONG Count,
    IN ULONG Flags);

//
// Subroutines for dealing with the Registry
//

typedef NTSTATUS (NTAPI * PRTL_QUERY_REGISTRY_ROUTINE)(
    IN PWSTR ValueName,
    IN ULONG ValueType,
    IN PVOID ValueData,
    IN ULONG ValueLength,
    IN PVOID Context,
    IN PVOID EntryContext
    );

typedef struct _RTL_QUERY_REGISTRY_TABLE {
    PRTL_QUERY_REGISTRY_ROUTINE QueryRoutine;
    ULONG Flags;
    PWSTR Name;
    PVOID EntryContext;
    ULONG DefaultType;
    PVOID DefaultData;
    ULONG DefaultLength;

} RTL_QUERY_REGISTRY_TABLE, *PRTL_QUERY_REGISTRY_TABLE;

//
// The following flags specify how the Name field of a RTL_QUERY_REGISTRY_TABLE
// entry is interpreted.  A NULL name indicates the end of the table.
//

#define RTL_QUERY_REGISTRY_SUBKEY   0x00000001  // Name is a subkey and remainder of
                                                // table or until next subkey are value
                                                // names for that subkey to look at.

#define RTL_QUERY_REGISTRY_TOPKEY   0x00000002  // Reset current key to original key for
                                                // this and all following table entries.

#define RTL_QUERY_REGISTRY_REQUIRED 0x00000004  // Fail if no match found for this table
                                                // entry.

#define RTL_QUERY_REGISTRY_NOVALUE  0x00000008  // Used to mark a table entry that has no
                                                // value name, just wants a call out, not
                                                // an enumeration of all values.

#define RTL_QUERY_REGISTRY_NOEXPAND 0x00000010  // Used to suppress the expansion of
                                                // REG_MULTI_SZ into multiple callouts or
                                                // to prevent the expansion of environment
                                                // variable values in REG_EXPAND_SZ

#define RTL_QUERY_REGISTRY_DIRECT   0x00000020  // QueryRoutine field ignored.  EntryContext
                                                // field points to location to store value.
                                                // For null terminated strings, EntryContext
                                                // points to UNICODE_STRING structure that
                                                // that describes maximum size of buffer.
                                                // If .Buffer field is NULL then a buffer is
                                                // allocated.
                                                //

#define RTL_QUERY_REGISTRY_DELETE   0x00000040  // Used to delete value keys after they
                                                // are queried.

NTSYSAPI
NTSTATUS
NTAPI
RtlQueryRegistryValues(
    IN ULONG RelativeTo,
    IN PCWSTR Path,
    IN PRTL_QUERY_REGISTRY_TABLE QueryTable,
    IN PVOID Context,
    IN PVOID Environment OPTIONAL
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlWriteRegistryValue(
    IN ULONG RelativeTo,
    IN PCWSTR Path,
    IN PCWSTR ValueName,
    IN ULONG ValueType,
    IN PVOID ValueData,
    IN ULONG ValueLength
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlDeleteRegistryValue(
    IN ULONG RelativeTo,
    IN PCWSTR Path,
    IN PCWSTR ValueName
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlCreateRegistryKey(
    IN ULONG RelativeTo,
    IN PWSTR Path
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlCheckRegistryKey(
    IN ULONG RelativeTo,
    IN PWSTR Path
    );

//
// The following values for the RelativeTo parameter determine what the
// Path parameter to RtlQueryRegistryValues is relative to.
//

#define RTL_REGISTRY_ABSOLUTE     0   // Path is a full path
#define RTL_REGISTRY_SERVICES     1   // \Registry\Machine\System\CurrentControlSet\Services
#define RTL_REGISTRY_CONTROL      2   // \Registry\Machine\System\CurrentControlSet\Control
#define RTL_REGISTRY_WINDOWS_NT   3   // \Registry\Machine\Software\Microsoft\Windows NT\CurrentVersion
#define RTL_REGISTRY_DEVICEMAP    4   // \Registry\Machine\Hardware\DeviceMap
#define RTL_REGISTRY_USER         5   // \Registry\User\CurrentUser
#define RTL_REGISTRY_MAXIMUM      6
#define RTL_REGISTRY_HANDLE       0x40000000    // Low order bits are registry handle
#define RTL_REGISTRY_OPTIONAL     0x80000000    // Indicates the key node is optional

NTSYSAPI                                            
NTSTATUS                                            
NTAPI                                               
RtlCharToInteger (                                  
	IN PCSZ String,                                    
	IN ULONG Base,                                     
	OUT PULONG Value                                    
	);                                              

NTSYSAPI
NTSTATUS
NTAPI
RtlIntegerToUnicodeString (
	IN ULONG Value,
	IN ULONG Base,
	OUT PUNICODE_STRING String
	);

NTSYSAPI
NTSTATUS
NTAPI
RtlInt64ToUnicodeString (
	IN ULONGLONG Value,
	IN ULONG Base OPTIONAL,
	OUT PUNICODE_STRING String
	);

#ifdef _WIN64
#define RtlIntPtrToUnicodeString(Value, Base, String) RtlInt64ToUnicodeString(Value, Base, String)
#else
#define RtlIntPtrToUnicodeString(Value, Base, String) RtlIntegerToUnicodeString(Value, Base, String)
#endif

NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeStringToInteger (
	IN PUNICODE_STRING String,
	IN ULONG Base,
	OUT PULONG Value
	);

//
//  String manipulation routines
//

NTSYSAPI
VOID
NTAPI
RtlInitString(
    IN PSTRING DestinationString,
    IN PCSZ SourceString
    );

NTSYSAPI
BOOLEAN
NTAPI
RtlPrefixString(
	IN PSTRING String1,
	IN PSTRING String2,
	IN BOOLEAN CaseInSensitive
	);

NTSYSAPI
VOID
NTAPI
RtlInitAnsiString(
    IN PANSI_STRING DestinationString,
    IN PCSZ SourceString
    );

NTSYSAPI
VOID
NTAPI
RtlInitUnicodeString(
    IN PUNICODE_STRING DestinationString,
    IN PCWSTR SourceString
    );

// RtlCreateUnicodeString creates a new counted Unicode string (allocated from the paged pool in kernel mode).
NTSYSAPI
BOOLEAN
NTAPI
RtlCreateUnicodeString(
	OUT PUNICODE_STRING DestinationString,
	IN PCWSTR SourceString
	);

NTSYSAPI
VOID
NTAPI
RtlCopyString(
    PSTRING DestinationString,
    PSTRING SourceString
    );

NTSYSAPI
CHAR
NTAPI
RtlUpperChar (
    CHAR Character
    );

NTSYSAPI
LONG
NTAPI
RtlCompareString(
    PSTRING String1,
    PSTRING String2,
    BOOLEAN CaseInSensitive
    );

NTSYSAPI
BOOLEAN
NTAPI
RtlEqualString(
    PSTRING String1,
    PSTRING String2,
    BOOLEAN CaseInSensitive
    );


NTSYSAPI
VOID
NTAPI
RtlUpperString(
    PSTRING DestinationString,
    PSTRING SourceString
    );

//
// NLS String functions
//

NTSYSAPI
NTSTATUS
NTAPI
RtlAnsiStringToUnicodeString(
    PUNICODE_STRING DestinationString,
    PANSI_STRING SourceString,
    BOOLEAN AllocateDestinationString
    );


NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeStringToAnsiString(
    PANSI_STRING DestinationString,
    PUNICODE_STRING SourceString,
    BOOLEAN AllocateDestinationString
    );

/*
NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeStringToOemString(
    POEM_STRING DestinationString,
    PCUNICODE_STRING SourceString,
    BOOLEAN AllocateDestinationString
    );
	*/

NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeToMultiByteSize(
    PULONG BytesInMultiByteString,
    IN PWSTR UnicodeString,
    ULONG BytesInUnicodeString
    );

NTSYSAPI
LONG
NTAPI
RtlCompareUnicodeString(
    PUNICODE_STRING String1,
    PUNICODE_STRING String2,
    BOOLEAN CaseInSensitive
    );

NTSYSAPI
BOOLEAN
NTAPI
RtlEqualUnicodeString(
    const UNICODE_STRING *String1,
    const UNICODE_STRING *String2,
    BOOLEAN CaseInSensitive
    );

// end_wdm

NTSYSAPI
BOOLEAN
NTAPI
RtlPrefixUnicodeString(
    IN PUNICODE_STRING String1,
    IN PUNICODE_STRING String2,
    IN BOOLEAN CaseInSensitive
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlUpcaseUnicodeString(
    PUNICODE_STRING DestinationString,
    PCUNICODE_STRING SourceString,
    BOOLEAN AllocateDestinationString
    );


NTSYSAPI
VOID
NTAPI
RtlCopyUnicodeString(
    PUNICODE_STRING DestinationString,
    PUNICODE_STRING SourceString
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlAppendUnicodeStringToString (
	IN PUNICODE_STRING Destination,
	OUT PUNICODE_STRING Source
	);

NTSYSAPI
NTSTATUS
NTAPI
RtlAppendUnicodeToString (
    PUNICODE_STRING Destination,
    PCWSTR Source
    );

NTSYSAPI
WCHAR
NTAPI
RtlUpcaseUnicodeChar(
    WCHAR SourceCharacter
    );


NTSYSAPI
VOID
NTAPI
RtlFreeUnicodeString(
    IN PUNICODE_STRING UnicodeString
    );

NTSYSAPI
VOID
NTAPI
RtlFreeAnsiString(
    PANSI_STRING AnsiString
    );

NTSYSAPI
ULONG
NTAPI
RtlxAnsiStringToUnicodeSize(
    PANSI_STRING AnsiString
    );

NTSYSAPI
ULONG
NTAPI
RtlAnsiStringToUnicodeSize(
    PANSI_STRING AnsiString
    );

#if !defined(__IDA__)
#include <guiddef.h>

#ifndef DEFINE_GUIDEX
    #define DEFINE_GUIDEX(name) EXTERN_C const CDECL GUID name
#endif // !defined(DEFINE_GUIDEX)

#ifndef STATICGUIDOF
    #define STATICGUIDOF(guid) STATIC_##guid
#endif // !defined(STATICGUIDOF)

#ifndef __IID_ALIGNED__
    #define __IID_ALIGNED__
    #ifdef __cplusplus
        inline int IsEqualGUIDAligned(REFGUID guid1, REFGUID guid2)
        {
            return ((*(PLONGLONG)(&guid1) == *(PLONGLONG)(&guid2)) && (*((PLONGLONG)(&guid1) + 1) == *((PLONGLONG)(&guid2) + 1)));
        }
    #else // !__cplusplus
        #define IsEqualGUIDAligned(guid1, guid2) \
            ((*(PLONGLONG)(guid1) == *(PLONGLONG)(guid2)) && (*((PLONGLONG)(guid1) + 1) == *((PLONGLONG)(guid2) + 1)))
    #endif // !__cplusplus
#endif // !__IID_ALIGNED__
#else
typedef GUID* REFGUID;
#endif

NTSYSAPI
NTSTATUS
NTAPI
RtlStringFromGUID(
    IN REFGUID Guid,
    OUT PUNICODE_STRING GuidString
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlStringFromGUID(
    IN REFGUID Guid,
    OUT PUNICODE_STRING GuidString
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlGUIDFromString(
    IN PUNICODE_STRING GuidString,
    OUT GUID* Guid
    );

//
// Fast primitives to compare, move, and zero memory
//

#ifndef RtlCompareMemory
NTSYSAPI
SIZE_T
NTAPI
RtlCompareMemory (
    const VOID *Source1,
    const VOID *Source2,
    SIZE_T Length
    );
#endif

#ifndef RtlCopyMemory
#if _WIN32_WINNT <= 0x0400
NTSYSAPI
VOID
NTAPI
RtlCopyMemory (
   VOID UNALIGNED *Destination,
   CONST VOID UNALIGNED *Source,
   SIZE_T Length
   );
#else
#define RtlCopyMemory(Destination, Source, Length) memcpy((Destination), (Source), (Length))
#pragma intrinsic(memcpy)
#endif
#endif

#if !defined(__IDA__)
#if !defined(_NTTYPES_NO_WINNT)
#if !defined(MIDL_PASS)
#if !defined(RtlSecureZeroMemory)
FORCEINLINE
PVOID
RtlSecureZeroMemory(
    IN PVOID ptr,
    IN SIZE_T cnt
    )
{
    volatile char *vptr = (volatile char *)ptr;
    while (cnt) {
        *vptr = 0;
        vptr++;
        cnt--;
    }
    return ptr;
}
#endif
#endif
#endif
#endif

#ifndef RtlCopyMemory32
NTSYSAPI
VOID
NTAPI
RtlCopyMemory32 (
   VOID UNALIGNED *Destination,
   CONST VOID UNALIGNED *Source,
   ULONG Length
   );
#endif

#ifndef RtlMoveMemory
NTSYSAPI
VOID
NTAPI
RtlMoveMemory (
   VOID UNALIGNED *Destination,
   CONST VOID UNALIGNED *Source,
   SIZE_T Length
   );
#endif

#ifndef RtlFillMemory
NTSYSAPI
VOID
NTAPI
RtlFillMemory (
   VOID UNALIGNED *Destination,
   SIZE_T Length,
   UCHAR Fill
   );
#endif

#ifndef RtlZeroMemory
NTSYSAPI
VOID
NTAPI
RtlZeroMemory (
   VOID UNALIGNED *Destination,
   SIZE_T Length
   );
#endif

NTSYSAPI
VOID
NTAPI
RtlFillMemoryUlong(
	IN PVOID Destination,
	IN ULONG Length,
	IN ULONG Fill
	);

NTSYSAPI
VOID
NTAPI
RtlFillMemoryUlonglong(
	IN PVOID Destination,
	IN SIZE_T Length,
	IN ULONGLONG Pattern
	);


#if !defined(RtlCopyBytes) && !defined(RtlZeroBytes) && !defined(RtlFillBytes)

#if defined(_M_ALPHA)

//
// Guaranteed byte granularity memory copy function.
//

NTSYSAPI
VOID
NTAPI
RtlCopyBytes (
   PVOID Destination,
   CONST VOID *Source,
   SIZE_T Length
   );

//
// Guaranteed byte granularity memory zero function.
//

NTSYSAPI
VOID
NTAPI
RtlZeroBytes (
   PVOID Destination,
   SIZE_T Length
   );

//
// Guaranteed byte granularity memory fill function.
//

NTSYSAPI
VOID
NTAPI
RtlFillBytes (
    PVOID Destination,
    SIZE_T Length,
    UCHAR Fill
    );

#else

#define RtlCopyBytes RtlCopyMemory
#define RtlZeroBytes RtlZeroMemory
#define RtlFillBytes RtlFillMemory

#endif

#endif

//
// Large integer arithmetic routines.
//

//
// Large integer add - 64-bits + 64-bits -> 64-bits
//

#if !defined(MIDL_PASS)

__inline
LARGE_INTEGER
NTAPI
RtlLargeIntegerAdd (
    LARGE_INTEGER Addend1,
    LARGE_INTEGER Addend2
    )
{
    LARGE_INTEGER Sum;

    Sum.QuadPart = Addend1.QuadPart + Addend2.QuadPart;
    return Sum;
}

//
// Enlarged integer multiply - 32-bits * 32-bits -> 64-bits
//

__inline
LARGE_INTEGER
NTAPI
RtlEnlargedIntegerMultiply (
    LONG Multiplicand,
    LONG Multiplier
    )
{
    LARGE_INTEGER Product;

    Product.QuadPart = (LONGLONG)Multiplicand * (ULONGLONG)Multiplier;
    return Product;
}

//
// Unsigned enlarged integer multiply - 32-bits * 32-bits -> 64-bits
//

__inline
LARGE_INTEGER
NTAPI
RtlEnlargedUnsignedMultiply (
    ULONG Multiplicand,
    ULONG Multiplier
    )
{
    LARGE_INTEGER Product;

    Product.QuadPart = (ULONGLONG)Multiplicand * (ULONGLONG)Multiplier;
    return Product;
}

//
// Enlarged integer divide - 64-bits / 32-bits > 32-bits
//

__inline
ULONG
NTAPI
RtlEnlargedUnsignedDivide (
    IN ULARGE_INTEGER Dividend,
    IN ULONG Divisor,
    IN PULONG Remainder
    )
{
    ULONG Quotient;

    Quotient = (ULONG)(Dividend.QuadPart / Divisor);
    if (ARGUMENT_PRESENT( Remainder )) {

        *Remainder = (ULONG)(Dividend.QuadPart % Divisor);
    }

    return Quotient;
}

//
// Large integer negation - -(64-bits)
//

__inline
LARGE_INTEGER
NTAPI
RtlLargeIntegerNegate (
    LARGE_INTEGER Subtrahend
    )
{
    LARGE_INTEGER Difference;

    Difference.QuadPart = -Subtrahend.QuadPart;
    return Difference;
}

//
// Large integer subtract - 64-bits - 64-bits -> 64-bits.
//

__inline
LARGE_INTEGER
NTAPI
RtlLargeIntegerSubtract (
    LARGE_INTEGER Minuend,
    LARGE_INTEGER Subtrahend
    )
{
    LARGE_INTEGER Difference;

    Difference.QuadPart = Minuend.QuadPart - Subtrahend.QuadPart;
    return Difference;
}

#endif

//
// Extended large integer magic divide - 64-bits / 32-bits -> 64-bits
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlExtendedMagicDivide (
    LARGE_INTEGER Dividend,
    LARGE_INTEGER MagicDivisor,
    CCHAR ShiftCount
    );

//
// Large Integer divide - 64-bits / 32-bits -> 64-bits
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlExtendedLargeIntegerDivide (
    LARGE_INTEGER Dividend,
    ULONG Divisor,
    PULONG Remainder
    );

// end_wdm
//
// Large Integer divide - 64-bits / 32-bits -> 64-bits
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlLargeIntegerDivide (
    LARGE_INTEGER Dividend,
    LARGE_INTEGER Divisor,
    PLARGE_INTEGER Remainder
    );

// begin_wdm
//
// Extended integer multiply - 32-bits * 64-bits -> 64-bits
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlExtendedIntegerMultiply (
    LARGE_INTEGER Multiplicand,
    LONG Multiplier
    );

//
// Large integer and - 64-bite & 64-bits -> 64-bits.
//

#define RtlLargeIntegerAnd(Result, Source, Mask)   \
        {                                           \
            Result.HighPart = Source.HighPart & Mask.HighPart; \
            Result.LowPart = Source.LowPart & Mask.LowPart; \
        }

//
// Large integer conversion routines.
//

#if defined(MIDL_PASS) || defined(__cplusplus) || !defined(_M_IX86)

//
// Convert signed integer to large integer.
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlConvertLongToLargeInteger (
    LONG SignedInteger
    );

//
// Convert unsigned integer to large integer.
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlConvertUlongToLargeInteger (
    ULONG UnsignedInteger
    );


//
// Large integer shift routines.
//

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlLargeIntegerShiftLeft (
    LARGE_INTEGER LargeInteger,
    CCHAR ShiftCount
    );

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlLargeIntegerShiftRight (
    LARGE_INTEGER LargeInteger,
    CCHAR ShiftCount
    );

NTSYSAPI
LARGE_INTEGER
NTAPI
RtlLargeIntegerArithmeticShift (
    LARGE_INTEGER LargeInteger,
    CCHAR ShiftCount
    );

#else

#if _MSC_VER >= 1200
#pragma warning(push)
#endif
#pragma warning(disable:4035)               // re-enable below

//
// Convert signed integer to large integer.
//

__inline LARGE_INTEGER
NTAPI
RtlConvertLongToLargeInteger (
    LONG SignedInteger
    )
{
    __asm {
        mov     eax, SignedInteger
        cdq                 ; (edx:eax) = signed LargeInt
    }
}

//
// Convert unsigned integer to large integer.
//

__inline LARGE_INTEGER
NTAPI
RtlConvertUlongToLargeInteger (
    ULONG UnsignedInteger
    )
{
    __asm {
        sub     edx, edx    ; zero highpart
        mov     eax, UnsignedInteger
    }
}

//
// Large integer shift routines.
//

__inline LARGE_INTEGER
NTAPI
RtlLargeIntegerShiftLeft (
    LARGE_INTEGER LargeInteger,
    CCHAR ShiftCount
    )
{
    __asm    {
        mov     cl, ShiftCount
        and     cl, 0x3f                    ; mod 64

        cmp     cl, 32
        jc      short sl10

        mov     edx, LargeInteger.LowPart   ; ShiftCount >= 32
        xor     eax, eax                    ; lowpart is zero
        shl     edx, cl                     ; store highpart
        jmp     short done

sl10:
        mov     eax, LargeInteger.LowPart   ; ShiftCount < 32
        mov     edx, LargeInteger.HighPart
        shld    edx, eax, cl
        shl     eax, cl
done:
    }
}


__inline LARGE_INTEGER
NTAPI
RtlLargeIntegerShiftRight (
    LARGE_INTEGER LargeInteger,
    CCHAR ShiftCount
    )
{
    __asm    {
        mov     cl, ShiftCount
        and     cl, 0x3f               ; mod 64

        cmp     cl, 32
        jc      short sr10

        mov     eax, LargeInteger.HighPart  ; ShiftCount >= 32
        xor     edx, edx                    ; lowpart is zero
        shr     eax, cl                     ; store highpart
        jmp     short done

sr10:
        mov     eax, LargeInteger.LowPart   ; ShiftCount < 32
        mov     edx, LargeInteger.HighPart
        shrd    eax, edx, cl
        shr     edx, cl
done:
    }
}


__inline LARGE_INTEGER
NTAPI
RtlLargeIntegerArithmeticShift (
    LARGE_INTEGER LargeInteger,
    CCHAR ShiftCount
    )
{
    __asm {
        mov     cl, ShiftCount
        and     cl, 3fh                 ; mod 64

        cmp     cl, 32
        jc      short sar10

        mov     eax, LargeInteger.HighPart
        sar     eax, cl
        bt      eax, 31                     ; sign bit set?
        sbb     edx, edx                    ; duplicate sign bit into highpart
        jmp     short done
sar10:
        mov     eax, LargeInteger.LowPart   ; (eax) = LargeInteger.LowPart
        mov     edx, LargeInteger.HighPart  ; (edx) = LargeInteger.HighPart
        shrd    eax, edx, cl
        sar     edx, cl
done:
    }
}

#if _MSC_VER >= 1200
#pragma warning(pop)
#else
#pragma warning(default:4035)
#endif

#endif

//
// Large integer comparison routines.
//
// BOOLEAN
// RtlLargeIntegerGreaterThan (
//     LARGE_INTEGER Operand1,
//     LARGE_INTEGER Operand2
//     );
//
// BOOLEAN
// RtlLargeIntegerGreaterThanOrEqualTo (
//     LARGE_INTEGER Operand1,
//     LARGE_INTEGER Operand2
//     );
//
// BOOLEAN
// RtlLargeIntegerEqualTo (
//     LARGE_INTEGER Operand1,
//     LARGE_INTEGER Operand2
//     );
//
// BOOLEAN
// RtlLargeIntegerNotEqualTo (
//     LARGE_INTEGER Operand1,
//     LARGE_INTEGER Operand2
//     );
//
// BOOLEAN
// RtlLargeIntegerLessThan (
//     LARGE_INTEGER Operand1,
//     LARGE_INTEGER Operand2
//     );
//
// BOOLEAN
// RtlLargeIntegerLessThanOrEqualTo (
//     LARGE_INTEGER Operand1,
//     LARGE_INTEGER Operand2
//     );
//
// BOOLEAN
// RtlLargeIntegerGreaterThanZero (
//     LARGE_INTEGER Operand
//     );
//
// BOOLEAN
// RtlLargeIntegerGreaterOrEqualToZero (
//     LARGE_INTEGER Operand
//     );
//
// BOOLEAN
// RtlLargeIntegerEqualToZero (
//     LARGE_INTEGER Operand
//     );
//
// BOOLEAN
// RtlLargeIntegerNotEqualToZero (
//     LARGE_INTEGER Operand
//     );
//
// BOOLEAN
// RtlLargeIntegerLessThanZero (
//     LARGE_INTEGER Operand
//     );
//
// BOOLEAN
// RtlLargeIntegerLessOrEqualToZero (
//     LARGE_INTEGER Operand
//     );
//

#define RtlLargeIntegerGreaterThan(X,Y) (                              \
    (((X).HighPart == (Y).HighPart) && ((X).LowPart > (Y).LowPart)) || \
    ((X).HighPart > (Y).HighPart)                                      \
)

#define RtlLargeIntegerGreaterThanOrEqualTo(X,Y) (                      \
    (((X).HighPart == (Y).HighPart) && ((X).LowPart >= (Y).LowPart)) || \
    ((X).HighPart > (Y).HighPart)                                       \
)

#define RtlLargeIntegerEqualTo(X,Y) (                              \
    !(((X).LowPart ^ (Y).LowPart) | ((X).HighPart ^ (Y).HighPart)) \
)

#define RtlLargeIntegerNotEqualTo(X,Y) (                          \
    (((X).LowPart ^ (Y).LowPart) | ((X).HighPart ^ (Y).HighPart)) \
)

#define RtlLargeIntegerLessThan(X,Y) (                                 \
    (((X).HighPart == (Y).HighPart) && ((X).LowPart < (Y).LowPart)) || \
    ((X).HighPart < (Y).HighPart)                                      \
)

#define RtlLargeIntegerLessThanOrEqualTo(X,Y) (                         \
    (((X).HighPart == (Y).HighPart) && ((X).LowPart <= (Y).LowPart)) || \
    ((X).HighPart < (Y).HighPart)                                       \
)

#define RtlLargeIntegerGreaterThanZero(X) (       \
    (((X).HighPart == 0) && ((X).LowPart > 0)) || \
    ((X).HighPart > 0 )                           \
)

#define RtlLargeIntegerGreaterOrEqualToZero(X) ( \
    (X).HighPart >= 0                            \
)

#define RtlLargeIntegerEqualToZero(X) ( \
    !((X).LowPart | (X).HighPart)       \
)

#define RtlLargeIntegerNotEqualToZero(X) ( \
    ((X).LowPart | (X).HighPart)           \
)

#define RtlLargeIntegerLessThanZero(X) ( \
    ((X).HighPart < 0)                   \
)

#define RtlLargeIntegerLessOrEqualToZero(X) (           \
    ((X).HighPart < 0) || !((X).LowPart | (X).HighPart) \
)


//
//  Time conversion routines
//

NTSYSAPI
VOID
NTAPI
RtlTimeToTimeFields (
    PLARGE_INTEGER Time,
    PTIME_FIELDS TimeFields
    );

//
//  A time field record (Weekday ignored) -> 64 bit Time value
//

NTSYSAPI
BOOLEAN
NTAPI
RtlTimeFieldsToTime (
    PTIME_FIELDS TimeFields,
    PLARGE_INTEGER Time
    );

//
// The following macros store and retrieve USHORTS and ULONGS from potentially
// unaligned addresses, avoiding alignment faults.  they should probably be
// rewritten in assembler
//

#define SHORT_SIZE  (sizeof(USHORT))
#define SHORT_MASK  (SHORT_SIZE - 1)
#define LONG_SIZE       (sizeof(LONG))
#define LONGLONG_SIZE   (sizeof(LONGLONG))
#define LONG_MASK       (LONG_SIZE - 1)
#define LONGLONG_MASK   (LONGLONG_SIZE - 1)
#define LOWBYTE_MASK 0x00FF

#define FIRSTBYTE(VALUE)  ((VALUE) & LOWBYTE_MASK)
#define SECONDBYTE(VALUE) (((VALUE) >> 8) & LOWBYTE_MASK)
#define THIRDBYTE(VALUE)  (((VALUE) >> 16) & LOWBYTE_MASK)
#define FOURTHBYTE(VALUE) (((VALUE) >> 24) & LOWBYTE_MASK)

//
// if MIPS Big Endian, order of bytes is reversed.
//

#define SHORT_LEAST_SIGNIFICANT_BIT  0
#define SHORT_MOST_SIGNIFICANT_BIT   1

#define LONG_LEAST_SIGNIFICANT_BIT       0
#define LONG_3RD_MOST_SIGNIFICANT_BIT    1
#define LONG_2ND_MOST_SIGNIFICANT_BIT    2
#define LONG_MOST_SIGNIFICANT_BIT        3

//++
//
// VOID
// RtlStoreUshort (
//     PUSHORT ADDRESS
//     USHORT VALUE
//     )
//
// Routine Description:
//
// This macro stores a USHORT value in at a particular address, avoiding
// alignment faults.
//
// Arguments:
//
//     ADDRESS - where to store USHORT value
//     VALUE - USHORT to store
//
// Return Value:
//
//     none.
//
//--

#define RtlStoreUshort(ADDRESS,VALUE)                     \
         if ((ULONG_PTR)(ADDRESS) & SHORT_MASK) {         \
             ((PUCHAR) (ADDRESS))[SHORT_LEAST_SIGNIFICANT_BIT] = (UCHAR)(FIRSTBYTE(VALUE));    \
             ((PUCHAR) (ADDRESS))[SHORT_MOST_SIGNIFICANT_BIT ] = (UCHAR)(SECONDBYTE(VALUE));   \
         }                                                \
         else {                                           \
             *((PUSHORT) (ADDRESS)) = (USHORT) VALUE;     \
         }


//++
//
// VOID
// RtlStoreUlong (
//     PULONG ADDRESS
//     ULONG VALUE
//     )
//
// Routine Description:
//
// This macro stores a ULONG value in at a particular address, avoiding
// alignment faults.
//
// Arguments:
//
//     ADDRESS - where to store ULONG value
//     VALUE - ULONG to store
//
// Return Value:
//
//     none.
//
// Note:
//     Depending on the machine, we might want to call storeushort in the
//     unaligned case.
//
//--

#define RtlStoreUlong(ADDRESS,VALUE)                      \
         if ((ULONG_PTR)(ADDRESS) & LONG_MASK) {          \
             ((PUCHAR) (ADDRESS))[LONG_LEAST_SIGNIFICANT_BIT      ] = (UCHAR)(FIRSTBYTE(VALUE));    \
             ((PUCHAR) (ADDRESS))[LONG_3RD_MOST_SIGNIFICANT_BIT   ] = (UCHAR)(SECONDBYTE(VALUE));   \
             ((PUCHAR) (ADDRESS))[LONG_2ND_MOST_SIGNIFICANT_BIT   ] = (UCHAR)(THIRDBYTE(VALUE));    \
             ((PUCHAR) (ADDRESS))[LONG_MOST_SIGNIFICANT_BIT       ] = (UCHAR)(FOURTHBYTE(VALUE));   \
         }                                                \
         else {                                           \
             *((PULONG) (ADDRESS)) = (ULONG) (VALUE);     \
         }

//++
//
// VOID
// RtlStoreUlonglong (
//     PULONGLONG ADDRESS
//     ULONG VALUE
//     )
//
// Routine Description:
//
// This macro stores a ULONGLONG value in at a particular address, avoiding
// alignment faults.
//
// Arguments:
//
//     ADDRESS - where to store ULONGLONG value
//     VALUE - ULONGLONG to store
//
// Return Value:
//
//     none.
//
//--

#define RtlStoreUlonglong(ADDRESS,VALUE)                        \
         if ((ULONG_PTR)(ADDRESS) & LONGLONG_MASK) {            \
             RtlStoreUlong((ULONG_PTR)(ADDRESS),                \
                           (ULONGLONG)(VALUE) & 0xFFFFFFFF);    \
             RtlStoreUlong((ULONG_PTR)(ADDRESS)+sizeof(ULONG),  \
                           (ULONGLONG)(VALUE) >> 32);           \
         } else {                                               \
             *((PULONGLONG)(ADDRESS)) = (ULONGLONG)(VALUE);     \
         }

//++
//
// VOID
// RtlStoreUlongPtr (
//     PULONG_PTR ADDRESS
//     ULONG_PTR VALUE
//     )
//
// Routine Description:
//
// This macro stores a ULONG_PTR value in at a particular address, avoiding
// alignment faults.
//
// Arguments:
//
//     ADDRESS - where to store ULONG_PTR value
//     VALUE - ULONG_PTR to store
//
// Return Value:
//
//     none.
//
//--

#ifdef _WIN64

#define RtlStoreUlongPtr(ADDRESS,VALUE)                         \
         RtlStoreUlonglong(ADDRESS,VALUE)

#else

#define RtlStoreUlongPtr(ADDRESS,VALUE)                         \
         RtlStoreUlong(ADDRESS,VALUE)

#endif

//++
//
// VOID
// RtlRetrieveUshort (
//     PUSHORT DESTINATION_ADDRESS
//     PUSHORT SOURCE_ADDRESS
//     )
//
// Routine Description:
//
// This macro retrieves a USHORT value from the SOURCE address, avoiding
// alignment faults.  The DESTINATION address is assumed to be aligned.
//
// Arguments:
//
//     DESTINATION_ADDRESS - where to store USHORT value
//     SOURCE_ADDRESS - where to retrieve USHORT value from
//
// Return Value:
//
//     none.
//
//--

#define RtlRetrieveUshort(DEST_ADDRESS,SRC_ADDRESS)                   \
         if ((ULONG_PTR)SRC_ADDRESS & SHORT_MASK) {                       \
             ((PUCHAR) DEST_ADDRESS)[0] = ((PUCHAR) SRC_ADDRESS)[0];  \
             ((PUCHAR) DEST_ADDRESS)[1] = ((PUCHAR) SRC_ADDRESS)[1];  \
         }                                                            \
         else {                                                       \
             *((PUSHORT) DEST_ADDRESS) = *((PUSHORT) SRC_ADDRESS);    \
         }                                                            \

//++
//
// VOID
// RtlRetrieveUlong (
//     PULONG DESTINATION_ADDRESS
//     PULONG SOURCE_ADDRESS
//     )
//
// Routine Description:
//
// This macro retrieves a ULONG value from the SOURCE address, avoiding
// alignment faults.  The DESTINATION address is assumed to be aligned.
//
// Arguments:
//
//     DESTINATION_ADDRESS - where to store ULONG value
//     SOURCE_ADDRESS - where to retrieve ULONG value from
//
// Return Value:
//
//     none.
//
// Note:
//     Depending on the machine, we might want to call retrieveushort in the
//     unaligned case.
//
//--

#define RtlRetrieveUlong(DEST_ADDRESS,SRC_ADDRESS)                    \
         if ((ULONG_PTR)SRC_ADDRESS & LONG_MASK) {                        \
             ((PUCHAR) DEST_ADDRESS)[0] = ((PUCHAR) SRC_ADDRESS)[0];  \
             ((PUCHAR) DEST_ADDRESS)[1] = ((PUCHAR) SRC_ADDRESS)[1];  \
             ((PUCHAR) DEST_ADDRESS)[2] = ((PUCHAR) SRC_ADDRESS)[2];  \
             ((PUCHAR) DEST_ADDRESS)[3] = ((PUCHAR) SRC_ADDRESS)[3];  \
         }                                                            \
         else {                                                       \
             *((PULONG) DEST_ADDRESS) = *((PULONG) SRC_ADDRESS);      \
         }
//
//  BitMap routines.  The following structure, routines, and macros are
//  for manipulating bitmaps.  The user is responsible for allocating a bitmap
//  structure (which is really a header) and a buffer (which must be longword
//  aligned and multiple longwords in size).
//
//
//  The following routine initializes a new bitmap.  It does not alter the
//  data currently in the bitmap.  This routine must be called before
//  any other bitmap routine/macro.
//

NTSYSAPI
VOID
NTAPI
RtlInitializeBitMap (
    PRTL_BITMAP BitMapHeader,
    PULONG BitMapBuffer,
    ULONG SizeOfBitMap
    );

//
//  The following two routines either clear or set all of the bits
//  in a bitmap.
//

NTSYSAPI
VOID
NTAPI
RtlClearAllBits (
    PRTL_BITMAP BitMapHeader
    );

NTSYSAPI
VOID
NTAPI
RtlSetAllBits (
    PRTL_BITMAP BitMapHeader
    );

//
//  The following two routines locate a contiguous region of either
//  clear or set bits within the bitmap.  The region will be at least
//  as large as the number specified, and the search of the bitmap will
//  begin at the specified hint index (which is a bit index within the
//  bitmap, zero based).  The return value is the bit index of the located
//  region (zero based) or -1 (i.e., 0xffffffff) if such a region cannot
//  be located
//

NTSYSAPI
ULONG
NTAPI
RtlFindClearBits (
    PRTL_BITMAP BitMapHeader,
    ULONG NumberToFind,
    ULONG HintIndex
    );

NTSYSAPI
ULONG
NTAPI
RtlFindSetBits (
    PRTL_BITMAP BitMapHeader,
    ULONG NumberToFind,
    ULONG HintIndex
    );

//
//  The following two routines locate a contiguous region of either
//  clear or set bits within the bitmap and either set or clear the bits
//  within the located region.  The region will be as large as the number
//  specified, and the search for the region will begin at the specified
//  hint index (which is a bit index within the bitmap, zero based).  The
//  return value is the bit index of the located region (zero based) or
//  -1 (i.e., 0xffffffff) if such a region cannot be located.  If a region
//  cannot be located then the setting/clearing of the bitmap is not performed.
//

NTSYSAPI
ULONG
NTAPI
RtlFindClearBitsAndSet (
    PRTL_BITMAP BitMapHeader,
    ULONG NumberToFind,
    ULONG HintIndex
    );

NTSYSAPI
ULONG
NTAPI
RtlFindSetBitsAndClear (
    PRTL_BITMAP BitMapHeader,
    ULONG NumberToFind,
    ULONG HintIndex
    );

//
//  The following two routines clear or set bits within a specified region
//  of the bitmap.  The starting index is zero based.
//

NTSYSAPI
VOID
NTAPI
RtlClearBits (
    PRTL_BITMAP BitMapHeader,
    ULONG StartingIndex,
    ULONG NumberToClear
    );

NTSYSAPI
VOID
NTAPI
RtlSetBits (
    PRTL_BITMAP BitMapHeader,
    ULONG StartingIndex,
    ULONG NumberToSet
    );

#if _WIN32_WINNT >= 0x0501

NTSYSAPI
VOID
NTAPI
RtlClearBit (
    PRTL_BITMAP BitMapHeader,
    ULONG BitNumber
    );

NTSYSAPI
VOID
NTAPI
RtlSetBit (
    PRTL_BITMAP BitMapHeader,
    ULONG BitNumber
    );

#endif

//
//  The following routine locates a set of contiguous regions of clear
//  bits within the bitmap.  The caller specifies whether to return the
//  longest runs or just the first found lcoated.  The following structure is
//  used to denote a contiguous run of bits.  The two routines return an array
//  of this structure, one for each run located.
//

typedef struct _RTL_BITMAP_RUN {

    ULONG StartingIndex;
    ULONG NumberOfBits;

} RTL_BITMAP_RUN;
typedef RTL_BITMAP_RUN *PRTL_BITMAP_RUN;

NTSYSAPI
ULONG
NTAPI
RtlFindClearRuns (
    PRTL_BITMAP BitMapHeader,
    PRTL_BITMAP_RUN RunArray,
    ULONG SizeOfRunArray,
    BOOLEAN LocateLongestRuns
    );

//
//  The following routine locates the longest contiguous region of
//  clear bits within the bitmap.  The returned starting index value
//  denotes the first contiguous region located satisfying our requirements
//  The return value is the length (in bits) of the longest region found.
//

NTSYSAPI
ULONG
NTAPI
RtlFindLongestRunClear (
    PRTL_BITMAP BitMapHeader,
    PULONG StartingIndex
    );

//
//  The following routine locates the first contiguous region of
//  clear bits within the bitmap.  The returned starting index value
//  denotes the first contiguous region located satisfying our requirements
//  The return value is the length (in bits) of the region found.
//

NTSYSAPI
ULONG
NTAPI
RtlFindFirstRunClear (
    PRTL_BITMAP BitMapHeader,
    PULONG StartingIndex
    );

//
//  The following macro returns the value of the bit stored within the
//  bitmap at the specified location.  If the bit is set a value of 1 is
//  returned otherwise a value of 0 is returned.
//
//      ULONG
//      RtlCheckBit (
//          PRTL_BITMAP BitMapHeader,
//          ULONG BitPosition
//          );
//
//
//  To implement CheckBit the macro retrieves the longword containing the
//  bit in question, shifts the longword to get the bit in question into the
//  low order bit position and masks out all other bits.
//

#define RtlCheckBit(BMH,BP) ((((BMH)->Buffer[(BP) / 32]) >> ((BP) % 32)) & 0x1)

//
//  The following two procedures return to the caller the total number of
//  clear or set bits within the specified bitmap.
//

NTSYSAPI
ULONG
NTAPI
RtlNumberOfClearBits (
    PRTL_BITMAP BitMapHeader
    );

NTSYSAPI
ULONG
NTAPI
RtlNumberOfSetBits (
    PRTL_BITMAP BitMapHeader
    );

//
//  The following two procedures return to the caller a boolean value
//  indicating if the specified range of bits are all clear or set.
//

NTSYSAPI
BOOLEAN
NTAPI
RtlAreBitsClear (
    PRTL_BITMAP BitMapHeader,
    ULONG StartingIndex,
    ULONG Length
    );

NTSYSAPI
BOOLEAN
NTAPI
RtlAreBitsSet (
    PRTL_BITMAP BitMapHeader,
    ULONG StartingIndex,
    ULONG Length
    );

NTSYSAPI
ULONG
NTAPI
RtlFindNextForwardRunClear (
    IN PRTL_BITMAP BitMapHeader,
    IN ULONG FromIndex,
    IN PULONG StartingRunIndex
    );

NTSYSAPI
ULONG
NTAPI
RtlFindLastBackwardRunClear (
    IN PRTL_BITMAP BitMapHeader,
    IN ULONG FromIndex,
    IN PULONG StartingRunIndex
    );

//
//  The following two procedures return to the caller a value indicating
//  the position within a ULONGLONG of the most or least significant non-zero
//  bit.  A value of zero results in a return value of -1.
//

NTSYSAPI
CCHAR
NTAPI
RtlFindLeastSignificantBit (
    IN ULONGLONG Set
    );

NTSYSAPI
CCHAR
NTAPI
RtlFindMostSignificantBit (
    IN ULONGLONG Set
    );


//
// BOOLEAN
// RtlEqualLuid(
//      PLUID L1,
//      PLUID L2
//      );

#define RtlEqualLuid(L1, L2) (((L1)->LowPart == (L2)->LowPart) && \
                              ((L1)->HighPart  == (L2)->HighPart))

//
// BOOLEAN
// RtlIsZeroLuid(
//      PLUID L1
//      );
//
#define RtlIsZeroLuid(L1) ((BOOLEAN) (((L1)->LowPart | (L1)->HighPart) == 0))


#if !defined(MIDL_PASS)

__inline LUID
NTAPI
RtlConvertLongToLuid(
    LONG Long
    )
{
    LUID TempLuid;
    LARGE_INTEGER TempLi;

    TempLi = RtlConvertLongToLargeInteger(Long);
    TempLuid.LowPart = TempLi.LowPart;
    TempLuid.HighPart = TempLi.HighPart;
    return(TempLuid);
}

__inline LUID
NTAPI
RtlConvertUlongToLuid(
    ULONG Ulong
    )
{
    LUID TempLuid;

    TempLuid.LowPart = Ulong;
    TempLuid.HighPart = 0;
    return(TempLuid);
}
#endif


NTSYSAPI
VOID
NTAPI
RtlMapGenericMask(
    PACCESS_MASK AccessMask,
    PGENERIC_MAPPING GenericMapping
    );
//
//  SecurityDescriptor RTL routine definitions
//

NTSYSAPI
NTSTATUS
NTAPI
RtlCreateSecurityDescriptor (
    IN OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
    IN ULONG Revision
    );

// RtlCreateSecurityDescriptorRelative initializes a new security descriptor in self-relative
// format. On return, the security descriptor is initialized with no system ACL (SACL), no
// discretionary ACL (DACL), no owner, no primary group, and all control flags set to zero.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateSecurityDescriptorRelative(
	IN PISECURITY_DESCRIPTOR_RELATIVE SecurityDescriptor,
	IN ULONG Revision
	);

// RtlCreateAndSetSD builds a new security descriptor with the specified components.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateAndSetSD(
	IN PRTL_ACE_DATA AceData,
	IN ULONG AceCount,
	IN PSID OwnerSid OPTIONAL,
	IN PSID GroupSid OPTIONAL,
	OUT PSECURITY_DESCRIPTOR *NewDescriptor
	);

// RtlDeleteSecurityObject deletes a Security Descriptor allocated by one of the RTL routines.
NTSYSAPI
NTSTATUS
NTAPI
RtlDeleteSecurityObject(
	IN OUT PSECURITY_DESCRIPTOR * ObjectDescriptor
	);

NTSYSAPI
BOOLEAN
NTAPI
RtlValidSecurityDescriptor (
    IN PSECURITY_DESCRIPTOR SecurityDescriptor
    );


NTSYSAPI
ULONG
NTAPI
RtlLengthSecurityDescriptor (
    IN PSECURITY_DESCRIPTOR SecurityDescriptor
    );

NTSYSAPI
BOOLEAN
NTAPI
RtlValidRelativeSecurityDescriptor (
    IN PSECURITY_DESCRIPTOR SecurityDescriptorInput,
    IN ULONG SecurityDescriptorLength,
    IN SECURITY_INFORMATION RequiredInformation
    );

// RtlSetDaclSecurityDescriptor sets a security descriptor's DACL.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetDaclSecurityDescriptor (
    IN OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
    IN BOOLEAN DaclPresent,
    IN PACL Dacl OPTIONAL,
    IN BOOLEAN DaclDefaulted OPTIONAL
    );

// RtlSetSaclSecurityDescriptor sets a security descriptor's SACL.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetSaclSecurityDescriptor (
    IN OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
    IN BOOLEAN SaclPresent,
    IN PACL Sacl OPTIONAL,
    IN BOOLEAN SaclDefaulted OPTIONAL
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlQueryInformationAcl(
	IN PACL Acl,
	OUT PVOID AclInformation,
	IN ULONG AclInformationLength,
	IN ACL_INFORMATION_CLASS AclInformationClass
	);


//
// Range list package
//

typedef struct _RTL_RANGE {

    //
    // The start of the range
    //
    ULONGLONG Start;    // Read only

    //
    // The end of the range
    //
    ULONGLONG End;      // Read only

    //
    // Data the user passed in when they created the range
    //
    PVOID UserData;     // Read/Write

    //
    // The owner of the range
    //
    PVOID Owner;        // Read/Write

    //
    // User defined flags the user specified when they created the range
    //
    UCHAR Attributes;    // Read/Write

    //
    // Flags (RTL_RANGE_*)
    //
    UCHAR Flags;       // Read only

} RTL_RANGE, *PRTL_RANGE;


#define RTL_RANGE_SHARED    0x01
#define RTL_RANGE_CONFLICT  0x02

typedef struct _RTL_RANGE_LIST {

    //
    // The list of ranges
    //
    LIST_ENTRY ListHead;

    //
    // These always come in useful
    //
    ULONG Flags;        // use RANGE_LIST_FLAG_*

    //
    // The number of entries in the list
    //
    ULONG Count;

    //
    // Every time an add/delete operation is performed on the list this is
    // incremented.  It is checked during iteration to ensure that the list
    // hasn't changed between GetFirst/GetNext or GetNext/GetNext calls
    //
    ULONG Stamp;

} RTL_RANGE_LIST, *PRTL_RANGE_LIST;

typedef struct _RANGE_LIST_ITERATOR {

    PLIST_ENTRY RangeListHead;
    PLIST_ENTRY MergedHead;
    PVOID Current;
    ULONG Stamp;

} RTL_RANGE_LIST_ITERATOR, *PRTL_RANGE_LIST_ITERATOR;


NTSYSAPI
VOID
NTAPI
RtlInitializeRangeList(
    IN OUT PRTL_RANGE_LIST RangeList
    );

NTSYSAPI
VOID
NTAPI
RtlFreeRangeList(
    IN PRTL_RANGE_LIST RangeList
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlCopyRangeList(
    OUT PRTL_RANGE_LIST CopyRangeList,
    IN PRTL_RANGE_LIST RangeList
    );

#define RTL_RANGE_LIST_ADD_IF_CONFLICT      0x00000001
#define RTL_RANGE_LIST_ADD_SHARED           0x00000002

NTSYSAPI
NTSTATUS
NTAPI
RtlAddRange(
    IN OUT PRTL_RANGE_LIST RangeList,
    IN ULONGLONG Start,
    IN ULONGLONG End,
    IN UCHAR Attributes,
    IN ULONG Flags,
    IN PVOID UserData,  OPTIONAL
    IN PVOID Owner      OPTIONAL
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlDeleteRange(
    IN OUT PRTL_RANGE_LIST RangeList,
    IN ULONGLONG Start,
    IN ULONGLONG End,
    IN PVOID Owner
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlDeleteOwnersRanges(
    IN OUT PRTL_RANGE_LIST RangeList,
    IN PVOID Owner
    );

#define RTL_RANGE_LIST_SHARED_OK           0x00000001
#define RTL_RANGE_LIST_NULL_CONFLICT_OK    0x00000002

typedef
BOOLEAN
(*PRTL_CONFLICT_RANGE_CALLBACK) (
    IN PVOID Context,
    IN PRTL_RANGE Range
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlFindRange(
    IN PRTL_RANGE_LIST RangeList,
    IN ULONGLONG Minimum,
    IN ULONGLONG Maximum,
    IN ULONG Length,
    IN ULONG Alignment,
    IN ULONG Flags,
    IN UCHAR AttributeAvailableMask,
    IN PVOID Context OPTIONAL,
    IN PRTL_CONFLICT_RANGE_CALLBACK Callback OPTIONAL,
    OUT PULONGLONG Start
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlIsRangeAvailable(
    IN PRTL_RANGE_LIST RangeList,
    IN ULONGLONG Start,
    IN ULONGLONG End,
    IN ULONG Flags,
    IN UCHAR AttributeAvailableMask,
    IN PVOID Context OPTIONAL,
    IN PRTL_CONFLICT_RANGE_CALLBACK Callback OPTIONAL,
    OUT PBOOLEAN Available
    );

#define FOR_ALL_RANGES(RangeList, Iterator, Current)            \
    for (RtlGetFirstRange((RangeList), (Iterator), &(Current)); \
         (Current) != NULL;                                     \
         RtlGetNextRange((Iterator), &(Current), TRUE)          \
         )

#define FOR_ALL_RANGES_BACKWARDS(RangeList, Iterator, Current)  \
    for (RtlGetLastRange((RangeList), (Iterator), &(Current));  \
         (Current) != NULL;                                     \
         RtlGetNextRange((Iterator), &(Current), FALSE)         \
         )

NTSYSAPI
NTSTATUS
NTAPI
RtlGetFirstRange(
    IN PRTL_RANGE_LIST RangeList,
    OUT PRTL_RANGE_LIST_ITERATOR Iterator,
    OUT PRTL_RANGE *Range
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlGetLastRange(
    IN PRTL_RANGE_LIST RangeList,
    OUT PRTL_RANGE_LIST_ITERATOR Iterator,
    OUT PRTL_RANGE *Range
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlGetNextRange(
    IN OUT PRTL_RANGE_LIST_ITERATOR Iterator,
    OUT PRTL_RANGE *Range,
    IN BOOLEAN MoveForwards
    );

#define RTL_RANGE_LIST_MERGE_IF_CONFLICT    RTL_RANGE_LIST_ADD_IF_CONFLICT

NTSYSAPI
NTSTATUS
NTAPI
RtlMergeRangeLists(
    OUT PRTL_RANGE_LIST MergedRangeList,
    IN PRTL_RANGE_LIST RangeList1,
    IN PRTL_RANGE_LIST RangeList2,
    IN ULONG Flags
    );

NTSYSAPI
NTSTATUS
NTAPI
RtlInvertRangeList(
    OUT PRTL_RANGE_LIST InvertedRangeList,
    IN PRTL_RANGE_LIST RangeList
    );

// end_nthal

// begin_wdm

//
// Byte swap routines.  These are used to convert from little-endian to
// big-endian and vice-versa.
//

#if 0
USHORT
FASTCALL
RtlUshortByteSwap(
    IN USHORT Source
    );

ULONG
FASTCALL
RtlUlongByteSwap(
    IN ULONG Source
    );

ULONGLONG
FASTCALL
RtlUlonglongByteSwap(
    IN ULONGLONG Source
    );
#endif


//
// Routine for converting from a volume device object to a DOS name.
//

NTSYSAPI
NTSTATUS
NTAPI
RtlVolumeDeviceToDosName(
    IN  PVOID           VolumeDeviceObject,
    OUT PUNICODE_STRING DosName
    );

#ifndef _NTTYPES_NO_WINNT

typedef struct _OSVERSIONINFOA {
    ULONG dwOSVersionInfoSize;
    ULONG dwMajorVersion;
    ULONG dwMinorVersion;
    ULONG dwBuildNumber;
    ULONG dwPlatformId;
    CHAR   szCSDVersion[ 128 ];     // Maintenance string for PSS usage
} OSVERSIONINFOA, *POSVERSIONINFOA, *LPOSVERSIONINFOA;

typedef struct _OSVERSIONINFOW {
    ULONG dwOSVersionInfoSize;
    ULONG dwMajorVersion;
    ULONG dwMinorVersion;
    ULONG dwBuildNumber;
    ULONG dwPlatformId;
    WCHAR  szCSDVersion[ 128 ];     // Maintenance string for PSS usage
} OSVERSIONINFOW, *POSVERSIONINFOW, *LPOSVERSIONINFOW, RTL_OSVERSIONINFOW, *PRTL_OSVERSIONINFOW;
#ifdef UNICODE
typedef OSVERSIONINFOW OSVERSIONINFO;
typedef POSVERSIONINFOW POSVERSIONINFO;
typedef LPOSVERSIONINFOW LPOSVERSIONINFO;
#else
typedef OSVERSIONINFOA OSVERSIONINFO;
typedef POSVERSIONINFOA POSVERSIONINFO;
typedef LPOSVERSIONINFOA LPOSVERSIONINFO;
#endif // UNICODE

typedef struct _OSVERSIONINFOEXA {
    ULONG dwOSVersionInfoSize;
    ULONG dwMajorVersion;
    ULONG dwMinorVersion;
    ULONG dwBuildNumber;
    ULONG dwPlatformId;
    CHAR   szCSDVersion[ 128 ];     // Maintenance string for PSS usage
    USHORT wServicePackMajor;
    USHORT wServicePackMinor;
    USHORT wSuiteMask;
    UCHAR wProductType;
    UCHAR wReserved;
} OSVERSIONINFOEXA, *POSVERSIONINFOEXA, *LPOSVERSIONINFOEXA;
typedef struct _OSVERSIONINFOEXW {
    ULONG dwOSVersionInfoSize;
    ULONG dwMajorVersion;
    ULONG dwMinorVersion;
    ULONG dwBuildNumber;
    ULONG dwPlatformId;
    WCHAR  szCSDVersion[ 128 ];     // Maintenance string for PSS usage
    USHORT wServicePackMajor;
    USHORT wServicePackMinor;
    USHORT wSuiteMask;
    UCHAR wProductType;
    UCHAR wReserved;
} OSVERSIONINFOEXW, *POSVERSIONINFOEXW, *LPOSVERSIONINFOEXW, RTL_OSVERSIONINFOEXW, *PRTL_OSVERSIONINFOEXW;
#ifdef UNICODE
typedef OSVERSIONINFOEXW OSVERSIONINFOEX;
typedef POSVERSIONINFOEXW POSVERSIONINFOEX;
typedef LPOSVERSIONINFOEXW LPOSVERSIONINFOEX;
#else
typedef OSVERSIONINFOEXA OSVERSIONINFOEX;
typedef POSVERSIONINFOEXA POSVERSIONINFOEX;
typedef LPOSVERSIONINFOEXA LPOSVERSIONINFOEX;
#endif // UNICODE

#ifdef __IDA__

typedef struct _OSVERSIONINFOW RTL_OSVERSIONINFOW;
typedef struct _OSVERSIONINFOW * PRTL_OSVERSIONINFOW;
//typedef RTL_OSVERSIONINFOW * PRTL_OSVERSIONINFOW;
typedef struct _OSVERSIONINFOEXW RTL_OSVERSIONINFOEXW;
typedef struct _OSVERSIONINFOEXW * PRTL_OSVERSIONINFOEXW;
//typedef RTL_OSVERSIONINFOEXW * PRTL_OSVERSIONINFOEXW;

#endif

//
// RtlVerifyVersionInfo() conditions
//

#define VER_EQUAL                       1
#define VER_GREATER                     2
#define VER_GREATER_EQUAL               3
#define VER_LESS                        4
#define VER_LESS_EQUAL                  5
#define VER_AND                         6
#define VER_OR                          7

#define VER_CONDITION_MASK              7
#define VER_NUM_BITS_PER_CONDITION_MASK 3

//
// RtlVerifyVersionInfo() type mask bits
//

#define VER_MINORVERSION                0x0000001
#define VER_MAJORVERSION                0x0000002
#define VER_BUILDNUMBER                 0x0000004
#define VER_PLATFORMID                  0x0000008
#define VER_SERVICEPACKMINOR            0x0000010
#define VER_SERVICEPACKMAJOR            0x0000020
#define VER_SUITENAME                   0x0000040
#define VER_PRODUCT_TYPE                0x0000080

//
// RtlVerifyVersionInfo() os product type values
//

#define VER_NT_WORKSTATION              0x0000001
#define VER_NT_DOMAIN_CONTROLLER        0x0000002
#define VER_NT_SERVER                   0x0000003

//
// dwPlatformId defines:
//

#define VER_PLATFORM_WIN32s             0
#define VER_PLATFORM_WIN32_WINDOWS      1
#define VER_PLATFORM_WIN32_NT           2


//
//
// VerifyVersionInfo() macro to set the condition mask
//
// For documentation sakes here's the old version of the macro that got
// changed to call an API
// #define VER_SET_CONDITION(_m_,_t_,_c_)  _m_=(_m_|(_c_<<(1<<_t_)))
//

#define VER_SET_CONDITION(_m_,_t_,_c_)  \
        ((_m_)=VerSetConditionMask((_m_),(_t_),(_c_)))

ULONGLONG
NTAPI
VerSetConditionMask(
        IN  ULONGLONG   ConditionMask,
        IN  ULONG   TypeMask,
        IN  UCHAR   Condition
        );
//
// end_winnt
//

#endif

#ifndef __IDA__

NTSYSAPI
NTSTATUS
RtlGetVersion(
    OUT PRTL_OSVERSIONINFOW lpVersionInformation
    );

NTSYSAPI
NTSTATUS
RtlVerifyVersionInfo(
    IN PRTL_OSVERSIONINFOEXW VersionInfo,
    IN ULONG TypeMask,
    IN ULONGLONG  ConditionMask
    );

#endif

NTSYSAPI
NTSTATUS
NTAPI
RtlAdjustPrivilege(
	IN ULONG Privilege,
	IN BOOLEAN Enable,
	IN ADJUST_PRIVILEGE_TYPE AdjType,
	OUT PBOOLEAN WasEnabled
	);

// RtlCreateUserProcess creates a new user mode process that is not associated with any subsystem.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateUserProcess(
    IN PUNICODE_STRING NtImagePathName,
    IN ULONG Attributes,
    IN PRTL_USER_PROCESS_PARAMETERS ProcessParameters,
    IN PSECURITY_DESCRIPTOR ProcessSecurityDescriptor OPTIONAL,
    IN PSECURITY_DESCRIPTOR ThreadSecurityDescriptor OPTIONAL,
    IN HANDLE ParentProcess OPTIONAL,
    IN BOOLEAN InheritHandles,
    IN HANDLE DebugPort OPTIONAL,
    IN HANDLE ExceptionPort OPTIONAL,
    OUT PRTL_USER_PROCESS_INFORMATION ProcessInformation
    );

// RtlCreateUserThread creates a new user mode thread that is not associated with any subsystem.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateUserThread(
	IN HANDLE hProcess,
	IN PVOID SecurityDescriptor OPTIONAL,
	IN BOOLEAN CreateSuspended,
	IN ULONG ZeroBits OPTIONAL,
	IN PULONG ReservedStackSize OPTIONAL,
	IN PULONG CommittedStackSize OPTIONAL,
	IN PVOID StartRoutine,
	IN PVOID Argument,
	OUT PHANDLE phThread OPTIONAL,
	OUT PCLIENT_ID ClientID OPTIONAL
	);

NTSYSAPI
DOS_PATHNAME_TYPE
NTAPI
RtlDetermineDosPathNameType_U(
	IN PCWSTR PathName
	);

NTSYSAPI
BOOLEAN
NTAPI
RtlDosPathNameToNtPathName_U(
	IN PCWSTR DosPathName,
	OUT PUNICODE_STRING NtPathName,
	OUT PWSTR* FilePartInNtPathName OPTIONAL,
	OUT PRELATIVE_NAME RelativeName OPTIONAL
	);

NTSYSAPI
NTSTATUS
NTAPI
RtlExpandEnvironmentStrings_U(
	IN PVOID EnvironmentBlock OPTIONAL,
	IN PUNICODE_STRING SourceString,
	OUT PUNICODE_STRING ExpandedString,
	OUT PULONG BytesRequired
	);

NTSYSAPI
NTSTATUS
NTAPI
RtlFindMessage(
	IN PVOID BaseAddress,
	IN ULONG Type,
	IN ULONG LanguageId,
	IN ULONG MessageId,
	OUT PRTL_MESSAGE_RESOURCE_ENTRY *MessageResourceEntry
	);

NTSYSAPI
NTSTATUS
NTAPI
RtlFreeUserThreadStack(
	IN HANDLE hProcess,
	IN HANDLE hThread
	);

// RtlDelete deletes the specified node from the splay link tree.
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlDelete(
	IN PRTL_SPLAY_LINKS Links
	);

// RtlDeleteNoSplay deletes the specified node from the splay link tree.
NTSYSAPI
VOID
NTAPI
RtlDeleteNoSplay(
	IN PRTL_SPLAY_LINKS Links,
	OUT PRTL_SPLAY_LINKS *Root
	);

// RtlDeleteElementGenericTable deletes an element from a generic table. 
NTSYSAPI
BOOLEAN
NTAPI
RtlDeleteElementGenericTable(
	IN PRTL_GENERIC_TABLE Table,
	IN PVOID Buffer
	);

// RtlDowncaseUnicodeString converts the specified Unicode source string to lowercase. The
// translation conforms to the current system locale information.
NTSYSAPI
NTSTATUS
NTAPI
RtlDowncaseUnicodeString(
	OUT PUNICODE_STRING DestinationString,
	IN PUNICODE_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlEnumerateGenericTable is used to enumerate the elements in a generic table.
NTSYSAPI
PVOID
NTAPI
RtlEnumerateGenericTable(
	IN PRTL_GENERIC_TABLE Table,
	IN BOOLEAN Restart
	);

// RtlEnumerateGenericTableWithoutSplaying is used to enumerate the elements in a generic table. 
NTSYSAPI
PVOID
NTAPI
RtlEnumerateGenericTableWithoutSplaying(
	IN PRTL_GENERIC_TABLE Table,
	IN PVOID *RestartKey
	);

// RtlEqualPrefixSid determines whether two security-identifier (SID) prefixes are equal. An SID
// prefix is the entire SID except for the last subauthority value. 
NTSYSAPI
BOOLEAN
NTAPI
RtlEqualPrefixSid(
	IN PSID Sid1,
	IN PSID Sid2
	);

// RtlFindUnicodePrefix searches for the best match for a given Unicode filename in a prefix table.
NTSYSAPI
PUNICODE_PREFIX_TABLE_ENTRY
NTAPI
RtlFindUnicodePrefix(
	IN PUNICODE_PREFIX_TABLE PrefixTable,
	IN PUNICODE_STRING FullName,
	IN ULONG CaseInsensitiveIndex
	);

// RtlFreeOemString releases storage that was allocated by any of the Rtl..ToOemString routines.
NTSYSAPI
VOID
NTAPI
RtlFreeOemString(
	IN POEM_STRING OemString
	);

// RtlGetAce obtains a pointer to an access control entry (ACE) in an access control list (ACL).
NTSYSAPI
NTSTATUS
NTAPI
RtlGetAce(
	IN PACL Acl,
	ULONG AceIndex,
	OUT PVOID *Ace
	);

// RtlGetElementGenericTable returns a pointer to the caller-supplied data for a particular
// element, selected by its index, in a generic table.
NTSYSAPI
VOID
NTAPI
RtlGetElementGenericTable(
	IN PRTL_GENERIC_TABLE Table,
	IN ULONG I
	);

// RtlInitializeGenericTable initializes a generic table.
NTSYSAPI
VOID
NTAPI
RtlInitializeGenericTable(
	IN PRTL_GENERIC_TABLE Table,
	IN PRTL_GENERIC_COMPARE_ROUTINE CompareRoutine,
	IN PRTL_GENERIC_ALLOCATE_ROUTINE AllocateRoutine,
	IN PRTL_GENERIC_FREE_ROUTINE FreeRoutine,
	IN PVOID TableContext
	);

// RtlInitializeSplayLinks initializes a splay link node.
/*
NTSYSAPI
VOID
NTAPI
RtlInitializeSplayLinks(
	IN PRTL_SPLAY_LINKS Links
	);
*/
//
//  The macro procedure InitializeSplayLinks takes as input a pointer to
//  splay link and initializes its substructure.  All splay link nodes must
//  be initialized before they are used in the different splay routines and
//  macros.
//
//  VOID
//  RtlInitializeSplayLinks (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlInitializeSplayLinks(Links) {    \
    PRTL_SPLAY_LINKS _SplayLinks;            \
    _SplayLinks = (PRTL_SPLAY_LINKS)(Links); \
    _SplayLinks->Parent = _SplayLinks;   \
    _SplayLinks->LeftChild = NULL;       \
    _SplayLinks->RightChild = NULL;      \
    }


// RtlInitializeUnicodePrefix initializes a prefix table.
NTSYSAPI
VOID
NTAPI
RtlInitializeUnicodePrefix(
	IN PUNICODE_PREFIX_TABLE PrefixTable
	);

// RtlInsertAsLeftChild inserts a splay link node into the tree as the left child of the
// specified node.
/*
NTSYSAPI
VOID
NTAPI
RtlInsertAsLeftChild(
	IN PRTL_SPLAY_LINKS ParentLinks,
	IN PRTL_SPLAY_LINKS ChildLinks
	);
*/
//
//  The macro procedure InsertAsLeftChild takes as input a pointer to a splay
//  link in a tree and a pointer to a node not in a tree.  It inserts the
//  second node as the left child of the first node.  The first node must not
//  already have a left child, and the second node must not already have a
//  parent.
//
//  VOID
//  RtlInsertAsLeftChild (
//      PRTL_SPLAY_LINKS ParentLinks,
//      PRTL_SPLAY_LINKS ChildLinks
//      );
//

#define RtlInsertAsLeftChild(ParentLinks,ChildLinks) { \
    PRTL_SPLAY_LINKS _SplayParent;                      \
    PRTL_SPLAY_LINKS _SplayChild;                       \
    _SplayParent = (PRTL_SPLAY_LINKS)(ParentLinks);     \
    _SplayChild = (PRTL_SPLAY_LINKS)(ChildLinks);       \
    _SplayParent->LeftChild = _SplayChild;          \
    _SplayChild->Parent = _SplayParent;             \
    }

// RtlInsertAsRightChild inserts a given splay link into the tree as the right child of
// a given node in that tree.
/*
NTSYSAPI
VOID
NTAPI
RtlInsertAsRightChild(
	IN PRTL_SPLAY_LINKS ParentLinks,
	IN PRTL_SPLAY_LINKS ChildLinks
	);
*/
//
//  The macro procedure InsertAsRightChild takes as input a pointer to a splay
//  link in a tree and a pointer to a node not in a tree.  It inserts the
//  second node as the right child of the first node.  The first node must not
//  already have a right child, and the second node must not already have a
//  parent.
//
//  VOID
//  RtlInsertAsRightChild (
//      PRTL_SPLAY_LINKS ParentLinks,
//      PRTL_SPLAY_LINKS ChildLinks
//      );
//

#define RtlInsertAsRightChild(ParentLinks,ChildLinks) { \
    PRTL_SPLAY_LINKS _SplayParent;                       \
    PRTL_SPLAY_LINKS _SplayChild;                        \
    _SplayParent = (PRTL_SPLAY_LINKS)(ParentLinks);      \
    _SplayChild = (PRTL_SPLAY_LINKS)(ChildLinks);        \
    _SplayParent->RightChild = _SplayChild;          \
    _SplayChild->Parent = _SplayParent;              \
    }

// RtlInsertElementGenericTable adds a new element to a generic table.
NTSYSAPI
PVOID
NTAPI
RtlInsertElementGenericTable(
	IN PRTL_GENERIC_TABLE Table,
	IN PVOID Buffer,
	IN CLONG BufferSize,
	OUT PBOOLEAN NewElement OPTIONAL
	);

// RtlInsertUnicodePrefix inserts a new element into a Unicode prefix table.
NTSYSAPI
BOOLEAN
NTAPI
RtlInsertUnicodePrefix(
	IN PUNICODE_PREFIX_TABLE PrefixTable,
	IN PUNICODE_STRING Prefix,
	IN PUNICODE_PREFIX_TABLE_ENTRY PrefixTableEntry
	);

// RtlIsGenericTableEmpty determines whether a generic table is empty.
NTSYSAPI
BOOLEAN
NTAPI
RtlIsGenericTableEmpty(
	IN PRTL_GENERIC_TABLE Table
	);

// RtlIsLeftChild determines whether a given splay link is the left child of a node in a splay
// link tree.
/*
NTSYSAPI
BOOLEAN
NTAPI
RtlIsLeftChild(
	IN PRTL_SPLAY_LINKS Links
	);
*/
//
//  The macro function IsLeftChild takes as input a pointer to a splay link
//  in a tree and returns TRUE if the input node is the left child of its
//  parent, otherwise it returns FALSE.
//
//  BOOLEAN
//  RtlIsLeftChild (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlIsLeftChild(Links) (                                   \
    (RtlLeftChild(RtlParent(Links)) == (PRTL_SPLAY_LINKS)(Links)) \
    )

// RtlIsRightChild determines whether a given splay link is the right child of a node in a splay
// link tree.
/*
NTSYSAPI
BOOLEAN
NTAPI
RtlIsRightChild(
	IN PRTL_SPLAY_LINKS Links
	);
*/
//
//  The macro function IsRightChild takes as input a pointer to a splay link
//  in a tree and returns TRUE if the input node is the right child of its
//  parent, otherwise it returns FALSE.
//
//  BOOLEAN
//  RtlIsRightChild (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlIsRightChild(Links) (                                   \
    (RtlRightChild(RtlParent(Links)) == (PRTL_SPLAY_LINKS)(Links)) \
    )

// RtlIsRoot determines whether the specified node is the root node of a splay link tree.
/*
NTSYSAPI
BOOLEAN
NTAPI
RtlIsRoot(
	IN PRTL_SPLAY_LINKS Links
	);
*/
//
//  The macro function IsRoot takes as input a pointer to a splay link
//  in a tree and returns TRUE if the input node is the root of the tree,
//  otherwise it returns FALSE.
//
//  BOOLEAN
//  RtlIsRoot (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlIsRoot(Links) (                          \
    (RtlParent(Links) == (PRTL_SPLAY_LINKS)(Links)) \
    )

// RtlIsValidOemCharacter determines whether the specified Unicode character can be mapped to a
// valid OEM character.
NTSYSAPI
BOOLEAN
NTAPI
RtlIsValidOemCharacter(
	IN PWCHAR Char
	);

// RtlLeftChild returns a pointer to the left child of the specified splay link node.
/*
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlLeftChild(
	IN PRTL_SPLAY_LINKS Links
	);
*/
//
//  The macro function LeftChild takes as input a pointer to a splay link in
//  a tree and returns a pointer to the splay link of the left child of the
//  input node.  If the left child does not exist, the return value is NULL.
//
//  PRTL_SPLAY_LINKS
//  RtlLeftChild (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlLeftChild(Links) (           \
    (PRTL_SPLAY_LINKS)(Links)->LeftChild \
    )

// RtlLookupElementGenericTable returns a pointer to the caller-supplied data for a particular
// element, selected by a buffered and caller-determined value, in a generic table.
NTSYSAPI
PVOID
NTAPI
RtlLookupElementGenericTable(
	IN PRTL_GENERIC_TABLE Table,
	IN PVOID Buffer
	);

// RtlMultiByteToUnicodeN translates the specified source string into a Unicode string, using the
// current system ANSI code page (ACP). The source string is not necessarily from a multibyte
// character set.
NTSYSAPI
NTSTATUS
NTAPI
RtlMultiByteToUnicodeN(
	OUT PWSTR UnicodeString,
	IN ULONG MaxBytesInUnicodeString,
	OUT PULONG BytesInUnicodeString OPTIONAL,
	IN PCHAR MultiByteString,
	IN ULONG BytesInMultiByteString
	);

// RtlMultiByteToUnicodeSize determines the number of bytes required to store the Unicode
// translation for the specified source string. The translation is assumed to use the current
// system ANSI code page (ACP). The source string is not necessarily from a multibyte character set.
NTSYSAPI
NTSTATUS
NTAPI
RtlMultiByteToUnicodeSize(
	OUT PULONG BytesInUnicodeString,
	IN PCHAR MultiByteString,
	IN ULONG BytesInMultiByteString
	);

// RtlNextUnicodePrefix is used to enumerate the elements in a Unicode prefix table.
NTSYSAPI
PUNICODE_PREFIX_TABLE_ENTRY
NTAPI
RtlNextUnicodePrefix(
	IN PUNICODE_PREFIX_TABLE PrefixTable,
	IN BOOLEAN Restart
	);

// RtlNumberGenericTableElements returns the number of elements in a generic table.
NTSYSAPI
ULONG
NTAPI
RtlNumberGenericTableElements(
	IN PRTL_GENERIC_TABLE Table
	);

// RtlOemStringToCountedUnicodeSize determines the size, in bytes, that a given OEM string
// will be after it is translated into a counted Unicode string.
NTSYSAPI
ULONG
NTAPI
RtlOemStringToCountedUnicodeSize(
	IN POEM_STRING OemString
	);

// RtlOemStringToCountedUnicodeString translates the specified source string into a Unicode
// string using the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlOemStringToCountedUnicodeString(
	OUT PUNICODE_STRING DestinationString,
	IN POEM_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlOemStringToUnicodeSize determines the size, in bytes, that a given OEM string will be
// after it is translated into a null-terminated Unicode string.
NTSYSAPI
ULONG
NTAPI
RtlOemStringToUnicodeSize(
	IN POEM_STRING OemString
	);

// RtlOemStringToUnicodeString translates a given source string into a null-terminated Unicode
// string using the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlOemStringToUnicodeString(
	OUT PUNICODE_STRING DestinationString,
	IN POEM_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlOemToUnicodeN translates the specified source string into a Unicode string, using the
// current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlOemToUnicodeN(
	OUT PWSTR UnicodeString,
	IN ULONG MaxBytesInUnicodeString,
	OUT PULONG BytesInUnicodeString OPTIONAL,
	IN PCHAR OemString,
	IN ULONG BytesInOemString
	);

// RtlOffsetToPointer returns a pointer for a given offset from a given base address.
NTSYSAPI
PCHAR
NTAPI
RtlOffsetToPointer(
	IN PVOID Base,
	IN ULONG Offset
	);

// RtlParent returns a pointer to the parent of the specified node in a splay link tree.
/*
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlParent(
	IN PRTL_SPLAY_LINKS Links
	);
*/
//
//  The macro function Parent takes as input a pointer to a splay link in a
//  tree and returns a pointer to the splay link of the parent of the input
//  node.  If the input node is the root of the tree the return value is
//  equal to the input value.
//
//  PRTL_SPLAY_LINKS
//  RtlParent (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlParent(Links) (           \
    (PRTL_SPLAY_LINKS)(Links)->Parent \
    )

// RtlPointerToOffset returns the offset from a given base address of a given pointer.
NTSYSAPI
ULONG
NTAPI
RtlPointerToOffset(
	IN PVOID Base,
	IN PVOID Pointer
	);

// RtlRealPredecessor returns a pointer to the predecessor of the specified node in the
// splay link tree.
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlRealPredecessor(
	IN PRTL_SPLAY_LINKS Links
	);

// RtlRealSuccessor returns a pointer to the successor of the specified node in the splay
// link tree.
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlRealSuccessor(
	IN PRTL_SPLAY_LINKS Links
	);

// RtlRemoveUnicodePrefix removes an element from a prefix table.
NTSYSAPI
VOID
NTAPI
RtlRemoveUnicodePrefix(
	IN PUNICODE_PREFIX_TABLE PrefixTable,
	IN PUNICODE_PREFIX_TABLE_ENTRY PrefixTableEntry
	);

// RtlRightChild returns a pointer to the right child of the specified splay link node.
//
//  The macro function RightChild takes as input a pointer to a splay link
//  in a tree and returns a pointer to the splay link of the right child of
//  the input node.  If the right child does not exist, the return value is
//  NULL.
//
//  PRTL_SPLAY_LINKS
//  RtlRightChild (
//      PRTL_SPLAY_LINKS Links
//      );
//

#define RtlRightChild(Links) (           \
    (PRTL_SPLAY_LINKS)(Links)->RightChild \
    )
/*
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlRightChild(
	IN PRTL_SPLAY_LINKS Links
	);
*/

// RtlSplay rebalances, or "splays," a splay link tree around the specified splay link, making
// that link the new root of the tree.
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlSplay(
	IN PRTL_SPLAY_LINKS Links
	);

// RtlSubtreePredecessor returns a pointer to the predecessor of the specified node within the
// subtree rooted at that node.
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlSubtreePredecessor(
	IN PRTL_SPLAY_LINKS Links
	);

// RtlSubtreeSuccessor returns a pointer to the successor of the specified node within the
// subtree rooted at that node.
NTSYSAPI
PRTL_SPLAY_LINKS
NTAPI
RtlSubtreeSuccessor(
	IN PRTL_SPLAY_LINKS Links
	);

// RtlUnicodeStringToAnsiSize determines the number of bytes required to store the ANSI
// translation for the specified Unicode string.
NTSYSAPI
ULONG
NTAPI
RtlUnicodeStringToAnsiSize(
	IN PUNICODE_STRING UnicodeString
	);

// RtlUnicodeStringToCountedOemString translates the specified Unicode source string
// into a counted OEM string using the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeStringToCountedOemString(
	OUT POEM_STRING DestinationString,
	IN PUNICODE_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlUnicodeStringToOemSize determines the size, in bytes, that a given Unicode string will
// be after it is translated into an OEM string.
NTSYSAPI
ULONG
NTAPI
RtlUnicodeStringToOemSize(
	IN PUNICODE_STRING UnicodeString
	);

// RtlUnicodeStringToOemString translates a given Unicode source string into an OEM string
// using the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeStringToOemString(
	OUT POEM_STRING DestinationString,
	IN PUNICODE_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlUnicodeToMultiByteN translates the specified Unicode string into a new character
// string, using the current system ANSI code page (ACP). The translated string is not
// necessarily from a multibyte character set.
NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeToMultiByteN(
	OUT PCHAR MultiByteString,
	IN ULONG MaxBytesInMultiByteString,
	OUT PULONG BytesInMultiByteString OPTIONAL,
	IN PWSTR UnicodeString,
	IN ULONG BytesInUnicodeString
	);

// Rtl(MultiByteSize determines the number of bytes required to store the multibyte
// translation for the specified Unicode string. The translation is assumed to use the current
// system ANSI code page (ACP).
NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeToMultiByteSize(
	OUT PULONG BytesInMultiByteString,
	IN PWSTR UnicodeString,
	IN ULONG BytesInUnicodeString
	);

// RtlUnicodeToOemN translates a given Unicode string to an OEM string, using the current
// system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlUnicodeToOemN(
	OUT PCHAR OemString,
	IN ULONG MaxBytesInOemString,
	OUT PULONG BytesInOemString OPTIONAL,
	IN PWSTR UnicodeString,
	IN ULONG BytesInUnicodeString
	);

// RtlUpcaseUnicodeStringToCountedOemString translates a given Unicode source string into an
// uppercase counted OEM string using the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlUpcaseUnicodeStringToCountedOemString(
	OUT POEM_STRING DestinationString,
	IN PUNICODE_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlUpcaseUnicodeStringToOemString translates a given Unicode source string into an uppercase
// OEM string using the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlUpcaseUnicodeStringToOemString(
	OUT POEM_STRING DestinationString,
	IN PUNICODE_STRING SourceString,
	IN BOOLEAN AllocateDestinationString
	);

// RtlUpcaseUnicodeToMultiByteN translates the specified Unicode string into a new uppercase
// character string, using the current system ANSI code page (ACP). The translated string is
// not necessarily from a multibyte character set.
NTSYSAPI
NTSTATUS
NTAPI
RtlUpcaseUnicodeToMultiByteN(
	OUT PCHAR MultiByteString,
	IN ULONG MaxBytesInMultiByteString,
	OUT PULONG BytesInMultiByteString OPTIONAL,
	IN PWSTR UnicodeString,
	IN ULONG BytesInUnicodeString
	);

// RtlUpcaseUnicodeToOemN translates a given Unicode string into an uppercase OEM string, using
// the current system OEM code page.
NTSYSAPI
NTSTATUS
NTAPI
RtlUpcaseUnicodeToOemN(
	OUT PCHAR OemString,
	IN ULONG MaxBytesInOemString,
	OUT PULONG BytesInOemString OPTIONAL,
	IN PWSTR UnicodeString,
	IN ULONG BytesInUnicodeString
	);

#if defined(_M_AMD64)

NTSYSAPI
VOID
NTAPI
RtlCopyMemoryNonTemporal (
   VOID UNALIGNED *Destination,
   CONST VOID UNALIGNED *Source,
   SIZE_T Length
   );

#else

#define RtlCopyMemoryNonTemporal RtlCopyMemory

#endif

// RtlCompareMemoryUlong returns how many bytes in a block of memory match a specified pattern.
NTSYSAPI
ULONG
NTAPI
RtlCompareMemoryUlong(
	IN PVOID Source,
	IN ULONG Length,
	IN ULONG Pattern
	);

// RtlCopyLuid copies a locally unique identifier (LUID) to a buffer. 
NTSYSAPI
VOID
NTAPI
RtlCopyLuid(
	OUT PLUID DestinationLuid,
	IN PLUID SourceLuid
	); 

// RtlGetDaclSecurityDescriptor gets a security descriptor's DACL.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetDaclSecurityDescriptor(
	IN CONST PSECURITY_DESCRIPTOR,
	OUT PBOOLEAN DaclPresent,
	OUT PACL *Dacl,
	OUT PBOOLEAN DaclDefaulted
	);

// RtlGetSaclSecurityDescriptor gets a security descriptor's SACL.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetSaclSecurityDescriptor(
	IN CONST PSECURITY_DESCRIPTOR,
	OUT PBOOLEAN SaclPresent,
	OUT PACL *Sacl,
	OUT PBOOLEAN SaclDefaulted
	);

// RtlAllocateHeap allocates memory from a heap.
NTSYSAPI
PVOID
NTAPI
RtlAllocateHeap(
	IN HANDLE Heap,
	IN ULONG_PTR Flags,
	IN SIZE_T Size
	);

// RtlCompactHeap attempts to reduce the size of the heap by freeing unused memory and moving unused blocks.
NTSYSAPI
ULONG
NTAPI
RtlCompactHeap(
   IN HANDLE Heap,
   IN ULONG Flags
   );

// RtlExtendHeap grows a heap.
NTSYSAPI
NTSTATUS
NTAPI
RtlExtendHeap(
    IN PVOID HeapHandle,
    IN ULONG Flags,
    IN PVOID Base,
    IN ULONG Size
    );


// RtlCreateHeap creates a heap.
NTSYSAPI
HANDLE
NTAPI
RtlCreateHeap(
	IN ULONG Flags,
	IN PVOID BaseAddress OPTIONAL,
	IN ULONG Reserve OPTIONAL,
	IN ULONG Commit,
	IN BOOLEAN Lock OPTIONAL,
	IN PRTL_HEAP_PARAMETERS OPTIONAL
	);

// RtlCreateTagHeap creates a tag heap.
NTSYSAPI
ULONG 
NTAPI
RtlCreateTagHeap(	
	IN HANDLE HeapHandle,
	IN ULONG Flags,
	IN PCWSTR TagName OPTIONAL,
	IN PCWSTR TagSubName
	);

// RtlDestroyHeap destroys a heap created with RtlCreateHeap.
NTSYSAPI
NTSTATUS
NTAPI
RtlDestroyHeap(
	IN HANDLE Heap
	);

// RtlFreeHeap frees memory allocated with RtlAllocateHeap.
NTSYSAPI
NTSTATUS
NTAPI
RtlFreeHeap(
	IN HANDLE Heap,
	IN ULONG Flags OPTIONAL,
	IN PVOID Memory
	);

// RtlEnumProcessHeaps enumerates the heaps present in the current process.
NTSYSAPI
NTSTATUS
NTAPI
RtlEnumProcessHeaps(
	IN PHEAP_ENUMERATION_ROUTINE HeapEnumRoutine,
	IN PVOID Context
	);

// RtlGetProcessHeaps obtains handles to all of the heaps that are valid for the current process.
NTSYSAPI
ULONG
NTAPI
RtlGetProcessHeaps(
   IN ULONG NumberOfHeaps,
   OUT PHANDLE ProcessHeaps
   );

// RtlLockHeap locks a heaps pages in memory, ensuring that subsequent accesses will not incur
// page faults.
NTSYSAPI
BOOLEAN
NTAPI
RtlLockHeap(
	IN HANDLE Heap
	);

// RtlProtectHeap changes the protection on a heaps pages in memory.
NTSYSAPI
PVOID
NTAPI
RtlProtectHeap(
	IN HANDLE Heap,
	IN BOOLEAN ReadOnly
	);

// RtlQueryTagHeap queries information about a tag heap.
NTSYSAPI
PCWSTR 
NTAPI
RtlQueryTagHeap(
	IN HANDLE HeapHandle,
	IN ULONG Flags,
	IN USHORT TagNumber,
	IN BOOLEAN ZeroInternalTagInfo,
	OUT PRTL_HEAP_TAG_INFO HeapTagInfo OPTIONAL
	);

// RtlReAllocateHeap changes the size of a previously allocated block of heap memory.
NTSYSAPI
PVOID
NTAPI
RtlReAllocateHeap(
	IN HANDLE Heap,
	IN ULONG Flags,
	IN PVOID Memory,
	IN ULONG NewSize
	);

// RtlSizeHeap determines the size of block of heap memory.
NTSYSAPI
ULONG
NTAPI
RtlSizeHeap(
	IN HANDLE Heap,
	IN ULONG Flags,
	IN CONST PVOID Memory
	);

// RtlValidateHeap checks the specified heap for consistency.
NTSYSAPI
BOOLEAN
NTAPI
RtlValidateHeap(
	IN HANDLE Heap,
	IN ULONG Flags,
	IN CONST PVOID Memory OPTIONAL
	);

// RtlValidateProcessHeaps checks all heaps in the process for consistency.
NTSYSAPI
BOOLEAN
NTAPI
RtlValidateProcessHeaps(
	VOID
	);

// RtlWalkHeap walks through the specified heap, enumerating all entries.
NTSYSAPI
NTSTATUS
NTAPI
RtlWalkHeap(
	IN HANDLE Heap,
	IN OUT LPPROCESS_HEAP_ENTRY ProcessHeapEntry
	);

// RtlCompressBuffer compresses a buffer with the specified compression algorithm.
NTSYSAPI 
NTSTATUS
NTAPI
RtlCompressBuffer(
	IN ULONG CompressionFormat,			// COMPRESSION_xxxxx
	IN CONST PVOID SourceBuffer,
	IN ULONG SourceBufferLength,
	OUT PVOID DestinationBuffer,
	IN ULONG DestinationBufferLength,
	IN ULONG ChunkSize,					// 4096
	OUT PULONG ReturnLength,
	IN PVOID WorkspaceBuffer
	);

// RtlReserveChunk reserves a chunk.
NTSYSAPI
NTSTATUS
NTAPI
RtlReserveChunk(
	IN USHORT CompressionFormat,
	IN OUT PUCHAR *CompressedBuffer,
	IN PUCHAR EndOfCompressedBufferPlus1,
	OUT PUCHAR *ChunkBuffer,
	IN ULONG ChunkSize
	);

// RtlDecompressBuffer decompresses a buffer compressed with the specified compression algorithm.
NTSYSAPI
NTSTATUS
NTAPI
RtlDecompressBuffer(
	IN ULONG CompressionFormat,
	OUT PVOID DestinationBuffer,
	IN ULONG DestinationBufferLength,
	IN PVOID SourceBuffer,
	IN ULONG SourceBufferLength,
	OUT PULONG ReturnLength
	);

// RtlCompressChunks compresses data chunks.
NTSYSAPI
NTSTATUS
NTAPI
RtlCompressChunks(
	IN PUCHAR UncompressedBuffer,
	IN ULONG UncompressedBufferSize,
	OUT PUCHAR CompressedBuffer,
	IN ULONG CompressedBufferSize,
	IN OUT PCOMPRESSED_DATA_INFO CompressedDataInfo,
	IN ULONG CompressedDataInfoLength,
	IN PVOID WorkSpace
	);

// RtlDecompressChunks decompresses compressed data chunks.
NTSYSAPI
NTSTATUS
NTAPI
RtlDecompressChunks(
	OUT PUCHAR UncompressedBuffer,
	IN ULONG UncompressedBufferSize,
	IN PUCHAR CompressedBuffer,
	IN ULONG CompressedBufferSize,
	IN PUCHAR CompressedTail,
	IN ULONG CompressedTailSize,
	IN PCOMPRESSED_DATA_INFO CompressedDataInfo
	);

// RtlDecompressFragment decompresses a compressed data fragment.
NTSYSAPI
NTSTATUS
NTAPI
RtlDecompressFragment(
	IN USHORT CompressionFormat,
	OUT PUCHAR UncompressedFragment,
	IN ULONG UncompressedFragmentSize,
	IN PUCHAR CompressedBuffer,
	IN ULONG CompressedBufferSize,
	IN ULONG FragmentOffset,
	OUT PULONG FinalUncompressedSize,
	IN PVOID WorkSpace
	);

// RtlDescribeChunk queries information about a compressed data chunk.
NTSYSAPI
NTSTATUS
NTAPI
RtlDescribeChunk(
	IN USHORT CompressionFormat,
	IN OUT PUCHAR *CompressedBuffer,
	IN PUCHAR EndOfCompressedBufferPlus1,
	OUT PUCHAR *ChunkBuffer,
	OUT PULONG ChunkSize
	);

// RtlGetCompressionWorkSpaceSize retrieves the amount of extra space needed for a compression operation.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetCompressionWorkSpaceSize(
	IN ULONG CompressionFormat,
	OUT PULONG WorkspaceSize,
	OUT PULONG ChunkSize
	);

// RtlCreateEnvironment creates an environmental variable block.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateEnvironment(
	IN BOOLEAN Inherit,
	OUT PVOID *Environment
	);

// RtlDestroyEnvironment frees an environmental variable block allocated with RtlCreateEnvironment.
NTSYSAPI
NTSTATUS
NTAPI
RtlDestroyEnvironment(
	IN PVOID Environment
	);

// RtlQueryEnvironmentalVariable_U queries the value of an environmental variable.
NTSYSAPI
NTSTATUS
NTAPI
RtlQueryEnvironmentalVariable_U(
	IN PVOID Environment OPTIONAL,
	IN PUNICODE_STRING VariableName,
	OUT PUNICODE_STRING VariableValue
	);

// RtlSetCurrentEnvironment sets the current environmental variable block.
NTSYSAPI
VOID
NTAPI
RtlSetCurrentEnvironment(
	IN PVOID NewEnvironment,
	OUT PVOID *OldEnvironment OPTIONAL
	);

// RtlSetEnvironmentalVariable sets the value of an environmental variable.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetEnvironmentalVariable(
	IN OUT PVOID *Environment,
	IN PUNICODE_STRING VariableName,
	IN PUNICODE_STRING VariableValue
	);

// RtlFormatCurrentUserKeyPath retrieves the current user's registry key path.
NTSYSAPI
NTSTATUS
NTAPI
RtlFormatCurrentUserKeyPath(
	OUT PUNICODE_STRING RegistryPath
	);

// RtlImageNtHeader retrieves a pointer to the IMAGE_NT_HEADERS given an executable module's base address.
NTSYSAPI
PIMAGE_NT_HEADERS
NTAPI
RtlImageNtHeader(
	IN PVOID Base
	);

// RtlImageRvaToVa translates a relative virtual address to a virtual address.
NTSYSAPI
PVOID
NTAPI
RtlImageRvaToVa(
	IN PIMAGE_NT_HEADERS NtHeaders,
	IN PVOID Base,
	IN ULONG Rva,
	IN OUT PIMAGE_SECTION_HEADER LastSection OPTIONAL
	);

// RtlImageRvaToSection translates a relative virtual address to a section header.
NTSYSAPI
PIMAGE_SECTION_HEADER
NTAPI
RtlImageRvaToSection(
	IN PIMAGE_NT_HEADERS NtHeaders,
	IN PVOID Base,
	IN ULONG Rva
	);

// RtlImageDirectoryEntryToData translates a directory entry to a data pointer.
NTSYSAPI
PVOID
NTAPI
RtlImageDirectoryEntryToData(
    IN PVOID Base,
    IN BOOLEAN MappedAsImage,
    IN USHORT DirectoryEntry,
    OUT PULONG Size
    );

// RtlInitializeContext initializes a CONTEXT structure for use in thread creation.
NTSYSAPI
PVOID
NTAPI
RtlInitializeContext(
	IN HANDLE Process,
	OUT PCONTEXT Context,
	IN PVOID ThreadStartParameter OPTIONAL,
	IN PVOID ThreadStartRoutine,
	IN PUSER_STACK InitialTeb
	);

// RtlAcquirePebLock acquires the lock associated with the current process's PEB.
NTSYSAPI
VOID
NTAPI
RtlAcquirePebLock(
	VOID
	);

// RtlReleasePebLock releases the lock associated with the current process's PEB.
NTSYSAPI
VOID
NTAPI
RtlReleasePebLock(
	VOID
	);

// RtlRandom generates a random number.
NTSYSAPI
ULONG
NTAPI
RtlRandom(
	IN OUT PULONG Seed
	);

// RtlUniform generates a uniformly distributed random number.
NTSYSAPI
ULONG
NTAPI
RtlUniform(
	IN OUT PULONG Seed
	);

// RtlUshortByteSwap swaps the byte order of a USHORT value.
NTSYSAPI
USHORT
NTFASTAPI
RtlUshortByteSwap(
	IN USHORT Value
	);

// RtlUlongByteSwap swaps the byte order of a ULONG value.
NTSYSAPI
ULONG
NTFASTAPI
RtlUlongByteSwap(
	IN ULONG Value
	);

// RtlUlonglongByteSwap swaps the byte order of a ULONGLONG value.
NTSYSAPI
ULONGLONG
NTFASTAPI
RtlUlonglongByteSwap(
	IN ULONGLONG Value
	);

// RtlTimeToSecondsSince1970 converts the specified 64-bit system time to the number of seconds
// since the beginning of January 1, 1970.
NTSYSAPI
BOOLEAN
NTAPI
RtlTimeToSecondsSince1970(
	IN PLARGE_INTEGER Time,
	OUT PULONG ElapsedSeconds
	);

// RtlTimeToSecondsSince1980 converts the specified 64-bit system time to the number of seconds
// since the beginning of January 1, 1980.
NTSYSAPI
BOOLEAN
NTAPI
RtlTimeToSecondsSince1980(
	IN PLARGE_INTEGER Time,
	OUT PULONG ElapsedSeconds
	);

// RtlSecondsSince1970ToTime converts the specified elapsed seconds count to a 64-bit system time.
NTSYSAPI
VOID
NTAPI
RtlSecondsSince1970ToTime(
	IN ULONG ElapsedSeconds,
	OUT PLARGE_INTEGER Time
	);

// RtlSecondsSince1980ToTime converts the specified elapsed seconds count to a 64-bit system time.
NTSYSAPI
VOID
NTAPI
RtlSecondsSince1980ToTime(
	IN ULONG ElapsedSeconds,
	OUT PLARGE_INTEGER Time
	);

// RtlRaiseException raises an exception.
NTSYSAPI
VOID
NTAPI
RtlRaiseException(
	IN PEXCEPTION_RECORD ExceptionRecord
	);

// RtlRaiseStatus raises a status.
NTSYSAPI
VOID
NTAPI
RtlRaiseStatus(
	IN NTSTATUS Status
	);

// RtlUnwind unwinds procedure call stack frames.
NTSYSAPI
VOID
NTAPI
RtlUnwind(
	IN OUT PVOID TargetFrame OPTIONAL,
	IN PVOID TargetIp OPTIONAL,
	IN PEXCEPTION_RECORD ExceptionRecord OPTIONAL,
	IN PVOID ReturnValue
	);

#if defined(_M_IA64)

// RtlUnwind2 unwinds procedure call stack frames on IA64.
NTSYSAPI
VOID
NTAPI
RtlUnwind2 (
    IN FRAME_POINTERS TargetFrame OPTIONAL,
    IN PVOID TargetIp OPTIONAL,
    IN PEXCEPTION_RECORD ExceptionRecord OPTIONAL,
    IN PVOID ReturnValue,
    IN PCONTEXT ContextRecord
    );

// RtlUnwindEx unwinds procedure call stack frames on IA64.
NTSYSAPI
VOID
NTAPI
RtlUnwindEx (
    IN FRAME_POINTERS TargetFrame OPTIONAL,
    IN PVOID TargetIp OPTIONAL,
    IN PEXCEPTION_RECORD ExceptionRecord OPTIONAL,
    IN PVOID ReturnValue,
    IN PCONTEXT ContextRecord,
    IN PUNWIND_HISTORY_TABLE HistoryTable OPTIONAL
    );

#endif

// RtlNtStatusToDosError converts an NTSTATUS to a Win32 error code.
NTSYSAPI
ULONG
NTAPI
RtlNtStatusToDosError(
	IN NTSTATUS Status
	);

// RtlIsNameLegalDOS8Dot3 checks if a filename is a legal DOS 8.3 filename.
NTSYSAPI
BOOLEAN
NTAPI
RtlIsNameLegalDOS8Dot3(
    IN CONST PUNICODE_STRING Name,
    IN OUT POEM_STRING OemName OPTIONAL,
    IN OUT PBOOLEAN NameContainsSpaces OPTIONAL
    );

// RtlGenerate8dot3Name creates a legal DOS 8.3 filename.
NTSYSAPI
VOID
NTAPI
RtlGenerate8dot3Name(
	 IN CONST PUNICODE_STRING Name,
	 IN BOOLEAN AllowExtendedCharacters,
	 IN OUT PGENERATE_NAME_CONTEXT Context,
	 OUT PUNICODE_STRING Name8dot3
	 );

// RtlConvertSidToUnicodeString converts an SID to a string representation and stores it in a
// caller-supplied UNICODE_STRING.
NTSYSAPI
NTSTATUS
NTAPI
RtlConvertSidToUnicodeString(
    OUT PUNICODE_STRING UnicodeString,
    IN CONST PSID Sid,
    IN BOOLEAN AllocateDestinationString
    );

// RtlValidSid determines if the specified SID is valid.
NTSYSAPI
NTSTATUS
NTAPI
RtlValidSid(
	IN CONST PSID Sid
	);

// RtlCopySid copies a SID.
NTSYSAPI
NTSTATUS
NTAPI
RtlCopySid(
	IN ULONG DestinationSidLength,
	OUT PSID DestinationSid,
	IN CONST PSID SourceSid
	);

// RtlEqualSid determines if two SIDs are the same.
NTSYSAPI
BOOLEAN
NTAPI
RtlEqualSid(
	IN CONST PSID Sid1,
	IN CONST PSID Sid2
	);

// RtlLengthSid determines the length of the specified SID.
NTSYSAPI
ULONG
NTAPI
RtlLengthSid(
	IN CONST PSID Sid
	);

// RtlLengthSidAsUnicodeString determines the size in bytes of a buffer required to represent a SID as a unicode string.
NTSYSAPI
NTSTATUS
NTAPI
RtlLengthSidAsUnicodeString(
	IN CONST PSID Sid,
	OUT PULONG SidStringLength
	);

// RtlLengthRequiredSid determines the size of a buffer required to store a SID with the
// specified number of subauthorities.
NTSYSAPI
ULONG
NTAPI
RtlLengthRequiredSid(
	 IN UCHAR SubAuthorityCount
	 );

// RtlSubAuthorityCountSid returns a pointer to the subauthority count stored
// in a SID.
NTSYSAPI
PUCHAR
NTAPI
RtlSubAuthorityCountSid(
	IN PSID Sid
	);

// RtlSubAuthoritySid retrieves a pointer to a specified subauthority in a SID.
NTSYSAPI
PULONG
NTAPI
RtlSubAuthoritySid(
	IN PSID Sid,
	IN ULONG SubAuthority
	);

// RtlAllocateAndInitializeSid allocates and initializes a SID with up to eight
// subauthorities.
NTSYSAPI
NTSTATUS
NTAPI
RtlAllocateAndInitializeSid(
	IN PSID_IDENTIFIER_AUTHORITY IdentifierAuthority,
	IN UCHAR SubAuthorityCount,
	IN ULONG SubAuthority0,
	IN ULONG SubAuthority1,
	IN ULONG SubAuthority2,
	IN ULONG SubAuthority3,
	IN ULONG SubAuthority4,
	IN ULONG SubAuthority5,
	IN ULONG SubAuthority6,
	IN ULONG SubAuthority7,
	OUT PSID *Sid
	);

// RtlFreeSid frees memory allocated by RtlAllocateAndInitializeSid.
NTSYSAPI
BOOLEAN
NTAPI
RtlFreeSid(
	IN PSID Sid
	);

// RtlAbsoluteToSelfRelativeSD creates a self-relative security descriptor from
// an absolute format security descriptor.  See MakeSelfRelativeSD.
NTSYSAPI
NTSTATUS
NTAPI
RtlAbsoluteToSelfRelativeSD(
	IN PSECURITY_DESCRIPTOR AbsoluteSD,
	OUT PSECURITY_DESCRIPTOR SelfRelativeSD,
	OUT PULONG SelfRelativeSize
	);

// RtlSelfRelativeToAbsoluteSD creates an absolute security descriptor from a self-
// relative format security descriptor.  See MakeAbsoluteSD.
NTSYSAPI
NTSTATUS
NTAPI
RtlSelfRelativeToAbsoluteSD(
	IN PSECURITY_DESCRIPTOR SelfRelativeSD,
	OUT PSECURITY_DESCRIPTOR AbsoluteSD,
	IN OUT PULONG AbsoluteSDSize,
	IN OUT PACL Dacl,
	IN OUT PULONG DaclSize,
	IN OUT PACL Sacl,
	IN OUT PULONG SaclSize,
	IN OUT PSID Owner,
	IN OUT PULONG OwnerSize,
	IN OUT PSID Group,
	IN OUT PULONG GroupSize
	);

// RtlSelfRelativeToAbsoluteSD2 modifies a self-relative format security descriptor to be an
// absolute format security descriptor.  The buffer size requirement may be slightly larger
// for an absolute security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlSelfRelativeToAbsoluteSD2(
	IN OUT PSECURITY_DESCRIPTOR SelfRelativeSecurityDescriptor,
	IN OUT PULONG BufferSize
	);

// RtlSetOwnerSecurityDescriptor sets the owner of an absolute-format security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetOwnerSecurityDescriptor(
	IN OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID Owner,
	IN BOOLEAN OwnerDefaulted
	);

// RtlGetOwnerSecurityDescriptor retrieves the owner of an absolute-format security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetOwnerSecurityDescriptor(
	IN CONST PSECURITY_DESCRIPTOR SecurityDescriptor,
	OUT PSID *Owner,
	OUT PBOOLEAN OwnerDefaulted
	);

// RtlSetGroupSecurityDescriptor sets the group of an absolute-format security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetGroupSecurityDescriptor(
	IN OUT PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN PSID Group,
	IN BOOLEAN GroupDefaulted
	);

// RtlGetGroupSecurityDescriptor gets the group of an absolute-format security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetGroupSecurityDescriptor(
	IN CONST PSECURITY_DESCRIPTOR SecurityDescriptor,
	OUT PSID *Group,
	OUT PBOOLEAN GroupDefaulted
	);

// RtlGetControlSecurityDescriptor gets the control flags of an abssolute-format security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetControlSecurityDescriptor(
	IN CONST PSECURITY_DESCRIPTOR SecurityDescriptor,
	OUT PSECURITY_DESCRIPTOR_CONTROL Control,
	OUT PULONG Revision
	);

// RtlSetControlSecurityDescriptor sets the control flags of an abssolute-format security descriptor.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetControlSecurityDescriptor(
	IN PSECURITY_DESCRIPTOR SecurityDescriptor,
	IN SECURITY_DESCRIPTOR_CONTROL ControlBitsOfInterest,
	IN SECURITY_DESCRIPTOR_CONTROL ControlBitsToSet
	);

// RtlCreateAcl creates a new ACL structure.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateAcl(
	OUT PACL Acl,
	IN ULONG AclSize,
	IN ULONG AclRevision
	);

// RtlAddAccessAllowedAce adds a new access-allowed entry to an ACL.
NTSYSAPI
NTSTATUS
NTAPI
RtlAddAccessAllowedAce(
	IN OUT PACL Acl,
	IN ULONG AclRevision,
	IN ULONG AccessMask,
	IN PSID Sid
	);

// RtlImpersonateSelf obtains an impersonation access token for the security context
// of the calling processes.
NTSYSAPI
NTSTATUS
NTAPI
RtlImpersonateSelf(
	IN SECURITY_IMPERSONATION_LEVEL ImpersonationLevel
	);

// RtlSetIoCompletionCallback binds the specified file handle to the thread pool's I/O
// completion port. On completion of the I/O request, a non-I/O worker thread will
// execute the callback function.  See BindIoCompletionCallback in the Platform SDK.
NTSYSAPI
NTSTATUS
NTAPI
RtlSetIoCompletionCallback(
	IN HANDLE FileHandle,
	IN POVERLAPPED_COMPLETION_ROUTINE CompletionRoutine,
	IN ULONG Flags
	);

// RtlDeleteCriticalSection releases any system resources allocated to maintain a
// critical-section object.
NTSYSAPI
NTSTATUS
NTAPI
RtlDeleteCriticalSection(
	IN PRTL_CRITICAL_SECTION CriticalSection
	);

// RtlEnterCriticalSection acquires ownership of a critical section object, waiting
// if necessary.
NTSYSAPI
NTSTATUS
NTAPI
RtlEnterCriticalSection(
	IN PRTL_CRITICAL_SECTION CriticalSection
	);

// RtlInitializeCriticalSection initializes a critical section object.
NTSYSAPI
NTSTATUS
NTAPI
RtlInitializeCriticalSection(
	OUT PRTL_CRITICAL_SECTION CriticalSection
	);

// RtlInitializeCriticalSectionAndSpinCount initializes a critical section object
// and sets it's spin count.
NTSYSAPI
NTSTATUS
NTAPI
RtlInitializeCriticalSectionAndSpinCount(
	OUT PRTL_CRITICAL_SECTION CriticalSection
	);

// RtlLeaveCriticalSection releases ownership of a critical section object.
NTSYSAPI
NTSTATUS
NTAPI
RtlLeaveCriticalSection(
	IN PRTL_CRITICAL_SECTION CriticalSection
	);

// RtlSetCriticalSectionSpinCount sets the spin count for a critical section object.
NTSYSAPI
ULONG
NTAPI
RtlSetCriticalSectionSpinCount(
   IN PRTL_CRITICAL_SECTION CriticalSection
   );

// RtlTryEnterCriticalSection attempts to acquire ownership of a critical section
// object, without waiting.
NTSYSAPI
BOOLEAN
NTAPI
RtlTryEnterCriticalSection(
   IN PRTL_CRITICAL_SECTION CriticalSection
   );

#ifndef _NTTYPES_NO_WINNT

#define WT_EXECUTEDEFAULT       0x00000000                           
#define WT_EXECUTEINIOTHREAD    0x00000001                           
#define WT_EXECUTEINUITHREAD    0x00000002                           
#define WT_EXECUTEINWAITTHREAD  0x00000004                           
#define WT_EXECUTEONLYONCE      0x00000008                           
#define WT_EXECUTEINTIMERTHREAD 0x00000020                           
#define WT_EXECUTELONGFUNCTION  0x00000010                           
#define WT_EXECUTEINPERSISTENTIOTHREAD  0x00000040                   
#define WT_EXECUTEINPERSISTENTTHREAD 0x00000080                      
#define WT_SET_MAX_THREADPOOL_THREADS(Flags, Limit)  ((Flags) |= (Limit)<<16) 
typedef VOID (NTAPI * WAITORTIMERCALLBACKFUNC) (PVOID, BOOLEAN );   
typedef VOID (NTAPI * WORKERCALLBACKFUNC) (PVOID );                 
typedef VOID (NTAPI * APC_CALLBACK_FUNCTION) (DWORD   , PVOID, PVOID); 
#define WT_EXECUTEINLONGTHREAD  0x00000010                           
#define WT_EXECUTEDELETEWAIT    0x00000008                           

#endif

// RtlQueueWorkItem queues a work item to the thread pool (Windows 2000 or later).
NTSYSAPI
NTSTATUS
NTAPI
RtlQueueWorkItem(
	WORKERCALLBACKFUNC Function,
	PVOID Context,
	ULONG Flags
	);

// RtlGetLongestNtPathLength returns the maximum allowable Windows NT path length.
NTSYSAPI
ULONG
NTAPI
RtlGetLongestNtPathLength(
	VOID
	);

// RtlGetGlobalNtFlags returns the Windows NT global flags bitmask.
NTSYSAPI
ULONG
NTAPI
RtlGetGlobalNtFlags(
	VOID
	);

// RtlCreateProcessParameters creates and populates the data structure used to hold the user mode process parameters.
NTSYSAPI
NTSTATUS
NTAPI
RtlCreateProcessParameters(
    OUT PRTL_USER_PROCESS_PARAMETERS *ProcessParameters,
    IN PUNICODE_STRING ImagePathName,
    IN PUNICODE_STRING DllPath OPTIONAL,
    IN PUNICODE_STRING CurrentDirectory OPTIONAL,
    IN PUNICODE_STRING CommandLine OPTIONAL,
    IN PVOID Environment OPTIONAL,
    IN PUNICODE_STRING WindowTitle OPTIONAL,
    IN PUNICODE_STRING DesktopInfo OPTIONAL,
    IN PUNICODE_STRING ShellInfo OPTIONAL,
    IN PUNICODE_STRING RuntimeData OPTIONAL
	);

// RtlDestroyProcessParameters deallocates the data structure used to hold the user mode process parameters.
NTSYSAPI
NTSTATUS
NTAPI
RtlDestroyProcessParameters(
	IN PRTL_USER_PROCESS_PARAMETERS ProcessParameters
	);

// RtlNormalizeProcessParams normalizes the specified process parameter block.
NTSYSAPI
PRTL_USER_PROCESS_PARAMETERS
NTAPI
RtlNormalizeProcessParams(
	IN PRTL_USER_PROCESS_PARAMETERS ProcessParameters
	);

// RtlDenormalizeProcessParams denormalizes the specified process parameter block.
NTSYSAPI
PRTL_USER_PROCESS_PARAMETERS
NTAPI
RtlDeNormalizeProcessParams(
	IN PRTL_USER_PROCESS_PARAMETERS ProcessParameters
	);

// RtlEraseUnicodeString zeroes the contents of a UNICODE_STRING.
NTSYSAPI
VOID
NTAPI
RtlEraseUnicodeString(
	IN PUNICODE_STRING UnicodeString
	);

// RtlEqualDomainName determines if two domain names refer to the same domain.
NTSYSAPI
BOOLEAN
NTAPI
RtlEqualDomainName(
	IN PUNICODE_STRING DomainName1,
	IN PUNICODE_STRING DomainName2
	);

// RtlEqualComputerName determines if two computer names refer to the same computer.
NTSYSAPI
BOOLEAN
NTAPI
RtlEqualComputerName(
	IN PUNICODE_STRING ComputerName1,
	IN PUNICODE_STRING ComputerName2
	);

#if _WIN32_WINNT >= 0x0501

// RtlNtStatusToDosErrorNoTeb converts an NTSTATUS to a Win32 error code without
// updating the last NTSTATUS field in the TEB.
NTSYSAPI
ULONG
NTAPI
RtlNtStatusToDosErrorNoTeb(
	IN NTSTATUS Status
	);

// RtlGetLastNtStatus retrieves the last NTSTATUS passed to RtlNtStatusToDosError.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetLastNtStatus(
	VOID
	);

// RtlGetLastWin32Error retrieves the last Win32 error value set in the TEB.
NTSYSAPI
ULONG
NTAPI
RtlGetLastWin32Error(
	VOID
	);

// RtlSetLastWin32Error sets the last Win32 error value in the TEB.
NTSYSAPI
VOID
NTAPI
RtlSetLastWin32Error(
	IN ULONG Win32Error
	);

// RtlRestoreLastWin32Error sets the last Win32 error value in the TEB.
NTSYSAPI
VOID
NTAPI
RtlRestoreLastWin32Error(
	IN ULONG Win32Error
	);

// RtlSetLastWin32ErrorAndNtStatusFromNtStatus updates the last NTSTATUS
// and Win32 error values.
NTSYSAPI
VOID
NTAPI
RtlSetLastWin32ErrorAndNtStatusFromNtStatus(
	IN NTSTATUS NtStatus
	);

// RtlGetNativeSystemInformation information about the system, bypassing
// Wow64 translations.
NTSYSAPI
NTSTATUS
NTAPI
RtlGetNativeSystemInformation(
	IN SYSTEM_INFORMATION_CLASS SystemInformationClass,
	IN OUT PVOID SystemInformation,
	IN ULONG SystemInformationLength,
	OUT PULONG ReturnLength OPTIONAL
	);

// RtlGetNtGlobalFlags returns the global flags bitmask.
NTSYSAPI
ULONG
NTAPI
RtlGetNtGlobalFlags(
	VOID
	);

// RtlGetNtProductType returns the current product type.  If this value has
// not been queried since the system boot, it accesses the registry to determine
// the product type; otherwise, it returns a value cached from a previous query.
NTSYSAPI
BOOLEAN
NTAPI
RtlGetNtProductType(
	IN PNT_PRODUCT_TYPE NtProductType
	);

// RtlGetNtVersonNumbers retrieves the operating system version.
NTSYSAPI
VOID
NTAPI
RtlGetNtVersionNumbers(
	OUT PULONG NtMajorVersion OPTIONAL,
	OUT PULONG NtMinorVersion OPTIONAL,
	OUT PULONG NtBuildNumber OPTIONAL
	);

#if _WIN32_WINNT >= 0x0501

// RtlGetCurrentPeb returns a pointer to the current PEB.
NTSYSAPI
PPEB
NTAPI
RtlGetCurrentPeb(
	VOID
	);

#endif

// RtlComputeCrc32 computes a CRC32 checksum.
NTSYSAPI
ULONG
NTAPI
RtlComputeCrc32(
	IN ULONG InitialChecksumValue,
	IN PVOID DataToChecksum,
	IN ULONG DataSize
	);

// RtlAddRefActivationContext adds a reference to an activation context.
NTSYSAPI
VOID
NTAPI
RtlAddRefActivationContext(
	IN struct _RTL_ACTIVATION_CONTEXT* ActivationContext
	);

// RtlIsDosDeviceName_U determines if the specified name refersto a DosDevice.
NTSYSAPI
BOOLEAN
NTAPI
RtlIsDosDeviceName_U(
	IN PCWSTR DosDeviceName
	);

// RtlLogStackBackTrace logs a stack back-trace entry.
NTSYSAPI
USHORT
NTAPI
RtlLogStackBackTrace(
	VOID
	);

// RtlDllShutdownInProgress determines if DLL shutdown is occuring.
NTSYSAPI
BOOLEAN
NTAPI
RtlDllShutdownInProgress(
	VOID
	);

// RtlAddVectoredExceptionHandler inserts a vectored exception handler.
NTSYSAPI
PVOID
NTAPI
RtlAddVectoredExceptionHandler(
    IN ULONG FirstHandler,
    IN PRTL_VECTORED_EXCEPTION_HANDLER VectoredHandler
    );

// RtlRemoveVectoredExceptionHandler removes a vectored exception handler.
NTSYSAPI
ULONG
NTAPI
RtlRemoveVectoredExceptionHandler(
    IN PVOID VectoredHandlerHandle
    );

#ifndef _NTTYPES_NO_WINNT

// RtlApplicationVerifierStop halts application verification for a violation.
VOID
RtlApplicationVerifierStop (
    ULONG_PTR Code,
    PCHAR Message,
    ULONG_PTR Param1, PCHAR Description1,
    ULONG_PTR Param2, PCHAR Description2,
    ULONG_PTR Param3, PCHAR Description3,
    ULONG_PTR Param4, PCHAR Description4
    );

#endif

// RtlEnableEarlyCriticalSectionEventCreation forces critical section wait semaphores to be created immediately.
// Normally, the creation of the wait semaphore is delayed until the first contention.  This ensures that failures
// to allocate the wait semaphore will not raise an exception in RtlEnterCriticalSection.  Most applications do not
// expect RtlEnterCriticalSection to raise an exception.
NTSYSAPI
VOID
NTAPI
RtlEnableEarlyCriticalSectionEventCreation(
	VOID
	);

// RtlpWaitForCriticalSection acquires exclusive ownership of a critical section when contention is detected.
// The wait semaphore of the critical section must have been initialized prior to calling this routine.
// A noncontinuable status is raised if the wait operation fails.
NTSYSAPI
VOID
NTAPI
RtlpWaitForCriticalSection(
	IN PRTL_CRITICAL_SECTION CriticalSection
	);

// RtlpUnWaitForCriticalSection releases exclusive ownership of a critical section.  In Windows Server 2003,
// the priority of a thread waiting for a critical section is temporarily boosted by this routine.
// A noncontinuable status is raised if the unwait operation fails.
NTSYSAPI
VOID
NTAPI
RtlpUnWaitForCriticalSection(
	IN PRTL_CRITICAL_SECTION CriticalSection
	);

#if _WIN32_WINNT >= 0x0501

// RtlExitUserThread exits the current thread.  It alo sets a flag in the TEB that indicates to the kernel that the
// exiting thread's stack was allocated with NtAllocateVirtualMemory, and should be freed when the thread is terminated.
// Normally, the thread's stack must be released explicitly; the kernel does not usually free the stack on thread termination.
DECLSPEC_NORETURN
NTSYSAPI
VOID
NTAPI
RtlExitUserThread(
	IN NTSTATUS ExitStatus
	);

#endif

//
// Rtl Resource routines
//

// RtlInitializeResource initializes a new resource.
NTSYSAPI
VOID
NTAPI
RtlInitializeResource(
	OUT PRTL_RESOURCE Resource
	);

// RtlAcquireResourceShared acquires shared access to a resource.
NTSYSAPI
BOOLEAN
NTAPI
RtlAcquireResourceShared(
	IN PRTL_RESOURCE Resource,
	IN BOOLEAN Wait
	);

// RtlAcquireResourceExclusive acquires exclusive access to a resource.
NTSYSAPI
BOOLEAN
NTAPI
RtlAcquireResourceExclusive(
	IN PRTL_RESOURCE Resource,
	IN BOOLEAN Wait
	);

// RtlReleaseResource releases shared or exclusive access to a resource.
NTSYSAPI
VOID
NTAPI
RtlReleaseResource(
	IN PRTL_RESOURCE Resource
	);

// RtlConvertSharedToExclusive converts a shared resource acquisition to an exclusive acquisition.
NTSYSAPI
VOID
NTAPI
RtlConvertSharedToExclusive(
	IN PRTL_RESOURCE Resource
	);

// RtlConvertExclusiveToShared converts an exclusive resource acquisition to a shared acquisition.
NTSYSAPI
VOID
NTAPI
RtlConvertExclusiveToShared(
	IN PRTL_RESOURCE Resource
	);

// RtlDeleteResource releases system resources used to maintain an RTL_RESOURCE.
NTSYSAPI
VOID
NTAPI
RtlDeleteResource (
	IN PRTL_RESOURCE Resource
	);

// RtlRemoteCall executes a function call in the context of a different process.
NTSYSAPI
NTSTATUS
NTAPI
RtlRemoteCall(
	IN HANDLE Process,
	IN HANDLE Thread,
	IN PVOID CallSite,
	IN ULONG ArgumentCount,
    IN PULONG Arguments,
	IN BOOLEAN PassContext,
    IN BOOLEAN AlreadySuspended
	);

#endif

//
// Conversion Routines
//

#ifndef _NTTYPES_NO_BASETYPES

#ifdef _WIN64

#define ADDRESS_TAG_BIT 0x40000000000UI64

typedef __int64 SHANDLE_PTR;
typedef unsigned __int64 HANDLE_PTR;
typedef unsigned int UHALF_PTR, *PUHALF_PTR;
typedef int HALF_PTR, *PHALF_PTR;

#if !defined(__midl)
__inline
unsigned long
HandleToULong(
    const void *h
    )
{
    return((unsigned long) (ULONG_PTR) h );
}

__inline
long
HandleToLong(
    const void *h
    )
{
    return((long) (LONG_PTR) h );
}

__inline
void *
ULongToHandle(
    const unsigned long h
    )
{
    return((void *) (UINT_PTR) h );
}


__inline
void *
LongToHandle(
    const long h
    )
{
    return((void *) (INT_PTR) h );
}


__inline
unsigned long
PtrToUlong(
    const void  *p
    )
{
    return((unsigned long) (ULONG_PTR) p );
}

__inline
unsigned int
PtrToUint(
    const void  *p
    )
{
    return((unsigned int) (UINT_PTR) p );
}

__inline
unsigned short
PtrToUshort(
    const void  *p
    )
{
    return((unsigned short) (unsigned long) (ULONG_PTR) p );
}

__inline
long
PtrToLong(
    const void  *p
    )
{
    return((long) (LONG_PTR) p );
}

__inline
int
PtrToInt(
    const void  *p
    )
{
    return((int) (INT_PTR) p );
}

__inline
short
PtrToShort(
    const void  *p
    )
{
    return((short) (long) (LONG_PTR) p );
}

__inline
void *
IntToPtr(
    const int i
    )
// Caution: IntToPtr() sign-extends the int value.
{
    return( (void *)(INT_PTR)i );
}

__inline
void *
UIntToPtr(
    const unsigned int ui
    )
// Caution: UIntToPtr() zero-extends the unsigned int value.
{
    return( (void *)(UINT_PTR)ui );
}

__inline
void *
LongToPtr(
    const long l
    )
// Caution: LongToPtr() sign-extends the long value.
{
    return( (void *)(LONG_PTR)l );
}

__inline
void *
ULongToPtr(
    const unsigned long ul
    )
// Caution: ULongToPtr() zero-extends the unsigned long value.
{
    return( (void *)(ULONG_PTR)ul );
}

#define PtrToPtr64( p )         ((void * POINTER_64) p)
#define Ptr64ToPtr( p )         ((void *) p)
#define HandleToHandle64( h )   (PtrToPtr64( h ))
#define Handle64ToHandle( h )   (Ptr64ToPtr( h ))

__inline
void *
Ptr32ToPtr(
    const void * POINTER_32 p
    )
{
    return((void *) (ULONG_PTR) (unsigned long) p);
}

__inline
void *
Handle32ToHandle(
    const void * POINTER_32 h
    )
{
    return((void *) h);
}

__inline
void * POINTER_32
PtrToPtr32(
    const void *p
    )
{
    return((void * POINTER_32) (unsigned long) (ULONG_PTR) p);
}

#define HandleToHandle32( h )       (PtrToPtr32( h ))

#endif // !_midl

#else  // !_WIN64

#define ADDRESS_TAG_BIT 0x80000000UL

typedef unsigned short UHALF_PTR, *PUHALF_PTR;
typedef short HALF_PTR, *PHALF_PTR;

#ifndef __IDA__
typedef _W64 long SHANDLE_PTR;
typedef _W64 unsigned long HANDLE_PTR;
#else
typedef long SHANDLE_PTR;
typedef unsigned long HANDLE_PTR;
#endif

#define HandleToULong( h ) ((ULONG)(ULONG_PTR)(h) )
#define HandleToLong( h )  ((LONG)(LONG_PTR) (h) )
#define ULongToHandle( ul ) ((HANDLE)(ULONG_PTR) (ul) )
#define LongToHandle( h )   ((HANDLE)(LONG_PTR) (h) )
#define PtrToUlong( p ) ((ULONG)(ULONG_PTR) (p) )
#define PtrToLong( p )  ((LONG)(LONG_PTR) (p) )
#define PtrToUint( p ) ((UINT)(UINT_PTR) (p) )
#define PtrToInt( p )  ((INT)(INT_PTR) (p) )
#define PtrToUshort( p ) ((unsigned short)(ULONG_PTR)(p) )
#define PtrToShort( p )  ((short)(LONG_PTR)(p) )
#define IntToPtr( i )    ((VOID *)(INT_PTR)((int)i))
#define UIntToPtr( ui )  ((VOID *)(UINT_PTR)((unsigned int)ui))
#define LongToPtr( l )   ((VOID *)(LONG_PTR)((long)l))
#define ULongToPtr( ul ) ((VOID *)(ULONG_PTR)((unsigned long)ul))

#if !defined(__midl) && !defined(__IDA__)
__inline
void * POINTER_64
PtrToPtr64(
    const void *p
    )
{
    return((void * POINTER_64) (unsigned __int64) (ULONG_PTR)p );
}

__inline
void *
Ptr64ToPtr(
    const void * POINTER_64 p
    )
{
    return((void *) (ULONG_PTR) (unsigned __int64) p);
}

__inline
void * POINTER_64
HandleToHandle64(
    const void *h
    )
{
    return((void * POINTER_64) h );
}

__inline
void *
Handle64ToHandle(
    const void * POINTER_64 h
    )
{
    return((void *) (ULONG_PTR) (unsigned __int64) h );
}
#endif

#define Ptr32ToPtr( p )         ((void *) p)
#define Handle32ToHandle( h )   (Ptr32ToPtr( h ))
#define PtrToPtr32( p )         ((void * POINTER_32) p)
#define HandleToHandle32( h )   (PtrToPtr32( h ))

#endif // !_WIN64

#define HandleToUlong(h)  HandleToULong(h)
#define UlongToHandle(ul) ULongToHandle(ul)
#define UlongToPtr(ul) ULongToPtr(ul)
#define UintToPtr(ui)  UIntToPtr(ui)

#define MAXUINT_PTR  (~((UINT_PTR)0))
#define MAXINT_PTR   ((INT_PTR)(MAXUINT_PTR >> 1))
#define MININT_PTR   (~MAXINT_PTR)

#define MAXULONG_PTR (~((ULONG_PTR)0))
#define MAXLONG_PTR  ((LONG_PTR)(MAXULONG_PTR >> 1))
#define MINLONG_PTR  (~MAXLONG_PTR)

#define MAXUHALF_PTR ((UHALF_PTR)~0)
#define MAXHALF_PTR  ((HALF_PTR)(MAXUHALF_PTR >> 1))
#define MINHALF_PTR  (~MAXHALF_PTR)

#endif

#ifndef __IDA__

//
// List APIs
//

#define InitializeListHead32(ListHead) (\
	(ListHead)->Flink = (ListHead)->Blink = PtrToUlong((ListHead)))

VOID
FORCEINLINE
InitializeListHead(
    IN PLIST_ENTRY ListHead
    )
{
    ListHead->Flink = ListHead->Blink = ListHead;
}

#define IsListEmpty(ListHead) \
	((ListHead)->Flink == (ListHead))

BOOLEAN
FORCEINLINE
RemoveEntryList(
    IN PLIST_ENTRY Entry
    )
{
    PLIST_ENTRY Blink;
    PLIST_ENTRY Flink;

    Flink = Entry->Flink;
    Blink = Entry->Blink;
    Blink->Flink = Flink;
    Flink->Blink = Blink;
    return (BOOLEAN)(Flink == Blink);
}

PLIST_ENTRY
FORCEINLINE
RemoveHeadList(
    IN PLIST_ENTRY ListHead
    )
{
    PLIST_ENTRY Flink;
    PLIST_ENTRY Entry;

    Entry = ListHead->Flink;
    Flink = Entry->Flink;
    ListHead->Flink = Flink;
    Flink->Blink = ListHead;
    return Entry;
}

PLIST_ENTRY
FORCEINLINE
RemoveTailList(
    IN PLIST_ENTRY ListHead
    )
{
    PLIST_ENTRY Blink;
    PLIST_ENTRY Entry;

    Entry = ListHead->Blink;
    Blink = Entry->Blink;
    ListHead->Blink = Blink;
    Blink->Flink = ListHead;
    return Entry;
}

VOID
FORCEINLINE
InsertTailList(
    IN PLIST_ENTRY ListHead,
    IN PLIST_ENTRY Entry
    )
{
    PLIST_ENTRY Blink;

    Blink = ListHead->Blink;
    Entry->Flink = ListHead;
    Entry->Blink = Blink;
    Blink->Flink = Entry;
    ListHead->Blink = Entry;
}

VOID
FORCEINLINE
InsertHeadList(
    IN PLIST_ENTRY ListHead,
    IN PLIST_ENTRY Entry
    )
{
    PLIST_ENTRY Flink;

    Flink = ListHead->Flink;
    Entry->Flink = Flink;
    Entry->Blink = ListHead;
    Flink->Blink = Entry;
    ListHead->Flink = Entry;
}

#define PopEntryList(ListHead) \
    (ListHead)->Next;\
    {\
        PSINGLE_LIST_ENTRY FirstEntry;\
        FirstEntry = (ListHead)->Next;\
        if (FirstEntry != NULL) {     \
            (ListHead)->Next = FirstEntry->Next;\
        }                             \
    }

#define PushEntryList(ListHead,Entry) \
    (Entry)->Next = (ListHead)->Next; \
    (ListHead)->Next = (Entry)

#endif

#if _WIN32_WINNT >= 0x0600

//
// Define the slim r/w lock
//

#if !defined( _WINNT ) && !defined( _NTDEF_ )

typedef struct _RTL_SRWLOCK {                            
        PVOID Ptr;                                       
} RTL_SRWLOCK, *PRTL_SRWLOCK; 

#endif

#ifndef RTL_SRWLOCK_INIT
#define RTL_SRWLOCK_INIT {0}  
#endif


NTSYSAPI
VOID
NTAPI
RtlInitializeSRWLock (
     __out PSRWLOCK SRWLock
     );

NTSYSAPI
VOID
NTAPI
RtlReleaseSRWLockExclusive (
     __inout PSRWLOCK SRWLock
     );

NTSYSAPI
VOID
NTAPI
RtlReleaseSRWLockShared (
     __inout PSRWLOCK SRWLock
     );

NTSYSAPI
VOID
NTAPI
RtlAcquireSRWLockExclusive (
     __inout PSRWLOCK SRWLock
     );

NTSYSAPI
VOID
NTAPI
RtlAcquireSRWLockShared (
     __inout PSRWLOCK SRWLock
     );

#endif

_NTNATIVE_END_NT

#endif
