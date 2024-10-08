﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="viewWorkPermit.aspx.cs" Inherits="AdminTemplate3._1._0.viewWorkPermit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <!-- jQuery UI CSS (CDN) -->
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <!-- AOS CSS (CDN) -->
    <link rel="stylesheet" href="https://cdn.rawgit.com/michalsnik/aos/2.1.1/dist/aos.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper position-relative">
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2 mt-5">
                    <div class="col-sm-6">
                        <h1 class="m-0">View Work Permit</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item text-decoration-none"><a href="../Homepage.aspx">Home</a></li>
                            <li class="breadcrumb-item active">View Work Permit</li>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
        <section class="content">
            <div class="container-fluid">
                <div>
                    <div>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-secondary m-1 float-end" OnClick="btnSearch_Click" />
                        <%--<asp:DropDownList ID="agencyNames" runat="server" CssClass="form-control m-1 float-end" style="width:30%;"></asp:DropDownList>--%>
                        <input type="text" placeholder="Search here..." id="txtSearch" runat="server" class="form-control m-1 float-end" style="width:30%;" />
                    </div>
                    <br />
                    <br />
                    <div id="detailsContainer" class="d-none">
                        <!-- GridView for displaying worker details -->
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="NameOfWorkers" HeaderText="Name Of Workers" SortExpression="NameOfWorkers" />
                                <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                                <asp:CheckBoxField DataField="Mask" HeaderText="Mask" SortExpression="Mask" />
                                <asp:CheckBoxField DataField="SafetyShoesGumBoots" HeaderText="Safety Shoes/Gum Boots" SortExpression="SafetyShoesGumBoots" />
                                <asp:CheckBoxField DataField="JacketsAprons" HeaderText="Jackets/Aprons" SortExpression="JacketsAprons" />
                                <asp:CheckBoxField DataField="Gloves" HeaderText="Gloves" SortExpression="Gloves" />
                                <asp:CheckBoxField DataField="EarPlugMuffs" HeaderText="Ear Plug/Muffs" SortExpression="EarPlugMuffs" />
                                <asp:CheckBoxField DataField="BeltHarness" HeaderText="Belt/Harness" SortExpression="BeltHarness" />
                                <asp:CheckBoxField DataField="Helmet" HeaderText="Helmet" SortExpression="Helmet" />
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                            </Columns>
                        </asp:GridView>
                    </div>
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
                                            <asp:Label runat="server" ID="contractorName" Text='<%# Eval("NameofFirm_Agency") %>'></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            Date of Issue: 
                                             <asp:Label runat="server" ID="dateIssue" Text='<%# Eval("DateofIssue") %>'></asp:Label><br />
                                            Permit Valid From: 
                                            <asp:Label runat="server" ID="validFrom" Text='<%# Eval("PermitValidFrom") %>'></asp:Label>
                                        </p>
                                        <asp:Button ID="viewPermit" runat="server" CssClass="btn btn-primary" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("PermitNumber") %>' OnCommand="ViewPermit_Click" />
                                        <asp:Button ID="deletePemit" runat="server" CssClass="btn btn-danger" Text="Delete Permit" CommandName="DeleteDetails" CommandArgument='<%# Eval("PermitNumber") %>' OnCommand="deleteViewPermit_Click" OnClientClick="return confirmDelete();" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </div>
                </div>
            </div>
        </section>
    </div>

    <!-- jQuery (CDN) -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- jQuery UI (CDN) -->
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <!-- AOS JS (CDN) -->
    <script src="https://cdn.rawgit.com/michalsnik/aos/2.1.1/dist/aos.js"></script>

    <script>
        $(document).ready(function () {
            AOS.init();
        });

        function showPermitDetails(details) {
            const repeater = document.querySelector('.repeater-item').parentElement;
            const detailsContainer = document.getElementById('detailsContainer');
            const detailsBox = document.createElement('div');
            const searchBox = document.getElementById('txtSearch');
            detailsBox.style.width = '100%';

            detailsBox.innerHTML = `
                <div class="card">
                    <div class="card-header d-flex align-items-center justify-content-between">
                        <h3>Permit Details</h3>
                        <h6 style="color:gray;">${details.SiteName}</h6>
                        <h6 style="color:gray;"><b>Date of Issue: </b>${details.DateofIssue}</h6>
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <strong>Permit Number:</strong> ${details.PermitNumber}
                        </h5>
                        <p class="card-text d-block">
                            <table style="width: 100%;">
                                <tr>
                                    <td><p><strong>Permit Valid From:</strong> ${details.PermitValidFrom}</p></td>
                                    <td><p><strong>Permit Valid Till:</strong> ${details.PermitValidTill}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Special License:</strong> ${details.SpecialLicense}</p></td>
                                    <td><p><strong>Special License Type:</strong> ${details.SpecialLicenseType}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>ESI/Insurance No:</strong> ${details.InsuranceNo}</p></td>
                                    <td><p><strong>ESI/Insurance Validity:</strong> ${details.InsuranceValidity}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Name of Vendor or Contractor Firm/Agency:</strong> ${details.AgencyName}</p></td>
                                    <td><p><strong>Number of workers:</strong> ${details.WorkerNo}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Worker Details:</strong> ${details.WorkerDeatials}</p></td>
                                </tr>
                                <tr>
                                    <td colspan="2" id="workerDetailsContainer"></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Name of Vendor/Contractor Supervisor:</strong> ${details.ContractorName}</p></td>
                                    <td><p><strong>Contact Number (Contractor):</strong> ${details.ContractorNo}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>ARAI Engineer:</strong> ${details.EngineerName}</p></td>
                                    <td><p><strong>Contact Number (Engineer):</strong> ${details.EngineerNo}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.Description}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.Location}</p></td>
                                </tr>
                            </table>
                            <p><strong>WorkPermits selected:</strong> ${details.workPermits}</p>
                        </p>
                        <div class="justify-content-between">
                            <button class="btn btn-primary" onclick="hidePermitDetails()">View Less</button>
                        <div>
                    </div>
                </div>
            `;
            detailsContainer.innerHTML = '';
            detailsContainer.appendChild(detailsBox);
            detailsContainer.classList.remove('d-none');
            searchBox.style.display = 'none';
            repeater.style.display = 'none';

            __doPostBack('LoadWorkerDetails', details.PermitNumber);
        }

        function hidePermitDetails() {
            const repeater = document.querySelector('.repeater-item').parentElement;
            const detailsContainer = document.getElementById('detailsContainer');
            const searchBox = document.getElementById('txtSearch');
            detailsContainer.classList.add('d-none');
            searchBox.style.display = 'block';
            repeater.style.display = 'block';
        }

        function confirmDelete() {
            return confirm("Are you sure you want to delete this permit?");
        }
    </script>
</asp:Content>