// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MediaSlider.cs" company="Zeroit Dev Technologies">
//    This program is for creating Progress controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress.Sliders
{
    #region Media Slider

    #region Control    
    /// <summary>
    /// A class collection for rendering a Media slider control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(ZeroitMediaSlider), "tbimage")]
    [Designer(typeof(ZeroitMediaSliderDesigner))]
    public partial class ZeroitMediaSlider : UserControl
    {
        #region Constants
        /// <summary>
        /// The track minimum depth
        /// </summary>
        private const int TrackMinDepth = 2;
        /// <summary>
        /// The track maximum depth
        /// </summary>
        private const int TrackMaxDepth = 6;
        #endregion

        #region Enums        
        /// <summary>
        /// Enum for retrieving the animation speed for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum AnimateSpeed : int
        {
            /// <summary>
            /// The fast
            /// </summary>
            Fast = 1,
            /// <summary>
            /// The normal
            /// </summary>
            Normal = 5,
            /// <summary>
            /// The slow
            /// </summary>
            Slow = 20
        }

        /// <summary>
        /// Enum for setting the type of button<c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum ButtonType : uint
        {
            /// <summary>
            /// The round
            /// </summary>
            Round = 0,
            /// <summary>
            /// The rounded rect inline
            /// </summary>
            RoundedRectInline,
            /// <summary>
            /// The rounded rect overlap
            /// </summary>
            RoundedRectOverlap,
            /// <summary>
            /// The pointer up right
            /// </summary>
            PointerUpRight,
            /// <summary>
            /// The pointer down left
            /// </summary>
            PointerDownLeft,
            /// <summary>
            /// The hybrid
            /// </summary>
            Hybrid,
            /// <summary>
            /// The glass inline
            /// </summary>
            GlassInline,
            /// <summary>
            /// The glass overlap
            /// </summary>
            GlassOverlap
        }

        /// <summary>
        /// Enum for the Fly out style for for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum FlyOutStyle : int
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The on focus
            /// </summary>
            OnFocus,
            /// <summary>
            /// The persistant
            /// </summary>
            Persistant
        }

        /// <summary>
        /// Enum for the type of preset for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum PresetType : uint
        {
            /// <summary>
            /// The WMP volume
            /// </summary>
            WmpVolume,
            /// <summary>
            /// The WMP trackbar
            /// </summary>
            WmpTrackbar,
            /// <summary>
            /// The WMC track bar
            /// </summary>
            WmcTrackBar,
            /// <summary>
            /// The office2007
            /// </summary>
            Office2007,
            /// <summary>
            /// The glass
            /// </summary>
            Glass
        }

        /// <summary>
        /// Enum indicating the Tick Mode for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum TickMode : int
        {
            /// <summary>
            /// The standard
            /// </summary>
            Standard = 0,
            /// <summary>
            /// The composite
            /// </summary>
            Composite,
            /// <summary>
            /// The precision
            /// </summary>
            Precision,
            /// <summary>
            /// The large stepped
            /// </summary>
            LargeStepped
        }

        /// <summary>
        /// Enum indicating the Track type for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum TrackType : uint
        {
            /// <summary>
            /// The progress
            /// </summary>
            Progress = 0,
            /// <summary>
            /// The value
            /// </summary>
            Value
        }

        /// <summary>
        /// Enum indicating the point direction for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum PointDirection : int
        {
            /// <summary>
            /// The bottom
            /// </summary>
            Bottom = 0,
            /// <summary>
            /// The right
            /// </summary>
            Right
        }

        /// <summary>
        /// Enum indicating the Slider Selected State for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum SliderSelectedState : uint
        {
            /// <summary>
            /// The none
            /// </summary>
            None = 0,
            /// <summary>
            /// The disabled
            /// </summary>
            Disabled,
            /// <summary>
            /// The focused
            /// </summary>
            Focused,
            /// <summary>
            /// The mouse leave
            /// </summary>
            MouseLeave,
            /// <summary>
            /// The pressed
            /// </summary>
            Pressed,
            /// <summary>
            /// The depressed
            /// </summary>
            Depressed,
            /// <summary>
            /// The hover
            /// </summary>
            Hover
        }

        /// <summary>
        /// Enum indicating the Change Type for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        private enum ChangeType : uint
        {
            /// <summary>
            /// The large
            /// </summary>
            Large = 0,
            /// <summary>
            /// The small
            /// </summary>
            Small
        }

        /// <summary>
        /// Enum indicating the HitTest for <c><see cref="ZeroitMediaSlider" /></c>.
        /// </summary>
        public enum HitTest : uint
        {
            /// <summary>
            /// The nowhere
            /// </summary>
            Nowhere = 0,
            /// <summary>
            /// The button
            /// </summary>
            Button,
            /// <summary>
            /// The track
            /// </summary>
            Track
        }
        #endregion

        #region Structs
        /// <summary>
        /// Struct RECT
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RECT"/> struct.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <param name="y">The y.</param>
            /// <param name="right">The right.</param>
            /// <param name="bottom">The bottom.</param>
            public RECT(int x, int y, int right, int bottom)
            {
                this.Left = x;
                this.Top = y;
                this.Right = right;
                this.Bottom = bottom;
            }
            /// <summary>
            /// The left
            /// </summary>
            public int Left;
            /// <summary>
            /// The top
            /// </summary>
            public int Top;
            /// <summary>
            /// The right
            /// </summary>
            public int Right;
            /// <summary>
            /// The bottom
            /// </summary>
            public int Bottom;
        }
        #endregion

        #region API
        /// <summary>
        /// Gets the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr handle);

        /// <summary>
        /// Releases the dc.
        /// </summary>
        /// <param name="handle">The handle.</param>
        /// <param name="hdc">The HDC.</param>
        /// <returns>System.Int32.</returns>
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        /// <summary>
        /// Bits the BLT.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="nXDest">The n x dest.</param>
        /// <param name="nYDest">The n y dest.</param>
        /// <param name="nWidth">Width of the n.</param>
        /// <param name="nHeight">Height of the n.</param>
        /// <param name="hdcSrc">The HDC source.</param>
        /// <param name="nXSrc">The n x source.</param>
        /// <param name="nYSrc">The n y source.</param>
        /// <param name="dwRop">The dw rop.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        /// <summary>
        /// Validates the rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpRect">The lp rect.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool ValidateRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// Gets the client rect.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="r">The r.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, ref RECT r);

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// Screens to client.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpPoint">The lp point.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

        /// <summary>
        /// Pts the in rect.
        /// </summary>
        /// <param name="lprc">The LPRC.</param>
        /// <param name="pt">The pt.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool PtInRect(ref RECT lprc, Point pt);
        #endregion

        #region Fields
        /// <summary>
        /// The b has initialized
        /// </summary>
        private bool _bHasInitialized = false;
        /// <summary>
        /// The b pulse timer on
        /// </summary>
        private bool _bPulseTimerOn = false;
        /// <summary>
        /// The b animated
        /// </summary>
        private bool _bAnimated = false;
        /// <summary>
        /// The b smooth scrolling
        /// </summary>
        private bool _bSmoothScrolling = false;
        /// <summary>
        /// The b track shadow
        /// </summary>
        private bool _bTrackShadow = false;
        /// <summary>
        /// The b show button on hover
        /// </summary>
        private bool _bShowButtonOnHover = false;
        /// <summary>
        /// The b in target
        /// </summary>
        private bool _bInTarget = false;
        /// <summary>
        /// The b property initialize
        /// </summary>
        private bool _bPropInit = false;
        /// <summary>
        /// The b finished property run
        /// </summary>
        private bool _bFinishedPropRun = false;
        /// <summary>
        /// The i large change
        /// </summary>
        private int _iLargeChange = 0;
        /// <summary>
        /// The i maximum
        /// </summary>
        private int _iMaximum = 10;
        /// <summary>
        /// The i minimum
        /// </summary>
        private int _iMinimum = 0;
        /// <summary>
        /// The i small change
        /// </summary>
        private int _iSmallChange = 0;
        /// <summary>
        /// The i value
        /// </summary>
        private int _iValue = 0;
        /// <summary>
        /// The i track depth
        /// </summary>
        private int _iTrackDepth = 6;
        /// <summary>
        /// The i button corner radius
        /// </summary>
        private int _iButtonCornerRadius = 4;
        /// <summary>
        /// The i track padding
        /// </summary>
        private int _iTrackPadding = 2;
        /// <summary>
        /// The i tick maximum length
        /// </summary>
        private int _iTickMaxLength = 4;
        /// <summary>
        /// The i tick minimum padding
        /// </summary>
        private int _iTickMinPadding = 2;
        /// <summary>
        /// The i fly out maximum depth
        /// </summary>
        private int _iFlyOutMaxDepth = 16;
        /// <summary>
        /// The i fly out maximum width
        /// </summary>
        private int _iFlyOutMaxWidth = 12;
        /// <summary>
        /// The i fly out spacer
        /// </summary>
        private int _iFlyOutSpacer = 6;
        /// <summary>
        /// The i line position
        /// </summary>
        private int _iLinePos = 0;
        /// <summary>
        /// The d button position
        /// </summary>
        private double _dButtonPosition = 0;
        /// <summary>
        /// The f animation size
        /// </summary>
        private float _fAnimationSize = .1f;

        /// <summary>
        /// The color button accent color
        /// </summary>
        private Color _clrButtonAccentColor = Color.FromArgb(128, 64, 64, 64);
        /// <summary>
        /// The color button border color
        /// </summary>
        private Color _clrButtonBorderColor = Color.Black;
        /// <summary>
        /// The color button color
        /// </summary>
        private Color _clrButtonColor = Color.FromArgb(160, 0, 0, 0);
        /// <summary>
        /// The color back color
        /// </summary>
        private Color _clrBackColor = Color.Black;
        /// <summary>
        /// The color track border color
        /// </summary>
        private Color _clrTrackBorderColor = Color.FromArgb(160, Color.White);
        /// <summary>
        /// The color track fill color
        /// </summary>
        private Color _clrTrackFillColor = Color.Transparent;
        /// <summary>
        /// The color track progress color
        /// </summary>
        private Color _clrTrackProgressColor = Color.FromArgb(5, 101, 188);
        /// <summary>
        /// The color tick color
        /// </summary>
        private Color _clrTickColor = Color.DarkGray;
        /// <summary>
        /// The color track shadow color
        /// </summary>
        private Color _clrTrackShadowColor = Color.DarkGray;

        /// <summary>
        /// The sz button size
        /// </summary>
        private Size _szButtonSize = new Size(14, 14);
        /// <summary>
        /// The sz minimum size
        /// </summary>
        private Size _szMinSize = new Size(0, 0);
        /// <summary>
        /// The sz maximum size
        /// </summary>
        private Size _szMaxSize = new Size(0, 0);
        /// <summary>
        /// The e button style
        /// </summary>
        private ButtonType _eButtonStyle = ButtonType.Round;
        /// <summary>
        /// The e track style
        /// </summary>
        private TrackType _eTrackStyle = TrackType.Value;
        /// <summary>
        /// The e slider state
        /// </summary>
        private SliderSelectedState _eSliderState = SliderSelectedState.None;
        /// <summary>
        /// The e orientation
        /// </summary>
        private Orientation _eOrientation = Orientation.Horizontal;
        /// <summary>
        /// The e tick type
        /// </summary>
        private TickMode _eTickType = TickMode.Standard;
        /// <summary>
        /// The e tick style
        /// </summary>
        private TickStyle _eTickStyle = TickStyle.None;
        /// <summary>
        /// The e fly out on focus
        /// </summary>
        private FlyOutStyle _eFlyOutOnFocus = FlyOutStyle.None;
        /// <summary>
        /// The e animation speed
        /// </summary>
        private AnimateSpeed _eAnimationSpeed = AnimateSpeed.Normal;

        /// <summary>
        /// The track rect
        /// </summary>
        private RECT _trackRect;
        /// <summary>
        /// The button rect
        /// </summary>
        private RECT _buttonRect;

        /// <summary>
        /// The BMP background
        /// </summary>
        private Bitmap _bmpBackground;
        /// <summary>
        /// The BMP button
        /// </summary>
        private Bitmap _bmpButton;
        /// <summary>
        /// The BMP sprite
        /// </summary>
        private Bitmap _bmpSprite;
        /// <summary>
        /// The c pulse timer
        /// </summary>
        private FadeTimer _cPulseTimer;
        /// <summary>
        /// The c control dc
        /// </summary>
        private cStoreDc _cControlDc;
        /// <summary>
        /// The c track dc
        /// </summary>
        private cStoreDc _cTrackDc;
        /// <summary>
        /// The c animation dc
        /// </summary>
        private cStoreDc _cAnimationDc;
        /// <summary>
        /// The error handler
        /// </summary>
        private ErrorProvider ErrorHandler;

        /// <summary>
        /// Delegate ResetCallback
        /// </summary>
        private delegate void ResetCallback();
        /// <summary>
        /// Delegate FlyOutInfoDelegate
        /// </summary>
        /// <param name="data">The data.</param>
        public delegate void FlyOutInfoDelegate(ref string data);

        /// <summary>
        /// Occurs when [fly out information].
        /// </summary>
        [Description("Callback event for the FlyOut window")]
        public event FlyOutInfoDelegate FlyOutInfo;
        #endregion

        #region Events and Delegates
        /// <summary>
        /// Delegate ValueChangedDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ValueChangedDelegate(Object sender, EventArgs e);
        /// <summary>
        /// Delegate ScrollDelegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void ScrollDelegate(Object sender, EventArgs e);
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        [Description("Raised when the Slider Value property changes")]
        public event ValueChangedDelegate ValueChanged;
        /// <summary>
        /// Occurs when [scrolled].
        /// </summary>
        [Description("Raised when the mSlider has scrolled.")]
        public event ScrollDelegate Scrolled;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMediaSlider"/> class.
        /// </summary>
        public ZeroitMediaSlider()
        {
            Init();
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);


        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Init()
        {
            CreateGraphicsObjects();
            _bHasInitialized = true;

            if (this.DesignMode)
            {
                ErrorHandler = new ErrorProvider();
                this.Minimum = 0;
                this.Maximum = 10;
                this.SmallChange = 1;
                this.LargeChange = 2;
            }
            _clrBackColor = Color.FromKnownColor(KnownColor.Control);
        }
        #endregion

        #region Destructor
        /// <summary>
        /// Des the initialize.
        /// </summary>
        private void DeInit()
        {
            _bHasInitialized = false;
            DestroyGraphicsObjects();
            if (ErrorHandler != null)
                ErrorHandler.Dispose();
        }

        /// <summary>
        /// Releases all resources used by the <see cref="T:System.ComponentModel.Component" />.
        /// </summary>
        public void Dispose()
        {
            DeInit();
        }
        #endregion

        #region Properties

        #region Hidden Properties        
        /// <summary>
        /// Gets or sets a value indicating whether the control can accept data that the user drags onto it.
        /// </summary>
        /// <value><c>true</c> if allow drop; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public new bool AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; }
        }

        /// <summary>
        /// Gets or sets the edges of the container to which a control is bound and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The anchor.</value>
        [Browsable(false)]
        public new AnchorStyles Anchor
        {
            get { return base.Anchor; }
            set { base.Anchor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <value><c>true</c> if automatic scroll; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public new bool AutoScroll
        {
            get { return base.AutoScroll; }
            set { base.AutoScroll = value; }
        }

        /// <summary>
        /// Gets or sets the size of the auto-scroll margin.
        /// </summary>
        /// <value>The automatic scroll margin.</value>
        [Browsable(false)]
        public new Size AutoScrollMargin
        {
            get { return base.AutoScrollMargin; }
            set { base.AutoScrollMargin = value; }
        }

        /// <summary>
        /// Gets or sets the minimum size of the auto-scroll.
        /// </summary>
        /// <value>The minimum size of the automatic scroll.</value>
        [Browsable(false)]
        public new Size AutoScrollMinSize
        {
            get { return base.AutoScrollMinSize; }
            set { base.AutoScrollMinSize = value; }
        }

        /// <summary>
        /// Gets or sets how the control will resize itself.
        /// </summary>
        /// <value>The automatic size mode.</value>
        [Browsable(false)]
        public new AutoSizeMode AutoSizeMode
        {
            get { return base.AutoSizeMode; }
            set { base.AutoSizeMode = value; }
        }

        /// <summary>
        /// Gets or sets how the control performs validation when the user changes focus to another control.
        /// </summary>
        /// <value>The automatic validate.</value>
        [Browsable(false)]
        public new AutoValidate AutoValidate
        {
            get { return base.AutoValidate; }
            set { base.AutoValidate = value; }
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout" /> enumeration.
        /// </summary>
        /// <value>The background image layout.</value>
        [Browsable(false)]
        public new ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Forms.ContextMenuStrip" /> associated with this control.
        /// </summary>
        /// <value>The context menu strip.</value>
        [Browsable(false)]
        public new ContextMenu ContextMenuStrip
        {
            get { return base.ContextMenu; }
            set { base.ContextMenu = value; }
        }

        /// <summary>
        /// Gets or sets which control borders are docked to its parent control and determines how a control is resized with its parent.
        /// </summary>
        /// <value>The dock.</value>
        [Browsable(false)]
        public new DockStyle Dock
        {
            get { return base.Dock; }
            set { base.Dock = value; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value>The font.</value>
        [Browsable(false)]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Browsable(false)]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        /// <value>The right to left.</value>
        [Browsable(false)]
        public new RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }

        /// <summary>
        /// Gets or sets padding within the control.
        /// </summary>
        /// <value>The padding.</value>
        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }
        #endregion

        #region Private Properties
        /// <summary>
        /// Gets or sets the track padding.
        /// </summary>
        /// <value>The track padding.</value>
        private int TrackPadding
        {
            get { return _iTrackPadding; }
            set { _iTrackPadding = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [finished property run].
        /// </summary>
        /// <value><c>true</c> if [finished property run]; otherwise, <c>false</c>.</value>
        private bool FinishedPropRun
        {
            get { return _bFinishedPropRun; }
            set { _bFinishedPropRun = value; }
        }

        /// <summary>
        /// Gets or sets the maximum width of the fly out.
        /// </summary>
        /// <value>The maximum width of the fly out.</value>
        private int FlyOutMaxWidth
        {
            get { return _iFlyOutMaxWidth; }
            set { _iFlyOutMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets the fly out maximum depth.
        /// </summary>
        /// <value>The fly out maximum depth.</value>
        private int FlyOutMaxDepth
        {
            get { return _iFlyOutMaxDepth; }
            set { _iFlyOutMaxDepth = value; }
        }

        /// <summary>
        /// Gets or sets the fly out spacer.
        /// </summary>
        /// <value>The fly out spacer.</value>
        private int FlyOutSpacer
        {
            get { return _iFlyOutSpacer; }
            set { _iFlyOutSpacer = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [in target].
        /// </summary>
        /// <value><c>true</c> if [in target]; otherwise, <c>false</c>.</value>
        private bool InTarget
        {
            get { return _bInTarget; }
            set { _bInTarget = value; }
        }

        /// <summary>
        /// Gets or sets the maximum length of the tick.
        /// </summary>
        /// <value>The maximum length of the tick.</value>
        private int TickMaxLength
        {
            get { return _iTickMaxLength; }
            set { _iTickMaxLength = value; }
        }

        /// <summary>
        /// Gets or sets the tick minimum padding.
        /// </summary>
        /// <value>The tick minimum padding.</value>
        private int TickMinPadding
        {
            get { return _iTickMinPadding; }
            set { _iTickMinPadding = value; }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Run the animation effect when focused
        /// </summary>
        /// <value><c>true</c> if animated; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Appearence"),
        Description("Run the animation effect when focused")]
        public bool Animated
        {
            get { return _bAnimated; }
            set
            {
                _bAnimated = value;
                if (!this.DesignMode)
                {
                    if (this.Focused && _bAnimated)
                        StartPulseTimer();
                    else
                        StopPulseTimer();
                    DrawSlider();
                }
            }
        }

        /// <summary>
        /// Animation cycle speed
        /// </summary>
        /// <value>The animation speed.</value>
        [Browsable(true), Category("Appearence"),
        Description("Animation cycle speed")]
        public AnimateSpeed AnimationSpeed
        {
            get { return _eAnimationSpeed; }
            set { _eAnimationSpeed = value; }
        }

        /// <summary>
        /// Percentage of size of sprite height/width to track height/width [min .05 - max .2]
        /// </summary>
        /// <value>The size of the animation.</value>
        [Browsable(false),
        Description("Percentage of size of sprite width to track width [min .05 - max .2]")]
        public float AnimationSize
        {
            get { return _fAnimationSize; }
            set
            {
                if (value < .02f)
                    _fAnimationSize = .02f;
                else if (value < .2f)
                    _fAnimationSize = .2f;
                else
                    _fAnimationSize = value;
            }
        }

        /// <summary>
        /// Use an image for the slider background
        /// </summary>
        /// <value>The background image.</value>
        /// <exception cref="Exception">Invalid BackGroundImage Property Setting: Invalid image type. Base of image must be a Bitmap</exception>
        [Browsable(true), Category("Appearence"),
        Description("Use an image for the slider background")]
        public new Bitmap BackgroundImage
        {
            get { return _bmpBackground; }
            set
            {
                try
                {
                    if (value != null && value.GetType() == typeof(Bitmap))
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        _bmpBackground = value;
                        base.Width = _bmpBackground.Width;
                        base.Height = _bmpBackground.Height;
                        PropertyChange();
                    }
                    else if (value != null && this.DesignMode)
                    {
                        throw new Exception("Invalid BackGroundImage Property Setting: Invalid image type. Base of image must be a Bitmap");
                    }
                    else if (value == null)
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        if (_bmpBackground != null)
                            _bmpBackground.Dispose();
                        _bmpBackground = null;
                    }
                }
                catch (Exception ex) { this.ErrorHandler.SetError(this, ex.Message); }
            }
        }

        /// <summary>
        /// Modify button accent color
        /// </summary>
        /// <value>The color of the button accent.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify button accent color")]
        public Color ButtonAccentColor
        {
            get { return _clrButtonAccentColor; }
            set
            {
                _clrButtonAccentColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Modify button border color
        /// </summary>
        /// <value>The color of the button border.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify button border color")]
        public Color ButtonBorderColor
        {
            get { return _clrButtonBorderColor; }
            set
            {
                _clrButtonBorderColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Modify button base color
        /// </summary>
        /// <value>The color of the button.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify button base color")]
        public Color ButtonColor
        {
            get { return _clrButtonColor; }
            set
            {
                _clrButtonColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Adjusts the slider buttons corner radius
        /// </summary>
        /// <value>The button corner radius.</value>
        [Browsable(false),
        Description("Adjusts the slider buttons corner radius")]
        public uint ButtonCornerRadius
        {
            get { return (uint)_iButtonCornerRadius; }
            set { _iButtonCornerRadius = (int)value; }
        }

        /// <summary>
        /// Modify slider button size
        /// </summary>
        /// <value>The size of the button.</value>
        [Browsable(true), Category("Appearence"), RefreshProperties(RefreshProperties.All),
        Description("Modify slider button size")]
        public Size ButtonSize
        {
            get { return _szButtonSize; }
            set
            {
                _szButtonSize = value;
                if (this.DesignMode && !this.AutoSize)
                    PropertyChange();
            }
        }

        /// <summary>
        /// Set the button style
        /// </summary>
        /// <value>The button style.</value>
        [Browsable(true), Category("Appearence"), RefreshProperties(RefreshProperties.All),
        Description("Set the button style")]
        public ButtonType ButtonStyle
        {
            get { return _eButtonStyle; }
            set
            {

                if (this.FinishedPropRun && this.DesignMode && _eButtonStyle != value)
                {
                    _eButtonStyle = value;
                    DefaultButtonSize(_eButtonStyle);
                }
                else
                {
                    _eButtonStyle = value;
                }
                PropertyChange();
            }
        }

        /// <summary>
        /// Returns the property initiated state
        /// </summary>
        /// <value><c>true</c> if this instance is inited; otherwise, <c>false</c>.</value>
        [Browsable(false),
        Description("Returns the property initiated state")]
        public bool IsInited
        {
            get { return this.Visible && _bPropInit; }
            private set { _bPropInit = this.Visible && value; }
        }

        /// <summary>
        /// The number of clicks the slider moves in response to mouse clicks or pageup/pagedown
        /// </summary>
        /// <value>The large change.</value>
        /// <exception cref="Exception">Invalid LargeChange Property Setting: Large change can not be less then 1</exception>
        [Browsable(true), Category("Behavior"),
        Description("The number of clicks the slider moves in response to mouse clicks or pageup/pagedown")]
        public int LargeChange
        {
            get { return _iLargeChange; }
            set
            {
                try
                {
                    if (value < 1 && this.DesignMode && this.FinishedPropRun)
                    {
                        throw new Exception("Invalid LargeChange Property Setting: Large change can not be less then 1");
                    }
                    else
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        _iLargeChange = value;
                        PropertyChange();
                    }
                }
                catch (Exception ex) { this.ErrorHandler.SetError(this, ex.Message); }
            }
        }

        /// <summary>
        /// The maximum value for the position of the slider
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="Exception">Invalid Maximum Property Setting: Maximum can not be less then the Minimum value setting</exception>
        [Browsable(true), Category("Behavior"),
        Description("The maximum value for the position of the slider")]
        public int Maximum
        {
            get { return _iMaximum; }
            set
            {
                try
                {
                    if (value <= this.Minimum && this.FinishedPropRun)
                    {
                        if (this.DesignMode)
                            throw new Exception("Invalid Maximum Property Setting: Maximum can not be less then the Minimum value setting");
                    }
                    else
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        _iMaximum = value;
                        PropertyChange();
                    }
                }
                catch (Exception ex) { this.ErrorHandler.SetError(this, ex.Message); }
                finally
                {
                    if (!this.DesignMode)
                        SliderFlyOut = _eFlyOutOnFocus;
                }
            }
        }

        /// <summary>
        /// The maximum Size value for the control
        /// </summary>
        /// <value>The maximum size.</value>
        [Browsable(true), Category("Behavior"),
        Description("The maximum Size value for the control [private set]")]
        public Size MaxSize
        {
            get { return _szMaxSize; }
            private set { _szMaxSize = value; }
        }

        /// <summary>
        /// The minimum value for the position of the slider
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="Exception">Invalid Minimum Property Setting: Minimum can not be more then the Maximum value setting</exception>
        [Browsable(true), Category("Behavior"),
        Description("The minimum value for the position of the slider")]
        public int Minimum
        {
            get { return _iMinimum; }
            set
            {
                try
                {
                    if (value >= this.Maximum && this.FinishedPropRun)
                    {
                        if (this.DesignMode)
                            throw new Exception("Invalid Minimum Property Setting: Minimum can not be more then the Maximum value setting");
                    }
                    else
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        _iMinimum = value;
                        PropertyChange();
                    }
                }
                catch (Exception ex) { this.ErrorHandler.SetError(this, ex.Message); }
            }
        }

        /// <summary>
        /// The minimum Size value for the control
        /// </summary>
        /// <value>The minimum size.</value>
        [Browsable(true), Category("Behavior"),
        Description("The minimum Size value for the control [private set]")]
        public Size MinSize
        {
            get { return _szMinSize; }
            private set { _szMinSize = value; }
        }

        /// <summary>
        /// The orientation of the control
        /// </summary>
        /// <value>The orientation.</value>
        [Browsable(true), Category("Appearence"), RefreshProperties(RefreshProperties.All),
        Description("The orientation of the control")]
        public Orientation Orientation
        {
            get { return _eOrientation; }
            set
            {
                _eOrientation = value;
                if (this.FinishedPropRun && this.DesignMode && _eOrientation != value)
                {
                    _eOrientation = value;
                    DefaultButtonSize(_eButtonStyle);
                }
                else
                {
                    _eOrientation = value;
                }
                PropertyChange();
            }
        }

        /// <summary>
        /// Returns the slider position to a floating point, requires SmoothScrolling set to true
        /// </summary>
        /// <value>The precision value.</value>
        [Browsable(false),
        Description("Returns the slider position to a floating point, requires SmoothScrolling set to true")]
        public double PrecisionValue
        {
            get { return IncrementalValue(); }
        }

        /// <summary>
        /// Show the slider button only when control is focused or mouse is hovering
        /// </summary>
        /// <value><c>true</c> if [show button on hover]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Appearence"),
        Description("Show the slider button only when control is focused or mouse is hovering")]
        public bool ShowButtonOnHover
        {
            get { return _bShowButtonOnHover; }
            set { _bShowButtonOnHover = value; }
        }

        /// <summary>
        /// Enable the flyout caption window
        /// </summary>
        /// <value>The slider fly out.</value>
        [Browsable(true), Category("Appearence"),
        Description("Enable the flyout caption window")]
        public FlyOutStyle SliderFlyOut
        {
            get { return _eFlyOutOnFocus; }
            set
            {
                _eFlyOutOnFocus = value;
                if (_eFlyOutOnFocus != FlyOutStyle.None)
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        this.FlyOutMaxDepth = 14;
                        this.FlyOutSpacer = 6;
                        if (this.Maximum < 10)
                        {
                            this.FlyOutMaxWidth = 10;
                            this.TrackPadding = 4;
                        }
                        else if (this.Maximum < 100)
                        {
                            this.FlyOutMaxWidth = 20;
                            this.TrackPadding = 6;
                        }
                        else if (this.Maximum < 1000)
                        {
                            this.FlyOutMaxWidth = 30;
                            this.TrackPadding = 12;
                        }
                        else if (this.Maximum > 999)
                        {
                            // probably time
                            this.FlyOutMaxWidth = 54;
                            this.TrackPadding = 24;
                        }
                    }
                    else
                    {
                        if (this.Minimum < 0)
                        {
                            // max 2 digit vertical
                            this.FlyOutSpacer = 2;
                            this.FlyOutMaxDepth = 30;
                            this.FlyOutMaxWidth = 20;
                            this.TrackPadding = 12;
                        }
                        else
                        {
                            // max 2 digit vertical
                            this.FlyOutSpacer = 2;
                            this.FlyOutMaxDepth = 20;
                            this.FlyOutMaxWidth = 18;
                            this.TrackPadding = 5;
                        }
                    }
                }
                else
                {
                    this.FlyOutMaxDepth = 0;
                    this.TrackPadding = 2;
                }
                PropertyChange();
            }
        }

        /// <summary>
        /// The number of positions the slider movers in response to arrow keys
        /// </summary>
        /// <value>The small change.</value>
        /// <exception cref="Exception">Invalid SmallChange Property Setting: Small change can not be less then 1</exception>
        [Browsable(true), Category("Behavior"),
        Description("The number of positions the slider movers in response to arrow keys")]
        public int SmallChange
        {
            get { return _iSmallChange; }
            set
            {
                try
                {
                    if (value < 1 && this.DesignMode && this.FinishedPropRun)
                    {
                        throw new Exception("Invalid SmallChange Property Setting: Small change can not be less then 1");
                    }
                    else
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        _iSmallChange = value;
                        PropertyChange();
                    }
                }
                catch (Exception ex) { this.ErrorHandler.SetError(this, ex.Message); }
            }
        }

        /// <summary>
        /// Run the animation effect when focused
        /// </summary>
        /// <value><c>true</c> if [smooth scrolling]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Behavior"),
        Description("Enable smooth scrolling style")]
        public bool SmoothScrolling
        {
            get { return _bSmoothScrolling; }
            set { _bSmoothScrolling = value; }
        }

        /// <summary>
        /// Modify slider tick color
        /// </summary>
        /// <value>The color of the tick.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify slider tick color")]
        public Color TickColor
        {
            get { return _clrTickColor; }
            set
            {
                _clrTickColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Select the tickstyle
        /// </summary>
        /// <value>The tick style.</value>
        [Browsable(true), Category("Appearence"),
        Description("Select the tickstyle")]
        public TickStyle TickStyle
        {
            get { return _eTickStyle; }
            set
            {
                _eTickStyle = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Select the tick drawing style
        /// </summary>
        /// <value>The type of the tick.</value>
        [Browsable(true), Category("Appearence"),
        Description("Select the tick drawing style")]
        public TickMode TickType
        {
            get { return _eTickType; }
            set
            {
                _eTickType = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Modify slider border color
        /// </summary>
        /// <value>The color of the track border.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify slider border color")]
        public Color TrackBorderColor
        {
            get { return _clrTrackBorderColor; }
            set
            {
                _clrTrackBorderColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Adjust the slider track depth
        /// </summary>
        /// <value>The track depth.</value>
        [Browsable(true), Category("Appearence"), RefreshProperties(RefreshProperties.All),
        Description("Adjust the slider track depth")]
        public int TrackDepth
        {
            get { return _iTrackDepth; }
            set
            {
                _iTrackDepth = value;
                if (this.DesignMode && !this.AutoSize)
                    PropertyChange();
            }
        }

        /// <summary>
        /// Set the track fill color
        /// </summary>
        /// <value>The color of the track fill.</value>
        [Browsable(true), Category("Appearence"),
        Description("Set the track fill color")]
        public Color TrackFillColor
        {
            get { return _clrTrackFillColor; }
            set
            {
                _clrTrackFillColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Set the track progress color
        /// </summary>
        /// <value>The color of the track progress.</value>
        [Browsable(true), Category("Appearence"),
        Description("Set the track progress color")]
        public Color TrackProgressColor
        {
            get { return _clrTrackProgressColor; }
            set
            {
                _clrTrackProgressColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Enable track border shadow
        /// </summary>
        /// <value><c>true</c> if [track shadow]; otherwise, <c>false</c>.</value>
        [Browsable(true), Category("Appearence"),
        Description("Enable track shadow")]
        public bool TrackShadow
        {
            get { return _bTrackShadow; }
            set
            {
                _bTrackShadow = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Modify track shadow color
        /// </summary>
        /// <value>The color of the track shadow.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify track shadow color")]
        public Color TrackShadowColor
        {
            get { return _clrTrackShadowColor; }
            set
            {
                _clrTrackShadowColor = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// Modify the display style of track
        /// </summary>
        /// <value>The track style.</value>
        [Browsable(true), Category("Appearence"),
        Description("Modify the display style of track")]
        public TrackType TrackStyle
        {
            get { return _eTrackStyle; }
            set
            {
                _eTrackStyle = value;
                PropertyChange();
            }
        }

        /// <summary>
        /// The position of the slider
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="Exception">
        /// Invalid Value Property Setting: Value can not be more then Maximum setting
        /// or
        /// Invalid Value Property Setting: Value can not be less then Minimum setting
        /// </exception>
        [Browsable(true), Category("Behavior"),
        Description("The position of the slider")]
        public int Value
        {
            get { return _iValue; }
            set
            {
                this.IsInited = !this.DesignMode;
                try
                {
                    if (value > this.Maximum)
                    {
                        if (this.DesignMode && this.FinishedPropRun)
                            throw new Exception("Invalid Value Property Setting: Value can not be more then Maximum setting");
                        else
                            _iValue = this.Maximum;
                    }
                    else if (value < this.Minimum)
                    {
                        if (this.DesignMode && this.FinishedPropRun)
                            throw new Exception("Invalid Value Property Setting: Value can not be less then Minimum setting");
                        else
                            _iValue = this.Minimum;
                    }
                    else
                    {
                        if (this.ErrorHandler != null)
                            this.ErrorHandler.Clear();
                        _iValue = value;
                    }

                    if (this.DesignMode)
                        _dButtonPosition = IncrementalValue();

                    if (!this.FinishedPropRun)
                    {
                        PropertyChange();
                        this.FinishedPropRun = true;
                    }
                    else if (!this.DesignMode)
                    {
                        _dButtonPosition = IncrementalValue();
                        if (ValueChanged != null)
                            ValueChanged(this, new EventArgs());
                        DrawSlider();
                    }
                }
                catch (Exception ex) { this.ErrorHandler.SetError(this, ex.Message); }
            }
        }
        #endregion
        #endregion

        #region Overrides
        /// <summary>
        /// Raises the CreateControl event.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            Init();
            base.OnHandleCreated(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleDestroyed" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            DeInit();
            base.OnHandleDestroyed(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_bHasInitialized)
                DrawSlider();
            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.BackColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnBackColorChanged(EventArgs e)
        {
            Init();
            base.OnBackColorChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            if (!this.InTarget)
            {
                _eSliderState = SliderSelectedState.Focused;
                DrawSlider();
            }
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            _eSliderState = SliderSelectedState.None;
            DrawSlider();
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseClick" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (SliderHitTest() == HitTest.Track)
                {
                    int pos;
                    if (Orientation == Orientation.Horizontal)
                        pos = e.X;
                    else
                        pos = e.Y;
                    if (this.SmoothScrolling)
                    {
                        ScrollThis(pos);
                    }
                    else
                    {
                        if (pos < IncrementalValue())
                            ScrollChange(ChangeType.Large, (Orientation == Orientation.Horizontal));
                        else
                            ScrollChange(ChangeType.Large, (Orientation != Orientation.Horizontal));
                    }
                }
            }
            base.OnMouseClick(e);
        }

        /// <summary>
        /// Handles the <see cref="E:MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.InTarget = (SliderHitTest() == HitTest.Button);
            if (this.InTarget)
                _eSliderState = SliderSelectedState.Pressed;
            else
                _eSliderState = SliderSelectedState.Focused;
            DrawSlider();
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseHover" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            _eSliderState = SliderSelectedState.Hover;
            DrawSlider();
            base.OnMouseHover(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _eSliderState = SliderSelectedState.Depressed;
            _bInTarget = false;
            DrawSlider();
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _eSliderState = SliderSelectedState.MouseLeave;
            DrawSlider();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _bInTarget)
            {
                if (Orientation == Orientation.Horizontal)
                    ScrollThis(e.X);
                else
                    ScrollThis(e.Y);
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Handles the <see cref="E:Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            PropertyChange();
            base.OnResize(e);
        }

        /// <summary>
        /// Processes the command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>true if the character was processed by the control; otherwise, false.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    ScrollChange(ChangeType.Small, true);
                    DrawSlider();
                    return true;
                case Keys.Right:
                    ScrollChange(ChangeType.Small, false);
                    DrawSlider();
                    return true;
                case Keys.Up:
                    ScrollChange(ChangeType.Small, false);
                    DrawSlider();
                    return true;
                case Keys.Down:
                    ScrollChange(ChangeType.Small, true);
                    DrawSlider();
                    return true;
                case Keys.Home:
                    this.Value = this.Minimum;
                    return true;
                case Keys.End:
                    this.Value = this.Maximum;
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Methods
        #region Graphics
        #region Drawing
        /// <summary>
        /// Drawing hub
        /// </summary>
        private void DrawSlider()
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            using (Graphics g = Graphics.FromHdc(_cControlDc.Hdc))
            {

                DrawTrack();
                if (this.SliderFlyOut == FlyOutStyle.Persistant)
                    DrawFlyOut(g);

                switch (_eSliderState)
                {
                    case SliderSelectedState.None:
                        {
                            if (_bPulseTimerOn)
                                StopPulseTimer();
                            if (!ShowButtonOnHover)
                                DrawButton(g, bounds, 1f);
                            break;
                        }
                    case SliderSelectedState.Disabled:
                        {
                            DrawButton(g, bounds, -1f);
                            break;
                        }
                    case SliderSelectedState.MouseLeave:
                        {
                            if (!ShowButtonOnHover || _bPulseTimerOn)
                            {
                                if (this.Focused)
                                    DrawButton(g, bounds, 1.2f);
                                else
                                    DrawButton(g, bounds, 1f);
                            }
                            break;
                        }
                    case SliderSelectedState.Hover:
                        {
                            if (this.SliderFlyOut == FlyOutStyle.OnFocus)
                                DrawFlyOut(g);
                            DrawButton(g, bounds, 1.2f);
                            break;
                        }
                    case SliderSelectedState.Depressed:
                    case SliderSelectedState.Focused:
                        {
                            if (!_bPulseTimerOn)
                            {
                                if (this.SliderFlyOut == FlyOutStyle.OnFocus)
                                    DrawFlyOut(g);
                                DrawButton(g, bounds, 1.2f);
                                if (this.Animated)
                                    StartPulseTimer();
                            }
                            else if (!this.InTarget)
                            {
                                DrawButton(g, bounds, 1.0f);
                            }
                            break;
                        }
                    case SliderSelectedState.Pressed:
                        {
                            if (_bPulseTimerOn)
                                StopPulseTimer();
                            if (this.SliderFlyOut == FlyOutStyle.OnFocus)
                                DrawFlyOut(g);
                            DrawButton(g, bounds, .9f);
                            break;
                        }
                }
            }

            if (!_bPulseTimerOn)
            {
                // draw buffer to control
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    BitBlt(g.GetHdc(), 0, 0, _cControlDc.Width, _cControlDc.Height, _cControlDc.Hdc, 0, 0, 0xCC0020);
                    g.ReleaseHdc();
                }
                RECT r = new RECT(0, 0, this.Width, this.Height);
                ValidateRect(this.Handle, ref r);
            }
        }

        /// <summary>
        /// Backfill the buffer
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawBackGround(Graphics g, Rectangle bounds)
        {
            using (Brush br = new SolidBrush(this.BackColor))
                g.FillRectangle(br, bounds);
        }

        /// <summary>
        /// Adjust gamma of an image [not used]
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="img">The img.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="gamma">The gamma.</param>
        private void DrawBrightImage(Graphics g, Image img, Rectangle bounds, float gamma)
        {
            try
            {
                using (Bitmap buttonImage = new Bitmap(img))
                {
                    using (ImageAttributes imageAttr = new ImageAttributes())
                    {
                        if (gamma > .9f)
                            gamma = .9f;
                        if (gamma < .2f)
                            gamma = .2f;
                        // raise gamma
                        imageAttr.SetGamma(gamma);
                        g.DrawImage(buttonImage,
                            bounds,
                            0, 0,
                            buttonImage.Width,
                            buttonImage.Height,
                            GraphicsUnit.Pixel,
                            imageAttr);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Draws the button.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="level">The level.</param>
        private void DrawButton(Graphics g, Rectangle bounds, float level)
        {
            Rectangle buttonRect = GetButtonRectangle();
            if (level != 1f)
            {
                using (ImageAttributes ia = new ImageAttributes())
                {
                    ColorMatrix cm = new ColorMatrix();
                    if (level == -1)
                    {
                        cm.Matrix00 = 1f;//r
                        cm.Matrix11 = 1f;//g
                        cm.Matrix22 = 1f;//b
                        cm.Matrix33 = .7f;//a
                        cm.Matrix44 = 1f;//w
                    }
                    else
                    {
                        cm.Matrix00 = level;
                        cm.Matrix11 = level;
                        cm.Matrix22 = level;
                        cm.Matrix33 = 1f;
                        cm.Matrix44 = 1f;
                    }
                    ia.SetColorMatrix(cm);
                    g.DrawImage(_bmpButton, buttonRect, 0, 0, _bmpButton.Width, _bmpButton.Height, GraphicsUnit.Pixel, ia);
                }
            }
            else
            {
                DrawImage(g, _bmpButton, buttonRect);
            }
        }

        /// <summary>
        /// Draw a disabled image using the control
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawDisabledImage(Graphics g, Image image, Rectangle bounds)
        {
            ControlPaint.DrawImageDisabled(g, image, bounds.X, bounds.Y, Color.Transparent);
        }

        /// <summary>
        /// Draw an unaltered image
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="image">The image.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawImage(Graphics g, Image image, Rectangle bounds)
        {
            g.DrawImage(image, bounds);
        }

        /// <summary>
        /// Draw the slider ticks
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        private void DrawTicks(Graphics g, Rectangle bounds)
        {
            Rectangle trackRect = GetTrackRectangle();
            float increment = (float)Increment();
            increment = (float)Increment();
            int count = (int)(IncrementScale());

            float endcap = (Orientation == Orientation.Horizontal ? (float)trackRect.Right - (1 + this.ButtonSize.Width / 2) : (float)trackRect.Bottom - (1 + this.ButtonSize.Height / 2));
            float offset = 0;
            int shadowlen = this.TickMaxLength - 1;
            int spacer = this.TickMaxLength + this.TickMinPadding;
            RectangleF buttonRect = GetButtonRectangle();

            switch (this.TickType)
            {
                #region Composite Style
                case TickMode.Composite:
                    {
                        using (GraphicsMode md = new GraphicsMode(g, SmoothingMode.None))
                        {
                            switch (this.TickStyle)
                            {
                                case TickStyle.Both:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;

                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, top), new PointF(val, top + this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, top + 1), new PointF(val + 1, top + shadowlen));
                                                        g.DrawLine(pn2, new PointF(val, bottom), new PointF(val, bottom - this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, bottom), new PointF(val + 1, bottom - shadowlen));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(val, top), new PointF(val, top + 2));
                                                        g.DrawLine(pn, new PointF(val, bottom), new PointF(val, bottom - 2));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(left, val), new PointF(left + this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(left + 1, val + 1), new PointF(left + shadowlen, val + 1));
                                                        g.DrawLine(pn2, new PointF(right, val), new PointF(right - this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(right, val + 1), new PointF(right - shadowlen, val + 1));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(left, val), new PointF(left + 2, val));
                                                        g.DrawLine(pn, new PointF(right, val), new PointF(right - 2, val));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.BottomRight:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, bottom), new PointF(val, bottom - this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, bottom), new PointF(val + 1, bottom - shadowlen));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(val, bottom), new PointF(val, bottom - 2));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(right, val), new PointF(right - this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(right, val + 1), new PointF(right - shadowlen, val + 1));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(right, val), new PointF(right - 2, val));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.TopLeft:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, top), new PointF(val, top + this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, top + 1), new PointF(val + 1, top + shadowlen));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(val, top), new PointF(val, top + 2));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(left, val), new PointF(left + this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(left + 1, val + 1), new PointF(left + shadowlen, val + 1));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(left, val), new PointF(left + 2, val));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region Large Stepped Style
                case TickMode.LargeStepped:
                    {
                        using (GraphicsMode md = new GraphicsMode(g, SmoothingMode.None))
                        {
                            switch (this.TickStyle)
                            {
                                case TickStyle.Both:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        val = (increment * i) + offset;
                                                        g.DrawLine(pn2, new PointF(val, top), new PointF(val, top + this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, top + 1), new PointF(val + 1, top + shadowlen));
                                                        g.DrawLine(pn2, new PointF(val, bottom), new PointF(val, bottom - this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, bottom), new PointF(val + 1, bottom - shadowlen));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        val = (increment * i) + offset;
                                                        g.DrawLine(pn2, new PointF(left, val), new PointF(left + this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(left + 1, val + 1), new PointF(left + shadowlen, val + 1));
                                                        g.DrawLine(pn2, new PointF(right, val), new PointF(right - this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(right, val + 1), new PointF(right - shadowlen, val + 1));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.BottomRight:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        val = (increment * i) + offset;
                                                        g.DrawLine(pn2, new PointF(val, bottom), new PointF(val, bottom - this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, bottom), new PointF(val + 1, bottom - shadowlen));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(right, val), new PointF(right - this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(right, val + 1), new PointF(right - shadowlen, val + 1));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.TopLeft:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, top), new PointF(val, top + this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, top + 1), new PointF(val + 1, top + shadowlen));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(left, val), new PointF(left + this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(left + 1, val + 1), new PointF(left + shadowlen, val + 1));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region Precision Style
                case TickMode.Precision:
                    {
                        using (GraphicsMode md = new GraphicsMode(g, SmoothingMode.None))
                        {
                            float split = increment * .5f;
                            bool valid = split > 2;
                            switch (this.TickStyle)
                            {
                                case TickStyle.Both:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;

                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, top), new PointF(val, top + this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, top + 1), new PointF(val + 1, top + shadowlen));
                                                        g.DrawLine(pn2, new PointF(val, bottom), new PointF(val, bottom - this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, bottom), new PointF(val + 1, bottom - shadowlen));
                                                        if (valid && val < endcap)
                                                        {
                                                            g.DrawLine(pn, new PointF(val + split, top), new PointF(val + split, top + 1));
                                                            g.DrawLine(pn, new PointF(val + split, bottom), new PointF(val + split, bottom - 1));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(val, top), new PointF(val, top + 2));
                                                        g.DrawLine(pn, new PointF(val, bottom), new PointF(val, bottom - 2));
                                                        if (valid && val < endcap)
                                                        {
                                                            g.DrawLine(pn, new PointF(val + split, top), new PointF(val + split, top + 1));
                                                            g.DrawLine(pn, new PointF(val + split, bottom), new PointF(val + split, bottom - 1));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(left, val), new PointF(left + this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(left + 1, val + 1), new PointF(left + shadowlen, val + 1));
                                                        g.DrawLine(pn2, new PointF(right, val), new PointF(right - this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(right, val + 1), new PointF(right - shadowlen, val + 1));
                                                        if (valid && val < endcap)
                                                        {
                                                            g.DrawLine(pn, new PointF(left, val + split), new PointF(left + 1, val + split));
                                                            g.DrawLine(pn, new PointF(right, val + split), new PointF(right - 1, val + split));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(left, val), new PointF(left + 2, val));
                                                        g.DrawLine(pn, new PointF(right, val), new PointF(right - 2, val));
                                                        if (valid && val < endcap)
                                                        {
                                                            g.DrawLine(pn, new PointF(left, val + split), new PointF(left + 1, val + split));
                                                            g.DrawLine(pn, new PointF(right, val + split), new PointF(right - 1, val + split));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.BottomRight:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, bottom), new PointF(val, bottom - this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, bottom), new PointF(val + 1, bottom - shadowlen));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(val + split, bottom), new PointF(val + split, bottom - 1));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(val, bottom), new PointF(val, bottom - 2));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(val + split, bottom), new PointF(val + split, bottom - 1));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(right, val), new PointF(right - this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(right, val + 1), new PointF(right - shadowlen, val + 1));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(right, val + split), new PointF(right - 2, val + split));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(right, val), new PointF(right - 2, val));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(right, val + split), new PointF(right - 2, val + split));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.TopLeft:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(val, top), new PointF(val, top + this.TickMaxLength));
                                                        g.DrawLine(pn3, new PointF(val + 1, top + 1), new PointF(val + 1, top + shadowlen));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(val + split, top), new PointF(val + split, top + 1));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(val, top), new PointF(val, top + 2));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(val + split, top), new PointF(val + split, top + 1));
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    if (Mod(i, this.LargeChange))
                                                    {
                                                        g.DrawLine(pn2, new PointF(left, val), new PointF(left + this.TickMaxLength, val));
                                                        g.DrawLine(pn3, new PointF(left + 1, val + 1), new PointF(left + shadowlen, val + 1));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(left, val + split), new PointF(left + 2, val + split));
                                                    }
                                                    else
                                                    {
                                                        g.DrawLine(pn, new PointF(left, val), new PointF(left + 2, val));
                                                        if (valid && val < endcap)
                                                            g.DrawLine(pn, new PointF(left, val + split), new PointF(left + 2, val + split));
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region Standard Tick Style
                case TickMode.Standard:
                    {
                        using (GraphicsMode md = new GraphicsMode(g, SmoothingMode.None))
                        {
                            switch (this.TickStyle)
                            {
                                case TickStyle.Both:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    g.DrawLine(pn, new PointF(val, top), new PointF(val, top + 2));
                                                    g.DrawLine(pn, new PointF(val, bottom), new PointF(val, bottom - 2));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    g.DrawLine(pn, new PointF(left, val), new PointF(left + 2, val));
                                                    g.DrawLine(pn, new PointF(right, val), new PointF(right - 2, val));
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.BottomRight:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float bottom = buttonRect.Bottom + spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    g.DrawLine(pn, new PointF(val, bottom), new PointF(val, bottom - 2));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float right = buttonRect.Right + spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    g.DrawLine(pn, new PointF(right, val), new PointF(right - 2, val));
                                                }
                                            }
                                        }
                                        break;
                                    }
                                case TickStyle.TopLeft:
                                    {
                                        if (this.Orientation == Orientation.Horizontal)
                                        {
                                            float top = buttonRect.Top - spacer;
                                            offset = (this.ButtonSize.Width / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    g.DrawLine(pn, new PointF(val, top), new PointF(val, top + 2));
                                                }
                                            }
                                        }
                                        else
                                        {
                                            float left = buttonRect.Left - spacer;
                                            offset = (this.ButtonSize.Height / 2) + this.TrackPadding;
                                            float val = offset;
                                            using (Pen pn = new Pen(this.TickColor, .5f), pn2 = new Pen(this.TickColor, 1f), pn3 = new Pen(Color.FromArgb(100, Color.DarkGray), 1f))
                                            {
                                                for (int i = 0; i < count + 1; i++)
                                                {
                                                    val = (increment * i) + offset;
                                                    g.DrawLine(pn, new PointF(left, val), new PointF(left + 2, val));
                                                }
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                    #endregion
            }
        }

        /// <summary>
        /// Draw slider and background dc
        /// </summary>
        private void DrawTrack()
        {
            BitBlt(_cControlDc.Hdc, 0, 0, _cTrackDc.Width, _cTrackDc.Height, _cTrackDc.Hdc, 0, 0, 0xCC0020);
            if (TrackStyle == TrackType.Progress)
            {
                Rectangle trackRect = GetTrackRectangle();
                Rectangle buttonRect = GetButtonRectangle();
                int length;

                trackRect.Inflate(-1, -1);
                if (Orientation == Orientation.Horizontal)
                {
                    if (_iValue == _iMinimum)
                    {
                        length = 0;
                    }
                    else if (_iValue == _iMaximum)
                    {
                        if (this.SmoothScrolling)
                        {
                            length = buttonRect.Right - (trackRect.Left + 1);
                            trackRect.Width = length;
                        }
                        else
                        {
                            length = buttonRect.Right - (trackRect.Left + 2);
                            trackRect.Width = length;
                        }
                    }
                    else
                    {
                        length = buttonRect.Right - (trackRect.Left + (int)(buttonRect.Width * .5f));
                        trackRect.Width = length;
                    }
                }
                else
                {
                    if (_iValue == _iMinimum)
                    {
                        length = 0;
                    }
                    else if (_iValue == _iMaximum)
                    {
                        if (this.SmoothScrolling)
                        {
                            length = trackRect.Bottom - (buttonRect.Top + 1);
                            trackRect.Y = buttonRect.Top - 1;
                            trackRect.Height = length;
                        }
                        else
                        {
                            length = trackRect.Bottom - (buttonRect.Top + 3);
                            trackRect.Height = length;
                        }
                    }
                    else
                    {
                        length = trackRect.Bottom - (buttonRect.Top + (int)(buttonRect.Height * .5f));
                        trackRect.Y = buttonRect.Top + (int)(buttonRect.Height * .5f) - 2;
                        trackRect.Height = length;
                    }
                }
                if (length > 1)
                {
                    using (Graphics g = Graphics.FromHdc(_cControlDc.Hdc))
                    {
                        using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                        {
                            using (GraphicsPath gp = CreateRoundRectanglePath(g, trackRect, 2))
                            {
                                using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                                    buttonRect,
                                    Color.FromArgb(120, Color.White),
                                    Color.FromArgb(250, this.TrackProgressColor),
                                    (Orientation == Orientation.Horizontal) ? LinearGradientMode.Vertical : LinearGradientMode.Horizontal))
                                {
                                    Blend blnd = new Blend();
                                    blnd.Positions = new float[] { 0f, .5f, 1f };
                                    blnd.Factors = new float[] { .5f, .7f, .3f };
                                    fillBrush.Blend = blnd;
                                    g.FillPath(fillBrush, gp);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Graphics Creation
        /// <summary>
        /// Create the button bitmap
        /// </summary>
        private void CreateButtonBitmap()
        {
            Rectangle buttonRect = GetButtonRectangle();
            float fx;
            float fy;

            buttonRect.X = 0;
            buttonRect.Y = 0;
            Rectangle accentRect = buttonRect;

            _bmpButton = new Bitmap(buttonRect.Width + 1, buttonRect.Height + 1);

            switch (this.ButtonStyle)
            {
                #region Precision
                case ButtonType.PointerUpRight:
                case ButtonType.PointerDownLeft:
                    {
                        using (Graphics g = Graphics.FromImage(_bmpButton))
                        {
                            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                            {
                                int offset = (int)(buttonRect.Height * .2);
                                buttonRect.Inflate(0, -offset);
                                buttonRect.Y = 0;

                                using (GraphicsPath gp = CreatePointedRectangularPath(g, buttonRect, PointDirection.Bottom, 3, offset * 2, -1))
                                {
                                    using (Brush br = new SolidBrush(Color.LightGray))
                                        g.FillPath(br, gp);
                                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                                        buttonRect,
                                        this.ButtonAccentColor,
                                        this.ButtonColor,
                                        LinearGradientMode.Horizontal))
                                    {
                                        Blend blnd = new Blend();
                                        blnd.Positions = new float[] { 0f, .5f, 1f };
                                        blnd.Factors = new float[] { .2f, .8f, .2f };
                                        fillBrush.Blend = blnd;
                                        g.FillPath(fillBrush, gp);
                                    }
                                    using (Pen borderPen = new Pen(Color.FromArgb(180, this.ButtonBorderColor), .5f))
                                        g.DrawPath(borderPen, gp);
                                }
                            }
                        }
                        if (this.ButtonStyle == ButtonType.PointerUpRight)
                        {
                            if (this.ButtonStyle == ButtonType.PointerUpRight)
                                _bmpButton.RotateFlip(RotateFlipType.Rotate180FlipX);
                        }
                        if (Orientation == Orientation.Vertical)
                            _bmpButton.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    }
                #endregion

                #region Round
                // round button style
                case ButtonType.Round:
                    {
                        using (Graphics g = Graphics.FromImage(_bmpButton))
                        {
                            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                            {
                                using (GraphicsPath gp = new GraphicsPath())
                                {
                                    gp.AddEllipse(buttonRect);
                                    // fill with base color
                                    using (Brush br = new SolidBrush(Color.FromArgb(255, this.ButtonColor)))
                                        g.FillPath(br, gp);
                                    // add top sheen
                                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                                        buttonRect,
                                        Color.FromArgb(180, Color.White),
                                        this.ButtonColor,
                                        LinearGradientMode.Vertical))
                                    {
                                        Blend blnd = new Blend();
                                        blnd.Positions = new float[] { 0f, .1f, .2f, .3f, .6f, 1f };
                                        blnd.Factors = new float[] { .2f, .3f, .4f, .5f, 1f, 1f };
                                        fillBrush.Blend = blnd;
                                        g.FillPath(fillBrush, gp);
                                    }
                                    // add the bottom glow
                                    using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                                    {
                                        using (GraphicsPath ga = new GraphicsPath())
                                        {
                                            accentRect.Inflate(0, (int)-(accentRect.Height * .2f));
                                            accentRect.Offset(0, (int)(ButtonSize.Width * .2f));
                                            ga.AddEllipse(accentRect);
                                            // center focus
                                            fx = accentRect.Width * .5f;
                                            fy = accentRect.Height * 1f;
                                            borderBrush.CenterColor = this.ButtonColor;
                                            borderBrush.SurroundColors = new Color[] { this.ButtonAccentColor };
                                            borderBrush.FocusScales = new PointF(1f, 0f);
                                            borderBrush.CenterPoint = new PointF(fx, fy);
                                            g.FillPath(borderBrush, ga);
                                        }
                                        // spotight offsets
                                        fx = buttonRect.Width * .2f;
                                        fy = buttonRect.Height * .05f;
                                        // draw the spotlight
                                        borderBrush.CenterColor = Color.FromArgb(120, Color.White);
                                        borderBrush.SurroundColors = new Color[] { Color.FromArgb(5, Color.Silver) };
                                        borderBrush.FocusScales = new PointF(.2f, .2f);
                                        borderBrush.CenterPoint = new PointF(fx, fy);
                                        g.FillPath(borderBrush, gp);
                                    }
                                    // draw the border
                                    using (Pen borderPen = new Pen(this.ButtonBorderColor, .5f))
                                        g.DrawPath(borderPen, gp);
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region Hybrid
                case ButtonType.Hybrid:
                    {
                        using (Graphics g = Graphics.FromImage(_bmpButton))
                        {
                            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                            {
                                using (GraphicsPath gp = new GraphicsPath())
                                {
                                    gp.AddEllipse(buttonRect);
                                    using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                                    {
                                        // center focus
                                        fx = buttonRect.Width * .5f;
                                        fy = buttonRect.Height * .5f;
                                        borderBrush.CenterColor = this.ButtonColor;
                                        borderBrush.SurroundColors = new Color[] { this.ButtonAccentColor };
                                        borderBrush.FocusScales = new PointF(.5f, .5f);
                                        borderBrush.CenterPoint = new PointF(fx, fy);
                                        g.FillPath(borderBrush, gp);

                                    }// draw the border
                                    using (Pen borderPen = new Pen(this.ButtonBorderColor, .5f))
                                        g.DrawPath(borderPen, gp);
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region Rounded Rectangle
                case ButtonType.RoundedRectInline:
                case ButtonType.RoundedRectOverlap:
                    {
                        using (Graphics g = Graphics.FromImage(_bmpButton))
                        {
                            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                            {
                                using (GraphicsPath gp = CreateRoundRectanglePath(g, buttonRect, this.ButtonCornerRadius))
                                {
                                    // fill with solid base color
                                    using (Brush br = new SolidBrush(Color.FromArgb(255, this.ButtonColor)))
                                        g.FillPath(br, gp);
                                    fx = buttonRect.Width * .5f;
                                    fy = buttonRect.Height * .5f;
                                    // add a shine
                                    LinearGradientMode md;
                                    if (Orientation == Orientation.Horizontal)
                                    {
                                        if (this.ButtonStyle == ButtonType.RoundedRectOverlap)
                                            md = LinearGradientMode.Horizontal;
                                        else
                                            md = LinearGradientMode.Vertical;
                                    }
                                    else
                                    {
                                        if (this.ButtonStyle == ButtonType.RoundedRectOverlap)
                                            md = LinearGradientMode.Vertical;
                                        else
                                            md = LinearGradientMode.Horizontal;
                                    }
                                    // draw it
                                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                                        buttonRect,
                                        Color.FromArgb(120, Color.White),
                                        Color.FromArgb(5, Color.Silver),
                                        md))
                                    {
                                        Blend blnd = new Blend();
                                        blnd.Positions = new float[] { 0f, .2f, .4f, .7f, .8f, 1f };
                                        blnd.Factors = new float[] { .2f, .4f, .5f, .4f, .2f, .1f };
                                        fillBrush.Blend = blnd;
                                        g.FillPath(fillBrush, gp);
                                    }
                                    // draw the border
                                    using (Pen borderPen = new Pen(Color.FromArgb(220, this.ButtonBorderColor), .5f))
                                        g.DrawPath(borderPen, gp);
                                    // add a spotlight underneath
                                    accentRect.Offset(0, (int)(accentRect.Height * .6f));
                                    // center focus
                                    if (Orientation == Orientation.Horizontal && this.ButtonStyle == ButtonType.RoundedRectOverlap
                                        || Orientation == Orientation.Vertical && this.ButtonStyle == ButtonType.RoundedRectInline)
                                    {

                                        fx = accentRect.Width * .1f;
                                        fy = accentRect.Height * .5f;
                                        // notch it down a little
                                        accentRect.Offset(0, (int)(accentRect.Height * .2f));
                                    }
                                    else
                                    {
                                        fx = accentRect.Width * .5f;
                                        fy = accentRect.Height * .1f;
                                    }

                                    using (GraphicsPath ga = new GraphicsPath())
                                    {
                                        ga.AddEllipse(accentRect);
                                        // draw bottom glow
                                        using (PathGradientBrush borderBrush = new PathGradientBrush(ga))
                                        {
                                            borderBrush.CenterColor = this.ButtonAccentColor;
                                            borderBrush.SurroundColors = new Color[] { Color.Transparent };
                                            borderBrush.FocusScales = new PointF(.1f, .2f);
                                            borderBrush.CenterPoint = new PointF(fx, fy);
                                            g.FillPath(borderBrush, ga);
                                        }
                                    }
                                    using (GraphicsPath ga = new GraphicsPath())
                                    {
                                        if (this.ButtonStyle == ButtonType.RoundedRectOverlap)
                                            ga.AddEllipse(0, 0, buttonRect.Width, 4);
                                        else
                                            ga.AddEllipse(2, 0, buttonRect.Width - 4, 4);
                                        // spotight offsets
                                        fx = buttonRect.Width * .5f;
                                        fy = buttonRect.Height * .05f;
                                        // draw the top spotlight
                                        using (PathGradientBrush borderBrush = new PathGradientBrush(ga))
                                        {
                                            borderBrush.CenterColor = Color.FromArgb(120, Color.White);
                                            borderBrush.SurroundColors = new Color[] { Color.FromArgb(5, Color.Silver) };
                                            borderBrush.FocusScales = new PointF(.2f, .2f);
                                            borderBrush.CenterPoint = new PointF(fx, fy);
                                            g.FillPath(borderBrush, gp);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                #endregion

                #region Glass
                case ButtonType.GlassInline:
                case ButtonType.GlassOverlap:
                    {
                        using (Graphics g = Graphics.FromImage(_bmpButton))
                        {
                            using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                            {
                                using (GraphicsPath gp = CreateRoundRectanglePath(g, buttonRect, this.ButtonCornerRadius))
                                {
                                    fx = buttonRect.Width * .5f;
                                    fy = buttonRect.Height * .5f;
                                    // add a shine
                                    using (PathGradientBrush borderBrush = new PathGradientBrush(gp))
                                    {
                                        borderBrush.CenterColor = Color.FromArgb(100, Color.DarkGray);
                                        borderBrush.SurroundColors = new Color[] { Color.FromArgb(120, Color.Silver) };
                                        borderBrush.FocusScales = new PointF(1f, .5f);
                                        borderBrush.CenterPoint = new PointF(fx, fy);
                                        g.FillPath(borderBrush, gp);
                                    }
                                    // draw the border
                                    using (Pen borderPen = new Pen(this.ButtonBorderColor, .5f))
                                        g.DrawPath(borderPen, gp);
                                    // add a spotlight underneath
                                    accentRect.Offset(0, (int)(accentRect.Height * .8f));
                                    // center focus
                                    if (Orientation == Orientation.Horizontal && this.ButtonStyle == ButtonType.RoundedRectOverlap
                                        || Orientation == Orientation.Vertical && this.ButtonStyle == ButtonType.RoundedRectInline)
                                    {

                                        fx = accentRect.Width * .05f;
                                        fy = accentRect.Height * .5f;
                                    }
                                    else
                                    {
                                        fx = accentRect.Width * .5f;
                                        fy = accentRect.Height * .05f;
                                    }
                                    using (GraphicsPath ga = new GraphicsPath())
                                    {
                                        ga.AddEllipse(accentRect);
                                        using (PathGradientBrush borderBrush = new PathGradientBrush(ga))
                                        {
                                            borderBrush.CenterColor = Color.FromArgb(120, this.ButtonAccentColor);
                                            borderBrush.SurroundColors = new Color[] { Color.FromArgb(5, Color.Silver) };
                                            borderBrush.FocusScales = new PointF(.2f, .2f);
                                            borderBrush.CenterPoint = new PointF(fx, fy);
                                            g.FillPath(borderBrush, ga);
                                        }
                                    }
                                    using (GraphicsPath ga = new GraphicsPath())
                                    {
                                        ga.AddEllipse(0, 0, buttonRect.Width, 4);
                                        // spotight offsets
                                        fx = buttonRect.Width * .5f;
                                        fy = buttonRect.Height * .05f;
                                        // draw the top spotlight
                                        using (PathGradientBrush borderBrush = new PathGradientBrush(ga))
                                        {
                                            borderBrush.CenterColor = Color.FromArgb(120, Color.White);
                                            borderBrush.SurroundColors = new Color[] { Color.FromArgb(5, Color.Silver) };
                                            borderBrush.FocusScales = new PointF(.2f, .2f);
                                            borderBrush.CenterPoint = new PointF(fx, fy);
                                            g.FillPath(borderBrush, gp);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                    #endregion
            }
            _bmpButton.MakeTransparent();
        }

        /// <summary>
        /// Create graphics objects
        /// </summary>
        private void CreateGraphicsObjects()
        {
            DestroyGraphicsObjects();
            // load primary buffer
            _cControlDc = new cStoreDc();
            _cControlDc.Height = this.Height;
            _cControlDc.Width = this.Width;
            // track and background dc
            _cTrackDc = new cStoreDc();
            _cTrackDc.Height = this.Height;
            _cTrackDc.Width = this.Width;
            // draw the track
            CreateTrack();
            // create the button image
            CreateButtonBitmap();
            // create the animation sprite
            CreateSprite();
        }

        /// <summary>
        /// create the animations sprite
        /// </summary>
        private void CreateSprite()
        {
            Rectangle trackRect = GetTrackRectangle();
            int width = (int)(Orientation == Orientation.Horizontal ? trackRect.Width * .1f : trackRect.Height * .1f);
            int height = this.TrackDepth;

            DestroySprite();
            // draw the line sprite into a bmp
            _bmpSprite = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(_bmpSprite))
            {
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                {
                    g.CompositingMode = CompositingMode.SourceOver;
                    Rectangle imageRect = new Rectangle(0, 0, width, height);
                    // draw sprite
                    using (LinearGradientBrush fillBrush = new LinearGradientBrush(
                        imageRect,
                        Color.White,
                        Color.Transparent,
                        LinearGradientMode.Horizontal))
                    {
                        Blend blnd = new Blend();
                        blnd.Positions = new float[] { 0f, .2f, .5f, .8f, 1f };
                        blnd.Factors = new float[] { 1f, .6f, 0f, .4f, 1f };
                        fillBrush.Blend = blnd;
                        using (GraphicsPath gp = CreateRoundRectanglePath(g, imageRect, 2))
                            g.FillPath(fillBrush, gp);
                    }
                }
            }
            // make transparent
            _bmpSprite.MakeTransparent();
            // rotate
            if (Orientation == Orientation.Vertical)
                _bmpSprite.RotateFlip(RotateFlipType.Rotate90FlipX);
        }

        /// <summary>
        /// Create the track dc
        /// </summary>
        private void CreateTrack()
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle trackRect = GetTrackRectangle();

            using (Graphics g = Graphics.FromHdc(_cTrackDc.Hdc))
            {
                // fill it in
                if (this.BackgroundImage != null)
                {
                    using (GraphicsMode md = new GraphicsMode(g, SmoothingMode.HighQuality))
                    {
                        using (ImageAttributes ia = new ImageAttributes())
                            g.DrawImage(this.BackgroundImage, bounds, 0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height, GraphicsUnit.Pixel, ia);
                    }
                }
                else
                {
                    DrawBackGround(g, bounds);
                }
                // draw ticks
                if (this.TickStyle != TickStyle.None)
                    DrawTicks(g, bounds);
                // create the path
                if (Orientation == Orientation.Horizontal)//***offsets wrong on createpath?
                    trackRect.Width -= 1;
                else
                    trackRect.Height -= 1;
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                {
                    // draw track shadow
                    if (this.TrackShadow)
                    {
                        trackRect.Inflate(2, 2);
                        using (GraphicsPath gp = CreateRoundRectanglePath(g, trackRect, 2))
                        {
                            // light shadow
                            using (Pen pn = new Pen(Color.FromArgb(80, this.TrackShadowColor), 1f))
                                g.DrawPath(pn, gp);
                        }
                        trackRect.Inflate(-1, -1);
                        using (GraphicsPath gp = CreateRoundRectanglePath(g, trackRect, 2))
                        {
                            // darker
                            using (Pen pn = new Pen(Color.FromArgb(120, this.TrackShadowColor), 1f))
                                g.DrawPath(pn, gp);
                        }
                        trackRect.Inflate(-1, -1);
                    }

                    using (GraphicsPath gp = CreateRoundRectanglePath(g, trackRect, 2))
                    {
                        // fill color
                        if (this.TrackFillColor != Color.Transparent)
                        {
                            using (Brush br = new SolidBrush(this.TrackFillColor))
                                g.FillPath(br, gp);
                        }
                        // draw the outline
                        using (Pen pn = new Pen(this.TrackBorderColor, 1f))
                            g.DrawPath(pn, gp);
                    }
                }
            }
        }

        /// <summary>
        /// Destroy grahics objects
        /// </summary>
        private void DestroyGraphicsObjects()
        {
            // destroy sprite and timer
            StopPulseTimer();
            DestroySprite();
            // destroy buffers
            if (_cControlDc != null)
                _cControlDc.Dispose();
            if (_cTrackDc != null)
                _cTrackDc.Dispose();
            if (_cAnimationDc != null)
                _cAnimationDc.Dispose();
            // destroy images
            if (_bmpButton != null)
                _bmpButton.Dispose();
            if (_bmpSprite != null)
                _bmpSprite.Dispose();
        }

        /// <summary>
        /// Destroy animation sprite
        /// </summary>
        private void DestroySprite()
        {
            if (_bmpSprite != null)
                _bmpSprite.Dispose();
        }
        #endregion

        #region Animation
        #region Drawing
        /// <summary>
        /// Draws the pulse.
        /// </summary>
        private void DrawPulse()
        {
            if (_cControlDc != null)
            {
                int offset = 0;
                Rectangle buttonRect = GetButtonRectangle();
                Rectangle trackRect = GetTrackRectangle();
                Rectangle lineRect;
                Rectangle clipRect = trackRect;

                // copy unaltered image into buffer
                BitBlt(_cAnimationDc.Hdc, 0, 0, _cAnimationDc.Width, _cAnimationDc.Height, _cControlDc.Hdc, 0, 0, 0xCC0020);

                if (Orientation == Orientation.Horizontal)
                {
                    _iLinePos += 2;
                    if (_iLinePos > trackRect.Right - _bmpSprite.Width)
                        _iLinePos = trackRect.Left + 1;
                    if (_iLinePos < buttonRect.Left)
                    {
                        if (_iLinePos + _bmpSprite.Width > buttonRect.Left)
                            offset = _iLinePos + _bmpSprite.Width - buttonRect.Left;
                        lineRect = new Rectangle(_iLinePos, trackRect.Y, _bmpSprite.Width - offset, _bmpSprite.Height);
                        // draw sprite -horz
                        DrawPulseSprite(_cAnimationDc.Hdc, _bmpSprite, lineRect, .4f);
                    }
                }
                else
                {
                    _iLinePos -= 1;
                    if (_iLinePos < trackRect.Top + _bmpSprite.Height)
                        _iLinePos = trackRect.Bottom - _bmpSprite.Height;
                    if (_iLinePos > buttonRect.Bottom)
                    {
                        if (_iLinePos - _bmpSprite.Height < buttonRect.Bottom)
                            offset = buttonRect.Bottom - (_iLinePos - _bmpSprite.Height);
                        lineRect = new Rectangle(trackRect.X, _iLinePos, _bmpSprite.Width, _bmpSprite.Height - offset);
                        // draw sprite -vert
                        DrawPulseSprite(_cAnimationDc.Hdc, _bmpSprite, lineRect, .4f);
                    }
                }
                // draw to control
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    BitBlt(g.GetHdc(), 0, 0, _cAnimationDc.Width, _cAnimationDc.Height, _cAnimationDc.Hdc, 0, 0, 0xCC0020);
                    g.ReleaseHdc();
                }
                RECT r = new RECT(0, 0, this.Width, this.Height);
                ValidateRect(this.Handle, ref r);
            }
        }

        /// <summary>
        /// Draws the line sprite
        /// </summary>
        /// <param name="destdc">The destdc.</param>
        /// <param name="source">The source.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="intensity">The intensity.</param>
        private void DrawPulseSprite(IntPtr destdc, Bitmap source, Rectangle bounds, float intensity)
        {
            using (Graphics g = Graphics.FromHdc(destdc))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                AlphaBlend(g, source, bounds, intensity);
            }
        }
        #endregion

        #region Timer
        /// <summary>
        /// Starts the pulse timer.
        /// </summary>
        private void StartPulseTimer()
        {
            if (_cPulseTimer == null)
            {
                _bPulseTimerOn = true;
                if (_cAnimationDc != null)
                    _cAnimationDc.Dispose();
                _cAnimationDc = new cStoreDc();
                _cAnimationDc.Width = _cControlDc.Width;
                _cAnimationDc.Height = _cControlDc.Height;
                BitBlt(_cAnimationDc.Hdc, 0, 0, _cControlDc.Width, _cControlDc.Height, _cControlDc.Hdc, 0, 0, 0xCC0020);
                // timer setup
                _cPulseTimer = new FadeTimer(this);
                _cPulseTimer.Tick += new FadeTimer.TickDelegate(_cPulseTimer_Tick);
                _cPulseTimer.Complete += new FadeTimer.CompleteDelegate(_cPulseTimer_Complete);
                _cPulseTimer.Interval = (int)this.AnimationSpeed;
                _cPulseTimer.Fade(FadeTimer.FadeType.Loop);
            }
        }

        /// <summary>
        /// Stops the pulse timer.
        /// </summary>
        private void StopPulseTimer()
        {
            if (_cPulseTimer != null)
            {
                _iLinePos = 0;
                if (_cAnimationDc != null)
                    _cAnimationDc.Dispose();
                // tear down the timer class
                _cPulseTimer.Reset();
                _cPulseTimer.Tick -= _cPulseTimer_Tick;
                _cPulseTimer.Complete -= _cPulseTimer_Complete;
                _cPulseTimer.Dispose();
                _cPulseTimer = null;
                _bPulseTimerOn = false;
            }
        }

        /// <summary>
        /// cs the pulse timer complete.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cPulseTimer_Complete(object sender)
        {
            ResetCallback rs = new ResetCallback(StopPulseTimer);
            this.Invoke(rs);
        }

        /// <summary>
        /// cs the pulse timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void _cPulseTimer_Tick(object sender)
        {
            DrawPulse();
        }

        #endregion
        #endregion

        #region FlyOut Caption
        /// <summary>
        /// Draws the fly out.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawFlyOut(Graphics g)
        {
            Rectangle buttonRect = GetButtonRectangle();
            Rectangle flyoutRect;
            int pos;
            string data = "";

            if (Orientation == Orientation.Horizontal)
            {
                pos = buttonRect.Left + (int)(buttonRect.Width * .5f);
                int offset = (int)(this.FlyOutMaxWidth * .5f);
                flyoutRect = new Rectangle((int)pos - offset, buttonRect.Top - (this.FlyOutMaxDepth + this.FlyOutSpacer), this.FlyOutMaxWidth, this.FlyOutMaxDepth);
                offset -= 8;
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                {
                    using (GraphicsPath gp = CreatePointedRectangularPath(g, flyoutRect, PointDirection.Bottom, 5, 4, offset))
                    {
                        using (Brush br = new SolidBrush(Color.FromArgb(220, Color.White)))
                            g.FillPath(br, gp);
                        using (Pen pn = new Pen(Color.FromArgb(160, Color.DimGray)))
                            g.DrawPath(pn, gp);

                        if (FlyOutInfo != null)
                            FlyOutInfo(ref data);
                        if (data.Length == 0)
                            data = this.Value.ToString("0");
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.FormatFlags = StringFormatFlags.NoWrap;
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            using (Font ft = new Font("Arial", 8f, FontStyle.Regular))
                                g.DrawString(data, ft, Brushes.Black, flyoutRect, sf);
                        }
                    }
                }
            }
            else
            {
                pos = buttonRect.Top + (int)(buttonRect.Height * .5f);
                int offset = (int)(this.FlyOutMaxWidth * .5f);
                flyoutRect = new Rectangle(buttonRect.Left - (this.FlyOutMaxDepth + this.FlyOutSpacer), pos - offset, this.FlyOutMaxDepth, this.FlyOutMaxWidth);
                using (GraphicsMode mode = new GraphicsMode(g, SmoothingMode.HighQuality))
                {
                    using (GraphicsPath gp = CreatePointedRectangularPath(g, flyoutRect, PointDirection.Right, 5, 4, 1))
                    {
                        using (Brush br = new SolidBrush(Color.FromArgb(200, Color.White)))
                            g.FillPath(br, gp);
                        using (Pen pn = new Pen(Color.FromArgb(240, this.ButtonBorderColor)))
                            g.DrawPath(pn, gp);

                        if (FlyOutInfo != null)
                            FlyOutInfo(ref data);
                        if (data.Length == 0)
                            data = this.Value.ToString("0");
                        flyoutRect.Width -= 4;
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.FormatFlags = StringFormatFlags.NoWrap;
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Center;
                            using (Font ft = new Font("Arial", 8f, FontStyle.Regular))
                                g.DrawString(data, ft, Brushes.Black, flyoutRect, sf);
                        }
                    }
                }
            }

        }
        #endregion
        #endregion

        #region Helpers
        /// <summary>
        /// AlphaBlend an image, alpha .1-1
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bmp">The BMP.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="alpha">The alpha.</param>
        private void AlphaBlend(Graphics g, Bitmap bmp, Rectangle bounds, float alpha)
        {
            if (alpha > 1f)
                alpha = 1f;
            else if (alpha < .01f)
                alpha = .01f;
            using (ImageAttributes ia = new ImageAttributes())
            {
                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = 1f;
                cm.Matrix11 = 1f;
                cm.Matrix22 = 1f;
                cm.Matrix44 = 1f;
                cm.Matrix33 = alpha;
                ia.SetColorMatrix(cm);
                g.DrawImage(bmp, bounds, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>
        /// Maximun size based on control options
        /// </summary>
        private void CalculateMaximumSize()
        {
            Size sz = new Size(0, 0);

            if (this.TickStyle != TickStyle.None)
                sz.Height += (this.TickMaxLength + this.TickMinPadding) * (this.TickStyle == TickStyle.Both ? 2 : 1);
            if (this.SliderFlyOut != FlyOutStyle.None)
                sz.Height += this.FlyOutMaxDepth + this.FlyOutSpacer;

            switch (this.ButtonStyle)
            {
                case ButtonType.GlassInline:
                case ButtonType.RoundedRectInline:
                    {
                        sz.Height += TrackMaxDepth + 6;
                        break;
                    }
                case ButtonType.GlassOverlap:
                case ButtonType.RoundedRectOverlap:
                    {
                        sz.Height += TrackMaxDepth * 4;
                        break;
                    }
                case ButtonType.Round:
                case ButtonType.Hybrid:
                    {
                        sz.Height += TrackMaxDepth + 8;
                        break;
                    }
                case ButtonType.PointerDownLeft:
                case ButtonType.PointerUpRight:
                    {
                        sz.Height += TrackMaxDepth * 4;
                        break;
                    }
            }
            if (Orientation == Orientation.Horizontal)
            {
                this.MaxSize = sz;
            }
            else
            {
                Size flip = new Size(sz.Height, sz.Width);
                this.MaxSize = flip;
            }
        }

        /// <summary>
        /// Minimum size based on control options
        /// </summary>
        private void CalculateMinimumSize()
        {
            Size sz = new Size(0, 0);

            if (this.TickStyle != TickStyle.None)
                sz.Height += (this.TickMaxLength + this.TickMinPadding) * (this.TickStyle == TickStyle.Both ? 2 : 1);
            if (this.SliderFlyOut != FlyOutStyle.None)
                sz.Height += this.FlyOutMaxDepth + this.FlyOutSpacer;

            switch (this.ButtonStyle)
            {
                case ButtonType.GlassInline:
                case ButtonType.RoundedRectInline:
                    {
                        sz.Height += TrackMinDepth + 6;
                        break;
                    }
                case ButtonType.GlassOverlap:
                case ButtonType.RoundedRectOverlap:
                    {
                        sz.Height += TrackMinDepth * 4;
                        break;
                    }
                case ButtonType.Round:
                case ButtonType.Hybrid:
                    {
                        sz.Height += TrackMinDepth + 8;
                        break;
                    }
                case ButtonType.PointerDownLeft:
                case ButtonType.PointerUpRight:
                    {
                        sz.Height += TrackMinDepth * 4;
                        break;
                    }
            }
            if (Orientation == Orientation.Horizontal)
            {
                this.MinSize = sz;
            }
            else
            {
                Size flip = new Size(sz.Height, sz.Width);
                this.MinSize = flip;
            }
        }

        /// <summary>
        /// Creates the pointed rectangular path.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="inset">The inset.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreatePointedRectangularPath(Graphics g, Rectangle bounds, PointDirection direction, float radius, int depth, int inset)
        {
            int diff = 0;
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            switch (direction)
            {
                case PointDirection.Bottom:
                    {
                        // line left
                        pathBounds.AddLine(bounds.Left, bounds.Bottom - radius, bounds.Left, bounds.Top + radius);
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90);
                        // line top
                        pathBounds.AddLine(bounds.Left + radius, bounds.Top, bounds.Right - radius, bounds.Top);
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90);
                        // line right
                        pathBounds.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom - radius);
                        // pointed path //
                        if (inset == -1)
                            radius = 0;
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                        // line bottom right
                        pathBounds.AddLine(bounds.Right - radius, bounds.Bottom, bounds.Right - (radius + inset), bounds.Bottom);
                        // pointed center
                        diff = (bounds.Width / 2) - ((int)radius + inset);
                        // right half
                        pathBounds.AddLine(bounds.Right - (radius + inset), bounds.Bottom, bounds.Right - (radius + inset + diff), bounds.Bottom + depth);
                        // left half
                        pathBounds.AddLine(bounds.Right - (radius + inset + diff), bounds.Bottom + depth, bounds.Left + radius + inset, bounds.Bottom);
                        // line bottom left
                        pathBounds.AddLine(bounds.Left + radius + inset, bounds.Bottom, bounds.Left + radius, bounds.Bottom);
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90);

                        break;
                    }
                case PointDirection.Right:
                    {
                        // line top
                        pathBounds.AddLine(bounds.Left + radius, bounds.Top, bounds.Right - (radius + depth), bounds.Top);
                        // arc top right
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Right - (radius + depth), bounds.Top, radius, radius, 270, 90);

                        // top line
                        pathBounds.AddLine(bounds.Right - depth, bounds.Top + radius, bounds.Right - depth, bounds.Top + (radius + inset));
                        // pointed center
                        diff = (bounds.Height / 2) - ((int)radius + inset);
                        // top half
                        pathBounds.AddLine(bounds.Right - depth, bounds.Top + (radius + inset), bounds.Right, bounds.Bottom - (radius + inset + diff));
                        // bottom half
                        pathBounds.AddLine(bounds.Right, bounds.Bottom - (radius + inset + diff), bounds.Right - depth, bounds.Bottom - (radius + inset));
                        // line right bottom
                        pathBounds.AddLine(bounds.Right - depth, bounds.Bottom - (radius + inset), bounds.Right - depth, bounds.Bottom - radius);
                        // arc bottom right
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Right - (radius + depth), bounds.Bottom - radius, radius, radius, 0, 90);
                        // line bottom
                        pathBounds.AddLine(bounds.Right - (radius + depth), bounds.Bottom, bounds.Left + radius, bounds.Bottom);
                        if (inset == -1)
                            radius = 0;
                        // arc bottom left
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90);
                        // line left
                        pathBounds.AddLine(bounds.Left, bounds.Bottom - radius, bounds.Left, bounds.Top + radius);
                        // arc top left
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90);

                        /*// pointed path //
                        // line left bottom
                        pathBounds.AddLine(bounds.Left, bounds.Bottom - radius, bounds.Left, bounds.Bottom - (radius + inset));
                        // pointed center
                        diff = (bounds.Height / 2) - ((int)radius + inset);
                        // bottom half
                        pathBounds.AddLine(bounds.Left, bounds.Bottom - (radius + inset), bounds.Left - depth, bounds.Bottom - (radius + inset + diff));
                        // top half
                        pathBounds.AddLine(bounds.Left - depth, bounds.Bottom - (radius + inset + diff), bounds.Left, bounds.Top + (radius + inset));
                        // top line
                        pathBounds.AddLine(bounds.Left, bounds.Top + (radius + inset), bounds.Left, bounds.Top + radius);
                        if (radius > 0)
                            pathBounds.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90);*/
                        break;
                    }
            }

            pathBounds.CloseFigure();
            return pathBounds;
        }

        /// <summary>
        /// Create a round GraphicsPath [not used]
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateRoundPath(Graphics g, Rectangle bounds)
        {
            int size = bounds.Width > bounds.Height ? bounds.Height : bounds.Width;
            bounds.Height = size;
            bounds.Width = size;
            GraphicsPath circlePath = new GraphicsPath();
            // create the path
            circlePath.AddEllipse(bounds);
            circlePath.CloseFigure();
            return circlePath;
        }

        /// <summary>
        /// Create a rounded rectangle GraphicsPath
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath CreateRoundRectanglePath(Graphics g, Rectangle bounds, float radius)
        {
            // create a path
            GraphicsPath pathBounds = new GraphicsPath();
            // arc top left
            pathBounds.AddArc(bounds.Left, bounds.Top, radius, radius, 180, 90);
            // line top
            pathBounds.AddLine(bounds.Left + radius, bounds.Top, bounds.Right - radius, bounds.Top);
            // arc top right
            pathBounds.AddArc(bounds.Right - radius, bounds.Top, radius, radius, 270, 90);
            // line right
            pathBounds.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom - radius);
            // arc bottom right
            pathBounds.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            // line bottom
            pathBounds.AddLine(bounds.Right - radius, bounds.Bottom, bounds.Left + radius, bounds.Bottom);
            // arc bottom left
            pathBounds.AddArc(bounds.Left, bounds.Bottom - radius, radius, radius, 90, 90);
            // line left
            pathBounds.AddLine(bounds.Left, bounds.Bottom - radius, bounds.Left, bounds.Top + radius);
            pathBounds.CloseFigure();
            return pathBounds;
        }

        /// <summary>
        /// Set default button sizes
        /// </summary>
        /// <param name="type">The type.</param>
        private void DefaultButtonSize(ButtonType type)
        {
            Size sz = new Size(14, 14);
            switch (type)
            {
                case ButtonType.Hybrid:
                case ButtonType.Round:
                    _iTrackDepth = 4;
                    sz.Height = _iTrackDepth + 8;
                    sz.Width = sz.Height;
                    break;
                case ButtonType.PointerDownLeft:
                case ButtonType.PointerUpRight:
                    _iTrackDepth = 5;
                    sz.Height = _iTrackDepth * 4;
                    sz.Width = _iTrackDepth + 2;
                    break;
                case ButtonType.RoundedRectInline:
                    _iTrackDepth = 4;
                    _iButtonCornerRadius = 6;
                    sz.Height = _iTrackDepth + 6;
                    sz.Width = sz.Height * 2;
                    break;
                case ButtonType.RoundedRectOverlap:
                    _iTrackDepth = 4;
                    _iButtonCornerRadius = 4;
                    sz.Height = _iTrackDepth * 4;
                    sz.Width = _iTrackDepth + 6;
                    break;
                case ButtonType.GlassInline:
                    _iTrackDepth = 6;
                    _iButtonCornerRadius = 2;
                    sz.Height = _iTrackDepth + 6;
                    sz.Width = sz.Height * 2;
                    break;
                case ButtonType.GlassOverlap:
                    _iTrackDepth = 4;
                    _iButtonCornerRadius = 2;
                    sz.Height = _iTrackDepth * 4;
                    sz.Width = _iTrackDepth + 6;
                    break;
            }

            if (Orientation == Orientation.Vertical)
            {
                Size sv = new Size(sz.Height, sz.Width);
                _szButtonSize = sv;
            }
            else
            {
                _szButtonSize = sz;
            }
        }

        /// <summary>
        /// Return button size and coordinates
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetButtonRectangle()
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            RectangleF buttonRect = new RectangleF();
            int offsetX = (bounds.Width / 2);
            int offset = 0;
            double pos = _dButtonPosition + this.TrackPadding;

            if (Orientation == Orientation.Horizontal)
            {
                if (this.SliderFlyOut != FlyOutStyle.None)
                    offset = this.FlyOutMaxDepth + this.FlyOutSpacer;
                if (this.TickStyle == TickStyle.TopLeft)
                    offset += this.TickMaxLength + this.TickMinPadding;
                else if (this.TickStyle == TickStyle.BottomRight)
                    offset -= this.TickMaxLength + this.TickMinPadding;
                offset += (int)((bounds.Height - offset) * .5f);
                offset -= (int)(this.ButtonSize.Height * .5f);
                buttonRect = new RectangleF((float)pos, offset, this.ButtonSize.Width, this.ButtonSize.Height);
            }
            else
            {
                // offset on track
                if (this.SliderFlyOut != FlyOutStyle.None)
                    offset = this.FlyOutMaxDepth + this.FlyOutSpacer;
                if (this.TickStyle == TickStyle.TopLeft)
                    offset += this.TickMaxLength + this.TickMinPadding;
                else if (this.TickStyle == TickStyle.BottomRight)
                    offset -= this.TickMaxLength + this.TickMinPadding;
                offset += (int)((bounds.Width - offset) * .5f);
                offset -= (int)(this.ButtonSize.Width * .5f);
                buttonRect = new RectangleF(offset, (float)pos, this.ButtonSize.Width, this.ButtonSize.Height);
            }
            // store it for hit testing
            _buttonRect = new RECT((int)buttonRect.X, (int)buttonRect.Y, (int)buttonRect.Right, (int)buttonRect.Bottom);
            return Rectangle.Round(buttonRect);
        }

        /// <summary>
        /// Return track size and coordinates
        /// </summary>
        /// <returns>Rectangle.</returns>
        private Rectangle GetTrackRectangle()
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle trackRect;
            int offset;

            if (Orientation == Orientation.Horizontal)
            {
                // reduce for padding and center rect
                offset = (int)(this.TrackPadding);
                bounds.Inflate(-offset, 0);
                offset = 0;
                if (this.SliderFlyOut != FlyOutStyle.None)
                    offset = this.FlyOutMaxDepth + this.FlyOutSpacer;
                if (this.TickStyle == TickStyle.TopLeft)
                    offset += this.TickMaxLength + this.TickMinPadding;
                else if (this.TickStyle == TickStyle.BottomRight)
                    offset -= this.TickMaxLength + this.TickMinPadding;
                offset += (int)((bounds.Height - offset) * .5f);
                offset -= (int)(this.TrackDepth * .5f);
                trackRect = new Rectangle(bounds.X, offset, bounds.Width, this.TrackDepth);
            }
            else
            {
                offset = (int)(this.TrackPadding);
                bounds.Inflate(0, -offset);
                offset = 0;
                if (this.SliderFlyOut != FlyOutStyle.None)
                    offset = this.FlyOutMaxDepth + this.FlyOutSpacer;
                if (this.TickStyle == TickStyle.TopLeft)
                    offset += this.TickMaxLength + this.TickMinPadding;
                else if (this.TickStyle == TickStyle.BottomRight)
                    offset -= this.TickMaxLength + this.TickMinPadding;
                offset += (int)((bounds.Width - offset) * .5f);
                offset -= (int)(this.TrackDepth * .5f);
                trackRect = new Rectangle(offset, bounds.Y, this.TrackDepth, bounds.Height);
            }
            // store for hit testing
            _trackRect = new RECT(trackRect.X, trackRect.Y, trackRect.Right, trackRect.Bottom);
            return trackRect;
        }

        /// <summary>
        /// Exact size between ticks
        /// </summary>
        /// <returns>System.Double.</returns>
        private double Increment()
        {
            Rectangle trackRect = GetTrackRectangle();

            if (Orientation == Orientation.Horizontal)
                return (double)((trackRect.Width - this.ButtonSize.Width) / IncrementScale());
            else
                return (double)((trackRect.Height - this.ButtonSize.Height) / IncrementScale());
        }

        /// <summary>
        /// Offset number if Minimum and Maximum are negative to positive integers
        /// </summary>
        /// <returns>System.Double.</returns>
        private double IncrementOffset()
        {
            double center = 0;
            if (this.Minimum < 0 && this.Maximum > 0)
                center = 1;
            return center;
        }

        /// <summary>
        /// The total number of tick increments
        /// </summary>
        /// <returns>System.Double.</returns>
        private double IncrementScale()
        {
            return (double)System.Math.Abs(this.Maximum - this.Minimum);
        }

        /// <summary>
        /// The incremental size between the Minimum and Value
        /// </summary>
        /// <returns>System.Double.</returns>
        private double IncrementalValue()
        {
            if (Orientation == Orientation.Horizontal)
                return Increment() * (double)(System.Math.Abs(this.Value - this.Minimum));
            else
                return Increment() * (double)(IncrementScale() - (System.Math.Abs(this.Value - this.Minimum)));
        }

        /// <summary>
        /// Modulus returns true if divisible with no remainder
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Mod(int a, int b)
        {
            if (System.Math.IEEERemainder((double)a, (double)b) == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Return position coordinates from value
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>System.Double.</returns>
        private double PosFromValue(int val)
        {
            if (Orientation == Orientation.Horizontal)
                return Increment() * (double)(System.Math.Abs(val - this.Minimum + (val != this.Minimum ? IncrementOffset() : 0)));
            else
                return Increment() * (double)(IncrementScale() - (System.Math.Abs(val - this.Minimum) + (val != this.Minimum ? IncrementOffset() : 0)));
        }

        /// <summary>
        /// Repaint and optionally resize
        /// </summary>
        private void PropertyChange()
        {
            if (this.DesignMode)
            {
                if (this.SmoothScrolling)
                    _dButtonPosition = PosFromValue(this.Value);
                else
                    _dButtonPosition = IncrementalValue();
                if (this.AutoSize && this.FinishedPropRun)
                    ResizeThis();
                CreateGraphicsObjects();
            }
            else if (this.IsInited)
            {
                if (this.SmoothScrolling)
                    _dButtonPosition = PosFromValue(this.Value);
                else
                    _dButtonPosition = IncrementalValue();
                CreateGraphicsObjects();
            }
            DrawSlider();
        }

        /// <summary>
        /// Repaint the control
        /// </summary>
        private void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        /// <summary>
        /// Resize the control via alignments and options
        /// </summary>
        private void ResizeThis()
        {
            int offset = 0;
            int depth = 0;
            int diff = 0;
            Size sz = new Size(14, 14);

            CalculateMaximumSize();
            CalculateMinimumSize();

            if (this.Orientation == Orientation.Horizontal)
            {
                if (this.MinSize.Height == 0 || this.MaxSize.Height == 0)
                    return;

                if (this.Height <= this.MinSize.Height)
                    this.Height = this.MinSize.Height;
                else if (this.Height >= this.MaxSize.Height)
                    this.Height = this.MaxSize.Height;

                offset = this.Height - this.MinSize.Height;
                diff = this.MinSize.Height - ButtonSize.Height;

                if (offset < 2)
                    depth = TrackMinDepth;
                else if (offset < 3)
                    depth = TrackMinDepth + 1;
                else if (offset < 4)
                    depth = TrackMinDepth + 2;
                else
                    depth = TrackMaxDepth;

                switch (this.ButtonStyle)
                {
                    case ButtonType.GlassInline:
                        {
                            sz.Height = depth + 6;
                            sz.Width = sz.Height * 2;
                            break;
                        }
                    case ButtonType.RoundedRectInline:
                        {
                            sz.Height = depth + 6;
                            sz.Width = sz.Height * 2;
                            break;
                        }
                    case ButtonType.GlassOverlap:
                        {
                            sz.Height = depth * 4;
                            sz.Width = depth + 6;
                            break;
                        }
                    case ButtonType.RoundedRectOverlap:
                        {
                            sz.Height = depth * 4;
                            sz.Width = depth + 6;
                            break;
                        }
                    case ButtonType.Round:
                    case ButtonType.Hybrid:
                        {
                            sz.Height = depth + 8;
                            sz.Width = sz.Height;
                            break;
                        }
                    case ButtonType.PointerDownLeft:
                    case ButtonType.PointerUpRight:
                        {
                            sz.Height = depth * 4;
                            sz.Width = depth + 2;
                            break;
                        }
                    default:
                        {
                            sz.Height = depth * 4;
                            sz.Width = depth + 2;
                            break;
                        }
                }

                if (this.Width < (this.ButtonSize.Height + this.TrackPadding) * 2)
                    this.Width = (this.ButtonSize.Height + this.TrackPadding) * 2;
                if (sz.Height != this.ButtonSize.Height && this.Height >= sz.Height + diff)
                {
                    _iTrackDepth = depth;
                    _szButtonSize = sz;
                }
                else if (sz.Height != this.ButtonSize.Height && this.Height < this.ButtonSize.Height + diff)
                {
                    _iTrackDepth = depth;
                    _szButtonSize = sz;
                }
            }
            else
            {
                if (this.MinSize.Width == 0 || this.MaxSize.Width == 0)
                    return;

                if (this.Width <= this.MinSize.Width)
                    this.Width = this.MinSize.Width;
                else if (this.Width >= this.MaxSize.Width)
                    this.Width = this.MaxSize.Width;

                offset = this.Width - this.MinSize.Width;

                if (offset < 2)
                    depth = TrackMinDepth;
                else if (offset < 3)
                    depth = TrackMinDepth + 1;
                else if (offset < 4)
                    depth = TrackMinDepth + 2;
                else
                    depth = TrackMaxDepth;

                switch (this.ButtonStyle)
                {
                    case ButtonType.GlassInline:
                        {
                            sz.Width = depth + 6;
                            sz.Height = sz.Width * 2;
                            break;
                        }
                    case ButtonType.RoundedRectInline:
                        {
                            sz.Width = depth + 6;
                            sz.Height = sz.Width * 2;
                            break;
                        }
                    case ButtonType.GlassOverlap:
                        {
                            sz.Width = depth * 4;
                            sz.Height = depth + 6;
                            break;
                        }
                    case ButtonType.RoundedRectOverlap:
                        {
                            sz.Width = depth * 4;
                            sz.Height = depth + 6;
                            break;
                        }
                    case ButtonType.Round:
                    case ButtonType.Hybrid:
                        {
                            sz.Width = depth + 8;
                            sz.Height = sz.Width;
                            break;
                        }
                    case ButtonType.PointerDownLeft:
                    case ButtonType.PointerUpRight:
                        {
                            sz.Width = depth * 4;
                            sz.Height = depth + 2;
                            break;
                        }
                    default:
                        {
                            sz.Width = depth * 4;
                            sz.Height = depth + 2;
                            break;
                        }
                }

                if (this.Height < (this.ButtonSize.Width + this.TrackPadding) * 2)
                    this.Height = (this.ButtonSize.Width + this.TrackPadding) * 2;

                if (sz.Width != this.ButtonSize.Width && this.Width >= sz.Width + diff)
                {
                    _iTrackDepth = depth;
                    _szButtonSize = sz;
                }
                else if (sz.Width != this.ButtonSize.Width && this.Width < this.ButtonSize.Width + diff)
                {
                    _iTrackDepth = depth;
                    _szButtonSize = sz;
                }
            }
        }

        /// <summary>
        /// Scroll by large or small change values
        /// </summary>
        /// <param name="change">The change.</param>
        /// <param name="decrease">if set to <c>true</c> [decrease].</param>
        private void ScrollChange(ChangeType change, bool decrease)
        {
            int count = 0;
            if (change == ChangeType.Large)
            {
                if (decrease)
                    count = this.Value - LargeChange;
                else
                    count = this.Value + LargeChange;
            }
            else
            {
                if (decrease)
                    count = this.Value - SmallChange;
                else
                    count = this.Value + SmallChange;
            }

            if (count < this.Minimum)
                count = this.Minimum;
            if (count > this.Maximum)
                count = this.Maximum;

            this.Value = count;
        }

        /// <summary>
        /// Estimate value from position
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int ValueFromPosition()
        {
            try
            {
                int pos = this.PointToClient(Cursor.Position).X;
                double increment = Increment();
                int sz = (Orientation == Orientation.Horizontal) ? this.ButtonSize.Width : this.ButtonSize.Height;
                double val = IncrementalValue();
                pos -= (sz / 2);

                if (pos > -sz)
                {
                    if (pos < this.TrackPadding)
                        pos = this.TrackPadding;
                    if (this.Orientation == Orientation.Horizontal)
                    {
                        if (pos > PosFromValue(this.Maximum) + this.TrackPadding)
                            pos = (int)PosFromValue(this.Maximum) + this.TrackPadding;
                    }
                    else
                    {
                        if (pos > PosFromValue(this.Minimum) + this.TrackPadding)
                            pos = (int)PosFromValue(this.Minimum) + this.TrackPadding;
                    }
                    pos -= this.TrackPadding;
                }
                return ValueFromPos(pos);
            }
            catch { return 0; }
        }

        /// <summary>
        /// Scroll the slider to a position and set value
        /// </summary>
        /// <param name="pos">The position.</param>
        private void ScrollThis(double pos)
        {
            bool redraw = false;
            double val;
            double store = _dButtonPosition;
            double increment = Increment();
            int sz = (Orientation == Orientation.Horizontal) ? this.ButtonSize.Width : this.ButtonSize.Height;

            val = IncrementalValue();
            pos -= (sz / 2); //ju 1.3

            if (pos > -sz)
            {
                if (SmoothScrolling)
                {
                    if (pos < this.TrackPadding)
                        pos = this.TrackPadding;
                    if (this.Orientation == Orientation.Horizontal)
                    {
                        if (pos > PosFromValue(this.Maximum) + this.TrackPadding)
                            pos = PosFromValue(this.Maximum) + this.TrackPadding;
                    }
                    else
                    {
                        if (pos > PosFromValue(this.Minimum) + this.TrackPadding)
                            pos = PosFromValue(this.Minimum) + this.TrackPadding;
                    }
                    pos -= this.TrackPadding;
                    _dButtonPosition = pos;
                    if (Scrolled != null)
                        Scrolled(this, new EventArgs());
                    if (store != pos)
                    {
                        val = this.Value;
                        _iValue = ValueFromPos(pos);
                        if (_iValue != val)
                        {
                            if (ValueChanged != null)
                                ValueChanged(this, new EventArgs());
                        }
                        DrawSlider();
                    }
                }
                else
                {
                    store = this.Value;
                    //pos -= this.TrackPadding; ju 1.3

                    if (pos > val + increment &&
                        (Orientation == Orientation.Horizontal && this.Value != this.Maximum) ||
                            (Orientation == Orientation.Vertical && this.Value != this.Minimum))
                    {
                        _iValue = ValueFromPos(pos);
                        if (Scrolled != null)
                            Scrolled(this, new EventArgs());
                    }
                    else if (pos < val && // ju 1.3
                        (Orientation == Orientation.Horizontal && this.Value != this.Minimum) ||
                            (Orientation == Orientation.Vertical && this.Value != this.Maximum))
                    {
                        _iValue = ValueFromPos(pos);
                        if (Scrolled != null)
                            Scrolled(this, new EventArgs());
                    }
                    if (_iValue != store)
                        this.Value = _iValue;
                    else if (redraw)
                        DrawSlider();
                }

            }
        }

        /// <summary>
        /// Mouse Hit test
        /// </summary>
        /// <returns>HitTest.</returns>
        private HitTest SliderHitTest()
        {
            Point pt = new Point();
            RECT tr = new RECT();

            GetClientRect(this.Handle, ref tr);
            GetCursorPos(ref pt);
            ScreenToClient(this.Handle, ref pt);
            if (PtInRect(ref _buttonRect, pt))
                return HitTest.Button;
            else if (PtInRect(ref _trackRect, pt))
                return HitTest.Track;
            else
                return HitTest.Nowhere;
        }

        /// <summary>
        /// The value at a provided position
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.Int32.</returns>
        private int ValueFromPos(double pos)
        {
            int val;
            pos -= this.TrackPadding;
            if (Orientation == Orientation.Horizontal)
                val = this.Minimum + (int)System.Math.Round(pos / Increment());
            else
                val = this.Maximum - (int)System.Math.Round(pos / Increment());

            if (val < this.Minimum)
                val = this.Minimum;
            if (val > this.Maximum)
                val = this.Maximum;
            return val;
        }
        #endregion
        #endregion

        #region Graphics Mode
        /// <summary>
        /// Maintains graphic object state
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        internal class GraphicsMode : IDisposable
        {
            #region Fields
            /// <summary>
            /// The g graphic copy
            /// </summary>
            private Graphics _gGraphicCopy;
            /// <summary>
            /// The e old mode
            /// </summary>
            private SmoothingMode _eOldMode;
            #endregion

            #region Methods
            /// <summary>
            /// Initialize a new instance of the class.
            /// </summary>
            /// <param name="g">Graphics instance.</param>
            /// <param name="mode">Desired Smoothing mode.</param>
            public GraphicsMode(Graphics g, SmoothingMode mode)
            {
                _gGraphicCopy = g;
                _eOldMode = _gGraphicCopy.SmoothingMode;
                _gGraphicCopy.SmoothingMode = mode;
            }

            /// <summary>
            /// Revert the SmoothingMode to original setting.
            /// </summary>
            public void Dispose()
            {
                _gGraphicCopy.SmoothingMode = _eOldMode;
            }
            #endregion
        }
        #endregion

        #region Effects Timer
        /// <summary>
        /// Effect timer class
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        internal class FadeTimer : IDisposable
        {
            #region Enum
            /// <summary>
            /// Enum FadeType
            /// </summary>
            internal enum FadeType
            {
                /// <summary>
                /// The none
                /// </summary>
                None = 0,
                /// <summary>
                /// The fade in
                /// </summary>
                FadeIn,
                /// <summary>
                /// The fade out
                /// </summary>
                FadeOut,
                /// <summary>
                /// The fade fast
                /// </summary>
                FadeFast,
                /// <summary>
                /// The loop
                /// </summary>
                Loop
            }
            #endregion

            #region Structs
            /// <summary>
            /// Struct RECT
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="RECT"/> struct.
                /// </summary>
                /// <param name="X">The x.</param>
                /// <param name="Y">The y.</param>
                /// <param name="Width">The width.</param>
                /// <param name="Height">The height.</param>
                public RECT(int X, int Y, int Width, int Height)
                {
                    this.Left = X;
                    this.Top = Y;
                    this.Right = Width;
                    this.Bottom = Height;
                }
                /// <summary>
                /// The left
                /// </summary>
                public int Left;
                /// <summary>
                /// The top
                /// </summary>
                public int Top;
                /// <summary>
                /// The right
                /// </summary>
                public int Right;
                /// <summary>
                /// The bottom
                /// </summary>
                public int Bottom;
            }
            #endregion

            #region API
            /// <summary>
            /// Gets the dc.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            private static extern IntPtr GetDC(IntPtr handle);

            /// <summary>
            /// Releases the dc.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <param name="hdc">The HDC.</param>
            /// <returns>System.Int32.</returns>
            [DllImport("user32.dll")]
            private static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

            /// <summary>
            /// Bits the BLT.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="nXDest">The n x dest.</param>
            /// <param name="nYDest">The n y dest.</param>
            /// <param name="nWidth">Width of the n.</param>
            /// <param name="nHeight">Height of the n.</param>
            /// <param name="hdcSrc">The HDC source.</param>
            /// <param name="nXSrc">The n x source.</param>
            /// <param name="nYSrc">The n y source.</param>
            /// <param name="dwRop">The dw rop.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

            /// <summary>
            /// Gets the desktop window.
            /// </summary>
            /// <returns>IntPtr.</returns>
            [DllImport("user32.dll")]
            private static extern IntPtr GetDesktopWindow();

            /// <summary>
            /// Gets the window rect.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="lpRect">The lp rect.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
            #endregion

            #region Events
            /// <summary>
            /// Delegate CompleteDelegate
            /// </summary>
            /// <param name="sender">The sender.</param>
            public delegate void CompleteDelegate(object sender);
            /// <summary>
            /// Delegate TickDelegate
            /// </summary>
            /// <param name="sender">The sender.</param>
            public delegate void TickDelegate(object sender);
            /// <summary>
            /// Occurs when [complete].
            /// </summary>
            public event CompleteDelegate Complete;
            /// <summary>
            /// Occurs when [tick].
            /// </summary>
            public event TickDelegate Tick;
            #endregion

            #region Fields
            /// <summary>
            /// The b capture screen
            /// </summary>
            private bool _bCaptureScreen = false;
            /// <summary>
            /// The b cancel timer
            /// </summary>
            private bool _bCancelTimer;
            /// <summary>
            /// The b is reset
            /// </summary>
            private bool _bIsReset;
            /// <summary>
            /// The i tick counter
            /// </summary>
            private int _iTickCounter;
            /// <summary>
            /// The i tick maximum
            /// </summary>
            private int _iTickMaximum;
            /// <summary>
            /// The i tick rate
            /// </summary>
            private double _iTickRate;
            /// <summary>
            /// The e fade type
            /// </summary>
            private FadeType _eFadeType;
            /// <summary>
            /// The c button dc
            /// </summary>
            private cStoreDc _cButtonDc;
            /// <summary>
            /// The ct parent control
            /// </summary>
            private UserControl _ctParentControl;
            /// <summary>
            /// a timer
            /// </summary>
            private System.Timers.Timer _aTimer;
            /// <summary>
            /// The b invalidating
            /// </summary>
            private bool _bInvalidating = false;
            #endregion

            #region Constructor
            /// <summary>
            /// Initializes a new instance of the <see cref="FadeTimer"/> class.
            /// </summary>
            /// <param name="sender">The sender.</param>
            public FadeTimer(object sender)
            {
                _iTickCounter = 0;
                _iTickMaximum = 10;
                _ctParentControl = (UserControl)sender;
                _aTimer = new System.Timers.Timer();
                _iTickRate = _aTimer.Interval;
                _aTimer.SynchronizingObject = (ISynchronizeInvoke)sender;
                _aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets or sets the button dc.
            /// </summary>
            /// <value>The button dc.</value>
            public cStoreDc ButtonDc
            {
                get { return _cButtonDc; }
                set { _cButtonDc = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [capture screen].
            /// </summary>
            /// <value><c>true</c> if [capture screen]; otherwise, <c>false</c>.</value>
            public bool CaptureScreen
            {
                get { return _bCaptureScreen; }
                set { _bCaptureScreen = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="FadeTimer"/> is invalidating.
            /// </summary>
            /// <value><c>true</c> if invalidating; otherwise, <c>false</c>.</value>
            public bool Invalidating
            {
                get { return _bInvalidating; }
                set { _bInvalidating = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is reset.
            /// </summary>
            /// <value><c>true</c> if this instance is reset; otherwise, <c>false</c>.</value>
            public bool IsReset
            {
                get { return _bIsReset; }
                set { _bIsReset = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="FadeTimer"/> is cancel.
            /// </summary>
            /// <value><c>true</c> if cancel; otherwise, <c>false</c>.</value>
            public bool Cancel
            {
                get { return _bCancelTimer; }
                set { _bCancelTimer = value; }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="FadeTimer"/> is enabled.
            /// </summary>
            /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
            public bool Enabled
            {
                get { return _aTimer.Enabled; }
            }

            /// <summary>
            /// Gets or sets the fade style.
            /// </summary>
            /// <value>The fade style.</value>
            public FadeType FadeStyle
            {
                get { return _eFadeType; }
                set { _eFadeType = value; }
            }

            /// <summary>
            /// Gets or sets the interval.
            /// </summary>
            /// <value>The interval.</value>
            public double Interval
            {
                get { return _iTickRate; }
                set
                {
                    _iTickRate = value;
                    _aTimer.Interval = _iTickRate;
                }
            }

            /// <summary>
            /// Gets or sets the tick count.
            /// </summary>
            /// <value>The tick count.</value>
            public int TickCount
            {
                get { return _iTickCounter; }
                set { _iTickCounter = value; }
            }

            /// <summary>
            /// Gets or sets the tick maximum.
            /// </summary>
            /// <value>The tick maximum.</value>
            public int TickMaximum
            {
                get { return _iTickMaximum; }
                set { _iTickMaximum = value; }
            }
            #endregion

            #region Public Methods
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Reset();
                if (_cButtonDc != null)
                    _cButtonDc.Dispose();
                if (_aTimer != null)
                    _aTimer.Dispose();
                GC.SuppressFinalize(this);
            }

            /// <summary>
            /// Fades the specified ft.
            /// </summary>
            /// <param name="ft">The ft.</param>
            public void Fade(FadeType ft)
            {
                Cancel = false;
                IsReset = false;
                Invalidating = false;
                _eFadeType = ft;
                if (_eFadeType == FadeType.FadeIn)
                {
                    TickCount = 0;
                    if (CaptureScreen)
                        CaptureDc();
                }
                else if (_eFadeType == FadeType.FadeOut)
                {
                    TickCount = 10;
                }
                else if (_eFadeType == FadeType.FadeFast)
                {
                    TickCount = 10;
                }
                else if (_eFadeType == FadeType.Loop)
                {
                    TickMaximum = 100000;
                    TickCount = 0;
                    if (CaptureScreen)
                        CaptureDc();
                }
                _aTimer.Enabled = true;
            }

            /// <summary>
            /// Stops this instance.
            /// </summary>
            public void Stop()
            {
                _aTimer.Stop();
            }

            /// <summary>
            /// Resets this instance.
            /// </summary>
            public void Reset()
            {
                TickCount = 0;
                _eFadeType = FadeType.None;
                IsReset = true;
                _aTimer.Stop();
                _aTimer.Enabled = false;
            }
            #endregion

            #region Event Handlers
            /// <summary>
            /// Handles the <see cref="E:TimedEvent" /> event.
            /// </summary>
            /// <param name="source">The source.</param>
            /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
            private void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                if (Cancel)
                {
                    Invalidating = true;
                    if (Complete != null) Complete(this);
                    return;
                }
                else
                {
                    switch (_eFadeType)
                    {
                        case FadeType.FadeIn:
                            FadeIn();
                            break;
                        case FadeType.FadeFast:
                            FadeOut();
                            break;
                        case FadeType.FadeOut:
                            FadeOut();
                            break;
                        case FadeType.Loop:
                            FadeLoop();
                            break;
                    }
                }
            }
            #endregion

            #region private Methods
            /// <summary>
            /// Captures the dc.
            /// </summary>
            private void CaptureDc()
            {
                try
                {
                    _cButtonDc.Width = _ctParentControl.Width;
                    _cButtonDc.Height = _ctParentControl.Height;
                    if (_cButtonDc.Hdc != IntPtr.Zero)
                    {
                        using (Graphics g = Graphics.FromHdc(_cButtonDc.Hdc))
                        {
                            RECT boundedRect = new RECT();
                            GetWindowRect(_ctParentControl.Handle, ref boundedRect);
                            g.CopyFromScreen(boundedRect.Left, boundedRect.Top, 0, 0, new Size(_cButtonDc.Width, _cButtonDc.Height), CopyPixelOperation.SourceCopy);
                        }
                    }
                }
                catch { }
            }

            /// <summary>
            /// Fades the in.
            /// </summary>
            private void FadeIn()
            {
                if (TickCount < TickMaximum)
                {
                    TickCount++;
                    if (Tick != null)
                        Tick(this);
                }
                else
                {
                    TickCount = TickMaximum;
                }
            }

            /// <summary>
            /// Fades the loop.
            /// </summary>
            private void FadeLoop()
            {
                if (TickCount < TickMaximum)
                {
                    TickCount++;
                    if (Tick != null)
                        Tick(this);
                }
                else
                {
                    TickCount = TickMaximum;
                    Reset();
                    Invalidating = true;
                    if (Complete != null)
                        Complete(this);
                }
            }

            /// <summary>
            /// Fades the out.
            /// </summary>
            private void FadeOut()
            {
                if (TickCount > 0)
                {
                    if (_eFadeType == FadeType.FadeFast)
                    {
                        TickCount -= 2;
                        if (TickCount < 0)
                            TickCount = 0;
                    }
                    else
                    {
                        TickCount--;
                    }
                    if (Tick != null)
                        Tick(this);
                }
                else
                {
                    Reset();
                    Invalidating = true;
                    if (Complete != null)
                        Complete(this);
                }
            }

            /// <summary>
            /// Finalizes an instance of the <see cref="FadeTimer"/> class.
            /// </summary>
            ~FadeTimer()
            {
                Dispose();
            }
            #endregion
        }
        #endregion

        #region StoreDc
        /// <summary>
        /// DC buffer class
        /// </summary>
        internal class cStoreDc
        {
            #region API
            /// <summary>
            /// Creates the dca.
            /// </summary>
            /// <param name="lpszDriver">The LPSZ driver.</param>
            /// <param name="lpszDevice">The LPSZ device.</param>
            /// <param name="lpszOutput">The LPSZ output.</param>
            /// <param name="lpInitData">The lp initialize data.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateDCA([MarshalAs(UnmanagedType.LPStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPStr)]string lpszOutput, int lpInitData);

            /// <summary>
            /// Creates the DCW.
            /// </summary>
            /// <param name="lpszDriver">The LPSZ driver.</param>
            /// <param name="lpszDevice">The LPSZ device.</param>
            /// <param name="lpszOutput">The LPSZ output.</param>
            /// <param name="lpInitData">The lp initialize data.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateDCW([MarshalAs(UnmanagedType.LPWStr)]string lpszDriver, [MarshalAs(UnmanagedType.LPWStr)]string lpszDevice, [MarshalAs(UnmanagedType.LPWStr)]string lpszOutput, int lpInitData);

            /// <summary>
            /// Creates the dc.
            /// </summary>
            /// <param name="lpszDriver">The LPSZ driver.</param>
            /// <param name="lpszDevice">The LPSZ device.</param>
            /// <param name="lpszOutput">The LPSZ output.</param>
            /// <param name="lpInitData">The lp initialize data.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, int lpInitData);

            /// <summary>
            /// Creates the compatible dc.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            /// <summary>
            /// Creates the compatible bitmap.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="nWidth">Width of the n.</param>
            /// <param name="nHeight">Height of the n.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll")]
            private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

            /// <summary>
            /// Deletes the dc.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteDC(IntPtr hdc);

            /// <summary>
            /// Selects the object.
            /// </summary>
            /// <param name="hdc">The HDC.</param>
            /// <param name="hgdiobj">The hgdiobj.</param>
            /// <returns>IntPtr.</returns>
            [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true)]
            private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

            /// <summary>
            /// Deletes the object.
            /// </summary>
            /// <param name="hObject">The h object.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DeleteObject(IntPtr hObject);
            #endregion

            #region Fields
            /// <summary>
            /// The height
            /// </summary>
            private int _Height = 0;
            /// <summary>
            /// The width
            /// </summary>
            private int _Width = 0;
            /// <summary>
            /// The HDC
            /// </summary>
            private IntPtr _Hdc = IntPtr.Zero;
            /// <summary>
            /// The BMP
            /// </summary>
            private IntPtr _Bmp = IntPtr.Zero;
            /// <summary>
            /// The BMP old
            /// </summary>
            private IntPtr _BmpOld = IntPtr.Zero;
            #endregion

            #region Methods
            /// <summary>
            /// Gets the HDC.
            /// </summary>
            /// <value>The HDC.</value>
            public IntPtr Hdc
            {
                get { return _Hdc; }
            }

            /// <summary>
            /// Gets the h BMP.
            /// </summary>
            /// <value>The h BMP.</value>
            public IntPtr HBmp
            {
                get { return _Bmp; }
            }

            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            /// <value>The height.</value>
            public int Height
            {
                get { return _Height; }
                set
                {
                    if (_Height != value)
                    {
                        _Height = value;
                        ImageCreate(_Width, _Height);
                    }
                }
            }

            /// <summary>
            /// Gets or sets the width.
            /// </summary>
            /// <value>The width.</value>
            public int Width
            {
                get { return _Width; }
                set
                {
                    if (_Width != value)
                    {
                        _Width = value;
                        ImageCreate(_Width, _Height);
                    }
                }
            }

            /// <summary>
            /// Selects the image.
            /// </summary>
            /// <param name="image">The image.</param>
            public void SelectImage(Bitmap image)
            {
                if (Hdc != IntPtr.Zero && image != null)
                    SelectObject(Hdc, image.GetHbitmap());
            }

            /// <summary>
            /// Images the create.
            /// </summary>
            /// <param name="Width">The width.</param>
            /// <param name="Height">The height.</param>
            private void ImageCreate(int Width, int Height)
            {
                IntPtr pHdc = IntPtr.Zero;

                ImageDestroy();
                pHdc = CreateDCA("DISPLAY", "", "", 0);
                _Hdc = CreateCompatibleDC(pHdc);
                _Bmp = CreateCompatibleBitmap(pHdc, _Width, _Height);
                _BmpOld = SelectObject(_Hdc, _Bmp);
                if (_BmpOld == IntPtr.Zero)
                {
                    ImageDestroy();
                }
                else
                {
                    _Width = Width;
                    _Height = Height;
                }
                DeleteDC(pHdc);
                pHdc = IntPtr.Zero;
            }

            /// <summary>
            /// Images the destroy.
            /// </summary>
            private void ImageDestroy()
            {
                if (_BmpOld != IntPtr.Zero)
                {
                    SelectObject(_Hdc, _BmpOld);
                    _BmpOld = IntPtr.Zero;
                }
                if (_Bmp != IntPtr.Zero)
                {
                    DeleteObject(_Bmp);
                    _Bmp = IntPtr.Zero;
                }
                if (_Hdc != IntPtr.Zero)
                {
                    DeleteDC(_Hdc);
                    _Hdc = IntPtr.Zero;
                }
            }

            /// <summary>
            /// Disposes this instance.
            /// </summary>
            public void Dispose()
            {
                ImageDestroy();
            }
            #endregion
        }
        #endregion
    }

    #endregion

    #region Designer Generated Code

    partial class ZeroitMediaSlider
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MediaSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MediaSlider";
            this.ResumeLayout(false);

        }

        #endregion
    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMediaSliderDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMediaSliderDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitMediaSliderSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitMediaSliderSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMediaSliderSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMediaSlider colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMediaSliderSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMediaSliderSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMediaSlider;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.

        /// <summary>
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitMediaSliderSmartTagActionList"/> is animated.
        /// </summary>
        /// <value><c>true</c> if animated; otherwise, <c>false</c>.</value>
        public bool Animated
        {
            get
            {
                return colUserControl.Animated;
            }
            set
            {
                GetPropertyByName("Animated").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public Zeroit.Framework.Progress.Sliders.ZeroitMediaSlider.AnimateSpeed AnimationSpeed
        {
            get
            {
                return colUserControl.AnimationSpeed;
            }
            set
            {
                GetPropertyByName("AnimationSpeed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the animation.
        /// </summary>
        /// <value>The size of the animation.</value>
        public float AnimationSize
        {
            get
            {
                return colUserControl.AnimationSize;
            }
            set
            {
                GetPropertyByName("AnimationSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the background image.
        /// </summary>
        /// <value>The background image.</value>
        public Bitmap BackgroundImage
        {
            get
            {
                return colUserControl.BackgroundImage;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the button accent.
        /// </summary>
        /// <value>The color of the button accent.</value>
        public Color ButtonAccentColor
        {
            get
            {
                return colUserControl.ButtonAccentColor;
            }
            set
            {
                GetPropertyByName("ButtonAccentColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the button border.
        /// </summary>
        /// <value>The color of the button border.</value>
        public Color ButtonBorderColor
        {
            get
            {
                return colUserControl.ButtonBorderColor;
            }
            set
            {
                GetPropertyByName("ButtonBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the button.
        /// </summary>
        /// <value>The color of the button.</value>
        public Color ButtonColor
        {
            get
            {
                return colUserControl.ButtonColor;
            }
            set
            {
                GetPropertyByName("ButtonColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button corner radius.
        /// </summary>
        /// <value>The button corner radius.</value>
        public uint ButtonCornerRadius
        {
            get
            {
                return colUserControl.ButtonCornerRadius;
            }
            set
            {
                GetPropertyByName("ButtonCornerRadius").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the button.
        /// </summary>
        /// <value>The size of the button.</value>
        public Size ButtonSize
        {
            get
            {
                return colUserControl.ButtonSize;
            }
            set
            {
                GetPropertyByName("ButtonSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the button style.
        /// </summary>
        /// <value>The button style.</value>
        public Zeroit.Framework.Progress.Sliders.ZeroitMediaSlider.ButtonType ButtonStyle
        {
            get
            {
                return colUserControl.ButtonStyle;
            }
            set
            {
                GetPropertyByName("ButtonStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inited.
        /// </summary>
        /// <value><c>true</c> if this instance is inited; otherwise, <c>false</c>.</value>
        public bool IsInited
        {
            get
            {
                return colUserControl.IsInited;
            }
            set
            {
                GetPropertyByName("IsInited").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the large change.
        /// </summary>
        /// <value>The large change.</value>
        public int LargeChange
        {
            get
            {
                return colUserControl.LargeChange;
            }
            set
            {
                GetPropertyByName("LargeChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum size.
        /// </summary>
        /// <value>The maximum size.</value>
        public Size MaxSize
        {
            get
            {
                return colUserControl.MaxSize;
            }
            set
            {
                GetPropertyByName("MaxSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum size.
        /// </summary>
        /// <value>The minimum size.</value>
        public Size MinSize
        {
            get
            {
                return colUserControl.MinSize;
            }
            set
            {
                GetPropertyByName("MinSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get
            {
                return colUserControl.Orientation;
            }
            set
            {
                GetPropertyByName("Orientation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show button on hover].
        /// </summary>
        /// <value><c>true</c> if [show button on hover]; otherwise, <c>false</c>.</value>
        public bool ShowButtonOnHover
        {
            get
            {
                return colUserControl.ShowButtonOnHover;
            }
            set
            {
                GetPropertyByName("ShowButtonOnHover").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the slider fly out.
        /// </summary>
        /// <value>The slider fly out.</value>
        public Zeroit.Framework.Progress.Sliders.ZeroitMediaSlider.FlyOutStyle SliderFlyOut
        {
            get
            {
                return colUserControl.SliderFlyOut;
            }
            set
            {
                GetPropertyByName("SliderFlyOut").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the small change.
        /// </summary>
        /// <value>The small change.</value>
        public int SmallChange
        {
            get
            {
                return colUserControl.SmallChange;
            }
            set
            {
                GetPropertyByName("SmallChange").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [smooth scrolling].
        /// </summary>
        /// <value><c>true</c> if [smooth scrolling]; otherwise, <c>false</c>.</value>
        public bool SmoothScrolling
        {
            get
            {
                return colUserControl.SmoothScrolling;
            }
            set
            {
                GetPropertyByName("SmoothScrolling").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        public Color TickColor
        {
            get
            {
                return colUserControl.TickColor;
            }
            set
            {
                GetPropertyByName("TickColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the tick style.
        /// </summary>
        /// <value>The tick style.</value>
        public TickStyle TickStyle
        {
            get
            {
                return colUserControl.TickStyle;
            }
            set
            {
                GetPropertyByName("TickStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the tick.
        /// </summary>
        /// <value>The type of the tick.</value>
        public Zeroit.Framework.Progress.Sliders.ZeroitMediaSlider.TickMode TickType
        {
            get
            {
                return colUserControl.TickType;
            }
            set
            {
                GetPropertyByName("TickType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the track border.
        /// </summary>
        /// <value>The color of the track border.</value>
        public Color TrackBorderColor
        {
            get
            {
                return colUserControl.TrackBorderColor;
            }
            set
            {
                GetPropertyByName("TrackBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the track depth.
        /// </summary>
        /// <value>The track depth.</value>
        public int TrackDepth
        {
            get
            {
                return colUserControl.TrackDepth;
            }
            set
            {
                GetPropertyByName("TrackDepth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the track fill.
        /// </summary>
        /// <value>The color of the track fill.</value>
        public Color TrackFillColor
        {
            get
            {
                return colUserControl.TrackFillColor;
            }
            set
            {
                GetPropertyByName("TrackFillColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the track progress.
        /// </summary>
        /// <value>The color of the track progress.</value>
        public Color TrackProgressColor
        {
            get
            {
                return colUserControl.TrackProgressColor;
            }
            set
            {
                GetPropertyByName("TrackProgressColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [track shadow].
        /// </summary>
        /// <value><c>true</c> if [track shadow]; otherwise, <c>false</c>.</value>
        public bool TrackShadow
        {
            get
            {
                return colUserControl.TrackShadow;
            }
            set
            {
                GetPropertyByName("TrackShadow").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the track shadow.
        /// </summary>
        /// <value>The color of the track shadow.</value>
        public Color TrackShadowColor
        {
            get
            {
                return colUserControl.TrackShadowColor;
            }
            set
            {
                GetPropertyByName("TrackShadowColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the track style.
        /// </summary>
        /// <value>The track style.</value>
        public Zeroit.Framework.Progress.Sliders.ZeroitMediaSlider.TrackType TrackStyle
        {
            get
            {
                return colUserControl.TrackStyle;
            }
            set
            {
                GetPropertyByName("TrackStyle").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        #endregion

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("ShowButtonOnHover",
                                 "Show Button On Hover", "Appearance",
                                 "Shows the button when hovered."));

            items.Add(new DesignerActionPropertyItem("TrackShadow",
                                 "Track Shadow", "Appearance",
                                 "Shows the track shadow."));

            items.Add(new DesignerActionPropertyItem("SmoothScrolling",
                                 "Smooth Scrolling", "Appearance",
                                 "Allow smooth scrolling effect."));

            items.Add(new DesignerActionPropertyItem("Animated",
                                 "Animated", "Appearance",
                                 "Allow the control to be animated."));

            items.Add(new DesignerActionPropertyItem("AnimationSpeed",
                                 "Animation Speed", "Appearance",
                                 "Sets the speed of the animation."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            //items.Add(new DesignerActionPropertyItem("ForeColor",
            //                     "Fore Color", "Appearance",
            //                     "Selects the foreground color."));


            items.Add(new DesignerActionPropertyItem("AnimationSize",
                                 "Animation Size", "Appearance",
                                 "Sets the size of the animation."));

            //items.Add(new DesignerActionPropertyItem("BackgroundImage",
            //                     "Background Image", "Appearance",
            //                     "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("ButtonAccentColor",
                                 "Button Accent Color", "Appearance",
                                 "Sets the button accent color."));

            items.Add(new DesignerActionPropertyItem("ButtonBorderColor",
                                 "Button Border Color", "Appearance",
                                 "Sets the button border color."));

            items.Add(new DesignerActionPropertyItem("TickColor",
                                 "Tick Color", "Appearance",
                                 "Sets the tick color."));

            items.Add(new DesignerActionPropertyItem("TrackBorderColor",
                                 "Track Border Color", "Appearance",
                                 "Sets the track border color of the control."));

            items.Add(new DesignerActionPropertyItem("TrackFillColor",
                                 "Track Fill Color", "Appearance",
                                 "Sets the track fill color of the control."));

            items.Add(new DesignerActionPropertyItem("TrackProgressColor",
                                 "Track Progress Color", "Appearance",
                                 "Sets the track progress color."));

            items.Add(new DesignerActionPropertyItem("TrackShadowColor",
                                 "Track Shadow Color", "Appearance",
                                 "Sets the track shadow color."));

            items.Add(new DesignerActionPropertyItem("ButtonCornerRadius",
                                 "Button Corner Radius", "Appearance",
                                 "Sets the button corner radius."));

            items.Add(new DesignerActionPropertyItem("ButtonSize",
                                 "Button Size", "Appearance",
                                 "Sets the button size of the control."));

            items.Add(new DesignerActionPropertyItem("ButtonStyle",
                                 "Button Style", "Appearance",
                                 "Sets the button style."));

            //items.Add(new DesignerActionPropertyItem("IsInited",
            //                     "Is Inited", "Appearance",
            //                     "Type few characters to filter Cities."));

            items.Add(new DesignerActionPropertyItem("LargeChange",
                                 "Large Change", "Appearance",
                                 "Sets the largest change in value."));

            items.Add(new DesignerActionPropertyItem("SmallChange",
                                 "Small Change", "Appearance",
                                 "Sets the smallest change."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value."));

            //items.Add(new DesignerActionPropertyItem("MaxSize",
            //                     "Max Size", "Appearance",
            //                     "Sets the max size of the control."));

            items.Add(new DesignerActionPropertyItem("Orientation",
                                 "Orientation", "Appearance",
                                 "Sets the orientation. Either vertical or horizontal."));


            items.Add(new DesignerActionPropertyItem("SliderFlyOut",
                                 "Slider Fly Out", "Appearance",
                                 "Sets the kind of slider flyout."));

            items.Add(new DesignerActionPropertyItem("TickStyle",
                                 "Tick Style", "Appearance",
                                 "Sets the tick style."));

            items.Add(new DesignerActionPropertyItem("TickType",
                                 "Tick Type", "Appearance",
                                 "Sets the tick type of the control."));

            items.Add(new DesignerActionPropertyItem("TrackDepth",
                                 "Track Depth", "Appearance",
                                 "Sets the track depth."));

            items.Add(new DesignerActionPropertyItem("TrackStyle",
                                 "Track Style", "Appearance",
                                 "Sets the track depth."));

            //items.Add(new DesignerActionPropertyItem("Value",
            //                     "Value", "Appearance",
            //                     "Type few characters to filter Cities."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion

    #endregion
}
