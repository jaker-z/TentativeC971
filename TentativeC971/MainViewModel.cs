//using Android.Telecom;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.Input;

namespace TentativeC971
{
    public partial class MainViewModel : ObservableObject
    {
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
    }
}
