namespace PDAScan
{
    partial class frmDGoodsDiff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDGoodsDiff));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lvdiff = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.colproductid = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvdiff
            // 
            this.lvdiff.BackColor = System.Drawing.SystemColors.Info;
            this.lvdiff.CheckBoxes = true;
            this.lvdiff.Columns.Add(this.columnHeader1);
            this.lvdiff.Columns.Add(this.colproductid);
            this.lvdiff.Columns.Add(this.columnHeader2);
            this.lvdiff.Columns.Add(this.columnHeader3);
            this.lvdiff.Columns.Add(this.columnHeader4);
            this.lvdiff.Columns.Add(this.columnHeader5);
            this.lvdiff.Location = new System.Drawing.Point(3, 3);
            this.lvdiff.Name = "lvdiff";
            this.lvdiff.Size = new System.Drawing.Size(305, 252);
            this.lvdiff.TabIndex = 58;
            this.lvdiff.View = System.Windows.Forms.View.Details;
            this.lvdiff.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvdiff_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 18;
            // 
            // colproductid
            // 
            this.colproductid.Text = "货号";
            this.colproductid.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "系统数";
            this.columnHeader2.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "实盘数";
            this.columnHeader3.Width = 60;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "差异数";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            // 
            // frmDGoodsDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvdiff);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDGoodsDiff";
            this.Text = "送货单差异";
            this.Load += new System.EventHandler(this.frmDGoodsDiff_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvdiff;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colproductid;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
    }
}