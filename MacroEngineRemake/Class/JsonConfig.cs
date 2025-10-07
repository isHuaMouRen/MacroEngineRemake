using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroEngineRemake.Class
{
    public class JsonConfig
    {
        public class Config
        {
            public class Root
            {
                public bool start_check_update { get; set; }
            }
        }

        public class UpdateIndex
        {
            public class Root
            {
                public string[] root_url { get; set; }
                public JsonConfig.UpdateIndex.UrlPaths url_paths { get; set; }
            }

            public class UrlPaths
            {
                public string MacroEngineRemake { get; set; }
            }
        }

        public class UpdateVersion
        {
            public class Root
            {
                public string latest_version { get; set; }
                public string release_time { get; set; }
                public string release_log { get; set; }
                public string download_url { get; set; }
                public string release_url { get; set; }
                public bool is_full_update { get; set; }
            }
        }
    }
}
