
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
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MSDN.SafeHandle
{
    public struct SafeDesktopHandle
    {
        public IntPtr stdHandle;

        public SafeDesktopHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeDesktopHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }

        public bool Close()
        {
            return user32.CloseDesktop(this);
        }
        public bool Switch()
        {
            Input.Close();
            Thread.Close();

            Thread = this;
            return user32.SwitchDesktop(this);
        }
        private static bool Switch(SafeDesktopHandle hDesktop)
        {
            return user32.SwitchDesktop(hDesktop);
        }

        public static SafeDesktopHandle Input
        {
            get
            {
                return user32.OpenInputDesktop(
                    0, true, ACCESS_MASK.DesktopAll | ACCESS_MASK.GenericAll);
            }
        }

        public static SafeDesktopHandle Thread
        {
            get
            {
                return user32.GetThreadDesktop(
                    kernel32.GetCurrentThreadId());
            }
            set
            {
                user32.SetThreadDesktop(value);
            }
        }

        public string Name
        {
            get
            {
                uint lpnLengthNeeded;
                user32.GetUserObjectInformation(
                    stdHandle,
                    UserObjectInformation.UOI_NAME,
                    IntPtr.Zero, 0,
                    out lpnLengthNeeded);

                var strPtr = kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed, lpnLengthNeeded);
                user32.GetUserObjectInformation(
                    stdHandle,
                    UserObjectInformation.UOI_NAME,
                    strPtr, lpnLengthNeeded,
                    out lpnLengthNeeded);

                var str = strPtr.ToUnicodeStr();
                kernel32.GlobalFree(strPtr);
                return str;
            }
        }

        public static string[] All
        {
            get
            {
                var arr = new List<string>();
                user32.EnumDesktops(
                    user32.GetProcessWindowStation(),
                    delegate(IntPtr desktop, IntPtr param) { arr.Add(desktop.ToUnicodeStr()); return true; },
                    IntPtr.Zero);
                return arr.ToArray();
            }
        }

        public static void ExportDesktop(
            out SafeDesktopHandle hOriginalInput,
            out SafeDesktopHandle hOriginalThread )
        {
            hOriginalInput = Input;
            hOriginalThread = Thread;
        }

        public static void ImportDesktop(
            SafeDesktopHandle hOriginalInput,
            SafeDesktopHandle hOriginalThread)
        {
            Switch(hOriginalInput);
            Thread = hOriginalThread;
        }

        public unsafe bool CreateProcess(
            string applicationName,
            string commandLine)
        {
            var lpStartupInfo = new STARTUPINFO()
            {
                cb = sizeof(STARTUPINFO),
                lpDesktop = Marshal.StringToHGlobalUni(Name)
            };
            PROCESS_INFORMATION lpProcessInformation;
            return kernel32.CreateProcess(
                applicationName, commandLine,
                IntPtr.Zero, IntPtr.Zero,
                false, 0,
                new Struct.Environment(0),
                null,
                ref lpStartupInfo,
                out lpProcessInformation);
        }

        public static SafeDesktopHandle CreateDesktop(string desktop)
        {
            if (string.IsNullOrEmpty(desktop))
                return new SafeDesktopHandle(0);

            var desktopPtr =  user32.CreateDesktop(desktop, IntPtr.Zero, IntPtr.Zero, 0x1, ACCESS_MASK.DesktopAll | ACCESS_MASK.GenericAll, IntPtr.Zero);
            desktopPtr.CreateProcess(@"c:\windows\explorer.exe", null);
            return desktopPtr;
        }

        public static SafeDesktopHandle OpenDesktop(string desktop)
        {
            return user32.OpenDesktop(desktop, 0x1, false, ACCESS_MASK.DesktopAll | ACCESS_MASK.GenericAll);
        }
    }
    public struct SafeWindowStationHandle
    {
        public IntPtr stdHandle;

        public SafeWindowStationHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeWindowStationHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
    }

    public struct SafeSidHandle
    {
        // Security Identifiers
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa379571(v=vs.85).aspx

        public IntPtr stdHandle;
        public SafeSidHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeSidHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }

        public static SafeSidHandle Default
        {
            get { return new SafeSidHandle(0); }
        }
        public bool Release()
        {
            return (advapi32.FreeSid(this) == IntPtr.Zero);
        }
        public String Account
        {
            get
            {
                uint
                    cchName = 256,
                    cchReferencedDomainName = 256;

                StringBuilder
                    lpName = new StringBuilder(256),
                    referencedDomainName = new StringBuilder(256);

                SID_NAME_USE peUse;

                advapi32.LookupAccountSid(
                    null, this, lpName, ref cchName, referencedDomainName, ref cchReferencedDomainName, out  peUse);
                return Convert.ToString(lpName);
            }
        }

        public uint Length
        {
            get { return advapi32.GetLengthSid(this); }
        }

        public override string ToString()
        {
            IntPtr stringSid;
            advapi32.ConvertSidToStringSid(
                this, out stringSid);

            return stringSid.ToUnicodeStr();
        }
        public bool Equals(SafeSidHandle other)
        {
            return ToString() == other.ToString();
        }

        public static SafeSidHandle AccountSid(string lpAccountName)
        {
            uint cbSid = 0;
            var sid = new SafeSidHandle();
            uint cchReferencedDomainName = 256;
            var referencedDomainName = new StringBuilder(256);
            SID_NAME_USE peUse;

            if (!advapi32.LookupAccountName(
                null, lpAccountName, sid, ref cbSid, referencedDomainName, ref cchReferencedDomainName, out  peUse) && cbSid != 0)
            {
                sid.stdHandle = Marshal.AllocHGlobal((int)cbSid);
                advapi32.LookupAccountName(
                    null, lpAccountName, sid, ref cbSid, referencedDomainName, ref cchReferencedDomainName, out  peUse);
            }
            return sid;
        }
        public static SafeSidHandle StringSid(string stringSid)
        {
            SafeSidHandle sid;
            return advapi32.ConvertStringSidToSid(
                stringSid, out sid) ? sid : new SafeSidHandle(0);
        }
    }
    public struct SafeAclHandle
    {
        public IntPtr stdHandle;
        public SafeAclHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeAclHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public static SafeAclHandle Default
        {
            get
            {
                var sd = new SafeAclHandle(0);
                sd.Initialize(0x0);
                return sd;
            }
        }

        /// <summary>
        /// calculate nececery size for specific Ace
        /// based on Sid,Type,NumOfAces
        /// </summary>
        /// <returns></returns>
        public unsafe uint Calculate(SafeSidHandle psid, AceType type, uint numOfAces)
        {
            // The following table lists the currently defined ACE types.
            // http://msdn.microsoft.com/en-us/library/windows/desktop/aa374912(v=vs.85).aspx

            uint structSize = 0;

            switch (type)
            {
                case AceType.SYSTEM_AUDIT:
                case AceType.ACCESS_DENIED:
                case AceType.ACCESS_ALLOWED:
                    structSize = (uint)sizeof(ACE);
                    break;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_OBJECT:
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_OBJECT:
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_OBJECT:
                    structSize = (uint)sizeof(ACE_OBJECT);
                    break;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK:
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK:
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK:
                    structSize = (uint)sizeof(ACE_CALLBACK);
                    break;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK | AceType.SYSTEM_AUDIT_OBJECT:
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK | AceType.ACCESS_DENIED_OBJECT:
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK | AceType.ACCESS_ALLOWED_OBJECT:
                    structSize = (uint)sizeof(ACE_CALLBACK_OBJECT);
                    break;

                case AceType.SYSTEM_MANDATORY_LABEL:
                    structSize = (uint)sizeof(ACE_MANDATORY_LABEL);
                    break;
            }

            // generate size
            var cbAcl =
                (uint)sizeof(ACL) +             // sizeof(ACL_INFO)
                (numOfAces * structSize) +      // sizeof(ACE_Structare)
                (numOfAces * psid.Length) -     // + SID.Length
                (numOfAces * sizeof(uint));     // - sizeof(Uint)

            // align size
            cbAcl = ((cbAcl + (sizeof(uint) - 1)) & 0xfffffffc);
            return cbAcl;
        }

        /// <summary>
        /// Initialize new ACL table
        /// </summary>
        public bool Initialize(uint size)
        {
            size += 0xc; // reserved space
            stdHandle = kernel32.LocalAlloc(LocalMemoryFlags.Fixed, size);
            return advapi32.InitializeAcl(this, size, 0x2);
        }

        /// <summary>
        /// size is optional if we 
        /// want to duplicate entiries
        /// and add new one's
        /// [using Add(ACE_HEADER_BASE) methood]
        /// [using Add(AceType,ACCESS_MASK,SafeSidHandle) methood]
        /// 
        /// in case we want add new entiries
        /// and keep (size = 0) as is ....
        /// call Add(EXPLICIT_ACCESS[])
        /// </summary>
        public void Duplicate(SafeAclHandle other, uint size = 0)
        {
            // easy way
            //EXPLICIT_Entries = other.EXPLICIT_Entries;

            // hard way
            Initialize(other.Information.AclBytesInUse + size);
            HeaderEntries = other.HeaderEntries;
        }

        /// <summary>
        /// this methood dont requied allocate new size
        /// the function do the ugly Job .....
        /// </summary>
        /// <param name="access"></param>
        public void Add(params EXPLICIT_ACCESS[] access)
        {
            // quick way ...
            ExplicitEntries = access;
        }

        /// <summary>
        /// before add make sure you have allocated enough size
        /// using Calculate and [[ Initialize(...) or Duplicate(..., sizeToAdd) ]]
        /// </summary>
        public void Add(params ACE_HEADER_BASE[] header)
        {
            // quick way ...
            HeaderEntries = header;
        }

        /// <summary>
        /// before add make sure you have allocated enough size
        /// using Calculate and [[ Initialize(...) or Duplicate(..., sizeToAdd) ]]
        /// </summary>
        public unsafe void Add(ACE_HEADER_BASE aceHeader, uint index)
        {
            if (!advapi32.AddAce(this, 0x2, index, &aceHeader, aceHeader.Size))
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// before add make sure you have allocated enough size
        /// using Calculate and [[ Initialize(size) or Duplicate(object,sizeToAdd) ]]
        /// </summary>
        public void Add(
            AceType type,
            AceFlags flags,                 // nececerry in specific cases
            ACCESS_MASK mask,
            SafeSidHandle sid,
            Guid objectTypeGuid,            // nececerry in specific cases
            Guid inheritedObjectTypeGuid)   // nececerry in specific cases
        {
            var dwRes = false;

            switch (type)
            {
                case AceType.SYSTEM_AUDIT:
                    dwRes = advapi32.AddAuditAccessAce(this, 0x2, mask, sid, true, false);
                    break;
                case AceType.ACCESS_DENIED:
                    dwRes = advapi32.AddAccessDeniedAce(this, 0x2, mask, sid);
                    break;
                case AceType.ACCESS_ALLOWED:
                    dwRes = advapi32.AddAccessAllowedAce(this, 0x2, mask, sid);
                    break;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_OBJECT:
                    break;
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_OBJECT:
                    dwRes = advapi32.AddAccessDeniedObjectAce(this, 0x2, flags,mask, ref objectTypeGuid, ref inheritedObjectTypeGuid, sid);
                    break;
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_OBJECT:
                    dwRes = advapi32.AddAccessAllowedObjectAce(this, 0x2, flags,mask, ref objectTypeGuid, ref inheritedObjectTypeGuid, sid);
                    break;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK:
                //case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK:
                //case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK:
                    break;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK | AceType.SYSTEM_AUDIT_OBJECT:
                //case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK | AceType.ACCESS_DENIED_OBJECT:
                //case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK | AceType.ACCESS_ALLOWED_OBJECT:
                    break;

                default:
                    throw new Exception("not supprted.");
                    break;
            }

            if (!dwRes)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// index taken from HeaderEntries / ExplicitEntries
        /// both contain same Data
        /// </summary>
        public bool Remove(uint index)
        {
            return advapi32.DeleteAce(this, index);
        }

        public unsafe bool Generate(
            ACCESS_MASK mask,
            AceType type,
            AceFlags flags,
            SafeSidHandle sid,
            Guid objectType,            // nececerry in specific cases
            Guid inheritedObjectType,   // nececerry in specific cases
            out ACE_HEADER_BASE aceHeaderBase)
        {
            var aceSize = Calculate(sid, type, 1);
            var aceHeader = (ACE_HEADER_BASE*)kernel32.LocalAlloc(LocalMemoryFlags.Fixed, aceSize);

            switch (type)
            {
                case AceType.SYSTEM_AUDIT:
                case AceType.ACCESS_DENIED:
                case AceType.ACCESS_ALLOWED:
                    
                    aceHeader->Ace.Header.AceType = type;
                    aceHeader->Ace.Header.AceFlags = flags;
                    aceHeader->Ace.Header.AceSize = (short)aceSize;
                    aceHeader->Ace.Mask = mask;
                    aceHeader->Sid = sid;

                    aceHeaderBase = *aceHeader;
                    return true;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_OBJECT:
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_OBJECT:
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_OBJECT:

                    aceHeader->AceObject.Header.AceType = type;
                    aceHeader->AceObject.Header.AceFlags = flags;
                    aceHeader->AceObject.Header.AceSize = (short)aceSize;
                    aceHeader->AceObject.Mask = mask;
                    aceHeader->AceObject.ObjectType = objectType;
                    aceHeader->AceObject.InheritedObjectType = inheritedObjectType;
                    aceHeader->Sid = sid;

                    aceHeaderBase = *aceHeader;
                    return true;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK:
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK:
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK:

                    aceHeader->AceCallback.Header.AceType = type;
                    aceHeader->AceCallback.Header.AceFlags = flags;
                    aceHeader->AceCallback.Header.AceSize = (short)aceSize;
                    aceHeader->AceCallback.Mask = mask;

                    aceHeaderBase = *aceHeader;
                    return true;

                //case AceType.SYSTEM_AUDIT | AceType.SYSTEM_AUDIT_CALLBACK | AceType.SYSTEM_AUDIT_OBJECT:
                case AceType.ACCESS_DENIED | AceType.ACCESS_DENIED_CALLBACK | AceType.ACCESS_DENIED_OBJECT:
                case AceType.ACCESS_ALLOWED | AceType.ACCESS_ALLOWED_CALLBACK | AceType.ACCESS_ALLOWED_OBJECT:

                    aceHeader->AceCallbackObject.Header.AceType = type;
                    aceHeader->AceCallbackObject.Header.AceFlags = flags;
                    aceHeader->AceCallbackObject.Header.AceSize = (short)aceSize;
                    aceHeader->AceCallbackObject.Mask = mask;
                    aceHeader->AceCallbackObject.ObjectType = objectType;
                    aceHeader->AceCallbackObject.InheritedObjectType = inheritedObjectType;

                    aceHeaderBase = *aceHeader;
                    return true;

                case AceType.SYSTEM_MANDATORY_LABEL:

                    aceHeader->AceMandatoryLabel.Header.AceType = type;
                    aceHeader->AceMandatoryLabel.Header.AceFlags = flags;
                    aceHeader->AceMandatoryLabel.Header.AceSize = (short)aceSize;
                    aceHeader->AceMandatoryLabel.Mask = mask;

                    aceHeaderBase = *aceHeader;
                    return true;
            }

            aceHeaderBase = new ACE_HEADER_BASE();
            return false;
        }

        public bool Generate(
            ACCESS_MASK mask,
            ACCESS_MODE mode,
            AceFlags flags,
            TRUSTEE_FORM form,
            TRUSTEE_TYPE type,
            IntPtr handle,
            out EXPLICIT_ACCESS explicitAccess)
        {
            explicitAccess = new EXPLICIT_ACCESS()
            {
                grfAccessPermissions = mask,
                grfAccessMode = mode,
                grfInheritance = flags,
                Trustee = new TRUSTEE()
                {
                    TrusteeForm = form,
                    TrusteeType = type,
                    ptstrName = handle
                }
            };
            return true;
        }

        /// <summary>
        /// free allcated memory
        /// </summary>
        public void Free()
        {
            kernel32.LocalFree(this.stdHandle);
        }

        /// <summary>
        /// Validate Ace
        /// </summary>
        public bool IsValid
        {
            get { return advapi32.IsValidAcl(this); }
        }

        /// <summary>
        /// Set >> [merge] the new entiries
        /// with current entiries,
        /// 
        /// example ... ::
        /// ExplicitEntries = new []{a,b,c};
        /// ExplicitEntries = new []{d,e,f};
        /// the result will be new ACL
        /// with {a,b,c,d,e,f}
        /// 
        /// SO, in case of create new entiries
        /// initilize new SafeAclHandle(0)
        /// and modify ExplicitEntries Once
        /// </summary>
        public unsafe EXPLICIT_ACCESS[] ExplicitEntries
        {
            get
            {
                uint pcCountOfExplicitEntries;
                EXPLICIT_ACCESS* pListOfExplicitEntries;
                advapi32.GetExplicitEntriesFromAcl(
                    this, out pcCountOfExplicitEntries, out pListOfExplicitEntries);
                var arr = new EXPLICIT_ACCESS[pcCountOfExplicitEntries];
                for (var i = 0; i < pcCountOfExplicitEntries; i++) { arr[i] = pListOfExplicitEntries[i]; }
                return arr;
            }
            set
            {
                fixed (EXPLICIT_ACCESS* access = &(value[0]))
                {
                    advapi32.SetEntriesInAcl(
                        (uint)value.Length,
                        access, this, out this);
                }
            }
        }

        /// <summary>
        /// Set >> create new entiries.
        /// [if we allocated enough memory]
        /// 
        /// SO, in case of duplicate [and add more entiries]
        /// use Duplicate() methood [with size parameter]
        /// and call Add(newObject,lastItemIndex).
        /// </summary>
        public unsafe ACE_HEADER_BASE[] HeaderEntries
        {
            get
            {
                ACE_HEADER_BASE* pAce;
                var cCount = Information.AceCount;
                var cArr = new ACE_HEADER_BASE[cCount];

                for (uint i = 0; i < cCount; i++)
                {
                    advapi32.GetAce(this, i, out pAce);
                    cArr[i] = *pAce;
                }
                return cArr;
            }
            set
            {
                fixed (ACE_HEADER_BASE* ptr = &value[0])
                {
                    for (var i = 0; i < value.Length; i++)
                        Add(ptr[i], (uint)i);
                }  
            }
        }

        /// <summary>
        /// ACL information
        /// </summary>
        public unsafe ACL_SIZE_INFORMATION Information
        {
            get
            {
                var pAclInformation = kernel32.LocalAlloc(
                    LocalMemoryFlags.Fixed, (uint)sizeof(ACL_SIZE_INFORMATION));
                advapi32.GetAclInformation(
                    this,
                    pAclInformation, (uint) sizeof (ACL_SIZE_INFORMATION),
                    ACL_INFORMATION_CLASS.AclSizeInformation);
                return *(ACL_SIZE_INFORMATION*)pAclInformation;
            }
        }
    }
    public struct SafeSecurityDescriptorHandle
    {
        #region Ctor
        public IntPtr stdHandle;
        public SafeSecurityDescriptorHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeSecurityDescriptorHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        } 
        #endregion

        #region Init
        public unsafe void Initialize(uint size = 0)
        {
            // manually build //

            // allocate memory space
            stdHandle = kernel32.LocalAlloc(LocalMemoryFlags.Fixed, size > 0 ? size : (uint)sizeof(SECURITY_DESCRIPTOR));
            if (!advapi32.InitializeSecurityDescriptor(this, 0x1))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());
        }

        /// <summary>
        /// Build it nice high level function
        /// that do same job we done here ...
        /// </summary>
        public unsafe void Initialize(
            SafeSidHandle owner,
            SafeSidHandle group,
            SafeAclHandle acl)
        {
            // manually build //

            // allocate memory space
            stdHandle = kernel32.LocalAlloc(
                LocalMemoryFlags.Fixed, (uint)sizeof(SECURITY_DESCRIPTOR));
            if (!advapi32.InitializeSecurityDescriptor(this, 0x1))
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            // set properties
            this.Owner = owner;
            this.Group = group;
            this.Dacl = acl;
        }

        public static unsafe SafeSecurityDescriptorHandle Build(
            SafeSidHandle owner,
            SafeSidHandle group,
            EXPLICIT_ACCESS[] listOfAccessEntries)
        {
            // automatic build //

            // set output
            UInt32 size;
            SafeSecurityDescriptorHandle newSD;

            // set owner
            var pOwner = new TRUSTEE()
            {
                TrusteeForm = TRUSTEE_FORM.TRUSTEE_IS_SID,
                TrusteeType = TRUSTEE_TYPE.TRUSTEE_IS_GROUP,
                ptstrName = owner.stdHandle
            };

            // set group
            var pGroup = new TRUSTEE()
            {
                TrusteeForm = TRUSTEE_FORM.TRUSTEE_IS_SID,
                TrusteeType = TRUSTEE_TYPE.TRUSTEE_IS_WELL_KNOWN_GROUP,
                ptstrName = group.stdHandle
            };

            // build all
            fixed (EXPLICIT_ACCESS* pListOfAccessEntries = &listOfAccessEntries[0])
                if (advapi32.BuildSecurityDescriptor(
                        &pOwner, &pGroup,
                        (uint)listOfAccessEntries.Length, pListOfAccessEntries,
                        0, (EXPLICIT_ACCESS*)0,                 // no sAcl
                        new SafeSecurityDescriptorHandle(0),    // no old source [if we have one, it will merge the old Acl with new List]
                        out size, out newSD) != Win32Error.SUCCESS)
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());

            // return result
            return newSD;
        } 
        #endregion   

        #region Convert
        public unsafe SafeSecurityDescriptorHandle ConvertToAbsoluteSD()
        {
            uint
                uu = 0,
                u1 = 0,
                u2 = 0,
                u3 = 0,
                u4 = 0;

            advapi32.MakeAbsoluteSD(
                this,
                (SECURITY_DESCRIPTOR*)0, ref uu,
                new SafeAclHandle(0), ref u1,
                new SafeAclHandle(0), ref u2,
                new SafeSidHandle(0), ref u3,
                new SafeSidHandle(0), ref u4);

            var pAbsoluteSD = new SafeSecurityDescriptorHandle
            {
                SecurityDescriptorHandle =
                    (SECURITY_DESCRIPTOR*)msvcrt.malloc(uu)
            };
            pAbsoluteSD.SecurityDescriptorHandle->Dacl = new SafeAclHandle(
                msvcrt.malloc(u1));
            pAbsoluteSD.SecurityDescriptorHandle->Sacl = new SafeAclHandle(
                msvcrt.malloc(u2));
            pAbsoluteSD.SecurityDescriptorHandle->Owner = new SafeSidHandle(
                msvcrt.malloc(u3));
            pAbsoluteSD.SecurityDescriptorHandle->Group = new SafeSidHandle(
                msvcrt.malloc(u4));

            advapi32.MakeAbsoluteSD(
                this,
                pAbsoluteSD.SecurityDescriptorHandle, ref uu,
                pAbsoluteSD.SecurityDescriptorHandle->Dacl, ref u1,
                pAbsoluteSD.SecurityDescriptorHandle->Sacl, ref u2,
                pAbsoluteSD.SecurityDescriptorHandle->Owner, ref u3,
                pAbsoluteSD.SecurityDescriptorHandle->Group, ref u4);

            return pAbsoluteSD;
        }
        public unsafe SafeSecurityDescriptorHandle ConvertToRelativeSD()
        {
            uint lpdwBufferLength = 0;
            advapi32.MakeSelfRelativeSD(
                this.SecurityDescriptorHandle,
                new SafeSecurityDescriptorHandle(0),
                ref lpdwBufferLength);

            var pSelfRelativeSD =
                new SafeSecurityDescriptorHandle(0);
            pSelfRelativeSD.Initialize(lpdwBufferLength);

            advapi32.MakeSelfRelativeSD(
                this.SecurityDescriptorHandle,
                pSelfRelativeSD,
                ref lpdwBufferLength);

            // done ....
            return pSelfRelativeSD;
        }
        #endregion

        #region Properties
        /// <summary>
        /// no intead to access directly ...
        /// only here for using with MakeAbsoluteSD
        /// its also depend on SD type ........
        /// [look inside the Api section]
        /// </summary>

        public unsafe SECURITY_DESCRIPTOR* SecurityDescriptorHandle
        {
            get { return (SECURITY_DESCRIPTOR*)this.stdHandle; }
            set { this.stdHandle = (IntPtr)value; }
        }

        public unsafe SECURITY_ATTRIBUTES Attributes
        {
            get
            {
                return new SECURITY_ATTRIBUTES()
                {
                    nLength = (uint)sizeof(SECURITY_ATTRIBUTES),
                    bInheritHandle = false,
                    lpSecurityDescriptor = this
                };
            }
        }

        public uint Length
        {
            get { return advapi32.GetSecurityDescriptorLength(this); }
        }

        public SafeSidHandle Owner
        {
            get
            {
                SafeSidHandle pOwner;
                bool lpbOwnerDefaulted;
                if (!advapi32.GetSecurityDescriptorOwner(
                    this, out pOwner, out lpbOwnerDefaulted))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());

                return pOwner;
            }
            set
            {
                if (!advapi32.SetSecurityDescriptorOwner(
                    this, value, true))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }

        public SafeSidHandle Group
        {
            get
            {
                SafeSidHandle pGroup;
                bool bGroupDefaulted;
                if (!advapi32.GetSecurityDescriptorGroup(
                    this, out pGroup, out bGroupDefaulted))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());

                return pGroup;
            }
            set
            {
                if (!advapi32.SetSecurityDescriptorGroup(
                    this, value, true))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }

        public bool ContainSacl
        {
            get
            {
                SafeAclHandle pSacl;
                bool lpbSaclPresent, lpbSaclDefaulted;
                advapi32.GetSecurityDescriptorSacl(
                    this, out lpbSaclPresent, out pSacl, out lpbSaclDefaulted);
                return lpbSaclPresent;
            }
        }

        public SafeAclHandle Sacl
        {
            get
            {
                SafeAclHandle pSacl;
                bool lpbSaclPresent, lpbSaclDefaulted;
                if (!advapi32.GetSecurityDescriptorSacl(
                    this, out lpbSaclPresent, out pSacl, out lpbSaclDefaulted))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
                return pSacl;
            }
            set
            {
                if (!advapi32.SetSecurityDescriptorSacl(
                    this, true, value, false))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }

        public bool ContainDacl
        {
            get
            {
                SafeAclHandle pDacl;
                bool lpbDaclPresent, lpbDaclDefaulted;
                advapi32.GetSecurityDescriptorDacl(
                    this, out lpbDaclPresent, out pDacl, out lpbDaclDefaulted);
                return lpbDaclPresent;
            }
        }

        public SafeAclHandle Dacl
        {
            get
            {
                SafeAclHandle pDacl;
                bool lpbDaclPresent, lpbDaclDefaulted;
                if (!advapi32.GetSecurityDescriptorDacl(
                    this, out lpbDaclPresent, out pDacl, out lpbDaclDefaulted))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
                return pDacl;
            }
            set
            {
                if (!advapi32.SetSecurityDescriptorDacl(
                    this, true, value, false))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
            }
        }

        public bool IsValid
        {
            get { return advapi32.IsValidSecurityDescriptor(this); }
        }
        #endregion

        #region Properties { Get }
        public static SafeSecurityDescriptorHandle Default
        {
            get
            {
                var sd = new SafeSecurityDescriptorHandle(0);
                sd.Initialize();
                return sd;
            }
        }
        public static SafeSecurityDescriptorHandle FromString(string securityDescriptorString)
        {
            int securityDescriptorSize;
            SafeSecurityDescriptorHandle securityDescriptor;
            advapi32.ConvertStringSecurityDescriptorToSecurityDescriptor(
                securityDescriptorString, 0x1, out securityDescriptor, out securityDescriptorSize);
            return securityDescriptor;
        }
        public static SafeSecurityDescriptorHandle FromObject(string hFileName)
        {
            uint lpnLengthNeeded;
            var pSecurityDescriptor =
                new SafeSecurityDescriptorHandle();
            advapi32.GetFileSecurity(
                hFileName,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                0x0, out lpnLengthNeeded);

            pSecurityDescriptor.Initialize(
                lpnLengthNeeded);
            advapi32.GetFileSecurity(
                hFileName,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                lpnLengthNeeded, out lpnLengthNeeded);
            return pSecurityDescriptor;
        }
        public static SafeSecurityDescriptorHandle FromObject(SafeRegistryHandle hKey)
        {
            uint lpnLengthNeeded;
            var pSecurityDescriptor =
                new SafeSecurityDescriptorHandle();
            advapi32.RegGetKeySecurity(
                hKey,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                out lpnLengthNeeded);

            pSecurityDescriptor.Initialize(
                lpnLengthNeeded);
            advapi32.RegGetKeySecurity(
                hKey,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                out lpnLengthNeeded);
            return pSecurityDescriptor;
        }
        public static SafeSecurityDescriptorHandle FromObject(SafeServiceHandle hService)
        {
            uint lpnLengthNeeded;
            var pSecurityDescriptor =
                new SafeSecurityDescriptorHandle();
            advapi32.QueryServiceObjectSecurity(
                hService,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                0x0, out lpnLengthNeeded);

            pSecurityDescriptor.Initialize(
                lpnLengthNeeded);
            advapi32.QueryServiceObjectSecurity(
                hService,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                lpnLengthNeeded, out lpnLengthNeeded);
            return pSecurityDescriptor;
        }
        public static SafeSecurityDescriptorHandle FromObject(SafeProcessHandle hProcess)
        {
            uint lpnLengthNeeded;
            var pSecurityDescriptor =
                new SafeSecurityDescriptorHandle();
            advapi32.GetKernelObjectSecurity(
                hProcess.stdHandle,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                0x0, out lpnLengthNeeded);

            pSecurityDescriptor.Initialize(
                lpnLengthNeeded);
            advapi32.GetKernelObjectSecurity(
                hProcess.stdHandle,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                lpnLengthNeeded, out lpnLengthNeeded);
            return pSecurityDescriptor;
        }
        public static SafeSecurityDescriptorHandle FromObject(SafeThreadHandle hThread)
        {
            uint lpnLengthNeeded;
            var pSecurityDescriptor =
                new SafeSecurityDescriptorHandle();
            advapi32.GetKernelObjectSecurity(
                hThread.stdHandle,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                0x0, out lpnLengthNeeded);

            pSecurityDescriptor.Initialize(
                lpnLengthNeeded);
            advapi32.GetKernelObjectSecurity(
                hThread.stdHandle,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                lpnLengthNeeded, out lpnLengthNeeded);
            return pSecurityDescriptor;
        }
        public static SafeSecurityDescriptorHandle FromObject(SafeEventHandle hEvent)
        {
            uint lpnLengthNeeded;
            var pSecurityDescriptor =
                new SafeSecurityDescriptorHandle();
            advapi32.GetKernelObjectSecurity(
                hEvent.stdHandle,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                0x0, out lpnLengthNeeded);

            pSecurityDescriptor.Initialize(
                lpnLengthNeeded);
            advapi32.GetKernelObjectSecurity(
                hEvent.stdHandle,
                SECURITY_INFORMATION.AllLite,
                pSecurityDescriptor,
                lpnLengthNeeded, out lpnLengthNeeded);
            return pSecurityDescriptor;
        }
        #endregion

        #region Properties { Set }
        public override string ToString()
        {
            uint stringSecurityDescriptorLen;
            var stringSecurityDescriptor = string.Empty;
            advapi32.ConvertSecurityDescriptorToStringSecurityDescriptor(
                this, 0x1, SECURITY_INFORMATION.All, ref stringSecurityDescriptor, out stringSecurityDescriptorLen);
            return stringSecurityDescriptor;
        }

        public bool ToObject(string hFileName)
        {
            return advapi32.SetFileSecurity(
                hFileName,
                SECURITY_INFORMATION.AllLite,
                this);
        }

        public bool ToObject(SafeRegistryHandle hKey)
        {
            return advapi32.RegSetKeySecurity(
                hKey,
                SECURITY_INFORMATION.AllLite,
                this) == 0;
        }

        public bool ToObject(SafeServiceHandle hService)
        {
            return advapi32.SetServiceObjectSecurity(
                hService,
                SECURITY_INFORMATION.AllLite,
                this);
        }

        public bool ToObject(SafeProcessHandle hProcess)
        {
            return advapi32.SetKernelObjectSecurity(
                hProcess.stdHandle,
                SECURITY_INFORMATION.AllLite,
                this);
        }

        public bool ToObject(SafeThreadHandle hThread)
        {
            return advapi32.SetKernelObjectSecurity(
                hThread.stdHandle,
                SECURITY_INFORMATION.AllLite,
                this);
        }

        public bool ToObject(SafeEventHandle hEvent)
        {
            return advapi32.SetKernelObjectSecurity(
                hEvent.stdHandle,
                SECURITY_INFORMATION.AllLite,
                this);
        }

        #endregion

        public void Free()
        {
            kernel32.LocalFree(stdHandle);
        }
    }

    public struct SafeSnapshotHandle
    {
        public IntPtr stdHandle;
        public SafeSnapshotHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeSnapshotHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
    }
    public struct SafeProcessHandle
    {
        public IntPtr stdHandle;
        public SafeProcessHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeProcessHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.CloseHandle(this.stdHandle);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }

        public void Terminate()
        {
            kernel32.TerminateProcess(this, 1);
        }
        public uint WaitForInputIdle(uint milliseconds)
        {
            return user32.WaitForInputIdle(this, milliseconds);
        }
        public bool isWow64
        {
            get
            {
                bool wow64Process;
                if (!kernel32.IsWow64Process(
                    this, out wow64Process))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());
                return wow64Process;
            }
        }

        public uint Id
        {
            get { return kernel32.GetProcessId(this); }
        }

        public uint ExitCode
        {
            get
            {
                uint lpExitCode;
                kernel32.GetExitCodeProcess(
                    this, out lpExitCode);
                return lpExitCode;
            }
        }

        public static SafeProcessHandle CurrentProcess
        {
            get
            {
                return kernel32.OpenProcess(
                    ProcessAccessFlags.All,
                    false,
                    kernel32.GetCurrentProcessId());
            }
        }
    }
    public struct SafeThreadHandle
    {
        public IntPtr stdHandle;
        public SafeThreadHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.CloseHandle(this.stdHandle);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }

        public void Suspend()
        {
            kernel32.SuspendThread(this);
        }
        public void Resume()
        {
            kernel32.ResumeThread(this);
        }
        public void Terminate()
        {
            kernel32.TerminateThread(this, 0);
        }
        public uint ExitCode
        {
            get
            {
                uint lpExitCode;
                kernel32.GetExitCodeThread(
                    this, out lpExitCode);
                return lpExitCode;
            }
        }

        public uint threadID
        {
            get { return kernel32.GetThreadId(this); }
        }

        public uint processID
        {
            get { return kernel32.GetProcessIdOfThread(this); }
        }

        public static SafeThreadHandle CurrentThread
        {
            get { return kernel32.GetCurrentThread(); }
        }

    }

    public struct SafeMailslotHandle
    {
        public IntPtr stdHandle;
        public SafeMailslotHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeMailslotHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        private SafeMailslotHandle(string mailSlot, uint maxMessageSize, TimeOut readTimeout, bool init)
        {
            var fixedSlot = init ? Parse(mailSlot) : mailSlot;
            var hSlot = kernel32.CreateMailslot(fixedSlot, maxMessageSize, readTimeout, IntPtr.Zero);
            stdHandle = hSlot.stdHandle;
        }

        public bool Release()
        {
            return kernel32.FreeConsole();
        }

        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }

        public bool GetInfo(out uint maxMessageSize, out uint nextSize, out uint messageCount, out TimeOut readTimeout)
        {
            return kernel32.GetMailslotInfo(
                this, out maxMessageSize, out nextSize, out messageCount, out readTimeout);
        }
        public bool SetInfo(TimeOut readTimeout)
        {
            return kernel32.SetMailslotInfo(
                this, readTimeout);
        }
        public bool Read(out byte[] buffer)
        {
            buffer = null;
            TimeOut readTimeout;
            uint nextSize, messageCount, maxMessageSize;
            var reader = new SafeFileHandle(stdHandle);
            return GetInfo(out maxMessageSize, out nextSize, out messageCount, out readTimeout) &&
                messageCount > 0 &&
                reader.Read(nextSize, out buffer) > 0;
        }
        public bool Read(out byte[] buffer, TimeOut timeout)
        {
            buffer = null;
            SetInfo(timeout);
            TimeOut readTimeout;
            uint nextSize, messageCount, maxMessageSize;
            var reader = new SafeFileHandle(stdHandle);
            return GetInfo(out maxMessageSize, out nextSize, out messageCount, out readTimeout) &&
                messageCount > 0 &&
                reader.Read(nextSize, out buffer) > 0;
        }

        public static string Parse(string mailSlot, string domain = null, string computer = null, Option opt = Option.Local)
        {
            switch (opt)
            {
                case Option.Local:
                    return string.Format(@"\\.\mailslot\{0}", mailSlot);
                case Option.Remote:
                    return string.Format(@"\\{0}\mailslot\{1}", computer, mailSlot);
                case Option.All:
                    return string.IsNullOrEmpty(domain) ?
                        string.Format(@"\\*\mailslot\{0}", mailSlot) :
                        string.Format(@"\\{0}\mailslot\{1}", domain, mailSlot);
            }
            return null;
        }
        public static SafeMailslotHandle CreateSlot(string mailSlot, uint maxMessageSize, TimeOut readTimeout, bool init = true)
        {
            return new SafeMailslotHandle(mailSlot, maxMessageSize, readTimeout, init);
        }
        public static SafeFileHandle ConnectSlot(string mailSlot, bool init = true)
        {
            var fixedSlot = init ? Parse(mailSlot) : mailSlot;
            return kernel32.CreateFile(
                fixedSlot,
                FileAccess.FileGenericRead | FileAccess.FileGenericWrite,
                FileShare.Read,
                IntPtr.Zero,
                FileMode.Open,
                FileAttributes.Normal,
                IntPtr.Zero);
        }
        public enum Option
        {
            Local,
            Remote,
            All
        }
    }
    public struct SafeSocketHandle
    {
        public IntPtr stdHandle;

        public SafeSocketHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeSocketHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public SocketError Release()
        {
            return ws2_32.closesocket(this);
        }
    }
    public struct SafePipeHandle
    {
        public IntPtr stdHandle;

        public SafePipeHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafePipeHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        private SafePipeHandle(
            string pipe, 
            NamePipeOpenMode openMode,
            NamePipeMode pipeMode)
        {
            var hNamePipe = kernel32.CreateNamedPipe(
                string.Format(@"\\.\pipe\{0}", pipe),
                openMode, pipeMode,
                255, 1024, 1024, TimeOut.Infinite, IntPtr.Zero);
            this.stdHandle = hNamePipe.stdHandle;
        }

        /* 
            server side ONLY,
            wait for a client process to connect,
            should be lunch in diffrent thread,
            because it can make this thread wait forever.
            */
        public void WaitForConnection()
        {
            var clientConnected = kernel32.ConnectNamedPipe(
                this, IntPtr.Zero);

            const int SUCCESS = 0x00000000;
            const int ERROR_PIPE_CONNECTED = 0x217;
            var lastWin32Error = Marshal.GetLastWin32Error();

            if (clientConnected ||
                lastWin32Error == SUCCESS ||
                lastWin32Error == ERROR_PIPE_CONNECTED)
                return;

            throw new Exception("fail to connect.");
        }

        /*
            server side ONLY,
            Disconnects the server end of a named pipe instance from a client process.
            */
        public bool ReleaseAllConnection()
        {
            return kernel32.DisconnectNamedPipe(this);
        }

        public void Release()
        {
            kernel32.DisconnectNamedPipe(this);
            this.stdHandle.Close();
        }

        public bool Read(ReadMode mode ,out byte[] buffer)
        {
            buffer = null;
            var length = (mode == 0) ?
                AvailableBytes : AvailableBytesForMessege;

            var reader = new SafeFileHandle(stdHandle);
            return length > 0 && 
                reader.Read(length, out buffer) > 0;
        }
        public bool Write(byte[] buffer)
        {
            var writer = new SafeFileHandle(stdHandle);
            return writer.Write(buffer) == buffer.Length;
        }
        public bool Flush()
        {
            var writer = new SafeFileHandle(stdHandle);
            return writer.Flush();
        }

        public bool HaveData
        {
            get { return AvailableBytes > 0; }
        }

        private uint AvailableBytes
        {
            get
            {
                uint lpBytesRead;
                uint lpTotalBytesAvail;
                uint lpBytesLeftThisMessage;

                kernel32.PeekNamedPipe(
                    this.stdHandle,
                    IntPtr.Zero, 0,
                    out lpBytesRead,
                    out lpTotalBytesAvail, 
                    out lpBytesLeftThisMessage);

                return lpTotalBytesAvail;
            }
        }

        public bool HaveMessege
        {
            get { return AvailableBytesForMessege > 0; }
        }

        private uint AvailableBytesForMessege
        {
            get
            {
                uint lpBytesRead;
                uint lpTotalBytesAvail;
                uint lpBytesLeftThisMessage;

                kernel32.PeekNamedPipe(
                    this.stdHandle,
                    IntPtr.Zero, 0,
                    out lpBytesRead,
                    out lpTotalBytesAvail,
                    out lpBytesLeftThisMessage);

                return lpBytesLeftThisMessage;
            }
        }

        public static SafePipeHandle CreatePipe(
            string pipe,
            NamePipeOpenMode openMode = NamePipeOpenMode.PIPE_ACCESS_INBOUND,
            NamePipeMode pipeMode = NamePipeMode.PIPE_TYPE_MESSAGE)
        {
            return new SafePipeHandle(pipe, openMode, pipeMode);
        }

        public static SafeFileHandle ConnectPipe(
            string pipe,
            FileAccess desiredAccess = FileAccess.FileGenericWrite)
        {
            var lpNamedPipeName = 
                string.Format(@"\\.\pipe\{0}", pipe);
                
            if (!IsPipeReady(
                lpNamedPipeName, 
                TimeOut.Infinite))
                throw new Exception("Pipe not ready.");

            return kernel32.CreateFile(
                lpNamedPipeName,
                desiredAccess,
                0, IntPtr.Zero,
                FileMode.Open,
                FileAttributes.Normal,
                IntPtr.Zero);
        }

        public static bool IsPipeReady(
            string lpNamedPipeName,
            TimeOut timeOut)
        {
            return kernel32.WaitNamedPipe(
                lpNamedPipeName, timeOut);
        }

        public enum ReadMode
        {
            ByteMode = 0,
            MessegeMode = 1
        }
    }

    public struct SafeEventHandle
    {
        public IntPtr stdHandle;

        public SafeEventHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeEventHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.CloseHandle(this.stdHandle);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }
        public uint SignalAndWait(IntPtr hObjectToWaitOn, uint dwMilliseconds)
        {
            return kernel32.SignalObjectAndWait(
                stdHandle, hObjectToWaitOn, dwMilliseconds, false);
        }
        public void Reset()
        {
            kernel32.ResetEvent(this);
        }
        public void Set()
        {
            kernel32.SetEvent(this);
        }
    }
    public struct SafeMutexHandle
    {
        public IntPtr stdHandle;

        public SafeMutexHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeMutexHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.ReleaseMutex(this);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }
        public uint SignalAndWait(IntPtr hObjectToWaitOn, uint dwMilliseconds)
        {
            return kernel32.SignalObjectAndWait(
                stdHandle, hObjectToWaitOn, dwMilliseconds, false);
        }
    }
    public struct SafeCriticalsection
    {
        public IntPtr stdHandle;
        public SafeCriticalsection(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeCriticalsection(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }

        public void Initialize()
        {
            kernel32.InitializeCriticalSection(out this);
        }
        public uint Set(uint spinCount)
        {
            return kernel32.SetCriticalSectionSpinCount(ref this, spinCount);
        }

        public void Enter()
        {
            kernel32.EnterCriticalSection(ref this);
        }
        public bool TryEnter()
        {
            return kernel32.TryEnterCriticalSection(ref this);
        }
        public void Leave()
        {
            kernel32.LeaveCriticalSection(ref this);
        }
        public void Delete()
        {
            kernel32.DeleteCriticalSection(ref this);
        }
    }
    public struct SafeSemaphoreHandle
    {
        public IntPtr stdHandle;

        public SafeSemaphoreHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeSemaphoreHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            int lpPreviousCount;
            return kernel32.ReleaseSemaphore(this, 1, out lpPreviousCount);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }
        public uint SignalAndWait(IntPtr hObjectToWaitOn, uint dwMilliseconds)
        {
            return kernel32.SignalObjectAndWait(
                stdHandle, hObjectToWaitOn, dwMilliseconds, false);
        }
    }

    public struct SafeTimerHandle
    {
        public UIntPtr stdHandle;
        public SafeTimerHandle(UIntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeTimerHandle(uint stdHandle)
        {
            this.stdHandle = new UIntPtr(stdHandle);
        }
        public uint Wait(
            WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                new IntPtr((int)stdHandle), flags);
        }

        public bool Kill()
        {
            return user32.KillTimer(
                new SafeWindowHandle((int)stdHandle),
                UIntPtr.Zero);
        }
        public bool Kill(
            SafeWindowHandle hWnd,
            UIntPtr uIDEvent)
        {
            return user32.KillTimer(
                hWnd, uIDEvent);
        }
    }
    public struct SafeThreadpoolTimer
    {
        public IntPtr stdHandle;
        public SafeThreadpoolTimer(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpoolTimer(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }
        public void WaitForCallback(bool cancalPendingCallback)
        {
            kernel32.WaitForThreadpoolTimerCallbacks(
                this, cancalPendingCallback);
        }
        public void Set(uint dueTime, uint period)
        {
            var li = LargeInteger.GetLargeInteger(-(dueTime * 10 * 1000 * 1000));
            var pftDueTime = new Filetime { dwLowDateTime = li.U_low, dwHighDateTime = li.U_high };
            kernel32.SetThreadpoolTimer(this, ref pftDueTime, period, 0);
        }
        public void Release()
        {
            kernel32.CloseThreadpoolTimer(this);
        }
        public bool IsSet
        {
            get { return kernel32.IsThreadpoolTimerSet(this); }
        }
    }
    public struct SafeTimerQueueHandle
    {
        public IntPtr stdHandle;
        public SafeTimerQueueHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeTimerQueueHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }
        public bool Delete()
        {
            return kernel32.DeleteTimerQueue(this);
        }
        public bool Change(uint dueTime, uint period)
        {
            return kernel32.ChangeTimerQueueTimer(
                new SafeTimerQueueHandle(0),
                this, dueTime, period);
        }
        public bool Release()
        {
            return kernel32.DeleteTimerQueue(this);
        }
    }
    public struct SafeWaitableTimerHandle
    {
        public IntPtr stdHandle;
        public SafeWaitableTimerHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeWaitableTimerHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }
        public bool Set(Int64 pDueTime, Int32 lPeriod)
        {
            return kernel32.SetWaitableTimer(
                this, ref pDueTime, lPeriod, IntPtr.Zero, IntPtr.Zero, true);
        }
        public bool Cancel()
        {
            return kernel32.CancelWaitableTimer(this);
        }
    }

    public struct SafeThreadpool
    {
        public IntPtr stdHandle;
        public SafeThreadpool(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpool(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Close()
        {
            kernel32.CloseThreadpool(this);
        }
        public uint MinimumThread
        {
            set { kernel32.SetThreadpoolThreadMinimum(this, value); }
        }
        public uint MaximumThread
        {
            set { kernel32.SetThreadpoolThreadMaximum(this, value); }
        }
    }
    public struct SafeThreadpoolIo
    {
        public IntPtr stdHandle;
        public SafeThreadpoolIo(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpoolIo(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Start()
        {
            kernel32.StartThreadpoolIo(this);
        }
        public void Cancel()
        {
            kernel32.CancelThreadpoolIo(this);
        }
        public void Release()
        {
            kernel32.CloseThreadpoolIo(this);
        }
        public void WaitForCallback(bool cancalPendingCallback)
        {
            kernel32.WaitForThreadpoolIoCallbacks(
                this, cancalPendingCallback);
        }
    }
    public struct SafeThreadpoolWork
    {
        public IntPtr stdHandle;
        public SafeThreadpoolWork(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpoolWork(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void WaitForCallback(bool cancalPendingCallback)
        {
            kernel32.WaitForThreadpoolWorkCallbacks(
                this, cancalPendingCallback);
        }
        public void Submit()
        {
            kernel32.SubmitThreadpoolWork(this);
        }
        public void Release()
        {
            kernel32.CloseThreadpoolWork(this);
        }
        public static void TrySubmitThreadpoolCallback(
            SimpleCallback pfns)
        {
            kernel32.TrySubmitThreadpoolCallback(
                pfns, IntPtr.Zero,
                new SafeThreadpoolEnvironment());
        }
    }
    public struct SafeThreadpoolWait
    {
        public IntPtr stdHandle;
        public SafeThreadpoolWait(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpoolWait(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Set(IntPtr h)
        {
            kernel32.SetThreadpoolWait(this, h, IntPtr.Zero);
        }
        public unsafe void Set(IntPtr h, Filetime pftTimeout)
        {
            kernel32.SetThreadpoolWait(this, h, (IntPtr)(&pftTimeout));
        }
        public void WaitForCallback(bool cancalPendingCallback)
        {
            kernel32.WaitForThreadpoolWaitCallbacks(
                this, cancalPendingCallback);
        }
        public void Release()
        {
            kernel32.CloseThreadpoolWait(this);
        }
    }
    public struct SafeThreadpoolEnvironment
    {
        public IntPtr stdHandle;

        public unsafe void Initialize()
        {
            var dwBytes = (uint)Marshal.SizeOf(typeof(CallbackEnvirment));
            stdHandle = kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed, dwBytes);
            kernel32.ZeroMemory(stdHandle, dwBytes);

            var callbackEnviron = (CallbackEnvirment*)stdHandle;

            callbackEnviron->Version = 3;
            callbackEnviron->Pool = new SafeThreadpool(0);
            callbackEnviron->CleanupGroup = new SafeThreadpoolCleanUpGroup(0);
            callbackEnviron->CleanupGroupCancelCallback = IntPtr.Zero;
            callbackEnviron->RaceDll = IntPtr.Zero;
            callbackEnviron->ActivationContext = IntPtr.Zero;
            callbackEnviron->FinalizationCallback = IntPtr.Zero;

            callbackEnviron->Flags = 0;
            //CallbackEnviron->u.Flags = 0;

            callbackEnviron->CallbackPriority = TpCallbackPriority.Normal;
            callbackEnviron->Size = dwBytes;
        }
        public unsafe void SetThreadpoolCallbackRunsLong()
        {
            // Indicates that callbacks associated with this callback environment
            // may not return quickly.

            var callbackEnviron = (CallbackEnvirment*)stdHandle;
            //CallbackEnviron->u.s.LongFunction = 1;
            callbackEnviron->Flags = 1;
        }

        public unsafe SafeThreadpool Pool
        {
            set
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                callbackEnviron->Pool = value;
            }
            get
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                return callbackEnviron->Pool;
            }
        }
        public unsafe SafeThreadpoolCleanUpGroup CleanUpGroup
        {
            get 
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                return callbackEnviron->CleanupGroup;
            }
            set
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                callbackEnviron->CleanupGroup = value;
            }
        }
        public unsafe CleanupGroupCancelCallback CleanupGroupCancelCallback
        {
            get
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                return (CleanupGroupCancelCallback)Marshal.GetDelegateForFunctionPointer(
                    callbackEnviron->CleanupGroupCancelCallback,
                    typeof(CleanupGroupCancelCallback));
            }
            set
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                callbackEnviron->CleanupGroupCancelCallback = (value == null) ?
                IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(value);
            }
        }
        public unsafe IntPtr Dll
        {
            get 
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                return callbackEnviron->RaceDll;
            }
            set
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                callbackEnviron->RaceDll = value;
            }
        }
        public unsafe TpCallbackPriority Priority
        {
            get
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                return callbackEnviron->CallbackPriority;
            }
            set
            {
                var callbackEnviron = (CallbackEnvirment*)stdHandle;
                callbackEnviron->CallbackPriority = value;
            }
        }

        public static SafeThreadpoolEnvironment Zero
        {
            get { return new SafeThreadpoolEnvironment(); }
        }

        public SafeThreadpoolTimer CreateTimer(TimerCallback pfnti, IntPtr pv)
        {
            return kernel32.CreateThreadpoolTimer(pfnti, pv, this);
        }

        public SafeThreadpoolWork CreateWork(WorkCallback pfnwk, IntPtr pv)
        {
            return kernel32.CreateThreadpoolWork(pfnwk, pv, this);
        }

        public SafeThreadpoolWait CreateWait(WaitCallback pfnwa, IntPtr pv)
        {
            return kernel32.CreateThreadpoolWait(pfnwa, pv, this);
        }

        public SafeThreadpoolIo CreateIO(SafeFileHandle fl,IoCompletionCallback pfnio,IntPtr pv)
        {
            return kernel32.CreateThreadpoolIo(fl, pfnio, pv, this);
        }
    }
    public struct SafeThreadpoolCleanUpGroup
    {
        public IntPtr stdHandle;
        public SafeThreadpoolCleanUpGroup(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpoolCleanUpGroup(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Close()
        {
            kernel32.CloseThreadpoolCleanupGroup(this);
        }
        public void WaitAndRelease(bool cancelPendingCallbacks = false)
        {
            kernel32.CloseThreadpoolCleanupGroupMembers(this, cancelPendingCallbacks, IntPtr.Zero);
        }
    }
    public struct SafeThreadpoolCallbackInstance
    {
        public IntPtr stdHandle;
        public SafeThreadpoolCallbackInstance(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeThreadpoolCallbackInstance(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }

        public bool CallbackMayRunLong
        {
            get { return kernel32.CallbackMayRunLong(this); }
        }
        public void DisassociateCurrentThreadFromCallback()
        {
            kernel32.DisassociateCurrentThreadFromCallback(this);
        }
        public void SetEventWhenCallbackReturns(SafeEventHandle evt)
        {
            kernel32.SetEventWhenCallbackReturns(this, evt);
        }
        public void LeaveCriticalSectionWhenCallbackReturns(SafeCriticalsection pcs)
        {
            kernel32.LeaveCriticalSectionWhenCallbackReturns(this, pcs);
        }
        public void FreeLibraryWhenCallbackReturns(IntPtr mod)
        {
            kernel32.FreeLibraryWhenCallbackReturns(this, mod);
        }
        public void ReleaseSemaphoreWhenCallbackReturns(SafeSemaphoreHandle sem, uint crel)
        {
            kernel32.ReleaseSemaphoreWhenCallbackReturns(this, sem, crel);
        }
        public void ReleaseMutexWhenCallbackReturns(SafeMutexHandle mut)
        {
            kernel32.ReleaseMutexWhenCallbackReturns(this, mut);
        }  
    }

    public struct SafeFileHandle
    {
        public IntPtr stdHandle;

        public SafeFileHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeFileHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.CloseHandle(this.stdHandle);
        }

        public uint Read(uint bytesToRead, out byte[] lpBuffer)
        {
            uint lpNumberOfBytesRead;
            lpBuffer = new byte[bytesToRead];
            kernel32.ReadFile(this, lpBuffer, bytesToRead, out lpNumberOfBytesRead, IntPtr.Zero);
            Array.Resize(ref lpBuffer, (int)lpNumberOfBytesRead);
            return lpNumberOfBytesRead;
        }
        public uint Write(byte[] lpBuffer)
        {
            uint lpNumberOfBytesWritten;
            kernel32.WriteFile(this, lpBuffer, (uint)lpBuffer.Length,out lpNumberOfBytesWritten, IntPtr.Zero);
            return lpNumberOfBytesWritten;
        }
        public bool Flush()
        {
            return kernel32.FlushFileBuffers(this);
        }

        public bool Lock(uint stareAddress, uint sizeToLock)
        {
            var bAddress = ByteOrder.GetByteOrder(stareAddress);
            var bSize = ByteOrder.GetByteOrder(sizeToLock);
            return kernel32.LockFile(this, bAddress.u_low, bAddress.u_high, bSize.u_low, bSize.u_high);
        }
        public bool Unlock(uint stareAddress, uint sizeToLock)
        {
            var bAddress = ByteOrder.GetByteOrder(stareAddress);
            var bSize = ByteOrder.GetByteOrder(sizeToLock);
            return kernel32.UnlockFile(this, bAddress.u_low, bAddress.u_high, bSize.u_low, bSize.u_high);
        }

        public unsafe bool SetFilePointer(EMoveMethod moveMethod, int distanceToMove)
        {
            return kernel32.SetFilePointer(
                this, distanceToMove, (int*)0, moveMethod) != (unchecked((uint)-1));
        }
        public bool SetEndOfFile()
        {
            return kernel32.SetEndOfFile(this);
        }

        public bool GetFileInformation(out BY_HANDLE_FILE_INFORMATION lpFileInformation)
        {
            return kernel32.GetFileInformationByHandle(this, out lpFileInformation);
        }
        private unsafe bool GetFileInformationEx(FILE_INFO_BY_HANDLE_CLASS fileInformationClass, FileInfo* fileInformation)
        {
            return kernel32.GetFileInformationByHandleEx(this, fileInformationClass, (IntPtr)fileInformation, FileInfo.Size);
        }
        private unsafe bool SetFileInformationEx(FILE_INFO_BY_HANDLE_CLASS fileInformationClass, FileInfo* fileInformation)
        {
            return kernel32.SetFileInformationByHandle(this, fileInformationClass, (IntPtr)fileInformation, FileInfo.Size);
        }

        public bool CancelIo()
        {
            return kernel32.CancelIo(this);
        }
        public bool SetCompletionCallback(FileCompletionDelegate function)
        {
            // handle must be with FileFlag.Overlapped Flag
            return kernel32.BindIoCompletionCallback(this, function, 0);
        }
        public bool SetCompletionNotificationModes(byte mode)
        {
            return kernel32.SetFileCompletionNotificationModes(this, mode);
        }

        public string Name
        {
            get
            {
                var ret = string.Empty;

                //var fileInformation = (FileInfo*)kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed,FileInfo.Size);
                //kernel32.ZeroMemory((IntPtr)fileInformation, FileInfo.Size);

                //if (GetFileInformationEx(FILE_INFO_BY_HANDLE_CLASS.FileNameInfo, fileInformation))
                //    ret = fileInformation->FileNameInfo.FileName;
                //kernel32.GlobalFree((IntPtr)fileInformation);

                var lpszFilePath = new StringBuilder(256);
                kernel32.GetFinalPathNameByHandle(
                    this, lpszFilePath, 256, FinalPathFlags.VOLUME_NAME_DOS);
                ret = lpszFilePath.ToString();

                return ret;
            }
        }

        public unsafe uint Size
        {
            get
            {
                uint ret = 0;

                ret = kernel32.SetFilePointer(
                    this, 0, (int*)0, EMoveMethod.End);

                kernel32.SetFilePointer(
                    this, 0, (int*)0, EMoveMethod.Begin);

                //var fileInformation = (FileInfo*)kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed, FileInfo.Size);
                //kernel32.ZeroMemory((IntPtr)fileInformation, FileInfo.Size);

                //if (GetFileInformationEx(FILE_INFO_BY_HANDLE_CLASS.FileStandardInfo, fileInformation))
                //    ret = fileInformation->FileStandardInfo.AllocationSize.LowPart;
                //kernel32.GlobalFree((IntPtr)fileInformation);

                return ret;
            }
        }
    }
    public struct SafeFindFileHandle
    {
        public IntPtr stdHandle;

        public SafeFindFileHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeFindFileHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.FindClose(this.stdHandle);
        }
    }
    public struct SafeFindFileNameHandle
    {
        public IntPtr stdHandle;

        public SafeFindFileNameHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeFindFileNameHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.FindClose(this.stdHandle);
        }
    }
    public struct SafeFindChangeNotificationHandle
    {
        public IntPtr stdHandle;

        public SafeFindChangeNotificationHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeFindChangeNotificationHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.FindCloseChangeNotification(this);
        }

        public uint Wait()
        {
            return kernel32.WaitForSingleObject(stdHandle, WaitForSingleObjectFlags.Infinite);
        }
    }
    public struct SafeFindVolumeHandle
    {
        public IntPtr stdHandle;

        public SafeFindVolumeHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeFindVolumeHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.FindVolumeClose(this);
        }
    }
    public struct SafeFindVolumeMountPointeHandle
    {
        public IntPtr stdHandle;

        public SafeFindVolumeMountPointeHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeFindVolumeMountPointeHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.FindVolumeMountPointClose(this);
        }
    }

    public struct SafeWaitHandle
    {
        public IntPtr stdHandle;
        public SafeWaitHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeWaitHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void UnRegister()
        {
            kernel32.UnregisterWaitEx(this, new SafeEventHandle(0));
        }
        public void UnRegister(SafeEventHandle completionEvent)
        {
            kernel32.UnregisterWaitEx(this, completionEvent);
        }
    }
    public struct SafeRegistryHandle
    {
        public UIntPtr stdHandle;

        public SafeRegistryHandle(UIntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeRegistryHandle(uint stdHandle)
        {
            this.stdHandle = new UIntPtr(stdHandle);
        }
        public void Flush()
        {
            advapi32.RegFlushKey(this);
        }
        public bool Release()
        {
            return advapi32.RegCloseKey(this) == 1;
        }

        public static SafeRegistryHandle HKEY_CLASSES_ROOT
        {
            get { return new SafeRegistryHandle(0x80000000); }
        }
        public static SafeRegistryHandle HKEY_CURRENT_USER
        {
            get { return new SafeRegistryHandle(0x80000001); }
        }
        public static SafeRegistryHandle HKEY_LOCAL_MACHINE
        {
            get { return new SafeRegistryHandle(0x80000002); }
        }
        public static SafeRegistryHandle HKEY_USERS
        {
            get { return new SafeRegistryHandle(0x80000003); }
        }
        public static SafeRegistryHandle HKEY_PERFORMANCE_DATA
        {
            get { return new SafeRegistryHandle(0x80000004); }
        }
        public static SafeRegistryHandle HKEY_PERFORMANCE_TEXT
        {
            get { return new SafeRegistryHandle(0x80000050); }
        }
        public static SafeRegistryHandle HKEY_PERFORMANCE_NLSTEXT
        {
            get { return new SafeRegistryHandle(0x80000060); }
        }
        public static SafeRegistryHandle HKEY_CURRENT_CONFIG
        {
            get { return new SafeRegistryHandle(0x80000005); }
        }
        public static SafeRegistryHandle HKEY_DYN_DATA
        {
            get { return new SafeRegistryHandle(0x80000006); }
        }
        public static SafeRegistryHandle HKEY_CURRENT_USER_LOCAL_SETTINGS
        {
            get { return new SafeRegistryHandle(0x80000007); }
        }
    }
    public struct SafeConsoleHandle
    {
        public IntPtr stdHandle;

        public SafeConsoleHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeConsoleHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.FreeConsole();
        }

        /// <summary>
        /// only work with StdIn ....
        /// </summary>
        public uint Wait(WaitForSingleObjectFlags flags)
        {
            return kernel32.WaitForSingleObject(
                stdHandle, flags);
        }

        public uint Read(out byte[] lpBuffer, uint nNumberOfBytesToRead)
        {
            lpBuffer = new byte[nNumberOfBytesToRead];
            kernel32.ReadFile(
                new SafeFileHandle(stdHandle),
                lpBuffer,
                nNumberOfBytesToRead,
                out nNumberOfBytesToRead,
                IntPtr.Zero);

            Array.Resize(ref lpBuffer, (int)nNumberOfBytesToRead);
            return nNumberOfBytesToRead;
        }
        public uint Write(byte[] lpBuffer, uint nNumberOfBytesToWrite)
        {
            uint lpNumberOfBytesWritten;
            kernel32.WriteFile(
                new SafeFileHandle(stdHandle),
                lpBuffer,
                nNumberOfBytesToWrite,
                out lpNumberOfBytesWritten,
                IntPtr.Zero);

            return lpNumberOfBytesWritten;
        }
    }
    public struct SafeServiceHandle
    {
        public IntPtr stdHandle;

        public SafeServiceHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeServiceHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }

        public bool Delete()
        {
            return advapi32.DeleteService(this);
        }
        public bool Start(uint numServiceArgs, string[] serviceArgVectors)
        {
            return advapi32.StartService(this, numServiceArgs, serviceArgVectors);
        }
        public bool Set(
            ServiceType serviceType,
            StartType startType,
            ErrorControl errorControl,
            string binaryPathName,
            string loadOrderGroup,
            out uint tagId,
            string dependencies,
            string serviceStartName,
            string password,
            string sisplayName)
        {
            return advapi32.ChangeServiceConfig(
                this, serviceType, startType, errorControl, binaryPathName, loadOrderGroup, out tagId, dependencies, serviceStartName, password, sisplayName);
        }
        public bool Control(ServiceControl controlCode, out SERVICE_STATUS lpServiceStatus)
        {
            return advapi32.ControlService(
                this, controlCode, out lpServiceStatus);
        }

        public unsafe ENUM_SERVICE_STATUS[] Dependencies
        {
            get
            {
                uint pcbBytesNeeded;
                uint lpServicesReturned;
                uint lpResumeHandle = 0;

                var lpServices = (ENUM_SERVICE_STATUS*)0;
                advapi32.EnumDependentServices(
                    this, ServiceState.ALL, lpServices, 0, out pcbBytesNeeded, out lpServicesReturned);

                lpServices = (ENUM_SERVICE_STATUS*)kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed, pcbBytesNeeded);
                advapi32.EnumDependentServices(
                    this, ServiceState.ALL, lpServices, pcbBytesNeeded, out pcbBytesNeeded, out lpServicesReturned);

                ENUM_SERVICE_STATUS[] svc = null;
                if (lpServicesReturned > 0)
                {
                    svc = new ENUM_SERVICE_STATUS[lpServicesReturned];
                    for (var i = 0; i < lpServicesReturned; i++)
                    {
                        svc[i] = lpServices[i];
                    }
                }
                else
                {
                    kernel32.GlobalFree((IntPtr) lpServices);
                }

                return svc;
            }
        }
        public unsafe SERVICE_STATUS_PROCESS Status
        {
            get
            {
                uint pcbBytesNeeded;
                SERVICE_STATUS_PROCESS lpBuffer;
                advapi32.QueryServiceStatusEx(
                    this, 0, &lpBuffer, (uint) sizeof (SERVICE_STATUS_PROCESS), out pcbBytesNeeded);
                return lpBuffer;
            }
        }
        public unsafe QUERY_SERVICE_CONFIG Config
        {
            get
            {
                uint pcbBytesNeeded;
                QUERY_SERVICE_CONFIG lpServiceConfig;
                advapi32.QueryServiceConfig(
                    this, &lpServiceConfig, (uint) sizeof (QUERY_SERVICE_CONFIG), out pcbBytesNeeded);
                return lpServiceConfig;
            }
        }
    }
    public struct SafeServiceManagerHandle
    {
        public IntPtr stdHandle;

        public SafeServiceManagerHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeServiceManagerHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return advapi32.CloseServiceHandle(this);
        }

        public void Initialize()
        {
            var hService = advapi32.OpenSCManager(
                null, null, SCM_ACCESS.GENERIC_ALL);
            stdHandle = hService.stdHandle;
        }
        public void Initialize(SCM_ACCESS desiredAccess)
        {
            var hService = advapi32.OpenSCManager(
                null, null, desiredAccess);
            stdHandle = hService.stdHandle;
        }

        public SafeServiceHandle OpenService(String lpServiceName, SCM_ACCESS dwDesiredAccess)
        {
            return advapi32.OpenService(this, lpServiceName, dwDesiredAccess);
        }
        public SafeServiceHandle CreateService(
            String lpServiceName,
            String lpDisplayName,
            SCM_ACCESS dwDesiredAccess,
            ServiceType dwServiceType,
            StartType dwStartType,
            ErrorControl dwErrorControl,
            String lpBinaryPathName,
            String lpLoadOrderGroup,
            out UInt32 lpdwTagId,
            String lpDependencies,
            String lpServiceStartName,
            String lpPassword)
        {
            return advapi32.CreateService(
                this, lpServiceName, lpDisplayName,
                dwDesiredAccess, dwServiceType, dwStartType, dwErrorControl,
                lpBinaryPathName, lpLoadOrderGroup, out lpdwTagId,
                lpDependencies, lpServiceStartName, lpPassword);
        }

        public string KeyName
        {
            get
            {
                uint lpcchBuffer = 256;
                var lpDisplayName = new StringBuilder(256);
                if (!advapi32.GetServiceKeyName(
                    this, null,
                    lpDisplayName, ref lpcchBuffer))
                    lpDisplayName.EnsureCapacity((int)lpcchBuffer);

                advapi32.GetServiceKeyName(
                    this, null,
                    lpDisplayName, ref lpcchBuffer);
                return lpDisplayName.ToString();
            }
        }

        public string DisplayName
        {
            get
            {
                uint lpcchBuffer = 256;
                var lpDisplayName = new StringBuilder(256);
                if (!advapi32.GetServiceDisplayName(
                    this, null,
                    lpDisplayName, ref lpcchBuffer))
                    lpDisplayName.EnsureCapacity((int)lpcchBuffer);

                advapi32.GetServiceDisplayName(
                    this, null,
                    lpDisplayName, ref lpcchBuffer);
                return lpDisplayName.ToString();
            }
        }

        public unsafe ENUM_SERVICE_STATUS_PROCESS[] Services
        {
            get
            {
                uint pcbBytesNeeded;
                uint lpServicesReturned;
                uint lpResumeHandle = 0;

                PrivilegesHelper.Take(
                    SafeProcessHandle.CurrentProcess,
                    true,
                    PrivilegesHelper.Types.SE_ALL);
;
                var lpServices = (ENUM_SERVICE_STATUS_PROCESS*)0;
                advapi32.EnumServicesStatusEx(
                    this, 0,
                    ServiceType.All,
                    ServiceState.ALL,
                    lpServices, 0,
                    out pcbBytesNeeded,
                    out lpServicesReturned,
                    ref lpResumeHandle,
                    null);

                lpServices = (ENUM_SERVICE_STATUS_PROCESS*)kernel32.GlobalAlloc(
                    GlobalMemoryFlags.Fixed,
                    pcbBytesNeeded);
                advapi32.EnumServicesStatusEx(
                    this, 0,
                    ServiceType.All,
                    ServiceState.ALL,
                    lpServices, pcbBytesNeeded,
                    out pcbBytesNeeded,
                    out lpServicesReturned,
                    ref lpResumeHandle,
                    null);

                ENUM_SERVICE_STATUS_PROCESS[] svc = null;
                if (lpServicesReturned > 0)
                {
                    svc = new ENUM_SERVICE_STATUS_PROCESS[lpServicesReturned];
                    for (var i = 0; i < lpServicesReturned; i++)
                    {
                        svc[i] = lpServices[i];
                    }
                }
                else
                {
                    kernel32.GlobalFree((IntPtr)lpServices);
                }

                return svc;
            }
        }
    }
    public struct SafeTokenHandle
    {
        public IntPtr stdHandle;
        public SafeTokenHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeTokenHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return kernel32.CloseHandle(stdHandle);
        }
        public static SafeTokenHandle FromProcId(uint procId)
        {
            SafeTokenHandle hToken;
            var processHandle = kernel32.OpenProcess(
                ProcessAccessFlags.All, true, procId);
            advapi32.OpenProcessToken(
                processHandle, TokenAccess.ALL_ACCESS, out hToken);
            
            if (hToken.stdHandle == IntPtr.Zero)
                throw new Win32Exception(
                    Marshal.GetLastWin32Error());

            return hToken;
        }
        public static SafeTokenHandle Current
        {
            get
            {
                try { return CurrentThread; }
                catch { return CurrentProcess; }
            }
        }
        public static SafeTokenHandle CurrentProcess
        {
            get
            {
                SafeTokenHandle tokenHandle;
                if (!advapi32.OpenProcessToken(
                    SafeProcessHandle.CurrentProcess,
                    TokenAccess.ALL_ACCESS,
                    out tokenHandle))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());

                return tokenHandle;
            }
        }
        public static SafeTokenHandle CurrentThread
        {
            get
            {
                SafeTokenHandle tokenHandle;
                if (!advapi32.OpenThreadToken(
                    SafeThreadHandle.CurrentThread,
                    TokenAccess.ALL_ACCESS, 
                    true, 
                    out tokenHandle))
                    throw new Win32Exception(
                        Marshal.GetLastWin32Error());

                return tokenHandle;
            }
        }

        public unsafe SafeSidHandle Sid
        {
            get
            {
                uint returnLength;
                var hToken = Current;
                var tokenInformation = (TOKEN_INFORMATION*) 0;

                advapi32.GetTokenInformation(
                    hToken, 
                    TOKEN_INFORMATION_CLASS.TokenLogonSid, 
                    tokenInformation, 0, 
                    out returnLength);

                tokenInformation = (TOKEN_INFORMATION*) msvcrt.malloc(returnLength);
                advapi32.GetTokenInformation(
                    hToken,
                    TOKEN_INFORMATION_CLASS.TokenLogonSid,
                    tokenInformation, returnLength,
                    out returnLength);

                return tokenInformation->TokenLogonSid.First.Sid;
            }
        }
    }
    public struct SafeWindowHandle
    {
        public IntPtr stdHandle;
        public SafeWindowHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeWindowHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public static SafeWindowHandle Zero
        {
            get { return new SafeWindowHandle(0); }
        }

        public void Send(WindowMessege msg, IntPtr wParam, IntPtr lParam)
        {
            user32.SendMessage(this, msg, wParam, lParam);
        }

        public unsafe bool Update(Color colour, byte opacity)
        {
            if (!IsLayered)
            {
                IsLayered = true;
                if (!IsLayered)
                    return false;
            }

            // Misc
            var rect = this.Rect;

            // Dst
            var pptDst = new POINT(rect.X, rect.Y);
            var psize = new SIZE(){cH = rect.Height, cW = rect.Width};

            // EOF
            var pblend = new BLENDFUNCTION()
            {
                BlendOp = 0x00,
                BlendFlags = 0x00,
                SourceConstantAlpha = opacity,
                AlphaFormat = 0x01
            };

            return user32.UpdateLayeredWindow(
                this,
                new SafeDCHandle(0), &pptDst, &psize,
                new SafeDCHandle(0), (POINT*)0,
                (uint) colour.ToArgb(), &pblend,
                ULW.Colour | ULW.Opicity);
        }

        public unsafe bool Update(Bitmap bitmap)
        {
            if (!IsLayered)
            {
                IsLayered = true;
                if (!IsLayered)
                    return false;
            }

            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            // Dst :: Window Handle
            var hdcDst = this.DeviceContext;
            var pptDst = new POINT(Rect.X, Rect.Y);
            var psize = new SIZE() { cH = bitmap.Height, cW = bitmap.Width };

            // Src :: Image
            var hdcSrc = hdcDst.CreateCompatibleDC();
            var hBitmap = new SafeBitmapHandle(
                bitmap.GetHbitmap(Color.FromArgb(0)));
            hdcSrc.Select(hBitmap.stdHandle);
            var pptSrc = new POINT(0, 0);

            // EOF
            var pblend = new BLENDFUNCTION()
            {
                BlendOp = 0x00,
                BlendFlags = 0x00,
                SourceConstantAlpha = 0xff,
                AlphaFormat = 0x01
            };

                
            var dwRet = user32.UpdateLayeredWindow(
                this,
                hdcDst, &pptDst, &psize,
                hdcSrc, &pptSrc,
                0x0, &pblend,
                ULW.Opicity);

            hdcDst.Release(     // Source DC
                new SafeWindowHandle(0));
            hdcSrc.Delete();    // Compatible DC
            hBitmap.Delete();   // Bitmap Handle
            return dwRet;
        }

        public bool Animate(AnimateWindowFlags flags, uint time)
        {
            return user32.AnimateWindow(
                this, time, flags);
        }

        public void InValidate()
        {
            var rect = Rect;
            user32.UpdateWindow(this);
            user32.InvalidateRect(this, ref rect, true);
            user32.RedrawWindow(this, ref rect, IntPtr.Zero,
                RedrawWindowFlags.Invalidate |
                RedrawWindowFlags.Erase |
                RedrawWindowFlags.EraseNow |
                RedrawWindowFlags.Frame |
                RedrawWindowFlags.NoFrame);
        }

        public bool Activate()
        {
            return user32.SetForegroundWindow(this);
        }

        public bool BringWindowToTop()
        {
            return user32.BringWindowToTop(this);
        }

        public bool Show(ShowWindowCommand nCmdShow)
        {
            return user32.ShowWindow(this, nCmdShow);
        }

        public bool Close()
        {
            return user32.CloseWindow(this);
        }

        public bool Destroy()
        {
            return user32.DestroyWindow(this);
        }

        public void Dispose()
        {
            Send(WindowMessege.CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Owner is the Window* responsible for a control or dialog (for example, 
        /// responsible for creating/destroying the window).
        /// </summary>
        public SafeWindowHandle Owner
        {
            get
            {
                // To obtain a window's owner window,
                // instead of using GetParent, 
                // use GetWindow with the GW_OWNER flag.

                return user32.GetWindow(this, GetWindow_Cmd.GW_OWNER);
            }
        }

        /// <summary>
        /// Parent is the next-senior window* to a control or dialog in the window chain, 
        /// but isn't actually responsible for it (doesn't necessarily care about its lifecycle, etc).
        /// A window's parent can also be its owner.
        /// </summary>
        public SafeWindowHandle Parent
        {
            get
            {
                // To obtain the parent window and not the owner,
                // instead of using GetParent,
                // use GetAncestor with the GA_PARENT flag.

                return user32.GetAncestor(this, AncestorFlags.Parent);
            }
            set { user32.SetParent(Parent, value); }
        }

        public bool Responding
        {
            get { return !user32.IsHungAppWindow(this); }
        }

        public bool Visible
        {
            get { return user32.IsWindowVisible(this); }
        }

        public bool Minimized
        {
            get { return user32.IsIconic(this); }
        }

        public bool Maximized
        {
            get { return user32.IsZoomed(this); }
        }

        public uint ProcessId
        {
            get
            {
                uint lpdwProcessId;
                user32.GetWindowThreadProcessId(this, out lpdwProcessId);
                return lpdwProcessId;
            }
        }
        public uint ThreadId
        {
            get
            {
                uint lpdwProcessId;
                return user32.GetWindowThreadProcessId(this, out lpdwProcessId);
            }
        }

        public SafeProcessHandle Process
        {
            get { return kernel32.OpenProcess(ProcessAccessFlags.All, false, ProcessId); }
        }

        public SafeWindowHandle[] Children
        {
            get
            {
                var arr = new List<SafeWindowHandle>();
                user32.EnumChildWindows(
                    this,
                    delegate(SafeWindowHandle hwnd, IntPtr param) { arr.Add(hwnd); return true; }, 
                    IntPtr.Zero);
                return arr.ToArray();
            }
        }

        public RECT Rect
        {
            get
            {
                RECT rect;
                user32.GetWindowRect(this, out rect);
                return rect;
            }
            set
            {
                user32.MoveWindow(
                    this, value.X, value.Y, value.Width, value.Height, true);

                //user32.SetWindowPos(
                //    this, 0, value.X, value.Y, value.Width, value.Height, 0);
            }
        }

        public WINDOWPLACEMENT Placment
        {
            get
            {
                var lpwndpl = WINDOWPLACEMENT.Default;
                user32.GetWindowPlacement(this, ref lpwndpl);
                return lpwndpl;
            }
            set { user32.SetWindowPlacement(this, ref value); }
        }

        public SafeDCHandle DeviceContext
        {
            get { return user32.GetDC(this); }
        }

        public WindowProc WindowProc
        {
            get
            {
                return (WindowProc) Marshal.GetDelegateForFunctionPointer(
                    (IntPtr) user32.GetWindowLong(this, WindowStyleFlags.GWL_WNDPROC),
                    typeof (WindowProc));
            }
        }

        public WindowStyle Style
        {
            get { return (WindowStyle)user32.GetWindowLong(this, WindowStyleFlags.GWL_STYLE); }
            set { user32.SetWindowLong(this, WindowStyleFlags.GWL_STYLE, value); }
        }

        public WindowStyle StyleEx
        {
            get { return (WindowStyle)user32.GetWindowLong(this, WindowStyleFlags.GWL_EXSTYLE); }
            set { user32.SetWindowLong(this, WindowStyleFlags.GWL_EXSTYLE, value); }
        }

        public bool Input
        {
            get { return user32.IsWindowEnabled(this); }
            set { user32.EnableWindow(this, value); }
        }

        public bool Valid
        {
            get { return user32.IsWindow(this); }
        }

        public string Type
        {
            get
            {
                var pszType = new StringBuilder(1024);
                user32.RealGetWindowClass(this, pszType, 1024 + 1);
                return pszType.ToString();
            }
        }

        public string Class
        {
            get
            {
                var lpClassName = new StringBuilder(1024);
                user32.GetClassName(this, lpClassName, 1024 + 1);
                return lpClassName.ToString();
            }
        }

        public string Text
        {
            get
            {
                var lpString = new StringBuilder(1024);
                user32.GetWindowText(this, lpString, 1024 + 1);
                return lpString.ToString();
            }
            set { user32.SetWindowText(this, value); }
        }

        public Color Colour
        {
            get
            {
                byte bAlpha;
                uint crKey, dwFlags;
                user32.GetLayeredWindowAttributes(
                    this, out crKey, out bAlpha, out dwFlags);

                return !IsLayered || (dwFlags & 0x1) == 0x1 ? 
                    Color.FromArgb((int)crKey) : 
                    default(Color);
            }
            set
            {
                if (!IsLayered)
                    IsLayered = true;

                if (IsLayered)
                {
                    user32.SetLayeredWindowAttributes(
                        this, (uint)value.ToArgb(), 0, 0x1);
                }
            }
        }

        public int Opicity
        {
            get
            {
                byte bAlpha;
                uint crKey, dwFlags;
                user32.GetLayeredWindowAttributes(
                    this, out crKey, out bAlpha, out dwFlags);

                return !IsLayered || (dwFlags & 0x2) == 0x2 ? 
                    bAlpha : -1;
            }
            set
            {
                if (!IsLayered) 
                    IsLayered = true;

                if (IsLayered && 
                    (value >= 0 || value <= 255))
                {
                    user32.SetLayeredWindowAttributes(
                        this, 0, (byte)value, 0x2);
                }
            }
        }

        public bool IsLayered
        {
            get
            {
                return (StyleEx & WindowStyle.EX_LAYERED) == 
                    WindowStyle.EX_LAYERED;
            }
            set
            {
                // Begin
                var newStyle = StyleEx;

                // Modify
                if (IsLayered && !value)
                    newStyle &= ~WindowStyle.EX_LAYERED;
                else
                    newStyle |= WindowStyle.EX_LAYERED;

                // End
                StyleEx = newStyle;
            }
        }

        public bool IsTransparent
        {
            get
            {
                return (StyleEx & WindowStyle.EX_TRANSPARENT) ==
                    WindowStyle.EX_TRANSPARENT;
            }
            set
            {
                // Begin
                var newStyle = StyleEx;

                // Modify
                if (IsTransparent && !value)
                    newStyle &= ~WindowStyle.EX_TRANSPARENT;
                else
                    newStyle |= WindowStyle.EX_TRANSPARENT;

                // End
                StyleEx = newStyle;
            }
        }

        public bool IsTopMost
        {
            get
            {
                return (StyleEx & WindowStyle.EX_TOPMOST) ==
                    WindowStyle.EX_TOPMOST;
            }
            set
            {
                // Begin
                var newStyle = StyleEx;

                // Modify
                if (IsTopMost && !value)
                    newStyle &= ~WindowStyle.EX_TOPMOST;
                else
                    newStyle |= WindowStyle.EX_TOPMOST;

                // End
                StyleEx = newStyle;
            }
        }   
    }
    public struct SafeDCHandle
    {
        public IntPtr stdHandle;
        public SafeDCHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeDCHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Cancel()
        {
            gdi32.CancelDC(this);
        }
        public void Delete()
        {
            gdi32.DeleteDC(this);
        }
        public void Release(SafeWindowHandle hWnd)
        {
            gdi32.ReleaseDC(hWnd, this);
        }
        public IntPtr Select(IntPtr hgdiobj)
        {
            return gdi32.SelectObject(this, hgdiobj);
        }
        public SafeDCHandle CreateCompatibleDC()
        {
            return gdi32.CreateCompatibleDC(this);
        }
        public SafeBitmapHandle CreateCompatibleBitmap(int width, int height)
        {
            return gdi32.CreateCompatibleBitmap(this, width, height);
        }
        public int Save()
        {
            return gdi32.SaveDC(this);
        }
        public void Restore(int nSavedDC)
        {
            gdi32.RestoreDC(this, nSavedDC);
        }
        public Graphics Graphics
        {
            get { return Graphics.FromHdc(stdHandle); }
        }

        public static SafeDCHandle Default
        {
            get {return new SafeDCHandle(0);}
        }
    }
    public struct SafeIconHandle
    {
        public IntPtr stdHandle;
        public SafeIconHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeIconHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public bool Release()
        {
            return user32.DestroyIcon(this);
        }
        public Icon hIcon
        {
            get { return Icon.FromHandle(this.stdHandle); }
        }
    }
    public struct SafeRegionHandle
    {
        public IntPtr stdHandle;
        public SafeRegionHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeRegionHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Delete()
        {
            gdi32.DeleteObject(stdHandle);
        }
        public static SafeRegionHandle Create(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRec)
        {
            return gdi32.CreateRectRgn(
                nLeftRect,
                nTopRect,
                nRightRect,
                nBottomRec);
        }
        public Region Region
        {
            get { return Region.FromHrgn(stdHandle); }
        }
    }
    public struct SafeBitmapHandle
    {
        public IntPtr stdHandle;
        public SafeBitmapHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeBitmapHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public void Delete()
        {
            gdi32.DeleteObject(stdHandle);
        }
        public Image Image
        {
            get { return Image.FromHbitmap(this.stdHandle); }
        }
    }
    public struct SafeLevelHandle
    {
        public IntPtr stdHandle;
        public SafeLevelHandle(IntPtr stdHandle)
        {
            this.stdHandle = stdHandle;
        }
        public SafeLevelHandle(int stdHandle)
        {
            this.stdHandle = new IntPtr(stdHandle);
        }
        public static SafeLevelHandle Create(SAFER_LEVELID levelid)
        {
            SafeLevelHandle pLevelHandle;
            advapi32.SaferCreateLevel(
                SAFER_SCOPEID.SAFER_SCOPEID_USER,
                levelid,
                SAFER_LEVEL.SAFER_LEVEL_OPEN,
                out pLevelHandle, IntPtr.Zero);
            return pLevelHandle;
        }

        public SafeTokenHandle TokenHandle
        {
            get
            {
                SafeTokenHandle outAccessToken;
                advapi32.SaferComputeTokenFromLevel(
                    this, new SafeTokenHandle(0), out outAccessToken, 0, IntPtr.Zero);
                return outAccessToken;
            }
        }

        public bool Close()
        {
            return advapi32.SaferCloseLevel(this);
        }
    }
}
