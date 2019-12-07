<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRecipe.aspx.cs" Inherits="FinalProject_RosarioHernandez.ShowRecipe" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

      <h3>Details for <span id="recipeName"  runat="server"></span></h3>
      <p>Recipe Description  <span id="recipeDescription" runat="server"></span></p>
      <asp:Button runat="server" text="Edit Recipe"  OnClick="Edit_Recipe"/>
      <asp:Button runat="server" OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" text="Delete Recipe" OnClick="Delete_Recipe"/>

    </div>
</asp:Content>
