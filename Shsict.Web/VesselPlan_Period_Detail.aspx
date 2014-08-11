<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Period_Detail.aspx.cs" Inherits="Shsict.Web.VesselPlan_Period_Detail" Title="船舶计划查询_船名" Theme="Shsict" %>


<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
        <script type="text/javascript">
            $(function () {
                $("#btnFavorite").css("display", "block");

                $("span.ObjectID").text(GetQueryString("VesselPlanID"));

                $("span.ObjectType").text("VesselPlan");
            });
    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content" class="ui-content" role="main">
        <asp:Panel ID="pnlVesselName" CssClass="banner4 banner1" runat="server">
            <asp:Label ID="lblVesselName" runat="server" Text=""> </asp:Label>
        </asp:Panel>
        <table data-role="table" class="table-stroke detail-list">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="yn">
                        <asp:Label ID="lblVoyageNumber" runat="server"></asp:Label>                        
                        <div class="fieldLabel">航次</div>
                    </td>
                    <td class="i-e">
                        <asp:Label ID="lblImportOrExport" runat="server"></asp:Label>
                        <div class="fieldLabel">进出口</div>
                    </td>
                    <td class="arrive-p-t">
                        <asp:Label ID="lblArrivePlanTime" runat="server"></asp:Label>
                        <div class="fieldLabel">计划靠泊</div>
                    </td>
                    <td class="arrive-a-t">
                        <asp:Label ID="lblArriveActualTime" runat="server"></asp:Label>
                        <div class="fieldLabel">实际靠泊</div>
                    </td>
                    <td class="departure-p-t">
                        <asp:Label ID="lblDeparturePlanTime" runat="server"></asp:Label>
                        <div class="fieldLabel">计划离泊</div>
                    </td>
                    <td class="departure-a-t">
                        <asp:Label ID="lblDepartureActualTime" runat="server"></asp:Label>
                        <div class="fieldLabel">实际离泊</div>
                    </td>
                    <td class="customs-c">
                        <asp:Label ID="lblIsCustomsClosing" runat="server"></asp:Label>
                        <div class="fieldLabel">已截关</div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>


