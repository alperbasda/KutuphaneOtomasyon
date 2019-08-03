﻿<%@ Page Title="Bölüm Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BolumDuzenle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Bolum.BolumDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Bölüm Düzenle</h6>
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
                            <button type="submit" class="btn btn-accent">Düzenle</button>
                        </div>
                    </div>
                    
                </div>

                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>