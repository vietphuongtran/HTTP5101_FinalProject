using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pagedb db = new Pagedb();
                ShowPageInfo(db);
            }
            
        }
        protected void Update_Page(object sender, EventArgs e)
        {
            Pagedb db = new Pagedb();

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            if (valid)
            {
                HTTP_Page new_page = new HTTP_Page();
                //update the page
                new_page.SetPagetitle(edit_pagetitle.Text);
                new_page.SetPagebody(edit_pagebody.Text);

                //adding to the database
                try
                {
                    db.Update_Page(Int32.Parse(pageid), new_page);
                    Response.Redirect("~/ShowPage.aspx?pageid=" + pageid);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                editpage.InnerHtml = "There was an error updating that article.";
            }

        }

        //Show the information of the article that needs editting
        protected void ShowPageInfo(Pagedb db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;


            show_pagetitle.InnerHtml = "";
            show_pagebody.InnerHtml = "";
            
            if (valid)
            {

                HTTP_Page page_record = db.FindPage(Int32.Parse(pageid));
                show_pagetitle.InnerHtml = page_record.GetPagetitle();
                show_pagebody.InnerHtml = page_record.GetPagebody();

            }


            else
            {
                valid = false;
            }
            //Problem
                //1. Edit page did not work
                //Reason: the query in Pagedb.cs is wrong
                //Solution/status: fixed
                
                //2. The pagebody did not update
                //Reason: Because of the "'" apostrope that make the wrong query
                //Solution/status + Future reference: Look into SQL parameterized query C# ASP.NET

        }
      
    }
}