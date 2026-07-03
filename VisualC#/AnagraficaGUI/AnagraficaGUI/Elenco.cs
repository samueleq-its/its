namespace AnagraficaGUI
{
    public partial class Elenco : Form
    {
        private StudentiDAL dal;
        public Elenco()
        {
            InitializeComponent();

            dal = new StudentiDAL();

            List<Studente> studenti = dal.Elenco();
            lblItemsTrovati.Text = $"Numero studenti trovati: {studenti.Count}";
            txtElenco.Text = String.Join("\n\r", studenti);


        }
    }
}
