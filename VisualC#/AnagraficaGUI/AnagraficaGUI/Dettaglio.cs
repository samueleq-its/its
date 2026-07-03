namespace AnagraficaGUI
{
    public partial class Dettaglio : Form
    {
        public Dettaglio()
        {
            InitializeComponent();
        }

        private void btnCerca_Click(object sender, EventArgs e)
        {
            Reset();

            try
            {
                int matricola = Convert.ToInt32(txtCerca.Text);

                var dal = new StudentiDAL();
                Studente studente = dal.Dettaglio(matricola);
                if (studente == null)
                {
                    MessageBox.Show($"lo studente con matricola {matricola} non è presente",
                        "Cerca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
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

        private void Reset()
        {
            txtMatricola.Text = string.Empty;
            txtNome.Text =string.Empty;
            txtCognome.Text =string.Empty;
            txtEmail.Text =string.Empty;
            txtClasse.Text =string.Empty;
        }
    }
}
