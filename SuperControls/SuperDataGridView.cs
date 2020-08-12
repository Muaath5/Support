using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperControls
{
    [ToolboxItem(true)]
    public class SuperDataGridView : DataGridView, ISuperControl
    {
        

        private bool otherColorTime = false;

        [Browsable(true)]
        public Color OtherColor { get; set; }

        private int borderRadius = 20;

        [Browsable(true), DefaultValue(20)]
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
        /// <returns>True on success</returns>
        public bool Animate(int time, AnimateWindowFlags flags)
        {
            return NativeMethods.AnimateWindow(Handle, time, (int)flags);
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            
            if (otherColorTime)
            {
                Rows[Rows.Count].DefaultCellStyle.BackColor = OtherColor;
            }
            otherColorTime = !otherColorTime;
            base.OnRowsAdded(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Region = NativeMethods.GetRoundRegion(DisplayRectangle, borderRadius);
            base.OnSizeChanged(e);
        }
    }
}
