<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShsictThread.aspx.cs" Inherits="Shsict.Web.ShsictThread" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnStart" runat="server" Text="Thread Start" OnClick="btnStart_Click" />
            <asp:Button ID="btnStop" runat="server" Text="Thread Stop" OnClick="btnStop_Click" />
        </div>
        <div>
            <asp:Label ID="lblThreadStatus" runat="server"></asp:Label>
              <asp:Label ID="lblThread" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
