<%@ Page Title="Fakülte Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FakulteListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Fakulte.FakulteListesi" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Fakülteler</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::SearchArea-->
                <form method="get" class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Fakülte Adı:</label>
                            <input type="text" class="form-control m-input" name="FakulteAdi" placeholder="Örn : Mühendislik Fakültesi">
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col-lg-12">
                            <button type="submit" class="btn btn-brand m-btn m-btn--icon" id="m_search">
                                <span>
                                    <i class="la la-search"></i>
                                    <span>Ara</span>
                                </span>
                            </button>
                            <button type="reset" class="btn btn-secondary m-btn m-btn--icon" id="m_reset">
                                <span>
                                    <span>Sıfırla</span>
                                </span>
                            </button>
                        </div>
                    </div>
                </form>
                <div class="m-separator m-separator--md m-separator--dashed"></div>
                <!--End::SearchArea-->

                <!--Begin::Table-->
                <div class="row table-responsive dataTables_wrapper dt-bootstrap4">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Fakülte Adı</th>
                                <th>Bölümleri Gör</th>
                                <th>Düzenle</th>
                                <th>Sil</th>
                            </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="Fakulteler" runat="server">
                                <HeaderTemplate></HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td><%# Eval("FakulteAdi") %></td>
                                        <td><a href="../Bolum/BolumListesi.aspx?Fakulte=<%# Eval("Id") %>"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><a href="../Fakulte/FakulteDuzenle.aspx?Fakulte=<%# Eval("Id") %>"><i class="fa fa-edit" style="color: coral"></i></a></td>
                                        <td><a href="../Fakulte/FakulteDuzenle.aspx?Fakulte=<%# Eval("Id") %>"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tbody>
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

            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="../Scripts/Site/fill-input.js"></script>
</asp:Content>
