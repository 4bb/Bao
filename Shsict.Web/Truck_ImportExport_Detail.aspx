<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Truck_ImportExport_Detail.aspx.cs" Inherits="Shsict.Web.Truck_ImportExport_Detail" Title="外集卡进出查询" Theme="Shsict" %>
<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
       <script type="text/javascript">
           $(function () {
               $("#btnFavorite").css("display", "block");

               $("span.ObjectID").text(GetQueryString("TruckID"));

               $("span.ObjectType").text("Truck");
           });
    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Panel ID="pnlTruckNo" CssClass="banner6 banner1" runat="server">
            <asp:Label ID="lblTruckNo" runat="server" Text=""> </asp:Label>
        </asp:Panel>
        <table data-role="table" class="table-stroke detail-list">
            <thead>
                <tr>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="arrive-y-t">
                        <asp:Label ID="lblArriveYardTime" runat="server"></asp:Label>
                        <div class="fieldLabel">进堆场时间</div>
                    </td>
                    <td class="departure-y-t">
                        <asp:Label ID="lblDepartureYardTime" runat="server"></asp:Label>
                        <div class="fieldLabel">出堆场时间</div>
                    </td>
                     <td class="Fcontainer">
                        <asp:Label ID="lblFcontainer" runat="server"></asp:Label>
                        <div class="fieldLabel">前箱</div>
                    </td>
                     <td class="Acontainer">
                        <asp:Label ID="lblAcontainer" runat="server"></asp:Label>
                        <div class="fieldLabel">后箱</div>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
</asp:Content>
