<%@ Page Title="我的收藏" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Favourite.aspx.cs" Inherits="Shsict.Web.Favourite" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var $btnRefreshFav = $("#btnRefresh");
            $btnRefreshFav.show();
            $btnRefreshFav.click(function () {
                $.get("Handler/SetFavouriteHandler.ashx", { Method: "refresh" }, function (data, status, xhr) {
                    if (status == "success" && data != null) {
                        if (data == "success") {
                            //alert("刷新关注完成");

                            window.location.href = window.location.href;

                        } else if (data == "nologin") {
                            window.location.href = "/login.aspx?nexturl=" + _url;
                        }
                        else {
                            //alert(data);
                        }
                    } else {
                        alert("调用接口失败(SetFavouriteHandler.ashx)");
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Repeater ID="rptrFavourite" runat="server" OnItemDataBound="rptrFavourite_ItemDataBound">
            <HeaderTemplate>
                <ul data-role="listview" id="listFavourite">
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Literal ID="ltrlFavourites" runat="server"></asp:Literal>
            </ItemTemplate>
            <FooterTemplate>
                </ul>        
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
