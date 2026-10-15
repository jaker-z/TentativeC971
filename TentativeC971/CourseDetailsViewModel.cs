using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TentativeC971
{
    [QueryProperty(nameof(ThisCourse), "Course")]
    public partial class CourseDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Course thisCourse;

    }
}
