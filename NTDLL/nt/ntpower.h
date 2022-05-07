#ifndef NTPOWER_H
#define NTPOWER_H

#pragma once

_NTNATIVE_BEGIN_NT

// NtRequestWakeupLatency controls the speed with which the system should be able to
// enter the working state.
NTSYSAPI
NTSTATUS
NTAPI
NtRequestWakeupLatency(
	IN LATENCY_TIME Latency
	);

// ZwRequestWakeupLatency controls the speed with which the system should be able to
// enter the working state.
NTSYSAPI
NTSTATUS
NTAPI
ZwRequestWakeupLatency(
	IN LATENCY_TIME Latency
	);

// NtRequestDeviceWakeup issues a wakeup request to a device.
NTSYSAPI
NTSTATUS
NTAPI
NtRequestDeviceWakeup(
	IN HANDLE DeviceHandle
	);

// ZwRequestDeviceWakeup issues a wakeup request to a device.
NTSYSAPI
NTSTATUS
NTAPI
ZwRequestDeviceWakeup(
	IN HANDLE DeviceHandle
	);

// NtCancelDeviceWakeupRequest cancels a previously issued device wakeup request.
NTSYSAPI
NTSTATUS
NTAPI
NtCancelDeviceWakeupRequest(
	IN HANDLE DeviceHandle
	);

// ZwCancelDeviceWakeupRequest cancels a previously issued device wakeup request.
NTSYSAPI
NTSTATUS
NTAPI
ZwCancelDeviceWakeupRequest(
	IN HANDLE DeviceHandle
	);

// NtIsSystemResumeAutomatic reports whether the system was resumed to handle a
// scheduled event or was resumed in response to user activity.
NTSYSAPI
BOOLEAN
NTAPI
NtIsSystemResumeAutomatic(
	VOID
	);

// ZwIsSystemResumeAutomatic reports whether the system was resumed to handle a
// scheduled event or was resumed in response to user activity.
NTSYSAPI
BOOLEAN
NTAPI
ZwIsSystemResumeAutomatic(
	VOID
	);

// NtSetThreadExecutionState sets the execution requirements of the current thread.
NTSYSAPI
NTSTATUS
NTAPI
NtSetThreadExecutionState(
	IN EXECUTION_STATE ExecutionState,
	OUT PEXECUTION_STATE PreviousExecutionState
	);

// ZwSetThreadExecutionState sets the execution requirements of the current thread.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetThreadExecutionState(
	IN EXECUTION_STATE ExecutionState,
	OUT PEXECUTION_STATE PreviousExecutionState
	);

// NtGetDevicePowerState retrieves the power state of a device.
NTSYSAPI
NTSTATUS
NTAPI
NtGetDevicePowerState(
	IN HANDLE DeviceHandle,
	OUT PDEVICE_POWER_STATE DevicePowerState
	);

// ZwGetDevicePowerState retrieves the power state of a device.
NTSYSAPI
NTSTATUS
NTAPI
ZwGetDevicePowerState(
	IN HANDLE DeviceHandle,
	OUT PDEVICE_POWER_STATE DevicePowerState
	);

// NtSetSystemPowerState sets the power state of the system.
NTSYSAPI
NTSTATUS
NTAPI
NtSetSystemPowerState(
	IN POWER_ACTION SystemAction,
	IN SYSTEM_POWER_STATE MinSystemState,
	IN ULONG Flags
	);

// ZwSetSystemPowerState sets the power state of the system.
NTSYSAPI
NTSTATUS
NTAPI
ZwSetSystemPowerState(
	IN POWER_ACTION SystemAction,
	IN SYSTEM_POWER_STATE MinSystemState,
	IN ULONG Flags
	);

// NtInitiatePowerAction initiates a power action.
NTSYSAPI
NTSTATUS
NTAPI
NtInitiatePowerAction(
	IN POWER_ACTION SystemAction,
	IN SYSTEM_POWER_STATE MinSystemState,
	IN ULONG Flags,
	IN BOOLEAN Asynchronous
	);

// ZwInitiatePowerAction initiates a power action.
NTSYSAPI
NTSTATUS
NTAPI
ZwInitiatePowerAction(
	IN POWER_ACTION SystemAction,
	IN SYSTEM_POWER_STATE MinSystemState,
	IN ULONG Flags,
	IN BOOLEAN Asynchronous
	);

// NtPowerInformation sets or queries power information.
NTSYSAPI
NTSTATUS
NTAPI
NtPowerInformation(
	IN POWER_INFORMATION_LEVEL PowerInformationLevel,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength
	);

// ZwPowerInformation sets or queries power information.
NTSYSAPI
NTSTATUS
NTAPI
ZwPowerInformation(
	IN POWER_INFORMATION_LEVEL PowerInformationLevel,
	IN PVOID InputBuffer OPTIONAL,
	IN ULONG InputBufferLength,
	OUT PVOID OutputBuffer OPTIONAL,
	IN ULONG OutputBufferLength
	);

_NTNATIVE_END_NT

#endif
