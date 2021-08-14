<%@ Page Title="DoctorListing" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="DoctorListing.aspx.cs" Inherits="Hospice.Web.Admin.DoctorListing" %>
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
            <li class="breadcrumb-item">Home</li>
            <li class="breadcrumb-item">Doctor</li>
            <li class="breadcrumb-item active">Doctor List</li>
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
                    <a href="DoctorEntry" class="btn btn-success"><span class="icon-plus"></span>Add New</a>
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
                        <asp:Repeater ID="rptDoctorListing" runat="server">
                            <HeaderTemplate>
                                <table class="table" id="tblDoctorListing">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Name</th>
                                            <th>Mobile </th>
                                            <th>Designation </th>
                                            <th>Department </th>
                                            <th>Status </th>
                                            <th>Action </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.ItemIndex+1 %></td>
                                    <td><%#Eval("EmpName") %>  </td>
                                    <td><%#Eval("MobileNo") %>  </td>
                                    <td><%#Eval("DesignationId") %>  </td>
                                    <td><%#Eval("DepartmentId") %>  </td>
                                    <td>
                                        <a href="#" id="lnkStatus" title='<%# Eval("EmpID") %>' onclick="changestatus(this,'subject');"><%# Convert.ToInt32(Eval("StatusEmp"))==1?"Active":"InActive" %></a>
                                    </td>
                                    <td>
                                        <div class="btn-group btn-group-sm">
                                            <asp:LinkButton ID="btnEdit" runat="server" PostBackUrl='<%#"~/Admin/DoctorEntry?_employeid="+Eval("EmpID") %>' CssClass="btn btn-info" CommandName="btnEdit">
                                                <i class="icon-edit1"></i></asp:LinkButton>

                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("EmpID")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="icon-cancel"></i></asp:LinkButton>
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
            $('#tblDoctorListing').DataTable();
        });
    </script>
</asp:Content>
