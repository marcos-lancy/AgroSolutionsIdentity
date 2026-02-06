using AgroSolutions.Identity.Service.Domain.Enums;

namespace AgroSolutions.Identity.Service.Domain.Entities;

public class ProdutorEntity : EntityBase
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string SenhaHash { get; set; } = string.Empty;

    public RoleEnum Role { get; set; } = RoleEnum.Produtor;

    public ProdutorEntity()
    {
    }

    public ProdutorEntity(
        Guid id,
        string nome,
        string email,
        string senhaHash,
        RoleEnum role)
    {
        Id = id;
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        Role = role;
    }
}
