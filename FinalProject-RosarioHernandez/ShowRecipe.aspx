<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowRecipe.aspx.cs" Inherits="FinalProject_RosarioHernandez.ShowRecipe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 runat="server" id="recipeName"></h2>
    <p runat="server" id="recipeDescription"></p>
    <asp:Button runat="server" text="Edit Recipe"  OnClick="Edit_Recipe"/>
    <asp:Button runat="server" OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" text="Delete Recipe" OnClick="Delete_Recipe"/>
</asp:Content>
