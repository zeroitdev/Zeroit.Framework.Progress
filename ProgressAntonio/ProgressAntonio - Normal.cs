// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-27-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 12-30-2017
// ***********************************************************************
// <copyright file="ProgressAntonio.cs" company="Zeroit Dev Technologies">
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
    #region ZeroitProgressBarNormal

    #region Control

    /// <summary>
    /// Class ZeroitProgressNormalResourceFinder.
    /// </summary>
    internal class ZeroitProgressNormalResourceFinder
    {

    }

    //]
    //[ToolboxItem("gfdsgdf"), ToolboxBitmap(typeof(ProgressBar), "System.Windows.Forms.ProgressBar.bmp")]

    /// <summary>
    /// A class collection for rendering a progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    [ToolboxBitmap(typeof(ZeroitProgressNormalResourceFinder), "System.Windows.Forms.ProgressBar.bmp")]
    [Designer(typeof(ZeroitProgressBarNormalDesigner))]
    public class ZeroitProgressBarNormal : System.Windows.Forms.Control
    {

        #region Include in Private Field

        /// <summary>
        /// The interval
        /// </summary>
        private int interval = 100;
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
        /// Gets or sets the animation interval.
        /// </summary>
        /// <value>The animation interval.</value>
        public int AnimationInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether automatically animate this control.
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


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarNormal"/> class.
        /// </summary>
        public ZeroitProgressBarNormal()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            BackColor = Color.Transparent;

            _Minimum = 0;
            _Maximum = 100;
            _Step = 5;
            _TurnOffInvalidation = false;
            _DisplayProgress = false;
            _BorderType = BorderTypes.Single;
            _TextAlign = TextAlignmentTypes.Center;
            _TextColorType = TextColorTypes.Automatic;
            _RollBlockPercent = 20;
            _RollingType = RollingTypes.None;


            _TurnOffInvalidation = true;
            ColorProgress = Color.Blue;
            _TurnOffInvalidation = true;
            BorderColor = Color.Black;
            _TurnOffInvalidation = true;
            BackColor = Color.White;
            _TurnOffInvalidation = true;
            ForeColor = Color.White;
            Value = 50;
            Size = new Size(100, 20);
            RollTimer = 200;

            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    //timer.Interval = interval;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    //timer.Interval = interval;
                    timer.Start();
                }
            }



            #endregion
        }
        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                xBrushes.DisposeAll();
                xPens.DisposeAll();
            }
            base.Dispose(disposing);
        }


        #region Drawing

        /// <summary>
        /// The x brushes
        /// </summary>
        protected BrushTable xBrushes = new BrushTable();
        /// <summary>
        /// The x pens
        /// </summary>
        protected PenTable xPens = new PenTable();
        /// <summary>
        /// Prepare2s the parts.
        /// </summary>
        /// <returns>Rectangle[].</returns>
        protected Rectangle[] Prepare2Parts()
        {
            return Zeroit.Framework.Progress.Drawing.MyRectangle.SplitByPercent(ClientRectangle, new int[] { _iPercent, 100 - _iPercent }, Zeroit.Framework.Progress.Drawing.MyRectangle.SplitType.Horizontal);
        }
        /// <summary>
        /// Prepare3s the parts.
        /// </summary>
        /// <returns>Rectangle[].</returns>
        protected Rectangle[] Prepare3Parts()
        {
            Rectangle xRec = ClientRectangle;
            int MiddleWidth = Progress.Math.MyMaths.Percent(xRec.Width, _RollBlockPercent);
            xRec.Inflate(MiddleWidth, 0);
            int Left = Progress.Math.MyMaths.Percent(ClientRectangle.Width + MiddleWidth, _iPercent);
            int Right = xRec.Width - -MiddleWidth - Left;
            return Progress.Drawing.MyRectangle.SplitByPixels(xRec, new int[] { Left, MiddleWidth, Right }, Zeroit.Framework.Progress.Drawing.MyRectangle.SplitType.Horizontal);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            timer.Interval = interval;
            Graphics g = e.Graphics;
            if (_RollingType == RollingTypes.None)
                DrawBackground(g);
            else
                DrawBackgroundRolling(g);
            if (_RollingType == RollingTypes.None)
                DrawText(g);
            DrawBorder(g);
            g.Dispose();

        }
        /// <summary>
        /// Draws the background rolling.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawBackgroundRolling(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
            }
            Rectangle[] xRecs = Prepare3Parts();
            FillRectangle(g, xRecs[1], xBrushes[BrushProgress]);

        }
        /// <summary>
        /// Draws the background.
        /// </summary>
        /// <param name="g">The g.</param>
        protected virtual void DrawBackground(Graphics g)
        {
            if (_iPercent == 0)
            {
                FillRectangle(g, ClientRectangle, xBrushes[BrushBackGround]);
                //return;
            }
            Rectangle[] xRecs = null;
            xRecs = Prepare2Parts();
            Rectangle xRectLeft = xRecs[0];
            Rectangle xRectRight = xRecs[1];
            FillRectangle(g, xRectLeft, xBrushes[BrushProgress]);
            //BrushAndFill(g, xRectLeft, ColorProgress);
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="g">The g.</param>
        protected void DrawText(Graphics g)
        {
            if (!_DisplayProgress || _RollingType != RollingTypes.None)
                return;
            string sProgress = _iPercent.ToString() + "%";
            StringFormat xFormat = new StringFormat();
            xFormat.LineAlignment = StringAlignment.Center;
            xFormat.Alignment = StringAlignment.Center;
            Rectangle TextRect = ClientRectangle;
            Color TextColor = ForeColor;
            Rectangle[] xRecs = Prepare2Parts();
            switch (_TextAlign)
            {
                case TextAlignmentTypes.Start:
                    TextRect = xRecs[0];
                    TextColor = Zeroit.Framework.Progress.Drawing.MyColor.GetBestContrast(_ColorProgress);
                    break;
                case TextAlignmentTypes.Center:
                    if (_iPercent > 50)
                        TextColor = Zeroit.Framework.Progress.Drawing.MyColor.GetBestContrast(_ColorProgress);
                    else
                        TextColor = Zeroit.Framework.Progress.Drawing.MyColor.GetBestContrast(BackColor);
                    TextRect = ClientRectangle;
                    break;
                case TextAlignmentTypes.End:
                    TextRect = xRecs[1];
                    TextColor = Zeroit.Framework.Progress.Drawing.MyColor.GetBestContrast(BackColor);
                    break;
            }
            if (_TextColorType == TextColorTypes.Specific)
                TextColor = ForeColor;
            if (Progress.Drawing.MySize.Compare(g.MeasureString(sProgress, Font).ToSize(), TextRect.Size) == Progress.Drawing.MySize.CompareOutputTypes.Smaller)
                g.DrawString(sProgress, Font, new SolidBrush(TextColor), TextRect, xFormat);
        }
        /// <summary>
        /// Draws the border.
        /// </summary>
        /// <param name="g">The g.</param>
        private void DrawBorder(Graphics g)
        {
            switch (_BorderType)
            {
                case BorderTypes.None:
                    break;
                case BorderTypes.Single:
                    g.DrawLines(xPens[PenBorder], Zeroit.Framework.Progress.Drawing.MyRectangle.PathAround(ClientRectangle));
                    break;
            }
        }
        /// <summary>
        /// Fills the rectangle.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="xRec">The x record.</param>
        /// <param name="xBrush">The x brush.</param>
        protected void FillRectangle(Graphics g, Rectangle xRec, Brush xBrush)
        {
            if (xRec.Width == 0)
                return;
            if (xBrush == null)
                return;
            g.FillRectangle(xBrush, xRec);
        }
        #endregion

        #region Values
        /// <summary>
        /// The minimum
        /// </summary>
        private int _Minimum;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum.</value>
        /// <exception cref="ArgumentOutOfRangeException">Minimum - Cannot be more than Maximum</exception>
        [Description("Minimum Value"), Category("Progress")]
        public int Minimum
        {
            get
            {
                return _Minimum;
            }
            set
            {
                if (value >= _Maximum)
                    throw new ArgumentOutOfRangeException("Minimum", "Cannot be more than Maximum");
                _Minimum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The maximum
        /// </summary>
        private int _Maximum;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum.</value>
        /// <exception cref="ArgumentOutOfRangeException">Maximum - Cannot be less than Minimum</exception>
        [Description("Maximum Value"), Category("Progress")]
        public int Maximum
        {
            get
            {
                return _Maximum;
            }
            set
            {
                if (value <= _Minimum)
                    throw new ArgumentOutOfRangeException("Maximum", "Cannot be less than Minimum");
                _Maximum = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The step
        /// </summary>
        private int _Step;
        /// <summary>
        /// Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        [Description("Step Value"), Category("Progress")]
        public int Step
        {
            get
            {
                return _Step;
            }
            set
            {
                _Step = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The turn off invalidation
        /// </summary>
        protected bool _TurnOffInvalidation;
        /// <summary>
        /// Invalidates the entire surface of the control and causes the control to be redrawn.
        /// </summary>
        protected new void Invalidate()
        {
            if (!_TurnOffInvalidation)
                base.Invalidate();
            _TurnOffInvalidation = false;
        }

        /// <summary>
        /// The value
        /// </summary>
        private int _Value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="ArgumentOutOfRangeException">Value - Must be between Minimum and Maximum</exception>
        [Description("Value Value"), Category("Progress")]
        public virtual int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                int Temp = _iPercent;
                if (value < _Minimum || value > _Maximum)
                    throw new ArgumentOutOfRangeException("Value", "Must be between Minimum and Maximum");
                _Value = value;
                float Range = _Maximum - _Minimum;
                _fPercent = 100 * (((float)_Value) / Range);
                _iPercent = (int)System.Math.Ceiling(_fPercent);
                if (_iPercent == Temp)
                    _TurnOffInvalidation = true;
                Invalidate();
            }
        }
        /// <summary>
        /// Performs Value Calculation based on Minimum,Maximum and Step
        /// </summary>
        public void PerformStep()
        {
            if (_Value + _Step <= _Maximum && _Value + _Step >= _Minimum)
            {
                Value += _Step;
                return;
            }
            if (_RollingType == RollingTypes.None)
                return;
            if (_RollingType == RollingTypes.Bouncing)
            {
                _Step = -Step;
                PerformStep();
                return;
            }
            if (_RollingType == RollingTypes.EdgeToEdge)
            {
                if (_Value + _Step > _Maximum)
                    Value += _Step - (_Maximum - _Minimum);
            }
        }

        /// <summary>
        /// The i percent
        /// </summary>
        protected int _iPercent = 0;
        /// <summary>
        /// The f percent
        /// </summary>
        protected float _fPercent = 0;

        #endregion

        #region ProgressApearance
        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <value>The color of the back.</value>
        [Description("Back Color"), Category("ProgressApearance")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                xBrushes[BrushBackGround] = new SolidBrush(value);
                base.BackColor = value;
            }
        }
        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <value>The color of the fore.</value>
        [Description("Text Color"), Category("ProgressApearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                xBrushes[BrushText] = new SolidBrush(value);
                base.ForeColor = value;
            }
        }
        /// <summary>
        /// The display progress
        /// </summary>
        private bool _DisplayProgress;
        /// <summary>
        /// Gets or sets a value indicating whether [display progress].
        /// </summary>
        /// <value><c>true</c> if [display progress]; otherwise, <c>false</c>.</value>
        [Description("Display Progress Percentage"), Category("ProgressApearance")]
        public virtual bool DisplayProgress
        {
            get
            {
                return _DisplayProgress;
            }
            set
            {
                _DisplayProgress = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The brush progress
        /// </summary>
        protected const string BrushProgress = "BrushProgress";
        /// <summary>
        /// The brush back ground
        /// </summary>
        protected const string BrushBackGround = "BrushBackGround";
        /// <summary>
        /// The brush text
        /// </summary>
        protected const string BrushText = "BrushText";
        /// <summary>
        /// The pen border
        /// </summary>
        protected const string PenBorder = "PenBorder";

        /// <summary>
        /// The color progress
        /// </summary>
        protected Color _ColorProgress;
        /// <summary>
        /// Gets or sets the color progress.
        /// </summary>
        /// <value>The color progress.</value>
        [Description("Fill Color Start"), Category("ProgressApearance")]
        public Color ColorProgress
        {
            get
            {
                return _ColorProgress;
            }
            set
            {
                _ColorProgress = value;
                xBrushes[BrushProgress] = new SolidBrush(_ColorProgress);
                Invalidate();
            }
        }

        /// <summary>
        /// The text color type
        /// </summary>
        private TextColorTypes _TextColorType;
        /// <summary>
        /// Gets or sets the type of the text color.
        /// </summary>
        /// <value>The type of the text color.</value>
        [Description("Percent Text Color Type"), Category("ProgressApearance")]
        public virtual TextColorTypes TextColorType
        {
            get
            {
                return _TextColorType;
            }
            set
            {
                _TextColorType = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The text align
        /// </summary>
        private TextAlignmentTypes _TextAlign;
        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        [Description("Percent Text Align"), Category("ProgressApearance")]
        public virtual TextAlignmentTypes TextAlign
        {
            get
            {
                return _TextAlign;
            }
            set
            {
                _TextAlign = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The border type
        /// </summary>
        private BorderTypes _BorderType;
        /// <summary>
        /// Gets or sets the type of the border.
        /// </summary>
        /// <value>The type of the border.</value>
        [Description("Border Type"), Category("ProgressApearance")]
        public BorderTypes BorderType
        {
            get
            {
                return _BorderType;
            }
            set
            {
                _BorderType = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The border color
        /// </summary>
        private Color _BorderColor;
        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [Description("Border Color"), Category("ProgressApearance")]
        public Color BorderColor
        {
            get
            {
                return _BorderColor;
            }
            set
            {
                xPens[PenBorder] = new Pen(value, 1);
                _BorderColor = value;
                Invalidate();
            }
        }


        #endregion

        #region Rolling
        /*
        private Bitmap[] _RollImage = new Bitmap[100];
        private void PrepareRollImages()
        {
            int OriginalPercent=_iPercent;
            for(int i=0;i<100;i++)
            {
                if (_RollImage[i] == null)
                    _RollImage = new Bitmap(10, 10);
                Graphics g=Graphics.FromImage(_RollImage[i]);
                BrushAndFill(g, _RollImage[i].GetBounds(GraphicsUnit.Pixel));
                _iPercent=i;
                Rectangle[] xRecs = Prepare4Parts();
                if (_ProgressBarType == ProgressBarTypes.Simple)
                {
                    BrushAndFill(g, xRecs[1], _ColorStart);
                    BrushAndFill(g, xRecs[2], _ColorStart);
                }
                if (_ProgressBarType == ProgressBarTypes.SpecificWidthGradient || _ProgressBarType == ProgressBarTypes.FullWidthGradient)
                {
                    xRecs[1].Width++;
                    BrushAndFill(g, xRecs[2], _ColorStart, _ColorEnd);
                    BrushAndFill(g, xRecs[1], _ColorEnd, _ColorStart);
                }
                g.Dispose();
            }
        }
        */
        /// <summary>
        /// The roll block percent
        /// </summary>
        private int _RollBlockPercent;
        /// <summary>
        /// Gets or sets the roll block percent.
        /// </summary>
        /// <value>The roll block percent.</value>
        /// <exception cref="ArgumentOutOfRangeException">RollBlockPercent - Must be between 10 and 90</exception>
        [Description("Middle Percentage of Control"), Category("Rolling")]
        public virtual int RollBlockPercent
        {
            get
            {
                return _RollBlockPercent;
            }
            set
            {
                if (value < 10 || value > 90)
                    throw new ArgumentOutOfRangeException("RollBlockPercent", "Must be between 10 and 90");
                _RollBlockPercent = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The rolling type
        /// </summary>
        private RollingTypes _RollingType;
        /// <summary>
        /// Gets or sets the type of the rolling.
        /// </summary>
        /// <value>The type of the rolling.</value>
        [Description("Rolling Type"), Category("Rolling")]
        public virtual RollingTypes RollingType
        {
            get
            {
                return _RollingType;
            }
            set
            {
                _RollingType = value;
                if (value == RollingTypes.None)
                {
                    RollStop();
                    Step = System.Math.Abs(Step);
                }
                else
                {
                    //throw new ArgumentException("Not Supported");
                    _Minimum = 0;
                    _Maximum = 100;
                    Value = 0;
                    //_RollImage.
                }
                Invalidate();
            }
        }
        /// <summary>
        /// The roll timer
        /// </summary>
        private System.Windows.Forms.Timer _RollTimer = new System.Windows.Forms.Timer();
        /// <summary>
        /// Gets or sets the roll timer.
        /// </summary>
        /// <value>The roll timer.</value>
        [Description("Rolling Interval"), Category("Rolling")]
        public virtual int RollTimer
        {
            get
            {
                return _RollTimer.Interval;
            }
            set
            {
                _RollTimer.Interval = value;
            }
        }
        /// <summary>
        /// Rolls the start.
        /// </summary>
        public void RollStart()
        {
            _RollTimer.Start();
        }
        /// <summary>
        /// Rolls the stop.
        /// </summary>
        public void RollStop()
        {
            _RollTimer.Stop();
        }
        /// <summary>
        /// Handles the Tick event of the _RollTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void _RollTimer_Tick(object sender, EventArgs e)
        {
            if (_Value >= _Maximum)
                if (_RollingType == RollingTypes.EdgeToEdge)
                    _Value = _Minimum;
                else
                    Step = -Step;
            PerformStep();
        }
        #endregion
    }


    /// <summary>
    /// Enum that represents Text Color Types
    /// </summary>
    public enum TextColorTypes
    {
        /// <summary>
        /// The specific
        /// </summary>
        Specific,
        /// <summary>
        /// The automatic
        /// </summary>
        Automatic
    }

    /// <summary>
    /// Enum that represents Text Alignment Types
    /// </summary>
    public enum TextAlignmentTypes
    {
        /// <summary>
        /// The start
        /// </summary>
        Start,
        /// <summary>
        /// The center
        /// </summary>
        Center,
        /// <summary>
        /// The end
        /// </summary>
        End
    }
    /// <summary>
    /// Enum that represents Border Types
    /// </summary>
    public enum BorderTypes
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The single
        /// </summary>
        Single
    }

    /// <summary>
    /// Enum that represents Rolling Types
    /// </summary>
    public enum RollingTypes
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The edge to edge
        /// </summary>
        EdgeToEdge,
        /// <summary>
        /// The bouncing
        /// </summary>
        Bouncing
    }
    #endregion

    #region Smart Tag Code

    #region Cut and Paste it on top of the component class

    //--------------- [Designer(typeof(myControlDesigner))] --------------------//
    #endregion

    #region ControlDesigner
    /// <summary>
    /// Class ZeroitProgressBarNormalDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressBarNormalDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressBarNormalSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressBarNormalSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressBarNormalSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressBarNormal colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressBarNormalSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressBarNormalSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressBarNormal;

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
        /// Gets or sets the animation interval.
        /// </summary>
        /// <value>The animation interval.</value>
        public int AnimationInterval
        {
            get
            {
                return colUserControl.AnimationInterval;
            }
            set
            {
                GetPropertyByName("AnimationInterval").SetValue(colUserControl, value);
            }
        }


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
        /// Gets or sets the step.
        /// </summary>
        /// <value>The step.</value>
        public int Step
        {
            get
            {
                return colUserControl.Step;
            }
            set
            {
                GetPropertyByName("Step").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public virtual int Value
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
        /// Gets or sets a value indicating whether [display progress].
        /// </summary>
        /// <value><c>true</c> if [display progress]; otherwise, <c>false</c>.</value>
        public virtual bool DisplayProgress
        {
            get
            {
                return colUserControl.DisplayProgress;
            }
            set
            {
                GetPropertyByName("DisplayProgress").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color progress.
        /// </summary>
        /// <value>The color progress.</value>
        public Color ColorProgress
        {
            get
            {
                return colUserControl.ColorProgress;
            }
            set
            {
                GetPropertyByName("ColorProgress").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the text color.
        /// </summary>
        /// <value>The type of the text color.</value>
        public virtual TextColorTypes TextColorType
        {
            get
            {
                return colUserControl.TextColorType;
            }
            set
            {
                GetPropertyByName("TextColorType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the text align.
        /// </summary>
        /// <value>The text align.</value>
        public virtual TextAlignmentTypes TextAlign
        {
            get
            {
                return colUserControl.TextAlign;
            }
            set
            {
                GetPropertyByName("TextAlign").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the border.
        /// </summary>
        /// <value>The type of the border.</value>
        public BorderTypes BorderType
        {
            get
            {
                return colUserControl.BorderType;
            }
            set
            {
                GetPropertyByName("BorderType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get
            {
                return colUserControl.BorderColor;
            }
            set
            {
                GetPropertyByName("BorderColor").SetValue(colUserControl, value);
            }
        }


        #endregion

        #region Rolling
        /// <summary>
        /// Gets or sets the roll block percent.
        /// </summary>
        /// <value>The roll block percent.</value>
        public virtual int RollBlockPercent
        {
            get
            {
                return colUserControl.RollBlockPercent;
            }
            set
            {
                GetPropertyByName("RollBlockPercent").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the rolling.
        /// </summary>
        /// <value>The type of the rolling.</value>
        public virtual RollingTypes RollingType
        {
            get
            {
                return colUserControl.RollingType;
            }
            set
            {
                GetPropertyByName("RollingType").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the roll timer.
        /// </summary>
        /// <value>The roll timer.</value>
        public virtual int RollTimer
        {
            get
            {
                return colUserControl.RollTimer;
            }
            set
            {
                GetPropertyByName("RollTimer").SetValue(colUserControl, value);
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

            items.Add(new DesignerActionPropertyItem("AutoAnimate",
                                 "Auto Animate", "Appearance",
                                 "Automatically animates the control."));

            items.Add(new DesignerActionPropertyItem("DisplayProgress",
                                 "Display Progress", "Appearance",
                                 "Shows the progress percentage."));

            items.Add(new DesignerActionPropertyItem("AnimationInterval",
                                 "Animation Interval", "Appearance",
                                 "Sets the animation speed."));

            items.Add(new DesignerActionPropertyItem("RollTimer",
                                 "Roll Timer", "Appearance",
                                 "Sets the roll timer."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Selects the background color."));

            items.Add(new DesignerActionPropertyItem("ForeColor",
                                 "Fore Color", "Appearance",
                                 "Selects the foreground color."));

            items.Add(new DesignerActionPropertyItem("Minimum",
                                 "Minimum", "Appearance",
                                 "Sets the minimum value."));

            items.Add(new DesignerActionPropertyItem("Maximum",
                                 "Maximum", "Appearance",
                                 "Sets the maximum value."));

            items.Add(new DesignerActionPropertyItem("Step",
                                 "Step", "Appearance",
                                 "Sets the step of the control."));

            items.Add(new DesignerActionPropertyItem("Value",
                                 "Value", "Appearance",
                                 "Sets the value of the progress."));

            items.Add(new DesignerActionPropertyItem("ColorProgress",
                                 "Color Progress", "Appearance",
                                 "Sets the color of the progress."));

            items.Add(new DesignerActionPropertyItem("TextColorType",
                                 "Text Color Type", "Appearance",
                                 "Sets the color of the text."));

            items.Add(new DesignerActionPropertyItem("TextAlign",
                                 "Text Align", "Appearance",
                                 "Sets the text alignment of the control."));

            items.Add(new DesignerActionPropertyItem("BorderType",
                                 "Border Type", "Appearance",
                                 "Sets the type of border."));

            items.Add(new DesignerActionPropertyItem("BorderColor",
                                 "Border Color", "Appearance",
                                 "Sets the border color."));

            items.Add(new DesignerActionPropertyItem("RollBlockPercent",
                                 "Roll Block Percent", "Appearance",
                                 "Sets the roll block percentage."));

            items.Add(new DesignerActionPropertyItem("RollingType",
                                 "Rolling Type", "Appearance",
                                 "Sets the type of rolling to use for the control."));



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
