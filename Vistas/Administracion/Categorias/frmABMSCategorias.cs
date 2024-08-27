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
    public partial class frmABMSCategorias : Form
    {
        private Categoria _objetoSeleccionado;

        public frmABMSCategorias()
        {
            InitializeComponent();

        }

        public Categoria ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSCategorias_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Categoria.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Categoria.Listar();
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
    }
}
