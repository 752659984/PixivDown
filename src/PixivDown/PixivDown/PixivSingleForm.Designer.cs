namespace PixivDown
{
    partial class PixivSingleForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ddlListUrl = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCurrListUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtItemUrl = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.rtxtSuccess = new System.Windows.Forms.RichTextBox();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.rtxtError = new System.Windows.Forms.RichTextBox();
            this.radSingle = new System.Windows.Forms.RadioButton();
            this.radAllFollow = new System.Windows.Forms.RadioButton();
            this.radCollection = new System.Windows.Forms.RadioButton();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSuper = new System.Windows.Forms.Button();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblOtherText = new System.Windows.Forms.Label();
            this.btnShowMsg = new System.Windows.Forms.Button();
            this.chkNeglect = new System.Windows.Forms.CheckBox();
            this.panDupRem = new System.Windows.Forms.Panel();
            this.radDupDir = new System.Windows.Forms.RadioButton();
            this.radDupLast = new System.Windows.Forms.RadioButton();
            this.radDupNot = new System.Windows.Forms.RadioButton();
            this.radDownSearch = new System.Windows.Forms.RadioButton();
            this.txtSearchUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.radAuthorColl = new System.Windows.Forms.RadioButton();
            this.panRelated = new System.Windows.Forms.Panel();
            this.chkRelatedWorks = new System.Windows.Forms.CheckBox();
            this.radSingleWorks = new System.Windows.Forms.RadioButton();
            this.panDupRem.SuspendLayout();
            this.panRelated.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(106, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "画师ID：";
            // 
            // ddlListUrl
            // 
            this.ddlListUrl.FormattingEnabled = true;
            this.ddlListUrl.Location = new System.Drawing.Point(165, 29);
            this.ddlListUrl.Name = "ddlListUrl";
            this.ddlListUrl.Size = new System.Drawing.Size(282, 20);
            this.ddlListUrl.TabIndex = 1;
            this.ddlListUrl.SelectedIndexChanged += new System.EventHandler(this.ddlListUrl_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(83, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "当前列表页：";
            // 
            // txtCurrListUrl
            // 
            this.txtCurrListUrl.Location = new System.Drawing.Point(166, 72);
            this.txtCurrListUrl.Name = "txtCurrListUrl";
            this.txtCurrListUrl.ReadOnly = true;
            this.txtCurrListUrl.Size = new System.Drawing.Size(480, 21);
            this.txtCurrListUrl.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(94, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "当前作品：";
            // 
            // txtItemUrl
            // 
            this.txtItemUrl.Location = new System.Drawing.Point(166, 116);
            this.txtItemUrl.Name = "txtItemUrl";
            this.txtItemUrl.ReadOnly = true;
            this.txtItemUrl.Size = new System.Drawing.Size(481, 21);
            this.txtItemUrl.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(55, 394);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存到...";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnStart.Location = new System.Drawing.Point(180, 394);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label12.Location = new System.Drawing.Point(70, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "当前保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(165, 160);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(481, 21);
            this.txtSavePath.TabIndex = 25;
            // 
            // rtxtSuccess
            // 
            this.rtxtSuccess.HideSelection = false;
            this.rtxtSuccess.Location = new System.Drawing.Point(54, 455);
            this.rtxtSuccess.Name = "rtxtSuccess";
            this.rtxtSuccess.Size = new System.Drawing.Size(592, 111);
            this.rtxtSuccess.TabIndex = 26;
            this.rtxtSuccess.Text = "";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.BackColor = System.Drawing.Color.Transparent;
            this.lblSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblSuccess.Location = new System.Drawing.Point(54, 437);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(65, 12);
            this.lblSuccess.TabIndex = 27;
            this.lblSuccess.Text = "成功信息：";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblError.Location = new System.Drawing.Point(55, 579);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(65, 12);
            this.lblError.TabIndex = 29;
            this.lblError.Text = "其他信息：";
            // 
            // rtxtError
            // 
            this.rtxtError.HideSelection = false;
            this.rtxtError.Location = new System.Drawing.Point(55, 600);
            this.rtxtError.Name = "rtxtError";
            this.rtxtError.Size = new System.Drawing.Size(592, 88);
            this.rtxtError.TabIndex = 28;
            this.rtxtError.Text = "";
            // 
            // radSingle
            // 
            this.radSingle.AutoSize = true;
            this.radSingle.BackColor = System.Drawing.Color.Transparent;
            this.radSingle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radSingle.Location = new System.Drawing.Point(55, 254);
            this.radSingle.Name = "radSingle";
            this.radSingle.Size = new System.Drawing.Size(119, 16);
            this.radSingle.TabIndex = 38;
            this.radSingle.TabStop = true;
            this.radSingle.Text = "仅下载指定的画师";
            this.radSingle.UseVisualStyleBackColor = false;
            this.radSingle.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // radAllFollow
            // 
            this.radAllFollow.AutoSize = true;
            this.radAllFollow.BackColor = System.Drawing.Color.Transparent;
            this.radAllFollow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radAllFollow.Location = new System.Drawing.Point(54, 305);
            this.radAllFollow.Name = "radAllFollow";
            this.radAllFollow.Size = new System.Drawing.Size(131, 16);
            this.radAllFollow.TabIndex = 39;
            this.radAllFollow.TabStop = true;
            this.radAllFollow.Text = "下载所有关注的画师";
            this.radAllFollow.UseVisualStyleBackColor = false;
            this.radAllFollow.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // radCollection
            // 
            this.radCollection.AutoSize = true;
            this.radCollection.BackColor = System.Drawing.Color.Transparent;
            this.radCollection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radCollection.Location = new System.Drawing.Point(397, 254);
            this.radCollection.Name = "radCollection";
            this.radCollection.Size = new System.Drawing.Size(107, 16);
            this.radCollection.TabIndex = 42;
            this.radCollection.TabStop = true;
            this.radCollection.Text = "下载自己的收藏";
            this.radCollection.UseVisualStyleBackColor = false;
            this.radCollection.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnStop.Location = new System.Drawing.Point(430, 394);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 43;
            this.btnStop.Text = "终止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSuper
            // 
            this.btnSuper.BackColor = System.Drawing.Color.White;
            this.btnSuper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnSuper.Location = new System.Drawing.Point(305, 394);
            this.btnSuper.Name = "btnSuper";
            this.btnSuper.Size = new System.Drawing.Size(75, 23);
            this.btnSuper.TabIndex = 44;
            this.btnSuper.Text = "暂停";
            this.btnSuper.UseVisualStyleBackColor = false;
            this.btnSuper.Click += new System.EventHandler(this.btnSuper_Click);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblMin.Location = new System.Drawing.Point(633, 4);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 27);
            this.lblMin.TabIndex = 72;
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
            this.lblClose.Location = new System.Drawing.Point(670, 4);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(26, 27);
            this.lblClose.TabIndex = 71;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblOtherText
            // 
            this.lblOtherText.AutoSize = true;
            this.lblOtherText.BackColor = System.Drawing.Color.Transparent;
            this.lblOtherText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblOtherText.Location = new System.Drawing.Point(54, 679);
            this.lblOtherText.Name = "lblOtherText";
            this.lblOtherText.Size = new System.Drawing.Size(0, 12);
            this.lblOtherText.TabIndex = 73;
            // 
            // btnShowMsg
            // 
            this.btnShowMsg.BackColor = System.Drawing.Color.White;
            this.btnShowMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnShowMsg.Location = new System.Drawing.Point(555, 394);
            this.btnShowMsg.Name = "btnShowMsg";
            this.btnShowMsg.Size = new System.Drawing.Size(91, 23);
            this.btnShowMsg.TabIndex = 101;
            this.btnShowMsg.Text = "隐藏输出信息";
            this.btnShowMsg.UseVisualStyleBackColor = false;
            this.btnShowMsg.Click += new System.EventHandler(this.btnShowMsg_Click);
            // 
            // chkNeglect
            // 
            this.chkNeglect.AutoSize = true;
            this.chkNeglect.BackColor = System.Drawing.Color.Transparent;
            this.chkNeglect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.chkNeglect.Location = new System.Drawing.Point(527, 358);
            this.chkNeglect.Name = "chkNeglect";
            this.chkNeglect.Size = new System.Drawing.Size(120, 16);
            this.chkNeglect.TabIndex = 106;
            this.chkNeglect.Text = "显示被忽略的数据";
            this.chkNeglect.UseVisualStyleBackColor = false;
            // 
            // panDupRem
            // 
            this.panDupRem.BackColor = System.Drawing.Color.Transparent;
            this.panDupRem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDupRem.Controls.Add(this.radDupDir);
            this.panDupRem.Controls.Add(this.radDupLast);
            this.panDupRem.Controls.Add(this.radDupNot);
            this.panDupRem.Location = new System.Drawing.Point(198, 291);
            this.panDupRem.Name = "panDupRem";
            this.panDupRem.Size = new System.Drawing.Size(448, 43);
            this.panDupRem.TabIndex = 107;
            // 
            // radDupDir
            // 
            this.radDupDir.AutoSize = true;
            this.radDupDir.BackColor = System.Drawing.Color.Transparent;
            this.radDupDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radDupDir.Location = new System.Drawing.Point(12, 14);
            this.radDupDir.Name = "radDupDir";
            this.radDupDir.Size = new System.Drawing.Size(143, 16);
            this.radDupDir.TabIndex = 90;
            this.radDupDir.TabStop = true;
            this.radDupDir.Text = "根据画师ID文件夹去重";
            this.radDupDir.UseVisualStyleBackColor = false;
            // 
            // radDupLast
            // 
            this.radDupLast.AutoSize = true;
            this.radDupLast.BackColor = System.Drawing.Color.Transparent;
            this.radDupLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radDupLast.Location = new System.Drawing.Point(182, 14);
            this.radDupLast.Name = "radDupLast";
            this.radDupLast.Size = new System.Drawing.Size(167, 16);
            this.radDupLast.TabIndex = 89;
            this.radDupLast.TabStop = true;
            this.radDupLast.Text = "根据画师作品最后一个判断";
            this.radDupLast.UseVisualStyleBackColor = false;
            // 
            // radDupNot
            // 
            this.radDupNot.AutoSize = true;
            this.radDupNot.BackColor = System.Drawing.Color.Transparent;
            this.radDupNot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radDupNot.Location = new System.Drawing.Point(376, 15);
            this.radDupNot.Name = "radDupNot";
            this.radDupNot.Size = new System.Drawing.Size(59, 16);
            this.radDupNot.TabIndex = 88;
            this.radDupNot.TabStop = true;
            this.radDupNot.Text = "不去重";
            this.radDupNot.UseVisualStyleBackColor = false;
            // 
            // radDownSearch
            // 
            this.radDownSearch.AutoSize = true;
            this.radDownSearch.BackColor = System.Drawing.Color.Transparent;
            this.radDownSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radDownSearch.Location = new System.Drawing.Point(550, 254);
            this.radDownSearch.Name = "radDownSearch";
            this.radDownSearch.Size = new System.Drawing.Size(95, 16);
            this.radDownSearch.TabIndex = 108;
            this.radDownSearch.TabStop = true;
            this.radDownSearch.Text = "下载搜索内容";
            this.radDownSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchUrl
            // 
            this.txtSearchUrl.Location = new System.Drawing.Point(165, 204);
            this.txtSearchUrl.Name = "txtSearchUrl";
            this.txtSearchUrl.Size = new System.Drawing.Size(481, 21);
            this.txtSearchUrl.TabIndex = 111;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(70, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 110;
            this.label6.Text = "搜索完整网址：";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(18, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 12);
            this.lblTitle.TabIndex = 113;
            this.lblTitle.Text = "PixivDown v1.1";
            // 
            // radAuthorColl
            // 
            this.radAuthorColl.AutoSize = true;
            this.radAuthorColl.BackColor = System.Drawing.Color.Transparent;
            this.radAuthorColl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radAuthorColl.Location = new System.Drawing.Point(220, 254);
            this.radAuthorColl.Name = "radAuthorColl";
            this.radAuthorColl.Size = new System.Drawing.Size(131, 16);
            this.radAuthorColl.TabIndex = 114;
            this.radAuthorColl.TabStop = true;
            this.radAuthorColl.Text = "下载指定画师的收藏";
            this.radAuthorColl.UseVisualStyleBackColor = false;
            this.radAuthorColl.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // panRelated
            // 
            this.panRelated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panRelated.Controls.Add(this.chkRelatedWorks);
            this.panRelated.Location = new System.Drawing.Point(198, 344);
            this.panRelated.Name = "panRelated";
            this.panRelated.Size = new System.Drawing.Size(118, 44);
            this.panRelated.TabIndex = 118;
            // 
            // chkRelatedWorks
            // 
            this.chkRelatedWorks.AutoSize = true;
            this.chkRelatedWorks.BackColor = System.Drawing.Color.Transparent;
            this.chkRelatedWorks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.chkRelatedWorks.Location = new System.Drawing.Point(12, 13);
            this.chkRelatedWorks.Name = "chkRelatedWorks";
            this.chkRelatedWorks.Size = new System.Drawing.Size(96, 16);
            this.chkRelatedWorks.TabIndex = 115;
            this.chkRelatedWorks.Text = "下载相关作品";
            this.chkRelatedWorks.UseVisualStyleBackColor = false;
            // 
            // radSingleWorks
            // 
            this.radSingleWorks.AutoSize = true;
            this.radSingleWorks.BackColor = System.Drawing.Color.Transparent;
            this.radSingleWorks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radSingleWorks.Location = new System.Drawing.Point(55, 357);
            this.radSingleWorks.Name = "radSingleWorks";
            this.radSingleWorks.Size = new System.Drawing.Size(107, 16);
            this.radSingleWorks.TabIndex = 117;
            this.radSingleWorks.TabStop = true;
            this.radSingleWorks.Text = "仅下载单个作品";
            this.radSingleWorks.UseVisualStyleBackColor = false;
            this.radSingleWorks.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // PixivSingleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 700);
            this.Controls.Add(this.panRelated);
            this.Controls.Add(this.radSingleWorks);
            this.Controls.Add(this.radAuthorColl);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearchUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radDownSearch);
            this.Controls.Add(this.panDupRem);
            this.Controls.Add(this.chkNeglect);
            this.Controls.Add(this.btnShowMsg);
            this.Controls.Add(this.lblOtherText);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.btnSuper);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.radCollection);
            this.Controls.Add(this.radAllFollow);
            this.Controls.Add(this.radSingle);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.rtxtError);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.rtxtSuccess);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtItemUrl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCurrListUrl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ddlListUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PixivSingleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PixivSingleDown";
            this.Load += new System.EventHandler(this.PixivSingleForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PixivSingleForm_MouseDown);
            this.panDupRem.ResumeLayout(false);
            this.panDupRem.PerformLayout();
            this.panRelated.ResumeLayout(false);
            this.panRelated.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlListUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCurrListUrl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtItemUrl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.RichTextBox rtxtSuccess;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.RichTextBox rtxtError;
        private System.Windows.Forms.RadioButton radSingle;
        private System.Windows.Forms.RadioButton radAllFollow;
        private System.Windows.Forms.RadioButton radCollection;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSuper;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblOtherText;
        private System.Windows.Forms.Button btnShowMsg;
        private System.Windows.Forms.CheckBox chkNeglect;
        private System.Windows.Forms.Panel panDupRem;
        private System.Windows.Forms.RadioButton radDupDir;
        private System.Windows.Forms.RadioButton radDupLast;
        private System.Windows.Forms.RadioButton radDupNot;
        private System.Windows.Forms.RadioButton radDownSearch;
        private System.Windows.Forms.TextBox txtSearchUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton radAuthorColl;
        private System.Windows.Forms.Panel panRelated;
        private System.Windows.Forms.CheckBox chkRelatedWorks;
        private System.Windows.Forms.RadioButton radSingleWorks;
    }
}

