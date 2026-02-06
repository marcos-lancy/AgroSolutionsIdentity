namespace AgroSolutions.Identity.Service.Application.Dtos.Produtor;

public class CadastrarProdutorDto
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string ConfirmaSenha { get; set; } = string.Empty;
}
