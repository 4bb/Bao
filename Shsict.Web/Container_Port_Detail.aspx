<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Port_Detail.aspx.cs" Inherits="Shsict.Web.Container_Port_Detail" Title="运抵报告发送情况" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
           <script type="text/javascript">
               $(function () {
                   $("#btnFavorite").css("display", "block");

                   $("span.ObjectID").text(GetQueryString("ContainerID"));

                   $("span.ObjectType").text("ContainerEload");

                   var lblBillOfLadingNum = $("span.BillOfLadingNum");

                   if (lblBillOfLadingNum.html() == "" || lblBillOfLadingNum.html().indexOf("<br>") < 0) {
                       lblBillOfLadingNum.addClass("h30");

                   }
               });
       </script>
</asp:Content>

<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">

    <div data-role="content">
        <asp:Panel ID="pnlContainerNo" CssClass="banner6 banner1" runat="server">
            <asp:Label ID="lblContainerNo" runat="server" Text=""> </asp:Label>
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
                    <td class="vessel-ID">
                        <asp:Label ID="lblVesselName" runat="server"></asp:Label>
                        <div class="fieldLabel">船名</div>
                    </td>
                    <td class="yn">
                        <asp:Label ID="lblVoyageNumber" runat="server"></asp:Label>
                        <div class="fieldLabel">航次</div>
                    </td>
                    <td class="lading-NO multiField">
                        <div class="fieldLabel">提单号</div>
                        <asp:Label ID="lblBillOfLadingNum" CssClass="BillOfLadingNum" runat="server" ></asp:Label>

                    </td>

                    <td class="arrive-y-t">
                        <asp:Label ID="lblArrivalPortTime" runat="server"></asp:Label>
                        <div class="fieldLabel">进港时间</div>
                    </td>
                    <td class="arrival-port-t">
                        <asp:Label ID="lblSendPackingListTime" runat="server"></asp:Label>
                        <div class="fieldLabel">装箱单发送时间</div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
