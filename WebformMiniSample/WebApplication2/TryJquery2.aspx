﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryJquery2.aspx.cs" Inherits="WebApplication2.TryJquery2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".pp").click(function () {
                $(this).hide('slow');
            });

            $("#btn1").click(function () {
                //$(".pp").show('fast');
                $(".pp").show('1300').css("color", "red").css("font-size", "24pt");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>If you click on me, I will disappear.</p>
            <p class="pp">Click me away!</p>
            <p class="pp">Click me too!</p>
            <p class="pp">Click me too!</p>
            <p class="pp">Click me too!</p>
            <p class="pp" id="p1">Click</p>

            <button type="button" id="btn1">ClickMe</button>

        </div>
    </form>
</body>
</html>
