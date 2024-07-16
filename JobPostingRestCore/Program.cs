using ClassLibrary1.Models;
using ClassLibrary1.Models.jobposting;
using ClassLibrary1.Services;
using FluentValidation;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<jobpostingContext>();
builder.Services.AddDbContext<PersonaleContext>();
builder.Services.AddTransient<IJobPostingCandidature, JobPostingCandidatureService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<ConfermaCandidatura>, ConfermaCandidaturaValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/", () => "CIAOOOOOOO!!!!").ExcludeFromDescription();




app.MapGet("/getCandidature/{matricola}", (IJobPostingCandidature db, string matricola) =>
{
    var risultato = db.Candidature(matricola);
    if (risultato.Any())
    {
        return Results.Json(risultato);
    }
    return Results.NoContent();

}).Produces<JobPostingCandidatureMatricola>(StatusCodes.Status200OK)
.WithTags("GetCandidature");




app.MapPost("/ConfermaCandidatura", async (HttpRequest Request, IValidator<ConfermaCandidatura> validator, IJobPostingCandidature db) =>
{
    string rawContent = string.Empty;
    using (var reader = new StreamReader(Request.Body,
                    encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
    {
        rawContent = await reader.ReadToEndAsync();
    }
    if (rawContent.Length > 0)
    {
        try
        {
            var confermaCandidatura = JsonSerializer.Deserialize<ConfermaCandidatura>(rawContent, new JsonSerializerOptions { AllowTrailingCommas = true });
            var validazione = validator.Validate(confermaCandidatura??new());
            if (!validazione.IsValid)
            {
                return Results.ValidationProblem(validazione.ToDictionary());
            }
            if (db.Insert(confermaCandidatura ?? new()))
            {
                return Results.Json(confermaCandidatura);
            }
            return Results.Content("Candidatura già presente a sistema");
        }
        catch (Exception ex)
        {
            return Results.Json(ex.Message);
        }
        
    }
    return Results.BadRequest();
}).Accepts<ConfermaCandidatura>("application/json").ProducesValidationProblem(StatusCodes.Status400BadRequest);




app.Run();

