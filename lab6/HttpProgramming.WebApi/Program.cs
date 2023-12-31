using HttpProgramming.Model;
using HttpProgramming.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new DateOnlyJSONSerializer());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register StudentsRepository as singleton in DI container
builder.Services.AddSingleton(_ => new StudentsRepository(1000));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.MapControllers();

app.Run();