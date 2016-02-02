<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Defoult.aspx.cs" Inherits="WebSmartHouse.Defoult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link  href="Content/MyCss.css" rel="stylesheet"/>
</head>
<body>

    <div id="MainDiv">

    <div id="Top" class="AllIteam"  >
             <img src="Content/top.PNG" width="800"/>
    </div>
        
    <form id="main" runat="server">
    <div style="width: 991px; height: 537px;">
        <div id="ButtBlok" >
              <asp:Button ID="LampButt" runat="server" Text="Lamp" CssClass="ButtonMenu"/><br />
              <asp:Button ID="FridgeButt" runat="server" Text="Fridge" CssClass="ButtonMenu"/><br />
              <asp:Button ID="TapRiderButt" runat="server" Text="Tape rider" CssClass="ButtonMenu"/><br />
              <asp:Button ID="ConditionerButt" runat="server" Text="Conditioner" CssClass="ButtonMenu"/><br />
              <asp:Button ID="TVButt" runat="server" Text="TV" CssClass="ButtonMenu" /><br />
              <asp:Button ID="KettleButt" runat="server" Text="Kettle" CssClass="ButtonMenu" />
              <asp:Button ID="AddDevice" runat="server" Text="Add Device" CssClass="ButtonMenu" />
        </div>
        
         <div id="Panel">
            <asp:Panel ID="DevicePanel" runat="server" Width="862px" Height="517px">

            </asp:Panel>          
        </div>
         
       </div> 
    </form>
        </div>
</body>
</html>
