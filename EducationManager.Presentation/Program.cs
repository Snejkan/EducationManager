using EducationManager.Application.UseCases;
using EducationManager.Infrastructure.Data;
using EducationManager.Infrastructure.Repositories;
using EducationManager.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using EducationManager.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<EducationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICourseSessionRepository, CourseSessionRepository>();
builder.Services.AddScoped<RegisterParticipant>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();



app.MapPost("/sessions/{id}/register", async (
    Guid id,
    Guid participantId,
    RegisterParticipant useCase) =>
{
    await useCase.Execute(id, participantId);

    return Results.Ok("Participant registered");
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EducationDbContext>();

    if (!db.Courses.Any())
    {
        var course = new Course("Programming Basics");
        db.Courses.Add(course);

        var session = new CourseSession(course.Id, 10);
        db.CourseSessions.Add(session);

        db.SaveChanges();
    }
}

app.Run();
