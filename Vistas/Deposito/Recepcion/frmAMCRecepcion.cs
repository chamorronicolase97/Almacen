using Almacen.Clases;
using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
using Almacen.Clases.Sistema;
using NEntidadesFinancieras;
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
        private List<DetalleRecepcion> listaRecepcion;        

        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCRecepcion()
        {
            InitializeComponent();

        }

        private void frmAMCRecepcion_Load(object sender, EventArgs e)
        {
            if(Clase != null)
            {               
                Proveedor = Clase.Pedido.Proveedor;
                txtProveedor.Text = Proveedor.RazonSocial.ToString();
                txtNroPedido.Text = Clase.ID.ToString();
                dtpFechaEntrega.Value = Clase.FechaEntrega;
                txtRecepcionID.Text = Clase.ID.ToString();

                if (_soloLectura)
                {
                    dtpFechaEntrega.Enabled = false;
                }
                CargarGrillaDetalles();
            }
            else
            {
                txtProveedor.Text = Proveedor.RazonSocial.ToString();
                txtNroPedido.Text = Pedido.ID.ToString();               
            }
            txtProveedor.ReadOnly = true;
            txtNroPedido.ReadOnly = true;
            txtRecepcionID.ReadOnly = true;         
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {       
            if(Clase != null)
            {
                if(Clase.Estado.PedidoEstadoID == PedidoEstado.EnEdicion.PedidoEstadoID)
                {
                    if (dgvDetalles.Rows.Count != 0)
                    {
                        frmMostrarMensaje.MostrarMensaje("Recepcion", "Ya tiene productos ingresados, eliminelos antes de cancelar la recepción");
                        return;
                    }

                    if (MessageBox.Show("¿Desea Eliminar la  recepción iniciada?", "Recepcion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Clase.Eliminar();
                    }

                }
            }

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
                Clase.Estado = PedidoEstado.EnEdicion;
                Clase.Insertar();
                
            }

            //actualizacion stock
            if (Clase.Estado.PedidoEstadoID == PedidoEstado.Confirmado.PedidoEstadoID)
            {

                List<DetalleRecepcion> recepcion = DetalleRecepcion.ListarDetallesRecepciones(Clase);

                foreach (DetalleRecepcion rec in recepcion)
                {
                    rec.Producto.Stock += rec.Cantidad;
                    rec.Producto.Modificar();
                }

                //imprimir comprobante.            
                ComprobanteRecepcionPDF comprobante = new ComprobanteRecepcionPDF(Clase, recepcion);

                var Renderer = new IronPdf.ChromePdfRenderer();
                using var PDF = Renderer.RenderHtmlAsPdf(comprobante.GenerarHtml());
                Renderer.RenderingOptions.HtmlHeader = new HtmlHeaderFooter()
                {
                    MaxHeight = 30,
                    HtmlFragment = comprobante.GetEncabezado()
                };

                var contentLength = PDF.BinaryData.Length;


                //PDF.SaveAsPdfA($"ComprobanteVenta_{venta.ID}");  

                Utilidades.VerPDFTemporal($"Recepcion_{Clase.ID}", PDF.BinaryData);
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool Validar()
        {
            if (dtpFechaEntrega == null)
            {
                frmMostrarMensaje.MostrarMensaje("Recepcion", "Debe definir una fecha de recepción.");
                return false;
            }

            if (Clase.Estado.PedidoEstadoID == PedidoEstado.EnEdicion.PedidoEstadoID)
            {
                if (MessageBox.Show("¿Desea finalizar la recepción?", "Recepcion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Clase.Estado = PedidoEstado.Confirmado;
                }
            }

            return true;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {           
            if (Clase == null)
            {
                Clase = new Recepcion()
                {
                    FechaEntrega = dtpFechaEntrega.Value,
                    Pedido = Pedido,
                    Estado = PedidoEstado.EnEdicion
                };
                Clase.Insertar();
            }

            frmAMCDetalleRecepcion f = new frmAMCDetalleRecepcion();
            f.Proveedor = Proveedor;
            f.Recepcion = Clase;
            f.ShowDialog(this);

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
