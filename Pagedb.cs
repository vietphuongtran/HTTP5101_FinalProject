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
        //adding a new page
        public void Add_Page(HTTP_Page new_page)
        {
            string query = "insert into pages (pagetitle, pagebody, authorid) values('{0}', '{1}', '{2}')";
            query = string.Format(query, new_page.GetPagetitle(), new_page.GetPagebody(), new_page.GetAuthorid());
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Add_Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void Update_Page(int pageid, HTTP_Page new_page)
        {
            string query = "update pages set pagetitle='{0}', pagebody='{1}' where pageid={2}";
            query = String.Format(query, new_page.GetPagetitle(), new_page.GetPagebody(), pageid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {

                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Update_Page Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
        public void Delete_Page(int pageid)
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
                Debug.WriteLine("Something went wrong in the Delete_Page Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }

   
        public Authors FindAuthor(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            Authors result_author = new Authors();

            try
            {
                string query = "select * from authors where authorid = " + id;
                Debug.WriteLine("Connection Initialized...");
                Connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                MySqlDataReader resultset = cmd.ExecuteReader();
                List<Authors> authors = new List<Authors>();

                while (resultset.Read())
                {
                    Authors currentauthor = new Authors();
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        switch (key)
                        {
                            case "authorfname":
                                currentauthor.SetAuthorfname(value);
                                break;
                            case "authorlname":
                                currentauthor.SetAuthorlname(value);
                                break;                            
                        }
                    }
                    authors.Add(currentauthor);
                }
                result_author = authors[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Author method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_author;
        }
        //adding a new author
        public void Add_Author(Authors new_author)
        {
            string query = "insert into authors (authorfname, authorlname) values('{0}', '{1}')";
            query = String.Format(query, new_author.GetAuthorfname(), new_author.GetAuthorlname());
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Add_Author Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void Update_Author(int authorid, Authors new_author)
        {
            string query = "update authors set authorfname='{0}', authorlname='{1}' where authorid={2}";
            query = String.Format(query, new_author.GetAuthorfname(), new_author.GetAuthorlname(), authorid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {

                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Update_Author Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
        public void Delete_Author(int authorid)
        {
            string removeauthor = "delete from authors where authorid = {0}";
            removeauthor = String.Format(removeauthor, authorid);
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd_removeauthor = new MySqlCommand(removeauthor, Connect);
            try
            {
                Connect.Open();
                cmd_removeauthor.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removeauthor);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Delete_Author Method!");
                Debug.WriteLine(ex.ToString());
            }
            Connect.Close();
        }
    }
}