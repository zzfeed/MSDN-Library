
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
using System.Globalization;
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

namespace MSDN.Extension
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ByteOrder
    {
        [FieldOffset(0)]
        private int number;

        [FieldOffset(0)]
        public short low;

        [FieldOffset(2)]
        public short high;

        [FieldOffset(0)]
        private uint u_number;

        [FieldOffset(0)]
        public ushort u_low;

        [FieldOffset(2)]
        public ushort u_high;

        public static ByteOrder GetByteOrder(UInt32 number)
        {
            return new ByteOrder { u_number = number };
        }
        public static ByteOrder GetByteOrder(Int32 number)
        {
            return new ByteOrder { number = number };
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct LargeInteger
    {
        [FieldOffset(0)]
        private long number;

        [FieldOffset(0)]
        private ulong U_number;

        [FieldOffset(0)]
        public int low;

        [FieldOffset(0)]
        public uint U_low;

        [FieldOffset(4)]
        public int high;

        [FieldOffset(4)]
        public uint U_high;

        public static LargeInteger GetLargeInteger(UInt64 number)
        {
            return new LargeInteger { U_number = number };
        }
        public static LargeInteger GetLargeInteger(Int64 number)
        {
            return new LargeInteger { number = number };
        }
    }

    public class Allocator<T> : IDisposable
        where T : struct
    {
        //private GCHandle gc;
        private IntPtr handle;
        private bool over;

        /// <summary>
        /// return T Handle
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                //return gc.AddrOfPinnedObject();
                return handle;
            }
            set
            {
                handle = value;
            }
        }

        /// <summary>
        /// return T as Object
        /// </summary>
        public object ToObject
        {
            get
            {
                return Marshal.PtrToStructure(this.Handle, this.Type);
            }
        }

        /// <summary>
        /// return T as T
        /// </summary>
        public T ToType
        {
            get { return (T)(ToObject); }
        }

        /// <summary>
        /// return T Type
        /// </summary>
        public Type Type
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// return T size
        /// </summary>
        public uint Size
        {
            get { return (uint)Marshal.SizeOf(this.Type); }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="t"></param>
        public Allocator()
        {
            try
            {
                var t = new T();

                //gc = GCHandle.Alloc(t, GCHandleType.Pinned);
                handle = Marshal.AllocHGlobal(Marshal.SizeOf(t));
            }
            catch (Exception)
            {
                throw new System.ComponentModel.Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="t"></param>
        public Allocator(T t)
        {
            try
            {
                //gc = GCHandle.Alloc(t, GCHandleType.Pinned);
                handle = Marshal.AllocHGlobal(Marshal.SizeOf(t));
            }
            catch (Exception)
            {
                throw new System.ComponentModel.Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="t"></param>
        public void ReAllocate(uint Size)
        {
            try
            {
                //gc = GCHandle.Alloc(t, GCHandleType.Pinned);
                handle = Marshal.AllocHGlobal((int)Size);
            }
            catch (Exception)
            {
                throw new System.ComponentModel.Win32Exception(
                    Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (over)
                return;

            over = true;

            //gc.Free();
            Marshal.FreeHGlobal(handle);
        }
    }

    public static class Extension
    {
        public static int AsInt(this uint number)
        {
            return unchecked((int)number);
        }
        public static short Low(this int number)
        {
            return ByteOrder.GetByteOrder(number).low;
        }
        public static ushort Low(this uint number)
        {
            return ByteOrder.GetByteOrder(number).u_low;
        }
        public static short High(this int number)
        {
            return ByteOrder.GetByteOrder(number).high;
        }
        public static ushort High(this uint number)
        {
            return ByteOrder.GetByteOrder(number).u_high;
        }
        public static void Close(this IntPtr ptr)
        {
            kernel32.CloseHandle(ptr);
        }
        public static void Free(this IntPtr ptr)
        {
            kernel32.GlobalFree(ptr);
        }
        public static string ToUnicodeStr(this IntPtr ptr)
        {
            return Marshal.PtrToStringUni(ptr);
        }
        public static string ToAnsiStr(this IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }
        public static string ToUnicodeStr(this IntPtr ptr, int length)
        {
            return length > 0 ?
                Marshal.PtrToStringUni(ptr, length) :
                Marshal.PtrToStringUni(ptr);
        }
        public static string ToUnicodeStr(this IntPtr ptr, uint length)
        {
            return length > 0 ?
                Marshal.PtrToStringUni(ptr, (int)length) :
                Marshal.PtrToStringUni(ptr);
        }
        public static string ToAnsiStr(this IntPtr ptr, int length)
        {
            return length > 0 ?
                Marshal.PtrToStringAnsi(ptr, length) :
                Marshal.PtrToStringAnsi(ptr);
        }
        public static string ToAnsiStr(this IntPtr ptr, uint length)
        {
            return length > 0 ?
                Marshal.PtrToStringAnsi(ptr, (int)length) :
                Marshal.PtrToStringAnsi(ptr);
        }
        public static Int16 ReadInt16(this IntPtr ptr)
        {
            return Marshal.ReadInt16(ptr);
        }
        public static Int32 ReadInt32(this IntPtr ptr)
        {
            return Marshal.ReadInt32(ptr);
        }
        public static Int64 ReadInt64(this IntPtr ptr)
        {
            return Marshal.ReadInt64(ptr);
        }
        public static T ToStructure<T>(this IntPtr ptr) where T : struct
        {
            //return *(T*) ptr;
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }
        public static IntPtr ToPointer<T>(this T structure) where T : struct
        {
            var ptr = Marshal.AllocHGlobal(
                Marshal.SizeOf(structure));
            Marshal.StructureToPtr(structure, ptr, false);
            return ptr;
        }
        public static IntPtr Increase<T>(this IntPtr ptr)
        {
            ptr += Marshal.SizeOf(
                Activator.CreateInstance<T>());
            return ptr;
        }
        public static IntPtr Decrease<T>(this IntPtr ptr)
        {
            ptr -= Marshal.SizeOf(
                Activator.CreateInstance<T>());
            return ptr;
        }
        public static IntPtr Increase(this IntPtr ptr, int size)
        {
            ptr += size;
            return ptr;
        }
        public static IntPtr Decrease(this IntPtr ptr, int size)
        {
            ptr -= size;
            return ptr;
        }
        public static IntPtr Increase(this IntPtr ptr, uint size)
        {
            ptr += (int)size;
            return ptr;
        }
        public static IntPtr Decrease(this IntPtr ptr, uint size)
        {
            ptr -= (int)size;
            return ptr;
        }
        public static IntPtr Reallocate(this IntPtr ptr, int size)
        {
            ptr.Free();
            ptr = kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed, (uint)size);
            return ptr;
        }
        public static IntPtr Reallocate(this IntPtr ptr, uint size)
        {
            ptr.Free();
            ptr = kernel32.GlobalAlloc(GlobalMemoryFlags.Fixed, size);
            return ptr;
        }
        public static RegFlags ToFlag(this RegType type)
        {
            switch (type)
            {
                case RegType.RegNone:
                    return RegFlags.RegNone;

                case RegType.RegSz:
                    return RegFlags.RegSz;

                case RegType.RegExpandSz:
                    return RegFlags.RegExpandSz;

                case RegType.RegMultiSz:
                    return RegFlags.RegMultiSz;

                case RegType.RegBinary:
                    return RegFlags.RegBinary;

                case RegType.RegDword:
                    return RegFlags.RegDword;

                case RegType.RegQword:
                    return RegFlags.RegQword;

                case RegType.RegDwordBigEndian:
                    return RegFlags.RegDword;

                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
        public static TimeSpan ToTimeSpan(this Struct.Filetime time)
        {
            return TimeSpan.FromMilliseconds((((ulong)time.dwHighDateTime << 32) + (uint)time.dwLowDateTime) / 10000.0);
        }
    }     

    public static class Macro
    {
        public static BYTE GetRValue(uint rgb)
        {
            return LOBYTE(rgb);
        }
        public static BYTE GetGValue(uint rgb)
        {
            return LOBYTE(rgb >> 8);
        }
        public static BYTE GetBValue(uint rgb)
        {
            return LOBYTE(rgb >> 16);
        }
        public static WORD LOWORD(uint l)
        {
            return (WORD)(l & 0xffff);
        }
        public static WORD HIWORD(uint l)
        {
            return (WORD)((l >> 16) & 0xffff);
        }
        public static BYTE LOBYTE(uint w)
        {
            return (BYTE)(w & 0xff);
        }
        public static BYTE HIBYTE(uint w)
        {
            return (BYTE)((w >> 8) & 0xff);
        }
        public static int MAKELANGID(CultureInfo Culture)
        {
            return MAKELANGID(
                PRIMARYLANGID(Culture.LCID),
                SUBLANGID(Culture.LCID));

            // or Second Option
            //return Culture.LCID;
        }
        public static int MAKELANGID(int primary, int sub)
        {
            return (((ushort)sub) << 10) | ((ushort)primary);
        }
        public static int PRIMARYLANGID(int lcid)
        {
            return ((ushort)lcid) & 0x3ff;
        }
        public static int SUBLANGID(int lcid)
        {
            return ((ushort)lcid) >> 10;
        }
        public static IntPtr ALIGN_CLUSPROP(IntPtr num)
        {
            return (IntPtr)(((int)num + 3) & ~3);
        }
    } 
}
