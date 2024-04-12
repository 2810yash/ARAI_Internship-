
<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs"
    Inherits="AdminTemplate3._1._0.WebForm1" %>
    <asp:Content ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet"
            href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
        <!-- Font Awesome -->
        <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css">
        <!-- daterange picker -->
        <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css">
        <!-- iCheck for checkboxes and radio inputs -->
        <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css">
        <!-- Bootstrap Color Picker -->
        <link rel="stylesheet" href="plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css">
        <!-- Tempusdominus Bootstrap 4 -->
        <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
        <!-- Select2 -->
        <link rel="stylesheet" href="plugins/select2/css/select2.min.css">
        <link rel="stylesheet" href="plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css">
        <!-- Bootstrap4 Duallistbox -->
        <link rel="stylesheet" href="plugins/bootstrap4-duallistbox/bootstrap-duallistbox.min.css">
        <!-- BS Stepper -->
        <link rel="stylesheet" href="plugins/bs-stepper/css/bs-stepper.min.css">
        <!-- dropzonejs -->
        <link rel="stylesheet" href="plugins/dropzone/min/dropzone.min.css">
        <!-- Theme style -->
        <link rel="stylesheet" href="dist/css/adminlte.min.css">
        <link rel="stylesheet" href="./Styles/accident.css" />
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="content-wrapper position-relative main">
<div class="position-relative form">
        <div class="heading"><h1>Accident/Incident</h1></div>
        <div class="datentime">
            <div class="inputBox">
            <asp:TextBox TextMode="Date" CssClass="date-input" runat="server" ID="date_of_issue" required="required"></asp:TextBox>
            <span>Date of Issue</span>
            </div>
            <div class="inputBox">
            <asp:TextBox TextMode="Time" CssClass="date-input" runat="server" ID="time_of_issue" required="required"></asp:TextBox>
            <span>Time of Issue</span>
            </div>
        </div>
        
    <div class="datentime">
        <div class="inputBox">
        <asp:TextBox CssClass="date-input" ID="nature_of_incident" runat="server" required="required"></asp:TextBox>
        <span>Nature of Incident</span>
    </div>
    <div class="inputBox">
        <select> <option value="" disabled selected style="display:none;"></option> <option>option1</option> <option>option2</option> </select>
        <span>Incident Category</span>
    </div>
    </div>
    <div class="datentime">
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" ID="root_cause" required="required" runat="server"></asp:TextBox>
            <span>Root Cause</span>
        </div>
    </div>
    <div class="datentime">
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" ID="mitigation" required="required" runat="server"></asp:TextBox>
            <span>Mitigation</span>
        </div>
    </div>
    <div class="datentime">
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" ID="root_cause_analysis" required="required" runat="server"></asp:TextBox>
            <span>Root Cause Analysis</span>
        </div>
    </div>

    <div class="datentime">
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" runat="server" required="required" ID="corrective_action_plan"></asp:TextBox>
            <span>Corrective Action Plan</span>
        </div>
    </div>
    <div class="datentime">
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" TextMode="Date" ID="completion_date" required="required" runat="server"></asp:TextBox>
            <span>Completion Date</span>
            </div>
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" required="required" runat="server" ID="responsibility"></asp:TextBox>
            <span>Responsibility</span>
        </div>
    </div>
    <div class="radioinput">
         <div class="radio">
             <div class="hazard-study">Hazard Study<br />Updated?</div>
        <div>
            <input type="radio" id="yes" name="option">
            <label for="yes">Yes</label>
            <input type="radio" id="no" name="option">
            <label for="no">No</label>
        </div>
             <div class="file">
            <input type="file" />
    </div>
    </div>
    </div>
     <div class="datentime">
        <div class="inputBox">
            <asp:TextBox CssClass="date-input" required="required" runat="server" ID="remarks"></asp:TextBox>
            <span>Remarks(If Any)</span>
        </div>
    </div>

    <div class="subbtn"> <asp:Button OnClick="submitForm" Text="SUBMIT" CssClass="submit btn btn-primary" runat="server" /> </div>

</div>
</div>
</asp:Content>

