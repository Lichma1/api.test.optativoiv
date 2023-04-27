using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace api.test.optativoiv.Controllers
{
    public class CiudadController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CiudadController : Controller
        {
            private CiudadService CiudadService;
            private IConfiguration configuration;

            public CiudadController(IConfiguration configuration)
            {
                this.configuration = configuration;
                this.CiudadService = new CiudadService(configuration.GetConnectionString("postgresDB"));
            }
        }
        [HttpGet("ConsultarCiudad/{id}")]
        public ActionResult<CiudadModel> ConsultarCiudad(int id)
        {
            var resultado = this.ciudadService.consultarCiudad(id);
            return Ok(resultado);
        }

    }
}
