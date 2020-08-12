using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace SuperControls
{
    /// <summary>
    /// SuperButton, Inherits from <see cref="Button"/>, <see cref="ISuperControl"/>
    /// </summary>
    [ToolboxItem(true)]
    [Designer("System.Windows.Forms.Design.ButtonBaseDesigner, System.Design")]
    public class SuperButton : Button, ISuperControl
    {
        //[DllImport("gdi32.dll", EntryPoint = "RoundRect")]
        //private static extern bool DrawRoundRect(IntPtr hdc, int left, int top, int right, int bottom, int width, int height);

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

        
        /// <summary>
        /// Super Button
        /// </summary>
        public SuperButton() : base()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            ForeColor = SystemColors.HighlightText;
            BackColor = SystemColors.Highlight;
        }

        /// <summary>
        /// Call enabeld changed event
        /// </summary>
        /// <param name="e"><see cref="EventArgs"/></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            switch (Enabled)
            {
                case true:
                    Cursor = this.DefaultCursor;
                    break;
                case false:
                    Cursor = Cursors.No;
                    break;
            }
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Animate Control with some styles
        /// </summary>
        /// <param name="time">Time from animation start to end</param>
        /// <param name="flags">Animation style and type</param>
        /// <returns>Returns <see cref="false"/> when error</returns>
        public bool Animate(int time, AnimateWindowFlags flags)
        {
            return NativeMethods.AnimateWindow(this.Handle, time, (int)flags);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            this.Region = NativeMethods.GetRoundRegion(this.DisplayRectangle, borderRadius);
            base.OnSizeChanged(e);
        }
    }
}
