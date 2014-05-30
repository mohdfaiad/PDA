using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
namespace PDAScan
{
    public partial class frmDGoodsDiff : Form
    {
        SqlCeConnection conn_db = new SqlCeConnection();
        SqlCeConnection conn_scan = new SqlCeConnection();
        string _dbpath = @"Data Source=Application Data\PDADB.sdf";
        string _dbscan = @"Data Source=Application Data\PDAScan.sdf";
        SqlCeCommand cmd_scan = new SqlCeCommand();
        string strselsn = "";
        public frmDGoodsDiff(string _selsn)
        {
            InitializeComponent();
            strselsn = _selsn;
        }

        private void frmDGoodsDiff_Load(object sender, EventArgs e)
        {
            try
            {
                conn_db.ConnectionString = _dbpath;
                conn_scan.ConnectionString = _dbscan;
                conn_db.Open();
                conn_scan.Open();
                GetDiff();
            }
            catch
            { }
        }
        private void GetDiff()
        {
            if (strselsn == "")
            {
                return;
            }
            string sql1 = "select productsn,sum(chkbuqty) chkbuqty   from tdgoodsdetail where dgoodssn = " + strselsn;
            sql1 += " group by productsn ";
            string sql2 = " select productsn,rdgoodsbuqty from tdgoodsdetailreal where  dgoodssn = " + strselsn;
            try
            {
                if (conn_scan.State != ConnectionState.Open)
                {
                    conn_scan.Open();
                }
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();

                SqlCeDataAdapter ada1 = new SqlCeDataAdapter(sql1, conn_scan);
                ada1.Fill(ds1);
                SqlCeDataAdapter ada2 = new SqlCeDataAdapter(sql2, conn_scan);
                ada2.Fill(ds2);
                conn_scan.Close();
                //执行比对
                ArrayList al = new ArrayList();
                if (ds1 != null && ds2 != null && ds1.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    int icnt1 = ds1.Tables[0].Rows.Count;
                    int icnt2 = ds2.Tables[0].Rows.Count;
                    for (int i = 0; i < icnt2; i++)
                    {
                        string tmpproductsn2 = ds2.Tables[0].Rows[i][0].ToString();
                        string tmpqty2 = ds2.Tables[0].Rows[i][1].ToString();
                        bool br = false;
                        for (int j = 0; j < icnt1; j++)
                        {
                            string tmpproductsn1 = ds1.Tables[0].Rows[j][0].ToString();
                            string tmpqty1 = ds1.Tables[0].Rows[j][1].ToString();
                            if (tmpproductsn1 == tmpproductsn2)
                            {
                                if (tmpqty1 != tmpqty2)
                                {
                                    string[] tmpdiff = new string[5];
                                    tmpdiff[0] = tmpproductsn2;
                                    tmpdiff[1] = tmpqty1;
                                    tmpdiff[2] = tmpqty2;
                                    tmpdiff[3] = "";
                                    tmpdiff[4] = "";
                                    al.Add(tmpdiff);
                                }
                                br = true;
                                break;
                            }
                        }
                        if (br == false)
                        {
                            string[] tmpdiffs = new string[5];
                            tmpdiffs[0] = tmpproductsn2;
                            tmpdiffs[1] = "0";
                            tmpdiffs[2] = tmpqty2;
                            tmpdiffs[3] = "";
                            tmpdiffs[4] = "";
                            al.Add(tmpdiffs);
                        }
                    }
                    //
                    if (al.Count > 0)
                    {
                        string tmpsn = "";
                        for (int i = 0; i < al.Count; i++)
                        {
                            string[] tmps = (string[])al[i];
                            tmpsn += tmps[0] + ",";
                        }
                        tmpsn = tmpsn.Substring(0, tmpsn.Length - 1);
                        string sql_db = "select productsn,productid,productname from tgoods where productsn in (" + tmpsn + ")";

                        if (conn_db.State != ConnectionState.Open)
                        {
                            conn_db.Open();
                        }
                        DataSet ds_db = new DataSet();
                        SqlCeDataAdapter ada_db = new SqlCeDataAdapter(sql_db, conn_db);
                        ada_db.Fill(ds_db);
                        conn_db.Close();
                        //
                        if (ds_db != null && ds_db.Tables[0].Rows.Count > 0)
                        {
                            int idbcnt = ds_db.Tables[0].Rows.Count;
                            for (int i = 0; i < al.Count; i++)
                            {
                                string[] tmpdiff = (string[])al[i];
                                for (int j = 0; j < ds_db.Tables[0].Rows.Count; j++)
                                {
                                    if (tmpdiff[0] == ds_db.Tables[0].Rows[j][0].ToString())
                                    {
                                        tmpdiff[3] = ds_db.Tables[0].Rows[j][1].ToString();
                                        tmpdiff[4] = ds_db.Tables[0].Rows[j][2].ToString();
                                        al[i] = tmpdiff;
                                        break;
                                    }
                                }
                            }
                            //listdata
                            for (int i = 0; i < al.Count; i++)
                            {
                                string[] tmps = (string[])al[i];
                                string strproductid = tmps[3];
                                string strproductname = tmps[4];
                                string strchkbuqty = tmps[1];
                                string strdgoodsbuqty = tmps[2];
                                string strdiff = "";
                                try
                                {
                                    strdiff = Convert.ToString(int.Parse(strdgoodsbuqty) - int.Parse(strchkbuqty));
                                }
                                catch
                                { }
                                ListViewItem lvt = new ListViewItem();
                                lvt.SubItems.Add(strproductid);
                                lvt.SubItems.Add(strdgoodsbuqty);
                                lvt.SubItems.Add(strchkbuqty);
                                lvt.SubItems.Add(strdiff);
                                lvt.SubItems.Add(strproductname);
                                this.lvdiff.Items.Add(lvt);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("单子没有差异!" , "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("单子没有盘点数据!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                if (conn_scan.State == ConnectionState.Open)
                {
                    conn_scan.Close();
                }
                if (conn_db.State == ConnectionState.Open)
                {
                    conn_db.Close();
                }
                MessageBox.Show("查询数据异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void lvdiff_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index != -1)
            {
                string tmp = lvdiff.Items[e.Index].SubItems[5].Text.Trim();
                this.label1.Text = tmp;
            }
            for (int i = 0; i < lvdiff.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    lvdiff.Items[i].Checked = false;
                }
            }
        }
    }
}