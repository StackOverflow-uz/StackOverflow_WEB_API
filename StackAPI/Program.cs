using Asp.Versioning;
using AutoMapper;
using DataAccessLayer.DB;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DTOs;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackAPI;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
const string CORS_POLICY = "AllowAll";

#region DBContext & DI Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "StackOverflow", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));
//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CORS_POLICY,
                             builder =>
                             {
                                 builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                             });
});
#endregion

#region Repositories & Services
builder.Services.AddTransient<IAnswerInterface, AnswerRepository>();
builder.Services.AddTransient<ICommentInterface, CommentRepository>();
builder.Services.AddTransient<IQuestionInterface, QuestionRepository>();
builder.Services.AddTransient<IQuestionTagInterface, QuestionTagRepository>();
builder.Services.AddTransient<ISavedInterface, SavedRepository>();
builder.Services.AddTransient<ITagInterface, TagRepository>();
builder.Services.AddTransient<IUnitOfWorkInterface, UnitOfWork>();

builder.Services.AddTransient<IAnswerService, AnswerService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
//builder.Services.AddTransient<IQuestionTagService, QuestionTagService>();
builder.Services.AddTransient<ISavedService, SavedService>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<IUserService, UserService>();
#endregion

#region Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
#endregion

#region Mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region JWT
var secretKey = builder.Configuration.GetSection("JWT:SecretKey").Value;
var key = Encoding.ASCII.GetBytes(secretKey!);
var issuer = builder.Configuration.GetSection("JWT:Issuer").Value;
var audience = builder.Configuration.GetSection("JWT:Audience").Value;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = ClaimTypes.Role
        };
    });
#endregion

#region API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
#endregion

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(CORS_POLICY);
app.UseAuthentication();
app.UseAuthorization();
var versionSet = app.NewApiVersionSet()
                            .HasApiVersion(new ApiVersion(1, 0))
                            .Build();
app.MapControllers().WithApiVersionSet(versionSet);
app.SeedRolesToDatabase();
app.Run();
