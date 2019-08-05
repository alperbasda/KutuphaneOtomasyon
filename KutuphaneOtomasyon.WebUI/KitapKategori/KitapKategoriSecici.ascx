<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KitapKategoriSecici.ascx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapKategori.KitapKategoriSecici" %>

<asp:DropDownList
    ValidationGroup="KitapEkleGroup"
    CssClass="form-control m-input m-input--air m-input--pill"
    ID="KitapKategoriId"
    placeholder="Kitap Kategorisi Seçin..."
    runat="server"></asp:DropDownList>
<dav:DataAnnotationsValidator 
    MetadataSourceID="msKitapEkleModel"
    ValidationGroup="KitapEkleGroup"
    ID="validatorKitapKategoriSec"
    cssclass="m-form__help"
    controltovalidate="KitapKategoriId"
    objectproperty="KitapKategoriId" 
    runat="server"></dav:DataAnnotationsValidator>