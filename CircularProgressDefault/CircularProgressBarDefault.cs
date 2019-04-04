// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="CircularProgressBarDefault.cs" company="Zeroit Dev Technologies">
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

    #region Circular ProgressBar Default

    /// <summary>
    /// A class collection for rendering circular progressbar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitProgressBarCircularDefaultDesigner))]
    public class ZeroitProgressBarCircularDefault : Control
    {

        #region Enums        
        /// <summary>
        /// Enum representing a the type of progressbar.
        /// </summary>
        public enum ProgressBarShape
        {
            /// <summary>
            /// The round
            /// </summary>
            Round,
            /// <summary>
            /// The flat
            /// </summary>
            Flat
        }

        #endregion

        #region Variables

        /// <summary>
        /// The value
        /// </summary>
        private long _Value;
        /// <summary>
        /// The maximum
        /// </summary>
        private long _Maximum = 100;
        /// <summary>
        /// The progress color1
        /// </summary>
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        /// <summary>
        /// The progress color2
        /// </summary>
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        /// <summary>
        /// The progress shape value
        /// </summary>
        private ProgressBarShape ProgressShapeVal;

        #endregion

        #region Custom Properties        
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress color.
        /// </summary>
        /// <value>The progress color1.</value>
        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress color.
        /// </summary>
        /// <value>The progress color2.</value>
        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the progress shape.
        /// </summary>
        /// <value>The progress shape.</value>
        public ProgressBarShape ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        /// <summary>
        /// Handles the <see cref="E:PaintBackground" /> event.
        /// </summary>
        /// <param name="p">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarCircularDefault" /> class.
        /// </summary>
        public ZeroitProgressBarCircularDefault()
        {
            Size = new Size(130, 130);
            Font = new Font("Segoe UI", 15);
            MinimumSize = new Size(100, 100);
            DoubleBuffered = true;
        }

        /// <summary>
        /// Sets the size of the standard.
        /// </summary>
        private void SetStandardSize()
        {
            int _Size = System.Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        /// <summary>
        /// Increments the specified value.
        /// </summary>
        /// <param name="Val">The value.</param>
        public void Increment(int Val)
        {
            this._Value += Val;
            Invalidate();
        }

        /// <summary>
        /// Decrements the specified value.
        /// </summary>
        /// <param name="Val">The value.</param>
        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(this.BackColor);
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, 10f))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case ProgressBarShape.Round:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case ProgressBarShape.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }
                            graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)System.Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                        }
                    }
                    using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(0x34, 0x34, 0x34), Color.FromArgb(0x34, 0x34, 0x34), LinearGradientMode.Vertical))
                    {
                        graphics.FillEllipse(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1);
                    }
                    SizeF MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
                    graphics.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, Brushes.White, Convert.ToInt32(Width / 2 - MS.Width / 2), Convert.ToInt32(Height / 2 - MS.Height / 2));
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarCircularDefaultDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarCircularDefaultDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarCircularDefaultSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarCircularDefaultSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarCircularDefaultSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarCircularDefault colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarCircularDefaultSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarCircularDefaultSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarCircularDefault;

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
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
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
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>The maximum.</value>
        public long Maximum
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
        /// Gets or sets the progress color1.
        /// </summary>
        /// <value>The progress color1.</value>
        public Color ProgressColor1
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ProgressColor1").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress color2.
        /// </summary>
        /// <value>The progress color2.</value>
        public Color ProgressColor2
        {
            get
            {
                return colUserControl.ProgressColor2;
            }
            set
            {
                GetPropertyByName("ProgressColor2").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the progress shape.
        /// </summary>
        /// <value>The progress shape.</value>
        public Zeroit.Framework.Progress.ZeroitProgressBarCircularDefault.ProgressBarShape ProgressShape
        {
            get
            {
                return colUserControl.ProgressShape;
            }
            set
            {
                GetPropertyByName("ProgressShape").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the progress control."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value of the progress control."));

            items.Add(new DesignerActionPropertyItem("ProgressColor1",
                                 "Progress Color1", "Appearance",
                                 "Sets the progress control color."));

            items.Add(new DesignerActionPropertyItem("ProgressColor2",
                                 "Progress Color2", "Appearance",
                                 "Sets the progress control color."));

            items.Add(new DesignerActionPropertyItem("ProgressShape",
                                 "Progress Shape", "Appearance",
                                 "Sets the shape of the progress control."));

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
