using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DefaultEvent("OnValueChanged")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuMetroTextbox : UserControl
	{
		private int int_0 = 3;

		private Color color_0 = Color.FromArgb(64, 64, 64);

		private Color color_1 = Color.Blue;

		private Color color_2 = Color.Blue;

		private Color color_3 = Color.SeaGreen;

		private Color color_4 = Color.SeaGreen;

		private System.Drawing.Graphics graphics_0;

		private bool bool_0;

		private IContainer icontainer_0;

		private TextBox textBox1;

		private System.Windows.Forms.Timer timer_0;

        EventHandler eventHandler_0;

        public Color BorderColorFocused
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

		public Color BorderColorIdle
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				if (base.DesignMode)
				{
					this.color_3 = value;
				}
				this.Refresh();
			}
		}

		public Color BorderColorMouseHover
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

		public int BorderThickness
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value <= 0)
				{
					throw new Exception("Value shoud be grater than 0");
				}
				this.int_0 = value;
				this.Refresh();
			}
		}

		public bool isOnFocused
		{
			get
			{
				return this.textBox1 == base.ActiveControl;
			}
		}

		public bool isPassword
		{
			get
			{
				return this.textBox1.UseSystemPasswordChar;
			}
			set
			{
				this.textBox1.UseSystemPasswordChar = value;
			}
		}

		[Bindable(true)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override string Text
		{
			get
			{
				return this.textBox1.Text;
			}
			set
			{
				this.textBox1.Text = value;
			}
		}

		public HorizontalAlignment TextAlign
		{
			get
			{
				return this.textBox1.TextAlign;
			}
			set
			{
				this.textBox1.TextAlign = value;
			}
		}

		public BunifuMetroTextbox()
		{
			this.InitializeComponent();
		}

		private void BunifuMetroTextbox_BackColorChanged(object sender, EventArgs e)
		{
			this.textBox1.BackColor = this.BackColor;
		}

		private void BunifuMetroTextbox_Click(object sender, EventArgs e)
		{
			this.textBox1.Focus();
		}

		private void BunifuMetroTextbox_FontChanged(object sender, EventArgs e)
		{
			this.textBox1.Font = this.Font;
			this.textBox1.Left = this.int_0 + 5;
			this.textBox1.Width = base.Width - this.textBox1.Left * 2;
			this.textBox1.Top = base.Height / 2 - this.textBox1.Height / 2;
		}

		private void BunifuMetroTextbox_ForeColorChanged(object sender, EventArgs e)
		{
			this.textBox1.ForeColor = this.ForeColor;
		}

		private void BunifuMetroTextbox_Load(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (!base.DesignMode)
			{
				this.timer_0.Start();
			}
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

		private void BunifuMetroTextbox_MouseEnter(object sender, EventArgs e)
		{
		}

		private void BunifuMetroTextbox_MouseLeave(object sender, EventArgs e)
		{
		}

		private void BunifuMetroTextbox_ParentChanged(object sender, EventArgs e)
		{
		}

		private void BunifuMetroTextbox_Resize(object sender, EventArgs e)
		{
			if (base.Height < this.textBox1.Height + this.int_0 * 2)
			{
				base.Height = this.textBox1.Height + this.int_0 * 3;
			}
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
			this.icontainer_0 = new System.ComponentModel.Container();
			this.textBox1 = new TextBox();
			this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
			base.SuspendLayout();
			this.textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			this.textBox1.BackColor = SystemColors.Control;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = Color.FromArgb(64, 64, 64);
			this.textBox1.Location = new Point(8, 15);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(353, 16);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
			this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			this.textBox1.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
			this.textBox1.MouseEnter += new EventHandler(this.textBox1_MouseEnter);
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			base.AutoScaleDimensions = new SizeF(8f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.textBox1);
			this.Cursor = Cursors.IBeam;
			this.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.ForeColor = Color.FromArgb(64, 64, 64);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "BunifuMetroTextbox";
			base.Size = new System.Drawing.Size(370, 44);
			base.Load += new EventHandler(this.BunifuMetroTextbox_Load);
			base.BackColorChanged += new EventHandler(this.BunifuMetroTextbox_BackColorChanged);
			base.FontChanged += new EventHandler(this.BunifuMetroTextbox_FontChanged);
			base.ForeColorChanged += new EventHandler(this.BunifuMetroTextbox_ForeColorChanged);
			base.Click += new EventHandler(this.BunifuMetroTextbox_Click);
			base.MouseEnter += new EventHandler(this.BunifuMetroTextbox_MouseEnter);
			base.MouseLeave += new EventHandler(this.BunifuMetroTextbox_MouseLeave);
			base.Resize += new EventHandler(this.BunifuMetroTextbox_Resize);
			base.ParentChanged += new EventHandler(this.BunifuMetroTextbox_ParentChanged);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void method_0(object sender, EventArgs e)
		{
			this.OnMouseLeave(e);
		}

		private void method_1(object sender, EventArgs e)
		{
			this.textBox1.Text = "";
			this.textBox1.Focus();
		}

		private void method_2(object sender, EventArgs e)
		{
			this.OnMouseEnter(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			this.color_3 = this.BorderColorIdle;
			this.graphics_0 = base.CreateGraphics();
			this.graphics_0.Clear(this.BackColor);
			Pen pen = new Pen(this.color_3, (float)this.int_0);
			Rectangle rectangle = new Rectangle(this.int_0, this.int_0, base.Width - this.int_0 * 2, base.Height - this.int_0 * 2);
			this.graphics_0.DrawRectangle(pen, rectangle);
			base.OnPaint(e);
		}

		public new void Refresh()
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.color_3 == this.color_4)
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
				this.graphics_0 = base.CreateGraphics();
				this.graphics_0.Clear(this.BackColor);
				Pen pen = new Pen(this.color_3, (float)this.int_0);
				Rectangle rectangle = new Rectangle(this.int_0, this.int_0, base.Width - this.int_0 * 2, base.Height - this.int_0 * 2);
				this.graphics_0.DrawRectangle(pen, rectangle);
				this.color_4 = this.color_3;
			}
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			this.OnKeyDown(e);
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.OnKeyPress(e);
		}

		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			this.OnKeyUp(e);
		}

		private void textBox1_MouseEnter(object sender, EventArgs e)
		{
			this.OnMouseEnter(e);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
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

		private void timer_0_Tick(object sender, EventArgs e)
		{
			this.timer_0.Start();
			Point screen = base.PointToScreen(Point.Empty);
			if (Control.MousePosition.X > screen.X && Control.MousePosition.X < screen.X + base.Width && Control.MousePosition.Y > screen.Y && Control.MousePosition.Y < screen.Y + base.Height)
			{
				if (!this.isOnFocused)
				{
					this.color_3 = this.BorderColorMouseHover;
					this.Refresh();
				}
				else
				{
					this.color_3 = this.BorderColorFocused;
					this.Refresh();
				}
			}
			else if (!this.isOnFocused)
			{
				this.color_3 = this.BorderColorIdle;
				this.Refresh();
			}
			else
			{
				this.color_3 = this.BorderColorFocused;
				this.Refresh();
			}
			this.timer_0.Start();
		}

		public event EventHandler OnValueChanged
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