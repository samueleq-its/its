namespace AnagraficaGUI
{
    public partial class Nuovo : Form
    {
        public Nuovo()
        {
            InitializeComponent();
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            int matricola = Convert.ToInt32(txtMatricola.Text);
            var dal = new StudentiDAL();

            Studente? studente = null;

            studente = dal.Dettaglio(matricola);

            if (studente != null)
            {
                MessageBox.Show($"lo studente con matricola {matricola} è già presente",
                    "Nuovo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dal.Nuovo(new Studente()
            {
                Matricola = matricola,
                Nome = txtNome.Text,
                Cognome = txtCognome.Text,
                Email = txtEmail.Text,
                Classe = txtClasse.Text,
            });

            MessageBox.Show(
                $"Inserimento avvenuto con successo",
                "Nuovo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Reset();
        }

        private void btnCancella_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                $"Conferma cancellazione dati?",
                        "Cancellare?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Reset();
            }
        }

        private void Reset()
        {
            txtMatricola.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCognome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClasse.Text = string.Empty;
        }
    }
}
