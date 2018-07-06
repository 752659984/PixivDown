namespace PixivDown
{
    partial class MainForm
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
            this.btnSingle = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.picCaptcha = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtCookie = new System.Windows.Forms.RichTextBox();
            this.ddlUserName = new System.Windows.Forms.ComboBox();
            this.chkRemPwd = new System.Windows.Forms.CheckBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.btnMutDown = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSingle
            // 
            this.btnSingle.BackColor = System.Drawing.Color.White;
            this.btnSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnSingle.Location = new System.Drawing.Point(163, 294);
            this.btnSingle.Name = "btnSingle";
            this.btnSingle.Size = new System.Drawing.Size(75, 23);
            this.btnSingle.TabIndex = 0;
            this.btnSingle.Text = "单线程版";
            this.btnSingle.UseVisualStyleBackColor = false;
            this.btnSingle.Click += new System.EventHandler(this.btnSingle_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(87, 104);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(282, 21);
            this.txtPassWord.TabIndex = 39;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(40, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 37;
            this.label16.Text = "密码：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(40, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "帐号：";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnLogin.Location = new System.Drawing.Point(32, 294);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 40;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblMsg.Location = new System.Drawing.Point(40, 462);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(28, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "验证码：";
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Location = new System.Drawing.Point(87, 150);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(282, 21);
            this.txtCaptcha.TabIndex = 43;
            this.txtCaptcha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Control_KeyDown);
            // 
            // picCaptcha
            // 
            this.picCaptcha.Location = new System.Drawing.Point(87, 191);
            this.picCaptcha.Name = "picCaptcha";
            this.picCaptcha.Size = new System.Drawing.Size(282, 50);
            this.picCaptcha.TabIndex = 44;
            this.picCaptcha.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(30, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "无法登录时手动输入Cookie：";
            // 
            // rtxtCookie
            // 
            this.rtxtCookie.Location = new System.Drawing.Point(32, 349);
            this.rtxtCookie.Name = "rtxtCookie";
            this.rtxtCookie.Size = new System.Drawing.Size(337, 96);
            this.rtxtCookie.TabIndex = 46;
            this.rtxtCookie.Text = "";
            this.rtxtCookie.TextChanged += new System.EventHandler(this.rtxtCookie_TextChanged);
            // 
            // ddlUserName
            // 
            this.ddlUserName.FormattingEnabled = true;
            this.ddlUserName.Location = new System.Drawing.Point(87, 56);
            this.ddlUserName.Name = "ddlUserName";
            this.ddlUserName.Size = new System.Drawing.Size(282, 20);
            this.ddlUserName.TabIndex = 0;
            this.ddlUserName.SelectedIndexChanged += new System.EventHandler(this.ddlUserName_SelectedIndexChanged);
            // 
            // chkRemPwd
            // 
            this.chkRemPwd.AutoSize = true;
            this.chkRemPwd.BackColor = System.Drawing.Color.Transparent;
            this.chkRemPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.chkRemPwd.Location = new System.Drawing.Point(87, 261);
            this.chkRemPwd.Name = "chkRemPwd";
            this.chkRemPwd.Size = new System.Drawing.Size(72, 16);
            this.chkRemPwd.TabIndex = 48;
            this.chkRemPwd.Text = "记住密码";
            this.chkRemPwd.UseVisualStyleBackColor = false;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblMin.Location = new System.Drawing.Point(333, 4);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 27);
            this.lblMin.TabIndex = 74;
            this.lblMin.Text = "_";
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblClose.Location = new System.Drawing.Point(370, 4);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(26, 27);
            this.lblClose.TabIndex = 73;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // btnMutDown
            // 
            this.btnMutDown.BackColor = System.Drawing.Color.White;
            this.btnMutDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMutDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnMutDown.Location = new System.Drawing.Point(294, 294);
            this.btnMutDown.Name = "btnMutDown";
            this.btnMutDown.Size = new System.Drawing.Size(75, 23);
            this.btnMutDown.TabIndex = 75;
            this.btnMutDown.Text = "多线程版";
            this.btnMutDown.UseVisualStyleBackColor = false;
            this.btnMutDown.Click += new System.EventHandler(this.btnMutDown_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(18, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 12);
            this.lblTitle.TabIndex = 76;
            this.lblTitle.Text = "PixivDown v1.1";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblAuthor.Location = new System.Drawing.Point(336, 479);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(53, 12);
            this.lblAuthor.TabIndex = 77;
            this.lblAuthor.Text = "关于作者";
            this.lblAuthor.Click += new System.EventHandler(this.lblAuthor_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnMutDown);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.chkRemPwd);
            this.Controls.Add(this.ddlUserName);
            this.Controls.Add(this.rtxtCookie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picCaptcha);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnSingle);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSingle;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.PictureBox picCaptcha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtCookie;
        private System.Windows.Forms.ComboBox ddlUserName;
        private System.Windows.Forms.CheckBox chkRemPwd;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnMutDown;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
    }
}