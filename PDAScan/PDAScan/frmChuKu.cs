using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace PDAScan
{
    public partial class frmChuKu : Form
    {
        SqlCeConnection conn_db = new SqlCeConnection();
        SqlCeConnection conn_scan = new SqlCeConnection();
        string _dbpath = @"Data Source=Application Data\PDADB.sdf";
        string _dbscan = @"Data Source=Application Data\PDAScan.sdf";
        SqlCeCommand cmd_scan = new SqlCeCommand();
        SqlCeCommand cmd_db = new SqlCeCommand();
        SqlCeDataAdapter ada_db;
        SqlCeDataAdapter ada_scan;
        string strinvinsn = "";
        string strprosn = "";
        string strporderdsn = "";
        string strrate = "";
        string strnoinvqty = "";
        string strscanflag = "";
        int icur = -1;
        public frmChuKu()
        {
            InitializeComponent();
        }

        private void SaveQty()
        {
            //string tmpqty = this.txtbuqty.Text.Trim();
            if (strscanflag == "")
            {
                strscanflag = "1";
            }
            if (this.comboBox3.Text.Trim() == "")
            {
                MessageBox.Show("请选择采购单!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.textBox1.Text = "";
                this.comboBox3.Focus();
                return;
            }
            /*
            if (tmpqty == "")
            {
                MessageBox.Show("请输入出库数量", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            try
            {
                tmpqty = Convert.ToString(int.Parse(tmpqty) * int.Parse(strrate));
            }
            catch
            {
                MessageBox.Show("输入的数量不正确!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
             */
            
            string tmpnoinvqty = strnoinvqty;
            if (tmpnoinvqty == "")
            {
                tmpnoinvqty = "0";
            }
            if (int.Parse(tmpqty) > int.Parse(tmpnoinvqty))
            {
                MessageBox.Show("不能大于未入库数量!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            string strinvinsn = this.comboBox3.Text.Trim().Split(':')[1].Trim();
            string sql = "";
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            try
            {
                sql = "delete from tinvindetail ";
                sql += "  where pordersn = " + strinvinsn + " ";
                sql += "  and productsn = " + strprosn + " ";
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                cmd_scan.ExecuteNonQuery();

                sql = "insert into tinvindetail(pordersn,porderdsn,productsn,inbuqty,madeby,madeon,scanflag) values(";
                sql += "" + strinvinsn + ",";
                sql += "" + strporderdsn + ",";
                sql += "" + strprosn + ",";
                sql += "" + tmpqty + ",";
                sql += "" + CurrentUser.USERSN + ",";
                sql += " getdate(),'" + strscanflag + "')";
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                cmd_scan.ExecuteNonQuery();
                this.txtbuqty.Text = "";
                this.txtProductid.Text = "";
                this.txtProductid.Focus();


            }
            catch (Exception ex)
            {
                MessageBox.Show("保存时异常!" + sql + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            RefreshList(strinvinsn, strprosn);

        }

        private void frmChuKu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedIndices != null && listView1.SelectedIndices.Count > 0)
                {
                    string tmpprosn = this.listView1.Items[this.listView1.SelectedIndices[0]].SubItems[6].Text.ToString();
                    icur = this.listView1.SelectedIndices[0];
                    GetRelProInfo(strinvinsn, tmpprosn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void GetRelProInfo(string tmpordersn, string tmpprosn)
        {
            this.txtProductName.Text = "";
            this.txtBarcode.Text = "";
            this.txtRate.Text = "";

            if (conn_db.State != ConnectionState.Open)
            {
                conn_db.Open();
            }
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            if (tmpprosn == "")
            {
                return;
            }
            string sql0 = "select productname,rate,productsn,productid from tgoods where 1=1 ";
            sql0 += " and productsn = " + tmpprosn;
            string sql1 = "select barcode from tgoodsbar where productsn = " + tmpprosn;

            string sqlsys = "select orderqty,invedqty,noinvqty ,porderdsn from tporderdetail where pordersn =" + tmpordersn;
            sqlsys += " and productsn = " + tmpprosn;
            string tmpproductname = "";
            string tmpbarcode = "";
            string tmprate = "";
            string tmpsn = "";
            string tmpid = "";
            try
            {
                DataSet ds1 = new DataSet();
                ada_db = new SqlCeDataAdapter(sql0, conn_db);
                ada_db.Fill(ds1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    tmpproductname = ds1.Tables[0].Rows[0]["productname"].ToString();
                    tmprate = ds1.Tables[0].Rows[0]["rate"].ToString();
                    tmpsn = ds1.Tables[0].Rows[0]["productsn"].ToString();
                    tmpid = ds1.Tables[0].Rows[0]["productid"].ToString();

                    this.txtProductName.Text = tmpproductname;
                    this.txtRate.Text = tmprate;

                    DataSet dbar = new DataSet();
                    ada_db = new SqlCeDataAdapter(sql1, conn_db);
                    ada_db.Fill(dbar);
                    if (dbar != null && dbar.Tables[0].Rows.Count > 0)
                    {
                        tmpbarcode = dbar.Tables[0].Rows[0][0].ToString();
                    }
                    if (tmpbarcode != "")
                    {
                        this.txtBarcode.Text = tmpbarcode;
                    }

                    //
                }
                DataSet dsys = new DataSet();
                ada_scan = new SqlCeDataAdapter(sqlsys, conn_scan);
                ada_scan.Fill(dsys);
                if (dsys != null && dsys.Tables[0].Rows.Count > 0)
                {
                    string tmporderqty = dsys.Tables[0].Rows[0][0].ToString();
                    string tmpinvedqty = dsys.Tables[0].Rows[0][1].ToString();
                    string tmpnoinvqty = dsys.Tables[0].Rows[0][2].ToString();
                    string tmpporderdsn = dsys.Tables[0].Rows[0][3].ToString();
                }
                else
                {
                    MessageBox.Show("本采购单没有采购此商品!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询数据时异常! " + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }
        
    }
}