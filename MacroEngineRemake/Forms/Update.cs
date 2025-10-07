using MacroEngineRemake.Class;
using Markdig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib.AreaSelectorLib;
using ToolLib.AutoStartLib;
using ToolLib.CmdLib;
using ToolLib.DownloaderLib;
using ToolLib.ErrorReportLib;
using ToolLib.GdiToolLib;
using ToolLib.HashLib;
using ToolLib.HexLib;
using ToolLib.HotkeyManagerLib;
using ToolLib.IniLib;
using ToolLib.InputLib;
using ToolLib.JsonLib;
using ToolLib.KeyboardHookLib;
using ToolLib.LogLib;
using ToolLib.MemoryLib;
using ToolLib.PosSelectorLib;
using ToolLib.RegistryLib;

namespace MacroEngineRemake.Forms
{
    public partial class Update : Form
    {
        #region Func
        public async Task Initialize()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    label_info.Text = $"当前版本: {Version}\n最新版本: {VersionContent.latest_version}\n发布时间: {VersionContent.release_time}\nRelease链接: {VersionContent.release_url}";

                    await webView2_Log.EnsureCoreWebView2Async(null);

                    webView2_Log.NavigateToString($"<!DOCTYPE html><html><head><meta charset='utf-8'><style>body {{font-family: 'Microsoft YaHei', 'Segoe UI', sans-serif;padding: 10px;font-size: 14px;line-height: 1.6;}}code {{font-family: Consolas, monospace;background: #f5f5f5;padding: 2px 4px;border-radius: 4px;}}</style></head><body>{Markdown.ToHtml(await client.GetStringAsync($"{IndexContent.root_url[UpdateSource]}{VersionContent.release_log}"))}</body></html>");
                }
                
            }
            catch (Exception ex)
            {
                if (ErrorReportBox.Show("Error", "在初始化窗口时发生错误", ex) == DialogResult.Abort)
                    Environment.Exit(1);
            }
        }
        #endregion

        #region Obj
        #endregion

        #region Var
        public static JsonConfig.UpdateIndex.Root IndexContent;
        public static JsonConfig.UpdateVersion.Root VersionContent;
        public static string Version;
        public static int UpdateSource;
        #endregion

        public Update()
        {
            InitializeComponent();
        }

        private async void Update_Load(object sender, EventArgs e)
        {
            await Initialize();
        }
    }
}
