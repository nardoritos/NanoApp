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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
           
		}

        private void Entrar(object sender, EventArgs e)
        {
            App.Current.MainPage = new MasterDetailPage() { Master= new ContentPage() { Title="ContentPage"}, Detail=new NavigationPage(new Homepage()) { BarTextColor=Color.White,BarBackgroundColor=Color.FromHex("#D49000") } };
        }
    }
}