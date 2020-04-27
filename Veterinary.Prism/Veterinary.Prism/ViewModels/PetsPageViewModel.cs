using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Veterinary.Common.Helpers;
using Veterinary.Common.Service;
using Veterinary.Models;

namespace Veterinary.Prism.ViewModels
{
    
	public class PetsPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private OwnerResponse _owner;
        private ObservableCollection<PetItemViewModel> _pets;

        public PetsPageViewModel(INavigationService navigationService,
                                 IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Pets";
            LoadOwner();

        }

        public ObservableCollection<PetItemViewModel> Pets
        {
            get => _pets;
            set => SetProperty(ref _pets, value);
        }


        private void LoadOwner()
        {
            _owner = JsonConvert.DeserializeObject<OwnerResponse>(Settings.Owner);
            Title = $"Pets of: {_owner.FirstName}";
            Pets = new ObservableCollection<PetItemViewModel>(_owner.Pets.Select(p => new PetItemViewModel(_navigationService)
            {
                Born = p.Born,
                Histories = p.Histories,
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                PetType = p.PetType,
                Race = p.Race,
                Remarks = p.Remarks,

            }).ToList());
        }
    }
}
