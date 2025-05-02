using BuberDinner.Api.Common.Http;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using ErrorOr;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddProblemDetails(options =>
    {
        options.CustomizeProblemDetails = (context) =>
        {
            var errors = context.HttpContext.Items[HttpContextItemKeys.Errors] as List<Error>;

            if (errors is not null)
            {
                context.ProblemDetails.Extensions.Add("errorCodes", errors.Select(e => e.Code));
            }
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

