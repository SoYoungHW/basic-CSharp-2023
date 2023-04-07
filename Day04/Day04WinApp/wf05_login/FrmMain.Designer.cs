namespace wf05_login
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelID = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.BtnMessageBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelID
            // 
            this.LabelID.AutoSize = true;
            this.LabelID.Location = new System.Drawing.Point(52, 42);
            this.LabelID.Name = "LabelID";
            this.LabelID.Size = new System.Drawing.Size(41, 12);
            this.LabelID.TabIndex = 0;
            this.LabelID.Text = "아이디";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(111, 36);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(100, 21);
            this.TxtID.TabIndex = 0;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(40, 85);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 12);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "패스워드";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(111, 82);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(100, 21);
            this.TxtPassword.TabIndex = 1;
            // 
            // BtnMessageBox
            // 
            this.BtnMessageBox.Location = new System.Drawing.Point(176, 120);
            this.BtnMessageBox.Name = "BtnMessageBox";
            this.BtnMessageBox.Size = new System.Drawing.Size(71, 35);
            this.BtnMessageBox.TabIndex = 2;
            this.BtnMessageBox.Text = "로그인";
            this.BtnMessageBox.UseVisualStyleBackColor = true;
            this.BtnMessageBox.Click += new System.EventHandler(this.BtnMessageBox_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 184);
            this.Controls.Add(this.BtnMessageBox);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.LabelID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelID;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button BtnMessageBox;
    }
}

