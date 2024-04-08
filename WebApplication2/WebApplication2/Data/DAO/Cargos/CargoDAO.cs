using MySql.Data.MySqlClient;
using System.Data;
using ApiModAdmin.Data.Conexion;
using ApiModAdmin.Data.Interfaces;

namespace ApiModAdmin.Data.DAO.Cargos
{
    public class CargoDAO : ICargo
    {
        ConMySql sql = new ConMySql();

        public List<Cargo> ConCargos()
        {
            List<Cargo> lcargos = new List<Cargo>();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "ccargos";
                using (MySqlDataReader reader = sql.ejecutaReader())
                {
                    while (reader.Read())
                    {
                        lcargos.Add(Cargo.ConListaCargos(reader));
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
            return lcargos;
        }
    }
}
