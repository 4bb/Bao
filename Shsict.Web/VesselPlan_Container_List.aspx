<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Container_List.aspx.cs" Inherits="Shsict.Web.VesselPlan_Container_List" Title="进箱计划查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            VesselPlanQueryImpl();

            var tbContainerTrace = $(".Vessel-Name .VesselName");

            tbContainerTrace.attr("placeholder", "请输入船名(淮海)").blur(VesselPlanQueryImpl).change(VesselPlanQueryImpl);

            tbContainerTrace.keydown(function () {
                if (event.keyCode == 13) {
                    VesselPlanQueryImpl();

                    return false;
                }
            });

            $("#btnRefreshCount").click(VesselPlanQueryImpl);

            if ($("div#menu").length > 0)
            {
                $("div.remind").css("bottom", "13%");

            }
        });

        function VesselPlanQueryImpl() {
            CustomLoader();

            var $tbVesselName = $(".Vessel-Name .VesselName");
            var $listView = $("ul#listVesselPlan");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();
            var _value = $(".Vessel-Name .VesselName").val().trim().toUpperCase();

            $tbVesselName.val(_value)

            $.getJSON("Handler/VesselPlanContainerList.ashx", { VN: _value }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();

                        $noDataView.hide();
                        
                        $.each(data, function (entryIndex, entry) {
                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");

                            $item.click(function () {
                                window.location.href = "VesselPlan_Container_Detail.aspx?VesselPlanID=" + entry.ID;
                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = String.format("{0}({1})", entry.VesselName, entry.VesselEnglishName);

                            $itemh3.html(itemHtmlh3);

                            var $itemContant = $item.find("p");

                            var itemHtmlContant = "";

                            if (entry.ContainerStatus.toUpperCase()=="W") {

                                itemHtmlContant = String.format("航次：{0} | <span class=\"will\">进箱开始时间：{1} </span>", entry.VoyageNumber, timeStamp2String(entry.ContainerBeginTime));
                            }
                            else if (entry.ContainerStatus.toUpperCase() == "G") {
                                itemHtmlContant = String.format("航次：{0} | <span class=\"going\">进箱开始时间：{1} </span>", entry.VoyageNumber, timeStamp2String(entry.ContainerBeginTime));
                            }
                            else {
                                itemHtmlContant = String.format("航次：{0} | 进箱开始时间：{1} ", entry.VoyageNumber, timeStamp2String(entry.ContainerBeginTime));
                            }

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
    <div class="ui-body ui-body-c Vessel-Name">
        <div style="display: inline;">
            <asp:TextBox ID="txtVesselName" runat="server" CssClass="VesselName"></asp:TextBox>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">

    <div data-role="content">
        <div class="remind">
    	<ul class="clearfix">
        	<li><i class="blue"></i>进行中</li>
        	<li><i class="red"></i>未开始</li>
        	<li><i class="black"></i>已截至</li>
        </ul>
    </div>

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
