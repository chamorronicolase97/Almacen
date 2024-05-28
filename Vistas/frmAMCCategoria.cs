using Almacen.Clases;
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
    public partial class frmAMCCategoria : Form
    {
        Categoria Clase = new Categoria();
        public frmAMCCategoria()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private bool Validar()
        {
            if (txtNombre.Text.Length <= 0) 
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Debe escribir un nombre para la categoria");
            return false;
            }

            if (txtUtilidad.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Debe escribir una utilidad para la categoria");
                return false;
            }
            return true;
        }
    }
}
