var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

// Structure of Middleware Pipeline 

//app.UseHttpsRedirection(); //Middleware Component - 1

app.UseRouting(); //Middleware Component - 2

//app.UseAuthentication(); //Middleware Component - 3

//app.UseAuthorization(); //Middleware Component - 4

// ***** ***** ***** ***** //

app.MapControllers();

app.Run();


