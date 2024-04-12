﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="AdminTemplate3._1._0.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <title>ARAI | Register</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            min-height: 100vh;
        }

        .container-regi {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            flex: 1;
        }

        /* Login box styles */
        .login-box {
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 50%;
            max-width: 40%;
        }

        .txt-box{
             width:100%;
        }

        .login-box p {
                font-size: 24px;
                text-align: center;
                margin-bottom: 20px;
        }

        /* Form input styles */
        .login-box1 label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .login-box1 input[type="text"],
        .login-box1 input[type="password"],
        .login-box1 .drop-down {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        /* Button styles */
        .sub-btn {
            width: 100%;
            padding: 10px;
            background-color: #2fba2c;
            border: none;
            border-radius: 4px;
            color: #fff;
            font-size: 18px;
            cursor: pointer;
        }

        .sub-btn:hover {
                background-color: #0056b3;
        }

        /* Link styles */
        .login-box1 a {
            text-decoration: none;
            color: #007bff;
            font-weight: bold;
        }

        .login-box1 a:hover {
                text-decoration: underline;
        }

        /* Navbar styles */
        .navbar {
            background-color: #343a40;
        }

        .navbar-brand {
            color: #fff !important;
            font-weight: bold;
        }

        .nav-link {
            color: #fff !important;
            font-weight: bold;
        }

        /* Center the logo */
        .navbar-brand {
            margin-left: auto;
            margin-right: auto;
        }

        /* Responsive adjustments */
        /*@media (max-width: 768px) {
            .login-box {
                width: 90%;*/ /* Adjusted for smaller screens */
            /*}
        }*/
    </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg bg-secondary">
        <div class="container-fluid ">
            <a class="navbar-brand ms-5 text-light" href="#">ARAI</a>
            <div class="d-flex justify-content-end me-5" id="navbarText">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active text-dark" href="login.aspx">Sign-In</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active text-dark text-decoration-underline" aria-current="page" href="register.aspx">Sign-Up</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container-regi">
        <form id="form1" runat="server" class="login-box">
            <div>
                <div>
                    <p>
                        <b>ARAI<br />
                            <br />
                            Sign-Up</b>
                    </p>
                </div>
                <div class="login-box1">
                    <%-- Name & E-mail --%>
                    <div class="d-flex">
                        <div class="d-block me-1 txt-box">
                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                            <br />
                            <asp:TextBox ID="regiName" runat="server" required></asp:TextBox>
                        </div>
                        <div class="d-block ms-1 txt-box">
                            <asp:Label ID="Label2" runat="server" Text="Email-ID"></asp:Label>
                            <br />
                            <asp:TextBox ID="regiEmail" runat="server" required></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <%-- Password & Re-Password --%>
                    <div class="d-flex">
                        <div class="d-block me-1 txt-box">
                            <asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label>
                            <br />
                            <asp:TextBox ID="regiPass" runat="server" required TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div class="d-block ms-1 txt-box">
                            Re-Enter Password :<br />
                            <asp:TextBox ID="regiRepass" runat="server" required TextMode="Password"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <%-- Role & Dept --%>
                    <div class="d-flex">
                        <div class="d-block me-1 txt-box">
                            Role:
                        <asp:DropDownList ID="roles" CssClass="drop-down" runat="server">
                            <asp:ListItem Text="-- Select Role --" Selected="false" Value="role"></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="admin"></asp:ListItem>
                            <asp:ListItem Text="User" Value="user"></asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <br />
                        <div class="d-block ms-1 txt-box">
                            Dept:
                        <asp:DropDownList ID="dept" CssClass="drop-down" runat="server"></asp:DropDownList>
                        </div>
                        <br />
                    </div>
                    <asp:Button ID="Button1" runat="server" CssClass="sub-btn" OnClick="Button1_Click" Text="Sign Up" />
                    <br />
                    <br />
                    Already have an account ?
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Sign-In</asp:LinkButton>
                </div>
            </div>
        </form>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
