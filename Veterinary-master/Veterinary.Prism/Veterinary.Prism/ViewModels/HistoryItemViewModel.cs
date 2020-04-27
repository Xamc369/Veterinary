using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Veterinary.Models;

namespace Veterinary.Prism.ViewModels
{
    public class HistoryItemViewModel : HistoryResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectHistoryCommand;

        public HistoryItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectHistoryCommand => _selectHistoryCommand ?? (_selectHistoryCommand = new DelegateCommand(SelectHistory));

        private async void SelectHistory()
        {
            var parameters = new NavigationParameters();
            parameters.Add("history", this);
            await _navigationService.NavigateAsync("HistoryPage", parameters);
        }
    }
}
