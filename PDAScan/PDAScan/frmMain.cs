using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAScan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInvChk_Click(object sender, EventArgs e)
        {
            frmInvChk fic = new frmInvChk();
            fic.ShowDialog();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    btnInvChk_Click(this.btnInvChk, e);
                    break;
                case Keys.D2:
                    btnPorderIn_Click(this.btnPorderIn, e);
                    break;
                case Keys.D3:
                    btnPRorderOut_Click(this.btnPRorderOut, e);
                    break;
                case Keys.D4:
                    btnDgoods_Click(this.btnDgoods, e);
                    break;
                //case Keys.D5:
                    //btnShopRgoods_Click(this.btnShopRgoods, e);
                    //break;
                case Keys.D6:
                    //btnSale_Click(this.btnSale, e);
                    break;
                case Keys.D7:
                    btnTelSale_Click(this.btnTelSale, e);
                    break;
                case Keys.D8:
                    btnChkGoods_Click(this.btnChkGoods, e);
                    break;
                case Keys.Escape:
                    btnExit_Click(this.btnExit, e);
                    break;
                default :
                    break;
            }
        }

        private void btnPorderIn_Click(object sender, EventArgs e)
        {
            frmInvIn fii = new frmInvIn();
            fii.ShowDialog();
        }

        private void btnPRorderOut_Click(object sender, EventArgs e)
        {
            frmChuKu fck = new  frmChuKu();
            fck.ShowDialog();
        }

        private void btnDgoods_Click(object sender, EventArgs e)
        {
            frmDGoods fdg = new frmDGoods();
            fdg.ShowDialog();
        }

        //private void btnShopRgoods_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnSale_Click(object sender, EventArgs e)
        //{

        //}

        private void btnTelSale_Click(object sender, EventArgs e)
        {
            frmTelSale fts = new frmTelSale();
            fts.ShowDialog();
        }

        private void btnChkGoods_Click(object sender, EventArgs e)
        {
            frmGoodChk fgc = new frmGoodChk();
            fgc.ShowDialog();
        }
    }
}