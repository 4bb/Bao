<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Detail.aspx.cs" Inherits="Shsict.Web.VesselPlan_Detail" Title="船舶计划详细" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnFavorite").css("display", "block");

            $("span.ObjectID").text(GetQueryString("VesselPlanID"));

            $("span.ObjectType").text("VesselPlan");
        });
    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content" class="ui-content" role="main">
        <asp:Panel ID="pnlVesselName" CssClass="banner4 banner1"  runat="server">
            <asp:Label ID="lblVesselName"   runat="server"> </asp:Label>
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
                    <asp:Label ID="lblArriveTime" runat="server"></asp:Label>
                    <asp:Label ID="lblDepartureTime" runat="server"></asp:Label>
                    <asp:Label ID="lblBerth" runat="server"></asp:Label>
                    <asp:Label ID="lblCustomsClosing" runat="server"></asp:Label>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
