<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PrintBill.aspx.cs" Inherits="Hospice.Web.Admin.PrintBill" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <!-- Row start -->
        <div class="row gutters">
            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-6">
                <div class="table-container" style="padding-left:25px">

                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800">
    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
        <!-- Row end -->

        
        
        

        
     </div>
   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
