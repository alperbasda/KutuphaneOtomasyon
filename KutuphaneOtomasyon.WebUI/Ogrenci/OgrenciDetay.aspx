<%@ Page Title="Ögrenci Detay" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OgrenciDetay.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Ogrenci.OgrenciDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-grid__item m-grid__item--fluid  m-grid m-grid--ver-desktop m-grid--desktop m-body align-custom">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">

            <div class="m-content">
                <div class="row">
                    <div class="col-xl-3 col-lg-4">
                        <div class="m-portlet m-portlet--full-height   m-portlet--rounded">
                            <div class="m-portlet__body">
                                <div class="m-card-profile">
                                    <div class="m-card-profile__details">
                                        <span class="m-card-profile__name">Alper Başda</span>
                                        <a href="#" class="m-card-profile__email m-link">alperbasda@gmail.com</a>
                                        <a href="#" class="m-card-profile__email m-link">0 551 432 73 31 </a>
                                    </div>
                                </div>

                                <div class="m-portlet__body-separator"></div>
                                <div class="m-widget1 m-widget1--paddingless">
                                    <div class="m-widget1__item text-center">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col">
                                                <h3 class="m-widget1__title">Bölüm</h3>
                                                <span class="m-widget1__desc">Bilgisayar Mühendisliği</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="m-widget1__item text-center">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col">
                                                <h3 class="m-widget1__title">Numara</h3>
                                                <span class="m-widget1__desc">201513172003</span>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="m-widget1__item text-center">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col">
                                                <h3 class="m-widget1__title">Kayıt Tarihi</h3>
                                                <span class="m-widget1__desc">10.12.2015</span>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-9 col-lg-8">
                        <div class="m-portlet m-portlet--full-height m-portlet--tabs   m-portlet--rounded">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-tools">
                                    <ul class="nav nav-tabs m-tabs m-tabs-line   m-tabs-line--left m-tabs-line--primary" role="tablist">
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_user_profile_tab_4" role="tab" aria-selected="false">
                                                <i class="flaticon-share m--hide"></i>
                                                Kişisel Bilgiler
                                            </a>
                                        </li>
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_user_profile_tab_1" role="tab" aria-selected="false">
                                                <i class="flaticon-share m--hide"></i>
                                                İletişim - Adres Bilgileri
                                            </a>
                                        </li>
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_user_profile_tab_2" role="tab" aria-selected="false">Ödünç Geçmişi
                                            </a>
                                        </li>
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link active show" data-toggle="tab" href="#m_user_profile_tab_3" role="tab" aria-selected="true">Ögrencideki Kitaplar
                                            </a>
                                        </li>

                                    </ul>
                                </div>
                            </div>
                            <div class="tab-content">
                                <div class="tab-pane" id="m_user_profile_tab_1">
                                    <form class="m-form m-form--fit m-form--label-align-right p-3">
                                        <div class="col-md-4 col-sm-12" style="float: left">
                                            <!--begin::Portlet-->
                                            <div class="m-portlet">
                                                <div class="m-portlet__head">
                                                    <div class="m-portlet__head-caption">
                                                        <div class="m-portlet__head-title">
                                                            <span class="m-portlet__head-icon m--hide">
                                                                <i class="la la-gear"></i>
                                                            </span>
                                                            <h3 class="m-portlet__head-text">Mail Adresi Ekle
                                                            </h3>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--begin::Form-->
                                                <div class="m-portlet__body">
                                                    <div class="m-form__section m-form__section--first">
                                                        <div class="form-group m-form__group">
                                                            <input type="email" class="form-control m-input" placeholder="Mail adresi yazın...">
                                                        </div>
                                                        <div class="form-group m-form__group">
                                                            <div class="m-form__actions m-form__actions">
                                                                <button type="submit" class="btn btn-primary col-12">Kaydet</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--end::Form-->
                                            </div>
                                            <!--end::Portlet-->
                                        </div>
                                        <div class="col-md-4 col-sm-12" style="float: left">
                                            <!--begin::Portlet-->
                                            <div class="m-portlet">
                                                <div class="m-portlet__head">
                                                    <div class="m-portlet__head-caption">
                                                        <div class="m-portlet__head-title">
                                                            <span class="m-portlet__head-icon m--hide">
                                                                <i class="la la-gear"></i>
                                                            </span>
                                                            <h3 class="m-portlet__head-text">Telefon Numarası Ekle
                                                            </h3>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--begin::Form-->
                                                <div class="m-portlet__body">
                                                    <div class="m-form__section m-form__section--first">
                                                        <div class="form-group m-form__group">
                                                            <input type="tel" class="form-control m-input" placeholder="Telefon numarası yazın...">
                                                        </div>
                                                        <div class="form-group m-form__group">
                                                            <div class="m-form__actions m-form__actions">
                                                                <button type="submit" class="btn btn-primary col-12">Kaydet</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--end::Form-->
                                            </div>
                                            <!--end::Portlet-->
                                        </div>
                                        <div class="col-md-4 col-sm-12" style="float: left">
                                            <!--begin::Portlet-->
                                            <div class="m-portlet">
                                                <div class="m-portlet__head">
                                                    <div class="m-portlet__head-caption">
                                                        <div class="m-portlet__head-title">

                                                            <div class="m-radio-inline">
                                                                <label class="m-radio">
                                                                    <input type="radio" name="adresTipi">
                                                                    Memleket 
                                                                    <span></span>
                                                                </label>
                                                                <label class="m-radio">
                                                                    <input type="radio" checked name="adresTipi">
                                                                    Ev
                                                                    <span></span>
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--begin::Form-->
                                                <div class="m-portlet__body">
                                                    <div class="m-form__section m-form__section--first">

                                                        <div class="form-group m-form__group">
                                                            <textarea class="form-control m-input" placeholder="Adres yazın.." rows="2"></textarea>
                                                        </div>
                                                        <div class="form-group m-form__group">
                                                            <div class="m-form__actions m-form__actions">
                                                                <button type="submit" class="btn btn-primary col-12">Kaydet</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--end::Form-->
                                            </div>
                                            <!--end::Portlet-->
                                        </div>
                                    </form>
                                    <!--begin::Portlet-->
                                    <div class="m-portlet">
                                        <div class="m-portlet__head">
                                            <div class="m-portlet__head-caption">
                                                <div class="m-portlet__head-title">
                                                    <span class="m-portlet__head-icon" data-toggle="m-tooltip" data-placement="bottom" data-original-title="İşlem geçmişi 1 yıllık tutulmaktadır.">
                                                        <i class="flaticon-questions-circular-button"></i>
                                                    </span>
                                                    <h3 class="m-portlet__head-text">Geçmiş işlemler
                                                    </h3>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="m-portlet__body">

                                            <!--begin::Section-->
                                            <div class="m-section">

                                                <div class="m-section__content">
                                                    <!--begin::Preview-->
                                                    <div class="m-demo">
                                                        <div class="m-demo__preview">
                                                            <div class="m-list-timeline">
                                                                <div class="m-list-timeline__items">
                                                                    <div class="m-list-timeline__item">
                                                                        <span class="m-list-timeline__badge"></span>
                                                                        <span class="m-list-timeline__text">12 new users registered and pending for activation</span>
                                                                        <span class="m-list-timeline__time">Just now</span>
                                                                    </div>
                                                                    <div class="m-list-timeline__item">
                                                                        <span class="m-list-timeline__badge"></span>
                                                                        <span class="m-list-timeline__text">Scheduled system reboot completed <span class="m-badge m-badge--success m-badge--wide">completed</span></span>
                                                                        <span class="m-list-timeline__time">14 mins</span>
                                                                    </div>
                                                                    <div class="m-list-timeline__item">
                                                                        <span class="m-list-timeline__badge"></span>
                                                                        <span class="m-list-timeline__text">New order has been planced and pending for processing</span>
                                                                        <span class="m-list-timeline__time">20 mins</span>
                                                                    </div>
                                                                    <div class="m-list-timeline__item">
                                                                        <span class="m-list-timeline__badge"></span>
                                                                        <span class="m-list-timeline__text">Database server overloaded 80% and requires quick reboot <span class="m-badge m-badge--info m-badge--wide">settled</span></span>
                                                                        <span class="m-list-timeline__time">1 hr</span>
                                                                    </div>
                                                                    <div class="m-list-timeline__item">
                                                                        <span class="m-list-timeline__badge"></span>
                                                                        <span class="m-list-timeline__text">System error occured and hard drive has been shutdown - <a href="#" class="m-link">Check</a></span>
                                                                        <span class="m-list-timeline__time">2 hrs</span>
                                                                    </div>
                                                                    <div class="m-list-timeline__item">
                                                                        <span class="m-list-timeline__badge"></span>
                                                                        <span class="m-list-timeline__text">Production server is rebooting...</span>
                                                                        <span class="m-list-timeline__time">3 hrs</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!--end::Preview-->

                                                </div>
                                            </div>

                                            <!--end::Section-->

                                        </div>
                                    </div>
                                    <!-- end:Portlet-->
                                </div>
                                <div class="tab-pane" id="m_user_profile_tab_2">
                                    <form class="m-form m-form--fit">
                                        <div class="col-12">
                                            <div class="m-content">
                                                <!--Begin::Section-->
                                                <div class="row table-responsive">
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
                                                </div>
                                                <!--End::Section-->
                                            </div>
                                        </div>
                                    </form>
                                </div>
                                <div class="tab-pane active show" id="m_user_profile_tab_3">
                                        <form class="m-form m-form--fit">
                                        <div class="col-12">
                                            <div class="m-content">


                                                <!--Begin::Section-->
                                                <div class="row table-responsive">

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

                                                </div>

                                                <!--End::Section-->

                                            </div>
                                        </div>
                                    </form>
                                </div>
                                <div class="tab-pane" id="m_user_profile_tab_4">
                                    <!--begin::user information-->
                                    <div class="row">
                                        <div class="col-lg-12">

                                            <!--begin::Portlet-->
                                            <div class="m-portlet">
                                                
                                                <!--begin::Form-->
                                                <form class="m-form m-form--label-align-right">
                                                    <div class="m-portlet__body">
                                                        <div class="m-form__section m-form__section--first">
                                                            <div class="m-form__heading">
                                                                <h3 class="m-form__heading-title">Son Güncelleme : 12.10.2015 13:08:11</h3>
                                                            </div>
                                                            <div class="form-group m-form__group row">
                                                                <label class="col-lg-2 col-form-label">Adı:</label>
                                                                <div class="col-lg-6">
                                                                    <input type="text" class="form-control m-input" placeholder="Ögrenci adını yazın...">
                                                                </div>
                                                            </div>
                                                            <div class="form-group m-form__group row">
                                                                <label class="col-lg-2 col-form-label">Soyadı:</label>
                                                                <div class="col-lg-6">
                                                                    <input type="text" class="form-control m-input" placeholder="Ögrenci soyadını yazın...">
                                                                </div>
                                                            </div>
                                                            <div class="form-group m-form__group row">
                                                                <label class="col-lg-2 col-form-label">Numarası:</label>
                                                                <div class="col-lg-6">
                                                                    <input type="number" class="form-control m-input" placeholder="Ögrenci numarası yazın...">
                                                                </div>
                                                            </div>
                                                            <div class="form-group m-form__group row">
                                                                <label class="col-lg-2 col-form-label" for="fakülteSec">Fakülte Seçin</label>
                                                                <div class="col-lg-6">
                                                                    <select class="form-control" id="fakülteSec">
                                                                        <option>Mühendislik Fakültesi</option>
                                                                        <option>Fen Edebiyat Fakültesi</option>
                                                                        <option>İktisadi ve İdari Bilimler Fakültesi</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <div class="form-group m-form__group row">
                                                                <label class="col-lg-2 col-form-label" for="bolumSec">Bölüm Seçin</label>
                                                                <div class="col-lg-6">
                                                                    <select class="form-control m-input" id="bolumSec">
                                                                        <option>Bilgisayar Mühendisliği</option>
                                                                        <option>İnşaat Mühendisliği</option>
                                                                        <option>Endüstri Mühendisliği</option>
                                                                    </select>
                                                                </div>
                                                                
                                                            </div>
                                                        
                                                        </div>
                                                        
                                                    </div>
                                                    <div class="m-portlet__foot m-portlet__foot--fit pull-right">
                                                        <div class="m-form__actions m-form__actions">
                                                            <div class="row">
                                                                <div class="col-lg-2"></div>
                                                                <div class="col-lg-6">
                                                                    <button type="submit" class="btn btn-primary">Düzenle</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </form>

                                                <!--end::Form-->
                                            </div>

                                            <!--end::Portlet-->

                                        </div>
                                    </div>
                                    <!--end user information-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
