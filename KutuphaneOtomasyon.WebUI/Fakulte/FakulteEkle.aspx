<%@ Page Title="Fakulte Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FakulteEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Fakulte.FakulteEkle" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Yeni Fakülte Ekle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::Section-->
                <form id="fakulteForm" runat="server">
                    <dav:metadatasource
                        id="msFakulteEkleModel" 
                        objecttype="<%$ Code: typeof(FakulteEkleModel) %>" 
                        runat="server" />
                    <div class="row justify-content-center">
                        <div class="col-4">
                            <div class="form-group m-form__group">
                                <label for="FakulteAdi">Fakülte Adı</label>
                                <asp:TextBox 
                                    CssClass="form-control m-input m-input--air m-input--pill" 
                                    type="text" 
                                    ID="FakulteAdi"
                                    ValidationGroup="FakulteEkleModel" 
                                    placeholder="Fakülte adı yazın..." 
                                    runat="server">
                                </asp:TextBox>
                                <dav:dataannotationsvalidator 
                                    id="Dataannotationsvalidator2" 
                                    cssclass="m-form__help"
                                    validationgroup="FakulteEkleModel" 
                                    metadatasourceid="msFakulteEkleModel"
                                    controltovalidate="FakulteAdi" 
                                    objectproperty="FakulteAdi" 
                                    runat="server" />
                            </div>
                            <br />
                            <div class="form-group m-form__group text-center">
                                <asp:Button 
                                    ValidationGroup="FakulteEkleModel" 
                                    OnClick="FakulteKaydetButton_OnClick" 
                                    ID="FakulteKaydetButton" 
                                    Text="Kaydet"
                                    CssClass="btn btn-accent"
                                    runat="server" />

                            </div>
                        </div>
                    </div>
                </form>

                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
