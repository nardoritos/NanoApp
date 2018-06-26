using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NanoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sidenav : MasterDetailPage
	{
		public Sidenav ()
		{
			InitializeComponent ();
		}
	}
}