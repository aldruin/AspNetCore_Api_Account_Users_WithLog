using Invio.Application.DataObjectsTransfer;
using Invio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invio.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly INotificationHandler _notificationHandler;

    public UsuarioController (IUsuarioService usuarioService, INotificationHandler notificationHandler)
    {
        _usuarioService = usuarioService;
        _notificationHandler = notificationHandler;
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost("criar")]
    public async Task<IActionResult> CriaUsuarioAsync([FromBody] UsuarioDto usuarioDto)
    {
        var novoUsuario = await _usuarioService.CriaUsuarioAsync(usuarioDto);
        var notificacoes = _notificationHandler.ObterNotificacoes();

        if (novoUsuario != null)
        {
            var resultado = new { novoUsuario, notificacoes };
            return Ok(resultado);
        }
        return BadRequest(notificacoes);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet("get")]
    public async Task<IActionResult> ObterUsuariosAsync()
    {
        var usuarios = await _usuarioService.ObterUsuariosAsync();
        var notificacoes = _notificationHandler.ObterNotificacoes();

        if (usuarios != null)
        {
            var resultado = new { usuarios, notificacoes };
            return Ok(resultado);
        }
        return BadRequest(notificacoes);
    }

    
}
