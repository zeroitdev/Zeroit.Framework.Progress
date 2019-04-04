// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 08-18-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="SupremeProgressBar.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
	[DefaultEvent("ProgressChanged")]
	[ProvideProperty("ZeroitDev", typeof(Control))]
	public class ZeroitSupremeProgressBar : UserControl
	{
        #region Private Fields
        /// <summary>
        /// The enc list
        /// </summary>
        private static List<WeakReference> __ENCList;

        /// <summary>
        /// The event handler0
        /// </summary>
        private EventHandler EventHandler0;

        /// <summary>
        /// The value
        /// </summary>
        public int Val;

        /// <summary>
        /// The maximum value
        /// </summary>
        public int MaxVal;

        /// <summary>
        /// The int0
        /// </summary>
        private int Int0;

        /// <summary>
        /// The i container0
        /// </summary>
        private IContainer IContainer0;

        /// <summary>
        /// The slider
        /// </summary>
        private Panel Slider;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the border radius.
        /// </summary>
        /// <value>The border radius.</value>
        public int BorderRadius
        {
            get
            {
                return this.Int0;
            }
            set
            {
                this.Int0 = value;
                this.Apply(this.Slider, this.Int0);
                this.Apply(this, this.Int0);
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return this.MaxVal;
            }
            set
            {
                this.MaxVal = value;
                try
                {
                    this.Slider.Width = checked((int)System.Math.Round((double)(checked(base.Width * this.Val)) / (double)this.MaxVal));
                    this.Apply(this.Slider, this.Int0);
                }
                catch (Exception exception)
                {
                    ProjectData.SetProjectError(exception);
                    ProjectData.ClearProjectError();
                }
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
                return this.Slider.BackColor;
            }
            set
            {
                this.Slider.BackColor = value;
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
                return this.Val;
            }
            set
            {
                if (value <= this.MaxVal)
                    this.Val = value;
                this.Slider.Width = checked((int)System.Math.Round((double)(checked(base.Width * this.Val)) / (double)this.MaxVal));
                this.Apply(this.Slider, this.Int0);
                if (this.EventHandler0 != null)
                {
                    this.EventHandler0(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes static members of the <see cref="ZeroitSupremeProgressBar"/> class.
        /// </summary>
        [DebuggerNonUserCode]
        static ZeroitSupremeProgressBar()
        {
            ZeroitSupremeProgressBar.__ENCList = new List<WeakReference>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSupremeProgressBar" /> class.
        /// </summary>
        public ZeroitSupremeProgressBar()
        {
            ZeroitSupremeProgressBar.__ENCAddToList(this);
            this.MaxVal = 100;
            this.Int0 = 5;
            this.InitializeComponent();
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

        #region Private Methods and Events
        /// <summary>
        /// Encs the add to list.
        /// </summary>
        /// <param name="value">The value.</param>
        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            lock (ZeroitSupremeProgressBar.__ENCList)
            {
                if (ZeroitSupremeProgressBar.__ENCList.Count == ZeroitSupremeProgressBar.__ENCList.Capacity)
                {
                    int item = 0;
                    int count = checked(ZeroitSupremeProgressBar.__ENCList.Count - 1);
                    for (int i = 0; i <= count; i++)
                    {
                        if (ZeroitSupremeProgressBar.__ENCList[i].IsAlive)
                        {
                            if (i != item)
                            {
                                ZeroitSupremeProgressBar.__ENCList[item] = ZeroitSupremeProgressBar.__ENCList[i];
                            }
                            item++;
                        }
                    }
                    ZeroitSupremeProgressBar.__ENCList.RemoveRange(item, checked(ZeroitSupremeProgressBar.__ENCList.Count - item));
                    ZeroitSupremeProgressBar.__ENCList.Capacity = ZeroitSupremeProgressBar.__ENCList.Count;
                }
                ZeroitSupremeProgressBar.__ENCList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
            }
        }

        /// <summary>
        /// Applies the specified control.
        /// </summary>
        /// <param name="ctrl">The control.</param>
        /// <param name="Elipse">The elipse.</param>
        public void Apply(Control ctrl, int Elipse)
        {
            try
            {
                ctrl.Region = System.Drawing.Region.FromHrgn(ZeroitSupremeProgressBar.CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, Elipse, Elipse));
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
        /// <param name="Int0">The int0.</param>
        /// <param name="int_1">The int 1.</param>
        /// <param name="int_2">The int 2.</param>
        /// <param name="int_3">The int 3.</param>
        /// <param name="int_4">The int 4.</param>
        /// <param name="int_5">The int 5.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("Gdi32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CreateRoundRectRgn(int Int0, int int_1, int int_2, int int_3, int int_4, int int_5);

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
            this.Slider = new Panel();
            base.SuspendLayout();
            this.Slider.BackColor = SystemColors.HotTrack;
            this.Slider.Dock = DockStyle.Left;
            this.Slider.Location = new Point(0, 0);
            this.Slider.Name = "ProgressBar";
            Panel slider = this.Slider;
            System.Drawing.Size size = new System.Drawing.Size(0, 15);
            slider.Size = size;
            this.Slider.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.Silver;
            base.Controls.Add(this.Slider);
            base.Name = "ShiftProgressBar";
            size = new System.Drawing.Size(410, 15);
            base.Size = size;
            ZeroitSupremeProgressBar shiftProgressBar = this;
            base.Resize += new EventHandler(shiftProgressBar.ShiftProgressBar_Resize);
            base.ResumeLayout(false);
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
        /// Handles the Resize event of the ShiftProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ShiftProgressBar_Resize(object sender, EventArgs e)
        {
            this.Slider.Width = checked((int)System.Math.Round((double)(checked(base.Width * this.Val)) / (double)this.MaxVal));
            this.Apply(this.Slider, this.Int0);
            this.Apply(this, this.Int0);
        }

        /// <summary>
        /// Occurs when [progress changed].
        /// </summary>
        public event EventHandler ProgressChanged
        {
            #region Old Code
            //add
            //{
            //	EventHandler eventHandler;
            //	EventHandler eventHandler0 = this.EventHandler0;
            //	do
            //	{
            //		eventHandler = eventHandler0;
            //		//EventHandler eventHandler1 = (EventHandler)Delegate.Combine((Delegate)eventHandler, (Delegate)Val);
            //		//eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.EventHandler0, eventHandler1, eventHandler);
            //	}
            //	while ((object)eventHandler0 != (object)eventHandler);
            //}
            //remove
            //{
            //	EventHandler eventHandler;
            //	EventHandler eventHandler0 = this.EventHandler0;
            //	do
            //	{
            //		eventHandler = eventHandler0;
            //		//EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, Val);
            //		//eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.EventHandler0, eventHandler1, eventHandler);
            //	}
            //	while ((object)eventHandler0 != (object)eventHandler);
            //} 
            #endregion

            add
            {
                EventHandler eventHandler;
                EventHandler eventHandlers = this.EventHandler0;
                do
                {
                    eventHandler = eventHandlers;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
                    eventHandlers = Interlocked.CompareExchange<EventHandler>(ref this.EventHandler0, eventHandler1, eventHandler);
                }
                while ((object)eventHandlers != (object)eventHandler);
            }

            remove
            {
                EventHandler eventHandler;
                EventHandler eventHandlers = this.EventHandler0;
                do
                {
                    eventHandler = eventHandlers;
                    EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
                    eventHandlers = Interlocked.CompareExchange<EventHandler>(ref this.EventHandler0, eventHandler1, eventHandler);
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


}