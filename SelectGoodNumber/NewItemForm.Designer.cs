namespace SelectGoodNumber
{
    partial class NewItemForm
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
            this.textBox_RegularExpression = new System.Windows.Forms.TextBox();
            this.textBox_NumberFeature = new System.Windows.Forms.TextBox();
            this.label_RegularExpression = new System.Windows.Forms.Label();
            this.label_NumberFeature = new System.Windows.Forms.Label();
            this.label_NumberLevel = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.comboBox_NumberLevel = new System.Windows.Forms.ComboBox();
            this.label_Priority = new System.Windows.Forms.Label();
            this.textBox_Priority = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_RegularExpression
            // 
            this.textBox_RegularExpression.Location = new System.Drawing.Point(85, 103);
            this.textBox_RegularExpression.Name = "textBox_RegularExpression";
            this.textBox_RegularExpression.Size = new System.Drawing.Size(187, 21);
            this.textBox_RegularExpression.TabIndex = 4;
            // 
            // textBox_NumberFeature
            // 
            this.textBox_NumberFeature.Location = new System.Drawing.Point(85, 73);
            this.textBox_NumberFeature.Name = "textBox_NumberFeature";
            this.textBox_NumberFeature.Size = new System.Drawing.Size(187, 21);
            this.textBox_NumberFeature.TabIndex = 3;
            // 
            // label_RegularExpression
            // 
            this.label_RegularExpression.AutoSize = true;
            this.label_RegularExpression.Location = new System.Drawing.Point(11, 106);
            this.label_RegularExpression.Name = "label_RegularExpression";
            this.label_RegularExpression.Size = new System.Drawing.Size(77, 12);
            this.label_RegularExpression.TabIndex = 3;
            this.label_RegularExpression.Text = "正则表达式：";
            // 
            // label_NumberFeature
            // 
            this.label_NumberFeature.AutoSize = true;
            this.label_NumberFeature.Location = new System.Drawing.Point(11, 77);
            this.label_NumberFeature.Name = "label_NumberFeature";
            this.label_NumberFeature.Size = new System.Drawing.Size(41, 12);
            this.label_NumberFeature.TabIndex = 4;
            this.label_NumberFeature.Text = "特征：";
            // 
            // label_NumberLevel
            // 
            this.label_NumberLevel.AutoSize = true;
            this.label_NumberLevel.Location = new System.Drawing.Point(11, 15);
            this.label_NumberLevel.Name = "label_NumberLevel";
            this.label_NumberLevel.Size = new System.Drawing.Size(65, 12);
            this.label_NumberLevel.TabIndex = 7;
            this.label_NumberLevel.Text = "号码等级：";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(51, 141);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "确定";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(157, 141);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // comboBox_NumberLevel
            // 
            this.comboBox_NumberLevel.FormattingEnabled = true;
            this.comboBox_NumberLevel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.comboBox_NumberLevel.Location = new System.Drawing.Point(85, 13);
            this.comboBox_NumberLevel.Name = "comboBox_NumberLevel";
            this.comboBox_NumberLevel.Size = new System.Drawing.Size(187, 20);
            this.comboBox_NumberLevel.Sorted = true;
            this.comboBox_NumberLevel.TabIndex = 1;
            this.comboBox_NumberLevel.TextChanged += new System.EventHandler(this.comboBox_NumberLevel_TextChanged);
            // 
            // label_Priority
            // 
            this.label_Priority.AutoSize = true;
            this.label_Priority.Location = new System.Drawing.Point(11, 45);
            this.label_Priority.Name = "label_Priority";
            this.label_Priority.Size = new System.Drawing.Size(53, 12);
            this.label_Priority.TabIndex = 7;
            this.label_Priority.Text = "优先级：";
            // 
            // textBox_Priority
            // 
            this.textBox_Priority.Location = new System.Drawing.Point(85, 42);
            this.textBox_Priority.Name = "textBox_Priority";
            this.textBox_Priority.Size = new System.Drawing.Size(187, 21);
            this.textBox_Priority.TabIndex = 2;
            this.textBox_Priority.Leave += new System.EventHandler(this.textBox_Priority_Leave);
            // 
            // NewItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 176);
            this.Controls.Add(this.comboBox_NumberLevel);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_Priority);
            this.Controls.Add(this.label_NumberLevel);
            this.Controls.Add(this.textBox_RegularExpression);
            this.Controls.Add(this.textBox_Priority);
            this.Controls.Add(this.textBox_NumberFeature);
            this.Controls.Add(this.label_RegularExpression);
            this.Controls.Add(this.label_NumberFeature);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加新项";
            this.Load += new System.EventHandler(this.NewItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RegularExpression;
        private System.Windows.Forms.TextBox textBox_NumberFeature;
        private System.Windows.Forms.Label label_RegularExpression;
        private System.Windows.Forms.Label label_NumberFeature;
        private System.Windows.Forms.Label label_NumberLevel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox comboBox_NumberLevel;
        private System.Windows.Forms.Label label_Priority;
        private System.Windows.Forms.TextBox textBox_Priority;
    }
}