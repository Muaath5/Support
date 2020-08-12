using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperControls
{
    public class SuperContextMenuStrip : ContextMenuStrip
    {
        protected override void OnOpening(CancelEventArgs e)
        {
            if (Location == Cursor.Position)
            {
                NativeMethods.AnimateWindow(Handle, 50, (int)(AnimateWindowFlags.Activate | AnimateWindowFlags.BottomLeft));
            }
            else
            {
                NativeMethods.AnimateWindow(Handle, 50, (int)(AnimateWindowFlags.Activate | AnimateWindowFlags.TopRight));
            }
            base.OnOpening(e);
        }
    }
}
