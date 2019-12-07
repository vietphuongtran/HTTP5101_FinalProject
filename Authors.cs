using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Final_Project
{
    public class Authors
    {
        private string Authorfname;
        private string Authorlname;
        public string GetAuthorfname()
        {
            return Authorfname;
        }
        public string GetAuthorlname()
        {
            return Authorlname;
        }


        public void SetAuthorfname(string value)
        {
            Authorfname = value;
        }
        public void SetAuthorlname(string value)
        {
            Authorlname = value;
        }
    }
}