<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KitapSecici.ascx.cs" Inherits="KutuphaneOtomasyon.WebUI.Kitap.KitapSecici" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
    </Scripts>
</asp:ScriptManager>
<div class="form-group m-form__group">
    <label for="anahtar">Kitap Ara</label>
    <div ID="SearchItems" class="input-group" runat="server">
        <asp:TextBox
            type="text"
            CssClass="form-control"
            placeholder="Kitap adı yazın..."
            ID="KitapAdi"
            runat="server"></asp:TextBox>
        <div class="input-group-append">
            <asp:Button
                CssClass="btn btn-brand"
                Text="Ara"
                ID="KitapAraButton"
                ValidationGroup="KitapAraSelectGroup"
                OnClick="KitaplariGetir_OnClick" runat="server" />
        </div>
    </div>
</div>
<div class="form-group m-form__group">
    <label for="KitapId">Kitap Seçin</label>
    <asp:UpdatePanel ID="KitapUpdatePanel" UpdateMode="Conditional"  runat="server">
        <ContentTemplate>
            <asp:DropDownList
                ValidationGroup="KitapAnahtarEkleGroup"
                ID="KitapId"
                CssClass="form-control"
                runat="server" />
            <dav:DataAnnotationsValidator
                id="KitapAnahtarEkleKitapValidation" 
                cssclass="m-form__help"
                ValidationGroup="KitapAnahtarEkleGroup"
                MetadataSourceID="msKitapAnahtarEkleModel"
                controltovalidate="KitapId" 
                objectproperty="KitapId" 
                runat="server"></dav:DataAnnotationsValidator>
            <asp:Label ID="searchLabel" runat="server"></asp:Label>
            <asp:UpdateProgress ID="KitapUpdatePanelProgress" runat="server">
                <ProgressTemplate>
                    <label>Kitaplar yükleniyor...</label>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="KitapAraButton" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

</div>

