﻿using Almacen.Clases;
using Almacen.Clases.Compra;
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
    public partial class frmAMCRecepcion : Form
    {
        public Recepcion Clase { get; set; }
        public Pedido Pedido { get; set; }
        public bool Modificacion { get; set; } = false;

        public frmAMCRecepcion()
        {
            InitializeComponent();

        }

        private void frmAMCPedido_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                CargarGrillaDetalles();
                txtNroPedido.Text = Clase.ID.ToString();
                dtpFechaEntrega.Value = Clase.FechaEntrega;
            }
            else
            {
                txtNroPedido.Text = Pedido.ID.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.FechaEntrega = dtpFechaEntrega.Value;

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
            if (dtpFechaEntrega == null)
            {
                frmMostrarMensaje.MostrarMensaje("Pedido", "Debe definir una fecha para el Pedido");
                return false;
            }

            return true;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            frmAMCDetalleRecepcion f = new frmAMCDetalleRecepcion();
            f.Show();
            CargarGrillaDetalles();
        }

        private void CargarGrillaDetalles()
        {
            dgvDetalles.DataSource = DetallePedido.Listar();
        }

    }
}