<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shsict.Web.Login" Title="用户登录" Theme="Shsict" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="scripts/jquery.mobile/jquery.mobile-1.3.2.min.css" rel="stylesheet" />
    <script src="scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.mobile-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/shsict.js" type="text/javascript"></script>

</head>
<body class="loading">
    <form id="form1" runat="server">
        <div data-role="page">
            <div class="main">
                <div class="login">
                    <script type="text/javascript">
                        $(function () {
                            var $tbuser = $(".ui-corner-all #tbun");
                            var $tbpass = $(".ui-corner-all #tbpass");
                            var $lblNextURL = $("#lblNextURL");
                            $lblNextURL.css("display", "none");
                            var $lblwrong = $("#lblwrong");

                            $tbuser.change(function () {
                                var _value = $tbuser.val().trim().toUpperCase();
                                $tbuser.val(_value);

                            });

                            $tbpass.change(function () {
                                var _value = $tbpass.val().trim().toUpperCase();
                                $tbpass.val(_value);
                            });



                            $("#btnLogin").click(function () {
                                $.get("Handler/LoginHandler.ashx", { Method: "Login", UserName: $tbuser.val(), PassWord: $tbpass.val() }, function (data, status, xhr) {
                                    if (status == "success" && data != null) {
                                        if (data.trim() != "failed") {
                                            $lblwrong.css("display", "none");

                                            if (typeof Mobile != 'undefined') {
                                                Mobile.setUser($tbuser.val());

                                            }

                                            //document.location = "objc://setUser/" + $tbuser.val() + "," + $lblNextURL.text();

                                            if ($lblNextURL.text() != "") {
                                                window.location.href = $lblNextURL.text();
                                            }
                                            else {
                                                window.location.href = "Portal.aspx";
                                            }
                                        }
                                        else {
                                            $lblwrong.text("错误用户名或密码");
                                            $lblwrong.css("display", "block");
                                        }
                                    }
                                    else {
                                        alert("调用接口失败(DefaultHandler.ashx)");
                                    }
                                });
                            });

                            $("#btnLogout").click(function () {
                                $.get("Handler/LoginHandler.ashx", { Method: "Logout" }, function (data, status, xhr) {
                                    if (status == "success" && data != null) {
                                        if (data.trim() == "succeed") {
                                            window.location.href = "Portal.aspx";
                                        }
                                    } else {
                                        alert("调用接口失败(DefaultHandler.ashx)");
                                    }
                                });
                            });
                        });
                    </script>
                    <div class=" ui-corner-all ui-shadow con">
                        <h3>用户登录</h3>
                        <label for="lblun" class="ui-hidden-accessible">Username:</label>
                        <asp:TextBox ID="tbun" runat="server" data-theme="b"></asp:TextBox>

                        <label for="lblpw" class="ui-hidden-accessible">Password:</label>
                        <input type="password" id="tbpass" data-theme="b" />

                        <button id="btnLogin" data-role="button" data-inline="true" onclick="return false;">登录</button>
                        <button id="btnLogout" data-role="button" data-inline="true" onclick="return false;">登出 </button>
                    </div>
                    <div id="lblwrong" style="display: none"></div>
                    <asp:Label ID="lblNextURL" runat="server"></asp:Label>


                </div>
            </div>
        </div>
    </form>
</body>
</html>
