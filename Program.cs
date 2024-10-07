using Archi.AppUserManagement.Business;
using Archi.AppUserManagement.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserManagementDbContext>(
            options =>
            {
                options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ArchiUserManagement;Integrated Security=true;TrustServerCertificate=true", o => o.EnableRetryOnFailure());

            }, ServiceLifetime.Singleton);
builder.Services.AddTransient<UsersService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
