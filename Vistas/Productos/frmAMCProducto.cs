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

        public bool Modificacion { get; set; } = false;

        public frmAMCProducto()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            #region Combo Categorias
            List<Categoria> ListaCategorias = Categoria.ListarCategorias();

            Categoria cat = new Categoria()
            {
                ID = 0,
                Descripcion = "Seleccione"
            };

            ListaCategorias.Insert(0, cat);


            cmbCategoria.ValueMember = "ID";
            cmbCategoria.DisplayMember = "Descripcion";
            cmbCategoria.DataSource = ListaCategorias;
            #endregion


            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtDescripcion.Text = Clase.Descripcion;
                txtCosto.Text = Clase.Costo.ToString();
                txtCodBarra.Text = Clase.CodigoDeBarra;
                cmbCategoria.Text = Clase.Categoria.Descripcion;
                cmbCategoria.Enabled = false;
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
            Clase.Categoria = new Categoria(Convert.ToInt32(cmbCategoria.SelectedValue));

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
            if (txtDescripcion.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe escribir una descripción para el producto");
                return false;
            }

            if(cmbCategoria.SelectedIndex == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Producto", "Debe seleccionar una categoria");
                return false;
            }

            
            return true;
        }


    }
}
