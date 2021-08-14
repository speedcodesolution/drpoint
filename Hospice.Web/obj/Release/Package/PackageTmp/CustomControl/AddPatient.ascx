<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddPatient.ascx.cs" Inherits="Hospice.Web.CustomControl.AddPatient" %>
<%@ Register Src="~/CustomControl/AddAppointment.ascx" TagPrefix="uc1" TagName="AddAppointment" %>

<style>
    .form-labelinl{
        max-width: 22%;
    padding-left: 1%;
    padding-right: 1%;font-size: 0.820rem;
    }
    .form-group {
    margin-bottom: 0.5rem;
}
    .prefix { padding:0px;
    }
</style>
<div class="card card-primary card-tabs" style="margin-bottom:0px">
    <div class="card-header p-0 pt-1">
        <ul class="nav nav-tabs float-right" id="custom-tabs-one-tab" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="custom-tabs-one-home-tab" data-toggle="pill" href="#custom-tabs-one-home" role="tab" aria-controls="custom-tabs-one-home" aria-selected="true"> Add Bill</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="custom-tabs-one-Appnt-tab" data-toggle="pill" href="#custom-tabs-one-Appnt" role="tab" aria-controls="custom-tabs-one-Appnt" aria-selected="false">Appnt</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="custom-tabs-one-messages-tab" data-toggle="pill" href="#custom-tabs-one-messages" role="tab" aria-controls="custom-tabs-one-messages" aria-selected="false">Bills</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="custom-tabs-one-settings-tab" data-toggle="pill" href="#custom-tabs-one-settings" role="tab" aria-controls="custom-tabs-one-settings" aria-selected="false">Paid</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="custom-tabs-one-visits-tab" data-toggle="pill" href="#custom-tabs-one-visits" role="tab" aria-controls="custom-tabs-one-visits" aria-selected="false" style="display:none">Visits</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="custom-tabs-one-lab-tab" data-toggle="pill" href="#custom-tabs-one-lab" role="tab" aria-controls="custom-tabs-one-lab" aria-selected="false" style="display:none">Lab</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" id="custom-tabs-one-edit-tab" data-toggle="pill" href="#custom-tabs-one-edit" role="tab" aria-controls="custom-tabs-one-edit" aria-selected="false">Edit</a>
            </li>
        </ul>
    </div>
    <div class="card-body" style="padding-left: 0px; padding-top: 0px; margin-left: -1px; padding-bottom: 0px">
        <div class="tab-content" id="custom-tabs-one-tabContent" style="padding-top: 0px; padding-bottom: 0px">
            <div class="tab-pane fade show active" id="custom-tabs-one-home" role="tabpanel" aria-labelledby="custom-tabs-one-home-tab">
                Pellentesque vestibulum commodo nibh nec blandit. Maecenas neque magna, iaculis tempus turpis ac, ornare sodales tellus. Mauris eget blandit dolor. Quisque tincidunt venenatis vulputate. Morbi euismod molestie tristique. Vestibulum consectetur dolor a vestibulum pharetra. Donec interdum placerat urna nec pharetra. Etiam eget dapibus orci, eget aliquet urna. Nunc at consequat diam. Nunc et felis ut nisl commodo dignissim. In hac habitasse platea dictumst. Praesent imperdiet accumsan ex sit amet facilisis.
            </div>
            <div class="tab-pane fade" id="custom-tabs-one-Appnt" role="tabpanel" aria-labelledby="custom-tabs-one-Appnt-tab">
                <div class="row card-primary" >
                    <div class="card-header col-5 col-sm-3" style="border-top-left-radius: 0; border-top-right-radius: 0; padding: 0px;">
                        <div class="nav flex-column nav-tabs h-100" id="vert-tabs-tabappnt" role="tablist" aria-orientation="vertical">
                            <a class="nav-link active" id="vert-tabs-appnttoday-tab" data-toggle="pill" href="#vert-tabs-appnttoday" role="tab" aria-controls="vert-tabs-patientdappnttodayetails" aria-selected="true">Appnt Today's</a>
                            <a class="nav-link" id="vert-tabs-appntall-tab" data-toggle="pill" href="#vert-tabs-appntall" role="tab" aria-controls="vert-tabs-appntall" aria-selected="false">Send Appnt All</a>
                        </div>
                    </div>
                    <div class="col-7 col-sm-9">
                        <div class="tab-content" id="vert-tabs-tabAppntContent">
                            <div class="tab-pane text-left fade show active" id="vert-tabs-appnttoday" role="tabpanel" aria-labelledby="vert-tabs-appnttoday-tab">
                                <div class="row gutters">
                                    <div class="card-body" style="padding:0;margin:0;padding-bottom: 2em;">
    <div class="form-group row">
		<label for="txtPName" class="col-sm-1 col-form-label">Patient</label>
		<div class="col-sm-5">
			<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50"></asp:TextBox>
		</div>
        <label for="txtPContact" class="col-sm-1 col-form-label">Mobile</label>
		<div class="col-sm-5">
			<asp:TextBox ID="txtPContact" runat="server" CssClass="form-control" placeholder="Enter Contact No" MaxLength="50"></asp:TextBox>
		</div>
	</div>
    <div class="form-group row">
		<label for="ddlDoctor" class="col-sm-1 col-form-label">Doctor</label>
		<div class="col-sm-5">
			<asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged" AutoPostBack="true"> </asp:DropDownList>
		</div>
        <label for="txtApptDate" class="col-sm-1 col-form-label">Date</label>
		<div class="col-sm-5">
			<asp:TextBox ID="txtApptDate" runat="server" CssClass="form-control datepicker-dropdowns" ClientIDMode="Static" ></asp:TextBox>
		</div>
	</div>
    <div class="form-group row">
		<label for="ddlService" class="col-sm-1 col-form-label">Service</label>
		<div class="col-sm-5">
			<asp:DropDownList ID="ddlService" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlService_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
		</div>
        <label for="ddlDuration" class="col-sm-1 col-form-label">Duration</label>
		<div class="col-sm-5">
			<asp:DropDownList ID="ddlDuration" runat="server" CssClass="form-control" >
                <asp:ListItem Text="10 minute" Value="10"></asp:ListItem>
                <asp:ListItem Text="20 minute" Value="20"></asp:ListItem>
                <asp:ListItem Text="30 minute" Value="30"></asp:ListItem>
                <asp:ListItem Text="40 minute" Value="40"></asp:ListItem>
                <asp:ListItem Text="50 minute" Value="50"></asp:ListItem>
                <asp:ListItem Text="60 minute" Value="60"></asp:ListItem>
			</asp:DropDownList>
		</div>
	</div>
    <div class="form-group row">
		<label for="ddlApptStatus" class="col-sm-1 col-form-label">Status</label>
		<div class="col-sm-5">
			<asp:DropDownList ID="ddlApptStatus" runat="server" CssClass="form-control" ></asp:DropDownList>
		</div>
        <label for="ddlTime" class="col-sm-1 col-form-label">Time</label>
		<div class="col-sm-3">
			<asp:DropDownList ID="ddlAvailabilTime" runat="server" CssClass="form-control select2" Width="100%"></asp:DropDownList>
		</div>
        <div class="col-sm-2">
			<asp:DropDownList ID="ddl" runat="server" CssClass="form-control">
                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
			</asp:DropDownList>
		</div>
        
	</div>
    <div class="form-inline" style="    padding-top: 2em;">
		<div class="custom-control custom-checkbox my-1 mr-sm-2">
			<input type="checkbox" class="custom-control-input" id="customControlInline">
			<label class="custom-control-label" for="customControlInline" style="color:red">Skip Billing</label>
		</div>
	</div>

    <div class="row gutters">
		<div class="col-xl-3 col-lglg-3 col-md-4 col-sm-3 col-12">
			<div class="form-group">
				<label for="txtUnitPrice">Unit Price</label>
				<asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control" TextMode="Number" onblur="priceCalculation()"></asp:TextBox>
			</div>
		</div>
		<div class="col-xl-2 col-lg-2 col-md-2 col-sm-2 col-12">
			<div class="form-group">
				<label for="txtQty">Qty</label>
				<asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TextMode="Number" onblur="priceCalculation()"></asp:TextBox>
			</div>
		</div>
		<div class="col-xl-2 col-lglg-2 col-md-2 col-sm-2 col-12">
			<div class="form-group">
				<label for="txtDiscount">Discount [Rs.]</label>
				<asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" TextMode="Number" onblur="priceCalculation()"></asp:TextBox>
			</div>
		</div>
        <div class="col-xl-2 col-lglg-2 col-md-2 col-sm-2 col-12">
			<div class="form-group">
				<label for="txtTax">Tax [%]</label>
				<asp:TextBox ID="txtTax" runat="server" CssClass="form-control" TextMode="Number" onblur="priceCalculation()"></asp:TextBox>
			</div>
		</div>
        <div class="col-xl-3 col-lglg-3 col-md-4 col-sm-3 col-12">
			<div class="form-group">
				<label for="lblNetPrice">Net Price</label>
                <div >
                    <asp:Label ID="lblNetPrice" runat="server" class="col-form-label-lg" style="padding:0px">Email</asp:Label>
                </div>
				<%--<asp:TextBox ID="txtNetPrice" runat="server" CssClass="form-control col-form-label-lg" Enabled="true"></asp:TextBox>--%>
			</div>
		</div>
	</div>
</div>
						
						            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							            <div class="text-right">
                                            <button type="button" class="btn btn-lighten" data-dismiss="modal">Close</button>
                                            <asp:Button ID="btnSaveAppt" runat="server" CssClass="btn btn-primary" Text="Save Appointment" OnClientClick="return validate();"/>
							            </div>
						            </div>
					            </div>
                            </div>
                            
                            <div class="tab-pane fade" id="vert-tabs-appntall" role="tabpanel" aria-labelledby="vert-tabs-appntall-tab">
                                Mauris tincidunt mi at erat gravida, eget tristique urna bibendum. Mauris pharetra purus ut ligula tempor, et vulputate metus facilisis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Maecenas sollicitudin, nisi a luctus interdum, nisl ligula placerat mi, quis posuere purus ligula eu lectus. Donec nunc tellus, elementum sit amet ultricies at, posuere nec nunc. Nunc euismod pellentesque diam.
                            </div>
                            <div class="tab-pane fade" id="vert-tabs-patientimage" role="tabpanel" aria-labelledby="vert-tabs-patientimage-tab">
                                Morbi turpis dolor, vulputate vitae felis non, tincidunt congue mauris. Phasellus volutpat augue id mi placerat mollis. Vivamus faucibus eu massa eget condimentum. Fusce nec hendrerit sem, ac tristique nulla. Integer vestibulum orci odio. Cras nec augue ipsum. Suspendisse ut velit condimentum, mattis urna a, malesuada nunc. Curabitur eleifend facilisis velit finibus tristique. Nam vulputate, eros non luctus efficitur, ipsum odio volutpat massa, sit amet sollicitudin est libero sed ipsum. Nulla lacinia, ex vitae gravida fermentum, lectus ipsum gravida arcu, id fermentum metus arcu vel metus. Curabitur eget sem eu risus tincidunt eleifend ac ornare magna.
                            </div>
                            <div class="tab-pane fade" id="vert-tabs-patientattach" role="tabpanel" aria-labelledby="vert-tabs-patientattach-tab">
                                Pellentesque vestibulum commodo nibh nec blandit. Maecenas neque magna, iaculis tempus turpis ac, ornare sodales tellus. Mauris eget blandit dolor. Quisque tincidunt venenatis vulputate. Morbi euismod molestie tristique. Vestibulum consectetur dolor a vestibulum pharetra. Donec interdum placerat urna nec pharetra. Etiam eget dapibus orci, eget aliquet urna. Nunc at consequat diam. Nunc et felis ut nisl commodo dignissim. In hac habitasse platea dictumst. Praesent imperdiet accumsan ex sit amet facilisis.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane fade" id="custom-tabs-one-messages" role="tabpanel" aria-labelledby="custom-tabs-one-messages-tab">
                Morbi turpis dolor, vulputate vitae felis non, tincidunt congue mauris. Phasellus volutpat augue id mi placerat mollis. Vivamus faucibus eu massa eget condimentum. Fusce nec hendrerit sem, ac tristique nulla. Integer vestibulum orci odio. Cras nec augue ipsum. Suspendisse ut velit condimentum, mattis urna a, malesuada nunc. Curabitur eleifend facilisis velit finibus tristique. Nam vulputate, eros non luctus efficitur, ipsum odio volutpat massa, sit amet sollicitudin est libero sed ipsum. Nulla lacinia, ex vitae gravida fermentum, lectus ipsum gravida arcu, id fermentum metus arcu vel metus. Curabitur eget sem eu risus tincidunt eleifend ac ornare magna.
            </div>
            <div class="tab-pane fade" id="custom-tabs-one-settings" role="tabpanel" aria-labelledby="custom-tabs-one-settings-tab">
                Pellentesque vestibulum commodo nibh nec blandit. Maecenas neque magna, iaculis tempus turpis ac, ornare sodales tellus. Mauris eget blandit dolor. Quisque tincidunt venenatis vulputate. Morbi euismod molestie tristique. Vestibulum consectetur dolor a vestibulum pharetra. Donec interdum placerat urna nec pharetra. Etiam eget dapibus orci, eget aliquet urna. Nunc at consequat diam. Nunc et felis ut nisl commodo dignissim. In hac habitasse platea dictumst. Praesent imperdiet accumsan ex sit amet facilisis.
            </div>
            <div class="tab-pane fade" id="custom-tabs-one-edit" role="tabpanel" aria-labelledby="custom-tabs-one-edit-tab">
                <div class="row card-primary" >
                    <div class="card-header col-5 col-sm-3" style="border-top-left-radius: 0; border-top-right-radius: 0; padding: 0px;">
                        <div class="nav flex-column nav-tabs h-100" id="vert-tabs-tab" role="tablist" aria-orientation="vertical">
                            <a class="nav-link active" id="vert-tabs-patientdetails-tab" data-toggle="pill" href="#vert-tabs-patientdetails" role="tab" aria-controls="vert-tabs-patientdetails" aria-selected="true">Patient Details</a>
                            <a class="nav-link" id="vert-tabs-sendsms-tab" data-toggle="pill" href="#vert-tabs-sendsms" role="tab" aria-controls="vert-tabs-sendsms" aria-selected="false">Send SMS</a>
                            <a class="nav-link" id="vert-tabs-patientimage-tab" data-toggle="pill" href="#vert-tabs-patientimage" role="tab" aria-controls="vert-tabs-patientimage" aria-selected="false">Patient Image</a>
                            <a class="nav-link" id="vert-tabs-patientattach-tab" data-toggle="pill" href="#vert-tabs-patientattach" role="tab" aria-controls="vert-tabs-patientattach" aria-selected="false">Patient Attach</a>
                        </div>
                    </div>
                    <div class="col-7 col-sm-9">
                        <div class="tab-content" id="vert-tabs-tabContent">
                            <div class="tab-pane text-left fade show active" id="vert-tabs-patientdetails" role="tabpanel" aria-labelledby="vert-tabs-patientdetails-tab">
                                <div class="row gutters">
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group row">
								<label for="txtPName" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Name<i style="color:red">*</i></label>
                                <div class="col-sm-2 pl-1  pr-1">
								<asp:DropDownList runat="server" CssClass="form-control form-control-sm prefix" ID="ddlPrefixPName" ></asp:DropDownList>
                                    </div>
                                <div class="col-sm-6 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtPName" placeholder="e.g:Hirdayesh Singh" MaxLength="250"></asp:TextBox>
                                    </div>
							</div>
                            <div class="form-group row">
								<label class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Gender<i style="color:red">*</i></label>
                                <div class="col-sm-8 pl-1 mt-1">
									<!-- Inline Radios example -->
									<div class="form-check form-check-inline">
										<input class="form-check-input" type="radio" name="inlineRadioOptions" id="rbMale" runat="server" value="1">
										<label class="form-check-label" for="rbMale">Male</label>
									</div>
									<div class="form-check form-check-inline">
										<input class="form-check-input" type="radio" name="inlineRadioOptions" id="rbFemale" runat="server"  value="2">
										<label class="form-check-label" for="rbFemale">Female</label>
									</div>
									<div class="form-check form-check-inline">
										<input class="form-check-input" type="radio" name="inlineRadioOptions" id="rbOther" runat="server"  value="3">
										<label class="form-check-label" for="rbOther">Other</label>
									</div>
                                </div>
							</div>
                            <div class="form-group row">
								<label for="txtDOB" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Age Or DOB<i style="color:red">*</i></label>
                                <div class="col-sm-5 pl-1 pr-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtAge" placeholder="e.g.:45 or 20-10-1980"  MaxLength="50"></asp:TextBox>
                                    </div>
                                <div class="col-sm-3 pl-1" style="flex: 25%; max-width: 25%;">
								<asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlAgeDOB" >
                                    <asp:ListItem Text="Year"></asp:ListItem>
                                    <asp:ListItem Text="DOB"></asp:ListItem>
								</asp:DropDownList>
                                    </div>
							</div>
                            <div class="form-group row" >
								<label for="txtMobileNo" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Mobile No.</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtMobileNo" placeholder="e.g.:1234567890" TextMode="Number" MaxLength="10"></asp:TextBox>
                                    </div>
							</div>
                            <div class="form-group row">
								<label for="txtEmail" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Email</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtEmail" placeholder="e.g:doctor@bm.com" TextMode="Email" MaxLength="100"></asp:TextBox>
                                </div>
							</div>
                            <div class="form-group row">
								<label for="ddlBloodGroup" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Blood Group</label>
                                <div class="col-sm-8 pl-1">
								<asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlBloodGroup" >
                                    <asp:ListItem Text="Year"></asp:ListItem>
								</asp:DropDownList>
                                    </div>
							</div>
                            <div class="form-group row">
								<label for="txtCO" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">C/O</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtCO" placeholder="e.g.:Ram Singh"  MaxLength="100"></asp:TextBox>
                                    </div>

							</div>
                            <div class="form-group row">
								<label for="txtMobileNo2" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Mobile2</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtMobileNo2" placeholder="e.g.:1234567890"  MaxLength="10"></asp:TextBox>
                                    </div>
							</div>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                            <div class="form-group row">
								<label for="txtAddress" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Full Address</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtAddress" rows="3" placeholder="Current Address" TextMode="MultiLine"></asp:TextBox>
							</div></div>
                            <div class="form-group row">
								<label for="ddlCity" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">City</label>
                                <div class="col-sm-8 pl-1">
								<asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlCity" placeholder="City">
                                    <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Delhi" Value="1"></asp:ListItem>
								</asp:DropDownList>
							</div></div>
                            <div class="form-group row">
								<label for="txtPin" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Pin</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtPin" placeholder="e.g.:114534"  MaxLength="6"></asp:TextBox>
							</div></div>
                            <div class="form-group row" >
								<label for="txtReferencedBy" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Referenced By</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtReferencedBy" placeholder="e.g.:Dr. Ram Singh"  MaxLength="100"></asp:TextBox>
							</div></div>
                            <div class="form-group  row">
								<label for="txtEmail" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Channel</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtChannel" MaxLength="100"></asp:TextBox>
							</div></div>
                            <div class="form-group  row">
								<label for="txtOccupation" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Occupation</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtOccupation" MaxLength="100"></asp:TextBox>
							</div></div>
                            <div class="form-group row">
								<label for="txtTag" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Tag</label>
                                <div class="col-sm-8 pl-1">
								<asp:TextBox runat="server" CssClass="form-control" ID="txtTag"  MaxLength="100"></asp:TextBox>
							</div>
                                </div>
                        </div>
						
						<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
							<div class="text-right">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click"/>
							</div>
						</div>
					</div>
                            </div>
                            
                            <div class="tab-pane fade" id="vert-tabs-sendsms" role="tabpanel" aria-labelledby="vert-tabs-sendsms-tab">
                                Mauris tincidunt mi at erat gravida, eget tristique urna bibendum. Mauris pharetra purus ut ligula tempor, et vulputate metus facilisis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Maecenas sollicitudin, nisi a luctus interdum, nisl ligula placerat mi, quis posuere purus ligula eu lectus. Donec nunc tellus, elementum sit amet ultricies at, posuere nec nunc. Nunc euismod pellentesque diam.
                            </div>
                            <div class="tab-pane fade" id="vert-tabs-patientimage" role="tabpanel" aria-labelledby="vert-tabs-patientimage-tab">
                                Morbi turpis dolor, vulputate vitae felis non, tincidunt congue mauris. Phasellus volutpat augue id mi placerat mollis. Vivamus faucibus eu massa eget condimentum. Fusce nec hendrerit sem, ac tristique nulla. Integer vestibulum orci odio. Cras nec augue ipsum. Suspendisse ut velit condimentum, mattis urna a, malesuada nunc. Curabitur eleifend facilisis velit finibus tristique. Nam vulputate, eros non luctus efficitur, ipsum odio volutpat massa, sit amet sollicitudin est libero sed ipsum. Nulla lacinia, ex vitae gravida fermentum, lectus ipsum gravida arcu, id fermentum metus arcu vel metus. Curabitur eget sem eu risus tincidunt eleifend ac ornare magna.
                            </div>
                            <div class="tab-pane fade" id="vert-tabs-patientattach" role="tabpanel" aria-labelledby="vert-tabs-patientattach-tab">
                                Pellentesque vestibulum commodo nibh nec blandit. Maecenas neque magna, iaculis tempus turpis ac, ornare sodales tellus. Mauris eget blandit dolor. Quisque tincidunt venenatis vulputate. Morbi euismod molestie tristique. Vestibulum consectetur dolor a vestibulum pharetra. Donec interdum placerat urna nec pharetra. Etiam eget dapibus orci, eget aliquet urna. Nunc at consequat diam. Nunc et felis ut nisl commodo dignissim. In hac habitasse platea dictumst. Praesent imperdiet accumsan ex sit amet facilisis.
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.card -->
    <div class="card-footer" style="background-color: #254189; border: none; padding-bottom: 0.5rem; padding-top: 0.5rem; color: #fff; font-weight: 600; font-size: 14px;">
        Last Payment : Today for ServiceName
    </div>
</div>
<script>
    function savePayment(pid) {
         //alert("Amout has been successfully updated.88888"+pid);
             $.ajax({
                type: "POST",
                url: "WebMethods.aspx/GetShippingName",
                data: '{_pid: "' + pid + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    
                     alert("Amout has been successfully updated."+response.d);
                },
                failure: function(response) {
                    alert(response.d+"--ddd");
                }
            });
        }
</script>