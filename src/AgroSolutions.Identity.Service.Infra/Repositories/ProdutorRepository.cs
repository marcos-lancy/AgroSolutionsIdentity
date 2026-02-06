using AgroSolutions.Identity.Service.Domain.Entities;
using AgroSolutions.Identity.Service.Domain.Interfaces;
using AgroSolutions.Identity.Service.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AgroSolutions.Identity.Service.Infra.Repositories;

public class ProdutorRepository(AppDbContext context) : Repository<ProdutorEntity>(context), IProdutorRepository
{
    public async Task<ProdutorEntity?> ObterPorEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}
