// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-20-2018
// ***********************************************************************
// <copyright file="DigitalClock.cs" company="Zeroit Dev Technologies">
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
using System.Drawing;
using System.Timers;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{
    #region Digital Clock

    /// <summary>
    /// A class collection for rendering a digital clock.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.Progress.ZeroitProgressBarAwesome" />
    public class ZeroitDigitalClock : Zeroit.Framework.Progress.ZeroitProgressBarAwesome
    {
        /// <summary>
        /// The time
        /// </summary>
        private System.Timers.Timer time = new System.Timers.Timer();

        //private System.Windows.Forms.Timer time = new System.Windows.Forms.Timer();
        /// <summary>
        /// The date time
        /// </summary>
        private DateTime dateTime = new DateTime();

        /// <summary>
        /// Enum representing whether the timer is Shown or not for <c><see cref="ZeroitDigitalClock" /></c>.
        /// </summary>
        public enum Times
        {
            /// <summary>
            /// The Shown
            /// </summary>
            Shown,
            /// <summary>
            /// The not Shown
            /// </summary>
            NotShown
        };
        /// <summary>
        /// The timers
        /// </summary>
        private Times timers = Times.NotShown;



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
        /// Gets or sets a value indicating whether automatically animate the clock.
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
                this.Value = 0;
            else
                this.Value++;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitDigitalClock" /> class.
        /// </summary>
        public ZeroitDigitalClock()
        {
            time.Interval = 1000;
            time.Elapsed += Time_Elapsed;
            time.Start();

            //Text = "00:00:00";
            //SubscriptText = "00";
            SuperscriptText = "";
            Style = ProgressBarStyle.Marquee;
            InnerColor = Color.DarkSlateGray;
            OuterColor = Color.SaddleBrown;
            OuterWidth = 17;

            ForeColor = Color.White;
            this.Font = new Font("Verdana", 15f);
            SecondaryFont = new Font("Verdana", 8.5f);
            ProgressWidth = 10;

            Maximum = 60;
            Minimum = 0;

            switch (dateTime.Second)
            {
                case 1:
                    Value = 1;
                    break;
                case 2:
                    Value = 2;
                    break;
                case 3:
                    Value = 3;
                    break;
                case 4:
                    Value = 4;
                    break;
                case 5:
                    Value = 5;
                    break;
                case 6:
                    Value = 6;
                    break;
                case 7:
                    Value = 7;
                    break;
                case 8:
                    Value = 8;
                    break;
                case 9:
                    Value = 9;
                    break;
                case 10:
                    Value = 10;
                    break;
                case 11:
                    Value = 11;
                    break;
                case 12:
                    Value = 12;
                    break;
                case 13:
                    Value = 13;
                    break;
                case 14:
                    Value = 14;
                    break;
                case 15:
                    Value = 15;
                    break;
                case 16:
                    Value = 16;
                    break;
                case 17:
                    Value = 17;
                    break;
                case 18:
                    Value = 18;
                    break;
                case 19:
                    Value = 19;
                    break;
                case 20:
                    Value = 20;
                    break;
                case 21:
                    Value = 21;
                    break;
                case 22:
                    Value = 22;
                    break;
                case 23:
                    Value = 23;
                    break;
                case 24:
                    Value = 24;
                    break;
                case 25:
                    Value = 25;
                    break;
                case 26:
                    Value = 26;
                    break;
                case 27:
                    Value = 27;
                    break;
                case 28:
                    Value = 28;
                    break;
                case 29:
                    Value = 29;
                    break;
                case 30:
                    Value = 30;
                    break;
                case 31:
                    Value = 31;
                    break;
                case 32:
                    Value = 32;
                    break;
                case 33:
                    Value = 33;
                    break;
                case 34:
                    Value = 34;
                    break;
                case 35:
                    Value = 35;
                    break;
                case 36:
                    Value = 36;
                    break;
                case 37:
                    Value = 37;
                    break;
                case 38:
                    Value = 38;
                    break;
                case 39:
                    Value = 39;
                    break;
                case 40:
                    Value = 40;
                    break;
                case 41:
                    Value = 41;
                    break;
                case 42:
                    Value = 42;
                    break;
                case 43:
                    Value = 43;
                    break;
                case 44:
                    Value = 44;
                    break;
                case 45:
                    Value = 45;
                    break;
                case 46:
                    Value = 46;
                    break;
                case 47:
                    Value = 47;
                    break;
                case 48:
                    Value = 48;
                    break;
                case 49:
                    Value = 49;
                    break;
                case 50:
                    Value = 50;
                    break;
                case 51:
                    Value = 51;
                    break;
                case 52:
                    Value = 52;
                    break;
                case 53:
                    Value = 53;
                    break;
                case 54:
                    Value = 54;
                    break;
                case 55:
                    Value = 55;
                    break;
                case 56:
                    Value = 56;
                    break;
                case 57:
                    Value = 57;
                    break;
                case 58:
                    Value = 58;
                    break;
                case 59:
                    Value = 59;
                    break;
                case 60:
                    Value = 60;
                    break;

                default:
                    Value = 0;
                    break;
            }

            Value = dateTime.Second;

        }

        /// <summary>
        /// Handles the Elapsed event of the Time control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void Time_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.Text = DateTime.Now.ToString("hh:mm:ss");
                this.SubscriptText = DateTime.Now.ToString("tt");

                Value++;

                if (Value == 60)
                {
                    Value = 0;
                }

                Invalidate();
            }
            );
        }


    }
    #endregion
}
