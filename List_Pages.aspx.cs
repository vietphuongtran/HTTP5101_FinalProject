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
        protected void QuickNavigation(object sender, EventArgs e)
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            pages_result.InnerHtml = "";
            quick_nav.InnerHtml = "";
            string searchkey = "";
            
            if (Page.IsPostBack)
            {
                searchkey = page_search.Text;
            }

            string query = "select pages.*, concat(authorfname, ' ', authorlname) as 'author full name' from pages left join authors on authors.authorid = pages.authorid";

            if (searchkey != "")
            {
                query += " WHERE pagetitle like '%" + searchkey + "%' ";
                query += " or pagebody like '%" + searchkey + "%' ";
                query += " or authorfname like '%" + searchkey + "%' ";
                query += " or authorlname like '%" + searchkey + "%' ";
                //query += " or pagedate like '" + searchkey + "' ";
            }
            //sql_debugger.InnerHtml = query;

            var db = new Pagedb();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pages_result.InnerHtml += "<div class=\"list item\">";
                string pageid = row["pageid"];
                string authorid = row["authorid"];
                string authorname = row["author full name"];
                string ListofArticles = "<a href =\"ShowPage.aspx?pageid=" + pageid + "\">" + row["pagetitle"] + "</a>"
                    + "<div>" + row["pagebody"] + "</div>"
                    + "<div>" + "Written by: " + "<a href =\"ShowAuthor.aspx?authorid=" + authorid + "\">" + authorname + "</a></div>"
                + "<a href =\"EditPage.aspx?pageid=" + pageid + "\">Edit</a>";
                pages_result.InnerHtml += "<div class=\"col2\">" + ListofArticles + "</div>";
                string QuickNavigation = "<a href =\"ShowPage.aspx?pageid=" + pageid + "\">" + row["pagetitle"] + "</a>";
                quick_nav.InnerHtml += "<div>" + QuickNavigation + "</div>";
            }
            if (pages_result.InnerHtml == "")
            {
                pages_result.InnerHtml += "<div class=\"col2\">" + "There is no article matches the search criteria" + "</div>";
            }
            

                     
            //Problem: 
            //Can not display pagedate
            //Reason: the pagedate format is not right.
            //Status: unsolved, temporary solution: delete the date



            //Future development: 
            //reset the name pages to articles to match the context. I tried reseting but it made the whole project collapsed so I just go with it.
            //the quick navigation should stay the same and will not be modified by the query.
        }
        
            


}
}