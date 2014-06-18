using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SelectGoodNumber
{
    public partial class NewItemForm : Form
    {
        private SettingForm _settingForm;
        public NewItemForm()
        {
            InitializeComponent();
        }

        public NewItemForm(SettingForm settingForm):
            this()
        {
            _settingForm = settingForm;
        }

        public void ClearText()
        {
            this.textBox_NumberFeature.Clear();
            this.textBox_RegularExpression.Clear();
            if(comboBox_NumberLevel.Text == String.Empty)
                this.textBox_Priority.Clear();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_NumberLevel.Text.Trim() == String.Empty)
            {
                MessageBox.Show("号码等级不允许为空！");
                return;
            }
            if (textBox_NumberFeature.Text.Trim() == String.Empty)
            {
                MessageBox.Show("号码特征不允许为空！");
                return;
            }
            if (textBox_RegularExpression.Text.Trim() == String.Empty)
            {
                MessageBox.Show("正则表达式不允许为空！");
                return;
            }
            if(textBox_Priority.Text.Trim() == String.Empty)
            {
                MessageBox.Show("优先级不允许为空！");
                return;
            }
            if(_settingForm.Numbers.FindIndex((it) => (it.Feature == textBox_NumberFeature.Text && it.Feature != "吉祥号码")) >= 0)
            {
                MessageBox.Show("此特征已存在，不允许出现相同的特征！");
                return;
            }

            if (!_settingForm.NumberLevelsComboBox.Items.Contains(comboBox_NumberLevel.Text.Trim()))
                _settingForm.NumberLevelsComboBox.Items.Add(comboBox_NumberLevel.Text.Trim());

            NumberItem item = new NumberItem(comboBox_NumberLevel.Text.Trim(), textBox_NumberFeature.Text.Trim(), textBox_RegularExpression.Text, Int32.Parse(textBox_Priority.Text.Trim()));
            _settingForm.Numbers.Add(item);
            _settingForm.NumberLevelsComboBox.Text = comboBox_NumberLevel.Text.Trim();
            _settingForm.UpdateUI(false);
            if (!comboBox_NumberLevel.Items.Contains(item.Level))
                comboBox_NumberLevel.Items.Add(item.Level);

            //textBox_Priority.Enabled = true;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            ClearText();
            //textBox_Priority.Enabled = true;
            this.Close();
        }

        private void NewItemForm_Load(object sender, EventArgs e)
        {
            foreach(var item in _settingForm.Numbers)
            {
                if(!comboBox_NumberLevel.Items.Contains(item.Level))
                    comboBox_NumberLevel.Items.Add(item.Level);
            }
        }

        private void textBox_Priority_Leave(object sender, EventArgs e)
        {
            int value = -1;
            bool canParse = Int32.TryParse(textBox_Priority.Text, out value);
            if ((textBox_Priority.Text != String.Empty && !canParse) || (canParse && (value < 0 || value > 100)))
            {
                MessageBox.Show("优先级只能输入数字0-100！");
                textBox_Priority.Text = String.Empty;
                return;
            }
        }

        private void comboBox_NumberLevel_TextChanged(object sender, EventArgs e)
        {
            string currentText = comboBox_NumberLevel.Text.Trim();
            int index = _settingForm.Numbers.FindIndex((it) => it.Level == currentText);
            if (index < 0)
            {
                textBox_Priority.Enabled = true;
                return;
            }

            textBox_Priority.Text = _settingForm.Numbers[index].Priority.ToString();
            textBox_Priority.Enabled = false;
        }
    }
}
