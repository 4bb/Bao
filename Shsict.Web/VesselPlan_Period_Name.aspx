<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Period_Name.aspx.cs" Inherits="Shsict.Web.VesselPlan_Period_Name" Title="船舶计划查询-船名" Theme="Shsict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var tbPeriodName = $(".VesselPlan_Period_Name .PeriodName");

            tbPeriodName.attr("placeholder", "请输入船舶英文名(ZK19)").blur(VesselPlanQueryImpl).change(VesselPlanQueryImpl);

            tbPeriodName.keydown(function () {
                if (event.keyCode == 13) {
                    VesselPlanQueryImpl();

                    return false;
                }
            });

            VesselPlanQueryImpl();

            $("#btnRefreshCount").click(VesselPlanQueryImpl);
           
        });

        function VesselPlanQueryImpl() {
            CustomLoader();

            var $tbPeriodName = $(".VesselPlan_Period_Name .PeriodName");
            var $listView = $("ul#listVesselPlan");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            var _value = $tbPeriodName.val().trim().toUpperCase();

            $tbPeriodName.val(_value);

            $.getJSON("Handler/VesselPlanPeriodName.ashx", { EnglishName: _value }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();
                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {

                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");
                            $item.click(function () {
                                window.location.href = "VesselPlan_Period_List.aspx?EnglishName=" + entry.EnglishName;

                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.EnglishName;

                            $itemh3.html(itemHtmlh3);

                            $listView.prepend($item);

                        });

                        $("#btnRefreshCount .ui-btn-text").text(data.length );

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
<asp:Content ID="Content2" ContentPlaceHolderID="cphHeader" runat="server">
    <div class="ui-body ui-body-c VesselPlan_Period_Name">
        <div style="display: inline;">
            <asp:TextBox ID="txtPeriodName" runat="server" CssClass="PeriodName"></asp:TextBox>
        </div>
    </div>
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="server">
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
