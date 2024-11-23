using Invio.Domain.Entities;
using Invio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Tests.Domain.Entities;
public class UsuairoTests
{
    [Fact]
    public void MetodoToString_DeveRetornarUsuarioFormatado_DeAcordoComDadosDeEntradaValidos()
    {
        //Arrange
        var userName = "aldruinsouza@outlook.com";
        var primeiroNome = "Aldruin";
        var ultimoNome = "Souza";
        var usuarioCategoria = UsuarioCategoria.Administrador;
        var usuario = new Usuario
        {
            UserName = userName,
            PrimeiroNome = primeiroNome,
            UltimoNome = ultimoNome,
            UsuarioCategoria = usuarioCategoria
        };

        var toStringEsperado = "Aldruin Souza (aldruinsouza@outlook.com) - Administrador";

        //Act
        var resultado = usuario.ToString();

        //Assert
        Assert.Equal(toStringEsperado, resultado);
    }
}
