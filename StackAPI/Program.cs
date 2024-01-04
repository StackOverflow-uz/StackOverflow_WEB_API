using AutoMapper;
using DataAccessLayer.DB;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Set DBContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalSqlServer")));
//builder.Services.AddIdentity<User, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();
#endregion

#region Repositories 
builder.Services.AddTransient<IAnswerInterface, AnswerRepository>();
builder.Services.AddTransient<ICommentInterface, CommentRepository>();
builder.Services.AddTransient<IQuestionInterface, QuestionRepository>();
builder.Services.AddTransient<IQuestionTagInterface, QuestionTagRepository>();
builder.Services.AddTransient<ISavedInterface, SavedRepository>();
builder.Services.AddTransient<ITagInterface, TagRepository>();
builder.Services.AddTransient<IUserInterface, UserRepository>();
builder.Services.AddTransient<IUnitOfWorkInterface, UnitOfWork>();
#endregion

#region Mapper 
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
