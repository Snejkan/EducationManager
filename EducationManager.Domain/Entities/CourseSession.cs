using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Domain.Entities;

public class CourseSession
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CourseId { get; private set; }
    public int MaxParticipants { get; private set; }

    private readonly List<Registration> _registrations = new();
    public IReadOnlyCollection<Registration> Registrations => _registrations;

    public CourseSession(Guid courseId, int maxParticipants)
    {
        CourseId = courseId;
        MaxParticipants = maxParticipants;
    }

    public void Register(Guid participantId)
    {
        if (_registrations.Count >= MaxParticipants)
            throw new InvalidOperationException("Course is full");

        _registrations.Add(new Registration(participantId, Id));
    }
}
