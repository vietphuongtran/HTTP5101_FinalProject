using System;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public class Pagedb
    {
        //this code is create by Christine Bittle, modified by Paul Tran for education purposes
        //trying to connect to a database
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "dailybugle"; } }
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
        //trying to get a result set from the database
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();
            //try and catch method
            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();

                //display the result set
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }//end row
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
        }
        public int Modify_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query" + query);
                //open the db connection
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return 1;
        }
        //Finding a particular page in the Daily Bugle Newspaper
        public HTTP_Page FindPage(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            HTTP_Page result_page = new HTTP_Page();

            try
            {
                string query = "select * from PAGES where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();
                List<HTTP_Page> pages = new List<HTTP_Page>();

                while (resultset.Read())
                {
                    HTTP_Page currentpage = new HTTP_Page();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        switch (key)
                        {
                            case "pagetitle":
                                currentpage.SetPagetitle(value);
                                break;
                            case "pagebody":
                                currentpage.SetPagebody(value);
                                break;
                            case "pagedate":
                                currentpage.SetPagedate(DateTime.ParseExact(value, "M/d/yyyy hh:mm:ss tt", new CultureInfo("en-US")));
                                break;
                        }
                    }
                    pages.Add(currentpage);
                }
                result_page = pages[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Page method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }
        //adding a student
        public void AddPage(HTTP_Page new_page)
        {
            string query = "insert into pages (pagebody, pagetitle) values('{0}', '{1}', '{2}')";
            query = String.Format(query, new_page.GetPagetitle(), new_page.GetPagebody());
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void UpdatePage(int pageid, HTTP_Page new_page)
        {
            string query = "update pages set pagetitle ='{0}', pagebody ='{1}' where pageid ='{3}'";
            query = String.Format(query, new_page.GetPagetitle(), new_page.GetPagebody(), pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //Try to update a student with the information provided to us.
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                //If that doesn't seem to work, check Debug>Windows>Output for the below message
                Debug.WriteLine("Something went wrong in the UpdatePage Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
        public void DeletePage(int pageid)
        {
            string removepage = "delete from pages where pageid = {0}";
            removepage = String.Format(removepage, pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd_removepage = new MySqlCommand(removepage, Connect);
            try
            {
                Connect.Open();
                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the delete Page Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
    }
}