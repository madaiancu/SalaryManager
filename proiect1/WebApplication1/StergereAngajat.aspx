
<%@ Page Title="Ștergere Angajat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StergereAngajat.aspx.cs" Inherits="WebApplication1.StergereAngajat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titlu { color: #142d4e; margin-bottom: 8px; }
        .subtitlu { color: #718397; margin-bottom: 25px; }
        .formular-stergere { background: #edf5f8; padding: 25px; border-radius: 12px; max-width: 550px; }
        .formular-stergere select { width: 100%; padding: 12px; border: 1px solid #cbd8e5; border-radius: 6px; background: white; margin-top: 12px; }
        .formular-stergere table { width: 100%; margin: 15px 0; }
        .formular-stergere td { padding: 9px; color: #142d4e; }
        .confirmare { border-top: 1px solid #cbd8e5; padding-top: 20px; }
        .avertizare { color: #c0392b; font-size: 16px; }
        .btn-sterge { background: #d9534f !important; color: white !important; border: none; padding: 11px 18px; border-radius: 6px; font-weight: bold; cursor: pointer; }
        .btn-renunta { background: #142d4e !important; color: white !important; border: none; padding: 11px 18px; border-radius: 6px; font-weight: bold; cursor: pointer; margin-left: 8px; }
        .btn-sterge:hover { background: #b93b37 !important; }
        .btn-renunta:hover { background: #24476d !important; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="titlu">Ștergere Angajat</h2>
    <p class="subtitlu">Selectează angajatul pe care dorești să îl elimini din sistem.</p>

    <asp:Label ID="lblMesaj" runat="server" Font-Bold="true"
        Style="margin-bottom: 15px; display: block;" />

    <div class="formular-stergere">

        <strong>Selectează angajatul de șters:</strong>

        <asp:DropDownList ID="ddlAngajati" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlAngajati_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:Panel ID="pnlConfirmare" runat="server"
            Visible="false" CssClass="confirmare">

            <h4 class="avertizare">
                Ești sigur că dorești ștergerea acestui angajat?
            </h4>

            <table>
                <tr>
                    <td><strong>ID Angajat:</strong></td>
                    <td><asp:Label ID="lblID" runat="server" /></td>
                </tr>
                <tr>
                    <td><strong>Nume și Prenume:</strong></td>
                    <td><asp:Label ID="lblNumeComplet" runat="server" Font-Bold="true" /></td>
                </tr>
                <tr>
                    <td><strong>Funcție:</strong></td>
                    <td><asp:Label ID="lblFunctie" runat="server" /></td>
                </tr>
                <tr>
                    <td><strong>Salariu de bază:</strong></td>
                    <td><asp:Label ID="lblSalar" runat="server" /> lei</td>
                </tr>
            </table>

            <div style="text-align: right;">
                <asp:Button ID="btnSterge" runat="server"
                    Text="Confirmă ștergerea"
                    CssClass="btn-sterge"
                    OnClick="btnSterge_Click" />

                <asp:Button ID="btnRenunta" runat="server"
                    Text="Renunță"
                    CssClass="btn-renunta"
                    CausesValidation="false"
                    OnClick="btnRenunta_Click" />
            </div>

        </asp:Panel>

    </div>

</asp:Content>
