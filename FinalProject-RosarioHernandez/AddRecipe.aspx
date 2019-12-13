<%@ Page Title="AddRecipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListRecipes.aspx.cs" Inherits="FinalProject_RosarioHernandez.ListRecipes" %>

<asp:Content ID="AddRecipe" ContentPlaceHolderID="MainContent" runat="server">
    <div id="recipe" runat="server">
        <div class="viewnav">
            <a class="left" href="ShowRecipe.aspx?recipeid=<%=Request.QueryString["recipe_id"] %>">Cancel</a>
        </div>
        <h2>Add Recipe Page <span id="recipeName" runat="server"></span></h2>
        
        <div class="formrow">
            <label>Recipe Name</label>
            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
        </div>
        <div class="formrow">
            <label>Recipe Description</label>
            <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
        </div>
         
        <asp:Button Text="Add Recipe Page" OnClick="Add_Recipe" runat="server" />
    </div>
</asp:Content>




