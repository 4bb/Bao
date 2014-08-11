using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shsict.Web
{
    public interface IMaster
    {
        void setHeaderBtnVisible(bool value);
        void setHeaderBtnBack(bool value);

        //void setRefreshNoticeBtn(bool value);

        //void setRefreshFavouriteBtn(bool value);
        void setRefreshCountBtn(bool value);
    }
}
