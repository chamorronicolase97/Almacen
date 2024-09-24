using Almacen.Clases;
using Almacen.Clases.Administracion;
using Almacen.Clases.Compra;
using Sistema;
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
    public partial class frmABMSPedidos : Form
    {
        private BindingSource bindingSource;
        private bool _modoSeleccion;
        public Pedido Pedido { get; set; }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        public frmABMSPedidos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        private void frmABMSPedidos_Load(object sender, EventArgs e)

        {
            if (_modoSeleccion)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
            }
            CargarGrilla();
        }

        private void CargarGrilla()
        {

            var pedidosview = Pedido.ListarPedidos().Select(p => new
            {
                p.ID,
                p.Proveedor.RazonSocial,
                p.FechaEntrega
            }).ToList();
            bindingSource.DataSource = pedidosview;
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["RazonSocial"].HeaderText = "Razón Social";
            dgvDatos.Columns["FechaEntrega"].HeaderText = "Fecha Entrega";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCPedido f = new frmAMCPedido();
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Pedido Clase = new Pedido(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Pedido " + Clase.ID + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (Clase.TieneRecepcion())
            {
                frmMostrarMensaje.MostrarMensaje($"{Pedido.NombreClase}", "El " + Pedido.NombreClase + " posee una recepción, no puede eliminarse.");
                return;
            }
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Pedido.NombreClase}", "Baja de " + Pedido.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Pedido Clase = new Pedido(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value));

            frmAMCPedido f = new frmAMCPedido();
            f.Clase = Clase;
            f.Modificacion = true;
            f.Show();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Pedido = new Pedido(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value));
            this.DialogResult = DialogResult.OK;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMCPedido f = new frmAMCPedido();
                Pedido pedido = new Pedido(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value));
                f.SoloLectura = true;
                f.Clase = pedido;
                f.Show(this);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim().ToLower();
            var pedidosview = Pedido.ListarPedidos()
                .Where(p => p.Proveedor.RazonSocial.ToLower().Contains(filtro))
                .Select(p => new
                {
                    p.ID,
                    p.Proveedor.RazonSocial,
                    p.FechaEntrega
                }).ToList();

            bindingSource.DataSource = pedidosview;
            dgvDatos.DataSource = bindingSource;
        }

    }
}
