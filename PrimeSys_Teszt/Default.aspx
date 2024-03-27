<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimeSys_Teszt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link rel="stylesheet" type="text/css" href="Styles/styles.css" runat="server" media="screen"/>
    </head>
    <div class="row">
        <div>
            <h2>Product Management</h2>
            <div>
                Termék neve: <asp:TextBox ID="txtProductName" runat="server" /><br /><br />
                Termék ára: &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPrice" runat="server" /><br /><br />
                <asp:Button ID="btnAddProduct" runat="server" Text="Hozzáadás" OnClick="btnAddProduct_Click" />
            </div>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="RowEditing"
                OnRowDeleting="RowDeleting" OnRowUpdating="RowUpdating" OnRowCancelingEdit="RowCancelingEdit">
                <Columns>
                    <asp:TemplateField HeaderText="#ID" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblEditID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date of Add">
                        <ItemTemplate>
                            <asp:Label ID="lblMade" runat="server" Text='<%# Eval("Made", "{0:MM/dd/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date of Expire">
                        <ItemTemplate>
                            <asp:Label ID="lblExpire" runat="server" Text='<%# Eval("Expire", "{0:MM/dd/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete" EditText="Edit"
                        HeaderText="Operations" ItemStyle-HorizontalAlign="Center" ControlStyle-Width="70px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
