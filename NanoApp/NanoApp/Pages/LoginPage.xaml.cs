using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NanoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void Entrar()
        {
            App.Current.MainPage = new MasterDetailPage() { Master= new ContentPage() { Title="ContentPage"}, Detail=new NavigationPage(new Homepage()) { BarTextColor=Color.White,BarBackgroundColor=Color.FromHex("#D49000") } };
        }

        private void FlexButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}