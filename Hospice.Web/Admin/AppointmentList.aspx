<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AppointmentList.aspx.cs" Inherits="Hospice.Web.Admin.AppointmentList" %>

<%@ Register Src="~/CustomControl/AddAppointment.ascx" TagPrefix="uc1" TagName="AddAppointment" %>
<%@ Register Src="~/CustomControl/EditPatient.ascx" TagPrefix="uc1" TagName="EditPatient" %>
<%@ Register Src="~/CustomControl/EditAppointment.ascx" TagPrefix="uc1" TagName="EditAppointment" %>


<%--<%@ Register Src="~/CustomControl/AddPatient.ascx" TagPrefix="uc1" TagName="AddPatient" %>--%>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Assests/vendor/datepicker/css/classic.css" />
		<link rel="stylesheet" href="../Assests/vendor/datepicker/css/classic.date.css" />
     <link rel="stylesheet" href="../Assests/vendor/select2/css/select2.min.css">

    <!-- Data Tables -->
    <link rel="stylesheet" href="../Assests/vendor/datatables/dataTables.bs4.css" />
    <link rel="stylesheet" href="../Assests/vendor/datatables/dataTables.bs4-custom.css" />

    <link href="../CustomCss/customtab.css" rel="stylesheet" />
    <style>
        #tblAppointmentListing tr .editbl:hover:not(.headerStyle):hover 
        {
          background-color: #bedcfc;
        }
        #tblAppointmentListing tr .editappnt:hover:not(.headerStyle):hover 
        {
          background-color: #bedcfc;
        }
        #tblAppointmentListing tr .editpt:hover:not(.headerStyle):hover 
        {
          background-color: #bedcfc;
        }
        table.innertbl th {padding:0px}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Page header start -->
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Setting</li>
            <li class="breadcrumb-item">Book Appointment</li>
            <li class="breadcrumb-item active">Appointment List</li>
        </ol>
    </div>
    <!-- Page header end -->
    <div class="content-wrapper">
           <div class="row mb-1">
            <div class="col-xl-9 col-lg-9 col-md-12 col-sm-12 col-12">
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
                <div class="text-right">
                    <a id="btnAddNew" runat="server" class="btn btn-success" href="#" data-toggle="modal" data-target=".bd-example-modal-lg"><i class="fa fa-plus"></i> Add New Appointment</a>
                </div>
            </div>
        </div>
        <!-- Row start -->
        <div class="row gutters">
            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <div class="table-container">

                    <!--*************************
						*************************
						*************************
						Basic table start
					*************************
					*************************
					*************************-->
                    <div class="table-responsive1">
                        <asp:Repeater ID="rptAppointmentListing" runat="server" OnItemCommand="rptAppointmentListing_ItemCommand">
                            <HeaderTemplate>
                                <table class="table" id="tblAppointmentListing">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Patient Name</th>
                                            <th>Amount </th>
                                            <th>Action </th>
                                            <th>
                                                <table style="width:100%" class="innertbl">
                                                    <tr>
                                                        <th style="width:20%;text-align:left">Appt Time </th>
                                            <th style="width:20%;text-align:left">Appt Status </th>
                                            <th style="width:20%;text-align:left">Doctor Name </th>
                                            <th style="width:40%;text-align:left">Service Name </th>
                                                    </tr>
                                                </table>
                                            </th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Container.ItemIndex+1 %></td>
                                    <td class="editpt"><%--<asp:Label ID="lblPname" runat="server" Text='<%#Eval("PatinetName") %>' > </asp:Label>--%>
                                        <asp:LinkButton ID="lnkbtnPname" runat="server" CommandName="editpatient" Text='<%#Eval("PatinetName") %>'></asp:LinkButton>
                                    </td>
                                    <td class="editbl"><asp:HiddenField ID="hfpatientid" runat="server"  Value='<%#Eval("PatientId") %>'/><asp:HiddenField ID="hfserviceid" runat="server" Value='<%#Eval("Serviceid") %>'/> <asp:HiddenField ID="hfapptdt" runat="server" Value='<%#Eval("ApptDate") %>'/><asp:HyperLink runat="server" NavigateUrl='<%# string.Format("PrintBill.aspx?ptid={0}&srv={1}&apptdt={2}",
                    HttpUtility.UrlEncode(Eval("PatientId").ToString()), HttpUtility.UrlEncode(Eval("Serviceid").ToString()),Convert.ToDateTime(Eval("ApptDate").ToString()).ToString("yyyy/MM/dd")) %>'
                     ><i class="icon-printer"></i></asp:HyperLink> <%--<a href="#" onclick="openPaymentModal(event)>800</a> --%>
                                        <asp:LinkButton ID="lnkbtnPayment" runat="server" CommandName="payment" Text='<%#Eval("TotalAmount") %>'></asp:LinkButton>
                                    </td><%--"data-toggle="modal" data-target=".bd-payment-modal-lg"--%>
                                    <td>
                                        <div class="btn-group">
								            <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
									            Action
								            </button>
								            <div class="dropdown-menu">
									            <a class="dropdown-item" href="#">Action</a>
									            <a class="dropdown-item" href="#">Another action</a>
									            <a class="dropdown-item" href="#">Something else here</a>
									            <div class="dropdown-divider"></div>
									            <a class="dropdown-item" href="#">Separated link</a>
								            </div>
							            </div>
                                    </td>
                                    <td class="editappnt">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="editappointment" >
                                        <table style="width:100%" >
                                            <tr >
                                        <td style="width:20%"><%#(DateTime.Parse(Eval("ApptTime").ToString())>DateTime.Parse("12:00"))? DateTime.Parse(Eval("ApptTime").ToString()).ToString("hh:mm")+" PM":DateTime.Parse(Eval("ApptTime").ToString()).ToString("hh:mm")+" AM" %>  </td>
                                        <td style="width:20%"><%#Eval("StatusName").ToString().ToUpper() %>  </td>
                                        <td style="width:20%"><%#Eval("Doctor") %>  </td>
                                        <td style="width:40%;"><%#Eval("ServiceName") %>  
                                            <asp:HiddenField ID="hfPaymentStatus" runat="server" Value=''/>
                                        </td>
                                                </tr>
                                        </table></asp:LinkButton>
                                    </td>
                                </tr>

                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <!--*************************
					*************************
					*************************
					Basic table end
				*************************
				*************************
				*************************-->

                </div>
            </div>
        </div>
        <!-- Row end -->

        <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-lg">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title" id="myLargeModalLabel">+ New Appointment</h5>
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body">
						<uc1:AddAppointment runat="server" ID="AddAppointment" />
					</div>
					<%--<div class="modal-footer">
						<button type="button" class="btn btn-lighten" data-dismiss="modal">Close</button>
						<button type="button" class="btn btn-primary">Save</button>
					</div>--%>
				</div>
			</div>
		</div>
        <div class="modal fade bd-editappnt-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myEditAppntLabel" aria-hidden="true">
			<div class="modal-dialog modal-lg">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title" id="myEditAppntLabel">+ Edit Appointment</h5>
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body">
                        <uc1:EditAppointment runat="server" ID="EditAppointment" />
					</div>
					<%--<div class="modal-footer">
						<button type="button" class="btn btn-lighten" data-dismiss="modal">Close</button>
						<button type="button" class="btn btn-primary">Save</button>
					</div>--%>
				</div>
			</div>
		</div>
        <div class="modal fade bd-payment-modal-lg" tabindex="-1" role="dialog" aria-labelledby="paymentModal" aria-hidden="true">
			<div class="modal-dialog modal-lg">
				<div class="modal-content">
					<div class="modal-header">
						<h5 class="modal-title" id="paymentTitle">+ New Appointment</h5>
                        <asp:HiddenField ID="hfbillid" runat="server" />
                        <asp:HiddenField ID="hfpaymentid" runat="server" />
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body" style="padding-bottom:0px">
                        <div class="row">
						<div class="col-xl-5 col-lg-5 col-md-5 col-sm-12 col-12">
                            <div class="row">
		                        <div class="col-sm-12 form-group ">
			                        <a href="#" class="btn btn-info"><i class="icon-print"></i> Print Bill</a>
		                        </div>
		                        <div class="col-sm-12">
                                    <div class="form-group">
										<div class="input-group mb-3">
											<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" aria-label="Email" aria-describedby="basic-addon2"></asp:TextBox>
											<div class="input-group-append">
												<span class="input-group-text" id="basic-addon2"><i class="icon-mail"></i></span>
											</div>
										</div>
									</div>
		                        </div>
	                        </div>
						</div>
                        <div class="col-xl-2 col-lg-2 col-md-2 col-sm-12 col-12"></div>
                        <div class="col-xl-5 col-lg-5 col-md-5 col-sm-12 col-12">
                            <div class="row" style="height:25px;margin-left: 0px;margin-right: 0px;">
		                        <label for="txtGrossBillAmt" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;" >Gross Bill Amount :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtGrossBillAmt" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
                            <div class="row" style="height:25px;margin-left: 0px;margin-right: 0px;">
		                        <label for="txtDiscount" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;">Discount :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
                            <div class="row" style="height:25px;margin-left: 0px;margin-right: 0px;">
		                        <label for="txtServiceTax" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;">Service Tax :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtServiceTax" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
                            <div class="row" style="height:25px;;margin-left: 0px;margin-right: 0px;font-weight:bold">
		                        <label for="txtNetBilledAmt" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;">Net Billed Amount :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtNetBilledAmt" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;font-weight:bold" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
                            <div class="row" style="height:25px;margin-left: 0px;margin-right: 0px;">
		                        <label for="txtCollectedAmt" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;">Collected Amount :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtCollectedAmt" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
                            <div class="row" style="height:25px;margin-left: 0px;margin-right: 0px;font-weight:bold">
		                        <label for="txtNetPaidAmt" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;">Net Paid Amount :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtNetPaidAmt" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;font-weight:bold" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
                            <div class="row" style="height:25px;margin-left: 0px;margin-right: 0px;background-color:#d9d4d4;font-weight:bold">
		                        <label for="txtBalanceAmt" class="col-sm-6 col-form-label text-right" style="height:25px;padding: 0px;padding-top: 1px;">Balance Amount :</label>
		                        <div class="col-sm-6">
			                        <asp:TextBox ID="txtBalanceAmt" runat="server" CssClass="form-control-plaintext form-control-sm text-right" style="height:25px;font-size: 1rem;font-weight:bold" Text="454"></asp:TextBox>
		                        </div>
                                
	                        </div>
						</div>
                            </div>
                        
						<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12" style="padding-left:0px;padding-bottom:0px">
							
							<div class="custom-tabs-container" style="margin-bottom:0px">
								<ul class="nav nav-tabs" id="myTab" role="tablist">
									<li class="nav-item">
										<a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Payment</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Edit Discount</a>
									</li>
									<li class="nav-item">
										<a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">Refund</a>
									</li>
								</ul>
								<div class="tab-content" id="myTabContent">
									<div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
										<div class="form-group row">
                                            <div class="col-xl-4 col-lg col-md-4 col-sm-4 col-12"> 
								            <label for="txtFullName">Payment Mode</label>
								            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPaymentMode" ></asp:DropDownList>
                                                </div>
                                            
                                                <div class="col-xl-4 col-lg col-md-4 col-sm-4 col-12"> 
                                            <label for="txtFullName">Amount</label>
								            <asp:TextBox runat="server" CssClass="form-control" ID="txtPayingAmount" placeholder="0.00" TextMode="Number"></asp:TextBox>
                                                    </div>
                                                
                                            
							            
                                                <div class="col-xl-4 col-lg col-md-4 col-sm-4 col-12"> 
                                                  
                                        <asp:Button ID="btnAddPayment" runat="server" Text="ADD DEPOSIT" CssClass="btn btn-primary"  style="margin-top:25px" OnClick="btnAddPayment_Click"/>
                                                    </div></div>
									</div>
									<div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
										<p>
											Royal Hospitals Admin Template is a modern Bootstrap 4 admin template and UI framework. It is fully responsive built using SASS, HTML5, CSS3 and jQuery. The best Bootstrap admin template you should be able to find a suitable user interface.
										</p>
									</div>
									<div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
										<p>
											The best Bootstrap admin template you should be able to find a suitable user for your project. Royal Hospitals Admin Template is a modern Bootstrap4 admin template and UI framework. It is fully responsive built using, HTML5, CSS3 and jQuery.
										</p>
									</div>
								</div>
							</div>

						</div>

						
					
					</div>
					<div class="modal-footer text-left justify-content-start" style="background-color: #e6e8e9;    display: initial;">
                        <div>Recent Few Payments: </div>
                        <div >
                            <asp:GridView CssClass="table table-bordered table-striped" ID="gvpaymentDetailList" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" HeaderStyle-BackColor="Silver" ShowHeader="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="#" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="InvoiceDate">

                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#Eval("PaymentDt", "{0:dd-MMM-yyyy hh:mm:ss}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="InvoiceDate">

                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#Eval("serviceName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="InvoiceDate">

                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#Eval("pmodPaymentMode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right" >

                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("RecivedAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    

                                </Columns>
                            </asp:GridView>
                        </div>
                      
					</div>
				</div>
			</div>
		</div>

        <div class="modal fade bd-editpatient-modal-xl" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
			<div class="modal-dialog modal-xl">
				<div class="modal-content">
					<div class="modal-header" >
						<h5 class="modal-title" id="myeditpatientModal">Edit Patient</h5>
                        <asp:HiddenField ID="hfpatientid" runat="server" />
						<button type="button" class="close" data-dismiss="modal" aria-label="Close">
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div class="modal-body p-0">
                        <uc1:EditPatient runat="server" ID="EditPatient" />
					</div>
					<%--<div class="modal-footer">
						<button type="button" class="btn btn-lighten" data-dismiss="modal">Close</button>
						<button type="button" class="btn btn-primary">Save</button>
					</div>--%>
				</div>
			</div>
		</div>
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script src="../Assests/vendor/datepicker/js/picker.js"></script>
		<script src="../Assests/vendor/datepicker/js/picker.date.js"></script>
		<script src="../Assests/vendor/datepicker/js/custom-picker.js"></script>

<script src="../Assests/vendor//select2/js/select2.full.min.js"></script>
     <!-- *************
			************ Vendor Js Files *************
		************* -->

    <!-- Data Tables -->
    <script src="../Assests/vendor/datatables/dataTables.min.js"></script>
    <script src="../Assests/vendor/datatables/dataTables.bootstrap.min.js"></script>
     <!-- page script -->
    <script>
        // Basic DataTable
        $(function () {
            $('#tblAppointmentListing').DataTable();
        });

        //function closePaymentModal() {
        //    $('.bd-payment-modal-lg').modal('hide');
           
        //}

        //function openPaymentModal(e) {
        //    debugger;
        //    var ptid = $(e.currentTarget).parent().children()[0].value;
        //    var servid = $(e.currentTarget).parent().children()[1].value;
        //    var aptdt = $(e.currentTarget).parent().children()[2].value;
        //    var ptname = $(e.currentTarget).parent().parent('tr')[0].cells[1].innerText;
        //    $('#paymentTitle').html(ptname);
        //    $('.bd-payment-modal-lg').modal('show');
            
        //}
    </script>
</asp:Content>
