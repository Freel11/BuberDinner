using BuberDinner.Api.Common.Http;
using BuberDinner.Api.Common.Mapping;
using ErrorOr;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails(options =>
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
        services.AddMappings();

        return services;
    }
}