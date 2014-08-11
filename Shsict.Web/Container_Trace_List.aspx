<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Trace_List.aspx.cs" Inherits="Shsict.Web.Container_Trace_List" Title="进箱信息跟踪" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            var tbContainerTrace = $(".container-trace .ContainerTrace");
            var ddlContainerNoOrbill = $(".container-trace select.ddlContainerNoOrbill");

            if (tbContainerTrace.val().trim() != "") {
                QueryImpl();
            }

            tbContainerTrace.attr("placeholder", "请输入箱号(IRSU2611715)/提单号").blur(QueryImpl).change(QueryImpl);

            tbContainerTrace.keydown(function () {
                if (event.keyCode == 13)
                {
                    QueryImpl();

                    return false;
                }
            });

            ddlContainerNoOrbill.change(QueryImpl);  
        });

        function QueryImpl() {
            CustomLoader();

            var $tbContainerNoOrbill = $(".container-trace .ContainerTrace");
            var _value1 = $tbContainerNoOrbill.val().trim().toUpperCase();
            var _value2 = $(".container-trace select.ddlContainerNoOrbill").val();

            $tbContainerNoOrbill.val(_value1);

            var $listView = $("ul#listContainerTrace");
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
                                window.location.href = String.format("Container_Trace_Detail.aspx?ContainerID={0}", entry.ID);

                                CustomLoader();
                            });

                            var $itemh3 = $item.find("h3");
                            var itemHtmlh3 = entry.ContainerNo;

                            $itemh3.html(itemHtmlh3);

                            var $itemp = $item.find("p");
                            var itemHtmlp = "进港时间:" + timeStamp2String(entry.ArrivalContainerTime);

                            $itemp.html(itemHtmlp);

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
            <asp:TextBox ID="txtContainerTrace" runat="server" CssClass="ContainerTrace"></asp:TextBox>
            <asp:DropDownList ID="ddlContainerNoOrbill" runat="server" CssClass="ddlContainerNoOrbill">
                <asp:ListItem Value="c" Text="箱号" Selected="True"></asp:ListItem>
                <asp:ListItem Value="b" Text="提单号"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <ul data-role="listview" id="listContainerTrace"></ul>
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
