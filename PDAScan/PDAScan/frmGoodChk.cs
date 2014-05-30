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
    public partial class frmGoodChk : Form
    {
        SqlCeConnection conn_db = new SqlCeConnection();
        SqlCeConnection conn_scan = new SqlCeConnection();
        string _dbpath = @"Data Source=Application Data\PDADB.sdf";
        string _dbscan = @"Data Source=Application Data\PDAScan.sdf";
        SqlCeCommand cmd_scan = new SqlCeCommand();
        SqlCeCommand cmd_db = new SqlCeCommand();
        SqlCeDataAdapter ada_scan;
        SqlCeDataAdapter ada_db;
        string strprosn = "";
        public frmGoodChk()
        {
            InitializeComponent();
        }

       

        private void frmGoodChk_Load(object sender, EventArgs e)
        {
            try
            {
                conn_db.ConnectionString = _dbpath;
                conn_scan.ConnectionString = _dbscan;
                conn_scan.Open();
                conn_db.Open();
            }
            catch
            { }
            RefreshQty();
            this.txtBarcode.Focus();
            txtOutBarcode.Enabled = false;
            this.btnSave1.Enabled = false;
        }
        private void RefreshQty()
        {
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }

            string sql = "select count(productsn) from tgoodschk ";
            try
            {
                DataSet ds = new DataSet();
                ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    this.txtCnt.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    this.txtCnt.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询数据时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("您确认要清空?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            string sql = "delete from tgoodschk";
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                cmd_scan.ExecuteNonQuery();
                RefreshQty();
            }
            catch (Exception ex)
            {
                MessageBox.Show("清空时异常!" + sql + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void SetStas(bool br)
        {
            this.txtProductid.Enabled = br;
            this.txtBarcode2.Enabled = br;
            this.txtOutBarcode2.Enabled = br;
            this.btnSave2.Enabled = br;
        }

        private void txtBarcode_GotFocus(object sender, EventArgs e)
        {
            SetStas(false);
            this.txtOutBarcode.Text = "";
            this.txtOutBarcode.Enabled = false;
            this.btnSave1.Enabled = false;
            this.txtProductidInf.Text = "";
            this.txtProductNameInf.Text = "";
            this.txtRateInf.Text = "";
            this.txtBarcodeInf.Text = "";
            this.txtOutbarcodeInf.Text = "";
            this.txtBarcode.Text = "";
            this.txtProductid.Text = "";
            this.txtBarcode2.Text = "";
            this.txtOutBarcode2.Text = "";
            strprosn = "";
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                GetProductbyBar(this.txtBarcode.Text.Trim());
            }
        }
        private void GetProductbyBar(string _tmpbarcode)
        {
            this.txtProductidInf.Text = "";
            this.txtProductNameInf.Text = "";
            this.txtBarcodeInf.Text = "";
            this.txtRateInf.Text = "";
            this.txtOutbarcodeInf.Text = "";
            if (_tmpbarcode.Trim() == "")
            {
                return;
            }
            string sql = "select a.productid,a.productname,b.barcode,a.rate,a.productsn   from tgoods a,tgoodsbar b where a.productsn = b.productsn";
            sql += " and b.barcode ='" + _tmpbarcode + "'";
            if (conn_db.State != ConnectionState.Open)
            {
                conn_db.Open();
            }
            try
            {
                DataSet ds = new DataSet();
                ada_db = new SqlCeDataAdapter(sql, conn_db);
                ada_db.Fill(ds);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string tmpid = ds.Tables[0].Rows[0]["productid"].ToString();
                    string tmpproductname = ds.Tables[0].Rows[0]["productname"].ToString();
                    string tmpbarcode = ds.Tables[0].Rows[0]["barcode"].ToString().Trim();
                    string tmprate = ds.Tables[0].Rows[0]["rate"].ToString().Trim();
                    string tmpsn = ds.Tables[0].Rows[0]["productsn"].ToString().Trim();
                    strprosn = tmpsn;
                    //
                    string tmpoutbarcode = "";
                    string sqltmp = "select outbarcode from tgoodsoutbar where productsn = " + tmpsn;
                    DataSet dbar = new DataSet();
                    ada_db = new SqlCeDataAdapter(sqltmp, conn_db);
                    ada_db.Fill(dbar);
                    if (dbar != null && dbar.Tables[0].Rows.Count > 0)
                    {
                        tmpoutbarcode = dbar.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    //
                    this.txtProductidInf.Text = tmpid;
                    this.txtProductNameInf.Text = tmpproductname;
                    this.txtBarcodeInf.Text = tmpbarcode;
                    this.txtRateInf.Text = tmprate;
                    this.txtOutbarcodeInf.Text = tmpoutbarcode;
                    //
                    this.txtOutBarcode.Enabled = true;
                    this.btnSave1.Enabled = true;
                    this.txtOutBarcode.Focus();
               
                }
                else
                {
                    //没有找到商品信息
                    strprosn = "";
                    MessageBox.Show("没有找到商品信息!" , "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    
                    this.txtOutBarcode.Enabled = false;
                    this.btnSave1.Enabled = false;

                    this.txtProductid.Enabled = true;
                    this.txtBarcode2.Enabled = false;
                    this.txtOutBarcode2.Enabled = false;
                    this.btnSave2.Enabled = false;
                    this.txtProductid.Focus();
                }
            }
            catch (Exception ex)
            {
                strprosn = "";
                MessageBox.Show("查询商品信息时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
    
        }

        private void txtOutBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                this.btnSave1.Focus();
            }
        }

        private void txtProductid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                GetProductbyID(this.txtProductid.Text.Trim());
            }
        }
        private void GetProductbyID(string _tmpid)
        {
            this.txtProductidInf.Text = "";
            this.txtProductNameInf.Text = "";
            this.txtBarcodeInf.Text = "";
            this.txtRateInf.Text = "";
            this.txtOutbarcodeInf.Text = "";
            if (_tmpid.Trim() == "")
            {
                return;
            }
            string sql = "select a.productid,a.productname,a.rate,a.productsn   from tgoods a where ";
            sql += " a.productid ='" + _tmpid + "'";
            if (conn_db.State != ConnectionState.Open)
            {
                conn_db.Open();
            }
            try
            {
                DataSet ds = new DataSet();
                ada_db = new SqlCeDataAdapter(sql, conn_db);
                ada_db.Fill(ds);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string tmpid = ds.Tables[0].Rows[0]["productid"].ToString();
                    string tmpproductname = ds.Tables[0].Rows[0]["productname"].ToString();
                    //string tmpbarcode = ds.Tables[0].Rows[0]["barcode"].ToString().Trim();
                    string tmprate = ds.Tables[0].Rows[0]["rate"].ToString().Trim();
                    string tmpsn = ds.Tables[0].Rows[0]["productsn"].ToString().Trim();
                    strprosn = tmpsn;
                    string tmpbarcode = "";
                    string sqlbar = "select barcode from tgoodsbar where productsn =" + tmpsn;
                    DataSet db = new DataSet();
                    ada_db = new SqlCeDataAdapter(sqlbar, conn_db);
                    ada_db.Fill(db);
                    if (db != null && db.Tables[0].Rows.Count > 0)
                    {
                        tmpbarcode = db.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    
                    //
                    string tmpoutbarcode = "";
                    string sqltmp = "select outbarcode from tgoodsoutbar where productsn = " + tmpsn;
                    DataSet dbar = new DataSet();
                    ada_db = new SqlCeDataAdapter(sqltmp, conn_db);
                    ada_db.Fill(dbar);
                    if (dbar != null && dbar.Tables[0].Rows.Count > 0)
                    {
                        tmpoutbarcode = dbar.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    //
                    this.txtProductidInf.Text = tmpid;
                    this.txtProductNameInf.Text = tmpproductname;
                    this.txtBarcodeInf.Text = tmpbarcode;
                    this.txtRateInf.Text = tmprate;
                    this.txtOutbarcodeInf.Text = tmpoutbarcode;
                    //
                    this.txtBarcode2.Enabled = true;
                    this.txtBarcode2.Text = "";
                    this.txtOutBarcode2.Enabled = true;
                    this.btnSave2.Enabled = true;
                    this.txtBarcode2.Focus();

                }
                else
                {
                    strprosn = "";
                    //没有找到商品信息
                    MessageBox.Show("没有找到商品信息!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.txtBarcode2.Enabled = false;
                    this.txtOutBarcode2.Enabled = false;
                    this.btnSave2.Enabled = false;

                    this.txtProductid.Enabled = true;
                    this.txtProductid.Focus();
                }
            }
            catch (Exception ex)
            {
                strprosn = "";
                MessageBox.Show("查询商品信息时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtBarcode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                if (this.txtBarcode2.Text.Trim() != "")
                {
                    this.txtOutBarcode2.Text = "";
                    this.txtOutBarcode2.Focus();
                }
            }
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (this.txtOutBarcode.Text.Trim() != "")
            {
                 if (this.txtOutBarcode.Text.Trim() == this.txtOutbarcodeInf.Text.Trim())
                {
                    MessageBox.Show("外箱条码正确不需要采集!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    this.txtOutBarcode.Text = "";
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Focus();
                    return;
                }

            }
            else
            {
                MessageBox.Show("请采集外箱条码!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtOutBarcode.Focus();
                return;

            }
            
            //保存操作
            string tmpbarcode = this.txtBarcode.Text.Trim();
            string tmpoutbarcode = this.txtOutBarcode.Text.Trim();
            string tmpoldbarcode = this.txtBarcodeInf.Text.Trim();
            string tmpoldoutbarcode = this.txtOutbarcodeInf.Text.Trim();
             
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            if (strprosn == "")
            {
                return;
            }
            string sql0 = "delete from tgoodschk where productsn ="+ strprosn;
            string sql1 = "insert into tgoodschk(productsn,oldbarcode,oldoutbarcode,barcode,outbarcode,madeby,madeon) values(";
            sql1 += " " + strprosn + ",";
            sql1 += "'" + tmpoldbarcode + "',";
            sql1 += "'" + tmpoldoutbarcode + "',";
            sql1 += "'" + tmpbarcode + "',";
            sql1 += "'" + tmpoutbarcode + "',";
            sql1 += " " + CurrentUser.USERSN + ",";
            sql1 += "  getdate())";
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql0;
                cmd_scan.ExecuteNonQuery();
                cmd_scan.CommandText = sql1;
                cmd_scan.ExecuteNonQuery();
                RefreshQty();
                this.txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存时异常!" + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSave1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                btnSave1_Click(this.btnSave1, e);
            }
        }

        private void btnSave1_GotFocus(object sender, EventArgs e)
        {
            this.btnSave1.ForeColor = Color.Red;
        }

        private void btnSave1_LostFocus(object sender, EventArgs e)
        {
            this.btnSave1.ForeColor = Color.Black;
        }

        private void txtOutBarcode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                this.btnSave2.Focus();
            }
        }

        private void btnSave2_GotFocus(object sender, EventArgs e)
        {
            this.btnSave2.ForeColor = Color.Red;
        }

        private void btnSave2_LostFocus(object sender, EventArgs e)
        {
            this.btnSave2.ForeColor = Color.Black;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (!(this.txtBarcode2.Text.Trim() == "" && this.txtOutBarcode2.Text.Trim() == ""))
            {
                if (this.txtBarcodeInf.Text.Trim() == this.txtBarcode2.Text.Trim() && this.txtOutbarcodeInf.Text.Trim() == this.txtOutBarcode2.Text.Trim())
                {
                    MessageBox.Show("条码正确,此商品不需要采集!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Focus();
                    return;
                }
                if (this.txtBarcodeInf.Text.Trim() != "" && this.txtBarcode2.Text.Trim() == "")
                {
                    MessageBox.Show("商品条码必须采集!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.txtBarcode2.Focus();
                    return;
                }
                if (this.txtOutbarcodeInf.Text.Trim() != "" && this.txtOutBarcode2.Text.Trim() == "")
                {
                    MessageBox.Show("商品外箱条码必须采集!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.txtOutBarcode2.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("请采集商品条码信息!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtBarcode2.Focus();
                return;
            }
            //开始保存
            string tmpbarcode = this.txtBarcode2.Text.Trim();
            string tmpoutbarcode = this.txtOutBarcode2.Text.Trim();
            string tmpoldbarcode = this.txtBarcodeInf.Text.Trim();
            string tmpoldoutbarcode = this.txtOutbarcodeInf.Text.Trim();

            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            if (strprosn == "")
            {
                return;
            }
            string sql0 = "delete from tgoodschk where productsn =" + strprosn;
            string sql1 = "insert into tgoodschk(productsn,oldbarcode,oldoutbarcode,barcode,outbarcode,madeby,madeon) values(";
            sql1 += " " + strprosn + ",";
            sql1 += "'" + tmpoldbarcode + "',";
            sql1 += "'" + tmpoldoutbarcode + "',";
            sql1 += "'" + tmpbarcode + "',";
            sql1 += "'" + tmpoutbarcode + "',";
            sql1 += " " + CurrentUser.USERSN + ",";
            sql1 += "  getdate())";
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql0;
                cmd_scan.ExecuteNonQuery();
                cmd_scan.CommandText = sql1;
                cmd_scan.ExecuteNonQuery();
                RefreshQty();
                this.txtBarcode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存时异常!" + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnSave2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                btnSave2_Click(this.btnSave2, e);
            }
        }

        private void txtProductid_GotFocus(object sender, EventArgs e)
        {
            this.txtProductidInf.Text = "";
            this.txtProductNameInf.Text = "";
            this.txtRateInf.Text = "";
            this.txtBarcodeInf.Text = "";
            this.txtOutbarcodeInf.Text = "";
            this.txtProductid.Text = "";
            this.txtBarcode2.Text = "";
            this.txtOutBarcode2.Text = "";
            strprosn = "";
        }

        private void frmGoodChk_Closing(object sender, CancelEventArgs e)
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

        private void frmGoodChk_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Focus();
                    break;
                case Keys.F1:
                    this.txtOutBarcode.Enabled = false;
                    this.btnSave1.Enabled = false;
                    this.txtProductid.Enabled = true;
                    this.txtBarcode2.Enabled = false;
                    this.txtOutBarcode2.Enabled = false;
                    this.btnSave2.Enabled = false;
                    this.txtProductid.Focus();
                    break;
                case Keys.F4:
                    if (this.txtOutBarcode2.Enabled == true)
                    {
                        this.txtOutBarcode2.Text = this.txtOutbarcodeInf.Text.Trim();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}