using AgroSolutions.Identity.Service.Domain.Entities;
using AgroSolutions.Identity.Service.Domain.Enums;
using AgroSolutions.Identity.Service.Domain.Exceptions;
using AgroSolutions.Identity.Service.Domain.Interfaces;
using AgroSolutions.Identity.Service.Application.Dtos.Produtor;
using AgroSolutions.Identity.Service.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace AgroSolutions.Identity.Service.Application.AppServices;

public class ProdutorAppService : IProdutorAppService
{
    private readonly IProdutorRepository _produtorRepository;
    private readonly IJwtAppService _jwtAppService;
    private readonly ILogger<ProdutorAppService> _logger;

    public ProdutorAppService(
        IProdutorRepository produtorRepository,
        IJwtAppService jwtAppService,
        ILogger<ProdutorAppService> logger)
    {
        _produtorRepository = produtorRepository;
        _jwtAppService = jwtAppService;
        _logger = logger;
    }

    public async Task<string> EfetuarLoginAsync(string email, string senha)
    {
        _logger.LogInformation($"Tentativa de efetuar o login. E-mail: {email}");

        var produtor = await _produtorRepository.ObterPorEmailAsync(email);

        if (produtor == null || !BCrypt.Net.BCrypt.Verify(senha, produtor.SenhaHash))
        {
            _logger.LogError("Houve um erro ao efetuar login, verifique os dados e tente novamente.");
            throw new AuthenticationException("Houve um erro ao efetuar login, verifique os dados e tente novamente.");
        }

        return _jwtAppService.GerarToken(produtor.Id, produtor.Email, produtor.Role.ToString());
    }

    public async Task<ProdutorDto> CadastrarAsync(CadastrarProdutorDto dto)
    {
        _logger.LogInformation("Tentativa de cadastro: {@Dto}", dto);

        var produtor = await _produtorRepository.ObterPorEmailAsync(dto.Email);
        if (produtor != null)
        {
            _logger.LogWarning($"Tentativa de cadastro. O endereço de e-mail {dto.Email} informado já está cadastrado.");
            throw new ConflictException("O endereço de e-mail informado já está cadastrado.");
        }

        var novoProdutor = new ProdutorEntity
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            Role = RoleEnum.Produtor
        };

        var registro = await _produtorRepository.AdicionarAsync(novoProdutor);

        return new ProdutorDto
        {
            Id = registro.Id,
            Nome = registro.Nome,
            Role = registro.Role,
            Email = registro.Email
        };
    }
}
