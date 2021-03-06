﻿using NanoApp.Pages;
using System;
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
            try
            {
                Settings.Cargo = "";
                Settings.Motorista = "";
                Settings.Obra = "";
                Settings.Senha = "";
                Settings.Tipo = "";
                Settings.UserName = "";
                Navigation.PopAsync();
                App.Current.MainPage= new NavigationPage(new LoginPage());
                
            }
            catch(Exception ex)
            {
                DisplayAlert("A", ex.ToString(), "OK");
            }
        }

        private void CarButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormCarroPage());
        }
    }
}