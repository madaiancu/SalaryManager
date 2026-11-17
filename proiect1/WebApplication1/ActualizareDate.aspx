
<%@ Page Title="Actualizare Date Angajați" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizareDate.aspx.cs" Inherits="WebApplication1.ActualizareDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .titlu { color: #142d4e; margin-bottom: 20px; }
        .cautare { background: #edf5f8; padding: 20px; border-radius: 10px; margin-bottom: 20px; }
        .tabel { border-collapse: collapse; font-size: 13px; }
        .tabel th { padding: 12px; background: #142d4e; color: white; }
        .tabel th a { color: white; text-decoration: none; }
        .tabel td { padding: 10px; border-bottom: 1px solid #e5edf3; }
        .tabel tr:hover td { background: #e8f7f8; }
        .tabel td a { color: #087f8a; font-weight: bold; }
        .buton { background: #0d9ba8; color: white; border: none; padding: 10px 15px; border-radius: 6px; cursor: pointer; }
        .buton:hover { background: #087f8a; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="titlu">Gestionare Angajați</h2>

    <div class="cautare">
        <asp:Label ID="lblCautare" runat="server" Text="Căutare după nume: " Font-Bold="true" />
        <asp:TextBox ID="txtCautare" runat="server" Width="250px" />
        <asp:Button ID="btnCauta" runat="server" Text="Caută"
            CssClass="buton" OnClick="btnCauta_Click" />
        <asp:Button ID="btnReset" runat="server" Text="Afișează toți angajații"
            CssClass="buton" OnClick="btnReset_Click" />
    </div>

    <asp:Label ID="lblMesaj" runat="server" ForeColor="Red" EnableViewState="false" />

    <div style="overflow-x:auto;">
        <asp:GridView ID="gvAngajati" runat="server"
            CssClass="tabel"
            AutoGenerateColumns="False"
            DataKeyNames="ID_ANGAJAT"
            AllowSorting="True"
            OnSorting="gvAngajati_Sorting"
            OnRowEditing="gvAngajati_RowEditing"
            OnRowCancelingEdit="gvAngajati_RowCancelingEdit"
            OnRowUpdating="gvAngajati_RowUpdating"
            CellPadding="8" GridLines="None" Width="100%">

            <AlternatingRowStyle BackColor="#F2F7FA" />

            <Columns>
                <asp:BoundField DataField="ID_ANGAJAT" HeaderText="ID" ReadOnly="True"
                    SortExpression="ID_ANGAJAT" ItemStyle-HorizontalAlign="Center" />

                <asp:BoundField DataField="NUME" HeaderText="Nume" SortExpression="NUME" />
                <asp:BoundField DataField="PRENUME" HeaderText="Prenume" SortExpression="PRENUME" />
                <asp:BoundField DataField="FUNCTIE" HeaderText="Funcție" SortExpression="FUNCTIE" />

                <asp:BoundField DataField="SALAR_BAZA" HeaderText="Salariu bază"
                    DataFormatString="{0:N0}" SortExpression="SALAR_BAZA" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="SPOR" HeaderText="Spor (%)"
                    DataFormatString="{0:N0}" SortExpression="SPOR" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="PREMII_BRUTE" HeaderText="Premii"
                    DataFormatString="{0:N0}" SortExpression="PREMII_BRUTE" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="RETINERI" HeaderText="Rețineri"
                    DataFormatString="{0:N0}" SortExpression="RETINERI" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="TOTAL_BRUT" HeaderText="Total brut"
                    ReadOnly="True" DataFormatString="{0:N0}" SortExpression="TOTAL_BRUT" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="BRUT_IMPOZABIL" HeaderText="Brut impozabil"
                    ReadOnly="True" DataFormatString="{0:N0}" SortExpression="BRUT_IMPOZABIL" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="CAS" HeaderText="CAS"
                    ReadOnly="True" DataFormatString="{0:N0}" SortExpression="CAS" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="CASS" HeaderText="CASS"
                    ReadOnly="True" DataFormatString="{0:N0}" SortExpression="CASS" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="IMPOZIT" HeaderText="Impozit"
                    ReadOnly="True" DataFormatString="{0:N0}" SortExpression="IMPOZIT" ItemStyle-HorizontalAlign="Right" />

                <asp:BoundField DataField="VIRAT_CARD" HeaderText="Salariu net"
                    ReadOnly="True" DataFormatString="{0:N0}" SortExpression="VIRAT_CARD"
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Bold="true" />

                <asp:CommandField ShowEditButton="True"
                    EditText="Editează" UpdateText="Salvează" CancelText="Renunță"
                    ItemStyle-HorizontalAlign="Center" />
            </Columns>

            <HeaderStyle BackColor="#142D4E" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFFFF" ForeColor="#333333" />

        </asp:GridView>
    </div>

</asp:Content>

