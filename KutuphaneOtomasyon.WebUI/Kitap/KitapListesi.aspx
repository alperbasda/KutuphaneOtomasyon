<%@ Page Title="Kitap Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Kitap.KitapListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Kitaplar</h6>
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
                            <input type="text" class="form-control m-input" placeholder="Örn : Safiye Sultan" data-col-index="0">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>ISBN:</label>
                            <input type="number" class="form-control m-input" placeholder="Örn : 6534547842467" data-col-index="3">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Kod:</label>
                            <input type="text" class="form-control m-input" placeholder="Örn : 435634634" data-col-index="2">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Yazar:</label>
                            <input type="text" class="form-control m-input" placeholder="Örn : Dostoyevski" data-col-index="4">
                        </div>
                        
                    </div>
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Kitap Kategorisi:</label>
                            <select class="form-control m-input" data-col-index="1">
                                <option value="">Kategori Seçin</option>
                                <option value="0">Dram</option>
                                <option value="1">Siyasi</option>
                                <option value="2">Karikatür</option>
                                <option value="3">Bilim - Teknoloji</option>
                            </select>
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Yayın Yılı:</label>

                            <select class="form-control m-input" data-col-index="1">
                                <option value="">Yayın Yılı Seçin</option>
                                <% for (int i = 1700; i <= DateTime.Now.Year; i++)
                                    {%>
                                <option value="<%=i %>"><% =i %></option>
                                <% } %>
                            </select>
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Durum:</label>
                            <select class="form-control m-input" data-col-index="1">
                                <option value="">Durum Seçin</option>
                                <option value="0">Kütüphanede</option>
                                <option value="1">Ögrencide</option>
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
                            <th>Kategori</th>
                            <th>Adı</th>
                            <th>Kodu</th>
                            <th>Yazar</th>
                            <th>YayinYili</th>
                            <th>ISBN</th>
                            <th>Sayfa Sayısı</th>
                            <th>Durum</th>
                            <th>Anahtarları Gör</th>
                            <th>Düzenle</th>
                            <th>Sil</th>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Dram</td>
                            <td>Sefiller</td>
                            <td>41241345135</td>
                            <td>Victor Hugo</td>
                            <td>1862</td>
                            <td>1236523674285</td>
                            <td>1032</td>
                            <td><span class="m-badge  m-badge--metal m-badge--accent">Kütüphane</span></td>
                            <td><a href="../Kitap/KitapDurum.aspx"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                            <td><a href="../Kitap/KitapDuzenle.aspx"><i class="fa fa-edit" style="color: coral"></i></a></td>
                            <td><a href="../Kitap/KitapDuzenle.aspx"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Siyasi</td>
                            <td>Beraber Yürüdük Biz Bu Yıllarda</td>
                            <td>5453463634</td>
                            <td>Yılmaz Özdil</td>
                            <td>2001</td>
                            <td>6531238762349</td>
                            <td>236</td>
                            <td><span class="m-badge  m-badge--metal m-badge--wide">Ögrenci</span></td>
                            <td><a href="../Kitap/KitapDurum.aspx"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                            <td><a href="../Kitap/KitapDuzenle.aspx"><i class="fa fa-edit" style="color: coral"></i></a></td>
                            <td><a href="../Kitap/KitapDuzenle.aspx"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
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