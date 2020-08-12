using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace SuperControls
{
    public class SuperForm : Form, ISuperControl
    {
        private int borderRadius = 0;
        private bool iconFromType = true;


        [Browsable(true)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                base.Region = NativeMethods.GetRoundRegion(this.DisplayRectangle, borderRadius);
            }
        }


        [Browsable(true), DefaultValue(typeof(FormType), "MainForm")]
        public FormType FormType { get; set; }


        [Browsable(true), DefaultValue(true)]
        public bool IconFromType 
        {
            get { return iconFromType; }
            set { iconFromType = value; Icon = SelectIcon(FormType); }
        }

        private Icon SelectIcon(FormType formType)
        {
            return formType switch
            {
                FormType.Other => null,
                FormType.MainForm => new Icon(""),
                FormType.SignIn => new Icon(""),
                FormType.Settings => new Icon(""),
                FormType.Browse => new Icon(""),
                _ => null,
            };
        }

        /// <summary>
        /// Animate Control with some styles
        /// </summary>
        /// <param name="time">Time from animation start to end</param>
        /// <param name="flags">Animation style and type</param>
        /// <returns>Returns <see cref="false"/> when error</returns>
        public bool Animate(int time, AnimateWindowFlags flags)
        {
            return NativeMethods.AnimateWindow(Handle, 1000, (int)flags);
        }
    }

    [Flags]
    public enum FormType
    {
        Other = 0,
        MainForm = 1,
        SignIn = 2,
        Settings = 4,
        Browse = 8,
    }
}
