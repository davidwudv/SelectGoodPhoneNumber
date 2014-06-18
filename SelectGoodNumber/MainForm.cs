using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace SelectGoodNumber
{
    public partial class MainForm : Form
    {
        private SettingForm _settingForm;
        private string _currentFile;//当前导入的文件

        private SettingForm CurrentSettingForm
        {
            get
            {
                if(_settingForm == null)
                {
                    _settingForm = new SettingForm();
                    _settingForm.Disposed += this.OnSettingFormDisposed;
                }
                return _settingForm;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void OnSettingFormDisposed(object sender, EventArgs e)
        {
            _settingForm = null;
        }

        private void Setting_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentSettingForm.ShowDialog();
        }

        private void Import_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentSettingForm.Numbers.Count <= 0)
            {
                MessageBox.Show("尚未设置任何匹配规则！");
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel 97-2003 文档(*.xls)|*.xls|Excel 文档(*.xlsx)|*.xlsx";

            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadNumbersFormExcelFile(dialog.FileName);
                _currentFile = dialog.FileName;
            }
        }

        private void SaveAs_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainDataGridView.Rows.Count <= 0)
            {
                MessageBox.Show("没有导入任何数据。");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel 97-2003 文档(*.xls)|*.xls|Excel 文档(*.xlsx)|*.xlsx";
            
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveNumbersToExcelFile(dialog.FileName);
            }
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadNumbersFormExcelFile(string filepath)
        {
            System.IO.FileStream stream = null;
            try
            {
                string fileType = System.IO.Path.GetExtension(filepath);
                IWorkbook workbook = null;
                stream = new System.IO.FileStream(filepath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                if (fileType == ".xlsx")
                {
                    workbook = new XSSFWorkbook(stream);
                }
                else if (fileType == ".xls")
                {
                    workbook = new HSSFWorkbook(stream);
                }

                ISheet sheet = null;
                if (workbook.NumberOfSheets > 1)
                {
                    SelectSheetForm select = new SelectSheetForm();
                    for (int i = 0; i < workbook.NumberOfSheets; ++i)
                        select.SheetNames.Add(workbook.GetSheetName(i));
                    select.CurrentSelectedIndex = 0;
                    if (select.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        sheet = workbook.GetSheet(select.CurrentSelectedText);
                    select.Dispose();
                }
                else if (workbook.NumberOfSheets == 1)
                    sheet = workbook.GetSheetAt(0);
                if (sheet == null)
                    return;

                InitDataTable(sheet);
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("此文件被其他进程占用（或无权限读取），无法打开，如果你用Excel或其他程序打开了此文件，请先关闭！");
            }
            catch(Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message);
#else
                MessageBox.Show(ex.Message);
#endif
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private void SaveNumbersToExcelFile(string filepath)
        {
            System.IO.FileStream stream = null;
            try
            {
                string fileType = System.IO.Path.GetExtension(filepath);
                IWorkbook workbook = null;
                if (fileType == ".xlsx")
                {
                    workbook = new XSSFWorkbook();
                }
                else if (fileType == ".xls")
                {
                    workbook = new HSSFWorkbook();
                }

                ISheet sheet = workbook.CreateSheet("Sheet1");
                var firstExcelRow = sheet.CreateRow(0);
                int columnCount = 7;
                for (int i = 0; i < columnCount; ++i)
                {
                    firstExcelRow.CreateCell(i, CellType.String);
                }
                sheet.SetColumnWidth(0, 5500);
                sheet.SetColumnWidth(1, 3500);
                sheet.SetColumnWidth(2, 3500);
                sheet.SetColumnWidth(3, 6000);
                sheet.SetColumnWidth(4, 5500);
                sheet.SetColumnWidth(5, 3000);
                sheet.SetColumnWidth(6, 3000);
                firstExcelRow.Cells[0].SetCellValue("手机号码");
                firstExcelRow.Cells[1].SetCellValue("等级");
                firstExcelRow.Cells[2].SetCellValue("幸运数字");
                firstExcelRow.Cells[3].SetCellValue("号码特征");
                firstExcelRow.Cells[4].SetCellValue("号码基础价格(元)");
                firstExcelRow.Cells[5].SetCellValue("选号费(元)");
                firstExcelRow.Cells[6].SetCellValue("总价(元)");

                for(int i = 0; i < MainDataGridView.Rows.Count; ++i)
                {
                    var dataRow = MainDataGridView.Rows[i];
                    var excelRow = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dataRow.Cells.Count; ++j)
                    {
                        excelRow.CreateCell(j, CellType.String);
                        if (dataRow.Cells[j].Value != null && dataRow.Cells[j].Value.ToString() != String.Empty)
                            excelRow.Cells[j].SetCellValue(dataRow.Cells[j].Value.ToString());
                        else
                            excelRow.Cells[j].SetCellValue(String.Empty);
                    }
                }

                stream = new System.IO.FileStream(filepath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Read);
                workbook.Write(stream);
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("此文件被其他进程占用（或无权限读取），无法打开，如果你用Excel或其他程序打开了此文件，请先关闭！");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message);
#else
                MessageBox.Show(ex.Message);
#endif
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private void Save_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentFile == null || MainDataGridView.Rows.Count <= 0 || _currentFile == String.Empty)
            {
                MessageBox.Show("没有任何数据！");
                return;
            }

            if(MessageBox.Show("确认覆盖源文件？", "注意", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                SaveNumbersToExcelFile(_currentFile);
        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Version 1.1\n" +
                                    "Author: 吴德伟\n" +
                                    "Email: davidwudv@gmail.com\n" +
                                    "Copyright ©: 广东讯源通讯科技有限公司";
            MessageBox.Show(msg);
        }

        private void PrintHelp_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm.Instance().Show();
        }

        private void InitDataTable(ISheet sheet)
        {
            ProgressForm progress = new ProgressForm();
            progress.Start();
            MainDataGridView.Enabled = false;
            MainDataGridView.Columns.Clear();
            var firstRow = sheet.GetRow(0);//标题栏
            if (firstRow.Cells.Count < 2)
            {
                MessageBox.Show("文件内容不正确！");
                return;
            }
            MainDataGridView.Columns.Add("手机号码列", "手机号码");
            MainDataGridView.Columns.Add(new DataGridViewComboBoxColumn());
            MainDataGridView.Columns[1].Name = "等级";
            MainDataGridView.Columns[1].HeaderText = "等级";
            MainDataGridView.Columns.Add("幸运数字列", "幸运数字");
            MainDataGridView.Columns.Add("号码特征列", "号码特征");
            MainDataGridView.Columns.Add("号码基础价格(元)列", "号码基础价格(元)");
            MainDataGridView.Columns.Add("选号费(元)列", "选号费(元)");
            MainDataGridView.Columns.Add("总价列", "总价");

            //DataGridViewCell cell = new DataGridViewComboBoxCell();
            //MainDataGridView.Columns[1] = new DataGridViewComboBoxColumn();
            //MainDataGridView.Columns[1].CellTemplate = cell;

            for (int i = 1; i <= sheet.LastRowNum; ++i)
            {
                progress.SetProgress((int)((double)i / sheet.LastRowNum * 100));
                int rowIndex = MainDataGridView.Rows.Add(1);
                DataGridViewRow newRow = MainDataGridView.Rows[rowIndex];
                var cellsCount = sheet.GetRow(i).Cells.Count;
                string phoneNumber;
                var regularList = CurrentSettingForm.Numbers;
                NumberItem matchItem = new NumberItem();//最高优先级匹配的item
                List<string> features = new List<string>();
                if(cellsCount > 0)
                    phoneNumber = sheet.GetRow(i).Cells[0].ToString();
                else
                    phoneNumber = String.Empty;

                newRow.Cells[0].Value = phoneNumber;
                List<int> luckyNumbers = LuckyNumberRegular.Match(phoneNumber);
                foreach (var item in _settingForm.NumberLevelsComboBox.Items)
                    ((DataGridViewComboBoxCell)newRow.Cells[1]).Items.Add((string)item);
                ((DataGridViewComboBoxCell)newRow.Cells[1]).Items.Add("普通号码");

                foreach (var item in regularList)
                {
                    if (item.Feature == "吉祥号码")
                    {
                        string lucky = LuckyNumbersMatch(phoneNumber, item.RegularExpression);
                        if (lucky != null)
                        {
                            features.Add(item.Feature);
                            if (item.Priority > matchItem.Priority)
                                matchItem = item;
                        }
                    }
                    else
                    {
                        Regex regex = new Regex(@item.RegularExpression);

                        if (regex.IsMatch(phoneNumber))
                        {
                            features.Add(item.Feature);
                            if (item.Priority > matchItem.Priority)
                                matchItem = item;//查找最高优先级匹配的item
                        }
                    }
                }

                if (matchItem.Priority != -100)
                {
                    newRow.Cells[1].Value = matchItem.Level;
                    StringBuilder builder = new StringBuilder();
                    foreach (string it in features)
                    {
                        builder.Append(it);
                        builder.Append(",");
                    }
                    builder.Remove(builder.Length - 1, 1);
                    newRow.Cells[3].Value = builder.ToString();
                }
                else
                    newRow.Cells[1].Value = "普通号码";

                if (luckyNumbers.Count > 0)
                {
                    StringBuilder builder2 = new StringBuilder();
                    foreach(int it in luckyNumbers)
                    {
                        builder2.Append(it.ToString());
                        builder2.Append(",");
                    }
                    builder2.Remove(builder2.Length - 1, 1);
                    builder2.Append("比较多");
                    newRow.Cells[2].Value = builder2.ToString();
                }

            }

            //MainDataGridView.Sort(MainDataGridView.Columns[1], ListSortDirection.Descending);
            MainDataGridView.Enabled = true;
            progress.Stop();
        }

        /// <summary>
        /// 匹配吉祥号码（不同于幸运数字）
        /// </summary>
        /// <param name="phoneNumber">手机号码</param>
        /// <param name="luckyNumber">吉祥号码串，以逗号分隔</param>
        private string LuckyNumbersMatch(string phoneNumber , string luckyNumbers)
        {
            var luckyNumbersArray = luckyNumbers.Split(',');
            foreach (string item in luckyNumbersArray)
            {
                string pattern = @"(13[\d]|15[\d]|18[\d])\d" + "{" + (8 - item.Length).ToString() + "}" + item.ToString();
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(phoneNumber))
                    return item;
            }
            return null;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainDataGridView.Rows.Clear();
        }

    }
}
