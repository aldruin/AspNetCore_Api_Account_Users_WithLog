using Invio.Application.DataObjectsTransfer;
using Invio.Application.Validators;
using Invio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Tests.Application.Validators;
public class UserValidatorTests
{
    private readonly UsuarioValidator _usuarioValidator;

    public UserValidatorTests()
    {
        _usuarioValidator = new UsuarioValidator();
    }

    [Fact]
    public void Validator_DeveRetornarValido_QuandoDadosValidos()
    {
        //Arrange
        var usuario = new UsuarioDto
        {
            PrimeiroNome = "Aldruin",
            UltimoNome = "Souza",
            Email = "aldruinsouza@outlook.com",
            UsuarioCategoria = Invio.Domain.Enums.UsuarioCategoria.Administrador,
            Senha = "Teste@123"
        };

        //Act
        var resultado = _usuarioValidator.Validate(usuario);

        //Assert
        Assert.True(resultado.IsValid);
    }

    [Theory]
    [InlineData("", "Souza", "aldruinsouza@outlook.com", Invio.Domain.Enums.UsuarioCategoria.Administrador, "Teste@123", "PrimeiroNome", "O primeiro nome é obrigatório")]
    [InlineData("Aldruin", "Souza", "emailinvalido", Invio.Domain.Enums.UsuarioCategoria.Administrador, "Teste@123", "Email", "O endereço de E-mail é obrigatório")]
    [InlineData("Aldruin", "Souza", "aldruinsouza@outlook.com", Invio.Domain.Enums.UsuarioCategoria.Administrador, "", "Senha", "A senha deve ter no mínimo 8 caracteres, uma letra, um caractere especial e um número")]
    [InlineData("Aldruin", "Souza", "aldruinsouza@outlook.com", (UsuarioCategoria)999, "Teste@123", "UsuarioCategoria", "A categoria de usuário é obrigatória")]
    public void Validator_DeveRetornarInvalido_QuandoDadosInvalidos(
        string primeiroNome,
        string ultimoNome,
        string email,
        UsuarioCategoria usuarioCategoria,
        string senha,
        string propertyName,
        string errorMessage)
    {
        //Arrange
        var usuario = new UsuarioDto
        {
            PrimeiroNome = primeiroNome,
            UltimoNome = ultimoNome,
            Email = email,
            UsuarioCategoria = usuarioCategoria,
            Senha = senha
        };

        //Act
        var resultado = _usuarioValidator.Validate(usuario);

        //Assert
        Assert.False(resultado.IsValid);
        Assert.Contains(resultado.Errors, e => e.PropertyName == propertyName && e.ErrorMessage == errorMessage);
    }
}
