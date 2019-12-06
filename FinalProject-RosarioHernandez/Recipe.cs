using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace FinalProject_RosarioHernandez
{
    public class Recipe
    {
        private int recipeId;
        private string recipeName;
        private string recipeDescription;

        public int GetRecipeId()
        {
            return recipeId;
        }
        public string GetRecipeName()
        {
            return recipeName;
        }
        public string GetRecipeDescription()
        {
            return recipeDescription;
        }

        public void SetRecipeId(int value)
        {
            recipeId = value;
        }

        public void SetRecipeName(string value)
        {
            recipeName= value;
        }

        public void SetRecipeDescription(string value)
        {
            recipeDescription = value;
        }

    }
}
