<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShtictHeader.ascx.cs" Inherits="Shsict.Web.Control.ShtictHeader" %>
<div id="header" data-theme="b" data-role="header" data-position="fixed" class="header">
    <h6>
        <asp:Label ID="lbltitle" runat="server"></asp:Label>
    </h6>

    <asp:HyperLink ID="btnBack" runat="server" CssClass="ui-btn-left but_back"></asp:HyperLink>

<%--    <a id="but_back" data-role="button" data-inline="true" data-rel="external"
        data-transition="slidedown" href="Portal.aspx" data-icon="arrow-l"
        style="display: none" data-iconpos="notext" data-mini="true"></a>--%>


</div>
