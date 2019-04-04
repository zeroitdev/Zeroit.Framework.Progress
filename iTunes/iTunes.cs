// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="iTunes.cs" company="Zeroit Dev Technologies">
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
using System.Drawing.Imaging;
using System.Text;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region ITunes

    #region Control
    /// <summary>
    /// This enum represents the diffrent states the control can take.
    /// Animation for ex. makes the procent bar "Rubber band" to the new procent value
    /// </summary>
	public enum BarType
    {
        /// <summary>
        /// Plain and simple bar with procent display.
        /// </summary>
        Static,         // Plain and simple bar with procent display
        /// <summary>
        /// This makes the control act as a progressbar.
        /// </summary>
        Progressbar,    // This makes the control act as a progressbar
        /// <summary>
        /// his makes the control "Rubber band" to new procent values (Animated).
        /// </summary>
        Animated        // This makes the control "Rubber band" to new procent values (Animated).
    };

    /// <summary>
    /// A delegate to be able to trigger value changed event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void BarValueChanged(object sender, EventArgs e);

    /// <summary>
    /// A class collection for rendering an iTunes look-a-like bar for displaying various data.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ProgressBar))]
    [Designer(typeof(ZeroitProgressITunesBarDesigner))]
    public partial class ZeroitProgressITunesBar : UserControl
    {

        #region Static Members
        /// <summary>
        /// The pre bar base dark
        /// </summary>
        public static readonly Color PreBarBaseDark = Color.FromArgb(199, 200, 201);
        /// <summary>
        /// The pre bar base light
        /// </summary>
        public static readonly Color PreBarBaseLight = Color.WhiteSmoke;
        /// <summary>
        /// The pre bar light
        /// </summary>
        public static readonly Color PreBarLight = Color.FromArgb(102, 144, 252);
        /// <summary>
        /// The pre bar dark
        /// </summary>
        public static readonly Color PreBarDark = Color.FromArgb(40, 68, 202);
        /// <summary>
        /// The pre border color
        /// </summary>
        public static readonly Color PreBorderColor = Color.DarkGray;
        #endregion

        #region Private Members
        /// <summary>
        /// The Light background color
        /// </summary>
        private Color clrBarBgLight = PreBarBaseLight;

        /// <summary>
        /// The Dark background color
        /// </summary>
        private Color clrBarBgDark = PreBarBaseDark;

        /// <summary>
        /// The Light bar color
        /// </summary>
        private Color clrBarLight = PreBarLight;

        /// <summary>
        /// The Dark bar color
        /// </summary>
        private Color clrBarDark = PreBarDark;

        /// <summary>
        /// The Border color for the control
        /// </summary>
        private Color clrBorderColor = PreBorderColor;

        /// <summary>
        /// The border width
        /// </summary>
        private float fBorderWidth = 1.25F;

        /// <summary>
        /// This is the % value that describs the amount of transparency
        /// through the background that we will show.
        /// </summary>
        private float fMirrorOpacity = 40.0F;

        /// <summary>
        /// This is the % value that will be filled in the bar
        /// </summary>
        private float fFillProcent = 50.0F;

        /// <summary>
        /// The number of dividers to draw in the bar
        /// </summary>
        private int iNumDividers = 10;

        /// <summary>
        /// A timer to enable progressbar feature
        /// </summary>
        private System.Windows.Forms.Timer tTickTimer = new System.Windows.Forms.Timer();

        /// <summary>
        /// The stepsize to use when the control is a progressbar
        /// </summary>
        private float iStepSize = 0;

        /// <summary>
        /// A member to control the way the bar behaves
        /// </summary>
        private BarType eBarType = BarType.Static;

        /// <summary>
        /// The timer to handle the progress tick event
        /// </summary>
        private System.Windows.Forms.Timer tAnimTicker = new System.Windows.Forms.Timer();

        /// <summary>
        /// A value to save the new target procent when we are in Animation mode
        /// </summary>
        private float fNewProcent = 0.0F;

        /// <summary>
        /// A simple flag to indicate what way the control should animate it's progress when it's in Animation mode
        /// </summary>
        private bool bAnimUp = false;
        #endregion

        #region Events
        /// <summary>
        /// This event is to notify the user that the progress of the control has changed
        /// </summary>
        //public event BarValueChanged OnBarValueChanged = null;
        public event EventHandler<EventArgs> OnBarValueChanged = null;
        #endregion

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
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get { return interval; }
            set
            {
                interval = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate.
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
            if (this.BarFillProcent + 1 > 100)
                this.BarFillProcent = 0;
            else
                this.BarFillProcent++;
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressITunesBar" /> class.
        /// </summary>
        public ZeroitProgressITunesBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.ResizeRedraw, true);

            InitializeComponent();
            this.Width = 300;
            this.Height = 50;

            // Progressbar timer
            this.tTickTimer.Tick += new EventHandler(TickTimer_Tick);
            this.tTickTimer.Enabled = false;
            this.tTickTimer.Interval = 100;

            // Animation timer
            tAnimTicker.Enabled = false;
            tAnimTicker.Interval = 75;
            tAnimTicker.Tick += new EventHandler(AnimationTimer_Tick);


            //Zeroit Timer addition
            #region MyRegion
            if (DesignMode)
            {
                timer.Tick += Timer_Tick;
                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }

            if (!DesignMode)
            {
                timer.Tick += Timer_Tick;

                if (AutoAnimate)
                {
                    //timer.Interval = 100;
                    timer.Start();
                }
            }



            #endregion

        } // END CONSTRUCTOR: iBar( ... ) 

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the control rendered to a Bitmap.
        /// This method can be used in Web environment.
        /// </summary>
        /// <returns>Bitmap.</returns>
        public Bitmap ToImage()
        {
            Bitmap retVal = new Bitmap(this.Width, this.Height);
            Graphics g = Graphics.FromImage(retVal);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.BackColor);

            Bitmap bmp = GenerateProcentBar(this.Width, this.Height, this.fFillProcent, this.fMirrorOpacity, this.BackColor);
            g.DrawImage(bmp, 0, 0);

            g.Dispose();
            return retVal;

        } // END METHOD: ToImage( ... )
        #endregion

        /// <summary>
        /// Handles the Tick event of the TickTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void TickTimer_Tick(object sender, EventArgs e)
        {
            this.fFillProcent += this.iStepSize;
            if (this.fFillProcent >= 100.0F)
                this.fFillProcent = 0.0F;
            else if (this.fFillProcent < 0.0F)
                this.fFillProcent = 100.0F;

            Refresh();

            // Trigger event if any defined
            if (OnBarValueChanged != null)
                OnBarValueChanged(this, EventArgs.Empty);

        } // END METHOD: TickTimer_Tick( ... )

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            timer.Interval = interval;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(this.BackColor);

            Bitmap bmp = GenerateProcentBar(this.Width, this.Height, this.fFillProcent, this.fMirrorOpacity, this.BackColor);
            g.DrawImage(bmp, 0, 0);

        } // END METHOD: OnPaint( ... )

        /// <summary>
        /// Generates the bar.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="fillProcent">The fill procent.</param>
        private void GenerateBar(ref Graphics g, float x, float y,
                                  float width, float height, float fillProcent)
        {
            float procentMarkerWidth = (width / iNumDividers);
            float totalWidth = width;
            RectangleF rect = new RectangleF(x, y, width, height);

            using (LinearGradientBrush white = new LinearGradientBrush(rect, clrBarBgLight, clrBarBgDark, 90.0F, false))
            {
                g.FillRectangle(white, rect);

            } // END using( LinearGradientBrush white = new LinearGradientBrush( rect, clrBarBgLight, clrBarBgDark, 90.0F, false ) )

            using (Pen p = new Pen(this.clrBorderColor, this.fBorderWidth * 2))
            {
                p.Alignment = PenAlignment.Outset;
                p.LineJoin = LineJoin.Round;
                g.DrawRectangle(p, x, y, width, height);

            } // END using( Pen p = new Pen( this.clrBorderColor, this.fBorderWidth * 2 ) )

            width = (fillProcent > 0 ? ((fillProcent / 100) * width) : 0);
            if (width > 0.10F)
            {
                rect = new RectangleF(x, y, width, height);
                using (LinearGradientBrush bg = new LinearGradientBrush(rect, this.clrBarLight, this.clrBarDark, 90.0F, false))
                {
                    g.FillRectangle(bg, rect);

                } // END using( LinearGradientBrush bg = new LinearGradientBrush( rect, this.clrBarLight, this.clrBarDark, 90.0F, false ) )

                using (Pen p = new Pen(this.clrBorderColor, this.fBorderWidth))
                {
                    p.Alignment = PenAlignment.Inset;
                    p.LineJoin = LineJoin.Round;
                    g.DrawLine(p, width, y, width, height);

                } // END using( Pen p = new Pen( this.clrBorderColor, this.fBorderWidth ) )

            } // END if( width > 0 )

            using (Pen p = new Pen(this.clrBarDark, this.fBorderWidth))
            {
                p.Alignment = PenAlignment.Inset;
                p.LineJoin = LineJoin.Round;
                using (Pen p2 = new Pen(this.clrBarLight, this.fBorderWidth))
                {
                    p2.Alignment = PenAlignment.Inset;
                    p2.LineJoin = LineJoin.Round;
                    for (float i = procentMarkerWidth; i < totalWidth; i += procentMarkerWidth)
                    {
                        if (i >= width)
                        {
                            p.Color = clrBarBgLight;
                            p2.Color = clrBarBgDark;

                        } // END if( i >= width )

                        g.DrawLine(p, i, 0, i, height);
                        g.DrawLine(p2, i + this.fBorderWidth, 0, i + this.fBorderWidth, height);

                    } // END for( float i = procentMarkerWidth; i < totalWidth; i += procentMarkerWidth )

                } // END using( Pen p2 = new Pen( this.clrBarLight, this.fBorderWidth ) )

            } // END using( Pen p = new Pen( this.clrBarDark, this.fBorderWidth ) )

        } // END METHOD: GenerateBar( ... )

        /// <summary>
        /// Generates the bar image.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="procent">The procent.</param>
        /// <returns>Bitmap.</returns>
        private Bitmap GenerateBarImage(int width, int height, float procent)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);

            GenerateBar(ref g, 0.0F, 0.0F, width, height, procent);
            g.Dispose();

            return bmp;

        } // END METHOD: GenerateBarImage( ... )

        /// <summary>
        /// Makes the colors fade to the background.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="bgColor">Color of the bg.</param>
        /// <param name="angle">The angle.</param>
        /// <returns>Bitmap.</returns>
        private Bitmap FadeToBg(Bitmap image, Color bgColor, float angle)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.DrawImage(image, 0, 0);
            Rectangle source = new Rectangle(0, -1, bmp.Width, bmp.Height);
            using (LinearGradientBrush bg = new LinearGradientBrush(source, Color.Transparent, bgColor, angle, false))
            {
                g.FillRectangle(bg, source);

            } // END using( LinearGradientBrush bg = new LinearGradientBrush( source, Color.Transparent, bgColor, angle, false ) )

            g.Dispose();

            return bmp;

        } // END METHOD: FadeToBg( ... )

        /// <summary>
        /// Generates the procent bar.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="procent">The procent.</param>
        /// <param name="mirrorOpacity">The mirror opacity.</param>
        /// <param name="bgColor">Color of the bg.</param>
        /// <returns>Bitmap.</returns>
        private Bitmap GenerateProcentBar(int width, int height, float procent, float mirrorOpacity, Color bgColor)
        {
            Bitmap theImage = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(theImage);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(bgColor);

            Bitmap bmp = GenerateBarImage(width, height - (height / 3), procent);
            Bitmap mirror = FadeToBg(bmp, bgColor, -90.0F);
            GraphicsState state = g.Save();
            g.ScaleTransform(1, -1.0F, MatrixOrder.Prepend);

            ColorMatrix clr = new ColorMatrix();
            ImageAttributes attributes = new ImageAttributes();

            clr.Matrix33 = (mirrorOpacity / 100);
            attributes.SetColorMatrix(clr);

            Rectangle source = new Rectangle(0, -(height), mirror.Width, mirror.Height);
            g.DrawImage(mirror, source, 0, 0, mirror.Width, mirror.Height, GraphicsUnit.Pixel, attributes);

            g.Restore(state);
            g.DrawImage(bmp, 0, -5);

            g.Dispose();
            bmp.Dispose();
            mirror.Dispose();

            return theImage;

        } // END METHOD: GenerateProcentBar( ... )

        /// <summary>
        /// Makes the animation.
        /// </summary>
        /// <param name="newProcent">The new procent.</param>
        private void MakeAnimation(float newProcent)
        {
            fNewProcent = newProcent;
            bAnimUp = ((fFillProcent - newProcent) > 0);
            tAnimTicker.Interval = 1;
            tAnimTicker.Enabled = true;

        } // END METHOD: MakeAnimation( ... )

        /// <summary>
        /// Handles the Tick event of the AnimationTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            fFillProcent -= ((fFillProcent - fNewProcent) / 5.0F);
            tAnimTicker.Enabled = (!bAnimUp ? (fFillProcent <= fNewProcent) : (fFillProcent >= fNewProcent));

            Refresh();

        } // END METHOD: AnimationTimer_Tick( ... )


        #region Access Methods
        /// <summary>
        /// Gets or sets the size of the step.
        /// When this value is &gt; 0 the progressbar is enabled
        /// </summary>
        /// <value>The size of the step.</value>
        [System.ComponentModel.Description("Gets or sets the stepsize. This controls how many steps it will progress when making a move")]
        [System.ComponentModel.DefaultValue(2)]
        public float StepSize
        {
            get { return iStepSize; }
            set
            {
                iStepSize = value;
                this.tTickTimer.Enabled = (this.iStepSize != 0 && this.tTickTimer.Interval > 0 && eBarType == BarType.Progressbar);
            }
        }

        /// <summary>
        /// Gets or sets the step interval.
        /// This is the interval that determins how often the control
        /// is updated with it's step size
        /// </summary>
        /// <value>The step interval.</value>
        [System.ComponentModel.Description("Gets or sets the StepInterval. This value determins how ofthen the control is updated using the StepSize")]
        [System.ComponentModel.DefaultValue(5)]
        public int StepInterval
        {
            get { return tTickTimer.Interval; }
            set
            {
                tTickTimer.Interval = value;
                this.tTickTimer.Enabled = (this.iStepSize != 0 && this.tTickTimer.Interval > 0 && eBarType == BarType.Progressbar);
            }
        }

        /// <summary>
        /// Gets or sets the number of bar dividers to display.
        /// </summary>
        /// <value>The num bar dividers.</value>
        [System.ComponentModel.Description("Gets or sets how many dividers to display on the bar")]
        [System.ComponentModel.DefaultValue(10)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public int BarDividersCount
        {
            get { return iNumDividers; }
            set { iNumDividers = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the mirror opacity.
        /// </summary>
        /// <value>The mirror opacity.</value>
        [System.ComponentModel.Description("Gets or sets the opacity level for the reflecting part of the control")]
        [System.ComponentModel.DefaultValue(35.0f)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public float BarMirrorOpacity
        {
            get { return fMirrorOpacity; }
            set { fMirrorOpacity = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the fill procent.
        /// </summary>
        /// <value>The fill procent.</value>
        [System.ComponentModel.Description("Gets or sets the fill procent")]
        [System.ComponentModel.DefaultValue(50.0f)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public float BarFillProcent
        {
            get { return fFillProcent; }
            set
            {
                if (this.eBarType == BarType.Animated)
                {
                    MakeAnimation(value);
                    return;
                }

                fFillProcent = value;
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        [System.ComponentModel.Description("Gets or sets the with of the borders")]
        [System.ComponentModel.DefaultValue(1.0f)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public float BarBorderWidth
        {
            get { return fBorderWidth; }
            set { fBorderWidth = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the bar background light.
        /// </summary>
        /// <value>The bar background light.</value>
        [System.ComponentModel.Description("Gets or sets the lighter background color")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Color BarBackgroundLight
        {
            get { return clrBarBgLight; }
            set { clrBarBgLight = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the bar background dark.
        /// </summary>
        /// <value>The bar background dark.</value>
        [System.ComponentModel.Description("Gets or sets the darker background color")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Color BarBackgroundDark
        {
            get { return clrBarBgDark; }
            set { clrBarBgDark = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the bar light.
        /// </summary>
        /// <value>The bar light.</value>
        [System.ComponentModel.Description("Gets or sets the light bar color")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Color BarLight
        {
            get { return clrBarLight; }
            set { clrBarLight = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the bar dark.
        /// </summary>
        /// <value>The bar dark.</value>
        [System.ComponentModel.Description("Gets or sets the dark bar color")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Color BarDark
        {
            get { return clrBarDark; }
            set { clrBarDark = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        [System.ComponentModel.Description("Gets or sets the border color")]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public Color BarBorderColor
        {
            get { return clrBorderColor; }
            set { clrBorderColor = value; Refresh(); }
        }

        /// <summary>
        /// Gets or sets the type of the bar.
        /// </summary>
        /// <value>The type of the bar.</value>
        [System.ComponentModel.Description("Gets or sets the type. This changes the bahaviour of the control. See the BarType enum for specification")]
        [System.ComponentModel.DefaultValue(BarType.Animated)]
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        public BarType BarType
        {
            get { return eBarType; }
            set
            {
                eBarType = value;
                if (value != BarType.Progressbar)
                {
                    this.iStepSize = 0;
                    this.tTickTimer.Enabled = false;
                }
            }
        }
        #endregion

    } // END CLASS: iBar
    #endregion

    #region Designer Generated Code
    partial class ZeroitProgressITunesBar
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
            this.SuspendLayout();
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(422, 50);
            this.ResumeLayout(false);

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
    /// Class ZeroitProgressITunesBarDesigner.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Design.ControlDesigner" />
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ZeroitProgressITunesBarDesigner : System.Windows.Forms.Design.ControlDesigner
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
                    actionLists.Add(new ZeroitProgressITunesBarSmartTagActionList(this.Component));
                }
                return actionLists;
            }
        }
    }

    #endregion

    #region SmartTagActionList
    /// <summary>
    /// Class ZeroitProgressITunesBarSmartTagActionList.
    /// </summary>
    /// <seealso cref="System.ComponentModel.Design.DesignerActionList" />
    public class ZeroitProgressITunesBarSmartTagActionList : System.ComponentModel.Design.DesignerActionList
    {
        //Replace SmartTag with the Component Class Name. In this case the component class name is SmartTag
        /// <summary>
        /// The col user control
        /// </summary>
        private ZeroitProgressITunesBar colUserControl;


        /// <summary>
        /// The designer action UI SVC
        /// </summary>
        private DesignerActionUIService designerActionUISvc = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitProgressITunesBarSmartTagActionList"/> class.
        /// </summary>
        /// <param name="component">A component related to the <see cref="T:System.ComponentModel.Design.DesignerActionList" />.</param>
        public ZeroitProgressITunesBarSmartTagActionList(IComponent component) : base(component)
        {
            this.colUserControl = component as ZeroitProgressITunesBar;

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
        /// Gets or sets the timer interval.
        /// </summary>
        /// <value>The timer interval.</value>
        public int TimerInterval
        {
            get
            {
                return colUserControl.TimerInterval;
            }
            set
            {
                GetPropertyByName("TimerInterval").SetValue(colUserControl, value);
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

        #region Access Methods
        /// <summary>
        /// Gets or sets the size of the step.
        /// </summary>
        /// <value>The size of the step.</value>
        public float StepSize
        {
            get
            {
                return colUserControl.StepSize;
            }
            set
            {
                GetPropertyByName("StepSize").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the step interval.
        /// </summary>
        /// <value>The step interval.</value>
        public int StepInterval
        {
            get
            {
                return colUserControl.StepInterval;
            }
            set
            {
                GetPropertyByName("StepInterval").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar dividers count.
        /// </summary>
        /// <value>The bar dividers count.</value>
        public int BarDividersCount
        {
            get
            {
                return colUserControl.BarDividersCount;
            }
            set
            {
                GetPropertyByName("BarDividersCount").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar mirror opacity.
        /// </summary>
        /// <value>The bar mirror opacity.</value>
        public float BarMirrorOpacity
        {
            get
            {
                return colUserControl.BarMirrorOpacity;
            }
            set
            {
                GetPropertyByName("BarMirrorOpacity").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar fill procent.
        /// </summary>
        /// <value>The bar fill procent.</value>
        public float BarFillProcent
        {
            get
            {
                return colUserControl.BarFillProcent;
            }
            set
            {
                GetPropertyByName("BarFillProcent").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the width of the bar border.
        /// </summary>
        /// <value>The width of the bar border.</value>
        public float BarBorderWidth
        {
            get
            {
                return colUserControl.BarBorderWidth;
            }
            set
            {
                GetPropertyByName("BarBorderWidth").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar background light.
        /// </summary>
        /// <value>The bar background light.</value>
        public Color BarBackgroundLight
        {
            get
            {
                return colUserControl.BarBackgroundLight;
            }
            set
            {
                GetPropertyByName("BarBackgroundLight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar background dark.
        /// </summary>
        /// <value>The bar background dark.</value>
        public Color BarBackgroundDark
        {
            get
            {
                return colUserControl.BarBackgroundDark;
            }
            set
            {
                GetPropertyByName("BarBackgroundDark").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar light.
        /// </summary>
        /// <value>The bar light.</value>
        public Color BarLight
        {
            get
            {
                return colUserControl.BarLight;
            }
            set
            {
                GetPropertyByName("BarLight").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the bar dark.
        /// </summary>
        /// <value>The bar dark.</value>
        public Color BarDark
        {
            get
            {
                return colUserControl.BarDark;
            }
            set
            {
                GetPropertyByName("BarDark").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the bar border.
        /// </summary>
        /// <value>The color of the bar border.</value>
        public Color BarBorderColor
        {
            get
            {
                return colUserControl.BarBorderColor;
            }
            set
            {
                GetPropertyByName("BarBorderColor").SetValue(colUserControl, value);
            }
        }

        /// <summary>
        /// Gets or sets the type of the bar.
        /// </summary>
        /// <value>The type of the bar.</value>
        public BarType BarType
        {
            get
            {
                return colUserControl.BarType;
            }
            set
            {
                GetPropertyByName("BarType").SetValue(colUserControl, value);
            }
        }

        #endregion

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
                                 "Sets the control to autostart."));

            items.Add(new DesignerActionPropertyItem("TimerInterval",
                                 "Timer Interval", "Appearance",
                                 "Sets the speed of the animation."));

            items.Add(new DesignerActionPropertyItem("BackColor",
                                 "Back Color", "Appearance",
                                 "Sets the background color."));

            items.Add(new DesignerActionPropertyItem("StepSize",
                                 "Step Size", "Appearance",
                                 "Sets the step size."));

            items.Add(new DesignerActionPropertyItem("StepInterval",
                                 "Step Interval", "Appearance",
                                 "Sets the step interval."));

            items.Add(new DesignerActionPropertyItem("BarDividersCount",
                                 "Bar Dividers Count", "Appearance",
                                 "Sets the number of bars."));

            items.Add(new DesignerActionPropertyItem("BarMirrorOpacity",
                                 "Bar Mirror Opacity", "Appearance",
                                 "Sets the mirror opacity of the control."));

            items.Add(new DesignerActionPropertyItem("BarFillProcent",
                                 "Bar Fill Procent", "Appearance",
                                 "Sets the bar progress level in percentage."));

            items.Add(new DesignerActionPropertyItem("BarBorderWidth",
                                 "Bar Border Width", "Appearance",
                                 "Sets the inner border width of the control ."));

            items.Add(new DesignerActionPropertyItem("BarBackgroundLight",
                                 "Bar Background Light", "Appearance",
                                 "Sets the bar background light color of the control."));

            items.Add(new DesignerActionPropertyItem("BarBackgroundDark",
                                 "Bar Background Dark", "Appearance",
                                 "Sets the bar background dark color of the control."));

            items.Add(new DesignerActionPropertyItem("BarLight",
                                 "Bar Light", "Appearance",
                                 "Sets the bar lighter color."));

            items.Add(new DesignerActionPropertyItem("BarDark",
                                 "Bar Dark", "Appearance",
                                 "Sets the bar darker color."));

            items.Add(new DesignerActionPropertyItem("BarBorderColor",
                                 "Bar Border Color", "Appearance",
                                 "Sets the bar border color."));

            items.Add(new DesignerActionPropertyItem("BarType",
                                 "Bar Type", "Appearance",
                                 "Sets the bar animation type."));



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
