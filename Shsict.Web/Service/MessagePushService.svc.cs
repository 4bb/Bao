using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Shsict.Entity;

namespace Shsict.Web.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“MessagePushService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 MessagePushService.svc 或 MessagePushService.svc.cs，然后开始调试。
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MessagePushService : IMessagePushService
    {
        public int GetMsgStatueByUID(string uid)
        {
            List<MyFavourite> list = MyFavourite.Cache.FavouriteList_Active.FindAll(delegate(MyFavourite f) { return f.USERNAME.Equals(uid)&&f.STATUS.Equals(1); });

            int ReturnString = list.Count;
            return ReturnString;
        }
    }

}
