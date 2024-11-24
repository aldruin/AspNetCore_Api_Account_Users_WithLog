using Invio.Application.DataObjectsTransfer;
using Invio.Application.Interfaces;
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

}
