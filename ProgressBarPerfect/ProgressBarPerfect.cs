// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ProgressBarPerfect.cs" company="Zeroit Dev Technologies">
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
using System.Globalization;
using System.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ZeroitProgressBarPerfect

    #region ProgressIndicator
    /// <summary>
    /// Firefox like circular progress indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />

    [Designer(typeof(ZeroitProgressBarPerfectDesigner))]
    public partial class ZeroitProgressBarPerfect : Control
    {

        #region Constructor

        /// <summary>
        /// Default constructor for the ProgressIndicator.
        /// </summary>
        public ZeroitProgressBarPerfect()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (DesignMode)
            {
                timerAnimation.Tick += timerAnimation_Tick;
                if (AutoStart)
                    timerAnimation.Start();

            }

            if (!DesignMode)
            {
                timerAnimation.Tick += timerAnimation_Tick;
                if (AutoStart)
                    timerAnimation.Start();

            }

            #region MyRegion
            //if (DesignMode)
            //{
            //    timer.Tick += Timer_Tick;
            //    if (AutoAnimate)
            //    {
            //        timer.Interval = 100;
            //        timer.Start();
            //    }
            //}

            //if (!DesignMode)
            //{
            //    timer.Tick += Timer_Tick;

            //    if (AutoAnimate)
            //    {
            //        timer.Interval = 100;
            //        timer.Start();
            //    }
            //}



            #endregion
        }

        #endregion

        #region Private Fields

        /// <summary>
        /// The value
        /// </summary>
        private int _value = 1;

        /// <summary>
        /// The interval
        /// </summary>
        private int _interval = 100;

        /// <summary>
        /// The circle color
        /// </summary>
        private Color _circleColor = Color.FromArgb(20, 20, 20);

        /// <summary>
        /// The automatic start
        /// </summary>
        private bool _autoStart;

        /// <summary>
        /// The stopped
        /// </summary>
        private bool _stopped = true;

        /// <summary>
        /// The circle size
        /// </summary>
        private float _circleSize = 0.2F;

        /// <summary>
        /// The number of circles
        /// </summary>
        private int _numberOfCircles = 180;

        /// <summary>
        /// The number of visible circles
        /// </summary>
        private int _numberOfVisibleCircles = 30;

        /// <summary>
        /// The rotation
        /// </summary>
        private RotationType1 _rotation = RotationType1.Clockwise;

        /// <summary>
        /// The percentage
        /// </summary>
        private float _percentage;

        /// <summary>
        /// The show percentage
        /// </summary>
        private bool _showPercentage;

        /// <summary>
        /// The show text
        /// </summary>
        private bool _showText;

        /// <summary>
        /// The text display
        /// </summary>
        private TextDisplayModes1 _textDisplay = TextDisplayModes1.None;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value>The text.</value>
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }


        /// <summary>
        /// Gets or sets the base color for the circles.
        /// </summary>
        /// <value>The color of the circle.</value>
        [DefaultValue(typeof(Color), "20, 20, 20")]
        [Description("Gets or sets the base color for the circles.")]
        [Category("Appearance")]
        public Color CircleColor
        {
            get { return _circleColor; }
            set
            {
                _circleColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the animation should start automatically.
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the animation should start automatically.")]
        [Category("Behavior")]
        public bool AutoStart
        {
            get { return _autoStart; }
            set
            {
                _autoStart = value;

                if (_autoStart && !DesignMode)
                    Start();
                else
                    Stop();
            }
        }

        /// <summary>
        /// Gets or sets the scale for the circles raging from 0.1 to 1.0.
        /// </summary>
        /// <value>The size of the circle.</value>
        [DefaultValue(1.0F)]
        [Description("Gets or sets the scale for the circles raging from 0.1 to 1.0.")]
        [Category("Appearance")]
        public float CircleSize
        {
            get { return _circleSize; }
            set
            {
                if (value <= 0.0F)
                    _circleSize = 0.1F;
                else
                    _circleSize = value > 1.0F ? 1.0F : value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        [DefaultValue(75)]
        [Description("Gets or sets the animation speed.")]
        [Category("Behavior")]
        public int AnimationSpeed
        {
            get { return (-_interval + 400) / 4; }
            set
            {
                checked
                {
                    int interval = 400 - (value * 4);

                    if (interval < 10)
                        _interval = 10;
                    else
                        _interval = interval > 400 ? 400 : interval;

                    timerAnimation.Interval = _interval;
                }
            }
        }

        //---------------------------------------------------Number Of Circles-------------------------------------//
        /// <summary>
        /// Gets or sets the number of circles used in the animation.
        /// </summary>
        /// <value>The number of circles.</value>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>


        //[DefaultValue(8)]
        [Description("Gets or sets the number of circles used in the animation.")]
        [Category("Behavior")]
        public int NumberOfCircles
        {
            get { return _numberOfCircles; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer.");
                else
                    _numberOfCircles = value > 500 ? 500 : value;

                _numberOfCircles = value;
                Invalidate();
            }
        }


        //---------------------------------------------------Number Of Circles-------------------------------------//

        /// <summary>
        /// Gets or sets the number of circles used in the animation.
        /// </summary>
        /// <value>The number of visible circles.</value>
        /// <exception cref="ArgumentOutOfRangeException"><c>NumberOfCircles</c> is out of range.</exception>
        [DefaultValue(8)]
        [Description("Gets or sets the number of circles used in the animation.")]
        [Category("Behavior")]
        public int NumberOfVisibleCircles
        {
            get { return _numberOfVisibleCircles; }
            set
            {
                if (value <= 0 || value > _numberOfCircles)
                    throw new ArgumentOutOfRangeException("value", "Number of circles must be a positive integer and less than or equal to the number of circles.");

                _numberOfVisibleCircles = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.
        /// </summary>
        /// <value>The rotation.</value>
        [DefaultValue(RotationType1.Clockwise)]
        [Description("Gets or sets a value indicating if the rotation should be clockwise or counter-clockwise.")]
        [Category("Behavior")]
        public RotationType1 Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        /// <summary>
        /// Gets or sets the percentage to show on the control.
        /// </summary>
        /// <value>The percentage.</value>
        /// <exception cref="ArgumentOutOfRangeException"><c>Percentage</c> is out of range.</exception>
        [DefaultValue(0)]
        [Description("Gets or sets the percentage to show on the control.")]
        [Category("Appearance")]
        public float Percentage
        {
            get { return _percentage; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value", "Percentage must be a positive integer between 0 and 100.");

                _percentage = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the percentage value should be shown.
        /// </summary>
        /// <value><c>true</c> if [show percentage]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the percentage value should be shown.")]
        [Category("Behavior")]
        public bool ShowPercentage
        {
            get { return _showPercentage; }
            set
            {
                _showPercentage = value;

                _textDisplay = _showPercentage
                                   ? _textDisplay | TextDisplayModes1.Percentage
                                   : _textDisplay & ~TextDisplayModes1.Percentage;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the control text should be shown.
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating if the control text should be shown.")]
        [Category("Behavior")]
        public bool ShowText
        {
            get { return _showText; }
            set
            {
                _showText = value;

                _textDisplay = _showText
                                   ? _textDisplay | TextDisplayModes1.Text
                                   : _textDisplay & ~TextDisplayModes1.Text;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the property that will be shown in the control.
        /// </summary>
        /// <value>The text display.</value>
        [DefaultValue(TextDisplayModes1.None)]
        [Description("Gets or sets the property that will be shown in the control.")]
        [Category("Appearance")]
        public TextDisplayModes1 TextDisplay
        {
            get { return _textDisplay; }
            set
            {
                _textDisplay = value;

                _showText = (_textDisplay & TextDisplayModes1.Text) == TextDisplayModes1.Text;
                _showPercentage = (_textDisplay & TextDisplayModes1.Percentage) == TextDisplayModes1.Percentage;
                Invalidate();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts the animation.
        /// </summary>
        public void Start()
        {
            timerAnimation.Interval = _interval;
            _stopped = false;
            timerAnimation.Start();
        }

        /// <summary>
        /// Stops the animation.
        /// </summary>
        public void Stop()
        {
            timerAnimation.Stop();
            _value = 1;
            _stopped = true;
            Invalidate();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            float angle = 360.0F / _numberOfCircles;

            GraphicsState oldState = e.Graphics.Save();

            e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
            e.Graphics.RotateTransform(angle * _value * (int)_rotation);
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 1; i <= _numberOfCircles; i++)
            {
                int alphaValue = (255.0F * (i / (float)_numberOfVisibleCircles)) > 255.0 ? 0 : (int)(255.0F * (i / (float)_numberOfVisibleCircles));
                int alpha = _stopped ? (int)(255.0F * (1.0F / 8.0F)) : alphaValue;

                Color drawColor = Color.FromArgb(alpha, _circleColor);



                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 4.5F / _circleSize;
                    float size = Width / sizeRate;

                    float diff = (Width / 4.5F) - size;

                    float x = (Width / 9.0F) + diff;
                    float y = (Height / 9.0F) + diff;
                    e.Graphics.FillEllipse(brush, x, y, size, size);
                    e.Graphics.RotateTransform(angle * (int)_rotation);
                }
            }

            e.Graphics.Restore(oldState);

            string percent = GetDrawText();

            if (!string.IsNullOrEmpty(percent))
            {
                SizeF textSize = e.Graphics.MeasureString(percent, Font);
                float textX = (Width / 2.0F) - (textSize.Width / 2.0F);
                float textY = (Height / 2.0F) - (textSize.Height / 2.0F);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                RectangleF rectangle = new RectangleF(textX, textY, textSize.Width, textSize.Height);


                using (SolidBrush textBrush = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(percent, Font, textBrush, rectangle, format);
                }
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Resize" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            SetNewSize();
            base.OnResize(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            SetNewSize();
            base.OnSizeChanged(e);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the draw text.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetDrawText()
        {
            string percent = string.Format(CultureInfo.CurrentCulture, "{0:0.##} %", _percentage);

            if (_showText && _showPercentage)
                return string.Format("{0}{1}{2}", percent, Environment.NewLine, Text);

            if (_showText)
                return Text;

            if (_showPercentage)
                return percent;

            return string.Empty;
        }

        /// <summary>
        /// Sets the new size.
        /// </summary>
        private void SetNewSize()
        {
            int size = System.Math.Max(Width, Height);
            Size = new Size(size, size);
        }

        /// <summary>
        /// Increases the value.
        /// </summary>
        private void IncreaseValue()
        {
            if (_value + 1 <= _numberOfCircles)
                _value++;
            else
                _value = 1;
        }

        #endregion

        #region Timer

        /// <summary>
        /// Handles the Tick event of the timerAnimation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                IncreaseValue();
                Invalidate();
            }

            if (DesignMode)
            {
                IncreaseValue();
                Invalidate();
            }
        }

        #endregion
    }

    #endregion

    #region RotationType1
    /// <summary>
    /// An enum used to indicate the rotational direction of the <c><see cref="ZeroitProgressBarPerfect" /></c> control.
    /// </summary>
    public enum RotationType1
    {
        /// <summary>
        /// Indicates that the rotation should move clockwise.
        /// </summary>
        Clockwise = 1,
        /// <summary>
        /// Indicates that the rotation should move counter-clockwise.
        /// </summary>
        CounterClockwise = -1,
    }
    #endregion

    #region TextDisplayModes1
    /// <summary>
    /// This enum is used to choose what text should be shown in the of the <c><see cref="ZeroitProgressBarPerfect" /></c> control.
    /// </summary>
    [Flags]
    public enum TextDisplayModes1
    {
        /// <summary>
        /// No text will be shown by the control.
        /// </summary>
        None = 0,

        /// <summary>
        /// The control will show the value of the Percentage property.
        /// </summary>
        Percentage = 1,

        /// <summary>
        /// The control will show the value of the Text property.
        /// </summary>
        Text = 2,

        /// <summary>
        /// The control will show the values of the Text and Percentage properties.
        /// </summary>
        Both = Percentage | Text
    }
    #endregion

    #region ProgressIndicator.designer.cs
    partial class ZeroitProgressBarPerfect
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
            this.components = new System.ComponentModel.Container();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // ProgressIndicator
            // 
            this.Size = new System.Drawing.Size(90, 90);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The timer animation
        /// </summary>
        private System.Windows.Forms.Timer timerAnimation;
    }

    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarPerfectDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarPerfectDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarPerfectSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarPerfectSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarPerfectSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarPerfect colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarPerfectSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarPerfectSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarPerfect;

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
        /// Gets or sets the color of the circle.
        /// </summary>
        /// <value>The color of the circle.</value>
        public Color CircleColor
        {
            get
            {
                return colUserControl.CircleColor;
            }
            set
            {
                GetPropertyByName("CircleColor").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [automatic start].
        /// </summary>
        /// <value><c>true</c> if [automatic start]; otherwise, <c>false</c>.</value>
        public bool AutoStart
        {
            get
            {
                return colUserControl.AutoStart;
            }
            set
            {
                GetPropertyByName("AutoStart").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the size of the circle.
        /// </summary>
        /// <value>The size of the circle.</value>
        public float CircleSize
        {
            get
            {
                return colUserControl.CircleSize;
            }
            set
            {
                GetPropertyByName("CircleSize").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the animation speed.
        /// </summary>
        /// <value>The animation speed.</value>
        public int AnimationSpeed
        {
            get
            {
                return colUserControl.AnimationSpeed;
            }
            set
            {
                GetPropertyByName("AnimationSpeed").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the number of circles.
        /// </summary>
        /// <value>The number of circles.</value>
        public int NumberOfCircles
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
        /// Gets or sets the number of visible circles.
        /// </summary>
        /// <value>The number of visible circles.</value>
        public int NumberOfVisibleCircles
        {
            get
            {
                return colUserControl.NumberOfVisibleCircles;
            }
            set
            {
                GetPropertyByName("NumberOfVisibleCircles").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public RotationType1 Rotation
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
        /// Gets or sets the percentage.
        /// </summary>
        /// <value>The percentage.</value>
        public float Percentage
        {
            get
            {
                return colUserControl.Percentage;
            }
            set
            {
                GetPropertyByName("Percentage").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return colUserControl.Text;
            }
            set
            {
                GetPropertyByName("Text").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [show percentage].
        /// </summary>
        /// <value><c>true</c> if [show percentage]; otherwise, <c>false</c>.</value>
        public bool ShowPercentage
        {
            get
            {
                return colUserControl.ShowPercentage;
            }
            set
            {
                GetPropertyByName("ShowPercentage").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [show text].
        /// </summary>
        /// <value><c>true</c> if [show text]; otherwise, <c>false</c>.</value>
        public bool ShowText
        {
            get
            {
                return colUserControl.ShowText;
            }
            set
            {
                GetPropertyByName("ShowText").SetValue(colUserControl, value);
            }
        }
        /// <summary>
        /// Gets or sets the text display.
        /// </summary>
        /// <value>The text display.</value>
        public TextDisplayModes1 TextDisplay
        {
            get
            {
                return colUserControl.TextDisplay;
            }
            set
            {
                GetPropertyByName("TextDisplay").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("CircleColor",
                                 "Circle Color", "Appearance",
                                 "Sets the color of the circle."));

            items.Add(new DesignerActionPropertyItem("AutoStart",
                                 "Auto Start", "Appearance",
                                 "Automatically start the animation on Form load."));

            items.Add(new DesignerActionPropertyItem("CircleSize",
                                 "Circle Size", "Appearance",
                                 "Sets the size of the circle."));

            items.Add(new DesignerActionPropertyItem("AnimationSpeed",
                                 "Animation Speed", "Appearance",
                                 "Sets the speed of the animation."));

            items.Add(new DesignerActionPropertyItem("NumberOfCircles",
                                 "Number Of Circles", "Appearance",
                                 "Sets the number of circles."));

            items.Add(new DesignerActionPropertyItem("NumberOfVisibleCircles",
                                 "Number Of Visible Circles", "Appearance",
                                 "Sets the number of visible circles."));

            items.Add(new DesignerActionPropertyItem("Rotation",
                                 "Rotation", "Appearance",
                                 "Sets the Rotation type of the progress."));

            items.Add(new DesignerActionPropertyItem("Percentage",
                                 "Percentage", "Appearance",
                                 "Sets the Percentage text of the control."));

            items.Add(new DesignerActionPropertyItem("Text",
                                 "Text", "Appearance",
                                 "Sets the Text of the control."));

            items.Add(new DesignerActionPropertyItem("ShowPercentage",
                                 "Show Percentage", "Appearance",
                                 "Indicates whether the Percentage should be shown."));

            items.Add(new DesignerActionPropertyItem("ShowText",
                                 "Show Text", "Appearance",
                                 "Indicates whether the text should be shown."));

            items.Add(new DesignerActionPropertyItem("TextDisplay",
                                 "Text Display", "Appearance",
                                 "Sets the text display mode."));

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
