﻿<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdminTemplate3._1._0.WebForm1" %>

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
            background-color:eff4f7;
        }

        /*.carousel-item img {
            width: 100%;
            height: auto;
            max-height: 500px; /* Adjust this value as needed */
            object-fit: contain;
        }*/

        .position-relative form {
            background-color: #778899; /* grey background */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); /* Optional: Adds a shadow to the container */
        }

        

        .hazard-study {
            font-weight: bold;
            margin-bottom: 10px;
        }

        .radio input[type="radio"] {
                display: none;
            }

            .radio label {
                display: inline-block;
                padding: 10px 20px;
                margin: 5px;
                cursor: pointer;
                border: 2px solid #007bff;
                border-radius: 5px;
                background-color: #f8f9fa;
                color: #007bff;
                font-size: 16px;
                transition: background-color 0.3s, color 0.3s;
            }

            .radio input[type="radio"]:checked + label {
                background-color: #007bff;
                color: #ffffff;
            }

            .radio label:hover {
                background-color: #e2e6ea;
            }

        .container1 {
            max-width: 800px;
            margin: 0 auto;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        

        content-wrapper position-relative main {
            background-color:aliceblue
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

        /new front end style Begins here/


        .marquee-container {
            /*border: 1px solid red;
            padding: 5px;
            background-color: #f9f9f9;*/
             border: 1px solid red;
            padding: 5px;
            background-color:blanchedalmond;
            overflow: hidden;
            white-space: nowrap;
            text-align: center;
        }

        .marquee-text {
            
             color: red;
            font-size: 16px;
            animation: blink 1s step-start infinite;
        }
        .navbar-container {
    width: 100%;
    background-color: #003366;
    padding: 10px 0;
    display: flex;
    justify-content: center;
}

.navbar {
    display: flex;
    align-items: center;
    color: white;
}

.nav-item {
    display: flex;
    align-items: center;
    padding: 0 15px;
}

.nav-item .nav-icon {
    width: 30px;
    height: 30px;
    margin-right: 5px;
}

.nav-arrow {
    padding: 0 10px;
}

.nav-text {
    color: white;
    font-size: 16px;
}
body {
            margin: 0;
            font-family: Arial, sans-serif;
        }
        .header {
            background-color: #003399;
            color: white;
            padding: 10px 20px;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }
        .header-title {
            font-size: 24px;
            font-weight: bold;
        }
        .header-subtitle {
            font-size: 14px;
        }
        .header-icons {
            display: flex;
            align-items: center;
        }
        .header-icons img {
            margin: 0 5px;
            height: 30px;
        }
        .header-links {
            margin-left: 20px;
        }
        .header-links a {
            color: white;
            margin: 0 10px;
            text-decoration: none;
        }
        .header-links a:hover {
            text-decoration: underline;
        }
        
        .radio input[type="radio"] {
                display: none;
            }

            .radio label {
                display: inline-block;
                padding: 10px 20px;
                margin: 5px;
                cursor: pointer;
                border: 2px solid #007bff;
                border-radius: 5px;
                background-color: #f8f9fa;
                color: #007bff;
                font-size: 16px;
                transition: background-color 0.3s, color 0.3s;
            }

            .radio input[type="radio"]:checked + label {
                background-color: #007bff;
                color: #ffffff;
            }

            .radio label:hover {
                background-color: #e2e6ea;
            }

            .file {
                display: none;
                margin-top: 10px;
            }

            .upload-arrow {
                font-size: 20px;
                margin-right: 10px;
            }



            .navbar-container {
    position: relative;
}

.nav-item {
    display: inline-block;
    position: relative;
}

.tooltip {
    position: absolute;
    background-color:black;
    color: #fff;
    padding: 5px 10px;
    border-radius: 5px;
    display: none;
    z-index: 1000;
    white-space: nowrap;
}

.tooltip::after {
    content: '';
    position: absolute;
    border-width: 5px;
    border-style: solid;
    border-color: transparent transparent #333 transparent;
    top: 100%;
    left: 50%;
    transform: translateX(-50%);
}

/* styles.css */
body {
    transition: background-color 0.5s, color 0.5s;
}

/* Day Theme */
.day-theme {
    background-color: white;
    color: black;
}

/* Night Theme */
.night-theme {
    background-color: #222222;
    color: white;
}

/* Toggle Switch */
.switch {
    position: relative;
    display: inline-block;
    width: 60px;
    height: 34px;
}

.switch input {
    opacity: 0;
    width: 0;
    height: 0;
}

.slider {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #ccc;
    transition: .4s;
}

.slider:before {
    position: absolute;
    content: "";
    height: 26px;
    width: 26px;
    left: 4px;
    bottom: 4px;
    background-color: white;
    transition: .4s;
}

input:checked + .slider {
    background-color: #2196F3;
}

input:checked + .slider:before {
    transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
    border-radius: 20px;
}

.slider.round:before {
    border-radius: 50%;
}

/new front end style ends here/






    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-wrapper position-relative main">
         <div class="header">
            <div>
                 <div class="header-title">Automotive Research Association of India</div>
                <div class="header-subtitle">Research Institute of the Automotive Industry with the Ministry of Heavy Industries, Govt. of India</div>
            </div>
            <div class="header-icons">
                
                <img src="assets/motorcycle.png" />
                <img src="assets/car.png" />
                <img src="assets/bus.png" />
                <img src="assets/construction.png" />
                <img src="assets/cargo-truck.png" />
                <label class="switch">
                <input type="checkbox" onclick="toggleTheme()">
                <span class="slider round"></span>
            </label>
                <script>
                    function toggleTheme() {
                        var body = document.body;
                        if (body.classList.contains('day-theme')) {
                            body.classList.remove('day-theme');
                            body.classList.add('night-theme');
                        } else {
                            body.classList.remove('night-theme');
                            body.classList.add('day-theme');
                        }
                    }
</script>

</div>
                   </div>
            
            <br />

             <div class="marquee-container">
            <marquee class="marquee-text" behavior="scroll" direction="left" scrollamount="5">
                
                Welcome to the online reporting portal of INCIDENT-ACCIDENT Analysis of ARAI.
                    
            </marquee>
        </div>
         
        <br />
        

         <div class="navbar-container">
    <div class="navbar">
        <%--<div class="nav-item">
            <img src="Content/report.png" class="nav-icon" />
            <span class="nav-text">Incident-Accident Online Report</span>
        </div>--%>
        <%--<div class="nav-arrow">></div>--%>
        <div class="nav-item" data-tooltip="Finding Better Methods to Deal Accident cases.">
            <span class="nav-text">Methodologies</span>
        </div>
        <div class="nav-arrow"><</div>
        <div class="nav-item" data-tooltip="Adding Detailed Description helps better analysis.">
            <img src="assets/edit-info.png" class="nav-icon" />
            <span class="nav-text">Incident Description</span>
        </div>
        <div class="nav-item" data-tooltip="Reporting Dynamics of the Accident is important.">
            <img src="assets/insurance.png" class="nav-icon" />
            <span class="nav-text">Accident Dynamics</span>
        </div>
        <div class="nav-item" data-tooltip="It is a 5 WHY? analysis step.">
            <img src="assets/root-cause.png" class="nav-icon" />
            <span class="nav-text">Root Cause Analysis</span>
        </div>
        <div class="nav-item" data-tooltip=" Recommendations for better work environments can be added in remarks section.">
            <img src="assets/guidelines.png" class="nav-icon" />
            <span class="nav-text">Recommendations</span>
        </div>
        <div class="nav-item" data-tooltip="Concluding report to avoid further scenarioes">
            <img src="assets/lightbulb.png" class="nav-icon" />
            <span class="nav-text">Conclusions</span>
        </div>
        <div class="nav-arrow">></div>

    </div>
</div>

<div class="tooltip" id="tooltip"></div>
        <script>
            document.addEventListener('DOMContentLoaded', function () {
                const tooltip = document.getElementById('tooltip');
                const navItems = document.querySelectorAll('.nav-item');

                navItems.forEach(item => {
                    item.addEventListener('mouseenter', function () {
                        const tooltipText = this.getAttribute('data-tooltip');
                        tooltip.textContent = tooltipText;
                        tooltip.style.display = 'block';

                        const rect = this.getBoundingClientRect();
                        tooltip.style.top = ${ rect.bottom + window.scrollY } px;
                        tooltip.style.left = ${ rect.left + (rect.width / 2) - (tooltip.offsetWidth / 2) + window.scrollX } px;
                    });

                    item.addEventListener('mouseleave', function () {
                        tooltip.style.display = 'none';
                    });
                });
            });

        </script>

 
       

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
            <div class="area">
            <div class="image-row">
                <img src="assets/im1.jpg" alt="Image 1" />
                <img src="assets/img2.jpg" alt="Image 2" />
                <img src="assets/img3.jpg" alt="Image 3" />
            </div>


            
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
                            <asp:ListItem Text="Injury" Value="Injury"></asp:ListItem>
                            <asp:ListItem Text="Explosions" Value="Explosions"></asp:ListItem>
                            <asp:ListItem Text="Fall of Persons" Value="Fall of Persons"></asp:ListItem>
                            <asp:ListItem Text="Fall of Objects" Value="Fall of Objects"></asp:ListItem>
                            <asp:ListItem Text="Over-Exertion" Value="Over-Exertion"></asp:ListItem>
                            <asp:ListItem Text="Contact with electric current" Value="Contact with electric current"></asp:ListItem>
                            <asp:ListItem Text="Caught between objects" Value="Caught between Objects"></asp:ListItem>
                            <asp:ListItem Text="Striking against moving objects" Value="Striking against moving objects"></asp:ListItem>
                            <asp:ListItem Text="Stepping on objects" Value="Stepping on objects"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                        </asp:DropDownList>
                        <div id="othersTextBox" style="display: none;">
                            <input type="text" id="txtOthers" placeholder="Enter details" />
                        </div>

                    </div>
                </div>




                <div class="inputBox" id="subDropdown1" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_1" runat="server" >
                        <asp:ListItem Text="-- Select Incident Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Fractures" Value="Fractures"></asp:ListItem>
                        <asp:ListItem Text="Dislocations" Value="Dislocations"></asp:ListItem>
                        <asp:ListItem Text="Sprains & Strains" Value="Sprains & Strains"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>

                    </asp:DropDownList>

                </div>
                <div class="inputBox" id="subDropdown2" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_2" runat="server" >
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Gas " Value="Gas"></asp:ListItem>
                        <asp:ListItem Text="Dust " Value="Dust"></asp:ListItem>
                        <asp:ListItem Text="Explosions" Value="Explosion"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                        <%--new--%>
                    </asp:DropDownList>
                   
                </div>

                <div class="inputBox" id="subDropdown3" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_3" runat="server" >
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="heights" Value="Heights"></asp:ListItem>
                        <asp:ListItem Text=" Depths" Value="Depths"></asp:ListItem>
                        <asp:ListItem Text="person" Value="Person"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>


                <div class="inputBox" id="subDropdown4" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_4" runat="server" >
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Cave-Ins" Value="Cave-Ins"></asp:ListItem>
                        <asp:ListItem Text="Slides" Value="Slides"></asp:ListItem>
                        <asp:ListItem Text="collapses" Value="Collapses"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown5" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_5" runat="server">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text="Lifting  " Value="Lifting"></asp:ListItem>
                        <asp:ListItem Text="Pushing " Value="Pushing"></asp:ListItem>
                        <asp:ListItem Text="Wrong Movements" Value="Wrong Movements"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>

                    </asp:DropDownList>
                    <span>TYPE</span>
                </div>
                <div class="inputBox" id="subDropdown7" style="display: none;">
                    <asp:DropDownList CssClass="dropdown-input" ID="drop_down_6" runat="server">
                        <asp:ListItem Text="-- Select Type --" Value="" Disabled="false" Selected="true"></asp:ListItem>
                        <asp:ListItem Text=" object" Value="Object"></asp:ListItem>
                        <asp:ListItem Text=" Stationary " Value="Stationary"></asp:ListItem>
                        <asp:ListItem Text=" Moving" Value="Moving"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>

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

                <div class="datentime">
                    <div class="inputBox">
                        <asp:TextBox CssClass="date-input remarks" ID="remarks" TextMode="MultiLine" required="required" runat="server" ></asp:TextBox>
                        <span>Remarks</span>
                    </div>
                </div>

               <%-- <div class="new block">
                    <div class="inputBox">
                        <asp:TextBox
                            CssClass="date-input"
                            TextMode="MultiLine"
                            required="required"
                            runat="server"
                            ID="remarks">
                        </asp:TextBox>
                        <span>Remarks(If Any)</span>
                    </div>
                </div>--%>

                <style>
                    .remarks {
                        width: 95%;  /*Adjust the width as needed */
                        height: 100px;  /*Adjust the height as needed */
                        overflow-y: auto;  /*Adds a vertical scrollbar */
                        white-space: pre-wrap;  /Ensures text wraps to the next line/ 
                        word-wrap: break-word;  /Breaks long words and wraps to the next line/ 
                        padding: 10px;  /*Adds padding inside the textarea */
                        box-sizing: border-box;  /Ensures padding and border are included in the width and height/
                        resize: vertical;  /Allows the user to resize the height of the textarea/
                    }

                    /*.remarks {
                        width: 100%;
                        height: 80px !important;
                    }*/
                       
                </style>


                <div class="subbtn">
                <asp:Button OnClick="submitForm" Text="SUBMIT" CssClass="submit btn btn-primary" runat="server" onsubmit="return validateForm();"/>
                </div>

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
    


</asp:Content>