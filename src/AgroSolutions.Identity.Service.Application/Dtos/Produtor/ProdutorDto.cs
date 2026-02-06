using AgroSolutions.Identity.Service.Domain.Enums;

namespace AgroSolutions.Identity.Service.Application.Dtos.Produtor;

public class ProdutorDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public RoleEnum Role { get; set; }
}
