namespace GUIDiario
{
    partial class Leggi
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
            lblTitolo = new Label();
            txtCommenti = new TextBox();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitolo.Location = new Point(279, 20);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(214, 32);
            lblTitolo.TabIndex = 0;
            lblTitolo.Text = "Elenco Commenti";
            // 
            // txtCommenti
            // 
            txtCommenti.Location = new Point(39, 74);
            txtCommenti.Multiline = true;
            txtCommenti.Name = "txtCommenti";
            txtCommenti.ReadOnly = true;
            txtCommenti.Size = new Size(725, 325);
            txtCommenti.TabIndex = 1;
            // 
            // Leggi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCommenti);
            Controls.Add(lblTitolo);
            Name = "Leggi";
            Text = "Leggi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private TextBox txtCommenti;
    }
}