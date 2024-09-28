using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private CustomerRepository cr= new CustomerRepository();

        private void btnObtenerTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodos();
            dgvCustomers.DataSource = cliente;
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerPorID(tbxIDCustomers.Text);
            List<Customers> listaId = new List<Customers> { cliente };
            if (cliente != null)
            {
                LlenarCampos(cliente);
            }
            dgvCustomers.DataSource = listaId;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se insertó {resultado} correctamente.");
        }

        private Customers crearCliente()
        {
            var cliente = new Customers()
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                Address = txbAddress.Text,
                ContactTitle = txbContactTitle.Text,
            };
            return cliente;
        }

        private void LlenarCampos(Customers customers)
        {
            txbCustomerID.Text = customers.CustomerID;
            txbCompanyName.Text = customers.CompanyName;
            txbContactName.Text = customers.ContactName;
            txbContactTitle.Text = customers.ContactTitle;
            txbAddress.Text = customers.Address;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = crearCliente();
            cr.ActualizarCliente(cliente);
            var resultado = cr.ObtenerPorID(cliente.CustomerID);
            List<Customers> lista1 = new List<Customers> { resultado };
            dgvCustomers.DataSource = lista1;
        }
    }
}
