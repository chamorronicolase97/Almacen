using Almacen.Clases;
using Almacen.Clases.Administracion;
using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen.Vistas
{
    public partial class frmABMSProductos : Form
    {

        public frmABMSProductos()
        {
            InitializeComponent();

        }

        private void frmABMSProductos_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Producto.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Producto.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCProducto f = new frmAMCProducto();
            f.Clase = new Producto(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Producto Clase = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"Baja de {Producto.NombreClase}", "Correcta.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Producto Clase = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            frmAMCProducto f = new frmAMCProducto();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }
    }
}
