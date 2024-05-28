using Almacen.Clases;
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
    public partial class frmABMSCategorias : Form
    {
        public frmABMSCategorias()
        {
            InitializeComponent();
        }

        private void frmABMSCategorias_Load(object sender, EventArgs e)

        {
            dgvDatos.DataSource = Categoria.Listar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAMCCategoria f = new frmAMCCategoria();
            f.ShowDialog();
        }
    }
}
