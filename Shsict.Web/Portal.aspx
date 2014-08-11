<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Portal.aspx.cs" Inherits="Shsict.Web.Portal" Title="上海盛东集装箱码头有限公司" Theme="Shsict" %>


<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content" id="gallery" class="ui-content" role="main">
        <div class="banner2"></div>
        <!--AD-->
        <div class="ui-grid-b">
            <div class="ui-block-a">
                <div class="icon-springboard i_1">
                    <a href="VesselPlan_List.aspx" target="_top">
                        <span class="icon-label" title="查询10天内船舶计划">船舶计划查询-类型</span> </a>
                </div>
            </div>
            <div class="ui-block-b">
                <div class="icon-springboard i_2">
                    <a href="VesselPlan_Period_Name.aspx" target="_top">
                        <span class="icon-label" title="英文船名查询船舶计划">船舶计划查询-船名</span> </a>
                </div>
            </div>
            <div class="ui-block-c">
                <div class="icon-springboard i_3">
                    <a href="VesselPlan_Container_List.aspx" target="_top">
                        <span class="icon-label" title="查询当天前后15天进箱计划">进箱计划查询</span> </a>
                </div>
            </div>
            <div class="ui-block-a">
                <div class="icon-springboard i_4">
                    <a href="Container_Plan_List.aspx" target="_top">
                        <span class="icon-label" title="按箱号提单号查询箱货信息">箱货信息查询</span> </a>
                </div>
            </div>
            <div class="ui-block-b">
                <div class="icon-springboard i_5">
                    <a href="Container_Trace_List.aspx" target="_top">
                        <span class="icon-label" title="按箱号提单号实时推送箱子信息">进箱信息跟踪</span> </a>
                </div>
            </div>
            <div class="ui-block-c">
                <div class="icon-springboard i_6">
                    <a href="Container_Acceptance_List.aspx" target="_top">
                        <span class="icon-label" title="按受理计划号查询特种箱信息">特种箱受理情况</span> </a>
                </div>
            </div>
            <div class="ui-block-a">
                <div class="icon-springboard i_7">
                    <a href="Container_Port_List.aspx" target="_top">
                        <span class="icon-label" title="按箱号提单号查询运抵报告">运抵报告发送情况</span> </a>
                </div>
            </div>
            <div class="ui-block-b">
                <div class="icon-springboard i_8">
                    <a href="Container_ArrangeTime_List.aspx" target="_top">
                        <span class="icon-label" title="按箱号提单号查询直装直提计划">直装直提计划</span> </a>
                </div>
            </div>
            <div class="ui-block-c">
                <div class="icon-springboard i_9">
                    <a href="Truck_ImportExport_List.aspx" target="_top">
                        <span class="icon-label" title="按集卡号查询外集卡进出情况">外集卡进出查询</span> </a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
