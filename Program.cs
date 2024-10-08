using Archi.AppBankAccountManagement.External;
using Archi.AppUserManagement.Application;
using Archi.AppUserManagement.Application.SharedService;
using Archi.AppUserManagement.Application.User.Commands.AddUserCommand;
using Archi.AppUserManagement.Application.User.Commands.DeleteUserCommand;
using Archi.AppUserManagement.Application.User.Commands.UpdateUserCommand;
using Archi.AppUserManagement.Application.User.Queries.GetAllUserQuery;
using Archi.AppUserManagement.Application.User.Queries.GetUserByIdQuery;
using Archi.AppUserManagement.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserManagementDbContext>(
            options =>
            {
                options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ArchiUserManagement;Integrated Security=true;TrustServerCertificate=true", o => o.EnableRetryOnFailure());

            }, ServiceLifetime.Singleton);
builder.Services.AddTransient<AddUserCommand>();
builder.Services.AddTransient<DeleteUserCommand>();
builder.Services.AddTransient<UpdateUserCommand>();
builder.Services.AddTransient<GetAllUserQuery>();
builder.Services.AddTransient<GetUserByIdQuery>();
builder.Services.AddTransient<BankAccountManagementServiceConnector>();

builder.Services.AddTransient<UsersService>();
builder.Services.AddTransient<ProfilesService>();
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
