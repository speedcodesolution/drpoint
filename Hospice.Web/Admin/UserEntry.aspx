<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="UserEntry.aspx.cs" Inherits="Hospice.Web.Admin.UserEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">User</li>
			<li class="breadcrumb-item active">Add User Details</li>
		</ol>
	</div>
	<!-- Page header end -->


	<!-- Content wrapper start -->
	<div class="content-wrapper">

		<!-- Row start -->
		<div class="row gutters">
			<div class="col-xl-8 col-lg-8 col-md-12 col-sm-12">
				<div class="card">
					<div class="card-header">
						<div class="card-title">Enter User Details</div>
					</div>
					<div class="card-body">
						<div class="row gutters">
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="txtFirstName">First Name</label>
									<asp:TextBox runat="server" CssClass="form-control" ID="txtFirstName" placeholder="Srinu" ClientIDMode="Static"></asp:TextBox>
								</div>
							</div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="txtLastName">Last Name</label>
									<asp:TextBox runat="server" CssClass="form-control" ID="txtLastName" placeholder="Srinu" ClientIDMode="Static"></asp:TextBox>
								</div>
							</div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="ddlUserType">UserType</label>
									<asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                          <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                                          <asp:ListItem Text="Doctor" Value="1" ></asp:ListItem>
                                          <asp:ListItem Text="Staff" Value="2"></asp:ListItem>
                                          <asp:ListItem Text="Patient" Value="3"></asp:ListItem>
                                      </asp:DropDownList>
								</div>
							</div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="ddlUserTypeId">User Type Id</label>
									<asp:DropDownList ID="ddlUserTypeId" runat="server" CssClass="form-control" ClientIDMode="Static">
                                      </asp:DropDownList>
								</div>
							</div>
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="txtEmail">Email</label>
									<asp:TextBox runat="server"  TextMode="Email" CssClass="form-control" ID="txtEmail" placeholder="doctor@bm.com" ClientIDMode="Static"></asp:TextBox>
								</div>
							</div>
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="txtContact">Contact No</label>
									<asp:TextBox runat="server"  CssClass="form-control" ID="txtContact" placeholder="Contact No" ClientIDMode="Static"></asp:TextBox>
								</div>
							</div>
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="txtAddress">Full Address</label>
									<asp:TextBox TextMode="MultiLine" runat="server" CssClass="form-control" ID="txtAddress" rows="5" placeholder="Current Address" ClientIDMode="Static"></asp:TextBox>
								</div>
							</div>
                            <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="ddlStatus">City</label>
									<asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control" ClientIDMode="Static">
                                      </asp:DropDownList>
								</div>
                                
								    <div class="form-group">
									    <label for="ddlStatus">Status</label>
									    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                              <asp:ListItem Text="Select Status" Value="-1"></asp:ListItem>
                                              <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                              <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
                                          </asp:DropDownList>
								    </div>
							    
							</div>
                            
							
							
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 col-lg-4 col-md-12 col-sm-12" >
				<div class="card">
					<div class="card-header">
						<div class="card-title">Create Account</div>
					</div>
					<div class="card-body">
						<div class="row gutters">
							<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
								<div class="form-group">
									<label for="userName">User Name</label>
									<asp:TextBox runat="server" CssClass="form-control" ID="txtloginName" placeholder="User Name" ClientIDMode="Static"></asp:TextBox>
								</div>
							</div>
							<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
								<div class="form-group">
									<label for="txtPassword">Password</label>
									<asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtPassword" placeholder="Password"></asp:TextBox>
								</div>
							</div>
							<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
								<div class="form-group">
									<label for="txtrePassword">Re-enter Password</label>
									<asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtrePassword" placeholder="New Password"></asp:TextBox>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
			    <div class="text-center card card-footer">
				    <%--<button class="btn btn-primary">Save</button>--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                                <a href="UserListing" class="btn btn-secondary">Cancel</a>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"/>   
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"/>
                        </Triggers>
                    </asp:UpdatePanel>
			    </div>
		    </div>
		</div>
		<!-- Row end -->

	</div>
	<!-- Content wrapper end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script>

        $('#txtEmail').keyup(function (e) {
            if ($(this).val() != '') {
                $('#txtloginName').val($(this).val())
                $('#txtPassword').val($(this).val())
                $('#txtrePassword').val($(this).val())
            }
        });
    </script>
</asp:Content>
