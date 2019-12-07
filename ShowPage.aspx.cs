using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Pagedb db = new Pagedb();
            ShowPageInfo(db);
        }
        protected void ShowPageInfo(Pagedb db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            
            show_pagetitle.InnerHtml = "";
            show_pagebody.InnerHtml = "";
            //We will attempt to get the record we need
            if (valid)
            {

                HTTP_Page page_record = db.FindPage(Int32.Parse(pageid));
                show_pagetitle.InnerHtml = page_record.GetPagetitle();
                show_pagebody.InnerHtml = page_record.GetPagebody();
                edit_page.InnerHtml="<div><a href =\"EditPage.aspx?pageid=" + pageid + "\">Edit</a></div>";

            }

            else
            {
                valid = false;
            }


            if (!valid)
            {
                error_summary.InnerHtml = "There was an error finding that article.";
            }
        }
        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            Pagedb db = new Pagedb();

            //deleting the page from the database
            if (valid)
            {
                db.Delete_Page(Int32.Parse(pageid));
                Response.Redirect("List_Pages.aspx");
            }
        }
    }
}