using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Domain.Entities;

public class Registration
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ParticipantId { get; private set; }
    public Guid CourseSessionId { get; private set; }

    public Registration(Guid participantId, Guid sessionId)
    {
        ParticipantId = participantId;
        CourseSessionId = sessionId;
    }
}
