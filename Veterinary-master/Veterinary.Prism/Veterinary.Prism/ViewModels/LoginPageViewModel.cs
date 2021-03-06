﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinary.Common.Models;
using Veterinary.Common.Service;
using Veterinary.Models;

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

        //CONSTRUCTOR
        public LoginPageViewModel(INavigationService navigationService,
                                  IApiService apiService) : base (navigationService)
        {
            Title = "Login";
            IsEnabled = true;
            _navigationService = navigationService;
            _apiService = apiService;
        }

        //PROPIEDADES
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));


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
                await App.Current.MainPage.DisplayAlert("Error","You must enter an email","Accept");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password", "Accept");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "/Account", "/CreateToken", request);

            if (!response.IsSuccess)
            {
                IsEnabled = true;
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Error", "Email or password incorrect.", "Accept");
                Password = string.Empty;
                return;
            }

            var token = (TokenResponse)response.Result;
            var response2 = await _apiService.GetOwnerByEmailAsync(url,
                "/api",
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

            var owner = (OwnerResponse)response2.Result;
            var parameters = new NavigationParameters
            {
                {"owner", owner }
            };


            IsRunning = false;
            IsEnabled = true;
            //await App.Current.MainPage.DisplayAlert("Ok", "Fuck Yeahh!!", "Accept");
            await _navigationService.NavigateAsync("PetsPage", parameters);
            Password = string.Empty;
        }
    }
}
