<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="VesselPlan_Container_Detail.aspx.cs" Inherits="Shsict.Web.VesselPlan_Container_Detail" Title="进箱计划查询" Theme="Shsict" %>


<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
            <script type="text/javascript">
                $(function () {
                    $("#btnFavorite").css("display", "block");

                    $("span.ObjectID").text(GetQueryString("VesselPlanID"));

                    $("span.ObjectType").text("VesselPlan");
       
                    var containerBeginTime = $("td.container-b-t");
                    var beginTime = Date.parse(containerBeginTime.text().replace("进箱开始", "").trim());
                    var dueTime = Date.parse($("td.container-d-t").text().replace("进箱截止", "").trim());
 
                    if (beginTime != "" && dueTime!="") {
                        if (beginTime > Date.now()) {

                            containerBeginTime.css("color","#da2419");
                        }
                        else if (beginTime < Date.now() && dueTime > Date.now()) {
                            containerBeginTime.css("color", "#1767b3");
                        }
                        else {

                            containerBeginTime.css("color", "black");
                        }
                
                    }
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
                    
                    <asp:Repeater ID="rptth" runat="server"  >
                        <ItemTemplate>
                            <th>&nbsp;</th>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="csi">
                        <asp:Label ID="lblCSI" runat="server"></asp:Label>
                          <div class="fieldLabel">CSI</div>
                    </td>
                    <td class="yn">
                        <asp:Label ID="lblVoyageNumber" runat="server"></asp:Label>
                         <div class="fieldLabel">航次</div>
                    </td>
                    <td class="i-e">
                        <asp:Label ID="lblImportOrExport" runat="server"></asp:Label>
                         <div class="fieldLabel">进出口</div>
                    </td>
                    <td class="container-b-t">
                        <asp:Label ID="lblContainerBeginTime" runat="server"></asp:Label>
                         <div class="fieldLabel">进箱开始</div>
                    </td>
                    <td class="container-d-t">
                        <asp:Label ID="lblContainerDeadLine" runat="server"></asp:Label>
                         <div class="fieldLabel">进箱截止</div>
                    </td>
                    <td class="agency">
                        <asp:Label ID="lblAgency" runat="server"></asp:Label>
                        <div class="fieldLabel">代理</div>
                    </td>
                    <td class="port-ID">  
                        <div class="fieldLabel">挂靠港</div>
                    </td>
                    
                    <asp:Repeater ID="rptPortOfCall" runat="server" OnItemDataBound="rptPortOfCall_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="ltrlPortOfCall" runat="server"></asp:Literal>
                        </ItemTemplate>                                 
                    </asp:Repeater>
                </tr>
            </tbody>
        </table>
    </div>

</asp:Content>
