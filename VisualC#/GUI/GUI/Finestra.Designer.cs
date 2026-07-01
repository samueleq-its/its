namespace GUI
{
    partial class Finestra
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
            txtTesto = new TextBox();
            btnInvia = new Button();
            lblTesto = new Label();
            lblRisultato = new Label();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Location = new Point(360, 31);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(38, 15);
            lblTitolo.TabIndex = 0;
            lblTitolo.Text = "Titolo";
            // 
            // txtTesto
            // 
            txtTesto.Location = new Point(117, 122);
            txtTesto.Name = "txtTesto";
            txtTesto.Size = new Size(260, 23);
            txtTesto.TabIndex = 1;
            // 
            // btnInvia
            // 
            btnInvia.Location = new Point(420, 122);
            btnInvia.Name = "btnInvia";
            btnInvia.Size = new Size(75, 23);
            btnInvia.TabIndex = 2;
            btnInvia.Text = "Invia";
            btnInvia.UseVisualStyleBackColor = true;
            btnInvia.Click += btnInvia_Click;
            // 
            // lblTesto
            // 
            lblTesto.AutoSize = true;
            lblTesto.Location = new Point(24, 126);
            lblTesto.Name = "lblTesto";
            lblTesto.Size = new Size(87, 15);
            lblTesto.TabIndex = 3;
            lblTesto.Text = "Inserisci il testo";
            // 
            // lblRisultato
            // 
            lblRisultato.AutoSize = true;
            lblRisultato.Location = new Point(93, 215);
            lblRisultato.Name = "lblRisultato";
            lblRisultato.Size = new Size(0, 15);
            lblRisultato.TabIndex = 4;
            // 
            // Finestra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(lblRisultato);
            Controls.Add(lblTesto);
            Controls.Add(btnInvia);
            Controls.Add(txtTesto);
            Controls.Add(lblTitolo);
            Name = "Finestra";
            Text = "Finestra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private TextBox txtTesto;
        private Button btnInvia;
        private Label lblTesto;
        private Label lblRisultato;
    }
}
