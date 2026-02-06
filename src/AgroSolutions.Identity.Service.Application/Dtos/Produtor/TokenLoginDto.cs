namespace AgroSolutions.Identity.Service.Application.Dtos.Produtor;

public class TokenLoginDto
{
    public string Token { get; set; } = string.Empty;

    public TokenLoginDto(string token)
    {
        Token = token;
    }
}
