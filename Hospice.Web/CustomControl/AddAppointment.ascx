<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAppointment.ascx.cs" Inherits="Hospice.Web.CustomControl.AddAppointment" %>



<!-- Required jQuery first, then Bootstrap Bundle JS -->
		<script src="../Assests/js/jquery.min.js"></script>
		<script src="../Assests/js/bootstrap.bundle.min.js"></script>
		<script src="../Assests/js/moment.js"></script>



<div class="card-body" style="padding:0;margin:0;padding-bottom: 2em;">
    <div class="form-group row">
		<label for="txtPName" class="col-sm-1 col-form-label">Patient</label>
		<div class="col-sm-5">
			<asp:TextBox ID="txtPName" runat="server" CssClass="form-control" placeholder="Enter Name" MaxLength="50"></asp:TextBox>
		</div>
        <label for="txtPContact" class="col-sm-1 col-form-label">Mobile</label>
		<div class="col-sm-5">
			<asp:TextBox ID="txtPContact" runat="server" CssClass="form-control" placeholder="Enter Contact No" MaxLength="50"></asp:TextBox>
		</div>
	</div>
    <div class="form-group row">
		<label for="ddlDoctor" class="col-sm-1 col-form-label">Doctor</label>
		<div class="col-sm-5">
			<asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged" AutoPostBack="true" Width="100%"></asp:DropDownList>
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
		<div class="col-sm-3" style="flex: 18%;
    max-width: 18%;">
			<asp:DropDownList ID="ddlAvailabilTime" runat="server" CssClass="form-control select2" Width="100%" onchange="AvailabilTimeChangeFun();" ClientIDMode="Static"></asp:DropDownList>
		</div>
        <div class="col-sm-2">
			<asp:DropDownList ID="ddl" runat="server" CssClass="form-control" ClientIDMode="Static">
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
<!-- /.card-body -->

<div class="modal-footer">
						<button type="button" class="btn btn-lighten" data-dismiss="modal">Close</button>
						<%--<button type="button" class="btn btn-primary">Save</button>--%>
                        <asp:Button ID="btnSaveAppt" runat="server" CssClass="btn btn-primary" Text="Save Appointment" OnClick="btnSaveAppt_Click" OnClientClick="return validate();"/>
					</div>

<script>
    function validate() {
        if ($('#<%=txtPName.ClientID%>').val() == "") {
            alert("Please Enter Patient Name.");
            return false;
        }
        if ($('#<%=txtPContact.ClientID%>').val() == "") {
            alert("Please Enter Patient contact number.");
        return false;}
        if ($('#<%=ddlDoctor.ClientID%>').val() == "") {
            alert("Please select doctor.");
        return false;}
        if ($('#<%=ddlService.ClientID%>').val() == "") {
            alert("Please select service.");
        return false;}
        if ($('#<%=ddlAvailabilTime.ClientID%>').val() == "") {
            alert("Please select time.");
        return false;
    }
         var up = $('#<%=txtUnitPrice.ClientID%>').val();
        if (up == "") {
            alert("Unit price not empty.");
            return false;
        }
        var qty = $('#<%=txtQty.ClientID%>').val();
        if (qty == "") {
            alert("Quantity not empty.");
            return false;
        }
        return true;
    }
    function priceCalculation() {
        debugger;
        var up = $('#<%=txtUnitPrice.ClientID%>').val();
        var qty = 0;var tax = 0; var discount = 0;
        if($('#<%=txtQty.ClientID%>').val()!="")
            qty = $('#<%=txtQty.ClientID%>').val();
        if($('#<%=txtTax.ClientID%>').val()!="")
            tax = $('#<%=txtTax.ClientID%>').val();
       if($('#<%=txtDiscount.ClientID%>').val()!="")
            discount = $('#<%=txtDiscount.ClientID%>').val();
       // if (parseInt(up) > 0 && parseInt(qty) > 0) {
            up = (up * qty);

            if (parseInt(discount) > 0)
                up = up - parseInt(discount);
            var amount = parseFloat((parseFloat(up) + ((parseFloat(up) * parseFloat(tax)) / 100)));


            $('#<%=lblNetPrice.ClientID%>').text(Number(amount).toFixed(2));

        //}
        return true;
    }

      function AvailabilTimeChangeFun()
      {
          debugger;
          var t = $("#ddlAvailabilTime").val();
          var dt = new Date();
          var st = new Date('00', '00', '00', t.split(':')[0], t.split(':')[1], t.split(':')[2]);
          var dtt = new Date('00', '00', '00', '12', '00', '00');
          $('#ddl option:selected').removeAttr('selected');
          if (st > dtt) 
              $("#ddl option[value='PM']").attr("selected", "selected");
          else 
              $("#ddl option[value='AM']").attr("selected", "selected");
      }
</script>