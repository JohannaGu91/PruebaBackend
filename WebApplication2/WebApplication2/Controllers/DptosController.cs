using ApiModAdmin.Data.DAO.Dptos;
using ApiModAdmin.Data.Interfaces;
using ApiModAmin.Providers;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ApiModAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DptosController : ControllerBase
    {

        private readonly ILoggerManager Log;
        public DptosController(ILoggerManager logger)
        {
            Log = logger;
            Log.Info("Ingresando CargosController");
        }

        [HttpGet]
        public IActionResult GetDepartamentos()
        {
            List<Departamento> ldepartamentos;
            IDpto dptos = new DptoDAO();

            try
            {
                Log.Info("Consulta de Departamentos.");
                ldepartamentos = dptos.ConDptos();

            }
            catch (MySqlException ex)
            {
                Log.Error(ex.Message, ex);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return BadRequest(ex.Message);
            }

            return Ok(ldepartamentos);
        }
    }
}
