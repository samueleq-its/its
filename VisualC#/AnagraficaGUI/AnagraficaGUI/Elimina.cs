namespace AnagraficaGUI
{
    public partial class Elimina : Form
    {
        public Elimina()
        {
            InitializeComponent();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                $"Conferma Eliminare studente?",
                "Eliminare?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                try
                {
                    var dal = new StudentiDAL();
                    dal.Elimina(Convert.ToInt32(txtElimina.Text));
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}",
                        "Errore",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void Reset()
        {
            txtElimina.Text = string.Empty;
        }
    }
}
