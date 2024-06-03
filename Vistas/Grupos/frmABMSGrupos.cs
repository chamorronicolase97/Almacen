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
            if (dgvDatos.CurrentCell == null) return;

            Grupo Clase = new Grupo(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"Baja de {Grupo.NombreClase}", "Correcta.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell == null) return;

            Grupo Clase = new Grupo(Convert.ToInt32(dgvDatos.CurrentRow.Cells["GrupoID"].Value));

            frmAMCGrupo f = new frmAMCGrupo();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }
    }
}
