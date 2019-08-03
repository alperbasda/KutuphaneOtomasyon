<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Anasayfa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
    <div class="m-grid__item m-grid__item--fluid m-wrapper">

        <!-- BEGIN: Subheader -->
        <div class="m-subheader ">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title m-subheader__title--separator">İstatistikler</h3>
                </div>
            </div>
        </div>

        <!-- END: Subheader -->
        <div class="m-content">


            <!--Begin::Section-->
            <div class="row">
              
                <div class="col-xl-12">

                    <!--begin:: Packages-->
                    <div class="m-portlet m--bg-warning m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded">
                        
                        <div class="m-portlet__body" style="padding-top: 30px">

                            <!--begin::Widget 29-->
                            <div class="m-widget29">
                                <div class="m-widget_content">
                                    <h3 class="m-widget_content-title">Sisteme Kayıtlı Toplam</h3>
                                    <div class="m-widget_content-items">
                                        <div class="m-widget_content-item">
                                            <span>Fakülte</span>
                                            <span class="m--font-info">29</span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Bölüm</span>
                                            <span >29</span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Ögrenci</span>
                                            <span class="m--font-accent">120</span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Kitap</span>
                                            <span class="m--font-brand">91</span>
                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget_content">
                                    <h3 class="m-widget_content-title">Kitap</h3>
                                    <div class="m-widget_content-items">
                                        <div class="m-widget_content-item">
                                            <span>Toplam</span>
                                            <span class="m--font-accent">5.300</span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Ögrencide</span>
                                            <span class="m--font-brand">1.300</span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Kütüphanede</span>
                                            <span>701</span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--end::Widget 29-->
                        </div>
                    </div>

                    <!--end:: Packages-->
                </div>
            </div>

            <!--End::Section-->

        </div>
    </div>
</div>
</asp:Content>
