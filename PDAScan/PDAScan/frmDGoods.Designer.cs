namespace PDAScan
{
    partial class frmDGoods
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDGoods));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSysqty = new System.Windows.Forms.TextBox();
            this.txtSumChkQty = new System.Windows.Forms.TextBox();
            this.lvChkQty = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.colqty = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtchkqty = new System.Windows.Forms.TextBox();
            this.txtProductid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDGoodsId = new System.Windows.Forms.ComboBox();
            this.cmbWare = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCy = new System.Windows.Forms.Button();
            this.btnWc = new System.Windows.Forms.Button();
            this.btnReChk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.SystemColors.Info;
            this.txtRate.Location = new System.Drawing.Point(37, 215);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(100, 23);
            this.txtRate.TabIndex = 62;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(2, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.Text = "比率";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarcode.Location = new System.Drawing.Point(37, 191);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(224, 23);
            this.txtBarcode.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1, 197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.Text = "条码";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Location = new System.Drawing.Point(37, 167);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(224, 23);
            this.txtProductName.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(2, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.Text = "品名";
            // 
            // txtSysqty
            // 
            this.txtSysqty.BackColor = System.Drawing.SystemColors.Info;
            this.txtSysqty.Location = new System.Drawing.Point(187, 141);
            this.txtSysqty.Name = "txtSysqty";
            this.txtSysqty.ReadOnly = true;
            this.txtSysqty.Size = new System.Drawing.Size(74, 23);
            this.txtSysqty.TabIndex = 59;
            // 
            // txtSumChkQty
            // 
            this.txtSumChkQty.BackColor = System.Drawing.SystemColors.Info;
            this.txtSumChkQty.Location = new System.Drawing.Point(187, 115);
            this.txtSumChkQty.Name = "txtSumChkQty";
            this.txtSumChkQty.ReadOnly = true;
            this.txtSumChkQty.Size = new System.Drawing.Size(74, 23);
            this.txtSumChkQty.TabIndex = 58;
            // 
            // lvChkQty
            // 
            this.lvChkQty.BackColor = System.Drawing.SystemColors.Info;
            this.lvChkQty.Columns.Add(this.columnHeader1);
            this.lvChkQty.Columns.Add(this.colqty);
            this.lvChkQty.Location = new System.Drawing.Point(37, 56);
            this.lvChkQty.Name = "lvChkQty";
            this.lvChkQty.Size = new System.Drawing.Size(100, 108);
            this.lvChkQty.TabIndex = 57;
            this.lvChkQty.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // colqty
            // 
            this.colqty.Text = "数量";
            this.colqty.Width = 80;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.Text = "明细";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Lavender;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(187, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtchkqty
            // 
            this.txtchkqty.BackColor = System.Drawing.Color.LightCyan;
            this.txtchkqty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtchkqty.ForeColor = System.Drawing.Color.Blue;
            this.txtchkqty.Location = new System.Drawing.Point(187, 29);
            this.txtchkqty.Name = "txtchkqty";
            this.txtchkqty.Size = new System.Drawing.Size(74, 23);
            this.txtchkqty.TabIndex = 55;
            this.txtchkqty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtchkqty_KeyDown);
            this.txtchkqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtchkqty_KeyPress);
            // 
            // txtProductid
            // 
            this.txtProductid.BackColor = System.Drawing.Color.White;
            this.txtProductid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtProductid.ForeColor = System.Drawing.Color.Blue;
            this.txtProductid.Location = new System.Drawing.Point(37, 29);
            this.txtProductid.Name = "txtProductid";
            this.txtProductid.Size = new System.Drawing.Size(100, 23);
            this.txtProductid.TabIndex = 54;
            this.txtProductid.GotFocus += new System.EventHandler(this.txtProductid_GotFocus);
            this.txtProductid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductid_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.Text = "货号";
            // 
            // cmbDGoodsId
            // 
            this.cmbDGoodsId.Location = new System.Drawing.Point(187, 4);
            this.cmbDGoodsId.Name = "cmbDGoodsId";
            this.cmbDGoodsId.Size = new System.Drawing.Size(74, 23);
            this.cmbDGoodsId.TabIndex = 53;
            this.cmbDGoodsId.SelectedIndexChanged += new System.EventHandler(this.cmbDGoodsId_SelectedIndexChanged);
            // 
            // cmbWare
            // 
            this.cmbWare.Location = new System.Drawing.Point(37, 4);
            this.cmbWare.Name = "cmbWare";
            this.cmbWare.Size = new System.Drawing.Size(102, 23);
            this.cmbWare.TabIndex = 52;
            this.cmbWare.SelectedValueChanged += new System.EventHandler(this.cmbWare_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.Text = "仓库";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(138, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.Text = "送货数";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(138, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 20);
            this.label6.Text = "汇总数";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(138, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.Text = "实收数";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(139, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.Text = "单　号";
            // 
            // btnCy
            // 
            this.btnCy.BackColor = System.Drawing.Color.Lavender;
            this.btnCy.Location = new System.Drawing.Point(27, 243);
            this.btnCy.Name = "btnCy";
            this.btnCy.Size = new System.Drawing.Size(55, 23);
            this.btnCy.TabIndex = 73;
            this.btnCy.Text = "看差异";
            this.btnCy.Click += new System.EventHandler(this.btnCy_Click);
            // 
            // btnWc
            // 
            this.btnWc.BackColor = System.Drawing.Color.Lavender;
            this.btnWc.Location = new System.Drawing.Point(176, 243);
            this.btnWc.Name = "btnWc";
            this.btnWc.Size = new System.Drawing.Size(53, 23);
            this.btnWc.TabIndex = 74;
            this.btnWc.Text = "完成";
            this.btnWc.Click += new System.EventHandler(this.btnWc_Click);
            // 
            // btnReChk
            // 
            this.btnReChk.BackColor = System.Drawing.Color.Lavender;
            this.btnReChk.Location = new System.Drawing.Point(101, 244);
            this.btnReChk.Name = "btnReChk";
            this.btnReChk.Size = new System.Drawing.Size(55, 23);
            this.btnReChk.TabIndex = 75;
            this.btnReChk.Text = "重盘";
            this.btnReChk.Click += new System.EventHandler(this.btnReChk_Click);
            // 
            // frmDGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnReChk);
            this.Controls.Add(this.btnWc);
            this.Controls.Add(this.btnCy);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSysqty);
            this.Controls.Add(this.txtSumChkQty);
            this.Controls.Add(this.lvChkQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtchkqty);
            this.Controls.Add(this.txtProductid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDGoodsId);
            this.Controls.Add(this.cmbWare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDGoods";
            this.Text = "门店送货单验单";
            this.Load += new System.EventHandler(this.frmDGoods_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDGoods_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDGoods_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSysqty;
        private System.Windows.Forms.TextBox txtSumChkQty;
        private System.Windows.Forms.ListView lvChkQty;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colqty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtchkqty;
        private System.Windows.Forms.TextBox txtProductid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDGoodsId;
        private System.Windows.Forms.ComboBox cmbWare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCy;
        private System.Windows.Forms.Button btnWc;
        private System.Windows.Forms.Button btnReChk;
    }
}