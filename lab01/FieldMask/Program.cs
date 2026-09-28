using FieldMask;
using FieldMask.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IVaccineRepository, VaccineRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/vaccines", (
    [AsParameters] VaccineFieldMask mask,
    IVaccineRepository vaccineRepository) =>
{
    var records = vaccineRepository.GetAllRecords();

    var result = records.Select(vaccine =>
        VaccineHelpers.GetVaccinesByMask(vaccine, mask));
    
    return Results.Ok(result);
});

app.Run();