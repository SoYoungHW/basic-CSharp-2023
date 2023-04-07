using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf05_login
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnMessageBox_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "abcd" && TxtPassword.Text == "1234")
            {
                MessageBox.Show("로그인성공", "메시지창", MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("로그인실패", "메시지창", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
