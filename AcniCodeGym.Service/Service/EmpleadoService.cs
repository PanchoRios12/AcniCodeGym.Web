using AcniCodeGym.Service.Base;
using AcniCodeGym.Service.ViewModel;
using AcniCodeGym.Service.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AcniCodeGym.Service.Service
{
    public class EmpleadoService
    {
        public async Task<List<EmpleadoDto>> listaEmpleados(string token)
        {
            var request = await GenericMethodsAPIClient<List<EmpleadoDto>>.Get(ApiConnection.EndPoints.Empleado + "ListaEmpleado", token);
            return request;
        }
        public async Task<EmpleadoDto> crearEmpleado(EmpleadoDto empleadoDto,string token)
        {
            empleadoDto.Estado = true;
            var request = await GenericMethodsAPIClient<EmpleadoDto>.Post(ApiConnection.EndPoints.Empleado + "CrearEmpleado", empleadoDto, token);
            return request;
        }
        public async Task<EmpleadoDto> actualizarEmpleado(EmpleadoDto empleadoDto,string token)
        {
            var request = await GenericMethodsAPIClient<EmpleadoDto>.Put(ApiConnection.EndPoints.Empleado + "actualizarEmpleado",null,empleadoDto ,token);
            return request;
        }
        public async Task<EmpleadoDto> ObtenerEmpleadoPorId(int id, string token)
        {
            var request = await GenericMethodsAPIClient<EmpleadoDto>.Get(ApiConnection.EndPoints.Empleado + "obtenerEmpleadoPorId/" + id.ToString(), token);
            return request;
        }
        public async Task<EmpleadoDto> eliminarEmpleado(int id, string token)
        {
            var request = await GenericMethodsAPIClient<EmpleadoDto>.Get(ApiConnection.EndPoints.Empleado + "obtenerEmpleadoPorId/" + id.ToString(), token);
            request.Estado = false;
            return await actualizarEmpleado(request, token);
        }
        public async Task<PaginationRequestBase<EmpleadoDto>> listaEmpleadoPaginado(PaginationDto pagination, string token)
        {
            var request = await GenericMethodsAPIClient<PaginationRequestBase<EmpleadoDto>>.Post(ApiConnection.EndPoints.Empleado + "obtenerEmpleadoPaginado", pagination, token);
            return request;
        }
    }
}
