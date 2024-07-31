namespace Almacen.Vistas
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            principalToolStripMenuItem = new ToolStripMenuItem();
            cambiarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            reiniciarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            depositoToolStripMenuItem = new ToolStripMenuItem();
            compraToolStripMenuItem = new ToolStripMenuItem();
            ventaToolStripMenuItem = new ToolStripMenuItem();
            administraciónToolStripMenuItem = new ToolStripMenuItem();
            categoriasToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            gruposToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            monthCalendar1 = new MonthCalendar();
            panel1 = new Panel();
            lblBienvenido = new Label();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { principalToolStripMenuItem, depositoToolStripMenuItem, compraToolStripMenuItem, ventaToolStripMenuItem, administraciónToolStripMenuItem, configuraciónToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // principalToolStripMenuItem
            // 
            principalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cambiarUsuarioToolStripMenuItem, reiniciarToolStripMenuItem, salirToolStripMenuItem });
            principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            principalToolStripMenuItem.Size = new Size(80, 24);
            principalToolStripMenuItem.Text = "Principal";
            // 
            // cambiarUsuarioToolStripMenuItem
            // 
            cambiarUsuarioToolStripMenuItem.Name = "cambiarUsuarioToolStripMenuItem";
            cambiarUsuarioToolStripMenuItem.Size = new Size(202, 26);
            cambiarUsuarioToolStripMenuItem.Text = "Cambiar Usuario";
            cambiarUsuarioToolStripMenuItem.Click += cambiarUsuarioToolStripMenuItem_Click;
            // 
            // reiniciarToolStripMenuItem
            // 
            reiniciarToolStripMenuItem.Name = "reiniciarToolStripMenuItem";
            reiniciarToolStripMenuItem.Size = new Size(202, 26);
            reiniciarToolStripMenuItem.Text = "Reiniciar";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(202, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // depositoToolStripMenuItem
            // 
            depositoToolStripMenuItem.Name = "depositoToolStripMenuItem";
            depositoToolStripMenuItem.Size = new Size(84, 24);
            depositoToolStripMenuItem.Text = "Deposito";
            // 
            // compraToolStripMenuItem
            // 
            compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            compraToolStripMenuItem.Size = new Size(76, 24);
            compraToolStripMenuItem.Text = "Compra";
            // 
            // ventaToolStripMenuItem
            // 
            ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            ventaToolStripMenuItem.Size = new Size(60, 24);
            ventaToolStripMenuItem.Text = "Venta";
            // 
            // administraciónToolStripMenuItem
            // 
            administraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriasToolStripMenuItem, productosToolStripMenuItem, proveedoresToolStripMenuItem });
            administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            administraciónToolStripMenuItem.Size = new Size(123, 24);
            administraciónToolStripMenuItem.Text = "Administración";
            // 
            // categoriasToolStripMenuItem
            // 
            categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            categoriasToolStripMenuItem.Size = new Size(174, 26);
            categoriasToolStripMenuItem.Text = "Categorias";
            categoriasToolStripMenuItem.Click += categoriasToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(174, 26);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(174, 26);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += proveedoresToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gruposToolStripMenuItem, usuariosToolStripMenuItem, permisosToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(116, 24);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // gruposToolStripMenuItem
            // 
            gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            gruposToolStripMenuItem.Size = new Size(224, 26);
            gruposToolStripMenuItem.Text = "Grupos";
            gruposToolStripMenuItem.Click += gruposToolStripMenuItem_Click;
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(224, 26);
            usuariosToolStripMenuItem.Text = "Usuarios";
            usuariosToolStripMenuItem.Click += usuariosToolStripMenuItem_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            monthCalendar1.Location = new Point(610, 376);
            monthCalendar1.Margin = new Padding(10, 12, 10, 12);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblBienvenido);
            panel1.Location = new Point(610, 188);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(283, 133);
            panel1.TabIndex = 2;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Location = new Point(17, 23);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(88, 20);
            lblBienvenido.TabIndex = 0;
            lblBienvenido.Text = "Bienvenid@";
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(224, 26);
            permisosToolStripMenuItem.Text = "Permisos";
            permisosToolStripMenuItem.Click += permisosToolStripMenuItem_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel1);
            Controls.Add(monthCalendar1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmPrincipal";
            Text = "Almacen";
            Load += frmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem principalToolStripMenuItem;
        private ToolStripMenuItem depositoToolStripMenuItem;
        private ToolStripMenuItem compraToolStripMenuItem;
        private ToolStripMenuItem ventaToolStripMenuItem;
        private ToolStripMenuItem administraciónToolStripMenuItem;
        private ToolStripMenuItem cambiarUsuarioToolStripMenuItem;
        private ToolStripMenuItem reiniciarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem categoriasToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripMenuItem gruposToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private Panel panel1;
        private Label lblBienvenido;
        protected MonthCalendar monthCalendar1;
        private ToolStripMenuItem permisosToolStripMenuItem;
    }
}