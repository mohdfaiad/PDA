using System;
using System.Collections.Generic;
using System.Text;

namespace PDAScan
{
    public class CurrentUser
    {
        public static string USERSN
        {
            get { return _usersn; }
            set { _usersn = value; }
        }
        private static string _usersn;
    }
}
