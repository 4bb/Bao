<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_List.aspx.cs"
    Inherits="Shsict.Web.VesselPlan_List" Title="船舶计划查询-类型" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script src="scripts/waypoints.min.js"></script>
    <script src="scripts/json2.js"></script>
    <script type="text/javascript">
        $(function () {
            var ddlImportOrExportFlag = $(".vesselplan-list select.ImportOrExportFlag");
            var ddlVesselType = $(".vesselplan-list select.VesselType");
            var ddlStatus = $(".vesselplan-list select.Status");

            VesselPlanQueryImpl();

            ddlImportOrExportFlag.change(VesselPlanQueryImpl);

            ddlVesselType.change(VesselPlanQueryImpl);

            ddlStatus.change(VesselPlanQueryImpl);

            $("#btnRefreshCount").click(VesselPlanQueryImpl);

        });

        function VesselPlanQueryImpl() {
            CustomLoader();

            var _value1 = $(".vesselplan-list select.ImportOrExportFlag").val();
            var _value2 = $(".vesselplan-list select.VesselType").val();
            var _value3 = $(".vesselplan-list select.Status").val();

            var $listView = $("ul#listVesselPlan");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("Handler/VesselPlanList.ashx", { ImportOrExportFlag: _value1, VesselType: _value2, Status: _value3 }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();
                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {
                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");
                            $item.click(function () {
                                window.location.href = "VesselPlan_Detail.aspx?VesselPlanID=" + entry.ID;

                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = String.format("{0}({1})", entry.VesselName, entry.VesselEnglishName);

                            $itemh3.html(itemHtmlh3);

                            var $itemContant = $item.find("p");
                            var itemHtmlContant = String.format("航次：{0} | 进/出口：{1} | 范围: {2}", entry.VoyageNumber, entry.ImportOrExportFlag == "E" ? "出口" : "进口", entry.VesselPlanStatus);

                            $itemContant.html(itemHtmlContant);

                            $listView.prepend($item);

                        });
                        
                      
                        //$("#btnRefreshCount").removeClass("ui-btn-icon-notext");
                        $("#btnRefreshCount .ui-btn-text").text(data.length);
                        //$("#btnRefreshCount").attr("data-iconpos", "left");
                        //$("#btnRefreshCount").removeAttr("data-iconpos").button();
                       //.button();

                    } else {
                        $("#btnRefreshCount .ui-btn-text").text("0");

                        $listView.empty();

                        $noDataView.show();
                    }
                } else {
                    alert("调用数据接口失败(VesselPlanList)");
                }

                CustomUnloader();
            });
        }

    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <div class="ui-body ui-body-c vesselplan-list">
        <fieldset data-role="controlgroup" data-type="horizontal" data-mini="ture" data-corners="false">
            <legend style="display: none">请选择筛选条件</legend>
            <asp:DropDownList ID="ddlImportOrExportFlag" runat="server" CssClass="ImportOrExportFlag">
                <asp:ListItem Value="" Text="全部" Selected="True"></asp:ListItem>
                <asp:ListItem Value="I" Text="进口"></asp:ListItem>
                <asp:ListItem Value="E" Text="出口"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlVesselType" runat="server" CssClass="VesselType">
                <asp:ListItem Value="" Text="全部"></asp:ListItem>
                <asp:ListItem Value="D" Text="大船" Selected="True"></asp:ListItem>
                <asp:ListItem Value="B" Text="驳船"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="Status">
                <asp:ListItem Value="" Text="全部"></asp:ListItem>
                <asp:ListItem Value="I" Text="在港" Selected="True"></asp:ListItem>
                <asp:ListItem Value="O" Text="离泊"></asp:ListItem>
                <asp:ListItem Value="P" Text="计划"></asp:ListItem>
            </asp:DropDownList>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listVesselPlan">
        </ul>
        <ul data-role="listview" id="NoData">

            <li>
                <a>
                <h3>暂无相关数据</h3>
                <p></p>
              </a>
            </li>
             
        </ul>
    </div>
</asp:Content>
