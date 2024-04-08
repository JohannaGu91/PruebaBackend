namespace ApiModAdmin.Data.DAO.Usuarios
{
    public class DatosUsuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }
        public bool Activo { get; set; }
    }
}
