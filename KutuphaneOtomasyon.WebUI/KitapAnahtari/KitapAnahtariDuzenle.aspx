<%@ Page Title="Kitap Anahtarı Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapAnahtariDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapAnahtari.KitapAnahtariDuzenle" %>
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
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="anahtar">Anahtar</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="anahtar" name="Anahtar" placeholder="Anahtar kelime yazın...">
                        </div>
                        <br />
                        <div class="form-group m-form__group text-center">
                            <button type="submit" class="btn btn-accent">Düzenle</button>
                        </div>
                    </div>
                    
                </div>

                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
