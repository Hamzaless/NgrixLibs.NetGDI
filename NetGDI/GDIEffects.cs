using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetGDI.NGHook;
using System.Windows.Forms;
using System.Threading;

namespace NetGDI
{
    public class GDIEffects
    {
        public GDIEffects()
        {
            //bo
            Random r = new Random();
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            int left = Screen.PrimaryScreen.Bounds.Left;
            int top = Screen.PrimaryScreen.Bounds.Top;
            int right = Screen.PrimaryScreen.Bounds.Right;
            int bottom = Screen.PrimaryScreen.Bounds.Bottom;
            POINT[] lppoint = new POINT[3];
            while (true)
            {
                uint[] randomColors = { 0x6d067f, 0xf7971b, 0x6bf71b, 0xd9f71b, 0x9f1bf7, 0xf31bf7, 0xdb1515, 0xFFFFFF };
                if (NGDISettings.InvertedColors.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr brush = CreateSolidBrush(randomColors[r.Next(randomColors.Length)]);
                    SelectObject(hdc, brush);
                    PatBlt(hdc, 0, 0, x, y, TernaryRasterOperations.PATINVERT);
                    DeleteObject(brush);
                    DeleteDC(hdc);
                    Thread.Sleep(NGDISettings.InvertedColors.Interval);
                }
                if (NGDISettings.BlurEffect.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr mhdc = CreateCompatibleDC(hdc);
                    IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                    IntPtr holdbit = SelectObject(mhdc, hbit);
                    BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                    AlphaBlend(hdc, r.Next(-4,4), r.Next(-4, 4), x, y, mhdc, 0, 0, x, y, new BLENDFUNCTION(0,0,70,0));
                    SelectObject(mhdc, holdbit);
                    DeleteObject(holdbit);
                    DeleteObject(hbit);
                    DeleteDC(mhdc);
                    DeleteDC(hdc);
                    Thread.Sleep(NGDISettings.BlurEffect.Interval);
                }
                if (NGDISettings.RoundedTunnelEffect.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr mhdc = CreateCompatibleDC(hdc);
                    IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                    IntPtr holdbit = SelectObject(mhdc, hbit);
                    lppoint[0].X = (left + 50) + 0;
                    lppoint[0].Y = (top - 50) + 0;
                    lppoint[1].X = (right + 50) + 0;
                    lppoint[1].Y = (top + 50) + 0;
                    lppoint[2].X = (left - 50) + 0;
                    lppoint[2].Y = (bottom - 50) + 0;
                    PlgBlt(hdc, lppoint, hdc, left - 20, top - 20, (right - left) + 40, (bottom - top) + 40, IntPtr.Zero, 0, 0);
                    DeleteDC(hdc);
                    Thread.Sleep(NGDISettings.RoundedTunnelEffect.Interval);
                }
                if (NGDISettings.HatchBrush.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr mhdc = CreateCompatibleDC(hdc);
                    IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                    IntPtr holdbit = SelectObject(mhdc, hbit);
                    IntPtr brush = CreateHatchBrush(r.Next(4), 0);
                    SetBkColor(hdc, randomColors[r.Next(randomColors.Length)]);
                    SelectObject(hdc, brush);
                    PatBlt(hdc, 0, 0, x, y, TernaryRasterOperations.PATINVERT);
                    DeleteObject(brush);
                    DeleteDC(hdc);
                    Thread.Sleep(NGDISettings.HatchBrush.Interval);
                }
                if (NGDISettings.PatternBrush.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr mhdc = CreateCompatibleDC(hdc);
                    IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                    IntPtr holdbit = SelectObject(mhdc, hbit);
                    byte[] bits = { 0xff, 0x81, 0xbd, 0xa5, 0xa5, 0x81, 0xff};
                    IntPtr bitmap = CreateBitmap(8, 8, 1, 1, bits);
                    IntPtr brush = CreatePatternBrush(bitmap);
                    SetBkColor(hdc, randomColors[r.Next(3)]);
                    SelectObject(hdc, brush);
                    PatBlt(hdc, 0, 0, x, y, TernaryRasterOperations.PATINVERT);
                    DeleteObject(brush);
                    DeleteDC(hdc);
                    Thread.Sleep(NGDISettings.PatternBrush.Interval);
                }
                if (NGDISettings.ColorFilters.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr mhdc = CreateCompatibleDC(hdc);
                    IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                    IntPtr holdbit = SelectObject(mhdc, hbit);
                    byte[] bits = { 0xff, 0x81, 0xbd, 0xa5, 0xa5, 0x81, 0xff };
                    IntPtr bitmap = CreateBitmap(8, 8, 1, 1, bits);
                    IntPtr brush = CreateSolidBrush(randomColors[r.Next(randomColors.Length)]);
                    SetBkColor(hdc, randomColors[r.Next(randomColors.Length)]);
                    SelectObject(hdc, brush);
                    BitBlt(hdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.MERGECOPY);
                    DeleteObject(brush);
                    DeleteDC(hdc);
                    Thread.Sleep(NGDISettings.ColorFilters.Interval);
                }
                if (NGDISettings.MeltingScreen.Enabled)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    IntPtr mhdc = CreateCompatibleDC(hdc);
                    IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                    IntPtr holdbit = SelectObject(mhdc, hbit);
                    byte[] bits = { 0xff, 0x81, 0xbd, 0xa5, 0xa5, 0x81, 0xff };
                    IntPtr bitmap = CreateBitmap(8, 8, 1, 1, bits);
                    IntPtr brush = CreateSolidBrush(randomColors[r.Next(randomColors.Length)]);
                    int rand = r.Next(x);
                    BitBlt(hdc, rand, r.Next(-4 , 4), r.Next(100), y, hdc, rand, 0, TernaryRasterOperations.SRCCOPY);
                    DeleteDC(hdc);
                }
            }
        }
    }

    public class NGDISettings
    {
        public static class InvertedColors
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 100;

        }
        public static class BlurEffect
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 50;

        }
        public static class RoundedTunnelEffect
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 100;

        }
        public static class HatchBrush
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 100;

        }
        public static class PatternBrush
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 100;

        }
        public static class ColorFilters
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 1000;

        }
        public static class MeltingScreen
        {
            public static bool Enabled { get; set; }
            public static int Interval { get; set; } = 100;

        }

    }
}
