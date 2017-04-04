<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Master.Master" AutoEventWireup="true" CodeBehind="Login_Type.aspx.cs" Inherits="SKF.Admin.Login_Type" %>
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
                                <i class="ti-export"></i><b>List of Schools - <a href="#">Add New</a> </b>
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
                                            <th>Info</th>
                                            <th>Type</th>
                                            <th>Price</th>
                                            <th>Edit</th>
                                            <th>Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Demetrius</td>
                                            <td>Cole</td>
                                            <td>Demetrius.Cole@yahoo.com</td>
                                            <td>Credit Card Account</td>
                                            <td></td>
                                            <td>
                                                <p>
                                                    <button class="btn btn-primary btn-xs" data-toggle="modal"
                                                        data-target="#edit" data-placement="top">
                                                        <span
                                                            class="fa fa-fw ti-pencil"></span>
                                                    </button>
                                                </p>
                                            </td>
                                            <td>
                                                <p>
                                                    <button class="btn btn-danger btn-xs" data-toggle="modal"
                                                        data-target="#delete" data-placement="top">
                                                        <span
                                                            class="fa fa-fw ti-trash"></span>
                                                    </button>
                                                </p>
                                            </td>
                                        </tr>

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
