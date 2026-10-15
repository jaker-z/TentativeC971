using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using IntelliJ.Lang.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TentativeC971
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel() { }

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
            string termName = await Shell.Current.DisplayPromptAsync("Enter Term Name: ", "What will your term name be called?");

            if (termName != string.Empty)
            {
                Term newTerm = new Term()
                {
                    Name = termName
                };

                Terms.Add(newTerm);
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
