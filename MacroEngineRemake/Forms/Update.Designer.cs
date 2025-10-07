namespace MacroEngineRemake.Forms
{
    partial class Update
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.webView2_Log = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.label_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Log)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "我们发现了一个可用更新";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webView2_Log
            // 
            this.webView2_Log.AllowExternalDrop = true;
            this.webView2_Log.CreationProperties = null;
            this.webView2_Log.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_Log.Location = new System.Drawing.Point(12, 145);
            this.webView2_Log.Name = "webView2_Log";
            this.webView2_Log.Size = new System.Drawing.Size(412, 228);
            this.webView2_Log.TabIndex = 1;
            this.webView2_Log.ZoomFactor = 0.8D;
            // 
            // label_info
            // 
            this.label_info.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_info.Location = new System.Drawing.Point(12, 64);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(412, 78);
            this.label_info.TabIndex = 2;
            this.label_info.Text = "当前版本: {Version}\r\n最新版本: {Version}\r\n发布时间: {Time}\r\nRelease链接: {Url}";
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 385);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.webView2_Log);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Update";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update";
            this.Load += new System.EventHandler(this.Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Log)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2_Log;
        private System.Windows.Forms.Label label_info;
    }
}