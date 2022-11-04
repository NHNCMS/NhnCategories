using FluentValidation;
using NhnCommon.Models;

namespace NhnCommon.Modules
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class BrewUpModule : IModule
    {
        public bool IsEnabled => true;
        public int Order => 0;

        /// <summary>
        /// 
        /// </summary>
        public IServiceCollection RegisterModule(WebApplicationBuilder builder)
        {
            return builder.Services;
        }

        /// <summary>
        /// 
        /// </summary>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/brewup", HandleSayHelloAsync)
                .Produces(StatusCodes.Status202Accepted)
                .ProducesValidationProblem()
                .WithName("GetHelloParameters")
                .WithTags("BrewUp");

            return endpoints;
        }

        private static async Task<IResult> HandleSayHelloAsync(HelloRequest helloRequest,
            IValidator<HelloRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(helloRequest);
            if (validationResult.IsValid)
                return Results.Ok($"Hello {helloRequest.Name} from BrewUp");

            var errors = validationResult.Errors.GroupBy(e => e.PropertyName)
                .ToDictionary(k => k.Key, v => v.Select(e => e.ErrorMessage).ToArray());

            return Results.ValidationProblem(errors);
        }
    }
}