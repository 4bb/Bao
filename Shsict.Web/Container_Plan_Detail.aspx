<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Plan_Detail.aspx.cs" Inherits="Shsict.Web.Container_Plan_Detail" Title="箱货信息查询" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnFavorite").css("display", "block");

            $("span.ObjectID").text(GetQueryString("ContainerID"));

            $("span.ObjectType").text("ContainerDetail");

            $(".ArriveISLate").css("color", "#da2419");

            CustomLoader();
            $.getJSON("Handler/ContainerPlanDetail.ashx", { ContainerID: GetQueryString("ContainerID") }, function (data, status, xhr) {
                if (status == "success" && data != null) {
                    if (data.result != "error" && JSON.stringify(data) != "[]") {
                    
                        if (data.ArriveISLate.toUpperCase() == 'Y')
                        {
                            $(".ArriveTime").append("<span style=\"color:#da2419\">(晚)</span>");

                        }
                        $(".CTNSize").text(data.CTNSize);
                        $(".CTNType").text(data.CTNType);
                        $(".CTNHeight").text(data.CTNHeight);
                        $(".CTNStat").text(data.CTNStat);
                        $(".SealNO").text(data.SealNO);
                        $(".BLNO").html(data.BLNO);
                        if ($(".table-stroke td#blno").find("br").length > 0) {
                            $(".table-stroke td#blno").addClass("multiField");
                        }
                        $(".CTNNetWeight").text (data.CTNNetWeight);
                        $(".RCTemerature").text (data.RCTemerature);
                        $(".DGType").text(data.DGType);
                        $(".CTNOwner").text (data.CTNOwner);
                        $(".CTNIOType").text(data.CTNIOType);
                        $(".PlanWorkTime").text(timeStamp2String(data.PlanWorkTime));

                        $(".TCTNEmpty").text (timeStamp2String(data.TCTNEmpty));
                        $(".RCTNEmpty").text (data.RCTNEmpty);
                        $(".FirstVVessel").text (data.FirstVVessel);
                        $(".FirstVVoyage").text (data.FirstVVoyage);
                        $(".SecondVVessel").text (data.SecondVVessel);
                        $(".SecondVVoyage").text (data.SecondVVoyage);
                        $(".LoadingPort").text ( data.LoadingPort);
                        $(".DischargingPort").text (data.DischargingPort);
                        $(".DestinationPort").text(data.DestinationPort);
                        $(".OverCTNType").text(data.OverCTNType);
                        $(".OverWeight").text(data.OverWeight);
                        $(".OverHeight").text(data.OverHeight);
                        $(".FOL").text(data.FOL);
                        $(".BOL").text(data.BOL);
                        $(".LOW").text( data.LOW);
                        $(".RoWidth").text (data.RoWidth);

                    }
                    else {

                    }
                }
                else {
                    alert("调用数据接口失败(VesselPlanList)");
                }

                CustomUnloader();
            });


        });
    </script>
</asp:Content>

<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>

<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Panel ID="pnlContainerNo" CssClass="banner5 banner1" runat="server">
            <asp:Label ID="lblContainerNo" runat="server" Text=""></asp:Label>
        </asp:Panel>

        <div data-role="collapsible" data-inset="false" data-collapsed="false">
            <h3 class="tit">箱动态</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="persist">进场时间</th>
                        <th data-priority="2">出场时间</th>
                        <th data-priority="3">进场方式</th>
                        <th data-priority="4">出场方式</th>
                        <th data-priority="5">放关</th>
                        <th data-priority="6">配船</th>
                        <th data-priority="7">箱号</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblArriveTime" runat="server" CssClass="ArriveTime" ></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDeparTureTime" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblArriveType" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDepartureType" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCustomsCLearance" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVesselID" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCNo" runat="server"></asp:Label>
                        </td>

                    </tr>
                </tbody>
            </table>
        </div>

        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">基本信息</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="persist">尺寸</th>
                        <th data-priority="2">箱型</th>
                        <th data-priority="3">高度</th>
                        <th data-priority="4">状态</th>
                        <th data-priority="5">铅封号</th>
                        <th data-priority="6">提单号</th>
                        <th data-priority="7">重量</th>
                        <th data-priority="8">冷藏箱温度</th>
                        <th data-priority="9">危险品类型</th>
                        <th data-priority="10">持箱人</th>
                        <th data-priority="11">计划作业方式</th>
                        <th data-priority="12">计划作业时间</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblCTNSize" runat="server" CssClass="CTNSize"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNType" runat="server" CssClass="CTNType"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNHeight" runat="server" CssClass="CTNHeight"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNStat" runat="server"   CssClass="CTNStat"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSealNO" runat="server" CssClass="SealNO"></asp:Label></td>

                        <td id="blno">
                            <asp:Label ID="lblBLNO" runat="server"  CssClass="BLNO"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNNetWeight" runat="server"  CssClass="CTNNetWeight"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRCTemerature" runat="server"  CssClass="RCTemerature"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDGType" runat="server"  CssClass="DGType"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNOwner" runat="server"  CssClass="CTNOwner"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCTNIOType" runat="server"  CssClass="CTNIOType"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPlanWorkTime" runat="server"  CssClass="PlanWorkTime"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">船舶相关</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="1">箱变空时间</th>
                        <th data-priority="2">箱变空原因</th>
                        <th data-priority="3">一程船名</th>
                        <th data-priority="4">一程船航次</th>
                        <th data-priority="5">二程船名</th>
                        <th data-priority="6">二程船航次</th>
                        <th data-priority="7">装货港</th>
                        <th data-priority="8">卸货港</th>
                        <th data-priority="9">目的港</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblTCTNEmpty" runat="server" CssClass="TCTNEmpty"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRCTNEmpty" runat="server" CssClass="RCTNEmpty"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFirstVVessel" runat="server" CssClass="FirstVVessel"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFirstVVoyage" runat="server" CssClass="FirstVVoyage"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSecondVVessel" runat="server" CssClass="SecondVVessel"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblSecondVVoyage" runat="server" CssClass="SecondVVoyage"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblLoadingPort" runat="server" CssClass="LoadingPort"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDischargingPort" runat="server" CssClass="DischargingPort"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblDestinationPort" runat="server" CssClass="DestinationPort"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">超限信息</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="persist">超限箱类型</th>
                        <th data-priority="1">超重</th>
                        <th data-priority="2">超高</th>
                        <th data-priority="3">前超长</th>
                        <th data-priority="4">后超长</th>
                        <th data-priority="5">左超宽</th>
                        <th data-priority="6">右超宽</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblOverCTNType" runat="server" CssClass="OverCTNType"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblOverWeight" runat="server" CssClass="OverWeight"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblOverHeight" runat="server" CssClass="OverHeight"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblFOL" runat="server" CssClass="FOL"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblBOL" runat="server" CssClass="BOL"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblLOW" runat="server" CssClass="LOW"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRoWidth" runat="server" CssClass="RoWidth"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
