// ***********************************************************************
// Assembly         : Zeroit.Framework.Progress
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-21-2018
// ***********************************************************************
// <copyright file="WorkDelegatesArguments.cs" company="Zeroit Dev Technologies">
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
using System.Threading;
//using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;

#endregion

namespace Zeroit.Framework.Progress
{

    #region Work, Delegates and Arguments

    //-----------------------------------------------------------------------------
    // Work
    /// <summary>
    /// Class Work.
    /// </summary>
    public class Work
    {
        /// <summary>
        /// The interval
        /// </summary>
        private int _Interval = 10;
        /// <summary>
        /// The thread
        /// </summary>
        private Thread _Thread = null;
        /// <summary>
        /// The stop
        /// </summary>
        private volatile bool _Stop = false;

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        public int Interval { get { return _Interval; } set { _Interval = value; } }
        /// <summary>
        /// Gets the thread.
        /// </summary>
        /// <value>The thread.</value>
        public Thread Thread { get { return _Thread; } }

        /// <summary>
        /// Occurs when [step].
        /// </summary>
        public event EventHandler Step;

        /// <summary>
        /// Initializes a new instance of the <see cref="Work"/> class.
        /// </summary>
        public Work()
        {
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            _Thread = new Thread(new ThreadStart(DoWork));
            _Thread.Priority = ThreadPriority.Lowest;
            _Thread.IsBackground = true;
            _Thread.Name = "Worker";
            _Thread.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            _Stop = true;
        }

        /// <summary>
        /// Does the work.
        /// </summary>
        private void DoWork()
        {
            for (;;)
            {
                if (Step != null) Step(this, EventArgs.Empty);

                DateTime start = DateTime.Now;

                for (;;)
                {
                    //						Thread.SpinWait( 1000000 );
                    Thread.Sleep(1);

                    TimeSpan interval = DateTime.Now - start;

                    if (interval.TotalMilliseconds >= _Interval) break;
                }

                if (_Stop) break;
            }
        }
    }



    /// <summary>
    /// Class BusyBarPerformStepArgs.
    /// </summary>
    public class BusyBarPerformStepArgs
    {
        /// <summary>
        /// The busy bar
        /// </summary>
        public ZeroitBusyBar BusyBar;
        /// <summary>
        /// Initializes a new instance of the <see cref="BusyBarPerformStepArgs"/> class.
        /// </summary>
        /// <param name="busyBar">The busy bar.</param>
        public BusyBarPerformStepArgs(ZeroitBusyBar busyBar) { BusyBar = busyBar; }
    }

    /// <summary>
    /// Delegate BusyBarPerformStepDelegate
    /// </summary>
    /// <param name="args">The arguments.</param>
    public delegate void BusyBarPerformStepDelegate(BusyBarPerformStepArgs args);



    /// <summary>
    /// Class ProgressBarPerformStepArgs.
    /// </summary>
    public class ProgressBarPerformStepArgs
    {
        /// <summary>
        /// The progress bar
        /// </summary>
        public ProgressBar ProgressBar;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBarPerformStepArgs"/> class.
        /// </summary>
        /// <param name="progressBar">The progress bar.</param>
        public ProgressBarPerformStepArgs(ProgressBar progressBar) { ProgressBar = progressBar; }
    }

    /// <summary>
    /// Delegate ProgressBarPerformStepDelegate
    /// </summary>
    /// <param name="args">The arguments.</param>
    public delegate void ProgressBarPerformStepDelegate(ProgressBarPerformStepArgs args);


    //-----------------------------------------------------------------------------

    #endregion

}
