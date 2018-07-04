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
using System.ComponentModel;
using Xamanimation;

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
    public partial class LoginPage : ContentPage, INotifyPropertyChanged
    {
        public string URL { get; set; }
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Usuario> _usuarios;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
            CheckInfo();
        }
        public void ValorIsLoading(bool valor)
        {
            IsLoading = valor;
        }
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        async void CheckInfo()
        {
            if (Settings.UserName !="" && Settings.Senha != "")
            {
                try
                {
                    LoadFull(Settings.UserName, Settings.Senha);
                }
                catch (Exception)
                {
                    ValorIsLoading(false);
                    await DisplayAlert("Erro ao conectar", "Digite novamente seus dados", "OK");
                }
            }
        }

        void Entrar()
        {
            LoadFull(Login.Text,Senha.Text);

        }
        
        async void LoadFull(string login, string senha)
        {
            ValorIsLoading(true);
            await Layout.FadeTo(1, 300);

            URL = "https://nanoapp.000webhostapp.com/API.php?nome=" + login + "&senha=" + senha;
            await Carregar();
            await Layout.FadeTo(0, 1);
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
            catch (Exception ex)
            {
                IsLoading = false;
                await DisplayAlert("Erro ao conectar", ex.ToString(), "OK");
                ValorIsLoading(false);
            }
        }
    }
}