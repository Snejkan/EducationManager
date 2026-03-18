using EducationManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Application.Interfaces;

public interface ICourseSessionRepository
{
    Task<CourseSession?> GetByIdAsync(Guid id);
    Task AddRegistrationAsync(Registration registration);
    Task SaveChangesAsync();
}
