<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="StateEntry.aspx.cs" Inherits="Hospice.Web.Admin.StateEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">State</li>
			<li class="breadcrumb-item active">Add State Details</li>
		</ol>
	</div>
	<!-- Page header end -->

    <!-- Main content -->
    <div class="content-wrapper">
    <section class="content">
      <div class="container-fluid">
        
        <div class="card card-default mt-2">
          <div class="card-header bg-gray">
            <h3 class="card-title">Add/Update</h3>

            
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                  <div class="form-group">
                  <label>Country</label><span class="star-help">*</span>
                  <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
              
                
              </div>
                <div class="col-md-6">
                <div class="form-group">
                  <label>State Code</label>
                  <asp:TextBox id="txtstateCode"  runat="server" CssClass="form-control" placeholder="Enter State Code"  MaxLength="50"></asp:TextBox>
                </div>              
              </div>

              <div class="col-md-6">
               
                <div class="form-group">
                  <label>State Name</label><span class="star-help">*</span>
                  <asp:TextBox id="txtName"  runat="server" CssClass="form-control" placeholder="Enter State Name" MaxLength="50"></asp:TextBox>
                </div>                
              </div>

                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="inputSpeciality">Status</label>
									<asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                          <asp:ListItem Text="Select Status" Value="-1"></asp:ListItem>
                                          <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                          <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
                                      </asp:DropDownList>
								</div>
							</div>

               <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
					<div class="text-right">
                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                        <ContentTemplate>
                                <a href="StateListing" class="btn btn-info">Cancel</a>
                                    <asp:Button ID="btnbSaveStateM" runat="server" Text="Save"  CssClass="btn btn-primary" OnClick="btnbSaveStateM_Click"/>  
                                    
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnbSaveStateM" EventName="Click"/>
                        </Triggers>
                    </asp:UpdatePanel>
                    
                </div>
            </div>
							
              <!-- /.col -->
              
              <!-- /.col -->
            </div>
            <!-- /.row -->

          </div>
          <!-- /.card-body -->
        </div>
        <!-- /.card -->
        <!-- /.row -->
         
      </div><!-- /.container-fluid -->
    </section>
        </div>
    <!-- /.content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script type="text/javascript">
        function ClearTextBoxes() {
          
            $("#<%=txtName.ClientID%>").val('') ;
            $("#<%=txtstateCode.ClientID%>").val('') ;
           
        }
    </script>
</asp:Content>
