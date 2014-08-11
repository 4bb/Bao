<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Acceptance_List.aspx.cs" Inherits="Shsict.Web.Container_Acceptance_List" Title="特种箱受理情况" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">

        $(function () {
            var tbContainerAcceptance = $(".container-acceptance .Acceptance");
            var ddlplanaccept = $(".container-acceptance select.planaccept");
            var counts = 0;

            tbContainerAcceptance.attr("placeholder", "请输入申请编号").blur(QueryImpl).change(QueryImpl);

            if (tbContainerAcceptance.val().trim() != "") {
                QueryImpl();
            }

            if (ddlplanaccept.val().trim() == "aa" && tbContainerAcceptance.val().trim() == "") {

            }
            else { QueryImpl(); }

            tbContainerAcceptance.keydown(function () {
                if (event.keyCode == 13) {
                    QueryImpl();

                    return false;
                }
            });

            ddlplanaccept.change(QueryImpl);

            $("#btnRefreshCount").click(QueryImpl);

        });

        function QueryImpl() {
            CustomLoader();

            var $tbAcceptance = $(".container-acceptance .Acceptance");
            var _value1 = $tbAcceptance.val().trim().toUpperCase();
            var _value2 = $(".container-acceptance select.planaccept").val();
            var _value3 = $(".container-acceptance .Custom").text();

            $tbAcceptance.val(_value1);

            var $listView = $("ul#listContainerAcceptance");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("Handler/ContainerAcceptanceList.ashx", { Acceptance: _value1, PlanAccept: _value2, Custom: _value3 }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();

                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {
                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");

                            $item.click(function () {
                                window.location.href = String.format("Container_Acceptance_Detail.aspx?ContainerID={0}", entry.ID);

                                CustomLoader();
                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.ID;

                            $itemh3.html(itemHtmlh3);

                            var $itemp = $item.find("p").first();
                            var itemHtmlp = "申请/实际进港时间:" + timeStamp2String(entry.PlanTime);

                            $itemp.html(itemHtmlp);

                            var $itemContant = $item.find("p").next();
                            var itemHtmlContant = "进港结束时间:" + timeStamp2String(entry.PlanAcceptedTime);

                            $itemContant.html(itemHtmlContant);

                            $listView.prepend($item);

                        });

                        $("#btnRefreshCount .ui-btn-text").text(data.length);
                    }
                    else {
                        $("#btnRefreshCount .ui-btn-text").text("0");

                        $listView.empty();

                        $noDataView.show();
                    }
                }
                else {
                    alert("调用数据接口失败(VesselPlanList)");
                }

                CustomUnloader();
            });
        }

    </script>

</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <div class="ui-body ui-body-c container-acceptance">
        <div style="display: inline;">
            <asp:TextBox ID="txtAcceptance" runat="server" CssClass="Acceptance"></asp:TextBox>
            <asp:Label ID="lblCustom" runat="server" CssClass="Custom"></asp:Label>
            <asp:DropDownList ID="ddlplanaccept" runat="server" CssClass="planaccept">
                <asp:ListItem Value="aa" Text="请选择受理状态" Selected="True"></asp:ListItem>
                <asp:ListItem Value="Y" Text="已受理"></asp:ListItem>
                <asp:ListItem Value="N" Text="未受理"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listContainerAcceptance">
        </ul>
        <ul data-role="listview" id="NoData">
            <li>
                <a>
                <h3>暂无相关数据</h3>
                <p></p>
                <p></p>
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
