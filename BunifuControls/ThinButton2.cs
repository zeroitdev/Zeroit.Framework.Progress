using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DefaultEvent("Click")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuThinButton2 : UserControl
	{
		private Color color_0 = Color.SeaGreen;

		private Color color_1 = Color.White;

		private Color color_2 = Color.SeaGreen;

		private int int_0 = 20;

		private int int_1 = 1;

		private Color color_3 = Color.SeaGreen;

		private Color color_4 = Color.SeaGreen;

		private Color color_5 = Color.White;

		private int int_2 = 20;

		private int int_3 = 1;

		public bool Onfocus;

		private IContainer icontainer_0;

		private BunifuCustomLabel label1;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;
        EventHandler eventHandler_2;
        EventHandler eventHandler_3;
        EventHandler eventHandler_4;
        EventHandler eventHandler_5;

        public int ActiveBorderThickness
		{
			get
			{
				return this.int_1;
			}
			set
			{
				int num = 0;
				int num1 = 0;
				int num2;
				if (value <= 0)
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
					this.int_1 = value;
					this.Refresh();
				}
			}
		}

		public int ActiveCornerRadius
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.Refresh();
			}
		}

		public Color ActiveFillColor
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.Refresh();
			}
		}

		public Color ActiveForecolor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.Refresh();
			}
		}

		public Color ActiveLineColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.Refresh();
			}
		}

		public string ButtonText
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
				this.label1.Text = value;
				this.OnResize(new EventArgs());
			}
		}

		public int IdleBorderThickness
		{
			get
			{
				return this.int_3;
			}
			set
			{
				int num = 0;
				int num1 = 0;
				int num2;
				if (value <= 0)
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
					this.int_3 = value;
					this.Refresh();
				}
			}
		}

		public int IdleCornerRadius
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.Refresh();
			}
		}

		public Color IdleFillColor
		{
			get
			{
				return this.color_5;
			}
			set
			{
				this.color_5 = value;
				this.Refresh();
			}
		}

		public Color IdleForecolor
		{
			get
			{
				return this.color_4;
			}
			set
			{
				this.color_4 = value;
				this.Refresh();
			}
		}

		public Color IdleLineColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.Refresh();
			}
		}

		public ContentAlignment TextAlign
		{
			get
			{
				return this.label1.TextAlign;
			}
			set
			{
				this.label1.TextAlign = this.label1.TextAlign;
			}
		}

		public BunifuThinButton2()
		{
			this.InitializeComponent();
			base.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
		}

		private void BunifuThinButton2_FontChanged(object sender, EventArgs e)
		{
			this.label1.Font = this.Font;
		}

		private void BunifuThinButton2_ForeColorChanged(object sender, EventArgs e)
		{
			this.label1.ForeColor = this.ForeColor;
		}

		private void BunifuThinButton2_Load(object sender, EventArgs e)
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

		private void BunifuThinButton2_MouseEnter(object sender, EventArgs e)
		{
			this.Onfocus = true;
			this.Refresh();
		}

		private void BunifuThinButton2_MouseLeave(object sender, EventArgs e)
		{
			this.Onfocus = false;
			this.Refresh();
		}

		private void BunifuThinButton2_Resize(object sender, EventArgs e)
		{
			this.label1.Left = base.Width / 2 - this.label1.Width / 2;
			this.label1.Top = base.Height / 2 - this.label1.Height / 2 + 2;
			this.Refresh();
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
			this.label1 = new BunifuCustomLabel();
			base.SuspendLayout();
			this.label1.BackColor = Color.Transparent;
			this.label1.Dock = DockStyle.Fill;
			this.label1.Location = new Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(181, 41);
			this.label1.TabIndex = 0;
			this.label1.Text = "ThinButton";
			this.label1.TextAlign = ContentAlignment.MiddleCenter;
			this.label1.Click += new EventHandler(this.label1_Click);
			this.label1.MouseDown += new MouseEventHandler(this.label1_MouseDown);
			this.label1.MouseEnter += new EventHandler(this.label1_MouseEnter);
			this.label1.MouseLeave += new EventHandler(this.label1_MouseLeave);
			this.label1.MouseHover += new EventHandler(this.label1_MouseHover);
			this.label1.MouseMove += new MouseEventHandler(this.label1_MouseMove);
			base.AutoScaleDimensions = new SizeF(10f, 21f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.White;
			base.Controls.Add(this.label1);
			this.Cursor = Cursors.Hand;
			this.Font = new System.Drawing.Font("Century Gothic", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.ForeColor = Color.SeaGreen;
			base.Margin = new System.Windows.Forms.Padding(5);
			base.Name = "BunifuThinButton2";
			base.Size = new System.Drawing.Size(181, 41);
			base.Load += new EventHandler(this.BunifuThinButton2_Load);
			base.FontChanged += new EventHandler(this.BunifuThinButton2_FontChanged);
			base.ForeColorChanged += new EventHandler(this.BunifuThinButton2_ForeColorChanged);
			this.MouseEnter += new EventHandler(this.BunifuThinButton2_MouseEnter);
			this.MouseLeave += new EventHandler(this.BunifuThinButton2_MouseLeave);
			base.Resize += new EventHandler(this.BunifuThinButton2_Resize);
			base.ResumeLayout(false);
		}

		private void label1_Click(object sender, EventArgs e)
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
				this.eventHandler_0(this, e);
			}
		}

		private void label1_MouseDown(object sender, MouseEventArgs e)
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
				this.eventHandler_1(this, e);
			}
		}

		private void label1_MouseEnter(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
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
			}
			else
			{
				this.eventHandler_2(this, e);
			}
		}

		private void label1_MouseHover(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_3 == null)
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
				this.eventHandler_3(this, e);
			}
		}

		private void label1_MouseLeave(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_4 == null)
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
				this.eventHandler_4(this, e);
			}
		}

		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_5 == null)
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
				this.eventHandler_5(this, e);
			}
		}

		private void method_0(System.Drawing.Graphics graphics_0, Rectangle rectangle_0, int int_4, Pen pen_0, Color color_6)
		{
			graphics_0.Clear(this.BackColor);
			GraphicsPath graphicsPath = new GraphicsPath();
			pen_0.StartCap = LineCap.Round;
			pen_0.EndCap = LineCap.Round;
			graphicsPath.AddArc(rectangle_0.X, rectangle_0.Y, int_4, int_4, 180f, 90f);
			graphicsPath.AddArc(rectangle_0.X + rectangle_0.Width - int_4, rectangle_0.Y, int_4, int_4, 270f, 90f);
			graphicsPath.AddArc(rectangle_0.X + rectangle_0.Width - int_4, rectangle_0.Y + rectangle_0.Height - int_4, int_4, int_4, 0f, 90f);
			graphicsPath.AddArc(rectangle_0.X, rectangle_0.Y + rectangle_0.Height - int_4, int_4, int_4, 90f, 90f);
			graphicsPath.CloseAllFigures();
			graphics_0.FillPath(new SolidBrush(color_6), graphicsPath);
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			graphics_0.DrawPath(pen_0, graphicsPath);
			graphics_0.SmoothingMode = SmoothingMode.AntiAlias;
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			this.BackColor = base.Parent.BackColor;
			base.OnParentBackColorChanged(e);
		}

		protected override void OnParentChanged(EventArgs e)
		{
			if (base.Parent != null)
			{
				this.BackColor = base.Parent.BackColor;
			}
			base.OnParentChanged(e);
		}

		public new void Refresh()
		{
			Bitmap bitmap = new Bitmap(base.Size.Width, base.Size.Height);
			System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap);
			graphic.SmoothingMode = SmoothingMode.HighQuality;
			graphic.Clear(Color.Transparent);
			if (!this.Onfocus)
			{
				Rectangle rectangle = new Rectangle(this.int_3, this.int_3 + 5, base.Width - this.int_3 * 2, base.Height - this.int_3 * 2 - 10);
				this.label1.ForeColor = this.color_4;
				if (!base.DesignMode)
				{
					Application.DoEvents();
				}
				this.method_0(graphic, rectangle, this.int_2, new Pen(this.color_3, (float)this.int_3), this.color_5);
			}
			else
			{
				Rectangle rectangle1 = new Rectangle(this.int_1, this.int_1 + 5, base.Width - this.int_1 * 2, base.Height - this.int_1 * 2 - 10);
				this.label1.ForeColor = this.color_1;
				if (!base.DesignMode)
				{
					Application.DoEvents();
				}
				this.method_0(graphic, rectangle1, this.int_0, new Pen(this.color_0, (float)this.int_1), this.color_2);
			}
			this.BackgroundImage = bitmap;
		}

		public event EventHandler Click
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

		public event EventHandler MouseDown
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

		public event EventHandler MouseEnter
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

		public event EventHandler MouseHover
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler3 = this.eventHandler_3;
				do
				{
					eventHandler = eventHandler3;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler3 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, eventHandler1, eventHandler);
				}
				while ((object)eventHandler3 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler3 = this.eventHandler_3;
				do
				{
					eventHandler = eventHandler3;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler3 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, eventHandler1, eventHandler);
				}
				while ((object)eventHandler3 != (object)eventHandler);
			}
		}

		public event EventHandler MouseLeave
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler4 = this.eventHandler_4;
				do
				{
					eventHandler = eventHandler4;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler4 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_4, eventHandler1, eventHandler);
				}
				while ((object)eventHandler4 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler4 = this.eventHandler_4;
				do
				{
					eventHandler = eventHandler4;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler4 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_4, eventHandler1, eventHandler);
				}
				while ((object)eventHandler4 != (object)eventHandler);
			}
		}

		public event EventHandler MouseMove
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler5 = this.eventHandler_5;
				do
				{
					eventHandler = eventHandler5;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_5, eventHandler1, eventHandler);
				}
				while ((object)eventHandler5 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler5 = this.eventHandler_5;
				do
				{
					eventHandler = eventHandler5;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_5, eventHandler1, eventHandler);
				}
				while ((object)eventHandler5 != (object)eventHandler);
			}
		}
	}
}