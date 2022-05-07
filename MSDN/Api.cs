using System;
using System.Text;
using Accessibility;
using System.Management;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

using MSDN.Api;
using MSDN.Enum;
using MSDN.Error;
using MSDN.Struct;
using MSDN.Wrapper;
using MSDN.Delegate;
using MSDN.Extension;
using MSDN.Interface;
using MSDN.SafeHandle;

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

namespace MSDN.Api
{
    static class undocument
    {
        #region IP Helper

        [DllImport("iphlpdll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern DWORD SetAdapterIpAddress(
            // GetAdaptersAddresses() && adapterAddresses.AdapterName
            string dwAdapterName,
            BOOL dwDhcp,
            in_addr dwIP,
            in_addr dwMask,
            in_addr dwGateway);

        [Obsolete("Undocument Function")]
        [DllImport("dhcpcsvc.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern DWORD DhcpNotifyConfigChange(
            string lpwszServerName,         // local machine should be NULL
            string lpwszAdapterName,        // GetAdaptersAddresses() && adapterAddresses.AdapterName
            BOOL bNewIpAddress,             // TRUE indicates changing ip
            DWORD dwIpIndex,                // which IP addr, if only 1, it's 0
            in_addr dwIpAddress,  // IP address
            in_addr dwSubNetMask, // SubNet Mask
            int nDhcpAction);               // 0 - don't modify 1 - enable DHCP 2 - disable DHCP

        [Obsolete("Undocument Function")]
        [DllImport("Dnsapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern DWORD DnsFlushResolverCache();

        #endregion
    }
    public static class newdev
    {
        #region Device

        /* Updates the function driver that is installed for matching PnP devices
            that are present in the system.  */
        [DllImport("Newdev.dll", SetLastError = true)]
        public static extern BOOL UpdateDriverForPlugAndPlayDevices(
            SafeWindowHandle hwndParent,
            string hardwareId,
            string fullInfPath,
            DWORD installFlags,
            out BOOL bRebootRequired);

        #endregion

        #region Device Management

        [DllImport("newdev.dll", SetLastError = true)]
        public unsafe static extern BOOL InstallNewDevice(
            SafeWindowHandle hwndParent,
            GUID* classGuid,
            out WORD pReboot);

        #endregion
    }
    public static class wlanapi
    {
        #region Bluetooth

        // Bluetooth
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa362932(v=vs.85).aspx

        // Bluetooth Reference
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa362930(v=vs.85).aspx

        // Bluetooth Programming with Windows Sockets
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa362928(v=vs.85).aspx

        // Discovering Bluetooth Devices and Services [using Windows Sockets]
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa362941(v=vs.85).aspx

        // SOCKADDR_BTH
        // new Socket(AddressFamilies.BTH, SocketType.STREAM, SocketProtocolInt.BTHPROTO_RFCOMM)

        #endregion

        #region Native Wifi

        // Memory

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern IntPtr WlanAllocateMemory(
            uint dwMemorySize);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern void WlanFreeMemory(
            IntPtr pMemory);

        // Handle

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanOpenHandle(
            // 0x1 [xp]
            // 0x2 [vista]
            uint dwClientVersion,
            IntPtr pReserved,
            out uint pdwNegotiatedVersion,
            out IntPtr phClientHandle);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanCloseHandle(
            IntPtr hClientHandle,
            IntPtr pReserved);

        // Interface 

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern uint WlanEnumInterfaces(
            IntPtr hClientHandle,
            IntPtr pReserved,
            // WLAN_INTERFACE_INFO_LIST* ppInterfaceList
            // &ppInterfaceList
            WLAN_INTERFACE_INFO_LIST** ppInterfaceList);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern uint WlanQueryInterface(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            WLAN_INTF_OPCODE opCode,
            IntPtr pReserved,
            out uint pdwDataSize,
            out IntPtr ppData,
            [Optional] WLAN_OPCODE_VALUE_TYPE* pWlanOpcodeValueType);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanSetInterface(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            WLAN_INTF_OPCODE opCode,
            uint dwDataSize,
            IntPtr pData,
            IntPtr pReserved);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern uint WlanGetInterfaceCapability(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            IntPtr pReserved,
            // WLAN_INTERFACE_CAPABILITY* ppCapability
            // &ppCapability
            WLAN_INTERFACE_CAPABILITY** ppCapability);

        // Network

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern uint WlanScan(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            [Optional] DOT11_SSID* pDot11Ssid,
            [Optional] WLAN_RAW_DATA* pIeData,
            IntPtr pReserved);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern uint WlanGetAvailableNetworkList(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            // 0x0 or 0x0|0x01|0x02 to include all network
            uint dwFlags,
            IntPtr pReserved,
            // WLAN_AVAILABLE_NETWORK_LIST* ppAvailableNetworkList
            // &ppAvailableNetworkList
            WLAN_AVAILABLE_NETWORK_LIST** ppAvailableNetworkList);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern uint WlanGetNetworkBssList(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            [Optional] DOT11_SSID* pDot11Ssid,
            DOT11_BSS_TYPE dot11BssType,
            BOOL bSecurityEnabled,
            PVOID pReserved,
            // WLAN_BSS_LIST* ppWlanBssList
            // &ppWlanBssList
            [Out] WLAN_BSS_LIST** ppWlanBssList);

        // Connect. Disconnect.

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanConnect(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            ref WLAN_CONNECTION_PARAMETERS pConnectionParameters,
            IntPtr pReserved);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanDisconnect(
          FARPROC hClientHandle,
          ref Guid pInterfaceGuid,
          IntPtr pReserved);

        // { Get }

        //WlanGetFilterList
        //WlanGetSecuritySettings 
        //WlanExtractPsdIEDataList
        //WlanQueryAutoConfigParameter

        // { Set }

        //WlanSetFilterList 
        //WlanSetSecuritySettings
        //WlanSetPsdIeDataList
        //WlanSetAutoConfigParameter 

        // Profile { Get }

        // to Enum use (&ppProfileList->First)[i]
        [DllImport("Wlanapi.dll", SetLastError = true)]
        public unsafe static extern DWORD WlanGetProfileList(
            HANDLE hClientHandle,
            ref GUID pInterfaceGuid,
            PVOID pReserved,
            // >> 
            // WLAN_PROFILE_INFO_LIST *ppProfileList
            // &ppProfileList 
            // <<
            WLAN_PROFILE_INFO_LIST** ppProfileList);

        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern uint WlanGetProfile(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            string strProfileName,
            IntPtr pReserved,
            out string pstrProfileXml,
            // 0x00000000 [XP]
            // 0x00000004 [Vista]
            ref uint pdwFlags,
            ref uint pdwGrantedAccess);

        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern DWORD WlanGetProfileCustomUserData(
            HANDLE hClientHandle,
            ref GUID pInterfaceGuid,
            string strProfileName,
            PVOID pReserved,
            out DWORD pdwDataSize,
            IntPtr ppData);

        // Profile { Set }

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern uint WlanSetProfileList(
            IntPtr hClientHandle,
            ref GUID pInterfaceGuid,
            uint dwItems,
            [MarshalAs(UnmanagedType.LPArray), In] string[] strProfileNames,
            IntPtr pReserved);

        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern uint WlanSetProfile(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            // 0x00 [All]
            // 0x01 [GroupPolicy]
            // 0x02 [ProfileUser]
            uint dwFlags,
            string strProfileXml,
            [Optional] string strAllUserProfileSecurity,
            bool bOverwrite,
            IntPtr pReserved,
            out uint pdwReasonCode);

        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern uint WlanSetProfileCustomUserData(
            IntPtr hClientHandle,
            ref GUID pInterfaceGuid,
            string strProfileName,
            uint dwDataSize,
            IntPtr pData,
            IntPtr pReserved);

        // ----------------------

        // use WlanGetProfileList to get exiting position
        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern uint WlanSetProfilePosition(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            string strProfileName,
            uint dwPosition,
            IntPtr pReserved);
 
        //WlanSetProfileEapUserData 
        //WlanSetProfileEapXmlUserData 

        // Profile { Misc }

        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern uint WlanDeleteProfile(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            string strProfileName,
            IntPtr pReserved);

        [DllImport("Wlanapi.dll", SetLastError = true,
            CharSet = CharSet.Unicode)]
        public static extern uint WlanRenameProfile(
            IntPtr hClientHandle,
            ref Guid pInterfaceGuid,
            string strOldProfileName,
            string strNewProfileName,
            IntPtr pReserved);
 
        //WlanUIEditProfile 
        //WlanSaveTemporaryProfile

        // Hosted Network

        //WlanHostedNetworkForceStart 
        //WlanHostedNetworkForceStop 
        //WlanHostedNetworkInitSettings 
        //WlanHostedNetworkQueryProperty 
        //WlanHostedNetworkQuerySecondaryKey 
        //WlanHostedNetworkQueryStatus 
        //WlanHostedNetworkRefreshSecuritySettings 
        //WlanHostedNetworkSetProperty 
        //WlanHostedNetworkSetSecondaryKey 
        //WlanHostedNetworkStartUsing 
        //WlanHostedNetworkStopUsing 

        // Notification

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern DWORD WlanRegisterNotification(
            HANDLE hClientHandle,
            WLAN_NOTIFICATION_SOURCE dwNotifSource,
            BOOL bIgnoreDuplicate,
            [Optional, In] WlanNotificationCallback funcCallback,
            [Optional, In] PVOID pCallbackContext,
            PVOID pReserved,
            out DWORD pdwPrevNotifSource);

        [DllImport("Wlanapi.dll", SetLastError = true)]
        public static extern DWORD WlanRegisterVirtualStationNotification(
            HANDLE hClientHandle,
            BOOL bRegister,
            PVOID pvReserved);

        // Misc

        //WlanIhvControl
        //WlanReasonCodeToString 

        #endregion

        #region Infrared Data Association

        // Infrared Data Association 
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms691773(v=vs.85).aspx

        // IrDA and Windows Sockets
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms691767(v=vs.85).aspx

        // SOCKADDR_IRDA
        // new Socket(AddressFamilies.IRDA, SocketType.STREAM, 0)

        #endregion
    }
    public static class crypt32
    {
        #region Cryptography

        [DllImport("crypt32.dll", SetLastError = true)]
        public static extern bool CryptStringToBinary(
            // STRING
            [MarshalAs(UnmanagedType.LPStr)]
            string pszString, 
            uint cchString,
            // FLAGS
            CRYPT_STRING dwFlags,
            // BUFFER
            [Out] IntPtr pbBinary, 
            ref uint pcbBinary,
            // skipped CHARS
            out uint pdwSkip, 
            out uint pdwFlags);

        [DllImport("crypt32.dll", SetLastError = true)]
        public static extern bool CryptBinaryToString(
            // BINARY
            IntPtr pbBinary,
            DWORD cbBinary,
            // FLAGS
            CRYPT_STRING dwFlags,
            [Optional] IntPtr pszString,
            ref DWORD pcchString);

        [DllImport("crypt32.dll", SetLastError = true)]
        public static extern bool CryptProtectData(
            [In] ref DATA_BLOB pDataIn,
            [MarshalAs(UnmanagedType.LPWStr)]
            string szDataDescr,
            ref DATA_BLOB pOptionalEntropy,
            PVOID pvReserved,
            IntPtr pPromptStruct,
            DWORD dwFlags,
            [Out] out DATA_BLOB pDataOut);

        [DllImport("crypt32.dll", SetLastError = true)]
        public static extern bool CryptUnprotectData(
            [In] ref DATA_BLOB pDataIn,
            [Optional] IntPtr ppszDataDescr,
            [Optional] IntPtr pOptionalEntropy,
            [Optional] IntPtr pvReserved,
            [Optional] IntPtr pPromptStruct,
            DWORD dwFlags,
            [Out] out DATA_BLOB pDataOut);

        #endregion
    }
    public static class mpr
    {
        #region NetUseAdd

        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetUseConnectionW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetUseConnection(
            SafeWindowHandle hwndOwner,
            ref NETRESOURCE lpNetResource,
            string lpPassword,
            string lpUserID,
            NetConnected dwFlags,
            string lpAccessName,
            ref DWORD lpBufferSize,
            out DWORD lpResult);

        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetAddConnection2W", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetAddConnection(
            ref NETRESOURCE lpNetResource,
            string lpPassword,
            string lpUsername,
            NetConnected dwFlags);

        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetAddConnection3W", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetAddConnection(
            SafeWindowHandle hwndOwner,
            ref NETRESOURCE lpNetResource,
            string lpPassword,
            string lpUsername,
            NetConnected dwFlags);

        #endregion

        #region NetUseDel
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetCancelConnectionW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetCancelConnection(
            string lpName,
            BOOL fForce);

        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetCancelConnection2W", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetCancelConnection(
            string lpName,
            NetConnected dwFlags,
            BOOL fForce);
        #endregion

        #region NetUseGetInfo
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetConnectionW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetConnection(
            string lpLocalName,
            string lpRemoteName,
            ref DWORD lpnLength);
        #endregion

        #region NetUseEnum
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetOpenEnumW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetOpenEnum(
            NetResourceScope dwScope,
            NetResourceType dwType,
            NetResourceType dwUsage,
            ref NETRESOURCE lpNetResource,
            out HANDLE lphEnum);

        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetEnumResourceW", CharSet = CharSet.Unicode)]
        public unsafe static extern DWORD WNetEnumResource(
            HANDLE hEnum,
            ref DWORD lpcCount,
            NETRESOURCE* lpBuffer,
            ref DWORD lpBufferSize);

        [DllImport("mpr.dll", SetLastError = true)]
        public static extern DWORD WNetCloseEnum(
            HANDLE hEnum);
        #endregion

        #region Dialog
        /// <summary>
        /// starts a general browsing dialog box for connecting to network resources.
        /// Support: RESOURCETYPE_DISK 0x00000001
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true)]
        public static extern DWORD WNetConnectionDialog(
            SafeWindowHandle hwnd,
            DWORD dwType);

        /// <summary>
        /// brings up a general browsing dialog for connecting to network resources. 
        /// The function requires a CONNECTDLGSTRUCT to establish the dialog box parameters.
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetConnectionDialog1")]
        public static extern DWORD WNetConnectionDialog(
            ref CONNECTDLGSTRUCT lpConnDlgStruct);

        /// <summary>
        /// starts a general browsing dialog box for disconnecting from network resources.
        /// Support: RESOURCETYPE_DISK 0x00000001
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true)]
        public static extern DWORD WNetDisconnectDialog(
            SafeWindowHandle hwnd,
            DWORD dwType);

        /// <summary>
        /// starts a general browsing dialog box for connecting to network resources.
        /// The function requires a CONNECTDLGSTRUCT to establish the dialog box parameters.
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetDisconnectDialog1W", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetDisconnectDialog(
            ref DISCDLGSTRUCT lpConnDlgStruct);
        #endregion

        #region Get

        /// <summary>
        /// retrieves the most recent extended error code set by a WNet function
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetLastErrorW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetLastError(
            out DWORD lpError,
            StringBuilder lpErrorBuf,
            DWORD nErrorBufSize,
            StringBuilder lpNameBuf,
            DWORD nNameBufSize);

        /// <summary>
        /// returns information about the expected performance of a connection used to access a network resource.
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "MultinetGetConnectionPerformanceW", CharSet = CharSet.Unicode)]
        public static extern DWORD MultinetGetConnectionPerformance(
            ref NETRESOURCE lpNetResource,
            out NETCONNECTINFOSTRUCT lpNetConnectInfoStruct);

        /// <summary>
        /// returns extended information about a specific network provider
        ///  whose name was returned by a previous network enumeration.
        /// </summary>
        [DllImport("Mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetResourceParentW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetResourceParent(
            ref NETRESOURCE lpNetResource,
            LPVOID lpBuffer,
            ref DWORD lpcbBuffer);

        /// <summary>
        /// parse and interpret a network path typed in by a user.
        /// </summary>
        [DllImport("Mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetResourceInformationW", CharSet = CharSet.Unicode)]
        public unsafe static extern DWORD WNetGetResourceInformation(
            ref NETRESOURCE lpNetResource,
            LPVOID lpBuffer,
            ref DWORD lpcbBuffer,
            out char* lplpSystem);

        /// <summary>
        /// returns extended information about a specific network provider 
        /// whose name was returned by a previous network enumeration.
        /// </summary>
        [DllImport("Mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetNetworkInformationW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetNetworkInformation(
            string lpProvider,
            out NETINFOSTRUCT lpNetInfoStruct);

        /// <summary>
        /// retrieves the current default user name, 
        /// or the user name used to establish a network connection.
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetUserW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetUser(
            string lpName,
            StringBuilder lpUserName,
            ref DWORD lpnLength);

        /// <summary>
        /// obtains the provider name for a specific type of network
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetProviderNameW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetProviderName(
            DWORD dwNetType,
            StringBuilder lpProviderName,
            ref DWORD lpBufferSize);

        /*
            * #define UNIVERSAL_NAME_INFO_LEVEL   0x00000001
            * IntPtr lpUniversalName
            * 
            * #define REMOTE_NAME_INFO_LEVEL      0x00000002
            * IntPtr lpUniversalName
            * IntPtr lpConnectionName
            * IntPtr lpRemainingPath
            */

        /// <summary>
        /// takes a drive-based path for a network resource
        ///  and returns an information structure 
        /// that contains a more universal form of the name.
        /// </summary>
        [DllImport("mpr.dll", SetLastError = true,
            EntryPoint = "WNetGetUniversalNameW", CharSet = CharSet.Unicode)]
        public static extern DWORD WNetGetUniversalName(
            string lpLocalPath,
            DWORD dwInfoLevel,
            LPVOID lpBuffer,
            ref DWORD lpBufferSize);
        #endregion
    }
    public static class wininet
    {
        #region Internet Options

        // Setting and Retrieving Internet Options
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa385384(v=vs.85).aspx

        // How to programmatically query and set proxy settings under Internet Explorer
        // http://support.microsoft.com/kb/226473

        // Option Flags
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa385328(v=vs.85).aspx

        [DllImport("wininet.dll", SetLastError = true,
            EntryPoint = "InternetQueryOptionW", CharSet = CharSet.Unicode)]
        public unsafe static extern bool InternetQueryOption(
            IntPtr hInternet, 
            InternetOption dwOption,
            IntPtr lpBuffer,
            uint* lpdwBufferLength);

        [DllImport("wininet.dll", SetLastError = true,
            EntryPoint = "InternetSetOptionW", CharSet = CharSet.Unicode)]
        public static extern bool InternetSetOption(
            IntPtr hInternet,
            InternetOption dwOption, 
            IntPtr lpBuffer, 
            uint lpdwBufferLength); 

        #endregion

        #region Connected State

        /* return >> connection state, out >> connection Flags */
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetConnectedState(
            out ConnectionStates lpdwFlags,
            uint dwReserved);

        [DllImport("wininet.dll", SetLastError = true,
            EntryPoint = "InternetCheckConnectionW", CharSet = CharSet.Unicode)]
        public static extern bool InternetCheckConnection(
            string lpszUrl,     // URL
            uint dwFlags,       // 0x1
            uint dwReserved);   // 0x0    

        #endregion
    }
    public static class netapi32
    {
        // Active Directory Service Interfaces
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa772170(v=vs.85).aspx

        // Mapping ADSI Interfaces to the Network Management Functions
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa370286(v=vs.85).aspx

        // Howto: (Almost) Everything In Active Directory via C#
        // http://www.codeproject.com/Articles/18102/Howto-Almost-Everything-In-Active-Directory-via-C

        #region Users

        //
        // Base
        //

        /* must fill 'bufptr->IUserInfo?' with the values needed for account */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static unsafe extern Win32Error NetUserAdd(
            string servername,
            UserLevelAdd level,
            USER_INFO* bufptr,
            out DWORD parmErr);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetUserDel(
            string servername, string username);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetUserChangePassword(
            string domainname, string username, string oldpassword, string newpassword);

        //
        // Get
        //

        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUserGetInfo(
            string servername, string username,
            UserLevelGet level,
            out USER_INFO* bufptr);

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right GROUP_USERS_INFO >> ((GROUP_USERS_INFO_[LEVEL]*) bufptr)[i] */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUserGetGroups(
            string servername, string username,
            UserGlobalGroup level,
            out GLOBAL_GROUP_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries);

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right LOCALGROUP_USERS_INFO >> ((LOCALGROUP_USERS_INFO_[LEVEL]*) bufptr)[i] */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUserGetLocalGroups(
            string servername, string username,
            UserLocalGroupGet level,
            UserLocalGroupFlags flags,
            out LOCALGROUP_USERS_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries);

        //
        // Set
        //

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUserSetInfo(
            string servername, string username, UserLevelSet level, USER_INFO* bufptr, out DWORD parmErr);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUserSetGroups(
            string servername, string username, UserGlobalGroup level, GLOBAL_GROUP_INFO* bufptr, DWORD numEntries);

        //
        // Enum
        //

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right USER_INFO >> ((USER_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUserEnum(
            string servername,
            UserLevelEnum level,
            UserFilter filter,
            out USER_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD resumeHandle);

        #endregion

        #region Local Group
        //
        // Base
        //

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupAdd(
            string servername,
            NetLocalGroupAdd level,
            LOCALGROUP_INFO* buf,
            out DWORD parmErr);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupAddMembers(
            string servername,
            string groupname,
            UserLocalGroupMember level,
            LOCALGROUP_MEMBERS_INFO* buf,
            DWORD totalentries);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetLocalGroupDel(
            string servername,
            string groupname);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupDelMembers(
            string servername,
            string groupname,
            UserLocalGroupMember level,
            LOCALGROUP_MEMBERS_INFO* buf,
            DWORD totalentries);

        //
        // Get
        //

        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupGetInfo(
            string servername,
            string groupname,
            NetLocalGroupGet level,
            out LOCALGROUP_INFO* bufptr);

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right GROUP_USERS_INFO >> ((LOCALGROUP_MEMBERS_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupGetMembers(
            string servername,
            string localgroupname,
            NetLocalGroupGetEx level,
            out LOCALGROUP_MEMBERS_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD_PTR resumehandle);

        //
        // Set
        //

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupSetInfo(
            string servername,
            string groupname,
            NetLocalGroupSet level,
            LOCALGROUP_INFO* buf,
            out DWORD parm_err);

        /* Cast (LOCALGROUP_MEMBERS_INFO_?*) Into (LOCALGROUP_MEMBERS_INFO*) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupSetMembers(
            string servername,
            string groupname,
            NetLocalGroupSetEx level,
            LOCALGROUP_MEMBERS_INFO* buf,
            DWORD totalentries);

        //
        // Enum
        //

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right LOCALGROUP_INFO >> ((LOCALGROUP_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != UIntPtr.Zero) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetLocalGroupEnum(
            string servername,
            NetLocalGroupEnum level,
            out  LOCALGROUP_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD_PTR resumehandle);
        #endregion

        #region Global Group
        //
        // Base
        //

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetGroupAdd(
            string servername,
            NetGroup level,
            GROUP_INFO* buf,
            out DWORD parmErr);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetGroupAddUser(
            string servername,
            string groupName,
            string username);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetGroupDel(
            string servername,
            string groupname);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetGroupDelUser(
            string servername,
            string groupName,
            string username);

        //
        // Get
        //

        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetGroupGetInfo(
            string servername,
            string groupname,
            NetGroup level,
            out GROUP_INFO* bufptr);

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right GROUP_USERS_INFO >> ((GROUP_USERS_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetGroupGetUsers(
            string servername,
            string groupname,
            NetGroupUsers level,
            out GROUP_USERS_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD_PTR resumeHandle);

        //
        // Set
        //

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetGroupSetInfo(
            string servername,
            string groupname,
            NetGroupEx level,
            GROUP_INFO* buf,
            out DWORD parmErr);

        /* Cast (GROUP_USERS_INFO_?*) Into (GROUP_USERS_INFO*) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetGroupSetUsers(
            string servername,
            string groupname,
            NetGroupUsers level,
            GROUP_USERS_INFO* buf,
            DWORD totalentries);

        //
        // Enum
        //

        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right GROUP_INFO >> ((GROUP_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != UIntPtr.Zero) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetGroupEnum(
            string servername,
            NetGroup level,
            out GROUP_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD_PTR resumehandle);
        #endregion

        #region Network Share
        //
        // Base
        //

        /* Checks whether or not a server is sharing a device. */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetShareCheck(
            string servername,
            string device,
            out DeviceType type);

        /* Shares a server resource. */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetShareAdd(
            string servername,
            NetShareAdd level,
            SHARE_INFO* buf,
            out DWORD parmError);

        /* Deletes a share name from a server's list of shared resources,
            which disconnects all connections to that share.  */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetShareDel(
            string servername,
            string netname,
            DWORD reserved);

        /* Deletes a share name from a server's list of shared resources,
            which disconnects all connections to that share.  */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetShareDelEx(
            string servername,
            NetShareDel level,
            SHARE_INFO* buf);

        //
        // Get
        //

        /* Retrieves information about a particular shared resource on a server. */
        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetShareGetInfo(
            string servername,
            string netname,
            NetShareGet level,
            out SHARE_INFO* buf);

        //
        // Set
        //

        /* Sets the parameters of a shared resource. */
        /* Cast (SHARE_INFO_?*) Into (SHARE_INFO*) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetShareSetInfo(
            string servername,
            string netname,
            NetShareSet level,
            SHARE_INFO* buf,
            out DWORD parmErr);

        //
        // Enum
        //

        /* Retrieves information about each shared resource on a server. */
        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right SHARE_INFO >> ((SHARE_INFO_[LEVEL]*) buf)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetShareEnum(
            string servername,
            NetShareEnum level,
            out SHARE_INFO* buf,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD resumeHandle);

        /* Retrieves information about each shared resource on a server. */
        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right CONNECTION_INFO >> ((CONNECTION_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetConnectionEnum(
            string servername,
            string qualifier,
            NetShareEnumEx level,
            out CONNECTION_INFO* bufptr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD resumeHandle);
        #endregion

        #region Network Use
        //
        // Base
        //

        /* establishes a connection between the local computer and a remote server.
            You can specify a local drive letter or a printer device to connect.
            also look at WNetAddConnection2, WNetAddConnection2 */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUseAdd(
            string uncServerName,
            NetUseAdd level,
            USE_INFO* buf,
            out DWORD parmError);

        /* ends a connection to a shared resource.
            also look at WNetCancelConnection2 */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetUseDel(
            string uncServerName,
            string useName,
            ForceCondition forceCond);

        //
        // Get
        //

        /* retrieves information about a connection to a shared resource.
            also look at WNetGetConnection */
        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUseGetInfo(
            string uncServerName,
            string useName,
            NetUseGet level,
            out USE_INFO* bufPtr);

        //
        // Enum
        //

        /* lists all current connections between the local computer and resources on remote servers.
            also look at WNetOpenEnum, WNetEnumResource */
        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right USE_INFO >> ((USE_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetUseEnum(
            string uncServerName,
            NetUseGet level,
            out USE_INFO* bufptr,
            DWORD preferedMaximumSize,
            out DWORD entriesRead,
            out DWORD totalEntries,
            ref DWORD resumeHandle);
        #endregion

        #region Network File
        //
        // Base
        //

        /* Forces a resource to close.  */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetFileClose(
            string servername,
            DWORD fileid);

        //
        // Get
        //

        /* Retrieves information about a particular opening of a server resource. */
        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetFileGetInfo(
            string servername,
            DWORD fileid,
            NetFile level,
            out FILE_INFO* buf);

        //
        // Enum
        //

        /* Returns information about some or all open files on a server, depending on the parameters specified. */
        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right FILE_INFO >> ((FILE_INFO_[LEVEL]*) bufptr)[i] */
        /* you can use do .. while (resumehandle != UIntPtr.Zero) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetFileEnum(
            string servername,
            string basepath,
            string username,
            NetFile level,
            out FILE_INFO* bufPtr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD_PTR resumeHandle);
        #endregion

        #region Network Session
        //
        // Base
        //

        /* Ends a network session between a server and a workstation.  */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetSessionDel(
            string servername,
            string uncClientName,
            string username);

        //
        // Get
        //

        /* Retrieves information about a session established between a particular server and workstation. */
        /* handle must be free later by call NetApiBufferFree */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern unsafe Win32Error NetSessionGetInfo(
            string servername,
            string uncClientName,
            string username,
            DWORD fileid,
            NetSessionAdd level,
            out SESSION_INFO* buf);


        //
        // Enum
        //

        /* Provides information about sessions established on a server. */
        /* handle must be free later by call NetApiBufferFree */
        /* convert it later to right SESSION_INFO >> ((SESSION_INFO_[LEVEL]*) bufPtr)[i] */
        /* you can use do .. while (resumehandle != 0) */
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error NetSessionEnum(
            string servername,
            string uncClientName,
            string username,
            NetSessionEnum level,
            out SESSION_INFO* bufPtr,
            DWORD prefmaxlen,
            out DWORD entriesread,
            out DWORD totalentries,
            ref DWORD_PTR resume_handle);
        #endregion

        #region Api Buffer
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetApiBufferAllocate(
            DWORD byteCount,
            out LPVOID buffer);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetApiBufferReallocate(
            LPVOID oldBuffer,
            DWORD newByteCount,
            out LPVOID newBuffer);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetApiBufferFree(
            LPVOID buffer);

        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error NetApiBufferSize(
            LPVOID buffer,
            out DWORD byteCount);
        #endregion
    }
    public static class Iphlpapi
    {
        // Wrapper

        #region Wmi
        public static bool WmiDisable(string netConnectionID)
        {
            var col = new ManagementObjectSearcher("select * from Win32_NetworkAdapterSetting").Get();
            foreach (var item in col)
            {
                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394216(v=vs.85).aspx
                var win32NetworkAdapter = new ManagementObject(
                    item["Element"].ToString());

                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx
                var win32NetworkAdapterConfiguration = new ManagementObject(
                    item["Setting"].ToString());

                var NetConnectionID = win32NetworkAdapter["NetConnectionID"];
                if (NetConnectionID != null && (string)NetConnectionID == netConnectionID)
                {
                    win32NetworkAdapter.InvokeMethod("Disable", null);
                    return true;
                }
            }
            return false;
        }
        public static bool WmiEnable(string netConnectionID)
        {
            var col = new ManagementObjectSearcher("select * from Win32_NetworkAdapterSetting").Get();
            foreach (var item in col)
            {
                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394216(v=vs.85).aspx
                var win32NetworkAdapter = new ManagementObject(
                    item["Element"].ToString());

                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx
                var win32NetworkAdapterConfiguration = new ManagementObject(
                    item["Setting"].ToString());

                var NetConnectionID = win32NetworkAdapter["NetConnectionID"];
                if (NetConnectionID != null && (string)NetConnectionID == netConnectionID)
                {
                    win32NetworkAdapter.InvokeMethod("Enable", null);
                    return true;
                }
            }
            return false;
        }
        public static bool WmiSetStatic(string netConnectionID, string ipAddress, string subnetMask)
        {
            var col = new ManagementObjectSearcher("select * from Win32_NetworkAdapterSetting").Get();
            foreach (var item in col)
            {
                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394216(v=vs.85).aspx
                var win32NetworkAdapter = new ManagementObject(
                    item["Element"].ToString());

                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx
                var win32NetworkAdapterConfiguration = new ManagementObject(
                    item["Setting"].ToString());

                var NetConnectionID = win32NetworkAdapter["NetConnectionID"];
                if (NetConnectionID != null && (string)NetConnectionID == netConnectionID)
                {
                    var res = (UINT32)win32NetworkAdapterConfiguration.InvokeMethod("EnableStatic",
                        new object[] 
                            { 
                                new string[1]{ipAddress}, 
                                new string[1]{subnetMask} });
                    return res == 0 || res == 1;
                }
            }

            return false;
        }
        public static bool WmiSetDhcp(string netConnectionID)
        {
            var col = new ManagementObjectSearcher("select * from Win32_NetworkAdapterSetting").Get();
            foreach (var item in col)
            {
                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394216(v=vs.85).aspx
                var win32NetworkAdapter = new ManagementObject(
                    item["Element"].ToString());

                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx
                var win32NetworkAdapterConfiguration = new ManagementObject(
                    item["Setting"].ToString());

                var NetConnectionID = win32NetworkAdapter["NetConnectionID"];
                if (NetConnectionID != null && (string)NetConnectionID == netConnectionID)
                {
                    var res = (UINT32)win32NetworkAdapterConfiguration.InvokeMethod("EnableDHCP", null);
                    return res == 0 || res == 1;
                }
            }

            return false;
        }
        public static bool WmiRenewDhcp(string netConnectionID)
        {
            var col = new ManagementObjectSearcher("select * from Win32_NetworkAdapterSetting").Get();
            foreach (var item in col)
            {
                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394216(v=vs.85).aspx
                var win32NetworkAdapter = new ManagementObject(
                    item["Element"].ToString());

                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx
                var win32NetworkAdapterConfiguration = new ManagementObject(
                    item["Setting"].ToString());

                var NetConnectionID = win32NetworkAdapter["NetConnectionID"];
                if (NetConnectionID != null && (string)NetConnectionID == netConnectionID)
                {
                    var res = (UINT32)win32NetworkAdapterConfiguration.InvokeMethod("RenewDHCPLease", null);
                    return res == 0 || res == 1;
                }
            }

            return false;
        }
        public static bool WmiReleaseDhcp(string netConnectionID)
        {
            var col = new ManagementObjectSearcher("select * from Win32_NetworkAdapterSetting").Get();
            foreach (var item in col)
            {
                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394216(v=vs.85).aspx
                var win32NetworkAdapter = new ManagementObject(
                    item["Element"].ToString());

                // http://msdn.microsoft.com/en-us/library/windows/desktop/aa394217(v=vs.85).aspx
                var win32NetworkAdapterConfiguration = new ManagementObject(
                    item["Setting"].ToString());

                var NetConnectionID = win32NetworkAdapter["NetConnectionID"];
                if (NetConnectionID != null && (string)NetConnectionID == netConnectionID)
                {
                    var res = (UINT32)win32NetworkAdapterConfiguration.InvokeMethod("ReleaseDHCPLease", null);
                    return res == 0 || res == 1;
                }
            }

            return false;
        }
        #endregion

        // Info

        #region Statistics

        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "GetUdpStatisticsEx")]
        public static extern uint GetUdpStatistics(
            out MIB_UDPSTATS pStats,
            uint dwFamily); // IPv4 [0x2], IPv6 [0xa]

        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "GetTcpStatisticsEx")]
        public static extern uint GetTcpStatistics(
            out MIB_TCPSTATS pStats,
            uint dwFamily); // IPv4 [0x2], IPv6 [0xa]

        // leave this shit here
        // ot will not make my life more better
        // so ignore this shiiti funtion

        // GetPerTcpConnectionEStats 
        // GetPerTcp6ConnectionEStats

        // SetPerTcpConnectionEStats
        // SetPerTcp6ConnectionEStats 

        #endregion

        #region Configuration
        [DllImport("iphlpdll", SetLastError = true)]
        public static extern DWORD GetNetworkParams(
            ref FIXED_INFO pFixedInfo,
            ref ULONG pOutBufLen); 
        #endregion

        #region Active Connection
        // --- Connection Info [= With Pid =] ---

        /* retrieves the IPv4 User Datagram Protocol (UDP) listener table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pUdpTable->First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern unsafe uint GetUdpTable(
            MIB_UDPTABLE* pUdpTable,
            ref uint pdwSize,
            bool bOrder);

        /* retrieves the IPv4 User Datagram Protocol (UDP) listener table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pUdpTable->First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern unsafe uint GetUdp6Table(
            MIB_UDP6TABLE* udp6Table,
            ref uint sizePointer,
            bool bOrder);

        /* retrieves a table that contains a list of UDP endpoints available to the application. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pTcpTable->???.First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern unsafe uint GetExtendedUdpTable(
            UDP_TABLE_INFO* pTcpTable,
            ref uint pdwSize,
            bool bOrder,
            uint ulAf, // IPv4 [0x2], IPv6 [0xa]
            UDP_TABLE_CLASS tableClass,
            uint reserved);

        /* retrieves the IPv4 TCP connection table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pTcpTable->First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern unsafe uint GetTcpTable(
            MIB_TCPTABLE* pTcpTable,
            ref uint pdwSize,
            bool bOrder);

        /* retrieves the IPv4 TCP connection table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&tcpTable->First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "GetTcpTable2")]
        public static extern unsafe uint GetTcpTable(
            MIB_TCPTABLE2* tcpTable,
            ref uint pdwSize,
            bool bOrder);

        /* retrieves the TCP connection table for IPv6. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&tcpTable->First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern unsafe uint GetTcp6Table(
            MIB_TCP6TABLE* tcpTable,
            ref uint sizePointer,
            bool bOrder);

        /* retrieves the TCP connection table for IPv6. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&tcpTable->First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "GetTcp6Table2")]
        public static extern unsafe uint GetTcp6Table(
            MIB_TCP6TABLE2* tcpTable,
            ref uint pdwSize,
            bool bOrder);

        /* retrieves a table that contains a list of TCP endpoints available to the application. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pTcpTable->???.First)[i] to enum */
        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern unsafe uint GetExtendedTcpTable(
            TCP_TABLE_INFO* pTcpTable,
            ref uint pdwSize,
            bool bOrder,
            uint ulAf, // IPv4 [0x2], IPv6 [0xa]
            TCP_TABLE_CLASS tableClass,
            uint reserved);

        // --- Owner Module Info ---
        // can be ignored ...
        // i can enum all process with
        // lot of function and see if one match
        // out pid ..........
        // and get process path bymyself !!!!

        // GetOwnerModuleFromTcpEntry
        // GetOwnerModuleFromTcp6Entry
        // GetOwnerModuleFromUdpEntry 
        // GetOwnerModuleFromUdp6Entry 

        // --- Dummy ---//
        // look at the Remarks ::
        // Currently, the only state to which a TCP connection can be set is MIB_TCP_STATE_DELETE_TCB.
        // so why MS made it at all ?????????

        // SetTcpEntry  
        #endregion

        #region Physical address
        /* sends an Address Resolution Protocol (ARP) request to obtain the physical address
            that corresponds to the specified destination IPv4 address. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD SendARP(
            in_addr destIP,   // real Ip (192, 256, 12 , 5)
            in_addr srcIP,    // null Ip (0  , 0  , 0  , 0)
            byte* pMacAddr,             // array :: must have at least two ULONG elements { sizeof(uint) * 2 }
            ref uint phyAddrLen);       // [In] array length :: [Out] mac Length

        /* retrieves the IPv4 to physical address mapping table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pIpNetTable->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern unsafe DWORD GetIpNetTable(
            MIB_IPNETTABLE* pIpNetTable,
            ref ULONG pdwSize,
            BOOL bOrder);

        /* creates an Address Resolution Protocol (ARP) entry in the ARP table on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD CreateIpNetEntry(
            ref MIB_IPNETROW pArpEntry);

        /* creates a Proxy Address Resolution Protocol (PARP) entry on the local computer for the specified IPv4 address. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD CreateProxyArpEntry(
            in_addr dwAddress,
            in_addr dwMask,
            DWORD dwIfIndex);

        /* deletes an ARP entry from the ARP table on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD DeleteIpNetEntry(
            ref MIB_IPNETROW pArpEntry);

        /* deletes the PARP entry on the local computer specified by the dwAddress and dwIfIndex parameters. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD DeleteProxyArpEntry(
            in_addr dwAddress,
            in_addr dwMask,
            DWORD dwIfIndex);

        /* modifies an existing ARP entry in the ARP table on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD SetIpNetEntry(
            ref MIB_IPNETROW pArpEntry);

        /* deletes all ARP entries for the specified interface from the ARP table on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD FlushIpNetTable(
            DWORD dwIfIndex);
        #endregion

        // Adapter

        #region Adapter
        /* obtains the index of an adapter, given its name. */
        [DllImport("Iphlpapi", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern DWORD GetAdapterIndex(
            string adapterName,
            ref ULONG ifIndex);

        /* retrieves adapter information for the local computer. */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern unsafe DWORD GetAdaptersInfo(
            IP_ADAPTER_INFO* pAdapterInfo,
            ref ULONG pOutBufLen);

        /* retrieves information about the adapter corresponding to the specified interface. */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern unsafe DWORD GetPerAdapterInfo(
            ULONG ifIndex,
            IP_PER_ADAPTER_INFO* pAdapterInfo,
            ref ULONG pOutBufLen);

        /* retrieves the addresses associated with the adapters on the local computer. */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern unsafe ULONG GetAdaptersAddresses(
            AddressFamilyInt family,
            AdaptersFlags flags,
            PVOID reserved,
            IP_ADAPTER_ADDRESSES* adapterAddresses,
            ref ULONG sizePointer);

        /* retrieves information about the unidirectional adapters installed on the local computer. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pIPIfInfo->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern unsafe DWORD GetUniDirectionalAdapterInfo(
            IP_UNIDIRECTIONAL_ADAPTER_ADDRESS* pIPIfInfo,
            ref ULONG dwOutBufLen); 
        #endregion

        #region Interface
        /* retrieves the number of interfaces on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetNumberOfInterfaces(
            out DWORD pdwNumIf);

        /* obtains the list of the network interface adapters with IPv4 enabled on the local system. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pIfTable->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetInterfaceInfo(
            IP_INTERFACE_INFO* pIfTable,
            ref ULONG dwOutBufLen);

        // --------------------------------------

        /* retrieves the MIB-II interface table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pIfTable->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetIfTable(
            MIB_IFTABLE* pIfTable,
            ref ULONG pdwSize,
            BOOL bOrder);

        /* retrieves information for the specified interface on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetIfEntry(
            ref MIB_IFROW pIfRow);

        /* sets the administrative status of an interface. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD SetIfEntry(
            ref MIB_IFROW pIfRow);

        // --------------------------------------

        /* retrieves the IP interface entries on the local computer. */
        /* use (&Table->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetIpInterfaceTable(
            AddressFamilies family,
            out MIB_IPINTERFACE_TABLE* table);

        /* retrieves IP information for the specified interface on the local computer. */
        /* use MIB_IPINTERFACE_ROW.GetInterface(index, family) before. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetIpInterfaceEntry(
            ref MIB_IPINTERFACE_ROW row); 
        #endregion

        // IP

        #region IP Address

        /* adds the specified IPv4 address to the specified adapter. */
        /* index can be take from GetAdaptersInfo->Output[i]->Index */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD AddIPAddress(
            in_addr address,
            in_addr ipMask,
            DWORD ifIndex,
            out ULONG nteContext,
            out ULONG nteInstance);

        /* deletes an IP address previously added using AddIPAddress. */
        /* nteContext can be take from GetAdaptersInfo->Output[i]->Context */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD DeleteIPAddress(
            ULONG nteContext);

        /* releases an IPv4 address previously obtained through
            the Dynamic Host Configuration Protocol (DHCP). */
        /* use GetInterfaceInfo() to obaint IP_ADAPTER_INDEX_MAP table*/
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD IpReleaseAddress(
            ref IP_ADAPTER_INDEX_MAP adapterInfo);

        /* renews a lease on an IPv4 address previously obtained through 
            Dynamic Host Configuration Protocol (DHCP). */
        /* use GetInterfaceInfo() to obaint IP_ADAPTER_INDEX_MAP table */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD IpRenewAddress(
            ref IP_ADAPTER_INDEX_MAP adapterInfo);

        // --------------------------------------

        /* retrieves the interface–to–IPv4 address mapping table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pIpAddrTable->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetIpAddrTable(
            MIB_IPADDRTABLE* pIpAddrTable,
            ref ULONG pdwSize,
            BOOL bOrder);

        // --------------------------------------

        /* retrieves information for an existing multicast IP address entry
            on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetMulticastIpAddressEntry(
            ref MIB_MULTICASTIPADDRESS_ROW row);

        /* retrieves the multicast IP address table on the local computer. */
        /* use (&Table->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetMulticastIpAddressTable(
            AddressFamilies family,
            out MIB_MULTICASTIPADDRESS_TABLE* table);

        // --------------------------------------

        /* deletes an existing anycast IP address entry on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD DeleteAnycastIpAddressEntry(
            ref MIB_ANYCASTIPADDRESS_ROW row);

        /* adds a new anycast IP address entry on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD CreateAnycastIpAddressEntry(
            ref MIB_ANYCASTIPADDRESS_ROW row);

        /* retrieves information for an existing anycast IP address entry
            on the local computer.  */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetAnycastIpAddressEntry(
            ref MIB_ANYCASTIPADDRESS_ROW row);

        /* retrieves the anycast IP address table on the local computer. */
        /* use (&Table->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetAnycastIpAddressTable(
            AddressFamilies family,
            out MIB_ANYCASTIPADDRESS_TABLE* table);

        // --------------------------------------

        /* a MIB_UNICASTIPADDRESS_ROW structure with default values
            for a unicast IP address entry on the local computer.  */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern void InitializeUnicastIpAddressEntry(
            out MIB_UNICASTIPADDRESS_ROW row);

        /* adds a new unicast IP address entry on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD CreateUnicastIpAddressEntry(
            ref MIB_UNICASTIPADDRESS_ROW row);

        /* adds a new unicast IP address entry on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD SetUnicastIpAddressEntry(
            ref MIB_UNICASTIPADDRESS_ROW row);

        /* deletes an existing unicast IP address entry on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD DeleteUnicastIpAddressEntry(
            ref MIB_UNICASTIPADDRESS_ROW row);

        /* retrieves information for an existing unicast IP address entry on
            the local computer.   */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetUnicastIpAddressEntry(
            ref MIB_UNICASTIPADDRESS_ROW row);

        /* retrieves the unicast IP address table on the local computer. */
        /* use (&Table->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetUnicastIpAddressTable(
            AddressFamilies family,
            out MIB_UNICASTIPADDRESS_TABLE* table);

        #endregion

        #region IP Route

        /* retrieves the IPv4 routing table. */
        /* first call needed to obtain Size, second call run after allocate the size */
        /* use (&pIpForwardTable->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetIpForwardTable(
            MIB_IPFORWARDTABLE* pIpForwardTable,
            ref ULONG pdwSize,
            BOOL bOrder);

        #endregion 

        #region IP Path

        /* flushes the IP path table on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD FlushIpPathTable(
            AddressFamilies family);

        /* retrieves the IP path table on the local computer. */
        /* use (&Table->First)[i] to enum */
        [DllImport("Iphlpapi", SetLastError = true)]
        public unsafe static extern DWORD GetIpPathTable(
            AddressFamilies family,
            out MIB_IPPATH_TABLE* table);

        /* retrieves information for a IP path entry on the local computer. */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern DWORD GetIpPathEntry(
            ref MIB_IPPATH_ROW family);

        #endregion

        // Notification

        #region Notification

        /* Windows 2000 + */

        //
        // Blocking Mode
        //

        /*
            while (MonitorEnabled)
            {
                var dwRet = Iphlpapi.NotifyAddrChange(IntPtr.Zero, IntPtr.Zero);
                if (dwRet != 0) 
                    continue;

                // some job here
            }
         */

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint NotifyAddrChange(
            IntPtr res1, IntPtr res2);

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint NotifyRouteChange(
            IntPtr res1, IntPtr res2);

        //
        // Non Blocking Mode
        //

        /*
            IntPtr handle;
            var overlapped = OVERLAPPED.Initialize();

            while (MonitorEnabled)
            {
                if (Iphlpapi.NotifyAddrChange(out handle, ref overlapped) == 997 ) // ERROR_IO_PENDING
                {
                    overlapped.Event.Wait(WaitForSingleObjectFlags.Infinite);
                    // some job here
                }

                overlapped.Event.Reset();
            }

            overlapped.Event.Release();   
         */

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint NotifyAddrChange(
            out IntPtr handle,
            ref OVERLAPPED overlapped);

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint NotifyRouteChange(
            out IntPtr handle,
            ref OVERLAPPED overlapped);

        /* cancels notification of IPv4 address and route changes 
            previously requested with successful calls 
            to the NotifyAddrChange or NotifyRouteChange functions */

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern bool CancelIPChangeNotify(
            ref OVERLAPPED overlapped);

        /* Windows Vista */

        /*
            var notificationHandle = IntPtr.Zero;
            Iphlpapi.NotifyIpInterfaceChange(
                AddressFamilies.INET,
                ***callbackFunction***, IntPtr.Zero,
                0x1, ref notificationHandle);
         */

        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "NotifyRouteChange2")]
        public static extern uint NotifyRouteChange(
            AddressFamilies family,     // UNSPEC, INET, INET6
            IpforwardChangeCallback callback,
            IntPtr callbackParams,
            byte initialNotification,   // callback should be invoked immediately ? False [0] :: True [1]
            ref IntPtr notificationHandle);

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint NotifyIpInterfaceChange(
            AddressFamilies family,     // UNSPEC, INET, INET6
            InterfaceChangeCallback callback,
            IntPtr callbackParams,
            byte initialNotification,   // callback should be invoked immediately ? False [0] :: True [1]
            ref IntPtr notificationHandle);

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint NotifyUnicastIpAddressChange(
            AddressFamilies family,     // UNSPEC, INET, INET6
            UnicastIpaddressChangeCallback callback,
            IntPtr callbackParams,
            byte initialNotification,   // callback should be invoked immediately ? False [0] :: True [1]
            ref IntPtr notificationHandle);

        /* deregisters for change notifications for IP interface changes, 
            IP address changes, IP route changes, Teredo port changes,
            and when the unicast IP address table is stable and can be retrieved. */
        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "CancelMibChangeNotify2")]
        public static extern uint CancelMibChangeNotify(
            HANDLE notificationHandle);

        #endregion

        // Connection

        #region Ping

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern IntPtr IcmpCreateFile();

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern IntPtr Icmp6CreateFile();

        // -----------

        // replyBuffer can BE NULL
        // return is number of struct filled
        // by the function

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public unsafe static extern DWORD IcmpSendEcho(
            HANDLE icmpHandle,
            // ------------
            in_addr destinationAddress,
            // ------------
            LPVOID requestData,
            WORD requestSize,
            [Optional] IP_OPTION_INFORMATION* requestOptions,
            // ------------
            [Out] ICMP_ECHO_REPLY* replyBuffer,
            DWORD replySize,
            // ------------
            DWORD timeout);

        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "IcmpSendEcho2")]
        public unsafe static extern DWORD IcmpSendEcho(
            HANDLE icmpHandle,
            // ------------
            [Optional]SafeEventHandle eventHandle,
            [Optional]IntPtr apcRoutine,
            [Optional]IntPtr apcContext,
            // ------------
            in_addr destinationAddress,
            // ------------
            LPVOID requestData,
            WORD requestSize,
            [Optional]IP_OPTION_INFORMATION* requestOptions,
            // ------------
            [Out]ICMP_ECHO_REPLY* replyBuffer,
            DWORD replySize,
            // ------------
            DWORD timeout);

        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "IcmpSendEcho2Ex")]
        public unsafe static extern DWORD IcmpSendEcho(
            HANDLE icmpHandle,
            // ------------
            [Optional]SafeEventHandle eventHandle,
            [Optional]IntPtr apcRoutine,
            [Optional]IntPtr apcContext,
            // ------------
            in_addr sourceAddress,
            in_addr destinationAddress,
            // ------------
            LPVOID requestData,
            WORD requestSize,
            [Optional]IP_OPTION_INFORMATION* requestOptions,
            // ------------
            [Out]ICMP_ECHO_REPLY* replyBuffer,
            DWORD replySize,
            // ------------
            DWORD timeout);

        [DllImport("Iphlpapi.dll", SetLastError = true,
            EntryPoint = "Icmp6SendEcho2")]
        public unsafe static extern DWORD Icmp6SendEcho(
            HANDLE icmpHandle,
            // ------------
            [Optional]SafeEventHandle eventHandle,
            [Optional]IntPtr apcRoutine,
            [Optional]IntPtr apcContext,
            // ------------
            sockaddr_in6* sourceAddress,
            sockaddr_in6* destinationAddress,
            // ------------
            LPVOID requestData,
            WORD requestSize,
            [Optional]IP_OPTION_INFORMATION* requestOptions,
            // ------------
            [Out]ICMPV6_ECHO_REPLY* replyBuffer,
            DWORD replySize,
            // ------------
            DWORD timeout);

        // -----------

        // parses the reply buffer provided
        // and returns the number of ICMP echo request
        // responses found.

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public unsafe static extern DWORD IcmpParseReplies(
            ICMP_ECHO_REPLY* replyBuffer,
            DWORD replySize);

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public unsafe static extern DWORD Icmp6ParseReplies(
            ICMPV6_ECHO_REPLY* replyBuffer,
            DWORD replySize);

        // -----------

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern bool IcmpCloseHandle(
            HANDLE icmpHandle);

        // -----------

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint GetIpStatistics(
            out MIB_IPSTATS pStats);

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint GetIpStatisticsEx(
            out MIB_IPSTATS pStats,
            AddressFamilyInt dwFamily);

        // -----------

        [DllImport("Iphlpapi.dll", SetLastError = true)]
        public static extern uint SetIpTTL(
            UINT nTTL);

        #endregion

        // Misc

        #region Memory
        /* frees the buffer allocated by the functions that return tables of 
            network interfaces, addresses, and routes (GetIfTable2 and GetAnycastIpAddressTable, for example). */
        [DllImport("Iphlpapi", SetLastError = true)]
        public static extern void FreeMibTable(PVOID memory);
        #endregion
    }
    public static class psapi
    {
        #region Process
        /// <summary>
        /// Retrieves the name of the executable file for the specified process.
        /// </summary>
        [DllImport("psapi.dll", SetLastError = true,
            EntryPoint = "GetProcessImageFileNameW", CharSet = CharSet.Unicode)]
        public static extern uint GetProcessImageFileName(
            SafeProcessHandle hProcess,
            StringBuilder lpImageFileName,
            DWORD nSize);

        /// <summary>
        /// Retrieves the process identifier for each process object in the system.
        /// </summary>
        /// <param name="pProcessIdsprocessIds">Uint32 array</param>
        /// <param name="arraySizeBytes">Uint32 array Length * 4</param>
        /// <param name="bytesCopied">out result</param>
        /// <returns></returns>
        [DllImport("psapi.dll", SetLastError = true)]
        public unsafe static extern bool EnumProcesses(
            DWORD* pProcessIdsprocessIds,
            DWORD arraySizeBytes,
            out DWORD bytesCopied
            );
        #endregion

        #region Module
        /// <summary>
        /// Retrieves a handle for each module in the specified process.
        /// </summary>
        /// <param name="hProcess">handle from OpenProcess</param>
        /// <param name="lphModule">IntPtr array</param>
        /// <param name="cb">IntPtr array Length * IntPtr.Size</param>
        /// <param name="lpcbNeeded">reference to result</param>
        /// <returns></returns>
        [DllImport("psapi.dll", SetLastError = true)]
        public unsafe static extern bool EnumProcessModules(
            SafeProcessHandle hProcess,
            HMODULE *lphModule,
            DWORD cb,
            out DWORD lpcbNeeded);

        /// <summary>
        /// Retrieves a handle for each module in the specified process,
        /// that meets the specified filter criteria.
        /// </summary>
        /// <param name="hProcess">handle from OpenProcess</param>
        /// <param name="lphModule">IntPtr array</param>
        /// <param name="cb">IntPtr array Length * IntPtr.Size</param>
        /// <param name="lpcbNeeded">reference to result</param>
        /// <param name="dwFilterFlag">The size of the lpFilename buffer, in characters.</param>
        /// <returns></returns>
        [DllImport("psapi.dll", SetLastError = true)]
        public unsafe static extern bool EnumProcessModulesEx(
            SafeProcessHandle hProcess,
            HMODULE* lphModule,
            DWORD cb,
            out DWORD lpcbNeeded,
            LIST_MODULES dwFilterFlag);

        /// <summary>
        /// Retrieves the fully qualified path for the file containing the specified module.
        /// </summary>
        /// <param name="hProcess">handle from OpenProcess</param>
        /// <param name="hModule">IntPtr.Zero</param>
        /// <param name="lpBaseName">A handle to the module. If this parameter is NULL, GetModuleFileNameEx returns the path of the executable file of the process specified in hProcess</param>
        /// <param name="nSize">The size of the lpFilename buffer, in characters.</param>
        /// <returns></returns>
        [DllImport("psapi.dll", SetLastError = true,
            EntryPoint = "GetModuleFileNameExW", CharSet = CharSet.Unicode)]
        public static extern uint GetModuleFileNameEx(
            SafeProcessHandle hProcess,
            IntPtr hModule,
            StringBuilder lpBaseName,
            uint nSize);

        /// <summary>
        /// Retrieves information about the specified module in the MODULEINFO structure.
        /// </summary>
        /// <param name="hProcess">handle from OpenProcess</param>
        /// <param name="hModule">handle from EnumProcessModules[Ex]</param>
        /// <param name="lpmodinfo">reference to LPMODULEINFO Stracture</param>
        /// <param name="cb">The size of the MODULEINFO structure</param>
        /// <returns></returns>
        [DllImport("psdll.dll", SetLastError = true)]
        public static extern uint GetModuleInformation(
            SafeProcessHandle hProcess,
            HMODULE hModule,
            ref LPMODULEINFO lpmodinfo,
            DWORD cb);
        #endregion

        #region Device Driver
        /// <summary>
        /// Retrieves the load address for each device driver in the system.
        /// </summary>
        /// <param name="lpImageBase">IntPtr array</param>
        /// <param name="cb">IntPtr array Length * IntPtr.Size</param>
        /// <param name="lpcbNeeded">reference to result</param>
        /// <returns></returns>
        [DllImport("psapi.dll", SetLastError = true)]
        public unsafe static extern BOOL EnumDeviceDrivers(
            LPVOID* lpImageBase,
            DWORD cb,
            out DWORD lpcbNeeded);

        /// <summary>
        /// Retrieves the base name of the specified device driver.
        /// </summary>
        /// <param name="imageBase">Handle from EnumProcessModules</param>
        /// <param name="lpBaseName">StringBuilder</param>
        /// <param name="nSize">StringBuilder Size</param>
        /// <returns></returns>
        [DllImport("psapi.dll", SetLastError = true,
            EntryPoint = "GetDeviceDriverBaseNameW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetDeviceDriverBaseName(
            LPVOID imageBase,
            StringBuilder lpBaseName,
            DWORD nSize);

        /// <summary>
        /// Retrieves the path available for the specified device driver.
        /// </summary>
        /// <param name="imageBase">Handle from EnumProcessModules</param>
        /// <param name="lpFilename">StringBuilder</param>
        /// <param name="nSize">StringBuilder Size</param>
        /// <returns></returns>
        [DllImport("psapi.dll", EntryPoint = "GetDeviceDriverFileNameW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern DWORD GetDeviceDriverFileName(
            LPVOID imageBase,
            StringBuilder lpFilename,
            DWORD nSize);
        #endregion
    }
    public static class imagehlp
    {
        #region Image Access

        [DllImport("ImageHlp.dll", SetLastError = true)]
        public static extern bool MapAndLoad(
            string imageName, 
            string dllPath,
            out LOADED_IMAGE loadedImage, 
            bool dotDll, 
            bool readOnly);

        [DllImport("ImageHlp.dll", SetLastError = true)]
        public static extern bool UnMapAndLoad(
            ref LOADED_IMAGE loadedImage);

        #endregion
    }
    public static class ntdll
    {
        #region Object

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwQueryObject")]
        public unsafe static extern NtStatus NtQueryObject(
            IntPtr objectHandle, 
            OBJECT_INFORMATION_CLASS objectInformationClass,
            OBJECT_INFORMATION* objectInformation,
            uint length, 
            out uint resultLength);

        #endregion

        #region Memory Sections

        // use File Mapping [Interprocess Communications]
        // instead ......................................

        // Managing Memory Sections 
        // http://msdn.microsoft.com/en-us/library/windows/hardware/ff554392(v=vs.85).aspx

        // ZwOpenSection
        // ZwCreateSection
        // ZwClose

        // ZwMapViewOfSection
        // ZwUnmapViewOfSection

        #endregion

        #region System Information

        /*
            unsafe
            {
                NtStatus status;
                uint returnLength;
                var infoClass = System_Information_Class.SystemProcessInformation;
                var processInformation = system_Information.CreateHandle(infoClass, out returnLength);

                status = ntdll.NtQuerySystemInformation(
                    infoClass,
                    (IntPtr)processInformation,
                    returnLength,
                    out returnLength);

                if (status == NtStatus.UNSUCCESSFUL ||
                    status == NtStatus.NOT_IMPLEMENtED ||
                    status == NtStatus.INVALID_INFO_CLASS)
                {
                    system_Information.FreeHandle(processInformation);
                    throw new System.ComponentModel.Win32Exception(
                        Marshal.GetLastWin32Error());
                }

                if (status == NtStatus.INFO_LENGTH_MISMATCH ||
                    status == NtStatus.BUFFER_TOO_SMALL ||
                    status == NtStatus.BUFFER_OVERFLOW)
                {
                    do
                    {
                        system_Information.FreeHandle(processInformation);
                        processInformation = system_Information.CreateHandle(returnLength);
                        status = ntdll.NtQuerySystemInformation(
                            infoClass,
                            (IntPtr)processInformation,
                            returnLength,
                            out returnLength);
                    } while (
                        status == NtStatus.INFO_LENGTH_MISMATCH ||
                        status == NtStatus.BUFFER_TOO_SMALL ||
                        status == NtStatus.BUFFER_OVERFLOW);
                }

                if (status == NtStatus.SUCCESS)
                {
                    var systemInformation = &processInformation->SystemProcessInformation;

                    while (true)
                    {
                        Console.WriteLine(
                            "Process Name {0}",
                            systemInformation->ProcessName);

                        //for (var i = 0; i < systemInformation->NumberOfThreads; i++)
                        //{
                        //    var thread = (&systemInformation->Threads)[i];
                        //    Console.WriteLine("Thread [{0}] State {1}", i, thread.State);
                        //}

                        if ((int)systemInformation->NextEntryOffset > 0)
                        {
                            systemInformation = (SYSTEM_PROCESS_INFORMATION*)
                                ((uint)systemInformation + systemInformation->NextEntryOffset);
                            continue;
                        }
                        
                        // no more data
                        break;
                    }
                }

                // free the garbage
                system_Information.FreeHandle(processInformation);
            }
         */

        /*
             to get access to Array List ... use this sample.
             [&tokenInformation->TokenPrivileges]
             without the >> & the result will be bad 
         
             var tokenPrivileges = &tokenInformation->TokenPrivileges;
             for (var i = 0; i < tokenPrivileges->PrivilegeCount; i++)
             {
                  var attrib = (&tokenPrivileges->First)[i];
                  luidList.Add(attrib.Luid.ToString(), attrib.Attributes);
             }
         */

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwQuerySystemInformation")]
        public static extern NtStatus NtQuerySystemInformation(
            System_Information_Class systemInformationClass,
            IntPtr systemInformation, 
            uint systemInformationLength,
            out uint returnLength);

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwSetSystemInformation")]
        public static extern NtStatus NtSetSystemInformation(
            System_Information_Class systemInformationClass,
            IntPtr systemInformation,
            uint systemInformationLength);

        #endregion

        #region Process Information

        /*
            unsafe
            {
                NtStatus status;
                uint returnLength;
                var hProcess = SafeProcessHandle.CurrentProcess;
                var infoClass = process_information_class.ProcessImageFileName;
                var processInformation = process_information.CreateHandle(infoClass, out returnLength);

                status = ntdll.NtQueryInformationProcess(
                    hProcess, infoClass,
                    (IntPtr)processInformation,
                    returnLength,
                    out returnLength);

                if (status == NtStatus.UNSUCCESSFUL ||
                    status == NtStatus.NOT_IMPLEMENtED ||
                    status == NtStatus.INVALID_INFO_CLASS)
                {
                    process_information.FreeHandle(processInformation);
                    throw new System.ComponentModel.Win32Exception(
                        Marshal.GetLastWin32Error());
                }

                if (status == NtStatus.INFO_LENGTH_MISMATCH ||
                    status == NtStatus.BUFFER_TOO_SMALL ||
                    status == NtStatus.BUFFER_OVERFLOW)
                {
                    do
                    {
                        process_information.FreeHandle(processInformation);
                        processInformation = process_information.CreateHandle(returnLength);

                        status = ntdll.NtQueryInformationProcess(
                            hProcess, infoClass,
                            (IntPtr)processInformation,
                            returnLength,
                            out returnLength);
                    } while (
                        status == NtStatus.INFO_LENGTH_MISMATCH ||
                        status == NtStatus.BUFFER_TOO_SMALL ||
                        status == NtStatus.BUFFER_OVERFLOW);
                }

                if (status == NtStatus.SUCCESS)
                {
                    Console.WriteLine();
                    Console.WriteLine(processInformation->ProcessImageFileName);
                }

                // free the garbage
                hprocess.Release();
                process_information.FreeHandle(processInformation);
            }
         */

        /*
             to get access to Array List ... use this sample.
             [&tokenInformation->TokenPrivileges]
             without the >> & the result will be bad 
         
             var tokenPrivileges = &tokenInformation->TokenPrivileges;
             for (var i = 0; i < tokenPrivileges->PrivilegeCount; i++)
             {
                  var attrib = (&tokenPrivileges->First)[i];
                  luidList.Add(attrib.Luid.ToString(), attrib.Attributes);
             }
         */

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwQueryInformationProcess")]
        public static extern NtStatus NtQueryInformationProcess(
            SafeProcessHandle hProcess, 
            process_information_class processInformationClass,
            IntPtr processInformation, 
            uint processInformationLength, 
            out uint returnLength);

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwWow64QueryInformationProcess64")]
        public static extern NtStatus NtWow64QueryInformationProcess64(
            SafeProcessHandle hProcess,
            process_information_class processInformationClass,
            IntPtr processInformation,
            uint processInformationLength,
            out uint returnLength);

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwSetInformationProcess")]
        public static extern NtStatus NtSetInformationProcess(
            SafeProcessHandle hProcess,
            process_information_class processInformationClass,
            IntPtr processInformation,
            uint processInformationLength);

        #endregion

        #region Thread Information

        /*
            unsafe
            {
                NtStatus status;
                uint returnLength;
                var hThread = kernel32.GetCurrentThread();
                var infoClass = THREAD_INFORMATION_CLASS.ThreadBasicInformation;
                var threadInformation = THREAD_INFORMATION.CreateHandle(infoClass, out returnLength);

                status = ntdll.NtQueryInformationThread(
                    hThread, infoClass,
                    (IntPtr)threadInformation,
                    returnLength,
                    out returnLength);

                if (status == NtStatus.UNSUCCESSFUL ||
                    status == NtStatus.NOT_IMPLEMENtED ||
                    status == NtStatus.INVALID_INFO_CLASS)
                {
                    THREAD_INFORMATION.FreeHandle(threadInformation);
                    throw new System.ComponentModel.Win32Exception(
                        Marshal.GetLastWin32Error());
                }

                if (status == NtStatus.INFO_LENGTH_MISMATCH ||
                    status == NtStatus.BUFFER_TOO_SMALL ||
                    status == NtStatus.BUFFER_OVERFLOW)
                {
                    do
                    {
                        THREAD_INFORMATION.FreeHandle(threadInformation);
                        threadInformation = THREAD_INFORMATION.CreateHandle(returnLength);

                        status = ntdll.NtQueryInformationThread(
                            hThread, infoClass,
                            (IntPtr)threadInformation,
                            returnLength,
                            out returnLength);
                    } while (
                        status == NtStatus.INFO_LENGTH_MISMATCH ||
                        status == NtStatus.BUFFER_TOO_SMALL ||
                        status == NtStatus.BUFFER_OVERFLOW);
                }

                if (status == NtStatus.SUCCESS)
                {
                    Console.WriteLine();
                    Console.WriteLine(threadInformation->ThreadBasicInformation);
                }

                // free the garbage
                THREAD_INFORMATION.FreeHandle(threadInformation);
            }
         */

        /*
             to get access to Array List ... use this sample.
             [&tokenInformation->TokenPrivileges]
             without the >> & the result will be bad 
         
             var tokenPrivileges = &tokenInformation->TokenPrivileges;
             for (var i = 0; i < tokenPrivileges->PrivilegeCount; i++)
             {
                  var attrib = (&tokenPrivileges->First)[i];
                  luidList.Add(attrib.Luid.ToString(), attrib.Attributes);
             }
         */

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwQueryInformationThread")]
        public static extern NtStatus NtQueryInformationThread(
            SafeThreadHandle threadHandle,
            THREAD_INFORMATION_CLASS threadInformationClass,
            IntPtr threadInformation,
            uint threadInformationLength,
            out uint returnLength);

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwSetInformationThread")]
        public static extern NtStatus NtSetInformationThread(
            SafeThreadHandle threadHandle,
            THREAD_INFORMATION_CLASS threadInformationClass,
            IntPtr threadInformation,
            uint threadInformationLength);

        #endregion

        #region File Information

        /*
            unsafe
            {
                NtStatus status;
                uint returnLength;
                var infoClass = FILE_INFORMATION_CLASS.FileNameInformation;
                var fileInformation = FILE_INFORMATION.CreateHandle(infoClass, out returnLength);

                IO_STATUS_BLOCK ioStatusBlock;
                var hFile = kernel32.CreateFile(
                    "C:\\Program Files\\Chrome\\Chrome.exe",
                    FileAccess.FileAllAccess, FileShare.Read, IntPtr.Zero,
                    FileMode.Open, (FileAttributes)0, IntPtr.Zero);

                status = ntdll.NtQueryInformationFile(
                    hFile,
                    out ioStatusBlock,
                    (IntPtr)fileInformation,
                    returnLength,
                    infoClass);

                if (status == NtStatus.UNSUCCESSFUL ||
                    status == NtStatus.NOT_IMPLEMENtED ||
                    status == NtStatus.INVALID_INFO_CLASS)
                {
                    FILE_INFORMATION.FreeHandle(fileInformation);
                    throw new System.ComponentModel.Win32Exception(
                        Marshal.GetLastWin32Error());
                }

                if (status == NtStatus.INFO_LENGTH_MISMATCH ||
                    status == NtStatus.BUFFER_TOO_SMALL ||
                    status == NtStatus.BUFFER_OVERFLOW)
                {
                    do
                    {
                        returnLength *= 2;
                        FILE_INFORMATION.FreeHandle(fileInformation);
                        fileInformation = FILE_INFORMATION.CreateHandle(returnLength);

                        status = ntdll.NtQueryInformationFile(
                            hFile,
                            out ioStatusBlock,
                            (IntPtr)fileInformation,
                            returnLength,
                            infoClass);
                    } while (
                        status == NtStatus.INFO_LENGTH_MISMATCH ||
                        status == NtStatus.BUFFER_TOO_SMALL ||
                        status == NtStatus.BUFFER_OVERFLOW);
                }

                if (status == NtStatus.SUCCESS)
                {
                    Console.WriteLine();
                    Console.WriteLine(fileInformation->FileNameInformation.Name);
                }

                // free the garbage
                hFile.Release();
                FILE_INFORMATION.FreeHandle(fileInformation);
            }
         */

        /*
             to get access to Array List ... use this sample.
             [&tokenInformation->TokenPrivileges]
             without the >> & the result will be bad 
         
             var tokenPrivileges = &tokenInformation->TokenPrivileges;
             for (var i = 0; i < tokenPrivileges->PrivilegeCount; i++)
             {
                  var attrib = (&tokenPrivileges->First)[i];
                  luidList.Add(attrib.Luid.ToString(), attrib.Attributes);
             }
         */

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwQueryInformationFile")]
        public static extern NtStatus NtQueryInformationFile(
            SafeFileHandle fileHandle,
            out IO_STATUS_BLOCK ioStatusBlock,
            [Out] IntPtr fileInformation,
            uint length,
            FILE_INFORMATION_CLASS fileInformationClass);

        [DllImport("ntdll.dll", SetLastError = true,
            EntryPoint = "ZwSetInformationFile")]
        public static extern NtStatus NtSetInformationFile(
            SafeFileHandle fileHandle,
            out IO_STATUS_BLOCK ioStatusBlock,
            [In] IntPtr fileInformation,
            uint length,
            FILE_INFORMATION_CLASS fileInformationClass);

        #endregion
    }
    public static class gdi32
    {
        #region Bitmap
        /* creates a bitmap with the specified width, height, and bit depth. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern SafeBitmapHandle CreateBitmap(
            int nWidth, 
            int nHeight, 
            UINT cPlanes, 
            UINT cBitsPerPel, 
            IntPtr lpvBits);

        /* creates a bitmap compatible with the device associated with the specified device context. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern SafeBitmapHandle CreateCompatibleBitmap(
            SafeDCHandle hdc,
            int nWidth,
            int nHeight);
        #endregion

        #region Region
        /* 
            * creates a rectangular region. 
            * When you no longer need the HRGN object, 
            * call the DeleteObject function to delete it.
            */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern SafeRegionHandle CreateRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect);
        #endregion

        #region Object
        /* retrieves information for the specified graphics object. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int GetObject(
            IntPtr hgdiobj,
            int cbBuffer,
            LPVOID lpvObject);

        /* retrieves the type of the specified object. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern ObjectType GetObjectType(
            IntPtr h);

        /* retrieves information for the specified graphics object. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr GetCurrentObject(
            SafeDCHandle hdc,
            ObjectType uObjectType);

        /* selects an object into the specified device context (DC). */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr SelectObject(SafeDCHandle hdc, IntPtr hgdiobj);

        /* deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the object. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject); 
        #endregion

        #region Device Context
        /* creates a device context (DC) for a device using the specified name. */
        [DllImport("gdi32.dll", SetLastError = true,
            EntryPoint = "CreateDCW", CharSet = CharSet.Unicode)]
        public static extern SafeDCHandle CreateDC(
            LPCTSTR lpszDriver, LPCTSTR lpszDevice, LPCTSTR lpszOutput, ref DEVMODE lpInitData);

        /* creates a memory device context (DC) compatible with the specified device. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern SafeDCHandle CreateCompatibleDC(
            SafeDCHandle hdc);

        /* releases a device context (DC), freeing it for use by other applications. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(
            SafeWindowHandle hWnd, SafeDCHandle hDC);

        /* deletes the specified device context (DC). */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool DeleteDC(
            SafeDCHandle hdc);

        /* cancels any pending operation on the specified device context (DC). */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool CancelDC(
            SafeDCHandle hdc);

        /* updates the specified printer or plotter device context (DC) using the specified information. */
        [DllImport("gdi32.dll", SetLastError = true,
            EntryPoint = "ResetDCW", CharSet = CharSet.Unicode)]
        public static extern SafeDCHandle ResetDC(
            SafeDCHandle hdc, ref DEVMODE lpInitData);

        /*
            * saves the current state of the specified device context (DC)
            * by copying data describing selected objects and graphic modes
            * (such as the bitmap, brush, palette, font, pen, region, drawing mode, and mapping mode)
            * to a context stack. 
            */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int SaveDC(
            SafeDCHandle hdc);

        /*
            * restores a device context (DC) to the specified state. 
            * The DC is restored by popping state information off a stack 
            * created by earlier calls to the SaveDC function.
            */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern BOOL RestoreDC(
            SafeDCHandle hdc, int nSavedDC);

        /* retrieves device-specific information for the specified device. */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern int GetDeviceCaps(
            SafeDCHandle hdc, DCType nIndex);

        /*
            * performs a bit-block transfer of the color data corresponding to a rectangle of pixels
            * from the specified source device context 
            * into a destination device context.
            */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool BitBlt(
            SafeDCHandle hdcDest, 
            int nXDest, int nYDest,     /* 0, 0 */
            int nWidth, int nHeight,    /* Width, Height */
            SafeDCHandle hdcSrc,
            int nXSrc, int nYSrc,       /* X, Y */
            CopyPixelOperation dwRop);

        /*
            * copies a bitmap from a source rectangle into a destination rectangle,
            * stretching or compressing the bitmap to fit the dimensions of the destination rectangle,
            * if necessary. 
            */
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool StretchBlt(
            SafeDCHandle hdcDest,
            int nXDest, int nYDest,     /* 0, 0 */
            int nWidth, int nHeight,    /* Width, Height */
            SafeDCHandle hdcSrc,
            int nXSrc, int nYSrc,       /* X, Y */
            CopyPixelOperation dwRop);
        #endregion
    }
    public static class dwmApi
    {
        #region Desktop Window Manager

        /* Enable and Disable DWM Composition */

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmIsCompositionEnabled(
            out bool pfEnabled);

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmEnableComposition(
            bool enablecomposition);

        /* Controlling Non-Client Region Rendering */

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmGetTransportAttributes(
            out BOOL pfIsRemoting,
            out BOOL pfIsConnected,
            out DWORD pDwGeneration);

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmGetWindowAttribute(
            SafeWindowHandle hwnd,
            DWMWINDOWATTRIBUTE dwAttribute,
            out VOID pvAttribute);

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmSetWindowAttribute(
            SafeWindowHandle hwnd,
            DWMWINDOWATTRIBUTE dwAttribute,
            LPCVOID pvAttribute,
            DWORD cbAttribute);

        /* Adding Blur to a Specific Region of the Client Area */

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmEnableBlurBehindWindow(
            SafeWindowHandle hWnd,
            ref DWM_BLURBEHIND pBlurBehind);

        /* Extending the Client Frame */

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmExtendFrameIntoClientArea(
            SafeWindowHandle hwnd,
            ref MARGINS m);

        /* DWM Thumbnail Relationships */

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmRegisterThumbnail(
            SafeWindowHandle hwndDestination,
            SafeWindowHandle hwndSource,
            out IntPtr phThumbnailId);

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmUpdateThumbnailProperties(
            IntPtr hThumbnailId,
            ref DWM_THUMBNAIL_PROPERTIES ptnProperties);

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmQueryThumbnailSourceSize(
            IntPtr hThumbnail,
            out SIZE pSize);

        [DllImport("Dwmapi.dll", SetLastError = true)]
        public static extern ComError DwmUnregisterThumbnail(
            IntPtr hThumbnailId);

        #endregion
    }
    public static class user32
    {
        #region Hook
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(
            HookType idHook,
            LowLevelProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(
            HookType idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);
        #endregion

        #region Hotkey
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(SafeWindowHandle hwnd, int id, Modifiers fsModifiers, VirtualKey vlc);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(SafeWindowHandle hwnd, int id);
        #endregion

        #region Clipboard [Interprocess Communications]
        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL OpenClipboard(SafeWindowHandle hWndNewOwner);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL EmptyClipboard();

        [DllImport("User32.dll", SetLastError = true)]
        public static extern HANDLE SetClipboardData(ClipboardFormat uFormat, HANDLE hMem);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern HANDLE GetClipboardData(ClipboardFormat uFormat);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL CloseClipboard();

        //
        // Clipboard Formats
        //

        [DllImport("User32.dll", SetLastError = true)]
        public static extern int CountClipboardFormats();

        [DllImport("User32.dll", SetLastError = true)]
        public static extern ClipboardFormat EnumClipboardFormats(ClipboardFormat format);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL IsClipboardFormatAvailable(ClipboardFormat format);

        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "GetClipboardFormatNameW", CharSet = CharSet.Unicode)]
        public static extern int GetClipboardFormatName(ClipboardFormat format, StringBuilder lpszFormatName, int cchMaxCount);

        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "RegisterClipboardFormatW", CharSet = CharSet.Unicode)]
        public static extern UINT RegisterClipboardFormat(LPCTSTR lpszFormat);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetPriorityClipboardFormat(uint[] paFormatPriorityList, int cFormats);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL GetUpdatedClipboardFormats(out IntPtr lpuiFormats, uint cFormats, out IntPtr pcFormatsOut);

        //
        // Monitor
        //

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL AddClipboardFormatListener(HWND hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL RemoveClipboardFormatListener(HWND hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetClipboardViewer(SafeWindowHandle hwndNewViewer);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardViewer();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ChangeClipboardChain(SafeWindowHandle hwndRemove, SafeWindowHandle hwndNewNext);

        //
        // Misc
        //

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardOwner();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetClipboardSequenceNumber();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();
        #endregion

        #region Mouse / keyboard
        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public unsafe static extern UINT SendInput(
            UINT nInputs, INPUT* pInputs, uint cbSize);

        /// <summary>
        /// process mouse event
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void mouse_event(
            MouseEventFlags dwFlags, 
            uint dx, uint dy, uint dwData,
            MouseEventDataXButtons dwExtraInfo);

        /// <summary>
        /// process keyboard event,
        /// you want send some keys use this format :: 
        /// keybd_event(MENU, KeyPress) > keybd_event(F4, KeyPress) > keybd_event(F4, KeyRelease) > keybd_event(MENU, KeyRelease)
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(
            VirtualKeyByte bVk,
            ScanCodeByte bScan, 
            KeyEventFlags dwFlags, 
            int dwExtraInfo);

        /// <summary>
        /// Get Mouse Position
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// Set Mouse Position
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetCursorPos(int x, int y);

        /// <summary>
        /// Translates (maps) a virtual-key code into a scan code
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint MapVirtualKey(uint uCode, MapVirtualKeyMapTypes uMapType);

        /// <summary>
        /// Retrieves the status of the specified virtual key. The status specifies whether the key is up, down,
        /// or toggled (on, off—alternating each time the key is pressed). 
        /// </summary>
        /// <returns>If the high-order bit is 1, the key is down; otherwise, it is up. see MSDN.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort GetKeyState(VirtualKey vKey);

        /// <summary>
        /// Determines whether a key is up or down at the time the function is called,
        /// and whether the key was pressed after a previous call to GetAsyncKeyState.
        /// </summary>
        /// <param name="vKey">The virtual-key code.</param>
        /// <returns>0 = not pressed since last call, 1 = pressed since last call, -32767 = pressed now</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort GetAsyncKeyState(VirtualKey vKey);

        /* Retrieves a handle to the window (if any) that has captured the mouse. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetCapture();

        /* Sets the mouse capture to the specified window belonging to the current thread. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle SetCapture(SafeWindowHandle hWnd);

        /* Releases the mouse capture from a window in the current thread and restores normal mouse input processing.  */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL ReleaseCapture();

        /* Blocks keyboard and mouse input events from reaching applications. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL BlockInput(BOOL fBlockIt);

        /* like it sound */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL SwapMouseButton(BOOL fSwap);
        #endregion

        #region ShutDown
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ExitWindowsEx(
            EWX uFlags, ShutdownReason dwReason);

        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool LockWorkStation();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShutdownBlockReasonCreate(
            SafeWindowHandle hWnd,
            String pwszReason);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShutdownBlockReasonQuery(
            SafeWindowHandle hWnd,
            StringBuilder pwszBuff,
            ref DWORD pcchBuff);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShutdownBlockReasonDestroy(
            SafeWindowHandle hWnd);
        #endregion

        #region Process
        /*
            * Waits until the specified process is waiting 
            * for user input with no input pending, 
            * or until the time-out interval has elapsed.
            */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern DWORD WaitForInputIdle(
            SafeProcessHandle handle,
            DWORD dwMilliseconds);
        #endregion

        #region Desktop
        /// <summary>
        /// Creates a new desktop, 
        /// associates it with the current window station of the calling process, 
        /// and assigns it to the calling thread. The calling process must have an associated window station, 
        /// either assigned by the system at process creation time
        ///  or set by the SetProcessWindowStation function.
        /// ---------------------------------------
        /// To specify the size of the heap for the desktop, use the CreateDesktopEx function.
        /// dwFlags parameter can be zero [0x0000] or this following value :: DF_ALLOWOTHERACCOUNTHOOK [0x0001]
        /// </summary>
        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "CreateDesktopW", CharSet = CharSet.Unicode)]
        public static extern SafeDesktopHandle CreateDesktop(
            string lpszDesktop,
            IntPtr reserved1,
            IntPtr reserved2,
            DWORD dwFlags,
            ACCESS_MASK dwDesiredAccess,
            IntPtr lpsa);

        /// <summary>
        /// Creates a new desktop with the specified heap,
        /// associates it with the current window station of the calling process,
        /// and assigns it to the calling thread. 
        /// The calling process must have an associated window station,
        /// either assigned by the system at process creation time
        ///  or set by the SetProcessWindowStation function.
        /// ---------------------------------------
        /// dwFlags parameter can be zero [0x0000] or this following value :: DF_ALLOWOTHERACCOUNTHOOK [0x0001]
        /// </summary>
        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "CreateDesktopExW", CharSet = CharSet.Unicode)]
        public static extern SafeDesktopHandle CreateDesktopEx(
            string lpszDesktop,
            IntPtr reserved1,
            IntPtr reserved2,
            DWORD dwFlags,
            ACCESS_MASK dwDesiredAccess,
            IntPtr lpsa,
            ULONG ulHeapSize,
            IntPtr reserved3);

        /// <summary>
        /// Opens the specified desktop object.
        /// ---------------------------------------
        /// dwFlags parameter can be zero [0x0000] or this following value :: DF_ALLOWOTHERACCOUNTHOOK [0x0001]
        /// </summary>
        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "OpenDesktopW", CharSet = CharSet.Unicode)]
        public static extern SafeDesktopHandle OpenDesktop(
            string lpszDesktop,
            DWORD dwFlags,
            BOOL fInherit,
            ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Opens the desktop that receives user input.
        /// ---------------------------------------
        /// dwFlags parameter can be zero [0x0000] or this following value :: DF_ALLOWOTHERACCOUNTHOOK [0x0001]
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern SafeDesktopHandle OpenInputDesktop(
            DWORD dwFlags,
            BOOL fInherit,
            ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// Makes the specified desktop visible and activates it.
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool SwitchDesktop(
            SafeDesktopHandle hDesktop);

        /// <summary>
        /// Closes an open handle to a desktop object.
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern bool CloseDesktop(
            SafeDesktopHandle hDesktop);

        /* Thread Desktop */

        /// <summary>
        /// Retrieves a handle to the desktop assigned to the specified thread.
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern SafeDesktopHandle GetThreadDesktop(
            DWORD dwThreadId);

        /// <summary>
        /// Assigns the specified desktop to the calling thread.
        /// All subsequent operations on the desktop use the access rights granted to the desktop.
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL SetThreadDesktop(
            SafeDesktopHandle hDesktop);

        /* Enum */

        /// <summary>
        /// Enumerates all desktops associated with
        /// the specified window station of the calling process.
        /// The function passes the name of each desktop,
        /// in turn, to an application-defined callback function.
        /// </summary>
        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "EnumDesktopsW", CharSet = CharSet.Unicode)]
        public static extern BOOL EnumDesktops(
            SafeWindowStationHandle hwinsta,
            EnumDesktopProc lpEnumFunc,
            IntPtr lParam);

        #endregion

        #region WindowStation

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "CreateWindowStationW", CharSet = CharSet.Unicode)]
        public static extern SafeWindowStationHandle CreateWindowStation(
            string lpwinsta,
            DWORD dwFlags,
            ACCESS_MASK dwDesiredAccess,
            IntPtr lpsa);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "OpenWindowStationW", CharSet = CharSet.Unicode)]
        public static extern SafeWindowStationHandle OpenWindowStation(
            string lpwinsta,
            BOOL fInherit,
            ACCESS_MASK dwDesiredAccess);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL CloseWindowStation(
            SafeWindowStationHandle hWinSta);

        /* Process WindowStation */

        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowStationHandle GetProcessWindowStation();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL SetProcessWindowStation(
            SafeWindowStationHandle hWinSta);

        /* Enum */

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL EnumWindowStations(
            EnumWindowStationProc lpEnumFunc,
            IntPtr lParam);

        #endregion

        #region ObjectInformation { WindowStation, Desktop }

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetUserObjectInformationW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetUserObjectInformation(
            HANDLE hObj,
            UserObjectInformation nIndex,
            PVOID pvInfo,
            DWORD nLength,
            out DWORD lpnLengthNeeded);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetUserObjectInformationW", CharSet = CharSet.Unicode)]
        public static extern BOOL SetUserObjectInformation(
            HANDLE hObj,
            UserObjectInformation nIndex,
            PVOID pvInfo,
            DWORD nLength);

        #endregion

        #region Image, Icon, Cursur
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadImage(
            IntPtr hinst, string lpszName, ImageType uType, int cxDesired, int cyDesired, ImageFlagsExtended fuLoad);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CopyImage(
            IntPtr hImage, ImageType uType, int cxDesired, int cyDesired, ImageFlags fuFlags);

        /* Copies the specified icon from another module to the current module. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeIconHandle CopyIcon(
            SafeIconHandle hIcon);

        /* Creates an icon that has the specified size, colors, and bit patterns. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeIconHandle CreateIcon(
            HINSTANCE hInstance,
            int nWidth, int nHeight,
            BYTE cPlanes, BYTE cBitsPixel,
            BYTE[] lpbAnDbits, BYTE[] lpbXORbits);

        /* Destroys an icon and frees any memory the icon occupied. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL DestroyIcon(
            SafeIconHandle hIcon);

        /* Draws an icon or cursor into the specified device context. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL DrawIcon(
            HDC hDc,
            int X, int Y,
            SafeIconHandle hIcon);

        /* Loads the specified icon resource from the executable (.exe) file 
            associated with an application instance. */
        [Obsolete("use LoadImage instead")]
        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "LoadIconW", CharSet = CharSet.Unicode)]
        public static extern BOOL LoadIcon(
            HINSTANCE hInstance, LPCTSTR lpIconName);

        /* Retrieves information about the specified icon or cursor. */
        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL GetIconInfo(
            SafeIconHandle hIcon, out ICONINFO piconinfo);

        /* Retrieves information about the specified icon or cursor.
            GetIconInfoEx extends GetIconInfo by using the newer ICONINFOEX structure. */
        [DllImport("User32.dll", SetLastError = true,
            EntryPoint = "GetIconInfoExW", CharSet = CharSet.Unicode)]
        public static extern SafeIconHandle GetIconInfoEx(
            SafeIconHandle hIcon, ref ICONINFOEX piconinfoex); 
        #endregion

        #region Region
        /* obtains a copy of the window region of a window. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowRgn(
            SafeWindowHandle hWnd,
            SafeRegionHandle hRgn);

        /// <summary>
        /// sets the window region of a window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowRgn(
            SafeWindowHandle hWnd,
            SafeRegionHandle hRgn,
            bool bRedraw);

        /// <summary>
        /// invalidates the client area within the specified region by adding it to the current update region of a window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool InvalidateRgn(
            SafeWindowHandle hWnd,
            SafeRegionHandle hRgn,
            bool bErase);
        #endregion

        #region Device Context

        /* retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeDCHandle GetDC(SafeWindowHandle hWnd);

        /* retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeDCHandle GetWindowDC(SafeWindowHandle hWnd);

        /* returns a handle to the window associated with the specified display device context (DC).  */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle WindowFromDC(SafeDCHandle hDC);

        #endregion

        #region Print API

        /* copies a visual window into the specified device context (DC), typically a printer DC. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PrintWindow(SafeWindowHandle hwnd, SafeDCHandle hDC, PrintFlags nFlags);

        #endregion

        #region Timer
        /// <summary>
        /// Creates a timer with the specified time-out value.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeTimerHandle SetTimer(
            SafeWindowHandle hWnd,
            UIntPtr nIDEvent,
            UINT uElapse,
            TimerProc lpTimerFunc);

        /// <summary>
        /// Creates a timer with the specified time-out value
        /// and coalescing tolerance delay.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeTimerHandle SetCoalescableTimer(
            SafeWindowHandle hWnd,
            UIntPtr nIDEvent,
            UINT uElapse,
            TimerProc lpTimerFunc,
            ULONG uToleranceDelay);

        /// <summary>
        /// Destroys the specified timer. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL KillTimer(
            SafeWindowHandle hWnd,
            UIntPtr uIDEvent);
	    #endregion

        #region System

        /// <summary>
        /// Retrieves the current color of the specified display element.
        ///  Display elements are the parts of a window and the display that appear on the system display screen.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern DWORD GetSysColor(
            int nIndex);

        /// <summary>
        /// Sets the colors for the specified display elements. 
        /// Display elements are the various parts of a window 
        /// and the display that appear on the system display screen
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL SetSysColors(
            int cElements,
            ref int lpaElements,
            ref COLORREF lpaRgbValues);

        /// <summary>
        /// Retrieves the specified system metric or system configuration setting.
        /// Note that all dimensions retrieved by GetSystemMetrics are in pixels.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetSystemMetrics(
            SystemMetric nIndex);

        /// <summary>
        /// Retrieves or sets the value of one of the system-wide parameters. 
        /// This function can also update the user profile while setting a parameter.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SystemParametersInfoW", CharSet = CharSet.Unicode)]
        public static extern bool SystemParametersInfo(
            ParameterAction uiAction,
            UINT uiParam,   /* sizeof(Type)*/
            PVOID pvParam,  /* Address who contain / receive the data*/
            ParameterFlags fWinIni);

        // SystemParametersInfo
        #endregion

        #region Device Management

        // SUPPORTED MSG
        // LIST :: <<&>>

        // WM_DEVICECHANGE
        // DBT_CONFIGCHANGECANCELED
        // DBT_CONFIGCHANGED
        // DBT_CUSTOMEVENT
        // DBT_DEVICEARRIVAL
        // DBT_DEVICEQUERYREMOVE
        // DBT_DEVICEQUERYREMOVEFAILED
        // DBT_DEVICEREMOVECOMPLETE
        // DBT_DEVICEREMOVEPENDING
        // DBT_DEVICETYPESPECIFIC
        // DBT_DEVNODES_CHANGED 
        // DBT_QUERYCHANGECONFIG 
        // DBT_USERDEFINED

        // notification Filter
        // can be pointer for

        // DEV_BROADCAST_HDR
        // DEV_BROADCAST_OEM
        // DEV_BROADCAST_PORT
        // DEV_BROADCAST_HANDLE
        // DEV_BROADCAST_VOLUME
        // DEV_BROADCAST_DEVICEINTERFACE

        // Detecting Hardware Insertion and/or Removal
        // http://www.codeproject.com/Articles/14500/Detecting-Hardware-Insertion-and-or-Removal

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "RegisterDeviceNotificationA", CharSet = CharSet.Ansi)]
        public unsafe static extern IntPtr RegisterDeviceNotification(
            SafeWindowHandle hRecipient,
            DEV_BROADCAST_HDR* notificationFilter,
            DEVICE_NOTIFY flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL UnregisterDeviceNotification(
            IntPtr handle);

        #endregion

        // Window Features
        // http://msdn.microsoft.com/en-us/library/ms632599.aspx

        // A Simple Window
        // http://www.winprog.org/tutorial/simple_window.html

        // Control Library
        // http://msdn.microsoft.com/en-us/library/windows/desktop/bb773169(v=vs.85).aspx

        // RegisterClassEx
        // WindowProc [Callback] >> DefWindowProc()
        // CreateWindowEx
        // ShowWindow / UpdateWindow
        // While(GetMessage())(TranslateMessage(), DispatchMessage())

        // Layered Windows
        // http://msdn.microsoft.com/en-us/library/ms997507.aspx

        /*
            * Create OR Set Layer Windows
            * CreateWindowEx(WS_EX_LAYERED | ...)
            * SetWindowLong(WS_EX_LAYERED | ...)
            */

        /*
            * Handle WM_PAINT MSG
            * UpdateLayeredWindow()
            * >> SafeWindowHandle.Colour
            * >> SafeWindowHandle.Opicity
            * SetLayeredWindowAttributes()
            * >> SafeWindowHandle.Update
            */

        #region Window Class

        // Register / Unregister

        /* return String ID */
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "RegisterClassExW", CharSet = CharSet.Unicode)]
        public static extern IntPtr RegisterClassEx(
            ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "UnregisterClassW", CharSet = CharSet.Unicode)]
        public static extern bool UnregisterClass(
            IntPtr lpClassName,
            HINSTANCE hInstance);

        // Get

        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL GetClassInfoEx(
            HINSTANCE hinst,
            IntPtr lpszClass,
            out WNDCLASSEX lpwcx);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetClassLongW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetClassLong(
            SafeWindowHandle hWnd,
            int nIndex);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetClassLongPtrW", CharSet = CharSet.Unicode)]
        public static extern ULONG_PTR GetClassLongPtr(
            SafeWindowHandle hWnd,
            int nIndex);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetClassNameW", CharSet = CharSet.Unicode)]
        public static extern int GetClassName(
            SafeWindowHandle hWnd,
            StringBuilder lpClassName,
            int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern WORD GetClassWord(
            SafeWindowHandle hWnd,
            int nIndex); // -32 /* GCW_ATOM >> String ID */

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetWindowLongW", CharSet = CharSet.Unicode)]
        public static extern LONG GetWindowLong(
            SafeWindowHandle hWnd,
            WindowStyleFlags nIndex);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetWindowLongPtrW", CharSet = CharSet.Unicode)]
        public static extern LONG_PTR GetWindowLongPtr(
            SafeWindowHandle hWnd,
            WindowStyleFlags nIndex);

        // Set

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetClassLongW", CharSet = CharSet.Unicode)]
        public static extern DWORD SetClassLong(
            SafeWindowHandle hWnd,
            int nIndex,
            LONG dwNewLong);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetClassLongPtrW", CharSet = CharSet.Unicode)]
        public static extern ULONG_PTR SetClassLongPtr(
            SafeWindowHandle hWnd,
            int nIndex,
            LONG dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern WORD SetClassWord(
            SafeWindowHandle hWnd,
            int nIndex,
            WORD wNewWord);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetWindowLongW", CharSet = CharSet.Unicode)]
        public static extern int SetWindowLong(
            SafeWindowHandle hWnd,
            WindowStyleFlags nIndex,
            WindowStyle dwNewLong);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetWindowLongPtrW", CharSet = CharSet.Unicode)]
        public static extern int SetWindowLongPtr(
            SafeWindowHandle hWnd,
            WindowStyleFlags nIndex,
            WindowStyle dwNewLong);

        #endregion

        #region Window Procedure

        /// <summary>
        /// Passes message information to the specified window procedure.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint CallWindowProc(
            WindowProc lpPrevWndFunc,
            SafeWindowHandle hwnd,
            WindowMessege uMsg,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        /// Calls the default window procedure to provide default processing
        /// for any window messages that an application does not process. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint DefWindowProc(
            SafeWindowHandle hwnd,
            WindowMessege uMsg,
            IntPtr wParam,
            IntPtr lParam);

        #endregion

        #region Messages and Message

        /// <summary>
        /// send messege to a windows and stay for replay
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(
            SafeWindowHandle hWnd,
            WindowMessege msg,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        /// post messege to a windows and go away
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(
            SafeWindowHandle hWnd,
            WindowMessege msg,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        /// Indicates to the system that a thread has made a request to terminate (quit). 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void PostQuitMessage(
            int nExitCode);

        /// <summary>
        /// Dispatches incoming sent messages,
        /// checks the thread message queue for a posted message,
        /// and retrieves the message (if any exist).
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PeekMessage(
            out MSG lpMsg,
            SafeWindowHandle hWnd,
            UINT wMsgFilterMin,
            UINT wMsgFilterMax,

            // 0x0000 NOREMOVE
            // 0x0001 REMOVE
            // 0x0002 NOYIELD
            UINT wRemoveMsg);

        /// <summary>
        /// Retrieves a message from the calling thread's message queue.
        /// The function dispatches incoming sent messages until a posted message is available for retrieval. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetMessage(
            out MSG lpMsg,
            SafeWindowHandle hWnd,
            UINT wMsgFilterMin,
            UINT wMsgFilterMax);

        /// <summary>
        /// Yields control to other threads when a thread has no other messages in its message queue.
        /// The WaitMessage function suspends the thread and does not return, 
        /// until a new message is placed in the thread's message queue.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool WaitMessage();

        /// <summary>
        /// Translates virtual-key messages into character messages. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool TranslateMessage(
            ref MSG lpMsg);

        /// <summary>
        /// Dispatches a message to a window procedure.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern DWORD DispatchMessage(
            ref MSG lpMsg);

        #endregion

        #region Window [Handle]

        /// <summary>
        /// Creates an overlapped, pop-up, or child window.
        ///  It specifies the window class, window title, window style,
        ///  and (optionally) the initial position and size of the window. 
        /// The function also specifies the window's parent or owner, if any,
        ///  and the window's menu.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "CreateWindowExW", CharSet = CharSet.Unicode)]
        public static extern SafeWindowHandle CreateWindowEx(
            WindowStyle dwExStyle,
            IntPtr lpClassName, // result from RegisterClassEx
            string lpWindowName,
            WindowStyle dwStyle,
            int x, int y,
            int nWidth, int nHeight,
            SafeWindowHandle hWndParent,
            HMENU hMenu,
            HINSTANCE hInstance,
            LPVOID lpParam);

        /// <summary>
        /// Creates an overlapped, pop-up, or child window.
        ///  It specifies the window class, window title, window style,
        ///  and (optionally) the initial position and size of the window. 
        /// The function also specifies the window's parent or owner, if any,
        ///  and the window's menu.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "CreateWindowExW", CharSet = CharSet.Unicode)]
        public static extern SafeWindowHandle CreateWindowEx(
            WindowStyle dwExStyle,
            string lpClassName, // "Button, etc ..."
            string lpWindowName,
            WindowStyle dwStyle, // CHILD | VISIBLE
            int x, int y,
            int nWidth, int nHeight,
            SafeWindowHandle hWndParent, // Parent Window
            HMENU hMenu,
            HINSTANCE hInstance,
            LPVOID lpParam);

        /// <summary>
        /// Retrieves a handle to the Shell's desktop window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetShellWindow();

        /// <summary>
        /// Retrieves a handle to the desktop window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetDesktopWindow();

        /* Retrieves the window handle used by the console associated 
            with the calling process. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetConsoleWindow();

        /// <summary>
        /// get last activate Window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetForegroundWindow();
			
		/* Retrieves the window handle to the active window attached to the calling thread's message queue. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetActiveWindow();

        /* Retrieves the handle to the window that has the keyboard focus, if the window is attached to the calling thread's message queue. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetFocus();

        /* Retrieves information about the active window or a specified GUI thread. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL GetGUIThreadInfo(uint idThread, ref GuiThreadInfo lpgui);

        /// <summary>
        /// get windows from Current Point
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle WindowFromPoint(
            POINT point);

        /// <summary>
        /// get windows from specified physical point
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle WindowFromPhysicalPoint(
            POINT point);

        /// <summary>
        /// get Child windows from Current Point
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle ChildWindowFromPoint(
            SafeWindowHandle hwndParent,
            POINT point);

        /// <summary>
        /// get Child windows from Current Point Extended
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle ChildWindowFromPointEx(
            SafeWindowHandle hwndParent,
            POINT point,
            WindowFromPointFlags uFlags);

        /// <summary>
        /// find windows by title And/Or name
        /// </summary>
        /// <param name="lpClassName">name</param>
        /// <param name="lpWindowName">title</param>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "FindWindowW", CharSet = CharSet.Unicode)]
        public static extern SafeWindowHandle FindWindow(
            string lpClassName,
            string lpWindowName);

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "FindWindowExW", CharSet = CharSet.Unicode)]
        public static extern SafeWindowHandle FindWindowEx(
            SafeWindowHandle hwndParent,
            SafeWindowHandle hwndChildAfter,
            string lpszClass,
            string lpszWindow);

        /// <summary>
        /// Enumerates all top-level windows on the screen by passing the handle to each window,
        /// in turn, to an application-defined callback function.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL EnumWindows(
            WNDENUMPROC lpEnumFunc,
            IntPtr lParam);

        /// <summary>
        /// Enumerates all top-level windows associated with the specified desktop.
        /// It passes the handle to each window, in turn,
        /// to an application-defined callback function.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL EnumDesktopWindows(
            SafeDesktopHandle hDesktop,
            WNDENUMPROC lpfn,
            IntPtr lParam);

        /// <summary>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to an application-defined callback function.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(
            SafeWindowHandle hWndParent,
            WNDENUMPROC lpEnumFunc,
            IntPtr lParam);
        #endregion

        #region Window [Property]

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetPropW", CharSet = CharSet.Unicode)]
        public static extern HANDLE GetProp(
            SafeWindowHandle hWnd,
            LPCTSTR lpString);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetPropW", CharSet = CharSet.Unicode)]
        public static extern bool SetProp(
            SafeWindowHandle hWnd,
            LPCTSTR lpString,
            HANDLE hData);

        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "RemovePropW", CharSet = CharSet.Unicode)]
        public static extern HANDLE RemovePropW(
            SafeWindowHandle hWnd,
            LPCTSTR lpString);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int EnumProps(
            SafeWindowHandle hWnd,
            PropEnumProc lpEnumFunc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int EnumPropsEx(
            SafeWindowHandle hWnd,
            PropEnumProcEx lpEnumFunc,
            IntPtr lParam);

        #endregion

        #region Window [Get]

        /// <summary>
        /// Retrieves the opacity and transparency color key of a layered window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern BOOL GetLayeredWindowAttributes(
            SafeWindowHandle hwnd,
            out COLORREF crKey, // transparency color 
            out BYTE bAlpha,    // opacity [0 To 255]
            out DWORD dwFlags); // 0x1 [crKey] / 0x2 [bAlpha]

        /// <summary>
        /// Retrieves a handle to the specified window's parent or owner.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetParent(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Retrieves the handle to the ancestor of the specified window.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern SafeWindowHandle GetAncestor(
            SafeWindowHandle hWnd,
            AncestorFlags flags);

        /// <summary>
        /// [if there is some windows in same position ...]
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) 
        /// to the specified window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetWindow(
            SafeWindowHandle hWnd,
            GetWindow_Cmd uCmd);

        /// <summary>
        /// Retrieves a handle to the next or previous window in the Z-Order. 
        /// The next window is below the specified window; 
        /// the previous window is above.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetNextWindow(
            SafeWindowHandle hWnd,
            GetWindow_Cmd uCmd);

        /// <summary>
        /// Examines the Z order of the child windows associated with the specified parent window
        /// and retrieves a handle to the child window at the top of the Z order. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle GetTopWindow(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Retrieves a handle to the specified window's parent or owner.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowInfo(
            SafeWindowHandle hwnd,
            ref WINDOWINFO pwi);

        /// <summary>
        /// Retrieves information about the specified title bar.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetTitleBarInfo(
            SafeWindowHandle hwnd,
            ref TITLEBARINFO pti);

        /// <summary>
        /// get Windows title
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "GetWindowTextW", CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(
            SafeWindowHandle hWnd,
            StringBuilder lpString,
            int nMaxCount);

        /// <summary>
        /// Retrieves the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowPlacement(
            SafeWindowHandle hWnd,
            ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Retrieves the coordinates of a window's client area.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(
            SafeWindowHandle hWnd,
            out RECT lpRect);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(
            SafeWindowHandle hWnd,
            out RECT rect);

        /// <summary>
        /// converts the client-area coordinates of a specified point to screen coordinates.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ClientToScreen(
            SafeWindowHandle hWnd,
            out POINT lpPoint);

        /// <summary>
        /// converts the screen coordinates of a specified point on the screen to client-area coordinates
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ScreenToClient(
            SafeWindowHandle hWnd,
            out POINT lpPoint);

        /// <summary>
        /// Converts the logical coordinates of a point in a window to physical coordinates.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LogicalToPhysicalPoint(
            SafeWindowHandle hWnd,
            out POINT lpPoint);

        /// <summary>
        /// Converts the physical coordinates of a point in a window to logical coordinates.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PhysicalToLogicalPoint(
            SafeWindowHandle hWnd,
            out POINT lpPoint);

        /// <summary>
        /// converts (maps) a set of points from a coordinate space relative to one window to a coordinate space relative to another window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public unsafe static extern int MapWindowPoints(
            SafeWindowHandle hWndFrom,
            SafeWindowHandle hWndTo,
            POINT* lpPoints,
            UINT cPoints);

        /// <summary>
        /// Retrieves a string that specifies the window type.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "RealGetWindowClassW", CharSet = CharSet.Unicode)]
        public static extern uint RealGetWindowClass(
            SafeWindowHandle hwnd,
            StringBuilder pszType,
            uint cchType);

        /* GetWindowThreadProcessId() ==> tID, [out lpdwProcessId] ==> pID */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(
            SafeWindowHandle hWnd,
            out DWORD lpdwProcessId);
        #endregion

        #region Window [Set]

        /// <summary>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// If hdcSrc is NULL, hdcDst must be NULL [And] dwFlags should be zero
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public unsafe static extern BOOL UpdateLayeredWindow(
            // handle
            SafeWindowHandle hwnd,
            // target
            [Optional] SafeDCHandle hdcDst,  // If hdcDst is NULL, the default palette will be used.
            [Optional] POINT* pptDst,         // new screen position of the layered window.
            [Optional] SIZE* psize,           // new size of the layered window.
            // source
            [Optional] SafeDCHandle hdcSrc,  // A handle to a DC for the surface that defines the layered window
            [Optional] POINT* pptSrc,         // location of the layer in the device context
            // colour and transparency
            COLORREF crKey,                             // color key
            [Optional] BLENDFUNCTION* pblend, // transparency value
            ULW dwFlags);

        /// <summary>
        /// Sets the opacity and transparency color key of a layered window.
        /// </summary>
        [DllImport("User32.dll", SetLastError = true)]
        public static extern BOOL SetLayeredWindowAttributes(
            SafeWindowHandle hwnd,
            COLORREF crKey, // transparency color 
            BYTE bAlpha,    // opacity [0 To 255]
            DWORD dwFlags); // 0x1 [crKey] / 0x2 [bAlpha]
			
        /* Activates a window. The window must be attached to the calling thread's message queue. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle SetActiveWindow(SafeWindowHandle hWnd);

        /* Sets the keyboard focus to the specified window. The window must be attached to the calling thread's message queue. */
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle SetFocus(SafeWindowHandle hWnd);
			
        /// <summary>
        /// Changes the parent window of the specified child window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern SafeWindowHandle SetParent(
            SafeWindowHandle hWndChild,
            SafeWindowHandle hWndNewParent);

        /// <summary>
        /// set Windows title
        /// </summary>
        [DllImport("user32.dll", SetLastError = true,
            EntryPoint = "SetWindowTextW", CharSet = CharSet.Unicode)]
        public static extern bool SetWindowText(
            SafeWindowHandle hwnd,
            String lpString);

        /// <summary>
        /// enabled/disable window input
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EnableWindow(
            SafeWindowHandle hWnd,
            bool bEnable);

        /// <summary>
        /// Sets the show state and the restored, minimized, and maximized positions of the specified window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPlacement(
            SafeWindowHandle hWnd,
            ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// move Windows to specific location
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(
            SafeWindowHandle hWnd,
            int x,
            int y,
            int nWidth,
            int nHeight,
            bool bRepaint);

        /// <summary>
        /// Set Window Position
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(
            SafeWindowHandle hWnd,
            SetWindowPosInsertAfter hWndInsertAfter,
            int x, int y, int cx, int cy,
            SetWindowPosuFlags uFlags);

        /// <summary>
        /// Set multiple Window Position :: Begin
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr BeginDeferWindowPos(
            int nNumWindows);

            /// <summary>
        /// Set multiple Window Position :: Begin
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr DeferWindowPos(
            IntPtr hWinPosInfo, // handle from BeginDeferWindowPos
            SafeWindowHandle hWnd,
            SafeWindowHandle hWndInsertAfter,
            int x, int y,
            int cx, int cy,
            SetWindowPosuFlags uFlags);

        /// <summary>
        /// Set multiple Window Position :: End
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EndDeferWindowPos(
            IntPtr hWinPosInfo); // handle from DeferWindowPos

        /// <summary>
        /// adds a rectangle to the specified window's update region.
        ///  The update region represents the portion of the window's client area that must be redrawn.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UpdateWindow(
            SafeWindowHandle hWnd);

        /// <summary>
        /// adds a rectangle to the specified window's update region.
        ///  The update region represents the portion of the window's client area that must be redrawn.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool InvalidateRect(
            SafeWindowHandle hWnd,
            ref RECT lpRect,
            bool bErase);

        /// <summary>
        /// The RedrawWindow function updates the specified rectangle or region in a window's client area.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RedrawWindow(
            SafeWindowHandle hWnd,
            ref RECT lprcUpdate,
            IntPtr hrgnUpdate,
            RedrawWindowFlags flags);

        /// <summary>
        /// activate Window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(
            SafeWindowHandle hWnd);

        /// <summary>
        /// The foreground process can call the LockSetForegroundWindow function
        ///  to disable calls to the SetForegroundWindow function. 
        /// </summary>
        /// <param name="uLockCode">Dis = 1, Ena = 2</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LockSetForegroundWindow(
            UINT uLockCode);

        /// <summary>
        /// Enables the specified process to set the foreground window using the SetForegroundWindow function.
        /// The calling process must already be able to set the foreground window. For more information,
        /// see Remarks later in this topic.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool AllowSetForegroundWindow(
            DWORD dwProcessId);

        /// <summary>
        /// Brings the specified window to the top of the Z order.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Sets the specified window's view state. [show | hide | minisize]
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowWindow(
            SafeWindowHandle hWnd,
            ShowWindowCommand nCmdShow);

        /// <summary>
        /// Sets the specified window's view state. [show | hide | minisize]
        /// that created by a different thread.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowWindowAsync(
            SafeWindowHandle hWnd,
            ShowWindowCommand nCmdShow);

        /// <summary>
        /// flash window one time.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool AnimateWindow(
            SafeWindowHandle hwnd,
            DWORD dwTime,
            AnimateWindowFlags dwFlags);

        /// <summary>
        /// flash window one time.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool FlashWindow(
            SafeWindowHandle hwnd,
            bool bInvert);

        /// <summary>
        /// flash window x times.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool FlashWindowEx(
            ref FLASHWINFO pwfi);

        /// <summary>
        /// Minimizes (but does not destroy) the specified window. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool CloseWindow(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Tiles the specified child windows of the specified parent window.
        /// </summary>
        [DllImport("user32.dll", ExactSpelling = true)]
        public unsafe static extern bool TileWindows(
            SafeWindowHandle hWnd,
            TileWindowsFlags wHow,
            ref RECT lpRect,
            UINT cKids,
            HWND* lpKids);

        /// <summary>
        /// Cascades the specified child windows of the specified parent window.
        /// </summary>
        [DllImport("user32.dll", ExactSpelling = true)]
        public unsafe static extern bool CascadeWindows(
            SafeWindowHandle hWnd,
            TileWindowsFlags wHow,
            ref RECT lpRect,
            UINT cKids,
            HWND* lpKids);

        /// <summary>
        /// destroy Window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(
            SafeWindowHandle hwnd);

        /// <summary>
        /// Forcibly closes the specified window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EndTask(
            SafeWindowHandle hwnd,
            BOOL fShutDown,
            BOOL fForce);

        /// <summary>
        /// Enable / Disable Menu Items [Close, Min..., Max...], Also can be Done with SetWindowsLong
        /// </summary>
        /// <param name="hMenu">handle from GetSystemMenu Func</param>
        /// <param name="uIDEnableItem">Item to Enable / Disable / Gray / else</param>
        /// <param name="uEnable">Enable / Disable / Gray / else</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EnableMenuItem(
            SafeWindowHandle hMenu,
            SysCommands uIDEnableItem,
            MenuOption uEnable);

        #endregion

        #region Window [Is?]

        /// <summary>
        /// check if window is enabled for any input
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsWindowEnabled(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Check if windows exist
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsWindow(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Determines whether the specified window is a native Unicode window.Syntax
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsWindowUnicode(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Determines whether a window is a child window or descendant window
        /// of a specified parent window.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsChild(
            SafeWindowHandle hWndParent, 
            SafeWindowHandle hWnd);

        /// <summary>
        /// Determines whether the specified window is minimized.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsIconic(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Determines whether a window is maximized. 
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsZoomed(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Check if windows visible
        /// if it visible it maybe the main window
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsWindowVisible(
            SafeWindowHandle hWnd);

        /// <summary>
        /// Determines whether the system considers that a specified application is not responding
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsHungAppWindow(
            SafeWindowHandle hWnd);

        #endregion
    }
    public static class shell32
    {
        #region Icon
        /* Creates a duplicate of a specified icon. */
        [DllImport("Shell32.dll", SetLastError = true)]
        public static extern SafeIconHandle DuplicateIcon(
            HINSTANCE hInst, SafeIconHandle hIcon);

        /* Retrieves a handle to an icon from the specified executable file,
            DLL, or icon file. */
        /* IntPtr.Zero, location, index */
        [DllImport("Shell32.dll", SetLastError = true,
            EntryPoint = "ExtractIconW", CharSet = CharSet.Unicode)]
        public static extern SafeIconHandle ExtractIcon(
            HINSTANCE hInst, LPCTSTR lpszExeFileName, UINT nIconIndex);

        /* Creates an array of handles to large or small icons extracted 
            from the specified executable file, DLL, or icon file.
            If this value is –1 and phiconLarge and phiconSmall are both NULL,
            the function returns the total number of icons in the specified file.
            If the file is an executable file or DLL, 
            the return value is the number of RT_GROUP_ICON resources.
            If the file is an .ico file, the return value is 1. */
        [DllImport("Shell32.dll", SetLastError = true,
            EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode)]
        public static extern UINT ExtractIconEx(
            LPCTSTR lpszFile, int nIconIndex,
            SafeIconHandle[] phiconLarge,
            SafeIconHandle[] phiconSmall,
            UINT nIcons);

        /* Retrieves a handle to an indexed icon found in a file or an icon found in an associated executable file. */
        /* IntPtr.Zero, location, index */
        [DllImport("Shell32.dll", SetLastError = true,
            EntryPoint = "ExtractAssociatedIconW", CharSet = CharSet.Unicode)]
        public static extern SafeIconHandle ExtractAssociatedIcon(
            HINSTANCE hInst, string lpIconPath, ref WORD lpiIcon);

        /* Retrieves a handle to an indexed icon found in a file or an icon found in an associated executable file. */
        /* IntPtr.Zero, location, index, id */
        [DllImport("Shell32.dll", SetLastError = true,
            EntryPoint = "ExtractAssociatedIconExW", CharSet = CharSet.Unicode)]
        public static extern SafeIconHandle ExtractAssociatedIconEx(
            HINSTANCE hInst, string lpIconPath, ref WORD lpiIconIndex, ref WORD lpiIconId);
        #endregion

        #region File Info
        /* Retrieves information about an object in the file system, such as a file, folder, directory, or drive root. */
        [DllImport("shell32", EntryPoint = "SHGetFileInfoW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern DWORD_PTR SHGetFileInfo(
            LPCTSTR pszPath,
            FileAttributes dwFileAttributes,
            ref SHFILEINFO psfi,
            UINT cbFileInfo,
            SHGFI uFlags); 
        #endregion

        #region Process
        [DllImport("shell32.dll", SetLastError = true,
            EntryPoint = "ShellExecuteW", CharSet = CharSet.Unicode)]
        public static extern HINSTANCE ShellExecute(
            SafeWindowHandle hwnd,
            string lpOperation,     // edit, explore, find, open, print, NULL { or 'runas' for requesting elevation [UAC dialog] }
            string lpFile,          // file or object on which to execute the specified verb
            string lpParameters,    // arameters to be passed to the application.
            string lpDirectory,     // specifies the default (working) directory for the action.
            ShowWindowCommand nShowCmd);

        [DllImport("shell32.dll", SetLastError = true,
            EntryPoint = "ShellExecuteExW", CharSet = CharSet.Unicode)]
        public static extern BOOL ShellExecuteEx(
            ShellExecuteInfo info);

        /* lpCmdLine from GetCommandLine */
        [DllImport("Shell32.dll", SetLastError = true,
            EntryPoint = "CommandLineToArgvW", CharSet = CharSet.Unicode)]
        public unsafe static extern IntPtr* CommandLineToArgv(
            string lpCmdLine,
            out int pNumArgs);
        #endregion
    }
    public static class userenv
    {
        #region Environment
        // Environment Variables
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms682653(v=vs.85).aspx
        // GetEnvironmentStrings() == NtQueryInformationProcess() -> PROCESS_BASIC_INFORMATION -> PEB -> RTL_USER_PROCESS_PARAMETERS -> Environment

        /* Retrieves the environment variables for the specified user */
        [DllImport("Userenv.dll", SetLastError = true)]
        public static extern bool CreateEnvironmentBlock(out Struct.Environment lpEnvironment, SafeTokenHandle hToken, BOOL bInherit);

        /* Frees environment variables created by the CreateEnvironmentBlock function. */
        [DllImport("Userenv.dll", SetLastError = true)]
        public static extern bool DestroyEnvironmentBlock(Struct.Environment lpEnvironment);
        #endregion

        #region Profile
        // NetUserAdd >> LogonUser >> [Load\UnLoad]UserProfile
        // How To Programmatically Cause the Creation of a User's Profile
        // http://support.microsoft.com/kb/196070

        //
        // UserProfile
        //

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "CreateUserProfileExW", CharSet = CharSet.Unicode)]
        public static extern BOOL CreateUserProfileEx(
            SafeSidHandle pSid,
            LPCTSTR lpUserName,
            [Optional] LPCTSTR lpUserHive,
            StringBuilder lpProfileDir,
            DWORD dwDirSize,
            BOOL bWin9XUpg);

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "LoadUserProfileW", CharSet = CharSet.Unicode)]
        public static extern BOOL LoadUserProfile(
            SafeTokenHandle hToken,
            ref PROFILEINFO lpProfileInfo);

        [DllImport("userenv.dll", SetLastError = true)]
        public static extern BOOL UnloadUserProfile(
            SafeTokenHandle hToken,
            SafeRegistryHandle hProfile);

        //
        // Profile
        //

        [DllImport("userenv.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error CreateProfile(
            string pszUserSid, // SafeSidHandle.Tostring()
            string pszUserName,
            StringBuilder pszProfilePath,
            DWORD cchProfilePath);

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "DeleteProfileW", CharSet = CharSet.Unicode)]
        public static extern Win32Error DeleteProfile(
            LPCTSTR lpSidString,
            LPCTSTR lpProfilePath,
            LPCTSTR lpComputerName);

        //
        // AppContainerProfile
        //

        [DllImport("userenv.dll", SetLastError = true)]
        public unsafe static extern Win32Error CreateAppContainerProfile(
            string pszAppContainerName, string pszDisplayName, string pszDescription,
            SID_AND_ATTRIBUTES* pCapabilities, DWORD dwCapabilityCount,
            [Out] SafeSidHandle ppSidAppContainerSid);

        [DllImport("userenv.dll", SetLastError = true)]
        public static extern Win32Error DeleteAppContainerProfile(
            string pszAppContainerName);

        //
        // Get
        //

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "GetProfilesDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetProfilesDirectory(
            StringBuilder lpProfileDir,
            ref DWORD lpcchSize);

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "GetUserProfileDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetUserProfileDirectory(
            SafeTokenHandle hToken,
            StringBuilder lpProfileDir,
            ref DWORD lpcchSize);

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "GetDefaultUserProfileDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetDefaultUserProfileDirectory(
            StringBuilder lpProfileDir,
            ref DWORD lpcchSize);

        [DllImport("userenv.dll", SetLastError = true,
            EntryPoint = "GetAllUsersProfileDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetAllUsersProfileDirectory(
            StringBuilder lpProfileDir,
            ref DWORD lpcchSize);

        [DllImport("userenv.dll", SetLastError = true)]
        public static extern BOOL GetProfileType(
            out ProfileType pdwFlags);
        #endregion
    }
    public static class kernel32
    {
        ///////////
        /// ??? ///
        ///////////

        #region Event
        /* Creates or opens a named or unnamed event object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateEventW", CharSet = CharSet.Unicode)]
        public static extern SafeEventHandle CreateEvent(
            IntPtr lpEventAttributes,
            BOOL bManualReset,
            BOOL bInitialState,
            LPCTSTR lpName);

        /* Creates or opens a named or unnamed event object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateEventExW", CharSet = CharSet.Unicode)]
        public static extern SafeEventHandle CreateEventEx(
            IntPtr lpEventAttributes,
            LPCTSTR lpName,
            CreateEventFlags dwFlags,
            ACCESS_MASK dwDesiredAccess);

        /* Opens an existing named event object. */
        [DllImport("kernel32.dll", SetLastError = true,
             EntryPoint = "OpenEventW", CharSet = CharSet.Unicode)]
        public static extern SafeEventHandle OpenEvent(
            ACCESS_MASK dwDesiredAccess,
            BOOL bInheritHandle,
            LPCTSTR lpName);

        /* Sets the specified event object to the signaled state. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetEvent(
            SafeEventHandle hEvent);

        /* Sets the specified event object to the nonsignaled state. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ResetEvent(
            SafeEventHandle hEvent); 
        #endregion

        #region Mutex
        /* Opens an existing named mutex object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "OpenMutexW", CharSet = CharSet.Unicode)]
        public static extern SafeMutexHandle OpenMutex(
            ACCESS_MASK dwDesiredAccess,
            BOOL bInheritHandle,
            LPCTSTR lpName);

        /* Creates or opens a named or unnamed mutex object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateMutexW", CharSet = CharSet.Unicode)]
        public static extern SafeMutexHandle CreateMutex(
            IntPtr lpMutexAttributes,
            BOOL bInitialOwner,
            LPCTSTR lpName);

        /* Creates or opens a named or unnamed mutex object and returns a handle to the object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateMutexExW", CharSet = CharSet.Unicode)]
        public static extern SafeMutexHandle CreateMutexEx(
            IntPtr lpMutexAttributes,
            LPCTSTR lpName,
            DWORD reserved,
            ACCESS_MASK dwDesiredAccess);

        /* Releases ownership of the specified mutex object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ReleaseMutex(
            SafeMutexHandle hMutex);
        #endregion

        #region Semaphore
        /* Opens an existing named semaphore object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "OpenSemaphoreW", CharSet = CharSet.Unicode)]
        public static extern SafeSemaphoreHandle OpenSemaphore(
            ACCESS_MASK dwDesiredAccess,
            BOOL bInheritHandle,
            LPCTSTR lpName);

        /* Creates or opens a named or unnamed semaphore object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateSemaphoreW", CharSet = CharSet.Unicode)]
        public static extern SafeSemaphoreHandle CreateSemaphore(
            IntPtr lpMutexAttributes,
            LONG lInitialCount,
            LONG lMaximumCount,
            LPCTSTR lpName);

        /* Creates or opens a named or unnamed semaphore object and returns a handle to the object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateSemaphoreExW", CharSet = CharSet.Unicode)]
        public static extern SafeSemaphoreHandle CreateSemaphoreEx(
            IntPtr lpMutexAttributes,
            LONG lInitialCount,
            LONG lMaximumCount,
            LPCTSTR lpName,
            DWORD reserved,
            ACCESS_MASK dwDesiredAccess);

        /* Increases the count of the specified semaphore object by a specified amount. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ReleaseSemaphore(
            SafeSemaphoreHandle hMutex,
            LONG lReleaseCount,
            out LONG lpPreviousCount);
        #endregion

        #region Critical Section

        // Critical Section Objects
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms682530(v=vs.85).aspx

        // Safe Thread Synchronization
        // http://msdn.microsoft.com/en-us/magazine/cc188793.aspx

        // Equls to Monitor.Lock >> Monitor.??? 
        // and Lock(object) ......

        /*
            * A critical section object provides synchronization similar
            * to that provided by a mutex object, 
            * except that a critical section can be used 
            * only by the threads of a single process. 
            * 
            * When a thread owns a critical section,
            * it can make additional calls to EnterCriticalSection or TryEnterCriticalSection,
            * without blocking its execution.
            * 
            * A thread uses the InitializeCriticalSectionAndSpinCount or SetCriticalSectionSpinCount function
            * to specify a spin count for the critical section object.
            * Spinning means that when a thread tries to acquire a critical section that is locked,
            * the thread enters a loop,
            * checks to see if the lock is released,
            * and if the lock is not released,
            * the thread goes to sleep.
            */

        // Initialize //

        /* Initializes a critical section object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void InitializeCriticalSection(
            out SafeCriticalsection lpCriticalSection);

        /*
            * Initializes a critical section object with a spin count and optional flags.
            * Flags :: 0 OR 0x01000000 [RTL_CRITICAL_SECTION_FLAG_NO_DEBUG_INFO]
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool InitializeCriticalSectionEx(
            out SafeCriticalsection lpCriticalSection,
            DWORD dwSpinCount,
            DWORD flags);

        /* Initializes a critical section object and sets the spin count for the critical section. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool InitializeCriticalSectionAndSpinCount(
            out SafeCriticalsection lpCriticalSection,
            DWORD dwSpinCount);

        // Enter -> Leave //

        /* Waits for ownership of the specified critical section object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void EnterCriticalSection(
            ref SafeCriticalsection lpCriticalSection);

        /* Attempts to enter a critical section without blocking. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool TryEnterCriticalSection(
            ref SafeCriticalsection lpCriticalSection);

        /* Releases ownership of the specified critical section object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void LeaveCriticalSection(
            ref SafeCriticalsection lpCriticalSection);

        /* Releases all resources used by an unowned critical section object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void DeleteCriticalSection(
            ref SafeCriticalsection lpCriticalSection);

        // Set //

        /* Sets the spin count for the specified critical section. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD SetCriticalSectionSpinCount(
            ref SafeCriticalsection lpCriticalSection,
            DWORD dwSpinCount);

        #endregion

        ///////////
        /// ??? ///
        ///////////

        #region Snapshot

        /// <summary>
        /// Takes a snapshot of the specified processes, as well as the heaps, modules, and threads used by these processes.
        /// </summary>
        /// <param name="dwFlags">Flags</param>
        /// <param name="th32ProcessID">The process identifier of the process to be included in the snapshot. This parameter can be zero to indicate the current process.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeSnapshotHandle CreateToolhelp32Snapshot(
            SnapshotFlags dwFlags, UInt32 th32ProcessID);

        #endregion

        #region Process

        //
        // Base
        //

        /// <summary>
        /// Opens an existing local process object.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeProcessHandle OpenProcess(
            ProcessAccessFlags dwDesiredAccess,
            bool bInheritHandle,
            uint dwProcessId);

        /// <summary>
        /// Create new Process
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateProcessW", CharSet = CharSet.Unicode)]
        public static extern bool CreateProcess(
            string lpApplicationName,
            string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            CreationFlags dwCreationFlags,
            Struct.Environment lpEnvironment,
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// Exit Process
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void ExitProcess(
            uint uExitCode);

        /// <summary>
        /// Terminate Process
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool TerminateProcess(
            SafeProcessHandle hProcess, 
            uint uExitCode);

        /// <summary>
        /// Retrieves the full name of the executable image for the specified process.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "QueryFullProcessImageNameW", CharSet = CharSet.Unicode)]
        public static extern bool QueryFullProcessImageName(
            SafeProcessHandle hProcess,
            uint dwFlags,
            StringBuilder lpExeName,
            ref uint lpdwSize);

        //
        // Get
        //

        /// <summary>
        /// use CommandLineToArgv to parse it to an array
        /// </summary>
        [DllImport("Kernel32.dll", SetLastError = true,
            EntryPoint = "GetCommandLineW", CharSet = CharSet.Unicode)]
        public static extern string GetCommandLine();

        /// <summary>
        /// Retrieves the process identifier of the specified process.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetProcessId(
            SafeProcessHandle process);

        /// <summary>
        /// Retrieves the process identifier of the calling process.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetCurrentProcessId();

        /// <summary>
        /// Retrieves a pseudo handle for the current process.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeProcessHandle GetCurrentProcess();

        /// <summary>
        /// Retrieves the process identifier of the process 
        /// associated with the specified thread.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetProcessIdOfThread(
            SafeThreadHandle thread);

        /// <summary>
        /// Retrieves the contents of the STARTUPINFO structure that was specified 
        /// when the calling process was created.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetStartupInfoW", CharSet = CharSet.Unicode)]
        public static extern void GetStartupInfo(
            out STARTUPINFO lpStartupInfo);

        /// <summary>
        /// get Exit code for process
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetExitCodeProcess(
            SafeProcessHandle hProcess,
            out uint lpExitCode);

        /// <summary>
        /// get Priority Class
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetPriorityClass(
            SafeProcessHandle hProcess);

        /// <summary>
        /// get Affinity Mask
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetProcessAffinityMask(
            SafeProcessHandle hProcess,
            out IntPtr lpProcessAffinityMask,
            out IntPtr lpSystemAffinityMask);

        /// <summary>
        /// get Priority Boost
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetProcessPriorityBoost(
            SafeProcessHandle hProcess,
            out bool pDisablePriorityBoost);

        /// <summary>
        /// get WorkingSet Size
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetProcessWorkingSetSize(
            SafeProcessHandle hProcess,
            out SIZE_T lpMinimumWorkingSetSize,
            out SIZE_T lpMaximumWorkingSetSize);

        /// <summary>
        /// get WorkingSet Size
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetProcessWorkingSetSizeEx(
            SafeProcessHandle hProcess,
            out SIZE_T lpMinimumWorkingSetSize,
            out SIZE_T lpMaximumWorkingSetSize,
            out WorkingSizeFlags flags);

        /// <summary>
        /// Get Process Times
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetProcessTimes(
            SafeProcessHandle hProcess,
            out Filetime lpCreationTime,
            out Filetime lpExitTime,
            out Filetime lpKernelTime,
            out Filetime lpUserTime);

        //
        // Set
        //

        /// <summary>
        /// Set Priority Class
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetPriorityClass(
            SafeProcessHandle hProcess,
            DWORD dwPriorityClass);

        /// <summary>
        /// Set Affinity Mask
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetProcessAffinityMask(
            SafeProcessHandle hProcess,
            DWORD_PTR dwProcessAffinityMask);

        /// <summary>
        /// Set Priority Boost
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetProcessPriorityBoost(
            SafeProcessHandle hProcess,
            BOOL disablePriorityBoost);

        /// <summary>
        /// Set WorkingSet Size
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetProcessWorkingSetSize(
            SafeProcessHandle hProcess,
            SIZE_T dwMinimumWorkingSetSize,
            SIZE_T dwMaximumWorkingSetSize);

        /// <summary>
        /// Set WorkingSet Size
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetProcessWorkingSetSizeEx(
            SafeProcessHandle hProcess,
            SIZE_T dwMinimumWorkingSetSize,
            SIZE_T dwMaximumWorkingSetSize,
            WorkingSizeFlags flags);

        //
        // Is ???
        //

        /// <summary>
        /// Determines whether the calling process is being debugged by a user-mode debugger.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool IsDebuggerPresent();

        /// <summary>
        /// Determines whether the specified process is running under WOW64.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL IsWow64Process(
            SafeProcessHandle hProcess, out BOOL wow64Process);

        //
        // Enum
        //

        /// <summary>
        /// first instance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <param name="lppe"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Process32First(
            SafeSnapshotHandle hSnapshot,
            ref PROCESSENTRY32 lppe);

        /// <summary>
        /// next instance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <param name="lppe"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Process32Next(
            SafeSnapshotHandle hSnapshot,
            ref PROCESSENTRY32 lppe);

        #endregion

        #region Thread

        //
        // Base
        //

        /// <summary>
        /// get handle for current thread
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadHandle GetCurrentThread();

        /// <summary>
        /// Opens an existing thread object.
        /// </summary>
        /// <param name="dwDesiredAccess">Desired Access</param>
        /// <param name="bInheritHandle">inherit this handle</param>
        /// <param name="dwThreadId">Thread Id</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadHandle OpenThread(
            ThreadAccess dwDesiredAccess,
            bool bInheritHandle,
            uint dwThreadId);

        /// <summary>
        /// Create new Thread
        /// </summary>
        /// <param name="securityAttributes">ref to Security_Attributes structure</param>
        /// <param name="stackSize">0</param>
        /// <param name="startFunction">pointer to function</param>
        /// <param name="threadParameter">A pointer to a variable to be passed to the thread. Default is IntPtr.Zero</param>
        /// <param name="creationFlags">The flags that control the creation of the thread.</param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadHandle CreateThread(
            IntPtr securityAttributes, 
            uint stackSize,
            ThreadProc startFunction,
            IntPtr threadParameter,
            CreateThreadFlags creationFlags,
            out uint threadId);

        /// <summary>
        /// Create Remote Thread
        /// </summary>
        /// <param name="hProcess">process Handle</param>
        /// <param name="lpThreadAttributes">ref to Security_Attributes structure</param>
        /// <param name="dwStackSize">0</param>
        /// <param name="lpStartAddress">Address from GetProcAddress function</param>
        /// <param name="lpParameter"></param>
        /// <param name="dwCreationFlags"></param>
        /// <param name="lpThreadId"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadHandle CreateRemoteThread(
            SafeProcessHandle hProcess,
            IntPtr lpThreadAttributes,
            uint dwStackSize,
            IntPtr lpStartAddress,
            IntPtr lpParameter,
            CreateThreadFlags dwCreationFlags,
            out uint lpThreadId);

        /// <summary>
        /// Ends the calling thread.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void ExitThread(
            uint dwExitCode);

        /// <summary>
        /// Retrieves the termination status of the specified thread.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetExitCodeThread(
            SafeThreadHandle hThread,
            out uint lpExitCode);

        /// <summary>
        /// Terminate Thread
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool TerminateThread(
            SafeThreadHandle hThread,
            uint dwExitCode);

        /// <summary>
        /// Suspend Thread
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SuspendThread(
            SafeThreadHandle hThread);

        /// <summary>
        /// Suspend Thread [X64 version]
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint Wow64SuspendThread(
            SafeThreadHandle hThread);

        /// <summary>
        /// Resume Thread
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint ResumeThread(
            SafeThreadHandle hThread);

        /// <summary>
        /// sleep Current thread in x Milliseconds
        /// </summary>
        /// <param name="dwMilliseconds"></param>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void Sleep(
            uint dwMilliseconds);

        /// <summary>
        /// Suspends the current thread until the specified condition is met. 
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SleepEx(
            uint dwMilliseconds,
            bool bAlertable);

        //
        // Get
        //

        /// <summary>
        /// Retrieves the context of the specified thread.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetThreadContext(
            SafeThreadHandle hThread,
            ref CONTEXT lpContext);

        /// <summary>
        /// Retrieves the context of the specified thread. [X64 version]
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64GetThreadContext(
            SafeThreadHandle hThread,
            ref WOW64_CONTEXT lpContext);

        // <summary>
        /// Retrieves the priority value for the specified thread.
        /// This value, together with the priority class of the thread's process, 
        /// determines the thread's base-priority level.
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetThreadPriority(
            SafeThreadHandle hThread);

        // <summary>
        /// Retrieves timing information for the specified thread.
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetThreadTimes(
            SafeThreadHandle hThread,
            out Filetime lpCreationTime,
            out Filetime lpExitTime,
            out Filetime lpKernelTime,
            out Filetime lpUserTime);

        /// <summary>
        /// Get Ideal Processor
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetThreadIdealProcessorEx(
            SafeThreadHandle hThread,
            out PROCESSOR_NUMBER lpPreviousIdealProcessor);

        /// <summary>
        /// thread identifier of the specified thread.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetThreadId(
            SafeThreadHandle hThread);

        /// <summary>
        /// thread identifier of the specified thread.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetCurrentThreadId();

        //
        // Set
        //

        /// <summary>
        /// Sets the context for the specified thread.
        /// </summary>
        /// <param name="hThread">A handle to the thread whose context is to be set.</param>
        /// <param name="lpContext">A pointer to a CONTEXT structure that receives the appropriate context of the specified thread.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetThreadContext(
            SafeThreadHandle hThread,
            ref CONTEXT lpContext);

        /// <summary>
        /// Sets the context for the specified thread. [X64 version]
        /// </summary>
        /// <param name="hThread">A handle to the thread whose context is to be set.</param>
        /// <param name="lpContext">A pointer to a CONTEXT structure that receives the appropriate context of the specified thread.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64SetThreadContext(
            SafeThreadHandle hThread,
            ref WOW64_CONTEXT lpContext);

        /// <summary>
        /// Enables an application to inform the system that it is in use,
        /// thereby preventing the system from entering sleep or
        /// turning off the display while the application is running.
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern ExecutionState SetThreadExecutionState(
            ExecutionState esFlags);

        /// <summary>
        /// Set Affinity Mask
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD_PTR SetThreadAffinityMask(
            SafeThreadHandle hThread,
            DWORD_PTR dwThreadAffinityMask);

        /// <summary>
        /// Set Ideal Processor
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD SetThreadIdealProcessor(
            SafeThreadHandle hThread,
            DWORD dwIdealProcessor);

        /// <summary>
        /// Set Ideal Processor
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetThreadIdealProcessorEx(
            SafeThreadHandle hThread,
            ref PROCESSOR_NUMBER lpIdealProcessor,
            out PROCESSOR_NUMBER lpPreviousIdealProcessor);

        //
        // Enum
        //

        /// <summary>
        /// first instance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <param name="lpte"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Thread32First(
            SafeSnapshotHandle hSnapshot,
            ref THREADENTRY32 lpte);

        /// <summary>
        /// next insatance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <param name="lpte"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Thread32Next(
            SafeSnapshotHandle hSnapshot,
            ref THREADENTRY32 lpte);

        /// <summary>
        /// Disables the DLL_THREAD_ATTACH and DLL_THREAD_DETACH notifications for the specified dynamic-link library (DLL).
        /// This can reduce the size of the working set for some applications.
        /// If the function succeeds, the return value is nonzero.
        /// </summary>
        /// <param name="hModule"></param>
        /// <returns>A handle to the DLL module</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool DisableThreadLibraryCalls(
            IntPtr hModule);
        #endregion

        #region Module

        //
        // Enum
        //

        /// <summary>
        /// first instance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Module32First(
            SafeSnapshotHandle hSnapshot,
            ref MODULEENTRY32 lpme);

        /// <summary>
        /// next insatance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Module32Next(
            SafeSnapshotHandle hSnapshot,
            ref MODULEENTRY32 lpme);
        #endregion

        #region Heap
            
        //
        // Enum
        //

        /// <summary>
        /// first instance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL Heap32First(
            SafeSnapshotHandle hSnapshot,
            ref HEAPLIST32 lphl);

        /// <summary>
        /// next insatance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL Heap32Next(
            SafeSnapshotHandle hSnapshot,
            ref HEAPLIST32 lphl);

        /// <summary>
        /// first instance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL Heap32ListFirst(
            SafeSnapshotHandle hSnapshot,
            ref HEAPLIST32 lphl);

        /// <summary>
        /// next insatance
        /// </summary>
        /// <param name="hSnapshot">handle from CreateToolhelp32Snapshot</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL Heap32ListNext(
            SafeSnapshotHandle hSnapshot,
            ref HEAPLIST32 lphl);
        #endregion

        // More Stuff

        // Window
        // EnumWindows >> GetWindowThreadProcessId

        // Handles
        // NtQuerySystemInformation(System_Information_Class.SystemHandleInformation, ....)

        // Information
        // NtQueryInformationProcess(process_information_class.???, ....)

        // Active Connection
        // GetExtendedUdpTable
        // GetExtendedTcpTable

        // privileges, Sid, More
        // OpenProcessToken >> GetTokenInformation,

        // Memory Read ^&& Write
        // VirtualQueryEx

        // Security^^Descriptor
        // GetKernelObjectSecurity

        ///////////
        /// ??? ///
        ///////////

        // Invoke a callback function 
        // at a due time.

        #region thread pool :: Timer

        //
        // Original API
        //

        /* Creates a queue for timers.
            Timer-queue timers are lightweight objects that enable you to specify
            a callback function to be called at a specified time. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeTimerQueueHandle CreateTimerQueue();

        /* Creates a timer-queue timer.
            This timer expires at the specified due time, then after every specified period. 
            When the timer expires, the callback function is called. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL CreateTimerQueueTimer(
            out SafeTimerQueueHandle phNewTimer,
            [Optional] SafeTimerQueueHandle timerQueue,
            WaitOrTimerCallback callback,
            [Optional] PVOID parameter,
            DWORD dueTime, DWORD period,
            WT_CREATE flags);

        /* Deletes a timer queue.
            Any pending timers in the queue are canceled and deleted */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL DeleteTimerQueue(
            SafeTimerQueueHandle timerQueue);

        /* Deletes a timer queue.
            Any pending timers in the queue are canceled and deleted */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL DeleteTimerQueueEx(
            SafeTimerQueueHandle timerQueue,
            [Optional] SafeEventHandle completionEvent);

        /* Removes a timer from the timer queue and optionally waits
            for currently running timer callback functions to complete before deleting the timer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL DeleteTimerQueueTimer(
            [Optional] SafeTimerQueueHandle timerQueue,
            SafeTimerQueueHandle timer,
            [Optional] SafeEventHandle completionEvent);

        /* Updates a timer-queue timer that was created by the CreateTimerQueueTimer function. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ChangeTimerQueueTimer(
            /* A handle to the timer queue. This handle is returned by the CreateTimerQueue function */
            [Optional] SafeTimerQueueHandle timerQueue,
            /* A handle to the timer-queue timer. This handle is returned by the CreateTimerQueueTimer function. */
            SafeTimerQueueHandle timer,
            ULONG dueTime, ULONG period);

        //
        // Current API
        //

        /* Creates a new timer object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadpoolTimer CreateThreadpoolTimer(
            TimerCallback pfnti,
            PVOID pv,
            SafeThreadpoolEnvironment pcbe);

        /*
            * Sets the timer object. 
            * A worker thread calls the timer object's callback after the specified timeout expires.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void SetThreadpoolTimer(
            SafeThreadpoolTimer pti,
            ref Filetime pftDueTime,
            DWORD msPeriod,
            DWORD msWindowLength);

        /* Determines whether the specified timer object is currently set. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL IsThreadpoolTimerSet(
            SafeThreadpoolTimer pti);

        /* Releases the specified timer object */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern VOID CloseThreadpoolTimer(
            SafeThreadpoolTimer pti);

        /*
            * Waits for outstanding timer callbacks to complete 
            * and optionally cancels pending callbacks 
            * that have not yet started to execute.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern VOID WaitForThreadpoolTimerCallbacks(
            SafeThreadpoolTimer pti,
            BOOL fCancelPendingCallbacks);

        #endregion

        // Invoke a callback function 
        // when a kernel object is signaled or the wait times out.

        #region thread pool :: Work

        //
        // Original API
        //

        /* Creates a new work object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL QueueUserWorkItem(
            LpthreadStartRoutine function,
            IntPtr context,
            ExecuteFlags flags);

        //
        // Current API
        //

        /* Queues a work item to a worker thread in the thread pool. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadpoolWork CreateThreadpoolWork(
            WorkCallback pfnwk, PVOID pv,
            SafeThreadpoolEnvironment pcbe);

        /* 
            * Posts a work object to the thread pool. 
            * A worker thread calls the work object's callback function. 
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void SubmitThreadpoolWork(
            SafeThreadpoolWork pwk);

        /* 
            * Requests that a thread pool worker thread 
            * call the specified callback function.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool TrySubmitThreadpoolCallback(
            SimpleCallback pfns, PVOID pv,
            SafeThreadpoolEnvironment pcbe);

        /* 
            * Waits for outstanding work callbacks to complete
            * and optionally cancels pending callbacks 
            * that have not yet started to execute.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void WaitForThreadpoolWorkCallbacks(
            SafeThreadpoolWork pwk,
            BOOL fCancelPendingCallbacks);

        /* Releases the specified work object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CloseThreadpoolWork(
            SafeThreadpoolWork pwk);
        #endregion

        // Invoke a callback function
        // when a kernel object is signaled or the wait times out.

        #region thread pool :: Synch

        //
        // Original API
        //

        /*
            * Directs a wait thread in the thread pool to wait on the object.
            * The wait thread queues the specified callback function 
            * to the thread pool when one of the following occurs:
            * The specified object is in the signaled state.
            * The time-out interval elapses.

            * its use same Flags as QueueUserWorkItem funtion
            * but little diffrent -- more parameters

            * hObject can be one of this following objects
            * Change notification
            * Console input
            * Event [must reset Before]
            * Memory resource notification
            * Mutex
            * Process
            * Semaphore
            * Thread
            * Waitable timer
            */

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL RegisterWaitForSingleObject(
            out SafeWaitHandle phNewWaitObject,
            HANDLE hObject,
            WaitOrTimerCallback callback,
            PVOID context,
            TimeOut dwMilliseconds,
            ExecuteFlags dwFlags);

        /* 
            * Cancels a registered wait operation
            * issued by the RegisterWaitForSingleObject function.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL UnregisterWaitEx(
            SafeWaitHandle waitHandle,
            SafeEventHandle completionEvent);

        //
        // Current API
        //

        /* Creates a new wait object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadpoolWait CreateThreadpoolWait(
            WaitCallback pfnwa,
            PVOID pv,
            SafeThreadpoolEnvironment pcbe);

        /* 
            * Sets the wait object.
            * A worker thread calls the wait object's callback function 
            * after the handle becomes signaled or after the specified timeout expires.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void SetThreadpoolWait(
            SafeThreadpoolWait pwa,
            HANDLE h,
            IntPtr pftTimeout);

        /* Releases the specified wait object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CloseThreadpoolWait(
            SafeThreadpoolWait pwa);

        /*
            * Waits for outstanding wait callbacks to complete
            * and optionally cancels pending callbacks
            * that have not yet started to execute. 
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void WaitForThreadpoolWaitCallbacks(
            SafeThreadpoolWait pwa,
            BOOL fCancelPendingCallbacks);

        #endregion

        // Invoke a callback function
        // when an asynchronous I/O completes.

        #region thread pool :: I/O

        //
        // Original API
        //

        /*
            * Associates the I/O completion port owned by the thread pool
            * with the specified file handle
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL BindIoCompletionCallback(
            SafeFileHandle fileHandle,
            FileCompletionDelegate function,
            ULONG flags);

        //
        // Current API
        //

        /* Creates a new I/O completion object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeThreadpoolIo CreateThreadpoolIo(
            SafeFileHandle fl,
            IoCompletionCallback pfnio,
            PVOID pv,
            SafeThreadpoolEnvironment pcbe);

        /* 
            * Notifies the thread pool that I/O operations
            * may possibly begin for the specified I/O completion object
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void StartThreadpoolIo(
            SafeThreadpoolIo pio);

        /* Cancels the notification from the StartThreadpoolIo function. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CancelThreadpoolIo(
            SafeThreadpoolIo pio);

        /* Releases the specified I/O completion object. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CloseThreadpoolIo(
            SafeThreadpoolIo pio);

        /* 
            * Waits for outstanding I/O completion callbacks to complete 
            * and optionally cancels pending callbacks
            * that have not yet started to execute.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void WaitForThreadpoolIoCallbacks(
            SafeThreadpoolIo pio,
            BOOL fCancelPendingCallbacks);

        #endregion

        // Pool of threads used to execute callbacks.

        #region thread pool :: Pool

        //
        // Original API
        //

        //
        // Current API
        //

        /*
            * To use the pool, 
            * you must associate the pool with a callback environment.
            * To create the callback environment, 
            * call InitializeThreadpoolEnvironment.
            * 
            * Then,
            * call SetThreadpoolCallbackPool to associate the pool 
            * with the callback environment.
            */

        /* Allocates a new pool of threads to execute callbacks. */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern SafeThreadpool CreateThreadpool(
            PVOID reserved);

        /* Closes the specified thread pool. */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void CloseThreadpool(
            SafeThreadpool ptpp);

        /* 
            * Sets the minimum number of threads 
            * that the specified thread pool 
            * must make available to process callbacks 
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL SetThreadpoolThreadMinimum(
            SafeThreadpool ptpp,
            DWORD cthrdMic);

        /* 
            * Sets the maximum number of threads 
            * that the specified thread pool 
            * can allocate to process callbacks.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL SetThreadpoolThreadMaximum(
            SafeThreadpool ptpp,
            DWORD cthrdMic);

        #endregion

        #region thread pool :: Clean-up group

        //
        // Original API
        //

        //
        // Current API
        //

        /*
            * Creates a cleanup group that applications can use
            * to track one or more thread pool callbacks.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern SafeThreadpoolCleanUpGroup CreateThreadpoolCleanupGroup();

        /* Closes the specified cleanup group. */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void CloseThreadpoolCleanupGroup(
            SafeThreadpoolCleanUpGroup ptpcg);

        /* 
            * Releases the members of the specified cleanup group,
            * waits for all callback functions to complete,
            * and optionally cancels any outstanding callback functions.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void CloseThreadpoolCleanupGroupMembers(
            SafeThreadpoolCleanUpGroup ptpcg,
            BOOL fCancelPendingCallbacks,
            PVOID pvCleanupContext);

        #endregion

        #region thread pool :: Callback Instance

        //
        // Original API
        //

        //
        // Current API
        //

        /* Indicates that the callback may not return quickly. */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL CallbackMayRunLong(
            SafeThreadpoolCallbackInstance pci);

        /*
            * Specifies the event that the thread pool will set
            * when the current callback completes. 
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void SetEventWhenCallbackReturns(
            SafeThreadpoolCallbackInstance pci,
            SafeEventHandle evt);

        /*
            * Removes the association between the currently executing callback function 
            * and the object that initiated the callback. 
            * The current thread will no longer count as executing a callback
            * on behalf of the object.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void DisassociateCurrentThreadFromCallback(
            SafeThreadpoolCallbackInstance pci);

        /*
            * Specifies the DLL that the thread pool will unload
            * when the current callback completes.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void LeaveCriticalSectionWhenCallbackReturns(
            SafeThreadpoolCallbackInstance pci,
            SafeCriticalsection pcs);

        /*
            * Specifies the semaphore that the thread pool will release
            * when the current callback completes.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void FreeLibraryWhenCallbackReturns(
            SafeThreadpoolCallbackInstance pci,
            HMODULE mod);

        /*
            * Specifies the semaphore that the thread pool will release
            * when the current callback completes.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void ReleaseSemaphoreWhenCallbackReturns(
            SafeThreadpoolCallbackInstance pci,
            SafeSemaphoreHandle sem,
            DWORD crel);

        /*
            * Specifies the mutex that the thread pool will release
            * when the current callback completes.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern void ReleaseMutexWhenCallbackReturns(
            SafeThreadpoolCallbackInstance pci,
            SafeMutexHandle mut);

        #endregion

        #region thread pool :: Callback Environment
        // Inline Function ....
        // so create one by call
        // new SafeThreadpoolEnvironment()

        #endregion

        ///////////
        /// ??? ///
        ///////////

        #region Pipe [Interprocess Communications]

        /*
         * Anonymous Pipe
         */

        /*
         * Creates an anonymous pipe,
         * and returns handles to the read and write ends of the pipe.
         * 
         * http://edn.embarcadero.com/article/10387
         * Using anonymous pipes to redirect standard input/output of a child process. 
         * 
         * http://support.microsoft.com/kb/190351
         * How to spawn console processes with redirected standard handles
         * 
         * http://msdn.microsoft.com/en-us/library/windows/desktop/ms682499(v=vs.85).aspx
         * Creating a Child Process with Redirected Input and Output
         * 
         * Guide :: how to use with Create Process ....
         * CreatePipe(out sb.hstdIn, out stdIn)     >> stdIn.Write
         * CreatePipe(out stdOut, out sb.hstdOut)   >> stdOut.Read
         * CreatePipe(out stdErr, out sb.hstdErr)   >> stdErr.Read
         */

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL CreatePipe(
            out SafeConsoleHandle hReadPipe,
            out SafeConsoleHandle hWritePipe,
            IntPtr lpPipeAttributes,
            DWORD nSize);

        /*
         * Named Pipes :: Client
         */

        /*
            * Waits until either a time-out interval elapses or
            * an instance of the specified named pipe is available for connection
            * (that is, the pipe's server process has a pending ConnectNamedPipe operation on the pipe).
            */
        [DllImport("Kernel32.dll", SetLastError = true,
            EntryPoint = "WaitNamedPipeW", CharSet = CharSet.Unicode)]
        public static extern BOOL WaitNamedPipe(
            string lpNamedPipeName,
            TimeOut nTimeOut);

        /* 
            * Connects to a message-type pipe
            * (and waits if an instance of the pipe is not available),
            * writes to and reads from the pipe,
            * and then closes the pipe.
            * 
            * Calling CallNamedPipe is equivalent to calling the CreateFile
            * (or WaitNamedPipe, if CreateFile cannot open the pipe immediately),
            * TransactNamedPipe, and CloseHandle functions.
            * CreateFile is called with an access flag of GENERIC_READ | GENERIC_WRITE,
            * and an inherit handle flag of FALSE.
            */
        [DllImport("Kernel32.dll", SetLastError = true,
            EntryPoint = "CallNamedPipeW", CharSet = CharSet.Unicode)]
        public static extern BOOL CallNamedPipe(
            string lpNamedPipeName,
            LPVOID lpInBuffer, DWORD nInBufferSize,
            LPVOID lpOutBuffer, DWORD nOutBufferSize,
            out DWORD lpBytesRead,
            DWORD nTimeOut);

        /*
            * Named Pipes :: Server
            */

        /*
            * Creates an instance of a named pipe and returns a handle for subsequent pipe operations.
            * A named pipe server process uses this function either to create the first instance of a specific named pipe
            * and establish its basic attributes
            * or to create a new instance of an existing named pipe.
            * 
            * Pipe Name must have the following form: 
            * \\.\pipe\pipename
            */
        [DllImport("Kernel32.dll", SetLastError = true,
            EntryPoint = "CreateNamedPipeW", CharSet = CharSet.Unicode)]
        public static extern SafePipeHandle CreateNamedPipe(
            string lpName,
            NamePipeOpenMode dwOpenMode,
            NamePipeMode dwPipeMode,
            DWORD nMaxInstances,
            DWORD nOutBufferSize,
            DWORD nInBufferSize,
            TimeOut nDefaultTimeOut,
            IntPtr lpSecurityAttributes);

        /*
            * Enables a named pipe server process to wait for a client process
            * to connect to an instance of a named pipe.
            * 
            * A client process connects by calling either the CreateFile 
            * or CallNamedPipe function.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL ConnectNamedPipe(
            SafePipeHandle hNamedPipe,
            IntPtr lpOverlapped);

        /*
            * Disconnects the server end of a named pipe instance 
            * from a client process.
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL DisconnectNamedPipe(
            SafePipeHandle hNamedPipe);

        /*
         * Named Pipes :: Properties
         */

        // Client Side //

        [DllImport("Kernel32.dll", SetLastError = true,
            EntryPoint = "GetNamedPipeClientComputerNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetNamedPipeClientComputerName(
            SafePipeHandle pipe,
            StringBuilder clientComputerName,
            ULONG clientComputerNameLength);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNamedPipeClientProcessId(
            SafePipeHandle pipe,
            out LONG clientProcessId);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNamedPipeClientSessionId(
            SafePipeHandle pipe,
            out LONG clientSessionId);

        // Server Side //

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNamedPipeServerProcessId(
            SafePipeHandle pipe,
            out LONG serverProcessId);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNamedPipeServerSessionId(
            SafePipeHandle pipe,
            out LONG serverSessionId);

        // Misc //

        /*
         * Accept:
         * [Anonymous Pipe]         SafeConsoleHandle
         * [Named Pipe :: Server]   safePipeHandle
         * [Named Pipe :: Client]   SafeFileHandle
         */  
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNamedPipeInfo(
            HANDLE hNamedPipe,
            out PipeInfoFlags lpFlags,
            out DWORD lpOutBufferSize,
            out DWORD lpInBufferSize,
            out DWORD lpMaxInstances);

        /*
         * Accept:
         * [Anonymous Pipe]         SafeConsoleHandle
         * [Named Pipe :: Server]   safePipeHandle
         * [Named Pipe :: Client]   SafeFileHandle
         * 
         * State:
         * PIPE_NOWAIT 0x00000001
         * PIPE_READMODE_MESSAGE 0x00000002
         */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNamedPipeHandleState(
            HANDLE hNamedPipe,
            out DWORD lpState,
            out DWORD lpOutBufferSize, 
            out DWORD lpCurInstances,
            out DWORD lpMaxCollectionCount,
            out DWORD lpCollectDataTimeout,
            StringBuilder lpUserName,
            DWORD nMaxUserNameSize);

        /*
         * Accept:
         * [Anonymous Pipe]         SafeConsoleHandle
         * [Named Pipe :: Server]   safePipeHandle
         * [Named Pipe :: Client]   SafeFileHandle
         */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL SetNamedPipeHandleState(
            HANDLE hNamedPipe,
            ref HandleStateFlags lpMode,
            ref DWORD lpMaxCollectionCount,
            ref DWORD lpCollectDataTimeout);
            

        /*
         * Pipes [All] :: Data
         */

        /*
         * Copies data from a named or anonymous pipe into a buffer,
         * without removing it from the pipe.
         * It also returns information about data in the pipe.
         * 
         * Accept:
         * [Anonymous Pipe]         SafeConsoleHandle
         * [Named Pipe :: Server]   safePipeHandle
         * [Named Pipe :: Client]   SafeFileHandle
         */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL PeekNamedPipe(
            HANDLE hNamedPipe,
            LPVOID lpBuffer, DWORD nBufferSize,
            out DWORD lpBytesRead,
            out DWORD lpTotalBytesAvail,
            out DWORD lpBytesLeftThisMessage);

        /*
         * Combines the functions that write a message to and read a message,
         * from the specified named pipe,
         * into a single network operation.
         * 
         * Accept:
         * [Anonymous Pipe]         SafeConsoleHandle
         * [Named Pipe :: Server]   safePipeHandle
         * [Named Pipe :: Client]   SafeFileHandle
         */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern BOOL TransactNamedPipe(
            HANDLE hNamedPipe,
            LPVOID lpInBuffer, DWORD nInBufferSize,
            LPVOID lpOutBuffer, DWORD nOutBufferSize,
            out DWORD lpBytesRead,
            IntPtr lpOverlapped);

        #endregion

        #region Mailslots [Interprocess Communications]

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeMailslotHandle CreateMailslot(
            string lpName,
            uint nMaxMessageSize,
            TimeOut lReadTimeout,
            IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetMailslotInfo(
            SafeMailslotHandle hMailslot,
            out DWORD lpMaxMessageSize,
            out DWORD lpNextSize,
            out DWORD lpMessageCount,
            out TimeOut lpReadTimeout);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetMailslotInfo(
            SafeMailslotHandle hMailslot,
            TimeOut lReadTimeout);

        #endregion

        #region File Mapping [Interprocess Communications]

        /* Step 1 */

        // call CreateFile function

        /* Step 2 */

        // uint dwMaxSizeHi;
        // uint dwMaxSizeLow = GetFileSize(hFile, out dwMaxSizeHi);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateFileMappingW", CharSet = CharSet.Unicode)]
        public static extern HANDLE CreateFileMapping(
            SafeFileHandle hFile,
            IntPtr lpAttributes,
            FileMapProtection flProtect,
            DWORD dwMaxSizeHi,
            DWORD dwMaxSizeLow,
            string lpName);

        /* lpName from CreateFileMapping(options, lpName) */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "OpenFileMappingW", CharSet = CharSet.Unicode)]
        public static extern HANDLE OpenFileMapping(
            FileMapAccess desiredAccess,
            BOOL bInheritHandle,
            string lpName);

        /* Step 3 */

        // dwFileOffsetHigh, dwFileOffsetLow should be 0
        // we can play with the handle later
        // .............................................
        // var Ptr = MapViewOfFile(...)
        // UINT* uintPtr = (UINT*)(Ptr + 0x00012)

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID MapViewOfFile(
            HANDLE hFileMapping,
            FileMapAccess dwDesiredAccess,
            DWORD dwFileOffsetHigh, // 0
            DWORD dwFileOffsetLow,  // 0
            SIZE_T dwNumberOfBytesToMap);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID MapViewOfFileEx(
            HANDLE hFileMapping,
            FileMapAccess dwDesiredAccess,
            DWORD dwFileOffsetHigh, // 0
            DWORD dwFileOffsetLow,  // 0
            SIZE_T dwNumberOfBytesToMap,
            LPVOID lpBaseAddress); // start address

        // from here we can play with the handle [as byte*, char*, else]
        // and modify it like we want,
        // all changes will be saved in the real file ....
        // [Really :P]

        /* Step 4 */

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FlushViewOfFile(
            LPCVOID hView,
            SIZE_T dwNumberOfBytesToFlush);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL UnmapViewOfFile(
            LPCVOID hView);

        #endregion

        ///////////
        /// ??? ///
        ///////////

        #region Wait
        //
        // wait For Objects
        //

        /*
            * The WaitForSingleObject function can wait for the following objects:
            * Change notification
            * Console input
            * Event
            * Memory resource notification
            * Mutex
            * Process
            * Semaphore
            * Thread
            * Waitable timer
            */

        /* Wait until handle is Close */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD WaitForSingleObject(
            HANDLE hHandle,
            WaitForSingleObjectFlags dwMilliseconds);

        /* Wait until handle is Close */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD WaitForSingleObjectEx(
            HANDLE hHandle,
            WaitForSingleObjectFlags dwMilliseconds,
            BOOL bAlertable);

        /* Wait until handles is Close */
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern DWORD WaitForMultipleObjects(
            DWORD nCount,
            HANDLE* lpHandles,
            BOOL bWaitAll,
            WaitForSingleObjectFlags dwMilliseconds);

        /* Wait until handles is Close */
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern DWORD WaitForMultipleObjectsEx(
            DWORD nCount,
            HANDLE* lpHandles,
            BOOL bWaitAll,
            WaitForSingleObjectFlags dwMilliseconds,
            BOOL bAlertable);

        //
        // wait For Address
        //

        /* Waits for the value at the specified address to change */
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern BOOL WaitOnAddress(
            IntPtr* address,
            PVOID compareAddress,
            SIZE_T addressSize,
            DWORD dwMilliseconds);

        /* Wakes one thread that is waiting for the value of an address to change. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void WakeByAddressSingle(
            PVOID address);

        /* Wakes all threads that are waiting for the value of an address to change. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void WakeByAddressAll(
            PVOID address);

        //
        // Signal And Wait
        //

        /* 
            * If the handle is a semaphore,
            * the SEMAPHORE_MODIFY_STATE access right is required.
            * If the handle is an event,
            * the EVENT_MODIFY_STATE access right is required.
            * If the handle is a mutex and the caller does not own the mutex,
            * the function fails with ERROR_NOT_OWNER. 
            */

        /* can be use with  SafeEventHandle / SafeMutexHandle / SafeSemaphoreHandle */
        /* Signals one object and waits on another object as a single operation. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD SignalObjectAndWait(
            HANDLE hObjectToSignal,
            HANDLE hObjectToWaitOn,
            DWORD dwMilliseconds,
            BOOL bAlertable);

        #endregion

        #region Waitable-timer
        /* Opens an existing named waitable timer object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "OpenWaitableTimerW", CharSet = CharSet.Unicode)]
        public static extern SafeWaitableTimerHandle OpenWaitableTimer(
            ACCESS_MASK dwDesiredAccess,
            BOOL bInheritHandle,
            LPCTSTR lpTimerName);

        /* Creates or opens a waitable timer object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateWaitableTimerW", CharSet = CharSet.Unicode)]
        public static extern SafeWaitableTimerHandle CreateWaitableTimer(
            [Optional] IntPtr lpTimerAttributes,
            BOOL bManualReset,
            [Optional] LPCTSTR lpTimerName);

        /* Creates or opens a waitable timer object and returns a handle to the object. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateWaitableTimerExW", CharSet = CharSet.Unicode)]
        public static extern SafeWaitableTimerHandle CreateWaitableTimerEx(
            [Optional] IntPtr lpTimerAttributes,
            [Optional] LPCTSTR lpTimerName,
            CREATE_WAITABLE_TIMER dwFlags,
            ACCESS_MASK dwDesiredAccess);

        /* Activates the specified waitable timer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetWaitableTimer(
            SafeWaitableTimerHandle hTimer,
            ref LARGE_INTEGER pDueTime,
            LONG lPeriod,
            [Optional] TimerApcProc pfnCompletionRoutine,
            [Optional] LPVOID lpArgToCompletionRoutine,
            BOOL fResume);

        /* Activates the specified waitable timer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetWaitableTimer(
            SafeWaitableTimerHandle hTimer,
            ref LARGE_INTEGER pDueTime,
            LONG lPeriod,
            IntPtr pfnCompletionRoutine,
            IntPtr lpArgToCompletionRoutine,
            BOOL fResume);

        /* Activates the specified waitable timer and provides context information for the timer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetWaitableTimerEx(
            SafeWaitableTimerHandle hTimer,
            ref LARGE_INTEGER pDueTime,
            LONG lPeriod,
            TimerApcProc pfnCompletionRoutine,
            LPVOID lpArgToCompletionRoutine,
            PREASON_CONTEXT wakeContext,
            ULONG tolerableDelay);

        /* Sets the specified waitable timer to the inactive state. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL CancelWaitableTimer(
            SafeWaitableTimerHandle hTimer);
        #endregion

        #region Time
        //
        // Windows time
        //

        /* Retrieves system timing information. On a multiprocessor system,
            the values returned are the sum of the designated times across all processors. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetSystemTimes(out Filetime lpIdleTime, out Filetime lpKernelTime, out Filetime lpUserTime);

        /* Retrieves system timing information. On a multiprocessor system,
            the values returned are the sum of the designated times across all processors. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetSystemTimes(out TimeSpan lpIdleTime, out TimeSpan lpKernelTime, out TimeSpan lpUserTime);

        /* Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetTickCount();

        /* Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern ULONGLONG GetTickCount64();

        //
        // system time
        //

        /* Retrieves the current system date and time.
            The system time is expressed in Coordinated Universal Time (UTC). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemTime(
            out SYSTEMTIME lpSystemTime);

        /* Sets the current system time and date.
            The system time is expressed in Coordinated Universal Time (UTC). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetSystemTime(
            ref SYSTEMTIME lpSystemTime);

        /* Enables or disables periodic time adjustments to the system's time-of-day clock.
            When enabled, such time adjustments can be used to synchronize the time of day with
            some other source of time information. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetSystemTimeAdjustment(
            DWORD dwTimeAdjustment,
            BOOL bTimeAdjustmentDisabled);

        /* Converts a system time to file time format.
            System time is based on Coordinated Universal Time (UTC). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SystemTimeToFileTime(
            ref  SYSTEMTIME lpSystemTime,
            out  Filetime lpFileTime);

        /* Retrieves the current system time. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD NtQuerySystemTime(
            out LARGE_INTEGER systemTime);

        //
        // local time
        //

        /* Retrieves the current local date and time. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetLocalTime(
            out SYSTEMTIME lpSystemTime);

        /* Sets the current local time and date. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetLocalTime(
            ref SYSTEMTIME lpSystemTime);

        /* Retrieves the current time zone settings.  */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetTimeZoneInformation(
            out TIME_ZONE_INFORMATION lpTimeZoneInformation);

        /* Sets the current time zone settings.  */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD SetTimeZoneInformation(
            ref TIME_ZONE_INFORMATION lpTimeZoneInformation);

        //
        // file time.
        //

        /* Retrieves the date and time that a file or directory was created,
            last accessed, and last modified. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetFileTime(
            SafeFileHandle hFile,
            out Filetime lpCreationTime,
            out Filetime lpLastAccessTime,
            out Filetime lpLastWriteTime);

        /* Sets the date and time that a file or directory was created,
            last accessed, and last modified. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetFileTime(
            SafeFileHandle hFile,
            ref Filetime lpCreationTime,
            ref Filetime lpLastAccessTime,
            ref Filetime lpLastWriteTime);

        /* Converts a file time to a local file time. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FileTimeToLocalFileTime(
            ref Filetime lpFileTime,
            out Filetime lpLocalFileTime);

        /* Converts a file time to system time format. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FileTimeToSystemTime(
            ref Filetime lpFileTime,
            out Filetime lpSystemTime);

        /* Converts a local file time to a file time based on the Coordinated Universal Time (UTC). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL LocalFileTimeToFileTime(
            ref Filetime lpLocalFileTime,
            out Filetime lpFileTime);

        /* Converts a system time to file time format. System time is based on Coordinated Universal Time (UTC). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SystemTimeToFileTime(
            ref Filetime lpSystemTime,
            out Filetime lpFileTime);

        /* Retrieves the current system date and time.
            The information is in Coordinated Universal Time (UTC) format. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemTimeAsFileTime(
            out Filetime lpSystemTimeAsFileTime);
        #endregion

        #region Console

        //
        // SafeConsoleHandle
        //

        // Get Handle

        /* Retrieves a handle to the specified standard device 
            (standard input, standard output, or standard error). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeConsoleHandle GetStdHandle(StdHandle nStdHandle);

        /* Sets the handle for the specified standard device (standard input, standard output, or standard error). */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetStdHandle(StdHandle nStdHandle, SafeConsoleHandle hHandle);

        // Allocate & Free Console

        /* Allocates a new console for the calling process. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL AllocConsole();

        /* Allocates a new console for the calling process. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FreeConsole();

        /* Attaches the calling process to the console of the specified process. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL AttachConsole(DWORD dwProcessId);

        // Create Console

        /* Creates a console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeConsoleHandle CreateConsoleScreenBuffer(
            ConsoleDesiredAccess dwDesiredAccess,
            ConsoleFileShare dwShareMode,
            IntPtr lpSecurityAttributes,
            DWORD dwFlags, /* 1 [CONSOLE_TEXTMODE_BUFFER] */
            LPVOID lpScreenBufferData);

        /* 
            * Sets the specified screen buffer to be
            * the currently displayed console screen buffer.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleActiveScreenBuffer(
            SafeConsoleHandle hConsoleOutput);

        /* Moves a block of data in a screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ScrollConsoleScreenBuffer(
            SafeConsoleHandle hConsoleOutput,
            ref SMALL_RECT lpScrollRectangle,
            IntPtr lpClipRectangle,
            COORD dwDestinationOrigin,
            ref CHAR_INFO lpFill);

        /* Moves a block of data in a screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ScrollConsoleScreenBuffer(
            SafeConsoleHandle hConsoleOutput,
            ref SMALL_RECT lpScrollRectangle,
            ref SMALL_RECT lpClipRectangle,
            COORD dwDestinationOrigin,
            ref CHAR_INFO lpFill);

        /* Retrieves information about the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleScreenBufferInfo(
            SafeConsoleHandle hConsoleOutput,
            out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo);

        /* Retrieves extended information about the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleScreenBufferInfoEx(
            SafeConsoleHandle hConsoleOutput,
            out CONSOLE_SCREEN_BUFFER_INFOEX lpConsoleScreenBufferInfo);

        /* Sets extended information about the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleScreenBufferInfoEx(
            SafeConsoleHandle hConsoleOutput,
            ref CONSOLE_SCREEN_BUFFER_INFOEX lpConsoleScreenBufferInfoEx);

        /* Changes the size of the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleScreenBufferSize(
            SafeConsoleHandle hConsoleOutput, COORD dwSize);

        //
        // Flush, Read, Write
        //

        /* Flushes the console input buffer. 
            All input records currently in the input buffer are discarded. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FlushConsoleInputBuffer(
            SafeConsoleHandle hConsoleInput);

        /* Reads character input from the console input buffer and removes it from the buffer. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ReadConsoleW", CharSet = CharSet.Unicode)]
        public static extern BOOL ReadConsole(
            SafeConsoleHandle hConsoleInput,
            LPVOID lpBuffer, /* nNumberOfCharsToRead * 2 */
            DWORD nNumberOfCharsToRead,
            out DWORD lpNumberOfCharsRead,
            LPVOID pInputControl);

        /* Writes a character string to a console screen buffer beginning at the current cursor location. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "WriteConsoleW", CharSet = CharSet.Unicode)]
        public static extern BOOL WriteConsole(
            SafeConsoleHandle hConsoleOutput,
            LPVOID lpBuffer, /* nNumberOfCharsToWrite * 2 */
            DWORD nNumberOfCharsToWrite,
            out DWORD lpNumberOfCharsWritten,
            LPVOID lpReserved /* IntPtr.Zero */);

        /* Reads data from the specified console input buffer without removing it from the buffer. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "PeekConsoleInputW", CharSet = CharSet.Unicode)]
        public static extern BOOL PeekConsoleInput(
            SafeConsoleHandle hConsoleInput,
            [MarshalAs(UnmanagedType.LPArray), Out] INPUT_RECORD[] lpBuffer,
            DWORD nLength, // lpBuffer.Length
            out DWORD lpNumberOfEventsRead);

        /* Reads data from a console input buffer and removes it from the buffer. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ReadConsoleInputW", CharSet = CharSet.Unicode)]
        public static extern BOOL ReadConsoleInput(
            SafeConsoleHandle hConsoleInput,
            [MarshalAs(UnmanagedType.LPArray), Out] INPUT_RECORD[] lpBuffer,
            DWORD nLength,
            out DWORD lpNumberOfEventsRead);

        /* Reads data from a console input buffer and removes it from the buffer. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "WriteConsoleInputW", CharSet = CharSet.Unicode)]
        public static extern BOOL WriteConsoleInput(
            SafeConsoleHandle hConsoleInput,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT_RECORD[] lpBuffer,
            DWORD nLength,
            out DWORD lpNumberOfEventsWritten);

        /* Reads character and color attribute data from a rectangular block of character cells in a console screen buffer,
            and the function writes the data to a rectangular block at a specified location in the destination buffer. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ReadConsoleOutputW", CharSet = CharSet.Unicode)]
        public static extern BOOL ReadConsoleOutput(
            SafeConsoleHandle hConsoleOutput,
            /* This pointer is treated as the origin of a two-dimensional array of CHAR_INFO structures
                whose size is specified by the dwBufferSize parameter.*/
            [MarshalAs(UnmanagedType.LPArray), Out] CHAR_INFO[,] lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            ref SMALL_RECT lpReadRegion);

        /* Writes character and color attribute data to a specified rectangular block of character cells in a console screen buffer.
            The data to be written is taken from a correspondingly sized rectangular block at a specified location in the source buffe */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "WriteConsoleOutputW", CharSet = CharSet.Unicode)]
        public static extern BOOL WriteConsoleOutput(
            SafeConsoleHandle hConsoleOutput,
            /* This pointer is treated as the origin of a two-dimensional array of CHAR_INFO structures
                whose size is specified by the dwBufferSize parameter.*/
            [MarshalAs(UnmanagedType.LPArray), In] CHAR_INFO[,] lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            ref SMALL_RECT lpWriteRegion);

        //
        // [Get]
        //

        /* Retrieves the current input mode of a console's input buffer
            or the current output mode of a console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleMode(
            SafeConsoleHandle hConsoleHandle,
            out ConsoleModes lpMode);

        /* Retrieves the title for the current console window. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleTitleW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetConsoleTitle(
            StringBuilder lpConsoleTitle,
            DWORD nSize);

        /* Retrieves the title for the current console window. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleOriginalTitleW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetConsoleOriginalTitle(
            StringBuilder lpConsoleTitle,
            DWORD nSize);

        /* Retrieves information about the size and visibility of the cursor,
            for the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleCursorInfo(
            SafeConsoleHandle hConsoleOutput,
            out CONSOLE_CURSOR_INFO lpConsoleCursorInfo);

        /* Retrieves the display mode of the current console. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleDisplayMode(
            out ConsoleMode dwFlags);

        /* Retrieves the input code page used by the console associated with the calling process. 
            A console uses its input code page to translate keyboard input into the corresponding character value. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UINT GetConsoleCP();

        /* Retrieves the history settings for the calling process's console. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleHistoryInfo(
            out CONSOLE_HISTORY_INFO lpConsoleHistoryInfo);

        /* Retrieves the output code page used by the console associated with the calling process.
            A console uses its output code page to translate the character values written by the various output functions,
            into the images displayed in the console window. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UINT GetConsoleOutputCP();

        // --------------------- //

        /* Retrieves the size of the largest possible console window,
            based on the current font and the size of the display. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern COORD GetLargestConsoleWindowSize(
            SafeConsoleHandle hConsoleOutput
            );

        /* Retrieves the number of buttons on the mouse used by the current console. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNumberOfConsoleMouseButtons(
            out DWORD lpNumberOfMouseButtons);

        /* Retrieves information about the current console selection. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetConsoleSelectionInfo(
            out CONSOLE_SELECTION_INFO lpConsoleSelectionInfo
        );

        //
        // [Set]
        //


        /* Sets the input mode of a console's input buffer 
            or the output mode of a console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleMode(
            SafeConsoleHandle hConsoleHandle,
            ConsoleModes dwMode);

        /* Sets the title for the current console window. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "SetConsoleTitleW", CharSet = CharSet.Unicode)]
        public static extern DWORD SetConsoleTitle(
            LPCTSTR lpConsoleTitle);

        /* Sets the display mode of the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleDisplayMode(
            SafeConsoleHandle hConsoleOutput,
            ConsoleMode dwFlags,
            ref COORD lpNewScreenBufferDimensions);

        /* Sets the display mode of the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleDisplayMode(
            SafeConsoleHandle hConsoleOutput,
            ConsoleMode dwFlags,
            [Optional] IntPtr lpNewScreenBufferDimensions);

        /* Sets the input code page used by the console associated with the calling process. 
            A console uses its input code page to translate keyboard input into the corresponding character value. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleCP(
            UINT wCodePageID);

        /* Sets the history settings for the calling process's console. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleHistoryInfo(
            ref CONSOLE_HISTORY_INFO lpConsoleHistoryInfo
            );

        /* Sets the output code page used by the console associated with the calling process. 
            A console uses its output code page to translate the character values written
            by the various output functions into the images displayed in the console window. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleOutputCP(
            UINT wCodePageID);

        // --------------------- //

        /* Sets the current size and position of a console screen buffer's window. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleWindowInfo(
            SafeConsoleHandle hConsoleOutput,
            BOOL bAbsolute,
            ref SMALL_RECT lpConsoleWindow);

        /* Sets the cursor position in the specified console screen buffer */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleCursorPosition(
            SafeConsoleHandle hConsoleOutput,
            COORD dwCursorPosition);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleIcon(
            IntPtr hIcon);

        // 
        // Font
        //

        /* Retrieves information about the current console font. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetCurrentConsoleFont(
            SafeConsoleHandle hConsoleOutput,
            BOOL bMaximumWindow,
            ref CONSOLE_FONT_INFO lpConsoleCurrentFont);

        /* Retrieves extended information about the current console font. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetCurrentConsoleFontEx(
            SafeConsoleHandle hConsoleOutput,
            BOOL bMaximumWindow,
            ref CONSOLE_FONT_INFOEX lpConsoleCurrentFontEx);

        /* Sets the size and visibility of the cursor for the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleCursorInfo(
            SafeConsoleHandle hConsoleOutput,
            ref CONSOLE_CURSOR_INFO lpConsoleCursorInfo);

        /* Sets information about the current console font. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetCurrentConsoleFont(
            SafeConsoleHandle hConsoleOutput,
            BOOL bMaximumWindow,
            ref CONSOLE_FONT_INFO lpConsoleCurrentFont);

        /* Sets extended information about the current console font. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetCurrentConsoleFontEx(
            SafeConsoleHandle hConsoleOutput,
            BOOL bMaximumWindow,
            ref CONSOLE_FONT_INFOEX lpConsoleCurrentFontEx);

        /* Retrieves the size of the font used by the specified console screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern COORD GetConsoleFontSize(
            SafeConsoleHandle hConsoleOutput,
            DWORD nFont);

        //
        // Changing Console Fonts
        // http://blogs.microsoft.co.il/blogs/pavely/archive/2009/07/23/changing-console-fonts.aspx 
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetNumberOfConsoleFonts();

        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static BOOL SetConsoleFont(
            SafeConsoleHandle hOutput,
            uint index);

        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern BOOL GetConsoleFontInfo(
            SafeConsoleHandle hOutput,
            BOOL bMaximize,
            uint count,
            CONSOLE_FONT* fonts);

        //
        // Color
        //

        /*  Sets the attributes of characters written to the console screen buffer 
            by the WriteFile or WriteConsole function, or echoed by the ReadFile or ReadConsole function. 
            This function affects text written after the function call.*/
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleTextAttribute(
            SafeConsoleHandle hConsoleOutput,
            Enum.Attribute wAttributes);

        /* Copies a specified number of character attributes from consecutive cells of a console screen buffer,
            beginning at a specified location. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern BOOL ReadConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,
            Enum.Attribute* lpAttribute, // nLength * sizeof(WORD).
            DWORD nLength,
            COORD dwReadCoord,
            out DWORD lpNumberOfAttrsRead);

        /* Copies a number of character attributes to consecutive cells of a console screen buffer,
            beginning at a specified location. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern BOOL WriteConsoleOutputAttribute (
            SafeConsoleHandle hConsoleOutput,
            Enum.Attribute* lpAttribute,
            DWORD nLength,
            COORD dwWriteCoord,
            out DWORD lpNumberOfAttrsWritten);

        /* Sets the character attributes for a specified number of character cells,
            beginning at the specified coordinates in a screen buffer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FillConsoleOutputAttribute(
            SafeConsoleHandle hConsoleOutput,    /* A handle to the console screen buffer. The handle must have the GENERIC_WRITE access right.*/
            Enum.Attribute wAttribute,                   /* The attributes to use when writing to the console screen buffer.  */
            DWORD nLength,                                  /* The number of character cells to be set to the specified color attributes. */
            COORD dwWriteCoord,                   /* A COORD structure that specifies the character coordinates of the first cell whose attributes are to be set. */
            out DWORD lpNumberOfAttrsWritten);

        //
        // Character
        //

        /* Copies a number of characters from consecutive cells of a console screen buffer,
                beginning at a specified location. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ReadConsoleOutputCharacterW", CharSet = CharSet.Unicode)]
        public static extern BOOL ReadConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            StringBuilder lpCharacter,
            DWORD nLength,
            COORD dwReadCoord,
            out DWORD lpNumberOfCharsRead);

        /* Copies a number of characters to consecutive cells of a console screen buffer,
            beginning at a specified location. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "WriteConsoleOutputCharacterW", CharSet = CharSet.Unicode)]
        public static extern BOOL WriteConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            StringBuilder lpCharacter,
            DWORD nLength,
            COORD dwWriteCoord,
            out DWORD lpNumberOfCharsWritten);

        [DllImport("Kernel32.dll", SetLastError = true,
            EntryPoint = "FillConsoleOutputCharacterW", CharSet = CharSet.Unicode)]
        public static extern BOOL FillConsoleOutputCharacter(
            SafeConsoleHandle hConsoleOutput,
            TCHAR cCharacter,
            DWORD nLength,
            COORD dwWriteCoord,
            out DWORD lpNumberOfCharsWritten
        );

        //
        // Alias
        //

        /* Adds or removes an application-defined HandlerRoutine function from the list
            of handler functions for the calling process. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "AddConsoleAliasW", CharSet = CharSet.Unicode)]
        public static extern BOOL AddConsoleAlias(
            LPCTSTR source, LPCTSTR target, LPCTSTR exeName);

        /* Retrieves the text for the specified console alias and executable. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleAliasW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetConsoleAlias(
            string lpSource,
            string lpTargetBuffer,
            DWORD targetBufferLength,
            string lpExeName);

        /* Retrieves all defined console aliases for the specified executable. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleAliasesW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetConsoleAliases(
            string lpAliasBuffer,
            DWORD aliasBufferLength,
            string lpExeName);

        /* Retrieves all defined console aliases for the specified executable. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleAliasesLengthW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetConsoleAliasesLength(
            string lpExeName);

        /* Retrieves the names of all executable files with console aliases defined. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleAliasExesW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetConsoleAliasExes(
            [MarshalAs(UnmanagedType.LPTStr)] string lpExeNameBuffer,
            DWORD exeNameBufferLength);

        /* Retrieves the required size for the buffer used by the GetConsoleAliasExes function. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetConsoleAliasExesLengthW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetConsoleAliasExesLength();

        //
        // Event
        //

        /* Adds or removes an application-defined HandlerRoutine function from the list
            of handler functions for the calling process. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL SetConsoleCtrlHandler(
            HandlerRoutine handlerRoutine, BOOL add);

        /* Retrieves the number of unread input records in the console's input buffer.
            use Peek/Read/Write[ConsoleInput] to handle the messege */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetNumberOfConsoleInputEvents(
            SafeConsoleHandle hConsoleInput,
            out DWORD lpcNumberOfEvents);

        /// <summary>
        /// Sends a specified signal to a console process group that shares the console
        /// associated with the calling process.
        /// </summary>
        /// <param name="dwCtrlEvent">CTRL_C_EVENT 0, CTRL_BREAK_EVENT 1 </param>
        /// <param name="dwProcessGroupId">0 Or ProcessId from CreateProcess [CREATE_NEW_PROCESS_GROUP flag]</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GenerateConsoleCtrlEvent(
            DWORD dwCtrlEvent, DWORD dwProcessGroupId);

        //
        // Misc
        //

        /* Retrieves a list of the processes attached to the current console. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public unsafe static extern DWORD GetConsoleProcessList(
            DWORD* lpdwProcessList,
            DWORD dwProcessCount);

        #endregion

        #region Shutdown

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetProcessShutdownParameters(
            out DWORD lpdwLevel, 
            out DWORD lpdwFlags);

        /// <summary>
        /// Sets shutdown parameters for the currently calling process.
        /// override wndproc and catch WindowMessege.QUERYENDSESSION
        /// to prevent process from closing [and all the system]
        /// </summary>
        /// <param name="dwLevel">0x280</param>
        /// <param name="dwFlags">0x001</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetProcessShutdownParameters(
            DWORD dwLevel,
            DWORD dwFlags);

        #endregion

        #region Environment
        // Environment Variables
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms682653(v=vs.85).aspx
        // GetEnvironmentStrings() == NtQueryInformationProcess() -> PROCESS_BASIC_INFORMATION -> PEB -> RTL_USER_PROCESS_PARAMETERS -> Environment

        /* Retrieves the environment variables for the current process. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetEnvironmentStringsW", CharSet = CharSet.Unicode)]
        public static extern Struct.Environment GetEnvironmentStrings();

        /* Frees a block of environment strings. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FreeEnvironmentStringsW", CharSet = CharSet.Unicode)]
        public static extern bool FreeEnvironmentStrings(
            Struct.Environment lpszEnvironmentBlock);

        /* Retrieves the contents of the specified variable from the environment block of the calling process. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetEnvironmentVariableW", CharSet = CharSet.Unicode)]
        public static extern bool GetEnvironmentVariable(
            string lpName, StringBuilder lpBuffer, uint nSize);

        /* Retrieves the contents of the specified variable from the environment block of the calling process. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "SetEnvironmentVariableW", CharSet = CharSet.Unicode)]
        public static extern bool SetEnvironmentVariable(
            string lpName, string lpValue);

        /* Expands environment-variable strings and replaces them with the values defined for the current user. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ExpandEnvironmentStringsW", CharSet = CharSet.Unicode)]
        public static extern bool ExpandEnvironmentStrings(
            string lpSrc, StringBuilder lpDst, uint nSize);

        /* Expands environment-variable strings and replaces them with the values defined for specified user. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ExpandEnvironmentStringsForUserW", CharSet = CharSet.Unicode)]
        public static extern bool ExpandEnvironmentStringsForUser(
            SafeTokenHandle hToken, string lpSrc, StringBuilder lpDst, uint nSize);
        #endregion

        #region System Information
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetComputerNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetComputerName(
            StringBuilder lpBuffer, ref DWORD lpnSize);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetComputerNameExW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetComputerNameEx(
            COMPUTER_NAME_FORMAT nameType, StringBuilder lpBuffer);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetSystemDirectoryW", CharSet = CharSet.Unicode)]
        public static extern UINT GetSystemDirectory(
            StringBuilder lpBuffer, UINT uSize);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetWindowsDirectoryW", CharSet = CharSet.Unicode)]
        public static extern UINT GetWindowsDirectory(
            StringBuilder lpBuffer, UINT uSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemInfo(
            out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetNativeSystemInfo(
            out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GetVersionEx(
            ref OSVERSIONINFOEX lpVersionInfo);
        #endregion

        #region Resource
        // Introduction to Resources
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ff468900(v=vs.85).aspx

        // Resource File Formats
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms648007(v=vs.85).aspx

        //
        // Get
        //

        /* 
            * pName usually start with #[?]
            * hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, DONT_RESOLVE_DLL_REFERENCES]
            */
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode,
            EntryPoint = "FindResourceW", SetLastError = true)]
        public static extern LPVOID FindResource(
            LPVOID hModule, LPCTSTR pName, Win32ResourceType pType);

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode,
            EntryPoint = "FindResourceExW", SetLastError = true)]
        public static extern LPVOID FindResourceEx(
            LPVOID hModule, LPCTSTR pName, Win32ResourceType pType, WORD wLanguage);

        /* hResource from FindResource[Ex] */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern DWORD SizeofResource(
            LPVOID hModule, LPVOID hResource);

        /* hResource from FindResource[Ex] */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern LPVOID LoadResource(
            LPVOID hModule, LPVOID hResource);

        /* hGlobal from LoadResource */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern LPVOID LockResource(
            LPVOID hGlobal);

        //
        // Set
        //

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "BeginUpdateResourceW", CharSet = CharSet.Unicode)]
        public static extern LPVOID BeginUpdateResource(
            LPCTSTR pFileName, BOOL bDeleteExistingResources);

        /* hUpdate from BeginUpdateResource */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UpdateResource(
            LPVOID hUpdate, Win32ResourceType lpType, LPCTSTR lpName, WORD wLanguage, LPVOID lpData, DWORD cbData);

        /* hUpdate from BeginUpdateResource */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UpdateResource(
            LPVOID hUpdate, Win32ResourceType lpType, LPCTSTR lpName, WORD wLanguage, byte[] lpData, DWORD cbData);

        /* hUpdate from BeginUpdateResource */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool EndUpdateResource(
            LPVOID hUpdate, BOOL fDiscard);

        //
        // Enum
        //

        /* hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, LOAD_IGNORE_CODE_AUTHZ_LEVEL] */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "EnumResourceLanguagesW", CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceLanguages(
            LPVOID hModule, Win32ResourceType lpszType, LPCTSTR lpName, Enumreslangproc lpEnumFunc, LPVOID lParam);

        /* hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, LOAD_IGNORE_CODE_AUTHZ_LEVEL] */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "EnumResourceNamesW", CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceNames(
            LPVOID hModule, Win32ResourceType lpszType, Enumresnameproc lpEnumFunc, LPVOID lParam);

        /* hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, LOAD_IGNORE_CODE_AUTHZ_LEVEL] */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "EnumResourceTypesW", CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceTypes(
            LPVOID hModule, Enumrestypeproc lpEnumFunc, LPVOID lParam);

        /* hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, LOAD_IGNORE_CODE_AUTHZ_LEVEL] */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "EnumResourceLanguagesExW", CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceLanguagesEx(
            LPVOID hModule, Win32ResourceType lpszType, LPCTSTR lpName, Enumreslangproc lpEnumFunc, LONG_PTR lParam, RESOURCE_ENUM dwFlags, LANGID LangId);

        /* hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, LOAD_IGNORE_CODE_AUTHZ_LEVEL] */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "EnumResourceNamesExW", CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceNamesEx(
            LPVOID hModule, Win32ResourceType lpszType, Enumresnameproc lpEnumFunc, LONG_PTR lParam, RESOURCE_ENUM dwFlags, LANGID LangId);

        /* hModule from LoadLibraryEx [DONT_RESOLVE_DLL_REFERENCES, LOAD_IGNORE_CODE_AUTHZ_LEVEL] */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "EnumResourceTypesExW", CharSet = CharSet.Unicode)]
        public static extern bool EnumResourceTypesEx(
            LPVOID hModule, Enumrestypeproc lpEnumFunc, LONG_PTR lParam, RESOURCE_ENUM dwFlags, LANGID LangId);
        #endregion

        #region File System

        //
        // File
        //

        /// <summary>
        /// Creates or opens a file or I/O device.
        /// lpFileName can be:
        /// [Device]    @"LPT1" 
        /// [Drive]     @"\\.\C:"
        /// [File]      @"\\.\C:\myFile"
        /// </summary>
            
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFile(
            string lpFileName,
            Enum.FileAccess dwDesiredAccess,
            Enum.FileShare dwShareMode,
            IntPtr lpSecurityAttributes,
            Enum.FileMode dwCreationDisposition,
            Enum.FileAttributes dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFile(
            string lpFileName,
            Enum.FileAccess dwDesiredAccess,
            Enum.FileShare dwShareMode,
            IntPtr lpSecurityAttributes,
            Enum.FileMode dwCreationDisposition,
            Enum.FileFlag dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool CopyFile(
            string lpExistingFileName, 
            string lpNewFileName, 
            bool bFailIfExists);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CopyFileEx(
            string lpExistingFileName,
            string lpNewFileName,
            CopyProgressRoutine lpProgressRoutine,
            IntPtr lpData, 
            ref Int32 pbCancel, 
            CopyFileFlags dwCopyFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool MoveFile(
            string lpExistingFileName, 
            string lpNewFileName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool MoveFileEx(
            string lpExistingFileName, 
            string lpNewFileName,
            MoveFileFlags dwFlags);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "DeleteFileW", CharSet = CharSet.Unicode)]
        public static extern BOOL DeleteFile  (
            string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadFile(
            SafeFileHandle hFile, 
            byte[] lpBuffer,
            uint nNumberOfBytesToRead, 
            out uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadFileEx(
            SafeFileHandle hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToRead, 
            IntPtr lpOverlapped,
            FileCompletionDelegate lpCompletionRoutine);

        /* Writes data to the specified file or input/output (I/O) device. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFile(
            SafeFileHandle hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite, 
            out uint lpNumberOfBytesWritten, 
            IntPtr lpOverlapped);

        /* Writes data to the specified file or input/output (I/O) device. :: synchronous and asynchronous operations Supprted */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFileEx(
            SafeFileHandle hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite, 
            IntPtr lpOverlapped,
            FileCompletionDelegate lpCompletionRoutine);

        /* Lock File */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool LockFile(
            SafeFileHandle hFile,
            DWORD dwFileOffsetLow, DWORD dwFileOffsetHigh,
            DWORD nNumberOfBytesToLockLow, DWORD nNumberOfBytesToLockHigh);

        /* Lock File -- Extended */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool LockFileEx(
            SafeFileHandle hFile,
            LockFlags dwFlags, DWORD dwReserved,
            DWORD nNumberOfBytesToLockLow,
            DWORD nNumberOfBytesToLockHigh,
            IntPtr lpOverlapped);

        /* UnLock File */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UnlockFile(
            SafeFileHandle hFile,
            DWORD dwFileOffsetLow, DWORD dwFileOffsetHigh,
            DWORD nNumberOfBytesToUnlockLow, DWORD nNumberOfBytesToUnlockHigh);

        /* UnLock File -- Extended */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool UnlockFileEx(
            SafeFileHandle hFile, DWORD dwReserved,
            DWORD nNumberOfBytesToUnlockLow,
            DWORD nNumberOfBytesToUnlockHigh,
            IntPtr lpOverlapped);

        //
        // File :: ???
        //

        /* Misc */

        /* Moves the file pointer of the specified file. 
            Cast lpDistanceToMoveHigh as (int*)0
            use lDistanceToMove as number of bytes,
            the return is the EOF position.
            [not the real harddrive bytes --- GetFileSize()]
            */
        [DllImport("Kernel32.dll", SetLastError = true)]
        public unsafe static extern uint SetFilePointer(
            SafeFileHandle hFile,
            int lDistanceToMove,
            int* lpDistanceToMoveHigh,
            EMoveMethod dwMoveMethod);

        /* Sets the physical file size for the specified file to the current position of the file pointer. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetEndOfFile(
            SafeFileHandle hFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FlushFileBuffers(
            SafeFileHandle hFile);

        /* File Notification Mode */

        /*
            * < flags >
            * 0x1 = FILE_SKIP_COMPLETION_PORT_ON_SUCCESS
            * 0x2 = FILE_SKIP_SET_EVENT_ON_HANDLE
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetFileCompletionNotificationModes(
            SafeFileHandle fileHandle,
            UCHAR flags);

        /* File I/O */

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CancelIo(
            SafeFileHandle hFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CancelIoEx(
            SafeFileHandle hFile,
            IntPtr lpOverlapped);

        /* File Information */

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetFinalPathNameByHandle(
            SafeFileHandle fileHandle,
            StringBuilder lpszFilePath,
            DWORD cchFilePath,
            FinalPathFlags dwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetFileInformationByHandle(
            SafeFileHandle fileHandle,
            out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        /* 
            * Accept :: 
            * (IntPtr)(FileInfo*)
            * FileInfo* :: fail.
            * Out FileInfo :: success >> Bad result.
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetFileInformationByHandleEx(
            SafeFileHandle fileHandle,
            FILE_INFO_BY_HANDLE_CLASS fileInformationClass,
            IntPtr lpFileInformation,
            DWORD dwBufferSize);

        /* 
            * Accept :: 
            * (IntPtr)(FileInfo*)
            * FileInfo* :: fail.
            * Ref FileInfo :: i.d.k
            */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetFileInformationByHandle(
            SafeFileHandle fileHandle,
            FILE_INFO_BY_HANDLE_CLASS fileInformationClass,
            IntPtr lpFileInformation,
            DWORD dwBufferSize);

        //
        // Directory
        //

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL CreateDirectory(
            LPCTSTR path,
            IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "CreateDirectoryExW", CharSet = CharSet.Unicode)]
        public static extern BOOL CreateDirectoryEx(
            LPCTSTR lpTemplateDirectory,
            LPCTSTR lpNewDirectory,
            IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "RemoveDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL RemoveDirectory(string lpFileName);

        //
        // Drive
        //

        /* lpRootPathName from FindFirstVolume .... */
        /* Determines whether a disk drive is a removable, fixed, CD-ROM, RAM disk, or network drive. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "GetDriveTypeW", CharSet = CharSet.Unicode)]
        public static extern DriveType GetDriveType(
            LPCTSTR lpRootPathName);

        /* Retrieves a bitmask representing the currently available disk drives. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetLogicalDrives();

        /* Fills a buffer with string[s] that specify valid drives in the system. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetLogicalDriveStrings(
            DWORD nBufferLength,
            IntPtr lpBuffer);

        //
        // Volume
        //

        /* Retrieves a list of drive letters and mounted folder paths for the specified volume. */
        /* get the Guid from FindFirstVolume Function */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetVolumePathNamesForVolumeName(
            LPCTSTR lpszVolumeName,
            StringBuilder lpszVolumePathNames,
            DWORD cchBufferLength,
            out DWORD lpcchReturnLength);

        /* Retrieves a list of drive letters and mounted folder paths for the specified volume. */
        /* get the Guid from FindFirstVolume Function,
            to read the data use Allcate 25 bytes and use lpcchReturnLength value.
            lpszVolumePathNames.ToAnsiStr(lpcchReturnLength) */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetVolumePathNamesForVolumeName(
            LPCTSTR lpszVolumeName,
            IntPtr lpszVolumePathNames,
            DWORD cchBufferLength,
            out DWORD lpcchReturnLength);

        /* Retrieves information about the file system and volume associated
            with the specified root directory. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "GetVolumeInformationW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetVolumeInformation(
            LPCTSTR lpRootPathName,
            StringBuilder lpVolumeNameBuffer,
            DWORD nVolumeNameSize,
            out DWORD lpVolumeSerialNumber,
            out DWORD lpMaximumComponentLength,
            out FileSystemFlags lpFileSystemFlags,
            StringBuilder lpFileSystemNameBuffer,
            DWORD nFileSystemNameSize);

        /* Retrieves information about the file system and volume associated with the specified file. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "GetVolumeInformationByHandleW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetVolumeInformationByHandle(
            SafeFileHandle hFile,
            StringBuilder lpVolumeNameBuffer,
            DWORD nVolumeNameSize,
            out DWORD lpVolumeSerialNumber,
            out DWORD lpMaximumComponentLength,
            out FileSystemFlags lpFileSystemFlags,
            StringBuilder lpFileSystemNameBuffer,
            DWORD nFileSystemNameSize);

        /* Sets the label of a file system volume. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "SetVolumeLabelW", CharSet = CharSet.Unicode)]
        public static extern BOOL SetVolumeLabel(
            LPCTSTR lpRootPathName,
            LPCTSTR lpVolumeName);

        //
        // VolumeMountPoint
        //

        /* Retrieves the volume mount point where the specified path is mounted. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "GetVolumePathNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetVolumePathName(
            LPCTSTR lpszFileName,
            StringBuilder lpszVolumePathName,
            DWORD cchBufferLength);

        /* Retrieves a volume GUID path for the volume that is associated with the specified volume mount point 
            (drive letter, volume GUID path, or mounted folder). */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "GetVolumeNameForVolumeMountPointW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetVolumeNameForVolumeMountPoint(
            LPCTSTR lpszVolumeMountPoint,
            StringBuilder lpszVolumeName,
            DWORD cchBufferLength);

        /* Associates a volume with a drive letter or a directory on another volume. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "SetVolumeMountPointW", CharSet = CharSet.Unicode)]
        public static extern BOOL SetVolumeMountPoint(
            LPCTSTR lpszVolumeMountPoint,
            LPCTSTR lpszVolumeName);

        /* Deletes a drive letter or mounted folder. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "DeleteVolumeMountPointW", CharSet = CharSet.Unicode)]
        public static extern BOOL DeleteVolumeMountPoint(
            LPCTSTR lpszVolumeMountPoint);

        //
        // DosDevice
        //

        /* Defines, redefines, or deletes MS-DOS device names. */
        [DllImport("kernel32.dll", SetLastError = true, 
            EntryPoint = "DefineDosDeviceW", CharSet = CharSet.Unicode)]
        public static extern BOOL DefineDosDevice(
            DDD_FLAGS dwFlags,
            LPCTSTR lpDeviceName,
            LPCTSTR lpTargetPath);

        /* Retrieves information about MS-DOS device names.
            The function can obtain the current mapping for a particular MS-DOS device name.
            The function can also obtain a list of all existing MS-DOS device names. */

        /* Usage :: 'DriveLetter': OR Harddisk'IDX'Partition'IDX' OR Volume{'GUID'} [FindFirstFileName]
            http://thisthattechnology.blogspot.com/2009/11/associating-disk-partitions-with.html */

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "QueryDosDeviceA", CharSet = CharSet.Ansi)]
        public static extern DWORD QueryDosDevice(
            LPCTSTR lpDeviceName,
            IntPtr lpTargetPath,
            DWORD ucchMax);

        //
        // Find
        //

        /* Searches a directory for a file or subdirectory with a name and attributes that match those specified. */
        /* Sample Search '@"\\?\C:\*.*"' */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindFirstFileW", CharSet = CharSet.Unicode)]
        public static extern SafeFindFileHandle FindFirstFile(
            LPCTSTR lpFileName,
            out WIN32_FIND_DATA lpFindFileData);

        /* Searches a directory for a file or subdirectory with a name and attributes that match those specified. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindFirstFileExW", CharSet = CharSet.Unicode)]
        public static extern SafeFindFileHandle FindFirstFileEx(
            LPCTSTR lpFileName,
            FINDEX_INFO_LEVELS fInfoLevelId,
            out WIN32_FIND_DATA lpFindFileData,
            FINDEX_SEARCH_OPS fSearchOp,
            LPVOID lpSearchFilter,
            AdditionalFlags dwAdditionalFlags);

        /* Creates an enumeration of all the hard links to the specified file.
            The FindFirstFileNameW function returns a handle to the enumeration 
            that can be used on subsequent calls to the FindNextFileNameW function. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindFirstFileNameW", CharSet = CharSet.Unicode)]
        public static extern SafeFindFileNameHandle FindFirstFileName(
            StringBuilder lpFileName,
            DWORD dwFlags,
            ref DWORD stringLength,
            ref WCHAR linkName);

        /* Retrieves the name of a volume on a computer. FindFirstVolume is used to begin scanning the volumes of a computer. */
        /* use GetVolumePathNamesForVolumeName to extract Volume Name */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindFirstVolumeW", CharSet = CharSet.Unicode)]
        public static extern SafeFindVolumeHandle FindFirstVolume(
            StringBuilder lpszVolumeName,
            DWORD cchBufferLength);

        /* Retrieves the name of a mounted folder on the specified volume. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindFirstVolumeMountPointW", CharSet = CharSet.Unicode)]
        public static extern SafeFindVolumeMountPointeHandle FindFirstVolumeMountPoint(
            String lpszRootPathName,
            StringBuilder lpszVolumeMountPoint,
            DWORD cchBufferLength);

        /* Continues a file search from a previous call to the FindFirstFile, FindFirstFileEx,
            or FindFirstFileTransacted functions. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindNextFileW", CharSet = CharSet.Unicode)]
        public static extern BOOL FindNextFile(
            SafeFindFileHandle hFindFile,
            out WIN32_FIND_DATA lpFindFileData);

        /* Continues enumerating the hard links to a file using the handle
            returned by a successful call to the FindFirstFileNameW function. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindNextFileNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL FindNextFileName(
            SafeFindFileNameHandle hFindStream,
            ref DWORD stringLength,
            ref WCHAR linkName);

        /* Requests that the operating system signal a change notification handle
            the next time it detects an appropriate change. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindNextVolumeW", CharSet = CharSet.Unicode)]
        public static extern BOOL FindNextVolume(
            SafeFindVolumeHandle hFindVolume,
            StringBuilder lpszVolumeName,
            DWORD cchBufferLength);

        /* Continues a mounted folder search started by a call to the FindFirstVolumeMountPoint function. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindNextVolumeMountPointW", CharSet = CharSet.Unicode)]
        public static extern BOOL FindNextVolumeMountPoint(
            SafeFindVolumeMountPointeHandle hFindVolumeMountPoint,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszVolumeMountPoint,
            DWORD cchBufferLength);

        /* Closes a file search handle opened by the FindFirstFile,
            FindFirstFileEx, FindFirstFileNameW, FindFirstFileNameTransactedW, FindFirstFileTransacted,
            FindFirstStreamTransactedW, or FindFirstStreamW functions. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FindClose(HANDLE hFindFile);

        /* Closes the specified volume search handle. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FindVolumeClose(
            SafeFindVolumeHandle hFindVolume);

        /* Closes the specified mounted folder search handle. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FindVolumeMountPointClose(
            SafeFindVolumeMountPointeHandle hFindVolumeMountPoint);

        //
        // Attributes
        //

        /* Retrieves file system attributes for a specified file or directory. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetFileAttributesW", CharSet = CharSet.Unicode)]
        public static extern FileAttributes GetFileAttributes(
            LPCTSTR lpFileName);

        /* Retrieves file system attributes for a specified file or directory. -- Extended */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetFileAttributesExW", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetFileAttributesEx(
            string lpFileName,
            GET_FILEEX_INFO_LEVELS fInfoLevelId,
            out WIN32_FILE_ATTRIBUTE_DATA fileData);

        /* Sets the attributes for a file or directory. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "SetFileAttributesW", CharSet = CharSet.Unicode)]
        public static extern DWORD SetFileAttributes(
            LPCTSTR lpFileName,
            FileAttributes dwFileAttributes);

        //
        // Size And Free Space
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetFileSize(SafeFileHandle hFile, out DWORD lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetFileSizeEx(SafeFileHandle hFile, out LARGE_INTEGER lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetDiskFreeSpaceW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetDiskFreeSpace(
            LPCTSTR lpRootPathName,
            out DWORD lpSectorsPerCluster,
            out DWORD lpBytesPerSector,
            out DWORD lpNumberOfFreeClusters,
            out DWORD lpTotalNumberOfClusters);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetDiskFreeSpaceExW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetDiskFreeSpaceEx(
            LPCTSTR lpDirectoryName,
            out LARGE_INTEGER lpFreeBytesAvailable,
            out LARGE_INTEGER lpTotalNumberOfBytes,
            out LARGE_INTEGER lpTotalNumberOfFreeBytes);

        //
        // CurrentDirectory
        //

        /// <summary>
        /// Retrieves the current directory for the current process
        /// </summary>
        /// <param name="nBufferLength">MAX_DEEP_PATH [32767]</param>
        /// <param name="lpBuffer">stringBuilder, length is [MAX_DEEP_PATH + 3]</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetCurrentDirectoryW", CharSet = CharSet.Unicode)]
        public static extern DWORD GetCurrentDirectory(
            DWORD nBufferLength, StringBuilder lpBuffer);

        /* Changes the current directory for the current process. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "SetCurrentDirectoryW", CharSet = CharSet.Unicode)]
        public static extern BOOL SetCurrentDirectory(
            string lpPathName);

        //
        // Event
        //

        /*
         * Usage ::
         * 
         * FindFirstChangeNotification
         * WaitForSingleObject
         * Print Result
         * 
         * While (True) >>
         * FindNextChangeNotification
         * WaitForSingleObject
         * Print Result
         * <<
         */

        /* Creates a change notification handle and sets up initial change notification filter conditions. */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "FindFirstChangeNotificationW", CharSet = CharSet.Unicode)]
        public static extern SafeFindChangeNotificationHandle FindFirstChangeNotification(
            LPCTSTR lpPathName,
            BOOL bWatchSubtree,
            NotifyFilter dwNotifyFilter);

        /* Requests that the operating system signal a change notification handle
            the next time it detects an appropriate change. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FindNextChangeNotification(
            SafeFindChangeNotificationHandle hChangeHandle);

        /* Stops change notification handle monitoring. */
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FindCloseChangeNotification(
            SafeFindChangeNotificationHandle hChangeHandle);

        /*
         * Usage ::
         * 
         * Create Handle to Directory
         * var hDirectory = kernel32.CreateFile(
                @"\\.\?:\Some Directory",
                FileAccess.FileListDirectory,
                FileShare.All,
                IntPtr.Zero,
                FileMode.Open,
                FileFlag.BackupSemantics,
                IntPtr.Zero);
         * 
         * While (ReadDirectoryChanges(hDirectory, ..., FILE_NOTIFY_CHANGE.All, out lpBytesReturned, IntPtr.Zero, null)) >>
         * Print Result
         * <<
         * 
         * Return.
         */

        /* Retrieves information that describes the changes within the specified directory.  */
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "ReadDirectoryChangesW", CharSet = CharSet.Unicode)]
        public static extern bool ReadDirectoryChanges(
            SafeFileHandle hDirectory,
            ref FILE_NOTIFY_INFORMATION lpBuffer,
            uint nBufferLength, // sizeof(FILE_NOTIFY_INFORMATION) + some bytes for the string
            bool bWatchSubtree,
            FILE_NOTIFY_CHANGE dwNotifyFilter,
            out uint lpBytesReturned,
            IntPtr lpOverlapped,
            FileIOCompletionRoutine lpCompletionRoutine);

        #endregion

        #region Address

        /// <summary>
        /// Loads the specified module into the address space of the calling process
        /// Alternative methood :: GetModuleHandle
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "LoadLibraryW", CharSet = CharSet.Unicode)]
        public static extern HMODULE LoadLibrary(LPCTSTR lpFileName);

        /// <summary>
        /// Loads the specified module into the address space of the calling process.
        /// The specified module may cause other modules to be loaded.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "LoadLibraryExW", CharSet = CharSet.Unicode)]
        public static extern HMODULE LoadLibraryEx(LPCTSTR fileName, HANDLE reserved, LoadLibraryFlags flags);

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, 
        /// if necessary, decrements its reference count
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL FreeLibrary(HMODULE hModule);

        /// <summary>
        /// Retrieves a module handle for the specified module
        /// </summary>
        /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file).</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetModuleHandleW", CharSet = CharSet.Unicode)]
        public static extern HMODULE GetModuleHandle(LPCTSTR lpModuleName);

        /// <summary>
        /// Retrieves a module handle for the specified module
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "GetModuleHandleExW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG dwFlags, LPCTSTR lpModuleName, out HMODULE phModule);

        /// <summary>
        /// Retrieves the fully-qualified path for the file that contains the specified module.
        /// </summary>
        /// <param name="hModule">If this parameter is NULL, GetModuleFileName retrieves the path of the executable file of the current process.</param>
        /// <param name="lpFilename">pointer to a buffer that receives the fully-qualified path of the module.</param>
        /// <param name="nSize">The size of the lpFilename buffer</param>
        /// <returns></returns>
        [PreserveSig]
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern DWORD GetModuleFileName(HMODULE hModule, StringBuilder lpFilename, DWORD nSize);

        /// <summary>
        /// Retrieves the address of an exported function or variable from the specified dynamic-link library (DLL).
        /// use Marshal.GetDelegateForFunctionPointer to convert it to Delegate
        /// </summary>
        /// <param name="hModule">Module from LoadLibrary[Ex] / GetModuleHandle[Ex]</param>
        /// <param name="lpProcName">function Name</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern FARPROC GetProcAddress(HMODULE hModule, string lpProcName);

        #endregion

        #region Memory Management
        // Heap Functions
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa366711(v=vs.85).aspx

        // Global and Local Functions 
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa366596(v=vs.85).aspx

        // Comparing Memory Allocation Methods
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa366533(v=vs.85).aspx

        //
        // manage memory in the process's default heap
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HANDLE GetProcessHeap();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HANDLE HeapCreate(
            HeapFlags uFlags, SIZE_T dwInitialSize, SIZE_T dwMaximumSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID HeapAlloc(
            HANDLE hHeap, HeapFlags dwFlags, SIZE_T dwBytes);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HGLOBAL HeapReAlloc(
            HANDLE hHeap, HeapFlags dwFlags, LPVOID lpMem, SIZE_T dwBytes);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL HeapDestroy(
            HANDLE hHeap);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL HeapFree(
            HANDLE hHeap, DWORD dwFlags, LPVOID lpMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID HeapLock(
            HANDLE hHeap);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL HeapUnlock(
            HANDLE hHeap);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SIZE_T HeapSize(
            HANDLE hHeap, DWORD dwFlags, LPCVOID lpMem);

        // HeapValidate
        // HeapCompact
        // HeapWalk

        //
        // manage memory in the process local heap
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HLOCAL LocalAlloc(
            LocalMemoryFlags uFlags, SIZE_T uBytes);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HLOCAL LocalReAlloc(
            HLOCAL hMem, SIZE_T uBytes, LocalMemoryFlags uFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HLOCAL LocalFree(
            HLOCAL hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID LocalLock(
            HLOCAL hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL LocalUnlock(
            HLOCAL hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SIZE_T LocalSize(
            HLOCAL hMem);

        //
        // manage memory in the process system heap
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HGLOBAL GlobalAlloc(
            GlobalMemoryFlags uFlags, SIZE_T dwBytes);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HGLOBAL GlobalReAlloc(
            HGLOBAL hMem, SIZE_T dwBytes, GlobalMemoryFlags uFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern HGLOBAL GlobalFree(
            HGLOBAL hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID GlobalLock(
            HGLOBAL hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL GlobalUnlock(
            HGLOBAL hMem);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SIZE_T GlobalSize(
            HGLOBAL hMem);

        //
        // manage memory in the process system heap
        // you to specify additional options for memory allocation.
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID VirtualAlloc(
            LPVOID lpAddress, SIZE_T dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern LPVOID VirtualAllocEx(
            SafeProcessHandle hProcess, LPVOID lpAddress, SIZE_T dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL VirtualFree(
            LPVOID lpAddress, SIZE_T dwSize, Operation dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL VirtualFreeEx(
            SafeProcessHandle hProcess, LPVOID lpAddress, SIZE_T dwSize, Operation dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL VirtualLock(
            LPVOID lpAddress, SIZE_T dwSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL VirtualUnlock(
            LPVOID lpAddress, SIZE_T dwSize);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL VirtualProtect(
            LPVOID lpAddress, SIZE_T dwSize, AllocationProtectEnum flNewProtect, out DWORD lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL VirtualProtectEx(
            SafeProcessHandle hProcess, LPVOID lpAddress, SIZE_T dwSize, AllocationProtectEnum flNewProtect, out DWORD lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SIZE_T VirtualQuery(
            LPCVOID lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, SIZE_T dwLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SIZE_T VirtualQueryEx(
            SafeProcessHandle hProcess, LPCVOID lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, SIZE_T dwLength);

        //
        // Misc [Read / Write / Copy / Move / Zero / Etc]
        //

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL ReadProcessMemory(
            SafeProcessHandle hProcess, LPCVOID lpBaseAddress, LPVOID lpBuffer, SIZE_T dwSize, out SIZE_T lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL WriteProcessMemory(
            SafeProcessHandle hProcess, LPCVOID lpBaseAddress, LPVOID lpBuffer, SIZE_T nSize, out SIZE_T lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void CopyMemory(
            PVOID destination, VOID source, SIZE_T length);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void MoveMemory(
            PVOID destination, VOID source, SIZE_T length);

        [DllImport("Kernel32.dll", SetLastError = false,
            EntryPoint = "RtlZeroMemory")]
        public static extern void ZeroMemory(
            PVOID dest, SIZE_T size);

        [DllImport("kernel32.dll", SetLastError = true,
            EntryPoint = "RtlSecureZeroMemory")]
        public static extern void SecureZeroMemory(
            PVOID ptr, SIZE_T cnt);

        [DllImport("Kernel32.dll", SetLastError = false,
            EntryPoint = "RtlFillMemory")]
        public static extern void FillMemory(
            PVOID destination, SIZE_T length, BYTE fill);
        #endregion

        #region Handle and Object
        /// <summary>
        /// Close Handle
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(
            IntPtr hObject);

        /// <summary>
        /// Duplicate Handle
        /// </summary>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool DuplicateHandle(
            SafeProcessHandle hSourceProcessHandle, IntPtr hSourceHandle,
            SafeProcessHandle hTargetProcessHandle, out IntPtr lpTargetHandle,
            ProcessAccessFlags dwDesiredAccess,
            bool bInheritHandle,
            DUPLICATE dwOptions);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetHandleInformation(
            IntPtr hObject,
            out HandleFlag lpdwFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetHandleInformation(
            IntPtr hObject,
            HandleFlag dwMask,
            HandleFlag dwFlags);
        #endregion

        #region Device Management

        // Calling DeviceIoControl
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363147(v=vs.85).aspx

        // Communications Control Codes
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363191(v=vs.85).aspx

        // Device Management Control Codes
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363226(v=vs.85).aspx

        // Directory Management Control Codes 
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363948(v=vs.85).aspx

        // Disk Management Control Codes 
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa363979(v=vs.85).aspx

        // File Management Control Codes
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa364230(v=vs.85).aspx

        // Power Management Control Codes 
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa373156(v=vs.85).aspx

        // Volume Management Control Codes 
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa365729(v=vs.85).aspx

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern BOOL DeviceIoControl(
            // CreateFile(@"\\.\DeviceName", NULL, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, NULL, NULL)
            SafeFileHandle hDevice,
            // Control Code
            DWORD dwIoControlCode,
            // In Buffer
            LPVOID lpInBuffer,
            DWORD nInBufferSize,
            // Out Buffer
            LPVOID lpOutBuffer,
            DWORD nOutBufferSize,
            // Result
            out DWORD lpBytesReturned,
            IntPtr lpOverlapped);

        #endregion
    }
    public static class dbghelp
    {
        #region Image Access

        /* Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file
            and returns the virtual address of the corresponding byte in the file. */
        [DllImport("Dbghelp.dll", SetLastError = true)]
        public unsafe static extern PVOID ImageRvaToVa(
            // NT headers
            IMAGE_NT_HEADERS_86* ntHeaders,
            // handle from MapViewOfFile
            PVOID Base,
            // dummy offset
            ULONG rva,
            // null
            [Optional, In] IMAGE_SECTION_HEADER **lastRvaSection);

        /* Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file
            and returns the virtual address of the corresponding byte in the file. */
        [DllImport("Dbghelp.dll", SetLastError = true,
            EntryPoint = "ImageRvaToVa")]
        public unsafe static extern PVOID ImageRvaToVaX64(
            // X64 NT headers
            IMAGE_NT_HEADERS_64* ntHeaders,
            // handle from MapViewOfFile
            PVOID Base,
            // dummy offset
            ULONG rva,
            // null
            [Optional, In] IMAGE_SECTION_HEADER** lastRvaSection);

        /* Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file
            and returns a pointer to the section table entry for that RVA. */
        [DllImport("Dbghelp.dll", SetLastError = true)]
        public unsafe static extern IMAGE_SECTION_HEADER* ImageRvaToSection(
            IMAGE_NT_HEADERS_86 ntHeaders,
            PVOID Base,
            ULONG rva);

        /* Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file
            and returns a pointer to the section table entry for that RVA. */
        [DllImport("Dbghelp.dll", SetLastError = true,
            EntryPoint = "ImageRvaToSection")]
        public unsafe static extern IMAGE_SECTION_HEADER* ImageRvaToSectionX64(
            IMAGE_NT_HEADERS_64 ntHeaders,
            PVOID Base,
            ULONG rva);

        /* Locates the IMAGE_NT_HEADERS structure in a PE image and returns a pointer to the data. */
        [DllImport("Dbghelp.dll", SetLastError = true)]
        public unsafe static extern IMAGE_NT_HEADERS_86* ImageNtHeader(
            PVOID imageBase);

        /* Locates the IMAGE_NT_HEADERS structure in a PE image and returns a pointer to the data. */
        [DllImport("Dbghelp.dll", SetLastError = true,
            EntryPoint = "ImageNtHeader")]
        public unsafe static extern IMAGE_NT_HEADERS_64* ImageNtHeaderX64(
            PVOID imageBase);

        #endregion
    }
    public static class advapi32
    {
        #region SID
        // Security Identifiers
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa379571(v=vs.85).aspx

        //
        // Base
        //

        /* Initialize Sid  */
        [DllImport("advapi32.dll", SetLastError = true)]
        public unsafe static extern BOOL InitializeSid(
            SafeSidHandle sid,
            SID_IDENTIFIER_AUTHORITY* pIdentifierAuthority,
            BYTE nSubAuthorityCount);

        /* Allocate & Initialize Sid  */
        [DllImport("advapi32.dll", SetLastError = true)]
        public unsafe static extern BOOL AllocateAndInitializeSid(
            SID_IDENTIFIER_AUTHORITY* pIdentifierAuthority,
            BYTE nSubAuthorityCount,
            DWORD dwSubAuthority0,
            DWORD dwSubAuthority1,
            DWORD dwSubAuthority2,
            DWORD dwSubAuthority3,
            DWORD dwSubAuthority4,
            DWORD dwSubAuthority5,
            DWORD dwSubAuthority6,
            DWORD dwSubAuthority7,
            out SafeSidHandle pSid);

        /* Copy Sid  */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL CopySid(
            DWORD nDestinationSidLength,
            [Out] SafeSidHandle pDestinationSid,
            [In] SafeSidHandle pSourceSid);

        /* Free Sid >> If the function fails,
            it returns a pointer to the SID structure represented by the pSid parameter. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern PVOID FreeSid(
            SafeSidHandle pSid);

        /* Check Sid */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL IsValidSid(
            SafeSidHandle pSid);

        /* Equal Sid */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL EqualSid(
            SafeSidHandle pSid1,
            SafeSidHandle pSid2);

        /* Equal Sid Prefix Values */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL EqualPrefixSid(
            SafeSidHandle pSid1,
            SafeSidHandle pSid2);

        //
        // Domain Sid
        //

        /* receives a security identifier (SID) and returns a SID representing the domain of that SID */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL GetWindowsAccountDomainSid(
            SafeSidHandle pSid,
            SafeSidHandle ppDomainSid,
            ref DWORD cbSid);

        /* determines whether two SIDs are from the same domain. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL EqualDomainSid(
            SafeSidHandle pSid1,
            SafeSidHandle pSid2,
            out BOOL pfEqual);

        //
        // Well Known Sid
        //

        /* creates a SID for predefined aliases. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL CreateWellKnownSid(
            WELL_KNOWN_SID_TYPE wellKnownSidType,
            SafeSidHandle domainSid,
            SafeSidHandle pSid,
            ref DWORD cbSid);

        /* compares a SID to a well-known SID and returns TRUE if they match. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL IsWellKnownSid(
            SafeSidHandle pSid,
            WELL_KNOWN_SID_TYPE wellKnownSidType);

        //
        // Length
        //

        /* returns the length, in bytes, of a valid security identifier (SID). */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern DWORD GetLengthSid(
            SafeSidHandle pSid);

        /* returns the length, in bytes, of a valid security identifier (SID). */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern DWORD GetSidLengthRequired(
            UCHAR nSubAuthorityCount);

        //
        // Authority
        //

        /* returns the length, in bytes, of a valid security identifier (SID). */
        [DllImport("advapi32.dll", SetLastError = true)]
        public unsafe static extern SID_IDENTIFIER_AUTHORITY* GetSidIdentifierAuthority(
            SafeSidHandle pSid);

        /* returns a pointer to the member in a security identifier (SID) structure 
            that contains the subauthority count. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr GetSidSubAuthorityCount(
            SafeSidHandle pSid);

        /* returns a pointer to a specified subauthority in a security identifier (SID).
            The subauthority value is a relative identifier (RID). */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern IntPtr GetSidSubAuthority(
            SafeSidHandle pSid,
            DWORD nSubAuthority);

        //
        // Sid <> String
        //

        /* Sid >> String */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "ConvertSidToStringSidW", CharSet = CharSet.Unicode)]
        public static extern BOOL ConvertSidToStringSid(
            SafeSidHandle sid,
            out IntPtr stringSid);

        /* String >> Sid */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "ConvertStringSidToSidW", CharSet = CharSet.Unicode)]
        public static extern BOOL ConvertStringSidToSid(
            LPCTSTR stringSid,
            out SafeSidHandle sid);

        //
        // Sid <> Account
        //
            
        /* Sid >> Account Name */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LookupAccountSidW", CharSet = CharSet.Unicode)]
        public static extern BOOL LookupAccountSid(
            LPCTSTR lpSystemName,
            SafeSidHandle sid,
            StringBuilder lpName,
            ref DWORD cchName,
            StringBuilder lpReferencedDomainName,
            ref DWORD cchReferencedDomainName,
            out SID_NAME_USE peUse);

        /* Account Name >> Sid */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LookupAccountNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL LookupAccountName(
            LPCTSTR lpSystemName,
            LPCTSTR lpAccountName,
            SafeSidHandle sid, 
            ref DWORD cbSid,
            StringBuilder referencedDomainName,
            ref DWORD cchReferencedDomainName,
            out SID_NAME_USE peUse);
        #endregion

        #region Token
        //
        // Base
        //

        /* Opens a handle to the access token associated with a process. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool OpenProcessToken(
            SafeProcessHandle processHandle,
            TokenAccess desiredAccess,
            out SafeTokenHandle tokenHandle);

        /* The DuplicateToken function creates a new access token that duplicates an existing token. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static bool DuplicateToken(
            SafeTokenHandle existingTokenHandle, 
            SECURITY_IMPERSONATION_LEVEL securityImpersonationLevel, 
            out SafeTokenHandle duplicateTokenHandle);

        /* 
            * The DuplicateTokenEx function creates a new access token that duplicates an existing token.
            * This function can create either a primary token or an impersonation token.
            */
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateTokenEx(
            SafeTokenHandle hExistingToken,
            TokenAccess dwDesiredAccess,
            IntPtr lpTokenAttributes,
            SECURITY_IMPERSONATION_LEVEL impersonationLevel,
            TOKEN_TYPE tokenType,
            out SafeTokenHandle phNewToken);

        //
        // Token Information
        //

        /*
         * retrieves a specified type of information about an access token.
         * The calling process must have appropriate access rights to obtain the information.
         * MUST LOOK AT TOKEN_INFORMATION_CLASS Output
         * 
         * *************************************************************************
         * first call needed to obtain Size, second call run after allocate the size
         * *************************************************************************
         *
         * to get access to Array List ... use this sample.
         * [&tokenInformation->TokenPrivileges]
         * without the >> & the result will be bad 
         * 
         * var tokenPrivileges = &tokenInformation->TokenPrivileges;
         * for (var i = 0; i < tokenPrivileges->PrivilegeCount; i++)
         * {
         *      var attrib = (&tokenPrivileges->First)[i];
         *      luidList.Add(attrib.Luid.ToString(), attrib.Attributes);
         * }
        */

        [DllImport("advapi32.dll", SetLastError = true)]
        public unsafe static extern bool GetTokenInformation(
            SafeTokenHandle tokenHandle,
            TOKEN_INFORMATION_CLASS tokenInformationClass,
            TOKEN_INFORMATION* tokenInformation,
            DWORD tokenInformationLength,
            out DWORD returnLength);

        [DllImport("advapi32.dll", SetLastError = true)]
        public unsafe static extern bool SetTokenInformation(
            SafeTokenHandle tokenHandle,
            TOKEN_INFORMATION_CLASS tokenInformationClass,
            TOKEN_INFORMATION* tokenInformation,
            DWORD tokenInformationLength);

        //
        // Token Membership
        //

        /* determines whether a specified security identifier (SID) is enabled in an access token. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL CheckTokenMembership(
            SafeTokenHandle tokenHandle,
            SafeSidHandle sidToCheck,
            out BOOL isMember);

        //
        // Thread Token
        //

        /*
            * opens the access token associated with a thread.
            * look at GetCurrentThread
            */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL OpenThreadToken(
            SafeThreadHandle threadHandle,
            TokenAccess desiredAccess,
            BOOL openAsSelf,
            out SafeTokenHandle tokenHandle);

        /* 
            * assigns an impersonation token to a thread.
            * The function can also cause a thread to stop using an impersonation token. 
            */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL SetThreadToken(
            SafeThreadHandle thread,
            SafeTokenHandle token);

        //
        // Restricted Token
        //

        /* creates a new access token that is a restricted version of an existing access token. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL CreateRestrictedToken(
            SafeTokenHandle  existingTokenHandle,
            RestrictedTokenFlags flags,
            DWORD disableSidCount,
            ref SID_AND_ATTRIBUTES sidsToDisable,
            DWORD deletePrivilegeCount,
            ref LUID_AND_ATTRIBUTES privilegesToDelete,
            DWORD restrictedSidCount,
            ref SID_AND_ATTRIBUTES sidsToRestrict,
            out SafeTokenHandle newTokenHandle
        );

        /* indicates whether a token contains a list of restricted security identifiers (SIDs). */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL IsTokenRestricted(
            SafeTokenHandle tokenHandle);

        //
        // Adjust Token 
        //

        /* enables or disables privileges in the specified access token. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool AdjustTokenPrivileges(
            SafeTokenHandle tokenHandle,
            BOOL disableAllPrivileges,
            ref TOKEN_PRIVILEGES newState,
            DWORD bufferLength,
            out TOKEN_PRIVILEGES previousState,
            out DWORD returnLength);

        /* enables or disables groups already present in the specified access token. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool AdjustTokenGroups(
            SafeTokenHandle tokenHandle,
            BOOL resetToDefault,
            ref TOKEN_GROUPS newState,
            DWORD bufferLength,
            out TOKEN_GROUPS previousState,
            out DWORD returnLength);

        //
        // ???
        //

        // NtCompareTokens << NTDLL
        // CheckTokenCapability << Kernel32 << Windows 8 
        #endregion

        #region Safer

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL SaferCreateLevel(
            SAFER_SCOPEID dwScopeId,
            SAFER_LEVELID dwLevelId,
            SAFER_LEVEL openFlags,
            out SafeLevelHandle pLevelHandle,
            LPVOID lpReserved);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL SaferCloseLevel(
            SafeLevelHandle hLevelHandle);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL SaferComputeTokenFromLevel(
            SafeLevelHandle hLevelHandle,
            [Optional] SafeTokenHandle inAccessToken,
            out SafeTokenHandle outAccessToken,
            SAFER_TOKEN dwFlags,
            LPVOID lpReserved);

        #endregion

        #region Privilege

        /// <summary>
        /// determines whether a specified set of privileges are enabled in an access token. 
        /// </summary>
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL PrivilegeCheck(
            SafeTokenHandle clientToken,
            ref PPRIVILEGE_SET requiredPrivileges,
            out BOOL pfResult);

        /// <summary>
        /// Privilege >> Display Name
        /// </summary>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LookupPrivilegeDisplayNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL LookupPrivilegeDisplayName(
            [Optional] LPCTSTR lpSystemName,
            LPCTSTR lpName,
            StringBuilder lpDisplayName,
            ref DWORD cchDisplayName,
            out DWORD lpLanguageId);

        /// <summary>
        /// LUID >> String
        /// </summary>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LookupPrivilegeNameW", CharSet = CharSet.Unicode)]
        public static extern bool LookupPrivilegeName(
            [Optional] string lpSystemName,
            ref LUID luid,
            StringBuilder lpName,
            out DWORD cchName);

        /// <summary>
        /// String >> LUID
        /// </summary>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LookupPrivilegeValueW", CharSet = CharSet.Unicode)]
        public static extern bool LookupPrivilegeValue(
            [Optional] string lpSystemName,
            string lpName,
            out LUID lpLuid);
        #endregion

        #region Registry
            
        //
        // Key
        //

        /* Establishes a connection to a predefined registry key on another computer. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegConnectRegistryW", CharSet = CharSet.Unicode)]
        public static extern LONG RegConnectRegistry(
            LPCTSTR lpMachineName,
            SafeRegistryHandle hKey,
            out SafeRegistryHandle phkResult);

        /* Opens the specified registry key. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegOpenKeyExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegOpenKeyEx(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey,
            DWORD mustBeZero,
            RegAccess samDesired,
            out SafeRegistryHandle phkResult);

        /* Creates the specified registry key. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegCreateKeyExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegCreateKeyEx(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey,
            DWORD reserved,
            string mustBeNull,
            RegOptions dwOptions,
            RegAccess samDesired,
            IntPtr lpSecurityAttributes,
            out SafeRegistryHandle phkResult,
            out RegDisposition lpdwDisposition);

        /* Deletes a subkey and its values. Note that key names are not case sensitive. */
            [DllImport("Advapi32.dll", SetLastError = true,
                EntryPoint = "RegDeleteKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegDeleteKey(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey);

        /* Deletes a subkey and its values. Note that key names are not case sensitive. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegDeleteKeyExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegDeleteKeyEx(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey,
            RegAccess samDesired,
            DWORD reserved);

            /* Writes all the attributes of the specified open registry key into the registry. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegFlushKey(
            SafeRegistryHandle hKey);

        /* Retrieves information about the specified registry key. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegQueryInfoKey(
            SafeRegistryHandle hKey,
            [MarshalAs(UnmanagedType.LPTStr)]string lpClass,    // NULL
            ref DWORD lpcClass,                                 // 0
            DWORD lpReserved,                                   // 0
            out DWORD lpcSubKeys,
            out DWORD lpcMaxSubKeyLen,
            out DWORD lpcMaxClassLen,
            out DWORD lpcValues,
            out DWORD lpcMaxValueNameLen,
            out DWORD lpcMaxValueLen,
            out DWORD lpcbSecurityDescriptor,
            out Filetime lpftLastWriteTime);

        /* Closes a handle to the specified registry key. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegCloseKey(
            SafeRegistryHandle hKey);

        /* Enumerates the subkeys of the specified open registry key. 
            The function retrieves information about one subkey each time it is called. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegEnumKeyExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegEnumKeyEx(
            SafeRegistryHandle hkey,
            DWORD dwIndex,
            StringBuilder lpName,
            ref DWORD lpcName,
            IntPtr lpReserved,
            StringBuilder lpClass,
            ref DWORD lpcClass,
            out Filetime lpftLastWriteTime);

        //
        // Value
        //

        /*
            * Retrieves the type and data for the specified value name associated with an open registry key. 
            * To ensure that any string values (REG_SZ, REG_MULTI_SZ, and REG_EXPAND_SZ) returned are null-terminated, use the RegGetValue function.
            */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegQueryValueExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegQueryValueEx(
            SafeRegistryHandle hKey,
            LPCTSTR lpValueName,
            IntPtr lpReserved,
            out RegType lpType,
            IntPtr lpData,
            ref DWORD lpcbData);

        /* Retrieves the type and data for the specified registry value. */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegGetValueW", CharSet = CharSet.Unicode)]
        public static extern LONG RegGetValue(
            SafeRegistryHandle hkey,
            LPCTSTR lpSubKey,
            LPCTSTR lpValue,
            RegFlags dwFlags,
            out RegType pdwType,
            PVOID pvData,
            ref DWORD pcbData);

        /* Retrieves the type and data for a list of value names associated with an open registry key. */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegQueryMultipleValuesW", CharSet = CharSet.Unicode)]
        public unsafe static extern LONG RegQueryMultipleValues(
            SafeRegistryHandle hKey,
            // AllocHGlobal(VALENT.Size * ?), ?   >> must set 've_valuename' for each Cell
            VALENT* valList, DWORD numVals,
            // first call needed to get the size we need    >> lpValueBuf = AllocHGlobal(ldwTotsize)
            IntPtr lpValueBuf, ref DWORD ldwTotsize);

        /* Sets the data and type of a specified value under a registry key. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegSetValueExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegSetValueEx(
            SafeRegistryHandle hkey,
            LPCTSTR lpValueName, 
            DWORD reserved,
            RegType dwType,
            IntPtr lpData, DWORD cbData);

        /* Sets the data for the specified value in the specified registry key and subkey. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegSetKeyValueW", CharSet = CharSet.Unicode)]
        public static extern LONG RegSetKeyValue(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey, LPCTSTR lpValueName,
            RegType dwType,
            LPCVOID lpData, DWORD cbData);

        /* Removes a named value from the specified registry key. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegDeleteValueW", CharSet = CharSet.Unicode)]
        public static extern LONG RegDeleteValue(
            SafeRegistryHandle hKey,
            LPCTSTR lpValueName);

        /* Removes the specified value from the specified registry key and subkey. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegDeleteKeyValueW", CharSet = CharSet.Unicode)]
        public static extern LONG RegDeleteKeyValue(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey,
            LPCTSTR lpValueName);

        /* Enumerates the values for the specified open registry key. 
            The function copies one indexed value name and data block for the key each time it is called. */
        /* first call needed to obtain Size, second call run after allocate the size */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegEnumValueW", CharSet = CharSet.Unicode)]
        public static extern LONG RegEnumValue(
            SafeRegistryHandle hkey,
            DWORD dwIndex,
            [MarshalAs(UnmanagedType.LPTStr)]StringBuilder lpValueName,
            ref DWORD lpcchValueName,
            IntPtr lpReserved,
            out RegType lpType,
            IntPtr lpData,
            ref DWORD lpcbData);
            

        //
        // File
        //

        /* Copies the specified registry key, along with its values and subkeys,
            to the specified destination key. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegCopyTreeW", CharSet = CharSet.Unicode)]
        public static extern LONG RegCopyTree(
            SafeRegistryHandle hKeySrc,
            LPCTSTR lpFile,
            SafeRegistryHandle hKeyDest);

        /* Saves the specified key and all of its subkeys and values to a new file,
            in the standard format. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegSaveKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegSaveKey(
            SafeRegistryHandle hkey,
            LPCTSTR lpFile,
            IntPtr lpSecurityAttributes);

        /* Saves the specified key and all of its subkeys and values to a new file,
            in the standard format. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegSaveKeyExW", CharSet = CharSet.Unicode)]
        public static extern LONG RegSaveKeyEx(
            SafeRegistryHandle hkey,
            LPCTSTR lpFile,
            IntPtr lpSecurityAttributes,
            RegFormat Flags);

        /* Reads the registry information in a specified file and copies it over the specified key.
            This registry information may be in the form of a key and multiple levels of subkeys. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegRestoreKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegRestoreKey(
            SafeRegistryHandle hkey,
            LPCTSTR lpFile,
            RegRestore dwFlags);

        /* Replaces the file backing a registry key and all its subkeys with another file,
            so that when the system is next started, the key and subkeys will have the values stored in the new file. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegReplaceKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegReplaceKey(
            SafeRegistryHandle hkey,
            LPCTSTR lpSubKey,
            LPCTSTR lpNewFile,
            LPCTSTR lpOldFile);

        //
        // Hive
        //

        /* Loads the specified registry hive. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegLoadAppKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegLoadAppKey(
            LPCTSTR lpFile,
            out SafeRegistryHandle phkResult,
            RegAccess samDesired,
            // 0x00000001 == REG_PROCESS_APPKEY
            DWORD mustBeOne,
            DWORD reserved);

        /* Creates a subkey under HKEY_USERS or HKEY_LOCAL_MACHINE
            and loads the data from the specified registry hive into that subkey. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegLoadKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegLoadKey(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey,
            LPCTSTR lpFile);

        /* Unloads the specified registry key and its subkeys from the registry. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegUnLoadKeyW", CharSet = CharSet.Unicode)]
        public static extern LONG RegUnLoadKey(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey);

        //
        // ReflectionKey
        //

        /* Disables registry reflection for the specified key. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegDisableReflectionKey(
            SafeRegistryHandle hBase);

        /* Restores registry reflection for the specified disabled key.  */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegEnableReflectionKey(
            SafeRegistryHandle hBase);

        /* Determines whether reflection has been disabled or enabled for the specified key.  */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegQueryReflectionKey(
            SafeRegistryHandle hBase,
            out BOOL bIsReflectionDisabled);

        //
        // Tree
        //

        /* Deletes the subkeys and values of the specified key recursively. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "RegDeleteTreeW", CharSet = CharSet.Unicode)]
        public static extern LONG RegDeleteTree(
            SafeRegistryHandle hKey,
            LPCTSTR lpSubKey);

        //
        // Event
        //

        /*
         * Usage ::
         * 
         * While (RegNotifyChangeKeyValue != 0) >>
         * Print Result
         * <<
         */

        /*
         * you also can use WMI for that task
         * RegistryTreeChangeEvent
         * RegistryKeyChangeEvent
         * RegistryValueChangeEvent
         * 
         * take a look at this project ::
         * Asynchronous Registry Notification Using Strongly-typed WMI Classes in .NET
         * http://www.codeproject.com/Articles/30624/Asynchronous-Registry-Notification-Using-Strongly
         */

        /* Notifies the caller about changes to the attributes or contents of a specified registry key.
            to specific non blobking Mode set fAsynchronous = True and set hEvent = CreateEvent()*/
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegNotifyChangeKeyValue(
            SafeRegistryHandle hKey,
            BOOL bWatchSubtree,
            RegNotifyFilter dwNotifyFilter,
            [Optional]SafeEventHandle hEvent, // depend on fAsynchronous value
            BOOL fAsynchronous);

        #endregion

        #region Service
            
        //
        // SCManager
        //

        /* Establishes a connection to the service control manager on the specified computer
            and opens the specified service control manager database. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "OpenSCManagerW", CharSet = CharSet.Unicode)]
        public static extern SafeServiceManagerHandle OpenSCManager(
            LPCTSTR lpMachineName,
            LPCTSTR lpDatabaseName,
            SCM_ACCESS dwDesiredAccess);

        /* Closes a handle to a service control manager or service object. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL CloseServiceHandle(
            SafeServiceManagerHandle hScObject);

        /* Retrieves the display name of the specified service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "GetServiceDisplayNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetServiceDisplayName(
            SafeServiceManagerHandle hScManager,
            LPCTSTR lpServiceName,
            StringBuilder lpDisplayName,
            ref DWORD lpcchBuffer);

        /* Retrieves the service name of the specified service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "GetServiceKeyNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetServiceKeyName(
            SafeServiceManagerHandle hScManager,
            LPCTSTR lpDisplayName,
            StringBuilder lpServiceName,
            ref DWORD lpcchBuffer);

        //
        // Service
        //

        /* Opens an existing service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "OpenServiceW", CharSet = CharSet.Unicode)]
        public static extern SafeServiceHandle OpenService(
            SafeServiceManagerHandle hScManager,
            LPCTSTR lpServiceName,
            SCM_ACCESS dwDesiredAccess);

        /* Creates a service object and adds it to the specified service control manager database. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "CreateServiceW", CharSet = CharSet.Unicode)]
        public static extern SafeServiceHandle CreateService(
            SafeServiceManagerHandle hScManager,
            LPCTSTR lpServiceName,
            LPCTSTR lpDisplayName,
            SCM_ACCESS dwDesiredAccess,
            ServiceType dwServiceType,
            StartType dwStartType,
            ErrorControl dwErrorControl,
            LPCTSTR lpBinaryPathName,
            LPCTSTR lpLoadOrderGroup,
            out DWORD lpdwTagId,
            LPCTSTR lpDependencies,
            LPCTSTR lpServiceStartName,
            LPCTSTR lpPassword);

        /* Marks the specified service for deletion from the service control manager database. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL DeleteService(
            SafeServiceHandle hService);

        /* Starts a service. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL StartService(
            SafeServiceHandle hService,
            DWORD dwNumServiceArgs,
            LPCTSTR[] lpServiceArgVectors);

        //
        // Get
        //

        /* Retrieves the current status of the specified service based on the specified information level. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public unsafe static extern BOOL QueryServiceStatusEx(
            SafeServiceHandle hService,
            DWORD reserved,
            SERVICE_STATUS_PROCESS* lpBuffer,
            DWORD cbBufSize,
            out DWORD pcbBytesNeeded);

        /* Retrieves the configuration parameters of the specified service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "QueryServiceConfigW", CharSet = CharSet.Unicode)]
        public unsafe static extern BOOL QueryServiceConfig(
            SafeServiceHandle hService,
            QUERY_SERVICE_CONFIG* lpServiceConfig,
            DWORD cbBufSize,
            out DWORD pcbBytesNeeded);

        /* Retrieves the optional configuration parameters of the specified service. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL QueryServiceConfig2(
            SafeServiceHandle hService,
            InfoLevel dwInfoLevel,
            IntPtr lpBuffer,
            DWORD cbBufSize,
            out DWORD pcbBytesNeeded);

        //
        // Set
        //

        /* Changes the configuration parameters of a service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "ChangeServiceConfigW", CharSet = CharSet.Unicode)]
        public static extern BOOL ChangeServiceConfig(
            SafeServiceHandle hService,
            ServiceType dwServiceType,
            StartType dwStartType,
            ErrorControl dwErrorControl,
            LPCTSTR lpBinaryPathName,
            LPCTSTR lpLoadOrderGroup,
            out DWORD lpdwTagId,
            LPCTSTR lpDependencies,
            LPCTSTR lpServiceStartName,
            LPCTSTR lpPassword,
            LPCTSTR lpDisplayName);

        /* Changes the configuration parameters of a service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "ChangeServiceConfig2W", CharSet = CharSet.Unicode)]
        public static extern BOOL ChangeServiceConfig2(
            SafeServiceHandle hService,
            InfoLevel dwInfoLevel,
            LPVOID lpInfo);

        /* Sends a control code to a service. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern BOOL ControlService(
            SafeServiceHandle hService,
            ServiceControl dwControl,
            out SERVICE_STATUS lpServiceStatus);

        /* Sends a control code to a service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "ControlServiceExW", CharSet = CharSet.Unicode)]
        public static extern BOOL ControlServiceEx(
            SafeServiceHandle hService,
            ServiceControl dwControl,
            DWORD mustBeOne,
            out SERVICE_CONTROL_STATUS_REASON_PARAMS pControlParams);

        // Notify
            
        /* Sends a control code to a service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "NotifyServiceStatusChangeW", CharSet = CharSet.Unicode)]
        public static extern DWORD NotifyServiceStatusChange(
            SafeServiceHandle hService,
            Enum.SERVICE_NOTIFY dwNotifyMask,
            ref Struct.SERVICE_NOTIFY pNotifyBuffer);

        /* Sends a control code to a service. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "NotifyServiceStatusChangeW", CharSet = CharSet.Unicode)]
        public static extern DWORD NotifyServiceStatusChange(
            SafeServiceManagerHandle hService,
            Enum.SERVICE_NOTIFY dwNotifyMask,
            ref Struct.SERVICE_NOTIFY pNotifyBuffer);

        //
        // Ctrl
        //

        // StartServiceCtrlDispatcher
        // RegisterServiceCtrlHandlerEx
        // SetServiceStatus

        //
        // Enum
        //

        /* Enumerates services in the specified service control manager database. 
            The name and status of each service are provided, 
            along with additional data based on the specified information level. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "EnumServicesStatusExW", CharSet = CharSet.Unicode)]
        public unsafe static extern BOOL EnumServicesStatusEx(
            SafeServiceManagerHandle hScManager,
            DWORD reserved,
            ServiceType dwServiceType,
            ServiceState dwServiceState,
            //ENUM_SERVICE_STATUS_PROCESS[] lpServices,
            ENUM_SERVICE_STATUS_PROCESS* lpServices,
            DWORD cbBufSize,
            out DWORD pcbBytesNeeded,
            out DWORD lpServicesReturned,
            ref DWORD lpResumeHandle,
            LPCTSTR pszGroupName);

        /* Retrieves the name and status of each service that depends on the specified service; 
            that is, the specified service must be running before the dependent services can run. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "EnumDependentServicesW", CharSet = CharSet.Unicode)]
        public unsafe static extern BOOL EnumDependentServices(
            SafeServiceHandle hService,
            ServiceState dwServiceState,
            // ENUM_SERVICE_STATUS[] lpServices
            ENUM_SERVICE_STATUS* lpServices,
            DWORD cbBufSize,
            out DWORD pcbBytesNeeded,
            out DWORD lpServicesReturned);
        #endregion

        #region Shutdown
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode,
            EntryPoint = "InitiateShutdownW", SetLastError = true)]
        public static extern bool InitiateShutdown(
            String lpMachineName,
            String lpMessage,
            DWORD dwGracePeriod,
            ShutdownFlags dwShutdownFlags,
            ShutdownReason dwReason);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode,
            EntryPoint = "InitiateSystemShutdownW", SetLastError = true)]
        public static extern bool InitiateSystemShutdown(
            String lpMachineName,
            String lpMessage,
            DWORD dwTimeout, 
            BOOL bForceAppsClosed,
            BOOL bRebootAfterShutdown);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode,
            EntryPoint = "InitiateSystemShutdownExW", SetLastError = true)]
        public static extern bool InitiateSystemShutdownEx(
            String lpMachineName,
            String lpMessage,
            DWORD dwTimeout,
            BOOL bForceAppsClosed,
            BOOL bRebootAfterShutdown,
            ShutdownReason dwReason);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode,
            EntryPoint = "AbortSystemShutdownW", SetLastError = true)]
        public static extern bool AbortSystemShutdown(
            String lpMachineName);
        #endregion

        #region System Information
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "GetUserNameW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetUserName(
            StringBuilder lpBuffer, ref DWORD lpnSize);
        #endregion

        #region Process

        /// <summary>
        /// Creates a new process and its primary thread.
        /// under specified credentials (user, domain, and password).
        /// It can optionally load the user profile for the specified user.
        /// [also look at CreateProcess definition]
        /// </summary>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "CreateProcessWithLogonW", CharSet = CharSet.Unicode)]
        public static extern bool CreateProcessWithLogon(
            String lpUsername,
            String lpDomain,
            String lpPassword,
            LogonFlags dwLogonFlags,
            String lpApplicationName,
            String lpCommandLine,
            CreationFlags dwCreationFlags,
            Struct.Environment lpEnvironment,
            String lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInfo);

        /// <summary>
        /// Creates a new process and its primary thread.
        /// under security context of the specified token.
        /// The process that calls CreateProcessWithTokenW must have the SE_IMPERSONATE_NAME privilege.
        /// It can optionally load the user profile for the specified user.
        /// [also look at CreateProcess definition]
        /// </summary>
        /// <param name="hToken">handle from :: OpenToken, DuplicateTokenEx, LogonUser</param>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "CreateProcessWithTokenW", CharSet = CharSet.Unicode)]
        public static extern bool CreateProcessWithToken(
            SafeTokenHandle hToken,
            LogonFlags dwLogonFlags,
            String lpApplicationName,
            String lpCommandLine,
            CreationFlags dwCreationFlags,
            IntPtr lpEnvironment,
            String lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInfo);

        /// <summary>
        /// Creates a new process and its primary thread.
        /// The new process runs in the security context of the user represented by the specified token.
        /// The process that calls CreateProcessAsUser must have the SE_IMPERSONATE_NAME privilege.
        /// [also look at CreateProcess definition]
        /// </summary>
        /// <param name="hToken">handle from OpenToken, LogonUser, DuplicateTokenEx</param>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "CreateProcessAsUserW", CharSet = CharSet.Unicode)]
        public static extern bool CreateProcessAsUser(
            SafeTokenHandle hToken,
            LPCTSTR lpApplicationName,
            LPCTSTR lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            BOOL bInheritHandles,
            CreationFlags dwCreationFlags,
            Struct.Environment lpEnvironment,
            LPCTSTR lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);
        #endregion

        #region User Login
        /// <summary>
        /// The LogonUser function attempts to log a user on to the local computer.
        /// output is token Handle
        /// </summary>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LogonUserW", CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(
            string lpszUsername, 
            string lpszDomain, 
            string lpszPassword, 
            LogonType dwLogonType,
            LogonProvider dwLogonProvider, 
            out SafeTokenHandle phToken);

        /// <summary>
        /// The LogonUser function attempts to log a user on to the local computer.
        /// output is token Handle
        /// </summary>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LogonUserExW", CharSet = CharSet.Unicode)]
        public unsafe static extern bool LogonUserEx(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            LogonType dwLogonType,
            LogonProvider dwLogonProvider,
            out SafeTokenHandle phToken,
            out SafeSidHandle ppLogonSid,
            out PVOID* ppProfileBuffer,
            out DWORD pdwProfileLength,
            out QUOTA_LIMITS pQuotaLimits);

        /// <summary>
        /// The LogonUser function attempts to log a user on to the local computer.
        /// output is token Handle
        /// </summary>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "LogonUserExExW", CharSet = CharSet.Unicode)]
        public unsafe static extern bool LogonUserExEx(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            LogonType dwLogonType,
            LogonProvider dwLogonProvider,
            ref TOKEN_GROUPS pTokenGroups,
            out SafeTokenHandle phToken,
            out SafeSidHandle* ppLogonSid,
            out PVOID* ppProfileBuffer,
            out DWORD pdwProfileLength,
            out QUOTA_LIMITS pQuotaLimits); 
        #endregion

        #region Impersonate
        /* impersonates the security context of the calling process. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static BOOL ImpersonateSelf(
            SECURITY_IMPERSONATION_LEVEL impersonationLevel);

        // LogonUser / OpenProcessToken / OpenThreadToken / DuplicateToken -> ImpersonateLoggedOnUser -> OK
        /* lets the calling thread impersonate the security context of a logged-on user. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern int ImpersonateLoggedOnUser(
            SafeTokenHandle hToken);

        /* impersonate the system's anonymous logon token. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static BOOL ImpersonateAnonymousToken(
            SafeThreadHandle threadHandle);

        /* impersonates a named-pipe client application. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static BOOL ImpersonateNamedPipeClient(
            SafePipeHandle hNamedPipe);

        /* terminates the impersonation of a client application. */
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static BOOL RevertToSelf();
        #endregion

        /*
            // [^]                 [OBJECTS_AND_SID, OBJECTS_AND_NAME, SafeSidHandle, Name]
            // [^]                 [    TRUSTEE    ][   SAME   ]
            // [^]                 [EXPLICIT_ACCESS][ACE_HEADER]
            // [^] [SafeSidHandle] [SafeAclHandle]
            // [^] SafeSecurityDescriptorHandle
            // [^] SECURITY_ATTRIBUTES
         */

        #region Audit

        // Enum :: Categories //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditEnumerateCategories(
            out GUID* ppAuditCategoriesArray,
            out ULONG pCountReturned);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool AuditLookupCategoryGuidFromCategoryId(
            POLICY_AUDIT_EVENT_TYPE auditCategoryId,
            out Guid pAuditCategoryGuid);

        /* Name */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "AuditLookupCategoryNameW", CharSet = CharSet.Unicode)]
        public static extern bool AuditLookupCategoryName(
            ref GUID pAuditCategoryGuid,
            out string ppszCategoryName);

        /* POLICY_AUDIT_EVENT_TYPE */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool AuditLookupCategoryIdFromCategoryGuid(
            ref GUID pAuditCategoryGuid,
            out POLICY_AUDIT_EVENT_TYPE pAuditCategoryId);

        // Enum :: Sub Categories //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditEnumerateSubCategories(
            ref GUID pAuditCategoryGuid,
            bool bRetrieveAllSubCategories,
            out GUID* ppAuditSubCategoriesArray,
            out ULONG pCountReturned);

        /* Name */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "AuditLookupSubCategoryNameW", CharSet = CharSet.Unicode)]
        public static extern bool AuditLookupSubCategoryName(
            ref GUID pAuditCategoryGuid,
            out string ppszSubCategoryName);

        // Enum :: PerUserPolicy //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditEnumeratePerUserPolicy(
            out POLICY_AUDIT_SID_ARRAY* ppAuditSidArray);

        // System Policy :: { Get, Set } //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditQuerySystemPolicy(
            ref Guid pSubCategoryGuids,
            ULONG policyCount,
            out AUDIT_POLICY_INFORMATION* ppAuditPolicy);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditSetSystemPolicy(
            AUDIT_POLICY_INFORMATION* pAuditPolicy,
            ULONG policyCount);

        // Per User Policy :: { Get, Set } //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditQueryPerUserPolicy(
            SafeSidHandle pSid,
            ref Guid pSubCategoryGuids,
            ULONG policyCount,
            out AUDIT_POLICY_INFORMATION* ppAuditPolicy);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditSetPerUserPolicy(
            SafeSidHandle pSid,
            AUDIT_POLICY_INFORMATION* pAuditPolicy,
            ULONG policyCount);

        // Security :: { Get, Set } //

        /* take Privileges before */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool AuditQuerySecurity(
            SECURITY_INFORMATION securityInformation,
            out SafeSecurityDescriptorHandle ppSecurityDescriptor);

        /* take Privileges before */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool AuditSetSecurity(
            SECURITY_INFORMATION securityInformation,
            SafeSecurityDescriptorHandle ppSecurityDescriptor);

        // Effective Policy :: { Get } //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditComputeEffectivePolicyBySid(
            SafeSidHandle pSid,
            ref GUID pSubCategoryGuids,
            ULONG policyCount,
            out AUDIT_POLICY_INFORMATION* pAuditPolicy);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool AuditComputeEffectivePolicyByToken(
            SafeTokenHandle hTokenHandle,
            ref GUID pSubCategoryGuids,
            ULONG policyCount,
            out AUDIT_POLICY_INFORMATION* pAuditPolicy);

        // Free //

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern VOID AuditFree(
            PVOID buffer);

        #endregion

        #region Trustee Form

        // not really necessary
        // it can be done with Get/Set properties
        // and about the BuildTrusteeWithName, ...
        // they really stupid function

        // GetTrusteeForm
        // GetTrusteeName
        // GetTrusteeType

        // BuildTrusteeWithName
        // BuildTrusteeWithObjectsAndName
        // BuildTrusteeWithObjectsAndSid
        // BuildTrusteeWithSid 

        #endregion

        #region Security Descriptor

        /* Base */

        // must allocate sizeof(SECURITY_DESCRIPTOR)
        // before call InitializeSecurityDescriptor

        // can be directly edit / access
        // using (SECURITY_DESCRIPTOR*)handle

        /* initializes a security descriptor in absolute format */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool InitializeSecurityDescriptor(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            DWORD dwRevision);

        /* creates a security descriptor in absolute format by using
            a security descriptor in self-relative format as a template */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool MakeAbsoluteSD(
            // Relative SD
            SafeSecurityDescriptorHandle pSelfRelativeSD,
            // SafeSecurityDescriptorHandle.SecurityDescriptor
            [Optional, Out] SECURITY_DESCRIPTOR* pAbsoluteSD,
            ref DWORD lpdwAbsoluteSDSize,
            // DACL
            [Optional, Out] SafeAclHandle pDacl,
            ref DWORD lpdwDaclSize,
            // SACL
            [Optional, Out] SafeAclHandle pSacl,
            ref DWORD lpdwSaclSize,
            // OWNER
            [Optional, Out] SafeSidHandle pOwner,
            ref DWORD lpdwOwnerSize,
            // GROUP
            [Optional, Out] SafeSidHandle pPrimaryGroup,
            ref DWORD lpdwPrimaryGroupSize);

        // can't be directly edit / access
        // using (SECURITY_DESCRIPTOR*)handle

        /* creates a self-relative security descriptor */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern Win32Error BuildSecurityDescriptor(
                TRUSTEE* pOwner, TRUSTEE* pGroup,
                ULONG cCountOfAccessEntries, EXPLICIT_ACCESS* pListOfAccessEntries,
                ULONG cCountOfAuditEntries, EXPLICIT_ACCESS* pListOfAuditEntries,
                SafeSecurityDescriptorHandle pOldSD,
                out ULONG pSizeNewSD, out SafeSecurityDescriptorHandle pNewSD);

        /* creates a security descriptor in self-relative format by using
            a security descriptor in absolute format as a template. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool MakeSelfRelativeSD(
            SECURITY_DESCRIPTOR* pAbsoluteSD,
            [Optional, Out] SafeSecurityDescriptorHandle pSelfRelativeSD,
            ref DWORD lpdwBufferLength);

        // Validate

        /* determines whether the components of a security descriptor are valid. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL IsValidSecurityDescriptor(
            SafeSecurityDescriptorHandle pSecurityDescriptor);

        /* String */

        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "ConvertSecurityDescriptorToStringSecurityDescriptorW", CharSet = CharSet.Unicode)]
        public static extern BOOL ConvertSecurityDescriptorToStringSecurityDescriptor(
            SafeSecurityDescriptorHandle securityDescriptor,
            DWORD requestedStringSdRevision, // 0x1 [SDDL_REVISION_1]
            SECURITY_INFORMATION securityInformation,
            ref string stringSecurityDescriptor,
            out ULONG stringSecurityDescriptorLen);

        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "ConvertStringSecurityDescriptorToSecurityDescriptorW", CharSet = CharSet.Unicode)]
        public static extern BOOL ConvertStringSecurityDescriptorToSecurityDescriptor(
            string stringSecurityDescriptor,
            DWORD stringSdRevision, // 0x1 [SDDL_REVISION_1]
            out SafeSecurityDescriptorHandle securityDescriptor,
            out LONG securityDescriptorSize);

        // ignore [not really necessary]

        // RtlSetSaclSecurityDescriptor
        // LookupSecurityDescriptorParts

        #endregion

        #region Security Descriptor :: Acl

        /* Base */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool InitializeAcl(
            SafeAclHandle pAcl,
            DWORD nAclLength,
            DWORD dwAclRevision);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool IsValidAcl(
            SafeAclHandle pAcl);

        /* Information */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL GetAclInformation(
            SafeAclHandle pAcl,
            PVOID pAclInformation,
            DWORD nAclInformationLength,
            ACL_INFORMATION_CLASS dwAclInformationClass);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL SetAclInformation(
            SafeAclHandle pAcl,
            LPVOID pAclInformation,
            DWORD nAclInformationLength,
            ACL_INFORMATION_CLASS dwAclInformationClass);

        /* Entries [Explicit] */

        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "BuildExplicitAccessWithNameW", CharSet = CharSet.Unicode)]
        public static extern void BuildExplicitAccessWithName(
            ref EXPLICIT_ACCESS pExplicitAccess,
            [Optional]string pTrusteeName, // pMultipleTrustee, MultipleTrusteeOperation, TrusteeForm, TrusteeType
            ACCESS_MASK accessPermissions,
            ACCESS_MODE accessMode,
            AceFlags inheritance);

        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "GetExplicitEntriesFromAclW", CharSet = CharSet.Unicode)]
        public unsafe static extern DWORD GetExplicitEntriesFromAcl(
            SafeAclHandle pacl,
            out ULONG pcCountOfExplicitEntries,
            out EXPLICIT_ACCESS* pListOfExplicitEntries);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern DWORD SetEntriesInAcl(
            ULONG cCountOfExplicitEntries,
            EXPLICIT_ACCESS* pListOfExplicitEntries,
            SafeAclHandle oldAcl, // can be null
            out SafeAclHandle newAcl);

        /* Entries [Header] */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern BOOL AddAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            DWORD dwStartingAceIndex,
            ACE_HEADER_BASE* pAceList,
            DWORD nAceListLength);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern BOOL GetAce(
            SafeAclHandle pAcl,
            DWORD dwAceIndex,
            out ACE_HEADER_BASE* pAce);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern BOOL FindFirstFreeAce(
            SafeAclHandle pAcl,
            out ACE_HEADER_BASE* pAce);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL DeleteAce(
            SafeAclHandle pAcl,
            DWORD dwAceIndex);

        /* Entries [Header] ::  Wrapper */

        #region Allowed
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAccessAllowedAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            ACCESS_MASK accessMask,
            SafeSidHandle pSid);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAccessAllowedAceEx(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            AceFlags aceFlags,
            ACCESS_MASK accessMask,
            SafeSidHandle pSid);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAccessAllowedObjectAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            AceFlags aceFlags,
            ACCESS_MASK accessMask,
            ref GUID objectTypeGuid,
            ref GUID inheritedObjectTypeGuid,
            SafeSidHandle pSid);
        #endregion

        #region Denied
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAccessDeniedAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            ACCESS_MASK accessMask,
            SafeSidHandle pSid);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAccessDeniedAceEx(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            AceFlags aceFlags,
            ACCESS_MASK accessMask,
            SafeSidHandle pSid);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAccessDeniedObjectAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            AceFlags aceFlags,
            ACCESS_MASK accessMask,
            ref GUID objectTypeGuid,
            ref GUID inheritedObjectTypeGuid,
            SafeSidHandle pSid);
        #endregion

        #region Audit
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAuditAccessAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            ACCESS_MASK accessMask,
            SafeSidHandle pSid,
            BOOL bAuditSuccess,
            BOOL bAuditFailure);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAuditAccessAceEx(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            AceFlags aceFlags,
            ACCESS_MASK accessMask,
            SafeSidHandle pSid,
            BOOL bAuditSuccess,
            BOOL bAuditFailure);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL AddAuditAccessObjectAce(
            SafeAclHandle pAcl,
            DWORD dwAceRevision,
            AceFlags aceFlags,
            ACCESS_MASK accessMask,
            ref GUID objectTypeGuid,
            ref GUID inheritedObjectTypeGuid,
            SafeSidHandle pSid,
            BOOL bAuditSuccess,
            BOOL bAuditFailure);
        #endregion

        #region ???
        // AddMandatoryAce          || Vista
        // AddConditionalAce        || Win 7
        // AddResourceAttributeAce  || Win 8
        // AddScopedPolicyIDAce     || Win 8  
        #endregion

        /* Rights */

        /* retrieves the audited access rights for a specified trustee. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "GetAuditedPermissionsFromAclW", CharSet = CharSet.Unicode)]
        public static extern Win32Error GetAuditedPermissionsFromAcl(
            SafeAclHandle pacl,          // from which to get the audited access rights.
            ref TRUSTEE pTrustee,         // user, group, or program.
            out ACCESS_MASK pSuccessfulAuditedRights,
            out ACCESS_MASK pFailedAuditRights);

        /* retrieves the effective access rights that an ACL structure grants to a specified trustee.
            The trustee's effective access rights are the access rights that the ACL grants to the trustee
            or to any groups of which the trustee is a member. */
        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "GetEffectiveRightsFromAclW", CharSet = CharSet.Unicode)]
        public static extern Win32Error GetEffectiveRightsFromAcl(
            SafeAclHandle pacl,          // from which to get the effective access rights. 
            ref TRUSTEE pTrustee,         // user, group, or program.
            out ACCESS_MASK pAccessRights);

        // inherited Ace information

        // GetInheritanceSource
        // FreeInheritedFromArray

        #endregion

        #region Security Descriptor :: Properties

        /* Get */

        /* retrieves a pointer to the system access control list (SACL) in a specified security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool GetSecurityDescriptorSacl(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            out bool lpbSaclPresent,
            out SafeAclHandle pSacl,
            out BOOL lpbSaclDefaulted);

        /* retrieves a pointer to the discretionary access control list (DACL) in a specified security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool GetSecurityDescriptorDacl(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            out bool lpbDaclPresent,
            out SafeAclHandle pDacl,
            out BOOL lpbDaclDefaulted);

        /* retrieves the owner information from a security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool GetSecurityDescriptorOwner(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            out SafeSidHandle pOwner,
            out BOOL lpbOwnerDefaulted);

        /* retrieves the primary group information from a security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool GetSecurityDescriptorGroup(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            out SafeSidHandle pGroup,
            out BOOL lpbGroupDefaulted);

        /* retrieves a security descriptor control and revision information. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public unsafe static extern bool GetSecurityDescriptorControl(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            WORD* pControl,
            out DWORD lpdwRevision);

        /* retrieves the resource manager control bits. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern DWORD GetSecurityDescriptorRMControl(
            SafeSecurityDescriptorHandle securityDescriptor,
            out CHAR rmControl);

        // ----------- | ----------- | ----------- | ----------- | -----------

        /* retrieves security information for the specified user object. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern DWORD GetSecurityDescriptorLength(
            SafeSecurityDescriptorHandle pSecurityDescriptor);

        /* Set */

        /* sets information in a system access control list (SACL). */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool SetSecurityDescriptorSacl(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            BOOL bSaclPresent,
            SafeAclHandle pSacl,
            BOOL bSaclDefaulted);

        /* sets information in a discretionary access control list (DACL). */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool SetSecurityDescriptorDacl(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            BOOL bDaclPresent,
            SafeAclHandle pDacl,
            BOOL bDaclDefaulted);

        /* sets the owner information of an absolute-format security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool SetSecurityDescriptorOwner(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            SafeSidHandle pOwner,
            BOOL lpbOwnerDefaulted);

        /* sets the primary group information of an absolute-format security descriptor,
            replacing any primary group information already present in the security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool SetSecurityDescriptorGroup(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            SafeSidHandle pGroup,
            BOOL bGroupDefaulted);

        /* sets the control bits of a security descriptor. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern bool SetSecurityDescriptorControl(
            SafeSecurityDescriptorHandle pSecurityDescriptor,
            WORD controlBitsOfInterest,
            WORD controlBitsToSet);

        /* sets the resource manager control bits in the SECURITY_DESCRIPTOR structure. */
        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern DWORD SetSecurityDescriptorRMControl(
            SafeSecurityDescriptorHandle securityDescriptor,
            CHAR rmControl);

        #endregion

        #region Security Descriptor { Get , Set }

        /*
        * Warning ::
        * 
        * do not direct edit the SafeSecurityDescriptor Handle from Get????
        * instead make new Handle initilize It,
        * than modify it and use Set???? in the specific enum
        * we want to modify in the object/file/handle/else
        * 
        * same thing to [Get/Set]SecurityInfo
        * just use IntPtr.Zero or struct(0) to ignore 
        * specific things we dont want change
         * 
         * instead use ConvertToAbsoluteSD()
         * than you can cast Pointer to real SD structare.
        */

        /*
         * [GET] usage
         * 
         * first call needed to obtain the size
         * later use SafeProcessHandle.Initialize methood 
         * with the needed size,
         * than call it again
         */

        /* FileSecurity */

        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "GetFileSecurityW", CharSet = CharSet.Unicode)]
        public static extern BOOL GetFileSecurity(
            string lpFileName,
            SECURITY_INFORMATION requestedInformation,
            // self-relative security descriptor format
            [Optional, Out] SafeSecurityDescriptorHandle pSecurityDescriptor,
            DWORD nLength,
            out DWORD lpnLengthNeeded);

        [DllImport("Advapi32.dll", SetLastError = true,
            EntryPoint = "SetFileSecurityW", CharSet = CharSet.Unicode)]
        public static extern BOOL SetFileSecurity(
            string lpFileName,
            SECURITY_INFORMATION requestedInformation,
            SafeSecurityDescriptorHandle pSecurityDescriptor);

        /* RegistryKeySecurity */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegGetKeySecurity(
            SafeRegistryHandle hKey,
            SECURITY_INFORMATION securityInformation,
            // self-relative security descriptor format
            [Optional, Out]SafeSecurityDescriptorHandle pSecurityDescriptor,
            out DWORD lpcbSecurityDescriptor);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern LONG RegSetKeySecurity(
            SafeRegistryHandle hKey,
            SECURITY_INFORMATION securityInformation,
            SafeSecurityDescriptorHandle pSecurityDescriptor);

        /* ServiceObjectSecurity */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL QueryServiceObjectSecurity(
            SafeServiceHandle hService,
            SECURITY_INFORMATION dwSecurityInformation,
            // self-relative security descriptor format
            [Optional, Out] SafeSecurityDescriptorHandle lpSecuraityDescriptor,
            DWORD cbBufSize,
            out DWORD pcbBytesNeeded);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL SetServiceObjectSecurity(
            SafeServiceHandle hService,
            SECURITY_INFORMATION dwSecurityInformation,
            SafeSecurityDescriptorHandle lpSecurityDescriptor);

        /* UserObjectSecurity */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL GetUserObjectSecurity(
            HANDLE hObj,
            ref SECURITY_INFORMATION pSiRequested,
            SafeSecurityDescriptorHandle pSd,
            DWORD nLength,
            out DWORD lpnLengthNeeded);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL SetUserObjectSecurity(
            HANDLE hObj,
            ref SECURITY_INFORMATION pSiRequested,
            SafeSecurityDescriptorHandle pSd);

        /* PrivateObjectSecurity */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL GetPrivateObjectSecurity(
            SafeSecurityDescriptorHandle objectDescriptor,
            // self-relative security descriptor format
            [Optional, Out] SECURITY_INFORMATION securityInformation,
            SafeSecurityDescriptorHandle resultantDescriptor,
            DWORD descriptorLength,
            out DWORD returnLength);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL SetPrivateObjectSecurity(
            SECURITY_INFORMATION securityInformation,
            SafeSecurityDescriptorHandle modificationDescriptor,
            ref SafeSecurityDescriptorHandle objectsSecurityDescriptor,
            ref GENERIC_MAPPING genericMapping,
            SafeThreadHandle token);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL SetPrivateObjectSecurityEx(
            SECURITY_INFORMATION securityInformation,
            SafeSecurityDescriptorHandle modificationDescriptor,
            ref SafeSecurityDescriptorHandle objectsSecurityDescriptor,
            ULONG autoInheritFlags,
            ref GENERIC_MAPPING genericMapping,
            SafeThreadHandle token);

        /* KernelObjectSecurity [process, thread, event] */

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL GetKernelObjectSecurity(
            HANDLE handle,
            SECURITY_INFORMATION requestedInformation,
            // self-relative security descriptor format
            [Optional, Out] SafeSecurityDescriptorHandle pSecurityDescriptor,
            DWORD nLength,
            out DWORD lpnLengthNeeded);

        [DllImport("Advapi32.dll", SetLastError = true)]
        public static extern BOOL SetKernelObjectSecurity(
            HANDLE handle,
            SECURITY_INFORMATION securityInformation,
            SafeSecurityDescriptorHandle securityDescriptor);

        /* Wrapper */

        /* can Get specific Or all */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "GetSecurityInfo")]
        public static extern Win32Error GetSecurityInfo(
            HANDLE handle,
            SE_OBJECT_TYPE objectType,
            SECURITY_INFORMATION securityInfo,
            out SafeSidHandle ppsidOwner,
            out SafeSidHandle ppsidGroup,
            out SafeAclHandle ppDacl,
            out SafeAclHandle ppSacl,
            out SafeSecurityDescriptorHandle ppSecurityDescriptor);

        /* can Get specific Or all */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "GetNamedSecurityInfoW", CharSet = CharSet.Unicode)]
        public static extern Win32Error GetSecurityInfo(
            string pObjectName,
            SE_OBJECT_TYPE objectType,
            SECURITY_INFORMATION securityInfo,
            out SafeSidHandle ppsidOwner,
            out SafeSidHandle ppsidGroup,
            out SafeAclHandle ppDacl,
            out SafeAclHandle ppSacl,
            out SafeSecurityDescriptorHandle ppSecurityDescriptor);

        /* can Set specific Or all */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "SetSecurityInfo")]
        public static extern Win32Error SetSecurityInfo(
            HANDLE handle,
            SE_OBJECT_TYPE objectType,
            SECURITY_INFORMATION securityInfo,
            SafeSidHandle psidOwner,
            SafeSidHandle ppsidGroup,
            SafeAclHandle ppDacl,
            SafeAclHandle ppSacl);

        /* can Set specific Or all */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "SetNamedSecurityInfoW", CharSet = CharSet.Unicode)]
        public static extern Win32Error SetSecurityInfo(
            string pObjectName,
            SE_OBJECT_TYPE objectType,
            SECURITY_INFORMATION securityInfo,
            SafeSidHandle psidOwner,
            SafeSidHandle ppsidGroup,
            SafeAclHandle ppDacl,
            SafeAclHandle ppSacl);

        /* Wrapper [Tree] */

        /* sets specified security information in the security descriptor of a specified tree of objects.  */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "TreeSetNamedSecurityInfoW", CharSet = CharSet.Unicode)]
        public static extern Win32Error TreeSetSecurityInfo(
            // Object
            string pObjectName,
            SE_OBJECT_TYPE objectType,
            SECURITY_INFORMATION securityInfo,
            // Args
            [Optional] SafeSidHandle pOwner,
            [Optional] SafeSidHandle pGroup,
            [Optional] SafeAclHandle pDacl,
            [Optional] SafeAclHandle pSacl,
            Enum.Action dwAction,
            // Callback
            IntPtr fnProgress,
            PROG_INVOKE_SETTING progressInvokeSetting,
            PVOID args);

        /* resets specified security information in the security descriptor of a specified tree of objects. */
        [DllImport("advapi32.dll", SetLastError = true,
            EntryPoint = "TreeResetNamedSecurityInfoW", CharSet = CharSet.Unicode)]
        public static extern Win32Error TreeResetSecurityInfo(
            // Object
            string pObjectName,
            SE_OBJECT_TYPE objectType,
            SECURITY_INFORMATION securityInfo,
            // Args
            [Optional] SafeSidHandle pOwner,
            [Optional] SafeSidHandle pGroup,
            [Optional] SafeAclHandle pDacl,
            [Optional] SafeAclHandle pSacl,
            Enum.Action dwAction,
            // Callback
            IntPtr fnProgress,
            PROG_INVOKE_SETTING progressInvokeSetting,
            PVOID args);

        #endregion
       
    }
    public static class version
    {
        #region Version
        [DllImport("version.dll", SetLastError = true,
            EntryPoint = "GetFileVersionInfoW", CharSet = CharSet.Unicode)]
        public static extern bool GetFileVersionInfo(string lptstrFilename, DWORD dwHandle, DWORD dwLen, LPVOID lpData);

        [DllImport("version.dll", SetLastError = true,
            EntryPoint = "GetFileVersionInfoSizeW", CharSet = CharSet.Unicode)]
        public static extern uint GetFileVersionInfoSize(string lptstrFilename, out uint handle);

        [DllImport("version.dll", CharSet = CharSet.Unicode,
            EntryPoint = "VerQueryValueW", SetLastError = true)]
        public static extern bool VerQueryValue(byte[] pBlock, string lpSubBlock, out LPVOID lpBuffer, out uint puLen);

        [DllImport("version.dll", SetLastError = true,
            EntryPoint = "VerQueryValueW", CharSet = CharSet.Unicode)]
        public static extern bool VerQueryValue(LPVOID pBlock, string lpSubBlock, out LPVOID lpBuffer, out uint puLen);

        [DllImport("version.dll", SetLastError = true)]
        public static extern uint VerLanguageName(DWORD wLang, String szLang, DWORD cchLang);
        #endregion
    }
    public static class ws2_32
    {
        #region Windows Sockets v2 [Interprocess Communications]
        //
        // Base
        //

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SocketError WSAStartup(Int16 wVersionRequested, ref WSAData wsaData);

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern SocketError WSACleanup();

        //
        // Socket
        //

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SafeSocketHandle socket(AddressFamilies af, SocketType socketType, SocketProtocolInt protocol);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SocketError closesocket(SafeSocketHandle s);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SocketError shutdown(SafeSocketHandle s, ShutDownFlags how);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError connect(SafeSocketHandle s, ref sockaddr_in addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError connect(SafeSocketHandle s, ref sockaddr_in6 addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError connect(SafeSocketHandle s, ref SOCKADDR_BTH addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError connect(SafeSocketHandle s, ref SOCKADDR_IRDA addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError bind(SafeSocketHandle s, ref sockaddr_in addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError bind(SafeSocketHandle s, ref sockaddr_in6 addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError bind(SafeSocketHandle s, ref SOCKADDR_BTH addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError bind(SafeSocketHandle s, ref SOCKADDR_IRDA addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int listen(SafeSocketHandle s, int backlog);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SafeSocketHandle accept(SafeSocketHandle s, IntPtr addr, int addrsize);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int send(SafeSocketHandle s, IntPtr buf, int len, MsgFlags flags);

        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int recv(SafeSocketHandle s, IntPtr buf, int len, MsgFlags flags);

        //
        // Properties
        //

        /* receive sockaddr_in from Socket handle */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError getsockname(SafeSocketHandle s, ref sockaddr_in name, ref int namelen);

        /* receive sockaddr_in6 from Socket handle */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError getsockname(SafeSocketHandle s, ref sockaddr_in6 name, ref int namelen);

        /* check for Read, Write, Error etc ... */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int select(
            int nfds,
            ref fd_set readfds, 	/* An optional pointer to a set of sockets to be checked for readability. */
            ref fd_set writefds,	/* An optional pointer to a set of sockets to be checked for writability. */
            ref fd_set exceptfds,	/* An optional pointer to a set of sockets to be checked for errors. */
            ref timeval timeout);

        /* retrieves a socket option. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public unsafe static extern SocketError getsockopt(SafeSocketHandle s, SocketOptionLevel level, SocketOptionName optname, IntPtr optval, int* optlen);
        //[DllImport("Ws2_32.dll", SetLastError = true)]
        //public static extern int getsockopt(SafeSocketHandle s, SocketOptionLevel level, SocketOptionName optname, out BOOL optval, ref int optlen);
        //[DllImport("Ws2_32.dll", SetLastError = true)]
        //public static extern int getsockopt(SafeSocketHandle s, SocketOptionLevel level, SocketOptionName optname, out int optval, ref int optlen);

        /* sets a socket option. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public unsafe static extern SocketError setsockopt(SafeSocketHandle s, SocketOptionLevel level, SocketOptionName optname, IntPtr optval, int optlen);
        //[DllImport("Ws2_32.dll", SetLastError = true)]
        //public static extern int setsockopt(SafeSocketHandle s, SocketOptionLevel level, SocketOptionName optname, ref BOOL optval, int optlen);
        //[DllImport("Ws2_32.dll", SetLastError = true)]
        //public static extern int setsockopt(SafeSocketHandle s, SocketOptionLevel level, SocketOptionName optname, ref int optval, int optlen);

        /* controls the I/O mode of a socket. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError ioctlsocket(SafeSocketHandle s, Command cmd, ref uint argp);

        /* controls the mode of a socket. */
        /* validate Check, [WSAIoctl() == 0], AndAlso in [Get] Mode --> [lpcbBytesReturned > 0] */
        /* http://msdn.microsoft.com/en-us/library/windows/desktop/ms741621(v=vs.85).aspx */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public unsafe static extern SocketError WSAIoctl(
            /* Socket, Mode */
            SafeSocketHandle s, ControlCode dwIoControlCode,
            /* [Optional][Set] Or IntPtr.Zero, 0 */
            IntPtr lpvInBuffer, int cbInBuffer,
            /* [Optional][Get] Or IntPtr.Zero, 0 */
            IntPtr lpvOutBuffer, int cbOutBuffer,
            /* [Get Only] ref to receive Size,
                can be NULL, look in MSDN before */
            uint* lpcbBytesReturned,
            /* IntPtr.Zero, IntPtr.Zero */
            IntPtr lpOverlapped, IntPtr lpCompletionRoutine);

        // Event

        /* specifies an event object to be associated with the specified set of FD_XXX network events. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern SocketError WSAEventSelect(SafeSocketHandle s, SafeEventHandle hEventObject, AsyncEventBits lNetworkEvents);

        //
        // Misc
        //

        // {Host}:{Port} <-> sockaddr_in[6]//

        /* converts a network address in its standard text presentation form into its numeric binary form in a sockaddr structure.  */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "WSAStringToAddressW", CharSet = CharSet.Unicode)]
        public static extern SocketError WSAStringToAddress(
            string addressString, AddressFamilies addressFamily, IntPtr lpProtocolInfo,
            ref sockaddr_in pAddr, ref int lpAddressLength);

        /* converts a network address in its standard text presentation form into its numeric binary form in a sockaddr structure.  */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "WSAStringToAddressW", CharSet = CharSet.Unicode)]
        public static extern SocketError WSAStringToAddress(
            string addressString, AddressFamilies addressFamily, IntPtr lpProtocolInfo,
            ref sockaddr_in6 pAddr, ref int lpAddressLength);

        /* converts sockaddr_in structure into a human-readable string representation of the address.  */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "WSAAddressToStringW", CharSet = CharSet.Unicode)]
        public static extern SocketError WSAAddressToString(
            ref sockaddr_in lpsaAddress, uint dwAddressLength, IntPtr lpProtocolInfo,
            StringBuilder lpszAddressString, ref uint lpdwAddressStringLength);

        /* converts sockaddr_in6 structure into a human-readable string representation of the address. */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "WSAAddressToStringW", CharSet = CharSet.Unicode)]
        public static extern SocketError WSAAddressToString(
            ref sockaddr_in6 lpsaAddress, uint dwAddressLength, IntPtr lpProtocolInfo,
            StringBuilder lpszAddressString, ref uint lpdwAddressStringLength);

        // Only -> Port //

        /* convert IP port number in host byte order to the IP port number in [network byte order]. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern ushort htons(
            ushort hostshort);

        /* convert an IP port number in network byte order to the IP port number in [host byte order]. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern ushort ntohs(
            ushort netshort);

        // Only -> Host [IPv4] //

        /* converts string containing an IPv4 dotted-decimal address into a proper address for the IN_ADDR */
        [Obsolete]
        [DllImport("Ws2_32.dll", SetLastError = true,
            CharSet = CharSet.Ansi)]
        public static extern in_addr inet_addr(
            string cp);

        /* converts an (Ipv4) Internet network address into an ASCII string in Internet standard dotted-decimal format. */
        [Obsolete]
        [DllImport("Ws2_32.dll", SetLastError = true, 
            CharSet = CharSet.Ansi)]
        public static extern string inet_ntoa(
            in_addr @in);

        // Only -> Host [IPv4, IPv6] //

        /* converts string containing an IPv4 into IN_ADDR structure */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "InetPtonW", CharSet = CharSet.Unicode)]
        public static extern uint inet_pton(
            AddressFamilies family, 
            string pszAddrString, 
            ref in_addr pAddrBuf);

        /* converts string containing an IPv6 to into IN_ADDR6 structure */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "InetPtonW", CharSet = CharSet.Unicode)]
        public static extern uint inet_pton(
            AddressFamilies family, 
            string pszAddrString, 
            ref in6_addr pAddrBuf);

        /* converts an IPv4 Internet network address into a string in Internet standard format.  */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "InetNtopW", CharSet = CharSet.Unicode)]
        public static extern uint InetNtop(
            AddressFamilies family, 
            ref in_addr pAddr,
            StringBuilder pStringBuf,
            int stringBufSize);

        /* converts an IPv6 Internet network address into a string in Internet standard format.  */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "InetNtopW", CharSet = CharSet.Unicode)]
        public static extern uint InetNtop(
            AddressFamilies family,
            ref in6_addr pAddr,
            StringBuilder pStringBuf,
            int stringBufSize);

        // Name <> Address

        /* 192.55.5.5:80 -> www.google.com */
        /* must call WSAStartup / WSACleanup */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "GetNameInfoW", CharSet = CharSet.Unicode)]
        public static extern int GetNameInfo(
            ref sockaddr_in pSockaddr, int sockaddrLength,    // sockaddr_in.FromString
            StringBuilder pNodeBuffer, DWORD nodeBufferSize,            // host
            StringBuilder pServiceBuffer, DWORD serviceBufferSize,      // port
            NI flags);

        /* 0122022202220222:3456 -> www.google.com */
        /* must call WSAStartup / WSACleanup */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "GetNameInfoW", CharSet = CharSet.Unicode)]
        public static extern int GetNameInfo(
            ref sockaddr_in6 pSockaddr, int sockaddrLength,   // sockaddr_in6.FromString
            StringBuilder pNodeBuffer, DWORD nodeBufferSize,            // host
            StringBuilder pServiceBuffer, DWORD serviceBufferSize,      // port
            NI flags);

        /* www.google.com -> 192.55.5.5, 22.3.45.6, .... */
        /* must call WSAStartup / WSACleanup */
        [DllImport("Ws2_32.dll", SetLastError = true,
            EntryPoint = "GetAddrInfoW", CharSet = CharSet.Unicode)]
        public unsafe static extern int getaddrinfo(
            string pNodeName,                   // Host
            string pServiceName,                // Port Or Null 
            ref addrinfo hints,    // addrinfo* ==> addrinfo.CreateHints()
            out addrinfo* res);    // addrinfo** ==> addrinfo.CreatePtr()

        // Hmmm //

        /* retrieves the standard host name for the local computer */
        /* must call WSAStartup / WSACleanup */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern int gethostname(
            /* Host */
            StringBuilder name,
            /* Port Or Null */
            int namelen);

        /* converts a u_long from host to TCP/IP [network byte order]. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern ushort htonl(uint hostlong);

        /* convert an IPv4 address in network byte order to the IPv4 address in [host byte order]. */
        [DllImport("Ws2_32.dll", SetLastError = true)]
        public static extern uint ntohl(uint netlong);
        #endregion
    }
    public static class fwpuclnt
    {
        #region Windows Sockets v2 [Security] [Interprocess Communications]
        //
        // Security
        //

        [DllImport("Fwpuclnt.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SocketError WSASetSocketSecurity(
            SafeSocketHandle socket,
            ref SOCKET_SECURITY_SETTINGS securitySettings,
            ULONG securitySettingsLen,
            IntPtr overlapped,
            IntPtr completionRoutine);

        // WSAQuerySocketSecurity

        [DllImport("Fwpuclnt.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern SocketError WSASetSocketPeerTargetName(
            SafeSocketHandle socket,
            ref SOCKET_PEER_TARGET_NAME peerTargetName,
            ULONG peerTargetNameLen,
            IntPtr overlapped,
            IntPtr completionRoutine);

        // WSADeleteSocketPeerTargetName
        #endregion
    }
    public static class ole32
    {
        #region Clipboard
        /* Return :: IDataObject */
        [DllImport("ole32.dll", SetLastError = true)]
        public static extern int OleGetClipboard(
            [MarshalAs(UnmanagedType.IUnknown)]
        out object ppDataObj);

        [DllImport("ole32.dll", SetLastError = true)]
        public static extern int OleSetClipboard(
            IDataObject pDataObj);

        [DllImport("ole32.dll", SetLastError = true)]
        public static extern int OleFlushClipboard();
        #endregion

        #region Memory Management
        [DllImport("ole32.dll", SetLastError = true)]
        public static extern LPVOID CoTaskMemAlloc(SIZE_T cb);

        [DllImport("ole32.dll", SetLastError = true)]
        public static extern void CoTaskMemFree(LPVOID pv);
        #endregion

        #region COM
        [DllImport("Ole32.dll", SetLastError = true)]
        public static extern int CoInitialize(
            IntPtr reserved);

        [DllImport("Ole32.dll", SetLastError = true)]
        public static extern int CoInitializeEx(
            IntPtr reserved, 
            CoInit coInit);

        [DllImport("Ole32.dll", SetLastError = true)]
        public static extern void CoUninitialize();
        #endregion
    }
    public static class msvcrt
    {
        #region Memory Management
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr malloc(SIZE_T size);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern void free(IntPtr memblock);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr memcpy(IntPtr dest, IntPtr src, SIZE_T count);

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr memmove(IntPtr dest, IntPtr src, SIZE_T count);

        /* Finds characters in a buffer.. */
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr memchr(IntPtr buf, int c, SIZE_T count);

        /* Sets buffers to a specified character. */
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr memset(IntPtr dest, int c, SIZE_T count);

        /* Compare characters in two buffers. */
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int memcmp(IntPtr buf1, IntPtr buf2, SIZE_T count);

        /* Compares characters in two buffers (case-insensitive). */
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern int _memicmp(IntPtr buf1, IntPtr buf2, SIZE_T count);
        #endregion
    }
    public static class dnsapi
    {
        #region Dns

        // Also look at ::

        // getaddrinfo
        // GetNameInfo

        // http://support.microsoft.com/kb/831226
        // How to use the DnsQuery function to resolve host names and host addresses with Visual C++ .NET

        //
        // Dns >> Query
        //

        [DllImport("Dnsapi.dll", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error DnsQuery(
            string lpstrName,
            QueryTypes wType,
            QueryOptions options,
            PVOID pExtra,
            out DNS_RECORD* ppQueryResultsSet,
            out PVOID pReserved);

        [DllImport("Dnsapi.dll", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error DnsQuery(
            string lpstrName,
            QueryTypes wType,
            QueryOptions options,
            ref IP4_ARRAY pExtra,
            out DNS_RECORD* ppQueryResultsSet,
            out PVOID pReserved);

        [DllImport("Dnsdll.dll", SetLastError = true)]
        public static extern Win32Error DnsQueryEx(
            ref DNS_QUERY_REQUEST pQueryRequest,
            ref DNS_QUERY_RESULT pQueryResults,
            ref DNS_QUERY_CANCEL pCancelHandle);

        // look here to know what size its nececery for pBuffer.
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms682017(v=vs.85).aspx
        [DllImport("Dnsdll.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsQueryConfig(
            DnsConfigType config,
            bool flag,
            string pwsAdapterName,
            PVOID pReserved,
            [Out] PVOID pBuffer,
            ref DWORD pBufferLength);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public static extern Win32Error DnsCancelQuery(
            ref DNS_QUERY_CANCEL pCancelHandle);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public static extern void DnsFree(
            PVOID pData,
            DnsFreeType freeType);


        [DllImport("Dnsapi.dll", SetLastError = true)]
        public unsafe static extern void DnsRecordListFree(
            DNS_RECORD* pRecordList,
            DnsFreeType freeType);

        //
        // Dns >> Specific Record
        //

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public unsafe static extern BOOL DnsRecordCompare(
            ref DNS_RECORD pRecord1,
            ref DNS_RECORD pRecord2);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public unsafe static extern BOOL DnsRecordSetCompare(
            ref DNS_RECORD pRr1,
            ref DNS_RECORD pRr2,
            out DNS_RECORD* ppDiff1,
            out DNS_RECORD* ppDiff2);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public unsafe static extern DNS_RECORD* DnsRecordCopyEx(
            ref DNS_RECORD pRecord,
            DnsCharset charSetIn,
            DnsCharset charSetOut);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public unsafe static extern DNS_RECORD* DnsRecordSetCopyEx(
            ref DNS_RECORD pRecordSet,
            DnsCharset charSetIn,
            DnsCharset charSetOut);

        [DllImport("Dnsapi.dll", EntryPoint = "DnsModifyRecordsInSet_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error DnsModifyRecordsInSet(
            ref DNS_RECORD pAddRecords,
            ref DNS_RECORD pDeleteRecords,
            QueryUpdate options,
            [Optional] HANDLE hContext,
            PVOID pExtraList,
            PVOID pReserved);

        [DllImport("Dnsapi.dll", EntryPoint = "DnsReplaceRecordSetW", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsReplaceRecordSet(
            ref DNS_RECORD pNewSet,
            QueryUpdate options,
            [Optional] HANDLE hContext,
            PVOID pExtraInfo,
            PVOID pReserved);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public unsafe static extern DNS_RECORD* DnsRecordSetDetach(
            ref DNS_RECORD pRr);

        //
        // Dns Name
        //

        [DllImport("Dnsapi.dll", EntryPoint = "DnsNameCompare_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern BOOL DnsNameCompare(
            string pName1,
            string pName2);

        [DllImport("Dnsapi.dll", EntryPoint = "DnsValidateName_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsValidateName(
            string pszName,
            DnsNameFormat format);

        //
        // Proxy Information
        //

        [DllImport("Dnsapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsGetProxyInformation(
            string hostName,
            ref DNS_PROXY_INFORMATION proxyInformation,
            ref DNS_PROXY_INFORMATION defaultProxyInformation,
            IntPtr completionRoutine,
            IntPtr completionContext);

        [DllImport("Dnsapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern void DnsFreeProxyName(
            string proxyName);

        //
        // Context Handle
        //

        [DllImport("Dnsapi.dll", EntryPoint = "DnsAcquireContextHandle_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsAcquireContextHandle(
            BOOL credentialFlags,
            PVOID credentials,
            out HANDLE pContext);

        [DllImport("Dnsapi.dll", SetLastError = true)]
        public static extern void DnsReleaseContextHandle(
            HANDLE contextHandle);

        //
        // Messege Buffer
        //

        [DllImport("Dnsapi.dll", EntryPoint = "DnsWriteQuestionToBuffer_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern BOOL DnsWriteQuestionToBuffer(
            ref DNS_MESSAGE_BUFFER pDnsBuffer,
            ref DWORD pdwBufferSize,
            string pszName,
            QueryTypes wType,
            WORD xid,
            BOOL fRecursionDesired);

        [DllImport("Dnsapi.dll", EntryPoint = "DnsExtractRecordsFromMessage_W", CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe static extern Win32Error DnsExtractRecordsFromMessage(
            ref DNS_MESSAGE_BUFFER pDnsBuffer,
            WORD wMessageLength,
            out DNS_RECORD* ppRecord);

        //
        // Misc
        //

        [DllImport("Dnsapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsValidateServerStatus(
            ref sockaddr_in server,
            string queryName,
            out DnsError serverStatus);

        [DllImport("Dnsapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Win32Error DnsValidateServerStatus(
            ref sockaddr_in6 server,
            string queryName,
            out Win32Error serverStatus);

        #endregion
    }
    public static class oleacc
    {
        #region Active Accessibility User Interface Services

        //
        // AccessibleObject
        //

        [DllImport("oleacc.dll", PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern IAccessible AccessibleObjectFromWindow(
            SafeWindowHandle hwnd, AccessibleObjectID dwObjectID, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern ComError AccessibleObjectFromPoint(
            POINT pt, [Out, MarshalAs(UnmanagedType.Interface)] out IAccessible accObj, [Out] out object childID);

        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern ComError AccessibleObjectFromEvent(
            SafeWindowHandle hwnd, uint dwObjectID, uint dwChildID, out IAccessible ppacc, [MarshalAs(UnmanagedType.Struct)] out object pvarChild);

        //
        // Children
        //

        /// <summary>
        /// if rgvarChildren[?] is int          >> use accChild[(int)rgvarChildren[?]]
        /// if rgvarChildren[?] is IAccessible  >> use (IAccessible)rgvarChildren[?]
        /// </summary>
        /// <returns></returns>
        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern ComError AccessibleChildren(
            IAccessible paccContainer, LONG iChildStart, LONG cChildren, [Out] object[] rgvarChildren, out LONG pcObtained);

        //
        // Event
        //

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWinEventHook(
            AccessibleEventType eventMin, AccessibleEventType eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, uint idProcess, uint idThread, WinEeventFlags dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);
            

        //
        // Text
        //

        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern ComError GetRoleText(
            uint dwRole, [Out] StringBuilder lpszRole, uint cchRoleMax);

        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern ComError GetStateText(
            uint dwStateBit, [Out] StringBuilder lpszStateBit, uint cchStateBitMax);

        //
        // Other
        //

        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern SafeProcessHandle GetProcessHandleFromHwnd(
            SafeWindowHandle hwnd);

        [DllImport("oleacc.dll", SetLastError = true)]
        public static extern ComError WindowFromAccessibleObject(
            IAccessible pacc, out SafeWindowHandle phwnd);
        #endregion
    }
    public static class difxapi
    {
        #region Driver Package

        [DllImport("difxapi.dll", SetLastError = true)]
        public static extern DWORD DriverPackageGetPath(
            string driverPackageInfPath,
            out string pDestInfPath,
            ref DWORD pNumOfChars);

        [DllImport("difxapi.dll", SetLastError = true)]
        public unsafe static extern DWORD DriverPackageInstall(
            string driverPackageInfPath,
            DWORD flags,
            INSTALLERINFO* pInstallerInfo,
            out BOOL pNeedReboot);

        [DllImport("difxapi.dll", SetLastError = true)]
        public static extern DWORD DriverPackagePreinstall(
            string driverPackageInfPath,
            DWORD flags);

        [DllImport("difxapi.dll", SetLastError = true)]
        public unsafe static extern DWORD DriverPackageUninstall(
            string driverPackageInfPath,
            DWORD flags,
            INSTALLERINFO* pInstallerInfo,
            out BOOL pNeedReboot);

        #endregion

        #region ???

        // SetDifxLogCallback 
        // DIFXAPISetLogCallback 

        #endregion
    }
    public static class cfgmgr32
    {
        #region Machine handle

		[DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern uint CM_Connect_Machine(
            string uncServerName,
            out IntPtr phMachine);

        [DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern uint CM_Disconnect_Machine(
            IntPtr hMachine);
 
	    #endregion

        #region Device :: Interface

        /* Use SetupDiGetClassDevs instead of CM_Get_Device_Interface_List. */
        //CM_Get_Device_Interface_List 
        //CM_Get_Device_Interface_List_Size  

        #endregion

        #region Device :: Node

        //CM_Locate_DevNode_Ex

        //CM_Setup_DevNode 
        /* To perform DIF_REMOVE use SetupDiCallClassInstaller. */
        //CM_Uninstall_DevNode
        //CM_Enable_DevNode 
        //CM_Disable_DevNode 
        //CM_Reenumerate_DevNode_Ex

        //CM_Query_And_Remove_SubTree_Ex

        //CM_Open_DevNode_Key 
        //CM_Delete_DevNode_Key

        // -----------------

        //CM_Get_Parent_Ex 
        //CM_Get_Sibling_Ex
        //CM_Get_HW_Prof_Flags_Ex

        /* used to retrieve a device instance handle to the first child node of a specified device node (devnode)
            in a local or a remote machine's device tree. */
        [DllImport("cfgmgr32.dll", SetLastError = true,
            EntryPoint = "CM_Get_Child_Ex")]
        public static extern uint CM_Get_Child(
            out DEVINST pdnDevInst,
            DEVINST dnDevInst,
            ULONG ulFlags,
            // obtained from a previous call to CM_Connect_Machine.
            [Optional] IntPtr hMachine);

        // -----------------

        //CM_Get_Depth_Ex 
        //CM_Get_DevNode_Registry_Property 
        //CM_Get_DevNode_Status_Ex 

        //CM_Set_DevNode_Problem_Ex 
        //CM_Set_DevNode_Registry_Property 

        #endregion

        #region Device :: ID

        //CM_Add_ID 
        //CM_Get_Device_ID_Ex 
        //CM_Get_Device_ID_List_Ex 
        //CM_Get_Device_ID_Size_Ex  
        //CM_Get_Device_ID_List_Size_Ex 

        #endregion

        #region Resource :: Conflict

        [DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern Win32Error CM_Query_Resource_Conflict_List(
          out CONFLICT_LIST pclConflictList,
          DEVINST dnDevInst,
          ResType resourceID,
          IntPtr resourceData,
          ULONG resourceLen,
          ULONG ulFlags,
          [Optional] IntPtr hMachine);

        [DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern Win32Error CM_Get_Resource_Conflict_Count(
          CONFLICT_LIST clConflictList,
          out ULONG pulCount);

        [DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern Win32Error CM_Get_Resource_Conflict_Details(
          CONFLICT_LIST clConflictList,
          ULONG ulIndex,
          ref CONFLICT_DETAILS pConflictDetails);

        [DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern Win32Error CM_Free_Resource_Conflict_Handle(
            CONFLICT_LIST clConflictList); 

        #endregion

        #region Resource :: Descriptor

        //CM_Add_Res_Des_Ex 
        //CM_Modify_Res_Des_Ex   
        //CM_Get_Next_Res_Des_Ex 
        //CM_Get_Res_Des_Data_Size_Ex 
        //CM_Get_Res_Des_Data_Ex 
        //CM_Free_Res_Des_Ex 
        //CM_Free_Res_Des_Handle  

        #endregion

        #region Class[es]

        //CM_Open_Class_Key
        //CM_Delete_Class_Key

        //CM_Enumerate_Classes 
        //CM_Enumerate_Classes_Ex 

        //CM_Get_Class_Registry_Property
        //CM_Set_Class_Registry_Property  

        #endregion

        #region Log

        //CM_Add_Empty_Log_Conf_Ex 
        //CM_Get_First_Log_Conf_Ex 
        //CM_Get_Next_Log_Conf_Ex 
        //CM_Get_Log_Conf_Priority_Ex 

        //CM_Free_Log_Conf_Ex 
        //CM_Free_Log_Conf_Handle  

        #endregion

        #region ???

        //CM_Request_Eject_PC_Ex 
        //CM_Request_Device_Eject_Ex

        //CM_Get_Version_Ex 
        //CM_Is_Version_Available_Ex

        /* waits until there are no pending device installation activities
            for the PnP manager to perform. */
        [DllImport("cfgmgr32.dll", SetLastError = true)]
        public static extern uint CMP_WaitNoPendingInstallEvents(
            DWORD dwTimeout);

        // CM_Enumerate_Enumerators
        // CM_Is_Dock_Station_Present_Ex 

        #endregion
    }
    public static class setupapi
    {
        // Using Device Installation Functions
        // http://msdn.microsoft.com/en-us/library/windows/hardware/ff553567(v=vs.85).aspx

        // Device Information Sets
        // http://msdn.microsoft.com/en-us/library/windows/hardware/ff541247(v=vs.85).aspx

        // Device Console (DevCon) Tool
        // http://code.msdn.microsoft.com/windowshardware/DevCon-Sample-4e95d71c

        // Enumerating windows device
        // http://www.codeproject.com/Articles/14412/Enumerating-windows-device

        // Enumerate Installed Devices Using Setup API
        // http://www.codeproject.com/Articles/6445/Enumerate-Installed-Devices-Using-Setup-API

        // Enumerate Properties of an Installed Device
        // http://www.codeproject.com/Articles/6866/Enumerate-Properties-of-an-Installed-Device


        #region ???

        // SetupDiRestartDevices  

        // SetupGetNonInteractiveMode
        // SetupSetNonInteractiveMode 

        // SetupDiGetActualModelsSection 
        // SetupDiGetActualSectionToInstall 
        // SetupDiGetActualSectionToInstallEx 

        #endregion

        #region Inf

        /* retrieves the fully qualified file name (directory path and file name) of an INF file in the system INF file directory
                that corresponds to a specified INF file in the driver store
                or a specified INF file in the system INF file directory. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupGetInfPublishedName(
            string driverStoreLocation,
            StringBuilder returnBuffer,
            DWORD returnBufferSize,
            out DWORD requiredSize);

        /* retrieves the fully qualified file name (directory path and file name) of an INF file in the driver store that corresponds
            to a specified INF file in the system INF file directory or a specified INF file in the driver store. */

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupGetInfDriverStoreLocation(
          string fileName,
          [Optional] IntPtr alternatePlatformInfo,
          [Optional] string localeName,
          StringBuilder returnBuffer,
          DWORD returnBufferSize,
          out DWORD requiredSize);

        /* Retrieves the class of a specified device INF file. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetINFClass(
            string infName,
            out Guid classGuid,
            StringBuilder className,
            DWORD classNameSize,
            out DWORD requiredSize);

        #endregion

        #region Hw Profile

        // SetupDiGetHwProfileList 
        // SetupDiGetHwProfileListEx 
        // SetupDiGetHwProfileFriendlyName 
        // SetupDiGetHwProfileFriendlyNameEx

        #endregion

        #region Setup Class

        //
        // Installation
        //

        /* Installs the ClassInstall32 section of the specified INF file. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiInstallClass(
            SafeWindowHandle hwndParent,
            string infFileName,
            uint flags,
            [Optional] IntPtr fileQueue);

        /* Installs a class installer or an interface class */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiInstallClassEx(
            SafeWindowHandle hwndParent,
            string infFileName,
            uint flags,
            [Optional] IntPtr fileQueue,
            ref Guid interfaceClassGuid,
            PVOID res1, PVOID res2);

        //
        // Device
        //

        /* Returns a device information set that contains all devices of a specified class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern HDEVINFO SetupDiGetClassDevs(
            [Optional] Guid* classGuid,
            [Optional] string enumerator,
            [Optional] SafeWindowHandle hwndParent,
            DiGetClassFlags flags);

        /* Returns a device information set that contains all devices of a specified class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern HDEVINFO SetupDiGetClassDevsEx(
            [Optional] Guid* classGuid,
            [Optional] string enumerator,
            [Optional] SafeWindowHandle hwndParent,
            DiGetClassFlags flags,

            // optional Parameters
            [Optional] HDEVINFO deviceInfoSet,
            [Optional] string machineName,
            IntPtr reserved);

        //
        // Guid
        //

        // HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Class
        // HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\DeviceClasses

        /* Returns a list of setup class GUIDs
            that includes every class installed on the system. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiBuildClassInfoList(
          DWORD flags,
          out GUID* classGuidList,
          DWORD classGuidListSize,
          out DWORD requiredSize);

        /* Returns a list of setup class GUIDs that includes every class installed on the system.
            or a remote system.*/
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiBuildClassInfoListEx(
            DWORD flags,
            GUID* classGuidList,
            DWORD classGuidListSize,
            out DWORD requiredSize,
            [Optional]string machineName,
            PVOID reserved);

        //
        // Description
        //

        /* Retrieves the class description associated with the specified setup class GUID. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiGetClassDescription(
            ref Guid classGuid,
            StringBuilder classDescription,
            uint classDescriptionSize,
            out uint requiredSize);

        // SetupDiGetClassDescriptionEx

        //
        // Image 
        //

        /* Builds an image list that contains bitmaps
            for every installed class and returns the list in a data structure. */
        // SetupDiGetClassImageList 

        /* Builds an image list of bitmaps for every class installed
            on a local or remote computer. */
        // SetupDiGetClassImageListEx 

        /* Destroys a class image list. */
        // SetupDiDestroyClassImageList

        /* Retrieves the index within the class image list of a specified class. */
        // SetupDiGetClassImageIndex

        /* Retrieves the index of the mini-icon supplied for the specified class. */
        // SetupDiGetClassBitmapIndex

        //
        // Icon
        //

        /* Loads both the large and mini-icon for the specified class. */
        // SetupDiLoadClassIcon 

        /* Loads a device icon for a specified device. (Windows Vista and later versions of Windows) */
        // SetupDiLoadDeviceIcon 

        /* Draws the specified mini-icon at the location requested. */
        // SetupDiDrawMiniIcon

        //
        // Name

        /* Retrieves the GUIDs associated with the specified class name. */

        // SetupDiClassGuidsFromName 
        // SetupDiClassGuidsFromNameEx

        /* Retrieves the class name associated with the class GUID. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiClassNameFromGuid(
            ref Guid classGuid,
            StringBuilder className,
            uint classNameSize,
            out DWORD requiredSize);

        // SetupDiClassNameFromGuidEx

        #endregion


        #region Property

        //
        // Class
        //

        /* Retrieves a device property that is set for a device setup class
            or a device interface class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetClassProperty(
            ref GUID classGuid,
            ref DEVPROPKEY propertyKey,
            ULONG* propertyType,
            out BYTE propertyBuffer,
            DWORD propertyBufferSize,
            out DWORD requiredSize,
            DWORD flags);

        // SetupDiGetClassPropertyEx

        /* Retrieves an array of the device property keys that represent the device properties
            that are set for a device setup class or a device interface class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetClassPropertyKeys(
            ref GUID classGuid,
            [Optional] DEVPROPKEY* propertyKeyArray,
            DWORD propertyKeyCount,
            out DWORD requiredPropertyKeyCount,
            DWORD flags);

        // SetupDiGetClassPropertyKeysEx 

        /* Sets a class property for a device setup class
            or a device interface class */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiSetClassProperty(
            ref GUID classGuid,
            DEVPROPKEY* propertyKey,
            ULONG propertyType,
            IntPtr propertyBuffer,
            DWORD propertyBufferSize,
            DWORD flags);

        // SetupDiSetClassPropertyEx 

        //
        // Device
        //

        /* Retrieves a device instance property. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetDeviceProperty(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DEVPROPKEY* propertyKey,
            ULONG* propertyType,
            IntPtr propertyBuffer,
            DWORD propertyBufferSize,
            out DWORD requiredSize,
            DWORD flags);

        /* Retrieves an array of the device property keys that represent the device properties
            that are set for a device instance.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetDevicePropertyKeys(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DEVPROPKEY* propertyKeyArray,
            DWORD propertyKeyCount,
            out DWORD requiredPropertyKeyCount,
            DWORD flags);

        /* Sets a device instance property. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiSetDeviceProperty(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DEVPROPKEY* propertyKey,
            ULONG propertyType,
            IntPtr propertyBuffer,
            DWORD propertyBufferSize,
            DWORD flags);

        //
        // Device Interface
        //

        /* Retrieves a device property that is set for a device interface.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetDeviceInterfaceProperty(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            [In] DEVPROPKEY* propertyKey,
            [Out] ULONG* propertyType,
            IntPtr propertyBuffer,
            DWORD propertyBufferSize,
            out DWORD requiredSize,
            DWORD flags);

        /* Retrieves an array of device property keys that represent the device properties
            that are set for a device interface.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetDeviceInterfacePropertyKeys(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            [Out] DEVPROPKEY* propertyKeyArray,
            DWORD propertyKeyCount,
            out DWORD requiredPropertyKeyCount,
            DWORD flags);

        /* Sets a device property of a device interface. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiSetDeviceInterfaceProperty(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            DEVPROPKEY* propertyKey,
            ULONG propertyType,
            IntPtr propertyBuffer,
            DWORD propertyBufferSize,
            DWORD dlags);

        #endregion

        #region Registry

        //
        // Class
        //

        /* Opens the device setup class registry key, or a specific subkey of the class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern SafeRegistryHandle SetupDiOpenClassRegKey(
            [Optional] GUID* classGuid,
            ACCESS_MASK samDesired);

        /* Opens the device setup class registry key, the device interface class registry key, or a specific subkey of the class.
            This function opens the specified key on the local computer or on a remote computer. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern SafeRegistryHandle SetupDiOpenClassRegKeyEx(
            [Optional] GUID* classGuid,
            ACCESS_MASK samDesired,
            DWORD flags,
            [Optional] string machineName,
            PVOID reserved);

        /* Retrieves a specified device class property from the registry. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetClassRegistryProperty(
          ref GUID classGuid,
          DWORD property,
          [Optional, Out] DWORD* propertyRegDataType,
          [Out] byte[] propertyBuffer,
          DWORD propertyBufferSize,
          out DWORD requiredSize,
          [Optional] string machineName,
          PVOID reserved);

        /* Sets a specified device class property in the registry. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiSetClassRegistryProperty(
            ref GUID classGuid,
            DWORD property,
            [Optional, In] byte[] propertyBuffer,
            DWORD propertyBufferSize,
            [Optional] string machineName,
            PVOID reserved);

        //
        // Device
        //

        /* Opens a registry storage key for device-specific configuration information and returns a handle to the key. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern SafeRegistryHandle SetupDiOpenDevRegKey(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DWORD scope,
            DWORD hwProfile,
            DWORD keyType,
            ACCESS_MASK samDesired);

        /* Creates a registry storage key for device-specific configuration information and returns a handle to the key. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern SafeRegistryHandle SetupDiCreateDevRegKey(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DWORD scope,
            DWORD hwProfile,
            DWORD keyType,
            [Optional] IntPtr infHandle,
            [Optional] string infSectionName);

        /* Deletes the specified user-accessible registry key(s) associated with a device information element. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiDeleteDevRegKey(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DWORD scope,
            DWORD hwProfile,
            DWORD keyType);

        /* Retrieves the specified Plug and Play device property. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiGetDeviceRegistryProperty(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            SPDRP property,
            [Optional, Out] out uint propertyRegDataType,
            [Optional, Out] byte[] propertyBuffer,
            uint propertyBufferSize,
            [Optional, Out] out uint requiredSize);

        /* Sets the specified Plug and Play device property. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiSetDeviceRegistryProperty(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            SPDRP property,
            byte[] propertyBuffer,
            DWORD propertyBufferSize);

        //
        // Device Interface
        //

        /* Opens the registry subkey that is used by applications and drivers to store information
            that is specific to a device interface instance
            and returns a handle to the key. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern SafeRegistryHandle SetupDiOpenDeviceInterfaceRegKey(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            DWORD reserved,
            ACCESS_MASK samDesired);

        /* Creates a registry subkey for storing information about a device interface instance
            and returns a handle to the key. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern SafeRegistryHandle SetupDiCreateDeviceInterfaceRegKey(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            DWORD reserved,
            ACCESS_MASK samDesired,
            [Optional] IntPtr infHandle,
            [Optional] string infSectionName);

        /* Deletes the registry subkey that was used by applications and drivers to store information
            that is specific to a device interface instance.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiDeleteDeviceInterfaceRegKey(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            DWORD reserved);

        #endregion

        #region Install Params

        //
        // Class
        //

        // Use this Structures
        // Depend on the InstallFunction
        //
        //SP_PROPCHANGE_PARAMS
        //SP_REMOVEDEVICE_PARAMS
        //SP_SELECTDEVICE_PARAMS
        //SP_TROUBLESHOOTER_PARAMS
        //SP_UNREMOVEDEVICE_PARAMS
        //SP_POWERMESSAGEWAKE_PARAMS

        /* Retrieves class install parameters for a device information set
            or a particular device information element.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiGetClassInstallParams(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            out SP_CLASSINSTALL_HEADER classInstallParams,
            DWORD classInstallParamsSize,
            out DWORD requiredSize);

        /* Sets or clears class install parameters for a device information set
            or a particular device information element.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiSetClassInstallParams(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            ref SP_CLASSINSTALL_HEADER classInstallParams,
            DWORD classInstallParamsSize);

        //
        // Device
        //

        //var deviceInstallParams = new SP_DEVINSTALL_PARAMS();
        //deviceInstallParams.cbSize = Marshal.SizeOf(deviceInstallParams);

        /* Retrieves device install parameters for a device information set
            or a particular device information element. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetDeviceInstallParams(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            out SP_DEVINSTALL_PARAMS deviceInstallParams);

        /* Sets device install parameters for a device information set
            or a particular device information element. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiSetDeviceInstallParams(
        HDEVINFO deviceInfoSet,
        ref SP_DEVINFO_DATA deviceInfoData,
        ref SP_DEVINSTALL_PARAMS deviceInstallParams);

        //
        // Driver
        //

        /* Retrieves install parameters for the specified driver. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiGetDriverInstallParams(
            HDEVINFO deviceInfoSet,
            [Optional] SP_DEVINFO_DATA* deviceInfoData,
            ref SP_DRVINFO_DATA driverInfoData,
            out SP_DRVINSTALL_PARAMS driverInstallParams);

        /* Sets the installation parameters for the specified driver. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiSetDriverInstallParams(
            HDEVINFO deviceInfoSet,
            [Optional] SP_DEVINFO_DATA* deviceInfoData,
            ref SP_DRVINFO_DATA driverInfoData,
            ref SP_DRVINSTALL_PARAMS driverInstallParams);

        #endregion


        #region Driver :: Information

        //
        // Driver Selection 
        //

        /* Default handler for the DIF_SELECTDEVICE request. */
        // SetupDiSelectDevice

        /* Displays a dialog that asks the user for the path of an OEM installation disk. */
        // SetupDiAskForOEMDisk

        /* Selects a driver for a device by using an OEM path supplied by the user. */
        // SetupDiSelectOEMDrv 

        //
        // Driver Info
        //

        /* Enumerates the members of a driver information list. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern BOOL SetupDiEnumDriverInfo(
            HDEVINFO deviceInfoSet,
            [Optional] SP_DEVINFO_DATA* deviceInfoData,
            // CLASSDRIVER	1
            // COMPATDRIVER	2
            uint driverType,
            uint memberIndex,
            ref SP_DRVINFO_DATA driverInfoData);

        /* Builds a list of drivers associated with a specified device instance
            or with the device information set's global class driver list.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiBuildDriverInfoList(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            // CLASSDRIVER	1
            // COMPATDRIVER	2
            uint driverType);

        /* Destroys a driver information list. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern bool SetupDiDestroyDriverInfoList(
            HDEVINFO deviceInfoSet,
            [Optional] SP_DEVINFO_DATA* deviceInfoData,
            // CLASSDRIVER	1
            // COMPATDRIVER	2
            uint driverType);

        /* Retrieves detailed information for a specified driver information element. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern bool SetupDiGetDriverInfoDetail(
            HDEVINFO deviceInfoSet,
            [Optional] SP_DEVINFO_DATA* deviceInfoData,
            ref SP_DRVINFO_DATA driverInfoData,
            ref SP_DRVINFO_DETAIL_DATA driverInfoDetailData,
            uint driverInfoDetailDataSize,
            out uint requiredSize);

        /* Cancels a driver list search that is currently underway in a different thread. */
        // SetupDiCancelDriverInfoSearch 

        /* Retrieves the member of a driver list that was selected as the driver to install. */
        // SetupDiGetSelectedDriver 

        /* Sets the specified member of a driver list as the currently selected-driver.
            It can also be used to reset the driver list so that there is no currently-selected driver. */
        // SetupDiSetSelectedDriver 

        #endregion

        #region Driver :: Installation

        //
        // Device
        //

        /* Installs a specified driver that is preinstalled in the driver store
            on a PnP device that is present in the system.
            (Windows Vista and later versions of Windows) */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL DiInstallDevice(
            SafeWindowHandle hwndParent,
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            ref SP_DRVINFO_DATA driverInfoData,
            DWORD flags,
            out BOOL needReboot);

        /* Uninstalls a device and removes its device node (devnode) ) from the system.
            (Windows Vista and later versions of Windows) */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL DiUninstallDevice(
            SafeWindowHandle hwndParent,
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DWORD flags,
            out BOOL needReboot);

        /* Displays the Hardware Update wizard for a specified device.
            (Windows Vista and later versions of Windows) */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL DiShowUpdateDevice(
            SafeWindowHandle hwndParent,
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DWORD flags,
            out BOOL needReboot);

        //
        // Driver
        //

        /* Preinstalls a driver in the driver store and then installs the driver
            on matching PnP devices that are present in the system.
            (Windows Vista and later versions of Windows)  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL DiInstallDriver(
            SafeWindowHandle hwndParent,
            string fullInfPath,
            DWORD flags,
            out BOOL needReboot);

        /* Installs a selected driver on a selected device. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL InstallSelectedDriver(
            SafeWindowHandle hwndParent,
            HDEVINFO deviceInfoSet,
            string reserved,
            BOOL backup,
            out DWORD bReboot);

        /* Rolls back the driver that is installed on a specified device
            to the backup driver set for the device.
            (Windows Vista and later versions of Windows) */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL DiRollbackDriver(
          HDEVINFO deviceInfoSet,
          ref SP_DEVINFO_DATA deviceInfoData,
          SafeWindowHandle hwndParent,
          DWORD flags,
          out BOOL needReboot);

        #endregion


        #region Device :: Interface

        //
        // Device Interface
        //

        /* Retrieves information about an existing device interface
            and adds it to the specified device information set.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiOpenDeviceInterface(
            HDEVINFO deviceInfoSet,
            string devicePath,
            DWORD openFlags,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        /* Registers device functionality (a device interface) for a device. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiCreateDeviceInterface(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            ref Guid interfaceClassGuid,
            [Optional] string referenceString,
            uint creationFlags,
            out SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        /* The default handler for the DIF_INSTALLINTERFACES request.
            It installs the interfaces that are listed in a DDInstall.Interfaces section of a device INF file. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiInstallDeviceInterfaces(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* Deletes a device interface from a device information set. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiDeleteDeviceInterfaceData(
          HDEVINFO deviceInfoSet,
          ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        /* Removes a registered device interface from the system. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiRemoveDeviceInterface(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        /* Returns a context structure for a device interface element of a device information set. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern bool SetupDiEnumDeviceInterfaces(
            HDEVINFO deviceInfoSet,
            [Optional] SP_DEVINFO_DATA* deviceInfoData,
            ref GUID interfaceClassGuid,
            uint memberIndex,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        //
        // { Get }
        //

        /* Returns an alias of the specified device interface. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetDeviceInterfaceAlias(
          HDEVINFO deviceInfoSet,
          ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
          ref Guid aliasInterfaceClassGuid,
          out SP_DEVICE_INTERFACE_DATA aliasDeviceInterfaceData);

        /* Returns details about a particular device interface. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern bool SetupDiGetDeviceInterfaceDetail(
            HDEVINFO deviceInfoSet,
            // cbSize must be Initilized Before
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            // cbSize must be Initilized Before
            SP_DEVICE_INTERFACE_DETAIL_DATA* deviceInterfaceDetailData,
            uint deviceInterfaceDetailDataSize,
            out uint requiredSize,
            // cbSize must be Initilized Before
            ref SP_DEVINFO_DATA deviceInfoData);

        //
        // { Set }
        //

        /* Sets a specified device interface as the default interface for a device class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiSetDeviceInterfaceDefault(
            HDEVINFO deviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            DWORD flags,
            PVOID reserved);

        #endregion

        #region Device :: Information

        //
        // Selected Device
        //

        /* Retrieves the currently-selected device for the specified device information set. */
        // SetupDiGetSelectedDevice 

        /* Sets the specified device information element to be the currently-selected member of a device information set.
            This function is typically used by an installation wizard. */
        // SetupDiSetSelectedDevice 

        //
        // Device Info List
        //

        /* Creates an empty device information set.
            This set can be associated with a class GUID. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern HDEVINFO SetupDiCreateDeviceInfoList(
            [Optional] Guid* classGuid,
            [Optional] SafeWindowHandle hwndParent);

        /* Creates an empty device information set.
            This set can be associated with a class GUID and can be for devices on a remote computer. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public unsafe static extern HDEVINFO SetupDiCreateDeviceInfoListEx(
            [Optional] Guid* classGuid,
            [Optional] SafeWindowHandle hwndParent,
            [Optional] string machineName,
            IntPtr reserved);

        /* Destroys a device information set and frees all associated memory. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiDestroyDeviceInfoList(
            HDEVINFO deviceInfoSet);

        /* Retrieves the class GUID associated with a device information set if it has an associated class. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetDeviceInfoListClass(
            HDEVINFO deviceInfoSet,
            out GUID classGuid);

        /* Retrieves information associated with a device information set including the class GUID,
            remote computer handle, and remote computer name. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetDeviceInfoListDetail(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_LIST_DETAIL_DATA deviceInfoSetDetailData);

        //
        // Device Info
        //

        /* Retrieves information about an existing device instance and adds it to the specified device information set.  */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiOpenDeviceInfo(
            HDEVINFO deviceInfoSet,
            string deviceInstanceId,
            [Optional] SafeWindowHandle hwndParent,
            DWORD openFlags,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* Creates an empty device information set. This set can be associated with a class GUID. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiCreateDeviceInfo(
            HDEVINFO deviceInfoSet,
            string deviceName,
            ref GUID classGuid,
            [Optional] string deviceDescription,
            [Optional] SafeWindowHandle hwndParent,
            DWORD creationFlags,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* Deletes a member from the specified device information set.
            This function does not delete the actual device. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiDeleteDeviceInfo(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* Registers a newly created device instance with the Plug and Play manager. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiRegisterDeviceInfo(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            DWORD flags,
            IntPtr compareProc,
            IntPtr compareContext,
            out SP_DEVINFO_DATA dupDeviceInfoData);

        /* Returns a context structure for a device information element of a device information set. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiEnumDeviceInfo(
            // From SetupDiGetClassDevs || SetupDiCreateDeviceInfoList
            HDEVINFO deviceInfoSet,
            uint memberIndex,
            ref SP_DEVINFO_DATA deviceInfoData);

        //
        // { Get }
        //

        /* Retrieves the device instance ID associated with a device information element. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiGetDeviceInstanceId(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData,
            StringBuilder deviceInstanceId,
            uint deviceInstanceIdSize,
            out uint requiredSize);

        /* Retrieves handles to the property sheets of a specified device information element
            or of the device setup class of a specified device information set. */
        // SetupDiGetClassDevPropertySheets 

        #endregion

        #region Device :: Installation

        // need to be called after using 
        // SetupDiGetClassInstallParams
        // SetupDiSetClassInstallParams

        /* Calls the appropriate class installer,
            and any registered co-installers,
            with the specified installation request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiCallClassInstaller(
            DIF installFunction,
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* The default handler for the DIF_INSTALLDEVICE request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiInstallDevice(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* The default handler for the DIF_REMOVEDEVICE request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiRemoveDevice(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* The default handler for the DIF_UNREMOVE request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiUnremoveDevice(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* The default handler for the DIF_PROPERTYCHANGE request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiChangeState(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* The default handler for the DIF_INSTALLDEVICEFILES request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiInstallDriverFiles(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* The default handler for the DIF_SELECTBESTCOMPATDRV request. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiSelectBestCompatDrv(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        /* This function is the default handler for DIF_REGISTER_COINSTALLERS.
            Registers the device-specific co-installers listed in the INF file for the specified device. */
        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern BOOL SetupDiRegisterCoDeviceInstallers(
            HDEVINFO deviceInfoSet,
            ref SP_DEVINFO_DATA deviceInfoData);

        #endregion

    }
}