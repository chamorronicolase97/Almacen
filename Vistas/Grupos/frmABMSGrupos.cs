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
    public partial class frmABMSGrupos : Form
    {

        public frmABMSGrupos()
        {
            InitializeComponent();

        }

        private void frmABMSGrupos_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Grupo.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Grupo.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCGrupo f = new frmAMCGrupo();
            f.Clase = new Grupo(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Grupo Clase = new Grupo(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Grupo " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (!Clase.EsVacio())
            {
                frmMostrarMensaje.MostrarMensaje($"{Categoria.NombreClase}", "El Grupo " + Grupo.NombreClase + " no se encuentra vacio, no puede eliminarse.");
                return;
            }
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Grupo.NombreClase}", "Baja de " + Grupo.NombreClase + " exitosa.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Grupo Clase = new Grupo(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));

            frmAMCGrupo f = new frmAMCGrupo();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }
    }
}
