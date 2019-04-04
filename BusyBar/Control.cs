// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 12-21-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="Control.cs" company="Zeroit Dev Technologies">
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Design;
using System.Diagnostics;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitBusyBar
    //-----------------------------------------------------------------------------
    // ZeroitBusyBar

    /// <summary>
    /// A class collection for rendering a progressbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    /// <seealso cref="System.ComponentModel.ISupportInitialize" />
    /// <seealso cref="System.ICloneable" />
    //	[ DesignerCategory( "Code" ) ]
    //	[ DesignerCategory( "Component" ) ]
    [DefaultProperty("Value")]
    //	[ Bindable( false ) ]
    [Designer(typeof(ZeroitBusyBar.ZeroitBusyBarDesigner))]
    [ToolboxBitmap(typeof(ZeroitBusyBarResFinder), ZeroitBusyBarResFinder.DefaultNamespace + ".Bitmaps.ZeroitBusyBar.bmp")]
    public class ZeroitBusyBar : Control, ISupportInitialize, ICloneable
    {
        /// <summary>
        /// The work
        /// </summary>
        private Work _Work = null;

        /// <summary>
        /// The busy bar perform step delegate
        /// </summary>
        public BusyBarPerformStepDelegate _BusyBarPerformStepDelegate = new BusyBarPerformStepDelegate(BusyBarPerformStep);

        /// <summary>
        /// Busies the bar perform step.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void BusyBarPerformStep(BusyBarPerformStepArgs args)
        {
            args.BusyBar.PerformStep();
        }

        /// <summary>
        /// The progress bar perform step delegate
        /// </summary>
        public ProgressBarPerformStepDelegate _ProgressBarPerformStepDelegate = new ProgressBarPerformStepDelegate(ProgressBarPerformStep);

        /// <summary>
        /// Progresses the bar perform step.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void ProgressBarPerformStep(ProgressBarPerformStepArgs args)
        {
            args.ProgressBar.PerformStep();
            if (args.ProgressBar.Value >= 100) args.ProgressBar.Value = 0;
        }

        /// <summary>
        /// Handles the Click event of the _Start control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void _Start_Click(object sender, System.EventArgs e)
        {


            if (_Work == null)
            {
                _Work = new Work();
                _Work.Step += new EventHandler(_Work_Step);
                _Work.Start();
            }
        }

        /// <summary>
        /// Handles the Click event of the _Stop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void _Stop_Click(object sender, System.EventArgs e)
        {
            if (_Work != null)
            {
                _Work.Stop();
                _Work = null;
            }


        }

        /// <summary>
        /// Handles the Closing event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_Work != null)
            {
                _Work.Stop();
                _Work.Thread.Join();
            }
        }

        /// <summary>
        /// Handles the Step event of the _Work control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void _Work_Step(object sender, EventArgs args)
        {
            ZeroitBusyBar busy = new ZeroitBusyBar();

            ZeroitBusyBar _BusyBarHorizontal = new ZeroitBusyBar();

            ZeroitBusyBar _BusyBarVertical = new ZeroitBusyBar();
            BeginInvoke(_BusyBarPerformStepDelegate, new object[] { new BusyBarPerformStepArgs(busy) });
            BeginInvoke(_BusyBarPerformStepDelegate, new object[] { new BusyBarPerformStepArgs(_BusyBarHorizontal) });
            //BeginInvoke(_BusyBarPerformStepDelegate, new object[] { new BusyBarPerformStepArgs(_BusyBarVertical) });

            //BeginInvoke(_ProgressBarPerformStepDelegate, new object[] { new ProgressBarPerformStepArgs(_ProgressBar1) });
        }

        //-----------------------------------------------------------------------------
        // ZeroitBusyBarDesigner

        /// <summary>
        /// Class ZeroitBusyBarDesigner.
        /// </summary>
        /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
        public class ZeroitBusyBarDesigner : ControlDesigner
        {
            /// <summary>
            /// Adjusts the set of properties the component exposes through a <see cref="T:System.ComponentModel.TypeDescriptor" />.
            /// </summary>
            /// <param name="properties">An <see cref="T:System.Collections.IDictionary" /> containing the properties for the class of the component.</param>
            protected override void PreFilterProperties(IDictionary properties)
            {
                //				MessageBox.Show( "ZeroitBusyBarDesigner.PreFilterProperties" );

                base.PreFilterProperties(properties);

                properties.Remove("DataBindings");
                properties.Remove("Tag");
            }
        }

        //-----------------------------------------------------------------------------
        // statics

        /// <summary>
        /// The event border style
        /// </summary>
        private static readonly object EventBorderStyle = new object();
        /// <summary>
        /// The event margin
        /// </summary>
        private static readonly object EventMargin = new object();
        /// <summary>
        /// The event corner radius
        /// </summary>
        private static readonly object EventCornerRadius = new object();
        /// <summary>
        /// The event minimum
        /// </summary>
        private static readonly object EventMinimum = new object();
        /// <summary>
        /// The event maximum
        /// </summary>
        private static readonly object EventMaximum = new object();
        /// <summary>
        /// The event value
        /// </summary>
        private static readonly object EventValue = new object();
        /// <summary>
        /// The event step
        /// </summary>
        private static readonly object EventStep = new object();
        /// <summary>
        /// The event pin
        /// </summary>
        private static readonly object EventPin = new object();
        /// <summary>
        /// The event reverse
        /// </summary>
        private static readonly object EventReverse = new object();
        /// <summary>
        /// The event bounce
        /// </summary>
        private static readonly object EventBounce = new object();
        /// <summary>
        /// The event draw bar
        /// </summary>
        private static readonly object EventDrawBar = new object();
        /// <summary>
        /// The event vertical
        /// </summary>
        private static readonly object EventVertical = new object();
        /// <summary>
        /// The event wrap initial
        /// </summary>
        private static readonly object EventWrapInitial = new object();
        /// <summary>
        /// The event wrap
        /// </summary>
        private static readonly object EventWrap = new object();
        /// <summary>
        /// The event painter preset
        /// </summary>
        private static readonly object EventPainterPreset = new object();
        /// <summary>
        /// The event painter object
        /// </summary>
        private static readonly object EventPainterObject = new object();
        //		private static readonly object EventPainterWorker  = new object();

        //-----------------------------------------------------------------------------
        // Fields

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// The border style
        /// </summary>
        private BorderStyle _BorderStyle = BorderStyle.FixedSingle;
        /// <summary>
        /// The margin
        /// </summary>
        private int _Margin = 2;
        /// <summary>
        /// The corner radius
        /// </summary>
        private int _CornerRadius = 9;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum = 0;
        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum = 100;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value = 0;
        /// <summary>
        /// The step
        /// </summary>
        private int _Step = 1;
        /// <summary>
        /// The pin
        /// </summary>
        private Pins _Pin = Pins.None;
        /// <summary>
        /// The reverse
        /// </summary>
        private bool _Reverse = false;
        /// <summary>
        /// The bounce
        /// </summary>
        private bool _Bounce = false;
        /// <summary>
        /// The draw bar
        /// </summary>
        private bool _DrawBar = true;
        /// <summary>
        /// The vertical
        /// </summary>
        private bool _Vertical = false;
        /// <summary>
        /// The wrap initial
        /// </summary>
        private bool _WrapInitial = false;
        /// <summary>
        /// The wrap
        /// </summary>
        private bool _Wrap = true;
        /// <summary>
        /// The painter preset
        /// </summary>
        private PainterPresets _PainterPreset = PainterPresets.None;
        /// <summary>
        /// The painter object
        /// </summary>
        private IPainter _PainterObject = null;

        /// <summary>
        /// The painter worker
        /// </summary>
        private IPainter _PainterWorker = null;

        /// <summary>
        /// The initialising
        /// </summary>
        private bool _Initialising = false;
        /// <summary>
        /// The initialize set worker
        /// </summary>
        private bool _InitSetWorker = false;
        /// <summary>
        /// The bouncing
        /// </summary>
        private bool _Bouncing = false;

        //-----------------------------------------------------------------------------
        // Events

        /// <summary>
        /// Occurs when [border style changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler BorderStyleChanged { add { Events.AddHandler(EventBorderStyle, value); } remove { Events.RemoveHandler(EventBorderStyle, value); } }
        /// <summary>
        /// Occurs when the control's margin changes.
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler MarginChanged { add { Events.AddHandler(EventMargin, value); } remove { Events.RemoveHandler(EventMargin, value); } }
        /// <summary>
        /// Occurs when [corner radius changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler CornerRadiusChanged { add { Events.AddHandler(EventCornerRadius, value); } remove { Events.RemoveHandler(EventCornerRadius, value); } }
        /// <summary>
        /// Occurs when [minimum changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler MinimumChanged { add { Events.AddHandler(EventMinimum, value); } remove { Events.RemoveHandler(EventMinimum, value); } }
        /// <summary>
        /// Occurs when [maximum changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler MaximumChanged { add { Events.AddHandler(EventMaximum, value); } remove { Events.RemoveHandler(EventMaximum, value); } }
        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler ValueChanged { add { Events.AddHandler(EventValue, value); } remove { Events.RemoveHandler(EventValue, value); } }
        /// <summary>
        /// Occurs when [step changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler StepChanged { add { Events.AddHandler(EventStep, value); } remove { Events.RemoveHandler(EventStep, value); } }
        /// <summary>
        /// Occurs when [pin changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler PinChanged { add { Events.AddHandler(EventPin, value); } remove { Events.RemoveHandler(EventPin, value); } }
        /// <summary>
        /// Occurs when [reverse changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler ReverseChanged { add { Events.AddHandler(EventReverse, value); } remove { Events.RemoveHandler(EventReverse, value); } }
        /// <summary>
        /// Occurs when [bounce changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler BounceChanged { add { Events.AddHandler(EventBounce, value); } remove { Events.RemoveHandler(EventBounce, value); } }
        /// <summary>
        /// Occurs when [draw bar changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler DrawBarChanged { add { Events.AddHandler(EventDrawBar, value); } remove { Events.RemoveHandler(EventDrawBar, value); } }
        /// <summary>
        /// Occurs when [vertical changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler VerticalChanged { add { Events.AddHandler(EventVertical, value); } remove { Events.RemoveHandler(EventVertical, value); } }
        /// <summary>
        /// Occurs when [wrap initial changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler WrapInitialChanged { add { Events.AddHandler(EventWrapInitial, value); } remove { Events.RemoveHandler(EventWrapInitial, value); } }
        /// <summary>
        /// Occurs when [wrap changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler WrapChanged { add { Events.AddHandler(EventWrap, value); } remove { Events.RemoveHandler(EventWrap, value); } }
        /// <summary>
        /// Occurs when [painter preset changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler PainterPresetChanged { add { Events.AddHandler(EventPainterPreset, value); } remove { Events.RemoveHandler(EventPainterPreset, value); } }
        /// <summary>
        /// Occurs when [painter object changed].
        /// </summary>
        [Category("1.ZeroitBusyBar")]
        public event EventHandler PainterObjectChanged { add { Events.AddHandler(EventPainterObject, value); } remove { Events.RemoveHandler(EventPainterObject, value); } }
        //		[ Category( "1.ZeroitBusyBar" ) ] public event EventHandler PainterWorkerChanged  { add { Events.AddHandler( EventPainterWorker , value ); } remove { Events.RemoveHandler( EventPainterWorker , value ); } }

        //-----------------------------------------------------------------------------
        // ISupportInitialize Members

        /// <summary>
        /// Signals the object that initialization is starting.
        /// </summary>
        public void BeginInit()
        {
            Debug.Assert(!_Initialising);

            _Initialising = true;
        }

        /// <summary>
        /// Signals the object that initialization is complete.
        /// </summary>
        public void EndInit()
        {
            Debug.Assert(_Initialising);

            _Initialising = false;

            OnEndInit();
        }

        //-----------------------------------------------------------------------------
        // Defaults

        /// <summary>
        /// Sets the defaults.
        /// </summary>
        public void SetDefaults()
        {
            if (_Initialising) { Debug.Assert(false); return; }

            BackColor = Color.White;

            //	no		BeginInit();
            _Initialising = true;

            BorderStyle = BorderStyle.FixedSingle;
            Margin = 2;
            CornerRadius = 9;
            Minimum = 0;
            Maximum = 100;
            Value = 25;
            Pin = Pins.None;
            Reverse = false;
            Bounce = false;
            DrawBar = true;
            //			Vertical = false;
            WrapInitial = false;
            Wrap = true;
            //			PainterPreset  = PainterPresets.None;
            //			PainterObject  = null;
            //			PainterWorker  = null;

            //	no		EndInit();
            _Initialising = false;

            SetRegion();
        }

        //-----------------------------------------------------------------------------
        // Properties

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value>The border style.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(BorderStyle.FixedSingle)]
        //		[ RefreshProperties( RefreshProperties.Repaint ) ]
        [Description("The style of the control's border")]
        public BorderStyle BorderStyle
        {
            get { return _BorderStyle; }

            set
            {
                _BorderStyle = value;

                OnBorderStyleChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the space between controls.
        /// </summary>
        /// <value>The margin.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(2)]
        [Description("The space between the border and the bar")]
        public int Margin
        {
            get { return _Margin; }

            set
            {
                _Margin = value;

                OnMarginChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(9)]
        //		[ RefreshProperties( RefreshProperties.Repaint ) ]
        [Description("The radius of the control's corners")]
        public int CornerRadius
        {
            get { return _CornerRadius; }

            set
            {
                _CornerRadius = value;

                SetRegion();

                OnCornerRadiusChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="ArgumentException">Minimum must be less than Value</exception>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(0)]
        [Description("The lower bound")]
        public int Minimum
        {
            get { return _Minimum; }

            set
            {
                if (!_Initialising)
                    if (value > _Value)
                        throw new ArgumentException(
                            "Minimum must be less than Value");

                _Minimum = value;

                OnMinimumChanged(EventArgs.Empty);

                Invalidate();
            }

        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="ArgumentException">Maximum must be greater than Value</exception>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(100)]
        [Description("The upper bound")]
        public int Maximum
        {
            get { return _Maximum; }

            set
            {
                if (!_Initialising)
                    if (value < _Value)
                        throw new ArgumentException(
                            "Maximum must be greater than Value");

                _Maximum = value;

                OnMaximumChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="ArgumentException">Value must be between Minimum and Maximum</exception>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(0)]
        [Description("The current value")]
        public int Value
        {
            get { return _Value; }

            set
            {
                if (!_Initialising)
                    if (value < _Minimum || value > _Maximum)
                        throw new ArgumentException(
                            "Value must be between Minimum and Maximum");

                _Value = value;

                OnValueChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(1)]
        [Description("The size of each step")]
        public int Step
        {
            get { return _Step; }

            set
            {
                _Step = value;

                OnStepChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the pin.
        /// </summary>
        /// <value>The pin.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(Pins.None)]
        [Description("Whether the bar is anchored")]
        public Pins Pin
        {
            get { return _Pin; }

            set
            {
                _Pin = value;

                OnPinChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitBusyBar"/> is reverse.
        /// </summary>
        /// <value><c>true</c> if reverse; otherwise, <c>false</c>.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(false)]
        [Description("Set to true to go right-to-left or bottom-to-top")]
        public bool Reverse
        {
            get { return _Reverse; }

            set
            {
                _Reverse = value;

                OnReverseChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitBusyBar"/> is bounce.
        /// </summary>
        /// <value><c>true</c> if bounce; otherwise, <c>false</c>.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(false)]
        [Description("Boing !")]
        public bool Bounce
        {
            get { return _Bounce; }

            set
            {
                _Bounce = value;

                OnBounceChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [draw bar].
        /// </summary>
        /// <value><c>true</c> if [draw bar]; otherwise, <c>false</c>.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(true)]
        [Description("Enable or disable the bar drawing")]
        public bool DrawBar
        {
            get { return _DrawBar; }

            set
            {
                _DrawBar = value;

                OnDrawBarChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitBusyBar"/> is vertical.
        /// </summary>
        /// <value><c>true</c> if vertical; otherwise, <c>false</c>.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(false)]
        [Description("Control orientation")]
        public bool Vertical
        {
            get { return _Vertical; }

            set
            {
                _Vertical = value;

                OnVerticalChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [wrap initial].
        /// </summary>
        /// <value><c>true</c> if [wrap initial]; otherwise, <c>false</c>.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(false)]
        [Description("Initial wrap around")]
        public bool WrapInitial
        {
            get { return _WrapInitial; }

            set
            {
                _WrapInitial = value;

                OnWrapInitialChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitBusyBar"/> is wrap.
        /// </summary>
        /// <value><c>true</c> if wrap; otherwise, <c>false</c>.</value>
        [Category("1.ZeroitBusyBar")]
        [DefaultValue(true)]
        [Description("Wrap around")]
        public bool Wrap
        {
            get { return _Wrap; }

            set
            {
                _Wrap = value;

                OnWrapChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the painter preset.
        /// </summary>
        /// <value>The painter preset.</value>
        [Category("2.Painter")]
        [DefaultValue(PainterPresets.None)]
        [Description("Painter preset")]
        [RefreshProperties(RefreshProperties.All)]
        public PainterPresets PainterPreset
        {
            get { return _PainterPreset; }

            set
            {
                _PainterPreset = value;

                if (_PainterPreset != PainterPresets.None)
                {
                    _PainterObject = null;
                    //					_PainterWorker = null;
                }

                if (!_Initialising) SetWorker();
                else
                    _InitSetWorker = true;

                OnPainterPresetChanged(EventArgs.Empty);
                OnPainterObjectChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the painter object.
        /// </summary>
        /// <value>The painter object.</value>
        [Category("2.Painter")]
        [DefaultValue(null)]
        [Description("Painter object")]
        [RefreshProperties(RefreshProperties.All)]
        public IPainter PainterObject
        {
            get
            {
                return _PainterObject;
            }

            set
            {
                _PainterObject = value;

                if (_PainterObject != null)
                {
                    _PainterPreset = PainterPresets.None;
                    //					_PainterWorker = null;

                    _PainterObject.ZeroitBusyBar = this;
                }

                if (!_Initialising) SetWorker();
                else
                    _InitSetWorker = true;

                OnPainterPresetChanged(EventArgs.Empty);
                OnPainterObjectChanged(EventArgs.Empty);

                Invalidate();
            }
        }

        /// <summary>
        /// Gets the painter worker.
        /// </summary>
        /// <value>The painter worker.</value>
        [Browsable(false)]
        [Category("2.Painter")]
        [DefaultValue(null)]
        [Description("The worker painter object")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IPainter PainterWorker
        {
            get { return _PainterWorker; }
        }

        //-----------------------------------------------------------------------------
        // OnEndInit

        /// <summary>
        /// Called when [end initialize].
        /// </summary>
        private void OnEndInit()
        {
            ValidateRange();

            if (_InitSetWorker)
            {
                _InitSetWorker = false;

                SetWorker();
            }

            //			SetRegion();


            Invalidate();
        }

        /// <summary>
        /// Validates the range.
        /// </summary>
        /// <exception cref="ArgumentException">Value must be between Minimum and Maximum</exception>
        private void ValidateRange()
        {
            if (_Value < _Minimum || _Value > _Maximum)
                throw new ArgumentException(
                    "Value must be between Minimum and Maximum");
        }

        //-----------------------------------------------------------------------------
        // SetWorker

        /// <summary>
        /// Sets the worker.
        /// </summary>
        private void SetWorker()
        {
            if (_PainterObject != null)
                SetWorkerFromObject();
            else
                SetWorkerFromPreset();
        }

        /// <summary>
        /// Sets the worker from preset.
        /// </summary>
        private void SetWorkerFromPreset()
        {
            switch (_PainterPreset)
            {
                case PainterPresets.None:
                    _PainterWorker = null;
                    break;

                case PainterPresets.Line:
                    _PainterWorker = new ZeroitBusyBarPainterLine(this, false);
                    break;

                case PainterPresets.XP:
                    _PainterWorker = new ZeroitBusyBarPainterXP(this, false);
                    break;

                case PainterPresets.PathGradient:
                    _PainterWorker = new ZeroitBusyBarPainterPathGradient(this, false);
                    break;

                case PainterPresets.Clock:
                    _PainterWorker = new ZeroitBusyBarPainterClock(this, false);
                    break;

                case PainterPresets.Sillyscope:
                    _PainterWorker = new ZeroitBusyBarPainterSillyscope(this, false);
                    break;

                case PainterPresets.Install:
                    _PainterWorker = new ZeroitBusyBarPainterInstall(this, false);
                    break;

                case PainterPresets.FrustratoBar:
                    _PainterWorker = new ZeroitBusyBarPainterFrustratoBar(this, false);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }
        }

        /// <summary>
        /// Sets the worker from object.
        /// </summary>
        private void SetWorkerFromObject()
        {
            _PainterWorker = _PainterObject;
        }

        //-----------------------------------------------------------------------------
        // Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBar"/> class.
        /// </summary>
        public ZeroitBusyBar()
        {
            InitializeComponent();

            DoSetStyle();


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitBusyBar"/> class.
        /// </summary>
        /// <param name="o">The o.</param>
        protected ZeroitBusyBar(ZeroitBusyBar o)
        {
            InitializeComponent();

            CopyThis(o);
        }

        /// <summary>
        /// Copies the this.
        /// </summary>
        /// <param name="o">The o.</param>
        private void CopyThis(ZeroitBusyBar o)
        {
            BackColor = o.BackColor;
            ForeColor = o.ForeColor;

            _BorderStyle = o._BorderStyle;
            _Margin = o._Margin;
            _CornerRadius = o._CornerRadius;
            _Minimum = o._Minimum;
            _Maximum = o._Maximum;
            _Value = o._Value;
            _Step = o._Step;
            _Pin = o._Pin;
            _Reverse = o._Reverse;
            _Bounce = o._Bounce;
            _DrawBar = o._DrawBar;
            _Vertical = o._Vertical;
            _WrapInitial = o._WrapInitial;
            _Wrap = o._Wrap;
            _PainterPreset = o._PainterPreset;

            if (o._PainterObject == null) _PainterObject = null;
            else
            {
                _PainterObject = (IPainter)o._PainterObject.Clone();
                _PainterObject.ZeroitBusyBar = this;
            }

            if (o._PainterWorker == null) _PainterWorker = null;
            else
            {
                _PainterWorker = (IPainter)o._PainterWorker.Clone();
                _PainterWorker.ZeroitBusyBar = this;
            }

            //			SetWorker();

            DoSetStyle();
        }

        /// <summary>
        /// Creates the copy.
        /// </summary>
        /// <returns>ZeroitBusyBar.</returns>
        public virtual ZeroitBusyBar CreateCopy()
        {
            return new ZeroitBusyBar(this);
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public virtual object Clone()
        {
            return CreateCopy();
        }

        /// <summary>
        /// Does the set style.
        /// </summary>
        private void DoSetStyle()
        {
            SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.Opaque |
                ControlStyles.ResizeRedraw,
                true);
        }

        //		protected override CreateParams CreateParams
        //		{
        //			get
        //			{
        //				CreateParams p = base.CreateParams;
        //
        //				if ( _BorderStyle == BorderStyle.Fixed3D )
        //					p.ExStyle |= 0x200;
        //
        //				return p;
        //			}
        //		}


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        //-----------------------------------------------------------------------------
        // InitializeComponent

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ZeroitBusyBar
            // 
            this.Resize += new System.EventHandler(this.ZeroitBusyBar_Resize);

        }
        #endregion

        //-----------------------------------------------------------------------------
        // Events

        /// <summary>
        /// Handles the <see cref="E:BorderStyleChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnBorderStyleChanged(EventArgs e) { EventHandler h = Events[EventBorderStyle] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MarginChanged" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnMarginChanged(EventArgs e) { EventHandler h = Events[EventMargin] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:CornerRadiusChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCornerRadiusChanged(EventArgs e) { EventHandler h = Events[EventCornerRadius] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:MinimumChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnMinimumChanged(EventArgs e) { EventHandler h = Events[EventMinimum] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:MaximumChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnMaximumChanged(EventArgs e) { EventHandler h = Events[EventMaximum] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:ValueChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnValueChanged(EventArgs e) { EventHandler h = Events[EventValue] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:StepChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnStepChanged(EventArgs e) { EventHandler h = Events[EventStep] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:PinChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnPinChanged(EventArgs e) { EventHandler h = Events[EventPin] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:ReverseChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnReverseChanged(EventArgs e) { EventHandler h = Events[EventReverse] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:BounceChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnBounceChanged(EventArgs e) { EventHandler h = Events[EventBounce] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:DrawBarChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnDrawBarChanged(EventArgs e) { EventHandler h = Events[EventDrawBar] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:VerticalChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnVerticalChanged(EventArgs e) { EventHandler h = Events[EventVertical] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:WrapInitialChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnWrapInitialChanged(EventArgs e) { EventHandler h = Events[EventWrapInitial] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:WrapChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnWrapChanged(EventArgs e) { EventHandler h = Events[EventWrap] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:PainterPresetChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnPainterPresetChanged(EventArgs e) { EventHandler h = Events[EventPainterPreset] as EventHandler; if (h != null) h(this, e); }
        /// <summary>
        /// Handles the <see cref="E:PainterObjectChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnPainterObjectChanged(EventArgs e) { EventHandler h = Events[EventPainterObject] as EventHandler; if (h != null) h(this, e); }
        //		protected virtual void OnPainterWorkerChanged ( EventArgs e ) { EventHandler h = Events[ EventPainterWorker ] as EventHandler; if ( h != null ) h( this, e ); }

        //-----------------------------------------------------------------------------
        // Paths

        /// <summary>
        /// Sets the path.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="path">The path.</param>
        private void SetPath(Rectangle c, GraphicsPath path)
        {
            //			c.Inflate( -10, -10 );

            if (c.Width <= 0 || c.Height <= 0) return;

            const int k = 7;

            int d = _CornerRadius;

            if (d + k > c.Width) d = c.Width - k;
            if (d + k > c.Height) d = c.Height - k;
            if (d <= 0) return;

            int left = c.Left;
            int right = c.Right - d - 0;

            int top = c.Top;
            int bottom = c.Bottom - d - 0;

            path.AddArc(left, top, d, d, 180, 90);
            path.AddArc(right, top, d, d + k, 270, 90);
            path.AddArc(right - k, bottom - k, d + k, d + k, 000, 90);
            path.AddArc(left, bottom, d + k, d, 090, 90);
            path.CloseFigure();
        }

        /// <summary>
        /// Pathes the specified space.
        /// </summary>
        /// <param name="space">The space.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath Path(int space)
        {
            GraphicsPath path = new GraphicsPath();

            Rectangle c = ClientRectangle;
            c.Inflate(-space, -space);

            if (_CornerRadius <= 0)
            {
                path.AddRectangle(c);
            }
            else
            {
                SetPath(c, path);
            }

            return path;
        }

        /// <summary>
        /// Gets the outline path.
        /// </summary>
        /// <value>The outline path.</value>
        private GraphicsPath OutlinePath
        {
            get
            {
                return Path(0);
            }
        }

        /// <summary>
        /// Gets the interior path.
        /// </summary>
        /// <value>The interior path.</value>
        private GraphicsPath InteriorPath
        {
            get
            {
                int space = (_BorderStyle == BorderStyle.None) ? 0 : 1;

                return Path(space);
            }
        }

        /// <summary>
        /// Gets the client path.
        /// </summary>
        /// <value>The client path.</value>
        private GraphicsPath ClientPath
        {
            get
            {
                int space = (_BorderStyle == BorderStyle.None) ? 0 : 1;
                space += _Margin;

                return Path(space);
            }
        }

        /// <summary>
        /// Gets the outline region.
        /// </summary>
        /// <value>The outline region.</value>
        private Region OutlineRegion
        {
            get
            {
                Region r = null;

                if (_CornerRadius <= 0)
                    r = new Region(ClientRectangle);
                else
                    r = new Region(OutlinePath);

                return r;
            }
        }

        /// <summary>
        /// Gets the interior region.
        /// </summary>
        /// <value>The interior region.</value>
        private Region InteriorRegion
        {
            get
            {
                Region r = null;

                if (_CornerRadius <= 0)
                {
                    Rectangle c = ClientRectangle;
                    if (_BorderStyle != BorderStyle.None) c.Inflate(-1, -1);
                    r = new Region(c);
                }
                else
                    r = new Region(InteriorPath);

                return r;
            }
        }

        /// <summary>
        /// Gets the client region.
        /// </summary>
        /// <value>The client region.</value>
        private Region ClientRegion
        {
            get
            {
                Region r = null;

                if (_CornerRadius <= 0)
                {
                    Rectangle c = ClientRectangle;
                    if (_BorderStyle != BorderStyle.None) c.Inflate(-1, -1);
                    c.Inflate(-_Margin, -_Margin);
                    r = new Region(c);
                }
                else
                    r = new Region(ClientPath);

                return r;
            }
        }

        //-----------------------------------------------------------------------------
        // Handlers

        /// <summary>
        /// Handles the Resize event of the ZeroitBusyBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ZeroitBusyBar_Resize(object sender, System.EventArgs e)
        {
            SetRegion();
        }

        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.Clear(BackColor);

            PaintBorder(g);

            if (_PainterWorker != null)
            {
                Region r = ClientRegion;
                g.Clip = r;
                _PainterWorker.Paint(g, r);
            }
        }

        /// <summary>
        /// Paints the border.
        /// </summary>
        /// <param name="g">The g.</param>
        private void PaintBorder(Graphics g)
        {
            switch (_BorderStyle)
            {
                case BorderStyle.None:
                    break;

                case BorderStyle.FixedSingle:
                    {
                        if (_CornerRadius <= 0)
                        {
                            ControlPaint.DrawBorder3D(g, ClientRectangle, Border3DStyle.Flat);
                        }
                        else
                        {
                            PaintBorderPath(g);
                        }

                        break;
                    }

                case BorderStyle.Fixed3D:
                    {
                        if (_CornerRadius <= 0)
                        {
                            ControlPaint.DrawBorder3D(g, ClientRectangle, Border3DStyle.SunkenOuter);
                        }
                        else
                        {
                            PaintBorderPath(g);
                        }

                        break;
                    }

                default:
                    Debug.Assert(false);
                    break;
            }
        }

        /// <summary>
        /// Paints the border path.
        /// </summary>
        /// <param name="g">The g.</param>
        private void PaintBorderPath(Graphics g)
        {
            //			g.DrawPath( Pens.Black, OutlinePath );

            g.FillPath(Brushes.Black, OutlinePath);

            //			g.FillPath( Brushes.Red, InteriorPath );

            using (Brush brush = new SolidBrush(BackColor))
                g.FillPath(brush, InteriorPath);
            //				g.FillPath( brush, ClientPath );
        }

        //-----------------------------------------------------------------------------
        // Methods

        /// <summary>
        /// Sets the region.
        /// </summary>
        public void SetRegion()
        {
            if (_CornerRadius <= 0)
                Region = null;
            else
                Region = OutlineRegion;

            Invalidate();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            _Value = _Reverse ? _Maximum : _Minimum;

            if (_PainterWorker != null) _PainterWorker.Reset();

            Invalidate();
        }

        /// <summary>
        /// Performs the step.
        /// </summary>
        public void PerformStep()
        {
            if (!_Bounce)
            {
                int i = _Reverse ? -1 : 1;
                _Value += i * _Step;

                if (_Value < _Minimum) _Value = _Maximum;
                if (_Value > _Maximum) _Value = _Minimum;
            }
            else
            {
                int i = _Bouncing ? -1 : 1;
                _Value += i * _Step;

                if (_Value < _Minimum)
                {
                    _Value = _Minimum;
                    _Bouncing = false;
                }

                if (_Value > _Maximum)
                {
                    _Value = _Maximum;
                    _Bouncing = true;
                }
            }

            Invalidate();
        }

        //-----------------------------------------------------------------------------
        // enums


        /// <summary>
        /// Enum representing Pins
        /// </summary>
        public enum Pins
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The start
            /// </summary>
            Start,
            /// <summary>
            /// The end
            /// </summary>
            End,
        }

        /// <summary>
        /// Enum representing the Painter Presets
        /// </summary>
        public enum PainterPresets
        {
            /// <summary>
            /// The none
            /// </summary>
            None,
            /// <summary>
            /// The line
            /// </summary>
            Line,
            /// <summary>
            /// The xp
            /// </summary>
            XP,
            /// <summary>
            /// The path gradient
            /// </summary>
            PathGradient,
            /// <summary>
            /// The clock
            /// </summary>
            Clock,
            /// <summary>
            /// The sillyscope
            /// </summary>
            Sillyscope,
            /// <summary>
            /// The install
            /// </summary>
            Install,
            /// <summary>
            /// The frustrato bar
            /// </summary>
            FrustratoBar,
        }

        //-----------------------------------------------------------------------------

    } // ZeroitBusyBar 
    #endregion
}
