using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;


namespace TentativeC971
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<Term> Terms { get; set; } = new();

        public MainViewModel()
        {
            string anotherTermName = "Term Jethrome";
            Term oneTerm = new Term();
            Term anotherTerm = new Term(anotherTermName);
            Term lastTerm = new Term();

            Terms.Add(oneTerm);
            Terms.Add(anotherTerm);
            Terms.Add(lastTerm);
        }
    }
}
