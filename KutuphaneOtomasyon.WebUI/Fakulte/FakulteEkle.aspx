<%@ Page Title="Fakülte Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FakulteEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.FakulteEkle" %>

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
                <div class="row justify-content-center">
                    <div class="col-4">

                        <div class="form-group m-form__group">
                            <label for="fakulteAdi">Fakülte Adı</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="fakulteAdi" name="Adi" placeholder="Fakülte adını yazın...">
                        </div>
                        <br />
                        <div class="form-group m-form__group text-center">
                            <button type="submit" class="btn btn-accent">Kaydet</button>
                        </div>
                    </div>

                </div>

                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
