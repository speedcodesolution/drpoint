<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAppointment.ascx.cs" Inherits="Hospice.Web.CustomControl.EditAppointment" %>
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
<div class="row card-primary">
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
                    <div class="card-body" style="padding: 0; margin: 0; padding-bottom: 2em;">
                        <div class="form-group row" style="display:none">
                            <label for="txtPName" class="col-sm-1 col-form-label">Patient</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtPName" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50" Visible="false"></asp:TextBox>
                            </div>
                            <label for="txtPContact" class="col-sm-1 col-form-label">Mobile</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtPContact" runat="server" CssClass="form-control" placeholder="Enter Contact No" MaxLength="50" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="ddlDoctor" class="col-sm-1 col-form-label">Doctor</label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control select2" Width="100%" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <label for="txtApptDate" class="col-sm-1 col-form-label">Date</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txtApptDate" runat="server" CssClass="form-control datepicker-dropdowns" ClientIDMode="Static" OnTextChanged="txtApptDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="ddlService" class="col-sm-1 col-form-label">Service</label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlService" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlService_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <label for="ddlDuration" class="col-sm-1 col-form-label">Duration</label>
                            <div class="col-sm-5">
                                <asp:DropDownList ID="ddlDuration" runat="server" CssClass="form-control">
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
                                <asp:DropDownList ID="ddlApptStatus" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <label for="ddlTime" class="col-sm-1 col-form-label">Time</label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="ddlAvailabilTime" runat="server" CssClass="form-control select2" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="col-sm-2">
                                <asp:DropDownList ID="ddl" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                    <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="form-inline" style="padding-top: 2em;">
                            <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                <input type="checkbox" class="custom-control-input" id="customControlInline">
                                <label class="custom-control-label" for="customControlInline" style="color: red">Skip Billing</label>
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
                                    <div>
                                        <asp:Label ID="lblNetPrice" runat="server" class="col-form-label-lg" Style="padding: 0px">Email</asp:Label>
                                    </div>
                                    <%--<asp:TextBox ID="txtNetPrice" runat="server" CssClass="form-control col-form-label-lg" Enabled="true"></asp:TextBox>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                        <div class="text-right">
                            <button type="button" class="btn btn-lighten" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnSaveAppt" runat="server" CssClass="btn btn-primary" Text="Save Appointment" OnClick="btnSaveAppt_Click" OnClientClick="return validate();" />
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
