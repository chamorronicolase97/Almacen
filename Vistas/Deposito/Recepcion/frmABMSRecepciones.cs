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
    public partial class frmABMSRecepciones : Form
    {
        private Recepcion _objetoSeleccionado;
        public frmABMSRecepciones()
        {
            InitializeComponent();

        }
        public Recepcion ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSPedidos_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Recepcion.Listar();
        }

        private void CargarGrilla()
        {
            dgvDatos.DataSource = Recepcion.Listar();
        }


        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmABMSPedidos pedidos = new frmABMSPedidos();
            pedidos.ModoSeleccion = true;
            MessageBox.Show("Seleccione pedido a recepcionar", "Recepción", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pedidos.ShowDialog();
            if (pedidos.DialogResult != DialogResult.OK) return;
            Pedido pedido = pedidos.Pedido;
            Proveedor proveedor = pedido.Proveedor;
            pedidos.Close();

            frmAMCRecepcion f = new frmAMCRecepcion();
            f.Pedido = pedido;
            f.Proveedor = proveedor;
            f.SoloLectura = false;
            
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Recepcion Clase = new Recepcion(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Pedido " + Clase.ID + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            if (Clase.TieneRecepcion())
            {
                frmMostrarMensaje.MostrarMensaje($"{Recepcion.NombreClase}", "El " + Recepcion.NombreClase + " posee una recepción, no puede eliminarse.");
                return;
            }
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Recepcion.NombreClase}", "Baja de " + Recepcion.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Recepcion Clase = new Recepcion(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

            if (Clase.Estado.PedidoEstadoID == PedidoEstado.Confirmado.PedidoEstadoID || Clase.Estado.PedidoEstadoID == PedidoEstado.Cancelado.PedidoEstadoID)
            {
                frmMostrarMensaje.MostrarMensaje("Recepciones", "Las recepciones deben estar en Estado de Edición para ser modificadas.");
                return ;
            }

            frmAMCRecepcion f = new frmAMCRecepcion();
            f.Clase = Clase;
            f.Modificacion = true;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null)
            {
                frmMostrarMensaje.MostrarMensaje($"Seleccionar", "No hay ningún registro seleccionado");
                return;
            }

            _objetoSeleccionado = new Recepcion(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMCRecepcion f = new frmAMCRecepcion();
                Recepcion recepcion = new Recepcion(Convert.ToInt32(dgvDatos.CurrentRow.Cells["RecepcionID"].Value));
                f.SoloLectura = true;
                f.Clase = recepcion;
                f.Show(this);
            }
        }
    }
}
