using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wf13_bookrentalshop
{
    public partial class FrmLogin : Form
    {
        private bool isLogined = false; // 로그인이 성공했는지 물어보는 변수
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            isLogined = LoginProcess(); // 로그인을 성공해야만 true가 됨

            if (isLogined)
            {
                this.Close();
            }
            else { return; }
        }

        // 핵심! DB userTbl에서 정보확인해서 로그인 처리
        private bool LoginProcess()
        {
            // Validation Check(입력검증) 내용이 들어있는지 검증
            if (string.IsNullOrEmpty(TxtuserID.Text))
            {
                MessageBox.Show("유저아이디를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(TxtPassword.Text))
            {
                MessageBox.Show("패스워드를 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string strUserId = "";
            string strPassword = "";

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345";
                // DB 처리

                // 구식
                //MySqlConnection conn = new MySqlConnection("");
                //conn.Open();
                //conn.Close();

                // 최신?(Close()필요없음)
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    #region < DB 쿼리를 위한 구성 >
                    string selQuery = @"SELECT userId
	                                         , password
                                          FROM usertbl
                                         WHERE userId = @userId 
                                           AND password = @password"; // WHERE절에 @userID @password 로 쓰는게 좋음
                    MySqlCommand selCmd = new MySqlCommand(selQuery, conn); // 첫번째는 쿼리문, 두번째 커넥션
                    // @userId @password 파라미터 할당
                    MySqlParameter prmUserID = new MySqlParameter("@userId", TxtuserID.Text);
                    MySqlParameter prmPassword = new MySqlParameter("@password", TxtPassword.Text);
                    selCmd.Parameters.Add(prmUserID);
                    selCmd.Parameters.Add(prmPassword);
                    #endregion

                    MySqlDataReader reader = selCmd.ExecuteReader(); // 실행한 다음에 userId, password
                    if (reader.Read())
                    {

                        strUserId = reader["userId"] != null ? reader["userId"].ToString() : "-";
                        strPassword = reader["password"] != null ? reader["password"].ToString() : "--";
                    }
                    else
                    {
                        MessageBox.Show("로그인 정보가 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                // MessageBox.Show($"{strUserId} / {strPassword}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"비정상적인 오류 : {ex.Message} 입력하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // 엔터키 누르면
            {
                BtnLogin_Click(sender, e); // 버튼클릭 이벤트핸들러 호출
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            Environment.Exit(0); // 가장 완벽하게 프로그램 종료시키는 메서드
        }

        // 이게 없으면 종료 버튼이나 Alt+F4 했을 때 메인폼이 나타남
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogined != true)
            {
                Environment.Exit(0);
            }
        }

        // 유저아이디 텍스트 박스에서 엔터를 치면 텍스트박스로 포커스이동
        private void TxtuserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                TxtPassword.Focus();
            }
        }
    }
}
