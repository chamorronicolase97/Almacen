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
        private Proveedor _proveedor;
        private BindingSource bindingSource;

        public Proveedor FiltroProveedor { get { return _proveedor; } set { _proveedor = value; } }

        public frmABMSProductos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        public Producto ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }

        private void frmABMSProductos_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            if (FiltroProveedor != null) { bindingSource.DataSource = Producto.ListarPorProveedor(FiltroProveedor); }
            else { bindingSource.DataSource = Producto.Listar(); }
            dgvDatos.DataSource = bindingSource;
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
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = $@"Descripcion LIKE '%{filtro}%' OR Convert(Costo, 'System.String') LIKE '%{filtro}%'
                                        OR CodigoDeBarra LIKE '%{filtro}%'";
            }
        }
    }
}
