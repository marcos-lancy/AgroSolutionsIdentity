namespace AgroSolutions.Identity.Service.Application.Interfaces;

public interface IJwtAppService
{
    string GerarToken(Guid idProdutor, string email, string role);
}
