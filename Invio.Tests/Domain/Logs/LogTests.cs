using Invio.Domain.Entities;
using Invio.Domain.Logs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Invio.Tests.Domain.Logs;

public class LogTests
{
    [Fact]
    public void LogConstrutor_DeveInicializarValoresPadroes()
    {
        //Arrange
        var usuarioId = Guid.NewGuid();
        var acao = "Editar";
        var entidadeAfetada = "Usuario";

        //Act
        var log = new Log
        {
            UsuarioId = usuarioId,
            Acao = acao,
            EntidadeAfetada = entidadeAfetada
        };

        //Assert
        Assert.NotEqual(Guid.Empty, log.Id);
        Assert.Equal(DateTime.UtcNow.Date, log.Data.Date);
    }

    [Fact]
    public void LogConstrutor_DeveInicializarPropriedades_ComDadosDeEntradaValidos()
    {
        //Arrange
        Guid usuarioId = Guid.NewGuid();
        string acao = "Criar";
        string entidadeAfetada = "Usuario";

        //Act
        var log = new Log
        {
            UsuarioId = usuarioId,
            Acao = acao,
            EntidadeAfetada = entidadeAfetada
        };

        //Assert
        Assert.Equal(usuarioId, log.UsuarioId);
        Assert.Equal(acao, log.Acao);
        Assert.Equal(entidadeAfetada, log.EntidadeAfetada);
        Assert.NotEqual(Guid.Empty, log.Id);
        Assert.Equal(DateTime.UtcNow.Date, log.Data.Date);
    }

    [Fact]
    public void MetodoToString_DeveRetornar_LogFormatado()
    {
        //Arrange
        var usuarioId = Guid.NewGuid();
        var acao = "Editar";
        var entidadeAfetada = "Usuario";
        var log = new Log
        {
            UsuarioId = usuarioId,
            Acao = acao,
            EntidadeAfetada = entidadeAfetada
        };
        var logEsperado = $"{log.Data:yyyy-MM-dd HH:mm:ss} - Usuário ID: {log.UsuarioId} - Ação: {log.Acao} - Entidade: {log.EntidadeAfetada}";

        //Act
        var resultado = log.ToString();

        //Assert
        Assert.Equal(logEsperado, resultado);
    }
}