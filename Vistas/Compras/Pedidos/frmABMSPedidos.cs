using Almacen.Clases;
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

        public frmABMSPedidos()
        {
            InitializeComponent();

        }

        private void frmABMSPedidos_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Pedido.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Pedido.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCPedido f = new frmAMCPedido();
            f.Clase = new Pedido(0);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Pedido Clase = new Pedido(Convert.ToInt32(dgvDatos.CurrentRow.Cells["NroPedido"].Value));

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

            Pedido Clase = new Pedido(Convert.ToInt32(dgvDatos.CurrentRow.Cells["NroPedido"].Value));

            frmAMCPedido f = new frmAMCPedido();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }
    }
}
