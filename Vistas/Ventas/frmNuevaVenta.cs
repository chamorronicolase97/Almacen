using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
using Almacen.Clases.Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen.Vistas.Ventas
{
    public partial class frmNuevaVenta : Form
    {

        private Cliente _cliente;
        private Producto _producto;
        private List<Producto> _productos;
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
            _productos = new List<Producto>();  
            
            _venta = new Venta(0);
            _venta.Cliente = _cliente;
            _venta.FechaVenta = DateTime.Now;
            _venta.Usuario = _usuario;

            _venta.Insertar();           

            if(_productos.Count != 0) //FIXME moverlo a otro metodo que habilite y valide todo
            {
            CalcularSubTotal();
            CalcularDescuento();
            CalcularTotal();
            }
        }

        private void CalcularSubTotal()
        {
            _subtotal = 0;
            
            foreach (Producto producto in _productos)
            {
                _subtotal += producto.Costo.Value + ((producto.Costo.Value * producto.Categoria.Utilidad) / 100);
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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           frmABMSProductos f = new frmABMSProductos();
            f.ShowDialog();
            if (f.DialogResult != DialogResult.OK) return;
            _producto = f.ObjetoSeleccionado;

            InputCantidad inputCantidad = new InputCantidad();
            inputCantidad.ShowDialog();
            if(inputCantidad.DialogResult != DialogResult.OK) return;
            int cantidad = Convert.ToInt32(inputCantidad.Cantidad);

            _detalle = new DetalleVenta();
            _detalle.Cantidad = cantidad;
            _detalle.Venta = _venta;
            _detalle.Producto = _producto;

            _detalle.Insertar();
            
        }
    }
}
