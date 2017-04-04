<%@ Page Title="Attendance Details" Language="C#" MasterPageFile="~/Admin/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="SKF.Admin.Attendance" %>
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
                    <a href="dashboard.php">
                        <i class="fa fa-fw ti-home"></i>Dashboard
                    </a>
                </li>
                <li>
                    <a href="Staff.aspx">Staff</a>
                </li>
                <li class="active">Add New Designation
                </li>
            </ol>
        </section>
        <!--section ends-->
        <section class="content">
            <!--main content-->
            <div class="row">
                <div class="col-md-10">
                    <div class="panel  form-horizontal">
                        <div class="panel-heading">
                            <h3 class="panel-title">
                                <i class="fa fa-fw ti-star"></i>Designation Details
                            </h3>
                            <span class="pull-right">
                                <i class="fa fa-fw ti-angle-up clickable"></i>
                                <i class="fa fa-fw ti-close removepanel clickable"></i>
                            </span>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    Student Name
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="DropStuName" class="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-4 control-label" for="val-username">
                                    Class Name
                                                <span class="text-danger">*</span>
                                </label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="DropClassName" class="form-control" runat="server"></asp:DropDownList>
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

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel filterable">
                        <div class="panel-heading clearfix">
                            <div class="panel-title pull-left">
                                <i class="ti-export"></i><b> List of Designations</b>
                            </div>
                            <div class="tools pull-right"></div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped" id="table1">
                                    <thead>
                                        <tr>
                                            <th>Sr. No</th>
                                            <th>Name</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="Lst_Designation" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.DataItemIndex + 1 %></td>
                                                    <td><%# Eval("class_name") %></td>
                                                    <td><%# Eval("stu_name") %></td>
                                                    <td>
                                                        <p>
                                                            <asp:LinkButton ID="lnkEdit" class="btn btn-primary btn-xs" OnClick="lnkEdit_Click" CommandArgument='<%# Eval("attedance_id") %>' runat="server"><span
                                                                    class="fa fa-fw ti-pencil"></span></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p>
                                                            <asp:LinkButton ID="lnkDelete" OnClientClick="return(confirm('Are you sure you want to delete this record?'))" OnClick="lnkDelete_Click" CommandArgument='<%# Eval("attedance_id") %>' class="btn btn-danger btn-xs" runat="server"><span
                                                                    class="fa fa-fw ti-trash"></span></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="background-overlay"></div>
        </section>
    </aside>
</asp:Content>
