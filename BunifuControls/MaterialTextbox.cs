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
	public class BunifuMaterialTextbox : UserControl
	{
		private Color color_0 = Color.Gray;

		private Color color_1 = Color.Blue;

		private Color color_2 = Color.Blue;

		private Color color_3;

		private string string_0 = "";

		private bool bool_0;

		private bool bool_1;

		private IContainer icontainer_0;

		private TextBox textBox1;

		private System.Windows.Forms.Timer timer_0;

		private Panel panel1;

        EventHandler eventHandler_0;

        public Color HintForeColor
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
				{
					this.textBox1.ForeColor = this.ForeColor;
					return;
				}
				this.textBox1.ForeColor = this.HintForeColor;
				this.textBox1.Text = this.HintText;
			}
		}

		public string HintText
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
				{
					this.textBox1.ForeColor = this.ForeColor;
					return;
				}
				this.textBox1.ForeColor = this.HintForeColor;
				this.textBox1.Text = this.HintText;
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
				this.bool_0 = this.textBox1.UseSystemPasswordChar;
				return this.textBox1.UseSystemPasswordChar;
			}
			set
			{
				this.textBox1.UseSystemPasswordChar = value;
			}
		}

		public Color LineFocusedColor
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

		public Color LineIdleColor
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

		public Color LineMouseHoverColor
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

		public int LineThickness
		{
			get
			{
				return this.panel1.Height;
			}
			set
			{
				if (value <= 0)
				{
					throw new Exception("Value shoud be grater than 0");
				}
				this.panel1.Height = value;
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
				if (this.textBox1.Text == this.HintText)
				{
					return "";
				}
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

		public BunifuMaterialTextbox()
		{
			this.InitializeComponent();
		}

		private void BunifuMaterialTextbox_BackColorChanged(object sender, EventArgs e)
		{
			this.textBox1.BackColor = this.BackColor;
		}

		private void BunifuMaterialTextbox_Click(object sender, EventArgs e)
		{
			this.textBox1.Focus();
		}

		private void BunifuMaterialTextbox_FontChanged(object sender, EventArgs e)
		{
			this.textBox1.Font = this.Font;
			this.textBox1.Left = 5;
			this.textBox1.Width = base.Width - this.textBox1.Left * 2;
			this.textBox1.Top = base.Height / 2 - this.textBox1.Height / 2;
		}

		private void BunifuMaterialTextbox_ForeColorChanged(object sender, EventArgs e)
		{
			this.textBox1.ForeColor = this.ForeColor;
		}

		private void BunifuMaterialTextbox_Load(object sender, EventArgs e)
		{
			if (!base.DesignMode)
			{
				this.timer_0.Start();
			}
			if (base.DesignMode)
			{
				BunifuCustomControl.initializeComponent(this);
			}
			if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
			{
				this.textBox1.ForeColor = this.ForeColor;
				return;
			}
			this.textBox1.ForeColor = this.HintForeColor;
			this.textBox1.Text = this.HintText;
		}

		private void BunifuMaterialTextbox_MouseEnter(object sender, EventArgs e)
		{
		}

		private void BunifuMaterialTextbox_MouseLeave(object sender, EventArgs e)
		{
		}

		private void BunifuMaterialTextbox_ParentChanged(object sender, EventArgs e)
		{
		}

		private void BunifuMaterialTextbox_Resize(object sender, EventArgs e)
		{
			if (base.Height < this.textBox1.Height + 5)
			{
				base.Height = this.textBox1.Height + 5;
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
			this.panel1 = new Panel();
			base.SuspendLayout();
			this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			this.textBox1.BackColor = SystemColors.ActiveBorder;
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox1.ForeColor = Color.FromArgb(64, 64, 64);
			this.textBox1.Location = new Point(8, 8);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(362, 16);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyDown += new KeyEventHandler(this.textBox1_KeyDown);
			this.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
			this.textBox1.KeyUp += new KeyEventHandler(this.textBox1_KeyUp);
			this.textBox1.MouseEnter += new EventHandler(this.textBox1_MouseEnter);
			this.timer_0.Tick += new EventHandler(this.timer_0_Tick);
			this.panel1.BackColor = Color.Gray;
			this.panel1.Dock = DockStyle.Bottom;
			this.panel1.Location = new Point(0, 30);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(379, 3);
			this.panel1.TabIndex = 1;
			base.AutoScaleDimensions = new SizeF(8f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.textBox1);
			this.Cursor = Cursors.IBeam;
			this.Font = new System.Drawing.Font("Century Gothic", 9.75f);
			this.ForeColor = Color.FromArgb(64, 64, 64);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "BunifuMaterialTextbox";
			base.Size = new System.Drawing.Size(379, 33);
			base.Load += new EventHandler(this.BunifuMaterialTextbox_Load);
			base.BackColorChanged += new EventHandler(this.BunifuMaterialTextbox_BackColorChanged);
			base.FontChanged += new EventHandler(this.BunifuMaterialTextbox_FontChanged);
			base.ForeColorChanged += new EventHandler(this.BunifuMaterialTextbox_ForeColorChanged);
			base.Click += new EventHandler(this.BunifuMaterialTextbox_Click);
			base.MouseEnter += new EventHandler(this.BunifuMaterialTextbox_MouseEnter);
			base.MouseLeave += new EventHandler(this.BunifuMaterialTextbox_MouseLeave);
			base.Resize += new EventHandler(this.BunifuMaterialTextbox_Resize);
			base.ParentChanged += new EventHandler(this.BunifuMaterialTextbox_ParentChanged);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void method_0(object sender, EventArgs e)
		{
			this.OnMouseLeave(e);
		}

		private void method_1(object sender, EventArgs e)
		{
		}

		public new void Refresh()
		{
			if (this.isOnFocused)
			{
				this.panel1.BackColor = this.color_1;
				return;
			}
			this.panel1.BackColor = this.LineIdleColor;
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
					this.panel1.BackColor = this.LineMouseHoverColor;
				}
				else
				{
					this.panel1.BackColor = this.LineFocusedColor;
					if (this.textBox1.Text == this.HintText)
					{
						this.textBox1.Text = "";
					}
				}
			}
			else if (!this.isOnFocused)
			{
				this.panel1.BackColor = this.LineIdleColor;
				if (this.textBox1.Text.Length > 0 && this.textBox1.Text != this.HintText)
				{
					this.textBox1.ForeColor = this.ForeColor;
					if (this.bool_0)
					{
						this.textBox1.UseSystemPasswordChar = true;
						this.bool_0 = false;
					}
				}
				else if (!this.textBox1.Focused)
				{
					this.textBox1.ForeColor = this.HintForeColor;
					this.textBox1.Text = this.HintText;
					if (this.isPassword)
					{
						this.textBox1.UseSystemPasswordChar = false;
						this.bool_0 = true;
					}
				}
			}
			else
			{
				this.panel1.BackColor = this.LineFocusedColor;
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