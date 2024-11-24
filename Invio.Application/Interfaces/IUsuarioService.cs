using Invio.Application.DataObjectsTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invio.Application.Interfaces;
public interface IUsuarioService
{
    Task<UsuarioDto> CriaUsuarioAsync(UsuarioDto usuarioDto);
}
