using KeeperCore.Repositories;
using KeeperCore.Repositories.Interfaces;
using KeeperCore.Services;
using KeeperCore.Services.Interfaces;
using KeeperDbContext;
using KeeperMain.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string ConnectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.RegisterDbContext(ConnectionString);
builder.Services.RegisterCore();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
