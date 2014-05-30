namespace PDAScan
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInvChk = new System.Windows.Forms.Button();
            this.btnPorderIn = new System.Windows.Forms.Button();
            this.btnPRorderOut = new System.Windows.Forms.Button();
            this.btnDgoods = new System.Windows.Forms.Button();
            this.btnTelSale = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChkGoods = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.Text = "仓储应用功能列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnInvChk
            // 
            this.btnInvChk.BackColor = System.Drawing.Color.Lavender;
            this.btnInvChk.Location = new System.Drawing.Point(14, 125);
            this.btnInvChk.Name = "btnInvChk";
            this.btnInvChk.Size = new System.Drawing.Size(95, 33);
            this.btnInvChk.TabIndex = 2;
            this.btnInvChk.Text = "[3]仓库盘点";
            this.btnInvChk.Click += new System.EventHandler(this.btnInvChk_Click);
            // 
            // btnPorderIn
            // 
            this.btnPorderIn.BackColor = System.Drawing.Color.Lavender;
            this.btnPorderIn.Location = new System.Drawing.Point(14, 77);
            this.btnPorderIn.Name = "btnPorderIn";
            this.btnPorderIn.Size = new System.Drawing.Size(95, 33);
            this.btnPorderIn.TabIndex = 3;
            this.btnPorderIn.Text = "[1]采购入库";
            this.btnPorderIn.Click += new System.EventHandler(this.btnPorderIn_Click);
            // 
            // btnPRorderOut
            // 
            this.btnPRorderOut.BackColor = System.Drawing.Color.Lavender;
            this.btnPRorderOut.Location = new System.Drawing.Point(130, 77);
            this.btnPRorderOut.Name = "btnPRorderOut";
            this.btnPRorderOut.Size = new System.Drawing.Size(95, 33);
            this.btnPRorderOut.TabIndex = 4;
            this.btnPRorderOut.Text = "[2]销售出库";
            this.btnPRorderOut.Click += new System.EventHandler(this.btnPRorderOut_Click);
            // 
            // btnDgoods
            // 
            this.btnDgoods.BackColor = System.Drawing.Color.Lavender;
            this.btnDgoods.Location = new System.Drawing.Point(130, 125);
            this.btnDgoods.Name = "btnDgoods";
            this.btnDgoods.Size = new System.Drawing.Size(95, 33);
            this.btnDgoods.TabIndex = 5;
            this.btnDgoods.Text = "[4]门店送货";
            this.btnDgoods.Click += new System.EventHandler(this.btnDgoods_Click);
            // 
            // btnTelSale
            // 
            this.btnTelSale.BackColor = System.Drawing.Color.Lavender;
            this.btnTelSale.Location = new System.Drawing.Point(14, 174);
            this.btnTelSale.Name = "btnTelSale";
            this.btnTelSale.Size = new System.Drawing.Size(95, 33);
            this.btnTelSale.TabIndex = 8;
            this.btnTelSale.Text = "[5]数据同步";
            this.btnTelSale.Click += new System.EventHandler(this.btnTelSale_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Lavender;
            this.btnExit.Location = new System.Drawing.Point(130, 226);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(95, 29);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "[ESC]退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChkGoods
            // 
            this.btnChkGoods.BackColor = System.Drawing.Color.Lavender;
            this.btnChkGoods.Location = new System.Drawing.Point(130, 174);
            this.btnChkGoods.Name = "btnChkGoods";
            this.btnChkGoods.Size = new System.Drawing.Size(95, 33);
            this.btnChkGoods.TabIndex = 10;
            this.btnChkGoods.Text = "[6]条码采集";
            this.btnChkGoods.Click += new System.EventHandler(this.btnChkGoods_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label2.Location = new System.Drawing.Point(3, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.Text = "VER:1.20140523";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChkGoods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTelSale);
            this.Controls.Add(this.btnDgoods);
            this.Controls.Add(this.btnPRorderOut);
            this.Controls.Add(this.btnPorderIn);
            this.Controls.Add(this.btnInvChk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "菜单选择";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInvChk;
        private System.Windows.Forms.Button btnPorderIn;
        private System.Windows.Forms.Button btnPRorderOut;
        private System.Windows.Forms.Button btnDgoods;
        private System.Windows.Forms.Button btnTelSale;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChkGoods;
        private System.Windows.Forms.Label label2;
    }
}