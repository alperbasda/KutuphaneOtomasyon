<%@ Page Title="Ödünç Kitap Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OduncListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.KitapOdunc.OduncListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
         <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Ödünç Kitap Listesi</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::SearchArea-->
                <form class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Kitap Adı:</label>
                            <input type="text" class="form-control m-input" placeholder="Örn : Şeytan ayrıntıda gizlidir" data-col-index="0">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Ögrenci Ad Soyad:</label>
                            <input type="text" class="form-control m-input" placeholder="Örn : Alper Başda" data-col-index="1">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Alınma Tarihi:</label>
                            <input type="date" class="form-control m-input" data-col-index="2">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Teslim Tarihi:</label>
                            <input type="date" class="form-control m-input" data-col-index="3">
                        </div>
                    </div>
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Durum </label>
                            <select class="form-control m-input" id="durumSec" data-col-index="4">
                                <option>Kütüphanede</option>
                                <option>Ögrencide</option>
                            </select>
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col-lg-12">
                            <button class="btn btn-brand m-btn m-btn--icon" id="m_search">
                                <span>
                                    <i class="la la-search"></i>
                                    <span>Ara</span>
                                </span>
                            </button>
                            <button class="btn btn-secondary m-btn m-btn--icon" id="m_reset">
                                <span>
                                    <span>Sıfırla</span>
                                </span>
                            </button>
                        </div>
                    </div>
                </form>
                <div class="m-separator m-separator--md m-separator--dashed"></div>
                <!--End::SearchArea-->

                <!--Begin::Section-->
                <div class="row table-responsive dataTables_wrapper dt-bootstrap4">

                    <!-- Begin::List-->
                    <table class="table table-striped">
                        <tr>
                            <th>#</th>
                            <th>Ögrenci</th>
                            <th>Kitap</th>
                            <th>Alınma Tarihi</th>
                            <th>Teslim Tarihi</th>
                            <th>Teslim Al</th>
                            <th>Son İşlemi Geri Al</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Alper Başda</td>
                            <td>İler Mvc</td>
                            <td>05.01.2015</td>
                            <td>15.01.2015</td>
                            <td><span class="m-badge  m-badge--metal m-badge--success">Teslim Alındı</span></td>
                            <td><a href="../Ogrenci/OgrenciDetay.aspx"><span class="m-badge  m-badge--metal m-badge--info">Teslim alınmadı işaretle</span></a></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Alper Başda</td>
                            <td>İler Mvc</td>
                            <td>05.01.2015</td>
                            <td>-</td>
                            <td><span class="m-badge  m-badge--metal m-badge--primary">Teslim Al</span></td>
                            <td><a href="../Ogrenci/OgrenciDetay.aspx"><span class="m-badge  m-badge--metal m-badge--danger">Kaydı Sil</span></a></td>
                        </tr>
                        
                    </table>
                    <!--End::Table-->
                    <!--Begin::Pager-->
                    <div class="col-sm-12 col-md-7 dataTables_pager">
                        <div class="dataTables_paginate paging_simple_numbers" id="m_table_1_paginate">
                            <ul class="pagination">
                                <li class="page-item previous"><a href="#" class="page-link"><i class="la la-angle-left"></i><i class="la la-angle-left"></i></a></li>
                                <li class="page-item previous"><a href="#" class="page-link"><i class="la la-angle-left"></i></a></li>
                                <li class="page-item active"><a href="#" class="page-link">3</a></li>
                                <li class="page-item next"><a href="#" class="page-link"><i class="la la-angle-right"></i></a></li>
                                <li class="page-item next"><a href="#" class="page-link"><i class="la la-angle-right"></i><i class="la la-angle-right"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-5">
                        <div class="dataTables_info" id="m_table_1_info" role="status" aria-live="polite">Toplam 15 Sayfa</div>
                    </div>
                    <!--End::Pager-->
                </div>

                <!--End::Section-->

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="../Scripts/Site/fill-input.js"></script>
</asp:Content>