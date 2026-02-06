using AgroSolutions.Identity.Service.Application.Dtos.Produtor;
using AgroSolutions.Identity.Service.Application.Interfaces;
using AgroSolutions.Identity.Service.Domain.Exceptions.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace AgroSolutions.Identity.Service.Api.Controllers;

/// <summary>
/// Responsável pelos endpoints de autenticação e registro de produtores rurais.
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthController : MainController
{
    private readonly IProdutorAppService _service;
    
    public AuthController(IProdutorAppService service)
    {
        _service = service;
    }

    /// <summary>
    /// Realiza o login do produtor rural e retorna um token de autenticação.
    /// </summary>
    /// <param name="request">Dados de login do produtor.</param>
    /// <returns>Token de autenticação.</returns>
    [SwaggerOperation(
        Summary = "Autentica o produtor rural.",
        Description = "Realiza o login do produtor rural e retorna um token JWT para autenticação."
    )]
    [ProducesResponseType(typeof(TokenLoginDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
    [HttpPost("entrar")]
    public async Task<IActionResult> Entrar([FromBody] EfetuarLoginDto request)
    {
        var resultado = await _service.EfetuarLoginAsync(request.Email, request.Senha);
        return Ok(new TokenLoginDto(resultado));
    }

    /// <summary>
    /// Registra um novo produtor rural no sistema.
    /// </summary>
    /// <param name="request">Dados para cadastro do produtor.</param>
    /// <returns>Dados do produtor criado.</returns>
    [SwaggerOperation(
        Summary = "Registra um novo produtor rural.",
        Description = "Cria um novo produtor rural no sistema e retorna seus dados."
    )]
    [ProducesResponseType(typeof(ProdutorDto), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar([FromBody] CadastrarProdutorDto request)
    {
        var produtor = await _service.CadastrarAsync(request);
        return Created($"/produtores/{produtor.Id}", produtor);
    }
}
