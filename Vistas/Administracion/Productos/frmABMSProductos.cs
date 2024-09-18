using Almacen.Clases;
using Almacen.Clases.Administracion;
using Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen.Vistas
{
    public partial class frmABMSProductos : Form
    {
        private Producto _objetoSeleccionado;
        private Proveedor _proveedor;
        private BindingSource bindingSource;
        private bool formularioCargado = false;
        private bool _modoSeleccion = false;

        public Proveedor FiltroProveedor { get { return _proveedor; } set { _proveedor = value; } }

        public frmABMSProductos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }

        public Producto ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        public bool ModoSeleccion { get { return _modoSeleccion; } set { _modoSeleccion = value; } }

        private void frmABMSProductos_Load(object sender, EventArgs e)
        {
            List<Categoria> categorias = Categoria.ListarCategorias();
            Categoria categoriaTodos = new Categoria(-1)
            {
                Descripcion = "Todos"
            };
            categorias.Sort(delegate (Categoria c1, Categoria c2) { return c1.Descripcion.CompareTo(c2.Descripcion); });
            categorias.Insert(0, categoriaTodos);

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.ValueMember = "CategoriaID";
            cmbCategoria.SelectedIndex = 0;


            List<Proveedor> proveedores = Proveedor.Listar();
            Proveedor proveedorTodos = new Proveedor(-1)
            {
                RazonSocial = "Todos"
            };
            proveedores.Sort(delegate (Proveedor c1, Proveedor c2) { return c1.RazonSocial.CompareTo(c2.RazonSocial); });
            proveedores.Insert(0, proveedorTodos);

            cmbProveedor.DataSource = proveedores;
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.ValueMember = "ID";
            cmbProveedor.SelectedIndex = 0;

            if (FiltroProveedor != null)
            {
                cmbProveedor.Enabled = false;
            }

            if(_modoSeleccion)
            {
                btnCrear.Enabled = false;
                btnModificar.Enabled = false;
                btnBorrar.Enabled = false;
            }

            CargarGrilla();

            formularioCargado = true;
        }

        private void CargarGrilla()
        {
            if (FiltroProveedor != null) { bindingSource.DataSource = Producto.ListarPorProveedor(FiltroProveedor); }
            else { bindingSource.DataSource = Producto.ListarGrilla(); }
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["ProductoID"].HeaderText = "ID";
            dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvDatos.Columns["CodigoDeBarra"].HeaderText = "Código de Barra";
            dgvDatos.Columns["Categoria"].HeaderText = "Categoría";
            dgvDatos.Columns["CategoriaID"].Visible = false;
            dgvDatos.Columns["ProveedorID"].Visible = false;

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCProducto f = new frmAMCProducto();
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Producto Clase = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Producto " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;
            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Producto.NombreClase}", "Baja de " + Producto.NombreClase + " exitosa.");

            CargarGrilla();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow == null) return;

            Producto Clase = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            frmAMCProducto f = new frmAMCProducto();
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

            _objetoSeleccionado = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroRapido();
        }

        private void AplicarFiltroRapido()
        {
            string str = "";
            string filtro = txtFiltro.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                bindingSource.RemoveFilter();
            }
            else
            {
                str += $@"Descripcion LIKE '%{filtro}%' OR Convert(Costo, 'System.String') LIKE '%{filtro}%'
                                        OR CodigoDeBarra LIKE '%{filtro}%' and ";
            }
            if (cmbCategoria.SelectedIndex > 0)
            {
                str += "CategoriaID =" + cmbCategoria.SelectedValue.ToString() + " and ";
            }
            if (cmbProveedor.SelectedIndex > 0)
            {
                str += "ProveedorID =" + cmbProveedor.SelectedValue.ToString() + " and ";
            }
            str += "1=1";
            bindingSource.Filter = str;
        }

        private void btnActualizarFiltro_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                Producto _producto = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));
                CargarGrilla();
            }
            else
            {
                CargarGrilla();
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;
            if (formularioCargado == false) return;
            AplicarFiltroRapido();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDatos == null) return;
            if (formularioCargado == false) return;
            AplicarFiltroRapido();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMCProducto f = new frmAMCProducto();
                Producto categoria = new Producto(Convert.ToInt32(dgvDatos.CurrentRow.Cells["ProductoID"].Value));
                f.SoloLectura = true;
                f.Clase = categoria;
                f.Show(this);
            }
        }
    }
}
