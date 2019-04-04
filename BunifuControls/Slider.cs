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
	public class BunifuSlider : UserControl
	{
		private int int_0 = 100;

		private int int_1;

		private int int_2;

		private IContainer icontainer_0;

		private Panel bg;

		private Panel slider;

		private Panel panel1;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;

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
				Elipse.Apply(this.slider, this.int_2);
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
				this.panel1.BackColor = this.slider.BackColor;
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
				double width = (double)base.Width;
				double num = (double)this.slider.Width;
				int left = this.slider.Left;
				double int1 = (double)this.int_1 * (width - num) / (double)this.MaximumValue;
				this.slider.Left = (int)Math.Truncate(int1);
				this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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
				double width = (double)base.Width;
				double num = (double)this.slider.Width;
				int left = this.slider.Left;
				double int1 = (double)this.int_1 * (width - num) / (double)this.MaximumValue;
				this.slider.Left = (int)Math.Truncate(int1);
				this.panel1.Width = this.slider.Left + this.slider.Width / 2;
			}
		}

		public BunifuSlider()
		{
			this.InitializeComponent();
			this.panel1.Width = this.slider.Left + this.slider.Width / 2;
			BunifuCustomControl.initializeComponent(this);
		}

		private void bg_MouseDown(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				int x = e.X;
				if (x > 0 && x + this.slider.Width < base.Width)
				{
					this.slider.Left = x;
					double width = (double)base.Width;
					double width1 = (double)this.slider.Width;
					double left = (double)this.slider.Left;
					double maximumValue = (double)this.MaximumValue * left / (width - width1);
					this.int_1 = (int)Math.Truncate(maximumValue);
					this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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

		private void BunifuSlider_Load(object sender, EventArgs e)
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

		private void BunifuSlider_Resize(object sender, EventArgs e)
		{
			base.Height = this.slider.Height + 10;
			this.bg.Width = base.Width;
			this.bg.Left = 0;
			Elipse.Apply(this.bg, this.int_2);
			Elipse.Apply(this.slider, this.int_2);
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
			this.panel1 = new Panel();
			this.slider = new Panel();
			this.bg.SuspendLayout();
			base.SuspendLayout();
			this.bg.BackColor = Color.DarkGray;
			this.bg.Controls.Add(this.panel1);
			this.bg.Cursor = Cursors.Hand;
			this.bg.Location = new Point(3, 8);
			this.bg.Name = "bg";
			this.bg.Size = new System.Drawing.Size(408, 10);
			this.bg.TabIndex = 0;
			this.bg.Paint += new PaintEventHandler(this.bg_Paint);
			this.bg.MouseDown += new MouseEventHandler(this.bg_MouseDown);
			this.panel1.BackColor = Color.SeaGreen;
			this.panel1.Cursor = Cursors.Hand;
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Enabled = false;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0, 10);
			this.panel1.TabIndex = 2;
			this.slider.BackColor = Color.SeaGreen;
			this.slider.Cursor = Cursors.Hand;
			this.slider.Location = new Point(0, 3);
			this.slider.Name = "slider";
			this.slider.Size = new System.Drawing.Size(20, 20);
			this.slider.TabIndex = 1;
			this.slider.MouseMove += new MouseEventHandler(this.slider_MouseMove);
			this.slider.MouseUp += new MouseEventHandler(this.slider_MouseUp);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.slider);
			base.Controls.Add(this.bg);
			base.Name = "BunifuSlider";
			base.Size = new System.Drawing.Size(415, 28);
			base.Load += new EventHandler(this.BunifuSlider_Load);
			base.Resize += new EventHandler(this.BunifuSlider_Resize);
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
				if (x < 0)
				{
					this.slider.Left = 0;
					this.int_1 = 0;
				}
				else if (x + this.slider.Width <= base.Width)
				{
					this.slider.Left = x;
					double width = (double)base.Width;
					double width1 = (double)this.slider.Width;
					double left = (double)this.slider.Left;
					double maximumValue = (double)this.MaximumValue * left / (width - width1);
					this.int_1 = (int)Math.Truncate(maximumValue);
				}
				else
				{
					this.slider.Left = base.Width - this.slider.Width;
					this.int_1 = this.MaximumValue;
				}
				this.panel1.Width = this.slider.Left + this.slider.Width / 2;
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

		private void slider_MouseUp(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
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
			}
			else
			{
				this.eventHandler_1(this, new EventArgs());
			}
		}

		public event EventHandler ValueChangeComplete
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