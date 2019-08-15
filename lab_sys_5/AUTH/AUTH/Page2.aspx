<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="lab5.Page2" %>

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
	<%--<script type="text/javascript">
        function hideButton()
		{
			document.get
        }
    </script>--%>
<body class="col">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            <span lang="UK" style="font-size:10.0pt;line-height:
115%;font-family:&quot;Courier New&quot;;mso-fareast-font-family:Calibri;mso-ansi-language:UK;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">Фото (формату JPEG/PNG, min 100x150, max 200x300):</span></p>
        <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" Width="380px" />
        <asp:Label ID="LabelImg" runat="server"></asp:Label>
        <p>
            <asp:Label ID="LabelName" runat="server" Text="Ім'я:"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server" OnTextChanged="TextBox1_TextChanged" Width="224px"></asp:TextBox>
        </p>
        <asp:Label ID="LabelSurname" runat="server" Text="Прізвище:"></asp:Label>
        <asp:TextBox ID="TextBoxSurname" runat="server" Width="173px"></asp:TextBox>
        <p>
            <asp:Label ID="LabelEmail" runat="server" Text="E-mail:"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" Width="199px"></asp:TextBox>
        </p>
        <asp:Label ID="LabelLogin" runat="server" Text="Логін:"></asp:Label>
        <asp:TextBox ID="TextBoxLogin" runat="server" Width="205px"></asp:TextBox>
        <p>
            <asp:Label ID="LabelPassword" runat="server" Text="Пароль:"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" type="password" Width="193px"></asp:TextBox>
        </p>
        <p>
            <asp:RadioButtonList ID="RadioButtonList" runat="server" OnSelectedIndexChanged="RadioButtonList_SelectedIndexChanged" >
                <asp:ListItem>Студент</asp:ListItem>
                <asp:ListItem>Викладач</asp:ListItem>
                <asp:ListItem>Навчально-допоміжний персонал</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:CheckBoxList ID="CheckBoxList" runat="server">
                <asp:ListItem>Майстер спорту</asp:ListItem>
                <asp:ListItem>Кандидат наук</asp:ListItem>
                <asp:ListItem>Доктор наук</asp:ListItem>
            </asp:CheckBoxList>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Курс:"></asp:Label>
            <asp:DropDownList ID="DropDownListCourse" runat="server" OnSelectedIndexChanged="DropDownListCourse_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label8" runat="server" Text="Факультет:	"></asp:Label>
            <asp:DropDownList ID="DropDownListFaculty" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Text="Структурний підрозділ:"></asp:Label>
            <asp:DropDownList ID="DropDownListStruct" runat="server">
            </asp:DropDownList>
        </p>
        <asp:Button ID="ButtonNext" runat="server" OnClick="ButtonNext_Click" Text="ДАЛІ" />
        <asp:Button ID="ButtonBack" runat="server" OnClick="ButtonBack_Click" Text="НАЗАД" />
        <asp:Label ID="LabelError" runat="server"></asp:Label>
    </form>
</body>
</html>
