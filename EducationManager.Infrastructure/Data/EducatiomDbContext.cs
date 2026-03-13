using EducationManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationManager.Infrastructure.Data;

public class EducationDbContext : DbContext
{
    public EducationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Participant> Participants { get; set; }

    public DbSet<CourseSession> CourseSessions { get; set; }

    public DbSet<Registration> Registrations { get; set; }
}

