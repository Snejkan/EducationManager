using EducationManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Application.UseCases;

public class RegisterParticipant
{
    private readonly ICourseSessionRepository _repository;

    public RegisterParticipant(ICourseSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task Execute(Guid sessionId, Guid participantId)
    {
        var session = await _repository.GetByIdAsync(sessionId);

        if (session == null)
        {
            throw new Exception("Session not found");
        }

        session.Register(participantId);

        await _repository.SaveChangesAsync();
    }
}
