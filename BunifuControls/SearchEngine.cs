using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Zeroit.Framework.Progress.CustomControls
{
	[DebuggerStepThrough]
	[DefaultEvent("onScanComlete")]
	[ProvideProperty("BunifuFramework", typeof(Control))]
	public class BunifuSearchEngine : UserControl
	{
		public string lastError = "";

		public int Passentage;

		public string path;

		public string curFile;

		public string curFolder = "";

		public bool pause;

		public List<FileInfo> Files = new List<FileInfo>();

		public List<DirectoryInfo> Folders = new List<DirectoryInfo>();

		private IContainer icontainer_0;

		private BackgroundWorker backgroundWorker_0;

        EventHandler eventHandler_0;
        EventHandler eventHandler_1;
        EventHandler eventHandler_2;
        EventHandler eventHandler_3;
        EventHandler eventHandler_4;
        EventHandler eventHandler_5;

        public BunifuSearchEngine()
		{
			this.InitializeComponent();
			LicenseUsageMode usageMode = LicenseManager.UsageMode;
			BunifuCustomControl.initializeComponent(this);
		}

		public void abortScan()
		{
		}

		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			string[] directories;
			int i;
			List<string> strs = new List<string>()
			{
				this.path
			};
			this.Folders.Add(new DirectoryInfo(this.path));
			while (strs.Count > 0)
			{
				this.curFolder = strs[0];
				if (this.eventHandler_2 != null)
				{
					base.Invoke(new Action(() => this.eventHandler_2(this, null)));
				}
				try
				{
					directories = Directory.GetDirectories(this.curFolder);
					for (i = 0; i < (int)directories.Length; i++)
					{
						strs.Add(directories[i]);
					}
				}
				catch (Exception exception)
				{
					this.lastError = exception.Message;
					if (this.eventHandler_1 != null)
					{
						base.Invoke(new Action(() => this.eventHandler_1(this, null)));
					}
				}
				try
				{
					directories = Directory.GetFiles(this.curFolder);
					for (i = 0; i < (int)directories.Length; i++)
					{
						this.curFile = directories[i];
						this.Files.Add(new FileInfo(this.curFile));
						if (this.eventHandler_0 != null)
						{
							base.Invoke(new Action(() => this.eventHandler_0(this, null)));
						}
					}
				}
				catch (Exception exception1)
				{
					this.lastError = exception1.Message;
					if (this.eventHandler_1 != null)
					{
						base.Invoke(new Action(() => this.eventHandler_1(this, null)));
					}
				}
				strs.RemoveAt(0);
			}
		}

		private void backgroundWorker_0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (this.eventHandler_5 == null)
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
				this.eventHandler_5(this, null);
			}
		}

		private void BunifuSearchEngine_Load(object sender, EventArgs e)
		{
			int num = 0;
			int num1 = 0;
			int num2;
			if (!base.DesignMode)
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
				BunifuCustomControl.initializeComponent(this);
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

		private void InitializeComponent()
		{
			this.backgroundWorker_0 = new BackgroundWorker();
			base.SuspendLayout();
			this.backgroundWorker_0.WorkerReportsProgress = true;
			this.backgroundWorker_0.WorkerSupportsCancellation = true;
			this.backgroundWorker_0.DoWork += new DoWorkEventHandler(this.backgroundWorker_0_DoWork);
			this.backgroundWorker_0.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorker_0_ProgressChanged);
			this.backgroundWorker_0.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorker_0_RunWorkerCompleted);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			this.DoubleBuffered = true;
			base.Name = "BunifuSearchEngine";
			base.Size = new System.Drawing.Size(43, 44);
			base.Load += new EventHandler(this.BunifuSearchEngine_Load);
			base.ResumeLayout(false);
		}

		public void restartScan()
		{
		}

		public void startScan(string _path)
		{
			this.path = _path;
			if (!this.backgroundWorker_0.IsBusy)
			{
				this.backgroundWorker_0.RunWorkerAsync();
				return;
			}
			MessageBox.Show("Scan Engine Busy");
		}

		public event EventHandler onAborted
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

		public event EventHandler onFailed
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

		public event EventHandler onFileScan
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

		public event EventHandler onFolderScan
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

		public event EventHandler onScanComplete
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

		public event EventHandler onScanError
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
	}
}