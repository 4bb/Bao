<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_ArrangeTime_List.aspx.cs" Inherits="Shsict.Web.Container_ArrangeTime_List" Title="直装直提计划" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">

        $(function () {
            var tbContainerArrangeTime = $(".container-arrangeTime .ArrangeTime");
            var ddlplanaccept = $(".container-arrangeTime select.planno");
            var counts = 0;

            tbContainerArrangeTime.attr("placeholder", "请输入申请编号|计划号").blur(QueryImpl).change(QueryImpl);

            QueryImpl();

            tbContainerArrangeTime.keydown(function () {
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

            var $tbArrangeTime = $(".container-arrangeTime .ArrangeTime");
            var _value1 = $tbArrangeTime.val().trim().toUpperCase();
            var _value2 = $(".container-arrangeTime select.planno").val();
            var _value3 = $(".container-arrangeTime .Custom").text();

            $tbArrangeTime.val(_value1);

            var $listView = $("ul#listContainerArrangeTime");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("Handler/ContainerArrangeTimeList.ashx", { ArrangeTime: _value1, NoType: _value2, Custom: _value3 }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();

                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {
                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");

                            $item.click(function () {
                                window.location.href = String.format("Container_ArrangeTime_Detail.aspx?ArrangeTime={0}&NoType={1}", entry.ID, _value2);

                                CustomLoader();
                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3;
                            var itempLast;


                            if (_value2.toUpperCase().trim() == "A") {
                                itemHtmlh3 = "申请编号：" + entry.ID;
                                itempLast = "计划号：" + entry.PLANNO;

                            }
                            else {
                                itemHtmlh3 = "计划号：" + entry.PLANNO;
                                itempLast = "申请编号：" + entry.ID;
                            }

                            $itemh3.html(itemHtmlh3);
                            var $itemp = $item.find("p").first();
                            var itemHtmlp = "船名/航次：" + entry.VESSELVOYAGE;
                            $itemp.html(itemHtmlp);

                            var $itemContant = $item.find("p").next();
                            var itemHtmlContant = "计划直装时间：" + timeStamp2String(entry.TVDATE);
                            $itemContant.html(itemHtmlContant);

                            var $itempLast = $item.find("p").last();
                            $itempLast.html(itempLast);

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
    <div class="ui-body ui-body-c container-arrangeTime">
        <div style="display: inline;">
            <asp:TextBox ID="txtArrangeTime" runat="server" CssClass="ArrangeTime"></asp:TextBox>
            <asp:Label ID="lblCustom" runat="server" CssClass="Custom"></asp:Label>
            <asp:DropDownList ID="ddlplanno" runat="server" CssClass="planno">
                <asp:ListItem Value="A" Text="申请编号" Selected="True"></asp:ListItem>
                <asp:ListItem Value="P" Text="计划号"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>

<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listContainerArrangeTime">
        </ul>
        <ul data-role="listview" id="NoData">
            <li>
                <a>
                    <h3>暂无相关数据</h3>
                    <p></p>
                    <p></p>
                    <p></p>
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
