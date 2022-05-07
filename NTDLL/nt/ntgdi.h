#ifdef _MSC_VER
#pragma once
#endif

#ifndef NTGDI_H
#define NTGDI_H

// NtGdiAbortDoc aborts a printer job.
W32KAPI
BOOL
NTAPI
NtGdiAbortDoc(
	IN HDC DC
	);

// NtGdiAbortPath discards all paths in a device context.
W32KAPI
BOOL
NTAPI
NtGdiAbortPath(
	IN HDC DC
	);

// NtGdiAddFontResourceW adds a font resource to the system font table.
W32KAPI
LONG
NTAPI
NtGdiAddFontResourceW(
	IN PWCHAR FileNames,					// file1\0\file2...
	IN ULONG FileNameCharacters,
	IN ULONG FilesInPath,
	IN FLONG Flags,
	IN ULONG ProcessIdOrThreadId,
	IN PDESIGNVECTOR DesignVector
	);

// NtGdiAddRemoteFontToDC adds a remote font to a device context.
W32KAPI
BOOL
NTAPI
NtGdiAddRemoteFontToDC(
	IN HDC DC,
	IN PVOID Buffer,
	IN ULONG BufferSize,
	IN PUNIVERSAL_FONT_ID FontId
	);

// NtGdiAddFontMemResourceEx adds a font resource to the system font table.
W32KAPI
HANDLE
NTAPI
NtGdiAddFontMemResourceEx(
	IN PVOID Buffer,
	IN ULONG BufferSize,
	IN PDESIGNVECTOR DesignVector,
	IN ULONG DesignVectorSize,
	OUT PULONG NumberOfFontsInstalled
	);

// NtGdiRemoveMergeFont removes a merge font from a DC.
W32KAPI
BOOL
NTAPI
NtGdiRemoveMergeFont(
	IN HDC DC,
	IN PUNIVERSAL_FONT_ID FontId
	);

W32KAPI
BOOL
NTAPI
NtGdiAddRemoteMMInstanceToDC(
	IN HDC DC,
	IN PDOWNLOADDESIGNVECTOR DesignVector,
	IN ULONG DesignVectorSize
	);

// NtGdiAlphaBlend performs an alpha blend.
W32KAPI
BOOL
NTAPI
NtGdiAlphaBlend(
	IN HDC DestDC,
	IN LONG DstX,
	IN LONG DstY,
	IN LONG DstCx,
	IN LONG DstCy,
	IN HDC SourceDC,
	IN LONG SrcX,
	IN LONG SrcY,
	IN LONG SrcCx,
	IN LONG SrcCy,
	IN BLENDFUNCTION BlendFunction,
	IN HANDLE TransformHandle				// Cm
	);

// NtGdiAngleArc draws an angled arc.
W32KAPI
BOOL
NTAPI
NtGdiAngleArc(
	IN HDC DC,
	IN LONG X,
	IN LONG Y,
	IN ULONG Radius,
	IN ULONG StartAngle,
	IN ULONG SweepAngle
	);

// NtGdiAnyLinkedFonts determines if there are any linked fonts present.
W32KAPI
BOOL
NTAPI
NtGdiAnyLinkedFonts(
	VOID
	);

// NtGdiFontIsLinked determines if a font selected into a DC is a linked font.
W32KAPI
BOOL
NTAPI
NtGdiFontIsLinked(
	IN HDC DC
	);

// NtGdiArcInternal draws an arc, pie, chord, or an ellipitic arc.
W32KAPI
BOOL
NTAPI
NtGdiArcInternal(
	IN ARCTYPE ArcType,
	IN HDC DC,
	IN LONG X1,
	IN LONG Y1,
	IN LONG X2,
	IN LONG Y2,
	IN LONG X3,
	IN LONG Y3,
	IN LONG X4,
	IN LONG Y4
	);

// NtGdiBeginPath opens a path bracket in a device context.
W32KAPI
BOOL
NTAPI
NtGdiBeginPath(
	IN HDC DC
	);

#if _WIN32_WINNT >= 0x0500

// NtGdiBitBlt performs a bit block transfer.
W32KAPI
BOOL
NTAPI
NtGdiBitBlt(
	IN HDC Dest,
	IN LONG X,
	IN LONG Y,
	IN LONG CountX,
	IN LONG CountY,
	IN HDC Source,
	IN LONG XSrc,
	IN LONG YSrc,
	IN ULONG RasterOperation4,
	IN ULONG BackgroundColor,
	IN FLONG Flags
	);

#else

// NtGdiBitBlt performs a bit block transfer.
W32KAPI
BOOL
NTAPI
NtGdiBitBlt(
	IN HDC Dest,
	IN LONG X,
	IN LONG Y,
	IN LONG CountX,
	IN LONG CountY,
	IN HDC Source,
	IN LONG XSrc,
	IN LONG YSrc,
	IN ULONG RasterOperation4,
	IN ULONG BackgroundColor,
	IN FLONG Flags
	);

#endif

// NtGdiCancelDC cancels any pending operations on a device context.
W32KAPI
BOOL
NTAPI
NtGdiCancelDC(
	IN HDC DC
	);

// NtGdiCheckBitmapBits checks whether the pixels in a specified bitmap lie within the output gamut of a specified transform.
W32KAPI
BOOL
NTAPI
NtGdiCheckBitmapBits(
	IN HDC DC,
	IN HANDLE ColorTransform,
	IN PVOID Bits,
	IN ULONG BitmapFormat,
	IN ULONG Width,
	IN ULONG Height,
	IN ULONG Stride,
	OUT PVOID Results
	);

// NtGdiCloseFigure closes the current figure in a path.
W32KAPI
BOOL
NTAPI
NtGdiCloseFigure(
	IN HDC DC
	);

// NtGdiClearBitmapAttributes clears attributes on a bitmap.
W32KAPI
HBITMAP
NTAPI
NtGdiClearBitmapAttributes(
	IN HBITMAP Bitmap,
	IN ULONG Flags
	);

// NtGdiClearBrushAttributes clears attributes on a brush.
W32KAPI
HBRUSH
NTAPI
NtGdiClearBrushAttributes(
	IN HBRUSH Brush,
	IN ULONG Flags
	);

#if _WIN32_WINNT >= 0x0500

// NtGdiColorCorrectPalette corrects the entries of a palette using the ICM 2.0 parameters in a device context.
W32KAPI
ULONG
NTAPI
NtGdiColorCorrectPalette(
	IN HDC DC,
	IN HPALETTE Palette,
	IN ULONG FirstEntry,
	IN ULONG NumberOfEntries,
	IN OUT PPALETTEENTRY PaletteEntry,
	IN ULONG Reserved
	);

#endif

// NtGdiCombineRgn combines two regions to form a third region.
W32KAPI
LONG
NTAPI
NtGdiCombineRgn(
	IN HRGN Dest,
	IN HRGN Source1, 
	IN HRGN Source2,
	IN LONG Mode
	);

// NtGdiCombineTransform combines two world-space to page-space transforms.
W32KAPI
BOOL
NTAPI
NtGdiCombineTransform(
	OUT PXFORM Dest,
	IN PXFORM Source1,
	IN PXFORM Source2
	);

// NtGdiComputeXformCoefficients computes the coefficient for the device context's current transform.
W32KAPI
BOOL
NTAPI
NtGdiComputeXformCoefficients(
	IN HDC DC
	);

// NtGdiConsoleTextOut displays text on a console.
W32KAPI
BOOL
NTAPI
NtGdiConsoleTextOut(
	IN HDC DC,
	IN PPOLYTEXTW Text,
	IN LONG NumStrings,
	IN PRECTL Bounds
	);

W32KAPI
LONG
NTAPI
NtGdiConvertMetafileRect(
	IN HDC DC,
	IN OUT PRECTL Rect
	);

// NtGdiCreateBitmap creates a bitmap.
W32KAPI
HBITMAP
NTAPI
NtGdiCreateBitmap(
	IN LONG CountX,
	IN LONG CountY,
	IN ULONG NumPlanes,
	IN ULONG BitsPerPixel,
	IN LPVOID Bits OPTIONAL
	);

W32KAPI
HANDLE
NTAPI
NtGdiCreateClientObj(
	IN ULONG Type
	);

// NtGdiCreateColorSpace creates a colorspace.
W32KAPI
HANDLE
NTAPI
NtGdiCreateColorSpace(
	IN PLOGCOLORSPACEEXW LogColorSpace
	);

// NtGdiCreateColorTransform creates a color transform.
W32KAPI
HANDLE
NTAPI
NtGdiCreateColorTransform(
	IN HDC DC,
	IN PLOGCOLORSPACEW LogColorSpace,
	IN PVOID SrcProfile,
	IN ULONG SrcProfileSize,
	IN PVOID DestProfile,
	IN ULONG DestProfileSize,
	IN PVOID TargetProfile,
	IN ULONG TargetProfileSize
	);

// NtGdiCreateCompatibleBitmap creates a bitmap that is compatible with a specified device context.
W32KAPI
HBITMAP
NTAPI
NtGdiCreateCompatibleBitmap(
	IN HDC DC,
	IN LONG SizeX,
	IN LONG SizeY
	);

// NtGdiCreateCompatibleDC creates a memory device context that is compatible with a specified device context.
W32KAPI
HDC
NTAPI
NtGdiCreateCompatibleDC(
	IN HDC DC
	);

// NtGdiCreateDIBBrush creates a brush from a DIB.
W32KAPI
HBRUSH
NTAPI
NtGdiCreateDIBBrush(
	IN PVOID Bits,
	IN FLONG Usage,
	IN ULONG Size,
	IN BOOL BrushIs8X8,
	IN BOOL CreatePen,
	IN PVOID Client
	);

// NtGdiCreateDIBitmapInternal creates a device-independent bitmap.
W32KAPI
HBITMAP
NTAPI
NtGdiCreateDIBitmapInternal(
	IN HDC DC,
	IN LONG SizeX,
	IN LONG SizeY,
	IN ULONG InitFormat,
	IN LPVOID InitData,
	IN PBITMAPINFO BitmapInfo,
	IN ULONG Usage,
	IN ULONG MaxInitInfoSize,
	IN ULONG MaxBits,
	IN FLONG Flags,
	IN HANDLE ColorTransform
	);

// NtGdiCreateDIBSection creates a device-independent bitmap allocated by either a section or user-space virtual memory.
W32KAPI
HBITMAP
NTAPI
NtGdiCreateDIBSection(
	IN HDC DC,
	IN HANDLE Section,
	IN ULONG SectionOffset,
	IN PBITMAPINFO BitmapInfo,
	IN ULONG Usage,
	IN ULONG HeaderSize,
	IN FLONG Flags,
	IN ULONG_PTR ColorSpace,
	OUT PVOID *SectionView
	);

// NtGdiCreateEllipticRgn creates an elliptic region.
W32KAPI
HRGN
NTAPI
NtGdiCreateEllipticRgn(
	IN LONG XLeft,
	IN LONG YTop,
	IN LONG XRight,
	IN LONG YBottom
	);

// NtGdiCreateHalftonePalette creates a halftone palette.
W32KAPI
HPALETTE
NTAPI
NtGdiCreateHalftonePalette(
	IN HDC DC
	);

// NtGdiCreateHatchBrushInternal creates a hatch brush.
W32KAPI
HBRUSH
NTAPI
NtGdiCreateHatchBrushInternal(
	IN ULONG Style,
	IN COLORREF Color,
	IN BOOL Pen
	);

// NtGdiCreateMetafileDC creates a metafile device context.
W32KAPI
HDC
NTAPI
NtGdiCreateMetafileDC(
	IN HDC DC
	);

// NtGdiCreatePaletteInternal creates a palette.
W32KAPI
HPALETTE
NTAPI
NtGdiCreatePaletteInternal(
	IN PLOGPALETTE LogPalette,
	IN ULONG NumEntries
	);

// NtGdiCreatePatternBrushInternal creates a pattern brush.
W32KAPI
HBRUSH
NTAPI
NtGdiCreatePatternBrushInternal(
	IN HBITMAP Bitmap,
	IN BOOL CreatePen,
	IN BOOL Create8X8
	);

// NtGdiCreatePen creates a pen.
W32KAPI
HPEN
NTAPI
NtGdiCreatePen(
	IN LONG PenStyle,
	IN LONG PenWidth,
	IN COLORREF Color,
	IN HBRUSH Brush
	);

// NtGdiCreateRectRgn creates a rectangular region.
W32KAPI
HRGN
NTAPI
NtGdiCreateRectRgn(
	IN LONG XLeft,
	IN LONG YTop,
	IN LONG XRight,
	IN LONG YBottom
	);

// NtGdiCreateRoundRectRgn creates a round region containing a rectangular area.
W32KAPI
HRGN
NTAPI
NtGdiCreateRoundRectRgn(
	IN LONG XLeft,
	IN LONG YTop,
	IN LONG XRight,
	IN LONG YBottom,
	IN LONG XWidth,
	IN LONG YHeight
	);

// NtGdiCreateServerMetaFile creates a server metafile.
W32KAPI
HANDLE
NTAPI
NtGdiCreateServerMetaFile(
	IN ULONG Type,
	IN ULONG DataSize,
	IN PVOID Data,
	IN ULONG Mm,
	IN ULONG XExt,
	IN DWORD yExt
	);

// NtGdiCreateSolidBrush creates a solid brush.
W32KAPI
HBRUSH
NTAPI
NtGdiCreateSolidBrush(
	IN COLORREF Color,
	IN HBRUSH Brush
	);

/*
// NtGdiD3dContextCreate creates a Direct3D context.
W32KAPI
ULONG
NTAPI
NtGdiD3dContextCreate(
	IN HANDLE DirectDrawLocal,
	IN HANDLE SurfColor,
	IN HANDLE SurfZ,
	IN OUT PD3DNTHAL_CONTEXTCREATEI CreateContextInfo
	);
*/

// NtGdiDeleteClientObj deletes a client object.
W32KAPI
BOOL
NTAPI
NtGdiDeleteClientObj(
	IN HANDLE ClientObject
	);

// NtGdiDeleteColorSpace deletes a color space.
W32KAPI
BOOL
NTAPI
NtGdiDeleteColorSpace(
	IN HANDLE ColorSpace
	);

// NtGdiDeleteColorTransform deletes a color transform.
W32KAPI
BOOL
NTAPI
NtGdiDeleteColorTransform(
	IN HDC DC,
	IN HANDLE ColorTransform
	);

// NtGdiDeleteObjectApp deletes a GDI object.
W32KAPI
BOOL
NTAPI
NtGdiDeleteObjectApp(
	IN HANDLE GdiObject
	);

// NtGdiEnableEudc enables or disables user-defined character sets.
W32KAPI
BOOL
NTAPI
NtGdiEnableEudc(
	IN BOOL Enable
	);

// NtGdiExtTextOutW displays text.
W32KAPI
BOOL
NTAPI
NtGdiExtTextOutW(
	IN HDC DC,
	IN LONG X,
	IN LONG Y,
	IN ULONG Options,
	IN PRECT Rect,
	IN LPWSTR String,
	IN LONG StringChars,
	IN PLONG Dx,
	IN ULONG CodePage
	);

// NtGdiHfontCreate creates a font.
W32KAPI
HFONT
NTAPI
NtGdiHfontCreate(
#if _WIN32_WINNT >= 0x0500
	IN PENUMLOGFONTEXDVW FontInfo,
#else
	IN PEXTLOGFONTW FontInfo,
#endif
	IN ULONG FontInfoSize,
	IN LFTYPE FontType,
	IN FLONG Flags,
	IN PVOID ClientData
	);

// NtGdiInit initializes NtGdi for the current process.
W32KAPI
BOOL
NTAPI
NtGdiInit(
	VOID
	);

// NtGdiSelectBitmap selects a bitmap into a device context.
W32KAPI
HBITMAP
NTAPI
NtGdiSelectBitmap(
	IN HDC DC,
	IN HBITMAP Bitmap
	);

// NtGdiSelectBrush selects a brush into a device context.
W32KAPI
HBRUSH
NTAPI
NtGdiSelectBrush(
	IN HDC DC,
	IN HBRUSH Brush
	);

// NtGdiSelectClipPath selects a clip path mode for a device context.
W32KAPI
BOOL
NTAPI
NtGdiSelectClipPath(
	IN HDC DC,
	IN LONG Mode
	);

// NtGdiSelectFont selects a font into a device context.
W32KAPI
HFONT
NTAPI
NtGdiSelectFont(
	IN HDC DC,
	IN HFONT Font
	);

// NtGdiSelectPen selects a pen into a device context.
W32KAPI
HPEN
NTAPI
NtGdiSelectPen(
	IN HDC DC,
	IN HPEN Pen
	);

#endif
