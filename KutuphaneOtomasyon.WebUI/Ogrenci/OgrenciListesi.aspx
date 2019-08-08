<%@ Page Title="Ögrenci Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OgrenciListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Ogrenci.OgrenciListesi" %>

<%@ Import Namespace="KutuphaneOtomasyon.WebUI.Helpers" %>
<%@ Register TagPrefix="UserControl" TagName="OgrenciAraFakulteBolumSecici" Src="~/Fakulte/OgrenciAraFakulteBolumSecici.ascx" %>
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
            <div class="m-content">

                <div class="row m--margin-bottom-20 text-center justify-content-center">
                    <UserControl:OgrenciAraFakulteBolumSecici runat="server" />
                </div>

                <form method="get" class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Ad:</label>
                            <input type="text" class="form-control m-input" name="Ad" placeholder="Örn : Alper" data-col-index="0">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Soyad:</label>
                            <input type="text" class="form-control m-input" name="Soyad" placeholder="Örn : Başda" data-col-index="1">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Numara:</label>
                            <input type="number" class="form-control m-input" name="Numara" placeholder="Örn : 3244353463" data-col-index="2">
                        </div>
                        <input type="hidden" name="BolumId" />

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
                                <th>Ad</th>
                                <th>Soyad</th>
                                <th>Numara</th>
                                <th>Bölüm</th>
                                <th>Mail Adresi</th>
                                <th>Memleket Adresi</th>
                                <th>Adresi</th>
                                <th>Telefonu</th>
                                <th>Kayıt Tarihi</th>
                                <th>Düzenle</th>
                                <th>Sil</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="OgrenciListesiRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td><%# Eval("Ad") %></td>
                                        <td><%# Eval("Soyad") %></td>
                                        <td><%# Eval("Numara") %></td>
                                        <td><%# Eval("BolumAdi") %></td>
                                        <td><a data-toggle="modal" data-target="#modalDetail" data-value="<%# Eval("Mail") %>" data-header="Mail Adresi" href="#"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><a data-toggle="modal" data-target="#modalDetail" data-value="<%# Eval("MemleketAdres") %>" data-header="Memleket Adresi" href="#"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><a data-toggle="modal" data-target="#modalDetail" data-value="<%# Eval("Adres") %>" data-header="Adres" href="#"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><a data-toggle="modal" data-target="#modalDetail" data-value="<%# Eval("Telefon") %>" data-header="Telefon" href="#"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><%# Eval("KayitTarihi") %></td>
                                        <td><a href="../Ogrenci/OgrenciDuzenle.aspx?Id=<%# Eval("Id") %>"><i class="fa fa-edit" style="color: coral"></i></a></td>
                                        <td><a href="../Ogrenci/OgrenciSil.aspx?Id=<%# Eval("Id") %>"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
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
                    <!--End::Section-->
                </div>
            </div>
        </div>
    </div>
    <!--Begin::BookModal-->
    <div class="modal fade" id="modalDetail" tabindex="-1" role="dialog" aria-labelledby="modalHeader" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalHeader">Kitap Seçin</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                        <label id="modalValue">Ad:</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                </div>
            </div>
        </div>
    </div>
    <!--end::BookModal-->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script src="../Scripts/jquery-3.1.0.min.js"></script>
    <script type="text/javascript">
        function degis(item) {
            $('input[name=BolumId]').val($(item).val());
        }
        $('button[type=reset]').click(function () {
            $('.fakulte-search').val(-1);
            $('.bolum-listesi').children().remove();
            $('input[name=BolumId]').val("");
        });
    </script>
    <script type="text/javascript">
        $('a[data-target="#modalDetail"]').click(function () {
            $('#modalValue').html($(this).data('value'));
            $('#modalHeader').html($(this).data('header'));
        });
</script>
</asp:Content>
