using Almacen.Clases.Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen.Vistas.Ventas
{
    public partial class frmPrincipalVentas : Form
    {
        private Usuario _usuario;
        private Cliente _cliente;

        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }
        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } } 

        public frmPrincipalVentas()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmABMSClientes f = new frmABMSClientes();
            f.Show();
        }

        private void frmPrincipalVentas_Load(object sender, EventArgs e)
        {
            lblOperador.Text = $"Operador: {Usuario.NombreApellido}";
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            frmABMSClientes clientes = new frmABMSClientes();
            clientes.Show();


        }
    }
}
