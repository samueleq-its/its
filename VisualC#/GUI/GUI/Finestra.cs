namespace GUI
{
    public partial class Finestra : Form
    {
        public Finestra()
        {
            InitializeComponent();
        }

        private void btnInvia_Click(object sender, EventArgs e)
        {
            string testo = txtTesto.Text;
            lblRisultato.Text = $"hai inserito il seguente testo: {testo}";
        }
    }
}
