using Microsoft.EntityFrameworkCore;
using OrisBackend.DbContexts;
using OrisBackend.Repositories;
using OrisBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrisDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
