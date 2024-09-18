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
    public partial class frmAMCRecepcion : Form
    {
        public Recepcion Clase { get; set; }
        public Pedido Pedido { get; set; }
        public Proveedor Proveedor { get; set; }
        public bool Modificacion { get; set; } = false;
        protected bool _soloLectura;

        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCRecepcion()
        {
            InitializeComponent();

        }

        private void frmAMCPedido_Load(object sender, EventArgs e)
        {
            if(Clase != null)
            {
                CargarGrillaDetalles();
                Proveedor = Clase.Pedido.Proveedor;
                txtProveedor.Text = Proveedor.RazonSocial.ToString();
                txtNroPedido.Text = Clase.ID.ToString();
                dtpFechaEntrega.Value = Clase.FechaEntrega;
                txtRecepcionID.Text = Clase.ID.ToString();

                if (_soloLectura)
                {
                    dtpFechaEntrega.Enabled = false;
                }
            }
            else
            {
                txtNroPedido.Text = Pedido.ID.ToString();
                txtRecepcionID.Text = Recepcion.CalcularNroRecepcion().ToString();
            }
            txtProveedor.ReadOnly = true;
            txtNroPedido.ReadOnly = true;
            txtRecepcionID.ReadOnly = true;
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
            Clase = Recepcion.GetRecepcion(Convert.ToInt32(txtRecepcionID.Text));
            if (Clase == null)
            {
                Clase = new Recepcion()
                {
                    FechaEntrega = dtpFechaEntrega.Value,
                    Pedido = Pedido
                };
                Clase.Insertar();
            }

            frmAMCDetalleRecepcion f = new frmAMCDetalleRecepcion();
            f.Proveedor = Proveedor;
            f.Recepcion = Clase;
            f.Show();

            CargarGrillaDetalles();
        }

        private void CargarGrillaDetalles()
        {
            var recepciones = DetalleRecepcion.ListarDetallesRecepciones(Clase).Select(p => new
            {
                p.Producto.Descripcion,
                p.Cantidad,
                p.CostoUnitario
            }).ToList();

            dgvDetalles.DataSource = recepciones;
        }

    }
}
