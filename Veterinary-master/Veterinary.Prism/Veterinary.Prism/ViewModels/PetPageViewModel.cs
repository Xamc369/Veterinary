﻿using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinary.Common.Helpers;
using Veterinary.Models;

namespace Veterinary.Prism.ViewModels
{
	public class PetPageViewModel : ViewModelBase
	{
        private PetResponse _pet;

        public PetPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Details";
        }

        public PetResponse Pet
        {
            get => _pet;
            set => SetProperty(ref _pet, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);  
        }
    }
}