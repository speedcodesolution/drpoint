<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RoleListing.aspx.cs" Inherits="Hospice.Web.Admin.RoleListing" %>

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
            <li class="breadcrumb-item">Role</li>
            <li class="breadcrumb-item active">Role List</li>
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
                    <a href="RoleEntry" class="btn btn-success"><span class="icon-plus"></span>Add New</a>
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
                        <asp:Repeater ID="rptRoleListing" runat="server">
                            <HeaderTemplate>
                                <table class="table" id="tblRoleListing">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Role Name</th>
                                            <th>Role Description </th>
                                            <th>Status </th>
                                            <th>Action </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.ItemIndex+1 %></td>
                                    <td><%#Eval("RlName") %>  </td>
                                    <td><%#Eval("RlDescription") %>  </td>
                                    <td>
                                        <a href="#" id="lnkStatus" title='<%# Eval("RlId") %>' onclick="changestatus(this,'subject');"><%# Convert.ToInt32(Eval("RlIsActive"))==1?"Active":"InActive" %></a>
                                    </td>
                                    <td>
                                        <div class="btn-group btn-group-sm">
                                            <asp:LinkButton ID="btnEdit" runat="server" PostBackUrl='<%#"~/Admin/RoleEntry.aspx?_rlid="+Eval("RlId") %>' CssClass="btn btn-info" CommandName="btnEdit">
                                                <i class="icon-edit1"></i></asp:LinkButton>

                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("RlId")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="icon-cancel"></i></asp:LinkButton>
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
            $('#tblRoleListing').DataTable({
                'iDisplayLength': 3,
            });
        });
    </script>
</asp:Content>
