<%@ Page Title="Kitap Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Kitap.KitapDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Kitap Düzenle</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">


                <!--Begin::Section-->
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="kategoriSec">Kategori Seçin</label>
                            <select class="form-control m-input m-input--air m-input--pill" id="kategoriSec">
                                <option>Dram</option>
                                <option>Mitoloji</option>
                                <option>Savaş</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="kitapAdi">Kitap Adı</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="kitapAdi" name="Adi" placeholder="Kitap adını yazın...">
                        </div>
                        <div class="form-group m-form__group">
                            <label for="kitapKodu">Kitap Kodu</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="kitapKodu" name="Kod" placeholder="Kitap kodu yazın...">
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="yazar">Yazar</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="yazar" name="Yazar" placeholder="Kitabın yazarını yazın...">
                        </div>
                        <div class="form-group m-form__group">
                            <label for="yayinTarihi">Yayın Tarihi</label>
                            <input type="date" class="form-control m-input m-input--air m-input--pill" id="yayinTarihi" name="YayinTarihi" placeholder="Yayın tarihini seçin...">
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="form-group m-form__group">
                            <label for="isbn">ISBN</label>
                            <input type="text" class="form-control m-input m-input--air m-input--pill" id="isbn" name="ISBN" placeholder="ISBN yazın...">
                        </div>
                        <div class="form-group m-form__group">
                            <label for="sayfaSayisi">Sayfa Sayısı</label>
                            <input type="number" class="form-control m-input m-input--air m-input--pill" id="sayfaSayisi" name="SayfaSayisi" placeholder="Kitabın sayfa sayısını yazın...">
                        </div>
                    </div>

                </div>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <div class="form-group m-form__group text-center">
                            <button type="submit" class="btn btn-accent col-4">Düzenle</button>
                        </div>
                    </div>
                </div>



                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>
