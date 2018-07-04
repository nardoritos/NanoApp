using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace NanoApp
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public string Obra { get; set; }
        public string Motorista { get; set; }
        public string Tipo { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public bool IsLoading;
        public string URL { get; set; }
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Usuario> _usuarios;

        public LoginPage()
        {
            InitializeComponent();
            IsLoading = true;

            CheckInfo();
        }

        async void CheckInfo()
        {
            if (Settings.UserName !="" && Settings.Senha != "")
            {
                try
                {
                    URL = "https://nanoapp.000webhostapp.com/API.php?nome=" + Settings.UserName + "&senha=" + Settings.Senha;
                    IsLoading = true;
                    await Carregar();
                }
                catch (Exception)
                {
                    IsLoading = false;
                    await DisplayAlert("Erro ao conectar", "Digite novamente seus dados", "OK");
                }
            }
        }

        async void Entrar()
        {
            URL = "https://nanoapp.000webhostapp.com/API.php?nome=" + Login.Text + "&senha=" + Senha.Text;
            IsLoading = true;
            await Carregar();
        }

        private async Task Carregar()
        {
            try
            {
                var content = await _client.GetStringAsync(URL);
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);

                _usuarios = new ObservableCollection<Usuario>(usuarios);
                if (_usuarios.Count > 0)
                {
                    Settings.UserName = _usuarios[0].Nome;
                    Settings.Senha = _usuarios[0].Senha;
                    Settings.Cargo = _usuarios[0].Cargo;
                    Settings.Obra = _usuarios[0].Obra;
                    Settings.Motorista = _usuarios[0].Motorista;
                    Settings.Tipo = _usuarios[0].Tipo;

                    var newPage = new MasterDetailPage() { Master = new ContentPage() { Title = "ContentPage" }, Detail = new NavigationPage(new Homepage()) { BarTextColor = Color.White, BarBackgroundColor = Color.FromHex("#D49000") } };
                    App.Current.MainPage = newPage;
                }
            }
            catch (Exception)
            {
                IsLoading = false;
                await DisplayAlert("Erro ao conectar", "Digite novamente seus dados", "OK");

            }
        }
    }
}