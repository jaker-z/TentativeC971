using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using IntelliJ.Lang.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Maui;

namespace TentativeC971
{
    public partial class BaseViewModel : ObservableObject
    {
        //private readonly IPopupService _popupService;

        public BaseViewModel()
        {
            //_popupService = popupService;
        }

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(IsNotBusy))]
        //bool isBusy;

        //[ObservableProperty]
        //string title;

        //public bool IsNotBusy => !IsBusy;





        public ObservableCollection<Term> Terms { get; set; } = new();

        [RelayCommand]
        public async Task AddTerm()
        {
            try
            {
                var vm = new TermDetailsViewModel();
                var termPopup = new TermPopup();
                IPopupResult<Term> result = await Shell.Current.ShowPopupAsync<Term>(termPopup);

                //await Shell.Current.DisplayAlertAsync("Consider this:", $"Check out this result!: {result.Result.Name}", "Okay");


                Terms.Add(result.Result);
                return;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error!", $"Something appears to have gone wrong. {ex.Message}", "Okay");
            }
        }

        [RelayCommand]
        public async Task EditTerm(Term selectedTerm)
        {
            try
            {
                var termPopup = new TermPopup(selectedTerm);
                IPopupResult<Term> result = await Shell.Current.ShowPopupAsync<Term>(termPopup);

                await Shell.Current.DisplayAlertAsync("CAUTION", $"{result.Result.Name}", "Okay");
                await Shell.Current.DisplayAlertAsync("CAUTION", $"{selectedTerm.Name}", "Okay");

                int index = Terms.IndexOf(selectedTerm);

                await Shell.Current.DisplayAlertAsync("CAUTION", $"{index}", "Okay");

                if (index != -1)
                {
                    Terms[index] = result.Result;
                }

                await Shell.Current.DisplayAlertAsync("CAUTION", $"{Terms[index]}", "Okay");

                return;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlertAsync("Error!", $"Something appears to have gone wrong. {ex.Message}", "Okay");
            }
        }


        [RelayCommand]
        public async Task AddCourse(Term selectedTerm)
        {
            string courseName = await Shell.Current.DisplayPromptAsync("Enter Course Name: ", "What will you name your course?");

            if (courseName != string.Empty)
            {
                Course newCourse = new Course()
                {
                    Name = courseName
                };

                selectedTerm.AddCourse(newCourse);
            }
        }

        [RelayCommand]
        public async Task GoToCourseDetails(Course selectedCourse)
        {
            await Shell.Current.GoToAsync(nameof(CourseDetailsPage), true,
                new Dictionary<string, object>
                {
                    {"Course", selectedCourse }
                });
        }

    }
}
