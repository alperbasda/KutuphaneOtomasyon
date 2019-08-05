<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FakulteSecici.ascx.cs" Inherits="KutuphaneOtomasyon.WebUI.Fakulte.FakulteSecici" %>

<asp:DropDownList
    ValidationGroup="BolumEkle"
    CssClass="form-control m-input m-input--air m-input--pill"
    ID="FakulteId"
    placeholder="Fakulte Seçin..."
    runat="server"></asp:DropDownList>
<dav:DataAnnotationsValidator 
    MetadataSourceID="msBolumEkleModel"
    ValidationGroup="BolumEkle"
    ID="validatorFakuldeSec"
    cssclass="m-form__help"
    controltovalidate="FakulteId"
    objectproperty="FakulteId" 
    runat="server"></dav:DataAnnotationsValidator>
