<%@ Page Title="Kitap Anahtar Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapAnahtariEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapAnahtari.KitapAnahtariEkle" %>

<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar" %>
<%@ Register Src="../Kitap/KitapSecici.ascx" TagName="KitapSecici" TagPrefix="UserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Kitap Anahtarı Ekle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <form id="KitapAnahtarEkleForm" runat="server">
                    <!--Begin::Section-->
                    <dav:MetadataSource
                        ID="msKitapAnahtarEkleModel"
                        ObjectType="<%$ Code: typeof(KitapAnahtarEkleModel) %>"
                        runat="server" />
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <UserControl:KitapSecici ID="KitapId" runat="server" />
                            <div class="form-group m-form__group">
                                <label for="Anahtar">Anahtar</label>
                                <asp:TextBox
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    type="text"
                                    ID="Anahtar"
                                    ValidationGroup="KitapAnahtarEkleGroup"
                                    placeholder="Anahtar kelime yazın..."
                                    runat="server">
                                </asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ID="KitapAnahtarEkleAnahtarValidation"
                                    CssClass="m-form__help"
                                    ValidationGroup="KitapAnahtarEkleGroup"
                                    MetadataSourceID="msKitapAnahtarEkleModel"
                                    ControlToValidate="Anahtar"
                                    ObjectProperty="Anahtar"
                                    runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    CausesValidation="True"
                                    ValidationGroup="KitapAnahtarEkleGroup"
                                    OnClick="KitapAnahtarEkleButton_OnClick"
                                    ID="KitapAnahtarEkleButton"
                                    Text="Kaydet"
                                    CssClass="btn btn-accent"
                                    runat="server" />
                            </div>
                        </div>

                    </div>

                    <!--End::Section-->
                </form>
            </div>
        </div>
    </div>
</asp:Content>


