using ApiModAdmin.Data.DAO.Usuarios;

namespace ApiModAdmin.Data.Interfaces
{
    public interface IUsuario
    {
        public List<Usuario> ConUsuarios();
        public int IngresoUsuario(DatosUsuario datos);
        public int ActualizaUsuario(DatosUsuario datos);

    }
}
