using Printer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Printer
{
    public partial class LineForm : Form
    {
        private int? id;

        public LineForm()
        {
            InitializeComponent();
        }

        public LineForm(int? id, DataItem item)
        {
            InitializeComponent();
            this.id = id;
            TextLine.Text = item.Line;
            TextIP.Text = item.IPAddress;
            TextPort.Value = item.Port;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            LineCrud lineCrud = new LineCrud();
            if (id == null)
            {
                lineCrud.Create(TextLine.Text, TextIP.Text, (int)TextPort.Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DataItem dataItem = new DataItem { 
                    Line = TextLine.Text,
                    IPAddress = TextIP.Text,
                    Port = (int)TextPort.Value
                };
                lineCrud.Update(id, dataItem);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
