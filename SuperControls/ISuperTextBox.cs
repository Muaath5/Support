using System;
using System.Windows.Forms;

namespace SuperControls
{
    /// <inheritdoc/>
    public interface ISuperTextBox : ISuperControl
    {
        event ScrollEventHandler VerticalScroll;

        event ScrollEventHandler HorizontalScroll;

        public int VerticalScrollBarValue { get; set; }

        public int HorizontalScrollBarValue { get; set; }

        void OnVerticalScroll(ScrollEventArgs e);

        void OnHorizontalScroll(ScrollEventArgs e);

        int CurrentLine { get; set; }
    }

    
}
