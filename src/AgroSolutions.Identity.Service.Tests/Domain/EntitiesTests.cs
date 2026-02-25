using AgroSolutions.Identity.Service.Domain.Entities;
using AgroSolutions.Identity.Service.Domain.Enums;
using AgroSolutions.Identity.Service.Domain.Exceptions;
using FluentAssertions;

namespace AgroSolutions.Identity.Service.Tests.Domain;

public class EntityBaseTests
{
    [Fact]
    public void EntityBase_DeveGerarGuidAutomaticamente_NoConstrutor()
    {
        // Act
        var entity = new ProdutorEntity();

        // Assert
        entity.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void EntityBase_DevePermitirGuidCustomizado()
    {
        // Arrange
        var guidEsperado = Guid.NewGuid();

        // Act
        var entity = new ProdutorEntity(
            guidEsperado,
            "João Silva",
            "joao@agro.com",
            "hash",
            RoleEnum.Produtor);

        // Assert
        entity.Id.Should().Be(guidEsperado);
    }
}

public class ProdutorEntityTests
{
    [Fact]
    public void ProdutorEntity_DeveCriarComParametrosCorretamente()
    {
        // Arrange
        var id = Guid.NewGuid();
        var nome = "João Silva";
        var email = "joao@agro.com";
        var senhaHash = "hashed_password";
        var role = RoleEnum.Produtor;

        // Act
        var entity = new ProdutorEntity(id, nome, email, senhaHash, role);

        // Assert
        entity.Id.Should().Be(id);
        entity.Nome.Should().Be(nome);
        entity.Email.Should().Be(email);
        entity.SenhaHash.Should().Be(senhaHash);
        entity.Role.Should().Be(role);
    }

    [Fact]
    public void ProdutorEntity_DeveTerRoleProdutor_PorPadrao()
    {
        // Act
        var entity = new ProdutorEntity();

        // Assert
        entity.Role.Should().Be(RoleEnum.Produtor);
    }

    [Theory]
    [InlineData(RoleEnum.Produtor)]
    [InlineData(RoleEnum.Admin)]
    public void ProdutorEntity_DeveAceitarDiferentesRoles(RoleEnum role)
    {
        // Act
        var entity = new ProdutorEntity(
            Guid.NewGuid(),
            "Teste",
            "teste@agro.com",
            "hash",
            role);

        // Assert
        entity.Role.Should().Be(role);
    }

    [Fact]
    public void ProdutorEntity_DeveAceitarStringsVazias_PorPadrao()
    {
        // Act
        var entity = new ProdutorEntity();

        // Assert
        entity.Nome.Should().Be(string.Empty);
        entity.Email.Should().Be(string.Empty);
        entity.SenhaHash.Should().Be(string.Empty);
    }
}

public class CustomExceptionBaseTests
{
    [Fact]
    public void AuthenticationException_DeveTerMensagemCorreta()
    {
        // Act
        var exception = new AuthenticationException("Erro de autenticação");

        // Assert
        exception.Message.Should().Be("Erro de autenticação");
    }

    [Fact]
    public void AuthenticationException_DeveTerMensagemPadrao()
    {
        // Act
        var exception = new AuthenticationException();

        // Assert
        exception.Message.Should().Be("Falha na autenticação.");
    }

    [Fact]
    public void NotFoundException_DeveTerMensagemCorreta()
    {
        // Act
        var exception = new NotFoundException("Registro não encontrado");

        // Assert
        exception.Message.Should().Be("Registro não encontrado");
    }

    [Fact]
    public void NotFoundException_DeveTerMensagemPadrao()
    {
        // Act
        var exception = new NotFoundException();

        // Assert
        exception.Message.Should().Be("Não foi possível localizar os dados solicitados.");
    }

    [Fact]
    public void ConflictException_DeveTerMensagemCorreta()
    {
        // Act
        var exception = new ConflictException("Conflito de dados");

        // Assert
        exception.Message.Should().Be("Conflito de dados");
    }

    [Fact]
    public void ConflictException_DeveTerMensagemPadrao()
    {
        // Act
        var exception = new ConflictException();

        // Assert
        exception.Message.Should().Be("Já existe um registro com os dados informados.");
    }
}

public class RoleEnumTests
{
    [Fact]
    public void RoleEnum_DeveTerValoresCorretos()
    {
        // Assert
        RoleEnum.Produtor.Should().Be((RoleEnum)0);
        RoleEnum.Admin.Should().Be((RoleEnum)1);
    }

    [Theory]
    [InlineData(RoleEnum.Produtor)]
    [InlineData(RoleEnum.Admin)]
    public void RoleEnum_DeveSerValido(RoleEnum role)
    {
        // Act
        var nome = role.ToString();

        // Assert
        nome.Should().NotBeEmpty();
    }
}
