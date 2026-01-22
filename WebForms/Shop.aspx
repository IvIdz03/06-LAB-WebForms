<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Shop.aspx.cs"
    Inherits="WebForms.Shop" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Shop</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Shop</h2>

        Naziv proizvoda:
        <asp:TextBox ID="txtName" runat="server" /><br /><br />

        Opis proizvoda:
        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" /><br /><br />

        <asp:Button ID="btnSave" runat="server" Text="Spremi" OnClick="btnSave_Click" />
        <br /><br />

        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="true" />

        <br />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

    </form>
</body>
</html>
