using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RosarioHernandez
{
    public partial class ShowRecipe : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecipeDB db = new RecipeDB();
            //showing the base record student information
            ShowRecipeInfo(db);
        }

        protected void ShowRecipeInfo(RecipeDB db)
        {
            bool valid = true;
            string recipeId = Request.QueryString["recipe_id"];
            if (String.IsNullOrEmpty(recipeId)) valid = false;

            if (valid)
            {
                Recipe selectedRecipe = db.FindRecipe(Int32.Parse(recipeId));
                recipeName.InnerHtml = selectedRecipe.GetRecipeName();
                recipeDescription.InnerHtml = selectedRecipe.GetRecipeDescription();
            }
        }



        protected void Delete_Recipe(object sender, EventArgs e)
        {
            bool valid = true;
            string recipeId = Request.QueryString["recipe_id"];
            if (String.IsNullOrEmpty(recipeId)) valid = false;

            RecipeDB db = new RecipeDB();

            //deleting the recipe from the system
            if (valid)
            {
                db.DeleteRecipe(Int32.Parse(recipeId));
                Response.Redirect("ListRecipes.aspx");
            }
        }

        protected void Edit_Recipe(object sender, EventArgs e)
        {
            string recipeId = Request.QueryString["recipe_id"];
            Response.Redirect("EditRecipes.aspx?recipe_id=" + recipeId);
            
        }
    }
}