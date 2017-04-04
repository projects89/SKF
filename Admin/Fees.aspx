<%@ Page Title="Fees List" Language="C#" MasterPageFile="~/Admin/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Fees.aspx.cs" Inherits="SKF.Admin.Fees" %>
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
                <li class="active">Fees
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
                                <i class="ti-export"></i><b> List of Paid - <a href="Add_Students.aspx">Add New</a> </b>
                            </div>
                            <div class="tools pull-right"></div>
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped" id="table1">
                                    <thead>
                                        <tr>
                                            <th>Sr. No</th>
                                            <th>Student Name</th>
                                            <th>Fee Type</th>
                                            <th>Amount</th>
                                            <th>Date</th>
                                            <th>Receiver Name</th>
                                            <th>Schoo Name</th>
                                            <th>Status</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="Lst_Student" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.DataItemIndex + 1 %></td>
                                                    <td><%# Eval("stu_name") %></td>
                                                    <td><%# Eval("bill_type_name") %></td>
                                                    <td><%# Eval("bill_fees") %></td>
                                                    <td><%# Eval("bill_datetime") %></td>
                                                    <td><%# Eval("bill_receiver_id") %></td>
                                                    <td><%# Eval("school_name") %></td>
                                                    <td><%# Eval("bill_paid") %></td>
                                                    <td>
                                                        <p>
                                                            <asp:LinkButton ID="lnkEdit" class="btn btn-primary btn-xs" OnClick="lnkEdit_Click" CommandArgument='<%# Eval("bill_id") %>' runat="server"><span
                                                                    class="fa fa-fw ti-pencil"></span></asp:LinkButton>
                                                        </p>
                                                    </td>
                                                    <td>
                                                        <p>
                                                            <asp:LinkButton ID="lnkDelete" OnClientClick="return(confirm('Are you sure you want to delete this record?'))" OnClick="lnkDelete_Click" CommandArgument='<%# Eval("bill_id") %>' class="btn btn-danger btn-xs" runat="server"><span
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
