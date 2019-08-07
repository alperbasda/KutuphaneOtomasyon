<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KitapAraKitapKategoriSecici.ascx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapKategori.KitapAraKitapKategoriSecici" %>

<form runat="server">
    <asp:DropDownList
        runat="server"
        CssClass="form-control m-input kitap-kategori"
        ID="KitapKategoriId" >
        <asp:ListItem Value="0">Kitap Kategorisi Seçin</asp:ListItem>
    </asp:DropDownList>
</form>
