namespace Almacen.Vistas
{
    partial class frmAMCPedido
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtFechaEntrega = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txtID = new TextBox();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAceptar.Location = new Point(175, 113);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(82, 22);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Location = new Point(263, 113);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(82, 22);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtFechaEntrega
            // 
            txtFechaEntrega.Anchor = AnchorStyles.Bottom;
            txtFechaEntrega.Location = new Point(97, 56);
            txtFechaEntrega.Margin = new Padding(3, 2, 3, 2);
            txtFechaEntrega.Name = "txtFechaEntrega";
            txtFechaEntrega.Size = new Size(173, 23);
            txtFechaEntrega.TabIndex = 2;            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(12, 59);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "Fecha Entrega";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Location = new Point(71, 34);
            label3.Name = "label3";
            label3.Size = new Size(18, 15);
            label3.TabIndex = 6;
            label3.Text = "ID";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Bottom;
            txtID.Enabled = false;
            txtID.Location = new Point(97, 32);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.Size = new Size(66, 23);
            txtID.TabIndex = 7;
            txtID.TextChanged += this.txtID_TextChanged;
            // 
            // frmAMCPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 144);
            Controls.Add(txtFechaEntrega);
            Controls.Add(txtID);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmAMCPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedido";
            Load += frmAMCPedido_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtFechaEntrega;
        private Label label1;
        private Label label3;
        private TextBox txtID;
    }
}