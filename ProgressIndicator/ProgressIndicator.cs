// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressIndicator.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Collections.Generic;
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
    #region Progress Indicator

    /// <summary>
    /// A class collection for rendering a progress indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [Designer(typeof(ZeroitProgressIndicatorDesigner))]
    public class ZeroitProgressIndicator : Control
    {

        #region Variables

        /// <summary>
        /// The base color
        /// </summary>
        private readonly SolidBrush BaseColor = new SolidBrush(Color.DarkGray);
        /// <summary>
        /// The animation color
        /// </summary>
        private readonly SolidBrush AnimationColor = new SolidBrush(Color.DimGray);

        /// <summary>
        /// The animation speed
        /// </summary>
        private readonly System.Windows.Forms.Timer AnimationSpeed = new System.Windows.Forms.Timer();
        /// <summary>
        /// The float point
        /// </summary>
        private PointF[] FloatPoint;
        /// <summary>
        /// The buff graphics
        /// </summary>
        private BufferedGraphics BuffGraphics;
        /// <summary>
        /// The g
        /// </summary>
        private Graphics G;
        /// <summary>
        /// The indicator index
        /// </summary>
        private int IndicatorIndex;
        /// <summary>
        /// The graphics context
        /// </summary>
        private readonly BufferedGraphicsContext GraphicsContext = BufferedGraphicsManager.Current;

        /// <summary>
        /// The visible circles
        /// </summary>
        private float _visibleCircles = 45f;
        /// <summary>
        /// The radian
        /// </summary>
        private double _radian = 180f;
        /// <summary>
        /// The circle width
        /// </summary>
        private float _circleWidth = 15f;
        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.AntiAlias;

        #endregion

        #region Custom Properties

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get { return smoothing; }
            set
            {
                smoothing = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of circles.
        /// </summary>
        /// <value>The number of circles.</value>
        public float NumberOfCircles
        {
            get { return _visibleCircles; }
            set
            {
                _visibleCircles = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the circle.
        /// </summary>
        /// <value>The width of the circle.</value>
        public float CircleWidth
        {
            get { return _circleWidth; }
            set
            {
                _circleWidth = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the radian.
        /// </summary>
        /// <value>The radian.</value>
        public double Radian
        {
            get { return _radian; }
            set
            {
                _radian = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the base color.
        /// </summary>
        /// <value>The base color.</value>
        public Color GetBaseColor
        {
            get { return BaseColor.Color; }
            set
            {
                BaseColor.Color = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation color.
        /// </summary>
        /// <value>The animation color.</value>
        public Color GetAnimationColor
        {
            get { return AnimationColor.Color; }
            set
            {
                AnimationColor.Color = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int GetAnimationSpeed
        {
            get { return AnimationSpeed.Interval; }
            set
            {
                AnimationSpeed.Interval = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs


        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
            UpdateGraphics();
            SetPoints();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            AnimationSpeed.Enabled = this.Enabled;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationSpeed.Tick += AnimationSpeed_Tick;
            AnimationSpeed.Start();
        }

        /// <summary>
        /// Handles the Tick event of the AnimationSpeed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AnimationSpeed_Tick(object sender, EventArgs e)
        {
            if (IndicatorIndex.Equals(0))
            {
                IndicatorIndex = FloatPoint.Length - 1;
            }
            else
            {
                IndicatorIndex -= 1;
            }
            this.Invalidate(false);
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressIndicator" /> class.
        /// </summary>
        public ZeroitProgressIndicator()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);

            Size = new Size(80, 80);
            Text = string.Empty;
            MinimumSize = new Size(80, 80);
            SetPoints();
            AnimationSpeed.Interval = 100;
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
        /// Sets the points.
        /// </summary>
        private void SetPoints()
        {
            Stack<PointF> stack = new Stack<PointF>();
            PointF startingFloatPoint = new PointF(((float)this.Width) / 2f, ((float)this.Height) / 2f);
            for (float i = 0f; i < 360f; i += _visibleCircles)
            {
                this.SetValue(startingFloatPoint, (int)System.Math.Round((double)((((double)this.Width) / 2.0) - 15.0)), (double)i);
                PointF endPoint = this.EndPoint;
                endPoint = new PointF(endPoint.X - 7.5f, endPoint.Y - 7.5f);
                stack.Push(endPoint);
            }
            this.FloatPoint = stack.ToArray();
        }

        /// <summary>
        /// Updates the graphics.
        /// </summary>
        private void UpdateGraphics()
        {
            if ((this.Width > 0) && (this.Height > 0))
            {
                Size size2 = new Size(this.Width + 1, this.Height + 1);
                this.GraphicsContext.MaximumBuffer = size2;
                this.BuffGraphics = this.GraphicsContext.Allocate(this.CreateGraphics(), this.ClientRectangle);
                this.BuffGraphics.Graphics.SmoothingMode = smoothing;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            BuffGraphics.Graphics.Clear(BackColor);

            int num2 = this.FloatPoint.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.IndicatorIndex == i)
                {
                    this.BuffGraphics.Graphics.FillEllipse(this.AnimationColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, _circleWidth, _circleWidth);

                }
                else
                {
                    this.BuffGraphics.Graphics.FillEllipse(this.BaseColor, this.FloatPoint[i].X, this.FloatPoint[i].Y, _circleWidth, _circleWidth);

                }
            }

            this.BuffGraphics.Render(e.Graphics);


        }


        /// <summary>
        /// The rise
        /// </summary>
        private double Rise;
        /// <summary>
        /// The run
        /// </summary>
        private double Run;
        /// <summary>
        /// The starting float point
        /// </summary>
        private PointF _StartingFloatPoint;

        /// <summary>
        /// Assigns the values.
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="Run">The run.</param>
        /// <param name="Length">The length.</param>
        /// <returns>X.</returns>
        private X AssignValues<X>(ref X Run, X Length)
        {
            Run = Length;
            return Length;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="StartingFloatPoint">The starting float point.</param>
        /// <param name="Length">The length.</param>
        /// <param name="Angle">The angle.</param>
        private void SetValue(PointF StartingFloatPoint, int Length, double Angle)
        {
            double CircleRadian = System.Math.PI * Angle / _radian;

            _StartingFloatPoint = StartingFloatPoint;
            Rise = AssignValues(ref Run, Length);
            Rise = System.Math.Sin(CircleRadian) * Rise;
            Run = System.Math.Cos(CircleRadian) * Run;
        }

        /// <summary>
        /// Gets the end point.
        /// </summary>
        /// <value>The end point.</value>
        private PointF EndPoint
        {
            get
            {
                float LocationX = Convert.ToSingle(_StartingFloatPoint.Y + Rise);
                float LocationY = Convert.ToSingle(_StartingFloatPoint.X + Run);

                return new PointF(LocationY, LocationX);
            }
        }
    }


    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressIndicatorDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressIndicatorDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressIndicatorSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressIndicatorSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressIndicatorSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressIndicator colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressIndicatorSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressIndicatorSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressIndicator;

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
        /// Gets or sets the smoothing.
        /// </summary>
        /// <value>The smoothing.</value>
        public SmoothingMode Smoothing
        {
            get
            {
                return colUserControl.Smoothing;
            }
            set
            {
                GetPropertyByName("Smoothing").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the number of circles.
        /// </summary>
        /// <value>The number of circles.</value>
        public float NumberOfCircles
        {
            get
            {
                return colUserControl.NumberOfCircles;
            }
            set
            {
                GetPropertyByName("NumberOfCircles").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the width of the circle.
        /// </summary>
        /// <value>The width of the circle.</value>
        public float CircleWidth
        {
            get
            {
                return colUserControl.CircleWidth;
            }
            set
            {
                GetPropertyByName("CircleWidth").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the radian.
        /// </summary>
        /// <value>The radian.</value>
        public double Radian
        {
            get
            {
                return colUserControl.Radian;
            }
            set
            {
                GetPropertyByName("Radian").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the get base.
        /// </summary>
        /// <value>The color of the get base.</value>
        public Color GetBaseColor
        {
            get
            {
                return colUserControl.GetBaseColor;
            }
            set
            {
                GetPropertyByName("GetBaseColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the color of the get animation.
        /// </summary>
        /// <value>The color of the get animation.</value>
        public Color GetAnimationColor
        {
            get
            {
                return colUserControl.GetAnimationColor;
            }
            set
            {
                GetPropertyByName("GetAnimationColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the get animation speed.
        /// </summary>
        /// <value>The get animation speed.</value>
        public int GetAnimationSpeed
        {
            get
            {
                return colUserControl.GetAnimationSpeed;
            }
            set
            {
                GetPropertyByName("GetAnimationSpeed").SetValue(colUserControl, value);
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
                                 "BackColor", "Appearance",
                                 "Sets the BackColor of this control."));

            items.Add(new DesignerActionPropertyItem("Smoothing",
                                 "Smoothing", "Appearance",
                                 "Sets the Smoothing mode of this control."));

            items.Add(new DesignerActionPropertyItem("NumberOfCircles",
                                 "Number Of Circles", "Appearance",
                                 "Sets the visible circles."));

            items.Add(new DesignerActionPropertyItem("CircleWidth",
                                 "Circle Width", "Appearance",
                                 "Sets the size of the circle."));

            items.Add(new DesignerActionPropertyItem("Radian",
                                 "Radian", "Appearance",
                                 "Sets the radian of the control. Tweak it to give different effects."));

            items.Add(new DesignerActionPropertyItem("GetBaseColor",
                                 "P Base Color", "Appearance",
                                 "Sets the color of the circles"));

            items.Add(new DesignerActionPropertyItem("GetAnimationColor",
                                 "P Animation Color", "Appearance",
                                 "Sets the animation color of the circle"));

            items.Add(new DesignerActionPropertyItem("GetAnimationSpeed",
                                 "P Animation Speed", "Appearance",
                                 "Sets the speed of the animation."));

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
