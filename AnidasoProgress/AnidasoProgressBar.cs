// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ZeroitAnidasoProgressBar.cs" company="Zeroit Dev Technologies">
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
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// A class collection for rendering a progressbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DebuggerStepThrough]
	[DefaultEvent("progressChanged")]
	public class ZeroitAnidasoProgressBar : UserControl
	{

        #region Private Fields
        /// <summary>
        /// The value
        /// </summary>
        public int _Value;

        /// <summary>
        /// The maximum value
        /// </summary>
        public int Maximum_Value = 100;

        /// <summary>
        /// The int 0
        /// </summary>
        private int int_0 = 5;

        /// <summary>
        /// The icontainer 0
        /// </summary>
        private IContainer icontainer_0;

        /// <summary>
        /// The slider
        /// </summary>
        private Panel slider;

        /// <summary>
        /// The event handler 0
        /// </summary>
        EventHandler eventHandler_0;
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
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
                Ellipse.Apply(this.slider, this.int_0);
                Ellipse.Apply(this, this.int_0);
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
                return this.Maximum_Value;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                this.Maximum_Value = value;
                try
                {
                    this.slider.Width = base.Width * this._Value / this.Maximum_Value;
                    Ellipse.Apply(this.slider, this.int_0);
                }
                catch (Exception exception)
                {
                }
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
        }

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        public Color ProgressColor
        {
            get
            {
                return this.slider.BackColor;
            }
            set
            {
                this.slider.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="Exception">Maxium Value Rached</exception>
        public int Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                int num = 0;
                int num1 = 0;
                int num2;
                if (value > this.Maximum_Value)
                {
                    throw new Exception("Maxium Value Rached");
                }
                this._Value = value;
                this.slider.Width = base.Width * this._Value / this.Maximum_Value;
                Ellipse.Apply(this.slider, this.int_0);
                if (this.eventHandler_0 != null)
                {
                    this.eventHandler_0(this, new EventArgs());
                    return;
                }
                do
                {
                    if (num == num1)
                    {
                        num1 = 1;
                        num2 = num;
                        num = 1;
                    }
                    else
                    {
                        break;
                    }
                }
                while (1 <= num2);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitAnidasoProgressBar" /> class.
        /// </summary>
        public ZeroitAnidasoProgressBar()
        {
            this.InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Handles the Load event of the ZeroitAnidasoProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnidasoProgressBar_Load(object sender, EventArgs e)
		{
			AnidasoCustomControl.initializeComponent(this);
		}

        /// <summary>
        /// Handles the Resize event of the ZeroitAnidasoProgressBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnidasoProgressBar_Resize(object sender, EventArgs e)
		{
			this.slider.Width = base.Width * this._Value / this.Maximum_Value;
			Ellipse.Apply(this.slider, this.int_0);
			Ellipse.Apply(this, this.int_0);
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
			this.slider = new Panel();
			base.SuspendLayout();
			this.slider.BackColor = Color.Teal;
			this.slider.Dock = DockStyle.Left;
			this.slider.Location = new Point(0, 0);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(0, 10);
			this.slider.TabIndex = 1;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Silver;
			base.Controls.Add(this.slider);
			base.Name = "ZeroitAnidasoProgressBar";
			base.Size = new System.Drawing.Size(410, 10);
			base.Load += new EventHandler(this.AnidasoProgressBar_Load);
			base.Resize += new EventHandler(this.AnidasoProgressBar_Resize);
			base.ResumeLayout(false);
		}

        /// <summary>
        /// Occurs when [progress changed].
        /// </summary>
        public event EventHandler progressChanged
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
}