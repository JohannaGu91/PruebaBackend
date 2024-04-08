using ApiModAdmin.Data.DAO.Cargos;
using ApiModAdmin.Data.Interfaces;
using ApiModAmin.Providers;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ILoggerManager Log;
        public CargosController(ILoggerManager logger)
        {
            Log = logger;
            Log.Info("Ingresando CargosController");
        }

        [HttpGet]
        public IActionResult GetCargos()
        {
            List<Cargo> lcargos;
            ICargo cargos = new CargoDAO();

            try
            {
                Log.Info("Consulta de Cargos.");
                lcargos = cargos.ConCargos();

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

            return Ok(lcargos);
        }
    }
}
