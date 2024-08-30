using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
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
            lblOperador.Text = $"Operador: {Usuario.NombreApellido}";
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
            f.ShowDialog();

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
                _total += venta.Total;
            }

            txtTotal.Text = _total.ToString();
        }


    }
}
