using Almacen.Clases;
using Almacen.Clases.Administracion;
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

namespace Almacen.Vistas
{
    public partial class frmCostosProductos : Form
    {

        public frmCostosProductos()
        {
            InitializeComponent();

        }

        private void frmCostosProductos_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string q = $@"select p.ProductoID, p.Descripcion, drec.RecepcionID, drec.FechaRecepcion 'Fecha Recepcion', 
            p.Costo 'Costo Actual', p.Costo + (p.Costo * Utilidad)/100 'Precio Venta Actual',
            drec.CostoUnitario 'Nuevo Costo', drec.CostoUnitario + (drec.CostoUnitario * Utilidad)/100 'Nuevo Precio Venta',
            c.Descripcion 'Categoria', prov.RazonSocial 'Proveedor'   from DetallesRecepciones drec 
            left join Productos p on drec.ProductoID = p.ProductoID 
            left join Categorias c on c.CategoriaID = p.CategoriaID
            left join Proveedores prov on prov.ProveedorID = p.ProveedorID
            where CONVERT(DATE, drec.FechaRecepcion) = CONVERT(DATE, '{dtpFechaCosto.Value.ToString("yyyyMMdd")}');";

            SqlCommand cmd = new SqlCommand(q);
            Conexion cn = new Conexion();
            dgvDatos.DataSource = cn.Consultar(cmd);
        }

        private void btnActualizarCostos_Click(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;

            string q = $@"UPDATE Productos 
                        set Costo = (
                        SELECT CostoUnitario from DetallesRecepciones 
                        WHERE DetallesRecepciones.ProductoID = Productos.ProductoID 
                        and CONVERT(DATE, DetallesRecepciones.FechaRecepcion) = CONVERT(DATE, '{dtpFechaCosto.Value}'));";

            if (MessageBox.Show($"¿Desea actualizar el costo de {dgvDatos.RowCount} productos?", "Actualizar Costos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            SqlCommand cmd = new SqlCommand(q);
            try
            {
                Conexion cn = new Conexion();
                cn.Ejecutar(cmd);
                frmMostrarMensaje.MostrarMensaje("Actualización de Costos", "Actualización realizada correctamente.");
                CargarGrilla();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
        }
    }
}
