using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Veterinary.Prism.ViewModels
{
	public class PetsPageViewModel : ViewModelBase
	{
        public PetsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Pets";
        }
	}
}
