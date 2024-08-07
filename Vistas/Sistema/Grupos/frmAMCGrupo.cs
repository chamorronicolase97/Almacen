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
    public partial class frmAMCGrupo : Form
    {
        public Grupo Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCGrupo()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtNombre.Text = Clase.Descripcion;
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

            Clase.Descripcion = txtNombre.Text;

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
            if (txtNombre.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Grupo", "Debe escribir un nombre para el grupo");
                return false;
            }
            return true;
        }


    }
}
