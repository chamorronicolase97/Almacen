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
    public partial class frmAMCCategoria : Form
    {
        public Categoria Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCCategoria()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                lblForm.Text = "Modificar " + Categoria.NombreClase;
                txtID.Text = Clase.ID.ToString();
                txtNombre.Text = Clase.Descripcion;
                txtUtilidad.Text = Clase.Utilidad.ToString();
            }
            else
            {
                lblForm.Text = "Crear " + Categoria.NombreClase;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.Descripcion = txtNombre.Text;
            Clase.Utilidad = Convert.ToDecimal(txtUtilidad.Text.ToString());

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
            if (txtNombre.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Debe escribir un nombre para la categoria");
                return false;
            }

            if (txtUtilidad.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Categoria", "Debe escribir una utilidad para la categoria");
                return false;
            }

            return true;
        }


    }
}
