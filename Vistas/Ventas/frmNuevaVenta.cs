using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
using Almacen.Clases.Venta;
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
        private List<DetalleVenta> _detalleVenta;
        private decimal _subtotal;
        private decimal _descuento;
        private decimal _total;
        private Venta _venta;
        private DetalleVenta _detalle;
        private Usuario _usuario;

        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }
        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }

        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            txtCliente.Text = _cliente.Denominacion;
            _detalleVenta = new List<DetalleVenta>();

            _venta = new Venta(0);
            _venta.Cliente = _cliente;
            _venta.FechaVenta = DateTime.Now;
            _venta.Usuario = _usuario;

            _venta.Insertar();

            CargarDetalleVenta();

        }

        private void CalcularSubTotal()
        {
            _subtotal = 0;

            foreach (DetalleVenta detalle in _detalleVenta)
            {
                _subtotal += detalle.SubTotal;
            }

            txtSubTotal.Text = _subtotal.ToString();
        }

        private void CalcularDescuento()
        {
            _descuento = 0;
            if (_cliente.Empleado) _descuento += 5;
            if (_cliente.Preferencial) _descuento += 5;
            txtDescuento.Text = _descuento.ToString();
        }
        private void CalcularTotal()
        {
            _total = _subtotal - ((_subtotal * _descuento) / 100);
            txtTotal.Text = _total.ToString();
        }

        private void CargarDetalleVenta()
        {
            string query = $@"SELECT DetallesVentas.Cantidad, Productos.Descripcion, dbo.PrecioVenta(Productos.ProductoID) 'Precio Venta',  DetallesVentas.SubTotal
                              FROM DetallesVentas
                              INNER JOIN Productos ON DetallesVentas.ProductoID = Productos.ProductoID
                              WHERE  VentaID = @VentaID";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Add("@VentaID", SqlDbType.Int).Value = _venta.ID;

            Conexion cn = new Conexion();

            dgvDatos.DataSource = cn.Consultar(cmd);

            if (_detalleVenta.Count != 0) //FIXME moverlo a otro metodo que habilite y valide todo
            {
                CalcularSubTotal();
                CalcularDescuento();
                CalcularTotal();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmABMSProductos f = new frmABMSProductos();
            f.ShowDialog();
            if (f.DialogResult != DialogResult.OK) return;
            _producto = f.ObjetoSeleccionado;

            InputCantidad inputCantidad = new InputCantidad();
            inputCantidad.ShowDialog();
            if (inputCantidad.DialogResult != DialogResult.OK) return;
            int cantidad = Convert.ToInt32(inputCantidad.Cantidad);

            _detalle = new DetalleVenta();
            _detalle.Cantidad = cantidad;
            _detalle.Venta = _venta;
            _detalle.Producto = _producto;

            //calcular SubTotal
            _detalle.SubTotal = _detalle.Cantidad * (_detalle.Producto.Costo.Value + ((_detalle.Producto.Costo.Value * _detalle.Producto.Categoria.Utilidad) / 100));

            _detalle.Insertar();

            _detalleVenta.Add(_detalle);

            CargarDetalleVenta();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Detalle Final.

            _venta.Total = Convert.ToDecimal(txtTotal.Text);
            _venta.Modificar();
            //Elegir Medio De Pago.

            //imprimir comprobante.

            //Mostrar Operación Exitosa.
            frmMostrarMensaje.MostrarMensaje("Venta", "Venta exitosa");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
