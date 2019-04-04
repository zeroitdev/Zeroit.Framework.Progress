// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="SpinnerCircle.cs" company="Zeroit Dev Technologies">
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
using System.Windows.Forms.Design;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Spinner Circle

    #region Loading Circle    
    /// <summary>
    /// A class collection for rendering a circular progress.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ZeroitProgressIndicatorSpinner), "spinner.bmp")]
    [Designer(typeof(ZeroitProgressIndicatorSpinnerDesigner))]
    public partial class ZeroitProgressIndicatorSpinner : Control
    {
        // Constants =========================================================
        /// <summary>
        /// The number of degrees in circle
        /// </summary>
        private static double NumberOfDegreesInCircle = 360;
        /// <summary>
        /// The number of degrees in half circle
        /// </summary>
        private double NumberOfDegreesInHalfCircle = NumberOfDegreesInCircle / 2;
        /// <summary>
        /// The default inner circle radius
        /// </summary>
        private int DefaultInnerCircleRadius = 8;
        /// <summary>
        /// The default outer circle radius
        /// </summary>
        private int DefaultOuterCircleRadius = 10;
        /// <summary>
        /// The default number of spoke
        /// </summary>
        private int DefaultNumberOfSpoke = 10;
        /// <summary>
        /// The default spoke thickness
        /// </summary>
        private int DefaultSpokeThickness = 4;
        /// <summary>
        /// The default color
        /// </summary>
        private Color DefaultColor = Color.DarkGray;

        /// <summary>
        /// The mac osx inner circle radius
        /// </summary>
        private int MacOSXInnerCircleRadius = 5;
        /// <summary>
        /// The mac osx outer circle radius
        /// </summary>
        private int MacOSXOuterCircleRadius = 11;
        /// <summary>
        /// The mac osx number of spoke
        /// </summary>
        private int MacOSXNumberOfSpoke = 12;
        /// <summary>
        /// The mac osx spoke thickness
        /// </summary>
        private int MacOSXSpokeThickness = 2;

        /// <summary>
        /// The fire fox inner circle radius
        /// </summary>
        private int FireFoxInnerCircleRadius = 6;
        /// <summary>
        /// The fire fox outer circle radius
        /// </summary>
        private int FireFoxOuterCircleRadius = 7;
        /// <summary>
        /// The fire fox number of spoke
        /// </summary>
        private int FireFoxNumberOfSpoke = 9;
        /// <summary>
        /// The fire fox spoke thickness
        /// </summary>
        private int FireFoxSpokeThickness = 4;

        /// <summary>
        /// The i e7 inner circle radius
        /// </summary>
        private int IE7InnerCircleRadius = 8;
        /// <summary>
        /// The i e7 outer circle radius
        /// </summary>
        private int IE7OuterCircleRadius = 9;
        /// <summary>
        /// The i e7 number of spoke
        /// </summary>
        private int IE7NumberOfSpoke = 24;
        /// <summary>
        /// The i e7 spoke thickness
        /// </summary>
        private int IE7SpokeThickness = 4;

        /// <summary>
        /// The zeroit inner circle radius
        /// </summary>
        private int ZeroitInnerCircleRadius = 98;
        /// <summary>
        /// The zeroit outer circle radius
        /// </summary>
        private int ZeroitOuterCircleRadius = 100;
        /// <summary>
        /// The zeroit number of spoke
        /// </summary>
        private int ZeroitNumberOfSpoke = 255;
        /// <summary>
        /// The zeroit spoke thickness
        /// </summary>
        private int ZeroitSpokeThickness = 10;

        // Enumeration =======================================================        
        /// <summary>
        /// Enum representing Style Presets
        /// </summary>
        public enum StylePresets
        {
            /// <summary>
            /// The mac osx
            /// </summary>
            MacOSX,
            /// <summary>
            /// The firefox
            /// </summary>
            Firefox,
            /// <summary>
            /// The i e7
            /// </summary>
            IE7,
            /// <summary>
            /// The zeroit
            /// </summary>
            Zeroit,
            /// <summary>
            /// The custom
            /// </summary>
            Custom
        }

        // Attributes ========================================================
        /// <summary>
        /// The m timer
        /// </summary>
        private System.Windows.Forms.Timer m_Timer;
        /// <summary>
        /// The m is timer active
        /// </summary>
        private bool m_IsTimerActive;
        /// <summary>
        /// The m number of spoke
        /// </summary>
        private int m_NumberOfSpoke;
        /// <summary>
        /// The m spoke thickness
        /// </summary>
        private int m_SpokeThickness;
        /// <summary>
        /// The m progress value
        /// </summary>
        private int m_ProgressValue;
        /// <summary>
        /// The m outer circle radius
        /// </summary>
        private int m_OuterCircleRadius;
        /// <summary>
        /// The m inner circle radius
        /// </summary>
        private int m_InnerCircleRadius;
        /// <summary>
        /// The m center point
        /// </summary>
        private PointF m_CenterPoint;
        /// <summary>
        /// The m color
        /// </summary>
        private Color m_Color;
        /// <summary>
        /// The m colors
        /// </summary>
        private Color[] m_Colors;
        /// <summary>
        /// The m angles
        /// </summary>
        private double[] m_Angles;
        /// <summary>
        /// The m style preset
        /// </summary>
        private StylePresets m_StylePreset;
        /// <summary>
        /// The timer interval
        /// </summary>
        private int _Timer_Interval = 1000;

        // Properties ========================================================
        /// <summary>
        /// Gets or sets the lightest color of the circle.
        /// </summary>
        /// <value>The lightest color of the circle.</value>
        [TypeConverter("System.Drawing.ColorConverter"),
         Category("LoadingCircle"),
         Description("Sets the color of spoke.")]
        public Color Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;

                GenerateColorsPallet();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer circle radius.
        /// </summary>
        /// <value>The outer circle radius.</value>
        [System.ComponentModel.Description("Gets or sets the radius of outer circle."),
         System.ComponentModel.Category("LoadingCircle")]
        public int OuterCircleRadius
        {
            get
            {
                if (m_OuterCircleRadius == 0)
                    m_OuterCircleRadius = DefaultOuterCircleRadius;

                return m_OuterCircleRadius;
            }
            set
            {
                m_OuterCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle radius.
        /// </summary>
        /// <value>The inner circle radius.</value>
        [System.ComponentModel.Description("Gets or sets the radius of inner circle."),
         System.ComponentModel.Category("LoadingCircle")]
        public int InnerCircleRadius
        {
            get
            {
                if (m_InnerCircleRadius == 0)
                    m_InnerCircleRadius = DefaultInnerCircleRadius;

                return m_InnerCircleRadius;
            }
            set
            {
                m_InnerCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of spoke.
        /// </summary>
        /// <value>The number of spoke.</value>
        [System.ComponentModel.Description("Gets or sets the number of spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public int NumberSpoke
        {
            get
            {
                if (m_NumberOfSpoke == 0)
                    m_NumberOfSpoke = DefaultNumberOfSpoke;

                return m_NumberOfSpoke;
            }
            set
            {
                if (m_NumberOfSpoke != value && m_NumberOfSpoke > 0)
                {
                    if (value > 255)
                    {
                        value = 255;
                    }
                    m_NumberOfSpoke = value;
                    GenerateColorsPallet();
                    GetSpokesAngles();

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:LoadingCircle" /> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [System.ComponentModel.Description("Gets or sets the number of spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public bool Active
        {
            get
            {
                return m_IsTimerActive;
            }
            set
            {
                m_IsTimerActive = value;
                ActiveTimer();
            }
        }

        /// <summary>
        /// Gets or sets the spoke thickness.
        /// </summary>
        /// <value>The spoke thickness.</value>
        [System.ComponentModel.Description("Gets or sets the thickness of a spoke."),
        System.ComponentModel.Category("LoadingCircle")]
        public int SpokeThickness
        {
            get
            {
                if (m_SpokeThickness <= 0)
                    m_SpokeThickness = DefaultSpokeThickness;

                return m_SpokeThickness;
            }
            set
            {
                m_SpokeThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotation speed.
        /// </summary>
        /// <value>The rotation speed.</value>
        [System.ComponentModel.Description("Gets or sets the rotation speed. Higher the slower."),
        System.ComponentModel.Category("LoadingCircle")]
        public int RotationSpeed
        {
            get
            {
                return m_Timer.Interval;
            }
            set
            {
                if (value > 0)
                    m_Timer.Interval = value;
            }
        }

        /// <summary>
        /// Gets or sets the Timer Interval.
        /// </summary>
        /// <value>The rotation speed.</value>
        /// <exception cref="ArgumentOutOfRangeException">Value should be more than 0</exception>
        [System.ComponentModel.Description("Gets or sets the Time Interval. Higher the slower."),
        System.ComponentModel.Category("LoadingCircle")]
        public int Timer_Interval
        {
            get
            {
                return _Timer_Interval;
            }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Value should be more than 0");

                else
                    _Timer_Interval = value;
            }
        }

        /// <summary>
        /// Quickly sets the style to one of these presets, or a custom style if desired
        /// </summary>
        /// <value>The style preset.</value>
        [Category("LoadingCircle"),
         Description("Quickly sets the style to one of these presets, or a custom style if desired"),
         DefaultValue(typeof(StylePresets), "Custom")]
        public StylePresets StylePreset
        {
            get { return m_StylePreset; }
            set
            {
                m_StylePreset = value;

                switch (m_StylePreset)
                {
                    case StylePresets.MacOSX:
                        SetCircleAppearance(MacOSXNumberOfSpoke,
                            MacOSXSpokeThickness, MacOSXInnerCircleRadius,
                            MacOSXOuterCircleRadius);
                        break;
                    case StylePresets.Firefox:
                        SetCircleAppearance(FireFoxNumberOfSpoke,
                            FireFoxSpokeThickness, FireFoxInnerCircleRadius,
                            FireFoxOuterCircleRadius);
                        break;
                    case StylePresets.IE7:
                        SetCircleAppearance(IE7NumberOfSpoke,
                            IE7SpokeThickness, IE7InnerCircleRadius,
                            IE7OuterCircleRadius);
                        break;
                    case StylePresets.Zeroit:
                        SetCircleAppearance(ZeroitNumberOfSpoke,
                            ZeroitSpokeThickness, ZeroitInnerCircleRadius,
                            ZeroitOuterCircleRadius);
                        RotationSpeed = 10;
                        break;
                    case StylePresets.Custom:
                        SetCircleAppearance(DefaultNumberOfSpoke,
                            DefaultSpokeThickness,
                            DefaultInnerCircleRadius,
                            DefaultOuterCircleRadius);
                        break;
                }
            }
        }

        // Construtor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LoadingCircle" /> class.
        /// </summary>
        public ZeroitProgressIndicatorSpinner()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            m_Color = DefaultColor;

            GenerateColorsPallet();
            GetSpokesAngles();
            GetControlCenterPoint();

            m_Timer = new System.Windows.Forms.Timer();
            m_Timer.Interval = _Timer_Interval;
            m_Timer.Tick += new EventHandler(aTimer_Tick);
            ActiveTimer();

            this.Resize += new EventHandler(LoadingCircle_Resize);
        }

        // Events ============================================================
        /// <summary>
        /// Handles the Resize event of the LoadingCircle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
        void LoadingCircle_Resize(object sender, EventArgs e)
        {
            GetControlCenterPoint();
        }

        /// <summary>
        /// Handles the Tick event of the aTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
        void aTimer_Tick(object sender, EventArgs e)
        {
            m_ProgressValue = ++m_ProgressValue % m_NumberOfSpoke;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (m_NumberOfSpoke > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                int intPosition = m_ProgressValue;
                for (int intCounter = 0; intCounter < m_NumberOfSpoke; intCounter++)
                {
                    intPosition = intPosition % m_NumberOfSpoke;
                    DrawLine(e.Graphics,
                             GetCoordinate(m_CenterPoint, m_InnerCircleRadius, m_Angles[intPosition]),
                             GetCoordinate(m_CenterPoint, m_OuterCircleRadius, m_Angles[intPosition]),
                             m_Colors[intCounter], m_SpokeThickness);
                    intPosition++;
                }
            }

            base.OnPaint(e);
        }

        // Overridden Methods ================================================
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            proposedSize.Width =
                (m_OuterCircleRadius + m_SpokeThickness) * 2;

            return proposedSize;
        }

        // Methods ===========================================================
        /// <summary>
        /// Darkens a specified color.
        /// </summary>
        /// <param name="_objColor">Color to darken.</param>
        /// <param name="_intPercent">The percent of darken.</param>
        /// <returns>The new color generated.</returns>
        private Color Darken(Color _objColor, int _intPercent)
        {
            int intRed = _objColor.R;
            int intGreen = _objColor.G;
            int intBlue = _objColor.B;
            return Color.FromArgb(_intPercent, System.Math.Min(intRed, byte.MaxValue), System.Math.Min(intGreen, byte.MaxValue), System.Math.Min(intBlue, byte.MaxValue));
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        private void GenerateColorsPallet()
        {
            m_Colors = GenerateColorsPallet(m_Color, Active, m_NumberOfSpoke);
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        /// <param name="_objColor">Color of the lightest spoke.</param>
        /// <param name="_blnShadeColor">if set to <c>true</c> the color will be shaded on X spoke.</param>
        /// <param name="_intNbSpoke">The int nb spoke.</param>
        /// <returns>An array of color used to draw the circle.</returns>
        private Color[] GenerateColorsPallet(Color _objColor, bool _blnShadeColor, int _intNbSpoke)
        {
            Color[] objColors = new Color[NumberSpoke];

            // Value is used to simulate a gradient feel... For each spoke, the 
            // color will be darken by value in intIncrement.
            byte bytIncrement = (byte)(byte.MaxValue / NumberSpoke);

            //Reset variable in case of multiple passes
            byte PERCENTAGE_OF_DARKEN = 0;

            for (int intCursor = 0; intCursor < NumberSpoke; intCursor++)
            {
                if (_blnShadeColor)
                {
                    if (intCursor == 0 || intCursor < NumberSpoke - _intNbSpoke)
                        objColors[intCursor] = _objColor;
                    else
                    {
                        // Increment alpha channel color
                        PERCENTAGE_OF_DARKEN += bytIncrement;

                        // Ensure that we don't exceed the maximum alpha
                        // channel value (255)
                        if (PERCENTAGE_OF_DARKEN > byte.MaxValue)
                            PERCENTAGE_OF_DARKEN = byte.MaxValue;

                        // Determine the spoke forecolor
                        objColors[intCursor] = Darken(_objColor, PERCENTAGE_OF_DARKEN);
                    }
                }
                else
                    objColors[intCursor] = _objColor;
            }

            return objColors;
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        private void GetControlCenterPoint()
        {
            m_CenterPoint = GetControlCenterPoint(this);
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        /// <param name="_objControl">The object control.</param>
        /// <returns>PointF object</returns>
        private PointF GetControlCenterPoint(Control _objControl)
        {
            return new PointF(_objControl.Width / 2, _objControl.Height / 2 - 1);
        }

        /// <summary>
        /// Draws the line with GDI+.
        /// </summary>
        /// <param name="_objGraphics">The Graphics object.</param>
        /// <param name="_objPointOne">The point one.</param>
        /// <param name="_objPointTwo">The point two.</param>
        /// <param name="_objColor">Color of the spoke.</param>
        /// <param name="_intLineThickness">The thickness of spoke.</param>
        private void DrawLine(Graphics _objGraphics, PointF _objPointOne, PointF _objPointTwo,
                              Color _objColor, int _intLineThickness)
        {
            using (Pen objPen = new Pen(new SolidBrush(_objColor), _intLineThickness))
            {
                objPen.StartCap = LineCap.Round;
                objPen.EndCap = LineCap.Round;
                _objGraphics.DrawLine(objPen, _objPointOne, _objPointTwo);
            }
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        /// <param name="_objCircleCenter">The Circle center.</param>
        /// <param name="_intRadius">The radius.</param>
        /// <param name="_dblAngle">The angle.</param>
        /// <returns>PointF.</returns>
        private PointF GetCoordinate(PointF _objCircleCenter, int _intRadius, double _dblAngle)
        {
            double dblAngle = System.Math.PI * _dblAngle / NumberOfDegreesInHalfCircle;

            return new PointF(_objCircleCenter.X + _intRadius * (float)System.Math.Cos(dblAngle),
                              _objCircleCenter.Y + _intRadius * (float)System.Math.Sin(dblAngle));
        }

        /// <summary>
        /// Gets the spokes angles.
        /// </summary>
        private void GetSpokesAngles()
        {
            m_Angles = GetSpokesAngles(NumberSpoke);
        }

        /// <summary>
        /// Gets the spoke angles.
        /// </summary>
        /// <param name="_intNumberSpoke">The int number spoke.</param>
        /// <returns>An array of angle.</returns>
        private double[] GetSpokesAngles(int _intNumberSpoke)
        {
            double[] Angles = new double[_intNumberSpoke];
            double dblAngle = (double)NumberOfDegreesInCircle / _intNumberSpoke;

            for (int shtCounter = 0; shtCounter < _intNumberSpoke; shtCounter++)
                Angles[shtCounter] = (shtCounter == 0 ? dblAngle : Angles[shtCounter - 1] + dblAngle);

            return Angles;
        }

        /// <summary>
        /// Actives the timer.
        /// </summary>
        private void ActiveTimer()
        {
            if (m_IsTimerActive)
                m_Timer.Start();
            else
            {
                m_Timer.Stop();
                m_ProgressValue = 0;
            }

            GenerateColorsPallet();
            Invalidate();
        }

        /// <summary>
        /// Sets the circle appearance.
        /// </summary>
        /// <param name="numberSpoke">The number spoke.</param>
        /// <param name="spokeThickness">The spoke thickness.</param>
        /// <param name="innerCircleRadius">The inner circle radius.</param>
        /// <param name="outerCircleRadius">The outer circle radius.</param>
        public void SetCircleAppearance(int numberSpoke, int spokeThickness,
            int innerCircleRadius, int outerCircleRadius)
        {
            NumberSpoke = numberSpoke;
            SpokeThickness = spokeThickness;
            InnerCircleRadius = innerCircleRadius;
            OuterCircleRadius = outerCircleRadius;

            Invalidate();
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressIndicatorSpinnerDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressIndicatorSpinnerDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressIndicatorSpinnerSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressIndicatorSpinnerSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressIndicatorSpinnerSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressIndicatorSpinner colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressIndicatorSpinnerSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressIndicatorSpinnerSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressIndicatorSpinner;

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
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public Color Color
        {
            get
            {
                return colUserControl.Color;
            }
            set
            {
                GetPropertyByName("Color").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the outer circle radius.
        /// </summary>
        /// <value>The outer circle radius.</value>
        public int OuterCircleRadius
        {
            get
            {
                return colUserControl.OuterCircleRadius;
            }
            set
            {
                GetPropertyByName("OuterCircleRadius").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the inner circle radius.
        /// </summary>
        /// <value>The inner circle radius.</value>
        public int InnerCircleRadius
        {
            get
            {
                return colUserControl.InnerCircleRadius;
            }
            set
            {
                GetPropertyByName("InnerCircleRadius").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the number spoke.
        /// </summary>
        /// <value>The number spoke.</value>
        public int NumberSpoke
        {
            get
            {
                return colUserControl.NumberSpoke;
            }
            set
            {
                GetPropertyByName("NumberSpoke").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ZeroitProgressIndicatorSpinnerSmartTagActionList"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active
        {
            get
            {
                return colUserControl.Active;
            }
            set
            {
                GetPropertyByName("Active").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the spoke thickness.
        /// </summary>
        /// <value>The spoke thickness.</value>
        public int SpokeThickness
        {
            get
            {
                return colUserControl.SpokeThickness;
            }
            set
            {
                GetPropertyByName("SpokeThickness").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the rotation speed.
        /// </summary>
        /// <value>The rotation speed.</value>
        public int RotationSpeed
        {
            get
            {
                return colUserControl.RotationSpeed;
            }
            set
            {
                GetPropertyByName("RotationSpeed").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int Timer_Interval
        {
            get
            {
                return colUserControl.Timer_Interval;
            }
            set
            {
                GetPropertyByName("Timer_Interval").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the style preset.
        /// </summary>
        /// <value>The style preset.</value>
        public Zeroit.Framework.Progress.ZeroitProgressIndicatorSpinner.StylePresets StylePreset
        {
            get
            {
                return colUserControl.StylePreset;
            }
            set
            {
                GetPropertyByName("StylePreset").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Color",
                                 "Color", "Appearance",
                                 "Sets the Color of the control."));

            items.Add(new DesignerActionPropertyItem("OuterCircleRadius",
                                 "Outer Circle Radius", "Appearance",
                                 "Sets the outer radius of the control."));

            items.Add(new DesignerActionPropertyItem("InnerCircleRadius",
                                 "Inner Circle Radius", "Appearance",
                                 "Sets the inner circle radius of the control."));

            items.Add(new DesignerActionPropertyItem("NumberSpoke",
                                 "Number Spoke", "Appearance",
                                 "Sets the number of spokes."));

            items.Add(new DesignerActionPropertyItem("Active",
                                 "Active", "Appearance",
                                 "Sets the control animation in the designer and at runtime."));

            items.Add(new DesignerActionPropertyItem("SpokeThickness",
                                 "Spoke Thickness", "Appearance",
                                 "Sets the spoke thickness."));

            items.Add(new DesignerActionPropertyItem("RotationSpeed",
                                 "Rotation Speed", "Appearance",
                                 "Sets the rotation speed of the control."));

            items.Add(new DesignerActionPropertyItem("Timer_Interval",
                                 "Timer Interval", "Appearance",
                                 "Sets the timer interval of this control for animation."));

            items.Add(new DesignerActionPropertyItem("StylePreset",
                                 "Style Preset", "Appearance",
                                 "Sets the type of spinner."));



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

    #region LoadingCircle.Designer.cs

    //partial class LoadingCircle
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}

    #endregion

    #region LoadingCircleToolStripMenuItem

    /// <summary>
    /// Class LoadingCircleToolStripMenuItem.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ToolStripControlHost" />
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class LoadingCircleToolStripMenuItem : ToolStripControlHost
    {
        // Constants =========================================================

        // Attributes ========================================================

        // Properties ========================================================
        /// <summary>
        /// Gets the loading circle control.
        /// </summary>
        /// <value>The loading circle control.</value>
        [RefreshProperties(RefreshProperties.All),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ZeroitProgressIndicatorSpinner LoadingCircleControl
        {
            get { return Control as ZeroitProgressIndicatorSpinner; }
        }

        // Constructor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingCircleToolStripMenuItem" /> class.
        /// </summary>
        public LoadingCircleToolStripMenuItem()
            : base(new ZeroitProgressIndicatorSpinner())
        {
        }

        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="constrainingSize">The custom-sized area for a control.</param>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.</returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override Size GetPreferredSize(Size constrainingSize)
        {
            //return base.GetPreferredSize(constrainingSize);
            return this.LoadingCircleControl.GetPreferredSize(constrainingSize);
        }

        /// <summary>
        /// Subscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to subscribe events.</param>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);

            //Add your code here to subsribe to Control Events
        }

        /// <summary>
        /// Unsubscribes events from the hosted control.
        /// </summary>
        /// <param name="control">The control from which to unsubscribe events.</param>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);

            //Add your code here to unsubscribe from control events.
        }
    }

    #endregion

    #endregion 
}
