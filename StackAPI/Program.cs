using AutoMapper;
using DataAccessLayer.DB;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));
//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();
builder.Services.AddTransient<IAnswerInterface, AnswerRepository>();
builder.Services.AddTransient<ICommentInterface, CommentRepository>();
builder.Services.AddTransient<IQuestionInterface, QuestionRepository>();
builder.Services.AddTransient<IQuestionTagInterface, QuestionTagRepository>();
builder.Services.AddTransient<ISavedInterface, SavedRepository>();
builder.Services.AddTransient<ITagInterface, TagRepository>();
builder.Services.AddTransient<IUserInterface, UserRepository>();
builder.Services.AddTransient<IUnitOfWorkInterface, UnitOfWork>();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
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
