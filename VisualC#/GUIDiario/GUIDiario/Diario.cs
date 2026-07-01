namespace GUIDiario
{
    public partial class Diario : Form
    {
        public Diario()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //TODO: non si apre se già aperto
            Nuovo nuovoCommento = new Nuovo();
            nuovoCommento.Show();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //TODO: non si apre se già aperto
            Leggi leggiCommenti = new Leggi();
            leggiCommenti.Show();
        }
    }
}
