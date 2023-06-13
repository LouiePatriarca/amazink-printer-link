using System;
using System.Windows.Forms;

namespace Printer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineSettings line = new LineSettings();
            line.ShowDialog();
        }
    }
}
