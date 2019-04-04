// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="ProgressStatusStrip.cs" company="Zeroit Dev Technologies">
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
    #region Progress Status Strip

    //[Designer(typeof(ZeroitProgressStatusStripDesigner))]    
    /// <summary>
    /// A class collection for rendering status strip control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.StatusStrip" />
    public class ZeroitProgressStatusStrip : StatusStrip
    {
        #region ProgressStatusStrip Definitions
        /// <summary>
        /// The bar color
        /// </summary>
        private Color _barColor = Color.ForestGreen;
        /// <summary>
        /// The bar shade
        /// </summary>
        private Color _barShade = Color.LightGreen;

        /// <summary>
        /// The progress minimum
        /// </summary>
        private float _progressMin = 0.0F;
        /// <summary>
        /// The progress maximum
        /// </summary>
        private float _progressMax = 100.0F;
        /// <summary>
        /// The progress value
        /// </summary>
        private float _progressVal = 0.0F;


        /// <summary>
        /// The automatic animate
        /// </summary>
        private bool autoAnimate = true;
        /// <summary>
        /// The timer
        /// </summary>
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        #endregion

        #region ProgressStatusStrip Properties

        /// <summary>
        /// Gets or sets a value indicating whether automatically animate.
        /// </summary>
        /// <value><c>true</c> if automatic animate; otherwise, <c>false</c>.</value>
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

        /// <summary>
        /// Gets or sets the color of the progress.
        /// </summary>
        /// <value>The color of the progress.</value>
        [Description("The color of the Progress Bar"), Category("Progress Bar"), DefaultValue(typeof(Color), "Color.ForestGreen")]
        public Color ProgressColor
        {
            get { return _barColor; }
            set { _barColor = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the progress shade color.
        /// </summary>
        /// <value>The progress shade color.</value>
        [Description("The shade color of the Progress Bar"), Category("Progress Bar"), DefaultValue(typeof(Color), "Color.LightGreen")]
        public Color ProgressShade
        {
            get { return _barShade; }
            set { _barShade = value; this.Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the lower bound of the range the Progress Bar is working with.
        /// </summary>
        /// <value>The minimum value.</value>
        [Description("The lower bound of the range the Progress Bar is working with"), Category("Progress Bar"), DefaultValue(0.0F)]
        public float Minimum
        {
            get { return _progressMin; }
            set
            {
                _progressMin = value;
                if (_progressMin > _progressMax) _progressMax = _progressMin;
                if (_progressMin > _progressVal) _progressVal = _progressMin;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the upper bound of the range the Progress Bar is working with.
        /// </summary>
        /// <value>The maximum.</value>
        [Description("The upper bound of the range the Progress Bar is working with"), Category("Progress Bar"), DefaultValue(100.0F)]
        public float Maximum
        {
            get { return _progressMax; }
            set
            {
                _progressMax = value;
                if (_progressMax < _progressMin) _progressMin = _progressMax;
                if (_progressMax < _progressVal) _progressVal = _progressMax;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current value for the Progress Bar, in the range specified by the minimum and maximum properties.
        /// </summary>
        /// <value>The value.</value>
        [Description("The current value for the Progress Bar, in the range specified by the minimum and maximum properties"), Category("Progress Bar"), DefaultValue(0.0F)]
        public float Value
        {
            get { return _progressVal; }
            set
            {
                _progressVal = value;
                if (_progressVal < _progressMin) _progressVal = _progressMin;
                if (_progressVal > _progressMax) _progressVal = _progressMax;
                this.Invalidate();
            }
        }

        #endregion

        #region ProgressStatusStrip Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressStatusStrip" /> class.
        /// </summary>
        public ZeroitProgressStatusStrip()
        {

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
        }

        /// <summary>
        /// Handles the Tick event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Value + 1 > this.Maximum)
                this.Value = 0;
            else
                this.Value++;

        }

        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="pe">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            float progPercent = (float)(_progressVal / (_progressMax - _progressMin));
            if (progPercent > 0)
            {
                RectangleF progRectangle = pe.Graphics.VisibleClipBounds;
                progRectangle.Width *= progPercent;
                LinearGradientBrush progBrush = new LinearGradientBrush(progRectangle, _barColor, _barShade, LinearGradientMode.Horizontal);
                pe.Graphics.FillRectangle(progBrush, progRectangle);
                progBrush.Dispose();
            }

            base.OnPaint(pe);
        }

        #endregion

    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressStatusStripDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressStatusStripDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressStatusStripSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressStatusStripSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressStatusStripSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressStatusStrip colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressStatusStripSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressStatusStripSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressStatusStrip;

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
        /// Gets or sets the color of the back.
        /// </summary>
        /// <value>The color of the back.</value>
        public Color BackColor
        {
            get
            {
                return colUserControl.BackColor;
            }
            set
            {
                GetPropertyByName("BackColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the fore.
        /// </summary>
        /// <value>The color of the fore.</value>
        public Color ForeColor
        {
            get
            {
                return colUserControl.ForeColor;
            }
            set
            {
                GetPropertyByName("ForeColor").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));
            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));
            //items.Add(new DesignerActionPropertyItem("Color1_inactive",
            //                     "Color1 inactive", "Appearance",
            //                     "Type few characters to filter Cities."));

            //items.Add(new DesignerActionPropertyItem("Color2_inactive",
            //                     "Color2 inactive", "Appearance",
            //                     "Type few characters to filter Cities."));

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
