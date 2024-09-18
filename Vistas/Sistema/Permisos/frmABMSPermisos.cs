using Almacen.Clases;
using Almacen.Clases.Administracion;
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
    public partial class frmABMSPermisos : Form
    {
        private Permiso _objetoSeleccionado;
        private BindingSource bindingSource;
        public frmABMSPermisos()
        {
            InitializeComponent();

            bindingSource = new BindingSource();
        }
        public Permiso ObjetoSeleccionado { get { return _objetoSeleccionado; } set { _objetoSeleccionado = value; } }
        private void frmABMSPermisos_Load(object sender, EventArgs e)

        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            bindingSource.DataSource = Permiso.ListarGrilla();
            dgvDatos.DataSource = bindingSource;

            dgvDatos.Columns["PermisoID"].HeaderText = "ID";
            dgvDatos.Columns["CodPermiso"].HeaderText = "Cod. Permiso";
            dgvDatos.Columns["Descripcion"].HeaderText = "Descripción";

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCPermiso f = new frmAMCPermiso();
            f.SoloLectura = false;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) CargarGrilla();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.CurrentCell == null) return;

            //Permiso Clase = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            //Clase.Eliminar();

            //frmMostrarMensaje.MostrarMensaje($"Baja de {Permiso.NombreClase}", "Correcta.");

            //CargarGrilla();

            if (dgvDatos.CurrentRow == null) return;

            Permiso Clase = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            DialogResult = MessageBox.Show("Desea eliminar el Permiso " + Clase.Descripcion + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.No) return;

            Clase.Eliminar();

            frmMostrarMensaje.MostrarMensaje($"{Permiso.NombreClase}", "Baja de " + Permiso.NombreClase + " exitosa.");

            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentCell == null) return;

            Permiso Clase = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            frmAMCPermiso f = new frmAMCPermiso();
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

            _objetoSeleccionado = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                frmAMCPermiso f = new frmAMCPermiso();
                Permiso permiso = new Permiso(Convert.ToInt32(dgvDatos.CurrentRow.Cells["PermisoID"].Value));
                f.SoloLectura = true;
                f.Clase = permiso;
                f.Show(this);
            }
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
                str += $@"CodPermiso LIKE '%{filtro}%' OR Descripcion LIKE '%{filtro}%' and ";
            }

            str += "1=1";
            bindingSource.Filter = str;
        }
    }
}
