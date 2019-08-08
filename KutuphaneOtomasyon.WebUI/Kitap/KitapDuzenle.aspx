<%@ Page Title="Kitap Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Kitap.KitapDuzenle" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap" %>

<%@ Register Src="../KitapKategori/KitapKategoriSecici.ascx" TagName="KitapKategoriSecici" TagPrefix="UserControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Kitap Düzenle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <form id="form" runat="server">
                    <dav:MetadataSource
                        ID="msKitapEkleModel"
                        ObjectType="<%$ Code: typeof(KitapEkleModel) %>"
                        runat="server" />

                    <!--Begin::Section-->
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="kategoriSec">Kategori Seçin</label>
                                <usercontrol:kitapkategorisecici id="KitapKategoriId" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="Adi">Kitap Adı</label>
                                <asp:TextBox
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ID="Adi"
                                    placeholder="Kitap adını yazın..."
                                    type="text"
                                    ValidationGroup="KitapEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msKitapEkleModel"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="ValidatorKitapEkleAd"
                                    CssClass="m-form__help"
                                    ControlToValidate="Adi"
                                    ObjectProperty="Adi"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <label for="KitapKodu">Kitap Kodu</label>
                                <asp:TextBox
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="Kod"
                                    type="text"
                                    placeholder="Kitap kodu yazın..."
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msKitapEkleModel"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="validatorKitapEkleKod"
                                    CssClass="m-form__help"
                                    ControlToValidate="Kod"
                                    ObjectProperty="Kod"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="Yazar">Yazar</label>
                                <asp:TextBox
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ID="Yazar"
                                    type="text"
                                    placeholder="Kitabın yazarını yazın..."
                                    ValidationGroup="KitapEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msKitapEkleModel"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="validatorKitapEkleYazar"
                                    CssClass="m-form__help"
                                    ControlToValidate="Yazar"
                                    ObjectProperty="Yazar"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <label for="YayinYili">Yayın Tarihi</label>
                                <asp:TextBox
                                    type="number"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    placeholder="Yayın tarihini seçin..."
                                    ID="YayinYili"
                                    ValidationGroup="KitapEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msKitapEkleModel"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="validatorKitapEkleYayinYili"
                                    CssClass="m-form__help"
                                    ControlToValidate="YayinYili"
                                    ObjectProperty="YayinYili"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="ISBN">ISBN</label>
                                <asp:TextBox
                                    type="text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    placeholder="ISBN yazın..."
                                    ID="ISBN"
                                    ValidationGroup="KitapEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msKitapEkleModel"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="validatorKitapEkleISBN"
                                    CssClass="m-form__help"
                                    ControlToValidate="ISBN"
                                    ObjectProperty="ISBN"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <label for="SayfaSayisi">Sayfa Sayısı</label>
                                <asp:TextBox
                                    type="number"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    placeholder="Kitabın sayfa sayısını yazın..."
                                    ID="SayfaSayisi"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    MetadataSourceID="msKitapEkleModel"
                                    ValidationGroup="KitapEkleGroup"
                                    ID="ValidatorKitapEkleSayfaSayisi"
                                    CssClass="m-form__help"
                                    ControlToValidate="SayfaSayisi"
                                    ObjectProperty="SayfaSayisi"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                        </div>

                    </div>
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    CssClass="btn btn-accent col-4"
                                    ID="KitapEkleButton"
                                    OnClick="DuzenleButton_OnClick"
                                    Text="Kaydet"
                                    ValidationGroup="KitapEkleGroup"
                                    runat="server" />

                            </div>
                        </div>
                    </div>
                    <!--End::Section-->
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

