using Newtonsoft.Json;
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
	public class PetTabbedPageViewModel : ViewModelBase
	{
        public PetTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            var pet = JsonConvert.DeserializeObject<PetResponse>(Settings.Pet);
            Title = $"Pet: {pet.Name}";
        }
	}
}
