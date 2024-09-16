using Almacen.Clases;
using Almacen.Clases.Administracion;
using Almacen.Clases.Sistema;
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
    public partial class frmABMSCategorias : Form
    {
        private Categoria _objetoSeleccionado;
        private BindingSource bindingSource;

        public frmABMSCategorias()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        public Categoria ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSCategorias_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            bindingSource.DataSource = Categoria.ListarGrilla();
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["CategoriaID"].HeaderText = "ID";
            dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCCategoria f = new frmAMCCategoria();
            f.Clase = new Categoria(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Categoria Clase = new Categoria(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar la categoría " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (!Clase.EsVacia())
            {
                frmMostrarMensaje.MostrarMensaje($"{Categoria.NombreClase}", "La Categoría " + Categoria.NombreClase + " no se encuentra vacia, no puede eliminarse.");
                return;
            }
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Categoria.NombreClase}", "Baja de " + Categoria.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Categoria Clase = new Categoria(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            frmAMCCategoria f = new frmAMCCategoria();
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

            _objetoSeleccionado = new Categoria(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

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
                bindingSource.Filter = $"Descripcion LIKE '%{filtro}%' OR Convert(Utilidad, 'System.String') LIKE '%{filtro}%'";
            }
        }
    }
}
