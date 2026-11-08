using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore; 

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services
builder.Services.AddInfrastructure();

// Add core services
builder.Services.AddCore();

//Add controllers to the service collection
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(cfg => {}, typeof(ApplicationUserMapperProfile));

builder.Services.AddFluentValidationAutoValidation(config =>
{
   config.DisableDataAnnotationsValidation = false; 
});

var app = builder.Build();

app.UseMiddleware<ExceptionHadlingMIddleware>();
//routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization(); 

//Contorller routes
app.MapControllers();
app.Run();