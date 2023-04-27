using api.test.optativoiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace api.test.optativoiv.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private ClienteService personaService;
        private IConfiguration configuration;

        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaService = new ClienteService(configuration.GetConnectionString("postgresDB"));    
        }

        [HttpGet("ListarPersona")]
        public ActionResult<List<ClienteModel>> ListarPersonas()
        {   
            var resultado = personaService.listarPersona();
            return Ok(resultado);
        }

        [HttpGet("ConsultarPersona/{id}")]
        public ActionResult<ClienteModel> ConsultarPersona(int id)
        {
            var resultado = this.personaService.consultarPersona(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insertarPersona(ClienteModel modelo)
        {
            var resultado = this.personaService.insertarPersona(new infraestructure.Models.ClienteModel {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Edad = modelo.Edad,
                Ciudad = modelo.Ciudad,
                FechaNacimiento = modelo.FechaNacimiento,
                Nacionalidad = modelo.Nacionalidad,
                Documento = modelo.Documento
            });
            return Ok(resultado);
        }

        [HttpPut("modificarPersona/{id}")]
        public ActionResult<string> modificarPersona(ClienteModel modelo, int id)
        {
            var resultado = this.personaService.modificarPersona(new infraestructure.Models.ClienteModel
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Edad = modelo.Edad
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarPersona/{id}")]
        public ActionResult<string> eliminarPersona(int id)
        {
            var resultado = this.personaService.eliminarPersona(id);
            return Ok(resultado);
        }
    }
}
