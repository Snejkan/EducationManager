using EducationManager.Application.Interfaces;
using EducationManager.Domain.Entities;
using EducationManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationManager.Infrastructure.Repositories;

public class CourseSessionRepository : ICourseSessionRepository
{
    private readonly EducationDbContext _context;

    public CourseSessionRepository(EducationDbContext context)
    {
        _context = context;
    }

    public async Task<CourseSession?> GetByIdAsync(Guid id)
    {
        return await _context.CourseSessions
            .Include(x => x.Registrations)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
