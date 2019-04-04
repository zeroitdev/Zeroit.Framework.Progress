using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("Click")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuSwitch : UserControl
	{
		private bool bool_0 = true;

		private Color color_0 = Color.SeaGreen;

		private Color color_1 = Color.DarkGray;

		private int int_0;

		private int int_1;

		private int int_2;

		private IContainer icontainer_0;

		private Panel panel1;

		private BunifuCustomLabel customLabel1;
        
        public int BorderRadius
		{
			get
			{
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				Elipse.Apply(this, this.int_2);
			}
		}

		public Color Oncolor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				if (this.bool_0)
				{
					this.panel1.BackColor = value;
				}
				this.color_0 = value;
			}
		}

		public Color Onoffcolor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				if (!this.bool_0)
				{
					this.panel1.BackColor = value;
				}
				this.color_1 = value;
			}
		}

		public Color Textcolor
		{
			get
			{
				return this.customLabel1.ForeColor;
			}
			set
			{
				this.customLabel1.ForeColor = value;
			}
		}

		public bool Value
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (!value)
				{
					this.panel1.Dock = DockStyle.Right;
					this.panel1.BackColor = this.color_1;
					this.customLabel1.Dock = DockStyle.Left;
					this.customLabel1.Text = "Off";
				}
				else
				{
					this.panel1.Dock = DockStyle.Left;
					this.panel1.BackColor = this.color_0;
					this.customLabel1.Dock = DockStyle.Right;
					this.customLabel1.Text = "On";
				}
				this.bool_0 = value;
			}
		}

		public BunifuSwitch()
		{
			this.InitializeComponent();
			this.int_0 = base.Width;
			this.int_1 = base.Height;
			BunifuCustomControl.initializeComponent(this);
		}

		private void BunifuSwitch_Click(object sender, EventArgs e)
		{
			this.Value = !this.Value;
		}

		private void BunifuSwitch_ForeColorChanged(object sender, EventArgs e)
		{
			this.customLabel1.ForeColor = this.ForeColor;
		}

		private void BunifuSwitch_Load(object sender, EventArgs e)
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

		private void BunifuSwitch_Resize(object sender, EventArgs e)
		{
			Elipse.Apply(this, this.int_2);
			base.Width = this.int_0;
			base.Height = this.int_1;
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
			this.panel1 = new Panel();
			this.customLabel1 = new BunifuCustomLabel();
			base.SuspendLayout();
			this.panel1.BackColor = Color.SeaGreen;
			this.panel1.Cursor = Cursors.Hand;
			this.panel1.Dock = DockStyle.Left;
			this.panel1.Enabled = false;
			this.panel1.Location = new Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(37, 19);
			this.panel1.TabIndex = 0;
			this.panel1.Click += new EventHandler(this.BunifuSwitch_Click);
			this.customLabel1.Dock = DockStyle.Right;
			this.customLabel1.Enabled = false;
			this.customLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.customLabel1.ForeColor = Color.FromArgb(224, 224, 224);
			this.customLabel1.Location = new Point(26, 0);
			this.customLabel1.Name = "customLabel1";
			this.customLabel1.Size = new System.Drawing.Size(25, 19);
			this.customLabel1.TabIndex = 1;
			this.customLabel1.Text = "On";
			this.customLabel1.TextAlign = ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(64, 64, 64);
			base.Controls.Add(this.customLabel1);
			base.Controls.Add(this.panel1);
			this.Cursor = Cursors.Hand;
			this.ForeColor = Color.FromArgb(224, 224, 224);
			base.Name = "BunifuSwitch";
			base.Size = new System.Drawing.Size(51, 19);
			base.Load += new EventHandler(this.BunifuSwitch_Load);
			base.ForeColorChanged += new EventHandler(this.BunifuSwitch_ForeColorChanged);
			base.Click += new EventHandler(this.BunifuSwitch_Click);
			base.Resize += new EventHandler(this.BunifuSwitch_Resize);
			base.ResumeLayout(false);
		}
	}
}