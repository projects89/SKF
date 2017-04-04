<%@ Page Title="Staff Details" Language="C#" MasterPageFile="~/Admin/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Add_Staff.aspx.cs" Inherits="SKF.Admin.Add_Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <aside class="right-side">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <!--section starts-->
            <h1>SKF
            </h1>
            <ol class="breadcrumb">
                <li>
                    <a href="Dashboard.aspx">
                        <i class="fa fa-fw ti-home"></i>Dashboard
                    </a>
                </li>
                <li>
                    <a href="Schools.aspx">Schools</a>
                </li>
                <li class="active">Add New Staff
                </li>
            </ol>
        </section>
        <!--section ends-->
        <section class="content">
            <!--main content-->
            <div class="row">
                <div class="col-md-10">
                    <div class="panel form-horizontal">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <i class="fa fa-fw ti-star"></i>Staff Details
                            </h3>
                            <span class="pull-right">
                                <i class="fa fa-fw ti-angle-up clickable"></i>
                                <i class="fa fa-fw ti-close removepanel clickable"></i>
                            </span>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    School Name
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="DropSchooName" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="email">
                                    User Type
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="DropUser_Type" class="form-control" runat="server">
                                        <asp:ListItem Value ="0">--Select--</asp:ListItem>
                                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                        <asp:ListItem Value="Staff">Staff</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    Name
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtStaffName" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    Email
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtStaffEmail" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    Phone
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtStaffPhone" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>


                           <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    Zip
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtStaffZip" class="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-8 col-md-offset-4">
                                    <label class="padding7" for="terms">
                                        <input type="checkbox" class="custom_icheck" id="terms" name="terms"
                                            value="1">&nbsp;&nbsp;I agree to
                                                    <a href="#modal-terms" data-toggle="modal">Terms &amp; Conditions
                                                    </a>
                                    </label>
                                </div>
                            </div>
                            <div class="form-group form-actions">
                                <div class="col-md-8 col-md-offset-4">
                                    <asp:Button ID="btnSubmit" class="btn btn-effect-ripple btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Submit" />
                                    <asp:Button ID="btnReset" class="btn btn-effect-ripple btn-default reset_btn" runat="server" Text="Reset" />
                                </div>
                            </div>

                            <div id="modal-terms" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h3 class="modal-title text-center">
                                                <strong>Terms and Conditions
                                                </strong>
                                            </h3>
                                        </div>
                                        <div class="modal-body">
                                            <h4 class="page-header">1.
                                                        <strong>General</strong>
                                            </h4>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas
                                                        ultrices, justo vel imperdiet gravida, urna ligula hendrerit nibh, ac
                                                        cursus nibh sapien in purus. Mauris tincidunt tincidunt turpis in porta.
                                                        Integer fermentum tincidunt auctor.
                                            </p>
                                            <h4 class="page-header">2.
                                                        <strong>Account</strong>
                                            </h4>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas
                                                        ultrices, justo vel imperdiet gravida, urna ligula hendrerit nibh, ac
                                                        cursus nibh sapien in purus. Mauris tincidunt tincidunt turpis in porta.
                                                        Integer fermentum tincidunt auctor.
                                            </p>
                                            <h4 class="page-header">3.
                                                        <strong>Service</strong>
                                            </h4>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas
                                                        ultrices, justo vel imperdiet gravida, urna ligula hendrerit nibh, ac
                                                        cursus nibh sapien in purus. Mauris tincidunt tincidunt turpis in porta.
                                                        Integer fermentum tincidunt auctor.
                                            </p>
                                            <h4 class="page-header">4.
                                                        <strong>Payments</strong>
                                            </h4>
                                            <p>
                                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas
                                                        ultrices, justo vel imperdiet gravida, urna ligula hendrerit nibh, ac
                                                        cursus nibh sapien in purus. Mauris tincidunt tincidunt turpis in porta.
                                                        Integer fermentum tincidunt auctor.
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <div class="text-center">
                                                <button type="button" class="btn btn-effect-ripple btn-primary"
                                                    data-dismiss="modal">
                                                    I've read them!
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="background-overlay"></div>
        </section>
        <!-- /.content -->
    </aside>
</asp:Content>
