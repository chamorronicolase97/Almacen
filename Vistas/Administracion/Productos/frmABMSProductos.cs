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
        private Producto _objetoSeleccionado;

        public frmABMSProductos()
        {
            InitializeComponent();

        }

        public Producto ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }

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

            DialogResult = MessageBox.Show("Desea eliminar el Producto " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Producto.NombreClase}", "Baja de " + Producto.NombreClase + " exitosa.");

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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
