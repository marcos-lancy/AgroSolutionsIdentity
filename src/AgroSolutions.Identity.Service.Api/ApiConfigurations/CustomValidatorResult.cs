using AgroSolutions.Identity.Service.Domain.Exceptions.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using System.Net;

namespace AgroSolutions.Identity.Service.Api.ApiConfigurations;

public class CustomValidatorResult : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
    {
        Dictionary<string, string[]>? errors = null;
        if (validationProblemDetails?.Errors != null)
        {
            errors = validationProblemDetails.Errors.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ToArray());
        }

        return new BadRequestObjectResult(
            new ErrorResponse(
                (int)HttpStatusCode.BadRequest,
                "Erros de validação",
                errors));
    }
}
