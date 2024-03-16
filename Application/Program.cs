using Business.TrashDetection;
using Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddModel();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(TrashDetection).Assembly));

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
