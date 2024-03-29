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
                        <%-- Blinking TEXT--%>
                        <div class="headline text-align-center">
                            <h6 class="blink-text text-align-center m-1">Security shall check work permit and allow
                                workers to enter with valid work permit in case of below mentioned works</h6>
                            <h6 class="blink-text text-align-center m-1">Work permit to be filled by contractor in
                                consultation with ARAI officials (of work intending dept.)</h6>
                            <h6 class="blink-text text-align-center m-1">Work on Saturday/Sunday & holidays will be
                                under strict supervision of work intending departments</h6>
                        </div>
                        <div class="pages">
                            <%-- Site Name--%>
                            <div class="card-header justify-content-between">
                                <label>Site: </label>
                                <select class="form-control select2" style="width: 100%;">
                                    <option selected="selected" id="kothrud">Kothrud</option>
                                    <option id="chakan">Chakan</option>
                                    <option id="htcCk">HTC-Chakan</option>
                                </select>
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
                                            <a class="nav-link" href="#page3">Worker Details</a>
                                        </li>
                                    </ul>
                                </nav>
                                <div class="bg-light rounded" id="Pages">

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
                                                    aria-label="No. of Workers" aria-describedby="basic-addon1" id="noWorkers">
                                                <button class="input-group-text btn btn-info border-1" id="confirm">Confirm</button>
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
                                        <%-- <div class="d-flex justify-content-between mt-3 mb-2">
                                <button type="reset" class="btn btn-outline-secondary align-self-end invisible"
                                    onclick="clearFields('workDetails')">
                                    Back</button>
                                <button type="submit" class="btn btn-primary align-self-end"
                                    onclick="saveWork_page1()">
                                    Next</button>
                            </div> --%>
                                    </div>

                                    <div id="page2" class="page2 p-4">
                                        <div class="d-flex">
                                            <div class="cont-1">
                                                <label class="text-wrap form-col-sm-7 m-lg-1 border-bottom-0">Work Permit</label>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon1">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk1" onchange="addHazard()"></span>
                                                    <label class="text-wrap form-check-label col-sm-7 m-lg-1 border-bottom-0">
                                                        Entry into vessel/Tanks/Manholes/A.C. Ducts/Cooling Towers/Confined Spaces</label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon2">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk2" onchange="addHazard()"></span>
                                                    <label class="text-wrap form-check-lab elevation-0  col-sm-7 m-lg-1 ">
                                                        Civil Work (Painting, Construction, Excavation etc)</label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon3">
                                                        <input class="text-wrap form-check-input" type="checkbox" value="" id="wk3" onchange="addHazard()"></span>
                                                    <label class="form-check-label col-sm-7 m-lg-1 ">Hot Works (Welding/Gas Cutting) </label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon4">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk4" onchange="addHazard()"></span>
                                                    <label class="form-check-label col-sm-9 m-lg-1 ">Work on Fragile Roof </label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon5">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk5" onchange="addHazard()"></span>
                                                    <label class="form-check-label col-sm-9 m-lg-1 ">High Tension Electrical Work </label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon6">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk6" onchange="addHazard()"></span>
                                                    <label class="form-check-label col-sm-9 m-lg-1 ">Low Tension Electrical Work </label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon7">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk7" onchange="addHazard()"></span>
                                                    <label class="form-check-label col-sm-9 m-lg-1 border-1">
                                                        Working on height (more than 3 meters)
                                                    </label>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <span class="input-group-text" id="basic-addon8">
                                                        <input class="form-check-input" type="checkbox" value="" id="wk8" onchange="addHazard()"></span>
                                                    <label class="text-wrap form-check-label col-sm-9 m-lg-1 ">
                                                        Others (Mobile crane operations, loading and unloading of gas cylinder, unloading of liquid nitrogen)
                                                    </label>
                                                </div>
                                            </div>
                                            <div class="cont-2">
                                                <label class="text-wrap form-col-sm-9 m-lg-1 border-bottom-0">Precautions to be taken</label>
                                                <!-- Work Permit 1: Entry into vessels... -->
                                                <div class="input-group  border-1 border-dark mb-1">
                                                    <ul class="border-1 mb-1">
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr1">Remove Flammable and explosive materials.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr2">Provide appropriate exhaust.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr3">Confirm oxygen levels are not below 19.5% or less.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr4">Pipeline/tank to be drained, purged and valve closed.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr5">Confirm Electrical equipment kept off.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr6">Person is wearing suitable breating apparatus and a belt securely attached to a rope the free end of which his held by a person outside the confined space, if apparatus is provided.</li>
                                                    </ul>
                                                </div>

                                                <!-- Work Permit 2: Civil Work -->
                                                <div class="input-group  border-1 border-dark mb-1">
                                                    <ul class="border-1 mb-1">
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr7">Provide fire watch/guard.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr8">Perform hot work in a safe location, or with fire hazards removed or covered.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr9">Provide appropriate ventilations.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr10">Use appropriate PPEs.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr11">Check routes of fuel lines, cables, etc.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr12">Check hose pipes and exhaust.</li>

                                                    </ul>
                                                </div>

                                                <!-- Work Permit 3: Hot Works -->
                                                <div class="input-group  border-1 border-dark mb-1">
                                                    <ul class="border-1 mb-1">
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr13">Provide barricade.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr14">Stacking to be made minimum 2 feet from edges of trench or excavation.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr15">Provide safe means of access.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr16">Check routes of electrical cables, gas/fuel/water pipes lines etc before initiation of work.</li>
                                                    </ul>
                                                </div>

                                                 <!-- Work Permit 4: Work on Fragile Roof -->
                                                <div class="input-group  border-1 border-dark mb-1">
                                                    <ul class="border-1 mb-1">
                                                        <!-- <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0" id="pr15">Provide safe means of access.</li> -->
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr17">Provide ladder attendant if required.</li>
                                                    </ul>
                                                </div>

                                                <!-- Work Permit 5 & 6: High tension and Low tension electrical Work -->
                                                <div class="input-group  border-1 border-dark mb-1">
                                                    <ul class="border-1 mb-1">
                                                        <!-- <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0" id="pr15">Provide safe means of access.</li> -->
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr18">Work to be carried out by trained manpower.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr19">Strict supervision required.</li>
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr20">Fire attendant and first aider should be availabe.</li>
                                                    </ul>
                                                </div>
                                                <!-- Work Permit 7: Work On Height (more than 3 meters) -->
                                                <div class="input-group  border-1 border-dark mb-1">
                                                    <ul class="border-1 mb-1">
                                                        <!-- <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0" id="pr15">Provide safe means of access.</li> -->
                                                        <!-- <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0" id="pr18">Work to be carried out by trained manpower.</li> -->
                                                        <!-- <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0" id="pr19">Strict supervision required.</li> -->
                                                        <li class="form-check-label col-sm-9 m-lg-1 border-bottom-0 invisible" id="pr21">Use of scaffold.</li>
                                                    </ul>
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
                                        <%--<div class="d-flex justify-content-between mt-3 mb-2">
                                <button type="reset" class="btn btn-outline-secondary align-self-end"
                                    onclick="clearFields('workDetails')">
                                    Back</button>
                                <button type="submit" class="btn btn-primary align-self-end"
                                    onclick="saveWork_page2()">
                                    Next</button>
                            </div>--%>
                                    </div>

                                    <div id="page3" class="page-3 p-4">

                                        <div id="workers">
                                        </div>
                                        <div class="d-flex justify-content-between mt-3 mb-2">
                                            <button type="reset" class="btn btn-outline-secondary align-self-end invisible"
                                                onclick="clearFields('workDetails')">
                                                Back
                                            </button>
                                            <button type="submit" class="btn btn-success align-self-end"
                                                onclick="saveWork_page3()">
                                                Submit
                                            </button>
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

        <script>
            $(document).ready(function() {
                $('#confirm').click(function () {
                    var rows = parseInt($('#noWorkers').val());
                    var cols = 10;
                    var table = $('<table></table>');

                    for (var i = 0; i < 3; i++) {
                        var row = $('<tr></tr>');
                        for (var j = 0; j < cols; j++) {
                            var cell = $('<td></td>').text('Row ' + (i + 1) + ',Cols' + (j + 1));
                            row.append(cell);
                        }
                        table.append(row);
                    }

                    $('#workers').empty().append(table);
                });
            });
        </script>
        <script>
            function changeHeight() {
                var scroll = (window.pageYOffset / 5);
                var height = scroll;

                document.getElementById('expand').style.height = height + '%';
            }

            window.addEventListener('scroll', function () {
                requestAnimationFrame(changeHeight);
            })
        </script>

    </asp:Content>