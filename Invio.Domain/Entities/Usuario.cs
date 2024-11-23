using Invio.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Domain.Entities;
public sealed class Usuario : IdentityUser<Guid>
{
    public required string PrimeiroNome { get; set; }
    public required string UltimoNome { get; set; }
    public required UsuarioCategoria UsuarioCategoria { get; set; }
    public Usuario() { }


    public override string ToString()
    {
        return $"{PrimeiroNome} {UltimoNome} ({UserName}) - {UsuarioCategoria}";
    }

}
