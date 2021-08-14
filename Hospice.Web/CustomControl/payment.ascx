<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="payment.ascx.cs" Inherits="Hospice.Web.CustomControl.payment" %>


 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                    

<div class="content-wrapper">
    <div class="row gutter">
        <div class="col-xl-8 col-lg-8 col-md-8 col-sm-12 col-12">
            <div class="card">
                <div class="card-header">
                    <div class="card-title">Paid bills</div>
               
                     <div class="form-inline">
                  
                      
                       <asp:Label ID="lblpatientname" runat="server" Text="Please select Patient : " for="ddlpatient "></asp:Label>
                        <asp:DropDownList ID="ddlpatient" CssClass="form-control form-control-sm" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlpatient_SelectedIndexChanged"  ClientIDMode="Static"></asp:DropDownList>
                                 
                            
                           
                         </div>
                     </div>
               
                <div class="card">
                   
                    <div class="form-inline">
                       
                               
                        
                        <asp:GridView ID="grdpaidbills" runat="server" CssClass="table table-bordered table-striped table-hover dataTable dtr-inline"   OnRowCommand="grdpaidbills_RowCommand" AutoGenerateColumns="false">

                            <Columns>
                               
                                <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date")%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                      </asp:TemplateField>

                                   
                              
                                  <asp:TemplateField HeaderText="Bill#" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                         <asp:Label ID="lblbillid" runat="server" Text='<%#Eval("billid")%>'></asp:Label>
                                        
                                    </ItemTemplate>

                                </asp:TemplateField>
                                 
                                  <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        <%-- <asp:Label ID="lbltype" runat="server" Text='<%#Eval("type")%>'></asp:Label>--%>
                                        <asp:Label ID="lbltype" runat="server" Text=<%# DataBinder.Eval(Container.DataItem, "type")%>></asp:Label>
                                         
                                    </ItemTemplate>

                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                         <%--<asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>--%>
                                        <%--<asp:LinkButton ID="lnkbtnamount" runat="server" CssClass="btn btn-info btn-sm" CommandArgument='<%# Container.DataItemIndex %>' CommandName="btnshow"><i class="fas fa-trash"> </i> <%#Eval("amount")%></asp:LinkButton>--%>
                                       <asp:LinkButton ID="lnkbtnamount" CssClass="btn btn-info btn-sm" CommandArgument='<%# Container.DataItemIndex %>' CommandName=<%#Eval("amount")%>  runat="server" ><%#Eval("amount")%></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="paymentmode" HeaderText="test" />--%>
                                 <asp:TemplateField HeaderText="Mode" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                         <asp:Label ID="lblpaymentmode" runat="server"  Text='<%#Eval("paymentmode")%>'></asp:Label>
                                        
                                    </ItemTemplate>

                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                         <asp:Label ID="lblcategory" runat="server" Text='<%#Eval("category")%>'></asp:Label>
                                        
                                    </ItemTemplate>

                                </asp:TemplateField>

                                

                               <%--  <asp:TemplateField HeaderText="Actions" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-info btn-sm"  CommandName="btnDelete"><i class="fas fa-trash"> </i> 
                                                            

                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                       
                        
                       
                       
                    </div>
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
                                    <div class="form-group row">
                                          <div class="col-sm-12">
                                    
                                </div>
                                <div class="col-sm-3">
                                    
                                </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                 <div class="form-group row">
                                                      <asp:Label ID="lblgrossamount" for="txtgrossamount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Gross Bill Amount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtgrossamount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>

                                                  <div class="form-group row">
                                                      <asp:Label ID="lbldiscount" for="txtdiscount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Discount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtdiscount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>
                                                  <div class="form-group row">
                                                      <asp:Label ID="lbltaxamount" for="txttaxamount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Tax Amount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txttaxamount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>
                                                  <div class="form-group row">
                                                      <asp:Label ID="lblNetamount" for="txtNetamount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Net Amount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtNetamount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>
                                                  <div class="form-group row">
                                                      <asp:Label ID="lblcollectedamount" for="txtcollectedamount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Collected Amount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtcollectedamount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>
                                                  <div class="form-group row">
                                                      <asp:Label ID="lblnetpaidamount" for="txtnetpaidamount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Net Paid Amount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtnetpaidamount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>
                                                  <div class="form-group row">
                                                      <asp:Label ID="lblbalanceamount" for="txtbalanceamount" CssClass="col-sm-9 col-form-label col-form-label-sm" runat="server" Text="Balance Amount" Font-Bold="true"></asp:Label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtbalanceamount" CssClass="form-control form-control-sm" runat="server" Text="" ReadOnly="True"></asp:TextBox>
                                        </div>
                                                 </div>

                                            </div>
                                        </div>
                                    </div>
                               </div>

                           </div>
                      </div>
                  </div>
             </div>
            
    </div>
</div>

    </ContentTemplate>
                        </asp:UpdatePanel>