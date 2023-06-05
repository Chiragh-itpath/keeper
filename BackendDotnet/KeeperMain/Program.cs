using KeeperCore.Repositories;
using KeeperCore.Repositories.Interfaces;
using KeeperCore.Services;
using KeeperCore.Services.Interfaces;
using KeeperDbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DbKeeperContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddScoped(typeof(IGenericRepo<>),typeof(GenericRepo<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
