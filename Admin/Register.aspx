<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SKF.Admin.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::Admin Register::</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link rel="shortcut icon" href="Styles/img/favicon.ico" />
    <!-- global css -->
    <link href="Styles/css/app.css" rel="stylesheet"/>
    <!-- end of global css -->
    <!--page level css -->
    <link type="text/css" href="Styles/vendors/themify/css/themify-icons.css" rel="stylesheet" />
    <link href="Styles/vendors/iCheck/css/all.css" rel="stylesheet"/>
    <link href="Styles/vendors/bootstrapvalidator/css/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="Styles/css/login.css" rel="stylesheet"/>
    <!--end of page level css-->
</head>
<body id="sign-up">
    <form id="form1" runat="server">
        <div class="preloader">
            <div class="loader_img">
                <img src="Styles/img/loader.gif" alt="loading..." height="64" width="64"></div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1 login-form">
                    <div class="panel-header">
                        <h2 class="text-center">
                            <img src="Styles/img/pages/clear_black.png" alt="Logo">
                        </h2>
                    </div>
                    <div class="panel-body">
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="first" class="sr-only">First Name</label>
                                    <asp:TextBox ID="txtFname" class="form-control  form-control-lg" placeholder="First name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="last" class="sr-only">Last Name</label>
                                    <asp:TextBox ID="txtLname" placeholder="Last name" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="email" class="sr-only">E-mail</label>
                                    <asp:TextBox ID="txtEmail" placeholder="E-mail" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-12">
                                <div class="form-group">
                                    <label for="email" class="sr-only">Phone</label>
                                    <asp:TextBox ID="txtPhone" placeholder="Phone" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-12">
                                <div class="form-group">
                                    <label for="email" class="sr-only">Zip</label>
                                    <asp:TextBox ID="txtZip" placeholder="Zip" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="email" class="sr-only">City</label>
                                    <asp:TextBox ID="TextBox1" placeholder="City" ReadOnly="true" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="email" class="sr-only">State</label>
                                    <asp:TextBox ID="TextBox2" placeholder="State" ReadOnly="true" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="email" class="sr-only">Country</label>
                                    <asp:TextBox ID="TextBox3" placeholder="Country" ReadOnly="true" class="form-control  form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="password" class="sr-only">Password</label>
                                    <asp:TextBox ID="txtPassword" placeholder="Password" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="confirm-password" class="sr-only">Password</label>
                                    <asp:TextBox ID="txtConfirmPassword" placeholder="Conform Password" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="confirm-password" class="sr-only">User Type</label>
                                    <asp:DropDownList ID="DropUserType" class="form-control form-control-lg" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group checkbox">
                                    <label for="terms">
                                        <input type="checkbox" name="terms" id="terms">&nbsp; I accept the <a href="javascript:void(0)">terms &amp; Conditions</a>
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button ID="btnRegister" class="btn btn-primary btn-block" OnClick="btnRegister_Click" runat="server" Text="Sign Up" />
                                </div>
                                <span class="sign-in">Already a member? <a href="Login.aspx">Sign In</a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- global js -->
        <script src="Styles/js/jquery.min.js" type="text/javascript"></script>
        <script src="Styles/js/bootstrap.min.js" type="text/javascript"></script>
        <!-- end of global js -->
        <!-- begining of page level js -->
        <script src="Styles/vendors/moment/js/moment.min.js"></script>
        <script src="Styles/vendors/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
        <script src="Styles/vendors/select2/js/select2.js"></script>
        <script src="Styles/vendors/iCheck/js/icheck.js"></script>
        <script src="Styles/vendors/bootstrapvalidator/js/bootstrapValidator.min.js" type="text/javascript"></script>
        <script src="Styles/js/custom_js/register.js"></script>
        <!-- end of page level js -->
    </form>
</body>
</html>
