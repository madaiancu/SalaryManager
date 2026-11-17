
<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication1.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .home-title { color: #142d4e; margin-bottom: 10px; }
        .home-desc { color: #718397; margin-bottom: 30px; }
        .home-section { padding: 18px 0; border-bottom: 1px solid #dce5ed; }
        .home-section h3 { color: #142d4e; margin: 0 0 12px; font-size: 19px; }
        .home-section p { color: #52677d; margin: 8px 0; line-height: 1.6; }
        .home-section strong { color: #142d4e; }
        .home-note { background: #edf5f8; padding: 18px; border-left: 4px solid #0d9ba8; margin-top: 25px; border-radius: 5px; }
        .home-note h3 { color: #142d4e; margin: 0 0 8px; }
        .home-note p { color: #52677d; margin: 0; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="home-title">Sistem de gestiune a salariilor</h2>

    <p class="home-desc">
        Aplicația SalaryManager permite administrarea datelor angajaților,
        calculul automat al salariilor și generarea documentelor salariale.
    </p>

    <div class="home-section">
        <h3>1. Administrarea angajaților</h3>
        <p><strong>Actualizare date:</strong> Căutarea și modificarea informațiilor angajaților.</p>
        <p><strong>Adăugare angajați:</strong> Înregistrarea angajaților noi în baza de date.</p>
        <p><strong>Ștergere angajați:</strong> Eliminarea unui angajat după confirmare.</p>
    </div>

    <div class="home-section">
        <h3>2. Calculul salariilor</h3>
        <p>
            Aplicația calculează automat salariul brut, contribuțiile CAS și CASS,
            impozitul pe venit și suma netă virată pe card.
        </p>
        <p>Rezultatele pot fi consultate în secțiunea <strong>Calcul salarii</strong>.</p>
    </div>

    <div class="home-section">
        <h3>3. Rapoarte și tipărire</h3>
        <p><strong>Stat de plată:</strong> Generarea raportului salarial în format A3.</p>
        <p><strong>Fluturași:</strong> Generarea și tipărirea fluturașilor de salariu.</p>
    </div>

    <div class="home-note">
        <h3>Modificarea procentelor salariale</h3>
        <p>
            Procentele CAS, CASS și impozit pot fi actualizate din secțiunea
            „Modificare Procente”, accesul fiind protejat prin parolă.
        </p>
    </div>

</asp:Content>
