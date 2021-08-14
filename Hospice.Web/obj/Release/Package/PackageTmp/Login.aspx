<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hospice.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

		<!-- Meta -->
		<meta name="description" content="Dr Points">
		<meta name="author" content="Dr Points">
		<link rel="shortcut icon" href="../Assests/img/fav.png" />

		<!-- Title -->
		<title>Dr Points - Login</title>
		
		<!-- *************
			************ Common Css Files *************
			************ -->
		<!-- Bootstrap CSS -->
		<link rel="stylesheet" href="Assests/css/bootstrap.min.css" />

		<!-- Master CSS -->
		<link rel="stylesheet" href="Assests/css/main.css" />

    <link href="CustomCss/custom.css" rel="stylesheet" />
</head>
<body class="authentication">
    <!-- Container start -->
		<div class="container">
    <form id="form1" runat="server" >
        <div class="row justify-content-md-center">
					<div class="col-xl-4 col-lg-5 col-md-6 col-sm-12">
						<div class="login-screen">
							<div class="login-box">
								<a href="#" class="login-logo">
									Dr's Points
								</a>
                                <p class="text-red">
                                    <asp:Literal runat="server" ID="FailureText"/>
                                </p>
								<h5>Welcome back,<br />Please Login to your Account.</h5>
								<div class="form-group">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name" required ToolTip="User Name"></asp:TextBox>
								</div>
								<div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" required ToolTip="Password"></asp:TextBox>
								</div>
								<div class="actions">
									<%--<a href="forgot-pwd.html">Recover password</a>--%>
                                    <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-primary btn-block" Text="Sign In" ToolTip="Sign In" OnClick="btnSignIn_Click"/>
								</div>
								<hr>
								<div class="m-0">
									<span class="additional-link">No account? <a href="signup.html" class="btn btn-secondary">Signup</a></span>
								</div>
							</div>
						</div>
					</div>
				</div>
    </form>
            </div>
		<!-- Container end -->
</body>
</html>
