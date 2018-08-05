using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command;
using Command.Entity;
using System.IO;
using System.Xml;
using System.Runtime.InteropServices;

namespace PixivDown
{
    public partial class PixivSingleForm : Form, IBaseForm
    {
        #region 窗体拖动代码 包含窗体事件
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void PixivSingleForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
        #endregion

        #region 实现接口
        public RadioButton RadAllFollow { get; set; }
        public RadioButton RadSingle { get; set; }
        public RadioButton RadCollection { get; set; }
        public RadioButton RadDupDir { get; set; }
        public RadioButton RadDupLast { get; set; }
        public CheckBox ChkNeglect { get; set; }
        public Label LblOtherText { get; set; }
        public Label LblGetThread { get; set; }
        public Label LblDownThread { get; set; }
        public RichTextBox RtxtSuccess { get; set; }
        public RichTextBox RtxtError { get; set; }
        public ComboBox DdlListUrl { get; set; }
        public TextBox TxtSavePath { get; set; }
        public TextBox TxtCurrListUrl { get; set; }
        public TextBox TxtItemUrl { get; set; }
        #endregion 实现接口

        public PixivDownHelp pHelp;

        public PixivSingleForm()
        {
            InitializeComponent();
            //窗体拖动
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void PixivSingleForm_Load(object sender, EventArgs e)
        {
            pHelp = new PixivDownHelp(this, this, true);

            this.Width = 700;
            this.Height = 700;

            var s = Screen.PrimaryScreen.Bounds;
            this.Location = new Point((s.Width - this.Width) / 2, (s.Height - this.Height) / 2);

            InitControlState();

            pHelp.LoadXmlConfig();

            //加载背景图片
            if (File.Exists("Single.jpg"))
            {
                using (var fs = new FileStream("Single.jpg", FileMode.Open))
                {
                    var bitmap = new Bitmap(Image.FromStream(fs));
                    this.BackgroundImage = bitmap;
                }
            }
        }

        #region 按钮事件

        /// <summary>
        /// 初始化控件的状态
        /// </summary>
        private void InitControlState()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            btnSuper.Enabled = false;

            radSingle.Checked = true;

            panDupRem.Enabled = false;
            radDupLast.Enabled = false;

            radDupDir.Checked = true;
            txtSearchUrl.Enabled = false;
        }

        /// <summary>
        /// 禁用或启用控件
        /// </summary>
        /// <param name="enable"></param>
        /// <param name="c"></param>
        private void EnableControl(bool enable, Control c)
        {
            foreach (Control item in c.Controls)
            {
                if (item is Label)
                    continue;

                item.Enabled = enable;
                if (item.Controls.Count > 0)
                    EnableControl(enable, item);
            }
        }

        /// <summary>
        /// 开始时对控件的操作
        /// </summary>
        private void StartEnableControl()
        {
            EnableControl(false, this);

            txtSavePath.Enabled = true;
            txtCurrListUrl.Enabled = true;
            txtItemUrl.Enabled = true;
            chkNeglect.Enabled = true;

            btnSuper.Enabled = true;
            btnStop.Enabled = true;
            btnShowMsg.Enabled = true;

            rtxtError.Enabled = true;
            rtxtSuccess.Enabled = true;
        }

        /// <summary>
        /// 结束时对控件的操作
        /// </summary>
        private void StopEnableControl()
        {
            EnableControl(true, this);

            ddlListUrl.Enabled = radSingle.Checked;
            txtSearchUrl.Enabled = radDownSearch.Checked;
            btnStop.Enabled = false;
            btnSuper.Enabled = false;
            radDupLast.Enabled = false;
        }

        /// <summary>
        /// 检查数据
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            if (radSingle.Checked && string.IsNullOrWhiteSpace(ddlListUrl.Text))
            {
                MessageBox.Show("请输入画师ID！", "提示");
                return false;
            }
            if (radSingle.Checked || radAuthorColl.Checked)
            {
                var r = new Regex("^[0-9]+$", RegexOptions.Singleline);
                if (!r.IsMatch(ddlListUrl.Text))
                {
                    MessageBox.Show("请输入纯数字ID！", "提示");
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtSavePath.Text))
            {
                MessageBox.Show("请选择保存路径！", "提示");
                return false;
            }
            if (HtmlHelp.cookiesString == "")
            {
                MessageBox.Show("请登录后再重试！", "提示");
                return false;
            }
            if (radDownSearch.Checked && string.IsNullOrWhiteSpace(txtSearchUrl.Text))
            {
                MessageBox.Show("请输入搜索的网址！", "提示");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <returns></returns>
        private bool DownHandler()
        {
            if (radSingle.Checked)
            {
                var listUrl = "https://www.pixiv.net/member_illust.php?id=" + ddlListUrl.Text;
                //pHelp.GetSingle(new RequestParameEntity() { ListUrl = listUrl, SavePath = txtSavePath.Text });
                pHelp.mainThread = new Thread(pHelp.GetSingle);
                pHelp.mainThread.IsBackground = true;
                pHelp.mainThread.Start(new RequestParameEntity() { ListUrl = listUrl, SavePath = txtSavePath.Text });
            }
            else if (radAllFollow.Checked)
            {
                //GetAllFollow(new RequestParameEntity() { SavePath = txtSavePath.Text, ParentPath = txtSavePath.Text });
                pHelp.mainThread = new Thread(pHelp.GetAllFollow);
                pHelp.mainThread.IsBackground = true;
                pHelp.mainThread.Start(new RequestParameEntity() { SavePath = txtSavePath.Text, ParentPath = txtSavePath.Text });
            }
            else if (radCollection.Checked)
            {
                //pHelp.GetCollection(new RequestParameEntity() { SavePath = txtSavePath.Text });
                pHelp.mainThread = new Thread(pHelp.GetCollection);
                pHelp.mainThread.IsBackground = true;
                pHelp.mainThread.Start(new RequestParameEntity() { SavePath = txtSavePath.Text });
            }
            else if (radAuthorColl.Checked)
            {
                //pHelp.GetCollection(new RequestParameEntity() { SavePath = txtSavePath.Text, ID = ddlListUrl.Text });
                pHelp.mainThread = new Thread(pHelp.GetAuthorCollection);
                pHelp.mainThread.IsBackground = true;
                pHelp.mainThread.Start(new RequestParameEntity() { SavePath = txtSavePath.Text, ID = ddlListUrl.Text });
            }
            else if (radDownSearch.Checked)
            {
                //pHelp.GetSearch(new RequestParameEntity() { SavePath = txtSavePath.Text, ListUrl = txtSearchUrl.Text });
                pHelp.mainThread = new Thread(pHelp.GetSearch);
                pHelp.mainThread.IsBackground = true;
                pHelp.mainThread.Start(new RequestParameEntity() { SavePath = txtSavePath.Text, ListUrl = txtSearchUrl.Text });
            }
            else
            {
                MessageBox.Show("没有对应的下载类型！");
                return false;
            }

            return true;
        }


        /// <summary>
        /// 现实或隐藏输出信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowMsg_Click(object sender, EventArgs e)
        {
            if (btnShowMsg.Text == "隐藏输出信息")
            {
                lblSuccess.Visible = false;
                lblError.Visible = false;
                rtxtError.Visible = false;
                rtxtSuccess.Visible = false;
                btnShowMsg.Text = "显示输出信息";
            }
            else
            {
                lblSuccess.Visible = true;
                lblError.Visible = true;
                rtxtError.Visible = true;
                rtxtSuccess.Visible = true;
                btnShowMsg.Text = "隐藏输出信息";
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sf = new FolderBrowserDialog();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = sf.SelectedPath + "/";

                txtSavePath.Text = txtSavePath.Text.Replace("\\", "/").Replace("//", "/");

                btnStart.Enabled = true;
            }
        }

        /// <summary>
        /// 终止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (pHelp.mainThread != null)
            {
                pHelp.mainThread.Abort();
            }
            while (pHelp.mainThread != null && pHelp.mainThread.IsAlive)
            {
                Thread.Sleep(100);
            }

            StopEnableControl();

            btnSuper.Text = "暂停";
            lblOtherText.Text = "";
        }

        /// <summary>
        /// 暂停或继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuper_Click(object sender, EventArgs e)
        {
            if (btnSuper.Text == "暂停")
            {
                if (pHelp.mainThread != null)
                {
                    pHelp.mainThread.Suspend();
                }
                btnSuper.Text = "继续";
            }
            else
            {
                if (pHelp.mainThread != null)
                {
                    pHelp.mainThread.Resume();
                }
                btnSuper.Text = "暂停";
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!CheckData())
                return;

            if (!Directory.Exists(txtSavePath.Text))
            {
                Directory.CreateDirectory(txtSavePath.Text);
            }

            StartEnableControl();

            if (pHelp.mainThread != null)
            {
                pHelp.mainThread.Abort();
            }

            pHelp.SavePainterInfo();

            pHelp.mut = new Multithreading(1, 1);

            if (!DownHandler())
            {
                return;
            }

            btnSuper.Text = "暂停";
            lblOtherText.Text = "";
        }

        #endregion 按钮事件

        #region 其他事件

        /// <summary>
        /// 下载类型单选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadDownType_CheckedChanged(object sender, EventArgs e)
        {
            if (radSingle.Checked || radAuthorColl.Checked)
            {
                ddlListUrl.Enabled = true;
            }
            else
            {
                ddlListUrl.Enabled = false;
            }
            panDupRem.Enabled = radAllFollow.Checked;
            txtSearchUrl.Enabled = radDownSearch.Checked;
        }

        /// <summary>
        /// 画师ID变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlListUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (XmlHelp.doc == null)
                XmlHelp.InitXmlDoucument();

            var node = XmlHelp.GetXmlNodesByPath("Config:PixivSingleForm:Painter").First(p => 
                p.SelectSingleNode("ID").InnerText == ddlListUrl.Text
            );

            if (node != null)
            {
                txtSavePath.Text = node.SelectSingleNode("SavePath").InnerText;
                if (txtSavePath.Text != "")
                    btnStart.Enabled = true;
            }
        }

        private void lblMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要关闭？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        #endregion 其他事件

    }
}
