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

        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }


        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            txtCliente.Text = _cliente.Denominacion;

            CalcularSubTotal();
            CalcularDescuento();
            CalcularTotal();
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


        }
    }
}
