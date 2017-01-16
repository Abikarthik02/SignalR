<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="InsertDatausingWebAPI.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <script src="scripts/jquery-3.1.1.js" type="text/javascript"></script>  
      
    <script type="text/javascript">  
        alert("OK");
         
        function AddUser() {  
            
           
            var User = {};  
            User.FirstName = $("#txtFirstName").val();
            User.LastName = $("#txtLastName").val();
            User.Address = $("#txtAddress").val();
  
  
            $.ajax({  
                url:"<%=Page.ResolveUrl("http://localhost:9000/api/DataFeed/PostRegisterUsers")%>",   
                type: "POST",
                headers: {'Content-Type': 'application/x-www-form-urlencoded'},
                //contentType: "application/x-www-form-urlencoded;charset=utf-8",
                data: {FirstName: User.FirstName, LastName: User.LastName , Address: User.Address },
                success: function (response) {  
  
                    alert(response);           
  
                },  
  
                error: function (x, e) {  
                    alert('Failed');  
                    alert(x.responseText);  
                    alert(x.status);  
  
                }  
            });   
        }       
   
        $(document).ready(function ()  
         {   
            $("#btnSubmit").click(function (e) {               
  
                AddUser();  
                e.preventDefault();  
            });    
        });  
  
    </script>  

</head>
<body>
    <form id="form1" runat="server">
    <div>
         <br /><br />  
    <table>  
        <tr>  
            <td>  
                First Name  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtFirstName" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                Last Name  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtLastName" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                Address  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtAddress" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
            </td>  
            <td>  
                <asp:Button Text="Submit" runat="server" ID="btnSubmit" />  
            </td>  
        </tr>  
    </table>  
    <br />  
      
    
    </div>
    </form>
</body>
</html>
