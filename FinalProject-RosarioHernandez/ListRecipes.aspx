<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListRecipes.aspx.cs" Inherits="FinalProject_RosarioHernandez.ListRecipes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
        
    <div>
        <asp:TextBox runat="server" ID="searchValue"></asp:TextBox>
        <asp:Button runat="server" text="Submit"/>
        <table>
            <thead>
                <tr>
                    <th>Recipe Id</th>
                    <th>Recipe Name</th>
                </tr>
            </thead>
            <tbody id="recipes" runat="server">
            </tbody>
        </table>
    </div>
</asp:Content>
