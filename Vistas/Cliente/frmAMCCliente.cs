﻿using Almacen.Clases;
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
    public partial class frmAMCCliente : Form
    {
        public Cliente Clase { get; set; }
        protected bool _soloLectura;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }


        public frmAMCCliente()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {

            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtCUIT.Text = Clase.Cuit;
                txtDenominacion.Text = Clase.Denominacion;
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
            Clase.Denominacion = txtDenominacion.Text;
            Clase.Direccion = txtDireccion.Text;
            Clase.Mail = txtMail.Text;
            Clase.Telefono = txtTelefono.Text;
            Clase.Empleado = chkEmpleado.Checked;
            Clase.Preferencial = chkPreferencial.Checked;  

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
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener un CUIT");
                return false;
            }

            if (txtDenominacion.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener una Denominación");
                return false;
            }

            if (txtDireccion.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener una Dirección");
                return false;
            }

            if (txtMail.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener un Correo");
                return false;
            }

            if (txtTelefono.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Cliente", "El Cliente debe tener un Teléfono");
                return false;
            }

            return true;
        }

    }
}
