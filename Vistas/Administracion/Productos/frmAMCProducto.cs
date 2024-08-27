using Almacen.Clases;
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

namespace Almacen.Vistas
{
    public partial class frmAMCProducto : Form
    {
        public Producto Clase { get; set; }
        protected bool _soloLectura;
        private Proveedor? _proveedor;
        private Categoria? _categoria;

        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCProducto()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {

            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtDescripcion.Text = Clase.Descripcion;
                txtCosto.Text = Clase.Costo.ToString();
                txtCodBarra.Text = Clase.CodigoDeBarra;
            }
            else
            {
                //aqui no vamos a guardar el costo como valor inicial así que este campo lo deshabilito.
                txtCosto.Enabled = false;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.Descripcion = txtDescripcion.Text;
            Clase.Costo = null;
            Clase.CodigoDeBarra = txtCodBarra.Text;
            Clase.Proveedor = _proveedor;
            Clase.Categoria = _categoria;

            if (Modificacion)
            {
                Clase.Modificar();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Clase.Insertar();
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool Validar()
        {
            if (txtDescripcion.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe escribir una descripción para el producto");
                return false;
            }

            if (_categoria == null)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe seleccionar una Categoría");
                return false;
            }

            if (_proveedor == null)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe seleccionar un Proveedor");
                return false;
            }


            return true;
        }

        private void HabilitarControles()
        {
            if (_proveedor != null) txtProveedor.Text = _proveedor.RazonSocial;
            if (_categoria != null) txtCategoria.Text = _categoria.Descripcion;
        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            frmABMSProveedores f = new frmABMSProveedores { };
            f.ObjetoSeleccionado = _proveedor;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _proveedor = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }
        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            frmAMCProveedor f = new frmAMCProveedor
            {
                Clase = _proveedor,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            if (_proveedor == null) return;

            _proveedor = null;
            HabilitarControles();
        }

        private void btnAsignarCategoria_Click(object sender, EventArgs e)
        {
            frmABMSCategorias f = new frmABMSCategorias { };
            f.ObjetoSeleccionado = _categoria;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _categoria = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnConsultarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoria == null) return;

            frmAMCCategoria f = new frmAMCCategoria
            {
                Clase = _categoria,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnQuitarCategoria_Click(object sender, EventArgs e)
        {
            if (_categoria == null) return;

            _categoria = null;
            HabilitarControles();
        }
    }
}
