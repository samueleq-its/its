namespace GUICalcolatrice
{
    partial class Form1
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
            lblN1 = new Label();
            txtN1 = new TextBox();
            txtN2 = new TextBox();
            lblN2 = new Label();
            txtRisultato = new TextBox();
            btnSomma = new Button();
            btnSottrazione = new Button();
            btnMult = new Button();
            btnPerc = new Button();
            btnDiv = new Button();
            btnCanc = new Button();
            SuspendLayout();
            // 
            // lblTitolo
            // 
            lblTitolo.AutoSize = true;
            lblTitolo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitolo.Location = new Point(127, 9);
            lblTitolo.Name = "lblTitolo";
            lblTitolo.Size = new Size(114, 25);
            lblTitolo.TabIndex = 0;
            lblTitolo.Text = "Calcolatrice";
            // 
            // lblN1
            // 
            lblN1.AutoSize = true;
            lblN1.Location = new Point(47, 111);
            lblN1.Name = "lblN1";
            lblN1.Size = new Size(22, 15);
            lblN1.TabIndex = 1;
            lblN1.Text = "N1";
            // 
            // txtN1
            // 
            txtN1.Location = new Point(84, 108);
            txtN1.Name = "txtN1";
            txtN1.Size = new Size(87, 23);
            txtN1.TabIndex = 2;
            // 
            // txtN2
            // 
            txtN2.Location = new Point(84, 137);
            txtN2.Name = "txtN2";
            txtN2.Size = new Size(87, 23);
            txtN2.TabIndex = 4;
            // 
            // lblN2
            // 
            lblN2.AutoSize = true;
            lblN2.Location = new Point(47, 140);
            lblN2.Name = "lblN2";
            lblN2.Size = new Size(22, 15);
            lblN2.TabIndex = 3;
            lblN2.Text = "N2";
            // 
            // txtRisultato
            // 
            txtRisultato.BackColor = SystemColors.Window;
            txtRisultato.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtRisultato.Location = new Point(36, 47);
            txtRisultato.Name = "txtRisultato";
            txtRisultato.ReadOnly = true;
            txtRisultato.Size = new Size(300, 29);
            txtRisultato.TabIndex = 5;
            txtRisultato.TextAlign = HorizontalAlignment.Right;
            // 
            // btnSomma
            // 
            btnSomma.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSomma.Location = new Point(202, 108);
            btnSomma.Name = "btnSomma";
            btnSomma.Size = new Size(25, 25);
            btnSomma.TabIndex = 6;
            btnSomma.Text = "+";
            btnSomma.UseVisualStyleBackColor = true;
            btnSomma.Click += btnSomma_Click;
            // 
            // btnSottrazione
            // 
            btnSottrazione.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSottrazione.Location = new Point(242, 108);
            btnSottrazione.Name = "btnSottrazione";
            btnSottrazione.Size = new Size(25, 25);
            btnSottrazione.TabIndex = 7;
            btnSottrazione.Text = "-";
            btnSottrazione.UseVisualStyleBackColor = true;
            btnSottrazione.Click += btnSottrazione_Click;
            // 
            // btnMult
            // 
            btnMult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMult.Location = new Point(202, 141);
            btnMult.Name = "btnMult";
            btnMult.Size = new Size(25, 25);
            btnMult.TabIndex = 8;
            btnMult.Text = "*";
            btnMult.UseVisualStyleBackColor = true;
            btnMult.Click += btnMult_Click;
            // 
            // btnPerc
            // 
            btnPerc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPerc.Location = new Point(202, 170);
            btnPerc.Name = "btnPerc";
            btnPerc.Size = new Size(25, 25);
            btnPerc.TabIndex = 9;
            btnPerc.Text = "%";
            btnPerc.UseVisualStyleBackColor = true;
            btnPerc.Click += btnPerc_Click;
            // 
            // btnDiv
            // 
            btnDiv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDiv.Location = new Point(242, 139);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(25, 25);
            btnDiv.TabIndex = 10;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = true;
            btnDiv.Click += btnDiv_Click;
            // 
            // btnCanc
            // 
            btnCanc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCanc.Location = new Point(242, 170);
            btnCanc.Name = "btnCanc";
            btnCanc.Size = new Size(25, 25);
            btnCanc.TabIndex = 11;
            btnCanc.Text = "C";
            btnCanc.UseVisualStyleBackColor = true;
            btnCanc.Click += btnCanc_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 461);
            Controls.Add(btnCanc);
            Controls.Add(btnDiv);
            Controls.Add(btnPerc);
            Controls.Add(btnMult);
            Controls.Add(btnSottrazione);
            Controls.Add(btnSomma);
            Controls.Add(txtRisultato);
            Controls.Add(txtN2);
            Controls.Add(lblN2);
            Controls.Add(txtN1);
            Controls.Add(lblN1);
            Controls.Add(lblTitolo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitolo;
        private Label lblN1;
        private TextBox txtN1;
        private TextBox txtN2;
        private Label lblN2;
        private TextBox txtRisultato;
        private Button btnSomma;
        private Button btnSottrazione;
        private Button btnMult;
        private Button btnPerc;
        private Button btnDiv;
        private Button btnCanc;
    }
}
