using AgroSolutions.Identity.Service.Domain.Entities;

namespace AgroSolutions.Identity.Service.Domain.Interfaces;

public interface IProdutorRepository : IRepository<ProdutorEntity>
{
    Task<ProdutorEntity?> ObterPorEmailAsync(string email);
}
