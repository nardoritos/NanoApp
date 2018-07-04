using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NanoApp
{
    
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Homepage : ContentPage
	{
       

		public Homepage ()
		{
			InitializeComponent ();
            UserName.Text = Settings.UserName;
            Cargo.Text = Settings.Cargo;
            Obra.Text = Settings.Obra;
		}

        private void PaintButton_Clicked(object sender, EventArgs e)
        {
            Settings.Cargo = "";
            Settings.Motorista = "";
            Settings.Obra = "";
            Settings.Senha = "";
            Settings.Tipo = "";
            Settings.UserName = "";
            App.Current.MainPage = new LoginPage();
        }
    }
}