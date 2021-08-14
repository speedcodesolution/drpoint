<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="StaffListing.aspx.cs" Inherits="Hospice.Web.Admin.StaffListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

      <!-- Page header start -->.
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Setting</li>
            <li class="breadcrumb-item">Staff</li>
            <li class="breadcrumb-item active">Staff Listing</li>
        </ol>
    </div>
    <!-- Page header end -->
    <div class="content-wrapper">
        <asp:UpdateProgress ID="updProgress1" AssociatedUpdatePanelID="upItemListing" runat="server" >
        <ProgressTemplate>
            <div class="row m-0 p-0">
                <div class="col-md-12 m-0 p-0">
                    <div class="modal1"></div>
                    <div class="center1">
                        <img alt="" src="SiteImage/loader.gif" />
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upItemListing" runat="server">
        <ContentTemplate>
            <!-- Main content -->
            <section class="content">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-md-12 text-right">
                            <a id="btnAddNew" runat="server" class="btn btn-success"><i class="fa fa-plus"></i>Add New</a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header bg-gray">
                                    <h3 class="card-title">List</h3>
                                    <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                                        <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.card-header -->
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row" style="padding-left: 8px;">
                                                Show
                                            <div style="padding-left: 3px; padding-right: 3px">
                                                <asp:DropDownList CssClass="custom-select custom-select-sm form-control form-control-sm" ID="ddlPaging" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged">
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
                                    <asp:GridView ID="gvstaffListing" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover dataTable dtr-inline" AllowPaging="true" OnPageIndexChanging="gvstaffListing_PageIndexChanging"  AllowSorting="true"  HeaderStyle-HorizontalAlign="Center" OnRowCommand="gvstaffListing_RowCommand"> 
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />  
                                         <PagerStyle CssClass="nohover" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center"  >
                                                <ItemTemplate>
                                                    <a href="StaffEntry.aspx?_staffid=<%#Eval("EmpID") %>" class="btn btn-info btn-sm"><i class="fas fa-pencil-alt"></i>
                                                        Edit</a>

                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("EmpID")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="fas fa-trash"> </i> 
                                                            Delete

                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EmpCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmpCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("EmpName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("DOB", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("DesignationId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("StatusEmp") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                    
                                      <div class="col-md-6 text-right">
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
            $('[id*=gvstaffListing] tr.nohover').children('td').append($('#divrecordindisplay'));
        }
    </script>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
     <!-- page script -->
    <script>
        function initjsfun() {
            //$("[id*=txtSearch]").on("keyup", function () {              
            $("[id*=Button1]")[0].click();
            //});
        }
    </script>
</asp:Content>
