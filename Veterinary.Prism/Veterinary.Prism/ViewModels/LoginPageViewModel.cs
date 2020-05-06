using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinary.Common.Helpers;
using Veterinary.Common.Models;
using Veterinary.Common.Service;
using Veterinary.Models;
using Veterinary.Prism.Helpers;
using Xamarin.Forms;

namespace Veterinary.Prism.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        

        //ATRIBUTOS PRIVADOS
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private DelegateCommand _registerCommand;
        private DelegateCommand _forgotPasswordCommand;

        //CONSTRUCTOR
        public LoginPageViewModel(INavigationService navigationService,
                                  IApiService apiService) : base (navigationService)
        {
            Title = "Login";
            IsEnabled = true;
            IsRemember = true;
            _navigationService = navigationService;
            _apiService = apiService;
        }

        //PROPIEDADES
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));
        public DelegateCommand ForgotPasswordCommand => _forgotPasswordCommand ?? (_forgotPasswordCommand = new DelegateCommand(ForgotPassword));

        public DelegateCommand RegisterCommand => _registerCommand ?? (_registerCommand = new DelegateCommand(Register));

        private bool _isRemember;
        public bool IsRemember
        {
            get => _isRemember;
            set => SetProperty(ref _isRemember, value);
        }

        public string Email { get; set; }

        //se hace cuando las propiedades tienen un cambio en la viewmodel y se 
        //va a ver reflejado en la interfaz de usuario
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        //METODOS PUBLICOS

        //METODOS PRIVADOS
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.EmailError, Languages.Accept);
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password", "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var url = App.Current.Resources["UrlAPI"].ToString();
            var connection = await _apiService.CheckConnection(url);
            if (!connection)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Check the internet connection.", "Accept");
                return;
            }


            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

           // var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "Account", "/CreateToken", request);
            // en acount /
            if (!response.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Email or password incorrect.", "Accept");
                Password = string.Empty;
                return;
            }
            //en api/
            var token = response.Result;
            var response2 = await _apiService.GetOwnerByEmailAsync(url,
                "api",
                "/Owners/GetOwnerByEmail",
                "bearer",
                token.Token,
                Email);

            if (!response2.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "This user have a problem, call support", "Accept");
                Password = string.Empty;
                return;
            }
            //(ownerresponse)

            var owner = response2.Result;

            Settings.Owner = JsonConvert.SerializeObject(owner);
            Settings.Token = JsonConvert.SerializeObject(token);
            Settings.IsRemembered = IsRemember;

            IsRunning = false;
            IsEnabled = true;

            //await App.Current.MainPage.DisplayAlert("Ok", "Fuck Yeahh!!", "Accept");
            //await _navigationService.NavigateAsync("PetsPage");
            await _navigationService.NavigateAsync("/VeterinaryMasterDetailPage/NavigationPage/PetsPage");
            Password = string.Empty;
        }

        private async void Register()
        {
            await _navigationService.NavigateAsync("RegisterPage");
        }

        private async void ForgotPassword()
        {
            await _navigationService.NavigateAsync("RememberPasswordPage");
        }
    }
}
