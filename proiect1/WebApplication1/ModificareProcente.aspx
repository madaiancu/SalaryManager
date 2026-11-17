
<%@ Page Title="Modificare Procente Salariale" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificareProcente.aspx.cs" Inherits="WebApplication1.ModificareProcente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titlu { color: #142d4e; margin-bottom: 8px; }
        .subtitlu { color: #718397; margin-bottom: 25px; }
        .formular { background: #edf5f8; padding: 25px; border-radius: 12px; max-width: 550px; }
        .formular table { width: 100%; }
        .formular td { padding: 10px; color: #142d4e; }
        .formular td:first-child { width: 210px; }
        .formular input[type="text"], .formular input[type="password"] {
            width: 100%; box-sizing: border-box; padding: 11px;
            border: 1px solid #cbd8e5; border-radius: 6px;
            background: white;
        }
        .formular input:focus { outline: none; border-color: #0d9ba8; }
        .btn-salvare {
            background: #0d9ba8 !important; color: white !important;
            border: none; padding: 12px 20px; border-radius: 6px;
            font-weight: bold; cursor: pointer;
        }
        .btn-salvare:hover { background: #087f8a !important; }
        .nota { font-size: 13px; color: #718397; margin-top: 15px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="titlu">Modificare Procente Salariale</h2>
    <p class="subtitlu">Actualizează procentele CAS, CASS și impozit utilizate la calculul salariilor.</p>

    <asp:Label ID="lblMessage" runat="server"
        EnableViewState="false" Font-Bold="true"
        Style="display: block; margin-bottom: 15px;" />

    <div class="formular">
        <table>
            <tr>
                <td><strong>Procent CAS (%):</strong></td>
                <td><asp:TextBox ID="txtCAS" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Procent CASS (%):</strong></td>
                <td><asp:TextBox ID="txtCASS" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Procent Impozit (%):</strong></td>
                <td><asp:TextBox ID="txtImpozit" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Parolă administrare:</strong></td>
                <td><asp:TextBox ID="txtParola" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right; padding-top: 15px;">
                    <asp:Button ID="btnSalveaza" runat="server"
                        Text="Salvează modificările"
                        CssClass="btn-salvare"
                        OnClick="btnSalveaza_Click" />
                </td>
            </tr>
        </table>

        <p class="nota">Modificarea procentelor necesită parola de administrare.</p>
    </div>

</asp:Content>
