<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdminTemplate3._1._0.login" %>

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="Styles/login.css" rel="stylesheet" />
        <title>Log in</title>
    </head>

    <body>
        <form id="form1" runat="server"
            class="login-box position-relative d-flex justify-content-center align-items-center">
            <div>
                <div>
                    <p>
                        <b>ARAI</b>
                    </p>
                </div>
                <div class="login-box1">

                    <asp:Label ID="Label1" runat="server" Text="Email-ID"></asp:Label>
&nbsp;:<br />
                    <input id="Text1" type="text" /><br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                    <br />
                    <input id="Password1" type="password" /><br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Sign-In" Width="166px" CssClass="btn btn-sucsess" OnClick="Button1_Click" />
                    <br />
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server">Forgot Password?</asp:LinkButton>
                    <br />
                    Don&#39;t have account ? <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="btn btn-success"> Sign Up</asp:LinkButton>

                </div>

            </div>
        </form>
    </body>

    </html>