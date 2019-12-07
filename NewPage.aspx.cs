using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add_Page(object sender, EventArgs e)
        {
            
            //create connection
            Pagedb db = new Pagedb();

            //create a new particular page
            HTTP_Page new_page = new HTTP_Page();
            //detail about the page
            new_page.SetPagetitle(add_pagetitle.Text);
            new_page.SetPagebody(add_pagebody.Text);
            new_page.SetAuthorid(Int32.Parse(add_authorid.Text));


            //add the page to the database
            db.Add_Page(new_page);

            Response.Redirect("List_Pages.aspx");
            //Problem: When adding authorid in, the new page can not be added to the database, there is sth wrong in the List-Query method
            //Reason: 1. the authorid is added to the insert statement (solved) 2. the authorid is not convert from string into int
            //Status: solved
        }
       
    }
}