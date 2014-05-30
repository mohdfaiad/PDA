using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
namespace PDAScan
{
    public partial class frmInvChk : Form
    {
        SqlCeConnection conn_db = new SqlCeConnection();
        SqlCeConnection conn_scan = new SqlCeConnection();
        string _dbpath = @"Data Source=Application\db\PDADB.sdf";
        string _dbscan = @"Data Source=Application\db\PDAScan.sdf";
        SqlCeCommand cmd_scan = new SqlCeCommand();
        SqlCeDataAdapter ada_db ;
        SqlCeDataAdapter ada_scan ;
        //
        string strinvchksn = "";
        string strprosn = "";
        string strrate = "";
        public frmInvChk()
        {
            InitializeComponent();       

        }

        private void frmInvChk_Load(object sender, EventArgs e)
        {
            try
            {
                conn_db.ConnectionString = _dbpath;
                conn_scan.ConnectionString = _dbscan;
                conn_db.Open();
                conn_scan.Open();
                InitWare();
                InitInvchkid("");
            }
            catch
            { }
        }
        private void InitWare()
        {
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            string sql = "select distinct warename from tinvchk ";

            try
            {
                DataSet ds = new DataSet();
                ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                cmbWare.Items.Clear();
                cmbWare.Items.Add(" ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int icnt = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < icnt; i++)
                    {
                        cmbWare.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                }
            }
            catch { }
             
        }
        private void InitInvchkid(string warename)
        {
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            string sql = "select invchkid ,ghinvchksn from tinvchk where 1=1  ";
            if (warename != "")
            {
                sql += " and warename = '" + warename + "'";
            }
            sql += " order by invchkid ";
            try
            {
                DataSet ds = new DataSet();
                ada_scan  = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                this.cmbInvchk.Items.Clear();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int icnt = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < icnt; i++)
                    {
                        cmbInvchk.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "                           :" + ds.Tables[0].Rows[i][1].ToString());
                    }
                }
            }
            catch { }
        }

        private void frmInvChk_Closing(object sender, CancelEventArgs e)
        {
            if (conn_db.State == ConnectionState.Open)
            {
                conn_db.Close();
            }
            if (conn_scan.State == ConnectionState.Open)
            {
                conn_scan.Close();
            }
               
        }

        private void cmbWare_SelectedValueChanged(object sender, EventArgs e)
        {
            InitInvchkid(cmbWare.Text.Trim());
        }

     

        private void txtProductid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13 )
            {
                GetProduct(this.txtProductid.Text.Trim());
                RefreshList(strinvchksn, strprosn);
            }
           
        }
        private void GetProduct(string tmp)
        {
            this.txtProductName.Text = "";
            this.txtBarcode.Text = "";
            this.txtRate.Text = "";
            this.txtSumChkQty.Text = "";
            this.txtSysqty.Text = "";
            //lblMsg.Text = "";
            this.lvChkQty.Items.Clear();
            strprosn = "";
            strrate = "";
            if (conn_db.State != ConnectionState.Open)
            {
                conn_db.Open();
            }
            if (tmp == "")
            {
                return;
            }
            string sql1 = "select a.productname,b.barcode,a.rate,a.productsn,a.productid from tgoods a,tgoodsbar b where a.productsn = b.productsn ";
            sql1 += " and b.barcode = '" + tmp + "'";
            string sql2 = "select productname,rate,productsn,productid from tgoods where productid ='" + tmp + "'";
            string sql3 = "select a.productname,a.rate,a.productsn,a.productid from tgoods a,tgoodsoutbar b where a.productsn = b.productsn  and b.outbarcode ='" + tmp + "'";

            string tmpproductname = "";
            string tmpbarcode = "";
            string tmprate = "";
            string tmpsn = "";
            string tmpid = "";
            try
            {
                DataSet ds1 = new DataSet();
                ada_db = new SqlCeDataAdapter(sql1, conn_db);
                ada_db.Fill(ds1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    tmpproductname = ds1.Tables[0].Rows[0]["productname"].ToString();
                    tmpbarcode = ds1.Tables[0].Rows[0]["barcode"].ToString();
                    tmprate = ds1.Tables[0].Rows[0]["rate"].ToString().Trim();
                    tmpsn = ds1.Tables[0].Rows[0]["productsn"].ToString();
                    this.txtProductName.Text = tmpproductname;
                    if (tmpbarcode != "")
                    {
                        this.txtBarcode.Text = tmpbarcode;
                    }
                    this.txtRate.Text = tmprate;
                    strprosn = tmpsn;
                    strrate = "1";
                    //lblMsg.Text = "__*1";
                    this.txtchkqty.Enabled = true;
                    this.txtchkqty.Focus();
                    this.txtchkqty.SelectAll();
                    this.btnSave.Enabled = true;

                }
                else
                {
                    DataSet ds2 = new DataSet();
                    ada_db = new SqlCeDataAdapter(sql2, conn_db);
                    ada_db.Fill(ds2);
                    if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
                    {
                        tmpproductname = ds2.Tables[0].Rows[0]["productname"].ToString();
                        tmprate = ds2.Tables[0].Rows[0]["rate"].ToString();
                        tmpsn = ds2.Tables[0].Rows[0]["productsn"].ToString();
                        tmpid = ds2.Tables[0].Rows[0]["productid"].ToString();
                        //
                        string tmpsql = "select barcode from tgoodsbar where productsn =" + tmpsn;
                        DataSet dbar= new DataSet();
                        ada_db = new SqlCeDataAdapter(tmpsql, conn_db);
                        ada_db.Fill(dbar);
                        if (dbar != null && dbar.Tables[0].Rows.Count > 0)
                        {
                            tmpbarcode = dbar.Tables[0].Rows[0]["barcode"].ToString();
                        }
                        this.txtProductName.Text = tmpproductname;
                        this.txtBarcode.Text = tmpbarcode;
                        this.txtRate.Text = tmprate;

                        //
                        strprosn = tmpsn;
                        strrate = "1";
                        //lblMsg.Text = "__*1";
                        this.txtchkqty.Enabled = true;
                        this.txtProductid.Text = tmpid;
                        this.txtchkqty.Focus();
                        this.txtchkqty.SelectAll();
                        this.btnSave.Enabled = true;
                    }
                    else
                    {
                        DataSet ds3 = new DataSet();
                        ada_db = new SqlCeDataAdapter(sql3, conn_db);
                        ada_db.Fill(ds3);
                        if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
                        {
                            tmpproductname = ds3.Tables[0].Rows[0]["productname"].ToString();
                            tmprate = ds3.Tables[0].Rows[0]["rate"].ToString();
                            tmpsn = ds3.Tables[0].Rows[0]["productsn"].ToString();
                            tmpid = ds3.Tables[0].Rows[0]["productid"].ToString();
                            string tmpsql3 = "select barcode from tgoodsbar where productsn =" + tmpsn;
                            DataSet dbar3 = new DataSet();
                            ada_db = new SqlCeDataAdapter(tmpsql3, conn_db);
                            ada_db.Fill(dbar3);
                            if (dbar3 != null && dbar3.Tables[0].Rows.Count > 0)
                            {
                                tmpbarcode = dbar3.Tables[0].Rows[0]["barcode"].ToString();
                            }
                            this.txtProductName.Text = tmpproductname;
                            this.txtBarcode.Text = tmpbarcode;     
                            this.txtRate.Text = tmprate;
                            //
                            strprosn = tmpsn;
                            strrate = tmprate;
                            //lblMsg.Text = "__*" + tmprate;
                            this.txtchkqty.Enabled = true;
                            this.txtProductid.Text = tmpid;
                            this.txtchkqty.Focus();
                            this.txtchkqty.SelectAll();
                            this.btnSave.Enabled = true;
                        }
                        else
                        {
                            this.txtchkqty.Enabled = false;
                            this.txtProductid.Focus();
                            this.txtProductid.SelectAll();
                            this.btnSave.Enabled = false;
                            MessageBox.Show("没有找到商品信息!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }

            }
            catch
            {
                strprosn = "";
                strrate = "";
            }
        }
        

        private void txtchkqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' || e.KeyChar == '\x0d' || e.KeyChar == '\x08'))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == false)
            {
                return;
            }
            string tmpqty = this.txtchkqty.Text.Trim();

            if (this.cmbInvchk.Text.Trim() == "")
            {
                MessageBox.Show("请选择盘点单!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtProductid.Text = "";
                this.cmbInvchk.Focus();
                return;
            }
            if (tmpqty == "")
            {
                MessageBox.Show("请输入盘点数量", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            //lblMsg.Text = tmpqty + " * " + strrate;
            try
            {
                tmpqty = Convert.ToString(int.Parse(tmpqty) * int.Parse(strrate));
            }
            catch
            {
                MessageBox.Show("输入的数量不正确!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            string strinvchksn = this.cmbInvchk.Text.Trim().Split(':')[1].Trim();
            string sql = "insert into tinvchkdetail(ghinvchksn,productsn,chkbuqty,madeby,madeon) values(" ;
            sql += "" + strinvchksn + ",";
            sql += "" + strprosn + ",";
            sql += "" + tmpqty + ",";
            sql += "" + CurrentUser.USERSN + ",";
            sql += " getdate())";
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                cmd_scan.ExecuteNonQuery();
                this.txtchkqty.Text = "";
                this.txtProductid.Text = "";
                this.txtProductid.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存时异常!" + sql + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            RefreshList(strinvchksn, strprosn);
        }
        private void RefreshList(string tmpsn,string tmpproductsn)
        {
            this.lvChkQty.Items.Clear();
            if (tmpsn == "" || tmpproductsn == "")
            {
                return;
            }
            string sql = "select chkbuqty from tinvchkdetail where ghinvchksn =" + tmpsn + " and productsn = "+ tmpproductsn;
            sql += " order by ghinvchkdsn desc";
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            string sqlsys = "select sysbuqty from tinvsysdetail where ghinvchksn =" + tmpsn + " and productsn = " + tmpproductsn;

            try
            {
                DataSet ds = new DataSet();
                ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                DataSet dsys = new DataSet();
                ada_scan = new SqlCeDataAdapter(sqlsys, conn_scan);
                ada_scan.Fill(dsys);
                int sumqty = 0;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int icnt = ds.Tables[0].Rows.Count;

                    for (int i = 0; i < icnt; i++)
                    {
                        ListViewItem lvt = new ListViewItem();
                        lvt.SubItems.Add(ds.Tables[0].Rows[i][0].ToString());
                        lvChkQty.Items.Add(lvt);
                        sumqty = sumqty + int.Parse(ds.Tables[0].Rows[i][0].ToString());
                       
                    }
                    txtSumChkQty.Text = sumqty.ToString();
                }
                else
                {
                    txtSumChkQty.Text = "";
                }
                if (dsys != null && dsys.Tables[0].Rows.Count > 0)
                {
                    string tmpsysqty = dsys.Tables[0].Rows[0][0].ToString();
                    this.txtSysqty.Text = tmpsysqty;
                }
                else
                {
                    this.txtSysqty.Text = "0";
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("刷新时异常!" + sql + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

        }
        private void txtProductid_GotFocus(object sender, EventArgs e)
        {
            this.txtchkqty.Text = "";
            this.lvChkQty.Items.Clear();
           
            this.txtchkqty.Enabled = false;
            this.btnSave.Enabled = false;
            if (this.cmbInvchk.Text.Trim() == "")
            {
                this.txtProductid.Text = "";
                this.cmbInvchk.Focus();
                return;
            }
        }

        private void txtchkqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this.btnSave, e);
            }
        }

        private void cmbInvchk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInvchk.Text.Trim() != "")
            {
                strinvchksn = cmbInvchk.Text.Trim().Split(':')[1].Trim();
                this.txtProductid.Focus();
                this.txtProductid.Text = "";
            }
            else
            {
                strinvchksn = "";
            }
            this.lvChkQty.Items.Clear();
        }

        private void frmInvChk_KeyDown(object sender, KeyEventArgs e)
        {
            if (strinvchksn == "")
            {
                this.txtProductid.Text = "";
                this.cmbInvchk.Focus();
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.txtProductid.Text = "";
                    this.txtProductid.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}