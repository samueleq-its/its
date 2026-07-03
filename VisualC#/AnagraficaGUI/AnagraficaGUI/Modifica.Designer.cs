namespace AnagraficaGUI
{
    partial class Modifica
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
            pnlDati = new Panel();
            btnCancella = new Button();
            btnSalva = new Button();
            lblMatricola = new Label();
            txtMatricola = new TextBox();
            txtClasse = new TextBox();
            lblNome = new Label();
            lblClasse = new Label();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            lblCognome = new Label();
            lblEmail = new Label();
            txtCognome = new TextBox();
            pnlCerca = new Panel();
            lblCerca = new Label();
            txtCerca = new TextBox();
            btnCerca = new Button();
            pnlDati.SuspendLayout();
            pnlCerca.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitolo.Location = new Point(118, 9);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(176, 25);
            lblTitolo.TabIndex = 19;
            lblTitolo.Text = "Modifica Studente";
            // 
            // pnlDati
            // 
            pnlDati.Controls.Add(btnCancella);
            pnlDati.Controls.Add(btnSalva);
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
            pnlDati.Location = new Point(15, 133);
            pnlDati.Name = "pnlDati";
            pnlDati.Size = new Size(410, 257);
            pnlDati.TabIndex = 18;
            // 
            // btnCancella
            // 
            btnCancella.Location = new Point(242, 214);
            btnCancella.Name = "btnCancella";
            btnCancella.Size = new Size(75, 23);
            btnCancella.TabIndex = 15;
            btnCancella.Text = "cancella";
            btnCancella.UseVisualStyleBackColor = true;
            btnCancella.Click += btnCancella_Click;
            // 
            // btnSalva
            // 
            btnSalva.Location = new Point(120, 214);
            btnSalva.Name = "btnSalva";
            btnSalva.Size = new Size(75, 23);
            btnSalva.TabIndex = 14;
            btnSalva.Text = "Salva";
            btnSalva.UseVisualStyleBackColor = true;
            btnSalva.Click += btnSalva_Click;
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
            txtMatricola.ReadOnly = true;
            txtMatricola.Size = new Size(237, 23);
            txtMatricola.TabIndex = 5;
            // 
            // txtClasse
            // 
            txtClasse.Location = new Point(119, 165);
            txtClasse.Name = "txtClasse";
            txtClasse.Size = new Size(237, 23);
            txtClasse.TabIndex = 13;
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
            // lblClasse
            // 
            lblClasse.AutoSize = true;
            lblClasse.Location = new Point(55, 168);
            lblClasse.Name = "lblClasse";
            lblClasse.Size = new Size(40, 15);
            lblClasse.TabIndex = 12;
            lblClasse.Text = "Classe";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(119, 78);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(237, 23);
            txtNome.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(119, 136);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(237, 23);
            txtEmail.TabIndex = 11;
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
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(55, 139);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email";
            // 
            // txtCognome
            // 
            txtCognome.Location = new Point(119, 107);
            txtCognome.Name = "txtCognome";
            txtCognome.Size = new Size(237, 23);
            txtCognome.TabIndex = 9;
            // 
            // pnlCerca
            // 
            pnlCerca.BackColor = SystemColors.ControlLight;
            pnlCerca.Controls.Add(lblCerca);
            pnlCerca.Controls.Add(txtCerca);
            pnlCerca.Controls.Add(btnCerca);
            pnlCerca.Location = new Point(15, 64);
            pnlCerca.Name = "pnlCerca";
            pnlCerca.Size = new Size(410, 63);
            pnlCerca.TabIndex = 20;
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
            // Modifica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 561);
            Controls.Add(pnlCerca);
            Controls.Add(lblTitolo);
            Controls.Add(pnlDati);
            Name = "Modifica";
            Text = "Modifica";
            pnlDati.ResumeLayout(false);
            pnlDati.PerformLayout();
            pnlCerca.ResumeLayout(false);
            pnlCerca.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private Panel pnlDati;
        private Button btnCancella;
        private Button btnSalva;
        private Label lblMatricola;
        private TextBox txtMatricola;
        private TextBox txtClasse;
        private Label lblNome;
        private Label lblClasse;
        private TextBox txtNome;
        private TextBox txtEmail;
        private Label lblCognome;
        private Label lblEmail;
        private TextBox txtCognome;
        private Panel pnlCerca;
        private Label lblCerca;
        private TextBox txtCerca;
        private Button btnCerca;
    }
}