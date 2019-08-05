<%@ Page Title="Ögrenci Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OgrenciListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Ogrenci.OgrenciListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Ögrenciler</h6>
                    </div>
                </div>
            </div>
            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::SearchArea-->
                <form class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Ad:</label>
                            <input type="text" class="form-control m-input" placeholder="Örn : Alper" data-col-index="0">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Soyad:</label>
                            <input type="text" class="form-control m-input" placeholder="Örn : Başda" data-col-index="1">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Numara:</label>
                            <input type="number" class="form-control m-input" placeholder="Örn : 3244353463" data-col-index="2">
                        </div>
                    </div>
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label for="fakülteSec">Fakülte Seçin</label>
                            <select class="form-control m-input m-input--air m-input--pill" id="fakülteSec">
                                <option>Mühendislik Fakültesi</option>
                                <option>Fen Edebiyat Fakültesi</option>
                                <option>İktisadi ve İdari Bilimler Fakültesi</option>
                            </select>
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
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
                            <th>Ad</th>
                            <th>Soyad</th>
                            <th>Numara</th>
                            <th>Kayıt Tarihi</th>
                            <th>Bölüm</th>
                            <th>Detay</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Alper</td>
                            <td>Başda</td>
                            <td>201513172004</td>
                            <td>05.01.2015</td>
                            <td>Bilgisayar Mühendisliği</td>
                            <td><a href="../Ogrenci/OgrenciDetay.aspx"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                            <td><a href="../Ogrenci/OgrenciDuzenle.aspx"><i class="fa fa-edit" style="color: coral"></i></a></td>
                            <td><a href="../Ogrenci/OgrenciDuzenle.aspx"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Mustafa</td>
                            <td>Özkaya</td>
                            <td>201513172001</td>
                            <td>05.01.2015</td>
                            <td>Bilgisayar Mühendisliği</td>
                            <td><a href="../Ogrenci/OgrenciDetay.aspx"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                            <td><a href="../Ogrenci/OgrenciDuzenle.aspx"><i class="fa fa-edit" style="color: coral"></i></a></td>
                            <td><a href="../Ogrenci/OgrenciDuzenle.aspx"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
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
                    <!--End::Section-->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="../Scripts/Site/fill-input.js"></script>
</asp:Content>