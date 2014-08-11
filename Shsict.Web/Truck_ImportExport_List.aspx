<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Truck_ImportExport_List.aspx.cs" Inherits="Shsict.Web.Truck_ImportExport_List" Title="外集卡进出查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var tbTruckImportExport = $(".Truck .Truck-ImportExport");

            if (tbTruckImportExport.val().trim() != "") {
                QueryImpl();
            }

            tbTruckImportExport.keydown(function () {
                if (event.keyCode == 13) {
                    QueryImpl();

                    return false;
                }
            });

            tbTruckImportExport.attr("placeholder", "请输入集卡号(沪D57372)").blur(QueryImpl).change(QueryImpl);

         
            $("#btnRefreshCount").click(QueryImpl);
    
        });

        function QueryImpl() {
            CustomLoader();

            var $tbTruckNo = $(".Truck .Truck-ImportExport");
            var _value = $tbTruckNo.val().trim().toUpperCase();

            $tbTruckNo.val(_value)

            var $listView = $("ul#listTruck");
            var $noDataView = $("ul#NoData").hide();
            var $itemTemplate = $noDataView.find("li").first();

            $.getJSON("Handler/TruckImportExportList.ashx", { Truck: _value }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                        $listView.empty();

                        $noDataView.hide();

                        $.each(data, function (entryIndex, entry) {
                            var $item = $itemTemplate.clone();

                            $item.css("cursor", "pointer");

                            $item.click(function () {
                                window.location.href = "Truck_ImportExport_Detail.aspx?TruckID=" + entry.ID;

                                CustomLoader();
                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.TruckNo;

                            $itemh3.html(itemHtmlh3);

                            var $itemP = $item.find("p").first();
                            var itemHtmlP = String.format("进堆场时间：{0} ", timeStamp2String(entry.ArriveYardTime));

                            $itemP.html(itemHtmlP);

                            var $itemContant = $item.find("p").next();
                            var itemHtmlContant = String.format("出堆场时间：{0}", timeStamp2String(entry.DepartureYardTime));

                            $itemContant.html(itemHtmlContant);

                            $listView.prepend($item);

                        });
                      
                        $("#btnRefreshCount .ui-btn-text").text(data.length );
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
    <div class="ui-body ui-body-c Truck">
        <div style="display: inline;">
            <asp:TextBox ID="txtTruckImportExport" runat="server" CssClass="Truck-ImportExport"></asp:TextBox>
        </div>
    </div>
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listTruck">
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
