<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Trace_Detail.aspx.cs" Inherits="Shsict.Web.Container_Trace_Detail" Title="进箱信息跟踪" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
                <script type="text/javascript">
                    $(function () {
                        $("#btnFavorite").css("display", "block");

                        $("span.ObjectID").text(GetQueryString("ContainerID"));

                        $("span.ObjectType").text("ContainerMain");
                    });
    </script>
</asp:Content>
<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Panel ID="pnlContainerNo" CssClass="banner5 banner1" runat="server">
            <asp:Label ID="lblContainerNo" runat="server"> </asp:Label>
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
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="vessel-n">
                        <asp:Label ID="lblVesselName" runat="server"></asp:Label>
                        <div class="fieldLabel">船名</div>
                    </td>
                    <td class="yn">
                        <asp:Label ID="lblVoyageNumber" runat="server"></asp:Label>
                        <div class="fieldLabel">航次</div>
                    </td>
                    <td class="arrive-type">
                        <asp:Label ID="lblArriveType" runat="server"></asp:Label>
                        <div class="fieldLabel">进场方式</div>
                    </td>
                    <td class="departure-type">
                        <asp:Label ID="lblDepartureType" runat="server"></asp:Label>
                        <div class="fieldLabel">出场方式</div>
                    </td>


                    <asp:Panel ID="pnlImport" runat="server" Visible="false">
                        <td class="arrive-t">
                            <asp:Label ID="lblArriveTime" runat="server"></asp:Label>
                            <div class="fieldLabel">进场时间</div>
                        </td>
                        <td class="customs-c-t">
                            <asp:Label ID="lblDepartTime" runat="server"></asp:Label>
                            <div class="fieldLabel">出场时间</div>
                        </td>
                    </asp:Panel>
                    <asp:Panel ID="pnlExport" runat="server" Visible="false">
                        <td class="arrival-c-t">
                            <asp:Label ID="lblArrivalContainerTime" runat="server"></asp:Label>
                            <div class="fieldLabel">进箱时间</div>
                        </td>
                     <%--   <td class="customs">
                            <asp:Label ID="lblCustoms" runat="server"></asp:Label>
                            <div class="fieldLabel">用户</div>
                        </td>--%>
                        <td class="customs-c-t">
                            <asp:Label ID="lblCustomsClearanceTime" runat="server"></asp:Label>
                            <div class="fieldLabel">放关时间</div>
                        </td>
                        <td class="stowage-t">
                            <asp:Label ID="lblStowageTime" runat="server"></asp:Label>
                            <div class="fieldLabel">配船时间</div>
                        </td>
                        <td class="vessel-t">
                            <asp:Label ID="lblVesselTime" runat="server"></asp:Label>
                            <div class="fieldLabel">装船时间</div>
                        </td>
                    </asp:Panel>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
