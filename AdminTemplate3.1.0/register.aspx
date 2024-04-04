<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="AdminTemplate3._1._0.register" %>

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

        .login-box1 {
            margin-top: 20px;
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

        .sub-btn:hover {
            background-color: #0056b3;
        }

        .login-box1 a {
            text-decoration: none;
            color: #007bff;
            font-weight: bold;
        }

            .login-box1 a:hover {
                text-decoration: underline;
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

        .drop-down {
            display: block;
            width: 100%;
            padding: .375rem 2.25rem .375rem .75rem;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
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
                        <a class="nav-link active text-dark text-decoration-underline" aria-current="page" href="register.aspx">Sign-Up</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active text-dark" href="login.aspx">Sign-In</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container">
    <form id="form1" runat="server" class="login-box">
        <div>
            <div>
                <p>
                    <b>ARAI<br /><br />Sign-Up</b>
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
                Re-Enter Password :<br />
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                Role:
                <asp:DropDownList ID="roles" CssClass="drop-down" runat="server">
                    <asp:ListItem Text="-- Select Role --" Selected="false" value="role"></asp:ListItem>
                    <asp:ListItem Text="Admin" value="admin"></asp:ListItem>
                    <asp:ListItem Text="User" value="user"></asp:ListItem>
                </asp:DropDownList>
                <br />

                <asp:Button ID="Button1" runat="server" CssClass="sub-btn" OnClick="Button1_Click" Text="Sign Up" />
                <br /><br />
                Already have an account ? <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Sign-In</asp:LinkButton>
            </div>
        </div>
    </form>
        </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
