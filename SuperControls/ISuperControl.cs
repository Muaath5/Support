using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace SuperControls
{
    public interface ISuperControl : IControl
    { 
        int BorderRadius { get; set; }

        bool Animate(int time, AnimateWindowFlags flags);
    }
}
