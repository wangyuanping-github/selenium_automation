namespace WindowsFormsApp1
{
    partial class automation
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(automation));
            this.File_treeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Unloading_address_code = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Identification_code = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // File_treeView
            // 
            this.File_treeView.Location = new System.Drawing.Point(12, 19);
            this.File_treeView.Name = "File_treeView";
            this.File_treeView.Size = new System.Drawing.Size(462, 153);
            this.File_treeView.TabIndex = 1;
            this.File_treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(488, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "卸货地代码";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Unloading_address_code
            // 
            this.Unloading_address_code.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Unloading_address_code.Location = new System.Drawing.Point(593, 29);
            this.Unloading_address_code.Name = "Unloading_address_code";
            this.Unloading_address_code.Size = new System.Drawing.Size(118, 26);
            this.Unloading_address_code.TabIndex = 5;
            this.Unloading_address_code.Text = "CNXAM370125";
            this.Unloading_address_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Unloading_address_code.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(636, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(12, 187);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputBox.Size = new System.Drawing.Size(462, 88);
            this.OutputBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(474, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "数据传输识别人";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Identification_code
            // 
            this.Identification_code.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Identification_code.Location = new System.Drawing.Point(593, 76);
            this.Identification_code.Name = "Identification_code";
            this.Identification_code.Size = new System.Drawing.Size(118, 26);
            this.Identification_code.TabIndex = 20;
            this.Identification_code.Text = "3700303036799";
            // 
            // automation
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 313);
            this.Controls.Add(this.Identification_code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Unloading_address_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.File_treeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "automation";
            this.Text = "自动化操作";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.automation_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.automation_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView File_treeView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Unloading_address_code;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Identification_code;
    }
}

