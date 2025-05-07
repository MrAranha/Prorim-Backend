using FbSoft_Services.Repositories;
using FbSoft_Services.Services;
using FbSoft_MediatrHandling.EntityRequests.Users.AutoMapper;
using FbSoft_MediatrHandling.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FbSoft_MediatrHandling.EntityRequests.Users.Interfaces;
using FbSoft_Services.Queries.Users;
using FbSoft_Services.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Carros.Interfaces;
using FbSoft_Services.Queries.Carros;
using Microsoft.OpenApi.Models;
using FbSoft_Backend.Email;
using FbSoft_MediatrHandling.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<DbSession>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();

#region AddTransient
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IGetPagedUsersQuery, GetPagedUsersQuery>();
builder.Services.AddTransient<IGetPagedCarroQuery, GetPagedCarroQuery>();
#endregion

builder.Services.AddTransient<IFbSoftQuery, DottaQuery>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(IDefaultHandler).Assembly));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(o => o.AddDefaultPolicy(
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:3000", "http://localhost:3043")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      }));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Example API",
        Version = "v1",
        Description = "TESTE",
        Contact = new OpenApiContact
        {
            Name = "Concessionária",
            Email = "concessionaria.noreply@gmail.com"
        }
    });
});
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
