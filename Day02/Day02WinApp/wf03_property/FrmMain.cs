using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent(); // 절대 지우면X
            // 생성자에는 되도록 설정부분 넣지X
            // Form_Load() 이벤트 핸들러에 작성할 것
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            GbxMain.Text = "컨트롤 학습";
            var fonts = FontFamily.Families.ToList(); // 내 OS에 있는 폰트이름 전부 가져오기
            // Families 배열, ToList() 컬렉션
            foreach (var font in fonts)
            {
                CboFontFamily.Items.Add(font.Name);
            }

            // 글자크기 최솟값, 최대값 지정
            NudFontSize.Minimum = 5;
            NudFontSize.Maximum = 40;

            // 텍스트박스 초기화
            TxtResult.Text = "Hello WinForms!";

            NudFontSize.Value = 9; // 최초의 글자체 크기를 9로 지정
        }
        /// <summary>
        /// 글자스타일, 크기, 글자체를 변경해주는 메서드
        /// </summary>
        private void ChangeFontStyle()
        {
            if (CboFontFamily.SelectedIndex < 0) { return; } // 초기화

            FontStyle style = FontStyle.Regular; // 기본
            if (ChkBold.Checked == true) // 굵게
            {
                style |= FontStyle.Bold; // Bit 연산 or
            }
            if (ChkItalic.Checked == true) // 기울임
            {
                style |= FontStyle.Italic;            
            }
            decimal FontSize = NudFontSize.Value; // Value가 decimal 이라서 dacimal로 받음
            // 글자사이즈 설정
            TxtResult.Font = new Font((string)CboFontFamily.SelectedItem, (float)FontSize, style);
            // 텍스트 박스에 지정한 스타일(폰트), 크기로 글자 나오게함
        }
        private void CboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void NudFontSize_ValueChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }
    }
}
