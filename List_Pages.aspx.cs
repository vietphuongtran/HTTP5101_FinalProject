using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Final_Project
{
    public partial class List_Pages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pages_result.InnerHtml = "";
            quick_nav.InnerHtml = "";


            string query = "select * from pages";

            var db = new Pagedb();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pages_result.InnerHtml += "<div class=\"list item\">";
                string pageid = row["pageid"];
                string ListofArticles = "<a href =\"ShowPage.aspx?pageid=" + pageid + "\">" + row["pagetitle"] + "</a>"
                    + "<div>" + row["pagebody"] + "</div>"
                    + "<div><a href =\"ShowPage.aspx?pageid=" + pageid + "\">" + "Edit" + "</a></div>"
                pages_result.InnerHtml += "<div class=\"col2\">" + ListofArticles + "</div>";
                string QuickNavigation = "<a href =\"ShowPage.aspx?pageid=" + pageid + "\">" + row["pagetitle"] +"</a>";
                quick_nav.InnerHtml += "<div>" + QuickNavigation + "</div>";
            }
            string searchkey = "";
            if (Page.IsPostBack)
            {
                
                searchkey = page_search.Text;

                
                //string query = "select * from pages";

                if (searchkey != "")
                {
                    query += " WHERE pagetitle like '%" + searchkey + "%' ";
                    query += " or pagebody like '%" + searchkey + "%' ";
                    //query += " or pagedate like '" + searchkey + "' ";
                }
                sql_debugger.InnerHtml = query;
                if (pages_result.InnerHtml == "")
                {
                    pages_result.InnerHtml += "There is no article matches the search criteria";
                }
            }

        }
    }
}