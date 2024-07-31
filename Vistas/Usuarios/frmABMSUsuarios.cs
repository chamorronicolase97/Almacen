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

        public frmABMSUsuarios()
        {
            InitializeComponent();

        }

        private void frmABMSUsuarios_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Usuario.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Usuario.Listar();
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

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"Baja de {Usuario.NombreClase}", "Correcta.");

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
    }
}
