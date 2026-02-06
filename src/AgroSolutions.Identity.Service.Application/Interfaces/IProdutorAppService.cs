using AgroSolutions.Identity.Service.Application.Dtos.Produtor;

namespace AgroSolutions.Identity.Service.Application.Interfaces;

public interface IProdutorAppService
{
    Task<ProdutorDto> CadastrarAsync(CadastrarProdutorDto dto);
    Task<string> EfetuarLoginAsync(string email, string senha);
}
