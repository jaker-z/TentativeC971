using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TentativeC971
{
    public partial class TermPopupViewModel : ObservableObject
    {
        private readonly IPopupService _popupService;

        [ObservableProperty]
        private string fieldOne = string.Empty;

        [ObservableProperty]
        private string fieldTwo = string.Empty;

        [ObservableProperty]
        private string fieldThree = string.Empty;

        public TermPopupViewModel(IPopupService popupService)
        {
            _popupService = popupService;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            var result = new MultiEntryResult(FieldOne, FieldTwo, FieldThree);
            //await _popupService.ClosePopupAsync(result);

        }
    }

    public record MultiEntryResult(string Value1, string Value2, string Value3);
}
