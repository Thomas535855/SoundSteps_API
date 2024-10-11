using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoundSteps.DAL;
using SoundSteps.DAL.DALs;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Containers;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("SoundStepsDb");

// Add services to the container
builder.Services.AddScoped<UserContainer>();
builder.Services.AddScoped<IUserDAL, UserDAL>();

// Register the DbContext and configure it to use SQL Server
builder.Services.AddDbContext<SoundStepsDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SoundSteps.DAL"))
);

// Add controllers
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:8080") // Vue app link
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowVueApp");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
