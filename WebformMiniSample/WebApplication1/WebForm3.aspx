<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>My title</title>
    <style>
        p:last-child {
            /*color:red;*/
        }

        span {
        }

        #span2 {
            /*color:;*/
        }

        .cls1 {
            color: red;
        }

        .cls2 {
            color: blue;
        }

        p > span {
            background-color: aquamarine
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>p Text1</p>
            <p>
                <span class="cls1">First</span>
                <span id="span2" class="cls1">Second</span>
                <span class="cls2">Third</span>
            </p>
            <p class="cls2">p Text3</p>
            <span>123</span>
        </div>
    </form>
</body>
</html>
