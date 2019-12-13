using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RosarioHernandez
{
    public partial class AddRecipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        RecipeDB db = new RecipeDB();

            Recipe new_recipe = new Recipe();

            
            new_recipe.SetRecipeName(recipe_name.Text);
            new_recipe.SetRecipeDescription(recipe_description.Text);

            db.AddRecipe(new_recipe);

            Response.Redirect("ListRecipes.aspx");

        }
    }
}