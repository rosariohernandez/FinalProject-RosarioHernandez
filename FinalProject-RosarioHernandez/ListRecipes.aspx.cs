using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject_RosarioHernandez
{
    public partial class ListRecipes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            recipies.InnerHtml = "";

            string searchkey = "";
            if (Page.IsPostBack)
            {
               
                searchkey = searchValue.Text;
            }


            string query = "select * from recipe";

            if (searchkey != "")
            {
                query += " WHERE recipe_name like '%" + searchkey + "%' ";
            }
            
            var db = new RecipeDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                recipies.InnerHtml += "<tr>";

                string recipeid = row["recipe_id"];
                recipies.InnerHtml += "<td>" + recipeid + "</td>";

                string recipename = row["recipe_name"];
                recipies.InnerHtml += "<td><a href=\"ShowRecipe.aspx?recipe_id="+recipeid+"\">" + recipename + "</a></td>";

                recipies.InnerHtml += "</tr>";
            }

            //the algorithm needs to call the database method for list query

            //passing in the query "select * from recipes;"

            //takes the result set as a List<Dictionary<String,String>>

            //runs a loop through each item in the result set

            //need to make markup that goes into the interface
        }
    }
}