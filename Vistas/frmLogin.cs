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
    public partial class frmLogin : Form
    {
        public Usuario? Usario { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string User = txtUsuario.Text;
            string Password = txtPassword.Text;
            
            Usario = Usuario.GetUsuario(User, Password);

            if (Usario != null) 
            {             
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario No encontrado.", "Iniciar Sesión", System.Windows.Forms.MessageBoxButtons.OK , System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
