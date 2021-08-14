<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PaymentModeEntry.aspx.cs" Inherits="Hospice.Web.Admin.PaymentModeEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">Payment Mode</li>
			<li class="breadcrumb-item active">Add Payment Mode Details</li>
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
                  <lable>PaymentMode Code</lable>
                  <asp:TextBox id="txtPaymentModeCode"  runat="server" CssClass="form-control" placeholder="Enter PaymentMode Code"  MaxLength="50"></asp:TextBox>
                </div>
              
              </div>
              <div class="col-md-6">
              
                <div class="form-group">
                  <lable>Name</lable><span class="star-help">*</span>
                  <asp:TextBox id="txtName"  runat="server" CssClass="form-control" placeholder="Enter PaymentMode Name" MaxLength="50"></asp:TextBox>
                </div>
                <!-- /.form-group -->
              </div>

                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<lable for="inputSpeciality">Status</lable>
									<asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                          <asp:ListItem Text="Select Status" Value="-1"></asp:ListItem>
                                          <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                          <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
                                      </asp:DropDownList>
								</div>
							</div>
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<lable for="biO">Remarks</lable>
                                    <asp:TextBox id="txtPaymentModeDesc"  runat="server" CssClass="form-control" placeholder="Enter description"  TextMode="SingleLine" Rows="3" MaxLength="400"></asp:TextBox>
								</div>
							</div>  
              <!-- /.col -->
               <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
					<div class="text-right">
                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                        <ContentTemplate>
                                <a href="PaymentModeListing" class="btn btn-info">Cancel</a>
                                    <asp:Button ID="btnbSavepaymM" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnbSavepaymM_Click"/>   
                                   
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnbSavepaymM" EventName="Click"/>
                        </Triggers>
                    </asp:UpdatePanel>
                    
                </div>
            </div>
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
            $("#<%=txtPaymentModeCode.ClientID%>").val('') ;
           
        }
    </script>
</asp:Content>
