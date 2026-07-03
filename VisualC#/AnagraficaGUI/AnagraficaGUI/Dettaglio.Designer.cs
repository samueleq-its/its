namespace AnagraficaGUI
{
    partial class Dettaglio
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
            lblCerca = new Label();
            txtCerca = new TextBox();
            btnCerca = new Button();
            lblMatricola = new Label();
            txtMatricola = new TextBox();
            txtNome = new TextBox();
            lblNome = new Label();
            txtCognome = new TextBox();
            lblCognome = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtClasse = new TextBox();
            lblClasse = new Label();
            pnlCerca = new Panel();
            pnlDati = new Panel();
            pnlCerca.SuspendLayout();
            pnlDati.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitolo.Location = new Point(106, 9);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(195, 25);
            lblTitolo.TabIndex = 0;
            lblTitolo.Text = "Dettaglio Anagrafica";
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
            // txtCerca
            // 
            txtCerca.Location = new Point(204, 20);
            txtCerca.Name = "txtCerca";
            txtCerca.Size = new Size(105, 23);
            txtCerca.TabIndex = 2;
            // 
            // btnCerca
            // 
            btnCerca.Location = new Point(315, 20);
            btnCerca.Name = "btnCerca";
            btnCerca.Size = new Size(75, 23);
            btnCerca.TabIndex = 3;
            btnCerca.Text = "Cerca";
            btnCerca.UseVisualStyleBackColor = true;
            btnCerca.Click += btnCerca_Click;
            // 
            // lblMatricola
            // 
            lblMatricola.AutoSize = true;
            lblMatricola.Location = new Point(55, 52);
            lblMatricola.Name = "lblMatricola";
            lblMatricola.Size = new Size(57, 15);
            lblMatricola.TabIndex = 4;
            lblMatricola.Text = "Matricola";
            // 
            // txtMatricola
            // 
            txtMatricola.Enabled = false;
            txtMatricola.Location = new Point(119, 49);
            txtMatricola.Name = "txtMatricola";
            txtMatricola.Size = new Size(237, 23);
            txtMatricola.TabIndex = 5;
            // 
            // txtNome
            // 
            txtNome.Enabled = false;
            txtNome.Location = new Point(119, 78);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(237, 23);
            txtNome.TabIndex = 7;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(55, 81);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 6;
            lblNome.Text = "Nome";
            // 
            // txtCognome
            // 
            txtCognome.Enabled = false;
            txtCognome.Location = new Point(119, 107);
            txtCognome.Name = "txtCognome";
            txtCognome.Size = new Size(237, 23);
            txtCognome.TabIndex = 9;
            // 
            // lblCognome
            // 
            lblCognome.AutoSize = true;
            lblCognome.Location = new Point(55, 110);
            lblCognome.Name = "lblCognome";
            lblCognome.Size = new Size(60, 15);
            lblCognome.TabIndex = 8;
            lblCognome.Text = "Cognome";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(119, 136);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(237, 23);
            txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(55, 139);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email";
            // 
            // txtClasse
            // 
            txtClasse.Enabled = false;
            txtClasse.Location = new Point(119, 165);
            txtClasse.Name = "txtClasse";
            txtClasse.Size = new Size(237, 23);
            txtClasse.TabIndex = 13;
            // 
            // lblClasse
            // 
            lblClasse.AutoSize = true;
            lblClasse.Location = new Point(55, 168);
            lblClasse.Name = "lblClasse";
            lblClasse.Size = new Size(40, 15);
            lblClasse.TabIndex = 12;
            lblClasse.Text = "Classe";
            // 
            // pnlCerca
            // 
            pnlCerca.BackColor = SystemColors.ControlLight;
            pnlCerca.Controls.Add(lblCerca);
            pnlCerca.Controls.Add(txtCerca);
            pnlCerca.Controls.Add(btnCerca);
            pnlCerca.Location = new Point(12, 62);
            pnlCerca.Name = "pnlCerca";
            pnlCerca.Size = new Size(410, 63);
            pnlCerca.TabIndex = 14;
            // 
            // pnlDati
            // 
            pnlDati.Controls.Add(lblMatricola);
            pnlDati.Controls.Add(txtMatricola);
            pnlDati.Controls.Add(txtClasse);
            pnlDati.Controls.Add(lblNome);
            pnlDati.Controls.Add(lblClasse);
            pnlDati.Controls.Add(txtNome);
            pnlDati.Controls.Add(txtEmail);
            pnlDati.Controls.Add(lblCognome);
            pnlDati.Controls.Add(lblEmail);
            pnlDati.Controls.Add(txtCognome);
            pnlDati.Location = new Point(12, 164);
            pnlDati.Name = "pnlDati";
            pnlDati.Size = new Size(410, 233);
            pnlDati.TabIndex = 15;
            // 
            // Dettaglio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 561);
            Controls.Add(pnlDati);
            Controls.Add(pnlCerca);
            Controls.Add(lblTitolo);
            Name = "Dettaglio";
            Text = "Dettaglio";
            pnlCerca.ResumeLayout(false);
            pnlCerca.PerformLayout();
            pnlDati.ResumeLayout(false);
            pnlDati.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private Label lblCerca;
        private TextBox txtCerca;
        private Button btnCerca;
        private Label lblMatricola;
        private TextBox txtMatricola;
        private TextBox txtNome;
        private Label lblNome;
        private TextBox txtCognome;
        private Label lblCognome;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtClasse;
        private Label lblClasse;
        private Panel pnlCerca;
        private Panel pnlDati;
    }
}