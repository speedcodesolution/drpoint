<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="StaffEntry.aspx.cs" Inherits="Hospice.Web.Admin.StaffEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtkt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">Staff</li>
			<li class="breadcrumb-item active">Add Staff Details</li>
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
                                <label>Employee ID</label><span class="star-help">*</span>
                                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control" placeholder="Enter Employee Id" MaxLength="10" required></asp:TextBox>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label>Name</label><span class="star-help">*</span>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50" required></asp:TextBox>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label>Date Of Birth</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="Enter Date of Birth" MaxLength="10"></asp:TextBox>
                                    <ajaxtkt:CalendarExtender ID="cetxtDOB" runat="server" Format="dd/MM/yyyy" Enabled="True" TargetControlID="txtDOB"></ajaxtkt:CalendarExtender>
                                </div>
                            </div>
                            <!-- /.form-group -->
                            <div class="form-group">
                                <label>Date Of Joining</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtDOJ" runat="server" CssClass="form-control" placeholder="Enter Date of Joining" MaxLength="10"></asp:TextBox>
                                    <ajaxtkt:CalendarExtender ID="cetxtDOJ" runat="server" Format="dd/MM/yyyy" Enabled="True" TargetControlID="txtDOJ"></ajaxtkt:CalendarExtender>
                                </div>
                            </div>
                            <!-- /.form-group -->
                            
                            <div class="form-group">
                                <label>Mobie No.</label><span class="star-help">*</span>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-phone-alt"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile No." MaxLength="10" onkeypress="return isNumberKey(event)" required></asp:TextBox>
                                </div>
                           </div>
                            <!-- /.input group -->
                            <div class="form-group">
                                <label>Email</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><strong>@</strong></span>
                                    </div>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" MaxLength="50"  ></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.form-group -->
                            
                        </div>
                        <!-- /.col -->
                        <div class="col-md-6">
                            <div class="row">
                                <div class="col-md-6">
                                    <!-- /.form-group -->

                                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="ddlDesignation">Designation</label>
								<asp:DropDownList runat="server" CssClass="form-control" ID="ddlDesignation" placeholder="Designation">
                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Sr. Doctor" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Jr. Doctor" Value="2"></asp:ListItem>
								</asp:DropDownList>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="ddlDepartment">Department</label>
								<asp:DropDownList runat="server" CssClass="form-control" ID="ddlDepartment" placeholder="Department">
                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                    <asp:ListItem Text="SkinTransplant" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="HairTransplant" Value="2"></asp:ListItem>
								</asp:DropDownList>
							</div>
						</div>


                                   <%-- <div class="form-group">
                                        <label>Department</label>
                                        <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50"></asp:TextBox>
                                    </div>
                                    <!-- /.form-group -->
                                    <div class="form-group">
                                        <label>Designation</label>
                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50"></asp:TextBox>
                                    </div>--%>
                                    <!-- /.form-group -->
                                    <!-- /.form-group -->
                                    <div class="form-group">
                                        <label>Status</label><span class="star-help">*</span>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="InActive" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <!-- /.form-group -->
                                </div>
                                <div class="col-md-6 text-center">
                                    <div class="form-group">
                                        <asp:Image runat="server" ID="Image1" Height="200px" Width="200px" ImageUrl="SiteImage/no-image.png" CssClass="fileinput-preview thumbnail"/>
                                        <div class="input-group">
                                          <div class="custom-file" style="display: block;padding-top: 5px;">
                                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" onchange="ShowImagePreview(this);" style="width:1%"></asp:FileUpload>
                                            <label class="custom-file-label" for="exampleInputFile" style="position:relative;color: transparent;border: transparent;">Choose file</label>
                                          </div>
                                        </div>
                                    </div>
                                </div>
                                
                            </div>

                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" Rows="4" MaxLength="250" Height="123px"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>City</label><span class="star-help">*</span>
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control select2" required>
                                    <asp:ListItem Text="Select City" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Delhi" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							<div class="text-right">
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <a href="DoctorListing" class="btn btn-info">Cancel</a>
								            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
                                        </ContentTemplate>
                                    <Triggers>
                                        <%--<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"/>--%>
                                        <asp:PostBackTrigger ControlID="btnSave" />  
                                    </Triggers>
                                </asp:UpdatePanel>
							</div>
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
            $("#<%=txtEmpCode.ClientID%>").val('') ;
           
        }
    </script>

     <script type="text/javascript">
        $(document).ready(function () {
            
        });

        //Image Upload Preview  
        function ShowImagePreview(input) {  
            if (input.files && input.files[0]) {  
                var reader = new FileReader();  
                reader.onload = function (e) {  
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result);  
                };  
                reader.readAsDataURL(input.files[0]);  
            }  
        }

        function ClearTextBoxes() {
            $("#<%=txtEmpCode.ClientID%>").val('');
            $("#<%=txtName.ClientID%>").val('');
            $("#<%=txtAddress.ClientID%>").val('');
            $("#<%=txtMobile.ClientID%>").val('');
            $("#<%=txtDOB.ClientID%>").val('');
            $("#<%=txtDOJ.ClientID%>").val('');
            $("#<%=ddlDesignation.ClientID%>").val('');
            $("#<%=ddlDepartment.ClientID%>").val('');
            $("#<%=ddlStatus.ClientID%>").val(1);

        }
    </script>
</asp:Content>
