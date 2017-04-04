<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Pass.aspx.cs" Inherits="SKF.Admin.Forgot_Pass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password | Clear Admin Template</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="Styles/img/favicon.ico" />
    <!-- Bootstrap -->
    <!-- global level css -->
    <link href="Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/vendors/themify/css/themify-icons.css" rel="stylesheet" type="text/css" />
    <!-- end of global css-->
    <!-- page level styles-->
    <link href="Styles/vendors/bootstrapvalidator/css/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="Styles/css/forgot_password.css" rel="stylesheet">
    <!-- end of page level styles-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="preloader">
            <div class="loader_img">
                <img src="Styles/img/loader.gif" alt="loading..." height="64" width="64"/></div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1 box animated fadeInUp">
                    <div class="text-center">
                        <img src="Styles/img/logo.png" alt="Clear logo"/></div>
                    <h3 class="text-center">Forgot Password
                    </h3>
                    <p class="text-center enter_email">
                        Enter your Registered email
                    </p>
                    <p class="text-center check_email hidden">
                        Check your email for Reset link
                <br>
                        <br>
                        <u><a href="javascript:void(0)" class="reset-link">Resend the link</a></u>
                    </p>
                    <div class="form-group">
                        <asp:TextBox ID="txtEmail" class="form-control email" placeholder="Email" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnForgotPass" OnClick="btnForgotPass_Click" runat="server" class="btn submit-btn" Text="Retrieve Password" />
                </div>
            </div>
        </div>
        <!-- page level js -->
        <script src="Styles/js/jquery.min.js" type="text/javascript"></script>
        <script src="Styles/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="Styles/vendors/bootstrapvalidator/js/bootstrapValidator.min.js" type="text/javascript"></script>
        <script src="Styles/js/custom_js/forgot_password.js" type="text/javascript"></script>
        <!-- end of page level js -->
    </form>
</body>
</html>
