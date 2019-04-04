using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuSeparator : UserControl
	{
		private bool bool_0;

		private IContainer icontainer_0;

		private PictureBox pictureBox1;

        public Color LineColor
		{
			get
			{
				return this.pictureBox1.BackColor;
			}
			set
			{
				this.pictureBox1.BackColor = value;
			}
		}

		public int LineThickness
		{
			get
			{
				if (this.Vertical)
				{
					return this.pictureBox1.Width;
				}
				return this.pictureBox1.Height;
			}
			set
			{
				if (this.Vertical)
				{
					this.pictureBox1.Width = value;
					return;
				}
				this.pictureBox1.Height = value;
			}
		}

		public int Transparency
		{
			get
			{
				return this.pictureBox1.BackColor.A;
			}
			set
			{
				PictureBox pictureBox = this.pictureBox1;
				byte r = this.pictureBox1.BackColor.R;
				byte g = this.pictureBox1.BackColor.G;
				Color backColor = this.pictureBox1.BackColor;
				pictureBox.BackColor = Color.FromArgb(value, (int)r, (int)g, (int)backColor.B);
			}
		}

		public bool Vertical
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				int num = 0;
				int num1 = 0;
				int num2;
				if (value == this.bool_0)
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
					this.bool_0 = value;
					int height = this.pictureBox1.Height;
					int width = this.pictureBox1.Width;
					this.pictureBox1.Height = width;
					this.pictureBox1.Width = height;
					this.OnResize(new EventArgs());
				}
			}
		}

		public BunifuSeparator()
		{
			this.InitializeComponent();
			this.OnResize(new EventArgs());
			LicenseUsageMode usageMode = LicenseManager.UsageMode;
			BunifuCustomControl.initializeComponent(this);
		}

		private void BunifuSeparator_BackColorChanged(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.BackColor != Color.Transparent)
			{
				throw new Exception("Invalid Value");
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

		private void BunifuSeparator_Load(object sender, EventArgs e)
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

		private void BunifuSeparator_Resize(object sender, EventArgs e)
		{
			if (this.Vertical)
			{
				this.pictureBox1.Top = 0;
				this.pictureBox1.Height = base.Height;
				this.pictureBox1.Left = base.Width / 2 - this.pictureBox1.Width / 2;
				return;
			}
			this.pictureBox1.Left = 0;
			this.pictureBox1.Width = base.Width;
			this.pictureBox1.Top = base.Height / 2 - this.pictureBox1.Height / 2;
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
			this.pictureBox1 = new PictureBox();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.BackColor = Color.DimGray;
			this.pictureBox1.Location = new Point(0, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(639, 1);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.Transparent;
			base.Controls.Add(this.pictureBox1);
			base.Name = "BunifuSeparator";
			base.Size = new System.Drawing.Size(639, 35);
			base.Load += new EventHandler(this.BunifuSeparator_Load);
			base.BackColorChanged += new EventHandler(this.BunifuSeparator_BackColorChanged);
			base.Resize += new EventHandler(this.BunifuSeparator_Resize);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}
	}
}