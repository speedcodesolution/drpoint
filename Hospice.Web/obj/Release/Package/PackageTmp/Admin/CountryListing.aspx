<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CountryListing.aspx.cs" Inherits="Hospice.Web.Admin.CountryListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- *************
			************ Vendor Css Files *************
		************ -->
    <!-- Data Tables -->
    <link rel="stylesheet" href="../Assests/vendor/datatables/dataTables.bs4.css" />
    <link rel="stylesheet" href="../Assests/vendor/datatables/dataTables.bs4-custom.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page header start -->
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Setting</li>
            <li class="breadcrumb-item">Country</li>
            <li class="breadcrumb-item active">Country List</li>
        </ol>
    </div>
    <!-- Page header end -->


    <!-- Content wrapper start -->
    <div class="content-wrapper">
        <div class="row mb-1">
            <div class="col-xl-9 col-lg-9 col-md-12 col-sm-12 col-12">
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
                <div class="text-right">
                    <a href="CountryEntry" class="btn btn-success"><span class="icon-plus"></span>Add New</a>
                </div>
            </div>
        </div>
        <!-- Row start -->
        <div class="row gutters">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div class="table-container">

                    <!--*************************
						*************************
						*************************
						Basic table start
					*************************
					*************************
					*************************-->
                    <div class="table-responsive">
                        <asp:Repeater ID="rptCountryListing" runat="server">
                            <HeaderTemplate>
                                <table class="table" id="tblCountryListing">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Country Name</th>
                                            <th>Country Code </th>
                                            <th>Status </th>
                                            <th>Action </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.ItemIndex+1 %></td>
                                    <td><%#Eval("CountryName") %>  </td>
                                    <td><%#Eval("CountryCode") %>  </td>
                                    <td>
                                        <a href="#" id="lnkStatus" title='<%# Eval("CountryID") %>' onclick="changestatus(this,'subject');"><%# Convert.ToInt32(Eval("Status"))==1?"Active":"InActive" %></a>
                                    </td>
                                    <td>
                                        <div class="btn-group btn-group-sm">
                                            <asp:LinkButton ID="btnEdit" runat="server" PostBackUrl='<%#"~/Admin/CountryEntry.aspx?_Countryid="+Eval("CountryID") %>' CssClass="btn btn-info" CommandName="btnEdit">
                                                <i class="icon-edit1"></i></asp:LinkButton>

                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("CountryID")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="icon-cancel"></i></asp:LinkButton>
                                        </div>
                                    </td>

                                </tr>

                            </ItemTemplate>

                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <!--*************************
					*************************
					*************************
					Basic table end
				*************************
				*************************
				*************************-->

                </div>
            </div>
        </div>
        <!-- Row end -->

    </div>
    <!-- Content wrapper end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <!-- *************
			************ Vendor Js Files *************
		************* -->

    <!-- Data Tables -->
    <script src="../Assests/vendor/datatables/dataTables.min.js"></script>
    <script src="../Assests/vendor/datatables/dataTables.bootstrap.min.js"></script>

    <!-- Custom Data tables -->
    <script src="../Assests/vendor/datatables/custom/custom-datatables.js"></script>
    <script>
        // Basic DataTable
        $(function () {
            $('#tblCountryListing').DataTable({
                'iDisplayLength': 3,
            });
        });
    </script>
</asp:Content>
