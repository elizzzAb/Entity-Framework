using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public NorthwindEntities contexto = new NorthwindEntities();
        public List<Customers> ObtenerTodos() 
        { 
            var cliente = from cum in contexto.Customers select cum;
            return cliente.ToList();
        }

        public Customers ObtenerPorID(string id)
        {
            var clientes = from cm in contexto.Customers where cm.CustomerID == id select cm;
            return clientes.FirstOrDefault();
        }

        public int InsertarCliente(Customers customers)
        {
            contexto.Customers.Add(customers);
            return contexto.SaveChanges();
        }

        public int ActualizarCliente(Customers customers)
        {
            var registro = ObtenerPorID(customers.CustomerID);
            if (registro != null)
            {
                registro.CustomerID = customers.CustomerID;
                registro.Address = customers.Address;
                registro.ContactTitle = customers.ContactTitle;
                registro.ContactName = customers.ContactName;
                registro.CompanyName = customers.CompanyName;
            }
            return contexto.SaveChanges();
        }

        public int EliminarCliente(string id)
        {
            var registro = ObtenerPorID(id);
            if (registro != null)
            {
                contexto.Customers.Remove(registro);
                return contexto.SaveChanges();
            }
            return 0;
        }
    }
}
