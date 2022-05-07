
using MSDN.Api;
using MSDN.Enum;
using MSDN.Error;
using MSDN.Struct;
using MSDN.Wrapper;
using MSDN.Delegate;
using MSDN.Extension;
using MSDN.Interface;
using MSDN.SafeHandle;

using System;
using System.Text;
using System.Runtime.InteropServices;

using GUID = System.Guid;

using WCHAR = System.Char;
using TCHAR = System.Char;
using LPCTSTR = System.String;

using BOOL = System.Boolean;
using BOOLEAN = System.Byte;

using BYTE = System.Byte;
using CHAR = System.Byte;
using UCHAR = System.Byte;
using UINT8 = System.Byte;

using WORD = System.Int16;
using SHORT = System.Int16;
using USHORT = System.UInt16;

using LANGID = System.UInt32;
using DWORD = System.UInt32;
using UINT = System.UInt32;
using DEVICE_TYPE = System.UInt32;
using SIZE_T = System.UInt32;
using UINT32 = System.UInt32;
using ULONG = System.UInt32;
using LONG = System.Int32;
using COLORREF = System.UInt32;
using INT = System.Int32;
using SCOPE_ID = System.UInt32;
using NET_IFINDEX = System.Int32;

using DWORD64 = System.UInt64;
using DWORDLONG = System.UInt64;
using LARGE_INTEGER = System.Int64;
using ULONG64 = System.UInt64;
using LONGLONG = System.Int64;
using ULONGLONG = System.UInt64;
using USN = System.Int64;
using time_t = System.Int64;
using NET_LUID = System.UInt64;

using HDC = System.IntPtr;
using HDEVINFO = System.IntPtr;
using DEVINST = System.IntPtr;
using HPALETTE = System.IntPtr;
using ULONG_PTR = System.UIntPtr;
using DWORD_PTR = System.UIntPtr;
using FARPROC = System.IntPtr;
using VOID = System.IntPtr;
using PVOID = System.IntPtr;
using LPVOID = System.IntPtr;
using HMODULE = System.IntPtr;
using HANDLE = System.IntPtr;
using HWND = System.IntPtr;
using HGLOBAL = System.IntPtr;
using LONG_PTR = System.IntPtr;
using HLOCAL = System.IntPtr;
using LPCVOID = System.IntPtr;
using HMENU = System.IntPtr;
using HINSTANCE = System.IntPtr;
using CONFLICT_LIST = System.IntPtr;

namespace MSDN.ToDo
{
        static class kernel32
        {
            #region Power Management

            // Power Management Functions 
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa373163(v=vs.85).aspx

            // About Power Management
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa372422(v=vs.85).aspx

            // Using the Device Power API
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa373243(v=vs.85).aspx

            #endregion
        }

        static class wlanapi
        {
            #region Bluetooth

            // >>> DEVICE

            //BluetoothFindFirstDevice
            //BluetoothFindNextDevice
            //BluetoothFindDeviceClose

            //BluetoothSelectDevices
            //BluetoothSelectDevicesFree

            //BluetoothAuthenticateDevice
            //BluetoothAuthenticateDeviceEx
            //BluetoothAuthenticateMultipleDevices

            //BluetoothRemoveDevice
            //BluetoothUpdateDeviceRecord

            //BluetoothGetDeviceInfo
            //BluetoothDisplayDeviceProperties

            // >>> RADIO

            //BluetoothFindFirstRadio
            //BluetoothFindNextRadio
            //BluetoothFindRadioClose

            //BluetoothGetRadioInfo

            // >>> Services

            //BluetoothSetServiceState
            //BluetoothSetLocalServiceInfo
            //BluetoothEnumerateInstalledServices

            // >>> Sdp

            //BluetoothSdpEnumAttributes
            //BluetoothSdpGetAttributeValue
            //BluetoothSdpGetContainerElementData
            //BluetoothSdpGetElementData
            //BluetoothSdpGetString

            // >>> Authentication

            //BluetoothSendAuthenticationResponse
            //BluetoothSendAuthenticationResponseEx

            //BluetoothRegisterForAuthentication
            //BluetoothRegisterForAuthenticationEx
            //BluetoothUnregisterAuthentication

            // >>> { Get; Set; }

            //BluetoothIsConnectable
            //BluetoothIsDiscoverable
            //BluetoothIsVersionAvailable

            //BluetoothEnableDiscovery
            //BluetoothEnableIncomingConnections

            #endregion
        }

        static class advapi32
        {
            #region LUID

            // (LUID)
            // A 64-bit value that is guaranteed to be unique on the operating system that generated it until the system is restarted.

            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern BOOL AllocateLocallyUniqueId(
                out LUID luid);

            #endregion

            #region Authz

            // AuthzAccessCheck
            // AuthzAccessCheckCallback

            // AuthzReportSecurityEvent
            // AuthzReportSecurityEventFromParams

            // AuthzInstallSecurityEventSource
            // AuthzUninstallSecurityEventSource

            // AuthzModifySids
            // AuthzModifyClaims
            // AuthzModifySecurityAttributes

            // AuthzRegisterSecurityEventSource
            // AuthzRegisterCapChangeNotification
            // AuthzUnregisterSecurityEventSource
            // AuthzUnregisterCapChangeNotification

            // AuthzInitializeCompoundContext
            // AuthzInitializeContextFromAuthzContext
            // AuthzInitializeContextFromSid
            // AuthzInitializeContextFromToken
            // AuthzInitializeObjectAccessAuditEvent
            // AuthzInitializeObjectAccessAuditEvent2
            // AuthzInitializeRemoteResourceManager
            // AuthzInitializeResourceManager
            // AuthzInitializeResourceManagerEx

            // AuthzFreeAuditEvent
            // AuthzFreeCentralAccessPolicyCache
            // AuthzFreeContext
            // AuthzFreeGroupsCallback
            // AuthzFreeHandle
            // AuthzFreeResourceManager

            // ???????

            // AuthzOpenObjectAudit
            // AuthzAddSidsToContext
            // AuthzCachedAccessCheck
            // AuthzComputeGroupsCallback
            // AuthzGetInformationFromContext
            // AuthzSetAppContainerInformation
            // AuthzEnumerateSecurityEventSources

            #endregion

            #region security property

            // EditSecurity
            // EditSecurityAdvanced
            // CreateSecurityPage

            // DSEditSecurity
            // DSCreateSecurityPage 
            // DSCreateISecurityInfoObject
            // DSCreateISecurityInfoObjectEx

            #endregion

            #region security descriptor [PrivateObject]

            // CreatePrivateObjectSecurity
            // CreatePrivateObjectSecurityEx
            // CreatePrivateObjectSecurityWithMultipleInheritance
            // DestroyPrivateObjectSecurity
            // ConvertToAutoInheritPrivateObjectSecurity 

            #endregion

            #region security descriptor :: ACE [Audit Alarm]

            // ObjectOpenAuditAlarm
            // ObjectCloseAuditAlarm
            // ObjectDeleteAuditAlarm
            // ObjectPrivilegeAuditAlarm 

            #endregion

            #region security descriptor :: ACE [Access Mask]

            /// <summary>
            /// creates an access mask that represents the access permissions necessary
            /// to query the specified object security information.
            /// </summary>
            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern void QuerySecurityAccessMask(
                SECURITY_INFORMATION securityInformation,
                out ACCESS_MASK desiredAccess);

            /// <summary>
            /// creates an access mask that represents the access permissions necessary
            /// to set the specified object security information.
            /// </summary>
            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern void SetSecurityAccessMask(
                SECURITY_INFORMATION securityInformation,
                out ACCESS_MASK desiredAccess);

            /// <summary>
            /// maps the generic access rights in an access mask 
            /// to specific and standard access rights. 
            /// </summary>
            [DllImport("Advapi32.dll", SetLastError = true)]
            public static extern void MapGenericMask(
                ref ACCESS_MASK accessMask,
                ref GENERIC_MAPPING genericMapping);

            // AreAllAccessesGranted
            // AreAnyAccessesGranted

            #endregion

            #region security descriptor :: ACE [Access Check]

            // AccessCheck
            // AccessCheckByType
            // AccessCheckByTypeAndAuditAlarm
            // AccessCheckByTypeResultList
            // AccessCheckByTypeResultListAndAuditAlarm
            // AccessCheckByTypeResultListAndAuditAlarmByHandle

            #endregion
        }
}
