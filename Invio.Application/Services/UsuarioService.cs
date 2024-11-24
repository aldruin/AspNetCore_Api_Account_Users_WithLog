using Invio.Application.DataObjectsTransfer;
using Invio.Application.Interfaces;
using Invio.Application.Validators;
using Invio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.Services;
public class UsuarioService : IUsuarioService
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly INotificationHandler _notificationHandler;

    public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, INotificationHandler notificationHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _notificationHandler = notificationHandler;
    }

    public async Task<UsuarioDto> CriaUsuarioAsync(UsuarioDto usuarioDto)
    {
        //valida dados de entrada de usuario (UsuarioDto)
        var validacao = await new UsuarioValidator().ValidateAsync(usuarioDto);
        if (!validacao.IsValid)
        {
            foreach (var error in validacao.Errors)
            {
                _notificationHandler.AdicionarNotificacao("UsuarioInvalido", error.ErrorMessage);
                return null;
            }
        }

        //cria entidade usuario
        var usuario = new Usuario()
        {
            PrimeiroNome = usuarioDto.PrimeiroNome,
            UltimoNome = usuarioDto.UltimoNome,
            UserName = usuarioDto.Email,
            Email = usuarioDto.Email,
            UsuarioCategoria = usuarioDto.UsuarioCategoria
        };

        var resultado = await _userManager.CreateAsync(usuario, usuarioDto.Senha);
        if(resultado.Succeeded)
        {
            _notificationHandler.AdicionarNotificacao("UsuarioCriado", $"Usuario criado com sucesso: {usuario.ToString()}");
            return new UsuarioDto()
            {
                Id = usuario.Id,
                PrimeiroNome = usuario.PrimeiroNome,
                UltimoNome = usuario.UltimoNome,
                UsuarioCategoria = usuario.UsuarioCategoria,
                Email = usuario.Email
            };
        }

        foreach (var error in resultado.Errors)
            _notificationHandler.AdicionarNotificacao("CriarUsuarioFalhou", $"Falha ao criar o usuario: {error.Description}");
        return null;
    }
}
