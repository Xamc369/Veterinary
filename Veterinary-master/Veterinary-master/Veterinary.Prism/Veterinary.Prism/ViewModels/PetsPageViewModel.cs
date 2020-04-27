using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Veterinary.Models;

namespace Veterinary.Prism.ViewModels
{
    
	public class PetsPageViewModel : ViewModelBase
	{
        private OwnerResponse _owner;

        public PetsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Pets";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("owner"))
            {
                _owner = parameters.GetValue<OwnerResponse>("owner");
            }

        }
    }
}
