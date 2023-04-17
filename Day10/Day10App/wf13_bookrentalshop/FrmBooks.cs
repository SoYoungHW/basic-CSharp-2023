using MySql.Data.MySqlClient;
using Mysqlx.Sql;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace wf13_bookrentalshop
{
    public partial class FrmBooks : Form
    {
        #region < 변수 >
        bool isNew = false; // false(UPDATE), true(INSERT)
        #endregion

        #region < 생성자 >
        public FrmBooks()
        {
            InitializeComponent();
        }
        #endregion

        #region < 이벤트 핸들러 >
        private void FrmGenre_Load(object sender, EventArgs e)
        {
            isNew = true; // 신규부터 시작
            RefreshData();
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
                if (conn.State == ConnectionState.Closed) conn.Open();
                string strChkQuery = "SELECT COUNT(*) FROM bookstbl WHERE Division = @Division";
                MySqlCommand chkCmd = new MySqlCommand(strChkQuery, conn);
                MySqlParameter prmDivision = new MySqlParameter("@Division", Txtbookidx.Text);
                chkCmd.Parameters.Add(prmDivision);

                var result = chkCmd.ExecuteScalar(); // 실행

                if (result.ToString() != "0") // 값이 있다면
                {
                    MessageBox.Show("이미 사용중인 코드입니다", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Txtbookidx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();

                isNew = false; // 수정
                Txtbookidx.ReadOnly = true; // PK는 수정하면 안됨!

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
                        var selQuery = @"SELECT b.bookIdx
                                              , b.Author
                                              , b.Division
                                              , d.Names AS DivNames
                                              , b.Names
                                              , b.ReleaseDate
                                              , b.ISBN
                                              , b.Price
                                           FROM bookstbl as b
                                     INNER JOIN divtbl as d
                                             ON b.Division = d.Division
                                       ORDER BY b.bookIdx ASC"; // 정렬
                        MySqlDataAdapter adapter = new MySqlDataAdapter(selQuery, conn);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "bookstbl"); // divtbl으로 DataSet 접근가능

                        // DgvResult.DataSource = ds.Tables[0];
                        DgvResult.DataSource = ds;
                        DgvResult.DataMember = "bookstbl";

                        DgvResult.Columns[0].HeaderText = "번호";
                        DgvResult.Columns[1].HeaderText = "저자명";
                        DgvResult.Columns[2].HeaderText = "책장르";
                        DgvResult.Columns[3].HeaderText = "책장르";
                        DgvResult.Columns[4].HeaderText = "책제목";
                        DgvResult.Columns[5].HeaderText = "출판일자";
                        DgvResult.Columns[6].HeaderText = "ISBN";
                        DgvResult.Columns[7].HeaderText = "책가격";

                        DgvResult.Columns[0].Width = 55;
                        DgvResult.Columns[2].Visible = false; // B001 코드영역 보일필요 없음
                        DgvResult.Columns[4].Width = 130;
                        DgvResult.Columns[5].Width = 90;
                        DgvResult.Columns[7].Width = 80;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적인 오류 : {ex.Message} 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void ClearInputs()
        {
            Txtbookidx.Text = TxtNames.Text = string.Empty;
            Txtbookidx.ReadOnly = false; // 신규일때는 입력가능
            Txtbookidx.Focus();
            isNew = true; // 신규
        }
        private bool CheckValidation() 
        {
            // 입력검증
            var result = true;
            var errorMsg = string.Empty;

            if (string.IsNullOrEmpty(Txtbookidx.Text))
            {
                result = false;
                errorMsg += "● 장르코드를 입력하세요.\r\n";
            }

            if (string.IsNullOrEmpty(TxtNames.Text))
            {
                result = false;
                errorMsg += "● 장르명을 입력하세요.\r\n";
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

                    if (isNew)
                    {
                        query = @"INSERT INTO divtbl (Division, Names)
	                                                  VALUES (@Division, @Names)";
                    }
                    else
                    {
                        query = @"UPDATE divtbl
                                    SET	Names = @Names
                                    WHERE Division = @Division";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", Txtbookidx.Text);
                    MySqlParameter prmNames = new MySqlParameter("@Names", TxtNames.Text);
                    cmd.Parameters.Add(prmDivision);
                    cmd.Parameters.Add(prmNames);

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

                    var query = @"DELETE FROM divtbl
                                        WHERE Division = @Division";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlParameter prmDivision = new MySqlParameter("@Division", Txtbookidx.Text);
                    cmd.Parameters.Add(prmDivision);

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
    }
}