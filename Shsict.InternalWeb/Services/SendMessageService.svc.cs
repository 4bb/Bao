using Shsict.InternalWeb.Controllers;
using Shsict.InternalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Shsict.InternalWeb.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“SendMessageService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 SendMessageService.svc 或 SendMessageService.svc.cs，然后开始调试。
    public class SendMessageService : ISendMessageService
    {
        public int GetMechanicalErrorByUID(string uid)
        {
            List<MechanicalError> list = MechanicalErrorController.Cache.MechanicalErrorList.FindAll(delegate(MechanicalError m) { return m.JobNo.Equals(uid) && m.ISSEND.Equals("Y"); });

            int ReturnString = list.Count;
            return ReturnString;
        }
    }
}
