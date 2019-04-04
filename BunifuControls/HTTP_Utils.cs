using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("OnJobDone")]
	public class BunifuHTTP_Utils : Component
	{
		private string string_0 = "";

		private Exception exception_0;

		private string string_1 = "";

		private string string_2 = "";

		private string string_3 = "";

		private bool bool_0;

		private IContainer icontainer_0;

		private BackgroundWorker backgroundWorker_0;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;
        EventHandler eventHandler_2;
        EventHandler eventHandler_3;
        EventHandler eventHandler_4;
        EventHandler eventHandler_5;
        EventHandler eventHandler_6;
        public bool IsBusy
		{
			get
			{
				return this.bool_0;
			}
		}

		public string JobName
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		public Exception LastError
		{
			get
			{
				return this.exception_0;
			}
		}

		public string Url
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		public string Value
		{
			get
			{
				return this.string_0;
			}
		}

		public BunifuHTTP_Utils()
		{
			this.method_0();
		}

		public BunifuHTTP_Utils(IContainer container)
		{
			container.Add(this);
			this.method_0();
		}

		public void AbortJob()
		{
			int num = 0;
			int num1 = 0;
			int num2;
			try
			{
				if (this.backgroundWorker_0.IsBusy)
				{
					this.backgroundWorker_0.CancelAsync();
				}
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
				if (this.eventHandler_2 != null)
				{
					this.eventHandler_2(this, new EventArgs());
				}
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

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			this.bool_0 = true;
			HTTP hTTP = new HTTP(this.string_2);
			if (hTTP.executesend(this.string_3))
			{
				this.string_0 = hTTP.Responce;
				this.exception_0 = null;
				return;
			}
			this.string_0 = "";
			this.exception_0 = hTTP.LastError;
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			this.bool_0 = false;
			try
			{
				if (this.LastError == null)
				{
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, new EventArgs());
					}
				}
				else if (this.eventHandler_1 != null)
				{
					this.eventHandler_1(this, new EventArgs());
				}
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
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

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		public long getFileSize(string url)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Method = "HEAD";
			return ((HttpWebResponse)httpWebRequest.GetResponse()).ContentLength;
		}

		private void method_0()
		{
			this.icontainer_0 = new System.ComponentModel.Container();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
		}

		public void PostString()
		{
			int num = 0;
			int num1 = 0;
			int num2;
			try
			{
				this.backgroundWorker_0.RunWorkerAsync();
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Http Job already running.");
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

		public void PostString(string Data)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			try
			{
				this.string_3 = Data;
				this.backgroundWorker_0.RunWorkerAsync();
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Http Job already running.");
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

		public void PostString(Dictionary<string, string> Data)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			string str = "";
			try
			{
				for (int i = 0; i < Data.Keys.Count; i++)
				{
					string str1 = Data.Keys.ElementAt<string>(i).ToString();
					string item = Data[str1];
					str = string.Concat(new string[] { str, "&", str1, "=", item });
				}
				this.string_3 = str;
				this.backgroundWorker_0.RunWorkerAsync();
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Http Job already running.");
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

		public void PostString(string Data, string jobname)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			this.string_3 = Data;
			this.JobName = jobname;
			try
			{
				this.backgroundWorker_0.RunWorkerAsync();
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Http Job already running.");
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

		public void PostString(string Data, string jobname, string url)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			this.string_3 = Data;
			this.JobName = jobname;
			this.Url = url;
			try
			{
				this.backgroundWorker_0.RunWorkerAsync();
				if (this.eventHandler_5 != null)
				{
					this.eventHandler_5(this, new EventArgs());
				}
			}
			catch (Exception exception)
			{
				throw new Exception("Http Job already running.");
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

		public event EventHandler onAborted
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler2 = this.eventHandler_2;
				do
				{
					eventHandler = eventHandler2;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler2 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_2, eventHandler1, eventHandler);
				}
				while ((object)eventHandler2 != (object)eventHandler);
			}
		}

		public event EventHandler onBusyStateChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler5 = this.eventHandler_5;
				do
				{
					eventHandler = eventHandler5;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_5, eventHandler1, eventHandler);
				}
				while ((object)eventHandler5 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler5 = this.eventHandler_5;
				do
				{
					eventHandler = eventHandler5;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler5 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_5, eventHandler1, eventHandler);
				}
				while ((object)eventHandler5 != (object)eventHandler);
			}
		}

		public event EventHandler OnDownloadProgressChanged
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler6 = this.eventHandler_6;
				do
				{
					eventHandler = eventHandler6;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_6, eventHandler1, eventHandler);
				}
				while ((object)eventHandler6 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler6 = this.eventHandler_6;
				do
				{
					eventHandler = eventHandler6;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler6 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_6, eventHandler1, eventHandler);
				}
				while ((object)eventHandler6 != (object)eventHandler);
			}
		}

		public event EventHandler OnError
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler1 = this.eventHandler_1;
				do
				{
					eventHandler = eventHandler1;
					EventHandler eventHandler2 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler1 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_1, eventHandler2, eventHandler);
				}
				while ((object)eventHandler1 != (object)eventHandler);
			}
		}

		public event EventHandler onFileDownloadComplete
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler3 = this.eventHandler_3;
				do
				{
					eventHandler = eventHandler3;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler3 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, eventHandler1, eventHandler);
				}
				while ((object)eventHandler3 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler3 = this.eventHandler_3;
				do
				{
					eventHandler = eventHandler3;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler3 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_3, eventHandler1, eventHandler);
				}
				while ((object)eventHandler3 != (object)eventHandler);
			}
		}

		public event EventHandler onFileDownloadFail
		{
			add
			{
				EventHandler eventHandler;
				EventHandler eventHandler4 = this.eventHandler_4;
				do
				{
					eventHandler = eventHandler4;
					EventHandler eventHandler1 = (EventHandler)Delegate.Combine(eventHandler, value);
					eventHandler4 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_4, eventHandler1, eventHandler);
				}
				while ((object)eventHandler4 != (object)eventHandler);
			}
			remove
			{
				EventHandler eventHandler;
				EventHandler eventHandler4 = this.eventHandler_4;
				do
				{
					eventHandler = eventHandler4;
					EventHandler eventHandler1 = (EventHandler)Delegate.Remove(eventHandler, value);
					eventHandler4 = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_4, eventHandler1, eventHandler);
				}
				while ((object)eventHandler4 != (object)eventHandler);
			}
		}

		public event EventHandler OnJobDone
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