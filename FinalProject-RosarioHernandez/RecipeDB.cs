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

        //need to make a method here which
        //receives a query string (input)
        //outputs a list<dictionary<string, string>> output result set
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
            //Utilize the connection string
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            //create a "blank" student so that our method can return something if we're not successful catching student data
            Recipe result_recipe = new Recipe();

            //we will try to grab student data from the database, if we fail, a message will appear in Debug>Windows>Output dialogue
            try
            {
                //Build a custom query with the id information provided
                string query = "select * from recipe where recipe_id = " + id;
                Debug.WriteLine("Connection Initialized...");
                //open the db connection
                Connect.Open();
                //Run out query against the database
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();

                //Create a list of students (although we're only trying to get 1)
                List<Recipe> recipes = new List<Recipe>();

                //read through the result set
                while (resultset.Read())
                {
                    //information that will store a single student
                    Recipe currentrecipe= new Recipe();

                    //Look at each column in the result set row, add both the column name and the column value to our Student dictionary
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        //can't just generically put data into a dictionary anymore
                        //must go through each column one by one to insert data into the right property
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
                    //Add the student to the list of students
                    recipes.Add(currentrecipe);
                }

                result_recipe = recipes[0]; //get the first student

            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                Debug.WriteLine("Something went wrong in the find Recipes method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_recipe;
        }

        public void DeleteRecipe(int recipeId)
        {
            //The unenrol student doesn't need to be as careful
            //we can indiscriminately remove any instance of a student belonging to a particular class
            string query = "delete from recipe where recipe_id = "+recipeId;
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //try to remove the student from the class
                Connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //If something (anything) goes wrong with the try{} block, this block will execute
                //Check debug>windows>output 
                Debug.WriteLine("Something went wrong in the delete recipe method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }

    }


}

