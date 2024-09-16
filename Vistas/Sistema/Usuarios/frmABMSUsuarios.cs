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
    public partial class frmABMSUsuarios : Form
    {
        private Usuario _objetoSeleccionado;
        public frmABMSUsuarios()
        {
            InitializeComponent();

        }
        public Usuario ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSUsuarios_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Usuario.ListarGrilla();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCUsuario f = new frmAMCUsuario();
            f.Clase = new Usuario(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Usuario Clase = new Usuario(Convert.ToInt32(dgvDatos.CurrentRow.Cells["UsuarioID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Usuario " + Clase.NombreApellido + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Usuario.NombreClase}", "Baja de " + Usuario.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Usuario Clase = new Usuario(Convert.ToInt32(dgvDatos.CurrentRow.Cells["UsuarioID"].Value));

            frmAMCUsuario f = new frmAMCUsuario();
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

            _objetoSeleccionado = new Usuario(Convert.ToInt32(dgvDatos.CurrentRow.Cells["UsuarioID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
