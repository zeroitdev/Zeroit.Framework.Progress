using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("progressChanged")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuProgressBar : UserControl
	{
		public int _Value;

		public int Maximum_Value = 100;

		private int int_0 = 5;

		private IContainer icontainer_0;

		private Panel slider;

        EventHandler eventHandler_0;

        public int BorderRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				Elipse.Apply(this.slider, this.int_0);
				Elipse.Apply(this, this.int_0);
			}
		}

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
					Elipse.Apply(this.slider, this.int_0);
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
				Elipse.Apply(this.slider, this.int_0);
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

		public BunifuProgressBar()
		{
			this.InitializeComponent();
		}

		private void BunifuProgressBar_Load(object sender, EventArgs e)
		{
			BunifuCustomControl.initializeComponent(this);
		}

		private void BunifuProgressBar_Resize(object sender, EventArgs e)
		{
			this.slider.Width = base.Width * this._Value / this.Maximum_Value;
			Elipse.Apply(this.slider, this.int_0);
			Elipse.Apply(this, this.int_0);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

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
			base.Name = "BunifuProgressBar";
			base.Size = new System.Drawing.Size(410, 10);
			base.Load += new EventHandler(this.BunifuProgressBar_Load);
			base.Resize += new EventHandler(this.BunifuProgressBar_Resize);
			base.ResumeLayout(false);
		}

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