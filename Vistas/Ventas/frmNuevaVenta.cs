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
        private List<Producto> _productos;
        private decimal _subtotal;
        private decimal _descuento;
        private decimal _total;        
        private Venta _venta;

        public Cliente Cliente { get { return _cliente; } set {  _cliente = value; } }


        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private void CalcularSubTotal()
        {
            _subtotal = 0;
            foreach (Producto producto in _productos)
            {
                _subtotal += producto.Costo.Value + (producto.Costo.Value * producto.Categoria.Utilidad) / 100
            }
        }
    }
}
