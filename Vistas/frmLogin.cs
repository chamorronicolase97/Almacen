using Almacen.Clases.Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen.Vistas
{
    public partial class frmLogin : Form
    {
        public Usuario? Usuario { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarAntesDeAceptar()) return;
            string User = txtUsuario.Text;
            string Password = txtPassword.Text;

            Usuario = Usuario.GetUsuario(User, Password);

            if (Usuario != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario No encontrado.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

        }

        private bool ValidarAntesDeAceptar()
        {
            if (txtUsuario.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar un usuario.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una contraseña.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

    }
}
