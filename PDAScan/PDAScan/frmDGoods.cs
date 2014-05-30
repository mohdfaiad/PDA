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
    public partial class frmDGoods : Form
    {
        SqlCeConnection conn_db = new SqlCeConnection();
        SqlCeConnection conn_scan = new SqlCeConnection();
        string _dbpath = @"Data Source=Application Data\PDADB.sdf";
        string _dbscan = @"Data Source=Application Data\PDAScan.sdf";
        SqlCeCommand cmd_scan = new SqlCeCommand();
        SqlCeDataAdapter ada_db;
        SqlCeDataAdapter ada_scan;
        //
        string strDGoodssn = "";
        string strprosn = "";
        string strrate = "";
        string strscanflag = "";
        public frmDGoods()
        {
            InitializeComponent();
        }

        private void frmDGoods_Load(object sender, EventArgs e)
        {
            try
            {
                conn_db.ConnectionString = _dbpath;
                conn_scan.ConnectionString = _dbscan;
                conn_db.Open();
                conn_scan.Open();
                InitWare();
                InitDGoodsid("");
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
            string sql = "select distinct warename from tdgoods ";

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
        private void InitDGoodsid(string warename)
        {
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            string sql = "select dgoodsid ,dgoodssn from tdgoods where flag='0'  ";
            if (warename != "")
            {
                sql += " and warename = '" + warename + "'";
            }
            sql += " order by dgoodsid ";
            try
            {
                DataSet ds = new DataSet();
                ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                this.cmbDGoodsId.Items.Clear();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int icnt = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < icnt; i++)
                    {
                        cmbDGoodsId.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "                           :" + ds.Tables[0].Rows[i][1].ToString());
                    }
                }
            }
            catch { }
        }

        private void frmDGoods_Closing(object sender, CancelEventArgs e)
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
            InitDGoodsid(cmbWare.Text.Trim());
        }

        private void GetProduct(string tmp)
        {
            strscanflag = "";
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
                    tmpid = ds1.Tables[0].Rows[0]["productid"].ToString();
                    this.txtProductName.Text = tmpproductname;
                    if (tmpbarcode != "")
                    {
                        this.txtBarcode.Text = tmpbarcode;
                    }
                    this.txtRate.Text = tmprate;
                    this.txtProductid.Text = tmpid;
                    strprosn = tmpsn;
                    strrate = "1";
                    //lblMsg.Text = "__*1";
                    this.txtchkqty.Focus();
                    this.txtchkqty.SelectAll();
                    this.txtchkqty.ReadOnly = true;
                    this.btnSave.Enabled = true;
                    strscanflag = "1";

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
                        DataSet dbar = new DataSet();
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
                        this.txtchkqty.ReadOnly = false;
                        this.txtProductid.Text = tmpid;
                        this.txtchkqty.Focus();
                        this.txtchkqty.SelectAll();
                        this.btnSave.Enabled = true;
                        strscanflag = "2";
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
                            this.txtchkqty.ReadOnly = true;
                            this.txtProductid.Text = tmpid;
                            this.txtchkqty.Focus();
                            this.txtchkqty.SelectAll();
                            this.btnSave.Enabled = true;
                            strscanflag = "3";
                        }
                        else
                        {
                            this.txtchkqty.ReadOnly = true;
                            this.txtchkqty.Text = "1";
                            this.txtProductid.Focus();
                            this.txtProductid.SelectAll();
                            this.btnSave.Enabled = false;
                            strscanflag = "";
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
        private void RefreshList(string tmpsn, string tmpproductsn)
        {
            this.lvChkQty.Items.Clear();
            if (tmpsn == "" || tmpproductsn == "")
            {
                return;
            }
            string sql = "select chkbuqty from tdgoodsdetail where dgoodssn =" + tmpsn + " and productsn = " + tmpproductsn;
            sql += " order by dgoodsdsn desc";
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            string sqlsys = "select rdgoodsbuqty from tdgoodsdetailreal where dgoodssn =" + tmpsn + " and productsn = " + tmpproductsn;

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
            catch (Exception ex)
            {
                MessageBox.Show("刷新时异常!" + sql + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void cmbDGoodsId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDGoodsId.Text.Trim() != "")
            {
                this.strDGoodssn = cmbDGoodsId.Text.Trim().Split(':')[1].Trim();
                this.txtProductid.Focus();
                this.txtProductid.Text = "";
            }
            else
            {
                strDGoodssn = "";
            }
            this.lvChkQty.Items.Clear();
        }

        private void txtProductid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                GetProduct(this.txtProductid.Text.Trim());
                RefreshList(this.strDGoodssn, strprosn);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == false)
            {
                return;
            }
            string tmpqty = this.txtchkqty.Text.Trim();

            if (this.cmbDGoodsId.Text.Trim() == "")
            {
                MessageBox.Show("请选择送货单!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtProductid.Text = "";
                this.cmbDGoodsId.Focus();
                return;
            }
            if (tmpqty == "")
            {
                MessageBox.Show("请输入数量", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            //lblMsg.Text = tmpqty + " * " + strrate;
            try
            {
                tmpqty = Convert.ToString(int.Parse(tmpqty) * int.Parse(strrate));
                string tmpsumchk = (this.txtSumChkQty.Text.Trim() == "" ? "0" : this.txtSumChkQty.Text.Trim());
                string tmpcomp = this.txtSysqty.Text.Trim();
                int itmpsumchk = int.Parse(tmpqty) + int.Parse(tmpsumchk);
                int tmp = itmpsumchk - int.Parse(tmpcomp);
                if (tmp >0) 
                {
                    MessageBox.Show("输入数量合计不能大于送货单数量!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("输入的数量不正确!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            string strdgoodssn = this.cmbDGoodsId.Text.Trim().Split(':')[1].Trim();
            string sql = "insert into tdgoodsdetail(dgoodssn,productsn,chkbuqty,madeby,madeon,scanflag) values(";
            sql += "" + strdgoodssn + ",";
            sql += "" + strprosn + ",";
            sql += "" + tmpqty + ",";
            sql += "" + CurrentUser.USERSN + ",";
            sql += " getdate(),";
            sql += "'" + strscanflag + "')";
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
            RefreshList(strdgoodssn, strprosn);
        }

        private void txtchkqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' || e.KeyChar == '\x0d' || e.KeyChar == '\x08'))
            {
                e.Handled = true;
            }
        }

        private void txtchkqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this.btnSave, e);
            }
            
        }

        private void txtProductid_GotFocus(object sender, EventArgs e)
        {
            this.txtchkqty.ReadOnly = true;
            this.txtchkqty.Text = "1";
            this.lvChkQty.Items.Clear();
            this.btnSave.Enabled = false;
            if (this.cmbDGoodsId.Text.Trim() == "")
            {
                this.txtProductid.Text = "";
                this.cmbDGoodsId.Focus();
                return;
            }
        }

        private void frmDGoods_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.strDGoodssn == "")
            {
                this.txtProductid.Text = "";
                this.cmbDGoodsId.Focus();
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    this.txtProductid.Text = "";
                    this.txtProductid.Focus();
                    break;
                case Keys.F10:
                    if (this.txtchkqty.ReadOnly == false)
                    {
                        this.txtchkqty.Text = "-";
                    }
                    break;
                case Keys.F9:
                    if (this.txtchkqty.ReadOnly == false)
                    {
                        this.txtchkqty.Text = "";
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnCy_Click(object sender, EventArgs e)
        {
            if (this.strDGoodssn == "")
            {
                return;
            }
            frmDGoodsDiff fd = new frmDGoodsDiff(this.strDGoodssn);
            fd.ShowDialog();
        }

        private void btnReChk_Click(object sender, EventArgs e)
        {
            if (this.strDGoodssn == "")
            {
                return;
            }
            DialogResult dr = MessageBox.Show("您确认要重盘,确定后本次盘点数据将被清空!", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            string sql = "delete from tdgoodsdetail where dgoodssn=" + this.strDGoodssn;
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                cmd_scan.ExecuteNonQuery();
                conn_scan.Close();
                MessageBox.Show("清除完成!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("清空数据时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnWc_Click(object sender, EventArgs e)
        {
            if (this.strDGoodssn == "")
            {
                return;
            }
            DialogResult dr = MessageBox.Show("您确认要完成,确定后本张单子不能再修改!", "提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            string sql = "update tdgoods set flag ='1' where dgoodssn=" + this.strDGoodssn;
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                cmd_scan.ExecuteNonQuery();
                conn_scan.Close();
                MessageBox.Show("完成成功!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("完成操作时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            InitDGoodsid(cmbWare.Text.Trim());
            this.strDGoodssn = "";
            this.cmbDGoodsId.SelectedIndex = -1;

        }
    }
}