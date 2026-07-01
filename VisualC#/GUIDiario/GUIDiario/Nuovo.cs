using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUIDiario
{
    public partial class Nuovo : Form
    {
        public Nuovo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string commento = txtCommento.Text;

            if (commento == "")
            {
                return;
            }

            //Lib.Inst.ElencoCommenti.Add(commento);
            Lib.Inst.AggiungiCommento(commento);

            Close();

        }
    }
}
