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
        public ObservableCollection<Term> Terms { get; set; } = new();
        public List<string> things;

        public BaseViewModel()
        {
            //_popupService = popupService;
            things = ["Six", "Seven", "Apples", "Oranges"];

            Term oneTerm = new Term(1);
            Term anotherTerm = new Term(2);
            Term lastTerm = new Term(3);

            Course course1 = new Course()
            {
                Id = 6,
                Name = "C971 Mobile App Development",
                Description = "Some kind of class where you make apps but on mobile devices."
            };

            Course course2 = new Course()
            {
                Id = 7,
                Name = "D282 Auror Attunement",
                Description = "Learn how to fine tune your Auror skills. Additional skills on hold."
            };

            Course course3 = new Course()
            {
                Id = 8,
                Name = "B101 Defense Against the Dark Arts",
                Description = "Harry Potter must not return to Hogwarts this year! The chamber of secrets has been opened."
            };

            Course course4 = new Course()
            {
                Id = 9,
                Name = "C671 Divination",
                Description = "Fine boy, boy for sale. He's going cheap, only seven guineas."
            };

            oneTerm.AddCourse(course1);
            oneTerm.AddCourse(course2);
            oneTerm.AddCourse(course3);
            oneTerm.AddCourse(course4);
            oneTerm.AddCourse(course2);
            oneTerm.AddCourse(course3);

            anotherTerm.AddCourse(course3);
            anotherTerm.AddCourse(course4);

            lastTerm.AddCourse(course1);
            lastTerm.AddCourse(course4);

            Terms.Add(oneTerm);
            Terms.Add(anotherTerm);
            Terms.Add(lastTerm);
        }

        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(IsNotBusy))]
        //bool isBusy;

        //[ObservableProperty]
        //string title;

        //public bool IsNotBusy => !IsBusy;







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

                await Shell.Current.DisplayAlertAsync("CAUTION 2", $"{result.Result.Name}", "Okay");
                await Shell.Current.DisplayAlertAsync("CAUTION 3", $"{selectedTerm.Name}", "Okay");

                int index = Terms.IndexOf(selectedTerm);

                await Shell.Current.DisplayAlertAsync("CAUTION 3", $"{index}", "Okay");

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
