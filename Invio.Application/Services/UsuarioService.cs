using Invio.Application.DataObjectsTransfer;
using Invio.Application.Interfaces;
using Invio.Application.Validators;
using Invio.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Invio.Application.Services;
public class UsuarioService : IUsuarioService
{
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly INotificationHandler _notificationHandler;

    public UsuarioService(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, RoleManager<IdentityRole<Guid>> roleManager, INotificationHandler notificationHandler)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _notificationHandler = notificationHandler;
    }

    public async Task<UsuarioDto> CriaUsuarioAsync(UsuarioDto usuarioDto)
    {
        var validacao = await new UsuarioValidator().ValidateAsync(usuarioDto);
        if (!validacao.IsValid)
        {
            foreach (var error in validacao.Errors)
            {
                _notificationHandler.AdicionarNotificacao("UsuarioInvalido", error.ErrorMessage);
                return null;
            }
        }

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
            //verifica se a role existe
            var roleName = usuario.UsuarioCategoria.ToString();
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                _notificationHandler.AdicionarNotificacao("RoleInvalida", $"A role {roleName} não existe");
                return null;
            }

            //adiciona a role ao usuario
            var roleAssignmentResult = await _userManager.AddToRoleAsync(usuario, roleName);
            if (!roleAssignmentResult.Succeeded)
            {
                foreach (var error in roleAssignmentResult.Errors)
                    _notificationHandler.AdicionarNotificacao("FalhaAoAdicionarRole", error.Description);
            }

            //retorna usuario criado com sucesso
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

    public async Task<List<UsuarioDto>> ObterUsuariosAsync()
    {
        var usuarios = await _userManager.Users.ToListAsync();
        if (usuarios == null || !usuarios.Any())
        {
            _notificationHandler.AdicionarNotificacao("FalhaObterUsuarios", "Nenhum usuário encontrado");
            return null;
        }

        var usuariosDto = usuarios.Select(usuario => new UsuarioDto
        {
            Id = usuario.Id,
            Email = usuario.Email,
            PrimeiroNome = usuario.PrimeiroNome,
            UltimoNome = usuario.UltimoNome,
            UsuarioCategoria = usuario.UsuarioCategoria
        }).ToList();

        _notificationHandler.AdicionarNotificacao("ObterUsuarios", "Usuários obtidos com sucesso");
        return usuariosDto;
    }


}
