<%@ Page Title="Kitap Anahtarı Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapAnahtariDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapAnahtari.KitapAnahtariDuzenle" %>

<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Kitap Anahtarı Düzenle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <form id="form" runat="server">
                    <!--Begin::Section-->
                    <dav:MetadataSource
                        ID="msKitapAnahtarEkleModel"
                        ObjectType="<%$ Code: typeof(KitapAnahtarEkleModel) %>"
                        runat="server" />
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="Anahtar">Kitap Adı</label>
                                <asp:TextBox
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    type="text"
                                    ID="KitapAd"
                                    disabled="disabled"
                                    ValidationGroup="KitapAnahtarEkleGroup"
                                    placeholder="Anahtar kelime yazın..."
                                    runat="server">
                                </asp:TextBox>
                              
                            </div>
                      
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
                                    OnClick="DuzenleButton_OnClick"
                                    ID="KitapAnahtarEkleButton"
                                    Text="Kaydet"
                                    CssClass="btn btn-accent"
                                    runat="server" />
                            </div>
                        </div>

                    </div>

                    <!--End::Section-->
                    <asp:TextBox
                        type="hidden"
                        ID="Id"
                        runat="server" />
                    <asp:TextBox
                        type="hidden"
                        ID="KitapId"
                        runat="server" />
                </form>

                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
