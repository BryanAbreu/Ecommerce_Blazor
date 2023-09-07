using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Services.Contract
{
    public interface IUserService
    {
        Task<List<UsuarioDTO>> List(string rol, string search);
        Task<UsuarioDTO> GetIDUser(int id);
        Task<SesionDTO> Auth(LoginDTO model);
        Task<UsuarioDTO> Create(UsuarioDTO model);
        Task<bool> Edit(UsuarioDTO model);
        Task<bool> Delete(int id);

    }
}
