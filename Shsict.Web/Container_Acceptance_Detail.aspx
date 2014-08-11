<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_Acceptance_Detail.aspx.cs" Inherits="Shsict.Web.Container_Acceptance_Detail" Title="特种箱受理情况" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnFavorite").css("display", "block");

            $("span.ObjectID").text(GetQueryString("ContainerID"));

            $("span.ObjectType").text("ContainerPlan");
        });
    </script>
</asp:Content>

<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>

<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Panel ID="pnlContainerNo" CssClass="banner5 banner1" runat="server">
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
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="yn">
                        <asp:Label ID="lblVoyageNumber" runat="server"></asp:Label>
                        <div class="fieldLabel">船名|航次</div>
                    </td>
                    <td class="operation">
                        <asp:Label ID="lbloperation" runat="server"></asp:Label>
                        <div class="fieldLabel">作业方式</div>
                    </td>
                    <td class="plan-accept">
                        <asp:Label ID="lblplanaccept" runat="server"></asp:Label>
                        <div class="fieldLabel">计划是否受理</div>
                    </td>
                    <td class="plan-no">
                        <asp:Label ID="lblplanno" runat="server"></asp:Label>
                        <div class="fieldLabel">计划号</div>
                    </td>
                    <td class="customs">
                        <asp:Label ID="lblcustom" runat="server"></asp:Label>
                        <div class="fieldLabel">客户名字</div>
                    </td>
                    <td class="plan-t">
                        <asp:Label ID="lblPlanTime" runat="server"></asp:Label>
                        <div class="fieldLabel">申请/实际进港时间</div>
                    </td>
                    <td class="plan-a-t">
                        <asp:Label ID="lblPlanAcceptTime" runat="server"></asp:Label>
                        <div class="fieldLabel">进港结束时间</div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
