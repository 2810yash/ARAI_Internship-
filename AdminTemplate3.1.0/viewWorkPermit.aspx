<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="viewWorkPermit.aspx.cs" Inherits="AdminTemplate3._1._0.viewWorkPermit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
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
                    <div>
                        <input type="text" placeholder="Search here..." id="txtSearch" class="form-control m-1 float-end" style="width:30%;" onkeyup="searchFun()" />
                    </div>
                    <br />
                    <br />
                    <div>
                        <asp:Repeater ID="reptCard" runat="server">
                            <ItemTemplate>
                                <div class="card repeater-item">
                                    <div class="card-header">
                                        Permit Number: 
                                        <asp:Label runat="server" ID="permitNUM" Text='<%# Eval("PermitNumber") %>'></asp:Label>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Name of Supervisor: 
                                            <asp:Label runat="server" ID="contractorName" Text='<%# Eval("NameofSupervisor") %>'></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            Date of Issue: 
                                            <asp:Label runat="server" ID="dateIssue" Text='<%# Eval("DateofIssue") %>'></asp:Label><br />
                                            Permit Valid From: 
                                            <asp:Label runat="server" ID="validFrom" Text='<%# Eval("PermitValidFrom") %>'></asp:Label>
                                        </p>
                                        <asp:Button ID="viewPermit" runat="server" Text="View details" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
    </div>

    <script>
        function searchFun() {
            const filter = document.getElementById('txtSearch').value.toUpperCase();
            const repeaterItems = document.getElementsByClassName('repeater-item');
            for (let i = 0; i < repeaterItems.length; i++) {
                const permitNum = repeaterItems[i].querySelector('#permitNUM').innerText.toUpperCase();
                const supervisorName = repeaterItems[i].querySelector('#contractorName').innerText.toUpperCase();
                if (permitNum.includes(filter) || supervisorName.includes(filter)) {
                    repeaterItems[i].style.display = "";
                } else {
                    repeaterItems[i].style.display = "none";
                }
            }
        }
    </script>
</asp:Content>
