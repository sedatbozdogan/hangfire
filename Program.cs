using Hangfire;
using HangfireBasicAuthenticationFilter;
using HangfireExample.Interfaces;
using HangfireExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("Database");
builder.Services.AddControllers();
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddHangfireServer();
builder.Services.AddScoped<IJobService, JobService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHangfireDashboard(
    pathMatch: "/hangfire",
    options: new DashboardOptions
    {
        DashboardTitle = "Hangfire Gösterge Ekranı",
        Authorization = new[]
        {
            new HangfireCustomBasicAuthenticationFilter
            {
                User="admin",
                Pass="admin"
            }
        }
    });
app.Run();
