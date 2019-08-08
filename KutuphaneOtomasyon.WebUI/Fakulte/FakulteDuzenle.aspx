<%@ Page Title="Fakülte Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FakulteDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Fakulte.FakulteDuzenle" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Fakülte Düzenle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <form id="form" runat="server">
                    <dav:MetadataSource
                        ID="msFakulteEkleModel"
                        ObjectType="<%$ Code: typeof(FakulteDuzenleModel) %>"
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
                                <dav:DataAnnotationsValidator
                                    ID="Dataannotationsvalidator2"
                                    CssClass="m-form__help"
                                    ValidationGroup="FakulteEkleModel"
                                    MetadataSourceID="msFakulteEkleModel"
                                    ControlToValidate="FakulteAdi"
                                    ObjectProperty="FakulteAdi"
                                    runat="server" />
                            </div>
                            <br />
                            <div class="form-group m-form__group text-center">
                                <asp:Button
                                    ValidationGroup="FakulteEkleModel"
                                    OnClick="DuzenleButton_OnClick"
                                    ID="FakulteDuzenleButton"
                                    Text="Duzenle"
                                    CssClass="btn btn-accent"
                                    runat="server" />

                            </div>
                        </div>
                    </div>

                    <asp:TextBox
                        type="hidden" 
                        ID="Id" 
                        runat="server"/>
                </form>
                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
