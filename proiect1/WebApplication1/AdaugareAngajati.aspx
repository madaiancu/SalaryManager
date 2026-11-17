
<%@ Page Title="Adăugare Angajat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdaugareAngajat.aspx.cs" Inherits="WebApplication1.AdaugareAngajat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titlu { color: #142d4e; margin-bottom: 8px; }
        .subtitlu { color: #718397; margin-bottom: 25px; }
        .formular { background: #edf5f8; padding: 25px; border-radius: 12px; max-width: 550px; }
        .formular table { width: 100%; }
        .formular td { padding: 9px; }
        .formular td:first-child { width: 140px; color: #142d4e; }
        .formular input[type="text"] { width: 100%; box-sizing: border-box; padding: 10px; border: 1px solid #cbd8e5; border-radius: 6px; }
        .formular input[type="text"]:focus { outline: none; border-color: #0d9ba8; }
        .buton-salvare { background: #0d9ba8; color: white; border: none; padding: 11px 18px; border-radius: 6px; font-weight: bold; cursor: pointer; }
        .buton-renunta { background: #142d4e; color: white; border: none; padding: 11px 18px; border-radius: 6px; font-weight: bold; cursor: pointer; margin-left: 8px; }
        .buton-salvare:hover { background: #087f8a; }
        .buton-renunta:hover { background: #24476d; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="titlu">Adăugare Angajat Nou</h2>
    <p class="subtitlu">Completează informațiile pentru înregistrarea unui angajat.</p>

    <asp:Label ID="lblMesaj" runat="server" Font-Bold="true"
        Style="margin-bottom: 15px; display: block;" />

    <div class="formular">
        <table>
            <tr>
                <td><strong>Nume:</strong></td>
                <td>
                    <asp:TextBox ID="txtNume" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvNume" runat="server"
                        ControlToValidate="txtNume" ErrorMessage="Numele este obligatoriu!"
                        ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td><strong>Prenume:</strong></td>
                <td>
                    <asp:TextBox ID="txtPrenume" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvPrenume" runat="server"
                        ControlToValidate="txtPrenume" ErrorMessage="Prenumele este obligatoriu!"
                        ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td><strong>Funcție:</strong></td>
                <td><asp:TextBox ID="txtFunctie" runat="server" /></td>
            </tr>
            <tr>
                <td><strong>Salariu de bază:</strong></td>
                <td>
                    <asp:TextBox ID="txtSalarBaza" runat="server" Text="4325" />
                    <asp:RangeValidator ID="rvSalar" runat="server"
                        ControlToValidate="txtSalarBaza" MinimumValue="0"
                        MaximumValue="1000000" Type="Double"
                        ErrorMessage="Salariul trebuie să fie un număr valid!"
                        ForeColor="Red" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td><strong>Spor (%):</strong></td>
                <td><asp:TextBox ID="txtSpor" runat="server" Text="0" /></td>
            </tr>
            <tr>
                <td><strong>Premii brute:</strong></td>
                <td><asp:TextBox ID="txtPremii" runat="server" Text="0" /></td>
            </tr>
            <tr>
                <td><strong>Rețineri:</strong></td>
                <td><asp:TextBox ID="txtRetineri" runat="server" Text="0" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right; padding-top: 15px;">
                    <asp:Button ID="btnSalveaza" runat="server"
                        Text="Salvează Angajat" CssClass="buton-salvare"
                        OnClick="btnSalveaza_Click" />

                    <asp:Button ID="btnRenunta" runat="server"
                        Text="Renunță" CssClass="buton-renunta"
                        OnClick="btnRenunta_Click" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
