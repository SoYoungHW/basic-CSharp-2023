using MySql.Data.MySqlClient;
using Mysqlx.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using wf13_bookrentalshop.Helpers;

namespace wf13_bookrentalshop
{
    public partial class FrmMembers : Form
    {
        #region < 변수 >
        bool isNew = false; // false(UPDATE), true(INSERT)
        #endregion

        #region < 생성자 >
        public FrmMembers()
        {
            InitializeComponent();
        }
        #endregion

        #region < 이벤트 핸들러 >
        private void FrmGenre_Load(object sender, EventArgs e)
        {
            isNew = true; // 신규부터 시작
            RefreshData();
            LoadCboData(); // 콤보박스에 들어갈 데이터 로드
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidation() != true) return;

            SaveData();
            RefreshData(); // 데이터 재조회
            ClearInputs(); // 입력창 클리어
            // 이런식으로 메서드를 만들어서 재활용하는 것이 좋음!
        }
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (isNew == true) // 신규
            {
                MessageBox.Show("삭제할 데이터를 선택하세요", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // FK제약조건으로 지울수없는 데이터인지 먼저 확인
            using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                string strChkQuery = "SELECT COUNT(*) FROM rentaltbl WHERE bookIdx = @bookIdx";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmBookIdx = new MySqlParameter("@bookIdx", Txtmemberidx.Text);
                chkCmd.Parameters.Add(prmBookIdx);

                var result = chkCmd.ExecuteScalar(); // 실행

                if (result.ToString() != "0") // 값이 있다면
                {
                    MessageBox.Show("이미 대여중인 책입니다", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

            if (MessageBox.Show(this, "삭제 하시겠습니까?", "삭제",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            // Yes를 누르면 계속 진행
            DeleteData();
            RefreshData(); // 지우고 나서 재조회
            ClearInputs();
        }
        private void DgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 그리드뷰 클릭하면 발생하는 이벤트
            if (e.RowIndex > -1) // 아무것도 선택X -1
            {
                var selData = DgvResult.Rows[e.RowIndex];
                // MessageBox.Show(selData.ToString());
                // Debug.WriteLine(selData.ToString());
                Debug.WriteLine(selData.Cells[0].Value);
                Debug.WriteLine(selData.Cells[1].Value);
                isNew = false; // 수정
                // Txtbookidx.ReadOnly = true; // PK는 수정하면 안됨!
                Txtmemberidx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                CboLevels.SelectedValue = selData.Cells[2].Value.ToString();
                TxtAddr.Text = selData.Cells[3].Value.ToString();
                TxtMobile.Text = selData.Cells[4].Value.ToString();
                TxtEmail.Text = selData.Cells[5].Value.ToString();
            }
        }

        #endregion

        #region < 커스텀 메서드 >
        private void RefreshData()
        {
            // DB divtbl 데이터 조회 DgvResult 뿌림
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();

                        // 쿼리작성
                        var selQuery = @"SELECT memberIdx,
                                                Names,
                                                Levels,
                                                Addr,
                                                Mobile,
                                                Email
                                           FROM membertbl
                                       ORDER BY memberIdx ASC;"; // 정렬
                        MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "membertbl"); // divtbl으로 DataSet 접근가능

                        // DgvResult.DataSource = ds.Tables[0];
                        DgvResult.DataSource = ds;
                        DgvResult.DataMember = "membertbl";

                        // 데이터그리드뷰 컬럼 헤더 제목
                        DgvResult.Columns[0].HeaderText = "번호";
                        DgvResult.Columns[1].HeaderText = "회원명";
                        DgvResult.Columns[2].HeaderText = "등급";
                        DgvResult.Columns[3].HeaderText = "주소";
                        DgvResult.Columns[4].HeaderText = "전화번호";
                        DgvResult.Columns[5].HeaderText = "이메일";                        
                        
                        // 컬럼 넓이 또는 보이기
                        DgvResult.Columns[0].Width = 55;
                        DgvResult.Columns[1].Width = 65;
                        DgvResult.Columns[2].Width = 55;
                        DgvResult.Columns[3].Width = 120;
                        DgvResult.Columns[4].Width = 160;
                        DgvResult.Columns[5].Width = 90;
                        
                        // 컬럼 정렬
                        DgvResult.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        // 콤보박스
                        CboLevels.DisplayMember = "Name"; //
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RefreshData()의 비정상적인 오류 : {ex.Message} 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCboData()
        {
            
                    // 콤보박스에 할당
                    //CboLevels.DataSource = new BindingSource(temp, null);
                    //CboLevels.DisplayMember = "Value";
                    //CboLevels.ValueMember = "Key";
                    //CboLevels.SelectedIndex = -1;

               
        }

        private void ClearInputs()
        {
            Txtmemberidx.Text = TxtAddr.Text = TxtNames.Text = TxtEmail.Text = TxtMobile.Text = string.Empty;
            // Txtbookidx.ReadOnly = false; // 신규일때는 입력가능
            CboLevels.SelectedIndex = -1;
            
            TxtNames.Focus(); // 번호는 입력안함
            isNew = true; // 신규
        }
        private bool CheckValidation() 
        {
            // 입력검증
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "● 회원명를 입력하세요.\r\n";
            }

            if (result == false)
            {
                MessageBox.Show(errorMsg, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // 메서드 탈출
            }
            return result;
        }
        private void SaveData()
        {
            // isNew = true INSERT / false UPDATE
            // INSERT부터 시작
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }

                    var query = "";

                    if (isNew == true)
                    {
                        query = @"INSERT INTO membertbl
                                            ( Names,
                                              Levels,
                                              Addr,
                                              Mobile,
                                              Email )
                                        VALUES
                                            ( @Names,
                                              @Levels,
                                              @Addr,
                                              @Mobile,
                                              @Email);";
                    }
                    else
                    {
                        query = @"UPDATE membertbl
                                     SET Names = @Names,
                                         Levels = @Levels,
                                         Addr = @Addr,
                                         Mobile = @Mobile,
                                         Email = @Email
                                   WHERE memberIdx = @memberIdx;";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    MySqlParameter prmLevels = new MySqlParameter("@Levels", CboLevels.DataSource);
                    MySqlParameter prmAddr = new MySqlParameter("@Addr", TxtAddr.Text);
                    MySqlParameter prmMobile = new MySqlParameter("@Mobile", TxtMobile.Text);
                    MySqlParameter prmEmail = new MySqlParameter("@Email", TxtEmail.Text);
                    
                    cmd.Parameters.Add(prmNames);
                    cmd.Parameters.Add(prmLevels);
                    cmd.Parameters.Add(prmAddr);
                    cmd.Parameters.Add(prmMobile);
                    cmd.Parameters.Add(prmEmail);
                    
                    if (isNew == false) // update 할때는 bookidx 파라미터를 추가!
                    {
                        MySqlParameter prmMemberIdx = new MySqlParameter("@memberidx", Txtmemberidx.Text);
                        cmd.Parameters.Add(prmMemberIdx);
                    }

                    var result = cmd.ExecuteNonQuery(); // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        MessageBox.Show("저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("저장실패..", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Helpers.Commons.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }

                    var query = @"DELETE FROM membertbl
                                        WHERE memberIdx = @memberIdx";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prMemberIdx = new MySqlParameter("@memberIdx", Txtmemberidx.Text);
                    cmd.Parameters.Add(prMemberIdx);

                    var result = cmd.ExecuteNonQuery(); // INSERT, UPDATE, DELETE

                    if (result != 0)
                    {
                        MessageBox.Show("삭제성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("삭제실패..", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적 오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void DgvResult_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DgvResult.ClearSelection(); // 첫번째열 철번째셀 선택되어있는것을 해제
        }
    }
}