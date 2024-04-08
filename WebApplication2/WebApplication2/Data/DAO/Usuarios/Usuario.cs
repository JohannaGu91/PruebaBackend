using System.Data;

namespace ApiModAdmin.Data.DAO.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }

        public static Usuario ConListaUsuarios(IDataRecord dr)
        {
            Usuario usuario = new Usuario
            {
                Id = int.Parse(dr["id"].ToString()),
                User = dr["usuario"].ToString(),
                Nombres = dr["primerNombre"].ToString() + " " + dr["segundoNombre"].ToString(),
                Apellidos = dr["primerApellido"].ToString() + " " + dr["segundoApellido"].ToString(),
                Email = dr["email"].ToString(),
                IdDepartamento = int.Parse(dr["idDepartamento"].ToString()),
                IdCargo = int.Parse(dr["idCargo"].ToString())
            };
            usuario.Nombres.Trim();
            usuario.Apellidos.Trim();

            return usuario;
        }
    }
}
