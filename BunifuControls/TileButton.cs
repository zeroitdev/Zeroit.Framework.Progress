using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("Click")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuTileButton : UserControl
	{
		private int int_0 = 50;

		private Color color_0 = Color.SeaGreen;

		private Color color_1 = Color.MediumSeaGreen;

		private IContainer icontainer_0;

		private PictureBox img;

		private Label lbl;



		public Color color
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.BackColor = this.color_0;
			}
		}

		public Color colorActive
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
			}
		}

		public System.Drawing.Image Image
		{
			get
			{
				return this.img.Image;
			}
			set
			{
				this.img.Image = value;
			}
		}

		public int ImagePosition
		{
			get
			{
				return this.img.Top;
			}
			set
			{
				this.img.Top = value;
				this.method_0();
			}
		}

		public int ImageZoom
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.method_0();
			}
		}

		public int LabelPosition
		{
			get
			{
				return this.lbl.Height;
			}
			set
			{
				this.lbl.Height = value;
			}
		}

		public string LabelText
		{
			get
			{
				return this.lbl.Text;
			}
			set
			{
				this.lbl.Text = value;
			}
		}

		public BunifuTileButton()
		{
			this.InitializeComponent();
			BunifuCustomControl.initializeComponent(this);
			this.method_0();
		}

		private void BunifuTileButton_FontChanged(object sender, EventArgs e)
		{
			this.lbl.Font = this.Font;
			this.method_0();
		}

		private void BunifuTileButton_ForeColorChanged(object sender, EventArgs e)
		{
			this.lbl.ForeColor = this.ForeColor;
		}

		private void BunifuTileButton_Load(object sender, EventArgs e)
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

		private void BunifuTileButton_MouseEnter(object sender, EventArgs e)
		{
			this.BackColor = this.color_1;
		}

		private void BunifuTileButton_MouseLeave(object sender, EventArgs e)
		{
			this.BackColor = this.color_0;
		}

		private void BunifuTileButton_Resize(object sender, EventArgs e)
		{
			this.method_0();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void img_SizeChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BunifuTileButton));
			this.img = new PictureBox();
			this.lbl = new Label();
			((ISupportInitialize)this.img).BeginInit();
			base.SuspendLayout();
			this.img.Cursor = Cursors.Hand;
			this.img.Enabled = false;
            this.img.Image = Properties.Resources.icons8_Online_Support_64px; //(System.Drawing.Image)componentResourceManager.GetObject("img.Image");
			this.img.Location = new Point(33, 20);
			this.img.Margin = new System.Windows.Forms.Padding(6);
			this.img.Name = "img";
			this.img.Size = new System.Drawing.Size(64, 56);
			this.img.SizeMode = PictureBoxSizeMode.Zoom;
			this.img.TabIndex = 0;
			this.img.TabStop = false;
			this.img.SizeChanged += new EventHandler(this.img_SizeChanged);
			this.lbl.Cursor = Cursors.Hand;
			this.lbl.Dock = DockStyle.Bottom;
			this.lbl.Font = new System.Drawing.Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lbl.ForeColor = Color.White;
			this.lbl.Location = new Point(0, 88);
			this.lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(128, 41);
			this.lbl.TabIndex = 1;
			this.lbl.Text = "Tile 1";
			this.lbl.TextAlign = ContentAlignment.TopCenter;
			this.lbl.Click += new EventHandler(this.lbl_Click);
			this.lbl.MouseEnter += new EventHandler(this.lbl_MouseEnter);
			this.lbl.MouseLeave += new EventHandler(this.lbl_MouseLeave);
			base.AutoScaleDimensions = new SizeF(12f, 24f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Color.SeaGreen;
			base.Controls.Add(this.lbl);
			base.Controls.Add(this.img);
			this.Cursor = Cursors.Hand;
			this.Font = new System.Drawing.Font("Century Gothic", 15.75f);
			this.ForeColor = Color.White;
			base.Margin = new System.Windows.Forms.Padding(6);
			base.Name = "BunifuTileButton";
			base.Size = new System.Drawing.Size(128, 129);
			base.Load += new EventHandler(this.BunifuTileButton_Load);
			base.FontChanged += new EventHandler(this.BunifuTileButton_FontChanged);
			base.ForeColorChanged += new EventHandler(this.BunifuTileButton_ForeColorChanged);
			base.MouseEnter += new EventHandler(this.BunifuTileButton_MouseEnter);
			base.MouseLeave += new EventHandler(this.BunifuTileButton_MouseLeave);
			base.Resize += new EventHandler(this.BunifuTileButton_Resize);
			((ISupportInitialize)this.img).EndInit();
			base.ResumeLayout(false);
		}

		private void lbl_Click(object sender, EventArgs e)
		{
			this.BackColor = this.color_0;
			base.OnClick(e);
		}

		private void lbl_MouseEnter(object sender, EventArgs e)
		{
			this.BackColor = this.color_1;
		}

		private void lbl_MouseLeave(object sender, EventArgs e)
		{
			this.BackColor = this.color_0;
		}

		private void method_0()
		{
			double num = 100;
			double width = (double)base.Width / num * (double)this.int_0;
			PictureBox pictureBox = this.img;
			double num1 = Math.Round(width, 0);
			pictureBox.Width = int.Parse(num1.ToString());
			this.img.Height = this.img.Width;
			this.img.Left = base.Width / 2 - this.img.Width / 2;
		}

		protected override void OnClick(EventArgs e)
		{
			this.BackColor = this.color_0;
			base.OnClick(e);
		}
	}
}