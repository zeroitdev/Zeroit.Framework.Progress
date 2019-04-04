using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	public class BunifuGauge : UserControl
	{
		private Color color_0 = Color.Gray;

		private Color color_1 = Color.SeaGreen;

		private int int_0;

		private int int_1 = 30;

		private Color color_2 = Color.SeaGreen;

		private Color color_3 = Color.Tomato;

		private string string_0 = "";

		private IContainer icontainer_0;

		private Label lblpass;

		private Label lblmin;

		private Label lblmax;

		private BunifuColorTransition bunifuColorTransition_0;

		public Color ProgressBgColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.method_0(this.int_0);
			}
		}

		public Color ProgressColor1
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.bunifuColorTransition_0.Color1 = this.color_2;
				this.method_0(this.int_0);
			}
		}

		public Color ProgressColor2
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.bunifuColorTransition_0.Color2 = this.color_3;
				this.method_0(this.int_0);
			}
		}

		public string Suffix
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.lblpass.Text = string.Concat(this.Value, this.string_0);
			}
		}

		public int Thickness
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				this.method_0(this.int_0);
			}
		}

		public int Value
		{
			get
			{
				return this.int_0;
			}
			set
			{
				int num = 0;
				int num1 = 0;
				int num2;
				if (value > 100)
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
					this.int_0 = value;
					this.bunifuColorTransition_0.ProgessValue = this.int_0;
					this.method_0(this.int_0);
				}
			}
		}

		public BunifuGauge()
		{
			this.InitializeComponent();
			base.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
			this.BunifuGauge_Resize(this, new EventArgs());
			this.method_0(this.int_0);
		}

		private void bunifuColorTransition_0_OnValueChange(object sender, EventArgs e)
		{
			this.color_1 = this.bunifuColorTransition_0.Value;
		}

		private void BunifuGauge_FontChanged(object sender, EventArgs e)
		{
			this.lblpass.Font = this.Font;
			this.method_0(this.int_0);
		}

		private void BunifuGauge_ForeColorChanged(object sender, EventArgs e)
		{
			Label label = this.lblpass;
			Label label1 = this.lblmin;
			Label label2 = this.lblmax;
			Color foreColor = this.ForeColor;
			Color color = foreColor;
			label2.ForeColor = foreColor;
			Color color1 = color;
			Color color2 = color1;
			label1.ForeColor = color1;
			label.ForeColor = color2;
			this.method_0(this.int_0);
		}

		private void BunifuGauge_Load(object sender, EventArgs e)
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

		private void BunifuGauge_Resize(object sender, EventArgs e)
		{
			this.method_0(this.int_0);
			this.lblpass.Top = base.Height - this.lblpass.Height - 30;
			Label label = this.lblmin;
			int height = base.Height - this.lblmax.Height - 10;
			int num = height;
			this.lblmax.Top = height;
			label.Top = num;
			this.lblmin.Left = 20;
			Label width = this.lblmax;
			System.Drawing.Size size = base.Size;
			width.Left = size.Width - this.lblmax.Width - 20;
			this.lblpass.Left = base.Width / 2 - this.lblpass.Width / 2;
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
			this.lblpass = new Label();
			this.lblmin = new Label();
			this.lblmax = new Label();
			this.bunifuColorTransition_0 = new BunifuColorTransition(this.icontainer_0);
			base.SuspendLayout();
			this.lblpass.AutoSize = true;
			this.lblpass.Font = new System.Drawing.Font("Century Gothic", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblpass.Location = new Point(83, 34);
			this.lblpass.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblpass.Name = "lblpass";
			this.lblpass.Size = new System.Drawing.Size(22, 24);
			this.lblpass.TabIndex = 1;
			this.lblpass.Text = "0";
			this.lblmin.AutoSize = true;
			this.lblmin.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblmin.Location = new Point(26, 86);
			this.lblmin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblmin.Name = "lblmin";
			this.lblmin.Size = new System.Drawing.Size(15, 17);
			this.lblmin.TabIndex = 2;
			this.lblmin.Text = "0";
			this.lblmax.AutoSize = true;
			this.lblmax.Font = new System.Drawing.Font("Century Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.lblmax.Location = new Point(145, 86);
			this.lblmax.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblmax.Name = "lblmax";
			this.lblmax.Size = new System.Drawing.Size(29, 17);
			this.lblmax.TabIndex = 3;
			this.lblmax.Text = "100";
			this.bunifuColorTransition_0.Color1 = Color.SeaGreen;
			this.bunifuColorTransition_0.Color2 = Color.Tomato;
			this.bunifuColorTransition_0.ProgessValue = 0;
			this.bunifuColorTransition_0.OnValueChange += new EventHandler(this.bunifuColorTransition_0_OnValueChange);
			base.AutoScaleDimensions = new SizeF(12f, 24f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.lblmax);
			base.Controls.Add(this.lblmin);
			base.Controls.Add(this.lblpass);
			this.Font = new System.Drawing.Font("Century Gothic", 15.75f);
			base.Margin = new System.Windows.Forms.Padding(6);
			base.Name = "BunifuGauge";
			base.Size = new System.Drawing.Size(174, 117);
			base.Load += new EventHandler(this.BunifuGauge_Load);
			base.FontChanged += new EventHandler(this.BunifuGauge_FontChanged);
			base.ForeColorChanged += new EventHandler(this.BunifuGauge_ForeColorChanged);
			base.Resize += new EventHandler(this.BunifuGauge_Resize);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void method_0(int int_2)
		{
			int width = base.Size.Width;
			System.Drawing.Size size = base.Size;
			Bitmap bitmap = new Bitmap(width, size.Height);
			System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(bitmap);
			graphic.SmoothingMode = SmoothingMode.HighQuality;
			graphic.Clear(Color.Transparent);
			Pen pen = new Pen(this.color_0, (float)this.int_1);
			size = base.Size;
			int num = size.Width - this.int_1 * 2;
			int int1 = this.int_1;
			size = base.Size;
			Rectangle rectangle = new Rectangle(int1, size.Height / 4, num, num);
			Pen pen1 = new Pen(this.color_1, (float)this.int_1);
            System.Drawing.Graphics graphic1 = System.Drawing.Graphics.FromImage(bitmap);
			graphic1.SmoothingMode = SmoothingMode.HighQuality;
			graphic1.DrawArc(pen, rectangle, 180f, 180f);
			this.lblpass.Text = string.Concat(int_2, this.Suffix);
			graphic1.DrawArc(pen1, rectangle, 180f, (float)this.method_1(int_2));
			this.BackgroundImage = bitmap;
		}

		private int method_1(int int_2)
		{
			double num = Math.Round((double)int_2 * 180 / 100, 0);
			return int.Parse(num.ToString());
		}
	}
}