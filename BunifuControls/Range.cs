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
	[DefaultEvent("RangeChanged")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuRange : UserControl
	{
		private int int_0 = 100;

		private int int_1;

		private int int_2;

		private int int_3;

		private IContainer icontainer_0;

		private Panel bg;

		private Panel slider;

		private Panel slider2;

		private Panel FILL;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;
        EventHandler eventHandler_2;

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
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				Elipse.Apply(this.bg, this.int_3);
				Elipse.Apply(this.slider, this.int_3);
				Elipse.Apply(this.slider2, this.int_3);
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
				Panel panel = this.slider;
				Panel fILL = this.FILL;
				Color color = value;
				Color color1 = color;
				this.slider2.BackColor = color;
				Color color2 = color1;
				Color color3 = color2;
				fILL.BackColor = color2;
				panel.BackColor = color3;
			}
		}

		public int MaximumRange
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.RangeMax = this.int_0 * this.slider2.Left / (base.Width - 15);
				this.RangeMin = this.int_0 * this.slider.Left / (base.Width - 15);
				this.FILL.Left = this.slider.Left + this.slider.Width / 2;
				this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			}
		}

		public int RangeMax
		{
			get
			{
				return this.int_2;
			}
			set
			{
				int left = this.slider2.Left;
				if (value > this.int_0)
				{
					throw new Exception("Maximum Value Reached");
				}
				this.int_2 = value;
				this.slider2.Left = (base.Width - 15) * this.int_2 / this.int_0;
				if (this.slider2.Left < this.slider.Left)
				{
					this.slider2.Left = left;
					throw new Exception("Minium Value Reached");
				}
				this.FILL.Left = this.slider.Left + this.slider.Width / 2;
				this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			}
		}

		public int RangeMin
		{
			get
			{
				return this.int_1;
			}
			set
			{
				int left = this.slider.Left;
				if (value > this.int_0)
				{
					throw new Exception("Minium Value Reached");
				}
				this.int_1 = value;
				this.slider.Left = (base.Width - 15) * this.int_1 / this.int_0;
				if (this.slider.Left > this.slider2.Left)
				{
					this.slider.Left = left;
					throw new Exception("Minium Value Reached");
				}
				this.FILL.Left = this.slider.Left + this.slider.Width / 2;
				this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			}
		}

		public BunifuRange()
		{
			this.InitializeComponent();
			this.RangeMax = this.int_0 * this.slider2.Left / (base.Width - 15);
			this.RangeMin = this.int_0 * this.slider.Left / (base.Width - 15);
			this.FILL.Left = this.slider.Left + this.slider.Width / 2;
			this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
			BunifuCustomControl.initializeComponent(this);
		}

		private void bg_MouseDown(object sender, MouseEventArgs e)
		{
		}

		private void bg_Paint(object sender, PaintEventArgs e)
		{
		}

		private void bg_Resize(object sender, EventArgs e)
		{
			this.FILL.Height = this.bg.Height + 1;
			this.FILL.Top = -1;
		}

		private void BunifuRange_Load(object sender, EventArgs e)
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

		private void BunifuRange_Resize(object sender, EventArgs e)
		{
			base.Height = this.slider.Height + 10;
			this.bg.Width = base.Width;
			this.bg.Left = 0;
			Elipse.Apply(this.bg, this.int_3);
			Elipse.Apply(this.slider, this.int_3);
			Elipse.Apply(this.slider2, this.int_3);
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
			this.FILL = new Panel();
			this.slider = new Panel();
			this.slider2 = new Panel();
			this.bg.SuspendLayout();
			base.SuspendLayout();
			this.bg.BackColor = Color.DarkGray;
			this.bg.Controls.Add(this.FILL);
			this.bg.Location = new Point(3, 8);
			this.bg.Name = "bg";
			this.bg.Size = new System.Drawing.Size(408, 10);
			this.bg.TabIndex = 0;
			this.bg.Paint += new PaintEventHandler(this.bg_Paint);
			this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
			this.bg.Resize += new EventHandler(this.bg_Resize);
			this.FILL.BackColor = Color.SeaGreen;
			this.FILL.Cursor = Cursors.Hand;
			this.FILL.Location = new Point(18, -5);
			this.FILL.Name = "FILL";
			this.FILL.Size = new System.Drawing.Size(183, 20);
			this.FILL.TabIndex = 3;
			this.slider.BackColor = Color.SeaGreen;
			this.slider.Cursor = Cursors.Hand;
			this.slider.Location = new Point(0, 3);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(20, 20);
			this.slider.TabIndex = 1;
			this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
			this.slider2.BackColor = Color.SeaGreen;
			this.slider2.Cursor = Cursors.Hand;
			this.slider2.Location = new Point(197, 3);
			this.slider2.Name = "slider2";
			this.slider2.Size = new System.Drawing.Size(20, 20);
			this.slider2.TabIndex = 2;
			this.slider2.MouseMove += new MouseEventHandler(this.slider2_MouseMove);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.slider2);
			base.Controls.Add(this.slider);
			base.Controls.Add(this.bg);
			base.Name = "BunifuRange";
			base.Size = new System.Drawing.Size(415, 28);
			base.Load += new EventHandler(this.BunifuRange_Load);
			base.Resize += new EventHandler(this.BunifuRange_Resize);
			this.bg.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void slider_MouseMove(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int x = e.X + this.slider.Left;
				if (x < this.slider2.Left && x > 0 && x + this.slider.Width < base.Width)
				{
					this.slider.Left = x;
					this.FILL.Left = this.slider.Left + this.slider.Width / 2;
					this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
					this.RangeMin = this.int_0 * this.slider.Left / (base.Width - 15);
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, new EventArgs());
					}
					if (this.eventHandler_2 == null)
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
					this.eventHandler_2(this, new EventArgs());
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

		private void slider2_MouseMove(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int x = e.X + this.slider2.Left;
				if (x > this.slider.Left && x + this.slider2.Width < base.Width)
				{
					this.slider2.Left = x;
					this.FILL.Left = this.slider.Left + this.slider.Width / 2;
					this.FILL.Width = this.slider2.Left + this.slider2.Width / 2 - this.FILL.Left;
					this.RangeMax = this.int_0 * this.slider2.Left / (base.Width - 15);
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, new EventArgs());
					}
					if (this.eventHandler_1 == null)
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
					this.eventHandler_1(this, new EventArgs());
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

		public event EventHandler RangeChanged
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

		public event EventHandler RangeMaxChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
		}

		public event EventHandler RangeMinChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
		}
	}
}