using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperControls
{
    /// <summary>
    /// Inherited from <see cref="Panel"/>, Impelements <see cref="ISuperControl"/>
    /// </summary>
    [
    ToolboxItem(true),
    Designer("System.Windows.Forms.Design.PanelDesigner, System.Design"),
    ]
    public class SuperPanel : Panel, ISuperControl
    {
        private int borderRadius = 0;

        [Browsable(true), DefaultValue(0)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Region = NativeMethods.GetRoundRegion(DisplayRectangle, borderRadius);
            }
        }


        /// <summary>
        /// Animate Control with some styles
        /// </summary>
        /// <param name="time">Time from animation start to end</param>
        /// <param name="flags">Animation style and type</param>
        /// <returns>Returns <see cref="false"/> when error</returns>
        public bool Animate(int time, AnimateWindowFlags flags)
        {
            return NativeMethods.AnimateWindow(Handle, time, (int)flags);
        }

        /// <inheritdoc/>
        protected override void OnSizeChanged(EventArgs e)
        {
            Region = NativeMethods.GetRoundRegion(DisplayRectangle, BorderRadius);
            base.OnSizeChanged(e);
            Invalidate();
        }
    }
}
