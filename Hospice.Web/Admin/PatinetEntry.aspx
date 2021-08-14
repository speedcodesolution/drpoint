<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PatinetEntry.aspx.cs" Inherits="Hospice.Web.Admin.PatinetEntry" %>

<%@ Register Src="~/CustomControl/AddPatient.ascx" TagPrefix="uc1" TagName="AddPatient" %>
<%@ Register Src="~/CustomControl/EditPatient.ascx" TagPrefix="uc1" TagName="EditPatient" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CustomCss/customtab.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page header start -->
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Doctors</li>
            <li class="breadcrumb-item active">Add Doctor Details</li>
        </ol>
    </div>
    <!-- Page header end -->
    <!-- Content wrapper start -->
    <div class="content-wrapper">
        <!-- Row start -->
        <div class="row gutters" >
            <uc1:EditPatient runat="server" ID="EditPatient" />
        </div>
        <!-- Row end -->
    </div>
    <!-- Content wrapper end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
