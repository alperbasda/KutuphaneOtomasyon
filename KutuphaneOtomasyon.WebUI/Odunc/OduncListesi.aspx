<%@ Page Title="Ödünç Kitap Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OduncListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Odunc.OduncListesi" %>

<%@ Import Namespace="KutuphaneOtomasyon.WebUI.Helpers" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.Enum" %>
<%@ Import Namespace="KutuphaneOtomasyon.Business.Helpers" %>
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
                    <div class="pull-right">
                        <a href="../Odunc/IslemiGeriAl.aspx" class="btn btn-danger">Son İşlemi Geri Al</a>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::SearchArea-->
                <form method="get" class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Kitap Adı:</label>
                            <input type="text" class="form-control m-input" name="KitapAdi" placeholder="Örn : Şeytan ayrıntıda gizlidir" data-col-index="0">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Ögrenci Ad Soyad:</label>
                            <input type="text" class="form-control m-input" name="OgrenciAdSoyad" placeholder="Örn : Alper Başda" data-col-index="1">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Alınma Tarihi:</label>
                            <input type="date" class="form-control m-input" name="AlinmaTarihi" data-col-index="2">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Teslim Tarihi:</label>
                            <input type="date" class="form-control m-input" name="TeslimTarihi" data-col-index="3">
                        </div>
                    </div>
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Durum </label>
                            <select name="KitapDurumTeslim" class="form-control m-input" data-col-index="1">
                                <%  foreach (KitapDurumTeslim durum in (KitapDurumTeslim[])Enum.GetValues(typeof(KitapDurumTeslim)))
                                    {%>
                                <option value="<%= (int)durum %>"><%= durum.GetDescription() %></option>
                                <%} %>
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

                <!--Begin::Section-->
                <div class="row table-responsive dataTables_wrapper dt-bootstrap4">

                    <!-- Begin::List-->
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Ögrenci</th>
                                <th>Kitap</th>
                                <th>Alınma Tarihi</th>
                                <th>Teslim Tarihi</th>
                                <th>Teslim Al</th>
                                <th>Kitap Suanki Durum</th>
                                
                            </tr>
                        </thead>
                        <tbody>

                            <asp:Repeater ID="OduncListem" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td><%# Eval("OgrenciAdi") %></td>
                                        <td><%# Eval("KitapAdi") %></td>
                                        <td><%# Eval("AlinmaTarihi") %></td>
                                        <td><%# Eval("TeslimTarihi") %></td>
                                        <td>

                                            <%# Eval("TeslimTarihi") == null 
                                                    ? $"<a href='../Odunc/TeslimAl.aspx?Id={Eval("Id")}' class='trigger-button'><span class='m-badge m-badge--metal m-badge--danger'> Teslim Al </a></span>" 
                                                    : "<span class='m-badge m-badge--metal m-badge--info'> Kütüphanede </span>" %>
                                        </td>
                                        <td><%#  (KitapDurum)Eval("KitapDurum") == KitapDurum.Ogrenci
                                                      ? "<span class='m-badge m-badge--metal m-badge--light'> Ögrencide </span>" 
                                                      : "<span class='m-badge m-badge--metal m-badge--light'> Kütüphanede </span>"   %></td>
                                        
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
<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="../Scripts/Site/fill-input.js"></script>
</asp:Content>
