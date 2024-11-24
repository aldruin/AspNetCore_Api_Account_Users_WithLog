using FluentValidation;
using Invio.Application.DataObjectsTransfer;
using Invio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.Validators;
public class UsuarioValidator : AbstractValidator<UsuarioDto>
{
    public UsuarioValidator()
    {
        RuleFor(u => u.PrimeiroNome)
            .NotEmpty().WithMessage("O primeiro nome é obrigatório");
        
        RuleFor(u => u.UltimoNome)
            .NotEmpty().WithMessage("O ultimo nome é obrigatório");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("O endereço de E-mail é obrigatório")
            .Matches(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").WithMessage("O endereço de E-mail é obrigatório");

        RuleFor(u => u.UsuarioCategoria)
            .Must(categoria => Enum.IsDefined(typeof(UsuarioCategoria), categoria))
            .WithMessage("A categoria de usuário é obrigatória");

        RuleFor(u => u.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória")
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$")
            .WithMessage("A senha deve ter no mínimo 8 caracteres, uma letra, um caractere especial e um número");
    }
}
