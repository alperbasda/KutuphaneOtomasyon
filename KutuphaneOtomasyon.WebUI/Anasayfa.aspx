<%@ Page Title="Kutuphane - Anasayfa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Anasayfa" %>

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

                                <div class="m-widget29 text-center">
                                    <h3 style="color: white">Kütüphane Otomasyon</h3>
                                    <br />
                                    <h4  style="color: white">Sistemi</h4>
                                    <br/>
                                    <p style="color: antiquewhite"><b> Proje çalıştığınızda sistemin hata verme ihtimaline karşı trigger.txt dosyasındaki triggerları veri tabanına ekleyin. </b></p>
                                    <br />
                                    <p style="color: antiquewhite"><b>Veritabanı için job ve index çalışması yapılmamıştır. </b></p><br/>
                                    <p style="color:green"> Projenin tüm dosyalarına <a target="_blank" href="http://www.github.com/alperbasda"> github  </a> adresimden erişebilirsiniz.</p>
                                    
                                    
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
