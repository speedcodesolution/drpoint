<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="DoctorEntry.aspx.cs" Inherits="Hospice.Web.Admin.DoctorEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Datepicker css -->
		<link rel="stylesheet" href="../Assests/vendor/datepicker/css/classic.css" />
		<link rel="stylesheet" href="../Assests/vendor/datepicker/css/classic.date.css" />
     <link rel="stylesheet" href="../Assests/vendor/select2/css/select2.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!-- Page header start -->
<div class="page-header">
	<ol class="breadcrumb">
		<li class="breadcrumb-item">Doctors</li>
		<li class="breadcrumb-item active">Add Doctor Details</li>
	</ol>
</div>
<!-- Page header end -->


<!-- Content wrapper start -->
<div class="content-wrapper">

	<!-- Row start -->
	<div class="row gutters">
		<div class="col-xl-2 col-lg-2 col-md-12 col-sm-12">
			<div class="card">
				<div class="card-body">
					<div class="doctor-profile">
						<div class="doctor-thumb">
							<img src="/Assests/img/noimage.png" alt="Doctor" runat="server" id="imgEmp" style="max-width:324px">
						</div>
						<div class="input-group mb-3">
                            <asp:FileUpload runat="server"  ID="fupProfile" onchange="previewFile(this);" ClientIDMode="Static"/>
							<div class="custom-file">
                                
								<%--<input runat="server" type="file" class="custom-file-input" id="fpProfile" aria-describedby="fpProfile">--%>
								<%--<label class="custom-file-label" for="fupProfile">Update Image</label>--%>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12">
			<div class="card">
				<div class="card-header">
					<div class="card-title">Enter Doctor Details</div>
				</div>
				<div class="card-body">
					<div class="row gutters">
                        <asp:PlaceHolder ID="phBranch" runat="server">
                            <div class="col-xl-12 col-lg-12 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="ddlBranch">Branch</label>
								<asp:DropDownList runat="server" CssClass="form-control" ID="ddlBranch" >

								</asp:DropDownList>
							</div>
						</div>
                        </asp:PlaceHolder>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtFullName">Full Name</label>
								<asp:TextBox runat="server" CssClass="form-control" ID="txtFullName" placeholder="e.g:Hirdayesh Singh" MaxLength="250"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtEmail">Email</label>
								<asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="doctor@bm.com" TextMode="Email" MaxLength="100"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtMobileno">Mobile No.</label>
								<asp:TextBox runat="server" CssClass="form-control" ID="txtMobileno" placeholder="Mobile No." TextMode="Number" MaxLength="10"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="ddlStatus">Status</label>
								<asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Select Status" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="InActive" Value="2"></asp:ListItem>
								</asp:DropDownList>
							</div>
						</div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtDOB">Date of Birth</label>
								<asp:TextBox runat="server" CssClass="form-control datepicker-dropdowns" ID="txtDOB" placeholder="Date of Birth"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtDOJ">Date of Joining</label>
								<asp:TextBox runat="server" CssClass="form-control datepicker-dropdowns" ID="txtDOJ" placeholder="Date of Joining"></asp:TextBox>
							</div>
						</div>
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
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtQualification">Qualification</label>
								<asp:TextBox runat="server" CssClass="form-control" ID="txtQualification" placeholder="Qualification"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtSpeciality">Speciality</label>
								<asp:TextBox runat="server" CssClass="form-control" ID="txtSpeciality" placeholder="Speciality"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="txtAddress">Full Address</label>
								<asp:TextBox runat="server" CssClass="form-control" ID="txtAddress" rows="3" placeholder="Current Address" TextMode="MultiLine"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
							<div class="form-group">
								<label for="ddlCity">City</label>
								<asp:DropDownList runat="server" CssClass="form-control" ID="ddlCity" placeholder="City">
                                    <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Delhi" Value="1"></asp:ListItem>
								</asp:DropDownList>
							</div>
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
				</div>
			</div>
		</div>
		<div class="col-xl-4 col-lg-4 col-md-12 col-sm-12" >
			<div class="card">
				<div class="card-header">
					<div class="card-title">Avability</div>
				</div>
				<div class="card-body">
					<div class="row gutters">
						<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							<div class="form-group">
								<label for="ddlWorkingDay1">Days</label>
                                <div class="select2-purple">
                                    <select id="ddlWorkingDay1" class="select2" runat="server" data-placeholder="Select Working Day" data-dropdown-css-class="select2-purple" style="width: 100%;" ></select>
                                    <asp:HiddenField ID="hfSelectedWorkingDay" runat="server" />
                              </div>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
							<div class="form-group">
								<label for="txtFromtime">From Time</label>
								<asp:TextBox CssClass="form-control" ID="txtFromtime" runat="server" TextMode="Time"></asp:TextBox>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
							<div class="form-group">
								<label for="password">To Time</label>
								<asp:TextBox CssClass="form-control" ID="txtToTime" runat="server" TextMode="Time"></asp:TextBox>
							</div>
						</div>
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <asp:UpdatePanel ID="updatepanel2" runat="server">
                                        <ContentTemplate>
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							<div class="text-right">
                                
                                            <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-info" Text="Cancel" />
								            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="btnAdd_Click" />
                                        
							</div>
						</div>
                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							<div class="text-center">
								<asp:GridView ID="gvAvailabilityList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover" HeaderStyle-HorizontalAlign="Center" DataKeyNames="AvailabilityId" ShowHeaderWhenEmpty="true" EmptyDataText="No Record Found." OnRowCommand="gvAvailabilityList_RowCommand"> 
                                        <Columns>
                                            <%--<asp:TemplateField HeaderText="#" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="WorkingDay" ItemStyle-CssClass="wrapcolumn" ItemStyle-Width="65%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvWorkingDay" runat="server" Text='<%#Eval("WorkingDay") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="FromTime" ItemStyle-HorizontalAlign="Center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvFromTime" runat="server" Text='<%#Eval("WorkingFromTime") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ToTime" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgvToTime" runat="server" Text='<%#Eval("WorkingToTime") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-info btn-sm" CommandName="EditRow" Text="Edit" CommandArgument='<%# Eval("TaskId")%>' ></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("AvailabilityId")%>' CommandName="DeleteRow"><i class="icon-cancel"></i>

                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
							</div>
						</div>
                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"/>
                                    </Triggers>
                                </asp:UpdatePanel></div>
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
    <!-- Datepickers -->
		<script src="../Assests/vendor/datepicker/js/picker.js"></script>
		<script src="../Assests/vendor/datepicker/js/picker.date.js"></script>
		<script src="../Assests/vendor/datepicker/js/custom-picker.js"></script>

    <script src="../Assests/vendor//select2/js/select2.full.min.js"></script>

     <script type="text/javascript">
         $(function () {
             //Initialize Select2 Elements
             $('.select2').select2();

             $('#<%=ddlWorkingDay1.ClientID%>').on('change', function () {
                 $('#<%=hfSelectedWorkingDay.ClientID%>').val($(this).val());
             });
             if ($("#<%=hfSelectedWorkingDay.ClientID%>").val() != "")
                 test1();
         });

        
         function test1() {
             //alert('1');
             var arrayOfValues = $("#<%=hfSelectedWorkingDay.ClientID%>").val()
             var Values = new Array();
             Values = arrayOfValues.split(',');
             $("#<%=ddlWorkingDay1.ClientID%>").val(Values).trigger('change');
         }
         
         function previewFile(input) {
             debugger;
            var file = $("input[type=file]").get(0).files[0];
 
            if(file){
                var reader = new FileReader();
                   reader.onload = function(){
                $("#imgEmp").attr("src", reader.result);
            }
 
            reader.readAsDataURL(file);
        }
    }
    </script>
</asp:Content>
