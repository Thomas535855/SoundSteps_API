using Microsoft.EntityFrameworkCore;
using SoundSteps.API;
using SoundSteps.DAL;
using SoundSteps.DAL.DALs;
using SoundSteps.Interface.Interfaces;
using SoundSteps.Logic.Containers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SoundStepsDb");

// Add services to the container.
builder.Services.AddScoped<UserContainer>();
builder.Services.AddScoped<IUserDal, UserDal>();

builder.Services.AddScoped<InstrumentContainer>();
builder.Services.AddScoped<IInstrumentDal, InstrumentDal>();

builder.Services.AddDbContext<SoundStepsDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
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

// builder.WebHost.UseUrls("http://0.0.0.0:7295");

app.UseCors("AllowVueApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWebSockets();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        await WebSocketHandler.HandleWebSocketAsync(webSocket);
    }
    else
    {
        context.Response.StatusCode = 400;
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
