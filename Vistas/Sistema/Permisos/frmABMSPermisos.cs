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
    public partial class frmABMSPermisos : Form
    {
        private Permiso _objetoSeleccionado;
        public frmABMSPermisos()
        {
            InitializeComponent();

        }
        public Permiso ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSPermisos_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Permiso.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCPermiso f = new frmAMCPermiso();
            f.Clase = new Permiso(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.CurrentCell == null) return;

            //Permiso Clase = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            //Clase.Eliminar();

            //frmMostrarMensaje.MostrarMensaje($"Baja de {Permiso.NombreClase}", "Correcta.");

            //CargarGrilla();

            if (dgvDatos.CurrentRow == null) return;

            Permiso Clase = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Permiso " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Permiso.NombreClase}", "Baja de " + Permiso.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell == null) return;

            Permiso Clase = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            frmAMCPermiso f = new frmAMCPermiso();
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

            _objetoSeleccionado = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
