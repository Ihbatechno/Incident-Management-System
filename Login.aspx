<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IMS.Login" %>

<!DOCTYPE html>
<html>
<head>
    <link href='https://fonts.googleapis.com/css?family=Ubuntu:500' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

<!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

<!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

        body {
            background: url('img/imagecb.jpg'), 100% 100%; 
           
            background-repeat:no-repeat;
            background:linear-gradient(to left, #c21500 , #ffc500);
            
            height:100%;
            width:100%;
             opacity:0.8;
             
             /*background-image: linear-gradient(to right top, #e9ff02, #f7d900, #fcb200, #fb8b00, #f36200, #f36100, #f36100, #f36000, #fb8800, #fdaf00, #f9d400, #eff907);*/ 
             /*background-image: linear-gradient(to left top, #f2a20c, #f29200, #f18100, #ef6f00, #ed5b00, #ec5e00, #ec6000, #eb6300, #ec7a00, #eb8f00, #e8a400, #e5b70f);*/
            margin: 0px;
            font-family: 'Ubuntu', sans-serif;
            z-index:0;
        }

        h1, h2, h3, h4, h5, h6, a {
            margin: 0;
            padding: 0;
        }

      
        .login-header {
            margin:10px auto;
            color: white;
            text-align: center;
            font-size: 100%;
        }
        /* .login-header h1 {
   text-shadow: 0px 5px 15px #000; } */

        /* .login-form {
  border:.5px solid #fff;
  background:#f5f6f8;
  border-radius:10px;
  box-shadow:0px 0px 10px #000;
} */
        .login-form h3 {
            text-align: left;
            margin-left:40px;
            color: rgb(8, 8, 8);
        }

        .login-form {
            box-sizing: border-box;
            padding-top: 15px;
            padding-bottom: 1%;
            margin: 5% auto;
            text-align: center;
        }

        .login .is1,
        .login .is2 {
            max-width: 400px;
            width: 80%;
            line-height: 3em;
            font-family: 'Ubuntu', sans-serif;
            margin: 1em 2em;
            border-radius: 5px;
            border: 2px solid #f2f2f2;
            outline: none;
            padding-left: 10px;
        }

        .login-form .is3 {
            height: 30px;
            width: 21%;
            background: #fff;
            border: 1px solid #f2f2f2;
            border-radius: 20px;
            color: black;
            text-transform: uppercase;
            font-family: 'Ubuntu', sans-serif;
            cursor: pointer;
        }

        .sign-up {
            color: #f2f2f2;
            margin-left: -70%;
            cursor: pointer;
            text-decoration: underline;
        }

        .no-access {
            color: #E86850;
            /* margin:20px 0px 20px -57%; */
            text-decoration: underline;
            cursor: pointer;
        }

        .try-again {
            color: #f2f2f2;
            text-decoration: underline;
            cursor: pointer;
        }

        .isils {
            background-color: rgba(3, 3, 3, 0.42) !important;
        }

        .isils1 {
            background-color: coral;
            border-radius: 5px;
            height: 30px;
            width: 21%;
            border: 1px solid #f2f2f2;
            border-radius: 20px;
            color: black;
            text-transform: uppercase;
            font-family: 'Ubuntu', sans-serif;
            cursor: pointer;
        }

            .isils1:hover {
                background: linear-gradient(left, rgba(241,231,103,1) 0%, rgba(241,231,103,1) 30%, rgba(252,70,82,1) 88%, rgba(252,70,82,1) 100%);
            }
        /*Media Querie*/
        @media only screen and (min-width : 150px) and (max-width : 530px) {
            .login-form h3 {
                text-align: center;
                margin: 0;
            }

            .sign-up, .no-access {
                margin: 10px 0;
            }

            .login-button {
                margin-bottom: 10px;
            }
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js"></script>

    <%--  <script  type="text/javascript">
function validate()
{
      if (document.getElementById("<%=txtemail.ClientID%>").value=="")
      {
                 alert("Email field cannot not be empty,please enter email");
                 document.getElementById("<%=txtemail.ClientID%>").focus();
                 return false;
      }
      if(document.getElementById("<%=txtpwd.ClientID %>").value=="")
      {
                 alert("Password field cannot be Empty, Please enter the Password");
                document.getElementById("<%=txtpwd.ClientID %>").focus();
                return false;
      }
      return true;
     }
 </script>--%>
</head>
<body>
    <form runat="server" id="loginform">
        <div>
            <div id="formContent">
                <h2 id="hmsg" style="color: aqua" runat="server"></h2>
                <!-- Tabs Titles -->
                <div class="login-page">
                    <div class="form">
                        <div class="login">
                            <div class="login-header">
                                <br>
                                <h3>Incident Management System</h3>
                            </div>
                            <div class="login-form">
                                <%--
                   
                            
                              <h3>Username:</h3>
                              <input type="text" id="login" name="login" placeholder="Username" class="is1"/><br>
                              <h3>Password:</h3>
                              <input type="password" id="password" name="login" placeholder="Password" class="is2"/>
                              <br>
                              <input type="button" value="Login" class="login-button isils is3 " size="50"/>
                              <br>
                             <br>
                              <h6 class="no-access" style="text-align:center;font-size: 20px;">&cwint;orget password?</h6>
                            </div>
                          </div>
                                              
                    <!-- <input type="text" id="login" name="login" placeholder="User id">
                    <input type="text" id="password"  name="login" placeholder="password" style="-webkit-text-security: disc; text-emphasis-style: disc">
                    <input type="submit" class=" forex2" id="col_h" value="Log In"> -->
                    
                                --%>
                                <asp:TextBox ID="txtemail" runat="server" CssClass="is1" placeholder="Email" autocomplete="off" autofocus></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="rfvtxtemail" runat="server" ErrorMessage="Enter Email" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rgetxtemail" runat="server" ErrorMessage="Email format is incorrect" ControlToValidate="txtemail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <br />

                                <asp:TextBox ID="txtpassword" runat="server" CssClass="is2" placeholder="Password" autocomplete="off" Style="-webkit-text-security: disc"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="rfvpwd" ControlToValidate="txtpassword" runat="server" ErrorMessage="Enter password" ForeColor="red"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="btlogin" runat="server" Text="Login" OnClick="btlogin_Click" CssClass="login-button isils is3" /><br />
                                <br />
                                <asp:Button ID="btnLoginWithGoogle" runat="server" CssClass="isils1" Text="Login With Google" OnClick="btnLoginWithGoogle_Click" CausesValidation="false" /><br />
                                <%-- <asp:Button ID="btnLoginWithFacebook" runat="server" Text="Login With Facebook" OnClick="btnLoginWithFacebook_Click" CausesValidation="false"  />--%>

                                <fb:login-button scope="public_profile,email" onlogin="checkLoginState();">
    </fb:login-button>

                                <%--  <a href="#"> &cwint;orgot Password?</a>--%>
                                <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>


                        <!-- Remind Passowrd -->
                        <!-- <div id="formFooter">

            </div>-->

                    </div>
    </form>

    <script>
        // This is called with the results from from FB.getLoginStatus().
        function statusChangeCallback(response) {
            console.log('statusChangeCallback');
            console.log(response);
            if (response.status === 'connected') {
                testAPI();

            } else {
                document.getElementById('status').innerHTML = 'Please log ' +
                    'into this app.';
            }
        }


        function checkLoginState() {
            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });
        }

        window.fbAsyncInit = function () {
            FB.init({
                appId: '339007656653785',
                xfbml: true,
                version: 'v3.2'
            });

            FB.getLoginStatus(function (response) {
                statusChangeCallback(response);
            });

        };

        // Load the SDK asynchronously
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "https://connect.facebook.net/en_US/sdk.js";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        function testAPI() {
            console.log('Welcome!  Fetching your information.... ');
            FB.api('/me', function (response) {
                console.log('Successful login for: ' + response.name);
                document.getElementById('status').innerHTML =
                    'Thanks for logging in, ' + response.name + '!';

                window.open("~/Dashboard/ManageTrash1.aspx");
            });
        }
    </script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js">$('.error-page').hide(0);

    $('.login-button , .no-access').click(function(){
      $('.login').slideUp(500);
      $('.error-page').slideDown(1000);
    });
    
    $('.try-again').click(function(){
      $('.error-page').hide(0);
      $('.login').slideDown(1000);
    });</script>

</body>
</html>
