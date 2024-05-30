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
                <div class="heading">
                    <h1>ACCIDENT-INCIDENT</h1>
                </div>
                <style>
                    .heading {
                        text-align: center;
                        font-weight: 200;
                        padding: 50px;
                        border-radius: 20px;
                        box-shadow: 0 0 10px rgb(56, 111, 111);
                    }

                        .heading h1 {
                            margin: 0;
                            font-family: 'Arial', sans-serif;
                            color: #6a3e95;
                            text-shadow: 20px 20px 40px rgb(56, 111, 111);
                        }
                </style>

                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox TextMode="Date" CssClass="date-input" runat="server" ID="date_of_incident" required="required"></asp:TextBox>
                        <span>Date of Incident/Accident</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox TextMode="Time" CssClass="date-input" runat="server" ID="time_of_incident" required="required"></asp:TextBox>
                        <span>Time of Incident/Accident</span>
                    </div>
                </div>


                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="name_person" required="required" runat="server"></asp:TextBox>
                        <span>Name of Affected Person</span>
                    </div>
                </div>

                <div class="datentime">
                    <div class="inputBox">
                        <asp:DropDownList CssClass="date-input" ID="dept_name" runat="server" required="required" onchange="enableIncidentDetails()">
                            <asp:ListItem Text=" " Value="" Disabled="true" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="QMD" Value="1"></asp:ListItem>
                            <asp:ListItem Text="PMD" Value="2"></asp:ListItem>
                            <asp:ListItem Text="BDCP" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <span>Name of Department</span>
                    </div>
                </div>
                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="accident_location" required="required" runat="server"></asp:TextBox>
                        <span>Location of incident/accident</span>
                    </div>
                </div>

                <div class="datentime">
                    <div class="inputBox">
                        <asp:DropDownList CssClass="dropdown-input" ID="nature_of_incident" runat="server" onchange="toggleSubDropdown(this)" required="required">
                            <asp:ListItem Text="-- Select Nature of Incident/Accident --" Value="" Disabled="true" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="Injury" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Explosions" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Fall of Persons" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Fall of Objects" Value="4"></asp:ListItem>
                            <asp:ListItem Text="Over-Exertion" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Contact with electric current" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Caught between objects" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Striking against moving objects" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Stepping on objects" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="10"></asp:ListItem>
                        </asp:DropDownList>
                        <div id="othersTextBox" style="display: none;">
                            <input type="text" id="txtOthers" placeholder="Enter details" />
                        </div>

                    </div>
                </div>




                <div class="inputBox" id="subDropdown1" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="DropDownListSubNatureOfIncident" runat="server" required="required">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Fractures" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Dislocations" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Sprains & Strains" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown2" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="DropDownList2" runat="server" required="required">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Gas " Value="1"></asp:ListItem>
                        <asp:ListItem Text="Dust " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Explosions" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>

                <div class="inputBox" id="subDropdown3" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="DropDownList3" runat="server" required="required">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="heights" Value="1"></asp:ListItem>
                        <asp:ListItem Text=" Depths" Value="2"></asp:ListItem>
                        <asp:ListItem Text="person" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>


                <div class="inputBox" id="subDropdown4" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="DropDownList4" runat="server" required="required">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Cave-Ins" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Slides" Value="2"></asp:ListItem>
                        <asp:ListItem Text="collapses" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown5" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="DropDownList5" runat="server" required="required">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Lifting  "> Value="1"></asp:ListItem>
                        <asp:ListItem Text="Pushing " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Wrong Movements" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown7" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="DropDownList7" runat="server" required="required">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text=" object" Value="1"></asp:ListItem>
                        <asp:ListItem Text=" Stationary " Value="2"></asp:ListItem>
                        <asp:ListItem Text=" Moving" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>





                <script>
                    function toggleSubDropdown(dropdown) {
                        var subDropdown1 = document.getElementById("subDropdown1");
                        var subDropdown2 = document.getElementById("subDropdown2");
                        var subDropdown3 = document.getElementById("subDropdown3");
                        var subDropdown4 = document.getElementById("subDropdown4");
                        var subDropdown5 = document.getElementById("subDropdown5");
                        var subDropdown7 = document.getElementById("subDropdown7");

                        var dropDown = document.getElementById("<%= nature_of_incident.ClientID %>");
                        var selectedValue = dropDown.options[dropDown.selectedIndex].value;
                        var textBox = document.getElementById("othersTextBox");
                        var txtOthers = document.getElementById("txtOthers");

                        if (dropdown.value === "1") {
                            subDropdown1.style.display = "block";
                            subDropdown2.style.display = "none";
                            subDropdown3.style.display = "none";
                            subDropdown4.style.display = "none";
                            subDropdown5.style.display = "none";
                            subDropdown6.style.display = "none";
                            subDropdown7.style.display = "none";
                        }
                        else if (dropdown.value === "2") {
                            subDropdown1.style.display = "none";
                            subDropdown2.style.display = "block";
                            subDropdown3.style.display = "none";
                            subDropdown4.style.display = "none";
                            subDropdown5.style.display = "none";
                            subDropdown6.style.display = "none";
                            subDropdown7.style.display = "none";
                        }
                        else if (dropdown.value === "3") {
                            subDropdown1.style.display = "none";
                            subDropdown2.style.display = "none";
                            subDropdown3.style.display = "block";
                            subDropdown4.style.display = "none";
                            subDropdown5.style.display = "none";
                            subDropdown6.style.display = "none";
                            subDropdown7.style.display = "none";
                        }
                        else if (dropdown.value === "4") {
                            subDropdown1.style.display = "none";
                            subDropdown2.style.display = "none";
                            subDropdown3.style.display = "none";
                            subDropdown4.style.display = "block";
                            subDropdown5.style.display = "none";
                            subDropdown6.style.display = "none";
                            subDropdown7.style.display = "none";
                        }
                        else if (dropdown.value === "5") {
                            subDropdown1.style.display = "none";
                            subDropdown2.style.display = "none";
                            subDropdown3.style.display = "none";
                            subDropdown4.style.display = "none";
                            subDropdown5.style.display = "block";
                            subDropdown6.style.display = "none";
                            subDropdown7.style.display = "none";
                        }
                        else if (dropdown.value === "7") {
                            subDropdown1.style.display = "none";
                            subDropdown2.style.display = "none";
                            subDropdown3.style.display = "none";
                            subDropdown4.style.display = "none";
                            subDropdown5.style.display = "none";
                            subDropdown6.style.display = "none";
                            subDropdown7.style.display = "block";
                        }

                        else {
                            subDropdown.style.display = "none";
                        }
                    }
                </script>

                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="describtion" required="required" runat="server"></asp:TextBox>
                        <span>Describe Incident/Accident</span>
                    </div>
                </div>


                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="immediate_action" required="required" runat="server"></asp:TextBox>
                        <span>Immediate Action Taken</span>
                    </div>
                </div>

                <div class="new-div">
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
                            <asp:TextBox CssClass="date-input" required="required" runat="server" ID="responsible_person"></asp:TextBox>
                            <span>Responsible Person</span>
                        </div>
                    </div>

                    <div class="datentime">
                        <div class="inputBox">
                            <asp:TextBox CssClass="date-input" runat="server" required="required" ID="corrective_action_impact"></asp:TextBox>
                            <span>Corrective Action Impact</span>
                        </div>
                    </div>


                    <div class="radioinput">
                        <div class="radio">
                            <div class="hazard-study">Hazard Study Updated?</div>
                            <div>
                                <asp:RadioButton ID="hazard_update" runat="server" />
                                <asp:RadioButton ID="RadioButton1" runat="server" />
                            </div>
                            <div class="file" id="fileUpload" style="display: none;">
                                <span class="upload-arrow">&#x25BC;</span>
                                <!-- Downward arrow indicating file upload -->
                                <input type="file" />
                            </div>
                        </div>
                    </div>

                    <script>
                        function toggleFileInput(show) {
                            var fileUpload = document.getElementById("fileUpload");
                            if (show) {
                                fileUpload.style.display = "block";
                                alert("Please upload a file."); // Popup message
                            } else {
                                fileUpload.style.display = "none";
                            }
                        }
                    </script>



                    <div class="new block">
                        <div class="inputBox">
                            <asp:TextBox CssClass="date-input" required="required" runat="server" ID="remarks"></asp:TextBox>
                            <span>Remarks(If Any)</span>
                        </div>
                    </div>
                    <div class="subbtn">
                        <asp:Button OnClientClick="return validateForm();" Text="SUBMIT" CssClass="submit btn btn-primary" runat="server" />
                    </div>

                    <script>
                        function validateForm() {
                            var date = document.getElementById('<%= date_of_incident.ClientID %>').value;
        var time = document.getElementById('<%= time_of_incident.ClientID %>').value;

                            if (date.trim() === '' || time.trim() === '') {
                                alert('Please fill in both Date and Time fields.');
                                return false; // Prevent form submission
                            }
                            return true; // Allow form submission
                        }
                    </script>



                </div>
            </div>
        </div>

</asp:Content>

