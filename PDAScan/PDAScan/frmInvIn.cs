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
    public partial class frmInvIn : Form
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
        public frmInvIn()
        {
            InitializeComponent();
        }

        private void SaveQty()
        {

            string tmpqty = this.txtbuqty.Text.Trim();
            if (strscanflag == "")
            {
                strscanflag = "1";
            }
            if (this.cmbPordercode.Text.Trim() == "")
            {
                MessageBox.Show("请选择采购单!", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                this.txtProductid.Text = "";
                this.cmbPordercode.Focus();
                return;
            }
            if (tmpqty == "")
            {
                MessageBox.Show("请输入入库数量", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
            string strinvinsn = this.cmbPordercode.Text.Trim().Split(':')[1].Trim();
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
                //
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
                //
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存时异常!" + sql + ":" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            RefreshList(strinvinsn, strprosn);
         
        }


        private void RefreshList(string tmpsn ,string tmproductsn)
        {
            strnoinvqty = "0";
            strporderdsn = "";
            if (tmpsn == "" || tmproductsn == "" )
            {
                return;
            }
            string sql = "select inbuqty from tinvindetail where pordersn =" + tmpsn;
            sql += " and productsn = " + tmproductsn;
            string sqlno = "select noinvqty,porderdsn from tporderdetail where pordersn =" + tmpsn;
            sqlno += " and productsn = " + tmproductsn;
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            try
            {
                cmd_scan.Connection = conn_scan;
                cmd_scan.CommandText = sql;
                SqlCeDataReader read = cmd_scan.ExecuteReader();
                cmd_scan.CommandText = sqlno;
                SqlCeDataReader readno = cmd_scan.ExecuteReader();
                if (readno.Read())
                {
                    strnoinvqty = readno[0].ToString();
                    strporderdsn = readno[1].ToString();
                }
                //
                if (read.Read())
                {
                    string _qty = read[0].ToString();
                    //
                    for (int i = 0; i < lvInvIn.Items.Count; i++)
                    {
                        string _sn = lvInvIn.Items[i].SubItems[6].Text.Trim();
                        if (_sn == tmproductsn)
                        {
                            lvInvIn.Items[i].SubItems[5].Text = _qty;
                            break;
                        }
                    }
                } 
                //
                lvInvIn.Refresh();
                RefreshNoWc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新时异常!" + ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void txtProductid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Enter || e.KeyValue == 13)
            {
                strscanflag = "";
                GetProduct(this.txtProductid.Text.Trim());
                RefreshList(strinvinsn,strprosn);
                ShowCurrentRow(strprosn);
            }
        }
        private void ShowCurrentRow(string tmpsn)
        {
             
            for (int i = 0; i < lvInvIn.Items.Count; i++)
            {
                string _sn = lvInvIn.Items[i].SubItems[6].Text.Trim();
                if (_sn == tmpsn)
                {
                    this.lvInvIn.Items[i].Selected = true;
                    this.lvInvIn.EnsureVisible(i);
                    break;
                }
            }
        }
        private void RefreshNoWc()
        {
            int icnt = 0;
            for (int i = 0; i < lvInvIn.Items.Count; i++)
            {
                string tmpnoinv = lvInvIn.Items[i].SubItems[4].Text.Trim();
                string tmpnowinv = lvInvIn.Items[i].SubItems[5].Text.Trim();
                if (tmpnoinv == "")
                {
                    tmpnoinv = "0";
                }
                if (tmpnowinv == "")
                {
                    tmpnowinv = "0";
                }
                if (int.Parse(tmpnowinv) < int.Parse(tmpnoinv))
                {
                    icnt = icnt + 1;
                }
                
            }
            this.txtNoCnt.Text = icnt.ToString() + " 行";
        }

        private void GetProduct(string tmp)
        {
            this.txtbuqty.Text = "";
            this.txtProductName.Text = "";
            this.txtBarcode.Text = "";
            this.txtRate.Text = "";
            lblMsg.Text = "*";
            strprosn = "";
            strrate = "";
            strscanflag = "";
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
                    //
                    strprosn = tmpsn;
                    strrate = "1";
                    lblMsg.Text = "__*1";
                    //
                    this.txtbuqty.Enabled = true;
                    this.txtbuqty.Focus();
                    this.txtbuqty.SelectAll();
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
                        lblMsg.Text = "__*1";
                        this.txtbuqty.Enabled = true;
                        this.txtProductid.Text = tmpid;
                        this.txtbuqty.Focus();
                        this.txtbuqty.SelectAll();
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
                            lblMsg.Text = "__*" + tmprate;
                            this.txtbuqty.Enabled = true;
                            this.txtProductid.Text = tmpid;
                            this.txtbuqty.Focus();
                            this.txtbuqty.SelectAll();
                            strscanflag = "3";
                        }
                        else
                        {
                            this.txtbuqty.Enabled = false;
                            this.txtProductid.Text = "";
                            this.txtProductid.Focus();
                            this.txtProductid.SelectAll();
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
                strscanflag = "";
            }
            //
        }
        
       

       

        private void frmInvIn_Load(object sender, EventArgs e)
        {
            try
            {
                conn_db.ConnectionString = _dbpath;
                conn_scan.ConnectionString = _dbscan;
                conn_db.Open();
                conn_scan.Open();
                InitWare();
                InitInvinid("");
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
            string sql = "select distinct warename from tporder ";

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
        private void InitInvinid(string warename)
        {
            this.Text = "采购入库";
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            string sql = "select pordercode ,pordersn,supplier from tporder where 1=1  ";
            if (warename != "")
            {
                sql += " and warename = '" + warename + "'";
            }
            sql += " order by pordercode ";
            try
            {
                DataSet ds = new DataSet();
                ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                this.cmbPordercode.Items.Clear();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int icnt = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < icnt; i++)
                    {
                        cmbPordercode.Items.Add(ds.Tables[0].Rows[i][0].ToString() + "                           :" + ds.Tables[0].Rows[i][1].ToString() + ":" + ds.Tables[0].Rows[i][2].ToString());
                    }
                }
            }
            catch { }
        }

        private void cmbWare_SelectedValueChanged_1(object sender, EventArgs e)
        {
            InitInvinid(this.cmbWare.Text.Trim());
        }

        private void cmbInvinid_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvInvIn.Items.Clear();
            strinvinsn = "";
            strprosn = "";
            strporderdsn = "";
            strrate = "";
            strnoinvqty = "";
            icur = -1;
            if (cmbPordercode.Text.Trim() != "")
            {
                strinvinsn = cmbPordercode.Text.Trim().Split(':')[1].Trim();
                string tmpsupp = cmbPordercode.Text.Trim().Split(':')[2].Trim();
                this.Text = "采购入库" + "-" + tmpsupp;
                //
                GetPorderDetail(strinvinsn);
                RefreshNoWc();
                //
                this.txtProductid.Focus();
                this.txtProductid.Text = "";
            }
            else
            {
                strinvinsn = "";
                this.Text = "采购入库";
            }

        }
        private void  GetPorderDetail(string strsn) 
        {
            string sql = "select productsn,orderqty,invedqty,noinvqty,porderdsn from tporderdetail where pordersn =" + strsn;
            if (conn_scan.State != ConnectionState.Open)
            {
                conn_scan.Open();
            }
            if (conn_db.State != ConnectionState.Open)
            {
                conn_db.Open();
            }
            //
            try
            {
                DataSet ds = new DataSet();
                ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                ada_scan.Fill(ds);
                this.lvInvIn.Items.Clear();
                #region test1
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int icnt = ds.Tables[0].Rows.Count;
                    txtCnt.Text = icnt.ToString() + " 行";
                    string strprosn = "";

                    for (int i = 0; i < icnt; i++)
                    {
                        strprosn += ds.Tables[0].Rows[i][0].ToString() + ",";
                    }
                    strprosn = strprosn.Substring(0, strprosn.Length - 1);
                    //
                    sql = "select porderdsn,inbuqty from tinvindetail where pordersn = " + strsn;
                    DataSet di = new DataSet();
                    ada_scan = new SqlCeDataAdapter(sql, conn_scan);
                    ada_scan.Fill(di);
                    //       
                    sql = "select productid,productsn from tgoods where productsn in (" + strprosn + ")";
                    DataSet dp = new DataSet();
                    ada_db = new SqlCeDataAdapter(sql, conn_db);
                    ada_db.Fill(dp);
                    if (dp != null && dp.Tables[0].Rows.Count > 0)
                    {
                        int jcnt = dp.Tables[0].Rows.Count;
                        int kcnt = 0;
                        int inocnt = 0;
                        if (di != null && di.Tables[0].Rows.Count > 0)
                        {
                            kcnt = di.Tables[0].Rows.Count;
                        }
                        for (int i = 0; i < icnt; i++)
                        {
                            string tmpsn = ds.Tables[0].Rows[i][0].ToString();
                            string tmporderqty = ds.Tables[0].Rows[i][1].ToString();
                            string tmpinvedqty = ds.Tables[0].Rows[i][2].ToString();
                            string tmpnoinvqty = ds.Tables[0].Rows[i][3].ToString();
                            string tmpporderdsn = ds.Tables[0].Rows[i][4].ToString();
                            for (int j = 0; j < jcnt; j++)
                            {
                                if (tmpsn.Trim() == dp.Tables[0].Rows[j][1].ToString().Trim())
                                {
                                    string tmpid = dp.Tables[0].Rows[j][0].ToString();
                                    ListViewItem lvt = new ListViewItem();
                                    lvt.SubItems.Add(tmpid);
                                    lvt.SubItems.Add(tmporderqty);
                                    lvt.SubItems.Add(tmpinvedqty);
                                    lvt.SubItems.Add(tmpnoinvqty);
                                    //
                                    if (kcnt > 0)
                                    {
                                        bool bhave = false;
                                        for (int k = 0; k < kcnt; k++)
                                        {
                                            if (tmpporderdsn == di.Tables[0].Rows[k][0].ToString())
                                            {
                                                string tmp = di.Tables[0].Rows[k][1].ToString().Trim();
                                                if (tmp == "")
                                                {
                                                    tmp = "0";
                                                }

                                                lvt.SubItems.Add(tmp);
                                                bhave = true;
                                                break;
                                            }
                                        }
                                        if (bhave == false)
                                        {
                                            lvt.SubItems.Add("");
                                        }
                                    }
                                    else
                                    {
                                        if (int.Parse(tmpnoinvqty) > 0)
                                        {
                                            inocnt = inocnt + 1;
                                        }
                                        lvt.SubItems.Add("");
                                    }
                                    lvt.SubItems.Add(tmpsn);
                                    this.lvInvIn.Items.Add(lvt);
                                    break;
                                }
                            }
                        }

                    }


                }
                #endregion

               
            }
            catch { }
        }
        private void txtProductid_GotFocus(object sender, EventArgs e)
        {
            this.txtbuqty.Enabled = false;
            if (this.cmbPordercode.Text.Trim() == "")
            {
                this.txtProductid.Text = "";
                this.cmbPordercode.Focus();
                return;
            }
        }

        private void txtbuqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' || e.KeyChar == '\x0d' || e.KeyChar == '\x08'))
            {
                e.Handled = true;
            }
        }

        private void txtbuqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveQty();
            }
        }

        private void lvInvIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvInvIn.SelectedIndices != null && lvInvIn.SelectedIndices.Count > 0)
                {
                    string tmpprosn = this.lvInvIn.Items[this.lvInvIn.SelectedIndices[0]].SubItems[6].Text.ToString();
                    icur = this.lvInvIn.SelectedIndices[0];
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
            catch(Exception ex)
            {
                MessageBox.Show("查询数据时异常! "+ex.Message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvInvIn.Items.Count; i++)
            {
                string tmpnoinv = lvInvIn.Items[i].SubItems[4].Text.Trim();
                string tmpnowinv = lvInvIn.Items[i].SubItems[5].Text.Trim();
                string tmpsn = lvInvIn.Items[i].SubItems[6].Text.Trim();
                if (tmpnoinv == "")
                {
                    tmpnoinv = "0";
                }
                if (tmpnowinv == "")
                {
                    tmpnowinv = "0";
                }
                if (int.Parse(tmpnowinv) < int.Parse(tmpnoinv) && i > icur)
                {
                    ShowCurrentRow(tmpsn);
                    icur = i;
                    break;
                }
                
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int icnt = lvInvIn.Items.Count;
            for (int i = icnt -1; i >= 0 ; i--)
            {
                string tmpnoinv = lvInvIn.Items[i].SubItems[4].Text.Trim();
                string tmpnowinv = lvInvIn.Items[i].SubItems[5].Text.Trim();
                string tmpsn = lvInvIn.Items[i].SubItems[6].Text.Trim();
                if (tmpnoinv == "")
                {
                    tmpnoinv = "0";
                }
                if (tmpnowinv == "")
                {
                    tmpnowinv = "0";
                }
                if (int.Parse(tmpnowinv) < int.Parse(tmpnoinv) && i < icur)
                {
                    ShowCurrentRow(tmpsn);
                    icur = i;
                    break;
                }

            }
        }

        private void frmInvIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (strinvinsn == "")
            {
                this.txtProductid.Text = "";
                this.cmbPordercode.Focus();
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Down:
                    btnDown_Click(this.btnDown, e);
                    break;
                case Keys.Up:
                    btnUp_Click(this.btnUp, e);
                    break;
                case Keys.Left:
                    this.txtProductid.Text = "";
                    this.txtProductid.Focus();
                    break;
                default:
                    break;
            }
        }

        private void frmInvIn_Closing(object sender, CancelEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmGoodChk fgc = new frmGoodChk();
            fgc.ShowDialog();
        }        
    }
}