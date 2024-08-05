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
        private Proveedor _objetoSeleccionado;

        public frmABMSProveedores()
        {
            InitializeComponent();

        }
        public Proveedor ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }

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
            if (dgvDatos.CurrentRow == null) return;

            Proveedor Clase = new Proveedor(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProveedorID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar al Proveedor " + Clase.RazonSocial + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Proveedor.NombreClase}", "Baja de " + Proveedor.NombreClase + " exitosa.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Proveedor Clase = new Proveedor(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProveedorID"].Value));

            frmAMCProveedor f = new frmAMCProveedor();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = new Proveedor(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProveedorID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
