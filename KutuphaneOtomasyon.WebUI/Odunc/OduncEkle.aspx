<%@ Page Title="Ödünç Kitap Ekle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OduncEkle.aspx.cs" Inherits="KutuphaneOtomasyon.WebUI.Odunc.OduncEkle" %>

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
                        <h6 class="m-subheader__title m-subheader__title--separator">Ödünç Kitap Ekle</h6>
                    </div>
                </div>
            </div>
            <!-- END: Subheader -->
            <div class="m-content">
                <!--Begin::Section-->
                <form id="form" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        <Scripts>
                            <asp:ScriptReference Name="jquery" />
                            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                        </Scripts>
                    </asp:ScriptManager>
                    <div class="row">
                        <table class="table table-bordered">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="ogrenciBilgi" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="SecilenOgrenci" runat="server"> Ögrenci Seçilmedi </asp:Label>
                                                <asp:TextBox hidden="hidden" ID="OgrenciId" runat="server"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-default" data-toggle="modal" data-target="#m_modal_user">Ögrenci Seç</button>
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
                                                        <div class="row">
                                                            <div class="form-group m-form__group col-12">
                                                                <label class="form-control-label">Ögrenci No </label>
                                                                <label class="m-form__help">En az 4 karakter yazın</label>
                                                                <div class="input-group">
                                                                    <asp:TextBox
                                                                        type="text"
                                                                        CssClass="form-control"
                                                                        placeholder="Örn : 201513172051"
                                                                        ID="Numara"
                                                                        runat="server"></asp:TextBox>
                                                                    <div class="input-group-append">
                                                                        <asp:Button
                                                                            CssClass="btn btn-brand"
                                                                            Text="Ara"
                                                                            ID="OgrenciAraButton"
                                                                            OnClick="AraButton_OnClick" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!--Begin::Section-->
                                                        <asp:UpdatePanel ID="OGrenciUpdatePanel" UpdateMode="Conditional" runat="server">
                                                            <ContentTemplate>
                                                                <div class="row table-responsive">
                                                                    <table class="table table-striped">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>#</th>
                                                                                <th>Ad</th>
                                                                                <th>Soyad</th>
                                                                                <th>Numara</th>
                                                                                <th>Elinde Kitap Varmı</th>
                                                                                <th>Seç</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:Repeater ID="OgrenciRepeater" runat="server">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <td><%# Eval("Id") %></td>
                                                                                        <td><%# Eval("Ad") %></td>
                                                                                        <td><%# Eval("Soyad") %></td>
                                                                                        <td><%# Eval("Numara") %></td>
                                                                                        <td><%# Eval("ElindeKitapVarmi").ToString().ToLower() == "true" ? "Var" :  "Yok" %></td>
                                                                                        <td>
                                                                                            <asp:Button
                                                                                                CssClass="btn btn-brand"
                                                                                                CommandArgument='<%# Eval("Id") %>'
                                                                                                CommandName='<%# Eval("Ad") + "," + Eval("Soyad")+ "," + Eval("Numara") %>'
                                                                                                ID="OgrenciAta"
                                                                                                Text="Ata"
                                                                                                OnClick="OgrenciAta_OnClick"
                                                                                                runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <asp:UpdateProgress ID="OgrenciUpdatePanelProgress" runat="server">
                                                                    <ProgressTemplate>
                                                                        <label>Ögrenciler yükleniyor...</label>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="OgrenciAraButton" EventName="Click" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end::UserModal-->
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ChildrenAsTriggers="false" UpdateMode="Conditional" ID="kitapBilgi" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="SecilenKitap" runat="server"> Kitap Seçilmedi </asp:Label>
                                                <asp:TextBox hidden="hidden" ID="KitapId" runat="server"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-default" data-toggle="modal" data-target="#m_modal_book">Kitap Seç</button>
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
                                                        <div class="row">
                                                            <div class="form-group m-form__group col-6">
                                                                <label class="form-control-label">Kitap Adı </label>
                                                                <label class="m-form__help">En az 4 karakter yazın</label>
                                                                <div class="input-group">
                                                                    <asp:TextBox
                                                                        type="text"
                                                                        CssClass="form-control"
                                                                        placeholder="Örn : Nutuk"
                                                                        ID="KitapAdiTb"
                                                                        runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="form-group m-form__group col-6">
                                                                <label class="form-control-label">ISBN </label>
                                                                <label class="m-form__help">En az 4 karakter yazın</label>
                                                                <div class="input-group">
                                                                    <asp:TextBox
                                                                        type="text"
                                                                        CssClass="form-control"
                                                                        placeholder="Örn : 5742785432696"
                                                                        ID="ISBNTb"
                                                                        runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row text-center">
                                                            <div class="form-group m-form__group col-12">
                                                                <asp:Button
                                                                    CssClass="btn btn-brand"
                                                                    Text="Ara"
                                                                    ID="KitapAraIsim"
                                                                    OnClick="KitapAraIsim_OnClick"
                                                                    runat="server" />
                                                            </div>
                                                        </div>
                                                        <!--Begin::Section-->
                                                        <div class="row table-responsive">
                                                            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="">
                                                                        <table class="table table-striped">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th>#</th>
                                                                                    <th>Adı</th>
                                                                                    <th>Kodu</th>
                                                                                    <th>ISBN</th>
                                                                                    <th>Sayfa Sayısı</th>
                                                                                    <th>Durum</th>
                                                                                    <th>Seç</th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <asp:Repeater ID="kitapRepeater" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td><%# Eval("Id") %></td>
                                                                                            <td><%# Eval("Adi") %></td>
                                                                                            <td><%# Eval("Kod") %></td>
                                                                                            <td><%# Eval("ISBN") %></td>
                                                                                            <td><%# Eval("SayfaSayisi") %></td>
                                                                                            <td><span class="m-badge  m-badge--metal m-badge--accent">
                                                                                                <%# ((KitapDurum)Eval("KitapDurum")).GetDescription() %></span></td>
                                                                                            <td>
                                                                                                <%# (KitapDurum)Eval("KitapDurum") == KitapDurum.Ogrenci 
                                                                                        ? "<span class='m-badge m-badge--metal m-badge--danger'> Ögrencide </span>" 
                                                                                        : "<a href='#' onclick='ates(this)' class='m-badge m-badge--metal m-badge--info trigger-button'> Seç </a>"  %>
                                                                                                <asp:Button
                                                                                                    CssClass="kitapSecimim"
                                                                                                    Style="display: none;"
                                                                                                    ID="kitapSecimiYap"
                                                                                                    CommandArgument='<%# Eval("Id") %>'
                                                                                                    CommandName='<%# Eval("Adi") + "," + Eval("ISBN") %>'
                                                                                                    OnClick="OnClick"
                                                                                                    runat="server" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>

                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                    <asp:UpdateProgress ID="KitapProgress" runat="server">
                                                                        <ProgressTemplate>
                                                                            <label>Kitaplar yükleniyor...</label>
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="KitapAraIsim" EventName="Click" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                        <!--End::Section-->
                                                    </div>
                                                    <div class="modal-footer">
                                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end::BookModal-->
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="row text-center">
                        <div class="col-12">
                            <div class="form-group m-form__group">
                                <asp:Button ID="Kaydet" OnClick="Kaydet_OnClick" CssClass="btn btn-accent col-3" Text="Kaydet" runat="server" />
                            </div>
                        </div>
                    </div>


                </form>
                <!--End::Section-->
            </div>
        </div>



    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        function ates(item) {
            $(item).parent('td').children('input').click();
        }
    </script>
</asp:Content>
