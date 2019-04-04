// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ZeroitAnidasoCircleProgress.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
    [DefaultEvent("ProgessChanged")]
    [ProvideProperty("AnidasoFramework", typeof(Control))]
    public class ZeroitAnidasoCircleProgress : UserControl
    {

        #region Private Fields
        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0 = 5;

        /// <summary>
        /// The int 1
        /// </summary>
        private int int_1 = 8;

        /// <summary>
        /// The color 0
        /// </summary>
        private Color color_0 = Color.LightBlue;

        /// <summary>
        /// The color 1
        /// </summary>
        private Color color_1 = Color.Gainsboro;

        /// <summary>
        /// The int 2
        /// </summary>
        private int int_2;

        /// <summary>
        /// The int 3
        /// </summary>
        private int int_3 = 100;

        /// <summary>
        /// The int 4
        /// </summary>
        private int int_4;

        /// <summary>
        /// The bool 0
        /// </summary>
        private bool bool_0;

        /// <summary>
        /// The int 5
        /// </summary>
        private int int_5 = -90;

        /// <summary>
        /// The int 6
        /// </summary>
        private int int_6 = 5;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        /// <summary>
        /// The lblpass
        /// </summary>
        private Label lblpass;

        /// <summary>
        /// The timer 0
        /// </summary>
        private System.Windows.Forms.Timer timer_0;

        /// <summary>
        /// The rectangle parameters
        /// </summary>
        private RectangleParemeters rectangleParameters = new RectangleParemeters();

        #endregion

        /// <summary>
        /// Gets or sets the rectangle values and parameters.
        /// </summary>
        /// <value>The rectangle.</value>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public RectangleParemeters Rectangle
        {
            get { return rectangleParameters; }
            set
            {
                rectangleParameters = value;
                this.method_2(this.int_2);
                Invalidate();
            }
        }

        /// <summary>
        /// The event handler 0
        /// </summary>
        EventHandler eventHandler_0;

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitAnidasoCircleProgress" /> is animated.
        /// </summary>
        /// <value><c>true</c> if animated; otherwise, <c>false</c>.</value>
        public bool Animated
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
                if (this.bool_0)
                {
                    this.timer_0.Start();
                    return;
                }
                this.timer_0.Stop();
                this.int_5 = -90;
                this.method_2(this.int_2);
            }
        }

        /// <summary>
        /// Gets or sets the animation interval.
        /// </summary>
        /// <value>The animation interval.</value>
        public int AnimationInterval
        {
            get
            {
                return this.int_6;
            }
            set
            {
                this.int_6 = value;
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int AnimationSpeed
        {
            get
            {
                return this.timer_0.Interval;
            }
            set
            {
                this.timer_0.Interval = value;
            }
        }

        /// <summary>
        /// Gets the progress percentage.
        /// </summary>
        /// <value>The percentage.</value>
        public int GetPercentage
        {
            get
            {
                return int.Parse(this.lblpass.Text.Replace("%", ""));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the progress.
        /// </summary>
        /// <value><c>true</c> if show text; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get
            {
                return this.lblpass.Visible;
            }
            set
            {
                this.lblpass.Visible = value;
            }
        }

        /// <summary>
        /// Gets or sets the line progress' thickness.
        /// </summary>
        /// <value>The line progress' thickness.</value>
        public int LineProgressThickness
        {
            get
            {
                return this.int_1;
            }
            set
            {
                this.int_1 = value;
                base.Invalidate();
                this.method_2(this.int_2);
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
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                base.Invalidate();
                this.method_2(this.int_2);
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int MaximumValue
        {
            get
            {
                return this.int_3;
            }
            set
            {
                this.int_3 = value;
                base.Invalidate();
                this.method_2(this.int_2);
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress background.
        /// </summary>
        /// <value>The color of the progress background.</value>
        public Color ProgressBackColor
        {
            get
            {
                return this.color_1;
            }
            set
            {
                this.color_1 = value;
                base.Invalidate();
                this.method_2(this.int_2);
            }
        }

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        public Color ProgressColor
        {
            get
            {
                return this.color_0;
            }
            set
            {
                this.color_0 = value;
                base.Invalidate();
                this.method_2(this.int_2);
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
                return this.int_2;
            }
            set
            {
                if (value > this.int_3)
                {
                    MessageBox.Show("Maximum Value Exceeded");
                    return;
                }
                this.int_2 = value;
                this.lblpass.Text = string.Concat((int)((double)this.int_2 / (double)this.int_3 * 100), "%");
                this.method_2(this.int_2);
            }
        }

        #endregion


        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoCircleProgress" /> class.
        /// </summary>
        public ZeroitAnidasoCircleProgress()
        {
            this.InitializeComponent();
            //color_0 = BackColor;

            this.lblpass.Font = this.Font;
            this.lblpass.ForeColor = this.ForeColor;
            this.lblpass.Top = base.Height / 2 - this.lblpass.Height / 2;
            this.lblpass.Left = base.Width / 2 - this.lblpass.Width / 2;
            base.Width = base.Height;
            LicenseUsageMode usageMode = LicenseManager.UsageMode;
            AnidasoCustomControl.initializeComponent(this);
            base.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
        }

        #endregion


        /// <summary>
        /// Handles the FontChanged event of the AnidasoCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnidasoCircleProgressbar_FontChanged(object sender, EventArgs e)
        {
            this.lblpass.Font = this.Font;
            this.lblpass.ForeColor = this.ForeColor;
            this.lblpass.Top = base.Height / 2 - this.lblpass.Height / 2;
            this.lblpass.Left = base.Width / 2 - this.lblpass.Width / 2;
        }

        /// <summary>
        /// Handles the ForeColorChanged event of the AnidasoCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnidasoCircleProgressbar_ForeColorChanged(object sender, EventArgs e)
        {
            this.lblpass.Font = this.Font;
            this.lblpass.ForeColor = this.ForeColor;
            this.lblpass.Top = base.Height / 2 - this.lblpass.Height / 2;
            this.lblpass.Left = base.Width / 2 - this.lblpass.Width / 2;
        }

        /// <summary>
        /// Handles the Load event of the AnidasoCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnidasoCircleProgressbar_Load(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (!base.DesignMode)
            {
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
            else
            {
                AnidasoCustomControl.initializeComponent(this);
            }
        }

        /// <summary>
        /// Handles the Resize event of the AnidasoCircleProgressbar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnidasoCircleProgressbar_Resize(object sender, EventArgs e)
        {
            base.Invalidate();
            this.lblpass.Top = base.Height / 2 - this.lblpass.Height / 2;
            this.lblpass.Left = base.Width / 2 - this.lblpass.Width / 2;
            base.Width = base.Height;
            this.method_2(this.int_2);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.icontainer_0 != null)
            {
                this.icontainer_0.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.icontainer_0 = new System.ComponentModel.Container();
            this.lblpass = new Label();
            this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
            base.SuspendLayout();
            this.lblpass.AutoSize = true;
            this.lblpass.BackColor = Color.Transparent;
            this.lblpass.Location = new Point(76, 72);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(67, 39);
            this.lblpass.TabIndex = 0;
            this.lblpass.Text = "0%";
            this.timer_0.Interval = 300;
            this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
            base.AutoScaleDimensions = new SizeF(20f, 39f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ForeColor = Color.Black;
            base.Controls.Add(this.lblpass);
            this.Font = new System.Drawing.Font("Segoe UI", 15f);
            
            base.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            base.Name = "AnidasoCircleProgressbar";
            base.Size = new System.Drawing.Size(205, 201);
            base.Load += new EventHandler(this.AnidasoCircleProgressbar_Load);
            base.FontChanged += new EventHandler(this.AnidasoCircleProgressbar_FontChanged);
            base.ForeColorChanged += new EventHandler(this.AnidasoCircleProgressbar_ForeColorChanged);
            base.Resize += new EventHandler(this.AnidasoCircleProgressbar_Resize);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        /// <summary>
        /// Methods the 0.
        /// </summary>
        /// <param name="int_7">The int 7.</param>
        /// <returns>System.Int32.</returns>
        private int method_0(int int_7)
        {
            return 360 * int_7 / this.int_3;
        }

        /// <summary>
        /// Methods the 1.
        /// </summary>
        private void method_1()
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (this.eventHandler_0 == null)
            {
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
            else
            {
                this.eventHandler_0(this, null);
            }
        }

        /// <summary>
        /// Methods the 2.
        /// </summary>
        /// <param name="int_7">The int 7.</param>
        private void method_2(int int_7)
        {
            Bitmap bitmap = new Bitmap(base.Size.Width, base.Size.Height);
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap);
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.Clear(Color.Transparent);
            Rectangle rectangle = new Rectangle(rectangleParameters.HorizontalShift, rectangleParameters.VerticalShift, base.Width - rectangleParameters.WidthShift, base.Width - rectangleParameters.HeightShift);
            Pen pen = new Pen(this.color_1)
            {
                Width = (float)this.int_0
            };
            graphic.DrawArc(pen, rectangle, 0f, 360f);
            System.Drawing.Graphics smoothingMode = System.Drawing.Graphics.FromImage(bitmap);
            smoothingMode.SmoothingMode = graphic.SmoothingMode;
            Rectangle rectangle1 = new Rectangle(rectangleParameters.HorizontalShift, rectangleParameters.VerticalShift, base.Width - rectangleParameters.WidthShift, base.Width - rectangleParameters.HeightShift);
            Pen pen1 = new Pen(this.color_0)
            {
                Width = (float)this.int_1
            };
            smoothingMode.DrawArc(pen1, rectangle1, (float)this.int_5, (float)this.method_0(int_7));
            this.BackgroundImage = bitmap;
            this.method_1();
        }

        /// <summary>
        /// Handles the 3 event of the method control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void method_3(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// Handles the 4 event of the method control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void method_4(object sender, EventArgs e)
        {
            Ellipse.Apply(this.lblpass, this.lblpass.Height);
            this.lblpass.Top = base.Height / 2 - this.lblpass.Height / 2;
            this.lblpass.Left = base.Width / 2 - this.lblpass.Width / 2;
        }

        /// <summary>
        /// Handles the Tick event of the timer_0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer_0_Tick(object sender, EventArgs e)
        {
            int num = 0;
            int num1 = 0;
            int num2;
            if (this.Value == this.MaximumValue || this.Value <= 0)
            {
                do
                {
                    if (num != num1)
                    {
                        break;
                    }
                    num1 = 1;
                    num2 = num;
                    num = 1;
                }
                while (1 <= num2);
            }
            else
            {
                this.int_5 = this.int_5 + this.AnimationInterval;
                this.method_2(this.int_2);
            }
        }

        /// <summary>
        /// Occurs when [progress changed].
        /// </summary>
        public event EventHandler ProgressChanged
        {
            add
            {
                EventHandler eventHandler;
                EventHandler eventHandler0 = this.eventHandler_0;
                do
                {
                    eventHandler = eventHandler0;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
                    eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
                }
                while ((object)eventHandler0 != (object)eventHandler);
            }
            remove
            {
                EventHandler eventHandler;
                EventHandler eventHandler0 = this.eventHandler_0;
                do
                {
                    eventHandler = eventHandler0;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
                    eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
                }
                while ((object)eventHandler0 != (object)eventHandler);
            }
        }

        
    }


    /// <summary>
    /// Class RectangleParemeters.
    /// </summary>
    public class RectangleParemeters
    {
        /// <summary>
        /// The vertical shift
        /// </summary>
        private int verticalShift = 10;
        /// <summary>
        /// The horizontal shift
        /// </summary>
        private int horizontalShift = 10;
        /// <summary>
        /// The width shift
        /// </summary>
        private int widthShift = 20;
        /// <summary>
        /// The height shift
        /// </summary>
        private int heightShift = 20;

        /// <summary>
        /// Gets or sets the vertical shift.
        /// </summary>
        /// <value>The vertical shift.</value>
        public int VerticalShift
        {
            get { return verticalShift; }
            set { verticalShift = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal shift.
        /// </summary>
        /// <value>The horizontal shift.</value>
        public int HorizontalShift
        {
            get { return horizontalShift; }
            set { horizontalShift = value; }
        }

        /// <summary>
        /// Gets or sets the width shift.
        /// </summary>
        /// <value>The width shift.</value>
        public int WidthShift
        {
            get { return widthShift; }
            set { widthShift = value; }
        }

        /// <summary>
        /// Gets or sets the height shift.
        /// </summary>
        /// <value>The height shift.</value>
        public int HeightShift
        {
            get { return heightShift; }
            set { heightShift = value; }
        }

    }
}
