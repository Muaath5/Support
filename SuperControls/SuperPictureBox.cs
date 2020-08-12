using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace SuperControls
{
    [ToolboxItem(true)]
    //[Designer("System.Design.PictureBoxDesigner, System.Design")]
    public class SuperPictureBox : PictureBox, ISuperControl
    {
        private int borderRadius = 20;

        [Browsable(true)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Region = NativeMethods.GetRoundRegion(DisplayRectangle, borderRadius);
            }
        }

        public bool Animate(int time, AnimateWindowFlags flags)
        {
            return NativeMethods.AnimateWindow(Handle, time, (int)flags);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.Region = NativeMethods.GetRoundRegion(this.DisplayRectangle, borderRadius);
            base.OnSizeChanged(e);
        }
    }
}
