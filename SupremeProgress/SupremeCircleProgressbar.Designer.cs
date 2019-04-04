// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 08-18-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="SupremeCircleProgressbar.Designer.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
	[DefaultEvent("ProgressChanged")]
	[ProvideProperty("ZeroitDev", typeof(Control))]
	public class ZeroitSupremeCircleProgress : UserControl
	{

        #region Private Fields
        /// <summary>
        /// The enc list
        /// </summary>
        private static List<WeakReference> __ENCList;

        /// <summary>
        /// The int0
        /// </summary>
        private int Int0;

        /// <summary>
        /// The int1
        /// </summary>
        private int Int1;

        /// <summary>
        /// The int2
        /// </summary>
        private int Int2;

        /// <summary>
        /// The int3
        /// </summary>
        private int Int3;

        /// <summary>
        /// The int4
        /// </summary>
        private int Int4;

        /// <summary>
        /// The int5
        /// </summary>
        private int Int5;

        /// <summary>
        /// The int6
        /// </summary>
        private int Int6;

        /// <summary>
        /// The int20
        /// </summary>
        private int Int20;

        /// <summary>
        /// The int21
        /// </summary>
        private int Int21;

        /// <summary>
        /// The int22
        /// </summary>
        private int Int22;

        /// <summary>
        /// The int23
        /// </summary>
        private int Int23;

        /// <summary>
        /// The dir
        /// </summary>
        private int Dir;

        /// <summary>
        /// The color0
        /// </summary>
        private Color Color0;

        /// <summary>
        /// The color1
        /// </summary>
        private Color Color1;

        /// <summary>
        /// The color2
        /// </summary>
        private Color Color2;

        /// <summary>
        /// The event handlers
        /// </summary>
        private EventHandler EventHandlers;

        /// <summary>
        /// The bool
        /// </summary>
        private bool Bool;

        /// <summary>
        /// The bool2
        /// </summary>
        private bool Bool2;

        /// <summary>
        /// The i container0
        /// </summary>
        private IContainer IContainer0;

        /// <summary>
        /// The label pass
        /// </summary>
        private Label LblPass;

        /// <summary>
        /// The components
        /// </summary>
        private IContainer components;

        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer Timer1;

        /// <summary>
        /// The timer2
        /// </summary>
        private System.Windows.Forms.Timer Timer2;
        #endregion

        #region Public Properties

        /// <summary>
        /// Enum representing the rendering mode.
        /// </summary>
        public enum RenderMode
	    {
            /// <summary>
            /// The solid
            /// </summary>
            Solid,
            /// <summary>
            /// The gradient
            /// </summary>
            Gradient
        }

        /// <summary>
        /// The color mode
        /// </summary>
        private RenderMode _colorMode = RenderMode.Solid;

        /// <summary>
        /// Gets or sets the color mode.
        /// </summary>
        /// <value>The color mode.</value>
        public RenderMode ColorMode
	    {
            get { return _colorMode; }
	        set
	        {
	            _colorMode = value;
	            Invalidate();
	        }
	    }

        /// <summary>
        /// Gets or sets the color of the base back.
        /// </summary>
        /// <value>The color of the base back.</value>
        public Color BaseBackColor
        {
            get
            {
                return this.Color2;
            }
            set
            {
                this.Color2 = value;
                base.Invalidate();
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Gets the get percentage.
        /// </summary>
        /// <value>The get percentage.</value>
        public int GetPercentage
        {
            get
            {
                int num = int.Parse(this.LblPass.Text.Replace("%", ""));
                return num;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show text.
        /// </summary>
        /// <value><c>true</c> if show text; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get
            {
                return this.LblPass.Visible;
            }
            set
            {
                this.LblPass.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the line progress thickness.
        /// </summary>
        /// <value>The line progress thickness.</value>
        public int LineProgressThickness
        {
            get
            {
                return this.Int1;
            }
            set
            {
                this.Int1 = value;
                base.Invalidate();
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Gets or sets the line thickness.
        /// </summary>
        /// <value>The line thickness.</value>
        public int LineThickness
        {
            get
            {
                return this.Int0;
            }
            set
            {
                this.Int0 = value;
                base.Invalidate();
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitSupremeCircleProgress" /> has marquee enabled.
        /// </summary>
        /// <value><c>true</c> if marquee; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Marquee")]
        [Description("Marquee Properties")]
        public bool Marquee
        {
            get
            {
                return this.Bool;
            }
            set
            {
                this.Bool = value;
                if (!this.Bool)
                {
                    this.Timer1.Stop();
                    this.Int5 = -90;
                    this.Method3(this.Int2);
                }
                else
                {
                    this.Timer1.Start();
                    this.ShowText = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the marquee pace.
        /// </summary>
        /// <value>The marquee pace.</value>
        [Browsable(true)]
        [Category("Marquee")]
        [Description("Marquee Properties")]
        public int MarqueePace
        {
            get
            {
                return this.Int6;
            }
            set
            {
                this.Int6 = value;
            }
        }

        /// <summary>
        /// Gets or sets the marquee smooth speed.
        /// </summary>
        /// <value>The marquee smooth speed.</value>
        [Browsable(true)]
        [Category("Marquee")]
        [Description("Marquee Properties")]
        public int MarqueeSmoothSpeed
        {
            get
            {
                return this.Timer1.Interval;
            }
            set
            {
                this.Timer1.Interval = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int Maximum
        {
            get
            {
                return this.Int3;
            }
            set
            {
                this.Int3 = value;
                base.Invalidate();
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress bar back.
        /// </summary>
        /// <value>The color of the progress bar back.</value>
        public Color ProgressBarBackColor
        {
            get
            {
                return this.Color1;
            }
            set
            {
                this.Color1 = value;
                base.Invalidate();
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress bar.
        /// </summary>
        /// <value>The color of the progress bar.</value>
        public Color ProgressBarColor
        {
            get
            {
                return this.Color0;
            }
            set
            {
                this.Color0 = value;
                base.Invalidate();
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitSupremeCircleProgress" /> is stretchable.
        /// </summary>
        /// <value><c>true</c> if stretchable; otherwise, <c>false</c>.</value>
        [Browsable(true)]
        [Category("Stretch")]
        [Description("Stretch Properties")]
        public bool Stretchable
        {
            get
            {
                return this.Timer2.Enabled;
            }
            set
            {
                this.Timer2.Enabled = value;
                if (value)
                {
                    this.Marquee = true;
                    this.MarqueePace = 1;
                    this.MarqueeSmoothSpeed = 1;
                    this.Value = this.Int22;
                    this.ShowText = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the stretch back pace.
        /// </summary>
        /// <value>The stretch back pace.</value>
        [Browsable(true)]
        [Category("Stretch")]
        [Description("Stretch Properties")]
        public int StretchBackPace
        {
            get
            {
                return this.Int21;
            }
            set
            {
                this.Int21 = value;
            }
        }

        /// <summary>
        /// Gets or sets the stretch front pace.
        /// </summary>
        /// <value>The stretch front pace.</value>
        [Browsable(true)]
        [Category("Stretch")]
        [Description("Stretch Properties")]
        public int StretchFrontPace
        {
            get
            {
                return this.Int20;
            }
            set
            {
                this.Int20 = value;
            }
        }

        /// <summary>
        /// Gets or sets the stretch maximum value.
        /// </summary>
        /// <value>The stretch maximum value.</value>
        [Browsable(true)]
        [Category("Stretch")]
        [Description("Stretch Properties")]
        public int StretchMaxVal
        {
            get
            {
                return this.Int23;
            }
            set
            {
                this.Int23 = value;
            }
        }

        /// <summary>
        /// Gets or sets the stretch minimum value.
        /// </summary>
        /// <value>The stretch minimum value.</value>
        [Browsable(true)]
        [Category("Stretch")]
        [Description("Stretch Properties")]
        public int StretchMinVal
        {
            get
            {
                return this.Int22;
            }
            set
            {
                this.Int22 = value;
            }
        }

        /// <summary>
        /// Gets or sets the stretch smooth speed.
        /// </summary>
        /// <value>The stretch smooth speed.</value>
        [Browsable(true)]
        [Category("Stretch")]
        [Description("Stretch Properties")]
        public int StretchSmoothSpeed
        {
            get
            {
                return this.Timer2.Interval;
            }
            set
            {
                this.Timer2.Interval = value;
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
                return this.Int2;
            }
            set
            {
                if (value <= this.Int3)
                {
                    this.Int2 = value;
                    if (this.LblPass.Visible)
                    {
                        Label lblPass = this.LblPass;
                        int num = checked((int)System.Math.Round(Convert.ToDouble(decimal.Divide(new decimal(this.Int2), new decimal(this.Int3))) * 100));
                        lblPass.Text = string.Concat(num.ToString(), "%");
                    }
                    this.Method3(this.Int2);
                }
            }
        } /**/
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes static members of the <see cref="ZeroitSupremeCircleProgress"/> class.
        /// </summary>
        [DebuggerNonUserCode]
        static ZeroitSupremeCircleProgress()
        {
            ZeroitSupremeCircleProgress.__ENCList = new List<WeakReference>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSupremeCircleProgress" /> class.
        /// </summary>
        public ZeroitSupremeCircleProgress()
        {
            ZeroitSupremeCircleProgress shiftCircleProgressbar = this;
            base.Resize += new EventHandler(shiftCircleProgressbar.ShiftCircleProgressbar_Resize);
            ZeroitSupremeCircleProgress shiftCircleProgressbar1 = this;
            base.FontChanged += new EventHandler(shiftCircleProgressbar1.ShiftCircleProgressbar_FontChanged);
            ZeroitSupremeCircleProgress shiftCircleProgressbar2 = this;
            base.ForeColorChanged += new EventHandler(shiftCircleProgressbar2.ShiftCircleProgressbar_ForeColorChanged);
            ZeroitSupremeCircleProgress.__ENCAddToList(this);
            this.Int0 = 10;
            this.Int1 = 15;
            this.Int3 = 100;
            this.Int5 = -90;
            this.Int6 = 1;
            this.Int20 = 5;
            this.Int21 = 2;
            this.Int22 = 20;
            this.Int23 = 90;
            this.Dir = 1;
            this.Color0 = SystemColors.HotTrack;
            this.Color1 = Color.LightGray;
            this.Color2 = Color.Transparent;
            this.Bool = false;
            this.Bool2 = false;
            this.InitializeComponent();
            this.LblPass.Font = this.Font;
            this.LblPass.ForeColor = this.ForeColor;
            this.LblPass.Top = checked((int)System.Math.Round((double)base.Height / 2 - (double)this.LblPass.Height / 2));
            this.LblPass.Left = checked((int)System.Math.Round((double)base.Width / 2 - (double)this.LblPass.Width / 2));
            base.Width = base.Height;
            this.DoubleBuffered = true;
            base.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
            //if (LicenseManager.CurrentContext.UsageMode == LicenseUsageMode.Designtime)
            //{
            //	if (!ShiftTechControls.ShiftTechSupport.License.Check(this))
            //	{
            //		Interaction.MsgBox("License is invalid or unknown! Please download a valid license from the Shift Technologies App.", MsgBoxStyle.Critical, null);
            //		this.Dispose();
            //	}
            //}

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Encs the add to list.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            lock (ZeroitSupremeCircleProgress.__ENCList)
            {
                if (ZeroitSupremeCircleProgress.__ENCList.Count == ZeroitSupremeCircleProgress.__ENCList.Capacity)
                {
                    int item = 0;
                    int count = checked(ZeroitSupremeCircleProgress.__ENCList.Count - 1);
                    for (int i = 0; i <= count; i++)
                    {
                        if (ZeroitSupremeCircleProgress.__ENCList[i].IsAlive)
                        {
                            if (i != item)
                            {
                                ZeroitSupremeCircleProgress.__ENCList[item] = ZeroitSupremeCircleProgress.__ENCList[i];
                            }
                            item++;
                        }
                    }
                    ZeroitSupremeCircleProgress.__ENCList.RemoveRange(item, checked(ZeroitSupremeCircleProgress.__ENCList.Count - item));
                    ZeroitSupremeCircleProgress.__ENCList.Capacity = ZeroitSupremeCircleProgress.__ENCList.Count;
                }
                ZeroitSupremeCircleProgress.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if ((!disposing || this.IContainer0 == null ? false : true))
            {
                this.IContainer0.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblPass = new Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            this.LblPass.AutoSize = true;
            this.LblPass.BackColor = Color.Transparent;
            this.LblPass.Font = new System.Drawing.Font("Century Gothic", 26.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.LblPass.ForeColor = SystemColors.HotTrack;
            this.LblPass.Location = new Point(76, 72);
            this.LblPass.Name = "LblPass";
            Label lblPass = this.LblPass;
            System.Drawing.Size size = new System.Drawing.Size(64, 42);
            lblPass.Size = size;
            this.LblPass.TabIndex = 0;
            this.LblPass.Text = "0%";
            this.LblPass.SizeChanged += new EventHandler((object a0, EventArgs a1) => this.LblPassSizeChanged());
            this.Timer1.Interval = 3;
            ZeroitSupremeCircleProgress shiftCircleProgressbar = this;
            this.Timer1.Tick += new EventHandler(shiftCircleProgressbar.Timer1_Tick);
            this.Timer2.Interval = 3;
            this.Timer2.Enabled = false;
            ZeroitSupremeCircleProgress shiftCircleProgressbar1 = this;
            this.Timer2.Tick += new EventHandler(shiftCircleProgressbar1.Timer2_Tick);
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.LblPass);
            this.Font = new System.Drawing.Font("Century Gothic", 26.25f);
            this.ForeColor = SystemColors.HotTrack;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "ShiftCircleProgressbar";
            size = new System.Drawing.Size(205, 201);
            this.Size = size;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Labels the pass size changed.
        /// </summary>
        private void LblPassSizeChanged()
        {
            try
            {
                this.LblPass.Top = checked((int)System.Math.Round((double)base.Height / 2 - (double)this.LblPass.Height / 2));
                this.LblPass.Left = checked((int)System.Math.Round((double)base.Width / 2 - (double)this.LblPass.Width / 2));
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                ProjectData.ClearProjectError();
            }
        }

        /// <summary>
        /// Method1s the specified int7.
        /// </summary>
        /// <param name="Int7">The int7.</param>
        /// <returns>System.Int32.</returns>
        private int Method1(int Int7)
        {
            int num = checked((int)System.Math.Round((double)(checked(360 * Int7)) / (double)this.Int3));
            return num;
        }

        /// <summary>
        /// Method2s this instance.
        /// </summary>
        private void Method2()
        {
            if (this.EventHandlers != null)
            {
                this.EventHandlers(this, null);
            }
        }

        /// <summary>
        /// Method3s the specified int7.
        /// </summary>
        /// <param name="Int7">The int7.</param>
        private void Method3(int Int7)
        {
            Bitmap bitmap = new Bitmap(base.Size.Width, base.Size.Height);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.Clear(Color.Transparent);
            Rectangle rectangle = new Rectangle(10, 10, checked(base.Width - 20), checked(base.Height - 20));
            Pen pen = new Pen(this.Color1)
            {
                Width = (float)this.Int0
            };
            graphic.DrawArc(pen, rectangle, 0f, 360f);
            switch (_colorMode)
            {
                case RenderMode.Solid:
                    graphic.FillEllipse(new SolidBrush(this.Color2), 10f + (float)((double)this.Int0 / 2), 10f + (float)((double)this.Int0 / 2), (float)(checked(checked(base.Width - 20) - this.Int0)), (float)(checked(checked(base.Height - 20) - this.Int0)));
                    break;
                case RenderMode.Gradient:
                    LinearGradientBrush linbrBrush = new LinearGradientBrush(new RectangleF(10f + (float)((double)this.Int0 / 2), 10f + (float)((double)this.Int0 / 2), (float)(checked(checked(base.Width - 20) - this.Int0)), (float)(checked(checked(base.Height - 20) - this.Int0))), Color.Orange, Color.DarkSlateGray,90f);
                    graphic.FillEllipse(linbrBrush, 10f + (float)((double)this.Int0 / 2), 10f + (float)((double)this.Int0 / 2), (float)(checked(checked(base.Width - 20) - this.Int0)), (float)(checked(checked(base.Height - 20) - this.Int0)));
                    break;
                default:
                    break;
            }
            Graphics smoothingMode = Graphics.FromImage(bitmap);
            smoothingMode.SmoothingMode = graphic.SmoothingMode;
            Rectangle rectangle1 = new Rectangle(10, 10, checked(base.Width - 20), checked(base.Height - 20));
            pen = new Pen(this.Color0)
            {
                Width = (float)this.Int1
            };
            smoothingMode.DrawArc(pen, rectangle1, (float)this.Int5, (float)this.Method1(Int7));
            this.BackgroundImage = bitmap;
            this.Method2();
        }
        #endregion


        #region Paint Events
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Method3(this.Int2);
            base.OnPaint(e);


        }

        /// <summary>
        /// Method4s the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Method4(object sender, EventArgs e)
        {
            ZeroitSupremeCircleElipseControlsWithForm.Apply(this.LblPass, this.LblPass.Height);
            this.LblPass.Top = checked((int)System.Math.Round((double)base.Height / 2 - (double)this.LblPass.Height / 2));
            this.LblPass.Left = checked((int)System.Math.Round((double)base.Width / 2 - (double)this.LblPass.Width / 2));
        }

        /// <summary>
        /// Handles the ProgressChanged event of the raise control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void raise_ProgressChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the FontChanged event of the ShiftCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ShiftCircleProgressbar_FontChanged(object sender, EventArgs e)
        {
            this.LblPass.Font = this.Font;
            this.LblPass.ForeColor = this.ForeColor;
            this.LblPass.Top = checked((int)System.Math.Round((double)base.Height / 2 - (double)this.LblPass.Height / 2));
            this.LblPass.Left = checked((int)System.Math.Round((double)base.Width / 2 - (double)this.LblPass.Width / 2));
        }

        /// <summary>
        /// Handles the ForeColorChanged event of the ShiftCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ShiftCircleProgressbar_ForeColorChanged(object sender, EventArgs e)
        {
            this.LblPass.Font = this.Font;
            this.LblPass.ForeColor = this.ForeColor;
            this.LblPass.Top = checked((int)System.Math.Round((double)base.Height / 2 - (double)this.LblPass.Height / 2));
            this.LblPass.Left = checked((int)System.Math.Round((double)base.Width / 2 - (double)this.LblPass.Width / 2));
        }

        /// <summary>
        /// Handles the Resize event of the ShiftCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ShiftCircleProgressbar_Resize(object sender, EventArgs e)
        {
            base.Invalidate();
            this.LblPass.Top = checked((int)System.Math.Round((double)base.Height / 2 - (double)this.LblPass.Height / 2));
            this.LblPass.Left = checked((int)System.Math.Round((double)base.Width / 2 - (double)this.LblPass.Width / 2));
            base.Width = base.Height;
            this.Method3(this.Int2);
        }

        /// <summary>
        /// Handles the Tick event of the Timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if ((this.Value == this.Maximum || this.Value <= 0 ? false : true))
            {
                this.Int5 = checked(this.Int5 + this.MarqueePace);
                this.Method3(this.Int2);
            }
        }

        /// <summary>
        /// Handles the Tick event of the Timer2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (this.Value == this.Int23)
            {
                this.Bool2 = true;
            }
            else if (this.Value == this.Int22)
            {
                this.Bool2 = false;
            }
            if (!this.Bool2)
            {
                this.Dir = 1;
                this.Int6 = this.Int21;
            }
            else
            {
                this.Dir = -1;
                this.Int6 = this.Int20;
            }
            this.Value = checked(this.Value + this.Dir);
        }

        /// <summary>
        /// Occurs when [progress changed].
        /// </summary>
        public event EventHandler ProgressChanged
        {
            add
            {
                EventHandler eventHandler;
                EventHandler eventHandlers = this.EventHandlers;
                do
                {
                    eventHandler = eventHandlers;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
                    eventHandlers = Interlocked.CompareExchange<EventHandler>(ref this.EventHandlers, eventHandler1, eventHandler);
                }
                while ((object)eventHandlers != (object)eventHandler);
            }
            remove
            {
                EventHandler eventHandler;
                EventHandler eventHandlers = this.EventHandlers;
                do
                {
                    eventHandler = eventHandlers;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
                    eventHandlers = Interlocked.CompareExchange<EventHandler>(ref this.EventHandlers, eventHandler1, eventHandler);
                }
                while ((object)eventHandlers != (object)eventHandler);
            }
        }
        #endregion

        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate the control.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                Invalidate();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Value + 1 > this.Maximum)
            {
                this.Value = 0;
            }

            else
            {
                this.Value++;
                Invalidate();
            }
        }

        #endregion

        
    }

    /// <summary>
    /// Class ZeroitSupremeCircleElipseControlsWithForm.
    /// </summary>
    public static class ZeroitSupremeCircleElipseControlsWithForm
    {
        /// <summary>
        /// Applies the specified form.
        /// </summary>
        /// <param name="Form">The form.</param>
        /// <param name="_Elipse">The elipse.</param>
        public static void Apply(System.Windows.Forms.Form Form, int _Elipse)
        {
            try
            {
                Form.FormBorderStyle = FormBorderStyle.None;
                Form.Region = Region.FromHrgn(ZeroitSupremeCircleElipseControlsWithForm.CreateRoundRectRgn(0, 0, Form.Width, Form.Height, _Elipse, _Elipse));
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                ProjectData.ClearProjectError();
            }
        }

        /// <summary>
        /// Applies the specified control.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="Elipse">The elipse.</param>
        public static void Apply(Control ctrl, int Elipse)
        {
            try
            {
                ctrl.Region = Region.FromHrgn(ZeroitSupremeCircleElipseControlsWithForm.CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, Elipse, Elipse));
            }
            catch (Exception exception)
            {
                ProjectData.SetProjectError(exception);
                ProjectData.ClearProjectError();
            }
        }

        /// <summary>
        /// Creates the round rect RGN.
        /// </summary>
        /// <param name="int_0">The int 0.</param>
        /// <param name="int_1">The int 1.</param>
        /// <param name="int_2">The int 2.</param>
        /// <param name="int_3">The int 3.</param>
        /// <param name="int_4">The int 4.</param>
        /// <param name="int_5">The int 5.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CreateRoundRectRgn(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);
    }


}