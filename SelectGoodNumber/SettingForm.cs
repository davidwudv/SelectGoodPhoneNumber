using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace SelectGoodNumber
{
    public partial class SettingForm : Form
    {
        private NewItemForm _newItemForm;
        private List<NumberItem> _numbers;
        private string _oldValue = String.Empty;//存储单元格旧值

        public ComboBox NumberLevelsComboBox
        {
            get { return comboBox_NumberLevel; }
        }

        public List<NumberItem> Numbers
        {
            get { return _numbers; }
            set
            {
                _numbers = value;
                UpdateUI();
            }
        }

        public SettingForm()
        {
            InitializeComponent();

            _numbers = new List<NumberItem>();
            LoadConfigFile(@".\regularConfig.xml");
            //if (comboBox_NumberLevel.Items.Count > 0)
            //    comboBox_NumberLevel.SelectedIndex = 0;
        }

        private void button_AddNewNumberLevel_Click(object sender, EventArgs e)
        {
            if (_newItemForm == null)
            {
                _newItemForm = new NewItemForm(this);
                _newItemForm.Disposed += this.OnNewItemFormDisposed;
            }

            _newItemForm.ClearText();
            _newItemForm.ShowDialog();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将会删除此号码等级下的所有特征、正则表达式、优先级信息，确定要继续吗？", "警告", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            string selectedNumberLevel = (string)comboBox_NumberLevel.SelectedItem;
            int index = _numbers.FindIndex((item) => item.Level == selectedNumberLevel);
            if (index >= 0)
            {
                _numbers.RemoveAt(index);
                if (comboBox_NumberLevel.Items.Count > 0)
                {
                    comboBox_NumberLevel.Items.Remove(selectedNumberLevel);
                    comboBox_NumberLevel.SelectedIndex = 0;
                }
                else
                    UpdateUI();
            }
        }

        private void OnNewItemFormDisposed(object sender, EventArgs e)
        {
            _newItemForm = null;
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile(@".\regularConfig.xml");
        }

        private void SaveToFile(string filePath)
        {
            XmlWriter writer = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<NumberItem>));
                FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                writer = new XmlTextWriter(stream, Encoding.Unicode);
                serializer.Serialize(writer, Numbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void LoadConfigFile(string filePath)
        {
            FileStream stream = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<NumberItem>));
                stream = new FileStream(filePath, FileMode.Open);
                XmlReader reader = XmlReader.Create(stream);
                Numbers = (List<NumberItem>)serializer.Deserialize(reader);
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public void UpdateUI(bool updateNumberLevel = true, bool updateDataGridView = true)
        {
            if (updateNumberLevel)
            {
                comboBox_NumberLevel.Items.Clear();
                foreach (var item in _numbers)
                {
                    if(!comboBox_NumberLevel.Items.Contains(item.Level))
                        comboBox_NumberLevel.Items.Add(item.Level);
                }
                if (comboBox_NumberLevel.Items.Count >= 0)
                    comboBox_NumberLevel.SelectedIndex = 0;
            }

            if (updateDataGridView && comboBox_NumberLevel.Text != String.Empty)
            {
                string currentNumberLevel = comboBox_NumberLevel.Text;
                var items = _numbers.FindAll((item) => item.Level == currentNumberLevel);
                if (items.Count > 0)
                {
                    dataGridView_CurrentNumberLevelInfo.Rows.Clear();

                    foreach (var item in items)
                    {
                        dataGridView_CurrentNumberLevelInfo.Rows.Add(item.Feature, item.RegularExpression, item.Priority);
                    }
                }
            }
        }

        private void comboBox_NumberLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI(false);
        }

        private void dataGridView_CurrentNumberLevelInfo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView_CurrentNumberLevelInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                _oldValue = dataGridView_CurrentNumberLevelInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void dataGridView_CurrentNumberLevelInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object obj = dataGridView_CurrentNumberLevelInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (obj == null)
            {
                MessageBox.Show("不允许输入空值");
                dataGridView_CurrentNumberLevelInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _oldValue;
                return;
            }
            string newValue = obj.ToString();
            if (_oldValue == newValue)
                return;

            int changedItem;
            if (e.ColumnIndex == 0)//特征被更改
            {
                if(_numbers.FindIndex((item) => item.Feature == newValue) >= 0)
                {
                    MessageBox.Show("不允许出现相同的特征！");
                    return;
                }
                changedItem = _numbers.FindIndex((item) => item.Feature == _oldValue);
                if (changedItem >= 0)
                    _numbers[changedItem].Feature = newValue;
            }
            else if (e.ColumnIndex == 1)//正则表达被更改
            {
                changedItem = _numbers.FindIndex((item) => item.RegularExpression == _oldValue);
                if (changedItem >= 0)
                    _numbers[changedItem].RegularExpression = newValue;
            }
            else if(e.ColumnIndex == 2)//优先级被修改
            {
                string level = comboBox_NumberLevel.Text;
                foreach(var item in _numbers)
                {
                    if (item.Level == level)
                        item.Priority = Convert.ToInt32(newValue);
                }

                for (int i = 0; i < dataGridView_CurrentNumberLevelInfo.Rows.Count; ++i)
                {
                    dataGridView_CurrentNumberLevelInfo.Rows[i].Cells[2].Value = newValue;
                }
            }
        }

        private void dataGridView_CurrentNumberLevelInfo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                dataGridView_CurrentNumberLevelInfo.ClearSelection();
                dataGridView_CurrentNumberLevelInfo.Rows[e.RowIndex].Selected = true;
                dataGridView_CurrentNumberLevelInfo.CurrentCell = dataGridView_CurrentNumberLevelInfo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void DeleteCurrentRow_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentRow = dataGridView_CurrentNumberLevelInfo.CurrentRow;
            string level = comboBox_NumberLevel.Text;
            string featrue = currentRow.Cells[0].Value.ToString();
            string regularExpression = currentRow.Cells[1].Value.ToString();
            int priority = (int)currentRow.Cells[2].Value;
            int index = _numbers.FindIndex((it) => (it.Feature == featrue && it.Level == level && it.RegularExpression == regularExpression && it.Priority == priority));

            if(index >= 0)
                _numbers.RemoveAt(index);
            dataGridView_CurrentNumberLevelInfo.Rows.Remove(currentRow);
        }
    }
}
