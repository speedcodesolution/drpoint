<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="BranchEntry.aspx.cs" Inherits="Hospice.Web.Admin.BranchEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Page header start -->
    <div class="page-header">
        <ol class="breadcrumb">
            <li class="breadcrumb-item">Branch</li>
            <li class="breadcrumb-item active">Add Branch Details</li>
        </ol>
    </div>
    <!-- Page header end -->

    <!-- Main content -->
    <div class="content-wrapper">
        <section class="content">
            <div class="container-fluid">
                <div class="card card-default mt-2">
                    <div class="card-header bg-gray">
                        <h3 class="card-title">Add/Update</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse"><i class="fas fa-minus"></i></button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove"><i class="fas fa-times"></i></button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Branch Code</label><span class="star-help">*</span>
                                    <asp:TextBox ID="txtBranchCode" runat="server" CssClass="form-control" placeholder="Enter Branch Code" MaxLength="5" required></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name</label><span class="star-help">*</span>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Branch Name" MaxLength="50" required></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Address</label><span class="star-help">*</span>
                                    <asp:TextBox ID="txtaddress1" runat="server" CssClass="form-control" placeholder="Enter Branch Address" MaxLength="500" required></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>State</label><span class="star-help">*</span>
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" required AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>City</label><span class="star-help">*</span>
                                    <asp:DropDownList ID="ddlcity" runat="server" CssClass="form-control select2" required>
                                        <asp:ListItem Text="Select City" Value="" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Delhi" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Secondry Address</label>
                                    <asp:TextBox ID="txtaddress2" runat="server" CssClass="form-control" placeholder="Enter Branch Secondory Address" MaxLength="500"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Mobie No.</label><span class="star-help">*</span>
                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile No." MaxLength="10" onkeypress="return isNumberKey(event)" required></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">

                                    <label for="inputSpeciality">Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Select Status" Value="-1"></asp:ListItem>
                                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
                                    </asp:DropDownList>


                                </div>

                            </div>
                            <!-- /.form-group -->

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email" MaxLength="50"></asp:TextBox>
                                </div>


                                <div class="form-group">
                                    <label for="biO">Remarks</label>
                                    <asp:TextBox ID="txtlabDesc" runat="server" CssClass="form-control" placeholder="Enter description" TextMode="SingleLine" Rows="3" MaxLength="400"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="text-right">
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <a href="BranchListing" class="btn btn-info">Cancel</a>
                                            <asp:Button ID="btnbSavebranchM" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnbSavebranchM_Click" />
                                            <%-- <asp:Button ID="btnbSaveNewbranchM" runat="server" Text="SaveNew" CssClass="btn btn-success" OnClick="btnbSaveNewbranchM_Click"/>--%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnbSavebranchM" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                            </div>

                        </div>
                        <!-- /.col -->

                        <!-- /.col -->
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
    <script type="text/javascript">
        function ClearTextBoxes() {

            $("#<%=txtName.ClientID%>").val('');
            $("#<%=txtBranchCode.ClientID%>").val('');

        }
    </script>
</asp:Content>
