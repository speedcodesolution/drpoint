<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="Hospice.Web.Admin.BillEntry" %>

<%@ Register Src="~/CustomControl/AddBill.ascx" TagPrefix="uc1" TagName="AddBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AddBill runat="server" ID="AddBill" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
