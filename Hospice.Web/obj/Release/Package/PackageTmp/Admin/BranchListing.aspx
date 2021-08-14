<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BranchListing.aspx.cs" Inherits="Hospice.Web.Admin.BranchListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

      <!-- Page header start -->.
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Setting</li>
            <li class="breadcrumb-item">Branch</li>
            <li class="breadcrumb-item active">Branch List</li>
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
                                    <asp:GridView ID="gvBranchListing" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover" AllowPaging="true" OnPageIndexChanging="gvBranchListing_PageIndexChanging"  AllowSorting="true" HeaderStyle-HorizontalAlign="Center" OnRowCommand="gvBranchListing_RowCommand"> 
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />  
                                         <PagerStyle CssClass="nohover" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="BranchEntry.aspx?_Branchid=<%#Eval("Branchid") %>" class="btn btn-info btn-sm"><i class="fas fa-pencil-alt"></i>
                                                        Edit</a>

                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("Branchid")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="fas fa-trash"> </i> 
                                                            Delete

                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("BranchLocation")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("BranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Address1">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Address1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Address2">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Address2") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="EmailID">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("EMailID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToInt32(Eval("Status"))==1?"Active":"InActive" %>'></asp:Label>
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
     <!-- page script -->
    <script>
        function initjsfun() {
            //$("[id*=txtSearch]").on("keyup", function () {              
            $("[id*=Button1]")[0].click();
            //});
        }
    </script>
</asp:Content>
