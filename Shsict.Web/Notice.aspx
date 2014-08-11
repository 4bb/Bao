<%@ Page Title="公告栏" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="Shsict.Web.Notice" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var $btnRefreshNotice = $("#btnRefresh");
            $btnRefreshNotice.show();
            $btnRefreshNotice.click(function () {
                $.get("Handler/NoticeHandler.ashx", { Method: "refresh" }, function (data, status, xhr) {
                    if (status == "success" && data != null) {
                        if (data == "success") {
                            //alert("刷新公告完成");

                            window.location.href = window.location.href;

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
    <asp:Repeater ID="rptNotice" runat="server" OnItemDataBound="rptNotice_ItemDataBound">
        <ItemTemplate>
            <asp:Literal ID="ltrlNotice" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
