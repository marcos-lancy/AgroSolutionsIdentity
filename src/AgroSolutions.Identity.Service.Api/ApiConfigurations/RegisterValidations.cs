using AgroSolutions.Identity.Service.Application.Dtos.Produtor.Validations;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace AgroSolutions.Identity.Service.Api.ApiConfigurations;

public static class RegisterValidations
{
    public static IServiceCollection AddAbstractValidations(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CadastrarProdutorDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(EfetuarLoginDtoValidator).Assembly);
        
        services.AddFluentValidationAutoValidation(options =>
        {
            options.OverrideDefaultResultFactoryWith<CustomValidatorResult>();
        });
        
        return services;
    }
}
