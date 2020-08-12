using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace SuperControls
{
    /// <summary>
    /// Non-Official, Everything in Control as an <see cref="interface"/>
    /// </summary>
    public interface IControl : IComponent, IWin32Window, IDropTarget, ISynchronizeInvoke
    {
        bool UseWaitCursor { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        bool IsHandleCreated { get; }
        IWindowTarget WindowTarget { get; set; }
        bool Visible { get; set; }
        ImeMode ImeMode { get; set; }
        Padding Padding { get; set; }
        Control TopLevelControl { get; }
        bool HasChildren { get; }
        Color ForeColor { get; set; }
        Font Font { get; set; }
        bool Focused { get; }
        Size PreferredSize { get; }
        int Top { get; set; }
        bool TabStop { get; set; }
        object Tag { get; set; }
        int Left { get; set; }
        Point Location { get; set; }
        Padding Margin { get; set; }
        Size MaximumSize { get; set; }
        Size MinimumSize { get; set; }
        string Name { get; set; }
        Control Parent { get; set; }
        string ProductName { get; }
        string Text { get; set; }
        string ProductVersion { get; }
        Region Region { get; set; }
        int Right { get; }
        RightToLeft RightToLeft { get; set; }
        Size Size { get; set; }
        int TabIndex { get; set; }
        bool Enabled { get; set; }
        bool RecreatingHandle { get; }
        DockStyle Dock { get; set; }
        bool Disposing { get; }
        Rectangle ClientRectangle { get; }
        bool CausesValidation { get; set; }
        bool Capture { get; set; }
        bool CanSelect { get; }
        bool CanFocus { get; }
        Rectangle Bounds { get; set; }
        int Bottom { get; }
        BindingContext BindingContext { get; set; }
        ImageLayout BackgroundImageLayout { get; set; }
        Image BackgroundImage { get; set; }
        bool IsMirrored { get; }
        Color BackColor { get; set; }
        Point AutoScrollOffset { get; set; }
        bool AutoSize { get; set; }
        AnchorStyles Anchor { get; set; }
        bool AllowDrop { get; set; }
        AccessibleRole AccessibleRole { get; set; }
        string AccessibleName { get; set; }
        string AccessibleDescription { get; set; }
        string AccessibleDefaultActionDescription { get; set; }
        AccessibleObject AccessibilityObject { get; }
        LayoutEngine LayoutEngine { get; }
        Size ClientSize { get; set; }
        bool IsAccessible { get; set; }
        bool ContainsFocus { get; }
        ContextMenu ContextMenu { get; set; }
        ContextMenuStrip ContextMenuStrip { get; set; }
        Control.ControlCollection Controls { get; }
        bool IsDisposed { get; }
        Rectangle DisplayRectangle { get; }
        bool Created { get; }
        int DeviceDpi { get; }
        Cursor Cursor { get; set; }
        ControlBindingsCollection DataBindings { get; }
        string CompanyName { get; }

        event EventHandler Leave;
        event LayoutEventHandler Layout;
        event KeyEventHandler KeyUp;
        event KeyPressEventHandler KeyPress;
        event KeyEventHandler KeyDown;
        event EventHandler GotFocus;
        event EventHandler Enter;
        event EventHandler DoubleClick;
        event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;
        event QueryContinueDragEventHandler QueryContinueDrag;
        event PaintEventHandler Paint;
        event EventHandler PaddingChanged;
        event InvalidateEventHandler Invalidated;
        event EventHandler LostFocus;
        event MouseEventHandler MouseClick;
        event MouseEventHandler MouseDoubleClick;
        event EventHandler MouseCaptureChanged;
        event MouseEventHandler MouseDown;
        event EventHandler MouseEnter;
        event EventHandler MouseLeave;
        event EventHandler DpiChangedBeforeParent;
        event MouseEventHandler MouseMove;
        event MouseEventHandler MouseUp;
        event MouseEventHandler MouseWheel;
        event EventHandler Move;
        event PreviewKeyDownEventHandler PreviewKeyDown;
        event EventHandler Resize;
        event UICuesEventHandler ChangeUICues;
        event EventHandler StyleChanged;
        event EventHandler SystemColorsChanged;
        event HelpEventHandler HelpRequested;
        event EventHandler HandleDestroyed;
        event EventHandler HandleCreated;
        event GiveFeedbackEventHandler GiveFeedback;
        event EventHandler AutoSizeChanged;
        event EventHandler BackColorChanged;
        event EventHandler BackgroundImageChanged;
        event EventHandler BackgroundImageLayoutChanged;
        event EventHandler BindingContextChanged;
        event EventHandler CausesValidationChanged;
        event EventHandler ClientSizeChanged;
        event EventHandler ContextMenuChanged;
        event EventHandler ContextMenuStripChanged;
        event EventHandler CursorChanged;
        event EventHandler DockChanged;
        event EventHandler EnabledChanged;
        event EventHandler FontChanged;
        event EventHandler ForeColorChanged;
        event CancelEventHandler Validating;
        event EventHandler LocationChanged;
        event EventHandler RegionChanged;
        event EventHandler RightToLeftChanged;
        event EventHandler SizeChanged;
        event EventHandler TabIndexChanged;
        event EventHandler TabStopChanged;
        event EventHandler TextChanged;
        event EventHandler VisibleChanged;
        event EventHandler Click;
        event ControlEventHandler ControlAdded;
        event ControlEventHandler ControlRemoved;
        event DragEventHandler DragDrop;
        event DragEventHandler DragEnter;
        event DragEventHandler DragOver;
        event EventHandler DragLeave;
        event EventHandler MarginChanged;
        event EventHandler DpiChangedAfterParent;
        event EventHandler MouseHover;
        event EventHandler Validated;
        event EventHandler ParentChanged;
        event EventHandler ImeModeChanged;
    }
}
