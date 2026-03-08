using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }

    public Course(string title)
    {
        Title = title;
    }
}
