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
    public partial class frmABMSClientes : Form
    {
        private Cliente _objetoSeleccionado;

        public frmABMSClientes()
        {
            InitializeComponent();

        }
        public Cliente ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }

        private void frmABMSProveedores_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Cliente.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCCliente f = new frmAMCCliente();
            f.Clase = new Cliente(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Proveedor Clase = new Proveedor(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ClienteID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar al Cliente " + Clase.RazonSocial + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Cliente.NombreClase}", "Baja de " + Cliente.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Cliente Clase = new Cliente(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ClienteID"].Value));

            frmAMCCliente f = new frmAMCCliente();
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

            _objetoSeleccionado = new Cliente(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ClienteID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
