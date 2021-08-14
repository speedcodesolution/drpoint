<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ServiceListing.aspx.cs" Inherits="Hospice.Web.Admin.ServiceListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <!-- Page header start -->.
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Setting</li>
            <li class="breadcrumb-item">Service</li>
            <li class="breadcrumb-item active">Service List</li>
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

                            <!-- Row start -->
					            <div class="row gutters">
						            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							
							            <div class="custom-tabs-container">
								            <ul class="nav nav-tabs" id="myTab3" role="tablist">
									            <li class="nav-item">
										            <a class="nav-link active" id="home-tab3" data-toggle="tab" href="#home3" role="tab" aria-controls="home3" aria-selected="true"><i class="icon-home2"></i>Appoinment Service</a>
									            </li>
									            <li class="nav-item">
										            <a class="nav-link" id="profile-tab3" data-toggle="tab" href="#profile3" role="tab" aria-controls="profile3" aria-selected="false"><i class="icon-feather"></i>Other Service</a>
									            </li>
									
								            </ul>
								            <div class="tab-content" id="myTabContent3">
									            <div class="tab-pane fade show active" id="home3" role="tabpanel" aria-labelledby="home-tab3">
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
                                                   <%-- <div class="row">
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
                                        
                                                </div>--%>
                                                <asp:GridView ID="gvServiceListing" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover" AllowPaging="true" OnPageIndexChanging="gvServiceListing_PageIndexChanging"  AllowSorting="true" HeaderStyle-HorizontalAlign="Center" OnRowCommand="gvServiceListing_RowCommand"> 
                                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />  
                                                     <PagerStyle CssClass="nohover" HorizontalAlign="Right" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a href="ServiceEntry.aspx?_Serviceid=<%#Eval("Serviceid") %>" class="btn btn-info btn-sm"><i class="fas fa-pencil-alt"></i>
                                                                    Edit</a>

                                                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("Serviceid")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="fas fa-trash"> </i> 
                                                                        Delete

                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Service Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("SericeCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Service Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Service Tax">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("servicetax") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Service Color">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("servicecolor") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Service Owner Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("serviceowner") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                          <asp:TemplateField HeaderText="Service Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("ServiceDescription") %>'></asp:Label>
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
									</div>
									<div class="tab-pane fade" id="profile3" role="tabpanel" aria-labelledby="profile-tab3">
										 <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-12 text-right">
                            <a id="btnAddother" runat="server" class="btn btn-success"><i class="fa fa-plus"></i> Add New</a>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card">
                               
                                <!-- /.card-header -->
                                <div class="card-body">
                                    
                                      <%--  <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group row" style="padding-left: 8px;">
                                                Show
                                            <div style="padding-left: 3px; padding-right: 3px">
                                                <asp:DropDownList CssClass="custom-select custom-select-sm form-control form-control-sm" ID="DropDownList1" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged"
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
                                            <div id="divgvfilterother" class="text-right">
                                                <label>
                                                    Search:
                                                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" CssClass="form-control form-control-sm" /><asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="S" Style="display: none" />
                                                </label>
                                            </div>
                                        </div>
                                        
                                    </div>--%>
                                    <asp:GridView ID="gvServiceListingother" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover" AllowPaging="true" OnPageIndexChanging="gvServiceListingother_PageIndexChanging"  AllowSorting="true" HeaderStyle-HorizontalAlign="Center" OnRowCommand="gvServiceListingother_RowCommand"> 
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />  
                                         <PagerStyle CssClass="nohover" HorizontalAlign="Right" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="ServiceEntry.aspx?_Serviceid=<%#Eval("Serviceid") %>" class="btn btn-info btn-sm"><i class="fas fa-pencil-alt"></i>
                                                        Edit</a>

                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("Serviceid")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="fas fa-trash"> </i> 
                                                            Delete

                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SericeCode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("ServiceName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Service Tax">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("servicetax") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        

                                                       

                                              <asp:TemplateField HeaderText="Service Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("ServiceDescription") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Convert.ToInt32(Eval("Status"))==1?"Active":"InActive" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView>
                                     <div id="divrecordindisplayother" style="z-index: 999; float: left; padding-top: 14px;">
                                        <asp:Label ID="Label3" runat="server" Text="Showing 1 to 10 of 10 entries [Page 1 of 1]"></asp:Label>
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
									</div>
									
								</div>
							</div>

						</div>
					</div>
					<!-- Row end -->






               
                <!-- /.container-fluid -->
            </section>
            <!-- /.content -->
        </ContentTemplate>
    </asp:UpdatePanel>
     <script>
        function pageinfo() {
            $('[id*=gvServiceListing] tr.nohover').children('td').append($('#divrecordindisplay'));
             $('[id*=gvServiceListingother] tr.nohover').children('td').append($('#divrecordindisplayother'));
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
