<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Plan_List.aspx.cs" Inherits="Shsict.Web.Container_Plan_List" Title="箱货信息查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var tbContainerAcceptance = $(".container-trace .ContainerNoOrbill");
            var ddlContainerNoOrbill = $(".container-trace select.ddlContainerNoOrbill");

            if (tbContainerAcceptance.val().trim() != "") {
                QueryImpl();
            }

            tbContainerAcceptance.keydown(function () {
                if (event.keyCode == 13) {
                    QueryImpl();

                    return false;
                }
            });

            tbContainerAcceptance.attr("placeholder", "请输入箱号/提单号(IRSU2611715)").blur(QueryImpl).change(QueryImpl);

            ddlContainerNoOrbill.change(QueryImpl);

        });

        function QueryImpl() {
            CustomLoader();

            var $tbContainerNoOrbill = $(".container-trace .ContainerNoOrbill");
            var _value1 = $tbContainerNoOrbill.val().trim().toUpperCase();
            var _value2 = $(".container-trace select.ddlContainerNoOrbill").val();

            $tbContainerNoOrbill.val(_value1);

            var $listView = $("ul#listContainerPlan");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("Handler/ContainerPlanList.ashx", { ContainerNoOrbill: _value1, Type: _value2 }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();

                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {
                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");

                            $item.click(function () {
                                window.location.href = String.format("Container_Plan_Detail.aspx?ContainerID={0}&Type={1}", entry.ID, _value2);
                                CustomLoader();
                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.ContainerNo;

                            $itemh3.html(itemHtmlh3);

                            var $itemp = $item.find("p").first();
                            var itemHtmlp = String.format("进场：{0} | 出场：{1} ", timeStamp2String(entry.ArriveTime), timeStamp2String(entry.DepartureTime));

                            $itemp.html(itemHtmlp);

                            var $itemContant = $item.find("p").next();
                            var itemHtmlContant = String.format("入场方式：{0} | 出场方式：{1}", entry.ArriveType, entry.DepartureType);

                            $itemContant.html(itemHtmlContant);

                            $listView.prepend($item);

                        });
                    }
                    else {
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
    <div class="ui-body ui-body-c container-trace">
        <div style="display: inline;">
            <asp:TextBox ID="txtContainerNoOrbill" runat="server" CssClass="ContainerNoOrbill"></asp:TextBox>
            <asp:DropDownList ID="ddlContainerNoOrbill" runat="server" CssClass="ddlContainerNoOrbill">
                <asp:ListItem Value="c" Text="箱号" Selected="True"></asp:ListItem>
                <asp:ListItem Value="b" Text="提单号"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listContainerPlan"></ul>
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
