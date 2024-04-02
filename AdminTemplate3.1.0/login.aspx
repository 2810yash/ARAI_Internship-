<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdminTemplate3._1._0.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ARAI | Login</title>

    <style>
        body{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .login-box{
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

        .sub-btn{
            width: 100%;
            padding: 10px;
            background-color: #2fba2c;
            border: none;
            border-radius: 4px;
            color: #fff;
            font-size: 16px;
            cursor: pointer;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
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
                <asp:Button ID="Button1" runat="server" CssClass="sub-btn" OnClick="Button1_Click" Text="Button" />

            </div>
        </div>
    </form>
</body>
</html>
