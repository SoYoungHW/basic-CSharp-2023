namespace wf03_property
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.GbxMain = new System.Windows.Forms.GroupBox();
            this.NudFontSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.ChkBold = new System.Windows.Forms.CheckBox();
            this.ChkItalic = new System.Windows.Forms.CheckBox();
            this.CboFontFamily = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TrbDummy = new System.Windows.Forms.TrackBar();
            this.PgbDummy = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnModal = new System.Windows.Forms.Button();
            this.BtnModaless = new System.Windows.Forms.Button();
            this.BtnMsgBox = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TrvDummy = new System.Windows.Forms.TreeView();
            this.LsvDummy = new System.Windows.Forms.ListView();
            this.BtnAddRoot = new System.Windows.Forms.Button();
            this.BtnAddChild = new System.Windows.Forms.Button();
            this.RboNomal = new System.Windows.Forms.RadioButton();
            this.RboIndent = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PcbDummy = new System.Windows.Forms.PictureBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.GbxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFontSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrbDummy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcbDummy)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxMain
            // 
            this.GbxMain.Controls.Add(this.RboIndent);
            this.GbxMain.Controls.Add(this.RboNomal);
            this.GbxMain.Controls.Add(this.NudFontSize);
            this.GbxMain.Controls.Add(this.label2);
            this.GbxMain.Controls.Add(this.TxtResult);
            this.GbxMain.Controls.Add(this.ChkBold);
            this.GbxMain.Controls.Add(this.ChkItalic);
            this.GbxMain.Controls.Add(this.CboFontFamily);
            this.GbxMain.Controls.Add(this.label1);
            this.GbxMain.Location = new System.Drawing.Point(12, 12);
            this.GbxMain.Name = "GbxMain";
            this.GbxMain.Size = new System.Drawing.Size(405, 195);
            this.GbxMain.TabIndex = 0;
            this.GbxMain.TabStop = false;
            this.GbxMain.Text = "컨트롤 학습";
            // 
            // NudFontSize
            // 
            this.NudFontSize.Location = new System.Drawing.Point(90, 52);
            this.NudFontSize.Name = "NudFontSize";
            this.NudFontSize.Size = new System.Drawing.Size(121, 21);
            this.NudFontSize.TabIndex = 4;
            this.NudFontSize.ValueChanged += new System.EventHandler(this.NudFontSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "글자크기";
            // 
            // TxtResult
            // 
            this.TxtResult.Location = new System.Drawing.Point(12, 85);
            this.TxtResult.Multiline = true;
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.ReadOnly = true;
            this.TxtResult.Size = new System.Drawing.Size(380, 102);
            this.TxtResult.TabIndex = 6;
            // 
            // ChkBold
            // 
            this.ChkBold.AutoSize = true;
            this.ChkBold.Location = new System.Drawing.Point(233, 26);
            this.ChkBold.Name = "ChkBold";
            this.ChkBold.Size = new System.Drawing.Size(48, 18);
            this.ChkBold.TabIndex = 2;
            this.ChkBold.Text = "볼드";
            this.ChkBold.UseVisualStyleBackColor = true;
            this.ChkBold.CheckedChanged += new System.EventHandler(this.ChkBold_CheckedChanged);
            // 
            // ChkItalic
            // 
            this.ChkItalic.AutoSize = true;
            this.ChkItalic.Location = new System.Drawing.Point(299, 26);
            this.ChkItalic.Name = "ChkItalic";
            this.ChkItalic.Size = new System.Drawing.Size(59, 18);
            this.ChkItalic.TabIndex = 3;
            this.ChkItalic.Text = "이텔릭";
            this.ChkItalic.UseVisualStyleBackColor = true;
            this.ChkItalic.CheckedChanged += new System.EventHandler(this.ChkItalic_CheckedChanged);
            // 
            // CboFontFamily
            // 
            this.CboFontFamily.FormattingEnabled = true;
            this.CboFontFamily.Location = new System.Drawing.Point(90, 24);
            this.CboFontFamily.Name = "CboFontFamily";
            this.CboFontFamily.Size = new System.Drawing.Size(121, 22);
            this.CboFontFamily.TabIndex = 1;
            this.CboFontFamily.SelectedIndexChanged += new System.EventHandler(this.CboFontFamily_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "글자체";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PgbDummy);
            this.groupBox1.Controls.Add(this.TrbDummy);
            this.groupBox1.Location = new System.Drawing.Point(12, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "트랙바 및 진행바";
            // 
            // TrbDummy
            // 
            this.TrbDummy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TrbDummy.Location = new System.Drawing.Point(13, 26);
            this.TrbDummy.Maximum = 20;
            this.TrbDummy.Name = "TrbDummy";
            this.TrbDummy.Size = new System.Drawing.Size(380, 45);
            this.TrbDummy.TabIndex = 7;
            this.TrbDummy.Scroll += new System.EventHandler(this.TrbDummy_Scroll);
            // 
            // PgbDummy
            // 
            this.PgbDummy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PgbDummy.Location = new System.Drawing.Point(23, 71);
            this.PgbDummy.Maximum = 20;
            this.PgbDummy.Name = "PgbDummy";
            this.PgbDummy.Size = new System.Drawing.Size(360, 25);
            this.PgbDummy.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnMsgBox);
            this.groupBox2.Controls.Add(this.BtnModaless);
            this.groupBox2.Controls.Add(this.BtnModal);
            this.groupBox2.Location = new System.Drawing.Point(12, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 60);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "모달/리스/메시지창";
            // 
            // BtnModal
            // 
            this.BtnModal.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnModal.Location = new System.Drawing.Point(59, 19);
            this.BtnModal.Name = "BtnModal";
            this.BtnModal.Size = new System.Drawing.Size(75, 30);
            this.BtnModal.TabIndex = 8;
            this.BtnModal.Text = "Modal";
            this.BtnModal.UseVisualStyleBackColor = true;
            this.BtnModal.Click += new System.EventHandler(this.BtnModal_Click);
            // 
            // BtnModaless
            // 
            this.BtnModaless.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnModaless.Location = new System.Drawing.Point(140, 19);
            this.BtnModaless.Name = "BtnModaless";
            this.BtnModaless.Size = new System.Drawing.Size(87, 30);
            this.BtnModaless.TabIndex = 9;
            this.BtnModaless.Text = "Modaless";
            this.BtnModaless.UseVisualStyleBackColor = true;
            this.BtnModaless.Click += new System.EventHandler(this.BtnModaless_Click);
            // 
            // BtnMsgBox
            // 
            this.BtnMsgBox.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnMsgBox.Location = new System.Drawing.Point(233, 19);
            this.BtnMsgBox.Name = "BtnMsgBox";
            this.BtnMsgBox.Size = new System.Drawing.Size(112, 30);
            this.BtnMsgBox.TabIndex = 10;
            this.BtnMsgBox.Text = "MessageBox";
            this.BtnMsgBox.UseVisualStyleBackColor = true;
            this.BtnMsgBox.Click += new System.EventHandler(this.BtnMsgBox_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnAddChild);
            this.groupBox3.Controls.Add(this.BtnAddRoot);
            this.groupBox3.Controls.Add(this.LsvDummy);
            this.groupBox3.Controls.Add(this.TrvDummy);
            this.groupBox3.Location = new System.Drawing.Point(423, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 195);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "트리뷰/리스트뷰";
            // 
            // TrvDummy
            // 
            this.TrvDummy.Location = new System.Drawing.Point(14, 20);
            this.TrvDummy.Name = "TrvDummy";
            this.TrvDummy.Size = new System.Drawing.Size(185, 127);
            this.TrvDummy.TabIndex = 11;
            // 
            // LsvDummy
            // 
            this.LsvDummy.HideSelection = false;
            this.LsvDummy.Location = new System.Drawing.Point(205, 20);
            this.LsvDummy.Name = "LsvDummy";
            this.LsvDummy.Size = new System.Drawing.Size(185, 127);
            this.LsvDummy.TabIndex = 12;
            this.LsvDummy.UseCompatibleStateImageBehavior = false;
            // 
            // BtnAddRoot
            // 
            this.BtnAddRoot.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnAddRoot.Location = new System.Drawing.Point(20, 153);
            this.BtnAddRoot.Name = "BtnAddRoot";
            this.BtnAddRoot.Size = new System.Drawing.Size(85, 30);
            this.BtnAddRoot.TabIndex = 13;
            this.BtnAddRoot.Text = "루트추가";
            this.BtnAddRoot.UseVisualStyleBackColor = true;
            this.BtnAddRoot.Click += new System.EventHandler(this.BtnAddRoot_Click);
            // 
            // BtnAddChild
            // 
            this.BtnAddChild.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnAddChild.Location = new System.Drawing.Point(111, 153);
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.Size = new System.Drawing.Size(85, 30);
            this.BtnAddChild.TabIndex = 14;
            this.BtnAddChild.Text = "자식추가";
            this.BtnAddChild.UseVisualStyleBackColor = true;
            this.BtnAddChild.Click += new System.EventHandler(this.BtnAddChild_Click);
            // 
            // RboNomal
            // 
            this.RboNomal.AutoSize = true;
            this.RboNomal.Checked = true;
            this.RboNomal.Location = new System.Drawing.Point(233, 52);
            this.RboNomal.Name = "RboNomal";
            this.RboNomal.Size = new System.Drawing.Size(47, 18);
            this.RboNomal.TabIndex = 5;
            this.RboNomal.TabStop = true;
            this.RboNomal.Text = "일반";
            this.RboNomal.UseVisualStyleBackColor = true;
            this.RboNomal.CheckedChanged += new System.EventHandler(this.RboNomal_CheckedChanged);
            // 
            // RboIndent
            // 
            this.RboIndent.AutoSize = true;
            this.RboIndent.Location = new System.Drawing.Point(299, 51);
            this.RboIndent.Name = "RboIndent";
            this.RboIndent.Size = new System.Drawing.Size(69, 18);
            this.RboIndent.TabIndex = 5;
            this.RboIndent.Text = "들여쓰기";
            this.RboIndent.UseVisualStyleBackColor = true;
            this.RboIndent.CheckedChanged += new System.EventHandler(this.RboIndent_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnLoad);
            this.groupBox4.Controls.Add(this.PcbDummy);
            this.groupBox4.Location = new System.Drawing.Point(424, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(404, 173);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "픽쳐박스";
            // 
            // PcbDummy
            // 
            this.PcbDummy.Location = new System.Drawing.Point(17, 16);
            this.PcbDummy.Name = "PcbDummy";
            this.PcbDummy.Size = new System.Drawing.Size(314, 147);
            this.PcbDummy.TabIndex = 0;
            this.PcbDummy.TabStop = false;
            this.PcbDummy.Click += new System.EventHandler(this.PcbDummy_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnLoad.Location = new System.Drawing.Point(339, 20);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(55, 36);
            this.BtnLoad.TabIndex = 1;
            this.BtnLoad.Text = "로드";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(838, 396);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GbxMain);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "속성 확인";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.GbxMain.ResumeLayout(false);
            this.GbxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFontSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrbDummy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PcbDummy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.CheckBox ChkBold;
        private System.Windows.Forms.CheckBox ChkItalic;
        private System.Windows.Forms.ComboBox CboFontFamily;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudFontSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar PgbDummy;
        private System.Windows.Forms.TrackBar TrbDummy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnMsgBox;
        private System.Windows.Forms.Button BtnModaless;
        private System.Windows.Forms.Button BtnModal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView LsvDummy;
        private System.Windows.Forms.TreeView TrvDummy;
        private System.Windows.Forms.Button BtnAddChild;
        private System.Windows.Forms.Button BtnAddRoot;
        private System.Windows.Forms.RadioButton RboIndent;
        private System.Windows.Forms.RadioButton RboNomal;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.PictureBox PcbDummy;
    }
}

