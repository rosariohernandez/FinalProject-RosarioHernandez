﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RosarioHernandez
{
    public partial class EditRecipes: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                RecipeDB db = new RecipeDB();
                //ShowRecipeInfo(db);
            }
        }
    }
}