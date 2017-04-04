<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPages/Master.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SKF.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <aside class="right-side">

        <section class="content-header">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-5 col-xs-8">
                    <div class="header-element">
                        <h3>Clear/
                            <small>Dashboard</small>
                        </h3>
                    </div>
                </div>
                <div class="col-lg-4 col-lg-offset-2 col-md-6 col-sm-7 col-xs-4">
                    <div class="header-object">
                        <span class="option-search pull-right hidden-xs">
                            <span class="search-wrapper">
                                <input type="text" placeholder="Search here"><i class="ti-search"></i>
                            </span>
                        </span>
                    </div>
                </div>
            </div>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="flip">
                        <div class="widget-bg-color-icon card-box front">
                            <div class="bg-icon pull-left">
                                <i class="ti-eye text-warning"></i>
                            </div>
                            <div class="text-right">
                                <h3 class="text-dark"><b>3752</b></h3>
                                <p>Daily Visits</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="widget-bg-color-icon card-box back">
                            <div class="text-center">
                                <span id="loadspark-chart"></span>
                                <hr>
                                <p>Check summary</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="flip">
                        <div class="widget-bg-color-icon card-box front">
                            <div class="bg-icon pull-left">
                                <i class="ti-shopping-cart text-success"></i>
                            </div>
                            <div class="text-right">
                                <h3><b id="widget_count3">3251</b></h3>
                                <p>Sales status</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="widget-bg-color-icon card-box back">
                            <div class="text-center">
                                <span class="linechart" id="salesspark-chart"></span>
                                <hr>
                                <p>Check summary</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="flip">
                        <div class="widget-bg-color-icon card-box front">
                            <div class="bg-icon pull-left">
                                <i class="ti-thumb-up text-danger"></i>
                            </div>
                            <div class="text-right">
                                <h3 class="text-dark"><b>1532</b></h3>
                                <p>Hits</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="widget-bg-color-icon card-box back">
                            <div class="text-center">
                                <span id="visitsspark-chart"></span>
                                <hr>
                                <p>Check summary</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-3">
                    <div class="flip">
                        <div class="widget-bg-color-icon card-box front">
                            <div class="bg-icon pull-left">
                                <i class="ti-user text-info"></i>
                            </div>
                            <div class="text-right">
                                <h3 class="text-dark"><b>1252</b></h3>
                                <p>Subscribers</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="widget-bg-color-icon card-box back">
                            <div class="text-center">
                                <span id="subscribers-chart"></span>
                                <hr>
                                <p>Check summary</p>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="background-overlay"></div>
        </section>
        <!-- /.content -->
    </aside>
</asp:Content>
