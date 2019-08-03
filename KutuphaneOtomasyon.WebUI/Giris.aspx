<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kutuphane Otomasyon Giriş</title>

    <!--Theme Style -->
    <link href="Content/Metronic/style.bundle.css" rel="stylesheet" />
    <link href="Content/Metronic/vendors.bundle.css" rel="stylesheet" />
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
            <div class="m-grid__item   m-grid__item--order-tablet-and-mobile-2  m-grid m-grid--hor m-login__aside " style="background-image: url(Content/Images/bg-4.jpg);">
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
                        <form class="m-login__form m-form" action="">
                            <div class="form-group m-form__group">
                                <input class="form-control m-input" type="text" placeholder="Kullanıcı Adi" name="kullaniciAdi" autocomplete="off">
                            </div>
                            <div class="form-group m-form__group">
                                <input class="form-control m-input m-login__form-input--last" type="password" placeholder="Şifre" name="sifre">
                            </div>
                        </form>

                        <!--end::Form-->

                        <!--begin::Action-->
                        <div class="m-login__action">
                            <a href="#" id="f-pass" class="m-link">
                                <span>Şifremi Unuttum ?</span>
                            </a>
                            <a href="#">
                                <button id="m_login_signin_submit" class="btn btn-primary m-btn m-btn--pill m-btn--custom m-btn--air m-login__btn m-login__btn--primary">Giriş</button>
                            </a>
                        </div>

                        <!--end::Action-->

                    </div>

                    <!--end::Signin-->
                </div>

                <!--end::Body-->
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/Metronic/toastr.js"></script>
    <script src="Scripts/Metronic/toast.js"></script>
    <script src="Scripts/Site/login.js"></script>
</body>
</html>
