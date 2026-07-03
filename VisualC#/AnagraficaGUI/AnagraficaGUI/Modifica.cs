namespace AnagraficaGUI
{
    public partial class Modifica : Form
    {
        private int? matricola = null;

        public Modifica()
        {
            InitializeComponent();
        }
        private void btnCerca_Click(object sender, EventArgs e)
        {
            Reset();

            try
            {
                var dal = new StudentiDAL();
                Studente studente = dal.Dettaglio(Convert.ToInt32(txtCerca.Text));
                if (studente == null)
                {
                    MessageBox.Show($"lo studente con matricola {matricola} non è presente",
                        "Cerca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    matricola = studente.Matricola;

                    txtMatricola.Text = studente.Matricola.ToString();
                    txtNome.Text = studente.Nome.ToString();
                    txtCognome.Text = studente.Cognome.ToString();
                    txtEmail.Text = studente.Email.ToString();
                    txtClasse.Text = studente.Classe.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                        "Errore",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            
            if (matricola == null)
            {
                MessageBox.Show($"Prima cercare lo studente da modificare",
                        "Studente non caricato",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                return;
            }

            var dal = new StudentiDAL();

            dal.Modifica(new Studente()
            {
                Matricola = (int)matricola,
                Nome = txtNome.Text,
                Cognome = txtCognome.Text,
                Email = txtEmail.Text,
                Classe = txtClasse.Text,
            });

            MessageBox.Show(
                $"Modifica effettuata con successo",
                "Modifica",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
            matricola = null;
            txtMatricola.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCognome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClasse.Text = string.Empty;
        }
    }
}
