// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="TimeBar.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Timer Bar

    /// <summary>
    /// Enum representing the Light Style
    /// </summary>
    public enum LightStyle
    {
        /// <summary>
        /// The fill
        /// </summary>
        Fill,
        /// <summary>
        /// The light
        /// </summary>
        Light
    }

    /// <summary>
    /// Enum representing the Light Speed
    /// </summary>
    public enum LightSpeed
    {
        /// <summary>
        /// The fast
        /// </summary>
        Fast = 20,
        /// <summary>
        /// The medium
        /// </summary>
        Medium = 40,
        /// <summary>
        /// The slow
        /// </summary>
        Slow = 60
    }

    /// <summary>
    /// Enum representing the Timer Position
    /// </summary>
    public enum TimerPosition
    {
        /// <summary>
        /// The left
        /// </summary>
        Left,
        /// <summary>
        /// The right
        /// </summary>
        Right
    }

    /// <summary>
    /// A class collection for rendering the progress bar.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class ZeroitTimeBar : Control
    {
        /// <summary>
        /// The tt
        /// </summary>
        ToolTip tt;
        /// <summary>
        /// The ticks
        /// </summary>
        private float ticks = 0;

        #region Private Fields
        /// <summary>
        /// Occurs when [tick].
        /// </summary>
        [Category("Action")]
        [Browsable(true)]
        public event EventHandler Tick;
        /// <summary>
        /// Occurs when [time has expired].
        /// </summary>
        [Category("Action")]
        [Browsable(true)]
        public event EventHandler TimeHasExpired;
        /// <summary>
        /// Occurs when [user begin change time].
        /// </summary>
        [Category("Action")]
        [Browsable(true)]
        public event EventHandler UserBeginChangeTime;
        /// <summary>
        /// Occurs when [user end change time].
        /// </summary>
        [Category("Action")]
        [Browsable(true)]
        public event EventHandler UserEndChangeTime;

        /// <summary>
        /// The bold train
        /// </summary>
        private bool boldTrain = false;
        /// <summary>
        /// The focus
        /// </summary>
        private float focus = 0;
        /// <summary>
        /// The scale
        /// </summary>
        private float scale = 0;
        /// <summary>
        /// The line left
        /// </summary>
        int line_left;
        /// <summary>
        /// The line right
        /// </summary>
        int line_right;

        /// <summary>
        /// The timer x offset
        /// </summary>
        private int timerXOffset = 0;
        /// <summary>
        /// The timer x size
        /// </summary>
        private int timerXSize = 45;

        /// <summary>
        /// The pix to sec
        /// </summary>
        private float pixToSec;
        /// <summary>
        /// The is dragging
        /// </summary>
        private bool isDragging;
        /// <summary>
        /// The now
        /// </summary>
        private float now = 0;
        /// <summary>
        /// The maximum duration
        /// </summary>
        private const int maxDuration = 9999;
        /// <summary>
        /// The duration
        /// </summary>
        private int duration = 60;

        /// <summary>
        /// The timer position
        /// </summary>
        private TimerPosition timerPosition;
        /// <summary>
        /// The light speed
        /// </summary>
        private LightSpeed lightSpeed = LightSpeed.Medium;
        /// <summary>
        /// The light style
        /// </summary>
        private LightStyle lightStyle = LightStyle.Fill;

        /// <summary>
        /// The color1
        /// </summary>
        private Color color1 = Color.FromArgb(162, 221, 251);
        /// <summary>
        /// The color2
        /// </summary>
        private Color color2 = Color.FromArgb(80, 110, 125);

        /// <summary>
        /// The BMP cursor
        /// </summary>
        private Bitmap bmp_cursor;
        /// <summary>
        /// The background worker1
        /// </summary>
        private BackgroundWorker backgroundWorker1;
        /// <summary>
        /// The components
        /// </summary>
        private IContainer components;
        /// <summary>
        /// The timer1
        /// </summary>
        private System.Windows.Forms.Timer timer1;
        /// <summary>
        /// The cursor location
        /// </summary>
        private PointF cursor_location;
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color1.</value>
        [Category("Misc")]
        [Browsable(true)]
        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                if (this.BackgroundImage != null)
                    this.BackgroundImage.Dispose();
                this.BackgroundImage = MakeBackground(0, 0);
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color2.</value>
        [Category("Misc")]
        [Browsable(true)]
        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                if (this.BackgroundImage != null)
                    this.BackgroundImage.Dispose();
                this.BackgroundImage = MakeBackground(0, 0);
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the timer position.
        /// </summary>
        /// <value>The timer position.</value>
        [Category("Misc")]
        [Browsable(true)]
        public TimerPosition TimerPosition
        {
            get { return timerPosition; }
            set
            {
                timerPosition = value;

                if (timerPosition == TimerPosition.Right)
                {
                    timerXOffset = this.Width - timerXSize;
                    line_left = 0; line_right = timerXOffset;
                }
                else { timerXOffset = 0; line_left = timerXSize; line_right = this.Width; }

                cursor_location.X = line_left;
                this.BackgroundImage.Dispose();
                this.BackgroundImage = MakeBackground(0, 0);

                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether set bold train.
        /// </summary>
        /// <value><c>true</c> if bold train; otherwise, <c>false</c>.</value>
        [Category("Misc")]
        [Browsable(true)]
        public bool BoldTrain
        {
            get { return boldTrain; }
            set { boldTrain = value; }
        }

        /// <summary>
        /// Gets or sets the light style.
        /// </summary>
        /// <value>The light style.</value>
        [Category("Misc")]
        [Browsable(true)]
        public LightStyle LightStyle
        {
            get { return lightStyle; }
            set
            {
                lightStyle = value;
                if (this.BackgroundImage != null)
                    this.BackgroundImage.Dispose();
                this.BackgroundImage = MakeBackground(0, 0);
                Refresh();
            }
        }

        /// <summary>
        /// Gets or sets the light speed.
        /// </summary>
        /// <value>The light speed.</value>
        [Category("Misc")]
        [Browsable(true)]
        public LightSpeed LightSpeed
        {
            get { return lightSpeed; }
            set { lightSpeed = value; }
        }

        /// <summary>
        /// Gets the now value.
        /// </summary>
        /// <value>The now.</value>
        [Browsable(false)]
        public float Now
        {
            get { return now; }
        }

        /// <summary>
        /// Gets a value indicating whether this control supports dragging.
        /// </summary>
        /// <value><c>true</c> if supports dragging; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsDragging
        {
            get { return isDragging; }
        }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        [Category("Misc")]
        [Browsable(true)]
        public int Interval
        {
            get { return timer1.Interval; }
            set { timer1.Interval = value; }
        }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>The duration.</value>
        /// <exception cref="ArgumentOutOfRangeException">Duration - Должна варьироваться от 0 до 9999 сек.</exception>
        [Category("Misc")]
        [Browsable(true)]
        public int Duration
        {
            get { return duration; }
            set
            {
                if (value <= maxDuration)
                {
                    duration = value;
                    if (duration != 0)
                        pixToSec = (float)(this.Width - timerXSize) / duration;
                    else pixToSec = 0;
                    Refresh();
                }
                else throw new ArgumentOutOfRangeException("Duration", "Должна варьироваться от 0 до 9999 сек.");
            }
        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitTimeBar" /> class.
        /// </summary>
        public ZeroitTimeBar()
        {
            InitializeComponent();

            tt = new ToolTip();
            tt.SetToolTip(this, "Move the cursor...");
            tt.UseAnimation = true;

            this.MouseDown += new MouseEventHandler(TimeBar_MouseDown);
            this.MouseMove += new MouseEventHandler(TimeBar_MouseMove);
            this.MouseUp += new MouseEventHandler(TimeBar_MouseUp);
            this.DoubleBuffered = true;

            this.BackgroundImage = MakeBackground(0, 0);
            bmp_cursor = MakeCursor();

            TimerPosition = TimerPosition.Left;
            cursor_location = new Point(line_left, 0);

            this.Disposed += new EventHandler(TimeBar_Disposed);
        }
        #endregion

        #region Events and Overrides
        /// <summary>
        /// Handles the MouseUp event of the TimeBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void TimeBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;

                if (e.X > line_right)
                    cursor_location.X = line_right;
                else if (e.X < line_left)
                    cursor_location.X = line_left;
                else
                    cursor_location.X = e.X;

                now = (int)((float)(cursor_location.X - line_left) / pixToSec);
                Refresh();

                if (Tick != null)
                    Tick(this, null);
                if (UserEndChangeTime != null)
                    UserEndChangeTime(this, null);

                timer1.Start();
            }
        }

        /// <summary>
        /// Handles the MouseMove event of the TimeBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void TimeBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
                if (e.X >= line_left && e.X <= line_right)
                {
                    cursor_location.X = e.X;
                    now = (int)((float)(e.X - line_left) / pixToSec);
                    Refresh();

                    if (Tick != null)
                        Tick(this, null);
                }
        }

        /// <summary>
        /// Handles the MouseDown event of the TimeBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void TimeBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                if (e.X >= line_left && e.X <= line_right)
                {
                    if (UserBeginChangeTime != null)
                        UserBeginChangeTime(this, null);

                    timer1.Stop();

                    isDragging = true;
                    cursor_location.X = e.X;
                    now = (int)((float)(e.X - line_left) / pixToSec);
                    Refresh();

                    if (Tick != null)
                        Tick(this, null);
                }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawImageUnscaled(bmp_cursor, (int)cursor_location.X - bmp_cursor.Width / 2, 0);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.Height > 0 && this.Width > 0)
            {
                if (timerPosition == TimerPosition.Right)
                    timerXOffset = this.Width - timerXSize;
                else timerXOffset = 0;

                if (duration != 0)
                    pixToSec = (float)(this.Width - timerXSize) / duration;
                else pixToSec = 0;

                if (timerPosition == TimerPosition.Right)
                { line_left = 0; line_right = timerXOffset; }
                else { line_left = timerXSize; line_right = this.Width; }

                if (this.BackgroundImage != null)
                    this.BackgroundImage.Dispose();
                this.BackgroundImage = MakeBackground(0, 0);
                bmp_cursor = MakeCursor();

                Refresh();
            }
        }
        #endregion

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            //stop time
            timer1.Stop();
            //stop background
            backgroundWorker1.CancelAsync();
            //for LightStyle.Fill
            pix = -1;
            //for LightStyle.Light
            focus = 0;
            scale = 0;
            //reset time
            now = 0;
            //reset cursor location
            cursor_location.X = line_left;
            Refresh();

            if (TimeHasExpired != null)
                TimeHasExpired(this, null);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            timer1.Start();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                now = 0;
                cursor_location.X = line_left;
                if (Tick != null)
                    Tick(this, null);
            }
        }

        /// <summary>
        /// Advances this instance.
        /// </summary>
        public void Advance()
        {
            cursor_location.X += pixToSec / (1000 / timer1.Interval);
            now += (float)1 / (1000 / timer1.Interval);
            if (now >= duration)  // не просто ==, а >=, для случая, если duration = 0
            {
                Stop();
            }
            else if (Tick != null) Tick(this, null);
        }

        #region Runtime Graphic
        /// <summary>
        /// Makes the background.
        /// </summary>
        /// <param name="focus">The focus.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>Bitmap.</returns>
        private Bitmap MakeBackground(float focus, float scale)
        {

            Bitmap bmp = new Bitmap(this.Width, this.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, bmp.Height / 2), new Point(bmp.Width, bmp.Height / 2), color1, color2))
                {
                    if (lightStyle == LightStyle.Light)
                        b.SetSigmaBellShape(focus, scale);
                    else
                        b.TranslateTransform(pix, 0.5f, System.Drawing.Drawing2D.MatrixOrder.Prepend);

                    g.FillRectangle(b, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }
                using (Pen p = new Pen(Color.Black))
                {
                    g.DrawLine(p, line_left, this.Height / 2, line_right, this.Height / 2);
                }
                using (Pen p = new Pen(Color.LightGray))
                {
                    g.DrawLine(p, line_left, this.Height / 2 - 2, line_right, this.Height / 2 - 2);
                    g.DrawLine(p, line_left, this.Height / 2 + 2, line_right, this.Height / 2 + 2);
                }
                using (Pen p = new Pen(Color.DarkGray))
                {
                    g.DrawLine(p, line_left, this.Height / 2 - 1, line_right, this.Height / 2 - 1);
                    g.DrawLine(p, line_left, this.Height / 2 + 1, line_right, this.Height / 2 + 1);
                }
                using (Pen p = new Pen(Color.Red))
                {
                    g.DrawLine(p, line_left, this.Height / 2, (int)cursor_location.X, this.Height / 2);
                    if (boldTrain)
                    {
                        g.DrawLine(p, line_left, this.Height / 2 - 1, (int)cursor_location.X, this.Height / 2 - 1);
                        g.DrawLine(p, line_left, this.Height / 2 + 1, (int)cursor_location.X, this.Height / 2 + 1);
                    }
                }
                using (SolidBrush sbrush = new SolidBrush(Color.Red))
                {
                    int intnow = Convert.ToInt32(now);
                    if (timerPosition == TimerPosition.Right)
                        g.DrawString(String.Format("{0:D2} : {1:D2}", intnow / 60, intnow - intnow / 60 * 60), new Font("Roman New Times", 10f, FontStyle.Bold, GraphicsUnit.Pixel), sbrush, timerXOffset + 3, this.Height / 2 - 7);
                    else g.DrawString(String.Format("{0:D2} : {1:D2}", intnow / 60, intnow - intnow / 60 * 60), new Font("Roman New Times", 10f, FontStyle.Bold, GraphicsUnit.Pixel), sbrush, 3, this.Height / 2 - 7);
                }
            }
            return bmp;
        }

        /// <summary>
        /// Создает изображение курсора в виде треугольника.
        /// </summary>
        /// <returns>Bitmap.</returns>
        private Bitmap MakeCursor()
        {
            Bitmap bmp = new Bitmap(11, this.Height / 2);

            bmp.MakeTransparent();
            Point[] pts = new Point[3];
            pts[0] = new Point();
            pts[1] = new Point(bmp.Width - 1, 0);
            pts[2] = new Point(bmp.Width / 2, bmp.Height - 1);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (Brush b = new SolidBrush(Color.Black))
                {
                    g.FillPolygon(b, pts);
                }
            }
            return bmp;
        }
        #endregion

        /// <summary>
        /// Handles the Disposed event of the TimeBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void TimeBar_Disposed(object sender, EventArgs e)
        {
            bmp_cursor.Dispose();
            this.BackgroundImage.Dispose();
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimeBar
            // 
            this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.MaximumSize = new System.Drawing.Size(0, 23);
            this.MinimumSize = new System.Drawing.Size(200, 13);
            this.Size = new System.Drawing.Size(200, 15);
            this.TabStop = false;
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Handles the DoWork event of the backgroundWorker1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!worker.CancellationPending)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep((int)lightSpeed);
                worker.ReportProgress(0);
            }
        }

        /// <summary>
        /// The pix
        /// </summary>
        float pix = 0;
        /// <summary>
        /// Handles the ProgressChanged event of the backgroundWorker1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //this event occurs in Form thread. And changes in this handler is thread-self.
            focus += 0.01f;
            pix++;

            if (focus > 1.0f)
            {
                focus = 0f;
                System.Threading.Thread.Sleep(100);
            }
            if (pix % this.Width == 0)
                pix = 0;

            scale = (focus - 0.5f) * (focus - 0.5f);
            scale *= 4;
            scale = 1 - scale;

            this.BackgroundImage.Dispose();
            this.BackgroundImage = MakeBackground(focus, scale);

            this.Refresh();
        }

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Advance();
        }

    }//class

    #endregion
}
