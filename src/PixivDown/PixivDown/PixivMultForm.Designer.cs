namespace PixivDown
{
    partial class PixivMultForm
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
            this.lblMin = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.btnSuper = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.radCollection = new System.Windows.Forms.RadioButton();
            this.radAllFollow = new System.Windows.Forms.RadioButton();
            this.radSingle = new System.Windows.Forms.RadioButton();
            this.lblError = new System.Windows.Forms.Label();
            this.rtxtError = new System.Windows.Forms.RichTextBox();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.rtxtSuccess = new System.Windows.Forms.RichTextBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlListUrl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGetThread = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDownThread = new System.Windows.Forms.Label();
            this.lblOtherText = new System.Windows.Forms.Label();
            this.btnShowMsg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numGetCount = new System.Windows.Forms.NumericUpDown();
            this.numDownCount = new System.Windows.Forms.NumericUpDown();
            this.chkNeglect = new System.Windows.Forms.CheckBox();
            this.panDupRem = new System.Windows.Forms.Panel();
            this.radDupDir = new System.Windows.Forms.RadioButton();
            this.radDupLast = new System.Windows.Forms.RadioButton();
            this.radDupNot = new System.Windows.Forms.RadioButton();
            this.radDownSearch = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearchUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numSleep = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            this.radAuthorColl = new System.Windows.Forms.RadioButton();
            this.radSingleWorks = new System.Windows.Forms.RadioButton();
            this.chkRelatedWorks = new System.Windows.Forms.CheckBox();
            this.panRelated = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numGetCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDownCount)).BeginInit();
            this.panDupRem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleep)).BeginInit();
            this.panRelated.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BackColor = System.Drawing.Color.Transparent;
            this.lblMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMin.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblMin.Location = new System.Drawing.Point(581, 5);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(26, 27);
            this.lblMin.TabIndex = 94;
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
            this.lblClose.Location = new System.Drawing.Point(618, 5);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(26, 27);
            this.lblClose.TabIndex = 93;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // btnSuper
            // 
            this.btnSuper.BackColor = System.Drawing.Color.White;
            this.btnSuper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnSuper.Location = new System.Drawing.Point(281, 348);
            this.btnSuper.Name = "btnSuper";
            this.btnSuper.Size = new System.Drawing.Size(75, 23);
            this.btnSuper.TabIndex = 92;
            this.btnSuper.Text = "暂停";
            this.btnSuper.UseVisualStyleBackColor = false;
            this.btnSuper.Click += new System.EventHandler(this.btnSuper_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnStop.Location = new System.Drawing.Point(405, 348);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 91;
            this.btnStop.Text = "终止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // radCollection
            // 
            this.radCollection.AutoSize = true;
            this.radCollection.BackColor = System.Drawing.Color.Transparent;
            this.radCollection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radCollection.Location = new System.Drawing.Point(358, 155);
            this.radCollection.Name = "radCollection";
            this.radCollection.Size = new System.Drawing.Size(107, 16);
            this.radCollection.TabIndex = 90;
            this.radCollection.TabStop = true;
            this.radCollection.Text = "下载自己的收藏";
            this.radCollection.UseVisualStyleBackColor = false;
            this.radCollection.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // radAllFollow
            // 
            this.radAllFollow.AutoSize = true;
            this.radAllFollow.BackColor = System.Drawing.Color.Transparent;
            this.radAllFollow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radAllFollow.Location = new System.Drawing.Point(36, 216);
            this.radAllFollow.Name = "radAllFollow";
            this.radAllFollow.Size = new System.Drawing.Size(131, 16);
            this.radAllFollow.TabIndex = 88;
            this.radAllFollow.TabStop = true;
            this.radAllFollow.Text = "下载所有关注的画师";
            this.radAllFollow.UseVisualStyleBackColor = false;
            this.radAllFollow.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // radSingle
            // 
            this.radSingle.AutoSize = true;
            this.radSingle.BackColor = System.Drawing.Color.Transparent;
            this.radSingle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radSingle.Location = new System.Drawing.Point(36, 155);
            this.radSingle.Name = "radSingle";
            this.radSingle.Size = new System.Drawing.Size(119, 16);
            this.radSingle.TabIndex = 87;
            this.radSingle.TabStop = true;
            this.radSingle.Text = "仅下载指定的画师";
            this.radSingle.UseVisualStyleBackColor = false;
            this.radSingle.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblError.Location = new System.Drawing.Point(31, 589);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(65, 12);
            this.lblError.TabIndex = 86;
            this.lblError.Text = "其他信息：";
            // 
            // rtxtError
            // 
            this.rtxtError.HideSelection = false;
            this.rtxtError.Location = new System.Drawing.Point(31, 607);
            this.rtxtError.Name = "rtxtError";
            this.rtxtError.Size = new System.Drawing.Size(592, 111);
            this.rtxtError.TabIndex = 85;
            this.rtxtError.Text = "";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.BackColor = System.Drawing.Color.Transparent;
            this.lblSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblSuccess.Location = new System.Drawing.Point(31, 396);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(65, 12);
            this.lblSuccess.TabIndex = 84;
            this.lblSuccess.Text = "成功信息：";
            // 
            // rtxtSuccess
            // 
            this.rtxtSuccess.HideSelection = false;
            this.rtxtSuccess.Location = new System.Drawing.Point(31, 414);
            this.rtxtSuccess.Name = "rtxtSuccess";
            this.rtxtSuccess.Size = new System.Drawing.Size(592, 153);
            this.rtxtSuccess.TabIndex = 83;
            this.rtxtSuccess.Text = "";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(142, 67);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(481, 21);
            this.txtSavePath.TabIndex = 82;
            this.txtSavePath.DoubleClick += new System.EventHandler(this.txtSavePath_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label12.Location = new System.Drawing.Point(47, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 81;
            this.label12.Text = "当前保存路径：";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.White;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnStart.Location = new System.Drawing.Point(157, 348);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 80;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(33, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "保存到...";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlListUrl
            // 
            this.ddlListUrl.FormattingEnabled = true;
            this.ddlListUrl.Location = new System.Drawing.Point(142, 28);
            this.ddlListUrl.Name = "ddlListUrl";
            this.ddlListUrl.Size = new System.Drawing.Size(282, 20);
            this.ddlListUrl.TabIndex = 74;
            this.ddlListUrl.SelectedIndexChanged += new System.EventHandler(this.ddlListUrl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(83, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 73;
            this.label1.Text = "画师ID：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(258, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 95;
            this.label2.Text = "当前获取数：";
            // 
            // lblGetThread
            // 
            this.lblGetThread.AutoSize = true;
            this.lblGetThread.BackColor = System.Drawing.Color.Transparent;
            this.lblGetThread.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblGetThread.Location = new System.Drawing.Point(341, 316);
            this.lblGetThread.Name = "lblGetThread";
            this.lblGetThread.Size = new System.Drawing.Size(11, 12);
            this.lblGetThread.TabIndex = 96;
            this.lblGetThread.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(370, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 97;
            this.label3.Text = "当前下载数：";
            // 
            // lblDownThread
            // 
            this.lblDownThread.AutoSize = true;
            this.lblDownThread.BackColor = System.Drawing.Color.Transparent;
            this.lblDownThread.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblDownThread.Location = new System.Drawing.Point(453, 316);
            this.lblDownThread.Name = "lblDownThread";
            this.lblDownThread.Size = new System.Drawing.Size(11, 12);
            this.lblDownThread.TabIndex = 98;
            this.lblDownThread.Text = "0";
            // 
            // lblOtherText
            // 
            this.lblOtherText.AutoSize = true;
            this.lblOtherText.BackColor = System.Drawing.Color.Transparent;
            this.lblOtherText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblOtherText.Location = new System.Drawing.Point(31, 725);
            this.lblOtherText.Name = "lblOtherText";
            this.lblOtherText.Size = new System.Drawing.Size(0, 12);
            this.lblOtherText.TabIndex = 99;
            // 
            // btnShowMsg
            // 
            this.btnShowMsg.BackColor = System.Drawing.Color.White;
            this.btnShowMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.btnShowMsg.Location = new System.Drawing.Point(529, 348);
            this.btnShowMsg.Name = "btnShowMsg";
            this.btnShowMsg.Size = new System.Drawing.Size(91, 23);
            this.btnShowMsg.TabIndex = 100;
            this.btnShowMsg.Text = "隐藏输出信息";
            this.btnShowMsg.UseVisualStyleBackColor = false;
            this.btnShowMsg.Click += new System.EventHandler(this.btnShowMsg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(144, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 102;
            this.label4.Text = "下载数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(34, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 101;
            this.label5.Text = "获取数：";
            // 
            // numGetCount
            // 
            this.numGetCount.Location = new System.Drawing.Point(85, 314);
            this.numGetCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numGetCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGetCount.Name = "numGetCount";
            this.numGetCount.Size = new System.Drawing.Size(40, 21);
            this.numGetCount.TabIndex = 103;
            this.numGetCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numDownCount
            // 
            this.numDownCount.Location = new System.Drawing.Point(196, 314);
            this.numDownCount.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDownCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numDownCount.Name = "numDownCount";
            this.numDownCount.Size = new System.Drawing.Size(40, 21);
            this.numDownCount.TabIndex = 104;
            this.numDownCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkNeglect
            // 
            this.chkNeglect.AutoSize = true;
            this.chkNeglect.BackColor = System.Drawing.Color.Transparent;
            this.chkNeglect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.chkNeglect.Location = new System.Drawing.Point(503, 269);
            this.chkNeglect.Name = "chkNeglect";
            this.chkNeglect.Size = new System.Drawing.Size(120, 16);
            this.chkNeglect.TabIndex = 105;
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
            this.panDupRem.Location = new System.Drawing.Point(175, 202);
            this.panDupRem.Name = "panDupRem";
            this.panDupRem.Size = new System.Drawing.Size(448, 43);
            this.panDupRem.TabIndex = 106;
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
            this.radDownSearch.Location = new System.Drawing.Point(525, 155);
            this.radDownSearch.Name = "radDownSearch";
            this.radDownSearch.Size = new System.Drawing.Size(95, 16);
            this.radDownSearch.TabIndex = 107;
            this.radDownSearch.TabStop = true;
            this.radDownSearch.Text = "下载搜索内容";
            this.radDownSearch.UseVisualStyleBackColor = false;
            this.radDownSearch.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(47, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 108;
            this.label6.Text = "搜索完整网址：";
            // 
            // txtSearchUrl
            // 
            this.txtSearchUrl.Location = new System.Drawing.Point(142, 106);
            this.txtSearchUrl.Name = "txtSearchUrl";
            this.txtSearchUrl.Size = new System.Drawing.Size(481, 21);
            this.txtSearchUrl.TabIndex = 109;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(484, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 110;
            this.label7.Text = "延时(ms)：";
            // 
            // numSleep
            // 
            this.numSleep.Location = new System.Drawing.Point(551, 314);
            this.numSleep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSleep.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSleep.Name = "numSleep";
            this.numSleep.Size = new System.Drawing.Size(69, 21);
            this.numSleep.TabIndex = 111;
            this.numSleep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(18, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 12);
            this.lblTitle.TabIndex = 112;
            this.lblTitle.Text = "PixivDown v1.1";
            // 
            // radAuthorColl
            // 
            this.radAuthorColl.AutoSize = true;
            this.radAuthorColl.BackColor = System.Drawing.Color.Transparent;
            this.radAuthorColl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radAuthorColl.Location = new System.Drawing.Point(188, 155);
            this.radAuthorColl.Name = "radAuthorColl";
            this.radAuthorColl.Size = new System.Drawing.Size(131, 16);
            this.radAuthorColl.TabIndex = 113;
            this.radAuthorColl.TabStop = true;
            this.radAuthorColl.Text = "下载指定画师的收藏";
            this.radAuthorColl.UseVisualStyleBackColor = false;
            this.radAuthorColl.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
            // 
            // radSingleWorks
            // 
            this.radSingleWorks.AutoSize = true;
            this.radSingleWorks.BackColor = System.Drawing.Color.Transparent;
            this.radSingleWorks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(255)))));
            this.radSingleWorks.Location = new System.Drawing.Point(36, 268);
            this.radSingleWorks.Name = "radSingleWorks";
            this.radSingleWorks.Size = new System.Drawing.Size(107, 16);
            this.radSingleWorks.TabIndex = 114;
            this.radSingleWorks.TabStop = true;
            this.radSingleWorks.Text = "仅下载单个作品";
            this.radSingleWorks.UseVisualStyleBackColor = false;
            this.radSingleWorks.CheckedChanged += new System.EventHandler(this.RadDownType_CheckedChanged);
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
            // panRelated
            // 
            this.panRelated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panRelated.Controls.Add(this.chkRelatedWorks);
            this.panRelated.Location = new System.Drawing.Point(175, 255);
            this.panRelated.Name = "panRelated";
            this.panRelated.Size = new System.Drawing.Size(118, 44);
            this.panRelated.TabIndex = 116;
            // 
            // PixivMultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 745);
            this.Controls.Add(this.panRelated);
            this.Controls.Add(this.radSingleWorks);
            this.Controls.Add(this.radAuthorColl);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.numSleep);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSearchUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radDownSearch);
            this.Controls.Add(this.panDupRem);
            this.Controls.Add(this.chkNeglect);
            this.Controls.Add(this.numDownCount);
            this.Controls.Add(this.numGetCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnShowMsg);
            this.Controls.Add(this.lblOtherText);
            this.Controls.Add(this.lblDownThread);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGetThread);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.ddlListUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PixivMultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PixivMultForm";
            this.Load += new System.EventHandler(this.PixivMultForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PixivMultForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.numGetCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDownCount)).EndInit();
            this.panDupRem.ResumeLayout(false);
            this.panDupRem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleep)).EndInit();
            this.panRelated.ResumeLayout(false);
            this.panRelated.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Button btnSuper;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RadioButton radCollection;
        private System.Windows.Forms.RadioButton radAllFollow;
        private System.Windows.Forms.RadioButton radSingle;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.RichTextBox rtxtError;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.RichTextBox rtxtSuccess;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlListUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGetThread;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDownThread;
        private System.Windows.Forms.Label lblOtherText;
        private System.Windows.Forms.Button btnShowMsg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numGetCount;
        private System.Windows.Forms.NumericUpDown numDownCount;
        private System.Windows.Forms.CheckBox chkNeglect;
        private System.Windows.Forms.Panel panDupRem;
        private System.Windows.Forms.RadioButton radDupDir;
        private System.Windows.Forms.RadioButton radDupLast;
        private System.Windows.Forms.RadioButton radDupNot;
        private System.Windows.Forms.RadioButton radDownSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearchUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numSleep;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton radAuthorColl;
        private System.Windows.Forms.RadioButton radSingleWorks;
        private System.Windows.Forms.CheckBox chkRelatedWorks;
        private System.Windows.Forms.Panel panRelated;
    }
}