<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind=ServiceEntry Inherits="Hospice.Web.Admin.ServiceEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">Service</li>
			<li class="breadcrumb-item active">Add Service Details</li>
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

            <div class="card-tools">
              <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
              <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-times"></i></button>
            </div>
          </div>
          <!-- /.card-header -->
          <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                <div class="form-group">
                  <label>Service Code</label>
                  <asp:TextBox id="txtservCode"  runat="server" CssClass="form-control" placeholder="Enter Exerise Code"  MaxLength="50"></asp:TextBox>
                </div>
              
              </div>
              <div class="col-md-6">
               
                <!-- /.form-group -->
                <div class="form-group">
                  <label>Service Name</label><span class="star-help">*</span>
                  <asp:TextBox id="txtName"  runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50"></asp:TextBox>
                </div>
                <!-- /.form-group -->

              </div>

              <div class="col-md-6">
               
                <!-- /.form-group -->
                <div class="form-group">
                  <label>Service Tax</label><span class="star-help">*</span>
                  <asp:TextBox id="txtservicetax"  runat="server" CssClass="form-control" placeholder="Enter Tax" MaxLength="50"></asp:TextBox>
                </div>
                <!-- /.form-group -->
              </div>

                 <div class="col-md-6">
               
                <!-- /.form-group -->
                <div class="form-group">
                  <label>Service Amount</label><span class="star-help">*</span>
                  <asp:TextBox id="txtamt" type="number"  runat="server" CssClass="form-control" placeholder="Enter Amount"  MaxLength="10"></asp:TextBox>
                </div>
                <!-- /.form-group -->

              </div>

                <asp:Panel ID="othertype" runat="server" Visible="false" class="col-md-12" style="left: -14px;">
                    <div class="col-md-6">                
                      <label>Service Color</label><span class="star-help">*</span>
                      <asp:TextBox id="txtcervicecolor"  runat="server" CssClass="form-control" placeholder="Enter service color" MaxLength="50"></asp:TextBox>
                
                   </div>

                     <div class="col-md-6">                    
                      <label>Service Owner Name</label><span class="star-help">*</span>
                      <asp:DropDownList ID="ddldocor" runat="server" CssClass="form-control"></asp:DropDownList>                  
                  </div>
                </asp:Panel>
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
				<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
					<div class="form-group">
						<label for="biO">Remarks</label>
                        <asp:TextBox id="txtserviceDescription"  runat="server" CssClass="form-control" placeholder="Enter description"  TextMode="SingleLine" Rows="3" MaxLength="400"></asp:TextBox>
					</div>
				</div>  

                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
					<div class="text-right">
                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                        <ContentTemplate>
                                <a href="ServiceListing" class="btn btn-info">Cancel</a>
                                    <asp:Button ID="btnbSaveservM" runat="server" Text="Save"  CssClass="btn btn-primary" OnClick="btnbSaveservM_Click"/>   
                                   
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnbSaveservM" EventName="Click"/>
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
            $("#<%=txtservCode.ClientID%>").val('') ;
           
        }
    </script>
</asp:Content>
