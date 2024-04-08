using ApiModAdmin.Data.Conexion;
using ApiModAdmin.Data.DAO.Dptos;
using ApiModAdmin.Data.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApiModAdmin.Data.DAO.Usuarios
{
    public class UsuarioDAO : IUsuario
    {
        ConMySql sql = new ConMySql();

        public List<Usuario> ConUsuarios()
        {
            List<Usuario> lusuarios = new List<Usuario>();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "cusuarios";
                using (MySqlDataReader reader = sql.ejecutaReader())
                {
                    while (reader.Read())
                    {
                        lusuarios.Add(Usuario.ConListaUsuarios(reader));
                    }
                }
                sql.cerrarConexion();
            }
            catch (MySqlException)
            {
                sql.cerrarConexion();
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sql.cerrarConexion();
            }
            return lusuarios;
        }

        public int IngresoUsuario(DatosUsuario datos)
        {
            int resp = 0;

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "iusuarios";
                sql.Comando.Parameters.AddWithValue("e_usuario", datos.User);
                sql.Comando.Parameters.AddWithValue("e_primerNombre", datos.PrimerNombre);
                sql.Comando.Parameters.AddWithValue("e_segundoNombre", datos.SegundoNombre);
                sql.Comando.Parameters.AddWithValue("e_primerApellido", datos.PrimerApellido);
                sql.Comando.Parameters.AddWithValue("e_segundoApellido", datos.SegundoApellido);
                sql.Comando.Parameters.AddWithValue("e_email", datos.Email);
                sql.Comando.Parameters.AddWithValue("e_idDepartamento", datos.IdDepartamento);
                sql.Comando.Parameters.AddWithValue("e_idCargo", datos.IdCargo);

                resp = sql.ejecutaQuery();

            }
            catch (MySqlException)
            {
                sql.cerrarConexion();
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sql.cerrarConexion();
            }

            return resp;
        }

        public int ActualizaUsuario(DatosUsuario datos)
        {
            int resp = 0;

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "ausuarios";
                sql.Comando.Parameters.AddWithValue("e_id", datos.IdCargo);
                sql.Comando.Parameters.AddWithValue("e_usuario", datos.User);
                sql.Comando.Parameters.AddWithValue("e_primerNombre", datos.PrimerNombre);
                sql.Comando.Parameters.AddWithValue("e_segundoNombre", datos.SegundoNombre);
                sql.Comando.Parameters.AddWithValue("e_primerApellido", datos.PrimerApellido);
                sql.Comando.Parameters.AddWithValue("e_segundoApellido", datos.SegundoApellido);
                sql.Comando.Parameters.AddWithValue("e_email", datos.Email);
                sql.Comando.Parameters.AddWithValue("e_idDepartamento", datos.IdDepartamento);
                sql.Comando.Parameters.AddWithValue("e_idCargo", datos.IdCargo);
                sql.Comando.Parameters.AddWithValue("e_activo", datos.Activo);

                resp = sql.ejecutaQuery();

            }
            catch (MySqlException)
            {
                sql.cerrarConexion();
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sql.cerrarConexion();
            }

            return resp;
        }
    }
}
