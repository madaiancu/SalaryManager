
<%@ Page Title="Generare Fluturași Salariu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerareFluturas.aspx.cs" Inherits="WebApplication1.GenerareFluturas" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titlu { color: #142d4e; margin-bottom: 8px; }
        .subtitlu { color: #718397; margin-bottom: 25px; }
        .zona-selectie { background: #edf5f8; padding: 20px; border-radius: 10px; margin-bottom: 20px; }
        .zona-selectie label { color: #142d4e; font-weight: bold; }
        .lista-angajati { padding: 10px; border: 1px solid #cbd8e5; border-radius: 6px; background: white; width: 300px; max-width: 100%; margin: 0 12px; }
        .buton-afisare { background: #0d9ba8 !important; color: white !important; border: none; padding: 11px 18px; border-radius: 6px; font-weight: bold; cursor: pointer; }
        .buton-afisare:hover { background: #087f8a !important; }
        .zona-raport { width: 100%; overflow-x: auto; margin-top: 20px; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="titlu">Generare Fluturaș de Salariu</h2>


    <div class="zona-selectie">
        <label for="ddlAngajati">Selectează angajatul:</label>

        <asp:DropDownList ID="ddlAngajati" runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlAngajati_SelectedIndexChanged"
            CssClass="lista-angajati">
        </asp:DropDownList>

        <asp:Button ID="btnToate" runat="server"
            Text="Afișează toți angajații"
            OnClick="btnToate_Click"
            CssClass="buton-afisare" />
    </div>

    <asp:Label ID="lblEroare" runat="server"
        ForeColor="Red" Font-Bold="true" />

    <div class="zona-raport">
        <CR:CrystalReportViewer ID="crvFluturas" runat="server"
            AutoDataBind="true"
            EnableDatabaseLogonPrompt="False"
            ToolPanelView="None" />
    </div>

</asp:Content>
