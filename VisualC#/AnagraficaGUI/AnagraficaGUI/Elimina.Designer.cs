namespace AnagraficaGUI
{
    partial class Elimina
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
            pnlCerca = new Panel();
            lblCerca = new Label();
            txtElimina = new TextBox();
            btnElimina = new Button();
            lblTitolo = new Label();
            pnlCerca.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCerca
            // 
            pnlCerca.BackColor = SystemColors.ControlLight;
            pnlCerca.Controls.Add(lblCerca);
            pnlCerca.Controls.Add(txtElimina);
            pnlCerca.Controls.Add(btnElimina);
            pnlCerca.Location = new Point(12, 206);
            pnlCerca.Name = "pnlCerca";
            pnlCerca.Size = new Size(410, 63);
            pnlCerca.TabIndex = 21;
            // 
            // lblCerca
            // 
            lblCerca.AutoSize = true;
            lblCerca.Location = new Point(21, 23);
            lblCerca.Name = "lblCerca";
            lblCerca.Size = new Size(157, 15);
            lblCerca.TabIndex = 1;
            lblCerca.Text = "cerca studente per matricola";
            // 
            // txtElimina
            // 
            txtElimina.Location = new Point(204, 20);
            txtElimina.Name = "txtElimina";
            txtElimina.Size = new Size(105, 23);
            txtElimina.TabIndex = 2;
            // 
            // btnElimina
            // 
            btnElimina.Location = new Point(315, 20);
            btnElimina.Name = "btnElimina";
            btnElimina.Size = new Size(75, 23);
            btnElimina.TabIndex = 3;
            btnElimina.Text = "Elimina";
            btnElimina.UseVisualStyleBackColor = true;
            btnElimina.Click += btnElimina_Click;
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitolo.Location = new Point(125, 23);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(162, 25);
            lblTitolo.TabIndex = 20;
            lblTitolo.Text = "Elimina Studente";
            // 
            // Elimina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 561);
            Controls.Add(lblTitolo);
            Controls.Add(pnlCerca);
            Name = "Elimina";
            Text = "Elimina";
            pnlCerca.ResumeLayout(false);
            pnlCerca.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlCerca;
        private Label lblCerca;
        private TextBox txtElimina;
        private Button btnElimina;
        private Label lblTitolo;
    }
}