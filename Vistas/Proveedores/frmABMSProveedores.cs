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
    public partial class frmABMSProveedores : Form
    {
        public frmABMSProveedores()
        {
            InitializeComponent();
        }

        private void frmABMSProveedores_Load(object sender, EventArgs e)
        
        {
            dgvDatos.DataSource = Categoria.Listar();
        }
    }
}
