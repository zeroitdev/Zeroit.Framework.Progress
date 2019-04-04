using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	public class BunifuGradientPanel : Panel
	{
		private Color color_0 = Color.White;

		private Color color_1 = Color.White;

		private Color color_2 = Color.White;

		private Color color_3 = Color.White;

		private int int_0 = 10;

		private IContainer icontainer_0;

		public Color GradientBottomLeft
		{
			get
			{
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.method_0();
			}
		}

		public Color GradientBottomRight
		{
			get
			{
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.method_0();
			}
		}

		public Color GradientTopLeft
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.method_0();
			}
		}

		public Color GradientTopRight
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.method_0();
			}
		}

		public int Quality
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

		public BunifuGradientPanel()
		{
			this.method_1();
			this.method_0();
		}

		private void BunifuGradientPanel_Resize(object sender, EventArgs e)
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

		private void method_0()
		{
			Bitmap bitmap = new Bitmap(this.Quality, this.Quality);
			if (this.Quality == 100)
			{
				bitmap = new Bitmap(base.Width, base.Height);
			}
			for (int i = 0; i < bitmap.Width; i++)
			{
				double num = Math.Round((double)i / (double)bitmap.Width * 100, 0);
				Color colorScale = BunifuColorTransition.getColorScale(int.Parse(num.ToString()), this.GradientTopLeft, this.GradientTopRight);
				for (int j = 0; j < bitmap.Height; j++)
				{
					num = Math.Round((double)j / (double)bitmap.Height * 100, 0);
					Color color = BunifuColorTransition.getColorScale(int.Parse(num.ToString()), this.GradientBottomLeft, this.GradientBottomRight);
					bitmap.SetPixel(i, j, Graphics.AddColor(colorScale, color));
				}
			}
			if (this.BackgroundImageLayout != ImageLayout.Stretch)
			{
				this.BackgroundImageLayout = ImageLayout.Stretch;
			}
			this.BackgroundImage = bitmap;
		}

		private void method_1()
		{
			base.SuspendLayout();
			base.Resize += new EventHandler(this.BunifuGradientPanel_Resize);
			base.ResumeLayout(false);
		}
	}
}