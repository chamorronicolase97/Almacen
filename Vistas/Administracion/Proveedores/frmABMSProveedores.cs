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
        private BindingSource bindingSource;

        public frmABMSProveedores()
        {
            InitializeComponent();

            bindingSource = new BindingSource();

        }
        public Proveedor ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }

        private void frmABMSProveedores_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            bindingSource.DataSource = Proveedor.ListarGrilla();
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["ProveedorID"].HeaderText = "ID";
            dgvDatos.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgvDatos.Columns["Direccion"].HeaderText = "Dirección";
            dgvDatos.Columns["Telefono"].HeaderText = "Teléfono";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void AplicarFiltroRapido()
        {
            string str = "";
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                str += $@"RazonSocial LIKE '%{filtro}%' OR Direccion LIKE '%{filtro}%'
                                        OR Mail LIKE '%{filtro}%' and ";
            }

            str += "1=1";
            bindingSource.Filter = str;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroRapido();
        }
    }
}
