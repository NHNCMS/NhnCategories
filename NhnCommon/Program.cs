using FluentValidation;
using FluentValidation.AspNetCore;
using NhnCommon.Modules;
using NhnCommon.Validators;

var builder = WebApplication.CreateBuilder(args);

// Register Modules
builder.RegisterModules();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<SayHelloValidator>();

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

// Register endpoints
app.MapEndpoints();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseSwagger(s =>
    {
        s.RouteTemplate = "documentation/{documentName}/documentation.json";
    });
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/documentation/v1/documentation.json", "NHN Common API");
        s.RoutePrefix = "documentation";
    });
}

app.Run();