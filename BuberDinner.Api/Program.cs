using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddProblemDetails(options =>
    {
        options.CustomizeProblemDetails = (context) =>
        {
            context.ProblemDetails.Extensions.Add("Custom Property", "Custom Value");
        };
    });

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}

