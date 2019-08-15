<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="User_Form.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<style type="text/css">
		#form1 {
			height: 298px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
		<asp:TextBox ID="TextBox1" runat="server" Height="68px" Width="283px">First operand</asp:TextBox>
    	<asp:TextBox ID="TextBox2" runat="server" Height="67px" Width="240px">Second operand</asp:TextBox>
		<asp:Button ID="Button1" runat="server" Height="70px" OnClick="Button1_Click" Text="Calculate" Width="149px" />
		<br />
		<asp:Label ID="Label1" runat="server" Text="Place for your result. Enjoy!"></asp:Label>
    </form>
</body>
</html>
