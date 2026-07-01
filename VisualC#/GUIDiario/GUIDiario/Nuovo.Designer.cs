namespace GUIDiario
{
    partial class Nuovo
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
            lblTitle = new Label();
            txtCommento = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(187, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(358, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inserisci un nuovo Commento";
            // 
            // txtCommento
            // 
            txtCommento.Location = new Point(81, 167);
            txtCommento.Name = "txtCommento";
            txtCommento.Size = new Size(613, 23);
            txtCommento.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(341, 254);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Salva";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Nuovo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(txtCommento);
            Controls.Add(lblTitle);
            Name = "Nuovo";
            Text = "Nuovo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtCommento;
        private Button btnSave;
    }
}