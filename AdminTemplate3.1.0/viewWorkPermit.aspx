<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="viewWorkPermit.aspx.cs" Inherits="AdminTemplate3._1._0.viewWorkPermit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Google Font -->
    <link rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper position-relative">
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6 mt-5">
                        <h1 class="m-0">View WorkPermit</h1>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item text-decoration-none"><a href="../Homepage.aspx">Home</a></li>
                            <li class="breadcrumb-item active">View WorkPermit</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->
        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <%-- Page started here--%>

                <div>
                    <asp:DataList ID="DataList1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyField="PermitNumber" DataSourceID="demoPermitList" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" GridLines="Horizontal" HorizontalAlign="Justify" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <ItemTemplate>
                            PermitNumber:
                        <asp:Label ID="PermitNumberLabel" runat="server" Text='<%# Eval("PermitNumber") %>' />
                            <br />
                            NameofSupervisor:
                        <asp:Label ID="NameofSupervisorLabel" runat="server" Text='<%# Eval("NameofSupervisor") %>' />
                            <br />
                            DateofIssue:
                        <asp:Label ID="DateofIssueLabel" runat="server" Text='<%# Eval("DateofIssue") %>' />
                            <br />
                            PermitValidFrom:
                        <asp:Label ID="PermitValidFromLabel" runat="server" Text='<%# Eval("PermitValidFrom") %>' />
                            <br />
                            <br />
                            <asp:Button ID="viewBTN" CssClass="btn btn-secondary align-self-end" runat="server" Text="View More" />
                            <hr />
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    </asp:DataList>

                    <asp:SqlDataSource ID="demoPermitList" runat="server" ConnectionString="<%$ ConnectionStrings:DemoConnectionString %>" SelectCommand="SELECT [PermitNumber], [NameofSupervisor], [DateofIssue], [PermitValidFrom] FROM [permit_details_tbl]"></asp:SqlDataSource>
                </div>

            </div>
        </section>
    </div>
</asp:Content>