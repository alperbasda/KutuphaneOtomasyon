<%@ Page Title="Kitap Listesi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KitapListesi.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Kitap.KitapListele" %>

<%@ Register Src="../KitapKategori/KitapAraKitapKategoriSecici.ascx" TagName="KitapAraKategoriSecici" TagPrefix="UserControl" %>
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
                        <h6 class="m-subheader__title m-subheader__title--separator">Kitaplar</h6>
                    </div>
                </div>
            </div>

            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::SearchArea-->
                <div class="row m--margin-bottom-20 text-center justify-content-center">
                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                        <label>Kitap Kategorisi</label>
                        <UserControl:KitapAraKategoriSecici ID="KitapAraKategoriUserControl" runat="server" />
                    </div>
                </div>
                <form method="get" class="m-form m-form--fit">
                    <div class="row m--margin-bottom-20 text-center justify-content-center">

                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Yayın Yılı:</label>

                            <select name="YayinYili" class="form-control m-input">
                                <option value="">Yayın Yılı Seçin</option>
                                <% for (int i = 1700; i <= DateTime.Now.Year; i++)
                                    {%>
                                <option value="<%=i %>"><% =i %></option>
                                <% } %>
                            </select>
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Durum:</label>
                            <select name="KitapDurum" class="form-control m-input" data-col-index="1">
                                <%  foreach (KitapDurum durum in (KitapDurum[])Enum.GetValues(typeof(KitapDurum)))
                                    {%>
                                <option value="<%= (int)durum %>"><%= durum.GetDescription() %></option>
                                <%} %>
                            </select>
                        </div>
                        <input type="hidden" name="KategoriId" />
                    </div>
                    <div class="row m--margin-bottom-20 text-center justify-content-center">
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Kitap Adı:</label>
                            <input type="text" class="form-control m-input" name="KitapAdi" placeholder="Örn : Safiye Sultan" data-col-index="0">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>ISBN:</label>
                            <input type="number" class="form-control m-input" name="ISBN" placeholder="Örn : 6534547842467" data-col-index="3">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Kod:</label>
                            <input type="text" class="form-control m-input" name="Kod" placeholder="Örn : 435634634" data-col-index="2">
                        </div>
                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                            <label>Yazar:</label>
                            <input type="text" class="form-control m-input" name="Yazar" placeholder="Örn : Dostoyevski" data-col-index="4">
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


                <!--Begin::Section-->
                <div class="row table-responsive dataTables_wrapper dt-bootstrap4">

                    <!-- Begin::List-->
                    <table class="table table-striped">
                        <thead>
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
                        </thead>
                        <tbody>
                            <asp:Repeater ID="kitapRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td><%# Eval("KitapKategoriAdi") %></td>
                                        <td><%# Eval("Adi") %></td>
                                        <td><%# Eval("Kod") %></td>
                                        <td><%# Eval("Yazar") %></td>
                                        <td><%# Eval("YayinYili") %></td>
                                        <td><%# Eval("ISBN") %></td>
                                        <td><%# Eval("SayfaSayisi") %></td>
                                        <td><span class="m-badge  m-badge--metal m-badge--accent">
                                            <%# ((KitapDurum)Eval("KitapDurum")).GetDescription() %></span></td>
                                        <td><a href="../KitapAnahtar/KitapAnahtarListesi.aspx?KitapId=<%# Eval("Id") %>"><i class="fa fa-eye" style="color: cadetblue"></i></a></td>
                                        <td><a href="../Kitap/KitapDuzenle.aspx?Id=<%# Eval("Id") %>"><i class="fa fa-edit" style="color: coral"></i></a></td>
                                        <td><a href="../Kitap/KitapDuzenle.aspx"><i class="fa fa-trash-alt" style="color: red"></i></a></td>
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
    <script src="../Scripts/jquery-3.1.0.min.js"></script>
    <script src="../Scripts/Site/fill-input.js"></script>
    <script type="text/javascript">

        $('.kitap-kategori').change(function () {
            $('input[name=KategoriId]').val($(this).val());
        });
        $('button[type=reset]').click(function () {
            $('.kitap-kategori').val(-1);
            $('input[name=KategoriId]').val("");
        });
    </script>
</asp:Content>
