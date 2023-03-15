using DefaultNamespace;
using hackatonBackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserAnswerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserAnswerContext") ?? throw new InvalidOperationException("Connection string 'UserAnswerContext' not found.")));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:5176").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            builder.WithOrigins("http://localhost:5176/Quiz").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            builder.WithOrigins("http://localhost:5176/UserAnswer").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            builder.WithOrigins("http://localhost:5176/User").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddScoped<IQuizClient, QuizClient>();
builder.Services.AddScoped<IUserAnswerRepository,UserAnswerRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IGameRepository,GameRepository>();
builder.Services.AddDbContext<UserAnswerContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("UserAnswerContext")
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();