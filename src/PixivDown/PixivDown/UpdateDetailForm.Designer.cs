namespace PixivDown
{
    partial class UpdateDetailForm
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
            this.rtxtUpdateDetail = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtUpdateDetail
            // 
            this.rtxtUpdateDetail.Location = new System.Drawing.Point(34, 26);
            this.rtxtUpdateDetail.Name = "rtxtUpdateDetail";
            this.rtxtUpdateDetail.ReadOnly = true;
            this.rtxtUpdateDetail.Size = new System.Drawing.Size(223, 239);
            this.rtxtUpdateDetail.TabIndex = 3;
            this.rtxtUpdateDetail.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(80, 284);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(131, 51);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "自动更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // UpdateDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 350);
            this.Controls.Add(this.rtxtUpdateDetail);
            this.Controls.Add(this.btnUpdate);
            this.Name = "UpdateDetailForm";
            this.Text = "UpdateDetailForm";
            this.Load += new System.EventHandler(this.UpdateDetailForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtUpdateDetail;
        private System.Windows.Forms.Button btnUpdate;
    }
}