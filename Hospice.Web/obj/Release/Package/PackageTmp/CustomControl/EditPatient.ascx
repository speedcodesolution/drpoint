<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditPatient.ascx.cs" Inherits="Hospice.Web.CustomControl.EditPatient" %>
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
<div class="row gutters card-primary" style="margin-right: 0px;
    margin-left: 0px;">
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
                            <label for="txtPName" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Name<i style="color: red">*</i></label>
                            <div class="col-sm-2 pl-1  pr-1">
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm prefix" ID="ddlPrefixPName"></asp:DropDownList>
                            </div>
                            <div class="col-sm-6 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtPName" placeholder="e.g:Hirdayesh Singh" MaxLength="250"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Gender<i style="color: red">*</i></label>
                            <div class="col-sm-8 pl-1 mt-1">
                                <!-- Inline Radios example -->
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="radio" name="inlineRadioOptions" id="rbMale" runat="server" value="1">
                                    <label class="form-check-label" for="rbMale">Male</label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="radio" name="inlineRadioOptions" id="rbFemale" runat="server" value="2">
                                    <label class="form-check-label" for="rbFemale">Female</label>
                                </div>
                                <div class="form-check form-check-inline">
                                    <input class="form-check-input" type="radio" name="inlineRadioOptions" id="rbOther" runat="server" value="3">
                                    <label class="form-check-label" for="rbOther">Other</label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtDOB" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Age Or DOB<i style="color: red">*</i></label>
                            <div class="col-sm-5 pl-1 pr-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtAge" placeholder="e.g.:45 or 20-10-1980" MaxLength="50"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 pl-1" style="flex: 25%; max-width: 25%;">
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlAgeDOB">
                                    <asp:ListItem Text="Year"></asp:ListItem>
                                    <asp:ListItem Text="DOB"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
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
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlBloodGroup">
                                    <asp:ListItem Text="Year"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtCO" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">C/O</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtCO" placeholder="e.g.:Ram Singh" MaxLength="100"></asp:TextBox>
                            </div>

                        </div>
                        <div class="form-group row">
                            <label for="txtMobileNo2" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Mobile2</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtMobileNo2" placeholder="e.g.:1234567890" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                        <div class="form-group row">
                            <label for="txtAddress" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Full Address</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtAddress" Rows="3" placeholder="Current Address" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="ddlCity" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">City</label>
                            <div class="col-sm-8 pl-1">
                                <asp:DropDownList runat="server" CssClass="form-control form-control-sm" ID="ddlCity" placeholder="City">
                                    <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Delhi" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtPin" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Pin</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtPin" placeholder="e.g.:114534" MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtReferencedBy" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Referenced By</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtReferencedBy" placeholder="e.g.:Dr. Ram Singh" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group  row">
                            <label for="txtEmail" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Channel</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtChannel" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group  row">
                            <label for="txtOccupation" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Occupation</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control form-control-sm" ID="txtOccupation" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtTag" class="col-sm-4 col-form-label col-form-label-sm form-labelinl">Tag</label>
                            <div class="col-sm-8 pl-1">
                                <asp:TextBox runat="server" CssClass="form-control" ID="txtTag" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="text-right">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
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
