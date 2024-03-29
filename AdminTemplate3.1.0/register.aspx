<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="AdminTemplate3._1._0.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Submit1 {
            width: 166px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="login-box position-relative d-flex justify-content-center align-items-center">
        <div>
            <div>
                <p>
                    <b>ARAI</b>
                </p>
            </div>
            <div class="login-box1">

                <asp:Label ID="Label1" runat="server" Text="Email-ID"></asp:Label>
                &nbsp;:<br />
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <br />
                Re-Enter Password :<br />
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign Up" Width="164px" />
                <br />
                <br />
                Already have account ?
                &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Sign-In</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>
