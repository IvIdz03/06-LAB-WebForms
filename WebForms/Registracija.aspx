<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Registracija.aspx.cs"
    Inherits="WebForms.Registracija" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Registracija</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Registracija</h2>

        Korisnicko ime:
        <asp:TextBox ID="txtUserName" runat="server" /><br /><br />

        Puno ime:
        <asp:TextBox ID="txtFullName" runat="server" /><br /><br />

        Lozinka:
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br /><br />

        Ponovi lozinku:
        <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password" /><br /><br />

        <asp:Button ID="btnRegister" runat="server"
            Text="Registriraj"
            OnClick="btnRegister_Click" />
        <br /><br />

        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

    </form>
</body>
</html>
