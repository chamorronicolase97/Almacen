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
    public partial class frmAMCUsuario : Form
    {
        public Usuario Clase { get; set; }

        public bool Modificacion { get; set; } = false;

        public frmAMCUsuario()
        {
            InitializeComponent();

        }

        private void frmAMCCategoria_Load(object sender, EventArgs e)
        {
            #region Combo Grupos
            List<Grupo> ListaGrupos = Grupo.ListarGrupos();

            Grupo grupo = new Grupo()
            {
                ID = 0,
                Descripcion = "Seleccione"
            };

            ListaGrupos.Insert(0, grupo);


            cmbGrupo.ValueMember = "ID";
            cmbGrupo.DisplayMember = "Descripcion";
            cmbGrupo.DataSource = ListaGrupos;
            #endregion


            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtNomApe.Text = Clase.NombreApellido;
                txtUsuario.Text = Clase.CodUsuario;
                txtContraseña.Text = Clase.Contraseña;
                cmbGrupo.Text = Clase.Grupo.Descripcion;
                cmbGrupo.Enabled = false;
            }
            else
            {                

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            Clase.NombreApellido = txtNomApe.Text;
            Clase.CodUsuario = txtUsuario.Text;
            Clase.Contraseña = txtContraseña.Text;
            Clase.Grupo = new Grupo(Convert.ToInt32(cmbGrupo.SelectedValue));

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
            if (txtNomApe.Text.Length <= 0)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir un nombre y apellido para el Usuario");
                return false;
            }

            if (cmbGrupo.SelectedIndex == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe seleccionar un grupo");
                return false;
            }


            return true;
        }


    }
}
