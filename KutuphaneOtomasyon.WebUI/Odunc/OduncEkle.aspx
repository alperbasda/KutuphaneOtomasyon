<%@ Page Title="Ödünç Kitap Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OduncEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Odunc.OduncEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <!-- BEGIN: Subheader -->
            <div class="m-subheader ">
                <div class="d-flex align-items-center">
                    <div class="mr-auto">
                        <h6 class="m-subheader__title m-subheader__title--separator">Ödünç Kitap Ekle</h6>
                    </div>
                </div>
            </div>
            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::Section-->
                <div class="row">
                    <table class="table table-bordered">
                        <tbody>
                            <tr>
                                <td>Ögrenci Seçilmedi</td>
                                <td>
                                    <button type="button" class="btn btn-default" data-toggle="modal" data-target="#m_modal_user">Ögrenci Seç</button>
                                </td>
                            </tr>
                            <tr>
                                <td>Kitap Seçilmedi</td>
                                <td>
                                    <button type="button" class="btn btn-default" data-toggle="modal" data-target="#m_modal_book">Kitap Seç</button></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="row text-center">
                    <div class="col-12">
                        <div class="form-group m-form__group">
                            <button type="submit" class="btn btn-accent col-3">Kaydet</button>
                        </div>
                    </div>
                </div>
                <!--End::Section-->
            </div>
        </div>
        <!--Begin::UserModal-->
        <div class="modal fade" id="m_modal_user" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Ögrenci Seçimi</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="row">
                                <div class="form-group m-form__group col-6">
                                    <label class="form-control-label">Ögrenci Ad Soyad</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" placeholder="Örn : Alper Başda">
                                        <div class="input-group-append">
                                            <button class="btn btn-brand" type="button"><i class="fa fa-search"></i></button>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group m-form__group col-6">
                                    <label class="form-control-label">Ögrenci No:</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" placeholder="Örn : 201513172051">
                                        <div class="input-group-append">
                                            <button class="btn btn-brand" type="button"><i class="fa fa-search"></i></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--Begin::Section-->
                            <div class="row table-responsive">

                                <!-- Begin::List-->
                                <table class="table table-striped">
                                    <tr>
                                        <th>#</th>
                                        <th>Ad</th>
                                        <th>Soyad</th>
                                        <th>Numara</th>
                                        <th>Kayıt Tarihi</th>
                                        <th>Bölüm</th>
                                        <th>Seç</th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Alper</td>
                                        <td>Başda</td>
                                        <td>201513172004</td>
                                        <td>05.01.2015</td>
                                        <td>Bilgisayar Mühendisliği</td>
                                        <td><a href="../Ogrenci/OgrenciDetay.aspx"><i class="fa fa-check" style="color: green"></i></a></td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Mustafa</td>
                                        <td>Özkaya</td>
                                        <td>201513172001</td>
                                        <td>05.01.2015</td>
                                        <td>Bilgisayar Mühendisliği</td>
                                        <td><a href="../Ogrenci/OgrenciDetay.aspx"><i class="fa fa-check" style="color: green"></i></a></td>
                                    </tr>

                                </table>
                                <!--End::Table-->

                            </div>

                            <!--End::Section-->
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                    </div>
                </div>
            </div>
        </div>
        <!--end::UserModal-->

        <!--Begin::BookModal-->
        <div class="modal fade" id="m_modal_book" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Kitap Seçin</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form>
                            <div class="row">
                                <div class="form-group m-form__group col-6">
                                    <label class="form-control-label">Kitap Adı</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" placeholder="Örn : Nutuk">
                                        <div class="input-group-append">
                                            <button class="btn btn-brand" type="button"><i class="fa fa-search"></i></button>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group m-form__group col-6">
                                    <label class="form-control-label">ISBN:</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control" placeholder="Örn : 5742785432696">
                                        <div class="input-group-append">
                                            <button class="btn btn-brand" type="button"><i class="fa fa-search"></i></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--Begin::Section-->
                            <div class="row table-responsive">

                                <!-- Begin::List-->
                                <table class="table table-striped">
                                    <tr>
                                        <th>#</th>
                                        <th>Adı</th>
                                        <th>Kodu</th>
                                        <th>ISBN</th>
                                        <th>Sayfa Sayısı</th>
                                        <th>Durum</th>
                                        <th>Seç</th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td>Sefiller</td>
                                        <td>41241345135</td>
                                        <td>1236523674285</td>
                                        <td>1032</td>
                                        <td><span class="m-badge  m-badge--metal m-badge--accent">Kütüphane</span></td>
                                        <td><a href="../Kitap/KitapDurum.aspx"><i class="fa fa-check" style="color: green"></i></a></td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Beraber Yürüdük Biz Bu Yıllarda</td>
                                        <td>5453463634</td>
                                        <td>6531238762349</td>
                                        <td>236</td>
                                        <td><span class="m-badge  m-badge--metal m-badge--wide">Ögrenci</span></td>
                                        <td><a href="../Kitap/KitapDurum.aspx"><i class="fa fa-times" style="color: red"></i></a></td>
                                    </tr>
                                </table>
                                <!--End::Table-->

                            </div>

                            <!--End::Section-->
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                    </div>
                </div>
            </div>
        </div>
        <!--end::BookModal-->
    </div>

</asp:Content>
