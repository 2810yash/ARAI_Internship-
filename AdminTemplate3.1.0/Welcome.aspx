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

        <style>
            .scroll-horizontal-div {
                overflow-x: auto;
                white-space: nowrap;
            }

            .scroll-horizontal-div::-webkit-scrollbar {
                width: 0.5em;
                height: 0.5em
            }

            .scroll-horizontal-div::-webkit-scrollbar-track {
                background-color: #c6ccd4;
                border-radius: 5em;
            }

            .scroll-horizontal-div::-webkit-scrollbar-thumb {
                background-color: #748290;
                border-radius: 5em;
            }

            .heading {
                    text-align: center;
                    font-weight: 500;
                    padding: 50px;
                    border-radius: 20px;
                    box-shadow: 0 0 10px rgb(56, 111, 111);
                    background-color: aliceblue;
                    width:100%;
            }

            .heading h1 {
                     margin: 0;
                     font-family: 'sans-serif';
                     color: #00000;
                     font-weight: 1000;
                     text-shadow: 20px 20px 40px rgb(56, 111, 111);
            }

            .blink-headline{
                border:2px solid orange;
                background-color:#fbe3b7;
            }

            .main-page{
                background-color:#82cefd;
            }

            .content-wrapper{
                background-color:#55b6e6;
            }
        </style>
    </asp:Content>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <!-- Content Wrapper. Contains page content -->
        <div class="content-wrapper position-relative p-2">
            <!-- Content Header (Page header) -->
            <div class="content-header">
                <div class="container-fluid">
                    <div class="d-flex justify-content-center align-items-center">
                        <div class="mt-5 heading">
                            <h1>WORK-PERMIT</h1>
                        </div>
                        <!-- /.col -->
                        <%--<div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item text-decoration-none"><a href="../Homepage.aspx">Home</a>
                                </li>
                                <li class="breadcrumb-item active">WorkPermit</li>
                            </ol>
                        </div>--%>
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
                        <marquee class="blink-headline rounded">
                        <div class="headline text-center p-3">
                            <h6 class="blink-text m-1">Security shall check work permit and allow
                                workers to enter with valid work permit in case of below mentioned works</h6>
                            <h6 class="blink-text m-1">Work permit to be filled by contractor in
                                consultation with ARAI officials (of work intending dept.)</h6>
                            <h6 class="blink-text m-1">Work on Saturday/Sunday & holidays will be
                                under strict supervision of work intending departments</h6>
                        </div>
                        </marquee>
                        <div class="main-page rounded">
                            <%-- Site Name--%>
                            <div class="card-header justify-content-between">
                                <label>Site: </label>
                                <asp:DropDownList ID="site" CssClass="form-control select" runat="server">
                                    <asp:ListItem Text="ARAI-Kothrud" Selected="false" Value="ARAI-Kothrud"></asp:ListItem>
                                    <asp:ListItem Text="ARAI-Chakan" Value="ARAI-Chakan"></asp:ListItem>
                                    <asp:ListItem Text="ARAI-HTC-Chakan" Value="ARAI-HTC-Chakan"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <%-- Permit Form--%>
                            <div class="position-relative" id="expand">
                                <div class="p-2" id="Pages">

                                    <div class="page1" id="page1">
                                        <div>
                                            <!-- permit number & date of issue: -->
                                            <div class="d-flex mb-3 mt-3">
                                                <div class="input-group me-2">
                                                    <span id="permitNo0" class="input-group-text text-wrap col-sm-3 justify-content-center">Permit No:</span>
                                                    <asp:TextBox ID="permitNum" CssClass="form-control" Height="100%" required="required" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span id="dateIssue" class="input-group-text text-wrap col-sm-3 justify-content-center">Date of Issue</span>
                                                    <asp:TextBox TextMode="DateTimeLocal" ID="issueDate" CssClass="form-control" Height="100%" required="required" runat="server"></asp:TextBox>
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
                                                        CssClass="form-control datepicker" required
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="validTill">Permit Valid Till:</span>
                                                    <asp:TextBox TextMode="Date"
                                                        ID="perValidTill" Height="100%"
                                                        CssClass="form-control " required runat="server">
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
                                                            AutoPostBack="True"
                                                            GroupName="Special-License"
                                                            OnCheckedChanged="special_license_CheckedChanged" />
                                                    </div>
                                                    <div class="ms-2">
                                                        <asp:RadioButton
                                                            ID="special_license_no"
                                                            Text="No"
                                                            runat="server"
                                                            AutoPostBack="True"
                                                            GroupName="Special-License"
                                                            OnCheckedChanged="special_license_CheckedChangedNo" />
                                                    </div>
                                                </div>
                                                <asp:DropDownList ID="spl_Licence"
                                                    CssClass="form-select"
                                                    Style="display: none; width: 50%;"
                                                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropdownSelectedSplIndexChanged">
                                                </asp:DropDownList>
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

                                                </script>
                                            </div>
                                            <!-- ESI/Insurance No & Its Date -->
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="esiNum0">ESI/Insurance No: </span>
                                                    <asp:TextBox ID="esiNUM" Height="100%"
                                                        CssClass="form-control" required runat="server">
                                                    </asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="esiVal">ESI/Insurance Validity:
                                                    </span>
                                                    <asp:TextBox TextMode="Date" ID="esiVali"
                                                        Height="100%" CssClass="form-control" required
                                                        runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Name of Vendor or Contractor Firm/Agency & Number of workers  -->
                                            <div class="mb-3 d-flex">
                                                <div class="input-group me-2">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="vendors0">Name of Vendor or
                                                                                Contractor Firm/Agency:</span>
                                                    <asp:TextBox ID="contractorNam"
                                                        Height="100%" CssClass="form-control" required
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="numWorkers0">Number of Workers:</span>
                                                    <asp:TextBox ID="numWorkers"
                                                        CssClass="form-control" Height="100%" required runat="server" TextMode="Number">
                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <!-- Name of Vendor/Contractor Supervisor & Contact Number -->
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="supervisor0">Name of Vendor/Contractor Supervisor: </span>
                                                    <asp:TextBox ID="supervisorNam"
                                                        Height="100%" CssClass="form-control" required
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="supervisorContact0">Contact Number (Supervisor):</span>
                                                    <asp:TextBox ID="supervisorContactNUM" required
                                                        Height="100%" CssClass="form-control"
                                                        runat="server" MaxLength="10" TextMode="Phone"></asp:TextBox>
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
                                                    <asp:DropDownList ID="araiEng" Height="100%" required
                                                        CssClass="form-select" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="input-group">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="araiEngContact0">Contact Number (Engineer):</span>
                                                    <asp:TextBox ID="engiContactNUM"
                                                        Height="100%" CssClass="form-control" required
                                                        runat="server" TextMode="Phone"></asp:TextBox>
                                                </div>
                                            </div>
                                            <!-- Brief Description of Work & Location of Work -->
                                            <div class="d-flex mb-3">
                                                <div class="input-group me-2">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="desc0">Brief Description of Work:</span>
                                                    <asp:TextBox ID="describeWork" Height="100%" required
                                                        CssClass="form-control" runat="server">
                                                    </asp:TextBox>
                                                </div>
                                                <div class="input-group">
                                                    <span
                                                        class="input-group-text text-wrap col-sm-3 justify-content-center"
                                                        id="location0">Location of Work:</span>
                                                    <asp:TextBox ID="locateWork" Height="100%" required
                                                        CssClass="form-control" runat="server">
                                                    </asp:TextBox>
                                                </div>
                                            </div>

                                            <!-- Workers Details -->
                                            <div class="mb-3 d-block scroll-horizontal-div">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" ShowFooter="True" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:BoundField DataField="RowNumber" HeaderText="Sr. No." />
                                                                <asp:TemplateField HeaderText="Name of Workers">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="AGE">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="TextBox2" TextMode="Number" runat="server"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mask">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Safety Shoes/Gum Boots">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Jackets/Aprons">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox3" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Gloves">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox4" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ear plug/muffs">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox5" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Belt/Harness">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox6" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Helmet">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox7" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remark">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                    <FooterTemplate>
                                                                        <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <%--file upload--%>
                                        <div class="container-fluid p-3">
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="float-right" />
                                        </div>
                                        <%--./fil upload--%>
                                    </div>
                                    <div id="page2" class="page2 p-4">
                                        <h4>Job-Safety Assessment</h4>
                                        <div>
                                            <asp:CheckBox ID="check1" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Entry into vessels/tanks/manholes/A.C. Ducts/Cooling towers/fire fighting equipment" OnCheckedChanged="checkChnage1" /><br />
                                            <asp:CheckBox ID="check2" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Civil Work(Construction/Excavation & Painting)" OnCheckedChanged="checkChnage2" /><br />
                                            <asp:CheckBox ID="check3" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Hot Works" OnCheckedChanged="checkChnage3" /><br />
                                            <asp:CheckBox ID="check4" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Work on fragile roof" OnCheckedChanged="checkChnage4" /><br />
                                            <asp:CheckBox ID="check5" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="High Tension Electrical Work" OnCheckedChanged="checkChnage5" /><br />
                                            <asp:CheckBox ID="check6" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Low Tension Electrical Work" OnCheckedChanged="checkChnage6" /><br />
                                            <asp:CheckBox ID="check7" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Working on height (More than 3 meters)" OnCheckedChanged="checkChnage7" /><br />
                                            <asp:CheckBox ID="check8" CssClass="border rounded p-2 bg-light" AutoPostBack="true" Width="100%" runat="server" ClientIDMode="Static" Text="Others (Mobile crane operations, loading/unloading on gas cylinder, unloading of liquid nitrogen)" OnCheckedChanged="checkChnage8" /><br />
                                        </div>
                                        <br />
                                        <hr />
                                        <div class="d-flex justify-content-around">
                                            <div class="d-block">
                                                <h5>Hazards Associated</h5>
                                                <ul>
                                                    <div id="check1_Hinfo" runat="server">
                                                        <li>Breathlessness/Fainting</li>
                                                        <li>Fire</li>
                                                        <li>Explosion</li>
                                                        <li>Fall of Material</li>
                                                        <li>Poor Visibility</li>
                                                        <li>InfectionOfViruses</li>
                                                    </div>
                                                    <div id="check2_Hinfo" runat="server">
                                                        <li>Fall of Material</li>
                                                        <li>Fall from height</li>
                                                        <li>Tripping over equipment</li>
                                                        <li>Exposure</li>
                                                        <li>Unstable Adjacent Struct</li>
                                                        <li>Mishandled/PoorlyP Materials</li>
                                                        <li>Hazardous Atmosphere</li>
                                                        <li>Eye Injury/Irritation</li>
                                                        <li>Inhalation of fumes</li>
                                                    </div>
                                                    <div id="check3_Hinfo" runat="server">
                                                        <li>Fire</li>
                                                        <li>Explosion</li>
                                                        <li>Burns</li>
                                                        <li>Exposure</li>
                                                        <li>Eye Injury/Irritation</li>
                                                        <li>Inhalation of fumes</li>
                                                        <li>Accumulation of gases</li>
                                                        <li>Property_Damage</li>
                                                        <li>Allergies</li>
                                                        <li>Suffocation</li>
                                                    </div>
                                                    <div id="check4_Hinfo" runat="server">
                                                        <li>Fall from height</li>
                                                    </div>
                                                    <div id="check5_Hinfo" runat="server">
                                                        <li>Fire</li>
                                                        <li>Explosion</li>
                                                        <li>Burns</li>
                                                        <li>Electrical Shock</li>
                                                    </div>
                                                    <div id="check6_Hinfo" runat="server">
                                                        <li>Fire</li>
                                                        <li>Explosion</li>
                                                        <li>Burns</li>
                                                        <li>Electrical Shock</li>
                                                    </div>
                                                    <div id="check7_Hinfo" runat="server">
                                                        <li>Fall from height</li>
                                                        <li>Fractures and dislocations</li>
                                                    </div>
                                                    <div id="check8_Hinfo" runat="server"></div>
                                                </ul>
                                            </div>
                                            <div class="d-block">
                                                <h5>Precautions to be taken</h5>
                                                <ul>
                                                    <div id="check1_Pinfo" runat="server">
                                                        <li>Remove Flammable/Explosive Materials</li>
                                                        <li>Breathing apparatus</li>
                                                        <li>Confirm Electrical equipment kept off</li>
                                                        <li>Confirm oxygen levels are not below 19.5%</li>
                                                        <li>Provide appropriate exhaust/ventilation</li>
                                                        <li>Pipeline/Tank to be drained</li>
                                                    </div>
                                                    <div id="check2_Pinfo" runat="server">
                                                        <li>Provide barricade</li>
                                                        <li>Stacking to be made min 2 feet</li>
                                                        <li>Provide safe means of access</li>
                                                        <li>Check routes of electrical cables</li>
                                                    </div>
                                                    <div id="check3_Pinfo" runat="server">
                                                        <li>Provide appropriate exhaust/ventilation</li>
                                                        <li>Check routes of electrical cables</li>
                                                        <li>Perform hot work in safe location</li>
                                                        <li>Use appropriate PPEs</li>
                                                        <li>Check hose pipes</li>
                                                        <li>Check exhaust</li>
                                                    </div>
                                                    <div id="check4_Pinfo" runat="server">
                                                        <li>Provide safe means of access</li>
                                                        <li>Provide ladder attendant</li>
                                                    </div>
                                                    <div id="check5_Pinfo" runat="server">
                                                        <li>Provide safe means of access</li>
                                                        <li>Work to be carried out by trained manpower</li>
                                                        <li>Strict supervision required</li>
                                                        <li>First aider available</li>
                                                    </div>
                                                    <div id="check6_Pinfo" runat="server">
                                                        <li>Provide safe means of access</li>
                                                        <li>Provide fire watch/guard</li>
                                                        <li>Work to be carried out by trained manpower</li>
                                                        <li>Strict supervision required</li>
                                                        <li>First aider available</li>
                                                    </div>
                                                    <div id="check7_Pinfo" runat="server">
                                                        <li>Provide safe means of access</li>
                                                        <li>Work to be carried out by trained manpower</li>
                                                        <li>Strict supervision required</li>
                                                        <li>Use of scaffold</li>
                                                    </div>
                                                    <div id="check8_Pinfo" runat="server"></div>
                                                </ul>
                                            </div>
                                            <div class="d-block">
                                                <h5>PPE's</h5>
                                                <ul>
                                                    <div id="check1_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Safety shoes</li>
                                                        <li>High visibility jackets</li>
                                                        <li>Dust masks</li>
                                                        <li>Breathing apparatus</li>
                                                        <li>Fire extinguisher</li>
                                                        <li>Portable ladders</li>
                                                        <li>Belts attached to rope</li>
                                                        <li>Ear plugs/mufflers</li>
                                                        <li>Torch</li>
                                                    </div>
                                                    <div id="check2_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Safety shoes</li>
                                                        <li>High visibility jackets</li>
                                                        <li>Dust masks</li>
                                                        <li>Portable ladders</li>
                                                        <li>Provide fall protection</li>
                                                    </div>
                                                    <div id="check3_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Use appropriate instrument</li>
                                                        <li>Safety goggles/face shield</li>
                                                        <li>Safety gloves/apron</li>
                                                    </div>
                                                    <div id="check4_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Safety shoes</li>
                                                        <li>Portable ladders</li>
                                                        <li>Harness/Full body harness</li>
                                                    </div>
                                                    <div id="check5_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Safety shoes</li>
                                                        <li>Safety gloves/apron</li>
                                                        <li>Portable ladders</li>
                                                    </div>
                                                    <div id="check6_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Safety shoes</li>
                                                        <li>Portable ladders</li>
                                                    </div>
                                                    <div id="check7_PPEinfo" runat="server">
                                                        <li>Helmets</li>
                                                        <li>Safety shoes</li>
                                                        <li>Harness/Full body harness</li>
                                                        <li>Safety nets</li>
                                                        <li>Ropes</li>
                                                    </div>
                                                    <div id="check8_PPEinfo" runat="server"></div>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="page3" class="page-3 p-4">
                                        <div class="d-flex justify-content-between mt-3 mb-2">
                                            <button type="reset" class="btn btn-outline-secondary align-self-end invisible"
                                                onclick="clearFields('workDetails')">
                                                Back</button>
                                            <asp:Button ID="submit" CssClass="btn btn-success align-self-end" runat="server" Text="Submit" OnClick="SubmitFrom" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <%-- </asp:UpdatePanel>--%>
            </section>
                </div>
        <!-- /.content-wrapper -->
        
    </asp:Content>