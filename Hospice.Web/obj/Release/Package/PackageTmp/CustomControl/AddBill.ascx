<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddBill.ascx.cs" Inherits="Hospice.Web.CustomControl.AddBill" %>
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
                <div class="card-header">
                    <div class="card-title">Add Bill</div>
                </div>
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
                            <asp:GridView ID="grdaddbill" runat="server" CssClass="table table-bordered table-striped table-hover dataTable dtr-inline" OnRowCommand="grdaddbill_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-info btn-sm" CommandArgument='<%# Container.DataItemIndex %>' CommandName="btnDelete"><i class="fas fa-trash"> </i> 
                                                            AddtoPay

                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
        <div class="col-xl-4 col-lg-4 col-md-4 col-sm-12 col-12">

            <div class="row gutters">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="card">
                        <div class="card-header">
                            <div class="card-title">Payment</div>
                        </div>
                        <div class="card-body">



                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div class="form-group row">
                                        <%--<label for="colFormLabelSm" class="col-sm-3 col-form-label col-form-label-sm">Email</label>--%>
                                        <asp:Label ID="lblconsultation" for="txtconsultation" CssClass="col-sm-3 col-form-label col-form-label-sm" runat="server" Text="Consultation" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <%--<input type="email" class="form-control form-control-sm" id="colFormLabelSm" placeholder="col-form-label-sm">--%>
                                            <asp:TextBox ID="txtconsultation" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <%--<label for="colFormLabel" class="col-sm-3 col-form-label">Email</label>--%>
                                        <asp:Label ID="lblbalance" for="txtbalance" CssClass="col-sm-3 col-form-label col-form-label-sm" runat="server" Text="Balance" Visible="True"></asp:Label>
                                        <div class="col-sm-9">
                                            <%--<input type="email" class="form-control" id="colFormLabel" placeholder="col-form-label">--%>
                                            <asp:TextBox ID="txtbalance" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Label ID="lblpaymentmode" CssClass="col-sm-3 col-form-label col-form-label-sm" runat="server" Text="Payment mode"></asp:Label>
                                        <div class="col-sm-9">
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
                                        <div class="col-sm-12" style="text-align:center">
                                            <asp:Button ID="btnpay" CssClass="btn btn-primary" runat="server" Text="Pay" OnClick="btnpay_Click" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnpay" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <div class="form-group row">
                                <div class="col-sm-12" style="text-align:center">
                                    <asp:Button ID="btnprint" CssClass="btn btn-primary" runat="server" Text="Print" />
                                </div>
                                <div class="col-sm-12">
                                    
                                </div>
                                <div class="col-sm-3">
                                    
                                </div>
                            </div>

                            <div class="form-group">
								<div class="input-group">
									<%--<input type="text" class="form-control" placeholder="Recipient's username" aria-label="Recipient's username" aria-describedby="button-addon2">--%>
                                    <asp:TextBox ID="txtemail" CssClass="form-control" runat="server" placeholder="Recipient's Email" aria-label="Recipient's Email" aria-describedby="btnemail"></asp:TextBox>
									<div class="input-group-append">
										<%--<button class="btn btn-primary" type="button" id="button-addon2">Button</button>--%>
                                        <asp:LinkButton ID="btnemail1" CssClass="btn btn-primary" runat="server"><i class="icon-mail"></i></asp:LinkButton>
                                        <%--<asp:Button ID="btnemail" CssClass="btn btn-primary" runat="server" />--%>
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
    </div>
</div>

