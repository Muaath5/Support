using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperControls
{
    public class SuperGraphics : IDeviceContext
    {
        private readonly IntPtr hdc;

        public SuperGraphics(IntPtr hdc)
        {
            this.hdc = hdc;
        }

        public SuperGraphics(IWin32Window win)
        {

        }

        public void DrawRoundRect(Rectangle rect, int vRadius, int hRadius)
        {
            if (!NativeMethods.RoundRect(hdc: hdc, left: rect.Left, top: rect.Top, right: rect.Right, bottom: rect.Bottom, width: hRadius, height: vRadius))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public void DrawRoundRect(Rectangle rect, int radius)
        {
            DrawRoundRect(rect, vRadius: radius, hRadius: radius);
        }

        public Color GetPixel(Point pt)
        {
            return Color.Transparent;
            //return Color.
        }

        public void SetPixel(Color color, Point pt)
        {

        }

        #region IDeviceContext

        public void Dispose()
        {
            
        }

        public IntPtr GetHdc()
        {
            return hdc;
        }

        public void ReleaseHdc()
        {
            
        }

        #endregion
    }
}
