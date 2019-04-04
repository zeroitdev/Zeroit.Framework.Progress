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
	[DefaultEvent("ValueChanged")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuVTrackbar : UserControl
	{
		private int int_0 = 100;

		private int int_1;

		private int int_2;

		private int int_3;

		private IContainer icontainer_0;

		private Panel bg;

		private Panel slider;

        EventHandler eventHandler_0;

        public Color BackgroudColor
		{
			get
			{
				return this.bg.BackColor;
			}
			set
			{
				this.bg.BackColor = value;
			}
		}

		public int BorderRadius
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				Elipse.Apply(this.bg, this.int_2);
			}
		}

		public Color IndicatorColor
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

		public int MaximumValue
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.slider.Top = (base.Height - 15) * this.int_1 / this.int_0;
			}
		}

		public int SliderRadius
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				Elipse.Apply(this.slider, this.int_3);
			}
		}

		public int Value
		{
			get
			{
				return this.int_1;
			}
			set
			{
				if (value > this.int_0)
				{
					MessageBox.Show("Cannot exceed maximum Value");
					return;
				}
				this.int_1 = value;
				double height = (double)base.Height;
				double num = (double)this.slider.Height;
				int top = this.slider.Top;
				double int1 = (double)this.int_1 * (height - num) / (double)this.MaximumValue;
				this.slider.Top = (int)Math.Truncate(int1);
			}
		}

		public BunifuVTrackbar()
		{
			this.InitializeComponent();
			BunifuCustomControl.initializeComponent(this);
		}

		private void bg_MouseDown(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int y = e.Y;
				if (y >= 0 && y + this.slider.Height <= base.Height)
				{
					this.slider.Top = y;
					double height = (double)base.Height;
					double height1 = (double)this.slider.Height;
					double top = (double)this.slider.Top;
					double maximumValue = (double)this.MaximumValue * top / (height - height1);
					this.int_1 = (int)Math.Truncate(maximumValue);
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
						return;
					}
					this.eventHandler_0(this, new EventArgs());
					return;
				}
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

		private void bg_Paint(object sender, PaintEventArgs e)
		{
		}

		private void BunifuVTrackbar_Load(object sender, EventArgs e)
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
				BunifuCustomControl.initializeComponent(this);
			}
		}

		private void BunifuVTrackbar_Resize(object sender, EventArgs e)
		{
			base.Width = this.slider.Width + 10;
			this.bg.Height = base.Height;
			this.bg.Top = 0;
			Elipse.Apply(this.bg, this.int_2);
			Elipse.Apply(this.slider, this.int_3);
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
			this.bg = new Panel();
			this.slider = new Panel();
			base.SuspendLayout();
			this.bg.BackColor = Color.DarkGray;
			this.bg.Cursor = Cursors.Hand;
			this.bg.Location = new Point(9, 8);
			this.bg.Name = "bg";
			this.bg.Size = new System.Drawing.Size(10, 408);
			this.bg.TabIndex = 0;
			this.bg.Paint += new PaintEventHandler(this.bg_Paint);
			this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
			this.slider.BackColor = Color.SeaGreen;
			this.slider.Cursor = Cursors.Hand;
			this.slider.Location = new Point(4, 0);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(20, 20);
			this.slider.TabIndex = 1;
			this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.slider);
			base.Controls.Add(this.bg);
			base.Name = "BunifuVTrackbar";
			base.Size = new System.Drawing.Size(28, 415);
			base.Load += new EventHandler(this.BunifuVTrackbar_Load);
			base.Resize += new EventHandler(this.BunifuVTrackbar_Resize);
			base.ResumeLayout(false);
		}

		private void slider_MouseMove(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int y = e.Y + this.slider.Top;
				if (y < 0)
				{
					this.slider.Top = 0;
					this.int_1 = 0;
				}
				else if (y + this.slider.Height <= base.Height)
				{
					this.slider.Top = y;
					double height = (double)base.Height;
					double height1 = (double)this.slider.Height;
					double top = (double)this.slider.Top;
					double maximumValue = (double)this.MaximumValue * top / (height - height1);
					this.int_1 = (int)Math.Truncate(maximumValue);
				}
				else
				{
					this.slider.Top = base.Height - this.slider.Height;
					this.int_1 = this.MaximumValue;
				}
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
					return;
				}
				this.eventHandler_0(this, new EventArgs());
				return;
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

		public event EventHandler ValueChanged
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