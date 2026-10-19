//using Android.Telecom;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui;

namespace TentativeC971
{
    public partial class MainViewModel : BaseViewModel
    {

        [RelayCommand]
        public async Task GoToTermDetails(Term selectedTerm)
        {
            await Shell.Current.GoToAsync(nameof(TermDetailsPage), true,
                new Dictionary<string, object>
                {
                    {"Term", selectedTerm }
                });
        }


        public MainViewModel()
        {

        }
    }
}
