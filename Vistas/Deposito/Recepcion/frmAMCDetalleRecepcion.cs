﻿using Almacen.Clases;
using Almacen.Clases.Administracion;
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
    public partial class frmAMCDetalleRecepcion : Form
    {
        private Producto _producto;
        private Proveedor _proveedor;

        public DetallePedido Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCDetalleRecepcion()
        {
            InitializeComponent();

        }

        private void frmAMCDetallePedido_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                txtNroPedido.Text = Clase.Pedido.ID.ToString();
                if (txtProducto != null) { txtProducto.Text = Clase.Producto.Descripcion.ToString(); }
                txtCantidad.Text = Clase.Cantidad.ToString();
                txtCostoUnitario.Text = Clase.CostoUnitario.ToString();
            }
            else
            {
                txtNroPedido.Text = Pedido.CalcularNroPedido().ToString();
            }
        }

        private void HabilitarControles()
        {
            if (_producto != null) { txtProducto.Text = _producto.Descripcion.ToString(); }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            if (Clase == null)
            {
                Clase = new DetallePedido();
            }

            Clase.Producto = _producto;
            Clase.Cantidad = Convert.ToInt32(txtCantidad.Text);
            Clase.CostoUnitario = Convert.ToDecimal(txtCostoUnitario.Text);

            if (Modificacion)
            {
                Clase.Modificar();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                int nroPedido = Pedido.CalcularNroPedido();
                Clase.Insertar(nroPedido, _producto.ID);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Validar()
        {
            if (txtProducto.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("DetallePedido", "Debe definir una fecha para el DetallePedido");
                return false;
            }

            return true;
        }

        private void btnAsignarProducto_Click(object sender, EventArgs e)
        {
            frmABMSProductos f = new frmABMSProductos { };
            f.ObjetoSeleccionado = _producto;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _producto = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores { };
            f.ObjetoSeleccionado = _proveedor;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _proveedor = f.ObjetoSeleccionado;
            }

            HabilitarControles();
        }

        private void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            if (_producto == null) return;

            frmAMCProducto f = new frmAMCProducto
            {
                Clase = _producto,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            frmAMCProveedor f = new frmAMCProveedor
            {
                Clase = _proveedor,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (_producto == null) return;

            _producto = null;
        }

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            _proveedor = null;
            HabilitarControles();
        }
    }
}
