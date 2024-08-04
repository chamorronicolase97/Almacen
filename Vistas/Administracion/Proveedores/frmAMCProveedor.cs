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
    public partial class frmAMCProveedor : Form
    {
        public Proveedor Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCProveedor()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {

            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtCUIT.Text = Clase.Cuit;
                txtRazonSocial.Text = Clase.RazonSocial;
                txtDireccion.Text = Clase.Direccion;
                txtMail.Text = Clase.Mail;
                txtTelefono.Text = Clase.Telefono;
            }
            else
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.Cuit = txtCUIT.Text;
            Clase.RazonSocial = txtRazonSocial.Text;
            Clase.Direccion = txtDireccion.Text;
            Clase.Mail = txtMail.Text;
            Clase.Telefono = txtTelefono.Text;

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
            if (txtCUIT.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Proveedor", "El proveedor debe tener un CUIT");
                return false;
            }


            return true;
        }


    }
}
