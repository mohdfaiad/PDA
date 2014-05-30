using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace PDAScan
{
    public partial class frmLogin : Form
    {
        SqlCeConnection conn;
        public frmLogin()
        {
            InitializeComponent();
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string spath = @"Data Source=Application Data\PDADB.sdf";
            string strid = this.txtUserID.Text.Trim();
            string strpwd = this.txtPwd.Text.Trim();
            if (strid == "")
            {
                MessageBox.Show("请输入用户编号!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (strpwd == "")
            {
                 MessageBox.Show("请输入用户密码!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            string sql = "select usersn,pwd,flag from tuser where userid ='" + strid + "'";
            try
            {
                conn = new SqlCeConnection(spath);
                conn.Open();
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                SqlCeDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    string tmpsn = read[0].ToString();
                    string tmppwd = read[1].ToString();
                    string tmpflag = read[2].ToString();
                    conn.Close();
                    if (tmpflag != "0")
                    {
                        MessageBox.Show("非有效用户!" , "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (tmppwd != strpwd)
                    {
                        MessageBox.Show("用户密码不正确!" , "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    CurrentUser.USERSN = tmpsn;
                    frmMain fm = new frmMain();
                    fm.ShowDialog();
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("没找到用户信息!" , "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("登陆异常!"+ ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUserID.Focus();
        }

        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPwd.Focus();
                this.txtPwd.SelectAll();
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this.btnLogin, e);
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape :
                    btnExit_Click(this.btnExit, e);
                    break;
                default :
                    break;
            }
        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }
    }
}