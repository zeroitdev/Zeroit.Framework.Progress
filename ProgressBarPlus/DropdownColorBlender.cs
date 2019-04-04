// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="DropdownColorBlender.cs" company="Zeroit Dev Technologies">
//    This program is for creating Progress controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace Zeroit.Framework.Progress
{
    /// <summary>
    /// Class DropdownColorBlender.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxItem(false), ToolboxItemFilter("Prevent", ToolboxItemFilterType.Prevent)]
	public partial class DropdownColorBlender : UserControl
	{
        /// <summary>
        /// The editor service
        /// </summary>
        private IWindowsFormsEditorService _editorService = null;

        /// <summary>
        /// The start pointer
        /// </summary>
        private cblPointer StartPointer = new cblPointer(0F, Color.White, false);
        /// <summary>
        /// The end pointer
        /// </summary>
        private cblPointer EndPointer = new cblPointer(1F, Color.White, false);
        /// <summary>
        /// The middle pointers
        /// </summary>
        private Microsoft.VisualBasic.Collection MiddlePointers = new Microsoft.VisualBasic.Collection();
        /// <summary>
        /// The mouse moving
        /// </summary>
        private bool MouseMoving = false;
        /// <summary>
        /// The curr pointer
        /// </summary>
        private int CurrPointer;
        /// <summary>
        /// The top margin
        /// </summary>
        private int TopMargin = 8;
        //List of Known Colors - Done this way because I haven't found a good
        //way to get the Known Colors in color shade order yet
        /// <summary>
        /// The known color
        /// </summary>
        private string[] Known_Color = "Transparent,Black,DimGray,Gray,DarkGray,Silver,LightGray,Gainsboro,WhiteSmoke,White,RosyBrown,IndianRed,Brown,Firebrick,LightCoral,Maroon,DarkRed,Red,Snow,MistyRose,Salmon,Tomato,DarkSalmon,Coral,OrangeRed,LightSalmon,Sienna,SeaShell,Chocalate,SaddleBrown,SandyBrown,PeachPuff,Peru,Linen,Bisque,DarkOrange,BurlyWood,Tan,AntiqueWhite,NavajoWhite,BlanchedAlmond,PapayaWhip,Mocassin,Orange,Wheat,OldLace,FloralWhite,DarkGoldenrod,Cornsilk,Gold,Khaki,LemonChiffon,PaleGoldenrod,DarkKhaki,Beige,LightGoldenrod,Olive,Yellow,LightYellow,Ivory,OliveDrab,YellowGreen,DarkOliveGreen,GreenYellow,Chartreuse,LawnGreen,DarkSeaGreen,ForestGreen,LimeGreen,PaleGreen,DarkGreen,Green,Lime,Honeydew,SeaGreen,MediumSeaGreen,SpringGreen,MintCream,MediumSpringGreen,MediumAquaMarine,YellowAquaMarine,Turquoise,LightSeaGreen,MediumTurquoise,DarkSlateGray,PaleTurquoise,Teal,DarkCyan,Aqua,Cyan,LightCyan,Azure,DarkTurquoise,CadetBlue,PowderBlue,LightBlue,DeepSkyBlue,SkyBlue,LightSkyBlue,SteelBlue,AliceBlue,DodgerBlue,SlateGray,LightSlateGray,LightSteelBlue,CornflowerBlue,RoyalBlue,MidnightBlue,Lavender,Navy,DarkBlue,MediumBlue,Blue,GhostWhite,SlateBlue,DarkSlateBlue,MediumSlateBlue,MediumPurple,BlueViolet,Indigo,DarkOrchid,DarkViolet,MediumOrchid,Thistle,Plum,Violet,Purple,DarkMagenta,Magenta,Fuchsia,Orchid,MediumVioletRed,DeepPink,HotPink,LavenderBlush,PaleVioletRed,Crimson,Pink,LightPink".Split(',');

        /// <summary>
        /// Initializes a new instance of the <see cref="DropdownColorBlender"/> class.
        /// </summary>
        /// <param name="editorService">The editor service.</param>
        public DropdownColorBlender(IWindowsFormsEditorService editorService)
		{
			InitializeComponent();
			_editorService = editorService;
		}

        /// <summary>
        /// Handles the Load event of the ColorBlender control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ColorBlender_Load(object sender, System.EventArgs e)
		{
			ColorBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			ColorBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ColorBox.DrawItem += this.ColorList_DrawItem;
			ColorBox.Items.AddRange(Known_Color);
			ColorBox.SelectedIndex = 1;
		}

        #region Properties

        /// <summary>
        /// The blend colors
        /// </summary>
        private Color[] _BlendColors = new Color[] {Color.White, Color.Black};
        /// <summary>
        /// Gets or sets the blend colors.
        /// </summary>
        /// <value>The blend colors.</value>
        [Category("ColorBlender"), Description("Array of Colors used in ColorBlend")]
		public Color[] BlendColors
		{
			get
			{
				return _BlendColors;
			}
			set
			{
				_BlendColors = value;
				//Me.Invalidate()
			}
		}

        /// <summary>
        /// The blend positions
        /// </summary>
        private float[] _BlendPositions = new float[] {0F, 1F};
        /// <summary>
        /// Gets or sets the blend positions.
        /// </summary>
        /// <value>The blend positions.</value>
        [Category("ColorBlender"), Description("Array of Color Positions used in ColorBlend")]
		public float[] BlendPositions
		{
			get
			{
				return _BlendPositions;
			}
			set
			{
				_BlendPositions = value;
				//Me.Invalidate()
			}
		}

        /// <summary>
        /// The focal points
        /// </summary>
        private cFocalPoints _FocalPoints = new cFocalPoints(0.5F, 0.5F, 0F, 0F);

        /// <summary>
        /// Gets or sets the focal points.
        /// </summary>
        /// <value>The focal points.</value>
        [Description("The CenterPoint and FocusScales for the ColorBlend"), Category("Appearance ProgBar")]
		public cFocalPoints FocalPoints
		{
			get
			{
				return _FocalPoints;
			}
			set
			{
				_FocalPoints = value;
				this.Invalidate();
			}
		}

        /// <summary>
        /// The bar height
        /// </summary>
        private float _BarHeight = 20F;
        /// <summary>
        /// Gets or sets the height of the bar.
        /// </summary>
        /// <value>The height of the bar.</value>
        [Category("ColorBlender"), Description("Height of color blender bar")]
		public float BarHeight
		{
			get
			{
				return _BarHeight;
			}
			set
			{
				_BarHeight = value;
				panProps.Location = new Point(10, Convert.ToInt32(value + 20));
				this.Invalidate();
			}
		}

        /// <summary>
        /// Enum eBlendGradientType
        /// </summary>
        public enum eBlendGradientType
		{
            /// <summary>
            /// The linear
            /// </summary>
            Linear,
            /// <summary>
            /// The path
            /// </summary>
            Path
        }
        /// <summary>
        /// The blend gradient type
        /// </summary>
        private eBlendGradientType _BlendGradientType = eBlendGradientType.Linear;
        /// <summary>
        /// Gets or sets the type of the blend gradient.
        /// </summary>
        /// <value>The type of the blend gradient.</value>
        [Category("ColorBlender"), Description("Type of brush used to paint color blend")]
		public eBlendGradientType BlendGradientType
		{
			get
			{
				return _BlendGradientType;
			}
			set
			{
				_BlendGradientType = value;
				this.Invalidate();
			}
		}

        /// <summary>
        /// Enum eBlendPathShape
        /// </summary>
        public enum eBlendPathShape
		{
            /// <summary>
            /// The rectangle
            /// </summary>
            Rectangle,
            /// <summary>
            /// The ellipse
            /// </summary>
            Ellipse,
            /// <summary>
            /// The triangle
            /// </summary>
            Triangle
        }
        /// <summary>
        /// The blend path shape
        /// </summary>
        private eBlendPathShape _BlendPathShape = eBlendPathShape.Rectangle;
        /// <summary>
        /// Gets or sets the blend path shape.
        /// </summary>
        /// <value>The blend path shape.</value>
        [Category("ColorBlender"), Description("Shape of path for the color blend")]
		public eBlendPathShape BlendPathShape
		{
			get
			{
				return _BlendPathShape;
			}
			set
			{
				_BlendPathShape = value;
				this.Invalidate();
			}
		}

        /// <summary>
        /// The blend path center point
        /// </summary>
        private PointF _BlendPathCenterPoint = new PointF();
        /// <summary>
        /// Gets or sets the blend path center point.
        /// </summary>
        /// <value>The blend path center point.</value>
        [Category("ColorBlender"), Description("Position of the center of the path ColorBlend")]
		public PointF BlendPathCenterPoint
		{
			get
			{
				return _BlendPathCenterPoint;
			}
			set
			{
				_BlendPathCenterPoint = value;
				this.Invalidate();
			}
		}

        /// <summary>
        /// The blend gradient mode
        /// </summary>
        private LinearGradientMode _BlendGradientMode = LinearGradientMode.Vertical;
        /// <summary>
        /// Gets or sets the blend gradient mode.
        /// </summary>
        /// <value>The blend gradient mode.</value>
        [Category("ColorBlender"), Description("Type of linear gradient color blend")]
		public LinearGradientMode BlendGradientMode
		{
			get
			{
				return _BlendGradientMode;
			}
			set
			{
				_BlendGradientMode = value;
				this.Invalidate();
			}
		}

        #endregion //Properties

        #region Mouse Events

        /// <summary>
        /// Handles the MouseDown event of the ColorBlender control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ColorBlender_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			if (e.Y > TopMargin + BarHeight - 10 && e.Y < TopMargin + BarHeight + 20 && e.X > 5 && e.X < this.Width - 5)
			{
				//Check if the cursor is over a MiddlePointer
				int mOver = IsMouseOverPointer(e.X, e.Y);
				if (mOver > -1)
				{
					if (!(CurrPointer == mOver))
					{
						CurrPointer = mOver;
						ClearCurrPointer();
						((cblPointer)(cblPointer)MiddlePointers[CurrPointer]).pIsCurr = true;
						UpdateRGBnuds(((cblPointer)(cblPointer)MiddlePointers[CurrPointer]).pColor);
						lblPos.Text = ((cblPointer)MiddlePointers[CurrPointer]).PosToStrong;
					}

					if (e.Button == System.Windows.Forms.MouseButtons.Left)
					{
						MouseMoving = true;
					}
					else if (e.Button == System.Windows.Forms.MouseButtons.Right)
					{
						MiddlePointers.Remove(CurrPointer);
						lblPos.Text = "";
					}
				}
				else
				{
					//Check if the cursor is over a Start or End Pointer
					if (IsMouseOverStartPointer(e.X, e.Y))
					{
						ClearCurrPointer();
						CurrPointer = -1;
						StartPointer.pIsCurr = true;
						UpdateRGBnuds(StartPointer.pColor);
						lblPos.Text = StartPointer.PosToStrong;
					}
					else if (IsMouseOverEndPointer(e.X, e.Y))
					{
						ClearCurrPointer();
						CurrPointer = -1;
						EndPointer.pIsCurr = true;
						UpdateRGBnuds(EndPointer.pColor);
						lblPos.Text = EndPointer.PosToStrong;
					}
					else
					{
						//If the cursor is not over a cblPointer then Add One
						if (e.Button == System.Windows.Forms.MouseButtons.Left)
						{
							ClearCurrPointer();
							MiddlePointers.Add(new cblPointer(Convert.ToSingle(((e.X - 10) / (double)(this.Width - 20))), Color.FromArgb(tbarAlpha.Value, Convert.ToInt32(nudRed.Value), Convert.ToInt32(nudGreen.Value), Convert.ToInt32(nudBlue.Value)), true), null, null, null);
							SortCollection(MiddlePointers, "pPos", true);
							CurrPointer = FindCurr();
							lblPos.Text = ((cblPointer)MiddlePointers[CurrPointer]).PosToStrong;
							this.Invalidate();
							MouseMoving = true;
						}
					}
				}
			}
		}

        /// <summary>
        /// Handles the MouseMove event of the ColorBlender control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ColorBlender_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (MouseMoving)
				{
					if (e.X >= 11 && e.X <= (this.Width - 11))
					{
						((cblPointer)MiddlePointers[CurrPointer]).pPos = Convert.ToSingle(((e.X - 10) / (double)(this.Width - 20)));
						SortCollection(MiddlePointers, "pPos", true);
						CurrPointer = FindCurr();
						lblPos.Text = ((cblPointer)MiddlePointers[CurrPointer]).PosToStrong;
						lblPos.Refresh();
						this.Invalidate();
					}
				}
			}
		}

        /// <summary>
        /// Handles the MouseUp event of the ColorBlender control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void ColorBlender_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			MouseMoving = false;
			SortCollection(MiddlePointers, "pPos", true);
			CurrPointer = FindCurr();
			this.Invalidate();
		}

        /// <summary>
        /// Determines whether [is mouse over start pointer] [the specified x].
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <returns><c>true</c> if [is mouse over start pointer] [the specified x]; otherwise, <c>false</c>.</returns>
        private bool IsMouseOverStartPointer(int X, int Y)
		{
			//Convert to Region.
			using (Region PointerRegion = new Region(BuildPointer(GetpX(0F))))
			{
				//Is the point inside the region.
				return PointerRegion.IsVisible(X, Y);
			}
		}

        /// <summary>
        /// Determines whether [is mouse over end pointer] [the specified x].
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <returns><c>true</c> if [is mouse over end pointer] [the specified x]; otherwise, <c>false</c>.</returns>
        private bool IsMouseOverEndPointer(int X, int Y)
		{
			//Convert to Region.
			using (Region PointerRegion = new Region(BuildPointer(GetpX(1F))))
			{
				//Is the point inside the region.
				return PointerRegion.IsVisible(X, Y);
			}
		}

        /// <summary>
        /// Determines whether [is mouse over pointer] [the specified x].
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <returns>System.Int32.</returns>
        private int IsMouseOverPointer(int X, int Y)
		{
			if (MiddlePointers != null)
			{

				for (int I = 1; I <= MiddlePointers.Count; I++)
				{
					//Convert to Region.
					using (Region PointerRegion = new Region(BuildPointer(GetpX(((cblPointer)MiddlePointers[I]).pPos))))
					{
						//Is the point inside the region.
						if (PointerRegion.IsVisible(X, Y))
						{
							return I;
						}
					}
				}
				return -1;
			}
//INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
			return 0;
		}

        /// <summary>
        /// Clears the curr pointer.
        /// </summary>
        private void ClearCurrPointer()
		{
			foreach (cblPointer ptr in MiddlePointers)
			{
				ptr.pIsCurr = false;
			}
			StartPointer.pIsCurr = false;
			EndPointer.pIsCurr = false;
		}

        /// <summary>
        /// Finds the curr.
        /// </summary>
        /// <returns>System.Int32.</returns>
        private int FindCurr()
		{
			for (int i = 1; i <= MiddlePointers.Count; i++)
			{
				if (((cblPointer)MiddlePointers[i]).pIsCurr)
				{
					return i;
				}
			}
			return -1;
		}
        #endregion //Mouse Events

        #region Drawing

        /// <summary>
        /// Draws the pointer.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="bColor">Color of the b.</param>
        /// <param name="pt">The pt.</param>
        /// <param name="IsCurr">if set to <c>true</c> [is curr].</param>
        private void DrawPointer(ref Graphics g, Color bColor, float pt, bool IsCurr)
		{
			using (Brush cpbr = new SolidBrush(bColor))
			{
				using (Pen pn = new Pen(Color.LightGray, 2F))
				{
					float pX = GetpX(pt);
					g.FillPath(cpbr, BuildPointer(pX));
					g.DrawPath(pn, BuildPointer(pX));
					pn.Width = 1F;
					pn.Color = Color.Black;
					g.DrawPath(pn, BuildPointer(pX));
					if (IsCurr)
					{
						g.FillEllipse(Brushes.Red, pX + 10, TopMargin + BarHeight + 8, 10, 4);
					}
				}
			}
		}

        /// <summary>
        /// Getps the x.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns>System.Single.</returns>
        private float GetpX(float pos)
		{
			return ((this.Width - 20) * pos) - 5;
		}

        /// <summary>
        /// Builds the pointer.
        /// </summary>
        /// <param name="cPX">The c px.</param>
        /// <returns>GraphicsPath.</returns>
        private GraphicsPath BuildPointer(float cPX)
		{
			cPX += 10;
			GraphicsPath gp = new GraphicsPath();
			gp.AddLine(cPX + 5, TopMargin + BarHeight - 3, cPX + 10, TopMargin + BarHeight);
			gp.AddLine(cPX + 10, TopMargin + BarHeight, cPX + 10, TopMargin + BarHeight + 7);
			gp.AddLine(cPX + 10, TopMargin + BarHeight + 7, cPX, TopMargin + BarHeight + 7);
			gp.AddLine(cPX, TopMargin + BarHeight + 7, cPX, TopMargin + BarHeight);
			gp.CloseFigure();
			return gp;
		}

        /// <summary>
        /// Linears the brush.
        /// </summary>
        /// <param name="BaseRect">The base rect.</param>
        /// <param name="Mode">The mode.</param>
        /// <returns>LinearGradientBrush.</returns>
        public LinearGradientBrush LinearBrush(Rectangle BaseRect, LinearGradientMode Mode)
		{
			LinearGradientBrush br = new LinearGradientBrush(new Rectangle(BaseRect.X - 1, BaseRect.Y - 1, BaseRect.Width + 2, BaseRect.Height + 2), Color.AliceBlue, Color.Blue, Mode);
			ColorBlend blend = new ColorBlend();
			blend.Colors = BlendColors;
			blend.Positions = BlendPositions;
			br.InterpolationColors = blend;
			return br;
		}

        /// <summary>
        /// Pathes the brush.
        /// </summary>
        /// <param name="BaseRect">The base rect.</param>
        /// <returns>PathGradientBrush.</returns>
        public PathGradientBrush PathBrush(Rectangle BaseRect)
		{
			GraphicsPath gp = GetShapePath(BaseRect);
			PathGradientBrush br = new PathGradientBrush(gp);
			ColorBlend blend = new ColorBlend();
			blend.Colors = BlendColors;
			blend.Positions = BlendPositions;
			//        br.CenterPoint = New PointF(40 + Me.Width - 92, CInt(40 + BarHeight + 25))
			br.FocusScales = this.FocalPoints.FocusScales;
			br.CenterPoint = new PointF((this.FocalPoints.CenterPoint.X * 80) + (this.Width - 92), (this.FocalPoints.CenterPoint.Y * 80) + (BarHeight + 25));
			br.InterpolationColors = blend;
			gp.Dispose();
			return br;
		}

        /// <summary>
        /// Gets the shape path.
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns>GraphicsPath.</returns>
        public GraphicsPath GetShapePath(Rectangle rect)
		{
			GraphicsPath gp = new GraphicsPath();
			switch (BlendPathShape)
			{

				case eBlendPathShape.Ellipse:
					gp.AddEllipse(rect);

					break;
				case eBlendPathShape.Triangle:
					Point[] pts = new Point[] {
						new Point(Convert.ToInt32(rect.X + (rect.Width / 2.0)), rect.Y),
						new Point(rect.X + rect.Width, rect.Y + rect.Height),
						new Point(rect.X, rect.Y + rect.Height)
					};
					gp.AddPolygon(pts);

					break;
				case eBlendPathShape.Rectangle:
					gp.AddRectangle(rect);

					break;
			}

			return gp;

		}

        /// <summary>
        /// Builds a blend.
        /// </summary>
        private void BuildABlend()
		{
			List<Color> lColors = new List<Color>();
			lColors.Add(StartPointer.pColor);
			if (MiddlePointers != null)
			{
				foreach (cblPointer ptr in MiddlePointers)
				{
					lColors.Add(ptr.pColor);
				}
			}
			lColors.Add(EndPointer.pColor);
			BlendColors = lColors.ToArray();
			lColors = null;

			List<float> lPos = new List<float>();
			lPos.Add(StartPointer.pPos);
			if (MiddlePointers != null)
			{
				foreach (cblPointer ptr in MiddlePointers)
				{
					lPos.Add(ptr.pPos);
				}
			}
			lPos.Add(EndPointer.pPos);
			BlendPositions = lPos.ToArray();
			lPos = null;

		}

        /// <summary>
        /// Loads a blend.
        /// </summary>
        /// <param name="cb">The cb.</param>
        public void LoadABlend(cBlendItems cb)
		{

			StartPointer.pColor = cb.iColor[0];
			StartPointer.pPos = cb.iPoint[0];
			EndPointer.pColor = cb.iColor[cb.iColor.Length - 1];
			EndPointer.pPos = cb.iPoint[cb.iColor.Length - 1];

			if (cb.iColor.Length > 2)
			{
				for (int i = 1; i <= cb.iColor.Length - 2; i++)
				{
					MiddlePointers.Add(new cblPointer(cb.iPoint[i], cb.iColor[i], false), null, null, null);
				}
			}
		}

        /// <summary>
        /// Updates the color of the pointer.
        /// </summary>
        private void UpdatePointerColor()
		{
			Color CurrColor = Color.FromArgb(tbarAlpha.Value, Convert.ToInt32(nudRed.Value), Convert.ToInt32(nudGreen.Value), Convert.ToInt32(nudBlue.Value));
			if (StartPointer.pIsCurr)
			{
				StartPointer.pColor = CurrColor;
			}
			else if (EndPointer.pIsCurr)
			{
				EndPointer.pColor = CurrColor;
			}
			else
			{
				int curr = FindCurr();
				if (curr > -1)
				{
					((cblPointer)MiddlePointers[curr]).pColor = CurrColor;
				}
			}
			panCurrColor.BackColor = CurrColor;

			txbCurrColor.Text = GetColorName(CurrColor);
			this.Invalidate();
		}

        /// <summary>
        /// Gets the name of the color.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns>System.String.</returns>
        public string GetColorName(Color c)
		{
			foreach (string ColorName in Known_Color)
			{
				if (!(Color.FromName(ColorName).IsSystemColor))
				{
					if (Convert.ToInt32(ColorTranslator.ToWin32(Color.FromName(ColorName))) == Convert.ToInt32(ColorTranslator.ToWin32(c)))
					{
						return ((c.Name == "ffffffff") ? "White- ffffffff" : ColorName + "- " + c.Name).ToString();
					}
				}
			}
			return ((c.Name == "ff7f007f") ? "Transparent- ff7f007f" : c.Name).ToString();

		}
        #endregion //Drawing

        #region Painting

        /// <summary>
        /// Paints the background of the control.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
		{
			//Do Nothing
		}

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			//Go through each cblPointer in the collection to get the current Color and Position arrays
			BuildABlend();

			//Create a canvas to aint on the same size as the control
			Bitmap bitmapBuffer = new Bitmap(this.Width, this.Height);
			Graphics g = Graphics.FromImage(bitmapBuffer);
			g.Clear(this.BackColor);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			// Paint the ColorBlender Bar with the Linear Brush
			Rectangle barRect = new Rectangle(10, TopMargin, this.ClientSize.Width - 20, Convert.ToInt32(BarHeight));
			Brush br = LinearBrush(barRect, LinearGradientMode.Horizontal);
			g.FillRectangle(br, barRect);

			// Paint the ColorBlender Sample with the chosen Brush
			Rectangle sampleRect = new Rectangle(this.Width - 92, Convert.ToInt32(BarHeight + 25), 80, 80);
			if (BlendGradientType == eBlendGradientType.Linear)
			{
				br = LinearBrush(sampleRect, BlendGradientMode);
			}
			else
			{
				br = PathBrush(sampleRect);
			}
			g.FillPath(br, GetShapePath(sampleRect));

			//Draw all the cblPointers in their Color at their Position along the Bar
			using (Pen pn = new Pen(Color.Gray, 1F))
			{
				pn.DashStyle = DashStyle.Dash;
				g.DrawLine(pn, 10, TopMargin + BarHeight + 7, this.ClientSize.Width - 15, TopMargin + BarHeight + 7);

				pn.Color = Color.Black;
				pn.DashStyle = DashStyle.Solid;

				DrawPointer(ref g, StartPointer.pColor, 0F, StartPointer.pIsCurr);
				DrawPointer(ref g, EndPointer.pColor, 1F, EndPointer.pIsCurr);

				if (MiddlePointers != null)
				{
					for (int I = 1; I <= MiddlePointers.Count; I++)
					{
						DrawPointer(ref g, ((cblPointer)MiddlePointers[I]).pColor, ((cblPointer)MiddlePointers[I]).pPos, I == CurrPointer);
					}
				}

			}

			//Draw the entire image to the control in one shot to eliminate flicker
			e.Graphics.DrawImage((Bitmap)bitmapBuffer.Clone(), 0, 0);

			bitmapBuffer.Dispose();
			br.Dispose();
			g.Dispose();



		}
        #endregion //Painting

        #region SortCollection

        /// <summary>
        /// Sorts the collection.
        /// </summary>
        /// <param name="col">The col.</param>
        /// <param name="psSortPropertyName">Name of the ps sort property.</param>
        /// <param name="pbAscending">if set to <c>true</c> [pb ascending].</param>
        /// <param name="psKeyPropertyName">Name of the ps key property.</param>
        private void SortCollection(Microsoft.VisualBasic.Collection col, string psSortPropertyName, bool pbAscending, string psKeyPropertyName = "")
		{

			object obj = null;
			int i = 0;
			int j = 0;
			int iMinMaxIndex = 0;
			object vMinMax = null;
			object vValue = null;
			bool bSortCondition = false;
			bool bUseKey = false;
			string sKey = null;

			bUseKey = (!string.IsNullOrEmpty(psKeyPropertyName));

//INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of col.Count for every iteration:
			int tempVar = col.Count;
			for (i = 1; i < tempVar; i++)
			{
				obj = col[i];
				vMinMax = Interaction.CallByName(obj, psSortPropertyName, Microsoft.VisualBasic.Constants.vbGet);
				iMinMaxIndex = i;

				for (j = i + 1; j <= col.Count; j++)
				{
					obj = col[j];
					vValue = Interaction.CallByName(obj, psSortPropertyName, Microsoft.VisualBasic.Constants.vbGet);

					if (pbAscending)
					{
						bSortCondition = (Convert.ToSingle(vValue) < Convert.ToSingle(vMinMax));
					}
					else
					{
						bSortCondition = (Convert.ToSingle(vValue) > Convert.ToSingle(vMinMax));
					}

					if (bSortCondition)
					{
						vMinMax = vValue;
						iMinMaxIndex = j;
					}

					obj = null;
				}

				if (iMinMaxIndex != i)
				{
					obj = col[iMinMaxIndex];

					col.Remove(iMinMaxIndex);
					if (bUseKey)
					{
						sKey = Convert.ToString(Interaction.CallByName(obj, psKeyPropertyName, Microsoft.VisualBasic.Constants.vbGet));
						col.Add(obj, sKey, i, null);
					}
					else
					{
						col.Add(obj,null,i,null);
					}

					obj = null;
				}

				obj = null;
			}

		}

        #endregion //SortCollection

        #region Controls

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ColorBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ColorBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateRGBnuds(Color.FromName(ColorBox.Text));
			this.Invalidate();
		}

        /// <summary>
        /// Handles the Click event of the Panel7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Panel7_Click(object sender, System.EventArgs e)
		{
			UpdateRGBnuds(((Panel)sender).BackColor);
			this.Invalidate();
		}

        /// <summary>
        /// The curr swatch
        /// </summary>
        private Panel CurrSwatch;
        /// <summary>
        /// Handles the MouseEnter event of the Panel10 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Panel10_MouseEnter(object sender, System.EventArgs e)
		{
			try
			{
				CurrSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			}
			catch (Exception ex)
			{
			}
			CurrSwatch = (Panel)sender;
			CurrSwatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		}

        /// <summary>
        /// Handles the MouseLeave event of the TabControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TabControl1_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				CurrSwatch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			}
			catch (Exception ex)
			{
			}

		}

        /// <summary>
        /// Updates the rg bnuds.
        /// </summary>
        /// <param name="c">The c.</param>
        private void UpdateRGBnuds(Color c)
		{
			tbarAlpha.Value = c.A;
			nudRed.Value = c.R;
			nudGreen.Value = c.G;
			nudBlue.Value = c.B;
			UpdatePointerColor();
		}

        /// <summary>
        /// Handles the ValueChanged event of the nud control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void nud_ValueChanged(object sender, System.EventArgs e)
		{
			txbAlpha.Text = Convert.ToString(tbarAlpha.Value);
			UpdatePointerColor();
		}

        /// <summary>
        /// Handles the TextChanged event of the txbAlpha control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txbAlpha_TextChanged(object sender, System.EventArgs e)
		{
			if (!string.IsNullOrEmpty(txbAlpha.Text))
			{
//INSTANT C# NOTE: The following VB 'Select Case' included either a non-ordinal switch expression or non-ordinal, range-type, or non-constant 'Case' expressions and was converted to C# 'if-else' logic:
//				Select Case CInt(txbAlpha.Text)
//ORIGINAL LINE: Case Is < 0
				if (Convert.ToInt32(txbAlpha.Text) < 0)
				{
						txbAlpha.Text = Convert.ToString(0);
				}
//ORIGINAL LINE: Case Is > 255
				else if (Convert.ToInt32(txbAlpha.Text) > 255)
				{
						txbAlpha.Text = Convert.ToString(255);
				}
				tbarAlpha.Value = Convert.ToInt32(txbAlpha.Text);
			}
		}

        /// <summary>
        /// Handles the Click event of the butApply control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void butApply_Click(object sender, System.EventArgs e)
		{
			_editorService.CloseDropDown();
		}

        /// <summary>
        /// Handles the Click event of the butClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void butClear_Click(object sender, System.EventArgs e)
		{
			StartPointer.pColor = Color.White;
			EndPointer.pColor = Color.White;
			MiddlePointers.Clear();
			this.Invalidate();
		}
        #endregion

        #region ColorBox

        /// <summary>
        /// Handles the DrawItem event of the ColorList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DrawItemEventArgs"/> instance containing the event data.</param>
        private void ColorList_DrawItem(object sender, DrawItemEventArgs e)
		{
			// If the item is the edit box item, then draw the rectangle white
			// If the item is the selected item, then draw the rectangle blue
			// Otherwise, draw the rectangle filled in beige
			if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit)
			{
				e.Graphics.FillRectangle(Brushes.White, e.Bounds);
			}
			else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
			}
			else
			{
				e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
			}

			// Cast the sender object  to ComboBox type.
			ComboBox TheBox = (ComboBox)sender;
			string itemString = Convert.ToString(TheBox.Items[e.Index]);
			Font MyFont = new Font("Tahoma", 10);
			SolidBrush myBrush = new SolidBrush(Color.FromName(itemString));

			//Draw a Color Swatch
			e.Graphics.FillRectangle(myBrush, e.Bounds.X + 3, e.Bounds.Y + 3, 20, e.Bounds.Height - 5);
			e.Graphics.DrawRectangle(Pens.Black, e.Bounds.X + 3, e.Bounds.Y + 3, 20, e.Bounds.Height - 5);

			// Draw the text in the item.
			e.Graphics.DrawString(itemString, MyFont, Brushes.Black, e.Bounds.X + 25, e.Bounds.Y + 1);

			// Draw the focus rectangle around the selected item.
			e.DrawFocusRectangle();
			myBrush.Dispose();
		}

#endregion //ColorBox

	}

    #region cblPointer Class

    /// <summary>
    /// Class cblPointer.
    /// </summary>
    internal class cblPointer
	{

        /// <summary>
        /// Initializes a new instance of the <see cref="cblPointer"/> class.
        /// </summary>
        /// <param name="pt">The pt.</param>
        /// <param name="c">The c.</param>
        /// <param name="IsCurr">if set to <c>true</c> [is curr].</param>
        public cblPointer(float pt, Color c, bool IsCurr)
		{
			pPos = pt;
			pColor = c;
			pIsCurr = IsCurr;
		}

        /// <summary>
        /// The p position
        /// </summary>
        private float _pPos;
        /// <summary>
        /// Gets or sets the p position.
        /// </summary>
        /// <value>The p position.</value>
        public float pPos
		{
			get
			{
				return _pPos;
			}
			set
			{
				_pPos = value;
			}
		}

        /// <summary>
        /// The p color
        /// </summary>
        private Color _pColor;
        /// <summary>
        /// Gets or sets the color of the p.
        /// </summary>
        /// <value>The color of the p.</value>
        public Color pColor
		{
			get
			{
				return _pColor;
			}
			set
			{
				_pColor = value;
			}
		}

        /// <summary>
        /// The p is curr
        /// </summary>
        private bool _pIsCurr;
        /// <summary>
        /// Gets or sets a value indicating whether [p is curr].
        /// </summary>
        /// <value><c>true</c> if [p is curr]; otherwise, <c>false</c>.</value>
        public bool pIsCurr
		{
			get
			{
				return _pIsCurr;
			}
			set
			{
				_pIsCurr = value;
			}
		}

        /// <summary>
        /// Gets the position to strong.
        /// </summary>
        /// <value>The position to strong.</value>
        public string PosToStrong
		{
			get
			{
				return System.Math.Round(_pPos * 100, 2).ToString();
			}
		}

	}

#endregion //cblPointer Class


}