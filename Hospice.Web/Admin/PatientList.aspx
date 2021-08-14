<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="Hospice.Web.Admin.PatientList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page header start -->
<div class="page-header">
	<ol class="breadcrumb">
		<li class="breadcrumb-item">Patient</li>
		<li class="breadcrumb-item active">Patient List</li>
	</ol>
</div>
<!-- Page header end -->
    <div class="content-wrapper">
    <div class="row gutters">
        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
    <asp:Repeater ID="rptPatientListing" runat="server">
        <HeaderTemplate>
            <table  id="tblPatientListing"   class="table table-bordered table-striped table-hover">
                 <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>PatientId</th>
<th>      PrefixId</th>
<th>      Name</th>
<th>      GenderId</th>
<th>      DateOfBirth</th>
<th>      Age</th>
<th>      Mobile1</th>
<th>      Mobile2</th>
<th>      BlodGroupId</th>
<th>      Email</th>
<th>      Address</th>
<th>      Area</th>
<th>      CityId</th>
<th>      Pin</th>
<th>      RefferredBy</th>
<th>      CareOf</th>
<th>      Occupation</th>
<th>      Tag</th>
<th>      Status</th>
<th>      BranchId</th>
<%--<th>      CreatedBy</th>
<th>      CreatedOn</th>
<th>      UpdatedBy</th>
<th>      UpdatedOn</th>--%>
 <th>Status </th>
                                            <th>Action </th>
                                        </tr>
                                    </thead>
             <tbody>
        </HeaderTemplate>
        <ItemTemplate>
             <tr>
                 <td><%#Container.ItemIndex+1 %></td>
                                    <td><%#Eval("PatientId") %>  </td>
 <td><%#Eval("PrefixId") %>  </td>
 <td><%#Eval("Name") %>  </td>
 <td><%#Eval("GenderId") %>  </td>
 <td><%#Eval("DateOfBirth") %>  </td>
 <td><%#Eval("Age") %>  </td>
 <td><%#Eval("Mobile1") %>  </td>
 <td><%#Eval("Mobile2") %>  </td>
 <td><%#Eval("BlodGroupId") %>  </td>
 <td><%#Eval("Email") %>  </td>
 <td><%#Eval("Address") %>  </td>
 <td><%#Eval("Area") %>  </td>
 <td><%#Eval("CityId") %>  </td>
 <td><%#Eval("Pin") %>  </td>
 <td><%#Eval("RefferredBy") %>  </td>
 <td><%#Eval("CareOf") %>  </td>
 <td><%#Eval("Occupation") %>  </td>
 <td><%#Eval("Tag") %>  </td>
 <td><%#Eval("Status") %>  </td>
 <td><%#Eval("BranchId") %>  </td>
 <%--<td><%#Eval("CreatedBy") %>  </td>
 <td><%#Eval("CreatedOn") %>  </td>
 <td><%#Eval("UpdatedBy") %>  </td>
 <td><%#Eval("UpdatedOn") %>  </td>--%>
                  <td>
                                        <a href="#" id="lnkStatus" title='<%# Eval("PatientId") %>' onclick="changestatus(this,'subject');"></a>
                                    </td>
                                    <td>
                                        <div class="btn-group btn-group-sm">
                                            <asp:LinkButton ID="btnEdit" runat="server" PostBackUrl='<%#"~/Admin/PatinetEntry?PatientId="+Eval("PatientId") %>' CssClass="btn btn-info" CommandName="btnEdit">
                                                <i class="icon-edit1"></i></asp:LinkButton>

                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("PatientId")%>' CommandName="btnDelete" OnClientClick="javascript:return confirm('Sure to delete this record?');"><i class="icon-cancel"></i></asp:LinkButton>
                                        </div>
                                    </td>

                                </tr>

        </ItemTemplate>
        <FooterTemplate>
            </tbody>
                                </table>
        </FooterTemplate>

    </asp:Repeater>
            </div>
        </div>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>


