<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddBill.ascx.cs" Inherits="Hospice.Web.CustomControl.AddBill" %>

<!-- Required jQuery first, then Bootstrap Bundle JS -->
		<script src="../Assests/js/jquery.min.js"></script>
		<script src="../Assests/js/bootstrap.bundle.min.js"></script>
		<script src="../Assests/js/moment.js"></script>
<style>
    /*.btn {
  border: 2px solid black;
  background-color: white;
  color: black;
  padding: 14px 28px;
  font-size: 16px;
  cursor: pointer;
}*/

    /* Blue */
    .btn-outline-primary {
        border-color: #242e64; /*#2196F3;*/
        color: #242e64; /*dodgerblue*/
    }

        .btn-outline-primary :hover {
            background: #242e64; /*#2196F3;*/
            color: white;
        }
</style>
<!-- Page header start -->
<div class="page-header">
    <ol class="breadcrumb">
        <li class="breadcrumb-item">Billing</li>
        <li class="breadcrumb-item active">Add Bill</li>
    </ol>
</div>
<!-- Page header end -->

<div class="content-wrapper">
    <div class="row gutters">
        <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12 col-12">
            <div class="card">
                <%--<div class="card-header">
                    <div class="card-title">Add Bill</div>
                </div>--%>
                <div class="card-body">

                    <div class="form-inline">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblpatientlist" runat="server" Text="Patient List" CssClass="sr-only" for="ddlpatient "></asp:Label>
                                <asp:DropDownList ID="ddlpatient" CssClass="form-control form-control-sm mr-sm-2" runat="server" OnSelectedIndexChanged="ddlpatient_SelectedIndexChanged" AutoPostBack="True" ClientIDMode="Static"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlpatient" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>


                                <asp:Label ID="lblservice" runat="server" Text="Service List" class="sr-only" for="ddlservicename"></asp:Label>
                                <asp:DropDownList ID="ddlservicename" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlservicename_SelectedIndexChanged" ClientIDMode="Static"></asp:DropDownList>
                                <asp:TextBox ID="txtprice" CssClass="form-control form-control-sm" runat="server" placeholder="Unit Price" ReadOnly="True" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtdiscount" CssClass="form-control form-control-sm" runat="server" placeholder="Discount" ClientIDMode="Static"></asp:TextBox>
                                <asp:Button ID="btnaddbill" runat="server" Text="Add" OnClick="btnaddbill_Click" CssClass="btn btn-info btn-sm" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlservicename" EventName="SelectedIndexChanged" />

                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <hr>

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdaddbill" runat="server" CssClass="table table-bordered table-striped table-hover dataTable dtr-inline" OnRowDataBound="grdaddbill_RowDataBound" OnRowCommand="grdaddbill_RowCommand" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                 <asp:LinkButton ID="btnAddtoBill" runat="server" CssClass="btn btn-info btn-sm" CommandArgument='<%# Container.DataItemIndex %>' CommandName="btnAddtoBill" OnClientClick='<%# "showdiv(" +Eval("mode") + " );" %>'><i class="fas fa-trash"> </i> 
                                                            AddtoPay
                                            </asp:LinkButton>
                                            <asp:HiddenField ID="hfBillid" runat="server" Value='<%# Eval("BillId") %>' />
                                            <asp:HiddenField ID="hfpatientid" runat="server" Value='<%# Eval("PatinetId") %>' />
                                            <asp:HiddenField ID="hfserviceid" runat="server" Value='<%# Eval("ServiceId") %>'/>
                                            <asp:HiddenField ID="hfmode" runat="server" Value='<%# Eval("mode") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
                                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                                    <asp:BoundField DataField="Discount" HeaderText="Discount" />
                                </Columns>
                            </asp:GridView>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdaddbill" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        
        <div id="paymentdiv" class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12" style="display: none">

            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="card">
                        <%--<div class="card-header">
                            <div class="card-title">Payment</div>
                        </div>--%>

                        <div class="card-body">

                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div class="form-group row">
                                        <asp:Label ID="lblServiceName" for="lblServiceAmt" CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Service Name" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-4">
                                            <a href="#"><i class="icon-printer"></i></a>
                                            <asp:Label ID="lblServiceAmt" CssClass="col-form-label col-form-label-sm" runat="server" Text="Price" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label ID="lblbalance" for="txtbalance" CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Total Balance" Visible="True"></asp:Label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtbalance" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label ID="lblpaymentmode" CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Payment mode"></asp:Label>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlpaymentmode" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlpaymentmode_SelectedIndexChanged" ClientIDMode="Static">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlpaymentmode" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>


                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="form-group row">
                                        <div class="col-sm-12" style="text-align: center">
                                            <asp:Button ID="btnpay" CssClass="btn btn-primary" runat="server" Text="PAY" OnClick="btnpay_Click" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnpay" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div class="form-group row">
                                <div class="col-sm-12" style="text-align: center">
                                    <asp:LinkButton ID="lnkbtnprint" CssClass="btn btn-outline-primary" runat="server" Text="Print Bill"><i class="icon-printer"></i> Print Bill</asp:LinkButton>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="txtemail" CssClass="form-control" runat="server" placeholder="Recipient's Email" aria-label="Recipient's Email" aria-describedby="btnemail"></asp:TextBox>
                                    <div class="input-group-append">
                                        <asp:LinkButton ID="btnemail1" CssClass="btn btn-primary" runat="server"><i class="icon-mail"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group row">
                                <asp:Label ID="lblbalamnt" runat="server" CssClass="col-sm-3 col-form-label col-form-label-sm" Text="Label" Visible="False"></asp:Label>
                                <div class="col-sm-9">
                                    <asp:Label ID="lblbillid" runat="server" Text="Label" Visible="False"></asp:Label>
                                </div>
                            </div>


                        </div>

                    </div>
                </div>
            </div>

        </div>
        <div id="appoinmentdiv" class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12" style="display: none">
            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="card">
                        <%--<div class="card-header">
                            <div class="card-title">Appoinment</div>
                        </div>--%>
                        <div class="card-body">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                            <div class="form-group row">
                                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                    <label for="ddlDoctor">Choose Doctor</label>
                                    <asp:DropDownList ID="ddlDoctor" CssClass="form-control form-control-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                    <label for="txtApptDate">Appoinment Date</label>
                                    <asp:TextBox ID="txtApptDate" runat="server" CssClass="form-control datepicker-dropdowns" ClientIDMode="Static" ></asp:TextBox>
                                </div>
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6 col-12">
                                    <label for="txtDuration">Duration</label>
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
                                <div class="col-xl-8 col-lg-8 col-md-8 col-sm-8 col-12">
                                    <label for="txtDuration">Appoinment Time</label>
                                    <asp:DropDownList ID="ddlAvailabilTime" runat="server" CssClass="form-control select2" Width="100%" onchange="AvailabilTimeChangeFun();" ClientIDMode="Static"></asp:DropDownList>
                                </div>
                                <div class="col-xl-4 col-lg-4 col-md-8 col-sm-8 col-12" style="padding-top: 22px;">
                                    <asp:DropDownList ID="ddl" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label1" CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Service Name" Font-Bold="true"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtUnitePrice" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <asp:Label ID="Label2" for="txtTotalAmt" CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Total" Font-Bold="true"></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtTotalAmt" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlDoctor" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>


                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>

                                <div class="form-group row">
                                    <div class="col-sm-6" style="text-align: left">
                                        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Back" />
                                    </div>
                                    <div class="col-sm-6" style="text-align: right">
                                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Create Bill" OnClick="Button1_Click"/>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnpay" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div id="createBilldiv" class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12" style="display:none">

            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="card-title">Create Bill</div>
                        </div>
                        <div class="card-body">



                           
                                    <div class="form-group row">
                                        <asp:Label ID="Label1"  CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Service Name" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtUnitePrice" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label ID="Label2" for="txtTotalAmt" CssClass="col-sm-8 col-form-label col-form-label-sm" runat="server" Text="Total" Visible="True"></asp:Label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="txtTotalAmt" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>

                                    <div class="form-group row">
                                        <div class="col-sm-12" style="text-align:center">
                                            <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Create Bill" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnpay" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>



                        </div>
                    </div>
                </div>
            </div>

        </div>--%>
</div>
</div>
<script>
    

    $(function () {
        bindDatePickers(); // bind date picker on first page load
   Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindDatePickers); // bind date picker on every UpdatePanel refresh
});

function bindDatePickers() {
    $('.datepicker-dropdowns').pickadate({
	selectYears: true,
    selectMonths: true,
    format: 'dd-mm-yyyy',
    formatSubmit: 'yyyy-mm-dd'
    })  
 }
    function showdiv(bid) {
        debugger;
        if (bid=="" || bid==undefined) {
            $("#paymentdiv").css("display", "");
            $("#appoinmentdiv").css("display", "none");
        }
        else if (Number(bid) < 0) {
            $("#paymentdiv").css("display", "none");
            $("#appoinmentdiv").css("display", "");
        }
        //alert(bid);;
    }
     function AvailabilTimeChangeFun()
      {
          debugger;
          var t = $("#ddlAvailabilTime").val();
          var dt = new Date();
          var st = new Date('00', '00', '00', t.split(':')[0], t.split(':')[1], t.split(':')[2]);
         var dtt = new Date('00', '00', '00', '12', '00', '00');
         $('#ddl option:selected').removeAttr('selected');
          if(st>dtt)
              $("#ddl option[value='PM']").attr("selected", "selected");
          else
              $("#ddl option[value='AM']").attr("selected", "selected");
      }
</script>
