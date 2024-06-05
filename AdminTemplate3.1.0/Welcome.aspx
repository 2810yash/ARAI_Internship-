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

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                                <li class="breadcrumb-item text-decoration-none"><a href="../Homepage.aspx">Home</a>
                                </li>
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

                        <%--<div data-aos="slide-up">--%>
                            <div>
                                <%-- Blinking TEXT --%>
                                    <div class="headline text-align-center">
                                        <h6 class="blink-text text-align-center m-1">Security shall check work permit
                                            and allow
                                            workers to enter with valid work permit in case of below mentioned works
                                        </h6>
                                        <h6 class="blink-text text-align-center m-1">Work permit to be filled by
                                            contractor in
                                            consultation with ARAI officials (of work intending dept.)</h6>
                                        <h6 class="blink-text text-align-center m-1">Work on Saturday/Sunday & holidays
                                            will be
                                            under strict supervision of work intending departments</h6>
                                    </div>
                                    <div>
                                        <%-- Site Name--%>
                                            <div class="card-header justify-content-between">
                                                <label>Site: </label>
                                                <asp:DropDownList ID="site" CssClass="form-control select"
                                                    runat="server">
                                                    <asp:ListItem Text="ARAI-Kothrud" Selected="false" Value="kothrud">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="ARAI-Chakan" Value="chakan"></asp:ListItem>
                                                    <asp:ListItem Text="ARAI-HTC-Chakan" Value="htc-chakan">
                                                    </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>

                                                <%-- Permit Form--%>
                                                    <div class="position-relative" id="expand">
                                                        <nav id="navbar-example2"
                                                            class="navbar navbar-light bg-light px-3">
                                                            <ul class="nav nav-pills">
                                                                <li class="nav-item">
                                                                    <a class="nav-link" href="#page1">Details</a>
                                                                </li>
                                                                <li class="nav-item">
                                                                    <a class="nav-link" href="#page2">Job Safety
                                                                        Assessment</a>
                                                                </li>
                                                                <li class="nav-item">
                                                                    <a class="nav-link" href="#page3">Workers Info</a>
                                                                </li>
                                                            </ul>
                                                        </nav>

                                                        <div class="bg-light rounded" id="Pages">

                                                            <div class="page1" id="page1">
                                                                <div class="bg-light">
                                                                    <!-- permit number & date of issue: -->
                                                                    <div class="d-flex mb-3 mt-3">
                                                                        <div class="input-group me-2">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="permitNo0">Permit No:</span>
                                                                            <asp:TextBox ID="permitNum" Height="100%"
                                                                                CssClass="form-control" runat="server">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                        <div class="input-group">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center">Date
                                                                                of Issue</span>
                                                                            <asp:TextBox TextMode="DateTimeLocal"
                                                                                ID="issueDate" Height="100%"
                                                                                CssClass="form-control" runat="server">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <!-- Permit Valid From & Permit Valid Till -->
                                                                    <div class="d-flex mb-3">
                                                                        <div class="input-group me-2">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="validFrom">Permit Valid From:</span>
                                                                            <asp:TextBox TextMode="Date"
                                                                                ID="perValidFrom" Height="100%"
                                                                                CssClass="form-control datepicker"
                                                                                runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="input-group">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="validTill">Permit Valid Till:</span>
                                                                            <asp:TextBox TextMode="Date"
                                                                                ID="perValidTill" Height="100%"
                                                                                CssClass="form-control " runat="server">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <!-- Special License & DropDown list -->
                                                                    <div class="d-flex mb-3">
                                                                        <div class="input-group me-2 icheck-primary d-flex align-items-center"
                                                                            style="width: 50%;">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="splLicense0">Special License:</span>
                                                                            <div class="ms-2 me-2">
                                                                                <asp:RadioButton
                                                                                    ID="special_license_yes" Text="Yes"
                                                                                    runat="server"
                                                                                    GroupName="Special-License"
                                                                                    OnCheckedChanged="special_license_CheckedChanged" />
                                                                            </div>
                                                                            <div class="ms-2">
                                                                                <asp:RadioButton ID="special_license_no"
                                                                                    Text="No" runat="server"
                                                                                    GroupName="Special-License" />
                                                                            </div>
                                                                        </div>
                                                                        <asp:DropDownList ID="spl_Licence"
                                                                            CssClass="form-select"
                                                                            Style="display: none; width: 50%;"
                                                                            runat="server">
                                                                            <asp:ListItem
                                                                                Text="-- Select Special License Work --"
                                                                                Value=""></asp:ListItem>
                                                                            <asp:ListItem
                                                                                Text="High Tension Electrical Work"
                                                                                Value="elec-contractor"></asp:ListItem>
                                                                            <asp:ListItem Text="Height Work"
                                                                                Value="hgt-work"></asp:ListItem>
                                                                            <asp:ListItem Text="Crane Operator"
                                                                                Value="crn-operator"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <!-- ESI/Insurance No & Its Date -->
                                                                    <div class="d-flex mb-3">
                                                                        <div class="input-group me-2">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="esiNum0">ESI/Insurance No: </span>
                                                                            <asp:TextBox ID="esiNUM" Height="100%"
                                                                                CssClass="form-control" runat="server">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                        <div class="input-group me-2">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="esiVal">ESI/Insurance Validity:
                                                                            </span>
                                                                            <asp:TextBox TextMode="Date" ID="esiVali"
                                                                                Height="100%" CssClass="form-control"
                                                                                runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <!-- Name of Vendor or Contractor Firm/Agency -->
                                                                    <div class="mb-3 d-flex">
                                                                        <div class="input-group">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="vendors0">Name of Vendor or
                                                                                Contractor Firm/Agency:</span>
                                                                            <asp:TextBox ID="contractorNam"
                                                                                Height="100%" CssClass="form-control"
                                                                                runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Name of Vendor/Contractor Supervisor & Contact Number -->
                                                                    <div class="d-flex mb-3">
                                                                        <div class="input-group me-2">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="supervisor0">Name of
                                                                                Vendor/Contractor Supervisor: </span>
                                                                            <asp:TextBox ID="supervisorNam"
                                                                                Height="100%" CssClass="form-control"
                                                                                runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="input-group">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="supervisorContact0">Contact
                                                                                Number:</span>
                                                                            <asp:TextBox ID="supervisorContactNUM"
                                                                                Height="100%" CssClass="form-control"
                                                                                runat="server" MaxLength="10" TextMode="Phone" required></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <!-- ARAI Engineer & contact number -->
                                                                    <div class="d-flex mb-3">
                                                                        <div class="input-group me-2">
                                                                            <label
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                for="araiEng">
                                                                                ARAI Engineer:
                                                                            </label>
                                                                            <asp:DropDownList ID="araiEng" Height="100%"
                                                                                CssClass="form-select" runat="server">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="input-group">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="araiEngContact0">Contact
                                                                                Number:</span>
                                                                            <asp:TextBox ID="engiContactNUM"
                                                                                Height="100%" CssClass="form-control"
                                                                                runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                    <!-- Brief Description of Work & Location of Work -->
                                                                    <div class="d-flex mb-3">
                                                                        <div class="input-group me-2">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="desc0">Brief Description of
                                                                                Work:</span>
                                                                            <asp:TextBox ID="describeWork" Height="100%"
                                                                                CssClass="form-control" runat="server">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                        <div class="input-group">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="location0">Location of Work:</span>
                                                                            <asp:TextBox ID="locateWork" Height="100%"
                                                                                CssClass="form-control" runat="server">
                                                                            </asp:TextBox>
                                                                        </div>
                                                                    </div>

                                                                    <!-- Number of Workers -->
                                                                    <div class="mb-3 d-block">
                                                                        <div class="input-group mb-3">
                                                                            <span
                                                                                class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                                                id="numWorkers0">Number of
                                                                                Workers:</span>
                                                                            <asp:TextBox ID="numWorkers"
                                                                                CssClass="form-control" runat="server">
                                                                            </asp:TextBox>
                                                                            <asp:Button ID="confirm"
                                                                                CssClass="input-group-text btn btn-info border-1"
                                                                                OnClick="confirm_Click" runat="server"
                                                                                Text="Confirm" />
                                                                        </div>
                                                                        <div id="workers" style="width: auto;"
                                                                            class="mt-2 mb-0 d-flex justify-content-around"
                                                                            runat="server"></div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div id="page2" class="page2 p-4">
                                                                <h5>Job Safety Assessment</h5>
                                                                <div class="d-flex">
                                                                    <div style="width: 100%;">
                                                                        <br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check1" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk1" for="check1"
                                                                                style="width: 60%;" runat="server">
                                                                                Entry into vessels/tanks/manholes/A.C.
                                                                                Ducts/Cooling towers/fire fighting
                                                                                equipment</label>
                                                                        </div>
                                                                        <br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check2" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk2" for="check2"
                                                                                style="width: 60%;" runat="server">Civil
                                                                                Work(Construction/Excavation &
                                                                                Painting)</label>
                                                                        </div><br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check3" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk3" for="check3"
                                                                                style="width: 60%;" runat="server">Hot Works</label>
                                                                        </div><br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check4" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk4" for="check4"
                                                                                style="width: 60%;" runat="server">Work on fragile
                                                                                roof</label>
                                                                        </div><br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check5" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk5" for="check5"
                                                                                style="width: 60%;" runat="server">High Tension
                                                                                Electrical Work</label>
                                                                        </div><br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check6" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk6" for="check6"
                                                                                style="width: 60%;" runat="server">Low Tension
                                                                                Electrical Work</label>
                                                                        </div><br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check7" runat="server">
                                                                            </div>
                                                                            <label class="form-control" id="chk7" for="check7"
                                                                                style="width: 60%;" runat="server">Working on height
                                                                                (More than 3 meters)</label>
                                                                        </div><br />
                                                                        <div class="input-group d-flex">
                                                                            <div class="bg-secondary d-flex justify-content-center align-items-center"
                                                                                style="width: 30px;">
                                                                                <input type="checkbox" id="check8" runat="server">
                                                                            </div>
                                                                            <label class="form-control" Id="chk8" for="check8"
                                                                                style="width: 60%;" runat="server">
                                                                                Others (Mobile crane operations,
                                                                                loading/unloading on gas cylinder,
                                                                                unloading of liquid nitrogen)</label>
                                                                        </div>
                                                                    </div>


                                                                </div>


                                                                <br />
                                                                <br />


                                                                <div class="d-flex justify-content-between">
                                                                    <asp:Panel ID="Panel1" runat="server">
                                                                        <label
                                                                            class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Hazards
                                                                            Associated</label>
                                                                        <div id="listContainer1"
                                                                            class="input-group border-1 border-dark mb-1">
                                                                            <br>
                                                                            <p>
                                                                            <ul>
                                                                                <div id="check1-Hinfo"
                                                                                    style="display: none;">
                                                                                    <li>Breathlessness/Fainting</li>
                                                                                    <li>Fire</li>
                                                                                    <li>Explosion</li>
                                                                                    <li>Fall of Material</li>
                                                                                    <li>Poor Visibility</li>
                                                                                    <li>InfectionOfViruses</li>
                                                                                </div>
                                                                                <div id="check2-Hinfo"
                                                                                    style="display: none;">
                                                                                    <li>Fall of Material</li>
                                                                                    <li>Fall from height</li>
                                                                                    <li>Tripping over equipment</li>
                                                                                    <li>Exposure</li>
                                                                                    <li>Unstable Adjacent Struct</li>
                                                                                    <li>Mishandled/PoorlyP Materials
                                                                                    </li>
                                                                                    <li>Hazardous Atmosphere</li>
                                                                                    <li>Eye Injury/Irritation</li>
                                                                                    <li>Inhalation of fumes</li>
                                                                                </div>
                                                                            </ul>
                                                                            </p>
                                                                            <div id="check3-Hinfo"
                                                                                style="display: none;">...</div>
                                                                            <div id="check4-Hinfo"
                                                                                style="display: none;">...</div>
                                                                            <div id="check5-Hinfo"
                                                                                style="display: none;">...</div>
                                                                            <div id="check6-Hinfo"
                                                                                style="display: none;">...</div>
                                                                            <div id="check7-Hinfo"
                                                                                style="display: none;">...</div>
                                                                            <div id="check8-Hinfo"
                                                                                style="display: none;">...</div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="Panel2" runat="server">
                                                                        <label
                                                                            class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Precautions
                                                                            taken</label>
                                                                        <div id="listContainer2"
                                                                            class="input-group border-1 border-dark mb-1">
                                                                            <br>
                                                                            <p>
                                                                            <ul>
                                                                                <div id="check1-Pinfo"
                                                                                    style="display: none;">
                                                                                    <li>Remove Flammable/Explosive
                                                                                        Materials</li>
                                                                                    <li>Breathing apparatus</li>
                                                                                    <li>Confirm Electrical equipment
                                                                                        kept off</li>
                                                                                    <li>Confirm oxygen levels are not
                                                                                        below 19.5%</li>
                                                                                    <li>Provide appropriate
                                                                                        exhaust/ventilation</li>
                                                                                    <li>Pipeline/Tank to be drained</li>
                                                                                </div>
                                                                                <div id="check2-Pinfo"
                                                                                    style="display: none;">
                                                                                    <li>Provide barricade</li>
                                                                                    <li>Stacking to be made min 2 feet
                                                                                    </li>
                                                                                    <li>Provide safe means of access
                                                                                    </li>
                                                                                    <li>Check routes of electrical
                                                                                        cables</li>
                                                                                </div>
                                                                                <div id="check3-Pinfo"
                                                                                    style="display: none;">
                                                                                    <li>Provide appropriate
                                                                                        exhaust/ventilation</li>
                                                                                    <li>Stacking to be made min 2 feet
                                                                                    </li>
                                                                                    <li>Provide safe means of access
                                                                                    </li>
                                                                                    <li>Check routes of electrical
                                                                                        cables</li>
                                                                                </div>
                                                                            </ul>
                                                                            </p>
                                                                        </div>
                                                                    </asp:Panel>
                                                                    <asp:Panel ID="Panel3" runat="server">
                                                                        <label
                                                                            class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Personal
                                                                            Protective Equipment</label>
                                                                        <div id="listContainer3"
                                                                            class="input-group border-1 border-dark mb-1">
                                                                            <ul>
                                                                            </ul>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                                <%--<div class="cont-2">
                                                                    <label
                                                                        class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Precautions
                                                                        taken</label>
                                                                    <div id="listContainer"
                                                                        class="input-group border-1 border-dark mb-1">
                                                                        <ul>
                                                                            <li>Work to be carried out by trained
                                                                                manpower</li>
                                                                            <li>Provide safe means of access</li>
                                                                            <li>Strict supervision required</li>
                                                                        </ul>
                                                                    </div>
                                                            </div>--%>
                                                            <%--<div class="cont-3">
                                                                <label
                                                                    class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Personal
                                                                    Precautionary Equipment</label>
                                                                <div id="listContainer2"
                                                                    class="input-group border-1 border-dark mb-1">
                                                                    <ul>
                                                                        <li>Portable ladders</li>
                                                                        <li>Safety Goggles and kit</li>
                                                                        <li>Helmet</li>
                                                                    </ul>
                                                                </div>
                                                        </div>--%>
                                                    </div>

                                    </div>

                                    <div id="page3" class="page-3 p-4">
                                        <div class="d-flex justify-content-between mt-3 mb-2">
                                            <button type="reset"
                                                class="btn btn-outline-secondary align-self-end invisible"
                                                onclick="clearFields('workDetails')">
                                                Back
                                            </button>
                                            <asp:Button ID="submit" CssClass="btn btn-success align-self-end"
                                                runat="server" Text="Submit" OnClick="SubmitFrom" />
                                        </div>
                                    </div>

                            </div>

                            <%-- </asp:UpdatePanel>--%>

                </div>
        </div>

        </div>

        </section>

        </div>
        <!-- /.content-wrapper -->

        <script>
            document.addEventListener('DOMContentLoaded', function () {
                var specialLicenseYes = document.getElementById('<%= special_license_yes.ClientID %>');
                var splLicenceDropDown = document.getElementById('<%= spl_Licence.ClientID %>');
                // Function to toggle dropdown visibility
                function toggleDropdownVisibility() {
                    splLicenceDropDown.style.display = specialLicenseYes.checked ? 'block' : 'none';
                }
                // Initial toggle on page load
                toggleDropdownVisibility();
                // Event listener for radio button change
                specialLicenseYes.addEventListener('change', toggleDropdownVisibility);
                // Additional logic for "No" selection
                var specialLicenseNo = document.getElementById('<%= special_license_no.ClientID %>');
                specialLicenseNo.addEventListener('change', function () {
                    splLicenceDropDown.style.display = specialLicenseNo.checked ? 'none' : 'block';
                });
            });

            document.addEventListener('DOMContentLoaded', function () {
                // Function to toggle visibility of info divs
                function toggleInfoDiv(event) {
                    var checkboxId = event.target.id;
                    var HcheckboxId = checkboxId + '-Hinfo';  // Get info div ID based on checkbox ID
                    var PcheckboxId = checkboxId + '-Pinfo';  // Get info div ID based on checkbox ID
                    var PPEcheckboxId = checkboxId + '-PPEinfo';  // Get info div ID based on checkbox ID

                    var HinfoDiv = document.getElementById(HcheckboxId);
                    var PinfoDiv = document.getElementById(PcheckboxId);
                    var PPEinfoDiv = document.getElementById(PPEcheckboxId);

                    if (HinfoDiv) {
                        HinfoDiv.style.display = HinfoDiv.style.display === 'none' ? 'block' : 'none';
                    }
                    if (PinfoDiv) {
                        PinfoDiv.style.display = PinfoDiv.style.display === 'none' ? 'block' : 'none';
                    }
                    if (PPEinfoDiv) {
                        PPEinfoDiv.style.display = PPEinfoDiv.style.display === 'none' ? 'block' : 'none';
                    }
                }

                // Attach event listener to all checkboxes
                var checkboxes = document.querySelectorAll('input[type="checkbox"]');
                checkboxes.forEach(function (checkbox) {
                    checkbox.addEventListener('click', toggleInfoDiv);
                });
            });

        </script>


    </asp:Content>