using Almacen.Clases.Administracion;
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
    public partial class frmPrincipalVentas : Form
    {
        private Usuario _usuario;
        private decimal _total;

        public Usuario Usuario { get { return _usuario; } set { _usuario = value; } }


        public frmPrincipalVentas()
        {
            InitializeComponent();
        }

        private void frmPrincipalVentas_Load(object sender, EventArgs e)
        {
            lblOperador.Text = $"Operador: {Usuario.NombreApellido}";

            CustomToolTip.SetToolTip(btnNuevaVenta, "Iniciar nueva Venta");
        }



        private void CalcularTotal()
        {
            //HACER CALCULOS.
            txtTotal.Text = _total.ToString();  
        }
    }
}
