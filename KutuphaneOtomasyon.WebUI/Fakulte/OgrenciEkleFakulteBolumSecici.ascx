<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OgrenciEkleFakulteBolumSecici.ascx.cs" Inherits="KutuphaneOtomasyon.WebUI.Fakulte.OgrenciEkleFakulteBolumSecici" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
    </Scripts>
</asp:ScriptManager>

<div class="col-6">
    <asp:DropDownList
        AutoPostBack="True"
        CssClass="form-control m-input m-input--air m-input--pill"
        ID="FakulteId"
        placeholder="Fakulte Seçin..."
        runat="server" OnSelectedIndexChanged="FakulteId_OnSelectedIndexChanged">
        <asp:ListItem disabled="disabled">Fakulte Seçin</asp:ListItem>
    </asp:DropDownList>
</div>
<div class="col-6">
    <asp:UpdatePanel ID="OgrenciEkleUpdatePanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:DropDownList
                ValidationGroup="OgrenciEkleGroup"
                ID="BolumId"
                CssClass="form-control m-input m-input--air m-input--pill"
                runat="server" />
            <dav:DataAnnotationsValidator
                ID="OgrenciEkleBolumValidator"
                CssClass="m-form__help"
                ValidationGroup="OgrenciEkleGroup"
                MetadataSourceID="msOgrenciEkleModel"
                ControlToValidate="BolumId"
                ObjectProperty="BolumId"
                runat="server"></dav:DataAnnotationsValidator>
            <asp:Label ID="infoLabel" runat="server">Önce Fakülte Seçin</asp:Label>
            <asp:UpdateProgress ID="OgrenciEkleUpdatePanelProgress" runat="server">
                <ProgressTemplate>
                    <label>Bölümler yükleniyor...</label>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="FakulteId" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</div>

