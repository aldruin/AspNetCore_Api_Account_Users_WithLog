using Invio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.DataObjectsTransfer;
public record UsuarioDto
{
    public Guid Id { get; set; }
    public required string PrimeiroNome { get; set; }
    public required string UltimoNome { get; set; }
    public required UsuarioCategoria UsuarioCategoria { get; set; }
    public required string Email { get; set; }
    public string? Senha { get; set; }

    public UsuarioDto() { }

    public UsuarioDto (Guid id, string primeiroNome, string ultimoNome, UsuarioCategoria usuarioCategoria, string email)
    {
        Id = id;
        PrimeiroNome = primeiroNome;
        UltimoNome = ultimoNome;
        UsuarioCategoria = usuarioCategoria;
        Email = email;
    }

    public override string ToString()
    {
        return $"{PrimeiroNome} {UltimoNome} ({Email}) - {UsuarioCategoria}";
    }
}
