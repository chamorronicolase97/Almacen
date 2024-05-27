﻿using System;
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
    public partial class frmMostrarMensaje : Form
    {
        public frmMostrarMensaje()
        {
            InitializeComponent();
        }

        public static void MostrarMensaje(string Titulo, string Descripcion)
        {
            frmMostrarMensaje mensaje = new frmMostrarMensaje();
            mensaje.lblTitulo.Text = Titulo;
            mensaje.lblMensaje.Text = Descripcion;
            mensaje.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
