using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class ShowAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pagedb db = new Pagedb();
            ShowAuthorInfo(db);
            ShowAuthorArticle(db);
        }
        protected void ShowAuthorInfo(Pagedb db)
        {

            bool valid = true;
            string authorid = Request.QueryString["authorid"];
            if (String.IsNullOrEmpty(authorid)) valid = false;


            show_authorfname.InnerHtml = "";
            show_authorlname.InnerHtml = "";

            if (valid)
            {

                Authors author_record = db.FindAuthor(Int32.Parse(authorid));
                show_authorfname.InnerHtml = author_record.GetAuthorfname();
                show_authorlname.InnerHtml = author_record.GetAuthorlname();
                show_authorfullname.InnerHtml = show_authorfname.InnerHtml + " " + show_authorlname.InnerHtml;
            }
            else
            {
                valid = false;
            }

        }
        protected void ShowAuthorArticle(Pagedb db)
        {
            string authorid = Request.QueryString["authorid"];    

            string query = "select pages.* from pages inner join authors on pages.authorid = authors.authorid where authors.authorid=" + authorid;
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                string pagetitle = row["pagetitle"];
                string pagebody = row["pagebody"];
                show_author_article.InnerHtml += "<div id=\"MainContent_show_pagetitle\">" + pagetitle + "</div><div id=\"MainContent_show_pagebody\">" + pagebody + "</div>";
            }
        }
    }
}