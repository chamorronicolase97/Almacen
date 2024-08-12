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
        protected bool _soloLectura;
        private Grupo? _grupo;
        public bool Modificacion { get; set; } = false;
        public bool SoloLectura { get { return _soloLectura; } set { _soloLectura = value; } }
        public frmAMCUsuario()
        {
            InitializeComponent();

        }

        private void frmAMCUsuario_Load(object sender, EventArgs e)
        {
            if (Modificacion == true)
            {
                txtID.Text = Clase.ID.ToString();
                txtNomApe.Text = Clase.NombreApellido;
                txtUsuario.Text = Clase.CodUsuario;
                txtContraseña.Text = Clase.Contraseña;
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
            Clase.Grupo = _grupo;

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
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir un NOMBRE y APELLIDO para el Usuario");
                return false;
            }

            List<string> nombre = txtNomApe.Text.Split(" ").ToList();
            if (nombre.Count < 2)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir un NOMBRE y APELLIDO para el Usuario");
                return false;
            }

            if (txtContraseña.Text.Length == 0)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe escribir una contraseña para el Usuario");
                return false;
            }

            if (_grupo == null)
            {
                frmMostrarMensaje.MostrarMensaje("Usuario", "Debe seleccionar un grupo");
                return false;
            }


            return true;
        }

        private void HabilitarControles()
        {
            if (_grupo != null) txtGrupo.Text = _grupo.Descripcion;
        }

        private void btnAsignarGrupo_Click(object sender, EventArgs e)
        {
            frmABMSGrupos f = new frmABMSGrupos { };
            f.ObjetoSeleccionado = _grupo;
            if (DialogResult.OK == f.ShowDialog(this))
            {
                _grupo = f.ObjetoSeleccionado;

                HabilitarControles();
            }
        }

        private void btnConsultarGrupo_Click(object sender, EventArgs e)
        {
            if (_grupo == null) return;

            frmAMCGrupo f = new frmAMCGrupo
            {
                Clase = _grupo,
                SoloLectura = true
            };
            f.ShowDialog(this);
        }

        private void btnQuitarGrupo_Click(object sender, EventArgs e)
        {
            if (_grupo == null) return;

            _grupo = null;
            HabilitarControles();
        }
    }
}
