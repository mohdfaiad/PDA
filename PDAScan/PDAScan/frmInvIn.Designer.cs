namespace PDAScan
{
    partial class frmInvIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvIn));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lvInvIn = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.txtbuqty = new System.Windows.Forms.TextBox();
            this.txtProductid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPordercode = new System.Windows.Forms.ComboBox();
            this.cmbWare = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCnt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoCnt = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductName.Location = new System.Drawing.Point(34, 73);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(281, 23);
            this.txtProductName.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-1, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.Text = "品名";
            // 
            // lvInvIn
            // 
            this.lvInvIn.BackColor = System.Drawing.SystemColors.Info;
            this.lvInvIn.Columns.Add(this.columnHeader1);
            this.lvInvIn.Columns.Add(this.columnHeader2);
            this.lvInvIn.Columns.Add(this.columnHeader3);
            this.lvInvIn.Columns.Add(this.columnHeader5);
            this.lvInvIn.Columns.Add(this.columnHeader4);
            this.lvInvIn.Columns.Add(this.columnHeader6);
            this.lvInvIn.Columns.Add(this.columnHeader7);
            this.lvInvIn.FullRowSelect = true;
            this.lvInvIn.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInvIn.Location = new System.Drawing.Point(1, 121);
            this.lvInvIn.Name = "lvInvIn";
            this.lvInvIn.Size = new System.Drawing.Size(314, 124);
            this.lvInvIn.TabIndex = 57;
            this.lvInvIn.View = System.Windows.Forms.View.Details;
            this.lvInvIn.SelectedIndexChanged += new System.EventHandler(this.lvInvIn_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "货号";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "订单数";
            this.columnHeader3.Width = 52;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "已入数";
            this.columnHeader5.Width = 52;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "未入数";
            this.columnHeader4.Width = 52;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "本次数";
            this.columnHeader6.Width = 52;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 0;
            // 
            // txtbuqty
            // 
            this.txtbuqty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtbuqty.Enabled = false;
            this.txtbuqty.ForeColor = System.Drawing.Color.Blue;
            this.txtbuqty.Location = new System.Drawing.Point(184, 26);
            this.txtbuqty.Name = "txtbuqty";
            this.txtbuqty.Size = new System.Drawing.Size(74, 23);
            this.txtbuqty.TabIndex = 55;
            this.txtbuqty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbuqty_KeyDown);
            this.txtbuqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbuqty_KeyPress);
            // 
            // txtProductid
            // 
            this.txtProductid.BackColor = System.Drawing.Color.White;
            this.txtProductid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtProductid.ForeColor = System.Drawing.Color.Blue;
            this.txtProductid.Location = new System.Drawing.Point(34, 26);
            this.txtProductid.Name = "txtProductid";
            this.txtProductid.Size = new System.Drawing.Size(102, 23);
            this.txtProductid.TabIndex = 54;
            this.txtProductid.GotFocus += new System.EventHandler(this.txtProductid_GotFocus);
            this.txtProductid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductid_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-1, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.Text = "货号";
            // 
            // cmbPordercode
            // 
            this.cmbPordercode.Location = new System.Drawing.Point(197, 3);
            this.cmbPordercode.Name = "cmbPordercode";
            this.cmbPordercode.Size = new System.Drawing.Size(118, 23);
            this.cmbPordercode.TabIndex = 53;
            this.cmbPordercode.SelectedIndexChanged += new System.EventHandler(this.cmbInvinid_SelectedIndexChanged);
            // 
            // cmbWare
            // 
            this.cmbWare.Location = new System.Drawing.Point(34, 3);
            this.cmbWare.Name = "cmbWare";
            this.cmbWare.Size = new System.Drawing.Size(102, 23);
            this.cmbWare.TabIndex = 52;
            this.cmbWare.SelectedValueChanged += new System.EventHandler(this.cmbWare_SelectedValueChanged_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.Text = "仓库";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(135, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.Text = "入库数";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(136, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.Text = "采购订单";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(259, 31);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(56, 20);
            this.lblMsg.Text = "*____";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(-2, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.Text = "条码";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarcode.Location = new System.Drawing.Point(34, 49);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ReadOnly = true;
            this.txtBarcode.Size = new System.Drawing.Size(102, 23);
            this.txtBarcode.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(135, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.Text = "比    率";
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.SystemColors.Info;
            this.txtRate.Location = new System.Drawing.Point(184, 49);
            this.txtRate.Name = "txtRate";
            this.txtRate.ReadOnly = true;
            this.txtRate.Size = new System.Drawing.Size(74, 23);
            this.txtRate.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-1, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.Text = "总数";
            // 
            // txtCnt
            // 
            this.txtCnt.BackColor = System.Drawing.SystemColors.Info;
            this.txtCnt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtCnt.ForeColor = System.Drawing.Color.Red;
            this.txtCnt.Location = new System.Drawing.Point(34, 97);
            this.txtCnt.Name = "txtCnt";
            this.txtCnt.ReadOnly = true;
            this.txtCnt.Size = new System.Drawing.Size(102, 23);
            this.txtCnt.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(135, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.Text = "未完成";
            // 
            // txtNoCnt
            // 
            this.txtNoCnt.BackColor = System.Drawing.SystemColors.Info;
            this.txtNoCnt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtNoCnt.ForeColor = System.Drawing.Color.Red;
            this.txtNoCnt.Location = new System.Drawing.Point(184, 97);
            this.txtNoCnt.Name = "txtNoCnt";
            this.txtNoCnt.ReadOnly = true;
            this.txtNoCnt.Size = new System.Drawing.Size(74, 23);
            this.txtNoCnt.TabIndex = 103;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Lavender;
            this.btnDown.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnDown.ForeColor = System.Drawing.Color.Red;
            this.btnDown.Location = new System.Drawing.Point(263, 97);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 23);
            this.btnDown.TabIndex = 104;
            this.btnDown.Text = "∨";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Lavender;
            this.btnUp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnUp.ForeColor = System.Drawing.Color.Red;
            this.btnUp.Location = new System.Drawing.Point(290, 97);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 23);
            this.btnUp.TabIndex = 115;
            this.btnUp.Text = "∧";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.Location = new System.Drawing.Point(14, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 24);
            this.button1.TabIndex = 126;
            this.button1.Text = "新增入库";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInvIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.txtNoCnt);
            this.Controls.Add(this.txtCnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvInvIn);
            this.Controls.Add(this.txtbuqty);
            this.Controls.Add(this.txtProductid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPordercode);
            this.Controls.Add(this.cmbWare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmInvIn";
            this.Text = "采购入库";
            this.Load += new System.EventHandler(this.frmInvIn_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmInvIn_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvIn_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvInvIn;
        private System.Windows.Forms.TextBox txtbuqty;
        private System.Windows.Forms.TextBox txtProductid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPordercode;
        private System.Windows.Forms.ComboBox cmbWare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCnt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoCnt;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button button1;
    }
}