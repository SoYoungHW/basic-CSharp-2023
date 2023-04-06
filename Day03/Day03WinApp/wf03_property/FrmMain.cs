using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf03_property
{
    public partial class FrmMain : Form
    {
        Random rnd = new Random();
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
            if (CboFontFamily.SelectedIndex < 0)
            {
                CboFontFamily.SelectedIndex = 279;
            } // 초기화, 디폴트는 나눔고딕

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
        private void ChangeIndent()
        {
            if (RboNomal.Checked) // 라디오버튼 추가 이벤트
            {
                TxtResult.Text = TxtResult.Text.Trim();
            }
            else if (RboIndent.Checked)
            {
                TxtResult.Text = "    " + TxtResult.Text;
            }
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

        private void TrbDummy_Scroll(object sender, EventArgs e)
        {
            PgbDummy.Value = TrbDummy.Value;
        }

        private void BtnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modal Form",
                Width = 300,
                Height = 200,
                Left = 10,
                Top = 20,
                BackColor = Color.AliceBlue,
                StartPosition = FormStartPosition.CenterParent
            };

            frm.ShowDialog(); // 새창(자식창) 띄우기
        } // 모달방식으로(자식창이 떠있는 동안 부모창 못건드리게)

        private void BtnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form()
            {
                Text = "Modaless Form",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterScreen,
                // Modaless 는 Centerparent 안먹힘
                BackColor = Color.SkyBlue
            };
            frm.Show();
        } // 모달리스 방식으로 자식창 띄움(부모창과 관게없음)

        // 기본적으로 MessageBox는 모달
        private void BtnMsgBox_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(TxtResult.Text); // 기본
            // MessageBox.Show(TxtResult.Text, caption: "메시지창"); // 캡션사용방법
            MessageBox.Show(TxtResult.Text, "메시지창", MessageBoxButtons.OKCancel, // 버튼추가
                            MessageBoxIcon.Information, // 아이콘추가
            // 여기까지는 알고 있어야함!
                            MessageBoxDefaultButton.Button2, // 기본포커스 버튼설정(디폴트버튼)
                            MessageBoxOptions.RightAlign); // 글자 오른쪽 정렬
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            TrvDummy.Nodes.Add(rnd.Next(50).ToString());
            TreeToList();
        }

        private void BtnAddChild_Click(object sender, EventArgs e)
        {
            if (TrvDummy.SelectedNode != null)
            {
                TrvDummy.SelectedNode.Nodes.Add(rnd.Next(50, 100).ToString());
                TrvDummy.SelectedNode.Expand(); // 트리노드 하위것 펼쳐주기, 반대 Collapse
                TreeToList();
            }
        }

        void TreeToList()
        {
            LsvDummy.Items.Clear(); // 리스트뷰, 트리뷰, ...뷰 모든 아이템을 제거/초기화 메서드
            foreach (TreeNode item in TrvDummy.Nodes)
            {
                TreeToList(item);
            }
        }

        private void TreeToList(TreeNode item)
        {
            LsvDummy.Items.Add(
                new ListViewItem(new[] { item.Text, item.FullPath.ToString() }));
            foreach (TreeNode node in item.Nodes)
            {
                TreeToList(node); // 재귀호출
            }
        }

        private void RboNomal_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void RboIndent_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIndent();
        }

        private void PcbDummy_Click(object sender, EventArgs e)
        {
            if ( PcbDummy.SizeMode == PictureBoxSizeMode.Normal)
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PcbDummy.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            PcbDummy.Image = Bitmap.FromFile("cat.png");
        }
    }
}