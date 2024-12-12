using SQLite;


namespace EJERCICIO_CRUD_MVVM.Models
{
    public class Proveedores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Codigo { get; set; }
        [NotNull]
        public string NombreProveedor { get; set; }
        [NotNull]
        public string Empresa { get; set; }
        [NotNull]
        public string Direccion { get; set; }
        


    }
}
