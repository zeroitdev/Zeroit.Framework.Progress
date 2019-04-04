// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 10-30-2017
//
// Last Modified By : ZEROIT
// Last Modified On : 05-05-2018
// ***********************************************************************
// <copyright file="ZeroitSpinning.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
#region Imports

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region SpinnerBuzz

    #region Control
    /// <summary>
    /// A class collection for rendering a progress indicator.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class ZeroitSpinning
    {

        #region Private Fields
        /// <summary>
        /// The m inactive colour
        /// </summary>
        private Color m_InactiveColour = Color.FromArgb(218, 218, 218);
        /// <summary>
        /// The m active colour
        /// </summary>
        private Color m_ActiveColour = Color.FromArgb(35, 146, 33);
        /// <summary>
        /// The m transistion colour
        /// </summary>
        private Color m_TransistionColour = Color.FromArgb(129, 242, 121);

        /// <summary>
        /// The inner background region
        /// </summary>
        private Region innerBackgroundRegion;
        /// <summary>
        /// The segment paths
        /// </summary>
        private System.Drawing.Drawing2D.GraphicsPath[] segmentPaths = new System.Drawing.Drawing2D.GraphicsPath[12];

        /// <summary>
        /// The m automatic increment
        /// </summary>
        private bool m_AutoIncrement = true;
        /// <summary>
        /// The m increment frequency
        /// </summary>
        private double m_IncrementFrequency = 100;
        /// <summary>
        /// The m behind is active
        /// </summary>
        private bool m_BehindIsActive = true;
        /// <summary>
        /// The m transition segment
        /// </summary>
        private int m_TransitionSegment = 0;

        /// <summary>
        /// The m automatic rotate timer
        /// </summary>
        private System.Timers.Timer m_AutoRotateTimer;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the inactive segment color.
        /// </summary>
        /// <value>The inactive segment color.</value>
        [System.ComponentModel.DefaultValue(typeof(Color), "218, 218, 218")]
        public Color InactiveSegmentColour
        {
            get
            {
                return m_InactiveColour;
            }
            set
            {
                m_InactiveColour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the active segment color.
        /// </summary>
        /// <value>The active segment color.</value>
        [System.ComponentModel.DefaultValue(typeof(Color), "35, 146, 33")]
        public Color ActiveSegmentColour
        {
            get
            {
                return m_ActiveColour;
            }
            set
            {
                m_ActiveColour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transistion segment color.
        /// </summary>
        /// <value>The transistion segment color.</value>
        [System.ComponentModel.DefaultValue(typeof(Color), "129, 242, 121")]
        public Color TransistionSegmentColour
        {
            get
            {
                return m_TransistionColour;
            }
            set
            {
                m_TransistionColour = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to set the behind transistion segment.
        /// </summary>
        /// <value><c>true</c> if behind transistion segment is active; otherwise, <c>false</c>.</value>
        [System.ComponentModel.DefaultValue(true)]
        public bool BehindTransistionSegmentIsActive
        {
            get
            {
                return m_BehindIsActive;
            }
            set
            {
                m_BehindIsActive = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the transistion segment.
        /// </summary>
        /// <value>The transistion segment.</value>
        /// <exception cref="ArgumentException">TransistionSegment must be between -1 and 11</exception>
        [System.ComponentModel.DefaultValue(-1)]
        public int TransistionSegment
        {
            get
            {
                return m_TransitionSegment;
            }
            set
            {
                if (value > 11 || value < -1)
                {
                    throw new ArgumentException("TransistionSegment must be between -1 and 11");
                }
                m_TransitionSegment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically animate the progress.
        /// </summary>
        /// <value><c>true</c> if automatic increment; otherwise, <c>false</c>.</value>
        [System.ComponentModel.DefaultValue(true)]
        public bool AutoIncrement
        {
            get
            {
                return m_AutoIncrement;
            }
            set
            {
                m_AutoIncrement = value;

                if (value == false && m_AutoRotateTimer != null)
                {
                    m_AutoRotateTimer.Dispose();
                    m_AutoRotateTimer = null;
                }

                if (value == true && m_AutoRotateTimer == null)
                {
                    m_AutoRotateTimer = new System.Timers.Timer(m_IncrementFrequency);
                    m_AutoRotateTimer.Elapsed += new System.Timers.ElapsedEventHandler(IncrementTransisionSegment);
                    m_AutoRotateTimer.Start();
                }
            }
        }

        /// <summary>
        /// Gets or sets the automatic increment frequency.
        /// </summary>
        /// <value>The automatic increment frequency.</value>
        [System.ComponentModel.DefaultValue(100)]
        public double AutoIncrementFrequency
        {
            get
            {
                return m_IncrementFrequency;
            }
            set
            {
                m_IncrementFrequency = value;

                if (m_AutoRotateTimer != null)
                {
                    AutoIncrement = false;
                    AutoIncrement = true;
                }
            }
        }


        #region Smoothing Mode

        /// <summary>
        /// The smoothing
        /// </summary>
        private SmoothingMode smoothing = SmoothingMode.HighQuality;

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
                Invalidate();
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSpinning" /> class.
        /// </summary>
        public ZeroitSpinning()
        {
            //  This call is required by the Windows Form Designer.
            InitializeComponent();

            //  Add any initialization after the InitializeComponent() call.
            CalculateSegments();

            m_AutoRotateTimer = new System.Timers.Timer(m_IncrementFrequency);
            m_AutoRotateTimer.Elapsed += new System.Timers.ElapsedEventHandler(IncrementTransisionSegment);
            this.DoubleBuffered = true;
            m_AutoRotateTimer.Start();

            this.EnabledChanged += new EventHandler(SpinningProgress_EnabledChanged);
            // events handled by ProgressDisk_Paint
            this.Paint += new PaintEventHandler(ProgressDisk_Paint);
            // events handled by ProgressDisk_Resize
            this.Resize += new EventHandler(ProgressDisk_Resize);
            // events handled by ProgressDisk_SizeChanged
            this.SizeChanged += new EventHandler(ProgressDisk_SizeChanged);
        }

        /// <summary>
        /// Increments the transision segment.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void IncrementTransisionSegment(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_TransitionSegment == 11)
            {
                m_TransitionSegment = 0;
                m_BehindIsActive = !(m_BehindIsActive);
            }
            else if (m_TransitionSegment == -1)
            {
                m_TransitionSegment = 0;
            }
            else
            {
                m_TransitionSegment += 1;
            }

            Invalidate();
        }


        /// <summary>
        /// Calculates the segments.
        /// </summary>
        private void CalculateSegments()
        {
            Rectangle rctFull = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle rctInner = new Rectangle(((this.Width * 7) / 30),
                                                ((this.Height * 7) / 30),
                                                (this.Width - ((this.Width * 14) / 30)),
                                                (this.Height - ((this.Height * 14) / 30)));

            System.Drawing.Drawing2D.GraphicsPath pthInnerBackground = null;

            // Create 12 segment pieces
            for (int intCount = 0; intCount < 12; intCount++)
            {
                segmentPaths[intCount] = new System.Drawing.Drawing2D.GraphicsPath();

                // We subtract 90 so that the starting segment is at 12 o'clock
                segmentPaths[intCount].AddPie(rctFull, (intCount * 30) - 90, 25);
            }

            // Create the center circle cut-out
            pthInnerBackground = new System.Drawing.Drawing2D.GraphicsPath();
            pthInnerBackground.AddPie(rctInner, 0, 360);
            innerBackgroundRegion = new Region(pthInnerBackground);
        }


        /// <summary>
        /// Handles the EnabledChanged event of the ZeroitSpinning control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SpinningProgress_EnabledChanged(object sender, System.EventArgs e)
        {
            if (Enabled == true)
            {
                if (m_AutoRotateTimer != null)
                {
                    m_AutoRotateTimer.Start();
                }
            }
            else
            {
                if (m_AutoRotateTimer != null)
                {
                    m_AutoRotateTimer.Stop();
                }
            }
        }




        /// <summary>
        /// Handles the Paint event of the ProgressDisk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void ProgressDisk_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = smoothing;
            e.Graphics.ExcludeClip(innerBackgroundRegion);

            for (int intCount = 0; intCount < 12; intCount++)
            {
                if (this.Enabled)
                {
                    if (intCount == m_TransitionSegment)
                    {
                        // If this segment is the transistion segment, colour it differently
                        e.Graphics.FillPath(new SolidBrush(m_TransistionColour), segmentPaths[intCount]);
                    }
                    else if (intCount < m_TransitionSegment)
                    {
                        // This segment is behind the transistion segment
                        if (m_BehindIsActive)
                        {
                            // If behind the transistion should be active, 
                            // colour it with the active colour
                            e.Graphics.FillPath(new SolidBrush(m_ActiveColour), segmentPaths[intCount]);
                        }
                        else
                        {
                            // If behind the transistion should be in-active, 
                            // colour it with the in-active colour
                            e.Graphics.FillPath(new SolidBrush(m_InactiveColour), segmentPaths[intCount]);
                        }
                    }
                    else
                    {
                        // This segment is ahead of the transistion segment
                        if (m_BehindIsActive)
                        {
                            // If behind the the transistion should be active, 
                            // colour it with the in-active colour
                            e.Graphics.FillPath(new SolidBrush(m_InactiveColour), segmentPaths[intCount]);
                        }
                        else
                        {
                            // If behind the the transistion should be in-active, 
                            // colour it with the active colour
                            e.Graphics.FillPath(new SolidBrush(m_ActiveColour), segmentPaths[intCount]);
                        }
                    }
                }
                else
                {
                    // Draw all segments in in-active colour if not enabled
                    e.Graphics.FillPath(new SolidBrush(m_InactiveColour), segmentPaths[intCount]);
                }
            }
        }


        /// <summary>
        /// Handles the Resize event of the ProgressDisk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ProgressDisk_Resize(object sender, System.EventArgs e)
        {
            CalculateSegments();
        }


        /// <summary>
        /// Handles the SizeChanged event of the ProgressDisk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ProgressDisk_SizeChanged(object sender, System.EventArgs e)
        {
            CalculateSegments();
        }

    }


    #endregion

    #region Designer Generated Code
    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class ZeroitSpinning : System.Windows.Forms.UserControl
    {

        // UserControl1 overrides dispose to clean up the component list.
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        // Required by the Windows Form Designer
        /// <summary>
        /// The components
        /// </summary>
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ZeroitSpinning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ZeroitSpinning";
            this.Size = new System.Drawing.Size(30, 30);
            this.ResumeLayout(false);

        }


    }

    #endregion

    #endregion
}
