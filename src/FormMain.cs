using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Migocorp.BJRD.Event.CheckIn.Util;
using Com.Migocorp.BJRD.Event.CheckIn.Dao;
using Common.Logging;

namespace Com.Migocorp.BJRD.Event.CheckIn
{
    public partial class FormMain : Form
    {
        private ILog log;
        private DaoAccess daoAccess;
        private bool guestSelected = false;
        private bool modeSurveyReturn = false;

        public FormMain()
        {
            log = Common.Logging.LogManager.GetLogger(this.GetType());
            daoAccess = new DaoAccess();
            modeSurveyReturn = KitConfig.GetKeyBool(KitConst.CONFIG_MODE_SURVEY_RETURN, false);
            InitializeComponent();
            InitialComponentsManual();
        }


        private void Form_Resize(object sender, System.EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            // this.panel1.Left = (this.Width - panel1.Width) / 2;
            this.panelMain.Left = 0;
            // this.panel1.Top = Convert.ToInt32(this.Height * 0.2);
        }


        private void Form_Load(object sender, EventArgs e)
        {
            //this.imgHead.Image = new Bitmap(DefaultImagePath);
        }
        
        //当前行改变
        private void dgvContent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetValueForCurrentUser(e.RowIndex);
        }

        private void InitialComponentsManual() {
            this.BackgroundImage = getBackgroundImage();
            this.setupDataGridColumns();

            DataTable dt = daoAccess.GetGuests(DaoAccess.FILTER_TYPE.FILTER_ALL, "");
            log.Debug("Count Rows :" + dt.Rows.Count);

            if (this.modeSurveyReturn)
            {
                btnCheckIn.Location = new Point(185, btnCheckIn.Location.Y);
                btnSurvey.Visible = true;
            }
            else
            {
                this.radioNotCheckedIn.Select();
            }

            this.ActiveControl = this.txtSearchWord;
            //this.txtSearchWord.Focus();
            //log.Debug("focused txtSearchWord-------");


        }



        private void setupDataGridColumns()
        {

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewCellStyle1.Padding = new Padding(0, 0, 0, 0);
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            makeDGVColumn("guest_id", "guest_id", "参会ID", 100),
            makeDGVColumn("time_checkin", "time_checkin", "签到时间", 90, "dd/MM HH:mm"),
            makeDGVColumn("name", "name", "姓名", 80),
            makeDGVColumn("email", "email", "Email", 170),
            makeDGVColumn("company", "company", "公司", 160),
            makeDGVColumn("job_title", "job_title", "职位", 70),
            makeDGVColumn("department", "department", "部门", 70),
            makeDGVColumn("phone", "phone", "phone", 100),
            //makeDGVColumn("weibo", "weibo", "微博账号", 100),
            makeDGVColumn("time_reg", "time_reg", "注册时间", 80, "dd/MM HH:mm")
            
            });
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn makeDGVColumn(string name, string dataPropertyName, string headerText, int width, string format) {
            System.Windows.Forms.DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = name;
            col.DataPropertyName = dataPropertyName;
            col.HeaderText = headerText;
            col.Width = width;
            col.ReadOnly = true;
            if (format != null && format.Length > 0)
            {
                col.DefaultCellStyle.Format = format;
            }
            return col;
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn makeDGVColumn(string name, string dataPropertyName, string headerText, int width) {
            return makeDGVColumn(name, dataPropertyName, headerText, width, "");
        }

        private Image getBackgroundImage()
        {
            Image bgImage = null;

            string path = KitConfig.GetKeyStr(KitConst.CONFIG_PATH_BACKGROUND_IMAGE, "");
            try
            {
                path = KitConfig.GetKeyStr(KitConst.CONFIG_PATH_BACKGROUND_IMAGE, "");
                bgImage = Image.FromFile(path);
                log.Info("Loaded background image :" + path);
            }
            catch (Exception ex)
            {
                log.Warn("Not found background image :" + path);
                log.Warn(ex.StackTrace);
                Image resultImage = new Bitmap(1, 1);
                using (Graphics grp = Graphics.FromImage(resultImage))
                {
                    grp.FillRectangle(Brushes.White, new Rectangle(0,0,1,1));
                }
            }

            return bgImage;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            log.Debug("btnQuery_Click");
            loadData();
        }

        private void loadData()
        {
            DaoAccess.FILTER_TYPE typeFilter = DaoAccess.FILTER_TYPE.FILTER_ALL;

            if (this.radioCheckedIn.Checked)
            {
                typeFilter = DaoAccess.FILTER_TYPE.FILTER_CHECKED_IN;
            }
            else if (this.radioNotCheckedIn.Checked)
            {
                typeFilter = DaoAccess.FILTER_TYPE.FILTER_NOT_CHECKED_IN;
            }

            string searchWord = this.txtSearchWord.Text.Trim();
            DataTable dtGuests = daoAccess.GetGuests(typeFilter, searchWord);
            this.dgvList.DataSource = dtGuests;
                        
            this.ResetCurrentUser();

            if (dtGuests.Rows.Count == 1)
            {
                this.SetValueForCurrentUser(0);
            }
            else if (dtGuests.Rows.Count == 0)
            {
                this.txtSearchWord.Focus();
            }
        }

        private void txtSearchWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log.Debug("Enter Pressed!!!");
                loadData();
            }
            else if (e.KeyCode == Keys.F12)
            {
                outputReportExcel();
            }
        }

        private void outputReportExcel()
        {

            string msg = "";
            FileInfo file = null;
            try
            {
                file = this.daoAccess.DoExportLogExcel();

                if (File.Exists(file.FullName))
                {
                    msg = String.Format("导出来宾系统信息完成，文件路径：\n\n{0}\n\n请将导出的Excel交给会后统计人员制作会后分析报告。\n感谢您的使用。", file.FullName);
                }
                else
                {
                    msg = "export excel file not exist";
                }


            }
            catch (Exception ex)
            {
                msg = "export excel failed.\n" + ex.Message;
            }

            MessageBox.Show(
                msg,
                "导出Excel",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private static readonly string DEFAULT_MESSAGE_TEXT = "请在右侧列表选择当前来宾";
        private static readonly string DEFAULT_CODE_TEXT = "未选择";
        private static readonly string DEFAULT_NAME_TEXT = "未选择";
        private static readonly string DEFAULT_COMPANY_TEXT = "未选择";

        private void ResetCurrentUser()
        {
            this.labMsg.Text = DEFAULT_MESSAGE_TEXT;
            this.labShowCode.Text = DEFAULT_CODE_TEXT;
            this.labShowName.Text = DEFAULT_NAME_TEXT;
            this.labShowCompany.Text = DEFAULT_COMPANY_TEXT;
            this.guestSelected = false;
        }

        //当前选中的用户
        private void SetValueForCurrentUser(int iRow)
        {
            try
            {
                DataGridViewRow dgvRow = dgvList.Rows[iRow];
                this.labShowCode.Text = dgvRow.Cells["guest_id"].Value.ToString();
                this.labShowName.Text = dgvRow.Cells["name"].Value.ToString();
                this.labShowCompany.Text = dgvRow.Cells["company"].Value.ToString();
                this.labMsg.Text = "";


                this.guestSelected = true;

                if (modeSurveyReturn)
                    btnSurvey.Focus();
                else
                    btnCheckIn.Focus();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (!this.guestSelected)
            {
                MessageBox.Show("请先在右侧列表选中来宾", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string guestId = labShowCode.Text;
            string guestName = labShowName.Text;

            if (guestId.Trim().Length > 0)
            {
                daoAccess.MakeActionLog(DaoAccess.LOG_TYPE.CHECK_IN, guestId.Trim());
                MessageBox.Show("来宾 " + guestId + " " + guestName + "签到成功", "签到完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                this.txtSearchWord.Text = "";
                this.ResetCurrentUser();
                this.txtSearchWord.Focus();
            }
        }

        private void btnSurvey_Click(object sender, EventArgs e)
        {
            if (!this.guestSelected)
            {
                MessageBox.Show("请先在右侧列表选中来宾", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string guestId = labShowCode.Text;
            string guestName = labShowName.Text;

            if (guestId.Trim().Length > 0)
            {
                daoAccess.MakeActionLog(DaoAccess.LOG_TYPE.RETURN_SURVEY, guestId.Trim());
                MessageBox.Show("来宾 " + guestId + " " + guestName + "交回问卷", "记录完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                this.txtSearchWord.Text = "";
                this.ResetCurrentUser();
                this.txtSearchWord.Focus();
            }
        }


    }
}
