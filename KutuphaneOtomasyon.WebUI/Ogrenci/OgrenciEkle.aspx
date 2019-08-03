<%@ Page Title="Ögrenci Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OgrenciEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Ogrenci.OgrenciEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Yeni Ögrenci Ekle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <div class="row justify-content-center">
                    <div class="col-6">
                        <div class="form-group m-form__group">
                            <label for="fakülteSec">Fakülte Seçin</label>
                            <select class="form-control m-input m-input--air m-input--pill" id="fakülteSec">
                                <option>Mühendislik Fakültesi</option>
                                <option>Fen Edebiyat Fakültesi</option>
                                <option>İktisadi ve İdari Bilimler Fakültesi</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-group m-form__group">
                            <label for="bolumSec">Bölüm Seçin</label>
                            <select class="form-control m-input m-input--air m-input--pill" id="bolumSec">
                                <option>Bilgisayar Mühendisliği</option>
                                <option>İnşaat Mühendisliği</option>
                                <option>Endüstri Mühendisliği</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="Adi">Adı</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="Adi" name="Adi" placeholder="Ögrencinin adını yazın...">
                        </div>
                        <div class="form-group m-form__group">
                            <label for="soyad">Soyadı</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="soyad" name="Soyad" placeholder="Ögrencinin soyadını yazın...">
                        </div>
                        <div class="form-group m-form__group">
                            <label for="numara">Numara</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="numara" name="Numara" placeholder="Ögrencinin numarasını yazın...">
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="mail">Mail Adresi</label>
                            <input type="email" class="form-control m-input m-input--air m-input--pill" id="mail" name="Mail" placeholder="Ögrencinin mail adresini yazın...">
                        </div>
                        <div class="form-group m-form__group">
                            <label for="tel">Telefon Numarası</label>
                            <input type="tel" class="form-control m-input m-input--air m-input--pill" id="tel" name="ISBN" placeholder="Ögrencinin telefon numarasını yazın...">
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="memleketOkul">Memleket Adres</label>
                            <textarea class="form-control m-input m-input--air m-input--pill"  id="memleketOkul" name="MemleketOkul" placeholder="Memleket Adresini yazın..." rows="3"></textarea>
                        </div>
                        <div class="form-group m-form__group">
                            <label for="adresOkul">Adres</label>
                            <textarea class="form-control m-input m-input--air m-input--pill"  id="adresOkul" name="AdresOkul" placeholder="Adres yazın..." rows="3"></textarea>
                        </div>
                    </div>
                    


                </div>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group text-center">
                            <button type="submit" class="btn btn-accent col-4">Kaydet</button>
                        </div>
                    </div>
                </div>



                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
