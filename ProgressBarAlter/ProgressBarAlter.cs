// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 10-30-2017
// ***********************************************************************
// <copyright file="ProgressBarAlter.cs" company="Zeroit Dev Technologies">
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
#region Imports

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitProgressBarAlter

    /// <summary>
    /// A class collection for rendering a progressbar.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ThemeControl154" />
    [Designer(typeof(ZeroitProgressBarAlterDesigner))]
    public class ZeroitProgressBarAlter : Zeroit.Framework.Progress.ThemeControl154
    {
        #region  Private Fields
        /// <summary>
        /// The color back
        /// </summary>
        private Color colorBack = Color.FromArgb(210, 210, 210);
        /// <summary>
        /// The color border
        /// </summary>
        private Color colorBorder = Color.FromArgb(150, 150, 150);
        /// <summary>
        /// The color text
        /// </summary>
        private Color colorText = Color.FromArgb(100, 100, 100);
        /// <summary>
        /// The color inside
        /// </summary>
        private Color colorInside = Color.FromArgb(200, 200, 200);
        /// <summary>
        /// The color ic
        /// </summary>
        private Color colorIC = Color.FromArgb(215, 215, 215);
        /// <summary>
        /// The color1
        /// </summary>
        private Color color1 = Color.FromArgb(220, 220, 220);
        /// <summary>
        /// The color2
        /// </summary>
        private Color color2 = Color.FromArgb(200, 200, 200);

        /// <summary>
        /// The color angle
        /// </summary>
        private float colorAngle = 90F;

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Max = 100;
        /// <summary>
        /// The minimum
        /// </summary>
        private int _Min = 0;
        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// The show value
        /// </summary>
        private bool _ShowValue = false;

        /// <summary>
        /// The bt
        /// </summary>
        Brush BT;
        /// <summary>
        /// The ib
        /// </summary>
        Pen IB, PB;
        /// <summary>
        /// The bg
        /// </summary>
        Color BG, IC;

        /// <summary>
        /// The orientation
        /// </summary>
        private Orientation _Orientation;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>The color of the background.</value>
        public Color ColorBack
        {
            get { return colorBack; }
            set
            {
                colorBack = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color ColorBorder
        {
            get { return colorBorder; }
            set
            {
                colorBorder = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color ColorText
        {
            get { return colorText; }
            set
            {
                colorText = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color inside.
        /// </summary>
        /// <value>The color inside.</value>
        public Color ColorInside
        {
            get { return colorInside; }
            set
            {
                colorInside = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the IC color.
        /// </summary>
        /// <value>The color IC color.</value>
        public Color ColorIC
        {
            get { return colorIC; }
            set
            {
                colorIC = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the main color.
        /// </summary>
        /// <value>The main color1.</value>
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the main color.
        /// </summary>
        /// <value>The main color2.</value>
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color angle.
        /// </summary>
        /// <value>The color angle.</value>
        public float ColorAngle
        {
            get { return colorAngle; }
            set
            {
                colorAngle = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value >= Minimum & value <= _Max)
                    _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get { return _Orientation; }
            set
            {
                _Orientation = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        public int Maximum
        {
            get { return _Max; }
            set
            {
                if (value > _Min)
                    _Max = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        public int Minimum
        {
            get { return _Min; }
            set
            {
                if (value < _Max)
                    _Min = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Increments the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        private void Increment(int amount)
        {
            Value += amount;
        }


        /// <summary>
        /// Gets or sets a value indicating whether the value of the progress bar will be shown in the middle of it.
        /// </summary>
        /// <value><c>true</c> if show value; otherwise, <c>false</c>.</value>
        [Description("Indicates if the value of the progress bar will be shown in the middle of it.")]
        public bool ShowValue
        {
            get { return _ShowValue; }
            set
            {
                _ShowValue = value;
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarAlter"/> class.
        /// </summary>
        public ZeroitProgressBarAlter()
        {
            Transparent = true;
            Value = 50;
            ShowValue = true;
            SetColor("Text", colorText);
            SetColor("Inside", colorInside);
            SetColor("Border", colorBorder);
            SetColor("BG", colorBack);
            SetColor("IC", colorIC);
            MinimumSize = new Size(40, 14);
            Size = new Size(175, 30);

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion

        }

        /// <summary>
        /// Colors the hook.
        /// </summary>
        protected override void ColorHook()
        {
            BT = GetBrush("Text");
            IB = GetPen("Inside");
            PB = GetPen("Border");
            BG = GetColor("BG");
            IC = GetColor("IC");
        }

        /// <summary>
        /// Paints the hook.
        /// </summary>
        protected override void PaintHook()
        {
            switch (_Orientation)
            {
                case System.Windows.Forms.Orientation.Horizontal:

                    int area = Convert.ToInt32((_Value * (Width - 6)) / _Max);
                    G.Clear(colorBack);
                    LinearGradientBrush LGB1 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), color1, color2, colorAngle);

                    if (_Value == _Max)
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(PB, 30);
                    }
                    else if (_Value == _Min)
                    { }
                    else
                    {
                        G.FillRectangle(LGB1, new Rectangle(3, 3, area, Height - 4));
                        G.DrawRectangle(PB, new Rectangle(3, 3, area - 1, Height - 7));
                    }
                    if (_ShowValue)
                    {
                        string val = _Value.ToString();
                        DrawText(BT, val, HorizontalAlignment.Center, 0, 0);
                    }

                    break;

                case System.Windows.Forms.Orientation.Vertical:

                    int area2 = Convert.ToInt32((_Value * (Height - 6)) / _Max);

                    G.Clear(BG);
                    LinearGradientBrush LGB2 = new LinearGradientBrush(new Rectangle(0, 0, Width - 1, Height - 1), color1, color2, 90F);

                    if (_Value == _Max)
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, Height - 4));
                        DrawBorders(PB, 3);
                    }
                    else if (_Value == _Min)
                    { }
                    else
                    {
                        G.FillRectangle(LGB2, new Rectangle(3, 3, Width - 4, area2));
                        G.DrawRectangle(PB, new Rectangle(3, 3, Width - 7, area2));
                    }
                    if (_ShowValue)
                    {
                        string val = _Value.ToString();
                        DrawText(BT, val, HorizontalAlignment.Center, 0, 0);
                    }


                    break;
            }

            DrawBorders(IB);
            DrawBorders(PB, 1);
        }
        
        #region Include in Private Field


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        #endregion

        #region Include in Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate the progress.
        /// </summary>
        /// <value><c>true</c> if automatica animate; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get { return autoAnimate; }
            set
            {
                autoAnimate = value;

                if (value == true)
                {
                    timer.Enabled = true;
                }

                else
                {
                    timer.Enabled = false;
                }

                Invalidate();
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Value + 1 > this.Maximum)
            {
                this.Value = 0;
            }

            else
            {
                this.Value++;
                Invalidate();
            }
        }

        #endregion




    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarAlterDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarAlterDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        /// <summary>
        /// The action lists
        /// </summary>
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        /// <summary>
        /// Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        /// <value>The action lists.</value>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ZeroitProgressBarAlterSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarAlterSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarAlterSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarAlter colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarAlterSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarAlterSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarAlter;

            // Cache a reference to DesignerActionUIService, so the 
            // DesigneractionList can be refreshed. 
            this.designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
        }

        // Helper method to retrieve control properties. Use of GetProperties enables undo and menu updates to work properly.
        /// <summary>
        /// Gets the name of the property by.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        /// <returns>PropertyDescriptor.</returns>
        /// <exception cref="ArgumentException">Matching ColorLabel property not found!</exception>
        private PropertyDescriptor GetPropertyByName(String propName)
        {
            PropertyDescriptor prop;
            prop = TypeDescriptor.GetProperties(colUserControl)[propName];
            if (null == prop)
                throw new ArgumentException("Matching ColorLabel property not found!", propName);
            else
                return prop;
        }

        #region Properties that are targets of DesignerActionPropertyItem entries.


        /// <summary>
        /// Gets or sets the color back.
        /// </summary>
        /// <value>The color back.</value>
        public Color ColorBack
        {
            get
            {
                return colUserControl.ColorBack;
            }
            set
            {
                GetPropertyByName("ColorBack").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color border.
        /// </summary>
        /// <value>The color border.</value>
        public Color ColorBorder
        {
            get
            {
                return colUserControl.ColorBorder;
            }
            set
            {
                GetPropertyByName("ColorBorder").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color text.
        /// </summary>
        /// <value>The color text.</value>
        public Color ColorText
        {
            get
            {
                return colUserControl.ColorText;
            }
            set
            {
                GetPropertyByName("ColorText").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color inside.
        /// </summary>
        /// <value>The color inside.</value>
        public Color ColorInside
        {
            get
            {
                return colUserControl.ColorInside;
            }
            set
            {
                GetPropertyByName("ColorInside").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color ic.
        /// </summary>
        /// <value>The color ic.</value>
        public Color ColorIC
        {
            get
            {
                return colUserControl.ColorIC;
            }
            set
            {
                GetPropertyByName("ColorIC").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color1.
        /// </summary>
        /// <value>The color1.</value>
        public Color Color1
        {
            get
            {
                return colUserControl.Color1;
            }
            set
            {
                GetPropertyByName("Color1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color2.
        /// </summary>
        /// <value>The color2.</value>
        public Color Color2
        {
            get
            {
                return colUserControl.Color2;
            }
            set
            {
                GetPropertyByName("Color2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color angle.
        /// </summary>
        /// <value>The color angle.</value>
        public float ColorAngle
        {
            get
            {
                return colUserControl.ColorAngle;
            }
            set
            {
                GetPropertyByName("ColorAngle").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return colUserControl.Value;
            }
            set
            {
                GetPropertyByName("Value").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public Orientation Orientation
        {
            get
            {
                return colUserControl.Orientation;
            }
            set
            {
                GetPropertyByName("Orientation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public int Maximum
        {
            get
            {
                return colUserControl.Maximum;
            }
            set
            {
                GetPropertyByName("Maximum").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>The minimum.</value>
        public int Minimum
        {
            get
            {
                return colUserControl.Minimum;
            }
            set
            {
                GetPropertyByName("Minimum").SetValue(colUserControl, value);
            }
        }

        #endregion

        #region DesignerActionItemCollection

        /// <summary>
        /// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> objects contained in the list.
        /// </summary>
        /// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem" /> array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection items = new DesignerActionItemCollection();

            //Define static section header entries.
            items.Add(new DesignerActionHeaderItem("Appearance"));

            items.Add(new DesignerActionPropertyItem("ColorBack",
                                 "Color Back", "Appearance",
                                 "Sets the Back Color of the control."));

            items.Add(new DesignerActionPropertyItem("ColorBorder",
                                 "Color Border", "Appearance",
                                 "Sets the Border Color of the control."));

            items.Add(new DesignerActionPropertyItem("ColorText",
                                 "Color Text", "Appearance",
                                 "Sets the Text color."));

            items.Add(new DesignerActionPropertyItem("ColorInside",
                                 "Color Inside", "Appearance",
                                 "Sets the Inside color."));

            items.Add(new DesignerActionPropertyItem("ColorIC",
                                 "Color IC", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("Color1",
                                 "Color 1", "Appearance",
                                 "Sets the gradient brush color."));

            items.Add(new DesignerActionPropertyItem("Color2",
                                 "Color 2", "Appearance",
                                 "Sets the gradient brush color."));

            items.Add(new DesignerActionPropertyItem("ColorAngle",
                                 "Color Angle", "Appearance",
                                 "Sets the angle of the Color."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the progress value."));

            items.Add(new DesignerActionPropertyItem("Orientation",
                                 "Orientation", "Appearance",
                                 "Sets the orientation of the progress control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the progress control."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value of the progress control."));

            //Create entries for static Information section.
            StringBuilder location = new StringBuilder("Product: ");
            location.Append(colUserControl.ProductName);
            StringBuilder size = new StringBuilder("Version: ");
            size.Append(colUserControl.ProductVersion);
            items.Add(new DesignerActionTextItem(location.ToString(),
                             "Information"));
            items.Add(new DesignerActionTextItem(size.ToString(),
                             "Information"));

            return items;
        }

        #endregion




    }

    #endregion

    #endregion

    #endregion
}
