using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Windows.Forms.VisualStyles;

namespace SuperControls
{
    [ToolboxItem(true)]
    [Designer("System.Windows.Forms.Design.TextBoxDesigner, System.Design", typeof(IDesigner))]
    public class SuperTextBox : TextBox, ISuperTextBox
    {
        public event ScrollEventHandler HorizontalScroll;

        public event ScrollEventHandler VerticalScroll;

        /// <summary>
        /// Vertical scroll bar value
        /// </summary>
        public int VerticalScrollBarValue 
        {
            get { return NativeMethods.GetScrollPos(Handle, 1); }
            set { NativeMethods.SetScrollPos(Handle, 1, value, true); }
        }


        /// <summary>
        /// Horizontal srcoll bar value
        /// </summary>
        public int HorizontalScrollBarValue
        {
            get { return NativeMethods.GetScrollPos(Handle, 2); }
            set 
            {
                if (ScrollBars == ScrollBars.Horizontal | ScrollBars == ScrollBars.Both)
                {
                    int oldScrollBarValue = NativeMethods.SetScrollPos(Handle, 2, value, true);
                }
                else
                {
                    //throw new DllNotFoundException()
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x114:
                    ScrollEventArgs args = new ScrollEventArgs((ScrollEventType)NativeMethods.LowWord(m.WParam.ToInt32()), );
                    OnVerticalScroll(null);
                    break;

                case 0x115:
                    OnHorizontalScroll(null);
                    break;

                default:
                    base.WndProc(ref m);
                    return;
            }
        }

        private int borderRadius = 0;

        private Color realColor;

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

        [Browsable(true)]
        public string HintText { get; set; }

        [Browsable(true)]
        public Color HintColor { get; set; } = Color.LightGray;

        [Browsable(true)]
        public InputDataType InputType { get; set; } = InputDataType.Text;

        [Browsable(false)]
        public bool IsHintVisible { get; private set; }

        public SuperTextBox() : base()
        {
            realColor = ForeColor;
        }

        [Browsable(false)]
        public int CurrentLine
        { 
            get { return GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine()); }
            set { SelectionStart = GetFirstCharIndexFromLine(value); ScrollToCaret(); }
        }

        protected override void OnBorderStyleChanged(EventArgs e)
        {
            switch (BorderStyle)
            {
                case BorderStyle.None:
                    NativeMethods.RoundRect(this.CreateGraphics().GetHdc(), DisplayRectangle.Left, DisplayRectangle.Top, DisplayRectangle.Right, DisplayRectangle.Bottom, borderRadius, borderRadius);
                    break;
                case BorderStyle.FixedSingle:
                    NativeMethods.RoundRect(this.CreateGraphics().GetHdc(), DisplayRectangle.Left, DisplayRectangle.Top, DisplayRectangle.Right, DisplayRectangle.Bottom, borderRadius, borderRadius);
                    break;
            }
            base.OnBorderStyleChanged(e);
        }

        public Point GetPositionFromLine(int lineNumber)
        {
            return GetPositionFromCharIndex(GetFirstCharIndexFromLine(lineNumber));
        }

        protected override void OnEnter(EventArgs e)
        {
            if (Text == HintText)
            {
                IsHintVisible = false;
                ForeColor = realColor;
                Text = "";
            }
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                Text = HintText;
                ForeColor = HintColor;
                IsHintVisible = true;
            }
            base.OnLeave(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.Region = NativeMethods.GetRoundRegion(this.DisplayRectangle, borderRadius);
            base.OnSizeChanged(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (!int.TryParse(Text, out int result) && InputType == InputDataType.Number)
            {
                Undo();
            }
            base.OnTextChanged(e);
        }

        public virtual void OnVerticalScroll(ScrollEventArgs e) 
        {
            ScrollEventHandler handler = VerticalScroll;
            handler?.Invoke(this, e);
        }

        public virtual void OnHorizontalScroll(ScrollEventArgs e) 
        {
            ScrollEventHandler handler = HorizontalScroll;
            handler?.Invoke(this, e);
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
    }
}
