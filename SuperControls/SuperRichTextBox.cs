using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SuperControls
{
    /// <summary>
    /// Inherited from <see cref="RichTextBox"/>, Impelements <see cref="ISuperTextBox"/>
    /// </summary>
    [ToolboxItem(true), Designer("System.Windows.Forms.Design.TextBoxBaseDesigner, System.Design")]
    public class SuperRichTextBox : RichTextBox, ISuperTextBox
    {
        private int borderRadius = 20;

        public event ScrollEventHandler VerticalScroll;
        public event ScrollEventHandler HorizontalScroll;


        /// <summary>
        /// Border ellipse radius, if no round conners let it 0
        /// </summary>
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
        /// Current Line
        /// </summary>
        [Browsable(false)]
        public int CurrentLine
        {
            get { return GetLineFromCharIndex(GetFirstCharIndexOfCurrentLine()); }
            set { SelectionStart = GetFirstCharIndexFromLine(value); ScrollToCaret(); }
        }

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
                int oldScrollBarValue = NativeMethods.SetScrollPos(Handle, 2, value, true);
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x114:
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

        public bool Animate(int time, AnimateWindowFlags flags)
        {
            return NativeMethods.AnimateWindow(Handle, time, (int)flags);
        }

        /// <summary>
        /// Highlight any word with forecolor, backcolor
        /// </summary>
        /// <param name="foreColor">Highlighted word Text color</param>
        /// <param name="backColor">Highlighted word Back color</param>
        /// <param name="word">Highlighted Word</param>
        public void Highlight(Color foreColor, Color backColor, string word)
        {
            int charIndex = SelectionStart;
            while (Text.IndexOf(word) != -1)
            {
                Select(Text.IndexOf(word), word.Length);
                SelectionBackColor = backColor;
                SelectionColor = foreColor;
            }
            SelectionStart = charIndex;
            DeselectAll();
        }

        /// <summary>
        /// Dehighlight all
        /// </summary>
        public void DehighlightAll()
        {
            SelectAll();
            SelectionBackColor = BackColor;
            SelectionColor = ForeColor;
            DeselectAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">Event Arguments</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            Region = NativeMethods.GetRoundRegion(this.DisplayRectangle, borderRadius);
            base.OnSizeChanged(e);
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
    }
}
