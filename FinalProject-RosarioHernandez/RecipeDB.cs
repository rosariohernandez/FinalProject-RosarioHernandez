using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace FinalProject_RosarioHernandez
{
    public class RecipeDB
    {
        private static string User { get { return "rosario"; } }
        private static string Password { get { return "test"; } }
        private static string Database { get { return "pagedb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }


        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();


            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);

                Connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connect);

                MySqlDataReader resultset = cmd.ExecuteReader();



                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();

                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }
                Console.WriteLine(ResultSet);
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }//code reference: SchoolDB.cs . Author:Christine Bittle.


        public Recipe FindRecipe(int id)
        {

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            Recipe result_recipe = new Recipe();


            try
            {

                string query = "select * from recipe where recipe_id = " + id;
                Debug.WriteLine("Connection Initialized...");

                Connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connect);

                MySqlDataReader resultset = cmd.ExecuteReader();


                List<Recipe> recipes = new List<Recipe>();


                while (resultset.Read())
                {

                    Recipe currentrecipe = new Recipe();


                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        switch (key)
                        {
                            case "recipe_id":
                                currentrecipe.SetRecipeId(Int32.Parse(value));
                                break;
                            case "recipe_name":
                                currentrecipe.SetRecipeName(value);
                                break;
                            case "recipe_description":
                                currentrecipe.SetRecipeDescription(value);
                                break;
                        }

                    }

                    recipes.Add(currentrecipe);
                }

                result_recipe = recipes[0];

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Something went wrong in the Find Recipe Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_recipe;
        }

        public void AddRecipe(Recipe new_recipe)
        {

            string query = "insert into recipe (recipe_id, recipe_name, recipe_description) values ('NULL','{0}','{1}')";
            query = String.Format(query, new_recipe.GetRecipeId(), new_recipe.GetRecipeName(), new_recipe.GetRecipeDescription());


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Add Recipe Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void EditRecipes(int recipeid, Recipe new_recipe)
        {

            string query = "update recipe set recipe_name='{0}', recipe_description='{1}' where recipe_id = " + recipeid;
            query = String.Format(query, new_recipe.GetRecipeId(), new_recipe.GetRecipeName(), new_recipe.GetRecipeDescription());


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try

            {
            Connect.Open();
            cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Something went wrong in the Edit Recipe Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();

           
        }


        public void DeleteRecipe(int recipeId)
        {
           
            string query = "delete from recipe where recipe_id = "+recipeId;
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
               
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine("Something went wrong in the Delete Recipe Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }

    }


}

