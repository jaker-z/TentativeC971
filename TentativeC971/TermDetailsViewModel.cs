using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TentativeC971
{
    [QueryProperty(nameof(ThisTerm), "Term")]
    public partial class TermDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        string welcomeText = "Welcome to the Term Details!";

        [ObservableProperty]
        Term thisTerm;

    }
}
