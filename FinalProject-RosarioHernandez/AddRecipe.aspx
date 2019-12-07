
<%@ Page Title="AddRecipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="FinalProject_RosarioHernandez.AddRecipe" %>
 
<asp:Content ID="newrecipe" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Recipe </h2>
    <div class="formrow">
        <label>Recipe Name</label>
        <asp:TextBox runat="server" ID="recipe_name"></asp:TextBox>
    </div>
    <div class="formrow">
        <label>Recipe Description</label>
        <asp:TextBox runat="server" ID="recipe_description"></asp:TextBox>
    </div>
    

    <asp:Button OnClick="Add_recipe" Text="Add Recipe" runat="server" />
</asp:Content>
