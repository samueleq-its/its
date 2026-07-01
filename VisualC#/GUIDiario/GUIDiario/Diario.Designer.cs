namespace GUIDiario
{
    partial class Diario
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
            btnNew = new Button();
            btnRead = new Button();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitolo.ForeColor = Color.White;
            lblTitolo.Location = new Point(255, 9);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(84, 32);
            lblTitolo.TabIndex = 0;
            lblTitolo.Text = "Diario";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(73, 111);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(200, 50);
            btnNew.TabIndex = 1;
            btnNew.Text = "Nuovo Commento";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(331, 111);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(200, 50);
            btnRead.TabIndex = 2;
            btnRead.Text = "Leggi Commenti";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // Diario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Fuchsia;
            ClientSize = new Size(584, 261);
            Controls.Add(btnRead);
            Controls.Add(btnNew);
            Controls.Add(lblTitolo);
            Name = "Diario";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private Button btnNew;
        private Button btnRead;
    }
}
