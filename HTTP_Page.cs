using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;


namespace Final_Project
{
    public class HTTP_Page
    {
        private string Pagetitle;
        private string Pagebody;
        public int Authorid;
        public string GetPagetitle()
        {
            return Pagetitle;
        }
        public string GetPagebody()
        {
            return Pagebody;
        }
        public int GetAuthorid()
        {
            return Authorid;
        }
        /*public string GetPagedate()
        {
            return Pagedate;
        }*/


        public void SetPagetitle(string value)
        {
            Pagetitle = value;
        }
        public void SetPagebody(string value)
        {
            Pagebody = value;
        }
        public void SetAuthorid(int value)
        {
            Authorid = value;
        }
    }
}