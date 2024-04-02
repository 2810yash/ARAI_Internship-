<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs"
    Inherits="AdminTemplate3._1._0.Welcome" %>
    <asp:Content ContentPlaceHolderID="head" runat="server">
        <!-- Google Font: Source Sans Pro -->
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

    </asp:Content>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper position-relative">
            <!-- Content Header (Page header) -->
            <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-6">
                            <h1 class="m-0">WorkPermit</h1>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item text-decoration-none"><a href="../Homepage.aspx">Home</a></li>
                                <li class="breadcrumb-item active">WorkPermit</li>
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

                    <div data-aos="slide-up">
                        <%-- Blinking TEXT --%>
                        <div class="headline text-align-center">
                            <h6 class="blink-text text-align-center m-1">Security shall check work permit and allow
                                workers to enter with valid work permit in case of below mentioned works</h6>
                            <h6 class="blink-text text-align-center m-1">Work permit to be filled by contractor in
                                consultation with ARAI officials (of work intending dept.)</h6>
                            <h6 class="blink-text text-align-center m-1">Work on Saturday/Sunday & holidays will be
                                under strict supervision of work intending departments</h6>
                        </div>
                        <div>
                            <%-- Site Name--%>
                            <div class="card-header justify-content-between">
                                <label>Site: </label>
                                <asp:DropDownList ID="site" CssClass="form-control select2" runat="server">
                                    <asp:ListItem Text="Kothrud" Selected="false" Value="kothrud"></asp:ListItem>
                                    <asp:ListItem Text="Chakan" Value="chakan"></asp:ListItem>
                                    <asp:ListItem Text="HTC-Chakan" Value="htc-chakan"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <%-- Permit Form--%>
                            <div class="position-relative" id="expand">
                                <nav id="navbar-example2" class="navbar navbar-light bg-light px-3">
                                    <ul class="nav nav-pills">
                                        <li class="nav-item">
                                            <a class="nav-link" href="#page1">Details</a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" href="#page2">Job Safety Assessment</a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" href="#page3">Workers Info</a>
                                        </li>
                                    </ul>
                                </nav>

                                <div class="bg-light rounded" id="Pages">

                                    <div class="page1" id="page1">
                                        <div class="bg-light">
                                            <div class="d-flex mb-3 mt-3">
                                                <div class="input-group me-2">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="permitNo0">Permit No:</span>
                                                    <asp:TextBox ID="TextBox1" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="doi0">Date of Issue:</span>
                                                    <!-- <input type="date" /> -->
                                                    <asp:TextBox ID="TextBox2" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="valid-from">Permit Valid From:</span>
                                                    <asp:TextBox ID="TextBox3" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="valid-till">Permit Valid Till:</span>
                                                    <asp:TextBox ID="TextBox4" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2 icheck-primary">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center" id="splLicense0">Special License:</span>
                                                    <asp:RadioButton ID="special_license_yes" Text="Yes" runat="server" GroupName="Special-License" />
                                                    <asp:RadioButton ID="special_license_no" Text="No" runat="server" GroupName="Special-License" />
                                                </div>
                                                <asp:DropDownList ID="spl_Licence" Height="100%" CssClass="form-select" runat="server">
                                                    <asp:ListItem Text="-- Select Special License Work --" Value="null"></asp:ListItem>
                                                    <asp:ListItem Text="Electric Contractor" Value="elec-contractor"></asp:ListItem>
                                                    <asp:ListItem Text="Height Work" Value="hgt-work"></asp:ListItem>
                                                    <asp:ListItem Text="Crane Operator" Value="crn-operator"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="esiNum0">ESI/Insurance No & Validity: </span>
                                                    <asp:TextBox ID="TextBox5" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="vendors0">Name of Vendor or Contractor Firm/Agency:</span>
                                                    <asp:TextBox ID="TextBox6" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="input-group mb-3">
                                                <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                    id="numWorkers0">Number of Workers:</span>
                                                <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:Button ID="confirm" CssClass="input-group-text btn btn-info border-1" runat="server" Text="Confirm" />
                                            </div>
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="supervisor0">Name of Vendor/Contractor Supervisor: </span>
                                                    <asp:TextBox ID="TextBox8" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="supervisorContact0">Contact Number:</span>
                                                    <asp:TextBox ID="TextBox9" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <label class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        for="araiEng">ARAI Engineer: </label>
                                                    <asp:DropDownList ID="araiEng" Height="100%" CssClass="form-select" runat="server"></asp:DropDownList>
                                                </div>
                                                <div class="input-group">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="araiEngContact0">Contact Number:</span>
                                                    <asp:TextBox ID="TextBox10" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="desc0">Brief Description of Work:</span>
                                                    <asp:TextBox ID="TextBox11" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="location0">Location of Work:</span>
                                                    <asp:TextBox ID="TextBox12" Height="100%" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div id="page2" class="page2 p-4">
                                        <div class="d-flex">
                                            <div  id="checkboxContainer"  class="cont-1" style="width:30%;">
                                                <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Work Permit</label>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox1" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Entry into vessel/Tanks/Manholes/A.C. Ducts/Cooling Towers/Confined Spaces" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox2" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Civil Work (Painting, Construction, Excavation etc)" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox3" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Hot Works (Welding/Gas Cutting)" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox4" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Work on Fragile Roof" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox5" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="High Tension Electrical Work" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox6" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Low Tension Electrical Work" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox7" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Working on height (more than 3 meters)" />
                                                </div>
                                                <div class="checkbox-container">
                                                    <asp:CheckBox class="text-wrap" ID="CheckBox8" CssClass="text-wrap" runat="server" OnCheckedChanged="CheckBox_CheckedChanged" Text="Others (Mobile crane operations, loading and unloading of gas cylinder, unloading of liquid nitrogen)" />
                                                </div>
                                            </div>
                                            <div class="cont-2">
                                                <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Precautions taken</label>
                                                <div id="listContainer" class="input-group border-1 border-dark mb-1">
                                                    <ul>
                                                        <li>Work to be carried out by trained manpower</li>
                                                        <li>Provide safe means of access</li>
                                                        <li>Strict supervision required</li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="cont-3">
                                                <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Personal Precautionary Equipment</label>
                                                <div id="listContainer2" class="input-group border-1 border-dark mb-1">
                                                    <ul>
                                                        <li>Portable ladders</li>
                                                        <li>Safety Goggles and kit</li>
                                                        <li>Helmet</li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                        
                                    </div>

                                    <div id="page3" class="page-3 p-4">

                                        <div id="workers">
                                        </div>
                                        <div class="d-flex justify-content-between mt-3 mb-2">
                                            <button type="reset" class="btn btn-outline-secondary align-self-end invisible"
                                                onclick="clearFields('workDetails')">
                                                Back
                                            </button>
                                            <asp:Button ID="submit" CssClass="btn btn-success align-self-end" runat="server" Text="Submit" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </section>

        </div>
        <!-- /.content-wrapper -->

    </asp:Content>