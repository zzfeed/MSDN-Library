
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
using System.Runtime.InteropServices;

using GUID = System.Guid;

namespace MSDN.Interface
{
    [Guid("c43dc798-95d1-4bea-9030-bb99e2983a1a")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList
    {
        // ITaskbarList
        [PreserveSig]
        void HrInit();
        [PreserveSig]
        void AddTab(SafeWindowHandle hwnd);
        [PreserveSig]
        void DeleteTab(SafeWindowHandle hwnd);
        [PreserveSig]
        void ActivateTab(SafeWindowHandle hwnd);
        [PreserveSig]
        void SetActiveAlt(SafeWindowHandle hwnd);

        // ITaskbarList2
        [PreserveSig]
        void MarkFullscreenWindow(
            SafeWindowHandle hwnd,
            [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

        // ITaskbarList3
        [PreserveSig]
        void SetProgressValue(SafeWindowHandle hwnd, UInt64 ullCompleted, UInt64 ullTotal);
        [PreserveSig]
        void SetProgressState(SafeWindowHandle hwnd, TaskbarProgressBarStatus tbpFlags);
        [PreserveSig]
        void RegisterTab(SafeWindowHandle hwndTab, SafeWindowHandle hwndMdi);
        [PreserveSig]
        void UnregisterTab(SafeWindowHandle hwndTab);
        [PreserveSig]
        void SetTabOrder(SafeWindowHandle hwndTab, SafeWindowHandle hwndInsertBefore);
        [PreserveSig]
        void SetTabActive(SafeWindowHandle hwndTab, SafeWindowHandle hwndInsertBefore, uint dwReserved);
        [PreserveSig]
        ComError ThumbBarAddButtons(
            SafeWindowHandle hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        [PreserveSig]
        ComError ThumbBarUpdateButtons(
            SafeWindowHandle hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        [PreserveSig]
        void ThumbBarSetImageList(SafeWindowHandle hwnd, IntPtr himl);
        [PreserveSig]
        void SetOverlayIcon(
          SafeWindowHandle hwnd,
          IntPtr hIcon,
          [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
        [PreserveSig]
        void SetThumbnailTooltip(
            SafeWindowHandle hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
        [PreserveSig]
        void SetThumbnailClip(
            SafeWindowHandle hwnd,
            IntPtr prcClip);

        // ITaskbarList4
        [PreserveSig]
        void SetTabProperties(
            SafeWindowHandle hwndTab,
            SetTabPropertiesOption stpFlags);
    }
}
