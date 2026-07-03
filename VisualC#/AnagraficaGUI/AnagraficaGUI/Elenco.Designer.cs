namespace AnagraficaGUI
{
    partial class Elenco
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitolo = new Label();
            lblItemsTrovati = new Label();
            txtElenco = new TextBox();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitolo.Location = new Point(293, 22);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(151, 25);
            lblTitolo.TabIndex = 0;
            lblTitolo.Text = "Elenco Studenti";
            // 
            // lblItemsTrovati
            // 
            lblItemsTrovati.AutoSize = true;
            lblItemsTrovati.Location = new Point(28, 103);
            lblItemsTrovati.Name = "lblItemsTrovati";
            lblItemsTrovati.Size = new Size(92, 15);
            lblItemsTrovati.TabIndex = 1;
            lblItemsTrovati.Text = "Elementi Trovati";
            // 
            // txtElenco
            // 
            txtElenco.BackColor = Color.White;
            txtElenco.Location = new Point(28, 134);
            txtElenco.Multiline = true;
            txtElenco.Name = "txtElenco";
            txtElenco.ReadOnly = true;
            txtElenco.Size = new Size(589, 275);
            txtElenco.TabIndex = 2;
            // 
            // Elenco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 450);
            Controls.Add(txtElenco);
            Controls.Add(lblItemsTrovati);
            Controls.Add(lblTitolo);
            Name = "Elenco";
            Text = "Elenco Anagrafica";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private Label lblItemsTrovati;
        private TextBox txtElenco;
    }
}
