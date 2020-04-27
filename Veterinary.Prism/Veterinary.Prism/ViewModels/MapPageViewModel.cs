using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Veterinary.Prism.ViewModels
{
	public class MapPageViewModel : ViewModelBase
	{
        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Map";
        }
	}
}
