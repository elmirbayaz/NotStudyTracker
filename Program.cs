using Microsoft.EntityFrameworkCore;
using StudyTracker.Data;
using StudyTracker.Models;
using StudyTracker.Repositories;
using StudyTracker.Services;
using StudyTracker.ViewModelBuilders;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Host=localhost;Port=5432;Database=StudyTracker;Username=postgres;Password=13092005";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        connectionString,
        npgsqlOptions => npgsqlOptions.MapEnum<AssignmentStatus>()
    )
);

builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CoursesVmBuilder>();

builder.Services.AddScoped<AssignmentService>();
builder.Services.AddScoped<AssignmentRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
