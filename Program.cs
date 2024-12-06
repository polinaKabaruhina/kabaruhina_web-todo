using Microsoft.EntityFrameworkCore;
using Todo.Data.DAL;
using Todo.Data.DAL.Repositories.Implementations;
using Todo.Data.DAL.Repositories.Interfaces;
using Todo.Data.Mapping;
using Todo.Data.Services.Implementations;
using Todo.Data.Services.Interfaces;


DotNetEnv.Env.Load("./.env");
var env = Environment.GetEnvironmentVariables();
string connectionsString = $"Host={env["DB_HOST"]};Port={env["DB_PORT"]};Database={env["DB_DATABASE"]};Username={env["DB_USER"]};Password={env["DB_PASS"]}";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(op => op.UseNpgsql(connectionsString));
builder.Services.AddTransient<AutoMapperCreator>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
app.MapControllers();
app.Run();
