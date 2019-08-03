<%@ Page Title="Bölüm Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BolumEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Bolum.BolumEkle" %>
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
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="fakulteSec">Fakülte Seçin</label>
                            <select class="form-control m-input m-input--air m-input--pill" id="fakulteSec">
                                <option>Mühendislik Fakültesi</option>
                                <option>Fen Edebiyat Fakültesi</option>
                                <option>İktisadi ve İdari Bilimler Fakültesi</option>
                                
                            </select>
                        </div>
                        <div class="form-group m-form__group">
                            <label for="bolumAdi">Bölüm Adı</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="bolumAdi" name="Adi" placeholder="Bölüm adını yazın...">
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
