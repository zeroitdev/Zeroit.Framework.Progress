using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	public class BunifuFormFadeTransition : Component
	{
		private Form form_0;

        private double double_0;

		private int int_0 = 1;

		private IContainer icontainer_0;

		private BackgroundWorker backgroundWorker_0;

        EventHandler eventHandler_0;

        
        public int Delay
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		public BunifuFormFadeTransition()
		{
            
			this.method_0();

		}

		public BunifuFormFadeTransition(IContainer container)
		{
			container.Add(this);
			this.method_0();
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			this.double_0 = 0;
			while (this.double_0 < 1)
			{
				this.backgroundWorker_0.ReportProgress(0);
				Thread.Sleep(this.Delay);
				this.double_0 = this.double_0 + 0.001;
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.form_0.Opacity = this.double_0;
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			this.form_0.Opacity = 1;
			if (this.eventHandler_0 == null)
			{
				do
				{
					if (num != num1)
					{
						break;
					}
					num1 = 1;
					num2 = num;
					num = 1;
				}
				while (1 <= num2);
			}
			else
			{
				this.eventHandler_0(sender, e);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		public void HideAsyc(Form frm, bool Close)
		{
			this.form_0 = frm;
		}

		private void method_0()
		{
			this.backgroundWorker_0 = new BackgroundWorker()
			{
				WorkerReportsProgress = true
			};
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
		}

		public void ShowAsyc(Form frm)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			try
			{
				this.form_0 = frm;
				this.backgroundWorker_0.RunWorkerAsync();
			}
			catch (Exception exception)
			{
			}
			do
			{
				if (num != num1)
				{
					break;
				}
				num1 = 1;
				num2 = num;
				num = 1;
			}
			while (1 <= num2);
		}

		public event EventHandler TransitionEnd
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler0 = this.eventHandler_0;
				do
				{
					eventHandler = eventHandler0;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
				}
				while ((object)eventHandler0 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler0 = this.eventHandler_0;
				do
				{
					eventHandler = eventHandler0;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler0 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, eventHandler1, eventHandler);
				}
				while ((object)eventHandler0 != (object)eventHandler);
			}
		}
	}
}