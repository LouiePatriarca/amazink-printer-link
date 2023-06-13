using Printer.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Printer
{
    public partial class LineSettings : Form
    {
        public LineSettings()
        {
            InitializeComponent();
            ReadData();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            LineForm lineForm = new LineForm();
            var result = lineForm.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                ReadData();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            LineForm lineForm = new LineForm(listView1.SelectedIndices[0]);
            lineForm.ShowDialog();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                LineCrud crud = new LineCrud();
                crud.Delete(listView1.SelectedIndices[0]);
                ReadData();
            }
        }

        public void ReadData() {
            // Assuming you have a ListView control named listView1 with the View property set to View.Details

            LineCrud crud = new LineCrud();

            List<DataItem> data = crud.Read();

            // Clear existing items and columns
            listView1.Items.Clear();
            listView1.Columns.Clear();

            // Define columns
            listView1.Columns.Add("Line", 150);
            listView1.Columns.Add("IP Address", 150);
            listView1.Columns.Add("Port", 100);

            // Populate items with data
            foreach (DataItem item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Line);
                listViewItem.SubItems.Add(item.IPAddress);
                listViewItem.SubItems.Add(item.Port.ToString());

                listView1.Items.Add(listViewItem);
            }
        }
    }
}
