<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" CodeBehind="Container_ArrangeTime_Detail.aspx.cs" Inherits="Shsict.Web.Container_ArrangeTime_Detail" Title="直装直提计划" Theme="Shsict" %>

<asp:Content ID="cphScript" ContentPlaceHolderID="cphScript" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#btnFavorite").css("display", "block");

            $("span.ObjectID").text(GetQueryString("ArrangeTime"));

            $("span.ObjectType").text("TVDangerPlan");

            if ($(".table-stroke td#blno").find("br").length > 1) {
                $(".table-stroke td#blno").addClass("multiField");
            }
        });
    </script>
</asp:Content>

<asp:Content ID="cphHeader" ContentPlaceHolderID="cphHeader" runat="server"></asp:Content>

<asp:Content ID="cphContent" ContentPlaceHolderID="cphContent" runat="server">
    <div data-role="content">
        <asp:Panel ID="pnlContainerNo" CssClass="banner5 banner1" runat="server">
            <asp:Label ID="lblTitleNo" runat="server" Text=""></asp:Label>
        </asp:Panel>

        <div data-role="collapsible" data-inset="false" data-collapsed="false">
            <h3 class="tit">基本信息</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                        <th data-priority="1">船名/航次</th>
                        <th data-priority="2"> <asp:Label ID="lblNoName" runat="server"></asp:Label></th>
                        <th data-priority="3">计划靠泊时间</th>
                        <th data-priority="4">计划离泊时间</th>
                        <th data-priority="5">计划直装时间</th>
                        <th data-priority="6">配载直装时间</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                   
                        <td>
                            <asp:Label ID="lblVesselVoyage" runat="server"></asp:Label>
                        </td>
                          <td>
                            <asp:Label ID="lblNo" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblArrivePlanTime" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDeparturePlanTime" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTVDate" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblExActTvDate" runat="server"></asp:Label>
                        </td>

                    </tr>
                </tbody>
            </table>
        </div>


        <div data-role="collapsible" data-inset="false">
            <h3 class="tit">直装箱清单</h3>
            <table data-role="table" data-mode="reflow" class="table-stroke">
                <thead>
                    <tr>
                       
                        <th data-priority="1">箱号</th>

                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td id="blno" style="font-size:16px;">
                            <asp:Label ID="lblContainerNo" runat="server" CssClass="f16"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


    </div>
</asp:Content>

