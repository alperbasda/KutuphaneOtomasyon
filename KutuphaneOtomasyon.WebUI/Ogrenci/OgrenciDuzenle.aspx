<%@ Page Title="Ogrenci Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OgrenciDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Ogrenci.OgrenciDuzenle" %>

<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Ogrenci" %>
<%@ Register Src="../Fakulte/OgrenciEkleFakulteBolumSecici.ascx" TagName="OgrenciEkleFakulteBolumSecici" TagPrefix="UserControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Ögrenci Düzenle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <form id="form" runat="server">
                    <dav:MetadataSource
                        ID="msOgrenciEkleModel"
                        ObjectType="<%$ Code: typeof(OgrenciDuzenleModel) %>"
                        runat="server" />
                    <div class="row justify-content-center">
                        <UserControl:OgrenciEkleFakulteBolumSecici ID="BolumId" runat="server" />
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="Ad">Adı</label>
                                <asp:TextBox
                                    ID="Ad"
                                    placeholder="Ögrencinin adını yazın..."
                                    type="text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleAdValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="Ad"
                                    ControlToValidate="Ad"
                                    runat="server"></dav:DataAnnotationsValidator>

                            </div>
                            <div class="form-group m-form__group">
                                <label for="Soyad">Soyadı</label>
                                <asp:TextBox
                                    ID="Soyad"
                                    placeholder="Ögrencinin soyadını yazın..."
                                    type="text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleSoyadValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="Soyad"
                                    ControlToValidate="Soyad"
                                    runat="server"></dav:DataAnnotationsValidator>

                            </div>
                            <div class="form-group m-form__group">
                                <label for="numara">Numara</label>
                                <asp:TextBox
                                    ID="Numara"
                                    placeholder="Ögrencinin numarasını yazın..."
                                    type="text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleNumaraValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="Numara"
                                    ControlToValidate="Numara"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="mail">Mail Adresi</label>
                                <asp:TextBox
                                    ID="OgrenciMail"
                                    placeholder="Ögrencinin mail adresini yazın..."
                                    type="email"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleMailValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="OgrenciMail"
                                    ControlToValidate="OgrenciMail"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <label for="tel">Telefon Numarası</label>
                                <asp:TextBox
                                    ID="OgrenciTelefon"
                                    placeholder="Ögrencinin telefon numarasını yazın..."
                                    type="tel"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleTelefonValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="OgrenciTelefon"
                                    ControlToValidate="OgrenciTelefon"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="memleketAdres">Memleket Adres</label>
                                <asp:TextBox
                                    placeholder="Memleket Adresini yazın..."
                                    Rows="3"
                                    ID="OgrenciMemleketAdres"
                                    type="text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleMemleketAdresValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="OgrenciMemleketAdres"
                                    ControlToValidate="OgrenciMemleketAdres"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <label for="adresOkul">Adres</label>
                                <asp:TextBox
                                    placeholder="Adresi yazın..."
                                    Rows="3"
                                    ID="OgrenciAdres"
                                    type="text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ValidationGroup="OgrenciEkleGroup"
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator
                                    ValidationGroup="OgrenciEkleGroup"
                                    MetadataSourceID="msOgrenciEkleModel"
                                    ID="OgrenciEkleAdresValidator"
                                    CssClass="m-form__help"
                                    ObjectProperty="OgrenciAdres"
                                    ControlToValidate="OgrenciAdres"
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    CssClass="btn btn-accent col-4"
                                    ID="OgrenciEkleButton"
                                    Text="Kaydet"
                                    ValidationGroup="OgrenciEkleGroup"
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
