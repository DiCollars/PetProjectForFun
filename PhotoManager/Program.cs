using BLL.Data;
using Mapper;
using BLL.Services.HashPasswordService;
using BLL.Services.TokenService;
using BLL.Services.UserService;
using DAL.Data;
using DAL.Repositories.UserRepository;
using DAL.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PhotoManager.SwaggerObjects;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(options =>
                  {
                      options.RequireHttpsMetadata = false;

                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidIssuer = AuthOptions.ISSUER,
                          ValidateAudience = true,
                          ValidAudience = AuthOptions.AUDIENCE,
                          ValidateLifetime = true,
                          IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                          ValidateIssuerSigningKey = true,
                      };
                  });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhotoManager", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Scheme = "bearer",
        Description = "nup-nup!"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
     });
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(connection));

builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IHashPasswordService, HashPasswordService>();
builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var swaggerOptions = new SwaggerOptions();
    builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

    app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

    app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description); });
}

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
