<%@ Page Title="Bölüm Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BolumListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Bolum.BolumListesi" %>

<%@ Import Namespace="KutuphaneOtomasyon.WebUI.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Bölümler</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::SearchArea-->
                <form method="get" class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Fakülte Adı </label>
                            <input value='<%# Request.QueryString["FakulteAdi"] %>' type="text" class="form-control m-input" placeholder="Örn : Mühendislik" name="FakulteAdi" />


                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Bölüm Adı:</label>
                            <input type="text" class="form-control m-input" name="BolumAdi" value="<%# Request.QueryString["BolumAdi"] %>" placeholder="Örn : Bilgisayar Mühendisliği">
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

                <div class="row table-responsive dataTables_wrapper dt-bootstrap4">

                    <!--Begin::Table-->
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Fakülte Adı</th>
                                <th>Bölümleri Adı</th>
                                <th>Ögrencileri Gör</th>
                                <th>Düzenle</th>
                                <th>Sil</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Bolumler" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td><%# Eval("FakulteAdi") %></td>
                                        <td><%# Eval("BolumAdi") %></td>
                                        <td><a href="../Ogrenci/OgrenciListesi.aspx?BolumId=<%# Eval("Id") %>"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><a href="../Bolum/BolumDuzenle.aspx?Id=<%# Eval("Id") %>"><i class="fa fa-edit" style="color: coral"></i></a></td>
                                        <td><a href="../Bolum/BolumDuzenle.aspx?Id=<%# Eval("Id") %>"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
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
                                <%= PagerHelper.Paging(Convert.ToInt32(sayfaSayisi.Text), Request.QueryString) %>
                            </ul>
                        </div>
                    </div>
                    <div class="col-sm-12 col-md-5">
                        <div class="dataTables_info" id="m_table_1_info" role="status" aria-live="polite">
                            Toplam
                            <asp:Label ID="sayfaSayisi" runat="server"></asp:Label>
                            Sayfada
                            <asp:Label ID="toplamData" runat="server"></asp:Label>
                        </div>
                    </div>
                    <!--End::Pager-->
                </div>

                <!--End::Section-->

            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="../Scripts/Site/fill-input.js"></script>
</asp:Content>
