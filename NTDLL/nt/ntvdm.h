#ifndef NTVDM_H
#define NTVDM_H

#pragma once

_NTNATIVE_BEGIN_NT

#ifdef _M_IX86

typedef enum _VdmServiceClass {
	VdmStartExecution,      
	VdmQueueInterrupt,
	VdmDelayInterrupt,
	VdmInitialize,
	VdmFeatures,
	VdmSetInt21Handler,
	VdmQueryDir,
	VdmPrinterDirectIoOpen,
	VdmPrinterDirectIoClose,
	VdmPrinterInitialize,
	VdmSetLdtEntries,
	VdmSetProcessLdtInfo,
	VdmAdlibEmulation,
	VdmPMCliControl,
	VdmQueryVdmProcess
} VDMSERVICECLASS, *PVDMSERVICECLASS;

typedef HANDLE _INTERRUPT_V86_THREAD, INTERRUPT_V86_THREAD, *PINTERRUPT_V86_THREAD;

typedef struct _DELAY_V86_INTERRUPT {
	ULONG Delay;
} DELAY_V86_INTERRUPT, *PDELAY_V86_INTERRUPT;

typedef struct _ICA_DATA {
	ULONG Unknown[9];
} ICA_DATA, *PICA_DATA;

typedef struct _VdmQueryVdmProcess {
	HANDLE VdmProcess;
	ULONG IsVdmProcess;
} VDMQUERYVDMPROCESS, * PVDMQUERYVDMPROCESS;

//
// NtVdm!VdmTrapcHandler
//
#ifdef NTNATIVE_VDM_FUNCTIONS

__declspec(naked)
inline
VOID
VdmTrapcHandler(
	VOID
	)
{
	__asm {
		and		esp, 0xffff
		push	dword ptr [ebx+0x394]
		push	dword ptr [ebx+0x390]
		mov		ebx, dword ptr [ebx+0x37c]
		retf
	}
}

#endif

typedef enum _V86_FEATURE_BITS {
	Unknown1					=	0x00000001,
	Unknown2					=	0x00000002
} V86_FEATURE_BITS, PV86_FEATURE_BITS;

typedef enum _V86_OPTION {
	DisableIFWorkaround			=	0,	// Interrupt Flag workaround for PUSHF/CLI/POPF
	EnableIFWorkaround			=	1,
	DisableUnknownOption1		=	2,	// Possibly disable interrupts
	EnableUnknownOption1		=	3,
	DisableUnknownOption2		=	4
} V86_OPTION, *PV86_OPTION;




// NtSetLdtEntries sets Local Descriptor Table (LDT) entries for a Virtual DOS
// Machine (VDM).
NTSYSAPI
NTSTATUS
NTAPI
NtSetLdtEntries(
	IN ULONG Selector1,
	IN LDT_ENTRY LdtEntry1,
	IN ULONG Selector2,
	IN LDT_ENTRY LdtEntry2
	);

// ZwSetLdtEntries sets Local Descriptor Table (LDT) entries for a Virtual DOS
// Machine (VDM).
NTSYSAPI
NTSTATUS
NTAPI
ZwSetLdtEntries(
	IN ULONG Selector1,
	IN LDT_ENTRY LdtEntry1,
	IN ULONG Selector2,
	IN LDT_ENTRY LdtEntry2
	);

//
// In Windows Server 2003, a process needs to be given permission to use NtVdmControl.
// This is done by calling NtSetInformationProcess with ProcessIoPortHandlers.
// The information parameter should point to a ULONG variable.  If this variable is
// TRUE, then the process is allowed to use NtVdmControl.  Otherwise, STATUS_ACCESS_DENIED
// will be returned for all VDM service classes except VdmQueryVdmProcess.
//
// Setting ProcessIoPortHandlers requires SeTcbPrivilege.
//

// NtVdmControl performs a control operation on a VDM.
NTSYSAPI
NTSTATUS
NTAPI
NtVdmControl(
	IN VDMSERVICECLASS Service,
	IN OUT PVOID ServiceData
	);

// ZwVdmControl performs a control operation on a VDM.
NTSYSAPI
NTSTATUS
NTAPI
ZwVdmControl(
	IN VDMSERVICECLASS Service,
	IN OUT PVOID ServiceData
	);

#endif


_NTNATIVE_END_NT

#endif
