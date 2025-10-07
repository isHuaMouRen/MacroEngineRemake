using ToolLib.AreaSelectorLib;
using ToolLib.ErrorReportLib;
using ToolLib.PosSelectorLib;
using ToolLib.AutoStartLib;
using ToolLib.CmdLib;
using ToolLib.DownloaderLib;
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
using ToolLib.RegistryLib;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MacroEngineRemake.Class;
using System.Net.Http;

namespace MacroEngineRemake.Forms
{
    public partial class Main_Form : Form
    {
        #region Func
        public void Initialize()
        {
            try
            {
                Log.Info("程序开始初始化");

                //初始化配置文件
                if (!File.Exists(ConfigPath))
                {
                    GlobalConfig = new JsonConfig.Config.Root
                    {
                        start_check_update = true
                    };
                    Json.WriteJson(ConfigPath, GlobalConfig);
                }

                //读配置文件
                GlobalConfig = Json.ReadJson<JsonConfig.Config.Root>(ConfigPath);
                Log.Info($"读取配置文件");

                //检查更新
                if (GlobalConfig.start_check_update)
                {
                    Log.Info("开始检测更新");
                    CheckUpdate();
                }


            }
            catch (Exception ex)
            {
                Log.Error($"初始化程序时发生错误\n\n{ex}");
                if (ErrorReportBox.Show("Error", "在初始化程序时发生错误", ex) == DialogResult.Abort) Environment.Exit(1);
            }
        }

        public async void CheckUpdate()
        {
            try
            {
                Log.Info("进入检查更新流程");

                int? reachable = null;


                for (int i = 0; i < UpdateIndexUrls.Length; i++)
                {
                    if (await CheckReachable(UpdateIndexUrls[i]))
                    {
                        Log.Info($"更新源 {UpdateIndexUrls[i]} 可联通");
                        reachable = i;
                        break;
                    }
                }

                if (reachable != null) 
                {
                    Log.Info("有可用更新源，开始获取更新信息");
                    using (var client = new HttpClient()) 
                    {
                        JsonConfig.UpdateIndex.Root indexContent = Json.ReadJson<JsonConfig.UpdateIndex.Root>(await client.GetStringAsync(UpdateIndexUrls[(int)reachable]));

                        Log.Info("获取更新索引成功，开始获取版本信息");
                        Log.Info($"版本信息Url: {indexContent.root_url[(int)reachable]}{indexContent.url_paths.MacroEngineRemake}");

                        JsonConfig.UpdateVersion.Root versionContent = Json.ReadJson<JsonConfig.UpdateVersion.Root>(await client.GetStringAsync($"{indexContent.root_url[(int)reachable]}{indexContent.url_paths.MacroEngineRemake}"));

                        Log.Info("所有信息获取成功");

                        if (versionContent.latest_version != Version)
                        {
                            Log.Info("检测到更新，进入更新流程");
                            using (var window = new Update())
                            {
                                MacroEngineRemake.Forms.Update.IndexContent = indexContent;
                                MacroEngineRemake.Forms.Update.VersionContent = versionContent;
                                MacroEngineRemake.Forms.Update.Version = Version;
                                Forms.Update.UpdateSource = (int)reachable;
                                Log.Info("创建窗口实例");
                                window.ShowDialog();
                            }
                            Log.Info("更新流程结束");
                        }
                        else
                        {
                            Log.Info("已是最新版本，无需更新");
                        }
                        


                    }
                }
                else
                {
                    Log.Warn($"无更新源可用，抛出错误");
                    throw new Exception("所有更新源均无法联通，请检查您的网络");
                }












                Log.Info("退出检测更新流程");
            }
            catch (Exception ex)
            {
                Log.Error($"在检测更新时发生错误\n\n{ex}");
                if (ErrorReportBox.Show("Error", "在检测更新时发生错误", ex) == DialogResult.Abort)
                    Environment.Exit(1);
            }
            
            
        }

        public async Task<bool> CheckReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(5);

                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                    var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Obj
        #endregion

        #region Var
        public static string Version = "Indev 1.0.0.0";
        public static string RunPath = Directory.GetCurrentDirectory();
        public static string ConfigPath = $"{RunPath}\\config.json";
        public static JsonConfig.Config.Root GlobalConfig;
        public static string[] UpdateIndexUrls =
        {
            "https://gitee.com/huamouren110/UpdateService/raw/main/index.json",
            "https://raw.githubusercontent.com/isHuaMouRen/UpdateService/refs/heads/main/index.json",
            "https://raw.gitcode.com/HuaMouRen/UpdateService/raw/main/index.json"
        };
        #endregion

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Info("主窗体退出");
        }
    }
}
