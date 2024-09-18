<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BasicWebForm.aspx.cs" Inherits="BasicEcx.AspxPages.BasicWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>A WebForms Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="label1"></asp:Label>
            <asp:TextBox runat="server" ID="textBox1"></asp:TextBox><br/><br/>
            <asp:Label runat="server" ID="label2"></asp:Label><br/><br/>
            <asp:Button runat="server" ID="updateButton" Text="Update" OnClick="updateButton_OnClick"/><br/>
        </div>
    </form>
</body>
</html>
