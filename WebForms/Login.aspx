<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="WebForms.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Login</h2>

        Korisničko ime:
        <asp:TextBox ID="txtUserName" runat="server" /><br /><br />

        Lozinka:
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />

        <asp:Button ID="btnLogin" runat="server"
            Text="Prijava"
            OnClick="btnLogin_Click" />
        <br /><br />

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

    </form>
</body>
</html>
