<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RoleEntry.aspx.cs" Inherits="Hospice.Web.Admin.RoleEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page header start -->
	<div class="page-header">
		<ol class="breadcrumb">
			<li class="breadcrumb-item">Role</li>
			<li class="breadcrumb-item active">Add Role Details</li>
		</ol>
	</div>
	<!-- Page header end -->


	<!-- Content wrapper start -->
	<div class="content-wrapper">

		<!-- Row start -->
		<div class="row gutters">
			<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
				<div class="card">
					<div class="card-header">
						<div class="card-title">Enter Role Details</div>
					</div>
					<div class="card-body">
						<div class="row gutters">
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="inputEmail">Role Name</label>
									<asp:TextBox id="txtRoleName"  runat="server" CssClass="form-control" placeholder="Enter role name" MaxLength="10" required></asp:TextBox>
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
							<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
								<div class="form-group">
									<label for="biO">Remarks</label>
                                    <asp:TextBox id="txtRoleDescription"  runat="server" CssClass="form-control" placeholder="Enter description"  TextMode="MultiLine" Rows="3" MaxLength="400"></asp:TextBox>
								</div>
							</div>
							<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
								<div class="text-right">
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <a href="RoleListing" class="btn btn-info">Cancel</a>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"/>   
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click"/>
                                        </Triggers>
                                    </asp:UpdatePanel>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			
		</div>
		<!-- Row end -->

	</div>
	<!-- Content wrapper end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
