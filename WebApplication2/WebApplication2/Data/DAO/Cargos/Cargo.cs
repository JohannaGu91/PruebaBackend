using System.Data;

namespace ApiModAdmin.Data.DAO.Cargos
{
    public class Cargo
    {
        public string Nombre { get; set; }


        public static Cargo ConListaCargos(IDataRecord dr)
        {
            Cargo c = new()
            {
                Nombre = dr["nombre"].ToString()
            };

            return c;
        }
    }
}
