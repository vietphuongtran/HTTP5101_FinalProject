using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project
{
    public partial class EditAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             Pagedb db = new Pagedb();
            ShowAuthorInfo(db);
            
           

        }
        //Show the information of the article that needs editting
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

            if (!valid)
            {
                editauthor.InnerHtml = "There was an error finding that author.";
            }
        }
        protected void Update_Author(object sender, EventArgs e)
        {
            Pagedb db = new Pagedb();

            bool valid = true;
            string authorid = Request.QueryString["authorid"];
            if (String.IsNullOrEmpty(authorid)) valid = false;
            if (valid)
            {
                Authors new_author = new Authors();
                //update author
                new_author.SetAuthorfname(edit_authorfname.Text);
                new_author.SetAuthorlname(edit_authorlname.Text);

                //adding to the database
                try
                {
                    db.Update_Author(Int32.Parse(authorid), new_author);
                    Response.Redirect("~/ShowAuthor.aspx?authorid=" + authorid);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                editauthor.InnerHtml = "There was an error updating that author.";
            }

        }

        

    }
}