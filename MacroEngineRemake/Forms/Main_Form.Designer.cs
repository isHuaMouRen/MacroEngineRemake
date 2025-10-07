namespace MacroEngineRemake.Forms
{
    partial class Main_Form
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
            this.listView_Main = new System.Windows.Forms.ListView();
            this.columnHeader_macroName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_hotkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_isEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView_Main
            // 
            this.listView_Main.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_macroName,
            this.columnHeader_description,
            this.columnHeader_hotkey,
            this.columnHeader_isEnabled});
            this.listView_Main.HideSelection = false;
            this.listView_Main.Location = new System.Drawing.Point(12, 12);
            this.listView_Main.Name = "listView_Main";
            this.listView_Main.Size = new System.Drawing.Size(699, 325);
            this.listView_Main.TabIndex = 0;
            this.listView_Main.UseCompatibleStateImageBehavior = false;
            this.listView_Main.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_macroName
            // 
            this.columnHeader_macroName.Text = "宏";
            this.columnHeader_macroName.Width = 85;
            // 
            // columnHeader_description
            // 
            this.columnHeader_description.Text = "描述";
            this.columnHeader_description.Width = 124;
            // 
            // columnHeader_hotkey
            // 
            this.columnHeader_hotkey.Text = "触发热键";
            this.columnHeader_hotkey.Width = 88;
            // 
            // columnHeader_isEnabled
            // 
            this.columnHeader_isEnabled.Text = "启用";
            this.columnHeader_isEnabled.Width = 113;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 349);
            this.Controls.Add(this.listView_Main);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MacroEngine";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Main;
        private System.Windows.Forms.ColumnHeader columnHeader_macroName;
        private System.Windows.Forms.ColumnHeader columnHeader_description;
        private System.Windows.Forms.ColumnHeader columnHeader_hotkey;
        private System.Windows.Forms.ColumnHeader columnHeader_isEnabled;
    }
}

