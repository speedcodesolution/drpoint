<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="paymentlist.aspx.cs" Inherits="Hospice.Web.Admin.paymentlist" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/CustomControl/payment.ascx" TagPrefix="uc1" tagname="payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <link href="../CustomCss/customtab.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Paid</li>
            <li class="breadcrumb-item active">Patient Paid Details</li>
        </ol>
    </div>

     <div class="content-wrapper">
         <div class="row gutters">
             <uc1:payment runat="server" ID="payment" />
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
