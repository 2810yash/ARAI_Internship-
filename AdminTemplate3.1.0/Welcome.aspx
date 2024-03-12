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
        <div class="content-wrapper">
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
                        <div class="headline text-align-center">
                            <h6 class="blink-text text-align-center m-1">Security shall check work permit and allow
                                workers to enter with valid work permit in case of below mentioned works</h6>
                            <h6 class="blink-text text-align-center m-1">Work permit to be filled by contractor in
                                consultation with ARAI officials (of work intending dept.)</h6>
                            <h6 class="blink-text text-align-center m-1">Work on Saturday/Sunday & holidays will be
                                under strict supervision of work intending departments</h6>
                        </div>

                    <div class="card-header justify-content-between">
                        <label>Site: </label>
                            <select class="form-control select2" style="width: 100%;">
                                <option selected="selected" id="kothrud">Kothrud</option>
                                <option id="chakan">Chakan</option>
                                <option id="htcCk">HTC-Chakan</option>
                            </select>
                        </div>

                    <div class="container mt-2 border rounded bg-light pages">

                        <nav id="navbar-example2" class="navbar navbar-light bg-light px-3">
                            <a class="navbar-brand" href="#">Navigation</a>
                            <ul class="nav nav-pills">
                                <li class="nav-item">
                                    <a class="nav-link" href="#page1">Details</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#page2">Job Safety Assessment</a>
                                </li>
                                <li class="nav-item dropdown">
                                    <a class="nav-link dropdown-toggle" data-bs-toggle="dropdown" href="#" role="button" aria-expanded="false">Dropdown</a>
                                    <ul class="dropdown-menu">
                                        <li><a class="dropdown-item" href="#scrollspyHeading3">Third</a></li>
                                        <li><a class="dropdown-item" href="#scrollspyHeading4">Fourth</a></li>
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>
                                        <li><a class="dropdown-item" href="#scrollspyHeading5">Fifth</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </nav>
                       <%-- <div data-bs-spy="scroll" data-bs-target="#navbar-example2" data-bs-offset="0" class="scrollspy-example" tabindex="0">
                            <h4 id="scrollspyHeading1">First heading</h4>
                            <p>...</p>
                            <h4 id="scrollspyHeading2">Second heading</h4>
                            <p>...</p>
                            <h4 id="scrollspyHeading3">Third heading</h4>
                            <p>...</p>
                            <h4 id="scrollspyHeading4">Fourth heading</h4>
                            <p>...</p>
                            <h4 id="scrollspyHeading5">Fifth heading</h4>
                            <p>...</p>
                        </div>--%>

                        <div class="page1" id="page1">
                            <div class="bg-light">
                                <div class="input-group mb-3 mt-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="permitNo0">Permit No:</span>
                                    <input type="text" class="form-control" placeholder="Permit No"
                                        aria-label="Permit No" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="doi0">Date of
                                        Issue:</span>
                                    <input type="datetime-local" class="form-control" 
                                        aria-label="DOI" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="basic-addon1">Permit Valid From:</span>
                                    <input type="datetime-local" class="form-control"
                                        aria-label="Valid From" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="basic-addon1">Permit Valid Till:</span>
                                    <input type="datetime-local" class="form-control" 
                                        aria-label="Valid Till" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3 icheck-primary">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="splLicense0">Special License:</span>
                                    <input type="radio" class="btn-check" name="options-outlined" id="success-outlined"
                                        autocomplete="off">
                                    <label class="btn btn-outline-secondary pe-4" for="success-outlined">Yes</label>
                                    <input type="radio" class="btn-check" name="options-outlined" id="danger-outlined"
                                        autocomplete="off">
                                    <label class="btn btn-outline-secondary pe-4" for="danger-outlined">No</label>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="esiNum0">ESI/Insurance No & Validity: </span>
                                    <input type="text" class="form-control" placeholder="ESI/Insurance No & Validity"
                                        aria-label="ESI/Insurance No & Validity" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="vendors0">Name of Vendor or Contractor Firm/Agency:</span>
                                    <input type="text" class="form-control" placeholder="Name of Vendor or Contractor Firm/Agency"
                                        aria-label="Name of Vendor or Contractor Firm/Agency" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="numWorkers0">Number of Workers:</span>
                                    <input type="text" class="form-control" placeholder="No. of Workers"
                                        aria-label="No. of Workers" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="supervisor0">Name of Vendor/Contractor Supervisor: </span>
                                    <input type="text" class="form-control" placeholder="Vendor/Contractor Supervisor"
                                        aria-label="Vendor/Contractor Supervisor" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="supervisorContact0">Contact Number:</span>
                                    <input type="text" class="form-control" placeholder="Vendor/Contractor Supervisor Contact No."
                                        aria-label="Contact No." aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <label class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        for="araiEng">
                                        ARAI
                                        Engineer:
                                    </label>
                                    <select class="form-select" id="araiEng">
                                        <option>Choose...</option>
                                        <option value="1">One</option>
                                        <option value="2">Two</option>
                                        <option value="3">Three</option>
                                    </select>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="araiEngContact0">Contact Number:</span>
                                    <input type="text" class="form-control" placeholder="ARAI Engineer Contact No."
                                        aria-label="Contact No." aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="desc0">Brief Description of Work:</span>
                                    <input type="text" class="form-control" placeholder="Work Description"
                                        aria-label="Work Description" aria-describedby="basic-addon1">
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text text-wrap col-sm-3 justify-content-center"
                                        id="location0">Location of Work:</span>
                                    <input type="text" class="form-control" placeholder="Location of Work"
                                        aria-label="Location of Work" aria-describedby="basic-addon1">
                                </div>
                            </div>
                            <div class="d-flex justify-content-between mt-3 mb-2">
                                <button type="reset" class="btn btn-outline-secondary align-self-end invisible"
                                    onclick="clearFields('workDetails')">
                                    Back</button>
                                <button type="submit" class="btn btn-primary align-self-end"
                                    onclick="saveWork_page1()">
                                    Next</button>
                            </div>
                        </div>
                        
                        <!--Work Permit Options-->
                        <div class="page2" id="page2">
                        <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Job Safety Assessment</label>
                            <div class="d-flex">
                                <div class="cont-1">
                                    <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Work Permit</label>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon1">
                                            <input class="form-check-input" type="checkbox" value="" id="wk1"></span>
                                        <label class="text-wrap form-check-label col-sm-9 m-lg-1 border-bottom-0">
                                            Entry into vessel/Tanks/Manholes/A.C. Ducts/Cooling Towers/Confined Spaces</label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon2">
                                            <input class="form-check-input" type="checkbox" value="" id="wk2"></span>
                                        <label class="form-check-label col-sm-9 m-lg-1 ">
                                            Civil Work (Painting, Construction, Excavation etc)</label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon3">
                                            <input class="form-check-input" type="checkbox" value="" id="wk3"></span>
                                        <label class="form-check-label col-sm-9 m-lg-1 ">Hot Works (Welding/Gas Cutting) </label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon4">
                                            <input class="form-check-input" type="checkbox" value="" id="wk4"></span>
                                        <label class="form-check-label col-sm-9 m-lg-1 ">Work on Fragile Roof </label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon5">
                                            <input class="form-check-input" type="checkbox" value="" id="wk5"></span>
                                        <label class="form-check-label col-sm-9 m-lg-1 ">High Tension Electrical Work </label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon6">
                                            <input class="form-check-input" type="checkbox" value="" id="wk6"></span>
                                        <label class="form-check-label col-sm-9 m-lg-1 ">Low Tension Electrical Work </label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon7">
                                            <input class="form-check-input" type="checkbox" value="" id="wk7"></span>
                                        <label class="form-check-label col-sm-9 m-lg-1 border-1">
                                            Working on height (more than 3 meters)
                                        </label>
                                    </div>
                                    <div class="input-group mb-3">
                                        <span class="input-group-text" id="basic-addon8">
                                            <input class="form-check-input" type="checkbox" value="" id="wk8"></span>
                                        <label class="text-wrap form-check-label col-sm-9 m-lg-1 ">
                                            Others (Mobile crane operations, loading and unloading of gas cylinder, unloading of liquid nitrogen)
                                        </label>
                                    </div>
                                </div>
                                <div class="cont-2">
                                    <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Hazard Associated</label>
                                    <div class="input-group  border-1 border-dark mb-1">
                                        <label class="form-check-label col-sm-9 m-lg-1 border-bottom-0">
                                            Entry into vessel/Tanks/Manholes/A.C. Ducts/Cooling Towers/Confined Spaces</label>
                                    </div>
                                </div>
                                <div class="cont-3">
                                    <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Personal Precautionary Equipment</label>
                                    <div class="input-group  border-1 border-dark mb-1">
                                        <label class="form-check-label col-sm-9 m-lg-1 border-bottom-0">
                                            Entry into vessel/Tanks/Manholes/A.C. Ducts/Cooling Towers/Confined Spaces</label>
                                    </div>
                                </div>
                            </div>
                            <div class="d-flex justify-content-between mt-3 mb-2">
                                <button type="reset" class="btn btn-outline-secondary align-self-end"
                                    onclick="clearFields('workDetails')">
                                    Back</button>
                                <button type="submit" class="btn btn-primary align-self-end"
                                    onclick="saveWork_page2()">
                                    Next</button>
                            </div>
                        </div>

                    </div>
                </div>
            </section>

        </div>
        <!-- /.content-wrapper -->

    </asp:Content>