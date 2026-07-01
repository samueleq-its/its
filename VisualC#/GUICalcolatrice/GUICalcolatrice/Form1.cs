namespace GUICalcolatrice
{
    public partial class Form1 : Form
    {

        private int n1, n2;

        public Form1()
        {
            InitializeComponent();
        }

        private void load()
        {
            try
            {
                n1 = Convert.ToInt32(txtN1.Text);
                n2 = Convert.ToInt32(txtN2.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    e.Message,
                    "Errore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }


        private void btnSomma_Click(object sender, EventArgs e)
        {
            load();
            txtRisultato.Text = (n1 + n2).ToString();
        }

        private void btnSottrazione_Click(object sender, EventArgs e)
        {
            load();
            txtRisultato.Text = (n1 - n2).ToString();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            load();
            txtRisultato.Text = (n1 * n2).ToString();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            load();
            if (n2 == 0)
            {
                MessageBox.Show("Impossibile dividere per zero", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtRisultato.Text = (n1 / (double)n2).ToString();
        }

        private void btnPerc_Click(object sender, EventArgs e)
        {
            load();
            txtRisultato.Text = (n1 / (double)n2 * 100).ToString();
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Eliminare tutti i dati?", "Cancella", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtRisultato.Text = String.Empty;
                txtN1.Text = String.Empty;
                txtN2.Text = String.Empty;
            }
        }
    }
}
