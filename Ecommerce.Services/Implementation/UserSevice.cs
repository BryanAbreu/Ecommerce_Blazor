using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contracts;
using Ecommerce.Services.Contract;
using AutoMapper;
using AutoMapper.Execution;

namespace Ecommerce.Services.Implementation
{
    public class UserSevice : IUserService
    {
        private readonly IGenericReposistory<Usuario> _Repository;
        private readonly IMapper _Mapper;

        public UserSevice(IGenericReposistory<Usuario> Repository, IMapper Mapper)
        {
            _Repository = Repository;
            _Mapper = Mapper;
        }

        public async Task<SesionDTO> Auth(LoginDTO model)
        {
            try
            {
                //probar
                var userlogin = await _Repository.Get(x=>x.Correo==model.Correo && x.Clave==model.Clave).FirstOrDefaultAsync();
                if (userlogin != null) return _Mapper.Map<SesionDTO>(userlogin);
                else { throw new TaskCanceledException("Not Found userlogin service"); } 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Create(UsuarioDTO model)
        {
            try
            {
                var dbModel = _Mapper.Map<Usuario>(model);
                var user = await _Repository.Create(dbModel);

                if(user.IdUsuario!=0)
                    return _Mapper.Map<UsuarioDTO>(user);
                else 
                { 
                    throw new TaskCanceledException("Error no create user service"); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var select = await _Repository.Get(x => x.IdUsuario == id).FirstOrDefaultAsync();
                if (select != null)
                {
                    var response = await _Repository.Delete(select);

                    if (!response)
                        throw new TaskCanceledException("NO delete user service");

                    return response;
                }
                else 
                { 
                    throw new TaskCanceledException("No Found user for delete service"); 
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> Edit(UsuarioDTO model)
        {
            try
            {
                var select = await _Repository.Get(x => x.IdUsuario == model.IdUsuario).FirstOrDefaultAsync();
                if (select != null)
                {
                    select.NombreCompleto = model.NombreCompleto;
                    select.Correo = model.Correo;
                    select.Clave = model.Clave;
                    var response = await _Repository.Edit(select);

                    if (!response)
                        throw new TaskCanceledException("NO edit user service");

                    return response;

                }
                else { throw new TaskCanceledException("No Found user for edit service"); }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<UsuarioDTO> GetIDUser(int id)
        {
            try
            {
                var select = await _Repository.Get(x => x.IdUsuario == id).FirstOrDefaultAsync();
                if(select!=null)
                    return _Mapper.Map<UsuarioDTO>(select);
                else
                { throw new TaskCanceledException("No found id user service"); }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<UsuarioDTO>> List(string rol, string search)
        {
            try
            {
                var select = _Repository.Get(x =>
                x.Rol == rol &&
                string.Concat(x.NombreCompleto.ToLower(), x.Correo.ToLower()).Contains(search.ToLower())
                );

                List<UsuarioDTO> list = _Mapper.Map<List<UsuarioDTO>>(await select.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
