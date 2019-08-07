<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OgrenciAraFakulteBolumSecici.ascx.cs" Inherits="KutuphaneOtomasyon.WebUI.Fakulte.OgrenciAraFakulteBolumSecici" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci" %>

<div class="container">
<form runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="m--margin-bottom-20 col-6" style="float: left">
        <asp:DropDownList
            AutoPostBack="True"
            CssClass="form-control m-input m-input--air m-input--pill fakulte-search"
            ID="FakulteId"
            placeholder="Fakulte Seçin..."
            runat="server" OnSelectedIndexChanged="FakulteId_OnSelectedIndexChanged">
            <asp:ListItem Value="-1">Fakülte Seçin</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="m--margin-bottom-20 col-6" style="float: left">
        <asp:UpdatePanel ID="OgrenciEkleUpdatePanel" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:DropDownList
                    AutoPostBack = "False"
                    ID="BolumListe"
                    onchange="degis(this)"
                    CssClass="form-control m-input m-input--air m-input--pill bolum-listesi"
                    runat="server" />
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

</form>
</div>
