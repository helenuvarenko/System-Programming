﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page4.aspx.cs" Inherits="lab5.Page4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style type="text/css">

        .col{
            background-color:beige;
        }
    </style>
<body class="col">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelSuccess" runat="server" Text="Label"></asp:Label>
    
    </div>
        <asp:Button ID="ButtonMain" runat="server" OnClick="ButtonMain_Click" Text="НА ГОЛОВНУ" />
    </form>
</body>
</html>
