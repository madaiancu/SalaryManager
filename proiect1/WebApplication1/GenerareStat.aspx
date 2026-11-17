<%@ Page Title="Stat de Plată" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GenerareStat.aspx.cs" Inherits="WebApplication1.GenerareStat" %>

<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Stat de Plată Salarii</h2>
    
    <%-- Controlul pentru mesaje de eroare --%>
    <asp:Label ID="lblMesaj" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
    
    <div style="width: 100%; overflow-x: auto; margin-top: 15px;">
        <%-- Viewer-ul Crystal Reports --%>
        <CR:CrystalReportViewer 
            ID="crvStatDePlata" 
            runat="server" 
            AutoDataBind="true" 
            ToolPanelView="None" 
            HasToggleGroupTreeButton="false"
            HasPageNavigationButtons="true"
            HasPrintButton="true"
            HasExportButton="true" 
            Width="100%" 
            Height="800px" />
    </div>
</asp:Content>