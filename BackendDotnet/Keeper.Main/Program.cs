using Microsoft.EntityFrameworkCore;
using Keeper.Context.Config;
using Keeper.Repos.Config;
using Keeper.Services.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Keeper.Context.Model;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
    option.AddPolicy("Allow All", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterRepos();
builder.Services.RegisterServices();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(option =>
{

    option.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors("Allow All");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
