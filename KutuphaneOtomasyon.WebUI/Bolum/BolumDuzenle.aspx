<%@ Page Title="Bölüm Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BolumDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Bolum.BolumDuzenle" %>

<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum" %>
<%@ Register Src="../Fakulte/FakulteSecici.ascx" TagName="FakulteSecici" TagPrefix="UserControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Bölüm Düzenle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::Section-->
                <form id="form" runat="server">
                    <dav:MetadataSource
                        ID="msBolumEkleModel"
                        ObjectType="<%$ Code: typeof(BolumEkleModel) %>"
                        runat="server" />
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label>Fakülte Seçin</label>
                                <UserControl:FakulteSecici ID="FakulteId" runat="server" />
                            </div>
                            <div class="form-group m-form__group">
                                <label for="BolumAdi">Bölüm Adı</label>
                                <asp:TextBox
                                    ValidationGroup="BolumEkle"
                                    Type="Text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ID="BolumAdi"
                                    placeholder="Bölüm adını yazın..."
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msBolumEkleModel"
                                    ValidationGroup="BolumEkle"
                                    ID="validator"
                                    CssClass="m-form__help"
                                    ControlToValidate="BolumAdi"
                                    ObjectProperty="BolumAdi"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <br />
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    ID="BolumEkleButton"
                                    Text="Kaydet"
                                    CssClass="btn btn-accent"
                                    ValidationGroup="BolumEkle"
                                    OnClick="DuzenleButton_OnClick"
                                    runat="server" />

                            </div>
                        </div>

                    </div>
                    <asp:TextBox
                        type="hidden"
                        ID="Id"
                        runat="server" />
                </form>
                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
