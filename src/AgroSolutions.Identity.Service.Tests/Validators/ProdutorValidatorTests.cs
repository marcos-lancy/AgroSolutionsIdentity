using AgroSolutions.Identity.Service.Application.Dtos.Produtor;
using AgroSolutions.Identity.Service.Application.Dtos.Produtor.Validations;
using FluentAssertions;

namespace AgroSolutions.Identity.Service.Tests.Validators;

public class CadastrarProdutorDtoValidatorTests
{
    private readonly CadastrarProdutorDtoValidator _validator;

    public CadastrarProdutorDtoValidatorTests()
    {
        _validator = new CadastrarProdutorDtoValidator();
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveSerValido_QuandoDadosEstiveremCorretos()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "João Silva",
            Email = "joao@agro.com",
            Senha = "Senha123!",
            ConfirmaSenha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoNomeForVazio()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "",
            Email = "joao@agro.com",
            Senha = "Senha123!",
            ConfirmaSenha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
        result.Errors.Should().Contain(x => x.PropertyName == "Nome");
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoNomeTiverMenosDe3Caracteres()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "Jo",
            Email = "joao@agro.com",
            Senha = "Senha123!",
            ConfirmaSenha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoEmailForInvalido()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "João Silva",
            Email = "email-invalido",
            Senha = "Senha123!",
            ConfirmaSenha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoEmailForVazio()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "João Silva",
            Email = "",
            Senha = "Senha123!",
            ConfirmaSenha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Theory]
    [InlineData("senha123")]
    [InlineData("SENHA123!")]
    [InlineData("Senhaabc!")]
    [InlineData("Senha123")]
    [InlineData("Senha1")]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoSenhaNaoCumprirRequisitos(string senhaInvalida)
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "João Silva",
            Email = "joao@agro.com",
            Senha = senhaInvalida,
            ConfirmaSenha = senhaInvalida
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoSenhasNaoConferirem()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "João Silva",
            Email = "joao@agro.com",
            Senha = "Senha123!",
            ConfirmaSenha = "SenhaDiferente123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }

    [Fact]
    public void CadastrarProdutorDtoValidator_DeveTerErro_QuandoSenhaForVazia()
    {
        // Arrange
        var dto = new CadastrarProdutorDto
        {
            Nome = "João Silva",
            Email = "joao@agro.com",
            Senha = "",
            ConfirmaSenha = ""
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeEmpty();
    }
}

public class EfetuarLoginDtoValidatorTests
{
    private readonly EfetuarLoginDtoValidator _validator;

    public EfetuarLoginDtoValidatorTests()
    {
        _validator = new EfetuarLoginDtoValidator();
    }

    [Fact]
    public void EfetuarLoginDtoValidator_DeveSerValido_QuandoDadosEstiveremCorretos()
    {
        // Arrange
        var dto = new EfetuarLoginDto
        {
            Email = "joao@agro.com",
            Senha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void EfetuarLoginDtoValidator_DeveTerErro_QuandoEmailForVazio()
    {
        // Arrange
        var dto = new EfetuarLoginDto
        {
            Email = "",
            Senha = "Senha123!"
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void EfetuarLoginDtoValidator_DeveTerErro_QuandoSenhaForVazia()
    {
        // Arrange
        var dto = new EfetuarLoginDto
        {
            Email = "joao@agro.com",
            Senha = ""
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void EfetuarLoginDtoValidator_DeveTerErro_QuandoEmailESenhaForemVazios()
    {
        // Arrange
        var dto = new EfetuarLoginDto
        {
            Email = "",
            Senha = ""
        };

        // Act
        var result = _validator.Validate(dto);

        // Assert
        result.IsValid.Should().BeFalse();
    }
}
