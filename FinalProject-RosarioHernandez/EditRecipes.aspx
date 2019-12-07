<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRecipe.aspx.cs" Inherits="FinalProject_RosarioHernandez.ShowRecipe" %>
<asp:Content ID="EditRecipes" ContentPlaceHolderID="MainContent" runat="server">
    <div id="recipe" runat="server">
        <div class="viewnav">
            <a class="left" href="ShowRecipe.aspx?recipeid=<%=Request.QueryString["recipe_id"] %>">Cancel</a>
        </div>
        <h2>Edit Recipe Page <span id="recipeName" runat="server"></span></h2>
        
        <div class="formrow">
            <label>Recipe Name</label>
            <asp:TextBox runat="server" ID="recipe_name"></asp:TextBox>
        </div>
        <div class="formrow">
            <label>Recipe Description</label>
            <asp:TextBox runat="server" ID="recipe_description"></asp:TextBox>
        </div>
          <!-- 
          In this part of the code i could not figure out why I kept getting an error on OnCLick="Edit-recipe" . i got it. I had a typo. It was Edit_Recipe
      -->
       
        <asp:Button Text="Update Recipe Page" OnClick="Edit_Recipe" runat="server" />
    </div>
</asp:Content>