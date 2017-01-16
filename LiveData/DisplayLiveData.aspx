<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayLiveData.aspx.cs" Inherits="LiveData.DisplayLiveData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>SignalR</h1>
        <asp:Repeater runat="server" ID="BoardGameRepeater" ItemType="LiveData.UserModel">
            <HeaderTemplate>
                <table border="1">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>FirstName</th>
                            <th>LastName</th>
                            <th>Address</th>                            
                        </tr>
                    </thead>
                    <tbody id="BoardGameTblBody">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#: Item.Id %></td>
                    <td><%#: Item.FirstName %></td>
                    <td><%#: Item.LastName %></td>
                    <td><%#: Item.Address %></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate></tbody></table></FooterTemplate>
        </asp:Repeater>
    
    </div>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
        <script src="scripts/jQuery-1.10.2.min.js"></script>
        <script src="scripts/jquery.signalR-2.1.2.min.js"></script>
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
        <script type="text/javascript">
            $.connection.hub.logging = true;
            var hub = $.connection.RealTimeHub;
            alert("OK");
            alert(hub);
            hub.client.displayUsers = function (game) {
                $("#BoardGameTblBody").append("<tr><td>" + game.Id + "</td><td>" + game.FirstName + "</td><td>" + game.LastName + "</td><td>" + game.Address + "</td><td>");
            };
            $.connection.hub.start();
        </script>
    </form>
</body>
</html>
