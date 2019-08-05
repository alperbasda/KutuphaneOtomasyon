<%@ Page Title="Bölüm Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BolumEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Bolum.BolumEkle" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum" %>
<%@ Register Src="../Fakulte/FakulteSecici.ascx" TagName="FakulteSecici" TagPrefix="UserControl"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Yeni Bölüm Ekle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <form id="BolumForm" runat="server">
                    <dav:MetadataSource
                        id="msBolumEkleModel" 
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
                                    cssclass="m-form__help"
                                    controltovalidate="BolumAdi"
                                    objectproperty="BolumAdi" 
                                    runat="server"></dav:DataAnnotationsValidator>
                            </div>
                            <br />
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    ID="BolumEkleButton"
                                    Text="Kaydet"
                                    CssClass="btn btn-accent"
                                    ValidationGroup="BolumEkle"
                                    OnClick="BolumEkleButton_OnClick"
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
