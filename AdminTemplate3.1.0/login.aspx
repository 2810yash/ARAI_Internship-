<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdminTemplate3._1._0.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">

    <title>ARAI | Login</title>

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            min-height: 100vh; /* Ensure the body covers the entire viewport height */
        }

        .container {
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            flex: 1; /* Allow the container to expand to fill available space */
        }

        .login-box {
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            width: 300px;
        }

        .login-box p {
            font-size: 18px;
            text-align: center;
            margin-bottom: 20px;
        }

        .login-box1 label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        .login-box1 input[type="text"],
        .login-box1 input[type="password"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .sub-btn {
            width: 100%;
            padding: 10px;
            background-color: #2fba2c;
            border: none;
            border-radius: 4px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }

        .sub-btn:hover {
            background-color: #0056b3;
        }
    </style>

</head>
<body>
    <nav class="navbar navbar-expand-lg bg-secondary">
        <div class="container-fluid ">
            <a class="navbar-brand ms-5 text-light" href="#">ARAI</a>
            <div class="d-flex justify-content-end me-5" id="navbarText">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active text-dark text-decoration-underline" aria-current="page" href="login.aspx">Sign-In</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active text-dark" href="register.aspx">Sign-Up</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container">
        <form id="form1" runat="server">
            <div class="login-box">
                <div>
                    <p>
                        <b>ARAI</b>
                        <b>
                            <br />
                            <br />
                            &nbsp;Sign-In</b>
                    </p>
                </div>
                <div class="login-box1">

                    <asp:Label ID="Label1" runat="server" Text="Email-ID"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" required></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" CssClass="sub-btn" OnClick="Button1_Click" Text="Button" />

                </div>
            </div>
        </form>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>