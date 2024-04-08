using ApiModAdmin.Data.Conexion;
using ApiModAdmin.Data.DAO.Cargos;
using ApiModAdmin.Data.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace ApiModAdmin.Data.DAO.Dptos
{
    public class DptoDAO: IDpto
    {
        ConMySql sql = new ConMySql();

        public List<Departamento> ConDptos()
        {
            List<Departamento> ldepartamentos = new List<Departamento>();

            try
            {
                sql.Comando.CommandType = CommandType.StoredProcedure;
                sql.Comando.CommandText = "cdepts";
                using (MySqlDataReader reader = sql.ejecutaReader())
                {
                    while (reader.Read())
                    {
                        ldepartamentos.Add(Departamento.ConListaDptos(reader));
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
            return ldepartamentos;
        }
    
}
}
