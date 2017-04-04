<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="SKF.Admin.Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <aside class="right-side">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>SKF
            </h1>
            <ol class="breadcrumb">
                <li>
                    <a href="Dashboard.aspx">
                        <i class="fa fa-fw ti-home"></i>Dashboard
                    </a>
                </li>
                <li class="active">Schools
                </li>
            </ol>
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel filterable">
                        <div class="panel-heading clearfix">
                            <div class="panel-title pull-left">
                                <i class="ti-export"></i><b> List of Staff - <a href="Add_Staff.aspx">Add New</a> </b>
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
                                            <th>Email</th>
                                            <th>Phone</th>
                                            <th>Zip</th>
                                            <th>School Name</th>
                                            <th>User Type</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="Lst_Staff" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.DataItemIndex + 1 %></td>
                                                    <td><%# Eval("staff_name") %></td>
                                                    <td><%# Eval("staff_email") %></td>
                                                    <td><%# Eval("staff_phone") %></td>
                                                    <td><%# Eval("staff_zip") %></td>
                                                    <td><%# Eval("school_name") %></td>
                                                    <td><%# Eval("staff_usertype") %></td>
                                                    <td>
                                                        <p>
                                                            <asp:LinkButton ID="lnkEdit" class="btn btn-primary btn-xs" OnClick="lnkEdit_Click" CommandArgument='<%# Eval("staff_id") %>' runat="server"><span
                                                                    class="fa fa-fw ti-pencil"></span></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p>
                                                            <asp:LinkButton ID="lnkDelete" OnClientClick="return(confirm('Are you sure you want to delete this record?'))" OnClick="lnkDelete_Click" CommandArgument='<%# Eval("staff_id") %>' class="btn btn-danger btn-xs" runat="server"><span
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
