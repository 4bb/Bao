using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Shsict.Web.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“IsUpdateService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 IsUpdateService.svc 或 IsUpdateService.svc.cs，然后开始调试。
    public class IsUpdateService : IIsUpdateService
    {
        public string IsNeedToUpadate(string version)
        {
            //List<MyVersion> list = new List<MyVersion>();
            string returnStr;

            if (version.ToUpper().Equals("ANDROID"))
            {
                returnStr = ConfigurationManager.AppSettings.GetValues("Version")[0].ToString() + "," + ConfigurationManager.AppSettings.GetValues("UpdateUrl")[0].ToString();
            }
            else if (version.ToUpper().Equals("iOS"))
            {
                returnStr = ConfigurationManager.AppSettings.GetValues("Version")[0].ToString() + "," + ConfigurationManager.AppSettings.GetValues("iphoneUpdateUrl")[0].ToString();
            }
            else
            {
                returnStr = "";
            }
            return returnStr;
        }
    }
}
