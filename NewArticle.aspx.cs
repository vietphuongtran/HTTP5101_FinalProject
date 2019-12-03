using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class NewArticle : System.Web.UI.Page
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
            //set page
            new_page.SetPagetitle(pagetitle.Text);
            new_page.SetPagebody(pagebody.Text);

            //add the page to the database
            db.AddPage(new_page);

            Response.Redirect("List_Pages.aspx");
        }
    }
}