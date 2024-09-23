using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
using Almacen.Clases.Sistema;
using Almacen.Clases.Venta;
using Azure.Core;
using NEntidadesFinancieras;
using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen.Vistas.Ventas
{
    public partial class frmPrincipalVentas : Form
    {
        private Usuario _usuario;
        private Cliente _cliente;
        private decimal _total;
        private List<Venta> _ventas;

        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }
        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }

        public frmPrincipalVentas()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmABMSClientes f = new frmABMSClientes();
            f.Show();
        }

        private void frmPrincipalVentas_Load(object sender, EventArgs e)
        {
            txtOperador.Text = $"Operador: {Usuario.NombreApellido}";
            _ventas = Venta.ListarVentasEnEldia(Usuario);
            CargarGrilla();
            CalcularTotal();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            frmABMSClientes clientes = new frmABMSClientes();
            clientes.ShowDialog();

            if (clientes.DialogResult != DialogResult.OK) return;

            frmNuevaVenta f = new frmNuevaVenta();
            f.Cliente = clientes.ObjetoSeleccionado;
            f.Usuario = Usuario;
            f.ShowDialog();

            if (f.DialogResult == DialogResult.OK) CargarGrilla();

        }

        private void CargarGrilla()
        {
            string q = $@"SELECT v.VentaID, v.NroCliente, cli.Denominacion, v.Total
                FROM dbo.Ventas v
                left join dbo.Clientes cli on cli.ClienteID = v.NroCliente
            where CONVERT(DATE, v.FechaVenta) = CONVERT(DATE, '{dtpFecha.Value.ToString("yyyyMMdd")}')
            and v.CodUsuarioCaja = @CodUsuario;";

            SqlCommand cmd = new SqlCommand(q);
            cmd.Parameters.Add("@CodUsuario", SqlDbType.VarChar).Value = Usuario.CodUsuario;
            Conexion cn = new Conexion();
            dgvDatos.DataSource = cn.Consultar(cmd);
        }

        private void CalcularTotal()
        {
            _total = 0;
            if (_ventas == null || _ventas.Count == 0) return;

            foreach (Venta venta in _ventas)
            {
                _total += venta.Total.GetValueOrDefault(0);
            }

            txtTotal.Text = _total.ToString();
        }

        private void  btnImprimirComprobante_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Venta venta = new Venta(Convert.ToInt32(dgvDatos.CurrentRow.Cells["VentaID"].Value));

            if (venta == null)
            {
                frmMostrarMensaje.MostrarMensaje("Imprimir Comprobante", "No se pudo obtener la venta seleccionada.");
                return;               
            }

            List<DetalleVenta> detalleVentas = DetalleVenta.ListarDetallesVentas(venta.ID);

            ComprobanteVentaPDF PDFHTML = new ComprobanteVentaPDF(venta, detalleVentas);

            var Renderer = new IronPdf.ChromePdfRenderer();
            using var PDF = Renderer.RenderHtmlAsPdf(PDFHTML.GenerarHtml()); 

            var contentLength = PDF.BinaryData.Length;


            //PDF.SaveAsPdfA($"ComprobanteVenta_{venta.ID}");  
                        
            Utilidades.VerPDFTemporal($"Venta_{venta.ID}", PDF.BinaryData);
        }
    }
}
