<%@ Page Title="Kitap Kategori Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapKategoriEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapKategori.KitapKategoriEkle" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Yeni Kitap Kategorisi Ekle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::Section-->
                <form id="KitapKategoriEkleForm" runat="server">
                    <dav:MetadataSource
                        id="msKitapKategoriEkleModel" 
                        ObjectType="<%$ Code: typeof(KitapKategoriEkleModel) %>"
                        runat="server" />
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label>Kategori Adı</label>
                                <asp:TextBox
                                    ValidationGroup="KitapKategoriEkleGroup"
                                    Type="Text"
                                    CssClass="form-control m-input m-input--air m-input--pill"
                                    ID="KitapKategoriAdi"
                                    placeholder="Kategori adını yazın..."
                                    runat="server"></asp:TextBox>
                                <dav:DataAnnotationsValidator 
                                    MetadataSourceID="msKitapKategoriEkleModel"
                                    ValidationGroup="KitapKategoriEkleGroup"
                                    ID="validatorKitapKategoriAdı"
                                    cssclass="m-form__help"
                                    controltovalidate="KitapKategoriAdi"
                                    objectproperty="KitapKategoriAdi" 
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <br />
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    ID="KitapKategoriEkleButton"
                                    Text="Kaydet"
                                    CssClass="btn btn-accent"
                                    ValidationGroup="KitapKategoriEkleGroup"
                                    OnClick="KitapKategoriEkleButton_OnClick"
                                    runat="server"/>
                            </div>
                        </div>

                    </div>
                </form>
                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
