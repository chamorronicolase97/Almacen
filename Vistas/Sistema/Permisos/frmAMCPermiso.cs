using Almacen.Clases;
using Almacen.Clases.Administracion;
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
    public partial class frmAMCPermiso : Form
    {
        public Permiso Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCPermiso()
        {
            InitializeComponent();

        }

        private void frmAMCPermiso_Load(object sender, EventArgs e)
        {

            if (Modificacion == true)
            {
                txtID.Text = Clase.PermisoID.ToString();
                txtCodPermiso.Text = Clase.CodPermiso;
                txtDescripcion.Text = Clase.Descripcion;
                btnAsignar.Enabled = true;
            }
            else
            {
                btnAsignar.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.CodPermiso = txtCodPermiso.Text;
            Clase.Descripcion = txtDescripcion.Text;

            if (Modificacion)
            {
                Clase.Modificar();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Clase.Insertar();
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool Validar()
        {
            if (txtCodPermiso.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Permiso", "Debe escribir un NOMBRE y APELLIDO para el Permiso");
                return false;
            }

            return true;
        }


    }
}
