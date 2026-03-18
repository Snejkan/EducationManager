using EducationManager.Application.Interfaces;
using EducationManager.Domain.Entities;

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
            throw new Exception("Session not found");

        if (session.Registrations.Count >= session.MaxParticipants)
            throw new InvalidOperationException("Course is full");

        var registration = new Registration(participantId, sessionId);

        await _repository.AddRegistrationAsync(registration);
        await _repository.SaveChangesAsync();
    }
}
