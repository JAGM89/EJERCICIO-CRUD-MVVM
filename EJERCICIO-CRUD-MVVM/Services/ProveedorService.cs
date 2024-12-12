using EJERCICIO_CRUD_MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_CRUD_MVVM.Services
{
    public class ProveedorService
    {
        private readonly SQLiteConnection connection;

        public ProveedorService()
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");
            connection = new SQLiteConnection(dbpath);
            connection.CreateTable<Proveedores>();
        }

        public List<Proveedores> GetAll()
        {
            var res= connection.Table<Proveedores>().ToList();
            return res;
        }

        public int Insert(Proveedores proveedores)
        {
            return connection.Insert(proveedores);
        }

        public int Update(Proveedores proveedores)
        {
            return connection.Update(proveedores);
        }

        public int Delete(Proveedores proveedores)
        {
            return connection.Delete(proveedores);
        }


    
    }
}
