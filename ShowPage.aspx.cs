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
            bool valid = true;
            //grabbing the pageid
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            //We will attempt to get the record we need
            if (valid)
            {
                var db = new Pagedb();
                Dictionary<String, String> page_record = db.FindPage(Int32.Parse(pageid));
                if (page_record.Count > 0)
                {
                    pagetitle.InnerHtml = page_record["pagetitle"];
                    pagebody.InnerHtml = page_record["pagebody"];
                    string QuickNavigation = "<a href =\"ShowPage.aspx?pageid=" + pageid + "\">" + page_record["pagetitle"] + "</a>";
                    quick_nav.InnerHtml += "<div>" + QuickNavigation + "</div>";
                }
            }      
        }
    }
}