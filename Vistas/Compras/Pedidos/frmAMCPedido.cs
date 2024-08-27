using Almacen.Clases;
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
    public partial class frmAMCPedido : Form
    {
        private int _nroPedido;
        private Proveedor? _proveedor;
        public Pedido Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCPedido()
        {
            InitializeComponent();

        }

        private void frmAMCPedido_Load(object sender, EventArgs e)
        {
                     
            if (Modificacion == true)
            {             
                txtNroPedido.Text = Clase.ID.ToString();
                _nroPedido = Clase.ID;
                dtpFechaEntrega.Value = Clase.FechaEntrega;
                _proveedor = Clase.Proveedor;
            }
            else
            {
                _nroPedido = Pedido.CalcularNroPedido();
                txtNroPedido.Text = _nroPedido.ToString();                
            }
            HabilitarControles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.ID = _nroPedido;
            Clase.FechaEntrega = dtpFechaEntrega.Value;
            Clase.Proveedor = _proveedor;

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
            if (_proveedor == null) return;
            frmAMCDetallePedido f = new frmAMCDetallePedido();
            f.FiltroProveedor = _proveedor;
            f.Show();
            CargarGrillaDetalles();
        }

        private void CargarGrillaDetalles()
        {
            var pedidosview = DetallePedido.ListarDetallesPedidos(_nroPedido).Select(p => new
            {
                p.Pedido.ID,
                p.Pedido.FechaEntrega,
                p.Producto.Descripcion,
                p.Cantidad,
                p.CostoUnitario,
            }).ToList();
            dgvDetalles.DataSource = pedidosview;
            dgvDetalles.Columns["ID"].HeaderText = "Nro. Pedido";
        }

        private void HabilitarControles()
        {
            if (_proveedor != null) txtProveedor.Text = _proveedor.RazonSocial.ToString();

            CargarGrillaDetalles();

            if (Modificacion)
            {

            }
            else
            {

            }

        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores { };
            f.ObjetoSeleccionado = _proveedor;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _proveedor = f.ObjetoSeleccionado;

                HabilitarControles();
            }
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

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            _proveedor = null;
            HabilitarControles();
        }
    }
}
