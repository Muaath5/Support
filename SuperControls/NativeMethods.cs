using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SuperControls
{
    /// <summary>
    /// Some Win32 methods
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Create Rounded rectangle <see cref="Region"/>
        /// </summary>
        /// <param name="nLeftRect">Rectangle.Left</param>
        /// <param name="nTopRect">Rectangle.Top</param>
        /// <param name="nRightRect">Rectangle.Right</param>
        /// <param name="nBottomRect">Rectangle.Bottom</param>
        /// <param name="nWidthEllipse">Ellipse horizintal radius</param>
        /// <param name="nHeightEllipse">Ellipse vertical radius</param>
        /// <returns></returns>
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn", SetLastError = true)]
        public static extern IntPtr GetRoundedRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        /// <summary>
        /// Draw Round rectangle
        /// </summary>
        /// <param name="hdc">HDC</param>
        /// <param name="left">Rectangle.Left</param>
        /// <param name="top">Rectangle.Top</param>
        /// <param name="right">Rectangle.Right</param>
        /// <param name="bottom">Rectangle.Bottom</param>
        /// <param name="width">Ellipse horizintal radius</param>
        /// <param name="height">Ellipse vertical radius</param>
        /// <returns>True on success</returns>
        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool RoundRect(IntPtr hdc, int left, int top, int right, int bottom, int width, int height);

        /// <summary>
        /// Delete GDI object
        /// </summary>
        /// <param name="hObject">object</param>
        /// <returns>True on success</returns>
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Animate Window
        /// </summary>
        /// <param name="hWnd">Window's handle</param>
        /// <param name="time">Time </param>
        /// <param name="flags"><see cref="AnimateWindowFlags"/></param>
        /// <returns>True on success</returns>
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hWnd, int time, int flags);

        /// <summary>
        /// Get Round region
        /// </summary>
        /// <param name="rect">Rectangle</param>
        /// <param name="radius"></param>
        /// <returns><see cref="Region"/></returns>
        public static Region GetRoundRegion(Rectangle rect, int radius)
        {
            if (radius == 0)
            {
                return new Region(rect);
            }

            IntPtr hRgn = GetRoundedRectRgn(rect.Left, rect.Top, rect.Right, rect.Bottom, radius, radius);
            
            Region roundRegion;

            try
            {
                roundRegion = Region.FromHrgn(hRgn);
            }
            catch
            {
                return null;
            }
            finally
            {
                DeleteObject(hRgn);
            }

            return roundRegion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <exception cref="Win32Exception">GDI Exception, 'RoundRect' method</exception>
        public static void DrawRoundRect(IntPtr hdc, Rectangle rect, int radius)
        {
            bool IsSuccess = RoundRect(hdc, rect.Left, rect.Top, rect.Right, rect.Bottom, radius, radius);
            if (!IsSuccess)
            {
                int lastErr = Marshal.GetLastWin32Error();
                if (lastErr != 0)
                {
                    throw new Win32Exception(lastErr, "GDI exception, \'RoundRect\' method");
                }
            }
        }

        /// <summary>
        /// Set scroll bar position
        /// </summary>
        /// <param name="hWnd">Handle</param>
        /// <param name="nBar">Bar type: 1 Vertical, 2 Horizonatal</param>
        /// <param name="nPos">New position</param>
        /// <param name="bRedraw"></param>
        /// <returns>Returns old value on success, otherwise returns 0</returns>
        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        /// <summary>
        /// Get scroll bar position
        /// </summary>
        /// <param name="hWnd">Handle</param>
        /// <param name="nBar">Bar type: 1 Vertical, 2 Horizonatal</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        
        public static int LowWord(int number)
        { 
            return number & 0x0000FFFF;
        }
        
        public static int HighWord(int number)
        { 
            return (int)(number & 0xFFFF0000);
        }
       
        
    }
}
