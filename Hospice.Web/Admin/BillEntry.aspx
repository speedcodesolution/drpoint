<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="Hospice.Web.Admin.BillEntry" %>

<%@ Register Src="~/CustomControl/AddBill.ascx" TagPrefix="uc1" TagName="AddBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" href="../Assests/vendor/datepicker/css/classic.css" />
		<link rel="stylesheet" href="../Assests/vendor/datepicker/css/classic.date.css" />
    <link rel="stylesheet" href="../Assests/vendor/select2/css/select2.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

    <uc1:AddBill runat="server" ID="AddBill" />

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script src="../Assests/vendor/datepicker/js/picker.js"></script>
		<script src="../Assests/vendor/datepicker/js/picker.date.js"></script>
		<script src="../Assests/vendor/datepicker/js/custom-picker.js"></script>

    <script src="../Assests/vendor//select2/js/select2.full.min.js"></script>
</asp:Content>
