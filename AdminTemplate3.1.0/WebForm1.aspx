<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdminTemplate3._1._0.WebForm1" %>

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

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Bootstrap JS and dependencies -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <style>
        .container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            background-color: #000000; /* background for container */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Optional: Adds a shadow to the container */
        }

        .area {
            background-color: blanchedalmond;
        }

        .carousel-item img {
            width: 100%;
            height: auto;
            max-height: 500px; /* Adjust this value as needed */
            object-fit: contain;
        }

        .position-relative form {
            background-color: #778899; /* grey background */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Optional: Adds a shadow to the container */
        }

        .radioinput {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-bottom: 20px;
        }

        .radio {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .hazard-study {
            font-weight: bold;
            margin-bottom: 10px;
        }

        input[type="radio"] {
            display: none;
        }

            input[type="radio"] + label {
                cursor: pointer;
                padding: 8px 20px;
                border: 2px solid #ccc;
                border-radius: 5px;
                margin-bottom: 5px;
                font-size: 16px;
            }

            input[type="radio"]:checked + label {
                background-color: #007bff;
                color: #fff;
                border-color: #007bff;
            }

        .container1 {
            max-width: 800px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .gridview input[type="text"] {
            width: 100%;
            box-sizing: border-box;
            padding: 5px;
            border: 1px solid #ccc;
        }

        .gridview th {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
        }

        .gridview td {
            padding: 10px;
        }

        content-wrapper position-relative main {
            background-color: antiquewhite;
        }

        .question-container {
            margin-bottom: 20px;
        }

        .question-label {
            font-weight: bold;
        }

        .text-box {
            display: block;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .submit-btn {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
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
                    font-weight: 500;
                    padding: 50px;
                    border-radius: 20px;
                    box-shadow: 0 0 10px rgb(56, 111, 111);
                    background-color: aliceblue;
                }

                    .heading h1 {
                        margin: 0;
                        font-family: 'sans-serif';
                        color: #00000;
                        font-weight: 1000;
                        text-shadow: 20px 20px 40px rgb(56, 111, 111);
                    }

                .image-row {
                    display: flex;
                    justify-content: space-around;
                    align-items: center;
                    background-color: #fff;
                    padding: 20px;
                    border-radius: 8px;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                    max-width: 100%;
                    margin-bottom: 10px;
                }

                    .image-row img {
                        max-width: 30%;
                        height: auto;
                        border-radius: 8px;
                        transition: transform 0.3s, box-shadow 0.3s;
                    }

                        .image-row img:hover {
                            transform: scale(1.05);
                            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
                        }
            </style>

            
            <br />
            <br />

            <div class="image-row">
                <img src="assets/im1.jpg" alt="Image 1" />
                <img src="assets/img2.jpg" alt="Image 2" />
                <img src="assets/img3.jpg" alt="Image 3" />
            </div>


            <div class="area">
                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="incident_id" required="required" runat="server"></asp:TextBox>
                        <span>Enter Incident Id</span>
                    </div>
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
                        <asp:TextBox CssClass="date-input" ID="name_of_affected_person" required="required" runat="server"></asp:TextBox>
                        <span>Name of Affected Person</span>
                    </div>
                </div>





                <div class="datentime">
                    <div class="inputBox">
                        <asp:DropDownList CssClass="date-input" ID="name_of_department" runat="server" required="required" onchange="enableIncidentDetails()">
                            <asp:ListItem Text=" " Value="" Disabled="true" Selected="true"></asp:ListItem>
                            <asp:ListItem Text="Quality Management Department" Value="QMD"></asp:ListItem>
                            <asp:ListItem Text="Prototype Manufacturing Department" Value="PMD"></asp:ListItem>
                            <asp:ListItem Text="Business&Development Planning" Value="BDCP"></asp:ListItem>
                            <asp:ListItem Text="Human Resource&Management&Administration" Value="HRMA"></asp:ListItem>
                            <asp:ListItem Text="Central Maintenance Cell" Value="CMC"></asp:ListItem>
                            <asp:ListItem Text="Infrastructure Development" Value="ID"></asp:ListItem>

                        </asp:DropDownList>
                        <span>Name of Department</span>
                    </div>
                </div>
                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="location_of_incident" required="required" runat="server"></asp:TextBox>
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
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_1" runat="server" >
                        <asp:ListItem Text="-- Select Incident Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Fractures" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Dislocations" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Sprains & Strains" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>

                </div>
                <div class="inputBox" id="subDropdown2" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_2" runat="server" >
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Gas " Value="1"></asp:ListItem>
                        <asp:ListItem Text="Dust " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Explosions" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>
                        <%--new--%>
                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>

                <div class="inputBox" id="subDropdown3" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_3" runat="server" >
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="heights" Value="1"></asp:ListItem>
                        <asp:ListItem Text=" Depths" Value="2"></asp:ListItem>
                        <asp:ListItem Text="person" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>


                <div class="inputBox" id="subDropdown4" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_4" runat="server" >
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Cave-Ins" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Slides" Value="2"></asp:ListItem>
                        <asp:ListItem Text="collapses" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown5" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_5" runat="server">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Lifting  "> Value="1"></asp:ListItem>
                        <asp:ListItem Text="Pushing " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Wrong Movements" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="4"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown7" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_6" runat="server">
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
                        <asp:TextBox CssClass="date-input" ID="describe_incident" required="required" runat="server"></asp:TextBox>
                        <span>Describe Incident/Accident</span>
                    </div>
                </div>

                <!-- Immediate Action Taken -->
                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="immediate_action" runat="server" required="required"></asp:TextBox>
                        <span>Immediate Action Taken</span>
                    </div>
                </div>

                

               
               <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="root1" runat="server" required="required"></asp:TextBox>
                        <span>Root Cause Analysis why 1</span>
                    </div>
                </div>
            <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="root2" runat="server" required="required"></asp:TextBox>
                        <span>Root Cause Analysis why 2</span>
                    </div>
                </div>
            </div>
            <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="root3" runat="server" required="required"></asp:TextBox>
                        <span>Root Cause Analysis why 3</span>
                    </div>
                </div>
            <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="root4" runat="server" required="required"></asp:TextBox>
                        <span>Root Cause Analysis why 4</span>
                    </div>
                </div>
            <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" ID="root5" runat="server" required="required"></asp:TextBox>
                        <span>Root Cause Analysis why 5</span>
                    </div>
                </div>
                <br />


                <div class="datentime">
                  
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" ID="corrective1" required="required"></asp:TextBox>
                        <span>Corrective action taken 1</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" ID="resp1" required="required"></asp:TextBox>
                        <span>Responsible person 1</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox TextMode="Date" CssClass="date-input" runat="server" ID="date1" required="required"></asp:TextBox>
                        <span>Date of Completion 1</span>
                    </div>
                </div>

                 <div class="datentime">
                  
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" ID="corrective2" required="required"></asp:TextBox>
                        <span>Corrective action taken 2</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" ID="resp2" required="required"></asp:TextBox>
                        <span>Responsible person 2</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox TextMode="Date" CssClass="date-input" runat="server" ID="date2" required="required"></asp:TextBox>
                        <span>Date of Completion 2</span>
                    </div>
                </div>

                <div class="datentime">
                  
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" ID="corrective3" required="required"></asp:TextBox>
                        <span>Corrective action taken 3</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" ID="resp3" required="required"></asp:TextBox>
                        <span>Responsible person 3</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox TextMode="Date" CssClass="date-input" runat="server" ID="date3" required="required"></asp:TextBox>
                        <span>Date of Completion 3</span>
                    </div>
                </div>

                
       
               <%--<div class="datentime">
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
                        <span>Responsible Person</span>
                    </div>
                </div>

                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input" runat="server" required="required" ID="TextBox3"></asp:TextBox>
                        <span>Corrective Action Impact</span>
                    </div>
                </div>--%>


                <div class="radioinput">
                    <div class="radio">
                        <div class="hazard-study">IS HAZARD STUDY UPDATED?</div>
                       <style>
                            /* Add your CSS here */
                            .hazard-study {
                                font-size: 25px; /* Adjust the font size */
                                font-weight: bold; /* Make the text bold */
                                color: #000000; /* Set the text color */
                                margin-bottom: 10px; /* Add some space below the heading */
                            }
                        </style>
                        <div>
                            <asp:RadioButton ID="RadioYes" Text="Yes" runat="server" GroupName="Hazard_Study" OnClick="toggleFileInput(true)" />
                            <asp:RadioButton ID="RadioNo" Text="No" runat="server" GroupName="Hazard_Study" OnClick="toggleFileInput(false)" />
                        </div>

                        <div class="file" id="fileUpload">
                            <span class="upload-arrow">&#x25BC;</span>
                            <asp:FileUpload ID="FileUpload1" runat="server" OnClickEvent="toggleFileInput(show)" />
                            <asp:Label ID="StatusLabel" runat="server"  />
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
                        <asp:TextBox
                            CssClass="date-input text-area"
                            TextMode="MultiLine"
                            required="required"
                            runat="server"
                            ID="remarks">
                        </asp:TextBox>
                        <span>Remarks(If Any)</span>
                    </div>
                </div>

                <style>
                    .date-input.text-area {
                        width: 95%; /* Adjust the width as needed */
                        height: 100px; /* Adjust the height as needed */
                        overflow-y: auto; /* Adds a vertical scrollbar */
                        white-space: pre-wrap; /* Ensures text wraps to the next line */
                        word-wrap: break-word; /* Breaks long words and wraps to the next line */
                        padding: 10px; /* Adds padding inside the textarea */
                        box-sizing: border-box; /* Ensures padding and border are included in the width and height */
                        resize: vertical; /* Allows the user to resize the height of the textarea */
                    }
                </style>


                <div class="subbtn">
                <asp:Button OnClick="submitForm" Text="SUBMIT" CssClass="submit btn btn-primary" runat="server" onsubmit="return validateForm();"/>
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

