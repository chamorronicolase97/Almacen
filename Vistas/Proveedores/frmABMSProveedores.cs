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
    public partial class frmABMSProveedores : Form
    {

        public frmABMSProveedores()
        {
            InitializeComponent();

        }

        private void frmABMSProveedores_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Proveedor.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Proveedor.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCProveedor f = new frmAMCProveedor();
            f.Clase = new Proveedor(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell == null) return;

            Proveedor Clase = new Proveedor(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProveedorID"].Value));

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"Baja de {Proveedor.NombreClase}", "Correcta.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell == null) return;

            Proveedor Clase = new Proveedor(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProveedorID"].Value));

            frmAMCProveedor f = new frmAMCProveedor();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }
    }
}
