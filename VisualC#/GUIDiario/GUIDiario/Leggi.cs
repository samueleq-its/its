namespace GUIDiario
{
    public partial class Leggi : Form
    {
        public Leggi()
        {
            InitializeComponent();
            txtCommenti.TabStop = false;
            Lib.Inst.ElencoCommenti.ForEach(c =>
            {
                txtCommenti.Text += c + "\r\n";
            }
            );
        }
    }
}
