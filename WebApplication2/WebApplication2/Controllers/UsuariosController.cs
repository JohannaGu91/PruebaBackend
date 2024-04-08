using ApiModAdmin.Data.DAO.Usuarios;
using ApiModAdmin.Data.Interfaces;
using ApiModAmin.Providers;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ApiModAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILoggerManager Log;
        IUsuario usuarios = new UsuarioDAO();
        public UsuariosController(ILoggerManager logger)
        {
            Log = logger;
            Log.Info("Ingresando UsuariosController");
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            List<Usuario> lusuarios;

            try
            {
                Log.Info("Consulta de Usuarios.");
                lusuarios = usuarios.ConUsuarios();

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

            return Ok(lusuarios);
        }

        [HttpPost]
        public IActionResult IngUsuario(DatosUsuario datosUsuario)
        {
            int result;

            try
            {
                Log.Info("Ingreso de Usuarios.");
                result = usuarios.IngresoUsuario(datosUsuario);

                if (result == 1)
                {
                    return Ok("Ingreso exitoso");
                }
                else
                {
                    return BadRequest("Error en el ingreso");
                }

            }
            catch (MySqlException ex)
            {
                Log.Error(ex.Message, ex);
                return BadRequest("Error en el ingreso");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult ActUsuario(DatosUsuario datosUsuario)
        {
            int result;

            try
            {
                Log.Info("Actualización de Usuarios.");
                result = usuarios.ActualizaUsuario(datosUsuario);

                if (result == 1)
                {
                    return Ok("Registro actualizado");
                }
                else
                {
                    return BadRequest("Error en actualizacion");
                }

            }
            catch (MySqlException ex)
            {
                Log.Error(ex.Message, ex);
                return BadRequest("Error en actualizacion");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return BadRequest(ex.Message);
            }

        }
    }
}
