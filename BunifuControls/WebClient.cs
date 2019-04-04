using System;
using System.ComponentModel;
using System.Net;

namespace Zeroit.Framework.Progress.CustomControls
{
	public class BunifuWebClient : WebClient
	{
		private IContainer icontainer_0;

		[Browsable(false)]
		public new bool AllowReadStreamBuffering
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Browsable(false)]
		public new bool AllowWriteStreamBuffering
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public BunifuWebClient()
		{
			this.method_0();
		}

		public BunifuWebClient(IContainer container)
		{
			container.Add(this);
			this.method_0();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_0()
		{
			this.icontainer_0 = new System.ComponentModel.Container();
		}
	}
}