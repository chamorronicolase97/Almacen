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

        public frmABMSCategorias()
        {
            InitializeComponent();

        }

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
            if (dgvDatos.CurrentCell == null) return;

            Categoria Clase = new Categoria(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"Baja de {Categoria.NombreClase}", "Correcta.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell == null) return;

            Categoria Clase = new Categoria(Convert.ToInt32(dgvDatos.CurrentRow.Cells["CategoriaID"].Value));

            frmAMCCategoria f = new frmAMCCategoria();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }
    }
}
