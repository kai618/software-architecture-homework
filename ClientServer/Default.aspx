<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientServer.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Keyword: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
            </div>
            <hr />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
        </div>
        <hr />
        <div>
            <asp:Button ID="Button_add" runat="server" Text="Add" OnClick="Button_add_Click" />
            <asp:Button ID="Button_update" runat="server" Text="Update" OnClick="Button_update_Click" />
            <asp:Button ID="Button_delete" runat="server" Text="Delete" OnClick="Button_delete_Click" OnClientClick="confirm('Are you sure?')"/>
        </div>
        <div>
            <br />
            <div>
                <asp:Label ID="Label2" runat="server" Text="Id: "></asp:Label><br />
                <asp:TextBox ID="TextBox_Id" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="Label3" runat="server" Text="Uploader: "></asp:Label><br />
                <asp:TextBox ID="TextBox_Uploader" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="Label4" runat="server" Text="Title: "></asp:Label><br />
                <asp:TextBox ID="TextBox_Title" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="Label5" runat="server" Text="Tags: "></asp:Label><br />
                <asp:TextBox ID="TextBox_Tags" runat="server"></asp:TextBox>
            </div>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Description: "></asp:Label><br />
            <asp:TextBox ID="TextBox_Description" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label7" runat="server" Text="Url: "></asp:Label><br />
            <asp:TextBox ID="TextBox_Url" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label8" runat="server" Text="Timestamp:"></asp:Label><br />
            <asp:TextBox ID="TextBox_Timestamp" runat="server"></asp:TextBox>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
