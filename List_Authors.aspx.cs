using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class List_Authors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            authors_result.InnerHtml = "";
            string searchkey = "";
            if (Page.IsPostBack)
            {
                searchkey = author_search.Text;
            }

            string query = "select authors.* from authors";

            if (searchkey != "")
            {
                query += " WHERE authorfname like '%" + searchkey + "%' ";
                query += " or authorlname like '%" + searchkey + "%' ";
                
            }
            sql_debugger.InnerHtml = query;

            var db = new Pagedb();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                authors_result.InnerHtml += "<div class=\"list item\">";
                string authorid = row["authorid"];
                string authorfname = row["authorfname"];
                authors_result.InnerHtml += "<div class=\"col3\"><a href=\"ShowAuthor.aspx?authorid=" + authorid + "\">" + authorfname + "</a></div>";

                string authorlname = row["authorlname"];
                authors_result.InnerHtml += "<div class=\"col3\">" + authorlname + "</div>";

                authors_result.InnerHtml += "<div class=\"col3last\">" + /*"<a href =\"EditAuthor.aspx?studentid=" + authorid + "\">" + "Edit" + "</a>" + " " + " " + " " + "<a href =\"DeleteAuthor.aspx?studentid=" + authorid + "\">" + "Delete" + "</a>" + " " + " " + " " +*/ "<a href=\"ShowAuthor.aspx?authorid=" + authorid + "\">" + "View" + "</a></div>";
                
            }
            if (authors_result.InnerHtml == "")
            {
                authors_result.InnerHtml += "<div class=\"col2\">" + "There is no authors matches the search criteria" + "</div>";
            }
        }
        //Future development: Looking into debugging Edit Author and Delete Author from both tables
    }
}