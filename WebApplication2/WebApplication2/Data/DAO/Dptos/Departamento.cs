using ApiModAdmin.Data.DAO.Cargos;
using System.Data;

namespace ApiModAdmin.Data.DAO.Dptos
{
    public class Departamento
    {
        public string Nombre { get; set; }


        public static Departamento ConListaDptos(IDataRecord dr)
        {
            Departamento departamento = new()
            {
                Nombre = dr["nombre"].ToString()
            };

            return departamento;
        }
    }
}
