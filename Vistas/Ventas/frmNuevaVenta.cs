using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
using Almacen.Clases.Sistema;
using Almacen.Clases.Venta;
using NComprobantesPDF;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Almacen.Vistas.Ventas
{
    public partial class frmNuevaVenta : Form
    {

        private Cliente _cliente;
        private Producto _producto;
        private List<Categoria> categorias;
        private List<DetalleVenta> _detalleVenta;
        private decimal _subtotal;
        private decimal _descuento;
        private decimal _total;
        private Venta _venta;
        private DetalleVenta _detalle;
        private Usuario _usuario;
        private BindingSource bindingSource;

        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }
        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }

        public frmNuevaVenta()
        {
            InitializeComponent();
            bindingSource = new BindingSource();
        }

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            categorias = Categoria.ListarCategorias();

            Categoria cat = new Categoria();
            cat.CategoriaID = 0;
            cat.Descripcion = "Categoria";
            categorias.Insert(0, cat);

            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.DataSource = categorias;

            txtCliente.Text = _cliente.Denominacion;
            txtOperador.Text = _usuario.NombreApellido;
            _detalleVenta = new List<DetalleVenta>();

            _venta = new Venta(0);
            _venta.Cliente = _cliente;
            _venta.FechaVenta = DateTime.Now;
            _venta.Usuario = _usuario;

            _venta.Insertar();

            CargarProductos();
            CargarDetalleVenta();

        }

        private void CalcularSubTotal()
        {
            _subtotal = 0;

            foreach (DetalleVenta detalle in _detalleVenta)
            {
                _subtotal += detalle.SubTotal;
            }

            txtSubTotal.Text = _subtotal.ToString("#00.00");
        }

        private void CalcularDescuento()
        {
            _descuento = 0;
            if (_cliente.Empleado) _descuento += 5;
            if (_cliente.Preferencial) _descuento += 5;
            txtDescuento.Text = _descuento.ToString() + " " + "%";
        }
        private void CalcularTotal()
        {
            _total = 0;
            _total = _subtotal - ((_subtotal * _descuento) / 100);
            txtTotal.Text = _total.ToString("#00.00");
        }

        private void CargarDetalleVenta()
        {
            string query = $@"SELECT DetallesVentas.DetalleVentaID, DetallesVentas.Cantidad, Productos.Descripcion, dbo.PrecioVenta(Productos.ProductoID) 'Precio Venta',  DetallesVentas.SubTotal
                              FROM DetallesVentas
                              INNER JOIN Productos ON DetallesVentas.ProductoID = Productos.ProductoID
                              WHERE  VentaID = @VentaID";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Add("@VentaID", SqlDbType.Int).Value = _venta.ID;

            Conexion cn = new Conexion();

            DataTable dtDatos = cn.Consultar(cmd);

            dgvDatos.DataSource = dtDatos;

            dgvDatos.Columns["DetalleVentaID"].Visible = false;

            CalcularSubTotal();
            CalcularDescuento();
            CalcularTotal();

        }        

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Detalle Final.
            if (dgvDatos.Rows.Count == 0) return;



            _venta.Total = Convert.ToDecimal(txtTotal.Text);
            _venta.Modificar();
            //Elegir Medio De Pago.            

            //Mostrar Operación Exitosa.
            string Detalle = $"Cliente: {_cliente.Denominacion}              Fecha y Hora: {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}" + Environment.NewLine;
            Detalle += Environment.NewLine;
            Detalle += $"Cajero: {_usuario.NombreApellido}" + Environment.NewLine;
            Detalle += Environment.NewLine;
            foreach (DetalleVenta dv in _detalleVenta)
            {
                Detalle += $"Cantidad: {dv.Cantidad}  Producto: {dv.Producto.Descripcion.Substring(0, 10)}  Precio Venta: $ {dv.Producto.ValorVenta:00.00}  SubTotal: $ {dv.SubTotal:00.00}" + Environment.NewLine;
                Detalle += Environment.NewLine;

                try
                {
                    dv.Producto.Stock -= dv.Cantidad;
                    dv.Producto.Modificar();
                }
                catch(Exception ex) 
                {
                    throw new Exception(ex.Message);
                }
            }

            Detalle += $"Total: $ {_venta.Total:00.00}";           

            frmMostrarMensajeDetalle.MostrarMensaje("Venta", "Venta exitosa", Detalle);

            //imprimir comprobante.

            ComprobanteVentaPDF PDFHTML = new ComprobanteVentaPDF(_venta, _detalleVenta);           

            var Renderer = new IronPdf.ChromePdfRenderer();
            using var PDF = Renderer.RenderHtmlAsPdf(PDFHTML.GenerarHtml());

            var contentLength = PDF.BinaryData.Length;


            //PDF.SaveAsPdfA($"ComprobanteVenta_{venta.ID}");  

            Utilidades.VerPDFTemporal($"Venta_{_venta.ID}", PDF.BinaryData);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            DetalleVenta Clase = new DetalleVenta(Convert.ToInt32(dgvDatos.CurrentRow.Cells["DetalleVentaID"].Value), _venta.ID);


            if (MessageBox.Show("Desea eliminar el detalle " + Clase.ID + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Clase.Eliminar();

                frmMostrarMensaje.MostrarMensaje($"{DetalleVenta.NombreClase}", "Baja de " + DetalleVenta.NombreClase + " exitosa.");
            }

            _detalleVenta.RemoveAll(x => x.ID == Clase.ID && x.Venta.ID == Clase.Venta.ID);

            CargarDetalleVenta();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            _producto = new Producto(Convert.ToInt32(dgvProductos.CurrentRow.Cells["ProductoID"].Value));



            InputCantidad inputCantidad = new InputCantidad();
            inputCantidad.ShowDialog();
            if (inputCantidad.DialogResult != DialogResult.OK) return;
            int cantidad = Convert.ToInt32(inputCantidad.Cantidad);

            _detalle = new DetalleVenta();
            _detalle.Cantidad = cantidad;
            _detalle.Venta = _venta;
            _detalle.Producto = _producto;

            //calcular SubTotal
            _detalle.SubTotal = _detalle.CalcularSubTotal;

            _detalle.Insertar();

            _detalleVenta.Add(_detalle);

            CargarDetalleVenta();
        }

        private void CargarProductos()
        {
            string query = $@"SELECT ProductoID, Descripcion, dbo.PrecioVenta(ProductoID) 'Precio Venta', CategoriaID FROM dbo.Productos WHERE Costo IS NOT NULL and Stock > 0";

            SqlCommand cmd = new SqlCommand(query);

            Conexion cn = new Conexion();

            DataTable dtDato = cn.Consultar(cmd);

            dgvProductos.DataSource = dtDato;

            dgvProductos.Columns["CategoriaID"].Visible = false;
            dgvProductos.Columns["ProductoID"].Visible = false;

            bindingSource.DataSource = dtDato;

            dgvDatos.DataSource = bindingSource;

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                bindingSource.Filter = $@"Descripcion LIKE '%{filtro}%'";
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedIndex == 0) return;

            Categoria categoria = (Categoria)cmbCategoria.SelectedItem;
            bindingSource.Filter = $@"CategoriaID = {categoria.CategoriaID}";
        }
    }
}
