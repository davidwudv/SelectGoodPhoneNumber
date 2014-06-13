using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectGoodNumber
{
    public partial class SelectSheetForm : Form
    {
        public string CurrentSelectedText
        {
            get { return comboBox_SheetList.Text; }
            set { comboBox_SheetList.Text = value; }
        }

        public ComboBox.ObjectCollection SheetNames
        {
            get { return comboBox_SheetList.Items; }
        }

        public int CurrentSelectedIndex
        {
            get { return comboBox_SheetList.SelectedIndex; }
            set { comboBox_SheetList.SelectedIndex = value; }
        }

        public SelectSheetForm()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
        }
    }
}
