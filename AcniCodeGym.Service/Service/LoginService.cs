using AcniCodeGym.Service.Base;
using AcniCodeGym.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcniCodeGym.Service.Service
{
    public class LoginService
    {
        public async Task<UsuarioDto> Login(LoginDto user)
        {
            var request = await GenericMethodsAPIClient<UsuarioDto>.Post(ApiConnection.EndPoints.Usuario + "login", user);
            return request;
        }
    }
}
