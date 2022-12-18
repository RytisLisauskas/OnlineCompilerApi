using JDoodleHttpClient.Extensions;
using OnlineCompiler.Configurations;
using OnlineCompiler.Data;
using OnlineCompiler.Data.Repositories;
using OnlineCompiler.Helpers;
using OnlineCompiler.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICompilatingService, CompilatingService>();
builder.Services.AddJDoodleClient(x => new JDoodleClientConfiguration(builder.Configuration.GetSection("JDoodle")));
builder.Services.AddDbContext<OnlineCompilerDbContext>();
builder.Services.AddScoped<ICompilerRepo, CompilerRepo>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();


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
