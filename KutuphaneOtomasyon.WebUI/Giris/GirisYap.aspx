<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GirisYap.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Giris.GirisYap" %>
<%@ Import Namespace="KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kullanici" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kutuphane Otomasyon Giriş</title>

    <!--Theme Style -->
    <link href="../Content/Metronic/style.bundle.css" rel="stylesheet" />
    <link href="../Content/Metronic/vendors.bundle.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js"></script>
    <script>
        WebFont.load({
            google: { "families": ["Poppins:300,400,500,600,700", "Roboto:300,400,500,600,700"] },
            active: function () {
                sessionStorage.fonts = true;
            }
        });
    </script>
    <!--Theme Style End-->
</head>
<body>
    <div class="m-grid m-grid--hor m-grid--root m-page">
        <div class="m-grid__item m-grid__item--fluid m-grid m-grid--desktop m-grid--ver-desktop m-grid--hor-tablet-and-mobile m-login m-login--6" id="m_login">
            <div class="m-grid__item   m-grid__item--order-tablet-and-mobile-2  m-grid m-grid--hor m-login__aside " style="background-image: url(../Content/Images/bg-4.jpg);">
                <div class="m-grid__item">
                    <div class="m-login__logo">
                    </div>
                </div>
                <div class="m-grid__item m-grid__item--fluid m-grid m-grid--ver">
                    <div class="m-grid__item m-grid__item--middle text-center">
                        <span class="m-login__title">Kütüphane Otomasyon Sistemine Hoşgeldiniz</span>
                        <span class="m-login__subtitle">Lütfen Giriş Yapın</span>
                    </div>
                </div>

            </div>
            <div class="m-grid__item m-grid__item--fluid  m-grid__item--order-tablet-and-mobile-1  m-login__wrapper">

                <!--begin::Body-->
                <div class="m-login__body">
                    <!--begin::Signin-->
                    <div class="m-login__signin">
                        <!--begin::Form-->
                        <form class="m-login__form m-form" id="girisForm" runat="server">
                            <dav:metadatasource runat="server" id="msGirisModel" objecttype="<%$ Code: typeof(GirisModel) %>" />
                            <div class="form-group m-form__group">
                                <asp:TextBox CssClass="form-control m-input m-login__form-input--last" ID="KullaniciAdi" ValidationGroup="GirisModel" placeholder="Kullanıcı adı" runat="server" />
                                <dav:dataannotationsvalidator id="VaKullaniciAdi" runat="server" cssclass="m-form__help"
                                    validationgroup="GirisModel"
                                    metadatasourceid="msGirisModel"
                                    controltovalidate="KullaniciAdi"
                                    objectproperty="KullaniciAdi" />

                            </div>
                            <div class="form-group m-form__group">
                                <asp:TextBox CssClass="form-control m-input m-login__form-input--last" type="password" ID="sifre" ValidationGroup="GirisModel" placeholder="Sifre" runat="server"></asp:TextBox>
                                <dav:dataannotationsvalidator id="Dataannotationsvalidator2" runat="server" cssclass="m-form__help"
                                    validationgroup="GirisModel"
                                    metadatasourceid="msGirisModel"
                                    controltovalidate="Sifre"
                                    objectproperty="Sifre" />
                            </div>
                            <!--begin::Action-->
                            <div class="m-login__action">
                                <a href="#" id="f-pass" class="m-link">
                                    <span data-toggle="m-tooltip" title="" data-placement="bottom" data-original-title="Proje içeriğinde yer almadığı için bu alan kodlanmamıştır !!!">Şifremi Unuttum ?</span>
                                </a>
                                <a href="#">
                                    <asp:Button ValidationGroup="GirisModel" OnClick="SubmitButton_OnClick" ID="SubmitButton" Text="Giriş" CssClass="btn btn-primary m-btn m-btn--pill m-btn--custom m-btn--air m-login__btn m-login__btn--primary" runat="server" />
                                </a>
                            </div>
                            <!--end::Action-->

                        </form>
                        <!--end::Form-->



                    </div>

                    <!--end::Signin-->
                </div>

                <!--end::Body-->
            </div>
        </div>
    </div>

    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/Metronic/scripts.bundle.js"></script>
    <script src="../Scripts/Metronic/vendors.bundle.js"></script>
    <script src="../Scripts/Metronic/toastr.js"></script>
    <script src="../Scripts/Metronic/toast.js"></script>
</body>
</html>
