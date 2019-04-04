// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="MacOSX - NonOptimized.cs" company="Zeroit Dev Technologies">
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
using System.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region MacOSX

    #region MacOSX NonOptimized

    #region Control    
    /// <summary>
    /// A class collection for rendering a mac os x type control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />.
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Designer(typeof(ZeroitMacOSXDesigner))]
    public partial class ZeroitMacOSX : UserControl
    {

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
        /// Gets or sets a value indicating whether to automatically animate the control.
        /// </summary>
        /// <value><c>true</c> if AutoStartMode animate; otherwise, <c>false</c>.</value>
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
            if (this.StartAngle + 1 > 360)
                this.StartAngle = 0;
            else
                this.StartAngle++;
            Invalidate();
        }

        #endregion

        #region Constants

        /// <summary>
        /// The default interval
        /// </summary>
        private const int DEFAULT_INTERVAL = 60;
        /// <summary>
        /// The default tick color
        /// </summary>
        private readonly Color DEFAULT_TICK_COLOR = Color.FromArgb(58, 58, 58);
        /// <summary>
        /// The default tick width
        /// </summary>
        private const int DEFAULT_TICK_WIDTH = 2;
        /// <summary>
        /// The minimum inner radius
        /// </summary>
        private const int MINIMUM_INNER_RADIUS = 4;
        /// <summary>
        /// The minimum outer radius
        /// </summary>
        private const int MINIMUM_OUTER_RADIUS = 8;
        /// <summary>
        /// The minimum control size
        /// </summary>
        private Size MINIMUM_CONTROL_SIZE = new Size(28, 28);
        /// <summary>
        /// The minimum pen width
        /// </summary>
        private const int MINIMUM_PEN_WIDTH = 2;

        #endregion

        #region Enums

        /// <summary>
        /// Enum representing how the control should be started.
        /// </summary>
        public enum AutoStartMode
        {
            /// <summary>
            /// The start
            /// </summary>
            Start,
            /// <summary>
            /// The fast rotate
            /// </summary>
            FastRotate,
            /// <summary>
            /// The slow rotate
            /// </summary>
            SlowRotate,
            /// <summary>
            /// The stop
            /// </summary>
            Stop
        }


        /// <summary>
        /// Enum representing the direction of the control.
        /// </summary>
        public enum Direction
        {
            /// <summary>
            /// The clockwise
            /// </summary>
            CLOCKWISE,
            /// <summary>
            /// The anticlockwise
            /// </summary>
            ANTICLOCKWISE
        }

        #endregion

        #region Members

        /// <summary>
        /// The m interval
        /// </summary>
        private int m_Interval;
        /// <summary>
        /// The m pen
        /// </summary>
        Pen m_Pen = null;
        /// <summary>
        /// The m centre pt
        /// </summary>
        PointF m_CentrePt = new PointF();
        /// <summary>
        /// The m inner radius
        /// </summary>
        int m_InnerRadius = 0;
        /// <summary>
        /// The m outer radius
        /// </summary>
        int m_OuterRadius = 0;
        /// <summary>
        /// The m start angle
        /// </summary>
        int m_StartAngle = 0;
        /// <summary>
        /// The m alpha start value
        /// </summary>
        int m_AlphaStartValue = 0;
        /// <summary>
        /// The m spokes count
        /// </summary>
        int m_SpokesCount = 0;
        /// <summary>
        /// The m angle increment
        /// </summary>
        int m_AngleIncrement = 0;
        /// <summary>
        /// The m alpha decrement
        /// </summary>
        int m_AlphaDecrement = 0;
        /// <summary>
        /// The m timer
        /// </summary>
        System.Windows.Forms.Timer m_Timer = null;

        /// <summary>
        /// The automatic
        /// </summary>
        private AutoStartMode _automatic = AutoStartMode.Start;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the control will be started.
        /// </summary>
        /// <value>The AutoStartMode.</value>
        public AutoStartMode Automatic
        {
            get { return _automatic; }
            set
            {
                _automatic = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Time interval for each tick.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval
        {
            get
            {
                return m_Interval;
            }
            set
            {
                if (value > 0)
                {
                    m_Interval = value;
                }
                else
                {
                    m_Interval = DEFAULT_INTERVAL;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Color of the tick
        /// </summary>
        /// <value>The color of the tick.</value>
        public Color TickColor { get; set; }

        /// <summary>
        /// Direction of rotation - CLOCKWISE/ANTICLOCKWISE
        /// </summary>
        /// <value>The rotation.</value>
        public Direction Rotation { get; set; }

        /// <summary>
        /// Angle at which the tick should start
        /// </summary>
        /// <value>The start angle.</value>
        public int StartAngle
        {
            get
            {
                return m_StartAngle;
            }
            set
            {
                m_StartAngle = value;
                Invalidate();
            }
        }

        #endregion

        #region Construction/Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMacOSX" /> class.
        /// </summary>
        public ZeroitMacOSX()
        {
            this.DoubleBuffered = true;

            InitializeComponent();

            this.BackColor = Color.Transparent;
            this.TickColor = DEFAULT_TICK_COLOR;
            this.MinimumSize = MINIMUM_CONTROL_SIZE;
            this.Interval = DEFAULT_INTERVAL;
            // Default rotation direction is clockwise
            this.Rotation = Direction.CLOCKWISE;
            // Default starting angle is 12 o'clock
            this.StartAngle = 270;
            // Default number of Spokes in this control is 12
            m_SpokesCount = 12;
            // Default alpha value of the first spoke is 255
            m_AlphaStartValue = 255;
            // Calculate the angle between adjacent spokes
            m_AngleIncrement = (int)(360 / m_SpokesCount);
            // Calculate the change in alpha between adjacent spokes
            m_AlphaDecrement = (int)((m_AlphaStartValue - 15) / m_SpokesCount);

            m_Pen = new Pen(TickColor, DEFAULT_TICK_WIDTH);
            m_Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            m_Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            m_Timer = new System.Windows.Forms.Timer();
            m_Timer.Interval = this.Interval;
            m_Timer.Tick += new EventHandler(OnTimerTick);


        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handle the Tick event
        /// </summary>
        /// <param name="sender">Timer</param>
        /// <param name="e">EventArgs</param>
        void OnTimerTick(object sender, EventArgs e)
        {
            if (Rotation == Direction.CLOCKWISE)
            {
                m_StartAngle += m_AngleIncrement;

                if (m_StartAngle >= 360)
                    m_StartAngle = 0;
            }
            else if (Rotation == Direction.ANTICLOCKWISE)
            {
                m_StartAngle -= m_AngleIncrement;

                if (m_StartAngle <= -360)
                    m_StartAngle = 0;
            }

            Invalidate();
        }

        /// <summary>
        /// Handles the Paint Event of the control
        /// </summary>
        /// <param name="e">PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // All the painting will be handled by us.
            //base.OnPaint(e);

            switch (_automatic)
            {
                case AutoStartMode.Start:
                    this.Start();
                    break;
                case AutoStartMode.FastRotate:
                    #region MyRegion
                    if (DesignMode)
                    {
                        timer.Tick += Timer_Tick;
                        if (AutoAnimate)
                        {
                            timer.Interval = m_Interval;
                            timer.Start();
                        }
                    }

                    if (!DesignMode)
                    {
                        timer.Tick += Timer_Tick;

                        if (AutoAnimate)
                        {
                            timer.Interval = m_Interval;
                            timer.Start();
                        }
                    }

                    #endregion
                    break;
                case AutoStartMode.SlowRotate:
                    this.Stop();

                    break;

                case AutoStartMode.Stop:
                    this.Stop();
                    timer.Stop();
                    break;
                default:
                    break;
            }



            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // Since the Rendering of the spokes is dependent upon the current size of the 
            // control, the following calculation needs to be done within the Paint eventhandler.
            int alpha = m_AlphaStartValue;
            int angle = m_StartAngle;
            // Calculate the location around which the spokes will be drawn
            int width = (this.Width < this.Height) ? this.Width : this.Height;
            m_CentrePt = new PointF(this.Width / 2, this.Height / 2);
            // Calculate the width of the pen which will be used to draw the spokes
            m_Pen.Width = (int)(width / 15);
            if (m_Pen.Width < MINIMUM_PEN_WIDTH)
                m_Pen.Width = MINIMUM_PEN_WIDTH;
            // Calculate the inner and outer radii of the control. The radii should not be less than the
            // Minimum values
            m_InnerRadius = (int)(width * (140 / (float)800));
            if (m_InnerRadius < MINIMUM_INNER_RADIUS)
                m_InnerRadius = MINIMUM_INNER_RADIUS;
            m_OuterRadius = (int)(width * (250 / (float)800));
            if (m_OuterRadius < MINIMUM_OUTER_RADIUS)
                m_OuterRadius = MINIMUM_OUTER_RADIUS;

            // Render the spokes
            for (int i = 0; i < m_SpokesCount; i++)
            {
                PointF pt1 = new PointF(m_InnerRadius * (float)System.Math.Cos(ConvertDegreesToRadians(angle)), m_InnerRadius * (float)System.Math.Sin(ConvertDegreesToRadians(angle)));
                PointF pt2 = new PointF(m_OuterRadius * (float)System.Math.Cos(ConvertDegreesToRadians(angle)), m_OuterRadius * (float)System.Math.Sin(ConvertDegreesToRadians(angle)));

                pt1.X += m_CentrePt.X;
                pt1.Y += m_CentrePt.Y;
                pt2.X += m_CentrePt.X;
                pt2.Y += m_CentrePt.Y;
                m_Pen.Color = Color.FromArgb(alpha, this.TickColor);
                e.Graphics.DrawLine(m_Pen, pt1, pt2);

                if (Rotation == Direction.CLOCKWISE)
                {
                    angle -= m_AngleIncrement;
                }
                else if (Rotation == Direction.ANTICLOCKWISE)
                {
                    angle += m_AngleIncrement;
                }

                //if (i < 5)
                //    alpha -= 45;
                alpha -= m_AlphaDecrement;
            }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Converts Degrees to Radians
        /// </summary>
        /// <param name="degrees">Degrees</param>
        /// <returns>System.Double.</returns>
        private double ConvertDegreesToRadians(int degrees)
        {
            return ((System.Math.PI / (double)180) * degrees);
        }

        #endregion

        #region APIs

        /// <summary>
        /// Start the Tick Control rotation
        /// </summary>
        public void Start()
        {
            if (m_Timer != null)
            {
                m_Timer.Interval = this.Interval;
                m_Timer.Enabled = true;
            }
        }

        /// <summary>
        /// Stop the Tick Control rotation
        /// </summary>
        public void Stop()
        {
            if (m_Timer != null)
            {
                m_Timer.Enabled = false;
            }
        }

        #endregion
    }
    #endregion

    #region Designer Generated Code

    partial class ZeroitMacOSX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }

    #endregion


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitMacOSXDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitMacOSXDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitMacOSXSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitMacOSXSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitMacOSXSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitMacOSX colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitMacOSXSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitMacOSXSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitMacOSX;

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

        /// <summary>
        /// Gets or sets a value indicating whether [automatic animate].
        /// </summary>
        /// <value><c>true</c> if [automatic animate]; otherwise, <c>false</c>.</value>
        public bool AutoAnimate
        {
            get
            {
                return colUserControl.AutoAnimate;
            }
            set
            {
                GetPropertyByName("AutoAnimate").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the automatic.
        /// </summary>
        /// <value>The automatic.</value>
        public Zeroit.Framework.Progress.ZeroitMacOSX.AutoStartMode Automatic
        {
            get
            {
                return colUserControl.Automatic;
            }
            set
            {
                GetPropertyByName("Automatic").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval
        {
            get
            {
                return colUserControl.Interval;
            }
            set
            {
                GetPropertyByName("Interval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the tick.
        /// </summary>
        /// <value>The color of the tick.</value>
        public Color TickColor
        {
            get
            {
                return colUserControl.TickColor;
            }
            set
            {
                GetPropertyByName("TickColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public Zeroit.Framework.Progress.ZeroitMacOSX.Direction Rotation
        {
            get
            {
                return colUserControl.Rotation;
            }
            set
            {
                GetPropertyByName("Rotation").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the start angle.
        /// </summary>
        /// <value>The start angle.</value>
        public int StartAngle
        {
            get
            {
                return colUserControl.StartAngle;
            }
            set
            {
                GetPropertyByName("StartAngle").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("Automatic",
                                 "Automatic", "Appearance",
                                 "Sets the rotation style."));

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "Auto Animate", "Appearance",
                                 "Set to enable auto animation."));

            items.Add(new DesignerActionPropertyItem("Interval",
                                 "Interval", "Appearance",
                                 "Sets the timer interval."));

            items.Add(new DesignerActionPropertyItem("TickColor",
                                 "TickColor", "Appearance",
                                 "Sets the color of the tick."));

            items.Add(new DesignerActionPropertyItem("Rotation",
                                 "Rotation", "Appearance",
                                 "Sets the rotation orientation."));

            items.Add(new DesignerActionPropertyItem("StartAngle",
                                 "Start Angle", "Appearance",
                                 "Sets the start angle."));

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
    
    #endregion
}
