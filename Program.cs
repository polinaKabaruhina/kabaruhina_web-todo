using Microsoft.EntityFrameworkCore;
using Todo.Data.DAL;
using Todo.Data.DAL.Repositories.Implementations;
using Todo.Data.DAL.Repositories.Interfaces;
using Todo.Data.Mapping;
using Todo.Data.Services.Implementations;
using Todo.Data.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(op => op.UseMySql(builder.Configuration.GetConnectionString("MySQLConnectionString"), new MySqlServerVersion(new Version(8,0,32))));
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
