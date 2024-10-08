﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="viewReport.aspx.cs" Inherits="AdminTemplate3._1._0.viewReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <div id="detailsContainer" class="d-none"></div>
                    <div>
                        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                            <ItemTemplate>
                                <div class="card repeater-item">
                                    <div class="card-header">
                                        Permit Number: 
                                        <asp:Label runat="server" ID="permitNUM" Text='<%# Eval("incident_id") %>'></asp:Label>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title">Name of Supervisor: 
                                            <asp:Label runat="server" ID="contractorName" Text='<%# Eval("date_of_incident") %>'></asp:Label>
                                        </h5>
                                        <p class="card-text">
                                            Date of Issue: 
                                             <asp:Label runat="server" ID="dateIssue" Text='<%# Eval("name_of_affected_person") %>'></asp:Label><br />
                                            Permit Valid From: 
                                            <asp:Label runat="server" ID="validFrom" Text='<%# Eval("location_of_incident") %>'></asp:Label>
                                        </p>
                                        <asp:Button ID="viewPermit" runat="server" CssClass="btn btn-primary" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("incident_id") %>' OnCommand="ViewPermit_Click" />
<%--                                        <asp:Button ID="deletePemit" runat="server" CssClass="btn btn-danger" Text="Delete Permit" CommandName="DeleteDetails" CommandArgument='<%# Eval("PermitNumber") %>' OnCommand="deleteViewPermit_Click" OnClientClick="return confirmDelete();" />--%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:strconn %>" SelectCommand="SELECT [incident_id], [date_of_incident], [name_of_affected_person], [location_of_incident] FROM [accident_incident]"></asp:SqlDataSource>
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
                        <h3>Incident Details</h3>
                        <h6 style="color:gray;"><b>Location of Incident: </b>${details.location_of_incident}</h6>
                        <h6 style="color:gray;"><b>Date of Incident: </b>${details.date_of_incident}</h6>
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <strong>Permit Number:</strong> ${details.incident_id}
                        </h5>
                        <p class="card-text d-block">
                            <table style="width: 100%;">
                                <tr>
                                    <td><p><strong>Time of Incident:</strong> ${details.time_of_incident}</p></td>
                                    <td><p><strong>Nature of Incident:</strong> ${details.nature_of_incident}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Name of Affected Person:</strong> ${details.name_of_affected_person}</p></td>
                                    <td><p><strong>Name of Department:</strong> ${details.name_of_department}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Type of Incident:</strong> ${details.drop_down_1}</p></td>
                                    <td><p><strong>ESI/Insurance Validity:</strong> ${details.drop_down_2}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Name of Vendor or Contractor Firm/Agency:</strong> ${details.drop_down_3}</p></td>
                                    <td><p><strong>Number of workers:</strong> ${details.drop_down_4}</p></td>
                                </tr>
                                
                                <tr>
                                    <td><p><strong>Name of Vendor/Contractor Supervisor:</strong> ${details.drop_down_5}</p></td>
                                    <td><p><strong>Contact Number (Contractor):</strong> ${details.drop_down_6}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Description of Incident:</strong> ${details.describe_incident}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>What Immediate Action is Taken:</strong> ${details.immediate_action}</p></td>
                                    <td><p><strong>Hazard Study Updated(Yes/No):</strong> ${details.hazard_study}</p></td>
                                </tr>
                                <tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.FName}</p></td>
                                    <td><p><strong>:</strong> ${details.FExtension}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.FilePath}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.created_date}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.remakrs}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.IPAddress}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.root_cause_1}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.root_cause_2}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.root_cause_3}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.root_cause_4}</p></td>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.root_cause_5}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.corrective_action_1}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.corective_action_2}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.corrective_action_3}</p></td>
                                    
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.responsible_person_1}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.responsible_person_2}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.responsible_person_3}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.date_of_completion_1}</p></td>
                                    <td><p><strong>Location of Work:</strong> ${details.date_of_completion_2}</p></td>
                                </tr>
<tr>
                                    <td><p><strong>Brief Description of Work:</strong> ${details.date_of_completion_3}</p></td>
                                   
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