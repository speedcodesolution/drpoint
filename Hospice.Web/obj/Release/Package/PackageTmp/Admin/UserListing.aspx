<%@ Page Title="UserListing" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="UserListing.aspx.cs" Inherits="Hospice.Web.Admin.UserListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- *************
			************ Vendor Css Files *************
		************ -->
    <!-- Data Tables -->
    <link rel="stylesheet" href="../Assests/vendor/datatables/dataTables.bs4.css" />
    <link rel="stylesheet" href="../Assests/vendor/datatables/dataTables.bs4-custom.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Page header start -->.
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Setting</li>
            <li class="breadcrumb-item">User</li>
            <li class="breadcrumb-item active">User List</li>
        </ol>
    </div>
    <!-- Page header end -->
    <div class="content-wrapper">
    <asp:UpdatePanel ID="upUserListing" runat="server">
        <ContentTemplate>
            <!-- Main content -->
            <section class="content">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-12 text-right">
                            <a id="btnAddNew" runat="server" class="btn btn-success"><i class="fa fa-plus"></i> Add New</a>
                         </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                              
                                <!-- /.card-header -->
                                <div class="card-body">
                                        <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row" style="padding-left: 8px;">
                                                Show
                                            <div style="padding-left: 3px; padding-right: 3px">
                                                <asp:DropDownList CssClass="custom-select custom-select-sm form-control form-control-sm" ID="ddlPaging" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged"
                                                    runat="server" AutoPostBack="true">
                                                    <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                    <asp:ListItem Text="500" Value="500"></asp:ListItem>
                                                    <asp:ListItem Text="ALL" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                                entries
                                            </div>
                                        </div>
                                        <div class="col-sm-12 col-md-6">
                                            <div id="divgvfilter" class="text-right">
                                                <label>
                                                    Search:
                                            <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" CssClass="form-control form-control-sm" /><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="S" Style="display: none" />
                                                </label>
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <asp:GridView ID="gvUserListing" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover" AllowPaging="true" OnPageIndexChanging="gvUserListing_PageIndexChanging"  AllowSorting="true" HeaderStyle-HorizontalAlign="Center" OnRowCommand="gvUserListing_RowCommand" ClientIDMode="Static"> 
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />  
                                         <PagerStyle CssClass="nohover" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="btn-group btn-group-sm">
                                                    <a href="UserEntry.aspx?_usrid=<%#Eval("UsrId") %>" class="btn btn-info"><i class="icon-edit1"></i></a>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("UsrId")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="icon-cancel"></i></asp:LinkButton>
                                                        </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("UsrFirstName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("DOB") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("UsrEmail") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="ContactNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("UsrContactNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="LoginName">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("UsrLoginName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToInt32(Eval("UsrStatus"))==1?"Active":"InActive" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                     <div id="divrecordindisplay" style="z-index: 999; float: left; padding-top: 14px;">
                                        <asp:Label ID="lblRecordsInDisplay" runat="server" Text="Showing 1 to 10 of 10 entries [Page 1 of 1]"></asp:Label>
                                    </div>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.container-fluid -->
            </section>
            <!-- /.content -->
        </ContentTemplate>
    </asp:UpdatePanel>
     <script>
        function pageinfo() {
            $('[id*=gvLabListing] tr.nohover').children('td').append($('#divrecordindisplay'));
        }
    </script>
        </div>
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
            $('#gvUserListing').DataTable({
                //'iDisplayLength': 3,
            });
        });
    </script>

     <!-- page script -->
    <script>
        function initjsfun() {
            //$("[id*=txtSearch]").on("keyup", function () {              
            $("[id*=Button1]")[0].click();
            //});
        }
    </script>
</asp:Content>
