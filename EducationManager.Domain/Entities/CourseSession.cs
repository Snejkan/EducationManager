using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Domain.Entities;

public class Participant
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }

    public Participant(string name)
    {
        Name = name;
    }
}
