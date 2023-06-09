using Microsoft.EntityFrameworkCore;
using Keeper.Context.Config;
using Keeper.Repos.Config;
using Keeper.Services.Config;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string ConnectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.RegisterDbContext(ConnectionString);
builder.Services.RegisterRepos();
builder.Services.RegisterServices();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.SuppressModelStateInvalidFilter = true; 
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
