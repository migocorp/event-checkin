namespace Com.Migocorp.BJRD.Event.CheckIn
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnSurvey = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.labMsg = new System.Windows.Forms.Label();
            this.labShowCode = new System.Windows.Forms.Label();
            this.labShowCompany = new System.Windows.Forms.Label();
            this.labShowName = new System.Windows.Forms.Label();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioNotCheckedIn = new System.Windows.Forms.RadioButton();
            this.radioCheckedIn = new System.Windows.Forms.RadioButton();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblSearchWord = new System.Windows.Forms.Label();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.panelMain.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.btnCheckIn);
            this.panelMain.Controls.Add(this.btnSurvey);
            this.panelMain.Controls.Add(this.btnPrint);
            this.panelMain.Controls.Add(this.panelPreview);
            this.panelMain.Controls.Add(this.panelQuery);
            this.panelMain.Controls.Add(this.dgvList);
            this.panelMain.Location = new System.Drawing.Point(3, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1280, 650);
            this.panelMain.TabIndex = 18;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckIn.Location = new System.Drawing.Point(105, 430);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(120, 40);
            this.btnCheckIn.TabIndex = 42;
            this.btnCheckIn.Text = "确认签到";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnSurvey
            // 
            this.btnSurvey.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSurvey.Location = new System.Drawing.Point(35, 430);
            this.btnSurvey.Name = "btnSurvey";
            this.btnSurvey.Size = new System.Drawing.Size(120, 40);
            this.btnSurvey.TabIndex = 44;
            this.btnSurvey.Text = "交回问卷";
            this.btnSurvey.UseVisualStyleBackColor = true;
            this.btnSurvey.Visible = false;
            this.btnSurvey.Click += new System.EventHandler(this.btnSurvey_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(263, 437);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 33);
            this.btnPrint.TabIndex = 43;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // panelPreview
            // 
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Controls.Add(this.labMsg);
            this.panelPreview.Controls.Add(this.labShowCode);
            this.panelPreview.Controls.Add(this.labShowCompany);
            this.panelPreview.Controls.Add(this.labShowName);
            this.panelPreview.Location = new System.Drawing.Point(9, 206);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(320, 200);
            this.panelPreview.TabIndex = 39;
            // 
            // labMsg
            // 
            this.labMsg.AllowDrop = true;
            this.labMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labMsg.AutoSize = true;
            this.labMsg.BackColor = System.Drawing.Color.Transparent;
            this.labMsg.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.ForeColor = System.Drawing.Color.DimGray;
            this.labMsg.Location = new System.Drawing.Point(30, 20);
            this.labMsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(98, 14);
            this.labMsg.TabIndex = 32;
            this.labMsg.Text = "Label Message";
            // 
            // labShowCode
            // 
            this.labShowCode.AutoSize = true;
            this.labShowCode.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labShowCode.Location = new System.Drawing.Point(28, 47);
            this.labShowCode.Name = "labShowCode";
            this.labShowCode.Size = new System.Drawing.Size(90, 26);
            this.labShowCode.TabIndex = 5;
            this.labShowCode.Text = "XXXXXX";
            this.labShowCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labShowCompany
            // 
            this.labShowCompany.AutoSize = true;
            this.labShowCompany.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labShowCompany.Location = new System.Drawing.Point(30, 122);
            this.labShowCompany.Name = "labShowCompany";
            this.labShowCompany.Size = new System.Drawing.Size(128, 17);
            this.labShowCompany.TabIndex = 4;
            this.labShowCompany.Text = "XXXXXXXXXXXXXXX";
            this.labShowCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labShowName
            // 
            this.labShowName.AutoSize = true;
            this.labShowName.Font = new System.Drawing.Font("Microsoft YaHei", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labShowName.Location = new System.Drawing.Point(28, 87);
            this.labShowName.Name = "labShowName";
            this.labShowName.Size = new System.Drawing.Size(48, 25);
            this.labShowName.TabIndex = 3;
            this.labShowName.Text = "XXX";
            this.labShowName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelQuery
            // 
            this.panelQuery.Controls.Add(this.radioAll);
            this.panelQuery.Controls.Add(this.radioNotCheckedIn);
            this.panelQuery.Controls.Add(this.radioCheckedIn);
            this.panelQuery.Controls.Add(this.btnQuery);
            this.panelQuery.Controls.Add(this.lblSearchWord);
            this.panelQuery.Controls.Add(this.txtSearchWord);
            this.panelQuery.Location = new System.Drawing.Point(8, 15);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Size = new System.Drawing.Size(320, 170);
            this.panelQuery.TabIndex = 38;
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioAll.Location = new System.Drawing.Point(27, 71);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(60, 26);
            this.radioAll.TabIndex = 42;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "全部";
            this.radioAll.UseVisualStyleBackColor = true;
            // 
            // radioNotCheckedIn
            // 
            this.radioNotCheckedIn.AutoSize = true;
            this.radioNotCheckedIn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioNotCheckedIn.Location = new System.Drawing.Point(119, 71);
            this.radioNotCheckedIn.Name = "radioNotCheckedIn";
            this.radioNotCheckedIn.Size = new System.Drawing.Size(76, 26);
            this.radioNotCheckedIn.TabIndex = 40;
            this.radioNotCheckedIn.TabStop = true;
            this.radioNotCheckedIn.Text = "未签到";
            this.radioNotCheckedIn.UseVisualStyleBackColor = true;
            // 
            // radioCheckedIn
            // 
            this.radioCheckedIn.AutoSize = true;
            this.radioCheckedIn.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioCheckedIn.Location = new System.Drawing.Point(221, 71);
            this.radioCheckedIn.Name = "radioCheckedIn";
            this.radioCheckedIn.Size = new System.Drawing.Size(76, 26);
            this.radioCheckedIn.TabIndex = 38;
            this.radioCheckedIn.TabStop = true;
            this.radioCheckedIn.Text = "已签到";
            this.radioCheckedIn.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.Color.Black;
            this.btnQuery.Location = new System.Drawing.Point(97, 115);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(105, 40);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblSearchWord
            // 
            this.lblSearchWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSearchWord.AutoSize = true;
            this.lblSearchWord.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchWord.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSearchWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSearchWord.Location = new System.Drawing.Point(23, 29);
            this.lblSearchWord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchWord.Name = "lblSearchWord";
            this.lblSearchWord.Size = new System.Drawing.Size(90, 22);
            this.lblSearchWord.TabIndex = 21;
            this.lblSearchWord.Text = "查询条件：";
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.AllowDrop = true;
            this.txtSearchWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearchWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtSearchWord.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearchWord.Location = new System.Drawing.Point(120, 26);
            this.txtSearchWord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(177, 29);
            this.txtSearchWord.TabIndex = 4;
            this.txtSearchWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchWord_KeyDown);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvList.Location = new System.Drawing.Point(348, 15);
            this.dgvList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvList.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.dgvList.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvList.RowTemplate.Height = 30;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(910, 600);
            this.dgvList.TabIndex = 36;
            this.dgvList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContent_RowEnter);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1016, 653);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check_In";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.Form_Resize);
            this.panelMain.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            this.panelQuery.ResumeLayout(false);
            this.panelQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Label lblSearchWord;
        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panelQuery;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.RadioButton radioNotCheckedIn;
        private System.Windows.Forms.RadioButton radioCheckedIn;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label labShowCode;
        private System.Windows.Forms.Label labShowCompany;
        private System.Windows.Forms.Label labShowName;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnSurvey;

    }
}