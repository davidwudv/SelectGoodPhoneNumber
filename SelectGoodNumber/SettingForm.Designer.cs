namespace SelectGoodNumber
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_NumberLevel = new System.Windows.Forms.Label();
            this.comboBox_NumberLevel = new System.Windows.Forms.ComboBox();
            this.dataGridView_CurrentNumberLevelInfo = new System.Windows.Forms.DataGridView();
            this.button_AddNewNumberLevel = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteCurrentRow_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegularExpressionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeatureColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CurrentNumberLevelInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_NumberLevel
            // 
            this.label_NumberLevel.AutoSize = true;
            this.label_NumberLevel.Location = new System.Drawing.Point(12, 15);
            this.label_NumberLevel.Name = "label_NumberLevel";
            this.label_NumberLevel.Size = new System.Drawing.Size(41, 12);
            this.label_NumberLevel.TabIndex = 0;
            this.label_NumberLevel.Text = "等级：";
            // 
            // comboBox_NumberLevel
            // 
            this.comboBox_NumberLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NumberLevel.FormattingEnabled = true;
            this.comboBox_NumberLevel.Location = new System.Drawing.Point(50, 12);
            this.comboBox_NumberLevel.Name = "comboBox_NumberLevel";
            this.comboBox_NumberLevel.Size = new System.Drawing.Size(205, 20);
            this.comboBox_NumberLevel.Sorted = true;
            this.comboBox_NumberLevel.TabIndex = 1;
            this.comboBox_NumberLevel.SelectedIndexChanged += new System.EventHandler(this.comboBox_NumberLevel_SelectedIndexChanged);
            // 
            // dataGridView_CurrentNumberLevelInfo
            // 
            this.dataGridView_CurrentNumberLevelInfo.AllowUserToAddRows = false;
            this.dataGridView_CurrentNumberLevelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_CurrentNumberLevelInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_CurrentNumberLevelInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_CurrentNumberLevelInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CurrentNumberLevelInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeatureColumn,
            this.RegularExpressionColumn,
            this.ColumnPriority});
            this.dataGridView_CurrentNumberLevelInfo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView_CurrentNumberLevelInfo.Location = new System.Drawing.Point(13, 43);
            this.dataGridView_CurrentNumberLevelInfo.Name = "dataGridView_CurrentNumberLevelInfo";
            this.dataGridView_CurrentNumberLevelInfo.RowTemplate.Height = 23;
            this.dataGridView_CurrentNumberLevelInfo.Size = new System.Drawing.Size(413, 166);
            this.dataGridView_CurrentNumberLevelInfo.TabIndex = 5;
            this.dataGridView_CurrentNumberLevelInfo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CurrentNumberLevelInfo_CellBeginEdit);
            this.dataGridView_CurrentNumberLevelInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CurrentNumberLevelInfo_CellEndEdit);
            this.dataGridView_CurrentNumberLevelInfo.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CurrentNumberLevelInfo_CellMouseUp);
            // 
            // button_AddNewNumberLevel
            // 
            this.button_AddNewNumberLevel.Location = new System.Drawing.Point(270, 10);
            this.button_AddNewNumberLevel.Name = "button_AddNewNumberLevel";
            this.button_AddNewNumberLevel.Size = new System.Drawing.Size(75, 23);
            this.button_AddNewNumberLevel.TabIndex = 4;
            this.button_AddNewNumberLevel.Text = "新建";
            this.button_AddNewNumberLevel.UseVisualStyleBackColor = true;
            this.button_AddNewNumberLevel.Click += new System.EventHandler(this.button_AddNewNumberLevel_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(351, 10);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 6;
            this.button_Delete.Text = "删除此等级";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteCurrentRow_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // DeleteCurrentRow_ToolStripMenuItem
            // 
            this.DeleteCurrentRow_ToolStripMenuItem.Name = "DeleteCurrentRow_ToolStripMenuItem";
            this.DeleteCurrentRow_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.DeleteCurrentRow_ToolStripMenuItem.Text = "删除此行";
            this.DeleteCurrentRow_ToolStripMenuItem.Click += new System.EventHandler(this.DeleteCurrentRow_ToolStripMenuItem_Click);
            // 
            // ColumnPriority
            // 
            this.ColumnPriority.HeaderText = "优先级";
            this.ColumnPriority.Name = "ColumnPriority";
            this.ColumnPriority.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RegularExpressionColumn
            // 
            this.RegularExpressionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RegularExpressionColumn.HeaderText = "正则表达式";
            this.RegularExpressionColumn.Name = "RegularExpressionColumn";
            // 
            // FeatureColumn
            // 
            this.FeatureColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeatureColumn.HeaderText = "特征";
            this.FeatureColumn.Name = "FeatureColumn";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 221);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.dataGridView_CurrentNumberLevelInfo);
            this.Controls.Add(this.button_AddNewNumberLevel);
            this.Controls.Add(this.comboBox_NumberLevel);
            this.Controls.Add(this.label_NumberLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CurrentNumberLevelInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_NumberLevel;
        private System.Windows.Forms.ComboBox comboBox_NumberLevel;
        private System.Windows.Forms.DataGridView dataGridView_CurrentNumberLevelInfo;
        private System.Windows.Forms.Button button_AddNewNumberLevel;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteCurrentRow_ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeatureColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegularExpressionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriority;
    }
}