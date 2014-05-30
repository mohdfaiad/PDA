using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDAScan
{
    public partial class FrmChuKu1 : Form
    {
        public FrmChuKu1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "select FID as 编号 from st_stockout where ForgID='" + user._FOrgID + "' and a.FdeptID='" + user._FDeptID + "' and fstatus='审核未出库' and (fid='" + this.textBox1.Text + "' or fsaleid='" + this.textBox1.Text + "')";
                DataSet ds = accessorDB.getDataSet(sql);
                if (ds.Tables[0].Rows.Count != 0)
                {

                    product._fid = ds.Tables[0].Rows[0][0].ToString();
                    ds.Dispose();
                    productOut1 pg = new productOut1();
                    if (pg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        pg.tabControl1.SelectedIndex = 0;
                        Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("出库单不存在或已经审核！", "提示");
                    ds.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string titel = this.Text;
            this.Text = string.Empty;
            pOutCheck pc = new pOutCheck();
            if (pc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pc.Dispose();
                this.Text = titel;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_outStockFind fr = new Frm_outStockFind(2);

            if (fr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                productOut1 fd = new productOut1();
                if (fr.listView1.FocusedItem.Selected)
                {
                    ListViewItem lv = fr.listView1.FocusedItem;
                    string curpfilenid = lv.SubItems[1].Text;
                    product._fid = curpfilenid;
                    fd.tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_outStockFind fr = new Frm_outStockFind(1);

            if (fr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                productOut1 fd = new productOut1();
                if (fr.listView1.FocusedItem.Selected)
                {
                    ListViewItem lv = fr.listView1.FocusedItem;
                    string curpfilenid = lv.SubItems[1].Text;
                    product._fid = curpfilenid;
                    fd.tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}