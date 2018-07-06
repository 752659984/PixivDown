using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Command;
using Command.Entity;

namespace PixivDown
{
    public partial class MainForm : Form
    {
        #region 窗体拖动代码 包含窗体事件
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
        #endregion

        private System.Threading.Timer timer = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("本软件仅供学习与研究使用，如用于任何非法用途，产生的法律责任将与作者无关！"
                , "声明", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.Close();
                return;
            }

            InitControl();

            //加载配置文件
            XmlHelp.InitXmlDoucument();

            LoadRegexJson();
            LoadXmlConfig();

            //检查更新
            //CheckUpdate();

            //加载背景图片
            if (File.Exists("Main.jpg"))
            {
                using (var fs = new FileStream("Main.jpg", FileMode.Open))
                {
                    var bitmap = new Bitmap(Image.FromStream(fs));
                    this.BackgroundImage = bitmap;
                }
            }

            //timer = new System.Threading.Timer(p => { ChangeCookieText(p); });
            timer = new System.Threading.Timer(ChangeCookieText);
        }

        #region 控件事件

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
        /// 打开单线程版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSingle_Click(object sender, EventArgs e)
        {
            rtxtCookie.Enabled = false;

            PixivSingleForm f = new PixivSingleForm();
            f.Show();
        }

        /// <summary>
        /// 打开多线程版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMutDown_Click(object sender, EventArgs e)
        {
            rtxtCookie.Enabled = false;

            PixivMultForm p = new PixivMultForm();
            p.Show();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ddlUserName.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
                {
                    MessageBox.Show("用户名密码不能为空！", "提示");
                    return;
                }

                lblMsg.Text = "登录中，请稍等...";
                EnableControl(false, this);
                SaveUserInfo();

                var name = ddlUserName.Text;
                var pwd = txtPassWord.Text;
                var ca = txtCaptcha.Text;
                var result = await Task.Run(()=> 
                {
                    return HtmlHelp.Login(name, pwd, ca);
                });

                if (result != null && result.Html.Contains("success"))
                {
                    btnSingle.Enabled = true;
                    btnMutDown.Enabled = true;
                    picCaptcha.Visible = false;

                    lblMsg.Text = "登录成功！";
                }
                else
                {
                    lblMsg.Text = "注：若账号密码正确，可能是需要输入验证码！";
                    MessageBox.Show("登录失败！", "提示");

                    EnableControl(true, this);
                    btnSingle.Enabled = false;
                    btnMutDown.Enabled = false;

                    //获取验证码
                    var buffter = HtmlHelp.GetCaptcha("https://accounts.pixiv.net/captcha");
                    if (buffter != null)
                    {
                        txtCaptcha.Enabled = true;
                        picCaptcha.Image = Image.FromStream(new MemoryStream(buffter));
                        picCaptcha.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "异常信息");
            }
        }


        /// <summary>
        /// 手动输入Cookie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtxtCookie_TextChanged(object sender, EventArgs e)
        {
            timer?.Change(-1, 0);
            timer?.Change(500, 1);
        }

        private void ChangeCookieText(object sender)
        {
            timer?.Change(-1, 0);
            this.Invoke(new Action(()=> 
            {
                HtmlHelp.cookiesString = rtxtCookie.Text;
                if (!string.IsNullOrWhiteSpace(HtmlHelp.cookiesString))
                {
                    EnableControl(false, this);

                    btnSingle.Enabled = true;
                    btnMutDown.Enabled = true;
                    rtxtCookie.Enabled = true;
                }
                else
                {
                    EnableControl(true, this);

                    txtCaptcha.Enabled = false;
                    btnSingle.Enabled = false;
                    btnMutDown.Enabled = false;
                }
                rtxtCookie.Focus();
            }));
        }


        /// <summary>
        /// 回车键直接登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// 用户账号下拉框变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (XmlHelp.doc == null)
                XmlHelp.InitXmlDoucument();

            var user = XmlHelp.GetXmlNodeByPath("Config:MainForm:UserInfo", "UserName=" + ddlUserName.Text);

            txtPassWord.Text = XmlHelp.GetInnerTextByXmlNode(user, "PassWord");
            chkRemPwd.Checked = bool.Parse(XmlHelp.GetInnerTextByXmlNode(user, "IsRememberPwd"));
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

        private void lblAuthor_Click(object sender, EventArgs e)
        {
            var msg = new StringBuilder();
            msg.Append("作者：JoySn\r\n");
            msg.Append("网址：JoySn.net\r\n");
            msg.Append("声明：本软件仅供学习与研究使用，如用于任何非法用途，产生的法律责任将与作者无关！");
            MessageBox.Show(msg.ToString(), "关于作者");
        }

        #endregion 控件事件

        #region 其他方法

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControl()
        {
            btnSingle.Enabled = false;
            btnMutDown.Enabled = false;
            txtCaptcha.Enabled = false;

            lblMsg.Text = "";
            picCaptcha.Visible = false;
        }

        /// <summary>
        /// 检查更新
        /// </summary>
        private void CheckUpdate()
        {
            try
            {
                var updateFile = XmlHelp.GetInnerTextByPath("Config:UpdateFileName");

                var ps = Process.GetProcessesByName(updateFile.Replace(".exe", ""));
                foreach (var p in ps)
                {
                    p.Kill();
                }
                if (File.Exists(updateFile))
                    File.Delete(updateFile);

                var url = XmlHelp.GetInnerTextByPath("Config:CheckVersionUrl");

                var json = HtmlHelp.Get(url);

                var result = JsonHelp.DeserializeObject<ResultEntity>(json);

                if (result.Code == "-1")
                {
                    MessageBox.Show(result.Message);
                }
                else if (result.Code == "1")
                {
                    UpdateDetailForm f = new UpdateDetailForm();
                    f.updateSoft = result.UpdateSoft;
                    f.updateDetail = result.UpdateDetail;

                    f.Show();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("检查更新失败！");
                //MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// 加载正则表达式配置文件
        /// </summary>
        private void LoadRegexJson()
        {
            try
            {
                StreamReader sr = new StreamReader("EachListRegex.json", Encoding.Unicode);
                var json = sr.ReadToEnd();
                sr.Dispose();

                RegexHelp.ListRegex = JsonHelp.DeserializeObject<List<EachListRegex>>(json);
            }
            catch (Exception e)
            {
                MessageBox.Show("加载配置文件失败！");
            }
        }

        /// <summary>
        /// 加载页面的配置信息
        /// </summary>
        private void LoadXmlConfig()
        {
            if (XmlHelp.doc == null)
                XmlHelp.InitXmlDoucument();

            ddlUserName.Items.Clear();
            try
            {
                var users = XmlHelp.GetXmlNodesByPath("Config:MainForm:UserInfo");
                foreach (XmlNode n in users)
                {
                    ddlUserName.Items.Add(n.SelectSingleNode("UserName").InnerText);
                }
            }
            catch { }
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        private void SaveUserInfo()
        {
            XmlHelp.SetXmlNode("Config:MainForm:UserInfo"
                , new Dictionary<string, string>()
                {
                    { "IsRememberPwd", chkRemPwd.Checked.ToString() },
                    { "UserName", ddlUserName.Text},
                    { "PassWord", chkRemPwd.Checked ? txtPassWord.Text : "" }
                }
                , "UserName");
        }

        #endregion 其他方法
    }
}
