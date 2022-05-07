#ifdef _MSC_VER
#pragma once
#endif

#ifndef NTGDITYPES_H
#define NTGDITYPES_H

//
// WinDef
//

#ifndef _NTWIN32_NO_WINDEF




#endif

//
// WinGdi
//

#ifndef _NTWIN32_NO_WINGDI

#define STAMP_DESIGNVECTOR	(0x8000000 + 'd' + ('v' << 8))
#define STAMP_AXESLIST		(0x8000000 + 'a' + ('l' << 8))
#define MM_MAX_NUMAXES		16

typedef struct tagDESIGNVECTOR {
	DWORD dvReserved;
	DWORD dvNumAxes;
	LONG dvValues[MM_MAX_NUMAXES];
} DESIGNVECTOR, * PDESIGNVECTOR, FAR * LPDESIGNVECTOR;

#if _WIN32_WINNT >= 0x0500

typedef struct tagWCRANGE {
	WCHAR wcLow;
	USHORT cGlyphs;
} WCRANGE, * PWCRANGE, FAR * LPWCRANGE;

typedef struct tagGLYPHSET {
	DWORD cbThis;
	DWORD flAccel;
	DWORD cGlyphsSupported;
	DWORD cRanges;
	WCRANGE ranges[1];
} GLYPHSET, * PGLYPHSET, FAR * LPGLYPHSET;

#define GS_8BIT_INDICES				0x00000001

#define GGI_MARK_NONEXISTING_GLYPHS	0x0001

#endif

typedef USHORT COLOR16;

typedef struct _TRIVERTEX {
	LONG x;
	LONG y;
	COLOR16 Red;
	COLOR16 Green;
	COLOR16 Blue;
	COLOR16 Alpha;
} TRIVERTEX, * PTRIVERTEX, * LPTRIVERTEX;

typedef struct _GRADIENT_TRIANGLE {
	ULONG Vertex1;
	ULONG Vertex2;
	ULONG Vertex3;
} GRADIENT_TRIANGLE, * PGRADIENT_TRIANGLE, * LPGRADIENT_TRIANGLE;

typedef struct _GRADIENT_RECT {
	ULONG UpperLeft;
	ULONG LowerRight;
} GRADIENT_RECT, * PGRADIENT_RECT, * LPGRADIENT_RECT;

typedef struct _BLENDFUNCTION {
	BYTE BlendOp;
	BYTE BlendFlags;
	BYTE SourceConstantAlpha;
	BYTE AlphaFormat;
} BLENDFUNCTION, * PBLENDFUNCTION;

#define ERROR				0
#define NULLREGION			1
#define SIMPLEREGION		2
#define COMPLEXREGION		3
#define RGN_ERROR ERROR

#define RGN_AND				1
#define RGN_OR				2
#define RGN_XOR				3
#define RGN_DIFF			4
#define RGN_COPY			5
#define RGN_MIN				RGN_AND
#define RGN_MAX				RGN_COPY

#define BLACKONWHITE				1
#define WHITEONBLACK				2
#define COLORONCOLOR				3
#define HALFTONE					4
#define MAXSTRETCHBLTMODE			4

#if _WIN32_WINNT >= 0x0400

#define STRETCH_ANDSCANS			BLACKONWHITE
#define STRETCH_ORSCANS				WHITEONBLACK
#define STRETCH_DELETESCANS			COLORONCOLOR
#define STRETCH_HALFTONE			HALFTONE

#endif

#define ALTERNATE					1
#define WINDING						2
#define POLYFILL_LAST				2

#if _WIN32_WINNT >= 0x0500

#define LAYOUT_RTL							0x00000001
#define LAYOUT_BTT							0x00000002	// Bottom to top
#define LAYOUT_VBH							0x00000004	// Vertical before horizontal
#define LAYOUT_ORIENTATIONMASK				(LAYOUT_RTL | LAYOUT_BTT | LAYOUT_VBH)
#define LAYOUT_BITMAPORIENTATIONPRESERVED	0x00000008

#endif

#define TA_NOUPDATECP				0
#define TA_UPDATECP					1

#define TA_LEFT						0
#define TA_RIGHT					2
#define TA_CENTER					6

#define TA_TOP						0
#define TA_BOTTOM					8
#define TA_BASELINE					24

#if _WIN32_WINNT >= 0x0500

#define TA_RTLREADING				256
#define TA_MASK						(TA_BASELINE+TA_CENTER+TA_UPDATECP+TA_RTLREADING)

#else

#define TA_MASK						(TA_BASELINE+TA_CENTER+TA_UPDATECP)

#endif

#define VTA_BASELINE	TA_BASELINE
#define VTA_LEFT		TA_BOTTOM
#define VTA_RIGHT		TA_TOP
#define VTA_CENTER		TA_CENTER
#define VTA_BOTTOM		TA_RIGHT
#define VTA_TOP			TA_LEFT

#define ETO_OPAQUE					0x0002
#define ETO_CLIPPED					0x0004

#if _WIN32_WINNT >= 0x0400

#define ETO_GLYPH_INDEX				0x0010
#define ETO_RTLREADING				0x0080
#define ETO_NUMERICSLOCAL			0x0400
#define ETO_NUMERICSLATIN			0x0800
#define ETO_IGNORELANGUAGE			0x1000

#endif

#if _WIN32_WINNT >= 0x0500

#define ETO_PDY						0x2000

#endif

#define ASPECT_FILTERING			0x0001

#define DCB_RESET					0x0001
#define DCB_ACCUMULATE				0x0002
#define DCB_DIRTY					DCB_ACCUMULATE
#define DCB_SET						(DCB_RESET | DCB_ACCUMULATE)
#define DCB_ENABLE					0x0004
#define DCB_DISABLE					0x0008







#define _XFORM_

typedef struct tagXFORM {
	FLOAT eM11;
	FLOAT eM12;
	FLOAT eM21;
	FLOAT eM22;
	FLOAT eDx;
	FLOAT eDy;
} XFORM, * PXFORM, FAR * LPXFORM;

typedef struct tagBITMAP {
	LONG bmType;
	LONG bmWidth;
	LONG bmHeight;
	LONG bmWidthBytes;
	WORD bmPlanes;
	WORD bmBitsPixel;
	LPVOID bmBits;
} BITMAP, * PBITMAP, NEAR * NPBITMAP, FAR * LPBITMAP;

#include <pshpack1.h>

typedef struct tagRGBTRIPLE {
	BYTE rgbtBlue;
	BYTE rgbtGreen;
	BYTE rgbtRed;
} RGBTRIPLE, * PRGBTRIPLE;

#include <poppack.h>

typedef struct tagRGBQUAD {
	BYTE rgbBlue;
	BYTE rgbGreen;
	BYTE rgbRed;
	BYTE rgbReserved;
} RGBQUAD, * PRGBQUAD, FAR * LPRGBQUAD;

typedef struct tagPOLYTEXTW {
	int x;
	int y;
	UINT n;
	LPCWSTR lpstr;
	UINT uiFlags;
	RECT rcl;
	int *pdx;
} POLYTEXTW, * PPOLYTEXTW, NEAR * NPPOLYTEXTW, FAR * LPPOLYTEXTW;

#define CS_ENABLE						0x00000001L
#define CS_DISABLE						0x00000002L
#define CS_DELETE_TRANSFORM				0x00000003L

#define LCS_SIGNATURE					'PSOC'

#define LCS_sRGB						'sRGB'
#define LCS_WINDOWS_COLOR_SPACE			'Win '	// Windows default

typedef LONG LCSCSTYPE;

#define LCS_CALIBRATED_RGB				0x00000000L

typedef LONG LCSGAMUTMATCH;
#define LCS_GM_BUSINESS					0x00000001L
#define LCS_GM_GRAPHICS					0x00000002L
#define LCS_GM_IMAGES					0x00000004L
#define LCS_GM_ABS_COLORIMETRIC			0x00000008L

#define CM_OUT_OF_GAMUT					255
#define CM_IN_GAMUT						0

#define ICM_ADDPROFILE					1
#define ICM_DELETEPROFILE				2
#define ICM_QUERYPROFILE				3
#define ICM_SETDEFAULTPROFILE			4
#define ICM_REGISTERICMATCHER			5
#define ICM_UNREGISTERICMATCHER			6
#define ICM_QUERYMATCH					7

#define GetKValue(cmyk)					((BYTE)(cmyk))
#define GetYValue(cmyk)					((BYTE)((cmyk)>> 8))
#define GetMValue(cmyk)					((BYTE)((cmyk)>>16))
#define GetCValue(cmyk)					((BYTE)((cmyk)>>24))

#define CMYK(c,m,y,k)					((COLORREF)((((BYTE)(k)|((WORD)((BYTE)(y))<<8))|(((DWORD)(BYTE)(m))<<16))|(((DWORD)(BYTE)(c))<<24)))

typedef long FXPT16DOT16, * PFXPT16DOT16, FAR *LPFXPT16DOT16;
typedef long FXPT2DOT30, * PFXPT2DOT30, FAR *LPFXPT2DOT30;



typedef struct tagCIEXYZ {
	FXPT2DOT30 ciexyzX;
	FXPT2DOT30 ciexyzY;
	FXPT2DOT30 ciexyzZ;
} CIEXYZ, * PCIEXYZ, FAR * LPCIEXYZ;

typedef struct tagICEXYZTRIPLE
{
	CIEXYZ  ciexyzRed;
	CIEXYZ  ciexyzGreen;
	CIEXYZ  ciexyzBlue;
} CIEXYZTRIPLE;
typedef CIEXYZTRIPLE    FAR *LPCIEXYZTRIPLE;
typedef struct tagLOGCOLORSPACEW {
	DWORD lcsSignature;
	DWORD lcsVersion;
	DWORD lcsSize;
	LCSCSTYPE lcsCSType;
	LCSGAMUTMATCH lcsIntent;
	CIEXYZTRIPLE lcsEndpoints;
	DWORD lcsGammaRed;
	DWORD lcsGammaGreen;
	DWORD lcsGammaBlue;
	WCHAR  lcsFilename[MAX_PATH];
} LOGCOLORSPACEW, * PLOGCOLORSPACEW, * LPLOGCOLORSPACEW;




typedef struct tagBITMAPCOREHEADER {
	DWORD bcSize;
	WORD bcWidth;
	WORD bcHeight;
	WORD bcPlanes;
	WORD bcBitCount;
} BITMAPCOREHEADER, * PBITMAPCOREHEADER, FAR * LPBITMAPCOREHEADER;

typedef struct tagBITMAPINFOHEADER{
	DWORD biSize;
	LONG biWidth;
	LONG biHeight;
	WORD biPlanes;
	WORD biBitCount;
	DWORD biCompression;
	DWORD biSizeImage;
	LONG biXPelsPerMeter;
	LONG biYPelsPerMeter;
	DWORD biClrUsed;
	DWORD biClrImportant;
} BITMAPINFOHEADER, * PBITMAPINFOHEADER, FAR * LPBITMAPINFOHEADER;


#if _WIN32_WINNT >= 0x0400
typedef struct tagBITMAPV4HEADER {
	DWORD bV4Size;
	LONG bV4Width;
	LONG bV4Height;
	WORD bV4Planes;
	WORD bV4BitCount;
	DWORD bV4V4Compression;
	DWORD bV4SizeImage;
	LONG bV4XPelsPerMeter;
	LONG bV4YPelsPerMeter;
	DWORD bV4ClrUsed;
	DWORD bV4ClrImportant;
	DWORD bV4RedMask;
	DWORD bV4GreenMask;
	DWORD bV4BlueMask;
	DWORD bV4AlphaMask;
	DWORD bV4CSType;
	CIEXYZTRIPLE bV4Endpoints;
	DWORD bV4GammaRed;
	DWORD bV4GammaGreen;
	DWORD bV4GammaBlue;
} BITMAPV4HEADER, * PBITMAPV4HEADER, FAR * LPBITMAPV4HEADER;

#endif

#if _WIN32_WINNT >= 0x0500
typedef struct {
	DWORD bV5Size;
	LONG bV5Width;
	LONG bV5Height;
	WORD bV5Planes;
	WORD bV5BitCount;
	DWORD bV5Compression;
	DWORD bV5SizeImage;
	LONG bV5XPelsPerMeter;
	LONG bV5YPelsPerMeter;
	DWORD bV5ClrUsed;
	DWORD bV5ClrImportant;
	DWORD bV5RedMask;
	DWORD bV5GreenMask;
	DWORD bV5BlueMask;
	DWORD bV5AlphaMask;
	DWORD bV5CSType;
	CIEXYZTRIPLE bV5Endpoints;
	DWORD bV5GammaRed;
	DWORD bV5GammaGreen;
	DWORD bV5GammaBlue;
	DWORD bV5Intent;
	DWORD bV5ProfileData;
	DWORD bV5ProfileSize;
	DWORD bV5Reserved;
} BITMAPV5HEADER, * PBITMAPV5HEADER, FAR * LPBITMAPV5HEADER;

// bV5CSType
#define PROFILE_LINKED			'LINK'
#define PROFILE_EMBEDDED		'MBED'
#endif

// biCompression
#define BI_RGB			0L
#define BI_RLE8			1L
#define BI_RLE4			2L
#define BI_BITFIELDS	3L
#define BI_JPEG			4L
#define BI_PNG			5L

typedef struct tagBITMAPINFO {
	BITMAPINFOHEADER bmiHeader;
	RGBQUAD bmiColors[1];
} BITMAPINFO, * PBITMAPINFO, FAR * LPBITMAPINFO;

typedef struct tagBITMAPCOREINFO {
	BITMAPCOREHEADER bmciHeader;
	RGBTRIPLE bmciColors[1];
} BITMAPCOREINFO, * PBITMAPCOREINFO, FAR *LPBITMAPCOREINFO;

#include <pshpack2.h>

typedef struct tagBITMAPFILEHEADER {
	WORD bfType;
	DWORD bfSize;
	WORD bfReserved1;
	WORD bfReserved2;
	DWORD bfOffBits;
} BITMAPFILEHEADER, * PBITMAPFILEHEADER, FAR *LPBITMAPFILEHEADER;

#include <poppack.h>

#define MAKEPOINTS(l)			(*((POINTS FAR *)&(l)))

#ifndef CCHDEVICENAME
#define CCHDEVICENAME			32
#endif

#define CCHFORMNAME				32

typedef struct _devicemodeW {
	WCHAR dmDeviceName[CCHDEVICENAME];
	WORD dmSpecVersion;
	WORD dmDriverVersion;
	WORD dmSize;
	WORD dmDriverExtra;
	DWORD dmFields;
	union {
		// Printer fields
		struct {
			short dmOrientation;
			short dmPaperSize;
			short dmPaperLength;
			short dmPaperWidth;
			short dmScale;
			short dmCopies;
			short dmDefaultSource;
			short dmPrintQuality;
		};
		// Display fields
		struct {
			POINTL dmPosition;
			DWORD dmDisplayOrientation;
			DWORD dmDisplayFixedOutput; 
		};
	};
	short dmColor;
	short dmDuplex;
	short dmYResolution;
	short dmTTOption;
	short dmCollate;
	WCHAR dmFormName[CCHFORMNAME];
	WORD dmLogPixels;
	DWORD dmBitsPerPel;
	DWORD dmPelsWidth;
	DWORD dmPelsHeight;
	union {
		DWORD dmDisplayFlags;
		DWORD dmNup;
	};
	DWORD dmDisplayFrequency;
#if _WIN32_WINNT >= 0x0400
	DWORD dmICMMethod;
	DWORD dmICMIntent;
	DWORD dmMediaType;
	DWORD dmDitherType;
	DWORD dmReserved1;
	DWORD dmReserved2;
	DWORD dmPanningWidth;
	DWORD dmPanningHeight;
#endif
} DEVMODEW, *PDEVMODEW, *NPDEVMODEW, *LPDEVMODEW;

#define LF_FULLFACESIZE		64
#define LF_FACESIZE			32

typedef struct tagLOGFONTW {
	LONG lfHeight;
	LONG lfWidth;
	LONG lfEscapement;
	LONG lfOrientation;
	LONG lfWeight;
	BYTE lfItalic;
	BYTE lfUnderline;
	BYTE lfStrikeOut;
	BYTE lfCharSet;
	BYTE lfOutPrecision;
	BYTE lfClipPrecision;
	BYTE lfQuality;
	BYTE lfPitchAndFamily;
	WCHAR lfFaceName[LF_FACESIZE];
} LOGFONTW, * PLOGFONTW, NEAR * NPLOGFONTW, FAR * LPLOGFONTW;

typedef struct tagENUMLOGFONTEXW {
	LOGFONTW elfLogFont;
	WCHAR elfFullName[LF_FULLFACESIZE];
	WCHAR elfStyle[LF_FACESIZE];
	WCHAR elfScript[LF_FACESIZE];
} ENUMLOGFONTEXW, FAR *LPENUMLOGFONTEXW;

typedef struct tagENUMLOGFONTEXDVW {
	ENUMLOGFONTEXW elfEnumLogfontEx;
	DESIGNVECTOR elfDesignVector;
} ENUMLOGFONTEXDVW, * PENUMLOGFONTEXDVW, FAR * LPENUMLOGFONTEXDVW;



#else

//
// Fixups for WinGdi
//

typedef LOGCOLORSPACEW * PLOGCOLORSPACEW;

#endif

//
// NtGdi
//

#define FL_UFI_PRIVATEFONT		1
#define FL_UFI_DESIGNVECTOR_PFF	2
#define FL_UFI_MEMORYFONT		4

typedef int UNIVERSAL_FONT_ID, * PUNIVERSAL_FONT_ID; // ???

#define ICM_SET_MODE			1
#define ICM_SET_CALIBRATE_MODE	2
#define ICM_SET_COLOR_MODE		3
#define ICM_CHECK_COLOR_MODE	4

typedef struct _LOGCOLORSPACEEXW {
	LOGCOLORSPACEW lcsColorSpace;
	DWORD dwFlags;
} LOGCOLORSPACEEXW, * PLOGCOLORSPACEEXW;

#define LCSEX_ANSICREATED		0x0001	// CreateColorSpaceA
#define LCSEX_TEMPPROFILE		0x0002	// Temp

typedef enum _COLORPALETTEINFO {
	ColorPaletteQuery,
	ColorPaletteSet
} COLORPALETTEINFO, * PCOLORPALETTEINFO;

typedef enum _ICM_DIB_INFO_CMD {
	IcmQueryBrush,
	IcmSetBrush
} ICM_DIB_INFO, * PICM_DIB_INFO;

#define GS_NUM_OBJS_ALL		0
#define GS_HANDOBJ_CURRENT	1
#define GS_HANDOBJ_MAX		2
#define GS_HANDOBJ_ALLOC	3
#define GS_LOOKASIDE_INFO	4

typedef struct _POLYPATBLT POLYPATBLT, * PPOLYPATBLT; // ??
typedef struct _DEVCAPS DEVCAPS, * PDEVCAPS; // ??
typedef struct _ENUMFONTDATAW ENUMFONTDATAW, * PENUMFONTDATAW; // ??

typedef struct tagDOWNLOADDESIGNVECTOR {
	UNIVERSAL_FONT_ID ufiBase;
	DESIGNVECTOR dv;
} DOWNLOADDESIGNVECTOR, * PDOWNLOADDESIGNVECTOR;

typedef enum _ARCTYPE {
	ARCTYPE_ARC,
	ARCTYPE_ARCTO,
	ARCTYPE_CHORD,
	ARCTYPE_PIE,
	ARCTYPE_MAX
} ARCTYPE, * PARCTYPE;

typedef enum _LFTYPE {
	LF_TYPE_USER,					// user-defined
	LF_TYPE_SYSTEM,					//
	LF_TYPE_SYSTEM_FIXED,			// fixed pitch
	LF_TYPE_OEM,					//
	LF_TYPE_DEVICE_DEFAULT,			//
	LF_TYPE_ANSI_VARIABLE,			// variable pitch
	LF_TYPE_ANSI_FIXED,				// fixed pitch
	LF_TYPE_DEFAULT_GUI				//
} LFTYPE, * PLFTYPE;


#endif
