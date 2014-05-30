namespace PDAScan
{
    partial class frmGoodChk
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoodChk));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutBarcode = new System.Windows.Forms.TextBox();
            this.btnSave1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductid = new System.Windows.Forms.TextBox();
            this.txtOutBarcode2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBarcode2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProductidInf = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProductNameInf = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRateInf = new System.Windows.Forms.TextBox();
            this.txtBarcodeInf = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOutbarcodeInf = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.Text = "现保存有";
            // 
            // txtCnt
            // 
            this.txtCnt.BackColor = System.Drawing.SystemColors.Info;
            this.txtCnt.ForeColor = System.Drawing.Color.Red;
            this.txtCnt.Location = new System.Drawing.Point(67, 5);
            this.txtCnt.Name = "txtCnt";
            this.txtCnt.ReadOnly = true;
            this.txtCnt.Size = new System.Drawing.Size(81, 23);
            this.txtCnt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(161, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.Text = "条采集数据";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Lavender;
            this.btnClear.Location = new System.Drawing.Point(253, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(59, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(308, 20);
            this.label3.Text = "---------------------------------------------------";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.Text = "商品条码";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtBarcode.ForeColor = System.Drawing.Color.Red;
            this.txtBarcode.Location = new System.Drawing.Point(67, 39);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(140, 23);
            this.txtBarcode.TabIndex = 8;
            this.txtBarcode.GotFocus += new System.EventHandler(this.txtBarcode_GotFocus);
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.Text = "外箱条码 ";
            // 
            // txtOutBarcode
            // 
            this.txtOutBarcode.BackColor = System.Drawing.Color.White;
            this.txtOutBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtOutBarcode.ForeColor = System.Drawing.Color.Blue;
            this.txtOutBarcode.Location = new System.Drawing.Point(67, 63);
            this.txtOutBarcode.Name = "txtOutBarcode";
            this.txtOutBarcode.Size = new System.Drawing.Size(140, 23);
            this.txtOutBarcode.TabIndex = 15;
            this.txtOutBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutBarcode_KeyDown);
            // 
            // btnSave1
            // 
            this.btnSave1.BackColor = System.Drawing.Color.Lavender;
            this.btnSave1.Location = new System.Drawing.Point(253, 63);
            this.btnSave1.Name = "btnSave1";
            this.btnSave1.Size = new System.Drawing.Size(59, 23);
            this.btnSave1.TabIndex = 16;
            this.btnSave1.Text = "保存";
            this.btnSave1.Click += new System.EventHandler(this.btnSave1_Click);
            this.btnSave1.GotFocus += new System.EventHandler(this.btnSave1_GotFocus);
            this.btnSave1.LostFocus += new System.EventHandler(this.btnSave1_LostFocus);
            this.btnSave1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave1_KeyDown);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(308, 20);
            this.label6.Text = "---------------------------------------------------";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.Text = "商品货号";
            // 
            // txtProductid
            // 
            this.txtProductid.BackColor = System.Drawing.Color.White;
            this.txtProductid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtProductid.ForeColor = System.Drawing.Color.Blue;
            this.txtProductid.Location = new System.Drawing.Point(67, 89);
            this.txtProductid.Name = "txtProductid";
            this.txtProductid.Size = new System.Drawing.Size(140, 23);
            this.txtProductid.TabIndex = 21;
            this.txtProductid.GotFocus += new System.EventHandler(this.txtProductid_GotFocus);
            this.txtProductid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductid_KeyDown);
            // 
            // txtOutBarcode2
            // 
            this.txtOutBarcode2.BackColor = System.Drawing.Color.White;
            this.txtOutBarcode2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtOutBarcode2.ForeColor = System.Drawing.Color.Blue;
            this.txtOutBarcode2.Location = new System.Drawing.Point(67, 137);
            this.txtOutBarcode2.Name = "txtOutBarcode2";
            this.txtOutBarcode2.Size = new System.Drawing.Size(140, 23);
            this.txtOutBarcode2.TabIndex = 25;
            this.txtOutBarcode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutBarcode2_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.Text = "外箱条码 ";
            // 
            // txtBarcode2
            // 
            this.txtBarcode2.BackColor = System.Drawing.Color.White;
            this.txtBarcode2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtBarcode2.ForeColor = System.Drawing.Color.Blue;
            this.txtBarcode2.Location = new System.Drawing.Point(67, 113);
            this.txtBarcode2.Name = "txtBarcode2";
            this.txtBarcode2.Size = new System.Drawing.Size(140, 23);
            this.txtBarcode2.TabIndex = 24;
            this.txtBarcode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode2_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(4, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.Text = "商品条码";
            // 
            // btnSave2
            // 
            this.btnSave2.BackColor = System.Drawing.Color.Lavender;
            this.btnSave2.Location = new System.Drawing.Point(253, 137);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(59, 23);
            this.btnSave2.TabIndex = 28;
            this.btnSave2.Text = "保存";
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            this.btnSave2.GotFocus += new System.EventHandler(this.btnSave2_GotFocus);
            this.btnSave2.LostFocus += new System.EventHandler(this.btnSave2_LostFocus);
            this.btnSave2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave2_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(309, 20);
            this.label11.Text = "****************************************";
            // 
            // txtProductidInf
            // 
            this.txtProductidInf.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductidInf.Location = new System.Drawing.Point(67, 172);
            this.txtProductidInf.Name = "txtProductidInf";
            this.txtProductidInf.ReadOnly = true;
            this.txtProductidInf.Size = new System.Drawing.Size(140, 23);
            this.txtProductidInf.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.Text = "商品货号";
            // 
            // txtProductNameInf
            // 
            this.txtProductNameInf.BackColor = System.Drawing.SystemColors.Info;
            this.txtProductNameInf.Location = new System.Drawing.Point(67, 196);
            this.txtProductNameInf.Name = "txtProductNameInf";
            this.txtProductNameInf.ReadOnly = true;
            this.txtProductNameInf.Size = new System.Drawing.Size(245, 23);
            this.txtProductNameInf.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.Text = "商品名称";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(213, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 20);
            this.label13.Text = "比率";
            // 
            // txtRateInf
            // 
            this.txtRateInf.BackColor = System.Drawing.SystemColors.Info;
            this.txtRateInf.Location = new System.Drawing.Point(253, 220);
            this.txtRateInf.Name = "txtRateInf";
            this.txtRateInf.ReadOnly = true;
            this.txtRateInf.Size = new System.Drawing.Size(59, 23);
            this.txtRateInf.TabIndex = 41;
            // 
            // txtBarcodeInf
            // 
            this.txtBarcodeInf.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarcodeInf.Location = new System.Drawing.Point(67, 220);
            this.txtBarcodeInf.Name = "txtBarcodeInf";
            this.txtBarcodeInf.ReadOnly = true;
            this.txtBarcodeInf.Size = new System.Drawing.Size(140, 23);
            this.txtBarcodeInf.TabIndex = 44;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(3, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.Text = "商品条码";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(4, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 20);
            this.label15.Text = "外箱条码";
            // 
            // txtOutbarcodeInf
            // 
            this.txtOutbarcodeInf.BackColor = System.Drawing.SystemColors.Info;
            this.txtOutbarcodeInf.Location = new System.Drawing.Point(67, 244);
            this.txtOutbarcodeInf.Name = "txtOutbarcodeInf";
            this.txtOutbarcodeInf.ReadOnly = true;
            this.txtOutbarcodeInf.Size = new System.Drawing.Size(140, 23);
            this.txtOutbarcodeInf.TabIndex = 48;
            // 
            // frmGoodChk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.txtOutbarcodeInf);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBarcodeInf);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRateInf);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtProductNameInf);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtProductidInf);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.txtOutBarcode2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBarcode2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtProductid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSave1);
            this.Controls.Add(this.txtOutBarcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCnt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.Red;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmGoodChk";
            this.Text = "商品条码采集";
            this.Load += new System.EventHandler(this.frmGoodChk_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGoodChk_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGoodChk_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutBarcode;
        private System.Windows.Forms.Button btnSave1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductid;
        private System.Windows.Forms.TextBox txtOutBarcode2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBarcode2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProductidInf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductNameInf;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRateInf;
        private System.Windows.Forms.TextBox txtBarcodeInf;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtOutbarcodeInf;
    }
}